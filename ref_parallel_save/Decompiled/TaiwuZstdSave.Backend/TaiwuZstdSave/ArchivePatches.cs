using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using GameData.ArchiveData;
using HarmonyLib;
using SQLite;
using ZstdNet;

namespace TaiwuZstdSave;

internal static class ArchivePatches
{
    [HarmonyPatch(typeof(ArchiveFileBase), "Save")]
    private static class ArchiveSavePatch
    {
        private static void Prefix(ArchiveFileBase __instance, ref CompressionAlgorithm algorithm, string ___Path)
        {
            if (!(__instance is LocalArchiveFile) || !CompatibilityBackup.IsMainArchivePath(___Path))
            {
                return;
            }
            if (ModSettings.VacuumBeforeSave)
            {
                VacuumDatabaseBeforeSave();
            }
            if (ModSettings.UseParallelDeflate)
            {
                algorithm = (CompressionAlgorithm)0;
                _useParallelDeflateForCurrentSave = NativeZlibNg.IsAvailable;
                if (_useParallelDeflateForCurrentSave)
                {
                    ModLog.Info("使用快速模式（并行 DEFLATE）保存 " + Path.GetFileName(___Path) + "。");
                }
                else
                {
                    ModLog.Warning("zlib-ng 不可用，本次保存已回退到原版 DEFLATE。");
                }
            }
            else if (ModSettings.UseZstd)
            {
                if (!CompatibilityBackup.EnsureBeforeZstdSave(___Path))
                {
                    algorithm = (CompressionAlgorithm)0;
                    ModLog.Warning("未能建立有效的兼容备份，本次保存已回退到原版 DEFLATE。");
                    return;
                }
                algorithm = (CompressionAlgorithm)254;
                ModLog.Info($"使用 {ModSettings.Mode} 保存 {Path.GetFileName(___Path)}。");
            }
        }

        private static Exception? Finalizer(Exception? __exception)
        {
            _useParallelDeflateForCurrentSave = false;
            return __exception;
        }
    }

    [HarmonyPatch(typeof(CompressionStreamFactory), "StartCompression", new Type[]
    {
        typeof(Stream),
        typeof(CompressionAlgorithm),
        typeof(CompressionType)
    })]
    private static class StartCompressionPatch
    {
        private static bool Prefix(Stream stream, CompressionAlgorithm algorithm, ref Stream __result)
        {
            //IL_0000: Unknown result type (might be due to invalid IL or missing references)
            //IL_0050: Unknown result type (might be due to invalid IL or missing references)
            //IL_0056: Invalid comparison between Unknown and I4
            if ((int)algorithm == 0 && _useParallelDeflateForCurrentSave)
            {
                try
                {
                    __result = new ParallelDeflateStream(stream, ModSettings.WorkerCount);
                    return false;
                }
                catch (Exception value)
                {
                    _useParallelDeflateForCurrentSave = false;
                    ModLog.Warning($"创建并行 DEFLATE 流失败，已回退到原版 DEFLATE：{value}");
                    return true;
                }
            }
            if ((int)algorithm != 254)
            {
                return true;
            }
            NativeZstd.EnsureInitialized();
            CompressionStream stream2 = new CompressionStream(stream, ModSettings.CreateCompressionOptions(), 1048576);
            __result = new BufferedStream(stream2, 1048576);
            return false;
        }
    }

    [HarmonyPatch(typeof(CompressionStreamFactory), "StartDecompression", new Type[]
    {
        typeof(Stream),
        typeof(CompressionAlgorithm)
    })]
    private static class StartDecompressionPatch
    {
        private static bool Prefix(Stream stream, CompressionAlgorithm algorithm, ref Stream __result)
        {
            //IL_0000: Unknown result type (might be due to invalid IL or missing references)
            //IL_0006: Invalid comparison between Unknown and I4
            if ((int)algorithm != 254)
            {
                return true;
            }
            Stream? stream2 = PrepareZstdStream(stream) ?? throw new InvalidDataException("存档标记为 Zstd，但内容不是有效的 Zstd 帧。");
            NativeZstd.EnsureInitialized();
            DecompressionStream stream3 = new DecompressionStream(stream2, 1048576);
            __result = new BufferedStream(stream3, 1048576);
            return false;
        }
    }

    private sealed class LimitedReadStream(Stream inner, long length) : Stream
    {
        private long _remaining = length;

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Read(buffer.AsSpan(offset, count));
        }

        public override int Read(Span<byte> buffer)
        {
            int num = (int)Math.Min(buffer.Length, _remaining);
            int num2 = ((num != 0) ? inner.Read(buffer.Slice(0, num)) : 0);
            _remaining -= num2;
            return num2;
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }

    private sealed class PrefixReadStream(byte[] prefix, Stream inner) : Stream
    {
        private int _prefixOffset;

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Read(buffer.AsSpan(offset, count));
        }

        public override int Read(Span<byte> buffer)
        {
            int num = Math.Min(buffer.Length, prefix.Length - _prefixOffset);
            if (num > 0)
            {
                prefix.AsSpan(_prefixOffset, num).CopyTo(buffer);
                _prefixOffset += num;
            }
            int num2 = ((num != buffer.Length) ? inner.Read(buffer.Slice(num)) : 0);
            return num + num2;
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                inner.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public const byte ZstdAlgorithm = 254;

    private static readonly byte[] ZstdFrameMagic = new byte[4] { 40, 181, 47, 253 };

    private static readonly FieldInfo? LiteConnectionField = AccessTools.Field(typeof(DatabaseBridge), "_liteConnection");

    [ThreadStatic]
    private static bool _useParallelDeflateForCurrentSave;

    private static void VacuumDatabaseBeforeSave()
    {
        try
        {
            object? obj = LiteConnectionField?.GetValue(null);
            SQLiteConnection val = (SQLiteConnection)((obj is SQLiteConnection) ? obj : null);
            if (val == null)
            {
                ModLog.Warning("存档前无法取得 SQLite 连接，已跳过 VACUUM。");
                return;
            }
            if (val.IsInTransaction)
            {
                ModLog.Warning("SQLite 连接仍处于事务中，已跳过本次 VACUUM。");
                return;
            }
            Stopwatch stopwatch = Stopwatch.StartNew();
            VacuumPreflightResult vacuumPreflightResult;
            try
            {
                vacuumPreflightResult = SqliteVacuumPreflight.Evaluate(val.DatabasePath);
            }
            catch (Exception value)
            {
                ModLog.Warning($"SQLite VACUUM 预检失败，已跳过本次整理：{value}");
                return;
            }
            stopwatch.Stop();
            string value2 = (vacuumPreflightResult.UsedSecondSample ? "，已执行二次抽样" : string.Empty);
            ModLog.Info($"SQLite VACUUM 预检用时 {stopwatch.Elapsed.TotalMilliseconds:F2} 毫秒，预计可回收 {vacuumPreflightResult.EstimatedReclaimableBytes / 1048576.0:F2} MiB，阈值 {vacuumPreflightResult.ThresholdBytes / 1048576.0:F2} MiB{value2}，{(vacuumPreflightResult.ShouldVacuum ? "开始整理" : "跳过")}。");
            if (vacuumPreflightResult.ShouldVacuum)
            {
                long length = new FileInfo(val.DatabasePath).Length;
                Stopwatch stopwatch2 = Stopwatch.StartNew();
                val.Execute("VACUUM", Array.Empty<object>());
                stopwatch2.Stop();
                long length2 = new FileInfo(val.DatabasePath).Length;
                double value3 = (double)Math.Max(0L, length - length2) / 1048576.0;
                ModLog.Info($"存档前 SQLite VACUUM 完成，用时 {stopwatch2.Elapsed.TotalSeconds:F2} 秒，数据库 {(double)length / 1048576.0:F2} MiB -> {(double)length2 / 1048576.0:F2} MiB，回收 {value3:F2} MiB。");
            }
        }
        catch (Exception value4)
        {
            ModLog.Warning($"存档前 SQLite VACUUM 失败，将继续正常存档：{value4}");
        }
    }

    private static Stream? PrepareZstdStream(Stream stream)
    {
        if (!stream.CanSeek)
        {
            return null;
        }
        long num = stream.Length - stream.Position - 4;
        if (num < ZstdFrameMagic.Length)
        {
            return null;
        }
        stream = new LimitedReadStream(stream, num);
        Span<byte> span = stackalloc byte[4];
        int i = 0;
        long position = (stream.CanSeek ? stream.Position : 0);
        int num2;
        for (; i < span.Length; i += num2)
        {
            num2 = stream.Read(span.Slice(i));
            if (num2 == 0)
            {
                if (stream.CanSeek)
                {
                    stream.Position = position;
                }
                return null;
            }
        }
        if (!span.SequenceEqual(ZstdFrameMagic))
        {
            if (stream.CanSeek)
            {
                stream.Position = position;
            }
            return null;
        }
        if (stream.CanSeek)
        {
            stream.Position = position;
            return stream;
        }
        return new PrefixReadStream(span.ToArray(), stream);
    }
}

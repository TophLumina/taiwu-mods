using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Hashing;
using System.Text;
using GameData.ArchiveData;

namespace TaiwuZstdSave;

internal static class CompatibilityBackup
{
    private sealed class LimitedReadStream : Stream
    {
        private readonly Stream _inner;

        private long _remaining;

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

        public LimitedReadStream(Stream inner, long length)
        {
            _inner = inner;
            _remaining = length;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            count = (int)Math.Min(count, _remaining);
            int num = ((count != 0) ? _inner.Read(buffer, offset, count) : 0);
            _remaining -= num;
            return num;
        }

        public override int Read(Span<byte> buffer)
        {
            int num = (int)Math.Min(buffer.Length, _remaining);
            int num2 = ((num != 0) ? _inner.Read(buffer.Slice(0, num)) : 0);
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

    private const string LocalSaveName = "local.sav";

    private static readonly object Sync = new object();

    private static readonly Dictionary<string, (long Length, long LastWriteTicks)> ValidatedBackups = new Dictionary<string, (long, long)>(StringComparer.OrdinalIgnoreCase);

    public static bool IsMainArchivePath(string path)
    {
        return string.Equals(Path.GetFileName(path), "local.sav", StringComparison.OrdinalIgnoreCase);
    }

    public static void EnsureForCurrentArchive()
    {
        if (Common.IsInWorld())
        {
            EnsureFromPath(Common.CurrArchivePath, Common.CurrArchivePath + ".pre-zstd");
        }
    }

    public static bool EnsureBeforeZstdSave(string savePath)
    {
        if (!IsMainArchivePath(savePath))
        {
            return true;
        }
        string text = (File.Exists(savePath) ? savePath : (savePath + ".old"));
        if (!File.Exists(text))
        {
            return false;
        }
        byte b;
        try
        {
            b = ReadCompressionAlgorithm(text);
        }
        catch (Exception value)
        {
            ModLog.Warning($"读取待转换存档头失败：{value}");
            return false;
        }
        switch (b)
        {
            case 254:
                return EnsureFromPath(text, savePath + ".pre-zstd");
            default:
                ModLog.Warning($"拒绝转换未知压缩算法 {b} 的存档：{text}");
                return false;
            case 0:
                return EnsureFromPath(text, savePath + ".pre-zstd");
        }
    }

    private static bool EnsureFromPath(string sourcePath, string backupPath)
    {
        lock (Sync)
        {
            try
            {
                if (!File.Exists(sourcePath))
                {
                    return true;
                }
                string fullPath = Path.GetFullPath(backupPath);
                if (File.Exists(backupPath) && ValidatedBackups.TryGetValue(fullPath, out (long, long) value))
                {
                    (long, long) stamp = GetStamp(backupPath);
                    (long, long) tuple = value;
                    if (stamp.Item1 == tuple.Item1 && stamp.Item2 == tuple.Item2)
                    {
                        return true;
                    }
                }
                if (File.Exists(backupPath) && ValidateDeflateArchive(backupPath, validateContent: false))
                {
                    ValidatedBackups[fullPath] = GetStamp(backupPath);
                    return true;
                }
                if (ReadCompressionAlgorithm(sourcePath) != 0)
                {
                    return false;
                }
                string text = backupPath + ".tmp";
                File.Delete(text);
                try
                {
                    File.Copy(sourcePath, text, overwrite: true);
                    if (!ValidateDeflateArchive(text, validateContent: true))
                    {
                        throw new InvalidDataException("兼容备份 CRC 校验失败。");
                    }
                    File.Move(text, backupPath, overwrite: true);
                    ValidatedBackups[fullPath] = GetStamp(backupPath);
                    ModLog.Info("已创建并验证原版兼容备份：" + backupPath);
                    return true;
                }
                finally
                {
                    File.Delete(text);
                }
            }
            catch (Exception value2)
            {
                ModLog.Warning($"创建兼容备份失败：{value2}");
                return false;
            }
        }
    }

    private static (long Length, long LastWriteTicks) GetStamp(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        return (Length: fileInfo.Length, LastWriteTicks: fileInfo.LastWriteTimeUtc.Ticks);
    }

    private static bool ValidateDeflateArchive(string path, bool validateContent)
    {
        //IL_0152: Unknown result type (might be due to invalid IL or missing references)
        //IL_0159: Expected O, but got Unknown
        try
        {
            using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using BinaryReader binaryReader = new BinaryReader(fileStream, Encoding.UTF8, leaveOpen: true);
            if (Encoding.ASCII.GetString(binaryReader.ReadBytes(3)) != "T1L")
            {
                return false;
            }
            binaryReader.ReadByte();
            int num = binaryReader.ReadInt32();
            long position = fileStream.Position;
            if (num < 3 || position + num > fileStream.Length)
            {
                return false;
            }
            if (binaryReader.ReadUInt16() == 0 || binaryReader.ReadByte() != 0)
            {
                return false;
            }
            fileStream.Position = position + num;
            int num2 = binaryReader.ReadInt32();
            long num3 = fileStream.Position + num2;
            if (num2 < 0 || num2 > 16777216 || num3 + 4 >= fileStream.Length)
            {
                return false;
            }
            fileStream.Position = num3;
            uint num4 = binaryReader.ReadUInt32();
            long position2 = fileStream.Position;
            fileStream.Position = 0L;
            byte[] array = binaryReader.ReadBytes(checked((int)num3));
            if (array.Length != num3 || CalculateCrc32(array) != num4)
            {
                return false;
            }
            if (!validateContent)
            {
                return true;
            }
            long num5 = fileStream.Length - position2 - 4;
            if (num5 <= 0)
            {
                return false;
            }
            fileStream.Position = position2;
            using LimitedReadStream stream = new LimitedReadStream(fileStream, num5);
            using DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress, leaveOpen: true);
            Crc32 val = new Crc32();
            byte[] array2 = new byte[1048576];
            while (true)
            {
                int num6 = deflateStream.Read(array2);
                if (num6 == 0)
                {
                    break;
                }
                ((NonCryptographicHashAlgorithm)val).Append((ReadOnlySpan<byte>)array2.AsSpan(0, num6));
            }
            fileStream.Position = fileStream.Length - 4;
            uint num7 = binaryReader.ReadUInt32();
            return val.GetCurrentHashAsUInt32() == num7;
        }
        catch
        {
            return false;
        }
    }

    private static uint CalculateCrc32(ReadOnlySpan<byte> data)
    {
        //IL_0000: Unknown result type (might be due to invalid IL or missing references)
        //IL_0005: Unknown result type (might be due to invalid IL or missing references)
        Crc32 val = new Crc32();
        ((NonCryptographicHashAlgorithm)val).Append(data);
        return val.GetCurrentHashAsUInt32();
    }

    private static byte ReadCompressionAlgorithm(string path)
    {
        using FileStream input = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        using BinaryReader binaryReader = new BinaryReader(input, Encoding.UTF8, leaveOpen: false);
        if (Encoding.ASCII.GetString(binaryReader.ReadBytes(3)) != "T1L")
        {
            return byte.MaxValue;
        }
        binaryReader.ReadByte();
        if (binaryReader.ReadInt32() < 3)
        {
            return byte.MaxValue;
        }
        return (binaryReader.ReadUInt16() > 0) ? binaryReader.ReadByte() : byte.MaxValue;
    }
}

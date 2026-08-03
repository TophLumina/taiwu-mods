using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using GameData.ArchiveData;

namespace TaiwuOptimization.Runtime;

internal sealed class ParallelDeflateStream : Stream
{
    public const int DefaultBlockSize = 4 * 1024 * 1024;

    private const int DefaultCompressionLevel = 2;

    private readonly Stream _destination;
    private readonly int _blockSize;
    private readonly int _workerCount;
    private readonly int _compressionLevel;
    private readonly Queue<Task<CompressedBlock>> _pending = new();

    private byte[]? _currentBlock;
    private int _currentLength;
    private bool _disposed;
    private bool _metricsPublished;

    private long _inputBytes;
    private long _outputBytes;
    private long _workerCompressionTicks;
    private long _workerWaitTicks;
    private long _destinationWriteTicks;
    private int _blockCount;
    private int _peakPendingBlocks;

    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => !_disposed;

    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    internal int BlockSize => _blockSize;
    internal int WorkerCount => _workerCount;

    public ParallelDeflateStream(Stream destination, int workerCount)
        : this(destination, workerCount, DefaultBlockSize, DefaultCompressionLevel)
    {
    }

    public ParallelDeflateStream(Stream destination, int workerCount, int blockSize)
        : this(destination, workerCount, blockSize, DefaultCompressionLevel)
    {
    }

    private ParallelDeflateStream(Stream destination, int workerCount, int blockSize, int compressionLevel)
    {
        ArgumentNullException.ThrowIfNull(destination);
        if (!destination.CanWrite)
        {
            throw new ArgumentException("The destination stream must be writable.", nameof(destination));
        }

        if (blockSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blockSize));
        }

        _destination = destination;
        _blockSize = blockSize;
        _workerCount = Math.Clamp(workerCount, 1, Math.Max(1, Environment.ProcessorCount));
        _compressionLevel = compressionLevel;
        _currentBlock = ArrayPool<byte>.Shared.Rent(_blockSize);
    }

    public override void Flush()
    {
        ThrowIfDisposed();
        try
        {
            if (_currentLength > 0)
            {
                SubmitCurrentBlock(final: false);
            }

            while (_pending.Count > 0)
            {
                DrainOne(write: true);
            }

            _destination.Flush();
        }
        catch
        {
            AbortPending();
            throw;
        }
    }

    public override void Write(byte[] buffer, int offset, int count) =>
        Write(buffer.AsSpan(offset, count));

    public override void Write(ReadOnlySpan<byte> buffer)
    {
        ThrowIfDisposed();
        try
        {
            while (!buffer.IsEmpty)
            {
                byte[] currentBlock = _currentBlock ??
                    throw new ObjectDisposedException(nameof(ParallelDeflateStream));
                int copyLength = Math.Min(buffer.Length, _blockSize - _currentLength);
                buffer[..copyLength].CopyTo(currentBlock.AsSpan(_currentLength));
                buffer = buffer[copyLength..];
                _currentLength += copyLength;
                _inputBytes += copyLength;

                if (_currentLength == _blockSize)
                {
                    SubmitCurrentBlock(final: false);
                }
            }
        }
        catch
        {
            AbortPending();
            throw;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposing || _disposed)
        {
            base.Dispose(disposing);
            return;
        }

        _disposed = true;
        Exception? firstException = null;
        try
        {
            SubmitCurrentBlock(final: true);
            while (_pending.Count > 0)
            {
                try
                {
                    DrainOne(write: firstException == null);
                }
                catch (Exception exception)
                {
                    firstException ??= exception;
                }
            }
        }
        catch (Exception exception)
        {
            firstException ??= exception;
            while (_pending.Count > 0)
            {
                try
                {
                    DrainOne(write: false);
                }
                catch
                {
                    // Preserve the first failure while still observing and releasing every task result.
                }
            }
        }
        finally
        {
            ReturnCurrentBlock();
            PublishMetrics(firstException == null);
            base.Dispose(disposing);
        }

        if (firstException != null)
        {
            throw new IOException("Parallel DEFLATE compression failed.", firstException);
        }
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();
    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

    internal static void SelfTest()
    {
        VerifySelfTest(Array.Empty<byte>(), flushOffset: -1);
        VerifySelfTest(CreateTestInput(4 * 65536), flushOffset: -1);
        VerifySelfTest(CreateTestInput(4 * 65536 + 17), flushOffset: 100 * 1024);
    }

    private static byte[] CreateTestInput(int length)
    {
        byte[] input = new byte[length];
        new Random(42).NextBytes(input);
        return input;
    }

    private static void VerifySelfTest(byte[] input, int flushOffset)
    {
        using MemoryStream compressed = new();
        using (ParallelDeflateStream stream = new(compressed, 2, 65536, DefaultCompressionLevel))
        {
            if (flushOffset < 0)
            {
                stream.Write(input);
            }
            else
            {
                stream.Write(input.AsSpan(0, flushOffset));
                stream.Flush();
                stream.Write(input.AsSpan(flushOffset));
            }
        }

        compressed.Position = 0;
        Stream decompressor = CompressionStreamFactory.StartDecompression(
            compressed,
            CompressionAlgorithm.Deflate);
        using MemoryStream restored = new();
        try
        {
            decompressor.CopyTo(restored);
        }
        finally
        {
            CompressionStreamFactory.EndDecompression(decompressor, CompressionAlgorithm.Deflate);
        }

        if (!input.AsSpan().SequenceEqual(restored.GetBuffer().AsSpan(0, checked((int)restored.Length))))
        {
            throw new InvalidDataException("zlib-ng parallel DEFLATE self-test failed.");
        }
    }

    private void SubmitCurrentBlock(bool final)
    {
        byte[] input = _currentBlock ??
            throw new ObjectDisposedException(nameof(ParallelDeflateStream));
        int inputLength = _currentLength;

        _currentBlock = final ? null : ArrayPool<byte>.Shared.Rent(_blockSize);
        _currentLength = 0;

        Task<CompressedBlock> task;
        try
        {
            task = Task.Run(() =>
            {
                long startTicks = Stopwatch.GetTimestamp();
                try
                {
                    return NativeZlibNg.Compress(input, inputLength, final, _compressionLevel);
                }
                finally
                {
                    Interlocked.Add(
                        ref _workerCompressionTicks,
                        Stopwatch.GetTimestamp() - startTicks);
                    ArrayPool<byte>.Shared.Return(input);
                }
            });
        }
        catch
        {
            ArrayPool<byte>.Shared.Return(input);
            throw;
        }

        _pending.Enqueue(task);
        _blockCount++;
        _peakPendingBlocks = Math.Max(_peakPendingBlocks, _pending.Count);
        if (!final && _pending.Count >= _workerCount)
        {
            DrainOne(write: true);
        }
    }

    private void DrainOne(bool write)
    {
        Task<CompressedBlock> task = _pending.Dequeue();
        CompressedBlock result;
        long waitStartTicks = Stopwatch.GetTimestamp();
        try
        {
            result = task.GetAwaiter().GetResult();
        }
        finally
        {
            _workerWaitTicks += Stopwatch.GetTimestamp() - waitStartTicks;
        }

        try
        {
            if (write)
            {
                long writeStartTicks = Stopwatch.GetTimestamp();
                _destination.Write(result.Buffer, 0, result.Length);
                _destinationWriteTicks += Stopwatch.GetTimestamp() - writeStartTicks;
                _outputBytes += result.Length;
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(result.Buffer);
        }
    }

    private void AbortPending()
    {
        _disposed = true;
        while (_pending.Count > 0)
        {
            try
            {
                DrainOne(write: false);
            }
            catch
            {
                // The original exception remains the save failure.
            }
        }

        ReturnCurrentBlock();
        PublishMetrics(success: false);
    }

    private void ReturnCurrentBlock()
    {
        if (_currentBlock == null)
        {
            return;
        }

        ArrayPool<byte>.Shared.Return(_currentBlock);
        _currentBlock = null;
    }

    private void PublishMetrics(bool success)
    {
        if (_metricsPublished)
        {
            return;
        }

        _metricsPublished = true;
        SaveWorldDiagnostics.RecordParallelDeflate(
            success,
            _workerCount,
            _blockSize,
            _blockCount,
            _peakPendingBlocks,
            _inputBytes,
            _outputBytes,
            Interlocked.Read(ref _workerCompressionTicks),
            _workerWaitTicks,
            _destinationWriteTicks);
    }

    private void ThrowIfDisposed() =>
        ObjectDisposedException.ThrowIf(_disposed, this);
}

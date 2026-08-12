using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace TaiwuZstdSave;

internal sealed class ParallelDeflateStream : Stream
{
    private const int DefaultBlockSize = 4194304;

    private readonly Stream _destination;

    private readonly int _blockSize;

    private readonly int _workerCount;

    private readonly int _compressionLevel;

    private readonly Queue<Task<CompressedBlock>> _pending = new Queue<Task<CompressedBlock>>();

    private byte[]? _currentBlock;

    private int _currentLength;

    private bool _disposed;

    public override bool CanRead => false;

    public override bool CanSeek => false;

    public override bool CanWrite => !_disposed;

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

    public ParallelDeflateStream(Stream destination, int workerCount)
        : this(destination, workerCount, 4194304, 2)
    {
    }

    private ParallelDeflateStream(Stream destination, int workerCount, int blockSize, int compressionLevel)
    {
        _destination = destination;
        _blockSize = blockSize;
        _workerCount = Math.Clamp(workerCount, 1, Environment.ProcessorCount);
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

    public override void Write(byte[] buffer, int offset, int count)
    {
        Write(buffer.AsSpan(offset, count));
    }

    public override void Write(ReadOnlySpan<byte> buffer)
    {
        ThrowIfDisposed();
        try
        {
            while (!buffer.IsEmpty)
            {
                int num = Math.Min(buffer.Length, _blockSize - _currentLength);
                buffer.Slice(0, num).CopyTo(_currentBlock.AsSpan(_currentLength));
                buffer = buffer.Slice(num);
                _currentLength += num;
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
        Exception ex = null;
        try
        {
            SubmitCurrentBlock(final: true);
            while (_pending.Count > 0)
            {
                try
                {
                    DrainOne(ex == null);
                }
                catch (Exception ex2)
                {
                    if (ex == null)
                    {
                        ex = ex2;
                    }
                }
            }
        }
        catch (Exception ex3)
        {
            ex = ex3;
            while (_pending.Count > 0)
            {
                try
                {
                    DrainOne(write: false);
                }
                catch
                {
                }
            }
        }
        finally
        {
            if (_currentBlock != null)
            {
                ArrayPool<byte>.Shared.Return(_currentBlock);
                _currentBlock = null;
            }
            base.Dispose(disposing);
        }
        if (ex == null)
        {
            return;
        }
        throw new IOException("并行 DEFLATE 压缩失败。", ex);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
        throw new NotSupportedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException();
    }

    internal static void SelfTest()
    {
        VerifySelfTest(Array.Empty<byte>(), -1);
        VerifySelfTest(CreateTestInput(262144), -1);
        VerifySelfTest(CreateTestInput(262161), 102400);
    }

    private static byte[] CreateTestInput(int length)
    {
        byte[] array = new byte[length];
        new Random(42).NextBytes(array);
        return array;
    }

    private static void VerifySelfTest(byte[] input, int flushOffset)
    {
        using MemoryStream memoryStream = new MemoryStream();
        using (ParallelDeflateStream parallelDeflateStream = new ParallelDeflateStream(memoryStream, 2, 65536, 2))
        {
            if (flushOffset < 0)
            {
                parallelDeflateStream.Write(input);
            }
            else
            {
                parallelDeflateStream.Write(input.AsSpan(0, flushOffset));
                parallelDeflateStream.Flush();
                parallelDeflateStream.Write(input.AsSpan(flushOffset));
            }
        }
        memoryStream.Position = 0L;
        using DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
        using MemoryStream memoryStream2 = new MemoryStream();
        deflateStream.CopyTo(memoryStream2);
        if (!input.AsSpan().SequenceEqual(memoryStream2.GetBuffer().AsSpan(0, checked((int)memoryStream2.Length))))
        {
            throw new InvalidDataException("zlib-ng 并行 DEFLATE 自检失败。");
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
            }
        }
        if (_currentBlock != null)
        {
            ArrayPool<byte>.Shared.Return(_currentBlock);
            _currentBlock = null;
        }
    }

    private void SubmitCurrentBlock(bool final)
    {
        byte[] input = _currentBlock;
        int length = _currentLength;
        _currentBlock = (final ? null : ArrayPool<byte>.Shared.Rent(_blockSize));
        _currentLength = 0;
        Task<CompressedBlock> item;
        try
        {
            item = Task.Run(delegate
            {
                try
                {
                    return NativeZlibNg.Compress(input, length, final, _compressionLevel);
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(input);
                }
            });
        }
        catch
        {
            ArrayPool<byte>.Shared.Return(input);
            throw;
        }
        _pending.Enqueue(item);
        if (!final && _pending.Count >= _workerCount)
        {
            DrainOne(write: true);
        }
    }

    private void DrainOne(bool write)
    {
        CompressedBlock result = _pending.Dequeue().GetAwaiter().GetResult();
        try
        {
            if (write)
            {
                _destination.Write(result.Buffer, 0, result.Length);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(result.Buffer);
        }
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
}

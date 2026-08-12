using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace TaiwuOptimization.Runtime;

/// <summary>
/// Estimates the space that a full SQLite VACUUM can reclaim without issuing
/// SQL against the live connection. Ported from ref_parallel_save.
/// </summary>
internal static class SqliteVacuumPreflight
{
    private const int SampleBlockCount = 32;
    private const int PagesPerSampleBlock = 32;
    private const long AbsoluteThresholdBytes = 32L * 1024L * 1024L;
    private const long BoundaryMarginBytes = 8L * 1024L * 1024L;
    private const double RelativeThreshold = 0.1;
    private const long LockByteOffset = 1_073_741_824L;

    private static readonly byte[] SqliteHeader = "SQLite format 3\0"u8.ToArray();

    public static VacuumPreflightResult Evaluate(string databasePath)
    {
        checked
        {
            using FileStream stream = new(
                databasePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite | FileShare.Delete,
                bufferSize: 4096,
                FileOptions.RandomAccess);
            if (stream.Length < 512)
            {
                throw new InvalidDataException("SQLite database file is too small.");
            }

            byte[] initialHeader = new byte[100];
            ReadExactly(stream.SafeFileHandle, initialHeader, 0L);
            int pageSize = ValidateHeader(initialHeader, stream.Length);
            int pageCount = (int)(stream.Length / pageSize);
            int reservedBytes = initialHeader[20];
            HashSet<int> freelistPages = ReadFreelist(
                stream.SafeFileHandle,
                initialHeader,
                pageSize,
                pageCount);

            double thresholdBytes = Math.Max(
                AbsoluteThresholdBytes,
                stream.Length * RelativeThreshold);
            double firstEstimate = EstimateReclaimableBytes(
                stream.SafeFileHandle,
                pageSize,
                reservedBytes,
                pageCount,
                freelistPages);
            bool useSecondSample =
                Math.Abs(firstEstimate - thresholdBytes) <= BoundaryMarginBytes;
            double estimatedReclaimableBytes = firstEstimate;
            if (useSecondSample)
            {
                double secondEstimate = EstimateReclaimableBytes(
                    stream.SafeFileHandle,
                    pageSize,
                    reservedBytes,
                    pageCount,
                    freelistPages);
                estimatedReclaimableBytes = (firstEstimate + secondEstimate) / 2.0;
            }

            byte[] finalHeader = new byte[initialHeader.Length];
            ReadExactly(stream.SafeFileHandle, finalHeader, 0L);
            if (!initialHeader.AsSpan().SequenceEqual(finalHeader))
            {
                throw new InvalidDataException(
                    "SQLite database changed while the VACUUM preflight was running.");
            }

            estimatedReclaimableBytes = Math.Clamp(
                estimatedReclaimableBytes,
                (double)freelistPages.Count * pageSize,
                stream.Length);
            return new VacuumPreflightResult(
                estimatedReclaimableBytes >= thresholdBytes,
                estimatedReclaimableBytes,
                thresholdBytes,
                useSecondSample);
        }
    }

    private static int ValidateHeader(byte[] header, long fileLength)
    {
        if (!header.AsSpan(0, SqliteHeader.Length).SequenceEqual(SqliteHeader))
        {
            throw new InvalidDataException("Invalid SQLite database header.");
        }

        if (header[18] != 1 || header[19] != 1)
        {
            throw new InvalidDataException(
                "VACUUM preflight only supports rollback-journal SQLite databases.");
        }

        int pageSize = ReadUInt16(header, 16);
        if (pageSize == 1)
        {
            pageSize = 65536;
        }

        if (pageSize < 512 ||
            pageSize > 65536 ||
            (pageSize & (pageSize - 1)) != 0)
        {
            throw new InvalidDataException($"Invalid SQLite page size: {pageSize}.");
        }

        if (header[20] >= pageSize || fileLength % pageSize != 0L)
        {
            throw new InvalidDataException("Invalid SQLite page layout.");
        }

        long pageCount = fileLength / pageSize;
        uint headerPageCount = ReadUInt32(header, 28);
        if (pageCount <= 0 || pageCount > int.MaxValue || headerPageCount != pageCount)
        {
            throw new InvalidDataException(
                "SQLite header page count does not match the database length.");
        }

        if (ReadUInt32(header, 24) != ReadUInt32(header, 92))
        {
            throw new InvalidDataException("SQLite database header state is invalid.");
        }

        if (ReadUInt32(header, 52) != 0)
        {
            throw new InvalidDataException(
                "VACUUM preflight does not support auto_vacuum databases.");
        }

        return pageSize;
    }

    private static double EstimateReclaimableBytes(
        SafeFileHandle handle,
        int pageSize,
        int reservedBytes,
        int pageCount,
        HashSet<int> freelistPages)
    {
        int availableBlockCount =
            (pageCount + PagesPerSampleBlock - 1) / PagesPerSampleBlock;
        int blocksToSample = Math.Min(SampleBlockCount, availableBlockCount);
        HashSet<int> sampledBlocks = new(blocksToSample);
        byte[] blockBuffer = new byte[PagesPerSampleBlock * pageSize];
        long sampledBtreeFreeBytes = 0L;
        int sampledPageCount = 0;
        int lockBytePageNumber = checked((int)(LockByteOffset / pageSize) + 1);

        while (sampledBlocks.Count < blocksToSample)
        {
            int blockIndex = Random.Shared.Next(availableBlockCount);
            if (!sampledBlocks.Add(blockIndex))
            {
                continue;
            }

            int firstPageNumber = blockIndex * PagesPerSampleBlock + 1;
            int pagesInBlock = Math.Min(
                PagesPerSampleBlock,
                pageCount - firstPageNumber + 1);
            int bytesInBlock = pagesInBlock * pageSize;
            ReadExactly(
                handle,
                blockBuffer.AsSpan(0, bytesInBlock),
                (long)(firstPageNumber - 1) * pageSize);
            sampledPageCount += pagesInBlock;

            for (int index = 0; index < pagesInBlock; index++)
            {
                int pageNumber = firstPageNumber + index;
                if (pageNumber == lockBytePageNumber ||
                    freelistPages.Contains(pageNumber))
                {
                    continue;
                }

                ReadOnlySpan<byte> page = blockBuffer.AsSpan(index * pageSize, pageSize);
                if (TryGetBtreeFreeBytes(
                        page,
                        pageNumber,
                        pageSize,
                        reservedBytes,
                        out byte pageType,
                        out int freeBytes) &&
                    pageType == 13)
                {
                    sampledBtreeFreeBytes += freeBytes;
                }
            }
        }

        return (double)sampledBtreeFreeBytes * pageCount / sampledPageCount +
            (double)freelistPages.Count * pageSize;
    }

    private static bool TryGetBtreeFreeBytes(
        ReadOnlySpan<byte> page,
        int pageNumber,
        int pageSize,
        int reservedBytes,
        out byte pageType,
        out int freeBytes)
    {
        int headerOffset = pageNumber == 1 ? 100 : 0;
        pageType = page[headerOffset];
        bool isLeafPage = pageType is 10 or 13;
        if (!isLeafPage && pageType is not 2 and not 5)
        {
            freeBytes = 0;
            return false;
        }

        int usableSize = pageSize - reservedBytes;
        int btreeHeaderSize = isLeafPage ? 8 : 12;
        int firstFreeblockOffset = ReadUInt16(page, headerOffset + 1);
        int cellCount = ReadUInt16(page, headerOffset + 3);
        int cellContentOffset = ReadUInt16(page, headerOffset + 5);
        if (cellContentOffset == 0 && pageSize == 65536)
        {
            cellContentOffset = 65536;
        }

        int cellPointerArrayEnd =
            headerOffset + btreeHeaderSize + cellCount * 2;
        if (cellContentOffset < cellPointerArrayEnd || cellContentOffset > usableSize)
        {
            freeBytes = 0;
            return false;
        }

        int freeblockBytes = 0;
        int freeblockOffset = firstFreeblockOffset;
        int visitedFreeblocks = 0;
        while (freeblockOffset != 0)
        {
            if (freeblockOffset < cellContentOffset ||
                freeblockOffset + 4 > usableSize ||
                ++visitedFreeblocks > pageSize / 4)
            {
                freeBytes = 0;
                return false;
            }

            int nextFreeblockOffset = ReadUInt16(page, freeblockOffset);
            int freeblockSize = ReadUInt16(page, freeblockOffset + 2);
            if (freeblockSize < 4 ||
                freeblockOffset + freeblockSize > usableSize ||
                (nextFreeblockOffset != 0 && nextFreeblockOffset <= freeblockOffset))
            {
                freeBytes = 0;
                return false;
            }

            freeblockBytes += freeblockSize;
            freeblockOffset = nextFreeblockOffset;
        }

        freeBytes =
            cellContentOffset - cellPointerArrayEnd +
            freeblockBytes +
            page[headerOffset + 7];
        return freeBytes is >= 0 and <= 65536;
    }

    private static HashSet<int> ReadFreelist(
        SafeFileHandle handle,
        byte[] header,
        int pageSize,
        int pageCount)
    {
        uint expectedFreelistPageCount = ReadUInt32(header, 36);
        if (expectedFreelistPageCount > pageCount)
        {
            throw new InvalidDataException("Invalid SQLite freelist page count.");
        }

        HashSet<int> freelistPages = new(checked((int)expectedFreelistPageCount));
        uint trunkPageNumber = ReadUInt32(header, 32);
        byte[] pageBuffer = new byte[pageSize];
        while (trunkPageNumber != 0)
        {
            if (trunkPageNumber > pageCount || !freelistPages.Add((int)trunkPageNumber))
            {
                throw new InvalidDataException("Invalid SQLite freelist trunk chain.");
            }

            ReadExactly(
                handle,
                pageBuffer,
                ((long)trunkPageNumber - 1L) * pageSize);
            uint nextTrunkPageNumber = ReadUInt32(pageBuffer, 0);
            uint leafPageCount = ReadUInt32(pageBuffer, 4);
            if (leafPageCount > (pageSize - 8) / 4)
            {
                throw new InvalidDataException("Invalid SQLite freelist leaf count.");
            }

            for (int index = 0; index < leafPageCount; index++)
            {
                uint leafPageNumber = ReadUInt32(pageBuffer, 8 + index * 4);
                if (leafPageNumber == 0 ||
                    leafPageNumber > pageCount ||
                    !freelistPages.Add((int)leafPageNumber))
                {
                    throw new InvalidDataException("Invalid SQLite freelist leaf page.");
                }
            }

            trunkPageNumber = nextTrunkPageNumber;
        }

        if (freelistPages.Count != expectedFreelistPageCount)
        {
            throw new InvalidDataException(
                $"SQLite freelist page count mismatch: header={expectedFreelistPageCount}, parsed={freelistPages.Count}.");
        }

        return freelistPages;
    }

    private static void ReadExactly(
        SafeFileHandle handle,
        byte[] buffer,
        long offset) =>
        ReadExactly(handle, buffer.AsSpan(), offset);

    private static void ReadExactly(
        SafeFileHandle handle,
        Span<byte> buffer,
        long offset)
    {
        int bytesRead;
        for (int consumed = 0; consumed < buffer.Length; consumed += bytesRead)
        {
            bytesRead = RandomAccess.Read(handle, buffer.Slice(consumed), offset + consumed);
            if (bytesRead == 0)
            {
                throw new EndOfStreamException();
            }
        }
    }

    private static int ReadUInt16(ReadOnlySpan<byte> bytes, int offset) =>
        bytes[offset] * 256 + bytes[offset + 1];

    private static uint ReadUInt32(ReadOnlySpan<byte> bytes, int offset) =>
        (uint)(
            (bytes[offset] << 24) |
            (bytes[offset + 1] << 16) |
            (bytes[offset + 2] << 8) |
            bytes[offset + 3]);
}

internal readonly record struct VacuumPreflightResult(
    bool ShouldVacuum,
    double EstimatedReclaimableBytes,
    double ThresholdBytes,
    bool UsedSecondSample);

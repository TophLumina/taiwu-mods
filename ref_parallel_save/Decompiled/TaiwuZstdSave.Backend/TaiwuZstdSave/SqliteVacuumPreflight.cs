using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace TaiwuZstdSave;

internal static class SqliteVacuumPreflight
{
    private const int SampleBlockCount = 32;

    private const int PagesPerSampleBlock = 32;

    private const long AbsoluteThresholdBytes = 33554432L;

    private const long BoundaryMarginBytes = 8388608L;

    private const double RelativeThreshold = 0.1;

    private const long LockByteOffset = 1073741824L;

    private static readonly byte[] SqliteHeader = "SQLite format 3\0"u8.ToArray();

    public static VacuumPreflightResult Evaluate(string databasePath)
    {
        checked
        {
            using FileStream fileStream = new FileStream(databasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete, 4096, FileOptions.RandomAccess);
            if (fileStream.Length < 512)
            {
                throw new InvalidDataException("SQLite 数据库文件过小。");
            }
            byte[] array = new byte[100];
            ReadExactly(fileStream.SafeFileHandle, array, 0L);
            int num = ValidateHeader(array, fileStream.Length);
            int pageCount = (int)unchecked(fileStream.Length / num);
            int reservedBytes = array[20];
            HashSet<int> hashSet = ReadFreelist(fileStream.SafeFileHandle, array, num, pageCount);
            double num2 = Math.Max(33554432.0, (double)fileStream.Length * 0.1);
            double num3 = EstimateReclaimableBytes(fileStream.SafeFileHandle, num, reservedBytes, pageCount, hashSet);
            bool flag = Math.Abs(num3 - num2) <= 8388608.0;
            double value = num3;
            if (flag)
            {
                double num4 = EstimateReclaimableBytes(fileStream.SafeFileHandle, num, reservedBytes, pageCount, hashSet);
                value = (num3 + num4) / 2.0;
            }
            byte[] array2 = new byte[array.Length];
            ReadExactly(fileStream.SafeFileHandle, array2, 0L);
            if (!array.AsSpan().SequenceEqual(array2))
            {
                throw new InvalidDataException("SQLite 数据库在预检期间发生了变化。");
            }
            value = Math.Clamp(value, (double)hashSet.Count * (double)num, fileStream.Length);
            return new VacuumPreflightResult(value >= num2, value, num2, flag);
        }
    }

    private static int ValidateHeader(byte[] header, long fileLength)
    {
        if (!header.AsSpan(0, SqliteHeader.Length).SequenceEqual(SqliteHeader))
        {
            throw new InvalidDataException("无效的 SQLite 数据库文件头。");
        }
        if (header[18] != 1 || header[19] != 1)
        {
            throw new InvalidDataException("预检仅支持 rollback-journal SQLite 数据库。");
        }
        int num = ReadUInt16(header, 16);
        if (num == 1)
        {
            num = 65536;
        }
        bool flag = ((num < 512 || num > 65536) ? true : false);
        if (flag || (num & (num - 1)) != 0)
        {
            throw new InvalidDataException($"无效的 SQLite 页大小：{num}。");
        }
        if (header[20] >= num || fileLength % num != 0L)
        {
            throw new InvalidDataException("SQLite 数据库页布局无效。");
        }
        long num2 = fileLength / num;
        uint num3 = ReadUInt32(header, 28);
        if (num2 <= 0 || num2 > int.MaxValue || num3 != num2)
        {
            throw new InvalidDataException("SQLite 数据库页数与文件长度不一致。");
        }
        if (ReadUInt32(header, 24) != ReadUInt32(header, 92))
        {
            throw new InvalidDataException("SQLite 数据库文件头状态无效。");
        }
        if (ReadUInt32(header, 52) != 0)
        {
            throw new InvalidDataException("预检暂不支持 auto_vacuum 数据库。");
        }
        return num;
    }

    private static double EstimateReclaimableBytes(SafeFileHandle handle, int pageSize, int reservedBytes, int pageCount, HashSet<int> freelistPages)
    {
        int num = (pageCount + 32 - 1) / 32;
        int num2 = Math.Min(32, num);
        HashSet<int> hashSet = new HashSet<int>(num2);
        byte[] array = new byte[32 * pageSize];
        long num3 = 0L;
        int num4 = 0;
        int num5;
        checked
        {
            num5 = (int)(unchecked(1073741824L / (long)pageSize) + 1);
        }
        while (hashSet.Count < num2)
        {
            int num6 = Random.Shared.Next(num);
            if (!hashSet.Add(num6))
            {
                continue;
            }
            int num7 = num6 * 32 + 1;
            int num8 = Math.Min(32, pageCount - num7 + 1);
            int length = num8 * pageSize;
            ReadExactly(handle, array.AsSpan(0, length), (long)(num7 - 1) * (long)pageSize);
            num4 += num8;
            for (int i = 0; i < num8; i++)
            {
                int num9 = num7 + i;
                if (num9 != num5 && !freelistPages.Contains(num9) && TryGetBtreeFreeBytes(array.AsSpan(i * pageSize, pageSize), num9, pageSize, reservedBytes, out var pageType, out var freeBytes) && pageType == 13)
                {
                    num3 += freeBytes;
                }
            }
        }
        return (double)num3 * (double)pageCount / (double)num4 + (double)freelistPages.Count * (double)pageSize;
    }

    private static bool TryGetBtreeFreeBytes(ReadOnlySpan<byte> page, int pageNumber, int pageSize, int reservedBytes, out byte pageType, out int freeBytes)
    {
        int num = ((pageNumber == 1) ? 100 : 0);
        pageType = page[num];
        byte b = pageType;
        bool flag = ((b == 10 || b == 13) ? true : false);
        bool flag2 = flag;
        if (!flag2)
        {
            b = pageType;
            if (b != 2 && b != 5)
            {
                freeBytes = 0;
                return false;
            }
        }
        int num2 = pageSize - reservedBytes;
        int num3 = (flag2 ? 8 : 12);
        int num4 = ReadUInt16(page, num + 1);
        int num5 = ReadUInt16(page, num + 3);
        int num6 = ReadUInt16(page, num + 5);
        if (num6 == 0 && pageSize == 65536)
        {
            num6 = 65536;
        }
        int num7 = num + num3 + num5 * 2;
        if (num6 < num7 || num6 > num2)
        {
            freeBytes = 0;
            return false;
        }
        int num8 = 0;
        int num9 = num4;
        int num10 = 0;
        while (num9 != 0)
        {
            if (num9 < num6 || num9 + 4 > num2 || ++num10 > pageSize / 4)
            {
                freeBytes = 0;
                return false;
            }
            int num11 = ReadUInt16(page, num9);
            int num12 = ReadUInt16(page, num9 + 2);
            if (num12 < 4 || num9 + num12 > num2 || (num11 != 0 && num11 <= num9))
            {
                freeBytes = 0;
                return false;
            }
            num8 += num12;
            num9 = num11;
        }
        freeBytes = num6 - num7 + num8 + page[num + 7];
        int num13 = freeBytes;
        if (num13 >= 0)
        {
            return num13 <= 65536;
        }
        return false;
    }

    private static HashSet<int> ReadFreelist(SafeFileHandle handle, byte[] header, int pageSize, int pageCount)
    {
        uint num = ReadUInt32(header, 36);
        if (num > pageCount)
        {
            throw new InvalidDataException("SQLite freelist 页数无效。");
        }
        HashSet<int> hashSet = new HashSet<int>(checked((int)num));
        uint num2 = ReadUInt32(header, 32);
        byte[] array = new byte[pageSize];
        while (num2 != 0)
        {
            if (num2 > pageCount || !hashSet.Add((int)num2))
            {
                throw new InvalidDataException("SQLite freelist trunk 链无效。");
            }
            ReadExactly(handle, array, (num2 - 1) * pageSize);
            uint num3 = ReadUInt32(array, 0);
            uint num4 = ReadUInt32(array, 4);
            if (num4 > (pageSize - 8) / 4)
            {
                throw new InvalidDataException("SQLite freelist leaf 页数无效。");
            }
            for (int i = 0; i < num4; i++)
            {
                uint num5 = ReadUInt32(array, 8 + i * 4);
                if (num5 == 0 || num5 > pageCount || !hashSet.Add((int)num5))
                {
                    throw new InvalidDataException("SQLite freelist leaf 页无效。");
                }
            }
            num2 = num3;
        }
        if (hashSet.Count != num)
        {
            throw new InvalidDataException($"SQLite freelist 页数不一致：header={num}，parsed={hashSet.Count}。");
        }
        return hashSet;
    }

    private static void ReadExactly(SafeFileHandle handle, byte[] buffer, long offset)
    {
        ReadExactly(handle, buffer.AsSpan(), offset);
    }

    private static void ReadExactly(SafeFileHandle handle, Span<byte> buffer, long offset)
    {
        int num;
        for (int i = 0; i < buffer.Length; i += num)
        {
            num = RandomAccess.Read(handle, buffer.Slice(i), offset + i);
            if (num == 0)
            {
                throw new EndOfStreamException();
            }
        }
    }

    private static int ReadUInt16(ReadOnlySpan<byte> bytes, int offset)
    {
        return bytes[offset] * 256 + bytes[offset + 1];
    }

    private static uint ReadUInt32(ReadOnlySpan<byte> bytes, int offset)
    {
        return (uint)((bytes[offset] << 24) | (bytes[offset + 1] << 16) | (bytes[offset + 2] << 8) | bytes[offset + 3]);
    }
}

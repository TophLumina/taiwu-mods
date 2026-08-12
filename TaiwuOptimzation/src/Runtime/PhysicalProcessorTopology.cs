using System;
using System.Runtime.InteropServices;

namespace TaiwuOptimization.Runtime;

internal static class PhysicalProcessorTopology
{
    private const int RelationProcessorCore = 0;
    private const int ErrorInsufficientBuffer = 122;

    public static readonly int PhysicalCoreCount = DetectPhysicalCoreCount();

    private static int DetectPhysicalCoreCount()
    {
        int availableLogicalProcessors = Math.Max(1, Environment.ProcessorCount);
        if (!OperatingSystem.IsWindows())
        {
            return availableLogicalProcessors;
        }

        uint bufferLength = 0;
        _ = GetLogicalProcessorInformationEx(RelationProcessorCore, IntPtr.Zero, ref bufferLength);
        if (Marshal.GetLastWin32Error() != ErrorInsufficientBuffer || bufferLength < 8)
        {
            return availableLogicalProcessors;
        }

        IntPtr buffer = Marshal.AllocHGlobal(checked((int)bufferLength));
        try
        {
            if (!GetLogicalProcessorInformationEx(RelationProcessorCore, buffer, ref bufferLength))
            {
                return availableLogicalProcessors;
            }

            int physicalCoreCount = 0;
            int offset = 0;
            int totalLength = checked((int)bufferLength);
            while (offset + 8 <= totalLength)
            {
                IntPtr entry = IntPtr.Add(buffer, offset);
                int relationship = Marshal.ReadInt32(entry, 0);
                int entrySize = Marshal.ReadInt32(entry, 4);
                if (entrySize < 8 || offset > totalLength - entrySize)
                {
                    return availableLogicalProcessors;
                }

                if (relationship == RelationProcessorCore)
                {
                    physicalCoreCount++;
                }

                offset += entrySize;
            }

            if (offset != totalLength || physicalCoreCount <= 0)
            {
                return availableLogicalProcessors;
            }

            // Respect process affinity / container CPU limits reported by .NET.
            return Math.Max(1, Math.Min(physicalCoreCount, availableLogicalProcessors));
        }
        finally
        {
            Marshal.FreeHGlobal(buffer);
        }
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetLogicalProcessorInformationEx(
        int relationshipType,
        IntPtr buffer,
        ref uint returnedLength);
}

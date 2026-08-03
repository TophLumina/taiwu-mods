using System;
using System.Collections.Generic;
using System.Threading;
using GameData.Domains;
using ZstdNet;

namespace TaiwuZstdSave;

internal static class ModSettings
{
    private const int DefaultWorkerCount = 8;

    private static int _mode = 1;

    private static int _workerCount = 8;

    private static bool _vacuumBeforeSave = true;

    public static SaveCompressionMode Mode => (SaveCompressionMode)Volatile.Read(in _mode);

    public static int WorkerCount => Volatile.Read(in _workerCount);

    public static bool VacuumBeforeSave => Volatile.Read(in _vacuumBeforeSave);

    public static bool UseZstd => Mode == SaveCompressionMode.ZstdOptimal;

    public static bool UseParallelDeflate => Mode == SaveCompressionMode.ParallelDeflate;

    public static void Update(string modId)
    {
        int num = 1;
        int value = 8;
        bool flag = true;
        DomainManager.Mod.GetSetting(modId, "CompressionMode", ref num);
        DomainManager.Mod.GetSetting(modId, "WorkerCount", ref value);
        DomainManager.Mod.GetSetting(modId, "VacuumBeforeSave", ref flag);
        if ((num < 0 || num > 2) ? true : false)
        {
            ModLog.Warning($"未知压缩模式 {num}，已回退到兼容模式。");
            num = 0;
        }
        value = Math.Clamp(value, 1, 32);
        Volatile.Write(ref _workerCount, value);
        Volatile.Write(ref _mode, num);
        Volatile.Write(ref _vacuumBeforeSave, flag);
        ModLog.Info($"压缩模式：{(SaveCompressionMode)num}，工作线程：{value}，主存档数据库按需整理：{(flag ? "启用" : "关闭")}。");
    }

    public static CompressionOptions CreateCompressionOptions()
    {
        Dictionary<ZSTD_cParameter, int> advancedParams = new Dictionary<ZSTD_cParameter, int>
        {
            [ZSTD_cParameter.ZSTD_c_nbWorkers] = WorkerCount,
            [ZSTD_cParameter.ZSTD_c_jobSize] = 8388608,
            [ZSTD_cParameter.ZSTD_c_checksumFlag] = 1
        };
        return new CompressionOptions(null, advancedParams, 10);
    }
}

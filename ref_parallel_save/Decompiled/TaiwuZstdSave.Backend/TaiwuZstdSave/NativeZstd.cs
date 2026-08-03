using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using GameData.Domains;
using ZstdNet;

namespace TaiwuZstdSave;

internal static class NativeZstd
{
    private static readonly object Sync = new object();

    private static nint _libraryHandle;

    private static bool _initialized;

    public static void Initialize(string modId)
    {
        lock (Sync)
        {
            if (!_initialized)
            {
                string modDirectory = DomainManager.Mod.GetModDirectory(modId);
                if (string.IsNullOrEmpty(modDirectory))
                {
                    throw new DirectoryNotFoundException("无法获取 Mod 目录。");
                }
                string text = Path.Combine(modDirectory, "Plugins", "libzstd.dll");
                if (!File.Exists(text))
                {
                    throw new FileNotFoundException("找不到 Zstd 原生库。", text);
                }
                _libraryHandle = NativeLibrary.Load(text);
                Assembly assembly = typeof(CompressionStream).Assembly;
                try
                {
                    NativeLibrary.SetDllImportResolver(assembly, ResolveLibrary);
                }
                catch (InvalidOperationException)
                {
                    ModLog.Warning("ZstdNet 已注册原生库解析器，将验证现有解析器是否可用。");
                }
                _ = CompressionOptions.MinCompressionLevel;
                _initialized = true;
                ModLog.Info($"已加载 ZstdNet {assembly.GetName().Version} 和 {Path.GetFileName(text)}。");
            }
        }
    }

    public static void EnsureInitialized()
    {
        if (!_initialized)
        {
            throw new InvalidOperationException("Zstd 原生库尚未初始化。");
        }
    }

    private static nint ResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (!string.Equals(libraryName, "libzstd", StringComparison.OrdinalIgnoreCase))
        {
            return IntPtr.Zero;
        }
        return _libraryHandle;
    }
}

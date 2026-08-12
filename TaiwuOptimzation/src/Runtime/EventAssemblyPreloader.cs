using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GameData.Domains.TaiwuEvent;
using NLog;

namespace TaiwuOptimization.Runtime;

/// <summary>
/// Reads the built-in event assemblies in parallel and then loads those buffers
/// in parallel. The game's original event-package loop still consumes the
/// resulting Assembly objects in its original order.
/// </summary>
internal static class EventAssemblyPreloader
{
    private const int ReadWorkerCount = 4;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly object SyncRoot = new();

    private static PreloadState? _state;
    private static bool _initialLoadFinished;

    public static void Initialize()
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (_state != null || _initialLoadFinished)
            {
                return;
            }

            try
            {
                string backendDirectory = Path.GetDirectoryName(typeof(TaiwuEventDomain).Assembly.Location)
                    ?? AppContext.BaseDirectory;
                string gameDirectory = Path.GetFullPath(Path.Combine(backendDirectory, ".."));

                // These marker files explicitly ask the game not to use LoadBuffer.
                // Loading byte arrays here would change the requested load context.
                if (File.Exists(Path.Combine(gameDirectory, "use_load_from.txt")) ||
                    File.Exists(Path.Combine(gameDirectory, "use_load_file.txt")))
                {
                    _initialLoadFinished = true;
                    Logger.Info("TaiwuOptimization: event assembly preload skipped because the game is not using LoadBuffer mode.");
                    return;
                }

                string eventLibraryDirectory = Path.Combine(gameDirectory, "Event", "EventLib");
                if (!Directory.Exists(eventLibraryDirectory))
                {
                    _initialLoadFinished = true;
                    Logger.Warn($"TaiwuOptimization: event assembly directory was not found; using the original loader: {eventLibraryDirectory}");
                    return;
                }

                string[] assemblyPaths = Directory.GetFiles(
                    eventLibraryDirectory,
                    "*.dll",
                    SearchOption.AllDirectories);
                if (assemblyPaths.Length == 0)
                {
                    _initialLoadFinished = true;
                    return;
                }

                int physicalCoreCount = PhysicalProcessorTopology.PhysicalCoreCount;
                int loadWorkerCount = physicalCoreCount;
                PreloadState state = new(assemblyPaths, ReadWorkerCount, loadWorkerCount);
                _state = state;
                state.Start();
            }
            catch (Exception exception)
            {
                PreloadState? failedState = _state;
                _state = null;
                _initialLoadFinished = true;
                failedState?.Cancel();
                Logger.Warn(exception, "TaiwuOptimization: event assembly preload initialization failed; using the original loader.");
            }
        }
    }

    public static void UpdateEnabledState()
    {
        if (TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            Initialize();
            return;
        }

        CancelCurrentState(resetInitialLoadState: false);
    }

    public static bool TryTake(string path, out Assembly assembly)
    {
        assembly = null!;
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled)
        {
            return false;
        }

        PreloadState? state = Volatile.Read(ref _state);
        if (state == null || !state.TryTake(path, out Task<PreloadResult> preloadTask))
        {
            return false;
        }

        long waitStartedAt = preloadTask.IsCompleted ? 0 : Stopwatch.GetTimestamp();
        PreloadResult result;
        try
        {
            result = preloadTask.GetAwaiter().GetResult();
        }
        catch (Exception exception)
        {
            state.RecordFallback();
            Logger.Warn(exception, $"TaiwuOptimization: event assembly preload task failed for {Path.GetFileName(path)}; using the original loader.");
            return false;
        }
        finally
        {
            if (waitStartedAt != 0)
            {
                state.AddConsumerWaitTicks(Stopwatch.GetTimestamp() - waitStartedAt);
            }
        }

        if (result.Assembly is Assembly preloadedAssembly)
        {
            state.RecordSuppliedAssembly();
            assembly = preloadedAssembly;
            return true;
        }

        state.RecordFallback();
        if (result.Exception != null)
        {
            Logger.Warn(
                result.Exception,
                $"TaiwuOptimization: event assembly preload failed during {result.Stage} for {Path.GetFileName(path)}; using the original loader.");
        }

        return false;
    }

    public static void CompleteInitialLoad()
    {
        PreloadState? state;
        lock (SyncRoot)
        {
            state = _state;
            _state = null;
            _initialLoadFinished = true;
        }

        if (state == null)
        {
            return;
        }

        try
        {
            state.LogSummary();
        }
        catch (Exception)
        {
            // Diagnostics must never affect event initialization.
        }
        finally
        {
            state.Cancel();
        }
    }

    public static void Dispose() =>
        CancelCurrentState(resetInitialLoadState: true);

    private static void CancelCurrentState(bool resetInitialLoadState)
    {
        PreloadState? state;
        lock (SyncRoot)
        {
            state = _state;
            _state = null;
            if (resetInitialLoadState)
            {
                _initialLoadFinished = false;
            }
        }

        state?.Cancel();
    }

    private sealed class PreloadState
    {
        private readonly Entry[] _entries;
        private readonly ConcurrentDictionary<string, Task<PreloadResult>> _preloads;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly int _readWorkerCount;
        private readonly int _loadWorkerCount;
        private readonly long _startedAt = Stopwatch.GetTimestamp();

        private long _finishedAt;
        private long _readBytes;
        private long _consumerWaitTicks;
        private int _preloadedCount;
        private int _suppliedCount;
        private int _fallbackCount;

        public PreloadState(string[] assemblyPaths, int readWorkerCount, int loadWorkerCount)
        {
            _readWorkerCount = Math.Max(1, readWorkerCount);
            _loadWorkerCount = Math.Max(1, loadWorkerCount);
            _entries = new Entry[assemblyPaths.Length];
            _preloads = new ConcurrentDictionary<string, Task<PreloadResult>>(
                StringComparer.OrdinalIgnoreCase);

            for (int index = 0; index < assemblyPaths.Length; index++)
            {
                Entry entry = new(NormalizePath(assemblyPaths[index]));
                _entries[index] = entry;
                _preloads[entry.Path] = entry.Completion.Task;
            }
        }

        public void Start() =>
            _ = Task.Run(Run);

        public bool TryTake(string path, out Task<PreloadResult> preloadTask)
        {
            try
            {
                if (_preloads.TryRemove(NormalizePath(path), out Task<PreloadResult>? task) &&
                    task != null)
                {
                    preloadTask = task;
                    return true;
                }
            }
            catch (Exception)
            {
                // Invalid or inaccessible paths simply keep the original loader.
            }

            preloadTask = null!;
            return false;
        }

        public void AddConsumerWaitTicks(long ticks) =>
            Interlocked.Add(ref _consumerWaitTicks, ticks);

        public void RecordSuppliedAssembly() =>
            Interlocked.Increment(ref _suppliedCount);

        public void RecordFallback() =>
            Interlocked.Increment(ref _fallbackCount);

        public void Cancel()
        {
            _preloads.Clear();
            try
            {
                _cancellation.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // A concurrently completed coordinator already released it.
            }
        }

        public void LogSummary()
        {
            long finishedAt = Volatile.Read(ref _finishedAt);
            long elapsedTicks = (finishedAt != 0 ? finishedAt : Stopwatch.GetTimestamp()) - _startedAt;
            Logger.Info(
                "TaiwuOptimization: event assembly preload complete: files={0}, readWorkers={1}, loadWorkers={2}, " +
                "readMiB={3:F2}, preloaded={4}, supplied={5}, fallbacks={6}, preloadMs={7:F2}, consumerWaitMs={8:F2}.",
                _entries.Length,
                _readWorkerCount,
                _loadWorkerCount,
                Interlocked.Read(ref _readBytes) / (1024d * 1024d),
                Volatile.Read(ref _preloadedCount),
                Volatile.Read(ref _suppliedCount),
                Volatile.Read(ref _fallbackCount),
                StopwatchTicksToMilliseconds(elapsedTicks),
                StopwatchTicksToMilliseconds(Interlocked.Read(ref _consumerWaitTicks)));
        }

        private void Run()
        {
            try
            {
                ParallelOptions readOptions = new()
                {
                    CancellationToken = _cancellation.Token,
                    MaxDegreeOfParallelism = _readWorkerCount,
                };
                Parallel.ForEach(_entries, readOptions, ReadEntry);

                ParallelOptions loadOptions = new()
                {
                    CancellationToken = _cancellation.Token,
                    MaxDegreeOfParallelism = _loadWorkerCount,
                };
                Parallel.ForEach(_entries, loadOptions, LoadEntry);
            }
            catch (OperationCanceledException) when (_cancellation.IsCancellationRequested)
            {
                // Cancellation is expected when the mod is disabled or unloaded.
            }
            catch (Exception exception)
            {
                Logger.Warn(exception, "TaiwuOptimization: event assembly preload coordinator failed; unresolved files will use the original loader.");
            }
            finally
            {
                PreloadResult cancelledResult = PreloadResult.Failed(
                    "cancellation",
                    new OperationCanceledException("Event assembly preload did not complete."));
                foreach (Entry entry in _entries)
                {
                    entry.DllBytes = null;
                    entry.PdbBytes = null;
                    entry.Completion.TrySetResult(cancelledResult);
                }

                Volatile.Write(ref _finishedAt, Stopwatch.GetTimestamp());
                _cancellation.Dispose();
            }
        }

        private void ReadEntry(Entry entry)
        {
            try
            {
                _cancellation.Token.ThrowIfCancellationRequested();
                entry.DllBytes = File.ReadAllBytes(entry.Path);
                Interlocked.Add(ref _readBytes, entry.DllBytes.LongLength);

                string pdbPath = Path.ChangeExtension(entry.Path, ".pdb");
                if (File.Exists(pdbPath))
                {
                    entry.PdbBytes = File.ReadAllBytes(pdbPath);
                    Interlocked.Add(ref _readBytes, entry.PdbBytes.LongLength);
                }
            }
            catch (Exception exception) when (exception is not OperationCanceledException)
            {
                entry.DllBytes = null;
                entry.PdbBytes = null;
                entry.Completion.TrySetResult(PreloadResult.Failed("read", exception));
            }
        }

        private void LoadEntry(Entry entry)
        {
            byte[]? dllBytes = entry.DllBytes;
            if (dllBytes == null)
            {
                return;
            }

            try
            {
                _cancellation.Token.ThrowIfCancellationRequested();
                Assembly assembly = entry.PdbBytes is byte[] pdbBytes
                    ? Assembly.Load(dllBytes, pdbBytes)
                    : Assembly.Load(dllBytes);
                Interlocked.Increment(ref _preloadedCount);
                entry.Completion.TrySetResult(PreloadResult.Succeeded(assembly));
            }
            catch (Exception exception) when (exception is not OperationCanceledException)
            {
                entry.Completion.TrySetResult(PreloadResult.Failed("Assembly.Load", exception));
            }
            finally
            {
                entry.DllBytes = null;
                entry.PdbBytes = null;
            }
        }

        private static string NormalizePath(string path) =>
            Path.GetFullPath(path);

        private static double StopwatchTicksToMilliseconds(long ticks) =>
            ticks * 1000d / Stopwatch.Frequency;
    }

    private sealed class Entry
    {
        public Entry(string path)
        {
            Path = path;
            Completion = new TaskCompletionSource<PreloadResult>(
                TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public string Path { get; }
        public TaskCompletionSource<PreloadResult> Completion { get; }
        public byte[]? DllBytes { get; set; }
        public byte[]? PdbBytes { get; set; }
    }

    private readonly struct PreloadResult
    {
        private PreloadResult(Assembly? assembly, string stage, Exception? exception)
        {
            Assembly = assembly;
            Stage = stage;
            Exception = exception;
        }

        public Assembly? Assembly { get; }
        public string Stage { get; }
        public Exception? Exception { get; }

        public static PreloadResult Succeeded(Assembly assembly) =>
            new(assembly, "complete", null);

        public static PreloadResult Failed(string stage, Exception exception) =>
            new(null, stage, exception);
    }
}

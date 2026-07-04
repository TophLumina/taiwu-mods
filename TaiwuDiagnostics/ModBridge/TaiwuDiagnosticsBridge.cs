using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

internal static class TaiwuDiagnosticsExporter
{
    private const int MaxQueueSize = 1024;
    private static readonly object SyncRoot = new();
    private static readonly Queue<string> Pending = new(MaxQueueSize);
    private static readonly AutoResetEvent Signal = new(false);
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = false,
    };

    private static string _modName = "unknown";
    private static string _endpoint = "http://127.0.0.1:18580/api/events";
    private static HttpClient? _client;
    private static Thread? _worker;
    private static bool _stopping;
    private static bool _initialized;
    private static bool _serverAvailable;
    private static long _lastAvailabilityCheckTicks;
    private static int _port = 18580;
    private static int _consecutiveFailures;
    private static long _spoolSequence;

    public static bool IsAvailable
    {
        get
        {
            if (!_initialized)
            {
                return false;
            }

            if (_serverAvailable)
            {
                return true;
            }

            long now = Environment.TickCount64;
            if (now - _lastAvailabilityCheckTicks < 2000)
            {
                return false;
            }

            _lastAvailabilityCheckTicks = now;
            _serverAvailable = TaiwuDiagnosticsServerLauncher.IsHealthy(_port);
            return _serverAvailable;
        }
    }

    public static void Initialize(string modName, bool launchServer, bool autoOpenDashboard, int port)
    {
        if (port < 18580 || port > 18595)
        {
            port = 18580;
        }

        bool isDiagnosticsMod = string.Equals(modName, "TaiwuDiagnostics", StringComparison.Ordinal);
        bool shouldLaunchServer = launchServer && isDiagnosticsMod;
        bool shouldOpenDashboard = autoOpenDashboard && isDiagnosticsMod;

        lock (SyncRoot)
        {
            _modName = string.IsNullOrEmpty(modName) ? "unknown" : modName;
            _endpoint = "http://127.0.0.1:" + port + "/api/events";
            _port = port;
            _stopping = false;

            if (_client == null)
            {
                _client = new HttpClient
                {
                    Timeout = TimeSpan.FromMilliseconds(350),
                };
            }

            if (_worker == null)
            {
                _worker = new Thread(WorkerLoop)
                {
                    IsBackground = true,
                    Name = "TaiwuDiagnosticsExporter",
                };
                _worker.Start();
            }

            _initialized = true;
        }

        if (shouldLaunchServer)
        {
            _serverAvailable = TaiwuDiagnosticsServerLauncher.EnsureStarted(port, shouldOpenDashboard);
        }
        else
        {
            _serverAvailable = TaiwuDiagnosticsServerLauncher.IsHealthy(port);
        }
    }

    public static void Dispose()
    {
        Thread? worker;
        lock (SyncRoot)
        {
            _stopping = true;
            _initialized = false;
            worker = _worker;
        }

        Signal.Set();
        worker?.Join(500);

        List<string> remaining = new();
        lock (SyncRoot)
        {
            while (Pending.Count > 0)
            {
                remaining.Add(Pending.Dequeue());
            }

            _worker = null;
            _client?.Dispose();
            _client = null;
        }

        foreach (string json in remaining)
        {
            MirrorEventToSpool(json);
        }
    }

    public static void Publish(string eventType, object payload, string? sessionId = null)
    {
        if (!_initialized)
        {
            return;
        }

        try
        {
            object envelope = new
            {
                schemaVersion = 1,
                eventId = Guid.NewGuid().ToString("N"),
                mod = _modName,
                eventType = string.IsNullOrEmpty(eventType) ? "unknown" : eventType,
                timestampUtc = DateTime.UtcNow.ToString("O"),
                sessionId,
                payload = payload ?? new { },
            };

            string json = JsonSerializer.Serialize(envelope, JsonOptions);
            Enqueue(json);
            MirrorEventToSpool(json);
        }
        catch
        {
            // Diagnostics must never affect game logic.
        }
    }

    private static void Enqueue(string json)
    {
        lock (SyncRoot)
        {
            if (_stopping)
            {
                return;
            }

            while (Pending.Count >= MaxQueueSize)
            {
                Pending.Dequeue();
            }

            Pending.Enqueue(json);
        }

        Signal.Set();
    }

    private static void WorkerLoop()
    {
        while (true)
        {
            string? json = null;
            lock (SyncRoot)
            {
                if (Pending.Count > 0)
                {
                    json = Pending.Dequeue();
                }
                else if (_stopping)
                {
                    return;
                }
            }

            if (json == null)
            {
                Signal.WaitOne(1000);
                continue;
            }

            try
            {
                HttpClient? client;
                string endpoint;
                lock (SyncRoot)
                {
                    client = _client;
                    endpoint = _endpoint;
                }

                if (client == null)
                {
                    continue;
                }

                using StringContent content = new(json, Encoding.UTF8, "application/json");
                client.PostAsync(endpoint, content).GetAwaiter().GetResult().Dispose();
                _serverAvailable = true;
                _consecutiveFailures = 0;
            }
            catch
            {
                _serverAvailable = false;
                if (!_stopping && _consecutiveFailures < 12)
                {
                    _consecutiveFailures++;
                    lock (SyncRoot)
                    {
                        if (Pending.Count < MaxQueueSize)
                        {
                            Pending.Enqueue(json);
                        }
                    }

                    Thread.Sleep(Math.Min(250 * _consecutiveFailures, 3000));
                }
                else
                {
                    MirrorEventToSpool(json);
                }

                // The dashboard is optional; failed exports are intentionally silent.
            }
        }
    }

    private static void MirrorEventToSpool(string json)
    {
        if (string.IsNullOrEmpty(json) ||
            string.Equals(_modName, "TaiwuDiagnostics", StringComparison.Ordinal))
        {
            return;
        }

        try
        {
            string? root = TaiwuDiagnosticsServerLauncher.FindDiagnosticsRoot();
            if (string.IsNullOrEmpty(root))
            {
                return;
            }

            string spoolDir = Path.Combine(root, "data", "spool");
            Directory.CreateDirectory(spoolDir);
            string fileName =
                DateTime.UtcNow.ToString("yyyyMMdd_HHmmss_fffffff") +
                "_" + Process.GetCurrentProcess().Id +
                "_" + Interlocked.Increment(ref _spoolSequence) +
                "_" + SanitizeFileName(_modName) +
                ".json";
            string finalPath = Path.Combine(spoolDir, fileName);
            string tempPath = finalPath + ".tmp";
            File.WriteAllText(tempPath, json, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            File.Move(tempPath, finalPath, overwrite: true);
        }
        catch
        {
            // File fallback is best-effort only.
        }
    }

    private static string SanitizeFileName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "unknown";
        }

        char[] invalid = Path.GetInvalidFileNameChars();
        StringBuilder builder = new(value.Length);
        foreach (char ch in value)
        {
            builder.Append(Array.IndexOf(invalid, ch) >= 0 ? '_' : ch);
        }

        return builder.ToString();
    }
}

internal static class TaiwuDiagnosticsServerLauncher
{
    private static readonly object SyncRoot = new();
    private static bool _launchAttempted;
    private static bool _dashboardOpened;

    public static bool EnsureStarted(int port, bool autoOpenDashboard)
    {
        lock (SyncRoot)
        {
            if (_launchAttempted)
            {
                if (autoOpenDashboard)
                {
                    TryOpenDashboard(port);
                }

                return IsHealthy(port);
            }

            _launchAttempted = true;
        }

        if (IsHealthy(port))
        {
            if (autoOpenDashboard)
            {
                TryOpenDashboard(port);
            }

            return true;
        }

        string? root = FindDiagnosticsRoot();
        if (root == null)
        {
            return false;
        }

        if (StartServer(root, port))
        {
            for (int i = 0; i < 20; i++)
            {
                if (IsHealthy(port))
                {
                    if (autoOpenDashboard)
                    {
                        TryOpenDashboard(port);
                    }

                    return true;
                }

                Thread.Sleep(250);
            }
        }

        return false;
    }

    public static bool IsHealthy(int port)
    {
        try
        {
            using HttpClient client = new()
            {
                Timeout = TimeSpan.FromMilliseconds(250),
            };
            using HttpResponseMessage response = client.GetAsync("http://127.0.0.1:" + port + "/api/health")
                .GetAwaiter()
                .GetResult();
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    private static bool StartServer(string root, int port)
    {
        string exePath = Path.Combine(root, "TaiwuDiagnostics.exe");
        string scriptPath = Path.Combine(root, "diagnostics_server.py");
        string dataDir = Path.Combine(root, "data");
        int parentPid = Process.GetCurrentProcess().Id;

        try
        {
            if (File.Exists(exePath))
            {
                ProcessStartInfo info = CreateStartInfo(exePath, root);
                info.ArgumentList.Add("--port");
                info.ArgumentList.Add(port.ToString());
                info.ArgumentList.Add("--data-dir");
                info.ArgumentList.Add(dataDir);
                info.ArgumentList.Add("--parent-pid");
                info.ArgumentList.Add(parentPid.ToString());
                Process.Start(info);
                if (WaitForHealth(port))
                {
                    return true;
                }
            }

            if (File.Exists(scriptPath))
            {
                foreach (PythonCandidate candidate in GetPythonCandidates())
                {
                    if (TryStartPython(
                            candidate.Executable,
                            scriptPath,
                            root,
                            dataDir,
                            port,
                            parentPid,
                            candidate.UsePyLauncher) &&
                        WaitForHealth(port))
                    {
                        return true;
                    }

                    if (TryStartPythonViaCmd(
                            candidate.Executable,
                            scriptPath,
                            root,
                            dataDir,
                            port,
                            parentPid,
                            candidate.UsePyLauncher) &&
                        WaitForHealth(port))
                    {
                        return true;
                    }
                }
            }
        }
        catch
        {
            // Local diagnostics are optional.
        }

        return false;
    }

    private static bool WaitForHealth(int port)
    {
        for (int i = 0; i < 8; i++)
        {
            Thread.Sleep(250);
            if (IsHealthy(port))
            {
                return true;
            }
        }

        return false;
    }

    private static bool TryStartPython(
        string executable,
        string scriptPath,
        string root,
        string dataDir,
        int port,
        int parentPid,
        bool usePyLauncher = false)
    {
        try
        {
            ProcessStartInfo info = CreateStartInfo(executable, root);
            if (usePyLauncher)
            {
                info.ArgumentList.Add("-3");
            }

            info.ArgumentList.Add(scriptPath);
            info.ArgumentList.Add("--port");
            info.ArgumentList.Add(port.ToString());
            info.ArgumentList.Add("--data-dir");
            info.ArgumentList.Add(dataDir);
            info.ArgumentList.Add("--parent-pid");
            info.ArgumentList.Add(parentPid.ToString());
            Process.Start(info);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool TryStartPythonViaCmd(
        string executable,
        string scriptPath,
        string root,
        string dataDir,
        int port,
        int parentPid,
        bool usePyLauncher)
    {
        try
        {
            string arguments =
                "/c start \"\" /B " +
                QuoteForCmd(executable) + " " +
                (usePyLauncher ? "-3 " : string.Empty) +
                QuoteForCmd(scriptPath) +
                " --port " + port +
                " --data-dir " + QuoteForCmd(dataDir) +
                " --parent-pid " + parentPid;

            ProcessStartInfo info = new()
            {
                FileName = "cmd.exe",
                Arguments = arguments,
                WorkingDirectory = root,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            Process.Start(info);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static string QuoteForCmd(string value) =>
        "\"" + value.Replace("\"", "\\\"") + "\"";

    private static List<PythonCandidate> GetPythonCandidates()
    {
        List<PythonCandidate> candidates = new();
        AddPythonCandidate(candidates, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "py.exe"), usePyLauncher: true);
        AddPythonCandidate(candidates, "py", usePyLauncher: true);
        AddPythonCandidate(candidates, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs", "Python", "Launcher", "py.exe"), usePyLauncher: true);
        AddPythonCandidate(candidates, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Python", "python.exe"), usePyLauncher: false);
        AddPythonCandidate(candidates, "python", usePyLauncher: false);
        AddPythonCandidate(candidates, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "WindowsApps", "python.exe"), usePyLauncher: false);
        return candidates;
    }

    private static void AddPythonCandidate(List<PythonCandidate> candidates, string executable, bool usePyLauncher)
    {
        if (string.IsNullOrEmpty(executable))
        {
            return;
        }

        foreach (PythonCandidate candidate in candidates)
        {
            if (string.Equals(candidate.Executable, executable, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
        }

        candidates.Add(new PythonCandidate(executable, usePyLauncher));
    }

    private static ProcessStartInfo CreateStartInfo(string fileName, string workingDirectory)
    {
        return new ProcessStartInfo
        {
            FileName = fileName,
            WorkingDirectory = workingDirectory,
            UseShellExecute = false,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
        };
    }

    private static void TryOpenDashboard(int port)
    {
        lock (SyncRoot)
        {
            if (_dashboardOpened)
            {
                return;
            }

            _dashboardOpened = true;
        }

        OpenDashboard(port);
    }

    private static void OpenDashboard(int port)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://127.0.0.1:" + port + "/",
                UseShellExecute = true,
            });
        }
        catch
        {
        }
    }

    public static string? FindDiagnosticsRoot()
    {
        List<string> anchors = new();
        AddAnchor(anchors, AppContext.BaseDirectory);
        AddAnchor(anchors, Environment.CurrentDirectory);
        string? assemblyPath = Assembly.GetExecutingAssembly().Location;
        if (!string.IsNullOrEmpty(assemblyPath))
        {
            AddAnchor(anchors, Path.GetDirectoryName(assemblyPath));
        }

        foreach (string anchor in anchors)
        {
            string? current = anchor;
            for (int depth = 0; depth < 6 && !string.IsNullOrEmpty(current); depth++)
            {
                if (IsDiagnosticsRoot(current))
                {
                    return current;
                }

                string childRoot = Path.Combine(current, "TaiwuDiagnostics");
                if (IsDiagnosticsRoot(childRoot))
                {
                    return childRoot;
                }

                string gameModRoot = Path.Combine(current, "Mod", "TaiwuDiagnostics");
                if (IsDiagnosticsRoot(gameModRoot))
                {
                    return gameModRoot;
                }

                current = Directory.GetParent(current)?.FullName;
            }
        }

        return null;
    }

    private static bool IsDiagnosticsRoot(string root)
    {
        if (string.IsNullOrEmpty(root))
        {
            return false;
        }

        return File.Exists(Path.Combine(root, "TaiwuDiagnostics.exe")) ||
            File.Exists(Path.Combine(root, "diagnostics_server.py"));
    }

    private static void AddAnchor(List<string> anchors, string? path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        try
        {
            string fullPath = Path.GetFullPath(path);
            if (!anchors.Contains(fullPath))
            {
                anchors.Add(fullPath);
            }
        }
        catch
        {
        }
    }

    private readonly struct PythonCandidate
    {
        public readonly string Executable;
        public readonly bool UsePyLauncher;

        public PythonCandidate(string executable, bool usePyLauncher)
        {
            Executable = executable;
            UsePyLauncher = usePyLauncher;
        }
    }
}

internal static class TaiwuDiagnosticsSnapshotStore
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
    };

    public static TaiwuDiagnosticsSnapshotRequest? QueueArchiveCopy(
        string archivePath,
        string source,
        object metadata,
        int maxSnapshotCount)
    {
        if (string.IsNullOrEmpty(archivePath) || !File.Exists(archivePath))
        {
            return null;
        }

        string? root = TaiwuDiagnosticsServerLauncher.FindDiagnosticsRoot();
        if (root == null)
        {
            return null;
        }

        try
        {
            string snapshotsRoot = Path.Combine(root, "data", "snapshots");
            Directory.CreateDirectory(snapshotsRoot);
            string snapshotId = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss_fff");
            string snapshotDir = Path.Combine(snapshotsRoot, snapshotId);
            Directory.CreateDirectory(snapshotDir);

            TaiwuDiagnosticsSnapshotRequest request = new()
            {
                Id = snapshotId,
                Status = "queued",
                Source = source,
                OriginalPath = archivePath,
                Directory = snapshotDir,
                MetadataPath = Path.Combine(snapshotDir, "metadata.json"),
                RequestedAtUtc = DateTime.UtcNow.ToString("O"),
            };

            WriteMetadata(request, metadata, null, 0);
            Task.Run(() => CopyArchive(request, archivePath, metadata, Math.Max(maxSnapshotCount, 1)));
            return request;
        }
        catch
        {
            return null;
        }
    }

    private static void CopyArchive(
        TaiwuDiagnosticsSnapshotRequest request,
        string archivePath,
        object metadata,
        int maxSnapshotCount)
    {
        try
        {
            string fileName = Path.GetFileName(archivePath);
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = "archive.copy";
            }

            string targetPath = Path.Combine(request.Directory, fileName);
            File.Copy(archivePath, targetPath, overwrite: true);
            long size = new FileInfo(targetPath).Length;
            request.Status = "complete";
            request.ArchiveCopyPath = targetPath;
            request.CompletedAtUtc = DateTime.UtcNow.ToString("O");
            WriteMetadata(request, metadata, null, size);
            CleanupOldSnapshots(Path.GetDirectoryName(request.Directory), maxSnapshotCount);
        }
        catch (Exception exception)
        {
            request.Status = "failed";
            request.Error = exception.GetType().Name + ": " + exception.Message;
            WriteMetadata(request, metadata, request.Error, 0);
        }
    }

    private static void WriteMetadata(
        TaiwuDiagnosticsSnapshotRequest request,
        object metadata,
        string? error,
        long copiedBytes)
    {
        object document = new
        {
            id = request.Id,
            status = request.Status,
            source = request.Source,
            originalPath = request.OriginalPath,
            directory = request.Directory,
            archiveCopyPath = request.ArchiveCopyPath,
            requestedAtUtc = request.RequestedAtUtc,
            completedAtUtc = request.CompletedAtUtc,
            copiedBytes,
            error,
            metadata,
        };

        File.WriteAllText(request.MetadataPath, JsonSerializer.Serialize(document, JsonOptions), Encoding.UTF8);
    }

    private static void CleanupOldSnapshots(string? snapshotsRoot, int maxSnapshotCount)
    {
        if (string.IsNullOrEmpty(snapshotsRoot) || !Directory.Exists(snapshotsRoot))
        {
            return;
        }

        DirectoryInfo[] directories = new DirectoryInfo(snapshotsRoot).GetDirectories();
        Array.Sort(directories, static (left, right) => string.CompareOrdinal(right.Name, left.Name));
        for (int i = maxSnapshotCount; i < directories.Length; i++)
        {
            try
            {
                directories[i].Delete(recursive: true);
            }
            catch
            {
            }
        }
    }
}

internal sealed class TaiwuDiagnosticsSnapshotRequest
{
    public string Id { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string OriginalPath { get; set; } = string.Empty;
    public string Directory { get; set; } = string.Empty;
    public string MetadataPath { get; set; } = string.Empty;
    public string? ArchiveCopyPath { get; set; }
    public string RequestedAtUtc { get; set; } = string.Empty;
    public string? CompletedAtUtc { get; set; }
    public string? Error { get; set; }
}

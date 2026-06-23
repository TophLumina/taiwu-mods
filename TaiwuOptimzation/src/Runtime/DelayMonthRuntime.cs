using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.Map;
using HarmonyLib;

namespace TaiwuOptimization.Runtime;

internal static class DelayMonthRuntime
{
    private static readonly object Sync = new object();
    private static readonly Queue<DelayedMonthJob> Jobs = new Queue<DelayedMonthJob>(512);
    private static readonly HashSet<int> ImmediateAreas = new HashSet<int>();
    private static readonly Dictionary<int, int> JobCountsByArea = new Dictionary<int, int>();

    private static MethodInfo? _characterAreaActionMethod;
    private static bool _advancingMonth;
    private static bool _replaying;
    private static bool _saveAfterFlush;
    private static int _enqueuedThisMonth;
    private static int _appliedThisMonth;

    public static bool IsReplaying => _replaying;
    public static bool HasPendingJobs
    {
        get
        {
            lock (Sync)
            {
                return Jobs.Count > 0;
            }
        }
    }

    public static void Initialize()
    {
        _characterAreaActionMethod = AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });
    }

    public static void Dispose()
    {
        lock (Sync)
        {
            Jobs.Clear();
            ImmediateAreas.Clear();
            JobCountsByArea.Clear();
            _advancingMonth = false;
            _replaying = false;
            _saveAfterFlush = false;
            _enqueuedThisMonth = 0;
            _appliedThisMonth = 0;
        }
    }

    public static void BeginAdvanceMonth(DataContext context)
    {
        FlushAll(context);

        lock (Sync)
        {
            ImmediateAreas.Clear();
            _enqueuedThisMonth = 0;
            _appliedThisMonth = 0;
            _saveAfterFlush = false;
            _advancingMonth = DelayMonthSettings.Enabled;
        }

        if (DelayMonthSettings.Enabled)
        {
            BuildImmediateAreas();
        }
    }

    public static void EndAdvanceMonth()
    {
        lock (Sync)
        {
            _advancingMonth = false;
        }
    }

    public static bool TryDelayCharacterAreaAction(int areaId, ICharacterParallelAction action)
    {
        if (!DelayMonthSettings.Enabled || _replaying || areaId < 0 || !ShouldDelayAction(action))
        {
            return false;
        }

        lock (Sync)
        {
            if (!_advancingMonth || IsImmediateArea(areaId))
            {
                return false;
            }

            EnqueueJob(DelayedMonthJob.CharacterArea(areaId, action));
            _enqueuedThisMonth++;
            return true;
        }
    }

    public static bool TryDelayBrokenBlockArea(int areaId)
    {
        if (!DelayMonthSettings.Enabled || !DelayMonthSettings.DelayBrokenBlocks || _replaying || areaId < 0)
        {
            return false;
        }

        lock (Sync)
        {
            if (!_advancingMonth || IsImmediateArea(areaId))
            {
                return false;
            }

            EnqueueJob(DelayedMonthJob.BrokenBlockArea(areaId));
            _enqueuedThisMonth++;
            return true;
        }
    }

    public static void Tick(DataContext context)
    {
        if (!DelayMonthSettings.Enabled || _advancingMonth || _replaying)
        {
            return;
        }

        FlushLiveImmediateAreas(context);

        int budgetMs = DelayMonthSettings.FrameBudgetMs;
        Stopwatch stopwatch = Stopwatch.StartNew();
        do
        {
            DelayedMonthJob? job = DequeueJob();
            if (job == null)
            {
                TryRunDeferredSave(context);
                return;
            }

            ExecuteJob(context, job);
        }
        while (stopwatch.ElapsedMilliseconds < budgetMs);

        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
        }
    }

    public static void FlushArea(DataContext context, short areaId)
    {
        if (areaId < 0 || _replaying)
        {
            return;
        }

        List<DelayedMonthJob> selected = new List<DelayedMonthJob>();
        lock (Sync)
        {
            if (!JobCountsByArea.ContainsKey(areaId))
            {
                return;
            }

            int count = Jobs.Count;
            for (int i = 0; i < count; i++)
            {
                DelayedMonthJob job = Jobs.Dequeue();
                if (job.AreaId == areaId)
                {
                    selected.Add(job);
                    DecrementJobCount(job.AreaId);
                }
                else
                {
                    Jobs.Enqueue(job);
                }
            }
        }

        foreach (DelayedMonthJob job in selected)
        {
            ExecuteJob(context, job);
        }

        if (!HasPendingJobs)
        {
            TryRunDeferredSave(context);
        }
    }

    public static void FlushAll(DataContext context)
    {
        while (true)
        {
            DelayedMonthJob? job = DequeueJob();
            if (job == null)
            {
                TryRunDeferredSave(context);
                return;
            }

            ExecuteJob(context, job);
        }
    }

    public static bool PostponeSaveIfNeeded(ref bool saveWorld)
    {
        if (!saveWorld)
        {
            return false;
        }

        lock (Sync)
        {
            if (Jobs.Count == 0)
            {
                return false;
            }

            _saveAfterFlush = true;
            saveWorld = false;
            return true;
        }
    }

    public static void ExecuteOriginalCharacterAreaAction(DataContext context, int areaId, ICharacterParallelAction action)
    {
        if (_characterAreaActionMethod == null)
        {
            throw new InvalidOperationException("Character area action method was not resolved.");
        }

        _characterAreaActionMethod.Invoke(null, new object[] { context, areaId, action });
    }

    private static void BuildImmediateAreas()
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return;
        }

        AddImmediateArea(location.AreaId);

        List<short> areaList = new List<short>(16);
        sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
        DomainManager.Map.GetAllAreaInState(stateId, areaList);
        foreach (short areaId in areaList)
        {
            AddImmediateArea(areaId);
        }

        AddNeighborAreas(location.AreaId);
    }

    private static void AddNeighborAreas(short areaId)
    {
        if (!DelayMonthSettings.ImmediateNeighborAreas || areaId < 0 || areaId >= 135)
        {
            return;
        }

        foreach (short neighborArea in DomainManager.Map.GetAreaByAreaId(areaId).NeighborAreas)
        {
            AddImmediateArea(neighborArea);
        }
    }

    private static void AddImmediateArea(short areaId)
    {
        if (areaId >= 0 && areaId < 141)
        {
            lock (Sync)
            {
                ImmediateAreas.Add(areaId);
            }
        }
    }

    private static bool IsImmediateArea(int areaId)
    {
        if (ImmediateAreas.Contains(areaId))
        {
            return true;
        }

        return IsLiveImmediateArea(areaId);
    }

    private static bool IsLiveImmediateArea(int areaId)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return false;
        }

        if (areaId == location.AreaId)
        {
            return true;
        }

        if (!DelayMonthSettings.ImmediateNeighborAreas || location.AreaId < 0 || location.AreaId >= 135)
        {
            return false;
        }

        return DomainManager.Map.GetAreaByAreaId(location.AreaId).NeighborAreas.Contains((short)areaId);
    }

    private static void FlushLiveImmediateAreas(DataContext context)
    {
        Location location = DomainManager.Taiwu.GetTaiwu()?.GetLocation() ?? Location.Invalid;
        if (!location.IsValid())
        {
            return;
        }

        FlushArea(context, location.AreaId);

        if (!DelayMonthSettings.ImmediateNeighborAreas || location.AreaId < 0 || location.AreaId >= 135)
        {
            return;
        }

        foreach (short neighborArea in DomainManager.Map.GetAreaByAreaId(location.AreaId).NeighborAreas)
        {
            FlushArea(context, neighborArea);
        }
    }

    private static bool ShouldDelayAction(ICharacterParallelAction action)
    {
        Type type = action.GetType();
        if (type == typeof(CharacterSelfImprovement) ||
            type == typeof(CharacterSelfImprovement_LearnNewSkills) ||
            type == typeof(CharacterSelfImprovement_Reading) ||
            type == typeof(CharacterSelfImprovement_PracticeAndBreakout) ||
            type == typeof(CharacterPreparation_GetSupply))
        {
            return true;
        }

        if (DelayMonthSettings.DelayEquipment &&
            type == typeof(CharacterPreparation_CombatSkillAndItemEquipping))
        {
            return true;
        }

        if (DelayMonthSettings.DelayMissionGoal &&
            (type == typeof(UpdateCharacterMission) || type == typeof(UpdateCharacterGoal)))
        {
            return true;
        }

        if (DelayMonthSettings.DelayLoseOverloadItems &&
            type == typeof(CharacterPreparation_LoseOverloadItems))
        {
            return true;
        }

        return false;
    }

    private static DelayedMonthJob? DequeueJob()
    {
        lock (Sync)
        {
            if (Jobs.Count == 0)
            {
                return null;
            }

            DelayedMonthJob job = Jobs.Dequeue();
            DecrementJobCount(job.AreaId);
            return job;
        }
    }

    private static void EnqueueJob(DelayedMonthJob job)
    {
        Jobs.Enqueue(job);
        JobCountsByArea.TryGetValue(job.AreaId, out int count);
        JobCountsByArea[job.AreaId] = count + 1;
    }

    private static void DecrementJobCount(int areaId)
    {
        int count = JobCountsByArea[areaId] - 1;
        if (count <= 0)
        {
            JobCountsByArea.Remove(areaId);
        }
        else
        {
            JobCountsByArea[areaId] = count;
        }
    }

    private static void ExecuteJob(DataContext context, DelayedMonthJob job)
    {
        _replaying = true;
        try
        {
            job.Execute(context);
            context.ParallelModificationsRecorder.ApplyAll(context);
            _appliedThisMonth++;
        }
        finally
        {
            _replaying = false;
        }
    }

    private static void TryRunDeferredSave(DataContext context)
    {
        bool shouldSave;
        lock (Sync)
        {
            shouldSave = _saveAfterFlush && Jobs.Count == 0;
            _saveAfterFlush = false;
        }

        if (shouldSave)
        {
            DomainManager.Global.SaveWorld(context);
        }
    }
}

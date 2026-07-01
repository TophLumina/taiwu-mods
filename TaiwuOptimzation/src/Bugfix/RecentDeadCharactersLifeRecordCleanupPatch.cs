using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using GameData.ArchiveData;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Utilities;
using HarmonyLib;
using NLog;

namespace TaiwuOptimization.Bugfix;

/// <summary>
/// 将近期死亡角色生平清理从逐角色 SQLite auto commit 改为单事务批量删除。
/// </summary>
[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.TryRemoveRecentDeadCharacters))]
internal static class RecentDeadCharactersLifeRecordCleanupPatch
{
    private const int DeleteBatchSize = 900;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    private static readonly FieldInfo RecentDeadCharactersField =
        AccessTools.Field(typeof(CharacterDomain), "_recentDeadCharacters");

    private static readonly MethodInfo RemoveRecentDeadCharacterMethod =
        AccessTools.Method(
            typeof(CharacterDomain),
            "RemoveElement_RecentDeadCharacters",
            new[] { typeof(IntPair), typeof(DataContext) });

    /// <summary>
    /// 替换原版逐个 `LifeRecordDomain.Remove` 的清理逻辑；失败时回退原版路径。
    /// </summary>
    private static bool Prefix(CharacterDomain __instance, DataContext context)
    {
        try
        {
            if (!TryCollectExpiredRecentDeadCharacters(
                    __instance,
                    out List<IntPair> expiredKeys,
                    out List<int> expiredCharIds,
                    out int recentDeadCount))
            {
                return true;
            }

            if (expiredKeys.Count == 0)
            {
                return false;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            int affectedRows = DeleteLifeRecordTmpBySelf(expiredCharIds);
            for (int i = 0; i < expiredKeys.Count; i++)
            {
                RemoveRecentDeadCharacterMethod.Invoke(__instance, new object[] { expiredKeys[i], context });
            }

            stopwatch.Stop();
            Logger.Info(
                $"TaiwuOptimization: batch removed recent dead characters life records {expiredKeys.Count}/{recentDeadCount}, " +
                $"uniqueChars={expiredCharIds.Count}, affectedRows={affectedRows}, cost={stopwatch.ElapsedMilliseconds}ms");
            return false;
        }
        catch (Exception exception)
        {
            Logger.Warn(exception, "TaiwuOptimization: failed to batch remove recent dead character life records; fallback to original cleanup.");
            return true;
        }
    }

    /// <summary>
    /// 收集原版本月应清理的 `_recentDeadCharacters` 项。
    /// </summary>
    private static bool TryCollectExpiredRecentDeadCharacters(
        CharacterDomain characterDomain,
        out List<IntPair> expiredKeys,
        out List<int> expiredCharIds,
        out int recentDeadCount)
    {
        expiredKeys = new List<IntPair>();
        expiredCharIds = new List<int>();
        recentDeadCount = 0;

        object? recentDeadCharacters = RecentDeadCharactersField.GetValue(characterDomain);
        if (recentDeadCharacters is not IEnumerable<KeyValuePair<IntPair, VoidValue>> recentDeadEnumerable)
        {
            return false;
        }

        int expireDateExclusive = GameData.Domains.DomainManager.World.GetCurrDate() - 12;
        HashSet<int> seenCharIds = new HashSet<int>();
        foreach (KeyValuePair<IntPair, VoidValue> recentDeadCharacter in recentDeadEnumerable)
        {
            recentDeadCount++;
            IntPair key = recentDeadCharacter.Key;
            if (key.First >= expireDateExclusive)
            {
                continue;
            }

            expiredKeys.Add(key);
            if (seenCharIds.Add(key.Second))
            {
                expiredCharIds.Add(key.Second);
            }
        }

        return true;
    }

    /// <summary>
    /// 使用一笔事务分块删除 `LifeRecordTmp.Self` 命中的生平记录。
    /// </summary>
    private static int DeleteLifeRecordTmpBySelf(IReadOnlyList<int> charIds)
    {
        if (charIds.Count == 0)
        {
            return 0;
        }

        var connection = DatabaseBridge.TmpConnection;
        bool ownsTransaction = !connection.IsInTransaction;
        if (ownsTransaction)
        {
            connection.BeginTransaction();
        }

        try
        {
            int affectedRows = 0;
            for (int offset = 0; offset < charIds.Count; offset += DeleteBatchSize)
            {
                int count = Math.Min(DeleteBatchSize, charIds.Count - offset);
                string sql = BuildDeleteSql(count);
                object[] args = new object[count];
                for (int i = 0; i < count; i++)
                {
                    args[i] = charIds[offset + i];
                }

                affectedRows += connection.Execute(sql, args);
            }

            if (ownsTransaction)
            {
                connection.Commit();
            }

            return affectedRows;
        }
        catch
        {
            if (ownsTransaction)
            {
                connection.Rollback();
            }

            throw;
        }
    }

    /// <summary>
    /// 构造 `DELETE FROM LifeRecordTmp WHERE Self IN (...)`。
    /// </summary>
    private static string BuildDeleteSql(int parameterCount)
    {
        StringBuilder builder = new StringBuilder("DELETE FROM LifeRecordTmp WHERE Self IN (");
        for (int i = 0; i < parameterCount; i++)
        {
            if (i > 0)
            {
                builder.Append(',');
            }

            builder.Append('?');
        }

        builder.Append(')');
        return builder.ToString();
    }
}

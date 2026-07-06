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
/// 将原版 `CharacterDomain.TryRemoveRecentDeadCharacters` 中逐角色删除 `LifeRecordTmp` 的逻辑改为批量删除。
/// </summary>
[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.TryRemoveRecentDeadCharacters))]
internal static class CharacterDomainRecentDeadCharactersCleanupPatch
{
    /// <summary>单条 SQL 使用的最大参数数，低于 SQLite 常见 999 参数上限。</summary>
    private const int LifeRecordTmpDeleteBatchSize = 900;

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>原版 `CharacterDomain._recentDeadCharacters` 字段。</summary>
    private static readonly FieldInfo RecentDeadCharactersField =
        AccessTools.Field(typeof(CharacterDomain), "_recentDeadCharacters");

    /// <summary>原版移除 `_recentDeadCharacters` 单项并标记数据变更的方法。</summary>
    private static readonly MethodInfo RemoveElementRecentDeadCharactersMethod =
        AccessTools.Method(
            typeof(CharacterDomain),
            "RemoveElement_RecentDeadCharacters",
            new[] { typeof(IntPair), typeof(DataContext) });

    /// <summary>
    /// 替换原版逐个调用 `LifeRecordDomain.Remove` 的清理流程；异常时回退原版逻辑。
    /// </summary>
    private static bool Prefix(CharacterDomain __instance, DataContext context)
    {
        try
        {
            if (!TryCollectRecentDeadCharactersToRemove(
                    __instance,
                    out List<IntPair> recentDeadCharacterKeysToRemove,
                    out List<int> deadCharacterIdsToRemove,
                    out int recentDeadCharacterCount))
            {
                return true;
            }

            if (recentDeadCharacterKeysToRemove.Count == 0)
            {
                return false;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            int affectedRows = DeleteLifeRecordTmpBySelf(deadCharacterIdsToRemove);
            for (int i = 0; i < recentDeadCharacterKeysToRemove.Count; i++)
            {
                RemoveElementRecentDeadCharactersMethod.Invoke(
                    __instance,
                    new object[] { recentDeadCharacterKeysToRemove[i], context });
            }

            stopwatch.Stop();
            Logger.Info(
                $"TaiwuOptimization: batch removed recent dead characters life records " +
                $"{recentDeadCharacterKeysToRemove.Count}/{recentDeadCharacterCount}, " +
                $"uniqueChars={deadCharacterIdsToRemove.Count}, affectedRows={affectedRows}, " +
                $"cost={stopwatch.ElapsedMilliseconds}ms");
            return false;
        }
        catch (Exception exception)
        {
            Logger.Warn(
                exception,
                "TaiwuOptimization: failed to batch remove recent dead character life records; fallback to original cleanup.");
            return true;
        }
    }

    /// <summary>
    /// 收集原版本次会从 `_recentDeadCharacters` 中移除的角色键和值。
    /// </summary>
    private static bool TryCollectRecentDeadCharactersToRemove(
        CharacterDomain characterDomain,
        out List<IntPair> recentDeadCharacterKeysToRemove,
        out List<int> deadCharacterIdsToRemove,
        out int recentDeadCharacterCount)
    {
        recentDeadCharacterKeysToRemove = new List<IntPair>();
        deadCharacterIdsToRemove = new List<int>();
        recentDeadCharacterCount = 0;

        object? recentDeadCharacters = RecentDeadCharactersField.GetValue(characterDomain);
        if (recentDeadCharacters is not IEnumerable<KeyValuePair<IntPair, VoidValue>> recentDeadCharacterEnumerable)
        {
            return false;
        }

        int expireDateExclusive = GameData.Domains.DomainManager.World.GetCurrDate() - 12;
        HashSet<int> collectedCharacterIds = new HashSet<int>();
        foreach (KeyValuePair<IntPair, VoidValue> recentDeadCharacter in recentDeadCharacterEnumerable)
        {
            recentDeadCharacterCount++;
            IntPair recentDeadCharacterKey = recentDeadCharacter.Key;
            if (recentDeadCharacterKey.First >= expireDateExclusive)
            {
                continue;
            }

            recentDeadCharacterKeysToRemove.Add(recentDeadCharacterKey);
            if (collectedCharacterIds.Add(recentDeadCharacterKey.Second))
            {
                deadCharacterIdsToRemove.Add(recentDeadCharacterKey.Second);
            }
        }

        return true;
    }

    /// <summary>
    /// 用一笔事务分块删除 `LifeRecordTmp.Self` 命中的生平记录。
    /// </summary>
    private static int DeleteLifeRecordTmpBySelf(IReadOnlyList<int> characterIds)
    {
        if (characterIds.Count == 0)
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
            for (int offset = 0; offset < characterIds.Count; offset += LifeRecordTmpDeleteBatchSize)
            {
                int parameterCount = Math.Min(LifeRecordTmpDeleteBatchSize, characterIds.Count - offset);
                string sql = BuildDeleteLifeRecordTmpBySelfSql(parameterCount);
                object[] parameters = new object[parameterCount];
                for (int i = 0; i < parameterCount; i++)
                {
                    parameters[i] = characterIds[offset + i];
                }

                affectedRows += connection.Execute(sql, parameters);
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
    private static string BuildDeleteLifeRecordTmpBySelfSql(int parameterCount)
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

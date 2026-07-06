using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.Common;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using HarmonyLib;
using SecretInformationData = GameData.Domains.Information.Secret.SecretInformation;

namespace TaiwuOptimization.Runtime;

internal static class SecretInformationMetabolismOptimizer
{
    private static readonly FieldInfo? SecretInformationField =
        AccessTools.Field(typeof(InformationDomain), "_secretInformation");

    private static readonly FieldInfo? SecretOccurenceField =
        AccessTools.Field(typeof(InformationDomain), "_secretOccurence");

    private static readonly FieldInfo? CharacterKnownSecretsField =
        AccessTools.Field(typeof(InformationDomain), "_characterKnownSecrets");

    private static readonly MethodInfo? RecordSecretInformationRemoveMethod =
        AccessTools.Method(
            typeof(InformationDomain),
            "RecordSecretInformationRemove",
            new[] { typeof(DataContext), typeof(IEnumerable<SecretInformationId>) });

    private static readonly MethodInfo? RecordSecretOccurenceRemoveMethod =
        AccessTools.Method(
            typeof(InformationDomain),
            "RecordSecretOccurenceRemove",
            new[] { typeof(DataContext), typeof(IEnumerable<SecretOccurenceId>) });

    private static readonly Dictionary<SecretInformationId, HashSet<int>> HoldersBySecret = new(16384);
    private static readonly Dictionary<SecretInformationId, int> SecretHolderCounts = new(16384);
    private static readonly Dictionary<SecretOccurenceId, HashSet<SecretInformationId>> ProcessedSecretIdsByOccurence = new(8192);
    private static readonly HashSet<SecretInformationId> SecretIdsToRemove = new();
    private static readonly HashSet<SecretOccurenceId> OccurenceIdsToRemove = new();

    /// <summary>尝试用等价实现替换原版秘闻代谢阶段。</summary>
    /// <returns>返回 true 表示已完成优化实现，原版方法应跳过。</returns>
    public static bool TryProcessMetabolismSecretInformation(InformationDomain domain, DataContext context)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled ||
            !TryGetSecretInformationMap(domain, out Dictionary<SecretInformationId, SecretInformationData>? secretMap) ||
            !TryGetSecretOccurenceMap(domain, out Dictionary<SecretOccurenceId, SecretOccurence>? occurenceMap) ||
            !TryGetCharacterKnownSecretsMap(domain, out Dictionary<int, CharacterKnownSecret>? knownSecretMap) ||
            RecordSecretInformationRemoveMethod == null ||
            RecordSecretOccurenceRemoveMethod == null)
        {
            return false;
        }

        if (secretMap == null || occurenceMap == null || knownSecretMap == null)
        {
            return false;
        }

        try
        {
            BuildIndexes(secretMap, knownSecretMap);
            ProcessSecrets(domain, context, secretMap, occurenceMap);
            ProcessExpiredOccurences(occurenceMap);
            InvokeRecordSecretInformationRemove(domain, context);
            InvokeRecordSecretOccurenceRemove(domain, context);
            return true;
        }
        finally
        {
            Clear();
        }
    }

    private static void BuildIndexes(
        Dictionary<SecretInformationId, SecretInformationData> secretMap,
        Dictionary<int, CharacterKnownSecret> knownSecretMap)
    {
        Clear();
        foreach (KeyValuePair<int, CharacterKnownSecret> pair in knownSecretMap)
        {
            CharacterKnownSecret? known = pair.Value;
            if (known?.KnownSecrets == null)
            {
                continue;
            }

            foreach (SecretInformationId secretId in known.KnownSecrets)
            {
                if (!secretMap.ContainsKey(secretId))
                {
                    continue;
                }

                if (!HoldersBySecret.TryGetValue(secretId, out HashSet<int>? holders))
                {
                    holders = new HashSet<int>();
                    HoldersBySecret.Add(secretId, holders);
                }

                holders.Add(pair.Key);
            }
        }
    }

    private static void ProcessSecrets(
        InformationDomain domain,
        DataContext context,
        Dictionary<SecretInformationId, SecretInformationData> secretMap,
        Dictionary<SecretOccurenceId, SecretOccurence> occurenceMap)
    {
        List<SecretInformationId> secretIds = new(secretMap.Keys);
        foreach (SecretInformationId secretId in secretIds)
        {
            if (!secretMap.TryGetValue(secretId, out SecretInformationData? secret) ||
                secret == null ||
                !occurenceMap.TryGetValue(secret.OccurenceId, out SecretOccurence? occurence) ||
                occurence == null)
            {
                continue;
            }

            HoldersBySecret.TryGetValue(secretId, out HashSet<int>? holders);
            int holderCount = holders?.Count ?? 0;
            int remainingLifeTime = InformationDomain.CalcSecretOccurenceRemainingLifeTime(occurence);
            SecretInformationItem secretInformationItem = Config.SecretInformation.Instance[occurence.TemplateId];

            if (holderCount >= secretInformationItem.MaxPersonAmount)
            {
                domain.GmCmd_MakeSecretInformationBroadcast(context, secretId, secret.SourceCharacterId);
            }

            if (remainingLifeTime <= 0 || occurence.InBroadcast)
            {
                if (holders != null)
                {
                    foreach (int holderId in holders)
                    {
                        domain.DiscardSecretInformation(context, holderId, secretId);
                    }
                }

                holderCount = 0;
            }

            if (!ProcessedSecretIdsByOccurence.TryGetValue(occurence.Id, out HashSet<SecretInformationId>? processedSecretIds))
            {
                processedSecretIds = new HashSet<SecretInformationId>();
                ProcessedSecretIdsByOccurence.Add(occurence.Id, processedSecretIds);
            }

            processedSecretIds.Add(secretId);
            SecretHolderCounts[secretId] = occurence.InBroadcast ? 1 : holderCount;
        }

        foreach (KeyValuePair<SecretInformationId, int> pair in SecretHolderCounts)
        {
            if (pair.Value < 1)
            {
                SecretIdsToRemove.Add(pair.Key);
            }
        }
    }

    private static void ProcessExpiredOccurences(Dictionary<SecretOccurenceId, SecretOccurence> occurenceMap)
    {
        List<SecretOccurence> occurences = new(occurenceMap.Values);
        foreach (SecretOccurence? occurence in occurences)
        {
            if (occurence == null || InformationDomain.CalcSecretOccurenceRemainingLifeTime(occurence) > 0)
            {
                continue;
            }

            OccurenceIdsToRemove.Add(occurence.Id);
            if (ProcessedSecretIdsByOccurence.TryGetValue(occurence.Id, out HashSet<SecretInformationId>? secretIds))
            {
                SecretIdsToRemove.UnionWith(secretIds);
            }
        }
    }

    private static void InvokeRecordSecretInformationRemove(InformationDomain domain, DataContext context)
    {
        RecordSecretInformationRemoveMethod!.Invoke(domain, new object[] { context, SecretIdsToRemove });
    }

    private static void InvokeRecordSecretOccurenceRemove(InformationDomain domain, DataContext context)
    {
        RecordSecretOccurenceRemoveMethod!.Invoke(domain, new object[] { context, OccurenceIdsToRemove });
    }

    private static bool TryGetSecretInformationMap(
        InformationDomain domain,
        out Dictionary<SecretInformationId, SecretInformationData>? secrets)
    {
        secrets = SecretInformationField?.GetValue(domain) as Dictionary<SecretInformationId, SecretInformationData>;
        return secrets != null;
    }

    private static bool TryGetSecretOccurenceMap(
        InformationDomain domain,
        out Dictionary<SecretOccurenceId, SecretOccurence>? occurences)
    {
        occurences = SecretOccurenceField?.GetValue(domain) as Dictionary<SecretOccurenceId, SecretOccurence>;
        return occurences != null;
    }

    private static bool TryGetCharacterKnownSecretsMap(
        InformationDomain domain,
        out Dictionary<int, CharacterKnownSecret>? knownSecrets)
    {
        knownSecrets = CharacterKnownSecretsField?.GetValue(domain) as Dictionary<int, CharacterKnownSecret>;
        return knownSecrets != null;
    }

    private static void Clear()
    {
        HoldersBySecret.Clear();
        SecretHolderCounts.Clear();
        ProcessedSecretIdsByOccurence.Clear();
        SecretIdsToRemove.Clear();
        OccurenceIdsToRemove.Clear();
    }
}

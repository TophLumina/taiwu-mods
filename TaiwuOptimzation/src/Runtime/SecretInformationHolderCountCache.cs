using System.Collections.Generic;
using System.Reflection;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using HarmonyLib;

namespace TaiwuOptimization.Runtime;

internal static class SecretInformationHolderCountCache
{
    private static readonly FieldInfo? SecretInformationField =
        AccessTools.Field(typeof(InformationDomain), "_secretInformation");

    private static readonly FieldInfo? CharacterKnownSecretsField =
        AccessTools.Field(typeof(InformationDomain), "_characterKnownSecrets");

    private static readonly Dictionary<SecretInformationId, SecretOccurenceId> SecretToOccurence = new(16384);
    private static readonly Dictionary<SecretOccurenceId, int> HolderCountsByOccurence = new(8192);
    private static readonly HashSet<SecretOccurenceId> CharacterOccurenceScratch = new();

    private static bool _inSecretInformationAdvanceMonth;
    private static bool _active;

    /// <summary>进入原版秘闻月结阶段，等待普通见闻生成结束后再建立索引。</summary>
    public static void BeginSecretInformationAdvanceMonth()
    {
        _inSecretInformationAdvanceMonth = TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled;
        _active = false;
        Clear();
    }

    /// <summary>离开原版秘闻月结阶段，释放本月临时索引。</summary>
    public static void EndSecretInformationAdvanceMonth()
    {
        _inSecretInformationAdvanceMonth = false;
        _active = false;
        Clear();
    }

    /// <summary>在 MakeSettlementsInformation 之后建立 holder count 反查表。</summary>
    /// <param name="domain">原版 InformationDomain 实例。</param>
    public static void BuildAfterMakeSettlementsInformation(InformationDomain domain)
    {
        if (!_inSecretInformationAdvanceMonth)
        {
            return;
        }

        if (!TryGetSecretInformationMap(domain, out Dictionary<SecretInformationId, SecretInformation>? secrets) ||
            !TryGetCharacterKnownSecretsMap(domain, out Dictionary<int, CharacterKnownSecret>? knownSecrets))
        {
            _active = false;
            return;
        }

        if (secrets == null || knownSecrets == null)
        {
            _active = false;
            return;
        }

        Dictionary<SecretInformationId, SecretInformation> secretMap = secrets;
        Dictionary<int, CharacterKnownSecret> knownSecretMap = knownSecrets;
        Clear();
        foreach (KeyValuePair<SecretInformationId, SecretInformation> pair in secretMap)
        {
            SecretInformation? secret = pair.Value;
            if (secret == null)
            {
                continue;
            }

            SecretToOccurence[pair.Key] = secret.OccurenceId;
            HolderCountsByOccurence.TryAdd(secret.OccurenceId, 0);
        }

        foreach (CharacterKnownSecret known in knownSecretMap.Values)
        {
            if (known == null || known.KnownSecrets == null)
            {
                continue;
            }

            CharacterOccurenceScratch.Clear();
            foreach (SecretInformationId secretId in known.KnownSecrets)
            {
                if (SecretToOccurence.TryGetValue(secretId, out SecretOccurenceId occurenceId))
                {
                    CharacterOccurenceScratch.Add(occurenceId);
                }
            }

            foreach (SecretOccurenceId occurenceId in CharacterOccurenceScratch)
            {
                HolderCountsByOccurence[occurenceId] = HolderCountsByOccurence.TryGetValue(occurenceId, out int count)
                    ? count + 1
                    : 1;
            }
        }

        CharacterOccurenceScratch.Clear();
        _active = true;
    }

    /// <summary>进入秘闻代谢前停用索引，保守地让广播和删除逻辑走原版扫描。</summary>
    public static void DeactivateBeforeMetabolismSecretInformation()
    {
        _active = false;
        Clear();
    }

    /// <summary>尝试用反查表回答 occurenceId 的当前持有人数量。</summary>
    /// <param name="occurenceId">秘闻事件 id。</param>
    /// <param name="holderCount">当前持有人数量。</param>
    /// <returns>返回 true 表示可以跳过原版全表扫描。</returns>
    public static bool TryGetHolderCount(SecretOccurenceId occurenceId, out int holderCount)
    {
        if (_active && HolderCountsByOccurence.TryGetValue(occurenceId, out holderCount))
        {
            return true;
        }

        holderCount = 0;
        return false;
    }

    /// <summary>原版新增 SecretInformation 后，同步 secretId 到 occurenceId 的映射。</summary>
    public static void OnSecretInformationAdded(SecretInformationId secretId, SecretInformation secret)
    {
        if (_active)
        {
            SecretToOccurence[secretId] = secret.OccurenceId;
            HolderCountsByOccurence.TryAdd(secret.OccurenceId, 0);
        }
    }

    /// <summary>传播成功后同步增加对应 occurenceId 的持有人数量。</summary>
    /// <param name="success">原版 ReceiveSecretInformation 是否成功。</param>
    /// <param name="realReceivedSecretId">目标角色实际获得的 secretId。</param>
    public static void OnReceiveSecretInformationFinished(bool success, SecretInformationId realReceivedSecretId)
    {
        if (!_active || !success)
        {
            return;
        }

        if (!realReceivedSecretId.Valid ||
            !SecretToOccurence.TryGetValue(realReceivedSecretId, out SecretOccurenceId occurenceId))
        {
            // 出现未知路径时回退原版，避免把错误 holder count 继续传下去。
            _active = false;
            Clear();
            return;
        }

        HolderCountsByOccurence[occurenceId] = HolderCountsByOccurence.TryGetValue(occurenceId, out int count)
            ? count + 1
            : 1;
    }

    /// <summary>传播阶段若意外删除 SecretInformation，则停用索引并回退原版。</summary>
    public static void OnSecretInformationRemoved()
    {
        if (_active)
        {
            _active = false;
            Clear();
        }
    }

    private static bool TryGetSecretInformationMap(
        InformationDomain domain,
        out Dictionary<SecretInformationId, SecretInformation>? secrets)
    {
        secrets = SecretInformationField?.GetValue(domain) as Dictionary<SecretInformationId, SecretInformation>;
        return secrets != null;
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
        SecretToOccurence.Clear();
        HolderCountsByOccurence.Clear();
        CharacterOccurenceScratch.Clear();
    }
}

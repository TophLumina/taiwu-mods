using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;

namespace TaiwuOptimization.Runtime;

internal static class OfflineUpdateCurrentGoalActionsActionPointReducer
{
    // 原版每月对 Primary/Secondary goal 各增加 40 行动点，上限 60。
    private const int OriginalMonthlyActionPointGain = 40;
    private const int OriginalActionPointCap = 60;

    // 太吾村组织 template id，用于可选保护村民。
    private const sbyte TaiwuVillageOrgTemplateId = 16;

    /// <summary>在原版 OfflineUpdateCurrentGoalActions 执行前记录行动点。</summary>
    /// <param name="character">正在更新目标行动点的角色。</param>
    /// <param name="goalType">Primary 或 Secondary goal。</param>
    public static OfflineCurrentGoalActionPointState CaptureBeforeOfflineUpdateCurrentGoalActions(Character character, ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsAdvanceMonthOptimizationEnabled())
        {
            return default;
        }

        int previousActionPoint = GetActionPoint(character.ActionPlanningData, goalType);
        return new OfflineCurrentGoalActionPointState(previousActionPoint);
    }

    /// <summary>在原版行动点增长后，按配置削减未受保护远区 NPC 的本月增长量。</summary>
    /// <param name="character">正在更新目标行动点的角色。</param>
    /// <param name="goalType">Primary 或 Secondary goal。</param>
    /// <param name="state">Prefix 捕获到的原行动点状态。</param>
    public static void ReduceOfflineCurrentGoalActionPointGainIfNeeded(Character character, ActionPlanningData.ECurrentGoalType goalType, OfflineCurrentGoalActionPointState state)
    {
        if (!state.IsValid || !IsAdvanceMonthOptimizationEnabled() || ShouldKeepOriginalActionPointGain(character))
        {
            return;
        }

        ActionPlanningData actionPlanningData = character.ActionPlanningData;
        int currentActionPoint = GetActionPoint(actionPlanningData, goalType);
        if (currentActionPoint <= state.PreviousActionPoint)
        {
            return;
        }

        int reducedGain = OriginalMonthlyActionPointGain - TaiwuOptimizationSettings.RemoteNpcOfflineCurrentGoalActionPointGainReduction;
        int reducedActionPoint = Math.Min(state.PreviousActionPoint + reducedGain, OriginalActionPointCap);
        if (currentActionPoint <= reducedActionPoint)
        {
            return;
        }

        SetActionPoint(actionPlanningData, goalType, reducedActionPoint);
    }

    /// <summary>检查实验性行动点削减是否启用。</summary>
    private static bool IsAdvanceMonthOptimizationEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.ReduceRemoteNpcOfflineCurrentGoalActionPointGain &&
        TaiwuOptimizationSettings.RemoteNpcOfflineCurrentGoalActionPointGainReduction > 0;

    /// <summary>判断角色是否应保留原版行动点增长。</summary>
    /// <param name="character">待判断角色。</param>
    private static bool ShouldKeepOriginalActionPointGain(Character character)
    {
        if (!PeriAdvanceMonthProtectionCache.TryGetSnapshot(out PeriAdvanceMonthProtectionCache.Snapshot protection))
        {
            return true;
        }

        int charId = character.GetId();
        if (protection.IsTaiwuOrGroupMember(charId) ||
            protection.IsDirectlyRelatedToTaiwuGroup(charId) ||
            IsSpecialOrEventCharacter(character) ||
            IsInProtectedArea(character, protection) ||
            HasActionTargetInTaiwuGroup(character, protection))
        {
            return true;
        }

        OrganizationInfo organizationInfo = character.GetOrganizationInfo();
        if (TaiwuOptimizationSettings.ProtectTaiwuVillageResidentsFromOfflineActionPointReduction &&
            organizationInfo.OrgTemplateId == TaiwuVillageOrgTemplateId)
        {
            return true;
        }

        return TaiwuOptimizationSettings.ProtectSectMembersFromOfflineActionPointReduction &&
            organizationInfo.OrgTemplateId >= 0 &&
            OrganizationDomain.IsSect(organizationInfo.OrgTemplateId);
    }

    /// <summary>排除临时角色、特殊组成员、旅行中角色和特殊事件角色。</summary>
    /// <param name="character">待判断角色。</param>
    private static bool IsSpecialOrEventCharacter(Character character)
    {
        int charId = character.GetId();
        return character.GetCreatingType() != 1 ||
            DomainManager.Character.IsTemporaryIntelligentCharacter(charId) ||
            DomainManager.Character.IsSpecialGroupMember(character) ||
            character.IsCrossAreaTraveling() ||
            DomainManager.LegendaryBook.IsCharacterActingCrazy(character);
    }

    /// <summary>判断角色是否位于通用保护区域。</summary>
    /// <param name="character">待判断角色。</param>
    /// <param name="protection">当前 protection cache 快照。</param>
    private static bool IsInProtectedArea(Character character, PeriAdvanceMonthProtectionCache.Snapshot protection)
    {
        Location location = character.GetLocation();
        return !location.IsValid() || protection.IsProtectedArea(location.AreaId);
    }

    /// <summary>判断角色当前目标是否直接指向太吾或队友。</summary>
    /// <param name="character">待判断角色。</param>
    /// <param name="protection">当前 protection cache 快照。</param>
    private static bool HasActionTargetInTaiwuGroup(Character character, PeriAdvanceMonthProtectionCache.Snapshot protection)
    {
        ActionPlanningData actionPlanningData = character.ActionPlanningData;
        return protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Primary)) ||
            protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Secondary));
    }

    /// <summary>读取指定 goal 的行动点。</summary>
    /// <param name="actionPlanningData">角色的 ActionPlanningData。</param>
    /// <param name="goalType">Primary 或 Secondary goal。</param>
    private static int GetActionPoint(ActionPlanningData actionPlanningData, ActionPlanningData.ECurrentGoalType goalType)
    {
        return goalType == ActionPlanningData.ECurrentGoalType.Primary
            ? actionPlanningData.PrimaryGoalActionPoint
            : actionPlanningData.SecondaryGoalActionPoint;
    }

    /// <summary>写入指定 goal 的行动点。</summary>
    /// <param name="actionPlanningData">角色的 ActionPlanningData。</param>
    /// <param name="goalType">Primary 或 Secondary goal。</param>
    /// <param name="value">新的行动点。</param>
    private static void SetActionPoint(ActionPlanningData actionPlanningData, ActionPlanningData.ECurrentGoalType goalType, int value)
    {
        if (goalType == ActionPlanningData.ECurrentGoalType.Primary)
        {
            actionPlanningData.PrimaryGoalActionPoint = value;
        }
        else
        {
            actionPlanningData.SecondaryGoalActionPoint = value;
        }
    }

    internal readonly struct OfflineCurrentGoalActionPointState
    {
        // Prefix 是否成功捕获到有效状态。
        public readonly bool IsValid;

        // 原版更新前的行动点。
        public readonly int PreviousActionPoint;

        public OfflineCurrentGoalActionPointState(int previousActionPoint)
        {
            IsValid = true;
            PreviousActionPoint = previousActionPoint;
        }
    }
}

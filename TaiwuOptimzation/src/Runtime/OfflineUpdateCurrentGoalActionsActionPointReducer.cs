using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;

namespace TaiwuOptimization.Runtime;

internal static class OfflineUpdateCurrentGoalActionsActionPointReducer
{
    private const int OriginalMonthlyActionPointGain = 40;
    private const int OriginalActionPointCap = 60;
    private const sbyte TaiwuVillageOrgTemplateId = 16;

    public static OfflineCurrentGoalActionPointState CaptureBeforeOfflineUpdateCurrentGoalActions(Character character, ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsAdvanceMonthOptimizationEnabled())
        {
            return default;
        }

        int previousActionPoint = GetActionPoint(character.ActionPlanningData, goalType);
        return new OfflineCurrentGoalActionPointState(previousActionPoint);
    }

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

    private static bool IsAdvanceMonthOptimizationEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.ReduceRemoteNpcOfflineCurrentGoalActionPointGain &&
        TaiwuOptimizationSettings.RemoteNpcOfflineCurrentGoalActionPointGainReduction > 0;

    private static bool ShouldKeepOriginalActionPointGain(Character character)
    {
        PeriAdvanceMonthProtectionCache.Snapshot protection = PeriAdvanceMonthProtectionCache.GetSnapshot();
        int charId = character.GetId();
        if (protection.IsTaiwuOrGroupMember(charId) ||
            protection.IsDirectlyRelatedToTaiwuGroup(charId) ||
            IsSpecialOrEventCharacter(character) ||
            IsInLiveSyncArea(character, protection) ||
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

    private static bool IsSpecialOrEventCharacter(Character character)
    {
        int charId = character.GetId();
        return character.GetCreatingType() != 1 ||
            DomainManager.Character.IsTemporaryIntelligentCharacter(charId) ||
            DomainManager.Character.IsSpecialGroupMember(character) ||
            character.IsCrossAreaTraveling() ||
            DomainManager.LegendaryBook.IsCharacterActingCrazy(character);
    }

    private static bool IsInLiveSyncArea(Character character, PeriAdvanceMonthProtectionCache.Snapshot protection)
    {
        Location location = character.GetLocation();
        return !location.IsValid() || protection.IsLiveSyncArea(location.AreaId);
    }

    private static bool HasActionTargetInTaiwuGroup(Character character, PeriAdvanceMonthProtectionCache.Snapshot protection)
    {
        ActionPlanningData actionPlanningData = character.ActionPlanningData;
        return protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Primary)) ||
            protection.HasActionTargetInTaiwuGroup(actionPlanningData.GetCurrentAction(ActionPlanningData.ECurrentGoalType.Secondary));
    }

    private static int GetActionPoint(ActionPlanningData actionPlanningData, ActionPlanningData.ECurrentGoalType goalType)
    {
        return goalType == ActionPlanningData.ECurrentGoalType.Primary
            ? actionPlanningData.PrimaryGoalActionPoint
            : actionPlanningData.SecondaryGoalActionPoint;
    }

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
        public readonly bool IsValid;
        public readonly int PreviousActionPoint;

        public OfflineCurrentGoalActionPointState(int previousActionPoint)
        {
            IsValid = true;
            PreviousActionPoint = previousActionPoint;
        }
    }
}

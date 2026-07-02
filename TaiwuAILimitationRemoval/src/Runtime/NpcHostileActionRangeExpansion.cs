using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Utilities;

namespace TaiwuRemoveAILimitation.Runtime;

internal static class NpcHostileActionRangeExpansion
{
    private const string LogTag = "TaiwuRemoveAILimitation";
    private const int ExpandedRangeValue = 2;

    private static readonly int[] HostileActionTemplateIds =
    {
        89, 90, 91, // AttackAction
        100, 101    // PoisonAction / PlotHarmAction
    };

    private static readonly object SyncRoot = new object();
    private static readonly PlanningActionItem?[] OriginalItems = new PlanningActionItem?[102];
    private static bool _isApplied;

    public static bool IsHostileActionWithExpandedRange(int actionTemplateId)
    {
        return actionTemplateId is 89 or 90 or 91 or 100 or 101;
    }

    public static void EnsureApplied()
    {
        if (!TaiwuRemoveAILimitationSettings.EnableNpcActionLimitationRemoval ||
            !TaiwuRemoveAILimitationSettings.EnableHostileActionRangeExpansion)
        {
            Restore();
            return;
        }

        lock (SyncRoot)
        {
            if (_isApplied)
            {
                return;
            }

            foreach (int actionTemplateId in HostileActionTemplateIds)
            {
                PlanningActionItem template = PlanningAction.Instance[actionTemplateId];
                if (template == null)
                {
                    continue;
                }

                OriginalItems[actionTemplateId] = template;
                if (template.CharacterSelectRange == EPlanningActionCharacterSelectRange.BlockRange &&
                    template.SelectRangeValue == ExpandedRangeValue)
                {
                    continue;
                }

                PlanningAction.Instance.AddOrModifyItem(CloneWithRange(
                    template,
                    EPlanningActionCharacterSelectRange.BlockRange,
                    ExpandedRangeValue));
            }

            _isApplied = true;
            if (NpcActionLimitationRemovalLog.Enabled)
            {
                AdaptableLog.TagInfo(LogTag, "Hostile action range expanded: A89/A90/A91/A100/A101 -> BlockRange(2)");
            }
        }
    }

    private static void Restore()
    {
        lock (SyncRoot)
        {
            if (!_isApplied)
            {
                return;
            }

            foreach (int actionTemplateId in HostileActionTemplateIds)
            {
                PlanningActionItem? template = OriginalItems[actionTemplateId];
                if (template != null)
                {
                    PlanningAction.Instance.AddOrModifyItem(template);
                    OriginalItems[actionTemplateId] = null;
                }
            }

            _isApplied = false;
        }
    }

    private static PlanningActionItem CloneWithRange(
        PlanningActionItem template,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        return new PlanningActionItem(
            template.TemplateId,
            template.ImplementationPath,
            template.Parameters,
            template.BehaviorTypeWeights,
            template.PersonalityWeights,
            template.PersonalityType,
            template.ProfessionRequirement,
            template.RequiredOrgMembers,
            template.IsAdultOnly,
            template.IsNonTaiwuTeammate,
            template.IsNonMonk,
            template.LoafChance,
            template.AllowMove,
            template.ActionPointCost,
            template.SelfRestrictions,
            template.Preconditions,
            template.TargetCharacterConditions,
            template.Effects,
            template.DeEffects,
            template.CharacterSelectCountType,
            template.CharacterSelectCountRange,
            template.CharacterSelector,
            template.SelectTaiwuChance,
            range,
            rangeValue,
            template.RefuseAppointment,
            template.MonthlyNotification,
            template.ExecuteSelfLifeRecord,
            template.ExecuteTargetLifeRecord,
            template.ExpChange,
            template.HappinessChange,
            template.FavorabilityChange,
            template.AuthorityChange,
            template.RandomItemRewards,
            template.SelfMatcher,
            template.TargetMatcher,
            template.Cooldown,
            template.CombatType,
            template.KillBaseChance,
            template.KidnapBaseChance,
            template.ReleaseBaseChance);
    }
}

using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class WanGuiYouZhao : TwelveImmortalsBase
{
	private int AddSilenceFrame => base.IsDirect ? 100 : 50;

	private int AddGoneMadInjuryFactor => base.IsDirect ? 100 : (-50);

	public WanGuiYouZhao()
	{
	}

	public WanGuiYouZhao(CombatSkillKey skillKey)
		: base(skillKey, 18011)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_SkillSilenceEnd(OnSkillSilenceEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_SkillSilenceEnd(OnSkillSilenceEnd);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 264, EDataModifyType.AddPercent, -1);
		ShowSpecialEffectTips(0);
	}

	private void OnSkillSilenceEnd(DataContext context, CombatSkillKey skillKey)
	{
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(skillKey.CharId, out var enemyChar) && enemyChar.IsAlly != base.CombatChar.IsAlly)
		{
			DomainManager.Combat.AddGoneMadInjury(context, enemyChar, base.SkillTemplateId, AddGoneMadInjuryFactor);
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId && dataKey.FieldId == 264)
		{
			return AddSilenceFrame;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}

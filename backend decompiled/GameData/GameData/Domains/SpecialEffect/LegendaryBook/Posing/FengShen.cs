using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Posing;

public class FengShen : CombatSkillEffectBase
{
	public FengShen()
	{
		IsLegendaryBookEffect = true;
	}

	public FengShen(CombatSkillKey skillKey)
		: base(skillKey, 40102, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && base.CombatChar.GetAgileSkillList().Exist(base.SkillTemplateId) && DomainManager.Combat.SkillCanUseInCurrCombat(CharObj.GetId(), Config.CombatSkill.Instance[base.SkillTemplateId]))
		{
			DomainManager.Combat.CastAgileOrDefenseWithoutPrepare(base.CombatChar, base.SkillTemplateId);
		}
	}
}

using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class AddDistanceAndAddInjury : CombatSkillEffectBase
{
	private const sbyte AddDistance = 60;

	private const sbyte AffectRequireDistance = 60;

	protected AddDistanceAndAddInjury()
	{
	}

	protected AddDistanceAndAddInjury(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			DomainManager.Combat.ChangeDistance(context, enemyChar, 60, isForced: true);
			if (DomainManager.Combat.GetDistanceRange().max - DomainManager.Combat.GetCurrentDistance() < 60)
			{
				ChangeMobilityValue(context, enemyChar, -enemyChar.GetMobilityValue());
				ClearAffectingAgileSkill(context, enemyChar);
				AddPowerDamageInjury(context, enemyChar, context.Random.CheckPercentProb(50), 1, 0, changeToOld: true);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}

using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class ZhanAoDaoFa : AttackBodyPart
{
	public ZhanAoDaoFa()
	{
	}

	public ZhanAoDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 6204)
	{
		BodyParts = new sbyte[2] { 5, 6 };
		ReverseAddDamagePercent = 45;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility);
		ClearAffectingAgileSkill(context, enemyChar);
		ShowSpecialEffectTips(1);
	}
}

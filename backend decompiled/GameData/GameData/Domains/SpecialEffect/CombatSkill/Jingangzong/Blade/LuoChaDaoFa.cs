using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class LuoChaDaoFa : AttackBodyPart
{
	public LuoChaDaoFa()
	{
	}

	public LuoChaDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 11201)
	{
		BodyParts = new sbyte[1];
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		if (base.CurrEnemyChar.WorsenRandomInjury(context, inner: false))
		{
			ShowSpecialEffectTips(1);
		}
	}
}

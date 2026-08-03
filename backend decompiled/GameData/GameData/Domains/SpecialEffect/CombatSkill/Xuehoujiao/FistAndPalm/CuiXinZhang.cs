using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class CuiXinZhang : AttackBodyPart
{
	public CuiXinZhang()
	{
	}

	public CuiXinZhang(CombatSkillKey skillKey)
		: base(skillKey, 15101)
	{
		BodyParts = new sbyte[1];
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		ShowSpecialEffectTips(1);
		ChangeBreathValue(context, base.CurrEnemyChar, -9000);
	}
}

using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class HanYinZhang : AttackBodyPart
{
	public HanYinZhang()
	{
	}

	public HanYinZhang(CombatSkillKey skillKey)
		: base(skillKey, 8102)
	{
		BodyParts = new sbyte[1] { 1 };
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		if (base.CurrEnemyChar.WorsenRandomInjury(context, inner: true))
		{
			ShowSpecialEffectTips(1);
		}
	}
}

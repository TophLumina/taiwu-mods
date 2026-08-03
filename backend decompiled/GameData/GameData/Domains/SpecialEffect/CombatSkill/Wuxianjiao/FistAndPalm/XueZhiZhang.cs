using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class XueZhiZhang : AttackBodyPart
{
	private const int AbsorbStancePercent = 20;

	public XueZhiZhang()
	{
	}

	public XueZhiZhang(CombatSkillKey skillKey)
		: base(skillKey, 12102)
	{
		BodyParts = new sbyte[1] { 1 };
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		AbsorbStanceValue(context, base.CurrEnemyChar, 20);
		ShowSpecialEffectTips(1);
	}
}

using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Throw;

public class ShiGuLanChangSha : AttackBodyPart
{
	public ShiGuLanChangSha()
	{
	}

	public ShiGuLanChangSha(CombatSkillKey skillKey)
		: base(skillKey, 15402)
	{
		BodyParts = new sbyte[1] { 1 };
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		ShowSpecialEffectTips(1);
		ChangeStanceValue(context, base.CurrEnemyChar, -1200);
	}
}

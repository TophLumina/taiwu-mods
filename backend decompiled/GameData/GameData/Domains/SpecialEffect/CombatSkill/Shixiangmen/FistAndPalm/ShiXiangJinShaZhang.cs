using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class ShiXiangJinShaZhang : AttackBodyPart
{
	private const int RecoverFlawKeepTimePercent = 100;

	public ShiXiangJinShaZhang()
	{
	}

	public ShiXiangJinShaZhang(CombatSkillKey skillKey)
		: base(skillKey, 6104)
	{
		BodyParts = new sbyte[2] { 3, 4 };
		ReverseAddDamagePercent = 45;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		FlawOrAcupointCollection flaw = enemyChar.GetFlawCollection();
		flaw.OfflineRecoverKeepTimePercent(100);
		enemyChar.SetFlawCollection(flaw, context);
		ShowSpecialEffectTips(1);
	}
}

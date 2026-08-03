using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class TaiYiJinDao : AttackBodyPart
{
	private const int RecoverAcupointKeepTimePercent = 100;

	public TaiYiJinDao()
	{
	}

	public TaiYiJinDao(CombatSkillKey skillKey)
		: base(skillKey, 5303)
	{
		BodyParts = new sbyte[2] { 5, 6 };
		ReverseAddDamagePercent = 45;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		FlawOrAcupointCollection acupoint = enemyChar.GetAcupointCollection();
		acupoint.OfflineRecoverKeepTimePercent(100);
		enemyChar.SetAcupointCollection(acupoint, context);
		ShowSpecialEffectTips(1);
	}
}

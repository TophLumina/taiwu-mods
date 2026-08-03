using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Finger;

public class QingJiaoTieXuZhi : AttackBodyPart
{
	private const int RecoverAcupointKeepTimePercent = 100;

	public QingJiaoTieXuZhi()
	{
	}

	public QingJiaoTieXuZhi(CombatSkillKey skillKey)
		: base(skillKey, 10204)
	{
		BodyParts = new sbyte[2] { 3, 4 };
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

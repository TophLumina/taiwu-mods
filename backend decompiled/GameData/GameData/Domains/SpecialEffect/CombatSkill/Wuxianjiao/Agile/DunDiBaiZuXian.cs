using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Agile;

public class DunDiBaiZuXian : CheckHitEffect
{
	private const sbyte ReducePercent = 30;

	public DunDiBaiZuXian()
	{
	}

	public DunDiBaiZuXian(CombatSkillKey skillKey)
		: base(skillKey, 12605)
	{
		CheckHitType = 2;
	}

	protected override bool HitEffect(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		if ((base.IsDirect ? enemyChar.GetAffectingDefendSkillId() : enemyChar.GetAffectingMoveSkillId()) < 0)
		{
			return false;
		}
		int leftPercent = (base.IsDirect ? enemyChar.GetDefendSkillTimePercent() : (enemyChar.GetMobilityValue() * 100 / MoveSpecialConstants.MaxMobility));
		if (leftPercent > 30)
		{
			if (base.IsDirect)
			{
				enemyChar.DefendSkillLeftFrame = (short)(enemyChar.DefendSkillLeftFrame - enemyChar.DefendSkillTotalFrame * 30 / 100);
				enemyChar.SetDefendSkillTimePercent((byte)(enemyChar.DefendSkillLeftFrame * 100 / enemyChar.DefendSkillTotalFrame), context);
			}
			else
			{
				ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility * 30 / 100);
			}
		}
		else if (base.IsDirect)
		{
			DomainManager.Combat.ClearAffectingDefenseSkill(context, enemyChar);
		}
		else
		{
			ClearAffectingAgileSkill(context, enemyChar);
		}
		return true;
	}
}

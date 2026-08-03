using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class ChenRan : AgileSkillBase
{
	private const short SilenceFrame = 300;

	public ChenRan()
	{
	}

	public ChenRan(CombatSkillKey skillKey)
		: base(skillKey, 16210)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && pursueIndex == 0 && attacker == base.CombatChar && base.CanAffect)
		{
			SilenceEnemySkill(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (hit && index <= 2 && context.Attacker == base.CombatChar && base.CanAffect)
		{
			SilenceEnemySkill(context);
		}
	}

	private void SilenceEnemySkill(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		short skillId = enemyChar.GetRandomBanableSkillId(context.Random, null, -1);
		if (skillId >= 0)
		{
			DomainManager.Combat.SilenceSkill(context, enemyChar, skillId, 300);
			ShowSpecialEffectTips(0);
		}
	}
}

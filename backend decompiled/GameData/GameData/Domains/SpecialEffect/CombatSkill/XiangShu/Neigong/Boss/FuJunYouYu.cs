using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class FuJunYouYu : BossNeigongBase
{
	private sbyte AddStatePowerUnit = 25;

	public FuJunYouYu()
	{
	}

	public FuJunYouYu(CombatSkillKey skillKey)
		: base(skillKey, 16111)
	{
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (pursueIndex == 0)
		{
			sbyte hitType = DomainManager.Combat.GetDamageCompareData().HitType[0];
			if (base.CombatChar == attacker && !hit)
			{
				AddCombatState(context, addHit: true, hitType);
			}
			else if (base.CombatChar == defender && hit)
			{
				AddCombatState(context, addHit: false, hitType);
			}
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index <= 2 && hitType >= 0)
		{
			if (base.CombatChar == context.Attacker && !hit)
			{
				AddCombatState(context, addHit: true, hitType);
			}
			else if (base.CombatChar == context.Defender && hit)
			{
				AddCombatState(context, addHit: false, hitType);
			}
		}
	}

	private void AddCombatState(DataContext context, bool addHit, sbyte hitType)
	{
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)((addHit ? 75 : 79) + hitType), AddStatePowerUnit);
		ShowSpecialEffectTips(addHit, 1, 2);
	}
}

using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class JiuGunShiBaDie : DefenseSkillBase
{
	private static readonly CValuePercent ChangeMobilityPercent = 12;

	public JiuGunShiBaDie()
	{
	}

	public JiuGunShiBaDie(CombatSkillKey skillKey)
		: base(skillKey, 5500)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && attacker == base.CombatChar && hit && base.CanAffect)
		{
			CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			int changeMobility = MoveSpecialConstants.MaxMobility * ChangeMobilityPercent;
			ChangeMobilityValue(context, affectChar, base.IsDirect ? changeMobility : (-changeMobility));
			ShowSpecialEffectTips(0);
		}
	}
}

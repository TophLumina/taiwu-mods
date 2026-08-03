using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public class AttackChangeMobility : AgileSkillBase
{
	private static readonly int[] ChangeMobilityPerMille = new int[3] { 30, 45, 60 };

	protected short RequireWeaponSubType;

	protected AttackChangeMobility()
	{
	}

	protected AttackChangeMobility(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
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
		if (base.CanAffect && hit && attacker == base.CombatChar && attacker.GetWeaponData().Template.ItemSubType == RequireWeaponSubType)
		{
			CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			int changeMobility = MoveSpecialConstants.MaxMobility * ChangeMobilityPerMille[base.CombatChar.GetConfigAttackPointCost()] / 1000;
			ChangeMobilityValue(context, affectChar, base.IsDirect ? changeMobility : (-changeMobility));
			ShowSpecialEffectTips(0);
		}
	}
}

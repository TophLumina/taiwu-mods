using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class WeiWoDuZun : AnimalEffectBase
{
	private bool _inAttackRange;

	private CValuePercent CostPercent => base.IsElite ? 66 : 33;

	public WeiWoDuZun()
	{
	}

	public WeiWoDuZun(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		_inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		DoAffect(context);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		bool newInAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		if (newInAttackRange != _inAttackRange)
		{
			_inAttackRange = newInAttackRange;
			DoAffect(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		if (base.IsCurrent)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			ChangeStanceValue(context, enemyChar, -enemyChar.GetMaxStanceValue() * CostPercent);
			ChangeBreathValue(context, enemyChar, -enemyChar.GetMaxBreathValue() * CostPercent);
			ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility * CostPercent);
			ShowSpecialEffectTips(0);
		}
	}
}

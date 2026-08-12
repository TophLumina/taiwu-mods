using System.Collections.Generic;

namespace GameData.Combat.Cricket.SkillsImplement;

public class HalfFallenAddProperty(CricketCombatData owner) : CricketCombatSkillBase(owner)
{
	private readonly IReadOnlyList<ECricketCombatPropertyType> _targetProperties = new ECricketCombatPropertyType[9]
	{
		ECricketCombatPropertyType.Vigor,
		ECricketCombatPropertyType.Strength,
		ECricketCombatPropertyType.Bite,
		ECricketCombatPropertyType.Deadliness,
		ECricketCombatPropertyType.Damage,
		ECricketCombatPropertyType.Cripple,
		ECricketCombatPropertyType.Defense,
		ECricketCombatPropertyType.DamageReduce,
		ECricketCombatPropertyType.Counter
	};

	private bool _invoked;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.HalfFallenAddProperty;

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.DoDamage || _invoked || !Owner.IsHalfFail)
		{
			return false;
		}
		_invoked = true;
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		foreach (ECricketCombatPropertyType property in _targetProperties)
		{
			AddModifyPercent(context, ECricketCombatPropertyModifyLifeCycle.Combat, property, 50);
		}
	}
}

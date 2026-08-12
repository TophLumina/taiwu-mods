using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public abstract class LoongBase : AnimalEffectBase
{
	private List<ISpecialEffectImplement> _implements;

	protected abstract IEnumerable<ISpecialEffectImplement> Implements { get; }

	protected LoongBase()
	{
		CreateImplements();
	}

	protected LoongBase(CombatSkillKey skillKey)
		: base(skillKey)
	{
		CreateImplements();
	}

	private void CreateImplements()
	{
		_implements = new List<ISpecialEffectImplement>(Implements);
		foreach (ISpecialEffectImplement implement in _implements)
		{
			implement.EffectBase = this;
		}
	}

	public override void OnEnable(DataContext context)
	{
		foreach (ISpecialEffectImplement implement in _implements)
		{
			implement.OnEnable(context);
		}
	}

	public override void OnDisable(DataContext context)
	{
		foreach (ISpecialEffectImplement implement in _implements)
		{
			implement.OnDisable(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return _implements.Sum((ISpecialEffectImplement implement) => implement.GetModifyValue(dataKey, currModifyValue));
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		dataValue = base.GetModifiedValue(dataKey, dataValue);
		return _implements.Aggregate(dataValue, (bool current, ISpecialEffectImplement implement) => implement.GetModifiedValue(dataKey, current));
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		return _implements.Aggregate(dataValue, (int current, ISpecialEffectImplement implement) => implement.GetModifiedValue(dataKey, current));
	}
}

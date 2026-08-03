using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class ReduceMainAttribute : CombatSkillEffectBase
{
	private const int ReduceFrame = 120;

	private const int ReduceValue = -3;

	protected abstract bool IsAffect { get; }

	protected abstract sbyte MainAttributeType { get; }

	protected short CurrMainAttribute => CharObj.GetCurrMainAttribute(MainAttributeType);

	protected ReduceMainAttribute()
	{
	}

	protected ReduceMainAttribute(CombatSkillKey skillKey, int type = -1)
		: base(skillKey, type, -1)
	{
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 120;
	}

	public override bool IsOn(int counterType)
	{
		return IsAffect;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		if (base.CombatChar.GetCharacter().GetCurrMainAttribute(MainAttributeType) > 0)
		{
			base.CombatChar.GetCharacter().ChangeCurrMainAttribute(context, MainAttributeType, -3);
		}
	}
}

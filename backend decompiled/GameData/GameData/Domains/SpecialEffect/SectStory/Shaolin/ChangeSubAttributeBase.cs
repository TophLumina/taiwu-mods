using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public abstract class ChangeSubAttributeBase : DemonSlayerTrialEffectBase
{
	private readonly CValuePercentBonus _reduceBonus;

	protected abstract IReadOnlyList<ushort> SubAttributes { get; }

	protected ChangeSubAttributeBase(int charId, IReadOnlyList<int> parameters)
		: base(charId)
	{
		_reduceBonus = -parameters[0];
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		foreach (ushort fieldId in SubAttributes)
		{
			CreateAffectedData(fieldId, EDataModifyType.Custom, -1);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (SubAttributes.Contains(dataKey.FieldId))
		{
			return dataValue * _reduceBonus;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}

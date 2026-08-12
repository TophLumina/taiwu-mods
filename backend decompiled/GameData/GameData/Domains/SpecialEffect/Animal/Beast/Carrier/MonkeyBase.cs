using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public abstract class MonkeyBase : CombatStateEffectBase
{
	protected abstract int PowerAddOrReduceRatio { get; }

	protected MonkeyBase()
	{
	}

	protected MonkeyBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 256, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 257, -1), EDataModifyType.TotalPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			256 => PowerAddOrReduceRatio, 
			257 => -PowerAddOrReduceRatio, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}

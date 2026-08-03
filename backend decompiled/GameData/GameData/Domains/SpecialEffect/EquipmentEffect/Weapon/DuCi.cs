using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon;

public class DuCi : EquipmentEffectBase
{
	private const sbyte AddPercent = 33;

	public DuCi()
	{
	}

	public DuCi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30017)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 73, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam2 != EquipItemKey.Id)
		{
			return 0;
		}
		if (dataKey.FieldId == 73)
		{
			return 33;
		}
		return 0;
	}
}

using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceBounceDamage;

public class HuaQi : EquipmentEffectBase
{
	private const sbyte ReducePercent = -50;

	public HuaQi()
	{
	}

	public HuaQi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30014)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 103, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 104, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam0 != 1 || !IsCurrWeapon())
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 103) <= 1u)
		{
			return -50;
		}
		return 0;
	}
}

using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.BreakReduceInjury;

public class HuQi : EquipmentEffectBase
{
	private const sbyte ReduceDamagePercent = -25;

	public HuQi()
	{
	}

	public HuQi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30116)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || base.CombatChar.NeedReduceArmorDurability <= 0 || dataKey.CustomParam0 != 1 || !IsCurrArmor((sbyte)dataKey.CustomParam1))
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			return 25;
		}
		return 0;
	}
}

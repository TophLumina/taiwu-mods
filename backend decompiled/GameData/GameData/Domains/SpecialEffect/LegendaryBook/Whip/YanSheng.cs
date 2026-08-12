using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Whip;

public class YanSheng : EquipmentEffectBase
{
	private const sbyte AddAttackRange = 10;

	public YanSheng()
	{
	}

	public YanSheng(int charId, ItemKey itemKey)
		: base(charId, itemKey, 41100, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 29, -1), EDataModifyType.Add);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam2 != EquipItemKey.Id)
		{
			return 0;
		}
		if (dataKey.FieldId == 29)
		{
			return 10;
		}
		return 0;
	}
}

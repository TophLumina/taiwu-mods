using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Throw;

public class AnSha : EquipmentEffectBase
{
	public AnSha()
	{
	}

	public AnSha(int charId, ItemKey itemKey)
		: base(charId, itemKey, 40600, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 280, -1), EDataModifyType.Custom);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsCurrWeapon())
		{
			return dataValue;
		}
		if (dataKey.FieldId == 280)
		{
			return true;
		}
		return dataValue;
	}
}

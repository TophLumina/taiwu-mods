using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.AddBounceDamage;

public class ZhenXue : EquipmentEffectBase
{
	private const sbyte AddPercent = 50;

	public ZhenXue()
	{
	}

	public ZhenXue(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30113)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 70, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 71, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CustomParam0 != 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 70 && !IsCurrArmor((sbyte)dataKey.CustomParam1))
		{
			return 0;
		}
		if (dataKey.FieldId == 71 && !IsCurrArmor(base.CombatChar.FightBackSourceBodyPart))
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 70) <= 1u)
		{
			return 50;
		}
		return 0;
	}
}

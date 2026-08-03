using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class ShanHeShenJie : RawCreateEquipmentBase
{
	private static CValuePercent ReplacementLossPercent => 50;

	protected override int ReduceDurabilityValue => 4;

	public ShanHeShenJie()
	{
	}

	public ShanHeShenJie(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30201)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(307, EDataModifyType.Custom, -1);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 307 || !base.CanAffect)
		{
			return dataValue;
		}
		ItemKey changingKey = base.CombatChar.ChangingDurabilityItems.Peek();
		if (base.CombatChar.GetRawCreateCollection().EffectEquals(changingKey, EquipItemKey))
		{
			return dataValue;
		}
		sbyte itemType = changingKey.ItemType;
		if ((uint)itemType > 2u)
		{
			return dataValue;
		}
		int replacementValue = dataValue * ReplacementLossPercent;
		if (replacementValue >= 0)
		{
			return dataValue;
		}
		dataValue -= replacementValue;
		DataContext context = DomainManager.Combat.Context;
		ChangeDurability(context, base.CombatChar, EquipItemKey, replacementValue);
		return dataValue;
	}
}

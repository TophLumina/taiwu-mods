using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public abstract class RawCreateEquipmentBase : EquipmentEffectBase
{
	private const int ReduceDurabilityFrame = 600;

	protected bool CanAffect => base.CombatChar.GetRawCreateCollection().Contains(EquipItemKey);

	protected abstract int ReduceDurabilityValue { get; }

	protected RawCreateEquipmentBase()
	{
	}

	protected RawCreateEquipmentBase(int charId, ItemKey itemKey, int type)
		: base(charId, itemKey, type)
	{
		EquipItemKey = itemKey;
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 600;
	}

	public override bool IsOn(int counterType)
	{
		return CanAffect;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		if (counterType == 0)
		{
			ChangeDurability(context, base.CombatChar, EquipItemKey, -ReduceDurabilityValue);
			ItemBase baseItem = DomainManager.Item.GetBaseItem(EquipItemKey);
			if (baseItem.GetCurrDurability() <= 0)
			{
				base.CombatChar.RevertRawCreate(context, EquipItemKey);
			}
		}
	}
}

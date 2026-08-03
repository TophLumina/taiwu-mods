using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class HunYuanShenZhu : RawCreateEquipmentBase
{
	protected override int ReduceDurabilityValue => 12;

	public HunYuanShenZhu()
	{
	}

	public HunYuanShenZhu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30205)
	{
	}
}

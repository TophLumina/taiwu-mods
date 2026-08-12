using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiZhang : ReduceHitBase
{
	public PiZhang()
	{
	}

	public PiZhang(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30100)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 4;
	}
}

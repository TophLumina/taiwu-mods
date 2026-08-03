using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiDao : ReduceHitBase
{
	public PiDao()
	{
	}

	public PiDao(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30102)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 9;
	}
}

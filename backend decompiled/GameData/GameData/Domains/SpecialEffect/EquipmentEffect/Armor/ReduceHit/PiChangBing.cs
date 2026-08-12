using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiChangBing : ReduceHitBase
{
	public PiChangBing()
	{
	}

	public PiChangBing(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30104)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 10;
	}
}

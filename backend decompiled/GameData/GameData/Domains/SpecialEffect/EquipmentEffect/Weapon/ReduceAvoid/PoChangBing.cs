using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoChangBing : ReduceAvoidBase
{
	public PoChangBing()
	{
	}

	public PoChangBing(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30004)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 10;
	}
}

using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoAnQi : ReduceAvoidBase
{
	public PoAnQi()
	{
	}

	public PoAnQi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30006)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if (weaponSubType == 0 || weaponSubType == 2 || weaponSubType == 12)
		{
			return true;
		}
		return false;
	}
}

using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoMoYin : ReduceAvoidBase
{
	public PoMoYin()
	{
	}

	public PoMoYin(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30008)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if (weaponSubType == 3 || weaponSubType == 11)
		{
			return true;
		}
		return false;
	}
}

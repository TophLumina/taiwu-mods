using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoQiMen : ReduceAvoidBase
{
	public PoQiMen()
	{
	}

	public PoQiMen(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30007)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if (weaponSubType == 1 || weaponSubType == 5 || weaponSubType == 13)
		{
			return true;
		}
		return false;
	}
}

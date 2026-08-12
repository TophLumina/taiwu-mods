using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiQiMen : ReduceHitBase
{
	public PiQiMen()
	{
	}

	public PiQiMen(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30107)
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

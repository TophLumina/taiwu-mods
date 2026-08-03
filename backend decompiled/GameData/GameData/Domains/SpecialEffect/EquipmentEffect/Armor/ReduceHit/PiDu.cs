using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiDu : ReduceHitBase
{
	public PiDu()
	{
	}

	public PiDu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30103)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if ((uint)(weaponSubType - 14) <= 1u)
		{
			return true;
		}
		return false;
	}
}

using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiAnQi : ReduceHitBase
{
	public PiAnQi()
	{
	}

	public PiAnQi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30106)
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

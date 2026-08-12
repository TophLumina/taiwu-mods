using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiJian : ReduceHitBase
{
	public PiJian()
	{
	}

	public PiJian(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30101)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 8;
	}
}

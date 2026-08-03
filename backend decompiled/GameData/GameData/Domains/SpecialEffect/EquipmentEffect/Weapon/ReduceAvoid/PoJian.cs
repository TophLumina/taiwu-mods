using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoJian : ReduceAvoidBase
{
	public PoJian()
	{
	}

	public PoJian(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30001)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 8;
	}
}

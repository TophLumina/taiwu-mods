using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoDao : ReduceAvoidBase
{
	public PoDao()
	{
	}

	public PoDao(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30002)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 9;
	}
}

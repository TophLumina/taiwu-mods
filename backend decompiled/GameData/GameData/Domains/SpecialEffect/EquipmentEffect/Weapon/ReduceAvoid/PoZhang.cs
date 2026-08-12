using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoZhang : ReduceAvoidBase
{
	public PoZhang()
	{
	}

	public PoZhang(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30000)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		return weaponSubType == 4;
	}
}

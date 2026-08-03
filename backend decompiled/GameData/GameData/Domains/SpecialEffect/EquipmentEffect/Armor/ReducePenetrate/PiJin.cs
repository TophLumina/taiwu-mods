using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;

public class PiJin : ReducePenetrateBase
{
	public PiJin()
	{
	}

	public PiJin(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30109)
	{
		RequireWeaponResourceType = 2;
	}
}

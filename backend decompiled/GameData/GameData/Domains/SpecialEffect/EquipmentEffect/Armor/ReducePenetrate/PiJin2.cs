using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;

public class PiJin2 : ReducePenetrateBase
{
	public PiJin2()
	{
	}

	public PiJin2(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30112)
	{
		RequireWeaponResourceType = 4;
	}
}

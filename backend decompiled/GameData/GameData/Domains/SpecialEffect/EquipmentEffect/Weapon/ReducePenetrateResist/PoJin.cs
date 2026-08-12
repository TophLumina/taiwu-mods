using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;

public class PoJin : ReducePenetrateResistBase
{
	public PoJin()
	{
	}

	public PoJin(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30009)
	{
		RequireArmorResourceType = 2;
	}
}

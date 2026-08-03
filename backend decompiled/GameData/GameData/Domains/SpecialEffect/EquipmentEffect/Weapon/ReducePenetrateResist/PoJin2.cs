using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;

public class PoJin2 : ReducePenetrateResistBase
{
	public PoJin2()
	{
	}

	public PoJin2(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30012)
	{
		RequireArmorResourceType = 4;
	}
}

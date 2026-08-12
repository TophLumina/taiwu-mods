using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;

public class PoMu : ReducePenetrateResistBase
{
	public PoMu()
	{
	}

	public PoMu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30010)
	{
		RequireArmorResourceType = 1;
	}
}

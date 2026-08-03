using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;

public class PoYu : ReducePenetrateResistBase
{
	public PoYu()
	{
	}

	public PoYu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30011)
	{
		RequireArmorResourceType = 3;
	}
}

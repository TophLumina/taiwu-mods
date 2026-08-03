using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;

public class PiMu : ReducePenetrateBase
{
	public PiMu()
	{
	}

	public PiMu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30110)
	{
		RequireWeaponResourceType = 1;
	}
}

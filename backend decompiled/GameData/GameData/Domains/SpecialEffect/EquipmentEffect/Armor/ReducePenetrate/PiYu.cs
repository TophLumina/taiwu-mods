using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;

public class PiYu : ReducePenetrateBase
{
	public PiYu()
	{
	}

	public PiYu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30111)
	{
		RequireWeaponResourceType = 3;
	}
}

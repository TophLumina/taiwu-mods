using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoRuanBing : ReduceAvoidBase
{
	public PoRuanBing()
	{
	}

	public PoRuanBing(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30005)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if ((uint)(weaponSubType - 6) <= 1u)
		{
			return true;
		}
		return false;
	}
}

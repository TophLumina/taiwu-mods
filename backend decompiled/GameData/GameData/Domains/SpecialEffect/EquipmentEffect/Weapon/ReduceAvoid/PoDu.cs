using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public class PoDu : ReduceAvoidBase
{
	public PoDu()
	{
	}

	public PoDu(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30003)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if ((uint)(weaponSubType - 14) <= 1u)
		{
			return true;
		}
		return false;
	}
}

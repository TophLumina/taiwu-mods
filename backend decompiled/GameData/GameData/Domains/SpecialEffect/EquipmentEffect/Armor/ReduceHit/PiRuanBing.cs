using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiRuanBing : ReduceHitBase
{
	public PiRuanBing()
	{
	}

	public PiRuanBing(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30105)
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

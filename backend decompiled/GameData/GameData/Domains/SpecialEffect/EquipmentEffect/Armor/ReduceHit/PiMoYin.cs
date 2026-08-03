using GameData.Combat.Math;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public class PiMoYin : ReduceHitBase
{
	protected override bool RequireIsCurrArmor => false;

	protected override EDataModifyType ModifyType => EDataModifyType.TotalPercent;

	public PiMoYin()
	{
	}

	public PiMoYin(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30108)
	{
	}

	protected override bool IsRequireWeaponSubType(short weaponSubType)
	{
		if (weaponSubType == 3 || weaponSubType == 11)
		{
			return true;
		}
		return false;
	}
}

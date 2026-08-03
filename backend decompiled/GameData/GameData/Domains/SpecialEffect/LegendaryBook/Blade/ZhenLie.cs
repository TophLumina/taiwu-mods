using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Blade;

public class ZhenLie : EquipmentEffectBase
{
	private const int DirectDamageAddPercent = 33;

	public ZhenLie()
	{
	}

	public ZhenLie(int charId, ItemKey itemKey)
		: base(charId, itemKey, 40800, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || !IsCurrWeapon())
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return (dataKey.CustomParam2 == 1) ? 33 : base.GetModifyValue(dataKey, currModifyValue);
	}
}

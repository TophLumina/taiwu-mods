using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Sword;

public class HuaXi : EquipmentEffectBase
{
	private const int AddPursueOdds = 200;

	public HuaXi()
	{
	}

	public HuaXi(int charId, ItemKey itemKey)
		: base(charId, itemKey, 40700, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(76, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 76 || !IsCurrWeapon())
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return (dataKey.CustomParam1 == 1) ? 200 : 0;
	}
}

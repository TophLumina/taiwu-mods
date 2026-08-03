using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Weapon;

public class YeXing : MasteryWeaponBase
{
	public YeXing()
	{
	}

	public YeXing(int charId, int itemId)
		: base(charId, itemId, 1789)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(313, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 313 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		int itemId = dataKey.CustomParam0;
		if (itemId != ItemId)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return 100;
	}
}

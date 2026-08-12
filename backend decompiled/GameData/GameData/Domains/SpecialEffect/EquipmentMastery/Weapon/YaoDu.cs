using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Weapon;

public class YaoDu : MasteryWeaponBase
{
	public YaoDu()
	{
	}

	public YaoDu(int charId, int itemId)
		: base(charId, itemId, 1784)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(73, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 73 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		if (dataKey.CustomParam1 != 1)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTips(0);
		return 33;
	}
}

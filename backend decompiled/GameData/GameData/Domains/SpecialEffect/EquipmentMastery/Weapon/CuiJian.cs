using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Weapon;

public class CuiJian : MasteryWeaponBase
{
	public CuiJian()
	{
	}

	public CuiJian(int charId, int itemId)
		: base(charId, itemId, 1785)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTips(0);
		return 33;
	}
}

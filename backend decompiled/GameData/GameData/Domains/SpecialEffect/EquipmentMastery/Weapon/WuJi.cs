using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Weapon;

public class WuJi : MasteryWeaponBase
{
	public WuJi()
	{
	}

	public WuJi(int charId, int itemId)
		: base(charId, itemId, 1788)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(32, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(33, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(34, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(35, EDataModifyType.TotalPercent, -1);
	}

	protected override void OnAffectingChanged(DataContext context)
	{
		base.OnAffectingChanged(context);
		InvalidateAllAffectDataCache(context);
		if (base.Affecting)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId || !base.Affecting;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 32) <= 3u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 50;
	}
}

using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Armor;

public class WuChen : MasteryArmorBase
{
	public WuChen()
	{
	}

	public WuChen(int charId, int itemId)
		: base(charId, itemId, 1796)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(38, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(39, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(40, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(41, EDataModifyType.TotalPercent, -1);
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
			bool flag3 = (uint)(fieldId - 38) <= 3u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 50;
	}
}

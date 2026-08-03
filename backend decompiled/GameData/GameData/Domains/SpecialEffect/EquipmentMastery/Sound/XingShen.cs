using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Sound;

public class XingShen : MasteryWeaponBase
{
	public XingShen()
	{
	}

	public XingShen(int charId, int itemId)
		: base(charId, itemId, 1791)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(274, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 274 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTips(0);
		return 33;
	}
}

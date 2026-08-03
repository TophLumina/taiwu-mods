using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Sound;

public class QingYou : MasteryWeaponBase
{
	protected override bool CheckAffectOdds => false;

	public QingYou()
	{
	}

	public QingYou(int charId, int itemId)
		: base(charId, itemId, 1792)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(336, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 336 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTips(0);
		return CMath.SumPercentOdds(currModifyValue, CalcAffectOdds());
	}
}

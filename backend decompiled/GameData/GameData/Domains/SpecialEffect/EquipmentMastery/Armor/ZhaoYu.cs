using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Armor;

public class ZhaoYu : MasteryArmorBase
{
	protected override bool CheckAffectOdds => false;

	public ZhaoYu()
	{
	}

	public ZhaoYu(int charId, int itemId)
		: base(charId, itemId, 1795)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(337, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 337 || !base.Affecting)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		int srcItemId = dataKey.CustomParam0;
		if (srcItemId != ItemId)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		IRandomSource random = DomainManager.Combat.Context.Random;
		int addValue = MasteryConstants.JadeAffectOdds.Count((int jadeAffectOdd) => CheckAffect(random, jadeAffectOdd));
		if (addValue > 0)
		{
			ShowSpecialEffectTips(0);
		}
		return addValue;
	}
}

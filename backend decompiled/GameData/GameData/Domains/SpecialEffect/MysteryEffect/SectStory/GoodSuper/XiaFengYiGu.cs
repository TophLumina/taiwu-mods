using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Map;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;

public class XiaFengYiGu : MysteryEffectBase
{
	private const int RequireSpiritualDebt = 1000;

	private const int SpiritualDebtUnit = 100;

	private const int MaxAddPercent = 33;

	private int _addPercent;

	protected override short SpecialEffectId => 1769;

	private static int CalcAddPercent(Location location)
	{
		if (!location.IsValid())
		{
			return 0;
		}
		int spiritualDebt = DomainManager.Extra.GetAreaSpiritualDebt(location.AreaId);
		if (spiritualDebt < 1000)
		{
			return 0;
		}
		return Math.Min(spiritualDebt / 100, 33);
	}

	public XiaFengYiGu()
	{
	}

	public XiaFengYiGu(int charId, int itemId)
		: base(charId, itemId, 50101)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		for (int i = 0; i < 4; i++)
		{
			CreateAffectedData((ushort)(32 + i), EDataModifyType.AddPercent, -1);
			CreateAffectedData((ushort)(38 + i), EDataModifyType.AddPercent, -1);
		}
		AutoMonitor(ParseCharDataUid(55), Update);
		AutoMonitor(new DataUid(2, 56, ulong.MaxValue), Update);
		AutoMonitor(new DataUid(19, 145, ulong.MaxValue), Update);
		Update(context, default(DataUid));
	}

	private void Update(DataContext context, DataUid uid)
	{
		Location location = (CharObj.IsTaiwu() ? CharObj.GetValidLocation() : CharObj.GetLocation());
		int addPercent = CalcAddPercent(location);
		if (addPercent != _addPercent)
		{
			_addPercent = addPercent;
			InvalidateAllAffectDataCache(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId)
		{
			return _addPercent;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}

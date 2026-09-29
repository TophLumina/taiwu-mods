using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryEventEffect : ConfigData<SettlementTreasuryEventEffectItem, short>
{
	public static class DefKey
	{
		public const short IntrudeSectTreasuryLow = 0;

		public const short IntrudeSectTreasuryMid = 1;

		public const short IntrudeSectTreasuryHigh = 2;

		public const short PlunderSectTreasury = 3;

		public const short DonateSectTreasury = 4;

		public const short IntrudeTownTreasury = 5;

		public const short PlunderTownrTreasury = 6;

		public const short DonateTownTreasury = 7;
	}

	public static class DefValue
	{
		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryLow => Instance[(short)0];

		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryMid => Instance[(short)1];

		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryHigh => Instance[(short)2];

		public static SettlementTreasuryEventEffectItem PlunderSectTreasury => Instance[(short)3];

		public static SettlementTreasuryEventEffectItem DonateSectTreasury => Instance[(short)4];

		public static SettlementTreasuryEventEffectItem IntrudeTownTreasury => Instance[(short)5];

		public static SettlementTreasuryEventEffectItem PlunderTownrTreasury => Instance[(short)6];

		public static SettlementTreasuryEventEffectItem DonateTownTreasury => Instance[(short)7];
	}

	public static SettlementTreasuryEventEffect Instance = new SettlementTreasuryEventEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TaiwuBounty", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SettlementTreasuryEventEffectItem(0, 100, 0, 1, -30000, 0, 100, 0, 100, 30, 0, 1, -15000, 0, 30, 0, 30, 0, 0, 165, 3));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(1, 100, 0, 1, -30000, 0, 100, 0, 100, 60, 0, 1, -15000, 0, 60, 0, 60, 0, 0, 166, 6));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(2, 100, 0, 1, -30000, 0, 100, 0, 100, 90, 0, 1, -15000, 0, 90, 0, 90, 0, 0, 167, 12));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(3, 67, 34, 1, 0, -50, 100, 0, 100, 0, 34, 1, 0, -50, 50, 0, 50, 0, 0, -1, 0));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(4, 0, 34, 0, 0, 50, 0, 50, 0, 0, 17, 0, 0, 25, 0, 25, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(5, 0, 0, 0, 0, 0, 0, 0, 0, 34, 0, 1, -15000, 0, 0, 0, 50, -300, 0, -1, 0));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 34, 1, 0, -50, 0, 0, 50, 0, -300, -1, 0));
		_dataArray.Add(new SettlementTreasuryEventEffectItem(7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 0, 25, 0, 0, 0, 0, 300, -1, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SettlementTreasuryEventEffectItem>(8);
		CreateItems0();
	}
}

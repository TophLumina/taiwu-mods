using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryEventEffect : ConfigData<SettlementTreasuryEventEffectItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 擅闯门派库房0
		/// </summary>
		public const short IntrudeSectTreasuryLow = 0;

		/// <summary>
		/// 擅闯门派库房1
		/// </summary>
		public const short IntrudeSectTreasuryMid = 1;

		/// <summary>
		/// 擅闯门派库房2
		/// </summary>
		public const short IntrudeSectTreasuryHigh = 2;

		/// <summary>
		/// 掠夺门派库房
		/// </summary>
		public const short PlunderSectTreasury = 3;

		/// <summary>
		/// 赠予门派库房
		/// </summary>
		public const short DonateSectTreasury = 4;

		/// <summary>
		/// 擅闯城镇库房
		/// </summary>
		public const short IntrudeTownTreasury = 5;

		/// <summary>
		/// 掠夺城镇库房
		/// </summary>
		public const short PlunderTownrTreasury = 6;

		/// <summary>
		/// 赠予城镇库房
		/// </summary>
		public const short DonateTownTreasury = 7;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 擅闯门派库房0
		/// </summary>
		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryLow => Instance[(short)0];

		/// <summary>
		/// 擅闯门派库房1
		/// </summary>
		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryMid => Instance[(short)1];

		/// <summary>
		/// 擅闯门派库房2
		/// </summary>
		public static SettlementTreasuryEventEffectItem IntrudeSectTreasuryHigh => Instance[(short)2];

		/// <summary>
		/// 掠夺门派库房
		/// </summary>
		public static SettlementTreasuryEventEffectItem PlunderSectTreasury => Instance[(short)3];

		/// <summary>
		/// 赠予门派库房
		/// </summary>
		public static SettlementTreasuryEventEffectItem DonateSectTreasury => Instance[(short)4];

		/// <summary>
		/// 擅闯城镇库房
		/// </summary>
		public static SettlementTreasuryEventEffectItem IntrudeTownTreasury => Instance[(short)5];

		/// <summary>
		/// 掠夺城镇库房
		/// </summary>
		public static SettlementTreasuryEventEffectItem PlunderTownrTreasury => Instance[(short)6];

		/// <summary>
		/// 赠予城镇库房
		/// </summary>
		public static SettlementTreasuryEventEffectItem DonateTownTreasury => Instance[(short)7];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldResource : ConfigData<WorldResourceItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 地块资源初始量
		/// </summary>
		public const byte BlockResourceInit = 0;

		/// <summary>
		/// 地块资源恢复量
		/// </summary>
		public const byte BlockResourceRecov = 1;

		/// <summary>
		/// 资源采集获取
		/// </summary>
		public const byte CollectionResource = 2;

		/// <summary>
		/// 主动采集收获
		/// </summary>
		public const byte TaiwuCollectionResource = 3;

		/// <summary>
		/// 太吾村资源产出
		/// </summary>
		public const byte TaiwuVillageResource = 4;

		/// <summary>
		/// 太吾村银钱威望产出
		/// </summary>
		public const byte TaiwuVillageMoneyPrestige = 5;

		/// <summary>
		/// 太吾村售卖比例
		/// </summary>
		public const byte TaiwuVillageSales = 6;

		/// <summary>
		/// 八方鼎力收入
		/// </summary>
		public const byte AssistIncome = 7;

		/// <summary>
		/// 奇遇地格产出
		/// </summary>
		public const byte AdventureBlockRevenue = 8;

		/// <summary>
		/// 奇遇事件产出
		/// </summary>
		public const byte AdventureEventRevenue = 9;

		/// <summary>
		/// 拆解物品获取
		/// </summary>
		public const byte DismantlingRevenue = 10;

		/// <summary>
		/// 商店售货比例
		/// </summary>
		public const byte ShopSalesRate = 11;

		/// <summary>
		/// 人物持有资源
		/// </summary>
		public const byte CharacterResource = 12;

		/// <summary>
		/// 库房补充资源
		/// </summary>
		public const byte TreasuryResupply = 13;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 地块资源初始量
		/// </summary>
		public static WorldResourceItem BlockResourceInit => Instance[(byte)0];

		/// <summary>
		/// 地块资源恢复量
		/// </summary>
		public static WorldResourceItem BlockResourceRecov => Instance[(byte)1];

		/// <summary>
		/// 资源采集获取
		/// </summary>
		public static WorldResourceItem CollectionResource => Instance[(byte)2];

		/// <summary>
		/// 主动采集收获
		/// </summary>
		public static WorldResourceItem TaiwuCollectionResource => Instance[(byte)3];

		/// <summary>
		/// 太吾村资源产出
		/// </summary>
		public static WorldResourceItem TaiwuVillageResource => Instance[(byte)4];

		/// <summary>
		/// 太吾村银钱威望产出
		/// </summary>
		public static WorldResourceItem TaiwuVillageMoneyPrestige => Instance[(byte)5];

		/// <summary>
		/// 太吾村售卖比例
		/// </summary>
		public static WorldResourceItem TaiwuVillageSales => Instance[(byte)6];

		/// <summary>
		/// 八方鼎力收入
		/// </summary>
		public static WorldResourceItem AssistIncome => Instance[(byte)7];

		/// <summary>
		/// 奇遇地格产出
		/// </summary>
		public static WorldResourceItem AdventureBlockRevenue => Instance[(byte)8];

		/// <summary>
		/// 奇遇事件产出
		/// </summary>
		public static WorldResourceItem AdventureEventRevenue => Instance[(byte)9];

		/// <summary>
		/// 拆解物品获取
		/// </summary>
		public static WorldResourceItem DismantlingRevenue => Instance[(byte)10];

		/// <summary>
		/// 商店售货比例
		/// </summary>
		public static WorldResourceItem ShopSalesRate => Instance[(byte)11];

		/// <summary>
		/// 人物持有资源
		/// </summary>
		public static WorldResourceItem CharacterResource => Instance[(byte)12];

		/// <summary>
		/// 库房补充资源
		/// </summary>
		public static WorldResourceItem TreasuryResupply => Instance[(byte)13];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static WorldResource Instance = new WorldResource();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new WorldResourceItem(0, new short[4] { 100, 75, 50, 25 }));
		_dataArray.Add(new WorldResourceItem(1, new short[4] { 100, 75, 50, 25 }));
		_dataArray.Add(new WorldResourceItem(2, new short[4] { 150, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(3, new short[4] { 200, 150, 100, 50 }));
		_dataArray.Add(new WorldResourceItem(4, new short[4] { 150, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(5, new short[4] { 150, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(6, new short[4] { 125, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(7, new short[4] { 150, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(8, new short[4] { 200, 150, 100, 50 }));
		_dataArray.Add(new WorldResourceItem(9, new short[4] { 200, 150, 100, 50 }));
		_dataArray.Add(new WorldResourceItem(10, new short[4] { 125, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(11, new short[4] { 125, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(12, new short[4] { 150, 100, 75, 50 }));
		_dataArray.Add(new WorldResourceItem(13, new short[4] { 150, 100, 75, 50 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WorldResourceItem>(14);
		CreateItems0();
	}
}

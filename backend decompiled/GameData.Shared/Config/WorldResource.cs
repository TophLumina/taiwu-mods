using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldResource : ConfigData<WorldResourceItem, byte>
{
	public static class DefKey
	{
		public const byte BlockResourceInit = 0;

		public const byte BlockResourceRecov = 1;

		public const byte CollectionResource = 2;

		public const byte TaiwuCollectionResource = 3;

		public const byte TaiwuVillageResource = 4;

		public const byte TaiwuVillageMoneyPrestige = 5;

		public const byte TaiwuVillageSales = 6;

		public const byte AssistIncome = 7;

		public const byte AdventureBlockRevenue = 8;

		public const byte AdventureEventRevenue = 9;

		public const byte DismantlingRevenue = 10;

		public const byte ShopSalesRate = 11;

		public const byte CharacterResource = 12;

		public const byte TreasuryResupply = 13;
	}

	public static class DefValue
	{
		public static WorldResourceItem BlockResourceInit => Instance[(byte)0];

		public static WorldResourceItem BlockResourceRecov => Instance[(byte)1];

		public static WorldResourceItem CollectionResource => Instance[(byte)2];

		public static WorldResourceItem TaiwuCollectionResource => Instance[(byte)3];

		public static WorldResourceItem TaiwuVillageResource => Instance[(byte)4];

		public static WorldResourceItem TaiwuVillageMoneyPrestige => Instance[(byte)5];

		public static WorldResourceItem TaiwuVillageSales => Instance[(byte)6];

		public static WorldResourceItem AssistIncome => Instance[(byte)7];

		public static WorldResourceItem AdventureBlockRevenue => Instance[(byte)8];

		public static WorldResourceItem AdventureEventRevenue => Instance[(byte)9];

		public static WorldResourceItem DismantlingRevenue => Instance[(byte)10];

		public static WorldResourceItem ShopSalesRate => Instance[(byte)11];

		public static WorldResourceItem CharacterResource => Instance[(byte)12];

		public static WorldResourceItem TreasuryResupply => Instance[(byte)13];
	}

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

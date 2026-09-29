using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EnemyNest : ConfigData<EnemyNestItem, short>
{
	public static class DefKey
	{
		public const short ViciousBeggarsNest = 0;

		public const short ThievesCamp = 1;

		public const short BanditsStronghold = 2;

		public const short TraitorsGang = 3;

		public const short VillainsValley = 4;

		public const short Mixiangzhen = 5;

		public const short MassGrave = 6;

		public const short HereticHome = 7;

		public const short EvilGround = 8;

		public const short Xiuluochang = 9;

		public const short FlurryofDemons = 10;

		public const short DeadEnd = 11;

		public const short HallOfTheRighteous = 12;

		public const short HerosLeague = 13;

		public const short UnchartedTerritory = 14;
	}

	public static class DefValue
	{
		public static EnemyNestItem ViciousBeggarsNest => Instance[(short)0];

		public static EnemyNestItem ThievesCamp => Instance[(short)1];

		public static EnemyNestItem BanditsStronghold => Instance[(short)2];

		public static EnemyNestItem TraitorsGang => Instance[(short)3];

		public static EnemyNestItem VillainsValley => Instance[(short)4];

		public static EnemyNestItem Mixiangzhen => Instance[(short)5];

		public static EnemyNestItem MassGrave => Instance[(short)6];

		public static EnemyNestItem HereticHome => Instance[(short)7];

		public static EnemyNestItem EvilGround => Instance[(short)8];

		public static EnemyNestItem Xiuluochang => Instance[(short)9];

		public static EnemyNestItem FlurryofDemons => Instance[(short)10];

		public static EnemyNestItem DeadEnd => Instance[(short)11];

		public static EnemyNestItem HallOfTheRighteous => Instance[(short)12];

		public static EnemyNestItem HerosLeague => Instance[(short)13];

		public static EnemyNestItem UnchartedTerritory => Instance[(short)14];
	}

	public static EnemyNest Instance = new EnemyNest();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TipTitle", "TipDesc", "Members", "Leader", "MonthlyActionId", "AdventureId", "TemplateId", "SpawnAmountFactors" };

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
		_dataArray.Add(new EnemyNestItem(0, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_0"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_0"), 0, new List<short> { 296, 297, 298, 299, 300 }, 300, new List<short> { 4, 4, 4, 4, 0 }, 15, 17, 50, 250, 50, 500, 36));
		_dataArray.Add(new EnemyNestItem(1, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_1"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_1"), 0, new List<short> { 301, 302, 303, 304, 305 }, 305, new List<short> { 4, 4, 4, 3, 0 }, 16, 268182972, 100, 500, 100, 1000, 36));
		_dataArray.Add(new EnemyNestItem(2, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_2"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_2"), 0, new List<short> { 306, 307, 308, 309, 310 }, 310, new List<short> { 4, 4, 3, 3, 0 }, 18, 81638591, 150, 1000, 200, 2000, 36));
		_dataArray.Add(new EnemyNestItem(3, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_3"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_3"), 0, new List<short>
		{
			311, 312, 313, 314, 315, 316, 317, 318, 319, 320,
			321, 322, 323, 324, 325
		}, -1, new List<short>
		{
			4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
			4, 4, 4, 4, 4
		}, 19, 1157686666, 200, 1500, 300, 3000, 1));
		_dataArray.Add(new EnemyNestItem(4, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_4"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_4"), 0, new List<short> { 326, 327, 328, 329, 330 }, 330, new List<short> { 3, 3, 3, 3, 0 }, 17, 24, 250, 2250, 450, 4500, 36));
		_dataArray.Add(new EnemyNestItem(5, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_5"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_5"), 0, new List<short> { 331, 332, 333, 334, 335 }, 335, new List<short> { 3, 3, 3, 2, 0 }, 20, 1016260222, 300, 3000, 600, 6000, 1));
		_dataArray.Add(new EnemyNestItem(6, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_6"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_6"), 0, new List<short> { 336, 337, 338, 339, 340 }, 340, new List<short> { 3, 3, 2, 2, 0 }, 22, 26, 350, 4000, 800, 8000, 1));
		_dataArray.Add(new EnemyNestItem(7, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_7"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_7"), 0, new List<short> { 341, 342, 343, 344, 345 }, 345, new List<short> { 3, 2, 2, 2, 0 }, 21, 242525420, 400, 5000, 1000, 10000, 36));
		_dataArray.Add(new EnemyNestItem(8, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_8"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_8"), 0, new List<short> { 346, 347, 348, 349, 350 }, 350, new List<short> { 2, 2, 2, 2, 0 }, 26, 719558403, 450, 6500, 1300, 13000, 36));
		_dataArray.Add(new EnemyNestItem(9, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_9"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_9"), 0, new List<short> { 351, 352, 353, 354, 355 }, 355, new List<short> { 2, 2, 2, 1, 0 }, 23, 493756853, 500, 8000, 1600, 16000, 1));
		_dataArray.Add(new EnemyNestItem(10, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_10"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_10"), 0, new List<short> { 356, 357, 358, 359, 360 }, 360, new List<short> { 2, 2, 1, 1, 0 }, 24, 150293747, 550, 10000, 2000, 20000, 36));
		_dataArray.Add(new EnemyNestItem(11, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_11"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_11"), 0, new List<short> { 361, 362, 363, 364, 365 }, 365, new List<short> { 2, 1, 1, 1, 0 }, 25, 267084840, 600, 12000, 2400, 24000, 36));
		_dataArray.Add(new EnemyNestItem(12, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_12"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_12"), 1, new List<short> { 375, 376, 377 }, 377, new List<short> { 4, 4, 3 }, 27, 38844009, -150, 1500, 300, 3000, 36));
		_dataArray.Add(new EnemyNestItem(13, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_13"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_13"), 1, new List<short> { 378, 379, 380 }, 380, new List<short> { 3, 3, 2 }, 28, 176747589, -350, 5000, 1000, 10000, 36));
		_dataArray.Add(new EnemyNestItem(14, LocalStringManager.GetConfig("EnemyNest_language", "TipTitle_14"), LocalStringManager.GetConfig("EnemyNest_language", "TipDesc_14"), 1, new List<short> { 381, 382, 383 }, 383, new List<short> { 2, 2, 1 }, 29, 81053777, -550, 10000, 2000, 20000, 36));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EnemyNestItem>(15);
		CreateItems0();
	}
}

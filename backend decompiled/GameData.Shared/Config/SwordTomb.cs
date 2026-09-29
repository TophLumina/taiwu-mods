using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SwordTomb : ConfigData<SwordTombItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Monv = 0;

		public const sbyte DayueYaochang = 1;

		public const sbyte Jiuhan = 2;

		public const sbyte JinHuanger = 3;

		public const sbyte YiYihou = 4;

		public const sbyte WeiQi = 5;

		public const sbyte Yixiang = 6;

		public const sbyte Xuefeng = 7;

		public const sbyte ShuFang = 8;
	}

	public static class DefValue
	{
		public static SwordTombItem Monv => Instance[(sbyte)0];

		public static SwordTombItem DayueYaochang => Instance[(sbyte)1];

		public static SwordTombItem Jiuhan => Instance[(sbyte)2];

		public static SwordTombItem JinHuanger => Instance[(sbyte)3];

		public static SwordTombItem YiYihou => Instance[(sbyte)4];

		public static SwordTombItem WeiQi => Instance[(sbyte)5];

		public static SwordTombItem Yixiang => Instance[(sbyte)6];

		public static SwordTombItem Xuefeng => Instance[(sbyte)7];

		public static SwordTombItem ShuFang => Instance[(sbyte)8];
	}

	public static SwordTomb Instance = new SwordTomb();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"AdventureCoreId", "XiangshuAvatarBegin", "WeakenedXiangshuAvatarBegin", "JuniorXiangshuAvatar", "PuppetXiangshuAvatar", "ImmortalXiangshuAvatar", "Legacies", "BigEventWhenRemoved", "SwordFragment", "MonthlyEventGood",
		"MonthlyEventBad", "DefeatAchievementStat", "TemplateId"
	};

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SwordTombItem(0, 261009073, 39, 120, 201, 219, 210, new short[4] { 713, 722, 731, 740 }, 0, 229, 435, 436, 154));
		_dataArray.Add(new SwordTombItem(1, 223477212, 48, 129, 202, 220, 211, new short[4] { 714, 723, 732, 741 }, 1, 230, 437, 438, 155));
		_dataArray.Add(new SwordTombItem(2, 282394811, 57, 138, 203, 221, 212, new short[4] { 715, 724, 733, 742 }, 2, 231, 439, 440, 156));
		_dataArray.Add(new SwordTombItem(3, 262953388, 66, 147, 204, 222, 213, new short[4] { 716, 725, 734, 743 }, 3, 232, 441, 442, 157));
		_dataArray.Add(new SwordTombItem(4, 236364639, 75, 156, 205, 223, 214, new short[4] { 717, 726, 735, 744 }, 4, 233, 443, 444, 158));
		_dataArray.Add(new SwordTombItem(5, 297365569, 84, 165, 206, 224, 215, new short[4] { 718, 727, 736, 745 }, 5, 234, 445, 446, 159));
		_dataArray.Add(new SwordTombItem(6, 236364643, 93, 174, 207, 225, 216, new short[4] { 719, 728, 737, 746 }, 6, 235, 447, 448, 160));
		_dataArray.Add(new SwordTombItem(7, 238278449, 102, 183, 208, 226, 217, new short[4] { 720, 729, 738, 747 }, 7, 236, 449, 450, 161));
		_dataArray.Add(new SwordTombItem(8, 236364641, 111, 192, 209, 227, 218, new short[4] { 721, 730, 739, 748 }, 8, 237, 451, 452, 162));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SwordTombItem>(9);
		CreateItems0();
	}
}

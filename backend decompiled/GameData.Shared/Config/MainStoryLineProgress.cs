using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MainStoryLineProgress : ConfigData<MainStoryLineProgressItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 开始
		/// </summary>
		public const short Beginning = 0;

		/// <summary>
		/// 深谷竹庐-探索深谷
		/// </summary>
		public const short ExploringValley = 1;

		/// <summary>
		/// 深谷竹庐-离开深谷
		/// </summary>
		public const short LeavingValley = 2;

		/// <summary>
		/// 隐世小村-进入小村
		/// </summary>
		public const short EnteringSmallVillage = 3;

		/// <summary>
		/// 隐世小村-探索小村
		/// </summary>
		public const short ExploringSmallVillage = 4;

		/// <summary>
		/// 隐世小村-离开小村
		/// </summary>
		public const short LeavingSmallVillage = 5;

		/// <summary>
		/// 崩溃地区-进入区域
		/// </summary>
		public const short EnteringBrokenPerformArea = 6;

		/// <summary>
		/// 继承太吾-进入区域
		/// </summary>
		public const short EnteringTaiwuVillage = 7;

		/// <summary>
		/// 继承太吾-继承太吾
		/// </summary>
		public const short InheritingTaiwu = 8;

		/// <summary>
		/// 继承太吾-村庄复兴
		/// </summary>
		public const short DevelopingTaiwuVillage = 9;

		/// <summary>
		/// 继承太吾-古墓仙人
		/// </summary>
		public const short MeetingImmortalXu = 10;

		/// <summary>
		/// 剑冢出现-离开古墓
		/// </summary>
		public const short LeavingAncientTomb = 11;

		/// <summary>
		/// 剑冢出现-化身移动
		/// </summary>
		public const short FirstAppearanceOfXiangshuAvatar = 12;

		/// <summary>
		/// 剑冢出现-仙公沉默
		/// </summary>
		public const short DefeatOfImmortalXu = 13;

		/// <summary>
		/// 和尚来访
		/// </summary>
		public const short VisitOfOldMonk = 14;

		/// <summary>
		/// 和尚离开
		/// </summary>
		public const short LeavingOfOldMonk = 15;

		/// <summary>
		/// 初涉江湖
		/// </summary>
		public const short ExploringTheState = 16;

		/// <summary>
		/// 拜师学艺
		/// </summary>
		public const short LearningCombatSkill = 17;

		/// <summary>
		/// 世界开放
		/// </summary>
		public const short ExploringTheWorld = 18;

		/// <summary>
		/// 剑冢主线-剑冢之一
		/// </summary>
		public const short DefeatingXiangshuAvatar1 = 19;

		/// <summary>
		/// 剑冢主线-剑冢之二
		/// </summary>
		public const short DefeatingXiangshuAvatar2 = 20;

		/// <summary>
		/// 剑冢主线-剑冢之三
		/// </summary>
		public const short DefeatingXiangshuAvatar3 = 21;

		/// <summary>
		/// 剑冢主线-剑冢之四
		/// </summary>
		public const short DefeatingXiangshuAvatar4 = 22;

		/// <summary>
		/// 剑冢主线-剑冢之五
		/// </summary>
		public const short DefeatingXiangshuAvatar5 = 23;

		/// <summary>
		/// 剑冢主线-剑冢之六
		/// </summary>
		public const short DefeatingXiangshuAvatar6 = 24;

		/// <summary>
		/// 剑冢主线-剑冢之七
		/// </summary>
		public const short DefeatingXiangshuAvatar7 = 25;

		/// <summary>
		/// 仙公复归
		/// </summary>
		public const short ReturnOfImmortalXu = 26;

		/// <summary>
		/// 神会焕心-出神之地
		/// </summary>
		public const short SpiritualWanderPlace = 27;

		/// <summary>
		/// 神会焕心-仙公离去
		/// </summary>
		public const short LeaveOfImmortalXu = 28;

		/// <summary>
		/// 决战相枢-染尘入魔
		/// </summary>
		public const short FinalRanChenDemon = 29;

		/// <summary>
		/// 决战相枢-染尘转世
		/// </summary>
		public const short FinalRanChenReincarnate = 30;

		/// <summary>
		/// 决战相枢-相枢蛰伏
		/// </summary>
		public const short FinalXiangShuDormant = 31;

		/// <summary>
		/// 游戏失败结束
		/// </summary>
		public const short GameOver = 32;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 开始
		/// </summary>
		public static MainStoryLineProgressItem Beginning => Instance[(short)0];

		/// <summary>
		/// 深谷竹庐-探索深谷
		/// </summary>
		public static MainStoryLineProgressItem ExploringValley => Instance[(short)1];

		/// <summary>
		/// 深谷竹庐-离开深谷
		/// </summary>
		public static MainStoryLineProgressItem LeavingValley => Instance[(short)2];

		/// <summary>
		/// 隐世小村-进入小村
		/// </summary>
		public static MainStoryLineProgressItem EnteringSmallVillage => Instance[(short)3];

		/// <summary>
		/// 隐世小村-探索小村
		/// </summary>
		public static MainStoryLineProgressItem ExploringSmallVillage => Instance[(short)4];

		/// <summary>
		/// 隐世小村-离开小村
		/// </summary>
		public static MainStoryLineProgressItem LeavingSmallVillage => Instance[(short)5];

		/// <summary>
		/// 崩溃地区-进入区域
		/// </summary>
		public static MainStoryLineProgressItem EnteringBrokenPerformArea => Instance[(short)6];

		/// <summary>
		/// 继承太吾-进入区域
		/// </summary>
		public static MainStoryLineProgressItem EnteringTaiwuVillage => Instance[(short)7];

		/// <summary>
		/// 继承太吾-继承太吾
		/// </summary>
		public static MainStoryLineProgressItem InheritingTaiwu => Instance[(short)8];

		/// <summary>
		/// 继承太吾-村庄复兴
		/// </summary>
		public static MainStoryLineProgressItem DevelopingTaiwuVillage => Instance[(short)9];

		/// <summary>
		/// 继承太吾-古墓仙人
		/// </summary>
		public static MainStoryLineProgressItem MeetingImmortalXu => Instance[(short)10];

		/// <summary>
		/// 剑冢出现-离开古墓
		/// </summary>
		public static MainStoryLineProgressItem LeavingAncientTomb => Instance[(short)11];

		/// <summary>
		/// 剑冢出现-化身移动
		/// </summary>
		public static MainStoryLineProgressItem FirstAppearanceOfXiangshuAvatar => Instance[(short)12];

		/// <summary>
		/// 剑冢出现-仙公沉默
		/// </summary>
		public static MainStoryLineProgressItem DefeatOfImmortalXu => Instance[(short)13];

		/// <summary>
		/// 和尚来访
		/// </summary>
		public static MainStoryLineProgressItem VisitOfOldMonk => Instance[(short)14];

		/// <summary>
		/// 和尚离开
		/// </summary>
		public static MainStoryLineProgressItem LeavingOfOldMonk => Instance[(short)15];

		/// <summary>
		/// 初涉江湖
		/// </summary>
		public static MainStoryLineProgressItem ExploringTheState => Instance[(short)16];

		/// <summary>
		/// 拜师学艺
		/// </summary>
		public static MainStoryLineProgressItem LearningCombatSkill => Instance[(short)17];

		/// <summary>
		/// 世界开放
		/// </summary>
		public static MainStoryLineProgressItem ExploringTheWorld => Instance[(short)18];

		/// <summary>
		/// 剑冢主线-剑冢之一
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar1 => Instance[(short)19];

		/// <summary>
		/// 剑冢主线-剑冢之二
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar2 => Instance[(short)20];

		/// <summary>
		/// 剑冢主线-剑冢之三
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar3 => Instance[(short)21];

		/// <summary>
		/// 剑冢主线-剑冢之四
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar4 => Instance[(short)22];

		/// <summary>
		/// 剑冢主线-剑冢之五
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar5 => Instance[(short)23];

		/// <summary>
		/// 剑冢主线-剑冢之六
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar6 => Instance[(short)24];

		/// <summary>
		/// 剑冢主线-剑冢之七
		/// </summary>
		public static MainStoryLineProgressItem DefeatingXiangshuAvatar7 => Instance[(short)25];

		/// <summary>
		/// 仙公复归
		/// </summary>
		public static MainStoryLineProgressItem ReturnOfImmortalXu => Instance[(short)26];

		/// <summary>
		/// 神会焕心-出神之地
		/// </summary>
		public static MainStoryLineProgressItem SpiritualWanderPlace => Instance[(short)27];

		/// <summary>
		/// 神会焕心-仙公离去
		/// </summary>
		public static MainStoryLineProgressItem LeaveOfImmortalXu => Instance[(short)28];

		/// <summary>
		/// 决战相枢-染尘入魔
		/// </summary>
		public static MainStoryLineProgressItem FinalRanChenDemon => Instance[(short)29];

		/// <summary>
		/// 决战相枢-染尘转世
		/// </summary>
		public static MainStoryLineProgressItem FinalRanChenReincarnate => Instance[(short)30];

		/// <summary>
		/// 决战相枢-相枢蛰伏
		/// </summary>
		public static MainStoryLineProgressItem FinalXiangShuDormant => Instance[(short)31];

		/// <summary>
		/// 游戏失败结束
		/// </summary>
		public static MainStoryLineProgressItem GameOver => Instance[(short)32];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MainStoryLineProgress Instance = new MainStoryLineProgress();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "MainStoryName", "TemplateId", "MainStoryOrder" };

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
		_dataArray.Add(new MainStoryLineProgressItem(0, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_0"), 0));
		_dataArray.Add(new MainStoryLineProgressItem(1, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_1"), 1));
		_dataArray.Add(new MainStoryLineProgressItem(2, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_2"), 2));
		_dataArray.Add(new MainStoryLineProgressItem(3, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_3"), 3));
		_dataArray.Add(new MainStoryLineProgressItem(4, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_4"), 4));
		_dataArray.Add(new MainStoryLineProgressItem(5, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_5"), 5));
		_dataArray.Add(new MainStoryLineProgressItem(6, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_6"), 6));
		_dataArray.Add(new MainStoryLineProgressItem(7, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_7"), 7));
		_dataArray.Add(new MainStoryLineProgressItem(8, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_8"), 8));
		_dataArray.Add(new MainStoryLineProgressItem(9, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_9"), 9));
		_dataArray.Add(new MainStoryLineProgressItem(10, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_10"), 10));
		_dataArray.Add(new MainStoryLineProgressItem(11, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_11"), 11));
		_dataArray.Add(new MainStoryLineProgressItem(12, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_12"), 12));
		_dataArray.Add(new MainStoryLineProgressItem(13, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_13"), 13));
		_dataArray.Add(new MainStoryLineProgressItem(14, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_14"), 14));
		_dataArray.Add(new MainStoryLineProgressItem(15, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_15"), 15));
		_dataArray.Add(new MainStoryLineProgressItem(16, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_16"), 16));
		_dataArray.Add(new MainStoryLineProgressItem(17, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_17"), 17));
		_dataArray.Add(new MainStoryLineProgressItem(18, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_18"), 18));
		_dataArray.Add(new MainStoryLineProgressItem(19, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_19"), 19));
		_dataArray.Add(new MainStoryLineProgressItem(20, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_20"), 20));
		_dataArray.Add(new MainStoryLineProgressItem(21, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_21"), 21));
		_dataArray.Add(new MainStoryLineProgressItem(22, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_22"), 22));
		_dataArray.Add(new MainStoryLineProgressItem(23, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_23"), 23));
		_dataArray.Add(new MainStoryLineProgressItem(24, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_24"), 24));
		_dataArray.Add(new MainStoryLineProgressItem(25, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_25"), 25));
		_dataArray.Add(new MainStoryLineProgressItem(26, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_26"), 26));
		_dataArray.Add(new MainStoryLineProgressItem(27, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_27"), 27));
		_dataArray.Add(new MainStoryLineProgressItem(28, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_28"), 28));
		_dataArray.Add(new MainStoryLineProgressItem(29, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_29"), 29));
		_dataArray.Add(new MainStoryLineProgressItem(30, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_30"), 30));
		_dataArray.Add(new MainStoryLineProgressItem(31, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_31"), 31));
		_dataArray.Add(new MainStoryLineProgressItem(32, LocalStringManager.GetConfig("MainStoryLineProgress_language", "MainStoryName_32"), 99));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MainStoryLineProgressItem>(33);
		CreateItems0();
	}
}

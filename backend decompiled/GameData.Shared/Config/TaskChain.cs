using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class TaskChain : ConfigData<TaskChainItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 主线任务链-完整主线
		/// </summary>
		public const int MainStory = 0;

		/// <summary>
		/// 支线任务链-振兴太吾
		/// </summary>
		public const int SideQuest_Construction = 13;

		/// <summary>
		/// 支线任务链-紫竹化身
		/// </summary>
		public const int PurpleBambooJunior = 20;

		/// <summary>
		/// 支线任务链-奇毒绝方
		/// </summary>
		public const int SectMainStory_Kongsang = 24;

		/// <summary>
		/// 支线任务链-血犼主线
		/// </summary>
		public const int SectMainStory_Xuehou = 25;

		/// <summary>
		/// 支线任务链-血犼村中
		/// </summary>
		public const int SectMainStory_Xuehou_Jixi = 26;

		/// <summary>
		/// 支线任务链-少林主线
		/// </summary>
		public const int SectMainStory_Shaolin = 27;

		/// <summary>
		/// 支线任务链-璇女主线
		/// </summary>
		public const int SectMainStory_Xuannv = 28;

		/// <summary>
		/// 支线任务链-武当主线
		/// </summary>
		public const int SectMainStory_Wudang = 29;

		/// <summary>
		/// 支线任务链-元山主线
		/// </summary>
		public const int SectMainStory_Yuanshan = 30;

		/// <summary>
		/// 支线任务链-狮相主线
		/// </summary>
		public const int SectMainStory_Shixiang = 31;

		/// <summary>
		/// 支线任务链-金刚主线
		/// </summary>
		public const int SectMainStory_Jingang = 32;

		/// <summary>
		/// 支线任务链-五仙主线
		/// </summary>
		public const int SectMainStory_Wuxian = 33;

		/// <summary>
		/// 支线任务链-峨眉主线
		/// </summary>
		public const int SectMainStory_Emei = 34;

		/// <summary>
		/// 支线任务链-峨眉新主线
		/// </summary>
		public const int SectMainStory_EmeiRemake = 172;

		/// <summary>
		/// 支线任务链-预备比武
		/// </summary>
		public const int SectMainStory_EmeiPrepare = 173;

		/// <summary>
		/// 支线任务链-探查妖族
		/// </summary>
		public const int SectMainStory_EmeiSeekEvil = 174;

		/// <summary>
		/// 支线任务链-青琅仙阁
		/// </summary>
		public const int SectMainStory_Ranshan = 35;

		/// <summary>
		/// 支线任务链-武当神树
		/// </summary>
		public const int SectMainStory_Wudang_HeavenlyTree = 36;

		/// <summary>
		/// 支线任务链-孤鸾镜水
		/// </summary>
		public const int PlayerShadowInMirrorChain = 37;

		/// <summary>
		/// 主线任务链-梦回剧情
		/// </summary>
		public const int CrossArchive_MainPlotChain = 38;

		/// <summary>
		/// 支线任务链-梦回取物
		/// </summary>
		public const int CrossArchive_FetchPast = 39;

		/// <summary>
		/// 支线任务链-五方神龙
		/// </summary>
		public const int LoongDLC = 40;

		/// <summary>
		/// 支线任务链-挑战神龙
		/// </summary>
		public const int LoongDLCCaptureLoong = 41;

		/// <summary>
		/// 支线任务链-灵池育蛟
		/// </summary>
		public const int LoongDLCNurtureJiao = 42;

		/// <summary>
		/// 支线任务链-百花主线
		/// </summary>
		public const int SectMainStory_Baihua = 43;

		/// <summary>
		/// 支线任务链-教导三尸
		/// </summary>
		public const int SectMainStory_Ranshan_Sanshi = 44;

		/// <summary>
		/// 支线任务链-寻找玄白
		/// </summary>
		public const int SectMainStory_Baihua_Combat = 45;

		/// <summary>
		/// 支线任务链-指点玄白
		/// </summary>
		public const int SectMainStory_Baihua_Relationship = 46;

		/// <summary>
		/// 支线任务链-伏龙化羽
		/// </summary>
		public const int SectMainStory_Fulong = 47;

		/// <summary>
		/// 支线任务链-神鸡寻羽
		/// </summary>
		public const int ChickenMap = 48;

		/// <summary>
		/// 支线任务链-铸剑主线
		/// </summary>
		public const int SectMainStory_Zhujian = 49;

		/// <summary>
		/// 支线任务链-铸剑技艺
		/// </summary>
		public const int SectMainStory_ZhujianHeritage = 50;

		/// <summary>
		/// 支线任务链-神木种植
		/// </summary>
		public const int PlantTrees = 51;

		/// <summary>
		/// 支线任务链-界青主线
		/// </summary>
		public const int SectMainStory_Jieqing = 52;

		/// <summary>
		/// 支线任务链-铸剑升级互动
		/// </summary>
		public const int SectMainStory_ZhujianUpgrade = 53;

		/// <summary>
		/// 支线任务链-武当升级互动
		/// </summary>
		public const int SectMainStory_WudangUpgrade = 54;

		/// <summary>
		/// 支线任务链-璇女升级互动
		/// </summary>
		public const int SectMainStory_UpgradeXuannv = 55;

		/// <summary>
		/// 支线任务链-五仙升级互动
		/// </summary>
		public const int SectMainStory_UpgradeWuxian = 56;

		/// <summary>
		/// 支线任务链-血犼升级互动
		/// </summary>
		public const int SectMainStory_UpgradeXuehou = 57;

		/// <summary>
		/// 支线任务链-空桑升级互动
		/// </summary>
		public const int SectMainStory_UpgradeKongsang = 58;

		/// <summary>
		/// 支线任务链-狮相升级互动
		/// </summary>
		public const int SectMainStory_ShixiangUpgrade = 59;

		/// <summary>
		/// 支线任务链-元山升级互动
		/// </summary>
		public const int SectMainStory_YuanshanUpgrade = 60;

		/// <summary>
		/// 支线任务链-然山升级互动
		/// </summary>
		public const int SectMainStory_RanshanUpgrade = 61;

		/// <summary>
		/// 支线任务链-金刚升级互动
		/// </summary>
		public const int SectMainStory_JingangUpgrade = 62;

		/// <summary>
		/// 支线任务链-伏龙升级互动
		/// </summary>
		public const int SectMainStory_FulongUpgrade = 63;

		/// <summary>
		/// 支线任务链-百花升级互动
		/// </summary>
		public const int SectMainStory_BaihuaUpgrade = 64;

		/// <summary>
		/// 支线任务链-百花互动剧情
		/// </summary>
		public const int SectMainStory_BaihuaStory = 65;

		/// <summary>
		/// 支线任务链-少林升级互动
		/// </summary>
		public const int SectMainStory_ShaolinUpgrade = 66;

		/// <summary>
		/// 支线任务链-峨眉升级互动
		/// </summary>
		public const int SectMainStory_EmeiUpgrade = 169;

		/// <summary>
		/// 支线任务链-界青升级互动
		/// </summary>
		public const int SectMainStory_JieqingUpgrade = 171;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 主线任务链-完整主线
		/// </summary>
		public static TaskChainItem MainStory => Instance[0];

		/// <summary>
		/// 支线任务链-振兴太吾
		/// </summary>
		public static TaskChainItem SideQuest_Construction => Instance[13];

		/// <summary>
		/// 支线任务链-紫竹化身
		/// </summary>
		public static TaskChainItem PurpleBambooJunior => Instance[20];

		/// <summary>
		/// 支线任务链-奇毒绝方
		/// </summary>
		public static TaskChainItem SectMainStory_Kongsang => Instance[24];

		/// <summary>
		/// 支线任务链-血犼主线
		/// </summary>
		public static TaskChainItem SectMainStory_Xuehou => Instance[25];

		/// <summary>
		/// 支线任务链-血犼村中
		/// </summary>
		public static TaskChainItem SectMainStory_Xuehou_Jixi => Instance[26];

		/// <summary>
		/// 支线任务链-少林主线
		/// </summary>
		public static TaskChainItem SectMainStory_Shaolin => Instance[27];

		/// <summary>
		/// 支线任务链-璇女主线
		/// </summary>
		public static TaskChainItem SectMainStory_Xuannv => Instance[28];

		/// <summary>
		/// 支线任务链-武当主线
		/// </summary>
		public static TaskChainItem SectMainStory_Wudang => Instance[29];

		/// <summary>
		/// 支线任务链-元山主线
		/// </summary>
		public static TaskChainItem SectMainStory_Yuanshan => Instance[30];

		/// <summary>
		/// 支线任务链-狮相主线
		/// </summary>
		public static TaskChainItem SectMainStory_Shixiang => Instance[31];

		/// <summary>
		/// 支线任务链-金刚主线
		/// </summary>
		public static TaskChainItem SectMainStory_Jingang => Instance[32];

		/// <summary>
		/// 支线任务链-五仙主线
		/// </summary>
		public static TaskChainItem SectMainStory_Wuxian => Instance[33];

		/// <summary>
		/// 支线任务链-峨眉主线
		/// </summary>
		public static TaskChainItem SectMainStory_Emei => Instance[34];

		/// <summary>
		/// 支线任务链-峨眉新主线
		/// </summary>
		public static TaskChainItem SectMainStory_EmeiRemake => Instance[172];

		/// <summary>
		/// 支线任务链-预备比武
		/// </summary>
		public static TaskChainItem SectMainStory_EmeiPrepare => Instance[173];

		/// <summary>
		/// 支线任务链-探查妖族
		/// </summary>
		public static TaskChainItem SectMainStory_EmeiSeekEvil => Instance[174];

		/// <summary>
		/// 支线任务链-青琅仙阁
		/// </summary>
		public static TaskChainItem SectMainStory_Ranshan => Instance[35];

		/// <summary>
		/// 支线任务链-武当神树
		/// </summary>
		public static TaskChainItem SectMainStory_Wudang_HeavenlyTree => Instance[36];

		/// <summary>
		/// 支线任务链-孤鸾镜水
		/// </summary>
		public static TaskChainItem PlayerShadowInMirrorChain => Instance[37];

		/// <summary>
		/// 主线任务链-梦回剧情
		/// </summary>
		public static TaskChainItem CrossArchive_MainPlotChain => Instance[38];

		/// <summary>
		/// 支线任务链-梦回取物
		/// </summary>
		public static TaskChainItem CrossArchive_FetchPast => Instance[39];

		/// <summary>
		/// 支线任务链-五方神龙
		/// </summary>
		public static TaskChainItem LoongDLC => Instance[40];

		/// <summary>
		/// 支线任务链-挑战神龙
		/// </summary>
		public static TaskChainItem LoongDLCCaptureLoong => Instance[41];

		/// <summary>
		/// 支线任务链-灵池育蛟
		/// </summary>
		public static TaskChainItem LoongDLCNurtureJiao => Instance[42];

		/// <summary>
		/// 支线任务链-百花主线
		/// </summary>
		public static TaskChainItem SectMainStory_Baihua => Instance[43];

		/// <summary>
		/// 支线任务链-教导三尸
		/// </summary>
		public static TaskChainItem SectMainStory_Ranshan_Sanshi => Instance[44];

		/// <summary>
		/// 支线任务链-寻找玄白
		/// </summary>
		public static TaskChainItem SectMainStory_Baihua_Combat => Instance[45];

		/// <summary>
		/// 支线任务链-指点玄白
		/// </summary>
		public static TaskChainItem SectMainStory_Baihua_Relationship => Instance[46];

		/// <summary>
		/// 支线任务链-伏龙化羽
		/// </summary>
		public static TaskChainItem SectMainStory_Fulong => Instance[47];

		/// <summary>
		/// 支线任务链-神鸡寻羽
		/// </summary>
		public static TaskChainItem ChickenMap => Instance[48];

		/// <summary>
		/// 支线任务链-铸剑主线
		/// </summary>
		public static TaskChainItem SectMainStory_Zhujian => Instance[49];

		/// <summary>
		/// 支线任务链-铸剑技艺
		/// </summary>
		public static TaskChainItem SectMainStory_ZhujianHeritage => Instance[50];

		/// <summary>
		/// 支线任务链-神木种植
		/// </summary>
		public static TaskChainItem PlantTrees => Instance[51];

		/// <summary>
		/// 支线任务链-界青主线
		/// </summary>
		public static TaskChainItem SectMainStory_Jieqing => Instance[52];

		/// <summary>
		/// 支线任务链-铸剑升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_ZhujianUpgrade => Instance[53];

		/// <summary>
		/// 支线任务链-武当升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_WudangUpgrade => Instance[54];

		/// <summary>
		/// 支线任务链-璇女升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_UpgradeXuannv => Instance[55];

		/// <summary>
		/// 支线任务链-五仙升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_UpgradeWuxian => Instance[56];

		/// <summary>
		/// 支线任务链-血犼升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_UpgradeXuehou => Instance[57];

		/// <summary>
		/// 支线任务链-空桑升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_UpgradeKongsang => Instance[58];

		/// <summary>
		/// 支线任务链-狮相升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_ShixiangUpgrade => Instance[59];

		/// <summary>
		/// 支线任务链-元山升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_YuanshanUpgrade => Instance[60];

		/// <summary>
		/// 支线任务链-然山升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_RanshanUpgrade => Instance[61];

		/// <summary>
		/// 支线任务链-金刚升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_JingangUpgrade => Instance[62];

		/// <summary>
		/// 支线任务链-伏龙升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_FulongUpgrade => Instance[63];

		/// <summary>
		/// 支线任务链-百花升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_BaihuaUpgrade => Instance[64];

		/// <summary>
		/// 支线任务链-百花互动剧情
		/// </summary>
		public static TaskChainItem SectMainStory_BaihuaStory => Instance[65];

		/// <summary>
		/// 支线任务链-少林升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_ShaolinUpgrade => Instance[66];

		/// <summary>
		/// 支线任务链-峨眉升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_EmeiUpgrade => Instance[169];

		/// <summary>
		/// 支线任务链-界青升级互动
		/// </summary>
		public static TaskChainItem SectMainStory_JieqingUpgrade => Instance[171];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaskChain Instance = new TaskChain();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"RequireFinishedTask", "RequireUntriggeredTask", "NextTaskChain", "TaskList", "StartConditions", "RemoveCondtions", "Name", "Sect", "MonthlyEvents", "TemplateId",
		"Group", "Type", "TaskChainIcon"
	};

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new TaskChainItem(0, ETaskChainGroup.MainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			2, 3, 4, 5, 12, 13, 14, 18, 19, 20,
			21, 22, 25, 26, 27, 28, 31, 44, 47, 49,
			61, 64, 65, 66, 67, 69, 70, 71, 72, 74,
			73, 75, 76, 81, 82, 83, 84, 677, 678, 679,
			680, 681, 682, 683, 684, 685, 686, 732, 730, 701,
			702, 703, 704
		}, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_0"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(1, ETaskChainGroup.MainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 34, 35, 36, 37, 38, 39, 40, 41, 42, 43 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_1"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_33"));
		_dataArray.Add(new TaskChainItem(2, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 0 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_2"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(3, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 1 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_3"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(4, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 6, 7, 8, 9 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_4"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(5, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 10, 11 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_5"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(6, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 16 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_6"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(7, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 15 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_7"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(8, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 17 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_8"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(9, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 18 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_9"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(10, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 12 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_10"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(11, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 13 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_11"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(12, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 14 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_12"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(13, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 23, 24 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_13"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_42"));
		_dataArray.Add(new TaskChainItem(14, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 29 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_14"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(15, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 30 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_15"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(16, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 33 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_16"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_33"));
		_dataArray.Add(new TaskChainItem(17, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 45, 46 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_17"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(18, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 48 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_18"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_42"));
		_dataArray.Add(new TaskChainItem(19, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 62, 63 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_19"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_42"));
		_dataArray.Add(new TaskChainItem(20, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int>
		{
			50, 51, 52, 598, 599, 600, 53, 601, 602, 603,
			54, 604, 605, 606, 55, 607, 608, 609, 56, 610,
			611, 612, 57, 613, 614, 615, 58, 616, 617, 618,
			59, 619, 620, 621, 60, 622, 623, 624
		}, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_20"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_46"));
		_dataArray.Add(new TaskChainItem(21, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 699, 68 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_21"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(22, ETaskChainGroup.MainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 77, 78, 79, 80 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_22"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(23, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, 22, 84, -1, new List<int>(), new List<int> { 230 }, new List<int> { 246 }, LocalStringManager.GetConfig("TaskChain_language", "Name_23"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_40"));
		_dataArray.Add(new TaskChainItem(24, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			101, 102, 103, 104, 105, 106, 107, 108, 109, 110,
			111, 112, 113, 114
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_24"), 10, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_7"));
		_dataArray.Add(new TaskChainItem(25, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 115, 116, 117, 118, 119, 120, 121, 122, 130, 131 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_25"), 15, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_14"));
		_dataArray.Add(new TaskChainItem(26, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 123, 124, 125, 126, 127, 128, 129 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_26"), 15, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_14"));
		_dataArray.Add(new TaskChainItem(27, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			132, 135, 133, 136, 137, 138, 139, 140, 141, 142,
			143, 144, 146, 145, 134
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_27"), 1, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_9"));
		_dataArray.Add(new TaskChainItem(28, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			147, 148, 149, 150, 151, 152, 162, 163, 161, 164,
			165, 153, 160, 154, 155, 156, 157, 158, 159
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_28"), 8, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_13"));
		_dataArray.Add(new TaskChainItem(29, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 167, 168, 169, 177, 178, 179, 181 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_29"), 4, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_12"));
		_dataArray.Add(new TaskChainItem(30, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			340, 341, 342, 343, 344, 345, 346, 347, 348, 349,
			350, 351, 352, 353
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_30"), 5, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_15"));
		_dataArray.Add(new TaskChainItem(31, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			182, 183, 185, 186, 187, 188, 189, 190, 184, 191,
			192, 194, 193, 195
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_31"), 6, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_10"));
		_dataArray.Add(new TaskChainItem(32, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			196, 197, 199, 198, 200, 201, 202, 203, 204, 205,
			206, 207, 212, 213, 214, 198, 208, 209, 210, 211
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_32"), 11, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_6"));
		_dataArray.Add(new TaskChainItem(33, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			245, 246, 247, 215, 248, 217, 249, 216, 250, 251,
			218, 252, 253, 219, 254, 221, 220, 255, 256, 257
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_33"), 12, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_11"));
		_dataArray.Add(new TaskChainItem(34, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 222, 223, 224, 225, 228, 227, 226, 229, 230 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_34"), 2, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_3"));
		_dataArray.Add(new TaskChainItem(35, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 258, 259, 260, 261, 265, 266, 267, 269, 268, 270 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_35"), 7, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_8"));
		_dataArray.Add(new TaskChainItem(36, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 172, 173, 174, 176, 180, 170, 175, 171 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_36"), 4, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_12"));
		_dataArray.Add(new TaskChainItem(37, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 166 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_37"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_43"));
		_dataArray.Add(new TaskChainItem(38, ETaskChainGroup.MainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 231 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_38"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_34"));
		_dataArray.Add(new TaskChainItem(39, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 232, 233, 234 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_39"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_34"));
		_dataArray.Add(new TaskChainItem(40, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 235 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_40"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_0"));
		_dataArray.Add(new TaskChainItem(41, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 236, 238, 239, 240, 241, 242 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_41"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_0"));
		_dataArray.Add(new TaskChainItem(42, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 237, 243, 244 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_42"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_0"));
		_dataArray.Add(new TaskChainItem(43, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			271, 272, 273, 274, 275, 276, 282, 290, 291, 292,
			293
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_43"), 3, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_2"));
		_dataArray.Add(new TaskChainItem(44, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 261, 262, 263, 264 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_44"), 7, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_8"));
		_dataArray.Add(new TaskChainItem(45, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 277, 278, 279, 280, 281 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_45"), 3, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_2"));
		_dataArray.Add(new TaskChainItem(46, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 283, 284, 285, 286, 287, 288, 289 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_46"), 3, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_2"));
		_dataArray.Add(new TaskChainItem(47, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			294, 295, 311, 308, 296, 297, 298, 299, 300, 301,
			310, 309, 302, 303, 304, 305, 306
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_47"), 14, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_4"));
		_dataArray.Add(new TaskChainItem(48, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 307 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_48"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_4"));
		_dataArray.Add(new TaskChainItem(49, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			312, 313, 314, 315, 316, 317, 318, 336, 319, 320,
			321, 337, 322, 323, 324, 325, 338, 326, 330, 331,
			332, 339
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_49"), 9, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_16"));
		_dataArray.Add(new TaskChainItem(50, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 327, 333, 334, 335, 328, 329 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_50"), 9, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_16"));
		_dataArray.Add(new TaskChainItem(51, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 364 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_51"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_43"));
		_dataArray.Add(new TaskChainItem(52, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 354, 355, 356, 357, 358, 359, 360, 361, 362, 363 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_52"), 13, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_5"));
		_dataArray.Add(new TaskChainItem(53, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 365, 366, 367, 368, 369, 370 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_53"), 9, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_31"));
		_dataArray.Add(new TaskChainItem(54, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 371, 372, 373, 374 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_54"), 4, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_27"));
		_dataArray.Add(new TaskChainItem(55, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 375, 376, 377 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_55"), 8, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_28"));
		_dataArray.Add(new TaskChainItem(56, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 378, 379, 380 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_56"), 12, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_26"));
		_dataArray.Add(new TaskChainItem(57, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 381, 382, 383, 384 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_57"), 15, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_29"));
		_dataArray.Add(new TaskChainItem(58, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 385, 386, 387, 388 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_58"), 10, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_7"));
		_dataArray.Add(new TaskChainItem(59, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 389, 390, 391, 392 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_59"), 6, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_25"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TaskChainItem(60, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 393, 394, 395 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_60"), 5, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_30"));
		_dataArray.Add(new TaskChainItem(61, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 396, 397, 398, 399 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_61"), 7, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_23"));
		_dataArray.Add(new TaskChainItem(62, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 400, 401, 402 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_62"), 11, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_21"));
		_dataArray.Add(new TaskChainItem(63, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 403, 404, 405, 406 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_63"), 14, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_19"));
		_dataArray.Add(new TaskChainItem(64, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 407, 410, 411 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_64"), 3, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_17"));
		_dataArray.Add(new TaskChainItem(65, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 408, 409 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_65"), 3, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_17"));
		_dataArray.Add(new TaskChainItem(66, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 412, 413, 414, 415 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_66"), 1, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_24"));
		_dataArray.Add(new TaskChainItem(67, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 416, 417, 418 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_67"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(68, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 419 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_68"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_40"));
		_dataArray.Add(new TaskChainItem(69, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 420 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_69"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_37"));
		_dataArray.Add(new TaskChainItem(70, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 421 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_70"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_39"));
		_dataArray.Add(new TaskChainItem(71, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 422, 423, 424 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_71"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(72, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 425, 426, 427 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_72"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_40"));
		_dataArray.Add(new TaskChainItem(73, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 428, 429, 430, 431 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_73"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(74, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 432, 433 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_74"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(75, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 434, 435 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_75"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(76, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 436, 437, 438, 439 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_76"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(77, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 440 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_77"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(78, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 441 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_78"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(79, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 442 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_79"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(80, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 443, 444 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_80"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(81, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 445, 446, 447 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_81"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_39"));
		_dataArray.Add(new TaskChainItem(82, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 448, 449, 450, 451, 452, 453 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_82"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(83, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 454 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_83"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_39"));
		_dataArray.Add(new TaskChainItem(84, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 455 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_84"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(85, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 456, 457, 458, 459 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_85"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(86, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 460 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_86"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(87, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 461 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_87"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(88, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 462 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_88"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(89, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 463 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_89"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(90, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 464 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_90"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(91, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 465, 466 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_91"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(92, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 467, 468, 469 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_92"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(93, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 470 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_93"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(94, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 471, 472 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_94"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(95, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 473, 588 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_95"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(96, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 474, 589 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_96"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(97, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 475 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_97"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(98, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 476, 477 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_98"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(99, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 478, 479 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_99"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(100, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 480, 481, 482 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_100"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(101, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 483 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_101"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(102, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 484 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_102"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(103, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 485 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_103"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(104, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 486 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_104"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(105, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 487 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_105"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(106, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 488, 489, 590 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_106"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(107, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 490, 491, 492 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_107"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(108, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 493 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_108"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(109, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 494 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_109"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(110, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 495 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_110"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(111, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 496 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_111"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(112, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 497 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_112"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(113, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 498, 499 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_113"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_40"));
		_dataArray.Add(new TaskChainItem(114, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 500, 501, 502 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_114"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(115, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 503, 504, 505 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_115"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_1"));
		_dataArray.Add(new TaskChainItem(116, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 506 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_116"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(117, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 507 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_117"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_37"));
		_dataArray.Add(new TaskChainItem(118, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 508 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_118"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(119, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 509 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_119"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new TaskChainItem(120, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 510, 511, 512, 513 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_120"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(121, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 514, 515, 516 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_121"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(122, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 517, 518, 519 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_122"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(123, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 520, 521, 522, 524, 523 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_123"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(124, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 526, 527 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_124"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(125, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 525 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_125"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(126, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 528, 529 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_126"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(127, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 530, 531, 532 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_127"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_5"));
		_dataArray.Add(new TaskChainItem(128, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 533, 534 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_128"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(129, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 535, 536, 537, 538 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_129"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_1"));
		_dataArray.Add(new TaskChainItem(130, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 539, 540, 541 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_130"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_43"));
		_dataArray.Add(new TaskChainItem(131, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 542 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_131"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(132, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 543 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_132"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(133, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 544 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_133"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(134, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 546 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_134"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(135, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 548 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_135"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(136, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 549 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_136"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(137, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 550 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_137"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(138, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 551 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_138"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(139, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 552 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_139"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(140, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 553 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_140"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(141, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 554 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_141"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(142, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 555 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_142"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(143, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 556 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_143"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(144, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 557, 558, 559 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_144"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_1"));
		_dataArray.Add(new TaskChainItem(145, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 560 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_145"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(146, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 561 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_146"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(147, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 562, 563 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_147"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(148, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 545 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_148"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_32"));
		_dataArray.Add(new TaskChainItem(149, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 564, 565, 566 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_149"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(150, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 547 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_150"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(151, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 567 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_151"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(152, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 568 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_152"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(153, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 569, 570, 571 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_153"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(154, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 572, 573, 574 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_154"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(155, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 575 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_155"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(156, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 576, 577 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_156"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(157, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 578 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_157"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_40"));
		_dataArray.Add(new TaskChainItem(158, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 579, 580 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_158"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(159, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 581, 582 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_159"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(160, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 583, 584, 585 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_160"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(161, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 586, 587 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_161"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(162, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 591, 592 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_162"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(163, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 593, 594, 595 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_163"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(164, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 596, 597 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_164"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(165, ETaskChainGroup.MainStory, ETaskChainType.Parallel, -1, 84, -1, new List<int>
		{
			625, 626, 627, 628, 629, 630, 631, 632, 633, 634,
			635, 636, 637, 638, 639, 640, 641
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_165"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_48"));
		_dataArray.Add(new TaskChainItem(166, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 642, 643 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_166"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_35"));
		_dataArray.Add(new TaskChainItem(167, ETaskChainGroup.MainStory, ETaskChainType.Line, -1, 84, -1, new List<int> { 644, 645, 646, 647, 648, 649, 650 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_167"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_49"));
		_dataArray.Add(new TaskChainItem(168, ETaskChainGroup.MainStory, ETaskChainType.Parallel, -1, 84, -1, new List<int>
		{
			651, 652, 653, 654, 655, 656, 657, 658, 659, 660,
			661, 662, 663, 664, 665, 666, 667, 668, 669, 670
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_168"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_47"));
		_dataArray.Add(new TaskChainItem(169, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 671, 672, 673, 674, 675, 676 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_169"), 2, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_18"));
		_dataArray.Add(new TaskChainItem(170, ETaskChainGroup.MainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int>
		{
			700, 687, 688, 689, 690, 691, 692, 693, 694, 695,
			696, 697, 698
		}, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_170"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_50"));
		_dataArray.Add(new TaskChainItem(171, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int> { 705, 706, 707, 708 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_171"), 13, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_20"));
		_dataArray.Add(new TaskChainItem(172, ETaskChainGroup.SectMainStory, ETaskChainType.Line, -1, -1, -1, new List<int>
		{
			709, 710, 711, 712, 713, 720, 731, 721, 722, 723,
			726, 727, 728, 729
		}, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_172"), 2, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_3"));
		_dataArray.Add(new TaskChainItem(173, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 714, 715, 716, 717, 718, 719 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_173"), 2, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_3"));
		_dataArray.Add(new TaskChainItem(174, ETaskChainGroup.SectMainStory, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 724, 725 }, new List<int>(), new List<int> { 348 }, LocalStringManager.GetConfig("TaskChain_language", "Name_174"), 2, new AutoTriggerMonthlyEvent[0], relateAdventure: false, "ui9_back_task_chain_icon_3"));
		_dataArray.Add(new TaskChainItem(175, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 738 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_175"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_41"));
		_dataArray.Add(new TaskChainItem(176, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 734, 733, 737, 736, 735 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_176"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_38"));
		_dataArray.Add(new TaskChainItem(177, ETaskChainGroup.OptionalTasks, ETaskChainType.Parallel, -1, -1, -1, new List<int> { 739, 740, 741, 742 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_177"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_36"));
		_dataArray.Add(new TaskChainItem(178, ETaskChainGroup.OptionalTasks, ETaskChainType.Line, -1, -1, -1, new List<int> { 743 }, new List<int>(), new List<int>(), LocalStringManager.GetConfig("TaskChain_language", "Name_178"), 0, new AutoTriggerMonthlyEvent[0], relateAdventure: true, "ui9_back_task_chain_icon_41"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaskChainItem>(179);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}

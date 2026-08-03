namespace GameData.Domains.World;

/// <summary>
/// 世界功能类型
/// </summary>
public static class WorldFunctionType
{
	/// <summary>
	/// 过月州内通知
	/// </summary>
	public const byte LocalMonthlyNotice = 0;

	/// <summary>
	/// 过月世界通知
	/// </summary>
	public const byte GlobalMonthlyNotice = 1;

	/// <summary>
	/// 查看小地图
	/// </summary>
	public const byte MiniMapViewing = 2;

	/// <summary>
	/// 州内旅行 (包括查看世界地图)
	/// </summary>
	public const byte IntraStateTravel = 3;

	/// <summary>
	/// 世界旅行
	/// </summary>
	public const byte InterStateTravel = 4;

	/// <summary>
	/// 世界资源采集
	/// </summary>
	public const byte WorldResourceCollection = 5;

	/// <summary>
	/// 地点标记
	/// </summary>
	public const byte LocationMarking = 6;

	/// <summary>
	/// 生成外道巢穴
	/// </summary>
	public const byte HereticStrongholdGenerating = 7;

	/// <summary>
	/// 生成义士据点
	/// </summary>
	public const byte RighteousStrongholdGenerating = 8;

	/// <summary>
	/// 显示商队
	/// </summary>
	public const byte CaravanDisplay = 9;

	/// <summary>
	/// 管理太吾村 (陈列室, 祠堂, 以及其他功能建筑的使用; 新建, 修复, 拆除建筑; 指派采集; 建筑经营; 行商等)
	/// </summary>
	public const byte TaiwuVillageManagement = 10;

	/// <summary>
	/// 鸡 (各地鸡的生成, 玩家对鸡的收集)
	/// </summary>
	public const byte Chicken = 11;

	/// <summary>
	/// 轮回台
	/// </summary>
	public const byte SamsaraPlatform = 12;

	/// <summary>
	/// 势力情报
	/// </summary>
	public const byte InfluenceInformation = 13;

	/// <summary>
	/// 恩义互动
	/// </summary>
	public const byte SpiritualDebtAction = 14;

	/// <summary>
	/// 拜师学艺 (学艺许可, 获取支持, 请教功法, 请教技艺, 技艺比试)
	/// </summary>
	public const byte SkillLearning = 15;

	/// <summary>
	/// 交换藏书
	/// </summary>
	public const byte SkillBookExchange = 16;

	/// <summary>
	/// 功法突破
	/// </summary>
	public const byte CombatSkillBreakOut = 17;

	/// <summary>
	/// 志向 (志向显示, 志向选择, 志向互动)
	/// </summary>
	public const byte Aspiration = 18;

	/// <summary>
	/// 关押
	/// </summary>
	public const byte Kidnap = 19;

	/// <summary>
	/// 见闻
	/// </summary>
	public const byte Information = 20;

	/// <summary>
	/// 奇书
	/// </summary>
	public const byte LegendaryBook = 21;

	/// <summary>
	/// 西域商人
	/// </summary>
	public const byte WesternRegionMerchant = 22;

	/// <summary>
	/// 茶马帮
	/// </summary>
	public const byte TeaCaravan = 23;

	/// <summary>
	/// 召唤紫竹化身
	/// </summary>
	public const byte JuniorXiangshuSummoning = 24;

	/// <summary>
	/// 武林大会
	/// </summary>
	public const byte MartialArtContest = 25;

	/// <summary>
	/// 显示太吾作为姓氏
	/// </summary>
	public const byte DisplayTaiwuSurname = 26;

	/// <summary>
	/// 太吾的志向系统
	/// </summary>
	public const byte TaiwuProfession = 27;

	/// <summary>
	/// 璇女抄录名曲功能
	/// </summary>
	public const byte XuannvMusicTranscribe = 28;

	/// <summary>
	/// 每月生成爪牙骷髅人
	/// </summary>
	public const byte XiangshuMinionsReincarnation = 29;

	/// <summary>
	/// NPC任务和行为规划
	/// </summary>
	public const byte NpcMissionAndActionPlanning = 30;

	/// <summary>
	/// 村民身份
	/// </summary>
	public const byte TaiwuVillagerRole = 31;

	/// <summary>
	/// 促织决斗
	/// </summary>
	public const byte CricketCombat = 32;

	/// <summary>
	/// 切磋武功
	/// </summary>
	public const byte PlayCombatInteract = 33;

	/// <summary>
	/// 显示柴山
	/// </summary>
	public const byte ShowChaishan = 34;

	/// <summary>
	/// 获取指定世界功能是否已开启
	/// </summary>
	/// <param name="statuses">所有世界功能的开启状态. 每个 bit 表示一个功能的开启状态, 0 为关闭, 1 为开启.</param>
	/// <param name="type">世界功能类型</param>
	/// <returns></returns>
	public static bool Get(ulong statuses, byte type)
	{
		return (statuses & (ulong)(1L << (int)type)) != 0;
	}

	/// <summary>
	/// 开启指定世界功能
	/// </summary>
	/// <param name="statuses">所有世界功能的开启状态. 每个 bit 表示一个功能的开启状态, 0 为关闭, 1 为开启.</param>
	/// <param name="type">世界功能类型</param>
	public static ulong Set(ulong statuses, byte type)
	{
		return statuses | (ulong)(1L << (int)type);
	}

	/// <summary>
	/// 关闭指定世界功能
	/// </summary>
	/// <param name="statuses">所有世界功能的开启状态. 每个 bit 表示一个功能的开启状态, 0 为关闭, 1 为开启.</param>
	/// <param name="type">世界功能类型</param>
	public static ulong Reset(ulong statuses, byte type)
	{
		return statuses & (ulong)(~(1L << (int)type));
	}
}

namespace GameData.Domains.World;

/// <summary>
/// 触发新功能解锁提示的时间点
/// </summary>
public static class NewFeatureUnlockHintTiming
{
	/// <summary>
	/// 首月可自由活动时
	/// </summary>
	public const int FirstMonthValid = 0;

	/// <summary>
	/// 过月后
	/// </summary>
	public const int AdvanceMonth = 1;

	/// <summary>
	/// 阿牛对话后
	/// </summary>
	public const int TalkToANiu = 2;

	/// <summary>
	/// 隐秘小村道长对话后
	/// </summary>
	public const int TalkToHiddenVillager = 3;

	/// <summary>
	/// 隐秘小村司徒还月对话后
	/// </summary>
	public const int TalkToHiddenVillageSitu = 4;

	/// <summary>
	/// 隐秘小村徐对话后
	/// </summary>
	public const int TalkToHiddenVillageXu = 5;

	/// <summary>
	/// 隐秘小村木人对话后
	/// </summary>
	public const int TalkToHiddenVillageWood = 6;

	/// <summary>
	/// 隐秘小村获得同道
	/// </summary>
	public const int HiddenVillageGetCompany = 7;

	/// <summary>
	/// 亡流寨定居点对话结束
	/// </summary>
	public const int RefugeesCampTalk = 8;

	/// <summary>
	/// 首次抵达太吾村
	/// </summary>
	public const int ReachTaiwuVillageEvent = 9;

	/// <summary>
	/// 志向对话结束后
	/// </summary>
	public const int AspirationEvent = 10;

	/// <summary>
	/// 古墓仙人奇遇对话事件结束
	/// </summary>
	public const int TombAdventureEnd = 11;

	/// <summary>
	/// 荒废驿站奇遇对话事件结束
	/// </summary>
	public const int StationAdventureEnd = 12;

	/// <summary>
	/// 门派接引对话事件结束后
	/// </summary>
	public const int SectAllowLearnSkill = 13;

	/// <summary>
	/// 奇书
	/// </summary>
	public const int LegendBoodEvent = 14;

	/// <summary>
	/// 紫竹
	/// </summary>
	public const int JuniorXiangshuSummoningEvent = 15;

	/// <summary>
	/// 武林大会
	/// </summary>
	public const int MartialArtContestEvent = 16;

	/// <summary>
	/// 抵达亡流寨地图
	/// </summary>
	public const int RefugeesCampMapArrive = 17;
}

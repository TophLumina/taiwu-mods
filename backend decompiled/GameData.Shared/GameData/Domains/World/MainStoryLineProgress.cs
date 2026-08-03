namespace GameData.Domains.World;

/// <summary>
/// 主线进度
/// </summary>
public static class MainStoryLineProgress
{
	/// <summary>
	/// 开始
	/// </summary>
	public const short Beginning = 0;

	/// <summary>
	/// 深谷竹庐: 探索深谷
	/// </summary>
	public const short ExploringValley = 1;

	/// <summary>
	/// 深谷竹庐: 离开深谷
	/// </summary>
	public const short LeavingValley = 2;

	/// <summary>
	/// 隐世小村: 进入小村
	/// </summary>
	public const short EnteringSmallVillage = 3;

	/// <summary>
	/// 隐世小村: 探索小村
	/// </summary>
	public const short ExploringSmallVillage = 4;

	/// <summary>
	/// 隐世小村: 离开小村
	/// </summary>
	public const short LeavingSmallVillage = 5;

	/// <summary>
	/// 崩溃地区: 进入区域
	/// </summary>
	public const short EnteringBrokenPerformArea = 6;

	/// <summary>
	/// 继承太吾: 进入区域
	/// </summary>
	public const short EnteringTaiwuVillage = 7;

	/// <summary>
	/// 继承太吾: 继承太吾
	/// </summary>
	public const short InheritingTaiwu = 8;

	/// <summary>
	/// 继承太吾: 村庄复兴
	/// </summary>
	public const short DevelopingTaiwuVillage = 9;

	/// <summary>
	/// 继承太吾: 古墓仙人
	/// </summary>
	public const short MeetingImmortalXu = 10;

	/// <summary>
	/// 剑冢出现: 离开古墓
	/// </summary>
	public const short LeavingAncientTomb = 11;

	/// <summary>
	/// 剑冢出现: 化身移动
	/// </summary>
	public const short FirstAppearanceOfXiangshuAvatar = 12;

	/// <summary>
	/// 剑冢出现: 仙公沉默
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
	/// 剑冢主线: 剑冢之一
	/// </summary>
	public const short DefeatingXiangshuAvatar1 = 19;

	/// <summary>
	/// 剑冢主线: 剑冢之二
	/// </summary>
	public const short DefeatingXiangshuAvatar2 = 20;

	/// <summary>
	/// 剑冢主线: 剑冢之三
	/// </summary>
	public const short DefeatingXiangshuAvatar3 = 21;

	/// <summary>
	/// 剑冢主线: 剑冢之四
	/// </summary>
	public const short DefeatingXiangshuAvatar4 = 22;

	/// <summary>
	/// 剑冢主线: 剑冢之五
	/// </summary>
	public const short DefeatingXiangshuAvatar5 = 23;

	/// <summary>
	/// 剑冢主线: 剑冢之六
	/// </summary>
	public const short DefeatingXiangshuAvatar6 = 24;

	/// <summary>
	/// 剑冢主线: 剑冢之七
	/// </summary>
	public const short DefeatingXiangshuAvatar7 = 25;

	/// <summary>
	/// 仙公复归
	/// 徐仙公在地图上随机异动，直到生成出神之地奇遇
	/// </summary>
	public const short ReturnOfImmortalXu = 26;

	/// <summary>
	/// 神会焕心: 出神之地
	/// 出神之地奇遇不断移动，直到玩家通关出神之地奇遇
	/// 此处应改变掌门及门派成员逻辑，不再举办武林大会
	/// </summary>
	public const short SpiritualWanderPlace = 27;

	/// <summary>
	/// 神会焕心: 仙公离去
	/// 通关出神之地奇遇，直到对话后仙公离去的事件完结
	/// 仙公离去环节，毁坏会持续包围蚕食太吾村区域
	/// </summary>
	public const short LeaveOfImmortalXu = 28;

	/// <summary>
	/// 决战相枢: 染尘入魔
	/// </summary>
	public const short FinalRanChenDemon = 29;

	/// <summary>
	/// 决战相枢: 染尘转世
	/// </summary>
	public const short FinalRanChenReincarnate = 30;

	/// <summary>
	/// 决战相枢: 相枢蛰伏
	/// </summary>
	public const short FinalXiangShuDormant = 31;

	/// <summary>
	/// 游戏失败结束
	/// </summary>
	public const short GameOver = 99;

	/// <summary>
	/// 检查能否从前一个进度转移到下一个进度
	/// </summary>
	/// <param name="prevProgress"></param>
	/// <param name="nextProgress"></param>
	/// <returns>转移是否有效</returns>
	public static bool CheckTransition(short prevProgress, short nextProgress)
	{
		switch (nextProgress)
		{
		case 0:
			return false;
		case 6:
			if (prevProgress != 5)
			{
				return prevProgress == 4;
			}
			return true;
		case 29:
		case 30:
		case 31:
			return prevProgress == 28;
		case 16:
			if (prevProgress != 14)
			{
				return prevProgress == 15;
			}
			return true;
		case 7:
			if (prevProgress != nextProgress - 1)
			{
				return prevProgress == 2;
			}
			return true;
		case 99:
			return true;
		default:
			return prevProgress == nextProgress - 1;
		}
	}
}

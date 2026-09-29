namespace GameData.Domains.World;

public static class MainStoryLineProgress
{
	public const short Beginning = 0;

	public const short ExploringValley = 1;

	public const short LeavingValley = 2;

	public const short EnteringSmallVillage = 3;

	public const short ExploringSmallVillage = 4;

	public const short LeavingSmallVillage = 5;

	public const short EnteringBrokenPerformArea = 6;

	public const short EnteringTaiwuVillage = 7;

	public const short InheritingTaiwu = 8;

	public const short DevelopingTaiwuVillage = 9;

	public const short MeetingImmortalXu = 10;

	public const short LeavingAncientTomb = 11;

	public const short FirstAppearanceOfXiangshuAvatar = 12;

	public const short DefeatOfImmortalXu = 13;

	public const short VisitOfOldMonk = 14;

	public const short LeavingOfOldMonk = 15;

	public const short ExploringTheState = 16;

	public const short LearningCombatSkill = 17;

	public const short ExploringTheWorld = 18;

	public const short DefeatingXiangshuAvatar1 = 19;

	public const short DefeatingXiangshuAvatar2 = 20;

	public const short DefeatingXiangshuAvatar3 = 21;

	public const short DefeatingXiangshuAvatar4 = 22;

	public const short DefeatingXiangshuAvatar5 = 23;

	public const short DefeatingXiangshuAvatar6 = 24;

	public const short DefeatingXiangshuAvatar7 = 25;

	public const short ReturnOfImmortalXu = 26;

	public const short SpiritualWanderPlace = 27;

	public const short LeaveOfImmortalXu = 28;

	public const short FinalRanChenDemon = 29;

	public const short FinalRanChenReincarnate = 30;

	public const short FinalXiangShuDormant = 31;

	public const short GameOver = 99;

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

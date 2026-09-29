namespace GameData.Domains.World;

public static class WorldFunctionType
{
	public const byte LocalMonthlyNotice = 0;

	public const byte GlobalMonthlyNotice = 1;

	public const byte MiniMapViewing = 2;

	public const byte IntraStateTravel = 3;

	public const byte InterStateTravel = 4;

	public const byte WorldResourceCollection = 5;

	public const byte LocationMarking = 6;

	public const byte HereticStrongholdGenerating = 7;

	public const byte RighteousStrongholdGenerating = 8;

	public const byte CaravanDisplay = 9;

	public const byte TaiwuVillageManagement = 10;

	public const byte Chicken = 11;

	public const byte SamsaraPlatform = 12;

	public const byte InfluenceInformation = 13;

	public const byte SpiritualDebtAction = 14;

	public const byte SkillLearning = 15;

	public const byte SkillBookExchange = 16;

	public const byte CombatSkillBreakOut = 17;

	public const byte Aspiration = 18;

	public const byte Kidnap = 19;

	public const byte Information = 20;

	public const byte LegendaryBook = 21;

	public const byte WesternRegionMerchant = 22;

	public const byte TeaCaravan = 23;

	public const byte JuniorXiangshuSummoning = 24;

	public const byte MartialArtContest = 25;

	public const byte DisplayTaiwuSurname = 26;

	public const byte TaiwuProfession = 27;

	public const byte XuannvMusicTranscribe = 28;

	public const byte XiangshuMinionsReincarnation = 29;

	public const byte NpcMissionAndActionPlanning = 30;

	public const byte TaiwuVillagerRole = 31;

	public const byte CricketCombat = 32;

	public const byte PlayCombatInteract = 33;

	public const byte ShowChaishan = 34;

	public const byte TaiwuVillageVow = 35;

	public static bool Get(ulong statuses, byte type)
	{
		return (statuses & (ulong)(1L << (int)type)) != 0;
	}

	public static ulong Set(ulong statuses, byte type)
	{
		return statuses | (ulong)(1L << (int)type);
	}

	public static ulong Reset(ulong statuses, byte type)
	{
		return statuses & (ulong)(~(1L << (int)type));
	}
}

namespace GameData.Adventure;

public static class AdventureDataHelper
{
	public static class AdvBpVersion
	{
		public const int Current = 1;

		public const int Default = 0;

		public const int BlockIcon = 1;

		public static bool IsSupport(int version)
		{
			if (version >= 0)
			{
				return version <= 1;
			}
			return false;
		}
	}

	public static class AdvElementVersion
	{
		public const int Current = 1;

		public const int Default = 0;

		public const int InvalidCharacterType = 1;

		public static bool IsSupport(int version)
		{
			if (version >= 0)
			{
				return version <= 1;
			}
			return false;
		}
	}

	public static class AdvMajorEventVersion
	{
		public const int Current = 1;

		public const int Default = 0;

		public const int MultiRewards = 1;

		public static bool IsSupport(int version)
		{
			if (version >= 0)
			{
				return version <= 1;
			}
			return false;
		}
	}

	public const int Invalid = 0;

	public const int StartId = 1;

	public const string AdventureBlueprintCheckHeader = "ADVBP:";

	public const string AdventureElementCheckHeader = "ADVE:";

	public const string AdventureMajorEventCheckHeader = "ADVME:";

	public const string AdventureDataExtension = ".advd";

	public const string AdventureElementDataExtension = ".adved";

	public const string AdventureMajorEventDataExtension = ".advmed";

	public const string AdventureCompileType = "Adv";

	public const string AdventureElementCompileType = "AdvElement";

	public const string AdventureMajorEventCompileType = "MajorEvent";
}

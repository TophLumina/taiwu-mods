namespace GameData.Domains.Taiwu;

public class VillagerWorkType
{
	public const sbyte Invalid = -1;

	public const sbyte Build = 0;

	public const sbyte ShopManage = 1;

	public const sbyte Job = 2;

	public const sbyte CollectResource = 10;

	public const sbyte CollectTribute = 11;

	public const sbyte KeepGrave = 12;

	public const sbyte Idle = 13;

	public const sbyte Migrate = 14;

	public const sbyte Develop = 15;

	public const sbyte WorkTypeOnMapStart = 10;

	public static bool IsWorkOnMap(sbyte workType)
	{
		return workType >= 10;
	}

	public static bool IsWorkOnMapAndNeedMark(sbyte workType)
	{
		if (workType >= 10 && workType != 10)
		{
			return workType != 14;
		}
		return false;
	}

	public static bool IsVillagerRoleSpecificType(sbyte workType)
	{
		if (workType != 10)
		{
			return workType == 14;
		}
		return true;
	}
}

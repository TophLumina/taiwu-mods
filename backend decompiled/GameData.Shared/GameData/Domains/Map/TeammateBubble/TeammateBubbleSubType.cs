using Config;

namespace GameData.Domains.Map.TeammateBubble;

public class TeammateBubbleSubType
{
	public const int CloseFriend = 0;

	public const int XuXiaomao = 1;

	public const int GuoYan = 2;

	public const int SituHuanyue = 3;

	public const int ANiu = 4;

	public const int Cricket = 5;

	public const int Family = 6;

	public const int Friend = 7;

	public const int Just = 8;

	public const int Kind = 9;

	public const int Even = 10;

	public const int Rebel = 11;

	public const int Egoistic = 12;

	public const int Count = 13;

	public static int GetPriority(int subtype)
	{
		return subtype switch
		{
			7 => 1, 
			6 => 2, 
			1 => 3, 
			2 => 3, 
			3 => 3, 
			4 => 3, 
			5 => 3, 
			0 => 4, 
			_ => 0, 
		};
	}

	public static string GetStringByType(TeammateBubbleItem config, int subType, short templateId)
	{
		return subType switch
		{
			0 => config.SpecialDesc0, 
			1 => config.SpecialDesc1, 
			2 => config.SpecialDesc2, 
			3 => config.SpecialDesc3, 
			4 => config.SpecialDesc4, 
			6 => config.FamilyDesc, 
			7 => config.FriendDesc, 
			5 => config.Cricket[GetIndexByCricketCharTemplateId(templateId)], 
			8 => config.BehaviorDesc[0], 
			9 => config.BehaviorDesc[1], 
			10 => config.BehaviorDesc[2], 
			11 => config.BehaviorDesc[3], 
			12 => config.BehaviorDesc[4], 
			_ => string.Empty, 
		};
	}

	public static int GetIndexByCricketCharTemplateId(short templateId)
	{
		return (templateId - 968) / 2;
	}
}

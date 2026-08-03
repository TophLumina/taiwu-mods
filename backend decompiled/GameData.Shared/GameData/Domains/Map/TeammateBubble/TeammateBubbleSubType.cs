using Config;

namespace GameData.Domains.Map.TeammateBubble;

/// <summary>
/// 同道气泡子类型
/// </summary>
public class TeammateBubbleSubType
{
	/// <summary>
	/// 谷中密友
	/// </summary>
	public const int CloseFriend = 0;

	/// <summary>
	/// 徐小猫
	/// </summary>
	public const int XuXiaomao = 1;

	/// <summary>
	/// 郭彦
	/// </summary>
	public const int GuoYan = 2;

	/// <summary>
	/// 司徒还月
	/// </summary>
	public const int SituHuanyue = 3;

	/// <summary>
	/// 阿牛
	/// </summary>
	public const int ANiu = 4;

	/// <summary>
	/// 促织
	/// </summary>
	public const int Cricket = 5;

	/// <summary>
	/// 亲属
	/// </summary>
	public const int Family = 6;

	/// <summary>
	/// 好友
	/// </summary>
	public const int Friend = 7;

	/// <summary>
	/// 刚正
	/// </summary>
	public const int Just = 8;

	/// <summary>
	/// 仁善
	/// </summary>
	public const int Kind = 9;

	/// <summary>
	/// 中庸
	/// </summary>
	public const int Even = 10;

	/// <summary>
	/// 叛逆
	/// </summary>
	public const int Rebel = 11;

	/// <summary>
	/// 唯我
	/// </summary>
	public const int Egoistic = 12;

	public const int Count = 13;

	/// <summary>
	/// 获取优先度
	/// </summary>
	/// <param name="subtype"></param>
	/// <returns></returns>
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

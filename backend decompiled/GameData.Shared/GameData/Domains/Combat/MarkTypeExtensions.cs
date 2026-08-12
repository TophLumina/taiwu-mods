namespace GameData.Domains.Combat;

/// <summary>
/// 标记类型拓展
/// </summary>
public static class MarkTypeExtensions
{
	/// <summary>
	/// 获取标记组类型
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public static EMarkGroupType GetGroup(this EMarkType type)
	{
		switch (type)
		{
		case EMarkType.Outer:
		case EMarkType.Inner:
			return EMarkGroupType.Injury;
		case EMarkType.Flaw:
		case EMarkType.Acupoint:
		case EMarkType.Mind:
			return EMarkGroupType.Impair;
		case EMarkType.Poison:
			return EMarkGroupType.Poison;
		case EMarkType.Fatal:
			return EMarkGroupType.Fatal;
		case EMarkType.Die:
			return EMarkGroupType.Die;
		case EMarkType.Wug:
			return EMarkGroupType.Wug;
		case EMarkType.QiDisorder:
			return EMarkGroupType.QiDisorder;
		case EMarkType.State:
			return EMarkGroupType.State;
		case EMarkType.NeiliAllocation:
			return EMarkGroupType.NeiliAllocation;
		case EMarkType.Health:
			return EMarkGroupType.Health;
		case EMarkType.Scar:
			return EMarkGroupType.Scar;
		case EMarkType.Tired:
			return EMarkGroupType.Tired;
		default:
			return EMarkGroupType.Unknown;
		}
	}
}

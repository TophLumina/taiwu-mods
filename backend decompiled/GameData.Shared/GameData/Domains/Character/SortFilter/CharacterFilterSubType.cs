using Config;

namespace GameData.Domains.Character.SortFilter;

/// <summary>
/// 筛选子规则
/// </summary>
public static class CharacterFilterSubType
{
	/// <summary>
	/// 州域
	/// </summary>
	public const sbyte MapState = 0;

	/// <summary>
	/// 关系显示类型
	/// </summary>
	public const sbyte RelationDisplayType = 1;

	/// <summary>
	/// 村民身份
	/// </summary>
	public const sbyte VillagerRole = 2;

	/// <summary>
	/// 排除自身和同道，并按州域分类
	/// </summary>
	public const sbyte MapStateWithoutTeammates = 3;

	/// <summary>
	/// 筛选类型对应的筛选分类数量
	/// </summary>
	public static readonly int[] SubTypeToFilterCount;

	static CharacterFilterSubType()
	{
		int[] obj = new int[4] { 16, 10, 0, 15 };
		obj[2] = Config.VillagerRole.Instance.Count + 1;
		SubTypeToFilterCount = obj;
	}
}

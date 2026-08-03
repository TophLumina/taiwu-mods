namespace GameData.Domains.Character;

/// <summary>
/// 武学技艺组
/// </summary>
public static class SkillGroup
{
	/// <summary>
	/// 技艺
	/// </summary>
	public const sbyte LifeSkill = 0;

	/// <summary>
	/// 武学
	/// </summary>
	public const sbyte CombatSkill = 1;

	/// <summary>
	/// 武学技艺组的个数
	/// </summary>
	public const int Count = 2;

	/// <summary>
	/// 从物品子类型获取武学技艺组
	/// </summary>
	/// <param name="itemSubType"><see cref="T:GameData.Domains.Item.ItemSubType" /></param>
	/// <returns></returns>
	public static sbyte FromItemSubType(short itemSubType)
	{
		return (sbyte)(itemSubType - 1000);
	}
}

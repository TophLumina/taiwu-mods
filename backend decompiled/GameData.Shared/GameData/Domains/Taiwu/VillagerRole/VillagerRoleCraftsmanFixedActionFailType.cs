namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 匠人固定行为失败原因
/// </summary>
public class VillagerRoleCraftsmanFixedActionFailType
{
	/// <summary>
	/// 非法
	/// </summary>
	public const sbyte InvalidSubType = -1;

	/// <summary>
	/// 不在太吾村影响范围
	/// </summary>
	public const sbyte NotInTaiwuVillageInfluenceRange = 0;

	/// <summary>
	/// 缺少建筑-火炼室
	/// </summary>
	public const sbyte LackBuildingForgingRoom = 1;

	/// <summary>
	/// 缺少建筑-木工房
	/// </summary>
	public const sbyte LackBuildingWoodworkingRoom = 2;

	/// <summary>
	/// 缺少建筑-绣楼
	/// </summary>
	public const sbyte LackBuildingWeavingRoom = 3;

	/// <summary>
	/// 缺少建筑-巧匠屋
	/// </summary>
	public const sbyte LackBuildingJadeRoom = 4;

	/// <summary>
	/// 药仓中物资不足
	/// </summary>
	public const sbyte LackResource = 5;

	/// <summary>
	/// 锻造造诣不满足
	/// </summary>
	public const sbyte ForgingLifeSkillNotMeet = 6;

	/// <summary>
	/// 制木造诣不满足
	/// </summary>
	public const sbyte WoodworkingLifeSkillNotMeet = 7;

	/// <summary>
	/// 织锦造诣不满足
	/// </summary>
	public const sbyte WeavingLifeSkillNotMeet = 8;

	/// <summary>
	/// 巧匠造诣不满足
	/// </summary>
	public const sbyte JadeLifeSkillNotMeet = 9;

	/// <summary>
	/// 数量
	/// </summary>
	public const sbyte Count = 10;
}

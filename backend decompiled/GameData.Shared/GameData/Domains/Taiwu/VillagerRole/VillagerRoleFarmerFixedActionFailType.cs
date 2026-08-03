namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 农户固定行为失败原因
/// </summary>
public class VillagerRoleFarmerFixedActionFailType
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
	/// 缺少建筑-食窖
	/// </summary>
	public const sbyte LackBuildingKitchen = 1;

	/// <summary>
	/// 厨仓中物资不足
	/// </summary>
	public const sbyte LackResource = 2;

	/// <summary>
	/// 厨艺造诣不满足
	/// </summary>
	public const sbyte CookingLifeSkillNotMeet = 3;

	/// <summary>
	/// 数量
	/// </summary>
	public const sbyte Count = 4;
}

namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 大夫固定行为失败原因
/// </summary>
public class VillagerRoleDoctorFixedActionFailType
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
	/// 缺少建筑-药房
	/// </summary>
	public const sbyte LackBuildingMedicineRoom = 1;

	/// <summary>
	/// 缺少建筑-幽室
	/// </summary>
	public const sbyte LackBuildingToxicologyRoom = 2;

	/// <summary>
	/// 药仓中物资不足
	/// </summary>
	public const sbyte LackResource = 3;

	/// <summary>
	/// 医术造诣不满足
	/// </summary>
	public const sbyte MedicineLifeSkillNotMeet = 4;

	/// <summary>
	/// 毒术造诣不满足
	/// </summary>
	public const sbyte ToxicologyLifeSkillNotMeet = 5;

	/// <summary>
	/// 数量
	/// </summary>
	public const sbyte Count = 6;
}

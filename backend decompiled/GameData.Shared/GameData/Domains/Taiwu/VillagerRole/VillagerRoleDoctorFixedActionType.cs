namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 大夫固定行为类型
/// </summary>
public class VillagerRoleDoctorFixedActionType
{
	/// <summary>
	/// 非法
	/// </summary>
	public const sbyte InvalidSubType = -1;

	/// <summary>
	/// 制药、制毒
	/// </summary>
	public const sbyte CraftMedicine = 0;

	/// <summary>
	/// 解毒
	/// </summary>
	public const sbyte DetoxItem = 1;

	/// <summary>
	/// 淬毒
	/// </summary>
	public const sbyte AddPoisonToItem = 2;

	/// <summary>
	/// 数量
	/// </summary>
	public const sbyte Count = 3;
}

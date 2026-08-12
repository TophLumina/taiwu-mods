namespace GameData.Domains.Taiwu.VillagerRole;

/// <summary>
/// 匠人固定行为类型
/// </summary>
public class VillagerRoleCraftsmanFixedActionType
{
	/// <summary>
	/// 非法
	/// </summary>
	public const sbyte InvalidSubType = -1;

	/// <summary>
	/// 制造
	/// </summary>
	public const sbyte CraftEquipment = 0;

	/// <summary>
	/// 修理
	/// </summary>
	public const sbyte RepairItem = 1;

	/// <summary>
	/// 拆解
	/// </summary>
	public const sbyte DisassembleItem = 2;

	/// <summary>
	/// 获取精制引子
	/// </summary>
	public const sbyte GainRefineMaterial = 3;

	/// <summary>
	/// 数量
	/// </summary>
	public const sbyte Count = 4;
}

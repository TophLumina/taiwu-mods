namespace GameData.Domains.Building;

/// <summary>
/// 需要与表现模块共享的常量集合
/// </summary>
public class SharedConstValue
{
	/// <summary>
	/// 建筑成员领袖的默认索引
	/// </summary>
	public const int BuildingMemberLeaderDefaultIndex = 0;

	/// <summary>
	/// 耐久度不为0时，修理所需资源倍率
	/// </summary>
	public const float RepairResourceNormalFactor = 0.5f;

	/// <summary>
	/// 耐久度为0时，修理所需资源倍率
	/// </summary>
	public const sbyte RepairResourceNoDurabilityFactor = 1;

	/// <summary>
	/// 拆解材料时获得的资源因子
	/// </summary>
	public const byte DisassembleMaterialFactor = 3;

	/// <summary>
	/// 制造时间每次增加需要的制造次数
	/// </summary>
	public const byte MakeTimeAddNeedCount = 3;

	/// <summary>
	/// 触发安定文化加成的定居点数量
	/// </summary>
	public const short SafetyOrCultureFactorSettlementCount = 10;

	/// <summary>
	/// 制造结果的3个阶段
	/// </summary>
	public const int MakeStageCount = 3;
}

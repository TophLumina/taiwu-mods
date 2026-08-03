namespace GameData.Domains.Character.Display;

/// <summary>
/// 村民选人数据接口
/// </summary>
public interface IVillagerSelectCharacterData : ISelectCharacterData
{
	/// <summary>
	/// 工作类型
	/// </summary>
	sbyte WorkType { get; }

	/// <summary>
	/// 工作状态
	/// </summary>
	byte WorkStatus { get; }

	/// <summary>
	/// 身份安排ID
	/// </summary>
	int ArrangementTemplateId { get; }

	/// <summary>
	/// 建筑块模板ID（用于经营地点显示）
	/// </summary>
	int BuildingBlockTemplateId { get; }

	/// <summary>
	/// 是否为买入操作（用于经营岗位区分）
	/// </summary>
	bool IsBuyOperation { get; }

	/// <summary>
	/// 陵墓ID（守墓时使用）
	/// </summary>
	int GraveId { get; }

	/// <summary>
	/// 剑冢ID（守护剑冢时使用）
	/// </summary>
	int SwordTombId { get; }

	/// <summary>
	/// 身份模板ID (如农户、匠人等)
	/// </summary>
	int RoleTemplateId { get; }
}

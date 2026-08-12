namespace GameData.Domains.Taiwu;

/// <summary>
/// 自动处理物品的书籍子类型，存档数据，不可删除
/// </summary>
public enum EItemAutoOperationBookSubtype
{
	Invalid = -1,
	/// <summary>
	/// 已读完
	/// </summary>
	ReadFinished,
	/// <summary>
	/// 未读完，研读中
	/// </summary>
	Reading,
	/// <summary>
	/// 未读完，未研读
	/// </summary>
	NotReading,
	Count
}

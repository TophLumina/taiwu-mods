using GameData.Serializer;

namespace GameData.Domains.Taiwu.ExchangeSystem;

/// <summary>
/// 交换类型
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EExchangeType
{
	/// <summary>
	/// 未指定
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 个人
	/// </summary>
	Person,
	/// <summary>
	/// 交换藏书 - 门派藏书
	/// </summary>
	BookSect,
	/// <summary>
	/// 交换藏书 - 私人藏书
	/// </summary>
	BookPriv,
	/// <summary>
	/// 定居点库房
	/// </summary>
	Settlement,
	/// <summary>
	/// 商店
	/// </summary>
	Shop,
	/// <summary>
	/// 太吾自家库房
	/// </summary>
	Warehouse
}

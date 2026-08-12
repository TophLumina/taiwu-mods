using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 自动处理物品的来源，存档数据，不可删除
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EItemAutoOperationSource
{
	Invalid = -1,
	/// <summary>
	/// 战斗结算
	/// </summary>
	Combat,
	/// <summary>
	/// 地格拾取
	/// </summary>
	Pick,
	/// <summary>
	/// 其他（展示获得物品）
	/// </summary>
	Other,
	Count
}

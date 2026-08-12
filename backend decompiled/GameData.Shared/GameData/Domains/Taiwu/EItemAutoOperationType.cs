using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 自动处理物品的操作类型，存档数据，不可删除
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EItemAutoOperationType
{
	Invalid = -1,
	Discard,
	Disassemble,
	Count
}

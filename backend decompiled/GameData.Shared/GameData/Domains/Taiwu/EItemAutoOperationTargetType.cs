using GameData.Serializer;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 自动处理物品的类型，存档数据，不可删除
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EItemAutoOperationTargetType
{
	Invalid = -1,
	Food,
	Medicine,
	Weapon,
	OtherEquipment,
	Book,
	Tool,
	Material,
	RefineMaterial,
	Count
}

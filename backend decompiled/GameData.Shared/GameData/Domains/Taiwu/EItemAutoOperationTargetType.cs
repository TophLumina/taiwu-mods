using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
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

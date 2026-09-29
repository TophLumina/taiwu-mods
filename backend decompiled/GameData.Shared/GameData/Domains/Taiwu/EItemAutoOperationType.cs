using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
public enum EItemAutoOperationType
{
	Invalid = -1,
	Discard,
	Disassemble,
	Count
}

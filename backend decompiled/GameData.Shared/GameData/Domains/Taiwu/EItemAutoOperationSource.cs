using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
public enum EItemAutoOperationSource
{
	Invalid = -1,
	Combat,
	Pick,
	Other,
	Count
}

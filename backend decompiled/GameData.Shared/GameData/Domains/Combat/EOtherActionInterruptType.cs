using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializeTo(typeof(byte))]
public enum EOtherActionInterruptType
{
	Allow,
	HideClose,
	ForceFlee
}

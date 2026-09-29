using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializeTo(typeof(byte))]
public enum MoveState
{
	Stay,
	Forward,
	Backward
}

using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializeTo(typeof(sbyte))]
public enum EWisdomType
{
	None = -1,
	Positive,
	Negative
}

using GameData.Serializer;

namespace GameData.Domains.Adventure;

[SerializeTo(typeof(byte))]
public enum EAdventureParameterValueType
{
	Int,
	Progress,
	Bool,
	Index,
	Task,
	String
}

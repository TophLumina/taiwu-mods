using GameData.Serializer;

namespace GameData.Domains.Adventure;

[SerializeTo(typeof(byte))]
public enum EAdventureParameterKeyType
{
	Int,
	String
}

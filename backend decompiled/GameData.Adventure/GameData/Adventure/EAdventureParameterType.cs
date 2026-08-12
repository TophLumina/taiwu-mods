using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureParameterType
{
	[OriginalName("Normal")]
	Normal,
	[OriginalName("State")]
	State,
	[OriginalName("Influence")]
	Influence
}

using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureCharacterType
{
	[OriginalName("Invalid")]
	Invalid,
	[OriginalName("Necessary")]
	Necessary,
	[OriginalName("NecessaryAutoCreate")]
	NecessaryAutoCreate,
	[OriginalName("Optional")]
	Optional
}

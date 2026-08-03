using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureElementCreatingType
{
	[OriginalName("Inherit")]
	Inherit,
	[OriginalName("RandomInBlock")]
	RandomInBlock,
	[OriginalName("RandomInGroup")]
	RandomInGroup
}

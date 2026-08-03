using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureMajorEventNodeType
{
	[OriginalName("Start")]
	Start,
	[OriginalName("Turn")]
	Turn,
	[OriginalName("End")]
	End,
	[OriginalName("Check")]
	Check
}

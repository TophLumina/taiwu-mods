using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureTag
{
	[OriginalName("MainStory")]
	MainStory,
	[OriginalName("SectStory")]
	SectStory,
	[OriginalName("SectCompetition")]
	SectCompetition
}

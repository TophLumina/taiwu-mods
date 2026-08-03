using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureBlockType
{
	[OriginalName("None")]
	None,
	[OriginalName("In")]
	In,
	[OriginalName("Out")]
	Out,
	[OriginalName("InOut")]
	InOut
}

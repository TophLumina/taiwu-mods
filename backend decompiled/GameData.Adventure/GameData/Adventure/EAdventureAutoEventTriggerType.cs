using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureAutoEventTriggerType
{
	[OriginalName("EnterAdventure")]
	EnterAdventure,
	[OriginalName("ExitAdventure")]
	ExitAdventure,
	[OriginalName("PlayerMove")]
	PlayerMove,
	[OriginalName("ElementMove")]
	ElementMove,
	[OriginalName("UseItem")]
	UseItem,
	[OriginalName("ActionFinished")]
	ActionFinished
}

using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureElementMoveType
{
	[OriginalName("Static")]
	Static,
	[OriginalName("RandomMove")]
	RandomMove,
	[OriginalName("CloserToPlayer")]
	CloserToPlayer,
	[OriginalName("AwayFromPlayer")]
	AwayFromPlayer,
	[OriginalName("CloserToElement")]
	CloserToElement,
	[OriginalName("AwayFromElement")]
	AwayFromElement,
	[OriginalName("PatrolInBlock")]
	PatrolInBlock,
	[OriginalName("PatrolInGroup")]
	PatrolInGroup,
	[OriginalName("CloserToTag")]
	CloserToTag,
	[OriginalName("AwayFromTag")]
	AwayFromTag,
	[OriginalName("Reset")]
	Reset,
	[OriginalName("PatrolInSpecifyGroup")]
	PatrolInSpecifyGroup,
	[OriginalName("Follow")]
	Follow
}

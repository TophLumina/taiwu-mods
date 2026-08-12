using System;

namespace GameData.Domains.Adventure;

[Flags]
public enum EAdventureChanged
{
	None = 0,
	DataChanged = 1,
	EventTriggered = 2
}

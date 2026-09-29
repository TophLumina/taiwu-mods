using System;

namespace GameData.Domains.Adventure;

[Flags]
public enum EAdventureBlockStatusType
{
	None = 0,
	In = 1,
	Out = 2,
	Passable = 4
}

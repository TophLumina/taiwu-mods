using System;

namespace GameData.Domains.Character.Ai;

[Flags]
public enum EQualificationImproveSources : byte
{
	None = 0,
	Guaranteed = 1,
	Personality = 2,
	Mentor = 4
}

using System;

namespace GameData.Domains.Character;

[Flags]
public enum AgeAffector : byte
{
	None = 0,
	TaoismPassive = 1,
	TaoismActive = 2,
	MaleKeepYoung = 4,
	FemaleKeepYoung = 8
}

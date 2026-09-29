using System;

namespace GameData.Domains.Organization;

[Flags]
public enum TreasuryOrPrisonVisitStatusType : byte
{
	None = 0,
	MidVisited = 1,
	HighVisited = 2
}

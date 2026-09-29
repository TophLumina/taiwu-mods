using System;

namespace GameData.Common.Algorithm;

[Flags]
public enum EPriorityEventStatus
{
	Keep = 0,
	Done = 1,
	BreakNext = 2
}

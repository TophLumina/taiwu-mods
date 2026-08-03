using System;

namespace GameData.Domains.Organization;

/// <summary>
/// 库房/监牢的访问状态，是一个flag
/// </summary>
[Flags]
public enum TreasuryOrPrisonVisitStatusType : byte
{
	/// <summary>
	/// 未访问任何监牢
	/// </summary>
	None = 0,
	/// <summary>
	/// 中级库房/监牢已访问
	/// </summary>
	MidVisited = 1,
	/// <summary>
	/// 高级库房/监牢已访问
	/// </summary>
	HighVisited = 2
}

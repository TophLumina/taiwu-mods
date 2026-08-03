using System.Collections.Generic;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 峨眉指点武学类型
/// </summary>
public static class EmeiGuidanceCombatSkillType
{
	/// <summary>
	/// 内功
	/// </summary>
	public const int Inner = 0;

	/// <summary>
	/// 拳掌
	/// </summary>
	public const int FistAndPalm = 1;

	/// <summary>
	/// 指法
	/// </summary>
	public const int Finger = 2;

	/// <summary>
	/// 剑法
	/// </summary>
	public const int Sword = 3;

	/// <summary>
	/// 奇门
	/// </summary>
	public const int Special = 4;

	public const int Count = 5;

	public static List<sbyte> GetCombatSkillTypes(int type)
	{
		return type switch
		{
			0 => new List<sbyte> { 0, 1, 2 }, 
			1 => new List<sbyte> { 3 }, 
			2 => new List<sbyte> { 4 }, 
			3 => new List<sbyte> { 7 }, 
			4 => new List<sbyte> { 10 }, 
			_ => new List<sbyte>(), 
		};
	}
}

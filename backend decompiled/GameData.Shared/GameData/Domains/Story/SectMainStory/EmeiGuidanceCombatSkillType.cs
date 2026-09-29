using System.Collections.Generic;

namespace GameData.Domains.Story.SectMainStory;

public static class EmeiGuidanceCombatSkillType
{
	public const int Inner = 0;

	public const int FistAndPalm = 1;

	public const int Finger = 2;

	public const int Sword = 3;

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

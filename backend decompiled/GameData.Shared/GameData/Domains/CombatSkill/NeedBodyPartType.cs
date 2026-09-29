using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

public static class NeedBodyPartType
{
	public const sbyte Head = 0;

	public const sbyte Chest = 1;

	public const sbyte Belly = 2;

	public const sbyte BothHands = 3;

	public const sbyte AnyHand = 4;

	public const sbyte BothLegs = 5;

	public const sbyte AnyLeg = 6;

	public static bool Contains(sbyte needBodyPart, sbyte bodyPart)
	{
		switch (needBodyPart)
		{
		case 0:
			return bodyPart == 2;
		case 1:
			return bodyPart == 0;
		case 2:
			return bodyPart == 1;
		case 3:
		case 4:
			return (uint)(bodyPart - 3) <= 1u;
		case 5:
		case 6:
			return (uint)(bodyPart - 5) <= 1u;
		default:
			return false;
		}
	}

	public static IEnumerable<sbyte> ParseBodyParts(sbyte needBodyPart)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (Contains(needBodyPart, bodyPart))
			{
				yield return bodyPart;
			}
		}
	}
}

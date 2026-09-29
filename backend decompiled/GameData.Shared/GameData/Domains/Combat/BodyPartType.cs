using Redzen.Random;

namespace GameData.Domains.Combat;

public static class BodyPartType
{
	public const sbyte Invalid = -1;

	public const sbyte Chest = 0;

	public const sbyte Belly = 1;

	public const sbyte Head = 2;

	public const sbyte LeftHand = 3;

	public const sbyte RightHand = 4;

	public const sbyte LeftLeg = 5;

	public const sbyte RightLeg = 6;

	public const sbyte Count = 7;

	public static sbyte GetRandomBodyPartType(IRandomSource random)
	{
		return (sbyte)random.Next(7);
	}

	public static sbyte TransferToFiveElementsType(sbyte bodyPartType)
	{
		switch (bodyPartType)
		{
		case 2:
			return 0;
		case 0:
			return 3;
		case 1:
			return 2;
		case 3:
		case 4:
			return 1;
		case 5:
		case 6:
			return 4;
		default:
			return -1;
		}
	}

	public static sbyte TransferFromFiveElementsType(sbyte fiveElementsType)
	{
		return fiveElementsType switch
		{
			0 => 2, 
			3 => 0, 
			2 => 1, 
			1 => 3, 
			4 => 5, 
			_ => -1, 
		};
	}
}

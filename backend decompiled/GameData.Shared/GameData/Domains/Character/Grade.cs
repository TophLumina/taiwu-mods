using GameData.Utilities;

namespace GameData.Domains.Character;

public static class Grade
{
	public const sbyte Low0 = 0;

	public const sbyte Low1 = 1;

	public const sbyte Low2 = 2;

	public const sbyte Middle0 = 3;

	public const sbyte Middle1 = 4;

	public const sbyte Middle2 = 5;

	public const sbyte High0 = 6;

	public const sbyte High1 = 7;

	public const sbyte High2 = 8;

	public const int Count = 9;

	public const int MedicineCount = 6;

	public const sbyte Lowest = 0;

	public const sbyte Highest = 8;

	public static sbyte GetGroup(sbyte grade)
	{
		return (sbyte)MathUtils.Clamp(grade / 3, 0, 3);
	}

	public static (sbyte min, sbyte max) GetGroupGradeRange(sbyte gradeGroup)
	{
		sbyte num = (sbyte)(gradeGroup * 3);
		sbyte maxGrade = (sbyte)(num + 2);
		return (min: num, max: maxGrade);
	}

	public static sbyte GetQualificationGrade(int qualification)
	{
		return (sbyte)MathUtils.Clamp((qualification - 1) / 10, 0, 8);
	}
}

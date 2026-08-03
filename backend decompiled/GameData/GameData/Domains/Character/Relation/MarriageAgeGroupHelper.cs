namespace GameData.Domains.Character.Relation;

public static class MarriageAgeGroupHelper
{
	public static EMarriageAgeGroup GetMarriageAgeGroup(int age)
	{
		if (CheckInRange(age, GlobalConfig.Instance.GoodMarriageAgeRange))
		{
			return EMarriageAgeGroup.GoodAge;
		}
		if (CheckInRange(age, GlobalConfig.Instance.LateMarriageAgeRange))
		{
			return EMarriageAgeGroup.LateAge;
		}
		return EMarriageAgeGroup.ExceedAge;
	}

	public static int GetDistantMarriageChance(this EMarriageAgeGroup ageGroup)
	{
		if (1 == 0)
		{
		}
		int result = ageGroup switch
		{
			EMarriageAgeGroup.GoodAge => GlobalConfig.Instance.DistantMarriageGoodAgeChance, 
			EMarriageAgeGroup.LateAge => GlobalConfig.Instance.DistantMarriageLateAgeChance, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool CheckMarriageTargetAgeInRange(this EMarriageAgeGroup selfMarriageAgeGroup, sbyte targetGender, int targetAge)
	{
		if (1 == 0)
		{
		}
		bool result = selfMarriageAgeGroup switch
		{
			EMarriageAgeGroup.GoodAge => CheckInRange(targetAge, GlobalConfig.Instance.DistantMarriageGoodAgeTargetAgeRange[targetGender]), 
			EMarriageAgeGroup.LateAge => CheckInRange(targetAge, GlobalConfig.Instance.DistantMarriageLateAgeTargetAgeRange[targetGender]), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static bool CheckMarriageTargetGradeInRange(this EMarriageAgeGroup selfMarriageAgeGroup, sbyte selfGrade, sbyte targetGrade)
	{
		if (1 == 0)
		{
		}
		bool result = selfMarriageAgeGroup switch
		{
			EMarriageAgeGroup.GoodAge => CheckInRange((sbyte)(targetGrade - selfGrade), GlobalConfig.Instance.DistantMarriageGoodAgeTargetGradeRange), 
			EMarriageAgeGroup.LateAge => CheckInRange((sbyte)(targetGrade - selfGrade), GlobalConfig.Instance.DistantMarriageLateAgeTargetGradeRange), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static bool CheckInRange(int value, int[] range)
	{
		return value >= range[0] && value <= range[1];
	}

	private static bool CheckInRange(sbyte value, sbyte[] range)
	{
		return value >= range[0] && value <= range[1];
	}
}

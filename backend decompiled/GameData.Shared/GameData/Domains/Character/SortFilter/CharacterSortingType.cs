namespace GameData.Domains.Character.SortFilter;

public static class CharacterSortingType
{
	public const int Name = 0;

	public const int Grade = 1;

	public const int Age = 2;

	public const int Health = 3;

	public const int Gender = 4;

	public const int BehaviorType = 5;

	public const int Happiness = 6;

	public const int Favorability = 7;

	public const int Fame = 8;

	public const int Reside = 9;

	public const int Work = 10;

	public const int AttackMedal = 11;

	public const int DefenseMedal = 12;

	public const int WisdomMedal = 13;

	public const int CombatSkillAgeAdjust = 17;

	public const int LifeSkillAgeAdjust = 18;

	public const int DefeatMarkCount = 19;

	public const int DisorderOfQi = 20;

	public const int PreexistenceCharCount = 21;

	public const int CurrInventoryLoad = 22;

	public const int KidnappedCharCount = 23;

	public const int Organization = 24;

	public const int Location = 25;

	public const int ResourceTypeBegin = 26;

	public const int ResourceTypeEnd = 33;

	public const int ConsummateLevel = 34;

	public const int PrisonTime = 35;

	public const int PunishmentSeverity = 36;

	public const int BountyAmount = 37;

	public const int VillagerNeedWaitTime = 38;

	public const int LifeSkillAttainment = 39;

	public const int Attraction = 201;

	public const int CharacterPropertyReferencedTypeBegin = 100;

	public static ECharacterPropertyReferencedType GetReferencedType(int sortingType)
	{
		return (ECharacterPropertyReferencedType)(sortingType - 100);
	}

	public static int GetCharacterSortingType(ECharacterPropertyReferencedType referencedType)
	{
		return (int)(100 + referencedType);
	}
}

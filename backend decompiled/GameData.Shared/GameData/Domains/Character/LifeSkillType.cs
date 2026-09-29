namespace GameData.Domains.Character;

public static class LifeSkillType
{
	public const sbyte Invalid = -1;

	public const sbyte Music = 0;

	public const sbyte Chess = 1;

	public const sbyte Poem = 2;

	public const sbyte Painting = 3;

	public const sbyte Math = 4;

	public const sbyte Appraisal = 5;

	public const sbyte Forging = 6;

	public const sbyte Woodworking = 7;

	public const sbyte Medicine = 8;

	public const sbyte Toxicology = 9;

	public const sbyte Weaving = 10;

	public const sbyte Jade = 11;

	public const sbyte Taoism = 12;

	public const sbyte Buddhism = 13;

	public const sbyte Cooking = 14;

	public const sbyte Eclectic = 15;

	public const int Count = 16;

	public static readonly sbyte[] ReligiousTypes = new sbyte[2] { 13, 12 };

	public static readonly sbyte[] EntertainingTypes = new sbyte[4] { 0, 1, 2, 3 };

	public static readonly sbyte[] CraftingTypes = new sbyte[7] { 6, 7, 8, 9, 10, 11, 14 };

	public static readonly sbyte[] CraftingMedicineTypes = new sbyte[2] { 8, 9 };

	public static readonly sbyte[] RefineTypes = new sbyte[4] { 6, 7, 10, 11 };
}

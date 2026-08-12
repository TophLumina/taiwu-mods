namespace GameData.Domains.Character;

/// <summary>
/// 技艺类型
/// </summary>
public static class LifeSkillType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 音律
	/// </summary>
	public const sbyte Music = 0;

	/// <summary>
	/// 弈棋
	/// </summary>
	public const sbyte Chess = 1;

	/// <summary>
	/// 诗书
	/// </summary>
	public const sbyte Poem = 2;

	/// <summary>
	/// 绘画
	/// </summary>
	public const sbyte Painting = 3;

	/// <summary>
	/// 术数
	/// </summary>
	public const sbyte Math = 4;

	/// <summary>
	/// 品鉴
	/// </summary>
	public const sbyte Appraisal = 5;

	/// <summary>
	/// 锻造
	/// </summary>
	public const sbyte Forging = 6;

	/// <summary>
	/// 制木
	/// </summary>
	public const sbyte Woodworking = 7;

	/// <summary>
	/// 医术
	/// </summary>
	public const sbyte Medicine = 8;

	/// <summary>
	/// 毒术
	/// </summary>
	public const sbyte Toxicology = 9;

	/// <summary>
	/// 织锦
	/// </summary>
	public const sbyte Weaving = 10;

	/// <summary>
	/// 巧匠
	/// </summary>
	public const sbyte Jade = 11;

	/// <summary>
	/// 道法
	/// </summary>
	public const sbyte Taoism = 12;

	/// <summary>
	/// 佛学
	/// </summary>
	public const sbyte Buddhism = 13;

	/// <summary>
	/// 厨艺
	/// </summary>
	public const sbyte Cooking = 14;

	/// <summary>
	/// 杂学
	/// </summary>
	public const sbyte Eclectic = 15;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 16;

	/// <summary>
	/// 宗教性技艺类型
	/// </summary>
	public static readonly sbyte[] ReligiousTypes = new sbyte[2] { 13, 12 };

	/// <summary>
	/// 娱乐相关技艺类型
	/// </summary>
	public static readonly sbyte[] EntertainingTypes = new sbyte[4] { 0, 1, 2, 3 };

	/// <summary>
	/// 制造相关的技艺类型
	/// </summary>
	public static readonly sbyte[] CraftingTypes = new sbyte[7] { 6, 7, 8, 9, 10, 11, 14 };

	/// <summary>
	/// 制造药毒相关的技艺类型
	/// </summary>
	public static readonly sbyte[] CraftingMedicineTypes = new sbyte[2] { 8, 9 };

	/// <summary>
	/// 精制相关技艺类型
	/// </summary>
	public static readonly sbyte[] RefineTypes = new sbyte[4] { 6, 7, 10, 11 };
}

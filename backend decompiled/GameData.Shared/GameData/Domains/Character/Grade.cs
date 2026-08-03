using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 人物阶级 / 物品品级
/// </summary>
public static class Grade
{
	/// <summary>
	/// 九品
	/// </summary>
	public const sbyte Low0 = 0;

	/// <summary>
	/// 八品
	/// </summary>
	public const sbyte Low1 = 1;

	/// <summary>
	/// 七品
	/// </summary>
	public const sbyte Low2 = 2;

	/// <summary>
	/// 六品
	/// </summary>
	public const sbyte Middle0 = 3;

	/// <summary>
	/// 五品
	/// </summary>
	public const sbyte Middle1 = 4;

	/// <summary>
	/// 四品
	/// </summary>
	public const sbyte Middle2 = 5;

	/// <summary>
	/// 三品
	/// </summary>
	public const sbyte High0 = 6;

	/// <summary>
	/// 二品
	/// </summary>
	public const sbyte High1 = 7;

	/// <summary>
	/// 一品
	/// </summary>
	public const sbyte High2 = 8;

	/// <summary>
	/// 品级的个数 (除药品外)
	/// </summary>
	public const int Count = 9;

	/// <summary>
	/// 药品的品级个数.
	/// 一组药品, 可能从九品到四品, 也可能从六品到一品.
	/// </summary>
	public const int MedicineCount = 6;

	/// <summary>
	/// 最低品级
	/// </summary>
	public const sbyte Lowest = 0;

	/// <summary>
	/// 最高品级
	/// </summary>
	public const sbyte Highest = 8;

	/// <summary>
	/// 品级所属分组. 0 - 下三品, 1 - 中三品, 2 - 上三品
	/// </summary>
	/// <param name="grade"></param>
	/// <returns></returns>
	public static sbyte GetGroup(sbyte grade)
	{
		return (sbyte)MathUtils.Clamp(grade / 3, 0, 3);
	}

	/// <summary>
	/// 获得指定分组的品级范围
	/// </summary>
	/// <param name="gradeGroup"></param>
	/// <returns>最小值(包含), 最大值(包含)</returns>
	public static (sbyte min, sbyte max) GetGroupGradeRange(sbyte gradeGroup)
	{
		sbyte num = (sbyte)(gradeGroup * 3);
		sbyte maxGrade = (sbyte)(num + 2);
		return (min: num, max: maxGrade);
	}

	/// <summary>
	/// 获取指定资质的品阶
	/// </summary>
	/// <param name="qualification"></param>
	/// <returns></returns>
	public static sbyte GetQualificationGrade(int qualification)
	{
		return (sbyte)MathUtils.Clamp((qualification - 1) / 10, 0, 8);
	}
}

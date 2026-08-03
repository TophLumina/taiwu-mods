using System;
using Redzen.Random;

namespace Config.ConfigCells.Character;

/// <summary>
/// 角色筛选规则单元
/// </summary>
[Serializable]
public struct CharacterFilterElement
{
	/// <summary>
	/// 属性类型
	/// </summary>
	public int PropertyType;

	/// <summary>
	/// 属性子类型
	/// </summary>
	public int PropertySubType;

	/// <summary>
	/// 属性下限值
	/// </summary>
	public int ValueMin;

	/// <summary>
	/// 属性上限值
	/// </summary>
	public int ValueMax;

	/// <summary>
	/// 是否为固定值 (最小值), 即没有随机范围.
	/// </summary>
	public bool IsFixed => ValueMax <= ValueMin;

	/// <summary>
	/// 角色筛选规则单元
	/// </summary>
	/// <param name="propertyType"></param>
	/// <param name="valueMin"></param>
	/// <param name="valueMax"></param>
	public CharacterFilterElement(int[] propertyType, int valueMin, int valueMax)
	{
		PropertyType = propertyType[0];
		PropertySubType = ((propertyType.Length > 1) ? propertyType[1] : (-1));
		ValueMin = valueMin;
		ValueMax = valueMax;
	}

	public int GetRandomValue(IRandomSource random)
	{
		if (ValueMin >= ValueMax)
		{
			return ValueMin;
		}
		return random.Next(ValueMin, ValueMax + 1);
	}
}

using Redzen.Random;

namespace GameData.Domains.Combat;

/// <summary>
/// 身体部位类型
/// </summary>
public static class BodyPartType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 胸背
	/// </summary>
	public const sbyte Chest = 0;

	/// <summary>
	/// 腰腹
	/// </summary>
	public const sbyte Belly = 1;

	/// <summary>
	/// 头颈
	/// </summary>
	public const sbyte Head = 2;

	/// <summary>
	/// 左臂
	/// </summary>
	public const sbyte LeftHand = 3;

	/// <summary>
	/// 右臂
	/// </summary>
	public const sbyte RightHand = 4;

	/// <summary>
	/// 左腿
	/// </summary>
	public const sbyte LeftLeg = 5;

	/// <summary>
	/// 右腿
	/// </summary>
	public const sbyte RightLeg = 6;

	/// <summary>
	/// 总数
	/// </summary>
	public const sbyte Count = 7;

	/// <summary>
	/// 获取随机的身体部位类型
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	public static sbyte GetRandomBodyPartType(IRandomSource random)
	{
		return (sbyte)random.Next(7);
	}

	/// <summary>
	/// 转换为五行类型
	/// </summary>
	/// <param name="bodyPartType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 自五行类型转换（手腿对应左侧）
	/// </summary>
	/// <param name="fiveElementsType"></param>
	/// <returns></returns>
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

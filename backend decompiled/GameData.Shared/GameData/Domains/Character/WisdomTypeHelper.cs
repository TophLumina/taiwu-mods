namespace GameData.Domains.Character;

/// <summary>
/// 机略类型工具集
/// </summary>
public static class WisdomTypeHelper
{
	/// <summary>
	/// 从机略值计算机略类型
	/// </summary>
	public static EWisdomType FromWisdomCount(int wisdomCount)
	{
		if (wisdomCount == 0)
		{
			return EWisdomType.None;
		}
		if (wisdomCount >= 0)
		{
			return EWisdomType.Positive;
		}
		return EWisdomType.Negative;
	}
}

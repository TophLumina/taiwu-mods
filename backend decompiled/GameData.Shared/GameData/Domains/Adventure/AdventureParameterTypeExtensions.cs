using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇变量类型拓展方法
/// </summary>
public static class AdventureParameterTypeExtensions
{
	/// <summary>
	/// 转换为值类型
	/// </summary>
	public static EAdventureParameterValueType ConvertToValueType(this EAdventureParameterType type)
	{
		if (type == EAdventureParameterType.State)
		{
			return EAdventureParameterValueType.Progress;
		}
		return EAdventureParameterValueType.Int;
	}
}

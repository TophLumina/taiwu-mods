using GameData.Adventure;

namespace GameData.Domains.Adventure;

public static class AdventureParameterTypeExtensions
{
	public static EAdventureParameterValueType ConvertToValueType(this EAdventureParameterType type)
	{
		if (type == EAdventureParameterType.State)
		{
			return EAdventureParameterValueType.Progress;
		}
		return EAdventureParameterValueType.Int;
	}
}

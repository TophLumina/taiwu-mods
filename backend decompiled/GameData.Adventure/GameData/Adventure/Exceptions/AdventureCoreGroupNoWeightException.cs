using System;

namespace GameData.Adventure.Exceptions;

public class AdventureCoreGroupNoWeightException : Exception
{
	public AdventureCoreGroupNoWeightException(AdventureData data)
		: base($"Adventure core {data.Id} group all no weight.")
	{
	}
}

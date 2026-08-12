using System;

namespace GameData.Adventure.Exceptions;

public class AdventureCoreGroupEmptyException : Exception
{
	public AdventureCoreGroupEmptyException(AdventureData data)
		: base($"Adventure core {data.Id} group is empty.")
	{
	}
}

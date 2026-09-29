using System.Collections.Generic;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

public interface IAdventureParameterProvider
{
	IReadOnlyList<AdventureParameterData> Parameters { get; }

	AdventureParameterValue? GetParameterOrNull(AdventureParameterKey key);

	void SetParameter(AdventureParameterKey key, AdventureParameterValue value);

	void RemoveParameter(AdventureParameterKey key);
}

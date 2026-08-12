using System.Collections.Generic;

namespace GameData.Adventure;

public interface IAdventureData
{
	bool Released { get; }

	string Name { get; }

	string Desc { get; }

	uint StayMonths { get; }

	AdventureCostData Cost { get; }

	IReadOnlyList<EAdventureTag> Tags { get; }
}

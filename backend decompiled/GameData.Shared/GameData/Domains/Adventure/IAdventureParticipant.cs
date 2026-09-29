using GameData.Adventure;

namespace GameData.Domains.Adventure;

public interface IAdventureParticipant : IAdventureParameterProvider
{
	AdventureBlockIndex Index { get; }
}

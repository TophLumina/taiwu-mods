using GameData.Adventure;

namespace GameData.Domains.Adventure;

public interface IAdventureDomainBridge
{
	bool Check(InstructionCompiled ins, int adventureId);

	bool Check(InstructionCompiled ins, int adventureId, int elementId);

	bool Check(InstructionCompiled ins, int adventureId, AdventureBlockIndex index);

	AdventureTaiwu GetAdventureTaiwu();
}

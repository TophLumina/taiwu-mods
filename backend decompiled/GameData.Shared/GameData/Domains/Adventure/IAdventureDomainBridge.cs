using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇域桥接器
/// </summary>
public interface IAdventureDomainBridge
{
	bool Check(InstructionCompiled ins, int adventureId);

	bool Check(InstructionCompiled ins, int adventureId, int elementId);

	bool Check(InstructionCompiled ins, int adventureId, AdventureBlockIndex index);

	AdventureTaiwu GetAdventureTaiwu();
}

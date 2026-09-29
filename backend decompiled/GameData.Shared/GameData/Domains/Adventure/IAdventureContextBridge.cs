using System.Collections.Generic;
using GameData.Adventure;
using GameData.Domains.Item;
using GameData.Domains.Map;
using Redzen.Random;

namespace GameData.Domains.Adventure;

public interface IAdventureContextBridge
{
	IRandomSource Random { get; }

	void ReleaseCalledCharacters(IEnumerable<int> calledCharacters);

	void ReleaseTemporaryCharacters(IEnumerable<int> temporaryCharacters);

	void ReleaseTemporaryItem(ItemKey itemKey);

	void ReleaseTemporaryItems(IReadOnlyList<AdventureItem> temporaryItems);

	void OwnedByAdventure(ItemKey itemKey);

	void CallCharacters(IList<int> calledCharacters, CharacterFilterKey filterKey, Location location, int maxCount);

	int GenerateTemporaryCharacter(short templateId, Location location);

	int GenerateTemporaryCharacter(CharacterFilterKey filterKey, Location location);

	void Execute(InstructionCompiled ins, IAdventureRuntime runtime);
}

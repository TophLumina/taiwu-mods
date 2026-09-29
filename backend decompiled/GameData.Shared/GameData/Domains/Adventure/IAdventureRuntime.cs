using System.Collections.Generic;
using GameData.Adventure;
using GameData.Domains.Map;

namespace GameData.Domains.Adventure;

public interface IAdventureRuntime : IAdventureParameterProvider
{
	int Id { get; }

	int CoreId { get; }

	IAdventureData Core => ExternalDataBridge.Context.AdventureCore.GetAdventureAny(CoreId);

	Location MapLocation { get; }

	int RemainMonths { get; }

	bool Satisfied { get; }

	EAdventureStatusType StatusType { get; }

	void CollectCharacters(ICollection<int> characters);

	bool CallCharacters(IAdventureContextBridge context, EAdventureCharacterType type);

	void SetStatusType(IAdventureContextBridge context, EAdventureStatusType statusType);

	bool IsTemporaryCharacter(int charId);

	bool IsCalledCharacter(int charId);
}

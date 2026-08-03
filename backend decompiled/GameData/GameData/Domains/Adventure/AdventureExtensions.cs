using GameData.Common;
using GameData.Domains.Character;

namespace GameData.Domains.Adventure;

public static class AdventureExtensions
{
	public static void DynamicUnbindAndUnhideFromMap(this AdventureRuntime runtime, DataContext context, GameData.Domains.Character.Character character)
	{
		EAdventureUnbindType unbindType = runtime.DynamicUnbindCharacterAndRemoveElement(character.GetId());
		HandleUnbindType(context, runtime, character, unbindType);
	}

	public static void DynamicUnbindAndUnhideFromMap(this AdventureRuntime runtime, DataContext context, AdventureElement element)
	{
		if (DomainManager.Character.TryGetElement_Objects(element.CharacterId, out var character))
		{
			EAdventureUnbindType unbindType = runtime.DynamicUnbindCharacterAndRemoveElement(element);
			HandleUnbindType(context, runtime, character, unbindType);
		}
	}

	public static void DynamicUnbindAndUnhideFromMap(this AdventureMajorEvent runtime, DataContext context, GameData.Domains.Character.Character character)
	{
		EAdventureUnbindType unbindType = runtime.DynamicUnbindCharacter(context, character.GetId());
		HandleUnbindType(context, runtime, character, unbindType);
	}

	private static void HandleUnbindType(DataContext context, IAdventureRuntime runtime, GameData.Domains.Character.Character character, EAdventureUnbindType unbindType)
	{
		switch (unbindType)
		{
		case EAdventureUnbindType.Called:
			DomainManager.Character.UnhideCharacterOnMap(context, character, 4uL);
			break;
		case EAdventureUnbindType.Temporary:
			character.DeactivateExternalRelationState(context, 4uL);
			break;
		default:
			return;
		}
		DomainManager.Adventure.SetAny(context, runtime);
	}
}

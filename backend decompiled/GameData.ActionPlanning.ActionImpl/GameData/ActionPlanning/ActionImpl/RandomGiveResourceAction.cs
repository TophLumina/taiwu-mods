using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.ActionPlanning.ActionImpl;

public class RandomGiveResourceAction : SpendResourceByGiveResourceAction, ICharacterActionImpl, ISerializableGameData
{
	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		ResourceInts resources = character.GetResources();
		Amount = resources[ResourceType = resources.GetMaxWealthType()] / 10;
		return Amount > 0;
	}
}

using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.ActionImpl;

public class InventoryLoadDemandRequestItemAction : WealthDemandRequestItemAction, ICharacterActionImpl, ISerializableGameData
{
	public new static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return ActionHelper.HasIncreaseInventoryLoadItem(character, targetChar.GetInventory());
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId()));
		Character targetChar = actionData.TargetChar;
		ItemKey selectedItemKey = ActionHelper.SelectIncreaseInventoryLoadItem(character, targetChar.GetInventory());
		if (!selectedItemKey.IsValid())
		{
			return false;
		}
		sbyte targetBehaviorType = targetChar.GetBehaviorType();
		sbyte addPoisonChance = AiHelper.GeneralActionConstants.AddPoisonOnTransferItemChance[targetBehaviorType];
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetBehaviorType, favorabilityType);
		bool agreeToRequest = context.Random.CheckPercentProb(respondChance);
		ItemKey[] poisons = ((agreeToRequest && context.Random.CheckPercentProb(addPoisonChance)) ? targetChar.SelectInventoryPoisonsToAdd(context.Random, selectedItemKey) : null);
		TargetItem = selectedItemKey;
		Amount = 1;
		AgreeToRequest = agreeToRequest;
		if (poisons != null && poisons.Length > 0)
		{
			PoisonsToAdd = poisons;
		}
		return true;
	}
}

using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.ActionImpl;

public class InventoryLoadDemandStealItemAction : WealthDemandStealItemAction, ICharacterActionImpl, ISerializableGameData
{
	public new static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return ActionHelper.HasIncreaseInventoryLoadItem(character, targetChar.GetInventory());
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		ItemKey selectedItemKey = ActionHelper.SelectIncreaseInventoryLoadItem(character, targetChar.GetInventory());
		if (!selectedItemKey.IsValid())
		{
			return false;
		}
		int alertFactor = targetChar.GetItemAlertFactor(selectedItemKey, 1);
		sbyte phase = character.GetStealActionPhase(context.Random, targetChar, alertFactor);
		sbyte poisonChance = AiHelper.GeneralActionConstants.AddPoisonOnTransferItemChance[targetChar.GetBehaviorType()];
		ItemKey[] poisons = ((phase >= 5 && context.Random.CheckPercentProb(poisonChance)) ? targetChar.SelectInventoryPoisonsToAdd(context.Random, selectedItemKey) : null);
		TargetItem = selectedItemKey;
		Amount = 1;
		Phase = phase;
		if (poisons != null && poisons.Length > 0)
		{
			PoisonsToAdd = poisons;
		}
		return true;
	}
}

using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class RequestIncreaseHappinessAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemUsed = 0;

		public const ushort AgreeToRequest = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ItemUsed", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemUsed;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		if (targetChar.GetAgeGroup() != 2)
		{
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		DomainManager.Character.GetAiActionRateAdjust(character.GetId(), 6, -1);
		_ = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
		bool allowWines = !character.IsForbiddenToDrinkingWines();
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType != 9)
			{
				continue;
			}
			TeaWineItem teaWineCfg = Config.TeaWine.Instance[itemKey.TemplateId];
			if (DomainManager.Item.GetBaseItem(itemKey).GetHappinessChange() > 0 && !character.TryDetectAttachedPoisons(itemKey))
			{
				if (teaWineCfg.ItemSubType == 900)
				{
					return true;
				}
				if (allowWines)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		ItemKey selectedItemKey = ItemKey.Invalid;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(actionData.TargetChar.GetInventory().Items);
		List<(GameData.Domains.Item.TeaWine, int)> teaWines = context.AdvanceMonthRelatedData.TeaWinesForHappiness.Get();
		teaWines.Sort(EatingItemComparer.TeaWineHappiness);
		bool allowWines = !character.IsForbiddenToDrinkingWines();
		int selectedIndex = character.SelectTeaWineForHappiness(teaWines, character.GetHappiness(), HappinessType.Ranges[3].min, allowWines);
		if (selectedIndex >= 0)
		{
			selectedItemKey = teaWines[selectedIndex].Item1.GetItemKey();
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		sbyte behaviorType = actionData.TargetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		ItemUsed = selectedItemKey;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (actionData.TargetChar.GetInventory().Items.ContainsKey(ItemUsed))
		{
			return character.GetEatingItems().GetAvailableEatingSlotsCount(character.GetCurrMaxEatingSlotsCount()) > 0;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddRequestTeaWine(selfCharId, location, actionData.TargetChar.GetId(), (ulong)ItemUsed);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 9)
			{
				throw new Exception($"Invalid item type {ItemUsed} to restore neili for {character.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			actionData.TargetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			character.AddEatingItem(context, ItemUsed);
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, actionData.TargetChar, baseItem.GetFavorabilityChange() * 2);
			lifeRecordCollection.AddRequestTeaWineSucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestTeaWine(targetCharId, selfCharId, (ulong)ItemUsed);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, actionData.TargetChar, -3000);
			lifeRecordCollection.AddRequestTeaWineFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestTeaWine(targetCharId, selfCharId, (ulong)ItemUsed);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += ItemUsed.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		int fieldSize = ItemUsed.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += ItemUsed.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

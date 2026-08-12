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
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class RequestRecoverMainAttributeAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort MainAttributeType = 0;

		public const ushort ItemKey = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "MainAttributeType", "ItemKey" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte MainAttributeType;

	[SerializableGameDataField(FieldIndex = 1)]
	public ItemKey ItemKey;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		sbyte behaviorType = character.GetBehaviorType();
		DomainManager.Character.GetAiActionRateAdjust(character.GetId(), 6, -1);
		_ = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
		bool allowMeat = !character.IsForbiddenToEatMeat();
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType != 7)
			{
				continue;
			}
			FoodItem foodCfg = Config.Food.Instance[itemKey.TemplateId];
			if (foodCfg.MainAttributesRegen.Get(args.MainAttributeType) > 0 && !character.TryDetectAttachedPoisons(itemKey))
			{
				if (foodCfg.ItemSubType != 701)
				{
					return true;
				}
				if (allowMeat)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		bool allowMeat = !character.IsForbiddenToEatMeat();
		actionData.Succeed = context.Random.CheckPercentProb(respondChance);
		ItemKey selectedItemKey = ItemKey.Invalid;
		sbyte mainAttributeType = argGroup.MainAttributeType;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(targetChar.GetInventory().Items);
		List<(GameData.Domains.Item.Food, int)> foods = context.AdvanceMonthRelatedData.FoodsForMainAttributes.Get()[mainAttributeType];
		foods.Sort(EatingItemComparer.FoodMainAttributes[mainAttributeType]);
		int selectedIndex = character.SelectFoodIndexForMainAttributes(foods, mainAttributeType, character.GetCurrMainAttribute(mainAttributeType), character.GetMaxMainAttribute(mainAttributeType), allowMeat);
		if (selectedIndex >= 0)
		{
			selectedItemKey = foods[selectedIndex].Item1.GetItemKey();
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		MainAttributeType = mainAttributeType;
		ItemKey = selectedItemKey;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		MainAttributes currMainAttributes = character.GetCurrMainAttributes();
		MainAttributes maxMainAttributes = character.GetMaxMainAttributes();
		if (currMainAttributes[MainAttributeType] < maxMainAttributes[MainAttributeType] && actionData.TargetChar.GetInventory().Items.ContainsKey(ItemKey))
		{
			return character.GetEatingItems().GetAvailableEatingSlotsCount(character.GetCurrMaxEatingSlotsCount()) > 0;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		ItemKey itemUsed = ItemKey;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (actionData.Succeed)
		{
			ItemBase baseItem = DomainManager.Item.GetBaseItem(itemUsed);
			targetChar.RemoveInventoryItem(context, itemUsed, 1, deleteItem: false);
			character.AddEatingItem(context, itemUsed);
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, baseItem.GetFavorabilityChange() * 2);
			lifeRecordCollection.AddRequestFoodSucceed(selfCharId, currDate, targetCharId, location, itemUsed.ItemType, itemUsed.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestFood(targetCharId, selfCharId, (ulong)itemUsed);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			lifeRecordCollection.AddRequestFoodFail(selfCharId, currDate, targetCharId, location, itemUsed.ItemType, itemUsed.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestFood(targetCharId, selfCharId, (ulong)itemUsed);
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
		totalSize += ItemKey.GetSerializedSize();
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
		*pCurrData = (byte)MainAttributeType;
		pCurrData++;
		int fieldSize = ItemKey.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
			MainAttributeType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

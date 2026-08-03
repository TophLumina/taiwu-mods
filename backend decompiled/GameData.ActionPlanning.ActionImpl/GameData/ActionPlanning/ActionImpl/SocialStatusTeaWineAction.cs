using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusTeaWineAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Succeed = 0;

		public const ushort SelfTeaWineItem = 1;

		public const ushort TargetTeaWineItem = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Succeed", "SelfTeaWineItem", "TargetTeaWineItem" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 1)]
	public ItemKey SelfTeaWineItem;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey TargetTeaWineItem;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return targetChar.GetEatingItems().GetAvailableEatingSlotsCount(targetChar.GetCurrMaxEatingSlotsCount()) > 0;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte currMaxEatingSlotCount = character.GetCurrMaxEatingSlotsCount();
		if (character.GetEatingItems().GetAvailableEatingSlot(currMaxEatingSlotCount) <= 0)
		{
			return false;
		}
		if (character.GetAgeGroup() != 2)
		{
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(character.GetId(), 6, -1);
		sbyte selfEatForbiddenFoodChance = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
		bool allowWines = !character.IsForbiddenToDrinkingWines() || context.Random.CheckPercentProb(selfEatForbiddenFoodChance + rateAdjust);
		List<ItemKey> teaWines = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (var (itemKey2, amount) in character.GetInventory().Items)
		{
			if (itemKey2.ItemType == 9 && amount >= 2 && (ItemTemplateHelper.GetItemSubType(itemKey2.ItemType, itemKey2.TemplateId) != 901 || allowWines) && !character.TryDetectAttachedPoisons(itemKey2))
			{
				teaWines.Add(itemKey2);
			}
		}
		ItemKey selectedItem = teaWines.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref teaWines);
		if (!selectedItem.IsValid())
		{
			return false;
		}
		bool num2 = ItemTemplateHelper.GetItemSubType(selectedItem.ItemType, selectedItem.TemplateId) == 901;
		Character selectedChar = actionData.TargetChar;
		bool succeed = true;
		if (num2 && selectedChar.IsForbiddenToDrinkingWines())
		{
			sbyte targetBehaviorType = selectedChar.GetBehaviorType();
			short targetRateAdjust = DomainManager.Character.GetAiActionRateAdjust(selectedChar.GetId(), 6, -1);
			sbyte targetBreakRuleChance = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[targetBehaviorType];
			succeed = context.Random.CheckPercentProb(targetBreakRuleChance + targetRateAdjust);
		}
		SelfTeaWineItem = selectedItem;
		TargetTeaWineItem = selectedItem;
		Succeed = succeed;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		Inventory inventory = character.GetInventory();
		if (inventory.Items.ContainsKey(SelfTeaWineItem))
		{
			return inventory.Items.ContainsKey(TargetTeaWineItem);
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = targetChar.GetLocation();
		monthlyEventCollection.AddAdviseTeaWine(selfCharId, location, targetChar.GetId(), (ulong)SelfTeaWineItem, (ulong)TargetTeaWineItem);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		sbyte behaviorType = character.GetBehaviorType();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		if (Succeed)
		{
			character.RemoveInventoryItem(context, SelfTeaWineItem, 1, deleteItem: false);
			if (SelfTeaWineItem.Id != TargetTeaWineItem.Id)
			{
				character.RemoveInventoryItem(context, TargetTeaWineItem, 1, deleteItem: false);
			}
			character.AddEatingItem(context, SelfTeaWineItem);
			targetChar.AddEatingItem(context, TargetTeaWineItem);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange);
			lifeRecordCollection.AddInviteToDrinkSucceed(selfCharId, currDate, targetCharId, location, SelfTeaWineItem.ItemType, SelfTeaWineItem.TemplateId);
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestDrinking(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange2);
			lifeRecordCollection.AddInviteToDrinkFail(selfCharId, currDate, targetCharId, location, SelfTeaWineItem.ItemType, SelfTeaWineItem.TemplateId);
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestDrinking(targetCharId, selfCharId);
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
		totalSize += SelfTeaWineItem.GetSerializedSize();
		totalSize += TargetTeaWineItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*pCurrData = (Succeed ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize = SelfTeaWineItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = TargetTeaWineItem.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
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
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			pCurrData += SelfTeaWineItem.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			pCurrData += TargetTeaWineItem.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

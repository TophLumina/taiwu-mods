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
public class RequestRestoreQiItemAction : ICharacterActionImpl, ISerializableGameData
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
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType == 8 && Config.Medicine.Instance[itemKey.TemplateId].EffectType == EMedicineEffectType.ChangeDisorderOfQi && !character.TryDetectAttachedPoisons(itemKey))
			{
				return true;
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		ItemKey selectedItemKey = ItemKey.Invalid;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(targetChar.GetInventory().Items);
		List<(GameData.Domains.Item.Medicine, int)> medicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get()[3];
		medicines.Sort(EatingItemComparer.MedicineQiDisorder);
		int selectedIndex = character.SelectMedicineIndexForQiDisorder(medicines, character.GetDisorderOfQi());
		if (selectedIndex >= 0)
		{
			selectedItemKey = medicines[selectedIndex].Item1.GetItemKey();
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		if (!selectedItemKey.IsValid())
		{
			throw new Exception($"Fail to find valid medicine for disorder of Qi in {targetChar}'s inventory to cure {this}.");
		}
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		ItemUsed = selectedItemKey;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (character.GetDisorderOfQi() > 0 && actionData.TargetChar.GetInventory().Items.ContainsKey(ItemUsed))
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
		monthlyEventCollection.AddRequestHealDisorderOfQi(selfCharId, location, actionData.TargetCharId, (ulong)ItemUsed);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to restore disorder of Qi for {character.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			targetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			character.AddEatingItem(context, ItemUsed);
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, baseItem.GetFavorabilityChange() * 5);
			lifeRecordCollection.AddRequestHealDisorderOfQiSucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestRestoreDisorderOfQi(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -6000);
			lifeRecordCollection.AddRequestHealDisorderOfQiFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestRestoreDisorderOfQi(targetCharId, selfCharId);
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

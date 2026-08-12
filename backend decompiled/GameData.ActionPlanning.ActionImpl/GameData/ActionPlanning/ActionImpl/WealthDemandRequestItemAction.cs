using System;
using System.Collections.Generic;
using System.Linq;
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
public class WealthDemandRequestItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort PoisonsToAdd = 3;

		public const ushort HavePoisonsToAdd = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "TargetItem", "Amount", "AgreeToRequest", "PoisonsToAdd", "HavePoisonsToAdd" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 3)]
	public ItemKey[] PoisonsToAdd = Array.Empty<ItemKey>();

	[Obsolete]
	[SerializableGameDataField(FieldIndex = 4)]
	public bool HavePoisonsToAdd;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return targetChar.GetInventory().Items.Any((KeyValuePair<ItemKey, int> pair) => pair.Key.ItemType == args.ItemType && pair.Key.TemplateId == args.ItemTemplateId);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte itemType = argGroup.ItemType;
		short itemTemplateId = argGroup.ItemTemplateId;
		if (itemType == 3)
		{
			return false;
		}
		Character targetChar = actionData.TargetChar;
		sbyte requestActionType = 0;
		ItemKey selectedItemKey = ItemKey.Invalid;
		int targetAmount = 1;
		foreach (var (itemKey2, _) in targetChar.GetInventory().Items)
		{
			if (itemKey2.ItemType == itemType && itemKey2.TemplateId == itemTemplateId)
			{
				selectedItemKey = itemKey2;
				targetAmount = 1;
				break;
			}
		}
		if (!selectedItemKey.IsValid())
		{
			throw new Exception($"Failed to find target item {itemType}, {itemTemplateId} in selected character {targetChar}'s inventory for {character} to request.");
		}
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(requestActionType, isSkill: false);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(actionData.TargetCharId, character.GetId()));
		sbyte targetBehaviorType = targetChar.GetBehaviorType();
		sbyte addPoisonChance = AiHelper.GeneralActionConstants.AddPoisonOnTransferItemChance[targetBehaviorType];
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetBehaviorType, favorabilityType);
		bool agreeToRequest = context.Random.CheckPercentProb(respondChance);
		ItemKey[] poisons = ((agreeToRequest && context.Random.CheckPercentProb(addPoisonChance)) ? targetChar.SelectInventoryPoisonsToAdd(context.Random, selectedItemKey) : null);
		TargetItem = selectedItemKey;
		Amount = targetAmount;
		AgreeToRequest = agreeToRequest;
		if (poisons != null && poisons.Length > 0)
		{
			PoisonsToAdd = poisons;
		}
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return actionData.TargetChar.GetInventory().Items.ContainsKey(TargetItem);
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestItem(selfCharId, location, targetCharId, (ulong)TargetItem, Amount);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		if (AgreeToRequest)
		{
			ItemKey[] poisonsToAdd = PoisonsToAdd;
			if (poisonsToAdd != null && poisonsToAdd.Length > 0)
			{
				(TargetItem, _) = targetChar.AttachPoisonsToInventoryItem(context, TargetItem, PoisonsToAdd);
			}
			DomainManager.Character.TransferInventoryItem(context, targetChar, character, TargetItem, Amount);
			ItemBase itemBase = DomainManager.Item.GetBaseItem(TargetItem);
			int favorabilityChange = itemBase.GetFavorabilityChange() * 2;
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorabilityChange);
			character.ChangeHappiness(context, itemBase.GetHappinessChange());
			lifeRecordCollection.AddRequestItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestItem(selfCharId, targetCharId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			character.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestItem(selfCharId, targetCharId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize += TargetItem.GetSerializedSize();
		if (PoisonsToAdd != null)
		{
			totalSize += 2;
			for (int i = 0; i < PoisonsToAdd.Length; i++)
			{
				totalSize += PoisonsToAdd[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (PoisonsToAdd != null)
		{
			int elementsCount = PoisonsToAdd.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize2 = PoisonsToAdd[i].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (HavePoisonsToAdd ? ((byte)1) : ((byte)0));
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += TargetItem.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PoisonsToAdd == null || PoisonsToAdd.Length != elementsCount)
				{
					PoisonsToAdd = new ItemKey[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					PoisonsToAdd[i] = default(ItemKey);
					pCurrData += PoisonsToAdd[i].Deserialize(pCurrData);
				}
			}
			else
			{
				PoisonsToAdd = null;
			}
		}
		if (fieldCount > 4)
		{
			HavePoisonsToAdd = *pCurrData != 0;
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

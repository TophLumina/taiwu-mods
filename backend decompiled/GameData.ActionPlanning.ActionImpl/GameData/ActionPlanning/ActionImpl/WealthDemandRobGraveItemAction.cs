using System;
using System.Collections.Generic;
using System.Linq;
using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandRobGraveItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort Succeed = 2;

		public const ushort TargetGraveId = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "TargetItem", "Amount", "Succeed", "TargetGraveId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 3)]
	public int TargetGraveId;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte itemType = argGroup.ItemType;
		short itemTemplateId = argGroup.ItemTemplateId;
		if (itemType == 3)
		{
			return false;
		}
		int targetCharId = ActionHelper.GetTargetGraveId(context, character, (Grave grave2) => grave2.GetInventory().Items.Any((KeyValuePair<ItemKey, int> pair) => pair.Key.ItemType == itemType && pair.Key.TemplateId == itemTemplateId), 0);
		if (targetCharId < 0)
		{
			return false;
		}
		sbyte requestActionType = 4;
		ItemKey selectedItemKey = ItemKey.Invalid;
		int targetAmount = 1;
		Grave grave = DomainManager.Character.GetElement_Graves(targetCharId);
		Inventory graveInventory = grave.GetInventory();
		int index = context.Random.Next(graveInventory.Items.Count);
		foreach (var (itemKey2, amount) in graveInventory.Items)
		{
			if (index <= 0)
			{
				selectedItemKey = itemKey2;
				targetAmount = amount;
				break;
			}
			index--;
		}
		if (!selectedItemKey.IsValid())
		{
			throw new Exception($"Failed to find target item {itemType}, {itemTemplateId} in selected character {targetCharId}'s inventory for {character} to request.");
		}
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(requestActionType, isSkill: false);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		int successRate = grave.GetInventory().Items.Count * (100 + character.GetPersonality(6) * 5) / 35;
		TargetItem = selectedItemKey;
		Amount = targetAmount;
		TargetGraveId = targetCharId;
		Succeed = context.Random.CheckPercentProb(successRate);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (DomainManager.Character.TryGetElement_Graves(TargetGraveId, out var grave))
		{
			return grave.GetInventory().Items.ContainsKey(TargetItem);
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			character.ChangeCurrMainAttribute(context, 3, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (DomainManager.Character.IsTaiwuPeople(TargetGraveId))
		{
			monthlyNotificationCollection.AddDigItem(selfCharId, location, TargetGraveId, TargetItem.ItemType, TargetItem.TemplateId);
		}
		if (Succeed)
		{
			DomainManager.Character.GetElement_Graves(TargetGraveId).RemoveInventoryItem(context, TargetItem, Amount);
			character.AddInventoryItem(context, TargetItem, Amount);
			lifeRecordCollection.AddRobItemFromGraveSucceed(selfCharId, currDate, TargetGraveId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRobGraveItem(selfCharId, TargetGraveId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			lifeRecordCollection.AddRobItemFromGraveFail(selfCharId, currDate, TargetGraveId, location, TargetItem.ItemType, TargetItem.TemplateId);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize += TargetItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*pCurrData = (Succeed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TargetGraveId;
		pCurrData += 4;
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
			pCurrData += TargetItem.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			TargetGraveId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

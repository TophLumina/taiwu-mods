using System;
using System.Collections.Generic;
using System.Linq;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandStealItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort Phase = 2;

		public const ushort PoisonsToAdd = 3;

		public const ushort HavePoisonsToAdd = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "TargetItem", "Amount", "Phase", "PoisonsToAdd", "HavePoisonsToAdd" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte Phase;

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
		sbyte requestActionType = 1;
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
		int alertFactor = targetChar.GetItemAlertFactor(selectedItemKey, targetAmount);
		sbyte phase = character.GetStealActionPhase(context.Random, targetChar, alertFactor);
		sbyte poisonChance = AiHelper.GeneralActionConstants.AddPoisonOnTransferItemChance[targetChar.GetBehaviorType()];
		ItemKey[] poisons = ((phase >= 5 && context.Random.CheckPercentProb(poisonChance)) ? targetChar.SelectInventoryPoisonsToAdd(context.Random, selectedItemKey) : null);
		TargetItem = selectedItemKey;
		Amount = targetAmount;
		Phase = phase;
		if (poisons != null)
		{
			PoisonsToAdd = poisons;
		}
		return true;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		if (!actionData.TargetChar.GetInventory().Items.ContainsKey(TargetItem))
		{
			if (Enumerable.Contains(actionData.TargetChar.GetEquipment(), TargetItem))
			{
				return !ItemDomain.GetForceNotTransferable(actionData.TargetChar.GetId(), TargetItem);
			}
			return false;
		}
		return true;
	}

	public void PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 3)
		{
			monthlyNotificationCollection.AddStealItemFailure(selfCharId, location, targetCharId, TargetItem.ItemType, TargetItem.TemplateId);
			ApplyChanges(context, character, targetChar);
			return;
		}
		monthlyNotificationCollection.AddStealItemSuccess(selfCharId, location, targetCharId, TargetItem.ItemType, TargetItem.TemplateId);
		if (Phase == 4)
		{
			if (ItemTemplateHelper.GetItemSubType(TargetItem.ItemType, TargetItem.TemplateId) == 1202)
			{
				monthlyEventCollection.AddStealLegendaryBookGotCaught(selfCharId, location, targetCharId, (ulong)TargetItem, Phase);
			}
			else
			{
				monthlyEventCollection.AddStealItemButBeCaught(selfCharId, location, targetCharId, (ulong)TargetItem);
			}
		}
		else
		{
			if (ItemTemplateHelper.GetItemSubType(TargetItem.ItemType, TargetItem.TemplateId) == 1202)
			{
				monthlyEventCollection.AddStealLegendaryBookAndEscape(selfCharId, location, targetCharId, (ulong)TargetItem, Phase);
			}
			else
			{
				monthlyEventCollection.AddStealItemAndEscape(selfCharId, location, targetCharId, (ulong)TargetItem);
			}
			ApplyChanges(context, character, targetChar);
		}
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 1, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddStealItem(selfCharId, targetCharId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealItemFail1(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			break;
		case 1:
			lifeRecordCollection.AddStealItemFail2(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			break;
		case 2:
			lifeRecordCollection.AddStealItemFail3(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			break;
		case 3:
			lifeRecordCollection.AddStealItemFail4(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			break;
		case 4:
		{
			lifeRecordCollection.AddStealItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			if (targetCharId == taiwuCharId)
			{
				break;
			}
			AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
			if ((uint)(combatResultType - 2) <= 1u)
			{
				int slotIndex2 = targetChar.GetEquipment().IndexOf(TargetItem);
				if (slotIndex2 >= 0)
				{
					targetChar.ChangeEquipment(context, (sbyte)slotIndex2, -1, ItemKey.Invalid);
				}
				DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, TargetItem, Amount);
				targetChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
				DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
			}
			else
			{
				lifeRecordCollection.AddStealItemSucceedAndBeatenUp(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
				DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
			}
			break;
		}
		default:
		{
			int slotIndex = targetChar.GetEquipment().IndexOf(TargetItem);
			if (slotIndex >= 0)
			{
				targetChar.ChangeEquipment(context, (sbyte)slotIndex, -1, ItemKey.Invalid);
			}
			ItemKey[] poisonsToAdd = PoisonsToAdd;
			if (poisonsToAdd != null && poisonsToAdd.Length > 0)
			{
				(TargetItem, _) = targetChar.AttachPoisonsToInventoryItem(context, TargetItem, PoisonsToAdd);
			}
			DomainManager.Character.TransferInventoryItem(context, targetChar, selfChar, TargetItem, Amount);
			targetChar.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
			lifeRecordCollection.AddStealItemSucceedAndEscaped(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			break;
		}
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
		*pCurrData = (byte)Phase;
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
			Phase = (sbyte)(*pCurrData);
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

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
public class RequestKillWugItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemUsed = 0;

		public const ushort WugType = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ItemUsed", "WugType", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemUsed;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte WugType;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		sbyte wugType = args.WugType;
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType == 8)
			{
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineCfg.EffectType == EMedicineEffectType.DetoxWug && medicineCfg.EffectValue == wugType)
				{
					return true;
				}
				if (medicineCfg.EffectType == EMedicineEffectType.ApplyPoison && medicineCfg.SideEffectValue == wugType)
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
		sbyte wugType = argGroup.WugType;
		if (wugType < 0)
		{
			return false;
		}
		EatingItems eatingItems = character.GetEatingItems();
		ItemKey selectedItemKey = ItemKey.Invalid;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(targetChar.GetInventory().Items);
		List<(GameData.Domains.Item.Medicine item, int amount)>[] array = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		List<(GameData.Domains.Item.Medicine, int)> medicines = array[5];
		List<(GameData.Domains.Item.Medicine, int)> poisons = array[6];
		medicines.Sort(EatingItemComparer.MedicineGrade);
		poisons.Sort(EatingItemComparer.MedicineGrade);
		int wugSlot = eatingItems.IndexOfWug(wugType);
		int selectedIndex = character.SelectMedicineIndexForWug(medicines, wugType, eatingItems.GetDuration(wugSlot));
		if (selectedIndex >= 0)
		{
			selectedItemKey = medicines[selectedIndex].Item1.GetItemKey();
		}
		else
		{
			selectedIndex = GameData.Domains.Character.Character.SelectPoisonIndexForWug(poisons, wugType, eatingItems.GetDuration(wugSlot));
			if (selectedIndex >= 0)
			{
				selectedItemKey = poisons[selectedIndex].Item1.GetItemKey();
			}
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		if (!selectedItemKey.IsValid())
		{
			throw new Exception($"Fail to find valid medicine for killing wug in {targetChar}'s inventory to help {this}.");
		}
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		ItemUsed = selectedItemKey;
		WugType = wugType;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (character.GetEatingItems().IndexOfWug(WugType) >= 0 && actionData.TargetChar.GetInventory().Items.ContainsKey(ItemUsed))
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
		EatingItems eatingItems = character.GetEatingItems();
		monthlyEventCollection.AddRequestKillWug(itemKey1: (ulong)eatingItems.Get(eatingItems.IndexOfWug(WugType)), charId: selfCharId, location: location, charId1: actionData.TargetCharId, itemKey: (ulong)ItemUsed);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int targetCharId = targetChar.GetId();
		EatingItems eatingItems = character.GetEatingItems();
		ItemKey wugItemKey = eatingItems.Get(eatingItems.IndexOfWug(WugType));
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to kill wug {WugType} for {character.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			targetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			character.AddEatingItem(context, ItemUsed);
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, baseItem.GetFavorabilityChange() * 5);
			lifeRecordCollection.AddRequestKillWugSucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId, wugItemKey.ItemType, wugItemKey.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestKillWug(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -6000);
			lifeRecordCollection.AddRequestKillWugFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId, wugItemKey.ItemType, wugItemKey.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestKillWug(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
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
		*(short*)pCurrData = 3;
		pCurrData += 2;
		int fieldSize = ItemUsed.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (byte)WugType;
		pCurrData++;
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
			WugType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
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

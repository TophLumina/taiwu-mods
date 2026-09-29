using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
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
public class RequestHealInjuryItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemUsed = 0;

		public const ushort IsInnerInjury = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort TopicalBodyPart = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "ItemUsed", "IsInnerInjury", "AgreeToRequest", "TopicalBodyPart" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemUsed;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool IsInnerInjury;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte TopicalBodyPart;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		sbyte injuryType = args.InjuryType;
		EMedicineEffectType requiredEffectType = ((injuryType == 1) ? EMedicineEffectType.RecoverInnerInjury : EMedicineEffectType.RecoverOuterInjury);
		sbyte minLevel = sbyte.MaxValue;
		Injuries injuries = character.GetInjuries();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryLevel = injuries.Get(bodyPart, injuryType == 1);
			if (injuryLevel > 0 && injuryLevel < minLevel)
			{
				minLevel = injuryLevel;
			}
		}
		Inventory inventory = targetChar.GetInventory();
		MainAttributes selfCurrMainAttributes = character.GetCurrMainAttributes();
		EatingItems eatingItems = character.GetEatingItems();
		sbyte maxEatingSlotCount = character.GetCurrMaxEatingSlotsCount();
		sbyte availableEatingSlot = eatingItems.GetAvailableEatingSlot(maxEatingSlotCount);
		foreach (ItemKey itemKey in inventory.Items.Keys)
		{
			if (itemKey.ItemType == 8)
			{
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineCfg.EffectType == requiredEffectType && !character.TryDetectAttachedPoisons(itemKey) && (medicineCfg.RequiredMainAttributeType < 0 || selfCurrMainAttributes[medicineCfg.RequiredMainAttributeType] >= medicineCfg.RequiredMainAttributeValue) && (medicineCfg.Duration <= 0 || availableEatingSlot >= 0))
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
		sbyte injuryType = argGroup.InjuryType;
		if (injuryType < 0)
		{
			return false;
		}
		bool isInnerInjury = injuryType == 1;
		sbyte minLevel = sbyte.MaxValue;
		sbyte minLevelBodyPart = -1;
		sbyte totalLevel = 0;
		Injuries injuries = character.GetInjuries();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryLevel = injuries.Get(bodyPart, isInnerInjury);
			totalLevel += injuryLevel;
			if (injuryLevel > 0 && injuryLevel < minLevel)
			{
				minLevel = injuryLevel;
				minLevelBodyPart = bodyPart;
			}
		}
		ItemKey selectedItemKey = ItemKey.Invalid;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(targetChar.GetInventory().Items);
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedMedicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		List<(GameData.Domains.Item.Medicine, int)> medicines = (isInnerInjury ? categorizedMedicines[1] : categorizedMedicines[0]);
		medicines.Sort(EatingItemComparer.MedicineInjury);
		MainAttributes currMainAttributes = character.GetCurrMainAttributes();
		int selectedIndex = character.SelectTopicalMedicineIndex(medicines, minLevel, ref currMainAttributes);
		if (selectedIndex >= 0)
		{
			selectedItemKey = medicines[selectedIndex].Item1.GetItemKey();
		}
		else
		{
			minLevelBodyPart = -1;
			selectedIndex = character.SelectMedicineIndexForInjury(medicines, minLevel, totalLevel);
			if (selectedIndex >= 0)
			{
				selectedItemKey = medicines[selectedIndex].Item1.GetItemKey();
			}
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		if (!selectedItemKey.IsValid())
		{
			AdaptableLog.TagError("RequestHealInjuryItemAction", $"Fail to find valid medicine for {(isInnerInjury ? "inner" : "outer")} injury in {targetChar}'s inventory to cure {character}.");
		}
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		ItemUsed = selectedItemKey;
		IsInnerInjury = isInnerInjury;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		TopicalBodyPart = minLevelBodyPart;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (!character.GetInjuries().HasAnyInjury(IsInnerInjury))
		{
			return false;
		}
		if (!actionData.TargetChar.GetInventory().Items.ContainsKey(ItemUsed))
		{
			return false;
		}
		if (TopicalBodyPart == -1)
		{
			return character.GetEatingItems().GetAvailableEatingSlotsCount(character.GetCurrMaxEatingSlotsCount()) > 0;
		}
		MedicineItem medicineCfg = Config.Medicine.Instance[ItemUsed.TemplateId];
		if (medicineCfg.RequiredMainAttributeType >= 0)
		{
			return character.GetCurrMainAttribute(medicineCfg.RequiredMainAttributeType) >= medicineCfg.RequiredMainAttributeValue;
		}
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int characterId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		if (Config.Medicine.Instance[ItemUsed.TemplateId].Duration == 0)
		{
			monthlyEventCollection.AddRequestHealInnerInjuryByItem(characterId, location, targetCharId, (ulong)ItemUsed, TopicalBodyPart);
		}
		else
		{
			monthlyEventCollection.AddRequestHealOuterInjuryByItem(characterId, location, targetCharId, (ulong)ItemUsed, TopicalBodyPart);
		}
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int characterId = character.GetId();
		int targetCharId = targetChar.GetId();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to heal injury for {character.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			targetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			if (Config.Medicine.Instance[ItemUsed.TemplateId].Duration == 0)
			{
				character.ApplyTopicalMedicine(context, ItemUsed);
				DomainManager.Item.RemoveItem(context, ItemUsed);
			}
			else
			{
				character.AddEatingItem(context, ItemUsed);
			}
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, baseItem.GetFavorabilityChange() * 5);
			if (IsInnerInjury)
			{
				lifeRecordCollection.AddRequestHealInnerInjuryItemSucceed(characterId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddRequestHealOuterInjuryItemSucceed(characterId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestHealInjury(targetCharId, characterId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -6000);
			if (IsInnerInjury)
			{
				lifeRecordCollection.AddRequestHealInnerInjuryItemFail(characterId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			else
			{
				lifeRecordCollection.AddRequestHealOuterInjuryItemFail(characterId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId);
			}
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestHealInjury(targetCharId, characterId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
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
		*(short*)pCurrData = 4;
		pCurrData += 2;
		int fieldSize = ItemUsed.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (IsInnerInjury ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)TopicalBodyPart;
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
			IsInnerInjury = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			TopicalBodyPart = (sbyte)(*pCurrData);
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

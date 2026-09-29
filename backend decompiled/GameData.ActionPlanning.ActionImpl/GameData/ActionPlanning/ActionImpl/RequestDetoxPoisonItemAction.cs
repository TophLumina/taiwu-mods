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
public class RequestDetoxPoisonItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemUsed = 0;

		public const ushort PoisonType = 1;

		public const ushort AgreeToRequest = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ItemUsed", "PoisonType", "AgreeToRequest" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ItemUsed;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte PoisonType;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool AgreeToRequest;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		sbyte poisonType = args.PoisonType;
		sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(character.GetPoisoned().Get(poisonType));
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType == 8)
			{
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineCfg.EffectType == EMedicineEffectType.DetoxPoison && medicineCfg.EffectSubType.PoisonType() == poisonType && medicineCfg.EffectThresholdValue >= poisonLevel && !character.TryDetectAttachedPoisons(itemKey))
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte poisonType = argGroup.PoisonType;
		if (poisonType < 0)
		{
			return false;
		}
		int poisonVal = character.GetPoisoned().Get(poisonType);
		sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonVal);
		ItemKey selectedItemKey = ItemKey.Invalid;
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		context.AdvanceMonthRelatedData.CategorizedRegenItems(actionData.TargetChar.GetInventory().Items);
		List<(GameData.Domains.Item.Medicine, int)> medicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get()[4];
		medicines.Sort(targetChar.CompareDetoxPoisonMedicines);
		int selectedIndex = character.SelectMedicineIndexForDetoxPoison(medicines, poisonType, poisonLevel, poisonVal);
		if (selectedIndex >= 0)
		{
			selectedItemKey = medicines[selectedIndex].Item1.GetItemKey();
		}
		context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		if (!selectedItemKey.IsValid())
		{
			throw new Exception($"Fail to find valid medicine for detox {poisonType} in {targetChar}'s inventory to cure {this}.");
		}
		sbyte behaviorType = targetChar.GetBehaviorType();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(behaviorType, favorabilityType);
		ItemUsed = selectedItemKey;
		PoisonType = poisonType;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		PoisonInts poisoned = character.GetPoisoned();
		if (poisoned.Get(PoisonType) > 0 && actionData.TargetChar.GetInventory().Items.ContainsKey(ItemUsed))
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
		monthlyEventCollection.AddRequestHealPoisonByItem(selfCharId, location, actionData.TargetCharId, (ulong)ItemUsed, PoisonType);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (AgreeToRequest)
		{
			if (ItemUsed.ItemType != 8)
			{
				throw new Exception($"Invalid item type {ItemUsed} to detox poison for {character.GetId()}");
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(ItemUsed);
			actionData.TargetChar.RemoveInventoryItem(context, ItemUsed, 1, deleteItem: false);
			character.AddEatingItem(context, ItemUsed);
			character.ChangeHappiness(context, baseItem.GetHappinessChange());
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, actionData.TargetChar, baseItem.GetFavorabilityChange() * 5);
			lifeRecordCollection.AddRequestDetoxPoisonItemSucceed(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId, PoisonType);
			int secretInfoOffset = secretInformationCollection.AddAcceptRequestDetoxPoison(targetCharId, selfCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			character.ChangeHappiness(context, -3);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, actionData.TargetChar, -6000);
			lifeRecordCollection.AddRequestDetoxPoisonItemFail(selfCharId, currDate, targetCharId, location, ItemUsed.ItemType, ItemUsed.TemplateId, PoisonType);
			int secretInfoOffset2 = secretInformationCollection.AddRefuseRequestDetoxPoison(targetCharId, selfCharId);
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
		*pCurrData = (byte)PoisonType;
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
			PoisonType = (sbyte)(*pCurrData);
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

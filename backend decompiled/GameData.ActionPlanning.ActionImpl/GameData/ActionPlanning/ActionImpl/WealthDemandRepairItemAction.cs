using System;
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
public class WealthDemandRepairItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort AgreeToRequest = 1;

		public const ushort ToolUsed = 2;

		public const ushort ResourceType = 3;

		public const ushort ResourceAmount = 4;

		public const ushort ToolDurabilityCost = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "TargetItem", "AgreeToRequest", "ToolUsed", "ResourceType", "ResourceAmount", "ToolDurabilityCost" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey ToolUsed;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 4)]
	public int ResourceAmount;

	[SerializableGameDataField(FieldIndex = 5)]
	public short ToolDurabilityCost;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		sbyte itemType = args.ItemType;
		int itemId = args.ItemId;
		ItemBase baseItem = DomainManager.Item.GetBaseItem(new ItemKey(itemType, 0, 0, itemId));
		ItemKey itemKey = baseItem.GetItemKey();
		sbyte grade = baseItem.GetGrade();
		short currDurability = baseItem.GetCurrDurability();
		sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
		short attainmentRequired = ItemTemplateHelper.GetRepairRequiredAttainment(itemKey.ItemType, itemKey.TemplateId, currDurability);
		sbyte requiredResourceType = ItemTemplateHelper.GetCraftRequiredResourceType(itemKey.ItemType, itemKey.TemplateId);
		int requiredResourceAmount = ItemTemplateHelper.GetRepairNeedResourceCount(DomainManager.Item.GetBaseEquipment(itemKey).GetMaterialResources(), itemKey, currDurability);
		if (targetChar.GetResource(requiredResourceType) < requiredResourceAmount)
		{
			return false;
		}
		short characterAttainment = targetChar.GetLifeSkillAttainment(requiredLifeSkillType);
		foreach (ItemKey toolItemKey in targetChar.GetInventory().Items.Keys)
		{
			if (toolItemKey.ItemType == 6)
			{
				ItemBase baseItem2 = DomainManager.Item.GetBaseItem(toolItemKey);
				CraftToolItem cfg = Config.CraftTool.Instance[toolItemKey.TemplateId];
				short cost = cfg.DurabilityCost[grade];
				if (baseItem2.GetCurrDurability() >= cost && cfg.RequiredLifeSkillTypes.Contains(requiredLifeSkillType) && characterAttainment + cfg.AttainmentBonus >= attainmentRequired)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte itemType = argGroup.ItemType;
		int itemId = argGroup.ItemId;
		ItemBase itemToRepair = DomainManager.Item.GetBaseItem(new ItemKey(itemType, 0, 0, itemId));
		ItemKey itemKey = itemToRepair.GetItemKey();
		short currDurability = itemToRepair.GetCurrDurability();
		sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
		short attainmentRequired = ItemTemplateHelper.GetRepairRequiredAttainment(itemKey.ItemType, itemKey.TemplateId, currDurability);
		sbyte requiredResourceType = ItemTemplateHelper.GetCraftRequiredResourceType(itemKey.ItemType, itemKey.TemplateId);
		int requiredResourceAmount = ItemTemplateHelper.GetRepairNeedResourceCount(DomainManager.Item.GetBaseEquipment(itemKey).GetMaterialResources(), itemKey, currDurability);
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetChar.GetBehaviorType(), favorabilityType);
		short targetCharAttainment = targetChar.GetLifeSkillAttainment(requiredLifeSkillType);
		short durabilityCost;
		ItemKey selectedTool = targetChar.GetInventory().GetWorstUsableCraftTool(requiredLifeSkillType, attainmentRequired, targetCharAttainment, itemToRepair.GetGrade(), out durabilityCost);
		if (!selectedTool.IsValid())
		{
			throw new Exception($"Failed to find target tool to repair {itemToRepair} in selected character {targetChar}'s inventory for {character}.");
		}
		TargetItem = itemKey;
		ToolUsed = selectedTool;
		ResourceType = requiredResourceType;
		ResourceAmount = requiredResourceAmount;
		AgreeToRequest = context.Random.CheckPercentProb(respondChance);
		ToolDurabilityCost = durabilityCost;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (character.GetInventory().Items.ContainsKey(TargetItem) && actionData.TargetChar.GetInventory().Items.ContainsKey(ToolUsed))
		{
			return actionData.TargetChar.GetResource(ResourceType) >= ResourceAmount;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestRepairItem(selfCharId, location, targetCharId, (ulong)TargetItem, (ulong)ToolUsed, ResourceAmount, ResourceType);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		if (AgreeToRequest)
		{
			GameData.Domains.Item.CraftTool element_CraftTools = DomainManager.Item.GetElement_CraftTools(ToolUsed.Id);
			ItemBase itemToRepair = DomainManager.Item.GetBaseItem(TargetItem);
			ItemBase.OfflineRepairItem(element_CraftTools, itemToRepair, itemToRepair.GetMaxDurability(), ToolDurabilityCost);
			itemToRepair.SetCurrDurability(itemToRepair.GetCurrDurability(), context);
			element_CraftTools.SetCurrDurability(element_CraftTools.GetCurrDurability(), context);
			targetChar.ChangeResource(context, ResourceType, -ResourceAmount);
			int favorabilityChange = itemToRepair.GetFavorabilityChange();
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorabilityChange);
			character.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
			lifeRecordCollection.AddRequestRepairItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestRepairItem(targetCharId, selfCharId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			character.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestRepairItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestRepairItem(targetCharId, selfCharId, (ulong)TargetItem);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize += TargetItem.GetSerializedSize();
		totalSize += ToolUsed.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 6;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize2 = ToolUsed.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*pCurrData = (byte)ResourceType;
		pCurrData++;
		*(int*)pCurrData = ResourceAmount;
		pCurrData += 4;
		*(short*)pCurrData = ToolDurabilityCost;
		pCurrData += 2;
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
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			pCurrData += ToolUsed.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			ResourceType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			ResourceAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			ToolDurabilityCost = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

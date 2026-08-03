using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusRepairAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ActionResourceType = 0;

		public const ushort Amount = 1;

		public const ushort ToolUsed = 2;

		public const ushort RepairedItem = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "ActionResourceType", "Amount", "ToolUsed", "RepairedItem" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ActionResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey ToolUsed;

	[SerializableGameDataField(FieldIndex = 3)]
	public ItemKey RepairedItem;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		if (!targetChar.GetInventory().Items.Keys.Any(NeedRepair))
		{
			return targetChar.GetEquipment().Any(NeedRepair);
		}
		return true;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (NeedRepair(itemKey))
			{
				itemKeys.Add(itemKey);
			}
		}
		ItemKey[] equipment = targetChar.GetEquipment();
		foreach (ItemKey itemKey2 in equipment)
		{
			if (NeedRepair(itemKey2))
			{
				itemKeys.Add(itemKey2);
			}
		}
		ItemKey selectedItemKey = itemKeys.GetRandom(context.Random);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
		short currDurability = DomainManager.Item.GetBaseItem(selectedItemKey).GetCurrDurability();
		sbyte requiredResourceType = 6;
		int requiredMoney = ItemTemplateHelper.GetRepairNeedResourceCount(DomainManager.Item.GetBaseEquipment(selectedItemKey).GetMaterialResources(), selectedItemKey, currDurability);
		if (!targetChar.CheckResources(context, requiredResourceType, requiredMoney))
		{
			return false;
		}
		sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(selectedItemKey.ItemType, selectedItemKey.TemplateId);
		short attainmentRequired = ItemTemplateHelper.GetRepairRequiredAttainment(selectedItemKey.ItemType, selectedItemKey.TemplateId, currDurability);
		short charAttainment = character.GetLifeSkillAttainment(requiredLifeSkillType);
		itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (ItemKey itemKey3 in character.GetInventory().Items.Keys)
		{
			if (itemKey3.ItemType == 6 && DomainManager.Item.GetBaseItem(itemKey3).GetCurrDurability() > 0)
			{
				CraftToolItem cfg = Config.CraftTool.Instance[itemKey3.TemplateId];
				if (charAttainment + cfg.AttainmentBonus >= attainmentRequired && cfg.RequiredLifeSkillTypes.Contains(requiredLifeSkillType))
				{
					itemKeys.Add(itemKey3);
				}
			}
		}
		ItemKey selectedToolKey = itemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
		if (!selectedItemKey.IsValid())
		{
			return false;
		}
		RepairedItem = selectedItemKey;
		ToolUsed = selectedToolKey;
		ActionResourceType = requiredResourceType;
		Amount = requiredMoney;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (character.GetResource(ActionResourceType) >= Amount && character.GetInventory().Items.ContainsKey(ToolUsed) && DomainManager.Item.GetBaseItem(ToolUsed).GetCurrDurability() > 0)
		{
			return actionData.TargetChar.GetInventory().Items.ContainsKey(RepairedItem);
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddAdviseRepairItem(selfCharId, location, actionData.TargetCharId, (ulong)RepairedItem, (ulong)ToolUsed, ActionResourceType, Amount);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		character.ChangeResource(context, ActionResourceType, Amount);
		ItemBase baseItem = DomainManager.Item.GetBaseItem(RepairedItem);
		baseItem.SetCurrDurability(baseItem.GetMaxDurability(), context);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, 3000);
		lifeRecordCollection.AddRepairItemSucceed(selfCharId, currDate, targetCharId, location);
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRepairItem(selfCharId, targetCharId, (ulong)RepairedItem);
		DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
	}

	private static bool NeedRepair(ItemKey itemKey)
	{
		if (!itemKey.IsValid())
		{
			return false;
		}
		ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
		short currDurability = baseItem.GetCurrDurability();
		if (baseItem.GetRepairable() && currDurability > 0)
		{
			return currDurability < baseItem.GetMaxDurability() / 2;
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize += ToolUsed.GetSerializedSize();
		totalSize += RepairedItem.GetSerializedSize();
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
		*pCurrData = (byte)ActionResourceType;
		pCurrData++;
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		int fieldSize = ToolUsed.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = RepairedItem.Serialize(pCurrData);
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
			ActionResourceType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			pCurrData += ToolUsed.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			pCurrData += RepairedItem.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

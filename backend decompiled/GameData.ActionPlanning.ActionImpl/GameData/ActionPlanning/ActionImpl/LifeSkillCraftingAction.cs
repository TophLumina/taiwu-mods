using System;
using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class LifeSkillCraftingAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ToolUsed = 0;

		public const ushort Material = 1;

		public const ushort RequiredMoney = 2;

		public const ushort TargetItemType = 3;

		public const ushort TargetItemTemplateId = 4;

		public const ushort ActionLifeSkillType = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "ToolUsed", "Material", "RequiredMoney", "TargetItemType", "TargetItemTemplateId", "ActionLifeSkillType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey ToolUsed;

	[SerializableGameDataField(FieldIndex = 1)]
	public ItemKey Material;

	[SerializableGameDataField(FieldIndex = 2)]
	public int RequiredMoney;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte TargetItemType;

	[SerializableGameDataField(FieldIndex = 4)]
	public short TargetItemTemplateId;

	[SerializableGameDataField(FieldIndex = 5)]
	public sbyte ActionLifeSkillType;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (character.GetInventory().Items.Count <= 1)
		{
			return false;
		}
		if (!context.Random.CheckPercentProb(50 + character.GetPersonality(2)))
		{
			return false;
		}
		Span<sbyte> craftingLifeSkillTypes = stackalloc sbyte[GameData.Domains.Character.LifeSkillType.CraftingTypes.Length];
		int craftingLifeSkillTypeCount = 0;
		sbyte[] craftingTypes = GameData.Domains.Character.LifeSkillType.CraftingTypes;
		foreach (sbyte lifeSkillType in craftingTypes)
		{
			if (character.GetLifeSkillAttainment(lifeSkillType) >= 200)
			{
				craftingLifeSkillTypes[craftingLifeSkillTypeCount] = lifeSkillType;
				craftingLifeSkillTypeCount++;
			}
		}
		if (craftingLifeSkillTypeCount == 0)
		{
			return false;
		}
		CollectionUtils.Shuffle(context.Random, craftingLifeSkillTypes, craftingLifeSkillTypeCount);
		List<ItemKey> materials = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		for (int j = 0; j < craftingLifeSkillTypeCount; j++)
		{
			sbyte lifeSkillType2 = craftingLifeSkillTypes[j];
			character.GetInventory().GetCraftMaterials(lifeSkillType2, materials);
			if (materials.Count == 0)
			{
				continue;
			}
			ItemKey selectedMaterial = materials.GetRandom(context.Random);
			MaterialItem selectedMaterialCfg = Config.Material.Instance[selectedMaterial.TemplateId];
			short durabilityCost;
			ItemKey bestTool = character.GetInventory().GetBestCraftTool(lifeSkillType2, selectedMaterialCfg.Grade, out durabilityCost);
			if (!bestTool.IsValid())
			{
				continue;
			}
			short makeItemType = selectedMaterialCfg.CraftableItemTypes.GetRandom(context.Random);
			List<short> makeItemSubTypeList = MakeItemType.Instance[makeItemType].MakeItemSubTypes;
			short makeItemSubType = makeItemSubTypeList.GetRandom(context.Random);
			MakeItemSubTypeItem makeItemSubTypeCfg = MakeItemSubType.Instance[makeItemSubType];
			int requiredMoney = GetMakeItemRequiredResourceWorth(selectedMaterialCfg, makeItemSubTypeCfg) * OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo()).PurchaseItemDiscount / 100;
			if (character.GetResource(6) >= requiredMoney)
			{
				int allPagesReadCookingSkillBookCount = character.GetAllPagesReadCookingSkillBookCount();
				short attainment = (short)(character.GetLifeSkillAttainment(lifeSkillType2) + Config.CraftTool.Instance[bestTool.TemplateId].AttainmentBonus);
				(sbyte, short) makeResult = DomainManager.Building.GetMakeResultTargetItemGradeAndTemplateId(selectedMaterial.TemplateId, attainment, lifeSkillType2, makeItemSubTypeList, makeItemSubType, allPagesReadCookingSkillBookCount, context.Random, upgradeMakeItem: false, 0);
				if (makeResult.Item2 >= 0)
				{
					ToolUsed = bestTool;
					Material = selectedMaterial;
					RequiredMoney = requiredMoney;
					ActionLifeSkillType = lifeSkillType2;
					TargetItemType = makeItemSubTypeCfg.Result.ItemType;
					TargetItemTemplateId = makeResult.Item2;
					break;
				}
			}
		}
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref materials);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		Inventory inventory = character.GetInventory();
		if (inventory.Items.ContainsKey(ToolUsed) && inventory.Items.ContainsKey(Material))
		{
			return character.GetResource(6) >= RequiredMoney;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		int selfCharId = character.GetId();
		character.ChangeResource(context, 6, -RequiredMoney);
		character.RemoveInventoryItem(context, Material, 1, deleteItem: true);
		GameData.Domains.Item.CraftTool tool = DomainManager.Item.GetElement_CraftTools(ToolUsed.Id);
		CraftToolItem craftToolItem = Config.CraftTool.Instance[ToolUsed.TemplateId];
		MaterialItem materialConfig = Config.Material.Instance[Material.TemplateId];
		short durabilityCost = craftToolItem.DurabilityCost[materialConfig.Grade];
		if (tool.GetCurrDurability() <= durabilityCost)
		{
			character.RemoveInventoryItem(context, ToolUsed, 1, deleteItem: true);
		}
		else
		{
			tool.ChangeCurrDurability(context, -durabilityCost);
		}
		ItemKey item = DomainManager.Item.CreateItem(context, TargetItemType, TargetItemTemplateId);
		character.AddInventoryItem(context, item, 1);
		if (ItemTemplateHelper.GetGrade(TargetItemType, TargetItemTemplateId) >= 6)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddMakeFamousItem(selfCharId, location, TargetItemType, TargetItemTemplateId);
			character.RecordFameAction(context, 77, -1, 1);
		}
		lifeRecordCollection.AddMakeItem(selfCharId, currDate, location, TargetItemType, TargetItemTemplateId);
	}

	private int GetMakeItemRequiredResourceWorth(MaterialItem materialCfg, MakeItemSubTypeItem makeItemSubTypeCfg)
	{
		return GlobalConfig.ResourcesWorth[materialCfg.ResourceType] * makeItemSubTypeCfg.ResourceTotalCount * materialCfg.RequiredResourceAmount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize += ToolUsed.GetSerializedSize();
		totalSize += Material.GetSerializedSize();
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
		int fieldSize = ToolUsed.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int fieldSize2 = Material.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		*(int*)pCurrData = RequiredMoney;
		pCurrData += 4;
		*pCurrData = (byte)TargetItemType;
		pCurrData++;
		*(short*)pCurrData = TargetItemTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)ActionLifeSkillType;
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
			pCurrData += ToolUsed.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			pCurrData += Material.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			RequiredMoney = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			TargetItemType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			TargetItemTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			ActionLifeSkillType = (sbyte)(*pCurrData);
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

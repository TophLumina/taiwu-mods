using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.TaiwuVillageStoragesRecord;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleCraftsman : VillagerRoleBase
{
	public readonly sbyte[] CraftLifeSkillTypes = new sbyte[4] { 6, 7, 10, 11 };

	public const int GainRefineMaterialGradeOffsetChance = 50;

	public const int GainRefineMaterialGradeOffset = -1;

	public override short RoleTemplateId => 1;

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId >= 0 || (WorkData != null && WorkData.WorkType == 1))
		{
			return;
		}
		bool canAutoRepairItem = base.AutoActionStates[1] && base.SettlementTreasury.Inventory.HasRepairableItem();
		bool canAutoGainRefineMaterial = base.AutoActionStates[2];
		if (canAutoRepairItem && canAutoGainRefineMaterial)
		{
			if (context.Random.Next(2) == 0)
			{
				AutoRepairItem(context);
			}
			else
			{
				AutoGainRefineMaterial(context);
			}
		}
		else if (canAutoRepairItem)
		{
			AutoRepairItem(context);
		}
		else if (canAutoGainRefineMaterial)
		{
			AutoGainRefineMaterial(context);
		}
	}

	private bool AutoRepairItem(DataContext context)
	{
		int repairCount = 0;
		int repairMaxCount = VillagerRoleFormula.DefValue.CraftsmanAutoRepairCount.Calculate(base.Personality);
		List<ItemKey> repairableItems = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		base.SettlementTreasury.Inventory.GetRepairableItem(repairableItems);
		foreach (ItemKey itemKey in repairableItems)
		{
			if (repairCount >= repairMaxCount)
			{
				break;
			}
			EquipmentBase equipment = DomainManager.Item.GetBaseEquipment(itemKey);
			sbyte requiredLifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemKey.ItemType, itemKey.TemplateId);
			if (DomainManager.Taiwu.GetTaiwuBuildingBlockData(GetLackBuildingTemplateId(requiredLifeSkillType)) == null)
			{
				continue;
			}
			short currDurability = equipment.GetCurrDurability();
			sbyte requiredResourceType = ItemTemplateHelper.GetCraftRequiredResourceType(itemKey.ItemType, itemKey.TemplateId);
			int requiredResourceAmount = ItemTemplateHelper.GetRepairNeedResourceCount(equipment.GetMaterialResources(), itemKey, currDurability);
			if (!CheckResource(requiredResourceType, requiredResourceAmount))
			{
				continue;
			}
			short attainmentRequired = ItemTemplateHelper.GetRepairRequiredAttainment(itemKey.ItemType, itemKey.TemplateId, currDurability);
			short lifeSkillAttainment = Character.GetLifeSkillAttainment(requiredLifeSkillType);
			short durabilityCost;
			ItemKey toolKey = base.SettlementTreasury.Inventory.GetWorstUsableCraftTool(requiredLifeSkillType, attainmentRequired, lifeSkillAttainment, equipment.GetGrade(), out durabilityCost);
			if (toolKey.IsValid())
			{
				GameData.Domains.Item.CraftTool craftTool = DomainManager.Item.GetElement_CraftTools(toolKey.Id);
				ItemBase.OfflineRepairItem(craftTool, equipment, equipment.GetMaxDurability(), durabilityCost);
				equipment.SetCurrDurability(equipment.GetCurrDurability(), context);
				short craftToolDurability = craftTool.GetCurrDurability();
				if (craftToolDurability <= 0)
				{
					CostItem(context, toolKey, 1, deleteItem: true);
				}
				else
				{
					craftTool.SetCurrDurability(craftToolDurability, context);
				}
				CostResource(context, requiredResourceType, requiredResourceAmount);
				int charId = Character.GetId();
				int currDate = DomainManager.World.GetCurrDate();
				Location location = Character.GetLocation();
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				lifeRecordCollection.AddVillagerRepairItem0(charId, currDate, location, itemKey.ItemType, itemKey.TemplateId);
				TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
				storageRecordCollection.AddVillagerRepairItem(currDate, TaiwuVillageStorageType.Treasury, charId, itemKey.ItemType, itemKey.TemplateId);
				repairCount++;
			}
		}
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref repairableItems);
		return repairCount > 0;
	}

	private void AutoGainRefineMaterial(DataContext context)
	{
		int gainRefineMaterialChance = VillagerRoleFormula.DefValue.CraftsmanAutoGainRefineMaterialChance.Calculate(base.Personality);
		if (context.Random.Next(100) >= gainRefineMaterialChance)
		{
			return;
		}
		Span<int> weights = stackalloc int[CraftLifeSkillTypes.Length];
		for (int i = 0; i < CraftLifeSkillTypes.Length; i++)
		{
			sbyte type = CraftLifeSkillTypes[i];
			weights[i] = Character.GetLifeSkillAttainment(type);
		}
		int index = CollectionUtils.GetRandomWeightedElement(context.Random, weights);
		sbyte lifeSkillType = CraftLifeSkillTypes[index];
		short attainment = Character.GetLifeSkillAttainment(lifeSkillType);
		int gainRefineMaterialGrade = VillagerRoleFormula.DefValue.CraftsmanAutoGainRefineMaterialGrade.Calculate(attainment);
		if (context.Random.Next(100) < 50)
		{
			gainRefineMaterialGrade += -1;
		}
		sbyte maxGrade = Config.Material.Instance.Where((MaterialItem m) => m.RequiredLifeSkillType == lifeSkillType && m.RefiningEffect >= 0).Max((MaterialItem m) => m.Grade);
		int grade = Math.Clamp(gainRefineMaterialGrade, 0, maxGrade);
		MaterialItem materialConfig = Config.Material.Instance.Where((MaterialItem m) => m.RequiredLifeSkillType == lifeSkillType && m.RefiningEffect >= 0).FirstOrDefault((MaterialItem m) => m.Grade == grade);
		if (materialConfig == null)
		{
			return;
		}
		int charId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
		if (grade < maxGrade && base.HasChickenUpgradeEffect && base.AutoActionStates[3])
		{
			int updateChance = VillagerRoleFormula.DefValue.CraftsmanChikenUpgradeAutoGainRefineMaterialGrade.Calculate(base.Personality);
			if (context.Random.Next(100) < updateChance)
			{
				int upgradeGrade = Math.Clamp(grade + 1, 0, maxGrade);
				MaterialItem updateMaterialConfig = Config.Material.Instance.Where((MaterialItem m) => m.RequiredLifeSkillType == lifeSkillType && m.RefiningEffect >= 0).FirstOrDefault((MaterialItem m) => m.Grade == upgradeGrade);
				if (updateMaterialConfig != null && updateMaterialConfig.RequiredAttainment <= attainment)
				{
					ItemKey upgradeItemKey = DomainManager.Item.CreateMaterial(context, updateMaterialConfig.TemplateId);
					GainItem(context, upgradeItemKey, 1);
					lifeRecordCollection.AddVillagerUpgradeRefineItem(charId, currDate, materialConfig.ItemType, materialConfig.TemplateId, upgradeItemKey.ItemType, upgradeItemKey.TemplateId);
					storageRecordCollection.AddVillagerUpgradeRefineItem1(currDate, TaiwuVillageStorageType.Treasury, charId, materialConfig.ItemType, materialConfig.TemplateId, upgradeItemKey.ItemType, upgradeItemKey.TemplateId);
					return;
				}
			}
		}
		ItemKey itemKey = DomainManager.Item.CreateMaterial(context, materialConfig.TemplateId);
		GainItem(context, itemKey, 1);
		storageRecordCollection.AddVillagerGetRefineItem(currDate, TaiwuVillageStorageType.Treasury, charId, itemKey.ItemType, itemKey.TemplateId);
		lifeRecordCollection.AddVillagerGetRefineItem(charId, currDate, itemKey.ItemType, itemKey.TemplateId);
	}

	private short GetLackBuildingTemplateId(sbyte lifeSkillType)
	{
		bool condition = (((uint)(lifeSkillType - 6) <= 1u || (uint)(lifeSkillType - 10) <= 1u) ? true : false);
		Tester.Assert(condition);
		return lifeSkillType switch
		{
			6 => 129, 
			7 => 139, 
			10 => 169, 
			_ => 179, 
		};
	}
}

using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class ParallelBuildingModification
{
	public BuildingBlockKey BlockKey;

	public BuildingBlockData BlockData;

	public List<TemplateKey> CollectableEarnings;

	public List<IntPair> CollectableResources;

	public List<(sbyte index, IntPair exchangeResource)> ShopSoldItems;

	public List<IntPair> RecruitLevelList;

	public List<ItemKey> FixBookList;

	public List<(int charId, short skillTemplateId, byte pageId)> LearnLifeSkills;

	public List<(int charId, short skillTemplateId, byte pageInternalIndex)> LearnCombatSkills;

	public List<(int charId, sbyte resourceType, int addCount)> ShopBuildingSalaryList;

	public Dictionary<BuildingBlockKey, int> BuildingMoneyPrestigeSuccessRateCompensationChanged;

	public bool FreeOperator = false;

	public bool FreeShopManager = false;

	public bool RemoveMakeItemData = false;

	public bool ResetAllChildrenBlocks = false;

	public bool RemoveCollectResourceType = false;

	public bool RemoveEventBookData = false;

	public bool BuildingOperationComplete = false;

	public bool RemoveResidence;

	public bool AddBuilding;

	public bool ExpandBuilding;

	public ResourceInts DeltaResources;

	public unsafe void SetResource(sbyte resourceType, int count)
	{
		DeltaResources.Items[resourceType] = count;
	}

	public unsafe int GetResource(sbyte resourceType)
	{
		return DeltaResources.Items[resourceType];
	}

	public void AddCollectableEarning(TemplateKey templateKey)
	{
		if (CollectableEarnings == null)
		{
			CollectableEarnings = new List<TemplateKey>();
		}
		CollectableEarnings.Add(templateKey);
	}

	public void AddCollectableResources(sbyte resourceType, int amount)
	{
		if (CollectableResources == null)
		{
			CollectableResources = new List<IntPair>();
		}
		CollectableResources.Add(new IntPair(resourceType, amount));
	}

	public void AddShopSalaryResources(int charId, sbyte resourceType, int amount)
	{
		if (ShopBuildingSalaryList == null)
		{
			ShopBuildingSalaryList = new List<(int, sbyte, int)>();
		}
		ShopBuildingSalaryList.Add((charId, resourceType, amount));
	}

	public void AddLearnCombatSkill(int charId, short templateId, byte pageInternalIndex)
	{
		if (LearnCombatSkills == null)
		{
			LearnCombatSkills = new List<(int, short, byte)>();
		}
		LearnCombatSkills.Add((charId, templateId, pageInternalIndex));
	}

	public void AddLearnLifeSkill(int charId, short templateId, byte pageId)
	{
		if (LearnLifeSkills == null)
		{
			LearnLifeSkills = new List<(int, short, byte)>();
		}
		LearnLifeSkills.Add((charId, templateId, pageId));
	}
}

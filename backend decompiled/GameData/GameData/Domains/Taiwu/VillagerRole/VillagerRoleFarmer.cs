using System;
using Config;
using Config.Common;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization.TaiwuVillageStoragesRecord;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleFarmer : VillagerRoleBase
{
	private static class FieldIds
	{
		public const ushort ArrangementTemplateId = 0;

		public const ushort FarmerStorageTypes = 1;

		public const ushort MigrateFailureInfo = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ArrangementTemplateId", "FarmerStorageTypes", "MigrateFailureInfo" };
	}

	public const int MapBlockRecoveryLockDuration = 120;

	[Obsolete]
	[SerializableGameDataField]
	public sbyte[] FarmerStorageTypes;

	[SerializableGameDataField]
	public (sbyte resourceType, int count) MigrateFailureInfo;

	public override short RoleTemplateId => 0;

	public int CollectResourceActionCount => VillagerRoleFormula.DefValue.FarmerAutoCollectActionCount.Calculate(base.Personality);

	public int MigrateResourceSuccessRate => MigrateResourceBaseSuccessRate * (CValuePercentBonus)DomainManager.Building.GetBuildingBlockEffect(Character.GetOrganizationInfo().SettlementId, EBuildingScaleEffect.MigrateSpeedBonusFactor) + MigrateResourceSuccessRateBonus;

	public int MigrateResourceBaseSuccessRate => VillagerRoleFormula.DefValue.FarmerMigrateResourceSuccessRate.Calculate(base.Personality);

	public int MigrateResourceSuccessRateBonus => VillagerRoleFormula.DefValue.FarmerMigrateResourceExtraSuccessRate.Calculate(base.Personality, MigrateFailureInfo.count);

	public int UpgradeBuildingCoreRate => VillagerRoleFormula.DefValue.FarmerChickenUpgradeBuildingCoreRate.Calculate(base.Personality);

	public VillagerRoleFarmer()
	{
		FarmerStorageTypes = new sbyte[6];
		for (int i = 0; i < FarmerStorageTypes.Length; i++)
		{
			FarmerStorageTypes[i] = 1;
		}
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId >= 0)
		{
			return;
		}
		VillagerWorkData workData = WorkData;
		bool flag;
		if (workData != null)
		{
			sbyte workType = workData.WorkType;
			if (workType == 1 || workType == 10 || workType == 14)
			{
				flag = true;
				goto IL_003e;
			}
		}
		flag = false;
		goto IL_003e;
		IL_003e:
		if (!flag && base.AutoActionStates[0])
		{
			int i = CollectResourceActionCount - 1;
			while (i >= 0 && AutoCollectResourceAction(context))
			{
				i--;
			}
		}
	}

	public void ResetFailureAccumulation()
	{
		MigrateFailureInfo = (resourceType: -1, count: 0);
	}

	public void RefreshFailureAccumulation(sbyte resourceType)
	{
		if (resourceType == -1 || MigrateFailureInfo.resourceType != resourceType)
		{
			MigrateFailureInfo = (resourceType: resourceType, count: 0);
		}
	}

	public void AccumulateMigrateFailure()
	{
		MigrateFailureInfo.count++;
	}

	private static bool CollectResourceBlockFilter(MapBlockData block)
	{
		if (block.GetConfig().ResourceCollectionType < 0)
		{
			return false;
		}
		for (sbyte i = 0; i < 6; i++)
		{
			short maxResource = block.MaxResources[i];
			if (maxResource > 0 && block.CurrResources[i] >= block.MaxResources[i] / 2)
			{
				return true;
			}
		}
		return false;
	}

	public int GetCollectResourceAmount(MapBlockData block, sbyte resourceType)
	{
		return block.GetCollectResourceAmount(resourceType) * (CValuePercentBonus)DomainManager.Building.GetBuildingBlockEffect(block.GetLocation(), EBuildingScaleEffect.CollectResourceIncomeBonus);
	}

	public bool CollectResource(DataContext context, MapBlockData block, sbyte resourceType, bool isAuto = false)
	{
		if (!block.CanCollectResource(resourceType))
		{
			return false;
		}
		int addResource = GetCollectResourceAmount(block, resourceType);
		if (isAuto)
		{
			addResource = VillagerRoleFormula.DefValue.FarmerAutoCollectActionResult.Calculate(addResource);
			ResourceTypeItem resourceConfig = ResourceType.Instance[resourceType];
			short currentResource = block.CurrResources[resourceType];
			block.CurrResources[resourceType] = (short)Math.Max(currentResource - resourceConfig.ResourceReducePerCollection / 5, 0);
		}
		GainResource(context, resourceType, addResource);
		short maxMalice = block.GetMaxMalice();
		if (maxMalice <= 0)
		{
			DomainManager.Map.SetBlockData(context, block);
			return true;
		}
		block.Malice = (short)Math.Clamp(block.Malice + 10, 0, block.GetMaxMalice());
		DomainManager.Map.SetBlockData(context, block);
		return true;
	}

	private bool AutoCollectResourceAction(DataContext context)
	{
		Location location = Character.GetLocation();
		MapBlockData block = DomainManager.Map.GetBlock(location);
		Span<sbyte> span = stackalloc sbyte[8];
		SpanList<sbyte> availableResources = span;
		for (sbyte i = 0; i < 6; i++)
		{
			if (block.CurrResources[i] >= block.MaxResources[i] / 2)
			{
				availableResources.Add(i);
			}
		}
		if (availableResources.Count == 0)
		{
			TryAddNextAutoTravelTarget(context, CollectResourceBlockFilter);
			return false;
		}
		sbyte resourceType = availableResources.GetRandom(context.Random);
		bool res = CollectResource(context, block, resourceType, isAuto: true);
		if (res)
		{
			CollectMaterial(context, block, resourceType);
		}
		return res;
	}

	private void CollectMaterial(DataContext context, MapBlockData blockData, sbyte resourceType)
	{
		short itemTemplateId = blockData.GetCollectItemTemplateId(context.Random, resourceType);
		int chance = blockData.GetCollectItemChance(resourceType) * 20 / 100;
		if (itemTemplateId >= 0 && context.Random.CheckPercentProb(chance))
		{
			ResourceCollectionItem collectionConfig = blockData.GetResourceCollectionConfig();
			short maxResource = Math.Max(blockData.MaxResources.Get(resourceType), (short)1);
			short currentResource = blockData.CurrResources.Get(resourceType);
			DomainManager.Map.UpgradeCollectMaterial(context.Random, collectionConfig, resourceType, maxResource, currentResource, 1, ref itemTemplateId);
			TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			int charId = Character.GetId();
			ItemKey itemKey = DomainManager.Item.CreateItem(context, 5, itemTemplateId);
			ItemSourceType target = (ItemSourceType)DomainManager.Extra.GetFarmerAutoCollectStorageType();
			if (target != ItemSourceType.Warehouse && target != ItemSourceType.Treasury && target != ItemSourceType.Stock)
			{
				target = ItemSourceType.Warehouse;
			}
			DomainManager.Taiwu.AddItem(context, itemKey, 1, target);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddFarmerCollectMaterial(charId, currDate, Character.GetLocation(), 5, itemTemplateId);
			switch (target)
			{
			case ItemSourceType.Warehouse:
				storageRecordCollection.AddGatherResources(currDate, TaiwuVillageStorageType.Warehouse, charId, 5, itemTemplateId);
				break;
			case ItemSourceType.Treasury:
				storageRecordCollection.AddGatherResourcesToTreasury(currDate, TaiwuVillageStorageType.Treasury, charId, 5, itemTemplateId);
				break;
			case ItemSourceType.Stock:
				storageRecordCollection.AddGatherResourcesToStockStorageGoodsShelf(currDate, TaiwuVillageStorageType.Stock, charId, 5, itemTemplateId);
				break;
			case ItemSourceType.Trough:
				break;
			}
		}
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new FarmerDisplayData
		{
			CollectResourceActionCount = CollectResourceActionCount,
			MigrateResourceSuccessRate = MigrateResourceSuccessRate,
			MigrateResourceBaseSuccessRate = MigrateResourceBaseSuccessRate,
			MigrateResourceSuccessRateBonus = MigrateResourceSuccessRateBonus,
			MigrateResourceSuccessRateBuildingBonus = DomainManager.Building.GetBuildingBlockEffect(Character.GetOrganizationInfo().SettlementId, EBuildingScaleEffect.MigrateSpeedBonusFactor),
			UpgradeBuildingCoreRate = UpgradeBuildingCoreRate
		};
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((FarmerStorageTypes == null) ? (totalSize + 2) : (totalSize + (2 + FarmerStorageTypes.Length)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		if (FarmerStorageTypes != null)
		{
			int elementsCount = FarmerStorageTypes.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)FarmerStorageTypes[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.Serialize(pCurrData, MigrateFailureInfo);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ArrangementTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (FarmerStorageTypes == null || FarmerStorageTypes.Length != elementsCount)
				{
					FarmerStorageTypes = new sbyte[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					FarmerStorageTypes[i] = (sbyte)pCurrData[i];
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				FarmerStorageTypes = null;
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.Deserialize(pCurrData, out MigrateFailureInfo);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

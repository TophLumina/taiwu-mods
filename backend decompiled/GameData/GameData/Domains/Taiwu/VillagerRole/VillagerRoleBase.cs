using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public abstract class VillagerRoleBase : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ArrangementTemplateId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ArrangementTemplateId" };
	}

	[SerializableGameDataField]
	public int ArrangementTemplateId = -1;

	public GameData.Domains.Character.Character Character;

	public VillagerWorkData WorkData;

	public abstract short RoleTemplateId { get; }

	public short OrgMemberTemplateId => RoleConfig.OrganizationMember;

	public bool HasChickenUpgradeEffect => DomainManager.Building.HasFulongChicken(RoleConfig);

	public VillagerRoleItem RoleConfig => Config.VillagerRole.Instance[RoleTemplateId];

	public bool IsInTaiwuVillageInfluenceRange => DomainManager.Map.IsLocationInSettlementInfluenceRange(Character.GetLocation(), DomainManager.Taiwu.GetTaiwuVillageSettlementId());

	public int Personality => Character.GetPersonality(RoleConfig.PersonalityType);

	public BoolArray64 AutoActionStates => DomainManager.Extra.GetElement_VillagerRoleAutoActionStates(RoleTemplateId);

	public SettlementTreasury SettlementTreasury => DomainManager.Taiwu.GetTaiwuTreasury();

	public virtual void OfflineSetArrangement(short arrangementTemplateId, Location location)
	{
		ArrangementTemplateId = arrangementTemplateId;
		WorkData = new VillagerWorkData(Character.GetId(), 2, location.AreaId, location.BlockId);
	}

	public virtual void Initialize(int charId)
	{
		DomainManager.Character.TryGetElement_Objects(charId, out Character);
		DomainManager.Taiwu.TryGetElement_VillagerWork(charId, out WorkData);
	}

	public virtual void ExecuteFixedAction(DataContext context)
	{
	}

	protected virtual void TryAddNextAutoTravelTarget(DataContext context, Predicate<MapBlockData> condition)
	{
		if (Character.GetNpcTravelTargets().Count > 0)
		{
			return;
		}
		Location location = Character.GetLocation();
		if (!location.IsValid() || !condition(DomainManager.Map.GetBlock(location)))
		{
			Location villageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
			MapBlockData targetBlock = DomainManager.Map.SelectBlockInCurrentOrNeighborState(context.Random, villageLocation, condition);
			if (targetBlock != null)
			{
				NpcTravelTarget travelTarget = new NpcTravelTarget(targetBlock.GetLocation(), 12);
				Character.AddTravelTarget(context, travelTarget);
			}
		}
	}

	public virtual bool GetExecuteFixedActionFailReasons(DataContext context, sbyte fixedActionType, ref List<sbyte> failReasons)
	{
		return false;
	}

	public virtual Func<DataContext, bool, bool> GetFixedActionByType(sbyte fixedActionType)
	{
		return null;
	}

	public virtual void AddLifeRecordByFailReasons(List<sbyte> failReasons, sbyte fixedActionType)
	{
	}

	public void AddFailReasonsDistinct(bool realAction, ref List<sbyte> failReasons, sbyte failType)
	{
		if (!failReasons.Contains(failType))
		{
			failReasons.Add(failType);
		}
	}

	public Settlement GetCurrentSettlement()
	{
		Location location = Character.GetLocation();
		if (!location.IsValid())
		{
			return null;
		}
		MapBlockData settlementBlock = DomainManager.Map.GetBelongSettlementBlock(location);
		return (settlementBlock == null) ? null : DomainManager.Organization.GetSettlementByLocation(settlementBlock.GetLocation());
	}

	public virtual IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return null;
	}

	public bool IsWorkingAtArrangementLocation()
	{
		return false;
	}

	public bool CheckResource(sbyte requiredResourceType, int requiredResourceAmount)
	{
		int storageResourceAmount = SettlementTreasury.Resources.Get(requiredResourceType);
		return storageResourceAmount >= requiredResourceAmount;
	}

	public void CostResource(DataContext context, sbyte resourceType, int resourceAmount)
	{
		SettlementTreasury.Resources.Subtract(resourceType, resourceAmount);
		DomainManager.Taiwu.SetNeedCommitSettlementTreasury(needCommit: true);
	}

	public void GainResource(DataContext context, sbyte resourceType, int resourceAmount)
	{
		SettlementTreasury.Resources.Add(resourceType, resourceAmount);
		DomainManager.Taiwu.SetNeedCommitSettlementTreasury(needCommit: true);
	}

	public void CostItem(DataContext context, ItemKey itemKey, int amount, bool deleteItem = false)
	{
		DomainManager.Taiwu.RemoveItem(context, itemKey, amount, ItemSourceType.Treasury, deleteItem: false, offLine: true);
		DomainManager.Taiwu.SetNeedCommitSettlementTreasury(needCommit: true);
	}

	public void GainItem(DataContext context, ItemKey itemKey, int amount)
	{
		DomainManager.Taiwu.AddItem(context, itemKey, amount, ItemSourceType.Treasury, offLine: true);
		DomainManager.Taiwu.SetNeedCommitSettlementTreasury(needCommit: true);
	}

	public virtual bool IsSerializedSizeFixed()
	{
		return false;
	}

	public virtual int GetSerializedSize()
	{
		int totalSize = 6;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe virtual int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe virtual int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ArrangementTemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

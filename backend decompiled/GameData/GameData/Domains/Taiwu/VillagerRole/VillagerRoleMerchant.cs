using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization.TaiwuVillageStoragesRecord;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleMerchant : VillagerRoleBase, IVillagerRoleArrangementExecutor, IVillagerRoleSelectLocation
{
	private static class FieldIds
	{
		public const ushort ArrangementTemplateId = 0;

		public const ushort BoughtInAmount = 1;

		public const ushort ItemTemplateKey = 2;

		public const ushort DesignatedMerchantType = 3;

		public const ushort CurrentMerchantType = 4;

		public const ushort SelfDecideMerchantType = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "ArrangementTemplateId", "BoughtInAmount", "ItemTemplateKey", "DesignatedMerchantType", "CurrentMerchantType", "SelfDecideMerchantType" };
	}

	[SerializableGameDataField]
	public TemplateKey ItemTemplateKey;

	[SerializableGameDataField]
	public int BoughtInAmount;

	[SerializableGameDataField]
	public sbyte DesignatedMerchantType;

	[SerializableGameDataField]
	public sbyte SelfDecideMerchantType;

	[SerializableGameDataField]
	public sbyte CurrentMerchantType;

	public const int FluctuationAdjustmentPerMonth = 10;

	private const int ActionBlockDistanceRange = 5;

	public override short RoleTemplateId => 3;

	public sbyte InteractTargetGrade
	{
		get
		{
			int grade = VillagerRoleFormula.DefValue.MerchantInteractTargetGrade.Calculate(base.Personality);
			int maxGrade = VillagerRoleFormula.DefValue.MerchantInteractTargetMaxGrade.Calculate(DomainManager.World.GetMaxGradeOfXiangshuInfection());
			return (sbyte)Math.Min(grade, maxGrade);
		}
	}

	internal int SellPriceRate => VillagerRoleFormula.DefValue.MerchantSellItemPriceRate.Calculate(Character.GetLifeSkillAttainment(15));

	internal int BuyPriceRate => VillagerRoleFormula.DefValue.MerchantBuyItemPriceRate.Calculate(Character.GetLifeSkillAttainment(15));

	internal int AddFavorA => VillagerRoleFormula.DefValue.MerchantChickenIncreaseHeadMerchantFavor.Calculate(Character.GetLifeSkillAttainment(15), base.Personality);

	internal int AddFavorB => VillagerRoleFormula.DefValue.MerchantChickenIncreaseBranchMerchantFavor.Calculate(Character.GetLifeSkillAttainment(15), base.Personality);

	[Obsolete]
	public int SellActionRepeatChance => SharedMethods.CalculateMerchantSellActionRepeatChance(Character.GetPersonalities());

	[Obsolete]
	public int SellPricePercent => SharedMethods.CalculateMerchantSellPricePercent(Character.GetPersonalities());

	[Obsolete]
	public int BuyActionRepeatChance => SharedMethods.CalculateMerchantBuyActionRepeatChance(Character.GetPersonalities());

	[Obsolete]
	public int BuyPricePercent => SharedMethods.CalculateMerchantBuyPricePercent(Character.GetPersonalities());

	[Obsolete]
	public int PriceGougingPercentPerMonth => SharedMethods.CalculateMerchantPriceGougingPercentPerMonth(Character.GetPersonalities());

	[Obsolete]
	public int PriceGougingPercentCap => SharedMethods.CalculateMerchantPriceGougingPercentCap(Character.GetPersonalities());

	[Obsolete]
	public int PriceSuppressionPercentPerMonth => SharedMethods.CalculateMerchantPriceSuppressionPercentPerMonth(Character.GetPersonalities());

	[Obsolete]
	public int PriceSuppressionPercentCap => SharedMethods.CalculateMerchantPriceSuppressionPercentCap(Character.GetPersonalities());

	[Obsolete]
	public int UpgradedActionFavorChange => SharedMethods.CalculateMerchantUpgradedActionFavorChange(Character.GetPersonalities());

	public VillagerRoleMerchant()
	{
		DesignatedMerchantType = 7;
		CurrentMerchantType = 7;
	}

	void IVillagerRoleArrangementExecutor.ExecuteArrangementAction(DataContext context)
	{
		int arrangementTemplateId = ArrangementTemplateId;
		int num = arrangementTemplateId;
		if (num == 8)
		{
			if (ItemTemplateKey.ItemType < 0)
			{
				ApplySellAction(context);
			}
			else
			{
				ApplyBuyAction(context);
			}
		}
	}

	private void ApplySellAction(DataContext context)
	{
		int selfCharId = Character.GetId();
		Location location = Character.GetLocation();
		List<MapBlockData> blockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		blockList.Clear();
		DomainManager.Map.GetNeighborBlocks(location.AreaId, location.BlockId, blockList, 5);
		HashSet<int> charSet = ObjectPool<HashSet<int>>.Instance.Get();
		charSet.Clear();
		foreach (MapBlockData mapBlockData in blockList)
		{
			if (mapBlockData.CharacterSet == null)
			{
				continue;
			}
			foreach (int id in mapBlockData.CharacterSet)
			{
				charSet.Add(id);
			}
		}
		sbyte targetGrade = InteractTargetGrade;
		int sellPriceRate = SellPriceRate;
		Inventory inventory = DomainManager.Taiwu.Stock;
		GameData.Domains.Character.Character targetChar = Character.SelectRandomActionTarget(context, charSet, Condition);
		if (targetChar == null)
		{
			OnEnd();
			return;
		}
		List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		int availableLoad = targetChar.GetMaxInventoryLoad() - targetChar.GetCurrInventoryLoad();
		foreach (KeyValuePair<ItemKey, int> item2 in inventory.Items)
		{
			item2.Deconstruct(out var key, out var value);
			ItemKey itemKey = key;
			int amount = value;
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
			if (CheckPrice(itemKey, targetChar) && itemBase.GetWeight() <= availableLoad)
			{
				itemKeys.Add(itemKey);
			}
		}
		if (itemKeys.Count > 0)
		{
			ItemKey selectedItemKey = itemKeys.GetRandom(context.Random);
			int price = GetPrice(selectedItemKey);
			if (price > 0)
			{
				GainResource(context, 6, price);
			}
			targetChar.ChangeResource(context, 6, -price);
			DomainManager.Taiwu.RemoveItem(context, selectedItemKey, 1, ItemSourceType.Stock, deleteItem: false, offLine: true);
			targetChar.AddInventoryItem(context, selectedItemKey, 1);
			int targetCharId = targetChar.GetId();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			lifeRecordCollection.AddVillagerSoldItem(selfCharId, currDate, targetCharId, location, selectedItemKey.ItemType, selectedItemKey.TemplateId, 6, price);
			TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
			storageRecordCollection.AddVillagerSoldItem(currDate, TaiwuVillageStorageType.Stock, selfCharId, selectedItemKey.ItemType, selectedItemKey.TemplateId, price, 6);
		}
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
		if (base.HasChickenUpgradeEffect)
		{
			ApplyChickenUpgradeEffect(context);
		}
		OnEnd();
		bool CheckPrice(ItemKey itemKey2, GameData.Domains.Character.Character character)
		{
			int price2 = GetPrice(itemKey2);
			return character.CheckResources(context, 6, price2);
		}
		bool Condition(GameData.Domains.Character.Character character)
		{
			if (character.GetInteractionGrade() > targetGrade)
			{
				return false;
			}
			int availableLoad2 = character.GetMaxInventoryLoad() - character.GetCurrInventoryLoad();
			if (availableLoad2 < 0)
			{
				return false;
			}
			foreach (KeyValuePair<ItemKey, int> item3 in inventory.Items)
			{
				item3.Deconstruct(out var key2, out var value2);
				ItemKey itemKey2 = key2;
				int value3 = value2;
				ItemBase itemBase2 = DomainManager.Item.GetBaseItem(itemKey2);
				if (CheckPrice(itemKey2, character) && itemBase2.GetWeight() <= availableLoad2)
				{
					return true;
				}
			}
			return false;
		}
		int GetPrice(ItemKey itemKey2)
		{
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey2);
			return Math.Max(0, item.GetValue() * sellPriceRate / 100);
		}
		void OnEnd()
		{
			blockList.Clear();
			charSet.Clear();
			ObjectPool<List<MapBlockData>>.Instance.Return(blockList);
			ObjectPool<HashSet<int>>.Instance.Return(charSet);
		}
	}

	private void ApplyBuyAction(DataContext context)
	{
		Location location = Character.GetLocation();
		List<MapBlockData> blockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		blockList.Clear();
		DomainManager.Map.GetNeighborBlocks(location.AreaId, location.BlockId, blockList, 5);
		HashSet<int> charSet = ObjectPool<HashSet<int>>.Instance.Get();
		charSet.Clear();
		foreach (MapBlockData mapBlockData in blockList)
		{
			if (mapBlockData.CharacterSet == null)
			{
				continue;
			}
			foreach (int id in mapBlockData.CharacterSet)
			{
				charSet.Add(id);
			}
		}
		sbyte targetGrade = InteractTargetGrade;
		int buyPriceRate = BuyPriceRate;
		GameData.Domains.Character.Character targetChar = Character.SelectRandomActionTarget(context, charSet, Condition);
		if (targetChar == null)
		{
			OnEnd();
			return;
		}
		List<ItemKey> targetItemKeyList = ObjectPool<List<ItemKey>>.Instance.Get();
		targetItemKeyList.Clear();
		foreach (var (key, value) in targetChar.GetInventory().Items)
		{
			if (key.ItemType == ItemTemplateKey.ItemType && (ItemTemplateKey.TemplateId < 0 || ItemTemplateHelper.GetItemSubType(key.ItemType, key.TemplateId) == ItemTemplateKey.TemplateId) && CheckPrice(key))
			{
				targetItemKeyList.Add(key);
			}
		}
		if (targetItemKeyList.Count == 0)
		{
			ObjectPool<List<ItemKey>>.Instance.Return(targetItemKeyList);
			OnEnd();
			return;
		}
		CollectionUtils.Sort(targetItemKeyList, delegate(ItemKey a, ItemKey b)
		{
			sbyte grade = ItemTemplateHelper.GetGrade(a.ItemType, a.TemplateId);
			return ItemTemplateHelper.GetGrade(b.ItemType, b.TemplateId).CompareTo(grade);
		});
		ItemKey itemKey2 = targetItemKeyList.First();
		int price = GetPrice(itemKey2);
		targetItemKeyList.Clear();
		ObjectPool<List<ItemKey>>.Instance.Return(targetItemKeyList);
		targetChar.ChangeResource(context, 6, price);
		targetChar.RemoveInventoryItem(context, itemKey2, 1, deleteItem: false);
		CostResource(context, 6, price);
		GainItem(context, itemKey2, 1);
		BoughtInAmount++;
		DomainManager.Extra.SetVillagerRole(context, Character.GetId());
		int selfCharId = Character.GetId();
		int targetCharId = targetChar.GetId();
		Location targetLocation = targetChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddVillagerBuyItem(selfCharId, currDate, targetCharId, targetLocation, itemKey2.ItemType, itemKey2.TemplateId, 6, price);
		TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
		storageRecordCollection.AddVillagerBuyItem(currDate, TaiwuVillageStorageType.Treasury, selfCharId, price, 6, itemKey2.ItemType, itemKey2.TemplateId);
		if (base.HasChickenUpgradeEffect)
		{
			ApplyChickenUpgradeEffect(context);
		}
		OnEnd();
		static ItemKey CheckInventoryItemKey(Inventory inventory, sbyte itemType, short itemSubType)
		{
			return (itemSubType == -1) ? inventory.GetInventoryItemKeyByItemType(itemType) : inventory.GetInventoryItemKeyByItemSubType(itemSubType);
		}
		bool CheckPrice(ItemKey itemKey3)
		{
			int price2 = GetPrice(itemKey3);
			return CheckResource(6, price2);
		}
		bool Condition(GameData.Domains.Character.Character character)
		{
			if (character.GetInteractionGrade() > targetGrade)
			{
				return false;
			}
			ItemKey targetItem = CheckInventoryItemKey(character.GetInventory(), ItemTemplateKey.ItemType, ItemTemplateKey.TemplateId);
			if (!targetItem.IsValid())
			{
				return false;
			}
			if (!CheckPrice(targetItem))
			{
				return false;
			}
			return true;
		}
		int GetPrice(ItemKey itemKey3)
		{
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey3);
			return Math.Max(0, item.GetValue() * buyPriceRate / 100);
		}
		void OnEnd()
		{
			blockList.Clear();
			charSet.Clear();
			ObjectPool<List<MapBlockData>>.Instance.Return(blockList);
			ObjectPool<HashSet<int>>.Instance.Return(charSet);
		}
	}

	private void ApplyChickenUpgradeEffect(DataContext context)
	{
		MapAreaData area = DomainManager.Map.GetAreaByAreaId(Character.GetLocation().AreaId);
		short eclecticAttainment = Character.GetLifeSkillAttainment(15);
		int merchantId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location charLocation = Character.GetLocation();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		for (sbyte i = 0; i < MerchantType.Instance.Count; i++)
		{
			MerchantTypeItem config = MerchantType.Instance[i];
			if (config.HeadArea == area.GetTemplateId())
			{
				int addFavor = AddFavorA;
				DomainManager.Merchant.ChangeMerchantCumulativeMoney(context, i, addFavor);
				lifeRecordCollection.AddVillagerGetMerchantFavorability(merchantId, currDate, merchantId, charLocation, i);
				lifeRecordCollection.AddVillagerGetMerchantFavorabilityTaiwu(taiwuId, currDate, merchantId, charLocation, i);
				break;
			}
			if (config.BranchArea == area.GetTemplateId())
			{
				int addFavor2 = AddFavorB;
				DomainManager.Merchant.ChangeMerchantCumulativeMoney(context, i, addFavor2);
				lifeRecordCollection.AddVillagerGetMerchantFavorability(merchantId, currDate, merchantId, charLocation, i);
				lifeRecordCollection.AddVillagerGetMerchantFavorabilityTaiwu(taiwuId, currDate, merchantId, charLocation, i);
				break;
			}
			if (i == 2 && area.GetTemplateId() == 11)
			{
				SettlementInfo[] settlementInfos = area.SettlementInfos;
				for (int j = 0; j < settlementInfos.Length; j++)
				{
					SettlementInfo settlementInfo = settlementInfos[j];
					Location location = new Location(area.GetAreaId(), settlementInfo.BlockId);
					List<BuildingBlockData> buildingBlockList = DomainManager.Building.GetBuildingBlockList(location);
					foreach (BuildingBlockData blockData in buildingBlockList)
					{
						if (blockData.TemplateId == 283)
						{
							int addFavor3 = VillagerRoleFormula.DefValue.MerchantChickenIncreaseBranchMerchantFavor.Calculate(eclecticAttainment, base.Personality);
							DomainManager.Merchant.ChangeMerchantCumulativeMoney(context, i, addFavor3);
							lifeRecordCollection.AddVillagerGetMerchantFavorability(merchantId, currDate, merchantId, charLocation, i);
							lifeRecordCollection.AddVillagerGetMerchantFavorabilityTaiwu(taiwuId, currDate, merchantId, charLocation, i);
						}
					}
				}
			}
		}
	}

	bool IVillagerRoleSelectLocation.NextLocationFilter(MapBlockData blockData)
	{
		if (blockData.IsNonDeveloped() || blockData.CharacterSet == null)
		{
			return false;
		}
		if (blockData.IsCityTown())
		{
			return true;
		}
		sbyte targetGrade = InteractTargetGrade;
		foreach (int charId in blockData.CharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetInteractionGrade() > targetGrade)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId < 0 && (WorkData == null || WorkData.WorkType != 1) && base.AutoActionStates[5])
		{
			TryAddNextAutoTravelTarget(context, AutoActionBlockFilter);
			AutoMoneyAction(context);
		}
	}

	private bool AutoMoneyAction(DataContext context)
	{
		Location location = Character.GetLocation();
		sbyte targetGrade = InteractTargetGrade;
		MapBlockData block = DomainManager.Map.GetBlock(location);
		int merchantId = Character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
		List<MapBlockData> blockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		blockList.Clear();
		DomainManager.Map.GetNeighborBlocks(location.AreaId, location.BlockId, blockList, 5);
		GameData.Domains.Character.Character targetChar = null;
		int targetIncome = 0;
		foreach (MapBlockData blockData in blockList)
		{
			if (blockData.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in blockData.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (character.GetInteractionGrade() <= targetGrade && AutoActionCharacterFilter(character))
				{
					int income = GetAutoActionMoneyIncome(character);
					if (targetIncome < income)
					{
						targetChar = character;
						targetIncome = income;
					}
				}
			}
		}
		blockList.Clear();
		ObjectPool<List<MapBlockData>>.Instance.Return(blockList);
		if (targetChar == null)
		{
			return false;
		}
		GainResource(context, 6, targetIncome);
		lifeRecordCollection.AddVillagerEarnMoney(merchantId, currDate, targetChar.GetId(), 6, targetIncome);
		storageRecordCollection.AddVillagerEarnMoney(currDate, TaiwuVillageStorageType.Treasury, merchantId, targetChar.GetId(), 6, targetIncome);
		return true;
	}

	private bool AutoActionBlockFilter(MapBlockData blockData)
	{
		if (blockData.CharacterSet == null)
		{
			return false;
		}
		sbyte interactTargetGrade = InteractTargetGrade;
		foreach (int charId in blockData.CharacterSet)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetInteractionGrade() > interactTargetGrade || !AutoActionCharacterFilter(character))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private bool AutoActionCharacterFilter(GameData.Domains.Character.Character character)
	{
		if (character.GetId() == Character.GetId() || character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			return false;
		}
		if (!CharacterMatcher.DefValue.CanBeMerchantAutoActionTarget.Match(character))
		{
			return false;
		}
		int moneyThreshold = character.GetAdjustedResourceSatisfyingThreshold(6);
		int moneyRequirement = VillagerRoleFormula.DefValue.MerchantAutoActionTargetMoneyRequirement.Calculate(moneyThreshold);
		return character.GetResource(6) >= moneyRequirement;
	}

	private int GetAutoActionMoneyIncome(GameData.Domains.Character.Character character)
	{
		VillagerRoleFormulaItem baseFormula = VillagerRoleFormula.Instance[27];
		VillagerRoleFormulaItem adjustFormula = VillagerRoleFormula.Instance[28];
		int moneyThreshold = character.GetAdjustedResourceSatisfyingThreshold(6);
		short eclecticAttainment = Character.GetLifeSkillAttainment(15);
		int baseValue = baseFormula.Calculate(moneyThreshold, eclecticAttainment);
		return adjustFormula.Calculate(baseValue);
	}

	protected override void TryAddNextAutoTravelTarget(DataContext context, Predicate<MapBlockData> condition)
	{
		if (Character.GetNpcTravelTargets().Count > 0)
		{
			return;
		}
		Location villageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		MapBlockData targetBlock = DomainManager.Map.SelectBlockInCurrentOrNeighborState(context.Random, villageLocation, condition, taiwuVillageInfluenceRangeIsLast: true);
		if (targetBlock != null)
		{
			short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			bool targetIsInTaiwuVillageInfluenceRange = DomainManager.Map.IsLocationInSettlementInfluenceRange(targetBlock.GetLocation(), settlementId);
			Location location = Character.GetLocation();
			bool currentIsInTaiwuVillageInfluenceRange = DomainManager.Map.IsLocationInSettlementInfluenceRange(location, settlementId);
			if (targetIsInTaiwuVillageInfluenceRange != currentIsInTaiwuVillageInfluenceRange || !location.IsValid() || !condition(DomainManager.Map.GetBlock(location)))
			{
				NpcTravelTarget travelTarget = new NpcTravelTarget(targetBlock.GetLocation(), 12);
				Character.AddTravelTarget(context, travelTarget);
			}
		}
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new PeddlingDisplayData
		{
			InteractTargetGrade = InteractTargetGrade,
			BuyPriceRate = BuyPriceRate,
			SellPriceRate = SellPriceRate,
			AddFavorA = AddFavorA,
			AddFavorB = AddFavorB,
			IsBuy = (ItemTemplateKey.ItemType >= 0)
		};
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 16;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 6;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = BoughtInAmount;
		pCurrData += 4;
		pCurrData += ItemTemplateKey.Serialize(pCurrData);
		*pCurrData = (byte)DesignatedMerchantType;
		pCurrData++;
		*pCurrData = (byte)CurrentMerchantType;
		pCurrData++;
		*pCurrData = (byte)SelfDecideMerchantType;
		pCurrData++;
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
			BoughtInAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			pCurrData += ItemTemplateKey.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			DesignatedMerchantType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			CurrentMerchantType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			SelfDecideMerchantType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

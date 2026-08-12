using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.Common;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Filters;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Organization.TaiwuVillageStoragesRecord;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.Taiwu.Display.VillagerRoleArrangement;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.VillagerRole;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class VillagerRoleSwordTombKeeper : VillagerRoleBase, IVillagerRoleContact, IVillagerRoleInfluence, IVillagerRoleArrangementExecutor, IVillagerRoleSelectLocation
{
	private static class FieldIds
	{
		public const ushort ArrangementTemplateId = 0;

		public const ushort XiangshuAvatarId = 1;

		public const ushort PositiveAction = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "ArrangementTemplateId", "XiangshuAvatarId", "PositiveAction" };
	}

	[SerializableGameDataField]
	public bool PositiveAction = true;

	[SerializableGameDataField]
	public sbyte XiangshuAvatarId = -1;

	public override short RoleTemplateId => 5;

	public bool IncreaseFavorability => PositiveAction;

	public int ContactFavorabilityChange => SharedMethods.CalculateSwordTombKeeperContactFavorabilityChange(Character.GetPersonalities(), Character.GetCombatSkillAttainments());

	public int ContactCharacterAmount => SharedMethods.CalculateSwordTombKeeperContactCharacterAmount(Character.GetPersonalities());

	public int LearnActionRepeatChance => SharedMethods.CalculateSwordTombKeeperLearnActionRepeatChance(Character.GetPersonalities());

	public int LearnRequestSuccessChanceBonus => SharedMethods.CalculateSwordTombKeeperLearnRequestSuccessChanceBonus(Character.GetPersonalities());

	public int CollectInformationChance => Math.Clamp(VillagerRoleFormula.DefValue.SwordTombKeeperWorkCollectOdd.Calculate(CalcSwordTombKeeperLifeSkillMaxAttainment(), Character.GetPersonality(3)), 0, 100);

	public int InjuredByXiangshuAvatarChance => Math.Clamp(VillagerRoleFormula.DefValue.SwordTombKeeperWorkHurtOdd.Calculate(CalcSwordTombKeeperLifeSkillMaxAttainment(), Character.GetPersonality(3)), 0, 100);

	private int ChickenUpgradeActionChance => Character.GetPersonality(3) / 2;

	internal int FeatureGainRateA => Math.Clamp(VillagerRoleFormula.DefValue.SwordTombKeeperWorkFeatureOddWhenInformationCollect.Calculate(CalcSwordTombKeeperLifeSkillMaxAttainment(), Character.GetPersonality(3)), 0, 100);

	internal int FeatureGainRateB => Math.Clamp(VillagerRoleFormula.DefValue.SwordTombKeeperWorkFeatureOddWhenBeAttacked.Calculate(CalcSwordTombKeeperLifeSkillMaxAttainment(), Character.GetPersonality(3)), 0, 100);

	public int InfluenceSettlementValueChange => SharedMethods.CalculateSwordTombKeeperInfluenceSettlementValueChange(Character.GetPersonalities(), Character.GetCombatSkillAttainments());

	public static int InjuryByXiangshuAvatarAmount => VillagerRoleFormula.DefValue.SwordTombKeeperWorkHurtCount.Calculate(DomainManager.World.GetXiangshuLevel(), DomainManager.World.GetWorldCreationSetting(1));

	internal int InfectionBaseValue => VillagerRoleFormula.DefValue.SwordTombKeeperWorkInfectAddPerMonth.Calculate();

	internal int InfectionDecreaseRate => VillagerRoleFormula.DefValue.SwordTombKeeperChickenDecreaseFactor.Calculate(CalcSwordTombKeeperLifeSkillMaxAttainment(), Character.GetPersonality(3));

	public sbyte XiangshuAvatarEscapeState
	{
		get
		{
			WorldStateData worldState = DomainManager.World.GetWorldStateData();
			if (worldState.IsXiangshuAvatarAwakening(XiangshuAvatarId))
			{
				return 1;
			}
			if (worldState.IsXiangshuAvatarAttacking(XiangshuAvatarId))
			{
				return 2;
			}
			return 0;
		}
	}

	void IVillagerRoleArrangementExecutor.ExecuteArrangementAction(DataContext context)
	{
		int arrangementTemplateId = ArrangementTemplateId;
		int num = arrangementTemplateId;
		if (num == 13)
		{
			ApplyGuardingSwordTombAction(context);
		}
	}

	public override void OfflineSetArrangement(short arrangementTemplateId, Location location)
	{
		base.OfflineSetArrangement(arrangementTemplateId, location);
		if (location.IsValid() && arrangementTemplateId == 13)
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(location).GetRootBlock();
			XiangshuAvatarId = (sbyte)XiangshuAvatarIds.SwordTombBlockTemplateIds.IndexOf(blockData.TemplateId);
		}
		else
		{
			XiangshuAvatarId = -1;
		}
	}

	private void ApplyGuardingSwordTombAction(DataContext context)
	{
		int charId = Character.GetId();
		Location location = Character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int infection = InfectionBaseValue;
		if (base.HasChickenUpgradeEffect)
		{
			infection -= infection * InfectionDecreaseRate / 100;
		}
		Character.ChangeXiangshuInfection(context, infection);
		if (infection > 0)
		{
			lifeRecordCollection.AddGuardingSwordTombXiangshuInfectUp(charId, currDate, location);
		}
		sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
		short templateId = XiangshuAvatarIds.GetCurrentLevelXiangshuTemplateId(XiangshuAvatarId, xiangshuLevel, isWeakened: true);
		if (context.Random.CheckPercentProb(CollectInformationChance))
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			NormalInformation information = DomainManager.Information.CalcSwordTombInformation(EInformationInfoSwordInformationType.SwordTombHuman, XiangshuAvatarId);
			if (information.TemplateId >= 0)
			{
				if (Config.Information.Instance[information.TemplateId].UsedCountWithMax)
				{
					DomainManager.Information.AddNormalInformationToCharacter(context, taiwuCharId, information);
				}
				else
				{
					DomainManager.Information.GiveRemainUsedCountInformation(context, taiwuCharId, information);
				}
				lifeRecordCollection.AddInquireSwordTomb(charId, currDate, XiangshuAvatarId);
				monthlyNotificationCollection.AddXiangshuNormalInformation(charId, XiangshuAvatarId, templateId);
			}
		}
		if (XiangshuAvatarId >= 0 && context.Random.CheckPercentProb(FeatureGainRateA))
		{
			GameData.Domains.Character.Character character = Character;
			short currentLevelXiangshuTemplateId = XiangshuAvatarIds.GetCurrentLevelXiangshuTemplateId(XiangshuAvatarId, 0);
			if (1 == 0)
			{
			}
			short featureId = currentLevelXiangshuTemplateId switch
			{
				39 => 356, 
				48 => 357, 
				57 => 358, 
				66 => 359, 
				75 => 360, 
				84 => 361, 
				93 => 362, 
				102 => 363, 
				111 => 364, 
				_ => -1, 
			};
			if (1 == 0)
			{
			}
			character.AddFeature(context, featureId);
		}
	}

	public override void ExecuteFixedAction(DataContext context)
	{
		if (ArrangementTemplateId < 0)
		{
			VillagerWorkData workData = WorkData;
			if ((workData == null || workData.WorkType != 1) && base.AutoActionStates[7])
			{
				TryAddNextAutoTravelTarget(context, AutoActionBlockFilter);
				AutoBattleWithRandomEnemy(context);
			}
		}
	}

	private bool AutoActionBlockFilter(MapBlockData blockData)
	{
		MapDomain mapDomain = DomainManager.Map;
		Location location = Character.GetLocation();
		if (location.IsValid() && mapDomain.GetStateIdByAreaId(location.AreaId) == mapDomain.GetStateIdByAreaId(blockData.AreaId) && blockData.TemplateEnemyList != null && blockData.TemplateEnemyList.Any((MapTemplateEnemyInfo info) => Config.Character.Instance[info.TemplateId].ConsummateLevel <= Character.GetConsummateLevel()))
		{
			return true;
		}
		return false;
	}

	private void AutoBattleWithRandomEnemy(DataContext context)
	{
		Location location = Character.GetLocation();
		MapBlockData block = DomainManager.Map.GetBlock(location);
		int count = VillagerRoleFormula.DefValue.SwordTombKeeperAutoActionKOCount.Calculate(Character.GetPersonality(4));
		ObjectPool<List<short>> listPool = ObjectPool<List<short>>.Instance;
		List<short> range = listPool.Get();
		range.Clear();
		if (block.TemplateEnemyList != null)
		{
			range.AddRange(block.TemplateEnemyList.Select((MapTemplateEnemyInfo info) => info.TemplateId));
		}
		CollectionUtils.Shuffle(context.Random, range);
		int rangeDiff = range.Count - count;
		if (rangeDiff > 0)
		{
			range.RemoveRange(0, rangeDiff);
		}
		CharacterDomain charDomain = DomainManager.Character;
		foreach (short targetCharTemplateId in range)
		{
			GameData.Domains.Character.Character enemyChar;
			AiHelper.NpcCombatResultType combatResultType = charDomain.SimulateEnemyAttackWithEnemyChar(context, targetCharTemplateId, Character, out enemyChar);
			if (combatResultType > AiHelper.NpcCombatResultType.MinorVictory)
			{
				continue;
			}
			int[] enemyTeam = new int[1] { enemyChar.GetId() };
			CombatResultDisplayData combatResultData = new CombatResultDisplayData();
			CombatConfigItem combatConfig = CombatConfig.Instance[(short)1];
			combatResultData.CombatStatus = 3;
			CombatDomain.ResultCalcResource(combatConfig, isPlaygroundCombat: false, Character, enemyTeam, combatResultData);
			CombatDomain.ResultCalcLootItem(context.Random, 50, combatConfig.CombatType, combatResultData.CombatStatus, isPuppetCombat: false, combatConfig, enemyChar, enemyTeam, Array.Empty<int>(), combatResultData);
			TaiwuVillageStoragesRecordCollection storageRecordCollection = DomainManager.Taiwu.GetTaiwuVillageStoragesRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			foreach (ItemDisplayData itemData in combatResultData.ItemList)
			{
				ItemKey itemKey = itemData.Key;
				ItemKey createdKey = DomainManager.Item.CreateItem(context, itemKey.ItemType, itemKey.TemplateId);
				DomainManager.Taiwu.StoreItemInTreasury(context, createdKey, itemData.Amount);
				storageRecordCollection.AddVillagerEnemyDropItem(currDate, TaiwuVillageStorageType.Treasury, Character.GetId(), itemKey.ItemType, itemKey.TemplateId);
			}
			for (sbyte i = 0; i < 8; i++)
			{
				int amount = combatResultData.Resource.Get(i);
				bool shouldTreasury = i != 7;
				DomainManager.Taiwu.AddResource(context, (!shouldTreasury) ? ItemSourceType.Inventory : ItemSourceType.Treasury, i, amount);
				if (shouldTreasury && amount > 0)
				{
					storageRecordCollection.AddVillagerEnemyDropResources(currDate, TaiwuVillageStorageType.Treasury, Character.GetId(), i, amount);
				}
			}
		}
		listPool.Return(range);
	}

	void IVillagerRoleInfluence.ApplyInfluenceAction(DataContext context)
	{
		int valueChange = InfluenceSettlementValueChange;
		if (!PositiveAction)
		{
			valueChange = -valueChange;
		}
		short areaId = Character.GetLocation().AreaId;
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
		int authorityGain = 0;
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos[i];
			if (settlementInfo.SettlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				settlement.ChangeSafety(context, valueChange);
				authorityGain += GetSettlementInfluenceAuthorityGain(settlement);
			}
		}
		DomainManager.Taiwu.GetTaiwu().ChangeResource(context, 7, authorityGain);
	}

	private static IEnumerable<sbyte> CalcSwordTombKeeperLifeSkillTypes()
	{
		yield return 13;
		yield return 12;
	}

	private int CalcSwordTombKeeperLifeSkillMaxAttainment()
	{
		LifeSkillShorts items = Character.GetLifeSkillAttainments();
		short max = short.MinValue;
		foreach (sbyte lifeSkillType in CalcSwordTombKeeperLifeSkillTypes())
		{
			if (items[lifeSkillType] > max)
			{
				max = items[lifeSkillType];
			}
		}
		return max;
	}

	Location IVillagerRoleSelectLocation.SelectNextWorkLocation(IRandomSource random, Location baseLocation)
	{
		if (baseLocation.BlockId >= 0)
		{
			if (ArrangementTemplateId == 13)
			{
				sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
				short templateId = XiangshuAvatarIds.GetCurrentLevelXiangshuTemplateId(XiangshuAvatarId, xiangshuLevel, isWeakened: true);
				if (DomainManager.Character.TryGetFixedCharacterByTemplateId(templateId, out var xiangshuAvatar))
				{
					Location location = xiangshuAvatar.GetLocation();
					if (location.IsValid())
					{
						return location;
					}
				}
			}
			MapBlockData block = DomainManager.Map.GetBlock(baseLocation);
			List<MapBlockData> groupBlockList = block.GroupBlockList;
			return (groupBlockList != null && groupBlockList.Count > 0) ? block.GroupBlockList.GetRandom(random).GetLocation() : baseLocation;
		}
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetMapBlocksInAreaByFilters(baseLocation.AreaId, ((IVillagerRoleSelectLocation)this).NextLocationFilter, validBlocks);
		if (validBlocks.Count == 0)
		{
			ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
			short stationBlockId = DomainManager.Map.GetElement_Areas(baseLocation.AreaId).StationBlockId;
			return new Location(baseLocation.AreaId, stationBlockId);
		}
		MapBlockData nextBlock = validBlocks.GetRandom(random);
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
		return nextBlock.GetLocation();
	}

	public int GetSettlementInfluenceAuthorityGain(Settlement settlement)
	{
		if (settlement == null)
		{
			return 0;
		}
		int safetyValue = (PositiveAction ? settlement.GetSafety() : (settlement.GetMaxSafety() - settlement.GetSafety()));
		return safetyValue * (50 + Character.GetPersonality(4) / 2) / 100;
	}

	public void SelectContactTargets(IRandomSource random, List<GameData.Domains.Character.Character> selectedCharList, int selectAmount)
	{
		selectedCharList.Clear();
		Location location = Character.GetLocation();
		MapBlockData currBlock = DomainManager.Map.GetBlock(location);
		if (currBlock.BelongBlockId >= 0)
		{
			MapCharacterFilter.Find(CharacterFilter, selectedCharList, location.AreaId);
			if (selectedCharList.Count > selectAmount)
			{
				selectedCharList.RemoveRange(selectAmount, selectedCharList.Count - selectAmount);
			}
		}
		bool CharacterFilter(GameData.Domains.Character.Character character)
		{
			if (!OrganizationDomain.IsLargeSect(character.GetOrganizationInfo().OrgTemplateId))
			{
				return false;
			}
			if (character == Character)
			{
				return false;
			}
			Location charLocation = character.GetLocation();
			MapBlockData block = DomainManager.Map.GetBlock(charLocation);
			if (block.IsNonDeveloped())
			{
				return false;
			}
			if (block.BelongBlockId != currBlock.BelongBlockId)
			{
				return false;
			}
			return true;
		}
	}

	public override IVillagerRoleArrangementDisplayData GetArrangementDisplayData()
	{
		return new GuardingSwordTombDisplayData
		{
			InformationGatheringSuccessRate = CollectInformationChance,
			InjuryProbability = InjuredByXiangshuAvatarChance,
			FeatureGainRateA = FeatureGainRateA,
			FeatureGainRateB = FeatureGainRateB,
			InfectionDecreaseRate = InfectionDecreaseRate,
			SwordTombId = XiangshuAvatarId,
			EscapeState = XiangshuAvatarEscapeState
		};
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 8;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*pCurrData = (byte)XiangshuAvatarId;
		pCurrData++;
		*pCurrData = (PositiveAction ? ((byte)1) : ((byte)0));
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
			XiangshuAvatarId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			PositiveAction = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

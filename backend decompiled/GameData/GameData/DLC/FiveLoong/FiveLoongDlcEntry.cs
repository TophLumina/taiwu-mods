using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.DLC.TameLoong;
using GameData.DomainEvents;
using GameData.Domains;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using NLog;

namespace GameData.DLC.FiveLoong;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class FiveLoongDlcEntry : IDlcEntry, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ChildrenOfLoongMonthlyEventChance = 0;

		public const ushort PulaoCricketLuckPoint = 1;

		public const ushort JiaoEggDropRate = 2;

		public const ushort MaleJiaoEggDropRate = 3;

		public const ushort IsJiaoPoolOpen = 4;

		public const ushort OwnedChildrenOfLoong = 5;

		public const ushort MaxTaiwuVillageLevel = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "ChildrenOfLoongMonthlyEventChance", "PulaoCricketLuckPoint", "JiaoEggDropRate", "MaleJiaoEggDropRate", "IsJiaoPoolOpen", "OwnedChildrenOfLoong", "MaxTaiwuVillageLevel" };
	}

	public const int MaxJiaoPoolCount = 9;

	[SerializableGameDataField]
	public int ChildrenOfLoongMonthlyEventChance;

	[SerializableGameDataField]
	public int PulaoCricketLuckPoint;

	[SerializableGameDataField]
	public int JiaoEggDropRate;

	[SerializableGameDataField]
	public int MaleJiaoEggDropRate;

	[SerializableGameDataField]
	public bool IsJiaoPoolOpen;

	[SerializableGameDataField]
	public int OwnedChildrenOfLoong;

	[SerializableGameDataField]
	public int MaxTaiwuVillageLevel;

	private const int DisablePoolTamePointLoss = 5;

	private const int JiaoTamingPointsLowLimit = 50;

	private static Dictionary<short, short> _carrierToJiaoTemplate;

	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static bool IsDlcEnabled => IsForcingEnabled() || (IsMainStoryLineProgressMeetLoongDlc() && IsTaiwuVillageLevelMeetFiveLoongDlc());

	public static IReadOnlyDictionary<short, short> CarrierToJiaoTemplate => _carrierToJiaoTemplate;

	private void PostAdvanceMonth_Main(DataContext context)
	{
		DomainManager.Extra.ClearTempData();
		UpdateMaxTaiwuVillageLevel();
		if (IsDlcEnabled)
		{
			EventArgBox loongDlcArgBox = DomainManager.Extra.GetOrCreateDlcArgBox(2764950uL, context);
			bool fiveLoongDlcBeginMonthlyEventTriggered = false;
			if (!loongDlcArgBox.Get("ConchShip_PresetKey_FiveLoongDlcBeginMonthlyEventTriggered", ref fiveLoongDlcBeginMonthlyEventTriggered) || !fiveLoongDlcBeginMonthlyEventTriggered)
			{
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				monthlyEventCollection.AddFiveLoongLetterFromTaiwuVillage();
			}
		}
	}

	private static bool IsForcingEnabled()
	{
		return DlcManager.IsDlcInstalled(ImplementedDlc.DefValue.TaiwuAsXiangshu.AppId) && DomainManager.Extra.PagodaofTheFallenEntered();
	}

	private static bool IsMainStoryLineProgressMeetLoongDlc()
	{
		return DomainManager.World.GetDefeatSwordTombCount() >= 4 && DomainManager.World.GetWorldFunctionsStatus(4);
	}

	private static bool IsTaiwuVillageLevelMeetFiveLoongDlc()
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockKey buildingKey = BuildingDomain.FindBuildingKey(taiwuVillageLocation, DomainManager.Building.GetBuildingAreaData(taiwuVillageLocation), 44);
		BuildingBlockData buildingBlockData;
		return !buildingKey.IsInvalid && DomainManager.Building.TryGetElement_BuildingBlocks(buildingKey, out buildingBlockData) && buildingBlockData.CalcUnlockedLevelCount() >= 6;
	}

	public void PostAdvanceMonth_JiaoPool(DataContext context)
	{
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		List<JiaoPool> jiaoPools = DomainManager.Extra.GetJiaoPoolList();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			location = taiwu.GetValidLocation();
		}
		for (int i = 0; i < jiaoPools.Count; i++)
		{
			JiaoPool jiaoPool = jiaoPools[i];
			if (jiaoPool.Jiaos.Count == 1)
			{
				if (!DomainManager.Extra.TryGetJiao(jiaoPool.Jiaos[0], out var jiao))
				{
					continue;
				}
				if (jiao.GrowthStage == 0)
				{
					if (--jiaoPool.NextPeriod == 0)
					{
						DomainManager.Extra.JiaoHatch(context, i);
						monthlyNotificationCollection.AddJiaoBrokeThroughTheShell(location, jiao.Id);
					}
				}
				else
				{
					if (jiao.GrowthStage != 1)
					{
						continue;
					}
					if (DomainManager.Extra.JiaoFlee(context, i))
					{
						monthlyNotificationCollection.AddJiaoGoHome(location, jiao.Id);
						continue;
					}
					if (jiaoPool.IsDisabled)
					{
						jiao.TamePoint = Math.Max(0, jiao.TamePoint - 5);
					}
					else if (!DomainManager.Extra.IsResourceEnoughForJiaoFoster(jiao.NurturanceTemplateId))
					{
						monthlyNotificationCollection.AddJiaoPoolAccident(location, jiao.Id);
					}
					else if (jiao.EvolveRemainingMonth != 0)
					{
						if (jiao.NextPeriod >= 0)
						{
							DomainManager.Extra.ConsumeResourceForJiaoFoster(context, jiao.NurturanceTemplateId);
						}
						if (--jiao.NextPeriod == 0 && jiao.NurturanceTemplateId != 0)
						{
							DomainManager.Extra.JiaoGrow(context, i);
						}
						else if (jiao.EvolveRemainingMonth > 1)
						{
							DomainManager.Extra.JiaoEvent(context, i);
						}
						if (jiao.TamePoint <= 50)
						{
							monthlyNotificationCollection.AddJiaoTamingPointsLow(location, jiao.Id);
						}
						DomainManager.Extra.UpdateJiaoEvolveRemainingMonth(context, jiao);
					}
					if (jiao.EvolveRemainingMonth == 0)
					{
						DomainManager.Extra.JiaoEvolveToCarrier(context, i);
						monthlyNotificationCollection.AddJiaoHasReachedAnAdultAge(location, jiao.Id);
					}
				}
			}
			else if (jiaoPool.Jiaos.Count == 2 && --jiaoPool.NextPeriod == 0 && DomainManager.Extra.JiaoBreed(context, i))
			{
				monthlyNotificationCollection.AddJiaoLayEggs(location, jiaoPool.Jiaos[0], jiaoPool.Jiaos[1]);
			}
		}
		DomainManager.Extra.SetJiaoPools(jiaoPools, context);
	}

	public void PostAdvanceMonth_JiaoPoolLog(DataContext context)
	{
		List<JiaoPoolRecord> tempList = new List<JiaoPoolRecord>();
		int currDate = DomainManager.World.GetCurrDate();
		List<JiaoPoolRecordList> records = DomainManager.Extra.GetJiaoPoolRecords();
		foreach (JiaoPoolRecordList list in records)
		{
			tempList.Clear();
			foreach (JiaoPoolRecord record in list.Collection)
			{
				if (currDate - record.Date <= 24)
				{
					tempList.Add(record);
				}
			}
			list.Collection.Clear();
			list.Collection.AddRange(tempList);
		}
		DomainManager.Extra.SetJiaoPoolRecords(records, context);
	}

	private void PostAdvanceMonth_ChildOfLoong(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ItemKey equippedCarrier = taiwu.GetEquipment()[12];
		JiaoItem carrierCfg = PostAdvanceMonth_ChildOfLoong(context, equippedCarrier);
		ItemKey equippedBeast = taiwu.GetEquipment()[13];
		JiaoItem beastCfg = PostAdvanceMonth_ChildOfLoong(context, equippedBeast);
		if (carrierCfg == null && beastCfg == null)
		{
			return;
		}
		JiaoItem jiaoCfg = carrierCfg ?? beastCfg;
		ItemKey jiaoCarrier = ((carrierCfg == null) ? equippedBeast : equippedCarrier);
		if (carrierCfg != null && beastCfg != null)
		{
			int sum = carrierCfg.MonthlyEventCost + beastCfg.MonthlyEventCost;
			if (context.Random.Next(sum) >= carrierCfg.MonthlyEventCost)
			{
				ItemKey itemKey = equippedCarrier;
				jiaoCarrier = itemKey;
				jiaoCfg = carrierCfg;
			}
			else
			{
				ItemKey itemKey = equippedBeast;
				jiaoCarrier = itemKey;
				jiaoCfg = beastCfg;
			}
		}
		PostAdvanceMonth_ChildOfLoong(context, jiaoCarrier, jiaoCfg);
	}

	private JiaoItem PostAdvanceMonth_ChildOfLoong(DataContext context, ItemKey equippedCarrier)
	{
		if (!equippedCarrier.IsValid() || DomainManager.Item.GetBaseItem(equippedCarrier).IsDurabilityRunningOut())
		{
			return null;
		}
		if (!CarrierToJiaoTemplate.TryGetValue(equippedCarrier.TemplateId, out var jiaoTemplateId))
		{
			return null;
		}
		JiaoItem jiaoCfg = Config.Jiao.Instance[jiaoTemplateId];
		if (jiaoCfg.MonthlyEventCost <= 0)
		{
			return null;
		}
		return jiaoCfg;
	}

	private void PostAdvanceMonth_ChildOfLoong(DataContext context, ItemKey equippedCarrier, JiaoItem jiaoCfg)
	{
		if (!context.Random.CheckPercentProb(ChildrenOfLoongMonthlyEventChance))
		{
			ChildrenOfLoongMonthlyEventChance += 10;
			return;
		}
		ChildrenOfLoong childOfLoong = DomainManager.Extra.GetChildrenOfLoongByItemKey(equippedCarrier);
		short templateId = equippedCarrier.TemplateId;
		if (1 == 0)
		{
		}
		bool flag = templateId switch
		{
			77 => PostAdvanceMonth_ChildOfLoong_Qiuniu(context, childOfLoong), 
			78 => PostAdvanceMonth_ChildOfLoong_Yazi(context, childOfLoong), 
			79 => PostAdvanceMonth_ChildOfLoong_Chaofeng(context, childOfLoong), 
			80 => PostAdvanceMonth_ChildOfLoong_Pulao(context, childOfLoong), 
			81 => PostAdvanceMonth_ChildOfLoong_Suanni(context, childOfLoong), 
			82 => PostAdvanceMonth_ChildOfLoong_Baxia(context, childOfLoong), 
			83 => PostAdvanceMonth_ChildOfLoong_Bian(context, childOfLoong), 
			84 => PostAdvanceMonth_ChildOfLoong_Fuxi(context, childOfLoong), 
			85 => PostAdvanceMonth_ChildOfLoong_Chiwen(context, childOfLoong), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		if (flag)
		{
			ChildrenOfLoongMonthlyEventChance -= jiaoCfg.MonthlyEventCost;
		}
		else
		{
			ChildrenOfLoongMonthlyEventChance += 10;
		}
	}

	private bool PostAdvanceMonth_ChildOfLoong_Qiuniu(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, neighborBlocks, 3);
		List<int> potentialCharIds = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			if (neighborBlock.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in neighborBlock.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (!character.IsActiveExternalRelationState(188uL))
				{
					potentialCharIds.Add(charId);
				}
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		if (potentialCharIds.Count == 0)
		{
			context.AdvanceMonthRelatedData.CharIdList.Release(ref potentialCharIds);
			return false;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		int affectedTargetCount = context.Random.Next(3) + 1;
		for (int i = 0; i < affectedTargetCount; i++)
		{
			if (potentialCharIds.Count == 0)
			{
				break;
			}
			int index = context.Random.Next(potentialCharIds.Count);
			int affectedCharId = potentialCharIds[index];
			CollectionUtils.SwapAndRemove(potentialCharIds, index);
			GameData.Domains.Character.Character affectedChar = DomainManager.Character.GetElement_Objects(affectedCharId);
			int favorChange = context.Random.Next(2000, 4001);
			DomainManager.Character.ChangeFavorabilityOptional(context, affectedChar, taiwuChar, favorChange, 5);
			Location location = affectedChar.GetLocation();
			lifeRecordCollection.AddDLCLoongRidingEffectQiuniuAudience(affectedCharId, currDate, taiwuCharId, location, childOfLoong.Id);
		}
		context.AdvanceMonthRelatedData.CharIdList.Release(ref potentialCharIds);
		lifeRecordCollection.AddDLCLoongRidingEffectQiuniu(taiwuCharId, currDate, taiwuLocation, childOfLoong.Id);
		monthlyEventCollection.AddDLCLoongRidingEffectQiuniu(taiwuCharId, childOfLoong.Id);
		monthlyNotifications.AddDLCLoongRidingEffectQiuniu(taiwuCharId, taiwuLocation, childOfLoong.Id);
		return true;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Yazi(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, neighborBlocks, 3);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<int> potentialCharIds = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			if (neighborBlock.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in neighborBlock.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (character.GetAgeGroup() != 0 && !character.IsActiveExternalRelationState(188uL) && DomainManager.Character.HasRelation(taiwuCharId, charId, 32768))
				{
					potentialCharIds.Add(charId);
				}
			}
		}
		int selectedCharId = potentialCharIds.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.CharIdList.Release(ref potentialCharIds);
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		if (selectedCharId < 0)
		{
			return false;
		}
		GameData.Domains.Character.Character selectedChar = DomainManager.Character.GetElement_Objects(selectedCharId);
		DomainManager.Character.SimulateEnemyAttack(context, 288, selectedChar);
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		lifeRecordCollection.AddDLCLoongRidingEffectYazi(taiwuCharId, currDate, selectedCharId, taiwuLocation, childOfLoong.Id);
		lifeRecordCollection.AddDLCLoongRidingEffectYazi2(selectedCharId, currDate, taiwuLocation, childOfLoong.Id);
		monthlyEventCollection.AddDLCLoongRidingEffectYazi(taiwuCharId, childOfLoong.Id, selectedCharId);
		monthlyNotifications.AddDLCLoongRidingEffectYazi(selectedCharId, taiwuLocation, childOfLoong.Id);
		return true;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Chaofeng(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<SecretInformationId> taiwuSecretInfoCollection = DomainManager.Information.QueryCharacterKnownSecretInformationIds(taiwuCharId).ToHashSet();
		Location taiwuLocation = taiwuChar.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, neighborBlocks, 3);
		List<int> potentialCharIds = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			if (neighborBlock.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in neighborBlock.CharacterSet)
			{
				IReadOnlyCollection<SecretInformationId> charSecrets = DomainManager.Information.QueryCharacterKnownSecretInformationIds(charId);
				foreach (SecretInformationId infoId in charSecrets)
				{
					if (!taiwuSecretInfoCollection.Contains(infoId))
					{
						potentialCharIds.Add(charId);
						break;
					}
				}
			}
		}
		int selectedCharId = potentialCharIds.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.CharIdList.Release(ref potentialCharIds);
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		if (selectedCharId < 0)
		{
			return false;
		}
		HashSet<int> targetInfoCollection = (from secretId in DomainManager.Information.QueryCharacterKnownSecretInformationIds(selectedCharId)
			select (int)secretId).ToHashSet();
		List<int> secretIdList = context.AdvanceMonthRelatedData.IntList.Occupy();
		foreach (int secretInformationId in targetInfoCollection)
		{
			if (!taiwuSecretInfoCollection.Contains((SecretInformationId)secretInformationId))
			{
				secretIdList.Add(secretInformationId);
			}
		}
		int selectedSecretInfoId = secretIdList.GetRandom(context.Random);
		DomainManager.Information.ReceiveSecretInformation(context, (SecretInformationId)selectedSecretInfoId, taiwuCharId, selectedCharId);
		context.AdvanceMonthRelatedData.IntList.Release(ref secretIdList);
		int currDate = DomainManager.World.GetCurrDate();
		Location location = taiwuChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyEventCollection.AddDLCLoongRidingEffectChaofeng(taiwuCharId, childOfLoong.Id, selectedCharId);
		lifeRecordCollection.AddDLCLoongRidingEffectChaofeng(taiwuCharId, currDate, location, childOfLoong.Id);
		monthlyNotifications.AddDLCLoongRidingEffectChaofeng(location, childOfLoong.Id);
		return true;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Pulao(DataContext context, ChildrenOfLoong childOfLoong)
	{
		ItemKey cricketKey = DomainManager.Item.CreateCricketByLuckPoint(context, ref PulaoCricketLuckPoint);
		DomainManager.Taiwu.GetTaiwu().AddInventoryItem(context, cricketKey, 1);
		GameData.Domains.Item.Cricket cricket = DomainManager.Item.GetElement_Crickets(cricketKey.Id);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		short colorId = cricket.GetColorId();
		short partId = cricket.GetPartId();
		int nameId = cricket.GetNameId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		lifeRecordCollection.AddDLCLoongRidingEffectPulao(taiwuCharId, currDate, childOfLoong.Id, colorId, partId, nameId);
		monthlyNotifications.AddDLCLoongRidingEffectPulao(childOfLoong.Id, colorId, partId, nameId);
		monthlyEventCollection.AddDLCLoongRidingEffectPulao(taiwuCharId, childOfLoong.Id, colorId, partId, nameId);
		return true;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Suanni(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(taiwu.GetId());
		List<ItemKey> potentialBooks = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (itemKey2.ItemType != 10)
			{
				continue;
			}
			SkillBookItem bookCfg = Config.SkillBook.Instance[itemKey2.TemplateId];
			if (bookCfg.ItemSubType != 1001 || !combatSkills.TryGetValue(bookCfg.CombatSkillTemplateId, out var combatSkill))
			{
				continue;
			}
			GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(itemKey2.Id);
			byte pageTypes = book.GetPageTypes();
			ushort readingState = combatSkill.GetReadingState();
			sbyte outlinePageType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
			byte outlinePageInternalIndex = CombatSkillStateHelper.GetOutlinePageInternalIndex(outlinePageType);
			bool hasReadPage = CombatSkillStateHelper.IsPageRead(readingState, outlinePageInternalIndex);
			bool hasUnreadPage = !hasReadPage;
			for (byte i = 1; i < 6; i++)
			{
				sbyte direction = SkillBookStateHelper.GetNormalPageType(pageTypes, i);
				byte internalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, i);
				if (CombatSkillStateHelper.IsPageRead(readingState, internalIndex))
				{
					hasReadPage = true;
				}
				else
				{
					hasUnreadPage = true;
				}
			}
			if (hasReadPage && hasUnreadPage)
			{
				potentialBooks.Add(itemKey2);
			}
		}
		bool hasPotentialBook = potentialBooks.Count > 0;
		if (hasPotentialBook)
		{
			ItemKey selectedBookKey = potentialBooks.GetRandom(context.Random);
			GameData.Domains.Item.SkillBook selectedBook = DomainManager.Item.GetElement_SkillBooks(selectedBookKey.Id);
			byte pageTypes2 = selectedBook.GetPageTypes();
			GameData.Domains.CombatSkill.CombatSkill combatSkill2 = combatSkills[selectedBook.GetCombatSkillTemplateId()];
			ushort readingState2 = combatSkill2.GetReadingState();
			sbyte outlinePageType2 = SkillBookStateHelper.GetOutlinePageType(pageTypes2);
			for (byte pageId = 0; pageId < 6; pageId++)
			{
				sbyte direction2 = SkillBookStateHelper.GetNormalPageType(pageTypes2, pageId);
				byte internalIndex2 = CombatSkillStateHelper.GetPageInternalIndex(outlinePageType2, direction2, pageId);
				if (!CombatSkillStateHelper.IsPageRead(readingState2, internalIndex2))
				{
					DomainManager.Taiwu.ReadSkillBookPageAndSetComplete(context, selectedBook, pageId);
					int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
					int currDate = DomainManager.World.GetCurrDate();
					Location location = taiwu.GetLocation();
					LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
					MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
					MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
					monthlyEventCollection.AddDLCLoongRidingEffectSuanni(taiwuCharId, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
					lifeRecordCollection.AddDLCLoongRidingEffectSuanni(taiwuCharId, currDate, location, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
					monthlyNotifications.AddDLCLoongRidingEffectSuanni(location, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
					break;
				}
			}
		}
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref potentialBooks);
		return hasPotentialBook;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Baxia(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, neighborBlocks, 3);
		for (int i = neighborBlocks.Count - 1; i >= 0; i--)
		{
			MapBlockData block = neighborBlocks[i];
			if (block.Items == null)
			{
				neighborBlocks.RemoveAt(i);
			}
		}
		bool succeed = neighborBlocks.Count > 0;
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		if (succeed)
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			monthlyEventCollection.AddDLCLoongRidingEffectBaxia(taiwuCharId, childOfLoong.Id);
		}
		return succeed;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Bian(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int currDate = DomainManager.World.GetCurrDate();
		List<FameActionRecord> fameActionRecords = taiwu.GetFameActionRecords();
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		foreach (FameActionRecord record in fameActionRecords)
		{
			if (record.EndDate > currDate)
			{
				FameActionItem fameActionCfg = FameAction.Instance[record.Id];
				weightTable.Add((record.Id, fameActionCfg.MaxStackCount));
			}
		}
		if (weightTable.Count == 0)
		{
			context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
			return false;
		}
		short fameActionTemplateId = RandomUtils.GetRandomResult(weightTable, context.Random);
		context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
		taiwu.RecordFameAction(context, fameActionTemplateId, -1, 1);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = taiwu.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		lifeRecordCollection.AddDLCLoongRidingEffectBian(taiwuCharId, currDate, location, childOfLoong.Id);
		monthlyEventCollection.AddDLCLoongRidingEffectBian(taiwuCharId, childOfLoong.Id);
		monthlyNotifications.AddDLCLoongRidingEffectBian(location, childOfLoong.Id);
		return false;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Fuxi(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = taiwu.GetLearnedLifeSkills();
		List<ItemKey> potentialBooks = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (var (itemKey2, _) in inventory.Items)
		{
			if (itemKey2.ItemType != 10)
			{
				continue;
			}
			SkillBookItem bookCfg = Config.SkillBook.Instance[itemKey2.TemplateId];
			if (bookCfg.ItemSubType != 1000)
			{
				continue;
			}
			int learnedLifeSkillIndex = taiwu.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
			if (learnedLifeSkillIndex >= 0)
			{
				GameData.Domains.Character.LifeSkillItem learnedLifeSkill = learnedLifeSkills[learnedLifeSkillIndex];
				if (!learnedLifeSkill.IsAllPagesRead() && learnedLifeSkill.ReadingState != 0)
				{
					potentialBooks.Add(itemKey2);
				}
			}
		}
		if (potentialBooks.Count == 0)
		{
			context.AdvanceMonthRelatedData.ItemKeys.Release(ref potentialBooks);
			return false;
		}
		ItemKey selectedBookKey = potentialBooks.GetRandom(context.Random);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref potentialBooks);
		GameData.Domains.Item.SkillBook selectedBook = DomainManager.Item.GetElement_SkillBooks(selectedBookKey.Id);
		int lifeSkillIndex = taiwu.FindLearnedLifeSkillIndex(selectedBook.GetLifeSkillTemplateId());
		GameData.Domains.Character.LifeSkillItem lifeSkillItem = learnedLifeSkills[lifeSkillIndex];
		for (byte pageId = 0; pageId < 5; pageId++)
		{
			if (!lifeSkillItem.IsPageRead(pageId))
			{
				DomainManager.Taiwu.ReadSkillBookPageAndSetComplete(context, selectedBook, pageId, addSeniority: true);
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				int currDate = DomainManager.World.GetCurrDate();
				Location location = taiwu.GetLocation();
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
				monthlyEventCollection.AddDLCLoongRidingEffectFuxi(taiwuCharId, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
				lifeRecordCollection.AddDLCLoongRidingEffectFuxi(taiwuCharId, currDate, location, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
				monthlyNotifications.AddDLCLoongRidingEffectFuxi(location, childOfLoong.Id, selectedBookKey.ItemType, selectedBookKey.TemplateId, pageId + 1);
				break;
			}
		}
		return true;
	}

	private bool PostAdvanceMonth_ChildOfLoong_Chiwen(DataContext context, ChildrenOfLoong childOfLoong)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int currNeili = taiwu.GetCurrNeili();
		int maxNeili = taiwu.GetMaxNeili();
		int neiliRecovery = taiwu.GetCurrNeiliRecovery(maxNeili);
		if (maxNeili - currNeili < neiliRecovery * 3)
		{
			return false;
		}
		int recoverAmount = neiliRecovery * (context.Random.Next(3) + 1);
		taiwu.ChangeCurrNeili(context, recoverAmount);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = taiwu.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		lifeRecordCollection.AddDLCLoongRidingEffectChiwen(taiwuCharId, currDate, location, childOfLoong.Id);
		monthlyEventCollection.AddDLCLoongRidingEffectChiwen(taiwuCharId, childOfLoong.Id);
		monthlyNotifications.AddDLCLoongRidingEffectChiwen(location, childOfLoong.Id);
		return false;
	}

	private void PostAdvanceMonth_FiveLoongs(DataContext context)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		HashSet<int> handledCharSet = new HashSet<int>();
		HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		List<int> charIdList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		foreach (KeyValuePair<short, LoongInfo> item in DomainManager.Extra.FiveLoongDict)
		{
			item.Deconstruct(out var key, out var value);
			short loongId = key;
			LoongInfo loongInfo = value;
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(loongInfo.LoongCurrentLocation.AreaId);
			LoongItem loongCfg = loongInfo.ConfigData;
			handledCharSet.Clear();
			handledCharSet.UnionWith(taiwuGroup);
			if (loongInfo.CoveredMapBlockTemplateId != null)
			{
				foreach (short blockId in loongInfo.CoveredMapBlockTemplateId.Keys)
				{
					MapBlockData block = areaBlocks[blockId];
					if (block.CharacterSet == null)
					{
						continue;
					}
					foreach (int charId in block.CharacterSet)
					{
						GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
						if (OfflineTryApplyLoongBlockDebuff(loongInfo, character) != 0)
						{
							handledCharSet.Add(charId);
						}
					}
				}
			}
			if (loongInfo.CharacterDebuffCounts != null)
			{
				charIdList.Clear();
				charIdList.AddRange(loongInfo.CharacterDebuffCounts.Keys);
				foreach (int charId2 in charIdList)
				{
					if (!handledCharSet.Contains(charId2))
					{
						if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
						{
							OfflineTryReduceLoongBlockDebuff(loongInfo, character2);
						}
						else
						{
							loongInfo.CharacterDebuffCounts.Remove(charId2);
						}
					}
				}
			}
			charIdList.Clear();
			Location loongLocation = loongInfo.LoongCurrentLocation;
			if (!loongInfo.IsDisappear)
			{
				MapBlockData loongBlockData = areaBlocks[loongLocation.BlockId];
				if (loongBlockData.CharacterSet != null)
				{
					charIdList.AddRange(loongBlockData.CharacterSet);
					int targetCharId = charIdList.GetRandom(context.Random);
					GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
					AiHelper.NpcCombatResultType resultType = DomainManager.Character.SimulateEnemyAttack(context, loongInfo.CharacterTemplateId, targetChar);
					if (resultType == AiHelper.NpcCombatResultType.MajorVictory || resultType == AiHelper.NpcCombatResultType.MinorVictory)
					{
						lifeRecordCollection.AddDefeatedByLoong(targetCharId, currDate, loongInfo.CharacterTemplateId, loongLocation);
					}
					else
					{
						lifeRecordCollection.AddDefeatLoong(targetCharId, currDate, loongInfo.CharacterTemplateId, loongLocation);
					}
				}
				List<short> blockIds = context.AdvanceMonthRelatedData.BlockIds.Occupy();
				Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(loongLocation.AreaId);
				foreach (short blockId2 in loongInfo.CoveredMapBlockTemplateId.Keys)
				{
					if (IsBlockLoongBlock(blocks[blockId2]))
					{
						blockIds.Add(blockId2);
					}
				}
				short randomBlockId = blockIds.GetRandom(context.Random);
				context.AdvanceMonthRelatedData.BlockIds.Release(ref blockIds);
				DomainManager.Extra.RemoveAnimalByLocationAndTemplateId(context, loongInfo.LoongCurrentLocation, loongInfo.CharacterTemplateId);
				loongInfo.LoongCurrentLocation = new Location(loongInfo.LoongCurrentLocation.AreaId, randomBlockId);
				DomainManager.Extra.CreateAnimalByCharacterTemplateId(context, loongInfo.CharacterTemplateId, loongInfo.LoongCurrentLocation);
			}
			else if (TameLoongEntry.IsLoongFree(loongId))
			{
				if (loongInfo.DisappearDate + 108 <= DomainManager.World.GetCurrDate() && loongInfo.IsDisappear && !TryCreateOrReAppearFiveLoong(context, isStrict: true, loongInfo.CharacterTemplateId))
				{
					TryCreateOrReAppearFiveLoong(context, isStrict: false, loongInfo.CharacterTemplateId);
				}
			}
			else
			{
				loongInfo.DisappearDate = DomainManager.World.GetCurrDate();
			}
			if (DomainManager.Extra.TryGetAnimalAreaDataByAreaId(loongLocation.AreaId, out var animalAreaData))
			{
				List<GameData.Domains.Character.Animal> animalsToRemove = null;
				foreach (KeyValuePair<short, List<int>> item2 in animalAreaData)
				{
					item2.Deconstruct(out key, out var value2);
					short blockId3 = key;
					List<int> animalIds = value2;
					GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
					Location taiwuLocation = taiwu.GetLocation();
					int taiwuCharId = taiwu.GetId();
					short minionTemplateId = loongCfg.MinionCharTemplateId;
					foreach (int animalId in animalIds)
					{
						if (!DomainManager.Extra.TryGetAnimal(animalId, out var animal) || animal.CharacterTemplateId != minionTemplateId)
						{
							continue;
						}
						charIdList.Clear();
						MapBlockData blockData = areaBlocks[blockId3];
						Location location = blockData.GetLocation();
						if (blockData.CharacterSet != null)
						{
							charIdList.AddRange(blockData.CharacterSet);
						}
						if (location == taiwuLocation)
						{
							charIdList.Add(taiwuCharId);
						}
						if (charIdList.Count == 0)
						{
							continue;
						}
						int selectedCharId = charIdList.GetRandom(context.Random);
						GameData.Domains.Character.Character selectedChar = DomainManager.Character.GetElement_Objects(selectedCharId);
						if (selectedCharId == taiwuCharId)
						{
							MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
							monthlyEventCollection.AddMinionLoongAttack(taiwuCharId, loongLocation, minionTemplateId);
							continue;
						}
						AiHelper.NpcCombatResultType resultType2 = DomainManager.Character.SimulateEnemyAttack(context, minionTemplateId, selectedChar);
						if (resultType2 == AiHelper.NpcCombatResultType.MajorVictory || resultType2 == AiHelper.NpcCombatResultType.MinorVictory)
						{
							lifeRecordCollection.AddDefeatedByAnimal(selectedCharId, currDate, location, animal.CharacterTemplateId);
							continue;
						}
						if (animalsToRemove == null)
						{
							animalsToRemove = new List<GameData.Domains.Character.Animal>();
						}
						animalsToRemove.Add(animal);
						lifeRecordCollection.AddKillAnimal(selectedCharId, currDate, location, animal.CharacterTemplateId);
					}
				}
				if (animalsToRemove != null)
				{
					foreach (GameData.Domains.Character.Animal animal2 in animalsToRemove)
					{
						DomainManager.Extra.RemoveAnimal(context, animal2);
					}
				}
			}
			DomainManager.Extra.SetLoongInfo(context, loongId, loongInfo);
		}
		context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
	}

	private static int OfflineTryApplyLoongBlockDebuff(LoongInfo loongInfo, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		LoongItem loongCfg = loongInfo.ConfigData;
		sbyte personality = character.GetPersonality(loongCfg.PersonalityType);
		bool hasClothing = false;
		ItemKey itemKey = character.GetEquipment()[4];
		if (itemKey.IsValid() && !DomainManager.Item.GetBaseItem(itemKey).IsDurabilityRunningOut() && itemKey.TemplateId == loongCfg.ClothingTemplateId)
		{
			hasClothing = true;
		}
		if (personality < loongCfg.PersonalityRequirement && !hasClothing)
		{
			loongInfo.ChangeCharacterDebuffCount(charId, 1);
			return 1;
		}
		if (loongInfo.GetCharacterDebuffCount(charId) > 0)
		{
			loongInfo.ChangeCharacterDebuffCount(charId, -1);
			return -1;
		}
		return 0;
	}

	private static int OfflineTryReduceLoongBlockDebuff(LoongInfo loongInfo, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		if (loongInfo.CharacterDebuffCounts == null || !loongInfo.CharacterDebuffCounts.ContainsKey(charId))
		{
			return 0;
		}
		loongInfo.ChangeCharacterDebuffCount(charId, -1);
		return -1;
	}

	private static void OnTaiwuMove(DataContext context, MapBlockData srcBlock, MapBlockData destBlock, int actionPointCost)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		MapBlockItem blockConfig = destBlock.GetConfig();
		foreach (KeyValuePair<short, LoongInfo> item in DomainManager.Extra.FiveLoongDict)
		{
			item.Deconstruct(out var key, out var value);
			short loongId = key;
			LoongInfo loongInfo = value;
			LoongItem loongCfg = loongInfo.ConfigData;
			bool isLoongBlock = loongCfg.MapBlock == blockConfig.TemplateId;
			int delta = (isLoongBlock ? OfflineTryApplyLoongBlockDebuff(loongInfo, taiwu) : OfflineTryReduceLoongBlockDebuff(loongInfo, taiwu));
			bool isModified = delta != 0;
			if (isModified)
			{
				AddLoongDebuffInstantNotification((delta > 0) ? loongCfg.DebuffCountIncNotification : loongCfg.DebuffCountDecNotification, (loongInfo.CharacterDebuffCounts != null && loongInfo.CharacterDebuffCounts.TryGetValue(taiwuCharId, out var count)) ? count : 0);
			}
			HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
			foreach (int groupCharId in taiwuGroup)
			{
				if (groupCharId != taiwuCharId)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(groupCharId);
					if ((isLoongBlock ? OfflineTryApplyLoongBlockDebuff(loongInfo, character) : OfflineTryReduceLoongBlockDebuff(loongInfo, character)) != 0)
					{
						isModified = true;
					}
				}
			}
			if (isModified)
			{
				DomainManager.Extra.SetLoongInfo(context, loongId, loongInfo);
			}
		}
	}

	public static void OnDefeatFiveLoongInCombat(DataContext context, sbyte combatStatus)
	{
		CombatConfigItem combatConfig = DomainManager.Combat.CombatConfig;
		if (combatStatus == 3 && combatConfig.TemplateId >= 182 && combatConfig.TemplateId <= 186)
		{
			short legacyId = DomainManager.Taiwu.GetRandomAvailableLegacy(context.Random, -1);
			if (DomainManager.Taiwu.AddAvailableLegacy(context, legacyId))
			{
				DomainManager.Combat.AddCombatResultLegacy(legacyId);
			}
			short legacyId2 = DomainManager.Taiwu.GetRandomAvailableLegacy(context.Random, -1);
			if (DomainManager.Taiwu.AddAvailableLegacy(context, legacyId2))
			{
				DomainManager.Combat.AddCombatResultLegacy(legacyId2);
			}
			short legacyId3 = DomainManager.Taiwu.GetRandomAvailableLegacy(context.Random, -1);
			if (DomainManager.Taiwu.AddAvailableLegacy(context, legacyId3))
			{
				DomainManager.Combat.AddCombatResultLegacy(legacyId3);
			}
		}
	}

	public static bool IsCharacterMinionLoong(short charTemplateId)
	{
		return charTemplateId >= 251 && charTemplateId <= 255;
	}

	public static bool IsCharacterLoong(short charTemplateId)
	{
		return charTemplateId >= 246 && charTemplateId <= 250;
	}

	public static short MinionLoongToLoong(short minionCharTemplateId)
	{
		return (short)(minionCharTemplateId - 251 + 246);
	}

	public static void AddLoongDebuffInstantNotification(short notificationTemplate, int debuffCount)
	{
		InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotificationCollection();
		switch (notificationTemplate)
		{
		case 120:
			instantNotificationCollection.AddThunderPowerGrow(debuffCount);
			break;
		case 121:
			instantNotificationCollection.AddFloodPowerGrow(debuffCount);
			break;
		case 123:
			instantNotificationCollection.AddStormPowerGrow(debuffCount);
			break;
		case 122:
			instantNotificationCollection.AddBlazePowerGrow(debuffCount);
			break;
		case 124:
			instantNotificationCollection.AddSandPowerGrow(debuffCount);
			break;
		case 125:
			instantNotificationCollection.AddThunderPowerDecline(debuffCount);
			break;
		case 126:
			instantNotificationCollection.AddFloodPowerDecline(debuffCount);
			break;
		case 128:
			instantNotificationCollection.AddStormPowerDecline(debuffCount);
			break;
		case 127:
			instantNotificationCollection.AddBlazePowerDecline(debuffCount);
			break;
		case 129:
			instantNotificationCollection.AddSandPowerDecline(debuffCount);
			break;
		}
	}

	public static bool IsBlockLoongBlock(MapBlockData block)
	{
		return MapBlock.Instance[block.TemplateId].SubType == EMapBlockSubType.DLCLoong;
	}

	private void UpdateMaxTaiwuVillageLevel()
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingAreaData taiwuBuildingAreaData = DomainManager.Building.GetBuildingAreaData(taiwuVillageLocation);
		BuildingBlockKey buildingBlockKey = BuildingDomain.FindBuildingKey(taiwuVillageLocation, taiwuBuildingAreaData, 44);
		MaxTaiwuVillageLevel = Math.Max(MaxTaiwuVillageLevel, DomainManager.Building.BuildingBlockLevel(buildingBlockKey));
	}

	private void InitializeJiaoData(DataContext context)
	{
		List<JiaoPool> jiaoPools = DomainManager.Extra.GetJiaoPoolList();
		List<JiaoPoolRecordList> jiaoPoolRecords = DomainManager.Extra.GetJiaoPoolRecordList();
		while (jiaoPools.Count < 9)
		{
			jiaoPools.Add(new JiaoPool());
			jiaoPoolRecords.Add(new JiaoPoolRecordList());
		}
		JiaoEggDropRate = GlobalConfig.Instance.InitJiaoEggDropRate;
		MaleJiaoEggDropRate = GlobalConfig.Instance.InitMaleJiaoEggDropRate;
		DomainManager.Extra.SetJiaoPools(jiaoPools, context);
		DomainManager.Extra.SetJiaoPoolRecords(jiaoPoolRecords, context);
	}

	private void InitializeMaxTaiwuVillageLevel()
	{
		UpdateMaxTaiwuVillageLevel();
	}

	private void InitializeJiaoCacheData()
	{
		foreach (var (id, jiao2) in DomainManager.Extra.Jiaos)
		{
			DomainManager.Extra.SetJiaoEvolutionChoice(id);
			DomainManager.Extra.SetJiaoKeyToId(jiao2.Key, id);
		}
		DomainManager.Extra.ResetJiaoPoolStatus(DataContextManager.GetCurrentThreadDataContext());
	}

	private void InitializeChildrenOfLoongCacheData()
	{
		foreach (var (id, loong) in DomainManager.Extra.ChildrenOfLoong)
		{
			DomainManager.Extra.SetChildOfLoongKeyToId(loong.Key, id);
		}
	}

	private void InitializeConfigCache()
	{
		_carrierToJiaoTemplate = new Dictionary<short, short>();
		foreach (JiaoItem jiaoCfg in (IEnumerable<JiaoItem>)Config.Jiao.Instance)
		{
			if (jiaoCfg.IndexOfCarrierTemplate >= 0)
			{
				_carrierToJiaoTemplate.Add(jiaoCfg.IndexOfCarrierTemplate, jiaoCfg.TemplateId);
			}
		}
	}

	private static bool TryCreateOrReAppearFiveLoong(DataContext context, bool isStrict, short characterTemplateId)
	{
		Tester.Assert(IsCharacterLoong(characterTemplateId), $"Wrong FiveLoong characterTemplateId: {characterTemplateId}");
		List<short> areaIds = new List<short>();
		List<short> stateIds = new List<short>();
		List<MapBlockData> neighborBlocks = new List<MapBlockData>();
		List<GameData.Domains.Character.Animal> animals = new List<GameData.Domains.Character.Animal>();
		areaIds.Clear();
		stateIds.Clear();
		neighborBlocks.Clear();
		stateIds.AddRange(DomainManager.Extra.GetFiveLoongStateIds());
		for (short areaId = 0; areaId < 135; areaId++)
		{
			areaIds.Add(areaId);
		}
		CollectionUtils.Shuffle(context.Random, areaIds);
		for (short i = 0; i < areaIds.Count; i++)
		{
			short areaId2 = areaIds[i];
			if (areaId2 != DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId && !DomainManager.Map.IsAreaBroken(areaId2))
			{
				sbyte stateId = DomainManager.Map.GetStateIdByAreaId(areaId2);
				if (!stateIds.Contains(stateId))
				{
					Span<MapBlockData> mapBlocks = DomainManager.Map.GetAreaBlocks(areaId2);
					Span<MapBlockData> span = mapBlocks;
					for (int j = 0; j < span.Length; j++)
					{
						MapBlockData centerBlock = span[j];
						if (!IsBlockMeet(centerBlock, isStrict))
						{
							continue;
						}
						neighborBlocks.Clear();
						if (isStrict)
						{
							DomainManager.Map.GetNeighborBlocks(areaId2, centerBlock.BlockId, neighborBlocks, 4);
							bool hasDevelopedNeighbor = false;
							foreach (MapBlockData neighborBlock in neighborBlocks)
							{
								if (!neighborBlock.IsNonDeveloped())
								{
									hasDevelopedNeighbor = true;
									break;
								}
							}
							if (!hasDevelopedNeighbor)
							{
								continue;
							}
						}
						neighborBlocks.Clear();
						DomainManager.Map.GetNeighborBlocks(areaId2, centerBlock.BlockId, neighborBlocks, 3);
						bool isCenterBlockMeet = true;
						if (neighborBlocks.Count < 24)
						{
							continue;
						}
						foreach (MapBlockData neighborBlock2 in neighborBlocks)
						{
							if (!IsBlockMeet(neighborBlock2))
							{
								isCenterBlockMeet = false;
								break;
							}
						}
						if (!isCenterBlockMeet)
						{
							continue;
						}
						Location centerLocation = centerBlock.GetLocation();
						stateIds.Add(stateId);
						Dictionary<short, short> blockConfigTemplateIds = new Dictionary<short, short>();
						foreach (MapBlockData neighborBlock3 in neighborBlocks)
						{
							blockConfigTemplateIds.Add(neighborBlock3.BlockId, neighborBlock3.TemplateId);
						}
						blockConfigTemplateIds.Add(centerBlock.BlockId, centerBlock.TemplateId);
						short loongTemplateId = LoongInfo.CharacterTemplateIdToLoongTemplateId(characterTemplateId);
						LoongItem loongCfg = Loong.Instance[loongTemplateId];
						if (DomainManager.Extra.TryGetElement_FiveLoongDict(characterTemplateId, out var loongInfo))
						{
							if (!loongInfo.IsDisappear)
							{
								return false;
							}
							RemoveMinionLoongsInArea(context, loongInfo.LoongTerrainCenterLocation.AreaId);
							MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
							monthlyNotifications.AddFiveLoongArise(centerLocation, characterTemplateId);
							loongInfo.LoongTerrainCenterLocation = centerLocation;
							loongInfo.LoongCurrentLocation = centerLocation;
							loongInfo.CoveredMapBlockTemplateId = blockConfigTemplateIds;
							loongInfo.IsDisappear = false;
							loongInfo.MapBlockExtraItems.Clear();
							DomainManager.Extra.SetLoongInfo(context, characterTemplateId, loongInfo);
						}
						else
						{
							DomainManager.Extra.SetLoongInfo(context, characterTemplateId, loongInfo = new LoongInfo(characterTemplateId, centerLocation, blockConfigTemplateIds));
						}
						MapBlockToLoong(context, centerBlock, centerBlock, loongCfg.MapBlock);
						DomainManager.Extra.CreateAnimalByCharacterTemplateId(context, characterTemplateId, centerLocation);
						DomainManager.World.TriggerExtraTask(context, 41, 236);
						DomainManager.World.TriggerExtraTask(context, 41, loongCfg.Task);
						int minionLoongCount = 0;
						int[] putLoongScaleBlockIndexes = new int[18];
						int[] putLoongEggBlockIndexes = new int[3];
						for (int k = 0; k < putLoongScaleBlockIndexes.Length; k++)
						{
							putLoongScaleBlockIndexes[k] = context.Random.Next(0, neighborBlocks.Count);
						}
						for (int l = 0; l < putLoongEggBlockIndexes.Length; l++)
						{
							putLoongEggBlockIndexes[l] = context.Random.Next(0, neighborBlocks.Count);
						}
						animals.Clear();
						CollectionUtils.Shuffle(context.Random, neighborBlocks);
						for (int neighborBlockIndex = 0; neighborBlockIndex < neighborBlocks.Count; neighborBlockIndex++)
						{
							MapBlockData neighborBlock4 = neighborBlocks[neighborBlockIndex];
							Location neighborLocation = neighborBlock4.GetLocation();
							MapBlockToLoong(context, neighborBlock4, centerBlock, loongCfg.MapBlock);
							DomainManager.Map.ClearBlockRandomEnemies(context, neighborBlock4);
							DomainManager.Map.SetBlockData(context, neighborBlock4);
							bool changedExtraItems = false;
							for (int m = 0; m < putLoongScaleBlockIndexes.Length; m++)
							{
								if (putLoongScaleBlockIndexes[m] == neighborBlockIndex)
								{
									LoongInfo loongInfo2 = loongInfo;
									if (loongInfo2.MapBlockExtraItems == null)
									{
										loongInfo2.MapBlockExtraItems = new Dictionary<Location, Inventory>();
									}
									if (!loongInfo.MapBlockExtraItems.TryGetValue(neighborLocation, out var inventory))
									{
										loongInfo.MapBlockExtraItems.Add(neighborLocation, inventory = new Inventory());
									}
									inventory.OfflineAddUncheck(new ItemKey(12, 0, 276, 0), 1);
									changedExtraItems = true;
								}
							}
							for (int n = 0; n < putLoongEggBlockIndexes.Length; n++)
							{
								if (putLoongEggBlockIndexes[n] == neighborBlockIndex)
								{
									LoongInfo loongInfo2 = loongInfo;
									if (loongInfo2.MapBlockExtraItems == null)
									{
										loongInfo2.MapBlockExtraItems = new Dictionary<Location, Inventory>();
									}
									if (!loongInfo.MapBlockExtraItems.TryGetValue(neighborLocation, out var inventory2))
									{
										loongInfo.MapBlockExtraItems.Add(neighborLocation, inventory2 = new Inventory());
									}
									inventory2.OfflineAddUncheck(new ItemKey(5, 0, 278, 0), 1);
									changedExtraItems = true;
								}
							}
							if (changedExtraItems)
							{
								DomainManager.Extra.SetLoongInfo(context, characterTemplateId, loongInfo);
							}
							if (DomainManager.Extra.TryGetAnimalIdsByLocation(new Location(areaId2, neighborLocation.BlockId), out var animalIds))
							{
								foreach (int animalId in animalIds)
								{
									if (DomainManager.Extra.TryGetAnimal(animalId, out var animal) && !IsCharacterMinionLoong(animal.CharacterTemplateId) && !IsCharacterLoong(animal.CharacterTemplateId))
									{
										animals.Add(animal);
									}
								}
							}
							if (minionLoongCount < GlobalConfig.Instance.FiveLoongDlcMinionLoongMaxCount)
							{
								MapBlockData blockData = DomainManager.Map.GetBlockData(neighborBlock4.AreaId, neighborBlock4.BlockId);
								MapBlockItem config = MapBlock.Instance[blockData.TemplateId];
								if (config.SubType == EMapBlockSubType.DLCLoong)
								{
									minionLoongCount++;
									DomainManager.Extra.CreateAnimalByCharacterTemplateId(context, loongCfg.MinionCharTemplateId, neighborLocation);
								}
							}
						}
						foreach (GameData.Domains.Character.Animal animal2 in animals)
						{
							Location targetLocation;
							if (DomainManager.Extra.IsAnimalAbleToAttack(animal2, isTaiwuVictim: false))
							{
								DomainManager.Extra.RemoveAnimal(context, animal2);
							}
							else if (TryGetValidAnimalMoveLocation(context, areaId2, neighborBlocks, out targetLocation))
							{
								DomainManager.Extra.SetAnimalLocation(context, animal2, targetLocation);
							}
						}
						return true;
					}
				}
			}
		}
		return false;
		static bool IsBlockMeet(MapBlockData mapBlockData, bool avoidBigBlock = false)
		{
			MapBlockItem config2 = mapBlockData.GetConfig();
			if (!mapBlockData.IsNonDeveloped() || mapBlockData.Destroyed || config2.TemplateId == 126)
			{
				return false;
			}
			if (avoidBigBlock && config2.Size > 1)
			{
				return false;
			}
			return true;
		}
	}

	public static void MapBlockToLoong(DataContext context, MapBlockData block, MapBlockData center, short templateId)
	{
		block = block.GetRootBlock();
		List<MapBlockData> targetBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		targetBlocks.Add(block);
		if (block.GetConfig().Size > 1)
		{
			targetBlocks.AddRange(block.GroupBlockList);
			DomainManager.Map.SplitMultiBlock(context, block);
		}
		ByteCoordinate centerPos = center.GetBlockPos();
		foreach (MapBlockData targetBlock in targetBlocks)
		{
			Tester.Assert(targetBlock.GetConfig().Size == 1, "targetBlock.GetConfig().Size == 1");
			if (targetBlock.GetManhattanDistanceToPos(centerPos.X, centerPos.Y) <= 3)
			{
				DomainManager.Map.ChangeBlockTemplate(context, targetBlock, templateId);
				DomainManager.Map.DestroyMapBlockItemsDirect(context, targetBlock);
				DomainManager.Map.SetBlockAndViewRangeVisible(context, targetBlock.AreaId, targetBlock.BlockId);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(targetBlocks);
	}

	public static bool TryGetValidAnimalMoveLocation(DataContext context, short areaId, List<MapBlockData> invalidBlocks, out Location location)
	{
		location = Location.Invalid;
		List<MapBlockData> blocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (block.Visible && block.IsNonDeveloped() && block.IsPassable() && (invalidBlocks == null || !invalidBlocks.Contains(block)))
			{
				blocks.Add(block);
			}
		}
		if (blocks.Count == 0)
		{
			return false;
		}
		short blockId = blocks.GetRandom(context.Random).BlockId;
		ObjectPool<List<MapBlockData>>.Instance.Return(blocks);
		location = new Location(areaId, blockId);
		return true;
	}

	public static void CreateAllFiveLoong(DataContext context)
	{
		if (DomainManager.Extra.FiveLoongDict.Count >= Loong.Instance.Count)
		{
			return;
		}
		foreach (LoongItem loongCfg in (IEnumerable<LoongItem>)Loong.Instance)
		{
			if (!TryCreateOrReAppearFiveLoong(context, isStrict: true, loongCfg.CharTemplateId))
			{
				TryCreateOrReAppearFiveLoong(context, isStrict: false, loongCfg.CharTemplateId);
			}
		}
		TameLoongEntry.DefeatAppearedFiveLoongByTaiwuCarriers(context);
	}

	public static int DefeatFiveLoong(DataContext context, short characterTemplateId)
	{
		Tester.Assert(characterTemplateId >= 246 && characterTemplateId <= 250, $"FiveLoong Wrong characterTemplateId: {characterTemplateId}");
		if (DomainManager.Extra.TryGetElement_FiveLoongDict(characterTemplateId, out var loongInfo))
		{
			Location centerLocation = loongInfo.LoongTerrainCenterLocation;
			if (loongInfo.CoveredMapBlockTemplateId != null)
			{
				foreach (KeyValuePair<short, short> item in loongInfo.CoveredMapBlockTemplateId)
				{
					item.Deconstruct(out var key, out var value);
					short blockId = key;
					short templateId = value;
					Location blockLocation = new Location(centerLocation.AreaId, blockId);
					DomainManager.Map.ChangeBlockTemplate(context, blockLocation, templateId, isTurnVisible: true);
					DomainManager.Map.SetBlockAndViewRangeVisible(context, blockLocation.AreaId, blockLocation.BlockId);
				}
				loongInfo.CoveredMapBlockTemplateId.Clear();
			}
			DomainManager.Extra.RemoveAnimalByLocationAndTemplateId(context, loongInfo.LoongCurrentLocation, characterTemplateId);
			short taskInfoTemplateId = (short)(characterTemplateId - 246 + 238);
			DomainManager.World.FinishTriggeredExtraTask(context, 41, taskInfoTemplateId);
			ushort count;
			bool needInstantNotification = loongInfo.CharacterDebuffCounts != null && loongInfo.CharacterDebuffCounts.TryGetValue(DomainManager.Taiwu.GetTaiwuCharId(), out count) && count > 0;
			if (loongInfo.CharacterDebuffCounts != null)
			{
				loongInfo.CharacterDebuffCounts.Clear();
			}
			if (needInstantNotification)
			{
				AddLoongDebuffInstantNotification(loongInfo.ConfigData.DebuffCountDecNotification, 0);
			}
			loongInfo.IsDisappear = true;
			loongInfo.DisappearDate = DomainManager.World.GetCurrDate();
			DomainManager.Extra.SetLoongInfo(context, characterTemplateId, loongInfo);
			return RemoveMinionLoongsInArea(context, loongInfo.LoongCurrentLocation.AreaId);
		}
		return 0;
	}

	private static int RemoveMinionLoongsInArea(DataContext context, short areaId)
	{
		if (DomainManager.Extra.TryGetAnimalAreaDataByAreaId(areaId, out var animalAreaData))
		{
			List<GameData.Domains.Character.Animal> animals = new List<GameData.Domains.Character.Animal>();
			foreach (List<int> animalIds in animalAreaData.Values)
			{
				foreach (int animalId in animalIds)
				{
					if (DomainManager.Extra.TryGetAnimal(animalId, out var animal) && IsCharacterMinionLoong(animal.CharacterTemplateId))
					{
						animals.Add(animal);
					}
				}
			}
			foreach (GameData.Domains.Character.Animal animal2 in animals)
			{
				DomainManager.Extra.RemoveAnimal(context, animal2);
			}
			return animals.Count;
		}
		return 0;
	}

	void IDlcEntry.OnLoadedArchiveData(bool firstEnable)
	{
		InitializeConfigCache();
		if (firstEnable)
		{
			InitializeJiaoData(DataContextManager.GetCurrentThreadDataContext());
		}
		InitializeJiaoCacheData();
		InitializeChildrenOfLoongCacheData();
		Events.RegisterHandler_TaiwuMove(OnTaiwuMove);
		Events.RegisterHandler_CombatSettlement(OnDefeatFiveLoongInCombat);
	}

	void IDlcEntry.OnEnterNewWorld()
	{
		InitializeConfigCache();
		InitializeJiaoData(DataContextManager.GetCurrentThreadDataContext());
		InitializeJiaoCacheData();
		InitializeChildrenOfLoongCacheData();
		Events.RegisterHandler_TaiwuMove(OnTaiwuMove);
		Events.RegisterHandler_CombatSettlement(OnDefeatFiveLoongInCombat);
	}

	void IDlcEntry.OnPostAdvanceMonth(DataContext context)
	{
		PostAdvanceMonth_Main(context);
		PostAdvanceMonth_ChildOfLoong(context);
		PostAdvanceMonth_JiaoPool(context);
		PostAdvanceMonth_JiaoPoolLog(context);
		PostAdvanceMonth_FiveLoongs(context);
	}

	public void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive)
	{
		FiveLoongDlcEntry entry = (FiveLoongDlcEntry)entryBeforeCrossArchive;
		MaleJiaoEggDropRate = entry.MaleJiaoEggDropRate;
		OwnedChildrenOfLoong = entry.OwnedChildrenOfLoong;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 27;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		*(int*)pCurrData = ChildrenOfLoongMonthlyEventChance;
		pCurrData += 4;
		*(int*)pCurrData = PulaoCricketLuckPoint;
		pCurrData += 4;
		*(int*)pCurrData = JiaoEggDropRate;
		pCurrData += 4;
		*(int*)pCurrData = MaleJiaoEggDropRate;
		pCurrData += 4;
		*pCurrData = (IsJiaoPoolOpen ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = OwnedChildrenOfLoong;
		pCurrData += 4;
		*(int*)pCurrData = MaxTaiwuVillageLevel;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ChildrenOfLoongMonthlyEventChance = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			PulaoCricketLuckPoint = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			JiaoEggDropRate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			MaleJiaoEggDropRate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			IsJiaoPoolOpen = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			OwnedChildrenOfLoong = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			MaxTaiwuVillageLevel = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

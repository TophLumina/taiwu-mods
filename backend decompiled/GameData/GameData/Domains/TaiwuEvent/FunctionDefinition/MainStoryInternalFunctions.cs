using System;
using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Story.MainStory;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.GameDataBridge;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class MainStoryInternalFunctions
{
	[EventFunction(457)]
	private static void ResetMartialArtTournament(EventScriptRuntime runtime, bool taiwuVictory)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure) || adventure.CoreId != 114668976)
		{
			throw new InvalidOperationException("ResetMartialArtTournament can only be used in WulinConference adventure.");
		}
		DomainManager.Organization.ResetMartialArtTournamentState(runtime.Context, adventure, taiwuVictory);
		if (taiwuVictory)
		{
			DomainManager.Taiwu.RecordLifeSummary(runtime.Context, 82);
		}
	}

	[EventFunction(458)]
	private static void OnLegendaryBookAdventureActivated(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure) && AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures.Exist(adventure.CoreId))
		{
			DomainManager.LegendaryBook.OnLegendaryBookAdventureActivated(runtime.Context, adventure);
			return;
		}
		if (runtime.ArgBox.Get("ConchShipPresetKey_MajorEvent", out AdventureMajorEvent majorEvent) && AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures.Exist(majorEvent.CoreId))
		{
			DomainManager.LegendaryBook.OnLegendaryBookAdventureActivated(runtime.Context, majorEvent);
			return;
		}
		throw new InvalidOperationException("OnLegendaryBookAdventureActivated can only be used in LegendaryBook adventure.");
	}

	[EventFunction(459)]
	private static void OnLegendaryBookAdventureRemoved(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure) && AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures.Exist(adventure.CoreId))
		{
			DomainManager.LegendaryBook.OnLegendaryBookAdventureRemoved(runtime.Context, adventure);
			return;
		}
		if (runtime.ArgBox.Get("ConchShipPresetKey_MajorEvent", out AdventureMajorEvent majorEvent) && AiHelper.LegendaryBookRelatedConstants.LegendaryBookAdventures.Exist(majorEvent.CoreId))
		{
			DomainManager.LegendaryBook.OnLegendaryBookAdventureRemoved(runtime.Context, majorEvent);
			return;
		}
		throw new InvalidOperationException("OnLegendaryBookAdventureRemoved can only be used in LegendaryBook adventure.");
	}

	[EventFunction(587)]
	private static void SetNextSwordTombAdventureCooldown()
	{
		int currAdventureCoreId = (DomainManager.Adventure.GetAdventureTaiwu().InAdventure ? DomainManager.Adventure.GetAdventureTaiwu().Adventure.CoreId : (DomainManager.Adventure.GetAdventureMajorEventTaiwu().InAdventure ? DomainManager.Adventure.GetAdventureMajorEventTaiwu().MajorEvent.CoreId : 0));
		sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdBySwordTomb(currAdventureCoreId);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetNextSwordTombAdventureCoolDownByFromAdventure(xiangshuAvatarId);
	}

	[EventFunction(588)]
	private static void RemoveSwordTombFromLocation(EventScriptRuntime runtime, MapBlockData mapBlockData)
	{
		MapBlockData rootBlock = mapBlockData.GetRootBlock();
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.RemoveSwordTomb, rootBlock);
	}

	[EventFunction(589)]
	private static int GetDefeatSwordTombCount()
	{
		return DomainManager.World.GetDefeatSwordTombCount();
	}

	[EventFunction(608)]
	private static Location GetLastSwordTombLocation()
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetLastSwordTombLocation();
	}

	[EventFunction(609)]
	private static void ActivateSwordTombAtLocation(MapBlockData mapBlock, int remainingMonth)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ActivateSwordTombAdventure(mapBlock.GetLocation(), (sbyte)remainingMonth);
	}

	[EventFunction(615)]
	private static void ActivateRemainingSwordTombs(int remainingMonth)
	{
		List<Location> toActivateSwordTombLocations = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRemainingSwordTombAdventure();
		foreach (Location location in toActivateSwordTombLocations)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ActivateSwordTombAdventure(location, (sbyte)remainingMonth);
		}
	}

	[EventFunction(610)]
	private static void DeactivateAllSwordTombAdventure()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DeActivateAllSwordTombAdventure();
	}

	[EventFunction(612)]
	private static void MakeSectCharactersApproveTaiwuInWulinConference(EventScriptRuntime runtime)
	{
		IRandomSource random = runtime.Context.Random;
		Span<sbyte> groupCharCounts = stackalloc sbyte[3] { 6, 4, 2 };
		List<SettlementCharacter> potentialCharacters = new List<SettlementCharacter>();
		for (sbyte orgTemplateId = 1; orgTemplateId <= 15; orgTemplateId++)
		{
			Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
			OrgMemberCollection memberCollection = settlement.GetMembers();
			for (sbyte group = 0; group < 2; group++)
			{
				sbyte charCount = groupCharCounts[group];
				(sbyte, sbyte) gradeRange = Grade.GetGroupGradeRange(group);
				var (grade, _) = gradeRange;
				while (grade <= gradeRange.Item2)
				{
					foreach (int charId in memberCollection.GetMembers(grade))
					{
						SectCharacter settlementChar = DomainManager.Organization.GetElement_SectCharacters(charId);
						if (!settlementChar.GetApprovedTaiwu())
						{
							potentialCharacters.Add(settlementChar);
						}
					}
					grade++;
				}
				for (int i = 0; i < charCount; i++)
				{
					if (potentialCharacters.Count == 0)
					{
						break;
					}
					SettlementCharacter settlementChar2 = potentialCharacters.GetRandom(random);
					settlementChar2.SetApprovedTaiwu(runtime.Context, approve: true);
				}
			}
		}
	}

	[EventFunction(613)]
	private static void YufuKillTopTenRankingCharacters(EventScriptRuntime runtime, int killCount)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || DomainManager.Character.TryGetFixedCharacterByTemplateId(913, out var yufu))
		{
			return;
		}
		AdventureRuntime adventure = DomainManager.Adventure.GetElement_Adventures(adventureId);
		IEnumerable<AdventureElement> potentialVictims = adventure.GetElementsByTag("YufuKillVictim");
		killCount = Math.Min(killCount, 15);
		Span<(int, int)> span = stackalloc(int, int)[killCount];
		SpanList<(int, int)> topK = span;
		foreach (AdventureElement victimElement in potentialVictims)
		{
			if (!DomainManager.Taiwu.IsCricketPolymorphCharacter(victimElement.CharacterId) && DomainManager.Character.TryGetElement_Objects(victimElement.CharacterId, out var character) && character.GetCreatingType() == 1)
			{
				topK.TryInsertTopK<int>(killCount, victimElement.CharacterId, character.GetCombatPower());
			}
		}
		int yufuId = yufu.GetId();
		int i = 0;
		for (int count = topK.Count; i < count; i++)
		{
			int charId = topK[i].Item1;
			GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(charId);
			if (DomainManager.Character.IsTemporaryIntelligentCharacter(charId))
			{
				DomainManager.Character.ConvertTemporaryIntelligentCharacter(runtime.Context, character2);
			}
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.KillCharacter(yufuId, charId, EKillCharacterType.KillInPublic);
		}
	}

	[EventFunction(823)]
	private static IntList ReleaseNoMindGuys(EventScriptRuntime runtime, int ensureCount)
	{
		return new IntList(from x in DomainManager.Extra.ReleaseAllKilledByLongYufuCharacters(runtime.Context, ensureCount)
			select x.GetId());
	}

	[EventFunction(825)]
	private static IntList GetNoMindGuyList(EventScriptRuntime runtime)
	{
		return new IntList(from x in DomainManager.Character.GetNoMindGuys()
			select x.GetId());
	}

	[EventFunction(616)]
	private static void SaveWorld(EventScriptRuntime runtime)
	{
		DomainManager.Global.SaveWorld(runtime.Context, 1);
	}

	[EventFunction(662)]
	private static void LoadDreamBackArchive(EventScriptRuntime runtime)
	{
		sbyte archiveId = GameData.ArchiveData.Common.GetCurrArchiveId();
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.TaiwuCrossArchive, arg1: true, archiveId);
	}

	[EventFunction(712)]
	private static void SaveArchiveForDreamBack(EventScriptRuntime runtime)
	{
		DomainManager.Global.SaveEnding(runtime.Context);
	}

	[EventFunction(617)]
	private static void MakeWorldChaos()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeWorldChaos();
	}

	[EventFunction(618)]
	private static void MakeTaiwuVillageAreaGraduallyBroken()
	{
		Dictionary<short, byte> protectedBlockMap = new Dictionary<short, byte>();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeAreaGraduallyBrokenInCondition(EventArgBox.TaiwuVillageAreaId, IsExcludeBlock, protectedBlockMap);
		static bool IsExcludeBlock(MapBlockData blockData)
		{
			return false;
		}
	}

	[EventFunction(630)]
	private static int GetSwordTombAdventureMaxMonthCount()
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSwordTombAdventureMaxMonthCount();
	}

	[EventFunction(643)]
	private static void TutorialHuanxingUnlockFuyuPower()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.HuanxinSavedByFuyuSwordAndAutoAllocateNeili();
	}

	[EventFunction(851)]
	private static void SetCharacterInvincibleInCombat(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool isInvincible)
	{
		if (character != null)
		{
			DomainManager.Combat.SetDefeatMarkImmunity(character.GetId(), isInvincible, isInvincible, isInvincible, isInvincible, isInvincible);
		}
	}

	[EventFunction(645)]
	private static void TutorialRemoveBuildingAreaBambooHouse()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveCenterBambooHouseOfTutorialArea();
	}

	[EventFunction(653)]
	private static void TutorialUnlockProfessionSkill(EventScriptRuntime runtime, int professionSkillId)
	{
		ProfessionSkillItem professionSkillCfg = ProfessionSkill.Instance[professionSkillId];
		int professionId = professionSkillCfg.Profession;
		ProfessionItem professionCfg = Profession.Instance[professionId];
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(professionId);
		int index = professionCfg.ProfessionSkills.IndexOf(professionSkillId);
		if (index < 0)
		{
			index = 3;
		}
		professionData.SetSkillLearned(index);
		professionData.Seniority = GameData.Domains.Taiwu.Profession.SharedMethods.GetSkillUnlockSeniority(professionSkillId);
		professionData.OfflineUpdateHadBeenUnlocked();
		DomainManager.Extra.SetProfessionData(runtime.Context, professionData);
	}

	[EventFunction(665)]
	private static void PrepareSectMembersAndTaiwuVillagersForSpiritualWanderPlace()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.PrepareSectMembersAndTaiwuVillagersForSpiritualWanderPlace();
	}

	[EventFunction(666)]
	private static void SetXiangshuMinionsSurroundTaiwuVillage(bool isOn)
	{
		if (isOn)
		{
			DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().Set("TrySurroundTaiwuVillage", arg: true);
		}
		else
		{
			DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().Remove<bool>("TrySurroundTaiwuVillage");
		}
	}

	[EventFunction(667)]
	private static sbyte GetLastXiangshuAvatar()
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetUndefeatedXiangshuAvatarId();
	}

	[EventFunction(668)]
	private static int GetLeaderInMaxApprovingRateSectByGoodness(sbyte sectGoodness)
	{
		short maxApprovingRate = -1;
		Settlement maxApprovingRateSect = null;
		foreach (OrganizationItem orgCfg in (IEnumerable<OrganizationItem>)Config.Organization.Instance)
		{
			if (orgCfg.IsSect && orgCfg.Goodness == sectGoodness)
			{
				Settlement sect = DomainManager.Organization.GetSettlementByOrgTemplateId(orgCfg.TemplateId);
				short approvingRate = sect.CalcApprovingRate();
				if (maxApprovingRate < approvingRate)
				{
					maxApprovingRate = approvingRate;
					maxApprovingRateSect = sect;
				}
			}
		}
		if (maxApprovingRateSect == null)
		{
			throw new Exception($"No sect with Goodness type {sectGoodness}.");
		}
		return maxApprovingRateSect.GetLeader().GetId();
	}

	[EventFunction(678)]
	private static void GetMartialArtTournamentReward(sbyte sectId)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		bool flag;
		switch (sectId)
		{
		case 1:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ClearHatredTowardTaiwu();
			return;
		case 2:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TaiwuVillageBuildingMaxLevelUp(3);
			return;
		case 3:
		case 5:
		case 7:
		case 9:
		case 13:
		case 15:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		if (flag)
		{
			AdaptableLog.TagWarning("GetMartialArtTournamentReward", $"SectId error:{sectId}");
			return;
		}
		switch (sectId)
		{
		case 4:
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 372))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 373, removeMutexFeature: true);
			}
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 371))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 372, removeMutexFeature: true);
			}
			if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 371) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 372) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 373))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 371, removeMutexFeature: true);
			}
			break;
		case 6:
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 375))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 376, removeMutexFeature: true);
			}
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 374))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 375, removeMutexFeature: true);
			}
			if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 374) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 375) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 376))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 374, removeMutexFeature: true);
			}
			break;
		case 8:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TryAddRandomPositiveFeature();
			break;
		case 10:
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 366))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 367, removeMutexFeature: true);
			}
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 365))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 366, removeMutexFeature: true);
			}
			if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 365) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 366) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 367))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 365, removeMutexFeature: true);
			}
			break;
		case 11:
		{
			sbyte type = (sbyte)GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, 6);
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ChangeBaseMainAttribute(taiwu, type, (short)(GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRoleMaxMainAttributes(taiwu, type) * 35 / 100));
			break;
		}
		case 12:
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 369))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 370, removeMutexFeature: true);
			}
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 368))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 369, removeMutexFeature: true);
			}
			if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 368) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 369) && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleHasFeature(taiwu, 370))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddFeature(taiwu, 368, removeMutexFeature: true);
			}
			break;
		case 14:
			if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRoleGender(taiwu) == 1)
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCloseFriend((!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckProbability(75)) ? ((sbyte)1) : ((sbyte)0));
			}
			else if (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRoleGender(taiwu) == 0)
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCloseFriend((sbyte)(GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckProbability(75) ? 1 : 0));
			}
			else
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCloseFriend(-1);
			}
			break;
		}
	}

	[EventFunction(705)]
	private static void GenerateEnemiesInBornArea(EventScriptRuntime runtime, int woodenManCount, int bronzeStatueCount)
	{
		Location bambooBlock = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetBambooHouseLocation();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		List<MapBlockData> aroundBlocks = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetBlocksAroundLocation(bambooBlock, 3);
		aroundBlocks.RemoveAll((MapBlockData e) => (e.AreaId == taiwuLocation.AreaId && e.BlockId == taiwuLocation.BlockId) || GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckBlockHasAdventure(e));
		for (int i = 0; i < woodenManCount; i++)
		{
			int rd = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, aroundBlocks.Count);
			Location location = new Location(aroundBlocks[rd].AreaId, aroundBlocks[rd].BlockId);
			switch (GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, 3))
			{
			case 0:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GenerateRandomEnemyOnBlock(location, 884);
				break;
			case 1:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GenerateRandomEnemyOnBlock(location, 885);
				break;
			case 2:
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GenerateRandomEnemyOnBlock(location, 886);
				break;
			}
		}
		for (int i2 = 0; i2 < bronzeStatueCount; i2++)
		{
			int rd2 = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, aroundBlocks.Count);
			Location location2 = new Location(aroundBlocks[rd2].AreaId, aroundBlocks[rd2].BlockId);
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GenerateRandomEnemyOnBlock(location2, 887);
		}
	}

	[EventFunction(707)]
	private static void GenerateCricketPlaceNearTaiwu(EventScriptRuntime runtime, int minGroupCount, int maxGroupCount, int minDistance, int maxDistance)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GenerateCricketPlaceNearTaiwu(minGroupCount, maxGroupCount, minDistance, maxDistance);
	}

	[EventFunction(708)]
	private static void SetCricketAtTaiwuLocationFake()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetCricketAtTaiwuLocationFake();
	}

	[EventFunction(765)]
	private static void ClearAreaCricket(EventScriptRuntime runtime, short areaTemplateId)
	{
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(areaTemplateId);
		DomainManager.Map.SetCricketPlaceData(runtime.Context, areaId, null);
	}

	[EventFunction(709)]
	private static void OpenMonthNotifyForStartCricketContent(EventScriptRuntime runtime, string nextEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.OpenMonthNotifyForStartCricketContent(nextEvent, runtime.ArgBox);
	}

	[EventFunction(713)]
	private static int CreateMissNingOfTaiwuVillage()
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateMissNingOfTaiwuVillage().GetId();
	}

	[EventFunction(714)]
	private static void StartShowSwordTombCreate(EventScriptRuntime runtime, string nextEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartShowSwordTombCreate();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(nextEvent, runtime.ArgBox, "MainStorySwordTombAppearComplete");
	}

	[EventFunction(715)]
	private static void ApplyHelpSectInStory(EventScriptRuntime runtime, GameData.Domains.Character.Character helpCharacter, GameData.Domains.Character.Character notHelpCharacter)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ApplyHelpSectInStory(runtime.Context, helpCharacter, notHelpCharacter);
	}

	[EventFunction(722)]
	private static void OpenLegacyActivateDisplay()
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenLegacyActivate);
	}

	[EventFunction(723)]
	private static void SetTaiwuVillageShowShrine(EventScriptRuntime runtime, bool shrineVisible)
	{
		DomainManager.TaiwuEvent.SetTaiwuVillageShowShrine(shrineVisible, runtime.Context);
	}

	[EventFunction(724)]
	private static void SetTaiwuAsLeaderOfTaiwuVillage(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetTaiwuAsLeaderOfTaiwuVillage();
	}

	[EventFunction(725)]
	private static void SetFirstSwordTombFinished(EventScriptRuntime runtime)
	{
		Location location = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSwordTombLocationAtIndex(0);
		MapBlockData rootBlock = DomainManager.Map.GetBlock(location).GetRootBlock();
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.RemoveSwordTomb, rootBlock);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetFirstSwordTombFinish();
		sbyte[] xiangshuAvatarIdTasksInOrder = DomainManager.World.GetXiangshuAvatarTasksInOrder();
		SwordTombItem swordTombCfg = SwordTomb.Instance[xiangshuAvatarIdTasksInOrder[0]];
		AchievementManager.RequestSetStat(runtime.Context, swordTombCfg.DefeatAchievementStat, 1);
	}

	[EventFunction(726)]
	private static void HideAllMapBlockCharacters(EventScriptRuntime runtime, bool hide)
	{
		DomainManager.TaiwuEvent.SetHideAllMapBlockCharacters(hide, runtime.Context);
	}

	[EventFunction(727)]
	private static void CreateAllSwordTombAdventure()
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateAllSwordTombAdventure();
	}

	[EventFunction(735)]
	private static int CreateBreakTombXiangshuAvatar()
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateBreakTombXiangshuFixedCharacterAtIndex(0);
	}

	[EventFunction(734)]
	private static int GetOrCreateFirstXiangshuAvatarForStory(bool isInvincible)
	{
		GameData.Domains.Character.Character character = (isInvincible ? GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetUndefeatedXiangshuCharacterForStory() : GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetCanDefeatedXiangshuCharacterForStory());
		return character.GetId();
	}

	[EventFunction(737)]
	private static UnmanagedVariant<TemplateKey> GetSwordFragmentTemplateByCharacter(GameData.Domains.Character.Character character)
	{
		sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(character.GetTemplateId());
		TemplateKey templateKey = new TemplateKey(12, SwordTomb.Instance[xiangshuAvatarId].SwordFragment);
		return new UnmanagedVariant<TemplateKey>(templateKey);
	}

	[EventFunction(748)]
	private static void SwordTombInvasion(EventScriptRuntime runtime)
	{
		int adventureId = 0;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdBySwordTomb(adventure.CoreId);
		if (xiangshuAvatarId < 0 || adventure.RemainMonths != 0)
		{
			return;
		}
		DomainManager.Global.InvokeGuidingTrigger(runtime.Context, 212);
		adventure.SetAutoDeleteDate(0u);
		DomainManager.Adventure.SetAny(runtime.Context, adventure);
		if (!adventure.StatusType.IsAsleep())
		{
			sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
			short templateId = XiangshuAvatarIds.GetCurrentLevelXiangshuTemplateId(xiangshuAvatarId, xiangshuLevel, isWeakened: true);
			GameData.Domains.Character.Character character = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetOrCreateFixedCharacterByTemplateId(templateId);
			List<Location> locationList = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetBlockLocationGroup(adventure.MapLocation);
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MoveFixedCharacter(character, locationList.Sample());
			if (DomainManager.World.GetXiangshuProgress() > 0 && GlobalConfig.Instance.SwordTombAdventureLastMonthCount[DomainManager.World.GetBossInvasionSpeedType()] > 0)
			{
				DomainManager.World.GetMonthlyEventCollection().AddXiangshuAvatarAttack(xiangshuAvatarId);
			}
			if (!DomainManager.TaiwuEvent.IsOneShotEventHandled(44) && DomainManager.Taiwu.GetTaiwu().GetConsummateLevel() < 4 && !DomainManager.Extra.IsDreamBack())
			{
				DomainManager.World.GetMonthlyEventCollection().AddWardOffXiangshuProtection(DomainManager.Taiwu.GetTaiwuCharId(), adventure.CoreId);
			}
		}
	}

	[EventFunction(788)]
	private static void SwordFragmentUnlockSkill(EventScriptRuntime runtime, sbyte xiangshuAvatarId)
	{
		List<sbyte> unlocked = DomainManager.Story.GetAdvanceXiangshuAvatarIds();
		if (!unlocked.Contains(xiangshuAvatarId))
		{
			unlocked.Add(xiangshuAvatarId);
			DomainManager.Story.SetAdvanceXiangshuAvatarIds(unlocked, runtime.Context);
		}
	}

	[EventFunction(792)]
	private static void ShowUnlockSkillSlotAnim(EventScriptRuntime runtime, int combatSkillEquipType, int slotCount, int neiliCount, string afterEvent)
	{
		if (!string.IsNullOrEmpty(afterEvent))
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "ShowUnlockSkillSlotAnimOver");
		}
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ShowUnlockSkillSlotAnim, combatSkillEquipType, slotCount, neiliCount);
	}

	[EventFunction(755)]
	private static void SetExorcismEnabled(EventScriptRuntime runtime, bool enabled)
	{
		DomainManager.World.SetExorcismEnabled(enabled, runtime.Context);
	}

	[EventFunction(758)]
	private static int GetXiangshuAvatarIdByCharacter(GameData.Domains.Character.Character character)
	{
		return XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(character.GetTemplateId());
	}

	[EventFunction(759)]
	private static void MarkTaiwuDieOfCombatWithXiangshuAttacking(EventScriptRuntime runtime)
	{
		DomainManager.Taiwu.SetIsTaiwuDieOfCombatWithXiangshu(value: true, runtime.Context);
	}

	[EventFunction(760)]
	private static void SetXiangshuDisplayStatus(EventScriptRuntime runtime, sbyte xiangshuAvatarId, sbyte displayStatus)
	{
		DomainManager.TaiwuEvent.SetRightRoleXiangshuDisplayData(new sbyte[2] { xiangshuAvatarId, displayStatus }, runtime.Context);
	}

	[EventFunction(761)]
	private static ValueInfo BlockHasNormalHeavenlyTree(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		MapBlockData blockData = parameters[0].GetAnyValue<MapBlockData>(evaluator);
		Location location = blockData.GetLocation();
		List<SectStoryHeavenlyTreeExtendable> trees = DomainManager.Extra.GetAllHeavenlyTrees();
		foreach (SectStoryHeavenlyTreeExtendable tree in trees)
		{
			if (tree.Location == location)
			{
				return evaluator.PushEvaluationResult(Config.Misc.Instance[tree.TemplateId].GroupId == 304);
			}
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(762)]
	private static void GetSwordTombInformation(EventScriptRuntime runtime, EInformationInfoSwordInformationType type, int xiangshuAvatarId)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSwordTombInformation(type, xiangshuAvatarId, runtime.ArgBox);
	}

	[EventFunction(766)]
	private static void SetNextSwordTombCountDownDate(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetNextSwordTombCountDownDate();
	}

	[EventFunction(770)]
	private static void DeepValleyToSmallVillage(EventScriptRuntime runtime, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "MainstoryMeetMapRiver");
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("DeepValleyToSmallVillage");
	}

	[EventFunction(771)]
	private static void SmallVillageToBrokenArea(EventScriptRuntime runtime, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "MainStoryHeroicWords");
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("SmallVillageToBrokenArea");
	}

	[EventFunction(772)]
	private static void BrokenAreaToTaiwuVillageArea(EventScriptRuntime runtime, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeBrokenPerformAreaCharacterAllDead();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "MainStotyEnterTaiwuArea");
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("BrokenAreaToTaiwuVillageArea");
	}

	[EventFunction(773)]
	private static void DeepValleyToTaiwuVillageArea(EventScriptRuntime runtime, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeBrokenPerformAreaCharacterAllDead();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "MainStoryHeroicWords");
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("DeepValleyToTaiwuVillageArea");
	}

	[EventFunction(813)]
	private static void TravelToPastTaiwuVillageArea(EventScriptRuntime runtime, string afterEvent)
	{
		if (!string.IsNullOrEmpty(afterEvent))
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "TravelToPastTaiwuVillage");
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("TravelToPastTaiwuVillageArea");
	}

	[EventFunction(820)]
	private static void BackFromPastTaiwuVillageArea(EventScriptRuntime runtime, string afterEvent)
	{
		if (!string.IsNullOrEmpty(afterEvent))
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "BackFromPastTaiwuVillage");
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddTravelCommand("BackFromPastTaiwuVillageArea");
	}

	[EventFunction(821)]
	private static void SetUnknownDateDisplay(EventScriptRuntime runtime, bool isUnknown, string onFinishEventId)
	{
		DomainManager.TaiwuEvent.SetListenerWithActionName(onFinishEventId, runtime.Current.ArgBox, "AfterSwitchDateDisplayFinish");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.SwitchDate, isUnknown);
	}

	[EventFunction(845)]
	private static int CurrAliveTwelveImmortalsTotalCount(EventScriptRuntime runtime)
	{
		return DomainManager.Story.CurrAliveTwelveImmortalsTotalCount();
	}

	[EventFunction(846)]
	private static int GenerateTwelveImmortals(EventScriptRuntime runtime, int count)
	{
		Span<sbyte> span = stackalloc sbyte[TwelveImmortals.Instance.Count];
		SpanList<sbyte> canCreateList = span;
		List<sbyte> createList = new List<sbyte>();
		foreach (TwelveImmortalsItem immortalCfg in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (!DomainManager.Story.IsTwelveImmortalsMemberCreated(immortalCfg.TemplateId))
			{
				canCreateList.Add(immortalCfg.TemplateId);
			}
		}
		int actualCount = Math.Min(count, canCreateList.Count);
		for (int i = 0; i < actualCount; i++)
		{
			int index = runtime.Context.Random.Next(canCreateList.Count);
			sbyte immortalId = canCreateList[index];
			createList.Add(immortalId);
			canCreateList.RemoveAt(index);
			DomainManager.Story.CreateTwelveImmortalsMember(runtime.Context, immortalId);
		}
		for (int j = 0; j < createList.Count; j++)
		{
			sbyte immortalId2 = createList[j];
			DomainManager.Story.SetTwelveImmortalsAssistData(runtime.Context, immortalId2);
		}
		return actualCount;
	}

	[EventFunction(863)]
	private static void TaiwuKillTwelveImmortals(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		short immortalsTemplateId = DomainManager.Story.GetTwelveImmortalsTemplateId(character.GetId());
		DomainManager.Character.RemoveTwelveImmortal(runtime.Context, (sbyte)immortalsTemplateId);
		DomainManager.Story.SetTwelveImmortalsAssistState(runtime.Context, immortalsTemplateId, 5);
	}

	[EventFunction(870)]
	private static void SetTwelveImmortalsAssistState(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte state)
	{
		short immortalsTemplateId = DomainManager.Story.GetTwelveImmortalsTemplateId(character.GetId());
		DomainManager.Story.SetTwelveImmortalsAssistState(runtime.Context, immortalsTemplateId, state);
	}

	[EventFunction(864)]
	private static void AssisterKillTwelveImmortals(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		short immortalsTemplateId = DomainManager.Story.GetTwelveImmortalsTemplateId(character.GetId());
		DomainManager.Character.RemoveTwelveImmortal(runtime.Context, (sbyte)immortalsTemplateId);
		DomainManager.Story.SetTwelveImmortalsAssistState(runtime.Context, immortalsTemplateId, 2);
	}

	[EventFunction(847)]
	private static ValueInfo IsTwelveImmortalsMember(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character == null)
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		short templateId = character.GetTemplateId();
		return evaluator.PushEvaluationResult(templateId >= 1075 && templateId <= 1086);
	}

	[EventFunction(848)]
	private static void GenerateMainStoryXiangshuMinion(EventScriptRuntime runtime, MapBlockData rootBlock, int range)
	{
		Location location = rootBlock.GetLocation();
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		neighborBlocks.AddRange(GenerateMainStoryXiangshuMinion(runtime.Context, location, range));
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	[EventFunction(842)]
	private static void GenerateChapter9XiangshuMinion(EventScriptRuntime runtime)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!location.IsValid())
		{
			throw new Exception($"generate failed at {location}");
		}
		DomainManager.TaiwuEvent.SaveArgToGlobalArgBox("CSPreset_Chapter9XiangshuMinionAtLocation", location);
		foreach (MapBlockData block in GenerateMainStoryXiangshuMinion(runtime.Context, location, 2))
		{
			if (block.IsNonDeveloped())
			{
				int blockId = runtime.Context.Random.Next(118, 124);
				DomainManager.Map.ChangeBlockTemplate(runtime.Context, block, (short)blockId);
			}
		}
	}

	private static IEnumerable<MapBlockData> GenerateMainStoryXiangshuMinion(DataContext context, Location location, int range)
	{
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, range);
		List<short> enemyTemplateIds = ObjectPool<List<short>>.Instance.Get();
		for (short id = 371; id <= 374; id++)
		{
			for (int i = 0; i < 2; i++)
			{
				enemyTemplateIds.Add(id);
			}
		}
		CollectionUtils.Shuffle(context.Random, neighborBlocks);
		CollectionUtils.Shuffle(context.Random, enemyTemplateIds);
		int generateCount = Math.Min(neighborBlocks.Count, enemyTemplateIds.Count);
		for (int j = 0; j < generateCount; j++)
		{
			short enemyTemplateId = enemyTemplateIds[j];
			MapBlockData block = neighborBlocks[j];
			Location validBlockLocation = block.GetLocation();
			MapTemplateEnemyInfo enemyInfo = new MapTemplateEnemyInfo(enemyTemplateId, validBlockLocation.BlockId, 5, -1, -1);
			Events.RaiseTemplateEnemyLocationChanged(context, enemyInfo, Location.Invalid, validBlockLocation);
			yield return block;
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
	}

	[EventFunction(857)]
	private static void CreateThreeWayDemon(EventScriptRuntime runtime)
	{
		List<short> areaList = new List<short>();
		List<MapBlockData> mbdl = new List<MapBlockData>();
		foreach (var (offset, demon) in RandomUtils.GetRandomUnrepeated(runtime.Context.Random, 15uL).Zip(new _003C_003Ez__ReadOnlyArray<short>(new short[3] { 1014, 1015, 1016 })))
		{
			areaList.Clear();
			DomainManager.Map.GetAllBrokenAreaInState((sbyte)offset, areaList);
			short areaId = areaList.MaxBy(DomainManager.Map.QueryAreaBrokenLevel);
			mbdl.Clear();
			DomainManager.Map.GetPassableBlocksInArea(areaId, mbdl);
			int block = (int)RandomUtils.GetRandomUnrepeated(runtime.Context.Random, (ulong)mbdl.Count).First();
			GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(runtime.Context, demon);
			Location location = character.GetLocation();
			Location dst = new Location(areaId, mbdl[block].BlockId);
			character.SetLocation(dst, runtime.Context);
			Events.RaiseFixedCharacterLocationChanged(runtime.Context, character.GetId(), location, dst);
			DomainManager.World.UpdateAreaStoryWeathers(runtime.Context, areaId, 20);
		}
	}

	[EventFunction(859)]
	private static void TeleportToTaiwuVillage(EventScriptRuntime runtime)
	{
		Location loc = DomainManager.Taiwu.GetTaiwuVillageLocation();
		if (loc.AreaId != DomainManager.Taiwu.GetTaiwu().GetValidLocation().AreaId)
		{
			DomainManager.Map.QuickTravel(runtime.Context, loc.AreaId);
		}
		DomainManager.Map.SetTeleportMove(teleport: true);
		DomainManager.Map.Move(runtime.Context, loc.BlockId);
		DomainManager.Map.SetTeleportMove(teleport: false);
	}

	[EventFunction(866)]
	private static void MoveCharacterAwaySuxiaImpactRange(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		TwelveImmortalsItem suxiaConfig = TwelveImmortals.DefValue.Suxia;
		if (!DomainManager.Character.TryGetFixedCharacterByTemplateId(suxiaConfig.Character, out var suxia))
		{
			return;
		}
		Location location = character.GetLocation();
		Location suxiaLocation = suxia.GetLocation();
		if (suxiaLocation.GetManhattanDistanceToPos(location) > suxiaConfig.ImpactRange)
		{
			return;
		}
		int targetDistance = suxiaConfig.ImpactRange + 1;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(location.AreaId);
		List<MapBlockData> prefer = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> normal = ObjectPool<List<MapBlockData>>.Instance.Get();
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			int distance = block.GetLocation().GetManhattanDistanceToPos(suxiaLocation);
			if (distance == targetDistance)
			{
				prefer.Add(block);
			}
			else
			{
				normal.Add(block);
			}
		}
		IRandomSource rnd = runtime.Context.Random;
		MapBlockData destBlock = ((prefer.Count > 0) ? prefer.GetRandom(rnd) : ((normal.Count > 0) ? normal.GetRandom(rnd) : null));
		if (destBlock == null)
		{
			throw new Exception($"{character} away suxia impact range failed at {suxiaLocation}, from {location}");
		}
		DomainManager.Character.GroupMove(runtime.Context, character, destBlock.GetLocation());
	}

	[EventFunction(867)]
	private static void LearnTwelveImmortalsCombatSkill(EventScriptRuntime runtime, GameData.Domains.Character.Character immortal)
	{
		TwelveImmortalsItem config = immortal.GetTwelveImmortalsConfig();
		if (config == null)
		{
			throw new Exception($"{immortal} is not one of the Twelve Immortals");
		}
		short skillTemplateId = config.CombatSkill;
		DomainManager.Taiwu.TaiwuLearnCombatSkill(runtime.Context, skillTemplateId, 31775);
	}

	[EventFunction(868)]
	private static void MakeChaishanBroken(EventScriptRuntime runtime)
	{
		MapBlockData[] blocks = DomainManager.Map.GetAreaBlockCollection(140).GetArray();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MakeBlocksBroken(140, blocks, null, null);
	}

	[EventFunction(869)]
	private static void RestoreAllAreaDestroyedBlocks(EventScriptRuntime runtime)
	{
		List<short> developed = new List<short>();
		List<short> normal = new List<short>();
		foreach (MapBlockItem blockCfg in (IEnumerable<MapBlockItem>)MapBlock.Instance)
		{
			if (blockCfg.Size <= 1)
			{
				if (blockCfg.Type == EMapBlockType.Developed)
				{
					developed.Add(blockCfg.TemplateId);
				}
				else if (blockCfg.Type == EMapBlockType.Normal)
				{
					normal.Add(blockCfg.TemplateId);
				}
			}
		}
		DataContext context = runtime.Context;
		for (short areaId = 0; areaId < 45; areaId++)
		{
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
			for (int i = 0; i < areaBlocks.Length; i++)
			{
				MapBlockData block = areaBlocks[i];
				if (!block.IsPassable() || block.BlockSubType != EMapBlockSubType.Ruin || !block.CanChangeBlockType() || block.RootBlockId >= 0)
				{
					continue;
				}
				short templateId = ((block.BelongBlockId >= 0) ? developed.GetRandom(context.Random) : normal.GetRandom(context.Random));
				DomainManager.Map.ClearBlockRandomEnemies(context, block);
				HashSet<int> enemyCharacterSet = block.EnemyCharacterSet;
				if (enemyCharacterSet != null && enemyCharacterSet.Count > 0)
				{
					int[] array = block.EnemyCharacterSet.ToArray();
					foreach (int charId in array)
					{
						if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetOrganizationInfo().OrgTemplateId == 19)
						{
							DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
						}
					}
				}
				DomainManager.Map.ChangeBlockTemplate(context, block.GetLocation(), templateId, isTurnVisible: false);
			}
		}
	}
}

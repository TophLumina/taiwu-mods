using System;
using System.Collections.Generic;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Character.Filters;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class WorldFunctions
{
	[EventFunction(51)]
	private static void AdvanceDays(EventScriptRuntime runtime, int days)
	{
		DomainManager.World.AdvanceDaysInMonth(runtime.Context, days);
	}

	[Obsolete]
	[EventFunction(52)]
	private static void ChangeMainStoryLineProgress(EventScriptRuntime runtime, short progress)
	{
		DomainManager.World.ChangeMainStoryLineProgress(runtime.Context, progress);
	}

	[EventFunction(53)]
	private static void SetWorldFunctionsStatus(EventScriptRuntime runtime, byte worldFunctionType)
	{
		DomainManager.World.SetWorldFunctionsStatus(runtime.Context, worldFunctionType);
		if (worldFunctionType == 25)
		{
			DomainManager.Organization.UpdateMartialArtTournament(runtime.Context);
		}
	}

	[EventFunction(849)]
	private static void ResetWorldFunctionStatus(EventScriptRuntime runtime, byte worldFunctionType)
	{
		DomainManager.World.ResetWorldFunctionsStatus(runtime.Context, worldFunctionType);
		if (worldFunctionType == 25)
		{
			DomainManager.Organization.UpdateMartialArtTournament(runtime.Context);
		}
	}

	[EventFunction(68)]
	private static void TriggerExtraTask(EventScriptRuntime runtime, int taskChainId, int taskInfoId)
	{
		DomainManager.World.TriggerExtraTask(runtime.Context, taskChainId, taskInfoId);
	}

	[EventFunction(69)]
	private static void FinishExtraTask(EventScriptRuntime runtime, int taskChainId, int taskInfoId)
	{
		DomainManager.World.FinishTriggeredExtraTask(runtime.Context, taskChainId, taskInfoId);
	}

	[EventFunction(70)]
	private static void FinishExtraTaskChain(EventScriptRuntime runtime, int taskChainId)
	{
		DomainManager.World.FinishAllTaskInChain(runtime.Context, taskChainId);
	}

	[EventFunction(115)]
	private static void TriggerSectMainStoryEndingCountDown(EventScriptRuntime runtime, sbyte orgTemplateId, bool isGoodEnding)
	{
		DomainManager.Story.TriggerSectMainStoryEndingCountDown(runtime.Context, orgTemplateId, isGoodEnding);
	}

	[EventFunction(116)]
	private static void SetSectMainStoryEnding(EventScriptRuntime runtime, sbyte orgTemplateId, bool isGoodEnding, int informationIndex, bool addInformation, string nextEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SectMainStoryEnd(orgTemplateId, isGoodEnding, informationIndex, nextEvent, runtime.Current.ArgBox, addInformation);
	}

	[EventFunction(93)]
	private static EventActorData CreateEventActor(EventScriptRuntime runtime, short actorTemplateId)
	{
		return EventActorDataHelper.CreateActor(runtime.Context.Random, actorTemplateId);
	}

	[EventFunction(114)]
	private static int GetIntelligentCharacterByFilter(EventScriptRuntime runtime, short characterFilterRuleId, short areaTemplateId, sbyte searchRangeType, bool createNew)
	{
		List<Predicate<GameData.Domains.Character.Character>> predicates = new List<Predicate<GameData.Domains.Character.Character>>();
		List<GameData.Domains.Character.Character> foundCharacters = new List<GameData.Domains.Character.Character>();
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		GameData.Domains.Character.Filters.CharacterFilterRules.ToPredicates(characterFilterRuleId, predicates, location);
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(areaTemplateId);
		switch (searchRangeType)
		{
		case 0:
			MapCharacterFilter.Find(predicates, foundCharacters, areaId);
			break;
		case 1:
		{
			List<short> areaList = ObjectPool<List<short>>.Instance.Get();
			sbyte curStateId = DomainManager.Map.GetStateIdByAreaId(areaId);
			DomainManager.Map.GetAllAreaInState(curStateId, areaList);
			MapCharacterFilter.ParallelFind(predicates, foundCharacters, areaList);
			ObjectPool<List<short>>.Instance.Return(areaList);
			break;
		}
		case 2:
			MapCharacterFilter.ParallelFind(predicates, foundCharacters, 0, 135);
			break;
		}
		if (foundCharacters.Count > 0)
		{
			return foundCharacters.GetRandom(runtime.Context.Random).GetId();
		}
		if (!createNew)
		{
			return -1;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.CreateTemporaryIntelligentCharacter(runtime.Context, characterFilterRuleId, location);
		DomainManager.Character.ConvertTemporaryIntelligentCharacter(runtime.Context, character);
		return character.GetId();
	}

	[EventFunction(92)]
	private static int CreateEnemyCharacter(EventScriptRuntime runtime, short characterTemplateId, bool adjustByXiangshuLevel)
	{
		CharacterItem template = Config.Character.Instance[characterTemplateId];
		if (adjustByXiangshuLevel && template.GroupId >= 0)
		{
			sbyte consummateLevel = DomainManager.Taiwu.GetTaiwu().GetConsummateLevel();
			short adjustedTemplateId = CharacterDomain.GetCharacterTemplateIdInGroup(template.GroupId, consummateLevel);
			template = Config.Character.Instance[adjustedTemplateId];
		}
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateNonIntelligentCharacter(template.TemplateId);
	}

	[EventFunction(99)]
	private static int GetFixedCharacter(EventScriptRuntime runtime, short characterTemplateId)
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(characterTemplateId, out var character))
		{
			return character.GetId();
		}
		if (DomainManager.Character.TryGetConvertedFixedCharacterByTemplateId(characterTemplateId, out character))
		{
			return character.GetId();
		}
		return DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(runtime.Context, characterTemplateId).GetId();
	}

	[EventFunction(100)]
	private static void MoveCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character character, MapBlockData block)
	{
		int charId = character.GetId();
		Location location = block?.GetLocation() ?? Location.Invalid;
		switch (character.GetCreatingType())
		{
		case 0:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MoveFixedCharacter(character, location);
			break;
		case 1:
			if (!DomainManager.Character.IsTemporaryIntelligentCharacter(charId) && !DomainManager.Taiwu.IsInGroup(charId))
			{
				if (location.IsValid())
				{
					GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MoveIntelligentCharacter(character, location);
				}
				else
				{
					GameData.Domains.TaiwuEvent.EventHelper.EventHelper.HideIntelligentCharacter(character);
				}
			}
			break;
		case 3:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MoveFixedEnemy(character, location);
			break;
		case 2:
			break;
		}
	}

	[EventFunction(139)]
	private static void SectStoryZhujianCreateCatchableThief(EventScriptRuntime runtime, short areaTemplateId)
	{
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(areaTemplateId);
		DomainManager.Story.CreateNewThief(runtime.Context, areaId);
	}

	[EventFunction(150)]
	private static void SectStoryZhujianCreateGearMate(EventScriptRuntime runtime)
	{
		GameData.Domains.Character.Character character = DomainManager.Extra.CreateGearMate(runtime.Context, 722);
		DomainManager.Extra.GearMateJoinGroup(runtime.Context, character.GetId());
	}

	[EventFunction(419)]
	private static int CreateGearMate(EventScriptRuntime runtime, short characterTemplateId)
	{
		return DomainManager.Extra.CreateGearMate(runtime.Context, characterTemplateId).GetId();
	}

	[EventFunction(149)]
	private static void AddBuilding(EventScriptRuntime runtime, short blockTemplateId, Settlement settlement, bool forcePlace, bool closeToCenter)
	{
		Location location = settlement.GetLocation();
		DomainManager.Building.PlaceBuildingAtBlock(runtime.Context, location.AreaId, location.BlockId, blockTemplateId, forcePlace, !closeToCenter);
	}

	[EventFunction(151)]
	private static void SectStoryZhujianAddAreaMerchantType(EventScriptRuntime runtime, short areaTemplateId, sbyte merchantType)
	{
		DomainManager.Extra.SetSectZhujianAreaMerchantType(runtime.Context, areaTemplateId, merchantType);
		DomainManager.Story.UpdateAreaMerchantType(runtime.Context);
	}

	[EventFunction(152)]
	private static void SectStoryZhujianRemoveAreaMerchantType(EventScriptRuntime runtime, short areaTemplateId)
	{
		DomainManager.Extra.RemoveSectZhujianAreaMerchantType(runtime.Context, areaTemplateId);
	}

	[EventFunction(328)]
	private static sbyte GetSectMainStoryEnding(EventScriptRuntime runtime, sbyte orgTemplateId)
	{
		return DomainManager.Story.GetSectMainStoryTaskStatus(orgTemplateId);
	}

	[EventFunction(329)]
	private static void OpenModifyBook(EventScriptRuntime runtime, string afterEvent = null)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.OpenModifyBook(afterEvent, runtime.ArgBox);
	}

	[EventFunction(355)]
	private static void SetBlackSnakeName(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetBlackSnakeName(runtime.ArgBox);
	}

	[EventFunction(330)]
	private static MapBlockData GetSectMapBlock(EventScriptRuntime runtime, sbyte orgTemplateId, int index)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		Location settlementLocation = settlement.GetLocation();
		List<short> blockIds = new List<short>();
		DomainManager.Map.GetSettlementBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
		short blockId = blockIds[index];
		return DomainManager.Map.GetBlock(new Location(settlementLocation.AreaId, blockId));
	}

	[EventFunction(332)]
	private static int GetCurrDate(EventScriptRuntime runtime)
	{
		return DomainManager.World.GetCurrDate();
	}

	[EventFunction(362)]
	private static int GetJixiCharacter(EventScriptRuntime runtime)
	{
		return DomainManager.Story.TryGetJixi()?.GetId() ?? (-1);
	}

	[EventFunction(363)]
	private static bool CopyFixedCharacterName(EventScriptRuntime runtime, short sourceCharTemplateId, short targetCharTemplateId)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CopyFixedCharacterName(runtime.ArgBox, sourceCharTemplateId, targetCharTemplateId);
	}

	[EventFunction(369)]
	private static ValueInfo TryGetJixiCharacter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		string tempArgKey = parameters[0].GetStringValue(evaluator);
		GameData.Domains.Character.Character jixi = DomainManager.Story.TryGetJixi();
		if (string.IsNullOrEmpty(tempArgKey))
		{
			return evaluator.PushEvaluationResult(jixi != null);
		}
		runtime.ArgBox.Set(tempArgKey, jixi?.GetId() ?? (-1));
		return evaluator.PushEvaluationResult(jixi != null);
	}

	[EventFunction(373)]
	private static bool DisableFixedCharacterAIMove(EventScriptRuntime runtime, short characterTemplateId, bool isDisabled)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DisableFixedCharacterAiMove(runtime.ArgBox, characterTemplateId, isDisabled);
	}

	[EventFunction(383)]
	private static bool CheckJixiCanFollow(EventScriptRuntime runtime)
	{
		GameData.Domains.Character.Character jixi = DomainManager.Story.TryGetJixi();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (jixi == null)
		{
			return false;
		}
		if (taiwu.GetId() != DomainManager.Taiwu.GetTaiwuCharIdForJixi())
		{
			return false;
		}
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		bool isSelect = false;
		if (sectArgBox.Get(SectMainStoryEventArgKey.DefValue.XuehouSelectFreeJixi, ref isSelect) && isSelect)
		{
			return false;
		}
		return true;
	}

	[EventFunction(447)]
	private static bool CheckJixiFollowing(EventScriptRuntime runtime)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		return sectArgBox.GetBool(SectMainStoryEventArgKey.DefValue.JixiFollowOpen);
	}

	[EventFunction(388)]
	private static void GearMateJoinGroup(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.Extra.GearMateJoinGroup(runtime.Context, character.GetId());
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ShowGetItemPageForCharacters(new List<int> { character.GetId() }, isVillager: false);
	}

	[EventFunction(389)]
	private static void GearMateLeaveGroup(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.Extra.GearMateLeaveGroup(runtime.Context, character.GetId());
	}

	[EventFunction(414)]
	private static void AddInstantNotificationNoArgument(EventScriptRuntime runtime, short templateId)
	{
		InstantNotificationItem config = InstantNotification.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotificationCollection();
		instantNotificationCollection.AddNotificationWithNoArgument(templateId);
	}

	[EventFunction(415)]
	private static void AddInstantNotificationArgumentOneCharacter(EventScriptRuntime runtime, short templateId, GameData.Domains.Character.Character character)
	{
		InstantNotificationItem config = InstantNotification.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotificationCollection();
		instantNotificationCollection.AddNotificationWithOneCharacterArgument(templateId, character.GetId());
	}

	[EventFunction(416)]
	private static void AddInstantNotificationArgumentTwoCharacter(EventScriptRuntime runtime, short templateId, GameData.Domains.Character.Character character0, GameData.Domains.Character.Character character1)
	{
		InstantNotificationItem config = InstantNotification.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotificationCollection();
		instantNotificationCollection.AddNotificationWithTwoCharacterArgument(templateId, character0.GetId(), character1.GetId());
	}

	[EventFunction(417)]
	private static void AddInstantNotificationArgumentThreeCharacter(EventScriptRuntime runtime, short templateId, GameData.Domains.Character.Character character0, GameData.Domains.Character.Character character1, GameData.Domains.Character.Character character2)
	{
		InstantNotificationItem config = InstantNotification.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotificationCollection();
		instantNotificationCollection.AddNotificationWithThreeCharacterArgument(templateId, character0.GetId(), character1.GetId(), character2.GetId());
	}

	[EventFunction(581)]
	private static void AddMonthlyNotificationNoArgument(EventScriptRuntime runtime, short templateId)
	{
		MonthlyNotificationItem config = MonthlyNotification.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		MonthlyNotificationCollection collection = DomainManager.World.GetMonthlyNotificationCollection();
		collection.AddMonthlyNotificationWithNoArgument(templateId);
	}

	[EventFunction(580)]
	private static void AddMonthlyEventNoArgument(EventScriptRuntime runtime, short templateId)
	{
		MonthlyEventItem config = MonthlyEvent.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		MonthlyEventCollection collection = DomainManager.World.GetMonthlyEventCollection();
		collection.AddMonthlyEventWithNoArgument(templateId);
	}

	[EventFunction(720)]
	private static void AddMonthlyEventArgumentOneCharacter(EventScriptRuntime runtime, short templateId, GameData.Domains.Character.Character character)
	{
		MonthlyEventItem config = MonthlyEvent.Instance[templateId];
		Tester.Assert(config.AllowByEventFunction);
		MonthlyEventCollection collection = DomainManager.World.GetMonthlyEventCollection();
		collection.AddMonthlyEventWithOneCharacterArgument(templateId, character.GetId());
	}

	[EventFunction(422)]
	private static ValueInfo CheckCorpsesCharacterGoodEnding(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		short templateId = character.GetTemplateId();
		bool result = DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(templateId)?.IsGoodEnd ?? false;
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(451)]
	private static int SetJixiGrow(EventScriptRuntime runtime, short characterTemplateId)
	{
		return DomainManager.Extra.SetJixiGrowByEvent(runtime.Context, characterTemplateId);
	}

	[EventFunction(600)]
	private static void SaveXiangshuLevel(EventScriptRuntime runtime, string saveKey)
	{
		runtime.ArgBox.Set(saveKey, DomainManager.World.GetXiangshuLevel());
	}

	[EventFunction(488)]
	private static bool CheckTaiwuChickenCount(int count)
	{
		return DomainManager.Building.GetSettlementChickenList(DomainManager.Taiwu.GetTaiwuVillageSettlementId()).Count >= count;
	}

	[EventFunction(701)]
	private static void TriggeredGuidingChapter(EventScriptRuntime runtime, short templateId)
	{
		DomainManager.Global.InvokeGuidingTrigger(runtime.Context, templateId);
	}

	[EventFunction(710)]
	private static void TaiwuRecordLifeSummary(EventScriptRuntime runtime, short templateId, int delta)
	{
		DomainManager.Taiwu.RecordLifeSummary(runtime.Context, templateId, delta);
	}

	[EventFunction(711)]
	private static void RequestSetStat(EventScriptRuntime runtime, short templateId, int value)
	{
		DomainManager.World.RequestSetStat(runtime.Context, templateId, value);
	}

	[EventFunction(717)]
	private static void ChangeActionPoint(EventScriptRuntime runtime, int delta)
	{
		if (delta < 0)
		{
			int remainPoints = DomainManager.Extra.GetTotalActionPointsRemaining();
			if (delta < -remainPoints)
			{
				delta = -remainPoints;
			}
		}
		DomainManager.Extra.ChangeActionPoint(runtime.Context, delta);
	}

	[EventFunction(793)]
	private static void SetAreaStoryWeather(EventScriptRuntime runtime, MapAreaData mapAreaData, sbyte weatherTemplateId)
	{
		DomainManager.World.UpdateAreaStoryWeathers(runtime.Context, mapAreaData.GetId(), weatherTemplateId);
	}
}

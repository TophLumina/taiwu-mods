using System.Collections.Generic;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Common;
using GameData.DLC;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class DlcSmarterChickenFunctions
{
	[EventFunction(909)]
	private static ValueInfo CheckSmarterChickenState(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte personalityType = parameters[0].GetAnyValue<sbyte>(evaluator);
		EPolymorphState stateType = (EPolymorphState)parameters[1].GetIntValue(evaluator);
		if (!DomainManager.Building.TryGetElement_SmarterChickens(personalityType, out var chicken))
		{
			return evaluator.PushEvaluationResult(stateType == EPolymorphState.None);
		}
		return evaluator.PushEvaluationResult(chicken.ContainsState(stateType));
	}

	[EventFunction(926)]
	private static ValueInfo IsEscapedChicken(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		short chickenTemplateId = parameters[0].GetAnyValue<short>(evaluator);
		int chickenId = DomainManager.Building.GetChickenByTemplateId(chickenTemplateId);
		List<int> escapedChicken = DomainManager.Building.GetEscapedChickenIds();
		return evaluator.PushEvaluationResult(escapedChicken.Contains(chickenId));
	}

	[EventFunction(959)]
	private static ValueInfo CharacterIsChicken(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool isChicken = character.CalcSmarterChickenPersonalityType() != -1;
		return evaluator.PushEvaluationResult(isChicken);
	}

	[EventFunction(906)]
	private static void SmarterChickenSetKingMonthlyEventInvoked(EventScriptRuntime runtime)
	{
		DataContext context = runtime.Context;
		EventArgBox argBox = DomainManager.Extra.GetOrCreateDlcArgBox(4975570uL, context);
		argBox.Set("KingMonthlyEventInvoked", arg: true);
		DomainManager.Extra.SetDlcArgBox(4975570uL, argBox, context);
	}

	[EventFunction(910)]
	private static int SmarterChickenBecomeCharacter(EventScriptRuntime runtime, sbyte personalityType, sbyte gender)
	{
		if (gender < 0)
		{
			gender = (sbyte)(runtime.Context.Random.NextBool() ? 1 : 0);
		}
		if (!DomainManager.Building.SmarterChickenBecomeCharacter(runtime.Context, personalityType, gender))
		{
			return -1;
		}
		if (!DomainManager.Building.TryGetElement_SmarterChickens(personalityType, out var chicken))
		{
			return -1;
		}
		return chicken.CurrentCharacterId;
	}

	[EventFunction(908)]
	private static bool SmarterChickenReturn(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return DomainManager.Building.SmarterChickenReturn(runtime.Context, character);
	}

	[EventFunction(925)]
	private static void AdoptChicken(EventScriptRuntime runtime, short chickenTemplateId, string nextEvent)
	{
		EventArgBox argBox = runtime.ArgBox;
		if (!string.IsNullOrEmpty(nextEvent))
		{
			DomainManager.TaiwuEvent.SetListenerWithActionName(nextEvent, argBox, "GetItemShowed");
		}
		DataContext context = runtime.Context;
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		int id = DomainManager.Building.GetChickenByTemplateId(chickenTemplateId);
		DomainManager.Building.MoveChicken(context, id, taiwuVillageSettlementId);
		GameData.Domains.Building.Chicken chicken = DomainManager.Building.GetChickenData(id);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Chicken, new List<GameData.Domains.Building.Chicken> { chicken });
	}

	[EventFunction(960)]
	private static void ChickenPolymorphEffect(EventScriptRuntime runtime, short charTemplateId, string afterEvent)
	{
		DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, runtime.ArgBox, "ChickenPolymorphEffectOver");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ChickenPolymorphEffect, charTemplateId, DomainManager.Character.GetChickenKingNickNameId(charTemplateId));
	}

	[EventFunction(966)]
	private static void CreateChickenEventActor(EventScriptRuntime runtime, short chickenTemplateId, string actorKey)
	{
		ChickenItem chicken = Config.Chicken.Instance[chickenTemplateId];
		short actorId = chicken.EventActorTemplateId;
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateAdventureActor(actorId, actorKey, runtime.ArgBox);
	}
}

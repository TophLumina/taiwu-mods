using Config;
using GameData.Domains.Character;
using GameData.Domains.Extra;
using GameData.Domains.Story.SectMainStory;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class SectMainStoryInternalFunctions
{
	[EventFunction(187)]
	private static void OpenEmeiCombatSkillSpecialBreak(GameData.Domains.Character.Character character)
	{
		short charTemplateId = character.GetTemplateId();
		bool flag;
		switch (charTemplateId)
		{
		case 560:
		case 562:
		case 563:
		case 564:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		bool isEmeiWhiteGibbon = flag;
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenCombatSkillSpecialBreak, charTemplateId, isEmeiWhiteGibbon);
	}

	[EventFunction(188)]
	private static void SectStoryEmeiSetMemberInsaneState(EventScriptRuntime runtime, bool isOn)
	{
		if (isOn)
		{
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(runtime.Context, 2, SectMainStoryEventArgKey.DefValue.EmeiKillEachOtherStage, 2);
		}
		else
		{
			DomainManager.Extra.RemoveArgToSectMainStoryEventArgBox<int>(runtime.Context, 2, SectMainStoryEventArgKey.DefValue.EmeiKillEachOtherStage);
		}
	}

	[EventFunction(871)]
	private static void CreateEmeiGuidance(EventScriptRuntime runtime)
	{
		DomainManager.Story.CreateEmeiGuidance(runtime.Context);
	}

	[EventFunction(872)]
	private static void ClearEmeiGuidance(EventScriptRuntime runtime)
	{
		DomainManager.Story.ClearEmeiGuidance(runtime.Context);
	}

	[EventFunction(873)]
	private static int GuideEmeiCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		DomainManager.Story.GuideEmeiCharacter(runtime.Context, target.GetId());
		SectEmeiGuidanceData data = DomainManager.Story.GetElement_SectEmeiGuidance(target.GetId());
		return data.Point;
	}

	[EventFunction(874)]
	private static int GetCharacterEmeiGuidanceType(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		SectEmeiGuidanceData data;
		return DomainManager.Story.TryGetElement_SectEmeiGuidance(target.GetId(), out data) ? data.EmeiGuidanceCombatSkillType : 0;
	}

	[EventFunction(875)]
	private static bool GetCharacterEmeiGuidanceChanged(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		SectEmeiGuidanceData data;
		bool res = DomainManager.Story.TryGetElement_SectEmeiGuidance(target.GetId(), out data) && data.Changed;
		if (data != null)
		{
			data.Changed = false;
		}
		DomainManager.Story.SetEmeiGuidanceData(runtime.Context, target.GetId(), data);
		return res;
	}

	[EventFunction(876)]
	private static int GetCharacterEmeiGuidanceNotch(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		SectEmeiGuidanceData data;
		return DomainManager.Story.TryGetElement_SectEmeiGuidance(target.GetId(), out data) ? data.Point : 0;
	}

	[EventFunction(877)]
	private static int GetCharacterEmeiGuidanceByType(EventScriptRuntime runtime, int type)
	{
		return DomainManager.Story.GetEmeiGuidanceCharacterByType(type);
	}

	[EventFunction(881)]
	private static void EmeiInteractionOneAdd(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		if (character == null)
		{
			return;
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		if (!argBox.ContainsKey(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList))
		{
			IntList intList = IntList.Create();
			if (!intList.Items.Contains(character.GetId()))
			{
				intList.Items.Add(character.GetId());
			}
			argBox.Set(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList, intList);
		}
		else
		{
			IntList intList2 = argBox.Get<IntList>(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList);
			if (!intList2.Items.Contains(character.GetId()))
			{
				intList2.Items.Add(character.GetId());
			}
			argBox.Set(SectMainStoryEventArgKey.DefValue.EmeiInteractionOneTriggeredList, intList2);
		}
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(runtime.Context, 2);
	}

	[EventFunction(882)]
	private static void EmeiInteractionTwoAdd(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		if (character == null)
		{
			return;
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		if (!argBox.ContainsKey(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList))
		{
			IntList intList = IntList.Create();
			if (!intList.Items.Contains(character.GetId()))
			{
				intList.Items.Add(character.GetId());
			}
			argBox.Set(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList, intList);
		}
		else
		{
			IntList intList2 = argBox.Get<IntList>(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList);
			if (!intList2.Items.Contains(character.GetId()))
			{
				intList2.Items.Add(character.GetId());
			}
			argBox.Set(SectMainStoryEventArgKey.DefValue.EmeiInteractionTwoTriggeredList, intList2);
		}
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(runtime.Context, 2);
	}

	[EventFunction(195)]
	private static void OpenYuanshanMiniGame(EventScriptRuntime runtime, string onFinishEvent, int stage)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.OpenYuanshanMiniGame(stage, onFinishEvent, runtime.Current.ArgBox);
	}

	[EventFunction(196)]
	private static int ProcessYuanshanMiniGameResults(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ProcessYuanshanMiniGameResults(runtime.Current.ArgBox);
	}

	[EventFunction(207)]
	private static bool IsVitalInPrison(EventScriptRuntime runtime, int index)
	{
		return DomainManager.Extra.GetSectYuanshanThreeVitals()[index].IsInPrison;
	}

	[EventFunction(208)]
	private static void SetVitalInPrison(EventScriptRuntime runtime, int index, bool value)
	{
		DomainManager.Extra.SetVitalInPrison(runtime.Context, (SectStoryThreeVitalsCharacterType)index, value);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayVitalAnim, index, value);
	}

	[EventFunction(209)]
	private static void PlayVitalAnim(EventScriptRuntime runtime, int index, bool value)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayVitalAnim, index, value);
	}

	[EventFunction(211)]
	private static bool AreVitalsDemon(EventScriptRuntime runtime)
	{
		return DomainManager.Extra.AreVitalsDemon();
	}

	[EventFunction(212)]
	private static int GetCurrentVitalIndex(EventScriptRuntime runtime)
	{
		return DomainManager.Extra.GetCurrentVitalIndex();
	}

	[EventFunction(214)]
	private static void InitThreeVitals(EventScriptRuntime runtime)
	{
		DomainManager.Extra.InitThreeVitals(runtime.Context);
	}

	[EventFunction(833)]
	private static bool GetThreeVitalsBetray(EventScriptRuntime runtime, int index)
	{
		return DomainManager.Extra.GetThreeVitalsBetray((SectStoryThreeVitalsCharacterType)index);
	}

	[EventFunction(244)]
	private static void SectMainStoryUnlockUI(EventScriptRuntime runtime, sbyte organizationId, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ShowSectMainStoryUnlock(organizationId, afterEvent, runtime.Current.ArgBox);
	}

	[EventFunction(460)]
	private static void SetRanshanThreeCorpseFollowing(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool following)
	{
		short characterTemplateId = character.GetTemplateId();
		DomainManager.Extra.SetRanshanThreeCorpsesCharacterFollowing(runtime.Context, characterTemplateId, following);
		if (!following)
		{
			DomainManager.Extra.ClearRanshanThreeCorpsesTarget(runtime.Context, characterTemplateId);
		}
	}

	[EventFunction(819)]
	private static void SetIconPlateIsUnlocked(EventScriptRuntime runtime, bool isUnlocked)
	{
		DomainManager.Story.SetIconPlateIsUnlocked(runtime.Context, isUnlocked);
	}

	[EventFunction(852)]
	private static void SetDivineFlameIsUnlocked(EventScriptRuntime runtime, bool isUnlocked)
	{
		DomainManager.Story.SetDivineFlameIsUnlocked(runtime.Context, isUnlocked);
	}
}

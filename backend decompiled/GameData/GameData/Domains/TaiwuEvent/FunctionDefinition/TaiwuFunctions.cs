using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class TaiwuFunctions
{
	[EventFunction(47)]
	private static void AddLegacyPoint(EventScriptRuntime runtime, short templateId)
	{
		DomainManager.Taiwu.AddLegacyPoint(runtime.Context, templateId);
	}

	[EventFunction(48)]
	private static void ExpelTaiwuVillager(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.Taiwu.ExpelVillager(runtime.Context, character.GetId());
	}

	[EventFunction(49)]
	private static void MakeAppointment(EventScriptRuntime runtime, GameData.Domains.Character.Character character, Location location)
	{
		DomainManager.Taiwu.AddAppointment(runtime.Context, character.GetId(), location);
	}

	[EventFunction(50)]
	private static void RemoveAppointment(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		character.RemoveGoal(runtime.Context, 254);
		DomainManager.Taiwu.RemoveAppointment(runtime.Context, character.GetId());
	}

	[EventFunction(147)]
	private static void CharacterTeachTaiwuProfession(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int professionId)
	{
		int charId = character.GetId();
		DomainManager.Character.CharacterTeachTaiwuProfession(runtime.Context, charId, professionId);
	}

	[EventFunction(156)]
	private static void TriggerLegacyPassingEvent(EventScriptRuntime runtime, bool isTaiwuDying, string onFinishEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TriggerLegacyPassingEvent(isTaiwuDying, onFinishEvent);
	}

	[EventFunction(275)]
	private static int GetMovePointValue(EventScriptRuntime runtime, bool cost)
	{
		int leftMovePoint = DomainManager.Extra.GetActionPointCurrMonth();
		if (!cost)
		{
			return leftMovePoint;
		}
		return DomainManager.World.ActionPointMax - leftMovePoint;
	}

	[EventFunction(327)]
	private static bool RandomSuccessorActive(EventScriptRuntime runtime)
	{
		return DomainManager.World.GetAllowRandomTaiwuHeir();
	}

	[EventFunction(531)]
	private static bool SaveCharacterCombatSkill(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte combatSkillType, sbyte grade, string saveKey)
	{
		List<short> learnedCombatSkills = character.GetLearnedCombatSkills();
		List<short> meetList = new List<short>();
		foreach (short templateId in learnedCombatSkills)
		{
			CombatSkillItem config = Config.CombatSkill.Instance[templateId];
			if ((config.Grade == grade || grade < 0) && (config.Type == combatSkillType || combatSkillType == -1))
			{
				meetList.Add(templateId);
			}
		}
		if (meetList.Count > 0)
		{
			runtime.ArgBox.Set(saveKey, meetList.GetRandom(runtime.Context.Random));
			return true;
		}
		return false;
	}

	[EventFunction(532)]
	private static bool ChangeTaiwuCombatSkillProficiency(EventScriptRuntime runtime, short combatSkillTemplateId, int delta)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<short> learnedCombatSkills = taiwu.GetLearnedCombatSkills();
		if (!learnedCombatSkills.Contains(combatSkillTemplateId))
		{
			return false;
		}
		CombatSkillKey key = new CombatSkillKey
		{
			CharId = taiwu.GetId(),
			SkillTemplateId = combatSkillTemplateId
		};
		DomainManager.Extra.ChangeCombatSkillProficiency(runtime.Context, key, delta);
		return true;
	}

	[EventFunction(584)]
	private static void TeleportMoveTaiwuToBlock(EventScriptRuntime runtime, MapBlockData mapBlockData)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TeleportMoveTaiwuToBlock(mapBlockData.GetLocation().BlockId);
	}

	[EventFunction(585)]
	private static void AddTaiwuPropertyPermanentBonus(EventScriptRuntime runtime, short propertyRefTemplateId, EDataModifyType bonusType, int value)
	{
		DomainManager.Taiwu.AddTaiwuPropertyPermanentBonus(runtime.Context, CharacterPropertyReferenced.Instance[propertyRefTemplateId].Type, bonusType, value);
	}

	[EventFunction(681)]
	private static void SetHideAllTeammates(EventScriptRuntime runtime, bool isOn)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetHideAllTeammates(isOn);
	}

	[EventFunction(744)]
	private static void AddWarehouseItem(EventScriptRuntime runtime, ItemKey itemKey, int amount)
	{
		DomainManager.Taiwu.WarehouseAdd(runtime.Context, itemKey, amount);
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
		instantNotification.AddGetItem(DomainManager.Taiwu.GetTaiwu().GetId(), itemKey.ItemType, itemKey.TemplateId);
		runtime.Current.RegisterToShowGetItem(itemKey, amount);
	}

	[EventFunction(893)]
	private static void AddFuyuFaithBySecure(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		character.SavedFromInfected(runtime.Context);
	}

	[EventFunction(894)]
	private static void AddTianjiefuluBySecure(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		int count = character.SaveFromInfectedGainFaith;
		ItemKey itemKey = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(DomainManager.Taiwu.GetTaiwu(), 8, 432, count, -1);
		runtime.Current.RegisterToShowGetItem(itemKey, count);
	}

	[EventFunction(603)]
	private static void PlayTutorialVideo(EventScriptRuntime runtime, short templateId)
	{
		TutorialVideoItem config = TutorialVideo.Instance[templateId];
		DomainManager.TutorialChapter.SetGuidVideoTemplateId(config.TemplateId, runtime.Context);
	}

	[EventFunction(637)]
	private static void BackToTutorialChapterMenu(EventScriptRuntime runtime, bool isComplete = true)
	{
		short currChapterId = DomainManager.TutorialChapter.GetTutorialChapter();
		int unlockChapter = (isComplete ? (currChapterId + 1) : currChapterId);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.BackToTutorialChapterMenu, unlockChapter);
	}

	[EventFunction(635)]
	private static void SetTutorialFunctionStatus(EventScriptRuntime runtime, short functionType, bool isOn)
	{
		DomainManager.TutorialChapter.SetTutorialFunctionStatus(runtime.Context, functionType, isOn);
	}

	[EventFunction(646)]
	private static void SetAllTutorialFunctionStatuses(EventScriptRuntime runtime, bool isOn)
	{
		DomainManager.TutorialChapter.SetAllTutorialFunctionStatuses(runtime.Context, isOn);
	}

	[EventFunction(826)]
	private static void BanNormalAttackInTutorial(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool ban)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.EnableNormalAttackInTutorial(character.GetId(), !ban);
	}

	[EventFunction(827)]
	private static void BanMoveInTutorial(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ClearMobilityAndForbidRecover(character.GetId());
	}

	[EventFunction(828)]
	private static void BanEnemyAiInTutorial(EventScriptRuntime runtime, bool ban)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.EnableEnemyAiInTutorial(!ban);
	}

	[EventFunction(858)]
	private static void TaiwuSetClothing(EventScriptRuntime runtime, short templateId)
	{
		DomainManager.Taiwu.SetSpecifyClothingTemplateId(templateId, runtime.Context);
	}
}

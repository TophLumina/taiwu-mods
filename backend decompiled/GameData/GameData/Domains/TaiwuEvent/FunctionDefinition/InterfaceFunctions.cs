using System.Collections.Generic;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class InterfaceFunctions
{
	[EventFunction(16)]
	private static void PlayAudio(EventScriptRuntime runtime, string audioName)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.SetMainStoryBgm, audioName);
	}

	[EventFunction(482)]
	private static void PerformCutscene(EventScriptRuntime runtime, short cutsceneId, string onFinishEventId)
	{
		DomainManager.TaiwuEvent.SetListenerWithActionName(onFinishEventId, runtime.Current.ArgBox, "PerformCutsceneComplete");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PerformCutscene, cutsceneId);
	}

	[EventFunction(197)]
	private static void SpecifyEventBackground(EventScriptRuntime runtime, string backgroundName)
	{
		runtime.ArgBox.Set("ConchShip_PresetKey_SpecifyEventBackground", backgroundName);
	}

	[EventFunction(483)]
	private static void BlackMask(EventScriptRuntime runtime, bool showMask, float animDuration, bool hideAfter, string nextEvent)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OperateBlackMaskView, showMask, animDuration, hideAfter);
		DomainManager.TaiwuEvent.SetListenerWithActionName(nextEvent, runtime.Current.ArgBox, showMask ? "OnBlackMaskShowComplete" : "OnBlackMaskHideComplete");
	}

	[EventFunction(512)]
	private static void AddAudioCommand(EventScriptRuntime runtime, string audioName, bool isLoop)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommand, audioName, arg2: false, isLoop);
	}

	[EventFunction(514)]
	private static void ChangeMusicStatusWithFade(EventScriptRuntime runtime, string audioName, bool isAmbience, bool isFadeOut, float fadeTime)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommandWithFade, audioName, isAmbience, isFadeOut, fadeTime);
	}

	[EventFunction(444)]
	private static void ChangeMusicStatus(EventScriptRuntime runtime, bool isPause)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ChangeMusicStatus, isPause);
	}

	[EventFunction(445)]
	private static void ChangeSoundStatus(EventScriptRuntime runtime, bool isPause)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ChangeSoundStatus, isPause);
	}

	[EventFunction(530)]
	private static void ShowExchangePanel(EventScriptRuntime runtime, int characterId, string onFinishEventId)
	{
		DomainManager.TaiwuEvent.SetListenerWithActionName(onFinishEventId, runtime.Current.ArgBox, "ExchangeComplete");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ShowExchangePanel, characterId, onFinishEventId);
	}

	[EventFunction(965)]
	private static void ShowNewFunctionUnlock(EventScriptRuntime runtime, int templateId, string afterEventId)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ShowNewFeatureUnlock(new List<int> { templateId }, afterEventId, runtime.Current.ArgBox);
	}

	[EventFunction(614)]
	private static void SetEventCgTextureByName(string textureName, float animDuration)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetEventCgTextureData(textureName, animDuration);
	}

	[EventFunction(611)]
	private static void SetEventCgTexture(EventScriptRuntime runtime, short cgTextureTemplateId)
	{
		DomainManager.TaiwuEvent.ShowCgTexture(cgTextureTemplateId);
	}

	[EventFunction(680)]
	private static void ShowEventCgTextureInPictureShowPage(EventScriptRuntime runtime, short templateId, string onFinishEventId)
	{
		DomainManager.TaiwuEvent.ShowCgTextureInPictureShowPage(runtime, templateId, onFinishEventId);
	}

	[EventFunction(661)]
	private static void BackToMainMenu(EventScriptRuntime runtime)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.BackToMainMenu);
	}

	[EventFunction(742)]
	private static void ChangeMusicVolume(EventScriptRuntime runtime, int volume, float fadeTime)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ChangeMusicVolume, volume, fadeTime);
	}

	[EventFunction(743)]
	private static void PlayMusicForCount(EventScriptRuntime runtime, string musicName, int count, string nextMusic)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayMusicForCount, musicName, count, nextMusic);
	}

	[EventFunction(829)]
	private static void SetObtainPopupEnabled(EventScriptRuntime runtime, bool enabled)
	{
		runtime.Current.SetObtainPopupEnabled(enabled);
	}

	[EventFunction(832)]
	private static void CloseCharacterMenu(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CloseCharacterMenu();
	}
}

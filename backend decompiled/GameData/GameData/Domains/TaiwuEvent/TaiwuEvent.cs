using System;
using System.Collections.Generic;
using System.IO;
using CompDevLib.Interpreter;
using Config;
using Config.EventConfig;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Domains.Mod;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.Enum;
using GameData.Domains.TaiwuEvent.EventOption;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent;

public class TaiwuEvent : IValueSelector
{
	public static readonly TaiwuEvent Empty = new TaiwuEvent
	{
		EventGuid = Guid.Empty.ToString(),
		EventConfig = null,
		ArgBox = null
	};

	private List<int> _needNameRelatedDataCharacterIdList;

	public string EventGuid;

	public TaiwuEventItem EventConfig;

	private EventArgBox _argBox;

	public List<(string, string)> ExtendEventOptions;

	private Dictionary<string, int> _name2IdMap;

	public bool IsEmpty
	{
		get
		{
			if (string.IsNullOrEmpty(EventGuid))
			{
				return true;
			}
			if (EventGuid == Empty.EventGuid)
			{
				return true;
			}
			if (EventConfig == null)
			{
				return true;
			}
			return false;
		}
	}

	public List<int> NeedNameRelatedDataCharacterIdList
	{
		get
		{
			if (_needNameRelatedDataCharacterIdList == null)
			{
				_needNameRelatedDataCharacterIdList = new List<int>();
			}
			return _needNameRelatedDataCharacterIdList;
		}
	}

	public EventArgBox ArgBox
	{
		get
		{
			return _argBox;
		}
		set
		{
			if (value == null && DomainManager.TaiwuEvent.IsTriggeredEvent(EventGuid))
			{
				return;
			}
			_argBox = value;
			if (EventConfig != null)
			{
				EventConfig.ArgBox = value;
				for (int i = 0; i < EventConfig.EventOptions.Length; i++)
				{
					EventConfig.EventOptions[i].ArgBox = value;
				}
			}
		}
	}

	public TaiwuEvent()
	{
	}

	public TaiwuEvent(TaiwuEvent other)
	{
		EventGuid = other.EventGuid;
	}

	public void AddOption(string srcEventGuid, string optionKey)
	{
		AddOption((srcEventGuid, optionKey));
	}

	public void AddOption((string, string) optionInfo)
	{
		if (ExtendEventOptions == null)
		{
			ExtendEventOptions = new List<(string, string)>();
		}
		for (int i = 0; i < ExtendEventOptions.Count; i++)
		{
			(string, string) tuple = ExtendEventOptions[i];
			if (optionInfo.Item1 == tuple.Item1 && optionInfo.Item2 == tuple.Item2)
			{
				return;
			}
		}
		ExtendEventOptions.Add(optionInfo);
	}

	private void UpdateAvatarGrowableElementToAge(GameData.Domains.Character.Character character, short age, ref AvatarData avatarData)
	{
		var (canGrowBeard1, canGrowBeard2) = character.IsAbleToGrowBeards(age);
		avatarData.SetGrowableElementShowingAbility(1, canGrowBeard1);
		avatarData.SetGrowableElementShowingAbility(2, canGrowBeard2);
		avatarData.SetGrowableElementShowingAbility(3, character.IsAbleToGrowWrinkle1(age));
		avatarData.SetGrowableElementShowingAbility(4, character.IsAbleToGrowWrinkle2(age));
		avatarData.SetGrowableElementShowingAbility(5, character.IsAbleToGrowWrinkle3(age));
		avatarData.SetGrowableElementShowingState(1, character.IsAbleToGrowAvatarElement(1, age));
		avatarData.SetGrowableElementShowingState(2, character.IsAbleToGrowAvatarElement(2, age));
		avatarData.SetGrowableElementShowingState(3, character.IsAbleToGrowAvatarElement(3, age));
		avatarData.SetGrowableElementShowingState(4, character.IsAbleToGrowAvatarElement(4, age));
		avatarData.SetGrowableElementShowingState(5, character.IsAbleToGrowAvatarElement(5, age));
	}

	public bool TryExecuteScript(EventScriptRuntime scriptRuntime, bool obtainEnabled = true)
	{
		if (EventConfig.Script == null)
		{
			return false;
		}
		string nextEvent = scriptRuntime.ExecuteScript(EventConfig.Script, ArgBox, obtainEnabled);
		if (nextEvent != null)
		{
			DomainManager.TaiwuEvent.ToEvent(nextEvent);
			return true;
		}
		return false;
	}

	public TaiwuEventDisplayData ToDisplayData()
	{
		EventConfig.TaiwuEvent = this;
		NeedNameRelatedDataCharacterIdList.Clear();
		TaiwuEventDisplayData data = new TaiwuEventDisplayData();
		data.EventGuid = EventGuid;
		data.EventTexture = EventConfig.EventBackground;
		data.MaskControlCode = EventConfig.MaskControl;
		data.MaskTweenTime = (ushort)(EventConfig.MaskTweenTime * 100f);
		bool notShowTargetRole = CheckEventBoolState("NotShowTargetRole", 4);
		bool notShowMainRole = CheckEventBoolState("NotShowMainRole", 3);
		string leftActorKey = string.Empty;
		if (ArgBox.Get("ConchShip_PresetKey_LeftActorKey", ref leftActorKey))
		{
			ArgBox.Remove<string>("ConchShip_PresetKey_LeftActorKey");
		}
		else if (!string.IsNullOrEmpty(EventConfig.MainRoleKey) && !notShowMainRole)
		{
			if (!ArgBox.Contains<EventActorData>(EventConfig.MainRoleKey))
			{
				GameData.Domains.Character.Character character = ArgBox.GetCharacter(EventConfig.MainRoleKey);
				data.MainCharacter = DomainManager.Character.GetCharacterDisplayData(character.GetId());
				short age = data.MainCharacter.PhysiologicalAge;
				if (ArgBox.Get("MainCharacterDisplayAge", ref age))
				{
					UpdateAvatarGrowableElementToAge(character, age, ref data.MainCharacter.AvatarRelatedData.AvatarData);
					data.MainCharacter.AvatarRelatedData.DisplayAge = age;
				}
				short clothTemplateId = -1;
				if (ArgBox.Get("MainCharacterDisplayCloth", ref clothTemplateId))
				{
					ClothingItem config = Clothing.Instance.GetItem(clothTemplateId);
					if (config != null)
					{
						data.MainCharacter.AvatarRelatedData.ClothingDisplayId = config.DisplayId;
					}
				}
			}
			else
			{
				leftActorKey = EventConfig.MainRoleKey;
			}
		}
		string actorKey = string.Empty;
		if (ArgBox.Get("ActorKey", ref actorKey))
		{
			ArgBox.Remove<string>("ActorKey");
		}
		else if (!string.IsNullOrEmpty(EventConfig.TargetRoleKey) && !notShowTargetRole)
		{
			if (!ArgBox.Contains<EventActorData>(EventConfig.TargetRoleKey))
			{
				GameData.Domains.Character.Character character2 = ArgBox.GetCharacter(EventConfig.TargetRoleKey);
				if (character2 == null)
				{
					throw new Exception(EventGuid + ":no character key " + EventConfig.TargetRoleKey + " in ArgBox!");
				}
				data.TargetCharacter = DomainManager.Character.GetCharacterDisplayData(character2.GetId());
				short age2 = data.TargetCharacter.PhysiologicalAge;
				if (ArgBox.Get("TargetCharacterDisplayAge", ref age2))
				{
					UpdateAvatarGrowableElementToAge(character2, age2, ref data.TargetCharacter.AvatarRelatedData.AvatarData);
					data.TargetCharacter.AvatarRelatedData.DisplayAge = age2;
				}
				short clothTemplateId2 = -1;
				if (ArgBox.Get("TargetCharacterDisplayCloth", ref clothTemplateId2))
				{
					ClothingItem config2 = Clothing.Instance.GetItem(clothTemplateId2);
					if (config2 != null)
					{
						data.TargetCharacter.AvatarRelatedData.ClothingDisplayId = config2.DisplayId;
					}
				}
				short clothingDisplayId = -1;
				if (ArgBox.Get("TargetCharacterDisplayingClothId", ref clothingDisplayId))
				{
					data.TargetCharacter.AvatarRelatedData.ClothingDisplayId = clothingDisplayId;
				}
			}
			else
			{
				actorKey = EventConfig.TargetRoleKey;
			}
		}
		if (string.IsNullOrEmpty(EventConfig.EventBackground))
		{
			string specifyEventBackground = string.Empty;
			if (!string.IsNullOrEmpty(DomainManager.TaiwuEvent.SeriesEventTexture))
			{
				data.EventTexture = DomainManager.TaiwuEvent.SeriesEventTexture;
			}
			else if (ArgBox.Get("ConchShip_PresetKey_SpecifyEventBackground", ref specifyEventBackground) && !string.IsNullOrEmpty(specifyEventBackground))
			{
				data.EventTexture = specifyEventBackground;
				ArgBox.Remove<string>("ConchShip_PresetKey_SpecifyEventBackground");
			}
			else
			{
				MapBlockData block;
				if (DomainManager.Map.IsTraveling)
				{
					Location location = DomainManager.Map.GetTravelCurrLocation();
					block = DomainManager.Map.GetBlock(location);
				}
				else if (DomainManager.Adventure.GetAdventureTaiwu().InAdventure)
				{
					Location location2 = DomainManager.Adventure.GetAdventureTaiwu().Adventure.MapLocation;
					block = DomainManager.Map.GetBlock(location2);
				}
				else
				{
					block = DomainManager.Map.GetBlock(EventArgBox.TaiwuAreaId, EventArgBox.TaiwuBlockId);
				}
				data.EventTexture = block.GetConfig().EventBack;
			}
		}
		else if (EventConfig.EventType == EEventType.ModEvent)
		{
			string modDirRoot = DomainManager.Mod.GetModDirectory(EventConfig.Package.ModIdString);
			if (string.IsNullOrEmpty(modDirRoot))
			{
				data.EventTexture = Path.Combine(EventConfig.Package.ModIdString, "../EventTextures/" + EventConfig.EventBackground + ".png").Replace("\\", "/");
			}
			else
			{
				data.EventTexture = Path.Combine(modDirRoot, "Events/EventTextures/" + EventConfig.EventBackground + ".png").Replace("\\", "/");
			}
		}
		try
		{
			data.EventContent = EventConfig.GetReplacedContentString();
		}
		catch (Exception ex)
		{
			data.EventContent = EventConfig.EventContent;
			AdaptableLog.Warning(ex.ToString(), appendWarningMessage: true);
		}
		if (string.IsNullOrEmpty(data.EventContent))
		{
			data.EventContent = TaiwuEventTagHandler.DecodeTag(EventConfig.EventContent, ArgBox, this);
		}
		data.ExtraFormatLanguageKeys = EventConfig.GetExtraFormatLanguageKeys();
		data.EscOptionIndex = -1;
		data.EventOptionInfos = new List<EventOptionInfo>();
		for (int i = 0; i < EventConfig.EventOptions.Length; i++)
		{
			HandleOption(EventConfig.EventOptions[i], this);
		}
		for (int j = 0; j < ExtendEventOptions.Count; j++)
		{
			(string, string) tuple = ExtendEventOptions[j];
			TaiwuEvent eventData = DomainManager.TaiwuEvent.GetEvent(tuple.Item1);
			if (eventData != null)
			{
				eventData.ArgBox = ArgBox;
				TaiwuEventOption option = eventData.EventConfig[tuple.Item2];
				HandleOption(option, eventData);
			}
		}
		if (data.EventOptionInfos.Count <= 0)
		{
			throw new Exception("event " + data.EventGuid + " failed to display cause no option!");
		}
		if (data.EventOptionInfos.Count > 36)
		{
			throw new Exception("event " + data.EventGuid + " failed to display cause too many options in event!");
		}
		if (CheckEventBoolState("ShuffleOptions", 0))
		{
			CollectionUtils.Shuffle(DomainManager.TaiwuEvent.MainThreadDataContext.Random, data.EventOptionInfos);
		}
		if (!string.IsNullOrEmpty(EventConfig.EscOptionKey))
		{
			data.EscOptionIndex = -1;
			for (sbyte i2 = 0; i2 < data.EventOptionInfos.Count; i2++)
			{
				if (data.EventOptionInfos[i2].OptionKey == EventConfig.EscOptionKey)
				{
					EventOptionInfo escOption = data.EventOptionInfos[i2];
					data.EventOptionInfos.RemoveAt(i2);
					data.EventOptionInfos.Add(escOption);
					data.EscOptionIndex = (sbyte)(data.EventOptionInfos.Count - 1);
					break;
				}
			}
		}
		if (NeedNameRelatedDataCharacterIdList.Count > 0)
		{
			data.NameDecodeDataList = new List<TaiwuEventCharacterNameDecodeData>();
			List<NameRelatedData> list = DomainManager.Character.GetNameRelatedDataList(NeedNameRelatedDataCharacterIdList);
			int k = 0;
			for (int max = NeedNameRelatedDataCharacterIdList.Count; k < max; k++)
			{
				int charId = NeedNameRelatedDataCharacterIdList[k];
				data.NameDecodeDataList.Add(new TaiwuEventCharacterNameDecodeData
				{
					CharacterId = charId,
					NameRelatedData = list[k]
				});
			}
			NeedNameRelatedDataCharacterIdList.Clear();
		}
		else
		{
			data.NameDecodeDataList = null;
		}
		_needNameRelatedDataCharacterIdList = null;
		data.ExtraData = new TaiwuEventDisplayExtraData();
		bool commonInteract = false;
		if (ArgBox.Get("ConchShip_PresetKey_CommonInteract", ref commonInteract))
		{
			data.ExtraData.ShowBlockCharacterBack = commonInteract;
		}
		data.ExtraData.ShowCommonOptionIndex = -1;
		int showCommonOption = -1;
		if (ArgBox.Get("ShowCommonOption", ref showCommonOption))
		{
			ArgBox.Remove<int>("ShowCommonOption");
		}
		else
		{
			showCommonOption = -1;
		}
		bool banCommonOption = false;
		if (ArgBox.Get("BanCommonOption", ref banCommonOption) && banCommonOption)
		{
			showCommonOption = -1;
		}
		data.ExtraData.ShowCommonOptionIndex = (sbyte)showCommonOption;
		data.ExtraData.ShowInteractOption = false;
		if (showCommonOption >= 0)
		{
			data.ExtraData.ShowInteractOption = GetInteractOptionVisibleCount(ArgBox) > 0;
		}
		data.ExtraData.ForbidViewCharacter = CheckEventBoolState("ForbidViewCharacter", 6);
		data.ExtraData.ForbidViewSelf = CheckEventBoolState("ForbidViewSelf", 5);
		data.ExtraData.HideRightFavorability = CheckEventBoolState("HideFavorability", 8);
		data.ExtraData.HideLeftFavorability = CheckEventBoolState("ConchShip_PresetKey_HideLeftFavorability", 7);
		data.ExtraData.TargetRoleUseAlternativeName = CheckEventBoolState("TargetRoleUseAlternativeName", 2);
		data.ExtraData.MainRoleUseAlternativeName = CheckEventBoolState("MainRoleUseAlternativeName", 1);
		data.ExtraData.RightCharacterShadow = CheckEventBoolState("ConchShip_PresetKey_RightCharacterShadow", 13);
		data.ExtraData.RightForbiddenConsummateLevel = CheckEventBoolState("ConchShip_PresetKey_RightForbiddenConsummateLevel", 14);
		int caravanId = -1;
		if (ArgBox.Get(EventTriggerParameter.DefValue.CaravanId, ref caravanId))
		{
			data.ExtraData.CaravanData = DomainManager.Merchant.GetCaravanDisplayData(DomainManager.TaiwuEvent.MainThreadDataContext, caravanId);
		}
		else
		{
			data.ExtraData.CaravanData = null;
		}
		int jiaoId = -1;
		if (ArgBox.Get("JiaoId", ref jiaoId) && DomainManager.Extra.TryGetJiao(jiaoId, out var jiao))
		{
			data.ExtraData.JiaoDisplayData = DomainManager.Item.GetItemDisplayData(jiao.Key);
		}
		else
		{
			data.ExtraData.JiaoDisplayData = null;
		}
		data.ExtraData.HereticTemplateId = -1;
		short targetCharacterTemplateId = -1;
		if (ArgBox.Get("TargetCharacterTemplateId", ref targetCharacterTemplateId))
		{
			data.ExtraData.HereticTemplateId = targetCharacterTemplateId;
			data.ExtraData.ForbidViewCharacter = true;
			data.ExtraData.HideRightFavorability = true;
			ArgBox.Remove<short>("TargetCharacterTemplateId");
		}
		if (!string.IsNullOrEmpty(leftActorKey))
		{
			ArgBox.Get(leftActorKey, out data.ExtraData.LeftActorData);
			data.ExtraData.ForbidViewSelf = true;
			data.ExtraData.LeftActorShowMarriageLook1 = CheckEventBoolState(string.Empty, 17);
			data.ExtraData.LeftActorShowMarriageLook2 = CheckEventBoolState(string.Empty, 18);
		}
		if (!string.IsNullOrEmpty(actorKey))
		{
			ArgBox.Get(actorKey, out data.ExtraData.ActorData);
			data.ExtraData.ForbidViewCharacter = true;
			data.ExtraData.RightActorShowMarriageLook1 = CheckEventBoolState(string.Empty, 19);
			data.ExtraData.RightActorShowMarriageLook2 = CheckEventBoolState(string.Empty, 20);
		}
		if (ArgBox.Get("SelectItemInfo", out EventSelectItemData selectItemData))
		{
			data.ExtraData.SelectItemData = selectItemData;
		}
		else
		{
			data.ExtraData.SelectItemData = null;
		}
		bool showProfessionPreview = false;
		if (ArgBox.Get("ShowProfessionPreview", ref showProfessionPreview) && showProfessionPreview)
		{
			data.ExtraData.ShowProfessionReview = true;
			ArgBox.Set("ShowProfessionPreview", arg: false);
		}
		else
		{
			data.ExtraData.ShowProfessionReview = false;
		}
		if (ArgBox.Get("SelectReadingBookCount", out EventSelectReadingBookCountData selectReadingBookCountData))
		{
			data.ExtraData.SelectReadingBookCountData = selectReadingBookCountData;
		}
		else
		{
			data.ExtraData.SelectReadingBookCountData = null;
		}
		if (ArgBox.Get("SelectNeigongLoopingCount", out EventSelectNeigongLoopingCountData selectNeigongLoopingCount))
		{
			data.ExtraData.SelectNeigongLoopingCountData = selectNeigongLoopingCount;
		}
		else
		{
			data.ExtraData.SelectNeigongLoopingCountData = null;
		}
		if (ArgBox.Get("SelectFuyuFaithCount", out EventSelectFuyuFaithCountData selectFuyuFaithCountData))
		{
			data.ExtraData.SelectFuyuFaithCountData = selectFuyuFaithCountData;
		}
		else
		{
			data.ExtraData.SelectFuyuFaithCountData = null;
		}
		if (ArgBox.Get("SelectFameData", out EventSelectFameData selectFameData))
		{
			data.ExtraData.SelectFameData = selectFameData;
		}
		else
		{
			data.ExtraData.SelectFameData = null;
		}
		if (ArgBox.Get("SelectCharacterData", out EventSelectCharacterData selectCharacterData))
		{
			data.ExtraData.SelectCharacterData = selectCharacterData;
		}
		else
		{
			data.ExtraData.SelectCharacterData = null;
		}
		if (ArgBox.Get("InputRequestData", out EventInputRequestData inputRequestData))
		{
			data.ExtraData.InputRequestData = inputRequestData;
		}
		else
		{
			data.ExtraData.InputRequestData = null;
		}
		bool selectAvatarFlag = false;
		if (ArgBox.Get("SelectAvatarEvent", ref selectAvatarFlag) && selectAvatarFlag)
		{
			data.ExtraData.SelectOneAvatarRelatedDataList = new List<AvatarRelatedData>();
			if (-1 != data.EscOptionIndex)
			{
				List<EventOptionInfo> eventOptionInfos = data.EventOptionInfos;
				int escOptionIndex = data.EscOptionIndex;
				List<EventOptionInfo> eventOptionInfos2 = data.EventOptionInfos;
				int index = eventOptionInfos2.Count - 1;
				List<EventOptionInfo> eventOptionInfos3 = data.EventOptionInfos;
				EventOptionInfo value = eventOptionInfos3[eventOptionInfos3.Count - 1];
				EventOptionInfo value2 = data.EventOptionInfos[data.EscOptionIndex];
				eventOptionInfos[escOptionIndex] = value;
				eventOptionInfos2[index] = value2;
				data.EscOptionIndex = (sbyte)(data.EventOptionInfos.Count - 1);
			}
			for (int l = 0; l < data.EventOptionInfos.Count; l++)
			{
				ArgBox.Get(data.EventOptionInfos[l].OptionKey, out AvatarRelatedData avatarRelatedData);
				if (avatarRelatedData == null)
				{
					throw new Exception(EventGuid + "'s option " + data.EventOptionInfos[l].OptionKey + ", not set an avatarRelatedData!");
				}
				data.ExtraData.SelectOneAvatarRelatedDataList.Add(avatarRelatedData);
			}
			ArgBox.Remove<bool>("SelectAvatarEvent");
		}
		data.ExtraData.MainRoleShyFlag = CheckEventBoolState("ConchShip_PresetKey_MainRoleShowBlush", 9);
		data.ExtraData.TargetRoleShyFlag = CheckEventBoolState("ConchShip_PresetKey_TargetRoleShowBlush", 10);
		short mainRoleClothAdjustId = -1;
		ArgBox.Get("ConchShip_PresetKey_MainRoleAdjustClothId", ref mainRoleClothAdjustId);
		ArgBox.Remove<short>("ConchShip_PresetKey_MainRoleAdjustClothId");
		data.ExtraData.MainRoleAdjustClothDisplayId = mainRoleClothAdjustId;
		short targetRoleClothAdjustId = -1;
		ArgBox.Get("ConchShip_PresetKey_TargetRoleAdjustClothId", ref targetRoleClothAdjustId);
		ArgBox.Remove<short>("ConchShip_PresetKey_TargetRoleAdjustClothId");
		data.ExtraData.TargetRoleAdjustClothDisplayId = targetRoleClothAdjustId;
		data.ExtraData.LeftRoleShowInjuryInfo = CheckEventBoolState("ConchShip_PresetKey_LeftRoleShowInjuryInfo", 11);
		data.ExtraData.RightRoleShowInjuryInfo = CheckEventBoolState("ConchShip_PresetKey_RightRoleShowInjuryInfo", 12);
		data.ExtraData.LeftForbidShowFavorChangeEffect = CheckEventBoolState("CS_PK_LeftForbidShowFavorChangeEffect", 15);
		data.ExtraData.RightForbidShowFavorChangeEffect = CheckEventBoolState("CS_PK_RightForbidShowFavorChangeEffect", 16);
		return data;
		void HandleOption(TaiwuEventOption taiwuEventOption, TaiwuEvent taiwuEvent)
		{
			if (taiwuEventOption.IsVisible)
			{
				EventOptionInfo optionInfo = new EventOptionInfo
				{
					OptionKey = taiwuEventOption.OptionKey,
					OptionGuid = taiwuEventOption.OptionGuid,
					Behavior = taiwuEventOption.Behavior,
					OptionContent = taiwuEventOption.GetReplacedContent?.Invoke(),
					Important = taiwuEventOption.Important,
					ImportantOptionTipLanguageKey = taiwuEventOption.ImportantOptionTipLanguageKey,
					ImportantOptionTitleLanguageKey = taiwuEventOption.ImportantOptionTitleLanguageKey
				};
				if (string.IsNullOrEmpty(optionInfo.OptionContent))
				{
					optionInfo.OptionContent = TaiwuEventTagHandler.DecodeTag(taiwuEventOption.OptionContent, ArgBox, this);
				}
				optionInfo.ExtraFormatLanguageKeys = taiwuEventOption.GetExtraFormatLanguageKeys?.Invoke();
				List<TaiwuEventOptionConditionBase> optionAvailableConditions = taiwuEventOption.OptionAvailableConditions;
				if (optionAvailableConditions != null && optionAvailableConditions.Count > 0)
				{
					optionInfo.OptionAvailableConditions = new List<OptionAvailableInfo>();
					bool finalState = true;
					for (int m = 0; m < taiwuEventOption.OptionAvailableConditions.Count; m++)
					{
						OptionAvailableInfo info = default(OptionAvailableInfo);
						TaiwuEventOptionConditionBase condition = taiwuEventOption.OptionAvailableConditions[m];
						if (condition.OrConditionCore != null && condition.OrConditionCore.Count > 0)
						{
							info.Data = new OptionAvailableInfoMinimumElement[condition.OrConditionCore.Count];
							for (int n = 0; n < condition.OrConditionCore.Count; n++)
							{
								OptionAvailableInfoMinimumElement element = default(OptionAvailableInfoMinimumElement);
								OptionConditionModifier.ModifyCondition(ref element, condition.OrConditionCore[m], ArgBox);
								info.PassState = info.PassState || element.Pass;
								info.Hide = info.Hide || element.Hide;
								info.Data[m] = element;
							}
						}
						else
						{
							OptionAvailableInfoMinimumElement element2 = default(OptionAvailableInfoMinimumElement);
							OptionConditionModifier.ModifyCondition(ref element2, condition, ArgBox);
							info.PassState = info.PassState || element2.Pass;
							info.Hide = info.Hide || element2.Hide;
							info.Data = new OptionAvailableInfoMinimumElement[1] { element2 };
						}
						if (!info.Hide)
						{
							optionInfo.OptionAvailableConditions.Add(info);
						}
						finalState = finalState && info.PassState;
					}
					if (!finalState)
					{
						optionInfo.OptionState = -1;
					}
				}
				if (!taiwuEventOption.CheckAvailableConditionsFromCode())
				{
					optionInfo.OptionState = -1;
				}
				EventScriptRuntime runtime = DomainManager.TaiwuEvent.ScriptRuntime;
				runtime.StartRecordConditionHints();
				if (!taiwuEventOption.CheckAvailableConditionsFromScript())
				{
					optionInfo.OptionState = -1;
				}
				if (!taiwuEventOption.CheckAvailableConditionsFromRedirect())
				{
					optionInfo.OptionState = -1;
				}
				optionInfo.OptionAvailableConditionInfos = runtime.StopRecordConditionHints();
				if (optionInfo.OptionState != -1)
				{
					if (taiwuEventOption.DefaultState == 1 && taiwuEventOption.WasSelected)
					{
						optionInfo.OptionState = 2;
					}
					else
					{
						optionInfo.OptionState = taiwuEventOption.DefaultState;
					}
				}
				if (!ArgBox.Get(taiwuEventOption.OptionKey + "_Type", ref optionInfo.OptionType))
				{
					optionInfo.OptionType = -1;
				}
				if (taiwuEventOption.OptionConsumeInfos != null)
				{
					optionInfo.OptionConsumeInfos = new List<OptionConsumeInfo>();
					FillOptionConsumeInfo(taiwuEventOption, ref optionInfo);
				}
				data.EventOptionInfos.Add(optionInfo);
			}
			else if (taiwuEvent != this)
			{
				taiwuEvent.ArgBox = null;
			}
		}
	}

	public bool HaveAvailableOption()
	{
		TaiwuEventDisplayData data = new TaiwuEventDisplayData();
		data.EventOptionInfos = new List<EventOptionInfo>();
		for (int i = 0; i < EventConfig.EventOptions.Length; i++)
		{
			HandleOption(EventConfig.EventOptions[i], this);
		}
		for (int j = 0; j < ExtendEventOptions.Count; j++)
		{
			(string, string) tuple = ExtendEventOptions[j];
			TaiwuEvent eventData = DomainManager.TaiwuEvent.GetEvent(tuple.Item1);
			if (eventData != null)
			{
				eventData.ArgBox = ArgBox;
				TaiwuEventOption option = eventData.EventConfig[tuple.Item2];
				HandleOption(option, eventData);
			}
		}
		return data.EventOptionInfos.Count > 0;
		void HandleOption(TaiwuEventOption taiwuEventOption, TaiwuEvent taiwuEvent)
		{
			if (taiwuEventOption.IsVisible)
			{
				EventOptionInfo optionInfo = new EventOptionInfo
				{
					OptionKey = taiwuEventOption.OptionKey,
					OptionGuid = taiwuEventOption.OptionGuid,
					Behavior = taiwuEventOption.Behavior,
					OptionContent = taiwuEventOption.GetReplacedContent?.Invoke(),
					Important = taiwuEventOption.Important,
					ImportantOptionTipLanguageKey = taiwuEventOption.ImportantOptionTipLanguageKey,
					ImportantOptionTitleLanguageKey = taiwuEventOption.ImportantOptionTitleLanguageKey
				};
				if (string.IsNullOrEmpty(optionInfo.OptionContent))
				{
					optionInfo.OptionContent = TaiwuEventTagHandler.DecodeTag(taiwuEventOption.OptionContent, ArgBox, this);
				}
				optionInfo.ExtraFormatLanguageKeys = taiwuEventOption.GetExtraFormatLanguageKeys?.Invoke();
				List<TaiwuEventOptionConditionBase> optionAvailableConditions = taiwuEventOption.OptionAvailableConditions;
				if (optionAvailableConditions != null && optionAvailableConditions.Count > 0)
				{
					optionInfo.OptionAvailableConditions = new List<OptionAvailableInfo>();
					bool finalState = true;
					for (int k = 0; k < taiwuEventOption.OptionAvailableConditions.Count; k++)
					{
						OptionAvailableInfo info = default(OptionAvailableInfo);
						TaiwuEventOptionConditionBase condition = taiwuEventOption.OptionAvailableConditions[k];
						if (condition.OrConditionCore != null && condition.OrConditionCore.Count > 0)
						{
							info.Data = new OptionAvailableInfoMinimumElement[condition.OrConditionCore.Count];
							for (int l = 0; l < condition.OrConditionCore.Count; l++)
							{
								OptionAvailableInfoMinimumElement element = default(OptionAvailableInfoMinimumElement);
								OptionConditionModifier.ModifyCondition(ref element, condition.OrConditionCore[k], ArgBox);
								info.PassState = info.PassState || element.Pass;
								info.Hide = info.Hide || element.Hide;
								info.Data[k] = element;
							}
						}
						else
						{
							OptionAvailableInfoMinimumElement element2 = default(OptionAvailableInfoMinimumElement);
							OptionConditionModifier.ModifyCondition(ref element2, condition, ArgBox);
							info.PassState = info.PassState || element2.Pass;
							info.Hide = info.Hide || element2.Hide;
							info.Data = new OptionAvailableInfoMinimumElement[1] { element2 };
						}
						if (!info.Hide)
						{
							optionInfo.OptionAvailableConditions.Add(info);
						}
						finalState = finalState && info.PassState;
					}
					if (!finalState)
					{
						optionInfo.OptionState = -1;
					}
				}
				if (!taiwuEventOption.CheckAvailableConditionsFromCode())
				{
					optionInfo.OptionState = -1;
				}
				EventScriptRuntime runtime = DomainManager.TaiwuEvent.ScriptRuntime;
				runtime.StartRecordConditionHints();
				if (!taiwuEventOption.CheckAvailableConditionsFromScript())
				{
					optionInfo.OptionState = -1;
				}
				if (!taiwuEventOption.CheckAvailableConditionsFromRedirect())
				{
					optionInfo.OptionState = -1;
				}
				optionInfo.OptionAvailableConditionInfos = runtime.StopRecordConditionHints();
				if (optionInfo.OptionState != -1)
				{
					if (taiwuEventOption.DefaultState == 1 && taiwuEventOption.WasSelected)
					{
						optionInfo.OptionState = 2;
					}
					else
					{
						optionInfo.OptionState = taiwuEventOption.DefaultState;
					}
				}
				if (!ArgBox.Get(taiwuEventOption.OptionKey + "_Type", ref optionInfo.OptionType))
				{
					optionInfo.OptionType = -1;
				}
				if (taiwuEventOption.OptionConsumeInfos != null)
				{
					optionInfo.OptionConsumeInfos = new List<OptionConsumeInfo>();
					FillOptionConsumeInfo(taiwuEventOption, ref optionInfo);
				}
				data.EventOptionInfos.Add(optionInfo);
			}
			else if (taiwuEvent != this)
			{
				taiwuEvent.ArgBox = null;
			}
		}
	}

	private void FillOptionConsumeInfo(TaiwuEventOption option, ref EventOptionInfo optionInfo)
	{
		bool hasExpression = option.OptionConsumeAmountExpressions != null;
		for (int i = 0; i < option.OptionConsumeInfos.Count; i++)
		{
			if (!hasExpression || !option.OptionConsumeAmountExpressions.TryGetValue(i, out var expression))
			{
				expression = null;
			}
			OptionConsumeInfo consumeInfo = OptionConsumeHelper.ModifyOptionConsumeInfo(option.OptionConsumeInfos[i], ArgBox, expression);
			GameData.Domains.Character.Character taiwu = option.ArgBox.GetCharacter("RoleTaiwu");
			GameData.Domains.Character.Character target = null;
			if (!string.IsNullOrEmpty(EventConfig.TargetRoleKey))
			{
				target = option.ArgBox.GetCharacter(EventConfig.TargetRoleKey);
			}
			bool hasEnough = (consumeInfo.HasEnough = consumeInfo.HasConsumeResource(taiwu.GetId(), target?.GetId() ?? (-1)));
			consumeInfo.HoldCount = consumeInfo.GetHoldCount(taiwu.GetId(), target?.GetId() ?? (-1));
			optionInfo.OptionConsumeInfos.Add(consumeInfo);
			if (!hasEnough)
			{
				optionInfo.OptionState = -1;
			}
		}
		if (option.HasRedirect)
		{
			TaiwuEventOption redirectOption = option.GetRedirectOption();
			FillOptionConsumeInfo(redirectOption, ref optionInfo);
		}
	}

	private bool CheckEventBoolState(string key, short templateId)
	{
		bool value = false;
		ArgBox.Get(key, ref value);
		TaiwuEventItem eventConfig = EventConfig;
		if (eventConfig.BoolStateDict == null)
		{
			eventConfig.BoolStateDict = new Dictionary<short, EventBoolStateInfo>();
		}
		EventConfig.BoolStateDict.TryGetValue(templateId, out var eventBoolStateInfo);
		if (eventBoolStateInfo == null)
		{
			EventBoolStateItem config = EventBoolState.Instance[templateId];
			if (config.RemoveBeforeNextEvent)
			{
				ArgBox.Remove<bool>(key);
			}
		}
		else if (eventBoolStateInfo.RemoveBeforeNextEvent)
		{
			ArgBox.Remove<bool>(key);
		}
		return value || (eventBoolStateInfo?.BoolState ?? false);
	}

	public int GetInteractOptionVisibleCount(EventArgBox argBox)
	{
		string guid = "fb38f657-6ed0-41e4-a0c2-c82afb49762f";
		TaiwuEvent taiwuEvent = DomainManager.TaiwuEvent.GetEvent(guid);
		taiwuEvent.ArgBox = argBox;
		TaiwuEventOption[] options = taiwuEvent.EventConfig.EventOptions;
		int visibleCount = 0;
		for (int i = 0; i < options.Length; i++)
		{
			if (options[i].IsVisible)
			{
				visibleCount++;
			}
		}
		for (int j = 0; j < taiwuEvent.ExtendEventOptions.Count; j++)
		{
			(string, string) tuple = taiwuEvent.ExtendEventOptions[j];
			TaiwuEvent extendEvent = DomainManager.TaiwuEvent.GetEvent(tuple.Item1);
			extendEvent.ArgBox = argBox;
			TaiwuEventOption option = extendEvent.EventConfig[tuple.Item2];
			if (option.IsVisible)
			{
				visibleCount++;
			}
		}
		return visibleCount;
	}

	public TaiwuEventSummaryDisplayData ToSummaryDisplayData()
	{
		TaiwuEventSummaryDisplayData data = new TaiwuEventSummaryDisplayData();
		data.EventGuid = EventGuid;
		if (string.IsNullOrEmpty(EventConfig.TargetRoleKey))
		{
			throw new Exception("can not to summary display data because EventConfig.TargetRoleKey has not been set!");
		}
		GameData.Domains.Character.Character character = ArgBox.GetCharacter(EventConfig.TargetRoleKey);
		if (character == null)
		{
			return null;
		}
		data.CharacterId = character.GetId();
		return data;
	}

	public void SetModInt(string dataName, bool isArchive, int val)
	{
		if (CheckModDataValid())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Mod.SetInt(context, EventConfig.Package.ModIdString, dataName, isArchive, val);
		}
	}

	public void SetModBool(string dataName, bool isArchive, bool val)
	{
		if (CheckModDataValid())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Mod.SetBool(context, EventConfig.Package.ModIdString, dataName, isArchive, val);
		}
	}

	public void SetModFloat(string dataName, bool isArchive, float val)
	{
		if (CheckModDataValid())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Mod.SetFloat(context, EventConfig.Package.ModIdString, dataName, isArchive, val);
		}
	}

	public void SetModString(string dataName, bool isArchive, string val)
	{
		if (CheckModDataValid())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Mod.SetString(context, EventConfig.Package.ModIdString, dataName, isArchive, val);
		}
	}

	public void SetSerializableModData(string dataName, bool isArchive, SerializableModData val)
	{
		if (CheckModDataValid())
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			DomainManager.Mod.SetSerializableModData(context, EventConfig.Package.ModIdString, dataName, isArchive, val);
		}
	}

	public void RemoveModData(string dataName)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		DomainManager.Mod.RemoveData(context, EventConfig.Package.ModIdString, dataName);
	}

	public bool RemoveModInt(string dataName, bool isArchive)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		return DomainManager.Mod.RemoveInt(context, EventConfig.Package.ModIdString, dataName, isArchive);
	}

	public bool RemoveModBool(string dataName, bool isArchive)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		return DomainManager.Mod.RemoveBool(context, EventConfig.Package.ModIdString, dataName, isArchive);
	}

	public bool RemoveModFloat(string dataName, bool isArchive)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		return DomainManager.Mod.RemoveFloat(context, EventConfig.Package.ModIdString, dataName, isArchive);
	}

	public bool RemoveModString(string dataName, bool isArchive)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		return DomainManager.Mod.RemoveString(context, EventConfig.Package.ModIdString, dataName, isArchive);
	}

	public bool RemoveSerializableModData(string dataName, bool isArchive)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		return DomainManager.Mod.RemoveSerializableModData(context, EventConfig.Package.ModIdString, dataName, isArchive);
	}

	public bool GetModData(string dataName, bool isArchive, ref int val)
	{
		if (!CheckModDataValid())
		{
			return false;
		}
		return DomainManager.Mod.TryGet(EventConfig.Package.ModIdString, dataName, isArchive, out val);
	}

	public bool GetModData(string dataName, bool isArchive, ref bool val)
	{
		if (!CheckModDataValid())
		{
			return false;
		}
		return DomainManager.Mod.TryGet(EventConfig.Package.ModIdString, dataName, isArchive, out val);
	}

	public bool GetModData(string dataName, bool isArchive, ref float val)
	{
		if (!CheckModDataValid())
		{
			return false;
		}
		return DomainManager.Mod.TryGet(EventConfig.Package.ModIdString, dataName, isArchive, out val);
	}

	public bool GetModData(string dataName, bool isArchive, ref string val)
	{
		if (!CheckModDataValid())
		{
			return false;
		}
		return DomainManager.Mod.TryGet(EventConfig.Package.ModIdString, dataName, isArchive, out val);
	}

	public bool GetModData(string dataName, bool isArchive, ref SerializableModData val)
	{
		if (!CheckModDataValid())
		{
			return false;
		}
		return DomainManager.Mod.TryGet(EventConfig.Package.ModIdString, dataName, isArchive, out val);
	}

	public bool CheckModDataValid(bool appendWarning = true)
	{
		if (string.IsNullOrEmpty(DomainManager.Mod.GetModDirectory(EventConfig.Package.ModIdString)))
		{
			AdaptableLog.TagWarning("TaiwuEvent", $"Unable to find mod {EventConfig.Package.ModIdString} with package group {EventConfig.Package.Group}.", appendWarning);
			return false;
		}
		return true;
	}

	private void InitializeValueSelector()
	{
		if (_name2IdMap != null)
		{
			return;
		}
		_name2IdMap = new Dictionary<string, int>();
		foreach (EventValueItem valueCfg in (IEnumerable<EventValueItem>)EventValue.Instance)
		{
			if (valueCfg.Type == EEventValueType.Event && !string.IsNullOrEmpty(valueCfg.Alias))
			{
				_name2IdMap.Add(valueCfg.Alias, valueCfg.TemplateId);
			}
		}
	}

	public ValueInfo SelectValue(Evaluator evaluator, string identifier)
	{
		InitializeValueSelector();
		int id;
		return _name2IdMap.TryGetValue(identifier, out id) ? SelectValue(evaluator, id) : ValueInfo.Void;
	}

	private ValueInfo SelectValue(Evaluator evaluator, int templateId)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.ScriptRuntime.ArgBox;
		switch (templateId)
		{
		case 39:
		{
			int charId2 = -1;
			return argBox.Get(EventConfig.MainRoleKey, ref charId2) ? evaluator.PushEvaluationResult(charId2) : evaluator.PushEvaluationResult(-1);
		}
		case 40:
		{
			int charId = -1;
			return argBox.Get(EventConfig.TargetRoleKey, ref charId) ? evaluator.PushEvaluationResult(charId) : evaluator.PushEvaluationResult(-1);
		}
		case 51:
		{
			GameData.Domains.Character.Character character = argBox.GetCharacter(EventTriggerParameter.DefValue.CharacterId.ArgBoxKey);
			if (character == null)
			{
				return evaluator.PushEvaluationResult(0);
			}
			sbyte grade = character.GetInteractionGrade();
			return evaluator.PushEvaluationResult(grade);
		}
		default:
			throw new ArgumentOutOfRangeException("templateId");
		}
	}
}

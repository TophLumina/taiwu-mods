using System;
using System.Collections.Generic;
using System.Text;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent;

[SerializableGameData(NotForDisplayModule = true, NotRestrictCollectionSerializedSize = true)]
public class EventArgBox : ISerializableGameData, IVariantCollection<string>, IValueSelector
{
	public const string ShuffleOption = "ShuffleOptions";

	public const string MainRoleUseAlternativeName = "MainRoleUseAlternativeName";

	public const string TargetRoleUseAlternativeName = "TargetRoleUseAlternativeName";

	public const string NotShowTargetRole = "NotShowTargetRole";

	public const string NotShowMainRole = "NotShowMainRole";

	public const string ForbidViewCharacter = "ForbidViewCharacter";

	public const string ForbidViewSelf = "ForbidViewSelf";

	public const string HideFavorability = "HideFavorability";

	public const string HideLeftFavorability = "ConchShip_PresetKey_HideLeftFavorability";

	public const string MainRoleShowBlush = "ConchShip_PresetKey_MainRoleShowBlush";

	public const string TargetRoleShowBlush = "ConchShip_PresetKey_TargetRoleShowBlush";

	[Obsolete]
	public const string LeftRoleShowInjuryInfo = "ConchShip_PresetKey_LeftRoleShowInjuryInfo";

	[Obsolete]
	public const string RightRoleShowInjuryInfo = "ConchShip_PresetKey_RightRoleShowInjuryInfo";

	public const string RightCharacterShadow = "ConchShip_PresetKey_RightCharacterShadow";

	public const string RightForbiddenConsummateLevel = "ConchShip_PresetKey_RightForbiddenConsummateLevel";

	public const string LeftForbidShowFavorChangeEffect = "CS_PK_LeftForbidShowFavorChangeEffect";

	public const string RightForbidShowFavorChangeEffect = "CS_PK_RightForbidShowFavorChangeEffect";

	public const string OrgTemplateId = "OrgTemplateId";

	public const string RoleTaiwu = "RoleTaiwu";

	public const string NpcCombatResultType = "NpcCombatResultType";

	[Obsolete]
	public const string ShowLeftFavorability = "ConchShip_PresetKey_ShowLeftFavorability";

	public const string SelectItemInfo = "SelectItemInfo";

	public const string ShowProfessionPreview = "ShowProfessionPreview";

	public const string SelectReadingBookCount = "SelectReadingBookCount";

	public const string SelectNeigongLoopingCount = "SelectNeigongLoopingCount";

	public const string SelectFuyuFaithCount = "SelectFuyuFaithCount";

	public const string SelectFameData = "SelectFameData";

	public const string SelectCountResult = "SelectCountResult";

	public const string SelectCharacterData = "SelectCharacterData";

	public const string InputRequestData = "InputRequestData";

	public const string ActorKey = "ActorKey";

	public const string LeftActorKey = "ConchShip_PresetKey_LeftActorKey";

	public const string TargetCharacterTemplateId = "TargetCharacterTemplateId";

	public const string CommonInteract = "ConchShip_PresetKey_CommonInteract";

	public const string SelectAvatarEvent = "SelectAvatarEvent";

	public const string MainCharacterDisplayAge = "MainCharacterDisplayAge";

	public const string MainCharacterDisplayCloth = "MainCharacterDisplayCloth";

	public const string TargetCharacterDisplayAge = "TargetCharacterDisplayAge";

	public const string TargetCharacterDisplayCloth = "TargetCharacterDisplayCloth";

	public const string TargetCharacterDisplayingClothId = "TargetCharacterDisplayingClothId";

	public const string ShowCommonOption = "ShowCommonOption";

	public const string BanCommonOption = "BanCommonOption";

	public const string EventInstanceGuid = "EventInstanceGuid";

	public const string CharIdSeizedInCombat = "CharIdSeizedInCombat";

	public const string ItemKeySeizeCharacterInCombat = "ItemKeySeizeCharacterInCombat";

	public const string UseItemKeySeizeCharacterId = "UseItemKeySeizeCharacterId";

	public const string ItemKeySeizeCarrierInCombat = "ItemKeySeizeCarrierInCombat";

	public const string CarrierItemKeyGotInCombat = "CarrierItemKeyGotInCombat";

	public const string UsedFuyuSwordInCombat = "UsedFuyuSwordInCombat";

	public const string DefaultHandleFlag = "DefaultHandleFlag";

	public const string PresetKeyDateOfNextSwordTombActivate = "ConchShip_PresetKey_DateOfNextSwordTombActivate";

	public const string ShopBuyMoney = "ConchShip_PresetKey_ShopBuyMoney";

	public const string ShopSoldMoney = "ConchShip_PresetKey_ShopSoldMoney";

	public const string ShopHasAnyTrade = "ConchShip_PresetKey_ShopHasAnyTrade";

	public const string ProtectedByWeiQiCharacter = "ProtectedByWeiQiCharacter";

	public const string MainRoleAdjustClothId = "ConchShip_PresetKey_MainRoleAdjustClothId";

	public const string TargetRoleAdjustClothId = "ConchShip_PresetKey_TargetRoleAdjustClothId";

	public const string TradeItemPrice = "ConchShip_PresetKey_TradeItemPrice";

	public const string SetGivenNameMatchSensitive = "ConchShip_PresetKey_SetGivenNameMatchSensitive";

	public const string SetGivenNameMatchSystemRuleType = "ConchShip_PresetKey_SetGivenNameMatchSystemRuleType";

	public const string CaravanCount = "ConchShip_PresetKey_CaravanCount";

	public const string CaravanIndex = "ConchShip_PresetKey_CaravanIndex";

	public const string CaravanPresentCount = "ConchShip_PresetKey_CaravanPresentCount";

	public const string FinishSkillExecute = "ConchShip_PresetKey_FinishSkillExecute";

	public const string SpecifyEventBackground = "ConchShip_PresetKey_SpecifyEventBackground";

	public const string OptionWaitConfirmKey = "ConchShip_PresetKey_OptionWaitConfirm";

	public const string ConfirmWaitOptionSignal = "ConchShip_PresetKey_ConfirmWaitOptionSignal";

	public const string JiaoId = "JiaoId";

	public const string EventLogMainCharacter = "ConchShip_PresetKey_EventLogMainCharacter";

	public const string ShaveSuccess = "ShaveSuccess";

	public const string ShaveHairFailFlag = "ShaveHairFailFlag";

	public const string ShaveBeardFailFlag = "ShaveBeardFailFlag";

	public const string ShaveEyebrowFailFlag = "ShaveEyebrowFailFlag";

	public const string ShaveAttraction = "ShaveAttraction";

	public const string StillAtShaolin = "ConchShip_PresetKey_StillAtShaolin";

	public const string StillAtEmei = "ConchShip_PresetKey_StillAtEmei";

	public const string StillAtBaihua = "ConchShip_PresetKey_StillAtBaihua";

	public const string StillAtWudang = "ConchShip_PresetKey_StillAtWudang";

	public const string StillAtYuanshan = "ConchShip_PresetKey_StillAtYuanshan";

	public const string StillAtShixiang = "ConchShip_PresetKey_StillAtShixiang";

	public const string StillAtRanshan = "ConchShip_PresetKey_StillAtRanshan";

	public const string StillAtXuannv = "ConchShip_PresetKey_StillAtXuannv";

	public const string StillAtZhujian = "ConchShip_PresetKey_StillAtZhujian";

	public const string StillAtKongsang = "ConchShip_PresetKey_StillAtKongsang";

	public const string StillAtJingang = "ConchShip_PresetKey_StillAtJingang";

	public const string StillAtWuxian = "ConchShip_PresetKey_StillAtWuxian";

	public const string StillAtJieqing = "ConchShip_PresetKey_StillAtJieqing";

	public const string StillAtFulong = "ConchShip_PresetKey_StillAtFulong";

	public const string StillAtXuehou = "ConchShip_PresetKey_StillAtXuehou";

	public const string MonkeyRobRoad = "MonkeyRobRoad";

	public const string CatchCricketTimes = "CatchCricketTimes";

	public const string RoleWoodenMan = "RoleWoodenMan";

	public const string WaitFinalCatchResult = "WaitFinalCatchResult";

	public const string WaitForCriketSecond = "WaitForCriketSecond";

	public const string WaitForCriketFourth = "WaitForCriketFourth";

	public const string MeetMonkey = "MeetMonkey";

	public const string SmallVillage_GirlCharId = "GirlCharId";

	public const string SmallVillage_YouthCharId = "YouthCharId";

	public const string SmallVillage_BigWigCharId = "BigWigCharId";

	public const string SmallVillage_ChildCharId = "ChildCharId";

	public const string SmallVillage_ChuiXingId = "ChuiXingId";

	public const string SmallVillage_DaoshiAskForWildFood = "DaoshiAskForWildFood";

	public const string SmallVillage_BattleWithXiangshuMinion = "BattleWithXiangshuMinion";

	public const string SmallVillage_MeetInfectedVillagerOnMap = "ConchShip_PresetKey_SmallVillage_MeetInfectedVillagerOnMap";

	public const string VillageChange_SaveInfectedVillagerCount = "ConchShip_PresetKey_VillageChange_SaveInfectedVillagerCount";

	public const string SaveAnyVillager = "SaveAnyVillager";

	public const string RiverHaveBoat = "RiverHaveBoat";

	public const string VillageHaveChanged = "VillageHaveChanged";

	public const string ChatWithANiu = "ChatWithANiu";

	public const string ChatWithGuoYan = "ChatWithGuoYan";

	public const string ChatWithXiaomao = "ChatWithXiaomao";

	public const string ChatWithHuanyue = "ChatWithHuanyue";

	public const string TryStealBoat = "TryStealBoat";

	public const string VillageRecordCount = "VillageRecordCount";

	public const string AllVillagerDieMonth = "AllVillagerDieMonth";

	[Obsolete]
	public const string VillagePlayCombatInteract = "VillagePlayCombatInteract";

	public const string VillageCricketInteract = "VillageCricketInteract";

	public const string LoopDeliver = "LoopDeliver";

	public const string DeliverVegetable = "DeliverVegetable";

	public const string GirlLocation = "GirlLocation";

	public const string BigWigLocation = "BigWigLocation";

	public const string ChildLocation = "ChildLocation";

	public const string YouthLocation = "YouthLocation";

	public const string VillageLocation = "VillageLocation";

	public const string RecordResource = "RecordResource";

	public const string MeetSmallVilliage = "MeetSmallVilliage";

	public const string StonePotGot = "StonePotGot";

	public const string HaveReturnedVillage = "HaveReturnedVillage";

	public const string VillageChangedWithoutTaiwu = "VillageChangedWithoutTaiwu";

	public const string BrokenDate = "BrokenDate";

	public const string PostLocation = "PostLocation";

	public const string WangliuLocation = "WangliuLocation";

	public const string WangliuFirstMeet = "WangliuFirstMeet";

	public const string CarterActivated = "CarterActivated";

	public const string FuyuHiltGuiding = "ConchShip_PresetKey_FuyuHiltGuiding";

	public const string FuyuHiltCatchUpCount = "ConchShip_PresetKey_FuyuHiltCatchUpCount";

	public const string TaiwuCrossArchiveEventTriggered = "ConchShip_PresetKey_TaiwuCrossArchiveEventTriggered";

	public const string TaiwuCrossArchiveAvatarData = "ConchShip_PresetKey_TaiwuCrossArchiveAvatarData";

	public const string TaiwuCrossArchiveDisplayName = "ConchShip_PresetKey_TaiwuCrossArchiveDisplayName";

	public const string TaiwuCrossArchiveOptionSelected = "ConchShip_PresetKey_TaiwuCrossArchiveAvatarData";

	public const string TaiwuVillageStationOpenDate = "CS_PK_StationOpenDate";

	public const string CaravanVisitMonthEventTriggered = "CS_PK_CaravanVisit";

	public const string OldMonkId = "OldMonk";

	public const string MissNingId = "MissNing";

	public const string YirenId = "Yiren";

	public const string BloodCharacter = "BloodCharacter";

	public const string DefeatXiangshuMinion = "DefeatXiangshuMinion";

	public const string SaveVillager = "SaveVillager";

	public const string OutTaiwuVillage = "OutTaiwuVillage";

	public const string ReturnSmallVillageEvent = "ReturnSmallVillageEvent";

	public const string BorrowBoat = "BorrowBoat";

	public const string TaiwuAncestral = "TaiwuAncestral";

	public const string HelpAreaSect = "HelpAreaSect";

	public const string HelpEnemySect = "HelpEnemySect";

	public const string WaitingForPostStory = "WaitingForPostStory";

	public const string WaitForWesternMerchants = "WaitForWesternMerchants";

	public const string WaitForReincarnationOpen = "WaitForReincarnationOpen";

	[Obsolete]
	public const string TaiwuPostLocation = "TaiwuPostLocation";

	public const string OldMonkToSwordTombCount = "OldMonkToSwordTombCount";

	public const string OldMonkSwordTombTalk = "OldMonkSwordTombTalk";

	public const string WakeUpAfterUsingSwordFirst = "WakeUpAfterUsingSwordFirst";

	public const string WaitTaiwuShrineComplete = "WaitTaiwuShrineComplete";

	public const string WakeUpAfterImmortalXuDestory = "WakeUpAfterImmortalXuDestory";

	public const string WaitForTombImmortalFirst = "WaitForTombImmortalFirst";

	public const string WaitForTombImmortalSecond = "WaitForTombImmortalSecond";

	public const string WaitForTombImmortalThird = "WaitForTombImmortalThird";

	public const string WaitForXiangongBack = "WaitForXiangongBack";

	public const string WaitForSwordTombAppearance = "WaitForSwordTombAppearance";

	public const string FarewellXuXiangong = "FarewellXuXiangong";

	public const string WaitForPurpleBambooAppear = "WaitForPurpleBambooAppear";

	public const string WaitForRanchenVisit = "WaitForRanchenVisit";

	public const string WaitTaiwuVillageDestory = "WaitTaiwuVillageDestory";

	public const string TrySurroundTaiwuVillage = "TrySurroundTaiwuVillage";

	public const string WaitForXiangongTime = "WaitForXiangongTime";

	public const string ImmortalXuMoveForSpiriteLand = "ImmortalXuMoveForSpiriteLand";

	public const string ImmortalXuBattle = "ImmortalXuBattle";

	public const string MeetLongYufu = "CS_PK_MeetLongYufu";

	public const string WaitForFirstWulinConference = "WaitForFirstWulinConference";

	public const string SwordStoveTombName = "SwordStoveTombName";

	public const string SwordStoveTombId = "SwordStoveTombId";

	public const string HuanxinCombatDie = "HuanxinCombatDie";

	public const string FirstMeetJunior = "FirstMeetJunior";

	public const string WaitForWuXiaoSpirit = "WaitForWuXiaoSpirit";

	public const string WuXiaoSacrificeStory = "WuXiaoSacrificeStory";

	public const string WaitWuXiaoDream = "WaitWuXiaoDream";

	public const string BlackBambooTime = "BlackBambooTime";

	public const string WaitForBlackBambooBorn = "WaitForBlackBambooBorn";

	public const string RockBambooCreateMonth = "RockBambooCreateMonth";

	public const string TaiwuMeetXiangshu = "TaiwuMeetXiangshu";

	public const string WaitFightXiangshuBegin = "WaitFightXiangshuBegin";

	public const string SealEvilPoints = "SealEvilPoints";

	public const string PassOutByUsingSwordFirst = "PassOutByUsingSwordFirst";

	public const string CheckChicken = "CheckChickenCrossSave";

	public const string Chapter9XiangshuMinionAtLocation = "CSPreset_Chapter9XiangshuMinionAtLocation";

	public const string MarriedTaiwuId = "MarriedTaiwuId";

	public const string GivenCloth = "GivenCloth";

	public const string WaitBlackToReturnMainMenu = "WaitBlackToReturnMainMenu";

	[Obsolete]
	public const string WaitCollectWoodOuter3 = "WaitCollectWoodOuter3";

	[Obsolete]
	public const string WaitCreateBambooThorn = "WaitCreateBambooThorn";

	public const string WaitBambooComplete = "WaitBambooComplete";

	public const string AwayForeverTime = "AwayForeverTime";

	public const string ForeverLoverId = "ForeverLoverId";

	public const string StoryForeverLoverId = "StoryForeverLoverId";

	public const string YuFuTellRanchenziStory = "YuFuTellRanchenziStory";

	public const string IsQuickStartGame = "CS_PK_IsQuickStartGame";

	public const string IsGuardCombat = "IsGuardCombat";

	public const string GuardCombatLevel = "GuardCombatLevel";

	public const string FulongServantSetGender = "FulongServantSetGender";

	public const string FulongServantSetTransgender = "FulongServantSetTransgender";

	public const string FulongServantSetBehaviorType = "FulongServantSetBehaviorType";

	public const string FulongServantSetLifeSkillType = "FulongServantSetLifeSkillType";

	public const string FulongServantSetCombatSkillType = "FulongServantSetCombatSkillType";

	public const string FulongServantSetMainAttributeType = "FulongServantSetMainAttributeType";

	private Dictionary<string, int> _intBox;

	private Dictionary<string, string> _stringBox;

	private Dictionary<string, float> _floatBox;

	private Dictionary<string, bool> _boolBox;

	private Dictionary<string, ISerializableGameData> _serializableObjectBox;

	public static readonly Dictionary<Type, sbyte> SerializeObjectMap = new Dictionary<Type, sbyte>
	{
		{
			typeof(Location),
			0
		},
		{
			typeof(AdventureMapPoint),
			1
		},
		{
			typeof(ItemKey),
			2
		},
		{
			typeof(AdventureSiteData),
			3
		},
		{
			typeof(MapTemplateEnemyInfo),
			4
		},
		{
			typeof(AvatarRelatedData),
			5
		},
		{
			typeof(EventActorData),
			6
		},
		{
			typeof(GameData.Utilities.ShortList),
			7
		},
		{
			typeof(AvatarData),
			8
		},
		{
			typeof(IntList),
			9
		},
		{
			typeof(BuildingBlockKey),
			10
		}
	};

	private static int _instancesCount = 0;

	private static int _objectCollectionsCount = 0;

	public static int TaiwuCharacterId => DomainManager.Taiwu.GetTaiwuCharId();

	public static short TaiwuAreaId => DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId;

	public static short TaiwuBlockId => DomainManager.Taiwu.GetTaiwu().GetLocation().BlockId;

	public static short TaiwuVillageAreaId => DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId;

	public static short TaiwuVillageBlockId => DomainManager.Taiwu.GetTaiwuVillageLocation().BlockId;

	public static void ShowStatus()
	{
		int instancesCount = _instancesCount;
		int objectCollectionsCount = _objectCollectionsCount;
		if (instancesCount > 0 || objectCollectionsCount > 0)
		{
			AdaptableLog.Info($"EventArgBox newly created: {instancesCount} instances, {objectCollectionsCount} object collections.");
		}
		_instancesCount = 0;
		_objectCollectionsCount = 0;
	}

	public void Clear()
	{
		_intBox?.Clear();
		_stringBox?.Clear();
		_floatBox?.Clear();
		_boolBox?.Clear();
		_serializableObjectBox?.Clear();
		_intBox = null;
		_stringBox = null;
		_floatBox = null;
		_boolBox = null;
		_serializableObjectBox = null;
	}

	public void CloneTo(EventArgBox argBox)
	{
		if (_intBox != null)
		{
			foreach (KeyValuePair<string, int> pair in _intBox)
			{
				EventArgBox eventArgBox = argBox;
				(eventArgBox._intBox ?? (eventArgBox._intBox = new Dictionary<string, int>())).Add(pair.Key, pair.Value);
			}
		}
		if (_stringBox != null)
		{
			foreach (KeyValuePair<string, string> pair2 in _stringBox)
			{
				EventArgBox eventArgBox = argBox;
				(eventArgBox._stringBox ?? (eventArgBox._stringBox = new Dictionary<string, string>())).Add(pair2.Key, pair2.Value);
			}
		}
		if (_floatBox != null)
		{
			foreach (KeyValuePair<string, float> pair3 in _floatBox)
			{
				EventArgBox eventArgBox = argBox;
				(eventArgBox._floatBox ?? (eventArgBox._floatBox = new Dictionary<string, float>())).Add(pair3.Key, pair3.Value);
			}
		}
		if (_boolBox != null)
		{
			foreach (KeyValuePair<string, bool> pair4 in _boolBox)
			{
				EventArgBox eventArgBox = argBox;
				(eventArgBox._boolBox ?? (eventArgBox._boolBox = new Dictionary<string, bool>())).Add(pair4.Key, pair4.Value);
			}
		}
		if (_serializableObjectBox == null)
		{
			return;
		}
		foreach (KeyValuePair<string, ISerializableGameData> pair5 in _serializableObjectBox)
		{
			EventArgBox eventArgBox = argBox;
			(eventArgBox._serializableObjectBox ?? (eventArgBox._serializableObjectBox = new Dictionary<string, ISerializableGameData>())).Add(pair5.Key, GetCopyOfSerializableObject(pair5.Value));
		}
	}

	public void Set(string key, sbyte arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			if (_intBox.ContainsKey(key))
			{
				_intBox[key] = arg;
			}
			else
			{
				_intBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, byte arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			if (_intBox.ContainsKey(key))
			{
				_intBox[key] = arg;
			}
			else
			{
				_intBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, ushort arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			if (_intBox.ContainsKey(key))
			{
				_intBox[key] = arg;
			}
			else
			{
				_intBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, short arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			if (_intBox.ContainsKey(key))
			{
				_intBox[key] = arg;
			}
			else
			{
				_intBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, int arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			if (_intBox.ContainsKey(key))
			{
				_intBox[key] = arg;
			}
			else
			{
				_intBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, float arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_floatBox == null)
			{
				_floatBox = new Dictionary<string, float>();
			}
			if (_floatBox.ContainsKey(key))
			{
				_floatBox[key] = arg;
			}
			else
			{
				_floatBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, string arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_stringBox == null)
			{
				_stringBox = new Dictionary<string, string>();
			}
			if (_stringBox.ContainsKey(key))
			{
				_stringBox[key] = arg;
			}
			else
			{
				_stringBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, bool arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_boolBox == null)
			{
				_boolBox = new Dictionary<string, bool>();
			}
			if (_boolBox.ContainsKey(key))
			{
				_boolBox[key] = arg;
			}
			else
			{
				_boolBox.Add(key, arg);
			}
		}
	}

	public void Set(string key, ISerializableGameData arg)
	{
		if (!string.IsNullOrEmpty(key))
		{
			if (_serializableObjectBox == null)
			{
				_serializableObjectBox = new Dictionary<string, ISerializableGameData>();
				_objectCollectionsCount++;
			}
			if (arg == null)
			{
				_serializableObjectBox.Remove(key);
			}
			else if (_serializableObjectBox.ContainsKey(key))
			{
				_serializableObjectBox[key] = arg;
			}
			else
			{
				_serializableObjectBox.Add(key, arg);
			}
		}
	}

	public void Remove<T>(string key)
	{
		if (typeof(T) == typeof(int) || typeof(T) == typeof(short) || typeof(T) == typeof(ushort) || typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
		{
			_intBox?.Remove(key);
		}
		else if (typeof(T) == typeof(float))
		{
			_floatBox?.Remove(key);
		}
		else if (typeof(T) == typeof(bool))
		{
			_boolBox?.Remove(key);
		}
		else if (typeof(T) == typeof(string))
		{
			_stringBox?.Remove(key);
		}
		else
		{
			_serializableObjectBox?.Remove(key);
		}
		if (this == DomainManager.TaiwuEvent.GetGlobalEventArgumentBox())
		{
			DomainManager.TaiwuEvent.SaveGlobalEventArgumentBox();
		}
	}

	public void GenericSet<T>(string key, T value)
	{
		T val = value;
		T val2 = val;
		if (!(val2 is int intValue))
		{
			if (!(val2 is short shortValue))
			{
				if (!(val2 is ushort ushortValue))
				{
					if (!(val2 is byte byteValue))
					{
						if (!(val2 is sbyte sbyteValue))
						{
							if (!(val2 is float floatValue))
							{
								if (!(val2 is string stringValue))
								{
									if (!(val2 is bool boolValue))
									{
										if (!(val2 is ISerializableGameData iSerializableValue))
										{
											throw new Exception($"Value {value} of type {typeof(T)} cannot be saved in EventArgBox");
										}
										if (!SerializeObjectMap.ContainsKey(value.GetType()))
										{
											AdaptableLog.Warning($"{value.GetType()} is a type can only set to EventArgBox in runtime,but will not be saved when saving game!");
										}
										Set(key, iSerializableValue);
									}
									else
									{
										Set(key, boolValue);
									}
								}
								else
								{
									Set(key, stringValue);
								}
							}
							else
							{
								Set(key, floatValue);
							}
						}
						else
						{
							Set(key, sbyteValue);
						}
					}
					else
					{
						Set(key, byteValue);
					}
				}
				else
				{
					Set(key, ushortValue);
				}
			}
			else
			{
				Set(key, shortValue);
			}
		}
		else
		{
			Set(key, intValue);
		}
	}

	public void SetActorKey(string key)
	{
		Set("ActorKey", key);
	}

	public void SetLeftActorKey(string key)
	{
		Set("ConchShip_PresetKey_LeftActorKey", key);
	}

	public bool Contains<T>(string key)
	{
		if (typeof(T) == typeof(int) || typeof(T) == typeof(short) || typeof(T) == typeof(ushort) || typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
		{
			return _intBox != null && _intBox.ContainsKey(key);
		}
		if (typeof(T) == typeof(float))
		{
			return _floatBox != null && _floatBox.ContainsKey(key);
		}
		if (typeof(T) == typeof(bool))
		{
			return _boolBox != null && _boolBox.ContainsKey(key);
		}
		if (typeof(T) == typeof(string))
		{
			return _stringBox != null && _stringBox.ContainsKey(key);
		}
		return _serializableObjectBox != null && _serializableObjectBox.ContainsKey(key);
	}

	public bool ContainsKey(string key)
	{
		return (_intBox != null && _intBox.ContainsKey(key)) || (_floatBox != null && _floatBox.ContainsKey(key)) || (_boolBox != null && _boolBox.ContainsKey(key)) || (_stringBox != null && _stringBox.ContainsKey(key)) || (_serializableObjectBox != null && _serializableObjectBox.ContainsKey(key));
	}

	public void RemoveKey(string key)
	{
		_intBox?.Remove(key);
		_floatBox?.Remove(key);
		_boolBox?.Remove(key);
		_stringBox?.Remove(key);
		_serializableObjectBox?.Remove(key);
	}

	public bool Get(string key, ref sbyte arg)
	{
		if (_intBox == null)
		{
			return false;
		}
		if (_intBox.TryGetValue(key, out var result))
		{
			arg = (sbyte)result;
			return true;
		}
		return false;
	}

	public bool Get(string key, ref byte arg)
	{
		if (_intBox == null)
		{
			return false;
		}
		if (_intBox.TryGetValue(key, out var result))
		{
			arg = (byte)result;
			return true;
		}
		return false;
	}

	public bool Get(string key, ref ushort arg)
	{
		if (_intBox == null)
		{
			return false;
		}
		if (_intBox.TryGetValue(key, out var result))
		{
			arg = (ushort)result;
			return true;
		}
		return false;
	}

	public bool Get(string key, ref short arg)
	{
		if (_intBox == null)
		{
			return false;
		}
		if (_intBox.TryGetValue(key, out var result))
		{
			arg = (short)result;
			return true;
		}
		return false;
	}

	public bool Get(string key, ref int arg)
	{
		if (_intBox == null)
		{
			return false;
		}
		return _intBox.TryGetValue(key, out arg);
	}

	public bool Get(string key, ref float arg)
	{
		if (_floatBox == null)
		{
			return false;
		}
		return _floatBox.TryGetValue(key, out arg);
	}

	public bool Get(string key, ref string arg)
	{
		if (_stringBox == null)
		{
			return false;
		}
		return _stringBox.TryGetValue(key, out arg);
	}

	public bool Get(string key, ref bool arg)
	{
		if (_boolBox == null)
		{
			return false;
		}
		return _boolBox.TryGetValue(key, out arg);
	}

	public bool Get<T>(string key, out T arg) where T : ISerializableGameData
	{
		arg = default(T);
		if (_serializableObjectBox == null)
		{
			return false;
		}
		ISerializableGameData data;
		bool ret = _serializableObjectBox.TryGetValue(key, out data);
		if (ret && data != null)
		{
			arg = (T)data;
		}
		return arg != null && ret;
	}

	public sbyte GetSbyte(string key)
	{
		if (_intBox == null || !_intBox.ContainsKey(key))
		{
			return 0;
		}
		_intBox.TryGetValue(key, out var result);
		return (sbyte)result;
	}

	public byte GetByte(string key)
	{
		if (_intBox == null || !_intBox.ContainsKey(key))
		{
			return 0;
		}
		_intBox.TryGetValue(key, out var result);
		return (byte)result;
	}

	public short GetShort(string key)
	{
		if (_intBox == null || !_intBox.ContainsKey(key))
		{
			return 0;
		}
		_intBox.TryGetValue(key, out var result);
		return (short)result;
	}

	public ushort GetUshort(string key)
	{
		if (_intBox == null || !_intBox.ContainsKey(key))
		{
			return 0;
		}
		_intBox.TryGetValue(key, out var result);
		return (ushort)result;
	}

	public int GetInt(string key)
	{
		if (_intBox == null || !_intBox.ContainsKey(key))
		{
			return 0;
		}
		_intBox.TryGetValue(key, out var result);
		return result;
	}

	public float GetFloat(string key)
	{
		if (_floatBox == null || !_floatBox.ContainsKey(key))
		{
			return 0f;
		}
		_floatBox.TryGetValue(key, out var result);
		return result;
	}

	public string GetString(string key)
	{
		if (_stringBox == null || !_stringBox.ContainsKey(key))
		{
			return null;
		}
		_stringBox.TryGetValue(key, out var result);
		return result;
	}

	public bool GetBool(string key)
	{
		if (_boolBox == null || !_boolBox.ContainsKey(key))
		{
			return false;
		}
		_boolBox.TryGetValue(key, out var result);
		return result;
	}

	public T Get<T>(string key) where T : ISerializableGameData
	{
		if (_serializableObjectBox == null || !_serializableObjectBox.ContainsKey(key))
		{
			return default(T);
		}
		_serializableObjectBox.TryGetValue(key, out var result);
		return (T)result;
	}

	public GameData.Domains.Character.Character GetCharacter(string key)
	{
		if (key == "RoleTaiwu")
		{
			return DomainManager.Taiwu.GetTaiwu();
		}
		GameData.Domains.Character.Character character = null;
		if (_intBox != null && _intBox.TryGetValue(key, out var characterId))
		{
			if (!DomainManager.Character.TryGetElement_Objects(characterId, out character))
			{
				AdaptableLog.Warning($"failed to get character {key} from ArgBox!curId in box is {characterId}");
			}
		}
		else
		{
			AdaptableLog.Warning("Failed to get character " + key + " from ArgBox.");
		}
		return character;
	}

	public DeadCharacter GetDeadCharacter(string key)
	{
		if (key == "RoleTaiwu")
		{
			return null;
		}
		if (_intBox == null || !_intBox.TryGetValue(key, out var characterId))
		{
			return null;
		}
		return DomainManager.Character.TryGetDeadCharacter(characterId);
	}

	public GameData.Domains.Character.Character GetAdventureMajorCharacter(int group, int index)
	{
		if (_intBox.TryGetValue($"MajorCharacter_{group}_{index}", out var characterId))
		{
			return DomainManager.Character.GetElement_Objects(characterId);
		}
		return null;
	}

	public int GetAdventureMajorCharacterCount(int group)
	{
		if (_intBox.TryGetValue($"MajorCharacter_{group}_Count", out var count))
		{
			return count;
		}
		return -1;
	}

	public GameData.Domains.Character.Character GetAdventureParticipateCharacter(int group, int index)
	{
		if (_intBox.TryGetValue($"ParticipateCharacter_{group}_{index}", out var characterId))
		{
			return DomainManager.Character.GetElement_Objects(characterId);
		}
		return null;
	}

	public int GetAdventureParticipateCharacterCount(int group)
	{
		if (_intBox.TryGetValue($"ParticipateCharacter_{group}_Count", out var count))
		{
			return count;
		}
		return -1;
	}

	public ItemBase GetItem(string key)
	{
		if (_serializableObjectBox.TryGetValue(key, out var itemKey))
		{
			return DomainManager.Item.GetBaseItem((ItemKey)(object)itemKey);
		}
		return null;
	}

	public EventArgBox()
	{
		_instancesCount++;
	}

	public EventArgBox(EventArgBox other)
	{
		_instancesCount++;
		if (other._intBox != null)
		{
			_intBox = new Dictionary<string, int>();
			foreach (KeyValuePair<string, int> pair in other._intBox)
			{
				_intBox.Add(pair.Key, pair.Value);
			}
		}
		if (other._stringBox != null)
		{
			_stringBox = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> pair2 in other._stringBox)
			{
				_stringBox.Add(pair2.Key, pair2.Value);
			}
		}
		if (other._floatBox != null)
		{
			_floatBox = new Dictionary<string, float>();
			foreach (KeyValuePair<string, float> pair3 in other._floatBox)
			{
				_floatBox.Add(pair3.Key, pair3.Value);
			}
		}
		if (other._boolBox != null)
		{
			_boolBox = new Dictionary<string, bool>();
			foreach (KeyValuePair<string, bool> pair4 in other._boolBox)
			{
				_boolBox.Add(pair4.Key, pair4.Value);
			}
		}
		if (other._serializableObjectBox == null)
		{
			return;
		}
		_serializableObjectBox = new Dictionary<string, ISerializableGameData>();
		_objectCollectionsCount++;
		foreach (KeyValuePair<string, ISerializableGameData> pair5 in other._serializableObjectBox)
		{
			_serializableObjectBox.Add(pair5.Key, pair5.Value);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (_intBox != null)
		{
			foreach (KeyValuePair<string, int> item in _intBox)
			{
				totalSize += 2 + 2 * item.Key.Length + 4;
			}
		}
		if (_stringBox != null)
		{
			foreach (KeyValuePair<string, string> pair in _stringBox)
			{
				totalSize += 2 + 2 * pair.Key.Length + 2 + 2 * pair.Value.Length;
			}
		}
		if (_floatBox != null)
		{
			foreach (KeyValuePair<string, float> item2 in _floatBox)
			{
				totalSize += 2 + 2 * item2.Key.Length + 4;
			}
		}
		if (_boolBox != null)
		{
			foreach (KeyValuePair<string, bool> item3 in _boolBox)
			{
				totalSize += 2 + 2 * item3.Key.Length + 1;
			}
		}
		if (_serializableObjectBox != null)
		{
			foreach (KeyValuePair<string, ISerializableGameData> pair2 in _serializableObjectBox)
			{
				Type type = pair2.Value.GetType();
				if (SerializeObjectMap.ContainsKey(type))
				{
					totalSize += 3 + 2 * pair2.Key.Length + pair2.Value.GetSerializedSize();
				}
			}
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	private unsafe int WriteString(byte* pData, string target)
	{
		byte* pCurrData = pData;
		if (!string.IsNullOrEmpty(target))
		{
			int elementsCount = target.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = target)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pData = 0;
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	private unsafe string ReadString(ref byte* pData)
	{
		ushort elementsCount = *(ushort*)pData;
		pData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			string resultString = Encoding.Unicode.GetString(pData, fieldSize);
			pData += fieldSize;
			return resultString;
		}
		return string.Empty;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_intBox != null)
		{
			*(ushort*)pCurrData = (ushort)_intBox.Count;
			pCurrData += 2;
			foreach (KeyValuePair<string, int> pair in _intBox)
			{
				pCurrData += WriteString(pCurrData, pair.Key);
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_stringBox != null)
		{
			*(ushort*)pCurrData = (ushort)_stringBox.Count;
			pCurrData += 2;
			foreach (KeyValuePair<string, string> pair2 in _stringBox)
			{
				pCurrData += WriteString(pCurrData, pair2.Key);
				pCurrData += WriteString(pCurrData, pair2.Value);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_floatBox != null)
		{
			*(ushort*)pCurrData = (ushort)_floatBox.Count;
			pCurrData += 2;
			foreach (KeyValuePair<string, float> pair3 in _floatBox)
			{
				pCurrData += WriteString(pCurrData, pair3.Key);
				*(float*)pCurrData = pair3.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_boolBox != null)
		{
			*(ushort*)pCurrData = (ushort)_boolBox.Count;
			pCurrData += 2;
			foreach (KeyValuePair<string, bool> pair4 in _boolBox)
			{
				pCurrData += WriteString(pCurrData, pair4.Key);
				*pCurrData = (pair4.Value ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_serializableObjectBox != null)
		{
			byte* pSerializableBoxHead = pCurrData;
			ushort savedDataCount = 0;
			pCurrData += 2;
			foreach (KeyValuePair<string, ISerializableGameData> pair5 in _serializableObjectBox)
			{
				Type type = pair5.Value.GetType();
				if (SerializeObjectMap.ContainsKey(type))
				{
					pCurrData += WriteString(pCurrData, pair5.Key);
					*pCurrData = (byte)SerializeObjectMap[pair5.Value.GetType()];
					pCurrData++;
					pCurrData += pair5.Value.Serialize(pCurrData);
					savedDataCount++;
				}
			}
			*(ushort*)pSerializableBoxHead = savedDataCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	private void CreateSerializableObject(sbyte code, out ISerializableGameData obj)
	{
		switch (code)
		{
		case 0:
			obj = default(Location);
			break;
		case 1:
			obj = new AdventureMapPoint();
			break;
		case 2:
			obj = default(ItemKey);
			break;
		case 3:
			obj = new AdventureSiteData();
			break;
		case 4:
			obj = default(MapTemplateEnemyInfo);
			break;
		case 5:
			obj = new AvatarRelatedData();
			break;
		case 6:
			obj = new EventActorData();
			break;
		case 7:
			obj = GameData.Utilities.ShortList.Create();
			break;
		case 8:
			obj = new AvatarData();
			break;
		case 9:
			obj = default(IntList);
			break;
		case 10:
			obj = default(BuildingBlockKey);
			break;
		default:
			obj = null;
			break;
		}
	}

	private ISerializableGameData GetCopyOfSerializableObject(ISerializableGameData obj)
	{
		if (!(obj is Location location))
		{
			if (!(obj is AdventureMapPoint adventureMapPoint))
			{
				if (!(obj is ItemKey itemKey))
				{
					if (!(obj is AdventureSiteData adventureSiteData))
					{
						if (!(obj is MapTemplateEnemyInfo mapRandomEnemyInfo))
						{
							if (!(obj is AvatarRelatedData avatarRelatedData))
							{
								if (!(obj is EventActorData eventActorData))
								{
									if (!(obj is AvatarData avatarData))
									{
										if (!(obj is AdventureBlockIndexForSerialize) && !(obj is AdventureAction))
										{
											if (!(obj is BuildingBlockKey))
											{
												if (obj is TreasureFindResult)
												{
													return obj;
												}
												return null;
											}
											return obj;
										}
										return obj;
									}
									return new AvatarData(avatarData);
								}
								return new EventActorData(eventActorData);
							}
							return new AvatarRelatedData(avatarRelatedData);
						}
						return mapRandomEnemyInfo;
					}
					return new AdventureSiteData(adventureSiteData);
				}
				return itemKey;
			}
			AdventureMapPoint advMapPointTarget = new AdventureMapPoint();
			advMapPointTarget.Assign(adventureMapPoint);
			return advMapPointTarget;
		}
		return location;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_intBox == null)
			{
				_intBox = new Dictionary<string, int>();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				string key = ReadString(ref pCurrData);
				int value = *(int*)pCurrData;
				pCurrData += 4;
				_intBox.Add(key, value);
			}
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_stringBox == null)
			{
				_stringBox = new Dictionary<string, string>();
			}
			for (int j = 0; j < elementsCount; j++)
			{
				string key2 = ReadString(ref pCurrData);
				string value2 = ReadString(ref pCurrData);
				_stringBox.Add(key2, value2);
			}
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_floatBox == null)
			{
				_floatBox = new Dictionary<string, float>();
			}
			for (int k = 0; k < elementsCount; k++)
			{
				string key3 = ReadString(ref pCurrData);
				float value3 = *(float*)pCurrData;
				pCurrData += 4;
				_floatBox.Add(key3, value3);
			}
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_boolBox == null)
			{
				_boolBox = new Dictionary<string, bool>();
			}
			for (int l = 0; l < elementsCount; l++)
			{
				string key4 = ReadString(ref pCurrData);
				bool value4 = *pCurrData != 0;
				pCurrData++;
				_boolBox.Add(key4, value4);
			}
		}
		elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_serializableObjectBox == null)
			{
				_serializableObjectBox = new Dictionary<string, ISerializableGameData>();
			}
			for (int m = 0; m < elementsCount; m++)
			{
				string key5 = ReadString(ref pCurrData);
				sbyte typeCode = (sbyte)(*pCurrData);
				pCurrData++;
				CreateSerializableObject(typeCode, out var data);
				if (data != null)
				{
					pCurrData += data.Deserialize(pCurrData);
					_serializableObjectBox.Add(key5, data);
				}
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref sbyte arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref byte arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref ushort arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref short arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref int arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref float arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref string arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get(EventTriggerParameterItem triggerParam, ref bool arg)
	{
		return Get(triggerParam.ArgBoxKey, ref arg);
	}

	public bool Get<T>(EventTriggerParameterItem triggerParam, out T arg) where T : ISerializableGameData
	{
		return Get(triggerParam.ArgBoxKey, out arg);
	}

	public sbyte GetSbyte(EventTriggerParameterItem triggerParam)
	{
		return GetSbyte(triggerParam.ArgBoxKey);
	}

	public byte GetByte(EventTriggerParameterItem triggerParam)
	{
		return GetByte(triggerParam.ArgBoxKey);
	}

	public short GetShort(EventTriggerParameterItem triggerParam)
	{
		return GetShort(triggerParam.ArgBoxKey);
	}

	public ushort GetUshort(EventTriggerParameterItem triggerParam)
	{
		return GetUshort(triggerParam.ArgBoxKey);
	}

	public int GetInt(EventTriggerParameterItem triggerParam)
	{
		return GetInt(triggerParam.ArgBoxKey);
	}

	public float GetFloat(EventTriggerParameterItem triggerParam)
	{
		return GetFloat(triggerParam.ArgBoxKey);
	}

	public string GetString(EventTriggerParameterItem triggerParam)
	{
		return GetString(triggerParam.ArgBoxKey);
	}

	public bool GetBool(EventTriggerParameterItem triggerParam)
	{
		return GetBool(triggerParam.ArgBoxKey);
	}

	public T Get<T>(EventTriggerParameterItem triggerParam) where T : ISerializableGameData
	{
		return Get<T>(triggerParam.ArgBoxKey);
	}

	public bool Contains<T>(EventTriggerParameterItem triggerParam)
	{
		return Contains<T>(triggerParam.ArgBoxKey);
	}

	public void Set(EventTriggerParameterItem triggerParam, sbyte arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, byte arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, ushort arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, short arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, int arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, float arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, string arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, bool arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Set(EventTriggerParameterItem triggerParam, ISerializableGameData arg)
	{
		Set(triggerParam.ArgBoxKey, arg);
	}

	public void Remove<T>(EventTriggerParameterItem triggerParam)
	{
		Remove<T>(triggerParam.ArgBoxKey);
	}

	public void RemoveKey(EventTriggerParameterItem triggerParam)
	{
		RemoveKey(triggerParam.ArgBoxKey);
	}

	public GameData.Domains.Character.Character GetCharacter()
	{
		return GetCharacter(EventTriggerParameter.DefValue.CharacterId.ArgBoxKey);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref sbyte arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref byte arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref ushort arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref short arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref int arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref float arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref string arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get(SectMainStoryEventArgKeyItem argKey, ref bool arg)
	{
		return Get(argKey.ArgBoxKey, ref arg);
	}

	public bool Get<T>(SectMainStoryEventArgKeyItem argKey, out T arg) where T : ISerializableGameData
	{
		return Get(argKey.ArgBoxKey, out arg);
	}

	public sbyte GetSbyte(SectMainStoryEventArgKeyItem argKey)
	{
		return GetSbyte(argKey.ArgBoxKey);
	}

	public byte GetByte(SectMainStoryEventArgKeyItem argKey)
	{
		return GetByte(argKey.ArgBoxKey);
	}

	public short GetShort(SectMainStoryEventArgKeyItem argKey)
	{
		return GetShort(argKey.ArgBoxKey);
	}

	public ushort GetUshort(SectMainStoryEventArgKeyItem argKey)
	{
		return GetUshort(argKey.ArgBoxKey);
	}

	public int GetInt(SectMainStoryEventArgKeyItem argKey)
	{
		return GetInt(argKey.ArgBoxKey);
	}

	public float GetFloat(SectMainStoryEventArgKeyItem argKey)
	{
		return GetFloat(argKey.ArgBoxKey);
	}

	public string GetString(SectMainStoryEventArgKeyItem argKey)
	{
		return GetString(argKey.ArgBoxKey);
	}

	public bool GetBool(SectMainStoryEventArgKeyItem argKey)
	{
		return GetBool(argKey.ArgBoxKey);
	}

	public T Get<T>(SectMainStoryEventArgKeyItem argKey) where T : ISerializableGameData
	{
		return Get<T>(argKey.ArgBoxKey);
	}

	public bool Contains<T>(SectMainStoryEventArgKeyItem argKey)
	{
		return Contains<T>(argKey.ArgBoxKey);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, sbyte arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, byte arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, ushort arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, short arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, int arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, float arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, string arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, bool arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void Set(SectMainStoryEventArgKeyItem argKey, ISerializableGameData arg)
	{
		Set(argKey.ArgBoxKey, arg);
	}

	public void SetActorKey(SectMainStoryEventArgKeyItem argKey)
	{
		SetActorKey(argKey.ArgBoxKey);
	}

	public void Remove<T>(SectMainStoryEventArgKeyItem argKey)
	{
		Remove<T>(argKey.ArgBoxKey);
	}

	public void RemoveKey(SectMainStoryEventArgKeyItem argKey)
	{
		RemoveKey(argKey.ArgBoxKey);
	}

	public void SetValueFromStack(EvaluationStack evaluationStack, string identifier, EValueType valueType)
	{
		switch (valueType)
		{
		case EValueType.Int:
		{
			int value5 = evaluationStack.PopUnmanaged<int>();
			Set(identifier, value5);
			break;
		}
		case EValueType.Float:
		{
			float value4 = evaluationStack.PopUnmanaged<float>();
			Set(identifier, value4);
			break;
		}
		case EValueType.Bool:
		{
			bool value3 = evaluationStack.PopUnmanaged<bool>();
			Set(identifier, value3);
			break;
		}
		case EValueType.Str:
		{
			string value2 = evaluationStack.PopObject<string>();
			Set(identifier, value2);
			break;
		}
		case EValueType.Obj:
		{
			ISerializableGameData value = evaluationStack.PopObject<ISerializableGameData>();
			Set(identifier, value);
			break;
		}
		}
	}

	public ValueInfo SelectValue(Evaluator evaluator, string identifier)
	{
		int intVal = 0;
		if (Get(identifier, ref intVal))
		{
			return evaluator.PushEvaluationResult(intVal);
		}
		bool boolVal = false;
		if (Get(identifier, ref boolVal))
		{
			return evaluator.PushEvaluationResult(boolVal);
		}
		float floatVal = 0f;
		if (Get(identifier, ref floatVal))
		{
			return evaluator.PushEvaluationResult(floatVal);
		}
		string strVal = null;
		if (Get(identifier, ref strVal))
		{
			return evaluator.PushEvaluationResult(strVal);
		}
		if (Get(identifier, out ISerializableGameData objVal))
		{
			return evaluator.PushEvaluationResult(objVal);
		}
		return ValueInfo.Void;
	}
}

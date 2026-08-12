using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Config;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Alertness;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Filters;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Story.MainStory;
using GameData.Domains.Story.SectMainStory;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Domains.World.Display;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Domains.World.SectMainStory;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.Story;

[GameDataDomain(20)]
public class StoryDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<sbyte> _advanceXiangshuAvatarIds;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private IronPlateData _ironPlateData;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private DivineFlameData _divineFlameData;

	[DomainData(DomainDataType.ElementList, true, false, false, false, ArrayElementsCount = 12)]
	private TwelveImmortalsStatus[] _twelveImmortalsStatuses;

	private static readonly List<short> IronPlateCharInteractionTemplateIdList = new List<short>
	{
		562, 580, 585, 597, 925, 698, 699, 700, 810, 1034,
		833
	};

	private static readonly List<short> IronPlateCharCombatTemplateIdList = new List<short>
	{
		566, 584, 589, 597, 925, 698, 699, 700, 810, 1034,
		833
	};

	[Obsolete]
	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private int _noMindGuyUsed;

	[DomainData(DomainDataType.ElementList, true, false, true, true, ArrayElementsCount = 15)]
	private readonly sbyte[] _sectMainStoryTaskStatus;

	private readonly HashSet<sbyte> _storyStatus = new HashSet<sbyte>();

	private readonly HashSet<short> _sectMainStoryTriggerRecord = new HashSet<short>();

	public const string TriggeringStatus = "ConchShip_PresetKey_SectMainStoryTriggeringStatus";

	private bool _sectMainStoryLifeLinkUpdated;

	private readonly List<(GameData.Domains.Character.Character character, int health, int leftMaxHealth)> _tmpLifeGateChars = new List<(GameData.Domains.Character.Character, int, int)>();

	private readonly List<(GameData.Domains.Character.Character character, int distributableHealth)> _tmpDeathGateChars = new List<(GameData.Domains.Character.Character, int)>();

	private Dictionary<int, (int index, bool isLifeGate)> _baihuaLinkedCharacters;

	private sbyte _baihuaLifeLinkNeiliType;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, SectEmeiBreakBonusData> _sectEmeiBreakBonusData;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, SkillBreakBonusCollection> _sectEmeiSkillBreakBonus;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<short, GameData.Utilities.ShortList> _sectEmeiBreakBonusTemplateIds;

	[DomainData(DomainDataType.SingleValueCollection, true, false, true, true)]
	private readonly Dictionary<int, SectEmeiGuidanceData> _sectEmeiGuidance;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<SectEmeiGuidanceMapData> _sectEmeiGuidanceData;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private SectStoryShaolinWordlessCharacter _wordless;

	[DomainData(DomainDataType.SingleValue, true, false, true, false)]
	private int _sectMainStoryCombatTimesShaolin;

	private int _shixiangKilledLimitInMonth;

	private Dictionary<short, List<Func<bool>>> _sectMainStoryTriggerConditions = new Dictionary<short, List<Func<bool>>>
	{
		{
			1,
			new List<Func<bool>> { ShaolinMainStoryTrigger0, ShaolinMainStoryTrigger1 }
		},
		{
			2,
			new List<Func<bool>> { EMeiMainStoryTrigger0, EMeiMainStoryTrigger1 }
		},
		{
			3,
			new List<Func<bool>> { BaihuaMainStoryTrigger0, BaihuaMainStoryTrigger1 }
		},
		{
			4,
			new List<Func<bool>> { WudangMainStoryTrigger0, WudangMainStoryTrigger1 }
		},
		{
			5,
			new List<Func<bool>> { YuanshanMainStoryTrigger0, YuanshanMainStoryTrigger1, YuanshanMainStoryTrigger2 }
		},
		{
			6,
			new List<Func<bool>> { ShixiangMainStoryTrigger0, ShixiangMainStoryTrigger1 }
		},
		{
			7,
			new List<Func<bool>> { RanshanMainStoryTrigger0, RanshanMainStoryTrigger1, RanshanMainStoryTrigger2 }
		},
		{
			8,
			new List<Func<bool>> { XuannvMainStoryTrigger0, XuannvMainStoryTrigger1 }
		},
		{
			9,
			new List<Func<bool>> { ZhujianMainStoryTrigger0, ZhujianMainStoryTrigger1 }
		},
		{
			10,
			new List<Func<bool>> { KongsangMainStoryTrigger0, KongsangMainStoryTrigger1 }
		},
		{
			11,
			new List<Func<bool>> { JingangMainStoryTrigger0, JingangMainStoryTrigger1 }
		},
		{
			12,
			new List<Func<bool>> { WuxianMainStoryTrigger0, WuxianMainStoryTrigger1 }
		},
		{
			13,
			new List<Func<bool>> { JieqingMainStoryTrigger0, JieqingMainStoryTrigger1, JieqingMainStoryTrigger2 }
		},
		{
			14,
			new List<Func<bool>> { FulongMainStoryTrigger0, FulongMainStoryTrigger1 }
		},
		{
			15,
			new List<Func<bool>> { XuehouMainStoryTrigger0 }
		}
	};

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<int> _threeVitalsReplaceTeammateRecordNew;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[15][];

	private static readonly DataInfluence[][] CacheInfluencesSectMainStoryTaskStatus = new DataInfluence[15][];

	private readonly byte[] _dataStatesSectMainStoryTaskStatus = new byte[4];

	private SingleValueCollectionModificationCollection<short> _modificationsSectEmeiBreakBonusData = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsSectEmeiSkillBreakBonus = SingleValueCollectionModificationCollection<short>.Create();

	private SingleValueCollectionModificationCollection<short> _modificationsSectEmeiBreakBonusTemplateIds = SingleValueCollectionModificationCollection<short>.Create();

	private static readonly DataInfluence[][] CacheInfluencesTwelveImmortalsStatuses = new DataInfluence[12][];

	private readonly byte[] _dataStatesTwelveImmortalsStatuses = new byte[3];

	private SingleValueCollectionModificationCollection<int> _modificationsSectEmeiGuidance = SingleValueCollectionModificationCollection<int>.Create();

	private Queue<uint> _pendingLoadingOperationIds;

	[Obsolete]
	[DomainData(DomainDataType.SingleValue, true, false, true, true, ArrayElementsCount = 3)]
	private int[] _threeVitalsReplaceTeammateRecord;

	[DataUpgrader(Version = "1.0.32", Date = "2026/06/26")]
	private void FixAbnormalBaihuaLifeLinkFeatures(DataContext context)
	{
		if (_baihuaLinkedCharacters == null)
		{
			return;
		}
		HashSet<short> features = new HashSet<short>();
		foreach (NeiliTypeItem neiliTypeCfg in (IEnumerable<NeiliTypeItem>)NeiliType.Instance)
		{
			short[] deathGateFeatures = neiliTypeCfg.DeathGateFeatures;
			if (deathGateFeatures != null && deathGateFeatures.Length > 0)
			{
				features.UnionWith(neiliTypeCfg.DeathGateFeatures);
			}
			deathGateFeatures = neiliTypeCfg.LifeGateFeatures;
			if (deathGateFeatures != null && deathGateFeatures.Length > 0)
			{
				features.UnionWith(neiliTypeCfg.LifeGateFeatures);
			}
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (_baihuaLinkedCharacters.ContainsKey(taiwu.GetId()))
		{
			return;
		}
		List<short> taiwuFeatures = taiwu.GetFeatureIds();
		bool modified = false;
		for (int index = taiwuFeatures.Count - 1; index >= 0; index--)
		{
			short featureId = taiwuFeatures[index];
			if (features.Contains(featureId))
			{
				Logger.Warn($"Removing abnormal feature {CharacterFeature.Instance[featureId].Name} for {taiwu}.");
				taiwuFeatures.RemoveAt(index);
				modified = true;
			}
		}
		if (modified)
		{
			taiwu.SetFeatureIds(taiwuFeatures, context);
		}
	}

	[DataUpgrader(Version = "1.0.40", Date = "2026/06/28")]
	private void FixAbnormalPurpleBambooProgress(DataContext context)
	{
		if (DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(6).JuniorXiangshuTaskStatus > 2 && DomainManager.World.IsExtraTaskInProgress(616))
		{
			DomainManager.World.FinishTriggeredExtraTask(context, 20, 616);
			Logger.Warn("Fixing abnormal purple bamboo progress: Finishing PurpleBambooYixiangChp2.");
		}
	}

	[DataUpgrader(Date = "2026/06/26", Version = "1.0.36")]
	private void FixAbnormalSamsaraFunctionStatus(DataContext context)
	{
		if (DomainManager.Extra.GetIsDreamBack() && !DomainManager.World.GetWorldFunctionsStatus(12) && DomainManager.Taiwu.GetTaiwu().GetInventory().GetInventoryItemKey(12, 227)
			.IsValid())
		{
			DomainManager.World.SetWorldFunctionsStatus(context, 12);
			Logger.Warn("Fixing abnormal SamsaraPlatform function status.");
		}
	}

	[DataUpgrader(Date = "2026/07/08", Version = "1.0.55")]
	private void FixAbnormalWudangSnakeCharacter(DataContext context)
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(597, out var snakeHuman) && DomainManager.Character.TryGetFixedCharacterByTemplateId(596, out var snake) && snakeHuman.GetLocation().IsValid() && snake.GetLocation().IsValid())
		{
			Location location = snake.GetLocation();
			Events.RaiseFixedCharacterLocationChanged(context, snake.GetId(), location, Location.Invalid);
			snake.SetLocation(Location.Invalid, context);
			Logger.Warn($"Fixing abnormal wudang snake {snake} at {location}.");
		}
	}

	[DataUpgrader(Version = "1.0.9", Date = "2026/06/19")]
	private void FixAbnormalIronPlateData(DataContext context)
	{
		if (_ironPlateData.FollowingCharId >= 0 && DomainManager.Character.TryGetElement_Objects(_ironPlateData.FollowingCharId, out var curCharacter) && IronPlateCharInteractionTemplateIdList.IndexOf(curCharacter.GetTemplateId()) < 0)
		{
			RemoveIconPlateFollowingCharacter(context, _ironPlateData.FollowingCharId);
			int index = IronPlateCharInteractionTemplateIdList.FindIndex((short id) => Config.Character.Instance[id].GroupId == curCharacter.Template.GroupId);
			if (index >= 0)
			{
				short templateId = IronPlateCharInteractionTemplateIdList[index];
				int charId = GetOrCreateFixedCharacter(context, templateId);
				AddIconPlateFollowingCharacter(context, charId);
				_ironPlateData.SetFollowingCharId(charId);
				SetIronPlateData(_ironPlateData, context);
			}
		}
	}

	[DataUpgrader(Version = "1.0.17", Date = "2026/06/21")]
	private void FixAbnormalAllFixedCharacterLocation(DataContext context)
	{
		if (!DomainManager.Story.GetIronPlateData().IsUnlocked)
		{
			return;
		}
		for (int index = 0; index < _twelveImmortalsStatuses.Length; index++)
		{
			TwelveImmortalsStatus statuse = _twelveImmortalsStatuses[index];
			bool flag = statuse == null;
			bool flag2 = flag;
			if (!flag2)
			{
				sbyte assistState = statuse.AssistState;
				bool flag3 = (uint)(assistState - 4) <= 1u;
				flag2 = flag3;
			}
			if (flag2 || statuse.CharacterId < 0 || !DomainManager.Character.TryGetElement_Objects(statuse.CharacterId, out var character) || character.GetLocation() != Location.Invalid)
			{
				continue;
			}
			TwelveImmortalsItem config = TwelveImmortals.Instance[index];
			switch (character.GetTemplateId())
			{
			case 1080:
				foreach (GameData.Domains.Character.Character blockChar in config.GetImpactRangeCharacters())
				{
					if (blockChar.GetFeatureIds().Contains(861))
					{
						blockChar.RemoveFeature(context, 861);
					}
				}
				break;
			case 1081:
				foreach (short jiaoTemplateId in TwelveImmortalsConstants.JiaoCharacterToPoisonTypes.Keys)
				{
					if (DomainManager.Character.TryGetFixedCharacterByTemplateId(jiaoTemplateId, out var jiao))
					{
						DomainManager.Character.RemoveNonIntelligentCharacter(context, jiao);
					}
				}
				break;
			case 1082:
				foreach (short mirrorTemplateId in TwelveImmortalsConstants.MirrorCharacters)
				{
					if (DomainManager.Character.TryGetFixedCharacterByTemplateId(mirrorTemplateId, out var mirror))
					{
						DomainManager.Character.RemoveNonIntelligentCharacter(context, mirror);
					}
				}
				break;
			case 1083:
				foreach (MapBlockData block in config.GetImpactRangeBlocks())
				{
					HashSet<int> enemyCharacterSet = block.EnemyCharacterSet;
					if (enemyCharacterSet == null || enemyCharacterSet.Count <= 0)
					{
						continue;
					}
					List<GameData.Domains.Character.Character> enemyChars = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
					foreach (int enemyCharId in block.EnemyCharacterSet)
					{
						if (DomainManager.Character.TryGetElement_Objects(enemyCharId, out var enemyChar) && enemyChar.GetFeatureIds().Contains(880))
						{
							enemyChars.Add(enemyChar);
						}
					}
					foreach (GameData.Domains.Character.Character enemyChar2 in enemyChars)
					{
						DomainManager.Character.RemoveNonIntelligentCharacter(context, enemyChar2);
					}
					ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(enemyChars);
				}
				break;
			}
			sbyte stateTemplateId = config.MapState;
			MapStateItem stateCfg = MapState.Instance[stateTemplateId];
			sbyte areaId = (context.Random.NextBool() ? stateCfg.MainAreaID : stateCfg.SectAreaID);
			short blockId = TwelveImmortalsHelper.GetTwelveImmortalsNextBlockId(areaId, context.Random);
			Location location = new Location(areaId, blockId);
			Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), location);
			character.SetLocation(location, context);
		}
		List<short> charTemplateList = new List<short> { 924, 945 };
		for (int avatarId = 0; avatarId < 9; avatarId++)
		{
			XiangshuAvatarTaskStatus xiangshuAvatarTaskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(avatarId);
			if (xiangshuAvatarTaskStatus.JuniorXiangshuTaskStatus > 0 && DomainManager.Character.TryGetElement_Objects(xiangshuAvatarTaskStatus.JuniorXiangshuCharId, out var character2))
			{
				charTemplateList.Add(character2.GetTemplateId());
			}
		}
		foreach (short template in charTemplateList)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(template, out var character3) && !(character3.GetLocation() != Location.Invalid))
			{
				Location location2 = DomainManager.Taiwu.GetTaiwuVillageLocation();
				Events.RaiseFixedCharacterLocationChanged(context, character3.GetId(), character3.GetLocation(), location2);
				character3.SetLocation(location2, context);
			}
		}
		if (DomainManager.World.IsTaskFinished(704))
		{
			return;
		}
		List<short> charTemplateList2 = new List<short> { 911, 919 };
		foreach (short template2 in charTemplateList2)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(template2, out var character4) && !(character4.GetLocation() != Location.Invalid))
			{
				Location location3 = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
				Events.RaiseFixedCharacterLocationChanged(context, character4.GetId(), character4.GetLocation(), location3);
				character4.SetLocation(location3, context);
				int distance = 2;
				DomainManager.Character.SetCharacterFollowTaiwu(context, character4.GetId(), distance);
			}
		}
	}

	[DataUpgrader(Version = "1.0.50", Date = "2026/07/05")]
	private void FixPastTaiwuVillageWeather(DataContext context)
	{
		if (DomainManager.Taiwu.AtPastTaiwuVillage())
		{
			DomainManager.World.UpdateAreaStoryWeathers(context, 139, 18);
		}
	}

	[DataUpgrader(Version = "1.0.74", Date = "2026/08/12")]
	private void FixCombatGroupCharIds(DataContext context)
	{
		HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		List<int> specialGroup = DomainManager.Taiwu.GetTaiwuSpecialGroup();
		for (int i = 0; i < 3; i++)
		{
			int charId = DomainManager.Taiwu.GetElement_CombatGroupCharIds(i);
			if (!groupCharIds.Contains(charId) && !specialGroup.Contains(charId))
			{
				DomainManager.Taiwu.SetElement_CombatGroupCharIds(i, -1, context);
			}
		}
	}

	[DataUpgrader(Version = "1.0.10", Date = "2026/06/20")]
	private void FixMainStoryTwelveImmortals(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<short> learnedCombatSkills = taiwu.GetLearnedCombatSkills();
		for (int i = 0; i < _twelveImmortalsStatuses.Length; i++)
		{
			TwelveImmortalsStatus status = _twelveImmortalsStatuses[i];
			if (status != null && status.Progress >= 1 && status.AssistState != 2)
			{
				TwelveImmortalsItem config = TwelveImmortals.Instance[i];
				if ((!DomainManager.Character.TryGetFixedCharacterByTemplateId(config.Character, out var character) || !character.GetLocation().IsValid()) && !learnedCombatSkills.Contains(config.CombatSkill))
				{
					DomainManager.Taiwu.TaiwuLearnCombatSkill(context, config.CombatSkill, 31775);
				}
			}
		}
	}

	[DataUpgrader(Version = "1.0.14", Date = "2026/06/21")]
	private void FixMissingMainStoryAdventure1(DataContext context)
	{
		if (DomainManager.World.IsTaskInProgress(332))
		{
			FixMissingMainStoryAdventure(context, 9, 358928716);
		}
		if (DomainManager.World.IsTaskInProgress(326))
		{
			FixMissingMainStoryAdventure(context, 31, 197737628);
		}
		if (DomainManager.World.IsTaskInProgress(259))
		{
			FixMissingMainStoryAdventure(context, 7, 881422255);
		}
		if (DomainManager.World.IsTaskInProgress(221))
		{
			FixMissingMainStoryAdventure(context, 12, 858486210);
		}
		if (DomainManager.World.IsTaskInProgress(379))
		{
			FixMissingMainStoryAdventure(context, 12, 662834376);
		}
		if (DomainManager.World.IsTaskInProgress(295))
		{
			FixMissingMainStoryAdventure(context, 14, 696935809);
		}
		if (DomainManager.World.IsTaskInProgress(305))
		{
			FixMissingMainStoryAdventure(context, 14, 196599723);
		}
	}

	[DataUpgrader(Version = "1.0.19", Date = "2026/06/23")]
	private void FixMissingMainStoryAdventure2(DataContext context)
	{
		if (DomainManager.World.IsTaskInProgress(267))
		{
			FixMissingMainStoryAdventure(context, 7, 832217391);
		}
		if (DomainManager.World.IsTaskInProgress(120))
		{
			FixMissingMainStoryAdventureAtBelong(context, 15, 192388978);
		}
	}

	private void FixMissingMainStoryAdventure(DataContext context, sbyte orgTemplateId, int coreId)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		if (settlement == null)
		{
			return;
		}
		Location settlementLocation = settlement.GetLocation();
		MapBlockData settlementBlock = DomainManager.Map.GetBlock(settlementLocation);
		List<MapBlockData> settlementBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		settlementBlocks.Add(settlementBlock);
		settlementBlocks.AddUniqueRange(settlementBlock.GroupBlockList);
		bool missing = true;
		foreach (MapBlockData block in settlementBlocks)
		{
			foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInLocation(block.GetLocation()))
			{
				if (runtime.CoreId == coreId)
				{
					missing = false;
				}
			}
		}
		if (missing)
		{
			Location targetLocation = settlementBlocks.GetRandom(context.Random).GetLocation();
			IAdventureRuntime runtime2 = DomainManager.Adventure.GenerateAny(context, coreId, targetLocation);
			runtime2.CallCharacters(context);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(settlementBlocks);
	}

	private void FixMissingMainStoryAdventureAtBelong(DataContext context, sbyte orgTemplateId, int coreId)
	{
		if (DomainManager.Adventure.QueryCountInWorld(coreId) > 0)
		{
			return;
		}
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		if (settlement == null)
		{
			return;
		}
		Location settlementLocation = settlement.GetLocation();
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(settlementLocation.AreaId);
		List<MapBlockData> belongBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.BelongBlockId == settlementLocation.BlockId)
			{
				belongBlocks.Add(block);
			}
		}
		Location targetLocation = belongBlocks.GetRandom(context.Random).GetLocation();
		IAdventureRuntime runtime = DomainManager.Adventure.GenerateAny(context, coreId, targetLocation);
		runtime.CallCharacters(context);
		ObjectPool<List<MapBlockData>>.Instance.Return(belongBlocks);
	}

	[DataUpgrader(Version = "1.0.13", Date = "2026/06/21")]
	private void FixElopeWithLoveGlobalEventArgBox(DataContext context)
	{
		int[] elopeWithLoveAdventureCoreIds = new int[4] { 132986587, 185782501, 41731331, 23132446 };
		if (!DomainManager.Adventure.QueryAnyInWorld(elopeWithLoveAdventureCoreIds).Any())
		{
			EventArgBox globalEventArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
			globalEventArgBox.Remove<int>("ForeverLoverId");
			globalEventArgBox.Remove<int>("StoryForeverLoverId");
		}
	}

	[DataUpgrader(Version = "1.0.31", Date = "2026/06/25")]
	private void FixKongsangTripodVesselOfMedicine(DataContext context)
	{
		if (DomainManager.World.IsTaskFinished(114) && !DomainManager.Character.TryGetFixedCharacterByTemplateId(755, out var _))
		{
			GameData.Domains.Character.Character character2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 755);
			EventHelper.MoveFixedCharacter(character2, DomainManager.Taiwu.GetTaiwuVillageLocation());
			DomainManager.Organization.SetSectFunctionStatus(context, 10, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked, value: true);
		}
	}

	[DataUpgrader(Version = "1.0.45", Date = "2026/07/01")]
	private void FixSectMainStoryYuanshanBone(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		int rosaryCount = inventory.GetInventoryItemCount(12, 345);
		int boneCount = inventory.GetInventoryItemCount(2, 272);
		bool jieqingUpgradedInteractionUnlocked = DomainManager.Organization.GetSectFunctionStatus(13, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked);
		if (rosaryCount > 0 && boneCount <= 0 && !jieqingUpgradedInteractionUnlocked)
		{
			ItemKey newBone = DomainManager.Item.CreateItem(context, 2, 272);
			taiwu.AddInventoryItem(context, newBone, 1);
		}
	}

	[DataUpgrader(Version = "1.0.48", Date = "2026/07/03")]
	private void FixSectMainStoryJingangAdventure(DataContext context)
	{
		bool taskInProgress = DomainManager.World.IsTaskInProgress(199);
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(11);
		IEnumerable<AdventureMajorEvent> majorEvents = DomainManager.Adventure.QueryMajorEventsInArea(areaId);
		bool adventureExists = false;
		foreach (AdventureMajorEvent majorEvent in majorEvents)
		{
			if (majorEvent.CoreId == 142172897)
			{
				adventureExists = true;
			}
		}
		if (taskInProgress && !adventureExists)
		{
			EventHelper.JingangCreateAdventure();
		}
	}

	[DataUpgrader(Version = "1.0.48", Date = "2026/07/03")]
	private void FixSectMainStoryWudangAccessory(DataContext context)
	{
		sbyte wudangStatus = DomainManager.Story.GetSectMainStoryTaskStatus(4);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		int qiCount = inventory.GetInventoryItemCount(2, 271);
		bool shaolinUpgradedInteractionUnlocked = DomainManager.Organization.GetSectFunctionStatus(1, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked);
		if (wudangStatus == 1 && qiCount <= 0 && !shaolinUpgradedInteractionUnlocked)
		{
			ItemKey newQi = DomainManager.Item.CreateItem(context, 2, 271);
			taiwu.AddInventoryItem(context, newQi, 1);
		}
	}

	[DataUpgrader(Version = "1.0.53", Date = "2026/07/07")]
	private void FixSectMainStoryJingangAdventureTargetLocation(DataContext context)
	{
		bool taskInProgress = DomainManager.World.IsTaskInProgress(199);
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(11);
		IEnumerable<AdventureMajorEvent> majorEvents = DomainManager.Adventure.QueryMajorEventsInArea(areaId);
		bool adventureExists = false;
		Location location = Location.Invalid;
		foreach (AdventureMajorEvent majorEvent in majorEvents)
		{
			if (majorEvent.CoreId == 142172897)
			{
				adventureExists = true;
				location = majorEvent.MapLocation;
			}
		}
		if (taskInProgress && adventureExists)
		{
			EventHelper.SaveArgToSectMainStory(11, SectMainStoryEventArgKey.DefValue.JingangAdventureNearestSettlementId, location);
		}
	}

	[DataUpgrader(Version = "1.0.48", Date = "2026/07/03")]
	private void FixSectMainStoryShixiangAccessory(DataContext context)
	{
		sbyte shixiangStatus = DomainManager.Story.GetSectMainStoryTaskStatus(6);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		int drumCount = inventory.GetInventoryItemCount(2, 273);
		bool wuxianUpgradedInteractionUnlocked = DomainManager.Organization.GetSectFunctionStatus(12, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked);
		if (shixiangStatus == 1 && drumCount <= 0 && !wuxianUpgradedInteractionUnlocked)
		{
			ItemKey newDrum = DomainManager.Item.CreateItem(context, 2, 273);
			taiwu.AddInventoryItem(context, newDrum, 1);
		}
	}

	[DataUpgrader(Version = "1.0.56", Date = "2026/07/06")]
	private void FixDisappearedSectCharacters(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(15) != 0)
		{
			int totalValue = DomainManager.Extra.GetJixiTotalGrowValue(null);
			if (1 == 0)
			{
			}
			short num = (short)((totalValue < 770) ? 877 : ((totalValue >= 1540) ? 879 : 878));
			if (1 == 0)
			{
			}
			short templateId = num;
			if (!DomainManager.Character.TryGetFixedCharacterByTemplateId(877, out var character) && !DomainManager.Character.TryGetFixedCharacterByTemplateId(878, out character) && !DomainManager.Character.TryGetFixedCharacterByTemplateId(879, out character))
			{
				GameData.Domains.Character.Character character2 = DomainManager.Character.CreateFixedCharacter(context, templateId);
				DomainManager.Character.CompleteCreatingCharacter(character2.GetId());
				DomainManager.Character.JixiMovement(context, character2);
			}
		}
	}

	[DataUpgrader(Version = "1.0.56", Date = "2026/07/06")]
	private void FixDuplicateJixi(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(15) == 0)
		{
			return;
		}
		int totalValue = DomainManager.Extra.GetJixiTotalGrowValue(null);
		if (1 == 0)
		{
		}
		short num = (short)((totalValue < 770) ? 877 : ((totalValue >= 1540) ? 879 : 878));
		if (1 == 0)
		{
		}
		short templateId = num;
		List<short> ids = new List<short> { 877, 878, 879 };
		foreach (short id in ids)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(id, out var fixedCharacter))
			{
				if (templateId != id)
				{
					DomainManager.Character.RemoveNonIntelligentCharacter(context, fixedCharacter);
				}
			}
			else if (templateId == id)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedCharacter(context, templateId);
				DomainManager.Character.CompleteCreatingCharacter(character.GetId());
				DomainManager.Character.JixiMovement(context, character);
			}
		}
	}

	[DataUpgrader(Version = "1.0.56", Date = "2026/07/10")]
	private void FixBadEndJixi(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(15) != 2 && !DomainManager.Story.CheckSectMainStoryEndingCountDown(15, isGoodEnding: false, isReady: false) && !DomainManager.Story.CheckSectMainStoryEndingCountDown(15, isGoodEnding: false, isReady: true))
		{
			return;
		}
		List<short> ids = new List<short> { 877, 878, 879 };
		foreach (short id in ids)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(id, out var fixedCharacter))
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(context, fixedCharacter);
			}
		}
	}

	[DataUpgrader(Version = "1.0.53", Date = "2026/07/07")]
	private void FixJingangFunctionStatus(DataContext context)
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(778, out var monk) && monk.GetLocation().IsValid() && !DomainManager.Organization.GetSectFunctionStatus(11, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked))
		{
			DomainManager.Organization.SetSectFunctionStatus(context, 11, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked, value: true);
		}
	}

	private void FixResetShaolin(DataContext context)
	{
	}

	public override void FixAbnormalDomainArchiveData(DataContext context)
	{
		if (DomainManager.World.GetDefeatSwordTombCount() <= 4 || DomainManager.World.IsTaskFinished(74))
		{
			return;
		}
		bool unlock5 = DomainManager.World.IsTaskFinished(67);
		EventArgBox globalArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		Location location = Location.Invalid;
		if (unlock5 && !globalArgBox.Get("SealedLastSwordTomb", out location))
		{
			location = Location.Invalid;
		}
		foreach (SwordTombItem config in (IEnumerable<SwordTombItem>)SwordTomb.Instance)
		{
			foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInWorld(config.AdventureCoreId))
			{
				if (!runtime.StatusType.IsAsleep())
				{
					bool is5 = location == runtime.MapLocation;
					if (!(is5 && unlock5))
					{
						DomainManager.Adventure.HideAdventure(context, runtime.Id);
						Logger.Warn($"Auto hide sword tomb {runtime} in {runtime.MapLocation}");
					}
				}
			}
		}
	}

	[DataUpgrader(Version = "1.0.48", Date = "2026/07/03")]
	private void FixWeakenedXiangshuAvatar(DataContext context)
	{
		List<IAdventureRuntime> runtimes = ObjectPool<List<IAdventureRuntime>>.Instance.Get();
		for (int i = 0; i < SwordTomb.Instance.Count; i++)
		{
			SwordTombItem config = SwordTomb.Instance[i];
			runtimes.Clear();
			runtimes.AddRange(DomainManager.Adventure.QueryAnyInWorld(config.AdventureCoreId));
			if (runtimes != null && runtimes.Count > 0 && runtimes[0].StatusType.IsActive())
			{
				continue;
			}
			short beginId = XiangshuAvatarIds.WeakenedXiangshuBossBeginIds[i];
			short endId = XiangshuAvatarIds.WeakenedXiangshuBossEndIds[i];
			for (short templateId = beginId; templateId <= endId; templateId++)
			{
				if (DomainManager.Character.TryGetFixedCharacterByTemplateId(templateId, out var character))
				{
					DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
				}
			}
			IReadOnlySet<int> swordTombKeepers = DomainManager.Taiwu.GetVillagerRoleSet(5);
			foreach (int charId in swordTombKeepers)
			{
				VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
				if (villagerRole is VillagerRoleSwordTombKeeper keeper && villagerRole.ArrangementTemplateId == 13 && keeper.XiangshuAvatarId == i)
				{
					DomainManager.Taiwu.RemoveVillagerWork(context, charId);
				}
			}
		}
		ObjectPool<List<IAdventureRuntime>>.Instance.Return(runtimes);
	}

	[DataUpgrader(Version = "1.0.45", Date = "2026/07/02")]
	private void SetJixiStatus(DataContext context)
	{
		if (!DomainManager.Organization.GetSectFunctionStatus(15, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked) && IsJixiFree())
		{
			DomainManager.Organization.SetSectFunctionStatus(context, 15, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked, value: true);
		}
	}

	[DataUpgrader(Version = "1.0.51", Date = "2026/07/07")]
	private void SetJixiTaskStatus(DataContext context)
	{
		if (DomainManager.Organization.GetSectFunctionStatus(15, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked) && DomainManager.Extra.GetSectMainStoryEventArgBox(15).GetBool(SectMainStoryEventArgKey.DefValue.XuehouSelectFreeJixi))
		{
			DomainManager.Extra.GetSectMainStoryEventArgBox(15).Remove<bool>(SectMainStoryEventArgKey.DefValue.XuehouSelectFreeJixi);
		}
	}

	[NewDomainDataInitializer(20, 12)]
	private void InitTwelveImmortalsStatuses()
	{
		for (int i = 0; i < _twelveImmortalsStatuses.Length; i++)
		{
			TwelveImmortalsStatus[] twelveImmortalsStatuses = _twelveImmortalsStatuses;
			int num = i;
			if (twelveImmortalsStatuses[num] == null)
			{
				twelveImmortalsStatuses[num] = new TwelveImmortalsStatus();
			}
		}
	}

	private void InitializeOnInitializeGameDataModule()
	{
	}

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnEnterNewWorld()
	{
		Events.RegisterHandler_AdvanceMonthFinish(AdvanceMonth_SectClearData);
	}

	private void OnLoadedArchiveData()
	{
		Events.RegisterHandler_AdvanceMonthFinish(AdvanceMonth_SectClearData);
	}

	public override void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
		InitializeBaihuaLinkedCharacters(context);
		InitializeEmeiBonusData(context);
		UpdateSectEmeiGuidanceData(context);
		base.OnCurrWorldArchiveDataReady(context, isNewWorld);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		crossArchiveGameData.SectEmeiSkillBreakBonus = _sectEmeiSkillBreakBonus;
		crossArchiveGameData.SectEmeiBreakBonusTemplateIds = _sectEmeiBreakBonusTemplateIds;
		crossArchiveGameData.SectEmeiBonusData = _sectEmeiBreakBonusData;
	}

	public void UnpackCrossArchiveGameData_CombatSkills(DataContext context, CrossArchiveGameData crossArchiveGameData, bool overwriteEquipment)
	{
		short key;
		if (crossArchiveGameData.SectEmeiSkillBreakBonus != null)
		{
			foreach (KeyValuePair<short, SkillBreakBonusCollection> sectEmeiSkillBreakBonu in crossArchiveGameData.SectEmeiSkillBreakBonus)
			{
				sectEmeiSkillBreakBonu.Deconstruct(out key, out var value);
				short id = key;
				SkillBreakBonusCollection bonusCollection = value;
				if (!_sectEmeiSkillBreakBonus.ContainsKey(id))
				{
					AddElement_SectEmeiSkillBreakBonus(id, bonusCollection, context);
				}
			}
		}
		if (crossArchiveGameData.SectEmeiBreakBonusTemplateIds != null)
		{
			foreach (KeyValuePair<short, GameData.Utilities.ShortList> sectEmeiBreakBonusTemplateId in crossArchiveGameData.SectEmeiBreakBonusTemplateIds)
			{
				sectEmeiBreakBonusTemplateId.Deconstruct(out key, out var value2);
				short id2 = key;
				GameData.Utilities.ShortList templateIds = value2;
				if (!_sectEmeiBreakBonusTemplateIds.ContainsKey(id2))
				{
					AddElement_SectEmeiBreakBonusTemplateIds(id2, templateIds, context);
				}
			}
		}
		if (crossArchiveGameData.SectEmeiBonusData != null)
		{
			foreach (KeyValuePair<short, SectEmeiBreakBonusData> sectEmeiBonusDatum in crossArchiveGameData.SectEmeiBonusData)
			{
				sectEmeiBonusDatum.Deconstruct(out key, out var value3);
				short id3 = key;
				SectEmeiBreakBonusData data = value3;
				if (!_sectEmeiBreakBonusData.TryGetValue(id3, out var existData))
				{
					AddElement_SectEmeiBreakBonusData(id3, data, context);
					continue;
				}
				existData.OfflineMerge(data);
				SetElement_SectEmeiBreakBonusData(id3, existData, context);
			}
		}
		crossArchiveGameData.SectEmeiSkillBreakBonus = null;
		crossArchiveGameData.SectEmeiBreakBonusTemplateIds = null;
	}

	[DomainMethod]
	public bool GmCmd_SectEmeiAddSkillBreakBonus(DataContext context, short combatSkillId, short bonusTypeTemplateId)
	{
		return AddEmeiSkillBreakBonusWithoutCost(context, combatSkillId, bonusTypeTemplateId);
	}

	[DomainMethod]
	public bool GmCmd_SectEmeiClearSkillBreakBonus(DataContext context, short combatSkillId)
	{
		return ClearEmeiSkillBreakBonus(context, combatSkillId);
	}

	public void CreateTwelveImmortalsMember(DataContext context, sbyte immortalTemplateId)
	{
		TwelveImmortalsItem immortalCfg = TwelveImmortals.Instance[immortalTemplateId];
		GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, immortalCfg.Character);
		TwelveImmortalsStatus status = _twelveImmortalsStatuses[immortalTemplateId] ?? new TwelveImmortalsStatus();
		status.CharacterId = character.GetId();
		status.Progress = 1;
		character.SetLocation(Location.Invalid, context);
		Location nextLocation = character.GetTwelveImmortalsNextLocation(context.Random);
		Location prevLocation = character.GetLocation();
		character.SetLocation(nextLocation, context);
		Events.RaiseFixedCharacterLocationChanged(context, status.CharacterId, prevLocation, nextLocation);
		SetElement_TwelveImmortalsStatuses(immortalTemplateId, status, context);
	}

	public bool IsTwelveImmortalsMemberCreated(int twelveImmortalId)
	{
		TwelveImmortalsStatus twelveImmortalsStatus = _twelveImmortalsStatuses[twelveImmortalId];
		if (twelveImmortalsStatus != null)
		{
			sbyte progress = twelveImmortalsStatus.Progress;
			if (progress != 1)
			{
				int characterId = twelveImmortalsStatus.CharacterId;
				if (characterId < 0)
				{
					goto IL_0028;
				}
			}
			return true;
		}
		goto IL_0028;
		IL_0028:
		return false;
	}

	public void InvokeAdvanceSwordFragmentSkillEvent()
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		MonthlyEventCollection monthlyEvent = DomainManager.World.GetMonthlyEventCollection();
		foreach (SwordTombItem config in (IEnumerable<SwordTombItem>)SwordTomb.Instance)
		{
			if (_advanceXiangshuAvatarIds.Contains(config.TemplateId))
			{
				continue;
			}
			XiangshuAvatarTaskStatus status = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(config.TemplateId);
			int charId = status.JuniorXiangshuCharId;
			if (charId < 0)
			{
				continue;
			}
			sbyte favorType = DomainManager.Character.GetFavorabilityType(charId, taiwuCharId);
			if (favorType < 6)
			{
				continue;
			}
			short monthlyEventId;
			if (status.JuniorXiangshuTaskStatus == 6)
			{
				monthlyEventId = config.MonthlyEventGood;
			}
			else
			{
				if (status.JuniorXiangshuTaskStatus != 5)
				{
					continue;
				}
				monthlyEventId = config.MonthlyEventBad;
			}
			monthlyEvent.AddMonthlyEventWithOneCharacterArgument(monthlyEventId, charId);
		}
	}

	public void SetIconPlateIsUnlocked(DataContext context, bool isUnlocked)
	{
		_ironPlateData.SetIsUnlocked(isUnlocked);
		int curData = DomainManager.World.GetCurrDate();
		_ironPlateData.SetCooldownDate(curData);
		SetIronPlateData(_ironPlateData, context);
	}

	private void RemoveIconPlateFollowingCharacter(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var curCharacter))
		{
			DomainManager.Character.RemoveCharacterFollowTaiwu(context, charId);
			return;
		}
		List<short> list;
		if (curCharacter.Template.GroupId < 0)
		{
			int num = 1;
			list = new List<short>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<short> span = CollectionsMarshal.AsSpan(list);
			int index = 0;
			span[index] = curCharacter.GetTemplateId();
		}
		else
		{
			list = (from c in Config.Character.Instance
				where c.CreatingType == 0 && c.GroupId == curCharacter.Template.GroupId
				select c.TemplateId).ToList();
		}
		List<short> templateList = list;
		foreach (short template in templateList)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(template, out var character))
			{
				DomainManager.Character.RemoveCharacterFollowTaiwu(context, charId);
				Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), Location.Invalid);
				character.SetLocation(Location.Invalid, context);
			}
		}
	}

	private void AddIconPlateFollowingCharacter(DataContext context, int charId)
	{
		int distance = 2;
		DomainManager.Character.SetCharacterFollowTaiwu(context, charId, distance);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		List<MapBlockData> taiwuNeighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			taiwuLocation = taiwu.GetValidLocation();
		}
		DomainManager.Map.GetRealNeighborBlocks(taiwuLocation.AreaId, taiwuLocation.BlockId, taiwuNeighborBlocks, distance);
		MapBlockData blockData = taiwuNeighborBlocks[context.Random.Next(0, taiwuNeighborBlocks.Count)];
		ObjectPool<List<MapBlockData>>.Instance.Return(taiwuNeighborBlocks);
		Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), blockData.GetLocation());
		character.SetLocation(blockData.GetLocation(), context);
	}

	[DomainMethod]
	public void SetIconPlateFollowingCharId(DataContext context, int charId)
	{
		if (_ironPlateData.FollowingCharId >= 0)
		{
			RemoveIconPlateFollowingCharacter(context, _ironPlateData.FollowingCharId);
		}
		_ironPlateData.SetFollowingCharId(charId);
		if (charId >= 0)
		{
			int curData = DomainManager.World.GetCurrDate();
			_ironPlateData.SetCooldownDate(curData + IronPlateData.CooldownDuration);
			AddIconPlateFollowingCharacter(context, charId);
		}
		SetIronPlateData(_ironPlateData, context);
	}

	private int GetOrCreateFixedCharacter(DataContext context, short templateId)
	{
		if (DomainManager.Character.FixedCharacterIds.TryGetValue(templateId, out var charId))
		{
			return charId;
		}
		CharacterItem config = Config.Character.Instance[templateId];
		if (config.CreatingType == 0)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedCharacter(context, templateId);
			charId = character.GetId();
			DomainManager.Character.CompleteCreatingCharacter(charId);
			return charId;
		}
		return -1;
	}

	[DomainMethod]
	public List<int> GetIronPlateOptionCharIdList(DataContext context)
	{
		HashSet<int> set = new HashSet<int>();
		foreach (short templateId in IronPlateCharInteractionTemplateIdList)
		{
			int charId = GetOrCreateFixedCharacter(context, templateId);
			if (charId >= 0)
			{
				set.Add(charId);
			}
		}
		GameData.Domains.Character.Character jixi = DomainManager.Story.TryGetJixi();
		if (jixi != null)
		{
			set.Add(jixi.GetId());
		}
		return set.ToList();
	}

	[DomainMethod]
	public int GetIronPlateCombatCharId(DataContext context)
	{
		if (!_ironPlateData.IsUnlocked || _ironPlateData.FollowingCharId < 0)
		{
			return -1;
		}
		if (!DomainManager.Character.TryGetElement_Objects(_ironPlateData.FollowingCharId, out var interactionCharacter))
		{
			return -1;
		}
		short interactionTemplateId = interactionCharacter.GetTemplateId();
		if (interactionTemplateId >= 877 && interactionTemplateId <= 879)
		{
			return _ironPlateData.FollowingCharId;
		}
		int index = IronPlateCharInteractionTemplateIdList.IndexOf(interactionTemplateId);
		short combatTemplateId = IronPlateCharCombatTemplateIdList[index];
		if (interactionTemplateId == combatTemplateId)
		{
			return _ironPlateData.FollowingCharId;
		}
		if (!DomainManager.Character.FixedCharacterIds.TryGetValue(combatTemplateId, out var combatCharId))
		{
			GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedCharacter(context, combatTemplateId);
			combatCharId = character.GetId();
			DomainManager.Character.CompleteCreatingCharacter(combatCharId);
			Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), Location.Invalid);
			character.SetLocation(Location.Invalid, context);
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		short favorability1 = DomainManager.Character.GetFavorability(_ironPlateData.FollowingCharId, taiwuCharId);
		short favorability2 = DomainManager.Character.GetFavorability(taiwuCharId, _ironPlateData.FollowingCharId);
		DomainManager.Character.DirectlySetFavorabilities(context, _ironPlateData.FollowingCharId, combatCharId, favorability1, favorability2);
		return combatCharId;
	}

	[DomainMethod]
	public void GmCmd_ClearIronPlateCooldown(DataContext context)
	{
		if (_ironPlateData != null)
		{
			_ironPlateData.SetCooldownDate(DomainManager.World.GetCurrDate());
			SetIronPlateData(_ironPlateData, context);
		}
	}

	[DomainMethod]
	public void GmCmd_SetIconPlateIsUnlocked(DataContext context, bool isUnlocked)
	{
		SetIconPlateIsUnlocked(context, isUnlocked);
	}

	public void SetDivineFlameIsUnlocked(DataContext context, bool isUnlocked)
	{
		_divineFlameData.SetIsUnlocked(isUnlocked);
		int curData = DomainManager.World.GetCurrDate();
		_divineFlameData.SetCooldownDate(curData);
		SetDivineFlameData(_divineFlameData, context);
	}

	[DomainMethod]
	public bool CheckDivineFlameTarget(DataContext context, sbyte xiangshuAvatarId)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		bool isGood = DomainManager.World.IsXiangshuAvatarTaskStatusesGood(xiangshuAvatarId);
		switch (DivineFlameData.GetTargetType(xiangshuAvatarId, isGood))
		{
		case DivineFlameData.TargetType.None:
			return true;
		case DivineFlameData.TargetType.SelectCharacter:
		case DivineFlameData.TargetType.CheckCharacter:
			return GetDivineFlameSelectTargetCharIdList(context, xiangshuAvatarId).Count > 0;
		case DivineFlameData.TargetType.SelectBlock:
		case DivineFlameData.TargetType.CheckBlock:
			return GetDivineFlameSelectTargetLocationList(context, xiangshuAvatarId, location).Count > 0;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	[DomainMethod]
	public List<Location> GetDivineFlameSelectTargetLocationList(DataContext context, sbyte xiangshuAvatarId, Location location)
	{
		if (location == Location.Invalid)
		{
			location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		}
		bool isGood = DomainManager.World.IsXiangshuAvatarTaskStatusesGood(xiangshuAvatarId);
		List<Location> list = new List<Location>();
		switch (xiangshuAvatarId)
		{
		case 2:
			GetDivineFlameSelectTargetLocationListForJiuhan(context, isGood, location, list);
			break;
		case 7:
			GetDivineFlameSelectTargetLocationListForXuefeng(context, isGood, location, list);
			break;
		}
		return list;
	}

	private void GetDivineFlameSelectTargetLocationListForJiuhan(DataContext context, bool isGood, Location location, List<Location> locationList)
	{
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 1, includeCenter: true);
		if (isGood)
		{
			foreach (MapBlockData block in neighborBlocks)
			{
				if (!block.Destroyed && !block.IsCityTown() && block.TemplateId != 37 && block.RootBlockId < 0 && block.GroupBlockList == null && block.CurrResources.GetSum() < block.MaxResources.GetSum())
				{
					locationList.Add(block.GetLocation());
				}
			}
		}
		else
		{
			foreach (MapBlockData block2 in neighborBlocks)
			{
				if (!block2.Destroyed && !block2.IsCityTown() && block2.TemplateId != 37 && block2.RootBlockId < 0 && block2.GroupBlockList == null)
				{
					locationList.Add(block2.GetLocation());
				}
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
	}

	private void GetDivineFlameSelectTargetLocationListForXuefeng(DataContext context, bool isGood, Location location, List<Location> locationList)
	{
		if (isGood)
		{
			return;
		}
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetValidBlocksForRandomEnemy(location.AreaId, location.BlockId, 1, onSettlement: false, nearTaiwu: true, neighborBlocks);
		foreach (MapBlockData block in neighborBlocks)
		{
			locationList.Add(block.GetLocation());
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
	}

	[DomainMethod]
	public List<int> GetDivineFlameSelectTargetCharIdList(DataContext context, sbyte xiangshuAvatarId)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		bool isGood = DomainManager.World.IsXiangshuAvatarTaskStatusesGood(xiangshuAvatarId);
		List<int> charIdList = new List<int>();
		switch (xiangshuAvatarId)
		{
		case 0:
			GetDivineFlameSelectTargetCharIdListForMonv(context, charIdList, location);
			break;
		case 1:
			GetDivineFlameSelectTargetCharIdListForDayueYaochang(context, charIdList, location, isGood);
			break;
		case 3:
			GetDivineFlameSelectTargetCharIdListForJinHuanger(context, charIdList, location);
			break;
		case 4:
			GetDivineFlameSelectTargetCharIdListForYiYihou(context, charIdList, location);
			break;
		case 5:
			GetDivineFlameSelectTargetCharIdListForWeiQi(context, charIdList, location);
			break;
		case 6:
			GetDivineFlameSelectTargetCharIdListForYixiang(context, charIdList, location);
			break;
		case 7:
			GetDivineFlameSelectTargetCharIdListForXuefeng(context, charIdList, location, isGood);
			break;
		case 8:
			GetDivineFlameSelectTargetCharIdListForShufang(context, charIdList, location, isGood);
			break;
		}
		return charIdList.Distinct().ToList();
	}

	public void GetDivineFlameSelectTargetCharactersInRange(DataContext context, Location centerLocation, List<int> charIds, int maxSteps, bool includeTaiwu)
	{
		if (centerLocation == Location.Invalid)
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetRealNeighborBlocks(centerLocation.AreaId, centerLocation.BlockId, neighborBlocks, maxSteps, includeCenter: true);
		foreach (MapBlockData block in neighborBlocks)
		{
			if (block.CharacterSet != null)
			{
				charIds.AddRange(block.CharacterSet);
			}
			if (block.InfectedCharacterSet != null)
			{
				charIds.AddRange(block.InfectedCharacterSet);
			}
			if (includeTaiwu)
			{
				charIds.AddRange(DomainManager.Taiwu.GetGroupCharIds().GetCollection());
				continue;
			}
			foreach (int charId in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
			{
				if (charId != taiwuCharId)
				{
					charIds.Add(charId);
				}
			}
		}
		charIds.RemoveAll((int id) => !DomainManager.Character.GetElement_Objects(id).IsInteractableAsIntelligentCharacter());
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
	}

	private void GetDivineFlameSelectTargetCharIdListForMonv(DataContext context, List<int> charIdList, Location targetLocation)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 1, includeTaiwu: false);
	}

	private void GetDivineFlameSelectTargetCharIdListForDayueYaochang(DataContext context, List<int> charIdList, Location targetLocation, bool isGood)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 3, includeTaiwu: false);
		if (isGood)
		{
			charIdList.RemoveAll((int id) => !DomainManager.Character.GetElement_Objects(id).IsCompletelyInfected());
		}
		else
		{
			charIdList.RemoveAll((int id) => DomainManager.Character.GetElement_Objects(id).IsCompletelyInfected());
		}
	}

	private void GetDivineFlameSelectTargetCharIdListForJinHuanger(DataContext context, List<int> charIdList, Location targetLocation)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 2, includeTaiwu: false);
	}

	private void GetDivineFlameSelectTargetCharIdListForYiYihou(DataContext context, List<int> charIdList, Location targetLocation)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 2, includeTaiwu: true);
	}

	private void GetDivineFlameSelectTargetCharIdListForWeiQi(DataContext context, List<int> charIdList, Location targetLocation)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 2, includeTaiwu: false);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		charIdList.RemoveAll((int id) => !DomainManager.Character.TryGetRelation(taiwuCharId, id, out var _));
	}

	private void GetDivineFlameSelectTargetCharIdListForYixiang(DataContext context, List<int> charIdList, Location targetLocation)
	{
		GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 3, includeTaiwu: false);
	}

	private void GetDivineFlameSelectTargetCharIdListForXuefeng(DataContext context, List<int> charIdList, Location targetLocation, bool isGood)
	{
		if (isGood)
		{
			GetDivineFlameSelectTargetCharactersInRange(context, targetLocation, charIdList, 2, includeTaiwu: false);
			charIdList.RemoveAll((int id) => DomainManager.Character.GetElement_Objects(id).GetFameType() >= 3);
		}
	}

	private void GetDivineFlameSelectTargetCharIdListForShufang(DataContext context, List<int> charIdList, Location targetLocation, bool isGood)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetRealNeighborBlocks(targetLocation.AreaId, targetLocation.BlockId, neighborBlocks, 2, includeCenter: true);
		foreach (MapBlockData block in neighborBlocks)
		{
			if (block.CharacterSet != null)
			{
				foreach (int charId in block.CharacterSet)
				{
					if (!isGood || DomainManager.Character.GetElement_Objects(charId).GetCurrAge() > 16)
					{
						charIdList.Add(charId);
					}
				}
			}
			if (block.AreaId != taiwuLocation.AreaId || block.BlockId != taiwuLocation.BlockId)
			{
				continue;
			}
			HashSet<int> taiwuGroupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
			foreach (int charId2 in taiwuGroupCharIds)
			{
				if (!isGood || DomainManager.Character.GetElement_Objects(charId2).GetCurrAge() > 16)
				{
					charIdList.Add(charId2);
				}
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
	}

	[DomainMethod]
	public void UseDivineFlame(DataContext context, sbyte xiangshuAvatarId, int targetCharId, Location targetLocation)
	{
		int curData = DomainManager.World.GetCurrDate();
		_divineFlameData.SetCooldownDate(curData + DivineFlameData.CooldownDuration);
		if (targetLocation == Location.Invalid)
		{
			targetLocation = ((targetCharId >= 0) ? DomainManager.Character.GetElement_Objects(targetCharId).GetValidLocation() : DomainManager.Taiwu.GetTaiwu().GetValidLocation());
		}
		bool isGood = DomainManager.World.IsXiangshuAvatarTaskStatusesGood(xiangshuAvatarId);
		switch (xiangshuAvatarId)
		{
		case 0:
			UseDivineFlameForMonv(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 1:
			UseDivineFlameForDayueYaochang(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 2:
			UseDivineFlameForJiuhan(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 3:
			UseDivineFlameForJinHuanger(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 4:
			UseDivineFlameForYiYihou(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 5:
			UseDivineFlameForWeiQi(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 6:
			UseDivineFlameForYixiang(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 7:
			UseDivineFlameForXuefeng(context, isGood, targetCharId, curData, targetLocation);
			break;
		case 8:
			UseDivineFlameForShufang(context, isGood, targetCharId, curData, targetLocation);
			break;
		}
	}

	private void UseDivineFlameForMonv(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
		if (isGood)
		{
			Injuries injuries = targetChar.GetInjuries();
			DomainManager.Character.GetOrHealRandomInjuriesWithoutChecking(context.Random, ref injuries, -6, -3);
			targetChar.SetInjuries(injuries, context);
			PoisonInts poisoned = targetChar.GetPoisoned();
			DomainManager.Character.GetOrDetoxRandomPoisonsWithoutChecking(context.Random, ref poisoned, 3, -300, -100);
			targetChar.SetPoisoned(ref poisoned, context);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddMonvGood(targetCharId, date, targetLocation);
			DomainManager.World.GetInstantNotificationCollection().AddMonvGood(targetCharId);
		}
		else
		{
			Injuries injuries2 = targetChar.GetInjuries();
			PoisonInts poisoned2 = default(PoisonInts);
			DomainManager.Character.GetOrHealRandomInjuriesWithoutChecking(context.Random, ref injuries2, 3, 6);
			DomainManager.Character.GetOrDetoxRandomPoisonsWithoutChecking(context.Random, ref poisoned2, 3, 100, 300);
			targetChar.SetInjuries(injuries2, context);
			targetChar.DirectlyChangePoisoned(context, ref poisoned2);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddMonvBad(targetCharId, date, targetLocation);
			DomainManager.World.GetInstantNotificationCollection().AddMonvBad(targetCharId);
		}
	}

	private void UseDivineFlameForDayueYaochang(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(targetCharId);
		if (isGood)
		{
			DomainManager.Character.MakeCharacterDead(context, character, 12);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDayueYaochangGood(targetCharId, date, targetLocation);
			DomainManager.World.GetInstantNotificationCollection().AddDayueYaochangGood(targetCharId);
		}
		else
		{
			DomainManager.Character.MakeCharacterDead(context, character, 13);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDayueYaochangBad(targetCharId, date, targetLocation);
			DomainManager.World.GetInstantNotificationCollection().AddDayueYaochangBad(targetCharId);
		}
	}

	private void UseDivineFlameForJiuhan(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		List<Location> locationList = GetDivineFlameSelectTargetLocationList(context, 2, targetLocation);
		foreach (Location location in locationList)
		{
			MapBlockData block = DomainManager.Map.GetBlock(location);
			if (block.Destroyed || block.IsCityTown() || block.TemplateId == 37 || block.RootBlockId >= 0 || block.GroupBlockList != null)
			{
				return;
			}
			if (isGood)
			{
				block.CurrResources = block.MaxResources;
				DomainManager.Map.SetBlockData(context, block);
			}
			else
			{
				DomainManager.Map.MakeBlockDestroyed(context, block);
			}
		}
		if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddJiuhanGood();
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddJiuhanBad();
		}
	}

	private void UseDivineFlameForJinHuanger(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(targetCharId);
		int rate = 100;
		if (context.Random.CheckPercentProb(rate))
		{
			DomainManager.Character.ApplyLuckEventToCharacter(context, character, isGood);
			if (isGood)
			{
				DomainManager.World.GetInstantNotificationCollection().AddJinHuangerGood(targetCharId);
				DomainManager.LifeRecord.GetLifeRecordCollection().AddJinHuangerGood(targetCharId, date, targetLocation);
			}
			else
			{
				DomainManager.World.GetInstantNotificationCollection().AddJinHuangerBad(targetCharId);
				DomainManager.LifeRecord.GetLifeRecordCollection().AddJinHuangerBad(targetCharId, date, targetLocation);
			}
		}
		else if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddJinHuangerGoodFailed();
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddJinHuangerBadFailed();
		}
	}

	private void UseDivineFlameForYiYihou(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		List<int> charIdList = GetDivineFlameSelectTargetCharIdList(context, 4);
		DomainManager.Character.SetDivineFlameRelationTargetLocation(context, targetLocation);
		HashSet<int> charSet = new HashSet<int>();
		foreach (int charId in charIdList)
		{
			charSet.Clear();
			foreach (int id in charIdList)
			{
				if (charId != id)
				{
					charSet.Add(id);
				}
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (isGood)
			{
				character.DivineFlameTryAddRelation_Adore(context, charSet);
			}
			else
			{
				character.DivineFlameTryAddRelation_Enemy(context, charSet);
			}
		}
	}

	private void UseDivineFlameForWeiQi(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddWeiQiGoodStart(targetCharId);
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddWeiQiBadStart(targetCharId);
		}
		DomainManager.Character.SetAvoidDeathCharId(context, targetCharId);
	}

	private void UseDivineFlameForYixiang(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddYixiangGood();
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddYixiangBad();
		}
		DomainManager.Character.SetDivineFlameMoralityTargetLocation(context, targetLocation, isGood);
		List<int> charIdList = GetDivineFlameSelectTargetCharIdList(context, 6);
		foreach (int charId in charIdList)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			Location location = character.GetValidLocation();
			if (isGood)
			{
				DomainManager.LifeRecord.GetLifeRecordCollection().AddYixiangGood(charId, date, location);
			}
			else
			{
				DomainManager.LifeRecord.GetLifeRecordCollection().AddYixiangBad(charId, date, location);
			}
		}
	}

	private void UseDivineFlameForXuefeng(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddXuefengGood(targetCharId);
			short templateId = 208;
			int charId;
			bool hasSelf = DomainManager.Character.FixedCharacterIds.TryGetValue(templateId, out charId);
			GameData.Domains.Character.Character character = (hasSelf ? DomainManager.Character.GetElement_Objects(charId) : DomainManager.Character.CreateFixedCharacter(context, templateId));
			GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
			DomainManager.Character.SimulateCharacterCombat(context, character, targetChar, CombatType.Beat, isGroupCombat: true, 5);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddXuefengGood(targetCharId, date, targetLocation);
			if (!hasSelf)
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
			}
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddXuefengBad();
			List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
			DomainManager.Map.GetValidBlocksForRandomEnemy(targetLocation.AreaId, targetLocation.BlockId, 1, onSettlement: false, nearTaiwu: true, neighborBlocks);
			int minionBaseTemplateId = 366 + DomainManager.World.GetXiangshuLevel();
			for (int i = 0; i < 3; i++)
			{
				short minionTemplateId = (short)Math.Clamp(context.Random.Next(minionBaseTemplateId - 1, minionBaseTemplateId + 2), 366, 374);
				DomainManager.Map.CreateTemporaryEnemiesOnValidBlocks(context, 0, Location.Invalid, minionTemplateId, 1, neighborBlocks);
			}
			context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		}
	}

	private void UseDivineFlameForShufang(DataContext context, bool isGood, int targetCharId, int date, Location targetLocation)
	{
		if (isGood)
		{
			DomainManager.World.GetInstantNotificationCollection().AddShufangGood(targetCharId);
		}
		else
		{
			DomainManager.World.GetInstantNotificationCollection().AddShufangBad(targetCharId);
		}
		List<int> charIdList = GetDivineFlameSelectTargetCharIdList(context, 8);
		foreach (int charId in charIdList)
		{
			GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(charId);
			short oldAge = targetChar.GetCurrAge();
			short newAge = (isGood ? ((short)(oldAge - 1)) : ((short)(oldAge + 1)));
			targetChar.SetCurrAge(newAge, context);
			Events.RaiseCharacterAgeChanged(context, targetChar, oldAge, newAge);
			if (isGood)
			{
				DomainManager.LifeRecord.GetLifeRecordCollection().AddShufangGood(charId, date, targetChar.GetValidLocation());
			}
			else
			{
				DomainManager.LifeRecord.GetLifeRecordCollection().AddShufangBad(charId, date, targetChar.GetValidLocation());
			}
			if (!isGood)
			{
				short newClothingTemplateId = -1;
				if (newAge == 16)
				{
					OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(targetChar.GetOrganizationInfo());
					newClothingTemplateId = OrganizationDomain.GetRandomOrgMemberClothing(context.Random, orgMemberCfg);
				}
				else if (newAge == GlobalConfig.Instance.AgeBaby)
				{
					newClothingTemplateId = 65;
				}
				if (newClothingTemplateId >= 0)
				{
					targetChar.ForceReplaceClothing(context, newClothingTemplateId);
				}
			}
		}
	}

	[DomainMethod]
	public DivineFlameData GetDivineFlameDisplayData()
	{
		return GetDivineFlameData();
	}

	[DomainMethod]
	public void GmCmd_ClearDivineFlameCooldown(DataContext context)
	{
		if (_divineFlameData != null)
		{
			_divineFlameData.SetCooldownDate(DomainManager.World.GetCurrDate());
			SetDivineFlameData(_divineFlameData, context);
		}
	}

	[DomainMethod]
	public void GmCmd_SetDivineFlameIsUnlocked(DataContext context, bool isUnlocked)
	{
		SetDivineFlameIsUnlocked(context, isUnlocked);
	}

	public void InvokeTwelveImmortalsIntoImpactRangeEvent(DataContext context, MapBlockData taiwuAtBlock)
	{
		foreach (TwelveImmortalsItem config in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			TwelveImmortalsStatus status = _twelveImmortalsStatuses[config.TemplateId];
			if (status != null && !status.AlreadyIntoImpactRange && DomainManager.Character.TryGetFixedCharacterByTemplateId(config.Character, out var character) && character.GetLocation().GetManhattanDistanceToPos(taiwuAtBlock.GetLocation()) <= config.ImpactRange)
			{
				status.AlreadyIntoImpactRange = true;
				SetElement_TwelveImmortalsStatuses(config.TemplateId, status, context);
				DomainManager.TaiwuEvent.OnEvent_FirstIntoTwelveImmortalsImpactRange(character.GetId());
			}
		}
	}

	public int CurrAliveTwelveImmortalsTotalCount()
	{
		int count = 0;
		foreach (TwelveImmortalsItem immortalCfg in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(immortalCfg.Character, out var character) && character.GetLocation().IsValid())
			{
				count++;
			}
		}
		return count;
	}

	public short GetTwelveImmortalsTemplateId(int characterId)
	{
		for (short i = 0; i < _twelveImmortalsStatuses.Length; i++)
		{
			TwelveImmortalsStatus twelveImmortals = _twelveImmortalsStatuses[i];
			if (twelveImmortals != null && twelveImmortals.CharacterId == characterId)
			{
				return i;
			}
		}
		return -1;
	}

	private List<short> GetCurrAliveTwelveImmortalsTemplateIdList(sbyte state)
	{
		bool needAlive = state == 0;
		List<short> result = new List<short>();
		foreach (TwelveImmortalsItem immortalCfg in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(immortalCfg.Character, out var character) && (!needAlive || character.GetLocation().IsValid()) && _twelveImmortalsStatuses[immortalCfg.TemplateId]?.AssistState == state)
			{
				result.Add(immortalCfg.TemplateId);
			}
		}
		return result;
	}

	public void SetTwelveImmortalsAssistState(DataContext context, short templateId, sbyte state)
	{
		TwelveImmortalsStatus immortals = _twelveImmortalsStatuses[templateId];
		immortals.AssistState = state;
		SetElement_TwelveImmortalsStatuses(templateId, immortals, context);
	}

	public short GetAssistTemplateId(DataContext context)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		if (!argBox.Contains<short>("MainStoryEndingLine"))
		{
			return -1;
		}
		short endingLine = argBox.GetShort("MainStoryEndingLine");
		IEnumerable<short> assistList = (from a in _twelveImmortalsStatuses
			where a != null && a.AssistState != 5
			select a.AssistCharacterTemplateId).Distinct();
		switch (endingLine)
		{
		case 0:
		{
			List<short> notUsedList2 = TwelveImmortalsConstants.DivineFlameAssistCharacters.Except(assistList).ToList();
			return notUsedList2.GetRandomOrDefault(context.Random, TwelveImmortalsConstants.DivineFlameAssistCharacters.First());
		}
		case 1:
		{
			List<short> notUsedList = IronPlateCharCombatTemplateIdList.Except(assistList).ToList();
			return notUsedList.GetRandomOrDefault(context.Random, IronPlateCharCombatTemplateIdList.First());
		}
		default:
			return -1;
		}
	}

	public void SetTwelveImmortalsAssistData(DataContext context, sbyte templateId)
	{
		short assistTemplateId = GetAssistTemplateId(context);
		TwelveImmortalsStatus twelveImmortals = _twelveImmortalsStatuses[templateId];
		twelveImmortals.AssistCharacterTemplateId = assistTemplateId;
		twelveImmortals.AssistState = 0;
		SetElement_TwelveImmortalsStatuses(templateId, twelveImmortals, context);
	}

	public int CreateNoMindGuy(DataContext context, GameData.Domains.Character.Character victim)
	{
		GameData.Domains.Character.Character noMindGuy = DomainManager.Character.DeepCopy(context, victim);
		noMindGuy.AddNoMindGuyFeature(context, resetAge: true);
		Location oldLoc = victim.GetLocation();
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		if (oldLoc != location)
		{
			noMindGuy.SetLocation(location, context);
		}
		Events.RaiseCharacterLocationChanged(context, noMindGuy.GetId(), (oldLoc != location) ? oldLoc : Location.Invalid, location);
		return noMindGuy.GetId();
	}

	private void AdvanceMonth_SectClearData(DataContext context)
	{
		SetSectMainStoryCombatTimesShaolin(0, context);
		_sectMainStoryLifeLinkUpdated = false;
		_storyStatus.Clear();
		_sectMainStoryTriggerRecord.Clear();
	}

	public bool CheckSectMainStoryTriggerRecord(short templateId)
	{
		return _sectMainStoryTriggerRecord.Contains(templateId);
	}

	public void AddSectMainStoryTriggerRecord(short templateId)
	{
		_sectMainStoryTriggerRecord.Add(templateId);
	}

	[DomainMethod]
	public int GetSectMainStoryActiveStatus(sbyte orgTemplateId)
	{
		bool flag = !GameData.ArchiveData.Common.IsInWorld();
		bool flag2 = flag;
		if (!flag2)
		{
			bool flag3 = ((orgTemplateId < 1 || orgTemplateId > 15) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return int.MinValue;
		}
		int[] taskChains = Config.Organization.Instance[orgTemplateId].SectMainStory.TaskChains;
		if (taskChains == null || taskChains.Length == 0)
		{
			return 2;
		}
		if (!CheckSectMainStoryAvailable(orgTemplateId) || _storyStatus.Contains(orgTemplateId))
		{
			return 1;
		}
		EventArgBox box = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		return box.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus") ? (-1) : 0;
	}

	public bool SectMainStoryTriggeredThisMonth(sbyte orgTemplateId)
	{
		return _storyStatus.Contains(orgTemplateId);
	}

	[DomainMethod]
	public void SetSectMainStoryActiveStatus(sbyte orgTemplateId, bool pause)
	{
		if (pause)
		{
			EventHelper.SaveArgToSectMainStory(orgTemplateId, "ConchShip_PresetKey_SectMainStoryTriggeringStatus", -1);
			if (orgTemplateId == 2 && EventHelper.GetSectMainStoryEventArgBox(orgTemplateId).Contains<short>(SectMainStoryEventArgKey.DefValue.WhiteApeBlockId))
			{
				EventHelper.ClearWhiteApeBlockId();
			}
		}
		else
		{
			EventHelper.RemoveArgFromSectMainStory<int>(orgTemplateId, "ConchShip_PresetKey_SectMainStoryTriggeringStatus");
			if (orgTemplateId == 2 && DomainManager.Organization.GetSettlementByOrgTemplateId(2).CalcApprovingRate() >= 500)
			{
				EventHelper.SaveWhiteApeBlockId();
			}
		}
	}

	[DomainMethod]
	public void NotifySectStoryActivated(DataContext context, sbyte orgTemplateId)
	{
		_storyStatus.Add(orgTemplateId);
		EventHelper.RemoveArgFromSectMainStory<int>(orgTemplateId, "ConchShip_PresetKey_SectMainStoryTriggeringStatus");
		SetSectMainStoryTaskStatus(context, orgTemplateId, GetSectMainStoryTaskStatus(orgTemplateId));
	}

	public sbyte GetSectMainStoryTaskStatus(sbyte orgTemplateId)
	{
		return _sectMainStoryTaskStatus[orgTemplateId - 1];
	}

	public void SetSectMainStoryTaskStatus(DataContext context, sbyte orgTemplateId, sbyte status)
	{
		switch (status)
		{
		case 1:
			DomainManager.Taiwu.RecordLifeSummary(context, 80);
			break;
		case 2:
			DomainManager.Taiwu.RecordLifeSummary(context, 81);
			break;
		}
		SetElement_SectMainStoryTaskStatus(orgTemplateId - 1, status, context);
	}

	public IReadOnlyList<sbyte> GetSectMainStoryTaskStatuses()
	{
		return _sectMainStoryTaskStatus;
	}

	public bool CheckSectMainStoryAvailable(sbyte orgTemplateId)
	{
		if (GetSectMainStoryTaskStatus(orgTemplateId) != 0)
		{
			return false;
		}
		sbyte sectIndex = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		SectMainStoryItem sectMainStoryCfg = Config.SectMainStory.Instance[sectIndex];
		if (!sectMainStoryCfg.IsReady())
		{
			return false;
		}
		for (int i = 0; i < sectMainStoryCfg.TaskChains.Length; i++)
		{
			if (DomainManager.World.IsExtraTaskChainInProgress(sectMainStoryCfg.TaskChains[i]))
			{
				return false;
			}
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		int date = int.MaxValue;
		if (argBox.Get(sectMainStoryCfg.GoodEndDateKey, ref date) || argBox.Get(sectMainStoryCfg.BadEndDateKey, ref date))
		{
			return false;
		}
		return true;
	}

	public void TriggerSectMainStoryEndingCountDown(DataContext context, sbyte orgTemplateId, bool isGoodEnding, int offsetMonthCount = 0)
	{
		if (GetSectMainStoryTaskStatus(orgTemplateId) != 0)
		{
			AdaptableLog.Warning("Sect main story for " + Config.Organization.Instance[orgTemplateId].Name + " is already finished.");
			return;
		}
		sbyte index = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		SectMainStoryItem sectMainStoryCfg = Config.SectMainStory.Instance[index];
		string argKey = (isGoodEnding ? sectMainStoryCfg.GoodEndDateKey : sectMainStoryCfg.BadEndDateKey);
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, orgTemplateId, argKey, currDate + offsetMonthCount);
	}

	public void ClearSectMainStoryEndingCountDown(DataContext context, sbyte orgTemplateId)
	{
		sbyte index = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		SectMainStoryItem sectMainStoryCfg = Config.SectMainStory.Instance[index];
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		argBox.Remove<int>(sectMainStoryCfg.GoodEndDateKey);
		argBox.Remove<int>(sectMainStoryCfg.BadEndDateKey);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, orgTemplateId);
	}

	public bool CheckSectMainStoryEndingCountDown(sbyte orgTemplateId, bool isGoodEnding, bool isReady)
	{
		sbyte index = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		SectMainStoryItem sectMainStoryCfg = Config.SectMainStory.Instance[index];
		string argKey = (isGoodEnding ? sectMainStoryCfg.GoodEndDateKey : sectMainStoryCfg.BadEndDateKey);
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		int date = 0;
		if (!argBox.Get(argKey, ref date))
		{
			return false;
		}
		int currDate = DomainManager.World.GetCurrDate();
		return isReady == currDate > date;
	}

	public bool TryTriggerSectMainStoryEndingMonthlyEvent(sbyte orgTemplateId)
	{
		sbyte index = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		if (_sectMainStoryTaskStatus[index] != 0)
		{
			return false;
		}
		int currDate = DomainManager.World.GetCurrDate();
		SectMainStoryItem sectMainStoryCfg = Config.SectMainStory.Instance[index];
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(orgTemplateId);
		int date = int.MaxValue;
		if (argBox.Get(sectMainStoryCfg.GoodEndDateKey, ref date) && currDate > date)
		{
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			MonthlyEventItem monthlyEventCfg = MonthlyEvent.Instance[sectMainStoryCfg.GoodEndingMonthlyEvent];
			monthlyEventCollection.AddAutoMonthlyEvent(argBox, monthlyEventCfg);
			return true;
		}
		date = int.MaxValue;
		if (argBox.Get(sectMainStoryCfg.BadEndDateKey, ref date) && currDate > date && sectMainStoryCfg.BadEndingMonthlyEvent >= 0)
		{
			MonthlyEventCollection monthlyEventCollection2 = DomainManager.World.GetMonthlyEventCollection();
			MonthlyEventItem monthlyEventCfg2 = MonthlyEvent.Instance[sectMainStoryCfg.BadEndingMonthlyEvent];
			monthlyEventCollection2.AddAutoMonthlyEvent(argBox, monthlyEventCfg2);
			return true;
		}
		return false;
	}

	public void OnAdvanceMonth(DataContext context)
	{
		OnAdvanceMonthMainStory(context);
		if (Config.SectMainStory.DefValue.Kongsang.IsReady())
		{
			AdvanceMonth_SectMainStory_Kongsang(context);
		}
		if (Config.SectMainStory.DefValue.Xuehou.IsReady())
		{
			AdvanceMonth_SectMainStory_Xuehou(context);
		}
		if (Config.SectMainStory.DefValue.Shaolin.IsReady())
		{
			AdvanceMonth_SectMainStory_Shaolin(context);
		}
		if (Config.SectMainStory.DefValue.Xuannv.IsReady())
		{
			AdvanceMonth_SectMainStory_Xuannv(context);
		}
		if (Config.SectMainStory.DefValue.Wudang.IsReady())
		{
			AdvanceMonth_SectMainStory_Wudang(context);
		}
		if (Config.SectMainStory.DefValue.Shixiang.IsReady())
		{
			AdvanceMonth_SectMainStory_Shixiang(context);
		}
		if (Config.SectMainStory.DefValue.Emei.IsReady())
		{
			AdvanceMonth_SectMainStory_Emei(context);
		}
		if (Config.SectMainStory.DefValue.Jingang.IsReady())
		{
			AdvanceMonth_SectMainStory_Jingang(context);
		}
		if (Config.SectMainStory.DefValue.Wuxian.IsReady())
		{
			AdvanceMonth_SectMainStory_Wuxian(context);
		}
		if (Config.SectMainStory.DefValue.Ranshan.IsReady())
		{
			AdvanceMonth_SectMainStory_Ranshan(context);
		}
		if (Config.SectMainStory.DefValue.Baihua.IsReady())
		{
			AdvanceMonth_SectMainStory_Baihua(context);
		}
		if (Config.SectMainStory.DefValue.Zhujian.IsReady())
		{
			AdvanceMonth_SectMainStory_Zhujian(context);
		}
		if (Config.SectMainStory.DefValue.Fulong.IsReady())
		{
			AdvanceMonth_SectMainStoryFulong(context);
		}
		if (Config.SectMainStory.DefValue.Jieqing.IsReady())
		{
			AdvanceMonth_SectMainStory_Common(context, 13);
		}
		DomainManager.Story.UpdateBaihuaLifeLinkNeiliType(context);
		DomainManager.Story.UpdateAreaMerchantType(context);
		DomainManager.Extra.UpdateThreeVitalsInfection(context);
		DomainManager.Extra.GearMateUpdateStatus(context);
		DomainManager.Extra.JieqingGameAdvanceMonth(context);
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 6, "EnteredShixiangDrumEasterEggThisMonth", value: false);
		if (DomainManager.Organization.GetSectFunctionStatus(13, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked) && context.Random.CheckPercentProb(GlobalConfig.Instance.GainExtraJieqingXingyunProbability))
		{
			int gain = context.Random.Next(GlobalConfig.Instance.GainExtraJieqingXingyunValueMinInclusive, GlobalConfig.Instance.GainExtraJieqingXingyunValueMaxExclusive);
			DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryJieqingUpgradeXingYun(DomainManager.Taiwu.GetTaiwuCharId(), gain);
			DomainManager.Extra.DirectlyAddExtraLegacyPoint(context, gain);
		}
	}

	private void AdvanceMonth_SectMainStory_Kongsang(DataContext context)
	{
		if (!DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(10) && DomainManager.Character.TryGetFixedCharacterByTemplateId(749, out var _))
		{
			int taskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(24);
			int num = taskInProgress;
			int num2 = num;
			if (num2 == 101)
			{
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 10, SectMainStoryEventArgKey.DefValue.MissionUnacceptedEventTriggeredSameMonth, value: true);
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Xuehou(DataContext context)
	{
		int xuehouTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(25);
		if (xuehouTaskInProgress < 0)
		{
			xuehouTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(26);
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int currDate = DomainManager.World.GetCurrDate();
		if (IsJixiFree())
		{
			bool needTrigger = false;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.NeedTriggerPassLegacyMonthlyNotification, ref needTrigger))
			{
				argBox.Set(SectMainStoryEventArgKey.DefValue.NeedTriggerPassLegacyMonthlyNotification, arg: false);
				TryTriggerXuehouJixiGone();
			}
		}
		if (xuehouTaskInProgress < 0)
		{
			DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(15);
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(15);
		Location settlementLocation = settlement.GetLocation();
		if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.JixiFollowOpen))
		{
			int awakeJixiTaiwuId = -1;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.AwakeJixiTaiwuId, ref awakeJixiTaiwuId) && taiwu.GetId() != awakeJixiTaiwuId)
			{
			}
		}
		switch (xuehouTaskInProgress)
		{
		case 115:
			if (AreaHasAdultGraveOfTargetOrganization(settlementLocation.AreaId, 15))
			{
				int date = int.MaxValue;
				if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.XuehouGraveDiggingEventTriggered))
				{
					monthlyEventCollection.AddSectMainStoryXuehouGraveDigging();
				}
				else if (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.XuehouGraveDiggingNormalTriggerTime) || (argBox.Get(SectMainStoryEventArgKey.DefValue.XuehouGraveDiggingNormalTriggerTime, ref date) && date + 6 <= currDate))
				{
					monthlyEventCollection.AddSectMainStoryXuehouGraveDiggingNormal();
				}
			}
			else
			{
				monthlyEventCollection.AddSectMainStoryXuehouStrangeDeath();
			}
			break;
		case 116:
		{
			int startDate2 = int.MaxValue;
			argBox.Get(SectMainStoryEventArgKey.DefValue.FirstGotBellTime, ref startDate2);
			if (taiwuLocation.AreaId == settlementLocation.AreaId && startDate2 + 3 <= currDate)
			{
				monthlyEventCollection.AddSectMainStoryXuehouOldManAppears();
			}
			break;
		}
		case 117:
		{
			int defeatXuehouOldManTime = int.MaxValue;
			if (!argBox.GetBool(SectMainStoryEventArgKey.DefValue.XuehouOldManGraveDisappearTriggered) && argBox.Get(SectMainStoryEventArgKey.DefValue.DefeatXuehouOldManTime, ref defeatXuehouOldManTime) && defeatXuehouOldManTime + 3 <= currDate)
			{
				monthlyEventCollection.AddSectMainStoryXuehouOldManReturns();
				break;
			}
			int startDate3 = int.MaxValue;
			if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.XuehouOldManGraveDisappearTriggered) || (argBox.Get(SectMainStoryEventArgKey.DefValue.GiveBellToXuehouOldManTime, ref startDate3) && startDate3 + 3 <= currDate))
			{
				GameData.Domains.Character.Character zombieOldMan2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 862);
				int zombieOldManId = zombieOldMan2.GetId();
				Location zombieOldManLocation2 = zombieOldMan2.GetLocation();
				DealXuehouOldManBell(zombieOldMan2);
				DomainManager.World.TriggerExtraTask(context, 25, 118);
				List<MapBlockData> blocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
				DomainManager.Map.GetSettlementAffiliatedBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blocks);
				Location destLocation = blocks.GetRandom(context.Random).GetLocation();
				context.AdvanceMonthRelatedData.Blocks.Release(ref blocks);
				Events.RaiseFixedCharacterLocationChanged(context, zombieOldManId, zombieOldManLocation2, destLocation);
				zombieOldMan2.SetLocation(destLocation, context);
			}
			break;
		}
		case 119:
		{
			List<Location> bloodLightLocationList = DomainManager.Extra.GetSectXuehouBloodLightLocations();
			if (bloodLightLocationList.Count > 0 && DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, settlement.GetId()))
			{
				GameData.Domains.Character.Character zombieOldMan = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 862);
				DealXuehouOldManBell(zombieOldMan);
				Location zombieOldManLocation = zombieOldMan.GetLocation();
				bool sameBlockAsOldManInRed = taiwuLocation.Equals(zombieOldManLocation);
				bool isOnBloodBlock = bloodLightLocationList.Contains(taiwuLocation);
				if (sameBlockAsOldManInRed && isOnBloodBlock)
				{
					monthlyEventCollection.AddSectMainStoryXuehouOnBloodBlock();
				}
				else if (sameBlockAsOldManInRed)
				{
					monthlyEventCollection.AddSectMainStoryXuehouOldManAttacks();
				}
			}
			break;
		}
		case 121:
			DealMonthlyEvent();
			break;
		case 122:
		{
			DealMonthlyEvent();
			bool result = DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, taiwuVillageSettlementId);
			short villagerCount = DomainManager.Taiwu.GetTotalAdultVillagerCount();
			if (result && villagerCount >= 3)
			{
				switch (argBox.GetInt(SectMainStoryEventArgKey.DefValue.JixiArrivedTaiwuMonthlyEventTriggeredCount))
				{
				case 0:
					monthlyEventCollection.AddSectMainStoryXuehouHarmoniousTaiwu();
					break;
				case 1:
					monthlyEventCollection.AddSectMainStoryXuehouFeedJixi();
					break;
				case 2:
					monthlyEventCollection.AddSectMainStoryXuehouMythInVillage();
					break;
				}
			}
			break;
		}
		case 123:
		{
			int coolTime = -1;
			if (!argBox.Get(SectMainStoryEventArgKey.DefValue.XuehouComingTime, ref coolTime))
			{
				argBox.Set(SectMainStoryEventArgKey.DefValue.XuehouComingTime, 3);
			}
			else
			{
				coolTime++;
			}
			argBox.Set(SectMainStoryEventArgKey.DefValue.XuehouComingTime, coolTime);
			int triggeredCount = -1;
			argBox.Get(SectMainStoryEventArgKey.DefValue.XuehouComingTriggeredCount, ref triggeredCount);
			if (coolTime >= 3 && triggeredCount < GetJixiFavorabilityType() - 1)
			{
				monthlyEventCollection.AddSectMainStoryXuehouComing();
				argBox.Set(SectMainStoryEventArgKey.DefValue.XuehouComingTime, 0);
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.XuehouComingTriggeredCount, ref triggeredCount))
				{
					argBox.Set(SectMainStoryEventArgKey.DefValue.XuehouComingTriggeredCount, 1);
				}
				else
				{
					argBox.Set(SectMainStoryEventArgKey.DefValue.XuehouComingTriggeredCount, triggeredCount + 1);
				}
			}
			if (TaiwuNotInVillageArea())
			{
				break;
			}
			if (JixiAdventureDisappear(3))
			{
				JixiGrowUp(context, 878, 879);
				DomainManager.World.TriggerExtraTask(context, 25, 130);
				DomainManager.World.FinishAllTaskInChain(context, 26);
			}
			else if (JixiAdventurePass(2, 0) || JixiAdventureDisappear(2))
			{
				if (JixiAdventureDisappear(2))
				{
					argBox.Set(SectMainStoryEventArgKey.DefValue.JixiAdventureTwoStartDate, int.MaxValue);
					JixiGrowUp(context, 877, 878);
				}
				if (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.JixiAdventureThreeStartDate) && (JixiAdventurePass(2, 3) || JixiAdventureDisappear(2)))
				{
					List<MapBlockData> validBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
					DomainManager.Map.GetMapBlocksInAreaByFilters(taiwuVillageLocation.AreaId, IsInTaiwuVillageRange, validBlocks);
					if (validBlocks.Count > 0)
					{
						MapBlockData block = validBlocks.GetRandom(context.Random);
						DomainManager.Adventure.GenerateMajorEvent(context, 838511810, block.GetLocation());
						argBox.Set(SectMainStoryEventArgKey.DefValue.JixiAdventureThreeStartDate, currDate);
					}
					context.AdvanceMonthRelatedData.Blocks.Release(ref validBlocks);
				}
				else
				{
					if (!argBox.GetBool(SectMainStoryEventArgKey.DefValue.JixiFeedChickenEventTriggered))
					{
						monthlyEventCollection.AddSectMainStoryXuehouJixiFeedChicken();
					}
					if (!argBox.GetBool(SectMainStoryEventArgKey.DefValue.JixiHarmVillagerEventTriggered))
					{
						monthlyEventCollection.AddSectMainStoryXuehouJixiKills();
					}
					else
					{
						monthlyEventCollection.AddSectMainStoryXuehouVillageWork();
					}
				}
			}
			else
			{
				if (!JixiAdventurePass(1, 0) && !JixiAdventureDisappear(1))
				{
					break;
				}
				if (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.JixiAdventureTwoStartDate) && (JixiAdventurePass(1, 3) || JixiAdventureDisappear(1)))
				{
					List<MapBlockData> validBlocks2 = context.AdvanceMonthRelatedData.Blocks.Occupy();
					DomainManager.Map.GetMapBlocksInAreaByFilters(taiwuVillageLocation.AreaId, IsInTaiwuVillageRange, validBlocks2);
					if (validBlocks2.Count > 0)
					{
						MapBlockData block2 = validBlocks2.GetRandom(context.Random);
						DomainManager.Adventure.GenerateMajorEvent(context, 849446568, block2.GetLocation());
						argBox.Set(SectMainStoryEventArgKey.DefValue.JixiAdventureTwoStartDate, currDate);
					}
					context.AdvanceMonthRelatedData.Blocks.Release(ref validBlocks2);
				}
				else if (!argBox.GetBool(SectMainStoryEventArgKey.DefValue.ProtectedJixiEventTriggered))
				{
					monthlyEventCollection.AddSectMainStoryXuehouProtectJixi();
				}
				else
				{
					monthlyEventCollection.AddSectMainStoryXuehouJixiAskForFood();
				}
			}
			break;
		}
		case 130:
			if (!TaiwuNotInVillageArea())
			{
				int passDate = int.MaxValue;
				int startDate = int.MaxValue;
				if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.CombatWithUltimateZombieTriggered) && ((argBox.Get(SectMainStoryEventArgKey.DefValue.JixiAdventureThreePassDate, ref passDate) && currDate >= passDate + 2) || (argBox.Get(SectMainStoryEventArgKey.DefValue.JixiAdventureThreeStartDate, ref startDate) && currDate >= startDate + 9 + 2)))
				{
					monthlyEventCollection.AddSectMainStoryXuehouFinale();
				}
				startDate = int.MaxValue;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.JixiAdventureFourStartDate, ref startDate) && currDate >= startDate + 6)
				{
					DomainManager.World.FinishTriggeredExtraTask(context, 25, 130);
					DomainManager.Story.SetSectMainStoryTaskStatus(context, 15, 1);
					DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 15, Config.SectMainStory.DefValue.Xuehou.GoodEndDateKey, currDate + 1);
					JixiGrowUp(context, 879, 877);
					GameData.Domains.Character.Character jixiBaby = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 877);
					Events.RaiseFixedCharacterLocationChanged(context, jixiBaby.GetId(), jixiBaby.GetLocation(), taiwuVillageLocation);
					jixiBaby.SetLocation(taiwuVillageLocation, context);
					MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
					monthlyNotifications.AddSectMainStoryXuehouJixiGoneFinal(taiwu.GetId());
				}
			}
			break;
		case 131:
			TryTriggerXuehouJixiGone();
			break;
		}
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 15);
		void DealMonthlyEvent()
		{
			int startDate4 = int.MaxValue;
			if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.XuehouEmptyCaveTriggered) && argBox.Get(SectMainStoryEventArgKey.DefValue.PassXuehouAdventure1Time, ref startDate4) && currDate >= startDate4 + 1)
			{
				monthlyEventCollection.AddSectMainStoryXuehouEmptyGrave();
			}
			else if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.XuehouFindPeopleTriggered) && argBox.Get(SectMainStoryEventArgKey.DefValue.PassXuehouAdventure1Time, ref startDate4) && currDate >= startDate4 + 2)
			{
				monthlyEventCollection.AddSectMainStoryXuehouLookingForTaiwu(taiwu.GetId());
			}
		}
		void DealXuehouOldManBell(GameData.Domains.Character.Character oldMan)
		{
			bool hasBell = false;
			if (argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.XuehouOldManHasBell) && argBox.Get(SectMainStoryEventArgKey.DefValue.XuehouOldManHasBell, ref hasBell))
			{
				ItemKey bell = DomainManager.Item.CreateItem(context, 12, 371);
				oldMan.AddInventoryItem(context, bell, 1);
			}
		}
		bool IsInTaiwuVillageRange(MapBlockData blockData)
		{
			if (blockData.GetConfig().TemplateId == 124)
			{
				return false;
			}
			if (DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(blockData.GetLocation()))
			{
				return false;
			}
			ByteCoordinate villagePos = DomainManager.Map.GetBlockData(taiwuVillageLocation.AreaId, taiwuVillageLocation.BlockId).GetBlockPos();
			return blockData.GetManhattanDistanceToPos(villagePos.X, villagePos.Y) == 3;
		}
		bool TaiwuNotInVillageArea()
		{
			return !DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, taiwuVillageSettlementId);
		}
		void TryTriggerXuehouJixiGone()
		{
			if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.PassLegacyMonthlyNotificationTriggered))
			{
				int awakeJixiTaiwuId2 = -1;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.AwakeJixiTaiwuId, ref awakeJixiTaiwuId2))
				{
					argBox.Set(SectMainStoryEventArgKey.DefValue.PassLegacyMonthlyNotificationTriggered, arg: true);
					if (DomainManager.Character.IsCharacterAlive(awakeJixiTaiwuId2))
					{
						DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryXuehouJixiGoneAgain();
					}
					else
					{
						DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryXuehouJixiGone();
					}
					GameData.Domains.Character.Character character = TryGetJixi();
					if (character != null)
					{
						DomainManager.Character.JixiMovementChangeLocation(context, character, new Location(137, DomainManager.Map.GetAreaBlocks(137).ToArray().GetRandom(context.Random)
							.BlockId));
					}
				}
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Shaolin(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int currDate = DomainManager.World.GetCurrDate();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		Location taiwuLocation = taiwu.GetLocation();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(1);
		int shaolinTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(27);
		int prevTaiwuCharId = -1;
		bool isTaiwuChanged = argBox.Get(SectMainStoryEventArgKey.DefValue.DamoDreamMeetTaiwuId, ref prevTaiwuCharId) && prevTaiwuCharId != taiwuCharId;
		DomainManager.Story.UpdateWordlessStatus(context);
		int num = shaolinTaskInProgress;
		int num2 = num;
		if (num2 >= 0)
		{
			switch (num2)
			{
			case 139:
			{
				if (isTaiwuChanged)
				{
					break;
				}
				int prevDate = 0;
				bool isFirstTime = !argBox.Get(SectMainStoryEventArgKey.DefValue.ShaolinMonthlyEventNotEnoughDate, ref prevDate);
				int expectedGradeGroup = Math.Clamp(argBox.GetInt(SectMainStoryEventArgKey.DefValue.ShaolinDamoFightTimes), 0, 2);
				int cooldown = ((expectedGradeGroup == 2) ? 6 : 3);
				sbyte combatSkillType = -1;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.ShaolinCombatSkillType, ref combatSkillType) || combatSkillType < 0)
				{
					break;
				}
				IReadOnlyList<CombatSkillItem> learnableCombatSkills = CombatSkillDomain.GetLearnableCombatSkills(1, combatSkillType);
				Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedSkills = DomainManager.CombatSkill.GetCharCombatSkills(taiwu.GetId());
				foreach (CombatSkillItem combatSkillCfg in learnableCombatSkills)
				{
					sbyte group = CombatSkillDomain.GetCombatSkillGradeGroup(combatSkillCfg.Grade, 1, combatSkillType);
					if (group != expectedGradeGroup || (learnedSkills.TryGetValue(combatSkillCfg.TemplateId, out var combatSkill) && CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState())))
					{
						continue;
					}
					if (isFirstTime)
					{
						monthlyEventCollection.AddSectMainStoryShaolinNotEnough();
					}
					else if (prevDate + cooldown <= currDate)
					{
						monthlyEventCollection.AddSectMainStoryShaolinNotEnoughCommon();
					}
					return;
				}
				if (expectedGradeGroup == 2)
				{
					AddEndChallengeMonthlyEvent();
				}
				else
				{
					AddChallengeMonthlyEvent();
				}
				break;
			}
			case 140:
				if (!isTaiwuChanged)
				{
					if (argBox.GetInt(SectMainStoryEventArgKey.DefValue.ShaolinDamoFightTimes) >= 2)
					{
						AddEndChallengeMonthlyEvent();
					}
					else
					{
						AddChallengeMonthlyEvent();
					}
				}
				break;
			case 142:
			{
				if (isTaiwuChanged)
				{
					break;
				}
				int offCooldownDate = 0;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.ShaolinStudyForBodhidharmaChallenge, ref offCooldownDate) || offCooldownDate <= currDate)
				{
					if (argBox.GetInt(SectMainStoryEventArgKey.DefValue.ShaolinDamoFightTimes) >= 2)
					{
						AddEndChallengeMonthlyEvent();
					}
					else
					{
						AddChallengeMonthlyEvent();
					}
				}
				break;
			}
			case 144:
			{
				if (isTaiwuChanged)
				{
					break;
				}
				short lifeSkillTemplateId = -1;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.ShaolinReadingMaxGradeSutra, ref lifeSkillTemplateId) || lifeSkillTemplateId < 0)
				{
					break;
				}
				int lifeSkillIndex = taiwu.FindLearnedLifeSkillIndex(lifeSkillTemplateId);
				if (lifeSkillIndex < 0)
				{
					break;
				}
				List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills = taiwu.GetLearnedLifeSkills();
				if (learnedLifeSkills[lifeSkillIndex].GetReadPagesCount() >= 3)
				{
					if (LifeSkill.Instance[lifeSkillTemplateId].Grade == 8)
					{
						monthlyEventCollection.AddSectMainStoryShaolinEnlightenment();
					}
					else
					{
						monthlyEventCollection.AddSectMainStoryShaolinLearning();
					}
				}
				break;
			}
			case 141:
			case 143:
				break;
			}
		}
		else if (DomainManager.Story.GetSectMainStoryTaskStatus(1) == 0 && !DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(1))
		{
			Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(1);
			if (sect.GetTaiwuExploreStatus() != 0 && taiwuLocation.IsValid() && DomainManager.Map.GetBlock(taiwuLocation).BlockSubType == EMapBlockSubType.ShaolinPai && DomainManager.Story.CheckSectMainStoryAvailable(1) && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus"))
			{
				monthlyEventCollection.AddSectMainStoryShaolinTowerFalling();
			}
		}
		void AddChallengeMonthlyEvent()
		{
			if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.ShaolinDamoTrialTriggered))
			{
				monthlyEventCollection.AddSectMainStoryShaolinChallengeCommon();
			}
			else
			{
				monthlyEventCollection.AddSectMainStoryShaolinChallenge();
			}
		}
		void AddEndChallengeMonthlyEvent()
		{
			if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.ShaolinLearnedAny))
			{
				if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.ShaolinDamoFightTriggered))
				{
					monthlyEventCollection.AddSectMainStoryShaolinEndChallengeCommon();
				}
				else
				{
					monthlyEventCollection.AddSectMainStoryShaolinEndChallenge();
				}
			}
			else if (argBox.GetBool(SectMainStoryEventArgKey.DefValue.ShaolinDamoFightTriggered))
			{
				monthlyEventCollection.AddSectMainStoryShaolinNeverLearnChallengeCommon();
			}
			else
			{
				monthlyEventCollection.AddSectMainStoryShaolinNeverLearnChallenge();
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Xuannv(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		Location taiwuLocation = taiwu.GetLocation();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(8);
		int xuannvTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(28);
		if (DomainManager.Character.GetOutterWorldCharacter() >= 0)
		{
			DomainManager.World.GetMonthlyEventCollection().AddBackFromOuterWorlds(DomainManager.Character.GetOutterWorldCharacter());
		}
		if (xuannvTaskInProgress < 0 && DomainManager.Story.GetSectMainStoryTaskStatus(8) == 0 && !DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(8))
		{
			Sect sect = (Sect)DomainManager.Organization.GetSettlementByOrgTemplateId(8);
			if (sect.GetTaiwuExploreStatus() != 0 && taiwuLocation.IsValid() && DomainManager.Map.GetBlock(taiwuLocation).BlockSubType == EMapBlockSubType.XuannvPai && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus"))
			{
				monthlyEventCollection.AddSectMainStoryXuannvPrologue();
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Wudang(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		GameData.Domains.Character.Character character;
		bool notInProgress = !DomainManager.Character.TryGetFixedCharacterByTemplateId(633, out character) || DomainManager.Story.GetSectMainStoryTaskStatus(4) != 0;
		List<SectStoryHeavenlyTreeExtendable> trees = DomainManager.Extra.GetAllHeavenlyTrees();
		int newEnemyCount = 0;
		foreach (SectStoryHeavenlyTreeExtendable tree in trees)
		{
			GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(tree.Id);
			short templateId = character2.GetTemplateId();
			if (templateId == 602 && (ItemTemplateHelper.CheckIsHeavenlyNormalTreeSeeds(12, tree.TemplateId) || notInProgress))
			{
				monthlyEventCollection.AddSectMainStoryWudangHeavenlyTreeDestroyed2(tree.Location);
			}
			else if (tree.Location.IsValid() && templateId != 602 && ItemTemplateHelper.CheckIsHeavenlyNormalTreeSeeds(12, tree.TemplateId))
			{
				newEnemyCount += XiangshuMinionsProtectWudangHeavenlyTree(context, tree, normalTree: true);
			}
		}
		if (newEnemyCount > 0)
		{
			monthlyEventCollection.AddSectMainStoryWudangProtectHeavenlyTree2();
		}
		if (DomainManager.Story.GetSectMainStoryTaskStatus(4) != 0)
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		Location taiwuLocation = taiwu.GetLocation();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(4);
		bool triggerTreeMonthlyNotification = false;
		if (DomainManager.World.IsExtraTaskChainInProgress(36))
		{
			if (DomainManager.World.IsExtraTaskInProgress(174))
			{
				List<SectStoryHeavenlyTreeExtendable> trees2 = DomainManager.Extra.GetAllHeavenlyTrees();
				int newEnemyCount2 = 0;
				foreach (SectStoryHeavenlyTreeExtendable tree2 in trees2)
				{
					if (!ItemTemplateHelper.CheckIsHeavenlyNormalTreeSeeds(12, tree2.TemplateId))
					{
						GameData.Domains.Character.Character character3 = DomainManager.Character.GetElement_Objects(tree2.Id);
						short templateId2 = character3.GetTemplateId();
						if (tree2.Location.IsValid() && templateId2 != 602)
						{
							newEnemyCount2 += XiangshuMinionsProtectWudangHeavenlyTree(context, tree2, normalTree: false);
						}
					}
				}
				if (newEnemyCount2 > 0)
				{
					monthlyEventCollection.AddSectMainStoryWudangProtectHeavenlyTree();
				}
			}
			if (DomainManager.World.IsExtraTaskInProgress(172))
			{
				List<SectStoryHeavenlyTreeExtendable> trees3 = DomainManager.Extra.GetAllHeavenlyTrees();
				foreach (SectStoryHeavenlyTreeExtendable tree3 in trees3)
				{
					if (tree3.Location.IsValid() && !ItemTemplateHelper.CheckIsHeavenlyNormalTreeSeeds(12, tree3.TemplateId) && !tree3.MetInDream && tree3.GrowPoint >= 900)
					{
						monthlyEventCollection.AddSectMainStoryWudangMeetingImmortal(taiwuCharId, taiwu.GetValidLocation(), tree3.Id, tree3.Location);
					}
				}
			}
			TriggerTreeMonthlyNotification();
		}
		int wudangTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(29);
		if (wudangTaskInProgress < 0)
		{
			DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(4);
		}
		else
		{
			TriggerTreeMonthlyNotification();
		}
		void TriggerTreeMonthlyNotification()
		{
			if (!triggerTreeMonthlyNotification)
			{
				List<SectStoryHeavenlyTreeExtendable> trees4 = DomainManager.Extra.GetAllHeavenlyTrees();
				if (trees4 != null)
				{
					foreach (SectStoryHeavenlyTreeExtendable tree4 in trees4)
					{
						short templateId3 = DomainManager.Extra.GetHeavenlyTreeTemplateIdByGrowValue(tree4.GrowPoint);
						if (templateId3 == 602)
						{
							GameData.Domains.Character.Character character4 = DomainManager.Character.GetElement_Objects(tree4.Id);
							if (ItemTemplateHelper.CheckIsHeavenlyNormalTreeSeeds(12, tree4.TemplateId))
							{
								DomainManager.World.GetMonthlyNotificationCollection().AddNormalTreesGrow(character4.GetLocation());
							}
							else
							{
								DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryWudangTreesGrow(character4.GetLocation());
							}
						}
					}
				}
				triggerTreeMonthlyNotification = true;
			}
		}
	}

	private int XiangshuMinionsProtectWudangHeavenlyTree(DataContext context, SectStoryHeavenlyTreeExtendable tree, bool normalTree)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		Location treeLocation = tree.Location;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(treeLocation.AreaId);
		List<MapTemplateEnemyInfo> movingEnemyList = new List<MapTemplateEnemyInfo>();
		List<GameData.Domains.Character.Character> villagerList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		List<Location> path = ObjectPool<List<Location>>.Instance.Get();
		List<MapTemplateEnemyInfo> blockEnemyList = new List<MapTemplateEnemyInfo>();
		bool isTreeDestroyed = false;
		movingEnemyList.Clear();
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.TemplateEnemyList == null)
			{
				continue;
			}
			Location location = block.GetLocation();
			blockEnemyList.Clear();
			foreach (MapTemplateEnemyInfo mapTemplateEnemy in block.TemplateEnemyList)
			{
				if (mapTemplateEnemy.SourceAdventureBlockId == treeLocation.BlockId)
				{
					blockEnemyList.Add(mapTemplateEnemy);
				}
			}
			if (blockEnemyList.Count == 0)
			{
				continue;
			}
			villagerList.Clear();
			if (block.CharacterSet != null)
			{
				foreach (int charId in block.CharacterSet)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					OrganizationInfo orgInfo = character.GetOrganizationInfo();
					if (orgInfo.OrgTemplateId == 16 && orgInfo.Grade != 8 && DomainManager.Taiwu.TryGetElement_VillagerWork(charId, out var work) && work.AreaId == location.AreaId && work.BlockId == location.BlockId)
					{
						villagerList.Add(character);
					}
				}
			}
			if (villagerList.Count > 0)
			{
				int injuredCount = 0;
				foreach (GameData.Domains.Character.Character villager in villagerList)
				{
					if (blockEnemyList.Count <= 0)
					{
						break;
					}
					int blockedEnemyIndex = context.Random.Next(blockEnemyList.Count);
					blockEnemyList.RemoveAt(blockedEnemyIndex);
					villager.ChangeHealth(context, -60);
					injuredCount++;
					if (villager.GetHealth() > 0)
					{
						continue;
					}
					LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
					if (DomainManager.Extra.IsCharacterDying(villager.GetId()))
					{
						DomainManager.Character.MakeCharacterDead(context, villager, 15);
						lifeRecordCollection.AddSectMainStoryWudangVillagerKilled(villager.GetId(), DomainManager.World.GetCurrDate(), villager.GetLocation());
						if (!normalTree)
						{
							monthlyNotifications.AddSectMainStoryWudangVillagerCasualty(villager.GetId(), villager.GetLocation());
						}
						else
						{
							monthlyNotifications.AddNormalVillagerCasualty(villager.GetId(), villager.GetLocation());
						}
					}
					else
					{
						DomainManager.Extra.AddDyingCharacters(context, villager.GetId(), 15);
						lifeRecordCollection.AddSectMainStoryWudangInjured(villager.GetId(), DomainManager.World.GetCurrDate(), villager.GetLocation());
					}
				}
				if (injuredCount > 0)
				{
					if (!normalTree)
					{
						monthlyNotifications.AddSectMainStoryWudangVillagersInjured(injuredCount);
					}
					else
					{
						monthlyNotifications.AddNormalVillagersInjured(injuredCount);
					}
				}
			}
			movingEnemyList.AddRange(blockEnemyList);
		}
		foreach (MapTemplateEnemyInfo enemy in movingEnemyList)
		{
			if (enemy.SourceAdventureBlockId != treeLocation.BlockId || Config.Character.Instance[enemy.TemplateId].OrganizationInfo.OrgTemplateId != 19)
			{
				continue;
			}
			Location location2 = new Location(treeLocation.AreaId, enemy.BlockId);
			MapDomain.GetPathInAreaWithoutCost(location2, treeLocation, path);
			Location nextLocation = ((path.Count > 2) ? path[1] : treeLocation);
			Events.RaiseTemplateEnemyLocationChanged(context, enemy, location2, nextLocation);
			if (nextLocation != treeLocation)
			{
				continue;
			}
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			Location taiwuLocation = taiwu.GetLocation();
			if (taiwuLocation == nextLocation)
			{
				MapBlockData block2 = DomainManager.Map.GetBlock(taiwuLocation);
				if (block2.TemplateEnemyList == null || block2.TemplateEnemyList.Count == 0)
				{
					continue;
				}
				bool triggered = false;
				foreach (MapTemplateEnemyInfo templateEnemy in block2.TemplateEnemyList)
				{
					CharacterItem template = Config.Character.Instance[templateEnemy.TemplateId];
					if (template.OrganizationInfo.OrgTemplateId != 19 || templateEnemy.SourceAdventureBlockId != treeLocation.BlockId)
					{
						continue;
					}
					if (!normalTree)
					{
						monthlyEventCollection.AddSectMainStoryWudangGuardHeavenlyTree(taiwu.GetId(), taiwuLocation);
					}
					else
					{
						monthlyEventCollection.AddNormalGuardHeavenlyTree(taiwu.GetId(), taiwuLocation);
					}
					triggered = true;
					break;
				}
				if (!triggered)
				{
					continue;
				}
				break;
			}
			if (!normalTree)
			{
				monthlyEventCollection.AddSectMainStoryWudangHeavenlyTreeDestroyed(treeLocation);
			}
			else
			{
				monthlyEventCollection.AddNormalHeavenlyTreeDestroyed(treeLocation);
			}
			isTreeDestroyed = true;
			break;
		}
		ObjectPool<List<Location>>.Instance.Return(path);
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(villagerList);
		if (!isTreeDestroyed && !normalTree)
		{
			short xiangshuMinionTemplateId = (short)(366 + DomainManager.World.GetXiangshuLevel());
			if (xiangshuMinionTemplateId > 374)
			{
				xiangshuMinionTemplateId = 374;
			}
			List<MapBlockData> blocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
			DomainManager.Map.GetLocationByDistance(treeLocation, 3, 3, ref blocks);
			MapBlockData targetBlock = blocks.GetRandom(context.Random);
			context.AdvanceMonthRelatedData.Blocks.Release(ref blocks);
			targetBlock.AddTemplateEnemy(MapTemplateEnemyInfo.CreateFromHeavenlyTree(xiangshuMinionTemplateId, targetBlock.BlockId, treeLocation.BlockId));
			return 1;
		}
		if (!isTreeDestroyed && normalTree)
		{
			List<MapBlockData> blockDataList = ObjectPool<List<MapBlockData>>.Instance.Get();
			DomainManager.Map.GetRealNeighborBlocks(treeLocation.AreaId, treeLocation.BlockId, blockDataList, 3);
			MapBlockData centerBlockData = DomainManager.Map.GetBlockData(treeLocation.AreaId, treeLocation.BlockId);
			blockDataList.Add(centerBlockData);
			bool flag = false;
			foreach (MapBlockData blockData in blockDataList)
			{
				if (blockData.TemplateEnemyList == null || blockData.TemplateEnemyList.Count <= 0)
				{
					continue;
				}
				foreach (MapTemplateEnemyInfo templateEnemy2 in blockData.TemplateEnemyList)
				{
					if (templateEnemy2.SourceAdventureBlockId == treeLocation.BlockId)
					{
						ObjectPool<List<MapBlockData>>.Instance.Return(blockDataList);
						return 1;
					}
				}
			}
			ObjectPool<List<MapBlockData>>.Instance.Return(blockDataList);
		}
		return 0;
	}

	private void AdvanceMonth_SectMainStory_Shixiang(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int currDate = DomainManager.World.GetCurrDate();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(6);
		int shixiangTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(31);
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(6);
		Location settlementLocation = settlement.GetLocation();
		if (DomainManager.Story.GetSectMainStoryTaskStatus(6) == 0 && DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(6))
		{
			DomainManager.Organization.SetSectFunctionStatus(context, 6, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked, value: true);
		}
		if ((uint)(shixiangTaskInProgress - 187) <= 5u)
		{
			AddInteractWithShixiangMemberEvent();
		}
		switch (shixiangTaskInProgress)
		{
		case 185:
		case 186:
		{
			int nextDate = 0;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.ShixiangAdventureAppearDate, ref nextDate) && currDate < nextDate)
			{
				break;
			}
			foreach (AdventureMajorEvent majorEvent in DomainManager.Adventure.QueryMajorEventsInArea(settlementLocation.AreaId))
			{
				if (majorEvent.CoreId == 1178223083)
				{
					return;
				}
			}
			List<short> blockIds = context.AdvanceMonthRelatedData.BlockIds.Occupy();
			DomainManager.Map.GetSettlementBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
			short adventureBlockId = blockIds.GetRandom(context.Random);
			context.AdvanceMonthRelatedData.BlockIds.Release(ref blockIds);
			Location location = new Location(settlementLocation.AreaId, adventureBlockId);
			DomainManager.Adventure.GenerateMajorEvent(context, 1178223083, location);
			DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryShixiangAdventure();
			DomainManager.World.TriggerExtraTask(context, 31, 186);
			break;
		}
		case 192:
			if (DomainManager.Story.ShixiangSettlementAffiliatedBlocksHasEnemy(context, 681))
			{
				int startDate = 0;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.StartFightShixiangTraitorsDate, ref startDate) && currDate >= startDate + 36)
				{
					monthlyEventCollection.AddSectMainStoryShixiangEnemyAttack2();
				}
			}
			break;
		case 193:
		{
			sbyte shixiangMemberKillCount = argBox.GetSbyte(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount2);
			int count = shixiangMemberKillCount / 10;
			if (count > 0)
			{
				monthlyEventCollection.AddSectMainStoryShixiangGoodNews();
				shixiangMemberKillCount -= (sbyte)(count * 10);
				argBox.Set(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount2, shixiangMemberKillCount);
			}
			sbyte taiwuKillCount = argBox.GetSbyte(SectMainStoryEventArgKey.DefValue.TaiwuKillBarbarianMasterCount2);
			count = taiwuKillCount / 10;
			if (count > 0)
			{
				monthlyEventCollection.AddSectMainStoryShixiangGoodNews2();
				taiwuKillCount -= (sbyte)(count * 10);
				argBox.Set(SectMainStoryEventArgKey.DefValue.TaiwuKillBarbarianMasterCount2, taiwuKillCount);
			}
			EnemyClear();
			break;
		}
		case 194:
			EnemyClear();
			break;
		}
		void AddInteractWithShixiangMemberEvent()
		{
			if (taiwuLocation.IsValid())
			{
				IRandomSource random = context.Random;
				Span<sbyte> actionOrder = stackalloc sbyte[3] { 0, 1, 2 };
				MapBlockData block = DomainManager.Map.GetBlock(taiwuLocation);
				if (block.CharacterSet != null)
				{
					CharacterMatcherItem matcher = CharacterMatcher.DefValue.InteractWithShixiangMemberEventTarget;
					foreach (int charId in block.CharacterSet)
					{
						GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
						if (matcher.Match(character) && !context.Random.CheckPercentProb(30))
						{
							CollectionUtils.Shuffle(random, actionOrder, actionOrder.Length);
							Span<sbyte> span = actionOrder;
							for (int i = 0; i < span.Length; i++)
							{
								sbyte actionType = span[i];
								if (1 == 0)
								{
								}
								bool flag = actionType switch
								{
									0 => TryAddChallengeEvent(character), 
									1 => TryAddRequestBookEvent(character), 
									2 => TryAddLearnSkillEvent(character), 
									_ => false, 
								};
								if (1 == 0)
								{
								}
								if (flag)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
		void EnemyClear()
		{
			if (!DomainManager.Story.ShixiangSettlementAffiliatedBlocksHasEnemy(context, 686))
			{
				DomainManager.World.TriggerExtraTask(context, 31, 195);
				monthlyEventCollection.AddSectMainStoryShixiangLetterFrom2(taiwu.GetId());
				DomainManager.Extra.RemoveArgToSectMainStoryEventArgBox<bool>(context, 6, SectMainStoryEventArgKey.DefValue.ShixiangToFightEnemy);
			}
		}
		bool TryAddChallengeEvent(GameData.Domains.Character.Character shixiangMember)
		{
			monthlyEventCollection.AddSectMainStoryShixiangDuel(shixiangMember.GetId(), taiwuLocation, taiwu.GetId());
			return true;
		}
		bool TryAddLearnSkillEvent(GameData.Domains.Character.Character shixiangMember)
		{
			List<GameData.Domains.Character.LifeSkillItem> taiwuLifeSkills = taiwu.GetLearnedLifeSkills();
			List<GameData.Domains.Character.LifeSkillItem> charLifeSkills = shixiangMember.GetLearnedLifeSkills();
			Inventory inventory = shixiangMember.GetInventory();
			List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
			foreach (var (itemKey2, amount) in inventory.Items)
			{
				if (itemKey2.ItemType == 10)
				{
					SkillBookItem bookCfg = Config.SkillBook.Instance[itemKey2.TemplateId];
					if (bookCfg.ItemSubType == 1000)
					{
						sbyte lifeSkillType = bookCfg.LifeSkillType;
						if ((uint)lifeSkillType <= 3u)
						{
							int charSkillIndex = shixiangMember.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
							if (charSkillIndex < 0 || !charLifeSkills[charSkillIndex].IsAllPagesRead())
							{
								int taiwuSkillIndex = taiwu.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
								if (taiwuSkillIndex >= 0 && taiwuLifeSkills[taiwuSkillIndex].IsAllPagesRead())
								{
									itemKeys.Add(itemKey2);
								}
							}
						}
					}
				}
			}
			ItemKey selectedBookKey = itemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
			context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
			if (!selectedBookKey.IsValid())
			{
				return false;
			}
			monthlyEventCollection.AddSectMainStoryShixiangRequestLifeSkill(shixiangMember.GetId(), taiwuLocation, (ulong)selectedBookKey, taiwu.GetId());
			return true;
		}
		bool TryAddRequestBookEvent(GameData.Domains.Character.Character shixiangMember)
		{
			Inventory taiwuInventory = taiwu.GetInventory();
			List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
			foreach (var (itemKey2, amount) in taiwuInventory.Items)
			{
				if (itemKey2.ItemType == 10)
				{
					SkillBookItem bookCfg = Config.SkillBook.Instance[itemKey2.TemplateId];
					if (bookCfg.ItemSubType == 1000)
					{
						sbyte lifeSkillType = bookCfg.LifeSkillType;
						if ((uint)lifeSkillType <= 3u)
						{
							int learnedLifeSkillIndex = shixiangMember.FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
							if (learnedLifeSkillIndex < 0)
							{
								itemKeys.Add(itemKey2);
							}
						}
					}
				}
			}
			ItemKey selectedBookKey = itemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
			context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
			if (!selectedBookKey.IsValid())
			{
				return false;
			}
			monthlyEventCollection.AddSectMainStoryShixiangRequestBook(shixiangMember.GetId(), taiwuLocation, (ulong)selectedBookKey, taiwu.GetId());
			return true;
		}
	}

	private void AdvanceMonth_SectMainStory_Emei(DataContext context)
	{
		if (DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(2))
		{
			return;
		}
		if (DomainManager.Story.GetSectMainStoryTaskStatus(2) != 0)
		{
			GameData.Domains.Character.Character gibbon = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 562);
			if (!gibbon.GetLocation().Equals(Location.Invalid))
			{
				return;
			}
			List<MapBlockData> blockDataList = ObjectPool<List<MapBlockData>>.Instance.Get();
			Location location = DomainManager.Organization.GetSettlementByOrgTemplateId(2).GetLocation();
			DomainManager.Map.GetLocationByDistance(location, 5, 7, ref blockDataList);
			MapBlockMatcherItem matcher = MapBlockMatcher.DefValue.NonDevelopedNaturalNoEffectAndAdventure;
			for (int i = blockDataList.Count - 1; i >= 0; i--)
			{
				if (!matcher.Match(blockDataList[i]))
				{
					CollectionUtils.SwapAndRemove(blockDataList, i);
				}
			}
			MapBlockData selectedBlock = blockDataList.GetRandomOrDefault(context.Random, null);
			if (selectedBlock != null)
			{
				Events.RaiseFixedCharacterLocationChanged(context, gibbon.GetId(), gibbon.GetLocation(), selectedBlock.GetLocation());
				gibbon.SetLocation(selectedBlock.GetLocation(), context);
			}
			ObjectPool<List<MapBlockData>>.Instance.Return(blockDataList);
		}
		else
		{
			EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
			Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
			int currDate = DomainManager.World.GetCurrDate();
			int triggerDate = argBox.GetInt(SectMainStoryEventArgKey.DefValue.EmeiStrangerTriggerDate);
			if (taiwuLocation.IsValid() && DomainManager.Map.GetAreaByAreaId(taiwuLocation.AreaId).GetConfig().TemplateId == 2 && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus") && !DomainManager.World.IsTaskInProgress(710) && !DomainManager.World.IsTaskFinished(710) && currDate - triggerDate >= 3)
			{
				MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
				monthlyNotifications.AddSectMainStoryEmeiStrangerAttack();
				argBox.Set(SectMainStoryEventArgKey.DefValue.EmeiStrangerTriggerDate, currDate);
				DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 2);
			}
			if (taiwuLocation.IsValid() && EMeiMainStoryTrigger0() && EMeiMainStoryTrigger1() && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus") && !argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.EmeiFirstMonthlyEventTriggered))
			{
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				monthlyEventCollection.AddSectMainStoryEmeiBeginning();
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Jingang(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(11) != 0)
		{
			return;
		}
		int jingangTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(32);
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetValidLocation();
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(11);
		int date = int.MaxValue;
		if (argBox.Get(SectMainStoryEventArgKey.DefValue.JingangMonkMurderedTriggeredDate, ref date) && currDate >= date + 2)
		{
			monthlyNotificationCollection.AddSectMainStoryJingangWrongdoing();
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangMonkMurderedTriggeredDate, currDate);
		}
		int num = jingangTaskInProgress;
		int num2 = num;
		if (num2 >= 0)
		{
			switch (num2)
			{
			case 200:
			{
				sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwu.GetValidLocation().AreaId);
				if (stateTemplateId == 11 && taiwu.GetFeatureIds().Contains(739))
				{
					monthlyNotificationCollection.AddSectMainStoryJingangHaunted(taiwu.GetId());
				}
				break;
			}
			case 201:
				monthlyNotificationCollection.AddSectMainStoryJingangFollowedByGhost(taiwu.GetId());
				break;
			case 205:
			{
				int stage = DomainManager.Story.JingangSpreadSecInfoStage();
				if (stage < 0)
				{
					DomainManager.Information.FixLackOfJingangInformation(context);
				}
				int secretId = DomainManager.Information.FixOrGetLackOfJingangInformation(context);
				if (DomainManager.Story.JingangKnowSecInfoCount() <= 0)
				{
					SecretOccurence secretOccurence = DomainManager.Information.QuerySecretOccurence((SecretInformationId)secretId);
					if (secretOccurence == null || !secretOccurence.InBroadcast)
					{
						break;
					}
				}
				monthlyEventCollection.AddSectMainStoryJingangVisitorsArrive();
				DomainManager.Story.JingangBroadCastSecInfo(context);
				break;
			}
			case 212:
			case 214:
			{
				bool jingangDefeatShmashanaAdhipati = false;
				argBox.Get(SectMainStoryEventArgKey.DefValue.JingangDefeatShmashanaAdhipati, ref jingangDefeatShmashanaAdhipati);
				if (jingangDefeatShmashanaAdhipati)
				{
					bool jingangMonkReincarnationTriggered = false;
					argBox.Get(SectMainStoryEventArgKey.DefValue.JingangMonkReincarnationTriggered, ref jingangMonkReincarnationTriggered);
					if (!jingangMonkReincarnationTriggered)
					{
						monthlyEventCollection.AddSectMainStoryJingangReincarnation(taiwu.GetId());
						monthlyNotificationCollection.AddSectMainStoryJingangRockFleshed();
						DomainManager.Organization.SetSectFunctionStatus(context, 11, SectFunctionStatuses.SectFunctionStatusType.SpecialInteractionUnlocked, value: true);
						GameData.Domains.Character.Character monk = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 778);
						Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
						Events.RaiseFixedCharacterLocationChanged(context, monk.GetId(), monk.GetLocation(), taiwuVillageLocation);
						monk.SetLocation(taiwuVillageLocation, context);
						DomainManager.Character.DirectlySetFavorabilities(context, monk.GetId(), taiwu.GetId(), 30000, 30000);
						DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangWesternBuddhistMonkPassLegacyTaiwuId, taiwu.GetId());
					}
				}
				else
				{
					bool jingangMonkGhostVanishesTriggered = false;
					argBox.Get(SectMainStoryEventArgKey.DefValue.JingangMonkGhostVanishesTriggered, ref jingangMonkGhostVanishesTriggered);
					if (!jingangMonkGhostVanishesTriggered)
					{
						monthlyEventCollection.AddSectMainStoryJingangGhostVanishes();
					}
				}
				break;
			}
			}
			if (DomainManager.Story.JingangIsInSpreadSutraTask())
			{
				if (DomainManager.Story.JingangCanTriggerMonkSoulEnterDream(context))
				{
					monthlyEventCollection.AddSectMainStoryJingangRitualsInDream();
				}
				int date2 = int.MaxValue;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.JingangAttackDate, ref date2) && currDate >= date2 + SectMainStoryRelatedConstants.JingangEventFrequency1)
				{
					monthlyEventCollection.AddSectMainStoryJingangAttack();
					argBox.Set(SectMainStoryEventArgKey.DefValue.JingangAttackDate, currDate);
				}
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.JingangFamousFakeMonkDate, ref date2) && currDate >= date2 + SectMainStoryRelatedConstants.JingangEventFrequency1)
				{
					monthlyNotificationCollection.AddSectMainStoryJingangFamousFakeMonk();
					argBox.Set(SectMainStoryEventArgKey.DefValue.JingangFamousFakeMonkDate, currDate);
				}
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.JingangPrayDate, ref date2) && currDate >= date2 + SectMainStoryRelatedConstants.JingangEventFrequency1)
				{
					monthlyNotificationCollection.AddSectMainStoryJingangPray();
					argBox.Set(SectMainStoryEventArgKey.DefValue.JingangPrayDate, currDate);
				}
				bool jingangSelectHelpWestMonk = false;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.JingangSelectHelpWestMonk, ref jingangSelectHelpWestMonk) && argBox.Get(SectMainStoryEventArgKey.DefValue.JingangLettersFromJingangDate, ref date2) && currDate >= date2 + SectMainStoryRelatedConstants.JingangEventFrequency2)
				{
					GameData.Domains.Character.Character leader = settlement?.GetAvailableHighMember(8, 0, needAdult: false);
					if (leader != null)
					{
						monthlyEventCollection.AddSectMainStoryJingangLettersFromJingang(leader.GetId());
						argBox.Set(SectMainStoryEventArgKey.DefValue.JingangLettersFromJingangDate, currDate);
					}
				}
				bool jingangSecInfoSpreadingSelectBetray = false;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.JingangSecInfoSpreadingSelectBetray, ref jingangSecInfoSpreadingSelectBetray) && argBox.Get(SectMainStoryEventArgKey.DefValue.JingangFameDistributionDate, ref date2) && currDate >= date2 + SectMainStoryRelatedConstants.JingangEventFrequency1)
				{
					short areaId = DomainManager.Map.GetSpiritualDebtLowestAreaIdByAreaId(taiwuLocation.AreaId);
					DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, 200);
					taiwu.ChangeResource(context, 7, 4000);
					InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
					collection.AddResourceIncreased(taiwu.GetId(), 7, 4000);
					monthlyNotificationCollection.AddSectMainStoryJingangFameDistribution(taiwu.GetId(), taiwuLocation);
					argBox.Set(SectMainStoryEventArgKey.DefValue.JingangFameDistributionDate, currDate);
				}
				if (DomainManager.Story.JingangCanTriggerPietyEvent())
				{
					monthlyEventCollection.AddSectMainStoryJingangPiety(taiwu.GetId());
				}
			}
			switch (jingangTaskInProgress)
			{
			case 204:
			{
				int count = 0;
				argBox.Get(SectMainStoryEventArgKey.DefValue.JingangPersuadeVillagerCount, ref count);
				if (count >= 1 && !argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.JingangMonthlyEventVillagerEscapeTriggered))
				{
					monthlyNotificationCollection.AddSectMainStoryJingangVillagerFlee(taiwu.GetId());
				}
				break;
			}
			case 199:
			case 206:
				if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.JingangMonthlyEventVillagerEscapeTriggered) && !argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.JingangTriggerMonthlyEventVillagerSuffer))
				{
					monthlyNotificationCollection.AddSectMainStoryJingangVillagerFlee(taiwu.GetId());
				}
				break;
			}
			int num3 = jingangTaskInProgress;
			int num4 = num3;
			if (num4 == 206 || num4 == 214)
			{
				DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(11);
			}
		}
		else if (DomainManager.Story.JingangMonkWasRobbedCanTrigger() && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus"))
		{
			monthlyEventCollection.AddSectMainStoryJingangMonkMurdered();
		}
	}

	private void AdvanceMonth_SectMainStory_Wuxian(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		int progress = DomainManager.World.GetExtraTaskChainCurrentTask(33);
		if (TryGetPrologueAddedWug(out var wugAdded) && wugAdded > -1)
		{
			if (IsWuxianTaiwuChanged() && IsWuxianPrologueWugAttackedOnce() && progress == 246)
			{
				monthlyEventCollection.AddSectMainStoryWuxianMiaoWoman(location);
			}
			else
			{
				monthlyEventCollection.AddSectMainStoryWuxianPoisonousWug(taiwuId);
			}
		}
		else if (GetWuxianChapterOneWishCount() > GetWuxianChapterOneWishComeTrueCount() && GetWuxianChapterOneWishComeTrueCount() < 2)
		{
			monthlyEventCollection.AddSectMainStoryWuxianStrangeThings();
		}
		else if (IsAbleToTriggerWuxianChapterThreeMail())
		{
			monthlyEventCollection.AddSectMainStoryWuxianGiftsReceived(taiwuId, location);
		}
		else
		{
			EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
			int date = -1;
			int currDate = DomainManager.World.GetCurrDate();
			if (progress >= 0 && progress != 254 && permanentArgBox.Get(SectMainStoryEventArgKey.DefValue.WuxianChapter4HappyEndingEventDate, ref date) && currDate >= date)
			{
				monthlyEventCollection.AddSectMainStoryWuxianStrangeThings();
			}
			switch (progress)
			{
			case 249:
				if (permanentArgBox.Get(Config.SectMainStory.DefValue.Wuxian.BadEndDateKey, ref date) && currDate >= date && !IsWuxianEndingEventTriggered())
				{
					monthlyEventCollection.AddSectMainStoryWuxianFailing0();
				}
				break;
			case 221:
			case 255:
				if (permanentArgBox.Get(Config.SectMainStory.DefValue.Wuxian.BadEndDateKey, ref date) && currDate >= date && !IsWuxianEndingEventTriggered())
				{
					monthlyEventCollection.AddSectMainStoryWuxianFailing1();
				}
				break;
			case 220:
				if (permanentArgBox.Get(Config.SectMainStory.DefValue.Wuxian.GoodEndDateKey, ref date) && currDate >= date && !IsWuxianEndingEventTriggered())
				{
					monthlyEventCollection.AddSectMainStoryWuxianProsperous();
				}
				break;
			}
		}
		UpdateWuxianParanoiaCharacters(context);
	}

	private void AdvanceMonth_SectMainStory_Ranshan(DataContext context)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(7);
		if (DomainManager.World.IsExtraTaskChainInProgress(44))
		{
			int currDate = DomainManager.World.GetCurrDate();
			int startDate = currDate;
			argBox.Get(SectMainStoryEventArgKey.DefValue.RanshanChapter2TeachStartDate, ref startDate);
			argBox.Set(SectMainStoryEventArgKey.DefValue.RanshanSanZongBiWuCountDown, 24 - currDate + startDate);
			DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 7);
		}
		if (IsRanshanSectMainStoryAbleToTrigger())
		{
			if (!argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus"))
			{
				monthlyEventCollection.AddSectMainStoryRanshanDragonGate();
			}
		}
		else if (IsRanshanChapter1MonthlyEvent2AbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanMessage(taiwuId);
		}
		else if (IsRanshanChapter1MonthlyEvent3AbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanAfterQinglang(taiwuId, location);
		}
		else if (IsRanshanChapter2HuajuAbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanPaperCraneFromYufuFaction(taiwuId, location);
		}
		else if (IsRanshanChapter2XuanzhiAbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanPaperCraneFromShenjianFaction(taiwuId, location);
		}
		else if (IsRanshanChapter2YingjiaoAbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanPaperCraneFromYinyangFaction(taiwuId, location);
		}
		else if (IsRanshanChapter2MonthlyEventAbleToTrigger())
		{
			monthlyEventCollection.AddSectMainStoryRanshanSanshiLeave(taiwuId);
		}
		else if (DomainManager.World.IsExtraTaskInProgress(266))
		{
			DomainManager.World.TriggerExtraTask(context, 35, 267);
			GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 697);
			Location ranshanLocation = DomainManager.Organization.GetSettlementByOrgTemplateId(7).GetLocation();
			Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), ranshanLocation);
			character.SetLocation(ranshanLocation, context);
		}
		else
		{
			switch (DomainManager.World.GetExtraTaskChainCurrentTask(35))
			{
			case 268:
				if (DomainManager.Extra.IsRanshanMenteeGoodStoryEnding())
				{
					monthlyEventCollection.AddSectMainStoryRanshanProsperous();
					ConvertRanshanFootman(context, isGoodEnd: true);
				}
				else
				{
					monthlyEventCollection.AddSectMainStoryRanshanFailing();
					ConvertRanshanFootman(context, isGoodEnd: false);
				}
				break;
			case 270:
				monthlyEventCollection.AddSectMainStoryRanshanFailing();
				ConvertRanshanFootman(context, isGoodEnd: false);
				break;
			}
		}
		UpdateRanshanThreeCorpsesAction(context);
	}

	private void AdvanceMonth_SectMainStory_Baihua(DataContext context)
	{
		if (DomainManager.World.GetDefeatSwordTombCount() < Config.SectMainStory.DefValue.Baihua.RequireDefeatSwordTombCount)
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		short whiteDeerLakeAreaId = DomainManager.Map.GetAreaIdByAreaTemplateId(18);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		bool baihuaEndenmicTriggered = argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaEndenmicTriggered);
		if (taiwuLocation.AreaId == whiteDeerLakeAreaId && !baihuaEndenmicTriggered && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus"))
		{
			monthlyEventCollection.AddSectMainStoryBaihuaEndenmic();
		}
		sbyte taskStatus = DomainManager.Story.GetSectMainStoryTaskStatus(3);
		if (taskStatus == 1 && argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.BaihuaLMTransferAnimalDate))
		{
			GameData.Domains.Character.Character leukorpus = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 580);
			GameData.Domains.Character.Character melanpsyche = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 585);
			GameData.Domains.Character.Character leukoDeer = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 573);
			GameData.Domains.Character.Character melanoOwl = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 574);
			int date = int.MaxValue;
			if (!leukorpus.IsActiveExternalRelationState(64uL) && !melanpsyche.IsActiveExternalRelationState(64uL) && !leukoDeer.IsActiveExternalRelationState(64uL) && !melanoOwl.IsActiveExternalRelationState(64uL) && argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLMTransferAnimalDate, ref date) && date + GlobalConfig.Instance.BaihuaLifeLinkRemoveCharacterCooldown <= currDate)
			{
				Settlement baihuaSettlement = DomainManager.Organization.GetSettlementByOrgTemplateId(3);
				Location baihuaLocation = baihuaSettlement.GetLocation();
				Events.RaiseFixedCharacterLocationChanged(context, leukorpus.GetId(), leukorpus.GetLocation(), baihuaLocation);
				leukorpus.SetLocation(baihuaLocation, context);
				Events.RaiseFixedCharacterLocationChanged(context, melanpsyche.GetId(), melanpsyche.GetLocation(), baihuaLocation);
				melanpsyche.SetLocation(baihuaLocation, context);
				Events.RaiseFixedCharacterLocationChanged(context, leukoDeer.GetId(), leukoDeer.GetLocation(), Location.Invalid);
				leukoDeer.SetLocation(Location.Invalid, context);
				Events.RaiseFixedCharacterLocationChanged(context, melanoOwl.GetId(), melanoOwl.GetLocation(), Location.Invalid);
				melanoOwl.SetLocation(Location.Invalid, context);
				DomainManager.Extra.RemoveArgToSectMainStoryEventArgBox<int>(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLMTransferAnimalDate);
				InstantNotificationCollection instantCollection = DomainManager.World.GetInstantNotificationCollection();
				instantCollection.AddSectStoryBaihuaToHuman();
			}
		}
		if (taskStatus != 0 || DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(3))
		{
			return;
		}
		int baihuaTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(43);
		bool baihuaCombatTaskInProgress = DomainManager.World.IsExtraTaskChainInProgress(45);
		bool baihuaRelationshipTaskInProgress = DomainManager.World.IsExtraTaskChainInProgress(46);
		bool tryTriggerBaihuaCombatTaskChain = false;
		bool tryTriggerBaihuaManicLow = false;
		bool tryTriggerBaihuaManicHigh = false;
		bool tryTriggerLeukoMelanoPlay = false;
		bool tryTriggerLMPlay = false;
		switch (baihuaTaskInProgress)
		{
		case 290:
			TryTriggerBaihuaManicLow();
			TryTriggerBaihuaManicHigh(triggerTask: true);
			TryTriggedLeukoMelanoPlay();
			TryTriggedLMPlay();
			break;
		case 291:
		{
			TryTriggerBaihuaManicHigh(triggerTask: false);
			int date2 = int.MaxValue;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaManicHighDate, ref date2) && currDate >= date2 + 3)
			{
				monthlyEventCollection.AddSectMainStoryBaihuaAnonymReturns();
			}
			break;
		}
		case 292:
			TryTriggerBaihuaManicHigh(triggerTask: false);
			break;
		}
		if (baihuaCombatTaskInProgress)
		{
			if (DomainManager.World.IsExtraTaskInProgress(277))
			{
				TryTriggerBaihuaCombatTaskChain();
				int date3 = 0;
				if (!argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaDreamAboutPastLastDate, ref date3) || (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaDreamAboutPastLastDate, ref date3) && currDate < date3 + 3))
				{
					return;
				}
				if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaDreamAboutPastLastTriggered))
				{
					monthlyEventCollection.AddSectMainStoryBaihuaDreamAboutPastLast(taiwu.GetId());
				}
			}
			if (DomainManager.World.IsExtraTaskInProgress(278))
			{
				TryTriggerBaihuaCombatTaskChain();
				if (context.Random.CheckPercentProb(50))
				{
					bool isLock = false;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementIdLock, ref isLock);
					short settlementId = -1;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, ref settlementId);
					Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
					if (!isLock)
					{
						List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
						DomainManager.Map.GetAreaSettlementIds(settlement.GetLocation().AreaId, settlementIds, containsMainCity: true, containsSect: true);
						short settlementIdNew = settlementIds.GetRandom(context.Random);
						ObjectPool<List<short>>.Instance.Return(settlementIds);
						if (settlementIdNew != settlementId)
						{
							DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, settlementIdNew);
							settlement = DomainManager.Organization.GetSettlement(settlementIdNew);
							DomainManager.Story.CallBaihuaMember(context, isLeuko: true);
						}
					}
					else
					{
						DomainManager.Story.CallBaihuaMember(context, isLeuko: true);
					}
					monthlyNotificationCollection.AddSectMainStoryBaihuaLeukoKills(settlement.GetLocation());
				}
			}
			if (DomainManager.World.IsExtraTaskInProgress(280))
			{
				TryTriggerBaihuaCombatTaskChain();
				if (context.Random.CheckPercentProb(50))
				{
					bool isLock2 = false;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementIdLock, ref isLock2);
					short settlementId2 = -1;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, ref settlementId2);
					Settlement settlement2 = DomainManager.Organization.GetSettlement(settlementId2);
					if (!isLock2)
					{
						List<short> settlementIds2 = ObjectPool<List<short>>.Instance.Get();
						DomainManager.Map.GetAreaSettlementIds(settlement2.GetLocation().AreaId, settlementIds2, containsMainCity: true, containsSect: true);
						short settlementIdNew2 = settlementIds2.GetRandom(context.Random);
						ObjectPool<List<short>>.Instance.Return(settlementIds2);
						if (settlementIdNew2 != settlementId2)
						{
							DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, settlementIdNew2);
							settlement2 = DomainManager.Organization.GetSettlement(settlementIdNew2);
							DomainManager.Story.CallBaihuaMember(context, isLeuko: false);
						}
					}
					else
					{
						DomainManager.Story.CallBaihuaMember(context, isLeuko: false);
					}
					monthlyNotificationCollection.AddSectMainStoryBaihuaMelanoKills(settlement2.GetLocation());
				}
			}
			int groupId;
			if (DomainManager.World.IsExtraTaskInProgress(279))
			{
				short baihuaLeukoKillsMonthEventSettlementId = -1;
				argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, ref baihuaLeukoKillsMonthEventSettlementId);
				if (DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwu.GetLocation(), baihuaLeukoKillsMonthEventSettlementId) && DomainManager.Story.BaihuaGroupMeetCount(isLeuko: true, out groupId) >= 1 && context.Random.CheckPercentProb(GetAmbushProb(isisLeuko: true)))
				{
					monthlyEventCollection.AddSectMainStoryBaihuaAmbushLeuko();
				}
			}
			if (DomainManager.World.IsExtraTaskInProgress(281))
			{
				short baihuaMelanoKillsMonthEventSettlementId = -1;
				argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, ref baihuaMelanoKillsMonthEventSettlementId);
				if (DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwu.GetLocation(), baihuaMelanoKillsMonthEventSettlementId) && DomainManager.Story.BaihuaGroupMeetCount(isLeuko: false, out groupId) >= 1 && context.Random.CheckPercentProb(GetAmbushProb(isisLeuko: false)))
				{
					monthlyEventCollection.AddSectMainStoryBaihuaAmbushMelano();
				}
			}
		}
		if (baihuaRelationshipTaskInProgress && DomainManager.World.IsExtraTaskInProgress(283))
		{
			int date4 = int.MaxValue;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaAnimalsBackDate, ref date4) && currDate < date4 + 6)
			{
				TryTriggerPandemicStartTask();
			}
			TryTriggerBaihuaManicLow();
			TryTriggerBaihuaManicHigh(triggerTask: true);
			TryTriggedLeukoMelanoPlay();
			TryTriggedLMPlay();
			if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaLeukoAssistedMelano))
			{
				GameData.Domains.Character.Character leukoDeer2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 573);
				if (FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(leukoDeer2.GetId(), taiwu.GetId())) >= 5)
				{
					monthlyNotificationCollection.AddSectMainStoryBaihuaLeukoHelps();
					DomainManager.World.TriggerExtraTask(context, 46, 286);
					DomainManager.World.FinishTriggeredExtraTask(context, 46, 285);
				}
			}
			if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaMelanoAssistedLeuko))
			{
				GameData.Domains.Character.Character melanoOwl2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 574);
				if (FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(melanoOwl2.GetId(), taiwu.GetId())) >= 5)
				{
					monthlyNotificationCollection.AddSectMainStoryBaihuaMelanoHelps();
					DomainManager.World.TriggerExtraTask(context, 46, 289);
					DomainManager.World.FinishTriggeredExtraTask(context, 46, 288);
				}
			}
		}
		UpdateBaihuaManicCharacters(context);
		int GetAmbushProb(bool isisLeuko)
		{
			int date5 = int.MaxValue;
			if (isisLeuko)
			{
				argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsOptionSelectDate, ref date5);
			}
			else
			{
				argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsOptionSelectDate, ref date5);
			}
			return 40 + (currDate - date5) * 10;
		}
		void TryTriggedLMPlay()
		{
			if (!tryTriggerLMPlay)
			{
				tryTriggerLMPlay = true;
				if (taiwuLocation.AreaId == taiwuVillageLocation.AreaId && argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaLeukoAssistedMelano) && argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaMelanoAssistedLeuko))
				{
					int count = -1;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLMPlayCount, ref count);
					DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLMPlayCount, ++count);
					if (count >= 2)
					{
						monthlyEventCollection.AddSectMainStoryBaihuaLeukoMelanoPlay();
					}
				}
			}
		}
		void TryTriggedLeukoMelanoPlay()
		{
			if (!tryTriggerLeukoMelanoPlay)
			{
				tryTriggerLeukoMelanoPlay = true;
				if (taiwuLocation.AreaId == taiwuVillageLocation.AreaId)
				{
					bool leukoNeedTrigger = false;
					bool melanoNeedTrigger = false;
					int count = -1;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoPlayCount, ref count);
					DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLeukoPlayCount, ++count);
					if (count > 2)
					{
						leukoNeedTrigger = true;
					}
					count = -1;
					argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoPlayCount, ref count);
					DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaMelanoPlayCount, ++count);
					if (count > 2)
					{
						melanoNeedTrigger = true;
					}
					if (leukoNeedTrigger && melanoNeedTrigger)
					{
						if (context.Random.Next(0, 2) == 0)
						{
							monthlyEventCollection.AddSectMainStoryBaihuaLeukoPlay();
						}
						else
						{
							monthlyEventCollection.AddSectMainStoryBaihuaMelanoPlay();
						}
					}
					else if (leukoNeedTrigger)
					{
						monthlyEventCollection.AddSectMainStoryBaihuaLeukoPlay();
					}
					else if (melanoNeedTrigger)
					{
						monthlyEventCollection.AddSectMainStoryBaihuaMelanoPlay();
					}
				}
			}
		}
		void TryTriggerBaihuaCombatTaskChain()
		{
			if (!tryTriggerBaihuaCombatTaskChain)
			{
				tryTriggerBaihuaCombatTaskChain = true;
				if (argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaDreamAboutPastLastTriggered))
				{
					if (currDate % 2 == 0)
					{
						if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventTriggered))
						{
							short settlementId3 = DomainManager.Story.BaihuaSelectSettlementIdNeighborTaiwuVillage(context);
							Settlement settlement3 = DomainManager.Organization.GetSettlement(settlementId3);
							DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, settlementId3);
							DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsInteractOpen, value: true);
							monthlyEventCollection.AddSectMainStoryBaihuaLeukoKills(settlement3.GetLocation());
						}
					}
					else if (!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventTriggered))
					{
						short settlementId4 = DomainManager.Story.BaihuaSelectSettlementIdNeighborTaiwuVillage(context);
						Settlement settlement4 = DomainManager.Organization.GetSettlement(settlementId4);
						DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, settlementId4);
						DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsInteractOpen, value: true);
						monthlyEventCollection.AddSectMainStoryBaihuaMelanoKills(settlement4.GetLocation());
					}
				}
			}
		}
		void TryTriggerBaihuaManicHigh(bool triggerTask)
		{
			if (!tryTriggerBaihuaManicHigh)
			{
				tryTriggerBaihuaManicHigh = true;
				int date5 = int.MaxValue;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaManicLowDate, ref date5) && currDate >= date5 + 3)
				{
					short taiwuAreaId = taiwuVillageLocation.AreaId;
					List<short> settlementIds3 = ObjectPool<List<short>>.Instance.Get();
					DomainManager.Map.GetAreaSettlementIds(taiwuAreaId, settlementIds3, containsMainCity: true, containsSect: true);
					short settlementId3 = settlementIds3.GetRandom(context.Random);
					CharacterSet groupCharIds = DomainManager.Taiwu.GetGroupCharIds();
					Settlement settlement3 = DomainManager.Organization.GetSettlement(settlementId3);
					monthlyNotificationCollection.AddSectMainStoryBaihuaManicHigh(settlement3.GetLocation());
					List<int> members = ObjectPool<List<int>>.Instance.Get();
					settlement3.GetMembers().GetAllMembers(members);
					CollectionUtils.Shuffle(context.Random, members);
					for (int j = members.Count - 1; j >= 0; j--)
					{
						int charId = members[j];
						if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && (groupCharIds.Contains(charId) || character.GetAgeGroup() < 2))
						{
							members.RemoveAt(j);
						}
					}
					int debuffCount = context.Random.Next(3, 7);
					for (int i = 0; i < Math.Min(debuffCount, members.Count); i++)
					{
						int charId2 = members[i];
						if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
						{
							character2.AddFeature(context, 713);
							lifeRecordCollection.AddSectMainStoryBaihuaManiaHigh(charId2, currDate, character2.GetLocation());
							DomainManager.Story.BaihuaAddCharIdToSpecialDebuffIntList(context, charId2);
						}
					}
					if (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.BaihuaManicHighDate))
					{
						DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaManicHighDate, currDate);
					}
					ObjectPool<List<int>>.Instance.Return(members);
					DomainManager.World.FinishAllTaskInChain(context, 46);
					if (triggerTask)
					{
						DomainManager.World.TriggerExtraTask(context, 43, 291);
					}
				}
			}
		}
		void TryTriggerBaihuaManicLow()
		{
			if (!tryTriggerBaihuaManicLow)
			{
				tryTriggerBaihuaManicLow = true;
				int date5 = int.MaxValue;
				if (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaAnimalsBackDate, ref date5) && currDate >= date5 + 6 && (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.BaihuaManicLowDate) || (argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaManicLowDate, ref date5) && currDate <= date5 + 6)))
				{
					List<short> settlementIds3 = DomainManager.Story.BaihuaSelectSettlementIds(context, avoidGuangnan: false, avoidTaiwuVillageArea: true, 3);
					List<int> members = ObjectPool<List<int>>.Instance.Get();
					CharacterSet groupCharIds = DomainManager.Taiwu.GetGroupCharIds();
					for (int i = 0; i < settlementIds3.Count; i++)
					{
						short settlementId3 = settlementIds3[i];
						Settlement settlement3 = DomainManager.Organization.GetSettlement(settlementId3);
						monthlyNotificationCollection.AddSectMainStoryBaihuaManicLow(settlement3.GetLocation());
						members.Clear();
						settlement3.GetMembers().GetAllMembers(members);
						CollectionUtils.Shuffle(context.Random, members);
						for (int j = members.Count - 1; j >= 0; j--)
						{
							int charId = members[j];
							if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && (groupCharIds.Contains(charId) || character.GetAgeGroup() < 2))
							{
								members.RemoveAt(j);
							}
						}
						int debuffCount = context.Random.Next(3, 7);
						for (int k = 0; k < Math.Min(debuffCount, members.Count); k++)
						{
							int charId2 = members[k];
							if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
							{
								character2.AddFeature(context, 712);
								lifeRecordCollection.AddSectMainStoryBaihuaManiaLow(charId2, currDate, character2.GetLocation());
								DomainManager.Story.BaihuaAddCharIdToSpecialDebuffIntList(context, charId2);
							}
						}
					}
					ObjectPool<List<int>>.Instance.Return(members);
					TryTriggerPandemicStartTask();
					if (!argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.BaihuaManicLowDate))
					{
						DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaManicLowDate, currDate);
					}
				}
			}
		}
		void TryTriggerPandemicStartTask()
		{
			if (argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaLeukoAssistedMelano) && argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.BaihuaMelanoAssistedLeuko))
			{
				DomainManager.World.TriggerExtraTask(context, 43, 290);
			}
		}
	}

	private void AdvanceMonth_SectMainStory_Zhujian(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(9) == 0)
		{
			EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(9);
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			if (DomainManager.Story.CheckSectMainStoryAvailable(9) && DomainManager.Organization.GetSettlementByOrgTemplateId(9).CalcApprovingRate() >= 500 && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus") && ZhujianMainStoryTrigger1())
			{
				monthlyEventCollection.AddSectMainStoryZhujianHeir(taiwu.GetId(), taiwu.GetLocation());
			}
			else
			{
				DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(9);
			}
		}
	}

	private void AdvanceMonth_SectMainStoryFulong(DataContext context)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(14);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		short fulongSettlementId = DomainManager.Organization.GetSettlementByOrgTemplateId(14).GetId();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		if (DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(14))
		{
			return;
		}
		bool fulongDisasterStart = false;
		argBox.Get(SectMainStoryEventArgKey.DefValue.FulongDisasterStart, ref fulongDisasterStart);
		if ((!argBox.Contains<bool>(SectMainStoryEventArgKey.DefValue.FulongDisasterStart) && !argBox.Contains<int>("ConchShip_PresetKey_SectMainStoryTriggeringStatus") && DomainManager.Story.FulongDisasterStart()) || fulongDisasterStart)
		{
			int prob = 30;
			if (argBox.Contains<int>(SectMainStoryEventArgKey.DefValue.FulongDisasterStartProb))
			{
				argBox.Get(SectMainStoryEventArgKey.DefValue.FulongDisasterStartProb, ref prob);
			}
			bool taiwuAtChimingdao = taiwuLocation.AreaId == DomainManager.Map.GetAreaIdByAreaTemplateId(29);
			prob = ((!taiwuAtChimingdao) ? (prob + 15) : (prob + 30));
			if (context.Random.CheckPercentProb(prob))
			{
				prob -= 45;
				DomainManager.Story.FulongTriggerDisaster(context);
				monthlyNotificationCollection.AddSectMainStoryFulongSacrifice();
				if (taiwuAtChimingdao)
				{
					monthlyEventCollection.AddSectMainStoryFulongDiasterAppear();
				}
			}
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongDisasterStartProb, prob);
		}
		int fulongTaskInProgress = DomainManager.World.GetExtraTaskChainCurrentTask(47);
		int num = fulongTaskInProgress;
		int num2 = num;
		if ((uint)(num2 - 298) <= 4u)
		{
			int date = int.MaxValue;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.FulongMessengerAppearTime, ref date) && currDate >= date + SectMainStoryRelatedConstants.FulongZealotStartRobTime)
			{
				DomainManager.Extra.ApplyFulongOutLawAdvanceMonth(context, date);
			}
		}
		switch (fulongTaskInProgress)
		{
		case 295:
		{
			int fulongAdventureOneCountDown = 0;
			argBox.Get(SectMainStoryEventArgKey.DefValue.FulongAdventureOneCountDown, ref fulongAdventureOneCountDown);
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongAdventureOneCountDown, --fulongAdventureOneCountDown);
			break;
		}
		case 308:
		case 311:
		{
			DomainManager.Extra.ApplyFulongInFlameAreaAdvanceMonth(context);
			int date2 = int.MaxValue;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.FulongFireStartTime, ref date2) && currDate >= date2 + GlobalConfig.Instance.FulongFlameExtinguishTime)
			{
				monthlyNotificationCollection.AddSectMainStoryFulongFireVanishes();
				List<FulongInFlameArea> fireAreas = DomainManager.Extra.GetAllFulongInFlameAreas();
				int count = fireAreas.Count;
				for (int i = 0; i < count; i++)
				{
					DomainManager.Extra.ApplyFulongInFlameAreaFullyExtinguished(context, 0, triggerEvent: false);
				}
			}
			else
			{
				bool putOutFire = false;
				argBox.Get(SectMainStoryEventArgKey.DefValue.FulongPutOutFire, ref putOutFire);
				if (putOutFire && DomainManager.Extra.GetAllFulongInFlameAreas().Count > 0)
				{
					monthlyEventCollection.AddSectMainStoryFulongFireFighting(taiwu.GetId());
				}
			}
			break;
		}
		case 309:
		{
			int level = 3;
			argBox.Get(SectMainStoryEventArgKey.DefValue.FulongLazuliFindFlowerDialogLevel, ref level);
			if (level < 6)
			{
				break;
			}
			int date3 = int.MaxValue;
			if (argBox.Get(SectMainStoryEventArgKey.DefValue.FulongStayWithLazuliTaskTriggerDate, ref date3) && currDate >= date3 + 3)
			{
				Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
				MapBlockData villageBlockData = DomainManager.Map.GetBlockData(taiwuVillageLocation.AreaId, taiwuVillageLocation.BlockId);
				MapBlockData taiwuLocationBlockData = DomainManager.Map.GetBlockData(taiwu.GetValidLocation().AreaId, taiwu.GetValidLocation().BlockId);
				ByteCoordinate taiwuBlockPos = taiwuLocationBlockData.GetBlockPos();
				if (villageBlockData.GetManhattanDistanceToPos(taiwuBlockPos.X, taiwuBlockPos.Y) <= 3)
				{
					DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongTravelWithLazuliFinished, value: true);
				}
			}
			break;
		}
		case 303:
		{
			int fulongAdventureTwoTaiwuId = -1;
			argBox.Get(SectMainStoryEventArgKey.DefValue.FulongAdventureTwoTaiwuId, ref fulongAdventureTwoTaiwuId);
			if (fulongAdventureTwoTaiwuId != taiwu.GetId())
			{
				monthlyEventCollection.AddSectMainStoryFulongLazuliLetter();
			}
			GameData.Utilities.ShortList list = argBox.Get<GameData.Utilities.ShortList>(SectMainStoryEventArgKey.DefValue.FulongChickenFeatherDropList);
			List<short> items = list.Items;
			if (items == null || items.Count <= 0)
			{
				break;
			}
			foreach (short chickenTemplateId in list.Items)
			{
				monthlyNotificationCollection.AddSectMainStoryFulongFeatherDrop(chickenTemplateId);
			}
			list.Items.Clear();
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongChickenFeatherDropList, list);
			break;
		}
		case 305:
		{
			int fulongAdventureThreeCountDown = 0;
			argBox.Get(SectMainStoryEventArgKey.DefValue.FulongAdventureThreeCountDown, ref fulongAdventureThreeCountDown);
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongAdventureThreeCountDown, --fulongAdventureThreeCountDown);
			break;
		}
		}
	}

	private void UpdateWuxianParanoiaCharacters(DataContext context)
	{
		List<GameData.Domains.Character.Character> paranoiaCharacters = new List<GameData.Domains.Character.Character>();
		List<int> potentialTargetIds = new List<int>();
		MapCharacterFilter.ParallelFind(ShouldAttackRandomTarget, paranoiaCharacters, 0, 135);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		if (paranoiaCharacters.Count < 7 && DomainManager.Story.GetSectMainStoryTaskStatus(12) == 2 && context.Random.CheckPercentProb(25))
		{
			Settlement sect = DomainManager.Organization.GetSettlementByOrgTemplateId(12);
			List<int> charIdList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
			sect.GetMembers().GetAllMembers(charIdList);
			int maxAttainment = int.MinValue;
			foreach (int charId in charIdList)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetHappinessType() != 6 && !character.GetFeatureIds().Contains(743))
				{
					short attainment = character.GetLifeSkillAttainment(9);
					if (attainment > maxAttainment)
					{
						maxAttainment = attainment;
						potentialTargetIds.Clear();
						potentialTargetIds.Add(charId);
					}
					else if (attainment == maxAttainment)
					{
						potentialTargetIds.Add(charId);
					}
				}
			}
			context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
			if (potentialTargetIds.Count > 0)
			{
				int selectedCharId = potentialTargetIds.GetRandom(context.Random);
				GameData.Domains.Character.Character selectedChar = DomainManager.Character.GetElement_Objects(selectedCharId);
				selectedChar.AddFeature(context, 743);
				lifeRecordCollection.AddWuxianParanoiaAdded(selectedCharId, currDate, selectedChar.GetLocation());
				monthlyNotifications.AddSectMainStoryWuxianParanoiaAppeared(selectedCharId);
			}
		}
		foreach (GameData.Domains.Character.Character character2 in paranoiaCharacters)
		{
			int charId2 = character2.GetId();
			Location location = character2.GetLocation();
			if (!DomainManager.Character.IsCharacterAlive(charId2))
			{
				continue;
			}
			if (character2.GetHappinessType() == 6)
			{
				character2.RemoveFeature(context, 743);
				lifeRecordCollection.AddWuxianParanoiaErased(charId2, currDate, location);
			}
			else
			{
				if (!location.IsValid() || !character2.IsInteractableAsIntelligentCharacter() || context.Random.NextBool())
				{
					continue;
				}
				if (location == taiwuLocation)
				{
					lifeRecordCollection.AddWuxianParanoiaAttack(charId2, currDate, taiwuChar.GetId(), location);
					monthlyEventCollection.AddSectMainStoryWuxianAssault(charId2, location);
					DomainManager.Character.HandleAttackAction(context, character2, taiwuChar);
					continue;
				}
				character2.GetPotentialHarmfulActionTargets(potentialTargetIds);
				if (potentialTargetIds.Count != 0)
				{
					int selectedCharId2 = potentialTargetIds.GetRandom(context.Random);
					GameData.Domains.Character.Character selectedChar2 = DomainManager.Character.GetElement_Objects(selectedCharId2);
					lifeRecordCollection.AddWuxianParanoiaAttack(charId2, currDate, selectedCharId2, location);
					DomainManager.Character.HandleAttackAction(context, character2, selectedChar2);
				}
			}
		}
		static bool ShouldAttackRandomTarget(GameData.Domains.Character.Character character3)
		{
			return character3.GetFeatureIds().Contains(743);
		}
	}

	private void UpdateBaihuaManicCharacters(DataContext context)
	{
		List<int> manicCharList = DomainManager.Story.BaihuaGetSpecialDebuffIntList().Items;
		if (manicCharList == null || manicCharList.Count <= 0)
		{
			return;
		}
		List<int> potentialTargetIds = ObjectPool<List<int>>.Instance.Get();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwuChar.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		foreach (int charId in manicCharList)
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			Location location = character.GetLocation();
			if (!location.IsValid() || !character.IsInteractableAsIntelligentCharacter() || DomainManager.Character.IsNotManicCharacter(character) || context.Random.NextBool())
			{
				continue;
			}
			if (location == taiwuLocation)
			{
				lifeRecordCollection.AddSectMainStoryBaihuaManiaAttack(charId, currDate, taiwuChar.GetId(), location);
				monthlyEventCollection.AddSectMainStoryBaihuaManicAttack(charId, location);
				DomainManager.Character.HandleAttackAction(context, character, taiwuChar);
				continue;
			}
			character.GetPotentialHarmfulActionTargets(potentialTargetIds);
			if (potentialTargetIds.Count != 0)
			{
				int selectedCharId = potentialTargetIds.GetRandom(context.Random);
				GameData.Domains.Character.Character selectedChar = DomainManager.Character.GetElement_Objects(selectedCharId);
				lifeRecordCollection.AddSectMainStoryBaihuaManiaAttack(charId, currDate, selectedCharId, location);
				DomainManager.Character.HandleAttackAction(context, character, selectedChar);
			}
		}
		ObjectPool<List<int>>.Instance.Return(potentialTargetIds);
	}

	private bool AreaHasAdultGraveOfTargetOrganization(short areaId, sbyte orgTemplateId)
	{
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData mapBlockData = span[i];
			if (mapBlockData.GraveSet == null || mapBlockData.GraveSet.Count <= 0)
			{
				continue;
			}
			foreach (int graveId in mapBlockData.GraveSet)
			{
				DomainManager.Character.TryGetElement_Graves(graveId, out var grave);
				DeadCharacter deadCharacter = DomainManager.Character.GetDeadCharacter(grave.GetId());
				if (deadCharacter.OrganizationInfo.OrgTemplateId == orgTemplateId && deadCharacter.GetActualAge() >= 16)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal void ShixiangQueryEnemyLocations(DataContext context, out short areaId, out List<short> blockIds)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(6);
		Location settlementLocation = settlement.GetLocation();
		areaId = settlementLocation.AreaId;
		List<MapBlockData> blocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.QueryRegularBelongBlocks(blocks, settlementLocation, true);
		blockIds = new List<short>();
		foreach (MapBlockData blockData in blocks)
		{
			HashSet<int> enemyCharacterSet = blockData.EnemyCharacterSet;
			if (enemyCharacterSet == null || enemyCharacterSet.Count <= 0)
			{
				continue;
			}
			foreach (int enemyCharId in blockData.EnemyCharacterSet)
			{
				if (DomainManager.Character.TryGetElement_Objects(enemyCharId, out var enemyChar))
				{
					short templateId = enemyChar.GetTemplateId();
					if ((templateId >= 681 && templateId <= 690) || 1 == 0)
					{
						blockIds.Add(blockData.BlockId);
						break;
					}
				}
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref blocks);
	}

	public void JixiGrowUp(DataContext context, short oldCharTemplateId, short newCharTemplateId)
	{
		GameData.Domains.Character.Character newChar = DomainManager.Character.ReplaceFixedCharacter(context, oldCharTemplateId, newCharTemplateId);
		if (!newChar.GetLocation().IsValid())
		{
			Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
			Events.RaiseFixedCharacterLocationChanged(context, newChar.GetId(), newChar.GetLocation(), taiwuVillageLocation);
			newChar.SetLocation(taiwuVillageLocation, context);
		}
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		bool hasFox = false;
		if (sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JixiHasAntiqueJadeFox, ref hasFox) && hasFox)
		{
			ItemKey fox = DomainManager.Item.CreateItem(context, 12, 373);
			newChar.AddInventoryItem(context, fox, 1);
		}
		bool hasBat = false;
		if (sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JixiHasAntiqueJadeBat, ref hasBat) && hasBat)
		{
			ItemKey bat = DomainManager.Item.CreateItem(context, 12, 372);
			newChar.AddInventoryItem(context, bat, 1);
		}
		bool hasButterfly = false;
		if (sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JixiHasAntiqueJadeButterfly, ref hasButterfly) && hasButterfly)
		{
			ItemKey butterfly = DomainManager.Item.CreateItem(context, 12, 374);
			newChar.AddInventoryItem(context, butterfly, 1);
		}
		SectStoryJixiData jixiData = DomainManager.Extra.GetJixiData();
		if (newCharTemplateId == 879)
		{
			DomainManager.Extra.GetJixiData().ChangeFormTotal[2]++;
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 15, SectMainStoryEventArgKey.DefValue.JixiKilledCountKey, 14);
		}
		if (newCharTemplateId == 878)
		{
			DomainManager.Extra.GetJixiData().ChangeFormTotal[1]++;
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 15, SectMainStoryEventArgKey.DefValue.JixiKilledCountKey, 7);
		}
		if (newCharTemplateId == 877)
		{
			DomainManager.Extra.GetJixiData().ChangeFormTotal[0]++;
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 15, SectMainStoryEventArgKey.DefValue.JixiKilledCountKey, 0);
		}
		jixiData.CurrentFormKillAmount = 0;
		if (jixiData.CurrentFormNeiliAllocProgressDrained.Items != null)
		{
			for (int i = 0; i < jixiData.CurrentFormNeiliAllocProgressDrained.Items.Count; i++)
			{
				jixiData.CurrentFormNeiliAllocProgressDrained.Items[i] = 0;
			}
		}
	}

	public bool JixiAdventurePass(sbyte index, int overTime)
	{
		string passKey = string.Empty;
		switch (index)
		{
		case 1:
			passKey = SectMainStoryEventArgKey.DefValue.JixiAdventureOnePassDate.ArgBoxKey;
			break;
		case 2:
			passKey = SectMainStoryEventArgKey.DefValue.JixiAdventureTwoPassDate.ArgBoxKey;
			break;
		case 3:
			passKey = SectMainStoryEventArgKey.DefValue.JixiAdventureThreePassDate.ArgBoxKey;
			break;
		}
		Tester.Assert(passKey != string.Empty);
		EventArgBox eventArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		int passDate = int.MaxValue;
		if (eventArgBox.Get(passKey, ref passDate))
		{
			int currDate = DomainManager.World.GetCurrDate();
			return currDate >= passDate + overTime;
		}
		return false;
	}

	public bool JixiAdventureDisappear(sbyte index, int overTime = 9)
	{
		string startKey = string.Empty;
		switch (index)
		{
		case 1:
			startKey = SectMainStoryEventArgKey.DefValue.JixiAdventureOneStartDate.ArgBoxKey;
			break;
		case 2:
			startKey = SectMainStoryEventArgKey.DefValue.JixiAdventureTwoStartDate.ArgBoxKey;
			break;
		case 3:
			startKey = SectMainStoryEventArgKey.DefValue.JixiAdventureThreeStartDate.ArgBoxKey;
			break;
		}
		Tester.Assert(startKey != string.Empty);
		EventArgBox eventArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		int startDate = int.MaxValue;
		if (eventArgBox.Get(startKey, ref startDate))
		{
			int currDate = DomainManager.World.GetCurrDate();
			return currDate >= startDate + overTime;
		}
		return false;
	}

	public sbyte GetJixiFavorabilityType()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.Character.Character jixi = TryGetJixi();
		if (jixi == null)
		{
			return sbyte.MinValue;
		}
		return FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(jixi.GetId(), taiwu.GetId()));
	}

	public GameData.Domains.Character.Character TryGetJixi()
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(879, out var jixiAdult))
		{
			return jixiAdult;
		}
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(877, out var jixiBaby))
		{
			return jixiBaby;
		}
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(878, out var jixiYoung))
		{
			return jixiYoung;
		}
		return null;
	}

	public void DealSectMainStoryEnd(DataContext context, sbyte orgTemplateId, sbyte endState, int time)
	{
		Tester.Assert(endState != 0);
		DomainManager.Story.SetSectMainStoryTaskStatus(context, orgTemplateId, endState);
		sbyte b = orgTemplateId;
		sbyte b2 = b;
		if (b2 == 15)
		{
			switch (endState)
			{
			case 1:
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, orgTemplateId, Config.SectMainStory.DefValue.Xuehou.GoodEndDateKey, time);
				break;
			case 2:
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, orgTemplateId, Config.SectMainStory.DefValue.Xuehou.BadEndDateKey, time);
				break;
			}
			DomainManager.World.FinishAllTaskInChain(context, 25);
			DomainManager.World.FinishAllTaskInChain(context, 26);
		}
	}

	public bool IsJixiFree()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(15);
		return DomainManager.Story.GetSectMainStoryTaskStatus(15) == 1 || sectArgBox.Contains<int>(Config.SectMainStory.DefValue.Xuehou.GoodEndDateKey);
	}

	[DomainMethod]
	public ItemKey RefiningWugKing(DataContext context)
	{
		List<int> costPoisons = ObjectPool<List<int>>.Instance.Get();
		SectWuxianWugJugData jugData = DomainManager.Extra.GetSectWuxianWugJugPoisons();
		sbyte wugKingType = SectMainStorySharedMethods.CalcWugKingType(costPoisons, jugData);
		ItemKey wugKingItemKey = ItemKey.Invalid;
		if (wugKingType < 0)
		{
			List<short> weights = ObjectPool<List<short>>.Instance.Get();
			foreach (WugKingItem wugKing in (IEnumerable<WugKingItem>)WugKing.Instance)
			{
				weights.Add(wugKing.RefiningWeight);
			}
			wugKingType = (sbyte)RandomUtils.GetRandomIndex(weights, context.Random);
			ObjectPool<List<short>>.Instance.Return(weights);
		}
		if (costPoisons.Sum() > 0)
		{
			for (sbyte i = 0; i < 6; i++)
			{
				jugData.ReducePoison(i, costPoisons[i]);
			}
			jugData.UpdateRefiningDate();
			WugKingItem wugKingConfig = WugKing.Instance[wugKingType];
			wugKingItemKey = DomainManager.Item.CreateMedicine(context, wugKingConfig.WugMedicine);
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			taiwu.GetInventory().OfflineAdd(wugKingItemKey, 1);
			taiwu.SetInventory(taiwu.GetInventory(), context);
		}
		DomainManager.Taiwu.RecordLifeSummary(context, 84);
		DomainManager.Extra.SetSectWuxianWugJugPoisons(jugData, context);
		ObjectPool<List<int>>.Instance.Return(costPoisons);
		return wugKingItemKey;
	}

	[DomainMethod]
	public bool DropPoisonsToWugJug(DataContext context, Inventory poisonMaterials)
	{
		if (poisonMaterials == null || poisonMaterials.InventoryItemTotalCount <= 0)
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory inventory = taiwu.GetInventory();
		ItemKey key;
		int value;
		foreach (KeyValuePair<ItemKey, int> item in poisonMaterials.Items)
		{
			item.Deconstruct(out key, out value);
			ItemKey material = key;
			if (!inventory.Items.ContainsKey(material))
			{
				return false;
			}
			if (!SectMainStorySharedMethods.CalcDropPoisonValue(material.GetData()).IsNonZero())
			{
				return false;
			}
		}
		SectWuxianWugJugData jugData = DomainManager.Extra.GetSectWuxianWugJugPoisons();
		List<IItemData> poisonMaterialsData = new List<IItemData>();
		foreach (KeyValuePair<ItemKey, int> item2 in poisonMaterials.Items)
		{
			item2.Deconstruct(out key, out value);
			ItemKey key2 = key;
			int value2 = value;
			for (int i = 0; i < value2; i++)
			{
				IItemData data = key2.GetData();
				poisonMaterialsData.Add(data);
			}
		}
		PoisonInts addPoisons = SectMainStorySharedMethods.CalcDropPoisonValue(jugData, poisonMaterialsData);
		taiwu.RemoveInventoryItem(context, poisonMaterials, deleteItem: true);
		for (sbyte i2 = 0; i2 < 6; i2++)
		{
			jugData.AddPoison(i2, addPoisons[i2]);
		}
		DomainManager.Extra.SetSectWuxianWugJugPoisons(jugData, context);
		return true;
	}

	public bool TryGetPrologueAddedWug(out int wugAdded)
	{
		wugAdded = -1;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianPrologueAddedWug, ref wugAdded);
	}

	public int GetWuxianChapterOneWishComeTrueCount()
	{
		int count = 0;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianChapter1WishComeTrueCount, ref count) ? count : 0;
	}

	public int GetWuxianChapterOneWishCount()
	{
		int count = 0;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianChapter1WishCount, ref count) ? count : 0;
	}

	public int GetWuxianHappyEndingEventDate()
	{
		int date = 0;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianChapter4HappyEndingEventDate, ref date) ? date : 0;
	}

	public static bool IsAbleToTriggerWuxianChapterThreeMail()
	{
		EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
		bool canStart = false;
		int count = 0;
		return permanentArgBox.Get(SectMainStoryEventArgKey.DefValue.WuxianChapter3AbleToStart, ref canStart) && canStart && (permanentArgBox.Get(SectMainStoryEventArgKey.DefValue.WuxianChapter3MailReceivedCount, ref count) ? count : 0) < 3;
	}

	public bool IsWuxianFinalBossBeaten()
	{
		EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
		bool isBeaten = false;
		return permanentArgBox.Get(SectMainStoryEventArgKey.DefValue.WuxianChapter4FinalBossBeaten, ref isBeaten) && isBeaten;
	}

	public bool IsWuxianTaiwuChanged()
	{
		int taiwuId = -1;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianPrologueTaiwuId, ref taiwuId) && taiwuId != DomainManager.Taiwu.GetTaiwuCharId();
	}

	public bool IsWuxianPrologueWugAttackedOnce()
	{
		bool attacked = false;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianPrologueWugAttacked, ref attacked) && attacked;
	}

	public void WuxianEndingProsperous(DataContext context)
	{
		EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
		permanentArgBox.Set(Config.SectMainStory.DefValue.Wuxian.GoodEndDateKey, DomainManager.World.GetCurrDate() + 1);
		permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4HappyEndingEventDate, DomainManager.World.GetCurrDate() + 3);
		permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4FinalBossBeaten, arg: true);
		permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4AdventureComplete, arg: false);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 12);
	}

	public void WuxianEndingFailing0(DataContext context)
	{
		EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
		permanentArgBox.Set(Config.SectMainStory.DefValue.Wuxian.BadEndDateKey, DomainManager.World.GetCurrDate() + 3);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 12);
	}

	public void WuxianEndingFailing1(DataContext context, bool isComplete)
	{
		EventArgBox permanentArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(12);
		permanentArgBox.Set(Config.SectMainStory.DefValue.Wuxian.BadEndDateKey, DomainManager.World.GetCurrDate() + 1);
		permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4FinalBossBeaten, arg: false);
		permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4AdventureComplete, isComplete);
		if (isComplete)
		{
			permanentArgBox.Set(SectMainStoryEventArgKey.DefValue.WuxianChapter4HappyEndingEventDate, DomainManager.World.GetCurrDate() + 3);
		}
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 12);
	}

	public bool IsWuxianEndingEventTriggered()
	{
		bool triggered = false;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(12).Get(SectMainStoryEventArgKey.DefValue.WuxianChapter4EndingEventTriggered, ref triggered) && triggered;
	}

	public bool IsTaiwuAtRanshanSettlement(bool settlementBlockOnly = false)
	{
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(7);
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		return settlementBlockOnly ? DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlementId) : DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, settlementId);
	}

	public bool IsRanshanSectMainStoryAbleToTrigger()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		int legendaryBookCount = 0;
		bool locationValid = false;
		if (taiwuLocation.IsValid())
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwuLocation.AreaId);
			locationValid = stateTemplateId == 7;
		}
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			if (DomainManager.Item.HasTrackedSpecialItems(12, (short)(240 + combatSkillType)))
			{
				legendaryBookCount++;
			}
		}
		return legendaryBookCount >= 3 && DomainManager.Story.CheckSectMainStoryAvailable(7) && locationValid && !MapAreaData.IsBrokenArea(taiwuLocation.AreaId) && DomainManager.Organization.GetSettlementByOrgTemplateId(7).CalcApprovingRate() >= 500;
	}

	public bool IsRanshanChapter1MonthlyEvent2AbleToTrigger()
	{
		if (!DomainManager.World.IsExtraTaskInProgress(258))
		{
			return false;
		}
		int count = GetRanshanChapter1MonthlyEventTriggeredCount();
		if (count >= 3)
		{
			return false;
		}
		Location location = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		MapAreaData areaData = DomainManager.Map.GetAreaByAreaId(location.AreaId);
		if (areaData.GetConfig().StateID != 7)
		{
			return false;
		}
		return DomainManager.World.GetCurrDate() - GetRanshanChapter1MonthlyEventTriggeredDate() >= 3;
	}

	public bool IsRanshanChapter1MonthlyEvent3AbleToTrigger()
	{
		return DomainManager.World.IsExtraTaskInProgress(260) && IsTaiwuAtRanshanSettlement(settlementBlockOnly: true);
	}

	public bool IsRanshanChapter2HuajuAbleToTrigger()
	{
		return DomainManager.World.IsExtraTaskInProgress(261) && DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(698) == null;
	}

	public bool IsRanshanChapter2XuanzhiAbleToTrigger()
	{
		return DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(698) != null && DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(699) == null;
	}

	public bool IsRanshanChapter2YingjiaoAbleToTrigger()
	{
		return DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(699) != null && DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(700) == null;
	}

	public bool IsRanshanChapter2MonthlyEventAbleToTrigger()
	{
		int startDate = 0;
		DomainManager.Extra.GetSectMainStoryEventArgBox(7).Get(SectMainStoryEventArgKey.DefValue.RanshanChapter2TeachStartDate, ref startDate);
		return DomainManager.World.IsExtraTaskChainInProgress(44) && (IsAllRanshanMenteeFinishedTeaching() || (DomainManager.Extra.GetSectMainStoryEventArgBox(7).Get(SectMainStoryEventArgKey.DefValue.RanshanChapter2TeachStartDate, ref startDate) && DomainManager.World.GetCurrDate() - startDate >= 24));
	}

	public bool IsAllRanshanMenteeFinishedTeaching()
	{
		foreach (short templateId in SectMainStoryRelatedConstants.RanshanThreeCorpsesCharacterTemplateIdList)
		{
			if (DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(templateId).Progress != 3)
			{
				return false;
			}
		}
		return true;
	}

	public int GetRanshanChapter1MonthlyEventTriggeredCount()
	{
		int count = 0;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(7).Get(SectMainStoryEventArgKey.DefValue.RanshanChapter1MonthlyEventTriggeredCount, ref count) ? count : 0;
	}

	public int GetRanshanChapter1MonthlyEventTriggeredDate()
	{
		int date = 0;
		return DomainManager.Extra.GetSectMainStoryEventArgBox(7).Get(SectMainStoryEventArgKey.DefValue.RanshanChapter1MonthlyEventTriggeredDate, ref date) ? date : 0;
	}

	public void UpdateRanshanThreeCorpsesAction(DataContext context)
	{
		if (DomainManager.Story.GetSectMainStoryTaskStatus(7) != 1)
		{
			return;
		}
		foreach (short templateId in SectMainStoryRelatedConstants.RanshanThreeCorpsesCharacterTemplateIdList)
		{
			SectStoryThreeCorpsesCharacter corpse = DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(templateId);
			if (corpse == null || !corpse.IsGoodEnd)
			{
				continue;
			}
			int currDate = DomainManager.World.GetCurrDate();
			if (corpse.Target < 0)
			{
				continue;
			}
			if (currDate >= corpse.NextDate)
			{
				if (DomainManager.LegendaryBook.GetOwner(corpse.Target) != corpse.TargetOwner)
				{
					DomainManager.Extra.ApplyRanshanThreeCorpsesLegendaryBookActionResult(context, templateId, 323, isSuccess: false);
				}
				else if (DomainManager.Extra.GetRanshanThreeCorpsesActionSucceed(context, templateId))
				{
					DomainManager.Extra.ApplyRanshanThreeCorpsesLegendaryBookActionResult(context, templateId, 314, isSuccess: true);
				}
				else
				{
					DomainManager.Extra.SetRanshanThreeCorpsesCharacterNextDate(context, templateId);
				}
			}
			if (currDate >= corpse.EndDate && corpse.EndDate >= 0)
			{
				DomainManager.Extra.ApplyRanshanThreeCorpsesLegendaryBookActionResult(context, templateId, 317, isSuccess: false);
			}
			DomainManager.Extra.SetRanshanThreeCorpsesCharacterLocation(context, templateId);
		}
		foreach (short templateId2 in SectMainStoryRelatedConstants.RanshanThreeCorpsesCharacterTemplateIdList)
		{
			SectStoryThreeCorpsesCharacter corpse2 = DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(templateId2);
			if (corpse2 != null && corpse2.IsGoodEnd && corpse2.Target >= 0 && DomainManager.LegendaryBook.GetOwner(corpse2.Target) != corpse2.TargetOwner)
			{
				DomainManager.Extra.ApplyRanshanThreeCorpsesLegendaryBookActionResult(context, templateId2, 323, isSuccess: false);
				DomainManager.Extra.SetRanshanThreeCorpsesCharacterLocation(context, templateId2);
			}
		}
	}

	public void ConvertRanshanFootman(DataContext context, bool isGoodEnd)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 697);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short value = FavorabilityType.GetRandomFavorability(context.Random, (sbyte)((!isGoodEnd) ? 1 : 6));
		DomainManager.Character.ConvertFixedCharacter(context, character, taiwu.GetLocation(), recreateAttributesAndQualifications: false);
		DomainManager.Character.DirectlySetFavorabilities(context, character.GetId(), taiwu.GetId(), value, value);
		if (isGoodEnd)
		{
			DomainManager.Organization.ChangeGrade(context, character, 5, destPrincipal: true);
		}
	}

	[DomainMethod]
	public bool DriveWugKing(DataContext context, int charId, sbyte wugType, sbyte driveType)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		sbyte slotIndex = character.GetWugKingSlotIndex(wugType);
		if (slotIndex < 0)
		{
			return false;
		}
		int currDate = DomainManager.World.GetCurrDate();
		if (!character.CanDriveWugKing(wugType, currDate))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		sbyte resourceType = GlobalConfig.Instance.WuxianDriveWugKingCostResourceType;
		int resourceCost = GlobalConfig.Instance.WuxianDriveWugKingCostResourceCount;
		if (taiwuChar.GetResource(resourceType) < resourceCost)
		{
			return false;
		}
		short actionPointCost = GlobalConfig.Instance.WuxianDriveWugKingCostActionPoint;
		if (!DomainManager.Extra.IsActionPointEnough(actionPointCost))
		{
			return false;
		}
		taiwuChar.ChangeResource(context, resourceType, -resourceCost);
		DomainManager.Extra.ConsumeActionPoint(context, actionPointCost);
		character.SetWugKingDriveData(context, wugType, driveType, currDate);
		ApplyWugKingImmediateEffect(context, character, wugType, driveType);
		return true;
	}

	[DomainMethod]
	public List<WugKingDriveDisplayData> GetWugKingDriveStatuses(int charId)
	{
		List<WugKingDriveDisplayData> displayDatas = new List<WugKingDriveDisplayData>();
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return displayDatas;
		}
		EatingItems eatingItems = character.GetEatingItems();
		HashSet<sbyte> seenWugTypes = new HashSet<sbyte>();
		for (int index = 0; index < 9; index++)
		{
			ItemKey itemKey = eatingItems.Get(index);
			if (EatingItems.IsWugKing(itemKey))
			{
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				if (seenWugTypes.Add(medicineCfg.WugType))
				{
					displayDatas.Add(GetWugKingDriveStatus(character, medicineCfg.WugType, itemKey));
				}
			}
		}
		return displayDatas;
	}

	private WugKingDriveDisplayData GetWugKingDriveStatus(GameData.Domains.Character.Character character, sbyte wugType, ItemKey itemKey)
	{
		int charId = character.GetId();
		WugKingDriveDisplayData displayData = new WugKingDriveDisplayData
		{
			CharacterId = charId,
			WugType = wugType,
			DriveType = 0,
			StartDate = 0,
			CanDrive = false,
			IsInEatingSlot = false
		};
		displayData.IsInEatingSlot = character.GetWugKingSlotIndex(wugType) >= 0;
		int currDate = DomainManager.World.GetCurrDate();
		displayData.CanDrive = character.CanDriveWugKing(wugType, currDate);
		if (character.TryGetWugKingDriveData(wugType, out var driveData))
		{
			displayData.DriveType = driveData.DriveType;
			displayData.StartDate = driveData.StartDate;
		}
		displayData.ItemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey, charId);
		return displayData;
	}

	private void ApplyWugKingImmediateEffect(DataContext context, GameData.Domains.Character.Character character, sbyte wugType, sbyte driveType)
	{
		bool isPositive = driveType == 1;
		switch (wugType)
		{
		case 1:
			ApplyForestSpiritEffect(context, character, isPositive);
			break;
		case 3:
			ApplyDevilInsideEffect(context, character, isPositive);
			break;
		case 4:
			ApplyCorpseWormEffect(context, character, isPositive);
			break;
		case 6:
			ApplyGoldenSilkwormEffect(context, character, isPositive);
			break;
		case 7:
			ApplyAzureMarrowEffect(context, character, isPositive);
			break;
		case 2:
		case 5:
			break;
		}
	}

	private void ApplyForestSpiritEffect(DataContext context, GameData.Domains.Character.Character character, bool isPositive)
	{
		Location location = character.GetLocation();
		if (!location.IsValid() || character.GetCreatingType() != 1)
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 1, includeCenter: true);
		charIds.Clear();
		charIds.AddRange(neighborBlocks.Where((MapBlockData x) => x.CharacterSet != null).SelectMany((MapBlockData x) => x.CharacterSet));
		charIds.Remove(character.GetId());
		short favorabilityDelta = (short)(isPositive ? 15000 : (-15000));
		foreach (int targetCharId in charIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar) && targetChar.GetCreatingType() == 1)
			{
				DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, character, favorabilityDelta);
				sbyte consummateLevel = targetChar.GetConsummateLevel();
				int disorderDelta = consummateLevel * 200;
				if (isPositive)
				{
					disorderDelta = -disorderDelta;
				}
				character.ChangeDisorderOfQi(context, disorderDelta);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	private void ApplyDevilInsideEffect(DataContext context, GameData.Domains.Character.Character character, bool isPositive)
	{
		int count = 0;
		int totalInfectionDelta = 0;
		HashSet<int> adoredCharIds = DomainManager.Character.GetRelatedCharIds(character.GetId(), 16384);
		count += adoredCharIds.Count;
		if (isPositive)
		{
			foreach (int adoredCharId in adoredCharIds)
			{
				short favorability = DomainManager.Character.GetFavorability(character.GetId(), adoredCharId);
				sbyte favorabilityType = FavorabilityType.GetFavorabilityType(favorability);
				totalInfectionDelta += -10 * Math.Abs((int)favorabilityType);
			}
		}
		HashSet<int> enemyCharIds = DomainManager.Character.GetRelatedCharIds(character.GetId(), 32768);
		count += enemyCharIds.Count;
		if (isPositive)
		{
			foreach (int enemyCharId in enemyCharIds)
			{
				short favorability2 = DomainManager.Character.GetFavorability(character.GetId(), enemyCharId);
				sbyte favorabilityType2 = FavorabilityType.GetFavorabilityType(favorability2);
				totalInfectionDelta += -10 * Math.Abs((int)favorabilityType2);
			}
		}
		int finalDelta = (isPositive ? totalInfectionDelta : (count * 20));
		byte currInfection = character.GetXiangshuInfection();
		byte newInfection = (byte)Math.Clamp(currInfection + finalDelta, 0, 255);
		character.SetXiangshuInfection(newInfection, context);
		character.UpdateXiangshuInfectionState(context);
	}

	private void ApplyCorpseWormEffect(DataContext context, GameData.Domains.Character.Character character, bool isPositive)
	{
		Injuries injuries = character.GetInjuries();
		List<sbyte> bodyParts = new List<sbyte>();
		if (isPositive)
		{
			for (sbyte i = 0; i < 7; i++)
			{
				var (outer, inner) = injuries.Get(i);
				if (outer > 0 || inner > 0)
				{
					bodyParts.Add(i);
				}
			}
			if (bodyParts.Count < 3)
			{
				for (sbyte i2 = 0; i2 < 7; i2++)
				{
					if (!bodyParts.Contains(i2))
					{
						bodyParts.Add(i2);
					}
				}
			}
		}
		else
		{
			for (sbyte i3 = 0; i3 < 7; i3++)
			{
				var (outer2, inner2) = injuries.Get(i3);
				if (outer2 < 6 || inner2 < 6)
				{
					bodyParts.Add(i3);
				}
			}
		}
		CollectionUtils.Shuffle(context.Random, bodyParts);
		List<sbyte> selectedParts = bodyParts.Take(Math.Min(3, bodyParts.Count)).ToList();
		foreach (sbyte bodyPart in selectedParts)
		{
			if (isPositive)
			{
				for (int j = 0; j < 4; j++)
				{
					injuries.Change(bodyPart, isInnerInjury: false, -1);
					injuries.Change(bodyPart, isInnerInjury: true, -1);
				}
			}
			else
			{
				for (int k = 0; k < 4; k++)
				{
					injuries.Change(bodyPart, isInnerInjury: false, 1);
					injuries.Change(bodyPart, isInnerInjury: true, 1);
				}
			}
		}
		character.SetInjuries(injuries, context);
	}

	private void ApplyGoldenSilkwormEffect(DataContext context, GameData.Domains.Character.Character character, bool isPositive)
	{
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 3, includeCenter: true);
		charIds.Clear();
		charIds.AddRange(neighborBlocks.Where((MapBlockData x) => x.CharacterSet != null).SelectMany((MapBlockData x) => x.CharacterSet));
		foreach (int targetCharId in charIds)
		{
			if (!DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				continue;
			}
			EatingItems eatingItems = targetChar.GetEatingItems();
			for (int i = 0; i < 9; i++)
			{
				ItemKey itemKey = eatingItems.Get(i);
				if (!EatingItems.IsValid(itemKey) || !EatingItems.IsWug(itemKey))
				{
					continue;
				}
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				sbyte wugType = medicineCfg.WugType;
				sbyte currentGrowthType = medicineCfg.WugGrowthType;
				if (currentGrowthType >= 4)
				{
					continue;
				}
				sbyte targetGrowthType;
				if (isPositive)
				{
					if (currentGrowthType == 2)
					{
						targetGrowthType = 0;
					}
					else
					{
						if (currentGrowthType != 3)
						{
							continue;
						}
						targetGrowthType = 1;
					}
				}
				else if (currentGrowthType == 0)
				{
					targetGrowthType = 2;
				}
				else
				{
					if (currentGrowthType != 1)
					{
						continue;
					}
					targetGrowthType = 3;
				}
				short targetTemplateId = ItemDomain.GetWugTemplateId(wugType, targetGrowthType);
				targetChar.AddWug(context, targetTemplateId, -1);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	private void ApplyAzureMarrowEffect(DataContext context, GameData.Domains.Character.Character character, bool isPositive)
	{
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<int> charIds = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 1, includeCenter: true);
		charIds.Clear();
		charIds.AddRange(neighborBlocks.Where((MapBlockData x) => x.CharacterSet != null).SelectMany((MapBlockData x) => x.CharacterSet));
		charIds.Remove(character.GetId());
		if (charIds.Count == 0)
		{
			ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
			ObjectPool<List<int>>.Instance.Return(charIds);
			return;
		}
		List<(int, short)> targetList = new List<(int, short)>();
		foreach (int targetCharId in charIds)
		{
			short favorability = DomainManager.Character.GetFavorability(character.GetId(), targetCharId);
			targetList.Add((targetCharId, favorability));
		}
		if (isPositive)
		{
			targetList.Sort(((int charId, short favorability) a, (int charId, short favorability) b) => a.favorability.CompareTo(b.favorability));
		}
		else
		{
			targetList.Sort(((int charId, short favorability) a, (int charId, short favorability) b) => b.favorability.CompareTo(a.favorability));
		}
		List<(int, short)> selectedTargets = targetList.Take(Math.Min(3, targetList.Count)).ToList();
		short favorabilityDelta = (short)(isPositive ? 15000 : (-15000));
		foreach (var item in selectedTargets)
		{
			int targetCharId2 = item.Item1;
			if (DomainManager.Character.TryGetElement_Objects(targetCharId2, out var targetChar))
			{
				DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, character, targetChar, favorabilityDelta);
				if (isPositive)
				{
					DomainManager.Character.TryAddAndApplyOneWayRelation(context, character.GetId(), targetChar.GetId(), 16384);
				}
				else
				{
					DomainManager.Character.TryAddAndApplyOneWayRelation(context, character.GetId(), targetChar.GetId(), 32768);
				}
			}
		}
		ObjectPool<List<int>>.Instance.Return(charIds);
	}

	private void AdvanceMonth_SectMainStory_Common(DataContext context, sbyte orgTemplateId)
	{
		if (!DomainManager.Story.TryTriggerSectMainStoryEndingMonthlyEvent(orgTemplateId))
		{
		}
	}

	public void OnAdvanceMonthMainStory(DataContext context)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		if (!argBox.Contains<short>("MainStoryEndingLine"))
		{
			return;
		}
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		short endingLine = argBox.GetShort("MainStoryEndingLine");
		int currAliveTwelveCount = DomainManager.Story.CurrAliveTwelveImmortalsTotalCount();
		if (currAliveTwelveCount > 3 || currAliveTwelveCount < 0)
		{
			return;
		}
		List<short> defaultTemplateIdList = GetCurrAliveTwelveImmortalsTemplateIdList(0);
		if (defaultTemplateIdList.Count > 0)
		{
			short templateId = defaultTemplateIdList.First();
			TwelveImmortalsStatus immortals = _twelveImmortalsStatuses[templateId];
			switch (endingLine)
			{
			case 0:
			{
				GameData.Domains.Character.Character assist2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, immortals.AssistCharacterTemplateId);
				monthlyEventCollection.AddMainStoryMessagefromtheAvatar(immortals.CharacterId, assist2.GetId());
				break;
			}
			case 1:
			{
				GameData.Domains.Character.Character assist = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, immortals.AssistCharacterTemplateId);
				monthlyEventCollection.AddMainStoryMessagefromanOldFriend(immortals.CharacterId, assist.GetId());
				break;
			}
			default:
				monthlyEventCollection.AddMainStoryMessagefromWunian(immortals.CharacterId);
				break;
			}
		}
		List<short> agreeTemplateIdList = GetCurrAliveTwelveImmortalsTemplateIdList(2);
		if (agreeTemplateIdList.Count > 0)
		{
			short templateId2 = agreeTemplateIdList.First();
			TwelveImmortalsStatus immortals2 = _twelveImmortalsStatuses[templateId2];
			switch (endingLine)
			{
			case 0:
			{
				GameData.Domains.Character.Character assist4 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, immortals2.AssistCharacterTemplateId);
				monthlyEventCollection.AddMainStoryTidingsonSwiftBlades(immortals2.CharacterId, assist4.GetId());
				break;
			}
			case 1:
			{
				GameData.Domains.Character.Character assist3 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, immortals2.AssistCharacterTemplateId);
				monthlyEventCollection.AddMainStoryTidingsfromanOldFriend(immortals2.CharacterId, assist3.GetId());
				break;
			}
			default:
				monthlyEventCollection.AddMainStoryTidingsoftheMind(immortals2.CharacterId);
				break;
			}
		}
	}

	private void InitializeBaihuaLinkedCharacters(DataContext context)
	{
		_baihuaLinkedCharacters = new Dictionary<int, (int, bool)>();
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		if (!lifeLinkData.IsInitialized())
		{
			_baihuaLifeLinkNeiliType = -1;
			lifeLinkData.Initialize();
			DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeLinkData, context);
			return;
		}
		_baihuaLifeLinkNeiliType = CalcBaihuaLifeLinkNeiliType();
		for (int i = 0; i < lifeLinkData.LifeGateCharIds.Length; i++)
		{
			int charId = lifeLinkData.LifeGateCharIds[i];
			if (charId >= 0)
			{
				_baihuaLinkedCharacters.Add(charId, (i, true));
			}
		}
		for (int j = 0; j < lifeLinkData.DeathGateCharIds.Length; j++)
		{
			int charId2 = lifeLinkData.DeathGateCharIds[j];
			if (charId2 >= 0)
			{
				_baihuaLinkedCharacters.Add(charId2, (j, false));
			}
		}
	}

	public void UpgradeBaihuaLifeLink(DataContext context)
	{
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		lifeLinkData.Upgrade();
		DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeLinkData, context);
	}

	[DomainMethod]
	public sbyte GetBaihuaLifeLinkNeiliType()
	{
		return _baihuaLifeLinkNeiliType;
	}

	[DomainMethod]
	public SectBaihuaLifeLinkDisplayData GetSectBaihuaLifeLinkDisplayData(DataContext context)
	{
		SectBaihuaLifeLinkDisplayData res = new SectBaihuaLifeLinkDisplayData
		{
			Data = DomainManager.Extra.GetSectBaihuaLifeLinkData(),
			CharacterDisplayData = new Dictionary<int, CharacterDisplayDataForLifeLink>(),
			NeiliType = _baihuaLifeLinkNeiliType
		};
		int[] lifeGateCharIds = res.Data.LifeGateCharIds;
		foreach (int charId in lifeGateCharIds)
		{
			if (charId >= 0 && DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				res.CharacterDisplayData[charId] = DomainManager.Character.GetCharacterDisplayDataForBaihuaLifeLink(context, character);
			}
		}
		int[] deathGateCharIds = res.Data.DeathGateCharIds;
		foreach (int charId2 in deathGateCharIds)
		{
			if (charId2 >= 0 && DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
			{
				res.CharacterDisplayData[charId2] = DomainManager.Character.GetCharacterDisplayDataForBaihuaLifeLink(context, character2);
			}
		}
		return res;
	}

	[DomainMethod]
	public void SetLifeLinkCharacter(DataContext context, int charId, int index, bool isLifeGate)
	{
		Logger.Info($"Setting life link character {charId}: isLifeGate = {isLifeGate}, index = {index}");
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		int[] charList = (isLifeGate ? lifeLinkData.LifeGateCharIds : lifeLinkData.DeathGateCharIds);
		int prevCharId = charList[index];
		if (prevCharId >= 0)
		{
			_baihuaLinkedCharacters.Remove(prevCharId);
			if (_baihuaLifeLinkNeiliType >= 0)
			{
				GameData.Domains.Character.Character prevChar = DomainManager.Character.GetElement_Objects(prevCharId);
				NeiliTypeItem neiliTypeCfg = NeiliType.Instance[_baihuaLifeLinkNeiliType];
				short[] features = (isLifeGate ? neiliTypeCfg.LifeGateFeatures : neiliTypeCfg.DeathGateFeatures);
				if (features != null)
				{
					for (int i = 0; i < features.Length; i++)
					{
						prevChar.RemoveFeature(context, features[i]);
					}
				}
			}
		}
		charList[index] = charId;
		DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeLinkData, context);
		bool neiliTypeChanged = UpdateBaihuaLifeLinkNeiliType(context);
		if (charId < 0)
		{
			return;
		}
		_baihuaLinkedCharacters.Add(charId, (index, isLifeGate));
		if (neiliTypeChanged || _baihuaLifeLinkNeiliType < 0)
		{
			return;
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		NeiliTypeItem neiliTypeCfg2 = NeiliType.Instance[_baihuaLifeLinkNeiliType];
		short[] features2 = (isLifeGate ? neiliTypeCfg2.LifeGateFeatures : neiliTypeCfg2.DeathGateFeatures);
		if (features2 != null)
		{
			for (int j = 0; j < features2.Length; j++)
			{
				character.AddFeature(context, features2[j]);
			}
		}
	}

	public void TryRemoveLifeLinkCharacter(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		if (!_baihuaLinkedCharacters.TryGetValue(charId, out (int, bool) info))
		{
			return;
		}
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		int[] charList = (info.Item2 ? lifeLinkData.LifeGateCharIds : lifeLinkData.DeathGateCharIds);
		charList[info.Item1] = -1;
		lifeLinkData.Cooldown = GlobalConfig.Instance.BaihuaLifeLinkRemoveCharacterCooldown;
		_baihuaLinkedCharacters.Remove(charId);
		if (_baihuaLifeLinkNeiliType >= 0 && DomainManager.Character.IsCharacterAlive(charId))
		{
			NeiliTypeItem neiliTypeCfg = NeiliType.Instance[_baihuaLifeLinkNeiliType];
			short[] lifeGateFeatures = neiliTypeCfg.LifeGateFeatures;
			foreach (short featureId in lifeGateFeatures)
			{
				character.RemoveFeature(context, featureId);
			}
		}
		DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeLinkData, context);
		UpdateBaihuaLifeLinkNeiliType(context);
	}

	private void UpdateBaihuaFixedCharacterLocations(DataContext context, int charId)
	{
		int currDate = DomainManager.World.GetCurrDate();
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		int date = int.MaxValue;
		if (!sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLMTransferAnimalDate, ref date) || date != currDate)
		{
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLMTransferAnimalDate, currDate);
			GameData.Domains.Character.Character leukorpus = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 580);
			GameData.Domains.Character.Character melanpsyche = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 585);
			GameData.Domains.Character.Character leukoDeer = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 573);
			GameData.Domains.Character.Character melanoOwl = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 574);
			if (leukorpus.GetLocation().IsValid())
			{
				Events.RaiseFixedCharacterLocationChanged(context, leukoDeer.GetId(), leukoDeer.GetLocation(), leukorpus.GetLocation());
				leukoDeer.SetLocation(leukorpus.GetLocation(), context);
				Events.RaiseFixedCharacterLocationChanged(context, melanoOwl.GetId(), melanoOwl.GetLocation(), melanpsyche.GetLocation());
				melanoOwl.SetLocation(melanpsyche.GetLocation(), context);
				Events.RaiseFixedCharacterLocationChanged(context, leukorpus.GetId(), leukorpus.GetLocation(), Location.Invalid);
				leukorpus.SetLocation(Location.Invalid, context);
				Events.RaiseFixedCharacterLocationChanged(context, melanpsyche.GetId(), melanpsyche.GetLocation(), Location.Invalid);
				melanpsyche.SetLocation(Location.Invalid, context);
				InstantNotificationCollection instantCollection = DomainManager.World.GetInstantNotificationCollection();
				instantCollection.AddSectStoryBaihuaToAnimal(charId);
			}
		}
	}

	public bool UpdateBaihuaLifeLinkNeiliType(DataContext context)
	{
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		if (!lifeLinkData.IsInitialized())
		{
			return false;
		}
		sbyte newLifeLinkNeiliType = CalcBaihuaLifeLinkNeiliType();
		if (newLifeLinkNeiliType == _baihuaLifeLinkNeiliType)
		{
			return false;
		}
		if (_baihuaLifeLinkNeiliType >= 0)
		{
			NeiliTypeItem neiliTypeCfg = NeiliType.Instance[_baihuaLifeLinkNeiliType];
			int[] lifeGateCharIds = lifeLinkData.LifeGateCharIds;
			foreach (int lifeGateCharId in lifeGateCharIds)
			{
				if (lifeGateCharId >= 0)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(lifeGateCharId);
					short[] lifeGateFeatures = neiliTypeCfg.LifeGateFeatures;
					foreach (short featureId in lifeGateFeatures)
					{
						character.RemoveFeature(context, featureId);
					}
				}
			}
			int[] deathGateCharIds = lifeLinkData.DeathGateCharIds;
			foreach (int deathGateCharId in deathGateCharIds)
			{
				if (deathGateCharId >= 0)
				{
					GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(deathGateCharId);
					short[] deathGateFeatures = neiliTypeCfg.DeathGateFeatures;
					foreach (short featureId2 in deathGateFeatures)
					{
						character2.RemoveFeature(context, featureId2);
					}
				}
			}
		}
		if (newLifeLinkNeiliType >= 0)
		{
			NeiliTypeItem neiliTypeCfg2 = NeiliType.Instance[newLifeLinkNeiliType];
			int[] lifeGateCharIds2 = lifeLinkData.LifeGateCharIds;
			foreach (int lifeGateCharId2 in lifeGateCharIds2)
			{
				if (lifeGateCharId2 >= 0)
				{
					GameData.Domains.Character.Character character3 = DomainManager.Character.GetElement_Objects(lifeGateCharId2);
					short[] lifeGateFeatures2 = neiliTypeCfg2.LifeGateFeatures;
					foreach (short featureId3 in lifeGateFeatures2)
					{
						character3.AddFeature(context, featureId3);
					}
				}
			}
			int[] deathGateCharIds2 = lifeLinkData.DeathGateCharIds;
			foreach (int deathGateCharId2 in deathGateCharIds2)
			{
				if (deathGateCharId2 >= 0)
				{
					GameData.Domains.Character.Character character4 = DomainManager.Character.GetElement_Objects(deathGateCharId2);
					short[] deathGateFeatures2 = neiliTypeCfg2.DeathGateFeatures;
					foreach (short featureId4 in deathGateFeatures2)
					{
						character4.AddFeature(context, featureId4);
					}
				}
			}
		}
		_baihuaLifeLinkNeiliType = newLifeLinkNeiliType;
		if (DomainManager.World.GetAdvancingMonthState() != 0 && !_sectMainStoryLifeLinkUpdated)
		{
			_sectMainStoryLifeLinkUpdated = true;
			DomainManager.World.GetMonthlyNotificationCollection().AddFiveElementsChange();
		}
		return true;
	}

	private sbyte CalcBaihuaLifeLinkNeiliType()
	{
		SectBaihuaLifeLinkData lifeLinkData = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		Span<NeiliProportionOfFiveElements> span = stackalloc NeiliProportionOfFiveElements[lifeLinkData.LifeGateCharIds.Length + lifeLinkData.DeathGateCharIds.Length];
		SpanList<NeiliProportionOfFiveElements> spanList = span;
		int lifeGateCount = 0;
		int[] lifeGateCharIds = lifeLinkData.LifeGateCharIds;
		foreach (int charId in lifeGateCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				NeiliProportionOfFiveElements fiveElements = character.GetNeiliProportionOfFiveElements();
				spanList.Add(fiveElements);
				lifeGateCount++;
			}
		}
		if (lifeGateCount == 0)
		{
			return -1;
		}
		int deathGateCount = 0;
		int[] deathGateCharIds = lifeLinkData.DeathGateCharIds;
		foreach (int charId2 in deathGateCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
			{
				NeiliProportionOfFiveElements fiveElements2 = character2.GetNeiliProportionOfFiveElements();
				spanList.Add(fiveElements2);
				deathGateCount++;
			}
		}
		if (deathGateCount == 0)
		{
			return -1;
		}
		NeiliProportionOfFiveElements proportionOfFiveElements = NeiliProportionOfFiveElements.GetTotal(spanList);
		return proportionOfFiveElements.GetNeiliType(DomainManager.World.GetCurrMonthInYear());
	}

	public void UpdateLifeDeathGateCharacters(DataContext context)
	{
		SectBaihuaLifeLinkData lifeDeathGate = DomainManager.Extra.GetSectBaihuaLifeLinkData();
		if (lifeDeathGate == null || !lifeDeathGate.IsInitialized())
		{
			return;
		}
		if (lifeDeathGate.Cooldown > 0)
		{
			lifeDeathGate.Cooldown--;
			DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeDeathGate, context);
			if (lifeDeathGate.Cooldown >= 0)
			{
				return;
			}
		}
		_tmpLifeGateChars.Clear();
		int[] lifeGateCharIds = lifeDeathGate.LifeGateCharIds;
		foreach (int lifeGateCharId in lifeGateCharIds)
		{
			if (lifeGateCharId >= 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(lifeGateCharId);
				short health = character.GetHealth();
				short maxHealth = character.GetLeftMaxHealth();
				if (health < maxHealth)
				{
					_tmpLifeGateChars.Add((character, health, maxHealth));
				}
			}
		}
		int distributableHealth = 0;
		_tmpDeathGateChars.Clear();
		int[] deathGateCharIds = lifeDeathGate.DeathGateCharIds;
		foreach (int deathGateCharId in deathGateCharIds)
		{
			if (deathGateCharId >= 0)
			{
				GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(deathGateCharId);
				short health2 = character2.GetHealth();
				if (health2 > 0)
				{
					distributableHealth += health2;
					_tmpDeathGateChars.Add((character2, health2));
				}
			}
		}
		if (_tmpLifeGateChars.Count == 0 || _tmpDeathGateChars.Count == 0)
		{
			return;
		}
		IRandomSource random = context.Random;
		Span<int> span = stackalloc int[8];
		SpanList<int> modifiedLifeGateCharIds = span;
		span = stackalloc int[8];
		SpanList<int> modifiedDeathGateCharIds = span;
		while (_tmpLifeGateChars.Count > 0 && _tmpDeathGateChars.Count > 0)
		{
			int lifeGateCharIndex = random.Next(_tmpLifeGateChars.Count);
			(GameData.Domains.Character.Character, int, int) lifeGateChar = _tmpLifeGateChars[lifeGateCharIndex];
			int lifeGateNeedHealth = Math.Min(lifeGateChar.Item3 - lifeGateChar.Item2, distributableHealth);
			int distributedHealth = 0;
			for (int i2 = _tmpDeathGateChars.Count - 1; i2 >= 0; i2--)
			{
				(GameData.Domains.Character.Character, int) deathGateChar = _tmpDeathGateChars[i2];
				int transferHealth = lifeGateNeedHealth * deathGateChar.Item2 / distributableHealth;
				if (transferHealth > 0)
				{
					deathGateChar.Item2 -= transferHealth;
					lifeGateChar.Item2 += transferHealth;
					distributedHealth += transferHealth;
					if (deathGateChar.Item2 <= 0)
					{
						CollectionUtils.SwapAndRemove(_tmpDeathGateChars, i2);
						deathGateChar.Item1.SetHealth(0, context);
						int deathGateCharId2 = deathGateChar.Item1.GetId();
						modifiedDeathGateCharIds.Add(deathGateCharId2);
						UpdateBaihuaFixedCharacterLocations(context, deathGateCharId2);
						lifeDeathGate.Cooldown = GlobalConfig.Instance.BaihuaLifeLinkRemoveCharacterCooldown;
					}
					else
					{
						_tmpDeathGateChars[i2] = deathGateChar;
					}
				}
			}
			if (lifeGateChar.Item2 < lifeGateChar.Item3)
			{
				lifeGateNeedHealth = lifeGateChar.Item3 - lifeGateChar.Item2;
				while (lifeGateNeedHealth > 0 && _tmpDeathGateChars.Count > 0)
				{
					int deathGateCharIndex = random.Next(_tmpDeathGateChars.Count);
					(GameData.Domains.Character.Character, int) deathGateChar2 = _tmpDeathGateChars[deathGateCharIndex];
					int transferredHealth = Math.Min(lifeGateNeedHealth, deathGateChar2.Item2);
					lifeGateChar.Item2 += transferredHealth;
					deathGateChar2.Item2 -= transferredHealth;
					lifeGateNeedHealth -= transferredHealth;
					distributedHealth += transferredHealth;
					if (deathGateChar2.Item2 <= 0)
					{
						CollectionUtils.SwapAndRemove(_tmpDeathGateChars, deathGateCharIndex);
						deathGateChar2.Item1.SetHealth(0, context);
						int deathGateCharId3 = deathGateChar2.Item1.GetId();
						modifiedDeathGateCharIds.Add(deathGateCharId3);
						UpdateBaihuaFixedCharacterLocations(context, deathGateCharId3);
						lifeDeathGate.Cooldown = GlobalConfig.Instance.BaihuaLifeLinkRemoveCharacterCooldown;
					}
					else
					{
						_tmpDeathGateChars[deathGateCharIndex] = deathGateChar2;
					}
				}
			}
			lifeGateChar.Item1.SetHealth((short)lifeGateChar.Item2, context);
			CollectionUtils.SwapAndRemove(_tmpLifeGateChars, lifeGateCharIndex);
			modifiedLifeGateCharIds.Add(lifeGateChar.Item1.GetId());
			Tester.Assert(distributedHealth <= distributableHealth);
			distributableHealth -= distributedHealth;
		}
		foreach (var deathGateChar3 in _tmpDeathGateChars)
		{
			short prevHealth = deathGateChar3.character.GetHealth();
			int currHealth = deathGateChar3.distributableHealth;
			if (prevHealth != currHealth)
			{
				deathGateChar3.character.SetHealth((short)currHealth, context);
				modifiedDeathGateCharIds.Add(deathGateChar3.character.GetId());
			}
		}
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		for (int k = 0; k < modifiedLifeGateCharIds.Count; k++)
		{
			monthlyNotifications.AddLifeLinkHealing(modifiedLifeGateCharIds[k]);
		}
		for (int l = 0; l < modifiedDeathGateCharIds.Count; l++)
		{
			monthlyNotifications.AddLifeLinkDamage(modifiedDeathGateCharIds[l]);
		}
		DomainManager.Extra.SetSectBaihuaLifeLinkData(lifeDeathGate, context);
	}

	public IntList BaihuaGetSpecialDebuffIntList()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaSpecialDebuffIntList, out IntList list);
		return list;
	}

	public void BaihuaAddCharIdToSpecialDebuffIntList(DataContext context, int charId)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaSpecialDebuffIntList, out IntList list);
		ref List<int> items = ref list.Items;
		if (items == null)
		{
			items = new List<int>();
		}
		list.Items.Add(charId);
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaSpecialDebuffIntList, list);
	}

	public IntList BaihuaGetCureSpecialDebuffIntList()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaCureSpecialDebuffIntList, out IntList list);
		return list;
	}

	public void BaihuaAddCharIdToCureSpecialDebuffIntList(DataContext context, int charId)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaCureSpecialDebuffIntList, out IntList list);
		ref List<int> items = ref list.Items;
		if (items == null)
		{
			items = new List<int>();
		}
		list.Items.Add(charId);
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaCureSpecialDebuffIntList, list);
	}

	public void BaihuaRemoveCharIdToCureSpecialDebuffIntList(DataContext context, int charId)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaCureSpecialDebuffIntList, out IntList list);
		if (list.Items != null)
		{
			list.Items.Remove(charId);
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaCureSpecialDebuffIntList, list);
		}
	}

	public short BaihuaSelectSettlementId(DataContext context, bool avoidGuangnan, bool avoidTaiwuVillageArea)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		List<short> areasCanSelect = ObjectPool<List<short>>.Instance.Get();
		List<short> areas = ObjectPool<List<short>>.Instance.Get();
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		for (short stateTemplateId = 1; stateTemplateId <= 15; stateTemplateId++)
		{
			areas.Clear();
			if (!avoidGuangnan || stateTemplateId != 3)
			{
				sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(stateTemplateId);
				DomainManager.Map.GetAllRegularAreaInState(stateId, areas);
				for (int i = 0; i < areas.Count; i++)
				{
					if (!DomainManager.Map.IsAreaBroken(areas[i]))
					{
						areasCanSelect.Add(areas[i]);
					}
				}
			}
		}
		if (avoidTaiwuVillageArea)
		{
			areasCanSelect.Remove(taiwuVillageLocation.AreaId);
		}
		short areaSelected = areasCanSelect.GetRandom(context.Random);
		DomainManager.Map.GetAreaSettlementIds(areaSelected, settlementIds, containsMainCity: true, containsSect: true);
		short settlementId = settlementIds.GetRandom(context.Random);
		ObjectPool<List<short>>.Instance.Return(areasCanSelect);
		ObjectPool<List<short>>.Instance.Return(areas);
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return settlementId;
	}

	public List<short> BaihuaSelectSettlementIds(DataContext context, bool avoidGuangnan, bool avoidTaiwuVillageArea, int needCount)
	{
		int count = 0;
		List<short> settlementIds = new List<short>();
		while (settlementIds.Count < needCount && count < 10000)
		{
			short settlementId = BaihuaSelectSettlementId(context, avoidGuangnan, avoidTaiwuVillageArea);
			if (!settlementIds.Contains(settlementId))
			{
				settlementIds.Add(settlementId);
			}
			count++;
		}
		return settlementIds;
	}

	public short BaihuaSelectSettlementIdNeighborTaiwuVillage(DataContext context)
	{
		Location taiwuVillageLocation = DomainManager.Taiwu.GetTaiwuVillageLocation();
		sbyte taiwuVillageStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwuVillageLocation.AreaId);
		sbyte taiwuVillageStateId = DomainManager.Map.GetStateIdByAreaId(taiwuVillageLocation.AreaId);
		MapStateItem config = MapState.Instance[taiwuVillageStateTemplateId];
		List<short> areasCanSelect = ObjectPool<List<short>>.Instance.Get();
		List<short> areas = ObjectPool<List<short>>.Instance.Get();
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		short leukoSettlementId = -1;
		sbyte leukoStateId = -1;
		argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, ref leukoSettlementId);
		short melanoSettlementId = -1;
		sbyte melanoStateId = -1;
		argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, ref melanoSettlementId);
		if (leukoSettlementId != -1)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(leukoSettlementId);
			leukoStateId = DomainManager.Map.GetStateIdByAreaId(settlement.GetLocation().AreaId);
		}
		if (melanoSettlementId != -1)
		{
			Settlement settlement2 = DomainManager.Organization.GetSettlement(melanoSettlementId);
			melanoStateId = DomainManager.Map.GetStateIdByAreaId(settlement2.GetLocation().AreaId);
		}
		for (int i = 0; i < config.NeighborStates.Length; i++)
		{
			areas.Clear();
			if (config.NeighborStates[i] == 3)
			{
				continue;
			}
			sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(config.NeighborStates[i]);
			if (stateId == leukoStateId || stateId == melanoStateId)
			{
				continue;
			}
			DomainManager.Map.GetAllRegularAreaInState(stateId, areas);
			for (int j = 0; j < areas.Count; j++)
			{
				if (!DomainManager.Map.IsAreaBroken(areas[j]))
				{
					areasCanSelect.Add(areas[j]);
				}
			}
		}
		if (areasCanSelect.Count == 0)
		{
			short usedSettlementId = ((leukoSettlementId > 0) ? leukoSettlementId : melanoSettlementId);
			Settlement settlement3 = DomainManager.Organization.GetSettlement(usedSettlementId);
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlement3.GetLocation().AreaId);
			MapStateItem stateConfig = MapState.Instance[stateTemplateId];
			for (int k = 0; k < stateConfig.NeighborStates.Length; k++)
			{
				areas.Clear();
				if (stateConfig.NeighborStates[k] == 3)
				{
					continue;
				}
				sbyte stateId2 = DomainManager.Map.GetStateIdByStateTemplateId(stateConfig.NeighborStates[k]);
				if (stateId2 == taiwuVillageStateId)
				{
					continue;
				}
				DomainManager.Map.GetAllRegularAreaInState(stateId2, areas);
				for (int l = 0; l < areas.Count; l++)
				{
					if (!DomainManager.Map.IsAreaBroken(areas[l]))
					{
						areasCanSelect.Add(areas[l]);
					}
				}
			}
		}
		short areaSelected = areasCanSelect.GetRandom(context.Random);
		DomainManager.Map.GetAreaSettlementIds(areaSelected, settlementIds, containsMainCity: true, containsSect: true);
		short settlementId = settlementIds.GetRandom(context.Random);
		ObjectPool<List<short>>.Instance.Return(areasCanSelect);
		ObjectPool<List<short>>.Instance.Return(areas);
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return settlementId;
	}

	public void CallBaihuaMember(DataContext context, bool isLeuko)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		short settlementId = -1;
		IntList charIdIntList;
		if (isLeuko)
		{
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsCalledCharIds, out charIdIntList);
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsMonthEventSettlementId, ref settlementId);
		}
		else
		{
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsCalledCharIds, out charIdIntList);
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsMonthEventSettlementId, ref settlementId);
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		if (charIdIntList.Items == null)
		{
			charIdIntList = IntList.Create();
		}
		if (!HaveAliveMember(charIdIntList.Items))
		{
			Settlement baihuaSettlement = DomainManager.Organization.GetSettlementByOrgTemplateId(3);
			List<int> members = ObjectPool<List<int>>.Instance.Get();
			for (sbyte grade = 0; grade <= 5; grade++)
			{
				members.AddRange(baihuaSettlement.GetMembers().GetMembers(grade));
			}
			for (int i = members.Count - 1; i >= 0; i--)
			{
				if (DomainManager.Character.TryGetElement_Objects(members[i], out var character))
				{
					if (!character.IsInteractableAsIntelligentCharacter() || character.GetAgeGroup() != 2)
					{
						members.RemoveAt(i);
					}
				}
				else
				{
					members.RemoveAt(i);
				}
			}
			int count = context.Random.Next(1, 4);
			CollectionUtils.Shuffle(context.Random, members);
			for (int j = 0; j < Math.Min(count, members.Count); j++)
			{
				int selectCharId = members[j];
				charIdIntList.Items.Add(selectCharId);
				if (DomainManager.Character.TryGetElement_Objects(selectCharId, out var character2))
				{
					DomainManager.Character.GroupMove(context, character2, settlement.GetLocation());
					character2.ActiveExternalRelationState(context, 64uL);
				}
			}
			ObjectPool<List<int>>.Instance.Return(members);
			if (isLeuko)
			{
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsCalledCharIds, charIdIntList);
			}
			else
			{
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsCalledCharIds, charIdIntList);
			}
			return;
		}
		for (int k = 0; k < charIdIntList.Items.Count; k++)
		{
			if (DomainManager.Character.TryGetElement_Objects(charIdIntList.Items[k], out var character3))
			{
				DomainManager.Character.GroupMove(context, character3, settlement.GetLocation());
				character3.ActiveExternalRelationState(context, 64uL);
			}
		}
		static bool HaveAliveMember(List<int> list)
		{
			for (int l = 0; l < list.Count; l++)
			{
				if (DomainManager.Character.TryGetElement_Objects(list[l], out var _))
				{
					return true;
				}
			}
			return false;
		}
	}

	public void BaihuaClearCalledCharacters(DataContext context, bool isLeuko)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		IntList charIdIntList;
		if (isLeuko)
		{
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsCalledCharIds, out charIdIntList);
		}
		else
		{
			argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsCalledCharIds, out charIdIntList);
		}
		if (charIdIntList.Items == null)
		{
			return;
		}
		for (int i = 0; i < charIdIntList.Items.Count; i++)
		{
			if (DomainManager.Character.TryGetElement_Objects(charIdIntList.Items[i], out var character))
			{
				character.DeactivateExternalRelationState(context, 64uL);
			}
		}
	}

	public int BaihuaGroupMeetCount(bool isLeuko, out int groupId)
	{
		groupId = -1;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		sbyte neiliType = -1;
		if (isLeuko)
		{
			sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaLeukoKillsFiveElementsType, ref neiliType);
		}
		else
		{
			sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaMelanoKillsFiveElementsType, ref neiliType);
		}
		HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		int sum = 0;
		foreach (int charId in groupCharIds)
		{
			if (charId != taiwu.GetId() && DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetAgeGroup() >= 2)
			{
				NeiliTypeItem config = NeiliType.Instance[character.GetNeiliType()];
				if (config.FiveElements == neiliType)
				{
					groupId = character.GetId();
					sum++;
				}
			}
		}
		return sum;
	}

	[DomainMethod]
	public bool EmeiTransferBonusProgress(DataContext context, short bonusTemplateId, List<ItemKey> itemKeys)
	{
		if (!TryGetElement_SectEmeiBreakBonusData(bonusTemplateId, out var data))
		{
			return false;
		}
		IEnumerable<IItemData> itemData = itemKeys.Select(ItemKeyHelper.GetData);
		int progress = SectMainStorySharedMethods.CalcEmeiBonusItemProgress(bonusTemplateId, itemData);
		DomainManager.Taiwu.RemoveItem(context, itemKeys, ItemSourceType.Inventory, deleteItem: true);
		data.OfflineAddProgress(progress);
		SetElement_SectEmeiBreakBonusData(bonusTemplateId, data, context);
		return true;
	}

	[DomainMethod]
	public SectEmeiSpecialBreakDisplayData GetSectEmeiSpecialBreakDisplayData()
	{
		SectEmeiSpecialBreakDisplayData res = new SectEmeiSpecialBreakDisplayData
		{
			IsAdvanceUnlocked = DomainManager.Organization.GetSectFunctionStatus(2, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked),
			SectEmeiBreakBonusData = new Dictionary<short, SectEmeiBreakBonusData>(_sectEmeiBreakBonusData),
			LearnedCombatSkills = new List<short>(DomainManager.Taiwu.GetTaiwu().GetLearnedCombatSkills()),
			Items = DomainManager.Character.GetAllInventoryItems(DomainManager.Taiwu.GetTaiwuCharId())
		};
		for (int i = res.Items.Count - 1; i >= 0; i--)
		{
			ItemDisplayData data = res.Items[i];
			if (ItemTemplateHelper.IsMiscResource(data.RealKey.ItemType, data.RealKey.TemplateId))
			{
				res.Items.RemoveAt(i);
			}
			else if (!ItemTemplateHelper.IsTransferable(data.RealKey.ItemType, data.RealKey.TemplateId))
			{
				res.Items.RemoveAt(i);
			}
			else if (!ItemTemplateHelper.AllowTrade(data.RealKey.ItemType, data.RealKey.TemplateId))
			{
				res.Items.RemoveAt(i);
			}
		}
		return res;
	}

	[DomainMethod]
	public SectStoryBonusDisplayData GetEmeiBreakBonusDisplayData(short combatSkillId)
	{
		_sectEmeiSkillBreakBonus.TryGetValue(combatSkillId, out var bonusCollection);
		_sectEmeiBreakBonusTemplateIds.TryGetValue(combatSkillId, out var bonusTemplateIds);
		return new SectStoryBonusDisplayData
		{
			CombatSkillId = combatSkillId,
			BreakBonusTemplateIds = bonusTemplateIds.Items,
			ExtraBonus = bonusCollection
		};
	}

	[DomainMethod]
	public SkillBreakBonusCollection GetEmeiBreakBonusCollection(short combatSkillId)
	{
		return _sectEmeiSkillBreakBonus.GetOrDefault(combatSkillId);
	}

	[DomainMethod]
	public bool AddEmeiSkillBreakBonus(DataContext context, short combatSkillId, short bonusTypeTemplateId)
	{
		if (!_sectEmeiBreakBonusData.TryGetValue(bonusTypeTemplateId, out var data))
		{
			return false;
		}
		if (data.BonusCount <= 0)
		{
			return false;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(taiwuCharId, combatSkillId), out var _))
		{
			return false;
		}
		data.BonusCount--;
		SetElement_SectEmeiBreakBonusData(bonusTypeTemplateId, data, context);
		return AddEmeiSkillBreakBonusWithoutCost(context, combatSkillId, bonusTypeTemplateId);
	}

	[DomainMethod]
	public bool RemoveEmeiSkillBreakBonus(DataContext context, short combatSkillId, short bonusTypeTemplateId)
	{
		if (!RemoveEmeiSkillBreakBonusNoRecycle(context, combatSkillId, bonusTypeTemplateId))
		{
			return false;
		}
		RemoveEmeiSkillBreakBonusRecycleBonus(context, bonusTypeTemplateId);
		return true;
	}

	private void InitializeEmeiBonusData(DataContext context)
	{
		foreach (SkillBreakPlateGridBonusTypeItem bonus in (IEnumerable<SkillBreakPlateGridBonusTypeItem>)SkillBreakPlateGridBonusType.Instance)
		{
			if (bonus.IsExtraBonus && !_sectEmeiBreakBonusData.ContainsKey(bonus.TemplateId))
			{
				AddElement_SectEmeiBreakBonusData(bonus.TemplateId, new SectEmeiBreakBonusData
				{
					TemplateId = bonus.TemplateId
				}, context);
			}
		}
	}

	public bool AddEmeiSkillBreakBonusWithoutCost(DataContext context, short combatSkillId, short bonusTypeTemplateId)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: taiwuCharId, skillId: combatSkillId), out var _))
		{
			return false;
		}
		if (!_sectEmeiSkillBreakBonus.TryGetValue(combatSkillId, out var bonusCollection))
		{
			bonusCollection = new SkillBreakBonusCollection();
			bonusCollection.AddBonusType(bonusTypeTemplateId);
			AddElement_SectEmeiSkillBreakBonus(combatSkillId, bonusCollection, context);
		}
		else
		{
			bonusCollection.AddBonusType(bonusTypeTemplateId);
			SetElement_SectEmeiSkillBreakBonus(combatSkillId, bonusCollection, context);
		}
		if (!_sectEmeiBreakBonusTemplateIds.TryGetValue(combatSkillId, out var bonusTemplateIds))
		{
			bonusTemplateIds = GameData.Utilities.ShortList.Create();
			bonusTemplateIds.Items.Add(bonusTypeTemplateId);
			AddElement_SectEmeiBreakBonusTemplateIds(combatSkillId, bonusTemplateIds, context);
		}
		else
		{
			bonusTemplateIds.Items.Add(bonusTypeTemplateId);
			SetElement_SectEmeiBreakBonusTemplateIds(combatSkillId, bonusTemplateIds, context);
		}
		SectEmeiUpdateBonusEffect(context, combatSkillId);
		return true;
	}

	public bool RemoveEmeiSkillBreakBonusNoRecycle(DataContext context, short combatSkillId, short bonusTypeTemplateId)
	{
		if (!_sectEmeiSkillBreakBonus.TryGetValue(combatSkillId, out var bonusCollection) || !_sectEmeiBreakBonusTemplateIds.TryGetValue(combatSkillId, out var bonusTemplateIds))
		{
			return false;
		}
		bonusCollection.RemoveBonusType(bonusTypeTemplateId);
		bonusTemplateIds.Items.Remove(bonusTypeTemplateId);
		if (bonusTemplateIds.Items.Count > 0)
		{
			SetElement_SectEmeiSkillBreakBonus(combatSkillId, bonusCollection, context);
			SetElement_SectEmeiBreakBonusTemplateIds(combatSkillId, bonusTemplateIds, context);
		}
		else
		{
			ClearEmeiSkillBreakBonus(context, combatSkillId);
		}
		SectEmeiUpdateBonusEffect(context, combatSkillId);
		return true;
	}

	private void RemoveEmeiSkillBreakBonusRecycleBonus(DataContext context, short bonusTypeTemplateId)
	{
		SectEmeiBreakBonusData data = _sectEmeiBreakBonusData[bonusTypeTemplateId];
		CValuePercent recyclePercent = GlobalConfig.Instance.SectStoryEmeiBonusProgressRecyclePercent;
		int recycleProgress = GlobalConfig.Instance.SectStoryEmeiBonusProgressPerCount * recyclePercent;
		data.OfflineAddProgress(recycleProgress);
		SetElement_SectEmeiBreakBonusData(bonusTypeTemplateId, data, context);
	}

	public bool ClearEmeiSkillBreakBonus(DataContext context, short combatSkillId)
	{
		if (!_sectEmeiSkillBreakBonus.ContainsKey(combatSkillId) || !_sectEmeiBreakBonusTemplateIds.ContainsKey(combatSkillId))
		{
			return false;
		}
		RemoveElement_SectEmeiSkillBreakBonus(combatSkillId, context);
		RemoveElement_SectEmeiBreakBonusTemplateIds(combatSkillId, context);
		SectEmeiUpdateBonusEffect(context, combatSkillId);
		return true;
	}

	public bool TryGetEmeiExtraBonusCollection(short combatSkillId, out SkillBreakBonusCollection extraBonusCollection)
	{
		return _sectEmeiSkillBreakBonus.TryGetValue(combatSkillId, out extraBonusCollection);
	}

	private void SectEmeiUpdateBonusEffect(DataContext context, short combatSkillId)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taiwuChar.IsCombatSkillEquipped(combatSkillId))
		{
			DomainManager.SpecialEffect.UpdateEquippedSkillEffect(context, taiwuChar);
		}
		DomainManager.Taiwu.GetTaiwu().UpdateAllocatedGenericGrids(context);
	}

	[DomainMethod]
	public void OnClickEmeiGuidance(DataContext context, int charId)
	{
		DomainManager.TaiwuEvent.OnEvent_ClickEmeiGuidance(charId);
	}

	[DomainMethod]
	public void UpdateSectEmeiGuidanceData(DataContext context, Location location)
	{
		if (!location.IsValid() || _sectEmeiGuidance.Count == 0)
		{
			return;
		}
		short areaId = DomainManager.Organization.GetSettlementByOrgTemplateId(2).GetLocation().AreaId;
		if (location.AreaId != areaId)
		{
			return;
		}
		foreach (var (charId, data) in _sectEmeiGuidance)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetLocation().AreaId != areaId)
			{
				TrySwitchEmeiGuidance(context, charId);
				break;
			}
		}
		UpdateSectEmeiGuidanceData(context);
	}

	public void CreateEmeiGuidance(DataContext context)
	{
		for (int i = 0; i < 5; i++)
		{
			AddEmeiGuidanceCharacter(context, i, -1);
		}
	}

	public void ClearEmeiGuidance(DataContext context)
	{
		foreach (SectEmeiGuidanceData prevData in _sectEmeiGuidance.Values)
		{
			if (DomainManager.Character.TryGetElement_Objects(prevData.EmeiGuidanceCombatSkillType, out var character))
			{
				character.DeactivateExternalRelationState(context, 64uL);
			}
		}
		ClearSectEmeiGuidance(context);
		_sectEmeiGuidanceData.Clear();
		SetSectEmeiGuidanceData(_sectEmeiGuidanceData, context);
	}

	public void TrySwitchEmeiGuidance(DataContext context, int charId)
	{
		if (_sectEmeiGuidance.TryGetValue(charId, out var data))
		{
			AddEmeiGuidanceCharacter(context, data.EmeiGuidanceCombatSkillType, charId);
		}
	}

	public void AddEmeiGuidanceCharacter(DataContext context, int emeiGuidanceCombatSkillType, int prevCharId)
	{
		sbyte orgTemplateId = 2;
		sbyte grade = 6;
		List<sbyte> types = EmeiGuidanceCombatSkillType.GetCombatSkillTypes(emeiGuidanceCombatSkillType);
		sbyte minConsummateLevel = OrganizationMember.Instance[Config.Organization.DefValue.Emei.Members[grade - 1]].ConsummateLevel;
		GameData.Domains.Character.Character character;
		foreach (SectEmeiGuidanceData prevData in _sectEmeiGuidance.Values)
		{
			if (prevData.EmeiGuidanceCombatSkillType == emeiGuidanceCombatSkillType)
			{
				SetEmeiGuidanceData(context, prevData.CharId, null);
				if (DomainManager.Character.TryGetElement_Objects(prevData.CharId, out character))
				{
					character.SetDisableAiMove(context, disableAiMove: false);
				}
				break;
			}
		}
		int maxValue = -1;
		int maxId = -1;
		Settlement sect = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		for (sbyte currGrade = 0; currGrade < 7; currGrade++)
		{
			HashSet<int> gradeMembers = sect.GetMembers().GetMembers(currGrade);
			foreach (int charId in gradeMembers)
			{
				if (_sectEmeiGuidance.ContainsKey(charId) || !DomainManager.Character.TryGetElement_Objects(charId, out character) || !character.IsInteractableAsIntelligentCharacter() || character.GetConsummateLevel() < minConsummateLevel)
				{
					continue;
				}
				int selectedMax = -1;
				foreach (sbyte type in types)
				{
					selectedMax = Math.Max(selectedMax, character.GetCombatSkillAttainment(type));
				}
				if (selectedMax >= maxValue)
				{
					maxValue = selectedMax;
					maxId = charId;
				}
			}
		}
		Location location = sect.GetLocation();
		short areaId = sect.GetLocation().AreaId;
		List<MapBlockData> result = new List<MapBlockData>();
		DomainManager.Map.GetMapBlocksInAreaByFilters(areaId, IsValidForEmeiGuidance, result);
		if (result.Count > 0)
		{
			location = new Location(areaId, result.GetRandom(context.Random).BlockId);
		}
		if (maxId < 0)
		{
			OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
			short orgMemberId = orgConfig.Members[grade];
			OrganizationMemberItem orgMemberInfo = OrganizationMember.Instance[orgMemberId];
			short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
			sbyte mapStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
			sbyte gender = ((orgMemberInfo.Gender == -1) ? Gender.GetRandom(context.Random) : orgMemberInfo.Gender);
			short charTemplateId = Config.Organization.Instance[orgTemplateId].CharTemplateIds[gender];
			if (charTemplateId < 0)
			{
				charTemplateId = MapDomain.GetCharacterTemplateId(mapStateTemplateId, gender);
			}
			IntelligentCharacterCreationInfo info = new IntelligentCharacterCreationInfo(location, new OrganizationInfo(orgTemplateId, grade, principal: true, settlementId), charTemplateId);
			character = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
			DomainManager.Character.CompleteCreatingCharacter(character.GetId());
			maxId = character.GetId();
		}
		else
		{
			character = DomainManager.Character.GetElement_Objects(maxId);
		}
		DomainManager.Character.LeaveGroup(context, character);
		DomainManager.Character.GroupMove(context, character, location);
		character.SetDisableAiMove(context, disableAiMove: true);
		SectEmeiGuidanceData data = new SectEmeiGuidanceData
		{
			EmeiGuidanceCombatSkillType = emeiGuidanceCombatSkillType,
			CharId = character.GetId(),
			Changed = (prevCharId >= 0 && prevCharId != maxId)
		};
		SetEmeiGuidanceData(context, maxId, data);
	}

	public void GuideEmeiCharacter(DataContext context, int charId)
	{
		if (_sectEmeiGuidance.TryGetValue(charId, out var data) && DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			sbyte type = GetGuidanceCombatSkillType(character, data.EmeiGuidanceCombatSkillType);
			short attainment = DomainManager.Taiwu.GetTaiwu().GetCombatSkillAttainment(type);
			SectEmeiGuidanceData sectEmeiGuidanceData = data;
			if (1 == 0)
			{
			}
			int point = ((attainment < 200) ? 1 : ((attainment >= 400) ? 3 : 2));
			if (1 == 0)
			{
			}
			sectEmeiGuidanceData.Point = point;
			SetEmeiGuidanceData(context, charId, data);
		}
	}

	public int GetEmeiGuidanceCharacterByType(int type)
	{
		if ((type < 0 || type >= 5) ? true : false)
		{
			return -1;
		}
		foreach (var (charId, data) in _sectEmeiGuidance)
		{
			if (data.EmeiGuidanceCombatSkillType == type)
			{
				return charId;
			}
		}
		return -1;
	}

	private sbyte GetGuidanceCombatSkillType(GameData.Domains.Character.Character character, int emeiGuidanceCombatSkillType)
	{
		List<sbyte> types = EmeiGuidanceCombatSkillType.GetCombatSkillTypes(emeiGuidanceCombatSkillType);
		sbyte type = types[0];
		if (types.Count > 1)
		{
			short max = character.GetCombatSkillAttainment(type);
			for (int i = 1; i < types.Count; i++)
			{
				short curr = character.GetCombatSkillAttainment(types[i]);
				if (curr > max)
				{
					max = curr;
					type = types[i];
				}
			}
		}
		return type;
	}

	private bool IsValidForEmeiGuidance(MapBlockData blockData)
	{
		if (blockData.IsNonDeveloped())
		{
			return false;
		}
		Location location = blockData.GetLocation();
		foreach (SectEmeiGuidanceData data in _sectEmeiGuidance.Values)
		{
			if (DomainManager.Character.TryGetElement_Objects(data.CharId, out var character) && location.Equals(character.GetLocation()))
			{
				return false;
			}
		}
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(2);
		if (DomainManager.Map.IsLocationOnSettlementBlock(location, settlementId))
		{
			return false;
		}
		if (!DomainManager.Map.IsLocationInSettlementInfluenceRange(location, settlementId))
		{
			return false;
		}
		return true;
	}

	public void SetEmeiGuidanceData(DataContext context, int id, SectEmeiGuidanceData data)
	{
		if (data != null)
		{
			if (_sectEmeiGuidance.ContainsKey(id))
			{
				SetElement_SectEmeiGuidance(id, data, context);
			}
			else
			{
				AddElement_SectEmeiGuidance(id, data, context);
			}
		}
		else
		{
			RemoveElement_SectEmeiGuidance(id, context);
		}
		UpdateSectEmeiGuidanceData(context);
	}

	private void UpdateSectEmeiGuidanceData(DataContext context)
	{
		_sectEmeiGuidanceData.Clear();
		foreach (var (id1, data1) in _sectEmeiGuidance)
		{
			if (DomainManager.Character.TryGetElement_Objects(id1, out var character))
			{
				_sectEmeiGuidanceData.Add(new SectEmeiGuidanceMapData
				{
					Data = data1,
					Location = character.GetLocation(),
					NameData = DomainManager.Character.GetNameRelatedData(id1),
					CombatSkillType = GetGuidanceCombatSkillType(character, data1.EmeiGuidanceCombatSkillType)
				});
			}
		}
		SetSectEmeiGuidanceData(_sectEmeiGuidanceData, context);
	}

	public void GetEmeiPotentialVictims(GameData.Domains.Character.Character selfChar, out List<int> charIds)
	{
		Location location = selfChar.GetLocation();
		List<MapBlockData> blocks = new List<MapBlockData>();
		int selfId = selfChar.GetId();
		sbyte grade = selfChar.GetOrganizationInfo().Grade;
		CharacterMatcherItem matcher = CharacterMatcher.DefValue.EmeiPotentialVictims;
		charIds = new List<int>();
		DomainManager.Map.GetNeighborBlocks(location.AreaId, location.BlockId, blocks, 3);
		foreach (MapBlockData blockData in blocks)
		{
			HashSet<int> characterSet = blockData.CharacterSet;
			if (characterSet == null || characterSet.Count <= 0)
			{
				continue;
			}
			foreach (int id in blockData.CharacterSet)
			{
				if (id == selfId || !DomainManager.Character.TryGetElement_Objects(id, out var victim) || !matcher.Match(victim) || victim.GetOrganizationInfo().Grade > grade)
				{
					continue;
				}
				charIds.Add(id);
				break;
			}
		}
	}

	public bool GetEmeiCostExpEnough()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		if (sectArgBox.GetBool(SectMainStoryEventArgKey.DefValue.EmeiBreakBonusSaved))
		{
			return true;
		}
		return true;
	}

	public int GetEmeiExpCharacterId()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(2);
		bool emeiShiHoujiuFollowOpen = sectArgBox.GetBool(SectMainStoryEventArgKey.DefValue.EmeiShiHoujiuFollowOpen);
		bool emeiWhiteGibbonFollowOpen = sectArgBox.GetBool(SectMainStoryEventArgKey.DefValue.EmeiWhiteGibbonFollowOpen);
		if (!emeiShiHoujiuFollowOpen && !emeiWhiteGibbonFollowOpen)
		{
			return -1;
		}
		short charTemplateId = (short)(emeiShiHoujiuFollowOpen ? 567 : 562);
		return DomainManager.Character.GetFixedCharacterIdByTemplateId(charTemplateId);
	}

	public bool FulongDisasterStart()
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(913, out var _) && !DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().Contains<bool>("YuFuTellRanchenziStory"))
		{
			return true;
		}
		return false;
	}

	public unsafe void FulongTriggerDisaster(DataContext context)
	{
		int distance = 6;
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(14);
		List<MapBlockData> mapBlockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> mapBlockListFit = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetLocationByDistance(settlement.GetLocation(), distance, distance, ref mapBlockList);
		for (int i = 0; i < mapBlockList.Count; i++)
		{
			MapBlockData mapBlockData = mapBlockList[i];
			if (mapBlockData.GetConfig().SubType != EMapBlockSubType.DLCLoong && mapBlockData.GetConfig().Size <= 1 && mapBlockData.IsNonDeveloped())
			{
				mapBlockListFit.Add(mapBlockData);
			}
		}
		if (mapBlockListFit.Count < 1)
		{
			return;
		}
		MapBlockData disasterCenterMapBlockData = mapBlockListFit.GetRandom(context.Random);
		mapBlockList.Clear();
		DomainManager.Map.GetLocationByDistance(disasterCenterMapBlockData.GetLocation(), 1, 1, ref mapBlockList);
		sbyte maxResourceType = 0;
		int maxResourceCount = 0;
		for (sbyte type = 0; type < 6; type++)
		{
			if (disasterCenterMapBlockData.CurrResources.Items[type] > maxResourceCount)
			{
				maxResourceCount = disasterCenterMapBlockData.CurrResources.Items[type];
				maxResourceType = type;
			}
		}
		Location disasterLocation = disasterCenterMapBlockData.GetLocation();
		if (ResourceDisasterHelper.GenerateDisasterAdventure(context, maxResourceType, disasterLocation))
		{
			AdventureRuntime adventure = DomainManager.Adventure.QueryAdventureInLocation(disasterLocation);
			adventure.CallCharacters(context);
			mapBlockList.Add(disasterCenterMapBlockData);
			for (int j = 0; j < mapBlockList.Count; j++)
			{
				MapBlockData mapBlockData2 = mapBlockList[j];
				if (mapBlockData2.GetConfig().Size <= 1)
				{
					mapBlockData2.Malice = 0;
					DomainManager.Map.MakeBlockDestroyedInAdvanceMonth(context, mapBlockData2);
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(mapBlockList);
		ObjectPool<List<MapBlockData>>.Instance.Return(mapBlockListFit);
	}

	public bool JingangWorldStateCheck()
	{
		return DomainManager.Building.IsTaiwuVillageHaveSpecifyBuilding(50, notBuild: true);
	}

	public bool JingangMonkWasRobbedCanTrigger()
	{
		if (!JingangWorldStateCheck())
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetValidLocation();
		if (DomainManager.Map.IsAreaBroken(location.AreaId))
		{
			return false;
		}
		sbyte stateTemplateIdByAreaId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		return stateTemplateIdByAreaId == 11;
	}

	public int JingangSpreadSecInfoStage()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwu.GetId(), 115))
		{
			return 3;
		}
		if (DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwu.GetId(), 114))
		{
			return 2;
		}
		if (DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwu.GetId(), 113))
		{
			return 1;
		}
		if (DomainManager.Information.CharacterHasSecretInformationByTemplateId(taiwu.GetId(), 112))
		{
			return 0;
		}
		return -1;
	}

	[DomainMethod]
	public bool JingangMonkSoulBtnShow()
	{
		if (JingangSpreadSecInfoStage() == -1)
		{
			return false;
		}
		if (!JingangIsInSpreadSutraTask())
		{
			return false;
		}
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		bool jingangMonkSoulBtnDisappear = false;
		argBox.Get(SectMainStoryEventArgKey.DefValue.JingangMonkSoulBtnDisappear, ref jingangMonkSoulBtnDisappear);
		return !jingangMonkSoulBtnDisappear;
	}

	public int JingangKnowSecInfoCount()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangKnowSecInfoIdList, out IntList charIds);
		if (charIds.Items == null)
		{
			return 0;
		}
		return charIds.Items.Count;
	}

	public bool JingangCanTriggerMonkSoulEnterDream(DataContext context)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		int totalCount = 0;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangSpreadSecInfoTotalCount, ref totalCount);
		int enterDreamCount = 0;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangMonkSoulEnterDreamCount, ref enterDreamCount);
		if (totalCount > enterDreamCount && enterDreamCount < 5)
		{
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangMonkSoulEnterDreamCount, ++enterDreamCount);
			return true;
		}
		return false;
	}

	public void JingangClearKnowSecInfo(DataContext context)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		sectArgBox.Remove<IntList>(SectMainStoryEventArgKey.DefValue.JingangKnowSecInfoIdList);
		DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 11);
	}

	public void JingangAddKnowSecInfoCharId(DataContext context, int charId)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangKnowSecInfoIdList, out IntList charIds);
		if (charIds.Items == null)
		{
			charIds = IntList.Create();
		}
		charIds.Items.Add(charId);
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangKnowSecInfoIdList, charIds);
		int totalCount = 0;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangSpreadSecInfoTotalCount, ref totalCount);
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangSpreadSecInfoTotalCount, ++totalCount);
	}

	public bool JingangCanTriggerPietyEvent()
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		int jingangPietyCount = 0;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangPietyCount, ref jingangPietyCount);
		return jingangPietyCount < JingangCanTriggerPietyEventCount();
	}

	public int JingangCanTriggerPietyEventCount()
	{
		int totalCount = 3;
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		bool jingangGiveVillagerFood = false;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangGiveVillagerFood, ref jingangGiveVillagerFood);
		if (jingangGiveVillagerFood)
		{
			totalCount++;
		}
		bool jingangGiveVillagerMoney = false;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangGiveVillagerMoney, ref jingangGiveVillagerMoney);
		if (jingangGiveVillagerMoney)
		{
			totalCount++;
		}
		bool jingangGiveVillagerPromise = false;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangGiveVillagerPromise, ref jingangGiveVillagerPromise);
		if (jingangGiveVillagerPromise)
		{
			totalCount++;
		}
		bool jingangGiveVillagerHelp = false;
		sectArgBox.Get(SectMainStoryEventArgKey.DefValue.JingangGiveVillagerHelp, ref jingangGiveVillagerHelp);
		if (jingangGiveVillagerHelp)
		{
			totalCount++;
		}
		return totalCount;
	}

	public void JingangDistributeSecInfo(DataContext context, int secretId, int targetCharId)
	{
		GameData.Domains.Character.Character monk = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 777);
		DomainManager.Information.DistributeSecretInformationToCharacter(context, (SecretInformationId)secretId, targetCharId, monk.GetId());
	}

	public bool JingangIsInSpreadSutraTask()
	{
		return DomainManager.World.IsExtraTaskInProgress(205) || DomainManager.World.IsExtraTaskInProgress(209) || DomainManager.World.IsExtraTaskInProgress(210) || DomainManager.World.IsExtraTaskInProgress(211);
	}

	public void JingangBroadCastSecInfo(DataContext context)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(11);
		int secretId = 0;
		InformationDomain informationDomain = DomainManager.Information;
		if (!argBox.Get(SectMainStoryEventArgKey.DefValue.JingangSecInfoMetaDataId, ref secretId))
		{
			return;
		}
		SecretInformationId realSecretId = SecretInformationId.Invalid;
		int occurenceId = -1;
		GameData.Domains.Information.Secret.SecretInformation secret = informationDomain.QuerySecretInformation((SecretInformationId)secretId);
		if (secret != null)
		{
			realSecretId = secret.Id;
		}
		else
		{
			GameData.Domains.Information.Secret.SecretInformation[] targets = (from s in informationDomain.QueryAllSecretInformation(delegate(SecretOccurence occurence)
				{
					short templateId = occurence.TemplateId;
					return (uint)(templateId - 112) <= 3u;
				})
				orderby (int)s.Id descending
				select s).ToArray();
			if (targets.Length != 0)
			{
				realSecretId = targets[0].Id;
			}
		}
		if (realSecretId.Valid)
		{
			informationDomain.MakeSecretBroadcast(context, realSecretId, -1);
			if (informationDomain.CalcSecretInformationConfig(realSecretId).TemplateId == 115)
			{
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 11, SectMainStoryEventArgKey.DefValue.JingangMonkSoulBtnDisappear, value: true);
			}
		}
	}

	[DomainMethod]
	public void ApplyKongsangSpecialInteract(DataContext context, List<int> characterIds, List<ItemKeyAndCount> selectedWugKingCountList)
	{
		if (characterIds == null)
		{
			return;
		}
		foreach (int charId in characterIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				if (character.GetFeatureIds().Contains(216))
				{
					character.RemoveDarkAsh(context);
				}
				character.AddFeature(context, 738);
			}
		}
		foreach (ItemKeyAndCount item in selectedWugKingCountList)
		{
			DomainManager.Taiwu.RemoveItem(context, item.ItemKey, item.Count, 1, deleteItem: true);
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.SetInventory(taiwu.GetInventory(), context);
	}

	[DomainMethod]
	public static List<CharacterDisplayData> GetCurAreaValidCharactersForTripodVessel(DataContext context)
	{
		List<GameData.Domains.Character.Character> target = new List<GameData.Domains.Character.Character>();
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(755, out var character) && character.GetLocation() != Location.Invalid)
		{
			MapCharacterFilter.Find((GameData.Domains.Character.Character v) => v.GetOrganizationInfo().OrgTemplateId != 16, target, character.GetLocation().AreaId, includeInfected: true);
		}
		return DomainManager.Character.GetCharacterDisplayDataList(target.Select((GameData.Domains.Character.Character x) => x.GetId()).ToList());
	}

	public void StatSectMainStoryCombatTimes(DataContext context, short combatConfigTemplateId)
	{
		CombatConfigItem config = CombatConfig.Instance[combatConfigTemplateId];
		bool flag = DomainManager.World.IsExtraTaskChainInProgress(27);
		bool flag2 = flag;
		if (flag2)
		{
			sbyte combatType = config.CombatType;
			bool flag3 = (uint)(combatType - 1) <= 1u;
			flag2 = flag3;
		}
		if (flag2)
		{
			SetSectMainStoryCombatTimesShaolin(_sectMainStoryCombatTimesShaolin + 1, context);
		}
	}

	[DomainMethod]
	public bool ShaolinInterruptDemonSlayerTrial(DataContext context)
	{
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		DomainManager.TaiwuEvent.CloseUI("ShaolinInterruptDemonSlayerTrial", presetBool: false, data.TrialingLevel.TemplateId);
		bool success = data.ClearDemons();
		if (success)
		{
			DomainManager.Extra.SetSectShaolinDemonSlayerData(context, data);
		}
		return success;
	}

	[DomainMethod]
	public bool ShaolinRegenerateRestricts(DataContext context)
	{
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		bool success = data.ReGenerateRestricts(context.Random);
		if (success)
		{
			DomainManager.Extra.SetSectShaolinDemonSlayerData(context, data);
		}
		return success;
	}

	[DomainMethod]
	public byte ShaolinQueryRestrictsAreSatisfied(int index)
	{
		BoolArray8 result = (byte)0;
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		int restrictIndex = 0;
		foreach (DemonSlayerTrialRestrictItem restrict in data.GetTrialingRestricts(index))
		{
			result[restrictIndex++] = restrict.Check();
		}
		return result;
	}

	[DomainMethod]
	public void ShaolinStartDemonSlayerTrial(DataContext context, int index)
	{
		DomainManager.TaiwuEvent.OnEvent_StartSectShaolinDemonSlayer(index);
	}

	[DomainMethod]
	public List<int> ShaolinGenerateTemporaryDemon(DataContext context)
	{
		List<int> demonCharIds = new List<int>();
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		for (int i = 0; i < 2; i++)
		{
			DemonSlayerTrialItem demon = data.GetTrialingDemon(i);
			if (demon != null)
			{
				GameData.Domains.Character.Character character = CreateFixedDemon(context, demon.CharacterId);
				demonCharIds.Add(character.GetId());
			}
		}
		return demonCharIds;
	}

	[DomainMethod]
	public void ShaolinClearTemporaryDemon(DataContext context, List<int> demonCharIds)
	{
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		for (int i = 0; i < 2; i++)
		{
			DemonSlayerTrialItem demon = data.GetTrialingDemon(i);
			if (demon == null)
			{
				continue;
			}
			int charId = demonCharIds.GetOrDefault(i, -1);
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				if (character.GetTemplateId() != demon.CharacterId)
				{
					AdaptableLog.Warning($"Failed to clear demon template by mismatch {character.GetTemplateId()}");
				}
				else
				{
					DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
				}
			}
		}
	}

	public bool ShaolinGenerateDemonSlayerTrial(DataContext context)
	{
		SectShaolinDemonSlayerData data = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		bool success = data.GenerateDemons(context.Random);
		if (success)
		{
			DomainManager.Extra.SetSectShaolinDemonSlayerData(context, data);
		}
		return success;
	}

	public GameData.Domains.Character.Character CreateFixedDemon(DataContext context, short demonTemplateId)
	{
		ulong seed = (ulong)(DomainManager.World.GetWorldId() + demonTemplateId);
		context.SwitchRandomSource(seed);
		GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedEnemy(context, demonTemplateId, isTemporary: true);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		context.RestoreRandomSource();
		return character;
	}

	public void UpdateWordlessStatus(DataContext context)
	{
		if (DomainManager.Organization.GetSectFunctionStatus(1, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked))
		{
			int currDate = DomainManager.World.GetCurrDate();
			if (_wordless.Id < 0)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 945);
				int id = character.GetId();
				SetWordless(new SectStoryShaolinWordlessCharacter
				{
					Id = id,
					Status = 0,
					PreviousDate = currDate
				}, context);
			}
			if (_wordless.PreviousDate + GlobalConfig.Instance.WordlessStatusChangeDuration <= currDate)
			{
				_wordless.PreviousDate = currDate;
				_wordless.Status = 1;
				SetWordless(_wordless, context);
			}
			SetWordlessLocation(context);
		}
	}

	public void SetWordlessLocation(DataContext context)
	{
		if (!DomainManager.Taiwu.AtPastTaiwuVillage() && DomainManager.Organization.GetSectFunctionStatus(1, SectFunctionStatuses.SectFunctionStatusType.UpgradedInteractionUnlocked) && _wordless.Status != 0)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, 945);
			if (_wordless.Status != 2 || !character.IsActiveExternalRelationState(64uL))
			{
				List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
				Location location = ((_wordless.Status == 2) ? DomainManager.Taiwu.GetTaiwu().GetValidLocation() : DomainManager.Taiwu.GetTaiwuVillageLocation());
				DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, 2);
				Location targetLocation = neighborBlocks.GetRandom(context.Random).GetLocation();
				Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), character.GetLocation(), targetLocation);
				character.SetLocation(targetLocation, context);
				ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
			}
		}
	}

	public void ShaolinGetSutraBooks(DataContext context, sbyte beginGrade, sbyte endGrade, Action<ItemKey> onGeneratedBook)
	{
		short[] buddhismLifeSkillTemplateIds = Config.LifeSkillType.Instance[(sbyte)13].SkillList;
		for (sbyte i = beginGrade; i <= endGrade; i++)
		{
			short lifeSkillTemplateId = buddhismLifeSkillTemplateIds[i];
			short bookId = LifeSkill.Instance[lifeSkillTemplateId].SkillBookId;
			ItemKey itemKey = DomainManager.Item.CreateSkillBook(context, bookId, 5, -1, -1, 50);
			SkillBookItem bookConfig = Config.SkillBook.Instance[bookId];
			if (bookConfig.Grade == 8 && DomainManager.Item.TryGetElement_SkillBooks(itemKey.Id, out var skillBook))
			{
				skillBook.SetMaxDurability(15, context);
				skillBook.SetCurrDurability(15, context);
			}
			onGeneratedBook(itemKey);
		}
		DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 1, SectMainStoryEventArgKey.DefValue.ShaolinReadingMaxGradeSutra, buddhismLifeSkillTemplateIds[endGrade]);
		DomainManager.World.TriggerExtraTask(context, 27, 143);
	}

	public int GetShixiangKilledLimit()
	{
		return _shixiangKilledLimitInMonth;
	}

	public void SetShixiangKilledLimit(int value, DataContext context)
	{
		_shixiangKilledLimitInMonth = value;
	}

	public void ResetShixiangKilledLimit(DataContext context)
	{
		_shixiangKilledLimitInMonth = context.Random.Next(6, 13);
	}

	public bool ShixiangSettlementAffiliatedBlocksHasEnemy(DataContext context, short startTemplateId)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(6);
		Location settlementLocation = settlement.GetLocation();
		List<MapBlockData> blockList = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetSettlementAffiliatedBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockList);
		bool hasEnemy = false;
		foreach (MapBlockData block in blockList)
		{
			if (block.EnemyCharacterSet == null)
			{
				continue;
			}
			foreach (int charId in block.EnemyCharacterSet)
			{
				DomainManager.Character.TryGetElement_Objects(charId, out var enemy);
				short templateId = enemy.GetTemplateId();
				if (templateId < startTemplateId || templateId > startTemplateId + 4)
				{
					continue;
				}
				hasEnemy = true;
				break;
			}
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref blockList);
		return hasEnemy;
	}

	[DomainMethod]
	public int GetSectMainStoryTriggerConditions(short templateId)
	{
		int res = 0;
		List<Func<bool>> funcs = _sectMainStoryTriggerConditions[templateId];
		for (int index = 0; index < funcs.Count; index++)
		{
			if (funcs[index]())
			{
				res |= 1 << index;
			}
		}
		return res;
	}

	public bool CheckSectMainStoryTriggerConditions(short templateId)
	{
		foreach (Func<bool> condition in _sectMainStoryTriggerConditions[templateId])
		{
			if (!condition())
			{
				return false;
			}
		}
		return true;
	}

	private static bool ShaolinMainStoryTrigger0()
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(1);
		return DomainManager.Organization.GetElement_Sects(settlement.GetId()).GetTaiwuExploreStatus() == 2;
	}

	private static bool ShaolinMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(1);
		return taiwuLocation.IsValid() && DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlementId);
	}

	private static bool EMeiMainStoryTrigger0()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(2).CalcApprovingRate() >= 500;
	}

	private static bool EMeiMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		Location emeiLocation = DomainManager.Organization.GetSettlementByOrgTemplateId(2).GetLocation();
		if (emeiLocation.AreaId != taiwuLocation.AreaId)
		{
			return false;
		}
		List<short> settlementIds = new List<short>();
		DomainManager.Map.GetAreaSettlementIds(emeiLocation.AreaId, settlementIds, containsMainCity: true, containsSect: true);
		foreach (short settlementId in settlementIds)
		{
			if (DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, settlementId))
			{
				return false;
			}
		}
		return true;
	}

	private static bool BaihuaMainStoryTrigger0()
	{
		return DomainManager.World.GetDefeatSwordTombCount() >= Config.SectMainStory.DefValue.Baihua.RequireDefeatSwordTombCount;
	}

	private static bool BaihuaMainStoryTrigger1()
	{
		return DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId == DomainManager.Map.GetAreaIdByAreaTemplateId(18);
	}

	private static bool WudangMainStoryTrigger0()
	{
		short settlementId = DomainManager.Organization.GetSettlementByOrgTemplateId(4).GetId();
		return DomainManager.Organization.GetElement_Sects(settlementId).GetTaiwuExploreStatus() == 2;
	}

	private static bool WudangMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		Location wudangLocation = DomainManager.Organization.GetSettlementByOrgTemplateId(4).GetLocation();
		return taiwuLocation.AreaId == wudangLocation.AreaId;
	}

	private static bool YuanshanMainStoryTrigger0()
	{
		return DomainManager.World.GetDefeatSwordTombCount() >= Config.SectMainStory.DefValue.Yuanshan.RequireDefeatSwordTombCount;
	}

	private static bool YuanshanMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		Location yuanshanLocation = DomainManager.Organization.GetSettlementByOrgTemplateId(5).GetLocation();
		return taiwuLocation.AreaId == yuanshanLocation.AreaId;
	}

	private static bool YuanshanMainStoryTrigger2()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(5).CalcApprovingRate() >= 500;
	}

	private static bool ShixiangMainStoryTrigger0()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(6).CalcApprovingRate() >= 500;
	}

	private static bool ShixiangMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(taiwuLocation.AreaId);
		sbyte guangdongStateId = DomainManager.Map.GetStateIdByStateTemplateId(6);
		MapBlockData taiwuBlockData = DomainManager.Map.GetBlockData(taiwuLocation.AreaId, taiwuLocation.BlockId);
		bool flag = stateId == guangdongStateId;
		bool flag2 = flag;
		if (flag2)
		{
			EMapBlockType blockType = taiwuBlockData.BlockType;
			bool flag3 = ((blockType == EMapBlockType.City || blockType == EMapBlockType.Town) ? true : false);
			flag2 = flag3;
		}
		return flag2;
	}

	private static bool RanshanMainStoryTrigger0()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(7).CalcApprovingRate() >= 500;
	}

	private static bool RanshanMainStoryTrigger1()
	{
		int legendaryBookCount = 0;
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			if (DomainManager.Item.HasTrackedSpecialItems(12, (short)(240 + combatSkillType)))
			{
				legendaryBookCount++;
			}
		}
		return legendaryBookCount >= 3;
	}

	private static bool RanshanMainStoryTrigger2()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		return taiwuLocation.IsValid() && !MapAreaData.IsBrokenArea(taiwuLocation.AreaId);
	}

	private static bool XuannvMainStoryTrigger0()
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(8);
		return DomainManager.Organization.GetElement_Sects(settlement.GetId()).GetTaiwuExploreStatus() == 2;
	}

	private static bool XuannvMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(8);
		return taiwuLocation.IsValid() && DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlementId);
	}

	private static bool ZhujianMainStoryTrigger0()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(9).CalcApprovingRate() >= 500;
	}

	private static bool ZhujianMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (taiwuLocation.IsValid() && !MapAreaData.IsBrokenArea(taiwuLocation.AreaId))
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwuLocation.AreaId);
			return stateTemplateId == 9;
		}
		return false;
	}

	private static bool KongsangMainStoryTrigger0()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(10).CalcApprovingRate() >= 500;
	}

	private static bool KongsangMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(10);
		if (!DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlement.GetId()))
		{
			return false;
		}
		MapBlockData taiwuBlockData = DomainManager.Map.GetBlockData(taiwuLocation.AreaId, taiwuLocation.BlockId);
		if (taiwuBlockData.CharacterSet == null || taiwuBlockData.CharacterSet.Count == 0)
		{
			return false;
		}
		GameData.Domains.Character.Character leader = settlement.GetLeader();
		if (leader == null)
		{
			return false;
		}
		int leaderId = leader.GetId();
		return taiwuBlockData.CharacterSet.Contains(leaderId);
	}

	private static bool JingangMainStoryTrigger0()
	{
		return DomainManager.Building.IsTaiwuVillageHaveSpecifyBuilding(50, notBuild: true);
	}

	private static bool JingangMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		if (DomainManager.Map.IsAreaBroken(taiwuLocation.AreaId))
		{
			return false;
		}
		sbyte stateTemplateIdByAreaId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwuLocation.AreaId);
		return stateTemplateIdByAreaId == 11;
	}

	private static bool WuxianMainStoryTrigger0()
	{
		short settlementId = DomainManager.Organization.GetSettlementByOrgTemplateId(12).GetId();
		return DomainManager.Organization.GetElement_Sects(settlementId).GetSpiritualDebtInteractionOccurred();
	}

	private static bool WuxianMainStoryTrigger1()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(12);
		return taiwuLocation.IsValid() && DomainManager.Map.IsLocationInSettlementInfluenceRange(taiwuLocation, settlementId);
	}

	private static bool JieqingMainStoryTrigger0()
	{
		return DomainManager.World.GetDefeatSwordTombCount() >= Config.SectMainStory.DefValue.Jieqing.RequireDefeatSwordTombCount;
	}

	private static bool JieqingMainStoryTrigger1()
	{
		return DomainManager.Taiwu.GetTaiwu().GetFameType() <= 1 || DomainManager.Taiwu.GetTaiwu().GetFameType() >= 5;
	}

	private static bool JieqingMainStoryTrigger2()
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetValidLocation();
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(33);
		return taiwuLocation.IsValid() && DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlementId);
	}

	private static bool FulongMainStoryTrigger0()
	{
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetFixedCharacterByTemplateId(913, out character) && !DomainManager.TaiwuEvent.GetGlobalEventArgumentBox().Contains<bool>("YuFuTellRanchenziStory");
	}

	private static bool FulongMainStoryTrigger1()
	{
		return DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId == DomainManager.Map.GetAreaIdByAreaTemplateId(29);
	}

	private static bool XuehouMainStoryTrigger0()
	{
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(35);
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		return taiwuLocation.IsValid() && DomainManager.Map.IsLocationOnSettlementBlock(taiwuLocation, settlementId);
	}

	[DomainMethod]
	public DefendHeavenlyTreeDisplayData GetDefendHeavenlyTreeDisplayData(bool includeGrownTree, Location curTreeLocation, List<Location> viewTreeLocationList)
	{
		DefendHeavenlyTreeDisplayData data = new DefendHeavenlyTreeDisplayData();
		data.AllCharacterDisplayDataDict = new Dictionary<int, CharacterDisplayData>();
		data.WorkAvailableVillagerList = DomainManager.Taiwu.GetAllVillagersAvailableForWork();
		foreach (int charId in data.WorkAvailableVillagerList)
		{
			if (!data.AllCharacterDisplayDataDict.ContainsKey(charId))
			{
				data.AllCharacterDisplayDataDict[charId] = DomainManager.Character.GetCharacterDisplayData(charId);
			}
		}
		data.TreeClearEnemyAvailableVillagerList = DomainManager.Taiwu.GetVillagersAvailableForTreeClearEnemy();
		foreach (int charId2 in data.TreeClearEnemyAvailableVillagerList)
		{
			if (!data.AllCharacterDisplayDataDict.ContainsKey(charId2))
			{
				data.AllCharacterDisplayDataDict[charId2] = DomainManager.Character.GetCharacterDisplayData(charId2);
			}
		}
		List<SectStoryHeavenlyTreeExtendable> heavenlyTreeList = DomainManager.Extra.GetAllHeavenlyTrees();
		data.HeavenlyTreeList = new List<SectStoryHeavenlyTreeExtendable>();
		foreach (SectStoryHeavenlyTreeExtendable tree in heavenlyTreeList)
		{
			bool isGrown = tree.GrowTemplateId == 602;
			if ((includeGrownTree && isGrown) || !isGrown || tree.Location == curTreeLocation || (viewTreeLocationList != null && viewTreeLocationList.Contains(tree.Location)))
			{
				data.HeavenlyTreeList.Add(tree);
				CharacterDisplayData charData = DomainManager.Character.GetCharacterDisplayData(tree.Id);
				data.AllCharacterDisplayDataDict[tree.Id] = charData;
			}
		}
		data.HeavenlyTreeList.Sort(delegate(SectStoryHeavenlyTreeExtendable a, SectStoryHeavenlyTreeExtendable b)
		{
			if (a.GrowPoint != b.GrowPoint)
			{
				return b.GrowPoint.CompareTo(a.GrowPoint);
			}
			return (a.TriggerRandomEnemyCount != b.TriggerRandomEnemyCount) ? b.TriggerRandomEnemyCount.CompareTo(a.TriggerRandomEnemyCount) : 0;
		});
		List<short> bookList = (from index in Config.SkillBook.Instance.GetAllKeys()
			where Config.SkillBook.Instance[index].LifeSkillType == 12
			select index).ToList();
		data.BookItemList = new List<ItemDisplayData>();
		foreach (short id in bookList)
		{
			ItemDisplayData itemData = new ItemDisplayData(10, id)
			{
				Amount = 1
			};
			data.BookItemList.Add(itemData);
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		data.AvailableBookList = bookList.Where((short templateId) => taiwuChar.TryGetLearnedLifeSkill(templateId, out var lifeSkill) && lifeSkill.IsAllPagesRead()).ToList();
		var (itemSourceType, list) = DomainManager.Taiwu.GetAllItems(ItemSourceType.Resources);
		list.RemoveAll((ItemDisplayData item) => item.ResourceType >= 6);
		data.ResourceItemList = list;
		int step = 6;
		foreach (SectStoryHeavenlyTreeExtendable treeData in data.HeavenlyTreeList)
		{
			List<MapBlockData> blockList = DomainManager.Extra.GetHeavenlyTreeNearBlocks(treeData.Id, step);
			data.HeavenlyTreeBlockDict[treeData.Id] = new DefendHeavenlyTreeBlockData
			{
				BlockList = blockList
			};
			MapBlockData centerBlock = blockList.Find((MapBlockData b) => b.GetLocation() == treeData.Location);
			ByteCoordinate centerCoordinate = centerBlock.GetBlockPos();
			List<MapBlockData> visibleBlockList = blockList.Where((MapBlockData b) => b.GetManhattanDistanceToPosWithoutRoot(centerCoordinate.X, centerCoordinate.Y) <= 3).ToList();
			data.HeavenlyTreeVisibleBlockDict[treeData.Id] = new DefendHeavenlyTreeBlockData
			{
				BlockList = visibleBlockList
			};
		}
		return data;
	}

	[DomainMethod]
	public SectWudangDefendHeavenlyTreeDisplayData DefendHeavenlyTreeClearEnemy(DataContext context, int treeId, int charId)
	{
		if (!DomainManager.Extra.TryGetHeavenlyTreeById(treeId, out var tree))
		{
			return ((List<Location>)null, false);
		}
		HashSet<Location> clearLocationSet = new HashSet<Location>();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		character.ChangeCurrAge(context, 3);
		MapBlockData blockData = DomainManager.Map.GetBlock(tree.Location);
		List<MapBlockData> blockList = DomainManager.Extra.GetHeavenlyTreeNearBlocks(treeId, 3);
		int clearCount = 0;
		List<MapTemplateEnemyInfo> toRemoveEnemyList = new List<MapTemplateEnemyInfo>();
		foreach (MapBlockData mapBlockData in blockList)
		{
			if (mapBlockData.TemplateEnemyList == null)
			{
				continue;
			}
			bool changed = false;
			Location location = mapBlockData.GetLocation();
			foreach (MapTemplateEnemyInfo templateEnemyInfo in mapBlockData.TemplateEnemyList)
			{
				short templateId = templateEnemyInfo.TemplateId;
				if ((templateId >= 366 && templateId <= 374) || 1 == 0)
				{
					Location targetLocation = new Location(blockData.AreaId, templateEnemyInfo.SourceAdventureBlockId);
					if (tree.Location == targetLocation)
					{
						changed = true;
						toRemoveEnemyList.Add(templateEnemyInfo);
						clearLocationSet.Add(location);
						clearCount++;
					}
				}
			}
			foreach (MapTemplateEnemyInfo templateEnemyInfo2 in toRemoveEnemyList)
			{
				mapBlockData.RemoveTemplateEnemy(templateEnemyInfo2);
			}
			toRemoveEnemyList.Clear();
			if (changed)
			{
				DomainManager.Map.SetBlockData(context, mapBlockData);
			}
		}
		int growPoint = 10 * clearCount;
		DomainManager.Extra.HeavenlyTreeGrewUp(context, treeId, growPoint, showUI: false, out var eventTriggered);
		return (clearLocationSet.ToList(), eventTriggered);
	}

	[DomainMethod]
	public bool DefendHeavenlyTreeFeed(DataContext context, int treeId, ItemDisplayData itemData)
	{
		int growPoint = 0;
		switch (itemData.RealKey.ItemType)
		{
		case 12:
			growPoint = EventHelper.GetHeavenlyTreeGrewUpValueByResource(itemData.Amount);
			DomainManager.Taiwu.RemoveResource(context, ItemSourceType.Resources, itemData.ResourceType, itemData.Amount);
			break;
		case 10:
			growPoint = EventHelper.GetHeavenlyTreeGrewUpValueByBook();
			EventHelper.AddWudangReadBookToTree(treeId, itemData.RealKey.TemplateId);
			break;
		}
		DomainManager.Extra.HeavenlyTreeGrewUp(context, treeId, growPoint, showUI: false, out var eventTriggered);
		DomainManager.Extra.ConsumeActionPoint(context, 100);
		return eventTriggered;
	}

	[DomainMethod]
	public int CreateMirrorCharacter(DataContext context, bool isMale, string familyName, string firstName)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuId = taiwu.GetId();
		sbyte taiwuVillageTemplateId = 16;
		sbyte gender = (sbyte)(isMale ? 1 : 0);
		bool isTaiwuTransgender = taiwu.GetTransgender();
		short age = 16;
		short templateId = taiwu.GetTemplateId();
		CharacterItem template = Config.Character.Instance[templateId];
		if (template.CreatingType != 1)
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(taiwu.GetLocation().AreaId);
			sbyte orgTemplateId = MapState.Instance[stateTemplateId].SectID;
			templateId = OrganizationDomain.GetCharacterTemplateId(orgTemplateId, stateTemplateId, gender);
		}
		IntelligentCharacterCreationInfo intelligentCharacterCreationInfo = new IntelligentCharacterCreationInfo(taiwu.GetLocation(), new OrganizationInfo(taiwuVillageTemplateId, 0, principal: true, DomainManager.Organization.GetSettlementIdByOrgTemplateId(taiwuVillageTemplateId)), templateId);
		intelligentCharacterCreationInfo.Age = age;
		intelligentCharacterCreationInfo.BirthMonth = DomainManager.World.GetCurrMonthInYear();
		intelligentCharacterCreationInfo.BaseAttraction = taiwu.GetBaseAttraction();
		intelligentCharacterCreationInfo.Avatar = taiwu.GetAvatar();
		intelligentCharacterCreationInfo.SpecifyGenome = true;
		intelligentCharacterCreationInfo.Genome = taiwu.GetGenome();
		intelligentCharacterCreationInfo.ReincarnationCharId = -2;
		intelligentCharacterCreationInfo.InitializeSectSkills = false;
		intelligentCharacterCreationInfo.LifeSkillQualificationGrowthType = taiwu.GetLifeSkillQualificationGrowthType();
		intelligentCharacterCreationInfo.CombatSkillQualificationGrowthType = taiwu.GetCombatSkillQualificationGrowthType();
		intelligentCharacterCreationInfo.Gender = gender;
		intelligentCharacterCreationInfo.Transgender = ((taiwu.GetGender() == gender) ? isTaiwuTransgender : (!isTaiwuTransgender));
		IntelligentCharacterCreationInfo info = intelligentCharacterCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
		int charId = character.GetId();
		int customSurnameId = (string.IsNullOrEmpty(familyName) ? (-1) : DomainManager.World.RegisterCustomText(context, familyName));
		int customGivenNameId = (string.IsNullOrEmpty(firstName) ? (-1) : DomainManager.World.RegisterCustomText(context, firstName));
		FullName fullName = CharacterDomain.GenerateRandomHanName(context.Random, customSurnameId, -1, gender, 0);
		if (customGivenNameId >= 0)
		{
			fullName.SetCustomGivenName(customGivenNameId);
		}
		character.SetFullName(fullName, context);
		List<short> learnedCombatSkills = character.GetLearnedCombatSkills();
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = ObjectPool<List<GameData.Domains.CombatSkill.CombatSkill>>.Instance.Get();
		combatSkills.Clear();
		foreach (short combatSkillId in taiwu.GetLearnedCombatSkills())
		{
			GameData.Domains.CombatSkill.CombatSkill oldSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(taiwuId, combatSkillId));
			GameData.Domains.CombatSkill.CombatSkill newSkill = GameData.Serializer.Serializer.CreateCopy(oldSkill);
			newSkill.OfflineSetCharId(charId);
			newSkill.OfflineSetSpecialEffectId(-1L);
			combatSkills.Add(newSkill);
			learnedCombatSkills.Add(combatSkillId);
		}
		DomainManager.CombatSkill.RegisterCombatSkills(charId, combatSkills);
		DomainManager.Character.AutoActivateReadCombatSkillNormalPages(context, combatSkills, charId);
		DomainManager.Extra.CopyCombatSkillProficiency(context, taiwuId, charId);
		ObjectPool<List<GameData.Domains.CombatSkill.CombatSkill>>.Instance.Return(combatSkills);
		character.SetLearnedCombatSkills(learnedCombatSkills, context);
		character.CopyCombatSkillEquipmentFrom(context, taiwu);
		DomainManager.SpecialEffect.AddAllBrokenSkillEffects(context, character);
		character.SetLoopingNeigong(taiwu.GetLoopingNeigong(), context);
		character.SetCombatSkillAttainmentPanels(taiwu.GetCombatSkillAttainmentPanels().ToArray(), context);
		List<GameData.Domains.Character.LifeSkillItem> lifeSkills = character.GetLearnedLifeSkills();
		lifeSkills.Clear();
		lifeSkills.AddRange(taiwu.GetLearnedLifeSkills());
		character.SetLearnedLifeSkills(lifeSkills, context);
		character.SetConsummateLevel(taiwu.GetConsummateLevel(), context);
		character.SetMainAttributeInterest(taiwu.GetMainAttributeInterest(), context);
		character.SetBaseMainAttributes(taiwu.GetBaseMainAttributes(), context);
		character.ClearGeneticFeatures(context);
		short taiwuOneYearFeatureId = taiwu.GetGroupFeature(172);
		if (taiwuOneYearFeatureId >= 0)
		{
			character.AddFeature(context, taiwuOneYearFeatureId, removeMutexFeature: true);
		}
		else
		{
			character.RemoveFeatureGroup(context, 172);
		}
		character.AddFeature(context, 733);
		foreach (short id in taiwu.GetFeatureIds())
		{
			bool flag;
			switch (id)
			{
			case 170:
				character.AddFeature(context, id);
				continue;
			case 168:
			case 169:
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				character.AddFeature(context, (short)(isMale ? 168 : 169));
			}
			else if (CharacterFeature.Instance[id].GeneticProb == 100)
			{
				character.AddFeature(context, id);
			}
		}
		character.SetBaseMorality((short)(-taiwu.GetBaseMorality()), context);
		CharacterAlertnessData alertness = new CharacterAlertnessData
		{
			Value = CharacterAlertnessData.MinValue
		};
		DomainManager.Character.SetAlertness(context, charId, alertness);
		DomainManager.Character.AddRelation(context, charId, taiwuId, 16384);
		DomainManager.TaiwuEvent.RecordCharacterRelationChanged(isRemove: false, charId, taiwuId, 16384);
		DomainManager.Taiwu.AddLegacyPoint(context, 2);
		DomainManager.Character.DirectlySetFavorabilities(context, character.GetId(), taiwuId, 30000, 30000);
		character.SetLifeSkillTypeInterest(taiwu.GetLifeSkillTypeInterest(), context);
		character.SetCombatSkillTypeInterest(taiwu.GetCombatSkillTypeInterest(), context);
		LifeSkillShorts baseLifeSkills = taiwu.GetBaseLifeSkillQualifications();
		character.SetBaseLifeSkillQualifications(ref baseLifeSkills, context);
		CombatSkillShorts baseCombatSkills = taiwu.GetBaseCombatSkillQualifications();
		character.SetBaseCombatSkillQualifications(ref baseCombatSkills, context);
		character.SetSkillQualificationBonuses(new List<SkillQualificationBonus>(taiwu.GetSkillQualificationBonuses()), context);
		DomainManager.Character.RemoveAllInventoryAndEquippedItems(context, character);
		ResourceInts resource = default(ResourceInts);
		resource.Initialize();
		character.SetResources(ref resource, context);
		character.SetAvatar(context, new AvatarData(taiwu.GetAvatar()));
		NeiliAllocation neiliAllocation = default(NeiliAllocation);
		neiliAllocation.Initialize();
		character.SetBaseNeiliAllocation(neiliAllocation, context);
		character.SetExtraNeili(taiwu.GetExtraNeili(), context);
		neiliAllocation = default(NeiliAllocation);
		neiliAllocation.Initialize();
		taiwu.SetBaseNeiliAllocation(neiliAllocation, context);
		character.SetExtraNeiliAllocationProgressWithHooks(taiwu.GetExtraNeiliAllocationProgress().ToArray(), context);
		character.SetExtraNeiliAllocation(taiwu.GetExtraNeiliAllocation(), context);
		taiwu.SetCurrNeili(0, context);
		character.SetCurrNeili(0, context);
		character.SetCurrMainAttributes(character.GetMaxMainAttributes(), context);
		character.SetHealth(character.GetLeftMaxHealth(), context);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		DomainManager.Extra.SectXuannvSaveMirrorCharacters(context, taiwuId, charId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddSectMainStoryXuannvBirthOfMirrorCreatedImposture(charId, DomainManager.World.GetCurrDate(), charId);
		DomainManager.Taiwu.JoinGroup(context, charId);
		return character.GetId();
	}

	[DomainMethod]
	public List<int> GetThreeVitalsReplaceTeammateRecord(DataContext context)
	{
		List<int> ids = new List<int>();
		for (int i = 0; i < _threeVitalsReplaceTeammateRecordNew.Count; i++)
		{
			int type = _threeVitalsReplaceTeammateRecordNew[i];
			if (type < 0)
			{
				ids.Add(-1);
			}
			else if (type < 3)
			{
				GameData.Domains.Character.Character vitalCharacter = DomainManager.Extra.GetVitalCharacterByType(context, (SectStoryThreeVitalsCharacterType)type);
				int vitalId = vitalCharacter.GetId();
				if (!ids.Contains(vitalId))
				{
					ids.Add(vitalId);
				}
			}
			else
			{
				IronPlateData ironPlateData = DomainManager.Story.GetIronPlateData();
				if (!ids.Contains(ironPlateData.FollowingCharId))
				{
					ids.Add(ironPlateData.FollowingCharId);
				}
			}
		}
		return ids.ToList();
	}

	[DomainMethod]
	public void ThreeVitalsReplaceTeammateRecordSet(DataContext context, int typeInt, int index)
	{
		List<int> record = DomainManager.Story.GetThreeVitalsReplaceTeammateRecordNew();
		int oldIndex = record.IndexOf(typeInt);
		if (oldIndex >= 0)
		{
			record.SetOrAdd(oldIndex, -1, 0);
		}
		record.SetOrAdd(index - 1, typeInt, -1);
		DomainManager.Story.SetThreeVitalsReplaceTeammateRecordNew(record, context);
	}

	[DomainMethod]
	public void ThreeVitalsReplaceTeammateRecordRemove(DataContext context, int typeInt)
	{
		List<int> record = DomainManager.Story.GetThreeVitalsReplaceTeammateRecordNew();
		int index = record.IndexOf(typeInt);
		if (index >= 0)
		{
			record[index] = -1;
			DomainManager.Story.SetThreeVitalsReplaceTeammateRecordNew(record, context);
		}
	}

	[DomainMethod]
	public int TryTriggerThiefCatch(DataContext context)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!TryGetThief(location, out var thiefData, out var thiefIndex))
		{
			return -1;
		}
		if (thiefData.ThiefTriggered[thiefIndex])
		{
			return -1;
		}
		List<SectStoryThiefData> thiefList = DomainManager.Extra.GetSectZhujianThiefList();
		thiefData.ThiefTriggered[thiefIndex] = true;
		bool isRealThief = thiefIndex == thiefData.RealThiefIndex;
		if (isRealThief || thiefData.AllIsTriggered())
		{
			thiefList.Remove(thiefData);
		}
		else
		{
			thiefData.UpdatePlace(context.Random);
		}
		DomainManager.Extra.SetSectZhujianThiefList(thiefList, context);
		return isRealThief ? thiefData.CatchThiefTimes : (-1);
	}

	[DomainMethod]
	public void CatchThief(sbyte thiefLevel, bool timeOut)
	{
		DomainManager.TaiwuEvent.OnEvent_CatchThief(thiefLevel, timeOut);
	}

	public void CreateNewThief(DataContext context, short areaId)
	{
		EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(9);
		int catchTimes = sectArgBox.GetInt(SectMainStoryEventArgKey.DefValue.ZhujianCatchThiefTimes);
		SectStoryThiefData thiefData = CreateThiefData(context.Random, catchTimes, areaId);
		foreach (short blockId in thiefData.ThiefBlockIds)
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(areaId, blockId);
			if (!blockData.Visible)
			{
				blockData.SetVisible(visible: true, context);
			}
		}
		List<SectStoryThiefData> thiefList = DomainManager.Extra.GetSectZhujianThiefList();
		thiefList.Add(thiefData);
		DomainManager.Extra.SetSectZhujianThiefList(thiefList, context);
	}

	private SectStoryThiefData CreateThiefData(IRandomSource random, int catchTimes, short areaId)
	{
		SectStoryThiefData data = new SectStoryThiefData
		{
			CatchThiefTimes = catchTimes,
			AreaId = areaId,
			ThiefBlockIds = new List<short>(),
			ThiefTriggered = new List<bool>(),
			RealThiefIndex = random.Next(3)
		};
		List<MapBlockData> availableBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		availableBlocks.Clear();
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(areaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			if (SectStoryThiefDataHelper.IsBlockAvailable(block))
			{
				availableBlocks.Add(block);
			}
		}
		CollectionUtils.Shuffle(random, availableBlocks);
		List<MapBlockData> neighborList = ObjectPool<List<MapBlockData>>.Instance.Get();
		foreach (MapBlockData block2 in availableBlocks)
		{
			DomainManager.Map.GetRealNeighborBlocks(block2.AreaId, block2.BlockId, neighborList);
			neighborList.RemoveAll(SectStoryThiefDataHelper.IsBlockUnAvailable);
			if (neighborList.Count < 2)
			{
				continue;
			}
			CollectionUtils.Shuffle(random, neighborList);
			data.ThiefBlockIds.Add(block2.BlockId);
			data.ThiefBlockIds.Add(neighborList[0].BlockId);
			data.ThiefBlockIds.Add(neighborList[1].BlockId);
			for (int j = 0; j < 3; j++)
			{
				data.ThiefTriggered.Add(item: false);
			}
			break;
		}
		if (data.ThiefBlockIds.Count == 0)
		{
			PredefinedLog.Show(11, $"Create thief failed in {areaId}");
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(availableBlocks);
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborList);
		return data;
	}

	public bool TryGetThief(Location location, out SectStoryThiefData thiefData, out int thiefIndex)
	{
		List<SectStoryThiefData> thiefList = DomainManager.Extra.GetSectZhujianThiefList();
		foreach (SectStoryThiefData thief in thiefList)
		{
			if (thief.AreaId != location.AreaId)
			{
				continue;
			}
			for (int i = 0; i < thief.ThiefBlockIds.Count; i++)
			{
				if (thief.ThiefBlockIds[i] == location.BlockId)
				{
					thiefData = thief;
					thiefIndex = i;
					return true;
				}
			}
		}
		thiefData = null;
		thiefIndex = -1;
		return false;
	}

	public void UpdateAreaMerchantType(DataContext context)
	{
		foreach (KeyValuePair<short, sbyte> item in DomainManager.Extra.SectZhujianAreaMerchantTypeDict)
		{
			item.Deconstruct(out var key, out var value);
			short areaTemplateId = key;
			sbyte merchantType = value;
			short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(areaTemplateId);
			MapAreaData areaData = DomainManager.Map.GetAreaByAreaId(areaId);
			List<SettlementInfo> settlementInfoList = areaData.SettlementInfos.ToList();
			SettlementInfo[] settlementInfos = areaData.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementInfo.SettlementId);
				OrganizationItem orgConfig = Config.Organization.Instance[settlement.GetOrgTemplateId()];
				if (orgConfig.IsSect)
				{
					settlementInfoList.Remove(settlementInfo);
				}
			}
			CollectionUtils.Shuffle(context.Random, settlementInfoList);
			Dictionary<int, sbyte> charToType = new Dictionary<int, sbyte>();
			foreach (SettlementInfo settlementInfo2 in settlementInfoList)
			{
				Settlement settlement2 = DomainManager.Organization.GetSettlement(settlementInfo2.SettlementId);
				List<int> charList = new List<int>();
				settlement2.GetMembers().GetAllMembers(charList);
				foreach (int charId in charList)
				{
					if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.IsInteractableAsIntelligentCharacter() && OrganizationDomain.CanInteractWithType(character, 4) && DomainManager.Extra.TryGetMerchantCharToType(charId, out var type))
					{
						charToType[charId] = type;
					}
				}
			}
			bool hasTargetChar = false;
			foreach (KeyValuePair<int, sbyte> item2 in charToType)
			{
				item2.Deconstruct(out var key2, out value);
				int charId2 = key2;
				sbyte type2 = value;
				if (type2 == merchantType)
				{
					hasTargetChar = true;
					break;
				}
			}
			if (!hasTargetChar)
			{
				if (charToType.Count > 0)
				{
					int charId3 = charToType.Keys.ToList().GetRandom(context.Random);
					GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(charId3);
					character2.AddOrSetMerchantType(merchantType, context);
					DomainManager.Map.SetBlockData(context, DomainManager.Map.GetBlock(character2.GetLocation()));
					continue;
				}
				SettlementInfo randomSettlementInfo = settlementInfoList.GetRandom(context.Random);
				Settlement randomSettlement = DomainManager.Organization.GetSettlement(randomSettlementInfo.SettlementId);
				Location location = randomSettlement.GetLocation();
				sbyte gender = Gender.GetRandom(context.Random);
				short age = 16;
				GameData.Domains.Character.Character newChar = EventHelper.CreateIntelligentCharacter(location, gender, age, -1, randomSettlementInfo.SettlementId, 4);
				newChar.AddOrSetMerchantType(merchantType, context);
				DomainManager.Map.SetBlockData(context, DomainManager.Map.GetBlock(location));
			}
		}
	}

	[DomainMethod]
	public SectZhujianGearMateAttributeDisplayData GetSectZhujianGearMateAttributeDisplayData(DataContext context, int gearMateId, int characterId)
	{
		GearMate gearMate = DomainManager.Extra.GetGearMateById(gearMateId);
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> items = new List<ItemDisplayData>();
		if (taiwu?.GetInventory() != null)
		{
			List<ItemDisplayData> inventoryItems = DomainManager.Item.GetItemDisplayDataListOptionalFromInventory(taiwu.GetInventory(), taiwuId, 1);
			if (inventoryItems != null)
			{
				items.AddRange(inventoryItems);
			}
		}
		List<ItemDisplayData> warehouseItems = DomainManager.Taiwu.GetAllWarehouseItems(context);
		if (warehouseItems != null)
		{
			items.AddRange(warehouseItems);
		}
		List<ItemDisplayData> treasuryItems = DomainManager.Taiwu.GetAllTreasuryItems(context);
		if (treasuryItems != null)
		{
			items.AddRange(treasuryItems);
		}
		MainAttributes baseMainAttributes = DomainManager.Character.GetElement_Objects(gearMate.Id).GetBaseMainAttributes();
		List<int> mainAttributes = new List<int>();
		for (int i = 0; i < 6; i++)
		{
			mainAttributes.Add(baseMainAttributes[i]);
		}
		bool canUseWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context);
		return new SectZhujianGearMateAttributeDisplayData
		{
			GearMate = gearMate,
			Items = items,
			MainAttributes = mainAttributes,
			CanUseWarehouse = canUseWarehouse
		};
	}

	[DomainMethod]
	public SectZhujianGearMateSkillDisplayData GetSectZhujianGearMateSkillDisplayData(DataContext context, int gearMateId, bool isCombatSkill)
	{
		GearMate gearMate = DomainManager.Extra.GetGearMateById(gearMateId);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.Character.Character gearMateChar = DomainManager.Character.GetElement_Objects(gearMate.Id);
		SectZhujianGearMateSkillDisplayData displayData = new SectZhujianGearMateSkillDisplayData
		{
			GearMate = gearMate,
			GearMateDisplayData = DomainManager.Character.GetCharacterDisplayData(gearMate.Id),
			CombatSkillQualifications = gearMateChar.GetBaseCombatSkillQualifications(),
			CombatSkillAttainments = gearMateChar.GetCombatSkillQualifications(),
			LifeSkillQualifications = gearMateChar.GetBaseLifeSkillQualifications(),
			LifeSkillAttainments = gearMateChar.GetLifeSkillAttainments(),
			LearnedLifeSkills = gearMateChar.GetLearnedLifeSkills(),
			CombatSkillAttainmentPanels = gearMateChar.GetCombatSkillAttainmentPanels(),
			CanUseWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			CanReadBookItemList = DomainManager.Extra.GetAllSkillBooksGearMateCanRead(isCombatSkill),
			TaiwuExp = taiwu.GetExp()
		};
		Dictionary<int, SkillBookPageDisplayData> pageDisplayDataDict = new Dictionary<int, SkillBookPageDisplayData>();
		foreach (ItemDisplayData data in displayData.CanReadBookItemList)
		{
			pageDisplayDataDict[data.RealKey.Id] = DomainManager.Item.GetSkillBookPagesInfo(data.RealKey);
		}
		displayData.PageDisplayDataDict = pageDisplayDataDict;
		return displayData;
	}

	[DomainMethod]
	public SectZhujianGearMateBreakoutDisplayData GetGearMateBreakoutDisplayData(int gearMateId)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeSkillShorts lifeSkillAttainments = taiwu.GetLifeSkillAttainments();
		List<short> learnedCombatSkills = taiwu.GetLearnedCombatSkills();
		List<CombatSkillDisplayData> combatSkillDisplayDataList = DomainManager.CombatSkill.GetCombatSkillDisplayData(taiwuCharId, learnedCombatSkills);
		List<ShortPair> banReasonList = DomainManager.Extra.GetGearMateBreakoutCombatSkillBanReasonList(gearMateId, learnedCombatSkills);
		GearMate gearMate = DomainManager.Extra.GetGearMateById(gearMateId);
		GameData.Domains.Character.Character gearMateChar = DomainManager.Character.GetElement_Objects(gearMate.Id);
		LifeSkillShorts gearMateLifeSkillAttainments = gearMateChar.GetLifeSkillAttainments();
		Dictionary<short, SByteList> gearMateCombatSkillReadingProgress = new Dictionary<short, SByteList>();
		foreach (KeyValuePair<short, TaiwuCombatSkill> kvp in gearMate.CombatSkillReadingProgress)
		{
			gearMateCombatSkillReadingProgress[kvp.Key] = SByteList.Create();
			gearMateCombatSkillReadingProgress[kvp.Key].Items.AddRange(kvp.Value.GetAllBookPageReadingProgress());
		}
		return new SectZhujianGearMateBreakoutDisplayData
		{
			LifeSkillAttainments = lifeSkillAttainments,
			CombatSkillDisplayDataList = combatSkillDisplayDataList,
			GearMateBreakoutCombatSkillBanReasonList = banReasonList,
			GearMateLifeSkillAttainments = gearMateLifeSkillAttainments,
			GearMateCombatSkillReadingProgress = gearMateCombatSkillReadingProgress,
			Exp = taiwu.GetExp()
		};
	}

	[DomainMethod]
	public SectZhujianGearMateFeatureDisplayData GetSectZhujianGearMateFeatureDisplayData(DataContext context, int gearMateId)
	{
		GearMate gearMate = DomainManager.Extra.GetGearMateById(gearMateId);
		GameData.Domains.Character.Character gearMateChar = DomainManager.Character.GetElement_Objects(gearMate.Id);
		return new SectZhujianGearMateFeatureDisplayData
		{
			GearMate = gearMate,
			GearMateDisplayData = DomainManager.Character.GetCharacterDisplayData(gearMate.Id),
			FeatureIds = gearMateChar.GetFeatureIds(),
			CanUseWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			CanUpgradeFeatureItemList = GetCanUpgradeFeatureItemList()
		};
	}

	[DomainMethod]
	public SectZhujianGearMateConsummateDisplayData GetSectZhujianGearMateConsummateDisplayData(DataContext context, int gearMateId)
	{
		GearMate gearMate = DomainManager.Extra.GetGearMateById(gearMateId);
		GameData.Domains.Character.Character gearMateChar = DomainManager.Character.GetElement_Objects(gearMate.Id);
		return new SectZhujianGearMateConsummateDisplayData
		{
			GearMate = gearMate,
			GearMateDisplayData = DomainManager.Character.GetCharacterDisplayData(gearMate.Id),
			ConsummateLevel = gearMateChar.GetConsummateLevel(),
			CanUseWarehouse = DomainManager.Taiwu.CanTransferItemToWarehouse(context),
			CanUpgradeConsummateItemList = GetCanUpgradeConsummateItemList()
		};
	}

	private List<ItemDisplayData> GetCanUpgradeFeatureItemList()
	{
		List<ItemDisplayData> res = new List<ItemDisplayData>();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		Span<ItemSourceType> itemSourceTypes = stackalloc ItemSourceType[4]
		{
			ItemSourceType.Equipment,
			ItemSourceType.Inventory,
			ItemSourceType.Warehouse,
			ItemSourceType.Treasury
		};
		Span<ItemSourceType> span = itemSourceTypes;
		for (int i = 0; i < span.Length; i++)
		{
			ItemSourceType itemSourceType = span[i];
			bool isFromEquipment = itemSourceType == ItemSourceType.Equipment;
			List<ItemDisplayData> list = CharacterDomain.GetItemDisplayData(taiwuId, DomainManager.Taiwu.GetItems(itemSourceType), itemSourceType);
			foreach (ItemDisplayData item in list)
			{
				bool isTransferable = ItemTemplateHelper.IsTransferable(item.RealKey.ItemType, item.RealKey.TemplateId);
				bool flag = isTransferable;
				bool flag2 = flag;
				if (flag2)
				{
					sbyte itemType = item.RealKey.ItemType;
					bool flag3 = (uint)itemType <= 2u;
					flag2 = flag3;
				}
				if (flag2)
				{
					res.Add(item);
					if (isFromEquipment)
					{
						item.ItemSourceType = 1;
					}
				}
			}
		}
		return res;
	}

	private List<ItemDisplayData> GetCanUpgradeConsummateItemList()
	{
		List<ItemDisplayData> res = new List<ItemDisplayData>();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		Span<ItemSourceType> itemSourceTypes = stackalloc ItemSourceType[3]
		{
			ItemSourceType.Inventory,
			ItemSourceType.Warehouse,
			ItemSourceType.Treasury
		};
		Span<ItemSourceType> span = itemSourceTypes;
		for (int i = 0; i < span.Length; i++)
		{
			ItemSourceType itemSourceType = span[i];
			List<ItemDisplayData> list = CharacterDomain.GetItemDisplayData(taiwuId, DomainManager.Taiwu.GetItems(itemSourceType), itemSourceType);
			foreach (ItemDisplayData item in list)
			{
				if (ItemTemplateHelper.IsTransferable(item.RealKey.ItemType, item.RealKey.TemplateId) && item.RealKey.ItemType == 5)
				{
					MaterialItem config = Config.Material.Instance[item.RealKey.TemplateId];
					if (config.RefiningEffect >= 0)
					{
						res.Add(item);
					}
				}
			}
		}
		return res;
	}

	public StoryDomain()
		: base(15)
	{
		_sectMainStoryTaskStatus = new sbyte[15];
		_wordless = new SectStoryShaolinWordlessCharacter();
		_sectEmeiBreakBonusData = new Dictionary<short, SectEmeiBreakBonusData>(0);
		_sectEmeiSkillBreakBonus = new Dictionary<short, SkillBreakBonusCollection>(0);
		_sectEmeiBreakBonusTemplateIds = new Dictionary<short, GameData.Utilities.ShortList>(0);
		_threeVitalsReplaceTeammateRecord = new int[3];
		_threeVitalsReplaceTeammateRecordNew = new List<int>();
		_sectMainStoryCombatTimesShaolin = 0;
		_advanceXiangshuAvatarIds = new List<sbyte>();
		_ironPlateData = new IronPlateData();
		_noMindGuyUsed = 0;
		_divineFlameData = new DivineFlameData();
		_twelveImmortalsStatuses = new TwelveImmortalsStatus[12];
		_sectEmeiGuidance = new Dictionary<int, SectEmeiGuidanceData>(0);
		_sectEmeiGuidanceData = new List<SectEmeiGuidanceMapData>();
		OnInitializedDomainData();
	}

	public sbyte GetElement_SectMainStoryTaskStatus(int index)
	{
		return _sectMainStoryTaskStatus[index];
	}

	public void SetElement_SectMainStoryTaskStatus(int index, sbyte value, DataContext context)
	{
		_sectMainStoryTaskStatus[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesSectMainStoryTaskStatus, CacheInfluencesSectMainStoryTaskStatus, context);
	}

	public SectStoryShaolinWordlessCharacter GetWordless()
	{
		return _wordless;
	}

	public void SetWordless(SectStoryShaolinWordlessCharacter value, DataContext context)
	{
		_wordless = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public SectEmeiBreakBonusData GetElement_SectEmeiBreakBonusData(short elementId)
	{
		return _sectEmeiBreakBonusData[elementId];
	}

	public bool TryGetElement_SectEmeiBreakBonusData(short elementId, out SectEmeiBreakBonusData value)
	{
		return _sectEmeiBreakBonusData.TryGetValue(elementId, out value);
	}

	private void AddElement_SectEmeiBreakBonusData(short elementId, SectEmeiBreakBonusData value, DataContext context)
	{
		_sectEmeiBreakBonusData.Add(elementId, value);
		_modificationsSectEmeiBreakBonusData.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void SetElement_SectEmeiBreakBonusData(short elementId, SectEmeiBreakBonusData value, DataContext context)
	{
		_sectEmeiBreakBonusData[elementId] = value;
		_modificationsSectEmeiBreakBonusData.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SectEmeiBreakBonusData(short elementId, DataContext context)
	{
		_sectEmeiBreakBonusData.Remove(elementId);
		_modificationsSectEmeiBreakBonusData.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	private void ClearSectEmeiBreakBonusData(DataContext context)
	{
		_sectEmeiBreakBonusData.Clear();
		_modificationsSectEmeiBreakBonusData.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public SkillBreakBonusCollection GetElement_SectEmeiSkillBreakBonus(short elementId)
	{
		return _sectEmeiSkillBreakBonus[elementId];
	}

	public bool TryGetElement_SectEmeiSkillBreakBonus(short elementId, out SkillBreakBonusCollection value)
	{
		return _sectEmeiSkillBreakBonus.TryGetValue(elementId, out value);
	}

	private void AddElement_SectEmeiSkillBreakBonus(short elementId, SkillBreakBonusCollection value, DataContext context)
	{
		_sectEmeiSkillBreakBonus.Add(elementId, value);
		_modificationsSectEmeiSkillBreakBonus.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void SetElement_SectEmeiSkillBreakBonus(short elementId, SkillBreakBonusCollection value, DataContext context)
	{
		_sectEmeiSkillBreakBonus[elementId] = value;
		_modificationsSectEmeiSkillBreakBonus.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SectEmeiSkillBreakBonus(short elementId, DataContext context)
	{
		_sectEmeiSkillBreakBonus.Remove(elementId);
		_modificationsSectEmeiSkillBreakBonus.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	private void ClearSectEmeiSkillBreakBonus(DataContext context)
	{
		_sectEmeiSkillBreakBonus.Clear();
		_modificationsSectEmeiSkillBreakBonus.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public GameData.Utilities.ShortList GetElement_SectEmeiBreakBonusTemplateIds(short elementId)
	{
		return _sectEmeiBreakBonusTemplateIds[elementId];
	}

	public bool TryGetElement_SectEmeiBreakBonusTemplateIds(short elementId, out GameData.Utilities.ShortList value)
	{
		return _sectEmeiBreakBonusTemplateIds.TryGetValue(elementId, out value);
	}

	private void AddElement_SectEmeiBreakBonusTemplateIds(short elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_sectEmeiBreakBonusTemplateIds.Add(elementId, value);
		_modificationsSectEmeiBreakBonusTemplateIds.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void SetElement_SectEmeiBreakBonusTemplateIds(short elementId, GameData.Utilities.ShortList value, DataContext context)
	{
		_sectEmeiBreakBonusTemplateIds[elementId] = value;
		_modificationsSectEmeiBreakBonusTemplateIds.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SectEmeiBreakBonusTemplateIds(short elementId, DataContext context)
	{
		_sectEmeiBreakBonusTemplateIds.Remove(elementId);
		_modificationsSectEmeiBreakBonusTemplateIds.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	private void ClearSectEmeiBreakBonusTemplateIds(DataContext context)
	{
		_sectEmeiBreakBonusTemplateIds.Clear();
		_modificationsSectEmeiBreakBonusTemplateIds.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _threeVitalsReplaceTeammateRecord is no longer in use.")]
	public int[] GetThreeVitalsReplaceTeammateRecord()
	{
		return _threeVitalsReplaceTeammateRecord;
	}

	[Obsolete("DomainData _threeVitalsReplaceTeammateRecord is no longer in use.")]
	public void SetThreeVitalsReplaceTeammateRecord(int[] value, DataContext context)
	{
		_threeVitalsReplaceTeammateRecord = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public List<int> GetThreeVitalsReplaceTeammateRecordNew()
	{
		return _threeVitalsReplaceTeammateRecordNew;
	}

	public void SetThreeVitalsReplaceTeammateRecordNew(List<int> value, DataContext context)
	{
		_threeVitalsReplaceTeammateRecordNew = value;
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public int GetSectMainStoryCombatTimesShaolin()
	{
		return _sectMainStoryCombatTimesShaolin;
	}

	private void SetSectMainStoryCombatTimesShaolin(int value, DataContext context)
	{
		_sectMainStoryCombatTimesShaolin = value;
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public List<sbyte> GetAdvanceXiangshuAvatarIds()
	{
		return _advanceXiangshuAvatarIds;
	}

	public void SetAdvanceXiangshuAvatarIds(List<sbyte> value, DataContext context)
	{
		_advanceXiangshuAvatarIds = value;
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public IronPlateData GetIronPlateData()
	{
		return _ironPlateData;
	}

	private void SetIronPlateData(IronPlateData value, DataContext context)
	{
		_ironPlateData = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _noMindGuyUsed is no longer in use.")]
	public int GetNoMindGuyUsed()
	{
		return _noMindGuyUsed;
	}

	[Obsolete("DomainData _noMindGuyUsed is no longer in use.")]
	private void SetNoMindGuyUsed(int value, DataContext context)
	{
		_noMindGuyUsed = value;
		SetModifiedAndInvalidateInfluencedCache(10, DataStates, CacheInfluences, context);
	}

	public DivineFlameData GetDivineFlameData()
	{
		return _divineFlameData;
	}

	private void SetDivineFlameData(DivineFlameData value, DataContext context)
	{
		_divineFlameData = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	private TwelveImmortalsStatus GetElement_TwelveImmortalsStatuses(int index)
	{
		return _twelveImmortalsStatuses[index];
	}

	private void SetElement_TwelveImmortalsStatuses(int index, TwelveImmortalsStatus value, DataContext context)
	{
		_twelveImmortalsStatuses[index] = value;
		SetModifiedAndInvalidateInfluencedCache(index, _dataStatesTwelveImmortalsStatuses, CacheInfluencesTwelveImmortalsStatuses, context);
	}

	public SectEmeiGuidanceData GetElement_SectEmeiGuidance(int elementId)
	{
		return _sectEmeiGuidance[elementId];
	}

	public bool TryGetElement_SectEmeiGuidance(int elementId, out SectEmeiGuidanceData value)
	{
		return _sectEmeiGuidance.TryGetValue(elementId, out value);
	}

	private void AddElement_SectEmeiGuidance(int elementId, SectEmeiGuidanceData value, DataContext context)
	{
		_sectEmeiGuidance.Add(elementId, value);
		_modificationsSectEmeiGuidance.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void SetElement_SectEmeiGuidance(int elementId, SectEmeiGuidanceData value, DataContext context)
	{
		_sectEmeiGuidance[elementId] = value;
		_modificationsSectEmeiGuidance.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SectEmeiGuidance(int elementId, DataContext context)
	{
		_sectEmeiGuidance.Remove(elementId);
		_modificationsSectEmeiGuidance.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	private void ClearSectEmeiGuidance(DataContext context)
	{
		_sectEmeiGuidance.Clear();
		_modificationsSectEmeiGuidance.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public List<SectEmeiGuidanceMapData> GetSectEmeiGuidanceData()
	{
		return _sectEmeiGuidanceData;
	}

	public void SetSectEmeiGuidanceData(List<SectEmeiGuidanceMapData> value, DataContext context)
	{
		_sectEmeiGuidanceData = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public override void OnInitializeGameDataModule()
	{
		InitializeOnInitializeGameDataModule();
	}

	public override void OnEnterNewWorld()
	{
		InitializeOnEnterNewWorld();
		InitializeInternalDataOfCollections();
	}

	public override void OnSaveWorld(ArchiveFileBase archive)
	{
		archive.WriteSingleValueUnmanaged((ushort)12);
		archive.WriteDomainDataMeta(0);
		archive.WriteElementListUnmanaged(_sectMainStoryTaskStatus);
		archive.WriteDomainDataMeta(1);
		archive.WriteSingleValueCustom(_wordless);
		archive.WriteDomainDataMeta(2);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiBreakBonusData);
		archive.WriteDomainDataMeta(3);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiSkillBreakBonus);
		archive.WriteDomainDataMeta(4);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiBreakBonusTemplateIds);
		archive.WriteDomainDataMeta(6);
		archive.WriteSingleValueUnmanagedList(_threeVitalsReplaceTeammateRecordNew);
		archive.WriteDomainDataMeta(7);
		archive.WriteSingleValueUnmanaged(_sectMainStoryCombatTimesShaolin);
		archive.WriteDomainDataMeta(8);
		archive.WriteSingleValueUnmanagedList(_advanceXiangshuAvatarIds);
		archive.WriteDomainDataMeta(9);
		archive.WriteSingleValueCustom(_ironPlateData);
		archive.WriteDomainDataMeta(11);
		archive.WriteSingleValueCustom(_divineFlameData);
		archive.WriteDomainDataMeta(12);
		archive.WriteElementListCustom(_twelveImmortalsStatuses);
		archive.WriteDomainDataMeta(13);
		archive.WriteSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiGuidance);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			switch (domainDataMeta.DataId)
			{
			case 0:
				archive.ReadElementListUnmanaged(_sectMainStoryTaskStatus);
				break;
			case 1:
				archive.ReadSingleValueCustom(ref _wordless);
				break;
			case 2:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiBreakBonusData);
				break;
			case 3:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiSkillBreakBonus);
				break;
			case 4:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiBreakBonusTemplateIds);
				break;
			case 5:
				archive.ReadSingleValueUnmanagedArray(ref _threeVitalsReplaceTeammateRecord);
				break;
			case 6:
				archive.ReadSingleValueUnmanagedList(ref _threeVitalsReplaceTeammateRecordNew);
				break;
			case 7:
				archive.ReadSingleValueUnmanaged(ref _sectMainStoryCombatTimesShaolin);
				break;
			case 8:
				archive.ReadSingleValueUnmanagedList(ref _advanceXiangshuAvatarIds);
				break;
			case 9:
				archive.ReadSingleValueCustom(ref _ironPlateData);
				break;
			case 10:
				archive.ReadSingleValueUnmanaged(ref _noMindGuyUsed);
				break;
			case 11:
				archive.ReadSingleValueCustom(ref _divineFlameData);
				break;
			case 12:
				archive.ReadElementListCustom(_twelveImmortalsStatuses);
				break;
			case 13:
				archive.ReadSingleValueCollectionUnmanagedKeyCustomValue(_sectEmeiGuidance);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(20);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(_dataStatesSectMainStoryTaskStatus, (int)subId0);
			}
			return GameData.Serializer.Serializer.Serialize(_sectMainStoryTaskStatus[(uint)subId0], dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(_wordless, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
				_modificationsSectEmeiBreakBonusData.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_sectEmeiBreakBonusData, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsSectEmeiSkillBreakBonus.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_sectEmeiSkillBreakBonus, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsSectEmeiBreakBonusTemplateIds.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_sectEmeiBreakBonusTemplateIds, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_threeVitalsReplaceTeammateRecord, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			return GameData.Serializer.Serializer.Serialize(_threeVitalsReplaceTeammateRecordNew, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			return GameData.Serializer.Serializer.Serialize(_sectMainStoryCombatTimesShaolin, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			return GameData.Serializer.Serializer.Serialize(_advanceXiangshuAvatarIds, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			return GameData.Serializer.Serializer.Serialize(_ironPlateData, dataPool);
		case 10:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			return GameData.Serializer.Serializer.Serialize(_noMindGuyUsed, dataPool);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_divineFlameData, dataPool);
		case 12:
			throw new Exception($"Not allow to get value of dataId: {dataId}");
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
				_modificationsSectEmeiGuidance.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_sectEmeiGuidance, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			return GameData.Serializer.Serializer.Serialize(_sectEmeiGuidanceData, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
		{
			sbyte value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			_sectMainStoryTaskStatus[(uint)subId0] = value;
			SetElement_SectMainStoryTaskStatus((int)subId0, value, context);
			break;
		}
		case 1:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _wordless);
			SetWordless(_wordless, context);
			break;
		case 2:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 3:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 4:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _threeVitalsReplaceTeammateRecord);
			SetThreeVitalsReplaceTeammateRecord(_threeVitalsReplaceTeammateRecord, context);
			break;
		case 6:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _threeVitalsReplaceTeammateRecordNew);
			SetThreeVitalsReplaceTeammateRecordNew(_threeVitalsReplaceTeammateRecordNew, context);
			break;
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _advanceXiangshuAvatarIds);
			SetAdvanceXiangshuAvatarIds(_advanceXiangshuAvatarIds, context);
			break;
		case 9:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 10:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 11:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 12:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 13:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 14:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _sectEmeiGuidanceData);
			SetSectEmeiGuidanceData(_sectEmeiGuidanceData, context);
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				sbyte orgTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId2);
				int returnValue19 = GetSectMainStoryActiveStatus(orgTemplateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 2)
			{
				sbyte orgTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId);
				bool pause = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref pause);
				SetSectMainStoryActiveStatus(orgTemplateId, pause);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 1)
			{
				sbyte orgTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref orgTemplateId3);
				NotifySectStoryActivated(context, orgTemplateId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
			if (operation.ArgsCount == 0)
			{
				sbyte returnValue33 = GetBaihuaLifeLinkNeiliType();
				return GameData.Serializer.Serializer.Serialize(returnValue33, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 4:
			if (operation.ArgsCount == 0)
			{
				SectBaihuaLifeLinkDisplayData returnValue10 = GetSectBaihuaLifeLinkDisplayData(context);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 5:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 3)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				int index3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index3);
				bool isLifeGate = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isLifeGate);
				SetLifeLinkCharacter(context, charId5, index3, isLifeGate);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 6:
			if (operation.ArgsCount == 0)
			{
				bool returnValue14 = ShaolinInterruptDemonSlayerTrial(context);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 7:
			if (operation.ArgsCount == 0)
			{
				bool returnValue38 = ShaolinRegenerateRestricts(context);
				return GameData.Serializer.Serializer.Serialize(returnValue38, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 8:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 1)
			{
				int index2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index2);
				byte returnValue27 = ShaolinQueryRestrictsAreSatisfied(index2);
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				ShaolinStartDemonSlayerTrial(context, index);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue2 = ShaolinGenerateTemporaryDemon(context);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 11:
		{
			int argsCount37 = operation.ArgsCount;
			int num37 = argsCount37;
			if (num37 == 1)
			{
				List<int> demonCharIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref demonCharIds);
				ShaolinClearTemporaryDemon(context, demonCharIds);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 3)
			{
				bool isMale = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isMale);
				string familyName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref familyName);
				string firstName = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref firstName);
				int returnValue29 = CreateMirrorCharacter(context, isMale, familyName, firstName);
				return GameData.Serializer.Serializer.Serialize(returnValue29, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 3)
			{
				bool includeGrownTree = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref includeGrownTree);
				Location curTreeLocation = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref curTreeLocation);
				List<Location> viewTreeLocationList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref viewTreeLocationList);
				DefendHeavenlyTreeDisplayData returnValue22 = GetDefendHeavenlyTreeDisplayData(includeGrownTree, curTreeLocation, viewTreeLocationList);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 14:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				int treeId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref treeId);
				ItemDisplayData itemData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemData);
				bool returnValue15 = DefendHeavenlyTreeFeed(context, treeId, itemData);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
			if (operation.ArgsCount == 0)
			{
				int returnValue7 = TryTriggerThiefCatch(context);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 16:
		{
			int argsCount40 = operation.ArgsCount;
			int num40 = argsCount40;
			if (num40 == 2)
			{
				sbyte thiefLevel = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref thiefLevel);
				bool timeOut = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref timeOut);
				CatchThief(thiefLevel, timeOut);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 17:
		{
			int argsCount36 = operation.ArgsCount;
			int num36 = argsCount36;
			if (num36 == 2)
			{
				int gearMateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gearMateId5);
				int characterId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterId);
				SectZhujianGearMateAttributeDisplayData returnValue35 = GetSectZhujianGearMateAttributeDisplayData(context, gearMateId5, characterId);
				return GameData.Serializer.Serializer.Serialize(returnValue35, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 2)
			{
				int gearMateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gearMateId4);
				bool isCombatSkill = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isCombatSkill);
				SectZhujianGearMateSkillDisplayData returnValue30 = GetSectZhujianGearMateSkillDisplayData(context, gearMateId4, isCombatSkill);
				return GameData.Serializer.Serializer.Serialize(returnValue30, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 1)
			{
				int gearMateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gearMateId3);
				SectZhujianGearMateBreakoutDisplayData returnValue25 = GetGearMateBreakoutDisplayData(gearMateId3);
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				int gearMateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gearMateId2);
				SectZhujianGearMateFeatureDisplayData returnValue20 = GetSectZhujianGearMateFeatureDisplayData(context, gearMateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 1)
			{
				int gearMateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref gearMateId);
				SectZhujianGearMateConsummateDisplayData returnValue17 = GetSectZhujianGearMateConsummateDisplayData(context, gearMateId);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
			if (operation.ArgsCount == 0)
			{
				bool returnValue11 = JingangMonkSoulBtnShow();
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 23:
			if (operation.ArgsCount == 0)
			{
				List<CharacterDisplayData> returnValue5 = GetCurAreaValidCharactersForTripodVessel(context);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 24:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 2)
			{
				List<int> characterIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref characterIds);
				List<ItemKeyAndCount> selectedWugKingCountList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref selectedWugKingCountList);
				ApplyKongsangSpecialInteract(context, characterIds, selectedWugKingCountList);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 25:
		{
			int argsCount38 = operation.ArgsCount;
			int num38 = argsCount38;
			if (num38 == 1)
			{
				short combatSkillId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId6);
				SkillBreakBonusCollection returnValue37 = GetEmeiBreakBonusCollection(combatSkillId6);
				return GameData.Serializer.Serializer.Serialize(returnValue37, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
		{
			int argsCount34 = operation.ArgsCount;
			int num34 = argsCount34;
			if (num34 == 2)
			{
				short combatSkillId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId5);
				short bonusTypeTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bonusTypeTemplateId3);
				bool returnValue34 = AddEmeiSkillBreakBonus(context, combatSkillId5, bonusTypeTemplateId3);
				return GameData.Serializer.Serializer.Serialize(returnValue34, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 27:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 2)
			{
				short combatSkillId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId4);
				short bonusTypeTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bonusTypeTemplateId2);
				bool returnValue32 = GmCmd_SectEmeiAddSkillBreakBonus(context, combatSkillId4, bonusTypeTemplateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue32, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 28:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				short combatSkillId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId3);
				SectStoryBonusDisplayData returnValue28 = GetEmeiBreakBonusDisplayData(combatSkillId3);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 29:
			if (operation.ArgsCount == 0)
			{
				SectEmeiSpecialBreakDisplayData returnValue24 = GetSectEmeiSpecialBreakDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 30:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 2)
			{
				short bonusTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bonusTemplateId);
				List<ItemKey> itemKeys = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKeys);
				bool returnValue21 = EmeiTransferBonusProgress(context, bonusTemplateId, itemKeys);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 2)
			{
				short combatSkillId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId2);
				short bonusTypeTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bonusTypeTemplateId);
				bool returnValue18 = RemoveEmeiSkillBreakBonus(context, combatSkillId2, bonusTypeTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 32:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 1)
			{
				short combatSkillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId);
				bool returnValue16 = GmCmd_SectEmeiClearSkillBreakBonus(context, combatSkillId);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 33:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				int returnValue13 = GetSectMainStoryTriggerConditions(templateId);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 34:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 3)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				sbyte wugType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref wugType);
				sbyte driveType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref driveType);
				bool returnValue8 = DriveWugKing(context, charId2, wugType, driveType);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 35:
			if (operation.ArgsCount == 0)
			{
				ItemKey returnValue4 = RefiningWugKing(context);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 36:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 1)
			{
				Inventory poisonMaterials = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisonMaterials);
				bool returnValue = DropPoisonsToWugJug(context, poisonMaterials);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 37:
		{
			int argsCount39 = operation.ArgsCount;
			int num39 = argsCount39;
			if (num39 == 1)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				List<WugKingDriveDisplayData> returnValue39 = GetWugKingDriveStatuses(charId6);
				return GameData.Serializer.Serializer.Serialize(returnValue39, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue36 = GetThreeVitalsReplaceTeammateRecord(context);
				return GameData.Serializer.Serializer.Serialize(returnValue36, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 39:
		{
			int argsCount35 = operation.ArgsCount;
			int num35 = argsCount35;
			if (num35 == 1)
			{
				int typeInt2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt2);
				ThreeVitalsReplaceTeammateRecordRemove(context, typeInt2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 40:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 2)
			{
				int typeInt = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt);
				int index4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index4);
				ThreeVitalsReplaceTeammateRecordSet(context, typeInt, index4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 41:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 2)
			{
				int treeId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref treeId2);
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				SectWudangDefendHeavenlyTreeDisplayData returnValue31 = DefendHeavenlyTreeClearEnemy(context, treeId2, charId4);
				return GameData.Serializer.Serializer.Serialize(returnValue31, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 42:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ClearIronPlateCooldown(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 43:
			if (operation.ArgsCount == 0)
			{
				int returnValue26 = GetIronPlateCombatCharId(context);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 44:
			if (operation.ArgsCount == 0)
			{
				List<int> returnValue23 = GetIronPlateOptionCharIdList(context);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 45:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 1)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				SetIconPlateFollowingCharId(context, charId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 46:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 1)
			{
				bool isUnlocked2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isUnlocked2);
				GmCmd_SetIconPlateIsUnlocked(context, isUnlocked2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 47:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ClearDivineFlameCooldown(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 48:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				bool isUnlocked = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isUnlocked);
				GmCmd_SetDivineFlameIsUnlocked(context, isUnlocked);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 49:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 3)
			{
				sbyte xiangshuAvatarId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref xiangshuAvatarId4);
				int targetCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetCharId);
				Location targetLocation = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetLocation);
				UseDivineFlame(context, xiangshuAvatarId4, targetCharId, targetLocation);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 50:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				sbyte xiangshuAvatarId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref xiangshuAvatarId3);
				List<int> returnValue12 = GetDivineFlameSelectTargetCharIdList(context, xiangshuAvatarId3);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 51:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				sbyte xiangshuAvatarId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref xiangshuAvatarId2);
				bool returnValue9 = CheckDivineFlameTarget(context, xiangshuAvatarId2);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 52:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 2)
			{
				sbyte xiangshuAvatarId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref xiangshuAvatarId);
				Location location2 = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location2);
				List<Location> returnValue6 = GetDivineFlameSelectTargetLocationList(context, xiangshuAvatarId, location2);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 53:
			if (operation.ArgsCount == 0)
			{
				DivineFlameData returnValue3 = GetDivineFlameDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 54:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				Location location = default(Location);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref location);
				UpdateSectEmeiGuidanceData(context, location);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 55:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				OnClickEmeiGuidance(context, charId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		switch (dataId)
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			_modificationsSectEmeiBreakBonusData.ChangeRecording(monitoring);
			break;
		case 3:
			_modificationsSectEmeiSkillBreakBonus.ChangeRecording(monitoring);
			break;
		case 4:
			_modificationsSectEmeiBreakBonusTemplateIds.ChangeRecording(monitoring);
			break;
		case 5:
			break;
		case 6:
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
			break;
		case 13:
			_modificationsSectEmeiGuidance.ChangeRecording(monitoring);
			break;
		case 14:
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		switch (dataId)
		{
		case 0:
			if (!BaseGameDataDomain.IsModified(_dataStatesSectMainStoryTaskStatus, (int)subId0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(_dataStatesSectMainStoryTaskStatus, (int)subId0);
			return GameData.Serializer.Serializer.Serialize(_sectMainStoryTaskStatus[(uint)subId0], dataPool);
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_wordless, dataPool);
		case 2:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_sectEmeiBreakBonusData, dataPool, _modificationsSectEmeiBreakBonusData);
			_modificationsSectEmeiBreakBonusData.Reset();
			return offset;
		}
		case 3:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_sectEmeiSkillBreakBonus, dataPool, _modificationsSectEmeiSkillBreakBonus);
			_modificationsSectEmeiSkillBreakBonus.Reset();
			return offset3;
		}
		case 4:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			int offset4 = GameData.Serializer.Serializer.SerializeModifications(_sectEmeiBreakBonusTemplateIds, dataPool, _modificationsSectEmeiBreakBonusTemplateIds);
			_modificationsSectEmeiBreakBonusTemplateIds.Reset();
			return offset4;
		}
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_threeVitalsReplaceTeammateRecord, dataPool);
		case 6:
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			return GameData.Serializer.Serializer.Serialize(_threeVitalsReplaceTeammateRecordNew, dataPool);
		case 7:
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			return GameData.Serializer.Serializer.Serialize(_sectMainStoryCombatTimesShaolin, dataPool);
		case 8:
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			return GameData.Serializer.Serializer.Serialize(_advanceXiangshuAvatarIds, dataPool);
		case 9:
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			return GameData.Serializer.Serializer.Serialize(_ironPlateData, dataPool);
		case 10:
			if (!BaseGameDataDomain.IsModified(DataStates, 10))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 10);
			return GameData.Serializer.Serializer.Serialize(_noMindGuyUsed, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_divineFlameData, dataPool);
		case 12:
			throw new Exception($"Not allow to check modification of dataId {dataId}");
		case 13:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_sectEmeiGuidance, dataPool, _modificationsSectEmeiGuidance);
			_modificationsSectEmeiGuidance.Reset();
			return offset2;
		}
		case 14:
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			return GameData.Serializer.Serializer.Serialize(_sectEmeiGuidanceData, dataPool);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			if (BaseGameDataDomain.IsModified(_dataStatesSectMainStoryTaskStatus, (int)subId0))
			{
				BaseGameDataDomain.ResetModified(_dataStatesSectMainStoryTaskStatus, (int)subId0);
			}
			break;
		case 1:
			if (BaseGameDataDomain.IsModified(DataStates, 1))
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			break;
		case 2:
			if (BaseGameDataDomain.IsModified(DataStates, 2))
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
				_modificationsSectEmeiBreakBonusData.Reset();
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
				_modificationsSectEmeiSkillBreakBonus.Reset();
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
				_modificationsSectEmeiBreakBonusTemplateIds.Reset();
			}
			break;
		case 5:
			if (BaseGameDataDomain.IsModified(DataStates, 5))
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			break;
		case 6:
			if (BaseGameDataDomain.IsModified(DataStates, 6))
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
			}
			break;
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
			}
			break;
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
			}
			break;
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			break;
		case 10:
			if (BaseGameDataDomain.IsModified(DataStates, 10))
			{
				BaseGameDataDomain.ResetModified(DataStates, 10);
			}
			break;
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			break;
		case 12:
			throw new Exception($"Not allow to reset modification state of dataId {dataId}");
		case 13:
			if (BaseGameDataDomain.IsModified(DataStates, 13))
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
				_modificationsSectEmeiGuidance.Reset();
			}
			break;
		case 14:
			if (BaseGameDataDomain.IsModified(DataStates, 14))
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			break;
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		return dataId switch
		{
			0 => BaseGameDataDomain.IsModified(_dataStatesSectMainStoryTaskStatus, (int)subId0), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => BaseGameDataDomain.IsModified(DataStates, 6), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			9 => BaseGameDataDomain.IsModified(DataStates, 9), 
			10 => BaseGameDataDomain.IsModified(DataStates, 10), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			12 => throw new Exception($"Not allow to verify modification state of dataId {dataId}"), 
			13 => BaseGameDataDomain.IsModified(DataStates, 13), 
			14 => BaseGameDataDomain.IsModified(DataStates, 14), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		default:
			throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
	}
}

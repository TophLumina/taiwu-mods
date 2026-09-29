using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Config;
using GameData.Achievement;
using GameData.ArchiveData;
using GameData.Combat.Animation;
using GameData.Combat.Chicken;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Common.SingleValueCollection;
using GameData.DLC;
using GameData.DLC.SmarterChicken;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat.Ai;
using GameData.Domains.Combat.Chicken;
using GameData.Domains.Combat.MixPoison;
using GameData.Domains.Combat.Profession;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.SpecialEffect;
using GameData.Domains.SpecialEffect.Adventure.EnemyNest;
using GameData.Domains.SpecialEffect.Chicken;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Tutorial;
using GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.WugEffect;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;
using GameData.Domains.SpecialEffect.SectStory.Baihua;
using GameData.Domains.SpecialEffect.SectStory.Fulong;
using GameData.Domains.Story.MainStory;
using GameData.Domains.Story.SectMainStory;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

[GameDataDomain(8)]
public class CombatDomain : BaseGameDataDomain
{
	public delegate void OnCombatCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type);

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private float _timeScale;

	[DomainData(DomainDataType.SingleValue, false, false, true, false)]
	private bool _autoCombat;

	private float _frameTimeAccumulator;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private ulong _combatFrame;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _combatType;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _isPuppetCombat;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _isPlaygroundCombat;

	public CombatConfigItem CombatConfig;

	private bool _inBulletTime;

	private float _timeScaleSaveInBulletTime;

	public sbyte TestSkillCounter;

	private bool _saveDyingEffectTriggerd;

	public DataContext Context;

	private bool _isTutorialCombat;

	private bool _enableEnemyAiInTutorial;

	private bool _enableEnemyAi = true;

	private bool _enableSkillFreeCast = false;

	public AiOptions AiOptions = new AiOptions();

	private const int AppearCd = 120;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private ChickenPointZones _chickenPointZones;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private CountdownData _nextAvailableChickenPointAppearCd;

	private int _nextChickenPointId;

	public const short CombatStatePowerLimit = 500;

	public const sbyte MaxFlawCount = 3;

	public const sbyte MaxAcupointCount = 3;

	private const short NoArmorEquipAttack = 100;

	private const short NoArmorEquipDefense = 50;

	public const sbyte MinEffectPercent = 33;

	private readonly string[][] _avoidSound = new string[4][]
	{
		new string[3] { "se_combat_block_combat_1", "se_combat_block_combat_2", "se_combat_block_combat_3" },
		new string[3] { "se_combat_block_combat_1", "se_combat_block_combat_2", "se_combat_block_combat_3" },
		new string[3] { "se_combat_block_dodge_1", "se_combat_block_dodge_2", "se_combat_block_dodge_3" },
		new string[3] { "se_combat_block_dodge_1", "se_combat_block_dodge_2", "se_combat_block_dodge_3" }
	};

	private const string NoDamageParticle = "Particle_D_qidun";

	public static readonly Dictionary<short, sbyte> CharId2BossId = new Dictionary<short, sbyte>();

	public const string SkillMoveForwardAni = "M_003";

	public const string SkillMoveBackwardAni = "M_004";

	public const string JumpMovePrepareAni = "C_007";

	public const string JumpMoveForwardAni = "M_003_fly";

	public const string JumpMoveBackwardAni = "M_004_fly";

	public const string SlowForwardAni = "M_014";

	public const string SlowBackwardAni = "M_015";

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private short _currentDistance;

	private static readonly sbyte[] AccessoryDropRateBonusSlot = new sbyte[6] { 8, 9, 10, 14, 15, 16 };

	private readonly CombatResultDisplayData _combatResultData = new CombatResultDisplayData();

	private static readonly Dictionary<ECombatEvaluationExtraCheck, Func<bool>> EvaluationCheckers = new Dictionary<ECombatEvaluationExtraCheck, Func<bool>>
	{
		[ECombatEvaluationExtraCheck.Fail] = FailChecker,
		[ECombatEvaluationExtraCheck.Draw] = DrawChecker,
		[ECombatEvaluationExtraCheck.Flee] = FleeChecker,
		[ECombatEvaluationExtraCheck.Win] = WinChecker,
		[ECombatEvaluationExtraCheck.FightSameLevel] = FightSameLevelChecker,
		[ECombatEvaluationExtraCheck.FightLessLevel] = FightLessLevelChecker,
		[ECombatEvaluationExtraCheck.BeatXiangShu] = BeatXiangShuChecker,
		[ECombatEvaluationExtraCheck.WinLess] = WinLessChecker,
		[ECombatEvaluationExtraCheck.WinChild] = WinChildChecker,
		[ECombatEvaluationExtraCheck.WinWorseEquip] = WinWorseEquipChecker,
		[ECombatEvaluationExtraCheck.WinLessNeili] = WinLessNeiliChecker,
		[ECombatEvaluationExtraCheck.WinWorseSkill] = WinWorseSkillChecker,
		[ECombatEvaluationExtraCheck.WinLessConsummate] = WinLessConsummateChecker,
		[ECombatEvaluationExtraCheck.WinPregnant] = WinPregnantChecker,
		[ECombatEvaluationExtraCheck.WinMore] = WinMoreChecker,
		[ECombatEvaluationExtraCheck.WinOlder] = WinOlderChecker,
		[ECombatEvaluationExtraCheck.WinBetterEquip] = WinBetterEquipChecker,
		[ECombatEvaluationExtraCheck.WinMoreNeili] = WinMoreNeiliChecker,
		[ECombatEvaluationExtraCheck.WinBetterSkill] = WinBetterSkillChecker,
		[ECombatEvaluationExtraCheck.WinMoreConsummate] = WinMoreConsummateChecker,
		[ECombatEvaluationExtraCheck.WinInPregnant] = WinInPregnantChecker,
		[ECombatEvaluationExtraCheck.KillBad0] = KillBad0Checker,
		[ECombatEvaluationExtraCheck.KillBad1] = KillBad1Checker,
		[ECombatEvaluationExtraCheck.KillGood0] = KillGood0Checker,
		[ECombatEvaluationExtraCheck.KillGood1] = KillGood1Checker,
		[ECombatEvaluationExtraCheck.KillMinion0] = KillMinion0Checker,
		[ECombatEvaluationExtraCheck.KillMinion1] = KillMinion1Checker,
		[ECombatEvaluationExtraCheck.ShixiangBuff0] = ShixiangBuff0Checker,
		[ECombatEvaluationExtraCheck.ShixiangBuff1] = ShixiangBuff1Checker,
		[ECombatEvaluationExtraCheck.ShixiangBuff2] = ShixiangBuff2Checker,
		[ECombatEvaluationExtraCheck.PuppetCombat] = PuppetCombatChecker,
		[ECombatEvaluationExtraCheck.OutBossCombat] = OutBossCombatChecker,
		[ECombatEvaluationExtraCheck.WinLoong] = WinLoongChecker,
		[ECombatEvaluationExtraCheck.CombatHard] = CombatHardChecker,
		[ECombatEvaluationExtraCheck.CombatVeryHard] = CombatVeryHardChecker
	};

	private static readonly CValuePercentBonus WinNeiliMinDelta = 25;

	public sbyte SelfMaxSkillGrade;

	public sbyte EnemyMaxSkillGrade;

	private readonly List<int> _lootCharList = new List<int>();

	private static OnCombatCharAboutToFall _handlersCombatCharAboutToFall;

	private Dictionary<StoryTeammateType, int> _vitalTeammateData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private DamageCompareData _damageCompareData;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private SkillDamageData _skillDamageData;

	public static readonly string[] InjuryAni = new string[3] { "H_003", "H_004", "H_005" };

	public static readonly string[] AvoidAni = new string[4] { "H_002", "H_001", "H_000", "H_002" };

	private static readonly sbyte[] AddCaptureRateEquipSlot = new sbyte[6] { 8, 9, 10, 14, 15, 16 };

	public const sbyte RopeEnsureHitConsummateGap = 6;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private SpecialMiscData _showUseGoldenWire;

	public Dictionary<int, int> EquipmentPowerChangeInCombat = new Dictionary<int, int>();

	public Dictionary<ItemKey, int> EquipmentOldDurability = new Dictionary<ItemKey, int>();

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private List<CombatQuickUseItemSlotData> _combatQuickUseItemSlotDataList;

	public const byte NormalWeaponCount = 3;

	public const byte MaxWeaponCount = 7;

	public const int WeaponIndexEmptyHand = 3;

	public const int WeaponIndexBranch = 4;

	public const int WeaponIndexStone = 5;

	public const int WeaponIndexVoice = 6;

	public const byte WeaponTrickCount = 6;

	public const byte MaxPursueAttack = 5;

	public const short NormalAttackMoveWaitFrame = 6;

	private static readonly Dictionary<sbyte, sbyte> GodTrickUseTrickType = new Dictionary<sbyte, sbyte>
	{
		[0] = 3,
		[1] = 5,
		[2] = 4,
		[3] = 9
	};

	[DomainData(DomainDataType.ObjectCollection, false, false, true, true)]
	private Dictionary<int, CombatWeaponData> _weaponDataDict;

	[Obsolete]
	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private WeaponExpectInnerRatioData _expectRatioData;

	[Obsolete("This field is obsolete and will be removed in future, use _skillDamageData instead.")]
	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private SkillIndexAndHitData _notUsed;

	public const string OtherActionPrepareAni = "C_007";

	public static readonly int[] OtherActionSpecialEffectId = new int[2] { 1457, 1459 };

	public static readonly short[] OtherActionPrepareFrame = new short[5] { 320, 320, 600, 120, -1 };

	public const short HealInjuryMinPrepareFrame = 120;

	public const short HealPoisonMinPrepareFrame = 120;

	private static readonly Dictionary<sbyte, MixPoisonEffectDelegate> MixPoisonEffectImplements = new Dictionary<sbyte, MixPoisonEffectDelegate>();

	public const string CommonPrepareAni = "C_007";

	public const string SkillFinalAvoidAni = "H_008";

	[DomainData(DomainDataType.ObjectCollection, false, false, true, true)]
	private Dictionary<CombatSkillKey, CombatSkillData> _skillDataDict;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, true)]
	private Dictionary<CombatSkillKey, SkillPowerChangeCollection> _skillPowerAddInCombat;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, true)]
	private Dictionary<CombatSkillKey, SkillPowerChangeCollection> _skillPowerReduceInCombat;

	[DomainData(DomainDataType.SingleValueCollection, false, false, true, true)]
	private Dictionary<CombatSkillKey, CombatSkillKey> _skillPowerReplaceInCombat;

	private readonly Dictionary<CombatSkillKey, int> _skillCastTimes = new Dictionary<CombatSkillKey, int>();

	private const string NoResourceTypeWhooshSound = "se_combat_whoosh_empty";

	private static readonly string[] NoResourceTypeStepSound = new string[2] { "se_combat_foot_empty_1", "se_combat_foot_empty_2" };

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _bgmIndex;

	private const string CombatStatisticsHandlerKey = "CombatStatisticsHandler";

	private readonly List<DataUid> _statisticsDataUids = new List<DataUid>();

	private const byte TeamCapacity = 4;

	public const sbyte MaxTeammateCommandCount = 3;

	public const sbyte TeammateCommandBaseCdSpeed = 100;

	public const sbyte TeammateFightBaseBreathStancePercent = 50;

	public const sbyte TeammateFightBaseMobilityPercent = 50;

	[DomainData(DomainDataType.ObjectCollection, false, false, true, true)]
	private Dictionary<int, CombatCharacter> _combatCharacterDict;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private List<int> _taiwuSpecialGroupCharIds;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, ArrayElementsCount = 4)]
	private int[] _selfTeam;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private int _selfCharId;

	private CombatCharacter _selfChar;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EWisdomType _selfTeamWisdomType;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private short _selfTeamWisdomCount;

	[DomainData(DomainDataType.SingleValue, false, false, true, true, ArrayElementsCount = 4)]
	private int[] _enemyTeam;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private int _enemyCharId;

	private CombatCharacter _enemyChar;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private EWisdomType _enemyTeamWisdomType;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private short _enemyTeamWisdomCount;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private int _carrierAnimalCombatCharId;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private int _specialShowCombatCharId;

	public TeammateCommandChangeData PreRandomizedTeammateCommandReplaceData;

	public static readonly Dictionary<ETeammateCommandImplement, ETeammateCommandOption> TeammateCommandOptions = new Dictionary<ETeammateCommandImplement, ETeammateCommandOption>();

	private static readonly Dictionary<ETeammateCommandImplement, ITeammateCommandChecker> TeammateCommandCheckers = new Dictionary<ETeammateCommandImplement, ITeammateCommandChecker>
	{
		{
			ETeammateCommandImplement.Fight,
			new TeammateCommandCheckerFight()
		},
		{
			ETeammateCommandImplement.AccelerateCast,
			new TeammateCommandCheckerAccelerateCast()
		},
		{
			ETeammateCommandImplement.Push,
			new TeammateCommandCheckerPush()
		},
		{
			ETeammateCommandImplement.Pull,
			new TeammateCommandCheckerPull()
		},
		{
			ETeammateCommandImplement.Attack,
			new TeammateCommandCheckerAttack()
		},
		{
			ETeammateCommandImplement.AttackSkill,
			new TeammateCommandCheckerAttackSkill()
		},
		{
			ETeammateCommandImplement.Defend,
			new TeammateCommandCheckerDefendSkill()
		},
		{
			ETeammateCommandImplement.HealInjury,
			new TeammateCommandCheckerHealInjury()
		},
		{
			ETeammateCommandImplement.HealPoison,
			new TeammateCommandCheckerHealPoison()
		},
		{
			ETeammateCommandImplement.HealFlaw,
			new TeammateCommandCheckerHealFlaw()
		},
		{
			ETeammateCommandImplement.HealAcupoint,
			new TeammateCommandCheckerHealAcupoint()
		},
		{
			ETeammateCommandImplement.AddHit,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.AddAvoid,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.StopEnemy,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.TransferNeiliAllocation,
			new TeammateCommandCheckerTransferNeiliAllocation()
		},
		{
			ETeammateCommandImplement.TransferInjury,
			new TeammateCommandCheckerTransferInjury()
		},
		{
			ETeammateCommandImplement.InterruptSkill,
			new TeammateCommandCheckerAccelerateCast()
		},
		{
			ETeammateCommandImplement.PushOrPullIntoDanger,
			new TeammateCommandCheckerPushOrPullIntoDanger()
		},
		{
			ETeammateCommandImplement.AttackFlawAndAcupoint,
			new TeammateCommandCheckerAttack()
		},
		{
			ETeammateCommandImplement.ClearAgileAndDefense,
			new TeammateCommandCheckerClearAgileAndDefense()
		},
		{
			ETeammateCommandImplement.AddInjuryAndPoison,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.ReduceHitAndAvoid,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.InterruptOtherAction,
			new TeammateCommandCheckerInterruptOtherAction()
		},
		{
			ETeammateCommandImplement.ReduceNeiliAllocation,
			new TeammateCommandCheckerReduceNeiliAllocation()
		},
		{
			ETeammateCommandImplement.AnimalEffect,
			new TeammateCommandCheckerAnimalEffect()
		},
		{
			ETeammateCommandImplement.GearMateA,
			new TeammateCommandCheckerAttack()
		},
		{
			ETeammateCommandImplement.GearMateB,
			new TeammateCommandCheckerDefendSkill()
		},
		{
			ETeammateCommandImplement.GearMateC,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.GearMateD,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.GearMateE,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.GearMateF,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.AddUnlockAttackValue,
			new TeammateCommandCheckerAddUnlockAttackValue()
		},
		{
			ETeammateCommandImplement.TransferManyMark,
			new TeammateCommandCheckerTransferManyMark()
		},
		{
			ETeammateCommandImplement.RepairItem,
			new TeammateCommandCheckerRepairItem()
		},
		{
			ETeammateCommandImplement.VitalDemonA,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.VitalDemonB,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.VitalDemonC,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.InterruptEnemySkill,
			new TeammateCommandCheckerInterruptEnemySkill()
		},
		{
			ETeammateCommandImplement.CriticalBonus,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.NormalAttackAddFatal,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.FightBackBonus,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.DefendFlawAndAcupoint,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.BounceBonus,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.FatalBonus,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.RecoverAttack,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.NormalAttackAddMind,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.MinorAttributeRandomToZero,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.IntoUpheaval,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.ExchangeMobility,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.AddInjuryOnEmpty,
			new TeammateCommandCheckerAddInjuryOnEmpty()
		},
		{
			ETeammateCommandImplement.AddFlawOrAcupoint,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.MergeFatalToDie,
			new TeammateCommandCheckerMergeFatalToDie()
		},
		{
			ETeammateCommandImplement.RemoveState,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.AbsorbNeiliAllocation,
			new TeammateCommandCheckerAbsorbNeiliAllocation()
		},
		{
			ETeammateCommandImplement.AttackSpecialPoison,
			new TeammateCommandCheckerAttack()
		},
		{
			ETeammateCommandImplement.FightSpecialGrow,
			new TeammateCommandCheckerFight()
		},
		{
			ETeammateCommandImplement.AddPowerUntilCast,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.SilenceRandomSkill,
			new TeammateCommandCheckerSimple()
		},
		{
			ETeammateCommandImplement.GotoTargetDistance,
			new TeammateCommandCheckerGotoTargetDistance()
		},
		{
			ETeammateCommandImplement.AddChickenPoint,
			new TeammateCommandCheckerAddChickenPoint()
		}
	};

	private static readonly string[] FailAni = new string[4] { "C_005", "C_012", "C_011", "C_005" };

	private static readonly string[] FailSound = new string[4] { "", "", "se_c_011", "" };

	private const string WaitMercyAni = "C_011_stun";

	private const string FallAni = "C_005";

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _combatStatus;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private bool _waitingDelaySettlement;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _showMercyOption;

	[DomainData(DomainDataType.SingleValue, false, false, true, true)]
	private sbyte _selectedMercyOption;

	private readonly HashSet<int> _needCheckFallenCharSet = new HashSet<int>();

	private bool _skipCombatLoop;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private sbyte _changeTrickIndex;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private sbyte _changeTrickBodyPart;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _changeTrickIsFlaw;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _enemyUnyieldingFallen;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private bool _disableEnemyAi;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private short _lastTargetDistance;

	[DomainData(DomainDataType.SingleValue, true, false, true, true)]
	private int _preferWeaponIndex;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[44][];

	private SingleValueCollectionModificationCollection<CombatSkillKey> _modificationsSkillPowerAddInCombat = SingleValueCollectionModificationCollection<CombatSkillKey>.Create();

	private SingleValueCollectionModificationCollection<CombatSkillKey> _modificationsSkillPowerReduceInCombat = SingleValueCollectionModificationCollection<CombatSkillKey>.Create();

	private SingleValueCollectionModificationCollection<CombatSkillKey> _modificationsSkillPowerReplaceInCombat = SingleValueCollectionModificationCollection<CombatSkillKey>.Create();

	private static readonly DataInfluence[][] CacheInfluencesCombatCharacterDict = new DataInfluence[152][];

	private readonly ObjectCollectionDataStates _dataStatesCombatCharacterDict = new ObjectCollectionDataStates(152, 0);

	public readonly ObjectCollectionHelperData HelperDataCombatCharacterDict;

	private static readonly DataInfluence[][] CacheInfluencesSkillDataDict = new DataInfluence[10][];

	private readonly ObjectCollectionDataStates _dataStatesSkillDataDict = new ObjectCollectionDataStates(10, 0);

	public readonly ObjectCollectionHelperData HelperDataSkillDataDict;

	private static readonly DataInfluence[][] CacheInfluencesWeaponDataDict = new DataInfluence[10][];

	private readonly ObjectCollectionDataStates _dataStatesWeaponDataDict = new ObjectCollectionDataStates(10, 0);

	public readonly ObjectCollectionHelperData HelperDataWeaponDataDict;

	private bool EnemyUnyieldingFallen => GetIsPlaygroundCombat() && _enemyUnyieldingFallen;

	private bool EnemyEnableAi => _enableEnemyAi && (!GetIsPlaygroundCombat() || !_disableEnemyAi) && (!_isTutorialCombat || _enableEnemyAiInTutorial);

	public bool Started { get; private set; }

	public bool Pause { get; private set; }

	public bool IsAiMoving => _selfChar.AiCanOperate(_autoCombat && AiOptions.AutoMove);

	public bool TaiwuInCombat => IsInCombat() && TaiwuInAllyMainChar;

	public bool NotInCombatOrTaiwuInCombat => !IsInCombat() || TaiwuInAllyMainChar;

	public bool TaiwuInAllyMainChar => _selfTeam[0] == DomainManager.Taiwu.GetTaiwuCharId();

	public float SelfAvgEquipGrade { get; private set; }

	public float EnemyAvgEquipGrade { get; private set; }

	private int CombatCharAboutToFallEventSendTimes => Enum.GetValues<ECombatCharAboutToFallType>().Length;

	public byte FleeNeedDistance => CombatConfig.FleeDistance;

	public byte InterruptFleeNeedDistance => CombatConfig.FleeInterruptDistance;

	private bool DisableAchievement => _isPuppetCombat || _isPlaygroundCombat || DomainManager.Global.GetCurrGameWorldType() != 1;

	private void OnInitializedDomainData()
	{
		_handlersCombatCharAboutToFall = null;
	}

	private void InitializeOnInitializeGameDataModule()
	{
		for (sbyte bossId = 0; bossId < Boss.Instance.Count; bossId++)
		{
			short[] charIdList = Boss.Instance[bossId].CharacterIdList;
			short[] array = charIdList;
			foreach (short charId in array)
			{
				CharId2BossId[charId] = bossId;
			}
		}
		foreach (TeammateCommandItem cmd in (IEnumerable<TeammateCommandItem>)TeammateCommand.Instance)
		{
			if (TeammateCommandOptions.TryGetValue(cmd.Implement, out var option) && option != cmd.Option)
			{
				PredefinedLog.Show(8, $"cmd implement mapping to multi option {option} {cmd.Option}");
			}
			else
			{
				TeammateCommandOptions[cmd.Implement] = cmd.Option;
			}
		}
		SharedConstValue.InitializeCharId2AnimalIdCache();
		BindMixPoisonEffectImplements();
		AiNodeFactory.Register(GetType().Assembly);
		AiActionFactory.Register(GetType().Assembly);
		AiConditionFactory.Register(GetType().Assembly);
	}

	private void InitializeOnEnterNewWorld()
	{
		InitializeStatistics();
	}

	private void OnLoadedArchiveData()
	{
		InitializeStatistics();
	}

	[DomainMethod]
	public void PrepareEnemyEquipments(DataContext context, short combatConfigId, List<int> enemyList)
	{
		GameData.Domains.Character.Character mainChar = DomainManager.Character.GetElement_Objects(enemyList[0]);
		short charTemplateId = mainChar.GetTemplateId();
		bool isBoss = CharId2BossId.ContainsKey(charTemplateId);
		bool isAnimal = SharedConstValue.CharId2AnimalId.ContainsKey(charTemplateId);
		if (!(isBoss || isAnimal) && !DomainManager.Taiwu.GetGroupCharIds().Contains(mainChar.GetId()))
		{
			for (int i = 0; i < enemyList.Count; i++)
			{
				GameData.Domains.Character.Character enemyChar = DomainManager.Character.GetElement_Objects(enemyList[i]);
				context.Equipping.SelectEquipmentsByCombatConfig(context, enemyChar, combatConfigId, isOutOfTaiwuGroup: true);
			}
		}
	}

	public sbyte PrepareCombat(DataContext context, short combatConfigId, IReadOnlyList<int> selfTeam, IReadOnlyList<int> enemyTeam)
	{
		CombatConfig = Config.CombatConfig.Instance[combatConfigId];
		SetCombatStatus(0, context);
		SetWaitingDelaySettlement(value: false, context);
		SetTimeScale(0f, context);
		SetAutoCombat(value: false, context);
		SetCombatFrame(0uL, context);
		SetCombatType(CombatConfig.CombatType, context);
		SetShowMercyOption(context, EShowMercyOption.Invalid);
		SetSelectedMercyOption(context, EShowMercySelect.Unselected);
		ClearSkillDamage(context);
		if (CombatConfig.InitDistance < CombatConfig.MinDistance || CombatConfig.InitDistance > CombatConfig.MaxDistance)
		{
			(byte, byte) distanceRange = GetDistanceRange();
			short midDistance = (short)((distanceRange.Item1 + distanceRange.Item2) / 2);
			List<short> distanceRandomPool = ObjectPool<List<short>>.Instance.Get();
			distanceRandomPool.Clear();
			for (int i = -2; i <= 2; i++)
			{
				short distance = (short)(midDistance + 10 * i);
				if (distance < distanceRange.Item1)
				{
					distance = distanceRange.Item1;
				}
				else if (distance > distanceRange.Item2)
				{
					distance = distanceRange.Item2;
				}
				if (!distanceRandomPool.Contains(distance))
				{
					distanceRandomPool.Add(distance);
				}
			}
			SetCurrentDistance(distanceRandomPool.GetRandom(context.Random), context);
			ObjectPool<List<short>>.Instance.Return(distanceRandomPool);
		}
		else
		{
			SetCurrentDistance(CombatConfig.InitDistance, context);
		}
		_frameTimeAccumulator = 0f;
		_bgmIndex = 0;
		Started = false;
		_inBulletTime = false;
		_showUseGoldenWire = 0;
		Context = context;
		_isTutorialCombat = DomainManager.Character.GetElement_Objects(selfTeam[0]).GetTemplateId() == 908;
		_enableEnemyAiInTutorial = true;
		ClearCombatCharacterDict();
		for (int j = 0; j < 4; j++)
		{
			_selfTeam[j] = ((j < selfTeam.Count && selfTeam[j] >= 0) ? selfTeam[j] : (-1));
			_enemyTeam[j] = ((j < enemyTeam.Count && enemyTeam[j] >= 0) ? enemyTeam[j] : (-1));
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		for (int k = 0; k < 4; k++)
		{
			int selfCharId = _selfTeam[k];
			int enemyCharId = _enemyTeam[k];
			if (selfCharId >= 0)
			{
				CombatCharacter combatChar = new CombatCharacter();
				combatChar.IsAlly = true;
				combatChar.IsTaiwu = taiwuCharId == selfCharId;
				AddElement_CombatCharacterDict(selfCharId, combatChar);
				combatChar.Init(this, selfCharId, context);
			}
			if (enemyCharId >= 0)
			{
				CombatCharacter combatChar2 = new CombatCharacter();
				combatChar2.IsAlly = false;
				combatChar2.IsTaiwu = taiwuCharId == enemyCharId;
				AddElement_CombatCharacterDict(enemyCharId, combatChar2);
				combatChar2.Init(this, enemyCharId, context);
			}
		}
		InitSkillData(context);
		InitWeaponData(context);
		_selfChar = (_enemyChar = null);
		SetCombatCharacter(context, isAlly: true, _selfTeam[0]);
		SetCombatCharacter(context, isAlly: false, _enemyTeam[0]);
		InitEquipmentDurability();
		for (sbyte skillType = 0; skillType < 14; skillType++)
		{
			int bookCharId = DomainManager.LegendaryBook.GetOwner(skillType);
			if (bookCharId >= 0 && bookCharId != _selfTeam[0] && _combatCharacterDict.ContainsKey(bookCharId))
			{
				AddCombatState(context, _combatCharacterDict[bookCharId], 0, (short)(117 + skillType), 100, reverse: false, applyEffect: true, bookCharId);
			}
		}
		foreach (CombatCharacter combatChar3 in _combatCharacterDict.Values)
		{
			combatChar3.AiController = new AiController(combatChar3);
			combatChar3.AiController.Init();
		}
		PrepareCombatSpecial(context);
		PrepareCombatProfession(context);
		PrepareCombatAdventure(context, combatConfigId);
		PrepareCombatSectStory(context, combatConfigId);
		int selfWisdom = GetTeamWisdomCount(isAlly: true);
		int enemyWisdom = GetTeamWisdomCount(isAlly: false);
		SetSelfTeamWisdomType(WisdomTypeHelper.FromWisdomCount(selfWisdom), context);
		SetSelfTeamWisdomCount((short)Math.Abs(selfWisdom), context);
		SetEnemyTeamWisdomType(WisdomTypeHelper.FromWisdomCount(enemyWisdom), context);
		SetEnemyTeamWisdomCount((short)Math.Abs(enemyWisdom), context);
		EPrepareCombatResult firstMoveType = CFormulaHelper.RandomPrepareResult(_selfTeam, _enemyTeam, context.Random);
		bool firstMoveIsAlly = firstMoveType == EPrepareCombatResult.SelfFirst;
		_selfChar.SetBreathValue(30000 * (firstMoveIsAlly ? 30 : 0) / 100, context);
		_selfChar.SetStanceValue(4000 * (firstMoveIsAlly ? 30 : 0) / 100, context);
		_enemyChar.SetBreathValue(30000 * ((!firstMoveIsAlly) ? 30 : 0) / 100, context);
		_enemyChar.SetStanceValue(4000 * ((!firstMoveIsAlly) ? 30 : 0) / 100, context);
		CombatCharacter afterMoveChar = (firstMoveIsAlly ? _enemyChar : _selfChar);
		ChangeMobilityValue(context, afterMoveChar, -MoveSpecialConstants.MaxMobility * 50 / 100);
		foreach (CombatCharacter combatChar4 in _combatCharacterDict.Values)
		{
			if (!IsMainCharacter(combatChar4))
			{
				combatChar4.InitTeammateCommand(context, combatChar4.IsAlly == firstMoveIsAlly);
			}
		}
		UpdateAllCommandAvailability(context, _selfChar);
		UpdateAllCommandAvailability(context, _enemyChar);
		InitChickenPoints(context);
		_combatResultData.Reset();
		_skillCastTimes.Clear();
		_lootCharList.Clear();
		SelfMaxSkillGrade = -1;
		EnemyMaxSkillGrade = -1;
		SelfAvgEquipGrade = 0f;
		EnemyAvgEquipGrade = 0f;
		int selfEquipCount = 0;
		int enemyEquipCount = 0;
		foreach (CombatCharacter combatChar5 in _combatCharacterDict.Values)
		{
			ItemKey[] equips = combatChar5.GetCharacter().GetEquipment();
			for (sbyte slot = 0; slot < 17; slot++)
			{
				if ((slot != 4 && (uint)(slot - 11) > 1u && (uint)(slot - 14) > 2u) || 1 == 0)
				{
					ItemKey equipKey = equips[slot];
					if (equipKey.IsValid())
					{
						ItemBase equipItem = DomainManager.Item.GetBaseItem(equipKey);
						if (equipItem.GetMaxDurability() < 0 || equipItem.GetCurrDurability() > 0)
						{
							sbyte grade = ItemTemplateHelper.GetGrade(equipKey.ItemType, equipKey.TemplateId);
							if (combatChar5.IsAlly)
							{
								SelfAvgEquipGrade += grade + 1;
								selfEquipCount++;
							}
							else
							{
								EnemyAvgEquipGrade += grade + 1;
								enemyEquipCount++;
							}
						}
					}
				}
			}
		}
		SelfAvgEquipGrade /= Math.Max(1, selfEquipCount);
		EnemyAvgEquipGrade /= Math.Max(1, enemyEquipCount);
		if (_isTutorialCombat)
		{
			_selfChar.SetBreathValue(30000, context);
			_selfChar.SetStanceValue(4000, context);
		}
		if (combatConfigId == 125)
		{
			ClearMobilityAndForbidRecover(context, _enemyCharId);
		}
		SetCombatStatus(1, context);
		foreach (CombatCharacter combatChar6 in _combatCharacterDict.Values)
		{
			UpdateBodyDefeatMark(context, combatChar6);
			UpdatePoisonDefeatMark(context, combatChar6);
			combatChar6.UpdateOtherMark(context);
		}
		UpdateAllTeammateCommandUsable(context, isAlly: true, -1);
		UpdateAllTeammateCommandUsable(context, isAlly: false, -1);
		PreRandomizedTeammateCommandReplaceData = null;
		_vitalTeammateData = null;
		if (TaiwuInCombat && AiOptions.SaveMoveTarget && _lastTargetDistance > 0)
		{
			SetTargetDistance(context, _lastTargetDistance);
		}
		return (sbyte)firstMoveType;
	}

	private void PrepareCombatSpecial(DataContext context)
	{
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			ItemKey carrierItemKey = combatChar.GetCharacter().GetEquipment()[13];
			if (DomainManager.Extra.IsCarrierFullTamePoint(carrierItemKey) && DomainManager.Item.TryGetElement_Carriers(carrierItemKey.Id, out var carrier) && carrier.GetCurrDurability() > 0)
			{
				short carrierId = carrierItemKey.TemplateId;
				if (SharedConstValue.AnimalCarrier2Effect.TryGetValue(carrierId, out var effectName))
				{
					DomainManager.SpecialEffect.Add(context, combatChar.GetId(), effectName);
				}
			}
		}
	}

	private void PrepareCombatProfession(DataContext context)
	{
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(4) && _enemyChar.IsAnimal && TaiwuInAllyMainChar)
		{
			DomainManager.SpecialEffect.Add(context, _selfChar.GetId(), "Profession.Hunter.HuntingBeasts");
		}
		ItemKey carrier = _selfChar.GetCharacter().GetEquipment()[13];
		short carrierId = carrier.TemplateId;
		bool canUse = carrier.IsValid() && !DomainManager.Item.GetBaseItem(carrier).IsDurabilityRunningOut();
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(5) && carrierId >= 0 && Config.Carrier.Instance[carrierId].CharacterIdInCombat >= 0 && canUse && TaiwuInAllyMainChar)
		{
			GameData.Domains.Character.Character animalChar = DomainManager.Character.CreateFixedEnemy(context, Config.Carrier.Instance[carrierId].CharacterIdInCombat, isTemporary: true);
			DomainManager.Character.CompleteCreatingCharacter(animalChar.GetId());
			CombatCharacter animalCombatChar = new CombatCharacter();
			animalCombatChar.IsAlly = true;
			animalCombatChar.IsTaiwu = false;
			AddElement_CombatCharacterDict(animalChar.GetId(), animalCombatChar);
			animalCombatChar.Init(this, animalChar.GetId(), context);
			animalCombatChar.Immortal = true;
			animalCombatChar.SetVisible(visible: false, context);
			animalCombatChar.SetCanAttackOutRange(canAttackOutRange: true, context);
			animalCombatChar.SetUsingWeaponIndex(0, context);
			animalCombatChar.SetAnimationToLoop(animalCombatChar.GetIdleAni(), context);
			for (int i = 0; i < 3; i++)
			{
				ItemKey weaponKey = animalCombatChar.GetWeapons()[i];
				if (weaponKey.IsValid())
				{
					List<sbyte> weaponTricks = DomainManager.Item.GetWeaponTricks(weaponKey);
					CombatWeaponData weaponData = new CombatWeaponData(weaponKey, animalCombatChar);
					sbyte[] trickList = weaponData.GetWeaponTricks();
					AddElement_WeaponDataDict(weaponKey.Id, weaponData);
					weaponData.Init(context, i);
					for (int k = 0; k < weaponTricks.Count; k++)
					{
						trickList[k] = weaponTricks[k];
					}
				}
			}
			SetCarrierAnimalCombatCharId(animalCombatChar.GetId(), context);
		}
		else
		{
			SetCarrierAnimalCombatCharId(-1, context);
		}
		Location location = _selfChar.GetCharacter().GetLocation();
		if (!DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(2) || !location.IsValid())
		{
			return;
		}
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		int steps = 1;
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, steps, includeCenter: true);
		HashSet<string> savageEffects = ObjectPool<HashSet<string>>.Instance.Get();
		savageEffects.Clear();
		foreach (MapBlockData block in neighborBlocks)
		{
			if (SharedConstValue.MapBlockSubType2SavageEffect.TryGetValue(block.BlockSubType, out var effect))
			{
				savageEffects.Add(effect);
			}
		}
		foreach (string effect2 in savageEffects)
		{
			DomainManager.SpecialEffect.Add(context, _selfChar.GetId(), effect2);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		ObjectPool<HashSet<string>>.Instance.Return(savageEffects);
	}

	private void PrepareCombatAdventure(DataContext context, short combatConfigId)
	{
		if (1 == 0)
		{
		}
		Type type;
		switch (combatConfigId)
		{
		case 230:
		case 235:
			type = typeof(FiveElementsStoneMetal);
			break;
		case 231:
		case 236:
			type = typeof(FiveElementsStoneWood);
			break;
		case 232:
		case 237:
			type = typeof(FiveElementsStoneWater);
			break;
		case 233:
		case 238:
			type = typeof(FiveElementsStoneFire);
			break;
		case 234:
		case 239:
			type = typeof(FiveElementsStoneEarth);
			break;
		default:
			type = null;
			break;
		}
		if (1 == 0)
		{
		}
		Type fiveElementsStoneType = type;
		if (!(fiveElementsStoneType != null))
		{
			return;
		}
		foreach (int charId in _combatCharacterDict.Keys)
		{
			SpecialEffectBase effect = (SpecialEffectBase)Activator.CreateInstance(fiveElementsStoneType, charId);
			DomainManager.SpecialEffect.Add(context, effect);
		}
	}

	private void PrepareCombatSectStory(DataContext context, short combatConfigId)
	{
		if (combatConfigId >= 164 && combatConfigId <= 166)
		{
			GameData.Domains.Character.Character liaoWumingChar = DomainManager.Character.CreateFixedCharacter(context, 772);
			DomainManager.Character.CompleteCreatingCharacter(liaoWumingChar.GetId());
			CombatCharacter liaoWumingCharCombatChar = new CombatCharacter();
			liaoWumingCharCombatChar.IsAlly = true;
			liaoWumingCharCombatChar.IsTaiwu = false;
			AddElement_CombatCharacterDict(liaoWumingChar.GetId(), liaoWumingCharCombatChar);
			liaoWumingCharCombatChar.Init(this, liaoWumingChar.GetId(), context);
			liaoWumingCharCombatChar.SetVisible(visible: false, context);
			SetSpecialShowCombatCharId(liaoWumingCharCombatChar.GetId(), context);
			_selfChar.NeedEnterSpecialShow = true;
		}
		else
		{
			SetSpecialShowCombatCharId(-1, context);
		}
		short enemyTemplateId = _enemyChar.GetCharacter().GetTemplateId();
		if (771 <= enemyTemplateId && enemyTemplateId <= 775)
		{
			AddCombatState(context, _enemyChar, 0, 145);
		}
		if (combatConfigId == 198)
		{
			int charId = _selfTeam[0];
			XiongZhongSiQi effect = new XiongZhongSiQi(charId);
			DomainManager.SpecialEffect.Add(context, effect);
		}
		if (combatConfigId == 203)
		{
			int charId2 = _selfTeam[0];
			SiQiDuoHun effect2 = new SiQiDuoHun(charId2);
			DomainManager.SpecialEffect.Add(context, effect2);
		}
		if (combatConfigId == 204)
		{
			EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
			sectArgBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaAdventureFinialWinSect, out SByteList list);
			List<sbyte> items = list.Items;
			if (items != null && items.Count > 0)
			{
				foreach (sbyte orgTemplateId in list.Items)
				{
					PrepareCombatSectStoryTryCreateBaihuaLegacyPower(context, orgTemplateId);
				}
			}
		}
		if (combatConfigId == 205)
		{
			int charId3 = _selfTeam[0];
			SoulWitheringBell effect3 = new SoulWitheringBell(charId3);
			DomainManager.SpecialEffect.Add(context, effect3);
		}
		if (combatConfigId == 244)
		{
			_enemyChar.AddMindMark(context, 6, -1, forceInfinite: true);
		}
		SectShaolinDemonSlayerData slayerTrial = DomainManager.Extra.GetSectShaolinDemonSlayerData();
		List<object> trialingRestrictEffects = slayerTrial.TrialingRestrictEffects;
		if (trialingRestrictEffects != null && trialingRestrictEffects.Count > 0)
		{
			foreach (object effect4 in slayerTrial.TrialingRestrictEffects)
			{
				DomainManager.SpecialEffect.Add(context, (SpecialEffectBase)effect4);
			}
		}
		slayerTrial.TrialingRestrictEffects = null;
	}

	private void PrepareCombatSectStoryTryCreateBaihuaLegacyPower(DataContext context, sbyte orgTemplateId)
	{
		int taiwuCharId = _selfTeam[0];
		if (1 == 0)
		{
		}
		SpecialEffectBase specialEffectBase = orgTemplateId switch
		{
			1 => new LegacyPowerShaolin(taiwuCharId), 
			2 => new LegacyPowerEmei(taiwuCharId), 
			3 => new LegacyPowerBaihua(taiwuCharId), 
			4 => new LegacyPowerWudang(taiwuCharId), 
			5 => new LegacyPowerYuanshan(taiwuCharId), 
			6 => new LegacyPowerShixiang(taiwuCharId), 
			7 => new LegacyPowerRanshan(taiwuCharId), 
			8 => new LegacyPowerXuannv(taiwuCharId), 
			9 => new LegacyPowerZhujian(taiwuCharId), 
			10 => new LegacyPowerKongsang(taiwuCharId), 
			11 => new LegacyPowerJingang(taiwuCharId), 
			12 => new LegacyPowerWuxian(taiwuCharId), 
			13 => new LegacyPowerJieqing(taiwuCharId), 
			14 => new LegacyPowerFulong(taiwuCharId), 
			15 => new LegacyPowerXuehou(taiwuCharId), 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		SpecialEffectBase effect = specialEffectBase;
		if (effect != null)
		{
			DomainManager.SpecialEffect.Add(context, effect);
		}
	}

	[DomainMethod]
	public bool StartCombat(DataContext context)
	{
		if (Started)
		{
			return false;
		}
		SetTimeScale(_timeScale, context);
		if (CombatConfig.StartInSecondPhase && _enemyChar.BossConfig != null)
		{
			RaiseCombatCharAboutToFall(context, _enemyChar, ECombatCharAboutToFallType.AddPhase);
		}
		_needCheckFallenCharSet.Clear();
		AddToCheckFallenSet(_selfChar.GetId());
		AddToCheckFallenSet(_enemyChar.GetId());
		Events.RaiseCombatBegin(context);
		Events.RaiseChangeNeiliAllocationAfterCombatBegin(context, _selfChar, _selfChar.GetNeiliAllocation());
		Events.RaiseChangeNeiliAllocationAfterCombatBegin(context, _enemyChar, _enemyChar.GetNeiliAllocation());
		Events.RaiseCreateGangqiAfterChangeNeiliAllocation(context, _selfChar);
		Events.RaiseCreateGangqiAfterChangeNeiliAllocation(context, _enemyChar);
		DomainManager.TaiwuEvent.OnEvent_CombatOpening(_enemyCharId);
		EnsurePauseState();
		TestSkillCounter = 0;
		Started = true;
		return true;
	}

	[DomainMethod]
	public void SetTimeScale(DataContext context, float timeScale)
	{
		if (IsInCombat() && !CombatAboutToOver())
		{
			if (_inBulletTime)
			{
				_timeScaleSaveInBulletTime = timeScale;
				SetTimeScale((timeScale == 0f) ? 0f : 0.2f, context);
			}
			else
			{
				SetTimeScale(timeScale, context);
			}
		}
	}

	[DomainMethod]
	public void SetPlayerAutoCombat(DataContext context, bool autoCombat)
	{
		SetAutoCombat(autoCombat, context);
		SetMoveState(MoveState.Stay);
	}

	[DomainMethod]
	public void EnterBossPuppetCombat(DataContext context, short puppetCharTemplateId, sbyte consummateLevel, bool playground = false)
	{
		int bossLevel = consummateLevel / 2 - 1;
		if (bossLevel < 0 || bossLevel > 8)
		{
			return;
		}
		PuppetItem config = Puppet.Instance[puppetCharTemplateId];
		int difficulty = 0;
		for (int index = 0; index < config.Difficulties.Count; index++)
		{
			sbyte val = config.Difficulties[index];
			if (val == consummateLevel)
			{
				difficulty = index;
				break;
			}
		}
		short charTemplateId = (short)(config.CharacterId + difficulty);
		GameData.Domains.Character.Character character;
		if (Config.Character.Instance[charTemplateId].CreatingType == 0)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(charTemplateId, out var fixedCharacter))
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(context, fixedCharacter);
			}
			character = DomainManager.Character.CreateFixedCharacter(context, charTemplateId);
		}
		else
		{
			character = DomainManager.Character.CreateFixedEnemy(context, charTemplateId, isTemporary: true);
		}
		character.OfflineSetXiangshuType(4);
		if (config.Type == EPuppetType.Xiangshu)
		{
			DomainManager.LegendaryBook.UpdateBossCharacterLegendaryBookFeatures(context, character);
		}
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		CombatEntry(context, new List<int> { character.GetId() }, config.CombatConfig);
		SetIsPuppetCombat(value: true, context);
		SetIsPlaygroundCombat(playground, context);
	}

	[DomainMethod]
	public void EnableBulletTime(DataContext context, bool enable)
	{
		if (_inBulletTime == enable)
		{
			return;
		}
		_inBulletTime = enable;
		if (enable)
		{
			_timeScaleSaveInBulletTime = _timeScale;
			if (_timeScale > 0f)
			{
				SetTimeScale(0.2f, context);
			}
		}
		else
		{
			SetTimeScale(_timeScaleSaveInBulletTime, context);
		}
	}

	public override void OnUpdate(DataContext context)
	{
		if (_timeScale <= 0f || !IsInCombat() || !Started)
		{
			return;
		}
		Context = context;
		_selfChar.OnFrameBegin();
		if (_selfChar.TeammateBeforeMainChar >= 0)
		{
			_combatCharacterDict[_selfChar.TeammateBeforeMainChar].OnFrameBegin();
		}
		_enemyChar.OnFrameBegin();
		if (_enemyChar.TeammateBeforeMainChar >= 0)
		{
			_combatCharacterDict[_enemyChar.TeammateBeforeMainChar].OnFrameBegin();
		}
		_frameTimeAccumulator += _timeScale;
		if (_frameTimeAccumulator >= 1f)
		{
			int frameTimes = (int)_frameTimeAccumulator;
			_frameTimeAccumulator %= 1f;
			for (int i = 0; i < frameTimes; i++)
			{
				if (IsInCombat())
				{
					CombatLoop(context);
				}
			}
		}
		_selfChar.OnFrameEnd();
		_enemyChar.OnFrameEnd();
	}

	private void CombatLoop(DataContext context)
	{
		if (_skipCombatLoop)
		{
			_skipCombatLoop = false;
			return;
		}
		_saveDyingEffectTriggerd = false;
		if (CheckFallen(context))
		{
			return;
		}
		if (Pause == _selfChar.StateMachine.GetCurrentState().IsUpdateOnPause)
		{
			if (!Pause)
			{
				if (_selfChar.AiCanOperate(_autoCombat && !_isTutorialCombat))
				{
					_selfChar.AiController.Update(context);
				}
				else
				{
					_selfChar.AiController.UpdateOnlyMove(context);
				}
			}
			_selfChar.StateMachine.OnUpdate();
		}
		if (IsInCombat() && Pause == _enemyChar.StateMachine.GetCurrentState().IsUpdateOnPause)
		{
			if (!Pause && EnemyEnableAi)
			{
				_enemyChar.AiController.Update(context);
			}
			_enemyChar.StateMachine.OnUpdate();
		}
		if (Pause)
		{
			return;
		}
		SetCombatFrame(_combatFrame + 1, context);
		if (CombatConfig.ForceDefeatType == ECombatConfigForceDefeatType.Invalid || CombatConfig.ForceDefeatFrame == 0 || _combatFrame < CombatConfig.ForceDefeatFrame)
		{
			return;
		}
		if (CombatConfig.ForceDefeatType == ECombatConfigForceDefeatType.LeftWin)
		{
			ForceDefeat(GetMainCharacter(isAlly: false).GetId());
		}
		else if (CombatConfig.ForceDefeatType == ECombatConfigForceDefeatType.RightWin)
		{
			ForceDefeat(GetMainCharacter(isAlly: true).GetId());
		}
		else if (CombatConfig.ForceDefeatType == ECombatConfigForceDefeatType.TiredMark)
		{
			ulong duration = _combatFrame - CombatConfig.ForceDefeatFrame;
			if (duration % GlobalConfig.Instance.TiredMarkAppearFrame == 0)
			{
				_selfChar.AddTiredMark(context);
				_enemyChar.AddTiredMark(context);
			}
		}
	}

	private bool CheckFallen(DataContext context)
	{
		if (_selfChar.StateMachine.GetCurrentState().RequireDelayFallen || _enemyChar.StateMachine.GetCurrentState().RequireDelayFallen)
		{
			return false;
		}
		return CheckFallenImmediate(context);
	}

	public bool CheckFallenImmediate(DataContext context)
	{
		for (int i = 0; i < _selfTeam.Length; i++)
		{
			int charId = _selfTeam[i];
			if (charId >= 0 && _needCheckFallenCharSet.Contains(charId) && CheckCurrCharDangerOrFallen(context, _combatCharacterDict[charId]))
			{
				break;
			}
		}
		if (IsInCombat() && !CombatAboutToOver())
		{
			for (int j = 0; j < _enemyTeam.Length; j++)
			{
				int charId2 = _enemyTeam[j];
				if (charId2 >= 0 && _needCheckFallenCharSet.Contains(charId2) && CheckCurrCharDangerOrFallen(context, _combatCharacterDict[charId2]))
				{
					break;
				}
			}
		}
		_needCheckFallenCharSet.Clear();
		return !IsInCombat();
	}

	public void EnsurePauseState()
	{
		bool prevPause = Pause;
		Pause = _selfChar.StateMachine.GetCurrentState().IsUpdateOnPause || _enemyChar.StateMachine.GetCurrentState().IsUpdateOnPause;
		if (prevPause != Pause)
		{
			UpdateAllTeammateCommandUsable(Context, isAlly: true, -1);
			UpdateAllTeammateCommandUsable(Context, isAlly: false, -1);
		}
	}

	[DomainMethod]
	public void SetAiOptions(AiOptions aiOptions)
	{
		AiOptions = aiOptions;
	}

	public bool CanRecoverBreath(CombatCharacter character)
	{
		bool canRecover = true;
		return DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 189, canRecover);
	}

	public void RecoverBreathValue(DataContext context, CombatCharacter character)
	{
		if (CanRecoverBreath(character))
		{
			int addValue = CFormula.CalcBreathRecoverValue(character.GetCharacter().GetRecoveryOfStanceAndBreath().Inner);
			addValue = character.CalcBreathRecoverValue(addValue);
			ChangeBreathValue(context, character, addValue);
		}
	}

	public int ChangeBreathValue(DataContext context, CombatCharacter character, int addValue, bool changedByEffect = false, CombatCharacter changer = null)
	{
		if (changedByEffect && addValue < 0)
		{
			addValue = DomainManager.SpecialEffect.ModifyValue(character.GetId(), 255, addValue, changer?.GetId() ?? (-1));
		}
		int prevValue = character.GetBreathValue();
		int currValue = Math.Clamp(prevValue + addValue, 0, character.GetMaxBreathValue());
		addValue = currValue - prevValue;
		if (addValue < 0 && character.PoisonOverflow(2))
		{
			character.AddPoisonAffectValue(2, (short)(-addValue * 100 / 30000));
		}
		if (character.LockMaxBreath)
		{
			currValue = 30000;
		}
		character.SetBreathValue(currValue, context);
		return addValue;
	}

	public bool CanRecoverStance(CombatCharacter character)
	{
		bool canRecover = true;
		return DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 190, canRecover);
	}

	public void RecoverStanceValue(DataContext context, CombatCharacter character, int addValue, sbyte attackPreparePointCost, bool isPursue)
	{
		if (CanRecoverStance(character))
		{
			addValue = CFormula.CalcStanceRecoverValue(character.GetCharacter().GetRecoveryOfStanceAndBreath().Outer, addValue, attackPreparePointCost, isPursue);
			addValue = character.CalcStanceRecoverValue(addValue);
			ChangeStanceValue(context, character, addValue);
			Events.RaiseRecoverStance(context, character, addValue);
			UpdateSkillCostBreathStanceCanUse(context, character);
		}
	}

	public int ChangeStanceValue(DataContext context, CombatCharacter character, int addValue, bool changedByEffect = false, CombatCharacter changer = null)
	{
		if (changedByEffect && addValue < 0)
		{
			addValue = DomainManager.SpecialEffect.ModifyValue(character.GetId(), 254, addValue, changer?.GetId() ?? (-1));
		}
		int prevValue = character.GetStanceValue();
		int currValue = Math.Clamp(prevValue + addValue, 0, character.GetMaxStanceValue());
		addValue = currValue - prevValue;
		if (addValue < 0 && character.PoisonOverflow(3))
		{
			character.AddPoisonAffectValue(3, (short)(-addValue * 100 / 4000));
		}
		if (character.LockMaxStance)
		{
			currValue = 4000;
		}
		character.SetStanceValue(currValue, context);
		return addValue;
	}

	public void CostBreathAndStance(DataContext context, CombatCharacter character, int costBreath, int costStance, short skillId = -1)
	{
		if (costBreath > 0)
		{
			costBreath = ChangeBreathValue(context, character, -costBreath);
		}
		if (costStance > 0)
		{
			costStance = ChangeStanceValue(context, character, -costStance);
		}
		Events.RaiseCostBreathAndStance(context, character.GetId(), character.IsAlly, -costBreath, -costStance, skillId);
	}

	[DomainMethod]
	public void InvokeChickenPoints(DataContext context, List<int> selectedPointIds)
	{
		_selfChar.SetNeedSmarterChicken(context, selectedPointIds);
	}

	[DomainMethod]
	public void ApplyChickenEffect(DataContext context)
	{
		if (IsInCombat() && _selfChar.StateMachine.GetCurrentState() is CombatCharacterStateSmarterChicken state)
		{
			state.ApplyEffect(context);
		}
	}

	[DomainMethod]
	public void FinishChickenPhase()
	{
		if (IsInCombat() && _selfChar.StateMachine.GetCurrentState() is CombatCharacterStateSmarterChicken state)
		{
			state.FinishState();
		}
	}

	public void ExecuteChickenEffect(DataContext context, sbyte type, int totalPoint)
	{
		CombatCharacter combatChar = _selfChar;
		CombatCharacter enemyChar = _enemyChar;
		switch (type)
		{
		case 0:
		{
			CValuePercent percent2 = totalPoint;
			ChangeBreathValue(context, combatChar, 30000 * percent2);
			ChangeStanceValue(context, combatChar, 4000 * percent2);
			break;
		}
		case 2:
		{
			int value = 100 * totalPoint;
			for (sbyte i2 = 0; i2 < 6; i2++)
			{
				AddPoison(context, combatChar, enemyChar, i2, 2, value, -1);
			}
			break;
		}
		case 1:
			DomainManager.SpecialEffect.Add(context, new ChickenClever(combatChar.GetId(), totalPoint));
			break;
		case 3:
			DomainManager.SpecialEffect.Add(context, new ChickenBrave(combatChar.GetId(), totalPoint));
			break;
		case 4:
		{
			CValuePercentBonus bonus = totalPoint * 3;
			HealInjuryInCombat(context, combatChar, combatChar, canHealOld: true, costHerb: false, bonus);
			HealPoisonInCombat(context, combatChar, combatChar, canHealOld: true, costHerb: false, bonus);
			ShowSpecialEffectTips(combatChar.GetId(), 1457, 0);
			ShowSpecialEffectTips(combatChar.GetId(), 1459, 0);
			break;
		}
		case 6:
		{
			short skillId = enemyChar.GetRandomBanableSkillId(context.Random, null, -1);
			if (skillId >= 0)
			{
				int silenceFrame = 30 * totalPoint;
				SilenceSkill(context, enemyChar, skillId, silenceFrame);
			}
			break;
		}
		case 5:
		{
			for (int i = 0; i < totalPoint; i++)
			{
				combatChar.AbsorbNeiliAllocationRandom(context, enemyChar, 1);
			}
			break;
		}
		case sbyte.MaxValue:
		{
			CValuePercent percent = 1 + totalPoint / 2;
			ChangeMobilityValue(context, combatChar, GlobalConfig.Instance.MaxMobility * percent);
			break;
		}
		}
	}

	public void InitChickenPoints(DataContext context)
	{
		_nextChickenPointId = 0;
		_chickenPointZones.Clear();
		if (TaiwuInAllyMainChar && DlcManager.IsDlcInstalled(4975570uL) && DomainManager.Extra.TryGetDlcEntry<SmarterChickenEntry>(4975570uL, out var entry) && DomainManager.Global.GetCurrGameWorldType() == 1)
		{
			_nextChickenPointId = entry.InitializePendingPoints(_chickenPointZones.Pending, context.Random);
		}
		SetChickenPointZones(_chickenPointZones, context);
		SetNextAvailableChickenPointAppearCd(CountdownData.Zero, context);
	}

	public void TickChickenPoints(DataContext context)
	{
		if (_chickenPointZones.NoDrawable)
		{
			return;
		}
		if (_chickenPointZones.CurrentNotFull)
		{
			if (_nextAvailableChickenPointAppearCd.Off)
			{
				_nextAvailableChickenPointAppearCd = CountdownData.Create(120);
			}
			_nextAvailableChickenPointAppearCd.Tick();
			SetNextAvailableChickenPointAppearCd(_nextAvailableChickenPointAppearCd, context);
			bool needDraw = _nextAvailableChickenPointAppearCd.Off;
			if (needDraw)
			{
				_chickenPointZones.Draw(context.Random);
			}
			if (_chickenPointZones.RemoveOverflow() || needDraw)
			{
				SetChickenPointZones(_chickenPointZones, context);
			}
		}
		else if (_nextAvailableChickenPointAppearCd.On)
		{
			SetNextAvailableChickenPointAppearCd(CountdownData.Zero, context);
		}
	}

	public ChickenPointRuntime CreateTemporaryChickenPoint(sbyte type, int value)
	{
		return new ChickenPointRuntime(_nextChickenPointId++, new ChickenPoint(type, value), null, null, stable: false);
	}

	public ChickenPointRuntime? AddChickenPointToCurrent(DataContext context, ChickenPointRuntime point)
	{
		_chickenPointZones.AddToCurrent(point);
		ChickenPointRuntime? overflowPoint = _chickenPointZones.RemoveOverflowInPriority(point.Type);
		SetChickenPointZones(_chickenPointZones, context);
		if (_nextAvailableChickenPointAppearCd.On && _chickenPointZones.CurrentFull)
		{
			SetNextAvailableChickenPointAppearCd(CountdownData.Zero, context);
		}
		return overflowPoint;
	}

	public void AddCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId)
	{
		AddCombatState(context, character, stateType, stateId, 100, reverse: false, applyEffect: true, -1);
	}

	public void AddCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId, int power)
	{
		AddCombatState(context, character, stateType, stateId, power, reverse: false, applyEffect: true, -1);
	}

	public void AddCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId, int power, bool reverse)
	{
		AddCombatState(context, character, stateType, stateId, power, reverse, applyEffect: true, -1);
	}

	public void AddCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId, int power, bool reverse, bool applyEffect)
	{
		AddCombatState(context, character, stateType, stateId, power, reverse, applyEffect, -1);
	}

	public void AddCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId, int power, bool reverse, bool applyEffect, int srcCharId)
	{
		CombatStateCollection stateCollection = character.GetCombatStateCollection(stateType);
		short maxPower = character.GetCombatStatePowerLimit(stateType);
		if (applyEffect)
		{
			stateId = (short)DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 166, stateId, stateType, power, reverse ? 1 : 0);
			if (stateId < 0)
			{
				return;
			}
			power = DomainManager.SpecialEffect.ModifyValue(character.GetId(), 167, power, stateType, stateId, (byte)new BoolArray8
			{
				[0] = power <= 0,
				[1] = !stateCollection.StateDict.ContainsKey(stateId)
			});
			if (power == 0)
			{
				return;
			}
		}
		if (stateCollection.StateDict.ContainsKey(stateId))
		{
			short currentPower = stateCollection.StateDict[stateId].power;
			if (currentPower + power != 0)
			{
				(short, bool, int) state = stateCollection.StateDict[stateId];
				state.Item1 = (short)Math.Min(currentPower + power, maxPower);
				stateCollection.StateDict[stateId] = state;
				((CombatStateEffect)DomainManager.SpecialEffect.Get(stateCollection.State2EffectId[stateId])).ChangePower(context, stateCollection.StateDict[stateId].power);
			}
			else
			{
				RemoveCombatState(context, character, stateType, stateId);
			}
		}
		else if (power > 0)
		{
			stateCollection.StateDict.Add(stateId, ((short)Math.Min(power, maxPower), reverse, srcCharId));
			(short, bool, int) state2 = stateCollection.StateDict[stateId];
			long effectId = DomainManager.SpecialEffect.AddCombatStateEffect(context, character.GetId(), stateType, stateId, state2.Item1, state2.Item2);
			stateCollection.State2EffectId[stateId] = effectId;
		}
		character.SetCombatStateCollection(stateType, stateCollection, context);
		character.UpdateStateMark(context);
	}

	public void RemoveCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId)
	{
		CombatStateCollection stateCollection = character.GetCombatStateCollection(stateType);
		if (stateCollection.StateDict.ContainsKey(stateId))
		{
			stateCollection.StateDict.Remove(stateId);
			character.SetCombatStateCollection(stateType, stateCollection, context);
			character.UpdateStateMark(context);
			DomainManager.SpecialEffect.Remove(context, stateCollection.State2EffectId[stateId]);
			stateCollection.State2EffectId.Remove(stateId);
		}
	}

	public void ClearCombatState(DataContext context, CombatCharacter character)
	{
		List<short> stateIdList = ObjectPool<List<short>>.Instance.Get();
		for (sbyte stateType = 0; stateType < 3; stateType++)
		{
			stateIdList.Clear();
			stateIdList.AddRange(character.GetCombatStateCollection(stateType).StateDict.Keys);
			for (int i = 0; i < stateIdList.Count; i++)
			{
				RemoveCombatState(context, character, stateType, stateIdList[i]);
			}
		}
		ObjectPool<List<short>>.Instance.Return(stateIdList);
	}

	public static (short stateId, bool reverse) CalcReversedCombatState(short stateId, bool reverse)
	{
		CombatStateItem stateConfig = CombatState.Instance[stateId];
		if (stateConfig.ReverseState < 0)
		{
			reverse = !reverse;
		}
		else
		{
			stateId = stateConfig.ReverseState;
		}
		return (stateId: stateId, reverse: reverse);
	}

	public void ReverseCombatState(DataContext context, CombatCharacter character, sbyte stateType, short stateId)
	{
		if ((uint)(stateType - 1) > 1u)
		{
			PredefinedLog.Show(8, $"cannot reverse special state {stateType} {stateId}");
			return;
		}
		CombatStateCollection stateCollection = character.GetCombatStateCollection(stateType);
		if (!stateCollection.StateDict.TryGetValue(stateId, out (short, bool, int) stateInfo))
		{
			PredefinedLog.Show(8, $"cannot reverse state of not existing {stateType} {stateId}");
		}
		else
		{
			sbyte reverseType = (sbyte)((stateType != 1) ? 1 : 2);
			bool reverse = stateInfo.Item2;
			RemoveCombatState(context, character, stateType, stateId);
			(stateId, reverse) = CalcReversedCombatState(stateId, reverse);
			AddCombatState(context, character, reverseType, stateId, stateInfo.Item1, reverse, applyEffect: false);
		}
	}

	public void InvalidateCombatStateCache(DataContext context, CombatCharacter character, sbyte stateType)
	{
		CombatStateCollection stateCollection = character.GetCombatStateCollection(stateType);
		foreach (long effectId in stateCollection.State2EffectId.Values)
		{
			((CombatStateEffect)DomainManager.SpecialEffect.Get(effectId)).InvalidateCache(context);
		}
	}

	[DomainMethod]
	public void ClearAllReserveAction(DataContext context, bool isAlly = true)
	{
		if (IsInCombat())
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			combatChar.SetCombatReserveData(CombatReserveData.Invalid, context);
		}
	}

	[DomainMethod]
	public void ClearReserveNormalAttack(DataContext context, bool isAlly = true)
	{
		if (IsInCombat())
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			combatChar.SetReserveNormalAttack(reserveNormalAttack: false, context);
		}
	}

	[DomainMethod]
	public bool SetPuppetUnyieldingFallen(DataContext context, bool unyieldingFallen)
	{
		if (!IsInCombat() || !GetIsPlaygroundCombat())
		{
			return false;
		}
		SetEnemyUnyieldingFallen(unyieldingFallen, context);
		return true;
	}

	[DomainMethod]
	public bool SetPuppetDisableAi(DataContext context, bool disableAi)
	{
		if (!IsInCombat() || !GetIsPlaygroundCombat())
		{
			return false;
		}
		SetDisableEnemyAi(disableAi, context);
		if (disableAi)
		{
			SetMoveState(MoveState.Stay, isAlly: false);
		}
		return true;
	}

	private bool IsGuardChar(CombatCharacter character)
	{
		if (character.GetCharacter().GetCreatingType() != 2)
		{
			return false;
		}
		for (int i = 0; i < _enemyTeam.Length; i++)
		{
			int charId = _enemyTeam[i];
			if (charId >= 0 && DomainManager.Character.GetElement_Objects(charId).GetCreatingType() == 1)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanAcceptCommand()
	{
		return IsInCombat() && !CombatAboutToOver() && _selfChar.ChangeCharId < 0 && _enemyChar.ChangeCharId < 0;
	}

	public (string anim, bool anyChanged) SetProperLoopAniAndParticle(DataContext context, CombatCharacter character, bool getMoveAni = false)
	{
		bool anyChanged = false;
		string properLoopAnim = GetProperLoopAni(character, getMoveAni);
		if (properLoopAnim != character.GetAnimationToLoop())
		{
			character.SetAnimationToLoop(properLoopAnim, context);
			anyChanged = true;
		}
		string properLoopParticle = GetProperLoopParticle(character, getMoveAni);
		if (properLoopParticle != character.GetParticleToLoop())
		{
			character.SetParticleToLoop(properLoopParticle, context);
		}
		return (anim: properLoopAnim, anyChanged: anyChanged);
	}

	public string GetProperLoopAni(CombatCharacter character, bool getMoveAni = false)
	{
		if (IsCharacterFallen(character))
		{
			return null;
		}
		if (character.SpecialAnimationLoop != null)
		{
			return character.SpecialAnimationLoop;
		}
		if (character.GetAttackingTrickType() >= 0)
		{
			return null;
		}
		if (!Pause && character.IsMoving && (character.KeepMoving || getMoveAni))
		{
			return character.MoveForward ? character.GetWalkForwardAni() : character.GetWalkBackwardAni();
		}
		if (character.GetPreparingSkillId() >= 0)
		{
			CombatSkillItem configData = Config.CombatSkill.Instance[character.GetPreparingSkillId()];
			bool isBoss = character.BossConfig != null;
			string musicWeaponFix = ((configData.Type != 13) ? "" : GetMusicWeaponNameFix(character.GetWeaponData()));
			string prepareAni = ((string.IsNullOrEmpty(configData.PlayerCastBossSkillPrepareAni) || isBoss) ? (configData.PrepareAnimation + musicWeaponFix + "_1") : (configData.PlayerCastBossSkillPrepareAni + musicWeaponFix + "_1"));
			return (configData.EquipType == 1 && !isBoss) ? prepareAni : "C_007";
		}
		if (character.GetPreparingOtherAction() >= 0)
		{
			return GetPrepareOtherActionAnim(character);
		}
		if (character.GetAffectingDefendSkillId() >= 0)
		{
			return Config.CombatSkill.Instance[character.GetAffectingDefendSkillId()].DefendAnimation;
		}
		return character.GetIdleAni();
	}

	private string GetProperLoopParticle(CombatCharacter character, bool getMoveAni)
	{
		if (IsCharacterFallen(character) || character.GetAttackingTrickType() >= 0 || character.GetPreparingOtherAction() < 0)
		{
			return null;
		}
		OtherActionTypeItem otherActionConfig = Config.OtherActionType.Instance[character.GetPreparingOtherAction()];
		if (Pause || !character.IsMoving || (!character.KeepMoving && !getMoveAni))
		{
			return otherActionConfig.PrepareParticle;
		}
		if (_currentDistance <= GlobalConfig.Instance.FastWalkDistance)
		{
			return character.MoveForward ? otherActionConfig.ForwardParticle : otherActionConfig.BackwardParticle;
		}
		return character.MoveForward ? otherActionConfig.ForwardFastParticle : otherActionConfig.BackwardFastParticle;
	}

	public string GetPrepareOtherActionAnim(CombatCharacter character)
	{
		if (!character.IsActorSkeleton)
		{
			return "C_007";
		}
		string prepareAnim = character.PreparingOtherActionTypeConfig.PrepareAnim;
		return string.IsNullOrEmpty(prepareAnim) ? "C_007" : prepareAnim;
	}

	public bool IsPlayingMoveAni(CombatCharacter character)
	{
		string aniName = character.GetAnimationToLoop();
		if (aniName == character.GetWalkForwardAni() || aniName == character.GetWalkBackwardAni())
		{
			goto IL_0058;
		}
		switch (aniName)
		{
		case "M_003":
		case "M_004":
		case "M_014":
			goto IL_0058;
		}
		int result = ((aniName == "M_015") ? 1 : 0);
		goto IL_0059;
		IL_0059:
		return (byte)result != 0;
		IL_0058:
		result = 1;
		goto IL_0059;
	}

	public void ChangeChangeTrickProgress(DataContext context, CombatCharacter character, int changeValue)
	{
		if (character.GetChangeTrickCount() < character.MaxChangeTrickCount)
		{
			int percent = 100 + DomainManager.SpecialEffect.GetModifyValue(character.GetId(), 198, EDataModifyType.AddPercent);
			changeValue = Math.Max(changeValue * percent / 100, 0);
			int newValue = Math.Clamp(character.GetChangeTrickProgress() + changeValue, 0, GlobalConfig.Instance.MaxChangeTrickProgressOnce);
			if (newValue >= GlobalConfig.Instance.MaxChangeTrickProgress)
			{
				int count = newValue / GlobalConfig.Instance.MaxChangeTrickProgress;
				ChangeChangeTrickCount(context, character, count);
				newValue -= GlobalConfig.Instance.MaxChangeTrickProgress * count;
			}
			if (character.GetChangeTrickCount() == character.MaxChangeTrickCount)
			{
				newValue = 0;
			}
			sbyte newProgress = (sbyte)Math.Clamp(newValue, 0, GlobalConfig.Instance.MaxChangeTrickProgress);
			character.SetChangeTrickProgress(newProgress, context);
		}
	}

	public short GetMaxNeiliAllocation(CombatCharacter character, byte type)
	{
		return character.GetMaxNeiliAllocation(type);
	}

	public sbyte GetAttackBodyPart(CombatCharacter attacker, CombatCharacter defender, IRandomSource random, short skillId = -1, sbyte trickType = -1, sbyte hitType = -1)
	{
		if (hitType < 0 && trickType >= 0)
		{
			hitType = GetAttackHitType(attacker, trickType);
		}
		sbyte trickHitType = ((trickType >= 0 && trickType != 21) ? Config.TrickType.Instance[trickType].AvoidType : hitType);
		if ((skillId >= 0 && CombatSkillEquipType.IsMindHitSkill(skillId)) || (trickType >= 0 && trickHitType == 3))
		{
			return -1;
		}
		if (trickType == 21)
		{
			trickType = GodTrickUseTrickType[hitType];
		}
		DefeatMarkCollection defeatMarks = defender.GetDefeatMarkCollection();
		List<int> attackOdds = ObjectPool<List<int>>.Instance.Get();
		attackOdds.Clear();
		if (skillId >= 0 && Config.CombatSkill.Instance[skillId].InjuryPartAtkRateDistribution != null)
		{
			attackOdds.AddRange(DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(attacker.GetId(), skillId)).GetBodyPartWeights());
		}
		else if (trickType >= 0 && Config.TrickType.Instance[trickType].InjuryPartAtkRateDistribution != null)
		{
			attackOdds.AddRange(((IEnumerable<sbyte>)Config.TrickType.Instance[trickType].InjuryPartAtkRateDistribution).Select((Func<sbyte, int>)((sbyte x) => x)));
		}
		else
		{
			PredefinedLog.Show(8, $"GetAttackBodyPart {skillId} {trickType}");
			for (int i = 0; i < 7; i++)
			{
				attackOdds.Add(0);
			}
		}
		List<sbyte> noExistPartList = ObjectPool<List<sbyte>>.Instance.Get();
		noExistPartList.Clear();
		if (!defender.GetCharacter().GetHaveLeftArm())
		{
			noExistPartList.Add(3);
		}
		if (!defender.GetCharacter().GetHaveRightArm())
		{
			noExistPartList.Add(4);
		}
		if (!defender.GetCharacter().GetHaveLeftLeg())
		{
			noExistPartList.Add(5);
		}
		if (!defender.GetCharacter().GetHaveRightLeg())
		{
			noExistPartList.Add(6);
		}
		if (noExistPartList.Count > 0)
		{
			for (int i2 = 0; i2 < noExistPartList.Count; i2++)
			{
				attackOdds[noExistPartList[i2]] = 0;
			}
			if (!attackOdds.Exists((int odds) => odds > 0))
			{
				for (sbyte part = 0; part < 7; part++)
				{
					if (!noExistPartList.Contains(part))
					{
						attackOdds[part] = 1;
					}
				}
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(noExistPartList);
		if (skillId < 0)
		{
			for (sbyte part2 = 0; part2 < 7; part2++)
			{
				byte outerInjury = defeatMarks.OuterInjuryMarkList[part2];
				byte innerInjury = defeatMarks.InnerInjuryMarkList[part2];
				if (attackOdds[part2] > 0 && (outerInjury >= 3 || innerInjury >= 3))
				{
					attackOdds[part2] = (sbyte)Math.Max(attackOdds[part2] / 10, 1);
				}
			}
		}
		for (sbyte part3 = 0; part3 < 7; part3++)
		{
			if (attackOdds[part3] > 0)
			{
				attackOdds[part3] = DomainManager.SpecialEffect.ModifyValue(attacker.GetId(), 306, attackOdds[part3], part3);
			}
		}
		sbyte attackBodyPart = (sbyte)RandomUtils.GetRandomIndex(attackOdds, Context.Random);
		ObjectPool<List<int>>.Instance.Return(attackOdds);
		return (sbyte)DomainManager.SpecialEffect.ModifyData(attacker.GetId(), skillId, 140, attackBodyPart);
	}

	private int ApplyHitOddsSpecialEffect(CombatCharacter attacker, CombatCharacter defender, int hitOdds, sbyte hitType, short skillId = -1)
	{
		long hitOddsLong = hitOdds;
		int percent = 100;
		percent += DomainManager.SpecialEffect.GetModifyValue(attacker.GetId(), skillId, 74, EDataModifyType.AddPercent, hitType);
		percent += DomainManager.SpecialEffect.GetModifyValue(defender.GetId(), skillId, 107, EDataModifyType.AddPercent, hitType);
		hitOddsLong = Math.Max(hitOddsLong * percent / 100, 0L);
		(int, int) attackerValue = DomainManager.SpecialEffect.GetTotalPercentModifyValue(attacker.GetId(), skillId, 74, hitType);
		(int, int) defenderValue = DomainManager.SpecialEffect.GetTotalPercentModifyValue(defender.GetId(), skillId, 107, hitType);
		if (attacker.GetIsFightBack())
		{
			(int, int) attackerFightBackValue = DomainManager.SpecialEffect.GetTotalPercentModifyValue(attacker.GetId(), skillId, 75, hitType);
			attackerValue.Item1 = Math.Max(attackerValue.Item1, attackerFightBackValue.Item1);
			attackerValue.Item2 = Math.Min(attackerValue.Item2, attackerFightBackValue.Item2);
			(int, int) defenderFightBackValue = DomainManager.SpecialEffect.GetTotalPercentModifyValue(defender.GetId(), skillId, 108, hitType);
			defenderValue.Item1 = Math.Max(defenderValue.Item1, defenderFightBackValue.Item1);
			defenderValue.Item2 = Math.Min(defenderValue.Item2, defenderFightBackValue.Item2);
		}
		percent = 100 + Math.Max(attackerValue.Item1, defenderValue.Item1) + Math.Min(attackerValue.Item2, defenderValue.Item2);
		hitOddsLong = Math.Max(hitOddsLong * percent / 100, 0L);
		hitOdds = (int)Math.Min(hitOddsLong, 2147483647L);
		hitOdds = DomainManager.SpecialEffect.ModifyData(attacker.GetId(), skillId, 74, hitOdds);
		hitOdds = DomainManager.SpecialEffect.ModifyData(defender.GetId(), skillId, 107, hitOdds);
		return hitOdds;
	}

	public void TransferDisorderOfQi(DataContext context, CombatCharacter srcChar, CombatCharacter dstChar, int delta)
	{
		delta = Math.Min(delta, srcChar.GetCharacter().GetDisorderOfQi() - srcChar.GetOldDisorderOfQi());
		if (delta > 0)
		{
			srcChar.GetCharacter().TransferDisorderOfQi(context, dstChar.GetCharacter(), delta);
		}
	}

	public void ChangeDisorderOfQiRandomRecovery(DataContext context, CombatCharacter combatChar, int delta, bool changeToOld = false)
	{
		delta = CFormula.RandomCalcDisorderOfQiDelta(context.Random, delta);
		if (delta >= 0 || combatChar.GetOldDisorderOfQi() < combatChar.GetCharacter().GetDisorderOfQi())
		{
			if (delta < 0)
			{
				delta = Math.Clamp(delta, combatChar.GetOldDisorderOfQi() - combatChar.GetCharacter().GetDisorderOfQi(), 0);
			}
			if (delta > 0 && changeToOld)
			{
				combatChar.SetOldDisorderOfQi((short)Math.Clamp(combatChar.GetOldDisorderOfQi() + delta, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue), context);
			}
			GameData.Domains.Character.Character character = combatChar.GetCharacter();
			character.ChangeDisorderOfQi(context, delta);
		}
	}

	public static int CalcWeaponAttack(CombatCharacter combatChar, GameData.Domains.Item.Weapon weapon, short skillId)
	{
		int equipAttack = weapon.GetEquipmentAttack();
		if (combatChar.SkillUseLegAsWeapon(skillId))
		{
			ItemKey shoesKey = combatChar.Armors[5];
			GameData.Domains.Item.Armor shoes = (shoesKey.IsValid() ? DomainManager.Item.GetElement_Armors(shoesKey.Id) : null);
			equipAttack = CalcArmorAttack(combatChar, shoes);
		}
		return equipAttack * DomainManager.SpecialEffect.GetModify(combatChar.GetId(), skillId, 141);
	}

	public static int CalcWeaponDefend(CombatCharacter combatChar, GameData.Domains.Item.Weapon weapon, short skillId)
	{
		int equipDefense = weapon.GetEquipmentDefense();
		if (combatChar.SkillUseLegAsWeapon(skillId))
		{
			ItemKey shoesKey = combatChar.Armors[5];
			GameData.Domains.Item.Armor shoes = (shoesKey.IsValid() ? DomainManager.Item.GetElement_Armors(shoesKey.Id) : null);
			equipDefense = CalcArmorDefend(combatChar, shoes);
		}
		return equipDefense * DomainManager.SpecialEffect.GetModify(combatChar.GetId(), skillId, 142, weapon.GetId());
	}

	public static int CalcArmorAttack(CombatCharacter combatChar, GameData.Domains.Item.Armor armor)
	{
		int equipAttack = ((armor != null && armor.GetCurrDurability() > 0) ? armor.GetEquipmentAttack() : 100);
		return DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 143, equipAttack);
	}

	public static int CalcArmorDefend(CombatCharacter combatChar, GameData.Domains.Item.Armor armor)
	{
		int equipDefense = ((armor != null && armor.GetCurrDurability() > 0) ? armor.GetEquipmentDefense() : 50);
		return DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 144, equipDefense, armor?.GetId() ?? (-1));
	}

	public static bool IsWeaponCanBreak(short weaponSubType)
	{
		bool flag = (uint)(weaponSubType - 16) <= 1u;
		return !flag;
	}

	public void CostDurability(DataContext context, CombatCharacter character, ItemKey key, int cost)
	{
		ChangeDurability(context, character, key, -cost, EChangeDurabilitySourceType.Cost);
	}

	public void ChangeDurability(DataContext context, CombatCharacter character, ItemKey key, int delta, EChangeDurabilitySourceType sourceType)
	{
		if (!key.IsValid())
		{
			return;
		}
		ItemBase item = DomainManager.Item.GetBaseItem(key);
		if (item.GetMaxDurability() <= 0)
		{
			return;
		}
		character.ChangingDurabilityItems.Push(key);
		delta = DomainManager.SpecialEffect.ModifyValueCustom(character.GetId(), 307, delta, key.ItemType, (int)sourceType);
		character.ChangingDurabilityItems.Pop();
		if (!item.ChangeCurrDurability(context, delta))
		{
			return;
		}
		if (delta > 0)
		{
			EnsureOldDurability(key);
		}
		if (item.GetCurrDurability() == 0)
		{
			Events.RaiseChangeDurabilityToZero(context, character, key);
		}
		short newDurability = item.GetCurrDurability();
		if (key.ItemType != 0)
		{
			return;
		}
		CombatWeaponData weapon = GetElement_WeaponDataDict(key.Id);
		if (weapon.GetDurability() != newDurability)
		{
			weapon.SetDurability(newDurability, context);
		}
		if (newDurability == 0)
		{
			weapon.SetCanChangeTo(canChangeTo: false, context);
			int index = character.GetWeapons().IndexOf(key);
			if (index >= 0 && index < 3)
			{
				character.ClearUnlockAttackValue(context, index);
			}
			if (!(key != character.GetWeapons()[character.GetUsingWeaponIndex()]) && !character.GetRawCreateCollection().Contains(key))
			{
				ChangeWeapon(context, character, 3);
			}
		}
	}

	private bool CanPlayHitAnimation(CombatCharacter character)
	{
		return !IsCharacterFallen(character) && character.GetAttackingTrickType() < 0 && character.GetAffectingDefendSkillId() < 0 && character.GetPreparingSkillId() < 0 && character.GetPreparingOtherAction() < 0 && !character.GetPreparingItem().IsValid() && character.GetAnimationToLoop() != "C_007" && IsCurrentCombatCharacter(character);
	}

	public void UpdateAllCommandAvailability(DataContext context, CombatCharacter character)
	{
		UpdateSkillCanUse(context, character);
		UpdateWeaponCanChange(context, character);
		UpdateOtherActionCanUse(context, character, -1);
		UpdateAllTeammateCommandUsable(context, character.IsAlly, -1);
		UpdateCanUseItem(context, character);
		UpdateCanChangeTrick(context, character);
		UpdateCanSurrender(context, character);
	}

	public bool CheckHit(DataContext context, CombatCharacter character, sbyte hitType, int hitValuePercent = 100)
	{
		CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
		sbyte bodyPart = (sbyte)context.Random.Next(0, 7);
		int hitValue = character.GetHitValue(hitType, bodyPart, 0, -1) * hitValuePercent / 100;
		int avoidValue = enemyChar.GetAvoidValue(hitType, bodyPart, -1);
		int hitOdds = hitValue * 100 / avoidValue / ((hitValue >= avoidValue) ? 1 : 2);
		hitOdds = ApplyHitOddsSpecialEffect(character, enemyChar, hitOdds, hitType, -1);
		return hitOdds < 0 || context.Random.CheckPercentProb(hitOdds);
	}

	public string GetMusicWeaponNameFix(CombatWeaponData weaponData)
	{
		return (weaponData.Template.ItemSubType == 11) ? "_guqin" : ((weaponData.TemplateId == 884) ? "_sing" : "_flute");
	}

	public ShowSpecialEffectDisplayData CalcEffectDisplayData(int charId, int effectId, int index, ItemKey itemData)
	{
		short skillTemplateId = Config.SpecialEffect.Instance[effectId].SkillTemplateId;
		return new ShowSpecialEffectDisplayData
		{
			Index = index,
			EffectId = effectId,
			ItemData = itemData,
			EffectDescription = DomainManager.CombatSkill.GetEffectDisplayData(charId, skillTemplateId)
		};
	}

	public void ShowWugKingEffectTips(DataContext context, int srcCharId, int dstCharId)
	{
		int effectId;
		if (srcCharId == dstCharId)
		{
			effectId = 1707;
		}
		else
		{
			if (_combatCharacterDict[srcCharId].IsAlly == _combatCharacterDict[dstCharId].IsAlly)
			{
				PredefinedLog.Show(8, $"Unexpected wug king from {srcCharId} to {dstCharId}");
				return;
			}
			effectId = 1706;
		}
		ShowSpecialEffectTips(srcCharId, effectId, 0);
	}

	public void ShowSpecialEffectTips(int charId, int effectId, byte index = 0)
	{
		if (IsInCombat() && _combatCharacterDict.TryGetValue(charId, out var character) && IsCurrentCombatCharacter(character))
		{
			int checkedIndex = ShowSpecialEffectDisplayData.CheckIndex(effectId, index);
			if (checkedIndex >= 0)
			{
				GetCombatCharacter(_combatCharacterDict[charId].IsAlly).NeedShowEffectList.Add(CalcEffectDisplayData(charId, effectId, checkedIndex, ItemKey.Invalid));
			}
		}
	}

	public void ShowSpecialEffectTips(int charId, int effectId, ItemKey itemKey, byte index = 0)
	{
		if (IsInCombat() && _combatCharacterDict.TryGetValue(charId, out var character) && IsCurrentCombatCharacter(character))
		{
			int checkedIndex = ShowSpecialEffectDisplayData.CheckIndex(effectId, index);
			if (checkedIndex >= 0)
			{
				_combatCharacterDict[charId].NeedShowEffectList.Add(CalcEffectDisplayData(charId, effectId, checkedIndex, itemKey));
			}
		}
	}

	public void ShowSpecialEffectTipsByDisplayEvent(int charId, int effectId, byte index = 0)
	{
		if (IsInCombat() && _combatCharacterDict.TryGetValue(charId, out var combatChar))
		{
			int checkedIndex = ShowSpecialEffectDisplayData.CheckIndex(effectId, index);
			ShowSpecialEffectDisplayData data = CalcEffectDisplayData(charId, effectId, checkedIndex, ItemKey.Invalid);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowSpecialEffect, combatChar.IsAlly, data);
		}
	}

	public void ShowTeammateCommand(int teammateId, int index, bool displayEvent = false)
	{
		if (!IsInCombat() || !_combatCharacterDict.TryGetValue(teammateId, out var teammate))
		{
			return;
		}
		List<sbyte> allCmdTypes = teammate.GetCurrTeammateCommands();
		if (!allCmdTypes.CheckIndex(index))
		{
			return;
		}
		int[] charIds = GetCharacterList(teammate.IsAlly);
		sbyte validIndexCharacter = 0;
		for (int i = 0; i < charIds.Length && charIds[i] != teammateId; i++)
		{
			if (charIds[i] >= 0)
			{
				validIndexCharacter++;
			}
		}
		validIndexCharacter--;
		TeammateCommandDisplayData data = new TeammateCommandDisplayData
		{
			CmdType = allCmdTypes[index],
			IndexCharacter = (sbyte)(charIds.IndexOf(teammateId) - 1),
			ValidIndexCharacter = validIndexCharacter,
			IndexCommand = (sbyte)index,
			IsAlly = teammate.IsAlly
		};
		if (displayEvent)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowCommand, data);
			return;
		}
		CombatCharacter mainChar = GetMainCharacter(teammate.IsAlly);
		mainChar.NeedShowCommandList.Add(data);
	}

	public void Reset(DataContext context, CombatCharacter character)
	{
		character.GetCharacter().SetInjuries(default(Injuries), context);
		character.SetInjuries(default(Injuries), context);
		character.SetOldInjuries(default(Injuries), context);
		int[] outerDamageValue = character.GetOuterDamageValue();
		int[] innerDamageValue = character.GetInnerDamageValue();
		Array.Clear(outerDamageValue, 0, outerDamageValue.Length);
		Array.Clear(innerDamageValue, 0, innerDamageValue.Length);
		character.SetOuterDamageValue(outerDamageValue, context);
		character.SetInnerDamageValue(innerDamageValue, context);
		character.SetMindDamageValue(0, context);
		character.SetFatalDamageValue(0, context);
		PoisonInts emptyPoisons = default(PoisonInts);
		character.GetCharacter().SetPoisoned(ref emptyPoisons, context);
		character.SetPoison(ref emptyPoisons, context);
		character.SetOldPoison(ref emptyPoisons, context);
		character.SetFlawCount(new byte[7], context);
		character.SetFlawCollection(new FlawOrAcupointCollection(), context);
		character.SetAcupointCount(new byte[7], context);
		character.SetAcupointCollection(new FlawOrAcupointCollection(), context);
		character.SetMindMarkTime(new MindMarkList(), context);
		character.SetScarMarkTime(new List<CountdownData>(), context);
		ClearCombatState(context, character);
		character.UnRegisterMarkHandler();
		character.SetDefeatMarkCollection(new DefeatMarkCollection(), context);
		character.RegisterMarkHandler();
	}

	public void AddBossPhase(DataContext context, CombatCharacter character, int effectId)
	{
		int charId = character.GetId();
		bool isAlly = character.IsAlly;
		sbyte newPhase = (sbyte)(character.GetBossPhase() + 1);
		InterruptSkill(context, character, -1);
		InterruptOtherAction(context, character);
		character.NeedChangeBossPhase = true;
		character.ChangeBossPhaseEffectId = effectId;
		character.ClearAllDoingOrReserveCommand(context);
		character.ClearMindRhythmAndUpheaval(context);
		character.SetHazardValue(0, context);
		character.GetCharacter().SetHealth(character.GetCharacter().GetLeftMaxHealth(), context);
		character.GetCharacter().SetDisorderOfQi(character.GetOldDisorderOfQi(), context);
		character.SetMixPoisonAffectedCount(character.GetMixPoisonAffectedCount().Clear(), context);
		character.GetCharacter().ClearEatingItems(context);
		ClearSkillEffect(context, character);
		List<short> attackSkillList = character.GetAttackSkillList();
		short[] newSkillList = character.BossConfig.PhaseAttackSkills[newPhase];
		for (int i = attackSkillList.Count - 1; i >= 0; i--)
		{
			short skillId = attackSkillList[i];
			if (skillId >= 0 && !Enumerable.Contains(newSkillList, skillId))
			{
				CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
				DomainManager.SpecialEffect.Remove(context, charId, skillId, 1);
				RemoveElement_SkillDataDict(skillKey);
				attackSkillList.RemoveAt(i);
			}
		}
		short[] array = newSkillList;
		foreach (short skillId2 in array)
		{
			if (skillId2 >= 0 && !attackSkillList.Contains(skillId2))
			{
				DomainManager.SpecialEffect.Add(context, charId, skillId2, 1, -1);
				AddCombatSkillData(context, charId, skillId2);
				attackSkillList.Add(skillId2);
			}
		}
		character.SetAttackSkillList(attackSkillList, context);
		if (character.BossConfig.PhaseWeapons != null)
		{
			short[] weaponList = character.BossConfig.PhaseWeapons[newPhase];
			ItemKey[] combatWeapons = character.GetWeapons();
			GameData.Domains.Character.Character charObj = character.GetCharacter();
			ItemKey[] equipments = charObj.GetEquipment();
			sbyte[] weaponSlots = EquipmentSlot.EquipmentType2Slots[0];
			for (int k = 0; k < weaponSlots.Length; k++)
			{
				ItemKey weaponKey = equipments[weaponSlots[k]];
				if (weaponKey.IsValid())
				{
					charObj.ChangeEquipment(context, weaponSlots[k], -1, ItemKey.Invalid);
					charObj.RemoveInventoryItem(context, weaponKey, 1, deleteItem: true);
					RemoveElement_WeaponDataDict(weaponKey.Id);
				}
			}
			for (int l = 0; l < weaponList.Length; l++)
			{
				ItemKey weaponKey2 = DomainManager.Item.CreateWeapon(context, weaponList[l], 0);
				List<sbyte> weaponTricks = DomainManager.Item.GetWeaponTricks(weaponKey2);
				CombatWeaponData weaponData = new CombatWeaponData(weaponKey2, character);
				sbyte[] trickList = weaponData.GetWeaponTricks();
				charObj.AddInventoryItem(context, weaponKey2, 1);
				charObj.ChangeEquipment(context, -1, weaponSlots[l], weaponKey2);
				combatWeapons[l] = weaponKey2;
				AddElement_WeaponDataDict(weaponKey2.Id, weaponData);
				weaponData.Init(context, l);
				for (int m = 0; m < weaponTricks.Count; m++)
				{
					trickList[m] = weaponTricks[m];
				}
			}
			character.SetWeapons(combatWeapons, context);
			character.SetUsingWeaponIndex(character.GetUsingWeaponIndex(), context);
			UpdateCanChangeTrick(context, character);
		}
		else
		{
			ItemKey[] weapons = character.GetWeapons();
			for (int n = 0; n < 3; n++)
			{
				if (weapons[n].IsValid())
				{
					ClearWeaponCd(context, character, n);
				}
			}
		}
		if (character.BossConfig.FailPlayerAni != null && character.BossConfig.FailPlayerAni.Count > character.GetBossPhase())
		{
			DomainManager.Combat.ForceAllTeammateLeaveCombatField(context, !isAlly);
		}
		Events.RaiseChangeBossPhase(context);
	}

	private List<int> ProcessTaiwuTeam(DataContext context, short combatConfigId, IReadOnlyList<int> enemyTeam)
	{
		CombatConfigItem config = Config.CombatConfig.Instance[combatConfigId];
		List<int> result = new List<int> { DomainManager.Taiwu.GetTaiwuCharId() };
		if (!config.AllowGroupMember)
		{
			return result;
		}
		for (int i = 0; i < 3; i++)
		{
			int teammateId = DomainManager.Taiwu.GetElement_CombatGroupCharIds(i);
			if (teammateId >= 0 && !enemyTeam.Contains(teammateId))
			{
				result.Add(teammateId);
			}
		}
		Dictionary<StoryTeammateType, int> vitalTeammateData = _vitalTeammateData;
		if (vitalTeammateData == null || vitalTeammateData.Count <= 0)
		{
			return result;
		}
		foreach (var (type, index) in _vitalTeammateData)
		{
			if (type < StoryTeammateType.IronPlate)
			{
				if (config.AllowVitalDemon)
				{
					SectStoryThreeVitalsCharacterType vitalType = (SectStoryThreeVitalsCharacterType)type;
					int vitalCharId = DomainManager.Extra.GetVitalCharacterByType(context, vitalType).GetId();
					if (result.CheckIndex(index))
					{
						result[index] = vitalCharId;
					}
					else
					{
						result.Add(vitalCharId);
					}
				}
			}
			else
			{
				IronPlateData ironPlateData = DomainManager.Story.GetIronPlateData();
				if (result.CheckIndex(index))
				{
					result[index] = ironPlateData.FollowingCharId;
				}
				else
				{
					result.Add(ironPlateData.FollowingCharId);
				}
			}
		}
		return result;
	}

	private void ProcessTeam(short combatConfigId, IList<int> teamCharIds)
	{
		CombatConfigItem config = Config.CombatConfig.Instance[combatConfigId];
		if (!config.AllowGroupMember)
		{
			int mainCharId = teamCharIds[0];
			teamCharIds.Clear();
			teamCharIds.Add(mainCharId);
		}
	}

	public void CombatEntry(DataContext context, List<int> enemyTeam, short combatConfigId)
	{
		List<int> taiwuTeam = ProcessTaiwuTeam(context, combatConfigId, enemyTeam);
		CombatEntry(taiwuTeam, enemyTeam, combatConfigId);
		Events.RaiseTaiwuCombatEntry(context, enemyTeam, combatConfigId);
	}

	public void CombatEntry(List<int> leftTeam, List<int> rightTeam, short combatConfigId)
	{
		ProcessTeam(combatConfigId, leftTeam);
		ProcessTeam(combatConfigId, rightTeam);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.StartCombat, leftTeam, rightTeam, combatConfigId);
	}

	[DomainMethod]
	public EPrepareCombatResult PrepareSimulate(List<int> leftTeam, List<int> rightTeam)
	{
		return CFormulaHelper.RandomPrepareResult(leftTeam, rightTeam);
	}

	[DomainMethod]
	public TeammateCommandChangeData PreparePreRandomTeammateCommands(DataContext context, short combatConfigId, List<int> leftTeam, List<int> rightTeam)
	{
		CombatConfigItem config = Config.CombatConfig.Instance[combatConfigId];
		if (config.AllowRandomFavorability)
		{
			PreparePreRandomTeammateCommandsGenerateFavorability(context, leftTeam);
			PreparePreRandomTeammateCommandsGenerateFavorability(context, rightTeam);
		}
		PreRandomizedTeammateCommandReplaceData = new TeammateCommandChangeData
		{
			LeftTeam = CalcTeammateBetrayData(context, combatConfigId, leftTeam, isAlly: true),
			RightTeam = CalcTeammateBetrayData(context, combatConfigId, rightTeam, isAlly: false)
		};
		if (config.AllowVitalDemonBetray && leftTeam[0] == DomainManager.Taiwu.GetTaiwuCharId())
		{
			ProcessVitalDemonBetray(context, PreRandomizedTeammateCommandReplaceData.RightTeam);
		}
		return PreRandomizedTeammateCommandReplaceData;
	}

	private void PreparePreRandomTeammateCommandsGenerateFavorability(DataContext context, IReadOnlyList<int> team)
	{
		int mainCharId = team[0];
		for (int i = 1; i < team.Count; i++)
		{
			int charId = team[i];
			if (charId < 0)
			{
				continue;
			}
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			if (character.GetCreatingType() != 1)
			{
				short existFavorability = DomainManager.Character.GetFavorability(mainCharId, charId);
				if (existFavorability == short.MinValue)
				{
					short favorability = character.GetRandomFavorability(context.Random);
					DomainManager.Character.DirectlySetFavorabilities(context, mainCharId, charId, favorability, favorability);
				}
			}
		}
	}

	[DomainMethod]
	public sbyte PrepareCombat(DataContext context, short combatConfigId, List<int> leftTeam, List<int> rightTeam)
	{
		return PrepareCombat(context, combatConfigId, (IReadOnlyList<int>)leftTeam, (IReadOnlyList<int>)rightTeam);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		crossArchiveGameData.EnemyUnyieldingFallen = _enemyUnyieldingFallen;
		crossArchiveGameData.EnemyDisableAi = _disableEnemyAi;
		crossArchiveGameData.LastTargetDistance = _lastTargetDistance;
	}

	public override void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
		SetEnemyUnyieldingFallen(crossArchiveGameData.EnemyUnyieldingFallen, context);
		SetDisableEnemyAi(crossArchiveGameData.EnemyDisableAi, context);
		SetLastTargetDistance(crossArchiveGameData.LastTargetDistance, context);
	}

	[DomainMethod]
	public DefeatMarkDetailInfoDisplayData GetMarkDisplayData(DataContext context, int charId, DefeatMarkKey markKey)
	{
		if (!IsInCombat() || !TryGetElement_CombatCharacterDict(charId, out var combatChar))
		{
			return null;
		}
		EMarkType type = markKey.Type;
		if (1 == 0)
		{
		}
		DefeatMarkDetailInfoDisplayData result = type switch
		{
			EMarkType.Poison => GetMarkDisplayDataPoison(combatChar, markKey), 
			EMarkType.State => GetMarkDisplayDataState(combatChar), 
			EMarkType.Wug => GetMarkDisplayDataWug(combatChar), 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private DefeatMarkDetailInfoDisplayData GetMarkDisplayDataPoison(CombatCharacter combatChar, DefeatMarkKey markKey)
	{
		return new DefeatMarkDetailInfoDisplayData
		{
			PoisonTriggerProgress = combatChar.GetPoisonAccumulator(markKey.PoisonType)
		};
	}

	private DefeatMarkDetailInfoDisplayData GetMarkDisplayDataState(CombatCharacter combatChar)
	{
		return new DefeatMarkDetailInfoDisplayData
		{
			StateBuffPower = combatChar.GetCombatStateTotalBuffPower()
		};
	}

	private DefeatMarkDetailInfoDisplayData GetMarkDisplayDataWug(CombatCharacter combatChar)
	{
		short[] wugTemplateIds = new short[9];
		for (int i = 0; i < 9; i++)
		{
			wugTemplateIds[i] = -1;
		}
		EatingItems eatingItems = combatChar.GetCharacter().GetEatingItems();
		for (int j = 0; j < 9; j++)
		{
			ItemKey itemKey = eatingItems.Get(j);
			if (EatingItems.IsValid(itemKey) && itemKey.ItemType == 8)
			{
				MedicineItem medicineItem = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineItem != null && medicineItem.ItemSubType == 802)
				{
					wugTemplateIds[j] = itemKey.TemplateId;
				}
			}
		}
		return new DefeatMarkDetailInfoDisplayData
		{
			WugTemplateIds = wugTemplateIds
		};
	}

	[DomainMethod]
	public void SetMoveState(MoveState state, bool isAlly = true, bool setByPlayer = false)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.MoveState != state && (!setByPlayer || state != MoveState.Stay || combatChar.PlayerControllingMove))
		{
			DataContext context = combatChar.GetDataContext();
			combatChar.SetMoveState(state, context);
			if (isAlly)
			{
				combatChar.SetPlayerControllingMove(setByPlayer && combatChar.KeepMoving, context);
			}
			if (state != combatChar.MoveData.JumpPrepareDirection && (combatChar.KeepMoving || (combatChar.MoveData.CanPartlyJump && combatChar.GetJumpPreparedDistance() > 0)))
			{
				combatChar.MoveData.ResetJumpState(context);
			}
			if (combatChar.KeepMoving)
			{
				combatChar.MoveData.JumpPrepareDirection = state;
			}
			else
			{
				SetProperLoopAniAndParticle(context, combatChar);
			}
			Events.RaiseMoveStateChanged(context, combatChar, state);
		}
	}

	[DomainMethod]
	public void SetTargetDistance(DataContext context, short targetDistance, bool isAlly = true)
	{
		if (IsInCombat() && !IsAiMoving)
		{
			CombatCharacter combatChar = GetCombatCharacter(isAlly);
			combatChar.PlayerTargetDistance = targetDistance;
			if (_timeScale <= 0f)
			{
				combatChar.SetTargetDistance(context, targetDistance);
			}
		}
	}

	[DomainMethod]
	public void ClearTargetDistance(DataContext context)
	{
		SetTargetDistance(context, -1);
	}

	[DomainMethod]
	public bool SetJumpThreshold(DataContext context, short combatSkillId, short jumpThreshold)
	{
		return DomainManager.Extra.SetJumpThreshold(context, combatSkillId, jumpThreshold);
	}

	public (byte min, byte max) GetDistanceRange()
	{
		return (min: CombatConfig.MinDistance, max: CombatConfig.MaxDistance);
	}

	public short GetMoveRangeOffsetCurrentDistance(int offset)
	{
		return GetMoveRangeDistance(_currentDistance + offset);
	}

	public short GetMoveRangeDistance(int distance)
	{
		var (min, max) = GetDistanceRange();
		return (short)Math.Clamp(distance, min, max);
	}

	public short GetNearlyOutDistance(OuterAndInnerShorts range)
	{
		(byte, byte) distanceRange = GetDistanceRange();
		int forwardDistance = _currentDistance - range.Outer;
		int backwardDistance = range.Inner - _currentDistance;
		bool canForward = range.Outer - 1 >= distanceRange.Item1;
		bool canBackward = range.Inner + 1 <= distanceRange.Item2;
		if (!canForward && !canBackward)
		{
			return -1;
		}
		return (short)(((forwardDistance < backwardDistance || !canBackward) && canForward) ? (range.Outer - 1) : (range.Inner + 1));
	}

	public bool CanMove(CombatCharacter combatChar, bool forward)
	{
		if (!combatChar.GetCharacter().Template.CanMove)
		{
			return false;
		}
		if (combatChar.IsMoving)
		{
			return false;
		}
		(byte, byte) distanceRange = GetDistanceRange();
		if (forward ? (_currentDistance <= distanceRange.Item1) : (_currentDistance >= distanceRange.Item2))
		{
			return false;
		}
		if (combatChar.TeammateBeforeMainChar >= 0 || combatChar.TeammateAfterMainChar >= 0)
		{
			return false;
		}
		if (_isTutorialCombat && !combatChar.CanRecoverMobility)
		{
			return false;
		}
		CombatCharacterStateType currState = combatChar.StateMachine.GetCurrentStateType();
		bool canMove;
		if (currState == CombatCharacterStateType.PrepareSkill)
		{
			canMove = (forward ? combatChar.MoveData.CanMoveForwardInSkillPrepareDist : combatChar.MoveData.CanMoveBackwardInSkillPrepareDist) > 0;
		}
		else
		{
			bool flag = ((currState == CombatCharacterStateType.Idle || currState == CombatCharacterStateType.PrepareOtherAction) ? true : false);
			canMove = flag;
		}
		short combatConfigId = DomainManager.Combat.CombatConfig.TemplateId;
		if ((uint)(combatConfigId - 157) <= 1u)
		{
			canMove = canMove && combatChar.GetAffectingMoveSkillId() >= 0;
		}
		return canMove;
	}

	public void RecoverMobilityValue(DataContext context, CombatCharacter character)
	{
		int currMobility = character.GetMobilityValue();
		int maxMobility = character.GetMaxMobility();
		if (currMobility < maxMobility && character.CanRecoverMobility)
		{
			ChangeMobilityValue(context, character, character.GetMobilityRecoverSpeed());
		}
	}

	public void ChangeMobilityValue(DataContext context, CombatCharacter character, int addValue, bool changedByEffect = false, CombatCharacter changer = null, bool costBySkill = false)
	{
		if (changedByEffect && addValue < 0)
		{
			if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 149, dataValue: true, changer?.GetId() ?? (-1)))
			{
				return;
			}
			addValue = DomainManager.SpecialEffect.ModifyValue(character.GetId(), 150, addValue, changer?.GetId() ?? (-1));
		}
		int maxMobility = character.GetMaxMobility();
		int mobilityValue = Math.Clamp(character.GetMobilityValue() + addValue, 0, maxMobility);
		if (mobilityValue != character.GetMobilityValue())
		{
			character.SetMobilityValue(mobilityValue, context);
			if (IsCurrentCombatCharacter(character))
			{
				UpdateSkillNeedMobilityCanUse(context, character);
			}
		}
	}

	public void ExchangeMobilityValue(DataContext context, CombatCharacter combatCharA, CombatCharacter combatCharB)
	{
		int oldMobilityA = combatCharA.GetMobilityValue();
		int oldMobilityB = combatCharB.GetMobilityValue();
		ChangeMobilityValue(context, combatCharA, oldMobilityB - oldMobilityA);
		ChangeMobilityValue(context, combatCharB, oldMobilityA - oldMobilityB);
	}

	public bool ChangeDistance(DataContext context, CombatCharacter mover, int addDistance)
	{
		return ChangeDistance(context, mover, addDistance, isForced: false, canStop: true);
	}

	public bool ChangeDistance(DataContext context, CombatCharacter mover, int addDistance, bool isForced)
	{
		return ChangeDistance(context, mover, addDistance, isForced, canStop: true);
	}

	public bool ChangeDistance(DataContext context, CombatCharacter mover, int addDistance, bool isForced, bool canStop)
	{
		bool lockDistance = DomainManager.SpecialEffect.ModifyData(-1, -1, 244, dataValue: false);
		if (lockDistance && canStop)
		{
			return false;
		}
		bool isMove = DomainManager.SpecialEffect.ModifyData(mover.GetId(), -1, 157, dataValue: true);
		int modifiedDistance = addDistance;
		if (isMove)
		{
			modifiedDistance = DomainManager.SpecialEffect.ModifyData(mover.GetId(), -1, 151, addDistance, (addDistance < 0) ? 1 : 0);
			if (!DomainManager.SpecialEffect.ModifyData(mover.GetId(), -1, 147, dataValue: true))
			{
				modifiedDistance = ((addDistance > 0) ? Math.Max(addDistance, modifiedDistance) : Math.Min(addDistance, modifiedDistance));
			}
			if (isForced && !DomainManager.SpecialEffect.ModifyData(mover.GetId(), -1, 148, dataValue: true, addDistance))
			{
				Events.RaiseIgnoredForceChangeDistance(context, mover, addDistance);
				return false;
			}
		}
		(byte, byte) distanceRange = GetDistanceRange();
		byte newDistance = (byte)Math.Clamp(_currentDistance + modifiedDistance, distanceRange.Item1, distanceRange.Item2);
		int movedDist = newDistance - _currentDistance;
		if (movedDist == 0)
		{
			return true;
		}
		int newPos = mover.GetCurrentPosition() + movedDist * ((!mover.IsAlly) ? 1 : (-1));
		bool needUpdateMoveAni = _currentDistance <= GlobalConfig.Instance.FastWalkDistance != newDistance <= GlobalConfig.Instance.FastWalkDistance;
		mover.SetCurrentPosition((short)newPos, context);
		SetCurrentDistance(newDistance, context);
		UpdateSkillNeedDistanceCanUse(context, _selfChar);
		UpdateSkillNeedDistanceCanUse(context, _enemyChar);
		UpdateOtherActionCanUse(context, _selfChar, 2);
		UpdateOtherActionCanUse(context, _enemyChar, 2);
		UpdateAllTeammateCommandUsable(context, isAlly: true, -1);
		UpdateAllTeammateCommandUsable(context, isAlly: false, -1);
		UpdateShowUseSpecialMisc(context);
		if (needUpdateMoveAni)
		{
			SetProperLoopAniAndParticle(context, _selfChar);
			SetProperLoopAniAndParticle(context, _enemyChar);
		}
		if (isMove && mover.PoisonOverflow(1))
		{
			mover.AddPoisonAffectValue(1, (short)Math.Abs(modifiedDistance));
		}
		Events.RaiseDistanceChanged(context, mover, (short)movedDist, isMove, isForced);
		return true;
	}

	public void EnsureDistance(DataContext context, CombatCharacter checker)
	{
		ChangeDistance(context, checker, 0, isForced: false, canStop: false);
	}

	public int GetSkillCostMobilityPerFrame(CombatCharacter character, short skillId)
	{
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillId));
		int breakPercent = skill.GetBreakoutGridCombatSkillPropertyBonus(16);
		foreach (SkillBreakPageEffectImplementItem effect in skill.GetPageEffects())
		{
			breakPercent += effect.CostMobilityByFrame;
		}
		foreach (SkillBreakPlateBonus breakBonuse in skill.GetBreakBonuses())
		{
			breakPercent += breakBonuse.CalcCostMobilityByFrame();
		}
		int costMobility = Config.CombatSkill.Instance[skillId].MobilityReduceSpeed;
		costMobility = DomainManager.SpecialEffect.ModifyValue(character.GetId(), skillId, 179, costMobility, -1, -1, -1, 0, breakPercent);
		return Math.Max(costMobility, 0);
	}

	public int GetSkillMoveCostMobility(CombatCharacter character, short skillId)
	{
		int charId = character.GetId();
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId));
		int gridBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(17);
		foreach (SkillBreakPageEffectImplementItem effect in skill.GetPageEffects())
		{
			gridBonus += effect.CostMobilityByMove;
		}
		foreach (SkillBreakPlateBonus breakBonuse in skill.GetBreakBonuses())
		{
			gridBonus += breakBonuse.CalcCostMobilityByMove();
		}
		int costSkillMobility = Config.CombatSkill.Instance[skillId].MoveCostMobility;
		return DomainManager.SpecialEffect.ModifyValueCustom(charId, skillId, 175, costSkillMobility, -1, -1, -1, 0, gridBonus);
	}

	public bool InAttackRange(CombatCharacter character)
	{
		if (character.GetCanAttackOutRange())
		{
			return true;
		}
		if (character.GetIsFightBack() && DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 340, dataValue: false))
		{
			return true;
		}
		short distance = GetCurrentDistance();
		OuterAndInnerShorts attackRange = character.GetAttackRange();
		return distance >= attackRange.Outer && distance <= attackRange.Inner;
	}

	public bool AnyAttackRangeEdge(CombatCharacter character)
	{
		if (character.GetCanAttackOutRange())
		{
			return false;
		}
		(byte, byte) moveRange = GetDistanceRange();
		OuterAndInnerShorts attackRange = character.GetAttackRange();
		return moveRange.Item1 < attackRange.Outer || moveRange.Item2 > attackRange.Inner;
	}

	public bool IsMovedByTeammate(CombatCharacter character)
	{
		if (character.TeammateAfterMainChar < 0)
		{
			return false;
		}
		CombatCharacter teammateChar = _combatCharacterDict[character.TeammateAfterMainChar];
		ETeammateCommandImplement executingTeammateCommandImplement = teammateChar.ExecutingTeammateCommandImplement;
		return (uint)(executingTeammateCommandImplement - 2) <= 1u;
	}

	public int GetDisplayPosition(bool isAlly, short distance)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!isAlly, tryGetCoverCharacter: true);
		int enemyPos = enemyChar.GetDisplayPosition();
		if (enemyPos == int.MinValue)
		{
			enemyPos = enemyChar.GetCurrentPosition();
		}
		return (short)(isAlly ? (enemyPos - distance) : (enemyPos + distance));
	}

	public void SetDisplayPosition(DataContext context, bool isAlly, int displayPos)
	{
		CombatCharacter currChar = GetCombatCharacter(isAlly);
		int mainCharPos = ((displayPos != int.MinValue) ? displayPos : currChar.GetCurrentPosition());
		if (currChar.TeammateBeforeMainChar >= 0)
		{
			CombatCharacter teammateBefore = _combatCharacterDict[currChar.TeammateBeforeMainChar];
			short posOffset = teammateBefore.ExecutingTeammateCommandConfig.PosOffset;
			teammateBefore.SetDisplayPosition(mainCharPos, context);
			mainCharPos = (displayPos = mainCharPos + posOffset * ((!isAlly) ? 1 : (-1)));
		}
		currChar.SetDisplayPosition(displayPos, context);
		if (currChar.TeammateAfterMainChar >= 0)
		{
			CombatCharacter teammateAfter = _combatCharacterDict[currChar.TeammateAfterMainChar];
			short posOffset2 = teammateAfter.ExecutingTeammateCommandConfig.PosOffset;
			teammateAfter.SetDisplayPosition(mainCharPos + posOffset2 * (isAlly ? 1 : (-1)), context);
		}
	}

	public void EnableJumpMove(CombatCharacter character, short skillId)
	{
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		EnableJumpMove(character, skillId, skillConfig.CanPartlyJump, skillConfig.MaxJumpDistance, skillConfig.MaxJumpDistance, skillConfig.JumpPrepareFrame);
	}

	public void EnableJumpMove(CombatCharacter character, short skillId, bool isForward)
	{
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		EnableJumpMove(character, skillId, skillConfig.CanPartlyJump, (short)(isForward ? skillConfig.MaxJumpDistance : 0), (short)((!isForward) ? skillConfig.MaxJumpDistance : 0), skillConfig.JumpPrepareFrame);
	}

	public void EnableJumpMove(CombatCharacter character, short skillId, bool canPartlyJump, short maxForwardDist, short maxBackwardDist, int prepareFrame)
	{
		character.MoveData.JumpMoveSkillId = skillId;
		character.MoveData.CanPartlyJump = canPartlyJump;
		character.MoveData.MaxJumpForwardDist = maxForwardDist;
		character.MoveData.MaxJumpBackwardDist = maxBackwardDist;
		character.MoveData.PrepareProgressUnit = prepareFrame;
		if (skillId >= 0 && Config.CombatSkill.Instance[skillId].EquipType == 2)
		{
			character.PauseJumpMoveSkillId = skillId;
		}
	}

	public void DisableJumpMove(DataContext context, CombatCharacter character, short skillId)
	{
		if (character.MoveData.JumpMoveSkillId == skillId)
		{
			DisableJumpMove(context, character);
		}
	}

	public void DisableJumpMove(DataContext context, CombatCharacter character)
	{
		character.MoveData.JumpMoveSkillId = -1;
		character.MoveData.MaxJumpForwardDist = 0;
		character.MoveData.MaxJumpBackwardDist = 0;
		character.MoveData.PrepareProgressUnit = 0;
		character.MoveData.ResetJumpState(context);
	}

	[DomainMethod]
	public CombatResultDisplayData GetCombatResultDisplayData()
	{
		_combatResultData.SelectAllItem = DomainManager.Taiwu.RequestCombatResultSelectAllItem();
		return _combatResultData;
	}

	[DomainMethod]
	public void SelectGetItem(DataContext context, List<ItemKey> acceptItems, List<int> acceptCounts)
	{
		if (acceptItems != null)
		{
			GameData.Domains.Character.Character charObj = _selfChar.GetCharacter();
			for (int i = 0; i < acceptItems.Count; i++)
			{
				ItemKey key = acceptItems[i];
				if (!_combatResultData.ItemSrcCharDict.ContainsKey(key))
				{
					continue;
				}
				if (_combatResultData.ItemSrcCharDict[key] != _selfChar.GetId())
				{
					GameData.Domains.Character.Character enemyChar = DomainManager.Character.GetElement_Objects(_combatResultData.ItemSrcCharDict[key]);
					int acceptCount = acceptCounts[i];
					int deleteCount = enemyChar.GetInventory().Items[key] - acceptCount;
					DomainManager.Character.TransferInventoryItem(context, enemyChar, charObj, key, acceptCount, EItemAutoOperationSource.Combat);
					if (deleteCount > 0)
					{
						enemyChar.RemoveInventoryItem(context, key, deleteCount, deleteItem: true);
					}
				}
				else
				{
					DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CombatOver", "CarrierItemKeyGotInCombat", key);
				}
				_combatResultData.ItemSrcCharDict.Remove(key);
			}
		}
		foreach (KeyValuePair<ItemKey, int> entry in _combatResultData.ItemSrcCharDict)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(entry.Value);
			character.RemoveInventoryItem(context, entry.Key, character.GetInventory().Items[entry.Key], deleteItem: true);
		}
	}

	public void UpdateMaxSkillGrade(bool isAlly, short skillId)
	{
		if (isAlly)
		{
			SelfMaxSkillGrade = Math.Max(SelfMaxSkillGrade, Config.CombatSkill.Instance[skillId].Grade);
		}
		else
		{
			EnemyMaxSkillGrade = Math.Max(EnemyMaxSkillGrade, Config.CombatSkill.Instance[skillId].Grade);
		}
	}

	public bool IsCharInLoot(int charId)
	{
		return _lootCharList.Contains(charId);
	}

	public void AppendGetChar(int charId)
	{
		_lootCharList.Add(charId);
	}

	public void AppendGetItem(ItemKey itemKey)
	{
		_combatResultData.ItemList.Add(DomainManager.Item.GetItemDisplayData(itemKey, _selfCharId));
		_combatResultData.ItemSrcCharDict.Add(itemKey, _selfCharId);
	}

	public void AppendEvaluation(sbyte evaluationId)
	{
		if (!_combatResultData.EvaluationList.Contains(evaluationId))
		{
			_combatResultData.EvaluationList.Add(evaluationId);
		}
	}

	public bool CheckEvaluation(sbyte evaluationTemplateId)
	{
		CombatEvaluationItem evaluation = CombatEvaluation.Instance[evaluationTemplateId];
		if (evaluation.AvailableInPlayground != _isPlaygroundCombat)
		{
			return false;
		}
		List<short> requireCombatConfigs = evaluation.RequireCombatConfigs;
		if (requireCombatConfigs != null && requireCombatConfigs.Count > 0 && !evaluation.RequireCombatConfigs.Contains(CombatConfig.TemplateId))
		{
			return false;
		}
		if (evaluation.RequireNotBoss && CombatConfig.IsBossCombat)
		{
			return false;
		}
		return evaluation.CombatTypes.Exist(_combatType);
	}

	private void CalcEvaluationList(DataContext context)
	{
		foreach (CombatEvaluationItem evaluation in (IEnumerable<CombatEvaluationItem>)CombatEvaluation.Instance)
		{
			ECombatEvaluationExtraCheck extraCheck = evaluation.ExtraCheck;
			bool flag = (uint)(extraCheck - -1) <= 1u;
			if (flag || (evaluation.NeedWin && !IsWin(isAlly: true)) || !CheckEvaluation(evaluation.TemplateId))
			{
				continue;
			}
			if (evaluation.ExtraCheck != ECombatEvaluationExtraCheck.None)
			{
				if (!EvaluationCheckers.TryGetValue(evaluation.ExtraCheck, out var checker))
				{
					PredefinedLog.Show(8, $"Unexpect checker type {evaluation.ExtraCheck}, evaluation will always be true.");
				}
				else if (!checker())
				{
					continue;
				}
			}
			AppendEvaluation(evaluation.TemplateId);
		}
		_combatResultData.EvaluationList.Sort();
	}

	private void CalcReadInCombat(DataContext context)
	{
		_combatResultData.ShowReadingEvent = false;
		sbyte readInCombatCount = DomainManager.Taiwu.GetReadInCombatCount();
		ItemKey currBook = DomainManager.Taiwu.GetCurReadingBook();
		if (readInCombatCount <= 0 || !currBook.IsValid() || Config.SkillBook.Instance[currBook.TemplateId].CombatSkillTemplateId < 0)
		{
			return;
		}
		int odds = _combatResultData.SelectEvaluations((CombatEvaluationItem x) => x.ReadInCombatRate).Sum((int x) => x);
		if (context.Random.CheckPercentProb(odds))
		{
			DomainManager.Taiwu.SetReadInCombatCount((sbyte)(readInCombatCount - 1), context);
			_combatResultData.EvaluationList.Add(33);
			_combatResultData.ShowReadingEvent = DomainManager.Taiwu.UpdateReadingProgressInCombat(context);
			if (_combatResultData.ShowReadingEvent)
			{
				DomainManager.Extra.AddReadingEventBookId(context, currBook.Id);
			}
		}
	}

	private void CalcQiQrtInCombat(DataContext context)
	{
		sbyte loopInCombatCount = DomainManager.Extra.GetLoopInCombatCount();
		_combatResultData.ShowLoopingEvent = false;
		if (loopInCombatCount <= 0)
		{
			return;
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		short loopingNeigongTemplateId = taiwuChar.GetLoopingNeigong();
		if (loopingNeigongTemplateId >= 0)
		{
			int percentProb = _combatResultData.SelectEvaluations((CombatEvaluationItem x) => x.QiArtCombatRate).Sum((int x) => x);
			if (context.Random.CheckPercentProb(percentProb))
			{
				DomainManager.Extra.SetLoopInCombatCount((sbyte)(loopInCombatCount - 1), context);
				DomainManager.Taiwu.ApplyNeigongLoopingImprovementOnce(context);
				_combatResultData.EvaluationList.Add(43);
				InstantNotificationCollection instantCollection = DomainManager.World.GetInstantNotificationCollection();
				instantCollection.AddQiArtInCombatNoChance(loopingNeigongTemplateId);
				_combatResultData.ShowLoopingEvent = DomainManager.Taiwu.TryAddLoopingEvent(context, percentProb);
			}
		}
	}

	private void CalcAddLegacyPoint(DataContext context)
	{
		bool win = CombatResultType.IsPlayerWin(_combatResultData.CombatStatus);
		Dictionary<short, int> legacyPoints = ObjectPool<Dictionary<short, int>>.Instance.Get();
		legacyPoints.Clear();
		foreach (CombatEvaluationItem evaluation in _combatResultData.Evaluations)
		{
			foreach (LegacyPointReference reference in evaluation.AddLegacyPoint)
			{
				int percent = (win ? reference.WinPercent : reference.FailPercent);
				legacyPoints[reference.TemplateId] = legacyPoints.GetOrDefault(reference.TemplateId) + percent;
			}
		}
		foreach (var (templateId, percent2) in legacyPoints)
		{
			if (percent2 > 0)
			{
				DomainManager.Taiwu.AddLegacyPoint(context, templateId, percent2);
			}
		}
		ObjectPool<Dictionary<short, int>>.Instance.Return(legacyPoints);
	}

	private void CalcAndAddFameAction(DataContext context)
	{
		GameData.Domains.Character.Character charObj = _selfChar.GetCharacter();
		foreach (short fameAction in from x in _combatResultData.SelectEvaluations((CombatEvaluationItem x) => x.FameAction)
			where x >= 0
			select x)
		{
			charObj.RecordFameAction(context, fameAction, -1, 1);
		}
	}

	private void CalcAndAddAreaSpiritualDebt(DataContext context)
	{
		int areaSpiritualDebt = 0;
		areaSpiritualDebt += _combatResultData.SelectEvaluations((CombatEvaluationItem x) => x.AreaSpiritualDebt).Sum((short x) => x);
		if (IsWin(isAlly: true))
		{
			areaSpiritualDebt += GetAddAreaSpiritualDebt(_enemyTeam);
		}
		_combatResultData.AreaSpiritualDebt = areaSpiritualDebt;
		if (areaSpiritualDebt != 0)
		{
			Location location = _selfChar.GetCharacter().GetLocation();
			if (!location.IsValid())
			{
				location = _selfChar.GetCharacter().GetValidLocation();
			}
			MapAreaData area = DomainManager.Map.GetElement_Areas(location.AreaId);
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, _combatResultData.AreaSpiritualDebt);
		}
	}

	private void CalcAndAddExp(DataContext context)
	{
		if (!CombatConfig.DropResource || _isPlaygroundCombat)
		{
			return;
		}
		int exp = CalcAddBase(_enemyTeam, GlobalConfig.Instance.CombatGetExpBase);
		GameData.Domains.Character.Character selfChar = _selfChar.GetCharacter();
		sbyte consummateLevel = selfChar.GetEffectiveConsummateLevel();
		int extraAddPercent = ConsummateLevel.Instance[consummateLevel].ExpBonus;
		exp = _combatResultData.ModifyValue(exp, (CombatEvaluationItem x) => x.ExpAddPercent, (CombatEvaluationItem x) => x.ExpTotalPercent, extraAddPercent);
		exp = Math.Max(exp, 0);
		_combatResultData.Exp = exp;
		DomainManager.Taiwu.GetTaiwu().ChangeExp(context, _combatResultData.Exp);
		if (!IsWin(isAlly: true))
		{
			return;
		}
		bool consummateLevelLessOrEqual = consummateLevel <= _enemyChar.GetCharacter().GetConsummateLevel();
		bool enemyIsIntelligent = _enemyChar.GetCharacter().GetCreatingType() == 1;
		sbyte enemyOrganization = _enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId;
		foreach (ExpAddProfessionSeniorityData data in ExpAddProfessionSeniorityData.AllData)
		{
			if ((!data.RequireConsummateLevel || consummateLevelLessOrEqual) && (data.RequireCombatType < 0 || data.RequireCombatType == _combatType) && (!data.RequireIntelligent || enemyIsIntelligent) && (data.RequireOrganization < 0 || data.RequireOrganization == enemyOrganization))
			{
				Func<bool> extraChecker = data.ExtraChecker;
				if (extraChecker == null || extraChecker())
				{
					data.DoAddSeniority(context, exp);
				}
			}
		}
	}

	private void CalcAndAddResource(DataContext context)
	{
		if (!CombatConfig.DropResource || _isPlaygroundCombat)
		{
			return;
		}
		for (sbyte i = 0; i < 8; i++)
		{
			int value = CalcAddResource(_enemyTeam, i);
			if (i == 7)
			{
				value += CalcAddBase(_enemyTeam, GlobalConfig.Instance.CombatGetAuthorityBase);
			}
			value = value * DomainManager.World.GetGainResourcePercent(12) / 100;
			if (i == 7)
			{
				value = _combatResultData.ModifyValue(value, (CombatEvaluationItem x) => x.AuthorityAddPercent, (CombatEvaluationItem x) => x.AuthorityTotalPercent);
			}
			else if (!_combatResultData.IsWin)
			{
				value = 0;
			}
			value = Math.Max(value, 0);
			_combatResultData.Resource[i] = value;
			_selfChar.GetCharacter().ChangeResource(context, i, value);
		}
	}

	private void CalcAndAddProficiency(DataContext context)
	{
		if (!CombatConfig.DropResource || _isPlaygroundCombat || _combatResultData.Evaluations.Any((CombatEvaluationItem evaluation) => !evaluation.AllowProficiency))
		{
			return;
		}
		foreach (short skillId in _selfChar.GetCombatSkillIds())
		{
			CombatSkillKey key = new CombatSkillKey(_selfChar.GetId(), skillId);
			int deltaTarget = CalcProficiencyDeltaTarget(context.Random, key);
			int delta = DomainManager.Extra.ChangeCombatSkillProficiency(context, key, deltaTarget);
			if (delta != 0)
			{
				CombatResultDisplayData combatResultData = _combatResultData;
				if (combatResultData.ChangedProficiencies == null)
				{
					combatResultData.ChangedProficiencies = new Dictionary<short, int>();
				}
				_combatResultData.ChangedProficiencies[skillId] = DomainManager.Extra.GetElement_CombatSkillProficiencies(key);
				combatResultData = _combatResultData;
				if (combatResultData.ChangedProficienciesDelta == null)
				{
					combatResultData.ChangedProficienciesDelta = new Dictionary<short, int>();
				}
				_combatResultData.ChangedProficienciesDelta[skillId] = delta;
			}
		}
		if (_enemyChar.GetCharacter().GetCreatingType() != 1)
		{
			return;
		}
		foreach (short skillId2 in _enemyChar.GetCombatSkillIds())
		{
			CombatSkillKey key2 = new CombatSkillKey(_enemyChar.GetId(), skillId2);
			int deltaTarget2 = CalcProficiencyDeltaTarget(context.Random, key2);
			DomainManager.Extra.ChangeCombatSkillProficiency(context, key2, deltaTarget2);
		}
	}

	private int CalcProficiencyDeltaTarget(IRandomSource random, CombatSkillKey key)
	{
		sbyte equipType = Config.CombatSkill.Instance[key.SkillTemplateId].EquipType;
		if (GameData.Domains.Character.CombatSkillHelper.IsProactiveSkill(equipType))
		{
			return _skillCastTimes.GetOrDefault(key) * GlobalConfig.ProactiveProficiencyFactor[_combatType];
		}
		int rangeMin = 1;
		int rangeMax = 3;
		return random.Next(rangeMin, rangeMax + 1);
	}

	private void CalcAndAddCompatibility(DataContext context)
	{
		if (!CombatConfig.DropResource || _isPlaygroundCombat || _combatResultData.Evaluations.Any((CombatEvaluationItem evaluation) => !evaluation.AllowProficiency))
		{
			return;
		}
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			combatChar.GetCharacter().AddMysteryCompatibility(context);
		}
	}

	public static short GetWorldLootRatePercent()
	{
		short lootYield = DomainManager.World.GetLootYield();
		WorldCreationItem worldCreationItem = WorldCreation.Instance[(byte)14];
		return worldCreationItem.InfluenceFactors[lootYield];
	}

	private unsafe void CalcLootItem(DataContext context)
	{
		int combatOdds = CombatConfig.LootItemRate;
		combatOdds = combatOdds * GetWorldLootRatePercent() / 100;
		sbyte combatType = _combatType;
		bool flag = ((combatType == 0 || combatType == 3) ? true : false);
		if (flag || !CombatConfig.AllowDropItem || _combatStatus != 3 || (combatOdds <= 0 && !CombatConfig.LootAllInventory) || _isPuppetCombat)
		{
			return;
		}
		GameData.Domains.Character.Character charObj = _selfChar.GetCharacter();
		if (!CombatConfig.LootAllInventory)
		{
			ItemKey[] equips = charObj.GetEquipment();
			Personalities personalities = charObj.GetPersonalities();
			int equipOdds = 100 + personalities.Items[5];
			ItemKey[] subArray = equips[11..13];
			for (int i = 0; i < subArray.Length; i++)
			{
				ItemKey carrierKey = subArray[i];
				if (carrierKey.IsValid())
				{
					equipOdds += DomainManager.Item.GetElement_Carriers(carrierKey.Id).GetDropRateBonus();
				}
			}
			sbyte[] accessoryDropRateBonusSlot = AccessoryDropRateBonusSlot;
			foreach (sbyte slot in accessoryDropRateBonusSlot)
			{
				ItemKey accessoryKey = equips[slot];
				if (accessoryKey.IsValid())
				{
					equipOdds += Config.Accessory.Instance[accessoryKey.TemplateId].DropRateBonus;
				}
			}
			List<ItemKey> dropItemRandomPool = ObjectPool<List<ItemKey>>.Instance.Get();
			List<int> dropItemCount = ObjectPool<List<int>>.Instance.Get();
			for (int k = 0; k < _enemyTeam.Length; k++)
			{
				int enemyId = _enemyTeam[k];
				if (enemyId < 0 || _lootCharList.Contains(enemyId))
				{
					continue;
				}
				GameData.Domains.Character.Character enemyChar = _combatCharacterDict[enemyId].GetCharacter();
				int charOdds = ((k == 0) ? enemyChar.Template.DropRatePercentAsMainChar : enemyChar.Template.DropRatePercentAsTeammate);
				ItemKey[] enemyEquips = enemyChar.GetEquipment();
				Inventory enemyInventory = enemyChar.GetInventory();
				dropItemRandomPool.Clear();
				dropItemCount.Clear();
				for (sbyte slot2 = 0; slot2 < 17; slot2++)
				{
					if (slot2 != 4)
					{
						ItemKey equipKey = enemyEquips[slot2];
						if (equipKey.IsValid() && ItemTemplateHelper.IsTransferable(equipKey.ItemType, equipKey.TemplateId))
						{
							int dropRate = ItemTemplateHelper.GetDropRate(equipKey.ItemType, equipKey.TemplateId) * equipOdds / 100 * combatOdds / 100 * charOdds / 100;
							if (context.Random.CheckPercentProb(dropRate))
							{
								dropItemRandomPool.Add(equipKey);
								dropItemCount.Add(1);
							}
						}
					}
				}
				foreach (KeyValuePair<ItemKey, int> itemEntry in enemyInventory.Items)
				{
					ItemKey key = itemEntry.Key;
					if (ItemTemplateHelper.IsTransferable(key.ItemType, key.TemplateId))
					{
						int dropRate2 = ItemTemplateHelper.GetDropRate(key.ItemType, key.TemplateId) * equipOdds / 100 * combatOdds / 100 * charOdds / 100;
						if (context.Random.CheckPercentProb(dropRate2))
						{
							dropItemRandomPool.Add(key);
							dropItemCount.Add(itemEntry.Value);
						}
					}
				}
				int randomCount = Math.Min(dropItemRandomPool.Count, (k != 0) ? 1 : 3);
				for (int l = 0; l < randomCount; l++)
				{
					if (context.Random.CheckPercentProb(100 - 20 * l))
					{
						int index = context.Random.Next(dropItemRandomPool.Count);
						ItemKey key2 = dropItemRandomPool[index];
						int count = dropItemCount[index];
						sbyte slotIndex = (sbyte)enemyEquips.IndexOf(key2);
						dropItemRandomPool.RemoveAt(index);
						dropItemCount.RemoveAt(index);
						if (slotIndex >= 0)
						{
							enemyChar.ChangeEquipment(context, slotIndex, -1, ItemKey.Invalid);
						}
						int existItemIndex = _combatResultData.ItemList.FindIndex((ItemDisplayData data) => data.Key.Equals(key2));
						if (existItemIndex < 0)
						{
							ItemDisplayData itemData = DomainManager.Item.GetItemDisplayData(key2, _selfCharId);
							itemData.Amount = count;
							_combatResultData.ItemList.Add(itemData);
							_combatResultData.ItemSrcCharDict[key2] = enemyChar.GetId();
						}
						else
						{
							_combatResultData.ItemList[existItemIndex].Amount += count;
							DomainManager.Character.TransferInventoryItem(context, enemyChar, DomainManager.Character.GetElement_Objects(_combatResultData.ItemSrcCharDict[key2]), key2, count);
						}
					}
				}
			}
			ObjectPool<List<ItemKey>>.Instance.Return(dropItemRandomPool);
			ObjectPool<List<int>>.Instance.Return(dropItemCount);
			return;
		}
		GameData.Domains.Character.Character enemyChar2 = _combatCharacterDict[_enemyTeam[0]].GetCharacter();
		Inventory enemyInventory2 = enemyChar2.GetInventory();
		foreach (KeyValuePair<ItemKey, int> itemEntry2 in enemyInventory2.Items)
		{
			ItemKey key3 = itemEntry2.Key;
			int existItemIndex2 = _combatResultData.ItemList.FindIndex((ItemDisplayData data) => data.Key.Equals(key3));
			if (existItemIndex2 < 0)
			{
				ItemDisplayData itemData2 = DomainManager.Item.GetItemDisplayData(key3, _selfCharId);
				itemData2.Amount = itemEntry2.Value;
				_combatResultData.ItemList.Add(itemData2);
				_combatResultData.ItemSrcCharDict[key3] = enemyChar2.GetId();
			}
			else
			{
				_combatResultData.ItemList[existItemIndex2].Amount += itemEntry2.Value;
				DomainManager.Character.TransferInventoryItem(context, enemyChar2, DomainManager.Character.GetElement_Objects(_combatResultData.ItemSrcCharDict[key3]), key3, itemEntry2.Value);
			}
		}
	}

	private void GetLootCharDisplayData()
	{
		_combatResultData.CharList = DomainManager.Character.GetCharacterDisplayDataList(_lootCharList);
	}

	private void CalcSnapshotAfterCombat(DataContext context)
	{
		_combatResultData.SnapshotAfterCombat = CombatResultHelper.CreateSnapshot();
	}

	private static int SumAddValue(IEnumerable<int> addValues)
	{
		int sum = 0;
		bool first = true;
		foreach (int addValue in addValues)
		{
			int value = addValue;
			if (first)
			{
				first = false;
			}
			else
			{
				value = value * GlobalConfig.Instance.CombatGetNonMainPercent / 100;
			}
			sum += value;
		}
		return sum;
	}

	public static int CalcAddBase(IEnumerable<int> charIds, IReadOnlyList<short> baseValues, bool useTemplate = false)
	{
		return SumAddValue(charIds.Select((int charId) => CalcAddBase(charId, baseValues, useTemplate)));
	}

	private static int CalcAddBase(int charId, IReadOnlyList<short> baseValues, bool useTemplate)
	{
		if (charId < 0)
		{
			return 0;
		}
		int index;
		if (useTemplate)
		{
			CharacterItem characterCfg = Config.Character.Instance[charId];
			if (characterCfg.RandomEnemyId < 0)
			{
				return 0;
			}
			index = Config.Character.Instance[charId].ConsummateLevel;
		}
		else
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			index = character.GetConsummateLevel();
		}
		index = Math.Clamp(index, 0, baseValues.Count - 1);
		return baseValues[index];
	}

	private static int CalcAddResource(IEnumerable<int> charIds, sbyte resourceType, bool useTemplate = false)
	{
		return SumAddValue(charIds.Select((int charId) => CalcAddResource(charId, resourceType, useTemplate)));
	}

	private static int CalcAddResource(int charId, sbyte resourceType, bool useTemplate)
	{
		if (charId < 0)
		{
			return 0;
		}
		if (useTemplate)
		{
			return Config.Character.Instance[charId].DropResources[resourceType];
		}
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		CharacterItem characterCfg = Config.Character.Instance[character.GetTemplateId()];
		if (characterCfg.CreatingType != 1)
		{
			return characterCfg.DropResources[resourceType];
		}
		return OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo()).DropResources[resourceType];
	}

	public void WipeOut(DataContext context, List<short> enemyList)
	{
		(WipeOutType, short) wipeOutType = GetWipeOutType(enemyList);
		WipeOutType type = wipeOutType.Item1;
		short enemyId = wipeOutType.Item2;
		InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotifications();
		switch (type)
		{
		case WipeOutType.Heretic:
			instantNotifications.AddExpelEnemy(enemyId);
			break;
		case WipeOutType.Righteous:
			instantNotifications.AddExpelRighteous(enemyId);
			DomainManager.Taiwu.GetTaiwu().RecordFameAction(context, 60, -1, 1);
			instantNotifications.AddFameDecreased(DomainManager.Taiwu.GetTaiwuCharId());
			break;
		case WipeOutType.Xiangshu:
			instantNotifications.AddExpelXiangshuMinion(enemyId);
			break;
		case WipeOutType.Beast:
			instantNotifications.AddExpelBeast(enemyId);
			break;
		}
		GetExpAndAuthorityAndAreaSpiritualDebtOutOfCombat(context, enemyList);
	}

	public bool CanWipeOut(short templateId)
	{
		if (templateId < 0)
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (TryGetWipeOutType(templateId, out var type))
		{
			if (type == WipeOutType.Righteous && taiwu.GetFameType() > 1)
			{
				return false;
			}
			if (type == WipeOutType.Beast && DomainManager.Extra.TryGetAnimalIdsByLocation(taiwu.GetLocation(), out var animalIds))
			{
				foreach (int animalId in animalIds)
				{
					if (DomainManager.Extra.TryGetAnimal(animalId, out var animal) && animal.CharacterTemplateId == templateId && animal.ItemKey.IsValid())
					{
						return false;
					}
				}
			}
		}
		return taiwu.GetConsummateLevel() >= Config.Character.Instance[templateId].ConsummateLevel + GlobalConfig.Instance.RandomEnemyEscapeConsummateLevelGap;
	}

	public bool TryGetWipeOutType(short templateId, out WipeOutType type)
	{
		type = WipeOutType.Invalid;
		if (templateId < 0)
		{
			return false;
		}
		switch (Config.Character.Instance[templateId].OrganizationInfo.OrgTemplateId)
		{
		case 17:
			type = WipeOutType.Heretic;
			return true;
		case 18:
			type = WipeOutType.Righteous;
			return true;
		case 19:
			type = WipeOutType.Xiangshu;
			return true;
		case 40:
			type = WipeOutType.Beast;
			return true;
		default:
			return false;
		}
	}

	private (WipeOutType, short) GetWipeOutType(List<short> enemyList)
	{
		foreach (short templateId in enemyList)
		{
			if (TryGetWipeOutType(templateId, out var type))
			{
				return (type, templateId);
			}
		}
		return (WipeOutType.Invalid, -1);
	}

	private int GetAddExp(int[] enemyList)
	{
		int exp = 0;
		foreach (int charId in enemyList)
		{
			if (charId >= 0)
			{
				int expIndex = Math.Clamp(DomainManager.Character.GetElement_Objects(charId).GetConsummateLevel(), 0, GlobalConfig.Instance.CombatGetExpBase.Length - 1);
				exp += GlobalConfig.Instance.CombatGetExpBase[expIndex];
			}
		}
		return exp;
	}

	private int GetAddExp(List<short> enemyList)
	{
		int exp = 0;
		for (int i = 0; i < enemyList.Count; i++)
		{
			int charTemplateId = enemyList[i];
			if (charTemplateId >= 0)
			{
				CharacterItem characterCfg = Config.Character.Instance[charTemplateId];
				short randomEnemyId = characterCfg.RandomEnemyId;
				if (randomEnemyId >= 0)
				{
					int expIndex = Math.Clamp(characterCfg.ConsummateLevel, 0, GlobalConfig.Instance.CombatGetExpBase.Length - 1);
					exp += GlobalConfig.Instance.CombatGetExpBase[expIndex];
				}
			}
		}
		return exp;
	}

	private int GetAddAuthority(int[] enemyList)
	{
		int authority = 0;
		foreach (int charId in enemyList)
		{
			if (charId >= 0)
			{
				int authorityIndex = Math.Clamp(DomainManager.Character.GetElement_Objects(charId).GetConsummateLevel(), 0, GlobalConfig.Instance.CombatGetAuthorityBase.Length - 1);
				authority += GlobalConfig.Instance.CombatGetAuthorityBase[authorityIndex];
			}
		}
		return authority;
	}

	private int GetAddAuthority(List<short> enemyList)
	{
		int authority = 0;
		for (int i = 0; i < enemyList.Count; i++)
		{
			int charTemplateId = enemyList[i];
			if (charTemplateId >= 0)
			{
				CharacterItem characterCfg = Config.Character.Instance[charTemplateId];
				short randomEnemyId = characterCfg.RandomEnemyId;
				if (randomEnemyId >= 0)
				{
					int authorityIndex = Math.Clamp(characterCfg.ConsummateLevel, 0, GlobalConfig.Instance.CombatGetAuthorityBase.Length - 1);
					authority += GlobalConfig.Instance.CombatGetAuthorityBase[authorityIndex];
				}
			}
		}
		return authority;
	}

	private int GetAddAreaSpiritualDebt(int[] enemyList)
	{
		int areaSpiritualDebt = 0;
		foreach (int charId in enemyList)
		{
			if (charId >= 0 && !IsGuardChar(_combatCharacterDict[charId]))
			{
				short randomEnemyId = Config.Character.Instance[DomainManager.Character.GetElement_Objects(charId).GetTemplateId()].RandomEnemyId;
				if (randomEnemyId >= 0)
				{
					areaSpiritualDebt += RandomEnemy.Instance[randomEnemyId].SpiritualDebt;
				}
			}
		}
		return areaSpiritualDebt;
	}

	private int GetAddAreaSpiritualDebt(List<short> enemyList)
	{
		int areaSpiritualDebt = 0;
		for (int i = 0; i < enemyList.Count; i++)
		{
			int charTemplateId = enemyList[i];
			if (charTemplateId >= 0)
			{
				short randomEnemyId = Config.Character.Instance[charTemplateId].RandomEnemyId;
				if (randomEnemyId >= 0)
				{
					areaSpiritualDebt += RandomEnemy.Instance[randomEnemyId].SpiritualDebt;
				}
			}
		}
		return areaSpiritualDebt;
	}

	public void GetExpAndAuthorityAndAreaSpiritualDebtOutOfCombat(DataContext context, List<int> enemyIdList)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwuChar.GetLocation();
		if (!location.IsValid())
		{
			location = taiwuChar.GetValidLocation();
		}
		short areaId = location.AreaId;
		int[] enemyList = enemyIdList.ToArray();
		taiwuChar.ChangeExp(context, GetAddExp(enemyList));
		taiwuChar.ChangeResource(context, 7, GetAddAuthority(enemyList));
		DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, GetAddAreaSpiritualDebt(enemyList));
	}

	public int GetExpAndAuthorityAndAreaSpiritualDebtOutOfCombat(DataContext context, List<short> enemyTemplateIdList, int rewardTimes = 1)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwuChar.GetLocation();
		if (!location.IsValid())
		{
			location = taiwuChar.GetValidLocation();
		}
		short areaId = location.AreaId;
		int expAdd = GetAddExp(enemyTemplateIdList) * rewardTimes;
		int resourceAdd = GetAddAuthority(enemyTemplateIdList) * rewardTimes;
		int spiritualDebtDelta = GetAddAreaSpiritualDebt(enemyTemplateIdList) * rewardTimes;
		InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotifications();
		taiwuChar.ChangeExp(context, expAdd);
		taiwuChar.ChangeResource(context, 7, resourceAdd);
		DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, spiritualDebtDelta, getProfessionSeniority: true, addInstantNotification: false);
		if (expAdd > 0)
		{
			instantNotifications.AddExpIncreased(taiwuChar.GetId(), expAdd);
		}
		if (resourceAdd > 0)
		{
			instantNotifications.AddResourceIncreased(taiwuChar.GetId(), 7, resourceAdd);
		}
		if (spiritualDebtDelta > 0)
		{
			instantNotifications.AddGraceUp(new Location(areaId, -1), spiritualDebtDelta);
		}
		else if (spiritualDebtDelta < 0)
		{
			instantNotifications.AddGraceDown(new Location(areaId, -1), -spiritualDebtDelta);
		}
		return expAdd;
	}

	public int GetAreaSpiritualDebtByJixi(DataContext context, List<short> enemyTemplateIdList, Location location, GameData.Domains.Character.Character character, bool addInstantNotification = false, int rewardTimes = 1)
	{
		if (!location.IsValid())
		{
			location = character.GetValidLocation();
		}
		short areaId = location.AreaId;
		int spiritualDebtDelta = GetAddAreaSpiritualDebt(enemyTemplateIdList) * rewardTimes;
		InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotifications();
		DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, spiritualDebtDelta, getProfessionSeniority: true, addInstantNotification: false);
		if (addInstantNotification && spiritualDebtDelta > 0)
		{
			instantNotifications.AddJixiKillTemplateEnemy(new Location(areaId, -1), spiritualDebtDelta);
		}
		return spiritualDebtDelta;
	}

	private static bool FailChecker()
	{
		return DomainManager.Combat.GetCombatStatus() == 2;
	}

	private static bool DrawChecker()
	{
		return false;
	}

	private static bool FleeChecker()
	{
		return DomainManager.Combat.GetCombatStatus() == 4;
	}

	private static bool WinChecker()
	{
		return DomainManager.Combat.IsWin(isAlly: true);
	}

	private static bool FightSameLevelChecker()
	{
		CombatDomain domain = DomainManager.Combat;
		return domain._selfChar.GetCharacter().GetConsummateLevel() <= domain._enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool FightLessLevelChecker()
	{
		CombatDomain domain = DomainManager.Combat;
		return domain._selfChar.GetCharacter().GetConsummateLevel() > domain._enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool BeatXiangShuChecker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: false).BossConfig?.TemplateId < 9 && DomainManager.Combat.CombatConfig.Scene >= 0 && !DomainManager.Combat._isPuppetCombat;
	}

	private static bool WinLessChecker()
	{
		int[] selfTeam = DomainManager.Combat.GetCharacterList(isAlly: true);
		int[] enemyTeam = DomainManager.Combat.GetCharacterList(isAlly: false);
		return selfTeam.FindAll((int id) => id >= 0).Count > enemyTeam.FindAll((int id) => id >= 0).Count;
	}

	private static bool WinMoreChecker()
	{
		int[] selfTeam = DomainManager.Combat.GetCharacterList(isAlly: true);
		int[] enemyTeam = DomainManager.Combat.GetCharacterList(isAlly: false);
		return selfTeam.FindAll((int id) => id >= 0).Count < enemyTeam.FindAll((int id) => id >= 0).Count;
	}

	private static bool WinChildChecker()
	{
		short selfAge = DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetCurrAge();
		short enemyAge = DomainManager.Combat.GetMainCharacter(isAlly: false).GetCharacter().GetCurrAge();
		return enemyAge < 16 && selfAge > enemyAge;
	}

	private static bool WinOlderChecker()
	{
		short selfAge = DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetCurrAge();
		short enemyAge = DomainManager.Combat.GetMainCharacter(isAlly: false).GetCharacter().GetCurrAge();
		return selfAge < 16 && selfAge < enemyAge;
	}

	private static bool WinWorseEquipChecker()
	{
		return DomainManager.Combat.SelfAvgEquipGrade - DomainManager.Combat.EnemyAvgEquipGrade >= 3f;
	}

	private static bool WinBetterEquipChecker()
	{
		return DomainManager.Combat.EnemyAvgEquipGrade - DomainManager.Combat.SelfAvgEquipGrade >= 3f;
	}

	private static bool WinLessNeiliChecker()
	{
		int selfNeiliAllocation = DomainManager.Combat.GetMaxOriginNeiliAllocationSum(isAlly: true);
		int enemyNeiliAllocation = DomainManager.Combat.GetMaxOriginNeiliAllocationSum(isAlly: false);
		return selfNeiliAllocation >= enemyNeiliAllocation * WinNeiliMinDelta;
	}

	private static bool WinMoreNeiliChecker()
	{
		int selfNeiliAllocation = DomainManager.Combat.GetMaxOriginNeiliAllocationSum(isAlly: true);
		int enemyNeiliAllocation = DomainManager.Combat.GetMaxOriginNeiliAllocationSum(isAlly: false);
		return enemyNeiliAllocation >= selfNeiliAllocation * WinNeiliMinDelta;
	}

	private static bool WinWorseSkillChecker()
	{
		return DomainManager.Combat.SelfMaxSkillGrade > DomainManager.Combat.EnemyMaxSkillGrade;
	}

	private static bool WinBetterSkillChecker()
	{
		return DomainManager.Combat.SelfMaxSkillGrade < DomainManager.Combat.EnemyMaxSkillGrade;
	}

	private static bool WinLessConsummateChecker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetConsummateLevel() - DomainManager.Combat.GetMainCharacter(isAlly: false).GetCharacter().GetConsummateLevel() >= 3;
	}

	private static bool WinMoreConsummateChecker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: false).GetCharacter().GetConsummateLevel() - DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetConsummateLevel() >= 3;
	}

	private static bool WinPregnantChecker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: false).GetCharacter().GetFeatureIds()
			.Contains(198);
	}

	private static bool WinInPregnantChecker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetFeatureIds()
			.Contains(198);
	}

	private static bool KillBad0Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 17 && selfChar.GetCharacter().GetConsummateLevel() > enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool KillBad1Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 17 && selfChar.GetCharacter().GetConsummateLevel() <= enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool KillGood0Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 18 && selfChar.GetCharacter().GetConsummateLevel() > enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool KillGood1Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 18 && selfChar.GetCharacter().GetConsummateLevel() <= enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool KillMinion0Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 19 && selfChar.GetCharacter().GetConsummateLevel() > enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool KillMinion1Checker()
	{
		CombatCharacter selfChar = DomainManager.Combat.GetMainCharacter(isAlly: true);
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(isAlly: false);
		return !DomainManager.Combat.IsGuardChar(enemyChar) && enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId == 19 && selfChar.GetCharacter().GetConsummateLevel() <= enemyChar.GetCharacter().GetConsummateLevel();
	}

	private static bool ShixiangBuff0Checker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetFeatureIds()
			.Contains(374);
	}

	private static bool ShixiangBuff1Checker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetFeatureIds()
			.Contains(375);
	}

	private static bool ShixiangBuff2Checker()
	{
		return DomainManager.Combat.GetMainCharacter(isAlly: true).GetCharacter().GetFeatureIds()
			.Contains(376);
	}

	private static bool PuppetCombatChecker()
	{
		return DomainManager.Combat._isPuppetCombat;
	}

	private static bool OutBossCombatChecker()
	{
		return DomainManager.Combat.CombatConfig.IsOutBoss;
	}

	private static bool WinLoongChecker()
	{
		short templateId = DomainManager.Combat.CombatConfig.TemplateId;
		if ((uint)(templateId - 182) <= 4u)
		{
			return true;
		}
		return false;
	}

	private static bool CombatHardChecker()
	{
		return DomainManager.World.GetCombatDifficulty() == 2;
	}

	private static bool CombatVeryHardChecker()
	{
		return DomainManager.World.GetCombatDifficulty() == 3;
	}

	public void AddCombatResultLegacy(short legacy)
	{
		CombatResultDisplayData combatResultData = _combatResultData;
		if (combatResultData.LegacyTemplateIds == null)
		{
			combatResultData.LegacyTemplateIds = new List<short>();
		}
		_combatResultData.LegacyTemplateIds.Add(legacy);
	}

	private void ClearCombatResultLegacies()
	{
		_combatResultData.LegacyTemplateIds?.Clear();
	}

	[DomainMethod]
	public void ApplyCombatResultDataEffect(DataContext context, CombatResultDisplayData combatResultData, List<ItemDisplayData> selectedLootItem)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.ChangeExp(context, combatResultData.Exp);
		for (sbyte i = 0; i < 8; i++)
		{
			taiwu.ChangeResource(context, i, combatResultData.Resource.Get(i));
		}
		int areaSpiritualDebt = combatResultData.AreaSpiritualDebt;
		if (areaSpiritualDebt != 0)
		{
			Location location = taiwu.GetLocation();
			if (!location.IsValid())
			{
				location = taiwu.GetValidLocation();
			}
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, areaSpiritualDebt);
		}
		ItemDomain itemDomain = DomainManager.Item;
		HashSet<ItemDisplayData> selected = new HashSet<ItemDisplayData>();
		if (selectedLootItem != null)
		{
			selected.UnionWith(selectedLootItem);
		}
		foreach (ItemDisplayData item in combatResultData.ItemList)
		{
			if (selected.Any((ItemDisplayData selectedItem) => selectedItem.ContainsItemKey(item.Key)))
			{
				taiwu.AddInventoryItem(context, item.Key, item.Amount);
			}
			else
			{
				itemDomain.RemoveItem(context, item.Key);
			}
		}
	}

	internal static void ResultCalcExp(CombatConfigItem combatConfig, bool isPlaygroundCombat, GameData.Domains.Character.Character selfChar, ICollection<int> enemyTeam, CombatResultDisplayData combatResultData)
	{
		if (!(!combatConfig.DropResource || isPlaygroundCombat))
		{
			int exp = CalcAddBase(enemyTeam, GlobalConfig.Instance.CombatGetExpBase);
			sbyte consummateLevel = selfChar.GetEffectiveConsummateLevel();
			int extraAddPercent = ConsummateLevel.Instance[consummateLevel].ExpBonus;
			exp = combatResultData.ModifyValue(exp, (CombatEvaluationItem x) => x.ExpAddPercent, (CombatEvaluationItem x) => x.ExpTotalPercent, extraAddPercent);
			exp = Math.Max(exp, 0);
			combatResultData.Exp += exp;
		}
	}

	internal static void ResultCalcResource(CombatConfigItem combatConfig, bool isPlaygroundCombat, GameData.Domains.Character.Character selfChar, ICollection<int> enemyTeam, CombatResultDisplayData combatResultData)
	{
		if (!combatConfig.DropResource || isPlaygroundCombat)
		{
			return;
		}
		for (sbyte i = 0; i < 8; i++)
		{
			int value = CalcAddResource(enemyTeam, i);
			if (i == 7)
			{
				value += CalcAddBase(enemyTeam, GlobalConfig.Instance.CombatGetAuthorityBase);
			}
			value = value * DomainManager.World.GetGainResourcePercent(12) / 100;
			if (i == 7)
			{
				value = combatResultData.ModifyValue(value, (CombatEvaluationItem x) => x.AuthorityAddPercent, (CombatEvaluationItem x) => x.AuthorityTotalPercent);
			}
			else if (!combatResultData.IsWin)
			{
				value = 0;
			}
			value = Math.Max(value, 0);
			combatResultData.Resource[i] += value;
		}
	}

	internal static void ResultCalcAreaSpiritualDebt(bool isWin, GameData.Domains.Character.Character selfChar, int[] enemyTeam, CombatResultDisplayData combatResultData)
	{
		int areaSpiritualDebt = 0;
		areaSpiritualDebt += combatResultData.SelectEvaluations((CombatEvaluationItem x) => x.AreaSpiritualDebt).Sum((short x) => x);
		if (isWin)
		{
			areaSpiritualDebt += CalcAddAreaSpiritualDebt();
		}
		combatResultData.AreaSpiritualDebt += areaSpiritualDebt;
		int CalcAddAreaSpiritualDebt()
		{
			int debt = 0;
			foreach (int charId in enemyTeam)
			{
				if (charId >= 0 && !IsGuardChar(charId))
				{
					short randomEnemyId = Config.Character.Instance[DomainManager.Character.GetElement_Objects(charId).GetTemplateId()].RandomEnemyId;
					if (randomEnemyId >= 0)
					{
						debt += RandomEnemy.Instance[randomEnemyId].SpiritualDebt;
					}
				}
			}
			return debt;
		}
		bool IsGuardChar(int chId)
		{
			GameData.Domains.Character.Character ch = DomainManager.Character.GetElement_Objects(chId);
			if (ch.GetCreatingType() != 2)
			{
				return false;
			}
			foreach (int charId in enemyTeam)
			{
				if (charId >= 0 && DomainManager.Character.GetElement_Objects(charId).GetCreatingType() == 1)
				{
					return true;
				}
			}
			return false;
		}
	}

	internal unsafe static void ResultCalcLootItem(IRandomSource random, int lootRatePercentFactor, sbyte combatType, sbyte combatStatus, bool isPuppetCombat, CombatConfigItem combatConfig, GameData.Domains.Character.Character charObj, int[] enemyTeam, ICollection<int> lootCharList, CombatResultDisplayData combatResultData)
	{
		int combatOdds = combatConfig.LootItemRate;
		combatOdds = combatOdds * GetWorldLootRatePercent() / 100;
		combatOdds = combatOdds * lootRatePercentFactor / 100;
		bool flag = ((combatType == 0 || combatType == 3) ? true : false);
		if (flag || !combatConfig.AllowDropItem || combatStatus != 3 || (combatOdds <= 0 && !combatConfig.LootAllInventory) || isPuppetCombat)
		{
			return;
		}
		if (!combatConfig.LootAllInventory)
		{
			ItemKey[] equips = charObj.GetEquipment();
			Personalities personalities = charObj.GetPersonalities();
			int equipOdds = 100 + personalities.Items[5];
			equipOdds += charObj.WorkingCarrierDropBonus;
			sbyte[] accessoryDropRateBonusSlot = AccessoryDropRateBonusSlot;
			foreach (sbyte slot in accessoryDropRateBonusSlot)
			{
				ItemKey accessoryKey = equips[slot];
				if (accessoryKey.IsValid())
				{
					equipOdds += Config.Accessory.Instance[accessoryKey.TemplateId].DropRateBonus;
				}
			}
			List<ItemKey> dropItemRandomPool = ObjectPool<List<ItemKey>>.Instance.Get();
			List<int> dropItemCount = ObjectPool<List<int>>.Instance.Get();
			for (int j = 0; j < enemyTeam.Length; j++)
			{
				int enemyId = enemyTeam[j];
				if (enemyId < 0 || lootCharList.Contains(enemyId))
				{
					continue;
				}
				int charOdds = ((j == 0) ? 100 : 25);
				GameData.Domains.Character.Character enemyChar = DomainManager.Character.GetElement_Objects(enemyId);
				ItemKey[] enemyEquips = enemyChar.GetEquipment();
				Inventory enemyInventory = enemyChar.GetInventory();
				dropItemRandomPool.Clear();
				dropItemCount.Clear();
				for (sbyte slot2 = 0; slot2 < 17; slot2++)
				{
					if (slot2 != 4)
					{
						ItemKey equipKey = enemyEquips[slot2];
						if (equipKey.IsValid() && ItemTemplateHelper.IsTransferable(equipKey.ItemType, equipKey.TemplateId))
						{
							int dropRate = ItemTemplateHelper.GetDropRate(equipKey.ItemType, equipKey.TemplateId) * equipOdds / 100 * combatOdds / 100 * charOdds / 100;
							if (random.CheckPercentProb(dropRate))
							{
								dropItemRandomPool.Add(equipKey);
								dropItemCount.Add(1);
							}
						}
					}
				}
				foreach (KeyValuePair<ItemKey, int> itemEntry in enemyInventory.Items)
				{
					ItemKey key = itemEntry.Key;
					if (ItemTemplateHelper.IsTransferable(key.ItemType, key.TemplateId))
					{
						int dropRate2 = ItemTemplateHelper.GetDropRate(key.ItemType, key.TemplateId) * equipOdds / 100 * combatOdds / 100 * charOdds / 100;
						if (random.CheckPercentProb(dropRate2))
						{
							dropItemRandomPool.Add(key);
							dropItemCount.Add(itemEntry.Value);
						}
					}
				}
				List<ItemKey> collectedKeys = new List<ItemKey>();
				int randomCount = Math.Min(dropItemRandomPool.Count, (j != 0) ? 1 : 3);
				for (int k = 0; k < randomCount; k++)
				{
					if (random.CheckPercentProb(100 - 20 * k))
					{
						int index = random.Next(dropItemRandomPool.Count);
						ItemKey key2 = dropItemRandomPool[index];
						int count = dropItemCount[index];
						dropItemRandomPool.RemoveAt(index);
						dropItemCount.RemoveAt(index);
						collectedKeys.Add(key2);
					}
				}
				List<ItemDisplayData> collection = DomainManager.Item.GetItemDisplayDataListOptional(collectedKeys, charObj.GetId(), 1);
				if (collection != null)
				{
					combatResultData.ItemList.AddRange(collection);
				}
				foreach (ItemKey key3 in collectedKeys)
				{
					combatResultData.ItemSrcCharDict[key3] = enemyChar.GetId();
				}
			}
			ObjectPool<List<ItemKey>>.Instance.Return(dropItemRandomPool);
			ObjectPool<List<int>>.Instance.Return(dropItemCount);
			return;
		}
		GameData.Domains.Character.Character enemyChar2 = DomainManager.Character.GetElement_Objects(enemyTeam[0]);
		Inventory enemyInventory2 = enemyChar2.GetInventory();
		List<ItemKey> collectedKeys2 = enemyInventory2.Items.Select((KeyValuePair<ItemKey, int> keyValuePair) => keyValuePair.Key).ToList();
		List<ItemDisplayData> collection2 = DomainManager.Item.GetItemDisplayDataListOptional(collectedKeys2, charObj.GetId(), 1);
		if (collection2 != null)
		{
			combatResultData.ItemList.AddRange(collection2);
		}
		foreach (ItemKey key4 in collectedKeys2)
		{
			combatResultData.ItemSrcCharDict[key4] = enemyChar2.GetId();
		}
	}

	public static void RegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall handler)
	{
		_handlersCombatCharAboutToFall = (OnCombatCharAboutToFall)Delegate.Combine(_handlersCombatCharAboutToFall, handler);
	}

	public static void UnRegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall handler)
	{
		_handlersCombatCharAboutToFall = (OnCombatCharAboutToFall)Delegate.Remove(_handlersCombatCharAboutToFall, handler);
	}

	public static void RaiseCombatCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		_handlersCombatCharAboutToFall?.Invoke(context, combatChar, type);
	}

	[DomainMethod]
	public CharacterDisplayData ApplyVitalOnTeammate(DataContext context, int typeInt, int index)
	{
		if ((index <= 0 || index >= 4) ? true : false)
		{
			return null;
		}
		if (PreRandomizedTeammateCommandReplaceData == null)
		{
			return null;
		}
		Dictionary<StoryTeammateType, int> vitalTeammateData = _vitalTeammateData;
		if (vitalTeammateData != null && vitalTeammateData.ContainsValue(index))
		{
			return null;
		}
		if (typeInt < 3)
		{
			bool vitalIsDemon = DomainManager.Extra.AreVitalsDemon();
			SectStoryThreeVitalsCharacter vitalData = DomainManager.Extra.GetVitalByType((SectStoryThreeVitalsCharacterType)typeInt);
			if (vitalData == null || !vitalData.AllowAsTeammate(vitalIsDemon))
			{
				return null;
			}
			if (_vitalTeammateData == null)
			{
				_vitalTeammateData = new Dictionary<StoryTeammateType, int>();
			}
			_vitalTeammateData[(StoryTeammateType)typeInt] = index;
			GameData.Domains.Character.Character vitalCharacter = DomainManager.Extra.GetVitalCharacterByType(context, (SectStoryThreeVitalsCharacterType)typeInt);
			JoinSpecialGroup(context, vitalCharacter.GetId());
			return DomainManager.Character.GetCharacterDisplayData(vitalCharacter.GetId());
		}
		switch (typeInt)
		{
		case 3:
		{
			int ironPlateCombatCharId = DomainManager.Story.GetIronPlateCombatCharId(context);
			JoinSpecialGroup(context, ironPlateCombatCharId);
			if (_vitalTeammateData == null)
			{
				_vitalTeammateData = new Dictionary<StoryTeammateType, int>();
			}
			_vitalTeammateData[(StoryTeammateType)typeInt] = index;
			return DomainManager.Character.GetCharacterDisplayData(ironPlateCombatCharId);
		}
		case 4:
		{
			int xiangshuShadowId = DomainManager.Story.GetXiangshuShadowId(context);
			JoinSpecialGroup(context, xiangshuShadowId);
			if (_vitalTeammateData == null)
			{
				_vitalTeammateData = new Dictionary<StoryTeammateType, int>();
			}
			_vitalTeammateData[(StoryTeammateType)typeInt] = index;
			return DomainManager.Character.GetCharacterDisplayData(xiangshuShadowId);
		}
		default:
			return null;
		}
	}

	[DomainMethod]
	public int RevertVitalOnTeammate(DataContext context, int typeInt)
	{
		if (_vitalTeammateData == null || PreRandomizedTeammateCommandReplaceData == null)
		{
			return -1;
		}
		if (!_vitalTeammateData.Remove((StoryTeammateType)typeInt, out var index))
		{
			return -1;
		}
		if (typeInt < 3)
		{
			SectStoryThreeVitalsCharacterType vitalType = (SectStoryThreeVitalsCharacterType)typeInt;
			GameData.Domains.Character.Character vitalCharacter = DomainManager.Extra.GetVitalCharacterByType(context, vitalType);
			ExitSpecialGroup(context, vitalCharacter.GetId());
		}
		else
		{
			int ironPlateCombatCharId = DomainManager.Story.GetIronPlateCombatCharId(context);
			ExitSpecialGroup(context, ironPlateCombatCharId);
		}
		List<int> teammateCharIds = PreRandomizedTeammateCommandReplaceData.LeftTeam.TeammateCharIds;
		if (teammateCharIds != null && teammateCharIds.Count > 0 && teammateCharIds.Count >= index)
		{
			return index;
		}
		foreach (StoryTeammateType otherType in _vitalTeammateData.Keys)
		{
			if (_vitalTeammateData[otherType] > index)
			{
				_vitalTeammateData[otherType]--;
			}
		}
		return index;
	}

	private void ProcessVitalDemonBetray(DataContext context, TeammateCommandChangeDataPart enemyTeam)
	{
		bool vitalIsDemon = DomainManager.Extra.AreVitalsDemon();
		List<SectStoryThreeVitalsCharacterType> betrayVitalDemons = null;
		SectStoryThreeVitalsCharacterType[] values = Enum.GetValues<SectStoryThreeVitalsCharacterType>();
		foreach (SectStoryThreeVitalsCharacterType type in values)
		{
			SectStoryThreeVitalsCharacter vital = DomainManager.Extra.GetVitalByType(type);
			if (vital == null)
			{
				continue;
			}
			int odds = vital.CalcBetrayOdds(vitalIsDemon);
			if (context.Random.CheckPercentProb(odds))
			{
				if (betrayVitalDemons == null)
				{
					betrayVitalDemons = new List<SectStoryThreeVitalsCharacterType>();
				}
				betrayVitalDemons.Add(type);
			}
		}
		if (betrayVitalDemons != null)
		{
			int emptyTeammateCount = 3 - enemyTeam.TeammateCharIds.Count;
			emptyTeammateCount = Math.Min(emptyTeammateCount, betrayVitalDemons.Count);
			betrayVitalDemons.Sort();
			if (emptyTeammateCount < betrayVitalDemons.Count)
			{
				betrayVitalDemons.MoveLastToFirst(emptyTeammateCount);
			}
			int fillingIndex = 0;
			bool betrayVitalIsDemon = !vitalIsDemon;
			for (int j = 0; j < emptyTeammateCount; j++)
			{
				SectStoryThreeVitalsCharacterType vitalType = betrayVitalDemons[fillingIndex++];
				short vitalTemplateId = vitalType.GetVitalTemplateId(betrayVitalIsDemon);
				GameData.Domains.Character.Character vital2 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, vitalTemplateId);
				int vitalCharId = vital2.GetId();
				SByteList vitalTeammateCommands = DomainManager.Extra.GetCharTeammateCommandsSByteList(context, vitalCharId);
				enemyTeam.BetrayedCharIds[j] = vitalCharId;
				enemyTeam.TeammateCharIds.Add(vitalCharId);
				enemyTeam.OriginTeammateCommands.Add(vitalTeammateCommands);
				enemyTeam.ReplaceTeammateCommands.Add(vitalTeammateCommands);
			}
			int replaceTeammateCount = Math.Min(3, betrayVitalDemons.Count) - emptyTeammateCount;
			for (int k = 0; k < replaceTeammateCount; k++)
			{
				SectStoryThreeVitalsCharacterType vitalType2 = betrayVitalDemons[fillingIndex++];
				short vitalTemplateId2 = vitalType2.GetVitalTemplateId(betrayVitalIsDemon);
				GameData.Domains.Character.Character vital3 = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, vitalTemplateId2);
				int vitalCharId2 = vital3.GetId();
				SByteList vitalTeammateCommands2 = DomainManager.Extra.GetCharTeammateCommandsSByteList(context, vitalCharId2);
				enemyTeam.BetrayedCharIds[k] = enemyTeam.TeammateCharIds[k];
				enemyTeam.TeammateCharIds[k] = vitalCharId2;
				List<SByteList> originTeammateCommands = enemyTeam.OriginTeammateCommands;
				int index = k;
				SByteList value = (enemyTeam.ReplaceTeammateCommands[k] = vitalTeammateCommands2);
				originTeammateCommands[index] = value;
			}
		}
	}

	public void SetCharacterUnyieldingFallen(DataContext context, int charId, bool enabled)
	{
		if (enabled)
		{
			UnyieldingFallenOnce effect = new UnyieldingFallenOnce(charId);
			DomainManager.SpecialEffect.Add(context, effect);
		}
		else
		{
			Events.RaiseSectStoryUnyieldingFallenOnceInterrupt(context, charId);
		}
	}

	[DomainMethod]
	public void GmCmd_ForceRecoverBreathAndStance(DataContext context)
	{
		ChangeBreathValue(context, _selfChar, _selfChar.GetMaxBreathValue());
		ChangeStanceValue(context, _selfChar, _selfChar.GetMaxStanceValue());
		UpdateSkillCostBreathStanceCanUse(context, _selfChar);
		GmCmd_ForceRecoverMobilityValue(context);
		GmCmd_ForceRecoverTeammateCommand(context);
	}

	[DomainMethod]
	public void GmCmd_ForceRecoverTeammateCommand(DataContext context)
	{
		CombatCharacter mainChar = GetMainCharacter(isAlly: true);
		foreach (CombatCharacter teammate in GetTeammateCharacters(mainChar.GetId()))
		{
			List<sbyte> cmdList = teammate.GetCurrTeammateCommands();
			for (int i = 0; i < cmdList.Count; i++)
			{
				teammate.ClearTeammateCommandCd(context, i);
			}
		}
	}

	[DomainMethod]
	public void GmCmd_AddTrick(DataContext context, bool isAlly, sbyte trickType)
	{
		AddTrick(context, GetCombatCharacter(isAlly), trickType);
	}

	[DomainMethod]
	public void GmCmd_AddInjury(DataContext context, bool isAlly, sbyte bodyPart, bool isInner, int count = 1, bool changeToOld = false)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		foreach (sbyte i in CRandom.IterBodyPart(bodyPart))
		{
			combatChar.AddInjury(context, i, isInner, (sbyte)count, updateDefeatMark: true, changeToOld);
		}
		AddToCheckFallenSet(combatChar.GetId());
		if (IsCharacterFallen(combatChar))
		{
			_skipCombatLoop = true;
			GetMainCharacter(isAlly).SkipOnFrameBegin = true;
		}
	}

	[DomainMethod]
	public void GmCmd_ForceHealAllInjury(DataContext context, bool isAlly = true)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		Injuries injuries = combatChar.GetInjuries();
		injuries.Initialize();
		combatChar.SetInjuries(context, injuries);
	}

	[DomainMethod]
	public void GmCmd_HealInjury(DataContext context, bool isAlly, bool isInner)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		Injuries injuries = combatChar.GetInjuries();
		for (sbyte i = 0; i < 7; i++)
		{
			injuries.Change(i, isInner, -6);
		}
		combatChar.SetInjuries(context, injuries);
	}

	[DomainMethod]
	public void GmCmd_AddPoison(DataContext context, bool isAlly, sbyte poisonType, int count = 1, bool changeToOld = false)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		short[] threshold = GlobalConfig.Instance.PoisonLevelThresholds;
		int addValue = threshold[Math.Clamp(count - 1, 0, threshold.Length - 1)] * (1 + (count - 1) / 3);
		foreach (sbyte i in CRandom.IterPoisonType(poisonType))
		{
			bool forceChangeToOld = changeToOld;
			AddPoison(context, null, combatChar, i, 3, addValue, -1, applySpecialEffect: false, canBounce: true, default(ItemKey), isDirectPoison: false, ignorePositiveResist: false, forceChangeToOld);
		}
		AddToCheckFallenSet(combatChar.GetId());
		if (IsCharacterFallen(combatChar))
		{
			_skipCombatLoop = true;
			GetMainCharacter(isAlly).SkipOnFrameBegin = true;
		}
	}

	[DomainMethod]
	public unsafe void GmCmd_ForceHealAllPoison(DataContext context, bool isAlly = true)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		PoisonInts poisons = combatChar.GetPoison();
		for (int i = 0; i < 6; i++)
		{
			poisons.Items[i] = 0;
		}
		SetPoisons(context, combatChar, poisons);
	}

	[DomainMethod]
	public void GmCmd_ForceEnemyUseSkill(DataContext context, short skillId)
	{
		if (_skillDataDict.ContainsKey(new CombatSkillKey(_enemyChar.GetId(), skillId)) && _enemyChar.NeedUseSkillId < 0 && _enemyChar.GetPreparingSkillId() < 0)
		{
			CastSkillFree(context, _enemyChar, skillId, ECombatCastFreePriority.Gm);
			_enemyChar.MoveData.ResetJumpState(context);
			UpdateAllCommandAvailability(context, _enemyChar);
		}
	}

	[DomainMethod]
	public void GmCmd_ForceEnemyUseOtherAction(DataContext context, sbyte actionType)
	{
		switch (actionType)
		{
		case 0:
			_enemyChar.SetHealInjuryCount((byte)(_enemyChar.GetHealInjuryCount() + 1), context);
			break;
		case 1:
			_enemyChar.SetHealPoisonCount((byte)(_enemyChar.GetHealPoisonCount() + 1), context);
			break;
		}
		_enemyChar.SetNeedUseOtherAction(context, actionType);
		_enemyChar.MoveData.ResetJumpState(context);
		UpdateAllCommandAvailability(context, _enemyChar);
	}

	[DomainMethod]
	public void GmCmd_ForceEnemyDefeat(DataContext context)
	{
		if (IsInCombat())
		{
			CombatCharacter enemyChar = GetCombatCharacter(isAlly: false, tryGetCoverCharacter: true);
			if (enemyChar.StateMachine.GetCurrentStateType() != CombatCharacterStateType.ChangeBossPhase && !enemyChar.NeedChangeBossPhase)
			{
				enemyChar.AddMindMark(context, GlobalConfig.NeedDefeatMarkCount[2], -1);
			}
		}
	}

	[DomainMethod]
	public void GmCmd_ForceSelfDefeat(DataContext context)
	{
		if (IsInCombat())
		{
			CombatCharacter selfChar = ((_selfChar.TeammateBeforeMainChar >= 0) ? GetElement_CombatCharacterDict(_selfChar.TeammateBeforeMainChar) : _selfChar);
			selfChar.AddMindMark(context, GlobalConfig.NeedDefeatMarkCount[2], -1);
			AddToCheckFallenSet(selfChar.GetId());
			if (DomainManager.Combat.IsCharacterFallen(selfChar))
			{
				_skipCombatLoop = true;
				GetMainCharacter(isAlly: true).SkipOnFrameBegin = true;
				SetTimeScale(1f, context);
			}
		}
	}

	[DomainMethod]
	public unsafe void GmCmd_SetNeiliAllocation(DataContext context, bool isAlly, short[] neiliAllocation)
	{
		CombatCharacter target = (isAlly ? _selfChar : _enemyChar);
		NeiliAllocation current = target.GetNeiliAllocation();
		for (byte type = 0; type < 4; type++)
		{
			target.ChangeNeiliAllocation(context, type, neiliAllocation[type] - current.Items[(int)type], applySpecialEffect: false);
		}
	}

	[DomainMethod]
	public void GmCmd_AddFlaw(DataContext context, bool isAlly, sbyte bodyPart, int count = 1)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		foreach (sbyte i in CRandom.IterBodyPart(bodyPart))
		{
			AddFlaw(context, combatChar, 3, new CombatSkillKey(-1, -1), i, count);
		}
		if (IsCharacterFallen(combatChar))
		{
			_skipCombatLoop = true;
			GetMainCharacter(isAlly).SkipOnFrameBegin = true;
		}
	}

	[DomainMethod]
	public void GmCmd_HealAllFlaw(DataContext context, bool isAlly)
	{
		RemoveAllFlaw(context, isAlly ? _selfChar : _enemyChar);
	}

	[DomainMethod]
	public void GmCmd_AddAcupoint(DataContext context, bool isAlly, sbyte bodyPart, int count = 1)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		foreach (sbyte i in CRandom.IterBodyPart(bodyPart))
		{
			AddAcupoint(context, combatChar, 3, new CombatSkillKey(-1, -1), i, count);
		}
		if (IsCharacterFallen(combatChar))
		{
			_skipCombatLoop = true;
			GetMainCharacter(isAlly).SkipOnFrameBegin = true;
		}
	}

	[DomainMethod]
	public void GmCmd_HealAllAcupoint(DataContext context, bool isAlly)
	{
		RemoveAllAcupoint(context, isAlly ? _selfChar : _enemyChar);
	}

	[DomainMethod]
	public void GmCmd_AddMind(DataContext context, bool isAlly, int count)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.AddMindMark(context, count, -1);
	}

	[DomainMethod]
	public void GmCmd_HealAllMind(DataContext context, bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.RemoveMindMark(context, int.MaxValue, random: false);
	}

	[DomainMethod]
	public void GmCmd_AddDie(DataContext context, bool isAlly, int count)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.AddDieMark(context, count);
	}

	[DomainMethod]
	public void GmCmd_HealAllDie(DataContext context, bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.GetDefeatMarkCollection().DieMarkList.Clear();
		combatChar.SetDefeatMarkCollection(combatChar.GetDefeatMarkCollection(), context);
	}

	[DomainMethod]
	public void GmCmd_AddFatal(DataContext context, bool isAlly, int count)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.AddFatalMark(context, count, -1, -1);
	}

	[DomainMethod]
	public void GmCmd_HealAllFatal(DataContext context, bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.RemoveAllFatalMark(context);
	}

	[DomainMethod]
	public void GmCmd_AddAllDefeatMark(DataContext context, bool isAlly, int count = 1)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			GmCmd_AddInjury(context, isAlly, bodyPart, isInner: true, count);
			GmCmd_AddInjury(context, isAlly, bodyPart, isInner: false, count);
			GmCmd_AddFlaw(context, isAlly, bodyPart, count);
			GmCmd_AddAcupoint(context, isAlly, bodyPart, count);
		}
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			GmCmd_AddPoison(context, isAlly, poisonType, count);
		}
		GmCmd_AddDie(context, isAlly, count);
		GmCmd_AddMind(context, isAlly, count);
		GmCmd_AddFatal(context, isAlly, count);
	}

	[DomainMethod]
	public void GmCmd_HealAllDefeatMark(DataContext context, bool isAlly)
	{
		GmCmd_ForceHealAllInjury(context, isAlly);
		GmCmd_ForceHealAllPoison(context, isAlly);
		GmCmd_HealAllFlaw(context, isAlly);
		GmCmd_HealAllAcupoint(context, isAlly);
		GmCmd_HealAllDie(context, isAlly);
		GmCmd_HealAllMind(context, isAlly);
		GmCmd_HealAllFatal(context, isAlly);
	}

	[DomainMethod]
	public void GmCmd_FightTwelveImmortals(DataContext context, int index)
	{
		TwelveImmortalsItem config = TwelveImmortals.Instance[index];
		if (config != null)
		{
			short templateId = config.Character;
			GameData.Domains.Character.Character character = ReGenerateFixedCharacter(context, templateId);
			Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
			character.SetLocation(location, context);
			Events.RaiseFixedCharacterLocationChanged(context, character.GetId(), Location.Invalid, location);
			List<int> enemyTeam = DomainManager.Character.GetNonIntelligentNpcCombatTeam(context, character);
			CombatEntry(context, enemyTeam, 2);
		}
	}

	[DomainMethod]
	public void GmCmd_FightBoss(DataContext context, short charTemplateId, int configIndex = 0)
	{
		if (Config.Character.Instance[charTemplateId].XiangshuType == 3)
		{
			sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(charTemplateId);
			int charId = DomainManager.Character.CreateJuniorXiangshuCombatImage(context, xiangshuAvatarId);
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
			List<short> config = Boss.Instance[CharId2BossId[character.GetTemplateId()]].CombatConfig;
			short sceneId = config[configIndex];
			CombatEntry(context, new List<int> { charId }, (short)(sceneId + 9));
		}
		else
		{
			GameData.Domains.Character.Character character2 = ReGenerateFixedCharacter(context, charTemplateId);
			List<int> enemyTeam = DomainManager.Character.GetNonIntelligentNpcCombatTeam(context, character2);
			List<short> config2 = Boss.Instance[CharId2BossId[charTemplateId]].CombatConfig;
			short sceneId2 = config2[configIndex];
			CombatEntry(context, enemyTeam, sceneId2);
		}
	}

	[DomainMethod]
	public void GmCmd_FightBossInternal(DataContext context, short leftCharTemplateId, short rightCharTemplateId)
	{
		int leftCharId = ReGenerateFixedCharacter(context, leftCharTemplateId).GetId();
		int rightCharId = ReGenerateFixedCharacter(context, rightCharTemplateId).GetId();
		short combatConfig = 242;
		CombatEntry(new List<int> { leftCharId }, new List<int> { rightCharId }, combatConfig);
	}

	private GameData.Domains.Character.Character ReGenerateFixedCharacter(DataContext context, short charTemplateId)
	{
		if (DomainManager.Character.TryGetFixedCharacterByTemplateId(charTemplateId, out var fixedCharacter))
		{
			DomainManager.Character.RemoveNonIntelligentCharacter(context, fixedCharacter);
		}
		GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedCharacter(context, charTemplateId);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		return character;
	}

	[DomainMethod]
	public void GmCmd_FightAnimal(DataContext context, short charTemplateId)
	{
		GameData.Domains.Character.Character character;
		switch (Config.Character.Instance[charTemplateId].CreatingType)
		{
		default:
			return;
		case 0:
			character = DomainManager.Character.GetOrCreateFixedCharacterByTemplateId(context, charTemplateId);
			break;
		case 3:
			character = DomainManager.Character.CreateFixedEnemy(context, charTemplateId, isTemporary: true);
			DomainManager.Character.CompleteCreatingCharacter(character.GetId());
			break;
		}
		CombatEntry(context, new List<int> { character.GetId() }, 2);
	}

	[DomainMethod]
	public void GmCmd_FightTestOrgMember(DataContext context, short charTemplateId, int testCount)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.CreateRandomEnemy(context, charTemplateId, isTemporary: true);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		testCount = Math.Clamp(testCount - 1, 0, 8);
		short testConfig = (short)(136 + testCount);
		CombatEntry(context, new List<int> { character.GetId() }, testConfig);
	}

	[DomainMethod]
	public void GmCmd_FightRandomEnemy(DataContext context, short charTemplateId, sbyte combatTypeAsSbyte)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.CreateRandomEnemy(context, charTemplateId, isTemporary: true);
		DomainManager.Character.CompleteCreatingCharacter(character.GetId());
		CombatType combatType = (CombatType)combatTypeAsSbyte;
		if (1 == 0)
		{
		}
		short num = combatType switch
		{
			CombatType.Play => 0, 
			CombatType.Beat => 1, 
			CombatType.Die => 2, 
			_ => 3, 
		};
		if (1 == 0)
		{
		}
		short testConfig = num;
		CombatEntry(context, new List<int> { character.GetId() }, testConfig);
	}

	[DomainMethod]
	public void GmCmd_FightCharacter(DataContext context, int charId, short combatConfig)
	{
		if (charId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			CombatEntry(context, new List<int> { charId }, combatConfig);
		}
	}

	[DomainMethod]
	public void GmCmd_FightNpc(int leftCharId, int rightCharId, short combatConfig)
	{
		CombatEntry(new List<int> { leftCharId }, new List<int> { rightCharId }, combatConfig);
	}

	[DomainMethod]
	public void GmCmd_EnableEnemyAi(DataContext context, bool on)
	{
		_enableEnemyAi = on;
		if (!on)
		{
			SetMoveState(MoveState.Stay, isAlly: false);
		}
	}

	[DomainMethod]
	public void GmCmd_EnableSkillFreeCast(DataContext context, bool on)
	{
		_enableSkillFreeCast = on;
		UpdateSkillCanUse(context, _selfChar);
	}

	[DomainMethod]
	public void GmCmd_SetImmortal(DataContext context, bool isAlly, bool on)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.Immortal = on;
		if (!on)
		{
			AddToCheckFallenSet(combatChar.GetId());
		}
	}

	[DomainMethod]
	public void GmCmd_UnitTestPrepare(DataContext context, bool testing = true)
	{
	}

	[DomainMethod]
	public void GmCmd_UnitTestClearAllEquipSkill(DataContext context, int charId)
	{
	}

	[DomainMethod]
	public bool GmCmd_UnitTestEquipSkill(DataContext context, int charId, short skillTemplateId, bool isDirect)
	{
		return false;
	}

	[DomainMethod]
	public void GmCmd_UnitTestSetDistanceToTarget(DataContext context, bool isAlly)
	{
	}

	[DomainMethod]
	public void GmCmd_ForceRecoverMobilityValue(DataContext context)
	{
		ChangeMobilityValue(context, _selfChar, _selfChar.GetMaxMobility());
	}

	[DomainMethod]
	public void GmCmd_ForceRecoverWugCount(DataContext context, bool isAlly, short wugCount)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.ChangeWugCount(context, wugCount);
	}

	[DomainMethod]
	public OuterAndInnerDamageStepDisplayData GetBodyPartDamageStepDisplayData(int charId, sbyte bodyPart)
	{
		return new OuterAndInnerDamageStepDisplayData
		{
			Outer = CalcDamageDisplayData(charId, bodyPart),
			Inner = CalcDamageDisplayData(charId, bodyPart, inner: true)
		};
	}

	[DomainMethod]
	public DamageStepDisplayData GetMindDamageStepDisplayData(int charId)
	{
		return CalcDamageDisplayData(charId, -1, inner: false, mind: true);
	}

	[DomainMethod]
	public DamageStepDisplayData GetFatalDamageStepDisplayData(int charId)
	{
		return CalcDamageDisplayData(charId, -1, inner: false, mind: false, fatal: true);
	}

	[DomainMethod]
	public CompleteDamageStepDisplayData GetCompleteDamageStepDisplayData(int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		CompleteDamageStepDisplayData ret = new CompleteDamageStepDisplayData
		{
			Fatal = GetFatalDamageStepDisplayData(charId),
			Mind = GetMindDamageStepDisplayData(charId),
			CharacterBaseDamageSteps = character.CalcBaseDamageSteps(),
			CharacterConsummateLevel = character.GetEffectiveConsummateLevel()
		};
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			ret.BodyPart[bodyPart] = GetBodyPartDamageStepDisplayData(charId, bodyPart);
		}
		return ret;
	}

	public void ClearSkillDamage(DataContext context)
	{
		_skillDamageData.Clear();
		SetSkillDamageData(_skillDamageData, context);
	}

	public void SetSkillDamageIndex(int index)
	{
		_skillDamageData.BackendTrackingIndex = index;
	}

	public void AccumulateSkillDamage(DataContext context, CombatCharacter defender, DefeatMarkKey mark, int value)
	{
		CombatCharacter attacker = GetCombatCharacter(!defender.IsAlly);
		if (attacker.GetPerformingSkillId() >= 0 && (GetCombatCharacter(defender.IsAlly) == defender || GetCombatCharacter(defender.IsAlly, tryGetCoverCharacter: true) == defender) && _skillDamageData.Accumulate(mark, value))
		{
			SetSkillDamageData(_skillDamageData, context);
		}
	}

	private DamageStepDisplayData CalcDamageDisplayData(int charId, sbyte bodyPart = -1, bool inner = false, bool mind = false, bool fatal = false)
	{
		DamageStepDisplayData ret = DamageStepDisplayData.Invalid;
		int maxDamageStep = 0;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (GameData.Domains.CombatSkill.CombatSkill skill in learnedCombatSkills.Values)
		{
			short skillTemplateId = skill.GetId().SkillTemplateId;
			CombatSkillItem config = Config.CombatSkill.Instance[skillTemplateId];
			int damageStep;
			if (mind)
			{
				damageStep = skill.CalcMindDamageStep();
			}
			else if (!fatal)
			{
				bool flag = ((bodyPart < 0 || bodyPart >= 7) ? true : false);
				damageStep = ((!flag) ? skill.CalcInjuryDamageStep(inner, bodyPart) : 0);
			}
			else
			{
				damageStep = skill.CalcFatalDamageStep();
			}
			if (damageStep > maxDamageStep)
			{
				maxDamageStep = damageStep;
				ret.ActivateSkillTemplateId = skillTemplateId;
				ret.ActivateSkillBonusData = skill.CalcStepBonusDisplayData();
			}
			else if (damageStep == maxDamageStep && ret.ActivateSkillTemplateId >= 0)
			{
				CombatSkillItem activatedConfig = Config.CombatSkill.Instance[ret.ActivateSkillTemplateId];
				if (activatedConfig.Grade < config.Grade || activatedConfig.TemplateId > config.TemplateId)
				{
					ret.ActivateSkillTemplateId = skillTemplateId;
					ret.ActivateSkillBonusData = skill.CalcStepBonusDisplayData();
				}
			}
		}
		EMarkType expectType = (fatal ? EMarkType.Fatal : (mind ? EMarkType.Mind : (inner ? EMarkType.Inner : EMarkType.Outer)));
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		ret.EatingBonusData = (int)character.GetEatingItems().CalcDamageStepBonus(expectType);
		return ret;
	}

	public DamageStepCollection GetDamageStepCollection(int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		DamageStepCollection damageSteps = character.CalcBaseDamageSteps();
		Span<int> learnedOuterDamageSteps = stackalloc int[7];
		Span<int> learnedInnerDamageSteps = stackalloc int[7];
		learnedOuterDamageSteps.Fill(0);
		learnedInnerDamageSteps.Fill(0);
		int learnedFatalDamageStep = 0;
		int learnedMindDamageStep = 0;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (GameData.Domains.CombatSkill.CombatSkill skill in learnedCombatSkills.Values)
		{
			for (sbyte i = 0; i < 7; i++)
			{
				learnedOuterDamageSteps[i] = Math.Max(learnedOuterDamageSteps[i], skill.CalcInjuryDamageStep(inner: false, i));
				learnedInnerDamageSteps[i] = Math.Max(learnedInnerDamageSteps[i], skill.CalcInjuryDamageStep(inner: true, i));
			}
			learnedFatalDamageStep = Math.Max(learnedFatalDamageStep, skill.CalcFatalDamageStep());
			learnedMindDamageStep = Math.Max(learnedMindDamageStep, skill.CalcMindDamageStep());
		}
		for (int j = 0; j < 7; j++)
		{
			damageSteps.OuterDamageSteps[j] += learnedOuterDamageSteps[j];
			damageSteps.InnerDamageSteps[j] += learnedInnerDamageSteps[j];
		}
		damageSteps.FatalDamageStep += learnedFatalDamageStep;
		damageSteps.MindDamageStep += learnedMindDamageStep;
		sbyte consummateLevel = character.GetEffectiveConsummateLevel();
		ConsummateLevelItem consummateConfig = ConsummateLevel.Instance[consummateLevel];
		damageSteps.FatalDamageStep *= (CValuePercentBonus)consummateConfig.FatalDamageStepAddPercent;
		damageSteps.MindDamageStep *= (CValuePercentBonus)consummateConfig.MindDamageStepAddPercent;
		EatingItems eatingItems = character.GetEatingItems();
		CValuePercentBonus outerDamageStepBonus = eatingItems.CalcDamageStepBonus(EMarkType.Outer);
		for (int k = 0; k < 7; k++)
		{
			damageSteps.OuterDamageSteps[k] *= outerDamageStepBonus;
		}
		CValuePercentBonus innerDamageStepBonus = eatingItems.CalcDamageStepBonus(EMarkType.Inner);
		for (int l = 0; l < 7; l++)
		{
			damageSteps.InnerDamageSteps[l] *= innerDamageStepBonus;
		}
		damageSteps.FatalDamageStep *= eatingItems.CalcDamageStepBonus(EMarkType.Fatal);
		damageSteps.MindDamageStep *= eatingItems.CalcDamageStepBonus(EMarkType.Mind);
		return damageSteps;
	}

	public void UpdateDamageCompareData(CombatContext context)
	{
		CombatCharacter attacker = context.Attacker;
		CombatCharacter defender = context.Defender;
		GameData.Domains.Item.Weapon weapon = context.Weapon;
		sbyte bodyPart = context.BodyPart;
		short skillId = context.SkillTemplateId;
		_damageCompareData.IsAlly = attacker.IsAlly;
		_damageCompareData.SkillId = skillId;
		_damageCompareData.WeaponAttack = CalcWeaponAttack(context.Attacker, context.Weapon, context.SkillTemplateId);
		_damageCompareData.WeaponDefend = CalcWeaponDefend(context.Attacker, context.Weapon, context.SkillTemplateId);
		_damageCompareData.ArmorAttack = CalcArmorAttack(context.Defender, context.Armor);
		_damageCompareData.ArmorDefend = CalcArmorDefend(context.Defender, context.Armor);
		if (skillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = context.Skill;
			for (int i = 0; i < 3; i++)
			{
				_damageCompareData.HitType[i] = attacker.SkillHitType[i];
				_damageCompareData.HitValue[i] = attacker.SkillHitValue[i];
				_damageCompareData.AvoidValue[i] = attacker.SkillAvoidValue[i];
			}
			_damageCompareData.OuterAttackValue = attacker.GetPenetrate(inner: false, weapon, bodyPart, skillId, skill.GetPenetrations().Outer);
			_damageCompareData.InnerAttackValue = attacker.GetPenetrate(inner: true, weapon, bodyPart, skillId, skill.GetPenetrations().Inner);
		}
		else
		{
			sbyte hitType = attacker.NormalAttackHitType;
			_damageCompareData.HitType[0] = hitType;
			_damageCompareData.HitType[1] = (_damageCompareData.HitType[2] = -1);
			_damageCompareData.HitValue[0] = attacker.GetHitValue(weapon, hitType, bodyPart, 0, -1);
			_damageCompareData.AvoidValue[0] = defender.GetAvoidValue(hitType, bodyPart, -1);
			_damageCompareData.OuterAttackValue = attacker.GetPenetrate(inner: false, weapon, bodyPart, -1);
			_damageCompareData.InnerAttackValue = attacker.GetPenetrate(inner: true, weapon, bodyPart, -1);
			if (attacker.GetId() == _carrierAnimalCombatCharId)
			{
				sbyte taiwuConsummateLevel = _selfChar.GetCharacter().GetConsummateLevel();
				_damageCompareData.HitValue[0] = _damageCompareData.HitValue[0] * (100 + taiwuConsummateLevel * 50) / 100;
				_damageCompareData.OuterAttackValue = _damageCompareData.OuterAttackValue * (200 + taiwuConsummateLevel * 100) / 100;
				_damageCompareData.InnerAttackValue = _damageCompareData.InnerAttackValue * (200 + taiwuConsummateLevel * 100) / 100;
			}
		}
		_damageCompareData.OuterDefendValue = defender.GetPenetrateResist(inner: false, weapon, bodyPart, skillId);
		_damageCompareData.InnerDefendValue = defender.GetPenetrateResist(inner: true, weapon, bodyPart, skillId);
		Events.RaiseCompareDataCalcFinished(context, _damageCompareData);
		SetDamageCompareData(_damageCompareData, context);
	}

	public int GetFinalCriticalOdds(CombatCharacter combatChar)
	{
		int finalIndex = combatChar.SkillFinalAttackHitIndex;
		int hitValue = _damageCompareData.HitValue[finalIndex];
		int avoidValue = _damageCompareData.AvoidValue[finalIndex];
		int hitOdds = CFormula.FormulaCalcHitOdds(hitValue, avoidValue);
		return CFormula.FormulaCalcCriticalOdds(hitOdds);
	}

	public void ClearDamageCompareData(DataContext context)
	{
		_damageCompareData.Clear();
		SetDamageCompareData(_damageCompareData, context);
	}

	private OuterAndInnerInts CalcAndAddInjury(CombatContext context, sbyte hitType, out int finalDamage, out bool critical, int power = 100, int outerPower = 100, int innerPower = 100)
	{
		OuterAndInnerInts markCounts = new OuterAndInnerInts(0, 0);
		critical = context.CheckCritical(hitType);
		if (context.BodyPart >= 0)
		{
			CalcMixedInjuryBegin(context, critical);
			CombatDamageResultMixed result = CalcMixedInjury(context, hitType, critical, power, outerPower, innerPower);
			markCounts = result.MarkCounts;
			finalDamage = result.TotalDamage;
			ApplyMixedInjury(context, result);
			CalcMixedInjuryEnd(context);
		}
		else
		{
			CombatDamageResult result2 = CalcMindInjury(context);
			markCounts.Outer = result2.MarkCount;
			finalDamage = result2.TotalDamage;
			ApplyMindInjury(context, result2);
		}
		return markCounts;
	}

	public void AddBounceDamage(CombatContext context, sbyte hitType)
	{
		AddBounceDamage(context, hitType, -1, 100);
	}

	public void AddBounceDamage(CombatContext context, sbyte hitType, short skillId, CValuePercent bouncePercent)
	{
		if (!DomainManager.SpecialEffect.ModifyData(context.AttackerId, skillId, 85, dataValue: true))
		{
			return;
		}
		OuterAndInnerInts bouncePower = context.Defender.GetBouncePower(context.InnerRatio);
		ItemKey armorKey = context.ArmorKey;
		if (armorKey.IsValid() && DomainManager.Item.TryGetElement_Armors(armorKey.Id, out var bounceArmor) && ModificationStateHelper.IsActive(bounceArmor.GetModificationState(), 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(armorKey).GetArmorPropertyBonus(ERefiningEffectArmorType.CounterAttackPower);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, bounceArmor.GetEquippedCharId());
			if (refineBonus != 0)
			{
				bouncePower.Outer = bouncePower.Outer * (100 + refineBonus) / 100;
				bouncePower.Inner = bouncePower.Inner * (100 + refineBonus) / 100;
			}
		}
		bouncePower.Outer *= bouncePercent;
		bouncePower.Inner *= bouncePercent;
		if (bouncePower.Outer > 0 || bouncePower.Inner > 0)
		{
			short defendSkillId = context.Defender.GetAffectingDefendSkillId();
			OuterAndInnerInts bounceRange = ((defendSkillId >= 0) ? new OuterAndInnerInts(CombatConfig.MinDistance, DomainManager.CombatSkill.GetElement_CombatSkills((charId: context.DefenderId, skillId: defendSkillId)).GetBounceDistance()) : new OuterAndInnerInts(CombatConfig.MaxDistance, CombatConfig.MinDistance));
			bounceRange = DomainManager.SpecialEffect.ModifyData(context.DefenderId, -1, 177, bounceRange);
			if (bounceRange.Outer <= _currentDistance && _currentDistance <= bounceRange.Inner)
			{
				CalcAndAddInjury(context.Bounce(), hitType, out var _, out var _, 100, bouncePower.Outer, bouncePower.Inner);
			}
		}
	}

	public int AddInjuryDamageValue(CombatCharacter attacker, CombatCharacter defender, sbyte bodyPart, int outerDamage, int innerDamage, short combatSkillId, bool updateDefeatMark = true, bool changeToOld = false)
	{
		DamageStepCollection damageStepCollection = defender.GetDamageStepCollection();
		CombatContext context = CombatContext.Create(attacker, defender, bodyPart, -1);
		int addMarkCount = 0;
		if (outerDamage > 0)
		{
			int damageStep = damageStepCollection.OuterDamageSteps[bodyPart];
			int[] damageValue = defender.GetOuterDamageValue();
			(int, int, int) damageResult = CalcSingleInjury(context, outerDamage, damageStep, inner: false, EDamageType.None, damageValue[bodyPart], combatSkillId);
			addMarkCount += damageResult.Item1;
			if (damageResult.Item1 > 0)
			{
				defender.AddInjury(context, bodyPart, isInner: false, (sbyte)damageResult.Item1, updateDefeatMark: false, changeToOld);
			}
			if (damageResult.Item2 > 0)
			{
				if (defender.GetInjuries().Get(bodyPart, isInnerInjury: false) < 6)
				{
					damageValue[bodyPart] = damageResult.Item2;
				}
				else
				{
					damageValue[bodyPart] = 0;
					damageResult.Item3 -= damageResult.Item2;
					addMarkCount += defender.AddFatalDamage(context, damageResult.Item2, 0, bodyPart, combatSkillId);
				}
				defender.SetOuterDamageValue(damageValue, context);
			}
			if (damageResult.Item3 >= 0)
			{
				IntPair[] outerDamageValueToShow = defender.GetOuterDamageValueToShow();
				outerDamageValueToShow[bodyPart].First = Math.Max(outerDamageValueToShow[bodyPart].First, 0);
				outerDamageValueToShow[bodyPart].First += damageResult.Item3;
				outerDamageValueToShow[bodyPart].Second = -1;
				defender.SetOuterDamageValueToShow(outerDamageValueToShow, context);
			}
		}
		if (innerDamage > 0)
		{
			int damageStep2 = damageStepCollection.InnerDamageSteps[bodyPart];
			int[] damageValue2 = defender.GetInnerDamageValue();
			int originDamageValue = damageValue2[bodyPart];
			(int, int, int) damageResult2 = CalcSingleInjury(context, innerDamage, damageStep2, inner: true, EDamageType.None, originDamageValue, combatSkillId);
			addMarkCount += damageResult2.Item1;
			if (damageResult2.Item1 > 0)
			{
				defender.AddInjury(context, bodyPart, isInner: true, (sbyte)damageResult2.Item1, updateDefeatMark: false, changeToOld);
			}
			if (damageResult2.Item2 > 0)
			{
				if (defender.GetInjuries().Get(bodyPart, isInnerInjury: true) < 6)
				{
					damageValue2[bodyPart] = damageResult2.Item2;
				}
				else
				{
					damageValue2[bodyPart] = 0;
					damageResult2.Item3 -= damageResult2.Item2;
					addMarkCount += defender.AddFatalDamage(context, damageResult2.Item2, 1, bodyPart, -1);
				}
				defender.SetInnerDamageValue(damageValue2, context);
			}
			if (damageResult2.Item3 >= 0)
			{
				IntPair[] innerDamageValueToShow = defender.GetInnerDamageValueToShow();
				innerDamageValueToShow[bodyPart].First = Math.Max(innerDamageValueToShow[bodyPart].First, 0);
				innerDamageValueToShow[bodyPart].First += damageResult2.Item3;
				innerDamageValueToShow[bodyPart].Second = -1;
				defender.SetInnerDamageValueToShow(innerDamageValueToShow, context);
			}
		}
		if (updateDefeatMark)
		{
			UpdateBodyDefeatMark(context, defender, bodyPart);
			AddToCheckFallenSet(defender.GetId());
		}
		return addMarkCount;
	}

	private static (int markCount, int leftDamage, int finalDamageValue) CalcSingleInjury(CombatContext context, long damage, int injuryStep, bool inner, EDamageType damageType, int originDamageValue, short combatSkillId = -1, CValuePercentBonus criticalPercent = default(CValuePercentBonus), int armorReducePercent = 0)
	{
		CombatCharacter attacker = context.Attacker;
		CombatCharacter defender = context.Defender;
		sbyte bodyPart = context.BodyPart;
		if (context.Defender.Immunity.IsImmune(inner ? EMarkType.Inner : EMarkType.Outer))
		{
			return (markCount: 0, leftDamage: 0, finalDamageValue: -1);
		}
		if (inner ? DomainManager.SpecialEffect.ModifyData(defender.GetId(), combatSkillId, 241, dataValue: false, bodyPart, (int)damageType) : DomainManager.SpecialEffect.ModifyData(defender.GetId(), combatSkillId, 242, dataValue: false, bodyPart, (int)damageType))
		{
			return (markCount: 0, leftDamage: 0, finalDamageValue: -1);
		}
		damage *= criticalPercent;
		int attackerId = ((damageType == EDamageType.Bounce) ? context.BounceSourceId : context.AttackerId);
		int defenderId = context.DefenderId;
		if (1 == 0)
		{
		}
		ushort num = damageType switch
		{
			EDamageType.Direct => 69, 
			EDamageType.Bounce => 70, 
			EDamageType.FightBack => 71, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort attackerFieldId = num;
		if (1 == 0)
		{
		}
		num = damageType switch
		{
			EDamageType.Direct => 102, 
			EDamageType.Bounce => 103, 
			EDamageType.FightBack => 104, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort defenderFieldId = num;
		CValueModify modify = CValueModify.Zero.ChangeB(armorReducePercent);
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(context.SkillKey, out var skill))
		{
			modify = modify.ChangeB(skill.GetMakeDamageBreakBonus());
		}
		CombatSkillKey defendSkillKey = new CombatSkillKey(context.DefenderId, context.Defender.GetAffectingDefendSkillId());
		bool anyFatal = context.Defender.GetDefeatMarkCollection().FatalDamageMarkCount > 0;
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(defendSkillKey, out var defendSkill))
		{
			modify = modify.ChangeB(defendSkill.GetAcceptDirectDamageBreakBonus(anyFatal));
		}
		int featureBonus = 0;
		foreach (short featureId in attacker.GetCharacter().GetValidFeatureIds())
		{
			featureBonus += CharacterFeature.Instance[featureId].InCombatMakeDirectDamageAddPercent;
		}
		if (featureBonus != 0)
		{
			modify = modify.ChangeB(featureBonus);
		}
		EDataSumType valueSumType = (inner ? context.InnerSumType : context.OuterSumType);
		if (attackerFieldId != ushort.MaxValue)
		{
			modify += DomainManager.SpecialEffect.GetModify(attackerId, combatSkillId, attackerFieldId, inner ? 1 : 0, bodyPart, (criticalPercent > 0) ? 1 : 0, valueSumType);
		}
		if (defenderFieldId != ushort.MaxValue)
		{
			modify += DomainManager.SpecialEffect.GetModify(defenderId, combatSkillId, defenderFieldId, inner ? 1 : 0, bodyPart, (criticalPercent > 0) ? 1 : 0, valueSumType);
		}
		modify = modify.MaxB(20);
		damage *= modify;
		if (damageType == EDamageType.Direct)
		{
			damage = DomainManager.SpecialEffect.ModifyData(attacker.GetId(), combatSkillId, 321, damage, defenderId);
		}
		damage = DomainManager.SpecialEffect.ModifyData(attacker.GetId(), combatSkillId, 89, damage, (int)damageType, inner ? 1 : 0, bodyPart);
		if (damageType == EDamageType.Direct)
		{
			damage = DomainManager.SpecialEffect.ModifyData(defender.GetId(), combatSkillId, 318, damage, attackerId, (criticalPercent > 0) ? 1 : 0);
		}
		damage = DomainManager.SpecialEffect.ModifyData(defender.GetId(), combatSkillId, 114, damage, (int)damageType, inner ? 1 : 0, bodyPart);
		(int, int) markResult = CMath.CalcMarkAndLeftDamage((int)Math.Min(originDamageValue + damage, 2147483647L), injuryStep, 6 - defender.GetInjuries().Get(bodyPart, inner));
		(int, int, int) damageResult = (markResult.Item1, markResult.Item2, (int)damage);
		if (damageType == EDamageType.Direct)
		{
			Events.RaiseAddDirectDamageValue(attacker.GetDataContext(), attacker.GetId(), defender.GetId(), bodyPart, inner, (int)damage, combatSkillId);
		}
		if (damageResult.Item1 > 0 && defender.GetInjuries().Get(bodyPart, inner) == 0 && !DomainManager.SpecialEffect.ModifyData(attacker.GetId(), combatSkillId, 80, dataValue: true, inner ? 1 : 0))
		{
			damageResult.Item1 = 0;
		}
		return damageResult;
	}

	private static CombatDamageResultMixed CalcMixedInjury(CombatContext context, sbyte hitType, bool critical, CValuePercent power, CValuePercent outerPower, CValuePercent innerPower)
	{
		context.CalcMixedDamage(hitType, power).Deconstruct(out var outer, out var inner);
		int outerDamage = outer;
		int innerDamage = inner;
		outerDamage *= outerPower;
		innerDamage *= innerPower;
		EDamageType outerDamageType = context.OuterDamageType;
		EDamageType innerDamageType = context.InnerDamageType;
		if (outerDamageType == EDamageType.Direct)
		{
			outerDamage *= context.ConsummateBonus;
		}
		if (innerDamageType == EDamageType.Direct)
		{
			innerDamage *= context.ConsummateBonus;
		}
		bool ignoreArmor = DomainManager.SpecialEffect.ModifyData(context.AttackerId, context.SkillTemplateId, 280, dataValue: false);
		ItemKey armorKey = context.Defender.Armors[context.BodyPart];
		int outerArmorReduce = 0;
		int innerArmorReduce = 0;
		if (!ignoreArmor && armorKey.IsValid())
		{
			GameData.Domains.Item.Armor armor = DomainManager.Item.GetElement_Armors(armorKey.Id);
			int weaponAttack = CalcWeaponAttack(context.Attacker, context.Weapon, context.SkillTemplateId);
			int armorDefense = CalcArmorDefend(context.Defender, armor);
			int factor = CFormula.FormulaCalcWeaponArmorFactor(100, weaponAttack, armorDefense);
			if (factor > 0)
			{
				OuterAndInnerShorts reduceInjury = armor.GetInjuryFactor();
				outerArmorReduce = -reduceInjury.Outer * factor / 100;
				innerArmorReduce = -reduceInjury.Inner * factor / 100;
			}
		}
		CValuePercentBonus criticalPercent = (critical ? context.CalcCriticalBonus(hitType) : ((CValuePercentBonus)0));
		(int, int, int) outerResult = CalcSingleInjury(context, outerDamage, context.OuterStep, inner: false, outerDamageType, context.OuterOrigin, context.SkillTemplateId, criticalPercent, outerArmorReduce);
		(int, int, int) innerResult = CalcSingleInjury(context, innerDamage, context.InnerStep, inner: true, innerDamageType, context.InnerOrigin, context.SkillTemplateId, criticalPercent, innerArmorReduce);
		ref int item = ref outerResult.Item1;
		ref int item2 = ref innerResult.Item1;
		CalcMixedInjuryMark(context, new OuterAndInnerInts(outerResult.Item1, innerResult.Item1)).Deconstruct(out inner, out outer);
		item = inner;
		item2 = outer;
		CalcMixedInjuryRefill(context, inner: false, ref outerResult.Item1, ref outerResult.Item2);
		CalcMixedInjuryRefill(context, inner: true, ref innerResult.Item1, ref innerResult.Item2);
		return new CombatDamageResultMixed
		{
			Outer = new CombatDamageResult
			{
				TotalDamage = outerResult.Item1 * context.OuterStep + outerResult.Item2 - context.OuterOrigin,
				LeftDamage = outerResult.Item2,
				MarkCount = outerResult.Item1
			},
			Inner = new CombatDamageResult
			{
				TotalDamage = innerResult.Item1 * context.InnerStep + innerResult.Item2 - context.InnerOrigin,
				LeftDamage = innerResult.Item2,
				MarkCount = innerResult.Item1
			},
			CriticalPercent = criticalPercent
		};
	}

	private static void CalcMixedInjuryBegin(CombatContext context, bool critical)
	{
		context.Defender.BeCriticalDuringCalcAddInjury = critical;
		context.Defender.BeCalcInjuryInnerRatio = context.InnerRatio;
	}

	private static void CalcMixedInjuryEnd(CombatContext context)
	{
		context.Defender.BeCriticalDuringCalcAddInjury = false;
		context.Defender.BeCalcInjuryInnerRatio = -1;
	}

	private static OuterAndInnerInts CalcMixedInjuryMark(CombatContext context, OuterAndInnerInts originMarks)
	{
		originMarks.Outer = ModifyMarkCount(inner: false);
		originMarks.Inner = ModifyMarkCount(inner: true);
		if (context.OuterDamageType == EDamageType.Direct && context.InnerDamageType == EDamageType.Direct)
		{
			originMarks = DomainManager.SpecialEffect.ModifyData(context.DefenderId, context.SkillTemplateId, 116, originMarks, context.BodyPart);
		}
		originMarks.Outer = Math.Max(originMarks.Outer, 0);
		originMarks.Inner = Math.Max(originMarks.Inner, 0);
		return originMarks;
		int ModifyMarkCount(bool inner)
		{
			EDamageType damageType = (inner ? context.InnerDamageType : context.OuterDamageType);
			int markCount = (inner ? originMarks.Inner : originMarks.Outer);
			if (markCount <= 0)
			{
				return 0;
			}
			sbyte bodyPart = context.BodyPart;
			short skillId = context.SkillTemplateId;
			if (1 == 0)
			{
			}
			int num = damageType switch
			{
				EDamageType.Direct => DomainManager.SpecialEffect.ModifyValue(context.DefenderId, skillId, 116, markCount, bodyPart, inner ? 1 : 0, markCount), 
				EDamageType.FightBack => DomainManager.SpecialEffect.ModifyValue(context.AttackerId, skillId, 87, markCount, bodyPart, inner ? 1 : 0, markCount), 
				_ => markCount, 
			};
			if (1 == 0)
			{
			}
			int modifiedMarkCount = num;
			return Math.Max(modifiedMarkCount, 0);
		}
	}

	private static void CalcMixedInjuryRefill(CombatContext context, bool inner, ref int markCount, ref int leftDamage)
	{
		int step = Math.Max(inner ? context.InnerStep : context.OuterStep, 1);
		sbyte injury = context.Defender.GetInjuries().Get(context.BodyPart, inner);
		int finalInjury = injury + markCount;
		if (finalInjury != 6 && (finalInjury >= 6 || leftDamage >= step))
		{
			if (finalInjury > 6)
			{
				int revertInjury = finalInjury - 6;
				markCount -= revertInjury;
				leftDamage += revertInjury * step;
			}
			else
			{
				(int, int) refill = CMath.CalcMarkAndLeftDamage(leftDamage, step, 6 - finalInjury);
				markCount += refill.Item1;
				leftDamage = refill.Item2;
			}
		}
	}

	private void ApplyMixedInjury(CombatContext context, CombatDamageResultMixed result)
	{
		CombatDamageResultMixed combatDamageResultMixed = result;
		var (outerResult, innerResult) = (CombatDamageResultMixed)(ref combatDamageResultMixed);
		if (context.InnerRatio > 0)
		{
			context.Defender.CheckImmunityAndShowEffect(EMarkType.Inner);
		}
		if (context.OuterRatio > 0)
		{
			context.Defender.CheckImmunityAndShowEffect(EMarkType.Outer);
		}
		CValueModify fatalModify = DomainManager.SpecialEffect.GetModify(context.AttackerId, 333);
		fatalModify += DomainManager.SpecialEffect.GetModify(context.DefenderId, 334);
		OuterAndInnerInts fatalDamage = new OuterAndInnerInts(CalcLeftFatalDamage(inner: false), CalcLeftFatalDamage(inner: true));
		if (outerResult.MarkCount > 0)
		{
			context.ApplyInjury(inner: false, outerResult.MarkCount);
		}
		if (innerResult.MarkCount > 0)
		{
			context.ApplyInjury(inner: true, innerResult.MarkCount);
		}
		if (context.OuterRatio > 0 || outerResult.TotalDamage > 0)
		{
			context.Defender.AddDamageToShow(context, outerResult.TotalDamage - fatalDamage.Outer, result.CriticalPercent, context.BodyPart, inner: false);
		}
		if (context.InnerRatio > 0 || innerResult.TotalDamage > 0)
		{
			context.Defender.AddDamageToShow(context, innerResult.TotalDamage - fatalDamage.Inner, result.CriticalPercent, context.BodyPart, inner: true);
		}
		OuterAndInnerInts fatalMarkCounts = new OuterAndInnerInts(0, 0);
		if (fatalDamage.Outer > 0)
		{
			fatalMarkCounts.Outer = context.Defender.AddFatalDamage(context, fatalDamage.Outer, 0, context.BodyPart, context.SkillTemplateId, context.OuterDamageType);
		}
		if (fatalDamage.Inner > 0)
		{
			fatalMarkCounts.Inner = context.Defender.AddFatalDamage(context, fatalDamage.Inner, 1, context.BodyPart, context.SkillTemplateId, context.InnerDamageType);
		}
		Events.RaiseAddDirectFatalDamage(context, fatalDamage, fatalMarkCounts);
		Events.RaiseAddDirectFatalDamageMark(context, context.AttackerId, context.DefenderId, context.Attacker.IsAlly, context.BodyPart, fatalMarkCounts.Outer, fatalMarkCounts.Inner, context.SkillTemplateId);
		if (context.DamageType == EDamageType.Bounce)
		{
			Events.RaiseBounceInjury(context, context.BounceSourceId, context.DefenderId, context.Attacker.IsAlly, context.BodyPart, (sbyte)outerResult.MarkCount, (sbyte)innerResult.MarkCount);
		}
		else if (result.MarkCounts.IsNonZero)
		{
			Events.RaiseAddDirectInjury(context, context.AttackerId, context.DefenderId, context.Attacker.IsAlly, context.BodyPart, (sbyte)outerResult.MarkCount, (sbyte)innerResult.MarkCount, context.SkillTemplateId);
		}
		Events.RaiseApplyMixedDamageResult(context, result);
		if (result.MarkCounts.IsNonZero)
		{
			UpdateBodyDefeatMark(context, context.Defender);
		}
		int CalcLeftFatalDamage(bool inner)
		{
			int leftDamage = (inner ? innerResult.LeftDamage : outerResult.LeftDamage);
			sbyte markCount = context.Defender.GetInjuries().Get(context.BodyPart, inner);
			if (markCount + (inner ? innerResult.MarkCount : outerResult.MarkCount) < 6)
			{
				context.Defender.SetDamageValue(context, leftDamage, context.BodyPart, inner);
				return 0;
			}
			if (context.Defender.GetDamageValue(context.BodyPart, inner) != 0)
			{
				context.Defender.SetDamageValue(context, 0, context.BodyPart, inner);
			}
			return leftDamage * fatalModify;
		}
	}

	private static CombatDamageResult CalcMindInjury(CombatContext context)
	{
		int hitOdds = context.CalcProperty(3).HitOdds;
		int damageValue = CFormula.FormulaCalcDamageValue(context.BaseDamage, hitOdds, 100L, context.AttackOdds);
		damageValue *= context.ConsummateBonus;
		int extraAddPercent = 0;
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(context.SkillKey, out var skill))
		{
			extraAddPercent += skill.GetMakeDamageBreakBonus();
		}
		damageValue = DomainManager.SpecialEffect.ModifyValueCustom(context.AttackerId, context.SkillTemplateId, 274, damageValue, -1, -1, -1, 0, extraAddPercent);
		damageValue = DomainManager.SpecialEffect.ModifyValueCustom(context.DefenderId, context.SkillTemplateId, 275, damageValue);
		int originDamageValue = context.Defender.GetMindDamageValue();
		int stepValue = context.DamageStepCollection.MindDamageStep;
		(int, int) damageResult = CMath.CalcMarkAndLeftDamage(damageValue + originDamageValue, stepValue);
		CombatDamageResult result = new CombatDamageResult
		{
			TotalDamage = damageResult.Item1 * stepValue + damageResult.Item2 - originDamageValue,
			LeftDamage = damageResult.Item2
		};
		(result.MarkCount, _) = damageResult;
		return result;
	}

	private void ApplyMindInjury(CombatContext context, CombatDamageResult result)
	{
		CombatCharacter defender = context.Defender;
		defender.SetMindDamageValue(result.LeftDamage, context);
		context.ApplyMind(result.MarkCount);
		Events.RaiseAddMindDamage(Context, context.AttackerId, context.DefenderId, result.TotalDamage, result.MarkCount, context.SkillTemplateId);
		if (result.TotalDamage >= 0)
		{
			defender.AddMindDamageToShow(context, result.TotalDamage);
		}
	}

	public void AddFlaw(DataContext context, CombatCharacter character, sbyte level, CombatSkillKey skillKey, sbyte bodyPart = -1, int count = 1, bool raiseEvent = true)
	{
		if (character.CheckImmunityAndShowEffect(EMarkType.Flaw))
		{
			return;
		}
		if (character.ChangeToMindMark)
		{
			character.AddMindMark(context, count, -1);
			return;
		}
		short skillId = skillKey.SkillTemplateId;
		if (skillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
			level = (sbyte)(level + skill.GetBreakoutGridCombatSkillPropertyBonus(41));
		}
		bool levelCanReduce = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 128, dataValue: true);
		EDataSumType levelSumType = DataSumTypeHelper.CalcSumType(canAdd: true, levelCanReduce);
		int maxLevel = GlobalConfig.Instance.FlawBaseKeepTime.Length - 1;
		level = (sbyte)Math.Clamp(level * DomainManager.SpecialEffect.GetModify(character.GetId(), skillId, 127, -1, -1, -1, levelSumType), 0, maxLevel);
		count = (sbyte)(count + DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 129, EDataModifyType.Add));
		count = (sbyte)DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 129, count, bodyPart, level);
		if (count <= 0)
		{
			return;
		}
		List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		for (int i = 0; i < count; i++)
		{
			sbyte finalBodyPart = bodyPart;
			if (finalBodyPart < 0)
			{
				partRandomPool.Clear();
				foreach (sbyte part in character.GetAvailableBodyParts())
				{
					if (character.GetFlawCount()[part] < character.GetMaxFlawCount())
					{
						partRandomPool.Add(part);
					}
				}
				if (partRandomPool.Count == 0)
				{
					foreach (sbyte part2 in character.GetAvailableBodyParts())
					{
						partRandomPool.Add(part2);
					}
				}
				finalBodyPart = partRandomPool[context.Random.Next(partRandomPool.Count)];
			}
			character.AddOrUpdateFlawOrAcupoint(context, finalBodyPart, isFlaw: true, level, raiseEvent);
		}
		ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
	}

	public void RemoveFlaw(DataContext context, CombatCharacter character, sbyte bodyPart, int index, bool raiseEvent = true, bool updateMark = true)
	{
		FlawOrAcupointCollection flaws = character.GetFlawCollection();
		byte[] flawCount = character.GetFlawCount();
		sbyte level = flaws.BodyPartDict[bodyPart][index].Level;
		flaws.BodyPartDict[bodyPart].RemoveAt(index);
		flawCount[bodyPart]--;
		character.SetFlawCollection(flaws, context);
		character.SetFlawCount(flawCount, context);
		if (updateMark)
		{
			UpdateBodyDefeatMark(context, character, bodyPart);
		}
		if (raiseEvent)
		{
			Events.RaiseFlawRemoved(context, character, bodyPart, level);
		}
	}

	public void ReduceFlawKeepTimePercent(DataContext context, CombatCharacter combatChar, int reducePercent, bool raiseEvent = true)
	{
		FlawOrAcupointCollection flawCollection = combatChar.GetFlawCollection();
		FlawOrAcupointCollection.ReduceKeepTimeResult flawRetValue = flawCollection.ReduceKeepTimePercent(reducePercent, combatChar.GetFlawCount());
		ApplyReduceFlawResult(context, combatChar, raiseEvent, flawRetValue);
	}

	public void RemoveAllFlaw(DataContext context, CombatCharacter combatChar)
	{
		FlawOrAcupointCollection flawCollection = combatChar.GetFlawCollection();
		FlawOrAcupointCollection.ReduceKeepTimeResult flawRetValue = flawCollection.ReduceKeepTime(int.MaxValue, combatChar.GetFlawCount());
		ApplyReduceFlawResult(context, combatChar, raiseEvent: false, flawRetValue);
	}

	private void ApplyReduceFlawResult(DataContext context, CombatCharacter combatChar, bool raiseEvent, FlawOrAcupointCollection.ReduceKeepTimeResult reduceResult)
	{
		FlawOrAcupointCollection collection = combatChar.GetFlawCollection();
		if (reduceResult.DataChanged)
		{
			combatChar.SetFlawCollection(collection, context);
		}
		if (reduceResult.CountChanged)
		{
			combatChar.SetFlawCount(combatChar.GetFlawCount(), context);
			UpdateBodyDefeatMark(context, combatChar);
			if (IsMainCharacter(combatChar))
			{
				UpdateAllTeammateCommandUsable(context, combatChar.IsAlly, ETeammateCommandImplement.HealFlaw);
			}
		}
		if (!raiseEvent)
		{
			return;
		}
		foreach (var (bodyPart, level) in reduceResult.RemovedList)
		{
			Events.RaiseFlawRemoved(context, combatChar, bodyPart, level);
		}
	}

	public void TransferRandomFlaw(DataContext context, CombatCharacter src, CombatCharacter dst)
	{
		DefeatMarkCollection marks = src.GetDefeatMarkCollection();
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (marks.FlawMarkList[i].Count > 0)
			{
				pool.Add(i);
			}
		}
		if (pool.Count > 0)
		{
			sbyte bodyPart = pool.GetRandom(context.Random);
			int index = context.Random.Next(marks.FlawMarkList[bodyPart].Count);
			TransferFlaw(context, src, dst, bodyPart, index);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	public void TransferFlaw(DataContext context, CombatCharacter srcChar, CombatCharacter destChar, sbyte bodyPart, int index)
	{
		FlawOrAcupointEntry flaw = srcChar.GetFlawCollection().BodyPartDict[bodyPart][index];
		RemoveFlaw(context, srcChar, bodyPart, index, raiseEvent: false);
		destChar.AddOrUpdateFlawOrAcupoint(context, bodyPart, isFlaw: true, flaw.Level, raiseEvent: true, flaw.LeftFrame, flaw.TotalFrame);
	}

	public void AddAcupoint(DataContext context, CombatCharacter character, sbyte level, CombatSkillKey skillKey, sbyte bodyPart = -1, int count = 1, bool raiseEvent = true)
	{
		if (character.CheckImmunityAndShowEffect(EMarkType.Acupoint))
		{
			return;
		}
		if (character.ChangeToMindMark)
		{
			character.AddMindMark(context, count, -1);
			return;
		}
		short skillId = skillKey.SkillTemplateId;
		if (skillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
			level = (sbyte)(level + skill.GetBreakoutGridCombatSkillPropertyBonus(40));
		}
		bool levelCanReduce = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 133, dataValue: true);
		EDataSumType levelSumType = DataSumTypeHelper.CalcSumType(canAdd: true, levelCanReduce);
		int maxLevel = GlobalConfig.Instance.AcupointBaseKeepTime.Length - 1;
		level = (sbyte)Math.Clamp(level * DomainManager.SpecialEffect.GetModify(character.GetId(), skillId, 132, -1, -1, -1, levelSumType), 0, maxLevel);
		count = (sbyte)(count + DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 134, EDataModifyType.Add));
		count = (sbyte)DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 134, count, bodyPart, level);
		if (count <= 0)
		{
			return;
		}
		List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		for (int i = 0; i < count; i++)
		{
			sbyte finalBodyPart = bodyPart;
			if (finalBodyPart < 0)
			{
				partRandomPool.Clear();
				foreach (sbyte part in character.GetAvailableBodyParts())
				{
					if (character.GetAcupointCount()[part] < character.GetMaxAcupointCount())
					{
						partRandomPool.Add(part);
					}
				}
				if (partRandomPool.Count == 0)
				{
					foreach (sbyte part2 in character.GetAvailableBodyParts())
					{
						partRandomPool.Add(part2);
					}
				}
				finalBodyPart = partRandomPool[context.Random.Next(partRandomPool.Count)];
			}
			character.AddOrUpdateFlawOrAcupoint(context, finalBodyPart, isFlaw: false, level, raiseEvent);
		}
		ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
	}

	public void RemoveAcupoint(DataContext context, CombatCharacter character, sbyte bodyPart, int index, bool raiseEvent = true, bool updateMark = true)
	{
		FlawOrAcupointCollection acupoints = character.GetAcupointCollection();
		byte[] acupointCount = character.GetAcupointCount();
		sbyte level = acupoints.BodyPartDict[bodyPart][index].Level;
		acupoints.BodyPartDict[bodyPart].RemoveAt(index);
		acupointCount[bodyPart]--;
		character.SetAcupointCollection(acupoints, context);
		character.SetAcupointCount(acupointCount, context);
		if (updateMark)
		{
			UpdateBodyDefeatMark(context, character, bodyPart);
		}
		if (raiseEvent)
		{
			Events.RaiseAcuPointRemoved(context, character, bodyPart, level);
		}
	}

	public void ReduceAcupointKeepTimePercent(DataContext context, CombatCharacter combatChar, int reducePercent, bool raiseEvent = true)
	{
		FlawOrAcupointCollection acupointCollection = combatChar.GetAcupointCollection();
		FlawOrAcupointCollection.ReduceKeepTimeResult acupointRetValue = acupointCollection.ReduceKeepTimePercent(reducePercent, combatChar.GetAcupointCount());
		ApplyReduceAcupointResult(context, combatChar, raiseEvent, acupointRetValue);
	}

	public void RemoveAllAcupoint(DataContext context, CombatCharacter combatChar)
	{
		FlawOrAcupointCollection acupointCollection = combatChar.GetAcupointCollection();
		FlawOrAcupointCollection.ReduceKeepTimeResult acupointRetValue = acupointCollection.ReduceKeepTime(int.MaxValue, combatChar.GetAcupointCount());
		ApplyReduceAcupointResult(context, combatChar, raiseEvent: false, acupointRetValue);
	}

	private void ApplyReduceAcupointResult(DataContext context, CombatCharacter combatChar, bool raiseEvent, FlawOrAcupointCollection.ReduceKeepTimeResult reduceResult)
	{
		FlawOrAcupointCollection collection = combatChar.GetAcupointCollection();
		if (reduceResult.DataChanged)
		{
			combatChar.SetAcupointCollection(collection, context);
		}
		if (reduceResult.CountChanged)
		{
			combatChar.SetAcupointCount(combatChar.GetAcupointCount(), context);
			UpdateBodyDefeatMark(context, combatChar);
			if (IsMainCharacter(combatChar))
			{
				UpdateAllTeammateCommandUsable(context, combatChar.IsAlly, ETeammateCommandImplement.HealAcupoint);
			}
		}
		if (!raiseEvent)
		{
			return;
		}
		foreach (var (bodyPart, level) in reduceResult.RemovedList)
		{
			Events.RaiseAcuPointRemoved(context, combatChar, bodyPart, level);
		}
	}

	public void TransferRandomAcupoint(DataContext context, CombatCharacter src, CombatCharacter dst)
	{
		DefeatMarkCollection marks = src.GetDefeatMarkCollection();
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (marks.AcupointMarkList[i].Count > 0)
			{
				pool.Add(i);
			}
		}
		if (pool.Count > 0)
		{
			sbyte bodyPart = pool.GetRandom(context.Random);
			int index = context.Random.Next(marks.AcupointMarkList[bodyPart].Count);
			TransferAcupoint(context, src, dst, bodyPart, index);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	public void TransferAcupoint(DataContext context, CombatCharacter srcChar, CombatCharacter destChar, sbyte bodyPart, int index)
	{
		FlawOrAcupointEntry acupoint = srcChar.GetAcupointCollection().BodyPartDict[bodyPart][index];
		RemoveAcupoint(context, srcChar, bodyPart, index, raiseEvent: false);
		destChar.AddOrUpdateFlawOrAcupoint(context, bodyPart, isFlaw: false, acupoint.Level, raiseEvent: true, acupoint.LeftFrame, acupoint.TotalFrame);
	}

	public void RemoveHalfFlawOrAcupoint(DataContext context, CombatCharacter combatChar, bool isFlaw)
	{
		DefeatMarkCollection collection = combatChar.GetDefeatMarkCollection();
		int totalCount = (isFlaw ? collection.GetTotalFlawCount() : collection.GetTotalAcupointCount());
		int removeCount = totalCount * CValueHalf.RoundUp;
		combatChar.RemoveRandomFlawOrAcupoint(context, isFlaw, removeCount);
	}

	[DomainMethod]
	public uint GetHealInjuryBanReason(int doctorCharId, int patientCharId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(doctorCharId, out var doctor))
		{
			return 0u;
		}
		if (!DomainManager.Character.TryGetElement_Objects(patientCharId, out var patient))
		{
			return 0u;
		}
		return GetHealInjuryBanReason(doctor, patient);
	}

	[DomainMethod]
	public uint GetHealPoisonBanReason(int doctorCharId, int patientCharId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(doctorCharId, out var doctor))
		{
			return 0u;
		}
		if (!DomainManager.Character.TryGetElement_Objects(patientCharId, out var patient))
		{
			return 0u;
		}
		return GetHealPoisonBanReason(doctor, patient);
	}

	public BoolArray32 GetHealInjuryBanReason(CombatCharacter doctor, CombatCharacter patient)
	{
		return GetHealInjuryBanReason(doctor.GetCharacter(), patient.GetCharacter());
	}

	public BoolArray32 GetHealInjuryBanReason(GameData.Domains.Character.Character doctor, GameData.Domains.Character.Character patient)
	{
		BoolArray32 array = default(BoolArray32);
		if (patient.GetInjuries().HasAnyInjury())
		{
			int hasHerb = doctor.GetResource(5);
			int needHerb = patient.CalcHealCostHerb(EHealActionType.Healing);
			HealInjury(patient.GetId(), doctor, out var allHealValue, out var herbHeal, out var maxHealMarkCount, canHealOld: true, getCost: true, checkHerb: true);
			array[2] = hasHerb < needHerb && herbHeal <= 0;
			HealInjury(patient.GetId(), doctor, out maxHealMarkCount, out var attainmentHeal, out allHealValue, canHealOld: true, getCost: true);
			array[3] = attainmentHeal <= 0;
		}
		else
		{
			array[0] = true;
		}
		return array;
	}

	public BoolArray32 GetHealPoisonBanReason(CombatCharacter doctor, CombatCharacter patient)
	{
		return GetHealPoisonBanReason(doctor.GetCharacter(), patient.GetCharacter());
	}

	public BoolArray32 GetHealPoisonBanReason(GameData.Domains.Character.Character doctor, GameData.Domains.Character.Character patient)
	{
		BoolArray32 array = default(BoolArray32);
		if (patient.GetPoisoned().IsNonZero())
		{
			int hasHerb = doctor.GetResource(5);
			int needHerb = patient.CalcHealCostHerb(EHealActionType.Detox);
			HealPoison(patient.GetId(), doctor, out var healMarkCount, out var herbHeal, canHealOld: true, getCost: true, checkHerb: true);
			array[2] = hasHerb < needHerb && herbHeal <= 0;
			HealPoison(patient.GetId(), doctor, out healMarkCount, out var attainmentHeal, canHealOld: true, getCost: true);
			array[3] = attainmentHeal <= 0;
		}
		else
		{
			array[0] = true;
		}
		return array;
	}

	public int GetMaxCanHealInjuryCount(int doctorCharId, int patientCharId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(doctorCharId, out var doctor))
		{
			return 0;
		}
		HealInjury(patientCharId, doctor, out var _, out var _, out var maxHealMarkCount, canHealOld: true, getCost: true, checkHerb: true);
		return maxHealMarkCount;
	}

	public static int GetHealInjuryCostHerb(Injuries injuries)
	{
		int costHerb = GlobalConfig.Instance.HealInjuryBaseHerb;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte, sbyte) injury = injuries.Get(bodyPart);
			if (injury.Item1 > 0)
			{
				costHerb += GlobalConfig.Instance.HealInjuryExtraHerb[injury.Item1 - 1];
			}
			if (injury.Item2 > 0)
			{
				costHerb += GlobalConfig.Instance.HealInjuryExtraHerb[injury.Item2 - 1];
			}
		}
		return costHerb;
	}

	public static int GetHealInjuryCostMoney(Injuries injuries, sbyte doctorBehaviorType)
	{
		int costMoney = GlobalConfig.Instance.HealInjuryBaseMoney;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte, sbyte) injury = injuries.Get(bodyPart);
			if (injury.Item1 > 0)
			{
				costMoney += GlobalConfig.Instance.HealInjuryExtraMoney[injury.Item1 - 1];
			}
			if (injury.Item2 > 0)
			{
				costMoney += GlobalConfig.Instance.HealInjuryExtraMoney[injury.Item2 - 1];
			}
		}
		return costMoney * GlobalConfig.Instance.HealMoneyPercent[doctorBehaviorType] / 100;
	}

	public static int GetHealInjuryCostSpiritualDebt(Injuries injuries)
	{
		int cost = 0;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte, sbyte) injury = injuries.Get(bodyPart);
			if (injury.Item1 > 0)
			{
				cost += GlobalConfig.Instance.HealInjuryCostSpiritualDebt[injury.Item1 - 1];
			}
			if (injury.Item2 > 0)
			{
				cost += GlobalConfig.Instance.HealInjuryCostSpiritualDebt[injury.Item2 - 1];
			}
		}
		return cost;
	}

	public unsafe static int GetHealPoisonCostHerb(PoisonInts poisons)
	{
		int costHerb = GlobalConfig.Instance.HealPoisonBaseHerb;
		for (sbyte type = 0; type < 6; type++)
		{
			int poison = poisons.Items[type];
			int poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poison);
			if (poisonLevel > 0)
			{
				costHerb += GlobalConfig.Instance.HealPoisonExtraHerb[poisonLevel - 1];
			}
		}
		return costHerb;
	}

	public unsafe static int GetHealPoisonCostMoney(PoisonInts poisons, sbyte doctorBehaviorType)
	{
		int costMoney = GlobalConfig.Instance.HealPoisonBaseMoney;
		for (sbyte type = 0; type < 6; type++)
		{
			int poison = poisons.Items[type];
			int poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poison);
			if (poisonLevel > 0)
			{
				costMoney += GlobalConfig.Instance.HealPoisonExtraMoney[poisonLevel - 1];
			}
		}
		return costMoney * GlobalConfig.Instance.HealMoneyPercent[doctorBehaviorType] / 100;
	}

	public unsafe static int GetHealPoisonCostSpiritualDebt(PoisonInts poisons)
	{
		int cost = 0;
		for (sbyte type = 0; type < 6; type++)
		{
			int poison = poisons.Items[type];
			int poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poison);
			if (poisonLevel > 0)
			{
				cost += GlobalConfig.Instance.HealPoisonExtraSpiritualDebt[poisonLevel - 1];
			}
		}
		return cost;
	}

	public static int GetHealQiDisorderCostHerb(short qiDisorder)
	{
		return GlobalConfig.Instance.HealQiDisorderHerb[DisorderLevelOfQi.GetDisorderLevelOfQi(qiDisorder)];
	}

	public static int GetHealQiDisorderCostMoney(short qiDisorder, sbyte doctorBehaviorType)
	{
		return GlobalConfig.Instance.HealQiDisorderMoney[DisorderLevelOfQi.GetDisorderLevelOfQi(qiDisorder)] * GlobalConfig.Instance.HealMoneyPercent[doctorBehaviorType];
	}

	public static int GetHealQiDisorderCostSpiritualDebt(short qiDisorder)
	{
		return GlobalConfig.Instance.HealQiDisorderCostSpiritualDebt[DisorderLevelOfQi.GetDisorderLevelOfQi(qiDisorder)];
	}

	public static int GetHealHealthCostHerb(EHealthType healthType)
	{
		int index = healthType.ToCommonIndex();
		return GlobalConfig.Instance.HealHealthHerb.GetOrDefault(index);
	}

	public static int GetHealHealthCostMoney(EHealthType healthType, sbyte doctorBehaviorType)
	{
		int index = healthType.ToCommonIndex();
		CValuePercent behaviorPercent = GlobalConfig.Instance.HealMoneyPercent[doctorBehaviorType];
		return GlobalConfig.Instance.HealHealthMoney.GetOrDefault(index) * behaviorPercent;
	}

	public static int GetHealHealthCostSpiritualDebt(EHealthType healthType)
	{
		int index = healthType.ToCommonIndex();
		return GlobalConfig.Instance.HealHealthCostSpiritualDebt.GetOrDefault(index);
	}

	public int GetHealInjuryMaxRequireAttainment(int patientId)
	{
		HealInjuryCalcOriginal(patientId, out var injuries, out var _, out var _);
		int maxInjuryCount = injuries.GetMax();
		return CFormula.CalcHealInjuryRequireAttainment(maxInjuryCount);
	}

	public int GetHealPoisonMaxRequireAttainment(int patientId)
	{
		HealPoisonCalcOriginal(patientId, out var poisons, out var _);
		int maxPoisonValue = poisons.Max();
		sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(maxPoisonValue);
		return CFormula.CalcHealPoisonRequireAttainment(poisonLevel);
	}

	public int GetHealQiDisorderRequireAttainment(int patientId)
	{
		short qiDisorder = DomainManager.Character.GetElement_Objects(patientId).GetDisorderOfQi();
		sbyte qiDisorderLevel = DisorderLevelOfQi.GetDisorderLevelOfQi(qiDisorder);
		return CFormula.CalcHealQiDisorderRequireAttainment(qiDisorderLevel);
	}

	public int GetHealHealthRequireAttainment(int patientId)
	{
		GameData.Domains.Character.Character patient = DomainManager.Character.GetElement_Objects(patientId);
		EHealthType healthType = patient.GetHealthType();
		return CFormula.CalcHealHealthRequireAttainment(healthType);
	}

	public sbyte HealInjuryInCombat(DataContext context, CombatCharacter patient, CombatCharacter doctor, bool canHealOld = true, bool costHerb = true, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		Injuries herbInjuries = patient.GetInjuries();
		int needHerb = (costHerb ? GetHealInjuryCostHerb(herbInjuries) : 0);
		int hasHerb = doctor.GetCharacter().GetResource(5);
		if (needHerb > hasHerb)
		{
			ShowSpecialEffectTips(patient.GetId(), 1458, 0);
		}
		Dictionary<int, int> changedInnerDamageValue = ObjectPool<Dictionary<int, int>>.Instance.Get();
		Dictionary<int, int> changedOuterDamageValue = ObjectPool<Dictionary<int, int>>.Instance.Get();
		changedInnerDamageValue.Clear();
		changedOuterDamageValue.Clear();
		int allHealValue;
		int allHealMarkCount;
		int maxHealMarkCount;
		Injuries newInjuries = HealInjury(patient.GetId(), doctor.GetCharacter(), out allHealValue, out allHealMarkCount, out maxHealMarkCount, canHealOld, getCost: false, costHerb, changedInnerDamageValue, changedOuterDamageValue, attainmentBonus);
		HealInjuryInCombatWithFatal(context, patient, doctor, herbInjuries);
		doctor.GetCharacter().ChangeResource(context, 5, -Math.Min(needHerb, hasHerb));
		if (allHealMarkCount > 0)
		{
			patient.SetInjuries(context, newInjuries);
		}
		int key;
		if (changedInnerDamageValue.Count > 0)
		{
			int[] innerDamageValue = patient.GetInnerDamageValue();
			foreach (KeyValuePair<int, int> item in changedInnerDamageValue)
			{
				item.Deconstruct(out maxHealMarkCount, out key);
				int bodyPart = maxHealMarkCount;
				int value = key;
				innerDamageValue[bodyPart] = value;
			}
			patient.SetInnerDamageValue(innerDamageValue, context);
		}
		if (changedOuterDamageValue.Count > 0)
		{
			int[] outerDamageValue = patient.GetOuterDamageValue();
			foreach (KeyValuePair<int, int> item2 in changedOuterDamageValue)
			{
				item2.Deconstruct(out key, out maxHealMarkCount);
				int bodyPart2 = key;
				int value2 = maxHealMarkCount;
				outerDamageValue[bodyPart2] = value2;
			}
			patient.SetOuterDamageValue(outerDamageValue, context);
		}
		Events.RaiseHealedInjury(context, doctor.GetId(), patient.GetId(), patient.IsAlly, (sbyte)allHealMarkCount);
		if (patient.IsTaiwu)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 13, allHealValue);
		}
		return (sbyte)allHealMarkCount;
	}

	private void HealInjuryInCombatWithFatal(DataContext context, CombatCharacter patient, CombatCharacter doctor, Injuries herbInjuries)
	{
		int healInjuryWithFatalRequireAttainment = DomainManager.SpecialEffect.ModifyData(doctor.GetId(), -1, 328, -1);
		if (healInjuryWithFatalRequireAttainment < 0)
		{
			return;
		}
		int step = patient.GetDamageStepCollection().FatalDamageStep;
		short doctorAttainment = doctor.GetCharacter().GetLifeSkillAttainment(8);
		int healValue = step * CFormula.CalcHealInjuryValue(doctorAttainment, healInjuryWithFatalRequireAttainment);
		var (buff, debuff) = HealInjuryCalcExtraAddPercent(patient.GetId(), doctor.GetCharacter(), checkHerb: true, herbInjuries, getCost: false);
		healValue *= debuff;
		healValue *= buff;
		if (healValue > 0)
		{
			int healMark = healValue / step;
			int damage = patient.GetFatalDamageValue();
			DefeatMarkCollection marks = patient.GetDefeatMarkCollection();
			bool allowRealloc = marks.FatalDamageMarkCount > healMark;
			int newDamage = HealInjuryReallocRemainder(healValue, step, damage, ref healMark, allowRealloc);
			if (newDamage != damage)
			{
				patient.SetFatalDamageValue(newDamage, context);
			}
			if (marks.FatalDamageMarkCount > 0 && healMark > 0)
			{
				marks.FatalDamageMarkCount = Math.Max(marks.FatalDamageMarkCount - healMark, 0);
				patient.SetDefeatMarkCollection(marks, context);
			}
		}
	}

	public sbyte HealPoisonInCombat(DataContext context, CombatCharacter patient, CombatCharacter doctor, bool canHealOld = true, bool costHerb = true, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		int needHerb = (costHerb ? GetHealPoisonCostHerb(patient.GetPoison()) : 0);
		int hasHerb = doctor.GetCharacter().GetResource(5);
		if (needHerb > hasHerb)
		{
			ShowSpecialEffectTips(patient.GetId(), 1460, 0);
		}
		int healMarkCount;
		int healPoisonValue;
		PoisonInts newPoison = HealPoison(patient.GetId(), doctor.GetCharacter(), out healMarkCount, out healPoisonValue, canHealOld, getCost: false, costHerb, attainmentBonus);
		doctor.GetCharacter().ChangeResource(context, 5, -Math.Min(needHerb, hasHerb));
		SetPoisons(context, patient, newPoison);
		Events.RaiseHealedPoison(context, doctor.GetId(), patient.GetId(), patient.IsAlly, (sbyte)healMarkCount);
		if (patient.IsTaiwu)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 14, healPoisonValue);
		}
		return (sbyte)healMarkCount;
	}

	public Injuries HealInjury(int patientId, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		int allHealValue;
		int allHealMarkCount;
		int maxHealMarkCount;
		return HealInjury(patientId, doctor, out allHealValue, out allHealMarkCount, out maxHealMarkCount, canHealOld: true, getCost: false, checkHerb: false, null, null, attainmentBonus);
	}

	public Injuries HealInjury(int patientId, Injuries injuries, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		HealInjuryCalcOriginal(patientId, out var _, out var _, out var damageSteps);
		int allHealValue;
		int allHealMarkCount;
		int maxHealMarkCount;
		return HealInjury(patientId, injuries, injuries, damageSteps, doctor, out allHealValue, out allHealMarkCount, out maxHealMarkCount, canHealOld: true, getCost: false, checkHerb: false, null, null, attainmentBonus);
	}

	public Injuries HealInjury(int patientId, GameData.Domains.Character.Character doctor, out int allHealValue, out int allHealMarkCount, out int maxHealMarkCount, bool canHealOld = true, bool getCost = false, bool checkHerb = false, Dictionary<int, int> changedInnerDamageValue = null, Dictionary<int, int> changedOuterDamageValue = null, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		HealInjuryCalcOriginal(patientId, out var injuries, out var oldInjuries, out var damageSteps);
		return HealInjury(patientId, injuries, oldInjuries, damageSteps, doctor, out allHealValue, out allHealMarkCount, out maxHealMarkCount, canHealOld, getCost, checkHerb, changedInnerDamageValue, changedOuterDamageValue, attainmentBonus);
	}

	public Injuries HealInjury(int patientId, Injuries injuries, Injuries oldInjuries, DamageStepCollection damageSteps, GameData.Domains.Character.Character doctor, out int allHealValue, out int allHealMarkCount, out int maxHealMarkCount, bool canHealOld = true, bool getCost = false, bool checkHerb = false, Dictionary<int, int> changedInnerDamageValue = null, Dictionary<int, int> changedOuterDamageValue = null, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		(CValueModify, CValueModify) tuple = HealInjuryCalcExtraAddPercent(patientId, doctor, checkHerb, injuries, getCost);
		CValueModify buff = tuple.Item1;
		CValueModify debuff = tuple.Item2;
		CValueModify innerDebuff = debuff + doctor.GetFeatureBonusHealInnerInjury();
		CValueModify outerDebuff = debuff + doctor.GetFeatureBonusHealOuterInjury();
		CombatCharacter patient;
		bool inCombat = _combatCharacterDict.TryGetValue(patientId, out patient) && IsInCombat();
		int doctorAttainment = doctor.CalcHealAttainment(EHealActionType.Healing);
		doctorAttainment *= attainmentBonus;
		allHealValue = 0;
		allHealMarkCount = 0;
		maxHealMarkCount = 0;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			HealPartInjury(bodyPart, isInner: true, ref allHealValue, ref allHealMarkCount, ref maxHealMarkCount);
			HealPartInjury(bodyPart, isInner: false, ref allHealValue, ref allHealMarkCount, ref maxHealMarkCount);
		}
		return injuries;
		void HealPartInjury(sbyte b, bool isInner, ref int reference, ref int reference2, ref int reference3)
		{
			int damage = ((patient != null) ? (isInner ? patient.GetInnerDamageValue() : patient.GetOuterDamageValue())[b] : 0);
			int step = (isInner ? damageSteps.InnerDamageSteps : damageSteps.OuterDamageSteps)[b];
			sbyte injuryCount = injuries.Get(b, isInner);
			int injury = injuryCount * step + damage;
			if (injury > 0)
			{
				int requireAttainment = CFormula.CalcHealInjuryRequireAttainment(injuryCount);
				int healValue = step * CFormula.CalcHealInjuryValue(doctorAttainment, requireAttainment);
				if (healValue > 0)
				{
					healValue *= (isInner ? innerDebuff : outerDebuff);
					int oldInjury = oldInjuries.Get(b, isInner) * step;
					int newInjury = injury - oldInjury;
					if (healValue < newInjury)
					{
						healValue = Math.Min(healValue * buff, newInjury);
					}
					int maxHealValue = healValue;
					healValue = Math.Min(healValue, canHealOld ? injury : (injury - oldInjury));
					int healMark = healValue / step;
					Dictionary<int, int> changedDamageValue = (isInner ? changedInnerDamageValue : changedOuterDamageValue);
					if (inCombat && changedDamageValue != null)
					{
						bool allowRealloc = injuries.Get(b, isInner) > healMark;
						int newDamageValue = HealInjuryReallocRemainder(healValue, step, damage, ref healMark, allowRealloc);
						if (newDamageValue != damage)
						{
							changedDamageValue[b] = newDamageValue;
						}
					}
					injuries.Change(b, isInner, (sbyte)(-healMark));
					reference += healValue;
					reference2 += healMark;
					reference3 += maxHealValue / step;
				}
			}
		}
	}

	private void HealInjuryCalcOriginal(int patientId, out Injuries injuries, out Injuries oldInjuries, out DamageStepCollection damageSteps)
	{
		if (IsCharInCombat(patientId))
		{
			CombatCharacter combatChar = _combatCharacterDict[patientId];
			injuries = combatChar.GetInjuries();
			oldInjuries = combatChar.GetOldInjuries();
			damageSteps = combatChar.GetDamageStepCollection();
		}
		else
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(patientId);
			injuries = (oldInjuries = character.GetInjuries());
			damageSteps = GetDamageStepCollection(patientId);
		}
	}

	private (CValueModify buff, CValueModify debuff) HealInjuryCalcExtraAddPercent(int patientId, GameData.Domains.Character.Character doctor, bool checkHerb, Injuries injuries, bool getCost)
	{
		CValueModify buff = CValueModify.Zero;
		CValueModify debuff = CValueModify.Zero;
		if (IsCharInCombat(patientId))
		{
			CombatCharacter doctorChar = _combatCharacterDict[doctor.GetId()];
			if (doctorChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.HealInjury)
			{
				debuff = debuff.ChangeB(DomainManager.SpecialEffect.GetModifyValue(patientId, 184, EDataModifyType.Add, 6));
			}
		}
		buff += DomainManager.SpecialEffect.GetModify(doctor.GetId(), 119, getCost ? 1 : 0);
		debuff += DomainManager.SpecialEffect.GetModify(doctor.GetId(), 120, getCost ? 1 : 0);
		if (!checkHerb)
		{
			return (buff: buff, debuff: debuff);
		}
		int needHerb = GetHealInjuryCostHerb(injuries);
		int hasHerb = doctor.GetResource(5);
		if (needHerb > hasHerb)
		{
			debuff = debuff.ChangeB(-(int)CValuePercent.Parse(needHerb - hasHerb, needHerb));
		}
		return (buff: buff, debuff: debuff);
	}

	private int HealInjuryReallocRemainder(int healValue, int step, int damage, ref int healMark, bool allowRealloc)
	{
		int newDamage = damage;
		int healInjuryValue = healValue % step;
		newDamage -= healInjuryValue;
		if (newDamage >= 0 || !allowRealloc)
		{
			return Math.Max(newDamage, 0);
		}
		healMark++;
		return newDamage + step;
	}

	public PoisonInts HealPoison(int patientId, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		int healMarkCount;
		int healPoisonValue;
		return HealPoison(patientId, doctor, out healMarkCount, out healPoisonValue, canHealOld: true, getCost: false, checkHerb: false, attainmentBonus);
	}

	public PoisonInts HealPoison(int patientId, PoisonInts poisons, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		int healMarkCount;
		int healPoisonValue;
		return HealPoison(patientId, poisons, poisons, doctor, out healMarkCount, out healPoisonValue, canHealOld: true, getCost: false, checkHerb: false, attainmentBonus);
	}

	public PoisonInts HealPoison(int patientId, GameData.Domains.Character.Character doctor, out int healMarkCount, out int healPoisonValue, bool canHealOld = true, bool getCost = false, bool checkHerb = false, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		HealPoisonCalcOriginal(patientId, out var poisons, out var oldPoisons);
		return HealPoison(patientId, poisons, oldPoisons, doctor, out healMarkCount, out healPoisonValue, canHealOld, getCost, checkHerb, attainmentBonus);
	}

	public PoisonInts HealPoison(int patientId, PoisonInts poisons, PoisonInts oldPoisons, GameData.Domains.Character.Character doctor, out int healMarkCount, out int healPoisonValue, bool canHealOld = true, bool getCost = false, bool checkHerb = false, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		(CValueModify buff, CValueModify debuff) tuple = HealPoisonCalcExtraAddPercent(patientId, doctor, checkHerb, poisons, getCost);
		CValueModify buff = tuple.buff;
		CValueModify debuff = tuple.debuff;
		int doctorAttainment = doctor.CalcHealAttainment(EHealActionType.Detox);
		doctorAttainment *= attainmentBonus;
		healMarkCount = 0;
		healPoisonValue = 0;
		for (sbyte type = 0; type < 6; type++)
		{
			int poison = poisons[type];
			if (poison > 0)
			{
				sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poison);
				int requireAttainment = CFormula.CalcHealPoisonRequireAttainment(poisonLevel);
				int healValue = CFormula.CalcHealPoisonValue(doctorAttainment, requireAttainment);
				if (healValue > 0)
				{
					CValueModify typeDebuff = debuff + doctor.GetFeatureBonusDetoxPoison(type);
					healValue *= typeDebuff;
					int oldPoison = oldPoisons[type];
					int newPoison = poison - oldPoison;
					if (healValue < newPoison)
					{
						healValue = Math.Min(healValue * buff, newPoison);
					}
					healValue = ApplyReducePoisonEffect(patientId, type, healValue, getCost);
					healValue = Math.Min(healValue, canHealOld ? poison : (poison - oldPoison));
					poisons[type] -= healValue;
					healMarkCount += poisonLevel - PoisonsAndLevels.CalcPoisonedLevel(poison - healValue);
					healPoisonValue += healValue;
				}
			}
		}
		return poisons;
	}

	private void HealPoisonCalcOriginal(int patientId, out PoisonInts poisons, out PoisonInts oldPoisons)
	{
		if (IsCharInCombat(patientId))
		{
			CombatCharacter combatChar = _combatCharacterDict[patientId];
			poisons = combatChar.GetPoison();
			oldPoisons = combatChar.GetOldPoison();
		}
		else
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(patientId);
			poisons = (oldPoisons = character.GetPoisoned());
		}
	}

	private (CValueModify buff, CValueModify debuff) HealPoisonCalcExtraAddPercent(int patientId, GameData.Domains.Character.Character doctor, bool checkHerb, PoisonInts poisons, bool getCost)
	{
		CValueModify buff = CValueModify.Zero;
		CValueModify debuff = CValueModify.Zero;
		if (IsCharInCombat(patientId))
		{
			CombatCharacter doctorChar = _combatCharacterDict[doctor.GetId()];
			if (doctorChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.HealPoison)
			{
				buff = buff.ChangeB(DomainManager.SpecialEffect.GetModifyValue(patientId, 184, EDataModifyType.Add, 7));
			}
		}
		buff += DomainManager.SpecialEffect.GetModify(doctor.GetId(), 122, getCost ? 1 : 0);
		debuff += DomainManager.SpecialEffect.GetModify(doctor.GetId(), 123, getCost ? 1 : 0);
		if (!checkHerb)
		{
			return (buff: buff, debuff: debuff);
		}
		int needHerb = GetHealPoisonCostHerb(poisons);
		int hasHerb = doctor.GetResource(5);
		if (needHerb > hasHerb)
		{
			debuff = debuff.ChangeB(-(int)CValuePercent.Parse(needHerb - hasHerb, needHerb));
		}
		return (buff: buff, debuff: debuff);
	}

	public short HealQiDisorder(int patientId, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		short qiDisorder = DomainManager.Character.GetElement_Objects(patientId).GetDisorderOfQi();
		int doctorAttainment = doctor.CalcHealAttainment(EHealActionType.Breathing);
		doctorAttainment *= attainmentBonus;
		int requireAttainment = GetHealQiDisorderRequireAttainment(patientId);
		int healValue = CFormula.CalcHealQiDisorderValue(doctorAttainment, requireAttainment);
		return (short)Math.Clamp(qiDisorder - healValue, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue);
	}

	public short HealHealth(int patientId, GameData.Domains.Character.Character doctor, CValuePercentBonus attainmentBonus = default(CValuePercentBonus))
	{
		int doctorAttainment = doctor.CalcHealAttainment(EHealActionType.Recover);
		doctorAttainment *= attainmentBonus;
		GameData.Domains.Character.Character patient = DomainManager.Character.GetElement_Objects(patientId);
		short health = patient.GetHealth();
		int requireAttainment = GetHealHealthRequireAttainment(patientId);
		int healValue = CFormula.CalcHealHealthValue(doctorAttainment, requireAttainment);
		return (short)Math.Clamp(health + healValue, 0, Math.Max((int)patient.GetLeftMaxHealth(), 0));
	}

	public static bool IsSwordFragment(ItemKey itemKey)
	{
		return itemKey.ItemType == 12 && SharedConstValue.SwordFragment2BossId.ContainsKey(itemKey.TemplateId);
	}

	[DomainMethod]
	public List<short> RequestSwordFragmentSkillIds()
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<short> result = null;
		foreach (ItemKey itemKey in taiwuChar.GetInventory().Items.Keys.Where(IsSwordFragment))
		{
			short skillId = DomainManager.Item.GetSwordFragmentCurrSkill(itemKey);
			if (skillId >= 0)
			{
				if (result == null)
				{
					result = new List<short>();
				}
				result.Add(skillId);
			}
		}
		return result;
	}

	[DomainMethod]
	public List<ItemDisplayData> RequestValidItemsInCombat(int charId)
	{
		if (!IsCharInCombat(charId))
		{
			return null;
		}
		CombatCharacter combatChar = GetElement_CombatCharacterDict(charId);
		List<ItemDisplayData> result = null;
		foreach (var (itemKey2, count) in combatChar.GetValidItemAndCounts())
		{
			if (result == null)
			{
				result = new List<ItemDisplayData>();
			}
			ItemDisplayData data = (itemKey2.IsValid() ? DomainManager.Item.GetItemDisplayData(itemKey2, charId) : new ItemDisplayData(itemKey2.ItemType, itemKey2.TemplateId));
			data.Amount = count;
			result.Add(data);
		}
		return result;
	}

	[DomainMethod]
	public void UseItem(DataContext context, ItemKey itemKey, sbyte useType = -1, bool isAlly = true, List<sbyte> targetBodyParts = null)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (!combatChar.GetCanUseItem() || !combatChar.GetValidItems().Contains(itemKey))
		{
			return;
		}
		int costWisdom = itemKey.GetConsumedFeatureMedals();
		if (costWisdom <= (isAlly ? _selfTeamWisdomCount : _enemyTeamWisdomCount))
		{
			bool needUpdate = !combatChar.HasDoingOrReserveCommand();
			combatChar.SetNeedUseItem(context, itemKey);
			combatChar.ItemUseType = useType;
			combatChar.ItemTargetBodyParts = targetBodyParts;
			combatChar.MoveData.ResetJumpState(context);
			if (needUpdate)
			{
				UpdateAllCommandAvailability(context, combatChar);
			}
			else
			{
				UpdateCanUseItem(context, combatChar);
			}
		}
	}

	[DomainMethod]
	public void RepairItem(DataContext context, ItemKey toolKey, ItemKey targetKey, bool isAlly = true)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.GetCanUseItem())
		{
			bool needUpdate = !combatChar.HasDoingOrReserveCommand();
			combatChar.SetNeedUseItem(context, toolKey);
			combatChar.NeedRepairItem = targetKey;
			combatChar.MoveData.ResetJumpState(context);
			if (needUpdate)
			{
				UpdateAllCommandAvailability(context, combatChar);
			}
			else
			{
				UpdateCanUseItem(context, combatChar);
			}
		}
	}

	[DomainMethod]
	public void UseSpecialItem(DataContext context, sbyte itemType, short templateId, bool isAlly = true)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		ItemKey? specialItemKey = null;
		foreach (ItemKey itemKey in combatChar.GetValidItems())
		{
			if (itemKey.TemplateEquals(itemType, templateId))
			{
				specialItemKey = itemKey;
			}
		}
		if (specialItemKey.HasValue)
		{
			UseItem(context, specialItemKey.Value, -1);
		}
	}

	public bool IsInfectedCombat()
	{
		GameData.Domains.Character.Character enemyChar = GetMainCharacter(isAlly: false).GetCharacter();
		if (enemyChar.GetCreatingType() != 1)
		{
			return false;
		}
		if (!enemyChar.IsCompletelyInfected())
		{
			return false;
		}
		return CombatConfig.TemplateId == 193;
	}

	public void ChangeWisdom(DataContext context, bool isAlly, int delta)
	{
		short value = (isAlly ? _selfTeamWisdomCount : _enemyTeamWisdomCount);
		short newValue = (short)Math.Clamp(value + delta, 0, 32767);
		if (newValue != value)
		{
			if (isAlly)
			{
				SetSelfTeamWisdomCount(newValue, context);
			}
			else
			{
				SetEnemyTeamWisdomCount(newValue, context);
			}
		}
	}

	public bool CostWisdom(DataContext context, bool isAlly, int costValue)
	{
		short value = (isAlly ? _selfTeamWisdomCount : _enemyTeamWisdomCount);
		if (value < costValue || costValue <= 0)
		{
			return false;
		}
		short newValue = (short)Math.Clamp(value - costValue, 0, 32767);
		if (isAlly)
		{
			SetSelfTeamWisdomCount(newValue, context);
		}
		else
		{
			SetEnemyTeamWisdomCount(newValue, context);
		}
		Events.RaiseWisdomCosted(context, isAlly, costValue);
		return true;
	}

	public void InitEquipmentDurability()
	{
		EquipmentOldDurability.Clear();
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			foreach (ItemKey key in from x in combatChar.GetCharacter().GetEquipment()
				where x.IsValid()
				select x)
			{
				EquipmentOldDurability.Add(key, DomainManager.Item.GetBaseItem(key).GetCurrDurability());
			}
		}
	}

	public void EnsureOldDurability(ItemKey key)
	{
		if (key.IsValid())
		{
			short currDurability = DomainManager.Item.GetBaseItem(key).GetCurrDurability();
			if (EquipmentOldDurability.ContainsKey(key))
			{
				EquipmentOldDurability[key] = Math.Max(EquipmentOldDurability[key], currDurability);
			}
		}
	}

	private void UpdateCanUseItem(DataContext context, CombatCharacter character)
	{
		if (!character.GetCanUseItem())
		{
			character.SetCanUseItem(canUseItem: true, context);
			if (character.IsAlly)
			{
				UpdateShowUseSpecialMisc(context);
			}
		}
	}

	public void ClearShowUseSpecialMisc(DataContext context)
	{
		SetShowUseGoldenWire(0, context);
	}

	public void UpdateShowUseSpecialMisc(DataContext context)
	{
		UpdateShowUseGoldenWire(context);
	}

	private bool CalcShowUseSpecialMiscCommon(short miscTemplateId)
	{
		if (!IsMainCharacter(_selfChar) || !IsMainCharacter(_enemyChar))
		{
			return false;
		}
		if (!_selfChar.GetCanUseItem())
		{
			return false;
		}
		if (_selfChar.GetCharacter().GetInventory().GetInventoryItemCount(12, miscTemplateId) == 0)
		{
			return false;
		}
		if (_enemyChar.TeammateBeforeMainChar >= 0)
		{
			return false;
		}
		MiscItem config = Config.Misc.Instance[miscTemplateId];
		List<short> requireCombatConfig = config.RequireCombatConfig;
		if (requireCombatConfig != null && requireCombatConfig.Count > 0 && !config.RequireCombatConfig.Contains(CombatConfig.TemplateId))
		{
			return false;
		}
		return _currentDistance <= config.MaxUseDistance;
	}

	private void UpdateShowUseGoldenWire(DataContext context)
	{
		if (_selfChar != null && _enemyChar != null)
		{
			short miscTemplateId = 275;
			int chance = (CalcShowUseSpecialMiscCommon(miscTemplateId) ? CalcRopeHitOdds(Config.Misc.Instance[miscTemplateId].Grade) : 0);
			if (_showUseGoldenWire != chance)
			{
				SetShowUseGoldenWire(chance, context);
			}
		}
	}

	private static int CalcCaptureRateBonus(ItemKey equipKey)
	{
		return (equipKey.ItemType == 2) ? Config.Accessory.Instance[equipKey.TemplateId].BaseCaptureRateBonus : DomainManager.Item.GetElement_Carriers(equipKey.Id).GetCaptureRateBonus();
	}

	public bool CheckRopeHit(IRandomSource random, int ropeGrade)
	{
		int hitOdds = CalcRopeHitOdds(ropeGrade);
		return random.CheckPercentProb(hitOdds);
	}

	private int CalcRopeHitOdds(int ropeGrade)
	{
		CombatCharacter enemyChar = GetCombatCharacter(isAlly: false, tryGetCoverCharacter: true);
		int markCount = enemyChar.GetDefeatMarkCollection().GetTotalCount();
		sbyte requireMarkCount = CFormula.CalcRopeRequireMinMarkCount((CombatType)_combatType);
		if (!IsMainCharacter(enemyChar) || enemyChar.TeammateBeforeMainChar >= 0 || enemyChar.BossConfig != null)
		{
			return 0;
		}
		GameData.Domains.Character.Character enemyCharObj = enemyChar.GetCharacter();
		if (!Config.Character.Instance[enemyCharObj.GetTemplateId()].CanBeKidnapped || CombatConfig.CaptureRate <= 0)
		{
			return 0;
		}
		if (_selfChar.GetCharacter().GetConsummateLevel() >= enemyChar.GetCharacter().GetConsummateLevel() + 6)
		{
			return 100;
		}
		if (markCount < requireMarkCount)
		{
			return 0;
		}
		HitOrAvoidInts hitValues = _selfChar.GetCharacter().GetHitValues();
		HitOrAvoidInts avoidValues = enemyChar.GetCharacter().GetAvoidValues();
		ItemKey[] equipments = _selfChar.GetCharacter().GetEquipment();
		int totalHit = 0;
		int totalAvoid = 0;
		int bonus = _selfChar.GetCharacter().WorkingCarrierCaptureRateBonus;
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			totalHit += hitValues[hitType];
			totalAvoid += avoidValues[hitType];
		}
		totalAvoid = Math.Max(totalAvoid, 1);
		for (int i = 0; i < AddCaptureRateEquipSlot.Length; i++)
		{
			ItemKey equipKey = equipments[AddCaptureRateEquipSlot[i]];
			if (equipKey.IsValid())
			{
				EquipmentBase equipment = DomainManager.Item.GetBaseEquipment(equipKey);
				if (equipment.GetCurrDurability() > 0)
				{
					bonus += CalcCaptureRateBonus(equipKey);
				}
			}
		}
		if (ropeGrade >= 0)
		{
			bonus += GlobalConfig.Instance.CaptureRatePerRopeGrade * (ropeGrade + 1);
		}
		sbyte baseHitOdds = CFormula.CalcRopeBaseHitOdds((CombatType)_combatType);
		int hitOdds = CFormula.FormulaCalcRopeHitOdds(baseHitOdds, requireMarkCount, totalHit, totalAvoid, bonus, markCount);
		if (ropeGrade >= 0)
		{
			hitOdds = hitOdds * CombatConfig.CaptureRate / 100;
		}
		return hitOdds;
	}

	public unsafe static bool CheckRopeHitOutOfCombat(IRandomSource random, GameData.Domains.Character.Character useChar, GameData.Domains.Character.Character targetChar, sbyte combatType, bool useMaxMarkCount = true, int ropeGrade = -1)
	{
		int markCount = (useMaxMarkCount ? GlobalConfig.NeedDefeatMarkCount[combatType] : GetDefeatMarksCountOutOfCombat(targetChar));
		sbyte requireMarkCount = CFormula.CalcRopeRequireMinMarkCount((CombatType)combatType);
		if (markCount < requireMarkCount)
		{
			return false;
		}
		if (!Config.Character.Instance[targetChar.GetTemplateId()].CanBeKidnapped)
		{
			return false;
		}
		HitOrAvoidInts hitValues = useChar.GetHitValues();
		HitOrAvoidInts avoidValues = targetChar.GetAvoidValues();
		ItemKey[] equipments = useChar.GetEquipment();
		sbyte baseHitOdds = CFormula.CalcRopeBaseHitOdds((CombatType)combatType);
		int totalHit = 0;
		int totalAvoid = 0;
		int bonus = useChar.WorkingCarrierCaptureRateBonus;
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			totalHit += hitValues.Items[hitType];
			totalAvoid += avoidValues.Items[hitType];
		}
		totalAvoid = Math.Max(totalAvoid, 1);
		for (int i = 0; i < AddCaptureRateEquipSlot.Length; i++)
		{
			ItemKey equipKey = equipments[AddCaptureRateEquipSlot[i]];
			if (equipKey.IsValid())
			{
				EquipmentBase equipment = DomainManager.Item.GetBaseEquipment(equipKey);
				if (equipment.GetCurrDurability() > 0)
				{
					bonus += CalcCaptureRateBonus(equipKey);
				}
			}
		}
		if (ropeGrade >= 0)
		{
			bonus += GlobalConfig.Instance.CaptureRatePerRopeGrade * (ropeGrade + 1);
		}
		int hitOdds = CFormula.FormulaCalcRopeHitOdds(baseHitOdds, requireMarkCount, totalHit, totalAvoid, bonus, markCount);
		return random.CheckPercentProb(hitOdds);
	}

	public void ChangeEquipmentPowerInCombat(int charId, int delta)
	{
		EquipmentPowerChangeInCombat[charId] = EquipmentPowerChangeInCombat.GetOrDefault(charId) + delta;
	}

	[DomainMethod]
	public List<CombatQuickUseItemSlotData> GetCombatQuickUseItemSlotData()
	{
		if (_combatQuickUseItemSlotDataList.Count == 0)
		{
			for (int i = 0; i < 9; i++)
			{
				_combatQuickUseItemSlotDataList.Add(new CombatQuickUseItemSlotData());
			}
		}
		return _combatQuickUseItemSlotDataList;
	}

	[DomainMethod]
	public void SetCombatQuickUseItemSlotData(DataContext context, List<CombatQuickUseItemSlotData> list)
	{
		SetCombatQuickUseItemSlotDataList(list, context);
	}

	[DomainMethod]
	public void ChangeWeapon(DataContext context, int weaponIndex, bool isAlly = true, bool forceChange = false)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		ItemKey itemKey = combatChar.GetWeapons()[weaponIndex];
		if (TryGetElement_WeaponDataDict(itemKey.Id, out var data) && (data.GetCanChangeTo() || forceChange))
		{
			bool needUpdate = !combatChar.HasDoingOrReserveCommand();
			combatChar.SetNeedChangeWeaponIndex(context, weaponIndex);
			if (needUpdate)
			{
				UpdateAllCommandAvailability(context, combatChar);
			}
		}
	}

	[DomainMethod]
	public void NormalAttack(DataContext context, bool isAlly = true)
	{
		if (CanAcceptCommand() && CanNormalAttack(isAlly))
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			combatChar.SetReserveNormalAttack(reserveNormalAttack: true, context);
			UpdateAllCommandAvailability(context, combatChar);
		}
	}

	[DomainMethod]
	public void NormalAttackImmediate(DataContext context, bool isAlly = true)
	{
		if (CanAcceptCommand() && CanNormalAttack(isAlly))
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			if (combatChar.CanNormalAttackImmediate)
			{
				combatChar.NeedNormalAttackImmediate = true;
				UpdateAllCommandAvailability(context, combatChar);
			}
		}
	}

	[DomainMethod]
	public void UnlockAttack(DataContext context, int index, bool isAlly = true)
	{
		if (CanAcceptCommand() && CanUnlockAttack(isAlly, index))
		{
			(isAlly ? _selfChar : _enemyChar).SetNeedUnlockWeaponIndex(context, index);
		}
	}

	[DomainMethod]
	public ChangeTrickDisplayData GetChangeTrickDisplayData(bool isAlly = true)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(combatChar).Id);
		sbyte pointCost = weapon.GetAttackPreparePointCost();
		return new ChangeTrickDisplayData
		{
			CanChangeTrick = (combatChar.GetChangeTrickCount() > pointCost),
			CostCount = (sbyte)(pointCost + 1),
			AddHitRate = (short)(100 + GlobalConfig.Instance.AttackChangeTrickHitValueAddPercent[pointCost]),
			AddBreakBlock = GlobalConfig.Instance.AttackChangeTrickCostBlockBasePercent[pointCost]
		};
	}

	[DomainMethod]
	public void StartChangeTrick(DataContext context, bool isAlly = true)
	{
		if (CanAcceptCommand())
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			if (combatChar.GetCanChangeTrick())
			{
				combatChar.SetNeedShowChangeTrick(context, needShowChangeTrick: true);
				UpdateAllCommandAvailability(context, combatChar);
			}
		}
	}

	[DomainMethod]
	public void SelectChangeTrick(DataContext context, sbyte trickType, sbyte bodyPart, int flawOrAcupointType)
	{
		_selfChar.PlayerChangeTrickType = trickType;
		_selfChar.PlayerChangeTrickBodyPart = bodyPart;
		SelectChangeTrick(context, trickType, bodyPart, isAlly: true, (EFlawOrAcupointType)flawOrAcupointType);
	}

	public void SelectChangeTrick(DataContext context, sbyte trickType, sbyte bodyPart, bool isAlly = true, EFlawOrAcupointType flawOrAcupointType = EFlawOrAcupointType.None)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.SetNeedShowChangeTrick(context, needShowChangeTrick: false);
		int costChangeTrickCount = CFormulaHelper.CalcCostChangeTrickCount(combatChar, flawOrAcupointType);
		if (combatChar.GetChangeTrickCount() >= costChangeTrickCount)
		{
			ChangeChangeTrickCount(context, combatChar, -costChangeTrickCount, bySelectChangeTrick: true);
			combatChar.NeedChangeTrickAttack = true;
			combatChar.ChangeTrickType = trickType;
			combatChar.ChangeTrickBodyPart = bodyPart;
			combatChar.ChangeTrickFlawOrAcupointType = flawOrAcupointType;
			combatChar.MoveData.ResetJumpState(context);
			UpdateAllCommandAvailability(context, combatChar);
		}
	}

	[DomainMethod]
	public void CancelChangeTrick(DataContext context, bool isAlly = true)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		combatChar.SetNeedShowChangeTrick(context, needShowChangeTrick: false);
		if (combatChar.StateMachine.GetCurrentStateType() != CombatCharacterStateType.SelectChangeTrick)
		{
			UpdateAllCommandAvailability(context, combatChar);
		}
	}

	[DomainMethod]
	public void ChangeTaiwuWeaponInnerRatio(DataContext context, int index, sbyte expectInnerRatio)
	{
		if (index < 3)
		{
			ItemKey[] equipment = DomainManager.Taiwu.GetTaiwu().GetEquipment();
			ItemKey item = equipment[index];
			if (item.TemplateId >= 0)
			{
				DomainManager.Taiwu.SetWeaponInnerRatiosById(context, item.Id, expectInnerRatio);
			}
			return;
		}
		if (1 == 0)
		{
		}
		short num = index switch
		{
			3 => 0, 
			4 => 1, 
			5 => 2, 
			_ => 884, 
		};
		if (1 == 0)
		{
		}
		short templateId = num;
		DomainManager.Taiwu.SetWeaponInnerRatiosByTemplateId(context, templateId, expectInnerRatio);
	}

	[DomainMethod]
	public void ChangeTaiwuWeaponInnerRatioByWeaponKey(DataContext context, ItemKey itemKey, sbyte expectInnerRatio)
	{
		if (itemKey.Id >= 0 && itemKey.TemplateId >= 0)
		{
			DomainManager.Taiwu.SetWeaponInnerRatiosById(context, itemKey.Id, expectInnerRatio);
		}
	}

	[DomainMethod]
	public sbyte GetWeaponInnerRatio(ItemKey weaponKey)
	{
		int taiwuWeaponIndex = (IsCharInCombat(_selfTeam[0]) ? _combatCharacterDict[_selfTeam[0]].GetWeapons().IndexOf(weaponKey) : (-1));
		return (taiwuWeaponIndex >= 0) ? DomainManager.Taiwu.GetWeaponCurrInnerRatios()[taiwuWeaponIndex] : Config.Weapon.Instance[weaponKey.TemplateId].DefaultInnerRatio;
	}

	[DomainMethod]
	public IntPair GetWeaponExpectInnerRatio(ItemKey weaponKey)
	{
		sbyte value;
		sbyte expect = (DomainManager.Taiwu.TryGetElement_WeaponInnerRatiosById(weaponKey.Id, out value) ? value : Config.Weapon.Instance[weaponKey.TemplateId].DefaultInnerRatio);
		short innerRatio = DomainManager.Taiwu.GetTaiwu().GetInnerRatio();
		return new IntPair(expect, innerRatio);
	}

	public List<WeaponEffectDisplayData> GetWeaponEffects(ItemKey weaponKey)
	{
		List<WeaponEffectDisplayData> result = new List<WeaponEffectDisplayData>();
		if (!IsInCombat() || !TryGetElement_WeaponDataDict(weaponKey.Id, out var weaponData))
		{
			return result;
		}
		int charId = weaponData.Character.GetId();
		SkillEffectKey autoAttackEffect = weaponData.GetAutoAttackEffect();
		if (autoAttackEffect.SkillId >= 0)
		{
			result.Add(autoAttackEffect.GetWeaponEffectDisplayData(charId));
		}
		foreach (SkillEffectKey pestleEffect in weaponData.GetPestleEffect())
		{
			if (pestleEffect.SkillId >= 0)
			{
				result.Add(pestleEffect.GetWeaponEffectDisplayData(charId));
			}
		}
		return result;
	}

	private void InitWeaponData(DataContext context)
	{
		ClearWeaponDataDict();
		foreach (CombatCharacter character in _combatCharacterDict.Values)
		{
			for (int i = 0; i < 7; i++)
			{
				InitWeaponData(context, character, i);
			}
			ChangeToFirstAvailableWeaponByInit(context, character);
			character.SetAnimationToLoop(character.GetIdleAni(), context);
		}
	}

	public void InitWeaponData(DataContext context, CombatCharacter character, int index)
	{
		ItemKey weaponKey = character.GetWeapons()[index];
		if (weaponKey.IsValid())
		{
			List<sbyte> weaponTricks = DomainManager.Item.GetWeaponTricks(weaponKey);
			CombatWeaponData weaponData = new CombatWeaponData(weaponKey, character);
			sbyte[] trickList = weaponData.GetWeaponTricks();
			AddElement_WeaponDataDict(weaponKey.Id, weaponData);
			weaponData.Init(context, index);
			for (int i = 0; i < weaponTricks.Count; i++)
			{
				trickList[i] = weaponTricks[i];
			}
		}
	}

	public void RemoveWeaponData(ItemKey weaponKey)
	{
		RemoveElement_WeaponDataDict(weaponKey.Id);
	}

	public void ChangeWeapon(DataContext context, CombatCharacter character, int weaponIndex, bool init = false, bool force = false)
	{
		ItemKey[] weapons = character.GetWeapons();
		int oldWeaponIndex = character.GetUsingWeaponIndex();
		int oldWeaponKeyId = (weapons.CheckIndex(oldWeaponIndex) ? weapons[oldWeaponIndex].Id : (-1));
		if ((!force || !DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 181, dataValue: false, oldWeaponKeyId)) && weaponIndex >= 0 && weapons[weaponIndex].IsValid())
		{
			CombatWeaponData weaponData = character.GetWeaponData(weaponIndex);
			if (oldWeaponIndex >= 0 && oldWeaponIndex != 3)
			{
				character.GetWeaponData(oldWeaponIndex).SetCdFrame(30000, context);
			}
			character.SetNeedChangeWeaponIndex(context, -1);
			character.SetUsingWeaponIndex(weaponIndex, context);
			character.SetWeaponTricks(weaponData.GetWeaponTricks(), context);
			character.SetChangeTrickAttack(changeTrickAttack: false, context);
			character.SetReserveNormalAttack(reserveNormalAttack: false, context);
			if (!init)
			{
				UpdateAllCommandAvailability(context, character);
				SetProperLoopAniAndParticle(context, character);
				Events.RaiseChangeWeapon(context, character.GetId(), character.IsAlly, weaponData, (oldWeaponIndex >= 0) ? character.GetWeaponData(oldWeaponIndex) : null);
			}
		}
	}

	private void ChangeToFirstAvailableWeaponByInit(DataContext context, CombatCharacter character)
	{
		ItemKey[] weapons = character.GetWeapons();
		List<int> indexes = ObjectPool<List<int>>.Instance.Get();
		int preferIndex = (character.IsTaiwu ? _preferWeaponIndex : (-1));
		if (weapons.CheckIndex(preferIndex))
		{
			indexes.Add(preferIndex);
		}
		for (int i = 0; i < weapons.Length; i++)
		{
			if (preferIndex != i)
			{
				indexes.Add(i);
			}
		}
		foreach (int i2 in indexes)
		{
			if (TryGetElement_WeaponDataDict(weapons[i2].Id, out var data) && data.GetCanChangeTo())
			{
				ChangeWeapon(context, character, i2, init: true);
				break;
			}
		}
		ObjectPool<List<int>>.Instance.Return(indexes);
	}

	public void UpdateWeaponCanChange(DataContext context, CombatCharacter character)
	{
		ItemKey[] weapons = character.GetWeapons();
		for (int i = 0; i < weapons.Length; i++)
		{
			if (weapons[i].IsValid())
			{
				UpdateWeaponCanChange(context, character, i);
			}
		}
	}

	private void UpdateWeaponCanChange(DataContext context, CombatCharacter character, int index)
	{
		bool allowUseFreeWeapon = Config.Character.Instance[character.GetCharacter().GetTemplateId()].AllowUseFreeWeapon;
		CombatWeaponData weaponData = character.GetWeaponData(index);
		bool canChange = index != character.GetUsingWeaponIndex() && !character.PreparingTeammateCommand() && ((index >= 3 && allowUseFreeWeapon) || weaponData.GetDurability() > 0) && weaponData.NotInAnyCd;
		if (weaponData.GetCanChangeTo() != canChange)
		{
			weaponData.SetCanChangeTo(canChange, context);
		}
	}

	public int GetWeaponCharId(int itemId)
	{
		CombatWeaponData data;
		return _weaponDataDict.TryGetValue(itemId, out data) ? data.Character.GetId() : (-1);
	}

	public CombatWeaponData GetUsingWeaponData(CombatCharacter character)
	{
		return _weaponDataDict[GetUsingWeaponKey(character).Id];
	}

	public ItemKey GetUsingWeaponKey(CombatCharacter character)
	{
		int weaponIndex = character.GetUsingWeaponIndex();
		weaponIndex = DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 82, weaponIndex);
		return character.GetWeapons()[weaponIndex];
	}

	public GameData.Domains.Item.Weapon GetUsingWeapon(CombatCharacter combatChar)
	{
		return DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(combatChar).Id);
	}

	public bool CanNormalAttack(bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		return !combatChar.GetReserveNormalAttack() && CanNormalAttackWithoutCommandPrepareValueCheck(isAlly);
	}

	private bool CanNormalAttackWithoutCommandPrepareValueCheck(bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.ForbidNormalAttackEffectCount > 0)
		{
			return false;
		}
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(combatChar).Id);
		return weapon.GetMaxDurability() <= 0 || weapon.GetCurrDurability() != 0;
	}

	private bool CanUnlockAttack(bool isAlly, int index)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		List<bool> canUnlockAttack = combatChar.GetCanUnlockAttack();
		return canUnlockAttack.CheckIndex(index) && canUnlockAttack[index];
	}

	public void UnlockAttack(DataContext context, CombatCharacter combatChar, int index)
	{
		combatChar.ChangeUnlockAttackValue(context, index, -GlobalConfig.Instance.UnlockAttackUnit);
		combatChar.NeedUnlockAttack = true;
		combatChar.UnlockWeaponIndex = index;
		combatChar.MoveData.ResetJumpState(context);
		UpdateAllCommandAvailability(context, combatChar);
		Events.RaiseUnlockAttack(context, combatChar, index);
		combatChar.DoExtraUnlockEffect(context, index);
	}

	public sbyte GetAttackHitType(CombatCharacter attacker, sbyte trickType)
	{
		return GetAttackHitType(attacker.GetCharacter(), trickType);
	}

	public unsafe sbyte GetAttackHitType(GameData.Domains.Character.Character attacker, sbyte trickType)
	{
		if (trickType != 21)
		{
			return Config.TrickType.Instance[trickType].AvoidType;
		}
		HitOrAvoidInts hitValues = attacker.GetHitValues();
		List<sbyte> hitTypeRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		int maxHitValue = int.MinValue;
		hitTypeRandomPool.Clear();
		for (sbyte type = 0; type < 4; type++)
		{
			int hitValue = hitValues.Items[type];
			if (hitValue > maxHitValue)
			{
				maxHitValue = hitValue;
				hitTypeRandomPool.Clear();
				hitTypeRandomPool.Add(type);
			}
			else if (hitValue == maxHitValue)
			{
				hitTypeRandomPool.Add(type);
			}
		}
		sbyte hitType = hitTypeRandomPool[Context.Random.Next(hitTypeRandomPool.Count)];
		ObjectPool<List<sbyte>>.Instance.Return(hitTypeRandomPool);
		return hitType;
	}

	public void UpdateWeaponCd(DataContext context, CombatCharacter character)
	{
		ItemKey[] weapons = character.GetWeapons();
		for (int i = 0; i < weapons.Length; i++)
		{
			if (!weapons[i].IsValid())
			{
				continue;
			}
			CombatWeaponData weaponData = character.GetWeaponData(i);
			if (!weaponData.NotInAnyCd)
			{
				if (weaponData.GetFixedCdLeftFrame() > 0)
				{
					weaponData.SetFixedCdLeftFrame((short)Math.Max(weaponData.GetFixedCdLeftFrame() - 1, 0), context);
				}
				else if (weaponData.GetCdFrame() > 0)
				{
					int weight = weaponData.Item.GetWeight();
					int switchSpeed = character.GetCharacter().GetWeaponSwitchSpeed();
					int cdSpeed = CFormula.CalcWeaponCdFrameSpeed(switchSpeed, weight);
					weaponData.SetCdFrame((short)Math.Max(weaponData.GetCdFrame() - cdSpeed, 0), context);
				}
				if (weaponData.NotInAnyCd)
				{
					UpdateWeaponCanChange(context, character, i);
					Events.RaiseWeaponCdEnd(context, character.GetId(), character.IsAlly, weaponData);
				}
			}
		}
	}

	public void ChangeWeaponCd(DataContext context, CombatCharacter character, int index, CValuePercent addPercent)
	{
		CombatWeaponData weaponData = character.GetWeaponData(index);
		int addValue = 30000 * addPercent;
		short newCd = (short)Math.Clamp(weaponData.GetCdFrame() + addValue, 0, 30000);
		bool hasCd = weaponData.GetCdFrame() > 0;
		weaponData.SetCdFrame(newCd, context);
		UpdateWeaponCanChange(context, character, index);
		if (hasCd && weaponData.NotInAnyCd)
		{
			Events.RaiseWeaponCdEnd(context, character.GetId(), character.IsAlly, weaponData);
		}
	}

	public void ClearAllWeaponCd(DataContext context, CombatCharacter character)
	{
		foreach (CombatWeaponData weaponData in _weaponDataDict.Values)
		{
			if (weaponData.Character == character && !weaponData.NotInAnyCd)
			{
				weaponData.SetCdFrame(0, context);
				weaponData.SetFixedCdLeftFrame(0, context);
				if (weaponData.NotInAnyCd)
				{
					Events.RaiseWeaponCdEnd(context, character.GetId(), character.IsAlly, weaponData);
				}
			}
		}
	}

	public void ClearWeaponCd(DataContext context, CombatCharacter character, int index)
	{
		CombatWeaponData weaponData = character.GetWeaponData(index);
		if (!weaponData.NotInAnyCd)
		{
			weaponData.SetCdFrame(0, context);
			weaponData.SetFixedCdLeftFrame(0, context);
			Events.RaiseWeaponCdEnd(context, character.GetId(), character.IsAlly, weaponData);
		}
	}

	public void SilenceWeapon(DataContext context, CombatCharacter combatChar, int weaponIndex, int cdFrame)
	{
		ItemKey itemKey = combatChar.GetWeapons()[weaponIndex];
		if (itemKey.IsValid())
		{
			if (cdFrame > 0)
			{
				(int, int) extraTotalPercent = combatChar.GetFeatureSilenceFrameTotalPercent();
				cdFrame = DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 263, cdFrame, -1, -1, -1, 0, 0, extraTotalPercent.Item1, extraTotalPercent.Item2);
			}
			short cdFrameShort = (short)Math.Clamp(cdFrame, -1, 32767);
			if (cdFrameShort != 0)
			{
				CombatWeaponData weaponData = _weaponDataDict[itemKey.Id];
				weaponData.SetFixedCdTotalFrame(cdFrameShort, context);
				weaponData.SetFixedCdLeftFrame(cdFrameShort, context);
				UpdateWeaponCanChange(context, combatChar, weaponIndex);
			}
		}
	}

	public void CalcNormalAttack(CombatContext context, sbyte trickType)
	{
		CombatCharacter attacker = context.Attacker;
		CombatCharacter defender = context.Defender;
		Events.RaiseNormalAttackBegin(context, attacker, defender, trickType, attacker.PursueAttackCount);
		ItemKey weaponKey = context.WeaponKey;
		GameData.Domains.Item.Weapon weapon = context.Weapon;
		WeaponItem configData = context.WeaponConfig;
		sbyte hitType = attacker.NormalAttackHitType;
		sbyte trickHitType = ((trickType != 21) ? Config.TrickType.Instance[trickType].AvoidType : hitType);
		bool isCarrierAnimalAttack = attacker.GetId() == _carrierAnimalCombatCharId;
		UpdateDamageCompareData(context);
		CombatProperty property = _damageCompareData.GetProperty();
		bool critical = context.CheckCritical(hitType);
		context = context.Property(property).Critical(critical);
		int hitOdds = property.HitOdds;
		hitOdds = ApplyHitOddsSpecialEffect(attacker, defender, hitOdds, hitType, -1);
		if (hitOdds > 0)
		{
			hitOdds += GlobalConfig.Instance.NormalAttackExtraHitOdds;
		}
		bool inevitableHit = DomainManager.SpecialEffect.ModifyData(attacker.GetId(), -1, 251, dataValue: false);
		bool hit = !DomainManager.SpecialEffect.ModifyData(defender.GetId(), -1, 290, dataValue: false, critical ? 1 : 0, context.BodyPart, attacker.GetId()) && (inevitableHit || hitOdds < 0 || context.Random.CheckPercentProb(hitOdds));
		bool isFightBack = context.IsFightBack;
		if (attacker.AttackForceHitCount > 0)
		{
			hit = true;
		}
		else if (attacker.AttackForceMissCount > 0)
		{
			hit = false;
		}
		Events.RaiseNormalAttackCalcHitEnd(context, attacker, defender, attacker.PursueAttackCount, hit, isFightBack, trickHitType == 3);
		Events.RaiseNormalAttackCalcCriticalEnd(context, attacker, defender, critical);
		Events.RaiseCalcLeveragingValue(context, trickHitType, hit, attacker.PursueAttackCount);
		if (hit)
		{
			sbyte breakOddsTrickType = ((trickType != 21) ? trickType : GodTrickUseTrickType[hitType]);
			sbyte breakOdds = (sbyte)((attacker.NormalAttackBodyPart >= 0) ? Config.TrickType.Instance[breakOddsTrickType].EquipmentBreakOdds : 0);
			context.CheckReduceDurability(breakOdds);
			int finalDamage = 0;
			bool addFlawOrAcupoint = false;
			if (!TrickType.NoBodyDamageTrickType.Exist(trickType))
			{
				int power = (isFightBack ? attacker.GetFightBackPower(attacker.FightBackHitType) : 100);
				if (isFightBack && power > 0 && attacker.FightBackSourceBodyPart >= 0)
				{
					ItemKey armorKey = attacker.Armors[attacker.FightBackSourceBodyPart];
					if (armorKey.IsValid() && DomainManager.Item.TryGetElement_Armors(armorKey.Id, out var fightBackArmor) && ModificationStateHelper.IsActive(fightBackArmor.GetModificationState(), 2))
					{
						int refineBonus = DomainManager.Item.GetRefinedEffects(armorKey).GetArmorPropertyBonus(ERefiningEffectArmorType.CounterDamagePower);
						refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, fightBackArmor.GetEquippedCharId());
						if (refineBonus != 0)
						{
							power = power * (100 + refineBonus) / 100;
						}
					}
				}
				OuterAndInnerInts markCounts = CalcAndAddInjury(context, hitType, out finalDamage, out critical, power);
				addFlawOrAcupoint = attacker.ApplyChangeTrickFlawOrAcupoint(context, defender, attacker.ChangeTrickBodyPart);
				bool attackPoisonSpecial = context.Attacker.ExecutingTeammateCommandImplement == ETeammateCommandImplement.AttackSpecialPoison;
				int poisonFactor = ((!attackPoisonSpecial) ? 1 : context.Attacker.ExecutingTeammateCommandConfig.IntArg);
				if (trickHitType != 3)
				{
					context.ApplyWeaponAndArmorPoison(poisonFactor, attackPoisonSpecial);
				}
				if (!attacker.IsAutoNormalAttackingSpecial && trickHitType != 3 && !isCarrierAnimalAttack)
				{
					AddBounceDamage(context, hitType);
				}
				if (CanPlayHitAnimation(defender))
				{
					int totalMarkCount = markCounts.Outer + markCounts.Inner;
					if (!attacker.NoBlockAttack && !critical)
					{
						BlockEffect blockEffect = defender.GetBlockEffect(context.Random);
						defender.SetAnimationToPlayOnce(blockEffect.AniName, context);
						defender.SetParticleToPlay(blockEffect.Particle, context);
					}
					else if (totalMarkCount > 0 || addFlawOrAcupoint)
					{
						defender.SetAnimationToPlayOnce(defender.GetBeHitAni(Math.Clamp(totalMarkCount - 1, 0, 2)), context);
					}
				}
				defender.PlayBeHitSound(context, configData, attacker, critical);
			}
			context.ApplyReduceDurabilityByHit();
			if (!defender.GetNewPoisonsToShow().IsNonZero() && !addFlawOrAcupoint && finalDamage <= 0)
			{
				defender.SetParticleToPlay("Particle_D_qidun", context);
			}
			if (defender.GetPreparingOtherAction() == 2 && _currentDistance <= InterruptFleeNeedDistance)
			{
				InterruptOtherAction(context, defender);
			}
			AddToCheckFallenSet(attacker.GetId());
			AddToCheckFallenSet(defender.GetId());
		}
		else
		{
			if (CanPlayHitAnimation(defender))
			{
				defender.SetAnimationToPlayOnce(defender.GetAvoidAni(hitType), context);
			}
			defender.SetParticleToPlay(CombatAnimationConstants.GetAvoidParticle(defender.IsAlly, hitType), context);
			string[] avoidSounds = _avoidSound[hitType];
			defender.SetHitSoundToPlay(avoidSounds[context.Random.Next(avoidSounds.Length)], context);
		}
		if (attacker.CalcNormalAttackAddTrick(context.Random, hit, hitOdds))
		{
			int trickCount = 1 * DomainManager.SpecialEffect.GetModify(attacker.GetId(), 326);
			AddTrick(context, GetCombatCharacter(attacker.IsAlly), trickType, trickCount, addedByAlly: true, !hit);
		}
		bool canFightBack = DomainManager.SpecialEffect.ModifyData(attacker.GetId(), -1, 86, dataValue: true);
		bool canFightBackWithHit = DomainManager.SpecialEffect.ModifyData(defender.GetId(), -1, 250, dataValue: false, critical ? 1 : 0);
		if (!isFightBack && !isCarrierAnimalAttack && canFightBack && CanFightBack(context, hitType) && (canFightBackWithHit || !hit))
		{
			defender.FightBackWithHit = hit;
			defender.FightBackHitType = hitType;
			defender.FightBackSourceBodyPart = context.BodyPart;
			defender.SetIsFightBack(isFightBack: true, context);
		}
		if (InAttackRange(attacker) && !attacker.IsAutoNormalAttackingSpecial)
		{
			bool isPursue = attacker.PursueAttackCount > 0;
			int addStance = configData.StanceIncrement;
			if (isPursue)
			{
				addStance *= (CValuePercent)25;
			}
			sbyte attackPreparePointCost = weapon.GetAttackPreparePointCost();
			if (attacker.GetStanceValue() < attacker.GetMaxStanceValue())
			{
				RecoverStanceValue(context, attacker, addStance, attackPreparePointCost, isPursue);
			}
			if (defender.GetStanceValue() < defender.GetMaxStanceValue())
			{
				RecoverStanceValue(context, defender, addStance / 3, attackPreparePointCost, isPursue);
			}
		}
		if (weapon.GetCanChangeTrick() && attacker.AttackForceHitCount <= 0 && attacker.AttackForceMissCount <= 0 && !attacker.GetChangeTrickAttack())
		{
			int addValue = DomainManager.Character.CalcWeaponChangeTrickValue(attacker.GetId(), weaponKey, attacker.PursueAttackCount == 0, hit);
			ChangeChangeTrickProgress(context, attacker, addValue);
		}
		if (!attacker.IsAutoNormalAttackingSpecial && attacker.PursueAttackCount == 0 && attacker.PoisonOverflow(0))
		{
			attacker.AddPoisonAffectValue(0, 1);
		}
		Events.RaiseNormalAttackEnd(context, attacker, defender, trickType, attacker.PursueAttackCount, hit, isFightBack);
	}

	public void CalcUnlockAttack(CombatCharacter attacker, int index)
	{
		IRandomSource random = Context.Random;
		CombatCharacter defender = GetCombatCharacter(!attacker.IsAlly, tryGetCoverCharacter: true);
		sbyte trickType = attacker.UnlockWeapon.GetTricks().GetRandom(random);
		sbyte hitType = GetAttackHitType(attacker, trickType);
		hitType = (sbyte)DomainManager.SpecialEffect.ModifyData(attacker.GetId(), -1, 68, hitType);
		sbyte bodyPart = GetAttackBodyPart(attacker, defender, random, -1, trickType, hitType);
		CombatContext context = CombatContext.Create(attacker, defender, bodyPart, -1, attacker.UnlockWeaponIndex).Critical(critical: true);
		attacker.NormalAttackHitType = hitType;
		attacker.NormalAttackBodyPart = bodyPart;
		Events.RaiseNormalAttackBegin(context, attacker, defender, trickType, 0);
		Events.RaiseNormalAttackCalcHitEnd(context, attacker, defender, 0, hit: true, isFightBack: false, hitType == 3);
		Events.RaiseNormalAttackCalcCriticalEnd(context, attacker, defender, critical: true);
		Events.RaiseCalcLeveragingValue(context, hitType, hit: true, index);
		if (bodyPart >= 0)
		{
			context.ApplyWeaponAndArmorPoison(attacker.UnlockEffect.PoisonRatio);
			if (attacker.UnlockEffect.FlawLevels != null && attacker.UnlockEffect.FlawLevels.Length > index)
			{
				AddFlaw(Context, defender, attacker.UnlockEffect.FlawLevels[index], (charId: -1, skillId: (short)(-1)), bodyPart);
			}
			if (attacker.UnlockEffect.AcupointLevels != null && attacker.UnlockEffect.AcupointLevels.Length > index)
			{
				AddAcupoint(Context, defender, attacker.UnlockEffect.AcupointLevels[index], (charId: -1, skillId: (short)(-1)), bodyPart);
			}
		}
		sbyte breakOdds = Config.TrickType.Instance[trickType].EquipmentBreakOdds;
		context.CheckReduceArmorDurability(breakOdds);
		int power = 100 + DomainManager.Character.GetItemPower(context.AttackerId, context.WeaponKey) / 5;
		UpdateDamageCompareData(context);
		context = context.Property(_damageCompareData.GetProperty());
		CalcAndAddInjury(context, hitType, out var _, out var _, power);
		if (hitType != 3)
		{
			AddBounceDamage(context, hitType);
		}
		context.ApplyReduceDurabilityByHit();
		if (attacker.UnlockEffect.StealNeiliAllocationPercent > 0)
		{
			attacker.StealNeiliAllocationRandom(Context, defender, attacker.UnlockEffect.StealNeiliAllocationPercent);
		}
		short banableSkillId = defender.GetRandomBanableSkillId(Context.Random, null, -1);
		if (banableSkillId >= 0 && attacker.UnlockEffect.SilenceSkillFrame > 0)
		{
			SilenceSkill(Context, defender, banableSkillId, attacker.UnlockEffect.SilenceSkillFrame);
		}
		if (attacker.UnlockEffect.AddQiDisorder > 0)
		{
			ChangeDisorderOfQiRandomRecovery(Context, defender, attacker.UnlockEffect.AddQiDisorder);
		}
		AddToCheckFallenSet(defender.GetId());
		if (defender.GetPreparingOtherAction() == 2 && _currentDistance <= InterruptFleeNeedDistance)
		{
			InterruptOtherAction(context, defender);
		}
		Events.RaiseNormalAttackEnd(context, attacker, defender, trickType, 0, hit: true, isFightBack: false);
		attacker.NormalAttackHitType = -1;
		attacker.NormalAttackBodyPart = -1;
	}

	public bool CalcSpiritAttack(CombatCharacter attacker, int index)
	{
		IRandomSource random = Context.Random;
		CombatCharacter defender = GetCombatCharacter(!attacker.IsAlly, tryGetCoverCharacter: true);
		CombatWeaponData weaponData = attacker.GetWeaponData(index);
		sbyte trickType = weaponData.GetWeaponTricks().GetRandom(random);
		sbyte hitType = DomainManager.Combat.GetAttackHitType(attacker, trickType);
		sbyte bodyPart = DomainManager.Combat.GetAttackBodyPart(attacker, defender, random, -1, trickType, hitType);
		CombatContext context = CombatContext.Create(attacker, defender, bodyPart, -1, index);
		bool prevIsChangeTrick = attacker.GetChangeTrickAttack();
		attacker.SetChangeTrickAttack(changeTrickAttack: true, context);
		attacker.IsAutoNormalAttackingSpecial = true;
		attacker.NormalAttackHitType = hitType;
		attacker.NormalAttackBodyPart = bodyPart;
		Events.RaiseNormalAttackBegin(context, attacker, defender, trickType, 0);
		Events.RaiseNormalAttackCalcHitEnd(context, attacker, defender, 0, hit: true, isFightBack: false, hitType == 3);
		Events.RaiseNormalAttackCalcCriticalEnd(context, attacker, defender, critical: true);
		Events.RaiseCalcLeveragingValue(context, hitType, hit: true, index);
		sbyte level = weaponData.Item.GetAttackPreparePointCost();
		bool hasFlawOrAcupoint = random.CheckPercentProb(50);
		if (hasFlawOrAcupoint)
		{
			if (random.CheckPercentProb(75))
			{
				AddFlaw(context, defender, level, (charId: -1, skillId: (short)(-1)), bodyPart);
			}
			else
			{
				AddAcupoint(context, defender, level, (charId: -1, skillId: (short)(-1)), bodyPart);
			}
		}
		context.ApplyWeaponAndArmorPoison();
		context = context.Critical(critical: true);
		UpdateDamageCompareData(context);
		context = context.Property(_damageCompareData.GetProperty());
		CalcAndAddInjury(context, hitType, out var _, out var critical);
		defender.PlayBeHitSound(context, weaponData.Template, attacker, critical);
		attacker.IsAutoNormalAttackingSpecial = false;
		Events.RaiseNormalAttackEnd(context, attacker, defender, trickType, 0, hit: true, isFightBack: false);
		attacker.NormalAttackHitType = -1;
		attacker.NormalAttackBodyPart = -1;
		Events.RaiseNormalAttackAllEnd(context, attacker, defender);
		attacker.SetChangeTrickAttack(prevIsChangeTrick, context);
		return hasFlawOrAcupoint;
	}

	public void AddWeaponAttackSelfInjury(DataContext context, CombatCharacter character, int weaponIndex)
	{
		CombatWeaponData weaponData = character.GetWeaponData(weaponIndex);
		GameData.Domains.Item.Weapon weapon = weaponData.Item;
		List<sbyte> trickList = weapon.GetTricks();
		sbyte trickType = trickList[context.Random.Next(0, trickList.Count)];
		sbyte hitType = GetAttackHitType(character, trickType);
		sbyte bodyPart = GetAttackBodyPart(character, character, context.Random, -1, trickType, hitType);
		CombatContext combatContext = CombatContext.Create(character, character, bodyPart, -1, weaponIndex);
		CalcAndAddInjury(combatContext, hitType, out var _, out var _);
	}

	public void ChangeChangeTrickCount(DataContext context, CombatCharacter character, int addValue, bool bySelectChangeTrick = false)
	{
		character.SetChangeTrickCount((short)Math.Clamp(character.GetChangeTrickCount() + addValue, 0, character.MaxChangeTrickCount), context);
		if (character.GetChangeTrickCount() == character.MaxChangeTrickCount && character.GetChangeTrickProgress() > 0)
		{
			character.SetChangeTrickProgress(0, context);
		}
		UpdateCanChangeTrick(context, character);
		Events.RaiseChangeTrickCountChanged(context, character, addValue, bySelectChangeTrick);
	}

	public void UpdateCanChangeTrick(DataContext context, CombatCharacter character)
	{
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(character).Id);
		bool canChangeTrick = character.GetChangeTrickCount() > weapon.GetAttackPreparePointCost() && IsCurrentCombatCharacter(character) && weapon.GetCanChangeTrick() && CanNormalAttackWithoutCommandPrepareValueCheck(character.IsAlly);
		if (character.GetCanChangeTrick() != canChangeTrick)
		{
			character.SetCanChangeTrick(canChangeTrick, context);
		}
	}

	public bool CanPursue(CombatCharacter character, bool critical)
	{
		CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly, tryGetCoverCharacter: true);
		if (!IsInCombat() || !DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 252, dataValue: true) || character.PursueAttackCount >= 5 || character.GetIsFightBack() || enemyChar.GetIsFightBack() || enemyChar.ChangeCharId >= 0 || character.ChangeCharId >= 0 || enemyChar.NeedChangeBossPhase || IsCharacterFallen(enemyChar) || IsCharacterFallen(character) || _saveDyingEffectTriggerd || character.AttackForceHitCount > 0 || character.AttackForceMissCount > 0)
		{
			return false;
		}
		if (character.IsAutoNormalAttackingSpecial)
		{
			return true;
		}
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(character).Id);
		short usePower = DomainManager.Character.GetItemPower(character.GetId(), weapon.GetItemKey());
		short pursueFactor = weapon.GetPursueAttackFactor();
		if (ModificationStateHelper.IsActive(weapon.GetModificationState(), 2))
		{
			int refineBonus = DomainManager.Item.GetRefinedEffects(weapon.GetItemKey()).GetWeaponPropertyBonus(ERefiningEffectWeaponType.PursueAttackFactor);
			refineBonus = ProfessionSkillHandle.GetRefineBonus_CraftSkill_2(refineBonus, weapon.GetEquippedCharId());
			pursueFactor = (short)(pursueFactor * (100 + refineBonus) / 100);
		}
		int pursueOdds = CFormula.FormulaCalcPursueOdds(pursueFactor, usePower, character.PursueAttackCount);
		int attackerAdd = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), 76, EDataModifyType.Add, character.PursueAttackCount);
		int defenderAdd = DomainManager.SpecialEffect.GetModifyValue(enemyChar.GetId(), 109, EDataModifyType.Add, character.PursueAttackCount);
		pursueOdds = Math.Max(pursueOdds + attackerAdd + defenderAdd, 0);
		int attackerAddPercent = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), 76, EDataModifyType.AddPercent, character.PursueAttackCount, critical ? 1 : 0);
		int defenderAddPercent = DomainManager.SpecialEffect.GetModifyValue(enemyChar.GetId(), 109, EDataModifyType.AddPercent, character.PursueAttackCount, critical ? 1 : 0);
		int percent = 100 + attackerAddPercent + defenderAddPercent;
		pursueOdds = pursueOdds * percent / 100;
		(int, int) attackerTotalPercent = DomainManager.SpecialEffect.GetTotalPercentModifyValue(character.GetId(), -1, 76);
		(int, int) defenderTotalPercent = DomainManager.SpecialEffect.GetTotalPercentModifyValue(enemyChar.GetId(), -1, 109);
		percent = 100 + Math.Max(attackerTotalPercent.Item1, defenderTotalPercent.Item1) + Math.Min(attackerTotalPercent.Item2, defenderTotalPercent.Item2);
		pursueOdds = pursueOdds * percent / 100;
		pursueOdds = DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 76, pursueOdds);
		return Context.Random.CheckPercentProb(pursueOdds);
	}

	private bool CanFightBack(CombatContext context, sbyte hitType)
	{
		CombatCharacter defender = context.Defender;
		bool canFightBackDuringPrepareSkill = DomainManager.SpecialEffect.ModifyData(defender.GetId(), -1, 193, dataValue: false);
		bool canFightBackOutOfAttackRange = DomainManager.SpecialEffect.ModifyData(context.DefenderId, -1, 340, dataValue: false);
		if (!IsCurrentCombatCharacter(defender) || IsCharacterFallen(defender) || (!InAttackRange(defender) && !canFightBackOutOfAttackRange) || hitType == 3 || (defender.GetPreparingSkillId() >= 0 && !canFightBackDuringPrepareSkill) || defender.GetPreparingOtherAction() >= 0 || defender.GetPreparingItem().IsValid() || defender.GetFightBackPower(hitType) <= 0)
		{
			return false;
		}
		return true;
	}

	public void AddRandomTrick(DataContext context, CombatCharacter combatChar, int count)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		sbyte[] weaponTricks = combatChar.GetWeaponTricks();
		for (int i = 0; i < count; i++)
		{
			tricks.Add(new NeedTrick(weaponTricks.GetRandom(context.Random), 1));
		}
		AddTrick(context, combatChar, tricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
	}

	public void AddTrick(DataContext context, CombatCharacter combatChar, sbyte trickType, bool addedByAlly = true)
	{
		AddTrick(context, combatChar, trickType, 1, addedByAlly);
	}

	public void AddTrick(DataContext context, CombatCharacter combatChar, sbyte trickType, int count, bool addedByAlly = true, bool addByAvoid = false)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		tricks.Add(new NeedTrick(trickType, (byte)Math.Clamp(count, 0, 255)));
		AddTrick(context, combatChar, tricks, addedByAlly, addByAvoid);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
	}

	public void AddTrick(DataContext context, CombatCharacter combatChar, IEnumerable<sbyte> trickTypes)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		ConvertTricks(tricks, trickTypes);
		AddTrick(context, combatChar, tricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
	}

	public void AddTrick(DataContext context, CombatCharacter character, List<NeedTrick> tricks, bool addedByAlly = true, bool addByAvoid = false)
	{
		TrickCollection trickCollection = character.GetTricks();
		int addedShaCount = 0;
		foreach (NeedTrick needTrick in tricks)
		{
			for (int i = 0; i < needTrick.NeedCount; i++)
			{
				sbyte trickType = needTrick.TrickType;
				if (DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 138, dataValue: true, trickType, addedByAlly ? 1 : 0, 1))
				{
					trickType = (sbyte)DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 139, trickType);
					trickCollection.AppendTrick(trickType, addByAvoid);
					if (trickCollection.Tricks.Count > character.GetMaxTrickCount())
					{
						RemoveOverflowTrick(context, character);
					}
					character.SetTricks(trickCollection, context);
					UpdateSkillCostTrickCanUse(context, character);
					Events.RaiseGetTrick(context, character.GetId(), character.IsAlly, trickType, character.IsTrickUsable(trickType));
					if (trickType == 19)
					{
						addedShaCount++;
					}
				}
			}
		}
		for (int j = 0; j < addedShaCount; j++)
		{
			Events.RaiseGetShaTrick(context, character.GetId(), character.IsAlly, real: true);
		}
	}

	public void RemoveOverflowTrick(DataContext context, CombatCharacter character, bool updateFieldAndSkill = false)
	{
		TrickCollection trickCollection = character.GetTricks();
		List<int> indexList = ObjectPool<List<int>>.Instance.Get();
		indexList.Clear();
		indexList.AddRange(trickCollection.Tricks.Keys);
		int removedCount = 0;
		while (trickCollection.Tricks.Count > character.GetMaxTrickCount())
		{
			trickCollection.RemoveTrick(indexList[0]);
			indexList.RemoveAt(0);
			removedCount++;
		}
		ObjectPool<List<int>>.Instance.Return(indexList);
		Events.RaiseOverflowTrickRemoved(context, character.GetId(), character.IsAlly, removedCount);
		if (updateFieldAndSkill)
		{
			character.SetTricks(trickCollection, context);
			UpdateSkillCostTrickCanUse(context, character);
		}
	}

	public void RemoveUsableTrickInsteadCostTrick([DisallowNull] CombatCharacter character, short skillId, [DisallowNull] List<NeedTrick> costTricks, [AllowNull] List<NeedTrick> costEnemyTricks = null)
	{
		costEnemyTricks?.Clear();
		bool canInstead = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 279, dataValue: false, (costEnemyTricks != null) ? 1 : 0);
		CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
		if (canInstead && enemyChar != null)
		{
			Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			Dictionary<sbyte, byte> lackTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			character.CalcCostTrickStatus(costTricks, costTrickDict, lackTrickDict);
			costTricks.Clear();
			Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			enemyChar.CalcInsteadTricks(extraDict, enemyChar.IsTrickUsable, costTrickDict, lackTrickDict);
			costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
			costEnemyTricks?.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(lackTrickDict);
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
		}
	}

	public void RemoveCostTrickInsteadUselessTrick(CombatCharacter character, short skillId, List<NeedTrick> costTricks, bool trulyCost)
	{
		if (DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 283, dataValue: false, trulyCost ? 1 : 0))
		{
			Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			Dictionary<sbyte, byte> lackTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			character.CalcCostTrickStatus(costTricks, costTrickDict, lackTrickDict);
			costTricks.Clear();
			Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
			character.CalcInsteadTricks(extraDict, character.IsTrickUseless, costTrickDict, lackTrickDict);
			costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
			costTricks.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(lackTrickDict);
			ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
		}
	}

	public void RemoveCostTrickBySelfShaTrick(DataContext context, CombatCharacter character, short skillId, List<NeedTrick> costTricks, bool trulyCost)
	{
		if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 317, dataValue: false, 1))
		{
			return;
		}
		Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		Dictionary<sbyte, byte> lackTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		character.CalcCostTrickStatus(costTricks, costTrickDict, lackTrickDict);
		costTricks.Clear();
		Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		if (costTrickDict.Keys.All((sbyte x) => x != 19))
		{
			character.CalcInsteadTricks(extraDict, (sbyte x) => x == 19, costTrickDict, lackTrickDict, int.MaxValue, onlyInsteadLack: true);
		}
		if (trulyCost && extraDict.Values.Sum((byte x) => x) > 0)
		{
			Events.RaiseShaTrickInsteadCostTricks(context, character, skillId);
		}
		costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		costTricks.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(lackTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
	}

	public void RemoveCostTrickByEnemyShaTrick(DataContext context, CombatCharacter character, short skillId, List<NeedTrick> costTricks, List<NeedTrick> costEnemyTricks = null)
	{
		bool canInstead = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 317, dataValue: false, 0);
		CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
		if (!canInstead || enemyChar == null)
		{
			return;
		}
		Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		Dictionary<sbyte, byte> lackTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		character.CalcCostTrickStatus(costTricks, costTrickDict, lackTrickDict);
		costTricks.Clear();
		Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		if (costTrickDict.Keys.All((sbyte x) => x != 19))
		{
			enemyChar.CalcInsteadTricks(extraDict, (sbyte x) => x == 19, costTrickDict, lackTrickDict, int.MaxValue, onlyInsteadLack: true);
		}
		if (costEnemyTricks != null && extraDict.Values.Sum((byte x) => x) > 0)
		{
			Events.RaiseShaTrickInsteadCostTricks(context, character, skillId);
		}
		costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		costEnemyTricks?.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(lackTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
	}

	public void RemoveCostTrickByJiTrick(DataContext context, CombatCharacter character, short skillId, List<NeedTrick> costTricks, bool trulyCost)
	{
		int maxInsteadCount = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 311, 0);
		if (maxInsteadCount <= 0)
		{
			return;
		}
		Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		Dictionary<sbyte, byte> lackTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		character.CalcCostTrickStatus(costTricks, costTrickDict, lackTrickDict);
		costTricks.Clear();
		Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		if (costTrickDict.Keys.All((sbyte x) => x != 12))
		{
			character.CalcInsteadTricks(extraDict, (sbyte x) => x == 12, costTrickDict, lackTrickDict, maxInsteadCount);
		}
		if (trulyCost)
		{
			Events.RaiseJiTrickInsteadCostTricks(context, character, extraDict.Values.Sum((byte x) => x));
		}
		costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		costTricks.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(lackTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
	}

	public void RemoveJiTrickByUselessTrick(DataContext context, CombatCharacter character, short skillId, List<NeedTrick> costTricks, bool trulyCost)
	{
		int maxInsteadCount = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 312, 0);
		maxInsteadCount = Math.Min(maxInsteadCount, costTricks.Sum((NeedTrick x) => (x.TrickType == 12) ? x.NeedCount : 0));
		if (maxInsteadCount <= 0)
		{
			return;
		}
		Dictionary<sbyte, byte> costTrickDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		foreach (NeedTrick needTrick in costTricks)
		{
			costTrickDict[needTrick.TrickType] = needTrick.NeedCount;
		}
		costTricks.Clear();
		Dictionary<sbyte, byte> extraDict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		foreach (sbyte trickType in character.GetTricks().Tricks.Values)
		{
			if (!character.IsTrickUsable(trickType))
			{
				extraDict[trickType] = (byte)Math.Min(extraDict.GetOrDefault(trickType) + 1, 255);
				costTrickDict[12]--;
				if (costTrickDict[12] <= 0)
				{
					costTrickDict.Remove(12);
					break;
				}
			}
		}
		if (trulyCost)
		{
			Events.RaiseUselessTrickInsteadJiTricks(context, character, extraDict.Values.Sum((byte x) => x));
		}
		costTricks.AddRange(costTrickDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		costTricks.AddRange(extraDict.Select((KeyValuePair<sbyte, byte> tup) => new NeedTrick(tup.Key, tup.Value)));
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(costTrickDict);
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(extraDict);
	}

	public bool RemoveTrick(DataContext context, CombatCharacter character, sbyte trickType, byte count = 1, bool removedByAlly = true, int preferIndex = -1)
	{
		List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		removeTricks.Clear();
		removeTricks.Add(new NeedTrick(trickType, count));
		bool anyRemoved = RemoveTrick(context, character, removeTricks, removedByAlly, skillCost: false, preferIndex);
		ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
		return anyRemoved;
	}

	public void RemoveTrick(DataContext context, CombatCharacter combatChar, IEnumerable<sbyte> trickTypes, bool removedByAlly = true)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		ConvertTricks(tricks, trickTypes);
		RemoveTrick(context, combatChar, tricks, removedByAlly);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
	}

	public bool RemoveTrick(DataContext context, CombatCharacter character, List<NeedTrick> tricks, bool removedByAlly = true, bool skillCost = false, int preferIndex = -1)
	{
		TrickCollection trickCollection = character.GetTricks();
		List<int> indexList = ObjectPool<List<int>>.Instance.Get();
		bool anyRemoved = false;
		tricks = DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 164, tricks, skillCost ? 1 : 0, removedByAlly ? 1 : 0);
		int removeShaTrickCount = 0;
		foreach (NeedTrick needTrick in tricks)
		{
			if (needTrick.NeedCount <= 0)
			{
				continue;
			}
			int removeCounter = 0;
			indexList.Clear();
			indexList.AddRange(trickCollection.Tricks.Keys);
			if (indexList.Contains(preferIndex))
			{
				indexList.MoveIndexToFirst(indexList.IndexOf(preferIndex));
			}
			for (int i = 0; i < indexList.Count; i++)
			{
				if (character.TrickEquals(trickCollection.Tricks[indexList[i]], needTrick.TrickType))
				{
					trickCollection.RemoveTrick(indexList[i]);
					removeCounter++;
					if (needTrick.TrickType == 19)
					{
						removeShaTrickCount++;
					}
					if (removeCounter == needTrick.NeedCount)
					{
						break;
					}
				}
			}
			if (removeCounter > 0)
			{
				anyRemoved = true;
			}
		}
		ObjectPool<List<int>>.Instance.Return(indexList);
		character.SetTricks(trickCollection, context);
		for (int j = 0; j < removeShaTrickCount; j++)
		{
			Events.RaiseRemoveShaTrick(context, character.GetId());
		}
		return anyRemoved;
	}

	public bool StealTrick(DataContext context, CombatCharacter thief, CombatCharacter victim, sbyte trickType, byte count = 1)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		tricks.Add(new NeedTrick(trickType, count));
		bool anyChanged = StealTrick(context, thief, victim, tricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
		return anyChanged;
	}

	public bool StealTrick(DataContext context, CombatCharacter thief, CombatCharacter victim, IEnumerable<sbyte> trickTypes)
	{
		List<NeedTrick> tricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		ConvertTricks(tricks, trickTypes);
		bool anyChanged = StealTrick(context, thief, victim, tricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(tricks);
		return anyChanged;
	}

	public bool StealTrick(DataContext context, CombatCharacter thief, CombatCharacter victim, List<NeedTrick> tricks)
	{
		tricks = DomainManager.SpecialEffect.ModifyData(victim.GetId(), -1, 164, tricks);
		List<NeedTrick> actualTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		TrickCollection trickCollection = victim.GetTricks();
		List<int> indexList = ObjectPool<List<int>>.Instance.Get();
		foreach (NeedTrick needTrick in tricks)
		{
			if (needTrick.NeedCount <= 0)
			{
				continue;
			}
			byte removeCounter = 0;
			indexList.Clear();
			indexList.AddRange(trickCollection.Tricks.Keys);
			for (int i = 0; i < indexList.Count; i++)
			{
				if (trickCollection.Tricks[indexList[i]] == needTrick.TrickType)
				{
					trickCollection.RemoveTrick(indexList[i]);
					removeCounter++;
					if (removeCounter == needTrick.NeedCount)
					{
						break;
					}
				}
			}
			if (removeCounter > 0)
			{
				actualTricks.Add(new NeedTrick(needTrick.TrickType, removeCounter));
			}
		}
		victim.SetTricks(trickCollection, context);
		bool anyChanged = actualTricks.Count > 0;
		if (anyChanged)
		{
			AddTrick(context, thief, actualTricks);
		}
		ObjectPool<List<int>>.Instance.Return(indexList);
		ObjectPool<List<NeedTrick>>.Instance.Return(actualTricks);
		return anyChanged;
	}

	private static void ConvertTricks(ICollection<NeedTrick> needTricks, IEnumerable<sbyte> trickTypes)
	{
		Dictionary<sbyte, byte> dict = ObjectPool<Dictionary<sbyte, byte>>.Instance.Get();
		dict.Clear();
		foreach (sbyte trickType in trickTypes)
		{
			dict[trickType] = (byte)Math.Clamp(dict.GetOrDefault(trickType) + 1, 0, 255);
		}
		needTricks.Clear();
		foreach (var (trickType2, count) in dict)
		{
			needTricks.Add(new NeedTrick(trickType2, count));
		}
		ObjectPool<Dictionary<sbyte, byte>>.Instance.Return(dict);
	}

	public bool WeaponHasNeedTrick(CombatCharacter character, short skillTemplateId, CombatWeaponData weaponData)
	{
		sbyte[] weaponTricks = weaponData.GetWeaponTricks();
		List<NeedTrick> costTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		costTricks.Clear();
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillTemplateId), out var combatSkill))
		{
			DomainManager.CombatSkill.GetCombatSkillCostTrick(combatSkill, costTricks, applySpecialEffect: false);
		}
		else
		{
			costTricks.AddRange(Config.CombatSkill.Instance[skillTemplateId].TrickCost);
		}
		bool result = costTricks.All((NeedTrick x) => weaponTricks.Exist(x.TrickType));
		ObjectPool<List<NeedTrick>>.Instance.Return(costTricks);
		return result;
	}

	public bool HasNeedTrick(CombatCharacter character, GameData.Domains.CombatSkill.CombatSkill skill, bool useConfigValue = false)
	{
		TrickCollection trickCollection = character.GetTricks();
		List<NeedTrick> costTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		List<int> indexList = ObjectPool<List<int>>.Instance.Get();
		bool result = true;
		costTricks.Clear();
		if (useConfigValue)
		{
			costTricks.AddRange(Config.CombatSkill.Instance[skill.GetId().SkillTemplateId].TrickCost);
		}
		else
		{
			DomainManager.CombatSkill.GetCombatSkillCostTrick(skill, costTricks);
		}
		RemoveUsableTrickInsteadCostTrick(character, skill.GetId().SkillTemplateId, costTricks);
		RemoveCostTrickInsteadUselessTrick(character, skill.GetId().SkillTemplateId, costTricks, trulyCost: false);
		RemoveCostTrickBySelfShaTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: false);
		RemoveCostTrickByEnemyShaTrick(Context, character, skill.GetId().SkillTemplateId, costTricks);
		RemoveCostTrickByJiTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: false);
		RemoveJiTrickByUselessTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: false);
		indexList.Clear();
		indexList.AddRange(trickCollection.Tricks.Keys);
		for (int i = 0; i < costTricks.Count; i++)
		{
			NeedTrick needTrick = costTricks[i];
			if (needTrick.NeedCount <= 0)
			{
				continue;
			}
			int removeCounter = 0;
			for (int j = 0; j < indexList.Count; j++)
			{
				if (character.TrickEquals(trickCollection.Tricks[indexList[j]], needTrick.TrickType))
				{
					removeCounter++;
					if (removeCounter == needTrick.NeedCount)
					{
						break;
					}
				}
			}
			if (removeCounter < needTrick.NeedCount)
			{
				result = false;
				break;
			}
		}
		ObjectPool<List<int>>.Instance.Return(indexList);
		ObjectPool<List<NeedTrick>>.Instance.Return(costTricks);
		return result;
	}

	public unsafe void NpcSimplifiedAttack(DataContext context, GameData.Domains.Character.Character attacker, GameData.Domains.Character.Character defender, GameData.Domains.CombatSkill.CombatSkill combatSkill, ItemKey weaponKey, CombatType combatType)
	{
		sbyte damageCount = AiHelper.NpcCombat.CombatTypeWeaponAttackInjuryCount[(int)combatType];
		sbyte poisonScale = AiHelper.NpcCombat.CombatTypePoisonScale[(int)combatType];
		sbyte innerRatio = Config.Weapon.Instance[weaponKey.TemplateId].DefaultInnerRatio;
		PoisonsAndLevels poisonsAndLevels = default(PoisonsAndLevels);
		if (combatSkill != null)
		{
			poisonsAndLevels = combatSkill.GetPoisons();
			damageCount = AiHelper.NpcCombat.CombatTypeSkillAttackInjuryCount[(int)combatType];
			innerRatio = combatSkill.GetCurrInnerRatio();
		}
		if (ModificationStateHelper.IsActive(weaponKey.ModificationState, 1))
		{
			poisonsAndLevels.Add(DomainManager.Item.GetAttachedPoisons(weaponKey));
		}
		int innerDamage = damageCount * innerRatio / 100;
		int outerDamage = damageCount - innerDamage;
		defender.TakeRandomDamage(context, innerDamage, isInnerInjury: true);
		defender.TakeRandomDamage(context, outerDamage, isInnerInjury: false);
		if (poisonScale != 100)
		{
			for (sbyte poisonType = 0; poisonType < 6; poisonType++)
			{
				if (poisonsAndLevels.Values[poisonType] > 0)
				{
					poisonsAndLevels.Values[poisonType] = (short)(poisonsAndLevels.Values[poisonType] * poisonScale / 100);
				}
			}
		}
		defender.ChangePoisoned(context, ref poisonsAndLevels);
		if (combatType == CombatType.Play || combatSkill == null)
		{
			return;
		}
		sbyte direction = combatSkill.GetDirection();
		if (direction == -1)
		{
			return;
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[combatSkill.GetId().SkillTemplateId];
		bool isDirect = direction == 0;
		if (skillConfig.AddWugType >= 0)
		{
			GameData.Domains.Character.Character wugChar = (isDirect ? defender : attacker);
			sbyte growthType = WugEffectBase.GetNpcCombatAddGrowthType(wugChar, skillConfig.AddWugType, isDirect);
			short wugTemplateId = ItemDomain.GetWugTemplateId(skillConfig.AddWugType, growthType);
			if (wugChar.GetCreatingType() == 1 && wugChar.GetEatingItems().IndexOfWug(Config.Medicine.Instance[wugTemplateId]) < 0)
			{
				wugChar.AddWug(context, wugTemplateId, -1);
			}
		}
		if (skillConfig.AddBreakBodyFeature == null)
		{
			return;
		}
		short featureId = skillConfig.AddBreakBodyFeature[(!isDirect) ? 1u : 0u];
		Injuries injuries = defender.GetInjuries();
		sbyte[] bodyParts = BreakFeatureHelper.Feature2BodyPart[featureId];
		bool hasAnyInjury = false;
		for (int i = 0; i < bodyParts.Length; i++)
		{
			if (injuries.Get(bodyParts[i], !isDirect) > 0)
			{
				hasAnyInjury = true;
				break;
			}
		}
		if (hasAnyInjury && !defender.GetFeatureIds().Contains(featureId))
		{
			defender.AddFeature(context, featureId);
			DomainManager.SpecialEffect.Add(context, defender.GetId(), SpecialEffectDomain.BreakBodyFeatureEffectClassName[featureId]);
		}
	}

	[DomainMethod]
	public void StartPrepareOtherAction(DataContext context, sbyte actionType, bool isAlly = true)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.GetOtherActionCanUse()[actionType])
		{
			bool needUpdate = !combatChar.HasDoingOrReserveCommand();
			combatChar.SetNeedUseOtherAction(context, actionType);
			combatChar.MoveData.ResetJumpState(context);
			if (needUpdate)
			{
				UpdateAllCommandAvailability(context, combatChar);
			}
			else
			{
				UpdateOtherActionCanUse(context, combatChar, -1);
			}
		}
	}

	[DomainMethod]
	public void InterruptOtherActionManual(DataContext context, bool isAlly = true)
	{
		if (!IsInCombat())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.GetPreparingOtherActionInterruptType() == EOtherActionInterruptType.Allow)
		{
			if (combatChar.GetPreparingOtherAction() == 4)
			{
				combatChar.NeedInterruptSurrender = true;
			}
			else if (combatChar.GetPreparingItem().IsValid())
			{
				combatChar.SetPreparingItem(ItemKey.Invalid, context);
			}
			else if (combatChar.GetPreparingOtherAction() != -1)
			{
				InterruptOtherAction(context, combatChar, isManual: true);
			}
		}
	}

	public void UpdateOtherActionCanUse(DataContext context, CombatCharacter character, sbyte actionType = -1)
	{
		bool[] canUseList = character.GetOtherActionCanUse();
		bool changed = false;
		if (actionType < 0 || actionType == 0)
		{
			bool canUse = character.GetHealInjuryCount() > 0 && !character.PreparingTeammateCommand() && (!character.GetInjuries().HasAnyInjury() || !GetHealInjuryBanReason(character, character).Any());
			if (canUseList[0] != canUse)
			{
				canUseList[0] = canUse;
				changed = true;
			}
		}
		if (actionType < 0 || actionType == 1)
		{
			bool canUse = character.GetHealPoisonCount() > 0 && !character.PreparingTeammateCommand() && (!character.GetPoison().IsNonZero() || !GetHealPoisonBanReason(character, character).Any());
			if (canUseList[1] != canUse)
			{
				canUseList[1] = canUse;
				changed = true;
			}
		}
		if (actionType < 0 || actionType == 2)
		{
			bool canUse = CanFlee(character.IsAlly) && !character.PreparingTeammateCommand() && GetCurrentDistance() >= FleeNeedDistance;
			if (canUseList[2] != canUse)
			{
				canUseList[2] = canUse;
				changed = true;
			}
		}
		if (actionType < 0 || actionType == 3)
		{
			bool canUse = _carrierAnimalCombatCharId >= 0 && !character.PreparingTeammateCommand() && character.AnimalDurability >= 30;
			if (canUseList[3] != canUse)
			{
				canUseList[3] = canUse;
				changed = true;
			}
		}
		if (actionType < 0 || actionType == 4)
		{
			bool canUse = character.GetCanSurrender();
			if (canUseList[4] != canUse)
			{
				canUseList[4] = canUse;
				changed = true;
			}
		}
		if (changed)
		{
			character.SetOtherActionCanUse(canUseList, context);
		}
	}

	public void InterruptOtherAction(DataContext context, CombatCharacter character, bool isManual = false)
	{
		if (character.GetPreparingOtherAction() == 2 && !isManual)
		{
			DomainManager.Combat.ShowSpecialEffectTips(character.GetId(), 1456, 0);
		}
		Events.RaiseInterruptOtherAction(context, character, character.GetPreparingOtherAction());
		character.SetPreparingOtherAction(-1, context);
		SetProperLoopAniAndParticle(context, character);
	}

	public bool CanFlee(bool isAlly)
	{
		return isAlly ? CombatConfig.SelfCanFlee : CombatConfig.EnemyCanFlee;
	}

	public unsafe void SetPoisons(DataContext context, CombatCharacter character, PoisonInts poisons, bool updateDefeatMark = true)
	{
		PoisonInts oldPoison = character.GetOldPoison();
		bool oldPoisonChanged = false;
		for (sbyte type = 0; type < 6; type++)
		{
			if (poisons.Items[type] < oldPoison.Items[type])
			{
				oldPoison.Items[type] = poisons.Items[type];
				oldPoisonChanged = true;
			}
		}
		if (oldPoisonChanged)
		{
			character.SetOldPoison(ref oldPoison, context);
		}
		character.SetPoison(ref poisons, context);
		character.SyncPoisonData(context);
		if (updateDefeatMark)
		{
			UpdatePoisonDefeatMark(context, character);
		}
		UpdateOtherActionCanUse(context, character, 1);
		if (IsMainCharacter(character))
		{
			UpdateAllTeammateCommandUsable(context, character.IsAlly, ETeammateCommandImplement.HealPoison);
		}
	}

	public unsafe void AddPoison(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte poisonType, sbyte level, int addValue, short skillId = -1, bool applySpecialEffect = true, bool canBounce = true, ItemKey equipKey = default(ItemKey), bool isDirectPoison = false, bool ignorePositiveResist = false, bool forceChangeToOld = false)
	{
		int attackerId = attacker?.GetId() ?? (-1);
		defender = DomainManager.SpecialEffect.ModifyData(attackerId, skillId, 246, defender);
		defender = DomainManager.SpecialEffect.ModifyData(defender.GetId(), skillId, 247, defender);
		if (defender.GetCharacter().HasInnatePoisonImmunity(poisonType))
		{
			return;
		}
		PoisonInts poisons = defender.GetPoison();
		int poisonResist = defender.GetPoisonResist()[poisonType];
		if (ignorePositiveResist && poisonResist > 0 && poisonResist < 1000)
		{
			poisonResist = 0;
		}
		if (applySpecialEffect)
		{
			poisonType = (sbyte)DomainManager.SpecialEffect.ModifyData(attackerId, skillId, 81, poisonType);
			level = (sbyte)(level + DomainManager.SpecialEffect.GetModifyValue(attackerId, skillId, 72, EDataModifyType.Add, poisonType));
			level = (sbyte)(level + DomainManager.SpecialEffect.GetModifyValue(defender.GetId(), skillId, 105, EDataModifyType.Add, poisonType));
			level = (sbyte)Math.Clamp((int)level, 0, 3);
			addValue *= CFormulaHelper.CalcConsummateChangeDamagePercent(attacker, defender);
			CValueModify modify = DomainManager.SpecialEffect.GetModify(attackerId, skillId, 73, poisonType, isDirectPoison ? 1 : 0, equipKey.Id);
			modify += DomainManager.SpecialEffect.GetModify(defender.GetId(), skillId, 106, poisonType, isDirectPoison ? 1 : 0, equipKey.Id);
			modify += attacker.GetCharacter().GetFeatureBonusAttachPoison(poisonType);
			addValue *= modify;
			addValue = DomainManager.SpecialEffect.ModifyData(defender.GetId(), skillId, 106, addValue, poisonType);
			if (!DomainManager.SpecialEffect.ModifyData(defender.GetId(), skillId, 159, dataValue: true, poisonType))
			{
				return;
			}
			sbyte poisonedLevel = PoisonsAndLevels.CalcPoisonedLevel(defender.GetPoison()[poisonType]);
			poisonResist += attacker.CalcAccessoryReducePoisonResist(poisonType, poisonedLevel);
			poisonResist += DomainManager.SpecialEffect.GetModifyValue(attacker.GetId(), skillId, 233, EDataModifyType.Add, poisonType, poisonResist);
			poisonResist += DomainManager.SpecialEffect.GetModifyValue(defender.GetId(), skillId, 232, EDataModifyType.Add, poisonType, poisonResist);
			CValuePercentBonus percent = 0;
			percent += (CValuePercentBonus)DomainManager.SpecialEffect.GetModifyValue(attacker.GetId(), skillId, 233, EDataModifyType.AddPercent, poisonType, poisonResist);
			percent += (CValuePercentBonus)DomainManager.SpecialEffect.GetModifyValue(defender.GetId(), skillId, 232, EDataModifyType.AddPercent, poisonType, poisonResist);
			poisonResist *= percent;
		}
		addValue = PoisonsAndLevels.CalcPoisonDelta(addValue, level, poisons.Items[poisonType], poisonResist);
		if (addValue > 0 && poisons.Items[poisonType] < 25000 && poisonResist < 1000)
		{
			poisons.Items[poisonType] = Math.Clamp(poisons.Items[poisonType] + addValue, 0, 25000);
			AccumulateSkillDamage(context, defender, new DefeatMarkKey(EMarkType.Poison, poisonType), addValue);
			SetPoisons(context, defender, poisons, updateDefeatMark: false);
			bool changeToOld = attackerId >= 0 && DomainManager.SpecialEffect.ModifyData(attackerId, skillId, 78, dataValue: false, poisonType);
			if (changeToOld || forceChangeToOld)
			{
				ChangeToOldPoison(context, defender, poisonType, addValue);
			}
			Events.RaiseAddPoison(context, attackerId, defender.GetId(), poisonType, level, addValue, skillId, canBounce);
			int markCount = UpdatePoisonDefeatMark(context, defender, poisonType);
			if (isDirectPoison)
			{
				Events.RaiseAddDirectPoisonMark(context, attacker, defender, poisonType, skillId, markCount);
			}
			defender.AddPoisonToShow(context, poisonType, level, addValue);
		}
	}

	public int ReducePoison(DataContext context, CombatCharacter character, sbyte poisonType, int reduceValue, bool applySpecialEffect = true, bool canReduceOld = false)
	{
		PoisonInts poisons = character.GetPoison();
		PoisonInts oldPoisons = character.GetOldPoison();
		if (applySpecialEffect)
		{
			reduceValue = ApplyReducePoisonEffect(character.GetId(), poisonType, reduceValue);
		}
		if (reduceValue > 0)
		{
			int prevValue = poisons[poisonType];
			int minPoison = ((!canReduceOld) ? oldPoisons[poisonType] : 0);
			int currValue = (poisons[poisonType] = Math.Max(poisons[poisonType] - reduceValue, minPoison));
			SetPoisons(context, character, poisons);
			reduceValue = prevValue - currValue;
		}
		return reduceValue;
	}

	private void AddDirectPoison(DataContext context, CombatCharacter attacker, CombatCharacter defender, PoisonsAndLevels poisons, CValuePercent ratio, short skillId = -1, ItemKey weaponKey = default(ItemKey))
	{
		for (sbyte type = 0; type < 6; type++)
		{
			var (value, level) = poisons.GetValueAndLevel(type);
			if (value > 0)
			{
				AddPoison(context, attacker, defender, type, level, value * ratio, skillId, applySpecialEffect: true, canBounce: true, weaponKey, isDirectPoison: true);
			}
		}
	}

	private int ApplyReducePoisonEffect(int charId, sbyte poisonType, int reduceValue, bool getCost = false)
	{
		reduceValue = DomainManager.SpecialEffect.ModifyData(charId, -1, 161, reduceValue, poisonType, getCost ? 1 : 0);
		if (!DomainManager.SpecialEffect.ModifyData(charId, -1, 160, dataValue: true, poisonType))
		{
			reduceValue = 0;
		}
		return reduceValue;
	}

	public void PoisonAffect(DataContext context, CombatCharacter character, sbyte poisonType)
	{
		int affectCount = 1 + DomainManager.SpecialEffect.GetModifyValue(character.GetId(), 163, EDataModifyType.Add);
		for (int i = 0; i < affectCount; i++)
		{
			PoisonAffectInternal(context, character, poisonType);
		}
	}

	private unsafe void PoisonAffectInternal(DataContext context, CombatCharacter character, sbyte poisonType)
	{
		if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 162, dataValue: true, poisonType))
		{
			return;
		}
		int poisonValue = character.GetPoison().Items[poisonType];
		sbyte currLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
		if (currLevel == 0)
		{
			return;
		}
		switch (poisonType)
		{
		case 0:
		case 1:
		{
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			Injuries injuries = character.GetInjuries();
			bool isInner = poisonType == 1;
			bodyPartRandomPool.Clear();
			for (sbyte type = 0; type < 7; type++)
			{
				if (injuries.Get(type, isInner) < 6)
				{
					bodyPartRandomPool.Add(type);
				}
			}
			if (bodyPartRandomPool.Count > 0 && currLevel > 0)
			{
				sbyte bodyPart = bodyPartRandomPool.GetRandom(context.Random);
				character.AddInjury(context, bodyPart, isInner, (sbyte)Math.Min(currLevel, 6 - injuries.Get(bodyPart, isInner)));
				UpdateBodyDefeatMark(context, character, bodyPart);
			}
			ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
			break;
		}
		case 2:
		case 3:
			character.WorsenRandomInjury(context, poisonType == 2, WorsenConstants.CalcPoisonPercent(currLevel));
			break;
		}
		CalcMixPoisonEffects(context, character, poisonType);
		Events.RaisePoisonAffected(context, character.GetId(), poisonType);
		PoisonProduce(context, character, poisonType);
		PoisonProduceWeaken(context, character, poisonType);
		ShowSpecialEffectTips(character.GetId(), 1466 + poisonType, 0);
	}

	public void PoisonProduce(DataContext context, CombatCharacter combatChar, sbyte poisonType, int multiplier = 1)
	{
		PoisonItem poisonData = Poison.Instance[poisonType];
		CValuePercent producePercent = poisonData.ProducePercent;
		int poisonValue = combatChar.GetPoison()[poisonType];
		sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
		int produceValue = DomainManager.SpecialEffect.ModifyValue(combatChar.GetId(), 258, poisonValue * multiplier * producePercent);
		AddPoison(context, null, combatChar, poisonData.ProduceType, poisonLevel, produceValue, -1, applySpecialEffect: false);
	}

	public void PoisonProduceWeaken(DataContext context, CombatCharacter combatChar, sbyte poisonType)
	{
		PoisonItem poisonData = Poison.Instance[poisonType];
		int poisonValue = combatChar.GetPoison()[poisonType];
		sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonValue);
		int oldPoisonValue = combatChar.GetOldPoison()[poisonType];
		CValuePercent weakenPercent = poisonData.AffectCostPercent[Math.Clamp(poisonLevel - 1, 0, poisonData.AffectCostPercent.Length)];
		int weakenValue = (poisonValue - oldPoisonValue) * weakenPercent;
		ReducePoison(context, combatChar, poisonType, weakenValue, applySpecialEffect: false);
	}

	public unsafe void ChangeToOldPoison(DataContext context, CombatCharacter character, sbyte poisonType, int poisonValue)
	{
		PoisonInts oldPoison = character.GetOldPoison();
		PoisonInts poison = character.GetPoison();
		oldPoison.Items[poisonType] = Math.Min(oldPoison.Items[poisonType] + poisonValue, poison.Items[poisonType]);
		character.SetOldPoison(ref oldPoison, context);
	}

	public bool CheckSkillPoison(short skillId, sbyte poisonType)
	{
		return Config.CombatSkill.Instance[skillId].Poisons.GetValueAndLevel(poisonType).value > 0;
	}

	public bool CheckEquipmentPoison(ItemKey itemKey, out PoisonsAndLevels attachedPoisons)
	{
		PoisonsAndLevels innatePoisons;
		bool anyPoison = CheckEquipmentPoison(itemKey, out attachedPoisons, out innatePoisons);
		if (!attachedPoisons.IsNonZero())
		{
			attachedPoisons = innatePoisons;
		}
		return anyPoison;
	}

	public bool CheckEquipmentPoison(ItemKey itemKey, out PoisonsAndLevels attachedPoisons, out PoisonsAndLevels innatePoisons)
	{
		ItemBase item = (itemKey.IsValid() ? DomainManager.Item.GetBaseItem(itemKey) : null);
		if (item == null || item.GetCurrDurability() <= 0)
		{
			return false;
		}
		if (ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
		{
			attachedPoisons = DomainManager.Item.GetAttachedPoisons(itemKey);
		}
		if (item is GameData.Domains.Item.Weapon weapon)
		{
			innatePoisons = weapon.GetInnatePoisons();
		}
		return attachedPoisons.IsNonZero() || innatePoisons.IsNonZero();
	}

	public void ApplyEquipmentPoison(DataContext context, CombatCharacter poisoner, CombatCharacter victim, ItemKey itemKey, int valueMultiplier = 1, bool ignorePositiveResist = false)
	{
		if (victim.GetId() == _carrierAnimalCombatCharId || !CheckEquipmentPoison(itemKey, out var attachedPoisons, out var innatePoisons))
		{
			return;
		}
		List<sbyte> validTypes = ObjectPool<List<sbyte>>.Instance.Get();
		List<int> typeWeights = ObjectPool<List<int>>.Instance.Get();
		validTypes.Clear();
		typeWeights.Clear();
		for (sbyte type = 0; type < 6; type++)
		{
			int weight = attachedPoisons.GetValueAndLevel(type).value + innatePoisons.GetValueAndLevel(type).value;
			if (weight > 0)
			{
				validTypes.Add(type);
				typeWeights.Add(weight);
			}
		}
		sbyte poisonType = validTypes[RandomUtils.GetRandomIndex(typeWeights, context.Random)];
		ObjectPool<List<sbyte>>.Instance.Return(validTypes);
		ObjectPool<List<int>>.Instance.Return(typeWeights);
		AddPoisonByTuple(attachedPoisons.GetValueAndLevel(poisonType));
		AddPoisonByTuple(innatePoisons.GetValueAndLevel(poisonType));
		void AddPoisonByTuple((short value, sbyte level) tuple)
		{
			if (tuple.value > 0)
			{
				AddPoison(context, poisoner, victim, poisonType, tuple.level, tuple.value * valueMultiplier, -1, applySpecialEffect: true, canBounce: true, itemKey, isDirectPoison: true, ignorePositiveResist);
			}
		}
	}

	private static void BindMixPoisonEffectImplements()
	{
		if (MixPoisonEffectImplements.Count > 0)
		{
			return;
		}
		Type type = typeof(MixPoisonEffectImplements);
		Type attributeType = typeof(MixPoisonEffectAttribute);
		MethodInfo[] methods = type.GetMethods();
		foreach (MethodInfo method in methods)
		{
			object[] attributes = method.GetCustomAttributes(attributeType, inherit: false);
			if (attributes.Length != 0)
			{
				MixPoisonEffectAttribute attribute = (MixPoisonEffectAttribute)attributes[0];
				MixPoisonEffectDelegate func = method.CreateDelegate<MixPoisonEffectDelegate>();
				MixPoisonEffectImplements.Add(attribute.TemplateId, func);
			}
		}
	}

	private void CalcMixPoisonEffects(DataContext context, CombatCharacter combatChar, sbyte affectPoisonType)
	{
		byte[] poisonMarkList = combatChar.GetDefeatMarkCollection().PoisonMarkList;
		if (poisonMarkList.CountAll((byte count) => count > 0) < 3)
		{
			return;
		}
		MixPoisonAffectedCountCollection canAffectCountCollection = combatChar.GetMixPoisonCanAffectCount();
		foreach (MixPoisonEffectItem effect in (IEnumerable<MixPoisonEffectItem>)MixPoisonEffect.Instance)
		{
			if (!effect.AffectPoisonTypes.Exist(affectPoisonType))
			{
				continue;
			}
			int canAffectCount = canAffectCountCollection.GetAffectedCount(effect.TemplateId);
			if (canAffectCount <= 0)
			{
				continue;
			}
			if (!MixPoisonEffectImplements.TryGetValue(effect.TemplateId, out var implement))
			{
				PredefinedLog.Show(8, $"Not implement mixed poison type {effect.TemplateId}");
				continue;
			}
			bool infinityAffect = DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), -1, 271, dataValue: false);
			int affectedCount = combatChar.GetMixPoisonAffectedCount().GetAffectedCount(effect.TemplateId);
			if ((infinityAffect || affectedCount < canAffectCount) && implement(context, combatChar, poisonMarkList))
			{
				combatChar.SetMixPoisonAffectedCount(combatChar.GetMixPoisonAffectedCount().AddAffectedCount(effect.TemplateId), context);
			}
			Events.RaiseMixedPoisonAffected(context, combatChar);
		}
	}

	[DomainMethod]
	public bool DoRawCreate(DataContext context, int effectId, sbyte equipmentSlot, short newTemplateId)
	{
		if (!_selfChar.IsAlly)
		{
			return false;
		}
		return _selfChar.DoRawCreate(context, effectId, equipmentSlot, newTemplateId);
	}

	[DomainMethod]
	public bool IgnoreRawCreate(DataContext context, int effectId)
	{
		if (!_selfChar.IsAlly)
		{
			return false;
		}
		_selfChar.IgnoreRawCreate(context, effectId);
		return true;
	}

	[DomainMethod]
	public bool IgnoreAllRawCreate(DataContext context)
	{
		if (!_selfChar.IsAlly)
		{
			return false;
		}
		_selfChar.IgnoreAllRawCreate(context);
		return true;
	}

	[DomainMethod]
	public List<sbyte> GetAllCanRawCreateEquipmentSlots(int effectId)
	{
		SpecialEffectItem config = Config.SpecialEffect.Instance[effectId];
		return new List<sbyte>(_selfChar.GetAllCanRawCreateEquipmentSlots(config.RawCreateType));
	}

	[DomainMethod]
	public UnlockSimulateResult GetUnlockSimulateResult(int index, bool isAlly = true)
	{
		if (!IsInCombat())
		{
			return null;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		List<bool> canUnlockAttack = combatChar.GetCanUnlockAttack();
		if (!canUnlockAttack.CheckIndex(index) || !canUnlockAttack[index])
		{
			return null;
		}
		List<int> effects = ObjectPool<List<int>>.Instance.Get();
		effects.Clear();
		effects = DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), -1, 310, effects, index);
		UnlockSimulateResult result = new UnlockSimulateResult(effects, combatChar.AllRawCreateSlotsBlocked);
		ObjectPool<List<int>>.Instance.Return(effects);
		return result;
	}

	[DomainMethod]
	public List<CombatSkillDisplayData> GetProactiveSkillList(int charId)
	{
		if (!IsCharInCombat(charId))
		{
			return null;
		}
		CombatCharacter combatChar = _combatCharacterDict[charId];
		List<short> skillIdList = ObjectPool<List<short>>.Instance.Get();
		skillIdList.Clear();
		skillIdList.AddRange(combatChar.GetAttackSkillList());
		skillIdList.AddRange(combatChar.GetAgileSkillList());
		skillIdList.AddRange(combatChar.GetDefenceSkillList());
		skillIdList.RemoveAll((short id) => id < 0);
		List<CombatSkillDisplayData> dataList = DomainManager.CombatSkill.GetCombatSkillDisplayData(charId, skillIdList);
		ObjectPool<List<short>>.Instance.Return(skillIdList);
		return dataList;
	}

	[DomainMethod]
	public OuterAndInnerShorts GetPreviewAttackRange(int charId, short skillId, int weaponIndex = -1)
	{
		if (!IsCharInCombat(charId) || !TryGetElement_CombatCharacterDict(charId, out var combatChar))
		{
			return default(OuterAndInnerShorts);
		}
		return combatChar.CalcAttackRangeImmediate(skillId, weaponIndex);
	}

	[DomainMethod]
	public void StartPrepareSkill(DataContext context, short skillId, bool isAlly = true)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (_skillDataDict.TryGetValue((charId: combatChar.GetId(), skillId: skillId), out var skillData) && skillData.GetCanUse())
		{
			combatChar.SetNeedUseSkillId(context, skillId);
			bool needPrepare = Config.CombatSkill.Instance[combatChar.NeedUseSkillId].EquipType == 1 || combatChar.GetPreparingSkillId() < 0 || !combatChar.CanCastDuringPrepareSkills.Contains(skillId);
			if (!needPrepare)
			{
				CastAgileOrDefenseWithoutPrepare(combatChar, combatChar.NeedUseSkillId);
				combatChar.SetNeedUseSkillId(context, -1);
			}
			if (needPrepare)
			{
				combatChar.MoveData.ResetJumpState(context);
			}
			UpdateMaxSkillGrade(isAlly, skillId);
			UpdateAllCommandAvailability(context, combatChar);
		}
	}

	[DomainMethod]
	public bool ClearDefendInBlockAttackSkill(DataContext context, bool isAlly = true)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (combatChar.NeedUseSkillId < 0 || combatChar.GetAffectingDefendSkillId() < 0)
		{
			return false;
		}
		if (DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), combatChar.NeedUseSkillId, 223, dataValue: false))
		{
			return false;
		}
		ClearAffectingDefenseSkillManual(context, isAlly);
		return true;
	}

	private void InitSkillData(DataContext context)
	{
		ClearSkillDataDict();
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			GameData.Domains.Character.Character character = combatChar.GetCharacter();
			int charId = character.GetId();
			foreach (short skillId in combatChar.GetCharacter().GetCombatSkillEquipment())
			{
				if ((combatChar.BossConfig == null || !CombatSkillEquipType.IsAttack(skillId)) && character.GetCombatSkillCanAffect(skillId))
				{
					AddCombatSkillData(context, charId, skillId);
				}
			}
			if (combatChar.BossConfig != null)
			{
				short[] array = combatChar.BossConfig.PhaseAttackSkills[0];
				foreach (short skillId2 in array)
				{
					AddCombatSkillData(context, charId, skillId2);
				}
			}
		}
	}

	private void AddCombatSkillData(DataContext context, int charId, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		if (_skillDataDict.ContainsKey(skillKey))
		{
			PredefinedLog.Show(8, "AddCombatSkillData already exist key " + skillKey.ToString());
			return;
		}
		CombatSkillData skillData = new CombatSkillData(skillKey);
		AddElement_SkillDataDict(skillKey, skillData);
		skillData.SetLeftCdFrame(0, context);
	}

	public CombatSkillData GetCombatSkillData(int charId, short skillId)
	{
		return _skillDataDict[new CombatSkillKey(charId, skillId)];
	}

	public bool TryGetCombatSkillData(int charId, short skillId, out CombatSkillData combatSkillData)
	{
		return _skillDataDict.TryGetValue((charId: charId, skillId: skillId), out combatSkillData);
	}

	public bool IsCombatSkillSilenceInfinity(CombatSkillKey skillKey)
	{
		CombatSkillData combatSkillData;
		return TryGetCombatSkillData(skillKey.CharId, skillKey.SkillTemplateId, out combatSkillData) && combatSkillData.GetTotalCdFrame() < 0;
	}

	public bool CombatSkillDataExist(CombatSkillKey skillKey)
	{
		return _skillDataDict.ContainsKey(skillKey);
	}

	public void UpdateSkillCanUse(DataContext context, CombatCharacter character)
	{
		List<short> skillIdList = ObjectPool<List<short>>.Instance.Get();
		skillIdList.Clear();
		skillIdList.AddRange(character.GetAttackSkillList());
		skillIdList.AddRange(character.GetAgileSkillList());
		skillIdList.AddRange(character.GetDefenceSkillList());
		skillIdList.AddRange(character.GetAssistSkillList());
		skillIdList.RemoveAll((short id) => id <= 0);
		for (int i = 0; i < skillIdList.Count; i++)
		{
			UpdateSkillCanUse(context, character, skillIdList[i]);
		}
		ObjectPool<List<short>>.Instance.Return(skillIdList);
	}

	public void UpdateSkillCanUse(DataContext context, CombatCharacter character, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		CombatSkillData skillData = _skillDataDict[skillKey];
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		bool canUse = ((configData.EquipType == 4) ? (skillData.GetLeftCdFrame() == 0) : CanCastSkill(character, skillId));
		if (skillData.GetCanUse() != canUse)
		{
			skillData.SetCanUse(canUse, context);
		}
		else if (!canUse)
		{
			skillData.InvalidateSelfAndInfluencedCache(7, context);
		}
		if (!canUse && character.GetCombatReserveData().NeedUseSkillId == skillId)
		{
			character.SetCombatReserveData(CombatReserveData.Invalid, context);
		}
	}

	public void UpdateSkillCostBreathStanceCanUse(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillKey skillKey in _skillDataDict.Keys)
		{
			if (skillKey.CharId == character.GetId() && DomainManager.CombatSkill.GetElement_CombatSkills(skillKey).GetCostBreathAndStancePercent() > 0)
			{
				UpdateSkillCanUse(context, character, skillKey.SkillTemplateId);
			}
		}
	}

	public void UpdateSkillCostTrickCanUse(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillKey skillKey in _skillDataDict.Keys)
		{
			if (skillKey.CharId == character.GetId() && Config.CombatSkill.Instance[skillKey.SkillTemplateId].TrickCost.Count > 0)
			{
				UpdateSkillCanUse(context, character, skillKey.SkillTemplateId);
			}
		}
		CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
		foreach (CombatSkillKey skillKey2 in _skillDataDict.Keys)
		{
			if (skillKey2.CharId == enemyChar.GetId() && DomainManager.SpecialEffect.ModifyData(skillKey2.CharId, skillKey2.SkillTemplateId, 279, dataValue: false))
			{
				UpdateSkillCanUse(context, enemyChar, skillKey2.SkillTemplateId);
			}
		}
	}

	private void UpdateSkillNeedMobilityCanUse(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillKey skillKey in _skillDataDict.Keys)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
			CombatSkillItem configData = Config.CombatSkill.Instance[skillKey.SkillTemplateId];
			bool canUseMobilityAsBreath = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 229, dataValue: false);
			bool canUseMobilityAsStance = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 230, dataValue: false);
			if (skillKey.CharId == character.GetId() && (configData.EquipType == 2 || skill.GetCostMobilityPercent() > 0 || canUseMobilityAsBreath || canUseMobilityAsStance))
			{
				UpdateSkillCanUse(context, character, skillKey.SkillTemplateId);
			}
		}
	}

	private void UpdateSkillNeedDistanceCanUse(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillKey skillKey in _skillDataDict.Keys)
		{
			if (skillKey.CharId == character.GetId() && Config.CombatSkill.Instance[skillKey.SkillTemplateId].EquipType == 1)
			{
				UpdateSkillCanUse(context, character, skillKey.SkillTemplateId);
			}
		}
	}

	public void UpdateSkillNeedBodyPartCanUse(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillKey skillKey in _skillDataDict.Keys)
		{
			if (skillKey.CharId == character.GetId() && Config.CombatSkill.Instance[skillKey.SkillTemplateId].NeedBodyPartTypes.Count > 0)
			{
				UpdateSkillCanUse(context, character, skillKey.SkillTemplateId);
			}
		}
	}

	public OuterAndInnerInts GetSkillCostBreathStance(int charId, GameData.Domains.CombatSkill.CombatSkill skill)
	{
		int costBreathPercent = skill.GetCostBreathPercent();
		int costStancePercent = skill.GetCostStancePercent();
		int convertStatus = DomainManager.SpecialEffect.ModifyValue(charId, skill.GetId().SkillTemplateId, 301, 0);
		if (1 == 0)
		{
		}
		(int, int) tuple = ((convertStatus > 0) ? (costBreathPercent + costStancePercent, 0) : ((convertStatus >= 0) ? (costBreathPercent, costStancePercent) : (0, costBreathPercent + costStancePercent)));
		if (1 == 0)
		{
		}
		(int, int) tuple2 = tuple;
		costBreathPercent = tuple2.Item1;
		costStancePercent = tuple2.Item2;
		costBreathPercent = DomainManager.SpecialEffect.ModifyData(charId, skill.GetId().SkillTemplateId, 227, costBreathPercent);
		costStancePercent = DomainManager.SpecialEffect.ModifyData(charId, skill.GetId().SkillTemplateId, 228, costStancePercent);
		return new OuterAndInnerInts(costStancePercent, costBreathPercent);
	}

	public bool SkillCostEnough(CombatCharacter character, short skillId)
	{
		if (_enableSkillFreeCast)
		{
			return true;
		}
		if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 154, dataValue: true))
		{
			return true;
		}
		foreach (ECombatSkillBanReasonType banReason in CalcSkillCostEnoughBanReasons(character, skillId))
		{
			if (banReason != ECombatSkillBanReasonType.None)
			{
				return false;
			}
		}
		return true;
	}

	public IEnumerable<ECombatSkillBanReasonType> CalcSkillCostEnoughBanReasons(CombatCharacter character, short skillId)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 289, dataValue: true))
		{
			yield return ECombatSkillBanReasonType.SpecialEffectBan;
		}
		if ((!character.CanCastSkillCostBreath && skill.GetCostBreathPercent() > 0) || (!character.CanCastSkillCostStance && skill.GetCostStancePercent() > 0))
		{
			yield return ECombatSkillBanReasonType.SpecialEffectBan;
		}
		else
		{
			int mobilityPercent = CValuePercent.ParseInt(character.GetMobilityValue(), MoveSpecialConstants.MaxMobility);
			OuterAndInnerInts costBreathStance = GetSkillCostBreathStance(character.GetId(), skill);
			CValuePercent innerRatio = skill.GetCurrInnerRatio();
			int breathExtra = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 173, EDataModifyType.Add);
			int breathCostPercent = Math.Max(costBreathStance.Inner - breathExtra, 0);
			bool breathCanUseMobility = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 229, dataValue: false);
			int breathUseMobility = 0;
			if (breathCanUseMobility && breathCostPercent > 0)
			{
				breathUseMobility = Math.Min(breathCostPercent, mobilityPercent * 2 * innerRatio);
			}
			breathCostPercent -= breathUseMobility;
			int breathCost = 30000 * breathCostPercent / 100;
			bool breathEnough = character.GetBreathValue() >= breathCost;
			bool breathCanCastOnLack = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 225, dataValue: false, breathCost);
			if (!breathEnough && !breathCanCastOnLack)
			{
				yield return ECombatSkillBanReasonType.BreathNotEnough;
			}
			int stanceExtra = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 174, EDataModifyType.Add);
			int stanceCostPercent = Math.Max(costBreathStance.Outer - stanceExtra, 0);
			bool stanceCanUseMobility = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 230, dataValue: false);
			int stanceUseMobility = 0;
			if (stanceCanUseMobility && stanceCostPercent > 0)
			{
				stanceUseMobility = Math.Min(stanceCostPercent, mobilityPercent * 2 - breathUseMobility);
			}
			stanceCostPercent -= stanceUseMobility;
			int stanceCost = 4000 * stanceCostPercent / 100;
			bool stanceEnough = character.GetStanceValue() >= stanceCost;
			bool stanceCanCastOnLack = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 226, dataValue: false, stanceCost);
			if (!stanceEnough && !stanceCanCastOnLack)
			{
				yield return ECombatSkillBanReasonType.StanceNotEnough;
			}
		}
		if (!HasNeedTrick(character, skill))
		{
			yield return ECombatSkillBanReasonType.TrickNotEnough;
		}
		if (configData.WeaponDurableCost > 0 && character.GetUsingWeaponIndex() < 3 && DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(character).Id).GetCurrDurability() < configData.WeaponDurableCost)
		{
			yield return ECombatSkillBanReasonType.WeaponDestroyed;
		}
		CValuePercent costMobilityPercent = skill.GetCostMobilityPercent();
		if (costMobilityPercent > 0)
		{
			int costMobility = MoveSpecialConstants.MaxMobility * costMobilityPercent;
			if (character.GetMobilityValue() < costMobility)
			{
				yield return ECombatSkillBanReasonType.MobilityNotEnough;
			}
		}
		if (character.GetWugCount() < configData.WugCost)
		{
			yield return ECombatSkillBanReasonType.WugNotEnough;
		}
		if (!HasNeedNeiliAllocation(character, skill))
		{
			yield return ECombatSkillBanReasonType.NeiliAllocationNotEnough;
		}
	}

	public bool SkillInCastRange(CombatCharacter character, short skillId)
	{
		OuterAndInnerInts skillRange = GetSkillAttackRange(character, skillId);
		return _currentDistance >= skillRange.Outer && _currentDistance <= skillRange.Inner;
	}

	public OuterAndInnerInts GetSkillAttackRange(CombatCharacter character, short skillId)
	{
		OuterAndInnerShorts attackRange = character.CalcAttackRangeImmediate(skillId);
		return new OuterAndInnerInts(attackRange.Outer, attackRange.Inner);
	}

	public bool HasSkillNeedBodyPart(CombatCharacter character, short skillId, bool applyEffect = true)
	{
		CombatSkillItem skillConfigData = Config.CombatSkill.Instance[skillId];
		bool canCastWithBrokenBody = applyEffect && DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 219, dataValue: false);
		byte[] acupointCount = character.GetAcupointCount();
		for (int i = 0; i < skillConfigData.NeedBodyPartTypes.Count; i++)
		{
			switch (skillConfigData.NeedBodyPartTypes[i])
			{
			case 0:
				if ((!canCastWithBrokenBody && character.HasBreakInjury(2)) || acupointCount[2] >= 3)
				{
					return false;
				}
				break;
			case 1:
				if ((!canCastWithBrokenBody && character.HasBreakInjury(0)) || acupointCount[0] >= 3)
				{
					return false;
				}
				break;
			case 2:
				if ((!canCastWithBrokenBody && character.HasBreakInjury(1)) || acupointCount[1] >= 3)
				{
					return false;
				}
				break;
			case 3:
				if ((!canCastWithBrokenBody && character.HasBreakInjury(3)) || acupointCount[3] >= 3 || (!canCastWithBrokenBody && character.HasBreakInjury(4)) || acupointCount[4] >= 3)
				{
					return false;
				}
				break;
			case 4:
				if (((!canCastWithBrokenBody && character.HasBreakInjury(3)) || acupointCount[3] >= 3) && ((!canCastWithBrokenBody && character.HasBreakInjury(4)) || acupointCount[4] >= 3))
				{
					return false;
				}
				break;
			case 5:
				if ((!canCastWithBrokenBody && character.HasBreakInjury(5)) || acupointCount[5] >= 3 || (!canCastWithBrokenBody && character.HasBreakInjury(6)) || acupointCount[6] >= 3)
				{
					return false;
				}
				break;
			case 6:
				if (((!canCastWithBrokenBody && character.HasBreakInjury(5)) || acupointCount[5] >= 3) && ((!canCastWithBrokenBody && character.HasBreakInjury(6)) || acupointCount[6] >= 3))
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	public bool SkillBodyPartHasHeavyInjury(CombatCharacter character, short skillId)
	{
		CombatSkillItem skillConfigData = Config.CombatSkill.Instance[skillId];
		for (int i = 0; i < skillConfigData.NeedBodyPartTypes.Count; i++)
		{
			switch (skillConfigData.NeedBodyPartTypes[i])
			{
			case 0:
				if (character.HasHeavyInjury(2))
				{
					return true;
				}
				break;
			case 1:
				if (character.HasHeavyInjury(0))
				{
					return true;
				}
				break;
			case 2:
				if (character.HasHeavyInjury(1))
				{
					return true;
				}
				break;
			case 3:
				if (character.HasHeavyInjury(3) || character.HasHeavyInjury(4))
				{
					return true;
				}
				break;
			case 4:
				if (character.HasHeavyInjury(3) && character.HasHeavyInjury(4))
				{
					return true;
				}
				break;
			case 5:
				if (character.HasHeavyInjury(5) || character.HasHeavyInjury(6))
				{
					return true;
				}
				break;
			case 6:
				if (character.HasHeavyInjury(5) && character.HasHeavyInjury(6))
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	public bool SkillCanUseInCurrCombat(int charId, CombatSkillItem configData)
	{
		List<sbyte> typeList = CombatConfig.CombatSkillType;
		return CombatSkillDomain.FiveElementMatch(charId, configData, CombatConfig.FiveElementsOfSkill) && (typeList == null || typeList.Count == 0 || typeList.Contains(DomainManager.CombatSkill.GetSkillType(charId, configData.TemplateId))) && (CombatConfig.Sect < 0 || CombatConfig.Sect == configData.SectId);
	}

	public bool SkillDirectionCanCast(CombatCharacter character, short skillId)
	{
		sbyte direction = DomainManager.CombatSkill.GetSkillDirection(character.GetId(), skillId);
		return (direction != 0 || character.CanCastDirectSkill) && (direction != 1 || character.CanCastReverseSkill);
	}

	public unsafe bool HasNeedNeiliAllocation(CombatCharacter character, GameData.Domains.CombatSkill.CombatSkill skill)
	{
		(sbyte, sbyte) costNeiliAllocation = skill.GetCostNeiliAllocation();
		NeiliAllocation neiliAllocation = character.GetNeiliAllocation();
		return costNeiliAllocation.Item1 < 0 || neiliAllocation.Items[costNeiliAllocation.Item1] >= costNeiliAllocation.Item2;
	}

	public void DoCombatSkillCost(DataContext context, CombatCharacter character, short skillId)
	{
		if (_enableSkillFreeCast || !DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 154, dataValue: true))
		{
			return;
		}
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		int mobilityPercent = CValuePercent.ParseInt(character.GetMobilityValue(), MoveSpecialConstants.MaxMobility);
		OuterAndInnerInts costBreathStance = GetSkillCostBreathStance(character.GetId(), skill);
		CValuePercent innerRatio = skill.GetCurrInnerRatio();
		int breathExtra = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 173, EDataModifyType.Add);
		int breathCostPercent = Math.Max(costBreathStance.Inner - breathExtra, 0);
		int breathExtraCost = costBreathStance.Inner - breathCostPercent;
		bool breathCanUseMobility = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 229, dataValue: false);
		int breathUseMobility = 0;
		if (breathCanUseMobility && breathCostPercent > 0)
		{
			breathUseMobility = Math.Min(breathCostPercent, mobilityPercent * 2 * innerRatio);
		}
		breathCostPercent -= breathUseMobility;
		int breathCost = 30000 * breathCostPercent / 100;
		int stanceExtra = DomainManager.SpecialEffect.GetModifyValue(character.GetId(), skillId, 174, EDataModifyType.Add);
		int stanceCostPercent = Math.Max(costBreathStance.Outer - stanceExtra, 0);
		int stanceExtraCost = costBreathStance.Outer - stanceCostPercent;
		bool stanceCanUseMobility = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillKey.SkillTemplateId, 230, dataValue: false);
		int stanceUseMobility = 0;
		if (stanceCanUseMobility && stanceCostPercent > 0)
		{
			stanceUseMobility = Math.Min(stanceCostPercent, mobilityPercent * 2 - breathUseMobility);
		}
		stanceCostPercent -= stanceUseMobility;
		int stanceCost = 4000 * stanceCostPercent / 100;
		Events.RaiseCastSkillUseExtraBreathOrStance(context, character.GetId(), skillId, breathExtraCost, stanceExtraCost);
		if (breathUseMobility > 0)
		{
			Events.RaiseCastSkillUseMobilityAsBreathOrStance(context, character.GetId(), skillId, asBreath: true);
		}
		if (stanceUseMobility > 0)
		{
			Events.RaiseCastSkillUseMobilityAsBreathOrStance(context, character.GetId(), skillId, asBreath: false);
		}
		CValuePercent breathAndStanceCostMobilityPercent = ((breathUseMobility + stanceUseMobility > 0) ? Math.Max((breathUseMobility + stanceUseMobility) / 2, 1) : 0);
		if (breathAndStanceCostMobilityPercent > 0)
		{
			ChangeMobilityValue(context, character, -MoveSpecialConstants.MaxMobility * breathAndStanceCostMobilityPercent, changedByEffect: false, null, costBySkill: true);
		}
		if (breathCost > 0 || stanceCost > 0)
		{
			bool canCastOnLackBreath = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 225, dataValue: false, breathCost);
			bool canCastOnLackStance = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 226, dataValue: false, stanceCost);
			if (canCastOnLackBreath || canCastOnLackStance)
			{
				int breathValue = character.GetBreathValue();
				int stanceValue = character.GetStanceValue();
				if (breathValue < breathCost || stanceValue < stanceCost)
				{
					Events.RaiseCastSkillOnLackBreathStance(context, character, skillId, breathValue - breathCost, stanceValue - stanceCost, breathCost, stanceCost);
				}
			}
		}
		CostBreathAndStance(context, character, breathCost, stanceCost, skillId);
		List<NeedTrick> costTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		List<NeedTrick> costEnemyTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		DomainManager.CombatSkill.GetCombatSkillCostTrick(skill, costTricks);
		RemoveUsableTrickInsteadCostTrick(character, skillId, costTricks, costEnemyTricks);
		RemoveCostTrickInsteadUselessTrick(character, skillId, costTricks, trulyCost: true);
		RemoveCostTrickBySelfShaTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: true);
		RemoveCostTrickByEnemyShaTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, costEnemyTricks);
		RemoveCostTrickByJiTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: true);
		RemoveJiTrickByUselessTrick(Context, character, skill.GetId().SkillTemplateId, costTricks, trulyCost: true);
		RemoveTrick(context, character, costTricks, removedByAlly: true, skillCost: true);
		if (costEnemyTricks.Count > 0)
		{
			RemoveTrick(context, GetCombatCharacter(!character.IsAlly), costEnemyTricks, removedByAlly: false);
		}
		Events.RaiseCastSkillTrickCosted(context, character, skillId, costTricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(costTricks);
		ObjectPool<List<NeedTrick>>.Instance.Return(costEnemyTricks);
		int costMobilityPercent = skill.GetCostMobilityPercent();
		if (costMobilityPercent > 0)
		{
			int costMobility = MoveSpecialConstants.MaxMobility * costMobilityPercent / 100;
			ChangeMobilityValue(context, character, -costMobility, changedByEffect: false, null, costBySkill: true);
		}
		if (configData.WugCost > 0)
		{
			character.ChangeWugCount(context, -configData.WugCost);
		}
		(sbyte, sbyte) costNeiliAllocation = skill.GetCostNeiliAllocation();
		if (costNeiliAllocation.Item1 >= 0)
		{
			if (DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 344, dataValue: false))
			{
				CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
				enemyChar.AbsorbNeiliAllocation(context, character, (byte)costNeiliAllocation.Item1, costNeiliAllocation.Item2);
			}
			else
			{
				character.ChangeNeiliAllocation(context, (byte)costNeiliAllocation.Item1, -costNeiliAllocation.Item2);
			}
		}
		Events.RaiseCastSkillCosted(context, character, skillId);
		UpdateAllCommandAvailability(context, character);
	}

	public int GetSkillPrepareSpeed(CombatCharacter character)
	{
		int charSpeed = DomainManager.SpecialEffect.ModifyValue(character.GetId(), character.GetPreparingSkillId(), 194, character.GetSkillPrepareSpeed());
		return CFormula.CalcSkillPrepareSpeed(charSpeed);
	}

	public void CalcSkillQiDisorderAndInjury(CombatCharacter character, CombatSkillItem skillConfig)
	{
		NeiliTypeItem neiliTypeConfig = NeiliType.Instance[character.GetNeiliType()];
		if (CombatSkillDomain.FiveElementEquals(character.GetId(), skillConfig, neiliTypeConfig.InjuryOnUseType))
		{
			AddGoneMadInjury(Context, character, skillConfig.TemplateId);
			ShowSpecialEffectTips(character.GetId(), 1462, 0);
		}
		if (Context.Random.CheckPercentProb(character.GetInjuredRate(skillConfig)))
		{
			AddGoneMadInjury(Context, character, skillConfig.TemplateId);
			ShowSpecialEffectTips(character.GetId(), 1487, 0);
		}
	}

	public void ApplyAgileOrDefenseSkill(CombatCharacter character, CombatSkillItem skillConfig)
	{
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillConfig.TemplateId));
		if (skillConfig.EquipType == 2)
		{
			character.SetAffectingMoveSkillId(skillConfig.TemplateId, Context);
			character.MoveData.ResetJumpState(Context);
			character.NeedAddEffectAgileSkillId = skillConfig.TemplateId;
			UpdateTeammateCommandUsable(Context, character, ETeammateCommandImplement.ClearAgileAndDefense);
		}
		else if (skillConfig.EquipType == 3)
		{
			short keepFrame = CombatSkillDomain.CalcContinuousFrames(skill);
			character.SetAffectingDefendSkillId(skillConfig.TemplateId, Context);
			character.DefendSkillLeftFrame = (character.DefendSkillTotalFrame = keepFrame);
			DomainManager.SpecialEffect.Add(Context, character.GetId(), skillConfig.TemplateId, 0, -1);
			UpdateTeammateCommandUsable(Context, character, ETeammateCommandImplement.ClearAgileAndDefense);
		}
		if (character.GetCharacter().IsCombatSkillEquipped(skillConfig.TemplateId))
		{
			CombatSkillKey key = new CombatSkillKey(character.GetId(), skillConfig.TemplateId);
			_skillCastTimes[key] = _skillCastTimes.GetOrDefault(key) + 1;
		}
	}

	public void CastAgileOrDefenseWithoutPrepare(CombatCharacter character, short skillId)
	{
		Events.RaiseCastAgileOrDefenseWithoutPrepareBegin(Context, character.GetId(), skillId);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		CalcSkillQiDisorderAndInjury(character, skillConfig);
		ApplyAgileOrDefenseSkill(character, skillConfig);
		AddToCheckFallenSet(character.GetId());
		Events.RaiseCastAgileOrDefenseWithoutPrepareEnd(Context, character.GetId(), skillId);
	}

	public unsafe void CalcAttackSkillDataCompare(CombatContext context)
	{
		CombatCharacter attacker = context.Attacker;
		CombatCharacter defender = context.Defender;
		short skillId = context.SkillTemplateId;
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(attacker.GetId(), skillId));
		HitOrAvoidInts hitValue = skill.GetHitValue();
		if (!CombatSkillEquipType.IsMindHitSkill(skillId))
		{
			HitOrAvoidInts hitDistribution = skill.GetHitDistribution();
			attacker.SkillHitType[0] = 2;
			attacker.SkillHitType[1] = 1;
			attacker.SkillHitType[2] = 0;
			attacker.SkillHitValue[0] = ((hitDistribution.Items[2] > 0) ? attacker.GetHitValue(2, attacker.SkillAttackBodyPart, hitValue.Items[2], skillId) : (-1));
			attacker.SkillAvoidValue[0] = ((hitDistribution.Items[2] > 0) ? defender.GetAvoidValue(2, attacker.SkillAttackBodyPart, skillId) : (-1));
			attacker.SkillHitValue[1] = ((hitDistribution.Items[1] > 0) ? attacker.GetHitValue(1, attacker.SkillAttackBodyPart, hitValue.Items[1], skillId) : (-1));
			attacker.SkillAvoidValue[1] = ((hitDistribution.Items[1] > 0) ? defender.GetAvoidValue(1, attacker.SkillAttackBodyPart, skillId) : (-1));
			attacker.SkillHitValue[2] = ((hitDistribution.Items[0] > 0) ? attacker.GetHitValue(0, attacker.SkillAttackBodyPart, hitValue.Items[0], skillId) : (-1));
			attacker.SkillAvoidValue[2] = ((hitDistribution.Items[0] > 0) ? defender.GetAvoidValue(0, attacker.SkillAttackBodyPart, skillId) : (-1));
			attacker.SkillFinalAttackHitIndex = 0;
			bool maxCanHit = CanHit(0);
			int maxDistribution = hitDistribution.Items[2];
			int maxHitOdds = CalcHitOdds(0);
			for (int i = 1; i < 3; i++)
			{
				bool canHit = CanHit(i);
				int distribution = hitDistribution.Items[2 - i];
				int hitOdds = CalcHitOdds(i);
				if ((!maxCanHit || canHit) && (distribution > maxDistribution || (distribution == maxDistribution && hitOdds > maxHitOdds)))
				{
					attacker.SkillFinalAttackHitIndex = i;
					maxCanHit = canHit;
					maxDistribution = distribution;
					maxHitOdds = hitOdds;
				}
			}
		}
		else
		{
			attacker.SkillHitType[0] = 3;
			attacker.SkillHitType[1] = (attacker.SkillHitType[2] = -1);
			attacker.SkillHitValue[0] = attacker.GetHitValue(3, attacker.SkillAttackBodyPart, hitValue.Items[3], skillId);
			attacker.SkillAvoidValue[0] = defender.GetAvoidValue(3, attacker.SkillAttackBodyPart, skillId);
			attacker.SkillFinalAttackHitIndex = 0;
		}
		attacker.SetAttackSkillAttackIndex(0, context);
		attacker.SetPerformingSkillId(skillId, context);
		UpdateDamageCompareData(context);
		int CalcHitOdds(int index)
		{
			return attacker.SkillHitValue[index] * 100 / Math.Max(attacker.SkillAvoidValue[index], 1);
		}
		bool CanHit(int index)
		{
			return attacker.SkillHitValue[index] >= 0 && attacker.SkillHitValue[index] >= attacker.SkillAvoidValue[index];
		}
	}

	public unsafe void CalcSkillAttack(CombatContext context, int attackIndex)
	{
		CombatCharacter character = context.Attacker;
		CombatCharacter enemyChar = context.Defender;
		short skillId = character.GetPerformingSkillId();
		GameData.Domains.Item.Weapon weapon = context.Weapon;
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillId));
		HitOrAvoidInts hitDistribution = skill.GetHitDistribution();
		bool isMindHit = CombatSkillEquipType.IsMindHitSkill(skillId);
		int skillPower = (isMindHit ? ((attackIndex == 0) ? 100 : 0) : ((attackIndex < 3) ? hitDistribution.Items[2 - attackIndex] : (-1)));
		int compareDataIndex = ((attackIndex < 3) ? attackIndex : character.SkillFinalAttackHitIndex);
		sbyte hitType = _damageCompareData.HitType[compareDataIndex];
		CombatProperty property = _damageCompareData.GetProperty(compareDataIndex);
		context = context.Property(property);
		bool critical = context.CheckCritical(hitType);
		context = context.Critical(critical);
		int hitOdds = property.HitOdds;
		if (attackIndex < 3)
		{
			hitOdds = ApplyHitOddsSpecialEffect(character, enemyChar, hitOdds, character.SkillHitType[attackIndex], skillId);
		}
		bool inevitableHit = DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 251, dataValue: false);
		bool inevitableAvoid = DomainManager.SpecialEffect.ModifyData(enemyChar.GetId(), skillId, 290, dataValue: false, critical ? 1 : 0, context.BodyPart, character.GetId());
		bool flag = !inevitableAvoid;
		bool flag2 = flag;
		if (flag2)
		{
			bool flag5;
			if (attackIndex < 3)
			{
				bool isValid = property.IsValid;
				bool flag3 = isValid;
				if (flag3)
				{
					bool flag4 = ((hitOdds < 0 || hitOdds >= 100) ? true : false);
					flag3 = flag4 || character.SkillForceHit || inevitableHit;
				}
				flag5 = flag3;
			}
			else
			{
				flag5 = character.GetAttackSkillPower() > 0;
			}
			flag2 = flag5;
		}
		bool hit = flag2;
		ESkillDamageSectionResult result = ESkillDamageSectionResult.Checked;
		if (hit)
		{
			result |= ESkillDamageSectionResult.Hit;
		}
		if (critical)
		{
			result |= ESkillDamageSectionResult.Critical;
		}
		if (_skillDamageData.MarkSectionResult(result))
		{
			SetSkillDamageData(_skillDamageData, context);
		}
		if (property.IsValid)
		{
			Events.RaiseAttackSkillAttackBegin(context, character, enemyChar, skillId, attackIndex, hit);
		}
		if (hit)
		{
			WeaponItem weaponConfig = Config.Weapon.Instance[weapon.GetTemplateId()];
			if (character.SkillUseLegAsWeapon(skillId))
			{
				ItemKey shoesKey = character.Armors[5];
				GameData.Domains.Item.Armor shoes = (shoesKey.IsValid() ? DomainManager.Item.GetElement_Armors(shoesKey.Id) : null);
				weaponConfig = ((shoes == null || shoes.GetCurrDurability() <= 0) ? Config.Weapon.Instance[(short)0] : Config.Weapon.Instance[Config.Armor.Instance[shoesKey.TemplateId].RelatedWeapon]);
			}
			PlayHitSound(context, enemyChar, weaponConfig);
			if (attackIndex < 3)
			{
				if (skillPower > 0)
				{
					character.SetAttackSkillPower((byte)(character.GetAttackSkillPower() + skillPower), context);
					if (CanPlayHitAnimation(enemyChar))
					{
						enemyChar.SetAnimationToPlayOnce(enemyChar.GetBeHitAni((skillPower > 30) ? ((skillPower <= 60) ? 1 : 2) : 0), context);
					}
					if (!isMindHit)
					{
						int power = skillPower / 2;
						if (power > 0)
						{
							CalcSkillDamage(context, hitType, power, out var _, out critical, power);
						}
					}
					else
					{
						int statePower = hitOdds / 5;
						if (statePower > 0)
						{
							AddCombatState(context, enemyChar, 2, 116, statePower);
						}
					}
				}
			}
			else
			{
				int finalDamage2;
				OuterAndInnerInts markCounts = CalcSkillHit(context, hitType, out finalDamage2, out critical);
				if (CanPlayHitAnimation(enemyChar))
				{
					enemyChar.SetAnimationToPlayOnce(enemyChar.GetBeHitAni(Math.Clamp(markCounts.Outer + markCounts.Inner - 1, 0, 2)), context);
				}
				if (!enemyChar.GetNewPoisonsToShow().IsNonZero() && finalDamage2 <= 0)
				{
					enemyChar.SetParticleToPlay("Particle_D_qidun", context);
				}
				if (enemyChar.GetPreparingOtherAction() == 2 && _currentDistance <= InterruptFleeNeedDistance)
				{
					InterruptOtherAction(context, enemyChar);
				}
			}
		}
		else if (attackIndex < 3 && property.IsValid)
		{
			if (CanPlayHitAnimation(enemyChar))
			{
				enemyChar.SetAnimationToPlayOnce(enemyChar.GetAvoidAni(hitType), context);
			}
			enemyChar.SetParticleToPlay(CombatAnimationConstants.GetAvoidParticle(enemyChar.IsAlly, hitType), context);
			string[] avoidSounds = _avoidSound[hitType];
			enemyChar.SetHitSoundToPlay(avoidSounds[context.Random.Next(avoidSounds.Length)], context);
		}
		else if (attackIndex == 3 && CanPlayHitAnimation(enemyChar))
		{
			enemyChar.SetAnimationToPlayOnce((enemyChar.AnimalConfig == null) ? "H_008" : AvoidAni[2], context);
		}
		if (hit)
		{
			Events.RaiseAttackSkillAttackHit(context, character, enemyChar, skillId, attackIndex, critical);
		}
		if (attackIndex == 3 && (!IsInCombat() || _selectedMercyOption >= 0))
		{
			character.SetPerformingSkillId(-1, context);
			character.SetAttackSkillPower(0, context);
			ClearDamageCompareData(context);
			ClearSkillDamage(context);
		}
		if (attackIndex == 3 && character.GetCharacter().IsCombatSkillEquipped(skillId))
		{
			CombatSkillKey key = new CombatSkillKey(character.GetId(), skillId);
			_skillCastTimes[key] = _skillCastTimes.GetOrDefault(key) + 1;
		}
		if (attackIndex == 3 && character.GetAttackSkillPower() >= 100 && character.GetId() == DomainManager.Taiwu.GetTaiwuCharId() && character.GetCharacter().GetConsummateLevel() <= enemyChar.GetCharacter().GetConsummateLevel())
		{
			DomainManager.Taiwu.AddFullPowerCastTimes(context, skillId);
		}
		if (property.IsValid)
		{
			Events.RaiseAttackSkillAttackEnd(context, hitType, hit, attackIndex);
		}
	}

	private OuterAndInnerInts CalcSkillDamage(CombatContext context, sbyte hitType, int skillPower, out int finalDamage, out bool critical, int bouncePercent = 100)
	{
		CombatCharacter character = context.Attacker;
		CombatCharacter enemyChar = context.Defender;
		short skillId = context.SkillTemplateId;
		bool isMindHit = CombatSkillEquipType.IsMindHitSkill(skillId);
		GameData.Domains.CombatSkill.CombatSkill skill = context.Skill;
		OuterAndInnerInts markCounts = CalcAndAddInjury(context, hitType, out finalDamage, out critical, skillPower);
		CValuePercent poisonRatio = (CValuePercent)skill.GetPower() * (CValuePercent)skillPower;
		PoisonsAndLevels poisons = skill.GetPoisons();
		if (poisons.IsNonZero())
		{
			AddDirectPoison(context, character, enemyChar, poisons, poisonRatio, skillId, context.WeaponKey);
		}
		if (isMindHit)
		{
			return markCounts;
		}
		context.ApplyWeaponAndArmorPoison(3 * skillPower / 100);
		AddBounceDamage(context, hitType, skillId, bouncePercent);
		return markCounts;
	}

	private OuterAndInnerInts CalcSkillHit(CombatContext context, sbyte hitType, out int finalDamage, out bool critical)
	{
		CombatCharacter character = context.Attacker;
		CombatCharacter enemyChar = context.Defender;
		sbyte bodyPart = context.BodyPart;
		short skillId = context.SkillTemplateId;
		byte skillPower = character.GetAttackSkillPower();
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillId));
		context.CheckReduceDurability(skillConfig.EquipmentBreakOdds);
		sbyte level = (sbyte)(skillConfig.GridCost - 1);
		if (skillConfig.HasAtkAcupointEffect && skillPower >= skill.GetSumMax2HitDistribution())
		{
			AddAcupoint(context, enemyChar, level, skill.GetId(), bodyPart);
		}
		if (skillConfig.HasAtkFlawEffect && skillPower >= skill.GetSumMax2HitDistribution())
		{
			AddFlaw(context, enemyChar, level, skill.GetId(), bodyPart);
		}
		OuterAndInnerInts markCounts = CalcSkillDamage(context, hitType, skillPower, out finalDamage, out critical);
		context.ApplyReduceDurabilityByHit();
		_skillDamageData.EquipmentSnapshot.WeaponOrShoesEndDurability = context.WeaponOrShoes?.GetCurrDurability() ?? 0;
		SetSkillDamageData(_skillDamageData, context);
		return markCounts;
	}

	public void DoSkillHit(CombatCharacter attacker, CombatCharacter defender, short skillId, sbyte bodyPart, sbyte hitType)
	{
		CombatContext context = CombatContext.Create(attacker, defender, bodyPart, skillId);
		CalcSkillHit(context, hitType, out var _, out var _);
	}

	public void UpdateSkillCd(DataContext context, CombatCharacter character)
	{
		foreach (CombatSkillData skillData in _skillDataDict.Values)
		{
			if (skillData.GetId().CharId == character.GetId() && skillData.GetLeftCdFrame() > 0)
			{
				skillData.SetLeftCdFrame((short)(skillData.GetLeftCdFrame() - 1), context);
				if (skillData.GetLeftCdFrame() == 0)
				{
					skillData.RaiseSkillSilenceEnd(context);
					UpdateSkillCanUse(context, character, skillData.GetId().SkillTemplateId);
				}
			}
		}
	}

	public sbyte AddGoneMadInjury(DataContext context, CombatCharacter character, short skillId, int factor = 0)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		int extraAddPercent = 0;
		foreach (CombatCharacter enemyChar in GetCharacters(!character.IsAlly))
		{
			foreach (short featureId in enemyChar.GetCharacter().GetValidFeatureIds())
			{
				extraAddPercent += CharacterFeature.Instance[featureId].InCombatEnemyGoneMadInjuryAddPercent;
			}
		}
		int extraTotalPercent = character.GetGoneMadInjuryTotalPercent(configData);
		sbyte injuryCount = configData.GoneMadInjuryValue;
		bool inner = configData.GoneMadInnerInjury;
		DamageStepCollection steps = character.GetDamageStepCollection();
		bool addingDisorderOfQi = false;
		sbyte part = character.RandomInjuryBodyPart(context.Random, inner, configData.GoneMadInjuredPart);
		int fatalDamage = 0;
		if (part < 0)
		{
			fatalDamage = ModifyValue(injuryCount * steps.FatalDamageStep);
		}
		else
		{
			int[] injuryValues = (inner ? character.GetInnerDamageValue() : character.GetOuterDamageValue());
			int injuryStep = (inner ? steps.InnerDamageSteps : steps.OuterDamageSteps)[part];
			int remainMark = 6 - character.GetInjuries().Get(part, inner);
			int totalDamage = ModifyValue(injuryCount * injuryStep) + injuryValues[part];
			var (markCount, leftDamage) = CMath.CalcMarkAndLeftDamage(totalDamage, injuryStep, remainMark);
			if (markCount > 0)
			{
				character.AddInjury(context, part, inner, (sbyte)markCount, updateDefeatMark: true);
			}
			if (markCount == remainMark)
			{
				fatalDamage = leftDamage * steps.FatalDamageStep / injuryStep;
			}
			else
			{
				injuryValues[part] = leftDamage;
				if (inner)
				{
					character.SetInnerDamageValue(injuryValues, context);
				}
				else
				{
					character.SetOuterDamageValue(injuryValues, context);
				}
			}
		}
		if (fatalDamage > 0)
		{
			character.AddFatalDamage(context, fatalDamage, configData.GoneMadInnerInjury ? 1 : 0, -1, -1);
		}
		addingDisorderOfQi = true;
		character.GetCharacter().ChangeDisorderOfQiRandomRecovery(Context, ModifyValue(configData.GoneMadQiDisorder));
		return part;
		int ModifyValue(int value)
		{
			value = DomainManager.SpecialEffect.ModifyValueCustom(character.GetId(), skillId, 117, value, -1, -1, -1, 0, extraAddPercent, extraTotalPercent, extraTotalPercent);
			value *= (CValuePercentBonus)factor;
			return DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 320, value, inner ? 1 : 0, part, addingDisorderOfQi ? 1 : 0);
		}
	}

	public void AddGoneMadInjuryOutOfCombat(DataContext context, GameData.Domains.Character.Character character, short skillId)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		Injuries injuries = character.GetInjuries();
		List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		partRandomPool.Clear();
		foreach (sbyte part in configData.GoneMadInjuredPart)
		{
			if (injuries.Get(part, configData.GoneMadInnerInjury) < 6)
			{
				partRandomPool.Add(part);
			}
		}
		if (partRandomPool.Count > 0)
		{
			sbyte part2 = partRandomPool[context.Random.Next(0, partRandomPool.Count)];
			injuries.Change(part2, configData.GoneMadInnerInjury, configData.GoneMadInjuryValue);
			character.SetInjuries(injuries, context);
		}
		ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
	}

	[DomainMethod]
	public bool InterruptSkillManual(DataContext context, bool isAlly = true)
	{
		return InterruptSkill(context, isAlly ? _selfChar : _enemyChar, -1);
	}

	public bool InterruptSkill(DataContext context, CombatCharacter character, int odds = 100)
	{
		short preparingSkillId = character.GetPreparingSkillId();
		if (preparingSkillId < 0)
		{
			return false;
		}
		if (odds > 0)
		{
			odds = (DomainManager.SpecialEffect.ModifyData(character.GetId(), preparingSkillId, 215, dataValue: true) ? (odds + DomainManager.SpecialEffect.GetModifyValue(character.GetId(), preparingSkillId, 216, EDataModifyType.Add)) : 0);
			odds = Math.Max(odds, 0);
		}
		if (odds < 0 || context.Random.CheckPercentProb(odds))
		{
			character.SetPreparingSkillId(-1, context);
			DomainManager.Combat.RaiseCastSkillEndByInterrupt(context, character.GetId(), character.IsAlly, preparingSkillId);
			return true;
		}
		return false;
	}

	public int GetInterruptSkillOdds(CombatSkillKey skillKey, CombatCharacter castingChar)
	{
		short preparingSkillId = castingChar.GetPreparingSkillId();
		if (preparingSkillId < 0)
		{
			return 0;
		}
		sbyte direction = DomainManager.CombatSkill.GetSkillDirection(skillKey.CharId, skillKey.SkillTemplateId);
		if (direction == -1)
		{
			return 0;
		}
		if (!DomainManager.SpecialEffect.ModifyData(castingChar.GetId(), preparingSkillId, 215, dataValue: true))
		{
			return 0;
		}
		Dictionary<short, Func<CombatSkillKey, bool, CombatSkillKey, int>> funcDict = CombatSkillEffectBase.CalcInterruptOddsFuncDict;
		int interruptOdds = (funcDict.ContainsKey(skillKey.SkillTemplateId) ? funcDict[skillKey.SkillTemplateId](skillKey, direction == 0, new CombatSkillKey(castingChar.GetId(), preparingSkillId)) : 0);
		interruptOdds += DomainManager.SpecialEffect.GetModifyValue(castingChar.GetId(), preparingSkillId, 216, EDataModifyType.Add);
		return Math.Clamp(interruptOdds, 0, 100);
	}

	public bool SilenceSkill(DataContext context, CombatCharacter character, short skillId, int silenceFrame, int odds = 100)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		if (odds > 0)
		{
			if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), skillId, 217, dataValue: true))
			{
				return false;
			}
			int pageEffect = skill.GetPageEffects().Sum((SkillBreakPageEffectImplementItem x) => x.SilenceRate);
			odds = DomainManager.SpecialEffect.ModifyValue(character.GetId(), skillId, 218, odds, -1, -1, -1, 0, pageEffect);
			odds = Math.Max(odds, 0);
		}
		if (odds >= 0 && !context.Random.CheckPercentProb(odds))
		{
			return false;
		}
		if (silenceFrame > 0)
		{
			int pageEffect2 = skill.GetPageEffects().Sum((SkillBreakPageEffectImplementItem x) => x.SilenceFrame);
			(int, int) extraTotalPercent = character.GetFeatureSilenceFrameTotalPercent();
			silenceFrame = DomainManager.SpecialEffect.ModifyValue(character.GetId(), skillId, 264, silenceFrame, -1, -1, -1, 0, pageEffect2, extraTotalPercent.Item1, extraTotalPercent.Item2);
		}
		short silenceFrameShort = (short)Math.Clamp(silenceFrame, -1, 32767);
		if (silenceFrameShort == 0)
		{
			return false;
		}
		CombatSkillData skillData = _skillDataDict[skillKey];
		if (skillData.GetLeftCdFrame() < 0 || skillData.GetTotalCdFrame() < 0)
		{
			return false;
		}
		if (silenceFrameShort < 0 || silenceFrameShort > skillData.GetTotalCdFrame() || skillData.GetLeftCdFrame() == 0)
		{
			skillData.SetTotalCdFrame(silenceFrameShort, context);
		}
		if (silenceFrameShort < 0 || silenceFrameShort > skillData.GetLeftCdFrame())
		{
			skillData.SetLeftCdFrame(silenceFrameShort, context);
		}
		skillData.RaiseSkillSilence(context);
		UpdateSkillCanUse(context, character, skillId);
		if (character.GetAffectingMoveSkillId() == skillId)
		{
			ClearAffectingAgileSkill(context, character);
		}
		if (character.GetAffectingDefendSkillId() == skillId)
		{
			ClearAffectingDefenseSkill(context, character);
		}
		if (character.GetPreparingSkillId() == skillId)
		{
			InterruptSkill(context, character);
		}
		return true;
	}

	public void DoubleSkillCd(DataContext context, CombatCharacter character, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		CombatSkillData skillData = _skillDataDict[skillKey];
		if (skillData.GetLeftCdFrame() > 0)
		{
			short newTotalCd = (short)Math.Min(skillData.GetTotalCdFrame() * 2, 32767);
			short newCd = (short)Math.Min(skillData.GetLeftCdFrame() * 2, newTotalCd);
			skillData.SetTotalCdFrame(newTotalCd, context);
			skillData.SetLeftCdFrame(newCd, context);
		}
	}

	public void ResetSkillCd(DataContext context, CombatCharacter character, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		CombatSkillData skillData = _skillDataDict[skillKey];
		skillData.SetLeftCdFrame(skillData.GetTotalCdFrame(), context);
	}

	public void ClearSkillCd(DataContext context, CombatCharacter character, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), skillId);
		CombatSkillData skillData = _skillDataDict[skillKey];
		skillData.SetTotalCdFrame(0, context);
		skillData.SetLeftCdFrame(0, context);
		skillData.RaiseSkillSilenceEnd(context);
		UpdateSkillCanUse(context, character, skillId);
	}

	public void RaiseCastSkillEndByInterrupt(DataContext context, int charId, bool isAlly, short skillId)
	{
		RaiseCastSkillEnd(context, charId, isAlly, skillId, 0, interrupt: true);
	}

	public void RaiseCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power = 0, bool interrupt = false, int finalCriticalOdds = 0)
	{
		Events.RaiseCastSkillEnd(context, charId, isAlly, skillId, power, interrupt);
		if (IsInCombat() && _combatCharacterDict.TryGetValue(charId, out var combatChar))
		{
			DomainManager.Combat.OnCastSkillEndEffect(context, combatChar, skillId, power, finalCriticalOdds);
		}
		Events.RaiseCastSkillAllEnd(context, charId, skillId);
		SetSkillDamageIndex(-1);
	}

	public void OnCastSkillEndEffect(DataContext context, CombatCharacter combatChar, short skillId, int power = 0, int finalCriticalOdds = 0)
	{
		if (CombatSkillEquipType.IsAttack(skillId))
		{
			combatChar.ClearAddPowerUntilCast(context);
		}
		OnCastSkillEndBreakBonus(context, combatChar, skillId);
		OnCastSkillEndFeature(context, combatChar, skillId, power, finalCriticalOdds);
	}

	private void OnCastSkillEndBreakBonus(DataContext context, CombatCharacter combatChar, short skillId)
	{
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: combatChar.GetId(), skillId: skillId), out var combatSkill))
		{
			int silenceRate = combatSkill.GetBreakoutGridCombatSkillPropertyBonus(70);
			if (silenceRate > 0)
			{
				int silenceFrame = combatSkill.GetBreakoutGridCombatSkillPropertyBonus(71);
				SilenceSkill(context, combatChar, skillId, (short)Math.Clamp(silenceFrame, 0, 32767), silenceRate);
			}
		}
	}

	private void OnCastSkillEndFeature(DataContext context, CombatCharacter attacker, short skillId, int power, int finalCriticalOdds)
	{
		if (power < 100)
		{
			return;
		}
		CombatCharacter defender = GetCombatCharacter(!attacker.IsAlly, tryGetCoverCharacter: true);
		List<short> attackerFeatures = attacker.GetCharacter().GetFeatureIds();
		List<short> defenderFeatures = defender.GetCharacter().GetFeatureIds();
		byte neiliTypeFiveElements = NeiliType.Instance[defender.GetNeiliType()].FiveElements;
		foreach (LifeLinkFeatureEffectItem item in (IEnumerable<LifeLinkFeatureEffectItem>)LifeLinkFeatureEffect.Instance)
		{
			LifeLinkFeatureEffectItem config = item;
			bool featureInAttacker = attackerFeatures.Contains(config.FeatureId);
			bool featureInDefender = defenderFeatures.Contains(config.FeatureId);
			if (!featureInAttacker && !featureInDefender)
			{
				continue;
			}
			if (config.CriticalProbPercent > 0)
			{
				if (CheckProb() && featureInAttacker && FiveElementEquals(config.FiveElements) && neiliTypeFiveElements == FiveElementsType.Countering[config.FiveElements])
				{
					AddGoneMadInjury(context, defender, skillId);
					ShowSpecialEffectTips(attacker.GetId(), 1713, 0);
				}
				if (CheckProb() && featureInDefender && FiveElementEquals(FiveElementsType.Countered[config.FiveElements]))
				{
					AddGoneMadInjury(context, defender, skillId);
					ShowSpecialEffectTips(defender.GetId(), 1714, 0);
				}
			}
			if (config.CriticalProbPercent < 0 && featureInDefender && CheckProb() && (FiveElementEquals(config.FiveElements) || FiveElementEquals(FiveElementsType.Countered[config.FiveElements])))
			{
				AddGoneMadInjury(context, defender, skillId);
				ShowSpecialEffectTips(defender.GetId(), 1715, 0);
			}
			bool CheckProb()
			{
				return context.Random.CheckPercentProb(finalCriticalOdds * (CValuePercent)Math.Abs(config.CriticalProbPercent));
			}
		}
		bool FiveElementEquals(int fiveElementType)
		{
			return CombatSkillDomain.FiveElementEquals(attacker.GetId(), skillId, (sbyte)fiveElementType);
		}
	}

	public short GetRandomAttackSkill(CombatCharacter combatChar, sbyte skillType, sbyte targetGrade, IRandomSource random, bool descSearch = true, short expectSkillId = -1)
	{
		List<short> attackSkillList = ObjectPool<List<short>>.Instance.Get();
		List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
		attackSkillList.Clear();
		attackSkillList.AddRange(combatChar.GetAttackSkillList());
		attackSkillList.RemoveAll((short id) => id < 0 || id == expectSkillId);
		skillRandomPool.Clear();
		targetGrade = Math.Clamp(targetGrade, 0, 8);
		for (int grade = targetGrade; grade != (descSearch ? (-1) : 9); grade += ((!descSearch) ? 1 : (-1)))
		{
			for (int i = 0; i < attackSkillList.Count; i++)
			{
				short attackSkillId = attackSkillList[i];
				if (Config.CombatSkill.Instance[attackSkillId].Grade == grade && DomainManager.CombatSkill.GetSkillType(combatChar.GetId(), attackSkillId) == skillType && DomainManager.Combat.CanCastSkill(combatChar, attackSkillId, costFree: true))
				{
					skillRandomPool.Add(attackSkillId);
				}
			}
			if (skillRandomPool.Count > 0)
			{
				break;
			}
		}
		short skillId = (short)((skillRandomPool.Count > 0) ? skillRandomPool[random.Next(0, skillRandomPool.Count)] : (-1));
		ObjectPool<List<short>>.Instance.Return(attackSkillList);
		ObjectPool<List<short>>.Instance.Return(skillRandomPool);
		return skillId;
	}

	[DomainMethod]
	public void ClearAffectingMoveSkillManual(DataContext context, bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		ClearAffectingAgileSkill(context, combatChar);
	}

	public bool ClearAffectingAgileSkillByEffect(DataContext context, CombatCharacter character, CombatCharacter changer = null)
	{
		if (!DomainManager.SpecialEffect.ModifyData(character.GetId(), -1, 149, dataValue: true, changer?.GetId() ?? (-1)))
		{
			return false;
		}
		return ClearAffectingAgileSkill(context, character);
	}

	public bool ClearAffectingAgileSkill(DataContext context, CombatCharacter character)
	{
		if (character.GetAffectingMoveSkillId() < 0)
		{
			return false;
		}
		if (character.NeedAddEffectAgileSkillId == character.GetAffectingMoveSkillId())
		{
			character.NeedAddEffectAgileSkillId = -1;
		}
		character.SetAffectingMoveSkillId(-1, context);
		return true;
	}

	[DomainMethod]
	public void ClearAffectingDefenseSkillManual(DataContext context, bool isAlly)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		ClearAffectingDefenseSkill(context, combatChar);
	}

	public bool ClearAffectingDefenseSkill(DataContext context, CombatCharacter character)
	{
		if (character.GetAffectingDefendSkillId() < 0)
		{
			return false;
		}
		character.DefendSkillLeftFrame = 1;
		character.SetAffectingDefendSkillId(-1, context);
		SetProperLoopAniAndParticle(context, character);
		return true;
	}

	public bool CanCastSkill(CombatCharacter character, short skillId, bool costFree = false, bool checkRange = false)
	{
		_skillDataDict.TryGetValue(new CombatSkillKey(character.GetId(), skillId), out var skillData);
		CombatSkillItem configData = Config.CombatSkill.Instance[skillId];
		bool isAttackSkill = configData.EquipType == 1;
		return character.PreventCastSkillEffectCount == 0 && !character.PreparingTeammateCommand() && (skillData == null || skillData.GetLeftCdFrame() == 0) && (costFree || SkillCostEnough(character, skillId)) && HasSkillNeedBodyPart(character, skillId) && (!isAttackSkill || WeaponHasNeedTrick(character, skillId, GetUsingWeaponData(character))) && (!character.IsAlly || costFree || SkillCanUseInCurrCombat(character.GetId(), configData)) && SkillDirectionCanCast(character, skillId) && (!isAttackSkill || !checkRange || SkillInCastRange(character, skillId));
	}

	public void CastSkillFree(DataContext context, CombatCharacter character, short skillId, ECombatCastFreePriority priority = ECombatCastFreePriority.Normal)
	{
		if (!character.CastFreeDataList.Contains((skillId: skillId, priority: priority)))
		{
			character.CastFreeDataList.Add((skillId: skillId, priority: priority));
			character.CastFreeDataList.Sort();
			UpdateAllCommandAvailability(context, character);
		}
	}

	public void ChangeSkillPrepareProgress(CombatCharacter character, int progress)
	{
		if (character.GetPreparingSkillId() >= 0)
		{
			character.SkillPrepareCurrProgress = Math.Max(character.SkillPrepareCurrProgress, progress);
		}
	}

	public void AddSkillPowerInCombat(DataContext context, CombatSkillKey skillKey, SkillEffectKey effectKey, int power)
	{
		if (power > 0)
		{
			SkillPowerChangeCollection powerCollection;
			bool exist = _skillPowerAddInCombat.TryGetValue(skillKey, out powerCollection);
			if (!exist)
			{
				powerCollection = new SkillPowerChangeCollection();
			}
			powerCollection.Add(effectKey, power);
			if (!exist)
			{
				AddElement_SkillPowerAddInCombat(skillKey, powerCollection, context);
			}
			else
			{
				SetElement_SkillPowerAddInCombat(skillKey, powerCollection, context);
			}
		}
	}

	public SkillPowerChangeCollection RemoveSkillPowerAddInCombat(DataContext context, CombatSkillKey skillKey)
	{
		if (!_skillPowerAddInCombat.TryGetValue(skillKey, out var powerCollection))
		{
			return null;
		}
		if (!DomainManager.SpecialEffect.ModifyData(skillKey.CharId, skillKey.SkillTemplateId, 220, dataValue: true))
		{
			return null;
		}
		RemoveElement_SkillPowerAddInCombat(skillKey, context);
		return powerCollection;
	}

	public int RemoveSkillPowerAddInCombat(DataContext context, CombatSkillKey skillKey, SkillEffectKey source)
	{
		if (!_skillPowerAddInCombat.TryGetValue(skillKey, out var powerCollection))
		{
			return 0;
		}
		if (!DomainManager.SpecialEffect.ModifyData(skillKey.CharId, skillKey.SkillTemplateId, 220, dataValue: true))
		{
			return 0;
		}
		if (powerCollection.EffectDict.ContainsKey(source))
		{
			int power = powerCollection.EffectDict[source];
			powerCollection.EffectDict.Remove(source);
			SetElement_SkillPowerAddInCombat(skillKey, powerCollection, context);
			return power;
		}
		return 0;
	}

	public Dictionary<CombatSkillKey, SkillPowerChangeCollection> GetAllSkillPowerAddInCombat()
	{
		return _skillPowerAddInCombat;
	}

	public int GetReduceSkillPowerInCombat(CombatSkillKey skillKey, SkillEffectKey effectKey)
	{
		if (!_skillPowerReduceInCombat.TryGetValue(skillKey, out var powerCollection))
		{
			return 0;
		}
		int value;
		return powerCollection.EffectDict.TryGetValue(effectKey, out value) ? value : 0;
	}

	public void ReduceSkillPowerInCombat(DataContext context, CombatSkillKey skillKey, SkillEffectKey effectKey, int power)
	{
		if (power < 0)
		{
			SkillPowerChangeCollection powerCollection;
			bool exist = _skillPowerReduceInCombat.TryGetValue(skillKey, out powerCollection);
			if (!exist)
			{
				powerCollection = new SkillPowerChangeCollection();
			}
			powerCollection.Add(effectKey, power);
			if (!exist)
			{
				AddElement_SkillPowerReduceInCombat(skillKey, powerCollection, context);
			}
			else
			{
				SetElement_SkillPowerReduceInCombat(skillKey, powerCollection, context);
			}
		}
	}

	public SkillPowerChangeCollection RemoveSkillPowerReduceInCombat(DataContext context, CombatSkillKey skillKey)
	{
		if (!_skillPowerReduceInCombat.TryGetValue(skillKey, out var powerCollection))
		{
			return null;
		}
		RemoveElement_SkillPowerReduceInCombat(skillKey, context);
		return powerCollection;
	}

	public int RemoveSkillPowerReduceInCombat(DataContext context, CombatSkillKey skillKey, SkillEffectKey source)
	{
		if (!_skillPowerReduceInCombat.TryGetValue(skillKey, out var powerCollection))
		{
			return 0;
		}
		if (powerCollection.EffectDict.ContainsKey(source))
		{
			int power = powerCollection.EffectDict[source];
			powerCollection.EffectDict.Remove(source);
			SetElement_SkillPowerReduceInCombat(skillKey, powerCollection, context);
			return power;
		}
		return 0;
	}

	public Dictionary<CombatSkillKey, SkillPowerChangeCollection> GetAllSkillPowerReduceInCombat()
	{
		return _skillPowerReduceInCombat;
	}

	public void SetSkillPowerReplaceInCombat(DataContext context, CombatSkillKey targetSkillKey, CombatSkillKey powerSkillKey)
	{
		if (!_skillPowerReplaceInCombat.ContainsKey(targetSkillKey))
		{
			AddElement_SkillPowerReplaceInCombat(targetSkillKey, powerSkillKey, context);
		}
		else
		{
			SetElement_SkillPowerReplaceInCombat(targetSkillKey, powerSkillKey, context);
		}
	}

	public void RemoveSkillPowerReplaceInCombat(DataContext context, CombatSkillKey targetSkillKey)
	{
		if (_skillPowerReplaceInCombat.ContainsKey(targetSkillKey))
		{
			RemoveElement_SkillPowerReplaceInCombat(targetSkillKey, context);
		}
	}

	public Dictionary<CombatSkillKey, CombatSkillKey> GetAllSkillPowerReplaceInCombat()
	{
		return _skillPowerReplaceInCombat;
	}

	public void AddMoveDistInSkillPrepare(CombatCharacter character, short dist, bool forward)
	{
		if (forward)
		{
			character.MoveData.CanMoveForwardInSkillPrepareDist += dist;
		}
		else
		{
			character.MoveData.CanMoveBackwardInSkillPrepareDist += dist;
		}
	}

	public void AddSkillEffect(DataContext context, CombatCharacter combatChar, SkillEffectKey key, short count, short maxCount, bool autoRemoveOnNoCount)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		SkillEffectCollection skillEffectCollection = effectCollection;
		if (skillEffectCollection.EffectDict == null)
		{
			skillEffectCollection.EffectDict = new Dictionary<SkillEffectKey, short>();
		}
		skillEffectCollection = effectCollection;
		if (skillEffectCollection.EffectDescriptionDict == null)
		{
			skillEffectCollection.EffectDescriptionDict = new Dictionary<SkillEffectKey, CombatSkillEffectDescriptionDisplayData>();
		}
		effectCollection.EffectDict[key] = count;
		effectCollection.EffectDescriptionDict[key] = DomainManager.CombatSkill.GetEffectDisplayData(combatChar.GetId(), key.SkillId);
		effectCollection.MaxEffectCountDict[key] = maxCount;
		effectCollection.AutoRemoveOnNoCountDict[key] = autoRemoveOnNoCount;
		combatChar.SetSkillEffectCollection(effectCollection, context);
		Events.RaiseSkillEffectChange(context, combatChar.GetId(), key, 0, count, removed: false);
	}

	public void ChangeSkillEffectCount(DataContext context, CombatCharacter combatChar, SkillEffectKey key, short addValue, bool raiseEvent = true, bool forceChange = false)
	{
		if (!DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), key.SkillId, 222, dataValue: true) && !forceChange)
		{
			return;
		}
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict == null || !effectCollection.EffectDict.ContainsKey(key))
		{
			return;
		}
		short oldCount = effectCollection.EffectDict[key];
		short maxCount = effectCollection.MaxEffectCountDict[key];
		short count = (short)Math.Clamp(oldCount + addValue, 0, maxCount);
		if (count == 0 && effectCollection.AutoRemoveOnNoCountDict[key])
		{
			RemoveSkillEffect(context, combatChar, key);
			return;
		}
		effectCollection.EffectDict[key] = count;
		combatChar.SetSkillEffectCollection(effectCollection, context);
		if (raiseEvent)
		{
			Events.RaiseSkillEffectChange(context, combatChar.GetId(), key, oldCount, count, removed: false);
		}
	}

	public bool IsSkillEffectExist(CombatCharacter combatChar, SkillEffectKey key)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		return effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key);
	}

	public short GetSkillEffectCount(CombatCharacter combatChar, SkillEffectKey key)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key))
		{
			return effectCollection.EffectDict[key];
		}
		return 0;
	}

	public void ClearSkillEffect(DataContext context, CombatCharacter combatChar)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && !DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), -1, 327, dataValue: false))
		{
			List<SkillEffectKey> keys = ObjectPool<List<SkillEffectKey>>.Instance.Get();
			List<short> values = ObjectPool<List<short>>.Instance.Get();
			keys.Clear();
			values.Clear();
			keys.AddRange(effectCollection.EffectDict.Keys);
			values.AddRange(effectCollection.EffectDict.Values);
			effectCollection.EffectDict.Clear();
			effectCollection.EffectDescriptionDict.Clear();
			effectCollection.MaxEffectCountDict.Clear();
			effectCollection.AutoRemoveOnNoCountDict.Clear();
			combatChar.SetSkillEffectCollection(effectCollection, context);
			for (int i = 0; i < keys.Count; i++)
			{
				Events.RaiseSkillEffectChange(context, combatChar.GetId(), keys[i], values[i], 0, removed: true);
			}
			ObjectPool<List<SkillEffectKey>>.Instance.Return(keys);
			ObjectPool<List<short>>.Instance.Return(values);
		}
	}

	public void RemoveSkillEffect(DataContext context, CombatCharacter combatChar, SkillEffectKey key)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key))
		{
			short oldCount = effectCollection.EffectDict[key];
			effectCollection.EffectDict.Remove(key);
			effectCollection.EffectDescriptionDict.Remove(key);
			effectCollection.MaxEffectCountDict.Remove(key);
			effectCollection.AutoRemoveOnNoCountDict.Remove(key);
			combatChar.SetSkillEffectCollection(effectCollection, context);
			Events.RaiseSkillEffectChange(context, combatChar.GetId(), key, oldCount, 0, removed: true);
		}
	}

	public bool ChangeSkillEffectRandom(DataContext context, CombatCharacter target, CValuePercent percent, int maxChangeCount = 1, sbyte requireEquipType = -1)
	{
		if (percent == 0)
		{
			return false;
		}
		SkillEffectCollection effectCollection = target.GetSkillEffectCollection();
		if (effectCollection?.EffectDict == null)
		{
			return false;
		}
		bool anyChanged = false;
		bool isAdd = percent > 0;
		int maxDeltaRange = 0;
		List<SkillEffectKey> prefer = ObjectPool<List<SkillEffectKey>>.Instance.Get();
		List<SkillEffectKey> normal = ObjectPool<List<SkillEffectKey>>.Instance.Get();
		foreach (KeyValuePair<SkillEffectKey, short> item in effectCollection.EffectDict)
		{
			item.Deconstruct(out var key, out var value);
			SkillEffectKey key2 = key;
			short count = value;
			short maxCount = effectCollection.MaxEffectCountDict[key2];
			int deltaRange = (isAdd ? (maxCount - count) : count);
			if (deltaRange != 0 && (requireEquipType < 0 || requireEquipType == Config.CombatSkill.Instance[key2.SkillId].EquipType))
			{
				if (deltaRange > maxDeltaRange)
				{
					normal.AddRange(prefer);
					prefer.Clear();
					maxDeltaRange = deltaRange;
				}
				if (deltaRange == maxDeltaRange)
				{
					prefer.Add(key2);
				}
				else
				{
					normal.Add(key2);
				}
			}
		}
		foreach (SkillEffectKey key3 in RandomUtils.GetRandomUnrepeated(context.Random, maxChangeCount, prefer, normal))
		{
			anyChanged = true;
			int delta = effectCollection.MaxEffectCountDict[key3] * percent;
			if (delta == 0)
			{
				delta = (isAdd ? 1 : (-1));
			}
			ChangeSkillEffectCount(context, target, key3, (short)delta);
		}
		ObjectPool<List<SkillEffectKey>>.Instance.Return(prefer);
		ObjectPool<List<SkillEffectKey>>.Instance.Return(normal);
		return anyChanged;
	}

	public void ChangeSkillEffectToMinCount(DataContext context, CombatCharacter combatChar, SkillEffectKey key)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key))
		{
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[key.SkillId];
			short effectId = (key.IsDirect ? skillConfig.DirectEffectID : skillConfig.ReverseEffectID);
			short minCount = Config.SpecialEffect.Instance[effectId].MinEffectCount;
			if (effectCollection.EffectDict[key] > minCount)
			{
				ChangeSkillEffectCount(context, combatChar, key, (short)(minCount - effectCollection.EffectDict[key]));
			}
		}
	}

	public void ChangeSkillEffectToMaxCount(DataContext context, CombatCharacter combatChar, SkillEffectKey key)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key))
		{
			short maxCount = effectCollection.MaxEffectCountDict[key];
			if (effectCollection.EffectDict[key] < maxCount)
			{
				ChangeSkillEffectCount(context, combatChar, key, (short)(maxCount - effectCollection.EffectDict[key]));
			}
		}
	}

	public void ChangeSkillEffectDirection(DataContext context, CombatCharacter combatChar, SkillEffectKey key, bool isDirect)
	{
		SkillEffectCollection effectCollection = combatChar.GetSkillEffectCollection();
		if (effectCollection.EffectDict != null && effectCollection.EffectDict.ContainsKey(key))
		{
			SkillEffectKey newKey = new SkillEffectKey(key.SkillId, isDirect);
			effectCollection.EffectDict.Add(newKey, effectCollection.EffectDict[key]);
			effectCollection.EffectDescriptionDict.Add(newKey, effectCollection.EffectDescriptionDict[key]);
			effectCollection.MaxEffectCountDict.Add(newKey, effectCollection.MaxEffectCountDict[key]);
			effectCollection.AutoRemoveOnNoCountDict.Add(newKey, effectCollection.AutoRemoveOnNoCountDict[key]);
			effectCollection.EffectDict.Remove(key);
			effectCollection.EffectDescriptionDict.Remove(key);
			effectCollection.MaxEffectCountDict.Remove(key);
			effectCollection.AutoRemoveOnNoCountDict.Remove(key);
			combatChar.SetSkillEffectCollection(effectCollection, context);
		}
	}

	[DomainMethod]
	public void PlayMoveStepSound(DataContext context, bool isAlly)
	{
		if (IsInCombat())
		{
			CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
			PlayStepSound(context, combatChar);
			PlayShockSound(context, combatChar);
		}
	}

	public void PlayHitSound(DataContext context, CombatCharacter character, WeaponItem weaponData)
	{
		List<string> hitSoundList = weaponData.HitSounds;
		ItemKey armorKey = character.Armors[0];
		if (hitSoundList != null && hitSoundList.Count > 0)
		{
			character.SetHitSoundToPlay(hitSoundList[context.Random.Next(hitSoundList.Count)], context);
		}
		if (!armorKey.IsValid())
		{
			return;
		}
		sbyte resourceType = DomainManager.Item.GetElement_Armors(armorKey.Id).GetResourceType();
		if (resourceType >= 0)
		{
			string[] armorHitSoundList = Config.ResourceType.Instance[resourceType].HitSound;
			string[] armorShockSoundList = Config.ResourceType.Instance[resourceType].ShockSound;
			if (weaponData.PlayArmorHitSound && armorHitSoundList != null && armorHitSoundList.Length != 0)
			{
				character.SetArmorHitSoundToPlay(armorHitSoundList[context.Random.Next(armorHitSoundList.Length)], context);
			}
			if (armorShockSoundList != null && armorShockSoundList.Length != 0)
			{
				character.SetShockSoundToPlay(armorShockSoundList[context.Random.Next(armorShockSoundList.Length)], context);
			}
		}
	}

	public void PlayBlockSound(DataContext context, CombatCharacter character)
	{
		string blockSound = null;
		if (character.AnimalConfig == null)
		{
			List<string> blockSoundList = Config.Weapon.Instance[GetUsingWeaponKey(character).TemplateId].BlockSounds;
			if (blockSoundList != null && blockSoundList.Count > 0)
			{
				blockSound = blockSoundList[context.Random.Next(blockSoundList.Count)];
			}
		}
		else
		{
			blockSound = character.AnimalConfig.BlockSound;
		}
		if (blockSound != null)
		{
			character.SetHitSoundToPlay(blockSound, context);
		}
	}

	public void PlayWhooshSound(DataContext context, CombatCharacter character)
	{
		ItemKey armorKey = character.Armors[0];
		if (armorKey.IsValid())
		{
			sbyte resourceType = DomainManager.Item.GetElement_Armors(armorKey.Id).GetResourceType();
			if (resourceType >= 0)
			{
				string[] soundList = Config.ResourceType.Instance[resourceType].WhooshSound;
				if (soundList != null && soundList.Length != 0)
				{
					character.SetWhooshSoundToPlay(soundList[context.Random.Next(soundList.Length)], context);
				}
			}
		}
		else
		{
			character.SetWhooshSoundToPlay("se_combat_whoosh_empty", context);
		}
	}

	public void PlayShockSound(DataContext context, CombatCharacter character)
	{
		ItemKey armorKey = character.Armors[0];
		if (!armorKey.IsValid())
		{
			return;
		}
		sbyte resourceType = DomainManager.Item.GetElement_Armors(armorKey.Id).GetResourceType();
		if (resourceType >= 0)
		{
			string[] soundList = Config.ResourceType.Instance[resourceType].ShockSound;
			if (soundList != null && soundList.Length != 0)
			{
				character.SetShockSoundToPlay(soundList[context.Random.Next(soundList.Length)], context);
			}
		}
	}

	public void PlayStepSound(DataContext context, CombatCharacter character)
	{
		ItemKey shoesKey = character.Armors[5];
		IList<string> soundList;
		if (character.IsAnimal)
		{
			soundList = character.AnimalConfig.StepSound;
		}
		else if (shoesKey.IsValid())
		{
			sbyte resourceType = DomainManager.Item.GetElement_Armors(shoesKey.Id).GetResourceType();
			soundList = ((resourceType >= 0) ? Config.ResourceType.Instance[resourceType].StepSound : NoResourceTypeStepSound);
		}
		else
		{
			soundList = NoResourceTypeStepSound;
		}
		if (soundList != null && soundList.Count > 0)
		{
			character.SetStepSoundToPlay(soundList.GetRandom(context.Random), context);
		}
	}

	private void InitializeStatistics()
	{
		Events.RegisterHandler_CombatSettlement(StatisticsOnCombatSettlement);
		InitializeStatisticsAchievement();
		InitializeStatisticsGuidingChapter();
		InitializeStatisticsTaiwuLifeSummary();
	}

	private void StatisticsMonitorTaiwu(ushort fieldId, DataModificationHandler handler)
	{
		if (TaiwuInCombat)
		{
			StatisticsMonitorCombatChar(_selfTeam[0], fieldId, handler);
		}
	}

	private void StatisticsMonitorEnemy(ushort fieldId, DataModificationHandler handler)
	{
		int[] enemyTeam = _enemyTeam;
		foreach (int enemyCharId in enemyTeam)
		{
			if (enemyCharId >= 0)
			{
				StatisticsMonitorCombatChar(enemyCharId, fieldId, handler);
			}
		}
	}

	private void StatisticsMonitorCombatChar(int charId, ushort fieldId, DataModificationHandler handler)
	{
		DataUid dataUid = new DataUid(8, 10, (ulong)charId, fieldId);
		StatisticsMonitor(dataUid, handler);
	}

	private void StatisticsDomainData(ushort dataId, DataModificationHandler handler)
	{
		DataUid dataUid = new DataUid(8, dataId, ulong.MaxValue);
		StatisticsMonitor(dataUid, handler);
	}

	private void StatisticsMonitor(DataUid uid, DataModificationHandler handler)
	{
		if (_statisticsDataUids.Contains(uid))
		{
			AdaptableLog.Warning($"Duplicate monitor {uid}", appendWarningMessage: true);
		}
		else
		{
			_statisticsDataUids.Add(uid);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, "CombatStatisticsHandler", handler);
		}
	}

	private void StatisticsOnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		List<DataUid> statisticsDataUids = _statisticsDataUids;
		if (statisticsDataUids != null && statisticsDataUids.Count > 0)
		{
			foreach (DataUid uid in _statisticsDataUids)
			{
				GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, "CombatStatisticsHandler");
			}
		}
		_statisticsDataUids.Clear();
	}

	private void InitializeStatisticsAchievement()
	{
		Events.RegisterHandler_UsedFuyuSword(AchievementOnUsedFuyuSword);
		Events.RegisterHandler_UsedRope(AchievementOnUsedRope);
		Events.RegisterHandler_TeammateCommandSkipCd(AchievementOnTeammateCommandSkipCd);
		Events.RegisterHandler_MixedPoisonAffected(AchievementOnMixedPoisonAffected);
		Events.RegisterHandler_CombatBegin(AchievementOnCombatBegin);
		Events.RegisterHandler_AddDirectFatalDamageMark(AchievementOnAddDirectFatalDamageMark);
		Events.RegisterHandler_NormalAttackBegin(AchievementOnNormalAttackBegin);
		Events.RegisterHandler_CastSkillEnd(AchievementOnCastSkillEnd);
		Events.RegisterHandler_CombatSettlement(AchievementOnCombatSettlement);
	}

	private void AchievementOnUsedFuyuSword(DataContext context, CombatCharacter combatChar)
	{
		if (!DisableAchievement && combatChar.IsTaiwu)
		{
			AchievementManager.RequestSetStat(context, 117, 1);
		}
	}

	private void AchievementOnUsedRope(DataContext context, CombatCharacter combatChar)
	{
		if (!DisableAchievement && combatChar.IsTaiwu)
		{
			AchievementManager.RequestSetStat(context, 116, 1);
		}
	}

	private void AchievementOnTeammateCommandSkipCd(DataContext context, CombatCharacter mainChar)
	{
		if (!DisableAchievement && mainChar.IsTaiwu)
		{
			AchievementManager.RequestSetStat(context, 125, 1);
		}
	}

	private void AchievementOnMixedPoisonAffected(DataContext context, CombatCharacter combatChar)
	{
		if (!DisableAchievement && TaiwuInCombat && !combatChar.IsAlly)
		{
			AchievementManager.RequestSetStat(context, 143, 1);
		}
	}

	private void AchievementOnCombatBegin(DataContext context)
	{
		if (!DisableAchievement && TaiwuInCombat)
		{
			StatisticsMonitorTaiwu(142, AchievementBroken);
			StatisticsMonitorEnemy(142, AchievementBroken);
		}
	}

	private void AchievementNeiliAllocation(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		bool anyBulge = false;
		bool anyScatter = false;
		for (byte i = 0; i < 4; i++)
		{
			ENeiliAllocationStatusType status = combatChar.GetNeiliAllocationStatus(i);
			anyBulge = anyBulge || status == ENeiliAllocationStatusType.Bulge;
			anyScatter = anyScatter || status == ENeiliAllocationStatusType.Scatter;
		}
		if (anyBulge)
		{
			AchievementManager.RequestSetStat(context, 144, 1);
		}
		if (anyScatter)
		{
			AchievementManager.RequestSetStat(context, 145, 1);
		}
	}

	private void AchievementBroken(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (combatChar.CalcBreakBodyPartCount() > 0)
		{
			if (combatChar.IsTaiwu)
			{
				AchievementManager.RequestSetStat(context, 142, 1);
			}
			else
			{
				AchievementManager.RequestSetStat(context, 141, 1);
			}
		}
	}

	private void AchievementOnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (!DisableAchievement && attackerId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			int markCount = outerMarkCount + innerMarkCount;
			AchievementManager.RequestSetStat(context, 146, markCount);
		}
	}

	private void AchievementOnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (!DisableAchievement && attacker.IsTaiwu && pursueIndex <= 0 && attacker.GetChangeTrickAttack())
		{
			AchievementManager.RequestSetStat(context, 124, 1);
		}
	}

	private void AchievementOnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!DisableAchievement && GetCombatCharacter(isAlly: true).IsTaiwu && CombatSkillEquipType.IsAttack(skillId))
		{
			if (isAlly)
			{
				AchievementOnCastSkillEndTaiwu(context, skillId, power);
			}
			else
			{
				AchievementOnCastSkillEndEnemy(context);
			}
		}
	}

	private void AchievementOnCastSkillEndTaiwu(DataContext context, short skillId, sbyte power)
	{
		switch (power)
		{
		case 100:
			AchievementManager.RequestSetStat(context, 139, 1);
			break;
		case 0:
			AchievementManager.RequestSetStat(context, 140, 1);
			break;
		}
		CombatSkillItem config = Config.CombatSkill.Instance[skillId];
		switch (config.Type)
		{
		case 3:
			AchievementManager.RequestSetStat(context, 128, 1);
			break;
		case 4:
			AchievementManager.RequestSetStat(context, 129, 1);
			break;
		case 5:
			AchievementManager.RequestSetStat(context, 130, 1);
			break;
		case 6:
			AchievementManager.RequestSetStat(context, 131, 1);
			break;
		case 7:
			AchievementManager.RequestSetStat(context, 132, 1);
			break;
		case 8:
			AchievementManager.RequestSetStat(context, 133, 1);
			break;
		case 9:
			AchievementManager.RequestSetStat(context, 134, 1);
			break;
		case 10:
			AchievementManager.RequestSetStat(context, 135, 1);
			break;
		case 11:
			AchievementManager.RequestSetStat(context, 136, 1);
			break;
		case 12:
			AchievementManager.RequestSetStat(context, 137, 1);
			break;
		case 13:
			AchievementManager.RequestSetStat(context, 138, 1);
			break;
		}
	}

	private void AchievementOnCastSkillEndEnemy(DataContext context)
	{
		if (!InAttackRange(_enemyChar))
		{
			AchievementManager.RequestSetStat(context, 122, 1);
		}
		else if (_selfChar.GetAffectingDefendSkillId() >= 0)
		{
			AchievementManager.RequestSetStat(context, 123, 1);
		}
	}

	private void AchievementOnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (!DisableAchievement && TaiwuInCombat)
		{
			if (_combatResultData.EvaluationList.Contains(45))
			{
				AchievementManager.RequestSetStat(context, 115, 1);
			}
			else if (combatStatus == 4)
			{
				AchievementManager.RequestSetStat(context, 114, 1);
			}
			else if (CombatStatusType.IsWin(ally: true, combatStatus))
			{
				AchievementOnCombatSettlementWin(context);
			}
		}
	}

	private void AchievementOnCombatSettlementWin(DataContext context)
	{
		AchievementOnCombatSettlementWinCombatConfig(context);
		CombatCharacter enemyChar = GetMainCharacter(isAlly: false);
		if (enemyChar.CalcMarkTypeCount() >= 6)
		{
			AchievementManager.RequestSetStat(context, 113, 1);
		}
		switch (enemyChar.GetCharacter().GetOrganizationInfo().OrgTemplateId)
		{
		case 17:
			AchievementManager.RequestSetStat(context, 119, 1);
			break;
		case 18:
			AchievementManager.RequestSetStat(context, 120, 1);
			break;
		case 19:
			AchievementManager.RequestSetStat(context, 118, 1);
			break;
		default:
			if (enemyChar.IsAnimal)
			{
				AchievementManager.RequestSetStat(context, 121, 1);
			}
			break;
		}
		if (enemyChar.GetCharacter().GetConsummateLevel() > GetMainCharacter(isAlly: true).GetCharacter().GetConsummateLevel())
		{
			AchievementManager.RequestSetStat(context, 127, 1);
		}
	}

	private void AchievementOnCombatSettlementWinCombatConfig(DataContext context)
	{
		switch ((CombatType)CombatConfig.CombatType)
		{
		case CombatType.Play:
			AchievementManager.RequestSetStat(context, 109, 1);
			break;
		case CombatType.Beat:
			AchievementManager.RequestSetStat(context, 110, 1);
			break;
		case CombatType.Test:
			AchievementManager.RequestSetStat(context, 111, 1);
			break;
		case CombatType.Die:
			AchievementManager.RequestSetStat(context, 112, 1);
			break;
		}
		if (CombatConfig.IsOutBoss)
		{
			AchievementManager.RequestSetStat(context, 108, 1);
		}
	}

	private void InitializeStatisticsGuidingChapter()
	{
		Events.RegisterHandler_NormalAttackCalcHitEnd(GuidingChapterOnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackCalcCriticalEnd(GuidingChapterOnNormalAttackCalcCriticalEnd);
		Events.RegisterHandler_NormalAttackAllEnd(GuidingChapterOnNormalAttackAllEnd);
		Events.RegisterHandler_CastAttackSkillBegin(GuidingChapterOnCastAttackSkillBegin);
		Events.RegisterHandler_AddDirectDamageValue(GuidingChapterOnAddDirectDamageValue);
		Events.RegisterHandler_CombatBegin(GuidingChapterOnCombatBegin);
		Events.RegisterHandler_CombatSettlement(GuidingChapterOnCombatSettlement);
		Events.RegisterHandler_PoisonAffected(GuidingChapterOnPoisonAffected);
		Events.RegisterHandler_MixedPoisonAffected(GuidingChapterOnMixedPoisonAffected);
		Events.RegisterHandler_GetTrick(GuidingChapterOnGetTrick);
		Events.RegisterHandler_ChangeBossPhase(GuidingChapterOnChangeBossPhase);
		Events.RegisterHandler_TeammateCommandSkipCd(GuidingChapterOnTeammateCommandSkipCd);
	}

	private void GuidingChapterOnTeammateCommandSkipCd(DataContext context, CombatCharacter mainChar)
	{
		if (mainChar.IsTaiwu)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 333);
		}
	}

	private void GuidingChapterOnChangeBossPhase(DataContext context)
	{
		DomainManager.Global.InvokeGuidingTrigger(context, 334);
	}

	private void GuidingChapterOnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 292);
		}
	}

	private void GuidingChapterOnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 304);
		}
	}

	private void GuidingChapterOnMixedPoisonAffected(DataContext context, CombatCharacter combatChar)
	{
		DomainManager.Global.InvokeGuidingTrigger(context, 251);
	}

	private void GuidingChapterOnPoisonAffected(DataContext context, int charId, sbyte poisonType)
	{
		DomainManager.Global.InvokeGuidingTrigger(context, 252);
	}

	private void GuidingChapterOnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (TaiwuInCombat && CombatStatusType.IsWin(ally: true, combatStatus))
		{
			CombatType type = (CombatType)CombatConfig.CombatType;
			if (type == CombatType.Die)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 229);
			}
		}
	}

	private void GuidingChapterOnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightBack, bool isMind)
	{
		if (defender.IsTaiwu && hit)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 147);
		}
	}

	private void GuidingChapterOnNormalAttackCalcCriticalEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, bool critical)
	{
		if (attacker.IsTaiwu && critical)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 152);
		}
		else if (defender.IsTaiwu && critical)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 335);
		}
	}

	private void GuidingChapterOnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.IsTaiwu)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 279);
		}
	}

	private void GuidingChapterOnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (defender.IsTaiwu)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 330);
		}
	}

	private void GuidingChapterOnCombatBegin(DataContext context)
	{
		GuidingChapterOnCombatBeginCheckSkill(context);
		StatisticsDomainData(4, GuidingChapterOnDistanceChanged);
		if (TaiwuInCombat)
		{
			StatisticsMonitorTaiwu(24, GuidingChapterCanChangeTrickChanged);
		}
		foreach (int charId in _combatCharacterDict.Keys)
		{
			StatisticsMonitorCombatChar(charId, 50, GuidingChapterMarkChanged);
			StatisticsMonitorCombatChar(charId, 3, GuidingChapterNeiliAllocationChanged);
			StatisticsMonitorCombatChar(charId, 63, GuidingChapterDefendSkillChanged);
		}
	}

	private void GuidingChapterOnCombatBeginCheckSkill(DataContext context)
	{
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			foreach (short skillId in combatChar.GetAttackSkillList())
			{
				if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: combatChar.GetId(), skillId: skillId), out var skill))
				{
					continue;
				}
				CombatSkillItem config = Config.CombatSkill.Instance[skillId];
				sbyte direction = skill.GetDirection();
				if (1 == 0)
				{
				}
				int num = direction switch
				{
					0 => config.DirectEffectID, 
					1 => config.ReverseEffectID, 
					_ => -1, 
				};
				if (1 == 0)
				{
				}
				int effectId = num;
				if (effectId >= 0)
				{
					SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectId];
					if (effectConfig.AddUnlockValue > 0)
					{
						DomainManager.Global.InvokeGuidingTrigger(context, 323);
					}
				}
			}
		}
		if (TaiwuInCombat && _selfChar.GetAgileSkillList().Any((short x) => x >= 0))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 245);
		}
	}

	private void GuidingChapterCanChangeTrickChanged(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (combatChar.GetCanChangeTrick())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 274);
		}
	}

	private void GuidingChapterOnDistanceChanged(DataContext context, DataUid dataUid)
	{
		int require = GuidingChapterTrigger.DefValue.CombatDistanceMoreOrEqual.Int1;
		if (_currentDistance >= require)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 269);
		}
	}

	private void GuidingChapterMarkChanged(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (combatChar.IsTaiwu)
		{
			GuidingChapterMarkChangedTaiwu(context, combatChar);
		}
		DefeatMarkCollection marks = combatChar.GetDefeatMarkCollection();
		if (marks.GetTotalCount() > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 157);
		}
		if (marks.FatalDamageMarkCount > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 159);
		}
		List<bool> mindMarkList = marks.MindMarkList;
		if (mindMarkList != null && mindMarkList.Count > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 160);
		}
		if (marks.NeiliAllocationMarkCount.scatter > 0 || marks.NeiliAllocationMarkCount.bulge > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 161);
		}
		if (marks.GetTotalInjuryCount() > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 162);
		}
		if (marks.QiDisorderMarkCount > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 163);
		}
		if (marks.HealthMarkCount > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 164);
		}
		if (marks.StateMarkCount > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 165);
		}
		if (marks.WugMarkCount > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 166);
		}
		if (marks.GetTotalPoisonCount() > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 167);
		}
		if (marks.GetTotalFlawCount() > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 168);
		}
		if (marks.GetTotalAcupointCount() > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 169);
		}
	}

	private void GuidingChapterMarkChangedTaiwu(DataContext context, CombatCharacter combatChar)
	{
		if (IsCharacterHalfFallen(combatChar) && CanFlee(combatChar.IsAlly))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 151);
		}
	}

	private void GuidingChapterNeiliAllocationChanged(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (combatChar.IsTaiwu)
		{
			AchievementNeiliAllocation(context, dataUid);
		}
		for (byte i = 0; i < 4; i++)
		{
			if (combatChar.GetNeiliAllocationStatus(i) != ENeiliAllocationStatusType.None)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 173);
			}
		}
	}

	private void GuidingChapterDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		int charId = (int)dataUid.SubId0;
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (combatChar.GetAffectingDefendSkillId() >= 0)
		{
			CombatSkillItem config = Config.CombatSkill.Instance[combatChar.GetAffectingDefendSkillId()];
			if (config.BounceRateOfInnerInjury > 0 || config.BounceRateOfOuterInjury > 0)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 170);
			}
			if (config.FightBackDamage > 0)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 171);
			}
		}
	}

	private void InitializeStatisticsTaiwuLifeSummary()
	{
		Events.RegisterHandler_CombatSettlement(TaiwuLifeSummaryOnCombatSettlement);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(TaiwuLifeSummaryOnCombatStateMachineUpdateEnd);
		Events.RegisterHandler_TeammateCommandExecuted(TaiwuLifeSummaryOnTeammateCommandExecuted);
		Events.RegisterHandler_UsedItem(TaiwuLifeSummaryOnUsedItem);
		Events.RegisterHandler_UsedAvatarFragment(TaiwuLifeSummaryOnUsedAvatarFragment);
		Events.RegisterHandler_AddPoison(TaiwuLifeSummaryOnAddPoison);
	}

	private void TaiwuLifeSummaryOnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (DisableAchievement || !TaiwuInCombat)
		{
			return;
		}
		DomainManager.Taiwu.RecordLifeSummary(context, 8);
		if (CombatStatusType.IsWin(ally: true, combatStatus))
		{
			switch ((CombatType)CombatConfig.CombatType)
			{
			case CombatType.Beat:
				DomainManager.Taiwu.RecordLifeSummary(context, 9);
				break;
			case CombatType.Test:
				DomainManager.Taiwu.RecordLifeSummary(context, 11);
				break;
			case CombatType.Die:
				DomainManager.Taiwu.RecordLifeSummary(context, 10);
				break;
			}
		}
	}

	private void TaiwuLifeSummaryOnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (!Pause && (!combatChar.IsAlly || combatChar.IsTaiwu))
		{
			bool ally = combatChar.IsAlly;
			int silenceCount = combatChar.GetSilenceData().CombatSkill.Count;
			if (silenceCount > 0)
			{
				int type = (ally ? 38 : 37);
				DomainManager.Taiwu.RecordLifeSummary(context, type, silenceCount);
			}
			if (combatChar.GetMindUpheavalTime().On)
			{
				int type2 = (ally ? 28 : 18);
				DomainManager.Taiwu.RecordLifeSummary(context, type2);
			}
		}
	}

	private void TaiwuLifeSummaryOnTeammateCommandExecuted(DataContext context, int mainCharId, int _, sbyte cmdType)
	{
		if (_combatCharacterDict.TryGetValue(mainCharId, out var mainChar) && mainChar.IsTaiwu)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 36);
		}
	}

	private void TaiwuLifeSummaryOnUsedItem(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.IsTaiwu)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 34);
		}
	}

	private void TaiwuLifeSummaryOnUsedAvatarFragment(DataContext context, CombatCharacter combatChar)
	{
		TaiwuLifeSummaryOnUsedItem(context, combatChar);
		if (combatChar.IsTaiwu)
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 35);
		}
	}

	private void TaiwuLifeSummaryOnAddPoison(DataContext context, int attackerId, int defenderId, sbyte poisonType, sbyte level, int addValue, short skillId, bool canBounce)
	{
		if (addValue > 0 && _combatCharacterDict.TryGetValue(defenderId, out var defender))
		{
			if (defender.IsTaiwu)
			{
				DomainManager.Taiwu.RecordLifeSummary(context, 32, addValue);
			}
			if (attackerId >= 0 && _combatCharacterDict.TryGetValue(attackerId, out var attacker) && attacker.IsTaiwu)
			{
				DomainManager.Taiwu.RecordLifeSummary(context, 22, addValue);
			}
		}
	}

	[DomainMethod]
	public bool ExecuteTeammateCommand(DataContext context, bool isAlly, int index, int charId)
	{
		if (!IsCharInCombat(charId))
		{
			return false;
		}
		CombatCharacter teammateChar = GetElement_CombatCharacterDict(charId);
		if (teammateChar.IsAlly != isAlly)
		{
			return false;
		}
		CombatCharacter currChar = GetCombatCharacter(isAlly);
		List<sbyte> currCmds = teammateChar.GetCurrTeammateCommands();
		if (currCmds.Count <= index || !teammateChar.GetTeammateCommandCanUse()[index] || teammateChar.GetExecutingTeammateCommand() >= 0 || currChar == teammateChar)
		{
			return false;
		}
		sbyte cmdType = (sbyte)(GetMainCharacter(isAlly).GetShowTransferInjuryCommand() ? 13 : teammateChar.GetCurrTeammateCommands()[index]);
		TeammateCommandItem commandConfig = TeammateCommand.Instance[cmdType];
		ETeammateCommandImplement commandImplement = commandConfig.Implement;
		if (commandImplement == ETeammateCommandImplement.TransferInjury && index != 0)
		{
			return false;
		}
		currChar.SetNeedTeammateCommand(context, charId, index);
		return true;
	}

	[DomainMethod]
	public CombatCharacterDisplayData GetCombatCharDisplayData(int charId)
	{
		if (!TryGetElement_CombatCharacterDict(charId, out var combatChar))
		{
			return null;
		}
		CombatCharacterDisplayData data = new CombatCharacterDisplayData();
		data.DefeatMarks = combatChar.GetDefeatMarkCollection();
		data.OldInjuries = combatChar.GetOldInjuries();
		data.OldPoisons = combatChar.GetOldPoison();
		data.OldDisorderOfQi = combatChar.GetOldDisorderOfQi();
		data.Happiness = combatChar.GetHappiness();
		return data;
	}

	private int GetTeamWisdomCount(bool isAlly)
	{
		return CFormulaHelper.CalcTeamWisdomCount(isAlly ? _selfTeam : _enemyTeam);
	}

	public void GetAllCharInCombat(List<int> charIdList)
	{
		charIdList.Clear();
		charIdList.AddRange(_combatCharacterDict.Keys);
	}

	public bool IsTeamCharacter(int charId)
	{
		return _selfTeam.Exist(charId) || _enemyTeam.Exist(charId);
	}

	public bool IsMainCharacter(CombatCharacter character)
	{
		return character.GetId() == (character.IsAlly ? _selfTeam : _enemyTeam)[0];
	}

	public bool AnyTeammateChar(bool isAlly)
	{
		int[] team = (isAlly ? _selfTeam : _enemyTeam);
		for (int i = 1; i < team.Length; i++)
		{
			if (team[i] >= 0)
			{
				return true;
			}
		}
		return false;
	}

	public CombatCharacter GetMainCharacter(bool isAlly)
	{
		return GetElement_CombatCharacterDict((isAlly ? _selfTeam : _enemyTeam)[0]);
	}

	public IEnumerable<int> GetTeamCharacterIds()
	{
		int[] selfTeam = _selfTeam;
		foreach (int teamCharId in selfTeam)
		{
			if (teamCharId >= 0)
			{
				yield return teamCharId;
			}
		}
		int[] enemyTeam = _enemyTeam;
		foreach (int teamCharId2 in enemyTeam)
		{
			if (teamCharId2 >= 0)
			{
				yield return teamCharId2;
			}
		}
	}

	public int[] GetCharacterList(bool isAlly)
	{
		return isAlly ? _selfTeam : _enemyTeam;
	}

	public IEnumerable<CombatCharacter> GetCharacters(bool isAlly)
	{
		int[] team = GetCharacterList(isAlly);
		for (int i = 0; i < team.Length; i++)
		{
			if (team[i] >= 0)
			{
				yield return _combatCharacterDict[team[i]];
			}
		}
	}

	public IEnumerable<CombatCharacter> GetTeammateCharacters(int charId)
	{
		if (!IsCharInCombat(charId))
		{
			yield break;
		}
		CombatCharacter combatChar = _combatCharacterDict[charId];
		if (!IsMainCharacter(combatChar))
		{
			yield break;
		}
		int[] team = GetCharacterList(combatChar.IsAlly);
		for (int i = 1; i < team.Length; i++)
		{
			if (team[i] >= 0)
			{
				yield return _combatCharacterDict[team[i]];
			}
		}
	}

	public int GetMaxOriginNeiliAllocationSum(bool isAlly)
	{
		NeiliAllocation maxNeiliAllocation = default(NeiliAllocation);
		maxNeiliAllocation.Initialize();
		foreach (CombatCharacter character in GetCharacters(isAlly))
		{
			NeiliAllocation originNeiliAllocation = character.GetOriginNeiliAllocation();
			for (int i = 0; i < 4; i++)
			{
				maxNeiliAllocation[i] = Math.Max(maxNeiliAllocation[i], originNeiliAllocation[i]);
			}
		}
		return maxNeiliAllocation.Sum();
	}

	public bool IsCurrentCombatCharacter(CombatCharacter character)
	{
		return GetCombatCharacter(character.IsAlly) == character;
	}

	public CombatCharacter GetCombatCharacter(bool isAlly, bool tryGetCoverCharacter = false)
	{
		CombatCharacter combatChar = (isAlly ? _selfChar : _enemyChar);
		if (tryGetCoverCharacter && combatChar.TeammateBeforeMainChar >= 0)
		{
			CombatCharacter teammateChar = _combatCharacterDict[combatChar.TeammateBeforeMainChar];
			if (teammateChar.GetVisible())
			{
				return teammateChar;
			}
		}
		return combatChar;
	}

	public void SetCombatCharacter(DataContext context, bool isAlly, int charId)
	{
		CombatCharacter character = _combatCharacterDict[charId];
		character.SetVisible(visible: true, context);
		if (!IsMainCharacter(character))
		{
			TrickCollection tricks = character.GetTricks();
			tricks.ClearTricks();
			character.SetTricks(tricks, context);
		}
		if (isAlly)
		{
			if (!_selfTeam.Exist(charId))
			{
				throw new Exception("Character " + charId + " is not in self team");
			}
			SetSelfCharId(charId, context);
			_selfChar = character;
		}
		else
		{
			if (!_enemyTeam.Exist(charId))
			{
				throw new Exception("Character " + charId + " is not in enemy team");
			}
			SetEnemyCharId(charId, context);
			_enemyChar = character;
		}
		UpdateAllCommandAvailability(context, character);
	}

	public bool IsCharInCombat(int charId, bool checkCombatStatus = true)
	{
		return (!checkCombatStatus || IsInCombat()) && _combatCharacterDict.ContainsKey(charId);
	}

	public bool IsAlly(int charId1, int charId2)
	{
		return _combatCharacterDict[charId1].IsAlly == _combatCharacterDict[charId2].IsAlly;
	}

	public void UpdateAllTeammateCommandUsable(DataContext context, bool isAlly, sbyte type = -1)
	{
		ETeammateCommandImplement implement = ((type < 0) ? ETeammateCommandImplement.Invalid : TeammateCommand.Instance[type].Implement);
		UpdateAllTeammateCommandUsable(context, isAlly, implement);
	}

	public void UpdateAllTeammateCommandUsable(DataContext context, bool isAlly, ETeammateCommandImplement implement)
	{
		int[] team = (isAlly ? _selfTeam : _enemyTeam);
		for (int i = 1; i < team.Length; i++)
		{
			int charId = team[i];
			if (charId >= 0)
			{
				UpdateTeammateCommandUsable(context, GetElement_CombatCharacterDict(charId), implement);
			}
		}
	}

	public void UpdateTeammateCommandUsable(DataContext context, CombatCharacter teammateChar, sbyte type = -1)
	{
		ETeammateCommandImplement implement = ((type < 0) ? ETeammateCommandImplement.Invalid : TeammateCommand.Instance[type].Implement);
		UpdateTeammateCommandUsable(context, teammateChar, implement);
	}

	public void UpdateTeammateCommandUsable(DataContext context, CombatCharacter teammateChar, ETeammateCommandImplement implement)
	{
		CombatCharacter currChar = GetCombatCharacter(teammateChar.IsAlly);
		List<sbyte> cmdTypeList = teammateChar.GetCurrTeammateCommands();
		List<SByteList> cmdBanReasonList = teammateChar.GetTeammateCommandBanReasons();
		TeammateCommandCheckerContext checkerContext = new TeammateCommandCheckerContext
		{
			CurrChar = currChar,
			TeammateChar = teammateChar
		};
		checkerContext.InitExtraFields();
		List<sbyte> tempBanReasons = ObjectPool<List<sbyte>>.Instance.Get();
		bool changed = false;
		if (GetMainCharacter(teammateChar.IsAlly).GetShowTransferInjuryCommand())
		{
			for (int index = 0; index < cmdTypeList.Count; index++)
			{
				UpdateBanReasons(ETeammateCommandImplement.TransferInjury, index);
			}
		}
		else
		{
			List<int> indexes = ObjectPool<List<int>>.Instance.Get();
			indexes.Clear();
			for (int i = 0; i < cmdTypeList.Count; i++)
			{
				sbyte cmdType = cmdTypeList[i];
				ETeammateCommandImplement cmdImplement = ((cmdType < 0) ? ETeammateCommandImplement.Invalid : TeammateCommand.Instance[cmdType].Implement);
				bool flag = implement == ETeammateCommandImplement.Invalid || cmdImplement == implement;
				bool flag2 = flag;
				if (!flag2)
				{
					bool flag3 = (uint)(cmdImplement - 2) <= 1u;
					bool flag4 = flag3;
					bool flag5 = flag4;
					if (flag5)
					{
						bool flag6 = (uint)(implement - 2) <= 1u;
						flag5 = flag6;
					}
					flag2 = flag5;
				}
				if (flag2)
				{
					indexes.Add(i);
				}
			}
			foreach (int index2 in indexes)
			{
				sbyte cmdType2 = cmdTypeList[index2];
				ETeammateCommandImplement cmdImplement2 = ((cmdType2 < 0) ? ETeammateCommandImplement.Invalid : TeammateCommand.Instance[cmdType2].Implement);
				UpdateBanReasons(cmdImplement2, index2);
			}
			ObjectPool<List<int>>.Instance.Return(indexes);
		}
		ObjectPool<List<sbyte>>.Instance.Return(tempBanReasons);
		if (changed)
		{
			teammateChar.SetTeammateCommandBanReasons(cmdBanReasonList, context);
		}
		void UpdateBanReasons(ETeammateCommandImplement key, int index3)
		{
			tempBanReasons.Clear();
			if (TeammateCommandCheckers.TryGetValue(key, out var checker))
			{
				tempBanReasons.AddRange(from x in checker.Check(index3, checkerContext)
					select (sbyte)x);
			}
			else
			{
				tempBanReasons.Add(-1);
			}
			SByteList cmdBanReasons = cmdBanReasonList[index3];
			if (!cmdBanReasons.Items.SequenceEqual(tempBanReasons))
			{
				cmdBanReasons.Items.Clear();
				cmdBanReasons.Items.AddRange(tempBanReasons);
				changed = true;
			}
		}
	}

	public void ForceAllTeammateLeaveCombatField(DataContext context, bool isAlly)
	{
		CombatCharacter currChar = GetCombatCharacter(isAlly);
		if (!IsMainCharacter(currChar))
		{
			currChar.ChangeCharId = GetCharacterList(isAlly)[0];
		}
		if (currChar.TeammateBeforeMainChar >= 0)
		{
			GetElement_CombatCharacterDict(currChar.TeammateBeforeMainChar).ClearTeammateCommand(context, interrupt: true);
		}
		if (currChar.TeammateAfterMainChar >= 0)
		{
			GetElement_CombatCharacterDict(currChar.TeammateAfterMainChar).ClearTeammateCommand(context, interrupt: true);
		}
	}

	public void TryUpdatePreRandomizedTeammateCommands(DataContext context, int teammateId)
	{
		IReadOnlyList<sbyte> teammateCmdTypes = PreRandomizedTeammateCommandReplaceData?.GetCharTeammateCommands(teammateId);
		if (teammateCmdTypes != null)
		{
			List<sbyte> newCmdTypes = ObjectPool<List<sbyte>>.Instance.Get();
			newCmdTypes.Clear();
			newCmdTypes.AddRange(DomainManager.Extra.GetCharUsableTeammateCommands(context, teammateId));
			if (!newCmdTypes.SequenceEqual(teammateCmdTypes))
			{
				PreRandomizedTeammateCommandReplaceData.SetCharTeammateCommands(teammateId, newCmdTypes);
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ChangeTeammateCommandOnCombatBegin, teammateId, newCmdTypes);
			}
			ObjectPool<List<sbyte>>.Instance.Return(newCmdTypes);
		}
	}

	private static TeammateCommandChangeDataPart CalcTeammateBetrayData(DataContext context, short combatConfigId, IReadOnlyList<int> charIds, bool isAlly)
	{
		CombatConfigItem config = Config.CombatConfig.Instance[combatConfigId];
		TeammateCommandChangeDataPart data = new TeammateCommandChangeDataPart();
		int mainCharId = charIds[0];
		for (int i = 1; i < charIds.Count; i++)
		{
			int charId = charIds[i];
			if (charId < 0)
			{
				continue;
			}
			data.TeammateCharIds.Add(charId);
			IEnumerable<sbyte> originCmds = DomainManager.Extra.GetCharUsableTeammateCommands(context, charId);
			SByteList oldCmdsSbyteList = new SByteList(originCmds);
			List<sbyte> oldCmds = oldCmdsSbyteList.Items;
			data.OriginTeammateCommands.Add(oldCmdsSbyteList);
			SByteList newCmdsSbyteList = SByteList.Create();
			List<sbyte> newCmds = newCmdsSbyteList.Items;
			if (config.SpecialTeammateCommands.Count > i - 1 && !isAlly)
			{
				List<sbyte> list = config.SpecialTeammateCommands[i - 1];
				if (list != null && list.Count > 0)
				{
					oldCmds.Clear();
					newCmds.AddRange(config.SpecialTeammateCommands[i - 1]);
					goto IL_0125;
				}
			}
			newCmds.AddRange(oldCmds);
			short favor = DomainManager.Character.GetFavorability(charId, mainCharId);
			int count = CalcNegativeTeammateCommandCount(favor, oldCmds);
			DomainManager.Extra.FillNegativeTeammateCommands(context.Random, charId, count, newCmds);
			goto IL_0125;
			IL_0125:
			data.ReplaceTeammateCommands.Add(newCmdsSbyteList);
		}
		return data;
	}

	private static int CalcNegativeTeammateCommandCount(short favor, IReadOnlyList<sbyte> cmdTypes)
	{
		sbyte favorType = FavorabilityType.GetFavorabilityType(favor);
		if (1 == 0)
		{
		}
		int num = ((favorType <= -3) ? ((favorType > -5) ? 2 : 3) : ((favorType <= -1) ? 1 : 0));
		if (1 == 0)
		{
		}
		int count = num;
		int advanceCount = cmdTypes.Count((sbyte x) => TeammateCommand.Instance[x].Type == ETeammateCommandType.Advance);
		return Math.Min(count, 3 - advanceCount);
	}

	public IReadOnlyList<sbyte> GetPreRandomizedTeammateCommands(DataContext context, int teammateId)
	{
		IReadOnlyList<sbyte> cmdList = PreRandomizedTeammateCommandReplaceData?.GetCharTeammateCommands(teammateId);
		return cmdList ?? DomainManager.Extra.GetCharOriginalTeammateCommands(context, teammateId);
	}

	public void JoinSpecialGroup(DataContext context, int charId)
	{
		if (!_taiwuSpecialGroupCharIds.Contains(charId))
		{
			_taiwuSpecialGroupCharIds.Add(charId);
			SetTaiwuSpecialGroupCharIds(_taiwuSpecialGroupCharIds, context);
			SpecialGroupInvalidateAllCaches(context, charId);
		}
	}

	public void ExitSpecialGroup(DataContext context, int charId)
	{
		if (_taiwuSpecialGroupCharIds.Remove(charId))
		{
			SetTaiwuSpecialGroupCharIds(_taiwuSpecialGroupCharIds, context);
			SpecialGroupInvalidateAllCaches(context, charId);
		}
	}

	public void ClearSpecialGroup(DataContext context)
	{
		List<int> taiwuSpecialGroupCharIds = _taiwuSpecialGroupCharIds;
		if (taiwuSpecialGroupCharIds == null || taiwuSpecialGroupCharIds.Count <= 0)
		{
			return;
		}
		List<int> specialCharIds = ObjectPool<List<int>>.Instance.Get();
		specialCharIds.AddRange(_taiwuSpecialGroupCharIds);
		_taiwuSpecialGroupCharIds.Clear();
		SetTaiwuSpecialGroupCharIds(_taiwuSpecialGroupCharIds, context);
		foreach (int charId in specialCharIds)
		{
			SpecialGroupInvalidateAllCaches(context, charId);
		}
		ObjectPool<List<int>>.Instance.Return(specialCharIds);
	}

	private void SpecialGroupInvalidateAllCaches(DataContext context, int charId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			character.InvalidateSelfAndInfluencedCache(111, context);
		}
	}

	public void ForbidNormalAttackInTutorial(int charId)
	{
		if (_isTutorialCombat)
		{
			CombatCharacter combatChar = _combatCharacterDict[charId];
			combatChar.ForbidNormalAttackEffectCount = int.MaxValue;
		}
	}

	public void PermitNormalAttackInTutorial(int charId)
	{
		if (_isTutorialCombat)
		{
			CombatCharacter combatChar = _combatCharacterDict[charId];
			combatChar.ForbidNormalAttackEffectCount = 0;
		}
	}

	public void ClearMobilityAndForbidRecover(DataContext context, int charId)
	{
		CombatCharacter combatChar = _combatCharacterDict[charId];
		combatChar.CanRecoverMobility = false;
		ChangeMobilityValue(context, combatChar, -MoveSpecialConstants.MaxMobility);
	}

	public void SetAttackForceMiss(int charId, sbyte count)
	{
		_combatCharacterDict[charId].AttackForceMissCount = count;
	}

	public void SetAttackForceHit(int charId, sbyte count)
	{
		_combatCharacterDict[charId].AttackForceHitCount = count;
	}

	public void SetSkillAttackForceHit(int charId, bool forceHit)
	{
		_combatCharacterDict[charId].SkillForceHit = forceHit;
	}

	public void SetSkillToMaxRange(DataContext context, int charId, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		SpecialEffectBase effect = new MaxAttackRange(skillKey);
		DomainManager.SpecialEffect.Add(context, effect);
	}

	public void AddSkillPower(DataContext context, int charId, short skillId, int power)
	{
		AddSkillPowerInCombat(effectKey: new SkillEffectKey(-1, isDirect: false), context: context, skillKey: new CombatSkillKey(charId, skillId), power: power);
	}

	public void AddInjury(DataContext context, int charId, sbyte bodyPart, bool isInner, sbyte count)
	{
		CombatCharacter combatChar = _combatCharacterDict[charId];
		combatChar.AddInjury(context, bodyPart, isInner, count, updateDefeatMark: true);
		AddToCheckFallenSet(combatChar.GetId());
	}

	public void SetDefeatMarkImmunity(int charId, bool outerInjuryImmunity, bool innerInjuryImmunity, bool mindImmunity, bool flawImmunity, bool acupointImmunity)
	{
		CombatCharacter combatChar = _combatCharacterDict[charId];
		combatChar.OuterInjuryImmunity = outerInjuryImmunity;
		combatChar.InnerInjuryImmunity = innerInjuryImmunity;
		combatChar.MindImmunity = mindImmunity;
		combatChar.FlawImmunity = flawImmunity;
		combatChar.AcupointImmunity = acupointImmunity;
	}

	public void AppendEquipAttackSkill(DataContext context, int charId, short skillId)
	{
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(charId, skillId), out var _))
		{
			DomainManager.Character.LearnCombatSkill(context, charId, skillId, 0);
		}
		CombatCharacter combatChar = _combatCharacterDict[charId];
		List<short> attackSkillList = combatChar.GetAttackSkillList();
		attackSkillList.Add(skillId);
		combatChar.SetAttackSkillList(attackSkillList, context);
		AddCombatSkillData(context, charId, skillId);
		UpdateSkillCanUse(context, combatChar, skillId);
	}

	public void ForceDefeat(int charId)
	{
		_combatCharacterDict[charId].ForceDefeat = true;
		DomainManager.Combat.AddToCheckFallenSet(charId);
	}

	public void EnableEnemyAiInTutorial(DataContext context, bool enable)
	{
		if (_isTutorialCombat)
		{
			_enableEnemyAiInTutorial = enable;
		}
	}

	[DomainMethod]
	public void SelectMercyOption(DataContext context, bool isAlly, bool mercy)
	{
		if (_combatStatus == 1)
		{
			EShowMercySelect selected = ((!mercy) ? EShowMercySelect.Confirm : EShowMercySelect.Cancel);
			SetSelectedMercyOption(context, selected);
		}
	}

	[DomainMethod]
	public void Surrender(DataContext context, bool isAlly = true)
	{
		if (!CanAcceptCommand())
		{
			return;
		}
		CombatCharacter combatChar = GetMainCharacter(isAlly);
		combatChar.ForceDefeat = true;
		AddToCheckFallenSet(combatChar.GetId());
		UpdateCanSurrender(context, combatChar);
		if (!CheckEvaluation(45))
		{
			return;
		}
		AppendEvaluation(45);
		byte addInjuryCount = GlobalConfig.SurrenderInjuryCount[_combatType];
		Injuries injuries = combatChar.GetInjuries();
		Injuries oldInjuries = combatChar.GetOldInjuries();
		DefeatMarkCollection marks = combatChar.GetDefeatMarkCollection();
		List<int> showData = ObjectPool<List<int>>.Instance.Get();
		showData.Clear();
		for (int i = 0; i < addInjuryCount; i++)
		{
			bool inner = context.Random.NextBool();
			sbyte bodyPart = (sbyte)context.Random.Next(7);
			if (injuries.Get(bodyPart, inner) < 6)
			{
				injuries.Change(bodyPart, inner, 1);
				oldInjuries.Change(bodyPart, inner, 1);
				showData.Add(new DefeatMarkKey(inner ? EMarkType.Inner : EMarkType.Outer, bodyPart, 1));
			}
			else
			{
				marks.FatalDamageMarkCount = CMath.ClampFatalMarkCount(marks.FatalDamageMarkCount + 1);
				showData.Add(new DefeatMarkKey(EMarkType.Fatal));
			}
		}
		combatChar.SetInjuries(injuries, context);
		combatChar.SetOldInjuries(oldInjuries, context);
		UpdateBodyDefeatMark(context, combatChar);
		combatChar.SetDefeatMarkCollection(marks, context);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowSurrenderMark, showData);
		ObjectPool<List<int>>.Instance.Return(showData);
	}

	[DomainMethod]
	public bool IsInCombat()
	{
		return _combatStatus == 1;
	}

	public bool CombatAboutToOver()
	{
		return _showMercyOption >= 0 || _selfChar.NeedDelaySettlement || _enemyChar.NeedDelaySettlement || _selfChar.StateMachine.GetCurrentStateType() == CombatCharacterStateType.DelaySettlement || _enemyChar.StateMachine.GetCurrentStateType() == CombatCharacterStateType.DelaySettlement;
	}

	public bool IsWin(bool isAlly)
	{
		return CombatStatusType.IsWin(isAlly, _combatStatus);
	}

	private void UpdateCanSurrender(DataContext context, CombatCharacter character)
	{
		bool canSurrender = IsMainCharacter(character) && !character.ForceDefeat && !_isTutorialCombat;
		if (character.GetCanSurrender() != canSurrender)
		{
			character.SetCanSurrender(canSurrender, context);
		}
		UpdateOtherActionCanUse(context, character, 4);
	}

	public void ShowMercyOption(DataContext context, CombatCharacter winChar)
	{
		CombatCharacter failChar = GetCombatCharacter(!winChar.IsAlly);
		failChar.SetAnimationToPlayOnce("C_011_stun", context);
		winChar.NeedSelectMercyOption = true;
	}

	public void SetShowMercyOption(DataContext context, EShowMercyOption option)
	{
		SetShowMercyOption((sbyte)option, context);
	}

	public void SetSelectedMercyOption(DataContext context, EShowMercySelect selected)
	{
		SetSelectedMercyOption((sbyte)selected, context);
	}

	public void UpdateBodyDefeatMark(DataContext context, CombatCharacter character)
	{
		DefeatMarkCollection markCollection = character.GetDefeatMarkCollection();
		Injuries injuries = character.GetInjuries();
		SortedDictionary<sbyte, List<FlawOrAcupointEntry>> flawDict = character.GetFlawCollection().BodyPartDict;
		SortedDictionary<sbyte, List<FlawOrAcupointEntry>> acupointDict = character.GetAcupointCollection().BodyPartDict;
		List<byte> flawOrAcupointList = ObjectPool<List<byte>>.Instance.Get();
		bool markChanged = false;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte, sbyte) injury = injuries.Get(bodyPart);
			if (markCollection.OuterInjuryMarkList[bodyPart] != injury.Item1)
			{
				markCollection.OuterInjuryMarkList[bodyPart] = (byte)injury.Item1;
				markChanged = true;
			}
			if (markCollection.InnerInjuryMarkList[bodyPart] != injury.Item2)
			{
				markCollection.InnerInjuryMarkList[bodyPart] = (byte)injury.Item2;
				markChanged = true;
			}
			flawOrAcupointList.Clear();
			for (int i = 0; i < flawDict[bodyPart].Count; i++)
			{
				flawOrAcupointList.Add((byte)flawDict[bodyPart][i].Level);
			}
			if (!markCollection.FlawMarkList[bodyPart].SequenceEqual(flawOrAcupointList))
			{
				markCollection.FlawMarkList[bodyPart].Clear();
				markCollection.FlawMarkList[bodyPart].AddRange(flawOrAcupointList);
				markChanged = true;
			}
			flawOrAcupointList.Clear();
			for (int j = 0; j < acupointDict[bodyPart].Count; j++)
			{
				flawOrAcupointList.Add((byte)acupointDict[bodyPart][j].Level);
			}
			if (!markCollection.AcupointMarkList[bodyPart].SequenceEqual(flawOrAcupointList))
			{
				markCollection.AcupointMarkList[bodyPart].Clear();
				markCollection.AcupointMarkList[bodyPart].AddRange(flawOrAcupointList);
				markChanged = true;
			}
		}
		ObjectPool<List<byte>>.Instance.Return(flawOrAcupointList);
		if (markChanged)
		{
			character.SetDefeatMarkCollection(markCollection, context);
			AddToCheckFallenSet(character.GetId());
			if (IsMainCharacter(character))
			{
				UpdateSkillNeedBodyPartCanUse(context, character);
			}
		}
	}

	public void UpdateBodyDefeatMark(DataContext context, CombatCharacter character, sbyte bodyPart)
	{
		DefeatMarkCollection markCollection = character.GetDefeatMarkCollection();
		Injuries injuries = character.GetInjuries();
		bool markChanged = false;
		if (bodyPart != -1)
		{
			(sbyte, sbyte) injury = injuries.Get(bodyPart);
			List<FlawOrAcupointEntry> flawList = character.GetFlawCollection().BodyPartDict[bodyPart];
			List<FlawOrAcupointEntry> acupointList = character.GetAcupointCollection().BodyPartDict[bodyPart];
			List<byte> flawOrAcupointList = ObjectPool<List<byte>>.Instance.Get();
			if (markCollection.OuterInjuryMarkList[bodyPart] != injury.Item1)
			{
				markCollection.OuterInjuryMarkList[bodyPart] = (byte)injury.Item1;
				markChanged = true;
			}
			if (markCollection.InnerInjuryMarkList[bodyPart] != injury.Item2)
			{
				markCollection.InnerInjuryMarkList[bodyPart] = (byte)injury.Item2;
				markChanged = true;
			}
			flawOrAcupointList.Clear();
			for (int i = 0; i < flawList.Count; i++)
			{
				flawOrAcupointList.Add((byte)flawList[i].Level);
			}
			if (!markCollection.FlawMarkList[bodyPart].SequenceEqual(flawOrAcupointList))
			{
				markCollection.FlawMarkList[bodyPart].Clear();
				markCollection.FlawMarkList[bodyPart].AddRange(flawOrAcupointList);
				markChanged = true;
			}
			flawOrAcupointList.Clear();
			for (int j = 0; j < acupointList.Count; j++)
			{
				flawOrAcupointList.Add((byte)acupointList[j].Level);
			}
			if (!markCollection.AcupointMarkList[bodyPart].SequenceEqual(flawOrAcupointList))
			{
				markCollection.AcupointMarkList[bodyPart].Clear();
				markCollection.AcupointMarkList[bodyPart].AddRange(flawOrAcupointList);
				markChanged = true;
			}
			ObjectPool<List<byte>>.Instance.Return(flawOrAcupointList);
		}
		if (markChanged)
		{
			character.SetDefeatMarkCollection(markCollection, context);
			if (IsMainCharacter(character))
			{
				UpdateSkillNeedBodyPartCanUse(context, character);
			}
			if (bodyPart == 5 || bodyPart == 6)
			{
				ChangeMobilityValue(context, character, 0);
			}
			AddToCheckFallenSet(character.GetId());
		}
	}

	public unsafe void UpdatePoisonDefeatMark(DataContext context, CombatCharacter character)
	{
		DefeatMarkCollection markCollection = character.GetDefeatMarkCollection();
		PoisonInts poison = character.GetPoison();
		bool markChanged = false;
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			sbyte markCount = (sbyte)((!character.GetCharacter().HasPoisonImmunity(poisonType)) ? PoisonsAndLevels.CalcPoisonedLevel(poison.Items[poisonType]) : 0);
			if (markCount != markCollection.PoisonMarkList[poisonType])
			{
				markCollection.PoisonMarkList[poisonType] = (byte)markCount;
				markChanged = true;
			}
		}
		if (markChanged)
		{
			AddToCheckFallenSet(character.GetId());
			character.SetDefeatMarkCollection(markCollection, context);
		}
	}

	public unsafe int UpdatePoisonDefeatMark(DataContext context, CombatCharacter character, sbyte poisonType)
	{
		DefeatMarkCollection markCollection = character.GetDefeatMarkCollection();
		int poison = character.GetPoison().Items[poisonType];
		sbyte markCount = (sbyte)((!character.GetCharacter().HasPoisonImmunity(poisonType)) ? PoisonsAndLevels.CalcPoisonedLevel(poison) : 0);
		byte oldMarkCount = markCollection.PoisonMarkList[poisonType];
		if (markCount != oldMarkCount)
		{
			markCollection.PoisonMarkList[poisonType] = (byte)markCount;
			character.SetDefeatMarkCollection(markCollection, context);
			AddToCheckFallenSet(character.GetId());
		}
		return markCount - oldMarkCount;
	}

	public void AddToCheckFallenSet(int charId)
	{
		_needCheckFallenCharSet.Add(charId);
	}

	private bool CheckCurrCharDangerOrFallen(DataContext context, CombatCharacter character)
	{
		if (!IsInCombat() || CombatAboutToOver() || (!IsCharacterFallen(character) && !DefeatMarkReachFailCount(character)))
		{
			return false;
		}
		if (EnemyUnyieldingFallen && !character.IsAlly)
		{
			Reset(context, character);
		}
		for (int i = 0; i < CombatCharAboutToFallEventSendTimes; i++)
		{
			RaiseCombatCharAboutToFall(context, character, (ECombatCharAboutToFallType)i);
			if (!IsCharacterFallen(character) && !DefeatMarkReachFailCount(character))
			{
				_saveDyingEffectTriggerd = true;
				return false;
			}
		}
		if (!IsCharacterFallen(character))
		{
			return false;
		}
		Events.RaiseCombatCharFallen(context, character);
		CombatCharacter currChar = GetCombatCharacter(character.IsAlly);
		bool isCurrChar = currChar == character;
		if (IsMainCharacter(character))
		{
			CombatCharacter enemyChar = GetCombatCharacter(!character.IsAlly);
			currChar.ClearAllDoingOrReserveCommand(context);
			enemyChar.ClearAllDoingOrReserveCommand(context);
			if (currChar.NeedShowChangeTrick && currChar.IsAlly)
			{
				CancelChangeTrick(context, currChar.IsAlly);
			}
			if (enemyChar.NeedShowChangeTrick && enemyChar.IsAlly)
			{
				CancelChangeTrick(context, enemyChar.IsAlly);
			}
			DomainManager.Combat.ForceAllTeammateLeaveCombatField(context, isAlly: true);
			DomainManager.Combat.ForceAllTeammateLeaveCombatField(context, isAlly: false);
			currChar.ChangeCharId = (isCurrChar ? (-1) : (character.IsAlly ? _selfTeam : _enemyTeam)[0]);
			enemyChar.ChangeCharId = (IsMainCharacter(enemyChar) ? (-1) : ((!character.IsAlly) ? _selfTeam : _enemyTeam)[0]);
			if (character.ChangeCharId == -1 && enemyChar.ChangeCharId == -1)
			{
				EndCombat(context, character);
			}
			else if (character.BossConfig == null && character.AnimalConfig == null)
			{
				character.SetAnimationToPlayOnce(NeedShowMercy(character) ? "C_011_stun" : FailAni[_combatType], context);
				character.SetDieSoundToPlay(NeedShowMercy(character) ? string.Empty : FailSound[_combatType], context);
			}
		}
		else if (isCurrChar)
		{
			character.ChangeCharId = (character.IsAlly ? _selfTeam : _enemyTeam)[0];
			character.ClearAllDoingOrReserveCommand(context);
			if (character.NeedShowChangeTrick && character.IsAlly)
			{
				CancelChangeTrick(context, character.IsAlly);
			}
			if (NeedShowMercy(character))
			{
				ShowMercyOption(context, GetCombatCharacter(!character.IsAlly));
			}
			else
			{
				character.ChangeCharFailAni = "C_005";
			}
		}
		else
		{
			character.ClearTeammateCommand(context, interrupt: true);
		}
		return true;
	}

	public bool IsCharacterFallen(CombatCharacter character)
	{
		if (character.Immortal)
		{
			return false;
		}
		if (character.ForceDefeat)
		{
			return true;
		}
		DefeatMarkCollection markCollection = character.GetDefeatMarkCollection();
		return (DefeatMarkReachFailCount(character) && !character.UnyieldingFallen) || markCollection.DieMarkList.Count >= SharedConstValue.DefeatNeedDieMarkCount;
	}

	public bool DefeatMarkReachFailCount(CombatCharacter character)
	{
		return character.GetDefeatMarkCollection().GetTotalCount() >= GlobalConfig.NeedDefeatMarkCount[_combatType];
	}

	public bool IsCharacterHalfFallen(CombatCharacter character)
	{
		return character.GetDefeatMarkCollection().GetTotalCount() > GlobalConfig.NeedDefeatMarkCount[_combatType] / 2;
	}

	public (string, string, string) GetFailAnimationAndSound(DataContext context, CombatCharacter attacker, bool kill = false)
	{
		if (!kill)
		{
			CombatCharacter defender = GetCombatCharacter(!attacker.IsAlly);
			return (defender.BossConfig != null) ? (defender.BossConfig.FailAnimation, defender.BossConfig.FailParticles[(CombatConfig.Scene < 0) ? 1 : defender.GetBossPhase()], defender.BossConfig.FailSounds[(CombatConfig.Scene < 0) ? 1 : defender.GetBossPhase()]) : ((defender.AnimalConfig != null) ? (FailAni[2], defender.AnimalConfig.FailParticle, defender.AnimalConfig.FailSound) : (FailAni[_combatType], "", FailSound[_combatType]));
		}
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(GetUsingWeaponKey(attacker).Id);
		sbyte trickType = attacker.GetWeaponTricks()[attacker.GetWeaponTrickIndex()];
		TrickTypeItem trickConfig = Config.TrickType.Instance[trickType];
		int weaponAction = weapon.GetWeaponAction();
		List<string> aniRandomPool = trickConfig.ExecuteAni[weaponAction];
		List<string> particleRandomPool = trickConfig.ExecuteParticle[weaponAction];
		List<string> soundRandomPool = trickConfig.ExecuteSound[weaponAction];
		int index = context.Random.Next(aniRandomPool.Count);
		return (aniRandomPool[index], particleRandomPool[index], soundRandomPool[index]);
	}

	public void ClearBurstBodyPartFlawAndAcupoint(DataContext context, CombatCharacter combatChar, string aniName)
	{
		if (aniName.Contains("burst"))
		{
			sbyte bodyPart = (sbyte)(aniName.Contains("head") ? 2 : (aniName.Contains("arm") ? 4 : (aniName.Contains("leg") ? 5 : (-1))));
			if (bodyPart >= 0)
			{
				byte[] flawCount = combatChar.GetFlawCount();
				FlawOrAcupointCollection flawCollection = combatChar.GetFlawCollection();
				byte[] acupointCount = combatChar.GetAcupointCount();
				FlawOrAcupointCollection acupointCollection = combatChar.GetAcupointCollection();
				flawCount[bodyPart] = 0;
				flawCollection.BodyPartDict[bodyPart].Clear();
				acupointCount[bodyPart] = 0;
				acupointCollection.BodyPartDict[bodyPart].Clear();
				combatChar.SetFlawCount(flawCount, context);
				combatChar.SetFlawCollection(flawCollection, context);
				combatChar.SetAcupointCount(acupointCount, context);
				combatChar.SetAcupointCollection(acupointCollection, context);
			}
		}
	}

	public bool NeedShowMercy(CombatCharacter failChar)
	{
		if (!IsMainCharacter(failChar))
		{
			return false;
		}
		CombatCharacter winChar = GetCombatCharacter(!failChar.IsAlly);
		CombatCharacterStateType winnerState = winChar.StateMachine.GetCurrentStateType();
		if (winnerState == CombatCharacterStateType.SelectMercy)
		{
			return false;
		}
		if (IsInfectedCombat() && !failChar.IsAlly)
		{
			return true;
		}
		bool flag = DomainManager.World.GetAllowExecute() && _combatType == 2 && CombatConfig.AllowShowMercy && failChar.GetDefeatMarkCollection().GetTotalCount() > GlobalConfig.NeedDefeatMarkCount[2];
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3 = ((winnerState == CombatCharacterStateType.Idle || winnerState == CombatCharacterStateType.Attack || winnerState == CombatCharacterStateType.CastSkill) ? true : false);
			flag2 = flag3;
		}
		return flag2 && winChar.IsActorSkeleton && failChar.IsActorSkeleton && failChar.GetCharacter().GetAgeGroup() == 2 && failChar.GetId() != DomainManager.Character.GetAvoidDeathCharId() && !_isTutorialCombat && Context.Random.CheckPercentProb(50);
	}

	public void EndCombat(DataContext context, CombatCharacter failChar, bool flee = false, bool playAni = true)
	{
		ClearCombatResultLegacies();
		CombatCharacter winChar = GetCombatCharacter(!failChar.IsAlly);
		failChar.ClearAllDoingOrReserveCommand(context);
		if (!flee && NeedShowMercy(failChar))
		{
			ShowMercyOption(context, winChar);
		}
		else
		{
			if (playAni)
			{
				if (!GetIsPuppetCombat() && flee && failChar.IsActorSkeleton)
				{
					GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowFleeAnimation, failChar.GetId(), "M_004");
				}
				else if (!GetIsPuppetCombat())
				{
					(string, string, string) dieEffect = GetFailAnimationAndSound(context, winChar);
					if ((failChar.GetAnimationToPlayOnce() != dieEffect.Item1 || failChar.BossConfig != null) && (!flee || failChar.AnimalConfig == null))
					{
						failChar.SetAnimationToPlayOnce(dieEffect.Item1, context);
					}
					if (dieEffect.Item2 != "" && failChar.GetParticleToPlay() != dieEffect.Item2)
					{
						failChar.SetParticleToPlay(dieEffect.Item2, context);
					}
					if (dieEffect.Item3 != "" && failChar.GetDieSoundToPlay() != dieEffect.Item3)
					{
						failChar.SetDieSoundToPlay(dieEffect.Item3, context);
					}
					BossItem bossConfig = failChar.BossConfig;
					if (bossConfig != null)
					{
						string[] failPetParticles = bossConfig.FailPetParticles;
						if (failPetParticles != null && failPetParticles.Length > 0 && !string.IsNullOrEmpty(failChar.BossConfig.FailPetParticles[0]))
						{
							failChar.SetPetParticle(failChar.BossConfig.FailPetParticles[1], context);
						}
					}
				}
				else
				{
					failChar.SetAnimationToLoop("C_000", context);
					failChar.SetAnimationToPlayOnce(null, context);
					failChar.SetParticleToPlay(null, context);
					failChar.SetDieSoundToPlay(null, context);
					BossItem bossConfig = failChar.BossConfig;
					if (bossConfig != null)
					{
						string[] failPetParticles = bossConfig.FailPetParticles;
						if (failPetParticles != null && failPetParticles.Length > 0)
						{
							failChar.SetPetParticle(null, context);
						}
					}
				}
				winChar.PlayWinAnimation(context);
			}
			if (!flee && playAni)
			{
				SetWaitingDelaySettlement(value: true, context);
				winChar.NeedDelaySettlement = true;
				winChar.StateMachine.TranslateState();
			}
			else
			{
				CombatSettlement(context, (sbyte)((!flee) ? (failChar.IsAlly ? 2 : 3) : (failChar.IsAlly ? 4 : 5)));
			}
		}
		if ((_combatType == 1 || _combatType == 2) && winChar.IsAlly)
		{
			for (int i = 0; i < _enemyTeam.Length; i++)
			{
				int charId = _enemyTeam[i];
				if (charId >= 0 && DomainManager.Character.TryGetElement_Objects(charId, out var enemyChar) && enemyChar.GetCreatingType() == 1)
				{
					DomainManager.Character.LoseGuard(context, charId, enemyChar);
				}
			}
		}
		if ((36 > CombatConfig.TemplateId || CombatConfig.TemplateId > 44) && (54 > CombatConfig.TemplateId || CombatConfig.TemplateId > 62))
		{
			return;
		}
		if (failChar.BossConfig != null)
		{
			sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(failChar.GetCharacter().GetTemplateId());
			if (xiangshuAvatarId >= 0)
			{
				DomainManager.World.SetSwordTombStatus(context, xiangshuAvatarId, 2);
			}
		}
		else if (winChar.BossConfig != null && winChar.GetBossPhase() > 0)
		{
			sbyte xiangshuAvatarId2 = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(winChar.GetCharacter().GetTemplateId());
			if (xiangshuAvatarId2 >= 0)
			{
				DomainManager.World.SetSwordTombStatus(context, xiangshuAvatarId2, 1);
			}
		}
	}

	public void Flee(DataContext context, CombatCharacter character)
	{
		EndCombat(context, character, flee: true);
	}

	public void CombatSettlement(DataContext context, sbyte statusType)
	{
		Started = false;
		_combatResultData.CombatStatus = statusType;
		Events.RaiseCombatSettlement(context, statusType);
		SetCombatStatus(statusType, context);
		CalcEvaluationList(context);
		CalcReadInCombat(context);
		CalcQiQrtInCombat(context);
		CalcAddLegacyPoint(context);
		CalcAndAddFameAction(context);
		CalcAndAddAreaSpiritualDebt(context);
		foreach (CombatCharacter combatChar in _combatCharacterDict.Values)
		{
			combatChar.RevertAllRawCreates(context);
		}
		CalcAndAddExp(context);
		CalcAndAddResource(context);
		CalcAndAddProficiency(context);
		CalcAndAddCompatibility(context);
		CalcLootItem(context);
		GetLootCharDisplayData();
		_selfChar.OnFrameBegin();
		_selfChar.OnFrameEnd();
		_enemyChar.OnFrameBegin();
		_enemyChar.OnFrameEnd();
		DomainManager.SpecialEffect.RemoveAllEffectsInCombat(context);
		ClearSkillPowerAddInCombat(context);
		ClearSkillPowerReduceInCombat(context);
		ClearSkillPowerReplaceInCombat(context);
		EquipmentPowerChangeInCombat.Clear();
		foreach (CombatCharacter combatChar2 in _combatCharacterDict.Values)
		{
			combatChar2.OnCombatEnd(context);
		}
		CombatCharacter failChar = (IsWin(isAlly: true) ? _enemyChar : _selfChar);
		GameData.Domains.Character.Character failCharacter = DomainManager.Character.GetElement_Objects(failChar.GetId());
		bool loserAvoidDeath = DomainManager.Character.TransferAvoidDeathCharInjuries(context, failCharacter);
		if (_isPuppetCombat)
		{
			DomainManager.Character.RemoveNonIntelligentCharacter(context, _enemyChar.GetCharacter());
			SetIsPuppetCombat(value: false, context);
			SetIsPlaygroundCombat(value: false, context);
		}
		if (_carrierAnimalCombatCharId >= 0)
		{
			DomainManager.Character.RemoveNonIntelligentCharacter(context, _combatCharacterDict[_carrierAnimalCombatCharId].GetCharacter());
		}
		if (_specialShowCombatCharId >= 0)
		{
			DomainManager.Character.RemoveNonIntelligentCharacter(context, _combatCharacterDict[_specialShowCombatCharId].GetCharacter());
		}
		ClearSpecialGroup(context);
		foreach (CombatCharacter combatChar3 in _combatCharacterDict.Values)
		{
			if (combatChar3.GetCharacter().GetAllowUseFreeWeapon())
			{
				combatChar3.RemoveTempWeapons(context);
			}
		}
		List<int> combatCharIds = ObjectPool<List<int>>.Instance.Get();
		combatCharIds.Clear();
		combatCharIds.AddRange(_combatCharacterDict.Keys);
		foreach (int combatCharId in combatCharIds)
		{
			RemoveElement_CombatCharacterDict(combatCharId);
		}
		ObjectPool<List<int>>.Instance.Return(combatCharIds);
		CalcSnapshotAfterCombat(context);
		Events.RaiseCombatEnd(context);
	}

	public static int GetDefeatMarksCountOutOfCombat(GameData.Domains.Character.Character character)
	{
		int count = 0;
		count += character.GetInjuries().GetSum();
		count += character.GetPoisonMarkCount();
		count += character.GetEatingItems().CountOfWugMark();
		count += DefeatMarkCollection.CalcQiDisorderMarkCount(character.GetDisorderOfQi());
		return count + DefeatMarkCollection.GetHealthMarkCount(character.GetHealthType());
	}

	[DomainMethod]
	public static DefeatMarksCountOutOfCombatData GetDefeatMarksCountOutOfCombat(DataContext context, int charId)
	{
		DefeatMarksCountOutOfCombatData data = new DefeatMarksCountOutOfCombatData();
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return data;
		}
		int injuryCount = character.GetInjuries().GetSum();
		int poisonCount = character.GetPoisonMarkCount();
		sbyte wugCount = character.GetEatingItems().CountOfWugMark();
		sbyte qiDisorderCount = DefeatMarkCollection.CalcQiDisorderMarkCount(character.GetDisorderOfQi());
		sbyte healthCount = DefeatMarkCollection.GetHealthMarkCount(character.GetHealthType());
		if (injuryCount > 0)
		{
			data.DefeatMarksDict.Add(0, injuryCount);
		}
		if (poisonCount > 0)
		{
			data.DefeatMarksDict.Add(2, poisonCount);
		}
		if (wugCount > 0)
		{
			data.DefeatMarksDict.Add(5, wugCount);
		}
		if (qiDisorderCount > 0)
		{
			data.DefeatMarksDict.Add(6, qiDisorderCount);
		}
		if (healthCount > 0)
		{
			data.DefeatMarksDict.Add(9, healthCount);
		}
		return data;
	}

	public CombatDomain()
		: base(44)
	{
		_timeScale = 0f;
		_autoCombat = false;
		_combatFrame = 0uL;
		_combatType = 0;
		_currentDistance = 0;
		_damageCompareData = new DamageCompareData();
		_skillPowerAddInCombat = new Dictionary<CombatSkillKey, SkillPowerChangeCollection>(0);
		_skillPowerReduceInCombat = new Dictionary<CombatSkillKey, SkillPowerChangeCollection>(0);
		_skillPowerReplaceInCombat = new Dictionary<CombatSkillKey, CombatSkillKey>(0);
		_bgmIndex = 0;
		_combatCharacterDict = new Dictionary<int, CombatCharacter>(0);
		_selfTeam = new int[4];
		_selfCharId = 0;
		_selfTeamWisdomType = EWisdomType.Positive;
		_selfTeamWisdomCount = 0;
		_enemyTeam = new int[4];
		_enemyCharId = 0;
		_enemyTeamWisdomType = EWisdomType.Positive;
		_enemyTeamWisdomCount = 0;
		_combatStatus = 0;
		_showMercyOption = 0;
		_selectedMercyOption = 0;
		_carrierAnimalCombatCharId = 0;
		_specialShowCombatCharId = 0;
		_notUsed = default(SkillIndexAndHitData);
		_waitingDelaySettlement = false;
		_showUseGoldenWire = default(SpecialMiscData);
		_isPuppetCombat = false;
		_isPlaygroundCombat = false;
		_skillDataDict = new Dictionary<CombatSkillKey, CombatSkillData>(0);
		_weaponDataDict = new Dictionary<int, CombatWeaponData>(0);
		_expectRatioData = new WeaponExpectInnerRatioData();
		_taiwuSpecialGroupCharIds = new List<int>();
		_lastTargetDistance = 0;
		_changeTrickIndex = 0;
		_changeTrickBodyPart = 0;
		_changeTrickIsFlaw = false;
		_enemyUnyieldingFallen = false;
		_disableEnemyAi = false;
		_preferWeaponIndex = 0;
		_combatQuickUseItemSlotDataList = new List<CombatQuickUseItemSlotData>();
		_skillDamageData = new SkillDamageData();
		_nextAvailableChickenPointAppearCd = default(CountdownData);
		_chickenPointZones = new ChickenPointZones();
		HelperDataCombatCharacterDict = new ObjectCollectionHelperData(8, 10, CacheInfluencesCombatCharacterDict, _dataStatesCombatCharacterDict, isArchive: false);
		HelperDataSkillDataDict = new ObjectCollectionHelperData(8, 29, CacheInfluencesSkillDataDict, _dataStatesSkillDataDict, isArchive: false);
		HelperDataWeaponDataDict = new ObjectCollectionHelperData(8, 30, CacheInfluencesWeaponDataDict, _dataStatesWeaponDataDict, isArchive: false);
		OnInitializedDomainData();
	}

	public float GetTimeScale()
	{
		return _timeScale;
	}

	private void SetTimeScale(float value, DataContext context)
	{
		_timeScale = value;
		SetModifiedAndInvalidateInfluencedCache(0, DataStates, CacheInfluences, context);
	}

	public bool GetAutoCombat()
	{
		return _autoCombat;
	}

	private void SetAutoCombat(bool value, DataContext context)
	{
		_autoCombat = value;
		SetModifiedAndInvalidateInfluencedCache(1, DataStates, CacheInfluences, context);
	}

	public ulong GetCombatFrame()
	{
		return _combatFrame;
	}

	public void SetCombatFrame(ulong value, DataContext context)
	{
		_combatFrame = value;
		SetModifiedAndInvalidateInfluencedCache(2, DataStates, CacheInfluences, context);
	}

	public sbyte GetCombatType()
	{
		return _combatType;
	}

	public void SetCombatType(sbyte value, DataContext context)
	{
		_combatType = value;
		SetModifiedAndInvalidateInfluencedCache(3, DataStates, CacheInfluences, context);
	}

	public short GetCurrentDistance()
	{
		return _currentDistance;
	}

	public void SetCurrentDistance(short value, DataContext context)
	{
		_currentDistance = value;
		SetModifiedAndInvalidateInfluencedCache(4, DataStates, CacheInfluences, context);
	}

	public DamageCompareData GetDamageCompareData()
	{
		return _damageCompareData;
	}

	public void SetDamageCompareData(DamageCompareData value, DataContext context)
	{
		_damageCompareData = value;
		SetModifiedAndInvalidateInfluencedCache(5, DataStates, CacheInfluences, context);
	}

	public SkillPowerChangeCollection GetElement_SkillPowerAddInCombat(CombatSkillKey elementId)
	{
		return _skillPowerAddInCombat[elementId];
	}

	public bool TryGetElement_SkillPowerAddInCombat(CombatSkillKey elementId, out SkillPowerChangeCollection value)
	{
		return _skillPowerAddInCombat.TryGetValue(elementId, out value);
	}

	private void AddElement_SkillPowerAddInCombat(CombatSkillKey elementId, SkillPowerChangeCollection value, DataContext context)
	{
		_skillPowerAddInCombat.Add(elementId, value);
		_modificationsSkillPowerAddInCombat.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void SetElement_SkillPowerAddInCombat(CombatSkillKey elementId, SkillPowerChangeCollection value, DataContext context)
	{
		_skillPowerAddInCombat[elementId] = value;
		_modificationsSkillPowerAddInCombat.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SkillPowerAddInCombat(CombatSkillKey elementId, DataContext context)
	{
		_skillPowerAddInCombat.Remove(elementId);
		_modificationsSkillPowerAddInCombat.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	private void ClearSkillPowerAddInCombat(DataContext context)
	{
		_skillPowerAddInCombat.Clear();
		_modificationsSkillPowerAddInCombat.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(6, DataStates, CacheInfluences, context);
	}

	public SkillPowerChangeCollection GetElement_SkillPowerReduceInCombat(CombatSkillKey elementId)
	{
		return _skillPowerReduceInCombat[elementId];
	}

	public bool TryGetElement_SkillPowerReduceInCombat(CombatSkillKey elementId, out SkillPowerChangeCollection value)
	{
		return _skillPowerReduceInCombat.TryGetValue(elementId, out value);
	}

	private void AddElement_SkillPowerReduceInCombat(CombatSkillKey elementId, SkillPowerChangeCollection value, DataContext context)
	{
		_skillPowerReduceInCombat.Add(elementId, value);
		_modificationsSkillPowerReduceInCombat.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void SetElement_SkillPowerReduceInCombat(CombatSkillKey elementId, SkillPowerChangeCollection value, DataContext context)
	{
		_skillPowerReduceInCombat[elementId] = value;
		_modificationsSkillPowerReduceInCombat.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SkillPowerReduceInCombat(CombatSkillKey elementId, DataContext context)
	{
		_skillPowerReduceInCombat.Remove(elementId);
		_modificationsSkillPowerReduceInCombat.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	private void ClearSkillPowerReduceInCombat(DataContext context)
	{
		_skillPowerReduceInCombat.Clear();
		_modificationsSkillPowerReduceInCombat.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(7, DataStates, CacheInfluences, context);
	}

	public CombatSkillKey GetElement_SkillPowerReplaceInCombat(CombatSkillKey elementId)
	{
		return _skillPowerReplaceInCombat[elementId];
	}

	public bool TryGetElement_SkillPowerReplaceInCombat(CombatSkillKey elementId, out CombatSkillKey value)
	{
		return _skillPowerReplaceInCombat.TryGetValue(elementId, out value);
	}

	private void AddElement_SkillPowerReplaceInCombat(CombatSkillKey elementId, CombatSkillKey value, DataContext context)
	{
		_skillPowerReplaceInCombat.Add(elementId, value);
		_modificationsSkillPowerReplaceInCombat.RecordAdding(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void SetElement_SkillPowerReplaceInCombat(CombatSkillKey elementId, CombatSkillKey value, DataContext context)
	{
		_skillPowerReplaceInCombat[elementId] = value;
		_modificationsSkillPowerReplaceInCombat.RecordSetting(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void RemoveElement_SkillPowerReplaceInCombat(CombatSkillKey elementId, DataContext context)
	{
		_skillPowerReplaceInCombat.Remove(elementId);
		_modificationsSkillPowerReplaceInCombat.RecordRemoving(elementId);
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	private void ClearSkillPowerReplaceInCombat(DataContext context)
	{
		_skillPowerReplaceInCombat.Clear();
		_modificationsSkillPowerReplaceInCombat.RecordClearing();
		SetModifiedAndInvalidateInfluencedCache(8, DataStates, CacheInfluences, context);
	}

	public sbyte GetBgmIndex()
	{
		return _bgmIndex;
	}

	public void SetBgmIndex(sbyte value, DataContext context)
	{
		_bgmIndex = value;
		SetModifiedAndInvalidateInfluencedCache(9, DataStates, CacheInfluences, context);
	}

	public CombatCharacter GetElement_CombatCharacterDict(int objectId)
	{
		return _combatCharacterDict[objectId];
	}

	public bool TryGetElement_CombatCharacterDict(int objectId, out CombatCharacter element)
	{
		return _combatCharacterDict.TryGetValue(objectId, out element);
	}

	private void AddElement_CombatCharacterDict(int objectId, CombatCharacter instance)
	{
		instance.CollectionHelperData = HelperDataCombatCharacterDict;
		instance.DataStatesOffset = _dataStatesCombatCharacterDict.Create();
		_combatCharacterDict.Add(objectId, instance);
	}

	private void RemoveElement_CombatCharacterDict(int objectId)
	{
		if (_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			_dataStatesCombatCharacterDict.Remove(instance.DataStatesOffset);
			_combatCharacterDict.Remove(objectId);
		}
	}

	private void ClearCombatCharacterDict()
	{
		_dataStatesCombatCharacterDict.Clear();
		_combatCharacterDict.Clear();
	}

	public int GetElementField_CombatCharacterDict(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_CombatCharacterDict", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCombatCharacterDict.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetBreathValue(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetStanceValue(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocation(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetOriginNeiliAllocation(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocationRecoverProgress(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetOldDisorderOfQi(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetNeiliType(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetAvoidToShow(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrentPosition(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetDisplayPosition(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetMobilityValue(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetJumpPrepareProgress(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetJumpPreparedDistance(), dataPool);
		case 14:
			return GameData.Serializer.Serializer.Serialize(instance.GetMobilityLockEffectCount(), dataPool);
		case 15:
			return GameData.Serializer.Serializer.Serialize(instance.GetJumpChangeDistanceDuration(), dataPool);
		case 16:
			return GameData.Serializer.Serializer.Serialize(instance.GetUsingWeaponIndex(), dataPool);
		case 17:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeaponTricks(), dataPool);
		case 18:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeaponTrickIndex(), dataPool);
		case 19:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeapons(), dataPool);
		case 20:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackingTrickType(), dataPool);
		case 21:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanAttackOutRange(), dataPool);
		case 22:
			return GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickProgress(), dataPool);
		case 23:
			return GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickCount(), dataPool);
		case 24:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanChangeTrick(), dataPool);
		case 25:
			return GameData.Serializer.Serializer.Serialize(instance.GetChangingTrick(), dataPool);
		case 26:
			return GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickAttack(), dataPool);
		case 27:
			return GameData.Serializer.Serializer.Serialize(instance.GetIsFightBack(), dataPool);
		case 28:
			return GameData.Serializer.Serializer.Serialize(instance.GetTricks(), dataPool);
		case 29:
			return GameData.Serializer.Serializer.Serialize(instance.GetInjuries(), dataPool);
		case 30:
			return GameData.Serializer.Serializer.Serialize(instance.GetOldInjuries(), dataPool);
		case 31:
			return GameData.Serializer.Serializer.Serialize(instance.GetInjuryAutoHealCollection(), dataPool);
		case 32:
			return GameData.Serializer.Serializer.Serialize(instance.GetDamageStepCollection(), dataPool);
		case 33:
			return GameData.Serializer.Serializer.Serialize(instance.GetOuterDamageValue(), dataPool);
		case 34:
			return GameData.Serializer.Serializer.Serialize(instance.GetInnerDamageValue(), dataPool);
		case 35:
			return GameData.Serializer.Serializer.Serialize(instance.GetMindDamageValue(), dataPool);
		case 36:
			return GameData.Serializer.Serializer.Serialize(instance.GetFatalDamageValue(), dataPool);
		case 37:
			return GameData.Serializer.Serializer.Serialize(instance.GetOuterDamageValueToShow(), dataPool);
		case 38:
			return GameData.Serializer.Serializer.Serialize(instance.GetInnerDamageValueToShow(), dataPool);
		case 39:
			return GameData.Serializer.Serializer.Serialize(instance.GetMindDamageValueToShow(), dataPool);
		case 40:
			return GameData.Serializer.Serializer.Serialize(instance.GetFatalDamageValueToShow(), dataPool);
		case 41:
			return GameData.Serializer.Serializer.Serialize(instance.GetFlawCount(), dataPool);
		case 42:
			return GameData.Serializer.Serializer.Serialize(instance.GetFlawCollection(), dataPool);
		case 43:
			return GameData.Serializer.Serializer.Serialize(instance.GetAcupointCount(), dataPool);
		case 44:
			return GameData.Serializer.Serializer.Serialize(instance.GetAcupointCollection(), dataPool);
		case 45:
			return GameData.Serializer.Serializer.Serialize(instance.GetMindMarkTime(), dataPool);
		case 46:
			return GameData.Serializer.Serializer.Serialize(instance.GetPoison(), dataPool);
		case 47:
			return GameData.Serializer.Serializer.Serialize(instance.GetOldPoison(), dataPool);
		case 48:
			return GameData.Serializer.Serializer.Serialize(instance.GetPoisonResist(), dataPool);
		case 49:
			return GameData.Serializer.Serializer.Serialize(instance.GetNewPoisonsToShow(), dataPool);
		case 50:
			return GameData.Serializer.Serializer.Serialize(instance.GetDefeatMarkCollection(), dataPool);
		case 51:
			return GameData.Serializer.Serializer.Serialize(instance.GetNeigongList(), dataPool);
		case 52:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillList(), dataPool);
		case 53:
			return GameData.Serializer.Serializer.Serialize(instance.GetAgileSkillList(), dataPool);
		case 54:
			return GameData.Serializer.Serializer.Serialize(instance.GetDefenceSkillList(), dataPool);
		case 55:
			return GameData.Serializer.Serializer.Serialize(instance.GetAssistSkillList(), dataPool);
		case 56:
			return GameData.Serializer.Serializer.Serialize(instance.GetPreparingSkillId(), dataPool);
		case 57:
			return GameData.Serializer.Serializer.Serialize(instance.GetSkillPreparePercent(), dataPool);
		case 58:
			return GameData.Serializer.Serializer.Serialize(instance.GetPerformingSkillId(), dataPool);
		case 59:
			return GameData.Serializer.Serializer.Serialize(instance.GetAutoCastingSkill(), dataPool);
		case 60:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillAttackIndex(), dataPool);
		case 61:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillPower(), dataPool);
		case 62:
			return GameData.Serializer.Serializer.Serialize(instance.GetAffectingMoveSkillId(), dataPool);
		case 63:
			return GameData.Serializer.Serializer.Serialize(instance.GetAffectingDefendSkillId(), dataPool);
		case 64:
			return GameData.Serializer.Serializer.Serialize(instance.GetDefendSkillTimePercent(), dataPool);
		case 65:
			return GameData.Serializer.Serializer.Serialize(instance.GetWugCount(), dataPool);
		case 66:
			return GameData.Serializer.Serializer.Serialize(instance.GetHealInjuryCount(), dataPool);
		case 67:
			return GameData.Serializer.Serializer.Serialize(instance.GetHealPoisonCount(), dataPool);
		case 68:
			return GameData.Serializer.Serializer.Serialize(instance.GetOtherActionCanUse(), dataPool);
		case 69:
			return GameData.Serializer.Serializer.Serialize(instance.GetPreparingOtherAction(), dataPool);
		case 70:
			return GameData.Serializer.Serializer.Serialize(instance.GetOtherActionPreparePercent(), dataPool);
		case 71:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanSurrender(), dataPool);
		case 72:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanUseItem(), dataPool);
		case 73:
			return GameData.Serializer.Serializer.Serialize(instance.GetPreparingItem(), dataPool);
		case 74:
			return GameData.Serializer.Serializer.Serialize(instance.GetUseItemPreparePercent(), dataPool);
		case 75:
			return GameData.Serializer.Serializer.Serialize(instance.GetCombatReserveData(), dataPool);
		case 76:
			return GameData.Serializer.Serializer.Serialize(instance.GetBuffCombatStateCollection(), dataPool);
		case 77:
			return GameData.Serializer.Serializer.Serialize(instance.GetDebuffCombatStateCollection(), dataPool);
		case 78:
			return GameData.Serializer.Serializer.Serialize(instance.GetSpecialCombatStateCollection(), dataPool);
		case 79:
			return GameData.Serializer.Serializer.Serialize(instance.GetSkillEffectCollection(), dataPool);
		case 80:
			return GameData.Serializer.Serializer.Serialize(instance.GetXiangshuEffectId(), dataPool);
		case 81:
			return GameData.Serializer.Serializer.Serialize(instance.GetHazardValue(), dataPool);
		case 82:
			return GameData.Serializer.Serializer.Serialize(instance.GetShowEffectList(), dataPool);
		case 83:
			return GameData.Serializer.Serializer.Serialize(instance.GetAnimationToLoop(), dataPool);
		case 84:
			return GameData.Serializer.Serializer.Serialize(instance.GetAnimationToPlayOnce(), dataPool);
		case 85:
			return GameData.Serializer.Serializer.Serialize(instance.GetParticleToPlay(), dataPool);
		case 86:
			return GameData.Serializer.Serializer.Serialize(instance.GetParticleToLoop(), dataPool);
		case 87:
			return GameData.Serializer.Serializer.Serialize(instance.GetSkillPetAnimation(), dataPool);
		case 88:
			return GameData.Serializer.Serializer.Serialize(instance.GetPetParticle(), dataPool);
		case 89:
			return GameData.Serializer.Serializer.Serialize(instance.GetAnimationTimeScale(), dataPool);
		case 90:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackOutOfRange(), dataPool);
		case 91:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackSoundToPlay(), dataPool);
		case 92:
			return GameData.Serializer.Serializer.Serialize(instance.GetSkillSoundToPlay(), dataPool);
		case 93:
			return GameData.Serializer.Serializer.Serialize(instance.GetHitSoundToPlay(), dataPool);
		case 94:
			return GameData.Serializer.Serializer.Serialize(instance.GetArmorHitSoundToPlay(), dataPool);
		case 95:
			return GameData.Serializer.Serializer.Serialize(instance.GetWhooshSoundToPlay(), dataPool);
		case 96:
			return GameData.Serializer.Serializer.Serialize(instance.GetShockSoundToPlay(), dataPool);
		case 97:
			return GameData.Serializer.Serializer.Serialize(instance.GetStepSoundToPlay(), dataPool);
		case 98:
			return GameData.Serializer.Serializer.Serialize(instance.GetDieSoundToPlay(), dataPool);
		case 99:
			return GameData.Serializer.Serializer.Serialize(instance.GetSoundToLoop(), dataPool);
		case 100:
			return GameData.Serializer.Serializer.Serialize(instance.GetBossPhase(), dataPool);
		case 101:
			return GameData.Serializer.Serializer.Serialize(instance.GetShowTransferInjuryCommand(), dataPool);
		case 102:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrTeammateCommands(), dataPool);
		case 103:
			return GameData.Serializer.Serializer.Serialize(instance.GetExecutingTeammateCommand(), dataPool);
		case 104:
			return GameData.Serializer.Serializer.Serialize(instance.GetVisible(), dataPool);
		case 105:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandPreparePercent(), dataPool);
		case 106:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandTimePercent(), dataPool);
		case 107:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandWeaponKey(), dataPool);
		case 108:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandTrickType(), dataPool);
		case 109:
			return GameData.Serializer.Serializer.Serialize(instance.GetDefendCommandSkillId(), dataPool);
		case 110:
			return GameData.Serializer.Serializer.Serialize(instance.GetShowEffectCommandIndex(), dataPool);
		case 111:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandSkillId(), dataPool);
		case 112:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandBanReasons(), dataPool);
		case 113:
			return GameData.Serializer.Serializer.Serialize(instance.GetTargetDistance(), dataPool);
		case 114:
			return GameData.Serializer.Serializer.Serialize(instance.GetOldInjuryAutoHealCollection(), dataPool);
		case 115:
			return GameData.Serializer.Serializer.Serialize(instance.GetMixPoisonAffectedCount(), dataPool);
		case 116:
			return GameData.Serializer.Serializer.Serialize(instance.GetParticleToLoopByCombatSkill(), dataPool);
		case 117:
			return GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocationCd(), dataPool);
		case 118:
			return GameData.Serializer.Serializer.Serialize(instance.GetProportionDelta(), dataPool);
		case 119:
			return GameData.Serializer.Serializer.Serialize(instance.GetShowCommandList(), dataPool);
		case 120:
			return GameData.Serializer.Serializer.Serialize(instance.GetUnlockPrepareValue(), dataPool);
		case 121:
			return GameData.Serializer.Serializer.Serialize(instance.GetRawCreateEffects(), dataPool);
		case 122:
			return GameData.Serializer.Serializer.Serialize(instance.GetRawCreateCollection(), dataPool);
		case 123:
			return GameData.Serializer.Serializer.Serialize(instance.GetNormalAttackRecovery(), dataPool);
		case 124:
			return GameData.Serializer.Serializer.Serialize(instance.GetReserveNormalAttack(), dataPool);
		case 125:
			return GameData.Serializer.Serializer.Serialize(instance.GetGangqi(), dataPool);
		case 126:
			return GameData.Serializer.Serializer.Serialize(instance.GetGangqiMax(), dataPool);
		case 127:
			return GameData.Serializer.Serializer.Serialize(instance.GetMoveState(), dataPool);
		case 128:
			return GameData.Serializer.Serializer.Serialize(instance.GetPlayerControllingMove(), dataPool);
		case 129:
			return GameData.Serializer.Serializer.Serialize(instance.GetScarMarkTime(), dataPool);
		case 130:
			return GameData.Serializer.Serializer.Serialize(instance.GetMindRhythm(), dataPool);
		case 131:
			return GameData.Serializer.Serializer.Serialize(instance.GetMindUpheavalTime(), dataPool);
		case 132:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCd(), dataPool);
		case 133:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCdSpeed(), dataPool);
		case 134:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxTrickCount(), dataPool);
		case 135:
			return GameData.Serializer.Serializer.Serialize(instance.GetMobilityLevel(), dataPool);
		case 136:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCanUse(), dataPool);
		case 137:
			return GameData.Serializer.Serializer.Serialize(instance.GetChangeDistanceDuration(), dataPool);
		case 138:
			return GameData.Serializer.Serializer.Serialize(instance.GetAttackRange(), dataPool);
		case 139:
			return GameData.Serializer.Serializer.Serialize(instance.GetHappiness(), dataPool);
		case 140:
			return GameData.Serializer.Serializer.Serialize(instance.GetSilenceData(), dataPool);
		case 141:
			return GameData.Serializer.Serializer.Serialize(instance.GetCombatStateTotalBuffPower(), dataPool);
		case 142:
			return GameData.Serializer.Serializer.Serialize(instance.GetHeavyOrBreakInjuryData(), dataPool);
		case 143:
			return GameData.Serializer.Serializer.Serialize(instance.GetMoveCd(), dataPool);
		case 144:
			return GameData.Serializer.Serializer.Serialize(instance.GetMobilityRecoverSpeed(), dataPool);
		case 145:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanUnlockAttack(), dataPool);
		case 146:
			return GameData.Serializer.Serializer.Serialize(instance.GetValidItems(), dataPool);
		case 147:
			return GameData.Serializer.Serializer.Serialize(instance.GetValidItemAndCounts(), dataPool);
		case 148:
			return GameData.Serializer.Serializer.Serialize(instance.GetUseItemCostNoWisdom(), dataPool);
		case 149:
			return GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandBaseCdSpeed(), dataPool);
		case 150:
			return GameData.Serializer.Serializer.Serialize(instance.GetPreparingOtherActionInterruptType(), dataPool);
		case 151:
			return GameData.Serializer.Serializer.Serialize(instance.GetMixPoisonCanAffectCount(), dataPool);
		default:
			if (fieldId >= 152)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_CombatCharacterDict(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
		{
			int value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetBreathValue(value3, context);
			return;
		}
		case 2:
		{
			int value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetStanceValue(value2, context);
			return;
		}
		case 3:
		{
			NeiliAllocation value = default(NeiliAllocation);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetNeiliAllocation(value, context);
			return;
		}
		case 4:
		{
			NeiliAllocation value132 = default(NeiliAllocation);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value132);
			instance.SetOriginNeiliAllocation(value132, context);
			return;
		}
		case 5:
		{
			NeiliAllocation value131 = default(NeiliAllocation);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value131);
			instance.SetNeiliAllocationRecoverProgress(value131, context);
			return;
		}
		case 6:
		{
			short value130 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value130);
			instance.SetOldDisorderOfQi(value130, context);
			return;
		}
		case 7:
		{
			sbyte value129 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value129);
			instance.SetNeiliType(value129, context);
			return;
		}
		case 8:
		{
			ShowAvoidData value128 = default(ShowAvoidData);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value128);
			instance.SetAvoidToShow(value128, context);
			return;
		}
		case 9:
		{
			int value127 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value127);
			instance.SetCurrentPosition(value127, context);
			return;
		}
		case 10:
		{
			int value126 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value126);
			instance.SetDisplayPosition(value126, context);
			return;
		}
		case 11:
		{
			int value125 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value125);
			instance.SetMobilityValue(value125, context);
			return;
		}
		case 12:
		{
			sbyte value124 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value124);
			instance.SetJumpPrepareProgress(value124, context);
			return;
		}
		case 13:
		{
			short value123 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value123);
			instance.SetJumpPreparedDistance(value123, context);
			return;
		}
		case 14:
		{
			short value122 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value122);
			instance.SetMobilityLockEffectCount(value122, context);
			return;
		}
		case 15:
		{
			float value121 = 0f;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value121);
			instance.SetJumpChangeDistanceDuration(value121, context);
			return;
		}
		case 16:
		{
			int value120 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value120);
			instance.SetUsingWeaponIndex(value120, context);
			return;
		}
		case 17:
		{
			sbyte[] value119 = instance.GetWeaponTricks();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value119);
			instance.SetWeaponTricks(value119, context);
			return;
		}
		case 18:
		{
			byte value118 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value118);
			instance.SetWeaponTrickIndex(value118, context);
			return;
		}
		case 19:
		{
			ItemKey[] value117 = instance.GetWeapons();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value117);
			instance.SetWeapons(value117, context);
			return;
		}
		case 20:
		{
			sbyte value116 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value116);
			instance.SetAttackingTrickType(value116, context);
			return;
		}
		case 21:
		{
			bool value115 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value115);
			instance.SetCanAttackOutRange(value115, context);
			return;
		}
		case 22:
		{
			sbyte value114 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value114);
			instance.SetChangeTrickProgress(value114, context);
			return;
		}
		case 23:
		{
			short value113 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value113);
			instance.SetChangeTrickCount(value113, context);
			return;
		}
		case 24:
		{
			bool value112 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value112);
			instance.SetCanChangeTrick(value112, context);
			return;
		}
		case 25:
		{
			bool value111 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value111);
			instance.SetChangingTrick(value111, context);
			return;
		}
		case 26:
		{
			bool value110 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value110);
			instance.SetChangeTrickAttack(value110, context);
			return;
		}
		case 27:
		{
			bool value109 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value109);
			instance.SetIsFightBack(value109, context);
			return;
		}
		case 28:
		{
			TrickCollection value108 = instance.GetTricks();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value108);
			instance.SetTricks(value108, context);
			return;
		}
		case 29:
		{
			Injuries value107 = default(Injuries);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value107);
			instance.SetInjuries(value107, context);
			return;
		}
		case 30:
		{
			Injuries value106 = default(Injuries);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value106);
			instance.SetOldInjuries(value106, context);
			return;
		}
		case 31:
		{
			InjuryAutoHealCollection value105 = instance.GetInjuryAutoHealCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value105);
			instance.SetInjuryAutoHealCollection(value105, context);
			return;
		}
		case 32:
		{
			DamageStepCollection value104 = instance.GetDamageStepCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value104);
			instance.SetDamageStepCollection(value104, context);
			return;
		}
		case 33:
		{
			int[] value103 = instance.GetOuterDamageValue();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value103);
			instance.SetOuterDamageValue(value103, context);
			return;
		}
		case 34:
		{
			int[] value102 = instance.GetInnerDamageValue();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value102);
			instance.SetInnerDamageValue(value102, context);
			return;
		}
		case 35:
		{
			int value101 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value101);
			instance.SetMindDamageValue(value101, context);
			return;
		}
		case 36:
		{
			int value100 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value100);
			instance.SetFatalDamageValue(value100, context);
			return;
		}
		case 37:
		{
			IntPair[] value99 = instance.GetOuterDamageValueToShow();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value99);
			instance.SetOuterDamageValueToShow(value99, context);
			return;
		}
		case 38:
		{
			IntPair[] value98 = instance.GetInnerDamageValueToShow();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value98);
			instance.SetInnerDamageValueToShow(value98, context);
			return;
		}
		case 39:
		{
			int value97 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value97);
			instance.SetMindDamageValueToShow(value97, context);
			return;
		}
		case 40:
		{
			int value96 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value96);
			instance.SetFatalDamageValueToShow(value96, context);
			return;
		}
		case 41:
		{
			byte[] value95 = instance.GetFlawCount();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value95);
			instance.SetFlawCount(value95, context);
			return;
		}
		case 42:
		{
			FlawOrAcupointCollection value94 = instance.GetFlawCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value94);
			instance.SetFlawCollection(value94, context);
			return;
		}
		case 43:
		{
			byte[] value93 = instance.GetAcupointCount();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value93);
			instance.SetAcupointCount(value93, context);
			return;
		}
		case 44:
		{
			FlawOrAcupointCollection value92 = instance.GetAcupointCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value92);
			instance.SetAcupointCollection(value92, context);
			return;
		}
		case 45:
		{
			MindMarkList value91 = instance.GetMindMarkTime();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value91);
			instance.SetMindMarkTime(value91, context);
			return;
		}
		case 46:
		{
			PoisonInts value90 = default(PoisonInts);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value90);
			instance.SetPoison(ref value90, context);
			return;
		}
		case 47:
		{
			PoisonInts value89 = default(PoisonInts);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value89);
			instance.SetOldPoison(ref value89, context);
			return;
		}
		case 48:
		{
			PoisonInts value88 = default(PoisonInts);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value88);
			instance.SetPoisonResist(ref value88, context);
			return;
		}
		case 49:
		{
			PoisonsAndLevels value87 = default(PoisonsAndLevels);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value87);
			instance.SetNewPoisonsToShow(ref value87, context);
			return;
		}
		case 50:
		{
			DefeatMarkCollection value86 = instance.GetDefeatMarkCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value86);
			instance.SetDefeatMarkCollection(value86, context);
			return;
		}
		case 51:
		{
			List<short> value85 = instance.GetNeigongList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value85);
			instance.SetNeigongList(value85, context);
			return;
		}
		case 52:
		{
			List<short> value84 = instance.GetAttackSkillList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value84);
			instance.SetAttackSkillList(value84, context);
			return;
		}
		case 53:
		{
			List<short> value83 = instance.GetAgileSkillList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value83);
			instance.SetAgileSkillList(value83, context);
			return;
		}
		case 54:
		{
			List<short> value82 = instance.GetDefenceSkillList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value82);
			instance.SetDefenceSkillList(value82, context);
			return;
		}
		case 55:
		{
			List<short> value81 = instance.GetAssistSkillList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value81);
			instance.SetAssistSkillList(value81, context);
			return;
		}
		case 56:
		{
			short value80 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value80);
			instance.SetPreparingSkillId(value80, context);
			return;
		}
		case 57:
		{
			byte value79 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value79);
			instance.SetSkillPreparePercent(value79, context);
			return;
		}
		case 58:
		{
			short value78 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value78);
			instance.SetPerformingSkillId(value78, context);
			return;
		}
		case 59:
		{
			bool value77 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value77);
			instance.SetAutoCastingSkill(value77, context);
			return;
		}
		case 60:
		{
			byte value76 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value76);
			instance.SetAttackSkillAttackIndex(value76, context);
			return;
		}
		case 61:
		{
			byte value75 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value75);
			instance.SetAttackSkillPower(value75, context);
			return;
		}
		case 62:
		{
			short value74 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value74);
			instance.SetAffectingMoveSkillId(value74, context);
			return;
		}
		case 63:
		{
			short value73 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value73);
			instance.SetAffectingDefendSkillId(value73, context);
			return;
		}
		case 64:
		{
			byte value72 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value72);
			instance.SetDefendSkillTimePercent(value72, context);
			return;
		}
		case 65:
		{
			short value71 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value71);
			instance.SetWugCount(value71, context);
			return;
		}
		case 66:
		{
			byte value70 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value70);
			instance.SetHealInjuryCount(value70, context);
			return;
		}
		case 67:
		{
			byte value69 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value69);
			instance.SetHealPoisonCount(value69, context);
			return;
		}
		case 68:
		{
			bool[] value68 = instance.GetOtherActionCanUse();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value68);
			instance.SetOtherActionCanUse(value68, context);
			return;
		}
		case 69:
		{
			sbyte value67 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value67);
			instance.SetPreparingOtherAction(value67, context);
			return;
		}
		case 70:
		{
			byte value66 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value66);
			instance.SetOtherActionPreparePercent(value66, context);
			return;
		}
		case 71:
		{
			bool value65 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value65);
			instance.SetCanSurrender(value65, context);
			return;
		}
		case 72:
		{
			bool value64 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value64);
			instance.SetCanUseItem(value64, context);
			return;
		}
		case 73:
		{
			ItemKey value63 = default(ItemKey);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value63);
			instance.SetPreparingItem(value63, context);
			return;
		}
		case 74:
		{
			byte value62 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value62);
			instance.SetUseItemPreparePercent(value62, context);
			return;
		}
		case 75:
		{
			CombatReserveData value61 = instance.GetCombatReserveData();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value61);
			instance.SetCombatReserveData(value61, context);
			return;
		}
		case 76:
		{
			CombatStateCollection value60 = instance.GetBuffCombatStateCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value60);
			instance.SetBuffCombatStateCollection(value60, context);
			return;
		}
		case 77:
		{
			CombatStateCollection value59 = instance.GetDebuffCombatStateCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value59);
			instance.SetDebuffCombatStateCollection(value59, context);
			return;
		}
		case 78:
		{
			CombatStateCollection value58 = instance.GetSpecialCombatStateCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value58);
			instance.SetSpecialCombatStateCollection(value58, context);
			return;
		}
		case 79:
		{
			SkillEffectCollection value57 = instance.GetSkillEffectCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value57);
			instance.SetSkillEffectCollection(value57, context);
			return;
		}
		case 80:
		{
			short value56 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value56);
			instance.SetXiangshuEffectId(value56, context);
			return;
		}
		case 81:
		{
			int value55 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value55);
			instance.SetHazardValue(value55, context);
			return;
		}
		case 82:
		{
			ShowSpecialEffectCollection value54 = instance.GetShowEffectList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value54);
			instance.SetShowEffectList(value54, context);
			return;
		}
		case 83:
		{
			string value53 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value53);
			instance.SetAnimationToLoop(value53, context);
			return;
		}
		case 84:
		{
			string value52 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value52);
			instance.SetAnimationToPlayOnce(value52, context);
			return;
		}
		case 85:
		{
			string value51 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value51);
			instance.SetParticleToPlay(value51, context);
			return;
		}
		case 86:
		{
			string value50 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value50);
			instance.SetParticleToLoop(value50, context);
			return;
		}
		case 87:
		{
			string value49 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value49);
			instance.SetSkillPetAnimation(value49, context);
			return;
		}
		case 88:
		{
			string value48 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value48);
			instance.SetPetParticle(value48, context);
			return;
		}
		case 89:
		{
			float value47 = 0f;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value47);
			instance.SetAnimationTimeScale(value47, context);
			return;
		}
		case 90:
		{
			bool value46 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value46);
			instance.SetAttackOutOfRange(value46, context);
			return;
		}
		case 91:
		{
			string value45 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value45);
			instance.SetAttackSoundToPlay(value45, context);
			return;
		}
		case 92:
		{
			string value44 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value44);
			instance.SetSkillSoundToPlay(value44, context);
			return;
		}
		case 93:
		{
			string value43 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value43);
			instance.SetHitSoundToPlay(value43, context);
			return;
		}
		case 94:
		{
			string value42 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value42);
			instance.SetArmorHitSoundToPlay(value42, context);
			return;
		}
		case 95:
		{
			string value41 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value41);
			instance.SetWhooshSoundToPlay(value41, context);
			return;
		}
		case 96:
		{
			string value40 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value40);
			instance.SetShockSoundToPlay(value40, context);
			return;
		}
		case 97:
		{
			string value39 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value39);
			instance.SetStepSoundToPlay(value39, context);
			return;
		}
		case 98:
		{
			string value38 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value38);
			instance.SetDieSoundToPlay(value38, context);
			return;
		}
		case 99:
		{
			string value37 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value37);
			instance.SetSoundToLoop(value37, context);
			return;
		}
		case 100:
		{
			sbyte value36 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value36);
			instance.SetBossPhase(value36, context);
			return;
		}
		case 101:
		{
			bool value35 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value35);
			instance.SetShowTransferInjuryCommand(value35, context);
			return;
		}
		case 102:
		{
			List<sbyte> value34 = instance.GetCurrTeammateCommands();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value34);
			instance.SetCurrTeammateCommands(value34, context);
			return;
		}
		case 103:
		{
			sbyte value33 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value33);
			instance.SetExecutingTeammateCommand(value33, context);
			return;
		}
		case 104:
		{
			bool value32 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value32);
			instance.SetVisible(value32, context);
			return;
		}
		case 105:
		{
			byte value31 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value31);
			instance.SetTeammateCommandPreparePercent(value31, context);
			return;
		}
		case 106:
		{
			byte value30 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value30);
			instance.SetTeammateCommandTimePercent(value30, context);
			return;
		}
		case 107:
		{
			ItemKey value29 = default(ItemKey);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value29);
			instance.SetAttackCommandWeaponKey(value29, context);
			return;
		}
		case 108:
		{
			sbyte value28 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value28);
			instance.SetAttackCommandTrickType(value28, context);
			return;
		}
		case 109:
		{
			short value27 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value27);
			instance.SetDefendCommandSkillId(value27, context);
			return;
		}
		case 110:
		{
			sbyte value26 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value26);
			instance.SetShowEffectCommandIndex(value26, context);
			return;
		}
		case 111:
		{
			short value25 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value25);
			instance.SetAttackCommandSkillId(value25, context);
			return;
		}
		case 112:
		{
			List<SByteList> value24 = instance.GetTeammateCommandBanReasons();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value24);
			instance.SetTeammateCommandBanReasons(value24, context);
			return;
		}
		case 113:
		{
			short value23 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value23);
			instance.SetTargetDistance(value23, context);
			return;
		}
		case 114:
		{
			InjuryAutoHealCollection value22 = instance.GetOldInjuryAutoHealCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value22);
			instance.SetOldInjuryAutoHealCollection(value22, context);
			return;
		}
		case 115:
		{
			MixPoisonAffectedCountCollection value21 = instance.GetMixPoisonAffectedCount();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value21);
			instance.SetMixPoisonAffectedCount(value21, context);
			return;
		}
		case 116:
		{
			string value20 = null;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value20);
			instance.SetParticleToLoopByCombatSkill(value20, context);
			return;
		}
		case 117:
		{
			CountdownData value19 = default(CountdownData);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value19);
			instance.SetNeiliAllocationCd(value19, context);
			return;
		}
		case 118:
		{
			NeiliProportionOfFiveElements value18 = default(NeiliProportionOfFiveElements);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value18);
			instance.SetProportionDelta(value18, context);
			return;
		}
		case 119:
		{
			List<TeammateCommandDisplayData> value17 = instance.GetShowCommandList();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value17);
			instance.SetShowCommandList(value17, context);
			return;
		}
		case 120:
		{
			List<int> value16 = instance.GetUnlockPrepareValue();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value16);
			instance.SetUnlockPrepareValue(value16, context);
			return;
		}
		case 121:
		{
			List<int> value15 = instance.GetRawCreateEffects();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value15);
			instance.SetRawCreateEffects(value15, context);
			return;
		}
		case 122:
		{
			RawCreateCollection value14 = instance.GetRawCreateCollection();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value14);
			instance.SetRawCreateCollection(value14, context);
			return;
		}
		case 123:
		{
			CountdownData value13 = default(CountdownData);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value13);
			instance.SetNormalAttackRecovery(value13, context);
			return;
		}
		case 124:
		{
			bool value12 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value12);
			instance.SetReserveNormalAttack(value12, context);
			return;
		}
		case 125:
		{
			int value11 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value11);
			instance.SetGangqi(value11, context);
			return;
		}
		case 126:
		{
			int value10 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value10);
			instance.SetGangqiMax(value10, context);
			return;
		}
		case 127:
		{
			MoveState value9 = MoveState.Stay;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value9);
			instance.SetMoveState(value9, context);
			return;
		}
		case 128:
		{
			bool value8 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetPlayerControllingMove(value8, context);
			return;
		}
		case 129:
		{
			List<CountdownData> value7 = instance.GetScarMarkTime();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetScarMarkTime(value7, context);
			return;
		}
		case 130:
		{
			CountdownData value6 = default(CountdownData);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetMindRhythm(value6, context);
			return;
		}
		case 131:
		{
			CountdownData value5 = default(CountdownData);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetMindUpheavalTime(value5, context);
			return;
		}
		case 132:
		{
			List<CountdownData> value4 = instance.GetTeammateCommandCd();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetTeammateCommandCd(value4, context);
			return;
		}
		}
		if (fieldId >= 152)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 152)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_CombatCharacterDict(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 152)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCombatCharacterDict.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCombatCharacterDict.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetBreathValue(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetStanceValue(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocation(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetOriginNeiliAllocation(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocationRecoverProgress(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetOldDisorderOfQi(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetNeiliType(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetAvoidToShow(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetCurrentPosition(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetDisplayPosition(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetMobilityValue(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetJumpPrepareProgress(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetJumpPreparedDistance(), dataPool), 
			14 => GameData.Serializer.Serializer.Serialize(instance.GetMobilityLockEffectCount(), dataPool), 
			15 => GameData.Serializer.Serializer.Serialize(instance.GetJumpChangeDistanceDuration(), dataPool), 
			16 => GameData.Serializer.Serializer.Serialize(instance.GetUsingWeaponIndex(), dataPool), 
			17 => GameData.Serializer.Serializer.Serialize(instance.GetWeaponTricks(), dataPool), 
			18 => GameData.Serializer.Serializer.Serialize(instance.GetWeaponTrickIndex(), dataPool), 
			19 => GameData.Serializer.Serializer.Serialize(instance.GetWeapons(), dataPool), 
			20 => GameData.Serializer.Serializer.Serialize(instance.GetAttackingTrickType(), dataPool), 
			21 => GameData.Serializer.Serializer.Serialize(instance.GetCanAttackOutRange(), dataPool), 
			22 => GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickProgress(), dataPool), 
			23 => GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickCount(), dataPool), 
			24 => GameData.Serializer.Serializer.Serialize(instance.GetCanChangeTrick(), dataPool), 
			25 => GameData.Serializer.Serializer.Serialize(instance.GetChangingTrick(), dataPool), 
			26 => GameData.Serializer.Serializer.Serialize(instance.GetChangeTrickAttack(), dataPool), 
			27 => GameData.Serializer.Serializer.Serialize(instance.GetIsFightBack(), dataPool), 
			28 => GameData.Serializer.Serializer.Serialize(instance.GetTricks(), dataPool), 
			29 => GameData.Serializer.Serializer.Serialize(instance.GetInjuries(), dataPool), 
			30 => GameData.Serializer.Serializer.Serialize(instance.GetOldInjuries(), dataPool), 
			31 => GameData.Serializer.Serializer.Serialize(instance.GetInjuryAutoHealCollection(), dataPool), 
			32 => GameData.Serializer.Serializer.Serialize(instance.GetDamageStepCollection(), dataPool), 
			33 => GameData.Serializer.Serializer.Serialize(instance.GetOuterDamageValue(), dataPool), 
			34 => GameData.Serializer.Serializer.Serialize(instance.GetInnerDamageValue(), dataPool), 
			35 => GameData.Serializer.Serializer.Serialize(instance.GetMindDamageValue(), dataPool), 
			36 => GameData.Serializer.Serializer.Serialize(instance.GetFatalDamageValue(), dataPool), 
			37 => GameData.Serializer.Serializer.Serialize(instance.GetOuterDamageValueToShow(), dataPool), 
			38 => GameData.Serializer.Serializer.Serialize(instance.GetInnerDamageValueToShow(), dataPool), 
			39 => GameData.Serializer.Serializer.Serialize(instance.GetMindDamageValueToShow(), dataPool), 
			40 => GameData.Serializer.Serializer.Serialize(instance.GetFatalDamageValueToShow(), dataPool), 
			41 => GameData.Serializer.Serializer.Serialize(instance.GetFlawCount(), dataPool), 
			42 => GameData.Serializer.Serializer.Serialize(instance.GetFlawCollection(), dataPool), 
			43 => GameData.Serializer.Serializer.Serialize(instance.GetAcupointCount(), dataPool), 
			44 => GameData.Serializer.Serializer.Serialize(instance.GetAcupointCollection(), dataPool), 
			45 => GameData.Serializer.Serializer.Serialize(instance.GetMindMarkTime(), dataPool), 
			46 => GameData.Serializer.Serializer.Serialize(instance.GetPoison(), dataPool), 
			47 => GameData.Serializer.Serializer.Serialize(instance.GetOldPoison(), dataPool), 
			48 => GameData.Serializer.Serializer.Serialize(instance.GetPoisonResist(), dataPool), 
			49 => GameData.Serializer.Serializer.Serialize(instance.GetNewPoisonsToShow(), dataPool), 
			50 => GameData.Serializer.Serializer.Serialize(instance.GetDefeatMarkCollection(), dataPool), 
			51 => GameData.Serializer.Serializer.Serialize(instance.GetNeigongList(), dataPool), 
			52 => GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillList(), dataPool), 
			53 => GameData.Serializer.Serializer.Serialize(instance.GetAgileSkillList(), dataPool), 
			54 => GameData.Serializer.Serializer.Serialize(instance.GetDefenceSkillList(), dataPool), 
			55 => GameData.Serializer.Serializer.Serialize(instance.GetAssistSkillList(), dataPool), 
			56 => GameData.Serializer.Serializer.Serialize(instance.GetPreparingSkillId(), dataPool), 
			57 => GameData.Serializer.Serializer.Serialize(instance.GetSkillPreparePercent(), dataPool), 
			58 => GameData.Serializer.Serializer.Serialize(instance.GetPerformingSkillId(), dataPool), 
			59 => GameData.Serializer.Serializer.Serialize(instance.GetAutoCastingSkill(), dataPool), 
			60 => GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillAttackIndex(), dataPool), 
			61 => GameData.Serializer.Serializer.Serialize(instance.GetAttackSkillPower(), dataPool), 
			62 => GameData.Serializer.Serializer.Serialize(instance.GetAffectingMoveSkillId(), dataPool), 
			63 => GameData.Serializer.Serializer.Serialize(instance.GetAffectingDefendSkillId(), dataPool), 
			64 => GameData.Serializer.Serializer.Serialize(instance.GetDefendSkillTimePercent(), dataPool), 
			65 => GameData.Serializer.Serializer.Serialize(instance.GetWugCount(), dataPool), 
			66 => GameData.Serializer.Serializer.Serialize(instance.GetHealInjuryCount(), dataPool), 
			67 => GameData.Serializer.Serializer.Serialize(instance.GetHealPoisonCount(), dataPool), 
			68 => GameData.Serializer.Serializer.Serialize(instance.GetOtherActionCanUse(), dataPool), 
			69 => GameData.Serializer.Serializer.Serialize(instance.GetPreparingOtherAction(), dataPool), 
			70 => GameData.Serializer.Serializer.Serialize(instance.GetOtherActionPreparePercent(), dataPool), 
			71 => GameData.Serializer.Serializer.Serialize(instance.GetCanSurrender(), dataPool), 
			72 => GameData.Serializer.Serializer.Serialize(instance.GetCanUseItem(), dataPool), 
			73 => GameData.Serializer.Serializer.Serialize(instance.GetPreparingItem(), dataPool), 
			74 => GameData.Serializer.Serializer.Serialize(instance.GetUseItemPreparePercent(), dataPool), 
			75 => GameData.Serializer.Serializer.Serialize(instance.GetCombatReserveData(), dataPool), 
			76 => GameData.Serializer.Serializer.Serialize(instance.GetBuffCombatStateCollection(), dataPool), 
			77 => GameData.Serializer.Serializer.Serialize(instance.GetDebuffCombatStateCollection(), dataPool), 
			78 => GameData.Serializer.Serializer.Serialize(instance.GetSpecialCombatStateCollection(), dataPool), 
			79 => GameData.Serializer.Serializer.Serialize(instance.GetSkillEffectCollection(), dataPool), 
			80 => GameData.Serializer.Serializer.Serialize(instance.GetXiangshuEffectId(), dataPool), 
			81 => GameData.Serializer.Serializer.Serialize(instance.GetHazardValue(), dataPool), 
			82 => GameData.Serializer.Serializer.Serialize(instance.GetShowEffectList(), dataPool), 
			83 => GameData.Serializer.Serializer.Serialize(instance.GetAnimationToLoop(), dataPool), 
			84 => GameData.Serializer.Serializer.Serialize(instance.GetAnimationToPlayOnce(), dataPool), 
			85 => GameData.Serializer.Serializer.Serialize(instance.GetParticleToPlay(), dataPool), 
			86 => GameData.Serializer.Serializer.Serialize(instance.GetParticleToLoop(), dataPool), 
			87 => GameData.Serializer.Serializer.Serialize(instance.GetSkillPetAnimation(), dataPool), 
			88 => GameData.Serializer.Serializer.Serialize(instance.GetPetParticle(), dataPool), 
			89 => GameData.Serializer.Serializer.Serialize(instance.GetAnimationTimeScale(), dataPool), 
			90 => GameData.Serializer.Serializer.Serialize(instance.GetAttackOutOfRange(), dataPool), 
			91 => GameData.Serializer.Serializer.Serialize(instance.GetAttackSoundToPlay(), dataPool), 
			92 => GameData.Serializer.Serializer.Serialize(instance.GetSkillSoundToPlay(), dataPool), 
			93 => GameData.Serializer.Serializer.Serialize(instance.GetHitSoundToPlay(), dataPool), 
			94 => GameData.Serializer.Serializer.Serialize(instance.GetArmorHitSoundToPlay(), dataPool), 
			95 => GameData.Serializer.Serializer.Serialize(instance.GetWhooshSoundToPlay(), dataPool), 
			96 => GameData.Serializer.Serializer.Serialize(instance.GetShockSoundToPlay(), dataPool), 
			97 => GameData.Serializer.Serializer.Serialize(instance.GetStepSoundToPlay(), dataPool), 
			98 => GameData.Serializer.Serializer.Serialize(instance.GetDieSoundToPlay(), dataPool), 
			99 => GameData.Serializer.Serializer.Serialize(instance.GetSoundToLoop(), dataPool), 
			100 => GameData.Serializer.Serializer.Serialize(instance.GetBossPhase(), dataPool), 
			101 => GameData.Serializer.Serializer.Serialize(instance.GetShowTransferInjuryCommand(), dataPool), 
			102 => GameData.Serializer.Serializer.Serialize(instance.GetCurrTeammateCommands(), dataPool), 
			103 => GameData.Serializer.Serializer.Serialize(instance.GetExecutingTeammateCommand(), dataPool), 
			104 => GameData.Serializer.Serializer.Serialize(instance.GetVisible(), dataPool), 
			105 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandPreparePercent(), dataPool), 
			106 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandTimePercent(), dataPool), 
			107 => GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandWeaponKey(), dataPool), 
			108 => GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandTrickType(), dataPool), 
			109 => GameData.Serializer.Serializer.Serialize(instance.GetDefendCommandSkillId(), dataPool), 
			110 => GameData.Serializer.Serializer.Serialize(instance.GetShowEffectCommandIndex(), dataPool), 
			111 => GameData.Serializer.Serializer.Serialize(instance.GetAttackCommandSkillId(), dataPool), 
			112 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandBanReasons(), dataPool), 
			113 => GameData.Serializer.Serializer.Serialize(instance.GetTargetDistance(), dataPool), 
			114 => GameData.Serializer.Serializer.Serialize(instance.GetOldInjuryAutoHealCollection(), dataPool), 
			115 => GameData.Serializer.Serializer.Serialize(instance.GetMixPoisonAffectedCount(), dataPool), 
			116 => GameData.Serializer.Serializer.Serialize(instance.GetParticleToLoopByCombatSkill(), dataPool), 
			117 => GameData.Serializer.Serializer.Serialize(instance.GetNeiliAllocationCd(), dataPool), 
			118 => GameData.Serializer.Serializer.Serialize(instance.GetProportionDelta(), dataPool), 
			119 => GameData.Serializer.Serializer.Serialize(instance.GetShowCommandList(), dataPool), 
			120 => GameData.Serializer.Serializer.Serialize(instance.GetUnlockPrepareValue(), dataPool), 
			121 => GameData.Serializer.Serializer.Serialize(instance.GetRawCreateEffects(), dataPool), 
			122 => GameData.Serializer.Serializer.Serialize(instance.GetRawCreateCollection(), dataPool), 
			123 => GameData.Serializer.Serializer.Serialize(instance.GetNormalAttackRecovery(), dataPool), 
			124 => GameData.Serializer.Serializer.Serialize(instance.GetReserveNormalAttack(), dataPool), 
			125 => GameData.Serializer.Serializer.Serialize(instance.GetGangqi(), dataPool), 
			126 => GameData.Serializer.Serializer.Serialize(instance.GetGangqiMax(), dataPool), 
			127 => GameData.Serializer.Serializer.Serialize(instance.GetMoveState(), dataPool), 
			128 => GameData.Serializer.Serializer.Serialize(instance.GetPlayerControllingMove(), dataPool), 
			129 => GameData.Serializer.Serializer.Serialize(instance.GetScarMarkTime(), dataPool), 
			130 => GameData.Serializer.Serializer.Serialize(instance.GetMindRhythm(), dataPool), 
			131 => GameData.Serializer.Serializer.Serialize(instance.GetMindUpheavalTime(), dataPool), 
			132 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCd(), dataPool), 
			133 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCdSpeed(), dataPool), 
			134 => GameData.Serializer.Serializer.Serialize(instance.GetMaxTrickCount(), dataPool), 
			135 => GameData.Serializer.Serializer.Serialize(instance.GetMobilityLevel(), dataPool), 
			136 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandCanUse(), dataPool), 
			137 => GameData.Serializer.Serializer.Serialize(instance.GetChangeDistanceDuration(), dataPool), 
			138 => GameData.Serializer.Serializer.Serialize(instance.GetAttackRange(), dataPool), 
			139 => GameData.Serializer.Serializer.Serialize(instance.GetHappiness(), dataPool), 
			140 => GameData.Serializer.Serializer.Serialize(instance.GetSilenceData(), dataPool), 
			141 => GameData.Serializer.Serializer.Serialize(instance.GetCombatStateTotalBuffPower(), dataPool), 
			142 => GameData.Serializer.Serializer.Serialize(instance.GetHeavyOrBreakInjuryData(), dataPool), 
			143 => GameData.Serializer.Serializer.Serialize(instance.GetMoveCd(), dataPool), 
			144 => GameData.Serializer.Serializer.Serialize(instance.GetMobilityRecoverSpeed(), dataPool), 
			145 => GameData.Serializer.Serializer.Serialize(instance.GetCanUnlockAttack(), dataPool), 
			146 => GameData.Serializer.Serializer.Serialize(instance.GetValidItems(), dataPool), 
			147 => GameData.Serializer.Serializer.Serialize(instance.GetValidItemAndCounts(), dataPool), 
			148 => GameData.Serializer.Serializer.Serialize(instance.GetUseItemCostNoWisdom(), dataPool), 
			149 => GameData.Serializer.Serializer.Serialize(instance.GetTeammateCommandBaseCdSpeed(), dataPool), 
			150 => GameData.Serializer.Serializer.Serialize(instance.GetPreparingOtherActionInterruptType(), dataPool), 
			151 => GameData.Serializer.Serializer.Serialize(instance.GetMixPoisonCanAffectCount(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_CombatCharacterDict(int objectId, ushort fieldId)
	{
		if (_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 152)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCombatCharacterDict.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCombatCharacterDict.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_CombatCharacterDict(int objectId, ushort fieldId)
	{
		if (!_combatCharacterDict.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 152)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCombatCharacterDict.IsModified(instance.DataStatesOffset, fieldId);
	}

	public int[] GetSelfTeam()
	{
		return _selfTeam;
	}

	public void SetSelfTeam(int[] value, DataContext context)
	{
		_selfTeam = value;
		SetModifiedAndInvalidateInfluencedCache(11, DataStates, CacheInfluences, context);
	}

	public int GetSelfCharId()
	{
		return _selfCharId;
	}

	public void SetSelfCharId(int value, DataContext context)
	{
		_selfCharId = value;
		SetModifiedAndInvalidateInfluencedCache(12, DataStates, CacheInfluences, context);
	}

	public EWisdomType GetSelfTeamWisdomType()
	{
		return _selfTeamWisdomType;
	}

	public void SetSelfTeamWisdomType(EWisdomType value, DataContext context)
	{
		_selfTeamWisdomType = value;
		SetModifiedAndInvalidateInfluencedCache(13, DataStates, CacheInfluences, context);
	}

	public short GetSelfTeamWisdomCount()
	{
		return _selfTeamWisdomCount;
	}

	public void SetSelfTeamWisdomCount(short value, DataContext context)
	{
		_selfTeamWisdomCount = value;
		SetModifiedAndInvalidateInfluencedCache(14, DataStates, CacheInfluences, context);
	}

	public int[] GetEnemyTeam()
	{
		return _enemyTeam;
	}

	public void SetEnemyTeam(int[] value, DataContext context)
	{
		_enemyTeam = value;
		SetModifiedAndInvalidateInfluencedCache(15, DataStates, CacheInfluences, context);
	}

	public int GetEnemyCharId()
	{
		return _enemyCharId;
	}

	public void SetEnemyCharId(int value, DataContext context)
	{
		_enemyCharId = value;
		SetModifiedAndInvalidateInfluencedCache(16, DataStates, CacheInfluences, context);
	}

	public EWisdomType GetEnemyTeamWisdomType()
	{
		return _enemyTeamWisdomType;
	}

	public void SetEnemyTeamWisdomType(EWisdomType value, DataContext context)
	{
		_enemyTeamWisdomType = value;
		SetModifiedAndInvalidateInfluencedCache(17, DataStates, CacheInfluences, context);
	}

	public short GetEnemyTeamWisdomCount()
	{
		return _enemyTeamWisdomCount;
	}

	public void SetEnemyTeamWisdomCount(short value, DataContext context)
	{
		_enemyTeamWisdomCount = value;
		SetModifiedAndInvalidateInfluencedCache(18, DataStates, CacheInfluences, context);
	}

	public sbyte GetCombatStatus()
	{
		return _combatStatus;
	}

	public void SetCombatStatus(sbyte value, DataContext context)
	{
		_combatStatus = value;
		SetModifiedAndInvalidateInfluencedCache(19, DataStates, CacheInfluences, context);
	}

	public sbyte GetShowMercyOption()
	{
		return _showMercyOption;
	}

	public void SetShowMercyOption(sbyte value, DataContext context)
	{
		_showMercyOption = value;
		SetModifiedAndInvalidateInfluencedCache(20, DataStates, CacheInfluences, context);
	}

	public sbyte GetSelectedMercyOption()
	{
		return _selectedMercyOption;
	}

	public void SetSelectedMercyOption(sbyte value, DataContext context)
	{
		_selectedMercyOption = value;
		SetModifiedAndInvalidateInfluencedCache(21, DataStates, CacheInfluences, context);
	}

	public int GetCarrierAnimalCombatCharId()
	{
		return _carrierAnimalCombatCharId;
	}

	public void SetCarrierAnimalCombatCharId(int value, DataContext context)
	{
		_carrierAnimalCombatCharId = value;
		SetModifiedAndInvalidateInfluencedCache(22, DataStates, CacheInfluences, context);
	}

	public int GetSpecialShowCombatCharId()
	{
		return _specialShowCombatCharId;
	}

	public void SetSpecialShowCombatCharId(int value, DataContext context)
	{
		_specialShowCombatCharId = value;
		SetModifiedAndInvalidateInfluencedCache(23, DataStates, CacheInfluences, context);
	}

	[Obsolete("DomainData _notUsed is no longer in use.")]
	public SkillIndexAndHitData GetNotUsed()
	{
		return _notUsed;
	}

	[Obsolete("DomainData _notUsed is no longer in use.")]
	public void SetNotUsed(SkillIndexAndHitData value, DataContext context)
	{
		_notUsed = value;
		SetModifiedAndInvalidateInfluencedCache(24, DataStates, CacheInfluences, context);
	}

	public bool GetWaitingDelaySettlement()
	{
		return _waitingDelaySettlement;
	}

	public void SetWaitingDelaySettlement(bool value, DataContext context)
	{
		_waitingDelaySettlement = value;
		SetModifiedAndInvalidateInfluencedCache(25, DataStates, CacheInfluences, context);
	}

	public SpecialMiscData GetShowUseGoldenWire()
	{
		return _showUseGoldenWire;
	}

	public void SetShowUseGoldenWire(SpecialMiscData value, DataContext context)
	{
		_showUseGoldenWire = value;
		SetModifiedAndInvalidateInfluencedCache(26, DataStates, CacheInfluences, context);
	}

	public bool GetIsPuppetCombat()
	{
		return _isPuppetCombat;
	}

	public void SetIsPuppetCombat(bool value, DataContext context)
	{
		_isPuppetCombat = value;
		SetModifiedAndInvalidateInfluencedCache(27, DataStates, CacheInfluences, context);
	}

	public bool GetIsPlaygroundCombat()
	{
		return _isPlaygroundCombat;
	}

	public void SetIsPlaygroundCombat(bool value, DataContext context)
	{
		_isPlaygroundCombat = value;
		SetModifiedAndInvalidateInfluencedCache(28, DataStates, CacheInfluences, context);
	}

	public CombatSkillData GetElement_SkillDataDict(CombatSkillKey objectId)
	{
		return _skillDataDict[objectId];
	}

	public bool TryGetElement_SkillDataDict(CombatSkillKey objectId, out CombatSkillData element)
	{
		return _skillDataDict.TryGetValue(objectId, out element);
	}

	private void AddElement_SkillDataDict(CombatSkillKey objectId, CombatSkillData instance)
	{
		instance.CollectionHelperData = HelperDataSkillDataDict;
		instance.DataStatesOffset = _dataStatesSkillDataDict.Create();
		_skillDataDict.Add(objectId, instance);
	}

	private void RemoveElement_SkillDataDict(CombatSkillKey objectId)
	{
		if (_skillDataDict.TryGetValue(objectId, out var instance))
		{
			_dataStatesSkillDataDict.Remove(instance.DataStatesOffset);
			_skillDataDict.Remove(objectId);
		}
	}

	private void ClearSkillDataDict()
	{
		_dataStatesSkillDataDict.Clear();
		_skillDataDict.Clear();
	}

	public int GetElementField_SkillDataDict(CombatSkillKey objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_skillDataDict.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_SkillDataDict", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesSkillDataDict.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanUse(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetLeftCdFrame(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetTotalCdFrame(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetConstAffecting(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetShowAffectTips(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetSilencing(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetBanReason(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetEffectData(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanAffect(), dataPool);
		default:
			if (fieldId >= 10)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_SkillDataDict(CombatSkillKey objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_skillDataDict.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
		{
			CombatSkillKey value4 = default(CombatSkillKey);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetId(value4, context);
			return;
		}
		case 1:
		{
			bool value3 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetCanUse(value3, context);
			return;
		}
		case 2:
		{
			short value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetLeftCdFrame(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetTotalCdFrame(value, context);
			return;
		}
		case 4:
		{
			bool value7 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetConstAffecting(value7, context);
			return;
		}
		case 5:
		{
			bool value6 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetShowAffectTips(value6, context);
			return;
		}
		case 6:
		{
			bool value5 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetSilencing(value5, context);
			return;
		}
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_SkillDataDict(CombatSkillKey objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_skillDataDict.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesSkillDataDict.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesSkillDataDict.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetCanUse(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetLeftCdFrame(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetTotalCdFrame(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetConstAffecting(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetShowAffectTips(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetSilencing(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetBanReason(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetEffectData(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetCanAffect(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_SkillDataDict(CombatSkillKey objectId, ushort fieldId)
	{
		if (_skillDataDict.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 10)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesSkillDataDict.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesSkillDataDict.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_SkillDataDict(CombatSkillKey objectId, ushort fieldId)
	{
		if (!_skillDataDict.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesSkillDataDict.IsModified(instance.DataStatesOffset, fieldId);
	}

	public CombatWeaponData GetElement_WeaponDataDict(int objectId)
	{
		return _weaponDataDict[objectId];
	}

	public bool TryGetElement_WeaponDataDict(int objectId, out CombatWeaponData element)
	{
		return _weaponDataDict.TryGetValue(objectId, out element);
	}

	private void AddElement_WeaponDataDict(int objectId, CombatWeaponData instance)
	{
		instance.CollectionHelperData = HelperDataWeaponDataDict;
		instance.DataStatesOffset = _dataStatesWeaponDataDict.Create();
		_weaponDataDict.Add(objectId, instance);
	}

	private void RemoveElement_WeaponDataDict(int objectId)
	{
		if (_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			_dataStatesWeaponDataDict.Remove(instance.DataStatesOffset);
			_weaponDataDict.Remove(objectId);
		}
	}

	private void ClearWeaponDataDict()
	{
		_dataStatesWeaponDataDict.Clear();
		_weaponDataDict.Clear();
	}

	public int GetElementField_WeaponDataDict(int objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_WeaponDataDict", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesWeaponDataDict.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetWeaponTricks(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetCanChangeTo(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetDurability(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetCdFrame(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetAutoAttackEffect(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetPestleEffect(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetFixedCdLeftFrame(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetFixedCdTotalFrame(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetInnerRatio(), dataPool);
		default:
			if (fieldId >= 10)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_WeaponDataDict(int objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
		{
			int value4 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetId(value4, context);
			return;
		}
		case 1:
		{
			sbyte[] value3 = instance.GetWeaponTricks();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetWeaponTricks(value3, context);
			return;
		}
		case 2:
		{
			bool value2 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetCanChangeTo(value2, context);
			return;
		}
		case 3:
		{
			short value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetDurability(value, context);
			return;
		}
		case 4:
		{
			short value9 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value9);
			instance.SetCdFrame(value9, context);
			return;
		}
		case 5:
		{
			SkillEffectKey value8 = default(SkillEffectKey);
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetAutoAttackEffect(value8, context);
			return;
		}
		case 6:
		{
			List<SkillEffectKey> value7 = instance.GetPestleEffect();
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetPestleEffect(value7, context);
			return;
		}
		case 7:
		{
			short value6 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetFixedCdLeftFrame(value6, context);
			return;
		}
		case 8:
		{
			short value5 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetFixedCdTotalFrame(value5, context);
			return;
		}
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_WeaponDataDict(int objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesWeaponDataDict.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesWeaponDataDict.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetWeaponTricks(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetCanChangeTo(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetDurability(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetCdFrame(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetAutoAttackEffect(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetPestleEffect(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetFixedCdLeftFrame(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetFixedCdTotalFrame(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetInnerRatio(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_WeaponDataDict(int objectId, ushort fieldId)
	{
		if (_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 10)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesWeaponDataDict.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesWeaponDataDict.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_WeaponDataDict(int objectId, ushort fieldId)
	{
		if (!_weaponDataDict.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 10)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesWeaponDataDict.IsModified(instance.DataStatesOffset, fieldId);
	}

	[Obsolete("DomainData _expectRatioData is no longer in use.")]
	public WeaponExpectInnerRatioData GetExpectRatioData()
	{
		return _expectRatioData;
	}

	[Obsolete("DomainData _expectRatioData is no longer in use.")]
	public void SetExpectRatioData(WeaponExpectInnerRatioData value, DataContext context)
	{
		_expectRatioData = value;
		SetModifiedAndInvalidateInfluencedCache(31, DataStates, CacheInfluences, context);
	}

	public List<int> GetTaiwuSpecialGroupCharIds()
	{
		return _taiwuSpecialGroupCharIds;
	}

	public void SetTaiwuSpecialGroupCharIds(List<int> value, DataContext context)
	{
		_taiwuSpecialGroupCharIds = value;
		SetModifiedAndInvalidateInfluencedCache(32, DataStates, CacheInfluences, context);
	}

	public short GetLastTargetDistance()
	{
		return _lastTargetDistance;
	}

	public void SetLastTargetDistance(short value, DataContext context)
	{
		_lastTargetDistance = value;
		SetModifiedAndInvalidateInfluencedCache(33, DataStates, CacheInfluences, context);
	}

	public sbyte GetChangeTrickIndex()
	{
		return _changeTrickIndex;
	}

	public void SetChangeTrickIndex(sbyte value, DataContext context)
	{
		_changeTrickIndex = value;
		SetModifiedAndInvalidateInfluencedCache(34, DataStates, CacheInfluences, context);
	}

	public sbyte GetChangeTrickBodyPart()
	{
		return _changeTrickBodyPart;
	}

	public void SetChangeTrickBodyPart(sbyte value, DataContext context)
	{
		_changeTrickBodyPart = value;
		SetModifiedAndInvalidateInfluencedCache(35, DataStates, CacheInfluences, context);
	}

	public bool GetChangeTrickIsFlaw()
	{
		return _changeTrickIsFlaw;
	}

	public void SetChangeTrickIsFlaw(bool value, DataContext context)
	{
		_changeTrickIsFlaw = value;
		SetModifiedAndInvalidateInfluencedCache(36, DataStates, CacheInfluences, context);
	}

	public bool GetEnemyUnyieldingFallen()
	{
		return _enemyUnyieldingFallen;
	}

	public void SetEnemyUnyieldingFallen(bool value, DataContext context)
	{
		_enemyUnyieldingFallen = value;
		SetModifiedAndInvalidateInfluencedCache(37, DataStates, CacheInfluences, context);
	}

	public bool GetDisableEnemyAi()
	{
		return _disableEnemyAi;
	}

	public void SetDisableEnemyAi(bool value, DataContext context)
	{
		_disableEnemyAi = value;
		SetModifiedAndInvalidateInfluencedCache(38, DataStates, CacheInfluences, context);
	}

	public int GetPreferWeaponIndex()
	{
		return _preferWeaponIndex;
	}

	public void SetPreferWeaponIndex(int value, DataContext context)
	{
		_preferWeaponIndex = value;
		SetModifiedAndInvalidateInfluencedCache(39, DataStates, CacheInfluences, context);
	}

	public List<CombatQuickUseItemSlotData> GetCombatQuickUseItemSlotDataList()
	{
		return _combatQuickUseItemSlotDataList;
	}

	public void SetCombatQuickUseItemSlotDataList(List<CombatQuickUseItemSlotData> value, DataContext context)
	{
		_combatQuickUseItemSlotDataList = value;
		SetModifiedAndInvalidateInfluencedCache(40, DataStates, CacheInfluences, context);
	}

	public SkillDamageData GetSkillDamageData()
	{
		return _skillDamageData;
	}

	public void SetSkillDamageData(SkillDamageData value, DataContext context)
	{
		_skillDamageData = value;
		SetModifiedAndInvalidateInfluencedCache(41, DataStates, CacheInfluences, context);
	}

	public CountdownData GetNextAvailableChickenPointAppearCd()
	{
		return _nextAvailableChickenPointAppearCd;
	}

	public void SetNextAvailableChickenPointAppearCd(CountdownData value, DataContext context)
	{
		_nextAvailableChickenPointAppearCd = value;
		SetModifiedAndInvalidateInfluencedCache(42, DataStates, CacheInfluences, context);
	}

	public ChickenPointZones GetChickenPointZones()
	{
		return _chickenPointZones;
	}

	public void SetChickenPointZones(ChickenPointZones value, DataContext context)
	{
		_chickenPointZones = value;
		SetModifiedAndInvalidateInfluencedCache(43, DataStates, CacheInfluences, context);
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
		archive.WriteSingleValueUnmanaged((ushort)8);
		archive.WriteDomainDataMeta(33);
		archive.WriteSingleValueUnmanaged(_lastTargetDistance);
		archive.WriteDomainDataMeta(34);
		archive.WriteSingleValueUnmanaged(_changeTrickIndex);
		archive.WriteDomainDataMeta(35);
		archive.WriteSingleValueUnmanaged(_changeTrickBodyPart);
		archive.WriteDomainDataMeta(36);
		archive.WriteSingleValueUnmanaged(_changeTrickIsFlaw);
		archive.WriteDomainDataMeta(37);
		archive.WriteSingleValueUnmanaged(_enemyUnyieldingFallen);
		archive.WriteDomainDataMeta(38);
		archive.WriteSingleValueUnmanaged(_disableEnemyAi);
		archive.WriteDomainDataMeta(39);
		archive.WriteSingleValueUnmanaged(_preferWeaponIndex);
		archive.WriteDomainDataMeta(40);
		archive.WriteSingleValueCustomList(_combatQuickUseItemSlotDataList);
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
			case 33:
				archive.ReadSingleValueUnmanaged(ref _lastTargetDistance);
				break;
			case 34:
				archive.ReadSingleValueUnmanaged(ref _changeTrickIndex);
				break;
			case 35:
				archive.ReadSingleValueUnmanaged(ref _changeTrickBodyPart);
				break;
			case 36:
				archive.ReadSingleValueUnmanaged(ref _changeTrickIsFlaw);
				break;
			case 37:
				archive.ReadSingleValueUnmanaged(ref _enemyUnyieldingFallen);
				break;
			case 38:
				archive.ReadSingleValueUnmanaged(ref _disableEnemyAi);
				break;
			case 39:
				archive.ReadSingleValueUnmanaged(ref _preferWeaponIndex);
				break;
			case 40:
				archive.ReadSingleValueCustomList(ref _combatQuickUseItemSlotDataList);
				break;
			default:
				throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
			}
			RecordLoadedDomainData(domainDataMeta.DataId);
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(8);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		switch (dataId)
		{
		case 0:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
			}
			return GameData.Serializer.Serializer.Serialize(_timeScale, dataPool);
		case 1:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 1);
			}
			return GameData.Serializer.Serializer.Serialize(_autoCombat, dataPool);
		case 2:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 2);
			}
			return GameData.Serializer.Serializer.Serialize(_combatFrame, dataPool);
		case 3:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			return GameData.Serializer.Serializer.Serialize(_combatType, dataPool);
		case 4:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
			}
			return GameData.Serializer.Serializer.Serialize(_currentDistance, dataPool);
		case 5:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 5);
			}
			return GameData.Serializer.Serializer.Serialize(_damageCompareData, dataPool);
		case 6:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 6);
				_modificationsSkillPowerAddInCombat.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_skillPowerAddInCombat, dataPool);
		case 7:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsSkillPowerReduceInCombat.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_skillPowerReduceInCombat, dataPool);
		case 8:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsSkillPowerReplaceInCombat.Reset();
			}
			return GameData.Serializer.Serializer.SerializeModifications(_skillPowerReplaceInCombat, dataPool);
		case 9:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			return GameData.Serializer.Serializer.Serialize(_bgmIndex, dataPool);
		case 10:
			return GetElementField_CombatCharacterDict((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 11:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			return GameData.Serializer.Serializer.Serialize(_selfTeam, dataPool);
		case 12:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			return GameData.Serializer.Serializer.Serialize(_selfCharId, dataPool);
		case 13:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			return GameData.Serializer.Serializer.Serialize(_selfTeamWisdomType, dataPool);
		case 14:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			return GameData.Serializer.Serializer.Serialize(_selfTeamWisdomCount, dataPool);
		case 15:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyTeam, dataPool);
		case 16:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyCharId, dataPool);
		case 17:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyTeamWisdomType, dataPool);
		case 18:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyTeamWisdomCount, dataPool);
		case 19:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			return GameData.Serializer.Serializer.Serialize(_combatStatus, dataPool);
		case 20:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			return GameData.Serializer.Serializer.Serialize(_showMercyOption, dataPool);
		case 21:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
			}
			return GameData.Serializer.Serializer.Serialize(_selectedMercyOption, dataPool);
		case 22:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
			}
			return GameData.Serializer.Serializer.Serialize(_carrierAnimalCombatCharId, dataPool);
		case 23:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
			}
			return GameData.Serializer.Serializer.Serialize(_specialShowCombatCharId, dataPool);
		case 24:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
			}
			return GameData.Serializer.Serializer.Serialize(_notUsed, dataPool);
		case 25:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
			}
			return GameData.Serializer.Serializer.Serialize(_waitingDelaySettlement, dataPool);
		case 26:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
			}
			return GameData.Serializer.Serializer.Serialize(_showUseGoldenWire, dataPool);
		case 27:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			return GameData.Serializer.Serializer.Serialize(_isPuppetCombat, dataPool);
		case 28:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
			}
			return GameData.Serializer.Serializer.Serialize(_isPlaygroundCombat, dataPool);
		case 29:
			return GetElementField_SkillDataDict((CombatSkillKey)subId0, (ushort)subId1, dataPool, resetModified);
		case 30:
			return GetElementField_WeaponDataDict((int)subId0, (ushort)subId1, dataPool, resetModified);
		case 31:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
			}
			return GameData.Serializer.Serializer.Serialize(_expectRatioData, dataPool);
		case 32:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
			}
			return GameData.Serializer.Serializer.Serialize(_taiwuSpecialGroupCharIds, dataPool);
		case 33:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
			}
			return GameData.Serializer.Serializer.Serialize(_lastTargetDistance, dataPool);
		case 34:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 34);
			}
			return GameData.Serializer.Serializer.Serialize(_changeTrickIndex, dataPool);
		case 35:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
			}
			return GameData.Serializer.Serializer.Serialize(_changeTrickBodyPart, dataPool);
		case 36:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
			}
			return GameData.Serializer.Serializer.Serialize(_changeTrickIsFlaw, dataPool);
		case 37:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
			}
			return GameData.Serializer.Serializer.Serialize(_enemyUnyieldingFallen, dataPool);
		case 38:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
			}
			return GameData.Serializer.Serializer.Serialize(_disableEnemyAi, dataPool);
		case 39:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
			}
			return GameData.Serializer.Serializer.Serialize(_preferWeaponIndex, dataPool);
		case 40:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
			}
			return GameData.Serializer.Serializer.Serialize(_combatQuickUseItemSlotDataList, dataPool);
		case 41:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
			}
			return GameData.Serializer.Serializer.Serialize(_skillDamageData, dataPool);
		case 42:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
			}
			return GameData.Serializer.Serializer.Serialize(_nextAvailableChickenPointAppearCd, dataPool);
		case 43:
			if (resetModified)
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
			}
			return GameData.Serializer.Serializer.SerializeAs(_chickenPointZones, dataPool, (ChickenPointZones x) => (ChickenPointZonesDto)x);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		switch (dataId)
		{
		case 0:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 1:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 2:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _combatFrame);
			SetCombatFrame(_combatFrame, context);
			break;
		case 3:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _combatType);
			SetCombatType(_combatType, context);
			break;
		case 4:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _currentDistance);
			SetCurrentDistance(_currentDistance, context);
			break;
		case 5:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _damageCompareData);
			SetDamageCompareData(_damageCompareData, context);
			break;
		case 6:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 7:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 8:
			throw new Exception($"Not allow to set value of dataId {dataId}");
		case 9:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _bgmIndex);
			SetBgmIndex(_bgmIndex, context);
			break;
		case 10:
			SetElementField_CombatCharacterDict((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 11:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selfTeam);
			SetSelfTeam(_selfTeam, context);
			break;
		case 12:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selfCharId);
			SetSelfCharId(_selfCharId, context);
			break;
		case 13:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selfTeamWisdomType);
			SetSelfTeamWisdomType(_selfTeamWisdomType, context);
			break;
		case 14:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selfTeamWisdomCount);
			SetSelfTeamWisdomCount(_selfTeamWisdomCount, context);
			break;
		case 15:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyTeam);
			SetEnemyTeam(_enemyTeam, context);
			break;
		case 16:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyCharId);
			SetEnemyCharId(_enemyCharId, context);
			break;
		case 17:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyTeamWisdomType);
			SetEnemyTeamWisdomType(_enemyTeamWisdomType, context);
			break;
		case 18:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyTeamWisdomCount);
			SetEnemyTeamWisdomCount(_enemyTeamWisdomCount, context);
			break;
		case 19:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _combatStatus);
			SetCombatStatus(_combatStatus, context);
			break;
		case 20:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _showMercyOption);
			SetShowMercyOption(_showMercyOption, context);
			break;
		case 21:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _selectedMercyOption);
			SetSelectedMercyOption(_selectedMercyOption, context);
			break;
		case 22:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _carrierAnimalCombatCharId);
			SetCarrierAnimalCombatCharId(_carrierAnimalCombatCharId, context);
			break;
		case 23:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _specialShowCombatCharId);
			SetSpecialShowCombatCharId(_specialShowCombatCharId, context);
			break;
		case 24:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _notUsed);
			SetNotUsed(_notUsed, context);
			break;
		case 25:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _waitingDelaySettlement);
			SetWaitingDelaySettlement(_waitingDelaySettlement, context);
			break;
		case 26:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _showUseGoldenWire);
			SetShowUseGoldenWire(_showUseGoldenWire, context);
			break;
		case 27:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _isPuppetCombat);
			SetIsPuppetCombat(_isPuppetCombat, context);
			break;
		case 28:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _isPlaygroundCombat);
			SetIsPlaygroundCombat(_isPlaygroundCombat, context);
			break;
		case 29:
			SetElementField_SkillDataDict((CombatSkillKey)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 30:
			SetElementField_WeaponDataDict((int)subId0, (ushort)subId1, valueOffset, dataPool, context);
			break;
		case 31:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _expectRatioData);
			SetExpectRatioData(_expectRatioData, context);
			break;
		case 32:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _taiwuSpecialGroupCharIds);
			SetTaiwuSpecialGroupCharIds(_taiwuSpecialGroupCharIds, context);
			break;
		case 33:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _lastTargetDistance);
			SetLastTargetDistance(_lastTargetDistance, context);
			break;
		case 34:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _changeTrickIndex);
			SetChangeTrickIndex(_changeTrickIndex, context);
			break;
		case 35:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _changeTrickBodyPart);
			SetChangeTrickBodyPart(_changeTrickBodyPart, context);
			break;
		case 36:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _changeTrickIsFlaw);
			SetChangeTrickIsFlaw(_changeTrickIsFlaw, context);
			break;
		case 37:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _enemyUnyieldingFallen);
			SetEnemyUnyieldingFallen(_enemyUnyieldingFallen, context);
			break;
		case 38:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _disableEnemyAi);
			SetDisableEnemyAi(_disableEnemyAi, context);
			break;
		case 39:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _preferWeaponIndex);
			SetPreferWeaponIndex(_preferWeaponIndex, context);
			break;
		case 40:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _combatQuickUseItemSlotDataList);
			SetCombatQuickUseItemSlotDataList(_combatQuickUseItemSlotDataList, context);
			break;
		case 41:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _skillDamageData);
			SetSkillDamageData(_skillDamageData, context);
			break;
		case 42:
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref _nextAvailableChickenPointAppearCd);
			SetNextAvailableChickenPointAppearCd(_nextAvailableChickenPointAppearCd, context);
			break;
		case 43:
			GameData.Serializer.Serializer.DeserializeAs(dataPool, valueOffset, ref _chickenPointZones, (ChickenPointZonesDto x) => (ChickenPointZones)x);
			SetChickenPointZones(_chickenPointZones, context);
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
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 1)
			{
				bool isAlly10 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly10);
				PlayMoveStepSound(context, isAlly10);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount62 = operation.ArgsCount;
			int num62 = argsCount62;
			if (num62 == 3)
			{
				bool isAlly47 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly47);
				int index8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index8);
				int charId15 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId15);
				bool returnValue41 = ExecuteTeammateCommand(context, isAlly47, index8, charId15);
				return GameData.Serializer.Serializer.Serialize(returnValue41, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 1)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				CombatCharacterDisplayData returnValue10 = GetCombatCharDisplayData(charId5);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount59 = operation.ArgsCount;
			int num59 = argsCount59;
			if (num59 == 2)
			{
				bool isAlly45 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly45);
				bool mercy = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref mercy);
				SelectMercyOption(context, isAlly45, mercy);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				int weaponIndex3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponIndex3);
				ChangeWeapon(context, weaponIndex3);
				return -1;
			}
			case 2:
			{
				int weaponIndex2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponIndex2);
				bool isAlly25 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly25);
				ChangeWeapon(context, weaponIndex2, isAlly25);
				return -1;
			}
			case 3:
			{
				int weaponIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponIndex);
				bool isAlly24 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly24);
				bool forceChange = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref forceChange);
				ChangeWeapon(context, weaponIndex, isAlly24, forceChange);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 5:
			switch (operation.ArgsCount)
			{
			case 0:
				NormalAttack(context);
				return -1;
			case 1:
			{
				bool isAlly21 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly21);
				NormalAttack(context, isAlly21);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 6:
			switch (operation.ArgsCount)
			{
			case 0:
				StartChangeTrick(context);
				return -1;
			case 1:
			{
				bool isAlly14 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly14);
				StartChangeTrick(context, isAlly14);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 7:
		{
			int argsCount69 = operation.ArgsCount;
			int num69 = argsCount69;
			if (num69 == 3)
			{
				sbyte trickType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref trickType2);
				sbyte bodyPart9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart9);
				int flawOrAcupointType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref flawOrAcupointType);
				SelectChangeTrick(context, trickType2, bodyPart9, flawOrAcupointType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount43 = operation.ArgsCount;
			int num43 = argsCount43;
			if (num43 == 2)
			{
				int index5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index5);
				sbyte expectInnerRatio2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref expectInnerRatio2);
				ChangeTaiwuWeaponInnerRatio(context, index5, expectInnerRatio2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount32 = operation.ArgsCount;
			int num32 = argsCount32;
			if (num32 == 1)
			{
				ItemKey weaponKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey2);
				sbyte returnValue21 = GetWeaponInnerRatio(weaponKey2);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				sbyte actionType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionType2);
				StartPrepareOtherAction(context, actionType2);
				return -1;
			}
			case 2:
			{
				sbyte actionType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionType);
				bool isAlly15 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly15);
				StartPrepareOtherAction(context, actionType, isAlly15);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 11:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 1)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				List<CombatSkillDisplayData> returnValue8 = GetProactiveSkillList(charId3);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				short skillId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId2);
				StartPrepareSkill(context, skillId2);
				return -1;
			}
			case 2:
			{
				short skillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId);
				bool isAlly12 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly12);
				StartPrepareSkill(context, skillId, isAlly12);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 13:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ForceRecoverBreathAndStance(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 14:
		{
			int argsCount55 = operation.ArgsCount;
			int num55 = argsCount55;
			if (num55 == 2)
			{
				bool isAlly41 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly41);
				sbyte trickType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref trickType);
				GmCmd_AddTrick(context, isAlly41, trickType);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
			switch (operation.ArgsCount)
			{
			case 3:
			{
				bool isAlly37 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly37);
				sbyte bodyPart6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart6);
				bool isInner3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInner3);
				GmCmd_AddInjury(context, isAlly37, bodyPart6, isInner3);
				return -1;
			}
			case 4:
			{
				bool isAlly36 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly36);
				sbyte bodyPart5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart5);
				bool isInner2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInner2);
				int count5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count5);
				GmCmd_AddInjury(context, isAlly36, bodyPart5, isInner2, count5);
				return -1;
			}
			case 5:
			{
				bool isAlly35 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly35);
				sbyte bodyPart4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart4);
				bool isInner = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInner);
				int count4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count4);
				bool changeToOld2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref changeToOld2);
				GmCmd_AddInjury(context, isAlly35, bodyPart4, isInner, count4, changeToOld2);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 16:
			switch (operation.ArgsCount)
			{
			case 0:
				GmCmd_ForceHealAllInjury(context);
				return -1;
			case 1:
			{
				bool isAlly31 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly31);
				GmCmd_ForceHealAllInjury(context, isAlly31);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 17:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				bool isAlly30 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly30);
				sbyte poisonType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisonType3);
				GmCmd_AddPoison(context, isAlly30, poisonType3);
				return -1;
			}
			case 3:
			{
				bool isAlly29 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly29);
				sbyte poisonType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisonType2);
				int count3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count3);
				GmCmd_AddPoison(context, isAlly29, poisonType2, count3);
				return -1;
			}
			case 4:
			{
				bool isAlly28 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly28);
				sbyte poisonType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref poisonType);
				int count2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count2);
				bool changeToOld = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref changeToOld);
				GmCmd_AddPoison(context, isAlly28, poisonType, count2, changeToOld);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 18:
			switch (operation.ArgsCount)
			{
			case 0:
				GmCmd_ForceHealAllPoison(context);
				return -1;
			case 1:
			{
				bool isAlly27 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly27);
				GmCmd_ForceHealAllPoison(context, isAlly27);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 19:
		{
			int argsCount39 = operation.ArgsCount;
			int num39 = argsCount39;
			if (num39 == 1)
			{
				short skillId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId3);
				GmCmd_ForceEnemyUseSkill(context, skillId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount28 = operation.ArgsCount;
			int num28 = argsCount28;
			if (num28 == 1)
			{
				sbyte actionType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref actionType3);
				GmCmd_ForceEnemyUseOtherAction(context, actionType3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ForceEnemyDefeat(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 22:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ForceSelfDefeat(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 23:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 2)
			{
				bool isAlly7 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly7);
				short[] neiliAllocation = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref neiliAllocation);
				GmCmd_SetNeiliAllocation(context, isAlly7, neiliAllocation);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				bool isAlly3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly3);
				sbyte bodyPart2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart2);
				GmCmd_AddFlaw(context, isAlly3, bodyPart2);
				return -1;
			}
			case 3:
			{
				bool isAlly2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly2);
				sbyte bodyPart = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart);
				int count = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count);
				GmCmd_AddFlaw(context, isAlly2, bodyPart, count);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 25:
		{
			int argsCount67 = operation.ArgsCount;
			int num67 = argsCount67;
			if (num67 == 1)
			{
				bool isAlly55 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly55);
				GmCmd_HealAllFlaw(context, isAlly55);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 26:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				bool isAlly49 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly49);
				sbyte bodyPart8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart8);
				GmCmd_AddAcupoint(context, isAlly49, bodyPart8);
				return -1;
			}
			case 3:
			{
				bool isAlly48 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly48);
				sbyte bodyPart7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart7);
				int count7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count7);
				GmCmd_AddAcupoint(context, isAlly48, bodyPart7, count7);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 27:
		{
			int argsCount57 = operation.ArgsCount;
			int num57 = argsCount57;
			if (num57 == 1)
			{
				bool isAlly42 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly42);
				GmCmd_HealAllAcupoint(context, isAlly42);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 28:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				short charTemplateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charTemplateId5);
				GmCmd_FightBoss(context, charTemplateId5);
				return -1;
			}
			case 2:
			{
				short charTemplateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charTemplateId4);
				int configIndex = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref configIndex);
				GmCmd_FightBoss(context, charTemplateId4, configIndex);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 29:
		{
			int argsCount50 = operation.ArgsCount;
			int num50 = argsCount50;
			if (num50 == 1)
			{
				short charTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charTemplateId3);
				GmCmd_FightAnimal(context, charTemplateId3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 30:
		{
			int argsCount47 = operation.ArgsCount;
			int num47 = argsCount47;
			if (num47 == 1)
			{
				bool on2 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref on2);
				GmCmd_EnableEnemyAi(context, on2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 31:
		{
			int argsCount42 = operation.ArgsCount;
			int num42 = argsCount42;
			if (num42 == 1)
			{
				bool on = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref on);
				GmCmd_EnableSkillFreeCast(context, on);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 32:
		{
			int argsCount36 = operation.ArgsCount;
			int num36 = argsCount36;
			if (num36 == 2)
			{
				int doctorCharId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorCharId2);
				int patientCharId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientCharId2);
				uint returnValue25 = GetHealInjuryBanReason(doctorCharId2, patientCharId2);
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 33:
		{
			int argsCount31 = operation.ArgsCount;
			int num31 = argsCount31;
			if (num31 == 2)
			{
				int doctorCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref doctorCharId);
				int patientCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref patientCharId);
				uint returnValue20 = GetHealPoisonBanReason(doctorCharId, patientCharId);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 34:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				ItemKey itemKey5 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey5);
				UseItem(context, itemKey5, -1);
				return -1;
			}
			case 2:
			{
				ItemKey itemKey4 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey4);
				sbyte useType3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref useType3);
				UseItem(context, itemKey4, useType3);
				return -1;
			}
			case 3:
			{
				ItemKey itemKey3 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey3);
				sbyte useType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref useType2);
				bool isAlly20 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly20);
				UseItem(context, itemKey3, useType2, isAlly20);
				return -1;
			}
			case 4:
			{
				ItemKey itemKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey2);
				sbyte useType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref useType);
				bool isAlly19 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly19);
				List<sbyte> targetBodyParts = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetBodyParts);
				UseItem(context, itemKey2, useType, isAlly19, targetBodyParts);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 35:
		{
			int argsCount26 = operation.ArgsCount;
			int num26 = argsCount26;
			if (num26 == 3)
			{
				short combatConfigId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatConfigId2);
				List<int> leftTeam3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftTeam3);
				List<int> rightTeam3 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightTeam3);
				sbyte returnValue16 = PrepareCombat(context, combatConfigId2, leftTeam3, rightTeam3);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 36:
			if (operation.ArgsCount == 0)
			{
				bool returnValue11 = StartCombat(context);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 37:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 1)
			{
				float timeScale = 0f;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref timeScale);
				SetTimeScale(context, timeScale);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 38:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 1)
			{
				bool autoCombat = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref autoCombat);
				SetPlayerAutoCombat(context, autoCombat);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 39:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				AiOptions aiOptions = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref aiOptions);
				SetAiOptions(aiOptions);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 40:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				MoveState state3 = MoveState.Stay;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref state3);
				SetMoveState(state3);
				return -1;
			}
			case 2:
			{
				MoveState state2 = MoveState.Stay;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref state2);
				bool isAlly5 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly5);
				SetMoveState(state2, isAlly5);
				return -1;
			}
			case 3:
			{
				MoveState state = MoveState.Stay;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref state);
				bool isAlly4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly4);
				bool setByPlayer = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref setByPlayer);
				SetMoveState(state, isAlly4, setByPlayer);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 41:
			if (operation.ArgsCount == 0)
			{
				CombatResultDisplayData returnValue42 = GetCombatResultDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue42, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 42:
		{
			int argsCount65 = operation.ArgsCount;
			int num65 = argsCount65;
			if (num65 == 2)
			{
				List<ItemKey> acceptItems = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref acceptItems);
				List<int> acceptCounts = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref acceptCounts);
				SelectGetItem(context, acceptItems, acceptCounts);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 43:
			switch (operation.ArgsCount)
			{
			case 0:
				Surrender(context);
				return -1;
			case 1:
			{
				bool isAlly53 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly53);
				Surrender(context, isAlly53);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 44:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				short puppetCharTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref puppetCharTemplateId2);
				sbyte consummateLevel2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref consummateLevel2);
				EnterBossPuppetCombat(context, puppetCharTemplateId2, consummateLevel2);
				return -1;
			}
			case 3:
			{
				short puppetCharTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref puppetCharTemplateId);
				sbyte consummateLevel = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref consummateLevel);
				bool playground = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref playground);
				EnterBossPuppetCombat(context, puppetCharTemplateId, consummateLevel, playground);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 45:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				ItemKey toolKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey2);
				ItemKey targetKey2 = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetKey2);
				RepairItem(context, toolKey2, targetKey2);
				return -1;
			}
			case 3:
			{
				ItemKey toolKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref toolKey);
				ItemKey targetKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetKey);
				bool isAlly51 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly51);
				RepairItem(context, toolKey, targetKey, isAlly51);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 46:
		{
			int argsCount60 = operation.ArgsCount;
			int num60 = argsCount60;
			if (num60 == 2)
			{
				short combatConfigId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatConfigId3);
				List<int> enemyList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref enemyList);
				PrepareEnemyEquipments(context, combatConfigId3, enemyList);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 47:
		{
			int argsCount56 = operation.ArgsCount;
			int num56 = argsCount56;
			if (num56 == 1)
			{
				bool enable = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref enable);
				EnableBulletTime(context, enable);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 48:
		{
			int argsCount53 = operation.ArgsCount;
			int num53 = argsCount53;
			if (num53 == 2)
			{
				bool isAlly40 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly40);
				bool on3 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref on3);
				GmCmd_SetImmortal(context, isAlly40, on3);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 49:
			switch (operation.ArgsCount)
			{
			case 0:
				CancelChangeTrick(context);
				return -1;
			case 1:
			{
				bool isAlly39 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly39);
				CancelChangeTrick(context, isAlly39);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 50:
			switch (operation.ArgsCount)
			{
			case 0:
				ClearAllReserveAction(context);
				return -1;
			case 1:
			{
				bool isAlly38 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly38);
				ClearAllReserveAction(context, isAlly38);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 51:
			if (operation.ArgsCount == 0)
			{
				bool returnValue33 = IsInCombat();
				return GameData.Serializer.Serializer.Serialize(returnValue33, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 52:
		{
			int argsCount48 = operation.ArgsCount;
			int num48 = argsCount48;
			if (num48 == 2)
			{
				short charTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charTemplateId2);
				int testCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref testCount);
				GmCmd_FightTestOrgMember(context, charTemplateId2, testCount);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 53:
		{
			int argsCount45 = operation.ArgsCount;
			int num45 = argsCount45;
			if (num45 == 2)
			{
				short charTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charTemplateId);
				sbyte combatTypeAsSbyte = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatTypeAsSbyte);
				GmCmd_FightRandomEnemy(context, charTemplateId, combatTypeAsSbyte);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 54:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ForceRecoverMobilityValue(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 55:
		{
			int argsCount38 = operation.ArgsCount;
			int num38 = argsCount38;
			if (num38 == 1)
			{
				bool isAlly23 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly23);
				GmCmd_UnitTestSetDistanceToTarget(context, isAlly23);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 56:
		{
			int argsCount34 = operation.ArgsCount;
			int num34 = argsCount34;
			if (num34 == 3)
			{
				int charId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId11);
				short skillTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId);
				bool isDirect = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isDirect);
				bool returnValue23 = GmCmd_UnitTestEquipSkill(context, charId11, skillTemplateId, isDirect);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 57:
			switch (operation.ArgsCount)
			{
			case 0:
				GmCmd_UnitTestPrepare(context);
				return -1;
			case 1:
			{
				bool testing = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref testing);
				GmCmd_UnitTestPrepare(context, testing);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 58:
		{
			int argsCount30 = operation.ArgsCount;
			int num30 = argsCount30;
			if (num30 == 1)
			{
				int charId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId10);
				GmCmd_UnitTestClearAllEquipSkill(context, charId10);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 59:
		{
			int argsCount27 = operation.ArgsCount;
			int num27 = argsCount27;
			if (num27 == 1)
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				DamageStepDisplayData returnValue18 = GetFatalDamageStepDisplayData(charId8);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 60:
		{
			int argsCount24 = operation.ArgsCount;
			int num24 = argsCount24;
			if (num24 == 1)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				DamageStepDisplayData returnValue14 = GetMindDamageStepDisplayData(charId7);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 61:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 2)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				sbyte bodyPart3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref bodyPart3);
				OuterAndInnerDamageStepDisplayData returnValue12 = GetBodyPartDamageStepDisplayData(charId6, bodyPart3);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 62:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 1)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				CompleteDamageStepDisplayData returnValue9 = GetCompleteDamageStepDisplayData(charId4);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 63:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 2)
			{
				bool isAlly13 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly13);
				short wugCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref wugCount);
				GmCmd_ForceRecoverWugCount(context, isAlly13, wugCount);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 64:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				short combatConfig = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatConfig);
				GmCmd_FightCharacter(context, charId2, combatConfig);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 65:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				ChangeTrickDisplayData returnValue6 = GetChangeTrickDisplayData();
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			case 1:
			{
				bool isAlly11 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly11);
				ChangeTrickDisplayData returnValue5 = GetChangeTrickDisplayData(isAlly11);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 66:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				bool isAlly9 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly9);
				ClearAffectingDefenseSkillManual(context, isAlly9);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 67:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				bool returnValue2 = ClearDefendInBlockAttackSkill(context);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			case 1:
			{
				bool isAlly8 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly8);
				bool returnValue = ClearDefendInBlockAttackSkill(context, isAlly8);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 68:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 1)
			{
				bool isAlly6 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly6);
				GmCmd_HealAllFatal(context, isAlly6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 69:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				bool isAlly = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly);
				GmCmd_HealAllDefeatMark(context, isAlly);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 70:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				bool isAlly58 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly58);
				GmCmd_AddAllDefeatMark(context, isAlly58);
				return -1;
			}
			case 2:
			{
				bool isAlly57 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly57);
				int count10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count10);
				GmCmd_AddAllDefeatMark(context, isAlly57, count10);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 71:
		{
			int argsCount68 = operation.ArgsCount;
			int num68 = argsCount68;
			if (num68 == 2)
			{
				bool isAlly56 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly56);
				int count9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count9);
				GmCmd_AddFatal(context, isAlly56, count9);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 72:
		{
			int argsCount66 = operation.ArgsCount;
			int num66 = argsCount66;
			if (num66 == 1)
			{
				bool isAlly54 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly54);
				GmCmd_HealAllDie(context, isAlly54);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 73:
		{
			int argsCount64 = operation.ArgsCount;
			int num64 = argsCount64;
			if (num64 == 2)
			{
				bool isAlly52 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly52);
				int count8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count8);
				GmCmd_AddDie(context, isAlly52, count8);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 74:
		{
			int argsCount63 = operation.ArgsCount;
			int num63 = argsCount63;
			if (num63 == 1)
			{
				bool isAlly50 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly50);
				GmCmd_HealAllMind(context, isAlly50);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 75:
		{
			int argsCount61 = operation.ArgsCount;
			int num61 = argsCount61;
			if (num61 == 2)
			{
				bool isAlly46 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly46);
				bool isInner4 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isInner4);
				GmCmd_HealInjury(context, isAlly46, isInner4);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 76:
		{
			int argsCount58 = operation.ArgsCount;
			int num58 = argsCount58;
			if (num58 == 2)
			{
				bool isAlly44 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly44);
				int count6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref count6);
				GmCmd_AddMind(context, isAlly44, count6);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 77:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				short targetDistance2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetDistance2);
				SetTargetDistance(context, targetDistance2);
				return -1;
			}
			case 2:
			{
				short targetDistance = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref targetDistance);
				bool isAlly43 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly43);
				SetTargetDistance(context, targetDistance, isAlly43);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 78:
			if (operation.ArgsCount == 0)
			{
				ClearTargetDistance(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 79:
		{
			int argsCount54 = operation.ArgsCount;
			int num54 = argsCount54;
			if (num54 == 2)
			{
				short combatSkillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId);
				short jumpThreshold = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref jumpThreshold);
				bool returnValue40 = SetJumpThreshold(context, combatSkillId, jumpThreshold);
				return GameData.Serializer.Serializer.Serialize(returnValue40, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 80:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				int charId14 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId14);
				short skillId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId5);
				OuterAndInnerShorts returnValue39 = GetPreviewAttackRange(charId14, skillId5);
				return GameData.Serializer.Serializer.Serialize(returnValue39, returnDataPool);
			}
			case 3:
			{
				int charId13 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId13);
				short skillId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId4);
				int weaponIndex4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponIndex4);
				OuterAndInnerShorts returnValue38 = GetPreviewAttackRange(charId13, skillId4, weaponIndex4);
				return GameData.Serializer.Serializer.Serialize(returnValue38, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 81:
		{
			int argsCount52 = operation.ArgsCount;
			int num52 = argsCount52;
			if (num52 == 1)
			{
				bool unyieldingFallen = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref unyieldingFallen);
				bool returnValue37 = SetPuppetUnyieldingFallen(context, unyieldingFallen);
				return GameData.Serializer.Serializer.Serialize(returnValue37, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 82:
		{
			int argsCount51 = operation.ArgsCount;
			int num51 = argsCount51;
			if (num51 == 1)
			{
				bool disableAi = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref disableAi);
				bool returnValue36 = SetPuppetDisableAi(context, disableAi);
				return GameData.Serializer.Serializer.Serialize(returnValue36, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 83:
			switch (operation.ArgsCount)
			{
			case 0:
			{
				bool returnValue35 = InterruptSkillManual(context);
				return GameData.Serializer.Serializer.Serialize(returnValue35, returnDataPool);
			}
			case 1:
			{
				bool isAlly34 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly34);
				bool returnValue34 = InterruptSkillManual(context, isAlly34);
				return GameData.Serializer.Serializer.Serialize(returnValue34, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 84:
		{
			int argsCount49 = operation.ArgsCount;
			int num49 = argsCount49;
			if (num49 == 1)
			{
				bool isAlly33 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly33);
				ClearAffectingMoveSkillManual(context, isAlly33);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 85:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				int index7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index7);
				UnlockAttack(context, index7);
				return -1;
			}
			case 2:
			{
				int index6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index6);
				bool isAlly32 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly32);
				UnlockAttack(context, index6, isAlly32);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 86:
			if (operation.ArgsCount == 0)
			{
				bool returnValue32 = IgnoreAllRawCreate(context);
				return GameData.Serializer.Serializer.Serialize(returnValue32, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 87:
		{
			int argsCount46 = operation.ArgsCount;
			int num46 = argsCount46;
			if (num46 == 1)
			{
				int effectId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectId3);
				bool returnValue31 = IgnoreRawCreate(context, effectId3);
				return GameData.Serializer.Serializer.Serialize(returnValue31, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 88:
		{
			int argsCount44 = operation.ArgsCount;
			int num44 = argsCount44;
			if (num44 == 3)
			{
				int effectId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectId2);
				sbyte equipmentSlot = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref equipmentSlot);
				short newTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref newTemplateId);
				bool returnValue30 = DoRawCreate(context, effectId2, equipmentSlot, newTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue30, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 89:
		{
			int argsCount41 = operation.ArgsCount;
			int num41 = argsCount41;
			if (num41 == 1)
			{
				int effectId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref effectId);
				List<sbyte> returnValue29 = GetAllCanRawCreateEquipmentSlots(effectId);
				return GameData.Serializer.Serializer.Serialize(returnValue29, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 90:
			switch (operation.ArgsCount)
			{
			case 1:
			{
				int index4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index4);
				UnlockSimulateResult returnValue28 = GetUnlockSimulateResult(index4);
				return GameData.Serializer.Serializer.Serialize(returnValue28, returnDataPool);
			}
			case 2:
			{
				int index3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index3);
				bool isAlly26 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly26);
				UnlockSimulateResult returnValue27 = GetUnlockSimulateResult(index3, isAlly26);
				return GameData.Serializer.Serializer.Serialize(returnValue27, returnDataPool);
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 91:
		{
			int argsCount40 = operation.ArgsCount;
			int num40 = argsCount40;
			if (num40 == 1)
			{
				int charId12 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId12);
				DefeatMarksCountOutOfCombatData returnValue26 = GetDefeatMarksCountOutOfCombat(context, charId12);
				return GameData.Serializer.Serializer.Serialize(returnValue26, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 92:
		{
			int argsCount37 = operation.ArgsCount;
			int num37 = argsCount37;
			if (num37 == 2)
			{
				CombatResultDisplayData combatResultData = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatResultData);
				List<ItemDisplayData> selectedLootItem = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref selectedLootItem);
				ApplyCombatResultDataEffect(context, combatResultData, selectedLootItem);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 93:
			switch (operation.ArgsCount)
			{
			case 0:
				ClearReserveNormalAttack(context);
				return -1;
			case 1:
			{
				bool isAlly22 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly22);
				ClearReserveNormalAttack(context, isAlly22);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 94:
		{
			int argsCount35 = operation.ArgsCount;
			int num35 = argsCount35;
			if (num35 == 2)
			{
				int typeInt2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt2);
				int index2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index2);
				CharacterDisplayData returnValue24 = ApplyVitalOnTeammate(context, typeInt2, index2);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 95:
		{
			int argsCount33 = operation.ArgsCount;
			int num33 = argsCount33;
			if (num33 == 1)
			{
				int typeInt = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref typeInt);
				int returnValue22 = RevertVitalOnTeammate(context, typeInt);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 96:
			if (operation.ArgsCount == 0)
			{
				GmCmd_ForceRecoverTeammateCommand(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 97:
		{
			int argsCount29 = operation.ArgsCount;
			int num29 = argsCount29;
			if (num29 == 1)
			{
				int charId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId9);
				List<ItemDisplayData> returnValue19 = RequestValidItemsInCombat(charId9);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 98:
			if (operation.ArgsCount == 0)
			{
				List<short> returnValue17 = RequestSwordFragmentSkillIds();
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 99:
			switch (operation.ArgsCount)
			{
			case 2:
			{
				sbyte itemType2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemType2);
				short templateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId2);
				UseSpecialItem(context, itemType2, templateId2);
				return -1;
			}
			case 3:
			{
				sbyte itemType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemType);
				short templateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref templateId);
				bool isAlly18 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly18);
				UseSpecialItem(context, itemType, templateId, isAlly18);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 100:
			switch (operation.ArgsCount)
			{
			case 0:
				NormalAttackImmediate(context);
				return -1;
			case 1:
			{
				bool isAlly17 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly17);
				NormalAttackImmediate(context, isAlly17);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 101:
			switch (operation.ArgsCount)
			{
			case 0:
				InterruptOtherActionManual(context);
				return -1;
			case 1:
			{
				bool isAlly16 = false;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref isAlly16);
				InterruptOtherActionManual(context, isAlly16);
				return -1;
			}
			default:
				throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
			}
		case 102:
		{
			int argsCount25 = operation.ArgsCount;
			int num25 = argsCount25;
			if (num25 == 2)
			{
				List<int> leftTeam2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftTeam2);
				List<int> rightTeam2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightTeam2);
				EPrepareCombatResult returnValue15 = PrepareSimulate(leftTeam2, rightTeam2);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 103:
		{
			int argsCount23 = operation.ArgsCount;
			int num23 = argsCount23;
			if (num23 == 3)
			{
				short combatConfigId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatConfigId);
				List<int> leftTeam = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftTeam);
				List<int> rightTeam = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightTeam);
				TeammateCommandChangeData returnValue13 = PreparePreRandomTeammateCommands(context, combatConfigId, leftTeam, rightTeam);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 104:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 3)
			{
				int leftCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftCharId);
				int rightCharId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightCharId);
				short combatConfig2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatConfig2);
				GmCmd_FightNpc(leftCharId, rightCharId, combatConfig2);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 105:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 1)
			{
				List<CombatQuickUseItemSlotData> list = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref list);
				SetCombatQuickUseItemSlotData(context, list);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 106:
			if (operation.ArgsCount == 0)
			{
				List<CombatQuickUseItemSlotData> returnValue7 = GetCombatQuickUseItemSlotData();
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 107:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 2)
			{
				short leftCharTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref leftCharTemplateId);
				short rightCharTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref rightCharTemplateId);
				GmCmd_FightBossInternal(context, leftCharTemplateId, rightCharTemplateId);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 108:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				ItemKey itemKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref itemKey);
				sbyte expectInnerRatio = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref expectInnerRatio);
				ChangeTaiwuWeaponInnerRatioByWeaponKey(context, itemKey, expectInnerRatio);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 109:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 1)
			{
				ItemKey weaponKey = default(ItemKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref weaponKey);
				IntPair returnValue4 = GetWeaponExpectInnerRatio(weaponKey);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 110:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 2)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				DefeatMarkKey markKey = default(DefeatMarkKey);
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref markKey);
				DefeatMarkDetailInfoDisplayData returnValue3 = GetMarkDisplayData(context, charId, markKey);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 111:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 1)
			{
				int index = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref index);
				GmCmd_FightTwelveImmortals(context, index);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 112:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 1)
			{
				List<int> selectedPointIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref selectedPointIds);
				InvokeChickenPoints(context, selectedPointIds);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 113:
			if (operation.ArgsCount == 0)
			{
				FinishChickenPhase();
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 114:
			if (operation.ArgsCount == 0)
			{
				ApplyChickenEffect(context);
				return -1;
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
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
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		case 6:
			_modificationsSkillPowerAddInCombat.ChangeRecording(monitoring);
			break;
		case 7:
			_modificationsSkillPowerReduceInCombat.ChangeRecording(monitoring);
			break;
		case 8:
			_modificationsSkillPowerReplaceInCombat.ChangeRecording(monitoring);
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
			break;
		case 14:
			break;
		case 15:
			break;
		case 16:
			break;
		case 17:
			break;
		case 18:
			break;
		case 19:
			break;
		case 20:
			break;
		case 21:
			break;
		case 22:
			break;
		case 23:
			break;
		case 24:
			break;
		case 25:
			break;
		case 26:
			break;
		case 27:
			break;
		case 28:
			break;
		case 29:
			break;
		case 30:
			break;
		case 31:
			break;
		case 32:
			break;
		case 33:
			break;
		case 34:
			break;
		case 35:
			break;
		case 36:
			break;
		case 37:
			break;
		case 38:
			break;
		case 39:
			break;
		case 40:
			break;
		case 41:
			break;
		case 42:
			break;
		case 43:
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
			if (!BaseGameDataDomain.IsModified(DataStates, 0))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 0);
			return GameData.Serializer.Serializer.Serialize(_timeScale, dataPool);
		case 1:
			if (!BaseGameDataDomain.IsModified(DataStates, 1))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 1);
			return GameData.Serializer.Serializer.Serialize(_autoCombat, dataPool);
		case 2:
			if (!BaseGameDataDomain.IsModified(DataStates, 2))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 2);
			return GameData.Serializer.Serializer.Serialize(_combatFrame, dataPool);
		case 3:
			if (!BaseGameDataDomain.IsModified(DataStates, 3))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 3);
			return GameData.Serializer.Serializer.Serialize(_combatType, dataPool);
		case 4:
			if (!BaseGameDataDomain.IsModified(DataStates, 4))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 4);
			return GameData.Serializer.Serializer.Serialize(_currentDistance, dataPool);
		case 5:
			if (!BaseGameDataDomain.IsModified(DataStates, 5))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 5);
			return GameData.Serializer.Serializer.Serialize(_damageCompareData, dataPool);
		case 6:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 6))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 6);
			int offset2 = GameData.Serializer.Serializer.SerializeModifications(_skillPowerAddInCombat, dataPool, _modificationsSkillPowerAddInCombat);
			_modificationsSkillPowerAddInCombat.Reset();
			return offset2;
		}
		case 7:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 7))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 7);
			int offset = GameData.Serializer.Serializer.SerializeModifications(_skillPowerReduceInCombat, dataPool, _modificationsSkillPowerReduceInCombat);
			_modificationsSkillPowerReduceInCombat.Reset();
			return offset;
		}
		case 8:
		{
			if (!BaseGameDataDomain.IsModified(DataStates, 8))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 8);
			int offset3 = GameData.Serializer.Serializer.SerializeModifications(_skillPowerReplaceInCombat, dataPool, _modificationsSkillPowerReplaceInCombat);
			_modificationsSkillPowerReplaceInCombat.Reset();
			return offset3;
		}
		case 9:
			if (!BaseGameDataDomain.IsModified(DataStates, 9))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 9);
			return GameData.Serializer.Serializer.Serialize(_bgmIndex, dataPool);
		case 10:
			return CheckModified_CombatCharacterDict((int)subId0, (ushort)subId1, dataPool);
		case 11:
			if (!BaseGameDataDomain.IsModified(DataStates, 11))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 11);
			return GameData.Serializer.Serializer.Serialize(_selfTeam, dataPool);
		case 12:
			if (!BaseGameDataDomain.IsModified(DataStates, 12))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 12);
			return GameData.Serializer.Serializer.Serialize(_selfCharId, dataPool);
		case 13:
			if (!BaseGameDataDomain.IsModified(DataStates, 13))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 13);
			return GameData.Serializer.Serializer.Serialize(_selfTeamWisdomType, dataPool);
		case 14:
			if (!BaseGameDataDomain.IsModified(DataStates, 14))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 14);
			return GameData.Serializer.Serializer.Serialize(_selfTeamWisdomCount, dataPool);
		case 15:
			if (!BaseGameDataDomain.IsModified(DataStates, 15))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 15);
			return GameData.Serializer.Serializer.Serialize(_enemyTeam, dataPool);
		case 16:
			if (!BaseGameDataDomain.IsModified(DataStates, 16))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 16);
			return GameData.Serializer.Serializer.Serialize(_enemyCharId, dataPool);
		case 17:
			if (!BaseGameDataDomain.IsModified(DataStates, 17))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 17);
			return GameData.Serializer.Serializer.Serialize(_enemyTeamWisdomType, dataPool);
		case 18:
			if (!BaseGameDataDomain.IsModified(DataStates, 18))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 18);
			return GameData.Serializer.Serializer.Serialize(_enemyTeamWisdomCount, dataPool);
		case 19:
			if (!BaseGameDataDomain.IsModified(DataStates, 19))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 19);
			return GameData.Serializer.Serializer.Serialize(_combatStatus, dataPool);
		case 20:
			if (!BaseGameDataDomain.IsModified(DataStates, 20))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 20);
			return GameData.Serializer.Serializer.Serialize(_showMercyOption, dataPool);
		case 21:
			if (!BaseGameDataDomain.IsModified(DataStates, 21))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 21);
			return GameData.Serializer.Serializer.Serialize(_selectedMercyOption, dataPool);
		case 22:
			if (!BaseGameDataDomain.IsModified(DataStates, 22))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 22);
			return GameData.Serializer.Serializer.Serialize(_carrierAnimalCombatCharId, dataPool);
		case 23:
			if (!BaseGameDataDomain.IsModified(DataStates, 23))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 23);
			return GameData.Serializer.Serializer.Serialize(_specialShowCombatCharId, dataPool);
		case 24:
			if (!BaseGameDataDomain.IsModified(DataStates, 24))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 24);
			return GameData.Serializer.Serializer.Serialize(_notUsed, dataPool);
		case 25:
			if (!BaseGameDataDomain.IsModified(DataStates, 25))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 25);
			return GameData.Serializer.Serializer.Serialize(_waitingDelaySettlement, dataPool);
		case 26:
			if (!BaseGameDataDomain.IsModified(DataStates, 26))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 26);
			return GameData.Serializer.Serializer.Serialize(_showUseGoldenWire, dataPool);
		case 27:
			if (!BaseGameDataDomain.IsModified(DataStates, 27))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 27);
			return GameData.Serializer.Serializer.Serialize(_isPuppetCombat, dataPool);
		case 28:
			if (!BaseGameDataDomain.IsModified(DataStates, 28))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 28);
			return GameData.Serializer.Serializer.Serialize(_isPlaygroundCombat, dataPool);
		case 29:
			return CheckModified_SkillDataDict((CombatSkillKey)subId0, (ushort)subId1, dataPool);
		case 30:
			return CheckModified_WeaponDataDict((int)subId0, (ushort)subId1, dataPool);
		case 31:
			if (!BaseGameDataDomain.IsModified(DataStates, 31))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 31);
			return GameData.Serializer.Serializer.Serialize(_expectRatioData, dataPool);
		case 32:
			if (!BaseGameDataDomain.IsModified(DataStates, 32))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 32);
			return GameData.Serializer.Serializer.Serialize(_taiwuSpecialGroupCharIds, dataPool);
		case 33:
			if (!BaseGameDataDomain.IsModified(DataStates, 33))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 33);
			return GameData.Serializer.Serializer.Serialize(_lastTargetDistance, dataPool);
		case 34:
			if (!BaseGameDataDomain.IsModified(DataStates, 34))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 34);
			return GameData.Serializer.Serializer.Serialize(_changeTrickIndex, dataPool);
		case 35:
			if (!BaseGameDataDomain.IsModified(DataStates, 35))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 35);
			return GameData.Serializer.Serializer.Serialize(_changeTrickBodyPart, dataPool);
		case 36:
			if (!BaseGameDataDomain.IsModified(DataStates, 36))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 36);
			return GameData.Serializer.Serializer.Serialize(_changeTrickIsFlaw, dataPool);
		case 37:
			if (!BaseGameDataDomain.IsModified(DataStates, 37))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 37);
			return GameData.Serializer.Serializer.Serialize(_enemyUnyieldingFallen, dataPool);
		case 38:
			if (!BaseGameDataDomain.IsModified(DataStates, 38))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 38);
			return GameData.Serializer.Serializer.Serialize(_disableEnemyAi, dataPool);
		case 39:
			if (!BaseGameDataDomain.IsModified(DataStates, 39))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 39);
			return GameData.Serializer.Serializer.Serialize(_preferWeaponIndex, dataPool);
		case 40:
			if (!BaseGameDataDomain.IsModified(DataStates, 40))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 40);
			return GameData.Serializer.Serializer.Serialize(_combatQuickUseItemSlotDataList, dataPool);
		case 41:
			if (!BaseGameDataDomain.IsModified(DataStates, 41))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 41);
			return GameData.Serializer.Serializer.Serialize(_skillDamageData, dataPool);
		case 42:
			if (!BaseGameDataDomain.IsModified(DataStates, 42))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 42);
			return GameData.Serializer.Serializer.Serialize(_nextAvailableChickenPointAppearCd, dataPool);
		case 43:
			if (!BaseGameDataDomain.IsModified(DataStates, 43))
			{
				return -1;
			}
			BaseGameDataDomain.ResetModified(DataStates, 43);
			return GameData.Serializer.Serializer.SerializeAs(_chickenPointZones, dataPool, (ChickenPointZones x) => (ChickenPointZonesDto)x);
		default:
			throw new Exception($"Unsupported dataId {dataId}");
		}
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		switch (dataId)
		{
		case 0:
			if (BaseGameDataDomain.IsModified(DataStates, 0))
			{
				BaseGameDataDomain.ResetModified(DataStates, 0);
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
			}
			break;
		case 3:
			if (BaseGameDataDomain.IsModified(DataStates, 3))
			{
				BaseGameDataDomain.ResetModified(DataStates, 3);
			}
			break;
		case 4:
			if (BaseGameDataDomain.IsModified(DataStates, 4))
			{
				BaseGameDataDomain.ResetModified(DataStates, 4);
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
				_modificationsSkillPowerAddInCombat.Reset();
			}
			break;
		case 7:
			if (BaseGameDataDomain.IsModified(DataStates, 7))
			{
				BaseGameDataDomain.ResetModified(DataStates, 7);
				_modificationsSkillPowerReduceInCombat.Reset();
			}
			break;
		case 8:
			if (BaseGameDataDomain.IsModified(DataStates, 8))
			{
				BaseGameDataDomain.ResetModified(DataStates, 8);
				_modificationsSkillPowerReplaceInCombat.Reset();
			}
			break;
		case 9:
			if (BaseGameDataDomain.IsModified(DataStates, 9))
			{
				BaseGameDataDomain.ResetModified(DataStates, 9);
			}
			break;
		case 10:
			ResetModifiedWrapper_CombatCharacterDict((int)subId0, (ushort)subId1);
			break;
		case 11:
			if (BaseGameDataDomain.IsModified(DataStates, 11))
			{
				BaseGameDataDomain.ResetModified(DataStates, 11);
			}
			break;
		case 12:
			if (BaseGameDataDomain.IsModified(DataStates, 12))
			{
				BaseGameDataDomain.ResetModified(DataStates, 12);
			}
			break;
		case 13:
			if (BaseGameDataDomain.IsModified(DataStates, 13))
			{
				BaseGameDataDomain.ResetModified(DataStates, 13);
			}
			break;
		case 14:
			if (BaseGameDataDomain.IsModified(DataStates, 14))
			{
				BaseGameDataDomain.ResetModified(DataStates, 14);
			}
			break;
		case 15:
			if (BaseGameDataDomain.IsModified(DataStates, 15))
			{
				BaseGameDataDomain.ResetModified(DataStates, 15);
			}
			break;
		case 16:
			if (BaseGameDataDomain.IsModified(DataStates, 16))
			{
				BaseGameDataDomain.ResetModified(DataStates, 16);
			}
			break;
		case 17:
			if (BaseGameDataDomain.IsModified(DataStates, 17))
			{
				BaseGameDataDomain.ResetModified(DataStates, 17);
			}
			break;
		case 18:
			if (BaseGameDataDomain.IsModified(DataStates, 18))
			{
				BaseGameDataDomain.ResetModified(DataStates, 18);
			}
			break;
		case 19:
			if (BaseGameDataDomain.IsModified(DataStates, 19))
			{
				BaseGameDataDomain.ResetModified(DataStates, 19);
			}
			break;
		case 20:
			if (BaseGameDataDomain.IsModified(DataStates, 20))
			{
				BaseGameDataDomain.ResetModified(DataStates, 20);
			}
			break;
		case 21:
			if (BaseGameDataDomain.IsModified(DataStates, 21))
			{
				BaseGameDataDomain.ResetModified(DataStates, 21);
			}
			break;
		case 22:
			if (BaseGameDataDomain.IsModified(DataStates, 22))
			{
				BaseGameDataDomain.ResetModified(DataStates, 22);
			}
			break;
		case 23:
			if (BaseGameDataDomain.IsModified(DataStates, 23))
			{
				BaseGameDataDomain.ResetModified(DataStates, 23);
			}
			break;
		case 24:
			if (BaseGameDataDomain.IsModified(DataStates, 24))
			{
				BaseGameDataDomain.ResetModified(DataStates, 24);
			}
			break;
		case 25:
			if (BaseGameDataDomain.IsModified(DataStates, 25))
			{
				BaseGameDataDomain.ResetModified(DataStates, 25);
			}
			break;
		case 26:
			if (BaseGameDataDomain.IsModified(DataStates, 26))
			{
				BaseGameDataDomain.ResetModified(DataStates, 26);
			}
			break;
		case 27:
			if (BaseGameDataDomain.IsModified(DataStates, 27))
			{
				BaseGameDataDomain.ResetModified(DataStates, 27);
			}
			break;
		case 28:
			if (BaseGameDataDomain.IsModified(DataStates, 28))
			{
				BaseGameDataDomain.ResetModified(DataStates, 28);
			}
			break;
		case 29:
			ResetModifiedWrapper_SkillDataDict((CombatSkillKey)subId0, (ushort)subId1);
			break;
		case 30:
			ResetModifiedWrapper_WeaponDataDict((int)subId0, (ushort)subId1);
			break;
		case 31:
			if (BaseGameDataDomain.IsModified(DataStates, 31))
			{
				BaseGameDataDomain.ResetModified(DataStates, 31);
			}
			break;
		case 32:
			if (BaseGameDataDomain.IsModified(DataStates, 32))
			{
				BaseGameDataDomain.ResetModified(DataStates, 32);
			}
			break;
		case 33:
			if (BaseGameDataDomain.IsModified(DataStates, 33))
			{
				BaseGameDataDomain.ResetModified(DataStates, 33);
			}
			break;
		case 34:
			if (BaseGameDataDomain.IsModified(DataStates, 34))
			{
				BaseGameDataDomain.ResetModified(DataStates, 34);
			}
			break;
		case 35:
			if (BaseGameDataDomain.IsModified(DataStates, 35))
			{
				BaseGameDataDomain.ResetModified(DataStates, 35);
			}
			break;
		case 36:
			if (BaseGameDataDomain.IsModified(DataStates, 36))
			{
				BaseGameDataDomain.ResetModified(DataStates, 36);
			}
			break;
		case 37:
			if (BaseGameDataDomain.IsModified(DataStates, 37))
			{
				BaseGameDataDomain.ResetModified(DataStates, 37);
			}
			break;
		case 38:
			if (BaseGameDataDomain.IsModified(DataStates, 38))
			{
				BaseGameDataDomain.ResetModified(DataStates, 38);
			}
			break;
		case 39:
			if (BaseGameDataDomain.IsModified(DataStates, 39))
			{
				BaseGameDataDomain.ResetModified(DataStates, 39);
			}
			break;
		case 40:
			if (BaseGameDataDomain.IsModified(DataStates, 40))
			{
				BaseGameDataDomain.ResetModified(DataStates, 40);
			}
			break;
		case 41:
			if (BaseGameDataDomain.IsModified(DataStates, 41))
			{
				BaseGameDataDomain.ResetModified(DataStates, 41);
			}
			break;
		case 42:
			if (BaseGameDataDomain.IsModified(DataStates, 42))
			{
				BaseGameDataDomain.ResetModified(DataStates, 42);
			}
			break;
		case 43:
			if (BaseGameDataDomain.IsModified(DataStates, 43))
			{
				BaseGameDataDomain.ResetModified(DataStates, 43);
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
			0 => BaseGameDataDomain.IsModified(DataStates, 0), 
			1 => BaseGameDataDomain.IsModified(DataStates, 1), 
			2 => BaseGameDataDomain.IsModified(DataStates, 2), 
			3 => BaseGameDataDomain.IsModified(DataStates, 3), 
			4 => BaseGameDataDomain.IsModified(DataStates, 4), 
			5 => BaseGameDataDomain.IsModified(DataStates, 5), 
			6 => BaseGameDataDomain.IsModified(DataStates, 6), 
			7 => BaseGameDataDomain.IsModified(DataStates, 7), 
			8 => BaseGameDataDomain.IsModified(DataStates, 8), 
			9 => BaseGameDataDomain.IsModified(DataStates, 9), 
			10 => IsModifiedWrapper_CombatCharacterDict((int)subId0, (ushort)subId1), 
			11 => BaseGameDataDomain.IsModified(DataStates, 11), 
			12 => BaseGameDataDomain.IsModified(DataStates, 12), 
			13 => BaseGameDataDomain.IsModified(DataStates, 13), 
			14 => BaseGameDataDomain.IsModified(DataStates, 14), 
			15 => BaseGameDataDomain.IsModified(DataStates, 15), 
			16 => BaseGameDataDomain.IsModified(DataStates, 16), 
			17 => BaseGameDataDomain.IsModified(DataStates, 17), 
			18 => BaseGameDataDomain.IsModified(DataStates, 18), 
			19 => BaseGameDataDomain.IsModified(DataStates, 19), 
			20 => BaseGameDataDomain.IsModified(DataStates, 20), 
			21 => BaseGameDataDomain.IsModified(DataStates, 21), 
			22 => BaseGameDataDomain.IsModified(DataStates, 22), 
			23 => BaseGameDataDomain.IsModified(DataStates, 23), 
			24 => BaseGameDataDomain.IsModified(DataStates, 24), 
			25 => BaseGameDataDomain.IsModified(DataStates, 25), 
			26 => BaseGameDataDomain.IsModified(DataStates, 26), 
			27 => BaseGameDataDomain.IsModified(DataStates, 27), 
			28 => BaseGameDataDomain.IsModified(DataStates, 28), 
			29 => IsModifiedWrapper_SkillDataDict((CombatSkillKey)subId0, (ushort)subId1), 
			30 => IsModifiedWrapper_WeaponDataDict((int)subId0, (ushort)subId1), 
			31 => BaseGameDataDomain.IsModified(DataStates, 31), 
			32 => BaseGameDataDomain.IsModified(DataStates, 32), 
			33 => BaseGameDataDomain.IsModified(DataStates, 33), 
			34 => BaseGameDataDomain.IsModified(DataStates, 34), 
			35 => BaseGameDataDomain.IsModified(DataStates, 35), 
			36 => BaseGameDataDomain.IsModified(DataStates, 36), 
			37 => BaseGameDataDomain.IsModified(DataStates, 37), 
			38 => BaseGameDataDomain.IsModified(DataStates, 38), 
			39 => BaseGameDataDomain.IsModified(DataStates, 39), 
			40 => BaseGameDataDomain.IsModified(DataStates, 40), 
			41 => BaseGameDataDomain.IsModified(DataStates, 41), 
			42 => BaseGameDataDomain.IsModified(DataStates, 42), 
			43 => BaseGameDataDomain.IsModified(DataStates, 43), 
			_ => throw new Exception($"Unsupported dataId {dataId}"), 
		};
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		switch (influence.TargetIndicator.DataId)
		{
		case 10:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects2 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _combatCharacterDict, influencedObjects2))
				{
					int influencedObjectsCount2 = influencedObjects2.Count;
					for (int k = 0; k < influencedObjectsCount2; k++)
					{
						BaseGameDataObject targetObject2 = influencedObjects2[k];
						List<DataUid> targetUids2 = influence.TargetUids;
						int targetUidsCount2 = targetUids2.Count;
						for (int l = 0; l < targetUidsCount2; l++)
						{
							targetObject2.InvalidateSelfAndInfluencedCache((ushort)targetUids2[l].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCombatCharacterDict, _dataStatesCombatCharacterDict, influence, context);
				}
				influencedObjects2.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects2);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCombatCharacterDict, _dataStatesCombatCharacterDict, influence, context);
			}
			break;
		case 29:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects3 = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _skillDataDict, influencedObjects3))
				{
					int influencedObjectsCount3 = influencedObjects3.Count;
					for (int m = 0; m < influencedObjectsCount3; m++)
					{
						BaseGameDataObject targetObject3 = influencedObjects3[m];
						List<DataUid> targetUids3 = influence.TargetUids;
						int targetUidsCount3 = targetUids3.Count;
						for (int n = 0; n < targetUidsCount3; n++)
						{
							targetObject3.InvalidateSelfAndInfluencedCache((ushort)targetUids3[n].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSkillDataDict, _dataStatesSkillDataDict, influence, context);
				}
				influencedObjects3.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects3);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesSkillDataDict, _dataStatesSkillDataDict, influence, context);
			}
			break;
		case 30:
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _weaponDataDict, influencedObjects))
				{
					int influencedObjectsCount = influencedObjects.Count;
					for (int i = 0; i < influencedObjectsCount; i++)
					{
						BaseGameDataObject targetObject = influencedObjects[i];
						List<DataUid> targetUids = influence.TargetUids;
						int targetUidsCount = targetUids.Count;
						for (int j = 0; j < targetUidsCount; j++)
						{
							targetObject.InvalidateSelfAndInfluencedCache((ushort)targetUids[j].SubId1, context);
						}
					}
				}
				else
				{
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesWeaponDataDict, _dataStatesWeaponDataDict, influence, context);
				}
				influencedObjects.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesWeaponDataDict, _dataStatesWeaponDataDict, influence, context);
			}
			break;
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
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
			throw new Exception($"Cannot invalidate cache state of non-cache data {influence.TargetIndicator.DataId}");
		}
	}

	private void InitializeInternalDataOfCollections()
	{
		foreach (KeyValuePair<int, CombatCharacter> item in _combatCharacterDict)
		{
			CombatCharacter instance = item.Value;
			instance.CollectionHelperData = HelperDataCombatCharacterDict;
			instance.DataStatesOffset = _dataStatesCombatCharacterDict.Create();
		}
		foreach (KeyValuePair<CombatSkillKey, CombatSkillData> item2 in _skillDataDict)
		{
			CombatSkillData instance2 = item2.Value;
			instance2.CollectionHelperData = HelperDataSkillDataDict;
			instance2.DataStatesOffset = _dataStatesSkillDataDict.Create();
		}
		foreach (KeyValuePair<int, CombatWeaponData> item3 in _weaponDataDict)
		{
			CombatWeaponData instance3 = item3.Value;
			instance3.CollectionHelperData = HelperDataWeaponDataDict;
			instance3.DataStatesOffset = _dataStatesWeaponDataDict.Create();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Config;
using GameData.Combat.Animation;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat.Ai;
using GameData.Domains.Combat.MixPoison;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect;
using GameData.Domains.SpecialEffect.Cricket.Teammate;
using GameData.Domains.SpecialEffect.SectStory.Yuanshan;
using GameData.Domains.SpecialEffect.SectStory.Zhujian;
using GameData.Domains.Story.MainStory;
using GameData.Domains.TaiwuEvent;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatCharacter : BaseGameDataObject, IExpressionConverter, IAiParticipant, ICombatCharacterBridge, IImmunityMaskProvider, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint BreathValue_Offset = 4u;

		public const int BreathValue_Size = 4;

		public const uint StanceValue_Offset = 8u;

		public const int StanceValue_Size = 4;

		public const uint NeiliAllocation_Offset = 12u;

		public const int NeiliAllocation_Size = 8;

		public const uint OriginNeiliAllocation_Offset = 20u;

		public const int OriginNeiliAllocation_Size = 8;

		public const uint NeiliAllocationRecoverProgress_Offset = 28u;

		public const int NeiliAllocationRecoverProgress_Size = 8;

		public const uint OldDisorderOfQi_Offset = 36u;

		public const int OldDisorderOfQi_Size = 2;

		public const uint NeiliType_Offset = 38u;

		public const int NeiliType_Size = 1;

		public const uint AvoidToShow_Offset = 39u;

		public const int AvoidToShow_Size = 4;

		public const uint CurrentPosition_Offset = 43u;

		public const int CurrentPosition_Size = 4;

		public const uint DisplayPosition_Offset = 47u;

		public const int DisplayPosition_Size = 4;

		public const uint MobilityValue_Offset = 51u;

		public const int MobilityValue_Size = 4;

		public const uint JumpPrepareProgress_Offset = 55u;

		public const int JumpPrepareProgress_Size = 1;

		public const uint JumpPreparedDistance_Offset = 56u;

		public const int JumpPreparedDistance_Size = 2;

		public const uint MobilityLockEffectCount_Offset = 58u;

		public const int MobilityLockEffectCount_Size = 2;

		public const uint JumpChangeDistanceDuration_Offset = 60u;

		public const int JumpChangeDistanceDuration_Size = 4;

		public const uint UsingWeaponIndex_Offset = 64u;

		public const int UsingWeaponIndex_Size = 4;

		public const uint WeaponTricks_Offset = 68u;

		public const int WeaponTricks_Size = 6;

		public const uint WeaponTrickIndex_Offset = 74u;

		public const int WeaponTrickIndex_Size = 1;

		public const uint Weapons_Offset = 75u;

		public const int Weapons_Size = 56;

		public const uint AttackingTrickType_Offset = 131u;

		public const int AttackingTrickType_Size = 1;

		public const uint CanAttackOutRange_Offset = 132u;

		public const int CanAttackOutRange_Size = 1;

		public const uint ChangeTrickProgress_Offset = 133u;

		public const int ChangeTrickProgress_Size = 1;

		public const uint ChangeTrickCount_Offset = 134u;

		public const int ChangeTrickCount_Size = 2;

		public const uint CanChangeTrick_Offset = 136u;

		public const int CanChangeTrick_Size = 1;

		public const uint ChangingTrick_Offset = 137u;

		public const int ChangingTrick_Size = 1;

		public const uint ChangeTrickAttack_Offset = 138u;

		public const int ChangeTrickAttack_Size = 1;

		public const uint IsFightBack_Offset = 139u;

		public const int IsFightBack_Size = 1;

		public const uint Injuries_Offset = 140u;

		public const int Injuries_Size = 16;

		public const uint OldInjuries_Offset = 156u;

		public const int OldInjuries_Size = 16;

		public const uint DamageStepCollection_Offset = 172u;

		public const int DamageStepCollection_Size = 64;

		public const uint OuterDamageValue_Offset = 236u;

		public const int OuterDamageValue_Size = 28;

		public const uint InnerDamageValue_Offset = 264u;

		public const int InnerDamageValue_Size = 28;

		public const uint MindDamageValue_Offset = 292u;

		public const int MindDamageValue_Size = 4;

		public const uint FatalDamageValue_Offset = 296u;

		public const int FatalDamageValue_Size = 4;

		public const uint OuterDamageValueToShow_Offset = 300u;

		public const int OuterDamageValueToShow_Size = 56;

		public const uint InnerDamageValueToShow_Offset = 356u;

		public const int InnerDamageValueToShow_Size = 56;

		public const uint MindDamageValueToShow_Offset = 412u;

		public const int MindDamageValueToShow_Size = 4;

		public const uint FatalDamageValueToShow_Offset = 416u;

		public const int FatalDamageValueToShow_Size = 4;

		public const uint FlawCount_Offset = 420u;

		public const int FlawCount_Size = 7;

		public const uint AcupointCount_Offset = 427u;

		public const int AcupointCount_Size = 7;

		public const uint Poison_Offset = 434u;

		public const int Poison_Size = 24;

		public const uint OldPoison_Offset = 458u;

		public const int OldPoison_Size = 24;

		public const uint PoisonResist_Offset = 482u;

		public const int PoisonResist_Size = 24;

		public const uint NewPoisonsToShow_Offset = 506u;

		public const int NewPoisonsToShow_Size = 18;

		public const uint PreparingSkillId_Offset = 524u;

		public const int PreparingSkillId_Size = 2;

		public const uint SkillPreparePercent_Offset = 526u;

		public const int SkillPreparePercent_Size = 1;

		public const uint PerformingSkillId_Offset = 527u;

		public const int PerformingSkillId_Size = 2;

		public const uint AutoCastingSkill_Offset = 529u;

		public const int AutoCastingSkill_Size = 1;

		public const uint AttackSkillAttackIndex_Offset = 530u;

		public const int AttackSkillAttackIndex_Size = 1;

		public const uint AttackSkillPower_Offset = 531u;

		public const int AttackSkillPower_Size = 1;

		public const uint AffectingMoveSkillId_Offset = 532u;

		public const int AffectingMoveSkillId_Size = 2;

		public const uint AffectingDefendSkillId_Offset = 534u;

		public const int AffectingDefendSkillId_Size = 2;

		public const uint DefendSkillTimePercent_Offset = 536u;

		public const int DefendSkillTimePercent_Size = 1;

		public const uint WugCount_Offset = 537u;

		public const int WugCount_Size = 2;

		public const uint HealInjuryCount_Offset = 539u;

		public const int HealInjuryCount_Size = 1;

		public const uint HealPoisonCount_Offset = 540u;

		public const int HealPoisonCount_Size = 1;

		public const uint OtherActionCanUse_Offset = 541u;

		public const int OtherActionCanUse_Size = 5;

		public const uint PreparingOtherAction_Offset = 546u;

		public const int PreparingOtherAction_Size = 1;

		public const uint OtherActionPreparePercent_Offset = 547u;

		public const int OtherActionPreparePercent_Size = 1;

		public const uint CanSurrender_Offset = 548u;

		public const int CanSurrender_Size = 1;

		public const uint CanUseItem_Offset = 549u;

		public const int CanUseItem_Size = 1;

		public const uint PreparingItem_Offset = 550u;

		public const int PreparingItem_Size = 8;

		public const uint UseItemPreparePercent_Offset = 558u;

		public const int UseItemPreparePercent_Size = 1;

		public const uint XiangshuEffectId_Offset = 559u;

		public const int XiangshuEffectId_Size = 2;

		public const uint HazardValue_Offset = 561u;

		public const int HazardValue_Size = 4;

		public const uint AnimationTimeScale_Offset = 565u;

		public const int AnimationTimeScale_Size = 4;

		public const uint AttackOutOfRange_Offset = 569u;

		public const int AttackOutOfRange_Size = 1;

		public const uint BossPhase_Offset = 570u;

		public const int BossPhase_Size = 1;

		public const uint ShowTransferInjuryCommand_Offset = 571u;

		public const int ShowTransferInjuryCommand_Size = 1;

		public const uint ExecutingTeammateCommand_Offset = 572u;

		public const int ExecutingTeammateCommand_Size = 1;

		public const uint Visible_Offset = 573u;

		public const int Visible_Size = 1;

		public const uint TeammateCommandPreparePercent_Offset = 574u;

		public const int TeammateCommandPreparePercent_Size = 1;

		public const uint TeammateCommandTimePercent_Offset = 575u;

		public const int TeammateCommandTimePercent_Size = 1;

		public const uint AttackCommandWeaponKey_Offset = 576u;

		public const int AttackCommandWeaponKey_Size = 8;

		public const uint AttackCommandTrickType_Offset = 584u;

		public const int AttackCommandTrickType_Size = 1;

		public const uint DefendCommandSkillId_Offset = 585u;

		public const int DefendCommandSkillId_Size = 2;

		public const uint ShowEffectCommandIndex_Offset = 587u;

		public const int ShowEffectCommandIndex_Size = 1;

		public const uint AttackCommandSkillId_Offset = 588u;

		public const int AttackCommandSkillId_Size = 2;

		public const uint TargetDistance_Offset = 590u;

		public const int TargetDistance_Size = 2;

		public const uint NeiliAllocationCd_Offset = 592u;

		public const int NeiliAllocationCd_Size = 8;

		public const uint ProportionDelta_Offset = 600u;

		public const int ProportionDelta_Size = 8;

		public const uint NormalAttackRecovery_Offset = 608u;

		public const int NormalAttackRecovery_Size = 8;

		public const uint ReserveNormalAttack_Offset = 616u;

		public const int ReserveNormalAttack_Size = 1;

		public const uint Gangqi_Offset = 617u;

		public const int Gangqi_Size = 4;

		public const uint GangqiMax_Offset = 621u;

		public const int GangqiMax_Size = 4;

		public const uint MoveState_Offset = 625u;

		public const int MoveState_Size = 1;

		public const uint PlayerControllingMove_Offset = 626u;

		public const int PlayerControllingMove_Size = 1;

		public const uint MindRhythm_Offset = 627u;

		public const int MindRhythm_Size = 8;

		public const uint MindUpheavalTime_Offset = 635u;

		public const int MindUpheavalTime_Size = 8;
	}

	private GameData.Domains.Character.Character _character;

	private CombatDomain _combatDomain;

	public readonly CombatCharacterStateMachine StateMachine = new CombatCharacterStateMachine();

	public bool IsAlly;

	public bool IsTaiwu;

	[CollectionObjectField(false, true, false, true, false)]
	private int _id;

	public int OriginXiangshuInfection;

	public sbyte OriginNeiliType;

	[CollectionObjectField(false, true, false, false, false)]
	private short _oldDisorderOfQi;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _neiliType;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliProportionOfFiveElements _proportionDelta;

	[CollectionObjectField(false, true, false, false, false)]
	private int _breathValue;

	[CollectionObjectField(false, true, false, false, false)]
	private int _stanceValue;

	public bool LockMaxBreath = false;

	public bool LockMaxStance = false;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliAllocation _neiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliAllocation _originNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliAllocation _neiliAllocationRecoverProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private CountdownData _neiliAllocationCd;

	private NeiliAllocation _originBaseNeiliAllocation;

	public int[] NeiliAllocationAutoRecoverProgress = new int[4];

	[CollectionObjectField(false, true, false, false, false)]
	private List<int> _unlockPrepareValue;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _changeTrickProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private short _changeTrickCount;

	[CollectionObjectField(false, false, true, false, false)]
	private short _moveCd;

	[CollectionObjectField(false, true, false, false, false)]
	private int _mobilityValue;

	[CollectionObjectField(false, false, true, false, false)]
	private byte _mobilityLevel;

	[CollectionObjectField(false, false, true, false, false)]
	private int _mobilityRecoverSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _jumpPrepareProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private short _jumpPreparedDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private int _usingWeaponIndex;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 6)]
	private sbyte[] _weaponTricks;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _weaponTrickIndex;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private ItemKey[] _weapons;

	[CollectionObjectField(false, true, false, false, false)]
	private List<int> _rawCreateEffects;

	[CollectionObjectField(false, true, false, false, false)]
	private RawCreateCollection _rawCreateCollection;

	public readonly ItemKey[] Armors = new ItemKey[7];

	public readonly Stack<ItemKey> ChangingDurabilityItems = new Stack<ItemKey>();

	[CollectionObjectField(false, false, true, false, false)]
	private List<ItemKey> _validItems = new List<ItemKey>();

	[CollectionObjectField(false, false, true, false, false)]
	private List<ItemKeyAndCount> _validItemAndCounts = new List<ItemKeyAndCount>();

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _neigongList;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _attackSkillList;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _agileSkillList;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _defenceSkillList;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _assistSkillList;

	[CollectionObjectField(false, true, false, false, false)]
	private TrickCollection _tricks;

	[CollectionObjectField(false, false, true, false, false)]
	private int _maxTrickCount;

	public readonly List<sbyte> InterchangeableTricks = new List<sbyte>();

	[CollectionObjectField(false, true, false, false, false)]
	private short _wugCount;

	[CollectionObjectField(false, true, false, false, false)]
	private Injuries _injuries;

	[CollectionObjectField(false, true, false, false, false)]
	private Injuries _oldInjuries;

	[CollectionObjectField(false, true, false, false, false)]
	private InjuryAutoHealCollection _injuryAutoHealCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private InjuryAutoHealCollection _oldInjuryAutoHealCollection;

	[CollectionObjectField(false, false, true, false, false)]
	private HeavyOrBreakInjuryData _heavyOrBreakInjuryData;

	public readonly List<short> OuterInjuryAutoHealSpeeds = new List<short>();

	public readonly List<short> InnerInjuryAutoHealSpeeds = new List<short>();

	public readonly List<short> OuterOldInjuryAutoHealSpeeds = new List<short>();

	public readonly List<short> InnerOldInjuryAutoHealSpeeds = new List<short>();

	[CollectionObjectField(false, true, false, false, false)]
	private PoisonInts _poison;

	[CollectionObjectField(false, true, false, false, false)]
	private PoisonInts _oldPoison;

	[CollectionObjectField(false, true, false, false, false)]
	private PoisonInts _poisonResist;

	[CollectionObjectField(false, true, false, false, false)]
	private MixPoisonAffectedCountCollection _mixPoisonAffectedCount;

	[CollectionObjectField(false, false, true, false, false)]
	private MixPoisonAffectedCountCollection _mixPoisonCanAffectCount;

	private readonly short[] _poisonAffectAccumulator = new short[6];

	private DataUid _poisonResistUid;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private byte[] _flawCount;

	[CollectionObjectField(false, true, false, false, false)]
	private FlawOrAcupointCollection _flawCollection;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private byte[] _acupointCount;

	[CollectionObjectField(false, true, false, false, false)]
	private FlawOrAcupointCollection _acupointCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private MindMarkList _mindMarkTime;

	[CollectionObjectField(false, true, false, false, false)]
	private CountdownData _mindRhythm;

	[CollectionObjectField(false, true, false, false, false)]
	private CountdownData _mindUpheavalTime;

	private readonly List<int> _delayedMindDamage = new List<int>();

	private bool _delayedDamageAdded;

	public bool EnableScarMark;

	[CollectionObjectField(false, true, false, false, false)]
	private List<CountdownData> _scarMarkTime;

	private int _scarMarkProgress;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private int[] _outerDamageValue;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private int[] _innerDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private int _mindDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private int _fatalDamageValue;

	[CollectionObjectField(false, true, false, false, false)]
	private DamageStepCollection _damageStepCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private DefeatMarkCollection _defeatMarkCollection;

	private DataUid _defeatMarkUid;

	public bool ForceDefeat = false;

	public bool Immortal;

	[CollectionObjectField(false, true, false, false, false)]
	private int _gangqi;

	[CollectionObjectField(false, true, false, false, false)]
	private int _gangqiMax;

	public int NeedReduceWeaponDurability;

	public int NeedReduceArmorDurability;

	public bool BeCriticalDuringCalcAddInjury;

	public int BeCalcInjuryInnerRatio;

	[CollectionObjectField(false, true, false, false, false)]
	private short _targetDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private short _mobilityLockEffectCount;

	[CollectionObjectField(false, false, true, false, false)]
	private float _changeDistanceDuration;

	[CollectionObjectField(false, true, false, false, false)]
	private float _jumpChangeDistanceDuration;

	[CollectionObjectField(false, true, false, false, false)]
	private MoveState _moveState;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _playerControllingMove;

	public short AiTargetDistance;

	public short PlayerTargetDistance;

	public sbyte PlayerChangeTrickType;

	public sbyte PlayerChangeTrickBodyPart;

	public MoveData MoveData;

	public bool NeedPauseJumpMove;

	public short PauseJumpMoveSkillId;

	public int PauseJumpMoveDistance;

	[CollectionObjectField(false, true, false, false, false)]
	private CountdownData _normalAttackRecovery;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canChangeTrick;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _changingTrick;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _changeTrickAttack;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _isFightBack;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _attackingTrickType;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canAttackOutRange;

	[CollectionObjectField(false, false, true, false, false)]
	private List<bool> _canUnlockAttack = new List<bool>();

	public byte PursueAttackCount;

	public sbyte NormalAttackHitType;

	public sbyte NormalAttackBodyPart;

	public sbyte ChangeTrickType;

	public sbyte ChangeTrickBodyPart;

	public bool NeedChangeTrickAttack;

	public EFlawOrAcupointType ChangeTrickFlawOrAcupointType;

	public int UnlockWeaponIndex;

	public sbyte FightBackHitType;

	public bool FightBackWithHit;

	public sbyte FightBackSourceBodyPart;

	public bool NeedUnlockAttack;

	public bool NeedNormalAttackImmediate;

	public int NeedNormalAttackSkipPrepare;

	public int ForbidNormalAttackEffectCount;

	public bool CanNormalAttackInPrepareSkill;

	public byte NormalAttackLeftRepeatTimes;

	public bool NormalAttackRepeatIsFightBack;

	public bool NextAttackNoPrepare;

	public bool NeedFreeAttack;

	public bool IsAutoNormalAttacking;

	public bool IsAutoNormalAttackingSpecial;

	[CollectionObjectField(false, true, false, false, false)]
	private short _preparingSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _skillPreparePercent;

	[CollectionObjectField(false, true, false, false, false)]
	private short _performingSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _autoCastingSkill;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _attackSkillAttackIndex;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _attackSkillPower;

	public int SkillPrepareTotalProgress;

	public int SkillPrepareCurrProgress;

	public sbyte SkillAttackBodyPart;

	public readonly sbyte[] SkillHitType = new sbyte[3];

	public readonly int[] SkillHitValue = new int[3];

	public readonly int[] SkillAvoidValue = new int[3];

	public int SkillFinalAttackHitIndex;

	[CollectionObjectField(false, true, false, false, false)]
	private short _affectingMoveSkillId;

	public short NeedAddEffectAgileSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private short _affectingDefendSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _defendSkillTimePercent;

	public short DefendSkillTotalFrame;

	public short DefendSkillLeftFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private ShowAvoidData _avoidToShow;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private IntPair[] _outerDamageValueToShow;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 7)]
	private IntPair[] _innerDamageValueToShow;

	[CollectionObjectField(false, true, false, false, false)]
	private PoisonsAndLevels _newPoisonsToShow;

	[CollectionObjectField(false, true, false, false, false)]
	private int _mindDamageValueToShow;

	[CollectionObjectField(false, true, false, false, false)]
	private int _fatalDamageValueToShow;

	[CollectionObjectField(false, true, false, false, false)]
	private int _currentPosition;

	[CollectionObjectField(false, true, false, false, false)]
	private int _displayPosition;

	[CollectionObjectField(false, true, false, false, false)]
	private short _xiangshuEffectId;

	[CollectionObjectField(false, true, false, false, false)]
	private ShowSpecialEffectCollection _showEffectList;

	[CollectionObjectField(false, true, false, false, false)]
	private List<TeammateCommandDisplayData> _showCommandList;

	[CollectionObjectField(false, true, false, false, false)]
	private string _animationToLoop;

	[CollectionObjectField(false, true, false, false, false)]
	private string _animationToPlayOnce;

	[CollectionObjectField(false, true, false, false, false)]
	private string _particleToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _particleToLoop;

	[CollectionObjectField(false, true, false, false, false)]
	private string _particleToLoopByCombatSkill;

	[CollectionObjectField(false, true, false, false, false)]
	private string _skillPetAnimation;

	[CollectionObjectField(false, true, false, false, false)]
	private string _petParticle;

	[CollectionObjectField(false, true, false, false, false)]
	private float _animationTimeScale;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _attackOutOfRange;

	[CollectionObjectField(false, true, false, false, false)]
	private string _attackSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _skillSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _hitSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _armorHitSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _whooshSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _shockSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _stepSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _dieSoundToPlay;

	[CollectionObjectField(false, true, false, false, false)]
	private string _soundToLoop;

	[CollectionObjectField(false, false, true, false, false)]
	private SilenceData _silenceData = new SilenceData();

	public readonly List<ShowSpecialEffectDisplayData> NeedShowEffectList = new List<ShowSpecialEffectDisplayData>();

	public readonly List<TeammateCommandDisplayData> NeedShowCommandList = new List<TeammateCommandDisplayData>();

	private readonly Dictionary<CombatCharacter, List<byte>> _showedAbsorbNeiliAllocations = new Dictionary<CombatCharacter, List<byte>>();

	public string SpecialAnimationLoop;

	public bool NeedSelectMercyOption;

	public bool NeedDelaySettlement;

	public bool NeedEnterSpecialShow = false;

	public bool NeedUseGoldenWire = false;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _bossPhase;

	public bool NeedChangeBossPhase;

	public int ChangeBossPhaseEffectId;

	public bool CanCastSkillCostBreath;

	public bool CanCastSkillCostStance;

	public int PreventCastSkillEffectCount;

	public bool CanCastDirectSkill;

	public bool CanCastReverseSkill;

	public readonly List<short> CanCastDuringPrepareSkills = new List<short>();

	public readonly List<short> ForgetAfterCombatSkills = new List<short>();

	[CollectionObjectField(false, true, false, false, false)]
	private CombatReserveData _combatReserveData;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _reserveNormalAttack;

	public readonly List<CastFreeData> CastFreeDataList = new List<CastFreeData>();

	public bool NeedForceFlee;

	public bool IsForceFlee;

	[CollectionObjectField(false, true, false, false, false)]
	private CombatStateCollection _buffCombatStateCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private CombatStateCollection _debuffCombatStateCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private CombatStateCollection _specialCombatStateCollection;

	[CollectionObjectField(false, false, true, false, false)]
	private int _combatStateTotalBuffPower;

	public short BuffCombatStatePowerExtraLimit;

	public short DebuffCombatStatePowerExtraLimit;

	[CollectionObjectField(false, true, false, false, false)]
	private SkillEffectCollection _skillEffectCollection;

	public sbyte ChangeHitTypeEffectCount;

	public sbyte ChangeAvoidTypeEffectCount;

	[CollectionObjectField(false, true, false, false, false)]
	private int _hazardValue;

	public AiController AiController;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _healInjuryCount;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _healPoisonCount;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 5)]
	private bool[] _otherActionCanUse;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _preparingOtherAction;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _otherActionPreparePercent;

	[CollectionObjectField(false, false, true, false, false)]
	private EOtherActionInterruptType _preparingOtherActionInterruptType;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canSurrender;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _canUseItem;

	[CollectionObjectField(false, true, false, false, false)]
	private ItemKey _preparingItem;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _useItemPreparePercent;

	[CollectionObjectField(false, false, true, false, false)]
	private bool _useItemCostNoWisdom;

	public ItemKey UsingItem;

	public sbyte ItemUseType;

	public List<sbyte> ItemTargetBodyParts;

	public ItemKey NeedRepairItem;

	public ItemKey RepairingItem;

	public bool NeedInterruptSurrender;

	public bool NeedAnimalAttack;

	public int ChangeCharId;

	public string ChangeCharFailAni;

	public string ChangeCharFailParticle;

	public string ChangeCharFailSound;

	public readonly bool[] TeammateHasCommand = new bool[3];

	public int TeammateBeforeMainChar;

	public int TeammateAfterMainChar;

	public CombatCharacter ActingTeammateCommandChar;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _showTransferInjuryCommand;

	public int StopCommandEffectCount;

	public bool TransferInjuryCommandIsInner;

	[CollectionObjectField(false, false, true, false, false)]
	private int _teammateCommandBaseCdSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private List<sbyte> _currTeammateCommands;

	[CollectionObjectField(false, true, false, false, false)]
	private List<CountdownData> _teammateCommandCd;

	[CollectionObjectField(false, false, true, false, false)]
	private List<int> _teammateCommandCdSpeed;

	[CollectionObjectField(false, true, false, false, false)]
	private List<SByteList> _teammateCommandBanReasons;

	[CollectionObjectField(false, false, true, false, false)]
	private readonly List<bool> _teammateCommandCanUse = new List<bool>();

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _executingTeammateCommand;

	public bool NeedResetAdvanceTeammateCommandPushCd;

	public bool NeedResetAdvanceTeammateCommandPullCd;

	public long ExecutingTeammateCommandSpecialEffect;

	public int ExecutingTeammateCommandIndex;

	public int ExecutingTeammateCommandChangeDistance;

	public TeammateCommandItem ExecutingTeammateCommandConfig;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _visible;

	public short TeammateCommandLeftPrepareFrame;

	public short TeammateCommandTotalPrepareFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _teammateCommandPreparePercent;

	public short TeammateCommandLeftFrame;

	public short TeammateCommandTotalFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _teammateCommandTimePercent;

	private short _teammateExitAniLeftFrame;

	[CollectionObjectField(false, true, false, false, false)]
	private ItemKey _attackCommandWeaponKey;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _attackCommandTrickType;

	[CollectionObjectField(false, true, false, false, false)]
	private short _attackCommandSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private short _defendCommandSkillId;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _showEffectCommandIndex;

	private readonly List<ITeammateCommandInvoker> _teammateCommandInvokers = new List<ITeammateCommandInvoker>();

	public bool CanRecoverMobility;

	public sbyte AttackForceMissCount;

	public sbyte AttackForceHitCount;

	public bool SkillForceHit;

	public bool OuterInjuryImmunity;

	public bool InnerInjuryImmunity;

	public bool MindImmunity;

	public bool FlawImmunity;

	public bool AcupointImmunity;

	public bool SkipOnFrameBegin;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerShorts _attackRange;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _happiness;

	private readonly List<DataUid> _markDataUids = new List<DataUid>();

	private static readonly Dictionary<ETeammateCommandImplement, Type> TeammateCommandEffects = new Dictionary<ETeammateCommandImplement, Type>
	{
		{
			ETeammateCommandImplement.GearMateC,
			typeof(GearMateC)
		},
		{
			ETeammateCommandImplement.GearMateE,
			typeof(GearMateE)
		},
		{
			ETeammateCommandImplement.VitalDemonA,
			typeof(VitalDemonA)
		},
		{
			ETeammateCommandImplement.VitalDemonB,
			typeof(VitalDemonB)
		},
		{
			ETeammateCommandImplement.VitalDemonC,
			typeof(VitalDemonC)
		},
		{
			ETeammateCommandImplement.CriticalBonus,
			typeof(YangJian)
		},
		{
			ETeammateCommandImplement.NormalAttackAddFatal,
			typeof(HuangJia)
		},
		{
			ETeammateCommandImplement.FightBackBonus,
			typeof(YongLie)
		},
		{
			ETeammateCommandImplement.DefendFlawAndAcupoint,
			typeof(FanGe)
		},
		{
			ETeammateCommandImplement.BounceBonus,
			typeof(BaiZhan)
		},
		{
			ETeammateCommandImplement.FatalBonus,
			typeof(WangXue)
		},
		{
			ETeammateCommandImplement.RecoverAttack,
			typeof(HuanXing)
		},
		{
			ETeammateCommandImplement.NormalAttackAddMind,
			typeof(JiShi)
		},
		{
			ETeammateCommandImplement.MinorAttributeRandomToZero,
			typeof(WeiYan)
		}
	};

	public int InterruptEnemySkillReduceOdds;

	public int FightSpecialGrowBonus;

	private const int DirectCostDurability = 4;

	private const int ReverseCostDurability = 8;

	private const byte DirectCostJiTrick = 2;

	private const byte ReverseCostUsableTrick = 3;

	private readonly List<IExtraUnlockEffect> _invokedUnlockEffects = new List<IExtraUnlockEffect>();

	private readonly List<IExtraUnlockEffect> _costedUnlockEffects = new List<IExtraUnlockEffect>();

	public const int FixedSize = 643;

	public const int DynamicCount = 43;

	private static readonly ushort[] ArchiveFieldIds = new ushort[133]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
		20, 21, 22, 23, 24, 25, 26, 27, 29, 30,
		32, 33, 34, 35, 36, 37, 38, 39, 40, 41,
		43, 46, 47, 48, 49, 56, 57, 58, 59, 60,
		61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
		71, 72, 73, 74, 80, 81, 89, 90, 100, 101,
		103, 104, 105, 106, 107, 108, 109, 110, 111, 113,
		117, 118, 123, 124, 125, 126, 127, 128, 130, 131,
		28, 31, 42, 44, 45, 50, 51, 52, 53, 54,
		55, 75, 76, 77, 78, 79, 82, 83, 84, 85,
		86, 87, 88, 91, 92, 93, 94, 95, 96, 97,
		98, 99, 102, 112, 114, 115, 116, 119, 120, 121,
		122, 129, 132
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[90]
	{
		4, 4, 4, 8, 8, 8, 2, 1, 4, 4,
		4, 4, 1, 2, 2, 4, 4, 6, 1, 56,
		1, 1, 1, 2, 1, 1, 1, 1, 16, 16,
		64, 28, 28, 4, 4, 56, 56, 4, 4, 7,
		7, 24, 24, 24, 18, 2, 1, 2, 1, 1,
		1, 2, 2, 1, 2, 1, 1, 5, 1, 1,
		1, 1, 8, 1, 2, 4, 4, 1, 1, 1,
		1, 1, 1, 1, 8, 1, 2, 1, 2, 2,
		8, 8, 8, 1, 4, 4, 1, 1, 8, 8
	};

	public BossItem BossConfig { get; private set; }

	public AnimalItem AnimalConfig { get; private set; }

	public bool IsActorSkeleton => BossConfig == null && AnimalConfig == null;

	public int MaxChangeTrickCount => DomainManager.SpecialEffect.ModifyValue(_id, 300, 12);

	public bool ChangeToMindMark => DomainManager.SpecialEffect.ModifyData(_id, -1, 287, dataValue: false);

	public bool UnyieldingFallen => DomainManager.SpecialEffect.ModifyData(_id, -1, 281, dataValue: false);

	public bool IsAnimal => (IsAlly && _id == DomainManager.Combat.GetCarrierAnimalCombatCharId()) || AnimalConfig != null;

	public bool IsMoving => MoveData.MoveCd > 0;

	public bool IsJumping => NeedPauseJumpMove || (KeepMoving && (_jumpPrepareProgress > 0 || _jumpPreparedDistance > 0));

	public bool IsUnlockAttack => UnlockWeaponIndex >= 0;

	public GameData.Domains.Item.Weapon UnlockWeapon => DomainManager.Item.GetElement_Weapons(_weapons[UnlockWeaponIndex].Id);

	public int UnlockEffectId => Config.Weapon.Instance[UnlockWeapon.GetTemplateId()].UnlockEffect;

	public WeaponUnlockEffectItem UnlockEffect => WeaponUnlockEffect.Instance[UnlockEffectId];

	public short NeedUseSkillFreeId
	{
		get
		{
			int result;
			if (CastFreeDataList.Count <= 0)
			{
				result = -1;
			}
			else
			{
				List<CastFreeData> castFreeDataList = CastFreeDataList;
				result = castFreeDataList[castFreeDataList.Count - 1].SkillId;
			}
			return (short)result;
		}
	}

	public bool NeedChangeSkill => NeedUseSkillId >= 0 && (_preparingSkillId < 0 || CanCastDuringPrepareSkills.Contains(NeedUseSkillId));

	public short NeedUseSkillId => (NeedUseSkillFreeId >= 0) ? NeedUseSkillFreeId : _combatReserveData.NeedUseSkillId;

	public bool NeedShowChangeTrick => _combatReserveData.NeedShowChangeTrick && (_preparingSkillId < 0 || CanNormalAttackInPrepareSkill);

	public int NeedChangeWeaponIndex => _combatReserveData.NeedChangeWeaponIndex;

	public ItemKey NeedUseItem => _combatReserveData.NeedUseItem;

	public sbyte NeedUseOtherAction => _combatReserveData.NeedUseOtherAction;

	public ItemKey AnimalKey => _character.GetEquipment()[13];

	public int AnimalDurability => DomainManager.Item.TryGetBaseEquipment(AnimalKey)?.GetCurrDurability() ?? 0;

	public OtherActionTypeItem PreparingOtherActionTypeConfig => (_preparingOtherAction < 0) ? null : Config.OtherActionType.Instance[_preparingOtherAction];

	public ETeammateCommandImplement ExecutingTeammateCommandImplement => (_executingTeammateCommand < 0) ? ETeammateCommandImplement.Invalid : TeammateCommand.Instance[_executingTeammateCommand].Implement;

	private string DataHandlerKey => $"CombatChar_{_id}";

	bool IAiParticipant.DisableAi => ExecutingTeammateCommandConfig?.DisableAi ?? false;

	private bool InNormalWalk => DomainManager.Combat.GetCurrentDistance() <= GlobalConfig.Instance.FastWalkDistance;

	public bool NoBlockAttack => GetChangeTrickAttack() || IsUnlockAttack;

	private WeaponItem UsingWeaponConfig => Config.Weapon.Instance[_weapons[_usingWeaponIndex].TemplateId];

	private sbyte UsingWeaponAction => UsingWeaponConfig.WeaponAction;

	private string AttackPostfix => BossConfig?.AttackEffectPostfix[_usingWeaponIndex] ?? string.Empty;

	public bool AnyRawCreate => _rawCreateEffects.Count > 0;

	bool IImmunityMaskProvider.InnerInjuryImmunity => InnerInjuryImmunity;

	bool IImmunityMaskProvider.OuterInjuryImmunity => OuterInjuryImmunity;

	bool IImmunityMaskProvider.MindImmunity => MindImmunity;

	bool IImmunityMaskProvider.FlawImmunity => FlawImmunity;

	bool IImmunityMaskProvider.AcupointImmunity => AcupointImmunity;

	public ImmunityMask Immunity => ImmunityMask.From(this) + _character.GetImmunityMask();

	public MoveState MoveState => _moveState;

	public bool KeepMoving => MoveState != MoveState.Stay;

	public bool MoveForward => MoveState == MoveState.Forward;

	public bool PlayerControllingMove => GetPlayerControllingMove();

	public bool NeedNormalAttack
	{
		get
		{
			if (NeedNormalAttackSkipPrepare > 0 || NeedFreeAttack || NeedChangeTrickAttack)
			{
				return true;
			}
			if (CanNormalAttackImmediate)
			{
				return GetReserveNormalAttack() || NeedNormalAttackImmediate;
			}
			NeedNormalAttackImmediate = false;
			return false;
		}
	}

	public bool CanNormalAttackImmediate
	{
		get
		{
			if (NeedNormalAttackSkipPrepare > 0 || NeedFreeAttack || NeedChangeTrickAttack)
			{
				return false;
			}
			if (_normalAttackRecovery.On || IsJumping)
			{
				return false;
			}
			return (StateMachine.GetCurrentStateType() == CombatCharacterStateType.Idle && !PreparingOrDoingTeammateCommand()) || (_preparingSkillId >= 0 && CanNormalAttackInPrepareSkill);
		}
	}

	private int AttackSpeed => _character.GetAttackSpeed();

	private CombatCharacter MainChar => DomainManager.Combat.GetMainCharacter(IsAlly);

	private bool IsMainChar => DomainManager.Combat.IsMainCharacter(this);

	public int AddPowerUntilCastUnit { get; private set; }

	public bool AnyUsableTrick => _tricks.Tricks.Values.Any(IsTrickUsable);

	public int UsableTrickCount => _tricks.Tricks.Values.Count(IsTrickUsable);

	public int UselessTrickCount => _tricks.Tricks.Values.Count(IsTrickUseless);

	public override string ToString()
	{
		return _character.ToString();
	}

	public unsafe void Init(CombatDomain combatDomain, int characterId, DataContext context)
	{
		_id = characterId;
		_character = DomainManager.Character.GetElement_Objects(characterId);
		_combatDomain = combatDomain;
		short charTemplateId = _character.GetTemplateId();
		bool isBoss = CombatDomain.CharId2BossId.ContainsKey(charTemplateId);
		bool isAnimal = SharedConstValue.CharId2AnimalId.ContainsKey(charTemplateId);
		BossConfig = (isBoss ? Boss.Instance[CombatDomain.CharId2BossId[charTemplateId]] : null);
		_bossPhase = 0;
		ChangeBossPhaseEffectId = -1;
		AnimalConfig = (isAnimal ? Config.Animal.Instance[SharedConstValue.CharId2AnimalId[charTemplateId]] : null);
		_breathValue = 30000;
		_stanceValue = 4000;
		_oldDisorderOfQi = _character.GetDisorderOfQi();
		_neiliType = (OriginNeiliType = _character.GetNeiliType());
		_avoidToShow.HitType = -1;
		_currentPosition = (short)(combatDomain.GetCurrentDistance() / 2 * ((!IsAlly) ? 1 : (-1)));
		_displayPosition = int.MinValue;
		_mobilityValue = MoveSpecialConstants.MaxMobility;
		_mobilityLevel = 2;
		_targetDistance = -1;
		_mobilityLockEffectCount = 0;
		_jumpChangeDistanceDuration = -1f;
		_moveState = MoveState.Stay;
		_playerControllingMove = false;
		AiTargetDistance = -1;
		PlayerTargetDistance = -1;
		PlayerChangeTrickType = (PlayerChangeTrickBodyPart = -1);
		MoveData.Init(context, this);
		NeedPauseJumpMove = false;
		ItemKey[] equipments = _character.GetEquipment();
		sbyte[] weaponSlots = EquipmentSlot.EquipmentType2Slots[0];
		if (isBoss && BossConfig.PhaseWeapons != null)
		{
			short[] weaponList = BossConfig.PhaseWeapons[0];
			for (int i = 0; i < weaponSlots.Length; i++)
			{
				if (equipments[weaponSlots[i]].IsValid())
				{
					_character.ChangeEquipment(context, weaponSlots[i], -1, ItemKey.Invalid);
				}
			}
			for (int j = 0; j < weaponList.Length; j++)
			{
				ItemKey itemKey = DomainManager.Item.CreateWeapon(context, weaponList[j], 0);
				_character.AddInventoryItem(context, itemKey, 1);
				_character.ChangeEquipment(context, -1, weaponSlots[j], itemKey);
			}
		}
		for (int k = 0; k < weaponSlots.Length; k++)
		{
			ItemKey weaponKey = equipments[weaponSlots[k]];
			_weapons[k] = weaponKey;
		}
		bool allowFreeWeapon = _character.GetAllowUseFreeWeapon();
		_weapons[3] = (allowFreeWeapon ? DomainManager.Item.CreateWeapon(context, 0, 0) : ItemKey.Invalid);
		_weapons[4] = (allowFreeWeapon ? DomainManager.Item.CreateWeapon(context, 1, 0) : ItemKey.Invalid);
		_weapons[5] = (allowFreeWeapon ? DomainManager.Item.CreateWeapon(context, 2, 0) : ItemKey.Invalid);
		_weapons[6] = (allowFreeWeapon ? DomainManager.Item.CreateWeapon(context, 884, 0) : ItemKey.Invalid);
		for (sbyte i2 = 0; i2 < 7; i2++)
		{
			ItemKey armorKey = equipments[EquipmentSlotHelper.GetSlotByBodyPartType(i2)];
			Armors[i2] = ((armorKey.IsValid() && DomainManager.Item.GetElement_Armors(armorKey.Id).GetCurrDurability() > 0) ? armorKey : ItemKey.Invalid);
		}
		foreach (sbyte effectSlot in EquipmentSlot.EquipmentEffectSlots)
		{
			ItemKey equipmentKey = equipments[effectSlot];
			if (equipmentKey.IsValid())
			{
				DomainManager.SpecialEffect.AddEquipmentEffect(context, _id, equipmentKey);
				DomainManager.SpecialEffect.AddEquipmentMastery(context, _id, equipmentKey);
			}
		}
		_usingWeaponIndex = -1;
		_weaponTrickIndex = 0;
		_changeTrickProgress = 0;
		_changeTrickCount = 0;
		_canChangeTrick = false;
		_attackingTrickType = -1;
		ForbidNormalAttackEffectCount = 0;
		CanNormalAttackInPrepareSkill = false;
		NeedNormalAttackImmediate = false;
		NeedNormalAttackSkipPrepare = 0;
		NormalAttackBodyPart = -1;
		NormalAttackHitType = -1;
		PursueAttackCount = 0;
		NormalAttackLeftRepeatTimes = 0;
		ChangeTrickType = -1;
		ChangeTrickBodyPart = -1;
		NeedChangeTrickAttack = false;
		UnlockWeaponIndex = -1;
		FightBackHitType = -1;
		IsAutoNormalAttackingSpecial = false;
		NeedReduceWeaponDurability = 0;
		NeedReduceArmorDurability = 0;
		_changingTrick = false;
		_changeTrickAttack = false;
		_unlockPrepareValue.Clear();
		for (int l = 0; l < 3; l++)
		{
			_unlockPrepareValue.Add(0);
		}
		_tricks.ClearTricks();
		_maxTrickCount = 0;
		_defeatMarkCollection = new DefeatMarkCollection();
		Immortal = !Config.Character.Instance[_character.GetTemplateId()].CanDefeat;
		_defeatMarkUid = new DataUid(8, 10, (ulong)_id, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, DataHandlerKey, OnDefeatMarkChanged);
		RegisterMarkHandler();
		DomainManager.World.ApplyChallengeModeScarMark(ref EnableScarMark);
		_injuries = (_oldInjuries = _character.GetInjuries());
		_injuryAutoHealCollection = new InjuryAutoHealCollection();
		_oldInjuryAutoHealCollection = new InjuryAutoHealCollection();
		_damageStepCollection = combatDomain.GetDamageStepCollection(_id);
		DomainManager.World.ApplyChallengeModeDamageStep(_damageStepCollection, IsAlly);
		for (sbyte part = 0; part < 7; part++)
		{
			_flawCount[part] = 0;
			_acupointCount[part] = 0;
		}
		_flawCollection = new FlawOrAcupointCollection();
		_acupointCollection = new FlawOrAcupointCollection();
		_mindMarkTime = new MindMarkList();
		for (sbyte part2 = 0; part2 < 7; part2++)
		{
			_outerDamageValueToShow[part2] = new IntPair(-1, -1);
			_innerDamageValueToShow[part2] = new IntPair(-1, -1);
		}
		_mindDamageValueToShow = -1;
		_fatalDamageValueToShow = -1;
		_poison = (_oldPoison = _character.GetPoisoned());
		_poisonResist = _character.GetPoisonResists();
		Array.Clear(_poisonAffectAccumulator, 0, 6);
		_poisonResistUid = new DataUid(4, 0, (ulong)_id, 93u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_poisonResistUid, DataHandlerKey, OnPoisonResistChanged);
		_mixPoisonAffectedCount.Clear();
		_neiliAllocation = default(NeiliAllocation);
		_originNeiliAllocation = default(NeiliAllocation);
		_originBaseNeiliAllocation = default(NeiliAllocation);
		NeiliAllocation neiliAllocation = _character.GetNeiliAllocation();
		NeiliAllocation baseNeiliAllocation = _character.GetBaseNeiliAllocation();
		for (int m = 0; m < 4; m++)
		{
			_neiliAllocation.Items[m] = neiliAllocation.Items[m];
			_originNeiliAllocation.Items[m] = neiliAllocation.Items[m];
			_originBaseNeiliAllocation.Items[m] = baseNeiliAllocation.Items[m];
			_neiliAllocationRecoverProgress.Items[m] = 0;
			NeiliAllocationAutoRecoverProgress[m] = 0;
		}
		OriginXiangshuInfection = _character.GetXiangshuInfection();
		InitSkillList(0, _neigongList);
		InitSkillList(1, _attackSkillList, BossConfig);
		InitSkillList(2, _agileSkillList);
		InitSkillList(3, _defenceSkillList);
		InitSkillList(4, _assistSkillList);
		EnableEnterCombatSkillEffect(context, _neigongList);
		EnableEnterCombatSkillEffect(context, _attackSkillList);
		EnableEnterCombatSkillEffect(context, _agileSkillList);
		EnableEnterCombatSkillEffect(context, _defenceSkillList);
		EnableEnterCombatSkillEffect(context, _assistSkillList);
		CanCastSkillCostBreath = true;
		CanCastSkillCostStance = true;
		_preparingSkillId = -1;
		_skillPreparePercent = 0;
		_performingSkillId = -1;
		_attackSkillPower = 0;
		_affectingMoveSkillId = -1;
		_affectingDefendSkillId = -1;
		_defendSkillTimePercent = 0;
		CastFreeDataList.Clear();
		NeedAddEffectAgileSkillId = -1;
		DefendSkillTotalFrame = 0;
		DefendSkillLeftFrame = 0;
		PreventCastSkillEffectCount = 0;
		CanCastDirectSkill = true;
		CanCastReverseSkill = true;
		_wugCount = 0;
		CombatResources usableCombatResources = DomainManager.Character.GetUsableCombatResources(_id);
		sbyte usableHealingCount = usableCombatResources.HealingCount;
		bool allowHeal = Config.Character.Instance[_character.GetTemplateId()].AllowHeal;
		_healInjuryCount = (byte)((usableHealingCount > 0 && !isAnimal && allowHeal) ? usableHealingCount : 0);
		sbyte usableDetoxCount = usableCombatResources.DetoxCount;
		_healPoisonCount = (byte)((usableDetoxCount > 0 && !isAnimal && allowHeal) ? usableDetoxCount : 0);
		_preparingOtherAction = -1;
		_otherActionPreparePercent = 0;
		UsingItem = ItemKey.Invalid;
		_preparingItem = ItemKey.Invalid;
		_useItemPreparePercent = 0;
		BuffCombatStatePowerExtraLimit = 0;
		DebuffCombatStatePowerExtraLimit = 0;
		_xiangshuEffectId = -1;
		_hazardValue = 0;
		NeedSelectMercyOption = false;
		NeedDelaySettlement = false;
		ChangeHitTypeEffectCount = 0;
		ChangeAvoidTypeEffectCount = 0;
		SpecialAnimationLoop = null;
		_animationToLoop = null;
		_animationToPlayOnce = null;
		_particleToPlay = null;
		_skillPetAnimation = null;
		_petParticle = null;
		_animationTimeScale = 1f;
		NeedAnimalAttack = false;
		ChangeCharId = -1;
		ChangeCharFailAni = null;
		Array.Clear(TeammateHasCommand, 0, TeammateHasCommand.Length);
		TeammateBeforeMainChar = -1;
		TeammateAfterMainChar = -1;
		ActingTeammateCommandChar = null;
		_showTransferInjuryCommand = false;
		_executingTeammateCommand = -1;
		NeedResetAdvanceTeammateCommandPushCd = false;
		NeedResetAdvanceTeammateCommandPullCd = false;
		ExecutingTeammateCommandSpecialEffect = -1L;
		ExecutingTeammateCommandIndex = -1;
		ExecutingTeammateCommandChangeDistance = 0;
		ExecutingTeammateCommandConfig = null;
		_visible = false;
		TeammateCommandLeftPrepareFrame = 0;
		_teammateCommandPreparePercent = 0;
		TeammateCommandLeftFrame = -1;
		_teammateCommandTimePercent = 0;
		_teammateExitAniLeftFrame = 0;
		_attackCommandWeaponKey = ItemKey.Invalid;
		_attackingTrickType = -1;
		_attackCommandSkillId = -1;
		_defendCommandSkillId = -1;
		_showEffectCommandIndex = -1;
		CanRecoverMobility = true;
		AttackForceMissCount = 0;
		AttackForceHitCount = 0;
		SkillForceHit = false;
		OuterInjuryImmunity = false;
		InnerInjuryImmunity = false;
		MindImmunity = false;
		FlawImmunity = false;
		AcupointImmunity = false;
		_combatReserveData = CombatReserveData.Invalid;
		_reserveNormalAttack = false;
		StateMachine.Init(combatDomain, this);
		StateMachine.TranslateState(CombatCharacterStateType.Idle);
	}

	private void InitSkillList(sbyte equipType, ICollection<short> skillList, BossItem bossConfig = null)
	{
		skillList.Clear();
		if (bossConfig == null)
		{
			ArraySegmentList<short>.Enumerator enumerator = _character.GetCombatSkillEquipment()[equipType].GetEnumerator();
			while (enumerator.MoveNext())
			{
				short skillId = enumerator.Current;
				if (skillId >= 0 && _character.GetCombatSkillCanAffect(skillId))
				{
					skillList.Add(skillId);
				}
			}
		}
		else
		{
			short[] array = bossConfig.PhaseAttackSkills[0];
			foreach (short skillId2 in array)
			{
				skillList.Add(skillId2);
			}
		}
	}

	private void EnableEnterCombatSkillEffect(DataContext context, IEnumerable<short> skillListInCombat)
	{
		if (!_combatDomain.IsTeamCharacter(_id))
		{
			return;
		}
		foreach (short skillId in skillListInCombat)
		{
			DomainManager.SpecialEffect.Add(context, _id, skillId, 1, -1);
		}
	}

	public void OnFrameBegin()
	{
		DataContext context = GetDataContext();
		if (NeedAddEffectAgileSkillId >= 0)
		{
			DomainManager.SpecialEffect.Add(context, _id, NeedAddEffectAgileSkillId, 0, -1);
			NeedAddEffectAgileSkillId = -1;
		}
		if (SkipOnFrameBegin)
		{
			SkipOnFrameBegin = false;
			return;
		}
		_delayedDamageAdded = false;
		if (_showEffectList.ShowEffectList.Count > 0)
		{
			_showEffectList.ShowEffectList.Clear();
		}
		if (NeedShowEffectList.Count > 0)
		{
			_showEffectList.ShowEffectList.AddRange(NeedShowEffectList);
			NeedShowEffectList.Clear();
		}
		if (_showCommandList.Count > 0)
		{
			_showCommandList.Clear();
		}
		if (NeedShowCommandList.Count > 0)
		{
			_showCommandList.AddRange(NeedShowCommandList);
			NeedShowCommandList.Clear();
		}
		for (sbyte part = 0; part < 7; part++)
		{
			_outerDamageValueToShow[part].First = -1;
			_outerDamageValueToShow[part].Second = -1;
			_innerDamageValueToShow[part].First = -1;
			_innerDamageValueToShow[part].Second = -1;
		}
		SetOuterDamageValueToShow(_outerDamageValueToShow, context);
		SetInnerDamageValueToShow(_innerDamageValueToShow, context);
		SetMindDamageValueToShow(-1, context);
		SetFatalDamageValueToShow(-1, context);
		if (_newPoisonsToShow.IsNonZero())
		{
			_newPoisonsToShow.Initialize();
			SetNewPoisonsToShow(ref _newPoisonsToShow, context);
		}
		foreach (List<byte> types in _showedAbsorbNeiliAllocations.Values)
		{
			types.Clear();
		}
	}

	public void OnFrameEnd()
	{
		if (_showEffectList.ShowEffectList.Count > 0)
		{
			SetShowEffectList(_showEffectList, GetDataContext());
		}
		if (_showCommandList.Count > 0)
		{
			SetShowCommandList(_showCommandList, GetDataContext());
		}
	}

	public GameData.Domains.Character.Character GetCharacter()
	{
		return _character;
	}

	public void OnCombatEnd(DataContext context)
	{
		CValuePercent stayPercent = _combatDomain.CombatConfig.StayPercent;
		bool isPlayground = DomainManager.Combat.GetIsPlaygroundCombat();
		if (isPlayground)
		{
			stayPercent = 0;
		}
		bool canKeepDamage = _character.GetCreatingType() == 1 || _combatDomain.CombatConfig.AffectTemporaryCharacter || DomainManager.Taiwu.IsInGroup(_character.GetId());
		bool keepDamage = canKeepDamage && (IsAlly || !_combatDomain.CombatConfig.EnemyHealDamage);
		if (keepDamage)
		{
			for (sbyte part = 0; part < 7; part++)
			{
				(sbyte, sbyte) injury = _injuries.Get(part);
				(sbyte, sbyte) oldInjury = _oldInjuries.Get(part);
				int newOuter = injury.Item1 - oldInjury.Item1;
				int newInner = injury.Item2 - oldInjury.Item2;
				_injuries.Set(part, isInnerInjury: false, (sbyte)(oldInjury.Item1 + newOuter * stayPercent));
				_injuries.Set(part, isInnerInjury: true, (sbyte)(oldInjury.Item2 + newInner * stayPercent));
			}
		}
		else
		{
			_injuries.Initialize();
		}
		_character.SetInjuries(_injuries, context);
		if (keepDamage)
		{
			for (sbyte type = 0; type < 6; type++)
			{
				int newPoison = _poison[type] - _oldPoison[type];
				_poison[type] = Math.Clamp(_oldPoison[type] + newPoison * stayPercent, 0, 25000);
			}
		}
		else
		{
			_poison.Initialize();
		}
		_character.SetPoisoned(ref _poison, context);
		if (keepDamage)
		{
			int newQiDisorder = _character.GetDisorderOfQi() - _oldDisorderOfQi;
			int value = Math.Clamp(_oldDisorderOfQi + newQiDisorder * stayPercent, 0, DisorderLevelOfQi.MaxValue);
			_character.SetDisorderOfQi((short)value, context);
		}
		else
		{
			_character.SetDisorderOfQi(0, context);
		}
		if (canKeepDamage)
		{
			sbyte unit = GlobalConfig.Instance.ReduceHealthPerFatalDamageMark[Math.Clamp(DomainManager.Combat.GetCombatType(), 0, GlobalConfig.Instance.ReduceHealthPerFatalDamageMark.Length - 1)];
			if (isPlayground)
			{
				unit = 0;
			}
			if (IsAlly ? _combatDomain.CombatConfig.SelfFatalDamageReduceHealth : _combatDomain.CombatConfig.EnemyFatalDamageReduceHealth)
			{
				_character.ChangeHealth(context, -unit * _defeatMarkCollection.FatalDamageMarkCount);
			}
		}
		else if (!DomainManager.Combat.IsCharInLoot(_id))
		{
			_character.ClearEatingItems(context);
		}
		List<short> learnedSkills = _character.GetLearnedCombatSkills();
		for (int i = 0; i < ForgetAfterCombatSkills.Count; i++)
		{
			short skillId = ForgetAfterCombatSkills[i];
			learnedSkills.Remove(skillId);
			DomainManager.CombatSkill.RemoveCombatSkill(_id, skillId);
		}
		_character.SetLearnedCombatSkills(learnedSkills, context);
		foreach (ITeammateCommandInvoker invoker in _teammateCommandInvokers)
		{
			invoker.Close();
		}
		_teammateCommandInvokers.Clear();
		if (canKeepDamage)
		{
			NeiliAllocation extraNeiliAllocation = _character.GetExtraNeiliAllocation();
			int currNeili = _character.GetCurrNeili();
			for (int j = 0; j < 4; j++)
			{
				_neiliAllocation[j] = (short)Math.Clamp(_neiliAllocation[j] - extraNeiliAllocation[j], 0, _originBaseNeiliAllocation[j]);
			}
			_character.SpecifyBaseNeiliAllocation(context, _neiliAllocation);
			_character.SpecifyCurrNeili(context, currNeili);
			if (IsAlly && _id == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Taiwu.UpdateTaiwuNeiliAllocation(context, isInCombat: true);
			}
		}
		else
		{
			_character.SpecifyBaseNeiliAllocation(context, _originBaseNeiliAllocation);
		}
		AiController?.UnInit();
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_poisonResistUid, DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, DataHandlerKey);
		UnRegisterMarkHandler();
		if (IsTaiwu && DomainManager.Combat.AiOptions.SaveMoveTarget)
		{
			DomainManager.Combat.SetLastTargetDistance(PlayerTargetDistance, context);
		}
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		argBox.Set("IsGuardCombat", arg: false);
	}

	public void RemoveTempWeapons(DataContext context)
	{
		DomainManager.Item.RemoveItem(context, _weapons[3]);
		DomainManager.Item.RemoveItem(context, _weapons[4]);
		DomainManager.Item.RemoveItem(context, _weapons[5]);
		DomainManager.Item.RemoveItem(context, _weapons[6]);
	}

	public DataContext GetDataContext()
	{
		return _combatDomain.Context;
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 16, 18, 56, 58, 26, 44 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCombatCharsInCombat)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 145, 146, 272 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private OuterAndInnerShorts CalcAttackRange()
	{
		return CalcAttackRangeImmediate(-1);
	}

	[ObjectCollectionDependency(17, 2, new ushort[] { 52 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private sbyte CalcHappiness()
	{
		int happiness = _character.GetHappiness();
		happiness += DomainManager.SpecialEffect.GetModifyValue(_id, 52, EDataModifyType.Add);
		happiness = Math.Clamp(happiness, -119, 119);
		return (sbyte)happiness;
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 135, 15 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 85 }, Scope = InfluenceScope.CombatCharOfTheChar)]
	private float CalcChangeDistanceDuration()
	{
		if (GetJumpChangeDistanceDuration() >= 0f)
		{
			return GetJumpChangeDistanceDuration();
		}
		short mobilityMoveCd = GetMoveCd();
		return (float)mobilityMoveCd / 60f;
	}

	[SingleValueCollectionDependency(4, new ushort[] { 11 }, Scope = InfluenceScope.AllCombatCharsInCombat)]
	private int CalcTeammateCommandBaseCdSpeed()
	{
		short favor = DomainManager.Character.GetFavorability(_id, _combatDomain.GetMainCharacter(IsAlly).GetId());
		sbyte favorType = FavorabilityType.GetFavorabilityType(favor);
		return (favorType >= 5) ? 100 : ((favorType >= 3) ? 85 : ((favorType >= 1) ? 70 : ((favorType >= 0) ? 55 : ((favorType >= -2) ? 40 : ((favorType >= -4) ? 25 : 10)))));
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 149 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 183 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private void CalcTeammateCommandCdSpeed(List<int> teammateCommandCdSpeed)
	{
		teammateCommandCdSpeed.Clear();
		int baseCdSpeed = GetTeammateCommandBaseCdSpeed();
		int mainCharId = _combatDomain.GetMainCharacter(IsAlly).GetId();
		for (int i = 0; i < _currTeammateCommands.Count; i++)
		{
			sbyte cmdType = _currTeammateCommands[i];
			if (_showTransferInjuryCommand)
			{
				cmdType = (sbyte)((i == 0) ? 13 : (-1));
			}
			if (cmdType < 0)
			{
				teammateCommandCdSpeed.Add(0);
				continue;
			}
			ETeammateCommandImplement implement = TeammateCommand.Instance[cmdType].Implement;
			int cdSpeed = DomainManager.SpecialEffect.ModifyValue(mainCharId, 183, baseCdSpeed, (int)implement);
			teammateCommandCdSpeed.Add(cdSpeed);
		}
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 112 }, Scope = InfluenceScope.Self)]
	private void CalcTeammateCommandCanUse(List<bool> teammateCommandCanUse)
	{
		for (int i = 0; i < _teammateCommandBanReasons.Count; i++)
		{
			teammateCommandCanUse[i] = _teammateCommandBanReasons[i].Items.Count == 0;
		}
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 11 }, Scope = InfluenceScope.Self)]
	private byte CalcMobilityLevel()
	{
		return CFormula.CalcMobilityLevel(_mobilityValue);
	}

	[ObjectCollectionDependency(8, 29, new ushort[] { 2, 3 }, Scope = InfluenceScope.CombatCharOfTheCombatSkillData)]
	[ObjectCollectionDependency(8, 30, new ushort[] { 7, 8 }, Scope = InfluenceScope.CombatCharOfTheCombatWeaponData)]
	private void CalcSilenceData(SilenceData silenceData)
	{
		SilenceData silenceData2 = silenceData;
		if (silenceData2.CombatSkill == null)
		{
			silenceData2.CombatSkill = new Dictionary<short, CountdownData>();
		}
		silenceData.CombatSkill.Clear();
		foreach (CombatSkillKey key in GetCombatSkillKeys())
		{
			if (DomainManager.Combat.TryGetCombatSkillData(_id, key.SkillTemplateId, out var skillData) && skillData.GetLeftCdFrame() != 0)
			{
				CountdownData frameData = CountdownData.Create(skillData.GetTotalCdFrame(), skillData.GetLeftCdFrame());
				silenceData.CombatSkill[key.SkillTemplateId] = frameData;
			}
		}
		silenceData2 = silenceData;
		if (silenceData2.WeaponKeys == null)
		{
			silenceData2.WeaponKeys = new List<ItemKey>();
		}
		silenceData.WeaponKeys.Clear();
		silenceData2 = silenceData;
		if (silenceData2.WeaponFrames == null)
		{
			silenceData2.WeaponFrames = new List<CountdownData>();
		}
		silenceData.WeaponFrames.Clear();
		ItemKey[] weapons = _weapons;
		for (int i = 0; i < weapons.Length; i++)
		{
			ItemKey itemKey = weapons[i];
			if (DomainManager.Combat.TryGetElement_WeaponDataDict(itemKey.Id, out var weaponData) && weaponData.GetFixedCdLeftFrame() != 0)
			{
				CountdownData frameData2 = CountdownData.Create(weaponData.GetFixedCdTotalFrame(), weaponData.GetFixedCdLeftFrame());
				silenceData.WeaponKeys.Add(itemKey);
				silenceData.WeaponFrames.Add(frameData2);
			}
		}
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 76, 77 }, Scope = InfluenceScope.Self)]
	private int CalcCombatStateTotalBuffPower()
	{
		int buffPower = _buffCombatStateCollection.StateDict.Values.Select(PowerSelector).Sum();
		int debuffPower = _debuffCombatStateCollection.StateDict.Values.Select(PowerSelector).Sum();
		return buffPower - debuffPower;
	}

	private static int PowerSelector((short power, bool reverse, int srcCharId) tuple)
	{
		return tuple.power;
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 29 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 168, 169 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private HeavyOrBreakInjuryData CalcHeavyOrBreakInjuryData()
	{
		HeavyOrBreakInjuryData result = default(HeavyOrBreakInjuryData);
		result.Initialize();
		for (sbyte i = 0; i < 7; i++)
		{
			if (HasBreakInjury(i))
			{
				result[i] = EHeavyOrBreakType.Break;
			}
			else if (HasHeavyInjury(i))
			{
				result[i] = EHeavyOrBreakType.Heavy;
			}
		}
		return result;
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 44, 62 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(4, 0, new ushort[] { 85 }, Scope = InfluenceScope.CombatCharOfTheChar)]
	private short CalcMoveCd()
	{
		short moveSpeed = _character.GetMoveSpeed();
		int moveCd = CFormula.CalcMoveCd(moveSpeed);
		if (_affectingMoveSkillId >= 0)
		{
			moveCd *= (CValuePercentBonus)Config.CombatSkill.Instance[_affectingMoveSkillId].MoveCdBonus;
		}
		int acupointAddPercent = _acupointCollection.CalcAcupointParam(5) + _acupointCollection.CalcAcupointParam(6);
		moveCd += moveCd * acupointAddPercent / 100;
		return (short)moveCd;
	}

	[ObjectCollectionDependency(17, 2, new ushort[] { 197 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private int CalcMobilityRecoverSpeed()
	{
		return DomainManager.SpecialEffect.ModifyValue(_id, 197, MoveSpecialConstants.MobilityRecoverSpeed);
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 120 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(8, new ushort[] { 4 }, Scope = InfluenceScope.AllCombatCharsInCombat)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 145, 146, 272 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private void CalcCanUnlockAttack(List<bool> canUnlockAttack)
	{
		int needUnlockAttackWeaponIndex = _combatReserveData.NeedUnlockWeaponIndex;
		canUnlockAttack.Clear();
		for (int i = 0; i < _unlockPrepareValue.Count; i++)
		{
			canUnlockAttack.Add(CalcCanUnlockAttackByWeaponIndex(i));
			if (needUnlockAttackWeaponIndex == i && !canUnlockAttack[i])
			{
				SetCombatReserveData(CombatReserveData.Invalid, _combatDomain.Context);
			}
		}
	}

	private bool CalcCanUnlockAttackByWeaponIndex(int weaponIndex)
	{
		if (!_weapons[weaponIndex].IsValid())
		{
			return false;
		}
		if (_unlockPrepareValue[weaponIndex] < GlobalConfig.Instance.UnlockAttackUnit)
		{
			return false;
		}
		WeaponUnlockEffectItem config = GetUnlockEffect(weaponIndex);
		if (config == null)
		{
			return false;
		}
		if (config.IgnoreAttackRange)
		{
			return true;
		}
		CalcAttackRangeImmediate(-1, weaponIndex).Deconstruct(out var outer, out var inner);
		short min = outer;
		short max = inner;
		short currentDistance = DomainManager.Combat.GetCurrentDistance();
		return min <= currentDistance && currentDistance <= max;
	}

	[ObjectCollectionDependency(17, 2, new ushort[] { 170 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private int CalcMaxTrickCount()
	{
		int maxTrickCount = 9;
		maxTrickCount = DomainManager.SpecialEffect.ModifyData(_id, -1, 170, maxTrickCount);
		return Math.Max(maxTrickCount, 0);
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 147 }, Scope = InfluenceScope.Self)]
	private void CalcValidItems(List<ItemKey> validItems)
	{
		validItems.Clear();
		foreach (ItemKeyAndCount validItemAndCount in GetValidItemAndCounts())
		{
			validItems.Add(validItemAndCount.ItemKey);
		}
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 57 }, Scope = InfluenceScope.CombatCharOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 323 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private void CalcValidItemAndCounts(List<ItemKeyAndCount> validItemAndCounts)
	{
		validItemAndCounts.Clear();
		if (IsAlly)
		{
			validItemAndCounts.Add(DomainManager.Extra.GetEmptyToolKey(DomainManager.Combat.Context));
		}
		foreach (var (itemKey2, count) in _character.GetInventory().Items)
		{
			if (ItemIsValid(itemKey2))
			{
				validItemAndCounts.Add(new ItemKeyAndCount(itemKey2, count));
			}
		}
		DomainManager.SpecialEffect.ModifyData(_id, -1, 323, validItemAndCounts);
	}

	private bool ItemIsValid(ItemKey itemKey)
	{
		if (itemKey.GetConsumedFeatureMedals() < 0)
		{
			return false;
		}
		if (itemKey.ItemType == 5)
		{
			return DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(54);
		}
		if (itemKey.ItemType != 12)
		{
			return true;
		}
		MiscItem config = Config.Misc.Instance[itemKey.TemplateId];
		List<short> requireCombatConfig = config.RequireCombatConfig;
		return requireCombatConfig == null || requireCombatConfig.Count <= 0 || config.RequireCombatConfig.Contains(DomainManager.Combat.CombatConfig.TemplateId);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 97 }, Scope = InfluenceScope.CombatCharOfTheChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 329 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private bool CalcUseItemCostNoWisdom()
	{
		return DomainManager.SpecialEffect.ModifyData(_id, -1, 329, dataValue: false);
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 69, 70, 73, 74 }, Scope = InfluenceScope.Self)]
	private EOtherActionInterruptType CalcPreparingOtherActionInterruptType()
	{
		if (_preparingOtherAction == 4)
		{
			return EOtherActionInterruptType.Allow;
		}
		if (IsForceFlee)
		{
			return EOtherActionInterruptType.ForceFlee;
		}
		bool allow = false;
		if (_preparingItem.IsValid())
		{
			allow = _useItemPreparePercent < 100;
		}
		else if (_preparingOtherAction >= 0)
		{
			allow = _otherActionPreparePercent < 100;
		}
		return (!allow) ? EOtherActionInterruptType.HideClose : EOtherActionInterruptType.Allow;
	}

	[ObjectCollectionDependency(8, 10, new ushort[] { 50 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 343 }, Scope = InfluenceScope.CombatCharacterAffectedByTheSpecialEffects)]
	private void CalcMixPoisonCanAffectCount(MixPoisonAffectedCountCollection mixPoisonCanAffectedCount)
	{
		mixPoisonCanAffectedCount.Clear();
		byte[] poisonMarkList = _defeatMarkCollection.PoisonMarkList;
		if (poisonMarkList.CountAll((byte count) => count > 0) < 3)
		{
			return;
		}
		List<sbyte> typeList = ObjectPool<List<sbyte>>.Instance.Get();
		typeList.Clear();
		for (sbyte type = 0; type < 6; type++)
		{
			if (poisonMarkList[type] > 0)
			{
				typeList.Add(type);
			}
		}
		foreach (MixPoisonEffectItem effect in (IEnumerable<MixPoisonEffectItem>)MixPoisonEffect.Instance)
		{
			if (!effect.HasPoisonTypes.Any((sbyte item) => !typeList.Contains(item)))
			{
				int totalMarkCount = effect.HasPoisonTypes.Sum((sbyte x) => poisonMarkList[x]);
				int canAffectCount = CFormula.CalcMixPoisonAffectCount(totalMarkCount);
				canAffectCount = DomainManager.SpecialEffect.ModifyValue(_id, 343, canAffectCount);
				if (canAffectCount > 0)
				{
					mixPoisonCanAffectedCount.SetAffectedCount(effect.TemplateId, canAffectCount);
				}
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(typeList);
	}

	private static bool SkillIdIsValid(short skillId)
	{
		return skillId >= 0;
	}

	public void SyncPoisonData(DataContext context)
	{
		_character.SetPoisoned(ref _poison, context);
	}

	public IEnumerable<short> GetCombatSkillIds()
	{
		IEnumerable<short> combatSkillIds = Enumerable.Empty<short>();
		if (_neigongList != null)
		{
			combatSkillIds = combatSkillIds.Concat(_neigongList.Where(SkillIdIsValid));
		}
		if (_attackSkillList != null)
		{
			combatSkillIds = combatSkillIds.Concat(_attackSkillList.Where(SkillIdIsValid));
		}
		if (_agileSkillList != null)
		{
			combatSkillIds = combatSkillIds.Concat(_agileSkillList.Where(SkillIdIsValid));
		}
		if (_defenceSkillList != null)
		{
			combatSkillIds = combatSkillIds.Concat(_defenceSkillList.Where(SkillIdIsValid));
		}
		if (_assistSkillList != null)
		{
			combatSkillIds = combatSkillIds.Concat(_assistSkillList.Where(SkillIdIsValid));
		}
		return combatSkillIds;
	}

	public IEnumerable<CombatSkillKey> GetCombatSkillKeys()
	{
		return GetCombatSkillIds().Select((Func<short, CombatSkillKey>)((short skillId) => (charId: _id, skillId: skillId)));
	}

	public IEnumerable<short> GetBannedSkillIds(bool requireNotInfinity = false)
	{
		foreach (CombatSkillKey key in GetCombatSkillKeys())
		{
			if (DomainManager.Combat.TryGetCombatSkillData(key.CharId, key.SkillTemplateId, out var data) && (!requireNotInfinity || data.GetLeftCdFrame() >= 0))
			{
				if (data.GetLeftCdFrame() != 0)
				{
					yield return key.SkillTemplateId;
				}
				data = null;
			}
		}
	}

	public IEnumerable<short> GetBanableSkillIds(sbyte specifyEquipType = -1, sbyte expectEquipType = -1)
	{
		foreach (CombatSkillKey key in GetCombatSkillKeys())
		{
			sbyte configEquipType = Config.CombatSkill.Instance[key.SkillTemplateId].EquipType;
			if (configEquipType != 0 && (specifyEquipType < 0 || configEquipType == specifyEquipType) && (expectEquipType < 0 || configEquipType != expectEquipType) && DomainManager.Combat.TryGetCombatSkillData(key.CharId, key.SkillTemplateId, out var data) && data.GetLeftCdFrame() >= 0)
			{
				yield return key.SkillTemplateId;
				data = null;
			}
		}
	}

	public short GetRandomBanableSkillId(IRandomSource random, Func<short, bool> predicate = null, sbyte specifyEquipType = -1)
	{
		using (IEnumerator<short> enumerator = GetRandomUnrepeatedBanableSkillIds(random, 1, predicate, specifyEquipType, -1).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return -1;
	}

	public IEnumerable<short> GetRandomUnrepeatedBanableSkillIds(IRandomSource random, int maxCount, Func<short, bool> predicate = null, sbyte specifyEquipType = -1, sbyte expectEquipType = -1)
	{
		if (maxCount <= 0)
		{
			yield break;
		}
		List<short> prefer = ObjectPool<List<short>>.Instance.Get();
		List<short> normal = ObjectPool<List<short>>.Instance.Get();
		prefer.Clear();
		normal.Clear();
		foreach (short skillId in from arg in GetBanableSkillIds(specifyEquipType, expectEquipType)
			where predicate == null || predicate(arg)
			select arg)
		{
			CombatSkillData data = DomainManager.Combat.GetCombatSkillData(_id, skillId);
			if (data.GetLeftCdFrame() == 0)
			{
				prefer.Add(skillId);
			}
			else
			{
				normal.Add(skillId);
			}
		}
		foreach (short item in RandomUtils.GetRandomUnrepeated(random, maxCount, prefer, normal))
		{
			yield return item;
		}
		ObjectPool<List<short>>.Instance.Return(prefer);
		ObjectPool<List<short>>.Instance.Return(normal);
	}

	public IReadOnlyList<short> GetCombatSkillList(sbyte equipType)
	{
		if (1 == 0)
		{
		}
		List<short> result = equipType switch
		{
			0 => _neigongList, 
			1 => _attackSkillList, 
			2 => _agileSkillList, 
			3 => _defenceSkillList, 
			4 => _assistSkillList, 
			_ => throw new Exception($"Invalid skill equip type {equipType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public sbyte RandomAvailableBodyPart(IRandomSource random)
	{
		List<sbyte> bodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		bodyParts.ClearAndAddRange(GetAvailableBodyParts());
		sbyte result = (sbyte)((bodyParts.Count > 0) ? bodyParts.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(bodyParts);
		return result;
	}

	public IEnumerable<sbyte> GetAvailableBodyParts()
	{
		for (sbyte i = 0; i < 7; i++)
		{
			if (ContainsBodyPart(i))
			{
				yield return i;
			}
		}
	}

	public bool ContainsBodyPart(sbyte bodyPart)
	{
		if (1 == 0)
		{
		}
		bool result = bodyPart >= 0 && bodyPart switch
		{
			3 => _character.GetHaveLeftArm(), 
			4 => _character.GetHaveRightArm(), 
			5 => _character.GetHaveLeftLeg(), 
			6 => _character.GetHaveRightLeg(), 
			_ => true, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public int GetMaxBreathValue()
	{
		int maxValue = 30000;
		int percent = 100;
		percent = DomainManager.SpecialEffect.ModifyData(_id, -1, 171, percent);
		return maxValue * percent / 100;
	}

	public int GetMaxStanceValue()
	{
		int maxValue = 4000;
		int percent = 100;
		percent = DomainManager.SpecialEffect.ModifyData(_id, -1, 172, percent);
		return maxValue * percent / 100;
	}

	public int CalcBreathRecoverValue(int value)
	{
		value = DomainManager.SpecialEffect.ModifyValue(_id, 195, value);
		int acupointReduce = _acupointCollection.CalcAcupointParam(0);
		value = value * (100 - acupointReduce) / 100;
		return value;
	}

	public int CalcStanceRecoverValue(int value)
	{
		value = DomainManager.SpecialEffect.ModifyValue(_id, 196, value);
		int acupointReduce = _acupointCollection.CalcAcupointParam(1);
		value = value * (100 - acupointReduce) / 100;
		return value;
	}

	public int GetMaxMobility()
	{
		int maxValue = MoveSpecialConstants.MaxMobility;
		int percent = 100;
		percent = DomainManager.SpecialEffect.ModifyData(_id, -1, 273, percent);
		return maxValue * percent / 100;
	}

	public void CalcCostTrickStatus(List<NeedTrick> costTricks, Dictionary<sbyte, byte> costTrickDict, Dictionary<sbyte, byte> lackTrickDict)
	{
		costTrickDict.Clear();
		lackTrickDict.Clear();
		byte value;
		foreach (NeedTrick needTrick in costTricks)
		{
			sbyte trickType = needTrick.TrickType;
			value = (costTrickDict[needTrick.TrickType] = needTrick.NeedCount);
			lackTrickDict[trickType] = value;
		}
		TrickCollection hasTricks = GetTricks();
		sbyte key2;
		foreach (KeyValuePair<int, sbyte> trick in hasTricks.Tricks)
		{
			trick.Deconstruct(out var _, out key2);
			sbyte trickType2 = key2;
			if (lackTrickDict.TryGetValue(trickType2, out var lackCount) && lackCount > 0)
			{
				lackTrickDict[trickType2] = (byte)(lackCount - 1);
			}
		}
		List<sbyte> enoughTrickTypes = ObjectPool<List<sbyte>>.Instance.Get();
		enoughTrickTypes.Clear();
		foreach (KeyValuePair<sbyte, byte> item in lackTrickDict)
		{
			item.Deconstruct(out key2, out value);
			sbyte trickType3 = key2;
			if (value == 0)
			{
				enoughTrickTypes.Add(trickType3);
			}
		}
		foreach (sbyte enoughTrickType in enoughTrickTypes)
		{
			lackTrickDict.Remove(enoughTrickType);
		}
		ObjectPool<List<sbyte>>.Instance.Return(enoughTrickTypes);
	}

	public void CalcInsteadTricks(Dictionary<sbyte, byte> insteadTrickDict, Func<sbyte, bool> insteadPredicate, Dictionary<sbyte, byte> costTrickDict, Dictionary<sbyte, byte> lackTrickDict, int maxInsteadCount = int.MaxValue, bool onlyInsteadLack = false)
	{
		insteadTrickDict.Clear();
		foreach (sbyte trickType in GetTricks().Tricks.Values)
		{
			if (!insteadPredicate(trickType))
			{
				continue;
			}
			if (costTrickDict.Count == 0 || (onlyInsteadLack && lackTrickDict.Count == 0) || maxInsteadCount <= 0)
			{
				break;
			}
			insteadTrickDict[trickType] = (byte)Math.Clamp(insteadTrickDict.GetOrDefault(trickType) + 1, 0, 255);
			sbyte needTrickType = ((lackTrickDict.Count > 0) ? lackTrickDict.First().Key : costTrickDict.First().Key);
			if (lackTrickDict.TryGetValue(needTrickType, out var lackCount))
			{
				if (lackCount <= 1)
				{
					lackTrickDict.Remove(needTrickType);
				}
				else
				{
					lackTrickDict[needTrickType] = (byte)(lackCount - 1);
				}
			}
			Tester.Assert(costTrickDict[needTrickType] > 0);
			costTrickDict[needTrickType]--;
			if (costTrickDict[needTrickType] == 0)
			{
				costTrickDict.Remove(needTrickType);
			}
			maxInsteadCount--;
		}
	}

	public short GetAttackSpeedPercent()
	{
		return _character.GetAttackSpeed();
	}

	public short GetSkillPrepareSpeed()
	{
		return _character.GetCastSpeed();
	}

	public bool ChangeWugCount(DataContext context, int delta)
	{
		short prev = GetWugCount();
		short curr = (short)Math.Clamp(prev + delta, 0, GlobalConfig.Instance.MaxWugCount);
		if (curr != prev)
		{
			SetWugCount(curr, context);
		}
		return curr - prev != 0;
	}

	public void ChangeToProportion(DataContext context, sbyte fiveElementsType, int maxChangeValue)
	{
		NeiliProportionOfFiveElements currentProportion = _character.GetNeiliProportionOfFiveElements();
		int existValue = currentProportion[fiveElementsType];
		int changeable = 100 - existValue;
		if (maxChangeValue == 0 || (maxChangeValue < 0 && existValue == 0) || (maxChangeValue > 0 && changeable == 0))
		{
			return;
		}
		maxChangeValue = Math.Min(maxChangeValue, changeable);
		NeiliProportionOfFiveElements delta = _proportionDelta;
		int totalChangeValue = 0;
		for (int i = 0; i < 5; i++)
		{
			if (i != fiveElementsType)
			{
				CValuePercent percent = CValuePercent.Parse(currentProportion[i], changeable);
				int changeValue = maxChangeValue * percent;
				if (changeValue != 0)
				{
					totalChangeValue += changeValue;
					delta[i] = (sbyte)(delta[i] - changeValue);
				}
			}
		}
		delta[fiveElementsType] = (sbyte)(delta[fiveElementsType] + totalChangeValue);
		SetProportionDelta(delta, context);
		sbyte newNeiliType = _character.GetNeiliType();
		if (newNeiliType != _neiliType)
		{
			SetNeiliType(newNeiliType, context);
		}
	}

	public void SilenceNeiliAllocationAutoRecover(DataContext context, int cdFrame)
	{
		if (_neiliAllocationCd.Cover(cdFrame))
		{
			SetNeiliAllocationCd(_neiliAllocationCd, context);
		}
	}

	public bool TickNeiliAllocationCd(DataContext context)
	{
		if (_neiliAllocationCd.Tick())
		{
			SetNeiliAllocationCd(_neiliAllocationCd, context);
		}
		return _neiliAllocationCd.On;
	}

	public bool AnyLowerThanOriginNeiliAllocation()
	{
		for (byte i = 0; i < 4; i++)
		{
			if (_neiliAllocation[i] < _originNeiliAllocation[i])
			{
				return true;
			}
		}
		return false;
	}

	public short GetMaxNeiliAllocation(byte type)
	{
		return (short)(GetOriginNeiliAllocation()[type] * 3);
	}

	public int ApplySpecialEffectToNeiliAllocation(byte type, int addValue)
	{
		if (addValue == 0)
		{
			return 0;
		}
		bool isAdd = addValue > 0;
		if (isAdd)
		{
			float percent = 100 + DomainManager.SpecialEffect.GetModifyValue(_id, 135, EDataModifyType.AddPercent, type);
			percent += (float)this.GetAddNeiliAllocationAddPercent(type);
			(int, int) totalPercent = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id, -1, 135, type);
			addValue = (int)Math.Floor((float)addValue * percent / 100f);
			addValue = (int)Math.Floor((float)addValue * (100f + (float)totalPercent.Item1 + (float)totalPercent.Item2) / 100f);
			addValue = DomainManager.SpecialEffect.ModifyData(_id, -1, 135, addValue);
		}
		else
		{
			float percent2 = 100 + DomainManager.SpecialEffect.GetModifyValue(_id, 136, EDataModifyType.AddPercent, type);
			percent2 += (float)this.GetCostNeiliAllocationAddPercent(type);
			(int, int) totalPercent2 = DomainManager.SpecialEffect.GetTotalPercentModifyValue(_id, -1, 136, type);
			addValue = (int)Math.Ceiling((float)addValue * percent2 / 100f);
			addValue = (int)Math.Ceiling((float)addValue * (100f + (float)totalPercent2.Item1 + (float)totalPercent2.Item2) / 100f);
			addValue = DomainManager.SpecialEffect.ModifyData(_id, -1, 136, addValue);
		}
		if (addValue != 0)
		{
			isAdd = addValue > 0;
		}
		addValue = (isAdd ? Math.Max(addValue, 1) : Math.Min(addValue, -1));
		return addValue;
	}

	public bool ChangeNeiliAllocationRandom(DataContext context, int addValue, int count, bool applySpecialEffect = true)
	{
		bool changed = false;
		for (int i = 0; i < count; i++)
		{
			changed = ChangeNeiliAllocationRandom(context, addValue, applySpecialEffect) || changed;
		}
		return changed;
	}

	public bool ChangeNeiliAllocationRandom(DataContext context, int addValue, bool applySpecialEffect = true)
	{
		if (addValue == 0)
		{
			return false;
		}
		bool isAdd = addValue > 0;
		List<byte> neiliAllocationTypes = ObjectPool<List<byte>>.Instance.Get();
		neiliAllocationTypes.Clear();
		for (byte i = 0; i < 4; i++)
		{
			if (!(isAdd ? (_originNeiliAllocation[i] <= 0) : (_neiliAllocation[i] <= 0)))
			{
				neiliAllocationTypes.Add(i);
			}
		}
		bool changed = neiliAllocationTypes.Count > 0;
		if (changed)
		{
			ChangeNeiliAllocation(context, neiliAllocationTypes.GetRandom(context.Random), addValue, applySpecialEffect);
		}
		ObjectPool<List<byte>>.Instance.Return(neiliAllocationTypes);
		return changed;
	}

	public int ChangeNeiliAllocation(DataContext context, byte type, int addValue, bool applySpecialEffect = true, bool raiseEvent = true, bool applyChallengeModeQiDisorder = true)
	{
		if (applySpecialEffect)
		{
			addValue = ApplySpecialEffectToNeiliAllocation(type, addValue);
			if (addValue == 0)
			{
				return 0;
			}
			if (!DomainManager.SpecialEffect.ModifyData(_id, -1, 137, dataValue: true, (addValue <= 0) ? 1 : 0))
			{
				return 0;
			}
		}
		short currValue = _neiliAllocation[type];
		short newValue = (short)MathUtils.Clamp(currValue + addValue, 0, _combatDomain.GetMaxNeiliAllocation(this, type));
		int changeValue = newValue - currValue;
		_neiliAllocation[type] = newValue;
		SetNeiliAllocation(_neiliAllocation, context);
		UpdateNeiliAllocationMark(context);
		_combatDomain.UpdateTeammateCommandUsable(context, this, _combatDomain.IsMainCharacter(this) ? ETeammateCommandImplement.ReduceNeiliAllocation : ETeammateCommandImplement.TransferNeiliAllocation);
		_combatDomain.UpdateAllTeammateCommandUsable(context, !IsAlly, ETeammateCommandImplement.AbsorbNeiliAllocation);
		if (raiseEvent)
		{
			Events.RaiseNeiliAllocationChanged(context, _id, type, changeValue);
		}
		if (applyChallengeModeQiDisorder)
		{
			DomainManager.World.ApplyChallengeModeQiDisorder(context, this, changeValue);
		}
		return changeValue;
	}

	public void ChangeAllNeiliAllocation(DataContext context, int addPercent, bool raiseEvent = true, bool applyChallengeModeQiDisorder = true)
	{
		for (byte type = 0; type < 4; type++)
		{
			short currValue = _neiliAllocation[type];
			short newValue = (short)MathUtils.Clamp(currValue + currValue * addPercent / 100, 0, _combatDomain.GetMaxNeiliAllocation(this, type));
			int changeValue = newValue - currValue;
			_neiliAllocation[type] = newValue;
			if (!_combatDomain.IsMainCharacter(this))
			{
				_combatDomain.UpdateTeammateCommandUsable(context, this, ETeammateCommandImplement.TransferNeiliAllocation);
			}
			_combatDomain.UpdateAllTeammateCommandUsable(context, !IsAlly, ETeammateCommandImplement.AbsorbNeiliAllocation);
			if (raiseEvent)
			{
				Events.RaiseNeiliAllocationChanged(context, _id, type, changeValue);
			}
			if (applyChallengeModeQiDisorder)
			{
				DomainManager.World.ApplyChallengeModeQiDisorder(context, this, changeValue);
			}
		}
		SetNeiliAllocation(_neiliAllocation, context);
		UpdateNeiliAllocationMark(context);
	}

	private byte RandomAbsorbNeiliAllocationType(IRandomSource random, CombatCharacter target)
	{
		List<byte> prefer = ObjectPool<List<byte>>.Instance.Get();
		List<byte> normal = ObjectPool<List<byte>>.Instance.Get();
		for (byte i = 0; i < 4; i++)
		{
			if (target._neiliAllocation[i] > 0)
			{
				if (_neiliAllocation[i] < GetMaxNeiliAllocation(i))
				{
					prefer.Add(i);
				}
				else
				{
					normal.Add(i);
				}
			}
		}
		byte type = byte.MaxValue;
		if (prefer.Count > 0)
		{
			type = prefer.GetRandom(random);
		}
		else if (normal.Count > 0)
		{
			type = normal.GetRandom(random);
		}
		ObjectPool<List<byte>>.Instance.Return(prefer);
		ObjectPool<List<byte>>.Instance.Return(normal);
		return type;
	}

	public bool AbsorbNeiliAllocation(DataContext context, CombatCharacter target, byte type, int value)
	{
		value = Math.Min(value, target._neiliAllocation[type]);
		if (value <= 0)
		{
			return false;
		}
		value = -target.ChangeNeiliAllocation(context, type, -value);
		ChangeNeiliAllocation(context, type, value);
		List<byte> types = _showedAbsorbNeiliAllocations.GetOrNew(target);
		if (types.Contains(type))
		{
			return true;
		}
		types.Add(type);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowAbsorbNeiliAllocation, target._id, _id, type);
		return true;
	}

	public bool AbsorbNeiliAllocationRandom(DataContext context, CombatCharacter target, int value)
	{
		byte type = RandomAbsorbNeiliAllocationType(context.Random, target);
		return type != byte.MaxValue && AbsorbNeiliAllocation(context, target, type, value);
	}

	public void StealNeiliAllocationRandom(DataContext context, CombatCharacter target, CValuePercent percent)
	{
		byte type = RandomAbsorbNeiliAllocationType(context.Random, target);
		if (type != byte.MaxValue)
		{
			int value = Math.Max(target._neiliAllocation[type] * percent, 1);
			AbsorbNeiliAllocation(context, target, type, value);
		}
	}

	public unsafe void SetNeiliAllocationRecoverProgress(DataContext context, byte type, short percent)
	{
		if (_neiliAllocationRecoverProgress.Items[(int)type] != percent)
		{
			_neiliAllocationRecoverProgress.Items[(int)type] = percent;
			SetNeiliAllocationRecoverProgress(_neiliAllocationRecoverProgress, context);
		}
	}

	public void AddOrUpdateFlawOrAcupoint(DataContext context, sbyte bodyPart, bool isFlaw, sbyte level, bool raiseEvent = true, int leftFrames = -1, int totalFrames = -1)
	{
		if (CheckImmunityAndShowEffect(isFlaw ? EMarkType.Flaw : EMarkType.Acupoint))
		{
			return;
		}
		int maxCount = (isFlaw ? GetMaxFlawCount() : GetMaxAcupointCount());
		if (maxCount <= 0)
		{
			return;
		}
		FlawOrAcupointCollection dataDict = (isFlaw ? _flawCollection : _acupointCollection);
		byte[] countList = (isFlaw ? _flawCount : _acupointCount);
		List<FlawOrAcupointEntry> dataList = dataDict.BodyPartDict[bodyPart];
		int keepFrames = (isFlaw ? GlobalConfig.Instance.FlawBaseKeepTime[level] : GlobalConfig.Instance.AcupointBaseKeepTime[level]);
		bool addNew = dataList.Count < maxCount;
		bool canAddNew = DomainManager.SpecialEffect.ModifyData(_id, -1, (ushort)(isFlaw ? 126 : 131), dataValue: true, bodyPart);
		if (addNew && !canAddNew)
		{
			return;
		}
		if (addNew)
		{
			countList[bodyPart]++;
			dataList.Add((level: level, totalFrame: (totalFrames > 0) ? totalFrames : keepFrames, leftFrame: (leftFrames > 0) ? leftFrames : keepFrames));
			if (isFlaw)
			{
				SetFlawCount(countList, context);
				SetFlawCollection(dataDict, context);
				if (raiseEvent)
				{
					Events.RaiseFlawAdded(context, this, bodyPart, level);
				}
			}
			else
			{
				SetAcupointCount(countList, context);
				SetAcupointCollection(dataDict, context);
				if (raiseEvent)
				{
					Events.RaiseAcuPointAdded(context, this, bodyPart, level);
				}
			}
			if (_combatDomain.IsMainCharacter(this))
			{
				_combatDomain.UpdateAllTeammateCommandUsable(context, IsAlly, isFlaw ? ETeammateCommandImplement.HealFlaw : ETeammateCommandImplement.HealAcupoint);
			}
		}
		else
		{
			int replaceIndex = 0;
			int replaceLevel = int.MaxValue;
			for (int i = 0; i < dataList.Count; i++)
			{
				if (dataList[i].Level < Math.Min(level, replaceLevel))
				{
					replaceIndex = i;
					replaceLevel = dataList[i].Level;
				}
			}
			FlawOrAcupointEntry entry = dataList[replaceIndex];
			entry.Level = level;
			entry.TotalFrame = (entry.LeftFrame = keepFrames);
			dataList.RemoveAt(0);
			dataList.Add(entry);
			if (isFlaw)
			{
				SetFlawCollection(dataDict, context);
			}
			else
			{
				SetAcupointCollection(dataDict, context);
			}
		}
		_combatDomain.UpdateBodyDefeatMark(context, this, bodyPart);
		if (!isFlaw && addNew && dataList.Count >= 3)
		{
			_combatDomain.UpdateSkillNeedBodyPartCanUse(context, this);
		}
	}

	public int UpgradeRandomFlawOrAcupoint(DataContext context, bool isFlaw, int count = 1, sbyte bodyPart = -1)
	{
		if (CheckImmunityAndShowEffect(isFlaw ? EMarkType.Flaw : EMarkType.Acupoint))
		{
			return 0;
		}
		int[] keepTimeArray = (isFlaw ? GlobalConfig.Instance.FlawBaseKeepTime : GlobalConfig.Instance.AcupointBaseKeepTime);
		int maxLevel = keepTimeArray.Length - 1;
		FlawOrAcupointCollection collection = (isFlaw ? _flawCollection : _acupointCollection);
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		List<int> indexRandomPool = ObjectPool<List<int>>.Instance.Get();
		HashSet<sbyte> updateMarkSet = ObjectPool<HashSet<sbyte>>.Instance.Get();
		bodyPartRandomPool.Clear();
		indexRandomPool.Clear();
		updateMarkSet.Clear();
		GenerateFlawOrAcupointRandomPool(bodyPart, collection, bodyPartRandomPool, indexRandomPool, maxLevel);
		int maxAffectCount = Math.Min(bodyPartRandomPool.Count, count);
		for (int i = 0; i < maxAffectCount; i++)
		{
			int index = context.Random.Next(bodyPartRandomPool.Count);
			List<FlawOrAcupointEntry> dataList = collection.BodyPartDict[bodyPartRandomPool[index]];
			FlawOrAcupointEntry entry = dataList[indexRandomPool[index]];
			entry.Level = (sbyte)Math.Min(entry.Level + 1, maxLevel);
			entry.LeftFrame = (entry.TotalFrame = keepTimeArray[entry.Level]);
			dataList[indexRandomPool[index]] = entry;
			updateMarkSet.Add(bodyPartRandomPool[index]);
			CollectionUtils.SwapAndRemove(bodyPartRandomPool, index);
			CollectionUtils.SwapAndRemove(indexRandomPool, index);
		}
		if (maxAffectCount > 0)
		{
			if (isFlaw)
			{
				SetFlawCollection(collection, context);
			}
			else
			{
				SetAcupointCollection(collection, context);
			}
		}
		foreach (sbyte markBodyPart in updateMarkSet)
		{
			_combatDomain.UpdateBodyDefeatMark(context, this, markBodyPart);
		}
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		ObjectPool<List<int>>.Instance.Return(indexRandomPool);
		ObjectPool<HashSet<sbyte>>.Instance.Return(updateMarkSet);
		return maxAffectCount;
	}

	public void RemoveRandomFlawOrAcupoint(DataContext context, bool isFlaw, int count = 1)
	{
		FlawOrAcupointCollection dataDict = (isFlaw ? _flawCollection : _acupointCollection);
		byte[] countList = (isFlaw ? _flawCount : _acupointCount);
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		List<(sbyte, sbyte)> removedList = new List<(sbyte, sbyte)>();
		bodyPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			for (int i = 0; i < countList[part]; i++)
			{
				bodyPartRandomPool.Add(part);
			}
		}
		int removeCount = Math.Min(count, bodyPartRandomPool.Count);
		for (int j = 0; j < removeCount; j++)
		{
			int index = context.Random.Next(0, bodyPartRandomPool.Count);
			sbyte part2 = bodyPartRandomPool[index];
			int collectionIndex = context.Random.Next(0, dataDict.BodyPartDict[part2].Count);
			bodyPartRandomPool.RemoveAt(index);
			removedList.Add((part2, dataDict.BodyPartDict[part2][collectionIndex].Level));
			countList[part2]--;
			dataDict.BodyPartDict[part2].RemoveAt(collectionIndex);
		}
		if (isFlaw)
		{
			SetFlawCount(countList, context);
			SetFlawCollection(dataDict, context);
		}
		else
		{
			SetAcupointCount(countList, context);
			SetAcupointCollection(dataDict, context);
		}
		_combatDomain.UpdateBodyDefeatMark(context, this);
		if (_combatDomain.IsMainCharacter(this))
		{
			if (isFlaw)
			{
				_combatDomain.UpdateAllTeammateCommandUsable(context, IsAlly, ETeammateCommandImplement.HealFlaw);
			}
			else
			{
				_combatDomain.UpdateAllCommandAvailability(context, this);
			}
		}
		for (int k = 0; k < removedList.Count; k++)
		{
			(sbyte, sbyte) removedItem = removedList[k];
			if (isFlaw)
			{
				Events.RaiseFlawRemoved(context, this, removedItem.Item1, removedItem.Item2);
			}
			else
			{
				Events.RaiseAcuPointRemoved(context, this, removedItem.Item1, removedItem.Item2);
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
	}

	private static void GenerateFlawOrAcupointRandomPool(sbyte bodyPart, FlawOrAcupointCollection collection, ICollection<sbyte> bodyPartRandomPool, ICollection<int> indexRandomPool, int maxLevel, bool onlyMaxLevel = false)
	{
		if (bodyPart < 0)
		{
			for (sbyte i = 0; i < 7; i++)
			{
				AddToRandom(i);
			}
		}
		else
		{
			AddToRandom(bodyPart);
		}
		void AddToRandom(sbyte bodyPartKey)
		{
			if (collection.BodyPartDict.TryGetValue(bodyPartKey, out var dataList) && dataList != null && dataList.Count > 0)
			{
				for (int j = 0; j < dataList.Count; j++)
				{
					FlawOrAcupointEntry entry = dataList[j];
					if (!(onlyMaxLevel ? (entry.Level != maxLevel) : (entry.Level >= maxLevel)))
					{
						bodyPartRandomPool.Add(bodyPartKey);
						indexRandomPool.Add(j);
					}
				}
			}
		}
	}

	public int GetMaxFlawCount()
	{
		int maxCount = 3 + DomainManager.SpecialEffect.GetModifyValue(_id, 125, EDataModifyType.Add);
		maxCount += _character.GetIceSilkwormWugKingFlawModify();
		return Math.Max(maxCount, 0);
	}

	public int GetMaxAcupointCount()
	{
		int maxCount = 3 + DomainManager.SpecialEffect.GetModifyValue(_id, 130, EDataModifyType.Add);
		maxCount += _character.GetIceSilkwormWugKingAcupointModify();
		return Math.Max(maxCount, 0);
	}

	public int GetRecoveryOfFlaw()
	{
		int extraPercent = 0;
		if (_affectingDefendSkillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: _affectingDefendSkillId));
			extraPercent += skill.GetPageEffects().Sum((SkillBreakPageEffectImplementItem pageEffect) => pageEffect.FlawRecoverSpeed);
		}
		int recoverySpeed = DomainManager.SpecialEffect.ModifyValue(_id, 185, _character.GetRecoveryOfFlaw(), -1, -1, -1, 0, extraPercent);
		int recoveryValue = CFormula.CalcFlawOrAcupointRecoveryValue(recoverySpeed);
		recoveryValue = DomainManager.SpecialEffect.ModifyValue(_id, 314, recoveryValue);
		return Math.Max(recoveryValue, 1);
	}

	public int GetRecoveryOfAcupoint()
	{
		int extraPercent = 0;
		if (_affectingDefendSkillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: _affectingDefendSkillId));
			extraPercent += skill.GetPageEffects().Sum((SkillBreakPageEffectImplementItem pageEffect) => pageEffect.AcupointRecoverSpeed);
		}
		int recoverySpeed = DomainManager.SpecialEffect.ModifyValue(_id, 186, _character.GetRecoveryOfBlockedAcupoint(), -1, -1, -1, 0, extraPercent);
		int recoveryValue = CFormula.CalcFlawOrAcupointRecoveryValue(recoverySpeed);
		recoveryValue = DomainManager.SpecialEffect.ModifyValue(_id, 299, recoveryValue);
		return Math.Max(recoveryValue, 1);
	}

	public void ClearInjuryAutoHealProgress(DataContext context, bool inner)
	{
		InjuryAutoHealCollection autoHealCollection = GetInjuryAutoHealCollection();
		List<short>[] bodyPartList = (inner ? autoHealCollection.InnerBodyPartList : autoHealCollection.OuterBodyPartList);
		foreach (List<short> progressList in bodyPartList)
		{
			for (int j = 0; j < progressList.Count; j++)
			{
				progressList[j] = 0;
			}
		}
		SetInjuryAutoHealCollection(autoHealCollection, context);
	}

	public int GetDamageValue(sbyte bodyPart, bool inner)
	{
		return (inner ? GetInnerDamageValue() : GetOuterDamageValue())[bodyPart];
	}

	public void SetDamageValue(DataContext context, int leftDamage, sbyte bodyPart, bool inner)
	{
		int[] valueArray = (inner ? GetInnerDamageValue() : GetOuterDamageValue());
		valueArray[bodyPart] = leftDamage;
		if (inner)
		{
			SetInnerDamageValue(valueArray, context);
		}
		else
		{
			SetOuterDamageValue(valueArray, context);
		}
	}

	public void AddDamageToShow(DataContext context, int damage, CValuePercentBonus criticalPercent, sbyte bodyPart, bool inner)
	{
		DefeatMarkKey markKey = new DefeatMarkKey(inner ? EMarkType.Inner : EMarkType.Outer, bodyPart);
		DomainManager.Combat.AccumulateSkillDamage(context, this, markKey, damage);
		IntPair value = (inner ? _innerDamageValueToShow[bodyPart] : _outerDamageValueToShow[bodyPart]);
		value.First = Math.Max(value.First, 0) + damage;
		value.Second = Math.Max(value.Second, 100 * criticalPercent);
		if (inner)
		{
			_innerDamageValueToShow[bodyPart] = value;
			SetInnerDamageValueToShow(_innerDamageValueToShow, context);
		}
		else
		{
			_outerDamageValueToShow[bodyPart] = value;
			SetOuterDamageValueToShow(_outerDamageValueToShow, context);
		}
	}

	public unsafe void AddPoisonToShow(DataContext context, sbyte poisonType, sbyte level, int poisonValue)
	{
		PoisonsAndLevels poisonToShow = _newPoisonsToShow;
		poisonToShow.Levels[poisonType] = Math.Max(poisonToShow.Levels[poisonType], level);
		poisonToShow.Values[poisonType] = (short)(Math.Max((int)poisonToShow.Values[poisonType], 0) + poisonValue);
		SetNewPoisonsToShow(ref poisonToShow, context);
	}

	public void AddMindDamageToShow(DataContext context, int mindDamage)
	{
		DomainManager.Combat.AccumulateSkillDamage(context, this, EMarkType.Mind, mindDamage);
		int value = Math.Max(_mindDamageValueToShow, 0) + mindDamage;
		SetMindDamageValueToShow(value, context);
	}

	public void AddFatalDamageToShow(DataContext context, int fatalDamage)
	{
		DomainManager.Combat.AccumulateSkillDamage(context, this, EMarkType.Fatal, fatalDamage);
		int value = Math.Max(_fatalDamageValueToShow, 0) + fatalDamage;
		SetFatalDamageValueToShow(value, context);
	}

	public CombatStateCollection GetCombatStateCollection(sbyte type)
	{
		if (1 == 0)
		{
		}
		CombatStateCollection result = type switch
		{
			0 => _specialCombatStateCollection, 
			1 => _buffCombatStateCollection, 
			2 => _debuffCombatStateCollection, 
			_ => throw new Exception($"Invalid combat state type: {type}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public void SetCombatStateCollection(sbyte type, CombatStateCollection stateCollection, DataContext context)
	{
		switch (type)
		{
		case 0:
			SetSpecialCombatStateCollection(stateCollection, context);
			break;
		case 1:
			SetBuffCombatStateCollection(stateCollection, context);
			break;
		case 2:
			SetDebuffCombatStateCollection(stateCollection, context);
			break;
		}
	}

	public int GetCombatStatePower(sbyte stateType, short stateId)
	{
		CombatStateCollection stateCollection = GetCombatStateCollection(stateType);
		(short, bool, int) tuple;
		return stateCollection.StateDict.TryGetValue(stateId, out tuple) ? tuple.Item1 : 0;
	}

	public short GetCombatStatePowerLimit(sbyte type)
	{
		return type switch
		{
			0 => 500, 
			1 => (short)Math.Max(500 + BuffCombatStatePowerExtraLimit, 0), 
			2 => (short)Math.Max(500 + DebuffCombatStatePowerExtraLimit, 0), 
			_ => throw new Exception($"Invalid combat state type: {type}"), 
		};
	}

	public unsafe int GetFightBackPower(sbyte hitType)
	{
		GameData.Domains.CombatSkill.CombatSkill skill = ((_affectingDefendSkillId >= 0) ? DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_id, _affectingDefendSkillId)) : null);
		HitOrAvoidInts addAvoid = skill?.GetAddAvoidValueOnCast() ?? default(HitOrAvoidInts);
		int fightBackPower = ((skill != null && addAvoid.Items[hitType] > 0) ? skill.GetFightBackPower() : 0);
		return DomainManager.SpecialEffect.ModifyValue(_id, 112, fightBackPower, hitType);
	}

	public OuterAndInnerInts GetBouncePower(sbyte attackInnerRatio = 50)
	{
		OuterAndInnerInts bouncePower = ((_affectingDefendSkillId > 0) ? DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_id, _affectingDefendSkillId)).GetBouncePower() : new OuterAndInnerInts(0, 0));
		bouncePower.Outer = DomainManager.SpecialEffect.ModifyValue(_id, 111, bouncePower.Outer, 0, attackInnerRatio);
		bouncePower.Inner = DomainManager.SpecialEffect.ModifyValue(_id, 111, bouncePower.Inner, 1, attackInnerRatio);
		return bouncePower;
	}

	public unsafe bool PoisonOverflow(sbyte poisonType)
	{
		return PoisonsAndLevels.CalcPoisonedLevel(_poison.Items[poisonType]) > 0;
	}

	public void AddPoisonAffectValue(sbyte poisonType, short value, bool needLessThanThreshold = false)
	{
		if (!GetCharacter().HasPoisonImmunity(poisonType))
		{
			_poisonAffectAccumulator[poisonType] += value;
			short threshold = Poison.Instance[poisonType].AffectNeedValue;
			threshold += (short)DomainManager.SpecialEffect.GetModifyValue(_id, 243, EDataModifyType.Add, poisonType);
			threshold = Math.Max((short)1, threshold);
			if (needLessThanThreshold)
			{
				_poisonAffectAccumulator[poisonType] = (short)Math.Min(_poisonAffectAccumulator[poisonType], threshold - 1);
			}
			while (_poisonAffectAccumulator[poisonType] >= threshold)
			{
				_poisonAffectAccumulator[poisonType] -= threshold;
				_combatDomain.PoisonAffect(GetDataContext(), this, poisonType);
			}
		}
	}

	public short GetPoisonAccumulator(sbyte poisonType)
	{
		return _poisonAffectAccumulator[poisonType];
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		if (!IsAlly)
		{
			_combatDomain.UpdateShowUseSpecialMisc(context);
		}
	}

	private void OnPoisonResistChanged(DataContext context, DataUid dataUid)
	{
		SetPoisonResist(ref _character.GetPoisonResists(), context);
		_combatDomain.UpdatePoisonDefeatMark(context, this);
	}

	public int GetFeatureMedalValue(sbyte medalType)
	{
		return _character.GetFeatureMedalValue(medalType);
	}

	public (int add, int reduce) GetFeatureSilenceFrameTotalPercent()
	{
		int add = 0;
		int reduce = 0;
		foreach (short featureId in _character.GetValidFeatureIds())
		{
			CharacterFeatureItem config = CharacterFeature.Instance[featureId];
			add = Math.Max(add, config.SilenceFramePercent);
			reduce = Math.Min(reduce, config.SilenceFramePercent);
		}
		return (add: add, reduce: reduce);
	}

	public bool HasInfectedFeature(ECharacterFeatureInfectedType type)
	{
		if (1 == 0)
		{
		}
		bool result;
		switch (type)
		{
		case ECharacterFeatureInfectedType.NotInfected:
			result = !HasInfectedFeature(ECharacterFeatureInfectedType.PartlyInfected) && !HasInfectedFeature(ECharacterFeatureInfectedType.CompletelyInfected);
			break;
		case ECharacterFeatureInfectedType.PartlyInfected:
		case ECharacterFeatureInfectedType.CompletelyInfected:
			result = _character.GetFeatureIds().Any((short x) => CharacterFeature.Instance[x].InfectedType == type);
			break;
		default:
			result = false;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public unsafe sbyte GetPersonalityValue(sbyte type)
	{
		Personalities personalities = _character.GetPersonalities();
		return personalities.Items[type];
	}

	public bool ChangeToEmptyHand(DataContext context)
	{
		if (!Config.Character.Instance[_character.GetTemplateId()].AllowUseFreeWeapon)
		{
			return false;
		}
		DomainManager.Combat.ChangeWeapon(context, this, 3, init: false, force: true);
		if (StateMachine.GetCurrentStateType() == CombatCharacterStateType.PrepareSkill && _preparingSkillId >= 0 && !DomainManager.Combat.WeaponHasNeedTrick(this, _preparingSkillId, DomainManager.Combat.GetUsingWeaponData(this)))
		{
			DomainManager.Combat.InterruptSkill(context, this, -1);
		}
		return true;
	}

	public bool ChangeToEmptyHandOrOther(DataContext context)
	{
		if (ChangeToEmptyHand(context))
		{
			return true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (i != _usingWeaponIndex && _weapons[i].IsValid())
			{
				CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(_weapons[i].Id);
				if (weaponData.GetCanChangeTo())
				{
					DomainManager.Combat.ChangeWeapon(context, this, i, init: false, force: true);
					return true;
				}
			}
		}
		return false;
	}

	public bool CanUnlockAttackByConfig(int index)
	{
		return GetUnlockEffect(index) != null;
	}

	public WeaponUnlockEffectItem GetUnlockEffect(int index)
	{
		if (!_weapons.CheckIndex(index))
		{
			return null;
		}
		ItemKey weaponKey = _weapons[index];
		if (!weaponKey.IsValid())
		{
			return null;
		}
		short weaponId = weaponKey.TemplateId;
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponId];
		return WeaponUnlockEffect.Instance[weaponConfig.UnlockEffect];
	}

	public CombatWeaponData GetWeaponData(int index = -1)
	{
		index = ((index < 0) ? _usingWeaponIndex : index);
		ItemKey key = _weapons[index];
		return _combatDomain.GetElement_WeaponDataDict(key.Id);
	}

	public sbyte GetConfigAttackPointCost()
	{
		GameData.Domains.Item.Weapon weapon = DomainManager.Combat.GetUsingWeapon(this);
		return weapon.GetAttackPreparePointCost();
	}

	public void ClearUnlockAttackValue(DataContext context, int index)
	{
		if (_unlockPrepareValue.CheckIndex(index) && _unlockPrepareValue[index] > 0)
		{
			_unlockPrepareValue[index] = 0;
			SetUnlockPrepareValue(_unlockPrepareValue, context);
		}
	}

	public void ChangeUnlockAttackValue(DataContext context, int index, int delta)
	{
		if (_unlockPrepareValue.CheckIndex(index) && CanUnlockAttackByConfig(index) && GetWeaponData(index).GetDurability() > 0)
		{
			if (delta > 0)
			{
				delta = DomainManager.SpecialEffect.ModifyValue(_id, 315, delta);
				delta = Math.Max(delta, 1);
			}
			int newValue = Math.Clamp(_unlockPrepareValue[index] + delta, 0, GlobalConfig.Instance.UnlockAttackUnit);
			if (newValue != _unlockPrepareValue[index])
			{
				_unlockPrepareValue[index] = newValue;
				SetUnlockPrepareValue(_unlockPrepareValue, context);
			}
		}
	}

	public void ChangeAllUnlockAttackValue(DataContext context, int delta)
	{
		for (int i = 0; i < 3; i++)
		{
			ChangeUnlockAttackValue(context, i, delta);
		}
	}

	public void ChangeAllUnlockAttackValue(DataContext context, CValuePercent deltaPercent)
	{
		ChangeAllUnlockAttackValue(context, GlobalConfig.Instance.UnlockAttackUnit * deltaPercent);
	}

	public bool HasDoingOrReserveCommand()
	{
		bool hasCmd = StateMachine.GetCurrentStateType() != CombatCharacterStateType.Idle || _combatReserveData.AnyReserve || NeedNormalAttack || NeedChangeTrickAttack || NeedUnlockAttack || NeedUseGoldenWire || NeedUseSkillFreeId >= 0 || ChangeCharId >= 0;
		if (!hasCmd && _combatDomain.IsMainCharacter(this))
		{
			int[] charList = (IsAlly ? _combatDomain.GetSelfTeam() : _combatDomain.GetEnemyTeam());
			for (int i = 0; i < TeammateHasCommand.Length; i++)
			{
				if (TeammateHasCommand[i] && _combatDomain.GetElement_CombatCharacterDict(charList[i + 1]).ExecutingTeammateCommandConfig.IntoCombatField)
				{
					hasCmd = true;
					break;
				}
			}
		}
		return hasCmd;
	}

	public void ClearAllDoingOrReserveCommand(DataContext context)
	{
		NeedChangeTrickAttack = (NeedUnlockAttack = (NeedUseGoldenWire = false));
		SetPreparingSkillId(-1, context);
		SetAffectingMoveSkillId(-1, context);
		SetAffectingDefendSkillId(-1, context);
		SetPreparingItem(ItemKey.Invalid, context);
		SetPreparingOtherAction(-1, context);
		SetCombatReserveData(CombatReserveData.Invalid, context);
		SetReserveNormalAttack(reserveNormalAttack: false, context);
		NeedNormalAttackImmediate = false;
		SetMoveState(MoveState.Stay, context);
		MoveData.ResetJumpState(context, calcPreparedMove: false);
		SetAnimationToLoop(null, context);
		SetParticleToLoop(null, context);
	}

	public void SetNeedUseSkillId(DataContext context, short needUseSkillId)
	{
		SetCombatReserveData(CombatReserveData.CreateSkill(needUseSkillId), context);
	}

	public void SetNeedShowChangeTrick(DataContext context, bool needShowChangeTrick)
	{
		SetCombatReserveData(CombatReserveData.CreateChangeTrick(needShowChangeTrick), context);
	}

	public void SetNeedChangeWeaponIndex(DataContext context, int needChangeWeaponIndex)
	{
		SetCombatReserveData(CombatReserveData.CreateChangeWeapon(needChangeWeaponIndex), context);
	}

	public void SetNeedUnlockWeaponIndex(DataContext context, int needUnlockWeaponIndex)
	{
		SetCombatReserveData(CombatReserveData.CreateUnlockAttack(needUnlockWeaponIndex), context);
	}

	public void SetNeedUseOtherAction(DataContext context, sbyte needUseOtherAction)
	{
		SetCombatReserveData(CombatReserveData.CreateOtherAction(needUseOtherAction), context);
	}

	public void SetNeedUseItem(DataContext context, ItemKey needUseItem)
	{
		SetCombatReserveData(CombatReserveData.CreateUseItem(needUseItem), context);
	}

	public void SetNeedTeammateCommand(DataContext context, int teammateId, int index)
	{
		SetCombatReserveData(CombatReserveData.CreateTeammateCommand(teammateId, index), context);
	}

	public void SetNeedSmarterChicken(DataContext context, IReadOnlyList<int> ids)
	{
		SetCombatReserveData(CombatReserveData.CreateSmarterChicken(ids), context);
	}

	public void NormalAttackFree()
	{
		NeedFreeAttack = true;
	}

	public void FinishFreeAttack()
	{
		IsAutoNormalAttacking = false;
	}

	public void ClearAllSound(DataContext context)
	{
		SetAttackSoundToPlay(null, context);
		SetSkillSoundToPlay(null, context);
		SetHitSoundToPlay(null, context);
		SetArmorHitSoundToPlay(null, context);
		SetWhooshSoundToPlay(null, context);
		SetShockSoundToPlay(null, context);
		SetStepSoundToPlay(null, context);
		SetDieSoundToPlay(null, context);
	}

	public void InitTeammateCommand(DataContext context, bool isFirstMove)
	{
		if (DomainManager.Combat.GetTeamCharacterIds().Contains(_id))
		{
			IReadOnlyList<sbyte> cmdList = DomainManager.Combat.GetPreRandomizedTeammateCommands(context, _id);
			CValuePercent initPercent = (isFirstMove ? 75 : 50);
			for (int i = 0; i < 3; i++)
			{
				sbyte cmdType = (sbyte)((cmdList != null && i < cmdList.Count) ? cmdList[i] : (-1));
				_currTeammateCommands.Add(cmdType);
				_teammateCommandBanReasons.Add(SByteList.Create());
				_teammateCommandCanUse.Add(item: false);
				int totalCd = ((cmdType >= 0) ? TeammateCommand.Instance[cmdType].CdCount : (-1));
				int initCd = ((totalCd < 0) ? totalCd : (totalCd - totalCd * initPercent));
				_teammateCommandCd.Add(CountdownData.Create(totalCd, initCd));
			}
			StopCommandEffectCount = 0;
			UpdateTeammateCommandOnPrepared(context);
		}
	}

	public bool IsBeforeOrAfterTeammate(int teammateId)
	{
		return teammateId == TeammateBeforeMainChar || teammateId == TeammateAfterMainChar;
	}

	public void ChangeTeammateCommandCd(DataContext context, int index, CValuePercent deltaPercent)
	{
		List<sbyte> cmdList = GetCurrTeammateCommands();
		if (!cmdList.CheckIndex(index) || cmdList[index] < 0 || MainChar.IsBeforeOrAfterTeammate(_id))
		{
			return;
		}
		CountdownData cd = _teammateCommandCd[index];
		if (!cd.Off && !cd.Infinite)
		{
			if (cd.Tick(cd.Total * deltaPercent))
			{
				_teammateCommandCd[index] = cd;
				SetTeammateCommandCd(_teammateCommandCd, context);
			}
			if (cd.Off)
			{
				DomainManager.Combat.UpdateTeammateCommandUsable(context, this, cmdList[index]);
			}
		}
	}

	public void ClearTeammateCommandCd(DataContext context, int index)
	{
		List<sbyte> cmdList = GetCurrTeammateCommands();
		if (cmdList.CheckIndex(index) && cmdList[index] >= 0 && !MainChar.IsBeforeOrAfterTeammate(_id))
		{
			CountdownData cd = _teammateCommandCd[index];
			if (!cd.Off && !cd.Infinite)
			{
				_teammateCommandCd[index] = CountdownData.Zero;
				SetTeammateCommandCd(_teammateCommandCd, context);
				DomainManager.Combat.UpdateTeammateCommandUsable(context, this, cmdList[index]);
			}
		}
	}

	public void ResetTeammateCommandCd(DataContext context, int index, int cdCount = -1, bool checkEvent = false, bool displayEvent = false)
	{
		sbyte cmdType = _currTeammateCommands[index];
		if (cdCount < 0)
		{
			cdCount = TeammateCommand.Instance[cmdType].CdCount;
		}
		if (MainChar.GetCharacter().IsTreasuryGuard())
		{
			cdCount *= (CValuePercentBonus)GlobalConfig.Instance.TreasuryGuardTeammateCdBonus;
		}
		bool skipCd = checkEvent && CheckInvokeSkipCd(context.Random, cmdType);
		if (skipCd)
		{
			DomainManager.Combat.ShowTeammateCommand(_id, index, displayEvent);
			Events.RaiseTeammateCommandSkipCd(context, MainChar);
		}
		CountdownData cd = CountdownData.Create(cdCount, (!skipCd) ? cdCount : 0);
		_teammateCommandCd[index] = cd;
		SetTeammateCommandCd(_teammateCommandCd, context);
		_combatDomain.UpdateTeammateCommandUsable(context, this, cmdType);
	}

	private bool CheckInvokeSkipCd(IRandomSource random, sbyte cmdType)
	{
		TeammateCommandItem config = TeammateCommand.Instance[cmdType];
		if (config.Type == ETeammateCommandType.Negative)
		{
			return false;
		}
		if (!_character.Template.AllowFavorabilitySkipCd)
		{
			return false;
		}
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(IsAlly);
		short favor = DomainManager.Character.GetFavorability(_id, mainChar.GetId());
		if (favor < config.FavorLimit[0] || favor > config.FavorLimit[1])
		{
			return false;
		}
		return random.CheckPercentProb(config.AutoProb);
	}

	public bool UpdateTeammateCommandState(DataContext context)
	{
		if (ExecutingTeammateCommandConfig.IntoCombatField)
		{
			if (!_visible)
			{
				sbyte displayDist = -1;
				if (ExecutingTeammateCommandImplement.IsAttack() && _combatDomain.InAttackRange(this))
				{
					displayDist = GetNormalAttackPosition(_attackCommandTrickType);
				}
				int displayPos = ((displayDist > 0) ? _combatDomain.GetDisplayPosition(IsAlly, displayDist) : int.MinValue);
				_combatDomain.SetDisplayPosition(context, IsAlly, displayPos);
				SetAnimationToLoop(GetIdleAni(), context);
				SetVisible(visible: true, context);
				SetTeammateCommandPreparePercent(0, context);
				if (TeammateCommandLeftPrepareFrame <= 0)
				{
					ResetTeammateCommandLeftTime(context);
				}
				return true;
			}
		}
		else if (TeammateCommandLeftFrame < 0)
		{
			ResetTeammateCommandLeftTime(context);
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.StopEnemy)
			{
				int[] enemyTeam = (IsAlly ? _combatDomain.GetEnemyTeam() : _combatDomain.GetSelfTeam());
				for (int i = 1; i < enemyTeam.Length; i++)
				{
					if (enemyTeam[i] >= 0)
					{
						_combatDomain.GetElement_CombatCharacterDict(enemyTeam[i]).StopCommandEffectCount++;
					}
				}
				_combatDomain.UpdateAllTeammateCommandUsable(context, !IsAlly, -1);
			}
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.AnimalEffect && ExecutingTeammateCommandSpecialEffect < 0)
			{
				string effect = SharedConstValue.AnimalCarrier2Effect[AnimalConfig.CarrierId];
				int mainCharId = _combatDomain.GetMainCharacter(IsAlly).GetId();
				ExecutingTeammateCommandSpecialEffect = DomainManager.SpecialEffect.Add(context, mainCharId, effect);
			}
			if (TeammateCommandEffects.TryGetValue(ExecutingTeammateCommandImplement, out var effectType) && ExecutingTeammateCommandSpecialEffect < 0)
			{
				SpecialEffectBase effect2 = (SpecialEffectBase)Activator.CreateInstance(effectType, _id);
				ExecutingTeammateCommandSpecialEffect = DomainManager.SpecialEffect.Add(context, effect2);
			}
		}
		if (TeammateCommandLeftPrepareFrame > 0)
		{
			TeammateCommandLeftPrepareFrame--;
			byte percent = (byte)((TeammateCommandLeftPrepareFrame != 0) ? ((uint)((TeammateCommandTotalPrepareFrame - TeammateCommandLeftPrepareFrame) * 100 / TeammateCommandTotalPrepareFrame)) : 0u);
			if (GetTeammateCommandPreparePercent() != percent)
			{
				SetTeammateCommandPreparePercent(percent, context);
			}
			if (TeammateCommandLeftPrepareFrame == 0)
			{
				ResetTeammateCommandLeftTime(context);
			}
			return TeammateCommandLeftPrepareFrame == 0;
		}
		if (TeammateCommandLeftFrame > 0)
		{
			ReduceTeammateCommandLeftTime(context);
			if (TeammateCommandLeftFrame == 0)
			{
				if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.StopEnemy)
				{
					int[] enemyTeam2 = (IsAlly ? _combatDomain.GetEnemyTeam() : _combatDomain.GetSelfTeam());
					for (int j = 1; j < enemyTeam2.Length; j++)
					{
						if (enemyTeam2[j] >= 0)
						{
							_combatDomain.GetElement_CombatCharacterDict(enemyTeam2[j]).StopCommandEffectCount--;
						}
					}
					_combatDomain.UpdateAllTeammateCommandUsable(context, !IsAlly, -1);
				}
				if (ExecutingTeammateCommandSpecialEffect >= 0)
				{
					DomainManager.SpecialEffect.Remove(context, ExecutingTeammateCommandSpecialEffect);
					ExecutingTeammateCommandSpecialEffect = -1L;
				}
				ClearTeammateCommand(context);
			}
			return false;
		}
		if (_teammateExitAniLeftFrame > 0)
		{
			_teammateExitAniLeftFrame--;
		}
		if (_teammateExitAniLeftFrame <= 0)
		{
			ClearTeammateCommandData(context);
		}
		return false;
	}

	public void ResetTeammateCommandLeftTime(DataContext context)
	{
		if (ExecutingTeammateCommandConfig.AffectFrame > 0)
		{
			short affectFrame = ExecutingTeammateCommandConfig.AffectFrame;
			ETeammateCommandImplement implement = ExecutingTeammateCommandConfig.Implement;
			if ((implement == ETeammateCommandImplement.Fight || implement == ETeammateCommandImplement.StopEnemy) ? true : false)
			{
				int cmdEffectPercent = DomainManager.SpecialEffect.GetModifyValue(_combatDomain.GetMainCharacter(IsAlly).GetId(), 184, EDataModifyType.Add, (int)ExecutingTeammateCommandConfig.Implement);
				affectFrame = (short)(affectFrame * (100 + cmdEffectPercent) / 100);
			}
			TeammateCommandLeftFrame = (TeammateCommandTotalFrame = affectFrame);
			SetTeammateCommandTimePercent(100, context);
		}
	}

	public void ReduceTeammateCommandLeftTime(DataContext context)
	{
		TeammateCommandLeftFrame--;
		byte percent = (byte)(TeammateCommandLeftFrame * 100 / TeammateCommandTotalFrame);
		if (GetTeammateCommandTimePercent() != percent)
		{
			SetTeammateCommandTimePercent(percent, context);
		}
	}

	public void ClearTeammateCommand(DataContext context, bool interrupt = false)
	{
		if (_executingTeammateCommand < 0)
		{
			return;
		}
		CombatCharacter mainChar = _combatDomain.GetMainCharacter(IsAlly);
		PartlyClearTeammateCommand(context, interrupt);
		if (ExecutingTeammateCommandConfig.IntoCombatField && (ExecutingTeammateCommandConfig.PrepareFrame > 0 || ExecutingTeammateCommandImplement.IsAttack() || ExecutingTeammateCommandImplement.IsDefend()))
		{
			TeammateCommandLeftPrepareFrame = 0;
			TeammateCommandLeftFrame = 0;
			_teammateExitAniLeftFrame = 1;
			SetTeammateCommandPreparePercent(0, context);
			if (interrupt)
			{
				if (mainChar.TeammateBeforeMainChar < 0)
				{
					mainChar.SpecialAnimationLoop = null;
				}
				_combatDomain.SetProperLoopAniAndParticle(context, mainChar);
				mainChar.SetTeammateCommandPreparePercent(0, context);
				if (!string.IsNullOrEmpty(_soundToLoop))
				{
					SetSoundToLoop(string.Empty, context);
				}
			}
		}
		else
		{
			if (!ExecutingTeammateCommandConfig.IntoCombatField)
			{
				ResetTeammateCommandCd(context, ExecutingTeammateCommandIndex, -1, checkEvent: true);
			}
			ClearTeammateCommandData(context);
		}
	}

	public void PartlyClearTeammateCommand(DataContext context, bool interrupt = false)
	{
		CombatCharacter mainChar = _combatDomain.GetMainCharacter(IsAlly);
		if (mainChar.TeammateBeforeMainChar == _id)
		{
			mainChar.TeammateBeforeMainChar = -1;
		}
		else if (mainChar.TeammateAfterMainChar == _id)
		{
			mainChar.TeammateAfterMainChar = -1;
		}
		mainChar.SetParticleToLoop(null, context);
		SetParticleToLoop(null, context);
		SetParticleToPlay(null, context);
		if (ExecutingTeammateCommandImplement.IsAttack())
		{
			_combatDomain.ClearDamageCompareData(context);
			UpdateAttackCommandWeaponAndTrick(context);
		}
		else if (ExecutingTeammateCommandImplement.IsDefend())
		{
			UpdateDefendCommandSkill(context);
		}
		else if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.AttackSkill)
		{
			UpdateAttackCommandSkill(context);
		}
		if ((ExecutingTeammateCommandConfig.IntoCombatField && ExecutingTeammateCommandConfig.PrepareFrame > 0) || ExecutingTeammateCommandImplement.IsAttack() || ExecutingTeammateCommandImplement.IsDefend())
		{
			short posOffset = ExecutingTeammateCommandConfig.PosOffset;
			string exitAni = ((posOffset < 0 && string.IsNullOrEmpty(ExecutingTeammateCommandConfig.BackCharExitAni) && !interrupt) ? ExecutingTeammateCommandConfig.BackCharExitAni : "M_004");
			_combatDomain.SetDisplayPosition(context, IsAlly, int.MinValue);
			SetAnimationToPlayOnce(exitAni, context);
			SetAnimationToLoop(GetIdleAni(), context);
			SetDisplayPosition(int.MinValue, context);
			if (ExecutingTeammateCommandImplement.IsDefend())
			{
				_combatDomain.ClearAffectingDefenseSkill(context, this);
			}
		}
	}

	private void ClearTeammateCommandData(DataContext context)
	{
		CombatCharacter mainChar = _combatDomain.GetMainCharacter(IsAlly);
		mainChar.TeammateHasCommand[_combatDomain.GetCharacterList(IsAlly).IndexOf(_id) - 1] = false;
		SetExecutingTeammateCommand(-1, context);
		SetVisible(visible: false, context);
		TeammateCommandLeftFrame = -1;
		ExecutingTeammateCommandIndex = -1;
		_combatDomain.UpdateAllCommandAvailability(context, mainChar);
	}

	public OuterAndInnerShorts CalcAttackRangeImmediate(short skillId = -1, int weaponIndex = -1)
	{
		if (!_combatDomain.IsInCombat())
		{
			return _attackRange;
		}
		if (skillId < 0 && weaponIndex < 0)
		{
			skillId = (short)((_preparingSkillId > 0) ? _preparingSkillId : ((_performingSkillId > 0) ? _performingSkillId : (-1)));
		}
		GameData.Domains.CombatSkill.CombatSkill skill = null;
		CombatSkillKey skillKey = new CombatSkillKey(_id, skillId);
		if (skillId >= 0 && !DomainManager.CombatSkill.TryGetElement_CombatSkills(skillKey, out skill))
		{
			PredefinedLog.DefValue.CombatRuntimeException.Log($"{skillKey} instance not found.");
			return _attackRange;
		}
		if (weaponIndex < 0)
		{
			weaponIndex = _usingWeaponIndex;
		}
		ItemKey weaponKey = _weapons[weaponIndex];
		if (!DomainManager.Item.TryGetElement_Weapons(weaponKey.Id, out var weapon))
		{
			throw new Exception($"Failed to get weapon by {weaponKey} at {this}.{weaponIndex}");
		}
		if (skillId >= 0 && DomainManager.CombatSkill.GetSkillType(_id, skillId) == 5)
		{
			weapon = DomainManager.Item.GetElement_Weapons(_weapons[3].Id);
		}
		WeaponItem weaponConfig = Config.Weapon.Instance[weapon.GetTemplateId()];
		sbyte currTrick = (_changeTrickAttack ? ChangeTrickType : _weaponTricks[_weaponTrickIndex]);
		int rangeMid = (weaponConfig.MinDistance + weaponConfig.MaxDistance) / 2;
		byte rangeMidMaxDelta = GlobalConfig.Instance.AttackRangeMidMinDistance;
		(int, int) weaponRange = DomainManager.Item.GetWeaponAttackRange(_id, weapon.GetItemKey());
		short minDist = (short)weaponRange.Item1;
		short maxDist = (short)weaponRange.Item2;
		if (skillId >= 0)
		{
			if (weaponConfig.TrickDistanceAdjusts.Count > 0)
			{
				List<NeedTrick> skillTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				DomainManager.CombatSkill.GetCombatSkillCostTrick(skill, skillTricks);
				short trickAddMinDist = 0;
				short trickAddMaxDist = 0;
				for (int i = 0; i < skillTricks.Count; i++)
				{
					sbyte skillTrick = skillTricks[i].TrickType;
					TrickDistanceAdjust trickAdjust = weaponConfig.TrickDistanceAdjusts.Find((TrickDistanceAdjust adjust) => adjust.TrickTemplateId == skillTrick);
					if (trickAdjust != null)
					{
						trickAddMinDist = Math.Max(trickAddMinDist, trickAdjust.MinDistance);
						trickAddMaxDist = Math.Max(trickAddMaxDist, trickAdjust.MaxDistance);
					}
				}
				ObjectPool<List<NeedTrick>>.Instance.Return(skillTricks);
				minDist -= trickAddMinDist;
				maxDist += trickAddMaxDist;
			}
			minDist -= DomainManager.CombatSkill.GetCombatSkillAddAttackDistance(_id, skillId, forward: true);
			maxDist += DomainManager.CombatSkill.GetCombatSkillAddAttackDistance(_id, skillId, forward: false);
		}
		else
		{
			TrickDistanceAdjust trickAdjust2 = weaponConfig.TrickDistanceAdjusts.Find((TrickDistanceAdjust adjust) => adjust.TrickTemplateId == currTrick);
			if (trickAdjust2 != null)
			{
				minDist -= trickAdjust2.MinDistance;
				maxDist += trickAdjust2.MaxDistance;
			}
		}
		minDist -= (short)DomainManager.SpecialEffect.GetModifyValue(_id, -1, 145, EDataModifyType.Add, currTrick);
		maxDist += (short)DomainManager.SpecialEffect.GetModifyValue(_id, -1, 146, EDataModifyType.Add, currTrick);
		int effectChangeDist = DomainManager.SpecialEffect.GetModifyValue(_id, 272, EDataModifyType.Add, minDist, maxDist);
		int acupointChangeDist = _acupointCollection.CalcAcupointParam(2);
		int changeDist = Math.Max(effectChangeDist, acupointChangeDist);
		minDist = (short)Math.Clamp(minDist + changeDist, 20, rangeMid - rangeMidMaxDelta);
		maxDist = (short)Math.Clamp(maxDist - changeDist, rangeMid + rangeMidMaxDelta, 120);
		return new OuterAndInnerShorts(minDist, maxDist);
	}

	public void UpdateTeammateCommandOnPrepared(DataContext context)
	{
		List<sbyte> cmdList = GetCurrTeammateCommands();
		if (cmdList.Exists((sbyte x) => x >= 0 && TeammateCommand.Instance[x].RequireTrick))
		{
			UpdateAttackCommandWeaponAndTrick(context);
		}
		if (cmdList.Exists((sbyte x) => x >= 0 && TeammateCommand.Instance[x].RequireAttackSkill))
		{
			UpdateAttackCommandSkill(context);
		}
		if (cmdList.Exists((sbyte x) => x >= 0 && TeammateCommand.Instance[x].RequireDefendSkill))
		{
			UpdateDefendCommandSkill(context);
		}
		UpdateTeammateCommandInvokers();
	}

	public void UpdateAttackCommandWeaponAndTrick(DataContext context)
	{
		List<ItemKey> weaponRandomPool = ObjectPool<List<ItemKey>>.Instance.Get();
		weaponRandomPool.Clear();
		for (int i = 0; i < 3; i++)
		{
			ItemKey weaponKey = _weapons[i];
			if (weaponKey.IsValid() && DomainManager.Item.GetBaseItem(weaponKey).GetCurrDurability() > 0)
			{
				weaponRandomPool.Add(weaponKey);
			}
		}
		if (weaponRandomPool.Count == 0)
		{
			for (int j = 3; j < 7; j++)
			{
				ItemKey weaponKey2 = _weapons[j];
				if (weaponKey2.IsValid())
				{
					weaponRandomPool.Add(weaponKey2);
				}
			}
		}
		ItemKey cmdWeaponKey = weaponRandomPool[context.Random.Next(0, weaponRandomPool.Count)];
		CombatWeaponData weaponData = _combatDomain.GetElement_WeaponDataDict(cmdWeaponKey.Id);
		sbyte[] tricks = weaponData.GetWeaponTricks();
		ObjectPool<List<ItemKey>>.Instance.Return(weaponRandomPool);
		_combatDomain.ChangeWeapon(context, this, _weapons.IndexOf(cmdWeaponKey));
		SetUsingWeaponIndex(Array.IndexOf(_weapons, cmdWeaponKey), context);
		SetAttackCommandWeaponKey(cmdWeaponKey, context);
		SetAttackCommandTrickType(tricks[context.Random.Next(0, tricks.Length)], context);
		_combatDomain.UpdateTeammateCommandUsable(context, this, -1);
	}

	public void UpdateAttackCommandSkill(DataContext context)
	{
		int maxScore = 0;
		List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
		skillRandomPool.Clear();
		for (int i = 0; i < _attackSkillList.Count; i++)
		{
			short skillId = _attackSkillList[i];
			if (skillId < 0)
			{
				continue;
			}
			int score = AiController.CalcAttackSkillScore(context.Random, skillId);
			if (score >= maxScore)
			{
				if (score > maxScore)
				{
					maxScore = score;
					skillRandomPool.Clear();
				}
				skillRandomPool.Add(skillId);
			}
		}
		SetAttackCommandSkillId((short)((skillRandomPool.Count > 0) ? skillRandomPool.GetRandom(context.Random) : (-1)), context);
		ObjectPool<List<short>>.Instance.Return(skillRandomPool);
		_combatDomain.UpdateTeammateCommandUsable(context, this, ETeammateCommandImplement.AttackSkill);
	}

	public void UpdateDefendCommandSkill(DataContext context)
	{
		List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
		skillRandomPool.Clear();
		for (int i = 0; i < _defenceSkillList.Count; i++)
		{
			short skillId = _defenceSkillList[i];
			if (skillId >= 0)
			{
				skillRandomPool.Add(skillId);
			}
		}
		SetDefendCommandSkillId((short)((skillRandomPool.Count > 0) ? skillRandomPool[context.Random.Next(0, skillRandomPool.Count)] : (-1)), context);
		ObjectPool<List<short>>.Instance.Return(skillRandomPool);
		_combatDomain.UpdateTeammateCommandUsable(context, this, -1);
	}

	public void UpdateTeammateCommandInvokers()
	{
		for (int i = 0; i < _currTeammateCommands.Count; i++)
		{
			sbyte cmdType = _currTeammateCommands[i];
			if (cmdType >= 0)
			{
				TeammateCommandItem cmdConfig = TeammateCommand.Instance[cmdType];
				ITeammateCommandInvoker invoker = TryCreateTeammateCommandInvoker(cmdConfig, i);
				if (invoker != null)
				{
					invoker.Setup();
					_teammateCommandInvokers.Add(invoker);
				}
			}
		}
	}

	private ITeammateCommandInvoker TryCreateTeammateCommandInvoker(TeammateCommandItem cmdConfig, int i)
	{
		ETeammateCommandType type = cmdConfig.Type;
		if (1 == 0)
		{
		}
		ITeammateCommandInvoker result;
		switch (type)
		{
		case ETeammateCommandType.Negative:
		{
			ETeammateCommandImplement implement2 = cmdConfig.Implement;
			if (1 == 0)
			{
			}
			ITeammateCommandInvoker teammateCommandInvoker = implement2 switch
			{
				ETeammateCommandImplement.InterruptSkill => new TeammateCommandInvokerCombatSkillProgress(_id, i), 
				ETeammateCommandImplement.InterruptOtherAction => new TeammateCommandInvokerOtherActionProgress(_id, i), 
				_ => new TeammateCommandInvokerFrame(_id, i), 
			};
			if (1 == 0)
			{
			}
			result = teammateCommandInvoker;
			break;
		}
		case ETeammateCommandType.GearMate:
		{
			ETeammateCommandImplement implement = cmdConfig.Implement;
			if (1 == 0)
			{
			}
			ITeammateCommandInvoker teammateCommandInvoker = implement switch
			{
				ETeammateCommandImplement.GearMateA => new TeammateCommandInvokerCooldown(_id, i), 
				ETeammateCommandImplement.GearMateB => new TeammateCommandInvokerAutoDefend(_id, i), 
				_ => null, 
			};
			if (1 == 0)
			{
			}
			result = teammateCommandInvoker;
			break;
		}
		default:
			result = null;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public bool UpdateTeammateCharStatus(DataContext context)
	{
		if (!DomainManager.Combat.IsMainCharacter(this))
		{
			return false;
		}
		int[] charList = DomainManager.Combat.GetCharacterList(IsAlly);
		for (int i = 1; i < charList.Length; i++)
		{
			int charId = charList[i];
			if (charId < 0)
			{
				continue;
			}
			CombatCharacter teammateChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			if (teammateChar.GetExecutingTeammateCommand() < 0)
			{
				if (TeammateBeforeMainChar == charId)
				{
					TeammateBeforeMainChar = -1;
				}
				if (TeammateAfterMainChar == charId)
				{
					TeammateAfterMainChar = -1;
				}
				continue;
			}
			if (teammateChar.ExecutingTeammateCommandConfig.IntoCombatField && !teammateChar.GetVisible())
			{
				if (teammateChar.ExecutingTeammateCommandConfig.PosOffset > 0)
				{
					TeammateBeforeMainChar = charId;
				}
				else
				{
					TeammateAfterMainChar = charId;
				}
			}
			if (teammateChar.UpdateTeammateCommandState(context))
			{
				ActingTeammateCommandChar = teammateChar;
				StateMachine.TranslateState(CombatCharacterStateType.TeammateCommand);
				return true;
			}
		}
		return false;
	}

	public bool PreparingOrDoingTeammateCommand()
	{
		return TeammateAfterMainChar >= 0 || TeammateBeforeMainChar >= 0;
	}

	public bool PreparingTeammateCommand()
	{
		return (TeammateAfterMainChar >= 0 && _combatDomain.GetElement_CombatCharacterDict(TeammateAfterMainChar).TeammateCommandLeftPrepareFrame >= 0) || (TeammateBeforeMainChar >= 0 && _combatDomain.GetElement_CombatCharacterDict(TeammateBeforeMainChar).TeammateCommandLeftPrepareFrame >= 0);
	}

	public int CalcTeammateCommandRepairDurabilityValue(ItemKey equipKey)
	{
		EquipmentBase item = (equipKey.IsValid() ? DomainManager.Item.TryGetBaseEquipment(equipKey) : null);
		if (item == null)
		{
			return 0;
		}
		short current = item.GetCurrDurability();
		int costed = DomainManager.Combat.EquipmentOldDurability.GetValueOrDefault(equipKey) - current;
		if (costed <= 0)
		{
			return 0;
		}
		sbyte repairType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(equipKey.ItemType, equipKey.TemplateId);
		short attainment = _character.GetLifeSkillAttainment(repairType);
		return CFormula.CalcPartRepairDurabilityValue(item.GetGrade(), attainment, current, costed);
	}

	public void ChangeAffectingDefenseSkillLeftFrame(DataContext context, CValuePercent delta)
	{
		if (_affectingDefendSkillId < 0)
		{
			return;
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Defend)
		{
			int deltaFrame = TeammateCommandTotalFrame * delta;
			int newLeftFrame = TeammateCommandLeftFrame + deltaFrame;
			TeammateCommandLeftFrame = (short)Math.Clamp(newLeftFrame, 1, TeammateCommandTotalFrame);
			return;
		}
		int deltaFrame2 = DefendSkillTotalFrame * delta;
		DefendSkillLeftFrame = (short)Math.Clamp(DefendSkillLeftFrame + deltaFrame2, 1, DefendSkillTotalFrame);
		if (DefendSkillLeftFrame <= 1)
		{
			SetAffectingDefendSkillId(-1, context);
			DomainManager.Combat.SetProperLoopAniAndParticle(context, this);
		}
	}

	public bool AiCanOperate(bool canOperate)
	{
		if (DomainManager.Combat.TaiwuInCombat && IsAlly)
		{
			return canOperate;
		}
		return true;
	}

	public bool AiCanCast(short skillId)
	{
		CombatSkillData skillData;
		return DomainManager.Combat.TryGetCombatSkillData(_id, skillId, out skillData) && skillData.GetCanUse();
	}

	public sbyte AiGetCombatSkillRequireTrickType(short skillId)
	{
		if (skillId < 0)
		{
			return -1;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: _id, skillId: skillId), out var skill))
		{
			return -1;
		}
		List<NeedTrick> skillTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		skillTricks.Clear();
		DomainManager.CombatSkill.GetCombatSkillCostTrick(skill, skillTricks);
		skillTricks.RemoveAll((NeedTrick needTrick) => !_weaponTricks.Exist(needTrick.TrickType) || GetTrickCount(needTrick.TrickType) >= needTrick.NeedCount);
		sbyte require = (sbyte)((skillTricks.Count > 0) ? skillTricks[0].TrickType : (-1));
		ObjectPool<List<NeedTrick>>.Instance.Return(skillTricks);
		return require;
	}

	public bool AiCastCheckRange()
	{
		short currentDistance = DomainManager.Combat.GetCurrentDistance();
		OuterAndInnerShorts attackRange = GetAttackRange();
		int outOfRange = Math.Max(attackRange.Outer - currentDistance, currentDistance - attackRange.Inner);
		if (outOfRange < 0)
		{
			return false;
		}
		int addRange = GetCharacter().GetCombatSkillGridCost(GetPreparingSkillId()) * 5 + 5;
		return addRange >= outOfRange;
	}

	public int AiGetFirstChangeableWeaponIndex(int minIndex, int maxIndex)
	{
		short distance = DomainManager.Combat.GetCurrentDistance();
		int from = Math.Max(minIndex, 0);
		int to = Math.Min(maxIndex + 1, _weapons.Length);
		for (int i = from; i < to; i++)
		{
			ItemKey weaponKey = _weapons[i];
			if (!weaponKey.IsValid())
			{
				continue;
			}
			CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(weaponKey.Id);
			if (weaponData.GetCanChangeTo())
			{
				OuterAndInnerShorts range = CalcAttackRangeImmediate(-1, i);
				if (range.Outer <= distance && distance <= range.Inner)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public bool AiCanRepair(ItemKey toolKey, ItemKey itemKey)
	{
		return DomainManager.Building.CheckRepairConditionIsMeet(_id, toolKey, itemKey, BuildingBlockKey.Invalid);
	}

	public bool AiCanRepair(IEnumerable<ItemKey> tools, ItemKey itemKey)
	{
		return tools.Any((ItemKey tool) => AiCanRepair(tool, itemKey));
	}

	public (ItemKey targetKey, ItemKey toolKey) AiSelectRepairTarget(IEnumerable<sbyte> equipmentSlots)
	{
		DataContext context = DomainManager.Combat.Context;
		ItemKey[] equipments = GetCharacter().GetEquipment();
		List<ItemKey> tools = ObjectPool<List<ItemKey>>.Instance.Get();
		tools.Clear();
		tools.AddRange(from itemKey in GetValidItems()
			where itemKey.ItemType == 6
			select itemKey);
		List<ItemKey> targets = ObjectPool<List<ItemKey>>.Instance.Get();
		targets.Clear();
		targets.AddRange(from itemKey in equipmentSlots.Select((sbyte slot) => equipments[slot]).Where(delegate(ItemKey itemKey)
			{
				ItemKey itemKey2 = itemKey;
				return itemKey2.IsValid();
			})
			let baseItem = DomainManager.Item.GetBaseItem(itemKey)
			where baseItem.GetCurrDurability() <= 0
			where AiCanRepair(tools, itemKey)
			select itemKey);
		(ItemKey, ItemKey) result = (ItemKey.Invalid, ItemKey.Invalid);
		if (targets.Count > 0)
		{
			ItemKey targetKey = targets.GetRandom(context.Random);
			ItemKey toolKey = tools.First((ItemKey toolKey2) => AiCanRepair(toolKey2, targetKey));
			result = (targetKey, toolKey);
		}
		ObjectPool<List<ItemKey>>.Instance.Return(tools);
		ObjectPool<List<ItemKey>>.Instance.Return(targets);
		return result;
	}

	public IEnumerable<(ItemKey weaponKey, int index)> AiCanChangeToWeapons()
	{
		for (int i = 0; i < _weapons.Length; i++)
		{
			if (i == _usingWeaponIndex)
			{
				continue;
			}
			ItemKey weaponKey = _weapons[i];
			if (weaponKey.IsValid())
			{
				CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(weaponKey.Id);
				if (weaponData.GetCanChangeTo())
				{
					yield return (weaponKey: weaponKey, index: i);
				}
			}
		}
	}

	int IExpressionConverter.GetPersonalityValue(int personalityType)
	{
		return GetPersonalityValue((sbyte)personalityType);
	}

	int IExpressionConverter.GetConsummateLevel()
	{
		return IsAlly ? GlobalConfig.Instance.MaxConsummateLevel : _character.GetConsummateLevel();
	}

	int IExpressionConverter.GetBehaviorType()
	{
		return _character.GetBehaviorType();
	}

	public string GetWrappedFullAnimationName(string animation)
	{
		if (BossConfig != null)
		{
			return BossConfig.AniPrefix[_bossPhase] + animation;
		}
		if (AnimalConfig != null)
		{
			return AnimalConfig.AniPrefix + animation;
		}
		return animation;
	}

	public string GetIdleAni()
	{
		int usingWeaponIndex = _usingWeaponIndex;
		if (usingWeaponIndex < 0)
		{
			return "C_000";
		}
		short weaponTemplateId = _weapons[usingWeaponIndex].TemplateId;
		if (weaponTemplateId < 0)
		{
			return "C_000";
		}
		string idleAni = Config.Weapon.Instance[weaponTemplateId].IdleAni;
		return (!string.IsNullOrEmpty(idleAni)) ? idleAni : ((GetMobilityLevel() == 0) ? "C_000" : "C_000");
	}

	public string GetWalkForwardAni()
	{
		OtherActionTypeItem otherActionConfig = PreparingOtherActionTypeConfig;
		if (IsActorSkeleton && otherActionConfig != null && !string.IsNullOrEmpty(InNormalWalk ? otherActionConfig.ForwardAnim : otherActionConfig.ForwardFastAnim))
		{
			return InNormalWalk ? otherActionConfig.ForwardAnim : otherActionConfig.ForwardFastAnim;
		}
		string commonForwardAni = (InNormalWalk ? "M_001" : "MR_001");
		int usingWeaponIndex = GetUsingWeaponIndex();
		if (usingWeaponIndex < 0)
		{
			return commonForwardAni;
		}
		short weaponTemplateId = GetWeapons()[usingWeaponIndex].TemplateId;
		if (weaponTemplateId < 0)
		{
			return commonForwardAni;
		}
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponTemplateId];
		string forwardAni = (InNormalWalk ? weaponConfig.ForwardAni : weaponConfig.FastForwardAni);
		return (!string.IsNullOrEmpty(forwardAni)) ? forwardAni : commonForwardAni;
	}

	public string GetWalkBackwardAni()
	{
		OtherActionTypeItem otherActionConfig = PreparingOtherActionTypeConfig;
		if (IsActorSkeleton && otherActionConfig != null && !string.IsNullOrEmpty(InNormalWalk ? otherActionConfig.BackwardAnim : otherActionConfig.BackwardFastAnim))
		{
			return InNormalWalk ? otherActionConfig.BackwardAnim : otherActionConfig.BackwardFastAnim;
		}
		string commonBackwardAni = (InNormalWalk ? "M_002" : "MR_002");
		int usingWeaponIndex = GetUsingWeaponIndex();
		if (usingWeaponIndex < 0)
		{
			return commonBackwardAni;
		}
		short weaponTemplateId = GetWeapons()[usingWeaponIndex].TemplateId;
		if (weaponTemplateId < 0)
		{
			return commonBackwardAni;
		}
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponTemplateId];
		string backwardAni = (InNormalWalk ? weaponConfig.BackwardAni : weaponConfig.FastBackwardAni);
		return (!string.IsNullOrEmpty(backwardAni)) ? backwardAni : commonBackwardAni;
	}

	public sbyte GetNormalAttackPosition(sbyte trickType)
	{
		if (BossConfig != null)
		{
			return BossConfig.AttackDistances[_bossPhase][_usingWeaponIndex];
		}
		if (AnimalConfig != null)
		{
			return AnimalConfig.AttackDistances[_usingWeaponIndex];
		}
		return Config.TrickType.Instance[trickType].AttackDistance[UsingWeaponAction];
	}

	public string GetNormalAttackParticle(sbyte trickType)
	{
		if (BossConfig != null)
		{
			return $"{BossConfig.AttackParticles[_bossPhase]}_{PursueAttackCount}{AttackPostfix}";
		}
		if (AnimalConfig != null)
		{
			return AnimalConfig.AttackParticles[_usingWeaponIndex];
		}
		return $"{Config.TrickType.Instance[trickType].AttackParticles[UsingWeaponAction]}_{PursueAttackCount}";
	}

	public string GetNormalAttackSound(sbyte trickType)
	{
		if (BossConfig != null)
		{
			return $"{BossConfig.AttackSounds[_bossPhase]}_{PursueAttackCount}";
		}
		if (AnimalConfig != null)
		{
			return AnimalConfig.AttackSounds[_usingWeaponIndex] + (_character.Template.IsChaiShanYuanZu() ? $"_{PursueAttackCount}" : string.Empty);
		}
		return $"{Config.TrickType.Instance[trickType].SoundEffects[UsingWeaponAction]}_{PursueAttackCount}{UsingWeaponConfig.SwingSoundsSuffix}";
	}

	public string GetNormalAttackAnimation(sbyte trickType)
	{
		if (BossConfig != null)
		{
			return $"{BossConfig.AttackAnimation}_{PursueAttackCount}{AttackPostfix}";
		}
		if (AnimalConfig != null)
		{
			return Config.TrickType.Instance[trickType].AttackAnimations[UsingWeaponAction];
		}
		return $"{Config.TrickType.Instance[trickType].AttackAnimations[UsingWeaponAction]}_{PursueAttackCount}";
	}

	public PrepareAttackEffect GetPrepareAttackAni(sbyte trickType, int aniIndex)
	{
		TrickTypeItem trickData = Config.TrickType.Instance[trickType];
		string aniName;
		string fullAniName;
		if (BossConfig == null && AnimalConfig == null)
		{
			aniName = (fullAniName = trickData.AttackAnimations[aniIndex] + "_7");
		}
		else if (BossConfig != null)
		{
			string postfix = BossConfig.AttackEffectPostfix[GetUsingWeaponIndex()];
			aniName = BossConfig.AttackAnimation + "_7" + postfix;
			fullAniName = BossConfig.AniPrefix[GetBossPhase()] + aniName;
		}
		else
		{
			aniName = trickData.AttackAnimations[aniIndex] + "_7";
			fullAniName = AnimalConfig.AniPrefix + aniName;
		}
		return new PrepareAttackEffect(aniName, fullAniName);
	}

	public AttackEffect GetAttackEffect(GameData.Domains.Item.Weapon weapon, sbyte trickType)
	{
		AttackEffect result = default(AttackEffect);
		TrickTypeItem trick = Config.TrickType.Instance[trickType];
		sbyte action = weapon.GetWeaponAction();
		short defendSkillId = GetAffectingDefendSkillId();
		CombatSkillItem defendSkillConfig = Config.CombatSkill.Instance[defendSkillId];
		if (BossConfig != null)
		{
			int weaponIndex = GetUsingWeaponIndex();
			int phase = GetBossPhase();
			if (GetIsFightBack() && defendSkillId >= 0)
			{
				result.AniName = defendSkillConfig.FightBackAnimation;
				result.FullAniName = BossConfig.AniPrefix[phase] + result.AniName;
				result.Particle = BossConfig.DefendSkillParticlePrefix[phase] + defendSkillConfig.FightBackParticle;
				result.Sound = BossConfig.DefendSkillSoundPrefix[phase] + defendSkillConfig.FightBackSound;
			}
			else
			{
				string postfix = BossConfig.AttackEffectPostfix[weaponIndex];
				result.AniName = $"{BossConfig.AttackAnimation}_{PursueAttackCount}{postfix}";
				result.FullAniName = BossConfig.AniPrefix[phase] + result.AniName;
				result.Particle = $"{BossConfig.AttackParticles[phase]}_{PursueAttackCount}{postfix}";
				result.Sound = $"{BossConfig.AttackSounds[phase]}_{PursueAttackCount}";
			}
		}
		else if (AnimalConfig != null)
		{
			int weaponIndex2 = GetUsingWeaponIndex();
			result.AniName = trick.AttackAnimations.GetClampedIndexValueWithWarning(action, "GetAttackEffect");
			result.Particle = AnimalConfig.AttackParticles[weaponIndex2];
			result.Sound = AnimalConfig.AttackSounds[weaponIndex2];
			if (_character.Template.IsChaiShanYuanZu())
			{
				string pursueSuffix = $"_{PursueAttackCount}";
				result.AniName += pursueSuffix;
				result.Particle += pursueSuffix;
				result.Sound += pursueSuffix;
			}
			result.FullAniName = AnimalConfig.AniPrefix + result.AniName;
		}
		else if (GetIsFightBack() && defendSkillId >= 0 && !string.IsNullOrEmpty(defendSkillConfig.FightBackAnimation))
		{
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[defendSkillId];
			string fullAniName = (result.AniName = skillConfig.FightBackAnimation);
			result.FullAniName = fullAniName;
			result.Particle = skillConfig.FightBackParticle;
			result.Sound = skillConfig.FightBackSound;
		}
		else
		{
			string fullAniName = (result.AniName = $"{trick.AttackAnimations[action]}_{PursueAttackCount}");
			result.FullAniName = fullAniName;
			result.Particle = $"{trick.AttackParticles[action]}_{PursueAttackCount}";
			result.Sound = $"{trick.SoundEffects[action]}_{PursueAttackCount}";
			result.Sound += Config.Weapon.Instance[weapon.GetTemplateId()].SwingSoundsSuffix;
		}
		return result;
	}

	public string GetAvoidAni(sbyte hitType)
	{
		if (BossConfig != null || AnimalConfig != null)
		{
			return CombatAnimationConstants.AvoidAni[hitType];
		}
		int usingWeaponIndex = GetUsingWeaponIndex();
		if (usingWeaponIndex < 0)
		{
			return CombatAnimationConstants.AvoidAni[hitType];
		}
		short weaponTemplateId = GetWeapons()[usingWeaponIndex].TemplateId;
		if (weaponTemplateId < 0)
		{
			return CombatAnimationConstants.AvoidAni[hitType];
		}
		string[] avoidAnis = Config.Weapon.Instance[weaponTemplateId].AvoidAnis;
		return (avoidAnis != null) ? avoidAnis[hitType] : CombatAnimationConstants.AvoidAni[hitType];
	}

	public string GetBeHitAni(int injuryLevel)
	{
		int usingWeaponIndex = GetUsingWeaponIndex();
		if (usingWeaponIndex < 0)
		{
			return CombatAnimationConstants.InjuryAni[injuryLevel];
		}
		short weaponTemplateId = GetWeapons()[usingWeaponIndex].TemplateId;
		if (weaponTemplateId < 0)
		{
			return CombatAnimationConstants.InjuryAni[injuryLevel];
		}
		string[] beHitAnis = Config.Weapon.Instance[weaponTemplateId].HittedAnis;
		return (beHitAnis != null) ? beHitAnis[injuryLevel] : CombatAnimationConstants.InjuryAni[injuryLevel];
	}

	public void PlayBeHitSound(DataContext context, WeaponItem weapon, CombatCharacter attacker, bool critical)
	{
		if (attacker.NoBlockAttack || critical)
		{
			DomainManager.Combat.PlayHitSound(context, this, weapon);
		}
		else
		{
			DomainManager.Combat.PlayBlockSound(context, this);
		}
	}

	public BlockEffect GetBlockEffect(IRandomSource random)
	{
		if (BossConfig == null && AnimalConfig == null)
		{
			WeaponItem weaponConfig = GetWeaponData().Template;
			int effectIndex = random.Next(weaponConfig.BlockAnis.Count);
			return new BlockEffect(weaponConfig.BlockAnis[effectIndex], weaponConfig.BlockParticles[effectIndex]);
		}
		string aniName = CombatAnimationConstants.SpecialCharBlockAni[random.Next(CombatAnimationConstants.SpecialCharBlockAni.Count)];
		string aniPrefix = ((BossConfig != null) ? BossConfig.AniPrefix[GetBossPhase()] : AnimalConfig.AniPrefix);
		return new BlockEffect(aniName, "Particle_" + aniPrefix + aniName);
	}

	public void PlayWinAnimation(DataContext context)
	{
		if (IsActorSkeleton)
		{
			sbyte gender = GetCharacter().GetDisplayingGender();
			int aniIndex = ((gender < 0 || gender >= 2) ? 1 : gender);
			SetAnimationToPlayOnce(CombatAnimationConstants.WinAni[aniIndex], context);
			SetAnimationToLoop(CombatAnimationConstants.WinAniLoop[aniIndex], context);
		}
		else
		{
			SetAnimationToLoop(GetIdleAni(), context);
		}
	}

	short ICombatCharacterBridge.GetDisorderOfQi()
	{
		return GetCharacter().GetDisorderOfQi();
	}

	EHealthType ICombatCharacterBridge.GetHealthType()
	{
		return _character.GetHealthType();
	}

	public int CalcAccessoryReducePoisonResist(sbyte poisonType, sbyte poisonLevel)
	{
		int reducePoisonAssist = 0;
		CValuePercent percent = GlobalConfig.Instance.AccessoryReducePoisonPercent;
		ItemKey[] equipment = _character.GetEquipment();
		for (int slot = 8; slot <= 10; slot++)
		{
			if (DomainManager.Combat.CheckEquipmentPoison(equipment[slot], out var attachedPoisons))
			{
				var (value, level) = attachedPoisons.GetValueAndLevel(poisonType);
				if (level > poisonLevel)
				{
					reducePoisonAssist -= value * percent;
				}
			}
		}
		return reducePoisonAssist;
	}

	public bool AllRawCreateSlotsBlocked(int effectId)
	{
		SpecialEffectItem config = Config.SpecialEffect.Instance[effectId];
		return !GetAllCanRawCreateEquipmentSlots(config.RawCreateType).Any();
	}

	public IEnumerable<sbyte> GetAllCanRawCreateEquipmentSlots(ESpecialEffectRawCreateType type)
	{
		if (1 == 0)
		{
		}
		int num = type switch
		{
			ESpecialEffectRawCreateType.Sword => 0, 
			ESpecialEffectRawCreateType.Blade => 0, 
			ESpecialEffectRawCreateType.Polearm => 0, 
			ESpecialEffectRawCreateType.Armor => 1, 
			ESpecialEffectRawCreateType.Accessory => 2, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int itemType = num;
		if (1 == 0)
		{
		}
		num = type switch
		{
			ESpecialEffectRawCreateType.Sword => 8, 
			ESpecialEffectRawCreateType.Blade => 9, 
			ESpecialEffectRawCreateType.Polearm => 10, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int itemSubType = num;
		ItemKey[] equipments = _character.GetEquipment();
		foreach (sbyte rawCreateSlot in SharedConstValue.AllRawCreateSlots)
		{
			ItemKey equipment = equipments[rawCreateSlot];
			if (!equipment.IsValid() || (itemType >= 0 && itemType != equipment.ItemType) || _rawCreateCollection.Contains(equipment))
			{
				continue;
			}
			short equipmentSubType = ItemTemplateHelper.GetItemSubType(equipment.ItemType, equipment.TemplateId);
			if (itemSubType < 0 || itemSubType == equipmentSubType)
			{
				ItemBase baseItem = DomainManager.Item.GetBaseItem(equipment);
				if (baseItem.GetCurrDurability() > 0)
				{
					yield return rawCreateSlot;
				}
			}
		}
	}

	public void InvokeRawCreate(DataContext context, int effectId)
	{
		bool willSkip = DomainManager.Combat.AiOptions.AutoUnlock && DomainManager.Combat.AiOptions.SkipRawCreate;
		if ((!DomainManager.Combat.GetAutoCombat() || !AiCanOperate(willSkip)) && !_rawCreateEffects.Contains(effectId))
		{
			SpecialEffectItem config = Config.SpecialEffect.Instance[effectId];
			if (GetAllCanRawCreateEquipmentSlots(config.RawCreateType).Any())
			{
				_rawCreateEffects.Add(effectId);
				SetRawCreateEffects(_rawCreateEffects, context);
			}
		}
	}

	public void IgnoreRawCreate(DataContext context, int effectId)
	{
		if (_rawCreateEffects.Remove(effectId))
		{
			SetRawCreateEffects(_rawCreateEffects, context);
		}
	}

	public void IgnoreAllRawCreate(DataContext context)
	{
		if (_rawCreateEffects.Count != 0)
		{
			_rawCreateEffects.Clear();
			SetRawCreateEffects(_rawCreateEffects, context);
		}
	}

	public void AutoAllRawCreate(DataContext context)
	{
		if (_rawCreateEffects.Count == 0)
		{
			return;
		}
		ItemKey[] equipments = _character.GetEquipment();
		List<sbyte> validSlots = ObjectPool<List<sbyte>>.Instance.Get();
		for (int i = _rawCreateEffects.Count - 1; i >= 0; i--)
		{
			int effectId = _rawCreateEffects[i];
			SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectId];
			validSlots.Clear();
			foreach (sbyte slot in GetAllCanRawCreateEquipmentSlots(effectConfig.RawCreateType))
			{
				if (ItemTemplateHelper.GetAllowRawCreate(equipments[slot].ItemType, equipments[slot].TemplateId))
				{
					validSlots.Add(slot);
				}
			}
			if (validSlots.Count > 0)
			{
				sbyte validSlot = validSlots.GetRandom(context.Random);
				DoRawCreate(context, effectId, validSlot, equipments[validSlot].TemplateId);
			}
			else
			{
				IgnoreRawCreate(context, effectId);
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(validSlots);
	}

	public bool DoRawCreate(DataContext context, int effectId, sbyte equipmentSlot, short newTemplateId)
	{
		if (!SharedConstValue.AllRawCreateSlots.Contains(equipmentSlot))
		{
			return false;
		}
		ItemKey[] equipments = _character.GetEquipment();
		ItemKey oldKey = equipments[equipmentSlot];
		if (!oldKey.IsValid() || _rawCreateCollection.Contains(oldKey))
		{
			return false;
		}
		sbyte itemType = oldKey.ItemType;
		if (1 == 0)
		{
		}
		int num = itemType switch
		{
			0 => Config.Weapon.Instance.Count, 
			1 => Config.Armor.Instance.Count, 
			2 => Config.Accessory.Instance.Count, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int count = num;
		if (newTemplateId < 0 || newTemplateId >= count)
		{
			return false;
		}
		Inventory inventory = _character.GetInventory();
		short materialId = ItemTemplateHelper.GetRawCreateMaterial(oldKey.ItemType, oldKey.TemplateId, newTemplateId);
		int materialCount = ((materialId >= 0) ? inventory.GetInventoryItemCount(5, materialId) : 0);
		int requireMaterialCount = Config.SpecialEffect.Instance[effectId].RawCreateRequireMaterialCount;
		if (materialId >= 0 && materialCount < requireMaterialCount)
		{
			return false;
		}
		if (!_rawCreateEffects.Remove(effectId))
		{
			return false;
		}
		SetRawCreateEffects(_rawCreateEffects, context);
		if (materialId >= 0)
		{
			_character.RemoveMultiInventoryItem(context, 5, materialId, requireMaterialCount);
		}
		ItemKey newKey = DomainManager.Item.CreateItem(context, oldKey.ItemType, newTemplateId);
		newKey = (equipments[equipmentSlot] = CopyEquipmentData(context, oldKey, newKey));
		_character.SetEquipment(equipments, context);
		SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectId];
		short equipmentEffectId = effectConfig.RawCreateEffect;
		DomainManager.Item.AddExternEquipmentEffect(context, newKey, equipmentEffectId);
		DomainManager.SpecialEffect.AddEquipmentMastery(context, _id, newKey);
		long specialEffectId = DomainManager.SpecialEffect.AddEquipmentEffect(context, _id, newKey, equipmentEffectId);
		ItemBase newItem = DomainManager.Item.GetBaseItem(newKey);
		DomainManager.Combat.EquipmentOldDurability[newKey] = newItem.GetCurrDurability();
		_rawCreateCollection.Add(newKey, oldKey, effectId, specialEffectId);
		SetRawCreateCollection(_rawCreateCollection, context);
		DomainManager.Combat.ShowSpecialEffectTips(_id, effectConfig.RawCreateTips, 0);
		switch (oldKey.ItemType)
		{
		case 0:
		{
			_weapons[equipmentSlot] = newKey;
			SetWeapons(_weapons, context);
			DomainManager.Combat.InitWeaponData(context, this, equipmentSlot);
			CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(newKey.Id);
			if (equipmentSlot == _usingWeaponIndex)
			{
				SetWeaponTricks(weaponData.GetWeaponTricks(), context);
			}
			return true;
		}
		case 1:
		{
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				if (EquipmentSlotHelper.GetSlotByBodyPartType(bodyPart) == equipmentSlot)
				{
					Armors[bodyPart] = newKey;
				}
			}
			return true;
		}
		default:
			return true;
		}
	}

	private ItemKey CopyEquipmentData(DataContext context, ItemKey oldKey, ItemKey newKey)
	{
		EquipmentBase oldEquipment = DomainManager.Item.GetBaseEquipment(oldKey);
		EquipmentBase newEquipment = DomainManager.Item.GetBaseEquipment(newKey);
		ItemBase result = newEquipment;
		newEquipment.ApplyDurabilityEquipmentEffectChange(context, newEquipment.GetEquipmentEffectId(), oldEquipment.GetEquipmentEffectId());
		newEquipment.SetEquipmentEffectId(oldEquipment.GetEquipmentEffectId(), context);
		newEquipment.SetCurrDurability(newEquipment.GetMaxDurability(), context);
		if (ModificationStateHelper.IsActive(oldKey.ModificationState, 2))
		{
			RefiningEffects refiningEffects = DomainManager.Item.GetRefinedEffects(oldKey);
			ItemBase itemBase = DomainManager.Item.GetBaseItem(newKey);
			result = DomainManager.Item.SetRefinedEffects(context, itemBase, refiningEffects);
			newKey = result.GetItemKey();
		}
		if (ModificationStateHelper.IsActive(oldKey.ModificationState, 1))
		{
			FullPoisonEffects poisonEffects = DomainManager.Item.GetPoisonEffects(oldKey);
			result = DomainManager.Item.SetAttachedPoisons(context, result, poisonEffects);
			newKey = result.GetItemKey();
		}
		DomainManager.Item.SetOwner(newKey, ItemOwnerType.CharacterEquipment, DomainManager.Taiwu.GetTaiwuCharId());
		return newKey;
	}

	public void RevertRawCreate(DataContext context, ItemKey newKey)
	{
		ItemKey[] equipments = _character.GetEquipment();
		int equipmentSlot = equipments.IndexOf(newKey);
		Tester.Assert(equipmentSlot >= 0, "equipmentSlot >= 0");
		int effectId = _rawCreateCollection.Effects[newKey];
		long specialEffectId = _rawCreateCollection.SpecialEffects[newKey];
		short equipmentEffectId = Config.SpecialEffect.Instance[effectId].RawCreateEffect;
		_rawCreateCollection.Remove(newKey, out var oldKey);
		SetRawCreateCollection(_rawCreateCollection, context);
		equipments[equipmentSlot] = oldKey;
		_character.SetEquipment(equipments, context);
		DomainManager.Item.RemoveItem(context, newKey);
		DomainManager.Item.RemoveExternEquipmentEffect(context, newKey, equipmentEffectId);
		DomainManager.SpecialEffect.Remove(context, specialEffectId);
		int weaponIndex = _weapons.IndexOf(newKey);
		if (weaponIndex >= 0)
		{
			DomainManager.Combat.RemoveWeaponData(newKey);
			_weapons[weaponIndex] = oldKey;
			CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(oldKey.Id);
			SetWeaponTricks(weaponData.GetWeaponTricks(), context);
			SetWeapons(_weapons, context);
		}
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (EquipmentSlotHelper.GetSlotByBodyPartType(bodyPart) == equipmentSlot)
			{
				Armors[bodyPart] = oldKey;
			}
		}
	}

	public void RevertAllRawCreates(DataContext context)
	{
		ItemKey[] equipments = _character.GetEquipment();
		foreach (sbyte slot in SharedConstValue.AllRawCreateSlots)
		{
			if (_rawCreateCollection.Contains(equipments[slot]))
			{
				equipments[slot] = _rawCreateCollection.Sources[equipments[slot]];
			}
		}
		if (_rawCreateCollection.Any())
		{
			_character.SetEquipment(equipments, context);
		}
		foreach (ItemKey key in _rawCreateCollection.Effects.Keys)
		{
			DomainManager.Item.RemoveItem(context, key);
		}
		_rawCreateCollection.Clear();
	}

	private void ListenCharacterField(ushort fieldId, DataModificationHandler handler)
	{
		DataUid uid = new DataUid(4, 0, (ulong)_id, fieldId);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, DataHandlerKey, handler);
		_markDataUids.Add(uid);
	}

	public void RegisterMarkHandler()
	{
		ListenCharacterField(58, UpdateWugMark);
		ListenCharacterField(21, UpdateQiDisorderMark);
		ListenCharacterField(19, UpdateHealthMark);
	}

	public void UnRegisterMarkHandler()
	{
		foreach (DataUid uid in _markDataUids)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, DataHandlerKey);
		}
		_markDataUids.Clear();
	}

	public bool CheckImmunityAndShowEffect(EMarkType markType)
	{
		if (!Immunity.IsImmune(markType))
		{
			return false;
		}
		if (1 == 0)
		{
		}
		int num = markType switch
		{
			EMarkType.Outer => 1700, 
			EMarkType.Inner => 1699, 
			EMarkType.Flaw => 1702, 
			EMarkType.Acupoint => 1703, 
			EMarkType.Mind => 1701, 
			EMarkType.Fatal => 1704, 
			EMarkType.Die => 1705, 
			EMarkType.Health => 1708, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int effectId = num;
		if (effectId < 0)
		{
			return true;
		}
		DomainManager.Combat.ShowSpecialEffectTips(_id, effectId, 0);
		return true;
	}

	public int CalcMarkTypeCount()
	{
		HashSet<int> counter = ObjectPool<HashSet<int>>.Instance.Get();
		counter.Clear();
		foreach (DefeatMarkKey allKey in _defeatMarkCollection.GetAllKeys(this))
		{
			counter.Add((int)allKey.Type);
		}
		int result = counter.Count;
		ObjectPool<HashSet<int>>.Instance.Return(counter);
		return result;
	}

	public void AddInjury(DataContext context, sbyte bodyPart, bool isInner, int value, bool updateDefeatMark = false, bool changeToOld = false)
	{
		if (value <= 0 || CheckImmunityAndShowEffect(isInner ? EMarkType.Inner : EMarkType.Outer))
		{
			return;
		}
		if (ChangeToMindMark)
		{
			AddMindMark(context, value, -1);
			return;
		}
		Injuries injuries = GetInjuries();
		sbyte injuryLevel = injuries.Get(bodyPart, isInner);
		if (injuryLevel < 6)
		{
			injuries.Change(bodyPart, isInner, value);
			SetInjuries(context, injuries, updateDefeatMark);
		}
		changeToOld = changeToOld || CheckEffectChangeToOld(context.Random, isInner);
		if (changeToOld)
		{
			ChangeToOldInjury(context, bodyPart, isInner, value);
		}
		Events.RaiseAddInjury(context, this, bodyPart, isInner, value, changeToOld);
	}

	private bool CheckEffectChangeToOld(IRandomSource random, bool inner)
	{
		int changeToOldOdds = DomainManager.SpecialEffect.ModifyValue(_id, (ushort)345, 0, inner ? 1 : 0, -1, -1, 0, 0, 0, 0);
		return random.CheckPercentProb(changeToOldOdds);
	}

	public void AddRandomInjury(DataContext context, bool inner, int count = 1, bool changeToOld = false)
	{
		if (CheckImmunityAndShowEffect(inner ? EMarkType.Inner : EMarkType.Outer))
		{
			return;
		}
		if (ChangeToMindMark)
		{
			AddMindMark(context, count, -1);
			return;
		}
		Injuries injuries = GetInjuries();
		List<sbyte> addedInjuryList = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		addedInjuryList.Clear();
		CRandom.GenerateToMaxInjuryPool(injuries, pool, inner);
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, count, pool))
		{
			sbyte exist = injuries.Get(bodyPart, inner);
			if (exist < 6)
			{
				injuries.Change(bodyPart, inner, 1);
				addedInjuryList.Add(bodyPart);
			}
		}
		SetInjuries(context, injuries);
		for (int i = 0; i < addedInjuryList.Count; i++)
		{
			if (changeToOld)
			{
				ChangeToOldInjury(context, addedInjuryList[i], inner, 1);
			}
			Events.RaiseAddInjury(context, this, addedInjuryList[i], inner, 1, changeToOld: false);
		}
		ObjectPool<List<sbyte>>.Instance.Return(addedInjuryList);
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	public void RemoveInjuryValue(DataContext context, sbyte bodyPart, bool inner, int value)
	{
		int[] steps = (inner ? _damageStepCollection.InnerDamageSteps : _damageStepCollection.OuterDamageSteps);
		int step = steps[bodyPart];
		int[] existValues = (inner ? _innerDamageValue : _outerDamageValue);
		int existValue = existValues[bodyPart];
		int maxRemoveMark = _injuries.Get(bodyPart, inner) - _oldInjuries.Get(bodyPart, inner);
		int maxRemoveValue = maxRemoveMark * step + existValue;
		value = Math.Min(value, maxRemoveValue);
		if (value <= 0)
		{
			return;
		}
		int removedValue = maxRemoveValue - value;
		int remainMark = removedValue / step;
		if (remainMark < maxRemoveMark)
		{
			RemoveInjury(context, bodyPart, inner, maxRemoveMark - remainMark);
		}
		int remainValue = removedValue % step;
		if (remainValue != existValue)
		{
			existValues[bodyPart] = remainValue;
			if (inner)
			{
				SetInnerDamageValue(existValues, context);
			}
			else
			{
				SetOuterDamageValue(existValues, context);
			}
		}
	}

	public void RemoveHalfInjury(DataContext context, bool inner)
	{
		Injuries injuries = GetInjuries();
		Injuries newInjuries = injuries.Subtract(GetOldInjuries());
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		pool.Clear();
		CRandom.GenerateValueInjuryPool(newInjuries, pool, inner);
		int removeCount = pool.Count * CValueHalf.RoundUp;
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, removeCount, pool))
		{
			injuries.Change(bodyPart, inner, -1);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		SetInjuries(context, injuries);
	}

	public void RemoveRandomInjury(DataContext context, bool inner, int count = 1)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		Injuries injuries = GetInjuries().Subtract(GetOldInjuries());
		for (sbyte i = 0; i < 7; i++)
		{
			sbyte value = injuries.Get(i, inner);
			pool.AddRepeat(i, value);
		}
		bool anyRemoved = false;
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, count, pool))
		{
			anyRemoved = true;
			RemoveInjury(context, bodyPart, inner, 1, updateDefeatMark: false);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		if (anyRemoved)
		{
			DomainManager.Combat.UpdateBodyDefeatMark(context, this);
		}
	}

	public bool RemoveRandomInjury(DataContext context, int count = 1)
	{
		bool anyRemoved = false;
		Injuries injuries = GetInjuries().Subtract(GetOldInjuries());
		foreach (InjuryKey item in CRandom.RandomInjuryByValue(context.Random, injuries, count))
		{
			item.Deconstruct(out var BodyPart, out var Inner);
			sbyte bodyPart = BodyPart;
			bool inner = Inner;
			anyRemoved = true;
			RemoveInjury(context, bodyPart, inner, 1, updateDefeatMark: false);
		}
		DomainManager.Combat.UpdateBodyDefeatMark(context, this);
		return anyRemoved;
	}

	public void RemoveInjury(DataContext context, sbyte bodyPart, bool inner, int count = 1, bool updateDefeatMark = true, bool removeOldInjury = false, bool byTransfer = false)
	{
		Injuries injuries = GetInjuries();
		injuries.Change(bodyPart, inner, (sbyte)(-count));
		if (removeOldInjury)
		{
			Injuries oldInjuries = GetOldInjuries();
			oldInjuries.Change(bodyPart, inner, (sbyte)(-count));
			SetOldInjuries(oldInjuries, context);
		}
		SetInjuries(context, injuries, updateDefeatMark, syncAutoHealProgress: true, byTransfer);
	}

	public int CalcBreakBodyPartCount()
	{
		int counter = 0;
		for (sbyte type = 0; type < 7; type++)
		{
			if (HasBreakInjury(type))
			{
				counter++;
			}
		}
		return counter;
	}

	public bool HasBreakInjury(sbyte bodyPart)
	{
		return HasBreakOrHeavyInjury(bodyPart, checkHeavyInjury: false);
	}

	public bool HasHeavyInjury(sbyte bodyPart)
	{
		return HasBreakOrHeavyInjury(bodyPart, checkHeavyInjury: true);
	}

	private bool HasBreakOrHeavyInjury(sbyte bodyPart, bool checkHeavyInjury)
	{
		Injuries injuries = GetInjuries();
		int needOuterCount = DomainManager.SpecialEffect.ModifyData(_id, -1, 168, 6, bodyPart, 0);
		int needInnerCount = DomainManager.SpecialEffect.ModifyData(_id, -1, 168, 6, bodyPart, 1);
		if (checkHeavyInjury)
		{
			needOuterCount = Math.Min(needOuterCount, 5);
			needInnerCount = Math.Min(needInnerCount, 5);
		}
		(sbyte outer, sbyte inner) tuple = injuries.Get(bodyPart);
		sbyte outer = tuple.outer;
		sbyte inner = tuple.inner;
		bool broken = outer >= needOuterCount || inner >= needInnerCount;
		return DomainManager.SpecialEffect.ModifyData(_id, -1, 169, broken, bodyPart);
	}

	public void ChangeToOldInjury(DataContext context, sbyte bodyPart, bool isInner, int count)
	{
		Injuries oldInjuries = GetOldInjuries();
		count = Math.Min(count, GetInjuries().Get(bodyPart, isInner) - oldInjuries.Get(bodyPart, isInner));
		oldInjuries.Change(bodyPart, isInner, (sbyte)count);
		SetOldInjuries(oldInjuries, context);
		SyncInjuryAutoHealCollection(context);
	}

	public int ChangeToOldInjury(DataContext context, int count)
	{
		Injuries newInjuries = GetInjuries().Subtract(GetOldInjuries());
		int changeCount = 0;
		foreach (InjuryKey item in CRandom.RandomInjuryByValue(context.Random, newInjuries, count))
		{
			item.Deconstruct(out var BodyPart, out var Inner);
			sbyte bodyPart = BodyPart;
			bool inner = Inner;
			changeCount++;
			ChangeToOldInjury(context, bodyPart, inner, 1);
		}
		return changeCount;
	}

	public int GetEffectDamageStep(DefeatMarkKey markKey)
	{
		return DomainManager.World.ApplyChallengeModeEffectDamageFactor(this, markKey);
	}

	public int MarkCountChangeToDamageValue(sbyte bodyPart, bool inner, int count)
	{
		int[] bodyPartSteps = (inner ? _damageStepCollection.InnerDamageSteps : _damageStepCollection.OuterDamageSteps);
		int existValue = (inner ? _innerDamageValue : _outerDamageValue)[bodyPart];
		int canAddInjury = 6 - _injuries.Get(bodyPart, inner);
		int injuryCount = Math.Min(canAddInjury, count);
		int fatalCount = count - injuryCount;
		int markValue = injuryCount * bodyPartSteps[bodyPart] + fatalCount * _damageStepCollection.FatalDamageStep;
		return markValue - existValue - ((fatalCount > 0) ? _fatalDamageValue : 0);
	}

	public void SetInjuries(DataContext context, Injuries injuries, bool updateDefeatMark = true, bool syncAutoHealProgress = true, bool byTransfer = false)
	{
		Injuries oldInjuries = GetOldInjuries();
		Injuries newInjuries = injuries.Subtract(oldInjuries);
		bool oldInjuriesChanged = false;
		if (newInjuries.HasAnyInjury())
		{
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				(sbyte, sbyte) injury = injuries.Get(bodyPart);
				(sbyte, sbyte) oldInjury = oldInjuries.Get(bodyPart);
				if (injury.Item1 < oldInjury.Item1)
				{
					oldInjuries.Change(bodyPart, isInnerInjury: false, (sbyte)(injury.Item1 - oldInjury.Item1));
					oldInjuriesChanged = true;
				}
				if (injury.Item2 < oldInjury.Item2)
				{
					oldInjuries.Change(bodyPart, isInnerInjury: true, (sbyte)(injury.Item2 - oldInjury.Item2));
					oldInjuriesChanged = true;
				}
			}
		}
		if (oldInjuriesChanged)
		{
			SetOldInjuries(oldInjuries, context);
		}
		int removedInjuryCount = GetInjuries().Subtract(injuries).MaxZero().GetSum();
		if (removedInjuryCount > 0 && !byTransfer)
		{
			AddScarMarkProgress(context, removedInjuryCount);
		}
		SetInjuries(injuries, context);
		GetCharacter().SetInjuries(injuries, context);
		if (syncAutoHealProgress)
		{
			SyncInjuryAutoHealCollection(context);
		}
		if (updateDefeatMark)
		{
			DomainManager.Combat.UpdateBodyDefeatMark(context, this);
		}
		DomainManager.Combat.UpdateOtherActionCanUse(context, this, 0);
		if (DomainManager.Combat.IsMainCharacter(this))
		{
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, IsAlly, ETeammateCommandImplement.HealInjury);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, IsAlly, ETeammateCommandImplement.TransferInjury);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, !IsAlly, ETeammateCommandImplement.AddInjuryOnEmpty);
		}
	}

	private void SyncInjuryAutoHealCollection(DataContext context)
	{
		InjuryAutoHealCollection oldAutoHealCollection = GetOldInjuryAutoHealCollection();
		InjuryAutoHealCollection autoHealCollection = GetInjuryAutoHealCollection();
		Injuries oldInjuries = GetOldInjuries();
		Injuries newInjuries = GetInjuries().Subtract(oldInjuries);
		oldAutoHealCollection.SyncInjuries(ref oldInjuries);
		autoHealCollection.SyncInjuries(ref newInjuries);
		SetOldInjuryAutoHealCollection(oldAutoHealCollection, context);
		SetInjuryAutoHealCollection(autoHealCollection, context);
	}

	public void TransferRandomMindMark(DataContext context, CombatCharacter target)
	{
		List<bool> markList = GetDefeatMarkCollection().MindMarkList;
		TransferMindMark(context, target, context.Random.Next(markList.Count));
	}

	public void TransferMindMark(DataContext context, CombatCharacter target, int index)
	{
		MindMarkList srcList = GetMindMarkTime();
		MindMarkList dstList = target.GetMindMarkTime();
		CountdownData mindMark = srcList.MarkList[index];
		short keepTime = GlobalConfig.Instance.MindMarkBaseKeepTime;
		srcList.MarkList.RemoveAt(index);
		MindMarkList mindMarkList = dstList;
		if (mindMarkList.MarkList == null)
		{
			mindMarkList.MarkList = new List<CountdownData>();
		}
		dstList.MarkList.Add(mindMark.Infinite ? CountdownData.Create(keepTime) : mindMark);
		SetMindMarkTime(srcList, context);
		target.SetMindMarkTime(dstList, context);
		UpdateMindMark(context);
		target.UpdateMindMark(context);
	}

	public void AddMindDamage(DataContext context, int damageValue, short skillId = -1)
	{
		int step = GetDamageStepCollection().MindDamageStep;
		var (markCount, leftDamage) = CMath.CalcMarkAndLeftDamage(damageValue + GetMindDamageValue(), step);
		SetMindDamageValue(leftDamage, context);
		AddMindDamageToShow(context, damageValue);
		AddMindMark(context, markCount, skillId);
	}

	public void AddMindDamageByMarkPercent(DataContext context, CValuePercent markPercent)
	{
		int damage = GetEffectDamageStep(EMarkType.Mind) * markPercent;
		AddMindDamage(context, damage, -1);
	}

	public void AddMindMark(DataContext context, int count, short skillId = -1, bool forceInfinite = false)
	{
		if (CheckImmunityAndShowEffect(EMarkType.Mind))
		{
			return;
		}
		count = DomainManager.SpecialEffect.ModifyData(_id, -1, 249, count);
		if (count <= 0)
		{
			return;
		}
		bool changeToFatal = DomainManager.SpecialEffect.ModifyData(_id, skillId, 288, dataValue: false);
		if (!ChangeToMindMark && changeToFatal)
		{
			AddFatalMark(context, count, -1, -1);
			return;
		}
		MindMarkList mindMarkList = GetMindMarkTime();
		int keepTimeNormal = DomainManager.SpecialEffect.ModifyValue(_id, 178, GlobalConfig.Instance.MindMarkBaseKeepTime);
		for (int i = 0; i < count; i++)
		{
			int keepTime = ((CheckMindMarkInfinity(context) || forceInfinite) ? (-1) : keepTimeNormal);
			MindMarkList mindMarkList2 = mindMarkList;
			if (mindMarkList2.MarkList == null)
			{
				mindMarkList2.MarkList = new List<CountdownData>();
			}
			mindMarkList.MarkList.Add(CountdownData.Create(keepTime));
		}
		UpdateMindMark(context);
		SetMindMarkTime(mindMarkList, context);
		Events.RaiseAddMindMark(context, this, count);
	}

	public void RemoveAllMindMark(DataContext context)
	{
		RemoveMindMark(context, _defeatMarkCollection.MindMarkList.Count, random: true);
	}

	public void RemoveHalfMindMark(DataContext context)
	{
		int removeCount = _defeatMarkCollection.MindMarkList.Count * CValueHalf.RoundUp;
		RemoveMindMark(context, removeCount, random: true);
	}

	public void RemoveMindMark(DataContext context, int count, bool random, int index = 0)
	{
		MindMarkList mindMarkList = GetMindMarkTime();
		int removeCount = Math.Min(count, mindMarkList.MarkList.Count);
		for (int i = 0; i < removeCount; i++)
		{
			mindMarkList.MarkList.RemoveAt(random ? context.Random.Next(0, mindMarkList.MarkList.Count) : index);
		}
		UpdateMindMark(context);
		SetMindMarkTime(mindMarkList, context);
	}

	public bool AnyNotInfinityMindMark()
	{
		List<CountdownData> markList = _mindMarkTime.MarkList;
		if (markList == null || markList.Count <= 0)
		{
			return false;
		}
		foreach (CountdownData mark in _mindMarkTime.MarkList)
		{
			if (!mark.Infinite)
			{
				return true;
			}
		}
		return false;
	}

	public void TickMindUpheaval(DataContext context)
	{
		AddUpheavalDamage(context);
		UpdateDelayedMindDamage(context);
		if (_mindUpheavalTime.Tick())
		{
			SetMindUpheavalTime(_mindUpheavalTime, context);
		}
		if (_mindUpheavalTime.On)
		{
			return;
		}
		bool anyNotInfinityMindMark = AnyNotInfinityMindMark();
		if (anyNotInfinityMindMark != _mindRhythm.On)
		{
			if (anyNotInfinityMindMark)
			{
				ResetMindRhythm(context);
			}
			else
			{
				SetMindRhythm(CountdownData.Zero, context);
			}
		}
	}

	public bool CheckMindMarkInfinity(DataContext context)
	{
		if (_mindUpheavalTime.On)
		{
			return true;
		}
		if (_mindRhythm.Off)
		{
			ResetMindRhythm(context);
		}
		else if (_mindRhythm.Tick())
		{
			SetMindRhythm(_mindRhythm, context);
		}
		if (_mindRhythm.On)
		{
			return false;
		}
		StartUpheaval(context);
		return false;
	}

	public void ResetMindRhythm(DataContext context)
	{
		SetMindRhythm(CountdownData.Create(GlobalConfig.Instance.BaseMindRhythm), context);
	}

	public void ForceUpheaval(DataContext context)
	{
		ResetMindRhythm(context);
		_mindRhythm.TickToZero();
		SetMindRhythm(_mindRhythm, context);
		StartUpheaval(context);
	}

	public void ClearMindRhythmAndUpheaval(DataContext context)
	{
		_delayedMindDamage.Clear();
		SetMindRhythm(CountdownData.Zero, context);
		SetMindUpheavalTime(CountdownData.Zero, context);
	}

	private void StartUpheaval(DataContext context)
	{
		int upheavalUnit = DomainManager.SpecialEffect.ModifyValue(_id, 330, _mindRhythm.Total);
		int upheavalTime = GlobalConfig.Instance.BaseMindUpheavalTime * upheavalUnit;
		SetMindUpheavalTime(CountdownData.Create(upheavalTime), context);
	}

	private void AddUpheavalDamage(DataContext context)
	{
		int unit = GlobalConfig.Instance.BaseMindUpheavalTime;
		if (!_mindUpheavalTime.Off && (_mindUpheavalTime.Left <= 1 || _mindUpheavalTime.Left % unit == 0))
		{
			CValuePercent addDamagePercent = GlobalConfig.Instance.MindUpheavalAddDamageStepPercent;
			int addDamage = _damageStepCollection.MindDamageStep * addDamagePercent;
			int splitCount = _mindUpheavalTime.Left / unit + 1;
			AddDelayedMindDamage(context, addDamage, splitCount);
		}
	}

	private void AddDelayedMindDamage(DataContext context, int damageValue, int splitCount)
	{
		List<int> pool = ObjectPool<List<int>>.Instance.Get();
		for (int i = 0; i < splitCount - 1; i++)
		{
			int value = context.Random.Next(damageValue / 2);
			pool.Add(value);
			damageValue -= value;
		}
		pool.Add(damageValue);
		CollectionUtils.Shuffle(context.Random, pool);
		_delayedMindDamage.AddRange(pool);
		ObjectPool<List<int>>.Instance.Return(pool);
	}

	private void UpdateDelayedMindDamage(DataContext context)
	{
		List<int> delayedMindDamage = _delayedMindDamage;
		if (delayedMindDamage != null && delayedMindDamage.Count > 0 && !_delayedDamageAdded)
		{
			_delayedDamageAdded = true;
			int damage = _delayedMindDamage[0];
			_delayedMindDamage.RemoveAt(0);
			AddMindDamage(context, damage, -1);
		}
	}

	public void UpdateMindMark(DataContext context)
	{
		int oldCount = _defeatMarkCollection.MindMarkList.Count;
		List<bool> newMindMark = ObjectPool<List<bool>>.Instance.Get();
		newMindMark.Clear();
		newMindMark.AddRange(_mindMarkTime.MarkList.Select((CountdownData x) => x.Infinite));
		if (_defeatMarkCollection.SyncMindMark(newMindMark))
		{
			SetDefeatMarkCollection(_defeatMarkCollection, context);
		}
		ObjectPool<List<bool>>.Instance.Return(newMindMark);
		int newCount = _defeatMarkCollection.MindMarkList.Count;
		if (newCount > oldCount)
		{
			DomainManager.Combat.AddToCheckFallenSet(_id);
		}
	}

	public void TransferFatalMark(DataContext context, CombatCharacter target, int count)
	{
		count = Math.Min(count, _defeatMarkCollection.FatalDamageMarkCount);
		if (count > 0)
		{
			_defeatMarkCollection.FatalDamageMarkCount -= count;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			DefeatMarkCollection targetMarks = target._defeatMarkCollection;
			targetMarks.FatalDamageMarkCount = CMath.ClampFatalMarkCount(targetMarks.FatalDamageMarkCount + count);
			target.SetDefeatMarkCollection(targetMarks, context);
		}
	}

	public int AddFatalDamage(DataContext context, int damageValue, int type = -1, sbyte bodyPart = -1, short skillId = -1, EDamageType damageType = EDamageType.None)
	{
		damageValue = DomainManager.SpecialEffect.ModifyValueCustom(_id, skillId, 191, damageValue, type, (int)damageType, bodyPart);
		damageValue = DomainManager.SpecialEffect.ModifyData(_id, skillId, 293, damageValue);
		if (damageValue <= 0)
		{
			return 0;
		}
		int step = GetDamageStepCollection().FatalDamageStep;
		var (mark, leftDamage) = CMath.CalcMarkAndLeftDamage(damageValue + _fatalDamageValue, step);
		SetFatalDamageValue(leftDamage, context);
		AddFatalDamageToShow(context, damageValue);
		return (mark > 0) ? AddFatalMark(context, mark, type, bodyPart, addByValue: true, damageType) : 0;
	}

	public void AddFatalDamageByMarkPercent(DataContext context, CValuePercent markPercent)
	{
		int damage = GetEffectDamageStep(EMarkType.Fatal) * markPercent;
		AddFatalDamage(context, damage, -1, -1, -1);
	}

	public int AddFatalMark(DataContext context, int count, int type = -1, sbyte bodyPart = -1, bool addByValue = false, EDamageType damageType = EDamageType.None)
	{
		if (CheckImmunityAndShowEffect(EMarkType.Fatal))
		{
			return 0;
		}
		count = DomainManager.SpecialEffect.ModifyData(_id, -1, 192, count, type, bodyPart, addByValue ? 1 : 0);
		count = DomainManager.SpecialEffect.ModifyData(_id, -1, 303, count, (int)damageType);
		if (count <= 0)
		{
			return 0;
		}
		if (ChangeToMindMark)
		{
			AddMindMark(context, count, -1);
			return 0;
		}
		AddFatalMarkImmediate(context, count);
		return count;
	}

	public void AddFatalMarkImmediate(DataContext context, int count)
	{
		DefeatMarkCollection markCollection = _defeatMarkCollection;
		markCollection.FatalDamageMarkCount = CMath.ClampFatalMarkCount(markCollection.FatalDamageMarkCount + count);
		SetDefeatMarkCollection(markCollection, context);
		Events.RaiseAddFatalDamageMark(context, this, count);
		DomainManager.Combat.AddToCheckFallenSet(_id);
		DomainManager.Combat.UpdateAllTeammateCommandUsable(context, IsAlly, ETeammateCommandImplement.MergeFatalToDie);
	}

	public void RemoveAllFatalMark(DataContext context)
	{
		RemoveFatalMark(context, _defeatMarkCollection.FatalDamageMarkCount);
	}

	public void RemoveHalfFatalMark(DataContext context)
	{
		RemoveFatalMark(context, _defeatMarkCollection.FatalDamageMarkCount * CValueHalf.RoundUp);
	}

	public void RemoveFatalMark(DataContext context, int count)
	{
		count = Math.Min(count, _defeatMarkCollection.FatalDamageMarkCount);
		if (count > 0)
		{
			_defeatMarkCollection.FatalDamageMarkCount -= count;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			AddScarMarkProgress(context, count);
		}
	}

	public void AddScarMarkProgress(DataContext context, int injuryOrFatalMarkCount)
	{
		if (!EnableScarMark)
		{
			return;
		}
		int min = GlobalConfig.Instance.ScarMarkProgressMin;
		int max = GlobalConfig.Instance.ScarMarkProgressMax;
		max = Math.Max(min + 1, max + 1);
		for (int i = 0; i < injuryOrFatalMarkCount; i++)
		{
			_scarMarkProgress += context.Random.Next(min, max);
		}
		int markCount = _scarMarkProgress / GlobalConfig.Instance.ScarMarkProgressPerMark;
		_scarMarkProgress %= GlobalConfig.Instance.ScarMarkProgressPerMark;
		if (markCount > 0)
		{
			if (_scarMarkTime == null)
			{
				_scarMarkTime = new List<CountdownData>();
			}
			for (int j = 0; j < markCount; j++)
			{
				_scarMarkTime.Add(CountdownData.Create(GlobalConfig.Instance.ScarMarkBaseKeepTime));
			}
			SetScarMarkTime(_scarMarkTime, context);
			SyncScarMark(context);
		}
	}

	public void TickScarMark(DataContext context)
	{
		List<CountdownData> scarMarkTime = _scarMarkTime;
		if (scarMarkTime == null || scarMarkTime.Count <= 0)
		{
			return;
		}
		for (int i = _scarMarkTime.Count - 1; i >= 0; i--)
		{
			CountdownData time = _scarMarkTime[i];
			time.Tick();
			if (time.On)
			{
				_scarMarkTime[i] = time;
			}
			else
			{
				_scarMarkTime.RemoveAt(i);
			}
		}
		SetScarMarkTime(_scarMarkTime, context);
		SyncScarMark(context);
	}

	private void SyncScarMark(DataContext context)
	{
		int currCount = _scarMarkTime.Count;
		if (currCount != _defeatMarkCollection.ScarMarkCount)
		{
			int prevCount = _defeatMarkCollection.ScarMarkCount;
			_defeatMarkCollection.ScarMarkCount = currCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (currCount > prevCount)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	public void AddTiredMark(DataContext context)
	{
		_defeatMarkCollection.TiredMarkCount++;
		SetDefeatMarkCollection(_defeatMarkCollection, context);
		DomainManager.Combat.AddToCheckFallenSet(_id);
	}

	public void AddDieMark(DataContext context, int count)
	{
		AddDieMark(context, CombatSkillKey.Invalid, count);
	}

	public void AddDieMark(DataContext context, CombatSkillKey skillKey, int count)
	{
		if (CheckImmunityAndShowEffect(EMarkType.Die))
		{
			return;
		}
		if (ChangeToMindMark)
		{
			AddMindMark(context, count, -1);
			return;
		}
		DefeatMarkCollection markCollection = GetDefeatMarkCollection();
		for (int i = 0; i < count; i++)
		{
			markCollection.DieMarkList.Add(skillKey);
		}
		SetDefeatMarkCollection(markCollection, context);
		DomainManager.Combat.AddToCheckFallenSet(_id);
	}

	public void UpdateWugMark(DataContext context)
	{
		sbyte oldCount = _defeatMarkCollection.WugMarkCount;
		sbyte newCount = _character.GetEatingItems().CountOfWugMark();
		if (newCount != oldCount)
		{
			_defeatMarkCollection.WugMarkCount = newCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (newCount > oldCount)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	private void UpdateWugMark(DataContext context, DataUid uid)
	{
		UpdateWugMark(context);
	}

	public void UpdateQiDisorderMark(DataContext context)
	{
		sbyte oldCount = _defeatMarkCollection.QiDisorderMarkCount;
		sbyte newCount = DefeatMarkCollection.CalcQiDisorderMarkCount(_character.GetDisorderOfQi());
		if (newCount != oldCount)
		{
			_defeatMarkCollection.QiDisorderMarkCount = newCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (newCount > oldCount)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	private void UpdateQiDisorderMark(DataContext context, DataUid uid)
	{
		UpdateQiDisorderMark(context);
	}

	public void UpdateStateMark(DataContext context)
	{
		sbyte oldCount = _defeatMarkCollection.StateMarkCount;
		short powerPerMark = GlobalConfig.Instance.DefeatMarkCombatStatePower;
		sbyte maxMarkCount = GlobalConfig.Instance.DefeatMarkCombatStateMaxCount;
		sbyte newCount = (sbyte)Math.Clamp(-GetCombatStateTotalBuffPower() / powerPerMark, 0, maxMarkCount);
		if (newCount != oldCount)
		{
			_defeatMarkCollection.StateMarkCount = newCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (newCount > oldCount)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	public void UpdateNeiliAllocationMark(DataContext context)
	{
		(sbyte, sbyte) oldCount = _defeatMarkCollection.NeiliAllocationMarkCount;
		(sbyte, sbyte) newCount = CalcNeiliAllocationMarkCount();
		var (b, b2) = newCount;
		var (b3, b4) = oldCount;
		if (b != b3 || b2 != b4)
		{
			_defeatMarkCollection.NeiliAllocationMarkCount = newCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (oldCount.Item1 + oldCount.Item2 < newCount.Item1 + newCount.Item2)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	private (sbyte scatter, sbyte bulge) CalcNeiliAllocationMarkCount()
	{
		sbyte scatter = 0;
		sbyte bulge = 0;
		for (byte i = 0; i < 4; i++)
		{
			NeiliAllocationStatusItem config = this.GetNeiliAllocationStatus(i).GetConfig();
			if (config.MarkCount < 0)
			{
				scatter += Math.Abs(config.MarkCount);
			}
			else if (config.MarkCount > 0)
			{
				bulge += Math.Abs(config.MarkCount);
			}
		}
		return (scatter: scatter, bulge: bulge);
	}

	public void UpdateHealthMark(DataContext context)
	{
		sbyte oldCount = _defeatMarkCollection.HealthMarkCount;
		sbyte newCount = DefeatMarkCollection.GetHealthMarkCount(_character.GetHealthType());
		if (newCount != oldCount)
		{
			_defeatMarkCollection.HealthMarkCount = newCount;
			SetDefeatMarkCollection(_defeatMarkCollection, context);
			if (newCount > oldCount)
			{
				DomainManager.Combat.AddToCheckFallenSet(_id);
			}
		}
	}

	private void UpdateHealthMark(DataContext context, DataUid uid)
	{
		UpdateHealthMark(context);
	}

	public void UpdateOtherMark(DataContext context)
	{
		UpdateWugMark(context);
		UpdateQiDisorderMark(context);
		UpdateStateMark(context);
		UpdateNeiliAllocationMark(context);
		UpdateHealthMark(context);
	}

	public void SetTargetDistance(DataContext context, short targetDistance)
	{
		if (_targetDistance != targetDistance)
		{
			SetTargetDistance(targetDistance, context);
			_combatDomain.UpdateAllTeammateCommandUsable(context, IsAlly, ETeammateCommandImplement.GotoTargetDistance);
		}
	}

	public int CalcNormalAttackStartupFrames()
	{
		GameData.Domains.Item.Weapon weapon = DomainManager.Combat.GetUsingWeapon(this);
		return CalcNormalAttackStartupFrames(weapon);
	}

	public int CalcNormalAttackStartupFrames(GameData.Domains.Item.Weapon weapon)
	{
		WeaponItem config = Config.Weapon.Instance[weapon.GetTemplateId()];
		int frames = weapon.CalcAttackStartupOrRecoveryFrame(AttackSpeed, config.BaseStartupFrames);
		FlawOrAcupointCollection acupoint = _acupointCollection;
		int acupointAddPercent = acupoint.CalcAcupointParam(3) + acupoint.CalcAcupointParam(4);
		frames = DomainManager.SpecialEffect.ModifyValue(_id, 282, frames, -1, -1, -1, 0, 0, acupointAddPercent);
		return Math.Max(frames, GlobalConfig.Instance.MinPrepareFrame);
	}

	public short CalcNormalAttackAnimationFrames(float animDuration)
	{
		FlawOrAcupointCollection acupoint = _acupointCollection;
		int acupointAddPercent = acupoint.CalcAcupointParam(3) + acupoint.CalcAcupointParam(4);
		acupointAddPercent /= 5;
		animDuration *= (float)(100 + acupointAddPercent) / 100f;
		return (short)Math.Round(animDuration * 60f, MidpointRounding.AwayFromZero);
	}

	public int CalcNormalAttackRecoveryFrames(GameData.Domains.Item.Weapon weapon)
	{
		WeaponItem config = Config.Weapon.Instance[weapon.GetTemplateId()];
		int frames = weapon.CalcAttackStartupOrRecoveryFrame(AttackSpeed, config.BaseRecoveryFrames);
		frames = DomainManager.SpecialEffect.ModifyValue(_id, 319, frames);
		return Math.Max(frames, 1);
	}

	public void NormalAttackRecovery(DataContext context)
	{
		if (!IsAutoNormalAttacking && !GetChangeTrickAttack())
		{
			GameData.Domains.Item.Weapon weapon = DomainManager.Combat.GetUsingWeapon(this);
			int recoveryFrames = CalcNormalAttackRecoveryFrames(weapon);
			if (_normalAttackRecovery.Cover(recoveryFrames))
			{
				SetNormalAttackRecovery(_normalAttackRecovery, context);
			}
		}
	}

	public bool CalcNormalAttackAddTrick(IRandomSource random, bool hit, int hitOdds)
	{
		if (IsAutoNormalAttackingSpecial || _id == DomainManager.Combat.GetCarrierAnimalCombatCharId())
		{
			return false;
		}
		bool hitOrAvoidAddTrick = hit;
		if (!hitOrAvoidAddTrick && AttackForceMissCount <= 0)
		{
			int baseOdds = GlobalConfig.Instance.AvoidAddTrickBaseOdds;
			int avoidTrickOdds = baseOdds + hitOdds / GlobalConfig.Instance.AvoidAddTrickHitOddsDivisor;
			hitOrAvoidAddTrick = random.CheckPercentProb(avoidTrickOdds);
		}
		if (!hitOrAvoidAddTrick)
		{
			return false;
		}
		byte pursueAttackCount = PursueAttackCount;
		return (pursueAttackCount == 0 || pursueAttackCount == 2 || pursueAttackCount == 5) ? true : false;
	}

	public bool ApplyChangeTrickFlawOrAcupoint(DataContext context, CombatCharacter defender, sbyte bodyPart)
	{
		if (PursueAttackCount != 0 || !GetChangeTrickAttack())
		{
			return false;
		}
		sbyte level = DomainManager.Combat.GetUsingWeapon(this).GetAttackPreparePointCost();
		if (ChangeTrickFlawOrAcupointType == EFlawOrAcupointType.Flaw)
		{
			DomainManager.Combat.AddFlaw(context, defender, level, (charId: -1, skillId: (short)(-1)), bodyPart);
		}
		else
		{
			if (ChangeTrickFlawOrAcupointType != EFlawOrAcupointType.Acupoint)
			{
				return false;
			}
			DomainManager.Combat.AddAcupoint(context, defender, level, (charId: -1, skillId: (short)(-1)), bodyPart);
		}
		return true;
	}

	public short GetOtherActionPrepareFrame(sbyte actionType)
	{
		int prepareFrame = CombatDomain.OtherActionPrepareFrame[actionType];
		if (1 == 0)
		{
		}
		int num = actionType switch
		{
			0 => _character.GetLifeSkillAttainment(8), 
			1 => _character.GetLifeSkillAttainment(9), 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		int attainment = num;
		if (1 == 0)
		{
		}
		num = actionType switch
		{
			0 => 120, 
			1 => 120, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		int minPrepareFrame = num;
		if (attainment > 0)
		{
			prepareFrame = Math.Max(prepareFrame - attainment / 5 * 2, minPrepareFrame);
		}
		int speedPercent = 100;
		if (1 == 0)
		{
		}
		ushort num2 = actionType switch
		{
			0 => 118, 
			1 => 121, 
			2 => 124, 
			_ => ushort.MaxValue, 
		};
		if (1 == 0)
		{
		}
		ushort fieldId = num2;
		if (fieldId != ushort.MaxValue)
		{
			speedPercent += DomainManager.SpecialEffect.GetModifyValue(_id, fieldId, EDataModifyType.AddPercent);
		}
		prepareFrame = prepareFrame * 100 / Math.Max(speedPercent, GlobalConfig.Instance.HealInjuryPoisonSpeedMinPercent);
		return (short)Math.Clamp(prepareFrame, 0, 32767);
	}

	public bool SkillUseLegAsWeapon(short skillId)
	{
		if (skillId < 0 || DomainManager.CombatSkill.GetSkillType(_id, skillId) != 5)
		{
			return false;
		}
		return DomainManager.SpecialEffect.ModifyData(_id, -1, 88, dataValue: true);
	}

	private CValuePercent GetEquipmentPower(ItemKey key)
	{
		return DomainManager.Character.GetItemPower(_id, key);
	}

	private GameData.Domains.Item.Weapon GetFinalWeapon(GameData.Domains.Item.Weapon weapon, short skillId, out ItemKey shoesWeaponKey)
	{
		shoesWeaponKey = ItemKey.Invalid;
		if (!SkillUseLegAsWeapon(skillId))
		{
			return weapon;
		}
		ItemKey shoesKey = Armors[5];
		GameData.Domains.Item.Armor shoes = (shoesKey.IsValid() ? DomainManager.Item.GetElement_Armors(shoesKey.Id) : null);
		if (shoes == null || shoes.GetCurrDurability() <= 0)
		{
			return DomainManager.Item.GetElement_Weapons(_weapons[3].Id);
		}
		short shoesWeaponTemplateId = Config.Armor.Instance[shoesKey.TemplateId].RelatedWeapon;
		shoesWeaponKey = new ItemKey(0, 0, shoesWeaponTemplateId, -1);
		return null;
	}

	private CValuePercentBonus CalcWeaponHitFactor(GameData.Domains.Item.Weapon weapon, sbyte hitType, short skillId)
	{
		ItemKey shoesWeaponKey;
		GameData.Domains.Item.Weapon finalWeapon = GetFinalWeapon(weapon, skillId, out shoesWeaponKey);
		if (finalWeapon != null)
		{
			return finalWeapon.GetHitFactors(_id)[hitType];
		}
		short weaponFactor = Config.Weapon.Instance[shoesWeaponKey.TemplateId].BaseHitFactors[hitType];
		if (weaponFactor > 0)
		{
			return weaponFactor * GetEquipmentPower(shoesWeaponKey);
		}
		return weaponFactor;
	}

	private CValuePercent CalcWeaponPenetrateFactor(GameData.Domains.Item.Weapon weapon, bool inner, sbyte bodyPart, short skillId)
	{
		ItemKey shoesWeaponKey;
		GameData.Domains.Item.Weapon finalWeapon = GetFinalWeapon(weapon, skillId, out shoesWeaponKey);
		int value = finalWeapon?.GetPenetrationFactor() ?? Config.Weapon.Instance[shoesWeaponKey.TemplateId].BasePenetrationFactor;
		value *= GetEquipmentPower(finalWeapon?.GetItemKey() ?? shoesWeaponKey);
		sbyte innerRatio = ((finalWeapon != null) ? DomainManager.Combat.GetElement_WeaponDataDict(finalWeapon.GetId()).GetInnerRatio() : Config.Weapon.Instance[shoesWeaponKey.TemplateId].DefaultInnerRatio);
		CValuePercent finalRatio = (inner ? innerRatio : (100 - innerRatio));
		value *= finalRatio;
		bool ignoreArmor = DomainManager.SpecialEffect.ModifyData(_id, skillId, 280, dataValue: false);
		if (bodyPart < 0 || ignoreArmor)
		{
			return value;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		ItemKey armorKey = enemyChar.Armors[bodyPart];
		GameData.Domains.Item.Armor armor = (armorKey.IsValid() ? DomainManager.Item.GetElement_Armors(armorKey.Id) : null);
		int weaponEquipDefense = CombatDomain.CalcWeaponDefend(this, weapon, skillId);
		int armorEquipAttack = CombatDomain.CalcArmorAttack(enemyChar, armor);
		if (armorEquipAttack > weaponEquipDefense)
		{
			value = CFormula.FormulaCalcWeaponArmorFactor(value, armorEquipAttack, weaponEquipDefense);
		}
		return value;
	}

	private CValuePercentBonus CalcArmorAvoidFactor(sbyte hitType, sbyte bodyPart, short skillId)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		bool ignoreArmor = DomainManager.SpecialEffect.ModifyData(enemyChar.GetId(), skillId, 280, dataValue: false);
		if (bodyPart < 0 || ignoreArmor)
		{
			return 0;
		}
		ItemKey armorKey = Armors[bodyPart];
		GameData.Domains.Item.Armor armor = (armorKey.IsValid() ? DomainManager.Item.GetElement_Armors(armorKey.Id) : null);
		if (armor == null)
		{
			return 0;
		}
		return armor.GetAvoidFactors(_id)[hitType];
	}

	private CValuePercentBonus CalcArmorPenetrateResistFactor(GameData.Domains.Item.Weapon weapon, bool inner, sbyte bodyPart, short skillId)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		bool ignoreArmor = DomainManager.SpecialEffect.ModifyData(enemyChar.GetId(), skillId, 280, dataValue: false);
		if (bodyPart < 0 || ignoreArmor)
		{
			return 0;
		}
		ItemKey armorKey = Armors[bodyPart];
		GameData.Domains.Item.Armor armor = (armorKey.IsValid() ? DomainManager.Item.GetElement_Armors(armorKey.Id) : null);
		if (armor == null)
		{
			return 0;
		}
		int armorFactor = armor.GetPenetrationResistFactors().Get(inner) * GetEquipmentPower(armorKey);
		int weaponEquipAttack = CombatDomain.CalcWeaponAttack(enemyChar, weapon, skillId);
		int armorEquipDefense = CombatDomain.CalcArmorDefend(this, armor);
		if (weaponEquipAttack > armorEquipDefense)
		{
			armorFactor = CFormula.FormulaCalcWeaponArmorFactor(armorFactor, weaponEquipAttack, armorEquipDefense);
		}
		return armorFactor;
	}

	private int CalcMoveSkillAddHitValue(sbyte hitType)
	{
		if (_affectingMoveSkillId < 0)
		{
			return 0;
		}
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: _affectingMoveSkillId));
		return skill.GetAddHitValueOnCast()[hitType];
	}

	private int CalcDefendSkillAddAvoidValue(sbyte hitType, bool ignoreDefendSkill)
	{
		if (_affectingDefendSkillId < 0 || ignoreDefendSkill)
		{
			return 0;
		}
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: _affectingDefendSkillId));
		return skill.GetAddAvoidValueOnCast()[hitType];
	}

	private int CalcDefendSkillAddPenetrateResistValue(bool inner, bool ignoreDefendSkill)
	{
		if (_affectingDefendSkillId < 0 || ignoreDefendSkill)
		{
			return 0;
		}
		GameData.Domains.CombatSkill.CombatSkill defendSkill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: _affectingDefendSkillId));
		OuterAndInnerInts addPenetrateResists = defendSkill.GetAddPenetrateResist();
		return inner ? addPenetrateResists.Inner : addPenetrateResists.Outer;
	}

	private CValueModify CalcTeammateHitModify(sbyte hitType, EDataSumType valueSumType)
	{
		CValueModify result = CValueModify.Zero;
		if (IsMainChar)
		{
			if (valueSumType.ContainsAdd())
			{
				CValuePercentBonus bonus = DomainManager.SpecialEffect.GetModifyValue(_id, 184, EDataModifyType.Add, 10);
				int addValue = (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.AddHit
					let baseValue = teammateChar.GetCharacter().GetHitValues()[hitType]
					select baseValue * (CValuePercent)teammateChar.ExecutingTeammateCommandConfig.IntArg * bonus).Sum();
				addValue += (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.GearMateD
					let baseValue = teammateChar.GetCharacter().GetHitValues()[hitType]
					select baseValue * (CValuePercent)teammateChar.ExecutingTeammateCommandConfig.IntArg).Sum();
				result = result.ChangeA(addValue);
			}
			if (valueSumType.ContainsReduce())
			{
				int reduceBonus = (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.ReduceHitAndAvoid
					select teammateChar.ExecutingTeammateCommandConfig.IntArg).Sum();
				result = result.ChangeB(-reduceBonus);
			}
		}
		else if (valueSumType.ContainsAdd())
		{
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Fight)
			{
				result = result.ChangeB(ExecutingTeammateCommandConfig.IntArg);
			}
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.FightSpecialGrow)
			{
				result = result.ChangeB(FightSpecialGrowBonus);
			}
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Attack)
			{
				result = result.ChangeC(DomainManager.SpecialEffect.GetModifyValue(MainChar.GetId(), 184, EDataModifyType.Add, 4));
			}
		}
		return result;
	}

	private CValueModify CalcTeammatePenetrateModify()
	{
		CValueModify result = CValueModify.Zero;
		if (IsMainChar)
		{
			return result;
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Fight)
		{
			result = result.ChangeB(ExecutingTeammateCommandConfig.IntArg);
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.FightSpecialGrow)
		{
			result = result.ChangeB(FightSpecialGrowBonus);
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Attack)
		{
			result = result.ChangeC(DomainManager.SpecialEffect.GetModifyValue(MainChar.GetId(), 184, EDataModifyType.Add, 4));
		}
		return result;
	}

	private CValueModify CalcTeammateAvoidModify(sbyte hitType, EDataSumType valueSumType)
	{
		CValueModify result = CValueModify.Zero;
		if (IsMainChar)
		{
			if (valueSumType.ContainsAdd())
			{
				CValuePercentBonus bonus = DomainManager.SpecialEffect.GetModifyValue(_id, 184, EDataModifyType.Add, 11);
				int addValue = (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.AddAvoid
					let baseValue = teammateChar.GetCharacter().GetAvoidValues()[hitType]
					select baseValue * (CValuePercent)teammateChar.ExecutingTeammateCommandConfig.IntArg * bonus).Sum();
				addValue += (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.GearMateD
					let baseValue = teammateChar.GetCharacter().GetAvoidValues()[hitType]
					select baseValue * (CValuePercent)teammateChar.ExecutingTeammateCommandConfig.SubIntArg).Sum();
				result = result.ChangeA(addValue);
			}
			if (valueSumType.ContainsReduce())
			{
				int reduceBonus = (from teammateChar in DomainManager.Combat.GetTeammateCharacters(_id)
					where teammateChar.ExecutingTeammateCommandImplement == ETeammateCommandImplement.ReduceHitAndAvoid
					select teammateChar.ExecutingTeammateCommandConfig.IntArg).Sum();
				result = result.ChangeB(-reduceBonus);
			}
		}
		else if (valueSumType.ContainsAdd())
		{
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Fight)
			{
				result = result.ChangeB(ExecutingTeammateCommandConfig.IntArg);
			}
			if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.FightSpecialGrow)
			{
				result = result.ChangeB(FightSpecialGrowBonus);
			}
		}
		return result;
	}

	private CValueModify CalcTeammatePenetrateResistModify()
	{
		CValueModify result = CValueModify.Zero;
		if (IsMainChar)
		{
			return result;
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.Fight)
		{
			result = result.ChangeB(ExecutingTeammateCommandConfig.IntArg);
		}
		if (ExecutingTeammateCommandImplement == ETeammateCommandImplement.FightSpecialGrow)
		{
			result = result.ChangeB(FightSpecialGrowBonus);
		}
		return result;
	}

	public int GetHitValue(CombatContext context, sbyte hitType)
	{
		int skillHitValue = context.Skill?.GetHitValue()[hitType] ?? 0;
		return GetHitValue(context.Weapon, hitType, context.BodyPart, skillHitValue, context.SkillTemplateId);
	}

	public int GetHitValue(sbyte hitType, sbyte bodyPart = -1, int skillAddPercent = 0, short skillId = -1)
	{
		GameData.Domains.Item.Weapon weapon = DomainManager.Combat.GetUsingWeapon(this);
		return GetHitValue(weapon, hitType, bodyPart, skillAddPercent, skillId);
	}

	public int GetHitValue(GameData.Domains.Item.Weapon weapon, sbyte hitType, sbyte bodyPart, int skillAddPercent = 0, short skillId = -1)
	{
		long value = _character.GetHitValues()[hitType];
		value = DomainManager.SpecialEffect.ModifyData(_id, skillId, 158, (int)value, hitType);
		value *= CalcWeaponHitFactor(weapon, hitType, skillId);
		bool canAdd = DomainManager.SpecialEffect.ModifyData(_id, -1, 36, dataValue: true, hitType, 0);
		bool canReduce = DomainManager.SpecialEffect.ModifyData(_id, -1, 36, dataValue: true, hitType, 1);
		CValuePercentBonus addEffectBonus = DomainManager.SpecialEffect.GetModifyValue(_id, 37, EDataModifyType.Add, hitType, 0);
		CValuePercentBonus reduceEffectBonus = DomainManager.SpecialEffect.GetModifyValue(_id, 37, EDataModifyType.Add, hitType, 1);
		CombatCharacter enemyChar = _combatDomain.GetCombatCharacter(!IsAlly, tryGetCoverCharacter: true);
		int attackerId = _id;
		int defenderId = enemyChar.GetId();
		ushort attackerFieldId = (ushort)(56 + hitType);
		ushort defenderFieldId = (ushort)(90 + hitType);
		CValueModify modify = CValueModify.Zero;
		if (canAdd)
		{
			modify = modify.ChangeA(CalcMoveSkillAddHitValue(hitType));
			modify += CalcTeammateHitModify(hitType, EDataSumType.OnlyAdd);
			modify += DomainManager.SpecialEffect.GetModify(attackerId, attackerFieldId, skillId, PursueAttackCount, bodyPart, EDataSumType.OnlyAdd) * addEffectBonus;
			modify += DomainManager.SpecialEffect.GetModify(defenderId, defenderFieldId, skillId, PursueAttackCount, bodyPart, EDataSumType.OnlyAdd) * addEffectBonus;
		}
		if (canReduce)
		{
			modify += CalcTeammateHitModify(hitType, EDataSumType.OnlyReduce);
			modify += DomainManager.SpecialEffect.GetModify(attackerId, attackerFieldId, skillId, PursueAttackCount, bodyPart, EDataSumType.OnlyReduce) * reduceEffectBonus;
			modify += DomainManager.SpecialEffect.GetModify(defenderId, defenderFieldId, skillId, PursueAttackCount, bodyPart, EDataSumType.OnlyReduce) * reduceEffectBonus;
		}
		modify = modify.MaxB(33);
		value *= modify;
		CValuePercentBonus bonus = skillAddPercent;
		if (skillId < 0 && GetChangeTrickAttack())
		{
			bonus += (CValuePercentBonus)GlobalConfig.Instance.AttackChangeTrickHitValueAddPercent[weapon.GetAttackPreparePointCost()];
		}
		value *= bonus;
		value = DomainManager.SpecialEffect.ModifyData(attackerId, skillId, attackerFieldId, value);
		value = DomainManager.SpecialEffect.ModifyData(defenderId, skillId, defenderFieldId, value);
		return (int)Math.Clamp(value, 0L, 2147483647L);
	}

	public int GetAvoidValue(CombatContext context, sbyte hitType)
	{
		return GetAvoidValue(hitType, context.BodyPart, context.SkillTemplateId);
	}

	public int GetAvoidValue(sbyte hitType, sbyte bodyPart = -1, short skillId = -1, bool ignoreDefendSkill = false)
	{
		int value = _character.GetAvoidValues()[hitType];
		CombatCharacter enemyChar = _combatDomain.GetCombatCharacter(!IsAlly);
		value *= CalcArmorAvoidFactor(hitType, bodyPart, skillId);
		bool canAdd = DomainManager.SpecialEffect.ModifyData(_id, -1, 42, dataValue: true, hitType, 0);
		bool canReduce = DomainManager.SpecialEffect.ModifyData(_id, -1, 42, dataValue: true, hitType, 1);
		CValuePercentBonus addEffectBonus = DomainManager.SpecialEffect.GetModifyValue(_id, 43, EDataModifyType.Add, hitType, 0);
		CValuePercentBonus reduceEffectBonus = DomainManager.SpecialEffect.GetModifyValue(_id, 43, EDataModifyType.Add, hitType, 1);
		int attackerId = enemyChar.GetId();
		int defenderId = _id;
		ushort attackerFieldId = (ushort)(60 + hitType);
		ushort defenderFieldId = (ushort)(94 + hitType);
		CValueModify modify = CValueModify.Zero;
		if (canAdd)
		{
			modify = modify.ChangeA(CalcDefendSkillAddAvoidValue(hitType, ignoreDefendSkill));
			modify += CalcTeammateAvoidModify(hitType, EDataSumType.OnlyAdd);
			modify += DomainManager.SpecialEffect.GetModify(attackerId, attackerFieldId, skillId, -1, -1, EDataSumType.OnlyAdd) * addEffectBonus;
			modify += DomainManager.SpecialEffect.GetModify(defenderId, defenderFieldId, skillId, -1, -1, EDataSumType.OnlyAdd) * addEffectBonus;
		}
		if (canReduce)
		{
			modify += CalcTeammateAvoidModify(hitType, EDataSumType.OnlyReduce);
			modify += DomainManager.SpecialEffect.GetModify(attackerId, attackerFieldId, skillId, -1, -1, EDataSumType.OnlyReduce) * reduceEffectBonus;
			modify += DomainManager.SpecialEffect.GetModify(defenderId, defenderFieldId, skillId, -1, -1, EDataSumType.OnlyReduce) * reduceEffectBonus;
		}
		modify = modify.MaxB(33);
		value *= modify;
		value = DomainManager.SpecialEffect.ModifyData(attackerId, skillId, attackerFieldId, value);
		value = DomainManager.SpecialEffect.ModifyData(defenderId, skillId, defenderFieldId, value);
		return Math.Max(value, 1);
	}

	public OuterAndInnerInts GetPenetrate(CombatContext context)
	{
		GameData.Domains.Item.Weapon weapon = context.Weapon;
		sbyte bodyPart = context.BodyPart;
		short skillId = context.SkillTemplateId;
		GameData.Domains.CombatSkill.CombatSkill skill = context.Skill;
		int outer = GetPenetrate(inner: false, weapon, bodyPart, skillId, skill?.GetPenetrations().Outer ?? 0);
		int inner = GetPenetrate(inner: true, weapon, bodyPart, skillId, skill?.GetPenetrations().Inner ?? 0);
		return new OuterAndInnerInts(outer, inner);
	}

	public int GetPenetrate(bool inner, GameData.Domains.Item.Weapon weapon, sbyte bodyPart, short skillId = -1, int skillAddPercent = 0)
	{
		long value = (inner ? _character.GetPenetrations().Inner : _character.GetPenetrations().Outer);
		value *= CalcWeaponPenetrateFactor(weapon, inner, bodyPart, skillId) + skillAddPercent;
		CombatCharacter enemyChar = _combatDomain.GetCombatCharacter(!IsAlly, tryGetCoverCharacter: true);
		int attackerId = _id;
		int defenderId = enemyChar.GetId();
		ushort attackerFieldId = (ushort)(inner ? 65 : 64);
		ushort defenderFieldId = (ushort)(inner ? 99 : 98);
		CValueModify modify = CalcTeammatePenetrateModify();
		modify += DomainManager.SpecialEffect.GetModify(attackerId, skillId, attackerFieldId, bodyPart);
		modify = (modify + DomainManager.SpecialEffect.GetModify(defenderId, skillId, defenderFieldId, bodyPart)).MaxB(33);
		value *= modify;
		value = DomainManager.SpecialEffect.ModifyData(attackerId, skillId, attackerFieldId, value);
		value = DomainManager.SpecialEffect.ModifyData(defenderId, skillId, defenderFieldId, value);
		return (int)Math.Clamp(value, 0L, 2147483647L);
	}

	public OuterAndInnerInts GetPenetrateResist(CombatContext context)
	{
		GameData.Domains.Item.Weapon weapon = context.Weapon;
		sbyte bodyPart = context.BodyPart;
		short skillId = context.SkillTemplateId;
		int outer = GetPenetrateResist(inner: false, weapon, bodyPart, skillId);
		int inner = GetPenetrateResist(inner: true, weapon, bodyPart, skillId);
		return new OuterAndInnerInts(outer, inner);
	}

	public int GetPenetrateResist(bool inner, GameData.Domains.Item.Weapon weapon, sbyte bodyPart, short skillId = -1, bool ignoreDefendSkill = false)
	{
		long value = (inner ? _character.GetPenetrationResists().Inner : _character.GetPenetrationResists().Outer);
		value *= CalcArmorPenetrateResistFactor(weapon, inner, bodyPart, skillId);
		CombatCharacter enemyChar = _combatDomain.GetCombatCharacter(!IsAlly);
		int attackerId = enemyChar.GetId();
		int defenderId = _id;
		ushort attackerFieldId = (ushort)(inner ? 67 : 66);
		ushort defenderFieldId = (ushort)(inner ? 101 : 100);
		CValueModify modify = CalcTeammatePenetrateResistModify().ChangeA(CalcDefendSkillAddPenetrateResistValue(inner, ignoreDefendSkill));
		modify += DomainManager.SpecialEffect.GetModify(attackerId, skillId, attackerFieldId, bodyPart);
		modify = (modify + DomainManager.SpecialEffect.GetModify(defenderId, skillId, defenderFieldId, bodyPart)).MaxB(33);
		value *= modify;
		value = DomainManager.SpecialEffect.ModifyData(attackerId, skillId, attackerFieldId, value);
		value = DomainManager.SpecialEffect.ModifyData(defenderId, skillId, defenderFieldId, value);
		return (int)Math.Clamp(value, 1L, 2147483647L);
	}

	public sbyte GetOrRandomChangeTrickType(IRandomSource random)
	{
		sbyte[] weaponTricks = GetWeaponTricks();
		if (PlayerChangeTrickType >= 0 && weaponTricks.Exist(PlayerChangeTrickType))
		{
			return PlayerChangeTrickType;
		}
		return weaponTricks.GetRandom(random);
	}

	public sbyte RandomChangeTrickBodyPart(IRandomSource random, sbyte trickType, short skillId = -1)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		CombatDomain combat = DomainManager.Combat;
		sbyte trickType2 = trickType;
		return combat.GetAttackBodyPart(this, enemyChar, random, skillId, trickType2, -1);
	}

	public sbyte RandomChangeTrickBodyPartByNeiliType(IRandomSource random, sbyte trickType)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		Dictionary<SkillEffectKey, short> effectDict = GetSkillEffectCollection().EffectDict;
		if (effectDict != null && effectDict.Keys.Any((SkillEffectKey x) => x.EffectConfig.TransferProportion > 0))
		{
			byte enemyFiveElements = NeiliType.Instance[enemyChar.OriginNeiliType].FiveElements;
			if (enemyFiveElements != 5)
			{
				return BodyPartType.TransferFromFiveElementsType(FiveElementsType.Countered[enemyFiveElements]);
			}
			byte selfFiveElements = NeiliType.Instance[GetNeiliType()].FiveElements;
			if (selfFiveElements != 5)
			{
				return BodyPartType.TransferFromFiveElementsType(FiveElementsType.Countering[selfFiveElements]);
			}
		}
		return DomainManager.Combat.GetAttackBodyPart(this, enemyChar, random, -1, trickType, -1);
	}

	public sbyte RandomInjuryBodyPart(IRandomSource random, bool inner, IEnumerable<sbyte> partRange = null)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		pool.Clear();
		if (partRange == null)
		{
			partRange = GetAvailableBodyParts();
		}
		foreach (sbyte possiblePart in partRange)
		{
			if (_injuries.Get(possiblePart, inner) < 6)
			{
				pool.Add(possiblePart);
			}
		}
		sbyte part = (sbyte)((pool.Count > 0) ? pool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		return part;
	}

	public sbyte RandomInjuryBodyPartMustValid(IRandomSource random, bool inner, IEnumerable<sbyte> partRange = null)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		if (partRange == null)
		{
			partRange = GetAvailableBodyParts();
		}
		pool.AddRange(partRange);
		sbyte part = RandomInjuryBodyPart(random, inner, pool);
		if (part < 0)
		{
			part = pool.GetRandom(random);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		return part;
	}

	public void CreateGangqi(DataContext context, int value)
	{
		if (value > _gangqiMax)
		{
			SetGangqi(value, context);
			SetGangqiMax(value, context);
		}
	}

	public void ChangeGangqi(DataContext context, int delta)
	{
		int newGangqi = Math.Clamp(_gangqi + delta, 0, _gangqiMax);
		SetGangqi(newGangqi, context);
	}

	public bool CanExecuteTeammateCommandImmediate(ETeammateCommandImplement implement)
	{
		if (DomainManager.Combat.Pause)
		{
			return false;
		}
		ECombatReserveType type = _combatReserveData.Type;
		if ((type != ECombatReserveType.Invalid && type != ECombatReserveType.TeammateCommand) || 1 == 0)
		{
			return false;
		}
		CombatReserveData prevReserveData = _combatReserveData;
		_combatReserveData = CombatReserveData.Invalid;
		bool hasDoingOrReserve = HasDoingOrReserveCommand();
		_combatReserveData = prevReserveData;
		if (!hasDoingOrReserve)
		{
			return true;
		}
		if (StateMachine.GetCurrentStateType() == CombatCharacterStateType.TeammateCommand)
		{
			return true;
		}
		bool flag = _preparingSkillId >= 0;
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3 = ((implement == ETeammateCommandImplement.AccelerateCast || implement == ETeammateCommandImplement.InterruptSkill) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return true;
		}
		if ((_preparingOtherAction >= 0 || _preparingItem.IsValid()) && implement == ETeammateCommandImplement.InterruptOtherAction)
		{
			return true;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!IsAlly);
		if (enemyChar.GetPreparingSkillId() >= 0 && implement == ETeammateCommandImplement.InterruptEnemySkill)
		{
			return true;
		}
		return false;
	}

	public bool CanExecuteReserveTeammateCommand()
	{
		if (_combatReserveData.Type != ECombatReserveType.TeammateCommand)
		{
			return false;
		}
		CombatCharacter teammate = DomainManager.Combat.GetElement_CombatCharacterDict(_combatReserveData.TeammateCharId);
		sbyte cmdType = (sbyte)(_showTransferInjuryCommand ? 13 : teammate.GetCurrTeammateCommands()[_combatReserveData.TeammateCmdIndex]);
		return CanExecuteTeammateCommandImmediate(TeammateCommand.Instance[cmdType].Implement);
	}

	public bool ExecuteTeammateCommandImmediate(DataContext context, int charId, int index)
	{
		CombatCharacter teammateChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		if (teammateChar.IsAlly != IsAlly || !DomainManager.Combat.IsMainCharacter(this))
		{
			return false;
		}
		sbyte cmdType = (sbyte)(_showTransferInjuryCommand ? 13 : teammateChar.GetCurrTeammateCommands()[index]);
		TeammateCommandItem config = TeammateCommand.Instance[cmdType];
		ETeammateCommandImplement implement = config.Implement;
		teammateChar.ExecutingTeammateCommandConfig = config;
		if (implement.IsFight())
		{
			if (implement == ETeammateCommandImplement.FightSpecialGrow)
			{
				teammateChar.FightSpecialGrowBonus = Math.Min(teammateChar.FightSpecialGrowBonus + config.IntArg, config.SubIntArg);
			}
			ChangeCharId = charId;
			teammateChar.ExecutingTeammateCommandIndex = index;
			DomainManager.Combat.ClearAllWeaponCd(context, teammateChar);
		}
		else if (implement == ETeammateCommandImplement.AttackSkill)
		{
			ChangeCharId = charId;
			teammateChar.ExecutingTeammateCommandIndex = index;
			DomainManager.Combat.CastSkillFree(context, teammateChar, teammateChar.GetAttackCommandSkillId());
			int weapon = teammateChar.AiController.GetBestWeaponIndex(context.Random, teammateChar.NeedUseSkillFreeId);
			if (teammateChar.GetUsingWeaponIndex() != weapon)
			{
				DomainManager.Combat.ChangeWeapon(context, teammateChar, weapon);
			}
			OuterAndInnerShorts attackRange = teammateChar.GetAttackRange();
			short bestDistance = (short)((attackRange.Outer + attackRange.Inner) / 2);
			int moveDistance = bestDistance - DomainManager.Combat.GetCurrentDistance();
			if (DomainManager.Combat.ChangeDistance(context, this, moveDistance))
			{
				teammateChar.ExecutingTeammateCommandChangeDistance = -moveDistance;
			}
			DomainManager.Combat.ClearAllWeaponCd(context, teammateChar);
		}
		else
		{
			teammateChar.SetExecutingTeammateCommand(cmdType, context);
			teammateChar.TeammateCommandLeftPrepareFrame = (teammateChar.TeammateCommandTotalPrepareFrame = teammateChar.ExecutingTeammateCommandConfig.PrepareFrame);
			TeammateHasCommand[DomainManager.Combat.GetCharacterList(IsAlly).IndexOf(charId) - 1] = true;
			if (teammateChar.ExecutingTeammateCommandConfig.IntoCombatField)
			{
				switch (implement)
				{
				case ETeammateCommandImplement.HealInjury:
					teammateChar.TeammateCommandLeftPrepareFrame = (teammateChar.TeammateCommandTotalPrepareFrame = teammateChar.GetOtherActionPrepareFrame(0));
					break;
				case ETeammateCommandImplement.HealPoison:
					teammateChar.TeammateCommandLeftPrepareFrame = (teammateChar.TeammateCommandTotalPrepareFrame = teammateChar.GetOtherActionPrepareFrame(1));
					break;
				default:
					if (implement.IsAttack())
					{
						ItemKey attackWeapon = teammateChar.GetAttackCommandWeaponKey();
						int attackWeaponIndex = teammateChar.GetWeapons().IndexOf(attackWeapon);
						if (teammateChar.GetUsingWeaponIndex() != attackWeaponIndex)
						{
							DomainManager.Combat.ChangeWeapon(context, teammateChar, attackWeaponIndex);
						}
					}
					break;
				}
			}
			if (teammateChar.ExecutingTeammateCommandConfig.AffectFrame >= 0)
			{
				teammateChar.ExecutingTeammateCommandIndex = index;
			}
			else if (teammateChar.CheckResetTeammateCommandCd(config))
			{
				teammateChar.ResetTeammateCommandCd(context, index, -1, checkEvent: true);
			}
		}
		teammateChar.SetShowEffectCommandIndex((sbyte)index, context);
		if (implement.IsFight() || implement.IsMove())
		{
			MoveData.ResetJumpState(context);
		}
		bool changeState = UpdateTeammateCharStatus(context);
		DomainManager.Combat.UpdateAllCommandAvailability(context, this);
		Events.RaiseTeammateCommandExecuted(context, _id, charId, cmdType);
		return changeState;
	}

	public bool ExecuteReserveTeammateCommand(DataContext context)
	{
		if (!CanExecuteReserveTeammateCommand())
		{
			return false;
		}
		int charId = _combatReserveData.TeammateCharId;
		int index = _combatReserveData.TeammateCmdIndex;
		SetCombatReserveData(CombatReserveData.Invalid, context);
		CombatCharacter teammate = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		if (!teammate.GetTeammateCommandCanUse()[index])
		{
			return false;
		}
		return ExecuteTeammateCommandImmediate(context, charId, index);
	}

	private bool CheckResetTeammateCommandCd(TeammateCommandItem commandConfig)
	{
		if (commandConfig.Type != ETeammateCommandType.Advance)
		{
			return true;
		}
		switch (commandConfig.Implement)
		{
		case ETeammateCommandImplement.Push:
			if (NeedResetAdvanceTeammateCommandPushCd)
			{
				NeedResetAdvanceTeammateCommandPushCd = false;
				return true;
			}
			NeedResetAdvanceTeammateCommandPushCd = true;
			return false;
		case ETeammateCommandImplement.Pull:
			if (NeedResetAdvanceTeammateCommandPullCd)
			{
				NeedResetAdvanceTeammateCommandPullCd = false;
				return true;
			}
			NeedResetAdvanceTeammateCommandPullCd = true;
			return false;
		default:
			return true;
		}
	}

	public void ApplyAddPowerUntilCast(DataContext context, int unit)
	{
		AddPowerUntilCastUnit = unit;
		SetExecutingTeammateCommand(_executingTeammateCommand, context);
	}

	public void ClearAddPowerUntilCast(DataContext context)
	{
		AddPowerUntilCastUnit = 0;
		SetExecutingTeammateCommand(_executingTeammateCommand, context);
	}

	public CValueModifyDelta CalcAddPowerUntilCast(short skillId)
	{
		if (AddPowerUntilCastUnit <= 0 || !CombatSkillEquipType.IsAttack(skillId))
		{
			return CValueModifyDelta.Zero;
		}
		CombatSkillItem config = Config.CombatSkill.Instance[skillId];
		List<sbyte> list = config?.NeedBodyPartTypes;
		if (list == null || list.Count <= 0)
		{
			return CValueModifyDelta.Zero;
		}
		HashSet<sbyte> bodyParts = ObjectPool<HashSet<sbyte>>.Instance.Get();
		foreach (sbyte needBodyPartType in config.NeedBodyPartTypes)
		{
			foreach (sbyte bodyPart in NeedBodyPartType.ParseBodyParts(needBodyPartType))
			{
				bodyParts.Add(bodyPart);
			}
		}
		int unit = 0;
		foreach (sbyte bodyPart2 in bodyParts)
		{
			unit += _injuries.GetSum(bodyPart2);
		}
		ObjectPool<HashSet<sbyte>>.Instance.Return(bodyParts);
		return new CValueModifyDelta(EDataModifyType.Add, unit * AddPowerUntilCastUnit);
	}

	public bool TrickEquals(sbyte trick1, sbyte trick2)
	{
		if (trick1 == trick2)
		{
			return true;
		}
		return InterchangeableTricks.Contains(trick1) && InterchangeableTricks.Contains(trick2) && _weaponTricks.Exist(InterchangeableTricks.Contains);
	}

	public bool IsTrickUsable(sbyte trickType)
	{
		if (trickType == 21)
		{
			return true;
		}
		sbyte[] weaponTricks = _combatDomain.GetUsingWeaponData(this).GetWeaponTricks();
		if (Enumerable.Contains(weaponTricks, trickType))
		{
			return true;
		}
		return InterchangeableTricks.Contains(trickType) && InterchangeableTricks.Any(((IEnumerable<sbyte>)weaponTricks).Contains<sbyte>);
	}

	public bool IsTrickUseless(sbyte trickType)
	{
		return !IsTrickUsable(trickType);
	}

	public int ReplaceUsableTrick(DataContext context, sbyte trickType, int count = -1)
	{
		if (count == 0)
		{
			return 0;
		}
		IReadOnlyDictionary<int, sbyte> tricks = _tricks.Tricks;
		List<int> indexList = ObjectPool<List<int>>.Instance.Get();
		indexList.Clear();
		indexList.AddRange(tricks.Where(delegate(KeyValuePair<int, sbyte> kvp)
		{
			KeyValuePair<int, sbyte> keyValuePair = kvp;
			int result;
			if (keyValuePair.Value != trickType)
			{
				CombatCharacter combatCharacter = this;
				keyValuePair = kvp;
				result = (combatCharacter.IsTrickUsable(keyValuePair.Value) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Select(delegate(KeyValuePair<int, sbyte> kvp)
		{
			KeyValuePair<int, sbyte> keyValuePair = kvp;
			return keyValuePair.Key;
		}));
		int reserveCount = ((count > 0) ? (indexList.Count - Math.Min(count, indexList.Count)) : 0);
		for (int i = 0; i < reserveCount; i++)
		{
			CollectionUtils.SwapAndRemove(indexList, context.Random.Next(indexList.Count));
		}
		foreach (int index in indexList)
		{
			_tricks.ReplaceTrick(index, trickType);
		}
		int replacedCount = indexList.Count;
		ObjectPool<List<int>>.Instance.Return(indexList);
		SetTricks(_tricks, context);
		return replacedCount;
	}

	public byte GetTrickCount(sbyte type)
	{
		return GetTrickCount(type, useTrickEquals: false);
	}

	public byte GetTrickCount(sbyte type, bool useTrickEquals)
	{
		byte trickCounter = 0;
		foreach (sbyte trickType in _tricks.Tricks.Values)
		{
			if (useTrickEquals ? TrickEquals(trickType, type) : (trickType == type))
			{
				trickCounter++;
			}
		}
		return trickCounter;
	}

	public sbyte GetTrickAtStart()
	{
		using (IEnumerator<sbyte> enumerator = _tricks.Tricks.Values.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return -1;
	}

	public int GetContinueTricksAtStart(sbyte trickType)
	{
		int count = 0;
		foreach (sbyte trick in _tricks.Tricks.Values)
		{
			if (trick == trickType)
			{
				count++;
				continue;
			}
			break;
		}
		return (count > 1) ? count : 0;
	}

	public int GetContinueTricks(sbyte trickType, List<int> indexList = null)
	{
		IReadOnlyDictionary<int, sbyte> trickDict = _tricks.Tricks;
		int maxContinueCount = 0;
		int curContinueCount = 0;
		List<int> checkingContinue = ObjectPool<List<int>>.Instance.Get();
		checkingContinue.Clear();
		foreach (var (index, trick) in trickDict)
		{
			if (trick == trickType)
			{
				curContinueCount++;
				checkingContinue.Add(index);
				if (curContinueCount >= 2 && curContinueCount > maxContinueCount)
				{
					maxContinueCount = curContinueCount;
					indexList?.Clear();
					indexList?.AddRange(checkingContinue);
				}
			}
			else
			{
				curContinueCount = 0;
				checkingContinue.Clear();
			}
		}
		ObjectPool<List<int>>.Instance.Return(checkingContinue);
		return maxContinueCount;
	}

	public void InvokeExtraUnlockEffect(IExtraUnlockEffect effect, int weaponIndex)
	{
		if (CanInvokeExtraUnlockEffect(effect, weaponIndex))
		{
			_invokedUnlockEffects.Add(effect);
		}
	}

	public void DoExtraUnlockEffect(DataContext context, int weaponIndex)
	{
		CollectionUtils.Shuffle(context.Random, _invokedUnlockEffects);
		foreach (IExtraUnlockEffect effect in _invokedUnlockEffects)
		{
			if (DoExtraUnlockEffectCost(context, effect, weaponIndex))
			{
				_costedUnlockEffects.Add(effect);
			}
		}
		_invokedUnlockEffects.Clear();
		foreach (IExtraUnlockEffect effect2 in _costedUnlockEffects)
		{
			effect2.DoAffectAfterCost(context, weaponIndex);
		}
		_costedUnlockEffects.Clear();
	}

	private bool CanInvokeExtraUnlockEffect(IExtraUnlockEffect effect, int weaponIndex)
	{
		ItemKey key = GetWeapons()[weaponIndex];
		if (!key.IsValid())
		{
			return false;
		}
		short durability = DomainManager.Item.GetBaseItem(key).GetCurrDurability();
		int trickCount = (effect.IsDirect ? GetTrickCount(12) : UsableTrickCount);
		trickCount += TryInsteadTrick(effect);
		if (effect.IsDirect)
		{
			return trickCount >= 2 || durability > 4;
		}
		return trickCount >= 3 && durability > 8;
	}

	private int TryInsteadTrick(IExtraUnlockEffect effect, DataContext context = null)
	{
		if (!effect.IsDirect && IsTrickUsable(12))
		{
			return 0;
		}
		int maxInsteadCount = DomainManager.SpecialEffect.ModifyData(_id, -1, (ushort)(effect.IsDirect ? 312 : 311), 0);
		int canInsteadCount = (effect.IsDirect ? UselessTrickCount : GetTrickCount(12));
		byte requireInsteadCount = (byte)(effect.IsDirect ? 2 : 3);
		int insteadCount = Math.Min(Math.Min(maxInsteadCount, canInsteadCount), requireInsteadCount);
		if (context == null)
		{
			return insteadCount;
		}
		if (effect.IsDirect)
		{
			List<sbyte> uselessTricks = ObjectPool<List<sbyte>>.Instance.Get();
			uselessTricks.AddRange(_tricks.Tricks.Values.Where(IsTrickUseless));
			IEnumerable<sbyte> costTricks = RandomUtils.GetRandomUnrepeated(context.Random, insteadCount, uselessTricks);
			_combatDomain.RemoveTrick(context, this, costTricks);
			ObjectPool<List<sbyte>>.Instance.Return(uselessTricks);
			Events.RaiseUselessTrickInsteadJiTricks(context, this, insteadCount);
		}
		else
		{
			_combatDomain.RemoveTrick(context, this, 12, (byte)insteadCount);
			Events.RaiseJiTrickInsteadCostTricks(context, this, insteadCount);
		}
		return insteadCount;
	}

	private bool DoExtraUnlockEffectCost(DataContext context, IExtraUnlockEffect effect, int weaponIndex)
	{
		if (!CanInvokeExtraUnlockEffect(effect, weaponIndex))
		{
			return false;
		}
		bool useJiTrick = effect.IsDirect && GetTrickCount(12) + TryInsteadTrick(effect) >= 2;
		bool useDurability = !useJiTrick || !effect.IsDirect;
		if (useJiTrick)
		{
			int costTrickCount = 2 - TryInsteadTrick(effect, context);
			_combatDomain.RemoveTrick(context, this, 12, (byte)costTrickCount);
		}
		if (!effect.IsDirect)
		{
			int costTrickCount2 = 3 - TryInsteadTrick(effect, context);
			List<sbyte> usableTricks = ObjectPool<List<sbyte>>.Instance.Get();
			usableTricks.AddRange(_tricks.Tricks.Values.Where(IsTrickUsable));
			IEnumerable<sbyte> costTricks = RandomUtils.GetRandomUnrepeated(context.Random, costTrickCount2, usableTricks);
			_combatDomain.RemoveTrick(context, this, costTricks);
			ObjectPool<List<sbyte>>.Instance.Return(usableTricks);
		}
		ItemKey weaponKey = _weapons[weaponIndex];
		int durability = (effect.IsDirect ? 4 : 8);
		if (useDurability)
		{
			_combatDomain.ChangeDurability(context, this, weaponKey, -durability, EChangeDurabilitySourceType.Unlock);
		}
		return true;
	}

	public int GetRecoverUnlockAttackValue(ItemKey weaponKey)
	{
		int value = 0;
		foreach (short skillId in GetCombatSkillIds())
		{
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: _id, skillId: skillId), out var skill))
			{
				continue;
			}
			SpecialEffectItem effectConfig = skill.TryGetSpecialEffect();
			if (effectConfig != null)
			{
				short itemSubType = ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId);
				if (itemSubType == effectConfig.AddUnlockValueItemSubType)
				{
					value = Math.Max(value, effectConfig.AddUnlockValue);
				}
			}
		}
		return value;
	}

	public bool WorsenInjury(DataContext context, sbyte bodyPart, bool inner)
	{
		return WorsenInjury(context, bodyPart, inner, WorsenConstants.DefaultPercent);
	}

	public bool WorsenInjury(DataContext context, sbyte bodyPart, bool inner, CValuePercent percent)
	{
		if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
		{
			return false;
		}
		sbyte injuryCount = _injuries.Get(bodyPart, inner);
		if (injuryCount <= 0)
		{
			return false;
		}
		int step = (inner ? _damageStepCollection.InnerDamageSteps : _damageStepCollection.OuterDamageSteps)[bodyPart];
		int addFatalDamage = step * WorsenConstants.WorsenFatalPercent[injuryCount - 1] * percent;
		if (addFatalDamage > 0)
		{
			AddFatalDamage(context, addFatalDamage, inner ? 1 : 0, bodyPart, -1);
		}
		return addFatalDamage > 0;
	}

	public bool WorsenRandomInjury(DataContext context)
	{
		return WorsenRandomInjury(context, WorsenConstants.DefaultPercent);
	}

	public bool WorsenRandomInjury(DataContext context, CValuePercent percent)
	{
		return WorsenRandomInjury(context, RandomWorsenIsInner(context.Random), percent);
	}

	public bool WorsenRandomInjury(DataContext context, sbyte bodyPart)
	{
		return WorsenRandomInjury(context, bodyPart, WorsenConstants.DefaultPercent);
	}

	public bool WorsenRandomInjury(DataContext context, sbyte bodyPart, CValuePercent percent)
	{
		return WorsenRandomInjury(context, RandomWorsenIsInner(context.Random, bodyPart), percent);
	}

	public bool WorsenRandomInjury(DataContext context, bool inner)
	{
		return WorsenRandomInjury(context, inner, WorsenConstants.DefaultPercent);
	}

	public bool WorsenRandomInjury(DataContext context, bool inner, CValuePercent percent)
	{
		sbyte bodyPart = RandomWorsenBodyPart(context.Random, inner);
		return bodyPart >= 0 && WorsenInjury(context, bodyPart, inner, percent);
	}

	public void WorsenRepeatableInjury(DataContext context, int count)
	{
		WorsenRepeatableInjury(context, count, WorsenConstants.DefaultPercent);
	}

	public void WorsenRepeatableInjury(DataContext context, int count, CValuePercent percent)
	{
		for (int i = 0; i < count; i++)
		{
			WorsenRandomInjury(context, percent);
		}
	}

	public void WorsenRepeatableInjury(DataContext context, bool inner, int count)
	{
		WorsenRepeatableInjury(context, inner, count, WorsenConstants.DefaultPercent);
	}

	public void WorsenRepeatableInjury(DataContext context, bool inner, int count, CValuePercent percent)
	{
		for (int i = 0; i < count; i++)
		{
			WorsenRandomInjury(context, inner, percent);
		}
	}

	public void WorsenUnrepeatedInjury(DataContext context, int count)
	{
		WorsenUnrepeatedInjury(context, count, WorsenConstants.DefaultPercent);
	}

	public void WorsenUnrepeatedInjury(DataContext context, int count, CValuePercent percent)
	{
		List<sbyte> innerBodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> outerBodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (_injuries.Get(i, isInnerInjury: true) > 0)
			{
				innerBodyParts.Add(i);
			}
			if (_injuries.Get(i, isInnerInjury: false) > 0)
			{
				outerBodyParts.Add(i);
			}
		}
		for (int j = 0; j < count; j++)
		{
			bool anyInner = innerBodyParts.Count > 0;
			bool anyOuter = outerBodyParts.Count > 0;
			if (!anyInner && !anyOuter)
			{
				break;
			}
			bool inner = context.Random.RandomIsInner(anyInner, anyOuter);
			sbyte bodyPart = (inner ? innerBodyParts : outerBodyParts).GetRandom(context.Random);
			if (inner)
			{
				innerBodyParts.Remove(bodyPart);
			}
			else
			{
				outerBodyParts.Remove(bodyPart);
			}
			WorsenInjury(context, bodyPart, inner, percent);
		}
		ObjectPool<List<sbyte>>.Instance.Return(innerBodyParts);
		ObjectPool<List<sbyte>>.Instance.Return(outerBodyParts);
	}

	public void WorsenUnrepeatedInjury(DataContext context, bool inner, int count)
	{
		WorsenUnrepeatedInjury(context, inner, count, WorsenConstants.DefaultPercent);
	}

	public void WorsenUnrepeatedInjury(DataContext context, bool inner, int count, CValuePercent percent)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (_injuries.Get(i, inner) > 0)
			{
				pool.Add(i);
			}
		}
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, count, pool))
		{
			WorsenInjury(context, bodyPart, inner, percent);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	public bool WorsenAllInjury(DataContext context)
	{
		return WorsenAllInjury(context, WorsenConstants.DefaultPercent);
	}

	public bool WorsenAllInjury(DataContext context, CValuePercent percent)
	{
		bool anyWorsen = WorsenAllInjury(context, inner: true, percent);
		return WorsenAllInjury(context, inner: false, percent) || anyWorsen;
	}

	public bool WorsenAllInjury(DataContext context, bool inner)
	{
		return WorsenAllInjury(context, inner, WorsenConstants.DefaultPercent);
	}

	public bool WorsenAllInjury(DataContext context, bool inner, CValuePercent percent)
	{
		bool anyWorsen = false;
		for (sbyte i = 0; i < 7; i++)
		{
			if (_injuries.Get(i, inner) > 0)
			{
				anyWorsen = WorsenInjury(context, i, inner, percent) || anyWorsen;
			}
		}
		return anyWorsen;
	}

	private bool RandomWorsenIsInner(IRandomSource random)
	{
		bool anyInner = _injuries.HasAnyInjury(isInnerInjury: true);
		bool anyOuter = _injuries.HasAnyInjury(isInnerInjury: false);
		return random.RandomIsInner(anyInner, anyOuter);
	}

	private bool RandomWorsenIsInner(IRandomSource random, sbyte bodyPart)
	{
		if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
		{
			return RandomWorsenIsInner(random);
		}
		bool anyInner = _injuries.Get(bodyPart, isInnerInjury: true) > 0;
		bool anyOuter = _injuries.Get(bodyPart, isInnerInjury: false) > 0;
		return random.RandomIsInner(anyInner, anyOuter);
	}

	private sbyte RandomWorsenBodyPart(IRandomSource random, bool inner)
	{
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (_injuries.Get(i, inner) > 0)
			{
				pool.Add(i);
			}
		}
		sbyte bodyPart = (sbyte)((pool.Count > 0) ? pool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(pool);
		return bodyPart;
	}

	public bool AddWug(DataContext context, short wugTemplateId, int srcCharId, EWugReplaceType replaceType = EWugReplaceType.CombatOnly, short specifyDuration = -1)
	{
		if (!DomainManager.SpecialEffect.ModifyData(_id, -1, 180, dataValue: true, srcCharId))
		{
			return false;
		}
		MedicineItem wugConfig = Config.Medicine.Instance[wugTemplateId];
		EatingItems eatingItems = _character.GetEatingItems();
		int index = eatingItems.IndexOfWug(wugConfig);
		if (index >= 0 && !replaceType.IsMatchWug(eatingItems.Get(index).TemplateId, wugTemplateId))
		{
			return false;
		}
		_character.AddWug(context, wugTemplateId, specifyDuration);
		return true;
	}

	public void AddWugIrresistibly(DataContext context, ItemKey wugItemKey)
	{
		_character.AddEatingItem(context, wugItemKey);
	}

	public short RandomExistWug(IRandomSource random, EWugReplaceType replaceType = EWugReplaceType.CombatOnly)
	{
		List<short> allExistWug = ObjectPool<List<short>>.Instance.Get();
		allExistWug.Clear();
		EatingItems eatingItems = _character.GetEatingItems();
		for (sbyte wugType = 0; wugType < 8; wugType++)
		{
			int index = eatingItems.IndexOfWug(wugType);
			if (index >= 0)
			{
				short wugTemplateId = eatingItems.Get(index).TemplateId;
				if (replaceType.IsMatchWug(wugTemplateId, -1))
				{
					allExistWug.Add(wugTemplateId);
				}
			}
		}
		short removeWugTemplateId = (short)((allExistWug.Count > 0) ? allExistWug.GetRandom(random) : (-1));
		ObjectPool<List<short>>.Instance.Return(allExistWug);
		return removeWugTemplateId;
	}

	public int GetId()
	{
		return _id;
	}

	public int GetBreathValue()
	{
		return _breathValue;
	}

	public void SetBreathValue(int breathValue, DataContext context)
	{
		_breathValue = breathValue;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public int GetStanceValue()
	{
		return _stanceValue;
	}

	public void SetStanceValue(int stanceValue, DataContext context)
	{
		_stanceValue = stanceValue;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public NeiliAllocation GetNeiliAllocation()
	{
		return _neiliAllocation;
	}

	public void SetNeiliAllocation(NeiliAllocation neiliAllocation, DataContext context)
	{
		_neiliAllocation = neiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public NeiliAllocation GetOriginNeiliAllocation()
	{
		return _originNeiliAllocation;
	}

	public void SetOriginNeiliAllocation(NeiliAllocation originNeiliAllocation, DataContext context)
	{
		_originNeiliAllocation = originNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public NeiliAllocation GetNeiliAllocationRecoverProgress()
	{
		return _neiliAllocationRecoverProgress;
	}

	public void SetNeiliAllocationRecoverProgress(NeiliAllocation neiliAllocationRecoverProgress, DataContext context)
	{
		_neiliAllocationRecoverProgress = neiliAllocationRecoverProgress;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public short GetOldDisorderOfQi()
	{
		return _oldDisorderOfQi;
	}

	public void SetOldDisorderOfQi(short oldDisorderOfQi, DataContext context)
	{
		_oldDisorderOfQi = oldDisorderOfQi;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public sbyte GetNeiliType()
	{
		return _neiliType;
	}

	public void SetNeiliType(sbyte neiliType, DataContext context)
	{
		_neiliType = neiliType;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public ShowAvoidData GetAvoidToShow()
	{
		return _avoidToShow;
	}

	public void SetAvoidToShow(ShowAvoidData avoidToShow, DataContext context)
	{
		_avoidToShow = avoidToShow;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public int GetCurrentPosition()
	{
		return _currentPosition;
	}

	public void SetCurrentPosition(int currentPosition, DataContext context)
	{
		_currentPosition = currentPosition;
		SetModifiedAndInvalidateInfluencedCache(9, context);
	}

	public int GetDisplayPosition()
	{
		return _displayPosition;
	}

	public void SetDisplayPosition(int displayPosition, DataContext context)
	{
		_displayPosition = displayPosition;
		SetModifiedAndInvalidateInfluencedCache(10, context);
	}

	public int GetMobilityValue()
	{
		return _mobilityValue;
	}

	public void SetMobilityValue(int mobilityValue, DataContext context)
	{
		_mobilityValue = mobilityValue;
		SetModifiedAndInvalidateInfluencedCache(11, context);
	}

	public sbyte GetJumpPrepareProgress()
	{
		return _jumpPrepareProgress;
	}

	public void SetJumpPrepareProgress(sbyte jumpPrepareProgress, DataContext context)
	{
		_jumpPrepareProgress = jumpPrepareProgress;
		SetModifiedAndInvalidateInfluencedCache(12, context);
	}

	public short GetJumpPreparedDistance()
	{
		return _jumpPreparedDistance;
	}

	public void SetJumpPreparedDistance(short jumpPreparedDistance, DataContext context)
	{
		_jumpPreparedDistance = jumpPreparedDistance;
		SetModifiedAndInvalidateInfluencedCache(13, context);
	}

	public short GetMobilityLockEffectCount()
	{
		return _mobilityLockEffectCount;
	}

	public void SetMobilityLockEffectCount(short mobilityLockEffectCount, DataContext context)
	{
		_mobilityLockEffectCount = mobilityLockEffectCount;
		SetModifiedAndInvalidateInfluencedCache(14, context);
	}

	public float GetJumpChangeDistanceDuration()
	{
		return _jumpChangeDistanceDuration;
	}

	public void SetJumpChangeDistanceDuration(float jumpChangeDistanceDuration, DataContext context)
	{
		_jumpChangeDistanceDuration = jumpChangeDistanceDuration;
		SetModifiedAndInvalidateInfluencedCache(15, context);
	}

	public int GetUsingWeaponIndex()
	{
		return _usingWeaponIndex;
	}

	public void SetUsingWeaponIndex(int usingWeaponIndex, DataContext context)
	{
		_usingWeaponIndex = usingWeaponIndex;
		SetModifiedAndInvalidateInfluencedCache(16, context);
	}

	public sbyte[] GetWeaponTricks()
	{
		return _weaponTricks;
	}

	public void SetWeaponTricks(sbyte[] weaponTricks, DataContext context)
	{
		_weaponTricks = weaponTricks;
		SetModifiedAndInvalidateInfluencedCache(17, context);
	}

	public byte GetWeaponTrickIndex()
	{
		return _weaponTrickIndex;
	}

	public void SetWeaponTrickIndex(byte weaponTrickIndex, DataContext context)
	{
		_weaponTrickIndex = weaponTrickIndex;
		SetModifiedAndInvalidateInfluencedCache(18, context);
	}

	public ItemKey[] GetWeapons()
	{
		return _weapons;
	}

	public void SetWeapons(ItemKey[] weapons, DataContext context)
	{
		_weapons = weapons;
		SetModifiedAndInvalidateInfluencedCache(19, context);
	}

	public sbyte GetAttackingTrickType()
	{
		return _attackingTrickType;
	}

	public void SetAttackingTrickType(sbyte attackingTrickType, DataContext context)
	{
		_attackingTrickType = attackingTrickType;
		SetModifiedAndInvalidateInfluencedCache(20, context);
	}

	public bool GetCanAttackOutRange()
	{
		return _canAttackOutRange;
	}

	public void SetCanAttackOutRange(bool canAttackOutRange, DataContext context)
	{
		_canAttackOutRange = canAttackOutRange;
		SetModifiedAndInvalidateInfluencedCache(21, context);
	}

	public sbyte GetChangeTrickProgress()
	{
		return _changeTrickProgress;
	}

	public void SetChangeTrickProgress(sbyte changeTrickProgress, DataContext context)
	{
		_changeTrickProgress = changeTrickProgress;
		SetModifiedAndInvalidateInfluencedCache(22, context);
	}

	public short GetChangeTrickCount()
	{
		return _changeTrickCount;
	}

	public void SetChangeTrickCount(short changeTrickCount, DataContext context)
	{
		_changeTrickCount = changeTrickCount;
		SetModifiedAndInvalidateInfluencedCache(23, context);
	}

	public bool GetCanChangeTrick()
	{
		return _canChangeTrick;
	}

	public void SetCanChangeTrick(bool canChangeTrick, DataContext context)
	{
		_canChangeTrick = canChangeTrick;
		SetModifiedAndInvalidateInfluencedCache(24, context);
	}

	public bool GetChangingTrick()
	{
		return _changingTrick;
	}

	public void SetChangingTrick(bool changingTrick, DataContext context)
	{
		_changingTrick = changingTrick;
		SetModifiedAndInvalidateInfluencedCache(25, context);
	}

	public bool GetChangeTrickAttack()
	{
		return _changeTrickAttack;
	}

	public void SetChangeTrickAttack(bool changeTrickAttack, DataContext context)
	{
		_changeTrickAttack = changeTrickAttack;
		SetModifiedAndInvalidateInfluencedCache(26, context);
	}

	public bool GetIsFightBack()
	{
		return _isFightBack;
	}

	public void SetIsFightBack(bool isFightBack, DataContext context)
	{
		_isFightBack = isFightBack;
		SetModifiedAndInvalidateInfluencedCache(27, context);
	}

	public TrickCollection GetTricks()
	{
		return _tricks;
	}

	public void SetTricks(TrickCollection tricks, DataContext context)
	{
		_tricks = tricks;
		SetModifiedAndInvalidateInfluencedCache(28, context);
	}

	public Injuries GetInjuries()
	{
		return _injuries;
	}

	public void SetInjuries(Injuries injuries, DataContext context)
	{
		_injuries = injuries;
		SetModifiedAndInvalidateInfluencedCache(29, context);
	}

	public Injuries GetOldInjuries()
	{
		return _oldInjuries;
	}

	public void SetOldInjuries(Injuries oldInjuries, DataContext context)
	{
		_oldInjuries = oldInjuries;
		SetModifiedAndInvalidateInfluencedCache(30, context);
	}

	public InjuryAutoHealCollection GetInjuryAutoHealCollection()
	{
		return _injuryAutoHealCollection;
	}

	public void SetInjuryAutoHealCollection(InjuryAutoHealCollection injuryAutoHealCollection, DataContext context)
	{
		_injuryAutoHealCollection = injuryAutoHealCollection;
		SetModifiedAndInvalidateInfluencedCache(31, context);
	}

	public DamageStepCollection GetDamageStepCollection()
	{
		return _damageStepCollection;
	}

	public void SetDamageStepCollection(DamageStepCollection damageStepCollection, DataContext context)
	{
		_damageStepCollection = damageStepCollection;
		SetModifiedAndInvalidateInfluencedCache(32, context);
	}

	public int[] GetOuterDamageValue()
	{
		return _outerDamageValue;
	}

	public void SetOuterDamageValue(int[] outerDamageValue, DataContext context)
	{
		_outerDamageValue = outerDamageValue;
		SetModifiedAndInvalidateInfluencedCache(33, context);
	}

	public int[] GetInnerDamageValue()
	{
		return _innerDamageValue;
	}

	public void SetInnerDamageValue(int[] innerDamageValue, DataContext context)
	{
		_innerDamageValue = innerDamageValue;
		SetModifiedAndInvalidateInfluencedCache(34, context);
	}

	public int GetMindDamageValue()
	{
		return _mindDamageValue;
	}

	public void SetMindDamageValue(int mindDamageValue, DataContext context)
	{
		_mindDamageValue = mindDamageValue;
		SetModifiedAndInvalidateInfluencedCache(35, context);
	}

	public int GetFatalDamageValue()
	{
		return _fatalDamageValue;
	}

	public void SetFatalDamageValue(int fatalDamageValue, DataContext context)
	{
		_fatalDamageValue = fatalDamageValue;
		SetModifiedAndInvalidateInfluencedCache(36, context);
	}

	public IntPair[] GetOuterDamageValueToShow()
	{
		return _outerDamageValueToShow;
	}

	public void SetOuterDamageValueToShow(IntPair[] outerDamageValueToShow, DataContext context)
	{
		_outerDamageValueToShow = outerDamageValueToShow;
		SetModifiedAndInvalidateInfluencedCache(37, context);
	}

	public IntPair[] GetInnerDamageValueToShow()
	{
		return _innerDamageValueToShow;
	}

	public void SetInnerDamageValueToShow(IntPair[] innerDamageValueToShow, DataContext context)
	{
		_innerDamageValueToShow = innerDamageValueToShow;
		SetModifiedAndInvalidateInfluencedCache(38, context);
	}

	public int GetMindDamageValueToShow()
	{
		return _mindDamageValueToShow;
	}

	public void SetMindDamageValueToShow(int mindDamageValueToShow, DataContext context)
	{
		_mindDamageValueToShow = mindDamageValueToShow;
		SetModifiedAndInvalidateInfluencedCache(39, context);
	}

	public int GetFatalDamageValueToShow()
	{
		return _fatalDamageValueToShow;
	}

	public void SetFatalDamageValueToShow(int fatalDamageValueToShow, DataContext context)
	{
		_fatalDamageValueToShow = fatalDamageValueToShow;
		SetModifiedAndInvalidateInfluencedCache(40, context);
	}

	public byte[] GetFlawCount()
	{
		return _flawCount;
	}

	public void SetFlawCount(byte[] flawCount, DataContext context)
	{
		_flawCount = flawCount;
		SetModifiedAndInvalidateInfluencedCache(41, context);
	}

	public FlawOrAcupointCollection GetFlawCollection()
	{
		return _flawCollection;
	}

	public void SetFlawCollection(FlawOrAcupointCollection flawCollection, DataContext context)
	{
		_flawCollection = flawCollection;
		SetModifiedAndInvalidateInfluencedCache(42, context);
	}

	public byte[] GetAcupointCount()
	{
		return _acupointCount;
	}

	public void SetAcupointCount(byte[] acupointCount, DataContext context)
	{
		_acupointCount = acupointCount;
		SetModifiedAndInvalidateInfluencedCache(43, context);
	}

	public FlawOrAcupointCollection GetAcupointCollection()
	{
		return _acupointCollection;
	}

	public void SetAcupointCollection(FlawOrAcupointCollection acupointCollection, DataContext context)
	{
		_acupointCollection = acupointCollection;
		SetModifiedAndInvalidateInfluencedCache(44, context);
	}

	public MindMarkList GetMindMarkTime()
	{
		return _mindMarkTime;
	}

	public void SetMindMarkTime(MindMarkList mindMarkTime, DataContext context)
	{
		_mindMarkTime = mindMarkTime;
		SetModifiedAndInvalidateInfluencedCache(45, context);
	}

	public ref PoisonInts GetPoison()
	{
		return ref _poison;
	}

	public void SetPoison(ref PoisonInts poison, DataContext context)
	{
		_poison = poison;
		SetModifiedAndInvalidateInfluencedCache(46, context);
	}

	public ref PoisonInts GetOldPoison()
	{
		return ref _oldPoison;
	}

	public void SetOldPoison(ref PoisonInts oldPoison, DataContext context)
	{
		_oldPoison = oldPoison;
		SetModifiedAndInvalidateInfluencedCache(47, context);
	}

	public ref PoisonInts GetPoisonResist()
	{
		return ref _poisonResist;
	}

	public void SetPoisonResist(ref PoisonInts poisonResist, DataContext context)
	{
		_poisonResist = poisonResist;
		SetModifiedAndInvalidateInfluencedCache(48, context);
	}

	public ref PoisonsAndLevels GetNewPoisonsToShow()
	{
		return ref _newPoisonsToShow;
	}

	public void SetNewPoisonsToShow(ref PoisonsAndLevels newPoisonsToShow, DataContext context)
	{
		_newPoisonsToShow = newPoisonsToShow;
		SetModifiedAndInvalidateInfluencedCache(49, context);
	}

	public DefeatMarkCollection GetDefeatMarkCollection()
	{
		return _defeatMarkCollection;
	}

	public void SetDefeatMarkCollection(DefeatMarkCollection defeatMarkCollection, DataContext context)
	{
		_defeatMarkCollection = defeatMarkCollection;
		SetModifiedAndInvalidateInfluencedCache(50, context);
	}

	public List<short> GetNeigongList()
	{
		return _neigongList;
	}

	public void SetNeigongList(List<short> neigongList, DataContext context)
	{
		_neigongList = neigongList;
		SetModifiedAndInvalidateInfluencedCache(51, context);
	}

	public List<short> GetAttackSkillList()
	{
		return _attackSkillList;
	}

	public void SetAttackSkillList(List<short> attackSkillList, DataContext context)
	{
		_attackSkillList = attackSkillList;
		SetModifiedAndInvalidateInfluencedCache(52, context);
	}

	public List<short> GetAgileSkillList()
	{
		return _agileSkillList;
	}

	public void SetAgileSkillList(List<short> agileSkillList, DataContext context)
	{
		_agileSkillList = agileSkillList;
		SetModifiedAndInvalidateInfluencedCache(53, context);
	}

	public List<short> GetDefenceSkillList()
	{
		return _defenceSkillList;
	}

	public void SetDefenceSkillList(List<short> defenceSkillList, DataContext context)
	{
		_defenceSkillList = defenceSkillList;
		SetModifiedAndInvalidateInfluencedCache(54, context);
	}

	public List<short> GetAssistSkillList()
	{
		return _assistSkillList;
	}

	public void SetAssistSkillList(List<short> assistSkillList, DataContext context)
	{
		_assistSkillList = assistSkillList;
		SetModifiedAndInvalidateInfluencedCache(55, context);
	}

	public short GetPreparingSkillId()
	{
		return _preparingSkillId;
	}

	public void SetPreparingSkillId(short preparingSkillId, DataContext context)
	{
		_preparingSkillId = preparingSkillId;
		SetModifiedAndInvalidateInfluencedCache(56, context);
	}

	public byte GetSkillPreparePercent()
	{
		return _skillPreparePercent;
	}

	public void SetSkillPreparePercent(byte skillPreparePercent, DataContext context)
	{
		_skillPreparePercent = skillPreparePercent;
		SetModifiedAndInvalidateInfluencedCache(57, context);
	}

	public short GetPerformingSkillId()
	{
		return _performingSkillId;
	}

	public void SetPerformingSkillId(short performingSkillId, DataContext context)
	{
		_performingSkillId = performingSkillId;
		SetModifiedAndInvalidateInfluencedCache(58, context);
	}

	public bool GetAutoCastingSkill()
	{
		return _autoCastingSkill;
	}

	public void SetAutoCastingSkill(bool autoCastingSkill, DataContext context)
	{
		_autoCastingSkill = autoCastingSkill;
		SetModifiedAndInvalidateInfluencedCache(59, context);
	}

	public byte GetAttackSkillAttackIndex()
	{
		return _attackSkillAttackIndex;
	}

	public void SetAttackSkillAttackIndex(byte attackSkillAttackIndex, DataContext context)
	{
		_attackSkillAttackIndex = attackSkillAttackIndex;
		SetModifiedAndInvalidateInfluencedCache(60, context);
	}

	public byte GetAttackSkillPower()
	{
		return _attackSkillPower;
	}

	public void SetAttackSkillPower(byte attackSkillPower, DataContext context)
	{
		_attackSkillPower = attackSkillPower;
		SetModifiedAndInvalidateInfluencedCache(61, context);
	}

	public short GetAffectingMoveSkillId()
	{
		return _affectingMoveSkillId;
	}

	public void SetAffectingMoveSkillId(short affectingMoveSkillId, DataContext context)
	{
		_affectingMoveSkillId = affectingMoveSkillId;
		SetModifiedAndInvalidateInfluencedCache(62, context);
	}

	public short GetAffectingDefendSkillId()
	{
		return _affectingDefendSkillId;
	}

	public void SetAffectingDefendSkillId(short affectingDefendSkillId, DataContext context)
	{
		_affectingDefendSkillId = affectingDefendSkillId;
		SetModifiedAndInvalidateInfluencedCache(63, context);
	}

	public byte GetDefendSkillTimePercent()
	{
		return _defendSkillTimePercent;
	}

	public void SetDefendSkillTimePercent(byte defendSkillTimePercent, DataContext context)
	{
		_defendSkillTimePercent = defendSkillTimePercent;
		SetModifiedAndInvalidateInfluencedCache(64, context);
	}

	public short GetWugCount()
	{
		return _wugCount;
	}

	public void SetWugCount(short wugCount, DataContext context)
	{
		_wugCount = wugCount;
		SetModifiedAndInvalidateInfluencedCache(65, context);
	}

	public byte GetHealInjuryCount()
	{
		return _healInjuryCount;
	}

	public void SetHealInjuryCount(byte healInjuryCount, DataContext context)
	{
		_healInjuryCount = healInjuryCount;
		SetModifiedAndInvalidateInfluencedCache(66, context);
	}

	public byte GetHealPoisonCount()
	{
		return _healPoisonCount;
	}

	public void SetHealPoisonCount(byte healPoisonCount, DataContext context)
	{
		_healPoisonCount = healPoisonCount;
		SetModifiedAndInvalidateInfluencedCache(67, context);
	}

	public bool[] GetOtherActionCanUse()
	{
		return _otherActionCanUse;
	}

	public void SetOtherActionCanUse(bool[] otherActionCanUse, DataContext context)
	{
		_otherActionCanUse = otherActionCanUse;
		SetModifiedAndInvalidateInfluencedCache(68, context);
	}

	public sbyte GetPreparingOtherAction()
	{
		return _preparingOtherAction;
	}

	public void SetPreparingOtherAction(sbyte preparingOtherAction, DataContext context)
	{
		_preparingOtherAction = preparingOtherAction;
		SetModifiedAndInvalidateInfluencedCache(69, context);
	}

	public byte GetOtherActionPreparePercent()
	{
		return _otherActionPreparePercent;
	}

	public void SetOtherActionPreparePercent(byte otherActionPreparePercent, DataContext context)
	{
		_otherActionPreparePercent = otherActionPreparePercent;
		SetModifiedAndInvalidateInfluencedCache(70, context);
	}

	public bool GetCanSurrender()
	{
		return _canSurrender;
	}

	public void SetCanSurrender(bool canSurrender, DataContext context)
	{
		_canSurrender = canSurrender;
		SetModifiedAndInvalidateInfluencedCache(71, context);
	}

	public bool GetCanUseItem()
	{
		return _canUseItem;
	}

	public void SetCanUseItem(bool canUseItem, DataContext context)
	{
		_canUseItem = canUseItem;
		SetModifiedAndInvalidateInfluencedCache(72, context);
	}

	public ItemKey GetPreparingItem()
	{
		return _preparingItem;
	}

	public void SetPreparingItem(ItemKey preparingItem, DataContext context)
	{
		_preparingItem = preparingItem;
		SetModifiedAndInvalidateInfluencedCache(73, context);
	}

	public byte GetUseItemPreparePercent()
	{
		return _useItemPreparePercent;
	}

	public void SetUseItemPreparePercent(byte useItemPreparePercent, DataContext context)
	{
		_useItemPreparePercent = useItemPreparePercent;
		SetModifiedAndInvalidateInfluencedCache(74, context);
	}

	public CombatReserveData GetCombatReserveData()
	{
		return _combatReserveData;
	}

	public void SetCombatReserveData(CombatReserveData combatReserveData, DataContext context)
	{
		_combatReserveData = combatReserveData;
		SetModifiedAndInvalidateInfluencedCache(75, context);
	}

	public CombatStateCollection GetBuffCombatStateCollection()
	{
		return _buffCombatStateCollection;
	}

	public void SetBuffCombatStateCollection(CombatStateCollection buffCombatStateCollection, DataContext context)
	{
		_buffCombatStateCollection = buffCombatStateCollection;
		SetModifiedAndInvalidateInfluencedCache(76, context);
	}

	public CombatStateCollection GetDebuffCombatStateCollection()
	{
		return _debuffCombatStateCollection;
	}

	public void SetDebuffCombatStateCollection(CombatStateCollection debuffCombatStateCollection, DataContext context)
	{
		_debuffCombatStateCollection = debuffCombatStateCollection;
		SetModifiedAndInvalidateInfluencedCache(77, context);
	}

	public CombatStateCollection GetSpecialCombatStateCollection()
	{
		return _specialCombatStateCollection;
	}

	public void SetSpecialCombatStateCollection(CombatStateCollection specialCombatStateCollection, DataContext context)
	{
		_specialCombatStateCollection = specialCombatStateCollection;
		SetModifiedAndInvalidateInfluencedCache(78, context);
	}

	public SkillEffectCollection GetSkillEffectCollection()
	{
		return _skillEffectCollection;
	}

	public void SetSkillEffectCollection(SkillEffectCollection skillEffectCollection, DataContext context)
	{
		_skillEffectCollection = skillEffectCollection;
		SetModifiedAndInvalidateInfluencedCache(79, context);
	}

	public short GetXiangshuEffectId()
	{
		return _xiangshuEffectId;
	}

	public void SetXiangshuEffectId(short xiangshuEffectId, DataContext context)
	{
		_xiangshuEffectId = xiangshuEffectId;
		SetModifiedAndInvalidateInfluencedCache(80, context);
	}

	public int GetHazardValue()
	{
		return _hazardValue;
	}

	public void SetHazardValue(int hazardValue, DataContext context)
	{
		_hazardValue = hazardValue;
		SetModifiedAndInvalidateInfluencedCache(81, context);
	}

	public ShowSpecialEffectCollection GetShowEffectList()
	{
		return _showEffectList;
	}

	public void SetShowEffectList(ShowSpecialEffectCollection showEffectList, DataContext context)
	{
		_showEffectList = showEffectList;
		SetModifiedAndInvalidateInfluencedCache(82, context);
	}

	public string GetAnimationToLoop()
	{
		return _animationToLoop;
	}

	public void SetAnimationToLoop(string animationToLoop, DataContext context)
	{
		_animationToLoop = animationToLoop;
		SetModifiedAndInvalidateInfluencedCache(83, context);
	}

	public string GetAnimationToPlayOnce()
	{
		return _animationToPlayOnce;
	}

	public void SetAnimationToPlayOnce(string animationToPlayOnce, DataContext context)
	{
		_animationToPlayOnce = animationToPlayOnce;
		SetModifiedAndInvalidateInfluencedCache(84, context);
	}

	public string GetParticleToPlay()
	{
		return _particleToPlay;
	}

	public void SetParticleToPlay(string particleToPlay, DataContext context)
	{
		_particleToPlay = particleToPlay;
		SetModifiedAndInvalidateInfluencedCache(85, context);
	}

	public string GetParticleToLoop()
	{
		return _particleToLoop;
	}

	public void SetParticleToLoop(string particleToLoop, DataContext context)
	{
		_particleToLoop = particleToLoop;
		SetModifiedAndInvalidateInfluencedCache(86, context);
	}

	public string GetSkillPetAnimation()
	{
		return _skillPetAnimation;
	}

	public void SetSkillPetAnimation(string skillPetAnimation, DataContext context)
	{
		_skillPetAnimation = skillPetAnimation;
		SetModifiedAndInvalidateInfluencedCache(87, context);
	}

	public string GetPetParticle()
	{
		return _petParticle;
	}

	public void SetPetParticle(string petParticle, DataContext context)
	{
		_petParticle = petParticle;
		SetModifiedAndInvalidateInfluencedCache(88, context);
	}

	public float GetAnimationTimeScale()
	{
		return _animationTimeScale;
	}

	public void SetAnimationTimeScale(float animationTimeScale, DataContext context)
	{
		_animationTimeScale = animationTimeScale;
		SetModifiedAndInvalidateInfluencedCache(89, context);
	}

	public bool GetAttackOutOfRange()
	{
		return _attackOutOfRange;
	}

	public void SetAttackOutOfRange(bool attackOutOfRange, DataContext context)
	{
		_attackOutOfRange = attackOutOfRange;
		SetModifiedAndInvalidateInfluencedCache(90, context);
	}

	public string GetAttackSoundToPlay()
	{
		return _attackSoundToPlay;
	}

	public void SetAttackSoundToPlay(string attackSoundToPlay, DataContext context)
	{
		_attackSoundToPlay = attackSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(91, context);
	}

	public string GetSkillSoundToPlay()
	{
		return _skillSoundToPlay;
	}

	public void SetSkillSoundToPlay(string skillSoundToPlay, DataContext context)
	{
		_skillSoundToPlay = skillSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(92, context);
	}

	public string GetHitSoundToPlay()
	{
		return _hitSoundToPlay;
	}

	public void SetHitSoundToPlay(string hitSoundToPlay, DataContext context)
	{
		_hitSoundToPlay = hitSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(93, context);
	}

	public string GetArmorHitSoundToPlay()
	{
		return _armorHitSoundToPlay;
	}

	public void SetArmorHitSoundToPlay(string armorHitSoundToPlay, DataContext context)
	{
		_armorHitSoundToPlay = armorHitSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(94, context);
	}

	public string GetWhooshSoundToPlay()
	{
		return _whooshSoundToPlay;
	}

	public void SetWhooshSoundToPlay(string whooshSoundToPlay, DataContext context)
	{
		_whooshSoundToPlay = whooshSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(95, context);
	}

	public string GetShockSoundToPlay()
	{
		return _shockSoundToPlay;
	}

	public void SetShockSoundToPlay(string shockSoundToPlay, DataContext context)
	{
		_shockSoundToPlay = shockSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(96, context);
	}

	public string GetStepSoundToPlay()
	{
		return _stepSoundToPlay;
	}

	public void SetStepSoundToPlay(string stepSoundToPlay, DataContext context)
	{
		_stepSoundToPlay = stepSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(97, context);
	}

	public string GetDieSoundToPlay()
	{
		return _dieSoundToPlay;
	}

	public void SetDieSoundToPlay(string dieSoundToPlay, DataContext context)
	{
		_dieSoundToPlay = dieSoundToPlay;
		SetModifiedAndInvalidateInfluencedCache(98, context);
	}

	public string GetSoundToLoop()
	{
		return _soundToLoop;
	}

	public void SetSoundToLoop(string soundToLoop, DataContext context)
	{
		_soundToLoop = soundToLoop;
		SetModifiedAndInvalidateInfluencedCache(99, context);
	}

	public sbyte GetBossPhase()
	{
		return _bossPhase;
	}

	public void SetBossPhase(sbyte bossPhase, DataContext context)
	{
		_bossPhase = bossPhase;
		SetModifiedAndInvalidateInfluencedCache(100, context);
	}

	public bool GetShowTransferInjuryCommand()
	{
		return _showTransferInjuryCommand;
	}

	public void SetShowTransferInjuryCommand(bool showTransferInjuryCommand, DataContext context)
	{
		_showTransferInjuryCommand = showTransferInjuryCommand;
		SetModifiedAndInvalidateInfluencedCache(101, context);
	}

	public List<sbyte> GetCurrTeammateCommands()
	{
		return _currTeammateCommands;
	}

	public void SetCurrTeammateCommands(List<sbyte> currTeammateCommands, DataContext context)
	{
		_currTeammateCommands = currTeammateCommands;
		SetModifiedAndInvalidateInfluencedCache(102, context);
	}

	public sbyte GetExecutingTeammateCommand()
	{
		return _executingTeammateCommand;
	}

	public void SetExecutingTeammateCommand(sbyte executingTeammateCommand, DataContext context)
	{
		_executingTeammateCommand = executingTeammateCommand;
		SetModifiedAndInvalidateInfluencedCache(103, context);
	}

	public bool GetVisible()
	{
		return _visible;
	}

	public void SetVisible(bool visible, DataContext context)
	{
		_visible = visible;
		SetModifiedAndInvalidateInfluencedCache(104, context);
	}

	public byte GetTeammateCommandPreparePercent()
	{
		return _teammateCommandPreparePercent;
	}

	public void SetTeammateCommandPreparePercent(byte teammateCommandPreparePercent, DataContext context)
	{
		_teammateCommandPreparePercent = teammateCommandPreparePercent;
		SetModifiedAndInvalidateInfluencedCache(105, context);
	}

	public byte GetTeammateCommandTimePercent()
	{
		return _teammateCommandTimePercent;
	}

	public void SetTeammateCommandTimePercent(byte teammateCommandTimePercent, DataContext context)
	{
		_teammateCommandTimePercent = teammateCommandTimePercent;
		SetModifiedAndInvalidateInfluencedCache(106, context);
	}

	public ItemKey GetAttackCommandWeaponKey()
	{
		return _attackCommandWeaponKey;
	}

	public void SetAttackCommandWeaponKey(ItemKey attackCommandWeaponKey, DataContext context)
	{
		_attackCommandWeaponKey = attackCommandWeaponKey;
		SetModifiedAndInvalidateInfluencedCache(107, context);
	}

	public sbyte GetAttackCommandTrickType()
	{
		return _attackCommandTrickType;
	}

	public void SetAttackCommandTrickType(sbyte attackCommandTrickType, DataContext context)
	{
		_attackCommandTrickType = attackCommandTrickType;
		SetModifiedAndInvalidateInfluencedCache(108, context);
	}

	public short GetDefendCommandSkillId()
	{
		return _defendCommandSkillId;
	}

	public void SetDefendCommandSkillId(short defendCommandSkillId, DataContext context)
	{
		_defendCommandSkillId = defendCommandSkillId;
		SetModifiedAndInvalidateInfluencedCache(109, context);
	}

	public sbyte GetShowEffectCommandIndex()
	{
		return _showEffectCommandIndex;
	}

	public void SetShowEffectCommandIndex(sbyte showEffectCommandIndex, DataContext context)
	{
		_showEffectCommandIndex = showEffectCommandIndex;
		SetModifiedAndInvalidateInfluencedCache(110, context);
	}

	public short GetAttackCommandSkillId()
	{
		return _attackCommandSkillId;
	}

	public void SetAttackCommandSkillId(short attackCommandSkillId, DataContext context)
	{
		_attackCommandSkillId = attackCommandSkillId;
		SetModifiedAndInvalidateInfluencedCache(111, context);
	}

	public List<SByteList> GetTeammateCommandBanReasons()
	{
		return _teammateCommandBanReasons;
	}

	public void SetTeammateCommandBanReasons(List<SByteList> teammateCommandBanReasons, DataContext context)
	{
		_teammateCommandBanReasons = teammateCommandBanReasons;
		SetModifiedAndInvalidateInfluencedCache(112, context);
	}

	public short GetTargetDistance()
	{
		return _targetDistance;
	}

	public void SetTargetDistance(short targetDistance, DataContext context)
	{
		_targetDistance = targetDistance;
		SetModifiedAndInvalidateInfluencedCache(113, context);
	}

	public InjuryAutoHealCollection GetOldInjuryAutoHealCollection()
	{
		return _oldInjuryAutoHealCollection;
	}

	public void SetOldInjuryAutoHealCollection(InjuryAutoHealCollection oldInjuryAutoHealCollection, DataContext context)
	{
		_oldInjuryAutoHealCollection = oldInjuryAutoHealCollection;
		SetModifiedAndInvalidateInfluencedCache(114, context);
	}

	public MixPoisonAffectedCountCollection GetMixPoisonAffectedCount()
	{
		return _mixPoisonAffectedCount;
	}

	public void SetMixPoisonAffectedCount(MixPoisonAffectedCountCollection mixPoisonAffectedCount, DataContext context)
	{
		_mixPoisonAffectedCount = mixPoisonAffectedCount;
		SetModifiedAndInvalidateInfluencedCache(115, context);
	}

	public string GetParticleToLoopByCombatSkill()
	{
		return _particleToLoopByCombatSkill;
	}

	public void SetParticleToLoopByCombatSkill(string particleToLoopByCombatSkill, DataContext context)
	{
		_particleToLoopByCombatSkill = particleToLoopByCombatSkill;
		SetModifiedAndInvalidateInfluencedCache(116, context);
	}

	public CountdownData GetNeiliAllocationCd()
	{
		return _neiliAllocationCd;
	}

	public void SetNeiliAllocationCd(CountdownData neiliAllocationCd, DataContext context)
	{
		_neiliAllocationCd = neiliAllocationCd;
		SetModifiedAndInvalidateInfluencedCache(117, context);
	}

	public NeiliProportionOfFiveElements GetProportionDelta()
	{
		return _proportionDelta;
	}

	public void SetProportionDelta(NeiliProportionOfFiveElements proportionDelta, DataContext context)
	{
		_proportionDelta = proportionDelta;
		SetModifiedAndInvalidateInfluencedCache(118, context);
	}

	public List<TeammateCommandDisplayData> GetShowCommandList()
	{
		return _showCommandList;
	}

	public void SetShowCommandList(List<TeammateCommandDisplayData> showCommandList, DataContext context)
	{
		_showCommandList = showCommandList;
		SetModifiedAndInvalidateInfluencedCache(119, context);
	}

	public List<int> GetUnlockPrepareValue()
	{
		return _unlockPrepareValue;
	}

	public void SetUnlockPrepareValue(List<int> unlockPrepareValue, DataContext context)
	{
		_unlockPrepareValue = unlockPrepareValue;
		SetModifiedAndInvalidateInfluencedCache(120, context);
	}

	public List<int> GetRawCreateEffects()
	{
		return _rawCreateEffects;
	}

	public void SetRawCreateEffects(List<int> rawCreateEffects, DataContext context)
	{
		_rawCreateEffects = rawCreateEffects;
		SetModifiedAndInvalidateInfluencedCache(121, context);
	}

	public RawCreateCollection GetRawCreateCollection()
	{
		return _rawCreateCollection;
	}

	public void SetRawCreateCollection(RawCreateCollection rawCreateCollection, DataContext context)
	{
		_rawCreateCollection = rawCreateCollection;
		SetModifiedAndInvalidateInfluencedCache(122, context);
	}

	public CountdownData GetNormalAttackRecovery()
	{
		return _normalAttackRecovery;
	}

	public void SetNormalAttackRecovery(CountdownData normalAttackRecovery, DataContext context)
	{
		_normalAttackRecovery = normalAttackRecovery;
		SetModifiedAndInvalidateInfluencedCache(123, context);
	}

	public bool GetReserveNormalAttack()
	{
		return _reserveNormalAttack;
	}

	public void SetReserveNormalAttack(bool reserveNormalAttack, DataContext context)
	{
		_reserveNormalAttack = reserveNormalAttack;
		SetModifiedAndInvalidateInfluencedCache(124, context);
	}

	public int GetGangqi()
	{
		return _gangqi;
	}

	public void SetGangqi(int gangqi, DataContext context)
	{
		_gangqi = gangqi;
		SetModifiedAndInvalidateInfluencedCache(125, context);
	}

	public int GetGangqiMax()
	{
		return _gangqiMax;
	}

	public void SetGangqiMax(int gangqiMax, DataContext context)
	{
		_gangqiMax = gangqiMax;
		SetModifiedAndInvalidateInfluencedCache(126, context);
	}

	public MoveState GetMoveState()
	{
		return _moveState;
	}

	public void SetMoveState(MoveState moveState, DataContext context)
	{
		_moveState = moveState;
		SetModifiedAndInvalidateInfluencedCache(127, context);
	}

	public bool GetPlayerControllingMove()
	{
		return _playerControllingMove;
	}

	public void SetPlayerControllingMove(bool playerControllingMove, DataContext context)
	{
		_playerControllingMove = playerControllingMove;
		SetModifiedAndInvalidateInfluencedCache(128, context);
	}

	public List<CountdownData> GetScarMarkTime()
	{
		return _scarMarkTime;
	}

	public void SetScarMarkTime(List<CountdownData> scarMarkTime, DataContext context)
	{
		_scarMarkTime = scarMarkTime;
		SetModifiedAndInvalidateInfluencedCache(129, context);
	}

	public CountdownData GetMindRhythm()
	{
		return _mindRhythm;
	}

	public void SetMindRhythm(CountdownData mindRhythm, DataContext context)
	{
		_mindRhythm = mindRhythm;
		SetModifiedAndInvalidateInfluencedCache(130, context);
	}

	public CountdownData GetMindUpheavalTime()
	{
		return _mindUpheavalTime;
	}

	public void SetMindUpheavalTime(CountdownData mindUpheavalTime, DataContext context)
	{
		_mindUpheavalTime = mindUpheavalTime;
		SetModifiedAndInvalidateInfluencedCache(131, context);
	}

	public List<CountdownData> GetTeammateCommandCd()
	{
		return _teammateCommandCd;
	}

	public void SetTeammateCommandCd(List<CountdownData> teammateCommandCd, DataContext context)
	{
		_teammateCommandCd = teammateCommandCd;
		SetModifiedAndInvalidateInfluencedCache(132, context);
	}

	public List<int> GetTeammateCommandCdSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 133))
		{
			return _teammateCommandCdSpeed;
		}
		CalcTeammateCommandCdSpeed(_teammateCommandCdSpeed);
		dataStates.SetCached(DataStatesOffset, 133);
		return _teammateCommandCdSpeed;
	}

	public int GetMaxTrickCount()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 134))
		{
			return _maxTrickCount;
		}
		_maxTrickCount = CalcMaxTrickCount();
		dataStates.SetCached(DataStatesOffset, 134);
		return _maxTrickCount;
	}

	public byte GetMobilityLevel()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 135))
		{
			return _mobilityLevel;
		}
		_mobilityLevel = CalcMobilityLevel();
		dataStates.SetCached(DataStatesOffset, 135);
		return _mobilityLevel;
	}

	public List<bool> GetTeammateCommandCanUse()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 136))
		{
			return _teammateCommandCanUse;
		}
		CalcTeammateCommandCanUse(_teammateCommandCanUse);
		dataStates.SetCached(DataStatesOffset, 136);
		return _teammateCommandCanUse;
	}

	public float GetChangeDistanceDuration()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 137))
		{
			return _changeDistanceDuration;
		}
		_changeDistanceDuration = CalcChangeDistanceDuration();
		dataStates.SetCached(DataStatesOffset, 137);
		return _changeDistanceDuration;
	}

	public OuterAndInnerShorts GetAttackRange()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 138))
		{
			return _attackRange;
		}
		_attackRange = CalcAttackRange();
		dataStates.SetCached(DataStatesOffset, 138);
		return _attackRange;
	}

	public sbyte GetHappiness()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 139))
		{
			return _happiness;
		}
		_happiness = CalcHappiness();
		dataStates.SetCached(DataStatesOffset, 139);
		return _happiness;
	}

	public SilenceData GetSilenceData()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 140))
		{
			return _silenceData;
		}
		CalcSilenceData(_silenceData);
		dataStates.SetCached(DataStatesOffset, 140);
		return _silenceData;
	}

	public int GetCombatStateTotalBuffPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 141))
		{
			return _combatStateTotalBuffPower;
		}
		_combatStateTotalBuffPower = CalcCombatStateTotalBuffPower();
		dataStates.SetCached(DataStatesOffset, 141);
		return _combatStateTotalBuffPower;
	}

	public HeavyOrBreakInjuryData GetHeavyOrBreakInjuryData()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 142))
		{
			return _heavyOrBreakInjuryData;
		}
		_heavyOrBreakInjuryData = CalcHeavyOrBreakInjuryData();
		dataStates.SetCached(DataStatesOffset, 142);
		return _heavyOrBreakInjuryData;
	}

	public short GetMoveCd()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 143))
		{
			return _moveCd;
		}
		_moveCd = CalcMoveCd();
		dataStates.SetCached(DataStatesOffset, 143);
		return _moveCd;
	}

	public int GetMobilityRecoverSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 144))
		{
			return _mobilityRecoverSpeed;
		}
		_mobilityRecoverSpeed = CalcMobilityRecoverSpeed();
		dataStates.SetCached(DataStatesOffset, 144);
		return _mobilityRecoverSpeed;
	}

	public List<bool> GetCanUnlockAttack()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 145))
		{
			return _canUnlockAttack;
		}
		CalcCanUnlockAttack(_canUnlockAttack);
		dataStates.SetCached(DataStatesOffset, 145);
		return _canUnlockAttack;
	}

	public List<ItemKey> GetValidItems()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 146))
		{
			return _validItems;
		}
		CalcValidItems(_validItems);
		dataStates.SetCached(DataStatesOffset, 146);
		return _validItems;
	}

	public List<ItemKeyAndCount> GetValidItemAndCounts()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 147))
		{
			return _validItemAndCounts;
		}
		CalcValidItemAndCounts(_validItemAndCounts);
		dataStates.SetCached(DataStatesOffset, 147);
		return _validItemAndCounts;
	}

	public bool GetUseItemCostNoWisdom()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 148))
		{
			return _useItemCostNoWisdom;
		}
		_useItemCostNoWisdom = CalcUseItemCostNoWisdom();
		dataStates.SetCached(DataStatesOffset, 148);
		return _useItemCostNoWisdom;
	}

	public int GetTeammateCommandBaseCdSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 149))
		{
			return _teammateCommandBaseCdSpeed;
		}
		_teammateCommandBaseCdSpeed = CalcTeammateCommandBaseCdSpeed();
		dataStates.SetCached(DataStatesOffset, 149);
		return _teammateCommandBaseCdSpeed;
	}

	public EOtherActionInterruptType GetPreparingOtherActionInterruptType()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 150))
		{
			return _preparingOtherActionInterruptType;
		}
		_preparingOtherActionInterruptType = CalcPreparingOtherActionInterruptType();
		dataStates.SetCached(DataStatesOffset, 150);
		return _preparingOtherActionInterruptType;
	}

	public MixPoisonAffectedCountCollection GetMixPoisonCanAffectCount()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		if (dataStates.IsCached(DataStatesOffset, 151))
		{
			return _mixPoisonCanAffectCount;
		}
		CalcMixPoisonCanAffectCount(_mixPoisonCanAffectCount);
		dataStates.SetCached(DataStatesOffset, 151);
		return _mixPoisonCanAffectCount;
	}

	public CombatCharacter()
	{
		_weaponTricks = new sbyte[6];
		_weapons = new ItemKey[7];
		_tricks = new TrickCollection();
		_injuryAutoHealCollection = new InjuryAutoHealCollection();
		_damageStepCollection = new DamageStepCollection();
		_outerDamageValue = new int[7];
		_innerDamageValue = new int[7];
		_outerDamageValueToShow = new IntPair[7];
		_innerDamageValueToShow = new IntPair[7];
		_flawCount = new byte[7];
		_flawCollection = new FlawOrAcupointCollection();
		_acupointCount = new byte[7];
		_acupointCollection = new FlawOrAcupointCollection();
		_mindMarkTime = new MindMarkList();
		_defeatMarkCollection = new DefeatMarkCollection();
		_neigongList = new List<short>();
		_attackSkillList = new List<short>();
		_agileSkillList = new List<short>();
		_defenceSkillList = new List<short>();
		_assistSkillList = new List<short>();
		_otherActionCanUse = new bool[5];
		_combatReserveData = new CombatReserveData();
		_buffCombatStateCollection = new CombatStateCollection();
		_debuffCombatStateCollection = new CombatStateCollection();
		_specialCombatStateCollection = new CombatStateCollection();
		_skillEffectCollection = new SkillEffectCollection();
		_showEffectList = new ShowSpecialEffectCollection();
		_animationToLoop = string.Empty;
		_animationToPlayOnce = string.Empty;
		_particleToPlay = string.Empty;
		_particleToLoop = string.Empty;
		_skillPetAnimation = string.Empty;
		_petParticle = string.Empty;
		_attackSoundToPlay = string.Empty;
		_skillSoundToPlay = string.Empty;
		_hitSoundToPlay = string.Empty;
		_armorHitSoundToPlay = string.Empty;
		_whooshSoundToPlay = string.Empty;
		_shockSoundToPlay = string.Empty;
		_stepSoundToPlay = string.Empty;
		_dieSoundToPlay = string.Empty;
		_soundToLoop = string.Empty;
		_currTeammateCommands = new List<sbyte>();
		_teammateCommandBanReasons = new List<SByteList>();
		_oldInjuryAutoHealCollection = new InjuryAutoHealCollection();
		_mixPoisonAffectedCount = new MixPoisonAffectedCountCollection();
		_particleToLoopByCombatSkill = string.Empty;
		_showCommandList = new List<TeammateCommandDisplayData>();
		_unlockPrepareValue = new List<int>();
		_rawCreateEffects = new List<int>();
		_rawCreateCollection = new RawCreateCollection();
		_scarMarkTime = new List<CountdownData>();
		_teammateCommandCd = new List<CountdownData>();
		_teammateCommandCdSpeed = new List<int>();
		_teammateCommandCanUse = new List<bool>();
		_silenceData = new SilenceData();
		_canUnlockAttack = new List<bool>();
		_validItems = new List<ItemKey>();
		_validItemAndCounts = new List<ItemKeyAndCount>();
		_mixPoisonCanAffectCount = new MixPoisonAffectedCountCollection();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		int totalSize = 815;
		int dataSize = _tricks.GetSerializedSize();
		totalSize += dataSize;
		int dataSize2 = _injuryAutoHealCollection.GetSerializedSize();
		totalSize += dataSize2;
		int dataSize3 = _flawCollection.GetSerializedSize();
		totalSize += dataSize3;
		int dataSize4 = _acupointCollection.GetSerializedSize();
		totalSize += dataSize4;
		int dataSize5 = _mindMarkTime.GetSerializedSize();
		totalSize += dataSize5;
		int dataSize6 = _defeatMarkCollection.GetSerializedSize();
		totalSize += dataSize6;
		int elementsCount = _neigongList.Count;
		int contentSize = 2 * elementsCount;
		int dataSize7 = 2 + contentSize;
		totalSize += dataSize7;
		int elementsCount2 = _attackSkillList.Count;
		int contentSize2 = 2 * elementsCount2;
		int dataSize8 = 2 + contentSize2;
		totalSize += dataSize8;
		int elementsCount3 = _agileSkillList.Count;
		int contentSize3 = 2 * elementsCount3;
		int dataSize9 = 2 + contentSize3;
		totalSize += dataSize9;
		int elementsCount4 = _defenceSkillList.Count;
		int contentSize4 = 2 * elementsCount4;
		int dataSize10 = 2 + contentSize4;
		totalSize += dataSize10;
		int elementsCount5 = _assistSkillList.Count;
		int contentSize5 = 2 * elementsCount5;
		int dataSize11 = 2 + contentSize5;
		totalSize += dataSize11;
		int dataSize12 = _combatReserveData.GetSerializedSize();
		totalSize += dataSize12;
		int dataSize13 = _buffCombatStateCollection.GetSerializedSize();
		totalSize += dataSize13;
		int dataSize14 = _debuffCombatStateCollection.GetSerializedSize();
		totalSize += dataSize14;
		int dataSize15 = _specialCombatStateCollection.GetSerializedSize();
		totalSize += dataSize15;
		int dataSize16 = _skillEffectCollection.GetSerializedSize();
		totalSize += dataSize16;
		int dataSize17 = _showEffectList.GetSerializedSize();
		totalSize += dataSize17;
		int elementsCount6 = _animationToLoop.Length;
		int contentSize6 = 2 * elementsCount6;
		int dataSize18 = 4 + contentSize6;
		totalSize += dataSize18;
		int elementsCount7 = _animationToPlayOnce.Length;
		int contentSize7 = 2 * elementsCount7;
		int dataSize19 = 4 + contentSize7;
		totalSize += dataSize19;
		int elementsCount8 = _particleToPlay.Length;
		int contentSize8 = 2 * elementsCount8;
		int dataSize20 = 4 + contentSize8;
		totalSize += dataSize20;
		int elementsCount9 = _particleToLoop.Length;
		int contentSize9 = 2 * elementsCount9;
		int dataSize21 = 4 + contentSize9;
		totalSize += dataSize21;
		int elementsCount10 = _skillPetAnimation.Length;
		int contentSize10 = 2 * elementsCount10;
		int dataSize22 = 4 + contentSize10;
		totalSize += dataSize22;
		int elementsCount11 = _petParticle.Length;
		int contentSize11 = 2 * elementsCount11;
		int dataSize23 = 4 + contentSize11;
		totalSize += dataSize23;
		int elementsCount12 = _attackSoundToPlay.Length;
		int contentSize12 = 2 * elementsCount12;
		int dataSize24 = 4 + contentSize12;
		totalSize += dataSize24;
		int elementsCount13 = _skillSoundToPlay.Length;
		int contentSize13 = 2 * elementsCount13;
		int dataSize25 = 4 + contentSize13;
		totalSize += dataSize25;
		int elementsCount14 = _hitSoundToPlay.Length;
		int contentSize14 = 2 * elementsCount14;
		int dataSize26 = 4 + contentSize14;
		totalSize += dataSize26;
		int elementsCount15 = _armorHitSoundToPlay.Length;
		int contentSize15 = 2 * elementsCount15;
		int dataSize27 = 4 + contentSize15;
		totalSize += dataSize27;
		int elementsCount16 = _whooshSoundToPlay.Length;
		int contentSize16 = 2 * elementsCount16;
		int dataSize28 = 4 + contentSize16;
		totalSize += dataSize28;
		int elementsCount17 = _shockSoundToPlay.Length;
		int contentSize17 = 2 * elementsCount17;
		int dataSize29 = 4 + contentSize17;
		totalSize += dataSize29;
		int elementsCount18 = _stepSoundToPlay.Length;
		int contentSize18 = 2 * elementsCount18;
		int dataSize30 = 4 + contentSize18;
		totalSize += dataSize30;
		int elementsCount19 = _dieSoundToPlay.Length;
		int contentSize19 = 2 * elementsCount19;
		int dataSize31 = 4 + contentSize19;
		totalSize += dataSize31;
		int elementsCount20 = _soundToLoop.Length;
		int contentSize20 = 2 * elementsCount20;
		int dataSize32 = 4 + contentSize20;
		totalSize += dataSize32;
		int elementsCount21 = _currTeammateCommands.Count;
		int contentSize21 = elementsCount21;
		int dataSize33 = 2 + contentSize21;
		totalSize += dataSize33;
		int dataSize34 = 2;
		int elementsCount22 = _teammateCommandBanReasons.Count;
		for (int i = 0; i < elementsCount22; i++)
		{
			dataSize34 += _teammateCommandBanReasons[i].GetSerializedSize();
		}
		totalSize += dataSize34;
		int dataSize35 = _oldInjuryAutoHealCollection.GetSerializedSize();
		totalSize += dataSize35;
		int dataSize36 = _mixPoisonAffectedCount.GetSerializedSize();
		totalSize += dataSize36;
		int elementsCount23 = _particleToLoopByCombatSkill.Length;
		int contentSize22 = 2 * elementsCount23;
		int dataSize37 = 4 + contentSize22;
		totalSize += dataSize37;
		int elementsCount24 = _showCommandList.Count;
		int contentSize23 = 8 * elementsCount24;
		int dataSize38 = 2 + contentSize23;
		totalSize += dataSize38;
		int elementsCount25 = _unlockPrepareValue.Count;
		int contentSize24 = 4 * elementsCount25;
		int dataSize39 = 2 + contentSize24;
		totalSize += dataSize39;
		int elementsCount26 = _rawCreateEffects.Count;
		int contentSize25 = 4 * elementsCount26;
		int dataSize40 = 2 + contentSize25;
		totalSize += dataSize40;
		int dataSize41 = _rawCreateCollection.GetSerializedSize();
		totalSize += dataSize41;
		int elementsCount27 = _scarMarkTime.Count;
		int contentSize26 = 8 * elementsCount27;
		int dataSize42 = 2 + contentSize26;
		totalSize += dataSize42;
		int elementsCount28 = _teammateCommandCd.Count;
		int contentSize27 = 8 * elementsCount28;
		int dataSize43 = 2 + contentSize27;
		return totalSize + dataSize43;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		*(int*)pCurrData = _breathValue;
		pCurrData += 4;
		*(int*)pCurrData = _stanceValue;
		pCurrData += 4;
		pCurrData += _neiliAllocation.Serialize(pCurrData);
		pCurrData += _originNeiliAllocation.Serialize(pCurrData);
		pCurrData += _neiliAllocationRecoverProgress.Serialize(pCurrData);
		*(short*)pCurrData = _oldDisorderOfQi;
		pCurrData += 2;
		*pCurrData = (byte)_neiliType;
		pCurrData++;
		pCurrData += _avoidToShow.Serialize(pCurrData);
		*(int*)pCurrData = _currentPosition;
		pCurrData += 4;
		*(int*)pCurrData = _displayPosition;
		pCurrData += 4;
		*(int*)pCurrData = _mobilityValue;
		pCurrData += 4;
		*pCurrData = (byte)_jumpPrepareProgress;
		pCurrData++;
		*(short*)pCurrData = _jumpPreparedDistance;
		pCurrData += 2;
		*(short*)pCurrData = _mobilityLockEffectCount;
		pCurrData += 2;
		*(float*)pCurrData = _jumpChangeDistanceDuration;
		pCurrData += 4;
		*(int*)pCurrData = _usingWeaponIndex;
		pCurrData += 4;
		if (_weaponTricks.Length != 6)
		{
			throw new Exception("Elements count of field _weaponTricks is not equal to declaration");
		}
		for (int i = 0; i < 6; i++)
		{
			pCurrData[i] = (byte)_weaponTricks[i];
		}
		pCurrData += 6;
		*pCurrData = _weaponTrickIndex;
		pCurrData++;
		if (_weapons.Length != 7)
		{
			throw new Exception("Elements count of field _weapons is not equal to declaration");
		}
		for (int j = 0; j < 7; j++)
		{
			pCurrData += _weapons[j].Serialize(pCurrData);
		}
		*pCurrData = (byte)_attackingTrickType;
		pCurrData++;
		*pCurrData = (_canAttackOutRange ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)_changeTrickProgress;
		pCurrData++;
		*(short*)pCurrData = _changeTrickCount;
		pCurrData += 2;
		*pCurrData = (_canChangeTrick ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_changingTrick ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_changeTrickAttack ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_isFightBack ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += _injuries.Serialize(pCurrData);
		pCurrData += _oldInjuries.Serialize(pCurrData);
		pCurrData += _damageStepCollection.Serialize(pCurrData);
		if (_outerDamageValue.Length != 7)
		{
			throw new Exception("Elements count of field _outerDamageValue is not equal to declaration");
		}
		for (int k = 0; k < 7; k++)
		{
			((int*)pCurrData)[k] = _outerDamageValue[k];
		}
		pCurrData += 28;
		if (_innerDamageValue.Length != 7)
		{
			throw new Exception("Elements count of field _innerDamageValue is not equal to declaration");
		}
		for (int l = 0; l < 7; l++)
		{
			((int*)pCurrData)[l] = _innerDamageValue[l];
		}
		pCurrData += 28;
		*(int*)pCurrData = _mindDamageValue;
		pCurrData += 4;
		*(int*)pCurrData = _fatalDamageValue;
		pCurrData += 4;
		if (_outerDamageValueToShow.Length != 7)
		{
			throw new Exception("Elements count of field _outerDamageValueToShow is not equal to declaration");
		}
		for (int m = 0; m < 7; m++)
		{
			pCurrData += _outerDamageValueToShow[m].Serialize(pCurrData);
		}
		if (_innerDamageValueToShow.Length != 7)
		{
			throw new Exception("Elements count of field _innerDamageValueToShow is not equal to declaration");
		}
		for (int n = 0; n < 7; n++)
		{
			pCurrData += _innerDamageValueToShow[n].Serialize(pCurrData);
		}
		*(int*)pCurrData = _mindDamageValueToShow;
		pCurrData += 4;
		*(int*)pCurrData = _fatalDamageValueToShow;
		pCurrData += 4;
		if (_flawCount.Length != 7)
		{
			throw new Exception("Elements count of field _flawCount is not equal to declaration");
		}
		for (int num = 0; num < 7; num++)
		{
			pCurrData[num] = _flawCount[num];
		}
		pCurrData += 7;
		if (_acupointCount.Length != 7)
		{
			throw new Exception("Elements count of field _acupointCount is not equal to declaration");
		}
		for (int num2 = 0; num2 < 7; num2++)
		{
			pCurrData[num2] = _acupointCount[num2];
		}
		pCurrData += 7;
		pCurrData += _poison.Serialize(pCurrData);
		pCurrData += _oldPoison.Serialize(pCurrData);
		pCurrData += _poisonResist.Serialize(pCurrData);
		pCurrData += _newPoisonsToShow.Serialize(pCurrData);
		*(short*)pCurrData = _preparingSkillId;
		pCurrData += 2;
		*pCurrData = _skillPreparePercent;
		pCurrData++;
		*(short*)pCurrData = _performingSkillId;
		pCurrData += 2;
		*pCurrData = (_autoCastingSkill ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = _attackSkillAttackIndex;
		pCurrData++;
		*pCurrData = _attackSkillPower;
		pCurrData++;
		*(short*)pCurrData = _affectingMoveSkillId;
		pCurrData += 2;
		*(short*)pCurrData = _affectingDefendSkillId;
		pCurrData += 2;
		*pCurrData = _defendSkillTimePercent;
		pCurrData++;
		*(short*)pCurrData = _wugCount;
		pCurrData += 2;
		*pCurrData = _healInjuryCount;
		pCurrData++;
		*pCurrData = _healPoisonCount;
		pCurrData++;
		if (_otherActionCanUse.Length != 5)
		{
			throw new Exception("Elements count of field _otherActionCanUse is not equal to declaration");
		}
		for (int num3 = 0; num3 < 5; num3++)
		{
			pCurrData[num3] = (_otherActionCanUse[num3] ? ((byte)1) : ((byte)0));
		}
		pCurrData += 5;
		*pCurrData = (byte)_preparingOtherAction;
		pCurrData++;
		*pCurrData = _otherActionPreparePercent;
		pCurrData++;
		*pCurrData = (_canSurrender ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_canUseItem ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += _preparingItem.Serialize(pCurrData);
		*pCurrData = _useItemPreparePercent;
		pCurrData++;
		*(short*)pCurrData = _xiangshuEffectId;
		pCurrData += 2;
		*(int*)pCurrData = _hazardValue;
		pCurrData += 4;
		*(float*)pCurrData = _animationTimeScale;
		pCurrData += 4;
		*pCurrData = (_attackOutOfRange ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)_bossPhase;
		pCurrData++;
		*pCurrData = (_showTransferInjuryCommand ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)_executingTeammateCommand;
		pCurrData++;
		*pCurrData = (_visible ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = _teammateCommandPreparePercent;
		pCurrData++;
		*pCurrData = _teammateCommandTimePercent;
		pCurrData++;
		pCurrData += _attackCommandWeaponKey.Serialize(pCurrData);
		*pCurrData = (byte)_attackCommandTrickType;
		pCurrData++;
		*(short*)pCurrData = _defendCommandSkillId;
		pCurrData += 2;
		*pCurrData = (byte)_showEffectCommandIndex;
		pCurrData++;
		*(short*)pCurrData = _attackCommandSkillId;
		pCurrData += 2;
		*(short*)pCurrData = _targetDistance;
		pCurrData += 2;
		pCurrData += _neiliAllocationCd.Serialize(pCurrData);
		pCurrData += _proportionDelta.Serialize(pCurrData);
		pCurrData += _normalAttackRecovery.Serialize(pCurrData);
		*pCurrData = (_reserveNormalAttack ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = _gangqi;
		pCurrData += 4;
		*(int*)pCurrData = _gangqiMax;
		pCurrData += 4;
		*pCurrData = (byte)_moveState;
		pCurrData++;
		*pCurrData = (_playerControllingMove ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += _mindRhythm.Serialize(pCurrData);
		pCurrData += _mindUpheavalTime.Serialize(pCurrData);
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _tricks.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_tricks"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		byte* pBegin2 = pCurrData;
		pCurrData += 4;
		pCurrData += _injuryAutoHealCollection.Serialize(pCurrData);
		int fieldSize2 = (int)(pCurrData - pBegin2 - 4);
		if (fieldSize2 > 4194304)
		{
			throw new Exception($"Size of field {"_injuryAutoHealCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin2 = fieldSize2;
		byte* pBegin3 = pCurrData;
		pCurrData += 4;
		pCurrData += _flawCollection.Serialize(pCurrData);
		int fieldSize3 = (int)(pCurrData - pBegin3 - 4);
		if (fieldSize3 > 4194304)
		{
			throw new Exception($"Size of field {"_flawCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin3 = fieldSize3;
		byte* pBegin4 = pCurrData;
		pCurrData += 4;
		pCurrData += _acupointCollection.Serialize(pCurrData);
		int fieldSize4 = (int)(pCurrData - pBegin4 - 4);
		if (fieldSize4 > 4194304)
		{
			throw new Exception($"Size of field {"_acupointCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin4 = fieldSize4;
		byte* pBegin5 = pCurrData;
		pCurrData += 4;
		pCurrData += _mindMarkTime.Serialize(pCurrData);
		int fieldSize5 = (int)(pCurrData - pBegin5 - 4);
		if (fieldSize5 > 4194304)
		{
			throw new Exception($"Size of field {"_mindMarkTime"} must be less than {4096}KB");
		}
		*(int*)pBegin5 = fieldSize5;
		byte* pBegin6 = pCurrData;
		pCurrData += 4;
		pCurrData += _defeatMarkCollection.Serialize(pCurrData);
		int fieldSize6 = (int)(pCurrData - pBegin6 - 4);
		if (fieldSize6 > 4194304)
		{
			throw new Exception($"Size of field {"_defeatMarkCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin6 = fieldSize6;
		int elementsCount = _neigongList.Count;
		int contentSize = 2 * elementsCount;
		if (contentSize > 4194300)
		{
			throw new Exception($"Size of field {"_neigongList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int num4 = 0; num4 < elementsCount; num4++)
		{
			((short*)pCurrData)[num4] = _neigongList[num4];
		}
		pCurrData += contentSize;
		int elementsCount2 = _attackSkillList.Count;
		int contentSize2 = 2 * elementsCount2;
		if (contentSize2 > 4194300)
		{
			throw new Exception($"Size of field {"_attackSkillList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize2 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount2;
		pCurrData += 2;
		for (int num5 = 0; num5 < elementsCount2; num5++)
		{
			((short*)pCurrData)[num5] = _attackSkillList[num5];
		}
		pCurrData += contentSize2;
		int elementsCount3 = _agileSkillList.Count;
		int contentSize3 = 2 * elementsCount3;
		if (contentSize3 > 4194300)
		{
			throw new Exception($"Size of field {"_agileSkillList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize3 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount3;
		pCurrData += 2;
		for (int num6 = 0; num6 < elementsCount3; num6++)
		{
			((short*)pCurrData)[num6] = _agileSkillList[num6];
		}
		pCurrData += contentSize3;
		int elementsCount4 = _defenceSkillList.Count;
		int contentSize4 = 2 * elementsCount4;
		if (contentSize4 > 4194300)
		{
			throw new Exception($"Size of field {"_defenceSkillList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize4 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount4;
		pCurrData += 2;
		for (int num7 = 0; num7 < elementsCount4; num7++)
		{
			((short*)pCurrData)[num7] = _defenceSkillList[num7];
		}
		pCurrData += contentSize4;
		int elementsCount5 = _assistSkillList.Count;
		int contentSize5 = 2 * elementsCount5;
		if (contentSize5 > 4194300)
		{
			throw new Exception($"Size of field {"_assistSkillList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize5 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount5;
		pCurrData += 2;
		for (int num8 = 0; num8 < elementsCount5; num8++)
		{
			((short*)pCurrData)[num8] = _assistSkillList[num8];
		}
		pCurrData += contentSize5;
		byte* pBegin7 = pCurrData;
		pCurrData += 4;
		pCurrData += _combatReserveData.Serialize(pCurrData);
		int fieldSize7 = (int)(pCurrData - pBegin7 - 4);
		if (fieldSize7 > 4194304)
		{
			throw new Exception($"Size of field {"_combatReserveData"} must be less than {4096}KB");
		}
		*(int*)pBegin7 = fieldSize7;
		byte* pBegin8 = pCurrData;
		pCurrData += 4;
		pCurrData += _buffCombatStateCollection.Serialize(pCurrData);
		int fieldSize8 = (int)(pCurrData - pBegin8 - 4);
		if (fieldSize8 > 4194304)
		{
			throw new Exception($"Size of field {"_buffCombatStateCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin8 = fieldSize8;
		byte* pBegin9 = pCurrData;
		pCurrData += 4;
		pCurrData += _debuffCombatStateCollection.Serialize(pCurrData);
		int fieldSize9 = (int)(pCurrData - pBegin9 - 4);
		if (fieldSize9 > 4194304)
		{
			throw new Exception($"Size of field {"_debuffCombatStateCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin9 = fieldSize9;
		byte* pBegin10 = pCurrData;
		pCurrData += 4;
		pCurrData += _specialCombatStateCollection.Serialize(pCurrData);
		int fieldSize10 = (int)(pCurrData - pBegin10 - 4);
		if (fieldSize10 > 4194304)
		{
			throw new Exception($"Size of field {"_specialCombatStateCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin10 = fieldSize10;
		byte* pBegin11 = pCurrData;
		pCurrData += 4;
		pCurrData += _skillEffectCollection.Serialize(pCurrData);
		int fieldSize11 = (int)(pCurrData - pBegin11 - 4);
		if (fieldSize11 > 4194304)
		{
			throw new Exception($"Size of field {"_skillEffectCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin11 = fieldSize11;
		byte* pBegin12 = pCurrData;
		pCurrData += 4;
		pCurrData += _showEffectList.Serialize(pCurrData);
		int fieldSize12 = (int)(pCurrData - pBegin12 - 4);
		if (fieldSize12 > 4194304)
		{
			throw new Exception($"Size of field {"_showEffectList"} must be less than {4096}KB");
		}
		*(int*)pBegin12 = fieldSize12;
		int elementsCount6 = _animationToLoop.Length;
		int contentSize6 = 2 * elementsCount6;
		if (contentSize6 > 4194300)
		{
			throw new Exception($"Size of field {"_animationToLoop"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize6 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize6;
		pCurrData += 4;
		fixed (char* pChar = _animationToLoop)
		{
			for (int num9 = 0; num9 < elementsCount6; num9++)
			{
				((short*)pCurrData)[num9] = (short)pChar[num9];
			}
		}
		pCurrData += contentSize6;
		int elementsCount7 = _animationToPlayOnce.Length;
		int contentSize7 = 2 * elementsCount7;
		if (contentSize7 > 4194300)
		{
			throw new Exception($"Size of field {"_animationToPlayOnce"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize7 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize7;
		pCurrData += 4;
		fixed (char* pChar2 = _animationToPlayOnce)
		{
			for (int num10 = 0; num10 < elementsCount7; num10++)
			{
				((short*)pCurrData)[num10] = (short)pChar2[num10];
			}
		}
		pCurrData += contentSize7;
		int elementsCount8 = _particleToPlay.Length;
		int contentSize8 = 2 * elementsCount8;
		if (contentSize8 > 4194300)
		{
			throw new Exception($"Size of field {"_particleToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize8 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize8;
		pCurrData += 4;
		fixed (char* pChar3 = _particleToPlay)
		{
			for (int num11 = 0; num11 < elementsCount8; num11++)
			{
				((short*)pCurrData)[num11] = (short)pChar3[num11];
			}
		}
		pCurrData += contentSize8;
		int elementsCount9 = _particleToLoop.Length;
		int contentSize9 = 2 * elementsCount9;
		if (contentSize9 > 4194300)
		{
			throw new Exception($"Size of field {"_particleToLoop"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize9 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize9;
		pCurrData += 4;
		fixed (char* pChar4 = _particleToLoop)
		{
			for (int num12 = 0; num12 < elementsCount9; num12++)
			{
				((short*)pCurrData)[num12] = (short)pChar4[num12];
			}
		}
		pCurrData += contentSize9;
		int elementsCount10 = _skillPetAnimation.Length;
		int contentSize10 = 2 * elementsCount10;
		if (contentSize10 > 4194300)
		{
			throw new Exception($"Size of field {"_skillPetAnimation"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize10 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize10;
		pCurrData += 4;
		fixed (char* pChar5 = _skillPetAnimation)
		{
			for (int num13 = 0; num13 < elementsCount10; num13++)
			{
				((short*)pCurrData)[num13] = (short)pChar5[num13];
			}
		}
		pCurrData += contentSize10;
		int elementsCount11 = _petParticle.Length;
		int contentSize11 = 2 * elementsCount11;
		if (contentSize11 > 4194300)
		{
			throw new Exception($"Size of field {"_petParticle"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize11 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize11;
		pCurrData += 4;
		fixed (char* pChar6 = _petParticle)
		{
			for (int num14 = 0; num14 < elementsCount11; num14++)
			{
				((short*)pCurrData)[num14] = (short)pChar6[num14];
			}
		}
		pCurrData += contentSize11;
		int elementsCount12 = _attackSoundToPlay.Length;
		int contentSize12 = 2 * elementsCount12;
		if (contentSize12 > 4194300)
		{
			throw new Exception($"Size of field {"_attackSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize12 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize12;
		pCurrData += 4;
		fixed (char* pChar7 = _attackSoundToPlay)
		{
			for (int num15 = 0; num15 < elementsCount12; num15++)
			{
				((short*)pCurrData)[num15] = (short)pChar7[num15];
			}
		}
		pCurrData += contentSize12;
		int elementsCount13 = _skillSoundToPlay.Length;
		int contentSize13 = 2 * elementsCount13;
		if (contentSize13 > 4194300)
		{
			throw new Exception($"Size of field {"_skillSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize13 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize13;
		pCurrData += 4;
		fixed (char* pChar8 = _skillSoundToPlay)
		{
			for (int num16 = 0; num16 < elementsCount13; num16++)
			{
				((short*)pCurrData)[num16] = (short)pChar8[num16];
			}
		}
		pCurrData += contentSize13;
		int elementsCount14 = _hitSoundToPlay.Length;
		int contentSize14 = 2 * elementsCount14;
		if (contentSize14 > 4194300)
		{
			throw new Exception($"Size of field {"_hitSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize14 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize14;
		pCurrData += 4;
		fixed (char* pChar9 = _hitSoundToPlay)
		{
			for (int num17 = 0; num17 < elementsCount14; num17++)
			{
				((short*)pCurrData)[num17] = (short)pChar9[num17];
			}
		}
		pCurrData += contentSize14;
		int elementsCount15 = _armorHitSoundToPlay.Length;
		int contentSize15 = 2 * elementsCount15;
		if (contentSize15 > 4194300)
		{
			throw new Exception($"Size of field {"_armorHitSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize15 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize15;
		pCurrData += 4;
		fixed (char* pChar10 = _armorHitSoundToPlay)
		{
			for (int num18 = 0; num18 < elementsCount15; num18++)
			{
				((short*)pCurrData)[num18] = (short)pChar10[num18];
			}
		}
		pCurrData += contentSize15;
		int elementsCount16 = _whooshSoundToPlay.Length;
		int contentSize16 = 2 * elementsCount16;
		if (contentSize16 > 4194300)
		{
			throw new Exception($"Size of field {"_whooshSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize16 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize16;
		pCurrData += 4;
		fixed (char* pChar11 = _whooshSoundToPlay)
		{
			for (int num19 = 0; num19 < elementsCount16; num19++)
			{
				((short*)pCurrData)[num19] = (short)pChar11[num19];
			}
		}
		pCurrData += contentSize16;
		int elementsCount17 = _shockSoundToPlay.Length;
		int contentSize17 = 2 * elementsCount17;
		if (contentSize17 > 4194300)
		{
			throw new Exception($"Size of field {"_shockSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize17 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize17;
		pCurrData += 4;
		fixed (char* pChar12 = _shockSoundToPlay)
		{
			for (int num20 = 0; num20 < elementsCount17; num20++)
			{
				((short*)pCurrData)[num20] = (short)pChar12[num20];
			}
		}
		pCurrData += contentSize17;
		int elementsCount18 = _stepSoundToPlay.Length;
		int contentSize18 = 2 * elementsCount18;
		if (contentSize18 > 4194300)
		{
			throw new Exception($"Size of field {"_stepSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize18 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize18;
		pCurrData += 4;
		fixed (char* pChar13 = _stepSoundToPlay)
		{
			for (int num21 = 0; num21 < elementsCount18; num21++)
			{
				((short*)pCurrData)[num21] = (short)pChar13[num21];
			}
		}
		pCurrData += contentSize18;
		int elementsCount19 = _dieSoundToPlay.Length;
		int contentSize19 = 2 * elementsCount19;
		if (contentSize19 > 4194300)
		{
			throw new Exception($"Size of field {"_dieSoundToPlay"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize19 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize19;
		pCurrData += 4;
		fixed (char* pChar14 = _dieSoundToPlay)
		{
			for (int num22 = 0; num22 < elementsCount19; num22++)
			{
				((short*)pCurrData)[num22] = (short)pChar14[num22];
			}
		}
		pCurrData += contentSize19;
		int elementsCount20 = _soundToLoop.Length;
		int contentSize20 = 2 * elementsCount20;
		if (contentSize20 > 4194300)
		{
			throw new Exception($"Size of field {"_soundToLoop"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize20 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize20;
		pCurrData += 4;
		fixed (char* pChar15 = _soundToLoop)
		{
			for (int num23 = 0; num23 < elementsCount20; num23++)
			{
				((short*)pCurrData)[num23] = (short)pChar15[num23];
			}
		}
		pCurrData += contentSize20;
		int elementsCount21 = _currTeammateCommands.Count;
		int contentSize21 = elementsCount21;
		if (contentSize21 > 4194300)
		{
			throw new Exception($"Size of field {"_currTeammateCommands"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize21 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount21;
		pCurrData += 2;
		for (int num24 = 0; num24 < elementsCount21; num24++)
		{
			pCurrData[num24] = (byte)_currTeammateCommands[num24];
		}
		pCurrData += contentSize21;
		int elementsCount22 = _teammateCommandBanReasons.Count;
		byte* pBegin13 = pCurrData;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount22;
		pCurrData += 2;
		for (int num25 = 0; num25 < elementsCount22; num25++)
		{
			pCurrData += _teammateCommandBanReasons[num25].Serialize(pCurrData);
		}
		int fieldSize13 = (int)(pCurrData - pBegin13 - 4);
		if (fieldSize13 > 4194304)
		{
			throw new Exception($"Size of field {"_teammateCommandBanReasons"} must be less than {4096}KB");
		}
		*(int*)pBegin13 = fieldSize13;
		byte* pBegin14 = pCurrData;
		pCurrData += 4;
		pCurrData += _oldInjuryAutoHealCollection.Serialize(pCurrData);
		int fieldSize14 = (int)(pCurrData - pBegin14 - 4);
		if (fieldSize14 > 4194304)
		{
			throw new Exception($"Size of field {"_oldInjuryAutoHealCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin14 = fieldSize14;
		byte* pBegin15 = pCurrData;
		pCurrData += 4;
		pCurrData += _mixPoisonAffectedCount.Serialize(pCurrData);
		int fieldSize15 = (int)(pCurrData - pBegin15 - 4);
		if (fieldSize15 > 4194304)
		{
			throw new Exception($"Size of field {"_mixPoisonAffectedCount"} must be less than {4096}KB");
		}
		*(int*)pBegin15 = fieldSize15;
		int elementsCount23 = _particleToLoopByCombatSkill.Length;
		int contentSize22 = 2 * elementsCount23;
		if (contentSize22 > 4194300)
		{
			throw new Exception($"Size of field {"_particleToLoopByCombatSkill"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize22 + 4;
		pCurrData += 4;
		*(int*)pCurrData = contentSize22;
		pCurrData += 4;
		fixed (char* pChar16 = _particleToLoopByCombatSkill)
		{
			for (int num26 = 0; num26 < elementsCount23; num26++)
			{
				((short*)pCurrData)[num26] = (short)pChar16[num26];
			}
		}
		pCurrData += contentSize22;
		int elementsCount24 = _showCommandList.Count;
		int contentSize23 = 8 * elementsCount24;
		if (contentSize23 > 4194300)
		{
			throw new Exception($"Size of field {"_showCommandList"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize23 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount24;
		pCurrData += 2;
		for (int num27 = 0; num27 < elementsCount24; num27++)
		{
			pCurrData += _showCommandList[num27].Serialize(pCurrData);
		}
		int elementsCount25 = _unlockPrepareValue.Count;
		int contentSize24 = 4 * elementsCount25;
		if (contentSize24 > 4194300)
		{
			throw new Exception($"Size of field {"_unlockPrepareValue"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize24 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount25;
		pCurrData += 2;
		for (int num28 = 0; num28 < elementsCount25; num28++)
		{
			((int*)pCurrData)[num28] = _unlockPrepareValue[num28];
		}
		pCurrData += contentSize24;
		int elementsCount26 = _rawCreateEffects.Count;
		int contentSize25 = 4 * elementsCount26;
		if (contentSize25 > 4194300)
		{
			throw new Exception($"Size of field {"_rawCreateEffects"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize25 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount26;
		pCurrData += 2;
		for (int num29 = 0; num29 < elementsCount26; num29++)
		{
			((int*)pCurrData)[num29] = _rawCreateEffects[num29];
		}
		pCurrData += contentSize25;
		byte* pBegin16 = pCurrData;
		pCurrData += 4;
		pCurrData += _rawCreateCollection.Serialize(pCurrData);
		int fieldSize16 = (int)(pCurrData - pBegin16 - 4);
		if (fieldSize16 > 4194304)
		{
			throw new Exception($"Size of field {"_rawCreateCollection"} must be less than {4096}KB");
		}
		*(int*)pBegin16 = fieldSize16;
		int elementsCount27 = _scarMarkTime.Count;
		int contentSize26 = 8 * elementsCount27;
		if (contentSize26 > 4194300)
		{
			throw new Exception($"Size of field {"_scarMarkTime"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize26 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount27;
		pCurrData += 2;
		for (int num30 = 0; num30 < elementsCount27; num30++)
		{
			pCurrData += _scarMarkTime[num30].Serialize(pCurrData);
		}
		int elementsCount28 = _teammateCommandCd.Count;
		int contentSize27 = 8 * elementsCount28;
		if (contentSize27 > 4194300)
		{
			throw new Exception($"Size of field {"_teammateCommandCd"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize27 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount28;
		pCurrData += 2;
		for (int num31 = 0; num31 < elementsCount28; num31++)
		{
			pCurrData += _teammateCommandCd[num31].Serialize(pCurrData);
		}
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				_id = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 1:
				_breathValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 2:
				_stanceValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 3:
				pCurrData += _neiliAllocation.Deserialize(pCurrData);
				break;
			case 4:
				pCurrData += _originNeiliAllocation.Deserialize(pCurrData);
				break;
			case 5:
				pCurrData += _neiliAllocationRecoverProgress.Deserialize(pCurrData);
				break;
			case 6:
				_oldDisorderOfQi = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 7:
				_neiliType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 8:
				pCurrData += _avoidToShow.Deserialize(pCurrData);
				break;
			case 9:
				_currentPosition = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 10:
				_displayPosition = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 11:
				_mobilityValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 12:
				_jumpPrepareProgress = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 13:
				_jumpPreparedDistance = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 14:
				_mobilityLockEffectCount = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 15:
				_jumpChangeDistanceDuration = *(float*)pCurrData;
				pCurrData += 4;
				break;
			case 16:
				_usingWeaponIndex = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 17:
			{
				if (_weaponTricks.Length != 6)
				{
					throw new Exception("Elements count of field _weaponTricks is not equal to declaration");
				}
				for (int num14 = 0; num14 < 6; num14++)
				{
					_weaponTricks[num14] = (sbyte)pCurrData[num14];
				}
				pCurrData += 6;
				break;
			}
			case 18:
				_weaponTrickIndex = *pCurrData;
				pCurrData++;
				break;
			case 19:
			{
				if (_weapons.Length != 7)
				{
					throw new Exception("Elements count of field _weapons is not equal to declaration");
				}
				for (int num12 = 0; num12 < 7; num12++)
				{
					ItemKey element6 = default(ItemKey);
					pCurrData += element6.Deserialize(pCurrData);
					_weapons[num12] = element6;
				}
				break;
			}
			case 20:
				_attackingTrickType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 21:
				_canAttackOutRange = *pCurrData != 0;
				pCurrData++;
				break;
			case 22:
				_changeTrickProgress = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 23:
				_changeTrickCount = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 24:
				_canChangeTrick = *pCurrData != 0;
				pCurrData++;
				break;
			case 25:
				_changingTrick = *pCurrData != 0;
				pCurrData++;
				break;
			case 26:
				_changeTrickAttack = *pCurrData != 0;
				pCurrData++;
				break;
			case 27:
				_isFightBack = *pCurrData != 0;
				pCurrData++;
				break;
			case 29:
				pCurrData += _injuries.Deserialize(pCurrData);
				break;
			case 30:
				pCurrData += _oldInjuries.Deserialize(pCurrData);
				break;
			case 32:
				pCurrData += _damageStepCollection.Deserialize(pCurrData);
				break;
			case 33:
			{
				if (_outerDamageValue.Length != 7)
				{
					throw new Exception("Elements count of field _outerDamageValue is not equal to declaration");
				}
				for (int num5 = 0; num5 < 7; num5++)
				{
					_outerDamageValue[num5] = ((int*)pCurrData)[num5];
				}
				pCurrData += 28;
				break;
			}
			case 34:
			{
				if (_innerDamageValue.Length != 7)
				{
					throw new Exception("Elements count of field _innerDamageValue is not equal to declaration");
				}
				for (int n = 0; n < 7; n++)
				{
					_innerDamageValue[n] = ((int*)pCurrData)[n];
				}
				pCurrData += 28;
				break;
			}
			case 35:
				_mindDamageValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 36:
				_fatalDamageValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 37:
			{
				if (_outerDamageValueToShow.Length != 7)
				{
					throw new Exception("Elements count of field _outerDamageValueToShow is not equal to declaration");
				}
				for (int i = 0; i < 7; i++)
				{
					IntPair element = default(IntPair);
					pCurrData += element.Deserialize(pCurrData);
					_outerDamageValueToShow[i] = element;
				}
				break;
			}
			case 38:
			{
				if (_innerDamageValueToShow.Length != 7)
				{
					throw new Exception("Elements count of field _innerDamageValueToShow is not equal to declaration");
				}
				for (int num15 = 0; num15 < 7; num15++)
				{
					IntPair element7 = default(IntPair);
					pCurrData += element7.Deserialize(pCurrData);
					_innerDamageValueToShow[num15] = element7;
				}
				break;
			}
			case 39:
				_mindDamageValueToShow = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 40:
				_fatalDamageValueToShow = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 41:
			{
				if (_flawCount.Length != 7)
				{
					throw new Exception("Elements count of field _flawCount is not equal to declaration");
				}
				for (int num13 = 0; num13 < 7; num13++)
				{
					_flawCount[num13] = pCurrData[num13];
				}
				pCurrData += 7;
				break;
			}
			case 43:
			{
				if (_acupointCount.Length != 7)
				{
					throw new Exception("Elements count of field _acupointCount is not equal to declaration");
				}
				for (int num11 = 0; num11 < 7; num11++)
				{
					_acupointCount[num11] = pCurrData[num11];
				}
				pCurrData += 7;
				break;
			}
			case 46:
				pCurrData += _poison.Deserialize(pCurrData);
				break;
			case 47:
				pCurrData += _oldPoison.Deserialize(pCurrData);
				break;
			case 48:
				pCurrData += _poisonResist.Deserialize(pCurrData);
				break;
			case 49:
				pCurrData += _newPoisonsToShow.Deserialize(pCurrData);
				break;
			case 56:
				_preparingSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 57:
				_skillPreparePercent = *pCurrData;
				pCurrData++;
				break;
			case 58:
				_performingSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 59:
				_autoCastingSkill = *pCurrData != 0;
				pCurrData++;
				break;
			case 60:
				_attackSkillAttackIndex = *pCurrData;
				pCurrData++;
				break;
			case 61:
				_attackSkillPower = *pCurrData;
				pCurrData++;
				break;
			case 62:
				_affectingMoveSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 63:
				_affectingDefendSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 64:
				_defendSkillTimePercent = *pCurrData;
				pCurrData++;
				break;
			case 65:
				_wugCount = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 66:
				_healInjuryCount = *pCurrData;
				pCurrData++;
				break;
			case 67:
				_healPoisonCount = *pCurrData;
				pCurrData++;
				break;
			case 68:
			{
				if (_otherActionCanUse.Length != 5)
				{
					throw new Exception("Elements count of field _otherActionCanUse is not equal to declaration");
				}
				for (int num10 = 0; num10 < 5; num10++)
				{
					_otherActionCanUse[num10] = pCurrData[num10] != 0;
				}
				pCurrData += 5;
				break;
			}
			case 69:
				_preparingOtherAction = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 70:
				_otherActionPreparePercent = *pCurrData;
				pCurrData++;
				break;
			case 71:
				_canSurrender = *pCurrData != 0;
				pCurrData++;
				break;
			case 72:
				_canUseItem = *pCurrData != 0;
				pCurrData++;
				break;
			case 73:
				pCurrData += _preparingItem.Deserialize(pCurrData);
				break;
			case 74:
				_useItemPreparePercent = *pCurrData;
				pCurrData++;
				break;
			case 80:
				_xiangshuEffectId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 81:
				_hazardValue = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 89:
				_animationTimeScale = *(float*)pCurrData;
				pCurrData += 4;
				break;
			case 90:
				_attackOutOfRange = *pCurrData != 0;
				pCurrData++;
				break;
			case 100:
				_bossPhase = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 101:
				_showTransferInjuryCommand = *pCurrData != 0;
				pCurrData++;
				break;
			case 103:
				_executingTeammateCommand = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 104:
				_visible = *pCurrData != 0;
				pCurrData++;
				break;
			case 105:
				_teammateCommandPreparePercent = *pCurrData;
				pCurrData++;
				break;
			case 106:
				_teammateCommandTimePercent = *pCurrData;
				pCurrData++;
				break;
			case 107:
				pCurrData += _attackCommandWeaponKey.Deserialize(pCurrData);
				break;
			case 108:
				_attackCommandTrickType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 109:
				_defendCommandSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 110:
				_showEffectCommandIndex = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 111:
				_attackCommandSkillId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 113:
				_targetDistance = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 117:
				pCurrData += _neiliAllocationCd.Deserialize(pCurrData);
				break;
			case 118:
				pCurrData += _proportionDelta.Deserialize(pCurrData);
				break;
			case 123:
				pCurrData += _normalAttackRecovery.Deserialize(pCurrData);
				break;
			case 124:
				_reserveNormalAttack = *pCurrData != 0;
				pCurrData++;
				break;
			case 125:
				_gangqi = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 126:
				_gangqiMax = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 127:
				_moveState = (MoveState)(*pCurrData);
				pCurrData++;
				break;
			case 128:
				_playerControllingMove = *pCurrData != 0;
				pCurrData++;
				break;
			case 130:
				pCurrData += _mindRhythm.Deserialize(pCurrData);
				break;
			case 131:
				pCurrData += _mindUpheavalTime.Deserialize(pCurrData);
				break;
			case 28:
				pCurrData += 4;
				pCurrData += _tricks.Deserialize(pCurrData);
				break;
			case 31:
				pCurrData += 4;
				pCurrData += _injuryAutoHealCollection.Deserialize(pCurrData);
				break;
			case 42:
				pCurrData += 4;
				pCurrData += _flawCollection.Deserialize(pCurrData);
				break;
			case 44:
				pCurrData += 4;
				pCurrData += _acupointCollection.Deserialize(pCurrData);
				break;
			case 45:
				pCurrData += 4;
				pCurrData += _mindMarkTime.Deserialize(pCurrData);
				break;
			case 50:
				pCurrData += 4;
				pCurrData += _defeatMarkCollection.Deserialize(pCurrData);
				break;
			case 51:
			{
				pCurrData += 4;
				ushort elementsCount12 = *(ushort*)pCurrData;
				pCurrData += 2;
				_neigongList.Clear();
				for (int num9 = 0; num9 < elementsCount12; num9++)
				{
					_neigongList.Add(((short*)pCurrData)[num9]);
				}
				pCurrData += 2 * elementsCount12;
				break;
			}
			case 52:
			{
				pCurrData += 4;
				ushort elementsCount11 = *(ushort*)pCurrData;
				pCurrData += 2;
				_attackSkillList.Clear();
				for (int num8 = 0; num8 < elementsCount11; num8++)
				{
					_attackSkillList.Add(((short*)pCurrData)[num8]);
				}
				pCurrData += 2 * elementsCount11;
				break;
			}
			case 53:
			{
				pCurrData += 4;
				ushort elementsCount10 = *(ushort*)pCurrData;
				pCurrData += 2;
				_agileSkillList.Clear();
				for (int num7 = 0; num7 < elementsCount10; num7++)
				{
					_agileSkillList.Add(((short*)pCurrData)[num7]);
				}
				pCurrData += 2 * elementsCount10;
				break;
			}
			case 54:
			{
				pCurrData += 4;
				ushort elementsCount9 = *(ushort*)pCurrData;
				pCurrData += 2;
				_defenceSkillList.Clear();
				for (int num6 = 0; num6 < elementsCount9; num6++)
				{
					_defenceSkillList.Add(((short*)pCurrData)[num6]);
				}
				pCurrData += 2 * elementsCount9;
				break;
			}
			case 55:
			{
				pCurrData += 4;
				ushort elementsCount8 = *(ushort*)pCurrData;
				pCurrData += 2;
				_assistSkillList.Clear();
				for (int num4 = 0; num4 < elementsCount8; num4++)
				{
					_assistSkillList.Add(((short*)pCurrData)[num4]);
				}
				pCurrData += 2 * elementsCount8;
				break;
			}
			case 75:
				pCurrData += 4;
				pCurrData += _combatReserveData.Deserialize(pCurrData);
				break;
			case 76:
				pCurrData += 4;
				pCurrData += _buffCombatStateCollection.Deserialize(pCurrData);
				break;
			case 77:
				pCurrData += 4;
				pCurrData += _debuffCombatStateCollection.Deserialize(pCurrData);
				break;
			case 78:
				pCurrData += 4;
				pCurrData += _specialCombatStateCollection.Deserialize(pCurrData);
				break;
			case 79:
				pCurrData += 4;
				pCurrData += _skillEffectCollection.Deserialize(pCurrData);
				break;
			case 82:
				pCurrData += 4;
				pCurrData += _showEffectList.Deserialize(pCurrData);
				break;
			case 83:
			{
				pCurrData += 4;
				uint contentSize16 = *(uint*)pCurrData;
				pCurrData += 4;
				_animationToLoop = Encoding.Unicode.GetString(pCurrData, (int)contentSize16);
				pCurrData += contentSize16;
				break;
			}
			case 84:
			{
				pCurrData += 4;
				uint contentSize15 = *(uint*)pCurrData;
				pCurrData += 4;
				_animationToPlayOnce = Encoding.Unicode.GetString(pCurrData, (int)contentSize15);
				pCurrData += contentSize15;
				break;
			}
			case 85:
			{
				pCurrData += 4;
				uint contentSize14 = *(uint*)pCurrData;
				pCurrData += 4;
				_particleToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize14);
				pCurrData += contentSize14;
				break;
			}
			case 86:
			{
				pCurrData += 4;
				uint contentSize13 = *(uint*)pCurrData;
				pCurrData += 4;
				_particleToLoop = Encoding.Unicode.GetString(pCurrData, (int)contentSize13);
				pCurrData += contentSize13;
				break;
			}
			case 87:
			{
				pCurrData += 4;
				uint contentSize12 = *(uint*)pCurrData;
				pCurrData += 4;
				_skillPetAnimation = Encoding.Unicode.GetString(pCurrData, (int)contentSize12);
				pCurrData += contentSize12;
				break;
			}
			case 88:
			{
				pCurrData += 4;
				uint contentSize11 = *(uint*)pCurrData;
				pCurrData += 4;
				_petParticle = Encoding.Unicode.GetString(pCurrData, (int)contentSize11);
				pCurrData += contentSize11;
				break;
			}
			case 91:
			{
				pCurrData += 4;
				uint contentSize10 = *(uint*)pCurrData;
				pCurrData += 4;
				_attackSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize10);
				pCurrData += contentSize10;
				break;
			}
			case 92:
			{
				pCurrData += 4;
				uint contentSize9 = *(uint*)pCurrData;
				pCurrData += 4;
				_skillSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize9);
				pCurrData += contentSize9;
				break;
			}
			case 93:
			{
				pCurrData += 4;
				uint contentSize8 = *(uint*)pCurrData;
				pCurrData += 4;
				_hitSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize8);
				pCurrData += contentSize8;
				break;
			}
			case 94:
			{
				pCurrData += 4;
				uint contentSize7 = *(uint*)pCurrData;
				pCurrData += 4;
				_armorHitSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize7);
				pCurrData += contentSize7;
				break;
			}
			case 95:
			{
				pCurrData += 4;
				uint contentSize6 = *(uint*)pCurrData;
				pCurrData += 4;
				_whooshSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize6);
				pCurrData += contentSize6;
				break;
			}
			case 96:
			{
				pCurrData += 4;
				uint contentSize5 = *(uint*)pCurrData;
				pCurrData += 4;
				_shockSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize5);
				pCurrData += contentSize5;
				break;
			}
			case 97:
			{
				pCurrData += 4;
				uint contentSize4 = *(uint*)pCurrData;
				pCurrData += 4;
				_stepSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize4);
				pCurrData += contentSize4;
				break;
			}
			case 98:
			{
				pCurrData += 4;
				uint contentSize3 = *(uint*)pCurrData;
				pCurrData += 4;
				_dieSoundToPlay = Encoding.Unicode.GetString(pCurrData, (int)contentSize3);
				pCurrData += contentSize3;
				break;
			}
			case 99:
			{
				pCurrData += 4;
				uint contentSize2 = *(uint*)pCurrData;
				pCurrData += 4;
				_soundToLoop = Encoding.Unicode.GetString(pCurrData, (int)contentSize2);
				pCurrData += contentSize2;
				break;
			}
			case 102:
			{
				pCurrData += 4;
				ushort elementsCount7 = *(ushort*)pCurrData;
				pCurrData += 2;
				_currTeammateCommands.Clear();
				for (int num3 = 0; num3 < elementsCount7; num3++)
				{
					_currTeammateCommands.Add((sbyte)pCurrData[num3]);
				}
				pCurrData += (int)elementsCount7;
				break;
			}
			case 112:
			{
				pCurrData += 4;
				ushort elementsCount6 = *(ushort*)pCurrData;
				pCurrData += 2;
				_teammateCommandBanReasons.Clear();
				for (int num2 = 0; num2 < elementsCount6; num2++)
				{
					SByteList element5 = default(SByteList);
					pCurrData += element5.Deserialize(pCurrData);
					_teammateCommandBanReasons.Add(element5);
				}
				break;
			}
			case 114:
				pCurrData += 4;
				pCurrData += _oldInjuryAutoHealCollection.Deserialize(pCurrData);
				break;
			case 115:
				pCurrData += 4;
				pCurrData += _mixPoisonAffectedCount.Deserialize(pCurrData);
				break;
			case 116:
			{
				pCurrData += 4;
				uint contentSize = *(uint*)pCurrData;
				pCurrData += 4;
				_particleToLoopByCombatSkill = Encoding.Unicode.GetString(pCurrData, (int)contentSize);
				pCurrData += contentSize;
				break;
			}
			case 119:
			{
				pCurrData += 4;
				ushort elementsCount5 = *(ushort*)pCurrData;
				pCurrData += 2;
				_showCommandList.Clear();
				for (int num = 0; num < elementsCount5; num++)
				{
					TeammateCommandDisplayData element4 = default(TeammateCommandDisplayData);
					pCurrData += element4.Deserialize(pCurrData);
					_showCommandList.Add(element4);
				}
				break;
			}
			case 120:
			{
				pCurrData += 4;
				ushort elementsCount4 = *(ushort*)pCurrData;
				pCurrData += 2;
				_unlockPrepareValue.Clear();
				for (int m = 0; m < elementsCount4; m++)
				{
					_unlockPrepareValue.Add(((int*)pCurrData)[m]);
				}
				pCurrData += 4 * elementsCount4;
				break;
			}
			case 121:
			{
				pCurrData += 4;
				ushort elementsCount3 = *(ushort*)pCurrData;
				pCurrData += 2;
				_rawCreateEffects.Clear();
				for (int l = 0; l < elementsCount3; l++)
				{
					_rawCreateEffects.Add(((int*)pCurrData)[l]);
				}
				pCurrData += 4 * elementsCount3;
				break;
			}
			case 122:
				pCurrData += 4;
				pCurrData += _rawCreateCollection.Deserialize(pCurrData);
				break;
			case 129:
			{
				pCurrData += 4;
				ushort elementsCount2 = *(ushort*)pCurrData;
				pCurrData += 2;
				_scarMarkTime.Clear();
				for (int k = 0; k < elementsCount2; k++)
				{
					CountdownData element3 = default(CountdownData);
					pCurrData += element3.Deserialize(pCurrData);
					_scarMarkTime.Add(element3);
				}
				break;
			}
			case 132:
			{
				pCurrData += 4;
				ushort elementsCount = *(ushort*)pCurrData;
				pCurrData += 2;
				_teammateCommandCd.Clear();
				for (int j = 0; j < elementsCount; j++)
				{
					CountdownData element2 = default(CountdownData);
					pCurrData += element2.Deserialize(pCurrData);
					_teammateCommandCd.Add(element2);
				}
				break;
			}
			default:
				if (fieldIndex < fixedFieldSizes.Length)
				{
					int fieldSize = fixedFieldSizes[fieldIndex];
					pCurrData += fieldSize;
				}
				else
				{
					int fieldSize2 = *(int*)pCurrData;
					pCurrData += 4;
					pCurrData += fieldSize2;
				}
				break;
			}
		}
		return (int)(pCurrData - pData);
	}
}

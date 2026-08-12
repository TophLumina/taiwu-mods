using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using CompDevLib.Interpreter;
using Config;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Achievement;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Ai.GeneralAction;
using GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;
using GameData.Domains.Character.Ai.GeneralAction.LifeSkillRandom;
using GameData.Domains.Character.Ai.GeneralAction.SocialStatusRandom;
using GameData.Domains.Character.Ai.GeneralAction.TeachRandom;
using GameData.Domains.Character.Ai.GeneralAction.WealthDemand;
using GameData.Domains.Character.Alertness;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.AvatarSystem.AvatarRes;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Mission;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.Character.Relation;
using GameData.Domains.Character.TemporaryModification;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Global;
using GameData.Domains.Global.Inscription;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.Item.Filters;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.SpecialEffect;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true)]
public class Character : BaseGameDataObject, ISerializableGameData, IValueSelector
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint TemplateId_Offset = 4u;

		public const int TemplateId_Size = 2;

		public const uint CreatingType_Offset = 6u;

		public const int CreatingType_Size = 1;

		public const uint Gender_Offset = 7u;

		public const int Gender_Size = 1;

		public const uint ActualAge_Offset = 8u;

		public const int ActualAge_Size = 2;

		public const uint BirthMonth_Offset = 10u;

		public const int BirthMonth_Size = 1;

		public const uint Happiness_Offset = 11u;

		public const int Happiness_Size = 1;

		public const uint BaseMorality_Offset = 12u;

		public const int BaseMorality_Size = 2;

		public const uint OrganizationInfo_Offset = 14u;

		public const int OrganizationInfo_Size = 8;

		public const uint IdealSect_Offset = 22u;

		public const int IdealSect_Size = 1;

		public const uint LifeSkillTypeInterest_Offset = 23u;

		public const int LifeSkillTypeInterest_Size = 1;

		public const uint CombatSkillTypeInterest_Offset = 24u;

		public const int CombatSkillTypeInterest_Size = 1;

		public const uint MainAttributeInterest_Offset = 25u;

		public const int MainAttributeInterest_Size = 1;

		public const uint Transgender_Offset = 26u;

		public const int Transgender_Size = 1;

		public const uint Bisexual_Offset = 27u;

		public const int Bisexual_Size = 1;

		public const uint XiangshuType_Offset = 28u;

		public const int XiangshuType_Size = 1;

		public const uint MonkType_Offset = 29u;

		public const int MonkType_Size = 1;

		public const uint BaseMainAttributes_Offset = 30u;

		public const int BaseMainAttributes_Size = 12;

		public const uint Health_Offset = 42u;

		public const int Health_Size = 2;

		public const uint BaseMaxHealth_Offset = 44u;

		public const int BaseMaxHealth_Size = 2;

		public const uint DisorderOfQi_Offset = 46u;

		public const int DisorderOfQi_Size = 2;

		public const uint HaveLeftArm_Offset = 48u;

		public const int HaveLeftArm_Size = 1;

		public const uint HaveRightArm_Offset = 49u;

		public const int HaveRightArm_Size = 1;

		public const uint HaveLeftLeg_Offset = 50u;

		public const int HaveLeftLeg_Size = 1;

		public const uint HaveRightLeg_Offset = 51u;

		public const int HaveRightLeg_Size = 1;

		public const uint Injuries_Offset = 52u;

		public const int Injuries_Size = 16;

		public const uint ExtraNeili_Offset = 68u;

		public const int ExtraNeili_Size = 4;

		public const uint ConsummateLevel_Offset = 72u;

		public const int ConsummateLevel_Size = 1;

		public const uint BaseLifeSkillQualifications_Offset = 73u;

		public const int BaseLifeSkillQualifications_Size = 32;

		public const uint LifeSkillQualificationGrowthType_Offset = 105u;

		public const int LifeSkillQualificationGrowthType_Size = 1;

		public const uint BaseCombatSkillQualifications_Offset = 106u;

		public const int BaseCombatSkillQualifications_Size = 28;

		public const uint CombatSkillQualificationGrowthType_Offset = 134u;

		public const int CombatSkillQualificationGrowthType_Size = 1;

		public const uint Resources_Offset = 135u;

		public const int Resources_Size = 32;

		public const uint LovingItemSubType_Offset = 167u;

		public const int LovingItemSubType_Size = 2;

		public const uint HatingItemSubType_Offset = 169u;

		public const int HatingItemSubType_Size = 2;

		public const uint FullName_Offset = 171u;

		public const int FullName_Size = 10;

		public const uint MonasticTitle_Offset = 181u;

		public const int MonasticTitle_Size = 4;

		public const uint Genome_Offset = 185u;

		public const int Genome_Size = 64;

		public const uint CurrMainAttributes_Offset = 249u;

		public const int CurrMainAttributes_Size = 12;

		public const uint Poisoned_Offset = 261u;

		public const int Poisoned_Size = 24;

		public const uint CurrNeili_Offset = 285u;

		public const int CurrNeili_Size = 4;

		public const uint LoopingNeigong_Offset = 289u;

		public const int LoopingNeigong_Size = 2;

		public const uint BaseNeiliAllocation_Offset = 291u;

		public const int BaseNeiliAllocation_Size = 8;

		public const uint ExtraNeiliAllocation_Offset = 299u;

		public const int ExtraNeiliAllocation_Size = 8;

		public const uint BaseNeiliProportionOfFiveElements_Offset = 307u;

		public const int BaseNeiliProportionOfFiveElements_Size = 8;

		public const uint HobbyExpirationDate_Offset = 315u;

		public const int HobbyExpirationDate_Size = 4;

		public const uint LovingItemRevealed_Offset = 319u;

		public const int LovingItemRevealed_Size = 1;

		public const uint HatingItemRevealed_Offset = 320u;

		public const int HatingItemRevealed_Size = 1;

		public const uint LegitimateBoysCount_Offset = 321u;

		public const int LegitimateBoysCount_Size = 1;

		public const uint BirthLocation_Offset = 322u;

		public const int BirthLocation_Size = 4;

		public const uint Location_Offset = 326u;

		public const int Location_Size = 4;

		public const uint Equipment_Offset = 330u;

		public const int Equipment_Size = 136;

		public const uint EatingItems_Offset = 466u;

		public const int EatingItems_Size = 90;

		public const uint EquippedCombatSkills_Offset = 556u;

		public const int EquippedCombatSkills_Size = 96;

		public const uint CombatSkillAttainmentPanels_Offset = 652u;

		public const int CombatSkillAttainmentPanels_Size = 252;

		public const uint PreexistenceCharIds_Offset = 904u;

		public const int PreexistenceCharIds_Size = 40;

		public const uint XiangshuInfection_Offset = 944u;

		public const int XiangshuInfection_Size = 1;

		public const uint CurrAge_Offset = 945u;

		public const int CurrAge_Size = 2;

		public const uint Exp_Offset = 947u;

		public const int Exp_Size = 4;

		public const uint ExternalRelationState_Offset = 951u;

		public const int ExternalRelationState_Size = 8;

		public const uint KidnapperId_Offset = 959u;

		public const int KidnapperId_Size = 4;

		public const uint LeaderId_Offset = 963u;

		public const int LeaderId_Size = 4;

		public const uint FactionId_Offset = 967u;

		public const int FactionId_Size = 4;

		public const uint ExtraNeiliAllocationProgress_Offset = 971u;

		public const int ExtraNeiliAllocationProgress_Size = 16;

		public const uint UsedQualificationPotential_Offset = 987u;

		public const int UsedQualificationPotential_Size = 2;
	}

	public class ProtagonistFeatureRelatedStatus
	{
		public List<GameData.Domains.CombatSkill.CombatSkill> CombatSkills;

		public List<GameData.Domains.Item.SkillBook> LifeSkillBooks;

		public bool AddFeatureLongevity;

		public bool CreateCloseFriend;

		public Dictionary<short, List<ItemKey>> CustomItems;

		public ProtagonistFeatureRelatedStatus(List<GameData.Domains.CombatSkill.CombatSkill> combatSkills)
		{
			CombatSkills = combatSkills;
			CreateCloseFriend = false;
		}
	}

	[CollectionObjectField(false, true, false, true, false)]
	private int _id;

	[CollectionObjectField(true, true, false, true, false)]
	private short _templateId;

	[CollectionObjectField(true, true, false, true, false)]
	private byte _creatingType;

	[CollectionObjectField(true, true, false, true, false)]
	private sbyte _gender;

	[CollectionObjectField(true, true, false, false, false)]
	private short _actualAge;

	[CollectionObjectField(true, true, false, true, false)]
	private sbyte _birthMonth;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _happiness;

	[CollectionObjectField(true, true, false, false, false)]
	private short _baseMorality;

	[CollectionObjectField(true, true, false, false, false)]
	private OrganizationInfo _organizationInfo;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _idealSect;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _lifeSkillTypeInterest;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _combatSkillTypeInterest;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _mainAttributeInterest;

	[CollectionObjectField(true, true, false, true, false)]
	private bool _transgender;

	[CollectionObjectField(true, true, false, true, false)]
	private bool _bisexual;

	[CollectionObjectField(true, true, false, true, false)]
	private sbyte _xiangshuType;

	[CollectionObjectField(true, true, false, false, false)]
	private byte _monkType;

	[CollectionObjectField(true, true, false, false, false)]
	private List<short> _featureIds;

	[CollectionObjectField(true, true, false, false, false)]
	private MainAttributes _baseMainAttributes;

	[CollectionObjectField(true, true, false, false, false)]
	private short _health;

	[CollectionObjectField(true, true, false, false, false)]
	private short _baseMaxHealth;

	[CollectionObjectField(true, true, false, false, false)]
	private short _disorderOfQi;

	[CollectionObjectField(true, true, false, false, false)]
	private bool _haveLeftArm;

	[CollectionObjectField(true, true, false, false, false)]
	private bool _haveRightArm;

	[CollectionObjectField(true, true, false, false, false)]
	private bool _haveLeftLeg;

	[CollectionObjectField(true, true, false, false, false)]
	private bool _haveRightLeg;

	[CollectionObjectField(true, true, false, false, false)]
	private Injuries _injuries;

	[CollectionObjectField(true, true, false, false, false)]
	private int _extraNeili;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _consummateLevel;

	[CollectionObjectField(true, true, false, false, false)]
	private List<LifeSkillItem> _learnedLifeSkills;

	[CollectionObjectField(true, true, false, false, false)]
	private LifeSkillShorts _baseLifeSkillQualifications;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _lifeSkillQualificationGrowthType;

	[CollectionObjectField(true, true, false, false, false)]
	private CombatSkillShorts _baseCombatSkillQualifications;

	[CollectionObjectField(true, true, false, false, false)]
	private sbyte _combatSkillQualificationGrowthType;

	[CollectionObjectField(true, true, false, false, false)]
	private ResourceInts _resources;

	[CollectionObjectField(true, true, false, false, false)]
	private short _lovingItemSubType;

	[CollectionObjectField(true, true, false, false, false)]
	private short _hatingItemSubType;

	[CollectionObjectField(false, true, false, false, false)]
	private FullName _fullName;

	[CollectionObjectField(false, true, false, false, false)]
	private MonasticTitle _monasticTitle;

	[CollectionObjectField(false, true, false, false, false)]
	private AvatarData _avatar;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _potentialFeatureIds;

	[CollectionObjectField(false, true, false, false, false)]
	private List<FameActionRecord> _fameActionRecords;

	[CollectionObjectField(false, true, false, true, false)]
	private Genome _genome;

	[CollectionObjectField(false, true, false, false, false)]
	private MainAttributes _currMainAttributes;

	[CollectionObjectField(false, true, false, false, false)]
	private PoisonInts _poisoned;

	[CollectionObjectField(false, true, false, false, false)]
	private int _currNeili;

	[CollectionObjectField(false, true, false, false, false)]
	private short _loopingNeigong;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliAllocation _baseNeiliAllocation;

	[CollectionObjectField(true, true, false, false, false)]
	private NeiliAllocation _extraNeiliAllocation;

	[CollectionObjectField(false, true, false, false, false)]
	private NeiliProportionOfFiveElements _baseNeiliProportionOfFiveElements;

	[CollectionObjectField(false, true, false, false, false)]
	private int _hobbyExpirationDate;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _lovingItemRevealed;

	[CollectionObjectField(false, true, false, false, false)]
	private bool _hatingItemRevealed;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _legitimateBoysCount;

	[CollectionObjectField(false, true, false, true, false)]
	private Location _birthLocation;

	[CollectionObjectField(false, true, false, false, false)]
	private Location _location;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 17)]
	private ItemKey[] _equipment;

	[CollectionObjectField(false, true, false, false, false)]
	private Inventory _inventory;

	[CollectionObjectField(false, true, false, false, false)]
	private EatingItems _eatingItems;

	[CollectionObjectField(false, true, false, false, false)]
	private List<short> _learnedCombatSkills;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 48)]
	private short[] _equippedCombatSkills;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 126)]
	private short[] _combatSkillAttainmentPanels;

	[CollectionObjectField(false, true, false, false, false)]
	private List<SkillQualificationBonus> _skillQualificationBonuses;

	[CollectionObjectField(false, true, false, true, false)]
	private PreexistenceCharIds _preexistenceCharIds;

	[CollectionObjectField(false, true, false, false, false)]
	private byte _xiangshuInfection;

	[CollectionObjectField(false, true, false, false, false)]
	private short _currAge;

	[CollectionObjectField(false, true, false, false, false)]
	private int _exp;

	[CollectionObjectField(false, true, false, false, false)]
	private ulong _externalRelationState;

	[CollectionObjectField(false, true, false, false, false)]
	private int _kidnapperId;

	[CollectionObjectField(false, true, false, false, false)]
	private int _leaderId;

	[CollectionObjectField(false, true, false, false, false)]
	private int _factionId;

	[CollectionObjectField(false, true, false, false, false)]
	private List<NpcTravelTarget> _npcTravelTargets;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 4)]
	private int[] _extraNeiliAllocationProgress;

	[CollectionObjectField(false, true, false, false, false)]
	private short _usedQualificationPotential;

	[CollectionObjectField(false, true, false, false, false, ArrayElementsCount = 8)]
	private WugKingDriveDataEx[] _wugKingDriveDataEx;

	[CollectionObjectField(false, false, true, false, false)]
	private short _physiologicalAge;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _fame;

	[CollectionObjectField(false, false, true, false, false)]
	private short _morality;

	[CollectionObjectField(false, false, true, false, false)]
	private short _attraction;

	[CollectionObjectField(false, false, true, false, false)]
	private MainAttributes _maxMainAttributes;

	[CollectionObjectField(false, false, true, false, false)]
	private HitOrAvoidInts _hitValues;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerInts _penetrations;

	[CollectionObjectField(false, false, true, false, false)]
	private HitOrAvoidInts _avoidValues;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerInts _penetrationResists;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerShorts _recoveryOfStanceAndBreath;

	[CollectionObjectField(false, false, true, false, false)]
	private short _moveSpeed;

	[CollectionObjectField(false, false, true, false, false)]
	private short _recoveryOfFlaw;

	[CollectionObjectField(false, false, true, false, false)]
	private short _castSpeed;

	[CollectionObjectField(false, false, true, false, false)]
	private short _recoveryOfBlockedAcupoint;

	[CollectionObjectField(false, false, true, false, false)]
	private short _weaponSwitchSpeed;

	[CollectionObjectField(false, false, true, false, false)]
	private short _attackSpeed;

	[CollectionObjectField(false, false, true, false, false)]
	private short _innerRatio;

	[CollectionObjectField(false, false, true, false, false)]
	private short _recoveryOfQiDisorder;

	[CollectionObjectField(false, false, true, false, false)]
	private PoisonInts _poisonResists;

	[CollectionObjectField(false, false, true, false, false)]
	private short _maxHealth;

	[CollectionObjectField(false, false, true, false, false)]
	private short _fertility;

	[CollectionObjectField(false, false, true, false, false)]
	private LifeSkillShorts _lifeSkillQualifications;

	[CollectionObjectField(false, false, true, false, false)]
	private LifeSkillShorts _lifeSkillAttainments;

	[CollectionObjectField(false, false, true, false, false)]
	private CombatSkillShorts _combatSkillQualifications;

	[CollectionObjectField(false, false, true, false, false)]
	private CombatSkillShorts _combatSkillAttainments;

	[CollectionObjectField(false, false, true, false, false)]
	private Personalities _personalities;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _hobbyChangingPeriod;

	[CollectionObjectField(false, false, true, false, false)]
	private OuterAndInnerShorts _favorabilityChangingFactor;

	[CollectionObjectField(false, false, true, false, false)]
	private int _maxInventoryLoad;

	[CollectionObjectField(false, false, true, false, false)]
	private int _currInventoryLoad;

	[CollectionObjectField(false, false, true, false, false)]
	private int _maxEquipmentLoad;

	[CollectionObjectField(false, false, true, false, false)]
	private int _currEquipmentLoad;

	[CollectionObjectField(false, false, true, false, false)]
	private int _inventoryTotalValue;

	[CollectionObjectField(false, false, true, false, false)]
	private int _maxNeili;

	[CollectionObjectField(false, false, true, false, false)]
	private NeiliAllocation _neiliAllocation;

	[CollectionObjectField(false, false, true, false, false)]
	private NeiliProportionOfFiveElements _neiliProportionOfFiveElements;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _neiliType;

	[CollectionObjectField(false, false, true, false, false)]
	private int _combatPower;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _attackTendencyOfInnerAndOuter;

	[CollectionObjectField(false, false, true, false, false)]
	private NeiliAllocation _allocatedNeiliEffects;

	[CollectionObjectField(false, false, true, false, false)]
	private sbyte _maxConsummateLevel;

	[CollectionObjectField(false, false, true, false, false)]
	private CombatSkillEquipment _combatSkillEquipment;

	[CollectionObjectField(false, false, true, false, false)]
	private uint _darkAshProtector;

	private const int BasePersonality = 10;

	private const int PreexistenceAttributeBonusDivisor = 10;

	private const int BaseFertility = 100;

	private ActionPlanningData _actionPlanningData;

	private const int UnreachableGoalPriorityChange = -200;

	private static readonly List<(short min, short max)> RandomFavorabilityRanges = new List<(short, short)>
	{
		(-30000, -18000),
		(-17999, 0),
		(1, 17999),
		(18000, 30000)
	};

	public const int InnateSkillQualificationBonusesCount = 2;

	public const int AcquiredSkillQualificationBonusesMaxCount = 9;

	public static readonly List<ECharacterPropertyReferencedType> HitAvoidAttackDefendPropertyTypes = new List<ECharacterPropertyReferencedType>
	{
		ECharacterPropertyReferencedType.HitRateStrength,
		ECharacterPropertyReferencedType.HitRateTechnique,
		ECharacterPropertyReferencedType.HitRateSpeed,
		ECharacterPropertyReferencedType.HitRateMind,
		ECharacterPropertyReferencedType.AvoidRateStrength,
		ECharacterPropertyReferencedType.AvoidRateTechnique,
		ECharacterPropertyReferencedType.AvoidRateSpeed,
		ECharacterPropertyReferencedType.AvoidRateMind,
		ECharacterPropertyReferencedType.PenetrateOfOuter,
		ECharacterPropertyReferencedType.PenetrateOfInner,
		ECharacterPropertyReferencedType.PenetrateResistOfOuter,
		ECharacterPropertyReferencedType.PenetrateResistOfInner
	};

	public static readonly List<ECharacterPropertyReferencedType> CombatPropertyTypes = new List<ECharacterPropertyReferencedType>(HitAvoidAttackDefendPropertyTypes)
	{
		ECharacterPropertyReferencedType.Strength,
		ECharacterPropertyReferencedType.Dexterity,
		ECharacterPropertyReferencedType.Concentration,
		ECharacterPropertyReferencedType.Vitality,
		ECharacterPropertyReferencedType.Energy,
		ECharacterPropertyReferencedType.Intelligence,
		ECharacterPropertyReferencedType.RecoveryOfStance,
		ECharacterPropertyReferencedType.RecoveryOfBreath,
		ECharacterPropertyReferencedType.RecoveryOfFlaw,
		ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint,
		ECharacterPropertyReferencedType.RecoveryOfQiDisorder,
		ECharacterPropertyReferencedType.MoveSpeed,
		ECharacterPropertyReferencedType.CastSpeed,
		ECharacterPropertyReferencedType.AttackSpeed,
		ECharacterPropertyReferencedType.WeaponSwitchSpeed,
		ECharacterPropertyReferencedType.InnerRatio
	};

	public static readonly List<ECharacterPropertyReferencedType> BonusPropertyTypes = new List<ECharacterPropertyReferencedType>(CombatPropertyTypes)
	{
		ECharacterPropertyReferencedType.QualificationAppraisal,
		ECharacterPropertyReferencedType.QualificationBlade,
		ECharacterPropertyReferencedType.QualificationBuddhism,
		ECharacterPropertyReferencedType.QualificationChess,
		ECharacterPropertyReferencedType.QualificationCooking,
		ECharacterPropertyReferencedType.QualificationEclectic,
		ECharacterPropertyReferencedType.QualificationFinger,
		ECharacterPropertyReferencedType.QualificationForging,
		ECharacterPropertyReferencedType.QualificationJade,
		ECharacterPropertyReferencedType.QualificationLeg,
		ECharacterPropertyReferencedType.QualificationMath,
		ECharacterPropertyReferencedType.QualificationMedicine,
		ECharacterPropertyReferencedType.QualificationMusic,
		ECharacterPropertyReferencedType.QualificationNeigong,
		ECharacterPropertyReferencedType.QualificationPainting,
		ECharacterPropertyReferencedType.QualificationPoem,
		ECharacterPropertyReferencedType.QualificationPolearm,
		ECharacterPropertyReferencedType.QualificationPosing,
		ECharacterPropertyReferencedType.QualificationSpecial,
		ECharacterPropertyReferencedType.QualificationStunt,
		ECharacterPropertyReferencedType.QualificationSword,
		ECharacterPropertyReferencedType.QualificationTaoism,
		ECharacterPropertyReferencedType.QualificationThrow,
		ECharacterPropertyReferencedType.QualificationToxicology,
		ECharacterPropertyReferencedType.QualificationWeaving,
		ECharacterPropertyReferencedType.QualificationWhip,
		ECharacterPropertyReferencedType.QualificationWoodworking,
		ECharacterPropertyReferencedType.QualificationCombatMusic,
		ECharacterPropertyReferencedType.QualificationControllableShot,
		ECharacterPropertyReferencedType.QualificationFistAndPalm
	};

	public static readonly List<ECharacterPropertyReferencedType> BonusAndPoisonResistPropertyTypes = new List<ECharacterPropertyReferencedType>(BonusPropertyTypes)
	{
		ECharacterPropertyReferencedType.ResistOfHotPoison,
		ECharacterPropertyReferencedType.ResistOfGloomyPoison,
		ECharacterPropertyReferencedType.ResistOfColdPoison,
		ECharacterPropertyReferencedType.ResistOfRedPoison,
		ECharacterPropertyReferencedType.ResistOfRottenPoison,
		ECharacterPropertyReferencedType.ResistOfIllusoryPoison
	};

	public static readonly IReadOnlyList<EHealActionType> AllHealActions = new EHealActionType[4]
	{
		EHealActionType.Healing,
		EHealActionType.Detox,
		EHealActionType.Breathing,
		EHealActionType.Recover
	};

	private byte _advanceMonthStatus;

	private const sbyte SearchRandomDestinationMaxCount = 10;

	public const int FixedSize = 989;

	public const int DynamicCount = 10;

	private SpinLock _spinLock = new SpinLock(enableThreadOwnerTracking: false);

	private static readonly ushort[] ArchiveFieldIds = new ushort[75]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
		10, 11, 12, 13, 14, 15, 16, 18, 19, 20,
		21, 22, 23, 24, 25, 26, 27, 28, 30, 31,
		32, 33, 34, 35, 36, 37, 38, 42, 43, 44,
		45, 46, 47, 48, 49, 50, 51, 52, 53, 54,
		55, 56, 58, 60, 61, 63, 64, 65, 66, 67,
		68, 69, 70, 72, 73, 17, 29, 39, 40, 41,
		57, 59, 62, 71, 74
	};

	private static readonly int[] FixedArchiveFieldSizes = new int[65]
	{
		4, 2, 1, 1, 2, 1, 1, 2, 8, 1,
		1, 1, 1, 1, 1, 1, 1, 12, 2, 2,
		2, 1, 1, 1, 1, 16, 4, 1, 32, 1,
		28, 1, 32, 2, 2, 10, 4, 64, 12, 24,
		4, 2, 8, 8, 8, 4, 1, 1, 1, 4,
		4, 136, 90, 96, 252, 40, 1, 2, 4, 8,
		4, 4, 4, 16, 2
	};

	private int _srcCharId = -1;

	private static readonly (TemplateKey templateKey, int amount)[] ProtagonistInitialItems = new(TemplateKey, int)[9]
	{
		(new TemplateKey(8, 54), 3),
		(new TemplateKey(8, 60), 2),
		(new TemplateKey(8, 58), 1),
		(new TemplateKey(8, 66), 3),
		(new TemplateKey(8, 72), 2),
		(new TemplateKey(8, 70), 1),
		(new TemplateKey(8, 88), 3),
		(new TemplateKey(8, 94), 3),
		(new TemplateKey(6, 0), 1)
	};

	private static readonly sbyte[][] LovingAndHatingSectsCandidates = new sbyte[5][]
	{
		new sbyte[3] { 5, 8, 14 },
		new sbyte[5] { 1, 2, 3, 5, 8 },
		new sbyte[9] { 1, 2, 3, 4, 6, 7, 9, 12, 13 },
		new sbyte[6] { 6, 10, 11, 12, 13, 15 },
		new sbyte[3] { 10, 11, 15 }
	};

	private const sbyte AttractionFollowGradeChance = 20;

	private readonly List<ItemKey> _itemsToBeDeleted = new List<ItemKey>();

	public short QualificationAge
	{
		get
		{
			short age = GetClampedAgeOfAgeEffect(_actualAge);
			if (_featureIds.Contains(879) && age < 16)
			{
				age = 16;
			}
			return age;
		}
	}

	public ActionPlanningData ActionPlanningData
	{
		get
		{
			if (_actionPlanningData != null)
			{
				return _actionPlanningData;
			}
			_actionPlanningData = DomainManager.Character.GetActionPlanningData(_id);
			_actionPlanningData.InitCharacter(this);
			return _actionPlanningData;
		}
	}

	public bool CanNotSpeak
	{
		get
		{
			bool flag = DomainManager.Character.GetSkeletonSourceGraveId(_id) >= 0 || !Config.Character.Instance[_templateId].CanSpeak;
			bool flag2 = flag;
			if (!flag2)
			{
				short templateId = _equipment[4].TemplateId;
				bool flag3 = (uint)(templateId - 69) <= 2u;
				flag2 = flag3;
			}
			return flag2;
		}
	}

	public bool CanAffectedByCombatDifficulty => DomainManager.Character.IsTemporaryIntelligentCharacter(_id) || (!IsTaiwu() && _leaderId != DomainManager.Taiwu.GetTaiwuCharId() && !DomainManager.Combat.GetTaiwuSpecialGroupCharIds().Contains(_id) && GetOrganizationInfo().OrgTemplateId != 16);

	public bool IsGearMate
	{
		get
		{
			short templateId = GetTemplateId();
			if ((uint)(templateId - 722) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public CharacterItem Template => Config.Character.Instance[_templateId];

	public bool IsFavorabilityGainFixed
	{
		get
		{
			int result;
			if (_creatingType == 1)
			{
				short templateId = _templateId;
				result = ((templateId <= 522 && templateId >= 519) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public bool HasDarkAsh => (GetDarkAshProtector() & 0x200) != 0;

	public int DarkAshDuration
	{
		get
		{
			int date = DomainManager.Character.GetTemporaryFeatureExpireDate(_id, 216);
			return (date != -1) ? (date - DomainManager.World.GetCurrDate()) : (-1);
		}
	}

	public int SaveFromInfectedGainFaith => GlobalConfig.FuyuFaithCountBySaveInfected[Math.Clamp(_consummateLevel, 0, GlobalConfig.FuyuFaithCountBySaveInfected.Length - 1)];

	public bool AnyAvailableEatingSlot => _eatingItems.GetAvailableEatingSlot(GetCurrMaxEatingSlotsCount()) >= 0;

	public int WorkingCarrierMaxInventoryLoadBonus => (from itemKey in GetValidCarrierEquipment()
		select DomainManager.Item.GetElement_Carriers(itemKey.Id) into equipment
		where equipment.GetMaxDurability() == 0 || equipment.GetCurrDurability() > 0
		select equipment).Select((Func<GameData.Domains.Item.Carrier, int>)((GameData.Domains.Item.Carrier equipment) => equipment.GetMaxInventoryLoadBonus())).Append(0).Max();

	public int WorkingCarrierKidnapMaxSlotCount => GetValidCarrierEquipment().Select((Func<ItemKey, int>)((ItemKey carrierKey) => DomainManager.Item.GetElement_Carriers(carrierKey.Id).GetMaxKidnapSlotCountBonus())).Append(0).Max();

	public int WorkingCarrierTimeBonus => GetValidCarrierEquipment().Select((Func<ItemKey, int>)((ItemKey itemKey) => DomainManager.Item.GetElement_Carriers(itemKey.Id).GetTravelTimeReduction())).Append(0).Max();

	public int WorkingCarrierDropBonus => GetValidCarrierEquipment().Select((Func<ItemKey, int>)((ItemKey carrierKey) => DomainManager.Item.GetElement_Carriers(carrierKey.Id).GetDropRateBonus())).Append(0).Max();

	public int WorkingCarrierExploreBonusRate => (from carrierKey in GetValidCarrierEquipment()
		select DomainManager.Item.GetElement_Carriers(carrierKey.Id).GetExploreBonusRate()).Append(0).Max();

	public int WorkingCarrierCaptureRateBonus => GetValidCarrierEquipment().Select((Func<ItemKey, int>)((ItemKey carrierKey) => DomainManager.Item.GetElement_Carriers(carrierKey.Id).GetCaptureRateBonus())).Append(0).Max();

	public CarrierMaxProperty GetCarrierMaxProperty => new CarrierMaxProperty
	{
		WorkingCarrierMaxInventoryLoadBonus = WorkingCarrierMaxInventoryLoadBonus,
		WorkingCarrierKidnapMaxSlotCount = WorkingCarrierKidnapMaxSlotCount,
		WorkingCarrierTimeBonus = WorkingCarrierTimeBonus,
		WorkingCarrierDropBonus = WorkingCarrierDropBonus,
		WorkingCarrierExploreBonusRate = WorkingCarrierExploreBonusRate,
		WorkingCarrierCaptureRateBonus = WorkingCarrierCaptureRateBonus
	};

	public bool IsOverweight
	{
		get
		{
			if (DomainManager.Taiwu.AtPastTaiwuVillage())
			{
				return false;
			}
			return GetCurrInventoryLoad() > GetMaxInventoryLoad();
		}
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 65 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 25 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private short CalcPhysiologicalAge()
	{
		short age = _currAge;
		return (short)DomainManager.SpecialEffect.ModifyData(_id, -1, 25, age);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 8 }, Scope = InfluenceScope.Self)]
	private uint CalcDarkAshProtector()
	{
		ECharacterFeatureDarkAshProtector value = ((_organizationInfo.OrgTemplateId == 16) ? ECharacterFeatureDarkAshProtector.IsTaiwu : ECharacterFeatureDarkAshProtector.None);
		if (IsNaturalDeathForbidden())
		{
			value |= ECharacterFeatureDarkAshProtector.Protected;
		}
		foreach (short featureId in _featureIds)
		{
			value |= CharacterFeature.Instance[featureId].DarkAshProtector;
		}
		return (uint)value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 8, 41, 17 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(1, new ushort[] { 26 })]
	private sbyte CalcFame()
	{
		CharacterItem template = Config.Character.Instance[_templateId];
		if (_creatingType != 1)
		{
			return template.PresetFame;
		}
		var (valueGood, valueBad) = SharedMethods.GetFame(_featureIds, _fameActionRecords, _organizationInfo, DomainManager.World.GetCurrDate(), IsTaiwu());
		return (sbyte)Math.Clamp(valueGood - valueBad, -100, 100);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 7, 55 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(4, new ushort[] { 24, 23 })]
	private short CalcMorality()
	{
		short fixedMorality = GetFixedMorality();
		return (fixedMorality != short.MaxValue) ? fixedMorality : Math.Clamp(_baseMorality, (short)(-500), (short)500);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 65, 75, 39, 60 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[ObjectCollectionDependency(6, 3, new ushort[] { 4 }, Scope = InfluenceScope.CharWhoEquippedTheItem, Condition = InfluenceCondition.ItemIsEquipped)]
	private short CalcAttraction()
	{
		if (GetAgeGroup() != 2)
		{
			return GlobalConfig.Instance.ImmaturityAttraction;
		}
		int value = CalcAvatarAttraction();
		value *= CalcPropertyModify(ECharacterPropertyReferencedType.Attraction);
		if (!IsCreatedWithFixedTemplate())
		{
			ItemKey key = _equipment[4];
			if (!key.IsValid() || DomainManager.Item.GetBaseItem(key).IsDurabilityRunningOut())
			{
				value /= 2;
			}
		}
		return (short)Math.Clamp(value, 0, 900);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 18, 75, 116 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 1, 2, 3, 4, 5, 6, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(9, new ushort[] { 12 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 147 }, Scope = InfluenceScope.TaiwuChar)]
	private unsafe MainAttributes CalcMaxMainAttributes()
	{
		MainAttributes value = _baseMainAttributes;
		short physiologicalAge = GetPhysiologicalAge();
		short clampedAge = GetClampedAgeOfAgeEffect(physiologicalAge);
		MainAttributes ageInfluence = AgeEffect.Instance[clampedAge].MainAttributes;
		for (int i = 0; i < 6; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(0 + i);
			ushort fieldId = (ushort)(1 + i);
			CValueModify modify = CalcPropertyModify(propertyType);
			modify += DomainManager.SpecialEffect.GetModify(_id, fieldId);
			value[i] = (short)Math.Clamp(value.Items[i] * modify * (CValuePercent)ageInfluence[i], GlobalConfig.Instance.MinValueOfMaxMainAttributes, GlobalConfig.Instance.MaxValueOfMaxMainAttributes);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 79, 111, 114, 28, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 32, 33, 34, 35, 36, 37, 236, 276, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147, 66 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	private unsafe HitOrAvoidInts CalcHitValues()
	{
		HitOrAvoidInts value = Template.BaseHitValues;
		BoolArray8 canAdd = default(BoolArray8);
		BoolArray8 canReduce = default(BoolArray8);
		Span<int> addEffectBonus = stackalloc int[4];
		Span<int> reduceEffectBonus = stackalloc int[4];
		for (int hitType = 0; hitType < 4; hitType++)
		{
			canAdd[hitType] = DomainManager.SpecialEffect.ModifyData(_id, -1, 36, dataValue: true, hitType, 0);
			canReduce[hitType] = DomainManager.SpecialEffect.ModifyData(_id, -1, 36, dataValue: true, hitType, 1);
			addEffectBonus[hitType] = DomainManager.SpecialEffect.GetModifyValue(_id, 37, EDataModifyType.Add, hitType, 0);
			reduceEffectBonus[hitType] = DomainManager.SpecialEffect.GetModifyValue(_id, 37, EDataModifyType.Add, hitType, 1);
		}
		for (int i = 0; i < 4; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(6 + i);
			EDataSumType sumType = DataSumTypeHelper.CalcSumType(canAdd[i], canReduce[i]);
			CValueModify modify = CalcPropertyModify(propertyType, sumType);
			ushort fieldId = (ushort)(32 + i);
			if (canAdd[i])
			{
				modify += DomainManager.SpecialEffect.GetModify(_id, fieldId, -1, -1, -1, EDataSumType.OnlyAdd) * (CValuePercentBonus)addEffectBonus[i];
			}
			if (canReduce[i])
			{
				modify += DomainManager.SpecialEffect.GetModify(_id, fieldId, -1, -1, -1, EDataSumType.OnlyReduce) * (CValuePercentBonus)reduceEffectBonus[i];
			}
			value[i] *= modify;
		}
		Span<int> tempValueAdd = stackalloc int[4];
		tempValueAdd.Fill(0);
		for (sbyte hitType2 = 0; hitType2 < 4; hitType2++)
		{
			int addValue = DomainManager.SpecialEffect.GetModifyValue(_id, 276, EDataModifyType.Add, hitType2, value.Items[hitType2]);
			for (sbyte type = 0; type < 4; type++)
			{
				if (type != hitType2)
				{
					tempValueAdd[type] += addValue;
				}
			}
		}
		for (sbyte hitType3 = 0; hitType3 < 4; hitType3++)
		{
			if (canAdd[hitType3])
			{
				ref int reference = ref value.Items[hitType3];
				reference += tempValueAdd[hitType3];
			}
		}
		for (sbyte hitType4 = 0; hitType4 < 4; hitType4++)
		{
			value.Items[hitType4] = DomainManager.SpecialEffect.ModifyData(_id, -1, (ushort)(32 + hitType4), value.Items[hitType4]);
		}
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].HitValues;
			for (int j = 0; j < 4; j++)
			{
				value.Items[j] = value.Items[j] * factor / 100;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (value.Items[k] < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
			{
				value.Items[k] = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
			}
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 79, 111, 114, 28, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 44, 45, 238, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(4, new ushort[] { 46 }, Scope = InfluenceScope.AllFixedCharsAffectedByXiangshuInfectedDemons)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	private OuterAndInnerInts CalcPenetrations()
	{
		CharacterItem template = Config.Character.Instance[_templateId];
		OuterAndInnerInts value = template.BasePenetrations;
		CValueModify modifyOuter = CalcPropertyModify(ECharacterPropertyReferencedType.PenetrateOfOuter);
		modifyOuter += DomainManager.SpecialEffect.GetModify(_id, 44);
		value.Outer *= modifyOuter;
		CValueModify modifyInner = CalcPropertyModify(ECharacterPropertyReferencedType.PenetrateOfInner);
		modifyInner += DomainManager.SpecialEffect.GetModify(_id, 45);
		value.Inner *= modifyInner;
		value.Outer = DomainManager.SpecialEffect.ModifyData(_id, -1, 44, value.Outer);
		value.Inner = DomainManager.SpecialEffect.ModifyData(_id, -1, 45, value.Inner);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].Penetrations;
			value.Outer = value.Outer * factor / 100;
			value.Inner = value.Inner * factor / 100;
		}
		if (value.Outer < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
		{
			value.Outer = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
		}
		if (value.Inner < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
		{
			value.Inner = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 79, 111, 114, 28, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 38, 39, 40, 41, 42, 43, 237, 277, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147, 66 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	private unsafe HitOrAvoidInts CalcAvoidValues()
	{
		HitOrAvoidInts value = Template.BaseAvoidValues;
		BoolArray8 canAdd = default(BoolArray8);
		BoolArray8 canReduce = default(BoolArray8);
		Span<int> addEffectBonus = stackalloc int[4];
		Span<int> reduceEffectBonus = stackalloc int[4];
		for (int hitType = 0; hitType < 4; hitType++)
		{
			canAdd[hitType] = DomainManager.SpecialEffect.ModifyData(_id, -1, 42, dataValue: true, hitType, 0);
			canReduce[hitType] = DomainManager.SpecialEffect.ModifyData(_id, -1, 42, dataValue: true, hitType, 1);
			addEffectBonus[hitType] = DomainManager.SpecialEffect.GetModifyValue(_id, 43, EDataModifyType.Add, hitType, 0);
			reduceEffectBonus[hitType] = DomainManager.SpecialEffect.GetModifyValue(_id, 43, EDataModifyType.Add, hitType, 1);
		}
		for (int i = 0; i < 4; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(12 + i);
			EDataSumType sumType = DataSumTypeHelper.CalcSumType(canAdd[i], canReduce[i]);
			CValueModify modify = CalcPropertyModify(propertyType, sumType);
			ushort fieldId = (ushort)(38 + i);
			if (canAdd[i])
			{
				modify += DomainManager.SpecialEffect.GetModify(_id, fieldId, -1, -1, -1, EDataSumType.OnlyAdd) * (CValuePercentBonus)addEffectBonus[i];
			}
			if (canReduce[i])
			{
				modify += DomainManager.SpecialEffect.GetModify(_id, fieldId, -1, -1, -1, EDataSumType.OnlyReduce) * (CValuePercentBonus)reduceEffectBonus[i];
			}
			value[i] *= modify;
		}
		Span<int> tempValueAdd = stackalloc int[4];
		tempValueAdd.Fill(0);
		for (sbyte hitType2 = 0; hitType2 < 4; hitType2++)
		{
			int addValue = DomainManager.SpecialEffect.GetModifyValue(_id, 277, EDataModifyType.Add, hitType2, value.Items[hitType2]);
			for (sbyte type = 0; type < 4; type++)
			{
				if (type != hitType2)
				{
					tempValueAdd[type] += addValue;
				}
			}
		}
		for (sbyte hitType3 = 0; hitType3 < 4; hitType3++)
		{
			if (canAdd[hitType3])
			{
				ref int reference = ref value.Items[hitType3];
				reference += tempValueAdd[hitType3];
			}
		}
		for (sbyte hitType4 = 0; hitType4 < 4; hitType4++)
		{
			value.Items[hitType4] = DomainManager.SpecialEffect.ModifyData(_id, -1, (ushort)(38 + hitType4), value.Items[hitType4]);
		}
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].AvoidValues;
			for (int j = 0; j < 4; j++)
			{
				value.Items[j] = value.Items[j] * factor / 100;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (value.Items[k] < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
			{
				value.Items[k] = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
			}
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 79, 111, 114, 28, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 46, 47, 239, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	[ObjectCollectionDependency(8, 10, new ushort[] { 46 }, Scope = InfluenceScope.CharOfTheCombatChar)]
	private OuterAndInnerInts CalcPenetrationResists()
	{
		OuterAndInnerInts value = Template.BasePenetrationResists;
		CValueModify modifyOuter = CalcPropertyModify(ECharacterPropertyReferencedType.PenetrateResistOfOuter);
		modifyOuter += DomainManager.SpecialEffect.GetModify(_id, 46);
		value.Outer *= modifyOuter;
		CValueModify modifyInner = CalcPropertyModify(ECharacterPropertyReferencedType.PenetrateResistOfInner);
		modifyInner += DomainManager.SpecialEffect.GetModify(_id, 47);
		value.Inner *= modifyInner;
		if (DomainManager.Combat.IsCharInCombat(_id))
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(_id);
			PoisonInts poisons = combatChar.GetPoison();
			CValuePercentBonus outerBonus = 0;
			CValuePercentBonus innerBonus = 0;
			sbyte rottenLevel = PoisonsAndLevels.CalcPoisonedLevel(poisons[4]);
			if (rottenLevel > 0)
			{
				outerBonus = -rottenLevel * Poison.Instance[(sbyte)4].ReduceOuterResist;
			}
			sbyte illusoryLevel = PoisonsAndLevels.CalcPoisonedLevel(poisons[5]);
			if (illusoryLevel > 0)
			{
				innerBonus = -illusoryLevel * Poison.Instance[(sbyte)5].ReduceInnerResist;
			}
			value.Outer *= outerBonus;
			value.Inner *= innerBonus;
		}
		value.Outer = DomainManager.SpecialEffect.ModifyData(_id, -1, 46, value.Outer);
		value.Inner = DomainManager.SpecialEffect.ModifyData(_id, -1, 47, value.Inner);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].PenetrationResists;
			value.Outer = value.Outer * factor / 100;
			value.Inner = value.Inner * factor / 100;
		}
		if (value.Outer < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
		{
			value.Outer = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
		}
		if (value.Inner < GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes)
		{
			value.Inner = GlobalConfig.Instance.MinValueOfAttackAndDefenseAttributes;
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 7, 8, 17, 18, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private OuterAndInnerShorts CalcRecoveryOfStanceAndBreath()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return new OuterAndInnerShorts(fixValue, fixValue);
		}
		OuterAndInnerInts value = Template.BaseRecoveryOfStanceAndBreath;
		CValueModify modifyOuter = CalcPropertyModify(ECharacterPropertyReferencedType.RecoveryOfStance);
		modifyOuter = (modifyOuter + DomainManager.SpecialEffect.GetModify(_id, 7)).MaxA(value.Outer, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value.Outer *= modifyOuter;
		CValueModify modifyInner = CalcPropertyModify(ECharacterPropertyReferencedType.RecoveryOfBreath);
		modifyInner = (modifyInner + DomainManager.SpecialEffect.GetModify(_id, 8)).MaxA(value.Inner, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value.Inner *= modifyInner;
		value.Outer = (short)DomainManager.SpecialEffect.ModifyData(_id, -1, 7, value.Outer);
		value.Inner = (short)DomainManager.SpecialEffect.ModifyData(_id, -1, 8, value.Inner);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			OuterAndInnerShorts factor = Config.CombatDifficulty.Instance[combatDifficulty].RecoveryOfStanceAndBreath;
			value.Outer = (short)(value.Outer * factor.Outer / 100);
			value.Inner = (short)(value.Inner * factor.Inner / 100);
		}
		value.Outer = Math.Clamp(value.Outer, 0, 1000);
		value.Inner = Math.Clamp(value.Inner, 0, 1000);
		return (OuterAndInnerShorts)value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(8, 10, new ushort[] { 62 }, Scope = InfluenceScope.CharOfTheCombatChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 9, 55, 17, 18, 278, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcMoveSpeed()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseMoveSpeed;
		bool canAdd = DomainManager.SpecialEffect.ModifyData(_id, -1, 55, dataValue: true, 0);
		bool canReduce = DomainManager.SpecialEffect.ModifyData(_id, -1, 55, dataValue: true, 1);
		EDataSumType sumType = DataSumTypeHelper.CalcSumType(canAdd, canReduce);
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.MoveSpeed, sumType);
		modify += DomainManager.SpecialEffect.GetModify(_id, 9, -1, -1, -1, sumType);
		if (DomainManager.Combat.IsCharInCombat(_id) && canAdd)
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(_id);
			short agileSkillId = combatChar.GetAffectingMoveSkillId();
			if (agileSkillId >= 0)
			{
				GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_id, agileSkillId));
				modify = modify.ChangeA(CombatSkillDomain.CalcCastAddMoveSpeed(skill, skill.GetPower())).ChangeB(CombatSkillDomain.CalcCastAddPercentMoveSpeed(skill, skill.GetPower()));
			}
		}
		modify = modify.MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipLoadSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 9, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].MoveSpeed;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 10, 17, 18, 292, 278 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcRecoveryOfFlaw()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseRecoveryOfFlaw;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.RecoveryOfFlaw);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 10)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipHealSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 10, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].RecoveryOfFlaw;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 11, 278, 17, 18, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcCastSpeed()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseCastSpeed;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.CastSpeed);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 11)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipLoadSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 11, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].CastSpeed;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 12, 17, 18, 292, 278 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcRecoveryOfBlockedAcupoint()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseRecoveryOfBlockedAcupoint;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 12)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipHealSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 12, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].RecoveryOfBlockedAcupoint;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 13, 17, 18, 292, 278 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcWeaponSwitchSpeed()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseWeaponSwitchSpeed;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.WeaponSwitchSpeed);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 13)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipHealSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 13, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].WeaponSwitchSpeed;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 106, 105, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 14, 278, 17, 18, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 29 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcAttackSpeed()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseAttackSpeed;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.AttackSpeed);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 14)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = CalcOverloadBonus(value, GlobalConfig.Instance.EquipLoadSpeedPercent);
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 14, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].AttackSpeed;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 15, 17, 18, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcInnerRatio()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseInnerRatio;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.InnerRatio);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 15)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 15, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].InnerRatio;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 55, 67, 8 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(1, new ushort[] { 14 })]
	[ObjectCollectionDependency(17, 2, new ushort[] { 16, 17, 18, 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueDependency(19, new ushort[] { 28, 29, 147 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcRecoveryOfQiDisorder()
	{
		if (TryGetFixedSubAttributeValue(out var fixValue))
		{
			return fixValue;
		}
		int value = Template.BaseRecoveryOfQiDisorder;
		CValueModify modify = CalcPropertyModify(ECharacterPropertyReferencedType.RecoveryOfQiDisorder);
		modify = (modify + DomainManager.SpecialEffect.GetModify(_id, 16)).MaxA(value, GlobalConfig.Instance.MinAValueOfMinorAttributes);
		value *= modify;
		if (IsActiveExternalRelationState(32uL) && DomainManager.Organization.GetPrisonerSect(_id) == 4)
		{
			value /= 2;
		}
		value = DomainManager.SpecialEffect.ModifyData(_id, -1, 16, value);
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			short factor = Config.CombatDifficulty.Instance[combatDifficulty].RecoveryOfQiDisorder;
			value = value * factor / 100;
		}
		return (short)Math.Clamp(value, 0, 1000);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 60, 111, 114, 21, 74 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 2, 4, 9 }, Scope = InfluenceScope.CombatSkillOwner)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	[ElementListDependency(5, 15, 9, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 19, 20, 21, 22, 23, 24, 245 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private PoisonInts CalcPoisonResists()
	{
		CharacterItem template = Config.Character.Instance[_templateId];
		PoisonInts value = template.BasePoisonResists;
		CValueModify allModify = DomainManager.SpecialEffect.GetModify(_id, 245);
		sbyte disorderLevelOfQi = DisorderLevelOfQi.GetDisorderLevelOfQi(_disorderOfQi);
		allModify = allModify.ChangeC(QiDisorderEffect.Instance[disorderLevelOfQi].PoisonResistChange);
		if (DomainManager.Combat.IsInCombat() && DomainManager.Combat.TryGetElement_CombatCharacterDict(_id, out var combatChar))
		{
			int addValue = 0;
			foreach (CombatCharacter enemyChar in DomainManager.Combat.GetCharacters(!combatChar.IsAlly))
			{
				foreach (short featureId in enemyChar.GetCharacter().GetFeatureIds())
				{
					addValue -= CharacterFeature.Instance[featureId].InCombatEnemyAllPoisonResistReduceValue;
				}
			}
			if (addValue != 0)
			{
				allModify = allModify.ChangeA(addValue);
			}
		}
		int blackBloodModify = GetBlackBloodWugKingPoisonResistModify();
		for (int i = 0; i < 6; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(28 + i);
			ushort fieldId = (ushort)(19 + i);
			CValueModify modify = CalcPropertyModify(propertyType);
			modify += DomainManager.SpecialEffect.GetModify(_id, fieldId);
			modify = (modify + allModify).ReverseByValue(value[i]);
			value[i] *= modify;
			value[i] += blackBloodModify;
		}
		return value;
	}

	private int GetBlackBloodWugKingPoisonResistModify()
	{
		if (!IsWugKingDriveActive(2, DomainManager.World.GetCurrDate(), 6))
		{
			return 0;
		}
		if (!TryGetWugKingDriveData(2, out var driveData))
		{
			return 0;
		}
		return (driveData.DriveType == 1) ? 500 : (-500);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 20 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 53 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	[SingleValueCollectionDependency(19, new ushort[] { 146 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcMaxHealth()
	{
		int value = _baseMaxHealth * CalcPropertyModify(ECharacterPropertyReferencedType.MaxHealth);
		value += DomainManager.SpecialEffect.GetModifyValue(_id, 53, EDataModifyType.Add);
		if (IsTaiwu())
		{
			value += ProfessionSkillHandle.TravelingTaoistMonkSkill_GetMaxHealthBonus();
		}
		return (short)Math.Clamp(value, 0, 32767);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 75, 44, 93, 58, 60 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(20, new ushort[] { 3 }, Scope = InfluenceScope.TaiwuChar)]
	private short CalcFertility()
	{
		int value = 100;
		value *= CalcPropertyModify(ECharacterPropertyReferencedType.Fertility);
		short physiologicalAge = GetPhysiologicalAge();
		short clampedAge = GetClampedAgeOfAgeEffect(physiologicalAge);
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		value += ((_gender == 1) ? ageEffectCfg.FertilityMale : ageEffectCfg.FertilityFemale);
		value -= GetMixedPoisonTypeRelatedMarkCount(25) * 30;
		return (short)Math.Clamp(value, 0, 32767);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 30, 31, 62, 4 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(9, new ushort[] { 14 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private LifeSkillShorts CalcLifeSkillQualifications()
	{
		LifeSkillShorts value = _baseLifeSkillQualifications;
		short clampedAge = QualificationAge;
		for (int i = 0; i < 16; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(34 + i);
			CValueModify modify = CalcPropertyModify(propertyType);
			int tempValue = value[i] * modify;
			if (clampedAge < 16)
			{
				tempValue = tempValue * clampedAge / 16;
			}
			value[i] = (short)Math.Clamp(tempValue, 0, 32767);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 29, 96, 55, 8 }, Scope = InfluenceScope.Self)]
	private LifeSkillShorts CalcLifeSkillAttainments()
	{
		LifeSkillShorts value = default(LifeSkillShorts);
		value.Initialize();
		GetLifeSkillBaseAttainment(ref value);
		GetLifeSkillAttainmentAddOns(ref value);
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 32, 33, 62, 4 }, Scope = InfluenceScope.Self)]
	[SingleValueDependency(5, new ushort[] { 0 })]
	[SingleValueDependency(9, new ushort[] { 13 }, Scope = InfluenceScope.TaiwuChar)]
	[ElementListDependency(11, 0, 14)]
	[SingleValueDependency(19, new ushort[] { 28, 29 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 292 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private CombatSkillShorts CalcCombatSkillQualifications()
	{
		CombatSkillShorts value = _baseCombatSkillQualifications;
		short clampedAge = QualificationAge;
		for (int i = 0; i < 14; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(66 + i);
			CValueModify modify = CalcPropertyModify(propertyType);
			int tempValue = value[i] * modify;
			if (clampedAge < 16)
			{
				tempValue = tempValue * clampedAge / 16;
			}
			value[i] = (short)Math.Clamp(tempValue, 0, 32767);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 61, 98, 8 }, Scope = InfluenceScope.Self)]
	private unsafe CombatSkillShorts CalcCombatSkillAttainments()
	{
		CombatSkillShorts value = default(CombatSkillShorts);
		value.Initialize();
		CombatSkillShorts bonuses = default(CombatSkillShorts);
		bonuses.Initialize();
		for (int skillType = 0; skillType < 14; skillType++)
		{
			for (int grade = 0; grade < 9; grade++)
			{
				int offset = 9 * skillType + grade;
				short skillTemplateId = _combatSkillAttainmentPanels[offset];
				if (skillTemplateId >= 0)
				{
					CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
					ref short reference = ref value.Items[skillType];
					reference += GlobalConfig.Instance.AddAttainmentPerGrade[skillConfig.Grade];
				}
			}
		}
		ref CombatSkillShorts qualifications = ref GetCombatSkillQualifications();
		for (int i = 0; i < 14; i++)
		{
			int qualification = DomainManager.World.ApplyChallengeModeAttainment(qualifications.Items[i]);
			value.Items[i] = (short)(qualification * (100 + value.Items[i]) / 100 + value.Items[i]);
		}
		for (int j = 0; j < 14; j++)
		{
			int currValue = value.Items[j] + bonuses.Items[j];
			value.Items[j] = (short)((currValue >= 0) ? currValue : 0);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 56, 58, 55, 8 }, Scope = InfluenceScope.Self)]
	[SingleValueCollectionDependency(19, new ushort[] { 132 }, Scope = InfluenceScope.AllCharsInTaiwuVillage)]
	[SingleValueCollectionDependency(9, new ushort[] { 7 }, Scope = InfluenceScope.AllCharsInTaiwuVillage)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 302 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private Personalities CalcPersonalities()
	{
		Personalities value = default(Personalities);
		CValueModify allModify = DomainManager.SpecialEffect.GetModify(_id, 302);
		for (int i = 0; i < 7; i++)
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(94 + i);
			CValueModify modify = CalcPropertyModify(propertyType) + allModify;
			int personality = 10 * modify;
			value[i] = (sbyte)Math.Clamp(personality, 0, 100);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17 }, Scope = InfluenceScope.Self)]
	private sbyte CalcHobbyChangingPeriod()
	{
		int value = GlobalConfig.Instance.BaseHobbyChangingPeriod;
		value *= CalcPropertyModify(ECharacterPropertyReferencedType.HobbyChangingPeriod);
		return (sbyte)((value < 1) ? 1 : value);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 17, 55 }, Scope = InfluenceScope.Self)]
	private OuterAndInnerShorts CalcFavorabilityChangingFactor()
	{
		OuterAndInnerShorts value = new OuterAndInnerShorts(100, 100);
		foreach (short featureId in _featureIds)
		{
			if (!HideAndDisableFeature(featureId))
			{
				CharacterFeatureItem config = CharacterFeature.Instance[featureId];
				value.Outer = (short)(value.Outer * config.FavorabilityIncrementFactor / 100);
				value.Inner = (short)(value.Inner * config.FavorabilityDecrementFactor / 100);
			}
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 56 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(6, 4, new ushort[] { 4 }, Scope = InfluenceScope.CharWhoEquippedTheItem, Condition = InfluenceCondition.ItemIsEquipped)]
	private int CalcMaxInventoryLoad()
	{
		int value = 3000;
		value += WorkingCarrierMaxInventoryLoadBonus;
		for (sbyte i = 14; i <= 16; i++)
		{
			ItemKey itemKey = _equipment[i];
			if (itemKey.IsValid())
			{
				EquipmentBase equipment = DomainManager.Item.GetBaseEquipment(itemKey);
				if (equipment.GetMaxDurability() == 0 || equipment.GetCurrDurability() > 0)
				{
					AccessoryItem config = Config.Accessory.Instance[itemKey.TemplateId];
					value += config.MaxInventoryLoadBonus;
				}
			}
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 57, 56 }, Scope = InfluenceScope.Self)]
	private int CalcCurrInventoryLoad()
	{
		int value = 0;
		foreach (KeyValuePair<ItemKey, int> item3 in _inventory.Items)
		{
			item3.Deconstruct(out var key, out var value2);
			ItemKey itemKey = key;
			int amount = value2;
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
			value += item.GetWeight() * amount;
		}
		for (int i = 0; i < 11; i++)
		{
			ItemKey itemKey2 = _equipment[i];
			if (itemKey2.IsValid())
			{
				ItemBase item2 = DomainManager.Item.GetBaseItem(itemKey2);
				value += item2.GetWeight();
			}
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 79 }, Scope = InfluenceScope.Self)]
	private unsafe int CalcMaxEquipmentLoad()
	{
		short maxStrength = GetMaxMainAttributes().Items[0];
		int extraLoad = Config.Character.Instance[_templateId].ExtraEquipmentLoad;
		return GlobalConfig.Instance.EquipmentLoadBaseValue + maxStrength * GlobalConfig.Instance.StrengthToEquipmentLoadFactor + extraLoad;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 56 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 309 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private int CalcCurrEquipmentLoad()
	{
		return (from i in Enumerable.Range(0, 11).Concat(Enumerable.Range(14, 3))
			select _equipment[i] into itemKey
			where itemKey.IsValid()
			select itemKey).Sum((ItemKey itemKey) => DomainManager.SpecialEffect.ModifyValue(_id, 309, DomainManager.Item.GetBaseItem(itemKey).GetWeight(), itemKey.Id, itemKey.ItemType));
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 57 }, Scope = InfluenceScope.Self)]
	private int CalcInventoryTotalValue()
	{
		int totalValue = 0;
		foreach (var (itemKey2, itemAmount) in _inventory.Items)
		{
			if (itemKey2.ItemType != 10)
			{
				totalValue += DomainManager.Item.GetValue(itemKey2) * itemAmount;
			}
		}
		return totalValue;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 27, 59, 47 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 7, 6 }, Scope = InfluenceScope.CombatSkillOwner)]
	[SingleValueCollectionDependency(5, new ushort[] { 78 }, Scope = InfluenceScope.TaiwuChar)]
	[SingleValueCollectionDependency(19, new ushort[] { 153 }, Scope = InfluenceScope.TaiwuAndGearMates)]
	private unsafe int CalcMaxNeili()
	{
		int value = GetPureMaxNeili();
		for (int type = 0; type < 4; type++)
		{
			value -= CombatHelper.CalcNeiliCostFromZero(_baseNeiliAllocation.Items[type]);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 47, 48, 1 }, Scope = InfluenceScope.Self)]
	private unsafe NeiliAllocation CalcNeiliAllocation()
	{
		NeiliAllocation value = _baseNeiliAllocation;
		for (int i = 0; i < 4; i++)
		{
			int currAllocation = value.Items[i] + _extraNeiliAllocation.Items[i];
			value.Items[i] = (short)((currAllocation >= 0) ? currAllocation : 0);
		}
		return value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 49 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(8, 10, new ushort[] { 118 }, Scope = InfluenceScope.CharOfTheCombatChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	[ObjectCollectionDependency(17, 2, new ushort[] { 26 }, Scope = InfluenceScope.CharacterAffectedByTheSpecialEffects)]
	private NeiliProportionOfFiveElements CalcNeiliProportionOfFiveElements()
	{
		NeiliProportionOfFiveElements proportions = _baseNeiliProportionOfFiveElements;
		proportions = DomainManager.SpecialEffect.ModifyData(_id, -1, 26, proportions);
		if (DomainManager.Combat.IsCharInCombat(_id))
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(_id);
			NeiliProportionOfFiveElements delta = combatChar.GetProportionDelta();
			Tester.Assert(delta.Sum() == 0, "delta.Sum() == 0");
			for (int i = 0; i < 5; i++)
			{
				proportions[i] += delta[i];
			}
		}
		Tester.Assert(proportions.SumCheck() == 100);
		return proportions;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 110 }, Scope = InfluenceScope.Self)]
	private sbyte CalcNeiliType()
	{
		return GetNeiliProportionOfFiveElements().GetNeiliType(_birthMonth);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 109 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(8, 10, new ushort[] { 3 }, Scope = InfluenceScope.CharOfTheCombatChar)]
	[SingleValueDependency(8, new ushort[] { 19 }, Scope = InfluenceScope.AllCharsInCombat)]
	private unsafe NeiliAllocation CalcAllocatedNeiliEffects()
	{
		NeiliAllocation value = default(NeiliAllocation);
		NeiliAllocation neiliAllocation = GetNeiliAllocation();
		NeiliAllocation neiliAllocationInCombat = (DomainManager.Combat.IsCharInCombat(_id) ? DomainManager.Combat.GetElement_CombatCharacterDict(_id).GetNeiliAllocation() : neiliAllocation);
		for (sbyte i = 0; i < 4; i++)
		{
			value.Items[i] = (short)(neiliAllocationInCombat.Items[i] * GlobalConfig.Instance.AllocatedNeiliEffectPercent / 100);
		}
		return value;
	}

	[SingleValueDependency(11, new ushort[] { 0 })]
	[ObjectCollectionDependency(4, 0, new ushort[]
	{
		60, 109, 28, 79, 80, 81, 82, 83, 84, 85,
		86, 87, 88, 89, 90, 91, 92, 96, 97, 98,
		99, 56, 26, 44, 93
	}, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 13 }, Scope = InfluenceScope.CombatSkillOwner)]
	private unsafe int CalcCombatPower()
	{
		int value = 0;
		value += _consummateLevel * 1000;
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		int bonus = 0;
		for (int i = 0; i < 6; i++)
		{
			bonus += maxMainAttributes.Items[i];
		}
		value += bonus * 3;
		int bonus2 = 0;
		HitOrAvoidInts hitValues = GetHitValues();
		for (int j = 0; j < 4; j++)
		{
			bonus2 += hitValues.Items[j];
		}
		OuterAndInnerInts penetrations = GetPenetrations();
		bonus2 += penetrations.Outer + penetrations.Inner;
		value += bonus2;
		int bonus3 = 0;
		HitOrAvoidInts avoidValues = GetAvoidValues();
		for (int k = 0; k < 4; k++)
		{
			bonus3 += avoidValues.Items[k];
		}
		OuterAndInnerInts penetrationResists = GetPenetrationResists();
		bonus3 += penetrationResists.Outer + penetrationResists.Inner;
		value += bonus3;
		OuterAndInnerShorts recoveryOfStanceAndBreath = GetRecoveryOfStanceAndBreath();
		value += (recoveryOfStanceAndBreath.Outer + recoveryOfStanceAndBreath.Inner + GetMoveSpeed() + GetRecoveryOfFlaw() + GetCastSpeed() + GetRecoveryOfBlockedAcupoint() + GetWeaponSwitchSpeed() + GetAttackSpeed() + GetInnerRatio() + GetRecoveryOfQiDisorder() - 1000) * 5;
		int bonus4 = 0;
		int bonus5 = 0;
		int bonus6 = 0;
		for (int l = 0; l < 16; l++)
		{
			short val = _lifeSkillAttainments.Items[l];
			if (val > bonus4)
			{
				bonus6 = bonus5;
				bonus5 = bonus4;
				bonus4 = val;
			}
			else if (val > bonus5)
			{
				bonus6 = bonus5;
				bonus5 = val;
			}
			else if (val > bonus6)
			{
				bonus6 = val;
			}
		}
		value += (bonus4 + bonus5 + bonus6) * 20;
		int bonus7 = 0;
		int bonus8 = 0;
		int bonus9 = 0;
		for (int m = 0; m < 14; m++)
		{
			short val2 = _combatSkillAttainments.Items[m];
			if (val2 > bonus7)
			{
				bonus9 = bonus8;
				bonus8 = bonus7;
				bonus7 = val2;
			}
			else if (val2 > bonus8)
			{
				bonus9 = bonus8;
				bonus8 = val2;
			}
			else if (val2 > bonus9)
			{
				bonus9 = val2;
			}
		}
		value += (bonus7 + bonus8 + bonus9) * 40;
		value += GetEquipmentCombatPowerValue();
		int defeatMarksCount = CombatDomain.GetDefeatMarksCountOutOfCombat(this);
		byte defeatMarksMaxCount = GlobalConfig.NeedDefeatMarkCount[2];
		int defeatRate = defeatMarksCount * 100 / defeatMarksMaxCount;
		if (DomainManager.LegendaryBook.GetCharOwnedBookTypes(_id) != null)
		{
			defeatRate /= 2;
		}
		value -= value * defeatRate / 100;
		return (value >= 0) ? value : 0;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 60, 91 }, Scope = InfluenceScope.Self)]
	[ObjectCollectionDependency(7, 0, new ushort[] { 14 }, Scope = InfluenceScope.CombatSkillOwner)]
	private sbyte CalcAttackTendencyOfInnerAndOuter()
	{
		int value = 0;
		int attackSkillsCount = 0;
		ArraySegmentList<short> attackSkills = GetCombatSkillEquipment().Attack;
		int i = 0;
		for (int count = attackSkills.Count; i < count; i++)
		{
			short skillTemplateId = attackSkills[i];
			if (skillTemplateId >= 0)
			{
				CombatSkillKey key = new CombatSkillKey(_id, skillTemplateId);
				GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(key);
				value += combatSkill.GetCurrInnerRatio();
				attackSkillsCount++;
			}
		}
		if (attackSkillsCount > 0)
		{
			value /= attackSkillsCount;
		}
		return (sbyte)value;
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 61 }, Scope = InfluenceScope.Self)]
	private sbyte CalcMaxConsummateLevel()
	{
		int maxConsummateLevel = -1;
		short[] combatSkillAttainmentPanels = GetCombatSkillAttainmentPanels();
		for (sbyte skillType = 0; skillType < 14; skillType++)
		{
			int totalCount = 0;
			int lowPoint = 0;
			int middlePoint = 0;
			int highPoint = 0;
			for (sbyte grade = 0; grade <= 8; grade++)
			{
				int offset = 9 * skillType + grade;
				short skillTemplateId = combatSkillAttainmentPanels[offset];
				if (skillTemplateId >= 0)
				{
					if (grade != 0)
					{
						totalCount++;
					}
					int point = GlobalConfig.Instance.ConsummateLevelPoints[grade];
					switch (Grade.GetGroup(grade))
					{
					case 0:
						lowPoint = Math.Max(point, lowPoint);
						break;
					case 1:
						middlePoint = Math.Max(point, middlePoint);
						break;
					case 2:
						highPoint = Math.Max(point, highPoint);
						break;
					}
				}
			}
			totalCount += (lowPoint + middlePoint + highPoint) / 10;
			if (maxConsummateLevel < totalCount)
			{
				maxConsummateLevel = totalCount;
			}
		}
		return (sbyte)Math.Clamp(maxConsummateLevel, 0, GlobalConfig.Instance.MaxConsummateLevel);
	}

	[ObjectCollectionDependency(4, 0, new ushort[] { 60 }, Scope = InfluenceScope.Self)]
	private void CalcCombatSkillEquipment(CombatSkillEquipment value)
	{
		if (DomainManager.Extra.TryGetCharacterEquippedCombatSkills(_id, out var combatSkillPlan))
		{
			value.Set(combatSkillPlan);
		}
		else
		{
			value.Set(_equippedCombatSkills);
		}
	}

	private static short GetClampedAgeOfAgeEffect(short age)
	{
		if (age < 0)
		{
			return 20;
		}
		if (age > 100)
		{
			return 100;
		}
		return age;
	}

	public bool CheckGoalComplete(DataContext context, CharacterGoalData goal)
	{
		context.PlanningAgent.Initialize(context, this, goal);
		return ((IGoal<Character, StateKey>)goal).IsComplete((IAgent<Character, StateKey>)context.PlanningAgent);
	}

	public IReadOnlyList<CharacterGoalData> GetGoals()
	{
		IReadOnlyList<CharacterGoalData> result;
		if (_actionPlanningData?.Goals != null)
		{
			IReadOnlyList<CharacterGoalData> goals = _actionPlanningData.Goals;
			result = goals;
		}
		else
		{
			IReadOnlyList<CharacterGoalData> goals = Array.Empty<CharacterGoalData>();
			result = goals;
		}
		return result;
	}

	public bool IsCurrentGoal(int templateId)
	{
		return GetGoal(templateId)?.IsCurrent ?? false;
	}

	public bool IsCurrentGoal(int templateId, PlanningContextArg arg0)
	{
		return GetGoal(templateId, arg0)?.IsCurrent ?? false;
	}

	public CharacterGoalData GetGoal(int templateId)
	{
		return ActionPlanningData.GetGoal(templateId);
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0)
	{
		return ActionPlanningData.GetGoal(templateId, arg0);
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		return ActionPlanningData.GetGoal(templateId, arg0, arg1);
	}

	public CharacterGoalData GetGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		return ActionPlanningData.GetGoal(templateId, arg0, arg1, arg2);
	}

	public void AddGoal(DataContext context, int templateId)
	{
		if (OfflineAddGoal(templateId))
		{
			SetActionPlanningModified(context);
		}
	}

	public void AddGoal(DataContext context, int templateId, PlanningContextArg arg0)
	{
		if (OfflineAddGoal(templateId, arg0))
		{
			SetActionPlanningModified(context);
		}
	}

	public void AddGoal(DataContext context, int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		if (OfflineAddGoal(templateId, arg0, arg1))
		{
			SetActionPlanningModified(context);
		}
	}

	public void AddGoal(DataContext context, int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		if (OfflineAddGoal(templateId, arg0, arg1, arg2))
		{
			SetActionPlanningModified(context);
		}
	}

	public bool OfflineAddGoal(int templateId)
	{
		return ActionPlanningData.AddGoal(templateId, DomainManager.World.GetCurrDate()) != null;
	}

	public bool OfflineAddGoal(int templateId, PlanningContextArg arg0)
	{
		return ActionPlanningData.AddGoal(templateId, DomainManager.World.GetCurrDate(), arg0) != null;
	}

	public bool OfflineAddGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		return ActionPlanningData.AddGoal(templateId, DomainManager.World.GetCurrDate(), arg0, arg1) != null;
	}

	public bool OfflineAddGoal(int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		return ActionPlanningData.AddGoal(templateId, DomainManager.World.GetCurrDate(), arg0, arg1, arg2) != null;
	}

	public void ClearGoals(DataContext context)
	{
		_actionPlanningData?.Goals?.Clear();
	}

	public CharacterGoalData RemoveGoal(DataContext context, int templateId)
	{
		CharacterGoalData removed = _actionPlanningData?.RemoveGoal(templateId);
		if (removed != null)
		{
			SetActionPlanningModified(context);
		}
		return removed;
	}

	public CharacterGoalData RemoveGoal(DataContext context, int templateId, PlanningContextArg arg0)
	{
		CharacterGoalData removed = _actionPlanningData?.RemoveGoal(templateId, arg0);
		if (removed != null)
		{
			SetActionPlanningModified(context);
		}
		return removed;
	}

	public CharacterGoalData RemoveGoal(DataContext context, int templateId, PlanningContextArg arg0, PlanningContextArg arg1)
	{
		CharacterGoalData removed = _actionPlanningData?.RemoveGoal(templateId, arg0, arg1);
		if (removed != null)
		{
			SetActionPlanningModified(context);
		}
		return removed;
	}

	public CharacterGoalData RemoveGoal(DataContext context, int templateId, PlanningContextArg arg0, PlanningContextArg arg1, PlanningContextArg arg2)
	{
		CharacterGoalData removed = _actionPlanningData?.RemoveGoal(templateId, arg0, arg1, arg2);
		if (removed != null)
		{
			SetActionPlanningModified(context);
		}
		return removed;
	}

	public void SetActionPlanningModified(DataContext context)
	{
		DomainManager.Character.SetActionPlanningData(context, this);
	}

	public void PeriAdvanceMonth_UpdateGoals(DataContext context)
	{
		ActionPlanningData planningData = ActionPlanningData;
		bool modified = OfflineUpdatePrioritizedGoals(context, planningData);
		modified = OfflineUpdateCurrentGoal(planningData) || modified;
		int currDate = DomainManager.World.GetCurrDate();
		if (planningData.UpdateActionCooldowns(currDate) || modified)
		{
			context.ParallelModificationsRecorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdateGoals);
			context.ParallelModificationsRecorder.RecordParameterClass(this);
		}
	}

	public static void ComplementPostAdvanceMonth_UpdateGoals(DataContext context, Character character)
	{
		character.SetActionPlanningModified(context);
	}

	public void PeriAdvanceMonth_UpdatePrimaryGoalAndActions(DataContext context)
	{
		if (!IsActiveAdvanceMonthStatus(7) && !IsActiveExternalRelationState(188uL) && !DomainManager.LegendaryBook.IsCharacterActingCrazy(this) && GetAgeGroup() != 0)
		{
			OfflineUpdateCurrentGoalActions(context, ActionPlanningData.ECurrentGoalType.Primary);
			context.ParallelModificationsRecorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdatePrimaryGoalAndActions);
			context.ParallelModificationsRecorder.RecordParameterClass(this);
		}
	}

	public void PeriAdvanceMonth_UpdateSecondaryGoalAndActions(DataContext context)
	{
		OfflineUpdateCurrentGoalActions(context, ActionPlanningData.ECurrentGoalType.Secondary);
		context.ParallelModificationsRecorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdateSecondaryGoalAndActions);
		context.ParallelModificationsRecorder.RecordParameterClass(this);
	}

	private void OfflineUpdateCurrentGoalActions(DataContext context, ActionPlanningData.ECurrentGoalType goalType)
	{
		ActionPlanningData planningData = ActionPlanningData;
		int currDate = DomainManager.World.GetCurrDate();
		planningData.UpdateActionPoints(goalType);
		CharacterGoalData currentGoal = planningData.GetCurrentGoal(goalType);
		while (currentGoal != null)
		{
			CharacterActionData currentAction = planningData.GetCurrentAction(goalType);
			if (currentAction != null)
			{
				currentAction.Character = this;
				if (currentAction.IsValid)
				{
					break;
				}
				planningData.SetCurrentAction(goalType, null);
			}
			if (ReassessPlan(context, currentGoal))
			{
				if (currentGoal.Plan.Count <= 0)
				{
					planningData.SetGoalAchieved(currentGoal, currDate);
					planningData.UpdateCurrentGoalsByPriority(this, currDate);
					currentGoal = planningData.GetCurrentGoal(goalType);
					continue;
				}
				CharacterActionData action = OfflineCreateNextAction(context, currentGoal);
				if (action != null)
				{
					planningData.SetCurrentAction(goalType, action);
					break;
				}
				currentGoal.Unreachable = true;
				planningData.SetGoalReplaced(currentGoal, currDate);
				planningData.UpdateCurrentGoalsByPriority(this, currDate);
				currentGoal = planningData.GetCurrentGoal(goalType);
			}
			else if (!OfflineUpdateGoalPlan(context, currentGoal))
			{
				currentGoal.Unreachable = true;
				planningData.UpdateCurrentGoalsByPriority(this, currDate);
				currentGoal = planningData.GetCurrentGoal(goalType);
			}
		}
	}

	private bool OfflineUpdateGoalPlan(DataContext context, CharacterGoalData goalData)
	{
		CharacterPlanningAgent agent = context.PlanningAgent;
		CharacterActionPlanner planner = CharacterActionPlanner.Instance;
		goalData.ResetPlan();
		agent.Initialize(context, this, goalData);
		planner.Plan(context, agent);
		if (agent.Plan.Count <= 0)
		{
			return false;
		}
		if (goalData.Plan == null)
		{
			goalData.Plan = new List<int>();
		}
		for (int index = agent.Plan.Count - 1; index >= 0; index--)
		{
			INode<Character, StateKey> node = agent.Plan[index];
			if (node is PlanningActionNode actionNode)
			{
				goalData.Plan.Add(actionNode.Template.TemplateId);
			}
		}
		return true;
	}

	public static void ComplementPeriAdvanceMonth_UpdatePrimaryGoalAndActions(DataContext context, Character character)
	{
		if (DomainManager.Character.IsCharacterAlive(character.GetId()))
		{
			character.ComplementUpdateCurrentGoalActions(context, ActionPlanningData.ECurrentGoalType.Primary);
			character.SetActionPlanningModified(context);
		}
	}

	public static void ComplementPeriAdvanceMonth_UpdateSecondaryGoalAndActions(DataContext context, Character character)
	{
		if (DomainManager.Character.IsCharacterAlive(character.GetId()))
		{
			character.ComplementUpdateCurrentGoalActions(context, ActionPlanningData.ECurrentGoalType.Secondary);
			character.SetActionPlanningModified(context);
		}
	}

	private void ComplementUpdateCurrentGoalActions(DataContext context, ActionPlanningData.ECurrentGoalType goalType)
	{
		int currDate = DomainManager.World.GetCurrDate();
		ActionPlanningData planningData = ActionPlanningData;
		List<CharacterActionData> interruptedActions = planningData.InterruptedActions;
		if (interruptedActions != null && interruptedActions.Count > 0)
		{
			foreach (CharacterActionData action in planningData.InterruptedActions)
			{
				action.Implementation?.OnInterrupt(context, this, action);
				ActionPlanningData.SetActionCooldown(action, currDate);
			}
			planningData.InterruptedActions.Clear();
		}
		CharacterGoalData currentGoal = planningData.GetCurrentGoal(goalType);
		if (currentGoal == null)
		{
			return;
		}
		CharacterActionData actionData = planningData.GetCurrentAction(goalType);
		while (actionData != null)
		{
			if (!DomainManager.Character.IsCharacterAlive(_id))
			{
				return;
			}
			if (IsActiveAdvanceMonthStatus(7) || IsActiveExternalRelationState(188uL) || !_location.IsValid())
			{
				if (actionData.InProgress)
				{
					actionData.Implementation?.OnInterrupt(context, this, actionData);
					ActionPlanningData.SetActionCooldown(actionData, currDate);
				}
				currentGoal.CurrentAction = null;
				SetActionPlanningModified(context);
				return;
			}
			CharacterActionData nextActionData;
			try
			{
				nextActionData = ExecuteAction(context, goalType, currentGoal, actionData);
			}
			catch (Exception ex)
			{
				planningData.SetCurrentAction(goalType, null);
				PredefinedLog.DefValue.CharacterActionExecutionFailed.Log(this, currentGoal, actionData, ex);
				return;
			}
			if (nextActionData == actionData)
			{
				break;
			}
			actionData = nextActionData;
		}
		planningData.SetCurrentAction(goalType, actionData);
		SetActionPlanningModified(context);
	}

	private CharacterActionData ExecuteAction(DataContext context, ActionPlanningData.ECurrentGoalType goalType, CharacterGoalData currentGoal, CharacterActionData currentAction)
	{
		if (!currentAction.IsValid)
		{
			return null;
		}
		ActionPlanningData planningData = ActionPlanningData;
		if (planningData.IsActionInCooldown(currentAction.ActionTemplateId))
		{
			return currentAction;
		}
		if (!currentAction.HasStarted)
		{
			if (!_location.IsValid())
			{
				return null;
			}
			if (!ActionPlanningData.TryStartAction(goalType, currentAction))
			{
				return currentAction;
			}
			currentAction.Implementation.OnStart(context, this, currentAction);
		}
		if (!currentAction.Implementation.CheckAtTargetLocation(this, currentAction) && (currentGoal.State == CharacterGoalData.EGoalState.Secondary || IsInTaiwuGroup() || !currentAction.Implementation.MoveToTargetLocation(context, this, currentAction) || currentAction.TargetIsTaiwuGroupMember))
		{
			Events.RaiseCharacterActionExecuted(context, this, currentGoal, currentAction, complete: false);
			return currentAction;
		}
		bool actionComplete = currentAction.Implementation.Execute(context, this, currentAction);
		Events.RaiseCharacterActionExecuted(context, this, currentGoal, currentAction, actionComplete);
		if (!actionComplete)
		{
			return currentAction;
		}
		int currDate = DomainManager.World.GetCurrDate();
		planningData.SetActionCooldown(currentAction, currDate);
		StateEffect<StateKey>[] effects = currentAction.Template.Effects;
		foreach (StateEffect<StateKey> effect in effects)
		{
			currentGoal.TryApplyEffect(effect);
		}
		if (!ReassessPlan(context, currentGoal))
		{
			return null;
		}
		return OfflineCreateNextAction(context, currentGoal);
	}

	private CharacterActionData OfflineCreateNextAction(DataContext context, CharacterGoalData currentGoal)
	{
		if (!currentGoal.Plan.TryPop(out var actionTemplateId))
		{
			return null;
		}
		PlanningActionNode actionNode = CharacterActionPlanner.Instance.GetActionNode(actionTemplateId);
		ContextArgGroupHandle args = ((CharacterStateMemory)context.PlanningAgent.Memory).Args;
		ICharacterActionImpl implementation = actionNode.CreateImplementation(context, this, args);
		if (implementation == null)
		{
			AdaptableLog.TagWarning("OfflineCreateNextAction", $"Failed to create action implementation {actionNode} for {this}.");
			return null;
		}
		if (ActionPlanningData.IsActionInCooldown(actionTemplateId))
		{
			return null;
		}
		CharacterActionData currentAction = new CharacterActionData(this, actionTemplateId, implementation);
		PlanningActionItem actionTemplate = actionNode.Template;
		if (args.HasArgOfType(EPlanningParameterType.MapBlock))
		{
			currentAction.TargetLocation = args.Location;
		}
		if (args.HasArgOfType(EPlanningParameterType.Character))
		{
			currentAction.TargetCharId = args.TargetCharId;
		}
		if (actionTemplate.CharacterSelectCountType == EPlanningActionCharacterSelectCountType.RequiredSingle)
		{
			if (actionTemplate.CharacterSelector != EPlanningActionCharacterSelector.None)
			{
				Character targetChar = context.PlanningAgent.SelectActionTarget(context, currentGoal.TemplateNode, currentAction.ActionNode, args);
				if (targetChar == null)
				{
					return null;
				}
				currentAction.TargetCharId = targetChar._id;
			}
			else if (currentAction.TargetCharId < 0)
			{
				return null;
			}
		}
		else if (actionTemplate.CharacterSelectCountType == EPlanningActionCharacterSelectCountType.RequiredMultiple)
		{
			IEnumerable<Character> targetChars = context.PlanningAgent.SelectActionTargetGroup(context, currentGoal.TemplateNode, currentAction.ActionNode, args);
			List<int> targetCharIds = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
			foreach (Character targetChar2 in targetChars)
			{
				targetCharIds.Add(targetChar2.GetId());
			}
			currentAction.TargetCharIds = targetCharIds.ToArray();
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref targetCharIds);
			if (currentAction.TargetCharIds.Length < actionTemplate.CharacterSelectCountRange[0])
			{
				return null;
			}
		}
		else if (actionTemplate.CharacterSelectCountType == EPlanningActionCharacterSelectCountType.OptionalMultiple)
		{
			IEnumerable<Character> targetChars2 = context.PlanningAgent.SelectActionTargetGroup(context, currentGoal.TemplateNode, currentAction.ActionNode, args);
			List<int> targetCharIds2 = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
			foreach (Character targetChar3 in targetChars2)
			{
				targetCharIds2.Add(targetChar3.GetId());
			}
			currentAction.TargetCharIds = targetCharIds2.ToArray();
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref targetCharIds2);
		}
		if (!currentAction.Implementation.OfflineInitActionData(context, this, args, currentAction))
		{
			return null;
		}
		return currentAction;
	}

	private bool OfflineUpdatePrioritizedGoals(DataContext context, ActionPlanningData planningData)
	{
		if (!_location.IsValid() || IsActiveExternalRelationState(188uL))
		{
			return false;
		}
		bool modified = false;
		List<int>[] prioritizedTargets = context.AdvanceMonthRelatedData.PrioritizedTargets.Occupy();
		HashSet<int> charSet = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
		DomainManager.Character.GetRelatedCharacters(_id)?.GetAllPrioritizedCharIds(charSet);
		ClassifyPrioritizedActionTargets(prioritizedTargets, charSet, context.Random);
		context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref charSet);
		foreach (PlanningGoalNode goal in CharacterActionPlanner.Instance.GetPrioritizedGoals())
		{
			PlanningGoalItem goalTemplate = goal.Template;
			if (goalTemplate.RecreateEveryMonth)
			{
				modified = goal.TryCreate(context, this) || planningData.RemoveGoal(goalTemplate.TemplateId) != null || modified;
			}
			else if (planningData.GetGoal(goalTemplate.TemplateId) == null)
			{
				modified = goal.TryCreate(context, this) || modified;
			}
		}
		context.AdvanceMonthRelatedData.PrioritizedTargets.Release(ref prioritizedTargets);
		return modified;
	}

	private bool OfflineUpdateCurrentGoal(ActionPlanningData planningData)
	{
		int currDate = DomainManager.World.GetCurrDate();
		bool modified = false;
		List<CharacterGoalData> goals = planningData.Goals;
		if (goals != null && goals.Count > 0)
		{
			for (int index = planningData.Goals.Count - 1; index >= 0; index--)
			{
				CharacterGoalData goal = planningData.Goals[index];
				if (goal.IsTimeout || !goal.IsValid(this))
				{
					modified = true;
					planningData.Goals.RemoveAt(index);
					if (goal.IsCurrent)
					{
						planningData.SetGoalReplaced(goal, currDate);
					}
				}
			}
		}
		modified = planningData.ResetUnreachableGoals() || modified;
		return planningData.UpdateCurrentGoalsByPriority(this, currDate) || modified;
	}

	private bool ReassessPlan(DataContext context, CharacterGoalData currentGoal)
	{
		if (currentGoal.Plan == null)
		{
			return false;
		}
		CharacterPlanningAgent agent = context.PlanningAgent;
		agent.Initialize(context, this, currentGoal);
		for (int index = currentGoal.Plan.Count - 1; index >= 0; index--)
		{
			int actionTemplateId = currentGoal.Plan[index];
			agent.Plan.Add(CharacterActionPlanner.Instance.GetActionNode(actionTemplateId));
		}
		agent.Plan.Add(currentGoal.TemplateNode);
		currentGoal.FillStateMemory(agent.Memory);
		if (!CharacterActionPlanner.Instance.ReassessPlan(context, agent, out var modified))
		{
			return false;
		}
		if (!modified)
		{
			return true;
		}
		if (currentGoal.Plan == null)
		{
			currentGoal.Plan = new List<int>();
		}
		currentGoal.Plan.Clear();
		for (int index2 = agent.Plan.Count - 1; index2 >= 0; index2--)
		{
			INode<Character, StateKey> node = agent.Plan[index2];
			if (node is PlanningActionNode action)
			{
				currentGoal.Plan.Add(action.Template.TemplateId);
			}
		}
		return true;
	}

	public bool IsProtectingTarget(int targetCharId)
	{
		return IsCurrentGoal(262, targetCharId);
	}

	public bool IsEscapingFromBounty()
	{
		return IsCurrentGoal(257) || IsCurrentGoal(258);
	}

	public bool CurrentActionBlockAppointment()
	{
		if (_actionPlanningData == null)
		{
			return false;
		}
		CharacterActionData action = _actionPlanningData.PrimaryGoalAction;
		if (action == null)
		{
			return false;
		}
		return !string.IsNullOrEmpty(action.Template.RefuseAppointment);
	}

	public AvatarRelatedData GenerateAvatarRelatedData()
	{
		return new AvatarRelatedData
		{
			AvatarData = new AvatarData(GetAvatar()),
			DisplayAge = GetPhysiologicalAge(),
			ClothingDisplayId = GetClothingDisplayId(),
			HasNewGoods = DomainManager.Character.MerchantHasNewGoods(GetId())
		};
	}

	public bool IsAbleToGrowAvatarElement(sbyte growableElementType, short physiologicalAge)
	{
		if (1 == 0)
		{
		}
		bool result = growableElementType switch
		{
			0 => IsAbleToGrowHair(), 
			1 => IsAbleToGrowBeard1(physiologicalAge), 
			2 => IsAbleToGrowBeard2(physiologicalAge), 
			3 => IsAbleToGrowWrinkle1(physiologicalAge), 
			4 => IsAbleToGrowWrinkle2(physiologicalAge), 
			5 => IsAbleToGrowWrinkle3(physiologicalAge), 
			6 => IsAbleToGrowEyebrow(), 
			_ => throw new Exception($"Unsupported AvatarGrowableElementType: {growableElementType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public bool IsAbleToGrowHair()
	{
		return !IsMonkType(2);
	}

	public (bool beard1, bool beard2) IsAbleToGrowBeards(short physiologicalAge)
	{
		if (_gender != 1 || _transgender || _featureIds.Contains(168))
		{
			return (beard1: false, beard2: false);
		}
		return (beard1: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1, beard2: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2);
	}

	public bool IsAbleToGrowBeard1(short physiologicalAge)
	{
		return _gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1 && !_transgender && !_featureIds.Contains(168);
	}

	public bool IsAbleToGrowBeard2(short physiologicalAge)
	{
		return _gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2 && !_transgender && !_featureIds.Contains(168);
	}

	public void SetAvatar(DataContext context, AvatarData customAvatarData)
	{
		for (sbyte i = 0; i < 7; i++)
		{
			customAvatarData.SetGrowableElementShowingAbility(i, IsAbleToGrowAvatarElement(i, GetPhysiologicalAge()));
		}
		for (sbyte i2 = 0; i2 < 7; i2++)
		{
			if (!customAvatarData.GetGrowableElementShowingState(i2) && IsAbleToGrowAvatarElement(i2, GetPhysiologicalAge()))
			{
				DomainManager.Character.InitializeAvatarElementGrowthProgress(context, _id, i2);
			}
		}
		SetAvatar(customAvatarData, context);
	}

	public bool IsAbleToGrowWrinkle1(short physiologicalAge)
	{
		return physiologicalAge >= GlobalConfig.Instance.AgeShowWrinkle1 && physiologicalAge * 12 * 100 >= GetMaxHealth() * GlobalConfig.Instance.AgePercentShowWrinkle1;
	}

	public bool IsAbleToGrowWrinkle2(short physiologicalAge)
	{
		return physiologicalAge >= GlobalConfig.Instance.AgeShowWrinkle2 && physiologicalAge * 12 * 100 >= GetMaxHealth() * GlobalConfig.Instance.AgePercentShowWrinkle2;
	}

	public bool IsAbleToGrowWrinkle3(short physiologicalAge)
	{
		return physiologicalAge >= GlobalConfig.Instance.AgeShowWrinkle3 && physiologicalAge * 12 * 100 >= GetMaxHealth() * GlobalConfig.Instance.AgePercentShowWrinkle3;
	}

	public static bool IsAbleToGrowEyebrow()
	{
		return true;
	}

	public sbyte GetInnateFiveElementsType()
	{
		return SharedMethods.GetInnateFiveElementsType(_birthMonth);
	}

	public void SpecifyCurrNeili(DataContext context, int value)
	{
		if (value < 0)
		{
			throw new Exception($"{this}'s current neili not enough: {value}");
		}
		int maxNeili = GetMaxNeili();
		if (value > maxNeili)
		{
			value = maxNeili;
		}
		SetCurrNeili(value, context);
	}

	public void ChangeCurrNeili(DataContext context, int delta)
	{
		int value = _currNeili + delta;
		if (value < 0)
		{
			throw new Exception($"{this}'s current neili not enough: {_currNeili}, {delta}");
		}
		int maxNeili = GetMaxNeili();
		if (value > maxNeili)
		{
			value = maxNeili;
		}
		SetCurrNeili(value, context);
	}

	public void ChangeCurrNeiliWithoutChecking(DataContext context, int delta)
	{
		int maxNeili = GetMaxNeili();
		int value = Math.Clamp(_currNeili + delta, 0, maxNeili);
		SetCurrNeili(value, context);
	}

	public int GetCurrNeiliRecovery(int maxNeili)
	{
		short attainment = GetCombatSkillAttainment(0);
		if (IsActiveExternalRelationState(32uL) && DomainManager.Organization.GetPrisonerSect(_id) == 3)
		{
			return 0;
		}
		return attainment + _extraNeili / 4;
	}

	public unsafe int GetPureCurrNeili()
	{
		int value = _currNeili;
		for (int type = 0; type < 4; type++)
		{
			value += CombatHelper.CalcNeiliCostFromZero(_baseNeiliAllocation.Items[type]);
		}
		int pureMaxNeili = GetPureMaxNeili();
		if (value > pureMaxNeili)
		{
			return pureMaxNeili;
		}
		return value;
	}

	public void ChangeExtraNeili(DataContext context, int delta)
	{
		_extraNeili += delta;
		if (_extraNeili < 0)
		{
			_extraNeili = 0;
		}
		SetExtraNeili(_extraNeili, context);
	}

	public void TransferNeiliProportionOfFiveElements(DataContext context, sbyte destType, sbyte transferType, int amount)
	{
		_baseNeiliProportionOfFiveElements.Transfer(destType, transferType, amount);
		SetBaseNeiliProportionOfFiveElements(_baseNeiliProportionOfFiveElements, context);
		if (GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Global.CheckFiveElementConflictGuidingTrigger(context, GetNeiliType());
		}
	}

	public unsafe bool AllocateNeili(DataContext context, byte neiliAllocationType)
	{
		if (!CombatHelper.CanAllocateNeiliConsideringFeature(neiliAllocationType, _baseNeiliAllocation, _currNeili, _consummateLevel, GetFeatureIds(), DomainManager.World.GetChallengeModeData()))
		{
			return false;
		}
		short currAllocation = _baseNeiliAllocation.Items[(int)neiliAllocationType];
		_baseNeiliAllocation.Items[(int)neiliAllocationType] = (short)(currAllocation + 1);
		SetBaseNeiliAllocation(_baseNeiliAllocation, context);
		int cost = CombatHelper.CalcNeiliCost(currAllocation);
		ChangeCurrNeili(context, -cost);
		Tester.Assert(_currNeili <= GetMaxNeili());
		return true;
	}

	public unsafe bool DeallocateNeili(DataContext context, byte neiliAllocationType)
	{
		short currAllocation = _baseNeiliAllocation.Items[(int)neiliAllocationType];
		if (currAllocation <= 0)
		{
			return false;
		}
		short targetAllocation = (short)(currAllocation - 1);
		_baseNeiliAllocation.Items[(int)neiliAllocationType] = targetAllocation;
		SetBaseNeiliAllocation(_baseNeiliAllocation, context);
		int returned = CombatHelper.CalcNeiliCost(targetAllocation);
		ChangeCurrNeili(context, returned);
		Tester.Assert(_currNeili <= GetMaxNeili());
		return true;
	}

	public void SpecifyBaseNeiliAllocation(DataContext context, NeiliAllocation allocations)
	{
		int oriPureCurrNeili = GetPureCurrNeili();
		int currRequiredNeili = CombatHelper.CalcRequiredNeili(allocations);
		int currNeili = oriPureCurrNeili - currRequiredNeili;
		SetBaseNeiliAllocation(allocations, context);
		SpecifyCurrNeili(context, currNeili);
	}

	public void ResetBaseNeiliAllocation(DataContext context)
	{
		int pureCurrNeili = GetPureCurrNeili();
		_baseNeiliAllocation.Initialize();
		SetBaseNeiliAllocation(_baseNeiliAllocation, context);
		SpecifyCurrNeili(context, pureCurrNeili);
	}

	public unsafe void ChangeExtraNeiliAllocation(DataContext context, NeiliAllocation delta)
	{
		for (int i = 0; i < 4; i++)
		{
			int value = _extraNeiliAllocation.Items[i] + delta.Items[i];
			_extraNeiliAllocation.Items[i] = (short)Math.Max(0, value);
		}
		SetExtraNeiliAllocation(_extraNeiliAllocation, context);
	}

	public unsafe void ChangeExtraNeiliAllocation(DataContext context, byte neiliAllocationType, short delta)
	{
		int value = _extraNeiliAllocation.Items[(int)neiliAllocationType] + delta;
		_extraNeiliAllocation.Items[(int)neiliAllocationType] = (short)Math.Max(0, value);
		SetExtraNeiliAllocation(_extraNeiliAllocation, context);
	}

	public void ChangePoisoned(DataContext context, sbyte poisonType, sbyte poisonLevel, int delta)
	{
		if (!OfflineChangePoisoned(poisonType, poisonLevel, delta))
		{
			return;
		}
		SetPoisoned(ref _poisoned, context);
		if (_id == DomainManager.Taiwu.GetTaiwuCharId() && delta != 0)
		{
			InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
			if (delta > 0)
			{
				collection.AddPoisonIncreased(_id, poisonType, delta);
			}
			else
			{
				collection.AddPoisonDecreased(_id, poisonType, -delta);
			}
		}
	}

	public bool CalcChangedPoisoned(ref PoisonInts targetPoisoned, sbyte poisonType, sbyte poisonLevel, int delta)
	{
		if (HasPoisonImmunity(poisonType))
		{
			return false;
		}
		int poisonResist = GetPoisonResists()[poisonType];
		int poisoned = targetPoisoned[poisonType];
		if (delta > 0)
		{
			if (1 == 0)
			{
			}
			int num = poisonType switch
			{
				3 => GetMixedPoisonTypeRelatedMarkCount(18), 
				0 => GetMixedPoisonTypeRelatedMarkCount(20), 
				1 => GetMixedPoisonTypeRelatedMarkCount(30), 
				2 => GetMixedPoisonTypeRelatedMarkCount(34), 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			int relatedMarkCount = num;
			if (relatedMarkCount > 0)
			{
				delta += relatedMarkCount * 10 + 10;
			}
			delta = delta * (100 + GetFeatureBonusAttachPoisonValue(poisonType)) / 100;
			delta = PoisonsAndLevels.CalcPoisonDelta(delta, poisonLevel, poisoned, poisonResist);
		}
		else if (poisonLevel < PoisonsAndLevels.CalcPoisonedLevel(poisoned))
		{
			return false;
		}
		targetPoisoned[poisonType] = Math.Clamp(poisoned + delta, 0, 25000);
		return true;
	}

	private bool OfflineChangePoisoned(sbyte poisonType, sbyte poisonLevel, int delta)
	{
		return CalcChangedPoisoned(ref _poisoned, poisonType, poisonLevel, delta);
	}

	public void ChangePoisoned(DataContext context, ref PoisonsAndLevels delta)
	{
		OfflineChangePoisoned(ref delta);
		SetPoisoned(ref _poisoned, context);
	}

	private unsafe void OfflineChangePoisoned(ref PoisonsAndLevels delta)
	{
		CharacterItem characterCfg = Config.Character.Instance[_templateId];
		byte poisonImmunities = DomainManager.Extra.GetPoisonImmunities(_id);
		ref PoisonInts poisonResists = ref GetPoisonResists();
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			if (!SharedMethods.HasPoisonImmunity(poisonType, characterCfg, ref poisonResists, poisonImmunities))
			{
				int poisonDelta = delta.Values[poisonType];
				sbyte poisonLevel = delta.Levels[poisonType];
				int currPoisoned = _poisoned.Items[poisonType];
				int currResist = poisonResists.Items[poisonType];
				if (poisonDelta >= 0)
				{
					poisonDelta = poisonDelta * (100 + GetFeatureBonusAttachPoisonValue(poisonType)) / 100;
					poisonDelta = PoisonsAndLevels.CalcPoisonDelta(poisonDelta, poisonLevel, currPoisoned, currResist);
					_poisoned.Items[poisonType] = Math.Clamp(currPoisoned + poisonDelta, 0, 25000);
				}
			}
		}
	}

	public unsafe void DirectlyChangePoisoned(DataContext context, ref PoisonInts delta)
	{
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			if (!HasPoisonImmunity(poisonType))
			{
				int currMaxValue = 25000;
				_poisoned.Items[poisonType] = Math.Clamp(_poisoned.Items[poisonType] + delta.Items[poisonType], 0, currMaxValue);
			}
		}
		SetPoisoned(ref _poisoned, context);
	}

	public void TransferDisorderOfQi(DataContext context, Character target, int delta)
	{
		DirectlyChangeDisorderOfQi(context, -delta);
		target.DirectlyChangeDisorderOfQi(context, delta);
	}

	public void ChangeDisorderOfQi(DataContext context, int baseDelta)
	{
		int delta = CalcDisorderOfQiDelta(baseDelta);
		DirectlyChangeDisorderOfQi(context, delta);
	}

	public void DirectlyChangeDisorderOfQi(DataContext context, int delta)
	{
		short oriValue = GetDisorderOfQi();
		short newDisorderOfQi = CalcChangedDisorderOfQiWithoutEffect(_disorderOfQi, delta);
		SetDisorderOfQi(newDisorderOfQi, context);
		if (_id != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return;
		}
		int changeValue = newDisorderOfQi - oriValue;
		if (changeValue != 0)
		{
			InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
			if (changeValue > 0)
			{
				collection.AddDisorderOfQiIncreased(_id, changeValue / 10);
			}
			else
			{
				collection.AddDisorderOfQiDecreased(_id, -changeValue / 10);
			}
			if (DisorderLevelOfQi.GetDisorderLevelOfQi(_disorderOfQi) >= 2)
			{
				DomainManager.Global.InvokeGuidingTrigger(context, 272);
			}
		}
	}

	public short CalcChangedDisorderOfQiWithoutEffect(short disorderOfQi, int delta)
	{
		return (short)Math.Clamp(disorderOfQi + delta, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue);
	}

	public int CalcDisorderOfQiDelta(int baseDelta)
	{
		int delta = baseDelta;
		CValuePercentBonus percent = 0;
		if (baseDelta < 0)
		{
			foreach (short featureId in _featureIds)
			{
				percent += (CValuePercentBonus)CharacterFeature.Instance[featureId].QiDisorderBuffPercent;
			}
		}
		else
		{
			foreach (short featureId2 in _featureIds)
			{
				if (!IgnoreFeature(featureId2))
				{
					percent += (CValuePercentBonus)CharacterFeature.Instance[featureId2].QiDisorderDebuffPercent;
				}
			}
		}
		delta *= percent.StaySymbol();
		if (delta < 0)
		{
			return delta + delta / 2 * GetRecoveryOfQiDisorder() / 1000;
		}
		return delta - delta / 2 * GetRecoveryOfQiDisorder() / 1000;
	}

	public void ChangeDisorderOfQiRandomRecovery(DataContext context, int delta)
	{
		delta = CFormula.RandomCalcDisorderOfQiDelta(context.Random, delta);
		ChangeDisorderOfQi(context, delta);
	}

	public void ChangeInjury(DataContext context, sbyte bodyPartType, bool isInnerInjury, sbyte delta)
	{
		CharacterItem config = Config.Character.Instance[_templateId];
		if (isInnerInjury ? config.InnerInjuryImmunity : config.OuterInjuryImmunity)
		{
			return;
		}
		_injuries.Change(bodyPartType, isInnerInjury, delta);
		SetInjuries(_injuries, context);
		if (_id == DomainManager.Taiwu.GetTaiwuCharId() && delta != 0)
		{
			InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
			if (delta > 0)
			{
				collection.AddInjuryIncreased(_id, bodyPartType, (sbyte)(isInnerInjury ? 1 : 0));
			}
			else
			{
				collection.AddInjuryDecreased(_id, bodyPartType, (sbyte)(isInnerInjury ? 1 : 0));
			}
		}
	}

	public void ChangeInjuries(DataContext context, Injuries delta)
	{
		CharacterItem config = Config.Character.Instance[_templateId];
		_injuries.Change(delta, config.OuterInjuryImmunity, config.InnerInjuryImmunity);
		SetInjuries(_injuries, context);
	}

	public DamageStepCollection CalcBaseDamageSteps()
	{
		DamageStepCollection result = new DamageStepCollection(GetDamageSteps());
		if (!IsTaiwu())
		{
			return result;
		}
		CharacterPropertyBonus bonus = DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(ECharacterPropertyReferencedType.BaseDamageStep);
		for (sbyte i = 0; i < 7; i++)
		{
			result.OuterDamageSteps[i] *= bonus + CalcMysteryBonusBaseDamageStepOuter(i);
			result.InnerDamageSteps[i] *= bonus + CalcMysteryBonusBaseDamageStepInner(i);
		}
		result.FatalDamageStep *= bonus + CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepFatal);
		result.MindDamageStep *= bonus + CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepMind);
		return result;
	}

	public void ChangeConsummateLevel(DataContext context, int delta)
	{
		sbyte value = (sbyte)Math.Clamp(_consummateLevel + delta, 0, GlobalConfig.Instance.MaxConsummateLevel);
		SetConsummateLevel(value, context);
	}

	public sbyte GetCombatSkillSlotCountWithGeneric(sbyte equipType)
	{
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			byte[] genericGridAllocation = DomainManager.Taiwu.GetGenericGridAllocation();
			byte addCount = genericGridAllocation.GetOrDefault(equipType - 1);
			return (sbyte)(GetCombatSkillSlotCount(equipType) + addCount);
		}
		Span<sbyte> slotCounts = stackalloc sbyte[5];
		GetCombatSkillSlotCountsWithGeneric(slotCounts);
		return slotCounts[equipType];
	}

	public int GetCombatSkillSlotCountsWithGeneric(Span<sbyte> slotCounts)
	{
		sbyte genericCount = GetCombatSkillSlotCounts(slotCounts);
		return ApplyGenericCombatSkillSlotAllocations(slotCounts, genericCount);
	}

	public int ApplyGenericCombatSkillSlotAllocations(Span<sbyte> slotCounts, int genericCount)
	{
		if (IsTaiwu())
		{
			byte[] genericGridAllocation = DomainManager.Taiwu.GetGenericGridAllocation();
			for (sbyte equipType = 1; equipType < 5; equipType++)
			{
				sbyte addCount = (sbyte)genericGridAllocation[equipType - 1];
				slotCounts[equipType] += addCount;
				int totalCost = CombatSkillHelper.GetGenericAllocationTotalCost(equipType, addCount);
				genericCount -= totalCost;
			}
		}
		else if (_leaderId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(_id);
			if (configuration == null)
			{
				return genericCount;
			}
			byte[] genericGridAllocation2 = configuration.CurrentEquipPlan.GenericGridAllocation;
			for (sbyte equipType2 = 1; equipType2 < 5; equipType2++)
			{
				sbyte addCount2 = (sbyte)genericGridAllocation2[equipType2 - 1];
				slotCounts[equipType2] += addCount2;
				int totalCost2 = CombatSkillHelper.GetGenericAllocationTotalCost(equipType2, addCount2);
				genericCount -= totalCost2;
			}
		}
		else
		{
			for (sbyte equipType3 = 1; equipType3 < 5; equipType3++)
			{
				sbyte required = (sbyte)GetCombatSkillTypeRequireGrid(equipType3);
				if (required > slotCounts[equipType3])
				{
					sbyte needAllocate = (sbyte)(required - slotCounts[equipType3]);
					int totalCost3 = CombatSkillHelper.GetGenericAllocationTotalCost(equipType3, needAllocate);
					if (needAllocate <= totalCost3)
					{
						slotCounts[equipType3] = required;
						genericCount -= totalCost3;
					}
				}
			}
		}
		return genericCount;
	}

	public sbyte GetCombatSkillSlotCounts(Span<sbyte> slotCounts)
	{
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		return GetCombatSkillSlotCounts(slotCounts, skillEquipment.Neigong);
	}

	public sbyte GetCombatSkillSlotCounts(Span<sbyte> slotCounts, ArraySegmentList<short> neigongList)
	{
		for (sbyte i = 0; i < 5; i++)
		{
			slotCounts[i] = GetCombatSkillSlotCount(i, neigongList);
		}
		return GetCombatSkillBasicSlotCount(5, neigongList);
	}

	public void GetCombatSkillExtraSlotCounts(Span<sbyte> slotCounts)
	{
		for (sbyte i = 0; i < 5; i++)
		{
			slotCounts[i] = GetCombatSkillExtraSlotCount(i);
		}
	}

	private sbyte GetCombatSkillSlotCount(sbyte equipType)
	{
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		return GetCombatSkillSlotCount(equipType, skillEquipment.Neigong);
	}

	private sbyte GetCombatSkillSlotCount(sbyte equipType, ArraySegmentList<short> neigongList)
	{
		if (equipType == 0)
		{
			return GetCombatSkillSlotCountNeigong();
		}
		int slotCount = GetCombatSkillBasicSlotCount(equipType, neigongList);
		slotCount += GetCombatSkillExtraSlotCount(equipType);
		return (sbyte)Math.Clamp(slotCount, 0, 99);
	}

	public sbyte GetCombatSkillSlotCountNeigong()
	{
		int slotCount = GlobalConfig.Instance.CombatSkillInitialEquipSlotCounts[0];
		slotCount += GetCombatSkillExtraSlotCount(0);
		return (sbyte)Math.Clamp(slotCount, 0, 99);
	}

	private sbyte GetCombatSkillGenericSlotCount()
	{
		return GetCombatSkillBasicSlotCount(5);
	}

	private sbyte GetCombatSkillBasicSlotCount(sbyte equipType)
	{
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		return GetCombatSkillBasicSlotCount(equipType, skillEquipment.Neigong);
	}

	public sbyte GetCombatSkillBasicSlotCount(sbyte equipType, ArraySegmentList<short> neigongList)
	{
		if (equipType == 0)
		{
			return GlobalConfig.Instance.CombatSkillInitialEquipSlotCounts[0];
		}
		bool isGeneric = equipType == 5;
		int slotCount = GlobalConfig.Instance.CombatSkillInitialEquipSlotCounts[equipType];
		sbyte mixedPoisonType = MixedPoisonType.FromCombatSkillEquipType(equipType);
		if (mixedPoisonType != -1)
		{
			slotCount -= Math.Max(0, GetRealMixedPoisonTypeRelatedMarkCount(mixedPoisonType) - 2);
		}
		if (isGeneric && IsTaiwu())
		{
			slotCount *= DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(ECharacterPropertyReferencedType.InnateGenericGrid);
		}
		sbyte remainNeigongGrid = GetCombatSkillSlotCountNeigong();
		ArraySegmentList<short>.Enumerator enumerator = neigongList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillTemplateId = enumerator.Current;
			if (skillTemplateId >= 0)
			{
				sbyte gridCost = GetCombatSkillGridCost(skillTemplateId);
				if (gridCost <= remainNeigongGrid && GetCombatSkillCanAffectBasic(skillTemplateId))
				{
					remainNeigongGrid -= gridCost;
					GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: _id, skillId: skillTemplateId));
					slotCount += (isGeneric ? skill.GetGenericGridCount() : skill.GetSpecificGridCount(equipType));
				}
			}
		}
		sbyte maxSlotCount = (isGeneric ? sbyte.MaxValue : CombatSkillHelper.MaxSlotCounts[equipType]);
		return (sbyte)Math.Clamp(slotCount, 0, maxSlotCount);
	}

	private sbyte GetCombatSkillExtraSlotCount(sbyte equipType)
	{
		int extraSlotCount = 0;
		foreach (short featureId in _featureIds)
		{
			extraSlotCount += CharacterFeature.Instance[featureId].CombatSkillSlotBonuses[equipType];
		}
		if (IsTaiwu())
		{
			extraSlotCount *= DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus((ECharacterPropertyReferencedType)(156 + equipType));
		}
		sbyte[] templateCounts = Template.ExtraCombatSkillGrids;
		sbyte[] orgMemberCounts = OrganizationDomain.GetOrgMemberConfig(_organizationInfo).ExtraCombatSkillGrids;
		if (CanAffectedByCombatDifficulty)
		{
			byte combatDifficulty = DomainManager.World.GetCombatDifficulty();
			CValuePercent difficultyFactor = Config.CombatDifficulty.Instance[combatDifficulty].ExtraCombatSkillGrids;
			extraSlotCount += templateCounts[equipType] + orgMemberCounts[equipType] * difficultyFactor;
		}
		else
		{
			extraSlotCount += templateCounts[equipType] + orgMemberCounts[equipType];
		}
		return (sbyte)Math.Clamp(extraSlotCount, 0, 127);
	}

	public void ResetCombatStatus(DataContext context)
	{
		ClearEatingItems(context);
		_injuries.Initialize();
		SetInjuries(_injuries, context);
		_poisoned.Initialize();
		SetPoisoned(ref _poisoned, context);
		SetDisorderOfQi(0, context);
		SetHealth(GetLeftMaxHealth(), context);
	}

	public int CalcNeiliAllocationStepCount(ECharacterPropertyReferencedType type)
	{
		NeiliAllocation allocations = GetNeiliAllocation();
		NeiliAllocation allocationEffects = GetAllocatedNeiliEffects();
		return type.CalcNeiliAllocationStepCount(allocations, allocationEffects);
	}

	public int CalcNeiliAllocationBonus(ECharacterPropertyReferencedType type)
	{
		sbyte neiliType = GetNeiliType();
		NeiliTypeItem neiliTypeCfg = NeiliType.Instance[neiliType];
		int valuePerStep = neiliTypeCfg.GetMapping(type);
		if (valuePerStep == 0)
		{
			return 0;
		}
		int stepCount = CalcNeiliAllocationStepCount(type);
		int value = valuePerStep * stepCount;
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		foreach (short skillId in skillEquipment)
		{
			if (skillId >= 0 && DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: _id, skillId: skillId), out var skill))
			{
				value += skill.CalcNeiliAllocationBonus(type, stepCount);
			}
		}
		return value;
	}

	public short GetRandomFavorability(IRandomSource random)
	{
		CharacterItem config = Config.Character.Instance[_templateId];
		int index = RandomUtils.GetRandomIndex(config.RandomEnemyFavorability, random);
		(short, short) range = RandomFavorabilityRanges[index];
		return (short)random.Next(range.Item1, range.Item2 + 1);
	}

	public sbyte CalcWeaponInnerRatio(short weaponTemplateId, sbyte expectRatio)
	{
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponTemplateId];
		int baseRatio = weaponConfig.DefaultInnerRatio;
		int changeRange = weaponConfig.InnerRatioAdjustRange * GetInnerRatio() / 100;
		int minRatio = Math.Max(baseRatio - changeRange, 0);
		int maxRatio = Math.Min(baseRatio + changeRange, 100);
		return (sbyte)Math.Clamp(expectRatio, minRatio, maxRatio);
	}

	private int GetPureMaxNeili()
	{
		int value = ((!IsGearMate) ? GlobalConfig.Instance.CharacterInitialNeili : 0);
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (var (skillTemplateId, skill) in combatSkills)
		{
			Tester.Assert(_learnedCombatSkills.Contains(skillTemplateId));
			if (!skill.GetRevoked())
			{
				value += skill.GetObtainedNeili();
			}
		}
		value += _extraNeili;
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			CharacterPropertyBonus permanentBonus = DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(ECharacterPropertyReferencedType.MaxNeili);
			value *= (CValueModify)permanentBonus;
		}
		if (DomainManager.Extra.TryGetElement_SectZhujianGearMates(_id, out var gearMate))
		{
			value += gearMate.Neili;
		}
		return value;
	}

	private bool TryGetFixedSubAttributeValue(out short fixedSubAttributeValue)
	{
		bool fixMaxValue = DomainManager.SpecialEffect.ModifyData(_id, -1, 17, dataValue: false);
		bool fixMinValue = DomainManager.SpecialEffect.ModifyData(_id, -1, 18, dataValue: false);
		bool hasFixed = fixMaxValue != fixMinValue;
		if (hasFixed)
		{
			fixedSubAttributeValue = (short)(fixMaxValue ? 1000 : 0);
		}
		else
		{
			fixedSubAttributeValue = -1;
		}
		return hasFixed;
	}

	private int CalcOverloadBonus(int value, IReadOnlyList<int> configBonus)
	{
		if (DomainManager.SpecialEffect.ModifyData(_id, -1, 278, dataValue: false))
		{
			return value;
		}
		int curLoad = GetCurrEquipmentLoad();
		int maxLoad = GetMaxEquipmentLoad();
		if (curLoad <= maxLoad || maxLoad <= 0)
		{
			return value;
		}
		int index = Math.Min((curLoad - 1) / maxLoad - 1, configBonus.Count - 1);
		CValuePercent percent = configBonus[index];
		return value * percent;
	}

	private int CalcTreasuryGuardBonus(int value)
	{
		return value * (CValuePercent)GlobalConfig.Instance.TreasuryGuardPropertyPercent;
	}

	private bool IsFeatureMakeRelated()
	{
		for (int i = 0; i < _featureIds.Count; i++)
		{
			if (CharacterFeature.Instance[_featureIds[i]].MakeConsummateLevelRelated)
			{
				return true;
			}
		}
		return false;
	}

	private int CalcMainAttributeRelatedConsummateLevel(ushort affectedDataFieldId, sbyte mainAttributeType, int hitOrInnerType, int divisor)
	{
		bool relatedConsummateLevel = DomainManager.SpecialEffect.ModifyData(_id, -1, affectedDataFieldId, dataValue: false, mainAttributeType, hitOrInnerType);
		short mainAttributeValue = GetMaxMainAttribute(mainAttributeType);
		int addValue = 100 + mainAttributeValue / 2;
		int consummateLevelAddValue = mainAttributeValue / divisor * _consummateLevel;
		if (relatedConsummateLevel)
		{
			addValue += consummateLevelAddValue;
		}
		if (IsFeatureMakeRelated())
		{
			addValue += consummateLevelAddValue;
		}
		return addValue;
	}

	public void AddEquippedCombatSkill(DataContext context, short skillTemplateId)
	{
		if (skillTemplateId >= 0)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
			sbyte equipType = skillCfg.EquipType;
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_id, skillTemplateId));
			if (skill.GetRevoked())
			{
				throw new Exception($"Combat skill {skillCfg.Name} of character {this} is revoked");
			}
			sbyte skillRequiredSlotCount = GetCombatSkillGridCost(skillTemplateId);
			int availableSlotCount = GetCombatSkillSlotCountWithGeneric(equipType) - GetCombatSkillTypeRequireGrid(equipType);
			if (availableSlotCount < skillRequiredSlotCount)
			{
				throw new Exception($"Combat skill {skillCfg.Name} exceed slot count: {availableSlotCount} available, {skillRequiredSlotCount} required.");
			}
		}
		CombatSkillEquipment combatSkillEquipment = GetCombatSkillEquipment();
		combatSkillEquipment.OfflineAddSkill(skillTemplateId);
		ApplyCombatSkillEquipmentModification(context, combatSkillEquipment);
	}

	public void RemoveEquippedCombatSkill(DataContext context, short skillTemplateId)
	{
		CombatSkillEquipment combatSkillEquipment = GetCombatSkillEquipment();
		if (combatSkillEquipment.OfflineRemoveSkill(skillTemplateId))
		{
			ApplyCombatSkillEquipmentModification(context, combatSkillEquipment);
		}
	}

	public void ClearCombatSkillEquipment(DataContext context)
	{
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		SetEquippedCombatSkills(_equippedCombatSkills, context);
		DomainManager.Extra.RemoveCharacterEquippedCombatSkills(context, _id);
		DomainManager.SpecialEffect.UpdateEquippedSkillEffect(context, this);
		if (IsTaiwu())
		{
			byte[] genericGridAllocation = DomainManager.Taiwu.GetGenericGridAllocation();
			Array.Fill(genericGridAllocation, (byte)0);
			DomainManager.Taiwu.SetGenericGridAllocation(context, genericGridAllocation);
		}
		else if (_leaderId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(_id);
			if (configuration != null)
			{
				Array.Fill(configuration.CurrentEquipPlan.GenericGridAllocation, (byte)0);
				DomainManager.Extra.SetCharacterCombatSkillConfiguration(context, _id, configuration);
			}
		}
	}

	public bool ClearExceededCombatSkills(DataContext context, sbyte equipType)
	{
		Span<sbyte> gridCounts = stackalloc sbyte[5];
		GetCombatSkillSlotCountsWithGeneric(gridCounts);
		return ClearExceededCombatSkills(context, equipType, gridCounts[equipType]);
	}

	public bool ClearExceededCombatSkills(DataContext context, sbyte equipType, int slotCount)
	{
		int requiredGrid = GetCombatSkillTypeRequireGrid(equipType);
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		bool isChanged = false;
		while (requiredGrid > slotCount)
		{
			short removedSkillId = skillEquipment.OfflineRemoveLastSkill(equipType);
			if (removedSkillId < 0)
			{
				break;
			}
			requiredGrid -= GetCombatSkillGridCost(removedSkillId);
			isChanged = true;
		}
		if (isChanged)
		{
			ApplyCombatSkillEquipmentModification(context, skillEquipment);
		}
		return isChanged;
	}

	public void UpdateAllocatedGenericGrids(DataContext context)
	{
		int totalGenericGrid = GetCombatSkillGenericSlotCount();
		CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(_id);
		bool isTaiwu = IsTaiwu();
		byte[] genericGridAllocation = (isTaiwu ? DomainManager.Taiwu.GetGenericGridAllocation() : configuration?.CurrentEquipPlan.GenericGridAllocation);
		if (genericGridAllocation == null)
		{
			return;
		}
		bool isChanged = false;
		for (int i = 0; i < genericGridAllocation.Length; i++)
		{
			sbyte equipType = (sbyte)(i + 1);
			byte allocatedGridCount = genericGridAllocation[i];
			sbyte maxSlotCount = CombatSkillHelper.MaxSlotCounts[equipType];
			byte allocatableGenericGridCount = (byte)(maxSlotCount - GetCombatSkillBasicSlotCount(equipType));
			if (allocatedGridCount > allocatableGenericGridCount)
			{
				allocatedGridCount = (genericGridAllocation[i] = allocatableGenericGridCount);
				isChanged = true;
			}
			int allocationCost = CombatSkillHelper.GetGenericAllocationTotalCost(equipType, allocatedGridCount);
			if (totalGenericGrid >= allocationCost)
			{
				totalGenericGrid -= allocationCost;
				continue;
			}
			do
			{
				allocatedGridCount--;
				allocationCost = CombatSkillHelper.GetGenericAllocationTotalCost(equipType, allocatedGridCount);
			}
			while (totalGenericGrid < allocationCost && allocatedGridCount > 0);
			genericGridAllocation[i] = allocatedGridCount;
			totalGenericGrid -= allocationCost;
			isChanged = true;
		}
		if (isChanged)
		{
			if (isTaiwu)
			{
				DomainManager.Taiwu.SetGenericGridAllocation(context, genericGridAllocation);
			}
			else
			{
				DomainManager.Extra.SetCharacterCombatSkillConfiguration(context, _id, configuration);
			}
		}
	}

	public void ApplyCombatSkillEquipmentModification(DataContext context, CombatSkillEquipment combatSkillEquipment)
	{
		SetEquippedCombatSkills(_equippedCombatSkills, context);
		CombatSkillPlan source = combatSkillEquipment.GetSourceObject<CombatSkillPlan>();
		if (source != null)
		{
			DomainManager.Extra.SetCharacterEquippedCombatSkills(context, _id, source);
		}
		else
		{
			DomainManager.Extra.RemoveCharacterEquippedCombatSkills(context, _id);
		}
		UpdateAllocatedGenericGrids(context);
		DomainManager.SpecialEffect.UpdateEquippedSkillEffect(context, this);
	}

	public bool IsCombatSkillEquipped(short skillTemplateId)
	{
		CombatSkillEquipment combatSkillEquipment = GetCombatSkillEquipment();
		return combatSkillEquipment.IsCombatSkillEquipped(skillTemplateId);
	}

	internal void CopyCombatSkillEquipmentFrom(DataContext context, Character other)
	{
		SetEquippedCombatSkills(other._equippedCombatSkills.ToArray(), context);
		if (DomainManager.Extra.TryGetCharacterEquippedCombatSkills(other._id, out var otherCombatSkillPlan))
		{
			if (DomainManager.Extra.TryGetCharacterEquippedCombatSkills(_id, out var selfCombatSkillPlan))
			{
				selfCombatSkillPlan.Assign(otherCombatSkillPlan);
			}
			else
			{
				selfCombatSkillPlan = new CombatSkillPlan(otherCombatSkillPlan);
			}
			DomainManager.Extra.SetCharacterEquippedCombatSkills(context, _id, selfCombatSkillPlan);
		}
		else
		{
			DomainManager.Extra.RemoveCharacterEquippedCombatSkills(context, _id);
		}
		DomainManager.SpecialEffect.UpdateEquippedSkillEffect(context, this);
	}

	public sbyte GetCombatSkillGridCost(short skillTemplateId)
	{
		sbyte gridCost = Config.CombatSkill.Instance[skillTemplateId].GridCost;
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			gridCost = (sbyte)DomainManager.SpecialEffect.ModifyData(_id, skillTemplateId, 211, gridCost);
		}
		if (DomainManager.Extra.IsCombatSkillMasteredByCharacter(_id, skillTemplateId))
		{
			gridCost--;
		}
		return Math.Max(gridCost, 1);
	}

	public int GetCombatSkillTypeRequireGrid(sbyte combatSkillEquipType)
	{
		int require = 0;
		ArraySegmentList<short> skillIds = GetCombatSkillEquipment()[combatSkillEquipType];
		ArraySegmentList<short>.Enumerator enumerator = skillIds.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillId = enumerator.Current;
			if (skillId >= 0)
			{
				require += GetCombatSkillGridCost(skillId);
			}
		}
		return require;
	}

	public bool GetCombatSkillCanAffect(short skillTemplateId)
	{
		if (skillTemplateId < 0)
		{
			return false;
		}
		if (_leaderId < 0 || _leaderId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return true;
		}
		sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		int equipIndex = skillEquipment[equipType].IndexOf(skillTemplateId);
		if (equipIndex < 0)
		{
			return true;
		}
		if (!GetCombatSkillCanAffectBasic(skillTemplateId))
		{
			return false;
		}
		sbyte slotCount = GetCombatSkillSlotCountWithGeneric(equipType);
		int require = 0;
		ArraySegmentList<short> skillIds = skillEquipment[equipType];
		for (int i = 0; i < skillIds.Count; i++)
		{
			short skillId = skillIds[i];
			require += GetCombatSkillGridCost(skillId);
			if (skillId == skillTemplateId)
			{
				return require <= slotCount;
			}
		}
		return false;
	}

	private bool GetCombatSkillCanAffectBasic(short skillTemplateId)
	{
		return !IsTaiwu() || DomainManager.Extra.GetConflictCombatSkill(skillTemplateId) == null;
	}

	public GameData.Domains.CombatSkill.CombatSkill LearnNewCombatSkill(DataContext context, short combatSkillTemplateId, ushort readingState)
	{
		CombatSkillKey key = new CombatSkillKey(_id, combatSkillTemplateId);
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(key, out var skill))
		{
			return skill;
		}
		skill = DomainManager.CombatSkill.CreateCombatSkill(_id, combatSkillTemplateId, readingState);
		_learnedCombatSkills.Add(combatSkillTemplateId);
		SetLearnedCombatSkills(_learnedCombatSkills, context);
		DomainManager.Character.TryAutoEquipCombatSkillOnAttainmentPanel(context, _id, combatSkillTemplateId);
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Taiwu.RegisterCombatSkill(context, skill);
			DomainManager.Taiwu.AddLegacyPoint(context, 20);
		}
		return skill;
	}

	private void ReadCombatSkillPage(DataContext context, GameData.Domains.CombatSkill.CombatSkill combatSkill, GameData.Domains.Item.SkillBook skillBook, byte pageId)
	{
		byte pageTypes = skillBook.GetPageTypes();
		ushort readingState = combatSkill.GetReadingState();
		if (pageId == 0)
		{
			sbyte direction = SkillBookStateHelper.GetNormalPageType(pageTypes, pageId);
			byte internalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, pageId);
			readingState = CombatSkillStateHelper.SetPageRead(readingState, internalIndex);
			DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
			DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, _id, skillBook.GetCombatSkillTemplateId(), internalIndex);
		}
		else
		{
			sbyte outlinePageType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
			byte internalIndex2 = CombatSkillStateHelper.GetOutlinePageInternalIndex(outlinePageType);
			readingState = CombatSkillStateHelper.SetPageRead(readingState, internalIndex2);
			DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
			DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, _id, skillBook.GetCombatSkillTemplateId(), internalIndex2);
		}
	}

	public void GetLearnedCombatSkillsFromSect(List<short> result, sbyte orgTemplateId, sbyte minGrade = 0, sbyte maxGrade = 8)
	{
		result.Clear();
		foreach (short skillTemplateId in _learnedCombatSkills)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
			if (skillCfg.SectId == orgTemplateId && skillCfg.Grade >= minGrade && skillCfg.Grade <= maxGrade)
			{
				result.Add(skillTemplateId);
			}
		}
	}

	public sbyte GetLearnedCombatSkillMaxGradeByType(sbyte combatSkillType)
	{
		sbyte grade = 0;
		int i = 0;
		for (int count = _learnedCombatSkills.Count; i < count; i++)
		{
			short templateId = _learnedCombatSkills[i];
			CombatSkillItem skillItem = Config.CombatSkill.Instance[templateId];
			if (skillItem.Type == combatSkillType && skillItem.Grade > grade)
			{
				grade = skillItem.Grade;
			}
		}
		return grade;
	}

	public int GetLearnedCombatSkillTotalValue(sbyte lifeSkillType)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		int totalValue = 0;
		foreach (var (key, combatSkill2) in combatSkills)
		{
			if (combatSkill2.Template.Type == lifeSkillType)
			{
				int baseValue = ItemTemplateHelper.GetBaseValue(10, combatSkill2.Template.BookId);
				int value = baseValue * combatSkill2.GetReadNormalPagesCount() / 5;
				totalValue += value;
			}
		}
		return totalValue;
	}

	public unsafe short GetCombatSkillAttainment(sbyte combatSkillType)
	{
		return GetCombatSkillAttainments().Items[combatSkillType];
	}

	public unsafe short GetCombatSkillQualification(sbyte combatSkillType)
	{
		return GetCombatSkillQualifications().Items[combatSkillType];
	}

	public int GetSkillBreakoutStepsMaxPower(short combatSkillTemplateId)
	{
		GameData.Domains.CombatSkill.CombatSkill combatSkill;
		if (IsTaiwu())
		{
			return DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: _id, skillId: combatSkillTemplateId), out combatSkill) ? combatSkill.GetPlateAddMaxPower() : 0;
		}
		if (IsGearMate)
		{
			GearMate gearMate = DomainManager.Extra.GetGearMateById(_id);
			CombatSkillKey gearMateSkillKey = new CombatSkillKey(_id, combatSkillTemplateId);
			if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(gearMateSkillKey, out var gearMateSkill))
			{
				return 0;
			}
			if (!CombatSkillStateHelper.IsBrokenOut(gearMateSkill.GetActivationState()))
			{
				return 0;
			}
			if (gearMate.LuohanBreakDict != null && gearMate.LuohanBreakDict.TryGetValue(combatSkillTemplateId, out var _))
			{
				return GameData.Domains.Taiwu.SharedMethods.GetLuohanBreakMaxPower(combatSkillTemplateId, GetCombatSkillQualifications());
			}
			if (gearMate.SkillBreakMaxPowerDict.TryGetValue(combatSkillTemplateId, out var maxPower))
			{
				return maxPower;
			}
		}
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[combatSkillTemplateId];
		int percentage = GetSkillBreakoutStepsPercentage(combatSkillTemplateId);
		return skillCfg.SkillBreakPlate.TotalMaxPower * percentage / 100;
	}

	public int GetSkillBreakoutStepsPercentage(short combatSkillTemplateId)
	{
		sbyte stepsCount = GetSkillBreakoutAvailableStepsCount(combatSkillTemplateId);
		return stepsCount * 100 / GlobalConfig.Instance.BreakoutBaseAvailableStepsCount;
	}

	public sbyte GetSkillBreakoutAvailableStepsCount(short combatSkillTemplateId, CombatSkillBreakAvailableStepsDisplayData displayData = null, bool applyCommandBonus = true)
	{
		if (_creatingType != 1)
		{
			sbyte specialNpcSteps = GlobalConfig.Instance.BreakoutSpecialNpcStepsCount;
			if (displayData != null)
			{
				displayData.BaseAvailableSteps = specialNpcSteps;
				displayData.BaseBaseAvailableSteps = specialNpcSteps;
			}
			return specialNpcSteps;
		}
		CombatSkillItem combatSkillConfig = Config.CombatSkill.Instance[combatSkillTemplateId];
		SkillGradeDataItem skillGradeConfig = SkillGradeData.Instance[combatSkillConfig.Grade];
		bool isTaiwu = IsTaiwu();
		short requiredQualification = skillGradeConfig.PracticeQualificationRequirement;
		short qualification = GetCombatSkillQualification(combatSkillConfig.Type);
		if (isTaiwu)
		{
			qualification = DomainManager.Taiwu.GetQualificationWithSectApprovalBonus(combatSkillConfig.SectId, qualification, requiredQualification);
		}
		int availableStepsCount = ((qualification >= requiredQualification) ? GlobalConfig.Instance.BreakoutBaseAvailableStepsCount : ((qualification >= requiredQualification / 2) ? Math.Min(15 * qualification / Math.Max((short)1, requiredQualification), 15) : Math.Min(10 * qualification / Math.Max((short)1, requiredQualification), 10)));
		if (IsTaiwu())
		{
			ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(119 + combatSkillConfig.Type);
			availableStepsCount *= DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(propertyType);
		}
		if (displayData != null)
		{
			displayData.BaseBaseAvailableSteps = (sbyte)availableStepsCount;
		}
		Location location = GetValidLocation();
		if (_creatingType == 1)
		{
			sbyte buildingBonus = (sbyte)DomainManager.Building.GetBuildingBlockEffect(location, EBuildingScaleEffect.BreakOutSteps);
			availableStepsCount += buildingBonus;
			if (displayData != null)
			{
				displayData.BuildingBonus = buildingBonus;
			}
		}
		sbyte consummateLevel = GetEffectiveConsummateLevel();
		sbyte consummateLevelBonus = (sbyte)ConsummateLevel.Instance[consummateLevel].AddBreakStepCount;
		availableStepsCount += consummateLevelBonus;
		if (displayData != null)
		{
			displayData.ConsummateLevelBonus = consummateLevelBonus;
		}
		if (!isTaiwu)
		{
			sbyte interactionGradeBonus = (sbyte)(GetInteractionGrade() - 3);
			availableStepsCount += interactionGradeBonus;
			if (displayData != null)
			{
				displayData.InteractionGradeBonus = interactionGradeBonus;
			}
		}
		else if (combatSkillConfig.SectId != 0)
		{
			short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(combatSkillConfig.SectId);
			Sect sect = DomainManager.Organization.GetElement_Sects(settlementId);
			short approvingRate = sect.CalcApprovingRate();
			if (approvingRate >= 700)
			{
				availableStepsCount += 3;
				if (displayData != null)
				{
					displayData.OrganizationBonus = 3;
				}
			}
		}
		if (applyCommandBonus && DomainManager.Taiwu.TryGetElement_NextBreakoutStepBaseBonus(new CombatSkillKey(_id, -1), out var commandBonus))
		{
			availableStepsCount += commandBonus;
		}
		sbyte finalStepsCount = (sbyte)Math.Clamp(availableStepsCount, GlobalConfig.Instance.BreakoutMinAvailableStepsCount, GlobalConfig.Instance.BreakoutMaxAvailableStepsCount);
		if (displayData != null)
		{
			displayData.BaseAvailableSteps = finalStepsCount;
		}
		return finalStepsCount;
	}

	public unsafe int GetPropertyValue(ECharacterPropertyReferencedType type)
	{
		switch (type)
		{
		case ECharacterPropertyReferencedType.Strength:
		case ECharacterPropertyReferencedType.Dexterity:
		case ECharacterPropertyReferencedType.Concentration:
		case ECharacterPropertyReferencedType.Vitality:
		case ECharacterPropertyReferencedType.Energy:
		case ECharacterPropertyReferencedType.Intelligence:
		{
			MainAttributes mainAttributes = GetMaxMainAttributes();
			int index4 = (int)(0 + type - 0);
			return mainAttributes.Items[index4];
		}
		case ECharacterPropertyReferencedType.AttainmentMusic:
		case ECharacterPropertyReferencedType.AttainmentChess:
		case ECharacterPropertyReferencedType.AttainmentPoem:
		case ECharacterPropertyReferencedType.AttainmentPainting:
		case ECharacterPropertyReferencedType.AttainmentMath:
		case ECharacterPropertyReferencedType.AttainmentAppraisal:
		case ECharacterPropertyReferencedType.AttainmentForging:
		case ECharacterPropertyReferencedType.AttainmentWoodworking:
		case ECharacterPropertyReferencedType.AttainmentMedicine:
		case ECharacterPropertyReferencedType.AttainmentToxicology:
		case ECharacterPropertyReferencedType.AttainmentWeaving:
		case ECharacterPropertyReferencedType.AttainmentJade:
		case ECharacterPropertyReferencedType.AttainmentTaoism:
		case ECharacterPropertyReferencedType.AttainmentBuddhism:
		case ECharacterPropertyReferencedType.AttainmentCooking:
		case ECharacterPropertyReferencedType.AttainmentEclectic:
		{
			ref LifeSkillShorts attainments2 = ref GetLifeSkillAttainments();
			int index3 = (int)(0 + type - 50);
			return attainments2.Items[index3];
		}
		case ECharacterPropertyReferencedType.AttainmentNeigong:
		case ECharacterPropertyReferencedType.AttainmentPosing:
		case ECharacterPropertyReferencedType.AttainmentStunt:
		case ECharacterPropertyReferencedType.AttainmentFistAndPalm:
		case ECharacterPropertyReferencedType.AttainmentFinger:
		case ECharacterPropertyReferencedType.AttainmentLeg:
		case ECharacterPropertyReferencedType.AttainmentThrow:
		case ECharacterPropertyReferencedType.AttainmentSword:
		case ECharacterPropertyReferencedType.AttainmentBlade:
		case ECharacterPropertyReferencedType.AttainmentPolearm:
		case ECharacterPropertyReferencedType.AttainmentSpecial:
		case ECharacterPropertyReferencedType.AttainmentWhip:
		case ECharacterPropertyReferencedType.AttainmentControllableShot:
		case ECharacterPropertyReferencedType.AttainmentCombatMusic:
		{
			ref CombatSkillShorts attainments = ref GetCombatSkillAttainments();
			int index2 = (int)(0 + type - 80);
			return attainments.Items[index2];
		}
		case ECharacterPropertyReferencedType.PersonalityCalm:
		case ECharacterPropertyReferencedType.PersonalityClever:
		case ECharacterPropertyReferencedType.PersonalityEnthusiastic:
		case ECharacterPropertyReferencedType.PersonalityBrave:
		case ECharacterPropertyReferencedType.PersonalityFirm:
		case ECharacterPropertyReferencedType.PersonalityLucky:
		case ECharacterPropertyReferencedType.PersonalityPerceptive:
		{
			Personalities personality = GetPersonalities();
			int index = (int)(0 + type - 94);
			return personality.Items[index];
		}
		case ECharacterPropertyReferencedType.AttainmentDivinePower:
			return DomainManager.Character.GetCharacterDivinePower(_id);
		case ECharacterPropertyReferencedType.AttainmentGhostTechnique:
			return DomainManager.Character.GetCharacterGhostTechnique(_id);
		default:
			throw new Exception($"Cannot get value of character property type {type}");
		}
	}

	public unsafe void ModifyBasePropertyValue(DataContext context, ECharacterPropertyReferencedType type, int delta)
	{
		switch (type)
		{
		case ECharacterPropertyReferencedType.Strength:
		case ECharacterPropertyReferencedType.Dexterity:
		case ECharacterPropertyReferencedType.Concentration:
		case ECharacterPropertyReferencedType.Vitality:
		case ECharacterPropertyReferencedType.Energy:
		case ECharacterPropertyReferencedType.Intelligence:
		{
			int index2 = (int)(0 + type - 0);
			int value2 = _baseMainAttributes.Items[index2] + delta;
			if (value2 < 0)
			{
				value2 = 0;
			}
			_baseMainAttributes.Items[index2] = (short)value2;
			SetBaseMainAttributes(_baseMainAttributes, context);
			break;
		}
		case ECharacterPropertyReferencedType.QualificationMusic:
		case ECharacterPropertyReferencedType.QualificationChess:
		case ECharacterPropertyReferencedType.QualificationPoem:
		case ECharacterPropertyReferencedType.QualificationPainting:
		case ECharacterPropertyReferencedType.QualificationMath:
		case ECharacterPropertyReferencedType.QualificationAppraisal:
		case ECharacterPropertyReferencedType.QualificationForging:
		case ECharacterPropertyReferencedType.QualificationWoodworking:
		case ECharacterPropertyReferencedType.QualificationMedicine:
		case ECharacterPropertyReferencedType.QualificationToxicology:
		case ECharacterPropertyReferencedType.QualificationWeaving:
		case ECharacterPropertyReferencedType.QualificationJade:
		case ECharacterPropertyReferencedType.QualificationTaoism:
		case ECharacterPropertyReferencedType.QualificationBuddhism:
		case ECharacterPropertyReferencedType.QualificationCooking:
		case ECharacterPropertyReferencedType.QualificationEclectic:
		{
			int index3 = (int)(0 + type - 34);
			int value3 = _baseLifeSkillQualifications.Items[index3] + delta;
			if (value3 < 0)
			{
				value3 = 0;
			}
			_baseLifeSkillQualifications.Items[index3] = (short)value3;
			SetBaseLifeSkillQualifications(ref _baseLifeSkillQualifications, context);
			break;
		}
		case ECharacterPropertyReferencedType.QualificationNeigong:
		case ECharacterPropertyReferencedType.QualificationPosing:
		case ECharacterPropertyReferencedType.QualificationStunt:
		case ECharacterPropertyReferencedType.QualificationFistAndPalm:
		case ECharacterPropertyReferencedType.QualificationFinger:
		case ECharacterPropertyReferencedType.QualificationLeg:
		case ECharacterPropertyReferencedType.QualificationThrow:
		case ECharacterPropertyReferencedType.QualificationSword:
		case ECharacterPropertyReferencedType.QualificationBlade:
		case ECharacterPropertyReferencedType.QualificationPolearm:
		case ECharacterPropertyReferencedType.QualificationSpecial:
		case ECharacterPropertyReferencedType.QualificationWhip:
		case ECharacterPropertyReferencedType.QualificationControllableShot:
		case ECharacterPropertyReferencedType.QualificationCombatMusic:
		{
			int index = (int)(0 + type - 66);
			int value = _baseCombatSkillQualifications.Items[index] + delta;
			if (value < 0)
			{
				value = 0;
			}
			_baseCombatSkillQualifications.Items[index] = (short)value;
			SetBaseCombatSkillQualifications(ref _baseCombatSkillQualifications, context);
			break;
		}
		default:
			throw new Exception($"Cannot get value of character property type {type}");
		}
	}

	public static bool IsCharacterIdValid(int charId)
	{
		return charId >= 0;
	}

	public static bool IsOppositeGender(Character characterA, Character characterB)
	{
		return characterA._transgender || characterB.CheckGenderMeetsRequirement(Gender.Flip(characterA._gender));
	}

	public int GetAdjustedResourceSatisfyingThreshold(sbyte resourceType)
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		return memberCfg.GetAdjustedResourceSatisfyingThreshold(resourceType);
	}

	public int GetAdjustedResourceSatisfyingAmount(sbyte resourceType)
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		return memberCfg.GetAdjustedResourceSatisfyingAmount(resourceType);
	}

	public bool IdentifyCanCraftItem(sbyte itemType, short itemTemplateId)
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		return memberCfg.CanCraftItem(itemType, itemTemplateId);
	}

	public int GetExpPerMonth()
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		int expPerMonth = memberCfg.ExpPerMonth;
		if (_organizationInfo.SettlementId >= 0 && OrganizationDomain.IsSect(_organizationInfo.OrgTemplateId))
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
			expPerMonth = expPerMonth * settlement.GetMemberSelfImproveSpeedFactor() / 100;
		}
		return expPerMonth;
	}

	public int GetContributionPerMonth()
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		int contributionPerMonth = memberCfg.ContributionPerMonth;
		if (_organizationInfo.SettlementId >= 0 && OrganizationDomain.IsSect(_organizationInfo.OrgTemplateId))
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
			contributionPerMonth = contributionPerMonth * settlement.GetMemberSelfImproveSpeedFactor() / 100;
		}
		return contributionPerMonth;
	}

	public int GetTotalTreasuryContribution()
	{
		if (_organizationInfo.SettlementId < 0)
		{
			return 0;
		}
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(_organizationInfo);
		return treasury.GetMemberContribution(this);
	}

	public bool OrgAndMonkTypeAllowMarriage()
	{
		int result;
		if (_monkType == 0)
		{
			OrganizationMemberItem orgMemberConfig = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
			if (orgMemberConfig != null)
			{
				sbyte[] childGrade = orgMemberConfig.ChildGrade;
				if (childGrade != null)
				{
					result = ((childGrade.Length > 0) ? 1 : 0);
					goto IL_002e;
				}
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		goto IL_002e;
		IL_002e:
		return (byte)result != 0;
	}

	public sbyte GetLegendaryBookOwnerState()
	{
		if (DomainManager.LegendaryBook.IsLegendaryBookConsumed(_id))
		{
			return 3;
		}
		if (DomainManager.LegendaryBook.GetCharOwnedBookTypes(_id) == null)
		{
			return -1;
		}
		if (_featureIds.Contains(214))
		{
			return 1;
		}
		if (_featureIds.Contains(215))
		{
			return 2;
		}
		return 0;
	}

	public bool IsOwningBook()
	{
		List<sbyte> charOwnedBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(_id);
		return charOwnedBookTypes != null && charOwnedBookTypes.Count > 0;
	}

	public bool IsEscapeCertainly()
	{
		return IsCompletelyInfected() || IsOwningBook();
	}

	public bool IsCreatedWithFixedTemplate()
	{
		return CreatingType.IsFixedPresetType(_creatingType);
	}

	public int GetSrcCharId()
	{
		return _srcCharId;
	}

	public sbyte GetAgeGroup()
	{
		return AgeGroup.GetAgeGroup(_currAge);
	}

	public EMarriageAgeGroup GetMarriageAgeGroup()
	{
		return MarriageAgeGroupHelper.GetMarriageAgeGroup(_currAge);
	}

	public bool CheckGenderMeetsRequirement(sbyte requiredGender)
	{
		return _gender == requiredGender || _transgender;
	}

	public bool CheckSexualOrientationMeetsRequirement(sbyte sexualOrientation)
	{
		return sexualOrientation == -1 || (sexualOrientation == 1 && _bisexual) || (sexualOrientation == 0 && !_bisexual);
	}

	public sbyte GetDisplayingGender()
	{
		return _transgender ? Gender.Flip(_gender) : _gender;
	}

	public sbyte GetInteractionGrade(bool targetIsTaiwu = false)
	{
		if (DomainManager.Taiwu.GetTaiwuCharId() == _id)
		{
			return MathUtils.Clamp(DomainManager.World.GetXiangshuLevel(), (sbyte)0, (sbyte)8);
		}
		return _organizationInfo.GetGrade(targetIsTaiwu);
	}

	public sbyte GetInteractionGrade(Character targetChar)
	{
		int twId = DomainManager.Taiwu.GetTaiwuCharId();
		return (twId == _id) ? MathUtils.Clamp(DomainManager.World.GetXiangshuLevel(), (sbyte)0, (sbyte)8) : _organizationInfo.GetGrade(targetChar != null && targetChar.GetId() == twId);
	}

	public bool IsInTaiwuGroup()
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		return _id == taiwuCharId || _leaderId == taiwuCharId;
	}

	public bool IsTaiwu()
	{
		return _id == DomainManager.Taiwu.GetTaiwuCharId();
	}

	public bool IsInteractableAsIntelligentCharacter()
	{
		return CharacterMatcher.DefValue.CanInteractAsIntelligentCharacter.Match(this);
	}

	public bool IsNaturalDeathForbidden()
	{
		if (_creatingType != 1)
		{
			return true;
		}
		if (DomainManager.Character.IsTemporaryIntelligentCharacter(_id))
		{
			return true;
		}
		if (_featureIds.Contains(680))
		{
			return true;
		}
		if (IsCompletelyInfected())
		{
			return true;
		}
		if (Template.CreatingType == 0 && _location.AreaId == 137)
		{
			return true;
		}
		if (IsActiveExternalRelationState(4uL))
		{
			AdventureRuntime runtime = DomainManager.Adventure.QueryAdventureInLocation(_location);
			if (runtime != null && runtime.GetElementsByTag("AvoidDeathInAdvanceMonth").Any((AdventureElement element) => element.CharacterId == _id))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsTreasuryGuard()
	{
		return GetGroupFeature(691) >= 0;
	}

	public void TryRetireTreasuryGuard(DataContext context)
	{
		if (IsTreasuryGuard() && _organizationInfo.OrgTemplateId >= 0 && OrganizationDomain.IsSect(_organizationInfo.OrgTemplateId) && DomainManager.Organization.TryGetElement_Sects(_organizationInfo.SettlementId, out var sect))
		{
			SettlementLayeredTreasuries treasuries = sect.Treasuries;
			if (treasuries.TryRemoveGuard(_id, out var _))
			{
				RemoveFeatureGroup(context, 691);
				sect.ForceUpdateTreasuryGuards(context);
			}
		}
	}

	public bool NeedToAvoidCombat(CombatType combatType)
	{
		int defeatMarkCount = CombatDomain.GetDefeatMarksCountOutOfCombat(this);
		return defeatMarkCount >= AiHelper.CombatRelatedConstants.AvoidCombatDefeatMarkCount[(int)combatType];
	}

	public bool ReachFallenInCombat(CombatType combatType)
	{
		int defeatMarkCount = CombatDomain.GetDefeatMarksCountOutOfCombat(this);
		return defeatMarkCount >= GlobalConfig.NeedDefeatMarkCount[(int)combatType];
	}

	public unsafe int GetPoisonResist(sbyte poisonType)
	{
		return GetPoisonResists().Items[poisonType];
	}

	public bool HasPoisonImmunity(sbyte poisonType)
	{
		return Config.Character.Instance[_templateId].PoisonImmunities[poisonType] || GetPoisonResist(poisonType) >= 1000 || DomainManager.Extra.HasPoisonImmunity(_id, poisonType);
	}

	public bool HasInnatePoisonImmunity(sbyte poisonType)
	{
		return Config.Character.Instance[_templateId].PoisonImmunities[poisonType] || DomainManager.Extra.HasPoisonImmunity(_id, poisonType);
	}

	public bool HasAcquiredPoisonImmunity(sbyte poisonType)
	{
		return GetPoisonResist(poisonType) >= 1000;
	}

	public unsafe int GetPoisonMarkCount()
	{
		int count = 0;
		CharacterItem characterCfg = Config.Character.Instance[_templateId];
		byte poisonImmunities = DomainManager.Extra.GetPoisonImmunities(_id);
		ref PoisonInts poisonResists = ref GetPoisonResists();
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			if (!SharedMethods.HasPoisonImmunity(poisonType, characterCfg, ref poisonResists, poisonImmunities))
			{
				count += PoisonsAndLevels.CalcPoisonedLevel(_poisoned.Items[poisonType]);
			}
		}
		return count;
	}

	public unsafe int GetNormalWugCount()
	{
		int count = 0;
		ref EatingItems eatingItems = ref GetEatingItems();
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (EatingItems.IsWug(itemKey) && !EatingItems.IsWugKing(itemKey))
			{
				count++;
			}
		}
		return count;
	}

	public sbyte GetRandomInjuredBodyPartToHeal(IRandomSource random, bool isInnerInjury, sbyte maxVal)
	{
		List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		bodyPartRandomPool.Clear();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			var (outer, inner) = _injuries.Get(bodyPart);
			if (isInnerInjury)
			{
				if (inner > 0 && inner <= maxVal)
				{
					bodyPartRandomPool.Add(bodyPart);
				}
			}
			else if (outer > 0 && outer <= maxVal)
			{
				bodyPartRandomPool.Add(bodyPart);
			}
		}
		int selectedBodyPart = ((bodyPartRandomPool.Count > 0) ? bodyPartRandomPool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(bodyPartRandomPool);
		return (sbyte)selectedBodyPart;
	}

	public unsafe sbyte GetRandomPoisonTypeToDetox(IRandomSource random, int maxLevel)
	{
		List<sbyte> poisonTypeRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		poisonTypeRandomPool.Clear();
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			int poisoned = _poisoned.Items[poisonType];
			sbyte level = PoisonsAndLevels.CalcPoisonedLevel(poisoned);
			if (_poisoned.Items[poisonType] > 0 && level <= maxLevel)
			{
				poisonTypeRandomPool.Add(poisonType);
			}
		}
		int selectedPoisonType = ((poisonTypeRandomPool.Count > 0) ? poisonTypeRandomPool.GetRandom(random) : (-1));
		ObjectPool<List<sbyte>>.Instance.Return(poisonTypeRandomPool);
		return (sbyte)selectedPoisonType;
	}

	public unsafe void TakeRandomDamage(DataContext context, int damage)
	{
		IRandomSource random = context.Random;
		Span<sbyte> span = stackalloc sbyte[14];
		SpanList<sbyte> injuryPartRandomPool = span;
		injuryPartRandomPool.Clear();
		for (sbyte part = 0; part < 14; part++)
		{
			if (_injuries.Items[part] < 6)
			{
				injuryPartRandomPool.Add(part);
			}
		}
		for (int i = 0; i < damage; i++)
		{
			if (injuryPartRandomPool.Count == 0)
			{
				break;
			}
			int index = random.Next(injuryPartRandomPool.Count);
			sbyte part2 = injuryPartRandomPool[index];
			ref sbyte reference = ref _injuries.Items[part2];
			reference++;
			if (_injuries.Items[part2] >= 6)
			{
				injuryPartRandomPool.RemoveAt(index);
			}
		}
		SetInjuries(_injuries, context);
	}

	public unsafe void TakeDamageRandomParts(DataContext context, int damage, bool innerInjury)
	{
		IRandomSource random = context.Random;
		Span<sbyte> span = stackalloc sbyte[14];
		SpanList<sbyte> injuryPartRandomPool = span;
		injuryPartRandomPool.Clear();
		for (sbyte part = 0; part < 14; part++)
		{
			if (_injuries.Items[part] < 6)
			{
				injuryPartRandomPool.Add(part);
			}
		}
		for (int i = 0; i < damage; i++)
		{
			if (injuryPartRandomPool.Count == 0)
			{
				break;
			}
			int index = random.Next(injuryPartRandomPool.Count / 2);
			index = index * 2 + (innerInjury ? 1 : 0);
			sbyte part2 = injuryPartRandomPool[index];
			ref sbyte reference = ref _injuries.Items[part2];
			reference++;
			if (_injuries.Items[part2] >= 6)
			{
				injuryPartRandomPool.RemoveAt(index);
			}
		}
		SetInjuries(_injuries, context);
	}

	public void ReduceRandomDamage(DataContext context, int reduceCount)
	{
		List<sbyte> outerPool = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> innerPool = ObjectPool<List<sbyte>>.Instance.Get();
		for (int i = 0; i < reduceCount; i++)
		{
			outerPool.Clear();
			innerPool.Clear();
			CRandom.GenerateValueInjuryPool(_injuries, innerPool, outerPool);
			if (outerPool.Count == 0 && innerPool.Count == 0)
			{
				break;
			}
			bool isInner = context.Random.RandomIsInner(innerPool.Count > 0, outerPool.Count > 0);
			List<sbyte> pool = (isInner ? innerPool : outerPool);
			sbyte bodyPart = pool.GetRandom(context.Random);
			_injuries.Change(bodyPart, isInner, -1);
		}
		ObjectPool<List<sbyte>>.Instance.Return(outerPool);
		ObjectPool<List<sbyte>>.Instance.Return(innerPool);
		SetInjuries(_injuries, context);
	}

	public void TakeRandomDamage(DataContext context, int damage, bool isInnerInjury)
	{
		IRandomSource random = context.Random;
		Span<sbyte> span = stackalloc sbyte[7];
		SpanList<sbyte> injuryPartRandomPool = span;
		injuryPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			if (_injuries.Get(part, isInnerInjury) < 6)
			{
				injuryPartRandomPool.Add(part);
			}
		}
		for (int i = 0; i < damage; i++)
		{
			if (injuryPartRandomPool.Count == 0)
			{
				break;
			}
			int index = random.Next(injuryPartRandomPool.Count);
			sbyte part2 = injuryPartRandomPool[index];
			_injuries.Change(part2, isInnerInjury, 1);
			if (_injuries.Get(part2, isInnerInjury) >= 6)
			{
				injuryPartRandomPool.RemoveAt(index);
			}
		}
		SetInjuries(_injuries, context);
	}

	public int GetBirthDate()
	{
		return CharacterDomain.CalcBirthDate(_actualAge, _birthMonth);
	}

	public short GetLeftMaxHealth()
	{
		if (_srcCharId >= 0)
		{
			return GetMaxHealth();
		}
		int livedMonths = ((!IsCompletelyInfected()) ? CharacterDomain.GetLivedMonths(_currAge, _birthMonth) : (_currAge * 12));
		return (short)Math.Clamp(0, GetMaxHealth() - livedMonths, 32767);
	}

	public EHealthType GetHealthType()
	{
		return HealthTypeHelper.CalcType(_featureIds, _health, GetLeftMaxHealth());
	}

	public static bool GetMakeLoveRole(IRandomSource random, ref Character father, ref Character mother)
	{
		bool fatherIsDualGender = father.GetFeatureIds().Contains(170);
		bool motherIsDualGender = mother.GetFeatureIds().Contains(170);
		if (!fatherIsDualGender && !motherIsDualGender && father.GetGender() == mother.GetGender())
		{
			return false;
		}
		if (1 == 0)
		{
		}
		bool flag = ((!fatherIsDualGender) ? (father.GetGender() == 0) : ((!motherIsDualGender) ? (mother.GetGender() != 0) : random.CheckPercentProb(50)));
		if (1 == 0)
		{
		}
		if (flag)
		{
			Character character = mother;
			Character character2 = father;
			father = character;
			mother = character2;
		}
		return true;
	}

	public static bool CheckMakeLoveRole(Character father, Character mother)
	{
		return (father.GetGender() == 1 || father.GetFeatureIds().Contains(170)) && (mother.GetGender() == 0 || mother.GetFeatureIds().Contains(170));
	}

	public void MakeLove(DataContext context, Character targetChar, bool isRape)
	{
		Character father = this;
		Character mother = targetChar;
		GetMakeLoveRole(context.Random, ref father, ref mother);
		bool isPregnant = OfflineMakeLove(context.Random, father, mother, isRape);
		father.SetFeatureIds(father._featureIds, context);
		mother.SetFeatureIds(mother._featureIds, context);
		PeriAdvanceMonthFixedActionModification.MakeLoveState state = (isRape ? PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeSucceed : ((!DomainManager.Character.HasRelation(father.GetId(), mother.GetId(), 1024)) ? PeriAdvanceMonthFixedActionModification.MakeLoveState.Illegal : PeriAdvanceMonthFixedActionModification.MakeLoveState.Legal));
		Events.RaiseMakeLove(context, father, mother, (sbyte)state);
		if (isPregnant)
		{
			DomainManager.Character.CreatePregnantState(context, mother, father, isRape);
		}
	}

	public short CalcChangedHealth(short health, int delta)
	{
		short leftMaxHealth = GetLeftMaxHealth();
		CValueModify modify = CalcHealthDelta(delta);
		return (short)((leftMaxHealth >= 0) ? ((short)Math.Clamp(health * modify, 0, leftMaxHealth)) : 0);
	}

	public void ChangeHealth(DataContext context, int delta)
	{
		_health = CalcChangedHealth(_health, delta);
		SetHealth(_health, context);
		if (IsTaiwu() && delta < 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 331);
		}
	}

	public void ChangeBaseMaxHealth(DataContext context, int delta, bool autoAdjustHealth = true)
	{
		short leftMaxHealthBefore = GetLeftMaxHealth();
		short value = (short)Math.Clamp(_baseMaxHealth + delta, 0, 32767);
		SetBaseMaxHealth(value, context);
		if (autoAdjustHealth)
		{
			short leftMaxHealthAfter = GetLeftMaxHealth();
			if (leftMaxHealthAfter != leftMaxHealthBefore)
			{
				ChangeHealth(context, leftMaxHealthAfter - leftMaxHealthBefore);
			}
		}
	}

	public void ChangeCurrAge(DataContext context, int delta)
	{
		sbyte prevAgeGroup = GetAgeGroup();
		short oldAge = _currAge;
		short newAge = (short)Math.Clamp(_currAge + delta, 0, 2730);
		SetCurrAge(newAge, context);
		Events.RaiseCharacterAgeChanged(context, this, oldAge, newAge);
		sbyte currAgeGroup = GetAgeGroup();
		if (prevAgeGroup != currAgeGroup)
		{
			ReAdjustClothingByAge(context);
		}
	}

	public void ReAdjustClothingByAge(DataContext context)
	{
		sbyte ageGroup = GetAgeGroup();
		short currClothingTemplateId = _equipment[4].TemplateId;
		if (currClothingTemplateId >= 0)
		{
			ClothingItem clothingCfg = Config.Clothing.Instance[currClothingTemplateId];
			if (clothingCfg.AgeGroup == ageGroup)
			{
				return;
			}
			if (clothingCfg.Detachable)
			{
				ChangeEquipment(context, 4, -1, ItemKey.Invalid);
			}
		}
		if (1 == 0)
		{
		}
		short num = ageGroup switch
		{
			0 => 64, 
			1 => 65, 
			_ => OrganizationDomain.GetRandomOrgMemberClothing(context.Random, OrganizationDomain.GetOrgMemberConfig(_organizationInfo)), 
		};
		if (1 == 0)
		{
		}
		short newClothingTemplateId = num;
		ForceReplaceClothing(context, newClothingTemplateId);
	}

	public int CalcHealthDeltaAfterSpecialEffect(DataContext context, int delta)
	{
		int percent = 100 + DomainManager.SpecialEffect.GetModifyValue(_id, 54, EDataModifyType.AddPercent);
		delta = delta * percent / 100;
		return delta;
	}

	public CValueModify CalcHealthDelta(int delta)
	{
		CValuePercentBonus bonus = 0;
		if (delta > 0)
		{
			foreach (short id in _featureIds)
			{
				bonus += (CValuePercentBonus)CharacterFeature.Instance[id].HealthRecovery;
			}
		}
		else if (delta < 0)
		{
			bonus += (CValuePercentBonus)DomainManager.SpecialEffect.GetModifyValue(_id, 54, EDataModifyType.AddPercent);
			bonus -= (CValuePercentBonus)DomainManager.Building.GetBuildingBlockEffect(_location, EBuildingScaleEffect.HealthDecreaseReduction);
		}
		return new CValueModify(delta * bonus.StaySymbol());
	}

	public void AdjustLifespan(DataContext context)
	{
		int factor = DomainManager.World.GetCharacterLifeSpanFactor();
		int extraLifespanThreshold = 36 * factor / 100;
		for (int owedLifespan = CharacterDomain.GetLivedMonths(_actualAge, _birthMonth) + extraLifespanThreshold - GetMaxHealth(); owedLifespan > 0; owedLifespan = CharacterDomain.GetLivedMonths(_actualAge, _birthMonth) + extraLifespanThreshold - GetMaxHealth())
		{
			int bonus = 84 * factor / 100;
			int baseMaxHealth = _baseMaxHealth + owedLifespan + context.Random.Next(bonus);
			if (baseMaxHealth > 32767)
			{
				SetBaseMaxHealth(short.MaxValue, context);
				break;
			}
			SetBaseMaxHealth((short)baseMaxHealth, context);
		}
		short leftMaxHealth = GetLeftMaxHealth();
		if (leftMaxHealth < 0)
		{
			throw new Exception($"Character {_id}: left max health must equal or greater than zero");
		}
		_health = Math.Clamp(_health, (short)0, leftMaxHealth);
		SetHealth(_health, context);
	}

	public void GetTitles(List<short> titleIds)
	{
		switch (GetXiangshuType())
		{
		case 1:
			titleIds.Add(0);
			break;
		case 2:
			titleIds.Add(1);
			break;
		case 3:
			titleIds.Add(2);
			break;
		}
		List<sbyte> bookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(_id);
		if (bookTypes != null)
		{
			int i = 0;
			for (int count = bookTypes.Count; i < count; i++)
			{
				sbyte bookType = bookTypes[i];
				short titleId = (short)(3 + bookType);
				titleIds.Add(titleId);
			}
		}
		DomainManager.Character.FillCharacterExtraTitles(_id, titleIds);
	}

	public bool HasTitle(short templateId)
	{
		switch (templateId)
		{
		case 0:
			return GetXiangshuType() == 1;
		case 1:
			return GetXiangshuType() == 2;
		case 2:
			return GetXiangshuType() == 3;
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
		case 15:
		case 16:
			return DomainManager.LegendaryBook.GetCharOwnedBookTypes(_id)?.Contains((sbyte)(templateId - 3)) ?? false;
		default:
			return DomainManager.Character.GetExtraTitleExpireDate(_id, templateId) >= 0;
		}
	}

	public unsafe void ChangeBaseMainAttributes(DataContext context, MainAttributes delta)
	{
		for (int i = 0; i < 6; i++)
		{
			int value = _baseMainAttributes.Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			_baseMainAttributes.Items[i] = (short)value;
		}
		SetBaseMainAttributes(_baseMainAttributes, context);
	}

	public void ChangeBaseMainAttribute(DataContext context, sbyte mainAttributeType, short delta)
	{
		Tester.Assert(mainAttributeType >= 0 && mainAttributeType < 6);
		_baseMainAttributes[mainAttributeType] = (short)Math.Clamp(_baseMainAttributes[mainAttributeType] + delta, 0, GlobalConfig.Instance.MaxValueOfMaxMainAttributes);
		SetBaseMainAttributes(_baseMainAttributes, context);
	}

	public unsafe sbyte GetPersonality(sbyte personalityType)
	{
		Personalities personalities = GetPersonalities();
		return personalities.Items[personalityType];
	}

	public unsafe short GetMaxMainAttribute(sbyte mainAttributeType)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		return mainAttributes.Items[mainAttributeType];
	}

	public unsafe short GetCurrMainAttribute(sbyte mainAttributeType)
	{
		MainAttributes currMainAttributes = GetCurrMainAttributes();
		return currMainAttributes.Items[mainAttributeType];
	}

	public void ChangeCurrMainAttribute(DataContext context, sbyte mainAttributeType, int delta)
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		_currMainAttributes[mainAttributeType] = (short)Math.Clamp(_currMainAttributes[mainAttributeType] + delta, 0, maxMainAttributes[mainAttributeType]);
		SetCurrMainAttributes(_currMainAttributes, context);
		if (IsTaiwu() && delta < 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 265);
		}
	}

	public unsafe void ChangeCurrMainAttributes(DataContext context, MainAttributes delta)
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		for (sbyte i = 0; i < 6; i++)
		{
			_currMainAttributes.Items[i] = (short)Math.Clamp(_currMainAttributes.Items[i] + delta.Items[i], 0, maxMainAttributes.Items[i]);
		}
		SetCurrMainAttributes(_currMainAttributes, context);
	}

	public unsafe void ChangeBaseLifeSkillQualifications(DataContext context, ref LifeSkillShorts delta)
	{
		for (int i = 0; i < 16; i++)
		{
			int value = _baseLifeSkillQualifications.Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			_baseLifeSkillQualifications.Items[i] = (short)value;
		}
		SetBaseLifeSkillQualifications(ref _baseLifeSkillQualifications, context);
	}

	public unsafe void ChangeBaseLifeSkillQualification(DataContext context, sbyte skillType, int delta)
	{
		Tester.Assert(skillType >= 0 && skillType < 16);
		_baseLifeSkillQualifications.Items[skillType] = (short)Math.Clamp(_baseLifeSkillQualifications.Items[skillType] + delta, 0, 32767);
		SetBaseLifeSkillQualifications(ref _baseLifeSkillQualifications, context);
	}

	public unsafe void ChangeBaseCombatSkillQualifications(DataContext context, ref CombatSkillShorts delta)
	{
		for (int i = 0; i < 14; i++)
		{
			int value = _baseCombatSkillQualifications.Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			_baseCombatSkillQualifications.Items[i] = (short)value;
		}
		SetBaseCombatSkillQualifications(ref _baseCombatSkillQualifications, context);
	}

	public unsafe void ChangeBaseCombatSkillQualification(DataContext context, sbyte skillType, int delta)
	{
		Tester.Assert(skillType >= 0 && skillType < 14);
		_baseCombatSkillQualifications.Items[skillType] = (short)Math.Clamp(_baseCombatSkillQualifications.Items[skillType] + delta, 0, 32767);
		SetBaseCombatSkillQualifications(ref _baseCombatSkillQualifications, context);
	}

	public sbyte GetLifeSkillQualificationAgeAdjust()
	{
		short clampedAge = QualificationAge;
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		sbyte lifeSkillQualificationGrowthType = _lifeSkillQualificationGrowthType;
		if (1 == 0)
		{
		}
		sbyte result = lifeSkillQualificationGrowthType switch
		{
			0 => ageEffectCfg.SkillQualificationAverage, 
			1 => ageEffectCfg.SkillQualificationPrecocious, 
			2 => ageEffectCfg.SkillQualificationLateBlooming, 
			_ => throw new Exception($"Unsupported GrowthType {_lifeSkillQualificationGrowthType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public sbyte GetCombatSkillQualificationAgeAdjust()
	{
		short clampedAge = QualificationAge;
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		sbyte combatSkillQualificationGrowthType = _combatSkillQualificationGrowthType;
		if (1 == 0)
		{
		}
		sbyte result = combatSkillQualificationGrowthType switch
		{
			0 => ageEffectCfg.SkillQualificationAverage, 
			1 => ageEffectCfg.SkillQualificationPrecocious, 
			2 => ageEffectCfg.SkillQualificationLateBlooming, 
			_ => throw new Exception($"Unsupported GrowthType {_lifeSkillQualificationGrowthType}"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public sbyte GetBodyType()
	{
		return _avatar.GetBodyType();
	}

	public void SetBodyType(DataContext context, sbyte bodyType)
	{
		_avatar.ChangeBodyType(bodyType);
		SetAvatar(_avatar, context);
	}

	public sbyte GetHappinessType()
	{
		return HappinessType.GetHappinessType(_happiness);
	}

	public void ChangeHappiness(DataContext context, int delta)
	{
		_happiness = (sbyte)Math.Clamp(_happiness + delta, -119, 119);
		SetHappiness(_happiness, context);
		Events.RaiseHappinessChanged(context, this);
	}

	public sbyte GetBehaviorType()
	{
		return BehaviorType.GetBehaviorType(GetMorality());
	}

	public short GetFixedMorality()
	{
		sbyte ownerState = GetLegendaryBookOwnerState();
		if (ownerState == 1 || _featureIds.Contains(210))
		{
			return -250;
		}
		if (ownerState >= 2 || _featureIds.Contains(211))
		{
			return -438;
		}
		for (int i = 0; i < _featureIds.Count; i++)
		{
			switch (_featureIds[i])
			{
			case 740:
				return 250;
			case 741:
				return -250;
			}
		}
		if (GetCreatingType() == 1 && !IsTaiwu())
		{
			Location forceRebelLocation = DomainManager.Character.GetForceRebelLocation();
			if (forceRebelLocation.IsValid() && forceRebelLocation.AreaId == _location.AreaId)
			{
				byte areaData = DomainManager.Map.GetAreaSize(_location.AreaId);
				ByteCoordinate forceRebelCoordinate = ByteCoordinate.IndexToCoordinate(forceRebelLocation.BlockId, areaData);
				ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaData);
				if (forceRebelCoordinate.GetManhattanDistance(selfCoordinate) <= 3)
				{
					return -250;
				}
			}
			Location forceKindLocation = DomainManager.Character.GetForceKindLocation();
			if (forceKindLocation.IsValid() && forceKindLocation.AreaId == _location.AreaId)
			{
				byte areaData2 = DomainManager.Map.GetAreaSize(_location.AreaId);
				ByteCoordinate forceKindCoordinate = ByteCoordinate.IndexToCoordinate(forceKindLocation.BlockId, areaData2);
				ByteCoordinate selfCoordinate2 = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaData2);
				if (forceKindCoordinate.GetManhattanDistance(selfCoordinate2) <= 3)
				{
					return 250;
				}
			}
		}
		return short.MaxValue;
	}

	public void ChangeBaseMorality(DataContext context, int delta)
	{
		_baseMorality = (short)Math.Clamp(_baseMorality + delta, -500, 500);
		SetBaseMorality(_baseMorality, context);
	}

	public void ChangeHobby(DataContext context)
	{
		OfflineChangeHobby(context.Random);
		CommitChangingHobby(context);
	}

	public void ChangeLovingItem(DataContext context)
	{
		short lovingItemSubType = GenerateRandomHobby(context.Random).lovingItemSubType;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(_id, DomainManager.Taiwu.GetTaiwuCharId()));
		bool needResetRevealedHobbies = false;
		if (favorabilityType < 3)
		{
			SetLovingItemRevealed(lovingItemRevealed: false, context);
		}
		else if (DomainManager.Extra.IsCharacterLovingItemRevealed(_id))
		{
			needResetRevealedHobbies = true;
		}
		_lovingItemSubType = (short)((lovingItemSubType == _hatingItemSubType) ? (-1) : lovingItemSubType);
		SetLovingItemSubType(_lovingItemSubType, context);
		if (needResetRevealedHobbies)
		{
			DomainManager.Extra.SetCharacterRevealedHobbies(context, _id, isLovingItem: true);
		}
	}

	public void ChangeHatingItem(DataContext context)
	{
		short hatingItemSubType = GenerateRandomHobby(context.Random).hatingItemSubType;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(_id, DomainManager.Taiwu.GetTaiwuCharId()));
		bool needResetRevealedHobbies = false;
		if (favorabilityType < 3)
		{
			SetHatingItemRevealed(hatingItemRevealed: false, context);
		}
		else if (DomainManager.Extra.IsCharacterHatingItemRevealed(_id))
		{
			needResetRevealedHobbies = true;
		}
		_hatingItemSubType = (short)((hatingItemSubType == _lovingItemSubType) ? (-1) : hatingItemSubType);
		SetHatingItemSubType(_hatingItemSubType, context);
		if (needResetRevealedHobbies)
		{
			DomainManager.Extra.SetCharacterRevealedHobbies(context, _id, isLovingItem: false);
		}
	}

	public void UpdateHobbyExpirationDate(DataContext context)
	{
		OfflineUpdateHobbyExpirationDate();
		SetHobbyExpirationDate(_hobbyExpirationDate, context);
	}

	public int GetCharacterWorth()
	{
		throw new NotImplementedException();
	}

	public bool CanBeXiangshuInfected()
	{
		sbyte grade = (sbyte)((_id != DomainManager.Taiwu.GetTaiwuCharId()) ? _organizationInfo.Grade : 0);
		sbyte threshold = DomainManager.World.GetMaxGradeOfXiangshuInfection();
		return grade <= threshold;
	}

	public bool CanHaveProfession()
	{
		return GetAgeGroup() == 2;
	}

	public void ChangeXiangshuInfection(DataContext context, int delta)
	{
		_xiangshuInfection = (byte)Math.Clamp(_xiangshuInfection + delta, 0, 200);
		SetXiangshuInfection(_xiangshuInfection, context);
	}

	public void UpdateXiangshuInfectionState(DataContext context)
	{
		if (!TryGetInfectionFeatureIdThatShouldBe(out var featureId))
		{
			return;
		}
		bool flag = _id == DomainManager.Taiwu.GetTaiwuCharId();
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3 = ((featureId == 211 || featureId == 814) ? true : false);
			flag2 = flag3;
		}
		if (!flag2)
		{
			AddFeature(context, featureId, removeMutexFeature: true);
			if (_creatingType == 1)
			{
				Events.RaiseXiangshuInfectionFeatureChanged(context, this, featureId);
			}
		}
	}

	private bool TryGetInfectionFeatureIdThatShouldBe(out short featureId)
	{
		short prevFeatureId = GetGroupFeature(209);
		if (prevFeatureId == 802)
		{
			featureId = prevFeatureId;
			return false;
		}
		featureId = XiangshuInfectionTypeHelper.GetInfectionFeatureIdThatShouldBe(_xiangshuInfection);
		if (prevFeatureId == featureId)
		{
			return false;
		}
		if (featureId == 209 || featureId == 210)
		{
			return true;
		}
		if (prevFeatureId == 814)
		{
			featureId = prevFeatureId;
			return false;
		}
		if (_featureIds.Contains(733))
		{
			return false;
		}
		return true;
	}

	public void ChangeExp(DataContext context, int delta)
	{
		_exp = Math.Clamp(_exp + delta, 0, 999999999);
		SetExp(_exp, context);
		if (IsTaiwu() && delta > 0)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 302);
		}
	}

	public unsafe int GetResource(sbyte resourceType)
	{
		return _resources.Items[resourceType];
	}

	public unsafe void SpecifyResource(DataContext context, sbyte resourceType, int value)
	{
		if (value < 0)
		{
			throw new Exception($"{_id}'s resource amount cannot be negative: {resourceType}, {value}");
		}
		_resources.Items[resourceType] = value;
		SetResources(ref _resources, context);
	}

	public unsafe void SpecifyResources(DataContext context, ref ResourceInts values)
	{
		for (int i = 0; i < 8; i++)
		{
			int value = values.Items[i];
			if (value < 0)
			{
				throw new Exception($"{_id}'s resource amount cannot be negative: {i}, {value}");
			}
			_resources.Items[i] = value;
		}
		SetResources(ref _resources, context);
	}

	public unsafe void ChangeResource(DataContext context, sbyte resourceType, int delta)
	{
		int value = _resources.Items[resourceType] + delta;
		if (value < 0)
		{
			AdaptableLog.TagWarning("Character", $"{_id}'s resource amount cannot be negative: {resourceType}, {value} (delta {delta})\n{Environment.StackTrace}");
			value = 0;
		}
		else if (value > 999999999)
		{
			value = 999999999;
		}
		_resources.Items[resourceType] = value;
		SetResources(ref _resources, context);
		if (delta > 0 && _id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			ResourceInvokeGuidingTrigger(context, resourceType);
		}
	}

	public unsafe void ChangeResources(DataContext context, ref ResourceInts delta)
	{
		for (int i = 0; i < 8; i++)
		{
			int value = _resources.Items[i] + delta.Items[i];
			if (value < 0)
			{
				AdaptableLog.TagWarning("Character", $"{_id}'s resource amount cannot be negative: {i}, {value} (delta {delta})\n{Environment.StackTrace}");
				value = 0;
			}
			else if (value > 999999999)
			{
				value = 999999999;
			}
			_resources.Items[i] = value;
		}
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			for (sbyte resourceType = 0; resourceType < 8; resourceType++)
			{
				int resourceDelta = _resources.Items[resourceType];
				if (resourceDelta > 0)
				{
					ResourceInvokeGuidingTrigger(context, resourceType);
				}
			}
		}
		SetResources(ref _resources, context);
	}

	private void ResourceInvokeGuidingTrigger(DataContext context, sbyte resourceType)
	{
		DomainManager.Global.InvokeGuidingTrigger(context, 25);
		switch (resourceType)
		{
		case 6:
			DomainManager.Global.InvokeGuidingTrigger(context, 26);
			break;
		case 7:
			DomainManager.Global.InvokeGuidingTrigger(context, 27);
			break;
		}
	}

	public bool CheckResources(DataContext context, ref ResourceInts resource)
	{
		return _resources.CheckIsMeet(ref resource);
	}

	public bool CheckResources(DataContext context, sbyte type, int value)
	{
		return _resources.CheckIsMeet(type, value);
	}

	public unsafe void ChangeResourceWithoutChecking(DataContext context, sbyte resourceType, int delta)
	{
		int value = _resources.Items[resourceType] + delta;
		if (value < 0)
		{
			value = 0;
		}
		_resources.Items[resourceType] = value;
		SetResources(ref _resources, context);
	}

	public unsafe void ChangeResourcesWithoutChecking(DataContext context, ref ResourceInts delta)
	{
		for (int i = 0; i < 8; i++)
		{
			int value = _resources.Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			_resources.Items[i] = value;
		}
		SetResources(ref _resources, context);
	}

	public Location GetValidLocation()
	{
		if (_location.IsValid())
		{
			return _location;
		}
		if (_kidnapperId >= 0)
		{
			if (DomainManager.Character.TryGetElement_Objects(_kidnapperId, out var kidnapper))
			{
				Location kidnapperLocation = kidnapper.GetLocation();
				if (kidnapperLocation.IsValid())
				{
					return kidnapperLocation;
				}
				if (kidnapper._kidnapperId >= 0)
				{
					throw new Exception($"Nested kidnapping detected: {this} => {_kidnapperId} => {kidnapper._kidnapperId}.");
				}
				return kidnapper.GetValidLocation();
			}
			Grave kidnapperGrave = DomainManager.Character.GetElement_Graves(_kidnapperId);
			return kidnapperGrave.GetLocation();
		}
		if (IsActiveExternalRelationState(32uL))
		{
			sbyte orgTemplateId = DomainManager.Organization.GetPrisonerSect(_id);
			Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
			return settlement.GetLocation();
		}
		if (DomainManager.Character.TryGetElement_CrossAreaMoveInfos((_leaderId >= 0) ? _leaderId : _id, out var crossAreaMoveInfos))
		{
			Location location = DomainManager.Map.CrossAreaTravelInfoToLocation(crossAreaMoveInfos);
			if (location.IsValid())
			{
				return location;
			}
			throw new Exception($"Character {this} is traveling outside of the planned route.");
		}
		if (DomainManager.Taiwu.GetTaiwuCharId() == _id || DomainManager.Taiwu.IsInGroup(_id))
		{
			if (DomainManager.Adventure.GetAdventureTaiwu().InAdventure)
			{
				return DomainManager.Adventure.GetAdventureTaiwu().Adventure.MapLocation;
			}
			return DomainManager.Map.GetTravelCurrLocation();
		}
		if (DomainManager.Extra.GetKidnappedTravelData().HunterCharId == _id)
		{
			return DomainManager.Map.GetTravelCurrLocation();
		}
		throw new Exception($"Character {this} is in invalid location for unknown reasons.");
	}

	public bool IsMoralityLocked()
	{
		sbyte ownerState = GetLegendaryBookOwnerState();
		if (ownerState == 1 || _featureIds.Contains(210))
		{
			return true;
		}
		if (ownerState >= 2 || _featureIds.Contains(211))
		{
			return true;
		}
		Location forceRebelLocation = DomainManager.Character.GetForceRebelLocation();
		if (IsNearbyLocation(forceRebelLocation, 3))
		{
			return true;
		}
		Location forceKindLocation = DomainManager.Character.GetForceKindLocation();
		if (IsNearbyLocation(forceKindLocation, 3))
		{
			return true;
		}
		return false;
	}

	public bool IsNearbyLocation(Location location, int steps)
	{
		if (!location.IsValid())
		{
			return false;
		}
		if (location.AreaId != _location.AreaId)
		{
			return false;
		}
		byte areaData = DomainManager.Map.GetAreaSize(_location.AreaId);
		ByteCoordinate targetCoordinate = ByteCoordinate.IndexToCoordinate(location.BlockId, areaData);
		ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaData);
		return targetCoordinate.GetManhattanDistance(selfCoordinate) <= steps;
	}

	public bool IsForbiddenToDrinkingWines()
	{
		return Config.Organization.Instance[_organizationInfo.OrgTemplateId].NoDrinking || IsMonkType(2);
	}

	public bool IsForbiddenToEatMeat()
	{
		return Config.Organization.Instance[_organizationInfo.OrgTemplateId].NoMeatEating || _monkType != 0;
	}

	public bool IsMonkType(byte monkType)
	{
		return (_monkType & monkType) != 0;
	}

	public void BecomeMonkType(DataContext context, byte monkType)
	{
		Tester.Assert((monkType & 0x80) == 0);
		_monkType |= monkType;
		SetMonkType(_monkType, context);
	}

	public void RemoveMonkType(DataContext context, byte monkType)
	{
		Tester.Assert((monkType & 0x80) == 0);
		Tester.Assert((_monkType & 0x80) == 0);
		_monkType &= (byte)(~monkType);
		SetMonkType(_monkType, context);
	}

	public bool IsActiveExternalRelationState(ulong type)
	{
		return (_externalRelationState & type) != 0;
	}

	public void ActiveExternalRelationState(DataContext context, ulong type)
	{
		_externalRelationState |= type;
		SetExternalRelationState(_externalRelationState, context);
	}

	public bool SetDisableAiMove(DataContext context, bool disableAiMove)
	{
		bool isActive = IsActiveExternalRelationState(64uL);
		if (disableAiMove)
		{
			if (!isActive)
			{
				ActiveExternalRelationState(context, 64uL);
			}
		}
		else if (isActive)
		{
			DeactivateExternalRelationState(context, 64uL);
		}
		return true;
	}

	public int GetKidnappingEnemyNestAdventure()
	{
		AdventureRuntime adventure = GetKidnappingAdventure();
		if (adventure == null || EnemyNest.Instance.All((EnemyNestItem x) => x.AdventureId != adventure.CoreId))
		{
			return 0;
		}
		return adventure.CoreId;
	}

	public AdventureRuntime GetKidnappingAdventure()
	{
		if (!IsActiveExternalRelationState(4uL))
		{
			return null;
		}
		foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInLocation(_location))
		{
			if (!(runtime is AdventureRuntime adventure))
			{
				continue;
			}
			foreach (AdventureElement element in adventure.GetElementsByTag("CSPreset_Kidnapping"))
			{
				if (element.CharacterId == _id)
				{
					return adventure;
				}
			}
		}
		return null;
	}

	public IAdventureRuntime GetCurrentAdventureOrMajorEvent()
	{
		if (!IsActiveExternalRelationState(4uL))
		{
			return null;
		}
		foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInLocation(_location))
		{
			if (runtime.ContainsCharacter(_id))
			{
				return runtime;
			}
		}
		return null;
	}

	public void DeactivateExternalRelationState(DataContext context, ulong type)
	{
		_externalRelationState &= (byte)(~type);
		SetExternalRelationState(_externalRelationState, context);
	}

	public bool IsInvincibleInNpcCombat()
	{
		short featureId = GetGroupFeature(740);
		return featureId >= 0;
	}

	public short GetBelongMapArea()
	{
		if (_organizationInfo.SettlementId < 0)
		{
			return -1;
		}
		return DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId)?.GetLocation().AreaId ?? (-1);
	}

	public sbyte GetBelongMapState()
	{
		short belongAreaId = GetBelongMapArea();
		if (belongAreaId < 0)
		{
			return -1;
		}
		return DomainManager.Map.GetStateIdByAreaId(belongAreaId);
	}

	public override string ToString()
	{
		(string, string) name = CharacterDomain.GetRealName(this);
		return $"{_organizationInfo}-{name.Item1}{name.Item2}({_id})";
	}

	public bool IsOnCityTown()
	{
		Location location = GetLocation();
		if (location.AreaId >= 0 && location.BlockId >= 0)
		{
			MapBlockData block = DomainManager.Map.GetBlock(location);
			return block.IsCityTown();
		}
		return false;
	}

	public short GetIdealClothingTemplateId()
	{
		if (_organizationInfo.OrgTemplateId == 16)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(_id);
			if (villagerRole != null)
			{
				return villagerRole.RoleConfig.Clothing;
			}
		}
		return OrganizationDomain.GetOrgMemberConfig(_organizationInfo).Clothing.TemplateId;
	}

	public static short GetSectRandomEnemyTemplateIdByGrade(sbyte orgTemplateId, sbyte grade)
	{
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		return orgConfig.RandomEnemyTemplateIds[grade];
	}

	public int GetExtraNameTextTemplateId()
	{
		short templateId = _templateId;
		if (templateId >= 598 && templateId <= 602 && DomainManager.Extra.TryGetHeavenlyTreeById(_id, out var tree))
		{
			return GameData.Domains.Extra.SharedMethods.GetTreeExtraNameTextTemplateId(tree.TemplateId);
		}
		return -1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public sbyte GetEffectiveConsummateLevel()
	{
		return (sbyte)((!IsLoseConsummateBonusByFeature()) ? Math.Min(_consummateLevel, GlobalConfig.Instance.MaxConsummateLevel) : 0);
	}

	public ProfessionData GetCurrentProfession()
	{
		return DomainManager.Character.GetCharacterCurrentProfession(_id);
	}

	public int GetMaxProfessionSeniority(int professionId)
	{
		if (IsTaiwu())
		{
			return 3000000;
		}
		short bestAttainment = GetProfessionBestAttainment(professionId);
		int skillIndex = GetAttainmentCanUnlockProfessionSkill(bestAttainment);
		int skillId = GameData.Domains.Taiwu.Profession.SharedMethods.GetSkillId(professionId, skillIndex);
		return GameData.Domains.Taiwu.Profession.SharedMethods.GetSkillUnlockSeniority(skillId);
	}

	public short GetProfessionBestAttainment(int professionId)
	{
		short bestAttainment = 0;
		ProfessionItem config = Profession.Instance[professionId];
		if (config.BonusLifeSkills != null)
		{
			foreach (sbyte lifeSkillType in config.BonusLifeSkills)
			{
				short attainment = GetLifeSkillAttainment(lifeSkillType);
				if (attainment > bestAttainment)
				{
					bestAttainment = attainment;
				}
			}
		}
		if (config.BonusCombatSkills != null)
		{
			foreach (sbyte combatSkillType in config.BonusCombatSkills)
			{
				short attainment2 = GetCombatSkillAttainment(combatSkillType);
				if (attainment2 > bestAttainment)
				{
					bestAttainment = attainment2;
				}
			}
		}
		return bestAttainment;
	}

	private static int GetAttainmentCanUnlockProfessionSkill(short attainment)
	{
		int[] thresholds = ProfessionRelatedConstants.MaxSeniorityAttainmentThresholds;
		for (int i = thresholds.Length - 1; i >= 0; i--)
		{
			int threshold = thresholds[i];
			if (attainment >= threshold)
			{
				return i;
			}
		}
		return 0;
	}

	public void ReadBookPage(DataContext context, GameData.Domains.Item.SkillBook skillBook, byte pageId)
	{
		if (IsTaiwu())
		{
			DomainManager.Taiwu.ReadSkillBookPageAndSetComplete(context, skillBook, pageId);
			return;
		}
		if (skillBook.IsCombatSkillBook())
		{
			short combatSkillTemplateId = skillBook.GetCombatSkillTemplateId();
			Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
			if (!combatSkills.TryGetValue(combatSkillTemplateId, out var combatSkill))
			{
				combatSkill = LearnNewCombatSkill(context, combatSkillTemplateId, 0);
			}
			ReadCombatSkillPage(context, combatSkill, skillBook, pageId);
			return;
		}
		short lifeSkillTemplateId = skillBook.GetLifeSkillTemplateId();
		int skillIndex = FindLearnedLifeSkillIndex(lifeSkillTemplateId);
		if (skillIndex < 0)
		{
			LearnNewLifeSkill(context, lifeSkillTemplateId, 0);
			skillIndex = _learnedLifeSkills.Count - 1;
		}
		ReadLifeSkillPage(context, skillIndex, pageId);
	}

	private CValueModify CalcPropertyModify(ECharacterPropertyReferencedType propertyType, EDataSumType valueSumType = EDataSumType.All)
	{
		CValueModify result = CValueModify.Zero.ChangeA(CalcMainAttributeAddValue(propertyType));
		result = (result + GetPropertyBonusOfFeatures(propertyType)).ChangeA(CalcTreasureGuardAddValue(propertyType)).ChangeA(CalcXiangshuInfectedDemonBonus(propertyType)).ChangeA(valueSumType.Sum(CalcNeiliAllocationBonus(propertyType)));
		if (IsTaiwu())
		{
			result = result.ChangeA(CalcProfessionAddValue(propertyType));
		}
		if (IsTaiwu())
		{
			result += (CValueModify)DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(propertyType);
		}
		result = result.ChangeA(CalcPreexistenceAddValue(propertyType)).ChangeA(CalcAgeEffectAddValue(propertyType));
		result += GetPropertyBonusOfEquipments(propertyType);
		result += _eatingItems.GetCharacterPropertyBonus(propertyType, IsTaiwu());
		if (IsTaiwu())
		{
			result += DomainManager.Extra.CalcLegendaryBookAddPropertyValue(propertyType);
		}
		result = result.ChangeA(CalcChickenAddValue(propertyType));
		if (IsTaiwu())
		{
			result = result.ChangeA(CalcSamsaraPlatformAddValue(propertyType));
		}
		if (IsTaiwu())
		{
			result = result.ChangeA(CalcSectXuannvUnlockedMusicAddValue(propertyType));
		}
		return result.ChangeA(GetPropertyBonusOfCombatSkillEquippingAndBreakout(propertyType));
	}

	private int CalcMainAttributeAddValue(ECharacterPropertyReferencedType propertyType)
	{
		sbyte mainAttributeType = propertyType.GetMainAttributeType();
		if (mainAttributeType == 6)
		{
			return 0;
		}
		ushort fieldId = propertyType.GetMainAttributeConsummateFieldId();
		int divisor = propertyType.GetMainAttributeConsummateDivisor();
		int hitOrInnerType;
		sbyte avoidType;
		bool penetrateIsInner;
		if (propertyType.TryParseHitType(out var hitType))
		{
			hitOrInnerType = hitType;
		}
		else if (propertyType.TryParseAvoidType(out avoidType))
		{
			hitOrInnerType = avoidType;
		}
		else if (propertyType.TryParsePenetrateIsInner(out penetrateIsInner))
		{
			hitOrInnerType = (penetrateIsInner ? 1 : 0);
		}
		else
		{
			if (!propertyType.TryParsePenetrateResistIsInner(out var penetrateResistIsInner))
			{
				return 0;
			}
			hitOrInnerType = (penetrateResistIsInner ? 1 : 0);
		}
		return CalcMainAttributeRelatedConsummateLevel(fieldId, mainAttributeType, hitOrInnerType, divisor);
	}

	private int CalcXiangshuInfectedDemonBonus(ECharacterPropertyReferencedType propertyType)
	{
		if (!Template.XiangshuInfectedDemonBonus)
		{
			return 0;
		}
		if (1 == 0)
		{
		}
		int result = propertyType switch
		{
			ECharacterPropertyReferencedType.PenetrateOfOuter => DomainManager.Character.GetXiangshuInfectedDemonsPenetrationsBonus().Outer, 
			ECharacterPropertyReferencedType.PenetrateOfInner => DomainManager.Character.GetXiangshuInfectedDemonsPenetrationsBonus().Inner, 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => DomainManager.Character.GetXiangshuInfectedDemonsPenetrationResistsBonus().Outer, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => DomainManager.Character.GetXiangshuInfectedDemonsPenetrationResistsBonus().Inner, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private int CalcTreasureGuardAddValue(ECharacterPropertyReferencedType propertyType)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		bool isGuardCombat = false;
		argBox.Get("IsGuardCombat", ref isGuardCombat);
		if (!isGuardCombat || !IsTreasuryGuard() || !HitAvoidAttackDefendPropertyTypes.Contains(propertyType))
		{
			return 0;
		}
		int value = 0;
		foreach (CombatCharacter teammate in DomainManager.Combat.GetTeammateCharacters(_id))
		{
			int teammateAddValue = 0;
			sbyte avoidType;
			bool penetrateIsInner;
			bool penetrateResistIsInner;
			if (propertyType.TryParseHitType(out var hitType))
			{
				teammateAddValue = teammate.GetCharacter().GetHitValues()[hitType];
			}
			else if (propertyType.TryParseAvoidType(out avoidType))
			{
				teammateAddValue = teammate.GetCharacter().GetAvoidValues()[avoidType];
			}
			else if (propertyType.TryParsePenetrateIsInner(out penetrateIsInner))
			{
				teammateAddValue = teammate.GetCharacter().GetPenetrations().Get(penetrateIsInner);
			}
			else if (propertyType.TryParsePenetrateResistIsInner(out penetrateResistIsInner))
			{
				teammateAddValue = teammate.GetCharacter().GetPenetrationResists().Get(penetrateResistIsInner);
			}
			value += CalcTreasuryGuardBonus(teammateAddValue);
		}
		return value;
	}

	private int CalcProfessionAddValue(ECharacterPropertyReferencedType propertyType)
	{
		if (!propertyType.TryParseMainAttributeType(out var mainAttributeType))
		{
			return 0;
		}
		int professionId = ProfessionRelatedConstants.MainAttributeRecoverProfessionIds[mainAttributeType];
		if (!DomainManager.Extra.IsProfessionalSkillUnlocked(professionId, 0))
		{
			return 0;
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(professionId);
		return professionData.GetSeniorityMainAttributeAdditional();
	}

	private unsafe int CalcPreexistenceAddValue(ECharacterPropertyReferencedType propertyType)
	{
		if (_preexistenceCharIds.Count <= 0)
		{
			return 0;
		}
		int value = 0;
		int i = 0;
		for (int count = _preexistenceCharIds.Count; i < count; i++)
		{
			int preCharId = _preexistenceCharIds.CharIds[i];
			DeadCharacter preChar = DomainManager.Character.TryGetDeadCharacter(preCharId);
			if (preChar != null)
			{
				sbyte lifeSkillType;
				sbyte combatSkillType;
				if (propertyType.TryParseMainAttributeType(out var mainAttributeType))
				{
					value += preChar.BaseMainAttributes[mainAttributeType];
				}
				else if (propertyType.TryParseLifeSkillQualificationType(out lifeSkillType))
				{
					value += preChar.BaseLifeSkillQualifications[lifeSkillType];
				}
				else if (propertyType.TryParseCombatSkillQualificationType(out combatSkillType))
				{
					value += preChar.BaseCombatSkillQualifications[combatSkillType];
				}
			}
		}
		return value / 10;
	}

	private int CalcAgeEffectAddValue(ECharacterPropertyReferencedType propertyType)
	{
		bool isLifeSkill;
		if (propertyType.TryParseLifeSkillQualificationType(out var expectSkillType))
		{
			isLifeSkill = true;
		}
		else
		{
			if (!propertyType.TryParseCombatSkillQualificationType(out expectSkillType))
			{
				return 0;
			}
			isLifeSkill = false;
		}
		short clampedAge = QualificationAge;
		AgeEffectItem ageEffectCfg = AgeEffect.Instance[clampedAge];
		sbyte growthType = (isLifeSkill ? _lifeSkillQualificationGrowthType : _combatSkillQualificationGrowthType);
		if (1 == 0)
		{
		}
		sbyte b = growthType switch
		{
			0 => ageEffectCfg.SkillQualificationAverage, 
			1 => ageEffectCfg.SkillQualificationPrecocious, 
			2 => ageEffectCfg.SkillQualificationLateBlooming, 
			_ => throw new Exception($"Unsupported GrowthType {growthType}"), 
		};
		if (1 == 0)
		{
		}
		sbyte value = b;
		sbyte expectSkillGroup = ((!isLifeSkill) ? ((sbyte)1) : ((sbyte)0));
		int i = 0;
		for (int count = _skillQualificationBonuses.Count; i < count; i++)
		{
			SkillQualificationBonus bonus = _skillQualificationBonuses[i];
			var (skillGroup, skillType) = bonus.GetSkillGroupAndType();
			if (skillGroup == expectSkillGroup && skillType == expectSkillType)
			{
				value += bonus.Bonus;
			}
		}
		return value;
	}

	private int CalcChickenAddValue(ECharacterPropertyReferencedType propertyType)
	{
		if (!propertyType.TryParsePersonalityType(out var personalityType))
		{
			return 0;
		}
		int value = 0;
		short orgMemberTemplateId = OrganizationDomain.GetOrgMemberConfig(_organizationInfo).TemplateId;
		foreach (GameData.Domains.Building.Chicken chicken in DomainManager.Building.GetFulongChickens(orgMemberTemplateId))
		{
			ChickenItem config = Config.Chicken.Instance[chicken.TemplateId];
			if (config.PersonalityType == personalityType)
			{
				value += config.PersonalityValue;
			}
		}
		return value;
	}

	private int CalcSamsaraPlatformAddValue(ECharacterPropertyReferencedType propertyType)
	{
		if (propertyType.TryParseMainAttributeType(out var mainAttributeType))
		{
			return DomainManager.Building.GetSamsaraPlatformAddMainAttributes()[mainAttributeType];
		}
		if (propertyType.TryParseLifeSkillQualificationType(out var lifeSkillType))
		{
			return DomainManager.Building.GetSamsaraPlatformAddLifeSkillQualifications()[lifeSkillType];
		}
		if (propertyType.TryParseCombatSkillQualificationType(out var combatSkillType))
		{
			return DomainManager.Building.GetSamsaraPlatformAddCombatSkillQualifications()[combatSkillType];
		}
		return 0;
	}

	private int CalcSectXuannvUnlockedMusicAddValue(ECharacterPropertyReferencedType propertyType)
	{
		if ((propertyType != ECharacterPropertyReferencedType.HitRateMind && propertyType != ECharacterPropertyReferencedType.AvoidRateMind) || 1 == 0)
		{
			return 0;
		}
		int value = 0;
		bool isHit = propertyType == ECharacterPropertyReferencedType.HitRateMind;
		foreach (short musicId in DomainManager.Extra.GetSectXuannvUnlockedMusicList())
		{
			MusicItem musicCfg = Music.Instance[musicId];
			value += (isHit ? musicCfg.HitRateMind : musicCfg.AvoidRateMind);
		}
		return value;
	}

	private int CalcAvatarAttraction()
	{
		if (!IsCreatedWithFixedTemplate() && string.IsNullOrEmpty(Template.FixedAvatarName))
		{
			return _avatar.GetCharm(GetPhysiologicalAge(), GetClothingDisplayIdForCharm());
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(1);
		HunterSkillsData skillsData = professionData.GetSkillsData<HunterSkillsData>();
		if (skillsData.AnimalCharIdToItemKey != null && skillsData.AnimalCharIdToItemKey.TryGetValue(_id, out var itemKey) && skillsData.AnimalCharIdToAttraction != null && skillsData.AnimalCharIdToAttraction.TryGetValue(itemKey, out var attraction))
		{
			return attraction;
		}
		return Template.BaseAttraction;
	}

	private int GetReversedFeatureBonus(ECharacterPropertyReferencedType propertyType, int originBonus, short featureId)
	{
		if (!BonusPropertyTypes.Contains(propertyType))
		{
			return originBonus;
		}
		CharacterFeatureItem config = CharacterFeature.Instance[featureId];
		int reverseStatus = DomainManager.SpecialEffect.GetModifyValue(_id, 292, EDataModifyType.Add);
		if ((originBonus < 0 && reverseStatus > 0 && config.IsBad()) || (originBonus > 0 && reverseStatus < 0 && config.IsGood()))
		{
			return -originBonus;
		}
		return originBonus;
	}

	private CValueModify GetPropertyBonusOfFeatures(ECharacterPropertyReferencedType propertyType)
	{
		int add = 0;
		int addPercent = 0;
		bool standardIsAdd = CharacterPropertyReferenced.Instance[(int)propertyType].FeatureStandardIsAdd;
		foreach (short featureId in _featureIds)
		{
			if (!IgnoreFeature(featureId))
			{
				CharacterFeatureItem config = CharacterFeature.Instance[featureId];
				int value = config.GetCharacterPropertyBonusInt(propertyType);
				value = GetReversedFeatureBonus(propertyType, value, featureId);
				if (standardIsAdd)
				{
					add += value;
				}
				else
				{
					addPercent += value;
				}
				int num = addPercent;
				if (1 == 0)
				{
				}
				int num2 = propertyType switch
				{
					ECharacterPropertyReferencedType.Attraction => config.AttractionPercentBonus, 
					ECharacterPropertyReferencedType.MaxHealth => config.MaxHealthPercentBonus, 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				addPercent = num + num2;
			}
		}
		return new CValueModify(add, addPercent);
	}

	private CValueModify GetPropertyBonusOfEquipments(ECharacterPropertyReferencedType propertyType)
	{
		int bonus = 0;
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey = _equipment[i];
			if (itemKey.IsValid())
			{
				int value = DomainManager.Item.GetCharacterPropertyBonus(itemKey, propertyType);
				bonus += DomainManager.SpecialEffect.ModifyValue(_id, 308, value, itemKey.ItemType, itemKey.Id, (int)propertyType);
			}
		}
		return CalcMysteryBonus(propertyType).ChangeA(bonus);
	}

	private int GetPropertyBonusOfCombatSkillEquippingAndBreakout(ECharacterPropertyReferencedType propertyType)
	{
		int bonus = 0;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		CombatSkillEquipment skillEquipment = GetCombatSkillEquipment();
		foreach (short skillTemplateId in skillEquipment)
		{
			if (skillTemplateId >= 0 && GetCombatSkillCanAffect(skillTemplateId))
			{
				if (!charCombatSkills.ContainsKey(skillTemplateId))
				{
					AdaptableLog.Warning($"character {this} has never learned combat skill {skillTemplateId}({Config.CombatSkill.Instance[skillTemplateId].Name}) but is trying to access it.");
				}
				else
				{
					bonus += charCombatSkills[skillTemplateId].GetCharPropertyBonus(propertyType);
				}
			}
		}
		return bonus;
	}

	private void OfflineUpdateHobbyExpirationDate()
	{
		int expYear = DomainManager.World.GetCurrYear() + GetHobbyChangingPeriod();
		int expDate = expYear * 12 + _birthMonth;
		_hobbyExpirationDate = expDate;
	}

	private void OfflineChangeHobby(IRandomSource random)
	{
		(short, short) tuple = GenerateRandomHobby(random);
		_lovingItemSubType = tuple.Item1;
		_hatingItemSubType = tuple.Item2;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(_id, DomainManager.Taiwu.GetTaiwuCharId()));
		if (favorabilityType < 3)
		{
			_lovingItemRevealed = false;
			_hatingItemRevealed = false;
		}
		else
		{
			_lovingItemRevealed = true;
			_hatingItemRevealed = true;
		}
		OfflineUpdateHobbyExpirationDate();
	}

	private void CommitChangingHobby(DataContext context)
	{
		SetLovingItemSubType(_lovingItemSubType, context);
		SetHatingItemSubType(_hatingItemSubType, context);
		SetLovingItemRevealed(_lovingItemRevealed, context);
		SetHatingItemRevealed(_hatingItemRevealed, context);
		SetHobbyExpirationDate(_hobbyExpirationDate, context);
		ChangeMerchantType(context, GetOrganizationInfo());
	}

	public bool IgnoreFeature(short featureId)
	{
		if (featureId == 739 && IsTaiwu())
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(GetValidLocation().AreaId);
			if (stateTemplateId != 11)
			{
				return true;
			}
		}
		return HideAndDisableFeature(featureId);
	}

	public bool HideAndDisableFeature(short featureId)
	{
		if ((uint)(featureId - 691) <= 3u)
		{
			return !CanInteractTreasury();
		}
		return false;
	}

	public bool IsMerchant(OrganizationInfo organizationInfo)
	{
		OrganizationItem organizationConfig = Config.Organization.Instance[organizationInfo.OrgTemplateId];
		OrganizationMemberItem organizationMemberConfig = OrganizationDomain.GetOrgMemberConfig(organizationInfo);
		List<sbyte> identityInteractConfig = organizationMemberConfig.IdentityInteractConfig;
		if (organizationConfig.IsCivilian && organizationInfo.Grade == 4 && identityInteractConfig != null && identityInteractConfig.Contains(4))
		{
			return true;
		}
		return false;
	}

	public void ChangeMerchantType(DataContext context, OrganizationInfo organizationInfo)
	{
		if (IsActiveExternalRelationState(4uL))
		{
			return;
		}
		if (organizationInfo.OrgTemplateId == 16)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(_id);
			if (!(villagerRole is VillagerRoleMerchant { CurrentMerchantType: var type } merchant))
			{
				RemoveMerchantType(context);
				return;
			}
			if (type == 7)
			{
				type = merchant.SelfDecideMerchantType;
			}
			AddOrSetMerchantType(type, context);
		}
		else if (IsMerchant(organizationInfo))
		{
			sbyte type2 = (sbyte)context.Random.Next(7);
			AddOrSetMerchantType(type2, context);
		}
		else
		{
			RemoveMerchantType(context);
		}
	}

	public void AddOrSetMerchantType(sbyte type, DataContext context)
	{
		if (DomainManager.Extra.TryGetMerchantCharToType(_id, out var _))
		{
			DomainManager.Extra.SetMerchantCharToType(_id, type, context);
		}
		else
		{
			DomainManager.Extra.AddMerchantCharToType(_id, type, context);
		}
	}

	public void RemoveMerchantType(DataContext context)
	{
		if (DomainManager.Extra.TryGetMerchantCharToType(_id, out var _))
		{
			DomainManager.Extra.RemoveMerchantCharToType(_id, context);
		}
	}

	public void RemoveMerchantExp(DataContext context)
	{
		if (DomainManager.Merchant.TryGetMerchantExpData(_id, out var _))
		{
			DomainManager.Merchant.RemoveMerchantExpData(context, _id);
		}
	}

	public short GetPreviewLeftMaxHealth(short offset)
	{
		short baseMaxHealth = GetBaseMaxHealth();
		baseMaxHealth -= offset;
		int value = baseMaxHealth * CalcPropertyModify(ECharacterPropertyReferencedType.MaxHealth);
		value += DomainManager.SpecialEffect.GetModifyValue(_id, 53, EDataModifyType.Add);
		if (IsTaiwu())
		{
			value += ProfessionSkillHandle.TravelingTaoistMonkSkill_GetMaxHealthBonus();
		}
		int livedMonths = ((!IsCompletelyInfected()) ? CharacterDomain.GetLivedMonths(_currAge, _birthMonth) : (_currAge * 12));
		return (short)Math.Clamp(0, Math.Min(32767, value - livedMonths), 32767);
	}

	[Obsolete("This method is obsolete, and will be removed in future. Use ChangeCurrMainAttribute instead.")]
	public void ChangeCurrMainAttributeWithoutSpecialEffect(DataContext context, sbyte mainAttributeType, int delta)
	{
		ChangeCurrMainAttribute(context, mainAttributeType, delta);
	}

	[Obsolete("This method is obsolete, and will be removed in future. Use ChangeCurrMainAttributes instead.")]
	public void ChangeCurrMainAttributesWithoutSpecialEffect(DataContext context, MainAttributes delta)
	{
		ChangeCurrMainAttributes(context, delta);
	}

	public void OfflineInheritCrossArchiveCharacter(Character crossArchiveChar)
	{
		_templateId = crossArchiveChar._templateId;
		_creatingType = crossArchiveChar._creatingType;
		_genome = crossArchiveChar._genome;
		_gender = crossArchiveChar._gender;
		_transgender = crossArchiveChar._transgender;
		_bisexual = crossArchiveChar._bisexual;
		_actualAge = crossArchiveChar._actualAge;
		_currAge = crossArchiveChar._currAge;
		_birthMonth = crossArchiveChar._birthMonth;
		_avatar = crossArchiveChar._avatar;
		_fullName = crossArchiveChar._fullName;
		_monasticTitle = crossArchiveChar._monasticTitle;
		_monkType = crossArchiveChar._monkType;
		_baseMaxHealth = crossArchiveChar._baseMaxHealth;
		_health = crossArchiveChar._health;
		_baseMorality = crossArchiveChar._baseMorality;
		_happiness = crossArchiveChar._happiness;
		_baseMainAttributes = crossArchiveChar._baseMainAttributes;
		_currMainAttributes = crossArchiveChar._currMainAttributes;
		_featureIds = new List<short>(crossArchiveChar._featureIds);
		_featureIds.RemoveAll((short featureId) => !CharacterFeature.Instance[featureId].CanCrossArchive);
		_potentialFeatureIds = crossArchiveChar._potentialFeatureIds;
		_extraNeili = crossArchiveChar._extraNeili;
		_baseCombatSkillQualifications = crossArchiveChar._baseCombatSkillQualifications;
		_baseLifeSkillQualifications = crossArchiveChar._baseLifeSkillQualifications;
		_combatSkillQualificationGrowthType = crossArchiveChar._combatSkillQualificationGrowthType;
		_lifeSkillQualificationGrowthType = crossArchiveChar._lifeSkillQualificationGrowthType;
		_skillQualificationBonuses = new List<SkillQualificationBonus>(crossArchiveChar._skillQualificationBonuses);
		_mainAttributeInterest = crossArchiveChar._mainAttributeInterest;
		_combatSkillTypeInterest = crossArchiveChar._combatSkillTypeInterest;
		_lifeSkillTypeInterest = crossArchiveChar._lifeSkillTypeInterest;
		_idealSect = crossArchiveChar._idealSect;
		_lovingItemSubType = crossArchiveChar._lovingItemSubType;
		_hatingItemSubType = crossArchiveChar._hatingItemSubType;
		_lovingItemRevealed = crossArchiveChar._lovingItemRevealed;
		_hatingItemRevealed = crossArchiveChar._hatingItemRevealed;
		_hobbyExpirationDate = crossArchiveChar._hobbyExpirationDate;
		_baseNeiliProportionOfFiveElements = crossArchiveChar._baseNeiliProportionOfFiveElements;
		_preexistenceCharIds = crossArchiveChar._preexistenceCharIds;
		_extraNeiliAllocation = crossArchiveChar._extraNeiliAllocation;
		_extraNeiliAllocationProgress = crossArchiveChar._extraNeiliAllocationProgress.ToArray();
		_injuries.Initialize();
		_poisoned.Initialize();
		_disorderOfQi = 0;
	}

	public void AddDarkAsh(DataContext context, LifeRecordCollection lifeRecordCollection = null, int baseTime = int.MinValue)
	{
		if (baseTime == int.MinValue)
		{
			int factor = DomainManager.World.GetCharacterLifeSpanFactor();
			baseTime = (GlobalConfig.Instance.DarkAshDurationBase * factor + context.Random.Next(factor * GlobalConfig.Instance.DarkAshDurationRangeMax - (factor - 100))) / 100;
		}
		int currDate = DomainManager.World.GetCurrDate();
		int consummateLevelExpiredDate = currDate + _consummateLevel;
		int darkAshExpiredDate = consummateLevelExpiredDate + baseTime;
		AddFeature(context, 216);
		DomainManager.Character.RegisterCharacterTemporaryFeature(context, _id, 216, darkAshExpiredDate);
		if (DomainManager.Character.TryGetDarkAshCounterData(_id, out var _))
		{
			AdaptableLog.Warning($"DarkAsh counter May duplicate for char {this}, please check the call stack:\n{new StackTrace()}");
			DomainManager.Character.SetDarkAshCounterData(context, _id, new DarkAshCounterData(currDate, _consummateLevel));
		}
		else
		{
			DomainManager.Character.AddDarkAshCounterData(context, _id, new DarkAshCounterData(currDate, _consummateLevel));
		}
		lifeRecordCollection?.AddGetInfected(_id, currDate, _location);
	}

	public void DirectlyChangeDarkAshDuration(DataContext context, int currDate, int baseTime, int consummateTime, int faithTime)
	{
		DomainManager.Character.RegisterCharacterTemporaryFeature(context, _id, 216, currDate + baseTime + consummateTime + faithTime);
		if (DomainManager.Character.TryGetDarkAshCounterData(_id, out var _))
		{
			DomainManager.Character.SetDarkAshCounterData(context, _id, new DarkAshCounterData(currDate, consummateTime, faithTime));
		}
		else
		{
			DomainManager.Character.AddDarkAshCounterData(context, _id, new DarkAshCounterData(currDate, consummateTime, faithTime));
		}
	}

	public void SavedFromInfected(DataContext context, bool batchMode = false)
	{
		int faithCount = SaveFromInfectedGainFaith;
		DomainManager.Character.AddFuyuFaith(context, faithCount);
		if (!batchMode && faithCount > 0)
		{
			DomainManager.World.GetInstantNotificationCollection().AddGainFuyuFaith1(_id, faithCount);
		}
	}

	public void RemoveDarkAsh(DataContext context)
	{
		RemoveFeature(context, 216);
		DomainManager.Character.UnregisterCharacterTemporaryFeature(context, _id, 216);
		DomainManager.Character.RemoveDarkAshCounterData(context, _id);
	}

	public DarkAshCounter GetDarkAshCounter()
	{
		DarkAshCounterData data;
		return DomainManager.Character.TryGetDarkAshCounterData(_id, out data) ? new DarkAshCounter(DarkAshDuration + DomainManager.World.GetCurrDate(), DomainManager.World.GetCurrDate(), data) : new DarkAshCounter(DarkAshDuration + DomainManager.World.GetCurrDate(), DomainManager.World.GetCurrDate());
	}

	public bool ShouldNotifyDarkAshInfected(out int duration)
	{
		int num = (duration = DarkAshDuration);
		return num <= 6 && num > 0;
	}

	public void ExtendDarkAshWithFuyuFaith(DataContext context, int delta, LifeRecordCollection lifeRecordCollection = null)
	{
		int currDate = DomainManager.World.GetCurrDate();
		CharacterDomain character = DomainManager.Character;
		int id = _id;
		int date = DomainManager.Character.GetTemporaryFeatureExpireDate(_id, 216);
		character.RegisterCharacterTemporaryFeature(context, id, 216, (date != -1) ? (date + delta) : (currDate + delta));
		if (DomainManager.Character.TryGetDarkAshCounterData(_id, out var data))
		{
			DomainManager.Character.SetDarkAshCounterData(context, _id, data.OfflineApplyFaithChangeToExtraData(currDate, delta));
		}
		else
		{
			DomainManager.Character.AddDarkAshCounterData(context, _id, new DarkAshCounterData(currDate, 0, delta));
		}
		DomainManager.Character.AddFuyuFaith(context, -delta);
		lifeRecordCollection?.AddExtendDarkAshTime(_id, currDate, _location);
	}

	public void DivineFlameTryAddRelation_Adore(DataContext context, HashSet<int> charSet)
	{
		if (GetAgeGroup() == 0 || DomainManager.LegendaryBook.IsCharacterActingCrazy(this))
		{
			return;
		}
		PotentialRelatedCharacters canStartRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Occupy();
		PotentialRelatedCharacters canEndRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Occupy();
		List<Character> newlyMetCharacters = new List<Character>();
		DomainManager.Character.GetPotentialRelatedCharactersInSet(canStartRelationChars, canEndRelationChars, newlyMetCharacters, this, charSet);
		foreach (Character relatedChar in newlyMetCharacters)
		{
			DomainManager.Character.TryCreateGeneralRelation(context, this, relatedChar);
		}
		Personalities personalities = GetPersonalities();
		IRandomSource random = context.Random;
		Character targetChar = GetStartOrEndRelationTarget(random, 2, canStartRelationChars.Adored, ref personalities);
		if (targetChar != null)
		{
			RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(_id, targetChar.GetId());
			RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(targetChar.GetId(), _id);
			int successRate = AiHelper.Relation.GetStartRelationSuccessRate_Adored(this, targetChar, selfToTarget, targetToSelf);
			if (random.CheckProb(successRate, 100))
			{
				sbyte selfBehaviorType = GetBehaviorType();
				bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(GetId());
				bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetChar.GetId());
				int targetLovesBackRate = AiHelper.Relation.GetStartRelationSuccessRate_Adored(targetChar, this, selfToTarget, targetToSelf);
				bool targetLovesBack = random.CheckPercentProb(targetLovesBackRate);
				ApplyAddRelation_Adore(context, this, targetChar, selfBehaviorType, targetLovesBack, selfIsTaiwuPeople, targetIsTaiwuPeople);
				int date = DomainManager.World.GetCurrDate();
				DomainManager.LifeRecord.GetLifeRecordCollection().AddYiyihouGood(_id, date, GetLocation(), targetChar.GetId());
				DomainManager.World.GetInstantNotificationCollection().AddYiyihouGood(_id, targetChar.GetId());
			}
		}
		context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Release(ref canStartRelationChars);
		context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Release(ref canEndRelationChars);
	}

	public void DivineFlameTryAddRelation_Enemy(DataContext context, HashSet<int> charSet)
	{
		if (GetAgeGroup() == 0 || DomainManager.LegendaryBook.IsCharacterActingCrazy(this))
		{
			return;
		}
		PotentialRelatedCharacters canStartRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Occupy();
		PotentialRelatedCharacters canEndRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Occupy();
		List<Character> newlyMetCharacters = new List<Character>();
		DomainManager.Character.GetPotentialRelatedCharactersInSet(canStartRelationChars, canEndRelationChars, newlyMetCharacters, this, charSet);
		foreach (Character relatedChar in newlyMetCharacters)
		{
			DomainManager.Character.TryCreateGeneralRelation(context, this, relatedChar);
		}
		Personalities personalities = GetPersonalities();
		IRandomSource random = context.Random;
		Character targetChar = GetStartOrEndRelationTarget(random, 0, canStartRelationChars.Enemies, ref personalities);
		if (targetChar != null)
		{
			sbyte targetBehaviorType = targetChar.GetBehaviorType();
			bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(GetId());
			bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetChar.GetId());
			bool targetHateBack = random.CheckPercentProb(AiHelper.RelationsRelatedConstants.SeverEnemyNotMutuallyChance[targetBehaviorType]);
			ApplyAddRelation_Enemy(context, this, targetChar, selfIsTaiwuPeople, 0);
			if (targetHateBack)
			{
				ApplyAddRelation_Enemy(context, targetChar, this, targetIsTaiwuPeople, 0);
			}
			int date = DomainManager.World.GetCurrDate();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddYiyihouBad(_id, date, GetLocation(), targetChar.GetId());
			DomainManager.World.GetInstantNotificationCollection().AddYiyihouBad(_id, targetChar.GetId());
		}
		context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Release(ref canStartRelationChars);
		context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Release(ref canEndRelationChars);
	}

	public unsafe sbyte GetCurrMaxEatingSlotsCount()
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		short maxVitality = maxMainAttributes.Items[3];
		return EatingItems.CalcMaxEatingSlotsCount(maxVitality);
	}

	public void AddEatingItem(DataContext context, ItemKey itemKey, IReadOnlyList<sbyte> targetBodyParts = null, bool reduceMainAttribute = true)
	{
		Tester.Assert(itemKey.IsValid());
		if (itemKey.ItemType == 8)
		{
			MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
			if (config.InstantAffect)
			{
				ApplyEatingItemInstantEffects(context, itemKey.ItemType, itemKey.TemplateId, targetBodyParts, itemKey.Id);
				if (config.Duration == 0)
				{
					TryApplyAttachedPoison(context, itemKey);
				}
			}
			if (config.Duration > 0)
			{
				AddEatingItemWithoutInstantEffects(context, itemKey);
			}
			sbyte mainAttrType = config.RequiredMainAttributeType;
			if (mainAttrType >= 0 && reduceMainAttribute)
			{
				sbyte mainAttrValue = config.RequiredMainAttributeValue;
				short currMainAttribute = GetCurrMainAttributes()[mainAttrType];
				if (currMainAttribute < mainAttrValue)
				{
					AdaptableLog.TagWarning($"Character {_id}", $"Current main attribute {mainAttrType} ({currMainAttribute}/{mainAttrValue}) is not enough to apply medicine {config.Name}.");
					return;
				}
				ChangeCurrMainAttribute(context, mainAttrType, -mainAttrValue);
			}
		}
		else
		{
			ApplyEatingItemInstantEffects(context, itemKey.ItemType, itemKey.TemplateId, targetBodyParts, itemKey.Id);
			AddEatingItemWithoutInstantEffects(context, itemKey);
		}
		if (_id == DomainManager.Taiwu.GetTaiwuCharId() && itemKey.ItemType == 9)
		{
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
			int price = item.GetValue();
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 900)
			{
				ProfessionFormulaItem formula = ProfessionFormula.Instance[100];
				int addSeniority = formula.Calculate(price);
				DomainManager.Extra.ChangeProfessionSeniority(context, 16, addSeniority);
			}
			else
			{
				ProfessionFormulaItem formula2 = ProfessionFormula.Instance[49];
				int addSeniority2 = formula2.Calculate(price);
				DomainManager.Extra.ChangeProfessionSeniority(context, 7, addSeniority2);
			}
		}
		if (IsTaiwu() && itemKey.ItemType != 9)
		{
			int value = DomainManager.Item.GetValue(itemKey);
			int addSeniority3 = ProfessionFormulaImpl.Calculate(63, value);
			DomainManager.Extra.ChangeProfessionSeniority(context, 9, addSeniority3);
		}
	}

	public void ApplyEatingItemInstantEffects(DataContext context, sbyte itemType, short templateId, IReadOnlyList<sbyte> targetBodyParts = null, int itemId = -1)
	{
		switch (itemType)
		{
		case 7:
		{
			FoodItem config3 = Config.Food.Instance[templateId];
			ApplyFoodInstantEffect(context, config3);
			break;
		}
		case 8:
		{
			MedicineItem config4 = Config.Medicine.Instance[templateId];
			if (config4.EffectType != EMedicineEffectType.Invalid)
			{
				MedicineEatingInstantEffect eatingEffect3 = new MedicineEatingInstantEffect(config4, targetBodyParts);
				ApplyMedicineInstantEffect(context, ref eatingEffect3, itemId);
			}
			ApplySpecialMedicineEffect(context, templateId);
			break;
		}
		case 9:
		{
			TeaWineItem config5 = Config.TeaWine.Instance[templateId];
			ApplyTeaWineInstantEffect(context, config5);
			break;
		}
		case 12:
		{
			MiscItem config2 = Config.Misc.Instance[templateId];
			if (config2.Neili != 0)
			{
				ChangeCurrNeili(context, config2.Neili);
			}
			if (config2.MaxNeili != 0)
			{
				ChangeExtraNeili(context, config2.MaxNeili);
			}
			int first = config2.FiveElementTransfer.First;
			if (first < 0 || first >= 5 || config2.FiveElementTransfer.Second <= 0)
			{
				break;
			}
			sbyte type = (sbyte)config2.FiveElementTransfer.First;
			int requirement = Math.Min(config2.FiveElementTransfer.Second, 100 - _baseNeiliProportionOfFiveElements[type]);
			int maxAmountEach = config2.FiveElementTransfer.Second / 4;
			while (requirement > 0)
			{
				for (sbyte i = 0; i < 5; i++)
				{
					if (i != type)
					{
						sbyte amount = (sbyte)Math.Min(_baseNeiliProportionOfFiveElements[i], maxAmountEach);
						if (amount > 0)
						{
							requirement -= amount;
							_baseNeiliProportionOfFiveElements[i] -= amount;
							_baseNeiliProportionOfFiveElements[type] += amount;
							SetBaseNeiliProportionOfFiveElements(_baseNeiliProportionOfFiveElements, context);
						}
					}
				}
			}
			if (GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.Global.CheckFiveElementConflictGuidingTrigger(context, GetNeiliType());
			}
			break;
		}
		case 5:
		{
			MaterialItem config = Config.Material.Instance[templateId];
			short value = config.BaseMaxHealthDelta;
			if (value != 0)
			{
				ChangeBaseMaxHealth(context, value);
			}
			if (config.PrimaryEffectType >= EMedicineEffectType.RecoverOuterInjury)
			{
				MedicineEatingInstantEffect eatingEffect = new MedicineEatingInstantEffect(config, primary: true);
				ApplyMedicineInstantEffect(context, ref eatingEffect, itemId);
			}
			if (config.SecondaryEffectType >= EMedicineEffectType.RecoverOuterInjury)
			{
				MedicineEatingInstantEffect eatingEffect2 = new MedicineEatingInstantEffect(config, primary: false);
				ApplyMedicineInstantEffect(context, ref eatingEffect2, itemId);
			}
			break;
		}
		default:
			throw new Exception($"Invalid item type: {itemType}");
		}
	}

	public void AddEatingItemWithoutInstantEffects(DataContext context, ItemKey itemKey)
	{
		DomainManager.Item.SetPoisonsIdentified(context, itemKey, isIdentified: true);
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.CharacterEatingItem, _id);
		IItemConfig config = itemKey.GetConfig();
		bool itemOccupyAvailableEatingSlot = config.IsEat();
		sbyte currMaxEatingSlotsCount = GetCurrMaxEatingSlotsCount();
		int index = (itemOccupyAvailableEatingSlot ? _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotsCount) : (-1));
		if (index < 0 && itemOccupyAvailableEatingSlot)
		{
			throw new Exception($"Character {_id}: EatingItems slots are full");
		}
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		short duration = ItemTemplateHelper.GetEatableItemDuration(itemKey.ItemType, itemKey.TemplateId);
		if (index >= 0)
		{
			_eatingItems.Set(index, itemKey, duration);
			if (_id != DomainManager.Taiwu.GetTaiwuCharId() || ((itemSubType != 900 || !DomainManager.Extra.IsProfessionalSkillUnlocked(16, 1)) && (itemSubType != 901 || !DomainManager.Extra.IsProfessionalSkillUnlocked(7, 1))))
			{
				short attachedPoisonDuration = TryApplyAttachedPoison(context, itemKey);
				_eatingItems.ChangeDuration(context, index, attachedPoisonDuration);
			}
			SetEatingItems(ref _eatingItems, context);
		}
		else if (itemKey.ItemType == 12)
		{
			TryApplyAttachedPoison(context, itemKey);
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		else if (itemKey.ItemType == 8 && Config.Medicine.Instance[itemKey.TemplateId].WugGrowthType == 5)
		{
			AddWug(context, itemKey, -1);
		}
		Events.RaiseEatingItem(context, this, itemKey);
		if (1 == 0)
		{
		}
		bool flag = itemSubType switch
		{
			701 => IsForbiddenToEatMeat(), 
			901 => IsForbiddenToDrinkingWines(), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		if (flag)
		{
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			Location location = GetLocation();
			lifeRecordCollection.AddMonkBreakRule(_id, currDate, location, itemKey.ItemType, itemKey.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddMonkBreakRule(_id, (ulong)itemKey);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
	}

	public void ApplyTopicalMedicine(DataContext context, ItemKey itemKey, bool reduceMainAttribute = true)
	{
		Tester.Assert(itemKey.IsValid());
		if (itemKey.ItemType != 8)
		{
			throw new Exception($"Invalid item type: {itemKey.ItemType}");
		}
		MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
		if (config.EffectType != EMedicineEffectType.RecoverOuterInjury && config.EffectType != EMedicineEffectType.RecoverInnerInjury)
		{
			throw new Exception($"Invalid EffectType: {config.EffectType}");
		}
		OfflineApplyTopicalMedicineInternal(context.Random, config, reduceMainAttribute, itemKey.Id);
		SetCurrMainAttributes(_currMainAttributes, context);
		SetInjuries(_injuries, context);
		TryApplyAttachedPoison(context, itemKey);
	}

	public void ApplySpecialMedicineEffect(DataContext context, short templateId)
	{
		switch (templateId)
		{
		case 78:
			_injuries.Initialize();
			SetInjuries(_injuries, context);
			break;
		case 79:
			SetXiangshuInfection(0, context);
			UpdateXiangshuInfectionState(context);
			break;
		case 81:
			SetXiangshuInfection(100, context);
			UpdateXiangshuInfectionState(context);
			break;
		case 346:
			if (_currAge >= GlobalConfig.Instance.AgeBaby)
			{
				bool needChildCloth = GetAgeGroup() != 1;
				short oldAge = _currAge;
				SetCurrAge((short)GlobalConfig.Instance.AgeBaby, context);
				Events.RaiseCharacterAgeChanged(context, this, oldAge, _currAge);
				if (needChildCloth)
				{
					ItemKey itemKey = DomainManager.Item.CreateClothing(context, 65, _gender);
					AddInventoryItem(context, itemKey, 1);
					ChangeEquipment(context, -1, 4, itemKey);
				}
			}
			break;
		case 387:
			AddFeature(context, 680);
			break;
		}
	}

	public void AddWug(DataContext context, short medicineTemplateId, short specifyDuration = -1)
	{
		ItemKey wugItemKey = new ItemKey(8, 0, medicineTemplateId, -1);
		AddWug(context, wugItemKey, specifyDuration);
	}

	public void AddWug(DataContext context, ItemKey wugItemKey, short specifyDuration = -1)
	{
		Tester.Assert(wugItemKey.ItemType == 8);
		MedicineItem config = Config.Medicine.Instance[wugItemKey.TemplateId];
		Tester.Assert(config.ItemSubType == 802);
		int index = _eatingItems.IndexOfWug(config);
		if ((index >= 0) ? OfflineReplaceWug(context, index, wugItemKey, specifyDuration) : OfflineAddNewWug(context, wugItemKey, specifyDuration))
		{
			SetEatingItems(ref _eatingItems, context);
		}
		if (IsTaiwu())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 158);
		}
	}

	public void RemoveWug(DataContext context, short medicineTemplateId)
	{
		MedicineItem config = Config.Medicine.Instance[medicineTemplateId];
		int index = _eatingItems.IndexOfWug(config);
		if (index >= 0)
		{
			ItemKey wugItemKey = _eatingItems.Get(index);
			_eatingItems.Clear(index);
			_eatingItems.SortWugs();
			SetEatingItems(ref _eatingItems, context);
			if (wugItemKey.IsValid())
			{
				DomainManager.Item.RemoveItem(context, wugItemKey);
			}
			Events.RaiseRemoveWug(context, _id, config.TemplateId);
		}
	}

	public void OnDeathTransferWugKings(DataContext context, Location charLocation)
	{
		List<ItemKey> wugKings = ObjectPool<List<ItemKey>>.Instance.Get();
		OnDeathTransferWugKings(context, wugKings);
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
		MonthlyNotificationCollection monthlyNotification = DomainManager.World.GetMonthlyNotificationCollection();
		foreach (ItemKey wugKing in wugKings)
		{
			_inventory.OfflineAdd(wugKing, 1);
			if (DomainManager.World.GetAdvancingMonthState() != 0)
			{
				monthlyNotification.AddWugKingParasitiferDead(wugKing.ItemType, wugKing.TemplateId, charLocation, _id);
			}
			else
			{
				instantNotification.AddWugKingParasitiferDead(wugKing.ItemType, wugKing.TemplateId, charLocation, _id);
			}
		}
	}

	public void OnDeathTransferWugKings(DataContext context, List<ItemKey> wugKings)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = _eatingItems.Get(i);
			if (EatingItems.IsWugKing(itemKey))
			{
				_eatingItems.Clear(i);
				wugKings.Add(itemKey);
				Events.RaiseRemoveWug(context, _id, itemKey.TemplateId);
			}
		}
	}

	public unsafe void ClearEatingItems(DataContext context)
	{
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetValidLocation();
		MapBlockData blockData = DomainManager.Map.GetBlock(location);
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
		for (int i = 8; i >= 0; i--)
		{
			ItemKey itemKey = (ItemKey)_eatingItems.ItemKeys[i];
			if (EatingItems.IsWug(itemKey))
			{
				Events.RaiseRemoveWug(context, _id, itemKey.TemplateId);
			}
			if (EatingItems.IsWugKing(itemKey) && Template.AllowDropWugKing)
			{
				DomainManager.Map.AddBlockItem(context, blockData, itemKey, 1);
				if (DomainManager.Combat.GetIsPuppetCombat())
				{
					instantNotification.AddWugKingEscape2(itemKey.ItemType, itemKey.TemplateId, location);
				}
				else
				{
					instantNotification.AddWugKingEscape1(itemKey.ItemType, itemKey.TemplateId, _templateId, location);
				}
			}
			else if (itemKey.IsValid())
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
			_eatingItems.Clear(i);
		}
		SetEatingItems(ref _eatingItems, context);
	}

	public unsafe void ClearSlotEatingItem(DataContext context, int index)
	{
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetValidLocation();
		MapBlockData blockData = DomainManager.Map.GetBlock(location);
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
		Tester.Assert(index >= 0 && index < 9);
		ItemKey itemKey = (ItemKey)_eatingItems.ItemKeys[index];
		if (EatingItems.IsWug(itemKey))
		{
			Events.RaiseRemoveWug(context, _id, itemKey.TemplateId);
		}
		if (EatingItems.IsWugKing(itemKey) && Template.AllowDropWugKing)
		{
			DomainManager.Map.AddBlockItem(context, blockData, itemKey, 1);
			if (DomainManager.Combat.GetIsPuppetCombat())
			{
				instantNotification.AddWugKingEscape2(itemKey.ItemType, itemKey.TemplateId, location);
			}
			else
			{
				instantNotification.AddWugKingEscape1(itemKey.ItemType, itemKey.TemplateId, _templateId, location);
			}
		}
		else if (itemKey.IsValid())
		{
			DomainManager.Item.RemoveItem(context, itemKey);
		}
		_eatingItems.Clear(index);
		SetEatingItems(ref _eatingItems, context);
	}

	public unsafe short TryApplyAttachedPoison(DataContext context, ItemKey itemKey)
	{
		if (!ModificationStateHelper.IsActive(itemKey.ModificationState, 1) || !DomainManager.Item.PoisonEffects.TryGetValue(itemKey.Id, out var poisonEffect))
		{
			return 0;
		}
		DomainManager.Item.SetPoisonsIdentified(context, itemKey, isIdentified: true);
		PoisonsAndLevels poisons = poisonEffect.GetAllPoisonsAndLevels();
		for (sbyte type = 0; type < 6; type++)
		{
			poisons.Values[type] = (short)(poisons.Values[type] * 10 * poisons.Levels[type]);
		}
		ChangePoisoned(context, ref poisons);
		short medicineTemplateId = poisonEffect.GetMedicineTemplateId();
		ApplyMixedPoisonInstantEffects(context);
		if (IsTaiwu())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 270);
		}
		return Config.Medicine.Instance[medicineTemplateId].Duration;
	}

	private void ApplyMixedPoisonInstantEffects(DataContext context)
	{
		for (sbyte mixedPoisonType = 15; mixedPoisonType <= 34; mixedPoisonType++)
		{
			ApplyMixedPoisonInstantEffect(context, mixedPoisonType);
		}
	}

	private void ApplyMixedPoisonInstantEffect(DataContext context, sbyte mixedPoisonType)
	{
		if (GetMixedPoisonTypeRelatedMarkCount(mixedPoisonType) == 0)
		{
			return;
		}
		short effectTemplateId = MixedPoisonType.ToMixPoisonEffectTemplateId(mixedPoisonType);
		MixPoisonEffectItem mixPoisonEffectCfg = MixPoisonEffect.Instance[effectTemplateId];
		if (mixPoisonEffectCfg.InstantEffect)
		{
			if (_creatingType == 1)
			{
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				lifeRecordCollection.AddMixedPoisonEffectRecord(this, mixPoisonEffectCfg);
			}
			sbyte combatSkillEquipType = MixedPoisonType.ToCombatSkillEquipType(mixedPoisonType);
			if (combatSkillEquipType != -1 && IsTaiwu())
			{
				DomainManager.Taiwu.ClearExceedCombatSkills(context);
				DomainManager.Global.InvokeGuidingTrigger(context, 237);
			}
		}
	}

	private void MakeExistingInjuriesWorse(DataContext context, bool isInnerInjury, sbyte delta)
	{
		Injuries injuries = GetInjuries();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte partInjury = injuries.Get(bodyPart, isInnerInjury);
			if (partInjury > 0)
			{
				injuries.Change(bodyPart, isInnerInjury, delta);
			}
		}
		SetInjuries(injuries, context);
	}

	public unsafe int GetMixedPoisonTypeRelatedMarkCount(sbyte mixedPoisonType)
	{
		sbyte[] poisonTypes = MixedPoisonType.ToPoisonTypes[mixedPoisonType];
		PoisonInts poisoned = _poisoned;
		int totalCount = 0;
		foreach (sbyte poisonType in poisonTypes)
		{
			sbyte markCount = PoisonsAndLevels.CalcPoisonedLevel(poisoned.Items[poisonType]);
			if (markCount == 0 || HasPoisonImmunity(poisonType))
			{
				return 0;
			}
			totalCount += markCount;
		}
		return totalCount;
	}

	public int GetRealMixedPoisonTypeRelatedMarkCount(sbyte mixedPoisonType)
	{
		sbyte[] poisonTypes = MixedPoisonType.ToPoisonTypes[mixedPoisonType];
		PoisonInts poisoned = _poisoned;
		int totalCount = 0;
		foreach (sbyte poisonType in poisonTypes)
		{
			sbyte markCount = PoisonsAndLevels.CalcPoisonedLevel(poisoned[poisonType]);
			if (markCount == 0 || GetPoisonImmunities()[poisonType] || DomainManager.Extra.HasPoisonImmunity(_id, poisonType))
			{
				return 0;
			}
			totalCount += markCount;
		}
		return totalCount;
	}

	private void ApplyMedicineInstantEffect(DataContext context, ref MedicineEatingInstantEffect effect, int itemId)
	{
		switch (effect.EffectType)
		{
		case EMedicineEffectType.RecoverOuterInjury:
		{
			IReadOnlyList<sbyte> targetBodyParts = effect.TargetBodyParts;
			if (targetBodyParts != null && targetBodyParts.Count > 0)
			{
				CalcMedicineEffect_RecoverInjury(ref _injuries, effect.TargetBodyParts, inner: false, ref effect, itemId);
			}
			else
			{
				CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: false, ref effect, itemId);
			}
			SetInjuries(_injuries, context);
			break;
		}
		case EMedicineEffectType.RecoverInnerInjury:
		{
			IReadOnlyList<sbyte> targetBodyParts = effect.TargetBodyParts;
			if (targetBodyParts != null && targetBodyParts.Count > 0)
			{
				CalcMedicineEffect_RecoverInjury(ref _injuries, effect.TargetBodyParts, inner: true, ref effect, itemId);
			}
			else
			{
				CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: true, ref effect, itemId);
			}
			SetInjuries(_injuries, context);
			break;
		}
		case EMedicineEffectType.RecoverHealth:
			CalcMedicineEffect_RecoverHealth(ref _health, ref effect, itemId);
			SetHealth(_health, context);
			break;
		case EMedicineEffectType.ChangeDisorderOfQi:
			CalcMedicineEffect_RecoverDisorderOfQi(ref _disorderOfQi, ref effect, itemId);
			SetDisorderOfQi(_disorderOfQi, context);
			break;
		case EMedicineEffectType.DetoxPoison:
			CalcMedicineEffect_DetoxPoison(ref _poisoned, ref effect, itemId);
			SetPoisoned(ref _poisoned, context);
			break;
		case EMedicineEffectType.DetoxWug:
		{
			sbyte wugType = effect.DetoxWugType;
			ApplyMedicineInstantEffect_DetoxWug(context, wugType, effect.Grade);
			break;
		}
		case EMedicineEffectType.ApplyPoison:
		{
			CalcMedicineEffect_ApplyPoison(ref _poisoned, ref effect, itemId);
			SetPoisoned(ref _poisoned, context);
			ApplyMixedPoisonInstantEffects(context);
			sbyte detoxWugType = effect.DetoxWugType;
			ApplyMedicineInstantEffect_DetoxWug(context, detoxWugType, effect.Grade);
			break;
		}
		}
	}

	public void CalcMedicineEffect_RecoverHealth(ref short health, ref MedicineEatingInstantEffect effect, int itemId)
	{
		int delta = CalcMedicineEffectDelta(GetLeftMaxHealth(), effect.EffectValue, effect.EffectIsPercentage, itemId);
		health = CalcChangedHealth(health, delta);
	}

	public int CalcMedicineHealInjuryTimes(int effectValue, int itemId)
	{
		CValuePercent effect = GetSpecialEffectModifiedMedicineEffectValue(100, itemId);
		return Math.Max(effectValue * effect, 1);
	}

	public int GetSpecialEffectModifiedMedicineEffectValue(int effectValue, int itemId)
	{
		int extraAddPercent = 0;
		if (itemId >= 0 && DomainManager.Item.TryGetElement_MedicineExtraAddPercent(itemId, out var value))
		{
			extraAddPercent = value;
		}
		return DomainManager.SpecialEffect.ModifyValue(_id, 260, effectValue, -1, -1, -1, 0, extraAddPercent);
	}

	public int GetTotalMedicineEffectValue(EatingItems eatingItems, EMedicineEffectSubType subType)
	{
		int effectValue = 0;
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = eatingItems.GetItem(i);
			if (itemKey.IsValid() && itemKey.ItemType == 8)
			{
				MedicineItem config = Config.Medicine.Instance[itemKey.TemplateId];
				if (config.EffectSubType == subType)
				{
					int value = GetSpecialEffectModifiedMedicineEffectValue(config.EffectValue, itemKey.Id);
					effectValue += value;
				}
			}
		}
		return effectValue;
	}

	public int CalcMedicineEffectDelta(int fullRangeValue, short effectValue, bool isPercentage, int itemId)
	{
		return GetSpecialEffectModifiedMedicineEffectValue(EMedicineEffectSubTypeExtension.EffectValue(fullRangeValue, effectValue, isPercentage), itemId);
	}

	public int CalcMedicineEffectDelta_RecoverDisorderOfQi(short effectValue, bool isPercentage, int itemId)
	{
		return -CalcMedicineEffectDelta(DisorderLevelOfQi.MaxValue, effectValue, isPercentage, itemId);
	}

	public void CalcMedicineEffect_RecoverDisorderOfQi(ref short disorderOfQi, ref MedicineEatingInstantEffect effect, int itemId)
	{
		int delta = CalcMedicineEffectDelta_RecoverDisorderOfQi(effect.EffectValue, effect.EffectIsPercentage, itemId);
		disorderOfQi = CalcChangedDisorderOfQiWithoutEffect(disorderOfQi, delta);
	}

	public unsafe void CalcMedicineEffect_DetoxPoison(ref PoisonInts poison, ref MedicineEatingInstantEffect effect, int itemId)
	{
		sbyte poisonType = effect.PoisonType;
		sbyte poisonLevel = (sbyte)effect.EffectThresholdValue;
		if (poisonLevel >= PoisonsAndLevels.CalcPoisonedLevel(poison.Items[poisonType]))
		{
			int delta = -CalcMedicineEffectDelta(poison.Items[poisonType], effect.EffectValue, effect.EffectIsPercentage, itemId);
			CalcChangedPoisoned(ref poison, poisonType, poisonLevel, delta);
		}
	}

	public unsafe void CalcMedicineEffect_ApplyPoison(ref PoisonInts poison, ref MedicineEatingInstantEffect effect, int itemId)
	{
		sbyte poisonType = effect.PoisonType;
		sbyte poisonLevel = (sbyte)effect.EffectThresholdValue;
		int effectValue = CalcMedicineEffectDelta(poison.Items[poisonType], effect.EffectValue, effect.EffectIsPercentage, itemId);
		short delta = PoisonsAndLevels.CalcApplyItemPoisonAmount((short)effectValue, poisonLevel);
		CalcChangedPoisoned(ref poison, poisonType, poisonLevel, delta);
	}

	private void ApplyTeaWineInstantEffect(DataContext context, TeaWineItem config)
	{
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			short qiDelta = config.DirectChangeOfQiDisorder;
			if (config.ItemSubType == 900)
			{
				if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(66))
				{
					int currGained = ProfessionSkillHandle.TeaTasterSkill_GetActionPointGained();
					int canGain = GlobalConfig.Instance.ProfessionSkillRecoverActionPointLimit - currGained;
					int actionPointDelta = config.ActionPointRecover;
					int delta = Math.Min(actionPointDelta, canGain);
					ProfessionSkillHandle.TeaTasterSkill_SetActionPointGained(context, currGained + delta);
					DomainManager.Extra.ChangeActionPoint(context, delta);
					if (delta > 0)
					{
						DomainManager.World.GetInstantNotificationCollection().AddDrinkTeaRecharge(_id, delta / 10);
					}
				}
				ChangeDisorderOfQiRandomRecovery(context, qiDelta);
			}
			else if (!DomainManager.Extra.IsProfessionalSkillUnlocked(7, 1))
			{
				ChangeDisorderOfQiRandomRecovery(context, qiDelta);
			}
		}
		else
		{
			ChangeDisorderOfQiRandomRecovery(context, config.DirectChangeOfQiDisorder);
		}
	}

	private void ApplyFoodInstantEffect(DataContext context, FoodItem config)
	{
		ChangeCurrMainAttributes(context, config.MainAttributesRegen);
	}

	public void CalcMedicineEffect_RecoverInjury(ref Injuries injuries, IRandomSource random, bool inner, ref MedicineEatingInstantEffect config, int itemId)
	{
		List<sbyte> targets = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		int remainRecoveryTimes = CalcMedicineHealInjuryTimes(config.InjuryRecoveryTimes, itemId);
		while (remainRecoveryTimes > 0)
		{
			pool.Clear();
			int maxValue = 0;
			for (sbyte part = 0; part < 7; part++)
			{
				sbyte value = injuries.Get(part, inner);
				if (value <= config.EffectThresholdValue && value > 0 && !targets.Contains(part))
				{
					if (value > maxValue)
					{
						maxValue = value;
						pool.Clear();
					}
					if (value == maxValue)
					{
						pool.Add(part);
					}
				}
			}
			if (pool.Count == 0)
			{
				break;
			}
			int recoveryTimes = Math.Min(remainRecoveryTimes, pool.Count);
			remainRecoveryTimes -= recoveryTimes;
			foreach (sbyte part2 in RandomUtils.GetRandomUnrepeated(random, recoveryTimes, pool))
			{
				targets.Add(part2);
			}
		}
		CalcMedicineEffect_RecoverInjury(ref injuries, targets, inner, ref config, itemId);
		ObjectPool<List<sbyte>>.Instance.Return(targets);
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	public void CalcMedicineEffect_RecoverInjury(ref Injuries injuries, IReadOnlyList<sbyte> bodyParts, bool inner, ref MedicineEatingInstantEffect config, int itemId)
	{
		foreach (sbyte part in bodyParts)
		{
			int effectValue = GetSpecialEffectModifiedMedicineEffectValue(config.EffectValue, itemId);
			injuries.Change(part, inner, -effectValue);
		}
	}

	private void ApplyMedicineInstantEffect_DetoxWug(DataContext context, sbyte wugType, sbyte medicineGrade)
	{
		int index = _eatingItems.IndexOfWug(wugType);
		if (index >= 0)
		{
			short deltaDuration = GameData.Domains.Item.Medicine.GetDeltaWugDuration(medicineGrade);
			short wugTemplateId = _eatingItems.Get(index).TemplateId;
			_eatingItems.ChangeDuration(context, index, deltaDuration);
			SetEatingItems(ref _eatingItems, context);
			if (_eatingItems.Get(index) == ItemKey.Invalid)
			{
				Events.RaiseRemoveWug(context, _id, wugTemplateId);
			}
		}
	}

	private unsafe void OfflineApplyTopicalMedicineInternal(IRandomSource random, MedicineItem config, bool reduceMainAttribute = true, int itemId = -1)
	{
		MedicineEatingInstantEffect effect = new MedicineEatingInstantEffect(config);
		bool isInner = effect.EffectType == EMedicineEffectType.RecoverInnerInjury;
		CalcMedicineEffect_RecoverInjury(ref _injuries, random, isInner, ref effect, itemId);
		sbyte mainAttrType = config.RequiredMainAttributeType;
		if (mainAttrType >= 0 && reduceMainAttribute)
		{
			sbyte mainAttrValue = config.RequiredMainAttributeValue;
			MainAttributes currMainAttributes = GetCurrMainAttributes();
			short currMainAttribute = currMainAttributes.Items[mainAttrType];
			if (currMainAttribute < mainAttrValue)
			{
				AdaptableLog.TagWarning($"Character {_id}", $"Current main attribute {mainAttrType} ({currMainAttribute}/{mainAttrValue}) is not enough to apply topical medicine {config.Name}.");
			}
			else
			{
				ref short reference = ref _currMainAttributes.Items[mainAttrType];
				reference -= mainAttrValue;
			}
		}
	}

	private bool OfflineReplaceWug(DataContext context, int index, ItemKey wugItemKey, short specifyDuration = -1)
	{
		ItemKey oriItemKey = _eatingItems.Get(index);
		if (!EatingItems.IsWug(oriItemKey) || !EatingItems.IsWug(wugItemKey))
		{
			throw new Exception($"cannot replace {oriItemKey} to {wugItemKey} as wug");
		}
		short oriDuration = _eatingItems.GetDuration(index);
		MedicineItem oriConfig = Config.Medicine.Instance[oriItemKey.TemplateId];
		MedicineItem curConfig = Config.Medicine.Instance[wugItemKey.TemplateId];
		short curDuration = ((specifyDuration < 0) ? oriDuration : specifyDuration);
		if (oriConfig.WugGrowthType == curConfig.WugGrowthType)
		{
			curDuration = Math.Max(curDuration, (specifyDuration < 0) ? curConfig.Duration : oriDuration);
		}
		_eatingItems.Clear(index);
		_eatingItems.Set(index, wugItemKey, curDuration);
		Events.RaiseRemoveWug(context, _id, oriConfig.TemplateId);
		Events.RaiseAddWug(context, _id, curConfig.TemplateId, oriConfig.TemplateId);
		if (oriItemKey.IsValid())
		{
			DomainManager.Item.RemoveItem(context, oriItemKey);
		}
		return true;
	}

	private unsafe bool OfflineAddNewWug(DataContext context, ItemKey wugItemKey, short specifyDuration = -1)
	{
		sbyte index = _eatingItems.GetSlotForNewWug();
		if (index < 0)
		{
			throw new Exception($"Character {_id}: There is no potential available eating slot");
		}
		MedicineItem config = Config.Medicine.Instance[wugItemKey.TemplateId];
		if (((ItemKey)_eatingItems.ItemKeys[index]).IsValid())
		{
			_eatingItems.Clear(index);
		}
		_eatingItems.Set(index, wugItemKey, (specifyDuration < 0) ? config.Duration : specifyDuration);
		Events.RaiseAddWug(context, _id, wugItemKey.TemplateId, -1);
		return true;
	}

	public void ApplyLoopingExtraNeiliAllocationProgressModify(DataContext context, int[] extraNeiliAllocationProgress)
	{
		int[] characterExtraNeiliAllocationProgress = GetExtraNeiliAllocationProgress();
		NeiliAllocation deltaAllocation = default(NeiliAllocation);
		for (int neiliType = 0; neiliType < 4; neiliType++)
		{
			int currentProgress = characterExtraNeiliAllocationProgress[neiliType];
			int maxProgress = GetNeiliAllocationMaxProgress();
			int deltaProgress = extraNeiliAllocationProgress[neiliType];
			if (deltaProgress > 0 && currentProgress >= maxProgress)
			{
				deltaProgress = 0;
			}
			characterExtraNeiliAllocationProgress[neiliType] = Math.Max(0, currentProgress + deltaProgress);
			int newProgress = characterExtraNeiliAllocationProgress[neiliType];
			int delta = CalculateDeltaNeiliAllocation(currentProgress, newProgress);
			deltaAllocation[neiliType] = (short)delta;
		}
		SetExtraNeiliAllocationProgressWithHooks(characterExtraNeiliAllocationProgress, context);
		ChangeExtraNeiliAllocation(context, deltaAllocation);
	}

	private static int CalculateDeltaNeiliAllocation(int currentProgress, int newProgress)
	{
		if (newProgress > currentProgress)
		{
			return GetNeiliAllocationProgressMilestoneCount(currentProgress, newProgress);
		}
		return -GetNeiliAllocationProgressMilestoneCount(newProgress, currentProgress);
	}

	[Obsolete]
	private static List<int> GenerateNeiliAllocationProgressMinestones(int currentProgress, int newProgress)
	{
		int basic = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * 100;
		int delta = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatioGrowth * 100;
		int p0 = 0;
		int d0 = basic;
		List<int> result = new List<int>();
		while (p0 <= newProgress)
		{
			if (p0 > currentProgress)
			{
				result.Add(p0);
			}
			p0 += d0;
			d0 += delta;
		}
		return result;
	}

	private static int GetNeiliAllocationProgressMilestoneCount(int currentProgress, int newProgress)
	{
		int basic = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * 100;
		int delta = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatioGrowth * 100;
		int p0 = 0;
		int d0 = basic;
		int count = 0;
		while (p0 <= newProgress)
		{
			if (p0 > currentProgress)
			{
				count++;
			}
			p0 += d0;
			d0 += delta;
		}
		return count;
	}

	private static int GetNeiliAllocationProgressMilestoneByIndex(int currentProgress, int newProgress, int index)
	{
		int basic = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * 100;
		int delta = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatioGrowth * 100;
		int p0 = 0;
		int d0 = basic;
		int count = -1;
		while (p0 <= newProgress)
		{
			if (p0 > currentProgress)
			{
				count++;
				if (count == index)
				{
					return p0;
				}
			}
			p0 += d0;
			d0 += delta;
		}
		throw new ArgumentOutOfRangeException("index", "下标超出了可用进度节点的范围");
	}

	public static int GetExtraNeiliAllocationByProgress(int currentProgress)
	{
		int basic = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * 100;
		int delta = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatioGrowth * 100;
		int p0 = 0;
		int d0 = basic;
		int extra = 0;
		while (p0 <= currentProgress)
		{
			if (p0 > 0)
			{
				extra++;
			}
			p0 += d0;
			d0 += delta;
		}
		return extra;
	}

	public static int GetNeiliAllocationMaxProgress()
	{
		short n = GlobalConfig.Instance.MaxExtraNeiliAllocation;
		return GetExtraNeiliAllocationProgressByExtraNeiliAllocation(n);
	}

	public static int GetExtraNeiliAllocationProgressByExtraNeiliAllocation(int extraNeiliAllocation)
	{
		int basic = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * 100;
		int delta = GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatioGrowth * 100;
		return basic * extraNeiliAllocation + delta * (extraNeiliAllocation * (extraNeiliAllocation - 1)) / 2;
	}

	public unsafe void SetExtraNeiliAllocationAndProgress(DataContext context, int[] extraNeiliAllocationProgress, bool canOverMax = false)
	{
		int maxProgress = GetNeiliAllocationMaxProgress();
		NeiliAllocation extraNeiliAllocation = default(NeiliAllocation);
		extraNeiliAllocation.Initialize();
		for (int i = 0; i < 4; i++)
		{
			int progress = (canOverMax ? extraNeiliAllocationProgress[i] : Math.Clamp(extraNeiliAllocationProgress[i], 0, maxProgress));
			extraNeiliAllocation.Items[i] = (short)GetExtraNeiliAllocationByProgress(progress);
		}
		SetExtraNeiliAllocationProgressWithHooks(extraNeiliAllocationProgress, context);
		SetExtraNeiliAllocation(extraNeiliAllocation, context);
	}

	public unsafe short AddExtraNeiliAllocationProgressToGainExtraNeiliAllocation(DataContext context, byte neiliAllocationType, int deltaNeiliAllocation, bool allowOverMax = false)
	{
		int maxProgress = GetNeiliAllocationMaxProgress();
		if (allowOverMax)
		{
			maxProgress = int.MaxValue;
		}
		int[] progress = GetExtraNeiliAllocationProgress();
		int milestonesCount = GetNeiliAllocationProgressMilestoneCount(progress[neiliAllocationType], maxProgress);
		int targetProgressIndex = Math.Min(milestonesCount - 1, deltaNeiliAllocation - 1);
		int targetProgress = GetNeiliAllocationProgressMilestoneByIndex(progress[neiliAllocationType], maxProgress, targetProgressIndex);
		NeiliAllocation extraNeiliAllocation = GetExtraNeiliAllocation();
		progress[neiliAllocationType] = targetProgress;
		short deltaExtraNeiliAllocation = (short)(targetProgressIndex + 1);
		ref short reference = ref extraNeiliAllocation.Items[(int)neiliAllocationType];
		reference += deltaExtraNeiliAllocation;
		SetExtraNeiliAllocation(extraNeiliAllocation, context);
		SetExtraNeiliAllocationProgressWithHooks(progress, context);
		return deltaExtraNeiliAllocation;
	}

	public void SetExtraNeiliAllocationProgressWithHooks(int[] extraNeiliAllocationProgress, DataContext context)
	{
		SetExtraNeiliAllocationProgress(extraNeiliAllocationProgress, context);
		CheckExtraNeiliAllocationMaxAchievements(extraNeiliAllocationProgress, context);
	}

	private void CheckExtraNeiliAllocationMaxAchievements(int[] extraNeiliAllocationProgress, DataContext context)
	{
		if (!IsTaiwu())
		{
			return;
		}
		int maxProgress = GetNeiliAllocationMaxProgress();
		for (int i = 0; i < 4; i++)
		{
			if (extraNeiliAllocationProgress[i] >= maxProgress)
			{
				if (1 == 0)
				{
				}
				short num = i switch
				{
					0 => 83, 
					1 => 84, 
					2 => 85, 
					_ => 86, 
				};
				if (1 == 0)
				{
				}
				short stat = num;
				AchievementManager.RequestSetStat(context, stat, 1);
			}
		}
	}

	public sbyte GetFameType()
	{
		sbyte fameType = FameType.GetFameType(GetFame());
		if (fameType != 3)
		{
			return fameType;
		}
		return (sbyte)(IsBothGoodAndBad() ? (-2) : 3);
	}

	public void RecordFameAction(DataContext context, short fameActionId, int targetCharId = -1, short fameMultiplier = 1, bool jumpAccordingToTargetFame = true)
	{
		FameActionItem template = FameAction.Instance[fameActionId];
		if (targetCharId >= 0 && template.HasJump && jumpAccordingToTargetFame)
		{
			sbyte targetFameType = 3;
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				targetFameType = targetChar.GetFameType();
			}
			else
			{
				DeadCharacter deadChar = DomainManager.Character.TryGetDeadCharacter(targetCharId);
				if (deadChar != null)
				{
					targetFameType = deadChar.FameType;
				}
			}
			RecordFameAction(context, fameActionId, targetFameType, fameMultiplier);
		}
		else
		{
			RecordFameActionInternal(context, fameActionId, fameMultiplier);
		}
	}

	public void RecordFameAction(DataContext context, short fameActionId, sbyte targetFameType, short fameMultiplier = 1)
	{
		FameActionItem template = FameAction.Instance[fameActionId];
		if (targetFameType >= 0 && template.HasJump)
		{
			fameActionId = ((targetFameType == 3 || targetFameType == -2) ? template.NormalJumpId : ((targetFameType >= 3) ? template.GoodJumpId : template.BadJumpId));
			if (fameActionId < 0)
			{
				return;
			}
		}
		RecordFameActionInternal(context, fameActionId, fameMultiplier);
	}

	private bool IsBothGoodAndBad()
	{
		if (_creatingType != 1)
		{
			return false;
		}
		var (valueGood, valueBad) = SharedMethods.GetFame(_featureIds, _fameActionRecords, _organizationInfo, DomainManager.World.GetCurrDate(), IsTaiwu());
		return valueGood + valueBad >= GlobalConfig.Instance.FameAbsValueForBothGoodAndBad;
	}

	private void RecordFameActionInternal(DataContext context, short fameActionId, short fameMultiplier)
	{
		FameActionItem template = FameAction.Instance[fameActionId];
		int currDate = DomainManager.World.GetCurrDate();
		int index = -1;
		int i = 0;
		for (int recordsCount = _fameActionRecords.Count; i < recordsCount; i++)
		{
			FameActionRecord record = _fameActionRecords[i];
			if (record.EndDate <= currDate)
			{
				CollectionUtils.SwapAndRemove(_fameActionRecords, i);
				i--;
				recordsCount--;
			}
			else if (record.Id == fameActionId)
			{
				index = i;
			}
		}
		if (index >= 0)
		{
			FameActionRecord record2 = _fameActionRecords[index];
			int value = record2.Value + template.Fame * fameMultiplier;
			int limit = template.Fame * template.MaxStackCount;
			value = ((template.Fame <= 0) ? ((value < limit) ? limit : value) : ((value > limit) ? limit : value));
			record2.Value = (short)value;
			if (template.RepeatType == 0)
			{
				record2.EndDate = currDate + template.Duration;
			}
			else
			{
				record2.EndDate += template.Duration;
			}
			_fameActionRecords[index] = record2;
		}
		else
		{
			short value2 = (short)(template.Fame * Math.Min(fameMultiplier, template.MaxStackCount));
			FameActionRecord record3 = new FameActionRecord(fameActionId, value2, currDate + template.Duration);
			_fameActionRecords.Add(record3);
		}
		if (DomainManager.Extra.IsCharacterCanGetExtraLegacyPoints(_id))
		{
			switch (Config.Organization.Instance[_organizationInfo.OrgTemplateId].Goodness)
			{
			case 1:
				DomainManager.Extra.AddSectJieqingNpcExtraLegacyPoints(context, _id, template.GoodSectExtraLegacyPoint);
				break;
			case -1:
				DomainManager.Extra.AddSectJieqingNpcExtraLegacyPoints(context, _id, template.EvilSectExtraLegacyPoint);
				break;
			default:
				DomainManager.Extra.AddSectJieqingNpcExtraLegacyPoints(context, _id, (template.EvilSectExtraLegacyPoint + template.GoodSectExtraLegacyPoint) / 2);
				break;
			}
		}
		SetFameActionRecords(_fameActionRecords, context);
		Events.RaiseFameActionRecorded(context, this, fameActionId);
	}

	public bool AddFeature(DataContext context, short featureId, bool removeMutexFeature = false)
	{
		bool success = OfflineAddFeature(featureId, removeMutexFeature);
		if (success)
		{
			SetFeatureIds(_featureIds, context);
			Events.RaiseCharacterFeatureAdded(context, this, featureId);
		}
		return success;
	}

	public void RevertFeatures(DataContext context, List<ShortListModification> modifications)
	{
		for (int i = modifications.Count - 1; i >= 0; i--)
		{
			ShortListModification mod = modifications[i];
			if (mod.ModificationType == 0)
			{
				if (mod.Index < _featureIds.Count && _featureIds[mod.Index] == mod.Element)
				{
					_featureIds.RemoveAt(mod.Index);
				}
				else
				{
					_featureIds.Remove(mod.Element);
				}
			}
			else if (mod.Index <= _featureIds.Count)
			{
				_featureIds.Insert(mod.Index, mod.Element);
			}
			else
			{
				_featureIds.Add(mod.Element);
			}
		}
		CheckForMutexFeatures();
		SetFeatureIds(_featureIds, context);
	}

	public void RemoveFeature(DataContext context, short featureId)
	{
		if (_featureIds.Remove(featureId))
		{
			SetFeatureIds(_featureIds, context);
			Events.RaiseCharacterFeatureRemoved(context, this, featureId);
		}
	}

	public void ClearGeneticFeatures(DataContext context)
	{
		for (int i = _featureIds.Count - 1; i >= 0; i--)
		{
			short featureId = _featureIds[i];
			CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId];
			if (featureCfg.GeneticProb != 0)
			{
				_featureIds.RemoveAt(i);
				DomainManager.SpecialEffect.RemoveFeatureEffect(context, _id, featureId);
			}
		}
		SetFeatureIds(_featureIds, context);
	}

	public bool RemoveFeatureGroup(DataContext context, short featureGroupId)
	{
		CharacterFeature config = CharacterFeature.Instance;
		int i = 0;
		for (int count = _featureIds.Count; i < count; i++)
		{
			short currFeatureId = _featureIds[i];
			CharacterFeatureItem currFeatureConfig = config[currFeatureId];
			if (currFeatureConfig.MutexGroupId == featureGroupId)
			{
				_featureIds.RemoveAt(i);
				SetFeatureIds(_featureIds, context);
				return true;
			}
		}
		return false;
	}

	public short GetGroupFeature(short featureGroupId)
	{
		CharacterFeature config = CharacterFeature.Instance;
		int i = 0;
		for (int count = _featureIds.Count; i < count; i++)
		{
			short currFeatureId = _featureIds[i];
			short currGroupId = config[currFeatureId].MutexGroupId;
			if (currGroupId == featureGroupId)
			{
				return currFeatureId;
			}
		}
		return -1;
	}

	public void CalcGroupFeatures(Dictionary<short, short> groupToFeatures)
	{
		groupToFeatures.Clear();
		int i = 0;
		for (int count = _featureIds.Count; i < count; i++)
		{
			short currFeatureId = _featureIds[i];
			short currGroupId = CharacterFeature.Instance[currFeatureId].MutexGroupId;
			if (currGroupId >= 0)
			{
				groupToFeatures.Add(currGroupId, currFeatureId);
			}
		}
	}

	public bool ChangeFeatureByWugKing(IRandomSource random)
	{
		Dictionary<short, short> groupToFeatures = ObjectPool<Dictionary<short, short>>.Instance.Get();
		List<short> nonexistentLowestBadFeatures = ObjectPool<List<short>>.Instance.Get();
		List<short> notHighestBadFeatures = ObjectPool<List<short>>.Instance.Get();
		List<short> notLowestGoodFeatures = ObjectPool<List<short>>.Instance.Get();
		List<short> lowestGoodFeatures = ObjectPool<List<short>>.Instance.Get();
		CalcGroupFeatures(groupToFeatures);
		nonexistentLowestBadFeatures.Clear();
		notHighestBadFeatures.Clear();
		notLowestGoodFeatures.Clear();
		lowestGoodFeatures.Clear();
		foreach (CharacterFeatureItem featureConfig in (IEnumerable<CharacterFeatureItem>)CharacterFeature.Instance)
		{
			if (!featureConfig.IsNormal() || featureConfig.IsNeutral())
			{
				continue;
			}
			if (groupToFeatures.TryGetValue(featureConfig.MutexGroupId, out var templateId))
			{
				if (templateId == featureConfig.TemplateId)
				{
					if (featureConfig.IsGood())
					{
						(featureConfig.IsLowest() ? lowestGoodFeatures : notLowestGoodFeatures).Add(featureConfig.TemplateId);
					}
					else if (featureConfig.IsBad() && !featureConfig.IsHighest())
					{
						notHighestBadFeatures.Add(featureConfig.TemplateId);
					}
				}
			}
			else if (featureConfig.IsBad() && featureConfig.IsLowest())
			{
				nonexistentLowestBadFeatures.Add(featureConfig.TemplateId);
			}
		}
		bool featureChanged = true;
		if (nonexistentLowestBadFeatures.Count > 0)
		{
			_featureIds.Add(nonexistentLowestBadFeatures.GetRandom(random));
		}
		else if (notHighestBadFeatures.Count > 0)
		{
			short featureId = notHighestBadFeatures.GetRandom(random);
			_featureIds.Remove(featureId);
			_featureIds.Add(CharacterFeature.Instance[featureId].Upgrade().TemplateId);
		}
		else if (notLowestGoodFeatures.Count > 0)
		{
			short featureId2 = notLowestGoodFeatures.GetRandom(random);
			_featureIds.Remove(featureId2);
			_featureIds.Add(CharacterFeature.Instance[featureId2].Degrade().TemplateId);
		}
		else if (lowestGoodFeatures.Count > 0)
		{
			_featureIds.Remove(lowestGoodFeatures.GetRandom(random));
		}
		else
		{
			featureChanged = false;
		}
		ObjectPool<Dictionary<short, short>>.Instance.Return(groupToFeatures);
		ObjectPool<List<short>>.Instance.Return(nonexistentLowestBadFeatures);
		ObjectPool<List<short>>.Instance.Return(notHighestBadFeatures);
		ObjectPool<List<short>>.Instance.Return(notLowestGoodFeatures);
		ObjectPool<List<short>>.Instance.Return(lowestGoodFeatures);
		if (featureChanged)
		{
			_featureIds.Sort(CharacterFeatureHelper.FeatureComparer);
		}
		return featureChanged;
	}

	public int GetFeatureMedalValue(sbyte medalType)
	{
		int result = CharacterFeatureHelper.CalcFeatureMedalValue(_featureIds, medalType);
		if (medalType == 2)
		{
			result *= CalcMysteryBonus(ECharacterPropertyReferencedType.Wisdom);
		}
		return result;
	}

	public bool IsCompletelyInfected()
	{
		return _organizationInfo.OrgTemplateId == 20;
	}

	public bool IsPartiallyInfected()
	{
		return GetGroupFeature(209) == 210;
	}

	public bool HasVirginity()
	{
		return _featureIds.Contains(196);
	}

	public void LoseVirginity(DataContext context)
	{
		AddFeature(context, 197, removeMutexFeature: true);
	}

	public void GetInscribableFeatureIds(List<short> featureIds)
	{
		int i = 0;
		for (int count = _featureIds.Count; i < count; i++)
		{
			short featureId = _featureIds[i];
			CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId];
			if (featureCfg.Inscribable)
			{
				featureIds.Add(featureId);
			}
		}
	}

	public List<short> GetChickenFeatures()
	{
		return _featureIds.Where((short f) => CharacterFeature.Instance[f].IsChickenFeature).ToList();
	}

	public CValueModifyDelta GetFeatureBonusHealOuterInjury()
	{
		int res = 0;
		foreach (short id in _featureIds)
		{
			CharacterFeatureItem config = CharacterFeature.Instance[id];
			if (config.HealOuterBonus != 0)
			{
				res += config.HealOuterBonus;
			}
		}
		return new CValueModifyDelta(EDataModifyType.AddPercent, res);
	}

	public CValueModifyDelta GetFeatureBonusHealInnerInjury()
	{
		int res = 0;
		foreach (short id in _featureIds)
		{
			CharacterFeatureItem config = CharacterFeature.Instance[id];
			if (config.HealInnerBonus != 0)
			{
				res += config.HealInnerBonus;
			}
		}
		return new CValueModifyDelta(EDataModifyType.AddPercent, res);
	}

	public CValueModifyDelta GetFeatureBonusDetoxPoison(sbyte poisonType)
	{
		return new CValueModifyDelta(EDataModifyType.AddPercent, GetFeatureBonusDetoxPoisonValue(poisonType));
	}

	public CValueModifyDelta GetFeatureBonusAttachPoison(sbyte poisonType)
	{
		return new CValueModifyDelta(EDataModifyType.AddPercent, GetFeatureBonusAttachPoisonValue(poisonType));
	}

	public int GetFeatureBonusDetoxPoisonValue(sbyte poisonType)
	{
		int res = 0;
		foreach (short id in _featureIds)
		{
			CharacterFeatureItem config = CharacterFeature.Instance[id];
			if (config.DetoxPoisonBonus == poisonType)
			{
				res += GlobalConfig.Instance.SolarTermAddHealPoison;
			}
		}
		return res;
	}

	public int GetFeatureBonusAttachPoisonValue(sbyte poisonType)
	{
		int res = 0;
		foreach (short id in _featureIds)
		{
			CharacterFeatureItem config = CharacterFeature.Instance[id];
			if (config.AttachPoisonBonus == poisonType)
			{
				res += GlobalConfig.Instance.SolarTermAddPoisonEffect;
			}
		}
		return res;
	}

	private bool OfflineAddFeature(short featureId, bool removeMutexFeature, bool removeLowerOnly = false)
	{
		CharacterFeatureItem featureConfig = CharacterFeature.Instance[featureId];
		if (featureConfig.Gender != -1 && featureConfig.Gender != _gender)
		{
			return false;
		}
		short groupId = featureConfig.MutexGroupId;
		bool replaced = false;
		int i = 0;
		for (int featuresCount = _featureIds.Count; i < featuresCount; i++)
		{
			short currFeatureId = _featureIds[i];
			CharacterFeatureItem currFeature = CharacterFeature.Instance[currFeatureId];
			if (currFeature.MutexGroupId == groupId)
			{
				if (!removeMutexFeature)
				{
					return false;
				}
				if (removeLowerOnly && currFeature.Level >= featureConfig.Level)
				{
					return false;
				}
				_featureIds[i] = featureId;
				replaced = true;
				break;
			}
		}
		if (!replaced)
		{
			int index = _featureIds.BinarySearch(featureId, CharacterFeatureHelper.FeatureComparer);
			if (index < 0)
			{
				index = ~index;
			}
			if (index >= _featureIds.Count)
			{
				_featureIds.Add(featureId);
			}
			else
			{
				_featureIds.Insert(index, featureId);
			}
		}
		return true;
	}

	private void CheckForMutexFeatures()
	{
		CharacterFeature featureConfig = CharacterFeature.Instance;
		int featuresCount = _featureIds.Count;
		HashSet<short> groupIds = new HashSet<short>(featuresCount);
		for (int i = 0; i < featuresCount; i++)
		{
			short featureId = _featureIds[i];
			short groupId = featureConfig[featureId].MutexGroupId;
			if (!groupIds.Add(groupId))
			{
				throw new Exception($"Character {_id}: contains mutex features: {groupId}");
			}
		}
	}

	public bool IsLoseConsummateBonusByFeature()
	{
		return _featureIds.Any((short f) => CharacterFeature.Instance[f].LoseConsummateBonus);
	}

	public bool NeedHealAction(EHealActionType type)
	{
		if (1 == 0)
		{
		}
		bool result = type switch
		{
			EHealActionType.Healing => _injuries.HasAnyInjury(), 
			EHealActionType.Detox => _poisoned.IsNonZero(), 
			EHealActionType.Breathing => _disorderOfQi > 0, 
			EHealActionType.Recover => _health < GetLeftMaxHealth(), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public int CalcHealCostHerb(EHealActionType type, bool isExpensiveHeal = false)
	{
		if (1 == 0)
		{
		}
		int num = type switch
		{
			EHealActionType.Healing => CombatDomain.GetHealInjuryCostHerb(_injuries), 
			EHealActionType.Detox => CombatDomain.GetHealPoisonCostHerb(_poisoned), 
			EHealActionType.Breathing => CombatDomain.GetHealQiDisorderCostHerb(_disorderOfQi), 
			EHealActionType.Recover => CombatDomain.GetHealHealthCostHerb(GetHealthType()), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
		if (1 == 0)
		{
		}
		int baseCost = num;
		return isExpensiveHeal ? (2 * baseCost) : baseCost;
	}

	public int CalcHealCostMoney(EHealActionType type, sbyte doctorBehaviorType, bool isExpensiveHeal = false)
	{
		if (1 == 0)
		{
		}
		int num = type switch
		{
			EHealActionType.Healing => CombatDomain.GetHealInjuryCostMoney(_injuries, doctorBehaviorType), 
			EHealActionType.Detox => CombatDomain.GetHealPoisonCostMoney(_poisoned, doctorBehaviorType), 
			EHealActionType.Breathing => CombatDomain.GetHealQiDisorderCostMoney(_disorderOfQi, doctorBehaviorType), 
			EHealActionType.Recover => CombatDomain.GetHealHealthCostMoney(GetHealthType(), doctorBehaviorType), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
		if (1 == 0)
		{
		}
		int baseCost = num;
		return isExpensiveHeal ? (2 * baseCost) : baseCost;
	}

	public int CalcHealCostSpiritualDebt(EHealActionType type)
	{
		if (1 == 0)
		{
		}
		int result = type switch
		{
			EHealActionType.Healing => CombatDomain.GetHealInjuryCostSpiritualDebt(_injuries), 
			EHealActionType.Detox => CombatDomain.GetHealPoisonCostSpiritualDebt(_poisoned), 
			EHealActionType.Breathing => CombatDomain.GetHealQiDisorderCostSpiritualDebt(_disorderOfQi), 
			EHealActionType.Recover => CombatDomain.GetHealHealthCostSpiritualDebt(GetHealthType()), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public int CalcHealAttainment(EHealActionType type)
	{
		LifeSkillShorts attainments = GetLifeSkillAttainments();
		if (1 == 0)
		{
		}
		short result = type switch
		{
			EHealActionType.Healing => attainments[8], 
			EHealActionType.Detox => attainments[9], 
			EHealActionType.Breathing => Math.Max(attainments[8], attainments[9]), 
			EHealActionType.Recover => Math.Max(attainments[8], attainments[9]), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public int CalcHealEffect(EHealActionType type, Character patient, out int maxRequireAttainment, bool isExpensiveHeal = false)
	{
		maxRequireAttainment = 0;
		int patientId = patient.GetId();
		int maxHealMarkCount;
		switch (type)
		{
		case EHealActionType.Healing:
		{
			maxRequireAttainment = DomainManager.Combat.GetHealInjuryMaxRequireAttainment(patientId);
			DomainManager.Combat.HealInjury(patientId, this, out var _, out var allHealMarkCount, out maxHealMarkCount, canHealOld: true, getCost: true, checkHerb: false, null, null, isExpensiveHeal);
			return allHealMarkCount;
		}
		case EHealActionType.Detox:
		{
			maxRequireAttainment = DomainManager.Combat.GetHealPoisonMaxRequireAttainment(patientId);
			DomainManager.Combat.HealPoison(patientId, this, out maxHealMarkCount, out var healPoisonValue, canHealOld: true, getCost: true, checkHerb: false, isExpensiveHeal);
			return healPoisonValue;
		}
		case EHealActionType.Breathing:
		{
			maxRequireAttainment = DomainManager.Combat.GetHealQiDisorderRequireAttainment(patientId);
			short disorderOfQi = patient.GetDisorderOfQi();
			short result2 = DomainManager.Combat.HealQiDisorder(patientId, this, isExpensiveHeal);
			return disorderOfQi - result2;
		}
		case EHealActionType.Recover:
		{
			maxRequireAttainment = DomainManager.Combat.GetHealHealthRequireAttainment(patientId);
			short health = patient.GetHealth();
			short result = DomainManager.Combat.HealHealth(patientId, this, isExpensiveHeal);
			return result - health;
		}
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	public bool DoHealAction(DataContext context, EHealActionType type, Character patient, bool canGetProfessionSeniority = false, bool isExpensiveHeal = false)
	{
		int patientId = patient.GetId();
		switch (type)
		{
		case EHealActionType.Healing:
		{
			Injuries injuries = patient.GetInjuries();
			Injuries result3 = DomainManager.Combat.HealInjury(patientId, this, isExpensiveHeal);
			patient.SetInjuries(result3, context);
			Injuries marks = injuries.Subtract(result3);
			if (canGetProfessionSeniority)
			{
				ProfessionFormulaItem formula3 = ProfessionFormula.Instance[86];
				int total = 0;
				for (sbyte i = 0; i < 7; i++)
				{
					sbyte count = marks.Get(i, isInnerInjury: true);
					if (count > 0)
					{
						total += formula3.Calculate(count - 1);
					}
					count = marks.Get(i, isInnerInjury: false);
					if (count > 0)
					{
						total += formula3.Calculate(count - 1);
					}
					if (total > 0)
					{
						DomainManager.Extra.ChangeProfessionSeniority(context, 13, total);
					}
				}
			}
			return marks.GetSum() != 0;
		}
		case EHealActionType.Detox:
		{
			PoisonInts poisons = patient.GetPoisoned();
			PoisonInts result2 = DomainManager.Combat.HealPoison(patientId, this, isExpensiveHeal);
			patient.SetPoisoned(ref result2, context);
			if (canGetProfessionSeniority)
			{
				ProfessionFormulaItem formula2 = ProfessionFormula.Instance[87];
				for (sbyte poisonType = 0; poisonType < 6; poisonType++)
				{
					int poisonDelta = poisons[poisonType] - result2[poisonType];
					sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonDelta);
					if (poisonLevel > 0)
					{
						DomainManager.Extra.ChangeProfessionSeniority(context, 13, formula2.Calculate(poisonLevel - 1));
					}
				}
			}
			return poisons.Subtract(ref result2).IsNonZero();
		}
		case EHealActionType.Breathing:
		{
			short disorderOfQi = patient.GetDisorderOfQi();
			short result4 = DomainManager.Combat.HealQiDisorder(patientId, this, isExpensiveHeal);
			patient.SetDisorderOfQi(result4, context);
			int delta2 = disorderOfQi - result4;
			if (canGetProfessionSeniority)
			{
				ProfessionFormulaItem formula4 = ProfessionFormula.Instance[88];
				int addSeniority2 = formula4.Calculate(delta2);
				DomainManager.Extra.ChangeProfessionSeniority(context, 13, addSeniority2);
			}
			return delta2 > 0;
		}
		case EHealActionType.Recover:
		{
			short health = patient.GetHealth();
			short result = DomainManager.Combat.HealHealth(patientId, this, isExpensiveHeal);
			patient.SetHealth(result, context);
			int delta = result - health;
			if (canGetProfessionSeniority)
			{
				ProfessionFormulaItem formula = ProfessionFormula.Instance[89];
				int addSeniority = formula.Calculate(delta);
				DomainManager.Extra.ChangeProfessionSeniority(context, 13, addSeniority);
			}
			return delta > 0;
		}
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	public short GetClothingDisplayId()
	{
		if (DomainManager.LegendaryBook.IsLegendaryBookConsumed(_id))
		{
			return 10003;
		}
		if (Template.ShowLegendaryBookConsumedCloth)
		{
			return 10003;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Character.TryGetRelation(taiwuCharId, _id, out var relation) && (relation.RelationType & 2) != 0)
		{
			short age = GetPhysiologicalAge();
			if (age < GlobalConfig.Instance.AgeBaby)
			{
				return 10;
			}
			if (age < 16)
			{
				return 19;
			}
		}
		ItemKey clothingKey = _equipment[4];
		if (clothingKey.IsValid() && !DomainManager.Item.GetBaseItem(clothingKey).IsDurabilityRunningOut())
		{
			short displayId = DomainManager.Taiwu.GetActualClothingDisplayId(clothingKey);
			OrganizationInfo orgnization = GetOrganizationInfo();
			short avatarAge = GetPhysiologicalAge();
			bool isChild = avatarAge >= GlobalConfig.Instance.AgeBaby && avatarAge < 16;
			bool isSect = orgnization.OrgTemplateId >= 1 && orgnization.OrgTemplateId <= 15;
			bool isCity = orgnization.OrgTemplateId >= 21 && orgnization.OrgTemplateId <= 35;
			if (isChild)
			{
				if (isSect)
				{
					int offset = orgnization.OrgTemplateId - 1;
					displayId = (short)(4 + offset);
				}
				else
				{
					displayId = (short)(displayId % 3 + 1);
				}
			}
			if (avatarAge < GlobalConfig.Instance.AgeBaby)
			{
				if (isSect)
				{
					sbyte grade = orgnization.Grade;
					if (1 == 0)
					{
					}
					short num;
					switch (grade)
					{
					case 0:
					case 1:
					case 2:
						num = 4;
						break;
					case 3:
					case 4:
					case 5:
						num = 5;
						break;
					case 6:
					case 7:
					case 8:
						num = 6;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					if (1 == 0)
					{
					}
					displayId = num;
				}
				else if (isCity)
				{
					sbyte grade2 = orgnization.Grade;
					if (1 == 0)
					{
					}
					short num;
					switch (grade2)
					{
					case 0:
					case 1:
					case 2:
						num = 7;
						break;
					case 3:
					case 4:
					case 5:
						num = 8;
						break;
					case 6:
					case 7:
					case 8:
						num = 9;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					if (1 == 0)
					{
					}
					displayId = num;
				}
				else
				{
					displayId = (short)(displayId % 3 + 1);
				}
			}
			return displayId;
		}
		return (short)((DomainManager.Character.GetSkeletonSourceGraveId(_id) >= 0) ? 20003 : 0);
	}

	private short GetClothingDisplayIdForCharm()
	{
		if (DomainManager.LegendaryBook.IsLegendaryBookConsumed(_id))
		{
			return 10003;
		}
		if (Template.ShowLegendaryBookConsumedCloth)
		{
			return 10003;
		}
		ItemKey clothingKey = _equipment[4];
		if (clothingKey.IsValid() && !DomainManager.Item.GetBaseItem(clothingKey).IsDurabilityRunningOut())
		{
			return Config.Clothing.Instance[clothingKey.TemplateId].DisplayId;
		}
		return (short)((DomainManager.Character.GetSkeletonSourceGraveId(_id) >= 0) ? 20003 : 0);
	}

	public IEnumerable<ItemKey> GetValidCarrierEquipment()
	{
		ItemKey carrier = _equipment[11];
		if (carrier.ItemType == 4)
		{
			yield return carrier;
		}
		ItemKey livestockCarrier = _equipment[12];
		if (livestockCarrier.ItemType == 4)
		{
			yield return livestockCarrier;
		}
	}

	public IEnumerable<ItemKey> GetValidAnimalEquipment()
	{
		foreach (sbyte index in GetAnimalEquipmentIndexes())
		{
			ItemKey carrier = _equipment[index];
			if (carrier.ItemType == 4)
			{
				yield return carrier;
			}
		}
	}

	public IEnumerable<sbyte> GetAnimalEquipmentIndexes()
	{
		yield return 12;
		yield return 13;
	}

	public bool HasEquippedItem(sbyte itemType, short templateId)
	{
		for (int i = 0; i < _equipment.Length; i++)
		{
			if (_equipment[i].TemplateEquals(itemType, templateId))
			{
				return true;
			}
		}
		return false;
	}

	public bool UnequipItem(DataContext context, ItemKey itemKey)
	{
		int equipSlot = _equipment.IndexOf(itemKey);
		if (equipSlot < 0)
		{
			return false;
		}
		ChangeEquipment(context, (sbyte)equipSlot, -1, itemKey);
		return true;
	}

	public void ChangeEquipment(DataContext context, sbyte srcSlot, sbyte destSlot, ItemKey srcItemKey)
	{
		if (srcSlot >= 0)
		{
			srcItemKey = _equipment[srcSlot];
			_equipment[srcSlot] = ItemKey.Invalid;
		}
		else
		{
			_inventory.OfflineRemove(srcItemKey, 1);
		}
		EquipmentBase srcItem = DomainManager.Item.GetBaseEquipment(srcItemKey);
		srcItem.ResetOwner();
		ItemKey destItemKey;
		if (destSlot >= 0)
		{
			destItemKey = _equipment[destSlot];
			_equipment[destSlot] = srcItemKey;
			srcItem.SetEquippedCharId(_id, context);
			srcItem.SetOwner(ItemOwnerType.CharacterEquipment, _id);
		}
		else
		{
			destItemKey = ItemKey.Invalid;
			_inventory.OfflineAdd(srcItemKey, 1);
			srcItem.SetEquippedCharId(-1, context);
			srcItem.SetOwner(ItemOwnerType.CharacterInventory, _id);
		}
		DomainManager.Item.UpdateMysteryEffect(context, srcItemKey.Id);
		if (destItemKey.IsValid())
		{
			EquipmentBase destItem = DomainManager.Item.GetBaseEquipment(destItemKey);
			if (srcSlot >= 0)
			{
				_equipment[srcSlot] = destItemKey;
				destItem.SetOwner(ItemOwnerType.CharacterEquipment, _id);
			}
			else
			{
				_inventory.OfflineAdd(destItemKey, 1);
				destItem.SetEquippedCharId(-1, context);
				destItem.RemoveOwner(ItemOwnerType.CharacterEquipment, _id);
				destItem.SetOwner(ItemOwnerType.CharacterInventory, _id);
				DomainManager.Item.UpdateMysteryEffect(context, destItemKey.Id);
			}
		}
		SetEquipment(_equipment, context);
		SetInventory(_inventory, context);
	}

	public void ChangeEquipment(DataContext context, ItemKey[] equipment)
	{
		for (int i = 0; i < 17; i++)
		{
			ItemKey oriItemKey = _equipment[i];
			if (oriItemKey.IsValid())
			{
				EquipmentBase oriItem = DomainManager.Item.GetBaseEquipment(oriItemKey);
				oriItem.RemoveOwner(ItemOwnerType.CharacterEquipment, _id);
				oriItem.SetOwner(ItemOwnerType.CharacterInventory, _id);
				oriItem.SetEquippedCharId(-1, context);
				_inventory.OfflineAdd(oriItemKey, 1);
			}
		}
		for (int j = 0; j < 17; j++)
		{
			ItemKey currItemKey = equipment[j];
			if (currItemKey.IsValid())
			{
				EquipmentBase currItem = DomainManager.Item.GetBaseEquipment(currItemKey);
				currItem.RemoveOwner(ItemOwnerType.CharacterInventory, _id);
				currItem.SetOwner(ItemOwnerType.CharacterEquipment, _id);
				currItem.SetEquippedCharId(_id, context);
				_inventory.OfflineRemove(currItemKey, 1);
			}
		}
		for (int k = 0; k < 17; k++)
		{
			_equipment[k] = equipment[k];
		}
		SetEquipment(_equipment, context);
		SetInventory(_inventory, context);
	}

	public int GetEquipmentCombatPowerValue()
	{
		return _equipment.Zip(GlobalConfig.EquipmentSlotCombatPower, (ItemKey key, int value) => ItemTemplateHelper.GetBaseCombatPowerValue(key.ItemType, key.TemplateId) * value / 100).Sum();
	}

	public void ForceReplaceClothing(DataContext context, short newClothingTemplateId)
	{
		ItemKey oldClothingKey = _equipment[4];
		if (oldClothingKey.IsValid())
		{
			DomainManager.Item.RemoveItem(context, oldClothingKey);
		}
		if (newClothingTemplateId >= 0)
		{
			_equipment[4] = DomainManager.Item.CreateClothing(context, newClothingTemplateId, _gender);
			EquipmentBase baseEquipment = DomainManager.Item.GetBaseEquipment(_equipment[4]);
			baseEquipment.SetEquippedCharId(_id, context);
			baseEquipment.SetOwner(ItemOwnerType.CharacterEquipment, _id);
		}
		else
		{
			_equipment[4] = ItemKey.Invalid;
		}
		SetEquipment(_equipment, context);
	}

	public void CreateInventoryItem(DataContext context, sbyte itemType, short templateId, int amount)
	{
		OfflineCreateInventoryItem(context, itemType, templateId, amount);
		SetInventory(_inventory, context);
		if (itemType == 12 && Config.Misc.Instance[templateId].ItemSubType == 1202)
		{
			sbyte bookCombatSkillType = (sbyte)(templateId - 240);
			DomainManager.LegendaryBook.RegisterOwner(context, this, bookCombatSkillType);
			ItemKey itemKey = DomainManager.LegendaryBook.GetLegendaryBookItem(bookCombatSkillType);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddGainQiBook(_id, (ulong)itemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		if (itemType == 3)
		{
			DomainManager.Taiwu.RecordOwnedClothing(context, templateId);
		}
	}

	public bool AddInventoryItem(DataContext context, ItemKey itemKey, int amount, bool offLine = false, EItemAutoOperationSource source = EItemAutoOperationSource.Other)
	{
		bool isTaiwu = _id == DomainManager.Taiwu.GetTaiwuCharId();
		if (isTaiwu && source > EItemAutoOperationSource.Invalid && DomainManager.Taiwu.TryItemAutoOperation(context, itemKey, source))
		{
			return false;
		}
		_inventory.OfflineAdd(itemKey, amount);
		if (!offLine)
		{
			SetInventory(_inventory, context);
		}
		if (itemKey.ItemType == 12 && Config.Misc.Instance[itemKey.TemplateId].ItemSubType == 1202)
		{
			int bookCombatSkillType = itemKey.TemplateId - 240;
			DomainManager.LegendaryBook.RegisterOwner(context, this, (sbyte)bookCombatSkillType);
			ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
			if (item.Owner.OwnerType == ItemOwnerType.System)
			{
				item.RemoveOwner(ItemOwnerType.System, 11);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddGainQiBook(_id, (ulong)itemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (IsTaiwu())
			{
				DomainManager.Taiwu.RecordLifeSummary(context, 83);
			}
		}
		DomainManager.Item.SetOwner(itemKey, ItemOwnerType.CharacterInventory, _id);
		if (isTaiwu)
		{
			Events.RaiseTaiwuItemModified(context, itemKey);
		}
		if (IsTaiwu() && EatingItems.IsWugKing(itemKey))
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 290);
		}
		if (IsTaiwu() && itemKey.ItemType == 10)
		{
			DomainManager.World.ApplyChallengeModeAutoReadBook(context, itemKey);
		}
		return true;
	}

	public bool AddInventoryItem(DataContext context, List<ItemKey> keyList, EItemAutoOperationSource source = EItemAutoOperationSource.Other)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		bool success = false;
		foreach (ItemKey key in keyList)
		{
			if (AddInventoryItem(context, key, 1, offLine: true, source))
			{
				success = true;
			}
		}
		SetInventory(_inventory, context);
		return success;
	}

	public bool AddInventoryItem(DataContext context, Inventory inventory, EItemAutoOperationSource source = EItemAutoOperationSource.Other)
	{
		Tester.Assert(inventory != null);
		bool success = false;
		foreach (var (key, count) in inventory.Items)
		{
			if (AddInventoryItem(context, key, count, offLine: true, source))
			{
				success = true;
			}
		}
		SetInventory(_inventory, context);
		return success;
	}

	public void RemoveMultiInventoryItem(DataContext context, sbyte itemType, short templateId, int count)
	{
		if (count <= 0)
		{
			return;
		}
		List<ItemKey> removedItem = ObjectPool<List<ItemKey>>.Instance.Get();
		while (count > 0)
		{
			ItemKey itemKey = _inventory.GetInventoryItemKey(itemType, templateId);
			int removeCount = Math.Min(count, _inventory.Items[itemKey]);
			count -= removeCount;
			_inventory.OfflineRemove(itemKey, removeCount);
			if (!_inventory.Items.ContainsKey(itemKey))
			{
				removedItem.Add(itemKey);
			}
			Events.RaiseItemRemovedFromInventory(context, this, itemKey, removeCount);
		}
		SetInventory(_inventory, context);
		foreach (ItemKey itemKey2 in removedItem)
		{
			DomainManager.Character.ClearItemUsingState(context, itemKey2, _id);
			DomainManager.Item.RemoveItem(context, itemKey2);
		}
		ObjectPool<List<ItemKey>>.Instance.Return(removedItem);
	}

	public void RemoveInventoryItem(DataContext context, ItemKey itemKey, int amount, bool deleteItem, bool offLine = false)
	{
		if (amount > 0)
		{
			DomainManager.Character.ClearItemUsingState(context, itemKey, _id);
			_inventory.OfflineRemove(itemKey, amount);
			Events.RaiseItemRemovedFromInventory(context, this, itemKey, amount);
			if (!offLine)
			{
				SetInventory(_inventory, context);
			}
			if (deleteItem)
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
		}
	}

	public void RemoveInventoryItem(DataContext context, List<ItemKey> keyList, bool deleteItem)
	{
		Tester.Assert(keyList != null);
		Tester.Assert(keyList.Count > 0);
		foreach (ItemKey key in keyList)
		{
			RemoveInventoryItem(context, key, 1, deleteItem, offLine: true);
		}
		SetInventory(_inventory, context);
	}

	public void RemoveInventoryItem(DataContext context, Inventory inventory, bool deleteItem)
	{
		Tester.Assert(inventory != null);
		foreach (var (key, value) in inventory.Items)
		{
			RemoveInventoryItem(context, key, value, deleteItem, offLine: true);
		}
		SetInventory(_inventory, context);
	}

	public bool TryDetectAttachedPoisons(ItemKey itemKey)
	{
		if (!ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
		{
			return false;
		}
		PoisonsAndLevels attachedPoisons = DomainManager.Item.GetAttachedPoisons(itemKey);
		short toxicologyAttainment = GetLifeSkillAttainment(9);
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			sbyte grade = attachedPoisons.GetGrade(poisonType);
			if (grade >= 0)
			{
				short attainment = GlobalConfig.Instance.PoisonAttainments[grade];
				if (toxicologyAttainment >= attainment)
				{
					return true;
				}
			}
		}
		return false;
	}

	public (ItemKey, bool KeyChanged) AttachPoisonsToInventoryItem(DataContext context, ItemKey targetItemKey, ItemKey[] poisonsToAdd)
	{
		bool keyChanged = false;
		ItemBase targetBaseItem = DomainManager.Item.GetBaseItem(targetItemKey);
		if (poisonsToAdd == null)
		{
			return (targetBaseItem.GetItemKey(), KeyChanged: false);
		}
		for (int i = 0; i < poisonsToAdd.Length; i++)
		{
			ItemKey poisonKey = poisonsToAdd[i];
			if (poisonKey.IsValid() && _inventory.Items.ContainsKey(poisonKey))
			{
				var (item, currKeyChanged) = DomainManager.Item.SetAttachedPoisons(context, targetBaseItem, poisonKey.TemplateId, add: true);
				RemoveInventoryItem(context, poisonKey, 1, deleteItem: true);
				if (currKeyChanged)
				{
					keyChanged = true;
					targetBaseItem = item;
				}
			}
		}
		if (keyChanged)
		{
			ItemKey newKey = targetBaseItem.GetItemKey();
			_inventory.OfflineRemove(targetItemKey, 1);
			_inventory.OfflineAdd(newKey, 1);
			DomainManager.Item.SetOwner(newKey, ItemOwnerType.CharacterInventory, _id);
			SetInventory(_inventory, context);
			if (newKey.Id != targetItemKey.Id)
			{
				DomainManager.Item.RemoveItem(context, targetItemKey);
			}
		}
		return (targetBaseItem.GetItemKey(), KeyChanged: keyChanged);
	}

	private ItemKey SelectInventoryPoisonToAdd(sbyte requiredType)
	{
		short toxicologyAttainment = GetLifeSkillAttainment(9);
		int minDeviation = 16129;
		ItemKey selectedPoison = ItemKey.Invalid;
		foreach (ItemKey itemKey in _inventory.Items.Keys)
		{
			if (itemKey.ItemType != 8)
			{
				continue;
			}
			MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
			if (medicineCfg.EffectType != EMedicineEffectType.ApplyPoison)
			{
				continue;
			}
			sbyte poisonType = medicineCfg.PoisonType;
			short attainmentRequired = GlobalConfig.Instance.PoisonAttainments[medicineCfg.Grade];
			if (poisonType == requiredType && toxicologyAttainment >= attainmentRequired)
			{
				int diff = medicineCfg.Grade - _organizationInfo.Grade;
				int currDeviation = diff * diff;
				if (currDeviation <= minDeviation)
				{
					minDeviation = currDeviation;
					selectedPoison = itemKey;
				}
			}
		}
		return selectedPoison;
	}

	public ItemKey[] SelectInventoryPoisonsToAdd(IRandomSource random, ItemKey itemToAttachPoisonOn)
	{
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			return null;
		}
		Span<ItemKey> span = stackalloc ItemKey[6];
		SpanList<ItemKey> selectedPoisons = span;
		short toxicologyAttainment = GetLifeSkillAttainment(9);
		_inventory.SelectPoisonsToAdd(random, toxicologyAttainment, _organizationInfo.Grade, itemToAttachPoisonOn, ref selectedPoisons);
		return selectedPoisons.ToArray();
	}

	public void FindItems(Predicate<ItemBase> predicate, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		if (searchInventory)
		{
			foreach (KeyValuePair<ItemKey, int> item3 in _inventory.Items)
			{
				item3.Deconstruct(out var key, out var value);
				ItemKey itemKey = key;
				int amount = value;
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
				if (predicate(item))
				{
					items.Add((itemKey, amount));
				}
			}
		}
		if (!searchEquipment)
		{
			return;
		}
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey2 = _equipment[i];
			if (itemKey2.IsValid())
			{
				ItemBase item2 = DomainManager.Item.GetBaseItem(itemKey2);
				if (predicate(item2))
				{
					items.Add((itemKey2, 1));
				}
			}
		}
	}

	public void FindItems(List<Predicate<ItemBase>> predicates, List<(ItemKey itemKey, int amount)> items, bool searchInventory, bool searchEquipment)
	{
		if (searchInventory)
		{
			foreach (KeyValuePair<ItemKey, int> item3 in _inventory.Items)
			{
				item3.Deconstruct(out var key, out var value);
				ItemKey itemKey = key;
				int amount = value;
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
				if (ItemMatchers.MatchAll(item, predicates))
				{
					items.Add((itemKey, amount));
				}
			}
		}
		if (!searchEquipment)
		{
			return;
		}
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey2 = _equipment[i];
			if (itemKey2.IsValid())
			{
				ItemBase item2 = DomainManager.Item.GetBaseItem(itemKey2);
				if (ItemMatchers.MatchAll(item2, predicates))
				{
					items.Add((itemKey2, 1));
				}
			}
		}
	}

	public bool HasReadableBook()
	{
		foreach (var (itemKey2, _) in GetInventory().Items)
		{
			if (itemKey2.ItemType != 10 || !BookIsReadable(itemKey2))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public void GetReadableBookList(List<ItemKey> list)
	{
		list.Clear();
		foreach (var (itemKey2, _) in GetInventory().Items)
		{
			if (itemKey2.ItemType == 10 && BookIsReadable(itemKey2))
			{
				list.Add(itemKey2);
			}
		}
	}

	public bool BookIsReadable(ItemKey itemKey)
	{
		if (!DomainManager.Item.TryGetElement_SkillBooks(itemKey.Id, out var book))
		{
			return false;
		}
		if (TryDetectAttachedPoisons(itemKey))
		{
			return false;
		}
		if (book.IsCombatSkillBook())
		{
			byte readingPage = GetCombatSkillBookCurrReadingInfo(book).readingPage;
			if (readingPage == 6)
			{
				return false;
			}
		}
		else
		{
			byte readingPage = GetLifeSkillBookCurrReadingInfo(book).readingPage;
			if (readingPage == 5)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsBookRead(ItemKey itemKey)
	{
		if (!DomainManager.Item.TryGetElement_SkillBooks(itemKey.Id, out var book))
		{
			return false;
		}
		if (book.IsCombatSkillBook())
		{
			byte readingPage = GetCombatSkillBookCurrReadingInfo(book).readingPage;
			if (readingPage == 6)
			{
				return true;
			}
		}
		else
		{
			byte readingPage = GetLifeSkillBookCurrReadingInfo(book).readingPage;
			if (readingPage == 5)
			{
				return true;
			}
		}
		return false;
	}

	public void VillagerReturnNotReadableBooks(DataContext context)
	{
		short settlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		if (_organizationInfo.SettlementId != settlementId)
		{
			return;
		}
		IReadOnlyDictionary<ItemKey, int> taiwuGiftItems = (DomainManager.Taiwu.IsInGroup(_id) ? DomainManager.Extra.GetTaiwuGiftItems(_id) : Inventory.Empty);
		List<ItemKey> bookList = ObjectPool<List<ItemKey>>.Instance.Get();
		foreach (var (itemKey2, _) in _inventory.Items)
		{
			if (itemKey2.ItemType == 10 && !taiwuGiftItems.ContainsKey(itemKey2) && !BookIsReadable(itemKey2))
			{
				bookList.Add(itemKey2);
			}
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		using (List<ItemKey>.Enumerator enumerator2 = bookList.GetEnumerator())
		{
			if (enumerator2.MoveNext())
			{
				ItemKey itemKey3 = enumerator2.Current;
				RemoveInventoryItem(context, itemKey3, 1, deleteItem: false);
				if (IsBookRead(itemKey3))
				{
					DomainManager.Taiwu.VillagerStoreItemInTreasury(context, this, itemKey3, 1, addLifeSkillRecord: false);
					lifeRecordCollection.AddTaiwuVillagerFinishedReading(_id, currDate, itemKey3.ItemType, itemKey3.TemplateId);
				}
				else
				{
					DomainManager.Taiwu.VillagerStoreItemInTreasury(context, this, itemKey3, 1);
				}
			}
		}
		ObjectPool<List<ItemKey>>.Instance.Return(bookList);
	}

	public void ReturnVillagerRoleClothing(DataContext context, bool forceReturn = true)
	{
		short idealClothingTemplateId = GetIdealClothingTemplateId();
		bool needEquipClothing = false;
		if (forceReturn)
		{
			ItemKey equipment = GetEquipment()[4];
			if (equipment.IsValid())
			{
				bool isRoleClothing = VillagerRole.Instance.Any((VillagerRoleItem r) => r.Clothing == equipment.TemplateId);
				bool isIdeal = idealClothingTemplateId == equipment.TemplateId;
				if (isRoleClothing && !isIdeal)
				{
					ChangeEquipment(context, 4, -1, equipment);
					needEquipClothing = true;
				}
			}
		}
		else
		{
			EventHelper.SelectAndEquipClothing(_id);
		}
		IReadOnlyDictionary<ItemKey, int> taiwuGiftItems = (DomainManager.Taiwu.IsInGroup(_id) ? DomainManager.Extra.GetTaiwuGiftItems(_id) : Inventory.Empty);
		List<ItemKey> clothingList = ObjectPool<List<ItemKey>>.Instance.Get();
		foreach (KeyValuePair<ItemKey, int> item in _inventory.Items)
		{
			var (itemKey2, _) = (KeyValuePair<ItemKey, int>)(ref item);
			if (itemKey2.ItemType == 3 && !taiwuGiftItems.ContainsKey(itemKey2))
			{
				bool isRoleClothing2 = VillagerRole.Instance.Any((VillagerRoleItem r) => r.Clothing == itemKey2.TemplateId);
				bool isIdeal2 = idealClothingTemplateId == itemKey2.TemplateId;
				if (isRoleClothing2 && !isIdeal2)
				{
					clothingList.Add(itemKey2);
				}
			}
		}
		foreach (ItemKey itemKey3 in clothingList)
		{
			RemoveInventoryItem(context, itemKey3, 1, deleteItem: false);
			DomainManager.Taiwu.VillagerStoreItemInTreasury(context, this, itemKey3, 1);
		}
		if (needEquipClothing)
		{
			EventHelper.SelectAndEquipClothing(_id);
		}
		ObjectPool<List<ItemKey>>.Instance.Return(clothingList);
	}

	public void GenerateBequest(DataContext context)
	{
		List<int> list = ObjectPool<List<int>>.Instance.Get();
		Dictionary<ItemKey, int> bequests = new Dictionary<ItemKey, int>();
		GenerateBequestBooks(context, bequests, list);
		DivideBequest(context, bequests, list);
		ObjectPool<List<int>>.Instance.Return(list);
	}

	private void GenerateBequestBooks(DataContext context, Dictionary<ItemKey, int> tempBooks, List<int> canChoosePages)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (GameData.Domains.CombatSkill.CombatSkill combatSkill in combatSkills.Values)
		{
			ushort readingState = combatSkill.GetReadingState();
			if (!CombatSkillStateHelper.HasReadOutlinePages(readingState) || !CombatSkillStateHelper.IsReadNormalPagesMeetConditionOfBreakout(readingState) || !context.Random.CheckPercentProb(GlobalConfig.Instance.BequestGenerateBookPercent))
			{
				continue;
			}
			byte bookPages = 0;
			ushort pageState = SkillBookStateHelper.SetPageIncompleteState(0, 0, 0);
			short attainment = _combatSkillAttainments[combatSkill.Template.Type];
			byte behaviorTypeMask = (byte)(1 << (int)GetBehaviorType());
			if ((readingState & behaviorTypeMask) != 0)
			{
				bookPages |= behaviorTypeMask;
			}
			else
			{
				canChoosePages.Clear();
				for (int i = 0; i < 5; i++)
				{
					if ((readingState & (1 << i)) != 0)
					{
						canChoosePages.Add(i);
					}
				}
				bookPages |= (byte)(1 << canChoosePages.GetRandom(context.Random));
			}
			for (byte page = 1; page < 6; page++)
			{
				byte directIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(0, page);
				byte reverseIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(1, page);
				byte selected = (CombatSkillStateHelper.IsPageRead(readingState, directIndex) ? (CombatSkillStateHelper.IsPageRead(readingState, reverseIndex) ? (context.Random.NextBool() ? directIndex : reverseIndex) : directIndex) : reverseIndex);
				bookPages |= (byte)(1 << (int)selected);
				sbyte state = (sbyte)((!context.Random.CheckPercentProb(attainment / GlobalConfig.Instance.BequestBookPageCompleteFactor)) ? ((!context.Random.CheckPercentProb(GlobalConfig.Instance.BequestBookPageLostFactor)) ? 1 : 2) : 0);
				pageState = SkillBookStateHelper.SetPageIncompleteState(pageState, page, state);
			}
			ItemKey key = DomainManager.Item.CreateSkillBook(context, combatSkill.Template.BookId, bookPages, pageState);
			ItemBase item = DomainManager.Item.GetBaseItem(key);
			item.SetOwner(ItemOwnerType.BequestBook, -1);
			tempBooks.Add(key, 1);
		}
		foreach (LifeSkillItem lifeSkill in _learnedLifeSkills)
		{
			if (lifeSkill.IsAllPagesRead() && context.Random.CheckPercentProb(GlobalConfig.Instance.BequestGenerateBookPercent))
			{
				Config.LifeSkillItem config = LifeSkill.Instance[lifeSkill.SkillTemplateId];
				short attainment2 = _lifeSkillAttainments[config.Type];
				ushort pageState2 = 0;
				for (byte page2 = 0; page2 < 5; page2++)
				{
					sbyte state2 = (sbyte)((!context.Random.CheckPercentProb(attainment2 / GlobalConfig.Instance.BequestBookPageCompleteFactor)) ? ((!context.Random.CheckPercentProb(GlobalConfig.Instance.BequestBookPageLostFactor)) ? 1 : 2) : 0);
					pageState2 = SkillBookStateHelper.SetPageIncompleteState(pageState2, page2, state2);
				}
				ItemKey key2 = DomainManager.Item.CreateSkillBook(context, config.SkillBookId, 0, pageState2);
				ItemBase item2 = DomainManager.Item.GetBaseItem(key2);
				item2.SetOwner(ItemOwnerType.BequestBook, -1);
				tempBooks.Add(key2, 1);
			}
		}
	}

	private void DivideBequest(DataContext context, Dictionary<ItemKey, int> bequests, List<int> candidates)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		sbyte behaviorType = GetBehaviorType();
		int privateCount = GlobalConfig.Instance.BequestPrivatePercent[behaviorType];
		int publicCount = GlobalConfig.Instance.BequestPublicPercent[behaviorType];
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		for (sbyte i = 0; i < _equipment.Length; i++)
		{
			ItemKey itemKey = _equipment[i];
			if (itemKey.IsValid() && i != 4)
			{
				ChangeEquipment(context, i, -1, ItemKey.Invalid);
			}
		}
		ItemKey key;
		int value;
		foreach (KeyValuePair<ItemKey, int> item3 in _inventory.Items)
		{
			item3.Deconstruct(out key, out value);
			ItemKey itemKey2 = key;
			int amount = value;
			if (ItemDomain.CanItemBeLost(itemKey2))
			{
				bequests.Add(itemKey2, amount);
			}
		}
		if (bequests.Count == 0 || (privateCount == 0 && publicCount == 0))
		{
			return;
		}
		int itemCount = 0;
		List<ItemKey> keys = ObjectPool<List<ItemKey>>.Instance.Get();
		keys.Clear();
		foreach (KeyValuePair<ItemKey, int> bequest in bequests)
		{
			bequest.Deconstruct(out key, out value);
			ItemKey key2 = key;
			int amount2 = value;
			itemCount += amount2;
			keys.Add(key2);
		}
		keys.Sort(CompareBequests);
		int maxDonate = itemCount * publicCount / 100;
		if (privateCount > 0)
		{
			candidates.Clear();
			if (_organizationInfo.SettlementId >= 0)
			{
				DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId).GetOrganizationMemberPotentialSuccessorsForDisplay(_id, _organizationInfo, candidates);
				if (candidates.Count > 0)
				{
					int id = candidates[0];
					candidates.Clear();
					candidates.Add(id);
					candidates.Add(id);
				}
			}
			ushort relations = 26623;
			HashSet<int> relatedIds = ObjectPool<HashSet<int>>.Instance.Get();
			relatedIds.Clear();
			DomainManager.Character.GetAllRelatedCharIds(_id, relatedIds, includeGeneral: false);
			foreach (int id2 in relatedIds)
			{
				if (DomainManager.Character.TryGetElement_Objects(id2, out var _) && GetBequestRelationValue(id2) > GlobalConfig.Instance.BequestRelationThreshold)
				{
					ushort relationTypes = DomainManager.Character.GetRelation(_id, id2).RelationType;
					if (relationTypes != ushort.MaxValue && relationTypes != 0 && (relations & relationTypes) != 0)
					{
						candidates.Add(id2);
					}
				}
			}
			ObjectPool<HashSet<int>>.Instance.Return(relatedIds);
		}
		if (candidates.Count > 0)
		{
			int maxCanGet = itemCount * privateCount / 100 / candidates.Count;
			candidates.Sort(CompareBequestCandidates);
			foreach (int id3 in candidates)
			{
				if (!DomainManager.Character.TryGetElement_Objects(id3, out var character))
				{
					continue;
				}
				int count = 0;
				sbyte grade = character.GetOrganizationInfo().Grade;
				Location location = character.GetLocation();
				for (int i2 = keys.Count - 1; i2 >= 0; i2--)
				{
					ItemKey key3 = keys[i2];
					int amount3 = bequests[key3];
					ItemBase item = DomainManager.Item.GetBaseItem(key3);
					ItemOwnerKey owner = item.Owner;
					bool isTempBook = owner.OwnerType == ItemOwnerType.BequestBook && owner.OwnerId < 0;
					sbyte itemGrade = ItemTemplateHelper.GetGrade(key3.ItemType, key3.TemplateId);
					int prob = (GlobalConfig.Instance.BequestProbabilityFactor1 + grade - itemGrade) * GlobalConfig.Instance.BequestProbabilityFactor2;
					for (int j = 0; j < amount3; j++)
					{
						if (context.Random.CheckPercentProb(prob))
						{
							if (!isTempBook)
							{
								RemoveInventoryItem(context, key3, 1, deleteItem: false);
							}
							else
							{
								item.RemoveOwner(ItemOwnerType.BequestBook, -1);
							}
							if (id3 == taiwuId)
							{
								DomainManager.Taiwu.AddBequest(_id, key3);
							}
							else
							{
								item.SetOwner(ItemOwnerType.CharacterInventory, id3);
								character.AddInventoryItem(context, key3, 1);
								lifeRecordCollection.AddInheritLegacy(id3, currDate, _id, location, key3.ItemType, key3.TemplateId);
							}
							key = key3;
							value = --bequests[key];
							if (value == 0)
							{
								keys.RemoveAt(i2);
							}
							if (++count == maxCanGet)
							{
								break;
							}
						}
					}
					if (count >= maxCanGet)
					{
						break;
					}
				}
			}
		}
		for (int index = keys.Count - 1; index >= 0; index--)
		{
			ItemKey key4 = keys[index];
			ItemBase item2 = DomainManager.Item.GetBaseItem(key4);
			ItemOwnerKey owner = item2.Owner;
			if (owner.OwnerType == ItemOwnerType.BequestBook && owner.OwnerId < 0)
			{
				DomainManager.Item.RemoveItem(context, key4);
				keys.RemoveAt(index);
			}
		}
		itemCount = 0;
		foreach (KeyValuePair<ItemKey, int> bequest2 in bequests)
		{
			bequest2.Deconstruct(out key, out value);
			ItemKey key5 = key;
			int amount4 = value;
			itemCount += amount4;
		}
		if (maxDonate > 0 && keys.Count > 0 && _organizationInfo.SettlementId >= 0)
		{
			for (int index2 = keys.Count - 1; index2 >= 0; index2--)
			{
				ItemKey key6 = keys[index2];
				int amount5 = bequests[key6];
				int actualAmount = ((amount5 > maxDonate) ? maxDonate : amount5);
				RemoveInventoryItem(context, key6, 1, deleteItem: false);
				DomainManager.Organization.StoreItemInTreasury(context, _organizationInfo.SettlementId, this, key6, actualAmount, -1, isBequest: true);
				maxDonate -= actualAmount;
				if (maxDonate <= 0)
				{
					break;
				}
			}
		}
		ObjectPool<List<ItemKey>>.Instance.Return(keys);
	}

	private int GetBequestRelationIndex(int id)
	{
		ushort relationType = DomainManager.Character.GetRelation(_id, id).RelationType;
		if (RelationType.HasRelation(relationType, 73))
		{
			return 0;
		}
		if (RelationType.HasRelation(relationType, 292))
		{
			return 1;
		}
		if (RelationType.HasRelation(relationType, 512))
		{
			return 2;
		}
		if (RelationType.HasRelation(relationType, 6144))
		{
			return 3;
		}
		if (RelationType.HasRelation(relationType, 1024))
		{
			return 4;
		}
		if (RelationType.HasRelation(relationType, 146))
		{
			return 5;
		}
		if (RelationType.HasRelation(relationType, 16384))
		{
			return 7;
		}
		return 6;
	}

	private int GetBequestRelationValue(int id)
	{
		sbyte favorType = DomainManager.Character.GetFavorabilityType(_id, id);
		int value = GlobalConfig.Instance.BequestBehaviorRelationFactor[GetBehaviorType()][GetBequestRelationIndex(id)];
		return (favorType > 0) ? (favorType * value * GlobalConfig.Instance.BequestRelationPositiveFinalFactor) : (favorType * value + GlobalConfig.Instance.BequestRelationNegativeFinalFactor);
	}

	private int CompareBequestCandidates(int a, int b)
	{
		return -GetBequestRelationValue(a).CompareTo(GetBequestRelationValue(b));
	}

	private int CompareBequests(ItemKey a, ItemKey b)
	{
		sbyte gradeA = ItemTemplateHelper.GetGrade(a.ItemType, a.TemplateId);
		sbyte gradeB = ItemTemplateHelper.GetGrade(b.ItemType, b.TemplateId);
		if (gradeA != gradeB)
		{
			return gradeA.CompareTo(gradeB);
		}
		int valueA = DomainManager.Item.GetValue(a);
		int valueB = DomainManager.Item.GetValue(b);
		if (valueA != valueB)
		{
			return valueA.CompareTo(valueB);
		}
		return a.TemplateId.CompareTo(b.TemplateId);
	}

	public unsafe ResourceInts GetResourcesAboveSatisfyingThreshold()
	{
		OrganizationMemberItem memberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		ResourceInts resources = default(ResourceInts);
		for (sbyte type = 0; type < 8; type++)
		{
			int threshold = memberCfg.GetAdjustedResourceSatisfyingAmount(type);
			resources.Items[type] = Math.Max(_resources.Items[type] - threshold, 0);
		}
		return resources;
	}

	public ItemKey GetMaxGradeItemToLose(IRandomSource random)
	{
		List<ItemKey> itemRandomPool = ObjectPool<List<ItemKey>>.Instance.Get();
		itemRandomPool.Clear();
		sbyte maxGrade = -1;
		bool isAdult = GetAgeGroup() != 2;
		for (int i = 0; i < _equipment.Length; i++)
		{
			ItemKey itemKey = _equipment[i];
			if (itemKey.IsValid() && (isAdult || i != 4))
			{
				maxGrade = AddItemToLose(itemKey, maxGrade, itemRandomPool);
			}
		}
		foreach (ItemKey itemKey2 in _inventory.Items.Keys)
		{
			if (ItemDomain.CanItemBeLost(itemKey2))
			{
				maxGrade = AddItemToLose(itemKey2, maxGrade, itemRandomPool);
			}
		}
		ItemKey itemToLose = ((itemRandomPool.Count > 0) ? itemRandomPool.GetRandom(random) : ItemKey.Invalid);
		ObjectPool<List<ItemKey>>.Instance.Return(itemRandomPool);
		return itemToLose;
		static sbyte AddItemToLose(ItemKey item, sbyte currMaxGrade, List<ItemKey> itemsToLose)
		{
			sbyte grade = ItemTemplateHelper.GetGrade(item.ItemType, item.TemplateId);
			if (grade < currMaxGrade)
			{
				return currMaxGrade;
			}
			if (grade > currMaxGrade)
			{
				currMaxGrade = grade;
				itemsToLose.Clear();
			}
			itemsToLose.Add(item);
			return currMaxGrade;
		}
	}

	public void GetItemsToLose(List<ItemKey> result, sbyte minGrade = 0, sbyte maxGrade = 8)
	{
		result.Clear();
		bool isAdult = GetAgeGroup() == 2;
		for (int i = 0; i < _equipment.Length; i++)
		{
			ItemKey itemKey = _equipment[i];
			if (itemKey.IsValid() && (isAdult || i != 4))
			{
				sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
				if (grade >= minGrade && grade <= maxGrade)
				{
					result.Add(itemKey);
				}
			}
		}
		foreach (ItemKey itemKey2 in _inventory.Items.Keys)
		{
			if (ItemDomain.CanItemBeLost(itemKey2))
			{
				sbyte grade2 = ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId);
				if (grade2 >= minGrade && grade2 <= maxGrade)
				{
					result.Add(itemKey2);
				}
			}
		}
	}

	private void OfflineCreateInventoryOnCharacterCreation(DataContext context, sbyte itemType, short templateId, int amount)
	{
		if (amount <= 1 || ItemTemplateHelper.IsStackable(itemType, templateId))
		{
			ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, templateId);
			_inventory.OfflineAdd(itemKey, amount);
			return;
		}
		for (int i = 0; i < amount; i++)
		{
			ItemKey itemKey2 = DomainManager.Item.CreateItem(context, itemType, templateId);
			_inventory.Items.Add(itemKey2, 1);
		}
	}

	private void OfflineCreateInventoryItem(DataContext context, sbyte itemType, short templateId, int amount)
	{
		if (amount <= 1 || ItemTemplateHelper.IsStackable(itemType, templateId))
		{
			ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, templateId);
			DomainManager.Item.SetOwner(itemKey, ItemOwnerType.CharacterInventory, _id);
			_inventory.OfflineAdd(itemKey, amount);
			return;
		}
		for (int i = 0; i < amount; i++)
		{
			ItemKey itemKey2 = DomainManager.Item.CreateItem(context, itemType, templateId);
			DomainManager.Item.SetOwner(itemKey2, ItemOwnerType.CharacterInventory, _id);
			_inventory.Items.Add(itemKey2, 1);
		}
	}

	public ItemKey GetInventoryRope(DataContext context, sbyte grade)
	{
		if (context.Random.CheckPercentProb(50))
		{
			foreach (var (itemKey2, _) in _inventory.Items)
			{
				if (itemKey2.ItemType == 12 && ItemTemplateHelper.GetItemSubType(itemKey2.ItemType, itemKey2.TemplateId) == 1206 && ItemTemplateHelper.GetGrade(itemKey2.ItemType, itemKey2.TemplateId) >= grade)
				{
					return itemKey2;
				}
			}
		}
		sbyte actualGrade = ItemDomain.GenerateRandomItemGrade(context.Random, grade);
		ItemKey rope = DomainManager.Item.CreateMisc(context, (short)(82 + actualGrade));
		AddInventoryItem(context, rope, 1);
		return rope;
	}

	public int GetKidnapMaxSlotCount()
	{
		return GlobalConfig.Instance.KidnapSlotBaseMaxCount + WorkingCarrierKidnapMaxSlotCount;
	}

	public LifeSkillItem LearnNewLifeSkill(DataContext context, short lifeSkillTemplateId, byte readingState)
	{
		int prevIndex = FindLearnedLifeSkillIndex(lifeSkillTemplateId);
		if (prevIndex >= 0)
		{
			return _learnedLifeSkills[prevIndex];
		}
		LifeSkillItem skill = new LifeSkillItem(lifeSkillTemplateId);
		skill.ReadingState = readingState;
		_learnedLifeSkills.Add(skill);
		SetLearnedLifeSkills(_learnedLifeSkills, context);
		if (skill.IsAllPagesRead())
		{
			DomainManager.Information.GainLifeSkillInformationToCharacter(context, _id, LifeSkill.Instance[lifeSkillTemplateId].Type);
		}
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Taiwu.RegisterLifeSkill(context, skill);
			DomainManager.Taiwu.AddLegacyPoint(context, 14);
		}
		return skill;
	}

	public void UpdateLifeSkillReadingState(DataContext context, int learnedSkillIndex, byte readingState)
	{
		LifeSkillItem skill = _learnedLifeSkills[learnedSkillIndex];
		bool isAllReadBefore = skill.IsAllPagesRead();
		skill.ReadingState = readingState;
		_learnedLifeSkills[learnedSkillIndex] = skill;
		SetLearnedLifeSkills(_learnedLifeSkills, context);
		sbyte lifeSkillType = LifeSkill.Instance[skill.SkillTemplateId].Type;
		if (!isAllReadBefore && skill.IsAllPagesRead())
		{
			DomainManager.Information.GainLifeSkillInformationToCharacter(context, _id, lifeSkillType);
		}
	}

	public void ReadLifeSkillPage(DataContext context, int learnedSkillIndex, byte pageId)
	{
		LifeSkillItem skill = _learnedLifeSkills[learnedSkillIndex];
		bool isAllReadBefore = skill.IsAllPagesRead();
		skill.SetPageRead(pageId);
		_learnedLifeSkills[learnedSkillIndex] = skill;
		SetLearnedLifeSkills(_learnedLifeSkills, context);
		sbyte lifeSkillType = LifeSkill.Instance[skill.SkillTemplateId].Type;
		if (!isAllReadBefore && skill.IsAllPagesRead())
		{
			DomainManager.Information.GainLifeSkillInformationToCharacter(context, _id, lifeSkillType);
		}
	}

	public unsafe short GetLifeSkillAttainment(sbyte lifeSkillType)
	{
		return GetLifeSkillAttainments().Items[lifeSkillType];
	}

	public unsafe short GetLifeSkillQualification(sbyte lifeSkillType)
	{
		return GetLifeSkillQualifications().Items[lifeSkillType];
	}

	public unsafe short GetMaxLifeSkillAttainment()
	{
		ref LifeSkillShorts attainments = ref GetLifeSkillAttainments();
		short max = 0;
		for (int i = 0; i < 16; i++)
		{
			if (attainments.Items[i] > max)
			{
				max = attainments.Items[i];
			}
		}
		return max;
	}

	public short GetMaxCombatSkillAttainment()
	{
		return GetCombatSkillAttainments().GetMaxCombatSkillValue();
	}

	public unsafe (sbyte, short) GetMaxCombatSkillAttainmentType()
	{
		ref CombatSkillShorts attainments = ref GetCombatSkillAttainments();
		sbyte combatType = attainments.GetMaxCombatSkillType();
		return (combatType, attainments.Items[combatType]);
	}

	public bool TryGetLearnedLifeSkill(short templateId, out LifeSkillItem lifeSkill)
	{
		int index = FindLearnedLifeSkillIndex(templateId);
		if (index < 0)
		{
			lifeSkill = default(LifeSkillItem);
			return false;
		}
		lifeSkill = _learnedLifeSkills[index];
		return true;
	}

	public int FindLearnedLifeSkillIndex(short skillTemplateId)
	{
		for (int i = 0; i < _learnedLifeSkills.Count; i++)
		{
			if (_learnedLifeSkills[i].SkillTemplateId == skillTemplateId)
			{
				return i;
			}
		}
		return -1;
	}

	public sbyte GetMaxLifeSkillAttainmentType(DataContext context)
	{
		return GetLifeSkillAttainments().GetMaxLifeSkillType(context.Random);
	}

	private unsafe LifeSkillShorts GetPredictLifeSkillAttainments(short skillTemplateId, int count)
	{
		LifeSkillShorts value = default(LifeSkillShorts);
		value.Initialize();
		GetLifeSkillBaseAttainment(ref value);
		Config.LifeSkillItem skillConfig = LifeSkill.Instance[skillTemplateId];
		int bonus = GlobalConfig.Instance.AddAttainmentPerGrade[skillConfig.Grade] / 5 * count;
		ref short reference = ref value.Items[skillConfig.Type];
		reference += (short)bonus;
		GetLifeSkillAttainmentAddOns(ref value);
		return value;
	}

	public unsafe short GetPredictLifeSkillAttainment(short type, short skillTemplateId, int count)
	{
		LifeSkillShorts value = GetPredictLifeSkillAttainments(skillTemplateId, count);
		return value.Items[type];
	}

	public unsafe void GetLifeSkillBaseAttainment(ref LifeSkillShorts value)
	{
		int i = 0;
		for (int count = _learnedLifeSkills.Count; i < count; i++)
		{
			LifeSkillItem item = _learnedLifeSkills[i];
			Config.LifeSkillItem skillConfig = LifeSkill.Instance[item.SkillTemplateId];
			int readPageCount = item.GetReadPagesCount();
			int bonus = GlobalConfig.Instance.AddAttainmentPerGrade[skillConfig.Grade] / 5 * readPageCount;
			ref short reference = ref value.Items[skillConfig.Type];
			reference += (short)bonus;
		}
	}

	public sbyte GetLearnedLifeSkillMaxGradeByType(sbyte lifeSkillType)
	{
		sbyte grade = 0;
		int i = 0;
		for (int count = _learnedLifeSkills.Count; i < count; i++)
		{
			LifeSkillItem item = _learnedLifeSkills[i];
			Config.LifeSkillItem skillItem = LifeSkill.Instance[item.SkillTemplateId];
			if (skillItem.Type == lifeSkillType && skillItem.Grade > grade)
			{
				grade = skillItem.Grade;
			}
		}
		return grade;
	}

	public int GetLearnedLifeSkillTotalValue(sbyte lifeSkillType)
	{
		int totalValue = 0;
		int i = 0;
		for (int count = _learnedLifeSkills.Count; i < count; i++)
		{
			LifeSkillItem item = _learnedLifeSkills[i];
			Config.LifeSkillItem skillItem = LifeSkill.Instance[item.SkillTemplateId];
			if (skillItem.Type == lifeSkillType)
			{
				int baseValue = ItemTemplateHelper.GetBaseValue(10, skillItem.SkillBookId);
				int value = baseValue * item.GetReadPagesCount() / 5;
				totalValue += value;
			}
		}
		return totalValue;
	}

	public unsafe void GetLifeSkillAttainmentAddOns(ref LifeSkillShorts value)
	{
		ref LifeSkillShorts qualifications = ref GetLifeSkillQualifications();
		for (int i = 0; i < 16; i++)
		{
			int bonus = value.Items[i];
			int qualification = DomainManager.World.ApplyChallengeModeAttainment(qualifications.Items[i]);
			value.Items[i] = (short)(qualification * (100 + bonus) / 100 + bonus);
		}
		IBuildingEffectValue buildingEffect = DomainManager.Building.GetBuildingBlockEffectObject(_location, EBuildingScaleEffect.LifeSkillAttainment);
		if (buildingEffect != null)
		{
			for (int lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
			{
				value[lifeSkillType] += (short)buildingEffect.Get(lifeSkillType);
			}
		}
		for (int j = 0; j < 16; j++)
		{
			if (value.Items[j] < 0)
			{
				value.Items[j] = 0;
			}
		}
	}

	public List<short> GetUnlockedDebateStrategyList()
	{
		List<short> strategyTemplateIdList = new List<short>();
		List<LifeSkillItem> learnedLifeSkills = GetLearnedLifeSkills();
		foreach (LifeSkillItem learnedLifeSkill in learnedLifeSkills)
		{
			if (CheckLearnedBookHasUnlockedDebateStrategy(learnedLifeSkill, out var strategyTemplateId, out var _) && !strategyTemplateIdList.Contains(strategyTemplateId))
			{
				strategyTemplateIdList.Add(strategyTemplateId);
			}
		}
		strategyTemplateIdList.Sort();
		return strategyTemplateIdList;
	}

	public Dictionary<sbyte, int> GetHasUnlockedDebateStrategyLearnedBookCountDict(int strategyLevel)
	{
		Dictionary<sbyte, int> dict = new Dictionary<sbyte, int>();
		List<LifeSkillItem> learnedLifeSkills = GetLearnedLifeSkills();
		foreach (LifeSkillItem learnedLifeSkill in learnedLifeSkills)
		{
			if (CheckLearnedBookHasUnlockedDebateStrategy(learnedLifeSkill, out var strategyTemplateId, out var bookLifeSkillType) && DebateStrategy.Instance[strategyTemplateId].Level == strategyLevel)
			{
				dict.TryGetValue(bookLifeSkillType, out var count);
				count = (dict[bookLifeSkillType] = count + 1);
			}
		}
		return dict;
	}

	public short GetUnlockedDebateStrategy(LifeSkillItem learnedLifeSkill, Dictionary<sbyte, int> oldUnlockCountDict)
	{
		if (!CheckLearnedBookHasUnlockedDebateStrategy(learnedLifeSkill, out var strategyTemplateId, out var lifeSkillType))
		{
			return -1;
		}
		DebateStrategyItem strategyConfig = DebateStrategy.Instance[strategyTemplateId];
		Dictionary<sbyte, int> newUnlockCountDict = GetHasUnlockedDebateStrategyLearnedBookCountDict(strategyConfig.Level);
		oldUnlockCountDict.TryGetValue(lifeSkillType, out var oldCount);
		newUnlockCountDict.TryGetValue(lifeSkillType, out var newCount);
		if (oldCount == 0 && newCount == 1)
		{
			return strategyTemplateId;
		}
		return -1;
	}

	public bool CheckLearnedBookHasUnlockedDebateStrategy(LifeSkillItem learnedLifeSkill, out short strategyTemplateId, out sbyte lifeSkillType)
	{
		lifeSkillType = -1;
		strategyTemplateId = -1;
		Config.LifeSkillItem skillConfig = LifeSkill.Instance[learnedLifeSkill.SkillTemplateId];
		SkillBookItem bookConfig = Config.SkillBook.Instance[skillConfig.SkillBookId];
		sbyte grade = bookConfig.Grade;
		if (1 == 0)
		{
		}
		int num;
		switch (grade)
		{
		case 0:
		case 1:
		case 2:
			num = 1;
			break;
		case 3:
		case 4:
		case 5:
			num = 2;
			break;
		case 6:
		case 7:
		case 8:
			num = 3;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		if (1 == 0)
		{
		}
		int strategyLevel = num;
		strategyTemplateId = DebateStrategy.Instance.FirstOrDefault((DebateStrategyItem s) => s.LifeSkillType == bookConfig.LifeSkillType && s.Level == strategyLevel)?.TemplateId ?? (-1);
		lifeSkillType = bookConfig.LifeSkillType;
		if (!learnedLifeSkill.IsAllPagesRead())
		{
			return false;
		}
		return strategyTemplateId >= 0;
	}

	public int GetAllPagesReadCookingSkillBookCount()
	{
		return GetFinishedLifeSkillBookCountByType(14);
	}

	public int GetFinishedLifeSkillBookCountByType(sbyte lifeSkillType)
	{
		List<LifeSkillItem> learnedLifeSkills = GetLearnedLifeSkills();
		int allPagesReadCookingSkillBookCount = 0;
		foreach (LifeSkillItem item in learnedLifeSkills)
		{
			if (item.IsAllPagesRead())
			{
				Config.LifeSkillItem skillConfig = LifeSkill.Instance[item.SkillTemplateId];
				if (skillConfig.Type == lifeSkillType)
				{
					allPagesReadCookingSkillBookCount++;
				}
			}
		}
		return allPagesReadCookingSkillBookCount;
	}

	public void GetCanImproveLifeSkillTypes(ref SpanList<sbyte> canImproveLifeSkillTypes)
	{
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (GetBaseLifeSkillQualifications()[lifeSkillType] < 90)
			{
				canImproveLifeSkillTypes.Add(lifeSkillType);
			}
		}
	}

	internal void AddNoMindGuyFeature(DataContext context, bool resetAge)
	{
		OfflineSetTemplateId(1114);
		_organizationInfo.Grade = 0;
		_organizationInfo.Principal = true;
		_organizationInfo.OrgTemplateId = 16;
		_organizationInfo.SettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		DomainManager.Organization.JoinOrganization(context, this, _organizationInfo, charIsCreating: false);
		if (resetAge)
		{
			SetCurrAge(16, context);
		}
		AddFeature(context, 860, removeMutexFeature: true);
		ItemKey item = GetEquipment()[4];
		if (item.IsValid())
		{
			ChangeEquipment(context, 4, -1, ItemKey.Invalid);
			RemoveInventoryItem(context, item, 1, deleteItem: true, offLine: true);
		}
		item = DomainManager.Item.CreateClothing(context, 101, GetGender());
		AddInventoryItem(context, item, 1, offLine: true);
		ChangeEquipment(context, -1, 4, item);
	}

	public int CalcMoveTimePercent()
	{
		return (IsOverweight ? CalcOverweightSanctionPercent() : 100) * CalcCarrierTimeBonus();
	}

	public int CalcOverweightSanctionPercent()
	{
		int currLoad = GetCurrInventoryLoad();
		int maxLoad = GetMaxInventoryLoad();
		return 300 + CValuePercent.ParseInt(currLoad - maxLoad, maxLoad);
	}

	public CValuePercentBonus CalcCarrierTimeBonus()
	{
		return -WorkingCarrierTimeBonus;
	}

	public sbyte GetValidOrganizationStateId()
	{
		if (_organizationInfo.SettlementId < 0)
		{
			return 0;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
		Location location = settlement.GetLocation();
		return DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
	}

	public Location CalcFurthestEscapeDestination(IRandomSource random)
	{
		short srcAreaId = GetValidLocation().AreaId;
		int maxTimeCost = -1;
		short maxDistanceAreaId = -1;
		for (short areaId = 0; areaId < 135; areaId++)
		{
			if (areaId != srcAreaId)
			{
				int totalTimeCost = DomainManager.Map.GetTotalTimeCost(this, srcAreaId, areaId);
				if (totalTimeCost > maxTimeCost)
				{
					maxTimeCost = totalTimeCost;
					maxDistanceAreaId = areaId;
				}
			}
		}
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(maxDistanceAreaId);
		short dstBlockId = areaData.StationBlockId;
		if (maxDistanceAreaId < 45)
		{
			Span<short> span = stackalloc short[areaData.SettlementInfos.Length];
			SpanList<short> blockIds = span;
			SettlementInfo[] settlementInfos = areaData.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				if (settlementInfo.SettlementId >= 0)
				{
					blockIds.Add(settlementInfo.BlockId);
				}
			}
			dstBlockId = blockIds.GetRandom(random);
		}
		return new Location(maxDistanceAreaId, dstBlockId);
	}

	public CharacterMissionData GetMission(ECharacterMissionGroup missionGroup)
	{
		ActionPlanningData actionPlanningData = ActionPlanningData;
		return actionPlanningData.Missions.CheckIndex((int)missionGroup) ? actionPlanningData.Missions[(int)missionGroup] : null;
	}

	public void PostAdvanceMonth_UpdateMissions(DataContext context)
	{
		bool isModified = false;
		int currDate = DomainManager.World.GetCurrDate();
		CharacterMissionData[] missions = ActionPlanningData.Missions;
		int expectedCount = 4;
		if (missions.Length < expectedCount)
		{
			CharacterMissionData[] newMissions = new CharacterMissionData[expectedCount];
			Array.Copy(missions, newMissions, missions.Length);
			missions = newMissions;
			ActionPlanningData.Missions = missions;
		}
		for (int i = 0; i < missions.Length; i++)
		{
			CharacterMissionData mission = missions[i];
			if (mission != null)
			{
				if (mission.InKeepDuration)
				{
					if (mission.CanRemove)
					{
						missions[i] = null;
						isModified = true;
					}
					continue;
				}
				if (!mission.IsComplete && !mission.IsTimeout)
				{
					continue;
				}
				mission.EndDate = currDate;
				isModified = true;
			}
			if (missions[i] == null)
			{
				isModified = OfflineCreateMission(context, (ECharacterMissionGroup)i) || isModified;
			}
		}
		if (isModified)
		{
			context.ParallelModificationsRecorder.RecordType(ParallelModificationType.PostAdvanceMonthUpdateMissions);
			context.ParallelModificationsRecorder.RecordParameterClass(this);
		}
	}

	public static void ComplementPostAdvanceMonth_UpdateMissions(DataContext context, Character character)
	{
		character.SetActionPlanningModified(context);
	}

	private bool OfflineCreateMission(DataContext context, ECharacterMissionGroup group)
	{
		if (!IsInteractableAsIntelligentCharacter())
		{
			return false;
		}
		IReadOnlyList<ECharacterMissionType> missionTypes = DomainManager.Character.GetMissionTypesInGroup(group);
		CharacterMissionItem nextMissionTemplate = null;
		foreach (ECharacterMissionType missionType in missionTypes)
		{
			ICharacterMissionCollection collection = DomainManager.Character.GetMissionCollection(missionType);
			CharacterMissionItem newMissionTemplate = collection.GetMission(context.Random, this);
			if (newMissionTemplate != null && (nextMissionTemplate == null || CompareMissionPriority(nextMissionTemplate, newMissionTemplate) < 0))
			{
				nextMissionTemplate = newMissionTemplate;
			}
		}
		if (nextMissionTemplate == null)
		{
			return false;
		}
		int currDate = DomainManager.World.GetCurrDate();
		CharacterMissionData[] missions = ActionPlanningData.Missions;
		if (missions[(int)group] == null)
		{
			missions[(int)group] = new CharacterMissionData();
		}
		CharacterMissionData mission = ActionPlanningData.Missions[(int)group];
		mission.Initialize(nextMissionTemplate.TemplateId, currDate);
		for (int index = mission.Goals.Count - 1; index >= 0; index--)
		{
			CharacterGoalData goal = mission.Goals[index];
			if (!goal.TemplateNode.CheckCanBeAdded(context, this))
			{
				mission.Goals.RemoveAt(index);
			}
			if (IsTemplateGoalComplete(context, goal.Template))
			{
				goal.SetAchieved(currDate - 1);
			}
		}
		return true;
	}

	private int CompareMissionPriority(CharacterMissionItem missionA, CharacterMissionItem missionB)
	{
		int missionAPersonality = GetMaxPersonalityInTypes(missionA.PersonalityTypes);
		int missionBPersonality = GetMaxPersonalityInTypes(missionB.PersonalityTypes);
		return (missionAPersonality != missionBPersonality) ? missionAPersonality.CompareTo(missionBPersonality) : missionA.Priority.CompareTo(missionB.Priority);
	}

	private int GetMaxPersonalityInTypes(IReadOnlyList<sbyte> personalityTypes)
	{
		Personalities personalities = GetPersonalities();
		int maxValue = -1;
		foreach (sbyte type in personalityTypes)
		{
			maxValue = Math.Max(maxValue, personalities[type]);
		}
		return maxValue;
	}

	private bool IsMissionComplete(DataContext context, CharacterMissionItem mission)
	{
		int[] goals = mission.Goals;
		if (goals == null || goals.Length <= 0)
		{
			return true;
		}
		int[] goals2 = mission.Goals;
		foreach (int goalTemplateId in goals2)
		{
			if (!IsTemplateGoalComplete(context, PlanningGoal.Instance[goalTemplateId]))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsTemplateGoalComplete(DataContext context, PlanningGoalItem goal)
	{
		CharacterPlanningAgent agent = context.PlanningAgent;
		agent.Initialize(context, this, null);
		StateConditionAndValue<StateKey>[] preconditions = goal.Preconditions;
		foreach (StateConditionAndValue<StateKey> condition in preconditions)
		{
			if (!agent.Memory.CheckCondition(agent, condition))
			{
				return false;
			}
		}
		return true;
	}

	public CValueModify CalcMysteryBonus(ECharacterPropertyReferencedType propertyType)
	{
		CValueModify result = CValueModify.Zero;
		ItemKey[] equipment = GetEquipment();
		foreach (ItemKey itemKey in equipment)
		{
			result += DomainManager.Item.CalcMysteryBonus(itemKey, propertyType);
		}
		return result;
	}

	public CValueModify CalcMysteryBonusCombatSkillPower(sbyte equipType)
	{
		if (1 == 0)
		{
		}
		CValueModify result = equipType switch
		{
			0 => CalcMysteryBonus(ECharacterPropertyReferencedType.SkillPowerNeigong), 
			1 => CalcMysteryBonus(ECharacterPropertyReferencedType.SkillPowerAttack), 
			2 => CalcMysteryBonus(ECharacterPropertyReferencedType.SkillPowerAgile), 
			3 => CalcMysteryBonus(ECharacterPropertyReferencedType.SkillPowerDefense), 
			4 => CalcMysteryBonus(ECharacterPropertyReferencedType.SkillPowerAssist), 
			_ => CValueModify.Zero, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public CValueModify CalcMysteryBonusBaseDamageStepOuter(sbyte bodyPart)
	{
		if (1 == 0)
		{
		}
		CValueModify result;
		switch (bodyPart)
		{
		case 2:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepOuterHead);
			break;
		case 0:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepOuterChest);
			break;
		case 3:
		case 4:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepOuterHand);
			break;
		case 1:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepOuterBelly);
			break;
		case 5:
		case 6:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepOuterLeg);
			break;
		default:
			result = CValueModify.Zero;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public CValueModify CalcMysteryBonusBaseDamageStepInner(sbyte bodyPart)
	{
		if (1 == 0)
		{
		}
		CValueModify result;
		switch (bodyPart)
		{
		case 2:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepInnerHead);
			break;
		case 0:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepInnerChest);
			break;
		case 3:
		case 4:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepInnerHand);
			break;
		case 1:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepInnerBelly);
			break;
		case 5:
		case 6:
			result = CalcMysteryBonus(ECharacterPropertyReferencedType.BaseDamageStepInnerLeg);
			break;
		default:
			result = CValueModify.Zero;
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public void AddMysteryCompatibility(DataContext context)
	{
		int min = GlobalConfig.Instance.MysteryMinCompatibilityPerCombat;
		int max = GlobalConfig.Instance.MysteryMaxCompatibilityPerCombat;
		ItemKey[] equipment = GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && itemKey.GetConfig().MysteryEffect != null)
			{
				DomainManager.Item.ChangeMysteryCompatibility(context, itemKey, _id, context.Random.Next(min, max + 1));
			}
		}
	}

	public void OfflinePossession(DataContext context, DeadCharacter deadCharacter, List<short> featureIds)
	{
		context.SwitchRandomSource((ulong)(((long)(_id ^ deadCharacter.BirthDate) << 32) ^ deadCharacter.DeathDate));
		_happiness = deadCharacter.Happiness;
		_baseMorality = deadCharacter.Morality;
		_preexistenceCharIds = deadCharacter.PreexistenceCharIds;
		_baseLifeSkillQualifications = deadCharacter.BaseLifeSkillQualifications;
		_baseCombatSkillQualifications = deadCharacter.BaseCombatSkillQualifications;
		_baseMainAttributes = deadCharacter.BaseMainAttributes;
		_featureIds.RemoveAll((short index) => !CharacterFeature.Instance[index].BodyTransform);
		if (GetFameType() >= 4)
		{
			_featureIds.Add(740);
		}
		else
		{
			sbyte fameType = GetFameType();
			if (fameType >= 0 && fameType < 3)
			{
				_featureIds.Add(741);
			}
		}
		if (featureIds != null && featureIds.Count != 0)
		{
			foreach (short id in featureIds)
			{
				OfflineAddFeature(id, removeMutexFeature: true);
			}
		}
		else
		{
			foreach (short id2 in deadCharacter.FeatureIds)
			{
				if (CharacterFeature.Instance[id2].MutexGroupId != 590 && CharacterFeature.Instance[id2].SoulTransform)
				{
					OfflineAddFeature(id2, removeMutexFeature: true, removeLowerOnly: true);
				}
			}
		}
		_featureIds.Sort(CharacterFeatureHelper.CompareFeature);
		context.RestoreRandomSource();
	}

	public static RecruitCharacterData GenerateRecruitCharacterData(IRandomSource random, sbyte peopleLevel, BuildingBlockKey blockKey, BuildingBlockData blockData)
	{
		Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockItem blockConfig = blockData.ConfigData;
		sbyte gender = Gender.GetRandom(random);
		bool transgender = false;
		short age = (short)random.Next(18, 25);
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
		sbyte orgTemplateId = MapState.Instance[stateTemplateId].SectID;
		short charTemplateId = OrganizationDomain.GetCharacterTemplateId(orgTemplateId, stateTemplateId, gender);
		short orgMemberId = OrganizationDomain.GetMemberId(taiwuChar.GetOrganizationInfo().OrgTemplateId, peopleLevel);
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance.GetItem(orgMemberId);
		CharacterItem template = Config.Character.Instance[charTemplateId];
		short baseAttraction = ((blockData.TemplateId == 217) ? ((short)Math.Min(random.Next(500, 751) + 25 * peopleLevel, 900)) : GenerateRandomAttraction(random, -1));
		short[] combatSkillAdjusts = blockConfig.RecruitCombatSkillsAdjust;
		if (DomainManager.Building.IsDependKungfuPracticeRoom(blockConfig))
		{
			List<short[]> adjusts = new List<short[]>();
			DomainManager.Building.BuildingBlockDependencies(blockKey, delegate(BuildingBlockData dependData, int _, BuildingBlockKey dependKey)
			{
				if (dependData.TemplateId == 52)
				{
					DomainManager.Building.BuildingBlockInfluences(dependKey, delegate(BuildingBlockData influenceData, int num)
					{
						adjusts.Add(influenceData.ConfigData.RecruitCombatSkillsAdjust);
					});
				}
			});
			combatSkillAdjusts = CharacterCreation.MergeAdjusts(adjusts, 14);
		}
		FeatureCreationContext featureCreationContext = new FeatureCreationContext
		{
			FeatureIds = new List<short>(),
			PotentialFeatureIds = new List<short>(),
			Gender = gender,
			BirthMonth = (sbyte)random.Next(0, 11),
			CurrAge = age,
			RandomFeaturesAtCreating = true,
			PotentialFeaturesAge = -1,
			DestinyType = -1,
			AllGoodBasicFeature = false,
			IsProtagonist = false
		};
		CharacterCreation.CreateFeatures(random, ref featureCreationContext);
		short clothingTemplateId = OrganizationDomain.GetRandomOrgMemberClothing(random, orgMemberConfig);
		AvatarData avatarData;
		short avatarAttraction;
		do
		{
			avatarData = AvatarManager.Instance.GetRandomAvatar(random, gender, transgender, template.PresetBodyType, baseAttraction);
			bool isAbleToGrowHair = orgMemberConfig.MonkType != 130;
			bool isAbleToGrowBeard = gender == 1 && !transgender && !featureCreationContext.FeatureIds.Contains(168);
			for (sbyte i = 0; i < 7; i++)
			{
				if (1 == 0)
				{
				}
				bool flag = i switch
				{
					0 => isAbleToGrowHair, 
					1 => age >= GlobalConfig.Instance.AgeShowBeard1 && isAbleToGrowBeard, 
					2 => isAbleToGrowBeard, 
					3 => SharedMethods.IsAbleToGrowWrinkle1(age), 
					4 => SharedMethods.IsAbleToGrowWrinkle2(age), 
					5 => SharedMethods.IsAbleToGrowWrinkle3(age), 
					6 => IsAbleToGrowEyebrow(), 
					_ => false, 
				};
				if (1 == 0)
				{
				}
				bool isShow = flag;
				avatarData.SetGrowableElementShowingAbility(i, isShow);
				avatarData.SetGrowableElementShowingState(i, isShow);
			}
			avatarAttraction = avatarData.GetCharm(age, Config.Clothing.Instance[clothingTemplateId].DisplayId);
		}
		while (Math.Abs(baseAttraction - avatarAttraction) > 100);
		baseAttraction = avatarAttraction;
		int bonus = 0;
		foreach (short featureId in featureCreationContext.FeatureIds)
		{
			int value = CharacterFeature.GetCharacterPropertyBonus(featureId, ECharacterPropertyReferencedType.Attraction);
			bonus = EDataSumType.All.Sum(bonus, value);
		}
		short finalAttraction = (short)(baseAttraction + bonus);
		short attractionPercentBonus = 0;
		foreach (short featureId2 in featureCreationContext.FeatureIds)
		{
			attractionPercentBonus += CharacterFeature.Instance[featureId2].AttractionPercentBonus;
		}
		finalAttraction = (short)(finalAttraction * (100 + attractionPercentBonus) / 100);
		List<sbyte> teammateCommands = new List<sbyte>();
		ExtraDomain.GetRandomCmdTypes(random, teammateCommands, CalcMedalCount);
		RecruitCharacterData data = new RecruitCharacterData
		{
			TemplateId = charTemplateId,
			PeopleLevel = peopleLevel,
			Age = age,
			BirthMonth = featureCreationContext.BirthMonth,
			FullName = CharacterDomain.GenerateRandomHanName(random, -1, -1, gender, 0),
			BaseAttraction = baseAttraction,
			FinalAttraction = finalAttraction,
			AvatarData = avatarData,
			MainAttributes = CharacterCreation.CreateMainAttributes(random, peopleLevel, orgMemberConfig.MainAttributesAdjust, null, 0),
			FeatureIds = featureCreationContext.FeatureIds,
			Gender = gender,
			Transgender = transgender,
			CombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, peopleLevel, combatSkillAdjusts, null, 0),
			CombatSkillQualificationGrowthType = (sbyte)random.Next(3),
			LifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, peopleLevel, blockConfig.RecruitLifeSkillsAdjust, null, 0),
			LifeSkillQualificationGrowthType = (sbyte)random.Next(3),
			ClothingTemplateId = clothingTemplateId,
			TeammateCommands = teammateCommands
		};
		data.Recalculate();
		return data;
		int CalcMedalCount(sbyte medalType)
		{
			return CharacterFeatureHelper.CalcFeatureMedalValue(featureCreationContext.FeatureIds, medalType);
		}
	}

	public IEnumerable<SolarTermItem> GetInvokedSolarTerm()
	{
		List<sbyte> validSolarTypes = ObjectPool<List<sbyte>>.Instance.Get();
		validSolarTypes.Clear();
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = _eatingItems.Get(i);
			if (itemKey.ItemType == 9)
			{
				TeaWineItem config = Config.TeaWine.Instance[itemKey.TemplateId];
				if (config.ItemSubType == 901 && config.SolarTermType >= 0 && !validSolarTypes.Contains(config.SolarTermType))
				{
					validSolarTypes.Add(config.SolarTermType);
				}
			}
		}
		sbyte month = DomainManager.World.GetCurrMonthInYear();
		foreach (SolarTermItem solar in (IEnumerable<SolarTermItem>)SolarTerm.Instance)
		{
			if (solar.Month == month && validSolarTypes.Contains(solar.Type))
			{
				yield return solar;
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(validSolarTypes);
	}

	public CValuePercentBonus GetSolarTermBonus(int value)
	{
		return GetSolarTermValue(value);
	}

	public int GetSolarTermValue(int value)
	{
		if (DomainManager.Taiwu.GetTaiwuCharId() != _id)
		{
			return value;
		}
		if (!DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(30))
		{
			return value;
		}
		List<short> allWineTemplateIds = ObjectPool<List<short>>.Instance.Get();
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = _eatingItems.Get(i);
			if (itemKey.ItemType == 9)
			{
				TeaWineItem config = Config.TeaWine.Instance[itemKey.TemplateId];
				if (config.ItemSubType == 901 && !allWineTemplateIds.Contains(itemKey.TemplateId))
				{
					allWineTemplateIds.Add(itemKey.TemplateId);
				}
			}
		}
		int wineCount = allWineTemplateIds.Count;
		ObjectPool<List<short>>.Instance.Return(allWineTemplateIds);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(7);
		return value * professionData.GetSeniorityToWineTasterSolarTermBonus(wineCount);
	}

	public CValueModifyDelta GetSolarTermBonusHealInjury(bool inner)
	{
		int bonus = 0;
		sbyte baseValue = (inner ? GlobalConfig.Instance.SolarTermAddHealInnerInjury : GlobalConfig.Instance.SolarTermAddHealOuterInjury);
		foreach (SolarTermItem solarTerm in GetInvokedSolarTerm())
		{
			if (inner ? solarTerm.InnerHealingBuff : solarTerm.OuterHealingBuff)
			{
				bonus += GetSolarTermValue(baseValue);
			}
		}
		return new CValueModifyDelta(EDataModifyType.AddPercent, bonus);
	}

	public CValueModifyDelta GetSolarTermBonusHealPoison(sbyte poisonType)
	{
		int bonus = 0;
		foreach (SolarTermItem solarTerm in GetInvokedSolarTerm())
		{
			if (solarTerm.DetoxBuffType == poisonType)
			{
				bonus += GetSolarTermValue(GlobalConfig.Instance.SolarTermAddHealPoison);
			}
		}
		return new CValueModifyDelta(EDataModifyType.AddPercent, bonus);
	}

	public CValueModifyDelta GetSolarTermBonusAddPoison(sbyte poisonType)
	{
		int bonus = 0;
		foreach (SolarTermItem solarTerm in GetInvokedSolarTerm())
		{
			if (solarTerm.PoisonBuffType == poisonType)
			{
				bonus += GetSolarTermValue(GlobalConfig.Instance.SolarTermAddPoisonEffect);
			}
		}
		return new CValueModifyDelta(EDataModifyType.AddPercent, bonus);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void ActivateAdvanceMonthStatus(byte statusType)
	{
		_advanceMonthStatus |= statusType;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void DeactivateAdvanceMonthStatus(byte statusType)
	{
		_advanceMonthStatus &= (byte)(~statusType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool IsActiveAdvanceMonthStatus(byte statusType)
	{
		return (_advanceMonthStatus & statusType) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void ResetAdvanceMonthStatus()
	{
		_advanceMonthStatus = 0;
	}

	public void PeriAdvanceMonth_UpdateStatus(DataContext context)
	{
		PeriAdvanceMonthUpdateStatusModification mod = new PeriAdvanceMonthUpdateStatusModification(this);
		IRandomSource rand = context.Random;
		OfflineChangeXiangshuInfection(mod);
		OfflineIncreaseAge(context, mod);
		if (!OfflineUpdatePregnantState(context, mod))
		{
			context.ParallelModificationsRecorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdateStatus);
			context.ParallelModificationsRecorder.RecordParameterClass(mod);
			return;
		}
		OfflineUpdateEatingItemEffect(context, mod);
		OfflineUpdateFeaturePoisons(context, mod);
		if (_xiangshuInfection < 200)
		{
			OfflineAutoRecoverCurrNeili(mod);
			OfflineChangeQiDisorder(mod);
			DomainManager.World.ApplyChallengeModeAdvanceMonthWorsen(rand, this, ref _injuries, ref _poisoned, mod);
			OfflineChangeInjuries(context.Random, mod);
			OfflineAutoRecoverPoisoned(mod);
			OfflineAutoRecoverMainAttributes();
		}
		else
		{
			OfflineRecoverAllForXiangshuInfected(mod);
		}
		OfflineUpdateHappiness(mod);
		if (_id != DomainManager.Taiwu.GetTaiwuCharId() && GetAgeGroup() != 0 && _kidnapperId < 0)
		{
			OfflineUseResourcesForHealingAndDetox(mod);
			context.AdvanceMonthRelatedData.CategorizedRegenItems(_inventory.Items);
			OfflineUseMedicineForHealingAndDetox(context, mod);
			OfflineUpdateHealth();
			OfflineUseResourcesForHealth(mod);
			OfflineUseMedicineForHealth(context, mod);
			OfflineUseMedicineForWug(context, mod);
			OfflineUseItemForNeili(context, mod);
			OfflineUseFoodForMainAttributes(context, mod);
			OfflineUseTeaWineForHappiness(context, mod);
			context.AdvanceMonthRelatedData.ReleaseCategorizedRegenItems();
		}
		else
		{
			OfflineUpdateHealth();
		}
		OfflineUpdateEatingItems(context, mod);
		ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
		recorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdateStatus);
		recorder.RecordParameterClass(mod);
	}

	public static void ComplementPeriAdvanceMonth_UpdateStatus(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		Character character = mod.Character;
		if (mod.ResourcesChanged)
		{
			character.SetResources(ref character.GetResources(), context);
		}
		if (mod.EatingItemsChanged)
		{
			character.SetEatingItems(ref character.GetEatingItems(), context);
			MonthlyNotificationCollection monthlyNotification = DomainManager.World.GetMonthlyNotificationCollection();
			if (mod.RemovedWugKings != null)
			{
				foreach (ItemKey wugKing in mod.RemovedWugKings)
				{
					monthlyNotification.AddWugKingDead(character.GetId(), wugKing.ItemType, wugKing.TemplateId);
				}
			}
			if (mod.RemovedSafetyWugKings != null)
			{
				foreach (ItemKey wugKing2 in mod.RemovedSafetyWugKings)
				{
					monthlyNotification.AddWugKingDeadSpecial(character.GetId(), wugKing2.ItemType, wugKing2.TemplateId);
				}
			}
			if (mod.RemovedWugs != null)
			{
				foreach (short wugTemplateId in mod.RemovedWugs)
				{
					Events.RaiseRemoveWug(context, character._id, wugTemplateId);
				}
			}
		}
		character.SetCurrMainAttributes(character.GetCurrMainAttributes(), context);
		if (mod.CurrNeiliChanged)
		{
			character.SetCurrNeili(character.GetCurrNeili(), context);
		}
		if (mod.QiDisorderChanged)
		{
			character.SetDisorderOfQi(character.GetDisorderOfQi(), context);
		}
		if (mod.InjuriesChanged)
		{
			character.SetInjuries(character.GetInjuries(), context);
		}
		if (mod.PoisonedChanged)
		{
			character.SetPoisoned(ref character.GetPoisoned(), context);
		}
		if (mod.InventoryChanged)
		{
			character.SetInventory(character.GetInventory(), context);
		}
		if (mod.HappinessChanged)
		{
			character.SetHappiness(character.GetHappiness(), context);
		}
		if (mod.XiangshuInfectionChanged)
		{
			character.SetXiangshuInfection(character._xiangshuInfection, context);
		}
		if (character.IsTaiwu())
		{
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			OuterAndInnerInts challengeModeWorsenInjuryCount = mod.ChallengeModeWorsenInjuryCount;
			var (worsenOuter, worsenInner) = (OuterAndInnerInts)(ref challengeModeWorsenInjuryCount);
			if (worsenOuter > 0)
			{
				monthlyNotificationCollection.AddChallengeModeAdvanceMonthWorsenInjuryOuter(worsenOuter);
			}
			if (worsenInner > 0)
			{
				monthlyNotificationCollection.AddChallengeModeAdvanceMonthWorsenInjuryInner(worsenInner);
			}
			if (mod.ChallengeModeWorsenAnyPoison)
			{
				monthlyNotificationCollection.AddChallengeModeAdvanceMonthWorsenPoison();
			}
		}
		if (mod.CurrAgeChanged)
		{
			character.SetCurrAge(character._currAge, context);
			AvatarData avatar = character.GetAvatar();
			if (avatar.UpdateGrowableElementsShowingAbilities(character))
			{
				character.SetAvatar(avatar, context);
			}
			Events.RaiseCharacterAgeChanged(context, character, character._currAge - 1, character._currAge);
		}
		if (mod.HealthChanged)
		{
			character.SetHealth(character._health, context);
		}
		if (mod.MaxHealthChanged)
		{
			character.SetBaseMaxHealth(character._baseMaxHealth, context);
		}
		if (mod.ActualAgeChanged)
		{
			character.SetActualAge(character._actualAge, context);
		}
		character.TryGrowAvatarElements(context);
		if (mod.HobbyChanged)
		{
			character.CommitChangingHobby(context);
			if (mod.FavorabilitiesOfRelatedChars != null)
			{
				DomainManager.Character.ApplyFavorabilitiesOfRelatedCharsWhenChangingHobby(context, character.GetId(), mod.FavorabilitiesOfRelatedChars);
			}
		}
		if (mod.PregnantStateModification != null)
		{
			DomainManager.Character.ApplyPregnantStateChange(context, character, mod.PregnantStateModification);
		}
		if (mod.ConsumedForbiddenFoodsOrWines != null)
		{
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			foreach (ItemKey itemKey in mod.ConsumedForbiddenFoodsOrWines)
			{
				lifeRecordCollection.AddMonkBreakRule(character._id, currDate, character._location, itemKey.ItemType, itemKey.TemplateId);
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddMonkBreakRule(character._id, (ulong)itemKey);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
		}
		if (mod.FeaturesChanged)
		{
			character.SetFeatureIds(character.GetFeatureIds(), context);
		}
		DomainManager.Extra.TryRegenerateTeammateCommand(context, character);
		if (character._id != DomainManager.Taiwu.GetTaiwuCharId() && character.GetAgeGroup() != 0)
		{
			DomainManager.Extra.UpdateCombatSkillProficiency(context, character);
		}
		if (mod.PersonalNeedsChanged)
		{
			character.SetActionPlanningModified(context);
		}
		if (mod.NewClothingTemplateId != -1)
		{
			character.ForceReplaceClothing(context, mod.NewClothingTemplateId);
		}
		short health = character.GetHealth();
		character.SetHealth(health, context);
		if (mod.CurrMainAttributesChanged)
		{
			character.SetCurrMainAttributes(character._currMainAttributes, context);
		}
		if (mod.UsedHealingCount > 0)
		{
			DomainManager.Character.UseCombatResources(context, character._id, EHealActionType.Healing, mod.UsedHealingCount);
		}
		if (mod.UsedDetoxCount > 0)
		{
			DomainManager.Character.UseCombatResources(context, character._id, EHealActionType.Detox, mod.UsedDetoxCount);
		}
		if (mod.UsedBreathingCount > 0)
		{
			DomainManager.Character.UseCombatResources(context, character._id, EHealActionType.Breathing, mod.UsedBreathingCount);
		}
		if (mod.UsedRecoverCount > 0)
		{
			DomainManager.Character.UseCombatResources(context, character._id, EHealActionType.Recover, mod.UsedRecoverCount);
		}
		if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			if (mod.XiangshuInfectionFeatureChanged == 211)
			{
				DomainManager.World.SetTaiwuGettingCompletelyInfected();
			}
			else if (mod.XiangshuInfectionFeatureChanged == 210)
			{
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				monthlyEventCollection.AddTaiwuInfectedPartially(character.GetId(), character._location);
				Events.RaiseXiangshuInfectionFeatureChanged(context, character, mod.XiangshuInfectionFeatureChanged);
			}
			else if (character.GetXiangshuInfection() >= 200 && character._featureIds.Contains(733))
			{
				MonthlyEventCollection monthlyEventCollection2 = DomainManager.World.GetMonthlyEventCollection();
				monthlyEventCollection2.AddMirrorCreatedImpostureXiangshuInfected(character._id, character._location);
			}
			PregnantStateModification pregnantStateModification = mod.PregnantStateModification;
			if (pregnantStateModification != null && pregnantStateModification.LostMother)
			{
				DomainManager.World.SetTaiwuDying(isTaiwuDyingOfDystocia: true);
			}
		}
		else
		{
			if (mod.XiangshuInfectionFeatureChanged >= 0)
			{
				Events.RaiseXiangshuInfectionFeatureChanged(context, character, mod.XiangshuInfectionFeatureChanged);
			}
			PregnantStateModification pregnantStateModification = mod.PregnantStateModification;
			if (pregnantStateModification != null && pregnantStateModification.LostMother)
			{
				DomainManager.Character.MakeCharacterDead(context, character, 2);
			}
		}
	}

	private void ApplyItemLost(DataContext context, List<(MapBlockData block, ItemKey itemKey, int amount)> itemsToBeLost)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		SetInventory(_inventory, context);
		SetHappiness(_happiness, context);
		bool addSecretInformation = false;
		ItemKey secretInfoParamItemKey = ItemKey.Invalid;
		int i = 0;
		for (int count = itemsToBeLost.Count; i < count; i++)
		{
			var (block, itemKey, amount) = itemsToBeLost[i];
			DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.CharacterInventory, _id);
			if (block != null)
			{
				DomainManager.Map.AddBlockItem(context, block, itemKey, amount);
			}
			else
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
			lifeRecordCollection.AddLoseOverloadingItem(_id, currDate, _location, itemKey.ItemType, itemKey.TemplateId);
			if (!addSecretInformation && ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId) >= 6)
			{
				addSecretInformation = true;
				if (!secretInfoParamItemKey.IsValid() || ItemTemplateHelper.GetBaseValue(secretInfoParamItemKey.ItemType, secretInfoParamItemKey.TemplateId) < ItemTemplateHelper.GetBaseValue(itemKey.ItemType, itemKey.TemplateId))
				{
					secretInfoParamItemKey = itemKey;
				}
			}
		}
		if (addSecretInformation)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddLoseOverloadingItem(_id, (ulong)secretInfoParamItemKey, _location);
			DomainManager.Information.AddSecretInformationWithNecessity(context, secretInfoOffset, withInitialDistribute: true, necessarily: false, null);
		}
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			int j = 0;
			for (int count2 = Math.Min(100, itemsToBeLost.Count); j < count2; j++)
			{
				ItemKey itemKey2 = itemsToBeLost[j].itemKey;
				monthlyNotifications.AddLoseItemCausedByInventoryFull(_id, itemKey2.ItemType, itemKey2.TemplateId);
			}
		}
	}

	public void PeriAdvanceMonth_SelfImprovement(DataContext context)
	{
		if (GetAgeGroup() != 0)
		{
			PeriAdvanceMonthSelfImprovementModification mod = new PeriAdvanceMonthSelfImprovementModification(this);
			OfflineUpdateConsummateLevel(context, mod);
			OfflineApplyLoopNeigong(context, mod);
			OfflineIncreaseQualifications(context, mod);
			PeriAdvanceMonth_SelfImprovement_LearnNewSkills(context);
			if (mod.IsChanged)
			{
				ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
				recorder.RecordType(ParallelModificationType.PeriAdvanceMonthSelfImprovement);
				recorder.RecordParameterClass(mod);
			}
		}
	}

	private void OfflineUpdateConsummateLevel(DataContext context, PeriAdvanceMonthSelfImprovementModification mod)
	{
		sbyte maxConsummateLevel = GetMaxConsummateLevel();
		if (_consummateLevel >= maxConsummateLevel)
		{
			return;
		}
		int progress = DomainManager.Extra.GetCharacterConsummateLevelProgress(_id);
		progress += GlobalConfig.Instance.ConsummateLevelProgressSpeed[_organizationInfo.Grade];
		do
		{
			int threshold = GlobalConfig.Instance.ConsummateLevelProgressThreshold[_consummateLevel];
			if (progress >= threshold)
			{
				_consummateLevel++;
				mod.ConsummateLevelChanged = true;
				progress -= threshold;
				continue;
			}
			break;
		}
		while (_consummateLevel < maxConsummateLevel);
		mod.ConsummateLevelProgress = progress;
	}

	private void OfflineApplyLoopNeigong(DataContext context, PeriAdvanceMonthSelfImprovementModification mod)
	{
		if (_loopingNeigong >= 0)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[_loopingNeigong];
			(short neili, short qiDisorder, int[] extraNeiliAllocationProgress) tuple = CombatSkillDomain.CalcNeigongLoopingEffect(context.Random, this, skillCfg);
			short neili = tuple.neili;
			short qiDisorder = tuple.qiDisorder;
			int[] extraNeiliAllocationProgress = tuple.extraNeiliAllocationProgress;
			mod.LoopingNeigong = (combatSkillTemplateId: _loopingNeigong, neili: neili, qiDisorder: qiDisorder);
			mod.ExtraNeiliAllocationProgress = extraNeiliAllocationProgress;
		}
		short expectedNeili = CalcExpectedNeili();
		if (_extraNeili < expectedNeili)
		{
			_extraNeili = expectedNeili;
			mod.ExtraNeiliChanged = true;
		}
	}

	private void OfflineIncreaseQualifications(DataContext context, PeriAdvanceMonthSelfImprovementModification mod)
	{
		if (_usedQualificationPotential >= GlobalConfig.Instance.TaiwuVillagerMaxPotential || GetAgeGroup() != 2 || _organizationInfo.OrgTemplateId == 0 || _organizationInfo.OrgTemplateId == 16)
		{
			return;
		}
		IRandomSource random = context.Random;
		int triggerChance = AdvancingMonthFormula.DefValue.QualificationGrowthTriggerChance.Calculate();
		if (!random.CheckPercentProb(triggerChance))
		{
			return;
		}
		_usedQualificationPotential++;
		EQualificationImproveSources sources = EQualificationImproveSources.None;
		if (AdvancingMonthFormula.DefValue.QualificationGrowthGuaranteed.Calculate(_usedQualificationPotential) == 0)
		{
			sources |= EQualificationImproveSources.Guaranteed;
		}
		(sbyte, bool) skillTypeInfo = GetRandomSkillTypeByAdjust(context);
		Personalities personalities = GetPersonalities();
		HashSet<int> mentors = DomainManager.Character.GetRelatedCharIds(_id, 2048);
		int bestMentorId = -1;
		short maxMentorQualification = 0;
		sbyte personalityType;
		short selfQualification;
		if (skillTypeInfo.Item2)
		{
			personalityType = Config.CombatSkillType.Instance[skillTypeInfo.Item1].PersonalityType;
			selfQualification = GetCombatSkillQualification(skillTypeInfo.Item1);
			if (mentors.Count > 0)
			{
				foreach (int mentorId in mentors)
				{
					if (DomainManager.Character.TryGetElement_Objects(mentorId, out var mentor))
					{
						short mentorQualification = mentor.GetCombatSkillQualification(skillTypeInfo.Item1);
						if (mentorQualification >= maxMentorQualification)
						{
							maxMentorQualification = mentorQualification;
							bestMentorId = mentorId;
						}
					}
				}
			}
		}
		else
		{
			personalityType = Config.LifeSkillType.Instance[skillTypeInfo.Item1].PersonalityType;
			selfQualification = GetLifeSkillQualification(skillTypeInfo.Item1);
			if (mentors.Count > 0)
			{
				foreach (int mentorId2 in mentors)
				{
					if (DomainManager.Character.TryGetElement_Objects(mentorId2, out var mentor2))
					{
						short mentorQualification2 = mentor2.GetLifeSkillQualification(skillTypeInfo.Item1);
						if (mentorQualification2 >= maxMentorQualification)
						{
							maxMentorQualification = mentorQualification2;
							bestMentorId = mentorId2;
						}
					}
				}
			}
		}
		int personalityChance = AdvancingMonthFormula.DefValue.QualificationGrowthPersonality.Calculate(personalities[personalityType]);
		if (context.Random.CheckPercentProb(personalityChance))
		{
			sources |= EQualificationImproveSources.Personality;
		}
		int mentorChance = AdvancingMonthFormula.DefValue.QualificationGrowthMentor.Calculate(maxMentorQualification, selfQualification);
		if (context.Random.CheckPercentProb(mentorChance))
		{
			sources |= EQualificationImproveSources.Mentor;
		}
		mod.ImprovedSkillQualification = (skillTypeInfo.Item1, skillTypeInfo.Item2, sources, bestMentorId);
	}

	private (sbyte skillType, bool isCombatSkill) GetRandomSkillTypeByAdjust(DataContext context)
	{
		Span<(sbyte, bool)> span = stackalloc(sbyte, bool)[30];
		SpanList<(sbyte, bool)> defaultSkillTypes = span;
		Span<(sbyte, bool, short)> span2 = stackalloc(sbyte, bool, short)[30];
		SpanList<(sbyte, bool, short)> weights = span2;
		OrganizationMemberItem orgMemberConfig = _organizationInfo.GetOrgMemberConfig();
		weights.Add((-1, false, 6));
		weights.Add((-1, true, 6));
		for (sbyte i = 0; i < 14; i++)
		{
			short weight = orgMemberConfig.CombatSkillsAdjust[i];
			if (weight >= 0)
			{
				weights.Add((i, true, weight));
			}
			else
			{
				defaultSkillTypes.Add((i, true));
			}
		}
		for (sbyte i2 = 0; i2 < 16; i2++)
		{
			short weight2 = orgMemberConfig.LifeSkillsAdjust[i2];
			if (weight2 >= 0)
			{
				weights.Add((i2, false, weight2));
			}
			else
			{
				defaultSkillTypes.Add((i2, false));
			}
		}
		(sbyte, bool) selectedSkillType = GetRandomResult(weights, context.Random);
		return (selectedSkillType.Item1 < 0) ? defaultSkillTypes.GetRandom(context.Random) : selectedSkillType;
		(sbyte skillType, bool isCombatSkill) GetRandomResult(SpanList<(sbyte skillType, bool isCombatSkill, short weight)> spanList, IRandomSource random)
		{
			int totalWeight = 0;
			SpanList<(sbyte, bool, short)>.Enumerator enumerator = spanList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				(sbyte, bool, short) item = enumerator.Current;
				totalWeight += item.Item3;
			}
			int randomValue = random.Next(0, totalWeight);
			SpanList<(sbyte, bool, short)>.Enumerator enumerator2 = spanList.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				(sbyte, bool, short) item2 = enumerator2.Current;
				randomValue -= item2.Item3;
				if (randomValue < 0)
				{
					return (skillType: item2.Item1, isCombatSkill: item2.Item2);
				}
			}
			throw new Exception($"Unable to get random skill type {this}.");
		}
	}

	public void PeriAdvanceMonth_SelfImprovement_Taiwu(DataContext context)
	{
		PeriAdvanceMonthSelfImprovementModification mod = new PeriAdvanceMonthSelfImprovementModification(this);
		if (GenerateNeigongLoopingImprovementForTaiwu(context, out var neili, out var qiDisorder, out var extraNeiliAllocationProgress))
		{
			mod.LoopingNeigong = (combatSkillTemplateId: _loopingNeigong, neili: neili, qiDisorder: qiDisorder);
			mod.ExtraNeiliAllocationProgress = extraNeiliAllocationProgress;
		}
		if (mod.IsChanged)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthSelfImprovement);
			recorder.RecordParameterClass(mod);
		}
	}

	public bool GenerateNeigongLoopingImprovementForTaiwu(DataContext context, out short neili, out short qiDisorder, out int[] extraNeiliAllocationProgress)
	{
		if (_loopingNeigong >= 0)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[_loopingNeigong];
			(short, short, int[]) tuple = CombatSkillDomain.CalcNeigongLoopingEffect(context.Random, this, skillCfg);
			neili = tuple.Item1;
			qiDisorder = tuple.Item2;
			extraNeiliAllocationProgress = tuple.Item3;
			byte loopingDifficulty = DomainManager.World.GetLoopingDifficulty();
			short factor = WorldCreation.Instance[(byte)4].InfluenceFactors[loopingDifficulty];
			neili = (short)(neili * factor / 100);
			return true;
		}
		neili = 0;
		qiDisorder = 0;
		extraNeiliAllocationProgress = null;
		return false;
	}

	private short CalcExpectedNeili()
	{
		int expectedNeili = _extraNeili;
		for (sbyte grade = _organizationInfo.Grade; grade >= 0; grade--)
		{
			OrganizationInfo orgInfo = _organizationInfo;
			orgInfo.Grade = grade;
			OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
			if (orgMemberCfg.ConsummateLevel <= _consummateLevel)
			{
				if (orgMemberCfg.ConsummateLevel == _consummateLevel || grade == _organizationInfo.Grade)
				{
					expectedNeili = orgMemberCfg.Neili;
					break;
				}
				orgInfo.Grade++;
				OrganizationMemberItem prevLevelOrgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo);
				expectedNeili = _consummateLevel * (orgMemberCfg.Neili + prevLevelOrgMemberCfg.Neili) / (orgMemberCfg.ConsummateLevel + prevLevelOrgMemberCfg.ConsummateLevel);
				break;
			}
		}
		return (short)expectedNeili;
	}

	public static void ComplementPeriAdvanceMonth_SelfImprovement(DataContext context, PeriAdvanceMonthSelfImprovementModification mod)
	{
		Character character = mod.Character;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (mod.LoopingNeigong.combatSkillTemplateId >= 0)
		{
			DomainManager.CombatSkill.ApplyNeigongLoopingEffect(context, character, mod.LoopingNeigong.combatSkillTemplateId, mod.LoopingNeigong.neili, mod.ExtraNeiliAllocationProgress);
			if (mod.LoopingNeigong.qiDisorder != 0)
			{
				character.ChangeDisorderOfQiRandomRecovery(context, mod.LoopingNeigong.qiDisorder);
			}
		}
		if (mod.ResourcesChanged)
		{
			character.SetResources(ref character.GetResources(), context);
		}
		if (mod.ConsummateLevelChanged)
		{
			lifeRecordCollection.AddConsummateLevelIncreased(character._id, currDate, location);
			character.SetConsummateLevel(character._consummateLevel, context);
		}
		if (mod.ConsummateLevelProgress >= 0)
		{
			DomainManager.Extra.SetCharacterConsummateLevelProgress(context, character._id, mod.ConsummateLevelProgress);
		}
		if (mod.ExtraNeiliChanged)
		{
			character.SetExtraNeili(character.GetExtraNeili(), context);
		}
		if (!mod.ImprovedSkillQualification.HasValue)
		{
			return;
		}
		(sbyte, bool, EQualificationImproveSources, int) improveInfo = mod.ImprovedSkillQualification.Value;
		character.SetUsedQualificationPotential(character._usedQualificationPotential, context);
		int totalCount = 0;
		if ((improveInfo.Item3 | EQualificationImproveSources.Guaranteed) == improveInfo.Item3)
		{
			if (improveInfo.Item2)
			{
				lifeRecordCollection.AddCombatSkillQualificationGrowthGuaranteed(character._id, currDate, location, improveInfo.Item1);
			}
			else
			{
				lifeRecordCollection.AddLifeSkillQualificationGrowthGuaranteed(character._id, currDate, location, improveInfo.Item1);
			}
			totalCount++;
		}
		if ((improveInfo.Item3 | EQualificationImproveSources.Personality) == improveInfo.Item3)
		{
			if (improveInfo.Item2)
			{
				lifeRecordCollection.AddCombatSkillQualificationGrowthPersonality(character._id, currDate, location, Config.CombatSkillType.Instance[improveInfo.Item1].PersonalityType, improveInfo.Item1);
			}
			else
			{
				lifeRecordCollection.AddLifeSkillQualificationGrowthPersonality(character._id, currDate, location, Config.LifeSkillType.Instance[improveInfo.Item1].PersonalityType, improveInfo.Item1);
			}
			totalCount++;
		}
		if ((improveInfo.Item3 | EQualificationImproveSources.Mentor) == improveInfo.Item3)
		{
			if (improveInfo.Item2)
			{
				lifeRecordCollection.AddCombatSkillQualificationGrowthMentor(character._id, currDate, improveInfo.Item4, location, improveInfo.Item1);
			}
			else
			{
				lifeRecordCollection.AddLifeSkillQualificationGrowthMentor(character._id, currDate, improveInfo.Item4, location, improveInfo.Item1);
			}
			totalCount++;
		}
		if (totalCount > 0)
		{
			if (improveInfo.Item2)
			{
				character.ChangeBaseCombatSkillQualification(context, improveInfo.Item1, totalCount);
			}
			else
			{
				character.ChangeBaseLifeSkillQualification(context, improveInfo.Item1, totalCount);
			}
		}
	}

	public unsafe void PeriAdvanceMonth_SelfImprovement_LearnNewSkills(DataContext context)
	{
		if (GetAgeGroup() == 0)
		{
			return;
		}
		OrganizationItem orgCfg = Config.Organization.Instance[_organizationInfo.OrgTemplateId];
		if (!orgCfg.IsSect && orgCfg.TemplateId != 16)
		{
			return;
		}
		Personalities personalities = GetPersonalities();
		sbyte cleverness = personalities.Items[1];
		(short, short, byte) combatSkillToLearn = GetCombatSkillToLearn();
		if (combatSkillToLearn.Item1 >= 0)
		{
			CombatSkillShorts combatSkillAttainments = GetCombatSkillAttainments();
			CombatSkillShorts combatSkillQualifications = GetCombatSkillQualifications();
			CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[combatSkillToLearn.Item1];
			int successRate = GetTaughtNewSkillSuccessRate(combatSkillCfg.Grade, combatSkillQualifications.Items[combatSkillCfg.Type], combatSkillAttainments.Items[combatSkillCfg.Type], cleverness);
			if (!context.Random.CheckPercentProb(2 * successRate))
			{
				combatSkillToLearn.Item1 = -1;
			}
		}
		if (combatSkillToLearn.Item2 >= 0)
		{
			CombatSkillShorts combatSkillAttainments2 = GetCombatSkillAttainments();
			CombatSkillItem combatSkillCfg2 = Config.CombatSkill.Instance[combatSkillToLearn.Item2];
			int successRate2 = GetReadingSuccessRate(combatSkillCfg2.Grade, 0, combatSkillAttainments2.Items[combatSkillCfg2.Type], cleverness);
			if (!context.Random.CheckPercentProb(successRate2))
			{
				combatSkillToLearn.Item2 = -1;
			}
		}
		(short, short, byte) lifeSkillToLearn = GetLifeSkillToLearn();
		if (lifeSkillToLearn.Item1 >= 0)
		{
			LifeSkillShorts lifeSkillAttainments = GetLifeSkillAttainments();
			LifeSkillShorts lifeSkillQualifications = GetLifeSkillQualifications();
			Config.LifeSkillItem lifeSkillCfg = LifeSkill.Instance[lifeSkillToLearn.Item1];
			int successRate3 = GetTaughtNewSkillSuccessRate(lifeSkillCfg.Grade, lifeSkillQualifications.Items[lifeSkillCfg.Type], lifeSkillAttainments.Items[lifeSkillCfg.Type], cleverness);
			if (!context.Random.CheckPercentProb(2 * successRate3))
			{
				lifeSkillToLearn.Item1 = -1;
			}
		}
		if (lifeSkillToLearn.Item2 >= 0)
		{
			short newPageSkillTemplateId = _learnedLifeSkills[lifeSkillToLearn.Item2].SkillTemplateId;
			LifeSkillShorts lifeSkillAttainments2 = GetLifeSkillAttainments();
			Config.LifeSkillItem lifeSkillCfg2 = LifeSkill.Instance[newPageSkillTemplateId];
			int successRate4 = GetReadingSuccessRate(lifeSkillCfg2.Grade, 0, lifeSkillAttainments2.Items[lifeSkillCfg2.Type], cleverness);
			if (!context.Random.CheckPercentProb(successRate4))
			{
				lifeSkillToLearn.Item2 = -1;
			}
		}
		if (combatSkillToLearn.Item1 >= 0 || combatSkillToLearn.Item2 >= 0 || lifeSkillToLearn.Item1 >= 0 || lifeSkillToLearn.Item2 >= 0)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthSelfImprovementLearnNewSkills);
			recorder.RecordParameterClass(this);
			recorder.RecordParameterUnmanaged<(short, short, byte)>(combatSkillToLearn);
			recorder.RecordParameterUnmanaged<(short, short, byte)>(lifeSkillToLearn);
		}
	}

	public static void ComplementPeriAdvanceMonth_SelfImprovement_LearnNewSkills(DataContext context, Character character, (short newSkillTemplateId, short newPageSkillTemplateId, byte pageId) combatSkillToLearn, (short newSkillTemplateId, short newPageSkillIndex, byte pageId) lifeSkillToLearn)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		if (combatSkillToLearn.newSkillTemplateId >= 0)
		{
			lifeRecordCollection.AddLearnCombatSkill(character._id, currDate, character.GetLocation(), combatSkillToLearn.newSkillTemplateId);
			character.LearnNewCombatSkill(context, combatSkillToLearn.newSkillTemplateId, 0);
			character.CreateInventoryItem(context, 10, Config.CombatSkill.Instance[combatSkillToLearn.newSkillTemplateId].BookId, 1);
		}
		if (combatSkillToLearn.newPageSkillTemplateId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character._id, combatSkillToLearn.newPageSkillTemplateId));
			sbyte direction = CombatSkillDirection.GetRandomDirection(context.Random);
			byte internalIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(direction, combatSkillToLearn.pageId);
			ushort readingState = CombatSkillStateHelper.SetPageRead(combatSkill.GetReadingState(), internalIndex);
			DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
			DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, character.GetId(), combatSkill.GetId().SkillTemplateId, internalIndex);
		}
		if (lifeSkillToLearn.newSkillTemplateId >= 0)
		{
			lifeRecordCollection.AddLearnLifeSkill(character._id, currDate, character.GetLocation(), lifeSkillToLearn.newSkillTemplateId);
			character.LearnNewLifeSkill(context, lifeSkillToLearn.newSkillTemplateId, 1);
			character.CreateInventoryItem(context, 10, LifeSkill.Instance[lifeSkillToLearn.newSkillTemplateId].SkillBookId, 1);
		}
		if (lifeSkillToLearn.newPageSkillIndex >= 0)
		{
			character.ReadLifeSkillPage(context, lifeSkillToLearn.newPageSkillIndex, lifeSkillToLearn.pageId);
		}
	}

	private (short newSkillTemplateId, short newPageSkillIndex, byte pageId) GetLifeSkillToLearn()
	{
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		if (_organizationInfo.OrgTemplateId == 16)
		{
			return (newSkillTemplateId: -1, newPageSkillIndex: -1, pageId: 0);
		}
		short newSkillTemplateId = -1;
		short newPageSkillIndex = -1;
		byte pageId = 0;
		for (sbyte lifeSkillType = 0; lifeSkillType < orgMemberCfg.LifeSkillsAdjust.Length; lifeSkillType++)
		{
			short adjust = orgMemberCfg.LifeSkillsAdjust[lifeSkillType];
			if (adjust >= 6)
			{
				for (int i = 0; i <= orgMemberCfg.LifeSkillGradeLimit; i++)
				{
					short lifeSkillTemplateId = Config.LifeSkillType.Instance[lifeSkillType].SkillList[i];
					int index = FindLearnedLifeSkillIndex(lifeSkillTemplateId);
					if (index < 0)
					{
						if (newSkillTemplateId < 0)
						{
							newSkillTemplateId = lifeSkillTemplateId;
						}
					}
					else if (newPageSkillIndex < 0)
					{
						LifeSkillItem learnedLifeSkill = _learnedLifeSkills[index];
						if (!learnedLifeSkill.IsAllPagesRead())
						{
							newPageSkillIndex = (short)index;
							pageId = 0;
							while (pageId < 5 && learnedLifeSkill.IsPageRead(pageId))
							{
								pageId++;
							}
						}
					}
					if (newSkillTemplateId >= 0 && newPageSkillIndex >= 0)
					{
						return (newSkillTemplateId: newSkillTemplateId, newPageSkillIndex: newPageSkillIndex, pageId: pageId);
					}
				}
			}
		}
		return (newSkillTemplateId: newSkillTemplateId, newPageSkillIndex: newPageSkillIndex, pageId: pageId);
	}

	private (short newSkillTemplateId, short newPageSkillTemplateId, byte pageId) GetCombatSkillToLearn()
	{
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		if (_organizationInfo.OrgTemplateId == 16)
		{
			return (newSkillTemplateId: -1, newPageSkillTemplateId: -1, pageId: 0);
		}
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		short newSkillTemplateId = -1;
		short newPageSkillTemplateId = -1;
		byte pageId = 0;
		foreach (PresetOrgMemberCombatSkill presetCombatSkill in orgMemberCfg.CombatSkills)
		{
			CombatSkillItem presetSkillCfg = Config.CombatSkill.Instance[presetCombatSkill.SkillGroupId];
			IReadOnlyList<CombatSkillItem> group = CombatSkillDomain.GetLearnableCombatSkills(presetSkillCfg.SectId, presetSkillCfg.Type);
			int maxGrade = Math.Min(presetCombatSkill.MaxGrade, group.Count - 1);
			for (int skillGrade = 0; skillGrade <= maxGrade; skillGrade++)
			{
				short skillTemplateId = group[skillGrade].TemplateId;
				if (!learnedCombatSkills.TryGetValue(skillTemplateId, out var combatSkill))
				{
					if (newSkillTemplateId < 0)
					{
						newSkillTemplateId = skillTemplateId;
					}
				}
				else if (newPageSkillTemplateId < 0)
				{
					ushort readingState = combatSkill.GetReadingState();
					byte nextUnreadPage = CombatSkillStateHelper.GetNextPageToRead(readingState);
					if (nextUnreadPage < 15 && !combatSkill.GetRevoked())
					{
						newPageSkillTemplateId = combatSkill.GetId().SkillTemplateId;
						pageId = nextUnreadPage;
					}
				}
				if (newSkillTemplateId >= 0 && newPageSkillTemplateId >= 0)
				{
					return (newSkillTemplateId: newSkillTemplateId, newPageSkillTemplateId: newPageSkillTemplateId, pageId: pageId);
				}
			}
		}
		return (newSkillTemplateId: newSkillTemplateId, newPageSkillTemplateId: newPageSkillTemplateId, pageId: pageId);
	}

	public void PeriAdvanceMonth_SelfImprovement_Reading(DataContext context)
	{
		sbyte personality = GetPersonality(2);
		int chance = AdvancingMonthFormula.DefValue.ReadingTriggerChance.Calculate(personality);
		if (context.Random.CheckPercentProb(chance))
		{
			(GameData.Domains.Item.SkillBook, int, byte) readingInfo = context.Equipping.GetCurrReadingBook(this);
			if (readingInfo.Item1 != null)
			{
				sbyte succeedPageCount = OfflineUpdateReadingProgress(readingInfo.Item1, readingInfo.Item3);
				ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
				recorder.RecordType(ParallelModificationType.PeriAdvanceMonthSelfImprovementReading);
				recorder.RecordParameterClass(this);
				recorder.RecordParameterClass(readingInfo.Item1);
				recorder.RecordParameterUnmanaged(readingInfo.Item2);
				recorder.RecordParameterUnmanaged(readingInfo.Item3);
				recorder.RecordParameterUnmanaged(succeedPageCount);
			}
		}
	}

	public static void ComplementPeriAdvanceMonth_SelfImprovement_Reading(DataContext context, Character character, GameData.Domains.Item.SkillBook readingBook, int learnedSkillIndex, byte readingPage, sbyte succeedPageCount)
	{
		character.ApplyBookReadingResult(context, readingBook, learnedSkillIndex, readingPage, succeedPageCount);
	}

	public bool ReadCurrBook(DataContext context)
	{
		if (IsTaiwu())
		{
			return false;
		}
		(GameData.Domains.Item.SkillBook, int, byte) readingInfo = context.Equipping.GetCurrReadingBook(this);
		if (readingInfo.Item1 == null)
		{
			return false;
		}
		sbyte succeedPageCount = OfflineUpdateReadingProgress(readingInfo.Item1, readingInfo.Item3);
		ApplyBookReadingResult(context, readingInfo.Item1, readingInfo.Item2, readingInfo.Item3, succeedPageCount);
		return true;
	}

	public void PeriAdvanceMonth_ActivePreparation_GetSupply(DataContext context)
	{
		sbyte ageGroup = GetAgeGroup();
		if (ageGroup == 0)
		{
			return;
		}
		PeriAdvanceMonthGetSupplyModification mod = new PeriAdvanceMonthGetSupplyModification(this);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		context.AdvanceMonthRelatedData.SummarizeItemSubTypeStats(_inventory.Items, _equipment);
		mod.ResourceChanged = OfflineGetResourcesSupply(orgMemberCfg);
		if (_location.IsValid() && _location.AreaId != 138)
		{
			OfflineGetBookSupply(context, mod);
			if (_organizationInfo.OrgTemplateId != 16)
			{
				OfflineGetItemSupply(context, mod, orgMemberCfg.ItemSatisfyingThreshold, orgMemberCfg.Inventory);
				OfflineGetEquipmentSupply(context, mod, orgMemberCfg.Equipment);
			}
		}
		if (ageGroup == 2)
		{
			OfflineGetClothingSupply(context, mod, orgMemberCfg.Clothing.TemplateId);
		}
		context.AdvanceMonthRelatedData.ReleaseItemSubTypeStats();
		if (mod.IsChanged)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthActivePreparationGetSupply);
			recorder.RecordParameterClass(mod);
		}
	}

	public static void ComplementPeriAdvanceMonth_ActivePreparation_GetSupply(DataContext context, PeriAdvanceMonthGetSupplyModification mod)
	{
		Character character = mod.Character;
		List<(sbyte, short, int)> itemsToCreate = mod.ItemsToCreate;
		if (itemsToCreate != null && itemsToCreate.Count > 0)
		{
			foreach (var itemInfo in mod.ItemsToCreate)
			{
				character.OfflineCreateInventoryItem(context, itemInfo.type, itemInfo.templateId, itemInfo.amount);
			}
			character.SetInventory(character.GetInventory(), context);
		}
		if (mod.ResourceChanged)
		{
			character.SetResources(ref character._resources, context);
		}
		if (mod.PersonalNeedChanged)
		{
			character.SetActionPlanningModified(context);
		}
	}

	public void PeriAdvanceMonth_ActivePreparation_CombatSkillAndItemEquipping(DataContext context)
	{
		if (GetAgeGroup() != 0)
		{
			PeriAdvanceMonthActivePreparationModification mod = new PeriAdvanceMonthActivePreparationModification(this);
			OfflineRepairEquipments(context, mod);
			OfflineFeedAnimalCarrier(context.Random, mod);
			bool outOfTaiwuGroup = !DomainManager.Taiwu.IsInGroup(_id);
			if (outOfTaiwuGroup || !DomainManager.Character.IsCombatSkillAttainmentLocked(_id))
			{
				context.Equipping.ParallelSetInitialCombatSkillAttainmentPanels(context, this);
			}
			SelectEquipmentsModification selectEquipmentMod = context.Equipping.ParallelSelectEquipments(context, this, outOfTaiwuGroup);
			OfflineAddPoisonToEquipments(context, mod, selectEquipmentMod.EquippedItems);
			if (mod.IsChanged)
			{
				ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
				recorder.RecordType(ParallelModificationType.PeriAdvanceMonthActivePreparation);
				recorder.RecordParameterClass(mod);
			}
		}
	}

	public static void ComplementPeriAdvanceMonth_ActivePreparation(DataContext context, PeriAdvanceMonthActivePreparationModification mod)
	{
		Character character = mod.Character;
		int charId = character.GetId();
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			location = character.GetValidLocation();
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		if (mod.ResourcesChanged)
		{
			character.SetResources(ref character._resources, context);
		}
		if (mod.ItemsFixed != null)
		{
			foreach (ItemBase item in mod.ItemsFixed)
			{
				item.SetCurrDurability(item.GetCurrDurability(), context);
				lifeRecordCollection.AddRepairItem(charId, currDate, location, item.GetItemType(), item.GetTemplateId());
			}
		}
		if (mod.CraftToolsUsed != null)
		{
			foreach (int itemId in mod.CraftToolsUsed)
			{
				GameData.Domains.Item.CraftTool craftTool = DomainManager.Item.GetElement_CraftTools(itemId);
				craftTool.SetCurrDurability(craftTool.GetCurrDurability(), context);
			}
		}
		if (mod.PersonalNeedChanged)
		{
			character.SetActionPlanningModified(context);
		}
		if (mod.FeedingCarrierKey.IsValid() && mod.FeedingFoodKey.IsValid())
		{
			DomainManager.Extra.FeedCarrier(context, character, mod.FeedingCarrierKey, mod.FeedingFoodKey);
			lifeRecordCollection.AddFeedTheAnimal(charId, currDate, mod.FeedingFoodKey.ItemType, mod.FeedingFoodKey.TemplateId, mod.FeedingCarrierKey.ItemType, mod.FeedingCarrierKey.TemplateId);
		}
		if (mod.PoisonsToUse == null || mod.EquipmentSlotToAddPoison < 0)
		{
			return;
		}
		ItemKey equipmentKey = character._equipment[mod.EquipmentSlotToAddPoison];
		if (!equipmentKey.IsValid())
		{
			AdaptableLog.TagWarning($"ActivePreparation ({charId})", $"Invalid item {equipmentKey} at slot {mod.EquipmentSlotToAddPoison} selected for adding poison.");
		}
		else
		{
			ItemKey newItemKey = character.ApplyAddPoisonsToItem(context, equipmentKey, mod.PoisonsToUse);
			if (equipmentKey != newItemKey)
			{
				character._equipment[mod.EquipmentSlotToAddPoison] = newItemKey;
				character.SetEquipment(character._equipment, context);
			}
		}
	}

	private ItemKey ApplyAddPoisonsToItem(DataContext context, ItemKey itemKey, ItemKey[] poisonKeys)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = GetValidLocation();
		ItemBase itemObj = DomainManager.Item.GetBaseItem(itemKey);
		if (poisonKeys.Length == 3 && poisonKeys[0].TemplateEquals(poisonKeys[1]) && poisonKeys[0].TemplateEquals(poisonKeys[2]))
		{
			ItemBase newItemObj = DomainManager.Item.SetAttachedPoisons(context, itemObj, poisonKeys[0].TemplateId, add: true, new short[2]
			{
				poisonKeys[1].TemplateId,
				poisonKeys[1].TemplateId
			}).item;
			itemObj = newItemObj;
			lifeRecordCollection.AddEnvenomedItemOverload(_id, currDate, location, poisonKeys[0].ItemType, poisonKeys[0].TemplateId, poisonKeys[1].ItemType, poisonKeys[1].TemplateId, poisonKeys[2].ItemType, poisonKeys[2].TemplateId, itemKey.ItemType, itemKey.TemplateId);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddAddPoisonToItem(_id, (ulong)newItemObj.GetItemKey(), (ulong)poisonKeys[0]);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			for (int i = 0; i < poisonKeys.Length; i++)
			{
				ItemKey poisonItemKey = poisonKeys[i];
				if (poisonItemKey.IsValid() && _inventory.Items.ContainsKey(poisonItemKey))
				{
					MedicineItem poisonConfig = Config.Medicine.Instance[poisonItemKey.TemplateId];
					Tester.Assert(poisonConfig.EffectType == EMedicineEffectType.ApplyPoison);
					ItemBase newItemObj2 = DomainManager.Item.SetAttachedPoisons(context, itemObj, poisonItemKey.TemplateId, add: true).item;
					itemObj = newItemObj2;
					lifeRecordCollection.AddAddPoisonToItem(_id, currDate, location, poisonItemKey.ItemType, poisonItemKey.TemplateId, itemKey.ItemType, itemKey.TemplateId);
					SecretInformationCollection secretInformationCollection2 = DomainManager.Information.GetSecretInformationCollection();
					int secretInfoOffset2 = secretInformationCollection2.AddAddPoisonToItem(_id, (ulong)newItemObj2.GetItemKey(), (ulong)poisonItemKey);
					DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
				}
			}
		}
		foreach (ItemKey poisonItemKey2 in poisonKeys)
		{
			RemoveInventoryItem(context, poisonItemKey2, 1, deleteItem: true);
		}
		return itemObj.GetItemKey();
	}

	public void PeriAdvanceMonth_LoseOverLoadedItems(DataContext context)
	{
		PeriAdvanceMonthLoseOverloadItemsModification mod = new PeriAdvanceMonthLoseOverloadItemsModification(this);
		int happinessChange = OfflineLoseOverloadedItems(context, mod);
		_happiness = (sbyte)Math.Clamp(_happiness + happinessChange, -119, 119);
		ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
		recorder.RecordType(ParallelModificationType.PeriAdvanceMonthLoseOverloadItems);
		recorder.RecordParameterClass(mod);
	}

	public void PeriAdvanceMonth_GearMateLoseOverLoadedItems(DataContext context)
	{
		int overloadedWeight = GetCurrInventoryLoad() - GetMaxInventoryLoad();
		if (overloadedWeight > 0)
		{
			PeriAdvanceMonthLoseOverloadItemsModification mod = new PeriAdvanceMonthLoseOverloadItemsModification(this);
			OfflineLoseOverloadedItems(context, mod);
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthLoseOverloadItems);
			recorder.RecordParameterClass(mod);
		}
	}

	public void PeriAdvanceMonth_SpecialGroupUpdateStatus(DataContext context)
	{
		PeriAdvanceMonthUpdateStatusModification mod = new PeriAdvanceMonthUpdateStatusModification(this);
		OfflineUpdateEatingItemEffect(context, mod);
		OfflineAutoRecoverCurrNeili(mod);
		OfflineAutoRecoverMainAttributes();
		OfflineUpdateEatingItems(context, mod);
		ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
		recorder.RecordType(ParallelModificationType.PeriAdvanceMonthUpdateStatus);
		recorder.RecordParameterClass(mod);
	}

	public static void ComplementPeriAdvanceMonth_LoseOverloadItems(DataContext context, PeriAdvanceMonthLoseOverloadItemsModification mod)
	{
		Character character = mod.Character;
		if (mod.ItemsToBeLost != null)
		{
			character.ApplyItemLost(context, mod.ItemsToBeLost);
		}
	}

	public unsafe MainAttributes GetMainAttributesRecoveries()
	{
		MainAttributes recoveries = default(MainAttributes);
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		short physiologicalAge = GetPhysiologicalAge();
		short clampedAge = GetClampedAgeOfAgeEffect(physiologicalAge);
		MainAttributes ageInfluence = AgeEffect.Instance[clampedAge].MainAttributesRecoveries;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int actionPointBonus = ((_id == taiwuCharId) ? (DomainManager.Extra.GetActionPointCurrMonth() / 10) : 0);
		for (sbyte i = 0; i < 6; i++)
		{
			short maxValue = maxMainAttributes.Items[i];
			int recovery = maxValue / 5 * ageInfluence.Items[i] / 100;
			recovery = Math.Max(1, recovery * (actionPointBonus + 100) / 100);
			if (_id == taiwuCharId)
			{
				ExtraDomain extraDomain = DomainManager.Extra;
				int professionId = ProfessionRelatedConstants.MainAttributeRecoverProfessionIds[i];
				if (extraDomain.IsProfessionalSkillUnlocked(professionId, 0))
				{
					ProfessionData professionData = extraDomain.GetProfessionData(professionId);
					recovery = professionData.GetMainAttributesRecoveryBonusAppliedRate(i, recovery);
				}
				ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(112 + i);
				recovery *= DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(propertyType);
			}
			recoveries.Items[i] = (short)recovery;
		}
		return recoveries;
	}

	public (short total, short disorderOfQiFactor, short injuryFactor, short poisonFactor, short buildingFactor, short eatItemFactor, short featureFactor, short specialEffectFactor) GetHealthRecovery(bool isCompletelyInfected)
	{
		if (IsGearMate)
		{
			return (total: 0, disorderOfQiFactor: -1, injuryFactor: -1, poisonFactor: -1, buildingFactor: -1, eatItemFactor: -1, featureFactor: -1, specialEffectFactor: -1);
		}
		if (isCompletelyInfected)
		{
			return (total: short.MaxValue, disorderOfQiFactor: -1, injuryFactor: -1, poisonFactor: -1, buildingFactor: -1, eatItemFactor: -1, featureFactor: -1, specialEffectFactor: -1);
		}
		int delta = 0;
		delta += GetHealthChangeDueToInjuries(ref _injuries);
		int injuryFactor = delta;
		int deltaOld = delta;
		delta += GetHealthChangeDueToPoisons(ref _poisoned, ref GetPoisonResists());
		int poisonFactor = delta - deltaOld;
		deltaOld = delta;
		delta += GetHealthChangeDueToDisorderOfQi(_disorderOfQi);
		int disorderOfQiFactor = delta - deltaOld;
		deltaOld = delta;
		delta += DomainManager.Building.GetBuildingBlockEffect(_location, EBuildingScaleEffect.HealthRecovery);
		int buildingFactor = delta - deltaOld;
		deltaOld = delta;
		int medicineEffectValue = GetTotalMedicineEffectValue(_eatingItems, EMedicineEffectSubType.RecoverHealthValue);
		delta += medicineEffectValue;
		medicineEffectValue = GetLeftMaxHealth() * GetTotalMedicineEffectValue(_eatingItems, EMedicineEffectSubType.RecoverHealthPercentage) / 100;
		delta += medicineEffectValue;
		int eatItemFactor = delta - deltaOld;
		deltaOld = delta;
		if (GetAgeGroup() == 0 && _leaderId < 0 && _location.IsValid())
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(_location);
			int num = delta;
			EMapBlockType blockType = blockData.BlockType;
			if (1 == 0)
			{
			}
			int num2 = blockType switch
			{
				EMapBlockType.City => 6, 
				EMapBlockType.Sect => 6, 
				EMapBlockType.Town => 6, 
				EMapBlockType.Station => 12, 
				EMapBlockType.Developed => 12, 
				EMapBlockType.Normal => 18, 
				_ => 24, 
			};
			if (1 == 0)
			{
			}
			delta = num - num2;
		}
		delta = DomainManager.SpecialEffect.ModifyValue(_id, 262, delta);
		int specialEffectFactor = delta - deltaOld;
		deltaOld = delta;
		if (delta > 0)
		{
			int percent = 100;
			foreach (short id in _featureIds)
			{
				percent += CharacterFeature.Instance[id].HealthRecovery;
			}
			delta = delta * percent / 100;
		}
		int featureFactor = delta - deltaOld;
		deltaOld = delta;
		return (total: (short)delta, disorderOfQiFactor: (short)disorderOfQiFactor, injuryFactor: (short)injuryFactor, poisonFactor: (short)poisonFactor, buildingFactor: (short)buildingFactor, eatItemFactor: (short)eatItemFactor, featureFactor: (short)featureFactor, specialEffectFactor: (short)specialEffectFactor);
	}

	public unsafe static int GetHealthChangeDueToInjuries(ref Injuries injuries)
	{
		int injuryLevel = 0;
		for (int i = 0; i < 14; i++)
		{
			injuryLevel += Math.Max(injuries.Items[i] / 2, 0);
		}
		return -injuryLevel * 12;
	}

	public unsafe static int GetHealthChangeDueToPoisons(ref PoisonInts poisoned, ref PoisonInts poisonResists)
	{
		int poisonedLevel = 0;
		for (int i = 0; i < 6; i++)
		{
			poisonedLevel += ((poisonResists.Items[i] < 1000) ? PoisonsAndLevels.CalcPoisonedLevel(poisoned.Items[i]) : 0);
		}
		return -poisonedLevel * 12;
	}

	public int GetHealthChangeDueToDisorderOfQi(short disorderOfQi)
	{
		sbyte qiDisorderEffect = DisorderLevelOfQi.GetDisorderLevelOfQiConfig(disorderOfQi).HealthRecovery;
		if (qiDisorderEffect > 0 && !DomainManager.SpecialEffect.ModifyData(_id, -1, 294, dataValue: true))
		{
			return 0;
		}
		return qiDisorderEffect;
	}

	public (short total, short buildingFactor, short recoveryFactor, short eatItemFactor, short featureFactor) GetChangeOfQiDisorder()
	{
		int delta = -GlobalConfig.Instance.RecoveryOfQiDisorderUnitValue;
		int deltaOld = delta;
		delta -= DomainManager.Building.GetBuildingBlockEffect(_location, EBuildingScaleEffect.QiDisorderRecovery);
		int buildingFactor = delta - deltaOld;
		deltaOld = delta;
		int percent = 100;
		int increase = 0;
		foreach (short featureId in _featureIds)
		{
			CharacterFeatureItem config = CharacterFeature.Instance[featureId];
			percent += config.QiDisorderBuffPercent;
			if (config.QiDisorderDelta > 0)
			{
				increase += config.QiDisorderDelta;
			}
			else
			{
				delta += config.QiDisorderDelta;
			}
		}
		delta = delta * percent / 100;
		int featureFactor = delta - deltaOld;
		deltaOld = delta;
		delta += delta * GetRecoveryOfQiDisorder() / 100;
		int recoveryFactor = delta - deltaOld - GlobalConfig.Instance.RecoveryOfQiDisorderUnitValue;
		deltaOld = delta;
		for (int i = 0; i < 9; i++)
		{
			ItemKey item = _eatingItems.Get(i);
			if (item.IsValid() && item.ItemType == 8)
			{
				MedicineItem config2 = item.GetConfigAs<MedicineItem>();
				if (config2.EffectType == EMedicineEffectType.ChangeDisorderOfQi)
				{
					delta += CalcMedicineEffectDelta_RecoverDisorderOfQi(config2.EffectValue, config2.EffectIsPercentage, item.Id);
				}
			}
		}
		int eatItemFactor = delta - deltaOld;
		deltaOld = delta;
		featureFactor += increase;
		delta = Math.Clamp(delta + increase, DisorderLevelOfQi.MinValue - DisorderLevelOfQi.MaxValue, DisorderLevelOfQi.MaxValue - DisorderLevelOfQi.MinValue);
		return (total: (short)delta, buildingFactor: (short)buildingFactor, recoveryFactor: (short)recoveryFactor, eatItemFactor: (short)eatItemFactor, featureFactor: (short)featureFactor);
	}

	private unsafe bool OfflineGetResourcesSupply(OrganizationMemberItem orgMemberCfg)
	{
		bool resourcesChanged = false;
		for (sbyte type = 0; type < 8; type++)
		{
			int satisfyingAmount = orgMemberCfg.GetAdjustedResourceSatisfyingAmount(type) * DomainManager.World.GetGainResourcePercent(12) / 100;
			int halfAmount = satisfyingAmount / 2;
			int gainAmount = satisfyingAmount / 40;
			int oriAmount = _resources.Items[type];
			if (oriAmount < halfAmount)
			{
				ref int reference = ref _resources.Items[type];
				reference += gainAmount;
				resourcesChanged = true;
			}
		}
		return resourcesChanged;
	}

	private void OfflineGetBookSupply(DataContext context, PeriAdvanceMonthGetSupplyModification mod)
	{
		HashSet<short> ownedBooks = context.AdvanceMonthRelatedData.TemplateIdSet.Occupy();
		foreach (var (itemKey2, _) in _inventory.Items)
		{
			if (itemKey2.ItemType == 10)
			{
				ownedBooks.Add(itemKey2.TemplateId);
			}
		}
		OfflineGetCombatSkillBookSupply(context, ownedBooks, mod);
		OfflineGetLifeSkillBookSupply(context, ownedBooks, mod);
		context.AdvanceMonthRelatedData.TemplateIdSet.Release(ref ownedBooks);
	}

	private unsafe void OfflineGetCombatSkillBookSupply(DataContext context, HashSet<short> ownedBooks, PeriAdvanceMonthGetSupplyModification mod)
	{
		if (!OrganizationDomain.IsSect(_organizationInfo.OrgTemplateId))
		{
			return;
		}
		List<TemplateKey> supplyBooks = context.AdvanceMonthRelatedData.ItemTemplateKeys.Occupy();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short templateId = key;
			GameData.Domains.CombatSkill.CombatSkill combatSkill = value;
			ushort readingState = combatSkill.GetReadingState();
			if (!combatSkill.GetRevoked() && CombatSkillStateHelper.CalcPagesToBeReadForActivation(readingState) > 0)
			{
				CombatSkillItem config = Config.CombatSkill.Instance[templateId];
				if (config.SectId == _organizationInfo.OrgTemplateId && config.BookId >= 0 && _organizationInfo.Grade >= config.Grade && !ownedBooks.Contains(config.BookId) && context.Random.CheckPercentProb(_combatSkillQualifications.Items[config.Type] / 5))
				{
					supplyBooks.Add(new TemplateKey(10, config.BookId));
				}
			}
		}
		if (supplyBooks.Count == 0)
		{
			context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref supplyBooks);
			return;
		}
		TemplateKey selectedBook = supplyBooks.GetRandom(context.Random);
		context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref supplyBooks);
		mod.AddItemToCreate(selectedBook.ItemType, selectedBook.TemplateId, 1);
	}

	private unsafe void OfflineGetLifeSkillBookSupply(DataContext context, HashSet<short> ownedBooks, PeriAdvanceMonthGetSupplyModification mod)
	{
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		List<TemplateKey> supplyBooks = context.AdvanceMonthRelatedData.ItemTemplateKeys.Occupy();
		foreach (LifeSkillItem learnedLifeSkill in _learnedLifeSkills)
		{
			if (!learnedLifeSkill.IsAllPagesRead())
			{
				Config.LifeSkillItem config = LifeSkill.Instance[learnedLifeSkill.SkillTemplateId];
				short adjust = orgMemberCfg.LifeSkillsAdjust[config.Type];
				if (adjust >= 6 && orgMemberCfg.LifeSkillGradeLimit >= config.Grade && !ownedBooks.Contains(config.SkillBookId) && config.SkillBookId >= 0 && context.Random.CheckPercentProb(_lifeSkillQualifications.Items[config.Type] / 5))
				{
					supplyBooks.Add(new TemplateKey(10, config.SkillBookId));
				}
			}
		}
		if (supplyBooks.Count == 0)
		{
			context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref supplyBooks);
			return;
		}
		TemplateKey selectedBook = supplyBooks.GetRandom(context.Random);
		context.AdvanceMonthRelatedData.ItemTemplateKeys.Release(ref supplyBooks);
		mod.AddItemToCreate(selectedBook.ItemType, selectedBook.TemplateId, 1);
	}

	private void OfflineGetItemSupply(DataContext context, PeriAdvanceMonthGetSupplyModification mod, int satisfyingThreshold, List<PresetInventoryItem> presetInventory)
	{
		if (GetInventoryTotalValue() > satisfyingThreshold)
		{
			return;
		}
		Dictionary<short, (sbyte, int)> itemSubTypeStats = context.AdvanceMonthRelatedData.ItemSubTypeStats.Get();
		foreach (PresetInventoryItem presetItem in presetInventory)
		{
			short itemSubType = ItemTemplateHelper.GetItemSubType(presetItem.Type, presetItem.TemplateId);
			sbyte expectedItemGrade = _organizationInfo.Grade;
			sbyte minItemGrade = (sbyte)Math.Max(0, expectedItemGrade - 3);
			if ((itemSubTypeStats.TryGetValue(itemSubType, out var stat) && stat.Item1 >= minItemGrade) || !context.Random.CheckPercentProb(presetItem.SpawnChance / 2))
			{
				continue;
			}
			short templateId = ItemTemplateHelper.GetTemplateIdInGroup(presetItem.Type, presetItem.TemplateId, expectedItemGrade);
			mod.PersonalNeedChanged = OfflineAddGoal(238, presetItem.Type, templateId) || mod.PersonalNeedChanged;
			break;
		}
	}

	private void OfflineGetEquipmentSupply(DataContext context, PeriAdvanceMonthGetSupplyModification mod, PresetEquipmentItemWithProb[] presetEquipments)
	{
		Dictionary<short, (sbyte, int)> itemSubTypeStats = context.AdvanceMonthRelatedData.ItemSubTypeStats.Get();
		sbyte expectedItemGrade = _organizationInfo.Grade;
		sbyte minItemGrade = (sbyte)Math.Max(0, expectedItemGrade - 3);
		for (int i = 0; i < presetEquipments.Length; i++)
		{
			PresetEquipmentItemWithProb presetEquipment = presetEquipments[i];
			if (presetEquipment.TemplateId >= 0)
			{
				short itemSubType = ItemTemplateHelper.GetItemSubType(presetEquipment.Type, presetEquipment.TemplateId);
				if ((!itemSubTypeStats.TryGetValue(itemSubType, out var stat) || stat.Item1 < minItemGrade) && context.Random.CheckPercentProb(presetEquipment.Prob / 2))
				{
					short itemTemplateId = ItemTemplateHelper.GetTemplateIdInGroup(presetEquipment.Type, presetEquipment.TemplateId, expectedItemGrade);
					mod.PersonalNeedChanged = OfflineAddGoal(238, presetEquipment.Type, itemTemplateId) || mod.PersonalNeedChanged;
					break;
				}
			}
		}
		ArraySegmentList<short> attackSkills = GetCombatSkillEquipment().Attack;
		ArraySegmentList<short>.Enumerator enumerator = attackSkills.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short combatSkillId = enumerator.Current;
			if (combatSkillId < 0)
			{
				continue;
			}
			CombatSkillItem config = Config.CombatSkill.Instance[combatSkillId];
			if (config.MostFittingWeaponID >= 0)
			{
				short randomItemSubtype = Config.Weapon.Instance[config.MostFittingWeaponID].ItemSubType;
				if (!itemSubTypeStats.TryGetValue(randomItemSubtype, out var stat2) || stat2.Item1 < minItemGrade)
				{
					short weaponTemplateId = ItemDomain.GenerateRandomItemTemplateId(context.Random, 0, config.MostFittingWeaponID, expectedItemGrade);
					mod.AddItemToCreate(0, weaponTemplateId, 1);
					break;
				}
			}
		}
	}

	private void OfflineGetClothingSupply(DataContext context, PeriAdvanceMonthGetSupplyModification mod, short clothingId)
	{
		ClothingItem clothing = Config.Clothing.Instance[clothingId];
		if (clothing != null)
		{
			Dictionary<short, (sbyte, int)> itemSubTypeStats = context.AdvanceMonthRelatedData.ItemSubTypeStats.Get();
			sbyte itemGrade = clothing.Grade;
			if ((!itemSubTypeStats.TryGetValue(clothing.ItemSubType, out var stat) || stat.Item1 < itemGrade) && context.Random.CheckPercentProb(30))
			{
				mod.AddItemToCreate(3, clothingId, 1);
			}
		}
	}

	private unsafe void OfflineRepairEquipments(DataContext context, PeriAdvanceMonthActivePreparationModification mod)
	{
		List<ItemKey> itemsToFix = ObjectPool<List<ItemKey>>.Instance.Get();
		List<ItemKey> tools = ObjectPool<List<ItemKey>>.Instance.Get();
		itemsToFix.Clear();
		tools.Clear();
		ItemKey[] equipment = _equipment;
		foreach (ItemKey equipment2 in equipment)
		{
			if (DomainManager.Item.CheckItemNeedRepair(equipment2))
			{
				itemsToFix.Add(equipment2);
			}
		}
		foreach (var (itemKey2, _) in _inventory.Items)
		{
			if (itemKey2.ItemType == 6)
			{
				ItemBase toolBaseItem = DomainManager.Item.GetBaseItem(itemKey2);
				if (toolBaseItem.GetCurrDurability() > 0)
				{
					tools.Add(itemKey2);
				}
			}
			else if (DomainManager.Item.CheckItemNeedRepair(itemKey2))
			{
				itemsToFix.Add(itemKey2);
			}
		}
		if (itemsToFix.Count > 0)
		{
			tools.Sort((ItemKey a, ItemKey b) => a.TemplateId.CompareTo(b.TemplateId));
			LifeSkillShorts lifeSkillAttainments = GetLifeSkillAttainments();
			foreach (ItemKey itemToFix in itemsToFix)
			{
				ItemBase itemObj = DomainManager.Item.GetBaseItem(itemToFix);
				short currDurability = itemObj.GetCurrDurability();
				short maxDurability = itemObj.GetMaxDurability();
				sbyte resourceType = itemObj.GetResourceType();
				sbyte lifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemToFix.ItemType, itemToFix.TemplateId);
				short attainmentRequired = ItemTemplateHelper.GetRepairRequiredAttainment(itemToFix.ItemType, itemToFix.TemplateId, currDurability);
				EquipmentBase equip = DomainManager.Item.GetBaseEquipment(itemToFix);
				ResourceInts resourceRequired = ItemTemplateHelper.GetRepairNeedResources(equip.GetMaterialResources(), itemToFix, currDurability);
				short charAttainment = lifeSkillAttainments.Items[lifeSkillType];
				int index = tools.FindIndex(delegate(ItemKey key)
				{
					CraftToolItem craftToolItem = Config.CraftTool.Instance[key.TemplateId];
					short num2 = craftToolItem.DurabilityCost[itemObj.GetGrade()];
					GameData.Domains.Item.CraftTool element_CraftTools = DomainManager.Item.GetElement_CraftTools(key.Id);
					return element_CraftTools.GetCurrDurability() >= num2 && charAttainment + craftToolItem.AttainmentBonus >= attainmentRequired && craftToolItem.RequiredLifeSkillTypes.Contains(lifeSkillType);
				});
				GameData.Domains.Item.CraftTool tool = ((index >= 0) ? DomainManager.Item.GetElement_CraftTools(tools[index].Id) : null);
				if (tool == null)
				{
					sbyte grade;
					for (grade = 0; grade <= _organizationInfo.Grade; grade++)
					{
						CraftToolItem currGradeCraftToolCfg = ItemTemplateHelper.GetGradeCraftTool(resourceType, grade);
						if (lifeSkillAttainments.Items[lifeSkillType] + currGradeCraftToolCfg.AttainmentBonus >= attainmentRequired)
						{
							OfflineAddGoal(238, (sbyte)6, currGradeCraftToolCfg.TemplateId);
							mod.PersonalNeedChanged = true;
							break;
						}
					}
					if (grade > _organizationInfo.Grade)
					{
						OfflineAddGoal(240, itemToFix.ItemType, itemToFix.Id);
						mod.PersonalNeedChanged = true;
					}
					continue;
				}
				if (!_resources.CheckIsMeet(ref resourceRequired))
				{
					for (int i2 = 0; i2 < 8; i2++)
					{
						int amount = resourceRequired.Items[i2];
						if (amount > 0)
						{
							OfflineAddGoal(236, resourceType, amount);
							mod.PersonalNeedChanged = true;
						}
					}
					continue;
				}
				CraftToolItem cfg = Config.CraftTool.Instance[tool.GetTemplateId()];
				short durabilityCost = cfg.DurabilityCost[itemObj.GetGrade()];
				ItemBase.OfflineRepairItem(tool, itemObj, itemObj.GetMaxDurability(), durabilityCost);
				_resources = _resources.Subtract(ref resourceRequired);
				mod.ResourcesChanged = true;
				PeriAdvanceMonthActivePreparationModification periAdvanceMonthActivePreparationModification = mod;
				if (periAdvanceMonthActivePreparationModification.ItemsFixed == null)
				{
					periAdvanceMonthActivePreparationModification.ItemsFixed = new List<ItemBase>();
				}
				mod.ItemsFixed.Add(itemObj);
				periAdvanceMonthActivePreparationModification = mod;
				if (periAdvanceMonthActivePreparationModification.CraftToolsUsed == null)
				{
					periAdvanceMonthActivePreparationModification.CraftToolsUsed = new HashSet<int>();
				}
				mod.CraftToolsUsed.Add(tool.GetId());
				if (tool.GetCurrDurability() <= 0)
				{
					tools.Remove(tool.GetItemKey());
				}
			}
		}
		ObjectPool<List<ItemKey>>.Instance.Return(itemsToFix);
		ObjectPool<List<ItemKey>>.Instance.Return(tools);
	}

	private void OfflineFeedAnimalCarrier(IRandomSource random, PeriAdvanceMonthActivePreparationModification mod)
	{
		int maxNeedTamePoint = 0;
		ItemKey equippedCarrierKey = _equipment[7];
		if (equippedCarrierKey.IsValid())
		{
			int needTamePoint = GetNeedTamePoint(equippedCarrierKey);
			if (needTamePoint > 0)
			{
				mod.FeedingCarrierKey = equippedCarrierKey;
				maxNeedTamePoint = needTamePoint;
			}
		}
		ItemKey key;
		int value;
		foreach (KeyValuePair<ItemKey, int> item in _inventory.Items)
		{
			item.Deconstruct(out key, out value);
			ItemKey itemKey = key;
			int needTamePoint2 = GetNeedTamePoint(itemKey);
			if (needTamePoint2 > maxNeedTamePoint)
			{
				maxNeedTamePoint = needTamePoint2;
				mod.FeedingCarrierKey = itemKey;
			}
		}
		if (!mod.FeedingCarrierKey.IsValid())
		{
			return;
		}
		int bestFeedTamePoint = -128;
		foreach (KeyValuePair<ItemKey, int> item2 in _inventory.Items)
		{
			item2.Deconstruct(out key, out value);
			ItemKey itemKey2 = key;
			int feedTamePoint = GetFeedTamePoint(mod.FeedingCarrierKey, itemKey2);
			if (feedTamePoint > 0 && Math.Abs(bestFeedTamePoint - maxNeedTamePoint) >= Math.Abs(feedTamePoint - maxNeedTamePoint))
			{
				bestFeedTamePoint = feedTamePoint;
				mod.FeedingFoodKey = itemKey2;
			}
		}
		if (!mod.FeedingFoodKey.IsValid())
		{
			CarrierItem carrierCfg = Config.Carrier.Instance[mod.FeedingCarrierKey.TemplateId];
			if (carrierCfg.LoveFoodType.CheckIndex(0))
			{
				short lovingType = carrierCfg.LoveFoodType.GetRandom(random);
				mod.PersonalNeedChanged = OfflineAddGoal(238, (sbyte)5, lovingType) || mod.PersonalNeedChanged;
			}
		}
		static int GetFeedTamePoint(ItemKey carrierKey, ItemKey foodKey)
		{
			if (!ItemTemplateHelper.IsFeedingAble(foodKey.ItemType, foodKey.TemplateId))
			{
				return 0;
			}
			return GameData.Domains.Extra.SharedMethods.GetFoodAddCarrierTamePoint(carrierKey.TemplateId, foodKey.TemplateId);
		}
		static int GetNeedTamePoint(ItemKey itemKey3)
		{
			if (!ItemTemplateHelper.HasCarrierTame(itemKey3.ItemType, itemKey3.TemplateId))
			{
				return 0;
			}
			int tamePoint = DomainManager.Extra.GetCarrierTamePoint(itemKey3.Id);
			if (tamePoint < 0)
			{
				return 0;
			}
			int maxTamePoint = DomainManager.Extra.GetCarrierMaxTamePoint(itemKey3.Id);
			if (tamePoint >= maxTamePoint)
			{
				return 0;
			}
			return maxTamePoint - tamePoint;
		}
	}

	private unsafe void OfflineAddPoisonToEquipments(DataContext context, PeriAdvanceMonthActivePreparationModification mod, ItemKey[] equipments = null)
	{
		if (!Config.Organization.Instance[_organizationInfo.OrgTemplateId].AllowPoisoning)
		{
			return;
		}
		sbyte behaviorType = GetBehaviorType();
		bool* primaryPoisonTypes = stackalloc bool[6];
		GetAttackSkillPoisonTypes(primaryPoisonTypes);
		bool hasAttackSkillWithPoison = false;
		for (int i = 0; i < 6; i++)
		{
			if (primaryPoisonTypes[i])
			{
				hasAttackSkillWithPoison = true;
				break;
			}
		}
		if (!hasAttackSkillWithPoison)
		{
			return;
		}
		int chance = 10 + AiHelper.ActivePreparationConstants.AddPoisonBonusChance[behaviorType];
		foreach (CharacterGoalData personalNeed in GetGoals())
		{
			if (personalNeed.GoalTemplateId == 241 && primaryPoisonTypes[personalNeed.Args.PoisonType])
			{
				chance = 100;
			}
		}
		short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, 9, -1);
		if (!context.Random.CheckPercentProb(chance + rateAdjust))
		{
			return;
		}
		short toxicologyAttainment = GetLifeSkillAttainment(9);
		ItemKey* poisonItemKeys = stackalloc ItemKey[6];
		byte* intPtr = stackalloc byte[6];
		// IL initblk instruction
		Unsafe.InitBlock(intPtr, 255, 6);
		sbyte* grades = (sbyte*)intPtr;
		int primaryPoisonCount = 0;
		int secondaryPoisonCount = 0;
		foreach (var (itemKey2, _) in _inventory.Items)
		{
			if (itemKey2.ItemType != 8)
			{
				continue;
			}
			MedicineItem medicineCfg = Config.Medicine.Instance[itemKey2.TemplateId];
			if (medicineCfg.EffectType != EMedicineEffectType.ApplyPoison)
			{
				continue;
			}
			sbyte poisonType = medicineCfg.PoisonType;
			short attainmentRequired = GlobalConfig.Instance.PoisonAttainments[medicineCfg.Grade];
			if (toxicologyAttainment < attainmentRequired || medicineCfg.Grade <= grades[poisonType])
			{
				continue;
			}
			if (grades[poisonType] < 0)
			{
				if (primaryPoisonTypes[poisonType])
				{
					primaryPoisonCount++;
				}
				else
				{
					secondaryPoisonCount++;
				}
			}
			poisonItemKeys[poisonType] = itemKey2;
			grades[poisonType] = medicineCfg.Grade;
		}
		if (primaryPoisonCount == 0)
		{
			(ItemKey, sbyte level, short value) leastPoisonedEquippedWeaponOrArmor = GetLeastPoisonedEquippedWeaponOrArmor();
			ItemKey leastPoisonedKey = leastPoisonedEquippedWeaponOrArmor.Item1;
			sbyte level = leastPoisonedEquippedWeaponOrArmor.level;
			short value = leastPoisonedEquippedWeaponOrArmor.value;
			sbyte charGradePoisonLevel = AiHelper.ActivePreparationConstants.GradePoisonLevel[_organizationInfo.Grade];
			short charGradePoisonValue = AiHelper.ActivePreparationConstants.GradePoisonValue[_organizationInfo.Grade];
			if (charGradePoisonLevel <= level && (charGradePoisonLevel != level || charGradePoisonValue <= value))
			{
				return;
			}
			for (sbyte poisonType2 = 0; poisonType2 < 6; poisonType2++)
			{
				if (primaryPoisonTypes[poisonType2])
				{
					OfflineAddGoal(241, poisonType2);
					mod.PersonalNeedChanged = true;
				}
			}
			return;
		}
		int totalPoisonCount = primaryPoisonCount + secondaryPoisonCount;
		ItemKey* sortedPoisons = stackalloc ItemKey[totalPoisonCount];
		int primaryPoisonIndex = 0;
		int secondaryPoisonIndex = primaryPoisonCount;
		for (sbyte poisonType3 = 0; poisonType3 < 6; poisonType3++)
		{
			if (grades[poisonType3] >= 0)
			{
				ItemKey itemKey3 = poisonItemKeys[poisonType3];
				if (primaryPoisonTypes[poisonType3])
				{
					sortedPoisons[primaryPoisonIndex] = itemKey3;
					primaryPoisonIndex++;
				}
				else
				{
					sortedPoisons[secondaryPoisonIndex] = itemKey3;
					secondaryPoisonIndex++;
				}
				Tester.Assert(itemKey3.ItemType == 8);
			}
		}
		Tester.Assert(primaryPoisonIndex == primaryPoisonCount);
		Tester.Assert(secondaryPoisonIndex == totalPoisonCount);
		if (primaryPoisonCount > 0)
		{
			CollectionUtils.Shuffle(context.Random, sortedPoisons, primaryPoisonCount);
		}
		if (secondaryPoisonCount > 0)
		{
			CollectionUtils.Shuffle(context.Random, sortedPoisons + primaryPoisonCount, secondaryPoisonCount);
		}
		sbyte* weapons = stackalloc sbyte[3] { 0, 1, 2 };
		(mod.EquipmentSlotToAddPoison, mod.PoisonsToUse) = SelectEquipmentSlotAndPoisonsToAdd(context.Random, sortedPoisons, totalPoisonCount, weapons, 3, equipments);
		if (mod.EquipmentSlotToAddPoison < 0)
		{
			sbyte* armor = stackalloc sbyte[4] { 3, 5, 6, 7 };
			(mod.EquipmentSlotToAddPoison, mod.PoisonsToUse) = SelectEquipmentSlotAndPoisonsToAdd(context.Random, sortedPoisons, totalPoisonCount, armor, 4, equipments);
			if (mod.EquipmentSlotToAddPoison < 0)
			{
				sbyte* accessories = stackalloc sbyte[3] { 8, 9, 10 };
				(mod.EquipmentSlotToAddPoison, mod.PoisonsToUse) = SelectEquipmentSlotAndPoisonsToAdd(context.Random, sortedPoisons, totalPoisonCount, accessories, 3, equipments);
			}
		}
	}

	private unsafe (ItemKey, sbyte level, short value) GetLeastPoisonedEquippedWeaponOrArmor()
	{
		sbyte* slots = stackalloc sbyte[7] { 0, 1, 2, 3, 5, 6, 7 };
		ItemKey leastPoisonedItemKey = ItemKey.Invalid;
		sbyte minPoisonLevel = 3;
		short minPoisonValue = short.MaxValue;
		for (int i = 0; i < 7; i++)
		{
			sbyte slotIndex = slots[i];
			ItemKey itemKey = _equipment[slotIndex];
			if (!itemKey.IsValid())
			{
				continue;
			}
			if (!ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
			{
				return (itemKey, level: 0, value: 0);
			}
			sbyte currPoisonLevel = 0;
			short currPoisonValue = 0;
			PoisonsAndLevels prevAttachedPoison = DomainManager.Item.GetAttachedPoisons(itemKey);
			for (sbyte poisonType = 0; poisonType < 6; poisonType++)
			{
				if (prevAttachedPoison.Levels[poisonType] > 0)
				{
					currPoisonLevel = prevAttachedPoison.Levels[poisonType];
					currPoisonValue = prevAttachedPoison.Values[poisonType];
					break;
				}
			}
			if (currPoisonLevel <= minPoisonLevel && (currPoisonLevel != minPoisonLevel || currPoisonValue <= minPoisonValue))
			{
				leastPoisonedItemKey = itemKey;
				minPoisonLevel = currPoisonLevel;
				minPoisonValue = currPoisonValue;
			}
		}
		return (leastPoisonedItemKey, level: minPoisonLevel, value: minPoisonValue);
	}

	public unsafe void GetAttackSkillPoisonTypes(bool* poisonTypes)
	{
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			poisonTypes[poisonType] = false;
		}
		ArraySegmentList<short> attackSkills = GetCombatSkillEquipment().Attack;
		ArraySegmentList<short>.Enumerator enumerator = attackSkills.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillTemplateId = enumerator.Current;
			if (skillTemplateId < 0)
			{
				continue;
			}
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
			if (!skillConfig.Poisons.IsNonZero())
			{
				continue;
			}
			for (sbyte poisonType2 = 0; poisonType2 < 6; poisonType2++)
			{
				if (skillConfig.Poisons.Values[poisonType2] > 0)
				{
					poisonTypes[poisonType2] = true;
				}
			}
		}
	}

	public unsafe sbyte SelectEquipmentInArrayToAddPoisonOn(IRandomSource random, MedicineItem poisonConfig, sbyte* equipmentArr, int length, ItemKey[] equipments = null)
	{
		if (equipments == null)
		{
			equipments = _equipment;
		}
		CollectionUtils.Shuffle(random, equipmentArr, length);
		for (int i = 0; i < length; i++)
		{
			sbyte slotIndex = equipmentArr[i];
			ItemKey equipmentKey = equipments[slotIndex];
			if (equipmentKey.IsValid() && ItemTemplateHelper.IsPoisonable(equipmentKey.ItemType, equipmentKey.TemplateId))
			{
				EquipmentBase equipmentObj = DomainManager.Item.GetBaseEquipment(equipmentKey);
				byte modificationState = equipmentObj.GetModificationState();
				if (!ModificationStateHelper.IsActive(modificationState, 1))
				{
					return slotIndex;
				}
			}
		}
		return -1;
	}

	private unsafe (sbyte, ItemKey[]) SelectEquipmentSlotAndPoisonsToAdd(IRandomSource random, ItemKey* poisonArr, int poisonLength, sbyte* equipSlotArr, int equipSlotLength, ItemKey[] equipments = null)
	{
		if (equipments == null)
		{
			equipments = _equipment;
		}
		Span<ItemKey> span = stackalloc ItemKey[3];
		SpanList<ItemKey> addedPoisons = span;
		CollectionUtils.Shuffle(random, equipSlotArr, equipSlotLength);
		for (int i = 0; i < equipSlotLength; i++)
		{
			sbyte slotIndex = equipSlotArr[i];
			ItemKey equipmentKey = equipments[slotIndex];
			if (!equipmentKey.IsValid() || !ItemTemplateHelper.IsPoisonable(equipmentKey.ItemType, equipmentKey.TemplateId))
			{
				continue;
			}
			EquipmentBase equipmentObj = DomainManager.Item.GetBaseEquipment(equipmentKey);
			byte modificationState = equipmentObj.GetModificationState();
			if (ModificationStateHelper.IsActive(modificationState, 1))
			{
				FullPoisonEffects prevAttachedPoison = DomainManager.Item.GetPoisonEffects(equipmentKey);
				PoisonsAndLevels poisonsAndLevels = prevAttachedPoison.GetAllPoisonsAndLevels();
				int prevPoisonCount = (prevAttachedPoison.IsTwoPoisonsMix() ? 2 : ((!prevAttachedPoison.IsThreePoisonsMix()) ? 1 : 3));
				if (prevPoisonCount >= 3)
				{
					continue;
				}
				for (int j = 0; j < poisonLength; j++)
				{
					ItemKey poisonItemKey = poisonArr[j];
					MedicineItem poisonCfg = Config.Medicine.Instance[poisonItemKey.TemplateId];
					sbyte poisonType = poisonCfg.PoisonType;
					sbyte level = poisonsAndLevels.Levels[poisonType];
					short value = poisonsAndLevels.Values[poisonType];
					if (value <= 0 && (level < poisonCfg.EffectThresholdValue || (level == poisonCfg.EffectThresholdValue && value < poisonCfg.EffectValue)))
					{
						addedPoisons.Add(poisonItemKey);
						if (addedPoisons.Count + prevPoisonCount >= 3)
						{
							break;
						}
					}
				}
				if (addedPoisons.Count > 0)
				{
					return (slotIndex, addedPoisons.ToArray());
				}
				continue;
			}
			if (random.CheckPercentProb(GetPersonality(1)))
			{
				for (int k = 0; k < poisonLength; k++)
				{
					ItemKey poisonItemKey2 = poisonArr[k];
					int amount = _inventory.Items[poisonItemKey2];
					if (amount >= 3)
					{
						addedPoisons.Add(poisonArr[k]);
						addedPoisons.Add(poisonArr[k]);
						addedPoisons.Add(poisonArr[k]);
						return (slotIndex, addedPoisons.ToArray());
					}
				}
			}
			int count = Math.Min(poisonLength, 3);
			for (int l = 0; l < count; l++)
			{
				addedPoisons.Add(poisonArr[l]);
			}
			return (slotIndex, addedPoisons.ToArray());
		}
		return (-1, null);
	}

	private int PoisonCompare(ItemKey itemKeyA, ItemKey itemKeyB)
	{
		return Config.Medicine.Instance[itemKeyA.TemplateId].Grade.CompareTo(Config.Medicine.Instance[itemKeyB.TemplateId].Grade);
	}

	private unsafe void OfflineLoseResources(PeriAdvanceMonthUpdateStatusModification mod)
	{
		int maxAmount = DomainManager.Taiwu.GetMaterialResourceMaxCount();
		for (sbyte type = 0; type < 6; type++)
		{
			int oriAmount = _resources.Items[type];
			if (oriAmount > maxAmount)
			{
				int lostAmount = Math.Max((oriAmount - maxAmount) / 2, 1);
				_resources.Items[type] = oriAmount - lostAmount;
				mod.ResourcesChanged = true;
			}
		}
	}

	private int OfflineLoseOverloadedItems(DataContext context, PeriAdvanceMonthLoseOverloadItemsModification mod)
	{
		int overloadedWeight = GetCurrInventoryLoad() - GetMaxInventoryLoad();
		if (overloadedWeight <= 0)
		{
			return 0;
		}
		Location charLocation = (_location.IsValid() ? _location : GetValidLocation());
		List<MapBlockData> nearbyBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(charLocation.AreaId, charLocation.BlockId, nearbyBlocks, 2, includeCenter: true);
		List<(ItemBase, int)> itemsToBeLost = context.AdvanceMonthRelatedData.ItemsWithAmount.Occupy();
		CharacterDomain.GetLostItemsDueToOverload(context, overloadedWeight, _inventory.Items, itemsToBeLost, _id == DomainManager.Taiwu.GetTaiwuCharId());
		mod.ItemsToBeLost = new List<(MapBlockData, ItemKey, int)>();
		int decreasedHappiness = 0;
		foreach (var item2 in itemsToBeLost)
		{
			ItemBase item = item2.Item1;
			int amount = item2.Item2;
			ItemKey itemKey = item.GetItemKey();
			_inventory.OfflineRemove(itemKey, amount);
			MapBlockData block = nearbyBlocks.GetRandom(context.Random);
			mod.ItemsToBeLost.Add((block, itemKey, amount));
			decreasedHappiness += item.GetHappinessChange() * amount;
		}
		context.AdvanceMonthRelatedData.ItemsWithAmount.Release(ref itemsToBeLost);
		ObjectPool<List<MapBlockData>>.Instance.Return(nearbyBlocks);
		return -decreasedHappiness;
	}

	private void ApplyBookReadingResult(DataContext context, GameData.Domains.Item.SkillBook book, int learnedSkillIndex, byte readingPage, sbyte succeedPageCount)
	{
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		ItemKey bookItemKey = book.GetItemKey();
		TryApplyAttachedPoison(context, bookItemKey);
		book.ChangeCurrDurability(context, -1);
		if (book.GetCurrDurability() <= 0)
		{
			RemoveInventoryItem(context, bookItemKey, 1, deleteItem: true);
			AddGoal(context, 238, (sbyte)10, book.GetTemplateId());
		}
		if (succeedPageCount > 0)
		{
			SetExp(_exp, context);
			byte nextPage;
			if (book.IsCombatSkillBook())
			{
				short combatSkillTemplateId = book.GetCombatSkillTemplateId();
				byte pageTypes = book.GetPageTypes();
				if (learnedSkillIndex < 0)
				{
					learnedSkillIndex = _learnedCombatSkills.Count;
					byte internalIndex = CombatSkillStateHelper.GetPageInternalIndex(SkillBookStateHelper.GetOutlinePageType(pageTypes), SkillBookStateHelper.GetNormalPageType(pageTypes, readingPage), readingPage);
					LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)internalIndex));
					readingPage++;
					succeedPageCount--;
				}
				GameData.Domains.CombatSkill.CombatSkill skillItem = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_id, combatSkillTemplateId));
				while (succeedPageCount > 0 && readingPage < 6)
				{
					byte internalIndex2 = CombatSkillStateHelper.GetPageInternalIndex(SkillBookStateHelper.GetOutlinePageType(pageTypes), SkillBookStateHelper.GetNormalPageType(pageTypes, readingPage), readingPage);
					DomainManager.CombatSkill.SetCombatSkillReadingState(context, skillItem, CombatSkillStateHelper.SetPageRead(skillItem.GetReadingState(), internalIndex2));
					DomainManager.CombatSkill.TryActivateCombatSkillBookPageWhenSetReadingState(context, _id, combatSkillTemplateId, internalIndex2);
					readingPage++;
					succeedPageCount--;
				}
				nextPage = GetCombatSkillBookCurrReadingInfo(book).readingPage;
			}
			else
			{
				short lifeSkillTemplateId = book.GetLifeSkillTemplateId();
				if (learnedSkillIndex < 0)
				{
					learnedSkillIndex = _learnedLifeSkills.Count;
					LearnNewLifeSkill(context, lifeSkillTemplateId, (byte)(1 << (int)readingPage));
					readingPage++;
					succeedPageCount--;
				}
				while (succeedPageCount > 0 && readingPage < 5)
				{
					ReadLifeSkillPage(context, learnedSkillIndex, readingPage);
					readingPage++;
					succeedPageCount--;
				}
				nextPage = GetLifeSkillBookCurrReadingInfo(book).readingPage;
			}
			if (nextPage < book.GetPageCount() && SkillBookStateHelper.GetPageIncompleteState(book.GetPageIncompleteState(), nextPage) == 2)
			{
				AddGoal(context, 244, book.GetItemType(), book.GetId());
			}
		}
		else
		{
			short attainmentRequirement = SkillGradeData.Instance[book.GetGrade()].ReadingAttainmentRequirement;
			if (book.IsCombatSkillBook())
			{
				AddGoal(context, 246, book.GetCombatSkillType(), (int)attainmentRequirement);
			}
			else
			{
				AddGoal(context, 247, book.GetLifeSkillType(), (int)attainmentRequirement);
			}
			AddGoal(context, 244, book.GetItemType(), book.GetId());
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddReadBookFail(_id, (ulong)bookItemKey);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
	}

	private sbyte OfflineUpdateReadingProgress(GameData.Domains.Item.SkillBook book, byte readingPage)
	{
		sbyte lifeSkillType = book.GetLifeSkillType();
		sbyte combatSkillType = book.GetCombatSkillType();
		short attainment = ((lifeSkillType >= 0) ? GetLifeSkillAttainment(lifeSkillType) : GetCombatSkillAttainment(combatSkillType));
		sbyte cleverness = GetPersonality(1);
		byte currPage = readingPage;
		byte pageCount = book.GetPageCount();
		int totalPoints = GetTotalReadingPoint(book.GetGrade(), attainment, cleverness);
		if (_organizationInfo.SettlementId >= 0 && OrganizationDomain.IsSect(_organizationInfo.OrgTemplateId))
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
			totalPoints = totalPoints * settlement.GetMemberSelfImproveSpeedFactor() / 100;
		}
		if (DomainManager.Building.IsCharacterParticipantFeast(_id, out var feast))
		{
			FeastItem config = Config.Feast.Instance[feast.Item1];
			int percent = ((lifeSkillType >= 0) ? config.ReadLifeSkillBook : config.ReadCombatSkillBook);
			totalPoints += totalPoints * percent / 100 * feast.Item2 / 100;
		}
		if (DomainManager.SpecialEffect.ModifyData(_id, -1, 259, dataValue: true))
		{
			while (currPage < pageCount)
			{
				sbyte incompleteState = SkillBookStateHelper.GetPageIncompleteState(book.GetPageIncompleteState(), readingPage);
				sbyte pointCost = SkillBookPageIncompleteState.ReadingPointCost[incompleteState];
				if (pointCost > totalPoints)
				{
					break;
				}
				totalPoints -= pointCost;
				currPage++;
			}
		}
		sbyte succeedPageCount = (sbyte)(currPage - readingPage);
		if (succeedPageCount > 0)
		{
			_exp += SkillGradeData.Instance[book.GetGrade()].ReadingExpGainPerPage * succeedPageCount;
		}
		return succeedPageCount;
	}

	public (int learnedSkillIndex, byte readingPage) GetCombatSkillBookCurrReadingInfo(GameData.Domains.Item.SkillBook book)
	{
		short combatSkillTemplateId = book.GetCombatSkillTemplateId();
		int learnedCombatSkillIndex = _learnedCombatSkills.IndexOf(combatSkillTemplateId);
		if (learnedCombatSkillIndex < 0)
		{
			return (learnedSkillIndex: learnedCombatSkillIndex, readingPage: 0);
		}
		CombatSkillKey combatSkillKey = new CombatSkillKey(_id, _learnedCombatSkills[learnedCombatSkillIndex]);
		GameData.Domains.CombatSkill.CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(combatSkillKey);
		byte pageTypes = book.GetPageTypes();
		sbyte behaviorType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
		ushort readingState = combatSkill.GetReadingState();
		for (byte readingPage = 0; readingPage < 6; readingPage++)
		{
			byte pageInternalIndex = CombatSkillStateHelper.GetPageInternalIndex(behaviorType, SkillBookStateHelper.GetNormalPageType(pageTypes, readingPage), readingPage);
			if (!CombatSkillStateHelper.IsPageRead(readingState, pageInternalIndex))
			{
				return (learnedSkillIndex: learnedCombatSkillIndex, readingPage: readingPage);
			}
		}
		return (learnedSkillIndex: learnedCombatSkillIndex, readingPage: 6);
	}

	public (int learnedSkillIndex, byte readingPage) GetLifeSkillBookCurrReadingInfo(GameData.Domains.Item.SkillBook book)
	{
		short lifeSkillTemplateId = book.GetLifeSkillTemplateId();
		int learnedLifeSkillIndex = FindLearnedLifeSkillIndex(lifeSkillTemplateId);
		if (learnedLifeSkillIndex < 0)
		{
			return (learnedSkillIndex: learnedLifeSkillIndex, readingPage: 0);
		}
		LifeSkillItem lifeSkill = _learnedLifeSkills[learnedLifeSkillIndex];
		for (byte readingPage = 0; readingPage < 5; readingPage++)
		{
			if (!lifeSkill.IsPageRead(readingPage))
			{
				return (learnedSkillIndex: learnedLifeSkillIndex, readingPage: readingPage);
			}
		}
		return (learnedSkillIndex: learnedLifeSkillIndex, readingPage: 5);
	}

	public static int GetTaughtNewSkillSuccessRate(sbyte grade, short qualification, short attainment, sbyte cleverness)
	{
		SkillGradeDataItem gradeDataCfg = SkillGradeData.Instance[grade];
		if (attainment > gradeDataCfg.ReadingAttainmentRequirement)
		{
			return 100;
		}
		if (qualification > gradeDataCfg.PracticeQualificationRequirement)
		{
			return 100;
		}
		return Math.Max((cleverness + attainment * 100 / gradeDataCfg.ReadingAttainmentRequirement) / 2, (cleverness + qualification * 100 / gradeDataCfg.PracticeQualificationRequirement) / 4);
	}

	public static int GetReadingSuccessRate(sbyte grade, sbyte incompleteState, short attainment, sbyte cleverness)
	{
		short needAttainment = SkillGradeData.Instance[grade].ReadingAttainmentRequirement;
		sbyte baseSuccessRate = SkillBookPageIncompleteState.BaseReadingSuccessRate[incompleteState];
		if (attainment >= needAttainment)
		{
			return baseSuccessRate;
		}
		return baseSuccessRate * (cleverness + attainment * 100 / needAttainment) / 200;
	}

	private static int GetTotalReadingPoint(sbyte grade, short attainment, sbyte cleverness)
	{
		short needAttainment = SkillGradeData.Instance[grade].ReadingAttainmentRequirement;
		return 100 + (100 + cleverness) * attainment / needAttainment / 2;
	}

	private bool OfflineUpdatePregnantState(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (!_featureIds.Contains(198) || DomainManager.Character.TryGetElement_CrossAreaMoveInfos((_leaderId >= 0) ? _leaderId : _id, out var _))
		{
			return true;
		}
		mod.PregnantStateModification = new PregnantStateModification();
		DomainManager.Character.ParallelUpdatePregnantState(context, this, mod.PregnantStateModification);
		if (mod.PregnantStateModification.State == PregnantStateModification.ChildState.AliveHuman)
		{
			DomainManager.Character.ParallelCreateNewbornChildren(context, this, mod.PregnantStateModification.Dystocia, mod.PregnantStateModification.LostMother);
		}
		else if (mod.PregnantStateModification.State == PregnantStateModification.ChildState.Dead)
		{
			sbyte happinessChange = AiHelper.UpdateStatusConstants.LostChildHappinessChange[GetBehaviorType()];
			_happiness = (sbyte)Math.Clamp(_happiness + happinessChange, -119, 119);
			_health += -72;
			mod.HappinessChanged = true;
		}
		if (mod.PregnantStateModification.State != PregnantStateModification.ChildState.Invalid)
		{
			_featureIds.Remove(198);
			mod.FeaturesChanged = true;
			mod.PersonalNeedsChanged = true;
		}
		if (!mod.PregnantStateModification.LostMother)
		{
			return true;
		}
		_health = 0;
		return false;
	}

	private sbyte GetXiangshuInfectionDelta()
	{
		int delta = DomainManager.SpecialEffect.ModifyValue(_id, 261, 0);
		if (!CanBeXiangshuInfected())
		{
			return (sbyte)Math.Clamp(delta, -128, 127);
		}
		int num = delta;
		sbyte happinessType = HappinessType.GetHappinessType(_happiness);
		if (1 == 0)
		{
		}
		int num2 = happinessType switch
		{
			0 => GlobalConfig.Instance.XiangshuInfectionAddSpeed[0], 
			1 => GlobalConfig.Instance.XiangshuInfectionAddSpeed[1], 
			2 => GlobalConfig.Instance.XiangshuInfectionAddSpeed[2], 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		delta = num + num2;
		foreach (short featureId in _featureIds)
		{
			if (!IgnoreFeature(featureId))
			{
				CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId];
				delta += featureCfg.XiangshuInfectionChange;
			}
		}
		if (delta > 127)
		{
			delta = 127;
		}
		return (sbyte)delta;
	}

	private void OfflineUpdateEatingItems(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (_eatingItems.UpdateDurations(context.AdvanceMonthRelatedData.WorldItemsToBeRemoved, ref mod.RemovedWugs, ref mod.RemovedWugKings))
		{
			mod.EatingItemsChanged = true;
		}
		OfflineUpdateWugKings(context, mod);
	}

	private void OfflineUpdateWugKings(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		List<ItemKey> removedWugKings = mod.RemovedWugKings;
		if (removedWugKings == null || removedWugKings.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < mod.RemovedWugKings.Count; i++)
		{
			if (ChangeFeatureByWugKing(context.Random))
			{
				mod.FeaturesChanged = true;
				continue;
			}
			if (mod.RemovedSafetyWugKings == null)
			{
				mod.RemovedSafetyWugKings = new List<ItemKey>();
			}
			mod.RemovedSafetyWugKings.Add(mod.RemovedWugKings[i]);
		}
		if (mod.RemovedSafetyWugKings == null)
		{
			return;
		}
		foreach (ItemKey removedSafetyWugKing in mod.RemovedSafetyWugKings)
		{
			mod.RemovedWugKings.Remove(removedSafetyWugKing);
		}
	}

	private unsafe void OfflineUpdateEatingItemEffect(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)_eatingItems.ItemKeys[i];
			if (!itemKey.IsValid())
			{
				continue;
			}
			short duration = _eatingItems.Durations[i];
			short maxDuration = ItemTemplateHelper.GetEatableItemDuration(itemKey.ItemType, itemKey.TemplateId);
			if (ModificationStateHelper.IsActive(itemKey.ModificationState, 1))
			{
				if (!DomainManager.Item.PoisonEffects.TryGetValue(itemKey.Id, out var poisonEffects))
				{
					continue;
				}
				PoisonsAndLevels poisons = poisonEffects.GetAllPoisonsAndLevels();
				short medicineTemplateId = poisonEffects.GetMedicineTemplateId();
				if (medicineTemplateId >= 0)
				{
					maxDuration += Config.Medicine.Instance[medicineTemplateId].Duration;
					for (sbyte type = 0; type < 6; type++)
					{
						int delta = PoisonsAndLevels.CalcApplyItemPoisonAmount(poisons.Values[type], poisons.Levels[type]) / 2 * duration / maxDuration;
						poisons.Values[type] = (short)delta;
					}
					OfflineChangePoisoned(ref poisons);
					mod.PoisonedChanged = true;
					if (IsTaiwu())
					{
						DomainManager.Global.InvokeGuidingTrigger(context, 270);
					}
				}
			}
			else
			{
				if (itemKey.ItemType != 8)
				{
					continue;
				}
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				MedicineEatingInstantEffect effect = new MedicineEatingInstantEffect(medicineCfg);
				switch (medicineCfg.EffectType)
				{
				case EMedicineEffectType.RecoverOuterInjury:
					CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: false, ref effect, itemKey.Id);
					mod.InjuriesChanged = true;
					break;
				case EMedicineEffectType.RecoverInnerInjury:
					CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: true, ref effect, itemKey.Id);
					mod.InjuriesChanged = true;
					break;
				case EMedicineEffectType.ApplyPoison:
				{
					sbyte poisonType2 = medicineCfg.PoisonType;
					sbyte poisonLevel2 = (sbyte)medicineCfg.EffectThresholdValue;
					int delta3 = PoisonsAndLevels.CalcApplyItemPoisonAmount(medicineCfg.EffectValue, poisonLevel2) / 2 * duration / maxDuration;
					if (OfflineChangePoisoned(poisonType2, poisonLevel2, delta3))
					{
						mod.PoisonedChanged = true;
					}
					break;
				}
				case EMedicineEffectType.DetoxPoison:
				{
					sbyte poisonType = effect.PoisonType;
					sbyte poisonLevel = (sbyte)effect.EffectThresholdValue;
					int poisonValue = GetPoisoned().Items[poisonType];
					if (poisonLevel >= PoisonsAndLevels.CalcPoisonedLevel(poisonValue))
					{
						int delta2 = -CalcMedicineEffectDelta(poisonValue, effect.EffectValue, effect.EffectIsPercentage, itemKey.Id);
						if (OfflineChangePoisoned(poisonType, poisonLevel, delta2))
						{
							mod.PoisonedChanged = true;
						}
					}
					break;
				}
				}
			}
		}
	}

	private void OfflineUpdateFeaturePoisons(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (!_featureIds.Contains(383))
		{
			return;
		}
		int prob = DomainManager.Extra.GetKongsangCharacterFeaturePoisonedProb();
		if (prob < GlobalConfig.Instance.KongsangCharacterFeaturePoisonedProbParm[0])
		{
			prob = GlobalConfig.Instance.KongsangCharacterFeaturePoisonedProbParm[0];
		}
		if (context.Random.CheckPercentProb(prob))
		{
			MedicineItem config = Config.Medicine.Instance[(short)51];
			sbyte poisonLevel = (sbyte)config.EffectThresholdValue;
			short delta = PoisonsAndLevels.CalcApplyItemPoisonAmount(config.EffectValue, poisonLevel);
			sbyte poisonType1 = (sbyte)context.Random.Next(6);
			int range = context.Random.Next(1, 3);
			sbyte poisonType2 = (sbyte)(poisonType1 + range);
			if (poisonType2 >= 6)
			{
				poisonType2 -= 6;
			}
			sbyte poisonType3 = (sbyte)(poisonType2 + range);
			if (poisonType3 >= 6)
			{
				poisonType3 -= 6;
			}
			bool poison1Change = OfflineChangePoisoned(poisonType1, poisonLevel, delta);
			bool poison2Change = OfflineChangePoisoned(poisonType2, poisonLevel, delta);
			bool poison3Change = OfflineChangePoisoned(poisonType3, poisonLevel, delta);
			if (poison1Change || poison2Change || poison3Change)
			{
				mod.PoisonedChanged = true;
				InstantNotificationCollection instantNotificationCollection = DomainManager.World.GetInstantNotifications();
				if (poison1Change)
				{
					instantNotificationCollection.AddPoisonIncreased(_id, poisonType1, delta);
				}
				if (poison2Change)
				{
					instantNotificationCollection.AddPoisonIncreased(_id, poisonType2, delta);
				}
				if (poison3Change)
				{
					instantNotificationCollection.AddPoisonIncreased(_id, poisonType3, delta);
				}
				DomainManager.LifeRecord.GetLifeRecordCollection().AddSpiritualDebtKongsangPoisoned(_id, DomainManager.World.GetCurrDate());
			}
			prob = GlobalConfig.Instance.KongsangCharacterFeaturePoisonedProbParm[0];
		}
		else
		{
			prob += GlobalConfig.Instance.KongsangCharacterFeaturePoisonedProbParm[1];
		}
		DomainManager.Extra.SetKongsangCharacterFeaturePoisonedProb(prob, context);
	}

	private unsafe void OfflineAutoRecoverMainAttributes()
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		short physiologicalAge = GetPhysiologicalAge();
		short clampedAge = GetClampedAgeOfAgeEffect(physiologicalAge);
		MainAttributes ageInfluence = AgeEffect.Instance[clampedAge].MainAttributesRecoveries;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int actionPointBonus = ((_id == taiwuCharId) ? (DomainManager.World.GetActionPointPrevMonth() / 10) : 0);
		for (sbyte i = 0; i < 6; i++)
		{
			short maxValue = maxMainAttributes.Items[i];
			int recovery = maxValue / 5 * ageInfluence.Items[i] / 100;
			recovery = Math.Max(1, recovery * (actionPointBonus + 100) / 100);
			if (_id == taiwuCharId)
			{
				ExtraDomain extraDomain = DomainManager.Extra;
				int professionId = ProfessionRelatedConstants.MainAttributeRecoverProfessionIds[i];
				if (extraDomain.IsProfessionalSkillUnlocked(professionId, 0))
				{
					ProfessionData professionData = extraDomain.GetProfessionData(professionId);
					recovery = professionData.GetMainAttributesRecoveryBonusAppliedRate(i, recovery);
				}
				ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)(112 + i);
				recovery *= DomainManager.Taiwu.GetTaiwuPropertyPermanentBonus(propertyType);
			}
			int currValue = _currMainAttributes.Items[i] + recovery;
			_currMainAttributes.Items[i] = (short)Math.Clamp(currValue, 0, maxValue);
		}
	}

	private void OfflineAutoRecoverCurrNeili(PeriAdvanceMonthUpdateStatusModification mod)
	{
		int oriCurrNeili = _currNeili;
		int maxNeili = GetMaxNeili();
		int recovery = GetCurrNeiliRecovery(maxNeili);
		recovery = DomainManager.SpecialEffect.ModifyData(_id, -1, 297, recovery);
		_currNeili = Math.Clamp(_currNeili + recovery, 0, maxNeili);
		if (_currNeili != oriCurrNeili)
		{
			mod.CurrNeiliChanged = true;
		}
	}

	private void OfflineChangeQiDisorder(PeriAdvanceMonthUpdateStatusModification mod)
	{
		short delta = GetChangeOfQiDisorder().total;
		int currDisorderOfQi = Math.Clamp(_disorderOfQi + delta, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue);
		if (currDisorderOfQi != _disorderOfQi)
		{
			_disorderOfQi = (short)currDisorderOfQi;
			mod.QiDisorderChanged = true;
		}
	}

	private unsafe void OfflineChangeInjuries(IRandomSource randomSource, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (!DomainManager.SpecialEffect.ModifyData(_id, -1, 268, dataValue: true))
		{
			return;
		}
		sbyte month = DomainManager.World.GetCurrMonthInYear();
		List<sbyte> parts = Month.Instance[month].RecoverBodyParts;
		for (int i = 0; i < parts.Count; i++)
		{
			sbyte part = parts[i];
			(sbyte outer, sbyte inner) tuple = _injuries.Get(part);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			int outerIndex = part * 2;
			if (outer > 0)
			{
				_injuries.Items[outerIndex] = (sbyte)(outer - 1);
				mod.InjuriesChanged = true;
			}
			if (inner > 0)
			{
				_injuries.Items[outerIndex + 1] = (sbyte)(inner - 1);
				mod.InjuriesChanged = true;
			}
		}
	}

	private unsafe void OfflineAutoRecoverPoisoned(PeriAdvanceMonthUpdateStatusModification mod)
	{
		ref PoisonInts poisonResists = ref GetPoisonResists();
		for (int i = 0; i < 6; i++)
		{
			if (_poisoned.Items[i] > 0)
			{
				int cureAmount = 100 + poisonResists.Items[i];
				_poisoned.Items[i] = Math.Max(_poisoned.Items[i] - cureAmount, 0);
				mod.PoisonedChanged = true;
			}
		}
	}

	private unsafe void OfflineRecoverAllForXiangshuInfected(PeriAdvanceMonthUpdateStatusModification mod)
	{
		int maxNeili = GetMaxNeili();
		if (_currNeili != maxNeili)
		{
			_currNeili = maxNeili;
			mod.CurrNeiliChanged = true;
		}
		if (_disorderOfQi > 0)
		{
			_disorderOfQi = 0;
			mod.QiDisorderChanged = true;
		}
		for (int i = 0; i < 14; i++)
		{
			if (_injuries.Items[i] > 0)
			{
				_injuries.Items[i] = 0;
				mod.InjuriesChanged = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (_poisoned.Items[j] > 0)
			{
				_poisoned.Items[j] = 0;
				mod.PoisonedChanged = true;
			}
		}
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		for (int k = 0; k < 6; k++)
		{
			short maxValue = maxMainAttributes.Items[k];
			_currMainAttributes.Items[k] = maxValue;
		}
	}

	private void OfflineChangeXiangshuInfection(PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (GetAgeGroup() != 2)
		{
			return;
		}
		if (_id != DomainManager.Taiwu.GetTaiwuCharId())
		{
			sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
			sbyte maxGrade = GlobalConfig.Instance.XiangshuInfectionGradeUpperLimits[xiangshuLevel];
			if (maxGrade < _organizationInfo.Grade)
			{
				return;
			}
		}
		if (GetLegendaryBookOwnerState() != 3)
		{
			byte oriXiangshuInfection = _xiangshuInfection;
			sbyte delta = GetXiangshuInfectionDelta();
			byte currXiangshuInfection = (byte)Math.Clamp(oriXiangshuInfection + delta, 0, 200);
			if (currXiangshuInfection != oriXiangshuInfection)
			{
				_xiangshuInfection = currXiangshuInfection;
				mod.XiangshuInfectionChanged = true;
			}
			if (TryGetInfectionFeatureIdThatShouldBe(out var featureId) && !IsActiveExternalRelationState(4uL))
			{
				OfflineAddFeature(featureId, removeMutexFeature: true);
				mod.FeaturesChanged = true;
				mod.XiangshuInfectionFeatureChanged = featureId;
			}
		}
	}

	private void OfflineIncreaseAge(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		if (_birthMonth != DomainManager.World.GetCurrMonthInYear())
		{
			return;
		}
		MainAttributes lackOfMainAttributes = default(MainAttributes);
		RecordLacksOfCurrMainAttributes(ref lackOfMainAttributes);
		_actualAge++;
		mod.ActualAgeChanged = true;
		if (!IsAgeIncreaseStopped())
		{
			_currAge++;
			mod.CurrAgeChanged = true;
			if (_id != DomainManager.Taiwu.GetTaiwuCharId() && _currAge == 1 && context.Random.CheckPercentProb(50))
			{
				short featureId = CharacterDomain.GenerateOneYearOldCatchFeature(context.Random);
				OfflineAddFeature(featureId, removeMutexFeature: true);
				mod.FeaturesChanged = true;
			}
			if (DomainManager.SpecialEffect.ModifyData(_id, -1, 265, dataValue: false))
			{
				_currAge++;
				mod.CurrAgeChanged = true;
			}
		}
		if (_hobbyExpirationDate <= DomainManager.World.GetCurrDate())
		{
			OfflineChangeHobby(context.Random);
			mod.HobbyChanged = true;
			mod.FavorabilitiesOfRelatedChars = DomainManager.Character.ChangeFavorabilitiesOfAllRelatedCharsWhenChangingHobby(context, this);
		}
		if (mod.CurrAgeChanged)
		{
			if (TryObtainPotentialFeatures())
			{
				mod.FeaturesChanged = true;
				mod.RecreateTeammateCommands = true;
			}
			mod.NewClothingTemplateId = TryGetNewClothingWhenAgeGroupChanges(context.Random, 0);
		}
		OfflineRestoreLacksOfCurrMainAttributes(context, lackOfMainAttributes, mod);
	}

	private void OfflineUpdateHealth()
	{
		bool isCompletelyInfected = IsCompletelyInfected();
		int healthDelta = GetHealthRecovery(isCompletelyInfected).total - 1;
		short leftMaxHealth = GetLeftMaxHealth();
		_health = (short)((leftMaxHealth >= 0) ? ((short)Math.Clamp(_health + healthDelta, 0, leftMaxHealth)) : 0);
	}

	private unsafe void RecordLacksOfCurrMainAttributes(ref MainAttributes lackOfCurrMainAtributes)
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		for (int i = 0; i < 6; i++)
		{
			short lack = (short)(maxMainAttributes.Items[i] - _currMainAttributes.Items[i]);
			lackOfCurrMainAtributes.Items[i] = lack;
		}
	}

	private unsafe void OfflineRestoreLacksOfCurrMainAttributes(DataContext context, MainAttributes lacksOfCurrMainAttributes, PeriAdvanceMonthUpdateStatusModification mod)
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		for (int i = 0; i < 6; i++)
		{
			short currValue = (short)(maxMainAttributes.Items[i] - lacksOfCurrMainAttributes.Items[i]);
			if (_currMainAttributes.Items[i] != currValue)
			{
				_currMainAttributes.Items[i] = currValue;
				mod.CurrMainAttributesChanged = true;
			}
		}
	}

	private bool TryObtainPotentialFeatures()
	{
		if (_currAge > 16)
		{
			return false;
		}
		int potentialFeaturesCount = _potentialFeatureIds.Count;
		int oriCount = potentialFeaturesCount * (_currAge - 1) / 16;
		int currCount = potentialFeaturesCount * _currAge / 16;
		if (oriCount >= currCount)
		{
			return false;
		}
		for (int i = oriCount; i < currCount; i++)
		{
			OfflineAddFeature(_potentialFeatureIds[i], removeMutexFeature: true, removeLowerOnly: true);
		}
		return true;
	}

	private short TryGetNewClothingWhenAgeGroupChanges(IRandomSource random, sbyte shufangAgeChange)
	{
		if ((_currAge == 16 && shufangAgeChange >= 0) || (shufangAgeChange == 1 && _currAge == 17))
		{
			if (_kidnapperId >= 0)
			{
				return -2;
			}
			OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
			return OrganizationDomain.GetRandomOrgMemberClothing(random, orgMemberCfg);
		}
		if (_currAge == GlobalConfig.Instance.AgeBaby)
		{
			return 65;
		}
		return -1;
	}

	private unsafe void TryGrowAvatarElements(DataContext context)
	{
		short physiologicalAge = GetPhysiologicalAge();
		bool gotDates = false;
		bool grownSomething = false;
		AvatarElementsGrownDates dates = default(AvatarElementsGrownDates);
		for (sbyte elementType = 0; elementType < 7; elementType++)
		{
			if (!_avatar.GetGrowableElementShowingState(elementType) && IsAbleToGrowAvatarElement(elementType, physiologicalAge))
			{
				if (!gotDates)
				{
					if (!DomainManager.Character.TryGetAvatarElementGrowthProgress(_id, out dates))
					{
						break;
					}
					gotDates = true;
				}
				int grownDate = dates.Items[elementType];
				if (DomainManager.World.GetCurrDate() >= grownDate)
				{
					_avatar.SetGrowableElementShowingState(elementType);
					dates.Items[elementType] = -1;
					grownSomething = true;
				}
			}
		}
		if (grownSomething)
		{
			SetAvatar(_avatar, context);
			DomainManager.Character.SetAvatarElementGrowthProgress(context, _id, ref dates);
		}
	}

	public bool IsAgeIncreaseStopped()
	{
		bool hasSpiritualDebtKongsang = _featureIds.Contains(383);
		if (_id == DomainManager.Taiwu.GetTaiwuCharId())
		{
			if (hasSpiritualDebtKongsang)
			{
				return true;
			}
			ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
			TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
			if (!DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(59) && skillsData.HasSurvivedAllTribulation() && !skillsData.ShouldIncreaseAge())
			{
				return true;
			}
		}
		else if (IsCompletelyInfected() || GetLegendaryBookOwnerState() > 0 || hasSpiritualDebtKongsang)
		{
			return true;
		}
		return false;
	}

	public void PeriAdvanceMonth_ExecuteFixedActions(DataContext context, HashSet<int> currBlockCharSet)
	{
		if (IsActiveAdvanceMonthStatus(4))
		{
			return;
		}
		PeriAdvanceMonthFixedActionModification mod = new PeriAdvanceMonthFixedActionModification(this);
		sbyte ageGroup = GetAgeGroup();
		if (ageGroup == 0)
		{
			if (!DomainManager.Taiwu.IsInGroup(_id))
			{
				OfflineExecuteFixedAction_Regroup(context.Random, currBlockCharSet, mod);
			}
		}
		else
		{
			OfflineCalcGeneralAction_RedEyeWugKing(context, mod, currBlockCharSet);
			if (ageGroup == 2)
			{
				OfflineExecuteFixedAction_MakeLove(context, currBlockCharSet, mod);
			}
			if (!DomainManager.Taiwu.IsInGroup(_id))
			{
				OfflineExecuteFixedAction_Regroup(context.Random, currBlockCharSet, mod);
			}
			OfflineExecuteFixedAction_ReleaseKidnappedCharacters(context.Random, mod);
			OfflineExecuteFixedAction_CollectResources(context.Random, mod);
		}
		if (mod.IsChanged)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthExecuteFixedActions);
			recorder.RecordParameterClass(mod);
		}
	}

	public static void ComplementPeriAdvanceMonth_ExecuteFixedActions(DataContext context, PeriAdvanceMonthFixedActionModification mod)
	{
		Character character = mod.Character;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (mod.MakeLoveTargetList != null)
		{
			character.SetFeatureIds(character._featureIds, context);
			foreach (var (target, state, isPregnant, targetIsFather) in mod.MakeLoveTargetList)
			{
				target.SetFeatureIds(target._featureIds, context);
				target.SetHappiness(target._happiness, context);
				switch (state)
				{
				case PeriAdvanceMonthFixedActionModification.MakeLoveState.Legal:
					if (target._id == taiwuCharId)
					{
						monthlyEventCollection.AddMakeLoveWithTaiwu(character._id, location, 0);
					}
					else
					{
						lifeRecordCollection.AddMakeLoveLegal(character._id, currDate, target._id, location);
					}
					break;
				case PeriAdvanceMonthFixedActionModification.MakeLoveState.Illegal:
				case PeriAdvanceMonthFixedActionModification.MakeLoveState.Wug:
				{
					if (target._id == taiwuCharId)
					{
						monthlyEventCollection.AddMakeLoveWithTaiwu(character._id, location, 1);
						break;
					}
					lifeRecordCollection.AddMakeLoveIllegal(character._id, currDate, target._id, location);
					int secretInfoOffset = secretInformationCollection.AddMakeLoveIllegal(character._id, target._id);
					SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
					break;
				}
				case PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeSucceed:
				{
					lifeRecordCollection.AddRapeSucceed(character._id, currDate, target._id, location);
					DomainManager.Character.AddRelation(context, target._id, character._id, 32768, currDate);
					DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, target, character, -30000);
					int secretInfoOffset2 = secretInformationCollection.AddRape(character._id, target._id);
					SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
					break;
				}
				case PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeFail:
					if (target._id == taiwuCharId)
					{
						monthlyNotificationCollection.AddRapeFailure(character._id, location, target._id);
					}
					lifeRecordCollection.AddRapeFail(character._id, currDate, target._id, location);
					DomainManager.Character.AddRelation(context, target._id, character._id, 32768, currDate);
					DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, target, character, -30000);
					break;
				}
				if (target._id != taiwuCharId)
				{
					Events.RaiseMakeLove(context, character, target, (sbyte)state);
				}
				if (isPregnant)
				{
					Character father = (targetIsFather ? target : character);
					Character mother = (targetIsFather ? character : target);
					DomainManager.Character.CreatePregnantState(context, mother, father, state == PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeSucceed);
				}
			}
		}
		if (mod.LeaveGroup)
		{
			DomainManager.Character.LeaveGroup(context, character);
		}
		if (mod.NewGroupLeader >= 0)
		{
			character.ApplyFixedAction_JoinGroup(context, mod.NewGroupLeader, mod.NewGroupActionTemplateId);
		}
		if (mod.TravelTargetsChanged)
		{
			character.SetNpcTravelTargets(character._npcTravelTargets, context);
		}
		if (mod.ReleaseKidnappedCharList != null)
		{
			KidnappedCharacterList kidnappedChars = DomainManager.Character.GetKidnappedCharacters(character._id);
			bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(character._id);
			foreach (int charId in mod.ReleaseKidnappedCharList)
			{
				int slotIndex = kidnappedChars.IndexOf(charId);
				lifeRecordCollection.AddReleaseKidnappedCharacter(character._id, currDate, charId, location);
				DomainManager.Character.RemoveKidnappedCharacter(context, character, kidnappedChars, slotIndex, isEscaped: false);
				if (selfIsTaiwuPeople || DomainManager.Character.IsTaiwuPeople(charId))
				{
					monthlyNotificationCollection.AddReleasePrisoner(character._id, location, charId);
				}
				int secretInfoOffset3 = secretInformationCollection.AddReleaseKidnappedCharacter(character._id, charId);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset3);
			}
		}
		if (mod.ModifiedMapBlocks != null)
		{
			character.SetResources(ref character._resources, context);
			foreach (MapBlockData blockData in mod.ModifiedMapBlocks)
			{
				DomainManager.Map.SetBlockData(context, blockData);
			}
		}
		List<(Character, IGeneralAction)> performedActions = mod.PerformedActions;
		if (performedActions == null || performedActions.Count <= 0)
		{
			return;
		}
		foreach (var (targetChar, performAction) in mod.PerformedActions)
		{
			if (!CanPerformAction(character))
			{
				break;
			}
			if ((targetChar == null || CanPerformAction(targetChar)) && performAction.CheckValid(character, targetChar))
			{
				if (targetChar != null && targetChar.GetId() == taiwuCharId)
				{
					performAction.ApplyInitialChangesForTaiwu(context, character, targetChar);
				}
				else
				{
					performAction.ApplyChanges(context, character, targetChar);
				}
			}
		}
	}

	private static bool CanPerformAction(Character character)
	{
		return DomainManager.Character.IsCharacterAlive(character._id) && character._kidnapperId < 0;
	}

	private void OfflineExecuteFixedAction_MakeLove(DataContext context, HashSet<int> currBlockCharSet, PeriAdvanceMonthFixedActionModification mod)
	{
		IRandomSource random = context.Random;
		if (SpecialEffectUtils.HasAzureMarrowMakeLoveEffect(_id))
		{
			List<int> potentialCharIds = context.AdvanceMonthRelatedData.CharIdList.Occupy();
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			foreach (int charId in currBlockCharSet)
			{
				if (!DomainManager.Character.TryGetRelation(_id, charId, out var selfToTarget) || !DomainManager.Character.TryGetRelation(charId, _id, out var targetToSelf) || selfToTarget.GetFavorabilityType() < 4 || targetToSelf.GetFavorabilityType() < 4)
				{
					continue;
				}
				Character targetChar = DomainManager.Character.GetElement_Objects(charId);
				if (_gender != targetChar._gender && targetChar.GetAgeGroup() == 2)
				{
					int successRate = AiHelper.Relation.GetStartRelationSuccessRate_BoyOrGirlFriend(this, targetChar, selfToTarget, targetToSelf);
					DomainManager.SpecialEffect.ModifyValue(_id, 267, successRate);
					successRate = successRate * GetFertility() * targetChar.GetFertility() / 10000;
					if (random.CheckPercentProb(successRate))
					{
						potentialCharIds.Add(charId);
					}
				}
			}
			int targetCharId = potentialCharIds.GetRandomOrDefault(random, -1);
			context.AdvanceMonthRelatedData.CharIdList.Release(ref potentialCharIds);
			if (targetCharId >= 0)
			{
				Character targetChar2 = DomainManager.Character.GetElement_Objects(targetCharId);
				Character father = this;
				Character mother = targetChar2;
				GetMakeLoveRole(context.Random, ref father, ref mother);
				bool isPregnant = targetCharId != taiwuCharId && OfflineMakeLove(random, father, mother, isRape: false);
				if (mod.MakeLoveTargetList == null)
				{
					mod.MakeLoveTargetList = new List<(Character, PeriAdvanceMonthFixedActionModification.MakeLoveState, bool, bool)>();
				}
				mod.MakeLoveTargetList.Add((targetChar2, PeriAdvanceMonthFixedActionModification.MakeLoveState.Wug, isPregnant, father.GetId() == targetCharId));
				return;
			}
		}
		foreach (int charId2 in currBlockCharSet)
		{
			if ((DomainManager.Character.TryGetRelation(_id, charId2, out var selfToTarget2) && RelationType.HasRelation(selfToTarget2.RelationType, 16384)) || RelationType.HasRelation(selfToTarget2.RelationType, 1024))
			{
				OfflineExecuteFixedAction_MakeLove_Mutual(random, charId2, allowRape: false, mod);
			}
		}
	}

	private void OfflineExecuteFixedAction_MakeLove_Mutual(IRandomSource random, int targetCharId, bool allowRape, PeriAdvanceMonthFixedActionModification mod)
	{
		Character target = DomainManager.Character.GetElement_Objects(targetCharId);
		if (target.GetAgeGroup() != 2)
		{
			return;
		}
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(targetCharId, _id);
		sbyte selfToTargetFavorType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetRelation(_id, targetCharId).Favorability);
		sbyte targetToSelfFavorType = FavorabilityType.GetFavorabilityType(targetToSelf.Favorability);
		Character father = this;
		Character mother = target;
		GetMakeLoveRole(random, ref father, ref mother);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (RelationType.HasRelation(targetToSelf.RelationType, 1024))
		{
			int baseChance = 50 + 50 * (selfToTargetFavorType + targetToSelfFavorType) / 12;
			int rate = baseChance * GetFertility() * target.GetFertility() / 10000;
			DomainManager.SpecialEffect.ModifyValue(_id, 267, rate);
			if (random.CheckPercentProb(rate))
			{
				bool isPregnant = target.GetId() != taiwuCharId && OfflineMakeLove(random, father, mother, isRape: false);
				PeriAdvanceMonthFixedActionModification periAdvanceMonthFixedActionModification = mod;
				if (periAdvanceMonthFixedActionModification.MakeLoveTargetList == null)
				{
					periAdvanceMonthFixedActionModification.MakeLoveTargetList = new List<(Character, PeriAdvanceMonthFixedActionModification.MakeLoveState, bool, bool)>();
				}
				mod.MakeLoveTargetList.Add((target, PeriAdvanceMonthFixedActionModification.MakeLoveState.Legal, isPregnant, father.GetId() == targetCharId));
			}
		}
		else if (RelationType.HasRelation(targetToSelf.RelationType, 16384))
		{
			int baseChance2 = 50 + 50 * (selfToTargetFavorType + targetToSelfFavorType) / 12;
			baseChance2 = baseChance2 * AiHelper.FixedActionConstants.BoyAndGirlFriendMakeLoveBaseChance[GetBehaviorType()] / 100;
			int rate2 = baseChance2 * GetFertility() * target.GetFertility() / 10000;
			rate2 += DomainManager.Character.GetAiActionRateAdjust(_id, 4, 1);
			DomainManager.SpecialEffect.ModifyValue(_id, 267, rate2);
			if (rate2 > 0 && random.CheckPercentProb(rate2))
			{
				bool isPregnant2 = target.GetId() != taiwuCharId && OfflineMakeLove(random, father, mother, isRape: false);
				PeriAdvanceMonthFixedActionModification periAdvanceMonthFixedActionModification = mod;
				if (periAdvanceMonthFixedActionModification.MakeLoveTargetList == null)
				{
					periAdvanceMonthFixedActionModification.MakeLoveTargetList = new List<(Character, PeriAdvanceMonthFixedActionModification.MakeLoveState, bool, bool)>();
				}
				mod.MakeLoveTargetList.Add((target, PeriAdvanceMonthFixedActionModification.MakeLoveState.Illegal, isPregnant2, father.GetId() == targetCharId));
			}
		}
		else
		{
			if (!allowRape)
			{
				return;
			}
			short fertility = GetFertility();
			int rate3 = AiHelper.FixedActionConstants.RapeBaseChance[GetBehaviorType()] * fertility / 100;
			rate3 += DomainManager.Character.GetAiActionRateAdjust(_id, 4, 3);
			DomainManager.SpecialEffect.ModifyValue(_id, 267, rate3);
			if (rate3 > 0 && random.CheckPercentProb(rate3))
			{
				PeriAdvanceMonthFixedActionModification periAdvanceMonthFixedActionModification = mod;
				if (periAdvanceMonthFixedActionModification.MakeLoveTargetList == null)
				{
					periAdvanceMonthFixedActionModification.MakeLoveTargetList = new List<(Character, PeriAdvanceMonthFixedActionModification.MakeLoveState, bool, bool)>();
				}
				if (targetCharId != DomainManager.Taiwu.GetTaiwuCharId() && GetCombatPower() > target.GetCombatPower() && fertility > 50)
				{
					mod.MakeLoveTargetList.Add((target, PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeSucceed, OfflineMakeLove(random, father, mother, isRape: true), father.GetId() == targetCharId));
				}
				else
				{
					mod.MakeLoveTargetList.Add((target, PeriAdvanceMonthFixedActionModification.MakeLoveState.RapeFail, false, target.GetId() == targetCharId));
				}
			}
		}
	}

	private static (Character father, Character mother) GetParentalInfoOnMakeLove(Character self, Character target)
	{
		return (self._gender == 1) ? (father: self, mother: target) : (father: target, mother: self);
	}

	private bool OfflineMakeLove(IRandomSource random, Character father, Character mother, bool isRape)
	{
		if (!CheckMakeLoveRole(father, mother))
		{
			return false;
		}
		mother.OfflineAddFeature(197, removeMutexFeature: true);
		father.OfflineAddFeature(197, removeMutexFeature: true);
		if (!PregnantState.CheckPregnant(random, father, mother, isRape))
		{
			return false;
		}
		mother.OfflineAddFeature(198, removeMutexFeature: true);
		return true;
	}

	private unsafe void OfflineExecuteFixedAction_Regroup(IRandomSource random, HashSet<int> currBlockCharSet, PeriAdvanceMonthFixedActionModification mod)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (_leaderId == taiwuCharId)
		{
			return;
		}
		int leaderId = _leaderId;
		if (leaderId == _id)
		{
			if (DomainManager.Character.HasNonBabyMemberInGroup(leaderId))
			{
				return;
			}
			leaderId = -1;
		}
		sbyte behaviorType = GetBehaviorType();
		if (OfflineExecuteFixedAction_Regroup_Action(random, behaviorType, currBlockCharSet, mod))
		{
			return;
		}
		int targetLeaderId = -1;
		Personalities personalities = GetPersonalities();
		sbyte ageGroup = AgeGroup.GetAgeGroup(_currAge);
		if (leaderId >= 0)
		{
			RelatedCharacter relation = DomainManager.Character.GetRelation(_id, leaderId);
			RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(leaderId, _id);
			sbyte groupRelationType = AiHelper.JoinGroupRelationType.GetJoinGroupRelationType(relation.RelationType, targetToSelf.RelationType);
			switch (ageGroup)
			{
			case 1:
				if ((uint)(groupRelationType - 2) > 1u)
				{
					break;
				}
				return;
			case 0:
				return;
			}
			sbyte favorabilityType = FavorabilityType.GetFavorabilityType(relation.Favorability);
			if (groupRelationType == -1 || favorabilityType < AiHelper.FixedActionConstants.JoinGroupFavorabilityReq[groupRelationType])
			{
				mod.LeaveGroup = true;
				return;
			}
			int stayInGroupMonth = DomainManager.World.GetCurrDate() - DomainManager.Character.GetElement_JoinGroupDates(_id);
			if (stayInGroupMonth >= AiHelper.FixedActionConstants.StayInGroupMonth[groupRelationType])
			{
				int leaveGroupChance = Math.Min(AiHelper.FixedActionConstants.MaxLeaveGroupChance[groupRelationType], (stayInGroupMonth - AiHelper.FixedActionConstants.StayInGroupMonth[groupRelationType]) * AiHelper.FixedActionConstants.LeaveGroupChancePerMonth[groupRelationType]);
				if (random.CheckPercentProb(leaveGroupChance))
				{
					mod.LeaveGroup = true;
				}
			}
		}
		else if (targetLeaderId >= 0)
		{
			if (currBlockCharSet.Contains(targetLeaderId) && !DomainManager.Taiwu.IsInGroup(targetLeaderId))
			{
				mod.NewGroupLeader = targetLeaderId;
				return;
			}
			NpcTravelTarget target = new NpcTravelTarget(targetLeaderId, 3);
			OfflineAddNpcTravelTarget(target);
			mod.TravelTargetsChanged = true;
		}
		else
		{
			if (currBlockCharSet.Count <= 0)
			{
				return;
			}
			List<(Character, RelatedCharacter)>[] groupTypes = new List<(Character, RelatedCharacter)>[7];
			for (int i = 0; i < 7; i++)
			{
				groupTypes[i] = new List<(Character, RelatedCharacter)>();
			}
			foreach (int charId in currBlockCharSet)
			{
				if (DomainManager.Taiwu.IsInGroup(charId) || !DomainManager.Character.TryGetRelation(_id, charId, out var relation2) || !DomainManager.Character.TryGetRelation(charId, _id, out var targetToSelf2))
				{
					continue;
				}
				sbyte groupRelationType2 = AiHelper.JoinGroupRelationType.GetJoinGroupRelationType(relation2.RelationType, targetToSelf2.RelationType);
				if (groupRelationType2 == -1)
				{
					continue;
				}
				Character character = DomainManager.Character.GetElement_Objects(charId);
				if (character.GetAgeGroup() == 0 || character.GetLegendaryBookOwnerState() >= 2)
				{
					continue;
				}
				switch (ageGroup)
				{
				case 0:
				{
					bool flag = (uint)(groupRelationType2 - 1) <= 2u;
					if (flag && character.GetCurrAge() > _currAge)
					{
						groupTypes[groupRelationType2].Add((character, relation2));
					}
					continue;
				}
				case 1:
					if ((uint)(groupRelationType2 - 2) > 1u)
					{
						break;
					}
					if (character.GetCurrAge() > _currAge)
					{
						groupTypes[groupRelationType2].Add((character, relation2));
					}
					continue;
				}
				sbyte favorabilityType2 = FavorabilityType.GetFavorabilityType(relation2.Favorability);
				if (favorabilityType2 >= AiHelper.FixedActionConstants.JoinGroupFavorabilityReq[groupRelationType2])
				{
					Comparison<(Character, RelatedCharacter)> comparison = AiHelper.JoinGroupRelationType.Comparisons[groupRelationType2];
					bool flag = (uint)(groupRelationType2 - 1) <= 1u;
					if (flag || comparison((this, targetToSelf2), (character, relation2)) <= 0)
					{
						groupTypes[groupRelationType2].Add((character, relation2));
					}
				}
			}
			switch (ageGroup)
			{
			case 0:
				if (groupTypes[2].Count > 0)
				{
					List<(Character, RelatedCharacter)> potentialLeaders3 = groupTypes[2];
					Comparison<(Character, RelatedCharacter)> comparison4 = AiHelper.JoinGroupRelationType.Comparisons[2];
					Character character4 = potentialLeaders3.Max(comparison4).Item1;
					mod.NewGroupLeader = character4._id;
				}
				else if (groupTypes[3].Count > 0)
				{
					List<(Character, RelatedCharacter)> potentialLeaders4 = groupTypes[3];
					Comparison<(Character, RelatedCharacter)> comparison5 = AiHelper.JoinGroupRelationType.Comparisons[3];
					Character character5 = potentialLeaders4.Max(comparison5).Item1;
					mod.NewGroupLeader = character5._id;
				}
				else if (groupTypes[1].Count > 0)
				{
					List<(Character, RelatedCharacter)> potentialLeaders5 = groupTypes[1];
					Comparison<(Character, RelatedCharacter)> comparison6 = AiHelper.JoinGroupRelationType.Comparisons[1];
					Character character6 = potentialLeaders5.Max(comparison6).Item1;
					mod.NewGroupLeader = character6._id;
				}
				return;
			case 1:
				if (groupTypes[2].Count > 0)
				{
					List<(Character, RelatedCharacter)> potentialLeaders = groupTypes[2];
					Comparison<(Character, RelatedCharacter)> comparison2 = AiHelper.JoinGroupRelationType.Comparisons[2];
					Character character2 = potentialLeaders.Max(comparison2).Item1;
					mod.NewGroupLeader = character2._id;
					return;
				}
				if (groupTypes[3].Count > 0)
				{
					List<(Character, RelatedCharacter)> potentialLeaders2 = groupTypes[3];
					Comparison<(Character, RelatedCharacter)> comparison3 = AiHelper.JoinGroupRelationType.Comparisons[3];
					Character character3 = potentialLeaders2.Max(comparison3).Item1;
					mod.NewGroupLeader = character3._id;
					return;
				}
				break;
			}
			sbyte[] orders = AiHelper.JoinGroupRelationType.Priorities[behaviorType];
			foreach (sbyte groupRelationType3 in orders)
			{
				List<(Character, RelatedCharacter)> potentialLeaders6 = groupTypes[groupRelationType3];
				if (potentialLeaders6.Count == 0)
				{
					continue;
				}
				sbyte personalityType = AiHelper.JoinGroupRelationType.ToPersonalityType[groupRelationType3];
				int joinGroupChance = AiHelper.FixedActionConstants.JoinGroupBaseChance[behaviorType] + personalities.Items[personalityType];
				if (!random.CheckPercentProb(joinGroupChance))
				{
					if ((uint)(groupRelationType3 - 1) <= 1u)
					{
						Comparison<(Character, RelatedCharacter)> comparison7 = AiHelper.JoinGroupRelationType.Comparisons[groupRelationType3];
						Character character7 = potentialLeaders6.Max(comparison7).Item1;
						mod.NewGroupLeader = character7._id;
					}
					else
					{
						Character character8 = potentialLeaders6.GetRandom(random).Item1;
						mod.NewGroupLeader = character8._id;
					}
					break;
				}
			}
		}
	}

	private bool OfflineExecuteFixedAction_Regroup_Action(IRandomSource random, sbyte behaviorType, HashSet<int> currBlockCharSet, PeriAdvanceMonthFixedActionModification mod)
	{
		return false;
	}

	private void OfflineExecuteFixedAction_ReleaseKidnappedCharacters(IRandomSource random, PeriAdvanceMonthFixedActionModification mod)
	{
		if (!IsActiveExternalRelationState(2uL))
		{
			return;
		}
		KidnappedCharacterList kidnappedCharList = DomainManager.Character.GetKidnappedCharacters(_id);
		sbyte behaviorType = GetBehaviorType();
		sbyte releaseThreshold = AiHelper.FixedActionConstants.ReleaseKidnappedCharResistanceThreshold[behaviorType];
		sbyte releaseBaseChance = AiHelper.FixedActionConstants.ReleaseKidnappedCharChance[behaviorType];
		Character kidnapper = DomainManager.Character.GetElement_Objects(_id);
		foreach (KidnappedCharacter kidnappedChar in kidnappedCharList.GetCollection())
		{
			int totalResistance = DomainManager.Character.CalcKidnappedCharacterTotalResistance(kidnapper, kidnappedChar);
			if (totalResistance < releaseThreshold)
			{
				continue;
			}
			short favorability = DomainManager.Character.GetFavorability(_id, kidnappedChar.CharId);
			int releaseChance = releaseBaseChance + FavorabilityType.GetFavorabilityType(favorability) * 5;
			if (random.CheckPercentProb(releaseChance))
			{
				if (mod.ReleaseKidnappedCharList == null)
				{
					mod.ReleaseKidnappedCharList = new List<int>();
				}
				mod.ReleaseKidnappedCharList.Add(kidnappedChar.CharId);
			}
		}
	}

	private unsafe void OfflineExecuteFixedAction_CollectResources(IRandomSource random, PeriAdvanceMonthFixedActionModification mod)
	{
		foreach (CharacterGoalData need in GetGoals())
		{
			if (need.GoalTemplateId != 236)
			{
				continue;
			}
			sbyte resourceType = need.Args.ResourceType;
			if (resourceType >= 6)
			{
				continue;
			}
			MapBlockData block = DomainManager.Map.GetBlock(_location);
			short currentResource = block.CurrResources.Items[resourceType];
			if (currentResource >= block.MaxResources.Items[resourceType] / 2)
			{
				int addResource = DomainManager.Map.GetCollectResourceAmount(random, block, resourceType);
				ref int reference = ref _resources.Items[resourceType];
				reference += addResource;
				ResourceTypeItem resourceConfig = Config.ResourceType.Instance[resourceType];
				block.CurrResources.Items[resourceType] = (short)Math.Max(currentResource - resourceConfig.ResourceReducePerCollection, 0);
				block.Malice += 10;
				if (mod.ModifiedMapBlocks == null)
				{
					mod.ModifiedMapBlocks = new List<MapBlockData>();
				}
				mod.ModifiedMapBlocks.Add(block);
			}
		}
	}

	private void ApplyFixedAction_JoinGroup(DataContext context, int newGroupLeader, short actionTemplateId)
	{
		Character targetLeader = DomainManager.Character.GetElement_Objects(newGroupLeader);
		if (_leaderId == _id)
		{
			if (DomainManager.Character.HasNonBabyMemberInGroup(_leaderId))
			{
				return;
			}
			CharacterSet prevGroup = DomainManager.Character.GetGroup(_leaderId);
			HashSet<int> toRemoveGroupChars = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
			toRemoveGroupChars.UnionWith(prevGroup.GetCollection());
			toRemoveGroupChars.Remove(_id);
			foreach (int memberId in toRemoveGroupChars)
			{
				Character memberChar = DomainManager.Character.GetElement_Objects(memberId);
				Tester.Assert(memberChar.GetAgeGroup() == 0);
				DomainManager.Character.LeaveGroup(context, memberChar);
				DomainManager.Character.JoinGroup(context, memberChar, targetLeader);
			}
			context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref toRemoveGroupChars);
		}
		DomainManager.Character.JoinGroup(context, this, targetLeader);
	}

	public bool CanLearnLifeSkillFrom(Character character, sbyte lifeSkillType = -1)
	{
		foreach (LifeSkillItem item in character._learnedLifeSkills)
		{
			Config.LifeSkillItem lifeSkillConfig = LifeSkill.Instance[item.SkillTemplateId];
			if (lifeSkillConfig.SkillBookId >= 0 && (lifeSkillConfig.Type == lifeSkillType || lifeSkillType < 0))
			{
				int learnedLifeSkillIndex = FindLearnedLifeSkillIndex(item.SkillTemplateId);
				if (learnedLifeSkillIndex < 0 && item.ReadingState != 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public (short skillId, byte pageId) CalcLifeSkillToLearnFromCharacter(DataContext context, Character character, sbyte lifeSkillType = -1)
	{
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		for (short index = 0; index < character._learnedLifeSkills.Count; index++)
		{
			LifeSkillItem lifeSkillItem = character._learnedLifeSkills[index];
			Config.LifeSkillItem lifeSkillCfg = LifeSkill.Instance[lifeSkillItem.SkillTemplateId];
			if (lifeSkillCfg.SkillBookId >= 0 && (lifeSkillCfg.Type == lifeSkillType || lifeSkillType < 0) && FindLearnedLifeSkillIndex(lifeSkillItem.SkillTemplateId) < 0 && lifeSkillItem.ReadingState != 0)
			{
				weightTable.Add((index, (short)(3 << 8 - lifeSkillCfg.Grade)));
			}
		}
		if (weightTable.Count == 0)
		{
			context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
			return (skillId: -1, pageId: 0);
		}
		short selectedIndex = RandomUtils.GetRandomResult(weightTable, context.Random);
		context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
		LifeSkillItem learnedLifeSkill = character._learnedLifeSkills[selectedIndex];
		short lifeSkillTemplateId = learnedLifeSkill.SkillTemplateId;
		byte pageId = 0;
		while (pageId < 5 && !learnedLifeSkill.IsPageRead(pageId))
		{
			pageId++;
		}
		return (skillId: lifeSkillTemplateId, pageId: pageId);
	}

	public bool CanLearnCombatSkillFrom(Character character, sbyte combatSkillType = -1)
	{
		int targetCharId = character.GetId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> targetCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(targetCharId);
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in targetCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill skill = value;
			CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[skillTemplateId];
			if (combatSkillCfg.BookId < 0 || (combatSkillCfg.Type != combatSkillType && combatSkillType >= 0) || selfCombatSkills.ContainsKey(skillTemplateId) || skill.GetReadingState() == 0)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public (short skillId, byte internalIndex, byte pageTypes) CalcCombatSkillToLearnFromCharacter(DataContext context, Character character, sbyte combatSkillType = -1)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> targetCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in targetCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short templateId = key;
			GameData.Domains.CombatSkill.CombatSkill combatSkill = value;
			CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[templateId];
			if (combatSkillCfg.BookId >= 0 && (combatSkillCfg.Type == combatSkillType || combatSkillType < 0) && !selfCombatSkills.ContainsKey(templateId) && combatSkill.GetReadingState() != 0)
			{
				int weight = 3 << 8 - combatSkillCfg.Grade;
				if (combatSkillCfg.IsNonPublic)
				{
					weight /= 3;
				}
				weightTable.Add((templateId, (short)weight));
			}
		}
		if (weightTable.Count == 0)
		{
			context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
			return (skillId: -1, internalIndex: 0, pageTypes: 0);
		}
		short skillTemplateId = RandomUtils.GetRandomResult(weightTable, context.Random);
		context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
		GameData.Domains.CombatSkill.CombatSkill selectedCombatSkill = targetCombatSkills[skillTemplateId];
		ushort readingState = selectedCombatSkill.GetReadingState();
		byte currInternalIndex = 0;
		while (currInternalIndex < 15 && !CombatSkillStateHelper.IsPageRead(readingState, currInternalIndex))
		{
			currInternalIndex++;
		}
		byte pageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(context.Random, readingState);
		return (skillId: skillTemplateId, internalIndex: currInternalIndex, pageTypes: pageTypes);
	}

	private bool CanInteractTreasury()
	{
		if (_organizationInfo.SettlementId < 0)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
		if (!settlement.HasTreasury() && _organizationInfo.OrgTemplateId != 16)
		{
			return false;
		}
		Location settlementLocation = settlement.GetLocation();
		if (settlementLocation.AreaId != _location.AreaId)
		{
			return false;
		}
		MapBlockData block = DomainManager.Map.GetBlock(_location);
		if (block.GetRootBlock().GetLocation() != settlementLocation)
		{
			return false;
		}
		return true;
	}

	public bool CanTeachCombatSkill(Character targetChar)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (var (skillId, skill) in selfCombatSkills)
		{
			if (skill.GetReadingState() != 0 && Config.CombatSkill.Instance[skillId].BookId >= 0 && !targetChar._learnedCombatSkills.Contains(skillId))
			{
				return true;
			}
		}
		return false;
	}

	public bool CanTeachLifeSkill(Character targetChar)
	{
		foreach (LifeSkillItem item in _learnedLifeSkills)
		{
			if (item.ReadingState != 0 && LifeSkill.Instance[item.SkillTemplateId].SkillBookId >= 0 && targetChar.FindLearnedLifeSkillIndex(item.SkillTemplateId) < 0)
			{
				return true;
			}
		}
		return false;
	}

	public void GetTeachableCombatSkillBookIds(Character targetChar, List<(short, short)> weightTable)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		foreach (short combatSkillTemplateId in _learnedCombatSkills)
		{
			CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[combatSkillTemplateId];
			if (combatSkillCfg.BookId >= 0 && selfCombatSkills[combatSkillTemplateId].GetReadingState() != 0 && !targetChar._learnedCombatSkills.Contains(combatSkillTemplateId))
			{
				int weight = 3 << 8 - combatSkillCfg.Grade;
				if (combatSkillCfg.IsNonPublic)
				{
					weight /= 3;
				}
				weightTable.Add((combatSkillCfg.BookId, (short)weight));
			}
		}
	}

	public void GetTeachableLifeSkillBookIds(Character targetChar, List<(short, short)> weightTable)
	{
		foreach (LifeSkillItem lifeSkillItem in _learnedLifeSkills)
		{
			Config.LifeSkillItem lifeSkillCfg = LifeSkill.Instance[lifeSkillItem.SkillTemplateId];
			byte selfReadingState = lifeSkillItem.ReadingState;
			if (lifeSkillCfg.SkillBookId >= 0 && selfReadingState != 0 && targetChar.FindLearnedLifeSkillIndex(lifeSkillItem.SkillTemplateId) < 0)
			{
				int weight = 3 << 8 - lifeSkillCfg.Grade;
				weightTable.Add((lifeSkillCfg.SkillBookId, (short)weight));
			}
		}
	}

	private unsafe void AddTeachSkillAction(DataContext context, PeriAdvanceMonthFixedActionModification mod, Character targetChar, short skillBookTemplateId = -1)
	{
		if (skillBookTemplateId < 0)
		{
			List<(short, short)> weightTable = context.AdvanceMonthRelatedData.WeightTable.Occupy();
			GetTeachableCombatSkillBookIds(targetChar, weightTable);
			GetTeachableLifeSkillBookIds(targetChar, weightTable);
			skillBookTemplateId = RandomUtils.GetRandomResult(weightTable, context.Random);
			context.AdvanceMonthRelatedData.WeightTable.Release(ref weightTable);
			if (skillBookTemplateId < 0)
			{
				return;
			}
		}
		SkillBookItem bookCfg = Config.SkillBook.Instance[skillBookTemplateId];
		if (bookCfg.CombatSkillType >= 0)
		{
			Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> selfCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
			ushort readingState = selfCombatSkills[bookCfg.CombatSkillTemplateId].GetReadingState();
			byte currInternalIndex = 0;
			while (currInternalIndex < 15 && !CombatSkillStateHelper.IsPageRead(readingState, currInternalIndex))
			{
				currInternalIndex++;
			}
			byte pageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(context.Random, readingState);
			CombatSkillShorts combatSkillAttainments = targetChar.GetCombatSkillAttainments();
			CombatSkillShorts combatSkillQualifications = targetChar.GetCombatSkillQualifications();
			Personalities personalities = targetChar.GetPersonalities();
			int successRate = GetTaughtNewSkillSuccessRate(bookCfg.Grade, combatSkillQualifications.Items[bookCfg.CombatSkillType], combatSkillAttainments.Items[bookCfg.CombatSkillType], personalities.Items[1]);
			mod.PerformedActions.Add((targetChar, new TeachCombatSkillAction
			{
				SkillTemplateId = bookCfg.CombatSkillTemplateId,
				InternalIndex = currInternalIndex,
				GeneratedPageTypes = pageTypes,
				Succeed = context.Random.CheckPercentProb(successRate)
			}));
		}
		else
		{
			int selectedIndex = FindLearnedLifeSkillIndex(bookCfg.LifeSkillTemplateId);
			LifeSkillItem learnedLifeSkill = _learnedLifeSkills[selectedIndex];
			byte pageId = 0;
			while (pageId < 5 && !learnedLifeSkill.IsPageRead(pageId))
			{
				pageId++;
			}
			LifeSkillShorts lifeSkillAttainments = targetChar.GetLifeSkillAttainments();
			LifeSkillShorts lifeSkillQualifications = targetChar.GetLifeSkillQualifications();
			Personalities personalities2 = targetChar.GetPersonalities();
			int successRate2 = GetTaughtNewSkillSuccessRate(bookCfg.Grade, lifeSkillQualifications.Items[bookCfg.LifeSkillType], lifeSkillAttainments.Items[bookCfg.LifeSkillType], personalities2.Items[1]);
			mod.PerformedActions.Add((targetChar, new TeachLifeSkillAction
			{
				SkillTemplateId = bookCfg.LifeSkillTemplateId,
				PageId = pageId,
				Succeed = context.Random.CheckPercentProb(successRate2)
			}));
		}
	}

	private unsafe bool IsValidForLifeSkillAwakening(Character targetChar)
	{
		LifeSkillShorts selfQualifications = GetBaseLifeSkillQualifications();
		LifeSkillShorts selfAttainments = GetLifeSkillAttainments();
		LifeSkillShorts targetQualifications = targetChar.GetBaseLifeSkillQualifications();
		bool hasValidLifeSkillType = false;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (targetQualifications.Items[lifeSkillType] < 90)
			{
				hasValidLifeSkillType = true;
				break;
			}
		}
		if (!hasValidLifeSkillType)
		{
			return false;
		}
		if (selfQualifications.Items[13] > targetQualifications.Items[13] && selfAttainments.Items[13] >= 200)
		{
			return true;
		}
		if (selfQualifications.Items[12] > targetQualifications.Items[12] && selfAttainments.Items[12] >= 200)
		{
			return true;
		}
		return false;
	}

	public void ClassifyPrioritizedActionTargets(List<int>[] prioritizedActionTargets, HashSet<int> charSet, IRandomSource random)
	{
		foreach (List<int> targets in prioritizedActionTargets)
		{
			targets.Clear();
		}
		foreach (int charId in charSet)
		{
			if (DomainManager.Character.TryGetRelation(_id, charId, out var selfToTarget))
			{
				sbyte priorityType = AiHelper.ActionTargetType.GetActionTargetType(selfToTarget.RelationType);
				if (priorityType != -1)
				{
					prioritizedActionTargets[priorityType].Add(charId);
				}
			}
		}
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34) && charSet.Contains(taiwuId) && DomainManager.Character.TryGetRelation(_id, taiwuId, out var selfToTaiwu))
		{
			sbyte priorityType2 = AiHelper.ActionTargetType.GetActionTargetType(selfToTaiwu.RelationType);
			if (priorityType2 != -1)
			{
				ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(prioritizedActionTargets[priorityType2]);
				CollectionUtils.Shuffle(random, prioritizedActionTargets[priorityType2]);
			}
		}
	}

	public int SelectMaxPriorityActionTarget(List<int>[] prioritizedActionTargets, Predicate<int> condition)
	{
		sbyte behaviorType = GetBehaviorType();
		sbyte[] priorities = AiHelper.ActionTargetType.Priorities[behaviorType];
		sbyte[] array = priorities;
		foreach (sbyte actionTargetType in array)
		{
			List<int> actionTargets = prioritizedActionTargets[actionTargetType];
			foreach (int charId in actionTargets)
			{
				if (condition(charId))
				{
					return charId;
				}
			}
		}
		return -1;
	}

	public Character SelectRandomActionTarget(DataContext context, HashSet<int> currBlockChars, Predicate<Character> condition, bool includeBabies = false)
	{
		if (currBlockChars == null)
		{
			return null;
		}
		List<int> targets = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		List<int> boostedTargets = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
		boostedTargets.Clear();
		targets.Clear();
		foreach (int charId in currBlockChars)
		{
			Character targetChar = DomainManager.Character.GetElement_Objects(charId);
			if ((includeBabies || targetChar.GetAgeGroup() != 0) && DomainManager.Character.TryGetRelation(_id, charId, out var _) && (condition == null || condition(targetChar)))
			{
				targets.Add(charId);
				boostedTargets.Add(charId);
			}
		}
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34) && boostedTargets.Contains(DomainManager.Taiwu.GetTaiwuCharId()))
		{
			ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(boostedTargets);
			int targetCharId = boostedTargets.GetRandom(context.Random);
			context.AdvanceMonthRelatedData.CharIdList.Release(ref targets);
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref boostedTargets);
			return DomainManager.Character.GetElement_Objects(targetCharId);
		}
		Character selectedChar = ((targets.Count == 0) ? null : DomainManager.Character.GetElement_Objects(targets.GetRandom(context.Random)));
		context.AdvanceMonthRelatedData.CharIdList.Release(ref targets);
		context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref boostedTargets);
		return selectedChar;
	}

	public Character SelectMaxPriorityActionTarget(DataContext context, HashSet<int> currBlockChars, Predicate<Character> condition, CharacterMatcherItem matcher = null)
	{
		if (currBlockChars == null)
		{
			return null;
		}
		sbyte currMaxPriorityType = -1;
		int currMaxPriorityScore = 0;
		List<int> maxPriorityTargets = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		List<int> boostedTargets = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
		sbyte behaviorType = GetBehaviorType();
		foreach (int charId in currBlockChars)
		{
			Character targetChar = DomainManager.Character.GetElement_Objects(charId);
			if (targetChar.GetAgeGroup() == 0 || (matcher != null && !matcher.Match(targetChar)) || !DomainManager.Character.TryGetRelation(_id, charId, out var selfToTarget) || (condition != null && !condition(targetChar)))
			{
				continue;
			}
			sbyte currPriorityType = AiHelper.ActionTargetType.GetActionTargetType(selfToTarget.RelationType);
			if (currPriorityType != -1)
			{
				sbyte currPriorityScore = AiHelper.ActionTargetType.PriorityScores[behaviorType][currPriorityType];
				if (currPriorityType == currMaxPriorityType)
				{
					maxPriorityTargets.Add(charId);
					boostedTargets.Add(charId);
				}
				else if (currMaxPriorityScore < currPriorityScore)
				{
					currMaxPriorityType = currPriorityType;
					currMaxPriorityScore = currPriorityScore;
					maxPriorityTargets.Clear();
					maxPriorityTargets.Add(charId);
					boostedTargets.Clear();
					boostedTargets.Add(charId);
				}
			}
		}
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34) && boostedTargets.Contains(DomainManager.Taiwu.GetTaiwuCharId()))
		{
			ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(boostedTargets);
			int targetCharId = boostedTargets.GetRandom(context.Random);
			context.AdvanceMonthRelatedData.CharIdList.Release(ref maxPriorityTargets);
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref boostedTargets);
			return DomainManager.Character.GetElement_Objects(targetCharId);
		}
		Character selectedChar = ((maxPriorityTargets.Count == 0) ? null : DomainManager.Character.GetElement_Objects(maxPriorityTargets.GetRandom(context.Random)));
		context.AdvanceMonthRelatedData.CharIdList.Release(ref maxPriorityTargets);
		context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref boostedTargets);
		return selectedChar;
	}

	private unsafe (int charId, sbyte actionType) SelectDemandActionTarget(DataContext context, HashSet<int> currBlockChars, HashSet<int> currBlockGraves, Predicate<Character> characterFilter, Predicate<Grave> graveFilter, sbyte restrictActionType)
	{
		IRandomSource random = context.Random;
		sbyte selfBehaviorType = GetBehaviorType();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		bool taiwuCanBeHarmed = DomainManager.Taiwu.CanTaiwuBeSneakyHarmfulActionTarget();
		List<int>[] requestActionTargets = context.AdvanceMonthRelatedData.DemandActionTargets.Occupy();
		sbyte currMaxPriorityType = -1;
		int currMaxPriorityScore = 0;
		short scamRateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, restrictActionType, 2);
		short stealRateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, restrictActionType, 1);
		short robRateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, restrictActionType, 3);
		if (currBlockChars != null)
		{
			foreach (int charId in currBlockChars)
			{
				Character targetChar = DomainManager.Character.GetElement_Objects(charId);
				if (targetChar.GetAgeGroup() == 0 || !DomainManager.Character.TryGetRelation(_id, targetChar._id, out var selfToTarget) || !characterFilter(targetChar))
				{
					continue;
				}
				sbyte category = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(selfToTarget.RelationType);
				if (graveFilter != null && random.CheckPercentProb(AiHelper.GeneralActionConstants.StartRobbingChance[selfBehaviorType][category] + robRateAdjust))
				{
					requestActionTargets[3].Add(charId);
				}
				if (charId != taiwuCharId || taiwuCanBeHarmed)
				{
					if (random.CheckPercentProb(AiHelper.GeneralActionConstants.StartScammingChance[selfBehaviorType][category] + scamRateAdjust))
					{
						requestActionTargets[2].Add(charId);
					}
					if (random.CheckPercentProb(AiHelper.GeneralActionConstants.StartStealingChance[selfBehaviorType][category] + stealRateAdjust))
					{
						requestActionTargets[1].Add(charId);
					}
				}
				sbyte currPriorityType = AiHelper.ActionTargetType.GetActionTargetType(selfToTarget.RelationType);
				if (currPriorityType != -1)
				{
					sbyte currPriorityScore = AiHelper.ActionTargetType.PriorityScores[selfBehaviorType][currPriorityType];
					if (currPriorityType == currMaxPriorityType)
					{
						requestActionTargets[0].Add(charId);
					}
					else if (currMaxPriorityScore < currPriorityScore)
					{
						currMaxPriorityType = currPriorityType;
						currMaxPriorityScore = currPriorityScore;
						requestActionTargets[0].Clear();
						requestActionTargets[0].Add(charId);
					}
				}
			}
		}
		if (graveFilter != null && currBlockGraves != null)
		{
			short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, restrictActionType, 4);
			foreach (int graveId in currBlockGraves)
			{
				Grave grave = DomainManager.Character.GetElement_Graves(graveId);
				if (DomainManager.Character.TryGetRelation(_id, graveId, out var selfToTarget2) && graveFilter(grave) && !DomainManager.Character.IsGraveProtected(grave))
				{
					sbyte category2 = AiHelper.ActionTargetRelationCategory.GetTargetRelationCategory(selfToTarget2.RelationType);
					if (random.CheckPercentProb(AiHelper.GeneralActionConstants.StartRobbingFromGraveChance[selfBehaviorType][category2] + rateAdjust))
					{
						requestActionTargets[4].Add(graveId);
					}
				}
			}
		}
		sbyte* targetActionTypeRange = stackalloc sbyte[5];
		int selectableActionTypeCount = 0;
		for (sbyte actionType = 0; actionType < 5; actionType++)
		{
			if (requestActionTargets[actionType].Count > 0)
			{
				targetActionTypeRange[selectableActionTypeCount] = actionType;
				selectableActionTypeCount++;
			}
		}
		if (selectableActionTypeCount <= 0)
		{
			context.AdvanceMonthRelatedData.DemandActionTargets.Release(ref requestActionTargets);
			return (charId: -1, actionType: -1);
		}
		sbyte targetActionType = targetActionTypeRange[random.Next(selectableActionTypeCount)];
		if (DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34) && requestActionTargets[targetActionType].Contains(DomainManager.Taiwu.GetTaiwuCharId()))
		{
			List<int> boostedTargets = context.AdvanceMonthRelatedData.TargetCharIdList.Occupy();
			foreach (int charId2 in requestActionTargets[targetActionType])
			{
				boostedTargets.Add(charId2);
			}
			ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(boostedTargets);
			int targetCharId = boostedTargets.GetRandom(random);
			context.AdvanceMonthRelatedData.TargetCharIdList.Release(ref boostedTargets);
			context.AdvanceMonthRelatedData.DemandActionTargets.Release(ref requestActionTargets);
			return (charId: targetCharId, actionType: targetActionType);
		}
		int selectedCharId = requestActionTargets[targetActionType].GetRandom(random);
		context.AdvanceMonthRelatedData.DemandActionTargets.Release(ref requestActionTargets);
		return (charId: selectedCharId, actionType: targetActionType);
	}

	public ItemBase SelectSpareableItem(DataContext context, sbyte targetGrade, bool allowUsed)
	{
		int currBestGrade = 9;
		List<(ItemBase, int)> selectableItems = context.AdvanceMonthRelatedData.ItemsWithAmount.Occupy();
		IReadOnlyDictionary<ItemKey, int> taiwuGiftItems = DomainManager.Extra.GetTaiwuGiftItems(_id);
		int villagerIdealClothing = ((_organizationInfo.OrgTemplateId == 16) ? GetIdealClothingTemplateId() : (-1));
		int keepClothingCount = ((villagerIdealClothing >= 0 && _equipment.Exist((ItemKey e) => e.IsValid() && e.ItemType == 3 && e.TemplateId == villagerIdealClothing)) ? 1 : 0);
		foreach (var (itemKey2, amount) in _inventory.Items)
		{
			if (!ItemTemplateHelper.IsTransferable(itemKey2.ItemType, itemKey2.TemplateId) || ItemTemplateHelper.GetBaseValue(itemKey2.ItemType, itemKey2.TemplateId) <= 0 || (taiwuGiftItems.TryGetValue(itemKey2, out var giftAmount) && giftAmount >= amount))
			{
				continue;
			}
			ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey2);
			if ((!allowUsed && baseItem.GetCurrDurability() < baseItem.GetMaxDurability()) || TryDetectAttachedPoisons(itemKey2))
			{
				continue;
			}
			if (itemKey2.ItemType == 10)
			{
				if (baseItem.GetItemSubType() == 1001)
				{
					(int, byte) readingInfo = GetCombatSkillBookCurrReadingInfo((GameData.Domains.Item.SkillBook)baseItem);
					if (readingInfo.Item1 < 0 || readingInfo.Item2 < 6)
					{
						continue;
					}
				}
				else
				{
					(int, byte) readingInfo2 = GetLifeSkillBookCurrReadingInfo((GameData.Domains.Item.SkillBook)baseItem);
					if (readingInfo2.Item1 < 0 || readingInfo2.Item2 < 5)
					{
						continue;
					}
				}
			}
			else if (itemKey2.ItemType == 3 && keepClothingCount > 0)
			{
				keepClothingCount--;
				continue;
			}
			if (itemKey2.ItemType == 12 && itemKey2.TemplateId == 267)
			{
				continue;
			}
			sbyte grade = baseItem.GetGrade();
			if (grade == currBestGrade)
			{
				selectableItems.Add((baseItem, amount));
			}
			else if (currBestGrade < targetGrade)
			{
				if (grade >= currBestGrade && grade <= targetGrade)
				{
					currBestGrade = grade;
					selectableItems.Clear();
					selectableItems.Add((baseItem, amount));
				}
			}
			else if (currBestGrade > targetGrade && grade < currBestGrade)
			{
				currBestGrade = grade;
				selectableItems.Clear();
				selectableItems.Add((baseItem, amount));
			}
		}
		ItemBase selectedItem = ((selectableItems.Count == 0) ? null : selectableItems.GetRandom(context.Random).Item1);
		context.AdvanceMonthRelatedData.ItemsWithAmount.Release(ref selectableItems);
		return selectedItem;
	}

	private bool HasBookToReadForExp()
	{
		foreach (ItemKey itemKey in _inventory.Items.Keys)
		{
			if (itemKey.ItemType == 10)
			{
				GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
				if (skillBook.GetCurrDurability() < skillBook.GetMaxDurability())
				{
					return true;
				}
			}
		}
		return false;
	}

	private ItemKey SelectBookToReadForExp(DataContext context)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(_id);
		List<ItemKey> books = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (ItemKey itemKey in _inventory.Items.Keys)
		{
			if (itemKey.ItemType != 10)
			{
				continue;
			}
			GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
			if (skillBook.GetCurrDurability() >= skillBook.GetMaxDurability())
			{
				continue;
			}
			if (skillBook.IsCombatSkillBook())
			{
				if (combatSkills.TryGetValue(skillBook.GetCombatSkillTemplateId(), out var combatSkill) && CombatSkillStateHelper.IsReadNormalPagesMeetConditionOfBreakout(combatSkill.GetReadingState()))
				{
					books.Add(itemKey);
				}
				continue;
			}
			int index = FindLearnedLifeSkillIndex(skillBook.GetLifeSkillTemplateId());
			if (index >= 0 && _learnedLifeSkills[index].IsAllPagesRead())
			{
				books.Add(itemKey);
			}
		}
		ItemKey selectedBook = books.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref books);
		return selectedBook;
	}

	[Obsolete("Use SelectSpareableItem instead.")]
	public ItemKey SelectItemToGive(DataContext context, sbyte targetGrade)
	{
		return SelectSpareableItem(context, targetGrade, allowUsed: true)?.GetItemKey() ?? ItemKey.Invalid;
	}

	public unsafe sbyte GetStealActionPhase(IRandomSource random, Character targetChar, int alertFactor, bool showCheckAnim = false)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		HitOrAvoidInts selfHitValues = GetHitValues();
		HitOrAvoidInts selfAvoidValues = GetAvoidValues();
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		short selfMoveSpeed = GetMoveSpeed();
		HitOrAvoidInts targetHitValues = targetChar.GetHitValues();
		HitOrAvoidInts targetAvoidValues = targetChar.GetAvoidValues();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		short targetMoveSpeed = targetChar.GetMoveSpeed();
		bool haveRing = false;
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (_id == taiwu.GetId())
		{
			DataContext context = DataContextManager.GetCurrentThreadDataContext();
			ItemKey[] equipment = taiwu.GetEquipment();
			for (int slot = 8; slot <= 10; slot++)
			{
				ItemKey accessory = equipment[slot];
				if (accessory.IsValid() && accessory.TemplateId == 298)
				{
					haveRing = true;
					DomainManager.Item.ReduceAccessoryDurability(context, taiwu.GetId(), accessory, 1, 1);
					break;
				}
			}
		}
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(1)
			{
				SelfMainAttributes = mainAttributes,
				SelfHitValues = selfHitValues,
				SelfAvoidValues = selfAvoidValues,
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				SelfMoveSpeed = selfMoveSpeed,
				TargetHitValues = targetHitValues,
				TargetAvoidValues = targetAvoidValues,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				TargetMoveSpeed = targetMoveSpeed,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = 0;
		successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (haveRing)
		{
			successRate = ThiefRingEffect(successRate);
		}
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfHitValues.Items[2], targetAvoidValues.Items[2], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (haveRing)
		{
			successRate = ThiefRingEffect(successRate);
		}
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfMoveSpeed, targetMoveSpeed, alertFactor) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 2, _id, targetChar.GetId());
		if (haveRing)
		{
			successRate = ThiefRingEffect(successRate);
		}
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
		static int ThiefRingEffect(int rate)
		{
			return rate + rate / 4;
		}
	}

	public unsafe sbyte GetScamActionPhase(IRandomSource random, Character targetChar, int alertFactor, bool showCheckAnim = false)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		HitOrAvoidInts selfHitValues = GetHitValues();
		HitOrAvoidInts selfAvoidValues = GetAvoidValues();
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		short selfMaxLifeSkillAttainment = GetLifeSkillAttainments().GetMaxLifeSkillValue();
		HitOrAvoidInts targetHitValues = targetChar.GetHitValues();
		HitOrAvoidInts targetAvoidValues = targetChar.GetAvoidValues();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		short targetMaxLifeSkillAttainment = targetChar.GetLifeSkillAttainments().GetMaxLifeSkillValue();
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(0)
			{
				SelfMainAttributes = mainAttributes,
				SelfHitValues = selfHitValues,
				SelfAvoidValues = selfAvoidValues,
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				TargetHitValues = targetHitValues,
				TargetAvoidValues = targetAvoidValues,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = 0;
		successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfHitValues.Items[3], targetAvoidValues.Items[3], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfMaxLifeSkillAttainment, targetMaxLifeSkillAttainment, alertFactor, 50) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 3, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	public unsafe sbyte GetRobActionPhase(IRandomSource random, Character targetChar, int alertFactor, bool showCheckAnim = false)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		HitOrAvoidInts selfHitValues = GetHitValues();
		HitOrAvoidInts selfAvoidValues = GetAvoidValues();
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		int selfCombatPower = GetCombatPower();
		HitOrAvoidInts targetHitValues = targetChar.GetHitValues();
		HitOrAvoidInts targetAvoidValues = targetChar.GetAvoidValues();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		int targetCombatPower = targetChar.GetCombatPower();
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(2)
			{
				SelfMainAttributes = mainAttributes,
				SelfHitValues = selfHitValues,
				SelfAvoidValues = selfAvoidValues,
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				TargetHitValues = targetHitValues,
				TargetAvoidValues = targetAvoidValues,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				CombatPowerHigher = (selfCombatPower > targetCombatPower),
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = 0;
		successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfHitValues.Items[0], targetAvoidValues.Items[0], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfCombatPower, targetCombatPower, alertFactor, 50) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 3, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	public unsafe sbyte GetStealLifeSkillActionPhase(IRandomSource random, Character targetChar, sbyte lifeSkillType, sbyte grade, bool showCheckAnim = false)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		HitOrAvoidInts selfHitValues = GetHitValues();
		HitOrAvoidInts selfAvoidValues = GetAvoidValues();
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		LifeSkillShorts selfLifeSkillQualifications = GetLifeSkillQualifications();
		HitOrAvoidInts targetHitValues = targetChar.GetHitValues();
		HitOrAvoidInts targetAvoidValues = targetChar.GetAvoidValues();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		short qualificationReq = SkillGradeData.Instance[grade].PracticeQualificationRequirement;
		int alertFactor = targetChar.GetGradeAlertFactor(grade, 1);
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(6)
			{
				SelfMainAttributes = mainAttributes,
				SelfHitValues = selfHitValues,
				SelfAvoidValues = selfAvoidValues,
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				SelfLifeSkillQualities = selfLifeSkillQualifications,
				TargetHitValues = targetHitValues,
				TargetAvoidValues = targetAvoidValues,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				StealSkillGrade = grade,
				StealLifeSkillType = lifeSkillType,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfHitValues.Items[1], targetAvoidValues.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfLifeSkillQualifications.Items[lifeSkillType], qualificationReq, alertFactor) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 2, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	public unsafe sbyte GetStealCombatSkillActionPhase(IRandomSource random, Character targetChar, sbyte combatSkillType, sbyte grade, bool showCheckAnim = false)
	{
		MainAttributes mainAttributes = GetMaxMainAttributes();
		HitOrAvoidInts selfHitValues = GetHitValues();
		HitOrAvoidInts selfAvoidValues = GetAvoidValues();
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		CombatSkillShorts selfCombatSkillQualifications = GetCombatSkillQualifications();
		HitOrAvoidInts targetHitValues = targetChar.GetHitValues();
		HitOrAvoidInts targetAvoidValues = targetChar.GetAvoidValues();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		short qualificationReq = SkillGradeData.Instance[grade].PracticeQualificationRequirement;
		int alertFactor = targetChar.GetGradeAlertFactor(grade, 1);
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(7)
			{
				SelfMainAttributes = mainAttributes,
				SelfHitValues = selfHitValues,
				SelfAvoidValues = selfAvoidValues,
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				SelfCombatSkillQualities = selfCombatSkillQualifications,
				TargetHitValues = targetHitValues,
				TargetAvoidValues = targetAvoidValues,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				StealSkillGrade = grade,
				StealCombatSkillType = combatSkillType,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfHitValues.Items[1], targetAvoidValues.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfCombatSkillQualifications.Items[combatSkillType], qualificationReq, alertFactor) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 2, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	public unsafe sbyte GetPoisonActionPhase(IRandomSource random, Character targetChar, int alertFactor = 100, bool showCheckAnim = false)
	{
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		LifeSkillShorts selfLifeSkillAttainments = GetLifeSkillAttainments();
		OuterAndInnerInts selfPenetrations = GetPenetrations();
		OuterAndInnerInts selfPenetrationResists = GetPenetrationResists();
		short selfCastSpeed = GetCastSpeed();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		LifeSkillShorts targetLifeSkillAttainments = targetChar.GetLifeSkillAttainments();
		OuterAndInnerInts targetPenetrations = targetChar.GetPenetrations();
		OuterAndInnerInts targetPenetrationResists = targetChar.GetPenetrationResists();
		short targetCastSpeed = targetChar.GetCastSpeed();
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(3)
			{
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				SelfLifeSkillAttainments = selfLifeSkillAttainments,
				SelfPenetrations = selfPenetrations,
				SelfPenetrationResists = selfPenetrationResists,
				SelfCastSpeed = selfCastSpeed,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				TargetLifeSkillAttainments = targetLifeSkillAttainments,
				TargetPenetrations = targetPenetrations,
				TargetPenetrationResists = targetPenetrationResists,
				TargetCastSpeed = targetCastSpeed,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfCastSpeed, targetCastSpeed, alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfLifeSkillAttainments.Items[9], targetLifeSkillAttainments.Items[9], alertFactor) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 2, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	public unsafe sbyte GetPlotHarmActionPhase(IRandomSource random, Character targetChar, int alertFactor = 100, bool showCheckAnim = false)
	{
		CombatSkillShorts selfCombatSkillAttainments = GetCombatSkillAttainments();
		LifeSkillShorts selfLifeSkillAttainments = GetLifeSkillAttainments();
		OuterAndInnerInts selfPenetrations = GetPenetrations();
		OuterAndInnerInts selfPenetrationResists = GetPenetrationResists();
		short selfAttackSpeed = GetAttackSpeed();
		CombatSkillShorts targetCombatSkillAttainments = targetChar.GetCombatSkillAttainments();
		LifeSkillShorts targetLifeSkillAttainments = targetChar.GetLifeSkillAttainments();
		OuterAndInnerInts targetPenetrations = targetChar.GetPenetrations();
		OuterAndInnerInts targetPenetrationResists = targetChar.GetPenetrationResists();
		short targetAttackSpeed = targetChar.GetAttackSpeed();
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData = new EventInteractCheckData(4)
			{
				SelfCombatSkillAttainments = selfCombatSkillAttainments,
				SelfLifeSkillAttainments = selfLifeSkillAttainments,
				SelfPenetrations = selfPenetrations,
				SelfPenetrationResists = selfPenetrationResists,
				SelfAttackSpeed = selfAttackSpeed,
				TargetCombatSkillAttainments = targetCombatSkillAttainments,
				TargetLifeSkillAttainments = targetLifeSkillAttainments,
				TargetPenetrations = targetPenetrations,
				TargetPenetrationResists = targetPenetrationResists,
				TargetAttackSpeed = targetAttackSpeed,
				TargetAlertFactor = alertFactor,
				SelfCharacterId = _id,
				TargetCharacterId = targetChar.GetId(),
				SelfNameRelatedData = DomainManager.Character.GetNameRelatedData(_id),
				TargetNameRelatedData = DomainManager.Character.GetNameRelatedData(targetChar.GetId())
			};
			DomainManager.TaiwuEvent.ShowInteractCheckAnimation = true;
		}
		int successRate = GetPhaseBaseSuccessRate(selfCombatSkillAttainments.Items[1], targetCombatSkillAttainments.Items[1], alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 4, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 1;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 0;
			}
			return 1;
		}
		successRate = GetPhaseBaseSuccessRate(selfAttackSpeed, targetAttackSpeed, alertFactor);
		successRate = GetAdjustedSuccessRate(successRate, 0, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 2;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 1;
			}
			return 2;
		}
		successRate = GetPhaseBaseSuccessRate(selfLifeSkillAttainments.Items[8], targetLifeSkillAttainments.Items[8], alertFactor) / 3;
		successRate = GetAdjustedSuccessRate(successRate, 2, _id, targetChar.GetId());
		if (showCheckAnim)
		{
			DomainManager.TaiwuEvent.InteractCheckData.PhaseProbList.Add(successRate);
		}
		if (!random.CheckPercentProb(successRate))
		{
			if (showCheckAnim)
			{
				DomainManager.TaiwuEvent.InteractCheckData.FailPhase = 3;
				DomainManager.TaiwuEvent.InteractCheckData.FailPhaseIndex = 2;
			}
			return 3;
		}
		return 5;
	}

	private static int GetPhaseBaseSuccessRate(int selfVal, int targetVal, int targetAlertFactor)
	{
		return GetPhaseBaseSuccessRate(selfVal, targetVal, targetAlertFactor, GlobalConfig.Instance.HarmfulActionPhaseBaseSuccessRate);
	}

	private static int GetPhaseBaseSuccessRate(int selfVal, int targetVal, int targetAlertFactor, int baseRate)
	{
		if (targetVal <= 0)
		{
			targetVal = 1;
		}
		if (targetAlertFactor < 25)
		{
			targetAlertFactor = 25;
		}
		return selfVal * baseRate / targetVal * 100 / targetAlertFactor;
	}

	private unsafe int GetAdjustedSuccessRate(int baseSuccessRate, sbyte personalityType, int charId, int targetCharId)
	{
		Personalities personalities = GetPersonalities();
		int factor = personalities.Items[personalityType] + 100;
		int result = baseSuccessRate * factor / 100;
		if (charId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return result;
		}
		int alertness = DomainManager.Character.GetAlertnessValue(targetCharId);
		sbyte level = CharacterAlertnessData.GetLevel(alertness);
		int effectRate = CharacterAlertnessData.GetEffectInteract(level);
		return result * effectRate / 100;
	}

	public Character GetGuardForCalculation(IRandomSource random)
	{
		if (_organizationInfo.SettlementId >= 0 && Config.Organization.Instance[_organizationInfo.OrgTemplateId].IsCivilian && DomainManager.Character.HasGuard(_id, this))
		{
			sbyte targetFameType = GetFameType();
			bool isHeretic = ((targetFameType == -2) ? random.NextBool() : (targetFameType < 3));
			Location settlementLocation = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId).GetLocation();
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlementLocation.AreaId);
			return DomainManager.Character.GetPregeneratedCityTownGuard(stateTemplateId, isHeretic, _organizationInfo.Grade);
		}
		return this;
	}

	public int GetItemAlertFactor(ItemKey itemKey, int amount)
	{
		if (itemKey.ItemType == 12)
		{
			if (itemKey.TemplateId == 475)
			{
				int charId = itemKey.Id;
				Character characterData = DomainManager.Character.GetElement_Objects(charId);
				return (int)Math.Clamp(Wager.CharacterValue(characterData.GetFame(), characterData.GetAttraction(), characterData.GetOrganizationInfo().Grade, characterData.GetDisplayingGender(), characterData.GetPhysiologicalAge()), 0L, 2147483647L);
			}
			if (itemKey.TemplateId != 388 && itemKey.TemplateId != 389)
			{
			}
		}
		if (itemKey.ItemType == 10)
		{
			return 80 + Config.SkillBook.Instance[itemKey.TemplateId].BaseValue / 75;
		}
		int value = ItemTemplateHelper.GetBaseValue(itemKey.ItemType, itemKey.TemplateId);
		return GetValueAlertFactor(value, amount);
	}

	public int GetResourceAlertFactor(sbyte resourceType)
	{
		int worth = ResourceTypeHelper.ResourceAmountToWorth(resourceType, _resources[resourceType]);
		return worth / 75;
	}

	public int GetCaptiveAlertFactor(int charId)
	{
		Character charData = DomainManager.Character.GetElement_Objects(charId);
		Wager.CharacterValue(charData.GetFame(), charData.GetAttraction(), charData.GetOrganizationInfo().Grade, charData.GetDisplayingGender(), charData.GetPhysiologicalAge());
		return 0;
	}

	public int GetGradeAlertFactor(sbyte grade, int amount)
	{
		sbyte gradeAlertness = GlobalConfig.Instance.CharacterGradeAlertness[_organizationInfo.Grade];
		return Math.Clamp(100 + (grade - gradeAlertness) * amount * 100, 100, 300);
	}

	public int GetValueAlertFactor(int value, int amount)
	{
		long result = (long)(80 + value / 75) * (long)(50 + 50 * amount) / 100;
		return (int)Math.Clamp(result, 0L, 2147483647L);
	}

	private void OfflineCalcGeneralAction_RedEyeWugKing(DataContext context, PeriAdvanceMonthFixedActionModification mod, HashSet<int> currBlockChars)
	{
		if (!TryGetWugKingDriveData(0, out var driveData) || driveData.DriveType == 0 || !IsWugKingDriveActive(0, DomainManager.World.GetCurrDate(), 3) || GetWugKingSlotIndex(0) < 0 || currBlockChars.Count <= 1)
		{
			return;
		}
		int targetCharId = SelectRandomCharacterFromBlock(currBlockChars, context.Random);
		if (targetCharId >= 0 && DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
		{
			mod.PerformedActions = new List<(Character, IGeneralAction)>();
			if (driveData.DriveType == 1)
			{
				OfflineCalcRedEyeWugKing_FriendlyAction(context, mod, targetChar);
			}
			else
			{
				OfflineCalcRedEyeWugKing_HostileAction(context, mod, targetChar);
			}
		}
	}

	private unsafe void OfflineCalcRedEyeWugKing_FriendlyAction(DataContext context, PeriAdvanceMonthFixedActionModification mod, Character targetChar)
	{
		IRandomSource random = context.Random;
		CombatResources usableCombatResources = DomainManager.Character.GetUsableCombatResources(_id);
		List<int> availableActions = new List<int>();
		AdoreAction adoreAction = new AdoreAction();
		if (adoreAction.CheckValid(this, targetChar))
		{
			availableActions.Add(0);
		}
		BecomeFriendAction becomeFriendAction = new BecomeFriendAction();
		if (becomeFriendAction.CheckValid(this, targetChar))
		{
			availableActions.Add(1);
		}
		BecomeSwornAction becomeSwornAction = new BecomeSwornAction();
		if (becomeSwornAction.CheckValid(this, targetChar))
		{
			availableActions.Add(2);
		}
		foreach (EHealActionType type in AllHealActions)
		{
			if (CalcHealAttainment(type) >= 200 && usableCombatResources.Get(type) > 0 && targetChar.NeedHealAction(type) && targetChar.CalcHealCostHerb(type) <= _resources.Items[5])
			{
				availableActions.Add(3);
				break;
			}
		}
		for (sbyte resType = 0; resType < 8; resType++)
		{
			if (GetResource(resType) >= 100)
			{
				availableActions.Add(4);
				break;
			}
		}
		if (_inventory.Items.Count > 0)
		{
			availableActions.Add(5);
		}
		if (CanTeachLifeSkill(targetChar) || CanTeachCombatSkill(targetChar))
		{
			availableActions.Add(6);
		}
		short selfAge = GetCurrAge();
		short targetAge = targetChar.GetCurrAge();
		if (targetAge - selfAge >= 10)
		{
			AdoptAsChildAction adoptAsChildAction = new AdoptAsChildAction();
			if (adoptAsChildAction.CheckValid(this, targetChar))
			{
				availableActions.Add(8);
			}
		}
		else if (selfAge - targetAge >= 10)
		{
			AdoptChildAction adoptChildAction = new AdoptChildAction();
			if (adoptChildAction.CheckValid(this, targetChar))
			{
				availableActions.Add(8);
			}
		}
		if (IsValidForLifeSkillAwakening(targetChar))
		{
			availableActions.Add(9);
		}
		if (availableActions.Count == 0)
		{
			return;
		}
		switch (availableActions[random.Next(0, availableActions.Count)])
		{
		case 0:
			mod.PerformedActions.Add((targetChar, new AdoreAction()));
			break;
		case 1:
			mod.PerformedActions.Add((targetChar, new BecomeFriendAction()));
			break;
		case 2:
			mod.PerformedActions.Add((targetChar, new BecomeSwornAction()));
			break;
		case 3:
		{
			foreach (EHealActionType type2 in AllHealActions)
			{
				if (CalcHealAttainment(type2) >= 200 && usableCombatResources.Get(type2) > 0 && targetChar.NeedHealAction(type2) && targetChar.CalcHealCostHerb(type2) <= _resources[5])
				{
					mod.PerformedActions.Add((targetChar, new SocialStatusHealAction
					{
						Type = type2,
						HerbAmount = targetChar.CalcHealCostHerb(type2)
					}));
					break;
				}
			}
			break;
		}
		case 4:
		{
			for (sbyte resType2 = 0; resType2 < 8; resType2++)
			{
				int amount2 = random.Next(100, 500);
				if (GetResource(resType2) >= amount2)
				{
					mod.PerformedActions.Add((targetChar, new GiveResourceAction
					{
						ResourceType = resType2,
						Amount = amount2
					}));
					break;
				}
			}
			break;
		}
		case 5:
		{
			List<ItemKey> items = new List<ItemKey>(_inventory.Items.Keys);
			if (items.Count > 0)
			{
				ItemKey selectedItem = items[random.Next(items.Count)];
				int amount = Math.Min(1, _inventory.Items[selectedItem]);
				mod.PerformedActions.Add((targetChar, new GiveItemAction
				{
					TargetItem = selectedItem,
					Amount = amount,
					RefusePoisonousItem = false
				}));
			}
			break;
		}
		case 6:
			AddTeachSkillAction(context, mod, targetChar, -1);
			break;
		case 8:
			if (targetAge - selfAge >= 10)
			{
				mod.PerformedActions.Add((targetChar, new AdoptAsChildAction()));
			}
			else
			{
				mod.PerformedActions.Add((targetChar, new AdoptChildAction()));
			}
			break;
		case 9:
		{
			LifeSkillShorts lifeSkillQualification = GetBaseLifeSkillQualifications();
			LifeSkillShorts lifeSkillAttainments = GetLifeSkillAttainments();
			LifeSkillShorts targetLifeSkillQualifications = targetChar.GetBaseLifeSkillQualifications();
			Span<sbyte> canImproveLifeSkillTypes = stackalloc sbyte[16];
			int canImproveCount = 0;
			for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
			{
				if (targetLifeSkillQualifications.Items[lifeSkillType] < 90)
				{
					canImproveLifeSkillTypes[canImproveCount] = lifeSkillType;
					canImproveCount++;
				}
			}
			if (canImproveCount <= 0)
			{
				break;
			}
			sbyte selectedLifeSkillType = canImproveLifeSkillTypes[random.Next(canImproveCount)];
			Span<sbyte> religiousLifeSkillTypes = stackalloc sbyte[LifeSkillType.ReligiousTypes.Length];
			int religiousLifeSkillTypeCount = 0;
			sbyte[] religiousTypes = LifeSkillType.ReligiousTypes;
			foreach (sbyte lifeSkillType2 in religiousTypes)
			{
				if (lifeSkillQualification.Items[lifeSkillType2] > targetLifeSkillQualifications.Items[lifeSkillType2] && lifeSkillAttainments.Items[lifeSkillType2] >= 200)
				{
					religiousLifeSkillTypes[religiousLifeSkillTypeCount] = lifeSkillType2;
					religiousLifeSkillTypeCount++;
				}
			}
			if (religiousLifeSkillTypeCount > 0)
			{
				sbyte religiousLifeSkillType = religiousLifeSkillTypes[random.Next(religiousLifeSkillTypeCount)];
				mod.PerformedActions.Add((targetChar, new LifeSkillAwakeningAction
				{
					AwakeningLifeSkillType = religiousLifeSkillType,
					IncreasedLifeSkillType = selectedLifeSkillType
				}));
			}
			break;
		}
		case 7:
			break;
		}
	}

	private void OfflineCalcRedEyeWugKing_HostileAction(DataContext context, PeriAdvanceMonthFixedActionModification mod, Character targetChar)
	{
		IRandomSource random = context.Random;
		List<int> availableActions = new List<int>();
		MakeEnemyAction makeEnemyAction = new MakeEnemyAction();
		if (makeEnemyAction.CheckValid(this, targetChar))
		{
			availableActions.Add(0);
		}
		SeverAdoptiveParentAction severAdoptiveParentAction = new SeverAdoptiveParentAction();
		if (severAdoptiveParentAction.CheckValid(this, targetChar))
		{
			availableActions.Add(1);
		}
		SeverAdoptiveChildAction severAdoptiveChildAction = new SeverAdoptiveChildAction();
		if (severAdoptiveChildAction.CheckValid(this, targetChar))
		{
			availableActions.Add(2);
		}
		SeverFriendshipAction severFriendshipAction = new SeverFriendshipAction();
		if (severFriendshipAction.CheckValid(this, targetChar))
		{
			availableActions.Add(3);
		}
		BreakupMutuallyAction breakupMutuallyAction = new BreakupMutuallyAction();
		if (breakupMutuallyAction.CheckValid(this, targetChar))
		{
			availableActions.Add(4);
		}
		DivorceAction divorceAction = new DivorceAction();
		if (divorceAction.CheckValid(this, targetChar))
		{
			availableActions.Add(5);
		}
		availableActions.Add(6);
		availableActions.Add(7);
		for (sbyte resType = 0; resType < 8; resType++)
		{
			if (targetChar.GetResource(resType) >= 100)
			{
				availableActions.Add(8);
				break;
			}
		}
		if (targetChar.GetInventory().Items.Count > 0)
		{
			availableActions.Add(9);
		}
		if (availableActions.Count == 0)
		{
			return;
		}
		switch (availableActions[random.Next(0, availableActions.Count)])
		{
		case 0:
			mod.PerformedActions.Add((targetChar, new MakeEnemyAction()));
			break;
		case 1:
			mod.PerformedActions.Add((targetChar, new SeverAdoptiveParentAction()));
			break;
		case 2:
			mod.PerformedActions.Add((targetChar, new SeverAdoptiveChildAction()));
			break;
		case 3:
			mod.PerformedActions.Add((targetChar, new SeverFriendshipAction()));
			break;
		case 4:
			mod.PerformedActions.Add((targetChar, new BreakupMutuallyAction()));
			break;
		case 5:
			mod.PerformedActions.Add((targetChar, new DivorceAction()));
			break;
		case 6:
		{
			sbyte actionPhase2 = GetPoisonActionPhase(random, targetChar);
			mod.PerformedActions.Add((targetChar, new PoisonAction
			{
				PoisonItem = ItemKey.Invalid,
				ActionPhase = actionPhase2
			}));
			break;
		}
		case 7:
		{
			sbyte actionPhase = GetPlotHarmActionPhase(random, targetChar);
			mod.PerformedActions.Add((targetChar, new PlotHarmAction
			{
				HarmItem = ItemKey.Invalid,
				ActionPhase = actionPhase
			}));
			break;
		}
		case 8:
		{
			for (sbyte resType2 = 0; resType2 < 8; resType2++)
			{
				int targetAmount = targetChar.GetResource(resType2);
				if (targetAmount >= 100)
				{
					int amount = random.Next(100, Math.Min(500, targetAmount));
					sbyte phase2 = GetPlotHarmActionPhase(random, targetChar);
					mod.PerformedActions.Add((targetChar, new RobResourceAction
					{
						ResourceType = resType2,
						Amount = amount,
						Phase = phase2
					}));
					break;
				}
			}
			break;
		}
		case 9:
		{
			List<ItemKey> items = new List<ItemKey>(targetChar.GetInventory().Items.Keys);
			if (items.Count > 0)
			{
				ItemKey selectedItem = items[random.Next(0, items.Count)];
				sbyte phase = GetPlotHarmActionPhase(random, targetChar);
				mod.PerformedActions.Add((targetChar, new RobItemAction
				{
					TargetItem = selectedItem,
					Amount = 1,
					Phase = phase
				}));
			}
			break;
		}
		}
	}

	private int SelectRandomCharacterFromBlock(HashSet<int> currBlockChars, IRandomSource random)
	{
		List<int> candidates = new List<int>();
		foreach (int charId in currBlockChars)
		{
			if (charId != _id)
			{
				candidates.Add(charId);
			}
		}
		if (candidates.Count == 0)
		{
			return -1;
		}
		return candidates.GetRandom(random);
	}

	public void PeriAdvanceMonth_MixedPoisonEffect(DataContext context)
	{
		List<(sbyte, int)> mixedPoisonInfoList = null;
		foreach (MixPoisonEffectItem mixedPoisonEffect in (IEnumerable<MixPoisonEffectItem>)MixPoisonEffect.Instance)
		{
			sbyte mixedPoisonType = MixedPoisonType.FromMedicineTemplateId(mixedPoisonEffect.MedicineId);
			int markCount = GetMixedPoisonTypeRelatedMarkCount(mixedPoisonType);
			if (markCount > 0 && (mixedPoisonType != 22 || (_location.IsValid() && _kidnapperId < 0)))
			{
				if (mixedPoisonInfoList == null)
				{
					mixedPoisonInfoList = new List<(sbyte, int)>();
				}
				mixedPoisonInfoList.Add((mixedPoisonType, markCount));
			}
		}
		if (mixedPoisonInfoList != null)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthMixedPoisonEffect);
			recorder.RecordParameterClass(this);
			recorder.RecordParameterClass(mixedPoisonInfoList);
		}
	}

	public static void ComplementPeriAdvanceMonth_MixedPoisonEffect(DataContext context, Character character, List<(sbyte mixedPoisonType, int markCount)> mixedPoisonInfoList)
	{
		if (!DomainManager.Character.IsCharacterAlive(character._id))
		{
			return;
		}
		Character taiwu = DomainManager.Taiwu.GetTaiwu();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		foreach (var (mixedPoisonType, markCount) in mixedPoisonInfoList)
		{
			switch (mixedPoisonType)
			{
			case 15:
				character.ChangeHealth(context, -markCount * 12);
				lifeRecordCollection.AddMixPoisonHotRedRotten(character._id, currDate, character._location);
				break;
			case 24:
				character.MakeExistingInjuriesWorse(context, isInnerInjury: false, (sbyte)(markCount / 3));
				lifeRecordCollection.AddMixPoisonHotRedCold(character._id, currDate, character._location);
				break;
			case 33:
			{
				int delta = -character._currNeili * markCount * 5 / 100;
				character.ChangeCurrNeili(context, delta);
				lifeRecordCollection.AddMixPoisonHotGloomyIllusory(character._id, currDate, character._location);
				break;
			}
			case 26:
			{
				List<short> equippedSkills = ObjectPool<List<short>>.Instance.Get();
				CombatSkillEquipment skillEquipment = character.GetCombatSkillEquipment();
				skillEquipment.GetValidSkills(equippedSkills);
				if (equippedSkills.Count > 0)
				{
					for (int j = 0; j < markCount; j++)
					{
						short skillId = equippedSkills.GetRandom(context.Random);
						DomainManager.Combat.AddGoneMadInjuryOutOfCombat(context, character, skillId);
					}
				}
				ObjectPool<List<short>>.Instance.Return(equippedSkills);
				lifeRecordCollection.AddMixPoisonRottenGloomyCold(character._id, currDate, character._location);
				break;
			}
			case 27:
				character.ChangeDisorderOfQiRandomRecovery(context, (short)Math.Clamp(markCount * 500, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue));
				lifeRecordCollection.AddMixPoisonHotGloomyCold(character._id, currDate, character._location);
				break;
			case 28:
				character.MakeExistingInjuriesWorse(context, isInnerInjury: true, (sbyte)(markCount / 3));
				lifeRecordCollection.AddMixPoisonRedGloomyCold(character._id, currDate, character._location);
				break;
			case 17:
			{
				List<(ItemBase, int)> lostItems = context.AdvanceMonthRelatedData.ItemsWithAmount.Occupy();
				CharacterDomain.GetLostItemsByAmount(context, markCount, character._inventory.Items, lostItems, character._id == taiwu._id);
				Location location2 = character.GetValidLocation();
				List<MapBlockData> nearbyBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
				DomainManager.Map.GetRealNeighborBlocks(location2.AreaId, location2.BlockId, nearbyBlocks, 2, includeCenter: true);
				if (character._id == taiwu._id)
				{
					foreach (var item3 in lostItems)
					{
						ItemBase item = item3.Item1;
						monthlyNotifications.AddPoisonMakeLoss(taiwu._id, location2, item.GetItemType(), item.GetTemplateId());
					}
				}
				int deltaHappiness = 0;
				foreach (var item4 in lostItems)
				{
					ItemBase item2 = item4.Item1;
					int amount = item4.Item2;
					ItemKey itemKey = item2.GetItemKey();
					character.RemoveInventoryItem(context, itemKey, amount, deleteItem: false);
					lifeRecordCollection.AddMixPoisonHotRottenGloomy(character._id, currDate, location2, itemKey.ItemType, itemKey.TemplateId);
					MapBlockData block = nearbyBlocks.GetRandom(context.Random);
					DomainManager.Map.AddBlockItem(context, block, itemKey, amount);
					deltaHappiness -= item2.GetHappinessChange() * amount;
				}
				context.AdvanceMonthRelatedData.ItemsWithAmount.Release(ref lostItems);
				ObjectPool<List<MapBlockData>>.Instance.Return(nearbyBlocks);
				character.ChangeHappiness(context, deltaHappiness);
				break;
			}
			case 21:
			{
				Location location3 = character._location;
				if (!location3.IsValid())
				{
					location3 = character.GetValidLocation();
				}
				MapBlockData currBlockData2 = DomainManager.Map.GetBlock(location3);
				if (currBlockData2.CharacterSet != null)
				{
					foreach (int charId3 in currBlockData2.CharacterSet)
					{
						if (charId3 != character._id)
						{
							Character targetChar4 = DomainManager.Character.GetElement_Objects(charId3);
							targetChar4.ChangePoisoned(context, 4, 3, 100 + markCount * 20);
						}
					}
				}
				if (location3.Equals(taiwu._location))
				{
					HashSet<int> taiwuGroup2 = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
					foreach (int charId4 in taiwuGroup2)
					{
						if (charId4 != character._id)
						{
							Character targetChar5 = DomainManager.Character.GetElement_Objects(charId4);
							targetChar5.ChangePoisoned(context, 4, 3, 100 + markCount * 20);
						}
					}
				}
				if (character._id == taiwu._id)
				{
					monthlyNotifications.AddRottenPoisonDiffuse(character._id, location3);
				}
				lifeRecordCollection.AddMixPoisonRedRottenCold(character._id, currDate, location3);
				break;
			}
			case 22:
			{
				if (character.GetAgeGroup() == 0)
				{
					break;
				}
				List<int> charIdList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
				character.GetPotentialHarmfulActionTargets(charIdList);
				lifeRecordCollection.AddMixPoisonHotRedIllusory(character._id, currDate, character._location);
				character.ActivateAdvanceMonthStatus(7);
				for (int i = 0; i < markCount; i++)
				{
					Character targetChar3;
					while (true)
					{
						if (charIdList.Count == 0)
						{
							context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
							return;
						}
						int index = context.Random.Next(charIdList.Count);
						int targetCharId = charIdList[index];
						if (DomainManager.Character.TryGetElement_Objects(targetCharId, out targetChar3) && targetChar3._location.IsValid())
						{
							break;
						}
						CollectionUtils.SwapAndRemove(charIdList, index);
						bool flag = true;
					}
					character.PerformHarmfulActionToTarget(context, targetChar3);
					if (!DomainManager.Character.IsCharacterAlive(character._id) || !character._location.IsValid())
					{
						break;
					}
				}
				context.AdvanceMonthRelatedData.CharIdList.Release(ref charIdList);
				break;
			}
			case 23:
				if (character.GetAgeGroup() != 0)
				{
					DomainManager.Character.TryAddCharacterAvatarSnapshot(context, character);
					character._avatar.AdjustToBaseCharm(context.Random, (short)Math.Max(0, character._avatar.BaseCharm - markCount * 50));
					character.SetAvatar(character._avatar, context);
					if (character._id == taiwu._id)
					{
						monthlyNotifications.AddPoisonDestroyFace(character._id);
					}
					lifeRecordCollection.AddMixPoisonHotRedGloomy(character._id, currDate, character._location);
				}
				break;
			case 31:
			{
				Location location = character._location;
				if (!location.IsValid())
				{
					location = character.GetValidLocation();
				}
				MapBlockData currBlockData = DomainManager.Map.GetBlock(location);
				if (currBlockData.CharacterSet != null)
				{
					foreach (int charId in currBlockData.CharacterSet)
					{
						if (charId != character._id)
						{
							Character targetChar = DomainManager.Character.GetElement_Objects(charId);
							targetChar.ChangePoisoned(context, 5, 3, 100 + markCount * 20);
						}
					}
				}
				if (location.Equals(taiwu._location))
				{
					HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
					foreach (int charId2 in taiwuGroup)
					{
						if (charId2 != character._id)
						{
							Character targetChar2 = DomainManager.Character.GetElement_Objects(charId2);
							targetChar2.ChangePoisoned(context, 5, 3, 100 + markCount * 20);
						}
					}
				}
				if (character._id == taiwu._id)
				{
					monthlyNotifications.AddIllusoryPoisonDiffuse(character._id, location);
				}
				lifeRecordCollection.AddMixPoisonRedColdIllusory(character._id, currDate, location);
				break;
			}
			}
		}
		if (character.IsTaiwu())
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 237);
		}
	}

	public void GetPotentialHarmfulActionTargets(List<int> charIdList)
	{
		charIdList.Clear();
		if (_location.IsValid())
		{
			MapBlockData currBlockData = DomainManager.Map.GetBlock(_location);
			if (currBlockData.CharacterSet != null)
			{
				GetPotentialHarmfulActionTargetsInSet(currBlockData.CharacterSet, charIdList);
			}
			if (_location.Equals(DomainManager.Taiwu.GetTaiwu()._location))
			{
				HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
				GetPotentialHarmfulActionTargetsInSet(taiwuGroup, charIdList);
			}
		}
	}

	private void GetPotentialHarmfulActionTargetsInSet(HashSet<int> allCharSet, List<int> charIdList)
	{
		foreach (int charId in allCharSet)
		{
			if (charId != _id && DomainManager.Character.TryGetElement_Objects(charId, out var targetChar) && targetChar.GetAgeGroup() != 0)
			{
				charIdList.Add(charId);
			}
		}
	}

	private unsafe void PerformHarmfulActionToTarget(DataContext context, Character targetChar)
	{
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		IRandomSource random = context.Random;
		sbyte* actionTypes = stackalloc sbyte[4];
		for (sbyte i = 0; i < 4; i++)
		{
			actionTypes[i] = i;
		}
		CollectionUtils.Shuffle(context.Random, actionTypes, 4);
		for (int j = 0; j < 4; j++)
		{
			switch (actionTypes[j])
			{
			case 0:
			{
				bool success2 = DomainManager.Character.HandleAttackAction(context, this, targetChar);
				if (_id == taiwuCharId)
				{
					if (success2)
					{
						monthlyNotifications.AddPoisonDisturbMindAttckSuccess(_id, _location, targetChar._id);
					}
					else
					{
						monthlyNotifications.AddPoisonDisturbMindAttckFalse(_id, _location, targetChar._id);
					}
				}
				return;
			}
			case 1:
			{
				bool success3 = DomainManager.Character.HandlePoisonAction(context, this, targetChar, ItemKey.Invalid, -1);
				if (_id == taiwuCharId)
				{
					if (success3)
					{
						monthlyNotifications.AddPoisonDisturbMindEmpoisonSuccess(_id, _location, targetChar._id);
					}
					else
					{
						monthlyNotifications.AddPoisonDisturbMindEmpoisonFalse(_id, _location, targetChar._id);
					}
				}
				return;
			}
			case 2:
			{
				bool success4 = DomainManager.Character.HandlePlotHarmAction(context, this, targetChar, ItemKey.Invalid, -1);
				if (_id == taiwuCharId)
				{
					if (success4)
					{
						monthlyNotifications.AddPoisonDisturbMindSneakAttckSuccess(_id, _location, targetChar._id);
					}
					else
					{
						monthlyNotifications.AddPoisonDisturbMindSneakAttckFalse(_id, _location, targetChar._id);
					}
				}
				return;
			}
			case 3:
			{
				if (GetAgeGroup() != 2 || targetChar.GetAgeGroup() != 2)
				{
					break;
				}
				bool success = DomainManager.Character.HandleRapeAction(context, this, targetChar);
				if (_id == taiwuCharId)
				{
					if (success)
					{
						monthlyNotifications.AddPoisonDisturbMindRapeSuccess(_id, _location, targetChar._id);
					}
					else
					{
						monthlyNotifications.AddPoisonDisturbMindRapeFalse(_id, _location, targetChar._id);
					}
				}
				return;
			}
			}
		}
	}

	public bool IsOnRegularSettlement()
	{
		Location location = _location;
		if (!location.IsValid())
		{
			location = GetValidLocation();
		}
		if (location.AreaId >= 45)
		{
			return false;
		}
		MapBlockData currBlock = DomainManager.Map.GetBlockData(location.AreaId, location.BlockId);
		return currBlock.IsCityTown();
	}

	public bool IsInRegularSettlementRange()
	{
		Location location = _location;
		if (!location.IsValid())
		{
			location = GetValidLocation();
		}
		if (location.AreaId >= 45)
		{
			return false;
		}
		return DomainManager.Map.GetBelongSettlementBlock(location) != null;
	}

	public void AddTravelTarget(DataContext context, NpcTravelTarget target)
	{
		_npcTravelTargets.Add(target);
		SetNpcTravelTargets(_npcTravelTargets, context);
	}

	public void UpdateTravelTargetRemainingMonths(DataContext context)
	{
		for (int i = _npcTravelTargets.Count - 1; i >= 0; i--)
		{
			NpcTravelTarget travelTarget = _npcTravelTargets[i];
			travelTarget.RemainingMonth--;
			if (travelTarget.RemainingMonth <= 0)
			{
				_npcTravelTargets.RemoveAt(i);
			}
		}
		SetNpcTravelTargets(_npcTravelTargets, context);
	}

	public void UpdateIntelligentCharacterMovement(DataContext context)
	{
		if (IsActiveExternalRelationState(188uL) || GetAgeGroup() == 0 || _kidnapperId >= 0 || (_leaderId >= 0 && _leaderId != _id) || (IsCompletelyInfected() && _location.IsValid()) || GetLegendaryBookOwnerState() >= 2)
		{
			return;
		}
		if (_location.IsValid())
		{
			HashSet<int> charSet = DomainManager.Map.GetBlock(_location).CharacterSet;
			if (charSet == null || !charSet.Contains(_id))
			{
				return;
			}
		}
		if (!ContinueCurrCrossAreaTravel(context) && (!IsActiveExternalRelationState(1uL) || !DomainManager.Taiwu.TryGetElement_VillagerWork(_id, out var work) || work.WorkType == 2) && !TravelToActionTargetLocation(context) && !TravelToTargets(context))
		{
			TravelToRandomTarget(context);
		}
	}

	public void CompletelyInfectedCharacterMovement(DataContext context)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (InfectedMoveCloserToLocationInSameArea(context, taiwuLocation))
		{
			return;
		}
		switch (GetBehaviorType())
		{
		case 0:
		case 1:
		{
			HashSet<int> charSet2 = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
			DomainManager.Character.GetRelatedCharacters(_id)?.GetAllPrioritizedCharIds(charSet2);
			List<int>[] prioritizedActionTargets2 = context.AdvanceMonthRelatedData.PrioritizedTargets.Occupy();
			ClassifyPrioritizedActionTargets(prioritizedActionTargets2, charSet2, context.Random);
			context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref charSet2);
			int targetCharId2 = SelectMaxPriorityActionTarget(prioritizedActionTargets2, delegate(int charId)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var element))
				{
					return false;
				}
				if (element._location.IsValid())
				{
					return element._location.AreaId == _location.AreaId;
				}
				return element._leaderId == taiwuCharId && element.GetValidLocation().AreaId == _location.AreaId;
			});
			context.AdvanceMonthRelatedData.PrioritizedTargets.Release(ref prioritizedActionTargets2);
			if (targetCharId2 < 0)
			{
				InfectedMoveToRandomLocationInThreeBlocks(context, _location);
				break;
			}
			Character targetChar2 = DomainManager.Character.GetElement_Objects(targetCharId2);
			Location targetLocation2 = targetChar2._location;
			if (!targetLocation2.IsValid())
			{
				targetLocation2 = targetChar2.GetValidLocation();
			}
			InfectedMoveAwayFromLocationInSameArea(context, targetLocation2);
			break;
		}
		case 2:
			InfectedMoveToRandomLocationInThreeBlocks(context, _location);
			break;
		case 3:
		case 4:
		{
			HashSet<int> charSet = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
			DomainManager.Character.GetRelatedCharacters(_id)?.GetAllPrioritizedCharIds(charSet);
			List<int>[] prioritizedActionTargets = context.AdvanceMonthRelatedData.PrioritizedTargets.Occupy();
			ClassifyPrioritizedActionTargets(prioritizedActionTargets, charSet, context.Random);
			context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref charSet);
			int targetCharId = SelectMaxPriorityActionTarget(prioritizedActionTargets, delegate(int charId)
			{
				if (!DomainManager.Character.TryGetElement_Objects(charId, out var element))
				{
					return false;
				}
				if (element._location.IsValid())
				{
					return element._location.AreaId == _location.AreaId;
				}
				return element._leaderId == taiwuCharId && element.GetValidLocation().AreaId == _location.AreaId;
			});
			context.AdvanceMonthRelatedData.PrioritizedTargets.Release(ref prioritizedActionTargets);
			if (targetCharId < 0)
			{
				InfectedMoveToRandomLocationInThreeBlocks(context, _location);
				break;
			}
			Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
			Location targetLocation = targetChar._location;
			if (!targetLocation.IsValid())
			{
				targetLocation = targetChar.GetValidLocation();
			}
			InfectedMoveCloserToLocationInSameArea(context, targetLocation);
			break;
		}
		}
	}

	private bool InfectedMoveCloserToLocationInSameArea(DataContext context, Location destLocation)
	{
		if (_location.AreaId != destLocation.AreaId)
		{
			return false;
		}
		if (_location.BlockId == destLocation.BlockId)
		{
			return true;
		}
		byte areaSize = DomainManager.Map.GetAreaSize(_location.AreaId);
		ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaSize);
		ByteCoordinate destCoordinate = ByteCoordinate.IndexToCoordinate(destLocation.BlockId, areaSize);
		if (selfCoordinate.GetManhattanDistance(destCoordinate) > 3)
		{
			InfectedMoveToRandomLocationInThreeBlocks(context, destLocation);
		}
		else
		{
			DomainManager.Character.GroupMove(context, this, destLocation);
		}
		return true;
	}

	private bool InfectedMoveAwayFromLocationInSameArea(DataContext context, Location moveAwayFrom)
	{
		if (_location.AreaId != moveAwayFrom.AreaId)
		{
			return false;
		}
		if (_location.BlockId == moveAwayFrom.BlockId && InfectedMoveToRandomLocationInThreeBlocks(context, moveAwayFrom))
		{
			return true;
		}
		byte areaSize = DomainManager.Map.GetAreaSize(_location.AreaId);
		ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaSize);
		ByteCoordinate destCoordinate = ByteCoordinate.IndexToCoordinate(moveAwayFrom.BlockId, areaSize);
		if (selfCoordinate.GetManhattanDistance(destCoordinate) > 3)
		{
			InfectedMoveToRandomLocationInThreeBlocks(context, _location);
			return true;
		}
		Span<MapBlockData> allBlocks = DomainManager.Map.GetAreaBlocks(_location.AreaId);
		int maxDistance = 0;
		Location selectedLocation = Location.Invalid;
		for (int i = 0; i < 10; i++)
		{
			int index = context.Random.Next(allBlocks.Length);
			MapBlockData selectedBlock = allBlocks[index];
			Location targetLocation = new Location(selectedBlock.AreaId, selectedBlock.BlockId);
			MapBlockData block = DomainManager.Map.GetBlock(targetLocation);
			if (block.IsPassable())
			{
				ByteCoordinate targetCoordinate = ByteCoordinate.IndexToCoordinate(targetLocation.BlockId, areaSize);
				int distance = selfCoordinate.GetManhattanDistance(targetCoordinate);
				if (distance > 3)
				{
					selectedLocation = targetLocation;
					break;
				}
				if (distance >= maxDistance)
				{
					maxDistance = distance;
					selectedLocation = targetLocation;
				}
			}
		}
		DomainManager.Character.GroupMove(context, this, selectedLocation);
		return true;
	}

	private bool InfectedMoveToRandomLocationInThreeBlocks(DataContext context, Location srcLocation, bool includeCenter = false)
	{
		List<MapBlockData> blocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetValidBlocksForRandomEnemy(srcLocation.AreaId, srcLocation.BlockId, 3, onSettlement: false, nearTaiwu: true, blocks);
		MapBlockData selectedBlock = blocks.GetRandomOrDefault(context.Random, null);
		context.AdvanceMonthRelatedData.Blocks.Release(ref blocks);
		if (selectedBlock == null)
		{
			return false;
		}
		Location targetLocation = new Location(selectedBlock.AreaId, selectedBlock.BlockId);
		DomainManager.Character.GroupMove(context, this, targetLocation);
		return true;
	}

	private bool ContinueCurrCrossAreaTravel(DataContext context)
	{
		if (!DomainManager.Character.TryGetElement_CrossAreaMoveInfos(_id, out var crossAreaMoveInfo))
		{
			return false;
		}
		_actionPlanningData?.OnTraveling(context, this);
		if (_location.IsValid())
		{
			AdaptableLog.TagWarning($"Character {_id}", $"character is currently in valid location {_location} while cross area traveling.");
			return true;
		}
		if (ActionPlanningData.PrimaryGoalAction != null)
		{
			Location targetLocation = ActionPlanningData.PrimaryGoalAction.GetActualTargetLocation();
			List<short> areaList = crossAreaMoveInfo.Route.AreaList;
			if (areaList[areaList.Count - 1] != targetLocation.AreaId)
			{
				Location location0 = GetValidLocation();
				Location location1 = GetValidAndNotForbiddenByBeggarSkillLocation(location0);
				if (!location1.IsValid())
				{
					throw new Exception($"Character {this} cannot find a valid location near {location0}.");
				}
				DomainManager.Character.RemoveCrossAreaTravelInfo(context, _id);
				DomainManager.Character.GroupMove(context, this, location1);
				return false;
			}
		}
		NpcCrossAreaTravel(context, crossAreaMoveInfo);
		return true;
	}

	public bool IsCrossAreaTraveling()
	{
		CrossAreaMoveInfo value;
		if (_leaderId >= 0)
		{
			return DomainManager.Character.TryGetElement_CrossAreaMoveInfos(_leaderId, out value);
		}
		return DomainManager.Character.TryGetElement_CrossAreaMoveInfos(_id, out value);
	}

	private bool TravelToActionTargetLocation(DataContext context)
	{
		CharacterActionData action = ActionPlanningData.PrimaryGoalAction;
		if (action == null)
		{
			return false;
		}
		Location actionTargetLocation = action.GetActualTargetLocation();
		actionTargetLocation = GetValidAndNotForbiddenByBeggarSkillLocation(actionTargetLocation);
		if (!actionTargetLocation.IsValid())
		{
			return false;
		}
		if (actionTargetLocation.Equals(_location))
		{
			return true;
		}
		if (actionTargetLocation.AreaId != _location.AreaId)
		{
			if (!DomainManager.Map.AllowCrossAreaTravel(_location.AreaId, actionTargetLocation.AreaId))
			{
				return false;
			}
			CrossAreaMoveInfo crossTravelRoute = DomainManager.Map.CalcAreaTravelRoute(this, _location.AreaId, _location.BlockId, actionTargetLocation.AreaId);
			for (int index = 0; index < _npcTravelTargets.Count; index++)
			{
				NpcTravelTarget travelTarget = _npcTravelTargets[index];
				Location targetLocation = travelTarget.GetRealTargetLocation();
				targetLocation = GetValidAndNotForbiddenByBeggarSkillLocation(targetLocation);
				if (!targetLocation.IsValid() || !crossTravelRoute.Route.AreaList.Contains(targetLocation.AreaId))
				{
					continue;
				}
				if (targetLocation.AreaId != _location.AreaId)
				{
					crossTravelRoute.ToAreaId = targetLocation.AreaId;
					if (!NpcCrossAreaTravel(context, crossTravelRoute))
					{
						return true;
					}
				}
				Tester.Assert(targetLocation.AreaId == _location.AreaId);
				DomainManager.Character.GroupMove(context, this, targetLocation);
				_npcTravelTargets.RemoveAt(index);
				SetNpcTravelTargets(_npcTravelTargets, context);
				return true;
			}
			if (!NpcCrossAreaTravel(context, crossTravelRoute))
			{
				return true;
			}
		}
		Tester.Assert(actionTargetLocation.AreaId == _location.AreaId);
		DomainManager.Character.GroupMove(context, this, actionTargetLocation);
		return true;
	}

	private bool TravelToTargets(DataContext context)
	{
		for (int index = 0; index < _npcTravelTargets.Count; index++)
		{
			NpcTravelTarget travelTarget = _npcTravelTargets[index];
			Location targetLocation = travelTarget.GetRealTargetLocation();
			targetLocation = GetValidAndNotForbiddenByBeggarSkillLocation(targetLocation);
			if (!targetLocation.IsValid())
			{
				continue;
			}
			if (targetLocation.AreaId != _location.AreaId)
			{
				if (!DomainManager.Map.AllowCrossAreaTravel(_location.AreaId, targetLocation.AreaId))
				{
					return false;
				}
				CrossAreaMoveInfo crossTravelRoute = DomainManager.Map.CalcAreaTravelRoute(this, _location.AreaId, _location.BlockId, targetLocation.AreaId);
				if (!NpcCrossAreaTravel(context, crossTravelRoute))
				{
					return true;
				}
			}
			Tester.Assert(targetLocation.AreaId == _location.AreaId);
			DomainManager.Character.GroupMove(context, this, targetLocation);
			_npcTravelTargets.RemoveAt(index);
			SetNpcTravelTargets(_npcTravelTargets, context);
			return true;
		}
		return false;
	}

	private void TravelToRandomTarget(DataContext context)
	{
		if (!context.Random.CheckPercentProb(30))
		{
			return;
		}
		Location randomMovementTarget = OfflineCalcRandomMovementTarget(context);
		randomMovementTarget = GetValidAndNotForbiddenByBeggarSkillLocation(randomMovementTarget);
		if (!randomMovementTarget.IsValid())
		{
			return;
		}
		if (randomMovementTarget.AreaId != _location.AreaId)
		{
			if (!DomainManager.Map.AllowCrossAreaTravel(_location.AreaId, randomMovementTarget.AreaId))
			{
				return;
			}
			CrossAreaMoveInfo crossTravelRoute = DomainManager.Map.CalcAreaTravelRoute(this, _location.AreaId, _location.BlockId, randomMovementTarget.AreaId);
			if (!NpcCrossAreaTravel(context, crossTravelRoute))
			{
				return;
			}
		}
		Tester.Assert(randomMovementTarget.AreaId == _location.AreaId);
		DomainManager.Character.GroupMove(context, this, randomMovementTarget);
	}

	public bool NpcCrossAreaTravel(DataContext context, CrossAreaMoveInfo travelInfo)
	{
		travelInfo.CostedDays += 30;
		int currDays = 0;
		int i = 0;
		while (i < travelInfo.Route.CostList.Count)
		{
			short currAreaId = travelInfo.Route.AreaList[i];
			currDays += travelInfo.Route.CostList[i];
			if (currAreaId != travelInfo.ToAreaId)
			{
				List<short> areaList = travelInfo.Route.AreaList;
				if (currAreaId != areaList[areaList.Count - 1])
				{
					if (currDays >= travelInfo.CostedDays)
					{
						break;
					}
					i++;
					continue;
				}
			}
			short targetBlockId = DomainManager.Map.GetElement_Areas(currAreaId).StationBlockId;
			Location targetLocation0 = new Location(currAreaId, targetBlockId);
			Location targetLocation1 = GetValidAndNotForbiddenByBeggarSkillLocation(targetLocation0);
			if (!targetLocation1.IsValid())
			{
				throw new Exception($"Character {this} cannot find a valid location near {targetLocation0}.");
			}
			DomainManager.Character.RemoveCrossAreaTravelInfo(context, _id);
			DomainManager.Character.GroupMove(context, this, targetLocation1);
			return true;
		}
		if (_location.IsValid())
		{
			DomainManager.Character.GroupMove(context, this, Location.Invalid);
		}
		DomainManager.Character.SetCrossAreaTravelInfo(context, _id, travelInfo);
		return false;
	}

	public unsafe Location OfflineCalcRandomMovementTarget(DataContext context)
	{
		Location currLocation = _location;
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(_organizationInfo);
		if (orgMemberCfg.CanStroll)
		{
			foreach (CharacterGoalData personalNeed in GetGoals())
			{
				if (personalNeed.GoalTemplateId != 236 || personalNeed.Args.ResourceType >= 6)
				{
					continue;
				}
				sbyte resourceType = personalNeed.Args.ResourceType;
				MapBlockData block = DomainManager.Map.GetBlock(currLocation);
				short currentResource = block.CurrResources.Items[resourceType];
				if (currentResource >= block.MaxResources.Items[resourceType] / 2)
				{
					continue;
				}
				List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
				DomainManager.Map.GetRealNeighborBlocks(currLocation.AreaId, currLocation.BlockId, neighborBlocks, 3);
				Location targetLocation = currLocation;
				foreach (MapBlockData neighborBlock in neighborBlocks)
				{
					if (neighborBlock.CurrResources.Items[resourceType] < neighborBlock.MaxResources.Items[resourceType] / 2)
					{
						continue;
					}
					targetLocation = new Location(neighborBlock.AreaId, neighborBlock.BlockId);
					break;
				}
				ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
				return targetLocation;
			}
		}
		if (_organizationInfo.SettlementId >= 0)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(_organizationInfo.SettlementId);
			Location settlementLocation = settlement.GetLocation();
			List<short> blockIds = context.AdvanceMonthRelatedData.BlockIds.Occupy();
			DomainManager.Map.GetSettlementBlocksAndAffiliatedBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
			if (currLocation.AreaId != settlementLocation.AreaId || !blockIds.Contains(currLocation.BlockId))
			{
				context.AdvanceMonthRelatedData.BlockIds.Release(ref blockIds);
				return settlementLocation;
			}
			if (orgMemberCfg.CanStroll)
			{
				short targetBlockId = blockIds.GetRandom(context.Random);
				context.AdvanceMonthRelatedData.BlockIds.Release(ref blockIds);
				return new Location(settlementLocation.AreaId, targetBlockId);
			}
			blockIds.Clear();
			DomainManager.Map.GetSettlementBlocks(settlementLocation.AreaId, settlementLocation.BlockId, blockIds);
			short targetBlockId2 = blockIds.GetRandom(context.Random);
			context.AdvanceMonthRelatedData.BlockIds.Release(ref blockIds);
			return new Location(settlementLocation.AreaId, targetBlockId2);
		}
		return currLocation;
	}

	private void OfflineAddNpcTravelTarget(NpcTravelTarget target)
	{
		for (int i = 0; i < _npcTravelTargets.Count; i++)
		{
			if (target.IsSameTargetWith(_npcTravelTargets[i]))
			{
				_npcTravelTargets[i] = target;
				return;
			}
		}
		_npcTravelTargets.Add(target);
	}

	private Location GetValidAndNotForbiddenByBeggarSkillLocation(Location location)
	{
		if (!location.IsValid())
		{
			return location;
		}
		if (!ProfessionSkillHandle.IsLocationForbiddenByBeggarSkill(location))
		{
			return location;
		}
		int maxSteps = 2;
		List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks, maxSteps);
		byte centerSize = DomainManager.Map.GetAreaSize(location.AreaId);
		ByteCoordinate centerCoordinate = ByteCoordinate.IndexToCoordinate(location.BlockId, centerSize);
		neighborBlocks.Sort(delegate(MapBlockData a, MapBlockData b)
		{
			byte areaSize = DomainManager.Map.GetAreaSize(a.AreaId);
			ByteCoordinate byteCoordinate = ByteCoordinate.IndexToCoordinate(a.BlockId, areaSize);
			byte areaSize2 = DomainManager.Map.GetAreaSize(b.AreaId);
			ByteCoordinate byteCoordinate2 = ByteCoordinate.IndexToCoordinate(b.BlockId, areaSize2);
			int manhattanDistance = centerCoordinate.GetManhattanDistance(byteCoordinate);
			int manhattanDistance2 = centerCoordinate.GetManhattanDistance(byteCoordinate2);
			return manhattanDistance.CompareTo(manhattanDistance2);
		});
		Location targetLocation = Location.Invalid;
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			Location neighborLocation = neighborBlock.GetLocation();
			if (!neighborLocation.IsValid() || ProfessionSkillHandle.IsLocationForbiddenByBeggarSkill(neighborLocation))
			{
				continue;
			}
			targetLocation = neighborLocation;
			break;
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
		return targetLocation;
	}

	private unsafe void OfflineUseResourcesForHealingAndDetox(PeriAdvanceMonthUpdateStatusModification mod)
	{
		CombatResources combatResources = DomainManager.Character.GetUsableCombatResources(_id);
		if (combatResources.HealingCount > 0)
		{
			for (int i = 0; i < combatResources.HealingCount; i++)
			{
				if (!_injuries.HasAnyInjury())
				{
					break;
				}
				int costHerb = CombatDomain.GetHealInjuryCostHerb(_injuries);
				if (OfflineCheckHerbLackAndAddPersonalNeed(mod, costHerb))
				{
					break;
				}
				_injuries = DomainManager.Combat.HealInjury(_id, this);
				ref int reference = ref _resources.Items[5];
				reference -= costHerb;
				mod.InjuriesChanged = true;
				mod.ResourcesChanged = true;
				mod.UsedHealingCount++;
			}
		}
		if (combatResources.DetoxCount > 0)
		{
			for (int j = 0; j < combatResources.DetoxCount; j++)
			{
				if (!_poisoned.IsNonZero())
				{
					break;
				}
				int costHerb2 = CombatDomain.GetHealPoisonCostHerb(_poisoned);
				if (OfflineCheckHerbLackAndAddPersonalNeed(mod, costHerb2))
				{
					break;
				}
				_poisoned = DomainManager.Combat.HealPoison(_id, this);
				ref int reference2 = ref _resources.Items[5];
				reference2 -= costHerb2;
				mod.PoisonedChanged = true;
				mod.ResourcesChanged = true;
				mod.UsedDetoxCount++;
			}
		}
		if (combatResources.BreathingCount <= 0)
		{
			return;
		}
		for (int k = 0; k < combatResources.BreathingCount; k++)
		{
			if (_disorderOfQi <= 0)
			{
				break;
			}
			int costHerb3 = CombatDomain.GetHealQiDisorderCostHerb(_disorderOfQi);
			if (OfflineCheckHerbLackAndAddPersonalNeed(mod, costHerb3))
			{
				break;
			}
			_disorderOfQi = DomainManager.Combat.HealQiDisorder(_id, this);
			ref int reference3 = ref _resources.Items[5];
			reference3 -= costHerb3;
			mod.QiDisorderChanged = true;
			mod.ResourcesChanged = true;
			mod.UsedBreathingCount++;
		}
	}

	private unsafe void OfflineUseResourcesForHealth(PeriAdvanceMonthUpdateStatusModification mod)
	{
		CombatResources combatResources = DomainManager.Character.GetUsableCombatResources(_id);
		if (combatResources.RecoverCount <= 0)
		{
			return;
		}
		short maxHealth = GetLeftMaxHealth();
		for (int i = 0; i < combatResources.RecoverCount; i++)
		{
			if (_health == maxHealth)
			{
				break;
			}
			EHealthType type = HealthTypeHelper.CalcType(_featureIds, _health, maxHealth);
			int costHerb = CombatDomain.GetHealHealthCostHerb(type);
			if (OfflineCheckHerbLackAndAddPersonalNeed(mod, costHerb))
			{
				break;
			}
			_health = DomainManager.Combat.HealHealth(_id, this);
			ref int reference = ref _resources.Items[5];
			reference -= costHerb;
			mod.ResourcesChanged = true;
			mod.UsedRecoverCount++;
		}
	}

	private unsafe bool OfflineCheckHerbLackAndAddPersonalNeed(PeriAdvanceMonthUpdateStatusModification mod, int costHerb)
	{
		if (_resources.Items[5] >= costHerb)
		{
			return false;
		}
		OfflineAddGoal(236, (sbyte)5, costHerb);
		mod.PersonalNeedsChanged = true;
		return true;
	}

	private unsafe void OfflineUseMedicineForHealingAndDetox(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		int availableEatingSlotsCount = _eatingItems.GetAvailableEatingSlotsCount(currMaxEatingSlotCount);
		PoisonInts poisonResists = GetPoisonResists();
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedMedicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		List<(GameData.Domains.Item.Medicine, int)> outerMedicines = categorizedMedicines[0];
		List<(GameData.Domains.Item.Medicine, int)> innerMedicines = categorizedMedicines[1];
		outerMedicines.Sort(EatingItemComparer.MedicineInjury);
		innerMedicines.Sort(EatingItemComparer.MedicineInjury);
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			var (outer, inner) = _injuries.Get(bodyPart);
			if (outer > 2 && outerMedicines.Count > 0)
			{
				int selectedIndex = SelectTopicalMedicineIndex(outerMedicines, outer, ref _currMainAttributes);
				if (selectedIndex >= 0)
				{
					(GameData.Domains.Item.Medicine, int) tuple2 = outerMedicines[selectedIndex];
					GameData.Domains.Item.Medicine medicine = tuple2.Item1;
					int amount = tuple2.Item2;
					MedicineItem config = Config.Medicine.Instance[medicine.GetTemplateId()];
					OfflineApplyTopicalMedicineInternal(context.Random, config, reduceMainAttribute: true, medicine.GetId());
					mod.InjuriesChanged = true;
					mod.CurrMainAttributesChanged = true;
					OfflineRemoveUsedMedicine(outerMedicines, selectedIndex, -1, mod);
				}
			}
			if (inner > 2 && innerMedicines.Count > 0)
			{
				int selectedIndex2 = SelectTopicalMedicineIndex(innerMedicines, inner, ref _currMainAttributes);
				if (selectedIndex2 >= 0)
				{
					(GameData.Domains.Item.Medicine, int) tuple3 = innerMedicines[selectedIndex2];
					GameData.Domains.Item.Medicine medicine2 = tuple3.Item1;
					int amount2 = tuple3.Item2;
					MedicineItem config2 = Config.Medicine.Instance[medicine2.GetTemplateId()];
					OfflineApplyTopicalMedicineInternal(context.Random, config2, reduceMainAttribute: true, medicine2.GetId());
					mod.InjuriesChanged = true;
					mod.CurrMainAttributesChanged = true;
					OfflineRemoveUsedMedicine(innerMedicines, selectedIndex2, -1, mod);
				}
			}
		}
		categorizedMedicines[3].Sort(EatingItemComparer.MedicineQiDisorder);
		int* healthChanges = stackalloc int[3];
		while (availableEatingSlotsCount > 1)
		{
			*healthChanges = GetHealthChangeDueToInjuries(ref _injuries) << 8;
			healthChanges[1] = (GetHealthChangeDueToPoisons(ref _poisoned, ref poisonResists) << 8) + 1;
			healthChanges[2] = (GetHealthChangeDueToDisorderOfQi(_disorderOfQi) << 8) + 2;
			CollectionUtils.Sort(healthChanges, 3);
			if (*healthChanges >> 8 >= 0 || !OfflineUseMedicineForHealingAndDetoxHelper(context, healthChanges, ref poisonResists, mod))
			{
				break;
			}
			availableEatingSlotsCount--;
		}
		OfflineCheckPersonalNeedForHealingAndDetox(mod);
	}

	private unsafe bool OfflineUseMedicineForHealingAndDetoxHelper(DataContext context, int* healthChanges, ref PoisonInts poisonResists, PeriAdvanceMonthUpdateStatusModification mod)
	{
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedMedicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		int* poisonLevels = stackalloc int[6];
		for (int i = 0; i < 3; i++)
		{
			int type = healthChanges[i] & 0xFF;
			int deltaHealth = healthChanges[i] >> 8;
			if (deltaHealth >= 0)
			{
				break;
			}
			switch (type)
			{
			case 0:
			{
				List<(GameData.Domains.Item.Medicine, int)> outerMedicines = categorizedMedicines[0];
				List<(GameData.Domains.Item.Medicine, int)> innerMedicines = categorizedMedicines[1];
				sbyte innerInjuryMinLevel = sbyte.MaxValue;
				sbyte outerInjuryMinLevel = sbyte.MaxValue;
				sbyte outerInjuryTotalLevel = 0;
				sbyte innerInjuryTotalLevel = 0;
				for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
				{
					(sbyte outer, sbyte inner) tuple2 = _injuries.Get(bodyPart);
					sbyte outer = tuple2.outer;
					sbyte inner = tuple2.inner;
					outerInjuryTotalLevel += outer;
					innerInjuryTotalLevel += inner;
					if (outer > 0 && outer < outerInjuryMinLevel)
					{
						outerInjuryMinLevel = outer;
					}
					if (inner > 0 && inner < innerInjuryMinLevel)
					{
						innerInjuryMinLevel = inner;
					}
				}
				int medicineIndex = -1;
				if (outerMedicines.Count > 0 && outerInjuryMinLevel > innerInjuryMinLevel && outerInjuryMinLevel <= 6)
				{
					medicineIndex = SelectMedicineIndexForInjury(outerMedicines, outerInjuryMinLevel, outerInjuryTotalLevel);
					if (medicineIndex >= 0)
					{
						(GameData.Domains.Item.Medicine, int) tuple3 = outerMedicines[medicineIndex];
						GameData.Domains.Item.Medicine medicine2 = tuple3.Item1;
						int amount2 = tuple3.Item2;
						MedicineItem config = Config.Medicine.Instance[medicine2.GetTemplateId()];
						MedicineEatingInstantEffect effect = new MedicineEatingInstantEffect(config);
						CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: false, ref effect, medicine2.GetId());
						sbyte slot2 = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
						OfflineRemoveUsedMedicine(outerMedicines, medicineIndex, slot2, mod);
						mod.InjuriesChanged = true;
						return true;
					}
				}
				if (innerMedicines.Count > 0 && innerInjuryMinLevel <= 6)
				{
					medicineIndex = SelectMedicineIndexForInjury(innerMedicines, innerInjuryMinLevel, innerInjuryTotalLevel);
					if (medicineIndex >= 0)
					{
						(GameData.Domains.Item.Medicine, int) tuple4 = innerMedicines[medicineIndex];
						GameData.Domains.Item.Medicine medicine3 = tuple4.Item1;
						int amount3 = tuple4.Item2;
						MedicineItem config2 = Config.Medicine.Instance[medicine3.GetTemplateId()];
						MedicineEatingInstantEffect effect2 = new MedicineEatingInstantEffect(config2);
						CalcMedicineEffect_RecoverInjury(ref _injuries, context.Random, inner: true, ref effect2, medicine3.GetId());
						sbyte slot3 = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
						OfflineRemoveUsedMedicine(innerMedicines, medicineIndex, slot3, mod);
						mod.InjuriesChanged = true;
						return true;
					}
				}
				break;
			}
			case 1:
			{
				List<(GameData.Domains.Item.Medicine, int)> detoxMedicines = categorizedMedicines[4];
				if (detoxMedicines.Count <= 0)
				{
					break;
				}
				detoxMedicines.Sort(CompareDetoxPoisonMedicines);
				for (sbyte poisonType = 0; poisonType < 6; poisonType++)
				{
					int level = ((poisonResists.Items[poisonType] < 1000) ? PoisonsAndLevels.CalcPoisonedLevel(_poisoned.Items[poisonType]) : 0);
					poisonLevels[poisonType] = (level << 8) + poisonType;
				}
				CollectionUtils.Sort(poisonLevels, 6);
				for (sbyte index = 5; index >= 0; index--)
				{
					sbyte poisonType2 = (sbyte)(poisonLevels[index] & 0xFF);
					sbyte level2 = (sbyte)(poisonLevels[index] >> 8);
					if (level2 <= 0)
					{
						break;
					}
					int medicineIndex2 = SelectMedicineIndexForDetoxPoison(detoxMedicines, poisonType2, level2, _poisoned.Items[poisonType2]);
					if (medicineIndex2 >= 0)
					{
						(GameData.Domains.Item.Medicine, int) medicine4 = detoxMedicines[medicineIndex2];
						MedicineItem config3 = Config.Medicine.Instance[medicine4.Item1.GetTemplateId()];
						int delta2 = -CalcMedicineEffectDelta(_poisoned.Items[poisonType2], config3.EffectValue, config3.EffectIsPercentage, medicine4.Item1.GetId());
						_poisoned.Items[poisonType2] = Math.Max(_poisoned.Items[poisonType2] + delta2, 0);
						sbyte slot4 = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
						OfflineRemoveUsedMedicine(detoxMedicines, medicineIndex2, slot4, mod);
						mod.PoisonedChanged = true;
						return true;
					}
				}
				break;
			}
			case 2:
			{
				List<(GameData.Domains.Item.Medicine, int)> qiMedicines = categorizedMedicines[3];
				int selectedIndex = SelectMedicineIndexForQiDisorder(qiMedicines, _disorderOfQi);
				if (selectedIndex >= 0)
				{
					(GameData.Domains.Item.Medicine, int) tuple = qiMedicines[selectedIndex];
					GameData.Domains.Item.Medicine medicine = tuple.Item1;
					int amount = tuple.Item2;
					short delta = medicine.GetEffectValue();
					_disorderOfQi = (short)Math.Clamp(_disorderOfQi + delta, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue);
					sbyte slot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
					OfflineRemoveUsedMedicine(qiMedicines, selectedIndex, slot, mod);
					mod.QiDisorderChanged = true;
					return true;
				}
				break;
			}
			}
		}
		return false;
	}

	public unsafe int CompareDetoxPoisonMedicines((GameData.Domains.Item.Medicine item, int amount) a, (GameData.Domains.Item.Medicine item, int amount) b)
	{
		short aEffect = a.item.GetEffectValue();
		short bEffect = b.item.GetEffectValue();
		sbyte aPoisonedType = a.item.GetEffectSubType().PoisonType();
		sbyte bPoisonedType = b.item.GetEffectSubType().PoisonType();
		int aPoisonedVal = ((aPoisonedType >= 0) ? _poisoned.Items[aPoisonedType] : 0);
		int aDelta = ((aPoisonedType < 0) ? int.MinValue : CalcMedicineEffectDelta(aPoisonedVal, aEffect, a.item.GetEffectSubType().IsPercentage(), a.item.GetId()));
		int bPoisonedVal = ((bPoisonedType < 0) ? (-1) : _poisoned.Items[bPoisonedType]);
		return ((aPoisonedType < 0) ? int.MinValue : CalcMedicineEffectDelta(bPoisonedVal, bEffect, b.item.GetEffectSubType().IsPercentage(), b.item.GetId())).CompareTo(aDelta);
	}

	private unsafe void OfflineCheckPersonalNeedForHealingAndDetox(PeriAdvanceMonthUpdateStatusModification mod)
	{
		int totalOuter = 0;
		int totalInner = 0;
		bool outerNeedHeal = false;
		bool innerNeedHeal = false;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte outer, sbyte inner) tuple = _injuries.Get(bodyPart);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			totalOuter += outer;
			totalInner += inner;
			if (outer > 2)
			{
				outerNeedHeal = true;
			}
			if (inner > 2)
			{
				innerNeedHeal = true;
			}
		}
		if (outerNeedHeal)
		{
			OfflineAddGoal(228, (sbyte)0, totalOuter);
			mod.PersonalNeedsChanged = true;
		}
		if (innerNeedHeal)
		{
			OfflineAddGoal(228, (sbyte)1, totalInner);
			mod.PersonalNeedsChanged = true;
		}
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			int poisonAmount = _poisoned.Items[poisonType];
			sbyte poisonLevel = PoisonsAndLevels.CalcPoisonedLevel(poisonAmount);
			if (poisonLevel > 0)
			{
				OfflineAddGoal(229, poisonType, poisonAmount);
				mod.PersonalNeedsChanged = true;
			}
		}
		if (GetHealthChangeDueToDisorderOfQi(_disorderOfQi) < 0)
		{
			OfflineAddGoal(230, (int)_disorderOfQi);
			mod.PersonalNeedsChanged = true;
		}
	}

	private void OfflineUseMedicineForHealth(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		short leftMaxHealth = GetLeftMaxHealth();
		if (_health >= leftMaxHealth / 2)
		{
			return;
		}
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		sbyte eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedMedicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		List<(GameData.Domains.Item.Medicine, int)> medicines = categorizedMedicines[2];
		if (eatingSlot >= 0 && medicines.Count > 0)
		{
			medicines.Sort(EatingItemComparer.MedicineEffect);
			while (eatingSlot >= 0 && _health < leftMaxHealth)
			{
				int selectedIndex = SelectMedicineIndexForHealth(medicines, _health, leftMaxHealth);
				if (selectedIndex < 0)
				{
					break;
				}
				short medicineEffect = medicines[selectedIndex].Item1.GetEffectValue();
				_health = (short)Math.Min(_health + medicineEffect, leftMaxHealth);
				OfflineRemoveUsedMedicine(medicines, selectedIndex, eatingSlot, mod);
				eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
			}
		}
		if (_health < leftMaxHealth)
		{
			OfflineAddGoal(227, leftMaxHealth - _health);
			mod.PersonalNeedsChanged = true;
		}
	}

	private unsafe void OfflineUseMedicineForWug(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		sbyte eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
		List<(GameData.Domains.Item.Medicine, int)>[] categorizedMedicines = context.AdvanceMonthRelatedData.CategorizedMedicines.Get();
		List<(GameData.Domains.Item.Medicine, int)> medicines = categorizedMedicines[5];
		List<(GameData.Domains.Item.Medicine, int)> poisons = categorizedMedicines[6];
		if (eatingSlot >= 0 && (medicines.Count > 0 || poisons.Count > 0))
		{
			medicines.Sort(EatingItemComparer.MedicineGrade);
			poisons.Sort(EatingItemComparer.MedicineGrade);
			for (sbyte currSlot = 0; currSlot < 9; currSlot++)
			{
				ItemKey itemKey = (ItemKey)_eatingItems.ItemKeys[currSlot];
				if (EatingItems.IsWug(itemKey) && !itemKey.IsValid())
				{
					MedicineItem wugConfig = Config.Medicine.Instance[itemKey.TemplateId];
					bool hasWug = EatingItems.IsWug(_eatingItems.Get(currSlot)) && !_eatingItems.Get(currSlot).IsValid();
					while (eatingSlot >= 0 && hasWug)
					{
						int selectedIndex = SelectMedicineIndexForWug(medicines, wugConfig.WugType, _eatingItems.Durations[currSlot]);
						if (selectedIndex >= 0)
						{
							short deltaDuration = GameData.Domains.Item.Medicine.GetDeltaWugDuration(medicines[selectedIndex].Item1.GetGrade());
							_eatingItems.ChangeDuration(context, currSlot, deltaDuration, ref mod.RemovedWugs);
							OfflineRemoveUsedMedicine(medicines, selectedIndex, eatingSlot, mod);
							eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
							continue;
						}
						selectedIndex = SelectPoisonIndexForWug(poisons, wugConfig.WugType, _eatingItems.Durations[currSlot]);
						if (selectedIndex >= 0)
						{
							MedicineItem config = Config.Medicine.Instance[poisons[selectedIndex].Item1.GetTemplateId()];
							short deltaDuration2 = GameData.Domains.Item.Medicine.GetDeltaWugDuration(config.Grade);
							_eatingItems.ChangeDuration(context, currSlot, deltaDuration2, ref mod.RemovedWugs);
							sbyte poisonType = config.PoisonType;
							sbyte poisonLevel = (sbyte)config.EffectThresholdValue;
							if (!HasPoisonImmunity(poisonType))
							{
								int maxValue = 25000;
								int poisoned = _poisoned.Items[poisonType];
								_poisoned.Items[poisonType] = Math.Clamp(poisoned + config.EffectValue, 0, maxValue);
								mod.PoisonedChanged = true;
							}
							OfflineRemoveUsedMedicine(poisons, selectedIndex, eatingSlot, mod);
							eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
							continue;
						}
						break;
					}
				}
			}
		}
		for (sbyte currSlot2 = 0; currSlot2 < 9; currSlot2++)
		{
			ItemKey itemKey2 = (ItemKey)_eatingItems.ItemKeys[currSlot2];
			if (EatingItems.IsWug(itemKey2) && !itemKey2.IsValid())
			{
				MedicineItem wugConfig2 = Config.Medicine.Instance[itemKey2.TemplateId];
				if (EatingItems.IsWug(_eatingItems.Get(currSlot2)) && !_eatingItems.Get(currSlot2).IsValid())
				{
					OfflineAddGoal(231, wugConfig2.WugType);
					mod.PersonalNeedsChanged = true;
				}
			}
		}
	}

	private void OfflineUseItemForNeili(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		int maxNeili = GetMaxNeili();
		if (_currNeili >= maxNeili)
		{
			return;
		}
		List<(GameData.Domains.Item.Misc, int)> itemsForNeili = context.AdvanceMonthRelatedData.ItemsForNeili.Get();
		if (itemsForNeili.Count > 0)
		{
			itemsForNeili.Sort(EatingItemComparer.MiscNeili);
			while (_currNeili < maxNeili)
			{
				int selectedIndex = SelectItemIndexForNeili(itemsForNeili, _currNeili, maxNeili);
				if (selectedIndex < 0)
				{
					break;
				}
				(GameData.Domains.Item.Misc, int) tuple = itemsForNeili[selectedIndex];
				GameData.Domains.Item.Misc item = tuple.Item1;
				int amount = tuple.Item2;
				short neili = item.GetNeili();
				_currNeili = (short)Math.Min(_currNeili + neili, maxNeili);
				mod.CurrNeiliChanged = true;
				if (amount > 1)
				{
					itemsForNeili[selectedIndex] = (item, amount - 1);
				}
				else
				{
					itemsForNeili.RemoveAt(selectedIndex);
				}
				ItemKey itemKey = item.GetItemKey();
				_inventory.OfflineRemove(itemKey, 1);
				mod.InventoryChanged = true;
			}
		}
		if (_currNeili < maxNeili)
		{
			OfflineAddGoal(233, maxNeili - _currNeili);
			mod.PersonalNeedsChanged = true;
		}
	}

	private unsafe void OfflineUseFoodForMainAttributes(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		MainAttributes maxMainAttributes = GetMaxMainAttributes();
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		sbyte eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
		List<(GameData.Domains.Item.Food, int)>[] foodsForMainAttributes = context.AdvanceMonthRelatedData.FoodsForMainAttributes.Get();
		for (sbyte attrType = 0; attrType < 6; attrType++)
		{
			short maxMainAttr = maxMainAttributes.Items[attrType];
			if (_currMainAttributes.Items[attrType] * 2 < maxMainAttr)
			{
				List<(GameData.Domains.Item.Food, int)> foods = foodsForMainAttributes[attrType];
				if (eatingSlot >= 0 && foods.Count > 0)
				{
					sbyte behaviorType = GetBehaviorType();
					sbyte eatForbiddenFoodChance = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
					bool isMeatForbidden = IsForbiddenToEatMeat();
					short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, 6, -1);
					bool allowMeat = !isMeatForbidden || context.Random.CheckPercentProb(eatForbiddenFoodChance + rateAdjust);
					foods.Sort(EatingItemComparer.FoodMainAttributes[attrType]);
					while (eatingSlot >= 0 && _currMainAttributes.Items[attrType] < maxMainAttr)
					{
						int selectedIndex = SelectFoodIndexForMainAttributes(foods, attrType, _currMainAttributes.Items[attrType], maxMainAttr, allowMeat);
						if (selectedIndex < 0)
						{
							break;
						}
						FoodItem config = Config.Food.Instance[foods[selectedIndex].Item1.GetTemplateId()];
						short regenAmount = config.MainAttributesRegen.Items[attrType];
						_currMainAttributes.Items[attrType] = (short)Math.Min(_currMainAttributes.Items[attrType] + regenAmount, maxMainAttr);
						mod.CurrMainAttributesChanged = true;
						if (isMeatForbidden && config.ItemSubType == 701)
						{
							ItemKey itemKey = foods[selectedIndex].Item1.GetItemKey();
							if (mod.ConsumedForbiddenFoodsOrWines == null)
							{
								mod.ConsumedForbiddenFoodsOrWines = new List<ItemKey>();
							}
							if (!mod.ConsumedForbiddenFoodsOrWines.Contains(itemKey))
							{
								mod.ConsumedForbiddenFoodsOrWines.Add(itemKey);
							}
							sbyte happinessChange = AiHelper.UpdateStatusConstants.EatForbiddenFoodHappinessChange[behaviorType];
							_happiness = (sbyte)Math.Clamp(_happiness + happinessChange, -119, 119);
							mod.HappinessChanged = true;
						}
						OfflineRemoveUsedFood(foods, selectedIndex, eatingSlot, mod);
						eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
					}
				}
				if (_currMainAttributes.Items[attrType] < maxMainAttributes.Items[attrType])
				{
					OfflineAddGoal(234, attrType, maxMainAttributes.Items[attrType] - _currMainAttributes.Items[attrType]);
					mod.PersonalNeedsChanged = true;
				}
			}
		}
	}

	private void OfflineUpdateHappiness(PeriAdvanceMonthUpdateStatusModification mod)
	{
		int happinessDelta = DomainManager.SpecialEffect.ModifyValue(_id, 269, 0);
		if (happinessDelta != 0)
		{
			sbyte prevHappiness = _happiness;
			_happiness = (sbyte)Math.Clamp(_happiness + happinessDelta, -119, 119);
			if (prevHappiness != _happiness)
			{
				mod.HappinessChanged = true;
			}
		}
	}

	private void OfflineUseTeaWineForHappiness(DataContext context, PeriAdvanceMonthUpdateStatusModification mod)
	{
		sbyte happinessThreshold = HappinessType.Ranges[3].min;
		if (_happiness >= happinessThreshold)
		{
			return;
		}
		sbyte currMaxEatingSlotCount = GetCurrMaxEatingSlotsCount();
		sbyte eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
		List<(GameData.Domains.Item.TeaWine, int)> teaWines = context.AdvanceMonthRelatedData.TeaWinesForHappiness.Get();
		if (eatingSlot >= 0 && teaWines.Count > 0)
		{
			sbyte behaviorType = GetBehaviorType();
			short rateAdjust = DomainManager.Character.GetAiActionRateAdjust(_id, 6, -1);
			sbyte eatForbiddenFoodChance = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
			bool isWineForbidden = IsForbiddenToDrinkingWines();
			bool allowWines = !isWineForbidden || context.Random.CheckPercentProb(eatForbiddenFoodChance + rateAdjust);
			teaWines.Sort(EatingItemComparer.TeaWineHappiness);
			while (eatingSlot >= 0 && _happiness < happinessThreshold)
			{
				int selectedIndex = SelectTeaWineForHappiness(teaWines, _happiness, happinessThreshold, allowWines);
				if (selectedIndex < 0)
				{
					break;
				}
				TeaWineItem config = Config.TeaWine.Instance[teaWines[selectedIndex].Item1.GetTemplateId()];
				_happiness = (sbyte)Math.Clamp(_happiness + config.EatHappinessChange, -119, 119);
				mod.HappinessChanged = true;
				if (isWineForbidden && config.ItemSubType == 901)
				{
					ItemKey itemKey = teaWines[selectedIndex].Item1.GetItemKey();
					if (mod.ConsumedForbiddenFoodsOrWines == null)
					{
						mod.ConsumedForbiddenFoodsOrWines = new List<ItemKey>();
					}
					if (!mod.ConsumedForbiddenFoodsOrWines.Contains(itemKey))
					{
						mod.ConsumedForbiddenFoodsOrWines.Add(itemKey);
					}
					sbyte happinessChange = AiHelper.UpdateStatusConstants.EatForbiddenFoodHappinessChange[behaviorType];
					_happiness = (sbyte)Math.Clamp(_happiness + happinessChange, -119, 119);
				}
				OfflineRemoveUsedTeaWine(teaWines, selectedIndex, eatingSlot, mod);
				eatingSlot = _eatingItems.GetAvailableEatingSlot(currMaxEatingSlotCount);
			}
		}
		if (_happiness < happinessThreshold)
		{
			OfflineAddGoal(232, happinessThreshold - _happiness);
			mod.PersonalNeedsChanged = true;
		}
	}

	private void OfflineRemoveUsedMedicine(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, int selectedIndex, sbyte eatingSlot, PeriAdvanceMonthUpdateStatusModification mod)
	{
		var (medicine, amount) = medicines[selectedIndex];
		if (amount > 1)
		{
			medicines[selectedIndex] = (medicine, amount - 1);
		}
		else
		{
			medicines.RemoveAt(selectedIndex);
		}
		ItemKey itemKey = medicine.GetItemKey();
		_inventory.OfflineRemove(itemKey, 1);
		mod.InventoryChanged = true;
		if (eatingSlot >= 0)
		{
			_eatingItems.Set(eatingSlot, itemKey, medicine.GetDuration());
			mod.EatingItemsChanged = true;
		}
	}

	private void OfflineRemoveUsedTeaWine(List<(GameData.Domains.Item.TeaWine item, int amount)> items, int selectedIndex, sbyte eatingSlot, PeriAdvanceMonthUpdateStatusModification mod)
	{
		var (teaWine, amount) = items[selectedIndex];
		if (amount > 1)
		{
			items[selectedIndex] = (teaWine, amount - 1);
		}
		else
		{
			items.RemoveAt(selectedIndex);
		}
		ItemKey itemKey = teaWine.GetItemKey();
		_inventory.OfflineRemove(itemKey, 1);
		mod.InventoryChanged = true;
		short duration = Config.TeaWine.Instance[itemKey.TemplateId].Duration;
		_eatingItems.Set(eatingSlot, itemKey, duration);
		mod.EatingItemsChanged = true;
	}

	private void OfflineRemoveUsedFood(List<(GameData.Domains.Item.Food item, int amount)> items, int selectedIndex, sbyte eatingSlot, PeriAdvanceMonthUpdateStatusModification mod)
	{
		var (food, amount) = items[selectedIndex];
		if (amount > 1)
		{
			items[selectedIndex] = (food, amount - 1);
		}
		else
		{
			items.RemoveAt(selectedIndex);
		}
		ItemKey itemKey = food.GetItemKey();
		_inventory.OfflineRemove(itemKey, 1);
		mod.InventoryChanged = true;
		short duration = Config.Food.Instance[itemKey.TemplateId].Duration;
		_eatingItems.Set(eatingSlot, itemKey, duration);
		mod.EatingItemsChanged = true;
	}

	public unsafe int SelectTopicalMedicineIndex(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, sbyte level, ref MainAttributes mainAttributes, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int currIndex = 0; currIndex < medicines.Count; currIndex++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[currIndex];
			if (TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				continue;
			}
			sbyte requiredMainAttrType = medicine.Item1.GetRequiredMainAttributeType();
			sbyte requiredMainAttrVal = medicine.Item1.GetRequiredMainAttributeValue();
			if (mainAttributes.Items[requiredMainAttrType] >= requiredMainAttrVal)
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				int totalEffect = medicine.Item1.GetEffectValue() * medicine.Item1.GetInjuryRecoveryTimes() * medicine.Item1.GetDuration();
				if (totalEffect >= level)
				{
					return currIndex;
				}
				workingIndex = currIndex;
			}
		}
		return workingIndex;
	}

	public int SelectMedicineIndexForInjury(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, sbyte minLevel, sbyte injuryTotalLevel, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int currIndex = 0; currIndex < medicines.Count; currIndex++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[currIndex];
			if (!TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				int totalEffect = medicine.Item1.GetEffectValue() * medicine.Item1.GetInjuryRecoveryTimes() * medicine.Item1.GetDuration();
				if (totalEffect >= injuryTotalLevel)
				{
					return currIndex;
				}
				workingIndex = currIndex;
			}
		}
		return workingIndex;
	}

	public int SelectMedicineIndexForDetoxPoison(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, sbyte poisonType, sbyte level, int poisonedVal, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int i = 0; i < medicines.Count; i++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[i];
			if (medicine.Item1.GetEffectSubType().DetoxPoisonType() != poisonType)
			{
				continue;
			}
			MedicineItem config = Config.Medicine.Instance[medicine.Item1.GetTemplateId()];
			sbyte threshold = (sbyte)config.EffectThresholdValue;
			if (level <= threshold && !TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				int delta = CalcMedicineEffectDelta(poisonedVal, config.EffectValue, config.EffectIsPercentage, medicine.Item1.GetId());
				if (delta + poisonedVal <= 0)
				{
					return i;
				}
				workingIndex = i;
			}
		}
		return workingIndex;
	}

	public int SelectMedicineIndexForWug(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, sbyte wugType, short remainingDuration, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int i = 0; i < medicines.Count; i++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[i];
			if (EMedicineEffectSubTypeExtension.DetoxWugType(medicine.Item1.GetEffectType(), medicine.Item1.GetSideEffectValue()) == wugType && !TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				short deltaDuration = GameData.Domains.Item.Medicine.GetDeltaWugDuration(medicine.Item1.GetGrade());
				if (remainingDuration + deltaDuration <= 0)
				{
					return i;
				}
				workingIndex = i;
			}
		}
		return workingIndex;
	}

	public static int SelectPoisonIndexForWug(List<(GameData.Domains.Item.Medicine item, int amount)> poisons, sbyte wugType, short remainingDuration, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int i = 0; i < poisons.Count; i++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = poisons[i];
			if (EMedicineEffectSubTypeExtension.DetoxWugType(medicine.Item1.GetEffectType(), medicine.Item1.GetSideEffectValue()) == wugType)
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				short deltaDuration = GameData.Domains.Item.Medicine.GetDeltaWugDuration(medicine.Item1.GetGrade());
				if (remainingDuration + deltaDuration <= 0)
				{
					return i;
				}
				workingIndex = i;
			}
		}
		return workingIndex;
	}

	public int SelectMedicineIndexForQiDisorder(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, short disorderOfQi, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int index = 0; index < medicines.Count; index++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[index];
			if (!TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				int delta = CalcMedicineEffectDelta(disorderOfQi, medicine.Item1.GetEffectValue(), medicine.Item1.GetEffectSubType().IsPercentage(), medicine.Item1.GetId());
				if (disorderOfQi + delta <= DisorderLevelOfQi.MinValue)
				{
					return index;
				}
				workingIndex = index;
			}
		}
		return workingIndex;
	}

	public int SelectMedicineIndexForHealth(List<(GameData.Domains.Item.Medicine item, int amount)> medicines, short health, short leftMaxHealth, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int index = 0; index < medicines.Count; index++)
		{
			(GameData.Domains.Item.Medicine, int) medicine = medicines[index];
			if (!TryDetectAttachedPoisons(medicine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(medicine.Item1.GetItemKey());
				}
				int delta = CalcMedicineEffectDelta(leftMaxHealth - health, medicine.Item1.GetEffectValue(), medicine.Item1.GetEffectSubType().IsPercentage(), medicine.Item1.GetId());
				if (health + delta >= leftMaxHealth)
				{
					return index;
				}
				workingIndex = index;
			}
		}
		return workingIndex;
	}

	public int SelectItemIndexForNeili(List<(GameData.Domains.Item.Misc item, int amount)> items, int currNeili, int maxNeili, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int index = 0; index < items.Count; index++)
		{
			(GameData.Domains.Item.Misc, int) misc = items[index];
			if (!TryDetectAttachedPoisons(misc.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(misc.Item1.GetItemKey());
				}
				if (currNeili + misc.Item1.GetNeili() >= maxNeili)
				{
					return index;
				}
				workingIndex = index;
			}
		}
		return workingIndex;
	}

	public unsafe int SelectFoodIndexForMainAttributes(List<(GameData.Domains.Item.Food item, int amount)> foods, sbyte attrType, short currAttr, short maxAttr, bool allowMeat, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int index = 0; index < foods.Count; index++)
		{
			(GameData.Domains.Item.Food, int) food = foods[index];
			FoodItem config = Config.Food.Instance[food.Item1.GetTemplateId()];
			if ((allowMeat || config.ItemSubType != 701) && !TryDetectAttachedPoisons(food.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(food.Item1.GetItemKey());
				}
				if (currAttr + config.MainAttributesRegen.Items[attrType] >= maxAttr)
				{
					return index;
				}
				workingIndex = index;
			}
		}
		return workingIndex;
	}

	public int SelectTeaWineForHappiness(List<(GameData.Domains.Item.TeaWine item, int amount)> teaWines, int currHappiness, int targetHappiness, bool allowWines, List<ItemKey> selections = null)
	{
		bool hasSelections = selections != null;
		if (hasSelections)
		{
			selections.Clear();
		}
		int workingIndex = -1;
		for (int index = 0; index < teaWines.Count; index++)
		{
			(GameData.Domains.Item.TeaWine, int) teaWine = teaWines[index];
			TeaWineItem config = Config.TeaWine.Instance[teaWine.Item1.GetTemplateId()];
			if ((allowWines || config.ItemSubType != 901) && !TryDetectAttachedPoisons(teaWine.Item1.GetItemKey()))
			{
				if (hasSelections)
				{
					selections.Add(teaWine.Item1.GetItemKey());
				}
				if (currHappiness + teaWine.Item1.GetHappinessChange() >= targetHappiness)
				{
					return index;
				}
				workingIndex = index;
			}
		}
		return workingIndex;
	}

	private bool TripleStartRelationChance(short aiRelationsTemplateId)
	{
		Location tripleAdoreLocation = DomainManager.Character.TripleAdoreLocation;
		Location tripleHateLocation = DomainManager.Character.TripleHateLocation;
		if (aiRelationsTemplateId == 2 && tripleAdoreLocation.IsValid() && tripleAdoreLocation.AreaId == _location.AreaId)
		{
			byte areaData = DomainManager.Map.GetAreaSize(_location.AreaId);
			ByteCoordinate tripleAdoreCoordinate = ByteCoordinate.IndexToCoordinate(tripleAdoreLocation.BlockId, areaData);
			ByteCoordinate selfCoordinate = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaData);
			return tripleAdoreCoordinate.GetManhattanDistance(selfCoordinate) <= 2;
		}
		if (aiRelationsTemplateId == 0 && tripleHateLocation.IsValid() && tripleHateLocation.AreaId == _location.AreaId)
		{
			byte areaData2 = DomainManager.Map.GetAreaSize(_location.AreaId);
			ByteCoordinate tripleHateCoordinate = ByteCoordinate.IndexToCoordinate(tripleHateLocation.BlockId, areaData2);
			ByteCoordinate selfCoordinate2 = ByteCoordinate.IndexToCoordinate(_location.BlockId, areaData2);
			return tripleHateCoordinate.GetManhattanDistance(selfCoordinate2) <= 2;
		}
		return false;
	}

	private Character GetStartOrEndRelationTarget(IRandomSource random, short aiRelationsTemplateId, List<int> selectableChars, ref Personalities selfPersonalities)
	{
		if (selectableChars.Count == 0)
		{
			return null;
		}
		int multiplier = ((!TripleStartRelationChance(aiRelationsTemplateId)) ? 1 : 3);
		AiRelationsItem relationCfg = AiHelper.Relation.GetAiRelationConfig(aiRelationsTemplateId);
		if (!AiHelper.Relation.CheckChangeRelationTypeChance(random, ref selfPersonalities, relationCfg.PersonalityType, multiplier))
		{
			return null;
		}
		int targetCharId = selectableChars.GetRandom(random);
		Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
		RelatedCharacter relation = DomainManager.Character.GetRelation(_id, targetCharId);
		sbyte sectFavorability = DomainManager.Organization.GetSectFavorability(_organizationInfo.OrgTemplateId, targetChar.GetOrganizationInfo().OrgTemplateId);
		int triggerRate = AiHelper.Relation.GetStartOrEndRelationChance(relationCfg, this, targetChar, relation.RelationType, sectFavorability, multiplier);
		return random.CheckProb(triggerRate, 10000) ? targetChar : null;
	}

	private Character GetStartAdoptiveParentRelationTarget(IRandomSource random, short aiRelationsTemplateId, List<int> selectableChars, ref Personalities selfPersonalities)
	{
		if (selectableChars.Count == 0)
		{
			return null;
		}
		AiRelationsItem relationCfg = AiHelper.Relation.GetAiRelationConfig(aiRelationsTemplateId);
		if (!AiHelper.Relation.CheckChangeRelationTypeChance(random, ref selfPersonalities, relationCfg.PersonalityType))
		{
			return null;
		}
		int targetCharId = selectableChars.GetRandom(random);
		Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
		RelatedCharacter relation = DomainManager.Character.GetRelation(targetCharId, _id);
		int triggerProb = targetChar.GetCurrAge() - _currAge;
		triggerProb += (targetChar.GetInteractionGrade(this) - GetInteractionGrade(targetChar)) * 3;
		triggerProb += (FavorabilityType.GetFavorabilityType(relation.Favorability) - 4) * 5;
		return random.CheckPercentProb(triggerProb) ? targetChar : null;
	}

	private Character GetStartAdoptiveChildRelationTarget(IRandomSource random, short aiRelationsTemplateId, List<int> selectableChars, ref Personalities selfPersonalities)
	{
		if (selectableChars.Count == 0)
		{
			return null;
		}
		AiRelationsItem relationCfg = AiHelper.Relation.GetAiRelationConfig(aiRelationsTemplateId);
		if (!AiHelper.Relation.CheckChangeRelationTypeChance(random, ref selfPersonalities, relationCfg.PersonalityType))
		{
			return null;
		}
		int targetCharId = selectableChars.GetRandom(random);
		Character targetChar = DomainManager.Character.GetElement_Objects(targetCharId);
		RelatedCharacter relation = DomainManager.Character.GetRelation(targetCharId, _id);
		int triggerProb = _currAge - targetChar.GetCurrAge();
		triggerProb += (GetInteractionGrade(targetChar) - targetChar.GetInteractionGrade(this)) * 3;
		triggerProb += (FavorabilityType.GetFavorabilityType(relation.Favorability) - 4) * 5;
		return random.CheckPercentProb(triggerProb) ? targetChar : null;
	}

	public void PeriAdvanceMonth_RelationsUpdate(DataContext context, HashSet<int> charSet)
	{
		if (GetAgeGroup() == 0 || DomainManager.LegendaryBook.IsCharacterActingCrazy(this))
		{
			return;
		}
		PeriAdvanceMonthRelationsUpdateModification mod = new PeriAdvanceMonthRelationsUpdateModification(this);
		bool isChanged = false;
		List<Character> newlyMetCharacters = new List<Character>();
		PotentialRelatedCharacters canStartRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Occupy();
		PotentialRelatedCharacters canEndRelationChars = context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Occupy();
		DomainManager.Character.GetPotentialRelatedCharactersInSet(canStartRelationChars, canEndRelationChars, newlyMetCharacters, this, charSet);
		if (newlyMetCharacters.Count != 0)
		{
			mod.NewlyMetCharacters = newlyMetCharacters;
			isChanged = true;
		}
		Personalities personalities = GetPersonalities();
		IRandomSource random = context.Random;
		Character targetChar = GetStartOrEndRelationTarget(random, 0, canStartRelationChars.Enemies, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			sbyte targetBehaviorType = targetChar.GetBehaviorType();
			bool targetHateBack = random.CheckPercentProb(AiHelper.RelationsRelatedConstants.SeverEnemyNotMutuallyChance[targetBehaviorType]);
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 32768, targetHateBack));
		}
		targetChar = GetStartOrEndRelationTarget(random, 1, canEndRelationChars.Enemies, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			sbyte targetBehaviorType2 = targetChar.GetBehaviorType();
			bool targetStillHateSelf = random.CheckPercentProb(AiHelper.RelationsRelatedConstants.SeverEnemyNotMutuallyChance[targetBehaviorType2]);
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.RemovedRegularRelations.Add((targetChar, 32768, targetStillHateSelf));
		}
		targetChar = GetStartOrEndRelationTarget(random, 2, canStartRelationChars.Adored, ref personalities);
		if (targetChar != null)
		{
			RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(_id, targetChar.GetId());
			RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(targetChar.GetId(), _id);
			int successRate = AiHelper.Relation.GetStartRelationSuccessRate_Adored(this, targetChar, selfToTarget, targetToSelf);
			if (random.CheckProb(successRate, 100))
			{
				isChanged = true;
				int targetLovesBackRate = AiHelper.Relation.GetStartRelationSuccessRate_Adored(targetChar, this, selfToTarget, targetToSelf);
				PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
				if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
				{
					periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
				}
				mod.NewRegularRelations.Add((targetChar, 16384, random.CheckPercentProb(targetLovesBackRate)));
			}
		}
		targetChar = GetStartOrEndRelationTarget(random, 3, canStartRelationChars.BoyAndGirlFriends, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			RelatedCharacter selfToTarget2 = DomainManager.Character.GetRelation(_id, targetChar.GetId());
			RelatedCharacter targetToSelf2 = DomainManager.Character.GetRelation(targetChar.GetId(), _id);
			int successRate2 = AiHelper.Relation.GetStartRelationSuccessRate_BoyOrGirlFriend(this, targetChar, selfToTarget2, targetToSelf2);
			mod.NewBoyOrGirlFriend = (targetChar: targetChar, succeed: random.CheckPercentProb(successRate2));
		}
		targetChar = GetStartOrEndRelationTarget(random, 4, canEndRelationChars.BoyAndGirlFriends, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			sbyte targetBehaviorType3 = targetChar.GetBehaviorType();
			bool targetStillLoveSelf = !random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BreakupMutuallyChance[targetBehaviorType3]);
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.RemovedRegularRelations.Add((targetChar, 16384, targetStillLoveSelf));
		}
		targetChar = GetStartOrEndRelationTarget(random, 5, canStartRelationChars.HusbandsAndWives, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			RelatedCharacter selfToTarget3 = DomainManager.Character.GetRelation(_id, targetChar.GetId());
			RelatedCharacter targetToSelf3 = DomainManager.Character.GetRelation(targetChar.GetId(), _id);
			int successRate3 = AiHelper.Relation.GetStartRelationSuccessRate_HusbandOrWife(this, targetChar, selfToTarget3, targetToSelf3);
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 1024, random.CheckProb(successRate3, 100)));
		}
		targetChar = GetStartOrEndRelationTarget(random, 12, canEndRelationChars.HusbandsAndWives, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.RemovedRegularRelations.Add((targetChar, 1024, false));
		}
		targetChar = GetStartOrEndRelationTarget(random, 6, canStartRelationChars.Friends, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 8192, true));
		}
		targetChar = GetStartOrEndRelationTarget(random, 7, canEndRelationChars.Friends, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.RemovedRegularRelations.Add((targetChar, 8192, false));
		}
		targetChar = GetStartOrEndRelationTarget(random, 8, canStartRelationChars.SwornBrothersAndSisters, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 512, true));
		}
		targetChar = GetStartOrEndRelationTarget(random, 9, canEndRelationChars.SwornBrothersAndSisters, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.RemovedRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.RemovedRegularRelations.Add((targetChar, 512, false));
		}
		targetChar = GetStartAdoptiveParentRelationTarget(random, 10, canStartRelationChars.AdoptiveParents, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 64, true));
		}
		targetChar = GetStartAdoptiveChildRelationTarget(random, 11, canStartRelationChars.AdoptiveChildren, ref personalities);
		if (targetChar != null)
		{
			isChanged = true;
			PeriAdvanceMonthRelationsUpdateModification periAdvanceMonthRelationsUpdateModification = mod;
			if (periAdvanceMonthRelationsUpdateModification.NewRegularRelations == null)
			{
				periAdvanceMonthRelationsUpdateModification.NewRegularRelations = new List<(Character, ushort, bool)>();
			}
			mod.NewRegularRelations.Add((targetChar, 128, true));
		}
		if (isChanged)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.PeriAdvanceMonthRelationsUpdate);
			recorder.RecordParameterClass(mod);
		}
		context.AdvanceMonthRelatedData.CurrBlockCanStartRelationChars.Release(ref canStartRelationChars);
		context.AdvanceMonthRelatedData.CurrBlockCanEndRelationChars.Release(ref canEndRelationChars);
	}

	public static void ComplementPeriAdvanceMonth_RelationsUpdate(DataContext context, PeriAdvanceMonthRelationsUpdateModification mod)
	{
		Character character = mod.Character;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int charId = character.GetId();
		sbyte charBehaviorType = character.GetBehaviorType();
		bool charIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(charId);
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		sbyte taiwuGender = DomainManager.Taiwu.GetTaiwu().GetGender();
		if (mod.NewlyMetCharacters != null)
		{
			foreach (Character targetChar in mod.NewlyMetCharacters)
			{
				DomainManager.Character.TryCreateGeneralRelation(context, character, targetChar);
			}
		}
		if (mod.NewRegularRelations != null)
		{
			foreach (var newRegularRelation in mod.NewRegularRelations)
			{
				Character targetChar2 = newRegularRelation.targetChar;
				ushort relationType = newRegularRelation.relationType;
				bool succeed = newRegularRelation.succeed;
				bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetChar2._id);
				switch (relationType)
				{
				case 64:
					if (targetChar2._id == taiwuCharId)
					{
						if (taiwuGender == 0)
						{
							monthlyEventCollection.AddGetAdoptedByMother(charId, taiwuLocation, taiwuCharId);
						}
						else
						{
							monthlyEventCollection.AddGetAdoptedByFather(charId, taiwuLocation, taiwuCharId);
						}
					}
					else
					{
						ApplyAddRelation_AdoptiveParent(context, character, targetChar2, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 128:
					if (targetChar2._id == taiwuCharId)
					{
						if (taiwuGender == 0)
						{
							monthlyEventCollection.AddAdoptDaughter(charId, taiwuLocation, taiwuCharId);
						}
						else
						{
							monthlyEventCollection.AddAdoptSon(charId, taiwuLocation, taiwuCharId);
						}
					}
					else
					{
						ApplyAddRelation_AdoptiveChild(context, character, targetChar2, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 512:
					if (targetChar2._id == taiwuCharId)
					{
						monthlyEventCollection.AddBecomeSwornBrotherOrSister(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplyBecomeSwornBrotherOrSister(context, character, targetChar2, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 1024:
					if (targetChar2._id == taiwuCharId)
					{
						monthlyEventCollection.AddProposeMarriage(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplyBecomeHusbandOrWife(context, character, targetChar2, charBehaviorType, succeed, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 8192:
					if (targetChar2._id == taiwuCharId)
					{
						monthlyEventCollection.AddBecomeFriend(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplyBecomeFriend(context, character, targetChar2, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 16384:
					if (targetChar2._id == taiwuCharId)
					{
						monthlyEventCollection.AddAdore(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplyAddRelation_Adore(context, character, targetChar2, charBehaviorType, succeed, charIsTaiwuPeople, targetIsTaiwuPeople);
					}
					break;
				case 32768:
					if (targetChar2._id == taiwuCharId)
					{
						monthlyEventCollection.AddMakeEnemy(charId, taiwuLocation, taiwuCharId);
						break;
					}
					ApplyAddRelation_Enemy(context, character, targetChar2, charIsTaiwuPeople, 0);
					if (succeed)
					{
						ApplyAddRelation_Enemy(context, targetChar2, character, targetIsTaiwuPeople, 0);
					}
					break;
				default:
					throw new Exception($"Given relation type cannot be handled as a regular relation type {relationType}");
				}
			}
		}
		if (mod.RemovedRegularRelations != null)
		{
			foreach (var removedRegularRelation in mod.RemovedRegularRelations)
			{
				Character targetChar3 = removedRegularRelation.targetChar;
				ushort relationType2 = removedRegularRelation.relationType;
				bool targetStillHasRelation = removedRegularRelation.targetStillHasRelation;
				bool targetIsTaiwuPeople2 = DomainManager.Character.IsTaiwuPeople(targetChar3._id);
				switch (relationType2)
				{
				case 512:
					if (targetChar3._id == taiwuCharId)
					{
						monthlyEventCollection.AddSeverSwornBrotherhood(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplySeverSwornBrotherOrSister(context, character, targetChar3, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople2);
					}
					break;
				case 1024:
					if (targetChar3._id != taiwuCharId)
					{
						ApplySeverHusbandOrWife(context, character, targetChar3, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople2);
					}
					break;
				case 8192:
					if (targetChar3._id == taiwuCharId)
					{
						monthlyEventCollection.AddSeverFriendship(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplySeverFriend(context, character, targetChar3, charBehaviorType, charIsTaiwuPeople, targetIsTaiwuPeople2);
					}
					break;
				case 16384:
					if (targetChar3._id == taiwuCharId)
					{
						monthlyEventCollection.AddBreakup(charId, taiwuLocation, taiwuCharId);
					}
					else
					{
						ApplyBreakupWithBoyOrGirlFriend(context, character, targetChar3, charBehaviorType, targetStillHasRelation, charIsTaiwuPeople, targetIsTaiwuPeople2);
					}
					break;
				case 32768:
					if (targetChar3._id == taiwuCharId)
					{
						monthlyEventCollection.AddSeverEnemy(charId, taiwuLocation, taiwuCharId);
						break;
					}
					ApplySeverEnemy(context, character, targetChar3, charBehaviorType, charIsTaiwuPeople);
					if (!targetStillHasRelation)
					{
						ApplySeverEnemy(context, targetChar3, character, targetChar3.GetBehaviorType(), targetIsTaiwuPeople2);
					}
					break;
				default:
					throw new Exception($"Given relation type cannot be handled as a regular relation type {relationType2}");
				}
			}
		}
		if (mod.NewBoyOrGirlFriend.targetChar != null)
		{
			var (targetChar4, succeed2) = mod.NewBoyOrGirlFriend;
			if (targetChar4._id == taiwuCharId)
			{
				monthlyEventCollection.AddConfess(charId, taiwuLocation, taiwuCharId);
				return;
			}
			bool targetIsTaiwuPeople3 = DomainManager.Character.IsTaiwuPeople(targetChar4._id);
			ApplyBecomeBoyOrGirlFriend(context, character, targetChar4, charBehaviorType, succeed2, charIsTaiwuPeople, targetIsTaiwuPeople3);
		}
	}

	public static void ApplyAddRelation_Enemy(DataContext context, Character selfChar, Character targetChar, bool selfIsTaiwuPeople, short becomeEnemyType)
	{
		CharacterBecomeEnemyInfo becomeEnemyInfo = new CharacterBecomeEnemyInfo(selfChar);
		ApplyAddRelation_Enemy(context, selfChar, targetChar, selfIsTaiwuPeople, becomeEnemyType, becomeEnemyInfo);
	}

	public static void ApplyAddRelation_Enemy(DataContext context, Character selfChar, Character targetChar, bool selfIsTaiwuPeople, short becomeEnemyType, CharacterBecomeEnemyInfo becomeEnemyInfo)
	{
		if (RelationTypeHelper.AllowAddingEnemyRelation(selfChar._id, targetChar._id))
		{
			int currDate = DomainManager.World.GetCurrDate();
			Location location = selfChar._location;
			if (!location.IsValid())
			{
				location = targetChar._location;
			}
			DomainManager.Character.AddRelation(context, selfChar._id, targetChar._id, 32768, currDate);
			sbyte charBehaviorType = selfChar.GetBehaviorType();
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeEnemyHappinessChange[charBehaviorType]);
			BecomeEnemyTypeItem becomeEnemyCfg = BecomeEnemyType.Instance[becomeEnemyType];
			LifeRecordCollection collection = DomainManager.LifeRecord.GetLifeRecordCollection();
			collection.AddBecomeEnemyRecord(selfChar, targetChar, becomeEnemyCfg, ref becomeEnemyInfo);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeEnemy(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople)
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddCreateHatred(selfChar._id, location, targetChar._id);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfChar._id);
			}
		}
	}

	public static void ApplySeverEnemy(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople)
	{
		int currDate = DomainManager.World.GetCurrDate();
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (DomainManager.Character.HasRelation(charId, targetCharId, 32768))
		{
			Location location = selfChar._location;
			DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 32768, 0);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverEnemyHappinessChange[charBehaviorType]);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 3000);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddSeverEnemy(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddSeverEnemy(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople)
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddDecreaseHatred(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfChar._id);
			}
		}
	}

	public static void ApplyBecomeFriend(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (RelationTypeHelper.AllowAddingFriendRelation(targetCharId, charId))
		{
			sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
			Location location = selfChar._location;
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			DomainManager.Character.AddRelation(context, charId, targetCharId, 8192, currDate);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeFriendHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeFriendHappinessChange[targetCharBehaviorType]);
			lifeRecordCollection.AddBecomeFriend(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeFriend(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				monthlyNotificationCollection.AddBecomeFriend(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
			}
			DomainManager.Character.AddFavorabilityChangeInstantNotification(targetChar, selfChar, isIncrease: true);
		}
	}

	public static void ApplySeverFriend(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!DomainManager.Character.HasRelation(targetCharId, charId, 8192))
		{
			return;
		}
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 8192, 0);
		DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 8192, 0);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -8000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -8000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverFriendHappinessChange[charBehaviorType]);
		targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverFriendHappinessChange[targetCharBehaviorType]);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (charId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, targetCharId, 8000);
		}
		if (targetCharId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, charId, 8000);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		sbyte becomeEnemy = AiHelper.RelationsRelatedConstants.FriendshipBreakBecomeEnemy[targetCharBehaviorType];
		if (context.Random.CheckPercentProb(becomeEnemy))
		{
			DomainManager.Character.AddRelation(context, targetCharId, charId, 32768, DomainManager.World.GetCurrDate());
			int secretInfoOffset1 = secretInformationCollection.AddBecomeEnemy(targetChar._id, selfChar._id);
			SecretInformationId secretInfoId1 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset1);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId1, taiwuCharId);
			}
		}
		lifeRecordCollection.AddSeverFriendship(charId, currDate, targetCharId, location);
		int secretInfoOffset2 = secretInformationCollection.AddSeverFriend(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		if (selfIsTaiwuPeople || targetIsTaiwuPeople)
		{
			monthlyNotificationCollection.AddDecreaseFriendship(charId, location, targetCharId);
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId2, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
		}
	}

	public static void ApplyBecomeSwornBrotherOrSister(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (RelationTypeHelper.AllowAddingSwornBrotherOrSisterRelation(targetCharId, charId))
		{
			sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
			Location location = selfChar._location;
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			DomainManager.Character.AddRelation(context, charId, targetCharId, 512, currDate);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 12000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 12000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[targetCharBehaviorType]);
			lifeRecordCollection.AddBecomeSwornBrotherOrSister(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeSwornBrothersAndSisters(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				monthlyNotificationCollection.AddBecomeSwornBrotherOrSister(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
			}
		}
	}

	public static void ApplySeverSwornBrotherOrSister(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!DomainManager.Character.HasRelation(targetCharId, charId, 512))
		{
			return;
		}
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 512, 0);
		DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 512, 0);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -16000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -16000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverSwornOrAdoptedFamilyHappinessChange[charBehaviorType]);
		targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverSwornOrAdoptedFamilyHappinessChange[targetCharBehaviorType]);
		lifeRecordCollection.AddSeverSwornBrotherhood(charId, currDate, targetCharId, location);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (charId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, targetCharId, 20000);
		}
		if (targetCharId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, charId, 20000);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		sbyte becomeEnemy = AiHelper.RelationsRelatedConstants.AdoptedBecomeEnemy[targetCharBehaviorType];
		if (context.Random.CheckPercentProb(becomeEnemy))
		{
			DomainManager.Character.AddRelation(context, targetCharId, charId, 32768, DomainManager.World.GetCurrDate());
			int secretInfoOffset1 = secretInformationCollection.AddBecomeEnemy(targetChar._id, selfChar._id);
			SecretInformationId secretInfoId1 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset1);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId1, taiwuCharId);
			}
		}
		int secretInfoOffset2 = secretInformationCollection.AddSeverSwornBrothersAndSisters(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		if (selfIsTaiwuPeople || targetIsTaiwuPeople)
		{
			monthlyNotificationCollection.AddSeverFriendship(charId, location, targetCharId);
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId2, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
		}
	}

	public static void ApplySeverHusbandOrWife(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (DomainManager.Character.HasRelation(targetCharId, charId, 1024))
		{
			sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
			Location location = selfChar.GetValidLocation();
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 1024, 0);
			DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 1024, 0);
			if (selfChar._organizationInfo.Principal)
			{
				DomainManager.Organization.TryDowngradeDeputySpouse(context, charId, selfChar._organizationInfo, targetCharId);
			}
			else
			{
				DomainManager.Organization.TryDowngradeDeputySpouse(context, targetCharId, targetChar._organizationInfo, charId);
			}
			DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 16384, 0);
			DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 16384, 0);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -20000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -20000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverHusbandOrWifeHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverHusbandOrWifeHappinessChange[targetCharBehaviorType]);
			lifeRecordCollection.AddDivorce(charId, currDate, targetCharId, location);
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			if (charId == taiwuCharId)
			{
				DomainManager.Character.ChangeAlertness(context, targetCharId, 30000);
			}
			if (targetCharId == taiwuCharId)
			{
				DomainManager.Character.ChangeAlertness(context, charId, 30000);
			}
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddDivorce(charId, targetCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
	}

	public static void ApplyAddRelation_Adore(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool targetLovesBack, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!RelationTypeHelper.AllowAddingAdoredRelation(charId, targetCharId))
		{
			return;
		}
		if (targetChar.GetFeatureIds().Contains(685) && selfChar.GetId() != DomainManager.Taiwu.GetTaiwuCharIdForCloseFriend() && targetLovesBack)
		{
			targetLovesBack = false;
		}
		Location location = selfChar._location;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.Character.AddRelation(context, charId, targetCharId, 16384, currDate);
		lifeRecordCollection.AddAdore(charId, currDate, targetCharId, location);
		if (targetLovesBack && !DomainManager.Character.HasRelation(targetCharId, charId, 16384))
		{
			DomainManager.Character.AddRelation(context, targetCharId, charId, 16384);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveSucceedHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveSucceedHappinessChange[targetChar.GetBehaviorType()]);
			lifeRecordCollection.AddAdore(targetCharId, currDate, charId, location);
			lifeRecordCollection.AddLoveAtFirstSight(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeLover(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				monthlyNotificationCollection.AddConfessLoveAndSucceed(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
			}
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.ConfessLoveSucceedNeedForSexChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 272, targetCharId);
			}
		}
	}

	public static void ApplySeverAdore(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople)
	{
		int currDate = DomainManager.World.GetCurrDate();
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (DomainManager.Character.HasRelation(charId, targetCharId, 16384))
		{
			Location location = selfChar._location;
			DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 16384, 0);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveFailedHappinessChange[charBehaviorType]);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -3000);
			DomainManager.LifeRecord.GetLifeRecordCollection().AddEndAdored(charId, currDate, targetCharId, location);
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BecomeSingleNeedNewLoveChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 249, (ushort)16384);
			}
		}
	}

	public static void ApplyBecomeBoyOrGirlFriend(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool succeed, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!RelationTypeHelper.AllowAddingAdoredRelation(targetCharId, charId))
		{
			return;
		}
		Location location = selfChar._location;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		int currDate = DomainManager.World.GetCurrDate();
		if (succeed)
		{
			DomainManager.Character.AddRelation(context, targetCharId, charId, 16384);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveSucceedHappinessChange[charBehaviorType]);
			lifeRecordCollection.AddConfessLoveSucceed(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeLover(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				monthlyNotificationCollection.AddConfessLoveAndSucceed(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
			}
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.ConfessLoveSucceedNeedForSexChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 272, targetCharId);
			}
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveFailedHappinessChange[charBehaviorType]);
			lifeRecordCollection.AddConfessLoveFail(charId, currDate, targetCharId, location);
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BecomeSingleNeedNewLoveChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 249, (ushort)16384);
			}
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.ConfessLoveFailedNeedForRapeChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 272, targetCharId);
			}
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.ConfessLoveOrProposeFailedBecomeEnemyChance[charBehaviorType]))
			{
				ApplyAddRelation_Enemy(context, selfChar, targetChar, selfIsTaiwuPeople, 9);
			}
		}
	}

	public static void ApplyBreakupWithBoyOrGirlFriend(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool targetStillLoveSelf, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!DomainManager.Character.HasRelation(targetCharId, charId, 16384))
		{
			return;
		}
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		sbyte targetBehaviorType = targetChar.GetBehaviorType();
		DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 16384, 0);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -12000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -12000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveFailedHappinessChange[charBehaviorType]);
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddBreakupWithLover(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		if (selfIsTaiwuPeople || targetIsTaiwuPeople)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddSeverLove(charId, location, targetCharId);
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
		}
		if (targetStillLoveSelf)
		{
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDumpLover(charId, currDate, targetCharId, location);
		}
		else
		{
			DomainManager.LifeRecord.GetLifeRecordCollection().AddBreakupMutually(charId, currDate, targetCharId, location);
			DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 16384, 0);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ConfessLoveFailedHappinessChange[targetBehaviorType]);
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BreakupBecomeEnemyChance[targetBehaviorType]))
			{
				ApplyAddRelation_Enemy(context, targetChar, selfChar, targetIsTaiwuPeople, 3);
			}
		}
		if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BecomeSingleNeedNewLoveChance[charBehaviorType]))
		{
			selfChar.AddGoal(context, 249, (ushort)16384);
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (charId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, targetCharId, 10000);
		}
		if (targetCharId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, charId, 10000);
		}
	}

	public static void ApplyBecomeHusbandOrWife(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool succeed, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!RelationTypeHelper.AllowAddingHusbandOrWifeRelation(targetCharId, charId))
		{
			return;
		}
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (succeed)
		{
			DomainManager.Character.AddHusbandOrWifeRelations(context, charId, targetCharId, currDate);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 12000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 12000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ProposeMarriageSucceedHappinessChange[charBehaviorType]);
			lifeRecordCollection.AddProposeMarriageSucceed(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddBecomeHusbandAndWife(selfChar._id, targetChar._id);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				monthlyNotificationCollection.AddMarriage(charId, location, targetCharId);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfIsTaiwuPeople ? selfChar._id : targetChar._id);
			}
			DomainManager.Organization.UpdateOrganizationAfterMarriage(context, selfChar, targetChar);
			selfChar.AddGoal(context, 272, targetCharId);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.ProposeMarriageFailHappinessChange[charBehaviorType]);
			lifeRecordCollection.AddProposeMarriageFail(charId, currDate, targetCharId, location);
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.BecomeSingleNeedNewLoveChance[charBehaviorType]))
			{
				selfChar.AddGoal(context, 249, (ushort)16384);
			}
			if (context.Random.CheckPercentProb(AiHelper.RelationsRelatedConstants.ConfessLoveOrProposeFailedBecomeEnemyChance[charBehaviorType]))
			{
				ApplyAddRelation_Enemy(context, selfChar, targetChar, selfIsTaiwuPeople, 4);
			}
		}
	}

	public static void ApplyEndRelation_AdoptiveParent(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!DomainManager.Character.HasRelation(charId, targetCharId, 64))
		{
			return;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 64, 0);
		DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 128, 0);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -16000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -16000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverSwornOrAdoptedFamilyHappinessChange[charBehaviorType]);
		targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.SeverSwornOrAdoptedFamilyHappinessChange[targetCharBehaviorType]);
		if (charId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, targetCharId, 20000);
		}
		if (targetCharId == taiwuCharId)
		{
			DomainManager.Character.ChangeAlertness(context, charId, 20000);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		sbyte becomeEnemy = AiHelper.RelationsRelatedConstants.AdoptedBecomeEnemy[targetCharBehaviorType];
		if (context.Random.CheckPercentProb(becomeEnemy))
		{
			DomainManager.Character.AddRelation(context, targetCharId, charId, 32768, DomainManager.World.GetCurrDate());
			int secretInfoOffset1 = secretInformationCollection.AddBecomeEnemy(targetChar._id, selfChar._id);
			SecretInformationId secretInfoId1 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset1);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId1, taiwuCharId);
			}
		}
		lifeRecordCollection.AddSeverAdoptiveParent(charId, currDate, targetCharId, location);
		int secretInfoOffset2 = secretInformationCollection.AddSeverGetAdopted(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		if (selfIsTaiwuPeople)
		{
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId2, taiwuCharId, selfChar._id);
		}
		secretInfoOffset2 = secretInformationCollection.AddSeverAdoptChild(targetChar._id, selfChar._id);
		secretInfoId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		if (targetIsTaiwuPeople)
		{
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId2, taiwuCharId, targetChar._id);
		}
	}

	public static void ApplyEndRelation_AdoptiveChild(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		ApplyEndRelation_AdoptiveParent(context, targetChar, selfChar, targetChar.GetBehaviorType(), targetIsTaiwuPeople, selfIsTaiwuPeople);
	}

	public static void ApplyAddRelation_AdoptiveParent(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!RelationTypeHelper.AllowAddingAdoptiveParentRelation(charId, targetCharId))
		{
			return;
		}
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		DomainManager.Character.AddAdoptiveParentRelations(context, charId, targetCharId, currDate);
		int spouseId = DomainManager.Character.GetAliveSpouse(targetCharId);
		if (spouseId >= 0)
		{
			DomainManager.Character.AddAdoptiveParentRelations(context, charId, spouseId, currDate);
		}
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 12000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 12000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[charBehaviorType]);
		targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[targetCharBehaviorType]);
		short relatedRecordId = (short)((targetChar.GetGender() == 1) ? 46 : 47);
		if (selfChar.GetGender() == 1)
		{
			lifeRecordCollection.AddAdoptSon(targetCharId, currDate, charId, location, relatedRecordId);
		}
		else
		{
			lifeRecordCollection.AddAdoptDaughter(targetCharId, currDate, charId, location, relatedRecordId);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddGetAdopted(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		if (selfIsTaiwuPeople)
		{
			if (targetChar.GetGender() == 1)
			{
				monthlyNotificationCollection.AddRecognizeFather(charId, location, targetCharId);
			}
			else
			{
				monthlyNotificationCollection.AddRecognizeMother(charId, location, targetCharId);
			}
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfChar._id);
		}
		secretInfoOffset = secretInformationCollection.AddAdoptChild(targetChar._id, selfChar._id);
		secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		if (targetIsTaiwuPeople)
		{
			if (selfChar.GetGender() == 1)
			{
				monthlyNotificationCollection.AddAdoptBoy(targetCharId, location, charId);
			}
			else
			{
				monthlyNotificationCollection.AddAdoptGirl(targetCharId, location, charId);
			}
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), targetChar._id);
		}
	}

	public static void ApplyAddRelation_AdoptiveChild(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (!RelationTypeHelper.AllowAddingAdoptiveChildRelation(charId, targetCharId))
		{
			return;
		}
		sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
		Location location = selfChar._location;
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		DomainManager.Character.AddAdoptiveParentRelations(context, targetCharId, charId, currDate);
		int spouseId = DomainManager.Character.GetAliveSpouse(charId);
		if (spouseId >= 0)
		{
			DomainManager.Character.AddAdoptiveParentRelations(context, targetCharId, spouseId, currDate);
		}
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 12000);
		DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 12000);
		selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[charBehaviorType]);
		targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeSwornOrAdoptedFamilyHappinessChange[targetCharBehaviorType]);
		short relatedRecordId = (short)((selfChar.GetGender() == 1) ? 46 : 47);
		if (targetChar.GetGender() == 1)
		{
			lifeRecordCollection.AddAdoptSon(charId, currDate, targetCharId, location, relatedRecordId);
		}
		else
		{
			lifeRecordCollection.AddAdoptDaughter(charId, currDate, targetCharId, location, relatedRecordId);
		}
		SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
		int secretInfoOffset = secretInformationCollection.AddAdoptChild(selfChar._id, targetChar._id);
		SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		if (selfIsTaiwuPeople)
		{
			if (targetChar.GetGender() == 1)
			{
				monthlyNotificationCollection.AddAdoptBoy(charId, location, targetCharId);
			}
			else
			{
				monthlyNotificationCollection.AddAdoptGirl(charId, location, targetCharId);
			}
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), selfChar._id);
		}
		secretInfoOffset = secretInformationCollection.AddGetAdopted(targetChar._id, selfChar._id);
		secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		if (targetIsTaiwuPeople)
		{
			if (selfChar.GetGender() == 1)
			{
				monthlyNotificationCollection.AddRecognizeFather(targetCharId, location, charId);
			}
			else
			{
				monthlyNotificationCollection.AddRecognizeMother(targetCharId, location, charId);
			}
			DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, DomainManager.Taiwu.GetTaiwuCharId(), targetChar._id);
		}
	}

	public static void ApplyAddRelation_Mentor(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (RelationTypeHelper.AllowAddingMentorRelation(charId, targetCharId))
		{
			sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
			Location location = selfChar._location;
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			DomainManager.Character.AddRelation(context, charId, targetCharId, 2048);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, 3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, 3000);
			selfChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeMentorHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, AiHelper.RelationsRelatedConstants.BecomeMentorHappinessChange[targetCharBehaviorType]);
			lifeRecordCollection.AddGetMentor(charId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset1 = secretInformationCollection.AddBecomeMaster(charId, targetCharId);
			SecretInformationId secretId1 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset1);
			int secretInfoOffset2 = secretInformationCollection.AddBecomeApprentice(targetCharId, charId);
			SecretInformationId secretId2 = DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
			if (selfIsTaiwuPeople || targetIsTaiwuPeople)
			{
				DomainManager.Information.ReceiveSecretInformation(context, secretId1, DomainManager.Taiwu.GetTaiwuCharId());
				DomainManager.Information.ReceiveSecretInformation(context, secretId2, DomainManager.Taiwu.GetTaiwuCharId());
			}
		}
	}

	public static void ApplyEndRelation_Mentor(DataContext context, Character selfChar, Character targetChar, sbyte charBehaviorType, bool selfIsTaiwuPeople, bool targetIsTaiwuPeople)
	{
		int charId = selfChar._id;
		int targetCharId = targetChar._id;
		if (DomainManager.Character.HasRelation(charId, targetCharId, 2048))
		{
			sbyte targetCharBehaviorType = targetChar.GetBehaviorType();
			Location location = selfChar._location;
			int currDate = DomainManager.World.GetCurrDate();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
			DomainManager.Character.ChangeRelationType(context, charId, targetCharId, 2048, 0);
			DomainManager.Character.ChangeRelationType(context, targetCharId, charId, 4096, 0);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, selfChar, targetChar, -3000);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, targetChar, selfChar, -3000);
			selfChar.ChangeHappiness(context, -AiHelper.RelationsRelatedConstants.BecomeMentorHappinessChange[charBehaviorType]);
			targetChar.ChangeHappiness(context, -AiHelper.RelationsRelatedConstants.BecomeMentorHappinessChange[targetCharBehaviorType]);
			lifeRecordCollection.AddSeverMentor(charId, currDate, targetCharId, location);
			if (!(selfIsTaiwuPeople || targetIsTaiwuPeople))
			{
			}
		}
	}

	public int GetId()
	{
		return _id;
	}

	public short GetTemplateId()
	{
		return _templateId;
	}

	public byte GetCreatingType()
	{
		return _creatingType;
	}

	public sbyte GetGender()
	{
		return _gender;
	}

	public short GetActualAge()
	{
		return _actualAge;
	}

	public void SetActualAge(short actualAge, DataContext context)
	{
		_actualAge = actualAge;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public sbyte GetBirthMonth()
	{
		return _birthMonth;
	}

	public sbyte GetHappiness()
	{
		return _happiness;
	}

	public void SetHappiness(sbyte happiness, DataContext context)
	{
		_happiness = happiness;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public short GetBaseMorality()
	{
		return _baseMorality;
	}

	public void SetBaseMorality(short baseMorality, DataContext context)
	{
		_baseMorality = baseMorality;
		SetModifiedAndInvalidateInfluencedCache(7, context);
	}

	public OrganizationInfo GetOrganizationInfo()
	{
		return _organizationInfo;
	}

	public void SetOrganizationInfo(OrganizationInfo organizationInfo, DataContext context)
	{
		_organizationInfo = organizationInfo;
		SetModifiedAndInvalidateInfluencedCache(8, context);
	}

	public sbyte GetIdealSect()
	{
		return _idealSect;
	}

	public void SetIdealSect(sbyte idealSect, DataContext context)
	{
		_idealSect = idealSect;
		SetModifiedAndInvalidateInfluencedCache(9, context);
	}

	public sbyte GetLifeSkillTypeInterest()
	{
		return _lifeSkillTypeInterest;
	}

	public void SetLifeSkillTypeInterest(sbyte lifeSkillTypeInterest, DataContext context)
	{
		_lifeSkillTypeInterest = lifeSkillTypeInterest;
		SetModifiedAndInvalidateInfluencedCache(10, context);
	}

	public sbyte GetCombatSkillTypeInterest()
	{
		return _combatSkillTypeInterest;
	}

	public void SetCombatSkillTypeInterest(sbyte combatSkillTypeInterest, DataContext context)
	{
		_combatSkillTypeInterest = combatSkillTypeInterest;
		SetModifiedAndInvalidateInfluencedCache(11, context);
	}

	public sbyte GetMainAttributeInterest()
	{
		return _mainAttributeInterest;
	}

	public void SetMainAttributeInterest(sbyte mainAttributeInterest, DataContext context)
	{
		_mainAttributeInterest = mainAttributeInterest;
		SetModifiedAndInvalidateInfluencedCache(12, context);
	}

	public bool GetTransgender()
	{
		return _transgender;
	}

	public bool GetBisexual()
	{
		return _bisexual;
	}

	public sbyte GetXiangshuType()
	{
		return _xiangshuType;
	}

	public byte GetMonkType()
	{
		return _monkType;
	}

	public void SetMonkType(byte monkType, DataContext context)
	{
		_monkType = monkType;
		SetModifiedAndInvalidateInfluencedCache(16, context);
	}

	public List<short> GetFeatureIds()
	{
		return _featureIds;
	}

	public void SetFeatureIds(List<short> featureIds, DataContext context)
	{
		_featureIds = featureIds;
		SetModifiedAndInvalidateInfluencedCache(17, context);
	}

	public MainAttributes GetBaseMainAttributes()
	{
		return _baseMainAttributes;
	}

	public void SetBaseMainAttributes(MainAttributes baseMainAttributes, DataContext context)
	{
		_baseMainAttributes = baseMainAttributes;
		SetModifiedAndInvalidateInfluencedCache(18, context);
	}

	public short GetHealth()
	{
		return _health;
	}

	public void SetHealth(short health, DataContext context)
	{
		_health = health;
		SetModifiedAndInvalidateInfluencedCache(19, context);
	}

	public short GetBaseMaxHealth()
	{
		return _baseMaxHealth;
	}

	public void SetBaseMaxHealth(short baseMaxHealth, DataContext context)
	{
		_baseMaxHealth = baseMaxHealth;
		SetModifiedAndInvalidateInfluencedCache(20, context);
	}

	public short GetDisorderOfQi()
	{
		return _disorderOfQi;
	}

	public void SetDisorderOfQi(short disorderOfQi, DataContext context)
	{
		_disorderOfQi = disorderOfQi;
		SetModifiedAndInvalidateInfluencedCache(21, context);
	}

	public bool GetHaveLeftArm()
	{
		return _haveLeftArm;
	}

	public void SetHaveLeftArm(bool haveLeftArm, DataContext context)
	{
		_haveLeftArm = haveLeftArm;
		SetModifiedAndInvalidateInfluencedCache(22, context);
	}

	public bool GetHaveRightArm()
	{
		return _haveRightArm;
	}

	public void SetHaveRightArm(bool haveRightArm, DataContext context)
	{
		_haveRightArm = haveRightArm;
		SetModifiedAndInvalidateInfluencedCache(23, context);
	}

	public bool GetHaveLeftLeg()
	{
		return _haveLeftLeg;
	}

	public void SetHaveLeftLeg(bool haveLeftLeg, DataContext context)
	{
		_haveLeftLeg = haveLeftLeg;
		SetModifiedAndInvalidateInfluencedCache(24, context);
	}

	public bool GetHaveRightLeg()
	{
		return _haveRightLeg;
	}

	public void SetHaveRightLeg(bool haveRightLeg, DataContext context)
	{
		_haveRightLeg = haveRightLeg;
		SetModifiedAndInvalidateInfluencedCache(25, context);
	}

	public Injuries GetInjuries()
	{
		return _injuries;
	}

	public void SetInjuries(Injuries injuries, DataContext context)
	{
		_injuries = injuries;
		SetModifiedAndInvalidateInfluencedCache(26, context);
	}

	public int GetExtraNeili()
	{
		return _extraNeili;
	}

	public void SetExtraNeili(int extraNeili, DataContext context)
	{
		_extraNeili = extraNeili;
		SetModifiedAndInvalidateInfluencedCache(27, context);
	}

	public sbyte GetConsummateLevel()
	{
		return _consummateLevel;
	}

	public void SetConsummateLevel(sbyte consummateLevel, DataContext context)
	{
		_consummateLevel = consummateLevel;
		SetModifiedAndInvalidateInfluencedCache(28, context);
	}

	public List<LifeSkillItem> GetLearnedLifeSkills()
	{
		return _learnedLifeSkills;
	}

	public void SetLearnedLifeSkills(List<LifeSkillItem> learnedLifeSkills, DataContext context)
	{
		_learnedLifeSkills = learnedLifeSkills;
		SetModifiedAndInvalidateInfluencedCache(29, context);
	}

	public ref LifeSkillShorts GetBaseLifeSkillQualifications()
	{
		return ref _baseLifeSkillQualifications;
	}

	public void SetBaseLifeSkillQualifications(ref LifeSkillShorts baseLifeSkillQualifications, DataContext context)
	{
		_baseLifeSkillQualifications = baseLifeSkillQualifications;
		SetModifiedAndInvalidateInfluencedCache(30, context);
	}

	public sbyte GetLifeSkillQualificationGrowthType()
	{
		return _lifeSkillQualificationGrowthType;
	}

	public void SetLifeSkillQualificationGrowthType(sbyte lifeSkillQualificationGrowthType, DataContext context)
	{
		_lifeSkillQualificationGrowthType = lifeSkillQualificationGrowthType;
		SetModifiedAndInvalidateInfluencedCache(31, context);
	}

	public ref CombatSkillShorts GetBaseCombatSkillQualifications()
	{
		return ref _baseCombatSkillQualifications;
	}

	public void SetBaseCombatSkillQualifications(ref CombatSkillShorts baseCombatSkillQualifications, DataContext context)
	{
		_baseCombatSkillQualifications = baseCombatSkillQualifications;
		SetModifiedAndInvalidateInfluencedCache(32, context);
	}

	public sbyte GetCombatSkillQualificationGrowthType()
	{
		return _combatSkillQualificationGrowthType;
	}

	public void SetCombatSkillQualificationGrowthType(sbyte combatSkillQualificationGrowthType, DataContext context)
	{
		_combatSkillQualificationGrowthType = combatSkillQualificationGrowthType;
		SetModifiedAndInvalidateInfluencedCache(33, context);
	}

	public ref ResourceInts GetResources()
	{
		return ref _resources;
	}

	public void SetResources(ref ResourceInts resources, DataContext context)
	{
		_resources = resources;
		SetModifiedAndInvalidateInfluencedCache(34, context);
	}

	public short GetLovingItemSubType()
	{
		return _lovingItemSubType;
	}

	public void SetLovingItemSubType(short lovingItemSubType, DataContext context)
	{
		_lovingItemSubType = lovingItemSubType;
		SetModifiedAndInvalidateInfluencedCache(35, context);
	}

	public short GetHatingItemSubType()
	{
		return _hatingItemSubType;
	}

	public void SetHatingItemSubType(short hatingItemSubType, DataContext context)
	{
		_hatingItemSubType = hatingItemSubType;
		SetModifiedAndInvalidateInfluencedCache(36, context);
	}

	public FullName GetFullName()
	{
		return _fullName;
	}

	public void SetFullName(FullName fullName, DataContext context)
	{
		_fullName = fullName;
		SetModifiedAndInvalidateInfluencedCache(37, context);
	}

	public MonasticTitle GetMonasticTitle()
	{
		return _monasticTitle;
	}

	public void SetMonasticTitle(MonasticTitle monasticTitle, DataContext context)
	{
		_monasticTitle = monasticTitle;
		SetModifiedAndInvalidateInfluencedCache(38, context);
	}

	public AvatarData GetAvatar()
	{
		return _avatar;
	}

	public void SetAvatar(AvatarData avatar, DataContext context)
	{
		_avatar = avatar;
		SetModifiedAndInvalidateInfluencedCache(39, context);
	}

	public List<short> GetPotentialFeatureIds()
	{
		return _potentialFeatureIds;
	}

	public void SetPotentialFeatureIds(List<short> potentialFeatureIds, DataContext context)
	{
		_potentialFeatureIds = potentialFeatureIds;
		SetModifiedAndInvalidateInfluencedCache(40, context);
	}

	public List<FameActionRecord> GetFameActionRecords()
	{
		return _fameActionRecords;
	}

	public void SetFameActionRecords(List<FameActionRecord> fameActionRecords, DataContext context)
	{
		_fameActionRecords = fameActionRecords;
		SetModifiedAndInvalidateInfluencedCache(41, context);
	}

	public ref Genome GetGenome()
	{
		return ref _genome;
	}

	public MainAttributes GetCurrMainAttributes()
	{
		return _currMainAttributes;
	}

	public void SetCurrMainAttributes(MainAttributes currMainAttributes, DataContext context)
	{
		_currMainAttributes = currMainAttributes;
		SetModifiedAndInvalidateInfluencedCache(43, context);
	}

	public ref PoisonInts GetPoisoned()
	{
		return ref _poisoned;
	}

	public void SetPoisoned(ref PoisonInts poisoned, DataContext context)
	{
		_poisoned = poisoned;
		SetModifiedAndInvalidateInfluencedCache(44, context);
	}

	public int GetCurrNeili()
	{
		return _currNeili;
	}

	public void SetCurrNeili(int currNeili, DataContext context)
	{
		_currNeili = currNeili;
		SetModifiedAndInvalidateInfluencedCache(45, context);
	}

	public short GetLoopingNeigong()
	{
		return _loopingNeigong;
	}

	public void SetLoopingNeigong(short loopingNeigong, DataContext context)
	{
		_loopingNeigong = loopingNeigong;
		SetModifiedAndInvalidateInfluencedCache(46, context);
	}

	public NeiliAllocation GetBaseNeiliAllocation()
	{
		return _baseNeiliAllocation;
	}

	public void SetBaseNeiliAllocation(NeiliAllocation baseNeiliAllocation, DataContext context)
	{
		_baseNeiliAllocation = baseNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(47, context);
	}

	public NeiliAllocation GetExtraNeiliAllocation()
	{
		return _extraNeiliAllocation;
	}

	public void SetExtraNeiliAllocation(NeiliAllocation extraNeiliAllocation, DataContext context)
	{
		_extraNeiliAllocation = extraNeiliAllocation;
		SetModifiedAndInvalidateInfluencedCache(48, context);
	}

	public NeiliProportionOfFiveElements GetBaseNeiliProportionOfFiveElements()
	{
		return _baseNeiliProportionOfFiveElements;
	}

	public void SetBaseNeiliProportionOfFiveElements(NeiliProportionOfFiveElements baseNeiliProportionOfFiveElements, DataContext context)
	{
		_baseNeiliProportionOfFiveElements = baseNeiliProportionOfFiveElements;
		SetModifiedAndInvalidateInfluencedCache(49, context);
	}

	public int GetHobbyExpirationDate()
	{
		return _hobbyExpirationDate;
	}

	public void SetHobbyExpirationDate(int hobbyExpirationDate, DataContext context)
	{
		_hobbyExpirationDate = hobbyExpirationDate;
		SetModifiedAndInvalidateInfluencedCache(50, context);
	}

	public bool GetLovingItemRevealed()
	{
		return _lovingItemRevealed;
	}

	public void SetLovingItemRevealed(bool lovingItemRevealed, DataContext context)
	{
		_lovingItemRevealed = lovingItemRevealed;
		SetModifiedAndInvalidateInfluencedCache(51, context);
	}

	public bool GetHatingItemRevealed()
	{
		return _hatingItemRevealed;
	}

	public void SetHatingItemRevealed(bool hatingItemRevealed, DataContext context)
	{
		_hatingItemRevealed = hatingItemRevealed;
		SetModifiedAndInvalidateInfluencedCache(52, context);
	}

	public sbyte GetLegitimateBoysCount()
	{
		return _legitimateBoysCount;
	}

	public void SetLegitimateBoysCount(sbyte legitimateBoysCount, DataContext context)
	{
		_legitimateBoysCount = legitimateBoysCount;
		SetModifiedAndInvalidateInfluencedCache(53, context);
	}

	public Location GetBirthLocation()
	{
		return _birthLocation;
	}

	public Location GetLocation()
	{
		return _location;
	}

	public void SetLocation(Location location, DataContext context)
	{
		_location = location;
		SetModifiedAndInvalidateInfluencedCache(55, context);
	}

	public ItemKey[] GetEquipment()
	{
		return _equipment;
	}

	public void SetEquipment(ItemKey[] equipment, DataContext context)
	{
		_equipment = equipment;
		SetModifiedAndInvalidateInfluencedCache(56, context);
	}

	public Inventory GetInventory()
	{
		return _inventory;
	}

	public void SetInventory(Inventory inventory, DataContext context)
	{
		_inventory = inventory;
		SetModifiedAndInvalidateInfluencedCache(57, context);
	}

	public ref EatingItems GetEatingItems()
	{
		return ref _eatingItems;
	}

	public void SetEatingItems(ref EatingItems eatingItems, DataContext context)
	{
		_eatingItems = eatingItems;
		SetModifiedAndInvalidateInfluencedCache(58, context);
	}

	public List<short> GetLearnedCombatSkills()
	{
		return _learnedCombatSkills;
	}

	public void SetLearnedCombatSkills(List<short> learnedCombatSkills, DataContext context)
	{
		_learnedCombatSkills = learnedCombatSkills;
		SetModifiedAndInvalidateInfluencedCache(59, context);
	}

	public short[] GetEquippedCombatSkills()
	{
		return _equippedCombatSkills;
	}

	public void SetEquippedCombatSkills(short[] equippedCombatSkills, DataContext context)
	{
		_equippedCombatSkills = equippedCombatSkills;
		SetModifiedAndInvalidateInfluencedCache(60, context);
	}

	public short[] GetCombatSkillAttainmentPanels()
	{
		return _combatSkillAttainmentPanels;
	}

	public void SetCombatSkillAttainmentPanels(short[] combatSkillAttainmentPanels, DataContext context)
	{
		_combatSkillAttainmentPanels = combatSkillAttainmentPanels;
		SetModifiedAndInvalidateInfluencedCache(61, context);
	}

	public List<SkillQualificationBonus> GetSkillQualificationBonuses()
	{
		return _skillQualificationBonuses;
	}

	public void SetSkillQualificationBonuses(List<SkillQualificationBonus> skillQualificationBonuses, DataContext context)
	{
		_skillQualificationBonuses = skillQualificationBonuses;
		SetModifiedAndInvalidateInfluencedCache(62, context);
	}

	public ref PreexistenceCharIds GetPreexistenceCharIds()
	{
		return ref _preexistenceCharIds;
	}

	public byte GetXiangshuInfection()
	{
		return _xiangshuInfection;
	}

	public void SetXiangshuInfection(byte xiangshuInfection, DataContext context)
	{
		_xiangshuInfection = xiangshuInfection;
		SetModifiedAndInvalidateInfluencedCache(64, context);
	}

	public short GetCurrAge()
	{
		return _currAge;
	}

	public void SetCurrAge(short currAge, DataContext context)
	{
		_currAge = currAge;
		SetModifiedAndInvalidateInfluencedCache(65, context);
	}

	public int GetExp()
	{
		return _exp;
	}

	public void SetExp(int exp, DataContext context)
	{
		_exp = exp;
		SetModifiedAndInvalidateInfluencedCache(66, context);
	}

	public ulong GetExternalRelationState()
	{
		return _externalRelationState;
	}

	public void SetExternalRelationState(ulong externalRelationState, DataContext context)
	{
		_externalRelationState = externalRelationState;
		SetModifiedAndInvalidateInfluencedCache(67, context);
	}

	public int GetKidnapperId()
	{
		return _kidnapperId;
	}

	public void SetKidnapperId(int kidnapperId, DataContext context)
	{
		_kidnapperId = kidnapperId;
		SetModifiedAndInvalidateInfluencedCache(68, context);
	}

	public int GetLeaderId()
	{
		return _leaderId;
	}

	public void SetLeaderId(int leaderId, DataContext context)
	{
		_leaderId = leaderId;
		SetModifiedAndInvalidateInfluencedCache(69, context);
	}

	public int GetFactionId()
	{
		return _factionId;
	}

	public void SetFactionId(int factionId, DataContext context)
	{
		_factionId = factionId;
		SetModifiedAndInvalidateInfluencedCache(70, context);
	}

	public List<NpcTravelTarget> GetNpcTravelTargets()
	{
		return _npcTravelTargets;
	}

	public void SetNpcTravelTargets(List<NpcTravelTarget> npcTravelTargets, DataContext context)
	{
		_npcTravelTargets = npcTravelTargets;
		SetModifiedAndInvalidateInfluencedCache(71, context);
	}

	public int[] GetExtraNeiliAllocationProgress()
	{
		return _extraNeiliAllocationProgress;
	}

	public void SetExtraNeiliAllocationProgress(int[] extraNeiliAllocationProgress, DataContext context)
	{
		_extraNeiliAllocationProgress = extraNeiliAllocationProgress;
		SetModifiedAndInvalidateInfluencedCache(72, context);
	}

	public short GetUsedQualificationPotential()
	{
		return _usedQualificationPotential;
	}

	public void SetUsedQualificationPotential(short usedQualificationPotential, DataContext context)
	{
		_usedQualificationPotential = usedQualificationPotential;
		SetModifiedAndInvalidateInfluencedCache(73, context);
	}

	public WugKingDriveDataEx[] GetWugKingDriveDataEx()
	{
		return _wugKingDriveDataEx;
	}

	public void SetWugKingDriveDataEx(WugKingDriveDataEx[] wugKingDriveDataEx, DataContext context)
	{
		_wugKingDriveDataEx = wugKingDriveDataEx;
		SetModifiedAndInvalidateInfluencedCache(74, context);
	}

	public short GetPhysiologicalAge()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 75))
		{
			return _physiologicalAge;
		}
		short value = CalcPhysiologicalAge();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_physiologicalAge = value;
			dataStates.SetCached(DataStatesOffset, 75);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _physiologicalAge;
	}

	public sbyte GetFame()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 76))
		{
			return _fame;
		}
		sbyte value = CalcFame();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_fame = value;
			dataStates.SetCached(DataStatesOffset, 76);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _fame;
	}

	public short GetMorality()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 77))
		{
			return _morality;
		}
		short value = CalcMorality();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_morality = value;
			dataStates.SetCached(DataStatesOffset, 77);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _morality;
	}

	public short GetAttraction()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 78))
		{
			return _attraction;
		}
		short value = CalcAttraction();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_attraction = value;
			dataStates.SetCached(DataStatesOffset, 78);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _attraction;
	}

	public MainAttributes GetMaxMainAttributes()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 79))
		{
			return _maxMainAttributes;
		}
		MainAttributes value = CalcMaxMainAttributes();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxMainAttributes = value;
			dataStates.SetCached(DataStatesOffset, 79);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxMainAttributes;
	}

	public HitOrAvoidInts GetHitValues()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 80))
		{
			return _hitValues;
		}
		HitOrAvoidInts value = CalcHitValues();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_hitValues = value;
			dataStates.SetCached(DataStatesOffset, 80);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _hitValues;
	}

	public OuterAndInnerInts GetPenetrations()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 81))
		{
			return _penetrations;
		}
		OuterAndInnerInts value = CalcPenetrations();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_penetrations = value;
			dataStates.SetCached(DataStatesOffset, 81);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _penetrations;
	}

	public HitOrAvoidInts GetAvoidValues()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 82))
		{
			return _avoidValues;
		}
		HitOrAvoidInts value = CalcAvoidValues();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_avoidValues = value;
			dataStates.SetCached(DataStatesOffset, 82);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _avoidValues;
	}

	public OuterAndInnerInts GetPenetrationResists()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 83))
		{
			return _penetrationResists;
		}
		OuterAndInnerInts value = CalcPenetrationResists();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_penetrationResists = value;
			dataStates.SetCached(DataStatesOffset, 83);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _penetrationResists;
	}

	public OuterAndInnerShorts GetRecoveryOfStanceAndBreath()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 84))
		{
			return _recoveryOfStanceAndBreath;
		}
		OuterAndInnerShorts value = CalcRecoveryOfStanceAndBreath();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_recoveryOfStanceAndBreath = value;
			dataStates.SetCached(DataStatesOffset, 84);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _recoveryOfStanceAndBreath;
	}

	public short GetMoveSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 85))
		{
			return _moveSpeed;
		}
		short value = CalcMoveSpeed();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_moveSpeed = value;
			dataStates.SetCached(DataStatesOffset, 85);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _moveSpeed;
	}

	public short GetRecoveryOfFlaw()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 86))
		{
			return _recoveryOfFlaw;
		}
		short value = CalcRecoveryOfFlaw();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_recoveryOfFlaw = value;
			dataStates.SetCached(DataStatesOffset, 86);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _recoveryOfFlaw;
	}

	public short GetCastSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 87))
		{
			return _castSpeed;
		}
		short value = CalcCastSpeed();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_castSpeed = value;
			dataStates.SetCached(DataStatesOffset, 87);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _castSpeed;
	}

	public short GetRecoveryOfBlockedAcupoint()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 88))
		{
			return _recoveryOfBlockedAcupoint;
		}
		short value = CalcRecoveryOfBlockedAcupoint();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_recoveryOfBlockedAcupoint = value;
			dataStates.SetCached(DataStatesOffset, 88);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _recoveryOfBlockedAcupoint;
	}

	public short GetWeaponSwitchSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 89))
		{
			return _weaponSwitchSpeed;
		}
		short value = CalcWeaponSwitchSpeed();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_weaponSwitchSpeed = value;
			dataStates.SetCached(DataStatesOffset, 89);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _weaponSwitchSpeed;
	}

	public short GetAttackSpeed()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 90))
		{
			return _attackSpeed;
		}
		short value = CalcAttackSpeed();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_attackSpeed = value;
			dataStates.SetCached(DataStatesOffset, 90);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _attackSpeed;
	}

	public short GetInnerRatio()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 91))
		{
			return _innerRatio;
		}
		short value = CalcInnerRatio();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_innerRatio = value;
			dataStates.SetCached(DataStatesOffset, 91);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _innerRatio;
	}

	public short GetRecoveryOfQiDisorder()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 92))
		{
			return _recoveryOfQiDisorder;
		}
		short value = CalcRecoveryOfQiDisorder();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_recoveryOfQiDisorder = value;
			dataStates.SetCached(DataStatesOffset, 92);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _recoveryOfQiDisorder;
	}

	public ref PoisonInts GetPoisonResists()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 93))
		{
			return ref _poisonResists;
		}
		PoisonInts value = CalcPoisonResists();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_poisonResists = value;
			dataStates.SetCached(DataStatesOffset, 93);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _poisonResists;
	}

	public short GetMaxHealth()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 94))
		{
			return _maxHealth;
		}
		short value = CalcMaxHealth();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxHealth = value;
			dataStates.SetCached(DataStatesOffset, 94);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxHealth;
	}

	public short GetFertility()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 95))
		{
			return _fertility;
		}
		short value = CalcFertility();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_fertility = value;
			dataStates.SetCached(DataStatesOffset, 95);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _fertility;
	}

	public ref LifeSkillShorts GetLifeSkillQualifications()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 96))
		{
			return ref _lifeSkillQualifications;
		}
		LifeSkillShorts value = CalcLifeSkillQualifications();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_lifeSkillQualifications = value;
			dataStates.SetCached(DataStatesOffset, 96);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _lifeSkillQualifications;
	}

	public ref LifeSkillShorts GetLifeSkillAttainments()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 97))
		{
			return ref _lifeSkillAttainments;
		}
		LifeSkillShorts value = CalcLifeSkillAttainments();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_lifeSkillAttainments = value;
			dataStates.SetCached(DataStatesOffset, 97);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _lifeSkillAttainments;
	}

	public ref CombatSkillShorts GetCombatSkillQualifications()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 98))
		{
			return ref _combatSkillQualifications;
		}
		CombatSkillShorts value = CalcCombatSkillQualifications();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_combatSkillQualifications = value;
			dataStates.SetCached(DataStatesOffset, 98);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _combatSkillQualifications;
	}

	public ref CombatSkillShorts GetCombatSkillAttainments()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 99))
		{
			return ref _combatSkillAttainments;
		}
		CombatSkillShorts value = CalcCombatSkillAttainments();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_combatSkillAttainments = value;
			dataStates.SetCached(DataStatesOffset, 99);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return ref _combatSkillAttainments;
	}

	public Personalities GetPersonalities()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 100))
		{
			return _personalities;
		}
		Personalities value = CalcPersonalities();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_personalities = value;
			dataStates.SetCached(DataStatesOffset, 100);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _personalities;
	}

	public sbyte GetHobbyChangingPeriod()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 101))
		{
			return _hobbyChangingPeriod;
		}
		sbyte value = CalcHobbyChangingPeriod();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_hobbyChangingPeriod = value;
			dataStates.SetCached(DataStatesOffset, 101);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _hobbyChangingPeriod;
	}

	public OuterAndInnerShorts GetFavorabilityChangingFactor()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 102))
		{
			return _favorabilityChangingFactor;
		}
		OuterAndInnerShorts value = CalcFavorabilityChangingFactor();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_favorabilityChangingFactor = value;
			dataStates.SetCached(DataStatesOffset, 102);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _favorabilityChangingFactor;
	}

	public int GetMaxInventoryLoad()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 103))
		{
			return _maxInventoryLoad;
		}
		int value = CalcMaxInventoryLoad();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxInventoryLoad = value;
			dataStates.SetCached(DataStatesOffset, 103);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxInventoryLoad;
	}

	public int GetCurrInventoryLoad()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 104))
		{
			return _currInventoryLoad;
		}
		int value = CalcCurrInventoryLoad();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_currInventoryLoad = value;
			dataStates.SetCached(DataStatesOffset, 104);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _currInventoryLoad;
	}

	public int GetMaxEquipmentLoad()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 105))
		{
			return _maxEquipmentLoad;
		}
		int value = CalcMaxEquipmentLoad();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxEquipmentLoad = value;
			dataStates.SetCached(DataStatesOffset, 105);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxEquipmentLoad;
	}

	public int GetCurrEquipmentLoad()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 106))
		{
			return _currEquipmentLoad;
		}
		int value = CalcCurrEquipmentLoad();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_currEquipmentLoad = value;
			dataStates.SetCached(DataStatesOffset, 106);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _currEquipmentLoad;
	}

	public int GetInventoryTotalValue()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 107))
		{
			return _inventoryTotalValue;
		}
		int value = CalcInventoryTotalValue();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_inventoryTotalValue = value;
			dataStates.SetCached(DataStatesOffset, 107);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _inventoryTotalValue;
	}

	public int GetMaxNeili()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 108))
		{
			return _maxNeili;
		}
		int value = CalcMaxNeili();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxNeili = value;
			dataStates.SetCached(DataStatesOffset, 108);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxNeili;
	}

	public NeiliAllocation GetNeiliAllocation()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 109))
		{
			return _neiliAllocation;
		}
		NeiliAllocation value = CalcNeiliAllocation();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_neiliAllocation = value;
			dataStates.SetCached(DataStatesOffset, 109);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _neiliAllocation;
	}

	public NeiliProportionOfFiveElements GetNeiliProportionOfFiveElements()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 110))
		{
			return _neiliProportionOfFiveElements;
		}
		NeiliProportionOfFiveElements value = CalcNeiliProportionOfFiveElements();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_neiliProportionOfFiveElements = value;
			dataStates.SetCached(DataStatesOffset, 110);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _neiliProportionOfFiveElements;
	}

	public sbyte GetNeiliType()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 111))
		{
			return _neiliType;
		}
		sbyte value = CalcNeiliType();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_neiliType = value;
			dataStates.SetCached(DataStatesOffset, 111);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _neiliType;
	}

	public int GetCombatPower()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 112))
		{
			return _combatPower;
		}
		int value = CalcCombatPower();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_combatPower = value;
			dataStates.SetCached(DataStatesOffset, 112);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _combatPower;
	}

	public sbyte GetAttackTendencyOfInnerAndOuter()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 113))
		{
			return _attackTendencyOfInnerAndOuter;
		}
		sbyte value = CalcAttackTendencyOfInnerAndOuter();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_attackTendencyOfInnerAndOuter = value;
			dataStates.SetCached(DataStatesOffset, 113);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _attackTendencyOfInnerAndOuter;
	}

	public NeiliAllocation GetAllocatedNeiliEffects()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 114))
		{
			return _allocatedNeiliEffects;
		}
		NeiliAllocation value = CalcAllocatedNeiliEffects();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_allocatedNeiliEffects = value;
			dataStates.SetCached(DataStatesOffset, 114);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _allocatedNeiliEffects;
	}

	public sbyte GetMaxConsummateLevel()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 115))
		{
			return _maxConsummateLevel;
		}
		sbyte value = CalcMaxConsummateLevel();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_maxConsummateLevel = value;
			dataStates.SetCached(DataStatesOffset, 115);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _maxConsummateLevel;
	}

	public CombatSkillEquipment GetCombatSkillEquipment()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 116))
		{
			return _combatSkillEquipment;
		}
		CombatSkillEquipment value = new CombatSkillEquipment();
		CalcCombatSkillEquipment(value);
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_combatSkillEquipment.Assign(value);
			dataStates.SetCached(DataStatesOffset, 116);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _combatSkillEquipment;
	}

	public uint GetDarkAshProtector()
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		Thread.MemoryBarrier();
		if (dataStates.IsCached(DataStatesOffset, 117))
		{
			return _darkAshProtector;
		}
		uint value = CalcDarkAshProtector();
		bool lockTaken = false;
		try
		{
			_spinLock.Enter(ref lockTaken);
			_darkAshProtector = value;
			dataStates.SetCached(DataStatesOffset, 117);
		}
		finally
		{
			if (lockTaken)
			{
				_spinLock.Exit(useMemoryBarrier: false);
			}
		}
		Thread.MemoryBarrier();
		return _darkAshProtector;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSurname()
	{
		return Config.Character.Instance[_templateId].Surname;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetGivenName()
	{
		return Config.Character.Instance[_templateId].GivenName;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetAnonymousTitle()
	{
		return Config.Character.Instance[_templateId].AnonymousTitle;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetRandomFeaturesAtCreating()
	{
		return Config.Character.Instance[_templateId].RandomFeaturesAtCreating;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowUseFreeWeapon()
	{
		return Config.Character.Instance[_templateId].AllowUseFreeWeapon;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowEscape()
	{
		return Config.Character.Instance[_templateId].AllowEscape;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowHeal()
	{
		return Config.Character.Instance[_templateId].AllowHeal;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanDefeat()
	{
		return Config.Character.Instance[_templateId].CanDefeat;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetRandomEnemyId()
	{
		return Config.Character.Instance[_templateId].RandomEnemyId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetLeadingEnemyNestId()
	{
		return Config.Character.Instance[_templateId].LeadingEnemyNestId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFixedAvatarName()
	{
		return Config.Character.Instance[_templateId].FixedAvatarName;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetPresetBodyType()
	{
		return Config.Character.Instance[_templateId].PresetBodyType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetHideAge()
	{
		return Config.Character.Instance[_templateId].HideAge;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetRace()
	{
		return Config.Character.Instance[_templateId].Race;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetPresetFame()
	{
		return Config.Character.Instance[_templateId].PresetFame;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseAttraction()
	{
		return Config.Character.Instance[_templateId].BaseAttraction;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanBeKidnapped()
	{
		return Config.Character.Instance[_templateId].CanBeKidnapped;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetFixWeaponPower()
	{
		return Config.Character.Instance[_templateId].FixWeaponPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetFixArmorPower()
	{
		return Config.Character.Instance[_templateId].FixArmorPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetFixCombatSkillPower()
	{
		return Config.Character.Instance[_templateId].FixCombatSkillPower;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public HitOrAvoidInts GetBaseHitValues()
	{
		return Config.Character.Instance[_templateId].BaseHitValues;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public OuterAndInnerInts GetBasePenetrations()
	{
		return Config.Character.Instance[_templateId].BasePenetrations;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public HitOrAvoidInts GetBaseAvoidValues()
	{
		return Config.Character.Instance[_templateId].BaseAvoidValues;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public OuterAndInnerInts GetBasePenetrationResists()
	{
		return Config.Character.Instance[_templateId].BasePenetrationResists;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public OuterAndInnerShorts GetBaseRecoveryOfStanceAndBreath()
	{
		return Config.Character.Instance[_templateId].BaseRecoveryOfStanceAndBreath;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseMoveSpeed()
	{
		return Config.Character.Instance[_templateId].BaseMoveSpeed;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseRecoveryOfFlaw()
	{
		return Config.Character.Instance[_templateId].BaseRecoveryOfFlaw;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseCastSpeed()
	{
		return Config.Character.Instance[_templateId].BaseCastSpeed;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseRecoveryOfBlockedAcupoint()
	{
		return Config.Character.Instance[_templateId].BaseRecoveryOfBlockedAcupoint;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseWeaponSwitchSpeed()
	{
		return Config.Character.Instance[_templateId].BaseWeaponSwitchSpeed;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseAttackSpeed()
	{
		return Config.Character.Instance[_templateId].BaseAttackSpeed;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseInnerRatio()
	{
		return Config.Character.Instance[_templateId].BaseInnerRatio;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetBaseRecoveryOfQiDisorder()
	{
		return Config.Character.Instance[_templateId].BaseRecoveryOfQiDisorder;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ref readonly PoisonInts GetBasePoisonResists()
	{
		return ref Config.Character.Instance[_templateId].BasePoisonResists;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetInnerInjuryImmunity()
	{
		return Config.Character.Instance[_templateId].InnerInjuryImmunity;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetOuterInjuryImmunity()
	{
		return Config.Character.Instance[_templateId].OuterInjuryImmunity;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetMindImmunity()
	{
		return Config.Character.Instance[_templateId].MindImmunity;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetFlawImmunity()
	{
		return Config.Character.Instance[_templateId].FlawImmunity;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAcupointImmunity()
	{
		return Config.Character.Instance[_templateId].AcupointImmunity;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 6)]
	public bool[] GetPoisonImmunities()
	{
		return Config.Character.Instance[_templateId].PoisonImmunities;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 17)]
	public PresetEquipmentItem[] GetPresetEquipment()
	{
		return Config.Character.Instance[_templateId].PresetEquipment;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PresetInventoryItem> GetPresetInventory()
	{
		return Config.Character.Instance[_templateId].PresetInventory;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PresetCombatSkill> GetPresetCombatSkills()
	{
		return Config.Character.Instance[_templateId].PresetCombatSkills;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public NeiliProportionOfFiveElements GetPresetNeiliProportionOfFiveElements()
	{
		return Config.Character.Instance[_templateId].PresetNeiliProportionOfFiveElements;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetMinionGroupId()
	{
		return Config.Character.Instance[_templateId].MinionGroupId;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public DamageStepCollection GetDamageSteps()
	{
		return Config.Character.Instance[_templateId].DamageSteps;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 4)]
	public sbyte[] GetIdeaAllocationProportion()
	{
		return Config.Character.Instance[_templateId].IdeaAllocationProportion;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetExtraEquipmentLoad()
	{
		return Config.Character.Instance[_templateId].ExtraEquipmentLoad;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetInitCurrAge()
	{
		return Config.Character.Instance[_templateId].InitCurrAge;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<sbyte> GetPresetTeammateCommands()
	{
		return Config.Character.Instance[_templateId].PresetTeammateCommands;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetIsFavorabilityDisplay()
	{
		return Config.Character.Instance[_templateId].IsFavorabilityDisplay;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetFixedCharacterShowNameOnMap()
	{
		return Config.Character.Instance[_templateId].FixedCharacterShowNameOnMap;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public sbyte GetSpecialCombatSkeleton()
	{
		return Config.Character.Instance[_templateId].SpecialCombatSkeleton;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetDieImmunity()
	{
		return Config.Character.Instance[_templateId].DieImmunity;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetFatalImmunity()
	{
		return Config.Character.Instance[_templateId].FatalImmunity;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 16)]
	public sbyte[] GetLearnedLifeSkillGrades()
	{
		return Config.Character.Instance[_templateId].LearnedLifeSkillGrades;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetCombatAi()
	{
		return Config.Character.Instance[_templateId].CombatAi;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanMove()
	{
		return Config.Character.Instance[_templateId].CanMove;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanOpenCharacterMenu()
	{
		return Config.Character.Instance[_templateId].CanOpenCharacterMenu;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetRandomAnimalAttack()
	{
		return Config.Character.Instance[_templateId].RandomAnimalAttack;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ref readonly ResourceInts GetDropResources()
	{
		return ref Config.Character.Instance[_templateId].DropResources;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSpecialGradeName()
	{
		return Config.Character.Instance[_templateId].SpecialGradeName;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<PresetItemTemplateId> GetPresetEatingItems()
	{
		return Config.Character.Instance[_templateId].PresetEatingItems;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanSpeak()
	{
		return Config.Character.Instance[_templateId].CanSpeak;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 4)]
	public sbyte[] GetRandomEnemyFavorability()
	{
		return Config.Character.Instance[_templateId].RandomEnemyFavorability;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public short GetGroupId()
	{
		return Config.Character.Instance[_templateId].GroupId;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 5)]
	public sbyte[] GetExtraCombatSkillGrids()
	{
		return Config.Character.Instance[_templateId].ExtraCombatSkillGrids;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public ECharacterSpecialTemmateType GetSpecialTemmateType()
	{
		return Config.Character.Instance[_templateId].SpecialTemmateType;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public List<sbyte> GetRandomIdealSects()
	{
		return Config.Character.Instance[_templateId].RandomIdealSects;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowDropWugKing()
	{
		return Config.Character.Instance[_templateId].AllowDropWugKing;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetAllowFavorabilitySkipCd()
	{
		return Config.Character.Instance[_templateId].AllowFavorabilitySkipCd;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSpecialMuteBubbleEnemy()
	{
		return Config.Character.Instance[_templateId].SpecialMuteBubbleEnemy;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetSpecialMuteBubbleSelf()
	{
		return Config.Character.Instance[_templateId].SpecialMuteBubbleSelf;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetDropRatePercentAsTeammate()
	{
		return Config.Character.Instance[_templateId].DropRatePercentAsTeammate;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public int GetDropRatePercentAsMainChar()
	{
		return Config.Character.Instance[_templateId].DropRatePercentAsMainChar;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFixedAvatarSpineSkin()
	{
		return Config.Character.Instance[_templateId].FixedAvatarSpineSkin;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public string GetFixedAvatarSpineName()
	{
		return Config.Character.Instance[_templateId].FixedAvatarSpineName;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanBeTaiwu()
	{
		return Config.Character.Instance[_templateId].CanBeTaiwu;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanBePossessionBody()
	{
		return Config.Character.Instance[_templateId].CanBePossessionBody;
	}

	[CollectionObjectField(true, false, false, false, false, ArrayElementsCount = 17)]
	public bool[] GetEquipmentLock()
	{
		return Config.Character.Instance[_templateId].EquipmentLock;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetCanBePossessionSoul()
	{
		return Config.Character.Instance[_templateId].CanBePossessionSoul;
	}

	[CollectionObjectField(true, false, false, false, false)]
	public bool GetXiangshuInfectedDemonBonus()
	{
		return Config.Character.Instance[_templateId].XiangshuInfectedDemonBonus;
	}

	public Character()
	{
		_featureIds = new List<short>();
		_learnedLifeSkills = new List<LifeSkillItem>();
		_avatar = new AvatarData();
		_potentialFeatureIds = new List<short>();
		_fameActionRecords = new List<FameActionRecord>();
		_equipment = new ItemKey[17];
		_inventory = new Inventory();
		_learnedCombatSkills = new List<short>();
		_equippedCombatSkills = new short[48];
		_combatSkillAttainmentPanels = new short[126];
		_skillQualificationBonuses = new List<SkillQualificationBonus>();
		_npcTravelTargets = new List<NpcTravelTarget>();
		_extraNeiliAllocationProgress = new int[4];
		_wugKingDriveDataEx = new WugKingDriveDataEx[8];
		_combatSkillEquipment = new CombatSkillEquipment();
	}

	public Character(short templateId)
	{
		CharacterItem template = Config.Character.Instance[templateId];
		_templateId = template.TemplateId;
		_creatingType = template.CreatingType;
		_gender = template.Gender;
		_actualAge = template.ActualAge;
		_birthMonth = template.BirthMonth;
		_happiness = template.Happiness;
		_baseMorality = template.BaseMorality;
		_organizationInfo = template.OrganizationInfo;
		_idealSect = template.IdealSect;
		_lifeSkillTypeInterest = template.LifeSkillTypeInterest;
		_combatSkillTypeInterest = template.CombatSkillTypeInterest;
		_mainAttributeInterest = template.MainAttributeInterest;
		_transgender = template.Transgender;
		_bisexual = template.Bisexual;
		_xiangshuType = template.XiangshuType;
		_monkType = template.MonkType;
		_featureIds = new List<short>(template.FeatureIds);
		_baseMainAttributes = template.BaseMainAttributes;
		_health = template.Health;
		_baseMaxHealth = template.BaseMaxHealth;
		_disorderOfQi = template.DisorderOfQi;
		_haveLeftArm = template.HaveLeftArm;
		_haveRightArm = template.HaveRightArm;
		_haveLeftLeg = template.HaveLeftLeg;
		_haveRightLeg = template.HaveRightLeg;
		_injuries = template.Injuries;
		_extraNeili = template.ExtraNeili;
		_consummateLevel = template.ConsummateLevel;
		_learnedLifeSkills = new List<LifeSkillItem>(template.LearnedLifeSkills);
		_baseLifeSkillQualifications = template.BaseLifeSkillQualifications;
		_lifeSkillQualificationGrowthType = template.LifeSkillQualificationGrowthType;
		_baseCombatSkillQualifications = template.BaseCombatSkillQualifications;
		_combatSkillQualificationGrowthType = template.CombatSkillQualificationGrowthType;
		_resources = template.Resources;
		_lovingItemSubType = template.LovingItemSubType;
		_hatingItemSubType = template.HatingItemSubType;
		_extraNeiliAllocation = template.ExtraNeiliAllocation;
		_avatar = new AvatarData();
		_potentialFeatureIds = new List<short>();
		_fameActionRecords = new List<FameActionRecord>();
		_equipment = new ItemKey[17];
		_inventory = new Inventory();
		_learnedCombatSkills = new List<short>();
		_equippedCombatSkills = new short[48];
		_combatSkillAttainmentPanels = new short[126];
		_skillQualificationBonuses = new List<SkillQualificationBonus>();
		_npcTravelTargets = new List<NpcTravelTarget>();
		_extraNeiliAllocationProgress = new int[4];
		_wugKingDriveDataEx = new WugKingDriveDataEx[8];
		_combatSkillEquipment = new CombatSkillEquipment();
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
		int totalSize = 1029;
		int elementsCount = _featureIds.Count;
		int contentSize = 2 * elementsCount;
		int dataSize = 2 + contentSize;
		totalSize += dataSize;
		int elementsCount2 = _learnedLifeSkills.Count;
		int contentSize2 = 4 * elementsCount2;
		int dataSize2 = 2 + contentSize2;
		totalSize += dataSize2;
		int dataSize3 = _avatar.GetSerializedSize();
		totalSize += dataSize3;
		int elementsCount3 = _potentialFeatureIds.Count;
		int contentSize3 = 2 * elementsCount3;
		int dataSize4 = 2 + contentSize3;
		totalSize += dataSize4;
		int elementsCount4 = _fameActionRecords.Count;
		int contentSize4 = 8 * elementsCount4;
		int dataSize5 = 2 + contentSize4;
		totalSize += dataSize5;
		int dataSize6 = _inventory.GetSerializedSize();
		totalSize += dataSize6;
		int elementsCount5 = _learnedCombatSkills.Count;
		int contentSize5 = 2 * elementsCount5;
		int dataSize7 = 2 + contentSize5;
		totalSize += dataSize7;
		int elementsCount6 = _skillQualificationBonuses.Count;
		int contentSize6 = 4 * elementsCount6;
		int dataSize8 = 2 + contentSize6;
		totalSize += dataSize8;
		int elementsCount7 = _npcTravelTargets.Count;
		int contentSize7 = 16 * elementsCount7;
		int dataSize9 = 2 + contentSize7;
		totalSize += dataSize9;
		int dataSize10 = 0;
		for (int i = 0; i < 8; i++)
		{
			WugKingDriveDataEx element = _wugKingDriveDataEx[i];
			dataSize10 = ((element == null) ? (dataSize10 + 2) : (dataSize10 + (2 + element.GetSerializedSize())));
		}
		return totalSize + dataSize10;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		*(short*)pCurrData = _templateId;
		pCurrData += 2;
		*pCurrData = _creatingType;
		pCurrData++;
		*pCurrData = (byte)_gender;
		pCurrData++;
		*(short*)pCurrData = _actualAge;
		pCurrData += 2;
		*pCurrData = (byte)_birthMonth;
		pCurrData++;
		*pCurrData = (byte)_happiness;
		pCurrData++;
		*(short*)pCurrData = _baseMorality;
		pCurrData += 2;
		pCurrData += _organizationInfo.Serialize(pCurrData);
		*pCurrData = (byte)_idealSect;
		pCurrData++;
		*pCurrData = (byte)_lifeSkillTypeInterest;
		pCurrData++;
		*pCurrData = (byte)_combatSkillTypeInterest;
		pCurrData++;
		*pCurrData = (byte)_mainAttributeInterest;
		pCurrData++;
		*pCurrData = (_transgender ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_bisexual ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)_xiangshuType;
		pCurrData++;
		*pCurrData = _monkType;
		pCurrData++;
		pCurrData += _baseMainAttributes.Serialize(pCurrData);
		*(short*)pCurrData = _health;
		pCurrData += 2;
		*(short*)pCurrData = _baseMaxHealth;
		pCurrData += 2;
		*(short*)pCurrData = _disorderOfQi;
		pCurrData += 2;
		*pCurrData = (_haveLeftArm ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_haveRightArm ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_haveLeftLeg ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_haveRightLeg ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += _injuries.Serialize(pCurrData);
		*(int*)pCurrData = _extraNeili;
		pCurrData += 4;
		*pCurrData = (byte)_consummateLevel;
		pCurrData++;
		pCurrData += _baseLifeSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)_lifeSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += _baseCombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)_combatSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += _resources.Serialize(pCurrData);
		*(short*)pCurrData = _lovingItemSubType;
		pCurrData += 2;
		*(short*)pCurrData = _hatingItemSubType;
		pCurrData += 2;
		pCurrData += _fullName.Serialize(pCurrData);
		pCurrData += _monasticTitle.Serialize(pCurrData);
		pCurrData += _genome.Serialize(pCurrData);
		pCurrData += _currMainAttributes.Serialize(pCurrData);
		pCurrData += _poisoned.Serialize(pCurrData);
		*(int*)pCurrData = _currNeili;
		pCurrData += 4;
		*(short*)pCurrData = _loopingNeigong;
		pCurrData += 2;
		pCurrData += _baseNeiliAllocation.Serialize(pCurrData);
		pCurrData += _extraNeiliAllocation.Serialize(pCurrData);
		pCurrData += _baseNeiliProportionOfFiveElements.Serialize(pCurrData);
		*(int*)pCurrData = _hobbyExpirationDate;
		pCurrData += 4;
		*pCurrData = (_lovingItemRevealed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_hatingItemRevealed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)_legitimateBoysCount;
		pCurrData++;
		pCurrData += _birthLocation.Serialize(pCurrData);
		pCurrData += _location.Serialize(pCurrData);
		if (_equipment.Length != 17)
		{
			throw new Exception("Elements count of field _equipment is not equal to declaration");
		}
		for (int i = 0; i < 17; i++)
		{
			pCurrData += _equipment[i].Serialize(pCurrData);
		}
		pCurrData += _eatingItems.Serialize(pCurrData);
		if (_equippedCombatSkills.Length != 48)
		{
			throw new Exception("Elements count of field _equippedCombatSkills is not equal to declaration");
		}
		for (int j = 0; j < 48; j++)
		{
			((short*)pCurrData)[j] = _equippedCombatSkills[j];
		}
		pCurrData += 96;
		if (_combatSkillAttainmentPanels.Length != 126)
		{
			throw new Exception("Elements count of field _combatSkillAttainmentPanels is not equal to declaration");
		}
		for (int k = 0; k < 126; k++)
		{
			((short*)pCurrData)[k] = _combatSkillAttainmentPanels[k];
		}
		pCurrData += 252;
		pCurrData += _preexistenceCharIds.Serialize(pCurrData);
		*pCurrData = _xiangshuInfection;
		pCurrData++;
		*(short*)pCurrData = _currAge;
		pCurrData += 2;
		*(int*)pCurrData = _exp;
		pCurrData += 4;
		*(ulong*)pCurrData = _externalRelationState;
		pCurrData += 8;
		*(int*)pCurrData = _kidnapperId;
		pCurrData += 4;
		*(int*)pCurrData = _leaderId;
		pCurrData += 4;
		*(int*)pCurrData = _factionId;
		pCurrData += 4;
		if (_extraNeiliAllocationProgress.Length != 4)
		{
			throw new Exception("Elements count of field _extraNeiliAllocationProgress is not equal to declaration");
		}
		for (int l = 0; l < 4; l++)
		{
			((int*)pCurrData)[l] = _extraNeiliAllocationProgress[l];
		}
		pCurrData += 16;
		*(short*)pCurrData = _usedQualificationPotential;
		pCurrData += 2;
		int elementsCount = _featureIds.Count;
		int contentSize = 2 * elementsCount;
		if (contentSize > 4194300)
		{
			throw new Exception($"Size of field {"_featureIds"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount;
		pCurrData += 2;
		for (int m = 0; m < elementsCount; m++)
		{
			((short*)pCurrData)[m] = _featureIds[m];
		}
		pCurrData += contentSize;
		int elementsCount2 = _learnedLifeSkills.Count;
		int contentSize2 = 4 * elementsCount2;
		if (contentSize2 > 4194300)
		{
			throw new Exception($"Size of field {"_learnedLifeSkills"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize2 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount2;
		pCurrData += 2;
		for (int n = 0; n < elementsCount2; n++)
		{
			pCurrData += _learnedLifeSkills[n].Serialize(pCurrData);
		}
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _avatar.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_avatar"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		int elementsCount3 = _potentialFeatureIds.Count;
		int contentSize3 = 2 * elementsCount3;
		if (contentSize3 > 4194300)
		{
			throw new Exception($"Size of field {"_potentialFeatureIds"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize3 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount3;
		pCurrData += 2;
		for (int num = 0; num < elementsCount3; num++)
		{
			((short*)pCurrData)[num] = _potentialFeatureIds[num];
		}
		pCurrData += contentSize3;
		int elementsCount4 = _fameActionRecords.Count;
		int contentSize4 = 8 * elementsCount4;
		if (contentSize4 > 4194300)
		{
			throw new Exception($"Size of field {"_fameActionRecords"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize4 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount4;
		pCurrData += 2;
		for (int num2 = 0; num2 < elementsCount4; num2++)
		{
			pCurrData += _fameActionRecords[num2].Serialize(pCurrData);
		}
		byte* pBegin2 = pCurrData;
		pCurrData += 4;
		pCurrData += _inventory.Serialize(pCurrData);
		int fieldSize2 = (int)(pCurrData - pBegin2 - 4);
		if (fieldSize2 > 4194304)
		{
			throw new Exception($"Size of field {"_inventory"} must be less than {4096}KB");
		}
		*(int*)pBegin2 = fieldSize2;
		int elementsCount5 = _learnedCombatSkills.Count;
		int contentSize5 = 2 * elementsCount5;
		if (contentSize5 > 4194300)
		{
			throw new Exception($"Size of field {"_learnedCombatSkills"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize5 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount5;
		pCurrData += 2;
		for (int num3 = 0; num3 < elementsCount5; num3++)
		{
			((short*)pCurrData)[num3] = _learnedCombatSkills[num3];
		}
		pCurrData += contentSize5;
		int elementsCount6 = _skillQualificationBonuses.Count;
		int contentSize6 = 4 * elementsCount6;
		if (contentSize6 > 4194300)
		{
			throw new Exception($"Size of field {"_skillQualificationBonuses"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize6 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount6;
		pCurrData += 2;
		for (int num4 = 0; num4 < elementsCount6; num4++)
		{
			pCurrData += _skillQualificationBonuses[num4].Serialize(pCurrData);
		}
		int elementsCount7 = _npcTravelTargets.Count;
		int contentSize7 = 16 * elementsCount7;
		if (contentSize7 > 4194300)
		{
			throw new Exception($"Size of field {"_npcTravelTargets"} must be less than {4096}KB");
		}
		*(int*)pCurrData = contentSize7 + 2;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)elementsCount7;
		pCurrData += 2;
		for (int num5 = 0; num5 < elementsCount7; num5++)
		{
			pCurrData += _npcTravelTargets[num5].Serialize(pCurrData);
		}
		if (_wugKingDriveDataEx.Length != 8)
		{
			throw new Exception("Elements count of field _wugKingDriveDataEx is not equal to declaration");
		}
		byte* pBegin3 = pCurrData;
		pCurrData += 4;
		for (int num6 = 0; num6 < 8; num6++)
		{
			WugKingDriveDataEx element = _wugKingDriveDataEx[num6];
			if (element != null)
			{
				byte* pSubContentSize = pCurrData;
				pCurrData += 2;
				int subContentSize = element.Serialize(pCurrData);
				pCurrData += subContentSize;
				*(ushort*)pSubContentSize = (ushort)subContentSize;
			}
			else
			{
				*(short*)pCurrData = 0;
				pCurrData += 2;
			}
		}
		int fieldSize3 = (int)(pCurrData - pBegin3 - 4);
		if (fieldSize3 > 4194304)
		{
			throw new Exception($"Size of field {"_wugKingDriveDataEx"} must be less than {4096}KB");
		}
		*(int*)pBegin3 = fieldSize3;
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
				_templateId = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 2:
				_creatingType = *pCurrData;
				pCurrData++;
				break;
			case 3:
				_gender = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 4:
				_actualAge = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 5:
				_birthMonth = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 6:
				_happiness = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 7:
				_baseMorality = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 8:
				pCurrData += _organizationInfo.Deserialize(pCurrData);
				break;
			case 9:
				_idealSect = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 10:
				_lifeSkillTypeInterest = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 11:
				_combatSkillTypeInterest = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 12:
				_mainAttributeInterest = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 13:
				_transgender = *pCurrData != 0;
				pCurrData++;
				break;
			case 14:
				_bisexual = *pCurrData != 0;
				pCurrData++;
				break;
			case 15:
				_xiangshuType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 16:
				_monkType = *pCurrData;
				pCurrData++;
				break;
			case 18:
				pCurrData += _baseMainAttributes.Deserialize(pCurrData);
				break;
			case 19:
				_health = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 20:
				_baseMaxHealth = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 21:
				_disorderOfQi = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 22:
				_haveLeftArm = *pCurrData != 0;
				pCurrData++;
				break;
			case 23:
				_haveRightArm = *pCurrData != 0;
				pCurrData++;
				break;
			case 24:
				_haveLeftLeg = *pCurrData != 0;
				pCurrData++;
				break;
			case 25:
				_haveRightLeg = *pCurrData != 0;
				pCurrData++;
				break;
			case 26:
				pCurrData += _injuries.Deserialize(pCurrData);
				break;
			case 27:
				_extraNeili = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 28:
				_consummateLevel = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 30:
				pCurrData += _baseLifeSkillQualifications.Deserialize(pCurrData);
				break;
			case 31:
				_lifeSkillQualificationGrowthType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 32:
				pCurrData += _baseCombatSkillQualifications.Deserialize(pCurrData);
				break;
			case 33:
				_combatSkillQualificationGrowthType = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 34:
				pCurrData += _resources.Deserialize(pCurrData);
				break;
			case 35:
				_lovingItemSubType = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 36:
				_hatingItemSubType = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 37:
				pCurrData += _fullName.Deserialize(pCurrData);
				break;
			case 38:
				pCurrData += _monasticTitle.Deserialize(pCurrData);
				break;
			case 42:
				pCurrData += _genome.Deserialize(pCurrData);
				break;
			case 43:
				pCurrData += _currMainAttributes.Deserialize(pCurrData);
				break;
			case 44:
				pCurrData += _poisoned.Deserialize(pCurrData);
				break;
			case 45:
				_currNeili = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 46:
				_loopingNeigong = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 47:
				pCurrData += _baseNeiliAllocation.Deserialize(pCurrData);
				break;
			case 48:
				pCurrData += _extraNeiliAllocation.Deserialize(pCurrData);
				break;
			case 49:
				pCurrData += _baseNeiliProportionOfFiveElements.Deserialize(pCurrData);
				break;
			case 50:
				_hobbyExpirationDate = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 51:
				_lovingItemRevealed = *pCurrData != 0;
				pCurrData++;
				break;
			case 52:
				_hatingItemRevealed = *pCurrData != 0;
				pCurrData++;
				break;
			case 53:
				_legitimateBoysCount = (sbyte)(*pCurrData);
				pCurrData++;
				break;
			case 54:
				pCurrData += _birthLocation.Deserialize(pCurrData);
				break;
			case 55:
				pCurrData += _location.Deserialize(pCurrData);
				break;
			case 56:
			{
				if (_equipment.Length != 17)
				{
					throw new Exception("Elements count of field _equipment is not equal to declaration");
				}
				for (int num6 = 0; num6 < 17; num6++)
				{
					ItemKey element6 = default(ItemKey);
					pCurrData += element6.Deserialize(pCurrData);
					_equipment[num6] = element6;
				}
				break;
			}
			case 58:
				pCurrData += _eatingItems.Deserialize(pCurrData);
				break;
			case 60:
			{
				if (_equippedCombatSkills.Length != 48)
				{
					throw new Exception("Elements count of field _equippedCombatSkills is not equal to declaration");
				}
				for (int num5 = 0; num5 < 48; num5++)
				{
					_equippedCombatSkills[num5] = ((short*)pCurrData)[num5];
				}
				pCurrData += 96;
				break;
			}
			case 61:
			{
				if (_combatSkillAttainmentPanels.Length != 126)
				{
					throw new Exception("Elements count of field _combatSkillAttainmentPanels is not equal to declaration");
				}
				for (int num4 = 0; num4 < 126; num4++)
				{
					_combatSkillAttainmentPanels[num4] = ((short*)pCurrData)[num4];
				}
				pCurrData += 252;
				break;
			}
			case 63:
				pCurrData += _preexistenceCharIds.Deserialize(pCurrData);
				break;
			case 64:
				_xiangshuInfection = *pCurrData;
				pCurrData++;
				break;
			case 65:
				_currAge = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 66:
				_exp = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 67:
				_externalRelationState = *(ulong*)pCurrData;
				pCurrData += 8;
				break;
			case 68:
				_kidnapperId = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 69:
				_leaderId = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 70:
				_factionId = *(int*)pCurrData;
				pCurrData += 4;
				break;
			case 72:
			{
				if (_extraNeiliAllocationProgress.Length != 4)
				{
					throw new Exception("Elements count of field _extraNeiliAllocationProgress is not equal to declaration");
				}
				for (int num3 = 0; num3 < 4; num3++)
				{
					_extraNeiliAllocationProgress[num3] = ((int*)pCurrData)[num3];
				}
				pCurrData += 16;
				break;
			}
			case 73:
				_usedQualificationPotential = *(short*)pCurrData;
				pCurrData += 2;
				break;
			case 17:
			{
				pCurrData += 4;
				ushort elementsCount7 = *(ushort*)pCurrData;
				pCurrData += 2;
				_featureIds.Clear();
				for (int num2 = 0; num2 < elementsCount7; num2++)
				{
					_featureIds.Add(((short*)pCurrData)[num2]);
				}
				pCurrData += 2 * elementsCount7;
				break;
			}
			case 29:
			{
				pCurrData += 4;
				ushort elementsCount6 = *(ushort*)pCurrData;
				pCurrData += 2;
				_learnedLifeSkills.Clear();
				for (int num = 0; num < elementsCount6; num++)
				{
					LifeSkillItem element5 = default(LifeSkillItem);
					pCurrData += element5.Deserialize(pCurrData);
					_learnedLifeSkills.Add(element5);
				}
				break;
			}
			case 39:
				pCurrData += 4;
				pCurrData += _avatar.Deserialize(pCurrData);
				break;
			case 40:
			{
				pCurrData += 4;
				ushort elementsCount5 = *(ushort*)pCurrData;
				pCurrData += 2;
				_potentialFeatureIds.Clear();
				for (int n = 0; n < elementsCount5; n++)
				{
					_potentialFeatureIds.Add(((short*)pCurrData)[n]);
				}
				pCurrData += 2 * elementsCount5;
				break;
			}
			case 41:
			{
				pCurrData += 4;
				ushort elementsCount4 = *(ushort*)pCurrData;
				pCurrData += 2;
				_fameActionRecords.Clear();
				for (int m = 0; m < elementsCount4; m++)
				{
					FameActionRecord element4 = default(FameActionRecord);
					pCurrData += element4.Deserialize(pCurrData);
					_fameActionRecords.Add(element4);
				}
				break;
			}
			case 57:
				pCurrData += 4;
				pCurrData += _inventory.Deserialize(pCurrData);
				break;
			case 59:
			{
				pCurrData += 4;
				ushort elementsCount3 = *(ushort*)pCurrData;
				pCurrData += 2;
				_learnedCombatSkills.Clear();
				for (int l = 0; l < elementsCount3; l++)
				{
					_learnedCombatSkills.Add(((short*)pCurrData)[l]);
				}
				pCurrData += 2 * elementsCount3;
				break;
			}
			case 62:
			{
				pCurrData += 4;
				ushort elementsCount2 = *(ushort*)pCurrData;
				pCurrData += 2;
				_skillQualificationBonuses.Clear();
				for (int k = 0; k < elementsCount2; k++)
				{
					SkillQualificationBonus element3 = default(SkillQualificationBonus);
					pCurrData += element3.Deserialize(pCurrData);
					_skillQualificationBonuses.Add(element3);
				}
				break;
			}
			case 71:
			{
				pCurrData += 4;
				ushort elementsCount = *(ushort*)pCurrData;
				pCurrData += 2;
				_npcTravelTargets.Clear();
				for (int j = 0; j < elementsCount; j++)
				{
					NpcTravelTarget element2 = default(NpcTravelTarget);
					pCurrData += element2.Deserialize(pCurrData);
					_npcTravelTargets.Add(element2);
				}
				break;
			}
			case 74:
			{
				if (_wugKingDriveDataEx.Length != 8)
				{
					throw new Exception("Elements count of field _wugKingDriveDataEx is not equal to declaration");
				}
				pCurrData += 4;
				for (int i = 0; i < 8; i++)
				{
					ushort subContentSize = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subContentSize > 0)
					{
						WugKingDriveDataEx element = _wugKingDriveDataEx[i];
						if (element != null)
						{
							pCurrData += element.Deserialize(pCurrData);
							continue;
						}
						element = new WugKingDriveDataEx();
						pCurrData += element.Deserialize(pCurrData);
						_wugKingDriveDataEx[i] = element;
					}
					else
					{
						_wugKingDriveDataEx[i] = null;
					}
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

	public bool TryGetWugKingDriveData(sbyte wugType, out WugKingDriveDataEx driveData)
	{
		if (_wugKingDriveDataEx == null)
		{
			driveData = null;
			return false;
		}
		driveData = _wugKingDriveDataEx[wugType];
		if (driveData == null)
		{
			return false;
		}
		return true;
	}

	public void SetWugKingDriveData(DataContext context, sbyte wugType, sbyte driveType, int startDate)
	{
		if (_wugKingDriveDataEx == null)
		{
			_wugKingDriveDataEx = new WugKingDriveDataEx[8];
		}
		_wugKingDriveDataEx[wugType] = new WugKingDriveDataEx(driveType, startDate);
		SetWugKingDriveDataEx(_wugKingDriveDataEx, context);
	}

	public void ClearWugKingDriveData(sbyte wugType)
	{
		if (_wugKingDriveDataEx == null)
		{
			_wugKingDriveDataEx = new WugKingDriveDataEx[8];
		}
		_wugKingDriveDataEx[wugType] = new WugKingDriveDataEx(0, -1);
	}

	public sbyte GetWugKingSlotIndex(sbyte wugType)
	{
		for (sbyte i = 0; i < 9; i++)
		{
			ItemKey itemKey = _eatingItems.Get(i);
			if (EatingItems.IsWugKing(itemKey))
			{
				MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
				if (medicineCfg.WugType == wugType)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public bool IsWugKingDriveActive(sbyte wugType, int currentDate, int durationMonths)
	{
		if (!TryGetWugKingDriveData(wugType, out var driveData))
		{
			return false;
		}
		if (driveData.DriveType == 0)
		{
			return false;
		}
		if (GetWugKingSlotIndex(wugType) < 0)
		{
			return false;
		}
		int elapsedMonths = currentDate - driveData.StartDate;
		return elapsedMonths < durationMonths;
	}

	public bool CanDriveWugKing(sbyte wugType, int currentDate, int cooldownMonths = 6)
	{
		if (GetWugKingSlotIndex(wugType) < 0)
		{
			return false;
		}
		if (!TryGetWugKingDriveData(wugType, out var driveData))
		{
			return true;
		}
		int elapsedMonths = currentDate - driveData.StartDate;
		return elapsedMonths >= cooldownMonths;
	}

	public int GetIceSilkwormWugKingFlawModify()
	{
		if (!IsWugKingDriveActive(5, DomainManager.World.GetCurrDate(), 3))
		{
			return 0;
		}
		if (!TryGetWugKingDriveData(5, out var driveData))
		{
			return 0;
		}
		return (driveData.DriveType == 1) ? (-2) : 2;
	}

	public int GetIceSilkwormWugKingAcupointModify()
	{
		if (!IsWugKingDriveActive(5, DomainManager.World.GetCurrDate(), 3))
		{
			return 0;
		}
		if (!TryGetWugKingDriveData(5, out var driveData))
		{
			return 0;
		}
		return (driveData.DriveType == 1) ? (-2) : 2;
	}

	public unsafe ProtagonistFeatureRelatedStatus OfflineCreateProtagonist(short templateId, short orgMemberId, ProtagonistCreationInfo info, DataContext context)
	{
		IRandomSource random = context.Random;
		CharacterItem template = Config.Character.Instance[templateId];
		if ((string.IsNullOrEmpty(info.Surname) || string.IsNullOrEmpty(info.GivenName)) && info.InscribedChar == null)
		{
			throw new Exception("Surname and given name can neither be null nor empty");
		}
		int customSurnameId = ((info.Surname != null) ? DomainManager.World.RegisterCustomText(context, info.Surname) : (-1));
		int customGivenNameId = ((info.GivenName != null) ? DomainManager.World.RegisterCustomText(context, info.GivenName) : (-1));
		bool nameType = customSurnameId >= 0 && customGivenNameId >= 0;
		_fullName = (nameType ? new FullName(customSurnameId, customGivenNameId, -1, -1, -1, -1) : new FullName((customGivenNameId >= 0) ? customGivenNameId : customSurnameId, -1, -1));
		_monasticTitle = new MonasticTitle(-1, -1);
		_actualAge = info.Age;
		_currAge = _actualAge;
		_birthMonth = info.InscribedChar?.BirthMonth ?? info.BirthMonth;
		_health = short.MaxValue;
		_baseMaxHealth = info.InscribedChar?.BaseMaxHealth ?? GenerateProtagonistMaxHealth(context.Random);
		_happiness = 0;
		_baseMorality = info.InscribedChar?.Morality ?? info.Morality;
		_location = Location.Invalid;
		sbyte orgTemplateId = _organizationInfo.OrgTemplateId;
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
		_organizationInfo = new OrganizationInfo(orgTemplateId, _organizationInfo.Grade, principal: true, settlementId);
		_avatar = info.InscribedChar?.Avatar ?? info.Avatar;
		if (_gender != _avatar.GetGender())
		{
			_transgender = true;
		}
		if (random.CheckPercentProb(20))
		{
			_bisexual = true;
		}
		_loopingNeigong = -1;
		if (info.CustomPreset == null || !info.CustomPreset.NeiliProportion.CheckValid())
		{
			OfflineInitializeBaseNeiliProportionOfFiveElements();
		}
		else
		{
			_baseNeiliProportionOfFiveElements = info.CustomPreset.NeiliProportion;
		}
		_resources.Initialize();
		_resources.Items[0] = 50;
		_resources.Items[6] = 990;
		OfflineCreateEquipmentAndInventoryItems(context, template, AgeGroup.GetAgeGroup(_actualAge));
		OfflineReplaceProtagonistClothing(context, info.ClothingTemplateId);
		(TemplateKey, int)[] protagonistInitialItems = ProtagonistInitialItems;
		for (int i = 0; i < protagonistInitialItems.Length; i++)
		{
			(TemplateKey, int) initialItem = protagonistInitialItems[i];
			OfflineCreateInventoryOnCharacterCreation(context, initialItem.Item1.ItemType, initialItem.Item1.TemplateId, initialItem.Item2);
		}
		_eatingItems.Initialize();
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = OfflineCreateCombatSkills(random, template.PresetCombatSkills);
		if (info.CustomPreset != null)
		{
			_baseMainAttributes = info.CustomPreset.MainAttributes;
			_baseLifeSkillQualifications = info.CustomPreset.LifeSkillQualifications;
			_baseCombatSkillQualifications = info.CustomPreset.CombatSkillQualifications;
			_lifeSkillQualificationGrowthType = info.CustomPreset.LifeSkillQualificationGrowthType;
			_combatSkillQualificationGrowthType = info.CustomPreset.CombatSkillQualificationGrowthType;
		}
		else if (info.InscribedChar != null)
		{
			_baseMainAttributes = info.InscribedChar.BaseMainAttributes;
			_baseLifeSkillQualifications = info.InscribedChar.BaseLifeSkillQualifications;
			_baseCombatSkillQualifications = info.InscribedChar.BaseCombatSkillQualifications;
			_lifeSkillQualificationGrowthType = info.InscribedChar.LifeSkillQualificationGrowthType;
			_combatSkillQualificationGrowthType = info.InscribedChar.CombatSkillQualificationGrowthType;
		}
		else
		{
			OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
			_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, orgMemberCfg.Grade, orgMemberCfg.MainAttributesAdjust);
			_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, orgMemberCfg.Grade, orgMemberCfg.LifeSkillsAdjust);
			_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, orgMemberCfg.Grade, orgMemberCfg.CombatSkillsAdjust);
			_lifeSkillQualificationGrowthType = (sbyte)random.Next(3);
			_combatSkillQualificationGrowthType = (sbyte)random.Next(3);
		}
		if (info.InscribedChar != null)
		{
			_skillQualificationBonuses.Add(info.InscribedChar.InnateSkillQualificationBonuses[0]);
			_skillQualificationBonuses.Add(info.InscribedChar.InnateSkillQualificationBonuses[1]);
		}
		else if (info.CustomPreset == null)
		{
			_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
			_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		}
		(_lovingItemSubType, _hatingItemSubType) = GenerateRandomHobby(random);
		OfflineGenerateRandomIdealSect(random);
		ProtagonistFeatureRelatedStatus protagonistFeatureRelatedStatus = OfflineApplyProtagonistFeaturesAndGenome(context, info, combatSkills);
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = -1;
		return protagonistFeatureRelatedStatus;
	}

	public void OfflineCreateCharacterFromInscription(DataContext context, CreateIntelligentCharacterModification mod, InscribedCharacter inscribedChar, OrganizationInfo targetOrgInfo)
	{
		OrganizationMemberItem orgMemberConfig = OrganizationDomain.GetOrgMemberConfig(targetOrgInfo);
		OrganizationItem orgConfig = Config.Organization.Instance[targetOrgInfo.OrgTemplateId];
		CharacterItem template = Template;
		int customSurnameId = ((inscribedChar.Surname != null) ? DomainManager.World.RegisterCustomText(context, inscribedChar.Surname) : (-1));
		int customGivenNameId = ((inscribedChar.GivenName != null) ? DomainManager.World.RegisterCustomText(context, inscribedChar.GivenName) : (-1));
		_fullName = ((customSurnameId >= 0 && customGivenNameId >= 0) ? new FullName(customSurnameId, customGivenNameId, -1, -1, -1, -1) : new FullName((customGivenNameId >= 0) ? customGivenNameId : customSurnameId, -1, -1));
		_monasticTitle = new MonasticTitle(-1, -1);
		_organizationInfo = targetOrgInfo;
		_avatar = new AvatarData(inscribedChar.Avatar);
		_currAge = inscribedChar.CurrAge;
		_actualAge = inscribedChar.ActualAge;
		_birthMonth = inscribedChar.BirthMonth;
		_gender = inscribedChar.Gender;
		_baseMorality = inscribedChar.Morality;
		_baseMaxHealth = inscribedChar.BaseMaxHealth;
		_health = short.MaxValue;
		_baseMainAttributes = inscribedChar.BaseMainAttributes;
		_baseCombatSkillQualifications = inscribedChar.BaseCombatSkillQualifications;
		_baseLifeSkillQualifications = inscribedChar.BaseLifeSkillQualifications;
		_combatSkillQualificationGrowthType = inscribedChar.CombatSkillQualificationGrowthType;
		_lifeSkillQualificationGrowthType = inscribedChar.LifeSkillQualificationGrowthType;
		_skillQualificationBonuses.AddRange(inscribedChar.InnateSkillQualificationBonuses);
		_featureIds.Add(CharacterDomain.GetBirthdayFeatureId(_birthMonth));
		_featureIds.Add(209);
		_featureIds.Add(196);
		if (inscribedChar.FeatureIds != null)
		{
			_featureIds.AddRange(inscribedChar.FeatureIds);
		}
		_featureIds.Sort(CharacterFeatureHelper.FeatureComparer);
		IRandomSource random = context.Random;
		OfflineCreateGenome(random, null, null, null);
		(_lovingItemSubType, _hatingItemSubType) = GenerateRandomHobby(random);
		OfflineGenerateRandomIdealSect(random);
		_loopingNeigong = -1;
		OfflineInitializeBaseNeiliProportionOfFiveElements();
		int ageInfluence = CalcAgeInfluence(random, this, orgMemberConfig);
		_extraNeili = orgMemberConfig.Neili * ageInfluence / 100;
		_consummateLevel = (sbyte)(orgMemberConfig.ConsummateLevel * ageInfluence / 100);
		sbyte ageGroup = AgeGroup.GetAgeGroup(_actualAge);
		OfflineCreateEquipmentAndInventoryItems(mod, Template, ageGroup);
		OfflineAddPresetOrgMemberEquipmentAndInventoryItems(context, mod, orgMemberConfig, ageGroup);
		OfflineCreateResources(random, orgMemberConfig.TemplateId, 20);
		_eatingItems.Initialize();
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		OfflineCreateCombatSkills(random, template.PresetCombatSkills, mod);
		OfflineAddPresetOrgMemberCombatSkills(context, mod, orgConfig, orgMemberConfig, ageInfluence);
		OfflineCreateInitialLifeSkills(random, orgMemberConfig);
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = -1;
	}

	public List<GameData.Domains.CombatSkill.CombatSkill> OfflineCreatePresetCharacter(short templateId, DataContext context)
	{
		IRandomSource random = context.Random;
		CharacterItem template = Config.Character.Instance[templateId];
		if (template.CreatingType != 0 && template.CreatingType != 3)
		{
			throw new Exception($"Not allow to create preset character by templateId: {templateId}");
		}
		_monasticTitle = new MonasticTitle(-1, -1);
		_actualAge = template.ActualAge;
		_currAge = ((template.InitCurrAge >= 0) ? template.InitCurrAge : _actualAge);
		_birthMonth = ((template.BirthMonth >= 0) ? template.BirthMonth : ((sbyte)random.Next(12)));
		if (_gender == -1)
		{
			_gender = Gender.GetRandom(random);
		}
		sbyte orgTemplateId = _organizationInfo.OrgTemplateId;
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
		_organizationInfo = new OrganizationInfo(orgTemplateId, _organizationInfo.Grade, principal: true, settlementId);
		_avatar = AvatarManager.Instance.GetRandomAvatar(random, _gender, _transgender, template.PresetBodyType, template.BaseAttraction);
		if (!string.IsNullOrEmpty(template.AvatarDataPath))
		{
			AvatarData customAvatar = AvatarDataLoader.Load(template.AvatarDataPath);
			if (customAvatar != null)
			{
				_avatar = customAvatar;
			}
		}
		CharacterCreation.CreateFeatures(context.Random, this);
		OfflineCreateGenome(context.Random, null, null, null);
		_loopingNeigong = -1;
		NeiliProportionOfFiveElements presetProportion = template.PresetNeiliProportionOfFiveElements;
		if (presetProportion.SumCheck() > 0)
		{
			_baseNeiliProportionOfFiveElements = presetProportion;
		}
		else
		{
			OfflineInitializeBaseNeiliProportionOfFiveElements();
		}
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		OfflineCreateEquipmentAndInventoryItems(context, template, AgeGroup.GetAgeGroup(_actualAge));
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = OfflineCreateCombatSkills(random, template.PresetCombatSkills);
		OfflineCreatePresetLifeSkillsByGradeConfig();
		_eatingItems.Initialize();
		if (_idealSect <= 0)
		{
			OfflineGenerateRandomIdealSect(random);
		}
		if (_lifeSkillTypeInterest < 0)
		{
			_lifeSkillTypeInterest = (sbyte)random.Next(16);
		}
		if (_combatSkillTypeInterest < 0)
		{
			_combatSkillTypeInterest = (sbyte)random.Next(14);
		}
		if (_mainAttributeInterest < 0)
		{
			_mainAttributeInterest = (sbyte)random.Next(6);
		}
		_birthLocation = Location.Invalid;
		_location = Location.Invalid;
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = -1;
		return combatSkills;
	}

	public void OfflineSetSrcCharId(int charId)
	{
		Tester.Assert(DomainManager.Character.IsTemporaryIntelligentCharacter(_id));
		_srcCharId = charId;
	}

	public void OfflineSetCopySource(int charId)
	{
		_eatingItems.Initialize();
		_injuries.Initialize();
		_poisoned.Initialize();
		_inventory.Items.Clear();
		_equipment = new ItemKey[17];
		for (int i = 0; i < 17; i++)
		{
			_equipment[i] = ItemKey.Invalid;
		}
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = charId;
	}

	public void OfflineCreateIntelligentCharacter(DataContext context, CreateIntelligentCharacterModification mod, ref IntelligentCharacterCreationInfo info)
	{
		IRandomSource random = context.Random;
		CharacterItem template = Config.Character.Instance[info.CharTemplateId];
		if (template.CreatingType != 1)
		{
			throw new Exception($"Not allow to create intelligent character by templateId: {info.CharTemplateId}");
		}
		sbyte orgTemplateId = info.OrgInfo.OrgTemplateId;
		bool isWangliuStronghold = info.Location.AreaId == 138 && orgTemplateId == 38;
		if (isWangliuStronghold)
		{
			sbyte stateTemplateId = DomainManager.World.GetTaiwuVillageStateTemplateId();
			orgTemplateId = MapState.Instance[stateTemplateId].SectID;
		}
		short orgMemberId = OrganizationDomain.GetMemberId(orgTemplateId, info.OrgInfo.Grade);
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		_organizationInfo = info.OrgInfo;
		_monasticTitle = new MonasticTitle(-1, -1);
		OfflineCreateRandomName(context, ref info, mod, (info.Race >= 0) ? info.Race : template.Race);
		_actualAge = ((info.Age >= 0) ? info.Age : GenerateRandomAge(random));
		_currAge = _actualAge;
		_birthMonth = ((info.BirthMonth >= 0) ? info.BirthMonth : ((template.BirthMonth >= 0) ? template.BirthMonth : ((sbyte)random.Next(12))));
		_health = short.MaxValue;
		_baseMaxHealth = GenerateRandomMaxHealth(random);
		int ageInfluence = CalcAgeInfluence(random, this, orgMemberConfig);
		_happiness = (sbyte)random.Next(-59, 60);
		_birthLocation = info.Location;
		_location = info.Location;
		if (info.DestinyType >= 0)
		{
			DestinyTypeItem destinyTypeCfg = DestinyType.Instance[info.DestinyType];
			_baseMorality = (short)random.Next(destinyTypeCfg.MoralityRange[0], destinyTypeCfg.MoralityRange[1]);
			info.GrowingSectGrade = (sbyte)random.Next(destinyTypeCfg.OrganizationGradeRange[0], destinyTypeCfg.OrganizationGradeRange[1]);
		}
		else if (orgConfig.MainMorality != short.MinValue && random.CheckPercentProb(60))
		{
			int morality = orgConfig.MainMorality + random.Next(301) - 150;
			_baseMorality = (short)Math.Clamp(morality, -500, 500);
		}
		else
		{
			_baseMorality = (short)(random.Next(1001) - 500);
		}
		if (info.Gender != -1)
		{
			_gender = info.Gender;
			_transgender = info.Transgender;
		}
		else if (random.CheckPercentProb(3))
		{
			_transgender = true;
		}
		if (random.CheckPercentProb(10))
		{
			_bisexual = true;
		}
		if (ProfessionSkillHandle.BuddhistMonkSkill_IsDirectedSamsaraCharacter(mod.ReincarnationCharId))
		{
			if (DomainManager.Character.TryGetDeadCharacter(mod.ReincarnationCharId, out var reincarnatedDeadChar))
			{
				_gender = reincarnatedDeadChar.Gender;
				_transgender = _gender != reincarnatedDeadChar.Avatar.Gender;
			}
			else
			{
				AdaptableLog.Warning($"[Debug] Creation Intelligent Character {mod.ReincarnationCharId}. Cannot find dead character.");
			}
		}
		OfflineCreateAttractionAndAvatar(context, template.PresetBodyType, ref info, -1);
		CharacterCreation.CreateFeatures(random, this, ref info);
		if (info.SpecifyGenome)
		{
			_genome = info.Genome;
		}
		else
		{
			OfflineCreateGenome(random, info.Mother, info.PregnantState, info.ActualFather);
		}
		if (_lifeSkillTypeInterest < 0)
		{
			_lifeSkillTypeInterest = (sbyte)random.Next(16);
		}
		if (_combatSkillTypeInterest < 0)
		{
			_combatSkillTypeInterest = (sbyte)random.Next(14);
		}
		if (_mainAttributeInterest < 0)
		{
			_mainAttributeInterest = (sbyte)random.Next(6);
		}
		if (_idealSect <= 0)
		{
			OfflineGenerateRandomIdealSect(random);
		}
		(short, short) tuple = GenerateRandomHobby(random);
		_lovingItemSubType = tuple.Item1;
		_hatingItemSubType = tuple.Item2;
		sbyte growingGrade = CharacterCreation.CalcGrowingSectGradeAndAssignWeights(context.Random, ref info, _idealSect);
		if (info.GrowingSectGrade < 0)
		{
			info.GrowingSectGrade = growingGrade;
		}
		mod.GrowingSectGrade = info.GrowingSectGrade;
		_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, ref info);
		_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, ref info);
		_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, ref info);
		_lifeSkillQualificationGrowthType = ((info.LifeSkillQualificationGrowthType < 0) ? ((sbyte)random.Next(3)) : info.LifeSkillQualificationGrowthType);
		_combatSkillQualificationGrowthType = ((info.CombatSkillQualificationGrowthType < 0) ? ((sbyte)random.Next(3)) : info.CombatSkillQualificationGrowthType);
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_loopingNeigong = -1;
		OfflineInitializeBaseNeiliProportionOfFiveElements();
		_extraNeili = orgMemberConfig.Neili * ageInfluence / 100;
		_consummateLevel = (sbyte)(orgMemberConfig.ConsummateLevel * ageInfluence / 100);
		sbyte ageGroup = AgeGroup.GetAgeGroup(_actualAge);
		OfflineCreateEquipmentAndInventoryItems(mod, template, ageGroup);
		if (isWangliuStronghold)
		{
			OfflineAddPresetOrgMemberEquipmentAndInventoryItems(context, mod, OrganizationDomain.GetOrgMemberConfig(orgTemplateId, (sbyte)(_organizationInfo.Grade / 2)), ageGroup);
		}
		else
		{
			OfflineAddPresetOrgMemberEquipmentAndInventoryItems(context, mod, orgMemberConfig, ageGroup);
		}
		OfflineCreateResources(random, orgMemberId, 20);
		_eatingItems.Initialize();
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		OfflineCreateCombatSkills(random, template.PresetCombatSkills, mod);
		if (info.InitializeSectSkills)
		{
			OfflineAddPresetOrgMemberCombatSkills(context, mod, orgConfig, orgMemberConfig, ageInfluence);
		}
		if (ageGroup != 0 && info.InitializeSectSkills)
		{
			OfflineCreateInitialLifeSkills(random, orgMemberConfig);
		}
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = -1;
	}

	public void OfflineCreateTemporaryIntelligentCharacter(DataContext context, CreateIntelligentCharacterModification mod, ref IntelligentCharacterCreationInfo info, ref TemporaryIntelligentCharacterCreationInfo tmpInfo)
	{
		IRandomSource random = context.Random;
		CharacterItem template = Config.Character.Instance[info.CharTemplateId];
		if (template.CreatingType != 1)
		{
			throw new Exception($"Not allow to create intelligent character by templateId: {info.CharTemplateId}");
		}
		sbyte orgTemplateId = info.OrgInfo.OrgTemplateId;
		short orgMemberId = OrganizationDomain.GetMemberId(orgTemplateId, info.OrgInfo.Grade);
		OrganizationItem orgConfig = Config.Organization.Instance[orgTemplateId];
		OrganizationMemberItem orgMemberConfig = OrganizationMember.Instance[orgMemberId];
		_organizationInfo = info.OrgInfo;
		_monasticTitle = new MonasticTitle(-1, -1);
		OfflineCreateRandomName(context, ref info, mod, template.Race);
		_actualAge = ((info.Age >= 0) ? info.Age : GenerateRandomAge(random));
		_currAge = _actualAge;
		_birthMonth = ((template.BirthMonth >= 0) ? template.BirthMonth : ((sbyte)random.Next(12)));
		_happiness = tmpInfo.Happiness ?? ((sbyte)random.Next(-59, 60));
		_health = short.MaxValue;
		_baseMaxHealth = GenerateRandomMaxHealth(random);
		_location = info.Location;
		if (tmpInfo.Morality.HasValue)
		{
			_baseMorality = tmpInfo.Morality.Value;
		}
		else if (orgConfig.MainMorality != short.MinValue && random.CheckPercentProb(60))
		{
			int morality = orgConfig.MainMorality + random.Next(301) - 150;
			_baseMorality = (short)Math.Clamp(morality, -500, 500);
		}
		else
		{
			_baseMorality = (short)(random.Next(1001) - 500);
		}
		if (random.CheckPercentProb(3))
		{
			_transgender = true;
		}
		if (random.CheckPercentProb(20))
		{
			_bisexual = true;
		}
		OfflineCreateAttractionAndAvatar(context, template.PresetBodyType, ref info, tmpInfo.HaveHair);
		CharacterCreation.CreateFeatures(random, this, ref info);
		if (info.SpecifyGenome)
		{
			_genome = info.Genome;
		}
		else
		{
			OfflineCreateGenome(random, info.Mother, info.PregnantState, info.ActualFather);
		}
		int ageInfluence = Math.Clamp(CalcAgeInfluence(random, this, orgMemberConfig), 75, 100);
		if (_lifeSkillTypeInterest < 0)
		{
			_lifeSkillTypeInterest = (sbyte)random.Next(16);
		}
		if (_combatSkillTypeInterest < 0)
		{
			_combatSkillTypeInterest = (sbyte)random.Next(14);
		}
		if (_mainAttributeInterest < 0)
		{
			_mainAttributeInterest = (sbyte)random.Next(6);
		}
		if (_idealSect <= 0)
		{
			OfflineGenerateRandomIdealSect(random);
		}
		(_lovingItemSubType, _hatingItemSubType) = GenerateRandomHobby(random);
		if (tmpInfo.LovingItemSubType.HasValue)
		{
			_lovingItemSubType = tmpInfo.LovingItemSubType.Value;
		}
		if (tmpInfo.HatingItemSubType.HasValue)
		{
			_hatingItemSubType = tmpInfo.HatingItemSubType.Value;
		}
		if (_lovingItemSubType == _hatingItemSubType)
		{
			if (tmpInfo.LovingItemSubType.HasValue)
			{
				_hatingItemSubType = -1;
			}
			else if (tmpInfo.HatingItemSubType.HasValue)
			{
				_lovingItemSubType = -1;
			}
		}
		sbyte growingGrade = CharacterCreation.CalcGrowingSectGradeAndAssignWeights(context.Random, ref info, _idealSect);
		if (info.GrowingSectGrade < 0)
		{
			info.GrowingSectGrade = growingGrade;
		}
		mod.GrowingSectGrade = info.GrowingSectGrade;
		_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, ref info);
		_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, ref info);
		_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, ref info);
		_lifeSkillQualificationGrowthType = ((info.LifeSkillQualificationGrowthType < 0) ? ((sbyte)random.Next(3)) : info.LifeSkillQualificationGrowthType);
		_combatSkillQualificationGrowthType = ((info.CombatSkillQualificationGrowthType < 0) ? ((sbyte)random.Next(3)) : info.CombatSkillQualificationGrowthType);
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		if (tmpInfo.CombatSkillQualifications != null)
		{
			for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
			{
				if (tmpInfo.CombatSkillQualifications[combatSkillType] > 0)
				{
					_baseCombatSkillQualifications[combatSkillType] = tmpInfo.CombatSkillQualifications[combatSkillType];
				}
			}
		}
		_loopingNeigong = -1;
		OfflineInitializeBaseNeiliProportionOfFiveElements();
		_extraNeili = orgMemberConfig.Neili * ageInfluence / 100;
		_consummateLevel = tmpInfo.ConsummateLevel ?? ((sbyte)(orgMemberConfig.ConsummateLevel * ageInfluence / 100));
		sbyte ageGroup = AgeGroup.GetAgeGroup(_actualAge);
		OfflineCreateEquipmentAndInventoryItems(mod, template, ageGroup);
		OfflineAddPresetOrgMemberEquipmentAndInventoryItems(context, mod, orgMemberConfig, ageGroup);
		OfflineCreateResources(random, orgMemberId, 20);
		_eatingItems.Initialize();
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		OfflineCreateCombatSkills(random, template.PresetCombatSkills, mod);
		if (info.InitializeSectSkills)
		{
			OfflineAddPresetOrgMemberCombatSkills(context, mod, orgConfig, orgMemberConfig, ageInfluence);
		}
		if (tmpInfo.GoodAtCombatSkillType.HasValue)
		{
			_baseCombatSkillQualifications[tmpInfo.GoodAtCombatSkillType.Value] = (short)Math.Max(_baseCombatSkillQualifications.GetMaxCombatSkillValue() + 1, _baseCombatSkillQualifications[tmpInfo.GoodAtCombatSkillType.Value]);
			OfflineAddGoodAtCombatSkills(context, mod, tmpInfo.GoodAtCombatSkillType.Value);
		}
		if (ageGroup != 0 && info.InitializeSectSkills)
		{
			OfflineCreateInitialLifeSkills(random, orgMemberConfig);
		}
		if (tmpInfo.GoodAtLifeSkillType.HasValue)
		{
			_baseLifeSkillQualifications[tmpInfo.GoodAtLifeSkillType.Value] = (short)Math.Max(_baseLifeSkillQualifications.GetMaxLifeSkillValue() + 1, _baseLifeSkillQualifications[tmpInfo.GoodAtLifeSkillType.Value]);
			OfflineAddGoodAtLifeSkills(context, mod, tmpInfo.GoodAtLifeSkillType.Value);
		}
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		_srcCharId = -1;
	}

	public List<GameData.Domains.CombatSkill.CombatSkill> OfflineCreateRandomEnemy(DataContext context, short templateId, short randomEnemyTemplateId = -1)
	{
		IRandomSource random = context.Random;
		CharacterItem template = Config.Character.Instance[templateId];
		if (template.CreatingType != 2)
		{
			throw new Exception($"Not allow to create random enemy by templateId: {templateId}");
		}
		if (_gender == -1)
		{
			_gender = Gender.GetRandom(random);
		}
		_monasticTitle = new MonasticTitle(-1, -1);
		_actualAge = GenerateRandomAge(random, template.ActualAge);
		_currAge = ((template.InitCurrAge >= 0) ? template.InitCurrAge : _actualAge);
		_birthMonth = ((template.BirthMonth >= 0) ? template.BirthMonth : ((sbyte)random.Next(12)));
		_health = short.MaxValue;
		_baseMaxHealth = GenerateRandomMaxHealth(random);
		sbyte orgTemplateId = _organizationInfo.OrgTemplateId;
		short settlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
		_organizationInfo = new OrganizationInfo(orgTemplateId, _organizationInfo.Grade, principal: true, settlementId);
		sbyte bodyType = template.PresetBodyType;
		if (bodyType < 0)
		{
			bodyType = BodyType.GetRandom(random);
		}
		short baseAttraction = template.BaseAttraction;
		if (baseAttraction < 0)
		{
			baseAttraction = GenerateRandomAttraction(random, -1);
		}
		_avatar = AvatarManager.Instance.GetRandomAvatar(random, _gender, _transgender, bodyType, baseAttraction);
		CharacterCreation.CreateFeatures(random, this);
		OfflineCreateGenome(context.Random, null, null, null);
		RandomEnemyItem randomEnemy = RandomEnemy.Instance[(randomEnemyTemplateId >= 0) ? randomEnemyTemplateId : template.RandomEnemyId];
		List<(OrganizationItem, OrganizationMemberItem)> relatedSectAndMembers = GetRelatedSectAndMembers(random, randomEnemy, _organizationInfo.Grade);
		short[] mainAttributesAdjust = CharacterCreation.GetRandomEnemyMainAttributesAdjust(random, relatedSectAndMembers);
		short[] lifeSkillsAdjust = CharacterCreation.GetRandomEnemyLifeSkillsAdjust(random, relatedSectAndMembers);
		short[] combatSkillsAdjust = CharacterCreation.GetRandomEnemyCombatSkillsAdjust(random, relatedSectAndMembers);
		_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, _organizationInfo.Grade, mainAttributesAdjust);
		_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, _organizationInfo.Grade, lifeSkillsAdjust);
		_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, _organizationInfo.Grade, combatSkillsAdjust);
		_lifeSkillQualificationGrowthType = (sbyte)random.Next(3);
		_combatSkillQualificationGrowthType = (sbyte)random.Next(3);
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_skillQualificationBonuses.Add(GenerateRandomInnateSkillQualificationBonus(context));
		_loopingNeigong = -1;
		OfflineInitializeBaseNeiliProportionOfFiveElements();
		sbyte ageGroup = AgeGroup.GetAgeGroup(_actualAge);
		OfflineCreateEquipmentAndInventoryItems(context, template, ageGroup);
		OfflineAddRandomEnemyPresetOrgMemberEquipmentAndInventoryItems(context, randomEnemy, relatedSectAndMembers);
		_eatingItems.Initialize();
		CombatSkillHelper.InitializeEquippedSkills(_equippedCombatSkills);
		CombatSkillAttainmentPanelsHelper.Initialize(_combatSkillAttainmentPanels);
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = OfflineCreateRandomEnemyCombatSkills(random, randomEnemy, template.PresetCombatSkills);
		OfflineAddRandomEnemyOrgMemberCombatSkills(context, randomEnemy, relatedSectAndMembers, combatSkills);
		if (relatedSectAndMembers.Count > 0)
		{
			int sum = 0;
			for (int i = 0; i < relatedSectAndMembers.Count; i++)
			{
				sum += relatedSectAndMembers[i].Item2.LifeSkillGradeLimit;
			}
			sbyte grade = (sbyte)(sum / relatedSectAndMembers.Count);
			OfflineCreateInitialLifeSkills(random, lifeSkillsAdjust, grade);
		}
		_location = Location.Invalid;
		if (_idealSect <= 0)
		{
			OfflineGenerateRandomIdealSect(random);
		}
		if (_lifeSkillTypeInterest < 0)
		{
			_lifeSkillTypeInterest = (sbyte)random.Next(16);
		}
		if (_combatSkillTypeInterest < 0)
		{
			_combatSkillTypeInterest = (sbyte)random.Next(14);
		}
		if (_mainAttributeInterest < 0)
		{
			_mainAttributeInterest = (sbyte)random.Next(6);
		}
		_kidnapperId = -1;
		_leaderId = -1;
		_factionId = -1;
		return combatSkills;
	}

	public void OfflineSetCloseFriendFields(DataContext context, short morality)
	{
		_organizationInfo.Grade = 0;
		_featureIds.Clear();
		_potentialFeatureIds.Clear();
		_featureIds.Add(164);
		_featureIds.Add(685);
		_bisexual = false;
		Genome.EraseAffectedRecessiveTraits(ref _genome);
		_baseMorality = morality;
	}

	public void RemoveUnequippedCombatSkills(DataContext context, sbyte retainingProb = 25)
	{
		HashSet<short> equippedCombatSkills = new HashSet<short>();
		CombatSkillEquipment combatSkillEquipment = GetCombatSkillEquipment();
		combatSkillEquipment.GetValidSkills(equippedCombatSkills);
		List<short> retainedCombatSkillIds = new List<short>(_learnedCombatSkills.Count);
		int i = 0;
		for (int count = _learnedCombatSkills.Count; i < count; i++)
		{
			short skillTemplateId = _learnedCombatSkills[i];
			if (equippedCombatSkills.Contains(skillTemplateId))
			{
				retainedCombatSkillIds.Add(skillTemplateId);
				continue;
			}
			if (CollectionUtils.Contains(_combatSkillAttainmentPanels, skillTemplateId))
			{
				retainedCombatSkillIds.Add(skillTemplateId);
				continue;
			}
			CombatSkillKey skillKey = new CombatSkillKey(_id, skillTemplateId);
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
			if (skill.GetObtainedNeili() > 0 || context.Random.CheckPercentProb(retainingProb))
			{
				retainedCombatSkillIds.Add(skillTemplateId);
			}
			else
			{
				DomainManager.CombatSkill.RemoveCombatSkill(_id, skillTemplateId);
			}
		}
		_learnedCombatSkills.Clear();
		_learnedCombatSkills.AddRange(retainedCombatSkillIds);
		SetLearnedCombatSkills(_learnedCombatSkills, context);
	}

	public void AddEquipmentAndInventoryItems(DataContext context, PresetEquipmentItem[] equipment, List<PresetInventoryItem> inventory)
	{
		OfflineAddEquipmentAndInventoryItems(context, equipment, inventory);
		SetEquipment(_equipment, context);
		SetInventory(_inventory, context);
	}

	public void AddSkillBooksAndWeapons(DataContext context, List<InventoryCombatSkillBookParams> skillBooks, HashSet<short> skillWeaponIds)
	{
		OfflineAddSkillBooksAndWeapons(context, skillBooks, skillWeaponIds);
		SetInventory(_inventory, context);
	}

	public void RemoveUnequippedEquipment(DataContext context)
	{
		_itemsToBeDeleted.Clear();
		foreach (KeyValuePair<ItemKey, int> item2 in _inventory.Items)
		{
			item2.Deconstruct(out var key, out var _);
			ItemKey itemKey = key;
			EquipmentBase item = DomainManager.Item.TryGetBaseEquipment(itemKey);
			if (item != null)
			{
				_itemsToBeDeleted.Add(itemKey);
			}
		}
		int i = 0;
		for (int count = _itemsToBeDeleted.Count; i < count; i++)
		{
			ItemKey itemKey2 = _itemsToBeDeleted[i];
			_inventory.OfflineRemove(itemKey2);
			DomainManager.Item.RemoveItem(context, itemKey2);
		}
		SetInventory(_inventory, context);
	}

	public void OfflineSetId(int id)
	{
		_id = id;
	}

	public void OfflineSetGenderInfo(sbyte gender, bool transgender)
	{
		_gender = gender;
		_transgender = transgender;
	}

	public void OfflineSetAvatar(AvatarData avatar)
	{
		_avatar = avatar;
	}

	public void OfflineSetTemplateId(short templateId)
	{
		_templateId = templateId;
	}

	public void OfflineSetCreatingType(byte creatingType)
	{
		_creatingType = creatingType;
	}

	public void OfflineSetXiangshuType(sbyte xiangshuType)
	{
		_xiangshuType = xiangshuType;
	}

	public void OfflineSetBirthLocation(Location location)
	{
		_birthLocation = location;
	}

	public unsafe void OfflineSetPreexistenceCharId(DataContext context, int reincarnationCharId, bool ignoreBonusFeature = false)
	{
		DeadCharacter reincarnationChar = DomainManager.Character.GetDeadCharacter(reincarnationCharId);
		ref PreexistenceCharIds preexistenceCharIds = ref reincarnationChar.PreexistenceCharIds;
		int bonusIndex = reincarnationChar.FeatureIds.FindIndex(IsReincarnationBonusFeature);
		if (bonusIndex >= 0)
		{
			OfflineAddFeature(reincarnationChar.FeatureIds[bonusIndex], removeMutexFeature: true);
		}
		OfflineInheritPreexistenceCharFeatures(context.Random, reincarnationChar.FeatureIds);
		if (preexistenceCharIds.Count < 9)
		{
			PreexistenceCharIds copiedPreexistenceCharIds = preexistenceCharIds;
			copiedPreexistenceCharIds.Add(context.Random, reincarnationCharId);
			_preexistenceCharIds = copiedPreexistenceCharIds;
			if (_preexistenceCharIds.Count != 9 || ignoreBonusFeature)
			{
				return;
			}
			int diff = 0;
			for (int i = 0; i < preexistenceCharIds.Count; i++)
			{
				int charId = preexistenceCharIds.CharIds[i];
				if (charId >= 0)
				{
					DeadCharacter deadChar = DomainManager.Character.TryGetDeadCharacter(charId);
					if (deadChar != null)
					{
						diff = ((deadChar.FameType != 3 && deadChar.FameType != -2) ? (diff + ((deadChar.FameType > 3) ? 1 : (-1))) : (diff + (context.Random.NextBool() ? 1 : (-1))));
					}
				}
			}
			short featureId = ((diff >= 0) ? ((short)context.Random.Next(232, 237)) : ((short)context.Random.Next(237, 242)));
			AdaptableLog.Info($"Reincarnation bonus feature {CharacterFeature.Instance[featureId].Name} is added to character {this} with diff {diff}");
			OfflineAddFeature(featureId, removeMutexFeature: true);
		}
		else
		{
			DomainManager.Character.RenewPreexistence(context, reincarnationCharId, ref preexistenceCharIds);
			_preexistenceCharIds = preexistenceCharIds;
		}
	}

	public void OfflineInheritPreexistenceCharFeatures(IRandomSource randomSource, List<short> featureIds)
	{
		Span<short> span = stackalloc short[featureIds.Count];
		SpanList<short> inheritableFeatures = span;
		foreach (short featureId in featureIds)
		{
			if (CharacterFeature.Instance[featureId].InheritableThroughSamsara)
			{
				inheritableFeatures.Add(featureId);
			}
		}
		if (inheritableFeatures.Count <= 0)
		{
			return;
		}
		int inheritCount = randomSource.Next(3) + 1;
		for (int i = 0; i < inheritCount; i++)
		{
			if (inheritableFeatures.Count <= 0)
			{
				break;
			}
			int index = randomSource.Next(inheritableFeatures.Count);
			short featureId2 = inheritableFeatures[index];
			inheritableFeatures.SwapRemove(index);
			OfflineAddFeature(featureId2, removeMutexFeature: true, removeLowerOnly: true);
		}
	}

	internal void ClearPreexistenceCharIds(DataContext context)
	{
		_preexistenceCharIds.Reset();
		SetModifiedAndInvalidateInfluencedCache(63, context);
	}

	public void OfflineCreateRandomName(IRandomSource random, int customSurnameId = -1, int customGivenNameId = -1)
	{
		if (Config.Character.Instance[_templateId].Race == 0)
		{
			if (_gender == 0)
			{
				_fullName = CharacterDomain.GenerateRandomHanName(random, customSurnameId, -1, _gender, -1);
			}
			else
			{
				_fullName = CharacterDomain.GenerateRandomHanName(random, customSurnameId, -1, _gender, 0);
			}
		}
		else
		{
			_fullName = CharacterDomain.GenerateRandomZangName(random, _gender);
		}
	}

	internal void SetCharacterUnamedStatus(DataContext context, bool unamed)
	{
		if (unamed)
		{
			_fullName.Type |= 16;
		}
		else
		{
			_fullName.Type &= -17;
		}
		SetFullName(_fullName, context);
	}

	public void OfflineRecreateByGrowingSect(IRandomSource random, sbyte growingOrgTemplateId, sbyte growingGrade)
	{
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(growingOrgTemplateId, growingGrade);
		_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, growingGrade, orgMemberCfg.MainAttributesAdjust);
		_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, growingGrade, orgMemberCfg.LifeSkillsAdjust);
		_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, growingGrade, orgMemberCfg.CombatSkillsAdjust);
		_lifeSkillQualificationGrowthType = (sbyte)random.Next(3);
		_combatSkillQualificationGrowthType = (sbyte)random.Next(3);
	}

	public void RecreateMainAttributes(DataContext context, sbyte growingOrgTemplateId, sbyte growingGrade)
	{
		IRandomSource random = context.Random;
		short orgMemberId = ChooseGrowingSectMember(random, growingOrgTemplateId, growingGrade);
		OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
		_baseMainAttributes = CharacterCreation.CreateMainAttributes(random, growingGrade, orgMemberCfg.MainAttributesAdjust);
		SetBaseMainAttributes(_baseMainAttributes, context);
	}

	public void RecreateCombatSkillQualifications(DataContext context, sbyte growingOrgTemplateId, sbyte growingGrade)
	{
		IRandomSource random = context.Random;
		short orgMemberId = ChooseGrowingSectMember(random, growingOrgTemplateId, growingGrade);
		OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
		_baseCombatSkillQualifications = CharacterCreation.CreateCombatSkillQualifications(random, growingGrade, orgMemberCfg.CombatSkillsAdjust);
		SetBaseCombatSkillQualifications(ref _baseCombatSkillQualifications, context);
	}

	public void RecreateLifeSkillQualifications(DataContext context, sbyte growingOrgTemplateId, sbyte growingGrade)
	{
		IRandomSource random = context.Random;
		short orgMemberId = ChooseGrowingSectMember(random, growingOrgTemplateId, growingGrade);
		OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
		_baseLifeSkillQualifications = CharacterCreation.CreateLifeSkillQualifications(random, growingGrade, orgMemberCfg.LifeSkillsAdjust);
		SetBaseLifeSkillQualifications(ref _baseLifeSkillQualifications, context);
	}

	public void RecreateFeatures(DataContext context, int positiveFeatureRate, sbyte featureMedalType)
	{
		for (int i = _featureIds.Count - 1; i >= 0; i--)
		{
			short featureId = _featureIds[i];
			CharacterFeatureItem featureCfg = CharacterFeature.Instance[featureId];
			if (featureCfg.Basic && featureCfg.MutexGroupId != 168)
			{
				_featureIds.Remove(featureId);
			}
		}
		_potentialFeatureIds.Clear();
		int basicFeaturesCount = CharacterCreation.GenerateRandomBasicFeaturesCount(context.Random);
		if (basicFeaturesCount <= 0)
		{
			return;
		}
		bool isProtagonist = _id == DomainManager.Taiwu.GetTaiwuCharId();
		Dictionary<short, short> featureGroup2Id = new Dictionary<short, short>(16);
		IRandomSource random = context.Random;
		int goodFeaturesPotential = positiveFeatureRate;
		featureGroup2Id.Add(168, -1);
		for (int j = 0; j < basicFeaturesCount; j++)
		{
			if (random.CheckPercentProb(goodFeaturesPotential))
			{
				sbyte currFeatureMedalType = featureMedalType;
				if (featureMedalType != 3 && !context.Random.CheckPercentProb(60))
				{
					currFeatureMedalType = 3;
				}
				var (groupId, featureId2) = CharacterDomain.GetRandomBasicFeature(random, isProtagonist, _gender, isPositive: true, currFeatureMedalType, featureGroup2Id, 3);
				if (featureId2 >= 0)
				{
					featureGroup2Id.Add(groupId, featureId2);
					goodFeaturesPotential -= 20;
				}
			}
			else
			{
				var (groupId2, featureId3) = CharacterDomain.GetRandomBasicFeature(random, isProtagonist, _gender, isPositive: false, featureGroup2Id);
				if (featureId3 >= 0)
				{
					featureGroup2Id.Add(groupId2, featureId3);
					goodFeaturesPotential += 20;
				}
			}
		}
		int potentialFeaturesAge = ((GetAgeGroup() == 2) ? (-1) : _actualAge);
		foreach (KeyValuePair<short, short> item in featureGroup2Id)
		{
			short featureId4 = item.Value;
			if (featureId4 >= 0)
			{
				if (potentialFeaturesAge >= 0 && CharacterFeature.Instance[featureId4].Mergeable)
				{
					_potentialFeatureIds.Add(featureId4);
				}
				else
				{
					_featureIds.Add(featureId4);
				}
			}
		}
		if (potentialFeaturesAge >= 0)
		{
			int affectedFeaturesCount = _potentialFeatureIds.Count * potentialFeaturesAge / 16;
			for (int k = 0; k < affectedFeaturesCount; k++)
			{
				_featureIds.Add(_potentialFeatureIds[k]);
			}
		}
		SetFeatureIds(_featureIds, context);
		SetPotentialFeatureIds(_potentialFeatureIds, context);
	}

	public void RecreateFeaturesByUpgradeCount(DataContext context, int upgradeCount, sbyte featureMedalType)
	{
		Dictionary<short, short> featureGroup2Id = ObjectPool<Dictionary<short, short>>.Instance.Get();
		List<short> matchedFeatures = ObjectPool<List<short>>.Instance.Get();
		List<short> mismatchedFeatures = ObjectPool<List<short>>.Instance.Get();
		bool isProtagonist = _id == DomainManager.Taiwu.GetTaiwuCharId();
		for (int i = 0; i < upgradeCount; i++)
		{
			featureGroup2Id.Clear();
			matchedFeatures.Clear();
			mismatchedFeatures.Clear();
			List<short> targetFeatures;
			if (featureMedalType != 3)
			{
				foreach (short id in _featureIds)
				{
					CharacterFeatureItem featureCfg = CharacterFeature.Instance[id];
					if (!featureCfg.Basic || featureCfg.MutexGroupId == 168)
					{
						continue;
					}
					if (CharacterFeatureHelper.CalcFeatureMedalValue(new short[1] { id }, featureMedalType) > 0)
					{
						if ((featureCfg.IsGood() && !featureCfg.IsHighest()) || featureCfg.IsBad())
						{
							matchedFeatures.Add(id);
						}
					}
					else if ((featureCfg.IsGood() && !featureCfg.IsHighest()) || featureCfg.IsBad())
					{
						mismatchedFeatures.Add(id);
					}
				}
				targetFeatures = ((matchedFeatures.Count == 0) ? mismatchedFeatures : ((mismatchedFeatures.Count == 0) ? matchedFeatures : (context.Random.CheckPercentProb(60) ? matchedFeatures : mismatchedFeatures)));
			}
			else
			{
				foreach (short id2 in _featureIds)
				{
					CharacterFeatureItem featureCfg2 = CharacterFeature.Instance[id2];
					if (featureCfg2.Basic && featureCfg2.MutexGroupId != 168 && ((featureCfg2.IsGood() && !featureCfg2.IsHighest()) || featureCfg2.IsBad()))
					{
						matchedFeatures.Add(id2);
					}
				}
				targetFeatures = matchedFeatures;
			}
			if (targetFeatures.Count == 0)
			{
				sbyte currFeatureMedalType = featureMedalType;
				if (featureMedalType == 3)
				{
					currFeatureMedalType = (sbyte)context.Random.Next(0, 3);
				}
				foreach (short id3 in _featureIds)
				{
					CharacterFeatureItem featureConfig = CharacterFeature.Instance[id3];
					short mutexGroupId = featureConfig.MutexGroupId;
					featureGroup2Id.Add(mutexGroupId, id3);
				}
				var (groupId, featureId) = CharacterDomain.GetRandomBasicFeature(context.Random, isProtagonist, _gender, isPositive: true, currFeatureMedalType, featureGroup2Id, 1);
				if (featureId >= 0)
				{
					_featureIds.Add(featureId);
				}
				continue;
			}
			short id4 = context.Random.GetRandomElement(targetFeatures);
			CharacterFeatureItem featureConfig2 = CharacterFeature.Instance[id4];
			int index = _featureIds.IndexOf(id4);
			if (featureConfig2.IsGood())
			{
				CharacterFeatureItem characterFeatureItem = featureConfig2.Upgrade();
				if (characterFeatureItem != null)
				{
					_featureIds[index] = characterFeatureItem.TemplateId;
				}
			}
			else
			{
				CharacterFeatureItem characterFeatureItem = featureConfig2.Degrade();
				if (characterFeatureItem != null)
				{
					_featureIds[index] = characterFeatureItem.TemplateId;
				}
				else
				{
					_featureIds.RemoveAt(index);
				}
			}
		}
		SetFeatureIds(_featureIds, context);
		ObjectPool<Dictionary<short, short>>.Instance.Return(featureGroup2Id);
		ObjectPool<List<short>>.Instance.Return(matchedFeatures);
		ObjectPool<List<short>>.Instance.Return(mismatchedFeatures);
	}

	public static short GenerateRandomAge(IRandomSource random)
	{
		return (short)RedzenHelper.NormalDistribute(random, 30f, 6.667f, 10, 50);
	}

	public static short GenerateRandomAge(IRandomSource random, short baseAge)
	{
		return (short)Math.Max(16, random.Next(baseAge - 5, baseAge + 6));
	}

	public static bool IsXiangshuMinion(short templateId)
	{
		return templateId >= 366 && templateId <= 374;
	}

	public static bool IsRighteous(short templateId)
	{
		CharacterItem config = Config.Character.Instance.GetItem(templateId);
		return config != null && config.OrganizationInfo.OrgTemplateId == 18;
	}

	public static bool IsReincarnationBonusFeature(short featureId)
	{
		switch (featureId)
		{
		case 232:
		case 233:
		case 234:
		case 235:
		case 236:
		case 237:
		case 238:
		case 239:
		case 240:
		case 241:
			return true;
		default:
			return false;
		}
	}

	public static bool IsPositiveReincarnationBonusFeature(short featureId)
	{
		return featureId >= 232 && featureId <= 236;
	}

	public static bool IsNegativeReincarnationBonusFeature(short featureId)
	{
		return featureId >= 237 && featureId <= 241;
	}

	public static bool IsProfessionReincarnationBonusFeature(short featureId)
	{
		return featureId >= 242 && featureId <= 261;
	}

	public static bool IsProfessionPositiveReincarnationBonusFeature(short featureId)
	{
		switch (featureId)
		{
		case 242:
		case 243:
		case 244:
		case 245:
		case 246:
		case 252:
		case 253:
		case 254:
		case 255:
		case 256:
			return true;
		default:
			return false;
		}
	}

	public static bool IsProfessionNegativeReincarnationBonusFeature(short featureId)
	{
		switch (featureId)
		{
		case 247:
		case 248:
		case 249:
		case 250:
		case 251:
		case 257:
		case 258:
		case 259:
		case 260:
		case 261:
			return true;
		default:
			return false;
		}
	}

	private void OfflineCreateRandomName(DataContext context, ref IntelligentCharacterCreationInfo info, CreateIntelligentCharacterModification mod, sbyte race)
	{
		if (race == 0)
		{
			if (info.ReferenceFullName.Type != 0)
			{
				_fullName = CharacterDomain.GenerateRandomHanName(context.Random, info.ReferenceFullName.GetCustomSurnameId(), info.ReferenceFullName.GetSurnameId(), _gender, -1);
				return;
			}
			FullName fullname = GetMainParentFullName(ref info, mod.CreateMotherRelation, mod.CreateFatherRelation);
			int customSurnameId = fullname.GetCustomSurnameId();
			short surnameId = fullname.GetSurnameId();
			if (_gender == 0)
			{
				_fullName = CharacterDomain.GenerateRandomHanName(context.Random, customSurnameId, surnameId, _gender, -1);
				return;
			}
			int elderBrothersCount = GetElderBrothersCount(ref info, mod);
			_fullName = CharacterDomain.GenerateRandomHanName(context.Random, customSurnameId, surnameId, _gender, elderBrothersCount);
			if (elderBrothersCount < 0)
			{
				return;
			}
			if (elderBrothersCount == 0)
			{
				if (_fullName.GivenNameGroupId == 0)
				{
					mod.Father = info.Father;
					mod.FathersLegitimateBoysCount = 1;
				}
				else
				{
					mod.Father = info.Father;
					mod.FathersLegitimateBoysCount = -1;
				}
			}
			else
			{
				mod.Father = info.Father;
				mod.FathersLegitimateBoysCount = (sbyte)(elderBrothersCount + 1);
			}
		}
		else
		{
			_fullName = CharacterDomain.GenerateRandomZangName(context.Random, _gender);
		}
	}

	private static FullName GetMainParentFullName(ref IntelligentCharacterCreationInfo info, bool createMotherRelation, bool createFatherRelation)
	{
		if (createMotherRelation && !createFatherRelation)
		{
			return info.Mother.GetFullName();
		}
		if (info.Father != null)
		{
			return info.Father.GetFullName();
		}
		if (info.DeadFather != null)
		{
			return info.DeadFather.FullName;
		}
		return default(FullName);
	}

	private static int GetElderBrothersCount(ref IntelligentCharacterCreationInfo info, CreateIntelligentCharacterModification mod)
	{
		if (info.Father == null || info.Mother == null)
		{
			return -1;
		}
		HashSet<int> wives = DomainManager.Character.GetRelatedCharIds(info.FatherCharId, 1024);
		if (!wives.Contains(info.MotherCharId))
		{
			return -1;
		}
		if (info.MultipleBirthCount > 1)
		{
			mod.Father = info.Father;
			mod.FathersLegitimateBoysCount = -1;
			return -1;
		}
		sbyte legitimateBoysCount = info.Father.GetLegitimateBoysCount();
		if (legitimateBoysCount >= 5)
		{
			mod.Father = info.Father;
			mod.FathersLegitimateBoysCount = -1;
			return -1;
		}
		return legitimateBoysCount;
	}

	private void OfflineCreateAttractionAndAvatar(DataContext context, sbyte bodyType, ref IntelligentCharacterCreationInfo info, sbyte haveHair = -1)
	{
		if (bodyType < 0)
		{
			bodyType = BodyType.GetRandom(context.Random);
		}
		if (info.BaseAttraction >= 0)
		{
			if (info.Avatar != null)
			{
				_avatar = info.Avatar;
				if (_transgender)
				{
					_avatar.ChangeGender(Gender.Flip(_gender));
				}
			}
			else
			{
				_avatar = AvatarManager.Instance.GetRandomAvatar(context.Random, _gender, _transgender, bodyType, info.BaseAttraction);
			}
			if (haveHair > 0)
			{
				AvatarGroup avatarGroup = AvatarManager.Instance.GetAvatarGroup(_avatar.AvatarId);
				short frontHairId;
				short backHairId;
				if (haveHair == 1)
				{
					(frontHairId, backHairId) = avatarGroup.GetRandomHairsNoSkinHead(context.Random);
				}
				else
				{
					(frontHairId, backHairId) = avatarGroup.GetHairsSkinHead(context.Random);
				}
				_avatar.FrontHairId = frontHairId;
				_avatar.BackHairId = backHairId;
			}
		}
		else if (info.MotherCharId >= 0 || info.ActualFatherCharId >= 0)
		{
			AvatarData motherAvatar = info.Mother?.GetAvatar();
			AvatarData fatherAvatar = info.ActualFather?.GetAvatar() ?? info.ActualDeadFather?.Avatar;
			_avatar = AvatarManager.Instance.GetRandomAvatar(context.Random, _gender, _transgender, bodyType, fatherAvatar, motherAvatar);
		}
		else
		{
			sbyte baseAttractionType = (sbyte)((_organizationInfo.OrgTemplateId != 16 && context.Random.CheckPercentProb(20)) ? _organizationInfo.Grade : (-1));
			short baseAttraction = GenerateRandomAttraction(context.Random, baseAttractionType);
			_avatar = AvatarManager.Instance.GetRandomAvatar(context.Random, _gender, _transgender, bodyType, baseAttraction);
		}
	}

	private void OfflineCreateInitialLifeSkills(IRandomSource random, OrganizationMemberItem orgMemberCfg)
	{
		OfflineCreateInitialLifeSkills(random, orgMemberCfg.LifeSkillsAdjust, orgMemberCfg.LifeSkillGradeLimit);
	}

	private unsafe void OfflineCreateInitialLifeSkills(IRandomSource random, short[] lifeSkillsAdjust, sbyte skillGradeLimit)
	{
		for (sbyte lifeSkillType = 0; lifeSkillType < lifeSkillsAdjust.Length; lifeSkillType++)
		{
			short adjust = lifeSkillsAdjust[lifeSkillType];
			if (adjust >= 6)
			{
				int attainmentPercentage = 0;
				short qualification = _baseLifeSkillQualifications.Items[lifeSkillType];
				int baseChance = adjust + 100;
				for (int grade = 0; grade < skillGradeLimit; grade++)
				{
					short lifeSkillTemplateId = Config.LifeSkillType.Instance[lifeSkillType].SkillList[grade];
					short attainmentReq = SkillGradeData.Instance[grade].ReadingAttainmentRequirement;
					attainmentPercentage += 5 * (grade + 1);
					int percentageBonus = ((grade > 8) ? (attainmentPercentage * 2) : ((grade > 5) ? (attainmentPercentage / 2) : ((grade > 2) ? (attainmentPercentage / 4) : 0)));
					int attainment = qualification * (100 + percentageBonus) / 100;
					if (!random.CheckPercentProb(attainment * baseChance / attainmentReq))
					{
						break;
					}
					LifeSkillItem learnedLifeSkill = new LifeSkillItem(lifeSkillTemplateId);
					learnedLifeSkill.SetRandomPagesRead(random, 5);
					_learnedLifeSkills.Add(learnedLifeSkill);
				}
			}
		}
	}

	private void OfflineCreatePresetLifeSkillsByGradeConfig()
	{
		sbyte[] grades = Config.Character.Instance[_templateId].LearnedLifeSkillGrades;
		List<LifeSkillItem> prevLearnedLifeSkills = ((_learnedLifeSkills.Count > 0) ? _learnedLifeSkills : null);
		if (prevLearnedLifeSkills != null)
		{
			_learnedLifeSkills = new List<LifeSkillItem>();
		}
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			sbyte maxGrade = grades[lifeSkillType];
			if (maxGrade >= 0)
			{
				for (sbyte grade = 0; grade <= maxGrade; grade++)
				{
					short lifeSkillTemplateId = Config.LifeSkillType.Instance[lifeSkillType].SkillList[grade];
					_learnedLifeSkills.Add(new LifeSkillItem(lifeSkillTemplateId)
					{
						ReadingState = 31
					});
				}
			}
		}
		if (prevLearnedLifeSkills == null)
		{
			return;
		}
		if (_learnedLifeSkills.Count != 0)
		{
			foreach (LifeSkillItem prevLearnedSkill in prevLearnedLifeSkills)
			{
				if (FindLearnedLifeSkillIndex(prevLearnedSkill.SkillTemplateId) < 0)
				{
					_learnedLifeSkills.Add(prevLearnedSkill);
				}
			}
			return;
		}
		_learnedLifeSkills.AddRange(prevLearnedLifeSkills);
	}

	private static int GetCurrAdjust(IRandomSource random, short[] adjusts, sbyte index, sbyte abnormalProb)
	{
		if (adjusts == null)
		{
			return 0;
		}
		if (abnormalProb > 0 && random.CheckPercentProb(abnormalProb))
		{
			return 0;
		}
		return adjusts[index];
	}

	private unsafe void OfflineCreateResources(IRandomSource random, short orgMemberId, sbyte abnormalOrgAttributesProb)
	{
		short[] resourcesAdjust = ((orgMemberId >= 0) ? OrganizationDomain.GetMemberResourcesAdjust(orgMemberId) : null);
		sbyte abnormalProb = (sbyte)(random.CheckPercentProb(abnormalOrgAttributesProb) ? random.Next(101) : 0);
		int percent = DomainManager.World.GetGainResourcePercent(12);
		int challengePercent = DomainManager.World.GetChallengeModeData().GetCharacterResourcesCreateRate();
		for (sbyte i = 0; i < 8; i++)
		{
			int unit = ((i == 7) ? 100 : 200);
			int currValue = RedzenHelper.GetNormalDistributedRangedValue(random, unit, unit * 2);
			int currAdjust = GetCurrAdjust(random, resourcesAdjust, i, abnormalProb);
			currValue = currValue * (100 + currAdjust) / 100;
			currValue = currValue * percent / 100;
			currValue = currValue * challengePercent / 100;
			_resources.Items[i] = ((currValue > 0) ? currValue : 0);
		}
	}

	private static SkillQualificationBonus GenerateRandomInnateSkillQualificationBonus(DataContext context)
	{
		IRandomSource random = context.Random;
		int skillGroup = random.Next(2);
		int skillType = ((skillGroup == 0) ? random.Next(16) : random.Next(14));
		int value = RedzenHelper.SkewDistribute(context.Random, 7f, 1.5f, 2f, 3, 15);
		return new SkillQualificationBonus((sbyte)skillGroup, (sbyte)skillType, (sbyte)value, -1);
	}

	private static short GenerateRandomMaxHealth(IRandomSource random)
	{
		int factor = DomainManager.World.GetCharacterLifeSpanFactor();
		int min = factor / 2 * 12;
		int max = factor * 12;
		float mean = (float)(min + max) / 2f;
		float stdDev = (float)(max - min) / 6f;
		return (short)RedzenHelper.NormalDistribute(random, mean, stdDev, min, max);
	}

	private static short GenerateProtagonistMaxHealth(IRandomSource random)
	{
		int factor = DomainManager.World.GetCharacterLifeSpanFactor();
		int baseMaxAge = factor * 3 / 4;
		int maxAge = baseMaxAge + random.Next(5, 15) * factor / 100;
		return (short)(maxAge * 12 + random.Next(12));
	}

	private static short GenerateRandomAttraction(IRandomSource random, sbyte attractionType = -1)
	{
		if (attractionType >= 0)
		{
			return (short)(attractionType * 100 + random.Next(100));
		}
		return (short)RedzenHelper.SkewDistribute(random, 350f, 152.2f, 1.5714285f, 0, 900);
	}

	private static (short lovingItemSubType, short hatingItemSubType) GenerateRandomHobby(IRandomSource random)
	{
		short lovingSubType = ItemSubType.GetRandom(random);
		short hatingSubType = ItemSubType.GetRandom(random);
		if (!ItemSubType.IsHobbyType(lovingSubType))
		{
			lovingSubType = -1;
		}
		if (!ItemSubType.IsHobbyType(hatingSubType))
		{
			hatingSubType = -1;
		}
		if (lovingSubType == hatingSubType && lovingSubType != -1)
		{
			if (random.CheckPercentProb(50))
			{
				lovingSubType = -1;
			}
			else
			{
				hatingSubType = -1;
			}
		}
		return (lovingItemSubType: lovingSubType, hatingItemSubType: hatingSubType);
	}

	private void OfflineGenerateRandomIdealSect(IRandomSource random)
	{
		if (Template.IdealSect == 0)
		{
			_idealSect = -1;
			return;
		}
		List<sbyte> randomIdealSectsPool = Template.RandomIdealSects;
		_idealSect = ((randomIdealSectsPool != null && randomIdealSectsPool.Count > 0) ? randomIdealSectsPool.GetRandom(random) : ((sbyte)((Template.IdealSect > 0) ? Template.IdealSect : (-1))));
	}

	private void OfflineCreateProtagonistRandomFeatures(DataContext context, List<short> inscribedFeatureIds, bool addFeatureLongevity)
	{
		if (inscribedFeatureIds != null)
		{
			int i = 0;
			for (int featuresCount = inscribedFeatureIds.Count; i < featuresCount; i++)
			{
				_featureIds.Add(inscribedFeatureIds[i]);
			}
		}
		_featureIds.Add(CharacterDomain.GetBirthdayFeatureId(_birthMonth));
		if (addFeatureLongevity)
		{
			_featureIds.Add(686);
		}
		if (inscribedFeatureIds == null)
		{
			FeatureCreationContext featureCreationContext = new FeatureCreationContext(this);
			featureCreationContext.IsProtagonist = true;
			FeatureCreationContext creationContext = featureCreationContext;
			CharacterCreation.CreateFeatures(context.Random, ref creationContext);
			return;
		}
		if (addFeatureLongevity)
		{
			CharacterDomain.GenerateLongevityFeatures(context.Random, _gender, _featureIds);
		}
		_featureIds.Add(196);
		_featureIds.Add(209);
		_featureIds.Sort(CharacterFeatureHelper.FeatureComparer);
	}

	private void OfflineCreateGenome(IRandomSource randomSource, Character mother, PregnantState pregnantState, Character father)
	{
		if (pregnantState != null)
		{
			if (pregnantState.FatherId >= 0)
			{
				Genome.Inherit(randomSource, ref mother.GetGenome(), ref pregnantState.FatherGenome, ref _genome);
				return;
			}
			Genome virtualFatherGenome = default(Genome);
			Genome.CreateRandom(randomSource, ref virtualFatherGenome);
			Genome.Inherit(randomSource, ref mother.GetGenome(), ref virtualFatherGenome, ref _genome);
		}
		else
		{
			GenomeHelper.Inherit(randomSource, mother, father, ref _genome);
		}
	}

	private void OfflineAddGoodAtCombatSkills(DataContext context, CreateIntelligentCharacterModification mod, sbyte skillType)
	{
		IRandomSource random = context.Random;
		OrganizationItem orgCfg = Config.Organization.Instance[_organizationInfo.OrgTemplateId];
		sbyte sectId = ((orgCfg.CombatSkillTypes != null && orgCfg.CombatSkillTypes.Contains(skillType)) ? _organizationInfo.OrgTemplateId : OrganizationDomain.GetGoodAtCombatSkillTypeSect(random, skillType));
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(sectId, _organizationInfo.Grade);
		sbyte behaviorType = BehaviorType.GetBehaviorType(_baseMorality);
		List<InventoryCombatSkillBookParams> skillBooks = new List<InventoryCombatSkillBookParams>();
		HashSet<short> suitableWeaponIds = new HashSet<short>();
		IReadOnlyList<CombatSkillItem> goodAtGroup = CombatSkillDomain.GetLearnableCombatSkills(sectId, skillType);
		foreach (PresetOrgMemberCombatSkill presetSkill in orgMemberCfg.CombatSkills)
		{
			CombatSkillItem presetSkillCfg = Config.CombatSkill.Instance[presetSkill.SkillGroupId];
			IReadOnlyList<CombatSkillItem> group = CombatSkillDomain.GetLearnableCombatSkills(presetSkillCfg.SectId, presetSkillCfg.Type);
			sbyte maxGrade = (sbyte)Math.Min(presetSkill.MaxGrade, group.Count - 1);
			LearnInGroup(group, maxGrade, 50);
		}
		sbyte maxGrade2 = (sbyte)Math.Min(_organizationInfo.Grade, goodAtGroup.Count - 1);
		LearnInGroup(goodAtGroup, maxGrade2, 100);
		OfflineAddSkillBooksAndWeapons(context, skillBooks, suitableWeaponIds);
		void LearnInGroup(IReadOnlyList<CombatSkillItem> readOnlyList, sbyte b, int chance)
		{
			for (int skillGrade = 0; skillGrade <= b; skillGrade++)
			{
				if (skillGrade == b || random.CheckPercentProb(chance))
				{
					CombatSkillItem skillConfig = readOnlyList[skillGrade];
					if (!_learnedCombatSkills.Contains(skillConfig.TemplateId))
					{
						sbyte directCount = (sbyte)random.Next(6);
						sbyte indirectCount = (sbyte)(5 - directCount);
						GameData.Domains.CombatSkill.CombatSkill combatSkill = new GameData.Domains.CombatSkill.CombatSkill(random, _id, skillConfig.TemplateId, behaviorType, directCount, indirectCount);
						byte bookPageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(random, combatSkill.GetReadingState());
						mod.CombatSkills.Add(combatSkill);
						_learnedCombatSkills.Add(skillConfig.TemplateId);
						if (random.CheckPercentProb(11 - skillGrade * 2))
						{
							skillBooks.Add(new InventoryCombatSkillBookParams(skillConfig.BookId, bookPageTypes));
						}
						short suitableWeaponId = skillConfig.MostFittingWeaponID;
						sbyte grade = ItemDomain.GenerateRandomItemGrade(random, _organizationInfo.Grade);
						if (suitableWeaponId >= 0)
						{
							suitableWeaponIds.Add((short)(suitableWeaponId + grade));
						}
					}
				}
			}
		}
	}

	private void OfflineAddGoodAtLifeSkills(DataContext context, CreateIntelligentCharacterModification mod, sbyte lifeSkillType)
	{
		IRandomSource random = context.Random;
		for (int grade = 0; grade < _organizationInfo.Grade; grade++)
		{
			short lifeSkillTemplateId = Config.LifeSkillType.Instance[lifeSkillType].SkillList[grade];
			if (FindLearnedLifeSkillIndex(lifeSkillTemplateId) < 0)
			{
				LifeSkillItem learnedLifeSkill = new LifeSkillItem(lifeSkillTemplateId);
				learnedLifeSkill.SetRandomPagesRead(random, 5);
				_learnedLifeSkills.Add(learnedLifeSkill);
			}
		}
	}

	private List<GameData.Domains.CombatSkill.CombatSkill> OfflineCreateCombatSkills(IRandomSource random, List<PresetCombatSkill> presetCombatSkills)
	{
		int combatSkillsCount = presetCombatSkills.Count;
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>(combatSkillsCount);
		for (int i = 0; i < combatSkillsCount; i++)
		{
			PresetCombatSkill presetSkill = presetCombatSkills[i];
			combatSkills.Add(new GameData.Domains.CombatSkill.CombatSkill(random, presetSkill));
			_learnedCombatSkills.Add(presetSkill.SkillTemplateId);
		}
		return combatSkills;
	}

	private List<GameData.Domains.CombatSkill.CombatSkill> OfflineCreateRandomEnemyCombatSkills(IRandomSource random, RandomEnemyItem randomEnemyCfg, List<PresetCombatSkill> presetCombatSkills)
	{
		int combatSkillsCount = presetCombatSkills.Count;
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>(combatSkillsCount);
		WorldCreationItem enemyPracticeLevelCfg = WorldCreation.Instance[(byte)11];
		sbyte behaviorType = BehaviorType.GetBehaviorType(_baseMorality);
		for (int i = 0; i < combatSkillsCount; i++)
		{
			PresetCombatSkill presetSkill = presetCombatSkills[i];
			GameData.Domains.CombatSkill.CombatSkill combatSkill = OfflineCreateRandomEnemyCombatSkill(random, presetSkill.SkillTemplateId, behaviorType, randomEnemyCfg, enemyPracticeLevelCfg);
			combatSkills.Add(combatSkill);
			_learnedCombatSkills.Add(presetSkill.SkillTemplateId);
		}
		return combatSkills;
	}

	private void OfflineAddRandomEnemyOrgMemberCombatSkills(DataContext context, RandomEnemyItem randomEnemyCfg, List<(OrganizationItem Org, OrganizationMemberItem Member)> relatedSectAndMembers, List<GameData.Domains.CombatSkill.CombatSkill> charCombatSkills)
	{
		IRandomSource random = context.Random;
		sbyte behaviorType = BehaviorType.GetBehaviorType(_baseMorality);
		List<InventoryCombatSkillBookParams> skillBooks = new List<InventoryCombatSkillBookParams>();
		HashSet<short> suitableWeaponIds = new HashSet<short>();
		WorldCreationItem enemyPracticeLevelCfg = WorldCreation.Instance[(byte)11];
		int i = 0;
		for (int count = relatedSectAndMembers.Count; i < count; i++)
		{
			OrganizationMemberItem orgMember = relatedSectAndMembers[i].Member;
			foreach (PresetOrgMemberCombatSkill presetSkill in orgMember.CombatSkills)
			{
				CombatSkillItem presetSkillCfg = Config.CombatSkill.Instance[presetSkill.SkillGroupId];
				if (presetSkillCfg.EquipType == 1)
				{
					List<short> requireAttackSkillType = randomEnemyCfg.RequireAttackSkillType;
					if (requireAttackSkillType != null && requireAttackSkillType.Count > 0 && !randomEnemyCfg.RequireAttackSkillType.Contains(presetSkillCfg.Type))
					{
						continue;
					}
				}
				IReadOnlyList<CombatSkillItem> group = CombatSkillDomain.GetLearnableCombatSkills(presetSkillCfg.SectId, presetSkillCfg.Type);
				int maxGrade = Math.Min(presetSkill.MaxGrade, group.Count - 1);
				for (int skillGrade = 0; skillGrade <= maxGrade; skillGrade++)
				{
					if (skillGrade == presetSkill.MaxGrade || random.CheckPercentProb(50))
					{
						CombatSkillItem skillConfig = group[skillGrade];
						GameData.Domains.CombatSkill.CombatSkill combatSkill = OfflineCreateRandomEnemyCombatSkill(random, skillConfig.TemplateId, behaviorType, randomEnemyCfg, enemyPracticeLevelCfg);
						byte bookPageTypes = CombatSkillStateHelper.GeneratePageTypesFromReadingState(random, combatSkill.GetReadingState());
						charCombatSkills.Add(combatSkill);
						_learnedCombatSkills.Add(skillConfig.TemplateId);
						if (random.CheckPercentProb(11 - skillGrade * 2))
						{
							skillBooks.Add(new InventoryCombatSkillBookParams(skillConfig.BookId, bookPageTypes));
						}
						short suitableWeaponId = skillConfig.MostFittingWeaponID;
						sbyte grade = ItemDomain.GenerateRandomItemGrade(random, _organizationInfo.Grade);
						if (suitableWeaponId >= 0)
						{
							suitableWeaponIds.Add((short)(suitableWeaponId + grade));
						}
					}
				}
			}
		}
		OfflineAddSkillBooksAndWeapons(context, skillBooks, suitableWeaponIds);
	}

	private GameData.Domains.CombatSkill.CombatSkill OfflineCreateRandomEnemyCombatSkill(IRandomSource random, short skillTemplateId, sbyte behaviorType, RandomEnemyItem randomEnemyCfg, WorldCreationItem enemyPracticeLevelCfg)
	{
		byte difficulty = DomainManager.World.GetEnemyPracticeLevel();
		short pageBuff = enemyPracticeLevelCfg.InfluenceFactors[difficulty];
		int directBuff = random.Next(0, pageBuff + 1);
		(int, int)[] pageRanges = randomEnemyCfg.PageCountRandomRange;
		sbyte directCount = (sbyte)Math.Clamp(random.Next(pageRanges[0].Item1, pageRanges[0].Item2 + 1) + directBuff, 0, 5);
		sbyte indirectCount = (sbyte)Math.Clamp(random.Next(pageRanges[1].Item1, pageRanges[1].Item2 + 1) + pageBuff - directBuff, 0, 5);
		return new GameData.Domains.CombatSkill.CombatSkill(random, _id, skillTemplateId, behaviorType, directCount, indirectCount);
	}

	private void OfflineCreateCombatSkills(IRandomSource random, List<PresetCombatSkill> presetCombatSkills, CreateIntelligentCharacterModification mod)
	{
		List<GameData.Domains.CombatSkill.CombatSkill> combatSkills = OfflineCreateCombatSkills(random, presetCombatSkills);
		mod.CombatSkills = combatSkills;
	}

	private void OfflineAddPresetOrgMemberCombatSkills(DataContext context, CreateIntelligentCharacterModification mod, OrganizationItem orgConfig, OrganizationMemberItem orgMemberConfig, int ageInfluence)
	{
		sbyte selfBehaviorType = BehaviorType.GetBehaviorType(_baseMorality);
		sbyte teacherBehaviorType = (sbyte)((orgConfig.MainMorality == short.MinValue) ? (-1) : BehaviorType.GetBehaviorType(orgConfig.MainMorality));
		List<InventoryCombatSkillBookParams> inventorySkillBooks = new List<InventoryCombatSkillBookParams>();
		HashSet<short> suitableWeaponIds = new HashSet<short>();
		OfflineAddPresetOrgMemberCombatSkillsInternal(context.Random, orgConfig.Goodness, teacherBehaviorType, selfBehaviorType, ageInfluence, orgMemberConfig.CombatSkills, mod.CombatSkills, inventorySkillBooks, suitableWeaponIds);
		mod.InventorySkillBooks = inventorySkillBooks;
		mod.SkillWeaponIds = suitableWeaponIds;
	}

	private void OfflineAddSkillBooksAndWeapons(DataContext context, List<InventoryCombatSkillBookParams> skillBooks, HashSet<short> skillWeaponIds)
	{
		int i = 0;
		for (int skillBooksCount = skillBooks.Count; i < skillBooksCount; i++)
		{
			InventoryCombatSkillBookParams book = skillBooks[i];
			ItemKey itemKey = DomainManager.Item.CreateSkillBook(context, book.TemplateId, book.PageTypes, -1, -1);
			_inventory.OfflineAdd(itemKey, 1);
		}
		foreach (short weaponId in skillWeaponIds)
		{
			ItemKey itemKey2 = DomainManager.Item.CreateWeapon(context, weaponId, 1);
			_inventory.OfflineAdd(itemKey2, 1);
		}
	}

	private void OfflineAddPresetOrgMemberCombatSkillsInternal(IRandomSource random, sbyte orgGoodness, sbyte teacherBehaviorType, sbyte selfBehaviorType, int ageInfluence, List<PresetOrgMemberCombatSkill> presetSkills, List<GameData.Domains.CombatSkill.CombatSkill> charCombatSkills, List<InventoryCombatSkillBookParams> inventorySkillBooks, HashSet<short> suitableWeaponIds)
	{
		sbyte baseGrade = ((_location.AreaId == 138 && _organizationInfo.OrgTemplateId == 38) ? ((sbyte)(_organizationInfo.Grade / 2)) : _organizationInfo.Grade);
		int i = 0;
		for (int count = presetSkills.Count; i < count; i++)
		{
			PresetOrgMemberCombatSkill presetSkill = presetSkills[i];
			CombatSkillItem presetSkillCfg = Config.CombatSkill.Instance[presetSkill.SkillGroupId];
			IReadOnlyList<CombatSkillItem> group = CombatSkillDomain.GetLearnableCombatSkills(presetSkillCfg.SectId, presetSkillCfg.Type);
			int maxGrade = Math.Clamp(presetSkill.MaxGrade * ageInfluence / 100, 0, group.Count - 1);
			for (int skillGrade = 0; skillGrade <= maxGrade; skillGrade++)
			{
				CombatSkillItem skillConfig = group[skillGrade];
				int gradeDiff = _organizationInfo.Grade - skillGrade;
				var (bookPageTypes, readingState) = GenerateCombatSkillBookReadingInfo(random, teacherBehaviorType, selfBehaviorType, orgGoodness, gradeDiff, ageInfluence, 0);
				charCombatSkills.Add(new GameData.Domains.CombatSkill.CombatSkill(-1, skillConfig.TemplateId, readingState));
				_learnedCombatSkills.Add(skillConfig.TemplateId);
				if (random.CheckPercentProb(11 - skillGrade * 2))
				{
					inventorySkillBooks.Add(new InventoryCombatSkillBookParams(skillConfig.BookId, bookPageTypes));
				}
				short suitableWeaponId = skillConfig.MostFittingWeaponID;
				sbyte grade = ItemDomain.GenerateRandomItemGrade(random, baseGrade);
				if (suitableWeaponId >= 0)
				{
					suitableWeaponIds.Add((short)(suitableWeaponId + grade));
				}
			}
		}
	}

	private static (byte bookPageTypes, ushort readingState) GenerateCombatSkillBookReadingInfo(IRandomSource random, sbyte teacherBehaviorType, sbyte selfBehaviorType, sbyte orgGoodness, int gradeDiff, int ageInfluence = 100, short pageBuff = 0)
	{
		sbyte behaviorType = ((teacherBehaviorType == -1) ? selfBehaviorType : (random.CheckPercentProb(70) ? teacherBehaviorType : selfBehaviorType));
		if (1 == 0)
		{
		}
		sbyte b = orgGoodness switch
		{
			-1 => 30, 
			0 => 50, 
			1 => 70, 
			_ => throw new Exception($"Unsupported goodness {orgGoodness}"), 
		};
		if (1 == 0)
		{
		}
		sbyte directProb = b;
		int readPagesCount = 3 + gradeDiff + random.Next(4) + pageBuff;
		readPagesCount = Math.Clamp(readPagesCount * ageInfluence / 100, 0, 6);
		byte bookPageTypes = GameData.Domains.Item.SkillBook.GenerateCombatPageTypes(random, behaviorType, directProb);
		ushort readingState = GameData.Domains.CombatSkill.CombatSkill.GenerateRandomReadingState(random, bookPageTypes, readPagesCount);
		return (bookPageTypes: bookPageTypes, readingState: readingState);
	}

	private void OfflineCreateEquipmentAndInventoryItems(DataContext context, CharacterItem template, sbyte ageGroup)
	{
		OfflineCreateEquipmentAndInventoryItemsInternal(template, ageGroup, out var equipment, out var inventory);
		OfflineAddEquipmentAndInventoryItems(context, equipment, inventory);
	}

	private void OfflineAddEquipmentAndInventoryItems(DataContext context, PresetEquipmentItem[] equipment, List<PresetInventoryItem> inventory)
	{
		for (int i = 0; i < 17; i++)
		{
			PresetEquipmentItem presetItem = equipment[i];
			_equipment[i] = ((presetItem.TemplateId < 0) ? ItemKey.Invalid : ((i != 4) ? DomainManager.Item.CreateItem(context, presetItem.Type, presetItem.TemplateId) : DomainManager.Item.CreateClothing(context, presetItem.TemplateId, _gender)));
			if (_equipment[i].IsValid() && ItemTemplateHelper.HasCarrierTame(presetItem.Type, presetItem.TemplateId))
			{
				ExtraDomain extraDomain = DomainManager.Extra;
				int maxTamePoint = extraDomain.GetCarrierMaxTamePoint(_equipment[i].Id);
				extraDomain.SetCarrierTamePoint(context, _equipment[i].Id, maxTamePoint);
			}
		}
		ChallengeModeData challengeModeData = DomainManager.World.GetChallengeModeData();
		challengeModeData.ApplyCharacterItemsCreateRate(inventory, context.Random);
		int j = 0;
		for (int count = inventory.Count; j < count; j++)
		{
			PresetInventoryItem presetItem2 = inventory[j];
			if (presetItem2.SpawnChance >= 100 || context.Random.CheckPercentProb(presetItem2.SpawnChance))
			{
				OfflineCreateInventoryOnCharacterCreation(context, presetItem2.Type, presetItem2.TemplateId, presetItem2.Amount);
			}
		}
	}

	private void OfflineCreateEquipmentAndInventoryItems(CreateIntelligentCharacterModification mod, CharacterItem template, sbyte ageGroup)
	{
		OfflineCreateEquipmentAndInventoryItemsInternal(template, ageGroup, out var equipment, out var inventory);
		mod.Equipment = equipment;
		mod.Inventory = inventory;
	}

	private static void OfflineCreateEquipmentAndInventoryItemsInternal(CharacterItem template, sbyte ageGroup, out PresetEquipmentItem[] equipment, out List<PresetInventoryItem> inventory)
	{
		equipment = new PresetEquipmentItem[17];
		for (int i = 0; i < 17; i++)
		{
			equipment[i] = template.PresetEquipment[i];
		}
		if (ageGroup != 2)
		{
			equipment[4] = new PresetEquipmentItem(3, (short)((ageGroup == 1) ? 65 : 64));
		}
		inventory = new List<PresetInventoryItem>(template.PresetInventory);
	}

	private void OfflineAddPresetOrgMemberEquipmentAndInventoryItems(DataContext context, CreateIntelligentCharacterModification mod, OrganizationMemberItem orgMemberConfig, sbyte ageGroup)
	{
		if (ageGroup == 2)
		{
			short clothingTemplateId = OrganizationDomain.GetRandomOrgMemberClothing(context.Random, orgMemberConfig);
			if (mod.Self._location.AreaId == 138 && mod.Self._organizationInfo.OrgTemplateId == 38)
			{
				clothingTemplateId = OrganizationDomain.GetRandomOrgMemberClothing(context.Random, OrganizationDomain.GetOrgMemberConfig(mod.Self._organizationInfo));
			}
			mod.Equipment[4] = new PresetEquipmentItem(3, clothingTemplateId);
		}
		OfflineAddPresetOrgMemberEquipmentsWithProb(context, orgMemberConfig.Equipment, orgMemberConfig.Grade, mod.Inventory);
		OfflineAddPresetOrgMemberInventoryItems(context, orgMemberConfig.Inventory, orgMemberConfig.Grade, mod.Inventory);
	}

	private void OfflineAddRandomEnemyPresetOrgMemberEquipmentAndInventoryItems(DataContext context, RandomEnemyItem randomEnemyCfg, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectAndMembers)
	{
		List<PresetInventoryItem> itemsToBeCreated = new List<PresetInventoryItem>();
		int i = 0;
		for (int count = relatedSectAndMembers.Count; i < count; i++)
		{
			OrganizationMemberItem sectMember = relatedSectAndMembers[i].Member;
			OfflineAddPresetOrgMemberEquipmentsWithProb(context, sectMember.Equipment, randomEnemyCfg.ItemGrade, itemsToBeCreated);
			OfflineAddRandomEnemyPresetOrgMemberInventoryItems(context, sectMember.Inventory, randomEnemyCfg.ItemGrade, itemsToBeCreated);
		}
		bool allowPoisoning = DomainManager.Global.GetLoadedAllArchiveData();
		int j = 0;
		for (int itemsCount = itemsToBeCreated.Count; j < itemsCount; j++)
		{
			PresetInventoryItem presetItem = itemsToBeCreated[j];
			if (allowPoisoning)
			{
				for (int k = 0; k < presetItem.Amount; k++)
				{
					OfflineCreateRandomEnemyInventoryItem(context, randomEnemyCfg, presetItem.Type, presetItem.TemplateId);
				}
			}
			else
			{
				OfflineCreateInventoryOnCharacterCreation(context, presetItem.Type, presetItem.TemplateId, presetItem.Amount);
			}
		}
	}

	private void OfflineCreateRandomEnemyInventoryItem(DataContext context, RandomEnemyItem randomEnemyCfg, sbyte itemType, short itemTemplateId)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType, itemTemplateId);
		if (randomEnemyCfg.PoisonsToAdd != null && ItemTemplateHelper.IsPoisonable(itemKey.ItemType, itemKey.TemplateId) && context.Random.CheckPercentProb(randomEnemyCfg.AddPoisonRate))
		{
			Span<short> span = stackalloc short[6];
			SpanList<short> spanList = span;
			spanList.Clear();
			spanList.AddRange(randomEnemyCfg.PoisonsToAdd);
			spanList.Shuffle(context.Random);
			int poisonCount = context.Random.Next(randomEnemyCfg.MaxAddPoisonCount) + 1;
			if (poisonCount > spanList.Count)
			{
				poisonCount = spanList.Count;
			}
			if (poisonCount > 3)
			{
				poisonCount = 3;
			}
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
			for (int j = 0; j < poisonCount; j++)
			{
				short poisonTemplateId = spanList[j];
				(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetAttachedPoisons(context, itemBase, poisonTemplateId, add: true);
				ItemBase newItem = tuple.item;
				bool hasChange = tuple.keyChanged;
				itemBase = newItem;
			}
			itemKey = itemBase.GetItemKey();
		}
		_inventory.OfflineAdd(itemKey, 1);
	}

	private void OfflineAddPresetOrgMemberEquipmentsWithProb(DataContext context, PresetEquipmentItemWithProb[] items, sbyte itemGrade, List<PresetInventoryItem> itemsToBeCreated)
	{
		int i = 0;
		for (int itemsCount = items.Length; i < itemsCount; i++)
		{
			PresetEquipmentItemWithProb presetItem = items[i];
			if (presetItem.TemplateId >= 0 && context.Random.CheckPercentProb(presetItem.Prob))
			{
				sbyte randomItemGrade = ItemDomain.GenerateRandomItemGrade(context.Random, itemGrade);
				short templateId = (short)(presetItem.TemplateId + randomItemGrade);
				itemsToBeCreated.Add(new PresetInventoryItem(presetItem.Type, templateId, 1, 100));
			}
		}
	}

	private void OfflineAddPresetOrgMemberInventoryItems(DataContext context, List<PresetInventoryItem> items, sbyte itemGrade, List<PresetInventoryItem> itemsToBeCreated)
	{
		IRandomSource random = context.Random;
		int i = 0;
		for (int itemsCount = items.Count; i < itemsCount; i++)
		{
			PresetInventoryItem presetItem = items[i];
			if (random.CheckPercentProb(presetItem.SpawnChance))
			{
				short templateId = ItemDomain.GenerateRandomItemTemplateId(random, presetItem.Type, presetItem.TemplateId, itemGrade);
				int amount = 1 + context.Random.Next(presetItem.Amount);
				itemsToBeCreated.Add(new PresetInventoryItem(presetItem.Type, templateId, amount, 100));
			}
		}
	}

	private void OfflineAddRandomEnemyPresetOrgMemberInventoryItems(DataContext context, List<PresetInventoryItem> items, sbyte itemGrade, List<PresetInventoryItem> itemsToBeCreated)
	{
		int i = 0;
		for (int itemsCount = items.Count; i < itemsCount; i++)
		{
			PresetInventoryItem presetItem = items[i];
			if (context.Random.CheckPercentProb(presetItem.SpawnChance))
			{
				short templateId = ItemDomain.GenerateRandomItemTemplateId(context.Random, presetItem.Type, presetItem.TemplateId, itemGrade);
				int amount = 1 + context.Random.Next(presetItem.Amount);
				itemsToBeCreated.Add(new PresetInventoryItem(presetItem.Type, templateId, amount, 100));
			}
		}
	}

	private void OfflineReplaceProtagonistClothing(DataContext context, short clothingTemplateId)
	{
		ItemKey oriClothingKey = _equipment[4];
		if (oriClothingKey.IsValid())
		{
			DomainManager.Item.RemoveItem(context, oriClothingKey);
		}
		ItemKey newClothingKey = DomainManager.Item.CreateClothing(context, clothingTemplateId, _gender);
		_equipment[4] = newClothingKey;
	}

	private static List<(OrganizationItem Sect, OrganizationMemberItem Member)> GetRelatedSectAndMembers(IRandomSource random, RandomEnemyItem randomEnemy, sbyte grade)
	{
		int candidateSectsCount = randomEnemy.SectIds.Count;
		Span<short> span = stackalloc short[15];
		SpanList<short> relatedSectIds = span;
		relatedSectIds.AddRange(randomEnemy.SectIds);
		if (candidateSectsCount > randomEnemy.SelectSectCount)
		{
			relatedSectIds.Shuffle(random);
			relatedSectIds.RemoveRange(randomEnemy.SelectSectCount, candidateSectsCount - randomEnemy.SelectSectCount);
		}
		List<(OrganizationItem, OrganizationMemberItem)> relatedSectsAndMembers = new List<(OrganizationItem, OrganizationMemberItem)>();
		int i = 0;
		for (int count = relatedSectIds.Count; i < count; i++)
		{
			short sectId = relatedSectIds[i];
			OrganizationItem sect = Config.Organization.Instance[sectId];
			short orgMemberId = sect.Members[grade];
			OrganizationMemberItem member = OrganizationMember.Instance[orgMemberId];
			relatedSectsAndMembers.Add((sect, member));
		}
		return relatedSectsAndMembers;
	}

	private short ChooseGrowingSectMember(IRandomSource random, sbyte orgTemplateId, sbyte growingSectGrade)
	{
		if (orgTemplateId < 0)
		{
			orgTemplateId = _organizationInfo.OrgTemplateId;
		}
		sbyte growingSectOrgTemplateId = -1;
		if (OrganizationDomain.IsSect(orgTemplateId))
		{
			growingSectOrgTemplateId = orgTemplateId;
		}
		else
		{
			sbyte idealSect = GetIdealSect();
			if (idealSect >= 0 && OrganizationDomain.MeetGenderRestriction(idealSect, _gender))
			{
				growingSectOrgTemplateId = idealSect;
			}
		}
		if (growingSectOrgTemplateId < 0)
		{
			growingSectOrgTemplateId = OrganizationDomain.GetRandomSectOrgTemplateId(random, _gender);
		}
		if (growingSectGrade < 0)
		{
			growingSectGrade = _organizationInfo.Grade;
		}
		return OrganizationDomain.GetMemberId(growingSectOrgTemplateId, growingSectGrade);
	}

	private void OfflineInitializeBaseNeiliProportionOfFiveElements()
	{
		sbyte innateFiveElementsType = GetInnateFiveElementsType();
		_baseNeiliProportionOfFiveElements = CustomProtagonistPresetItem.GenerateNeiliProportionByNeiliType(innateFiveElementsType);
	}

	private static int CalcAgeInfluence(IRandomSource random, Character character, OrganizationMemberItem orgMemberConfig)
	{
		short initialAge = OrganizationDomain.GetInitialAge(orgMemberConfig);
		return (character._actualAge < initialAge) ? Math.Clamp(character._actualAge * 100 / initialAge + RedzenHelper.NormalDistribute(random, 0f, 10f), 25, 100) : 100;
	}

	[Obsolete]
	private static int GenerateRandomAttributeValue(IRandomSource random, int adjustPercent)
	{
		float currMean = 40f + 25f * ((float)adjustPercent / 100f);
		return RedzenHelper.NormalDistribute(random, currMean, 10.746457f, 0, 100);
	}

	[Obsolete]
	private unsafe void OfflineGenerateRandomMainAttributes(IRandomSource random, short[] mainAttributesAdjust, bool abnormalOrgAttributes)
	{
		sbyte abnormalProb = (sbyte)(abnormalOrgAttributes ? random.Next(101) : 0);
		for (sbyte i = 0; i < 6; i++)
		{
			int currAdjust = GetCurrAdjust(random, mainAttributesAdjust, i, abnormalProb);
			int currValue = GenerateRandomAttributeValue(random, currAdjust);
			_baseMainAttributes.Items[i] = (short)currValue;
		}
	}

	[Obsolete]
	public void RecreateMainAttributesAndQualificationsByGrowingSect(DataContext context, sbyte growingOrgTemplateId, sbyte growingGrade)
	{
		OfflineRecreateByGrowingSect(context.Random, growingOrgTemplateId, growingGrade);
	}

	[Obsolete]
	private void OfflineCreateMainAttributes(IRandomSource random, ref IntelligentCharacterCreationInfo info, short orgMemberId, sbyte abnormalOrgAttributesProb)
	{
		if (info.MotherCharId >= 0 || info.ActualFatherCharId >= 0)
		{
			OfflineInheritMainAttributes(random, ref info);
		}
		else if (orgMemberId >= 0)
		{
			OfflineGenerateRandomMainAttributes(random, OrganizationDomain.GetMemberMainAttributesAdjust(orgMemberId), random.CheckPercentProb(abnormalOrgAttributesProb));
		}
		else
		{
			OfflineGenerateRandomMainAttributes(random, null, abnormalOrgAttributes: false);
		}
	}

	[Obsolete]
	private unsafe void OfflineInheritMainAttributes(IRandomSource random, ref IntelligentCharacterCreationInfo info)
	{
		if (info.MotherCharId >= 0 && info.ActualFatherCharId >= 0)
		{
			int* pAttrPairs = stackalloc int[6];
			MainAttributes motherAttributes = info.Mother.GetBaseMainAttributes();
			MainAttributes fatherAttributes = info.ActualFather?.GetBaseMainAttributes() ?? info.ActualDeadFather.BaseMainAttributes;
			for (sbyte i = 0; i < 6; i++)
			{
				*(short*)(pAttrPairs + i) = motherAttributes.Items[i];
				((short*)(pAttrPairs + i))[1] = fatherAttributes.Items[i];
			}
			InheritAttributes_SortAttributePairs(pAttrPairs, 6);
			fixed (short* pResult = _baseMainAttributes.Items)
			{
				InheritAttributes_CalcAttributes(random, pAttrPairs, pResult, 6);
			}
			return;
		}
		MainAttributes attributes = info.Mother?.GetBaseMainAttributes() ?? info.ActualFather?.GetBaseMainAttributes() ?? info.ActualDeadFather.BaseMainAttributes;
		for (sbyte i2 = 0; i2 < 6; i2++)
		{
			int value = attributes.Items[i2];
			value += random.Next(21) - 10;
			if (value < 0)
			{
				value = 0;
			}
			_baseMainAttributes.Items[i2] = (short)value;
		}
	}

	[Obsolete]
	private unsafe static void InheritAttributes_SortAttributePairs(int* pAttrPairs, int count)
	{
		short* pAttrL = (short*)pAttrPairs;
		short* pAttrR = (short*)pAttrPairs + 1;
		for (int i = 0; i < count; i++)
		{
			if (pAttrL < pAttrR)
			{
				short tmp = *pAttrL;
				*pAttrL = *pAttrR;
				*pAttrR = tmp;
			}
			pAttrL += 2;
			pAttrR += 2;
		}
	}

	[Obsolete]
	private unsafe static void InheritAttributes_CalcAttributes(IRandomSource random, int* pAttrPairs, short* pResultAttributes, int count)
	{
		int mainRuleRandomValue = random.Next(100);
		short* pAttrBig = (short*)pAttrPairs;
		short* pAttrSmall = (short*)pAttrPairs + 1;
		for (int i = 0; i < count; i++)
		{
			int randomValue = (random.CheckPercentProb(50) ? mainRuleRandomValue : random.Next(100));
			int value = ((randomValue < 20) ? (*pAttrBig + *pAttrSmall / 10) : ((randomValue >= 50) ? ((*pAttrBig + *pAttrSmall) / 2) : (*pAttrBig)));
			value += random.Next(21) - 10;
			if (value < 0)
			{
				value = 0;
			}
			pResultAttributes[i] = (short)value;
			pAttrBig += 2;
			pAttrSmall += 2;
		}
	}

	[Obsolete]
	private void OfflineCreateRandomEnemyMainAttributes(IRandomSource random, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers, sbyte abnormalOrgAttributesProb)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] mainAttributesAdjust;
		if (relatedSectsCount > 1)
		{
			mainAttributesAdjust = new short[6];
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.MainAttributesAdjust;
				for (sbyte j = 0; j < 6; j++)
				{
					mainAttributesAdjust[j] += currAdjust[j];
				}
			}
			for (sbyte i2 = 0; i2 < 6; i2++)
			{
				mainAttributesAdjust[i2] /= relatedSectsCount;
			}
		}
		else
		{
			mainAttributesAdjust = relatedSectsAndMembers[0].Member.MainAttributesAdjust;
		}
		OfflineGenerateRandomMainAttributes(random, mainAttributesAdjust, random.CheckPercentProb(abnormalOrgAttributesProb));
	}

	[Obsolete]
	private unsafe void OfflineCreateProtagonistMainAttributes(IRandomSource random, short orgMemberId)
	{
		short[] mainAttributesAdjust = OrganizationDomain.GetMemberMainAttributesAdjust(orgMemberId);
		for (sbyte i = 0; i < 6; i++)
		{
			int adjust = mainAttributesAdjust[i];
			int baseValue = ((adjust > 0) ? 50 : ((adjust == 0) ? 35 : 20));
			int currValue = baseValue + random.Next(16);
			_baseMainAttributes.Items[i] = (short)currValue;
		}
	}

	[Obsolete]
	private void OfflineCreateLifeSkillsQualifications(IRandomSource random, short orgMemberId, sbyte abnormalOrgAttributesProb, short[] lifeSkillsAdjustBonus)
	{
		if (orgMemberId >= 0)
		{
			OfflineGenerateRandomLifeSkillsQualifications(random, OrganizationDomain.GetMemberLifeSkillsAdjust(orgMemberId), lifeSkillsAdjustBonus, random.CheckPercentProb(abnormalOrgAttributesProb));
		}
		else
		{
			OfflineGenerateRandomLifeSkillsQualifications(random, null, lifeSkillsAdjustBonus, abnormalOrgAttributes: false);
		}
	}

	[Obsolete]
	private unsafe void OfflineGenerateRandomLifeSkillsQualifications(IRandomSource random, short[] lifeSkillsAdjust, short[] lifeSkillsAdjustBonus, bool abnormalOrgAttributes)
	{
		sbyte abnormalProb = (sbyte)(abnormalOrgAttributes ? random.Next(101) : 0);
		for (sbyte i = 0; i < 16; i++)
		{
			int currAdjust = GetCurrAdjust(random, lifeSkillsAdjust, i, abnormalProb);
			if (lifeSkillsAdjustBonus != null)
			{
				currAdjust += lifeSkillsAdjustBonus[i];
			}
			int currValue = GenerateRandomAttributeValue(random, currAdjust);
			_baseLifeSkillQualifications.Items[i] = (short)currValue;
		}
	}

	[Obsolete]
	private void OfflineCreateLifeSkillsQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo info, short orgMemberId, sbyte abnormalOrgAttributesProb)
	{
		if (info.MotherCharId >= 0 || info.ActualFatherCharId >= 0)
		{
			OfflineInheritLifeSkillsQualifications(random, ref info);
		}
		else
		{
			OfflineCreateLifeSkillsQualifications(random, orgMemberId, abnormalOrgAttributesProb, info.LifeSkillsLowerBound);
		}
	}

	[Obsolete]
	private unsafe void OfflineInheritLifeSkillsQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo info)
	{
		if (info.MotherCharId >= 0 && info.ActualFatherCharId >= 0)
		{
			int* pAttrPairs = stackalloc int[16];
			ref LifeSkillShorts motherQualifications = ref info.Mother.GetBaseLifeSkillQualifications();
			Character actualFather = info.ActualFather;
			LifeSkillShorts fatherQualifications = ((actualFather != null) ? actualFather.GetBaseLifeSkillQualifications() : info.ActualDeadFather.BaseLifeSkillQualifications);
			for (sbyte i = 0; i < 16; i++)
			{
				*(short*)(pAttrPairs + i) = motherQualifications.Items[i];
				((short*)(pAttrPairs + i))[1] = fatherQualifications.Items[i];
			}
			InheritAttributes_SortAttributePairs(pAttrPairs, 16);
			fixed (short* pResult = _baseLifeSkillQualifications.Items)
			{
				InheritAttributes_CalcAttributes(random, pAttrPairs, pResult, 16);
			}
			return;
		}
		Character mother = info.Mother;
		LifeSkillShorts obj;
		if (mother == null)
		{
			Character actualFather2 = info.ActualFather;
			obj = ((actualFather2 != null) ? actualFather2.GetBaseLifeSkillQualifications() : info.ActualDeadFather.BaseLifeSkillQualifications);
		}
		else
		{
			obj = mother.GetBaseLifeSkillQualifications();
		}
		LifeSkillShorts qualifications = obj;
		for (sbyte i2 = 0; i2 < 16; i2++)
		{
			int value = qualifications.Items[i2];
			value += random.Next(21) - 10;
			if (value < 0)
			{
				value = 0;
			}
			_baseLifeSkillQualifications.Items[i2] = (short)value;
		}
	}

	[Obsolete]
	private unsafe void OfflineCreateRandomEnemyLifeSkillsQualifications(IRandomSource random, RandomEnemyItem randomEnemy, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers, sbyte abnormalOrgAttributesProb)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] lifeSkillsAdjust;
		if (relatedSectsCount > 1)
		{
			lifeSkillsAdjust = new short[16];
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.LifeSkillsAdjust;
				for (sbyte j = 0; j < 16; j++)
				{
					lifeSkillsAdjust[j] += currAdjust[j];
				}
			}
			for (sbyte i2 = 0; i2 < 16; i2++)
			{
				lifeSkillsAdjust[i2] /= relatedSectsCount;
			}
		}
		else
		{
			lifeSkillsAdjust = relatedSectsAndMembers[0].Member.LifeSkillsAdjust;
		}
		OfflineGenerateRandomLifeSkillsQualifications(random, lifeSkillsAdjust, null, random.CheckPercentProb(abnormalOrgAttributesProb));
		for (sbyte i3 = 0; i3 < 16; i3++)
		{
			int value = _baseLifeSkillQualifications.Items[i3];
			value = value * (100 + randomEnemy.LifeSkillQualificationAdjust) / 100;
			if (value < 0)
			{
				value = 0;
			}
			_baseLifeSkillQualifications.Items[i3] = (short)value;
		}
	}

	[Obsolete]
	private unsafe void OfflineGenerateRandomCombatSkillsQualifications(IRandomSource random, short[] combatSkillsAdjust, short[] combatSkillsAdjustBonus, bool abnormalOrgAttributes)
	{
		sbyte abnormalProb = (sbyte)(abnormalOrgAttributes ? random.Next(101) : 0);
		for (sbyte i = 0; i < 14; i++)
		{
			int currAdjust = GetCurrAdjust(random, combatSkillsAdjust, i, abnormalProb);
			if (combatSkillsAdjustBonus != null)
			{
				currAdjust += combatSkillsAdjustBonus[i];
			}
			int currValue = GenerateRandomAttributeValue(random, currAdjust);
			_baseCombatSkillQualifications.Items[i] = (short)currValue;
		}
	}

	[Obsolete]
	private void OfflineCreateCombatSkillsQualifications(IRandomSource random, short orgMemberId, sbyte abnormalOrgAttributesProb, short[] combatSkillsAdjustBonus)
	{
		if (orgMemberId >= 0)
		{
			OfflineGenerateRandomCombatSkillsQualifications(random, OrganizationDomain.GetMemberCombatSkillsAdjust(orgMemberId), combatSkillsAdjustBonus, random.CheckPercentProb(abnormalOrgAttributesProb));
		}
		else
		{
			OfflineGenerateRandomCombatSkillsQualifications(random, null, combatSkillsAdjustBonus, abnormalOrgAttributes: false);
		}
	}

	[Obsolete]
	private void OfflineCreateCombatSkillsQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo info, short orgMemberId, sbyte abnormalOrgAttributesProb)
	{
		if (info.MotherCharId >= 0 || info.ActualFatherCharId >= 0)
		{
			OfflineInheritCombatSkillsQualifications(random, ref info);
		}
		else
		{
			OfflineCreateCombatSkillsQualifications(random, orgMemberId, abnormalOrgAttributesProb, info.CombatSkillsLowerBound);
		}
	}

	[Obsolete]
	private unsafe void OfflineInheritCombatSkillsQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo info)
	{
		if (info.MotherCharId >= 0 && info.ActualFatherCharId >= 0)
		{
			int* pAttrPairs = stackalloc int[14];
			ref CombatSkillShorts motherQualifications = ref info.Mother.GetBaseCombatSkillQualifications();
			Character actualFather = info.ActualFather;
			CombatSkillShorts fatherQualifications = ((actualFather != null) ? actualFather.GetBaseCombatSkillQualifications() : info.ActualDeadFather.BaseCombatSkillQualifications);
			for (sbyte i = 0; i < 14; i++)
			{
				*(short*)(pAttrPairs + i) = motherQualifications.Items[i];
				((short*)(pAttrPairs + i))[1] = fatherQualifications.Items[i];
			}
			InheritAttributes_SortAttributePairs(pAttrPairs, 14);
			fixed (short* pResult = _baseCombatSkillQualifications.Items)
			{
				InheritAttributes_CalcAttributes(random, pAttrPairs, pResult, 14);
			}
			return;
		}
		Character mother = info.Mother;
		CombatSkillShorts obj;
		if (mother == null)
		{
			Character actualFather2 = info.ActualFather;
			obj = ((actualFather2 != null) ? actualFather2.GetBaseCombatSkillQualifications() : info.ActualDeadFather.BaseCombatSkillQualifications);
		}
		else
		{
			obj = mother.GetBaseCombatSkillQualifications();
		}
		CombatSkillShorts qualifications = obj;
		for (sbyte i2 = 0; i2 < 14; i2++)
		{
			int value = qualifications.Items[i2];
			value += random.Next(21) - 10;
			if (value < 0)
			{
				value = 0;
			}
			_baseCombatSkillQualifications.Items[i2] = (short)value;
		}
	}

	[Obsolete]
	private unsafe void OfflineCreateRandomEnemyCombatSkillsQualifications(IRandomSource random, RandomEnemyItem randomEnemy, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers, sbyte abnormalOrgAttributesProb)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] combatSkillsAdjust;
		if (relatedSectsCount > 1)
		{
			combatSkillsAdjust = new short[14];
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.CombatSkillsAdjust;
				for (int j = 0; j < 14; j++)
				{
					combatSkillsAdjust[j] += currAdjust[j];
				}
			}
			for (int k = 0; k < 14; k++)
			{
				combatSkillsAdjust[k] /= relatedSectsCount;
			}
		}
		else
		{
			combatSkillsAdjust = relatedSectsAndMembers[0].Member.CombatSkillsAdjust;
		}
		OfflineGenerateRandomCombatSkillsQualifications(random, combatSkillsAdjust, null, random.CheckPercentProb(abnormalOrgAttributesProb));
		for (sbyte i2 = 0; i2 < 14; i2++)
		{
			int value = _baseCombatSkillQualifications.Items[i2];
			value = value * (100 + randomEnemy.CombatSkillQualificationAdjust) / 100;
			if (value < 0)
			{
				value = 0;
			}
			_baseCombatSkillQualifications.Items[i2] = (short)value;
		}
	}

	[Obsolete("replaced with GameData.Domains.Character.Character.OfflineAddRandomEnemyOrgMemberCombatSkills")]
	private void OfflineAddRandomEnemyPresetOrgMemberCombatSkills(DataContext context, List<(OrganizationItem Org, OrganizationMemberItem Member)> relatedSectAndMembers, List<GameData.Domains.CombatSkill.CombatSkill> charCombatSkills)
	{
		sbyte selfBehaviorType = BehaviorType.GetBehaviorType(_baseMorality);
		List<InventoryCombatSkillBookParams> skillBooks = new List<InventoryCombatSkillBookParams>();
		HashSet<short> suitableWeaponIds = new HashSet<short>();
		int i = 0;
		for (int count = relatedSectAndMembers.Count; i < count; i++)
		{
			OrganizationItem org = relatedSectAndMembers[i].Org;
			OrganizationMemberItem orgMember = relatedSectAndMembers[i].Member;
			sbyte teacherBehaviorType = (sbyte)((org.MainMorality == short.MinValue) ? (-1) : BehaviorType.GetBehaviorType(org.MainMorality));
			OfflineAddRandomEnemyPresetOrgMemberCombatSkillsInternal(context.Random, org.Goodness, teacherBehaviorType, selfBehaviorType, orgMember.CombatSkills, charCombatSkills, skillBooks, suitableWeaponIds);
		}
		OfflineAddSkillBooksAndWeapons(context, skillBooks, suitableWeaponIds);
	}

	[Obsolete("replaced with GameData.Domains.Character.Character.OfflineAddRandomEnemyOrgMemberCombatSkills")]
	private void OfflineAddRandomEnemyPresetOrgMemberCombatSkillsInternal(IRandomSource random, sbyte orgGoodness, sbyte teacherBehaviorType, sbyte selfBehaviorType, List<PresetOrgMemberCombatSkill> presetSkills, List<GameData.Domains.CombatSkill.CombatSkill> charCombatSkills, List<InventoryCombatSkillBookParams> skillBooks, HashSet<short> suitableWeaponIds)
	{
		byte difficulty = DomainManager.World.GetEnemyPracticeLevel();
		short pageBuff = WorldCreation.Instance[(byte)11].InfluenceFactors[difficulty];
		short practiceBuff = WorldCreation.Instance[(byte)11].SecondaryInfluenceFactors[difficulty];
		int i = 0;
		for (int count = presetSkills.Count; i < count; i++)
		{
			PresetOrgMemberCombatSkill presetSkill = presetSkills[i];
			for (int skillGrade = 0; skillGrade <= presetSkill.MaxGrade; skillGrade++)
			{
				if (skillGrade == presetSkill.MaxGrade || random.CheckPercentProb(50))
				{
					short templateId = (short)(presetSkill.SkillGroupId + skillGrade);
					int gradeDiff = _organizationInfo.Grade - skillGrade;
					var (bookPageTypes, readingState) = GenerateCombatSkillBookReadingInfo(random, teacherBehaviorType, selfBehaviorType, orgGoodness, gradeDiff, 100, pageBuff);
					charCombatSkills.Add(new GameData.Domains.CombatSkill.CombatSkill(-1, templateId, readingState));
					_learnedCombatSkills.Add(templateId);
					CombatSkillItem skillConfig = Config.CombatSkill.Instance[templateId];
					if (random.CheckPercentProb(11 - skillGrade * 2))
					{
						skillBooks.Add(new InventoryCombatSkillBookParams(skillConfig.BookId, bookPageTypes));
					}
					short suitableWeaponId = skillConfig.MostFittingWeaponID;
					sbyte grade = ItemDomain.GenerateRandomItemGrade(random, _organizationInfo.Grade);
					if (suitableWeaponId >= 0)
					{
						suitableWeaponIds.Add((short)(suitableWeaponId + grade));
					}
				}
			}
		}
	}

	[Obsolete]
	private void OfflineCreateFeatures(DataContext context, Character mother, PregnantState pregnantState, Character father, DeadCharacter deadFather, bool randomFeaturesAtCreating, short potentialFeaturesAge = -1, int destinyType = -1)
	{
		IRandomSource random = context.Random;
		Dictionary<short, short> featureGroup2Id = new Dictionary<short, short>(16);
		GenerateFixedFeatures(featureGroup2Id);
		if (destinyType >= 0)
		{
			AddFeature(featureGroup2Id, DestinyType.Instance[destinyType].Feature);
		}
		if (randomFeaturesAtCreating)
		{
			GenerateGeneticFeatures(random, featureGroup2Id, mother, pregnantState, father, deadFather);
			AddFeature(featureGroup2Id, CharacterDomain.GetBirthdayFeatureId(_birthMonth));
			if (_currAge >= 1 && random.CheckPercentProb(50))
			{
				AddFeature(featureGroup2Id, CharacterDomain.GenerateOneYearOldCatchFeature(random));
			}
			GenerateRandomBasicFeatures(context, featureGroup2Id);
		}
		OfflineApplyFeatureIds(featureGroup2Id, potentialFeaturesAge);
	}

	[Obsolete]
	private void OfflineCreateCloseFriendRandomFeatures(DataContext context)
	{
		IRandomSource random = context.Random;
		Dictionary<short, short> featureGroup2Id = new Dictionary<short, short>(16);
		GenerateFixedFeatures(featureGroup2Id);
		AddFeature(featureGroup2Id, CharacterDomain.GetBirthdayFeatureId(_birthMonth));
		if (random.CheckPercentProb(50))
		{
			AddFeature(featureGroup2Id, CharacterDomain.GenerateOneYearOldCatchFeature(random));
		}
		AddFeature(featureGroup2Id, 164);
		GenerateRandomBasicFeatures(context, featureGroup2Id, isProtagonist: true, allGoodBasicFeatures: true);
		OfflineApplyFeatureIds(featureGroup2Id, -1);
	}

	[Obsolete]
	private static void AddFeature(Dictionary<short, short> featureGroup2Id, short featureId)
	{
		short groupId = CharacterFeature.Instance[featureId].MutexGroupId;
		featureGroup2Id.TryAdd(groupId, featureId);
	}

	[Obsolete]
	private static void ApplyFeatureGroup(Dictionary<short, short> featureGroup2Id, List<short> featureIds, short groupId)
	{
		if (featureGroup2Id.TryGetValue(groupId, out var featureId))
		{
			featureIds.Add(featureId);
			featureGroup2Id.Remove(groupId);
		}
	}

	[Obsolete]
	private void OfflineApplyFeatureIds(Dictionary<short, short> featureGroup2Id, short potentialFeaturesAge = -1)
	{
		_featureIds.Clear();
		_potentialFeatureIds.Clear();
		ApplyFeatureGroup(featureGroup2Id, _featureIds, 209);
		ApplyFeatureGroup(featureGroup2Id, _featureIds, 196);
		ApplyFeatureGroup(featureGroup2Id, _featureIds, 184);
		ApplyFeatureGroup(featureGroup2Id, _featureIds, 172);
		foreach (KeyValuePair<short, short> item in featureGroup2Id)
		{
			short featureId = item.Value;
			if (potentialFeaturesAge >= 0 && CharacterFeature.Instance[featureId].Mergeable)
			{
				_potentialFeatureIds.Add(featureId);
			}
			else
			{
				_featureIds.Add(featureId);
			}
		}
		if (potentialFeaturesAge >= 0)
		{
			int affectedFeaturesCount = _potentialFeatureIds.Count * potentialFeaturesAge / 16;
			for (int i = 0; i < affectedFeaturesCount; i++)
			{
				_featureIds.Add(_potentialFeatureIds[i]);
			}
		}
	}

	[Obsolete]
	private void GenerateFixedFeatures(Dictionary<short, short> featureGroup2Id)
	{
		short virginityFeatureId = 196;
		short xiangshuStateFeatureId = 209;
		int featureIdsCount = _featureIds.Count;
		for (int i = 0; i < featureIdsCount; i++)
		{
			short featureId = _featureIds[i];
			switch (CharacterFeature.Instance[featureId].MutexGroupId)
			{
			case 196:
				virginityFeatureId = featureId;
				break;
			case 209:
				xiangshuStateFeatureId = featureId;
				break;
			}
		}
		AddFeature(featureGroup2Id, virginityFeatureId);
		AddFeature(featureGroup2Id, xiangshuStateFeatureId);
		for (int j = 0; j < featureIdsCount; j++)
		{
			AddFeature(featureGroup2Id, _featureIds[j]);
		}
	}

	[Obsolete]
	private void GenerateGeneticFeatures(IRandomSource random, Dictionary<short, short> featureGroup2Id, Character mother, PregnantState pregnantState, Character father, DeadCharacter deadFather)
	{
		if (mother == null && father == null && deadFather == null)
		{
			return;
		}
		List<short> motherFeatureIds = null;
		List<short> fatherFeatureIds = null;
		if (pregnantState != null)
		{
			motherFeatureIds = pregnantState.MotherFeatureIds;
			fatherFeatureIds = pregnantState.FatherFeatureIds;
		}
		else
		{
			if (mother != null)
			{
				motherFeatureIds = mother.GetFeatureIds();
			}
			if (father != null)
			{
				fatherFeatureIds = father.GetFeatureIds();
			}
			else if (deadFather != null)
			{
				fatherFeatureIds = deadFather.FeatureIds;
			}
		}
		Dictionary<short, (short, short)> mergeableFeaturePairs = new Dictionary<short, (short, short)>();
		if (fatherFeatureIds != null)
		{
			int fatherFeatureIdsCount = fatherFeatureIds.Count;
			for (int i = 0; i < fatherFeatureIdsCount; i++)
			{
				short featureId = fatherFeatureIds[i];
				CharacterFeatureItem template = CharacterFeature.Instance[featureId];
				short groupId = template.MutexGroupId;
				sbyte geneticProb = template.GeneticProb;
				if (template.Mergeable)
				{
					mergeableFeaturePairs[groupId] = (-1, featureId);
				}
				else if (geneticProb > 0 && !featureGroup2Id.ContainsKey(groupId) && random.CheckPercentProb(geneticProb))
				{
					featureGroup2Id.Add(groupId, featureId);
				}
			}
		}
		if (motherFeatureIds != null)
		{
			int motherFeatureIdsCount = motherFeatureIds.Count;
			for (int j = 0; j < motherFeatureIdsCount; j++)
			{
				short featureId2 = motherFeatureIds[j];
				CharacterFeatureItem template2 = CharacterFeature.Instance[featureId2];
				short groupId2 = template2.MutexGroupId;
				sbyte geneticProb2 = template2.GeneticProb;
				if (template2.Mergeable)
				{
					if (mergeableFeaturePairs.TryGetValue(groupId2, out var pair))
					{
						mergeableFeaturePairs[groupId2] = (featureId2, pair.Item2);
					}
				}
				else if (geneticProb2 > 0 && !featureGroup2Id.ContainsKey(groupId2) && random.CheckPercentProb(geneticProb2))
				{
					featureGroup2Id.Add(groupId2, featureId2);
				}
			}
		}
		foreach (KeyValuePair<short, (short, short)> entry in mergeableFeaturePairs)
		{
			short groupId3 = entry.Key;
			var (motherFeatureId, fatherFeatureId) = entry.Value;
			if (motherFeatureId < 0 || fatherFeatureId < 0 || featureGroup2Id.ContainsKey(groupId3))
			{
				continue;
			}
			sbyte motherLevel = CharacterFeature.Instance[motherFeatureId].Level;
			sbyte fatherLevel = CharacterFeature.Instance[fatherFeatureId].Level;
			sbyte mergedLevel = (sbyte)((motherLevel + fatherLevel) / 2);
			if (motherLevel > 0 && fatherLevel > 0)
			{
				int upgradeProb = (3 - mergedLevel) * 40;
				if (random.CheckPercentProb(upgradeProb))
				{
					mergedLevel++;
				}
			}
			else if (motherLevel < 0 && fatherLevel < 0)
			{
				int downgradeProb = (3 + mergedLevel) * 40;
				if (random.CheckPercentProb(downgradeProb))
				{
					mergedLevel--;
				}
			}
			if (mergedLevel != 0)
			{
				short mergedFeatureId = CharacterDomain.GetMergeableFeatureIdByLevel(groupId3, mergedLevel);
				featureGroup2Id.Add(groupId3, mergedFeatureId);
			}
		}
	}

	[Obsolete]
	private void GenerateRandomBasicFeatures(DataContext context, Dictionary<short, short> featureGroup2Id, bool isProtagonist = false, bool allGoodBasicFeatures = false)
	{
		IRandomSource random = context.Random;
		int basicFeaturesCount = (allGoodBasicFeatures ? 5 : GenerateRandomBasicFeaturesCount(context.Random));
		foreach (KeyValuePair<short, short> item in featureGroup2Id)
		{
			short featureId = item.Value;
			if (CharacterFeature.Instance[featureId].Basic)
			{
				basicFeaturesCount--;
			}
		}
		if (basicFeaturesCount <= 0)
		{
			return;
		}
		int goodFeaturesPotential = random.Next(101);
		for (int i = 0; i < basicFeaturesCount; i++)
		{
			if (allGoodBasicFeatures || random.CheckPercentProb(goodFeaturesPotential))
			{
				var (groupId, featureId2) = CharacterDomain.GetRandomBasicFeature(random, isProtagonist, _gender, isPositive: true, featureGroup2Id);
				if (featureId2 >= 0)
				{
					featureGroup2Id.Add(groupId, featureId2);
					goodFeaturesPotential -= 20;
				}
			}
			else
			{
				var (groupId2, featureId3) = CharacterDomain.GetRandomBasicFeature(random, isProtagonist, _gender, isPositive: false, featureGroup2Id);
				if (featureId3 >= 0)
				{
					featureGroup2Id.Add(groupId2, featureId3);
					goodFeaturesPotential += 20;
				}
			}
		}
	}

	[Obsolete]
	private static int GenerateRandomBasicFeaturesCount(IRandomSource random)
	{
		return RedzenHelper.SkewDistribute(random, 4f, 0.333f, 3f, 3, 7);
	}

	[Obsolete("Use GameData.Domains.Organization.OrganizationDomain.GetRandomOrgMemberClothing instead.")]
	private static short GetOrgClothing(IRandomSource random, OrganizationMemberItem orgMemberConfig)
	{
		return OrganizationDomain.GetRandomOrgMemberClothing(random, orgMemberConfig);
	}

	private ProtagonistFeatureRelatedStatus OfflineApplyProtagonistFeaturesAndGenome(DataContext context, ProtagonistCreationInfo info, List<GameData.Domains.CombatSkill.CombatSkill> combatSkills)
	{
		ProtagonistFeatureRelatedStatus status = new ProtagonistFeatureRelatedStatus(combatSkills);
		Dictionary<short, DataList<TemplateKey>> protagonistCustomItems = info.ProtagonistCustomItems;
		if (protagonistCustomItems != null && protagonistCustomItems.Count > 0)
		{
			foreach (KeyValuePair<short, DataList<TemplateKey>> protagonistCustomItem in info.ProtagonistCustomItems)
			{
				protagonistCustomItem.Deconstruct(out var key, out var value);
				short featureId = key;
				DataList<TemplateKey> customItems = value;
				if (customItems == null || customItems.Count <= 0)
				{
					continue;
				}
				ProtagonistFeatureRelatedStatus protagonistFeatureRelatedStatus = status;
				if (protagonistFeatureRelatedStatus.CustomItems == null)
				{
					protagonistFeatureRelatedStatus.CustomItems = new Dictionary<short, List<ItemKey>>();
				}
				List<ItemKey> generatedItems = status.CustomItems.GetOrNew(featureId);
				foreach (TemplateKey item in customItems)
				{
					item.Deconstruct(out var itemType, out key);
					sbyte itemType2 = itemType;
					short templateId = key;
					ItemKey itemKey = DomainManager.Item.CreateItem(context, itemType2, templateId);
					_inventory.OfflineAdd(itemKey, 1);
					generatedItems.Add(itemKey);
				}
			}
		}
		List<short> protagonistFeatureIds = info.ProtagonistFeatureIds;
		if (protagonistFeatureIds != null && protagonistFeatureIds.Count > 0)
		{
			int i = 0;
			for (int count = info.ProtagonistFeatureIds.Count; i < count; i++)
			{
				short featureId2 = info.ProtagonistFeatureIds[i];
				OfflineApplyProtagonistFeature(context, featureId2, status);
			}
		}
		List<short> inscribedFeatureIds = ((info.CustomPreset != null) ? info.CustomPreset.SelectedFeatures : info.InscribedChar?.FeatureIds);
		OfflineCreateProtagonistRandomFeatures(context, inscribedFeatureIds, status.AddFeatureLongevity);
		Tester.Assert(!IsCompletelyInfected());
		Genome.CreateRandom(context.Random, ref _genome);
		return status;
	}

	private unsafe void OfflineApplyProtagonistFeature(DataContext context, short protagonistFeatureId, ProtagonistFeatureRelatedStatus status)
	{
		switch (protagonistFeatureId)
		{
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
			break;
		case 12:
			status.CreateCloseFriend = true;
			break;
		case 13:
			break;
		case 14:
			OfflineApplyProtagonistFeature_PoisonResists();
			break;
		case 15:
			status.AddFeatureLongevity = true;
			break;
		case 16:
			break;
		case 17:
		{
			ref int reference = ref _resources.Items[6];
			reference += 60000;
			break;
		}
		case 18:
			OfflineApplyProtagonistFeature_Wines(context);
			break;
		case 19:
			OfflineApplyProtagonistFeature_Teas(context);
			break;
		case 20:
			OfflineApplyProtagonistFeature_Clothing(context);
			break;
		case 21:
			OfflineApplyProtagonistFeature_Rope(context);
			break;
		case 22:
			OfflineApplyProtagonistFeature_CricketJar(context);
			break;
		case 23:
			break;
		case 24:
			OfflineApplyProtagonistFeature_Horse(context);
			break;
		case 25:
		case 26:
			break;
		case 27:
			OfflineApplyProtagonistFeature_Medicines(context);
			break;
		case 28:
			OfflineApplyProtagonistFeature_SealOfMerchant(context);
			break;
		case 29:
			OfflineApplyProtagonistFeature_Fruit(context);
			break;
		case 30:
			OfflineApplyProtagonistFeature_Accessory(context, status);
			break;
		case 31:
			OfflineApplyProtagonistFeature_Construction(context);
			break;
		case 32:
			OfflineApplyProtagonistFeature_Literature(context, status);
			break;
		case 33:
			OfflineApplyProtagonistFeature_Religion(context, status);
			break;
		case 34:
			OfflineApplyProtagonistFeature_WitchDoctor(context, status);
			break;
		case 35:
			OfflineApplyProtagonistFeature_Artisan(context, status);
			break;
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
			break;
		case 47:
			OfflineApplyProtagonistFeature_SkillBooks(context);
			break;
		default:
			throw new Exception($"Unsupported ProtagonistFeatureId: {protagonistFeatureId}");
		}
	}

	private void OfflineApplyProtagonistFeature_PoisonResists()
	{
		_currNeili += 810;
		_extraNeili += 810;
	}

	private void OfflineApplyProtagonistFeature_Clothing(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateClothing(context, 95, _gender);
		GameData.Domains.Item.Clothing clothing = DomainManager.Item.GetElement_Clothing(itemKey.Id);
		clothing.SetEquipmentEffectId(66, context);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateClothing(context, 96, _gender);
		clothing = DomainManager.Item.GetElement_Clothing(itemKey.Id);
		clothing.SetEquipmentEffectId(66, context);
		_inventory.OfflineAdd(itemKey, 1);
	}

	private void OfflineApplyProtagonistFeature_Rope(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateMisc(context, 88);
		_inventory.OfflineAdd(itemKey, 3);
	}

	private void OfflineApplyProtagonistFeature_Wines(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, 9, 6);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 9, 5);
		_inventory.OfflineAdd(itemKey, 2);
		itemKey = DomainManager.Item.CreateItem(context, 9, 15);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 9, 14);
		_inventory.OfflineAdd(itemKey, 2);
	}

	private void OfflineApplyProtagonistFeature_Teas(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, 9, 24);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 9, 23);
		_inventory.OfflineAdd(itemKey, 2);
		itemKey = DomainManager.Item.CreateItem(context, 9, 33);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 9, 32);
		_inventory.OfflineAdd(itemKey, 2);
	}

	private void OfflineApplyProtagonistFeature_Horse(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateCarrier(context, 24);
		_inventory.OfflineAdd(itemKey, 1);
	}

	private void OfflineApplyProtagonistFeature_CricketJar(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateMisc(context, 97);
		_inventory.OfflineAdd(itemKey, 1);
		DomainManager.Taiwu.SetCricketLuckPoint(100, context);
	}

	private void OfflineApplyProtagonistFeature_Medicines(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, 8, 64);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 8, 63);
		_inventory.OfflineAdd(itemKey, 2);
		itemKey = DomainManager.Item.CreateItem(context, 8, 76);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 8, 75);
		_inventory.OfflineAdd(itemKey, 2);
		itemKey = DomainManager.Item.CreateItem(context, 8, 92);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 8, 91);
		_inventory.OfflineAdd(itemKey, 2);
		itemKey = DomainManager.Item.CreateItem(context, 8, 104);
		_inventory.OfflineAdd(itemKey, 1);
		itemKey = DomainManager.Item.CreateItem(context, 8, 103);
		_inventory.OfflineAdd(itemKey, 2);
	}

	private void OfflineApplyProtagonistFeature_SealOfMerchant(DataContext context)
	{
		for (int i = 0; i < 3; i++)
		{
			ItemKey itemKey = DomainManager.Item.CreateMisc(context, 380);
			_inventory.OfflineAdd(itemKey, 1);
		}
	}

	private void OfflineApplyProtagonistFeature_Fruit(DataContext context)
	{
		ItemKey itemKey = DomainManager.Item.CreateFood(context, 8);
		_inventory.OfflineAdd(itemKey, 9);
	}

	private void OfflineApplyProtagonistFeature_Accessory(DataContext context, ProtagonistFeatureRelatedStatus status)
	{
		Dictionary<short, List<ItemKey>> items = status.CustomItems;
		if (items == null || items.Count <= 0 || !items.TryGetValue(30, out var keys))
		{
			return;
		}
		foreach (ItemKey key in keys)
		{
			GameData.Domains.Item.Accessory accessory = DomainManager.Item.GetElement_Accessories(key.Id);
			accessory.SetEquipmentEffectId(67, context);
		}
	}

	private static void OfflineApplyProtagonistFeature_Construction(DataContext context)
	{
		DomainManager.Taiwu.SetProsperousConstruction(value: true, context);
		DomainManager.Building.ApplyProsperousConstruction(context);
	}

	private void OfflineApplyProtagonistFeature_Literature(DataContext context, ProtagonistFeatureRelatedStatus status)
	{
		sbyte[] lifeSkillTypes = new sbyte[4] { 0, 1, 2, 3 };
		OfflineBuffLifeSkills(context, lifeSkillTypes, status);
	}

	private void OfflineApplyProtagonistFeature_Religion(DataContext context, ProtagonistFeatureRelatedStatus status)
	{
		sbyte[] lifeSkillTypes = new sbyte[4] { 13, 12, 5, 14 };
		OfflineBuffLifeSkills(context, lifeSkillTypes, status);
	}

	private void OfflineApplyProtagonistFeature_WitchDoctor(DataContext context, ProtagonistFeatureRelatedStatus status)
	{
		sbyte[] lifeSkillTypes = new sbyte[4] { 8, 9, 4, 15 };
		OfflineBuffLifeSkills(context, lifeSkillTypes, status);
	}

	private void OfflineApplyProtagonistFeature_Artisan(DataContext context, ProtagonistFeatureRelatedStatus status)
	{
		sbyte[] lifeSkillTypes = new sbyte[4] { 6, 7, 11, 10 };
		OfflineBuffLifeSkills(context, lifeSkillTypes, status);
	}

	private void OfflineBuffLifeSkills(DataContext context, IReadOnlyList<sbyte> lifeSkillTypes, ProtagonistFeatureRelatedStatus status)
	{
		for (int i = 0; i < lifeSkillTypes.Count; i++)
		{
			sbyte lifeSkillType = lifeSkillTypes[i];
			for (int grade = 0; grade <= 2; grade++)
			{
				foreach (SkillBookItem config in (IEnumerable<SkillBookItem>)Config.SkillBook.Instance)
				{
					if (config.LifeSkillType != lifeSkillType || config.Grade != grade)
					{
						continue;
					}
					ItemKey itemKey = DomainManager.Item.CreateSkillBook(context, config.TemplateId, 5, -1, -1, 50);
					_inventory.OfflineAdd(itemKey, 1);
					GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
					if (status.LifeSkillBooks == null)
					{
						status.LifeSkillBooks = new List<GameData.Domains.Item.SkillBook>();
					}
					status.LifeSkillBooks.Add(skillBook);
					break;
				}
			}
		}
	}

	private void OfflineApplyProtagonistFeature_SkillBooks(DataContext context)
	{
		MapBlockData rootBlock = null;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(135);
		Span<MapBlockData> span = areaBlocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.GetConfig().SubType == EMapBlockSubType.Zhulu)
			{
				rootBlock = block;
				break;
			}
		}
		if (rootBlock == null)
		{
			return;
		}
		ByteCoordinate rootPos = rootBlock.GetBlockPos();
		List<MapBlockData> normal = ObjectPool<List<MapBlockData>>.Instance.Get();
		List<MapBlockData> prefer = ObjectPool<List<MapBlockData>>.Instance.Get();
		Span<MapBlockData> span2 = areaBlocks;
		for (int j = 0; j < span2.Length; j++)
		{
			MapBlockData block2 = span2[j];
			if (block2.GetManhattanDistanceToPos(rootPos.X, rootPos.Y) == 2 && block2.IsPassable())
			{
				normal.Add(block2);
			}
		}
		foreach (MapBlockData block3 in normal)
		{
			if (block3.GetConfig().SubType != EMapBlockSubType.DarkPool)
			{
				prefer.Add(block3);
			}
		}
		if (normal.Count > 0)
		{
			MapBlockData block4 = ((prefer.Count > 0) ? prefer.GetRandom(context.Random) : normal.GetRandom(context.Random));
			Location location = block4.GetLocation();
			DomainManager.Adventure.GenerateAny(context, 940661293, location)?.CallCharacters(context);
			block4.SetVisible(visible: true, context);
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(normal);
		ObjectPool<List<MapBlockData>>.Instance.Return(prefer);
	}

	ValueInfo IValueSelector.SelectValue(Evaluator evaluator, string identifier)
	{
		if (1 == 0)
		{
		}
		ValueInfo result = ((!(identifier == "MapBlock")) ? ValueInfo.Void : evaluator.PushEvaluationResult(DomainManager.Map.GetBlock(GetValidLocation())));
		if (1 == 0)
		{
		}
		return result;
	}
}

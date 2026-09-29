using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Config;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Building;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.Ai;

public class Equipping
{
	private class ScoreFormulas
	{
		public readonly AdvancingMonthFormulaItem EquippingScoreCurrSect = AdvancingMonthFormula.DefValue.EquippingScoreCurrSect;

		public readonly AdvancingMonthFormulaItem EquippingScoreIdealSect = AdvancingMonthFormula.DefValue.EquippingScoreIdealSect;

		public readonly AdvancingMonthFormulaItem EquippingScoreNotCounter = AdvancingMonthFormula.DefValue.EquippingScoreNotCounter;

		public readonly AdvancingMonthFormulaItem EquippingScoreGrade = AdvancingMonthFormula.DefValue.EquippingScoreGrade;

		public readonly AdvancingMonthFormulaItem EquippingScoreSkillPower = AdvancingMonthFormula.DefValue.EquippingScoreSkillPower;

		public readonly int EquippingScoreBreakout = AdvancingMonthFormula.DefValue.EquippingScoreBreakout.Calculate();

		public readonly int EquippingScoreLegendaryBook = AdvancingMonthFormula.DefValue.EquippingScoreLegendaryBook.Calculate();

		public readonly AdvancingMonthFormulaItem LoopingScoreGrade = AdvancingMonthFormula.DefValue.LoopingScoreGrade;

		public readonly int LoopingScorePotentialNeili = AdvancingMonthFormula.DefValue.LoopingScorePotentialNeili.Calculate();

		public readonly int LoopingScorePotentialExtraAllocation = AdvancingMonthFormula.DefValue.LoopingScorePotentialExtraAllocation.Calculate();

		public readonly int LoopingScoreCurrSectNotCounter = AdvancingMonthFormula.DefValue.LoopingScoreCurrSectNotCounter.Calculate();

		public readonly int LoopingScoreCurrSectDestType = AdvancingMonthFormula.DefValue.LoopingScoreCurrSectDestType.Calculate();

		public readonly int LoopingScoreCurrSectTransferCounter = AdvancingMonthFormula.DefValue.LoopingScoreCurrSectTransferCounter.Calculate();

		public readonly int LoopingScoreIdealSectNotCounter = AdvancingMonthFormula.DefValue.LoopingScoreIdealSectNotCounter.Calculate();

		public readonly int LoopingScoreIdealSectDestType = AdvancingMonthFormula.DefValue.LoopingScoreIdealSectDestType.Calculate();

		public readonly int LoopingScoreIdealSectTransferCounter = AdvancingMonthFormula.DefValue.LoopingScoreIdealSectTransferCounter.Calculate();

		public readonly AdvancingMonthFormulaItem ReadingScoreCurrSectAdjust = AdvancingMonthFormula.DefValue.ReadingScoreCurrSectAdjust;

		public readonly AdvancingMonthFormulaItem ReadingScoreIdealSectAdjust = AdvancingMonthFormula.DefValue.ReadingScoreIdealSectAdjust;

		public readonly AdvancingMonthFormulaItem ReadingScoreQualification = AdvancingMonthFormula.DefValue.ReadingScoreQualification;

		public readonly AdvancingMonthFormulaItem ReadingScoreCompleteState = AdvancingMonthFormula.DefValue.ReadingScoreCompleteState;

		public readonly int ReadingScorePersonalNeed = AdvancingMonthFormula.DefValue.ReadingScorePersonalNeed.Calculate();

		public readonly int ReadingScoreBuildingRequiredType = AdvancingMonthFormula.DefValue.ReadingScoreBuildingRequiredType.Calculate();
	}

	public ref struct EquipCombatSkillContext
	{
		public bool IsTaiwu;

		public bool IsTaiwuGroup;

		public ItemKey[] Equipments;

		public sbyte SlotCostTemplateAdjust;

		public Personalities Personalities;

		public sbyte NeiliType;

		public sbyte OrgTemplateId;

		public sbyte IdealSectId;

		public List<sbyte> OwnedLegendaryBookTypes;

		public Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> CharacterCombatSkills;

		public unsafe sbyte* SlotTotalCounts;

		public CombatSkillEquipment EquippedSkills;
	}

	private class GradeComparer : IComparer<(CombatSkillItem skillCfg, int index)>
	{
		public int Compare((CombatSkillItem skillCfg, int index) x, (CombatSkillItem skillCfg, int index) y)
		{
			return x.skillCfg.Grade - y.skillCfg.Grade;
		}
	}

	public struct BreakoutCombatSkillContext(IRandomSource random, Character character)
	{
		public IRandomSource Random = random;

		public Character Character = character;

		public CombatSkillShorts Qualifications = character.GetCombatSkillQualifications();

		public bool IsCreatedWithFixedTemplate = character.GetCreatingType() != 1;

		public sbyte BehaviorType = character.GetBehaviorType();

		public int CharExp = character.GetExp();

		public int ExpPerMonth = character.GetExpPerMonth();

		public Injuries Injuries = character.GetInjuries();

		public short DisorderOfQi = character.GetDisorderOfQi();
	}

	private struct BreakPlateBonusContext(IRandomSource random, Character character)
	{
		public readonly IRandomSource Random = random;

		public readonly Character Character = character;

		public readonly Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> CharCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());

		public HashSet<int> UsedRelatedCharIds = null;
	}

	private static ScoreFormulas _formulas;

	private readonly List<GameData.Domains.CombatSkill.CombatSkill>[] _availableCombatSkills;

	private List<short> _masteredSkills;

	private readonly CombatSkillEquipment _equippedCombatSkills;

	private short[] _combatSkillAttainmentPanels;

	private readonly LocalObjectPool<SectCandidateSkills> _sectCandidateSkillsPool;

	private readonly List<SectCandidateSkills> _sectCandidateSkillInfos;

	private readonly List<SectCandidateSkills> _sortedSectCandidateSkillInfos;

	private static readonly IComparer<(CombatSkillItem skillCfg, int index)> Comparer = new GradeComparer();

	private List<CombatSkillInitialBreakoutData> _brokenOutCombatSkills;

	private readonly List<GameData.Domains.CombatSkill.CombatSkill>[] _categorizedCombatSkillsByGrade;

	private readonly List<(CombatSkillItem skillCfg, int index)> _brokenOutNeigongList;

	private readonly HashSet<int> _usedRelatedCharIds;

	private readonly List<ShortPair> _skillBreakBonusWeights = new List<ShortPair>();

	private const sbyte EnsuredSuccessStepCount = 20;

	private HashSet<int> _askingForHelpSkills = new HashSet<int>();

	private readonly List<(GameData.Domains.CombatSkill.CombatSkill combatSkill, int score)> _canUpdateCombatSkills = new List<(GameData.Domains.CombatSkill.CombatSkill, int)>();

	private bool _goalUpdated;

	private List<ItemKey> _consumedItems = new List<ItemKey>();

	private List<(GameData.Domains.CombatSkill.CombatSkill combatSkill, ushort activationState)> _newlyActivatedCombatSkills = new List<(GameData.Domains.CombatSkill.CombatSkill, ushort)>();

	private List<GameData.Domains.CombatSkill.CombatSkill> _failedToBreakoutCombatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>();

	private List<(short skillTemplateId, int startIndex, SerializableList<SkillBreakPlateBonus> bonuses)> _modifiedBreakPlateBonuses = new List<(short, int, SerializableList<SkillBreakPlateBonus>)>();

	private ItemKey[] _equippedItems;

	private readonly List<(ItemKey weapon, int score)> _availableWeapons;

	private readonly List<(short itemTemplateId, short count)> _suitableWeapons;

	private readonly HashSet<short> _fixedBestWeapons;

	private readonly List<GameData.Domains.Item.Armor> _availableHelms;

	private readonly List<GameData.Domains.Item.Armor> _availableTorsos;

	private readonly List<GameData.Domains.Item.Armor> _availableBracers;

	private readonly List<GameData.Domains.Item.Armor> _availableBoots;

	private readonly List<GameData.Domains.Item.Accessory> _availableAccessories;

	private readonly List<GameData.Domains.Item.Accessory> _availablePockets;

	private readonly List<GameData.Domains.Item.Clothing> _availableClothing;

	private readonly List<GameData.Domains.Item.Carrier> _availableCarriers;

	private readonly List<GameData.Domains.Item.Carrier> _availableLivestockCarriers;

	private readonly List<GameData.Domains.Item.Carrier> _availableBeastCarriers;

	private readonly List<(CombatSkillItem skillCfg, bool canObtainNeili)> _candidateCombatSkillsForLooping;

	private static readonly IComparer<sbyte> ReverseComparer = new ReverseComparerSbyte();

	private readonly List<(GameData.Domains.Item.SkillBook book, int learnedSkillIndex, byte readingPage)> _availableReadingBooks;

	private readonly List<short> _hasPersonalNeedToReadBooks;

	private readonly List<sbyte> _hasPersonalNeedToLearnCombatSkillTypes;

	private readonly List<sbyte> _hasPersonalNeedToLearnLifeSkillTypes;

	public Equipping()
	{
		_brokenOutCombatSkills = new List<CombatSkillInitialBreakoutData>(32);
		_brokenOutNeigongList = new List<(CombatSkillItem, int)>();
		_combatSkillAttainmentPanels = new short[126];
		_sectCandidateSkillsPool = new LocalObjectPool<SectCandidateSkills>(15, 30);
		_sectCandidateSkillInfos = new List<SectCandidateSkills>();
		_sortedSectCandidateSkillInfos = new List<SectCandidateSkills>();
		_availableCombatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>[5];
		for (int i = 0; i < 5; i++)
		{
			_availableCombatSkills[i] = new List<GameData.Domains.CombatSkill.CombatSkill>();
		}
		_equippedCombatSkills = new CombatSkillEquipment();
		_equippedCombatSkills.Set(new CombatSkillPlan());
		_categorizedCombatSkillsByGrade = new List<GameData.Domains.CombatSkill.CombatSkill>[9];
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			_categorizedCombatSkillsByGrade[grade] = new List<GameData.Domains.CombatSkill.CombatSkill>();
		}
		_masteredSkills = new List<short>();
		_candidateCombatSkillsForLooping = new List<(CombatSkillItem, bool)>();
		_equippedItems = new ItemKey[17];
		_availableWeapons = new List<(ItemKey, int)>();
		_suitableWeapons = new List<(short, short)>();
		_fixedBestWeapons = new HashSet<short>();
		_availableHelms = new List<GameData.Domains.Item.Armor>();
		_availableTorsos = new List<GameData.Domains.Item.Armor>();
		_availableBracers = new List<GameData.Domains.Item.Armor>();
		_availableBoots = new List<GameData.Domains.Item.Armor>();
		_availableAccessories = new List<GameData.Domains.Item.Accessory>();
		_availableClothing = new List<GameData.Domains.Item.Clothing>();
		_availableCarriers = new List<GameData.Domains.Item.Carrier>();
		_availableLivestockCarriers = new List<GameData.Domains.Item.Carrier>();
		_availableBeastCarriers = new List<GameData.Domains.Item.Carrier>();
		_availablePockets = new List<GameData.Domains.Item.Accessory>();
		_availableReadingBooks = new List<(GameData.Domains.Item.SkillBook, int, byte)>();
		_hasPersonalNeedToReadBooks = new List<short>();
		_hasPersonalNeedToLearnCombatSkillTypes = new List<sbyte>();
		_hasPersonalNeedToLearnLifeSkillTypes = new List<sbyte>();
		_usedRelatedCharIds = new HashSet<int>();
	}

	public static void InitFormulas()
	{
		_formulas = new ScoreFormulas();
	}

	public void SetInitialCombatSkillBreakouts(DataContext context, Character character)
	{
		if (character.GetAgeGroup() != 0)
		{
			var (brokenOutSkills, breakPlateBonuses, neiliProportion, extraNeiliAllocationProgress) = ParallelSetInitialCombatSkillBreakouts(context, character, recordModification: false);
			if (brokenOutSkills != null && brokenOutSkills.Count > 0)
			{
				ComplementSetInitialCombatSkillBreakouts(context, brokenOutSkills, character, neiliProportion, extraNeiliAllocationProgress);
			}
			if (breakPlateBonuses != null && breakPlateBonuses.Count > 0)
			{
				ApplyBreakPlateBonuses(context, character.GetId(), breakPlateBonuses);
			}
		}
	}

	public void SetInitialCombatSkillAttainmentPanels(DataContext context, Character character)
	{
		if (character.GetAgeGroup() != 0)
		{
			short[] panels = ParallelSetInitialCombatSkillAttainmentPanels(context, character, recordModification: false);
			if (panels != null)
			{
				ComplementSetInitialCombatSkillAttainmentPanels(context, character, panels);
			}
		}
	}

	public void SelectEquipments(DataContext context, Character character, bool isOutOfTaiwuGroup, bool removeUnequippedEquipment = false)
	{
		if (character.GetAgeGroup() != 0)
		{
			SelectEquipmentsModification mod = ParallelSelectEquipments(context, character, isOutOfTaiwuGroup, removeUnequippedEquipment, recordModification: false);
			ComplementSelectEquipments(context, mod);
		}
	}

	public void SelectEquipmentsByCombatConfig(DataContext context, Character character, short combatTemplateId, bool isOutOfTaiwuGroup, bool removeUnequippedEquipment = false)
	{
		if (character.GetAgeGroup() != 0)
		{
			SelectEquipmentsModification mod = ParallelSelectEquipmentsByCombatConfig(context, character, combatTemplateId, isOutOfTaiwuGroup, removeUnequippedEquipment, recordModification: false);
			ComplementSelectEquipments(context, mod);
		}
	}

	public unsafe SelectEquipmentsModification ParallelSelectEquipments(DataContext context, Character character, bool isOutOfTaiwuGroup, bool removeUnequippedEquipment = false, bool recordModification = true)
	{
		SelectEquipmentsModification mod = new SelectEquipmentsModification(character, removeUnequippedEquipment);
		int charId = character.GetId();
		sbyte* skillSlotTotalCounts = stackalloc sbyte[5];
		CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(charId);
		bool canAutoEquipCombatSkills = isOutOfTaiwuGroup || !(configuration?.IsCombatSkillLocked ?? false);
		bool canAutoAllocateNeili = isOutOfTaiwuGroup || !(configuration?.IsNeiliAllocationLocked ?? false);
		bool canAutoEquipItems = !character.IsCreatedWithFixedTemplate() && !character.IsNonActorSkeleton() && (isOutOfTaiwuGroup || !DomainManager.Taiwu.GetManualChangeEquipGroupCharIds().Contains(charId));
		ChooseLoopingNeigong(character, mod);
		if (canAutoEquipCombatSkills)
		{
			EquipCombatSkills(character, skillSlotTotalCounts, -1, mod);
		}
		if (canAutoAllocateNeili)
		{
			AllocateNeili(character, skillSlotTotalCounts, mod);
		}
		if (canAutoEquipItems)
		{
			EquipItems(character, mod);
		}
		if (recordModification && (mod.EquippedSkillsChanged || mod.NeiliAllocationChanged || mod.LoopingNeigongChanged || mod.EquippedItems != null || mod.MasteredSkillsChanged))
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.SelectEquipments);
			recorder.RecordParameterClass(mod);
		}
		return mod;
	}

	private unsafe SelectEquipmentsModification ParallelSelectEquipmentsByCombatConfig(DataContext context, Character character, short combatConfigTemplateId, bool isOutOfTaiwuGroup, bool removeUnequippedEquipment = false, bool recordModification = true)
	{
		SelectEquipmentsModification mod = new SelectEquipmentsModification(character, removeUnequippedEquipment);
		sbyte* skillSlotTotalCounts = stackalloc sbyte[5];
		int charId = character.GetId();
		CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(charId);
		bool canAutoEquipCombatSkills = isOutOfTaiwuGroup || !(configuration?.IsCombatSkillLocked ?? false);
		bool canAutoAllocateNeili = isOutOfTaiwuGroup || !(configuration?.IsNeiliAllocationLocked ?? false);
		bool canAutoEquipItems = !character.IsCreatedWithFixedTemplate() && !character.IsNonActorSkeleton() && (isOutOfTaiwuGroup || !DomainManager.Taiwu.GetManualChangeEquipGroupCharIds().Contains(charId));
		ChooseLoopingNeigong(character, mod);
		if (canAutoEquipCombatSkills)
		{
			EquipCombatSkills(character, skillSlotTotalCounts, combatConfigTemplateId, mod);
		}
		if (canAutoAllocateNeili)
		{
			AllocateNeili(character, skillSlotTotalCounts, mod);
		}
		if (canAutoEquipItems)
		{
			EquipItems(character, mod);
		}
		if (recordModification && (mod.EquippedSkillsChanged || mod.NeiliAllocationChanged || mod.LoopingNeigongChanged || mod.EquippedItems != null || mod.MasteredSkillsChanged))
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.SelectEquipments);
			recorder.RecordParameterClass(mod);
		}
		return mod;
	}

	public static void ComplementSelectEquipments(DataContext context, SelectEquipmentsModification mod)
	{
		Character character = mod.Character;
		int charId = character.GetId();
		if (mod.EquippedSkillsChanged)
		{
			if (mod.GenericSkillSlotAllocation != null)
			{
				ApplyGenericSkillSlotAllocation(context, character, mod.GenericSkillSlotAllocation);
			}
			character.ApplyCombatSkillEquipmentModification(context, mod.CombatSkillEquipment);
		}
		if (mod.NeiliAllocationChanged)
		{
			character.SpecifyBaseNeiliAllocation(context, mod.NeiliAllocation);
		}
		if (mod.LoopingNeigongChanged)
		{
			character.SetLoopingNeigong(mod.LoopingNeigong, context);
		}
		if (mod.EquippedItems != null)
		{
			character.ChangeEquipment(context, mod.EquippedItems);
		}
		if (mod.RemoveUnequippedEquipment)
		{
			character.RemoveUnequippedEquipment(context);
		}
		if (mod.PersonalNeedChanged)
		{
			character.SetActionPlanningModified(context);
		}
		if (mod.MasteredSkillsChanged)
		{
			DomainManager.Extra.SetCharacterMasteredCombatSkills(context, charId, mod.MasteredCombatSkills);
		}
	}

	public unsafe void EquipCombatSkills(DataContext context, Character character, short combatConfigTemplateId)
	{
		int charId = character.GetId();
		SelectEquipmentsModification mod = new SelectEquipmentsModification(character, removeUnequippedEquipment: false);
		sbyte* skillSlotTotalCounts = stackalloc sbyte[5];
		EquipCombatSkills(character, skillSlotTotalCounts, combatConfigTemplateId, mod);
		if (mod.MasteredSkillsChanged)
		{
			AdaptableLog.Info($"{character} changed mastered skills.");
			DomainManager.Extra.SetCharacterMasteredCombatSkills(context, charId, mod.MasteredCombatSkills);
		}
		if (mod.EquippedSkillsChanged)
		{
			if (mod.GenericSkillSlotAllocation != null)
			{
				ApplyGenericSkillSlotAllocation(context, character, mod.GenericSkillSlotAllocation);
			}
			AdaptableLog.Info($"{character} changed equipped skills.");
			character.ApplyCombatSkillEquipmentModification(context, mod.CombatSkillEquipment);
		}
	}

	private static void ApplyGenericSkillSlotAllocation(DataContext context, Character character, byte[] genericSkillSlotAllocation)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (taiwuCharId >= 0)
		{
			int charId = character.GetId();
			if (charId == taiwuCharId)
			{
				AdaptableLog.Info($"{character} changed generic skill slot allocation.");
				DomainManager.Taiwu.SetGenericGridAllocation(context, genericSkillSlotAllocation);
			}
			else if (character.GetLeaderId() == taiwuCharId)
			{
				CharacterCombatSkillConfiguration configuration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(charId) ?? new CharacterCombatSkillConfiguration(character);
				AdaptableLog.Info($"{character} changed generic skill slot allocation.");
				byte[] currAllocation = configuration.CurrentEquipPlan.GenericGridAllocation;
				Array.Copy(genericSkillSlotAllocation, currAllocation, currAllocation.Length);
				DomainManager.Extra.SetCharacterCombatSkillConfiguration(context, charId, configuration);
			}
		}
	}

	private unsafe void EquipCombatSkills(Character character, sbyte* skillSlotTotalCounts, short combatConfigTemplateId, SelectEquipmentsModification mod)
	{
		int charId = character.GetId();
		for (int i = 0; i < 5; i++)
		{
			_availableCombatSkills[i].Clear();
		}
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		CombatConfigItem combatConfig = CombatConfig.Instance.GetItem(combatConfigTemplateId);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in charCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill skill = value;
			sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
			if (!skill.GetRevoked() && (combatConfig == null || MatchCombatSkillByCombatConfig(skillTemplateId, combatConfig)))
			{
				_availableCombatSkills[equipType].Add(skill);
			}
		}
		_equippedCombatSkills.OfflineClear();
		CombatSkillEquipment oriCombatSkillEquipment = character.GetCombatSkillEquipment();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		bool isTaiwu = charId == taiwuCharId;
		EquipCombatSkillContext context = new EquipCombatSkillContext
		{
			IsTaiwu = isTaiwu,
			IsTaiwuGroup = (character.GetLeaderId() == taiwuCharId),
			Equipments = character.GetEquipment(),
			Personalities = character.GetPersonalities(),
			NeiliType = character.GetNeiliType(),
			OrgTemplateId = character.GetOrganizationInfo().OrgTemplateId,
			IdealSectId = character.GetIdealSect(),
			OwnedLegendaryBookTypes = DomainManager.LegendaryBook.GetCharOwnedBookTypes(charId),
			EquippedSkills = _equippedCombatSkills,
			CharacterCombatSkills = charCombatSkills,
			SlotTotalCounts = skillSlotTotalCounts
		};
		*skillSlotTotalCounts = character.GetCombatSkillSlotCountNeigong();
		SelectCombatSkills(ref context, 0);
		Span<sbyte> gridCounts = new Span<sbyte>(skillSlotTotalCounts, 5);
		sbyte genericSlotCount = character.GetCombatSkillSlotCounts(gridCounts, context.EquippedSkills.Neigong);
		Span<byte> allocatedGenericSlots = stackalloc byte[4];
		Span<byte> slotCountsProvidedByNeigong = stackalloc byte[4];
		for (sbyte equipType2 = 1; equipType2 < 5; equipType2++)
		{
			slotCountsProvidedByNeigong[equipType2 - 1] = (byte)character.GetCombatSkillBasicSlotCount(equipType2, context.EquippedSkills.Neigong);
		}
		AllocateGenericSkillSlots(ref allocatedGenericSlots, ref slotCountsProvidedByNeigong, genericSlotCount);
		for (sbyte index = 0; index < 4; index++)
		{
			int equipType3 = index + 1;
			int result = skillSlotTotalCounts[equipType3] + allocatedGenericSlots[index];
			skillSlotTotalCounts[equipType3] = (sbyte)result;
		}
		if (context.IsTaiwu)
		{
			byte[] prevAllocation = DomainManager.Taiwu.GetGenericGridAllocation();
			if (!allocatedGenericSlots.SequenceEqual(prevAllocation))
			{
				mod.GenericSkillSlotAllocation = new byte[4];
				for (int j = 0; j < 4; j++)
				{
					mod.GenericSkillSlotAllocation[j] = allocatedGenericSlots[j];
				}
			}
		}
		else if (context.IsTaiwuGroup)
		{
			byte[] prevAllocation2 = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(charId)?.CurrentEquipPlan?.GenericGridAllocation;
			if (prevAllocation2 == null || !allocatedGenericSlots.SequenceEqual(prevAllocation2))
			{
				mod.GenericSkillSlotAllocation = new byte[4];
				for (int k = 0; k < 4; k++)
				{
					mod.GenericSkillSlotAllocation[k] = allocatedGenericSlots[k];
				}
			}
		}
		SelectCombatSkills(ref context, 1);
		SelectCombatSkills(ref context, 2);
		SelectCombatSkills(ref context, 3);
		SelectCombatSkills(ref context, 4);
		if (!oriCombatSkillEquipment.EqualsTo(context.EquippedSkills) || mod.GenericSkillSlotAllocation != null)
		{
			oriCombatSkillEquipment.CopyFrom(context.EquippedSkills);
			mod.CombatSkillEquipment = oriCombatSkillEquipment;
			mod.EquippedSkillsChanged = true;
		}
	}

	private void AllocateGenericSkillSlots(ref Span<byte> result, ref Span<byte> currSlotCounts, int genericSlotsCount)
	{
		result.Fill(0);
		do
		{
			int minCost = int.MaxValue;
			int minCostEquipType = -1;
			for (sbyte equipType = 1; equipType < 5; equipType++)
			{
				int index = equipType - 1;
				if (result[index] + currSlotCounts[index] < CombatSkillHelper.MaxSlotCounts[equipType])
				{
					int currCost = CombatSkillHelper.GetGenericAllocationNextCost(equipType, result[index]);
					if (currCost < minCost && currCost <= genericSlotsCount)
					{
						minCost = currCost;
						minCostEquipType = equipType;
					}
				}
			}
			if (minCostEquipType < 0)
			{
				break;
			}
			result[minCostEquipType - 1]++;
			genericSlotsCount -= minCost;
		}
		while (genericSlotsCount > 0);
	}

	private unsafe void SelectCombatSkills(ref EquipCombatSkillContext context, sbyte equipType)
	{
		sbyte slotCount = context.SlotTotalCounts[equipType];
		if (slotCount <= 0)
		{
			return;
		}
		List<GameData.Domains.CombatSkill.CombatSkill> candidateSkills = _availableCombatSkills[equipType];
		int candidateSkillsCount = candidateSkills.Count;
		int* pSkillInfos = stackalloc int[candidateSkillsCount];
		for (int i = 0; i < candidateSkillsCount; i++)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = candidateSkills[i];
			short skillTemplateId = skill.GetId().SkillTemplateId;
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
			if (skillConfig.ScoreBonusType == -2)
			{
				pSkillInfos[i] = 2147418112 + skillTemplateId;
				continue;
			}
			short score = CalcCombatSkillScore(skill, equipType, ref context.Personalities, context.NeiliType, context.OrgTemplateId, context.IdealSectId, context.OwnedLegendaryBookTypes);
			if (context.IsTaiwuGroup)
			{
				score += CalcCombatSkillScoreForCurrWeapons(skillConfig, context.Equipments);
			}
			pSkillInfos[i] = (score << 16) + skillTemplateId;
		}
		CollectionUtils.Sort(pSkillInfos, candidateSkillsCount);
		int slotsUsed = 0;
		context.EquippedSkills.OfflineEnsureCapacity(equipType, slotCount);
		ref ArraySegmentList<short> skillList = ref context.EquippedSkills[equipType];
		skillList.Clear();
		if (context.IsTaiwu)
		{
			Character taiwu = DomainManager.Taiwu.GetTaiwu();
			for (int j = 0; j < candidateSkillsCount; j++)
			{
				if (slotsUsed >= slotCount)
				{
					break;
				}
				int selectedIndex = candidateSkillsCount - j - 1;
				int skillInfo = pSkillInfos[selectedIndex];
				short skillTemplateId2 = (short)skillInfo;
				sbyte slotCost = taiwu.GetCombatSkillGridCost(skillTemplateId2);
				if (slotsUsed + slotCost <= slotCount)
				{
					skillList.Add(skillTemplateId2);
					slotsUsed += slotCost;
				}
			}
			return;
		}
		for (int k = 0; k < candidateSkillsCount; k++)
		{
			if (slotsUsed >= slotCount)
			{
				break;
			}
			int selectedIndex2 = candidateSkillsCount - k - 1;
			int skillInfo2 = pSkillInfos[selectedIndex2];
			short skillTemplateId3 = (short)skillInfo2;
			var (slotCost2, isMastered) = CalcSlotCostInfo(context, skillTemplateId3);
			if (slotsUsed + slotCost2 <= slotCount)
			{
				skillList.Add(skillTemplateId3);
				slotsUsed += slotCost2;
			}
		}
	}

	private static (sbyte slotCost, bool isMastered) CalcSlotCostInfo(EquipCombatSkillContext context, short skillTemplateId)
	{
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
		sbyte gridCost = skillCfg.GridCost;
		return (slotCost: Math.Max(gridCost, 1), isMastered: false);
	}

	private static short CalcCombatSkillScoreForCurrWeapons(CombatSkillItem skillCfg, ItemKey[] equipments)
	{
		int score = 0;
		for (int i = 0; i <= 2; i++)
		{
			ItemKey itemKey = equipments[i];
			if (itemKey.ItemType == 0)
			{
				GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(itemKey.Id);
				WeaponItem weaponCfg = Config.Weapon.Instance[itemKey.TemplateId];
				if (weaponCfg.GroupId == skillCfg.MostFittingWeaponID)
				{
					score += 50 * ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
				}
				if (weapon.TricksMatchCombatSkill(skillCfg))
				{
					score += 100;
				}
			}
		}
		return (short)score;
	}

	public unsafe static short CalcCombatSkillScore(GameData.Domains.CombatSkill.CombatSkill skill, sbyte equipType, ref Personalities personalities, sbyte neiliType, sbyte orgTemplateId, sbyte idealSectTemplateId, List<sbyte> ownedLegendaryBookTypes)
	{
		short skillTemplateId = skill.GetId().SkillTemplateId;
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
		if (skillConfig.ScoreBonusType == -2)
		{
			return short.MaxValue;
		}
		int score = 0;
		if (skillConfig.SectId == orgTemplateId)
		{
			score += _formulas.EquippingScoreCurrSect.Calculate(personalities.Items[0]);
		}
		if (skillConfig.SectId == idealSectTemplateId)
		{
			score += _formulas.EquippingScoreIdealSect.Calculate(personalities.Items[2]);
		}
		if (!CheckCounterWithNeiliType(skillConfig.FiveElements, neiliType))
		{
			score += _formulas.EquippingScoreNotCounter.Calculate(personalities.Items[0]);
		}
		score += _formulas.EquippingScoreGrade.Calculate(skillConfig.Grade);
		score += _formulas.EquippingScoreSkillPower.Calculate(skill.GetPower());
		if (CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState()))
		{
			score += _formulas.EquippingScoreBreakout;
		}
		if (ownedLegendaryBookTypes != null && equipType == 1 && ownedLegendaryBookTypes.Contains(skillConfig.Type))
		{
			score += _formulas.EquippingScoreLegendaryBook;
		}
		return (short)score;
	}

	public static bool CheckCounterWithNeiliType(sbyte fiveElementsType, sbyte neiliTypeId)
	{
		NeiliTypeItem neiliTypeCfg = NeiliType.Instance[neiliTypeId];
		return neiliTypeCfg.InjuryOnUseType == fiveElementsType || neiliTypeCfg.MaxPowerChange[fiveElementsType] < 0;
	}

	public static bool CheckCounterWithTargetFiveElementsType(short fiveElementsType, sbyte targetFiveElementsType)
	{
		return targetFiveElementsType == 5 || (FiveElementsType.Countered[targetFiveElementsType] != fiveElementsType && FiveElementsType.Countering[targetFiveElementsType] != fiveElementsType);
	}

	public short[] ParallelSetInitialCombatSkillAttainmentPanels(DataContext context, Character character, bool recordModification = true)
	{
		short[] panels = _combatSkillAttainmentPanels ?? new short[126];
		CombatSkillAttainmentPanelsHelper.Initialize(panels);
		int charId = character.GetId();
		sbyte selfOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte lovingOrgTemplateId = character.GetIdealSect();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		for (sbyte skillType = 0; skillType < 14; skillType++)
		{
			SetCombatSkillAttainmentPanel(charCombatSkills, selfOrgTemplateId, lovingOrgTemplateId, panels, skillType);
		}
		short[] oriPanels = character.GetCombatSkillAttainmentPanels();
		if (CombatSkillAttainmentPanelsHelper.EqualAll(oriPanels, panels))
		{
			_combatSkillAttainmentPanels = panels;
			return null;
		}
		if (recordModification)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.SetInitialCombatSkillAttainmentPanels);
			recorder.RecordParameterClass(character);
			recorder.RecordParameterClass(panels);
		}
		_combatSkillAttainmentPanels = null;
		return panels;
	}

	public static void ComplementSetInitialCombatSkillAttainmentPanels(DataContext context, Character character, short[] panels)
	{
		short[] oriPanels = character.GetCombatSkillAttainmentPanels();
		CombatSkillAttainmentPanelsHelper.CopyAll(panels, oriPanels);
		character.SetCombatSkillAttainmentPanels(oriPanels, context);
	}

	private unsafe void SetCombatSkillAttainmentPanel(Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills, sbyte selfOrgTemplateId, sbyte lovingOrgTemplateId, short[] panels, sbyte combatSkillType)
	{
		int i = 0;
		for (int count = _sectCandidateSkillInfos.Count; i < count; i++)
		{
			_sectCandidateSkillsPool.Return(_sectCandidateSkillInfos[i]);
		}
		_sectCandidateSkillInfos.Clear();
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkill in charCombatSkills)
		{
			charCombatSkill.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill skill = value;
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
			if (skillConfig.Type == combatSkillType && skill.CanBreakout())
			{
				SetCombatSkillAttainmentPanel_AddSectCandidateSkill(skillConfig);
			}
		}
		SetCombatSkillAttainmentPanel_SortCandidateSects(selfOrgTemplateId, lovingOrgTemplateId);
		byte* intPtr = stackalloc byte[18];
		// IL initblk instruction
		Unsafe.InitBlock(intPtr, 255, 18);
		short* pPanel = (short*)intPtr;
		int j = 0;
		for (int count2 = _sortedSectCandidateSkillInfos.Count; j < count2; j++)
		{
			short[] currSkillTemplateIds = _sortedSectCandidateSkillInfos[j].SkillTemplateIds;
			for (int grade = 0; grade < 9; grade++)
			{
				if (pPanel[grade] < 0 && currSkillTemplateIds[grade] >= 0)
				{
					pPanel[grade] = currSkillTemplateIds[grade];
				}
			}
		}
		CombatSkillAttainmentPanelsHelper.SetPanel(panels, combatSkillType, pPanel);
	}

	private void SetCombatSkillAttainmentPanel_AddSectCandidateSkill(CombatSkillItem config)
	{
		sbyte orgTemplateId = config.SectId;
		sbyte grade = config.Grade;
		int index = -1;
		int i = 0;
		for (int count = _sectCandidateSkillInfos.Count; i < count; i++)
		{
			if (_sectCandidateSkillInfos[i].OrgTemplateId == orgTemplateId)
			{
				index = i;
				break;
			}
		}
		if (index >= 0)
		{
			SectCandidateSkills info = _sectCandidateSkillInfos[index];
			info.Add(config.TemplateId, grade);
			return;
		}
		SectCandidateSkills info2 = _sectCandidateSkillsPool.Get();
		info2.Initialize(orgTemplateId);
		info2.Add(config.TemplateId, grade);
		_sectCandidateSkillInfos.Add(info2);
	}

	private void SetCombatSkillAttainmentPanel_SortCandidateSects(sbyte selfOrgTemplateId, sbyte lovingOrgTemplateId)
	{
		int maxValue = int.MinValue;
		int comboIndex = -1;
		int selfOrgIndex = -1;
		int lovingOrgIndex = -1;
		int i = 0;
		for (int count = _sectCandidateSkillInfos.Count; i < count; i++)
		{
			SectCandidateSkills info = _sectCandidateSkillInfos[i];
			int value = (info.CombatSkillsCount << 8) + info.MaxGrade;
			if (value > maxValue)
			{
				maxValue = value;
				comboIndex = i;
			}
			sbyte orgTemplateId = info.OrgTemplateId;
			if (orgTemplateId == selfOrgTemplateId)
			{
				selfOrgIndex = i;
			}
			else if (orgTemplateId == lovingOrgTemplateId)
			{
				lovingOrgIndex = i;
			}
		}
		_sortedSectCandidateSkillInfos.Clear();
		if (comboIndex >= 0)
		{
			SectCandidateSkills info2 = _sectCandidateSkillInfos[comboIndex];
			if (info2.CombatSkillsCount >= 3)
			{
				_sortedSectCandidateSkillInfos.Add(info2);
			}
			else
			{
				comboIndex = -1;
			}
		}
		if (selfOrgIndex >= 0 && selfOrgIndex != comboIndex)
		{
			_sortedSectCandidateSkillInfos.Add(_sectCandidateSkillInfos[selfOrgIndex]);
		}
		if (lovingOrgIndex >= 0 && lovingOrgIndex != comboIndex && lovingOrgIndex != selfOrgIndex)
		{
			_sortedSectCandidateSkillInfos.Add(_sectCandidateSkillInfos[lovingOrgIndex]);
		}
		int j = 0;
		for (int count2 = _sectCandidateSkillInfos.Count; j < count2; j++)
		{
			if (j != comboIndex && j != selfOrgIndex && j != lovingOrgIndex)
			{
				_sortedSectCandidateSkillInfos.Add(_sectCandidateSkillInfos[j]);
			}
		}
	}

	public (List<CombatSkillInitialBreakoutData> brokenOutSkills, List<(short skillTemplateId, int startIndex, SerializableList<SkillBreakPlateBonus> bonuses)> breakPlateBonuses, NeiliProportionOfFiveElements neiliProportion, int[] extraNeiliAllocationProgress) ParallelSetInitialCombatSkillBreakouts(DataContext context, Character character, bool recordModification = true)
	{
		_brokenOutCombatSkills.Clear();
		_brokenOutNeigongList.Clear();
		_modifiedBreakPlateBonuses.Clear();
		PerformInitialCombatSkillBreakouts(context, character);
		if (_brokenOutCombatSkills.Count <= 0)
		{
			return (brokenOutSkills: null, breakPlateBonuses: null, neiliProportion: default(NeiliProportionOfFiveElements), extraNeiliAllocationProgress: new int[4]);
		}
		(NeiliProportionOfFiveElements neiliProportionOfFiveElements, int[] extraNeiliAllocationProgress) tuple = PerformInitialNeigongLooping(context, character);
		NeiliProportionOfFiveElements neiliProportion = tuple.neiliProportionOfFiveElements;
		int[] extraNeiliAllocationProgress = tuple.extraNeiliAllocationProgress;
		List<CombatSkillInitialBreakoutData> brokenOutCombatSkills = _brokenOutCombatSkills;
		List<(short, int, SerializableList<SkillBreakPlateBonus>)> breakPlateBonuses = _modifiedBreakPlateBonuses;
		if (recordModification)
		{
			_brokenOutCombatSkills = new List<CombatSkillInitialBreakoutData>(32);
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.SetInitialCombatSkillBreakouts);
			recorder.RecordParameterClass(brokenOutCombatSkills);
			recorder.RecordParameterClass(character);
			recorder.RecordParameterUnmanaged(neiliProportion);
			recorder.RecordParameterClass(extraNeiliAllocationProgress);
			if (_modifiedBreakPlateBonuses.Count > 0)
			{
				_modifiedBreakPlateBonuses = new List<(short, int, SerializableList<SkillBreakPlateBonus>)>();
				recorder.RecordType(ParallelModificationType.UpdateBreakPlateBonuses);
				recorder.RecordParameterClass(new UpdateBreakPlateBonusesModification(character)
				{
					ModifiedBonuses = breakPlateBonuses
				});
			}
		}
		return (brokenOutSkills: brokenOutCombatSkills, breakPlateBonuses: breakPlateBonuses, neiliProportion: neiliProportion, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
	}

	public static void ComplementSetInitialCombatSkillBreakouts(DataContext context, List<CombatSkillInitialBreakoutData> brokenOutSkills, Character character, NeiliProportionOfFiveElements neiliProportion, int[] extraNeiliAllocationProgress)
	{
		int i = 0;
		for (int count = brokenOutSkills.Count; i < count; i++)
		{
			CombatSkillInitialBreakoutData data = brokenOutSkills[i];
			GameData.Domains.CombatSkill.CombatSkill skill = data.CombatSkill;
			skill.SetActivationState(data.ActivationState, context);
			skill.SetForcedBreakoutStepsCount(data.ForceBreakoutStepsCount, context);
			skill.SetBreakoutStepsCount(data.BreakoutStepsCount, context);
			if (data.ObtainedNeili != 0)
			{
				skill.SetObtainedNeili(data.ObtainedNeili, context);
			}
		}
		if (character.Template.PresetNeiliProportionOfFiveElements.Sum() <= 0)
		{
			character.SetBaseNeiliProportionOfFiveElements(neiliProportion, context);
		}
		character.SetExtraNeiliAllocationAndProgress(context, extraNeiliAllocationProgress, canOverMax: true);
	}

	private void PerformInitialCombatSkillBreakouts(DataContext context, Character character)
	{
		int charId = character.GetId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		BreakoutCombatSkillContext breakoutContext = new BreakoutCombatSkillContext(context.Random, character);
		byte creatingType = character.GetCreatingType();
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in charCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill skill = value;
			ushort activationState = skill.GetActivationState();
			if (CombatSkillStateHelper.IsBrokenOut(activationState) || !skill.CanBreakout())
			{
				continue;
			}
			var (newActivationState, availableStepsCount, forcedStepsCount) = CalcCombatSkillBreakoutResult(ref breakoutContext, skill);
			if (CombatSkillStateHelper.IsBrokenOut(newActivationState))
			{
				int index = _brokenOutCombatSkills.Count;
				_brokenOutCombatSkills.Add(new CombatSkillInitialBreakoutData(skill, newActivationState, (sbyte)(availableStepsCount + forcedStepsCount), forcedStepsCount));
				CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
				if (skillConfig.EquipType == 0)
				{
					_brokenOutNeigongList.Add((skillConfig, index));
				}
			}
		}
		if (creatingType == 2)
		{
			PerformInitialCombatSkillBreakoutsForRandomEnemy(context, character);
		}
		else
		{
			PerformInitialCombatSkillBreakoutsForNormalCharacter(context, character);
		}
	}

	private void PerformInitialCombatSkillBreakoutsForNormalCharacter(DataContext context, Character character)
	{
		BreakPlateBonusContext breakPlateBonusContext = new BreakPlateBonusContext(context.Random, character);
		List<GameData.Domains.CombatSkill.CombatSkill>[] categorizedCombatSkillsByGrade = _categorizedCombatSkillsByGrade;
		foreach (List<GameData.Domains.CombatSkill.CombatSkill> list in categorizedCombatSkillsByGrade)
		{
			list.Clear();
		}
		foreach (CombatSkillInitialBreakoutData entry in _brokenOutCombatSkills)
		{
			_categorizedCombatSkillsByGrade[entry.CombatSkill.Template.Grade].Add(entry.CombatSkill);
		}
		List<GameData.Domains.CombatSkill.CombatSkill>[] categorizedCombatSkillsByGrade2 = _categorizedCombatSkillsByGrade;
		foreach (List<GameData.Domains.CombatSkill.CombatSkill> list2 in categorizedCombatSkillsByGrade2)
		{
			CollectionUtils.Shuffle(context.Random, list2);
			int bonusCount = list2.Count * 80 / 100;
			for (int k = 0; k < bonusCount; k++)
			{
				int index = context.Random.Next(list2.Count);
				GameData.Domains.CombatSkill.CombatSkill skill = list2[index];
				SerializableList<SkillBreakPlateBonus> bonuses = CreateInitialBreakPlateBonuses(ref breakPlateBonusContext, skill);
				CollectionUtils.SwapAndRemove(list2, index);
				if (bonuses.Items.Count > 0)
				{
					_modifiedBreakPlateBonuses.Add((skill.GetId().SkillTemplateId, 0, bonuses));
				}
			}
		}
	}

	private void PerformInitialCombatSkillBreakoutsForRandomEnemy(DataContext context, Character character)
	{
		BreakPlateBonusContext breakPlateBonusContext = new BreakPlateBonusContext(context.Random, character);
		foreach (CombatSkillInitialBreakoutData brokenOutCombatSkill in _brokenOutCombatSkills)
		{
			GameData.Domains.CombatSkill.CombatSkill skill = brokenOutCombatSkill.CombatSkill;
			SerializableList<SkillBreakPlateBonus> bonuses = CreateInitialBreakPlateBonusesForRandomEnemy(ref breakPlateBonusContext, skill);
			if (bonuses.Items.Count > 0)
			{
				_modifiedBreakPlateBonuses.Add((skill.GetId().SkillTemplateId, 0, bonuses));
			}
		}
	}

	private SerializableList<SkillBreakPlateBonus> CreateInitialBreakPlateBonuses(ref BreakPlateBonusContext context, GameData.Domains.CombatSkill.CombatSkill combatSkill)
	{
		Character character = context.Character;
		int charId = character.GetId();
		OrganizationItem organizationCfg = GetSkillBreakBonusOrganization(character);
		sbyte grade = character.GetOrganizationInfo().Grade;
		int maxBonusCount = CalcMaxSkillBreakBonusCount(character, combatSkill);
		SerializableList<SkillBreakPlateBonus> breakBonusList = SerializableList<SkillBreakPlateBonus>.Create();
		CombatSkillItem skillCfg = combatSkill.Template;
		_skillBreakBonusWeights.Clear();
		_skillBreakBonusWeights.AddRange(organizationCfg.SkillBreakBonusWeights);
		if (_skillBreakBonusWeights.Count == 0)
		{
			foreach (SkillBreakBonusEffectItem effectCfg in (IEnumerable<SkillBreakBonusEffectItem>)SkillBreakBonusEffect.Instance)
			{
				_skillBreakBonusWeights.Add(new ShortPair(effectCfg.TemplateId, 1));
			}
		}
		while (breakBonusList.Items.Count < maxBonusCount)
		{
			int index = GetRandomSkillBreakBonusIndex(context.Random, _skillBreakBonusWeights);
			sbyte bonusEffectId = (sbyte)_skillBreakBonusWeights[index].First;
			if (bonusEffectId < 0)
			{
				break;
			}
			if (!skillCfg.MatchBreakPlateBonusEffect(SkillBreakBonusEffect.Instance[bonusEffectId]))
			{
				CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
				continue;
			}
			switch (bonusEffectId)
			{
			case 37:
			{
				int expLevel = GradeToExpLevel(grade);
				breakBonusList.Items.Add(SkillBreakPlateBonusHelper.CreateExp(expLevel));
				continue;
			}
			case 33:
			case 34:
			{
				ushort relationType = (ushort)((bonusEffectId == 33) ? 16384 : 32768);
				int selectedRelatedCharId = SelectRelatedCharForSkillBreakBonus(ref context, charId, relationType);
				if (selectedRelatedCharId >= 0)
				{
					breakBonusList.Items.Add(SkillBreakPlateBonusHelper.CreateRelation(charId, selectedRelatedCharId, relationType));
				}
				continue;
			}
			}
			TemplateKey groupTemplateKey = ItemDomain.GetRandomItemGroupIdByEffect(context.Random, bonusEffectId);
			if (groupTemplateKey.ItemType >= 0)
			{
				short templateId = ItemTemplateHelper.GetTemplateIdInGroup(groupTemplateKey.ItemType, groupTemplateKey.TemplateId, grade);
				if (templateId >= 0)
				{
					breakBonusList.Items.Add(SkillBreakPlateBonusHelper.CreateItem(new ItemKey(groupTemplateKey.ItemType, 0, templateId, -1)));
				}
			}
		}
		return breakBonusList;
	}

	private SerializableList<SkillBreakPlateBonus> CreateInitialBreakPlateBonusesForRandomEnemy(ref BreakPlateBonusContext context, GameData.Domains.CombatSkill.CombatSkill combatSkill)
	{
		Character character = context.Character;
		int maxBonusCount = CalcMaxSkillBreakBonusCount(character, combatSkill);
		SerializableList<SkillBreakPlateBonus> breakBonusList = SerializableList<SkillBreakPlateBonus>.Create();
		CombatSkillItem skillCfg = combatSkill.Template;
		OrganizationItem organizationCfg = null;
		sbyte idealSectId = character.GetIdealSect();
		if (idealSectId >= 0)
		{
			organizationCfg = Config.Organization.Instance[idealSectId];
		}
		_skillBreakBonusWeights.Clear();
		if (organizationCfg != null && organizationCfg.SkillBreakBonusWeights != null && organizationCfg.SkillBreakBonusWeights.Length != 0)
		{
			ShortPair[] skillBreakBonusWeights = organizationCfg.SkillBreakBonusWeights;
			for (int i = 0; i < skillBreakBonusWeights.Length; i++)
			{
				ShortPair weight = skillBreakBonusWeights[i];
				short effectId = weight.First;
				if (effectId != 33 && effectId != 34)
				{
					_skillBreakBonusWeights.Add(weight);
				}
			}
		}
		else
		{
			foreach (SkillBreakBonusEffectItem effectCfg in (IEnumerable<SkillBreakBonusEffectItem>)SkillBreakBonusEffect.Instance)
			{
				if (effectCfg.TemplateId != 33 && effectCfg.TemplateId != 34)
				{
					_skillBreakBonusWeights.Add(new ShortPair(effectCfg.TemplateId, 1));
				}
			}
		}
		sbyte grade = character.GetOrganizationInfo().Grade;
		while (breakBonusList.Items.Count < maxBonusCount)
		{
			int index = GetRandomSkillBreakBonusIndex(context.Random, _skillBreakBonusWeights);
			sbyte bonusEffectId = (sbyte)_skillBreakBonusWeights[index].First;
			if (bonusEffectId < 0)
			{
				break;
			}
			if (!skillCfg.MatchBreakPlateBonusEffect(SkillBreakBonusEffect.Instance[bonusEffectId]))
			{
				CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
				continue;
			}
			switch (bonusEffectId)
			{
			case 37:
			{
				int expLevel = GradeToExpLevel(grade);
				breakBonusList.Items.Add(SkillBreakPlateBonusHelper.CreateExp(expLevel));
				continue;
			}
			case 33:
			case 34:
				CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
				continue;
			}
			TemplateKey groupTemplateKey = GetRandomItemGroupIdByEffectForRandomEnemy(context.Random, bonusEffectId, grade);
			if (groupTemplateKey.ItemType >= 0)
			{
				short templateId = ItemTemplateHelper.GetTemplateIdInGroup(groupTemplateKey.ItemType, groupTemplateKey.TemplateId, grade);
				if (templateId >= 0)
				{
					breakBonusList.Items.Add(SkillBreakPlateBonusHelper.CreateItem(new ItemKey(groupTemplateKey.ItemType, 0, templateId, -1)));
				}
			}
		}
		return breakBonusList;
	}

	private static TemplateKey GetRandomItemGroupIdByEffectForRandomEnemy(IRandomSource random, sbyte effectId, sbyte expectedGrade)
	{
		List<TemplateKey> candidates = new List<TemplateKey>();
		for (sbyte itemType = 0; itemType < 13; itemType++)
		{
			IList<int> keys = ItemTemplateHelper.GetTemplateDataAllKeys(itemType);
			foreach (int key in keys)
			{
				short templateId = (short)key;
				if (ItemTemplateHelper.GetBreakBonusEffect(itemType, templateId) == effectId)
				{
					short groupId = ItemTemplateHelper.GetGroupId(itemType, templateId);
					if (groupId < 0)
					{
						groupId = templateId;
					}
					else if (groupId != templateId)
					{
						continue;
					}
					if (ItemTemplateHelper.GetGrade(itemType, groupId) <= expectedGrade)
					{
						candidates.Add(new TemplateKey(itemType, groupId));
					}
				}
			}
		}
		return (candidates.Count > 0) ? candidates.GetRandom(random) : TemplateKey.Invalid;
	}

	private (NeiliProportionOfFiveElements neiliProportionOfFiveElements, int[] extraNeiliAllocationProgress) PerformInitialNeigongLooping(DataContext context, Character character)
	{
		IRandomSource random = context.Random;
		NeiliProportionOfFiveElements neiliProportion = character.GetBaseNeiliProportionOfFiveElements();
		int[] extraNeiliAllocationProgress = new int[4];
		CharacterItem characterTemplate = character.Template;
		NeiliAllocation configExtraNeiliAllocation = characterTemplate.ExtraNeiliAllocation;
		for (int i = 0; i < 4; i++)
		{
			int progress = Character.GetExtraNeiliAllocationProgressByExtraNeiliAllocation(configExtraNeiliAllocation[i]);
			extraNeiliAllocationProgress[i] = progress;
		}
		int maxExtraNeiliAllocationProgress = Character.GetNeiliAllocationMaxProgress();
		if (_brokenOutNeigongList.Count <= 0)
		{
			return (neiliProportionOfFiveElements: neiliProportion, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
		}
		int totalLoopsCount = GenerateInitialNeigongLoopsCount(character);
		if (totalLoopsCount <= 0)
		{
			return (neiliProportionOfFiveElements: neiliProportion, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
		}
		_brokenOutNeigongList.Sort(Comparer);
		bool cannotGetExtraNeiliAllocationProgress = CreatingType.IsNonEvolutionaryType(character.GetCreatingType());
		int j = 0;
		for (int count = _brokenOutNeigongList.Count; j < count; j++)
		{
			if (totalLoopsCount <= 0)
			{
				break;
			}
			(CombatSkillItem skillCfg, int index) tuple = _brokenOutNeigongList[j];
			CombatSkillItem skillCfg = tuple.skillCfg;
			int index = tuple.index;
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg.TemplateId));
			sbyte fiveElementsChange = skill.GetFiveElementsChange();
			(short ObtainedNeili, int loopCount, int[] extraNeiliAllocationProgress) tuple2 = GenerateInitialNeili(random, character, skillCfg, ref totalLoopsCount);
			short obtainedNeili = tuple2.ObtainedNeili;
			int loopCount = tuple2.loopCount;
			int[] extraNeiliAllocationProgress2 = tuple2.extraNeiliAllocationProgress;
			CombatSkillInitialBreakoutData breakoutData = _brokenOutCombatSkills[index];
			breakoutData.ObtainedNeili = obtainedNeili;
			for (int k = 0; k < 4; k++)
			{
				if (!cannotGetExtraNeiliAllocationProgress && extraNeiliAllocationProgress[k] < maxExtraNeiliAllocationProgress)
				{
					extraNeiliAllocationProgress[k] = extraNeiliAllocationProgress2[k];
				}
			}
			_brokenOutCombatSkills[index] = breakoutData;
			if (fiveElementsChange > 0 && skillCfg.TransferTypeWhileLooping >= 0)
			{
				neiliProportion.Transfer(skillCfg.DestTypeWhileLooping, skillCfg.TransferTypeWhileLooping, fiveElementsChange * loopCount);
			}
		}
		if (totalLoopsCount > 0)
		{
			CombatSkillItem skillCfg2 = SelectCombatSkillForAdjustingNeiliType(character, _brokenOutNeigongList);
			if (skillCfg2 != null)
			{
				GameData.Domains.CombatSkill.CombatSkill skill2 = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg2.TemplateId));
				sbyte fiveElementsChange2 = skill2.GetFiveElementsChange();
				if (fiveElementsChange2 > 0 && skillCfg2.TransferTypeWhileLooping >= 0)
				{
					neiliProportion.Transfer(skillCfg2.DestTypeWhileLooping, skillCfg2.TransferTypeWhileLooping, fiveElementsChange2 * totalLoopsCount);
				}
			}
			List<(CombatSkillItem skillCfg, int index)> brokenOutNeigongList = _brokenOutNeigongList;
			if (brokenOutNeigongList != null && brokenOutNeigongList.Count > 0)
			{
				CombatSkillItem skillCfgForProgress = _brokenOutNeigongList[0].skillCfg;
				for (int l = 0; l < totalLoopsCount; l++)
				{
					int[] extraNeiliAllocationProgress3 = GenerateInitialNeili(random, character, skillCfgForProgress, ref totalLoopsCount).extraNeiliAllocationProgress;
					for (int m = 0; m < 4; m++)
					{
						if (!cannotGetExtraNeiliAllocationProgress && extraNeiliAllocationProgress[m] < maxExtraNeiliAllocationProgress)
						{
							extraNeiliAllocationProgress[m] += extraNeiliAllocationProgress3[m];
						}
					}
				}
			}
		}
		return (neiliProportionOfFiveElements: neiliProportion, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
	}

	private static (ushort activationState, sbyte availableStepsCount, sbyte forcedStepsCount) CalcCombatSkillBreakoutResult(ref BreakoutCombatSkillContext context, GameData.Domains.CombatSkill.CombatSkill skill)
	{
		short skillTemplateId = skill.GetId().SkillTemplateId;
		ushort readingState = skill.GetReadingState();
		IRandomSource random = context.Random;
		ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedNormalPages(random, readingState, 0);
		sbyte availableStepsCount = context.Character.GetSkillBreakoutAvailableStepsCount(skillTemplateId);
		int forcedStepsCount = 20 - availableStepsCount;
		if (forcedStepsCount < 0)
		{
			forcedStepsCount = 0;
		}
		int successRate = (context.IsCreatedWithFixedTemplate ? 100 : CombatSkillHelper.CalcBreakoutSuccessRate(skillTemplateId, ref context.Qualifications));
		if (random.CheckPercentProb(successRate))
		{
			activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(random, readingState, activationState, context.BehaviorType);
			return (activationState: activationState, availableStepsCount: availableStepsCount, forcedStepsCount: (sbyte)forcedStepsCount);
		}
		return (activationState: 0, availableStepsCount: availableStepsCount, forcedStepsCount: (sbyte)forcedStepsCount);
	}

	private unsafe static int GenerateInitialNeigongLoopsCount(Character character)
	{
		int baseCount = (character.GetActualAge() - 10) * 12;
		int interestPercent = 60 + character.GetCombatSkillQualifications().Items[0];
		return baseCount * interestPercent / 100;
	}

	private static (short ObtainedNeili, int loopCount, int[] extraNeiliAllocationProgress) GenerateInitialNeili(IRandomSource random, Character character, CombatSkillItem skillCfg, ref int totalLoopsCount)
	{
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg.TemplateId));
		short totalNeili = skill.GetTotalObtainableNeili();
		int obtainedNeili = 0;
		int currLoopCount = 0;
		int[] extraNeiliAllocationProgress = new int[4];
		while ((obtainedNeili < totalNeili) & (totalLoopsCount > 0))
		{
			(short neili, short qiDisorder, int[] extraNeiliAllocationProgress) tuple = CombatSkillDomain.CalcNeigongLoopingEffect(random, character, skillCfg);
			short neili = tuple.neili;
			int[] extraNeiliAllocationProgress2 = tuple.extraNeiliAllocationProgress;
			obtainedNeili += neili;
			for (int i = 0; i < 4; i++)
			{
				extraNeiliAllocationProgress[i] += extraNeiliAllocationProgress2[i];
			}
			currLoopCount++;
			totalLoopsCount--;
		}
		if (obtainedNeili > totalNeili)
		{
			obtainedNeili = totalNeili;
		}
		return (ObtainedNeili: (short)obtainedNeili, loopCount: currLoopCount, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
	}

	public void ParallelPracticeAndBreakoutCombatSkills(DataContext context, Character character)
	{
		_canUpdateCombatSkills.Clear();
		_brokenOutCombatSkills.Clear();
		_failedToBreakoutCombatSkills.Clear();
		_askingForHelpSkills.Clear();
		_newlyActivatedCombatSkills.Clear();
		_goalUpdated = false;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		Personalities personalities = character.GetPersonalities();
		sbyte neiliType = character.GetNeiliType();
		sbyte selfOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte lovingOrgTemplateId = character.GetIdealSect();
		foreach (CharacterGoalData goal in character.GetGoals())
		{
			if (goal.GoalTemplateId == 245)
			{
				_askingForHelpSkills.Add(goal.Args.CombatSkillTemplateId);
			}
		}
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in charCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill combatSkill = value;
			ushort activationStates = combatSkill.GetActivationState();
			if (CombatSkillStateHelper.IsBrokenOut(activationStates))
			{
				ushort readingState = combatSkill.GetReadingState();
				ushort newActivationState = CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, activationStates);
				if (newActivationState != activationStates)
				{
					_newlyActivatedCombatSkills.Add((combatSkill, newActivationState));
				}
			}
			else if (combatSkill.CanBreakout() && !_askingForHelpSkills.Contains(skillTemplateId))
			{
				int score = CalcCombatSkillPracticeOrBreakoutScore(skillTemplateId, combatSkill, selfOrgTemplateId, lovingOrgTemplateId, ref personalities, neiliType);
				_canUpdateCombatSkills.Add((combatSkill, score));
			}
		}
		if (_newlyActivatedCombatSkills.Count >= 0)
		{
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.ActivateCombatSkillPages);
			recorder.RecordParameterClass(_newlyActivatedCombatSkills);
			_newlyActivatedCombatSkills = new List<(GameData.Domains.CombatSkill.CombatSkill, ushort)>();
		}
		if (_canUpdateCombatSkills.Count == 0)
		{
			return;
		}
		_canUpdateCombatSkills.Sort(CompareScore);
		BreakoutCombatSkillContext breakoutContext = new BreakoutCombatSkillContext(context.Random, character);
		for (int i = _canUpdateCombatSkills.Count - 1; i >= 0; i--)
		{
			GameData.Domains.CombatSkill.CombatSkill combatSkill2 = _canUpdateCombatSkills[i].combatSkill;
			if (OfflineBreakoutCombatSkill(ref breakoutContext, combatSkill2))
			{
				break;
			}
		}
		PracticeAndBreakoutModification mod = new PracticeAndBreakoutModification(character);
		if (_brokenOutCombatSkills.Count != 0)
		{
			mod.BrokenOutCombatSkills = _brokenOutCombatSkills;
			_brokenOutCombatSkills = new List<CombatSkillInitialBreakoutData>(32);
		}
		if (_failedToBreakoutCombatSkills.Count != 0)
		{
			mod.FailedToBreakoutCombatSkills = _failedToBreakoutCombatSkills;
			_failedToBreakoutCombatSkills = new List<GameData.Domains.CombatSkill.CombatSkill>(8);
		}
		mod.PersonalNeedsChanged = _goalUpdated;
		mod.NewExp = breakoutContext.CharExp;
		mod.NewInjuries = breakoutContext.Injuries;
		mod.NewDisorderOfQi = breakoutContext.DisorderOfQi;
		ParallelModificationsRecorder recorder2 = context.ParallelModificationsRecorder;
		recorder2.RecordType(ParallelModificationType.PracticeAndBreakoutCombatSkills);
		recorder2.RecordParameterClass(mod);
	}

	public static void ComplementActivateCombatSkillPages(DataContext context, List<(GameData.Domains.CombatSkill.CombatSkill skill, ushort activationStates)> newlyActivatedCombatSkills)
	{
		foreach (var pair in newlyActivatedCombatSkills)
		{
			pair.skill.SetActivationState(pair.activationStates, context);
		}
	}

	public static void ComplementPracticeAndBreakoutCombatSkill(DataContext context, PracticeAndBreakoutModification mod)
	{
		Character character = mod.Character;
		character.SetExp(Math.Max(mod.NewExp, 0), context);
		character.SetInjuries(mod.NewInjuries, context);
		character.SetDisorderOfQi(Math.Clamp(mod.NewDisorderOfQi, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue), context);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (mod.BrokenOutCombatSkills != null)
		{
			bool equipChanged = false;
			foreach (CombatSkillInitialBreakoutData brokenOutCombatSkill in mod.BrokenOutCombatSkills)
			{
				GameData.Domains.CombatSkill.CombatSkill skill = brokenOutCombatSkill.CombatSkill;
				skill.SetActivationState(brokenOutCombatSkill.ActivationState, context);
				skill.SetForcedBreakoutStepsCount(brokenOutCombatSkill.ForceBreakoutStepsCount, context);
				skill.SetBreakoutStepsCount(brokenOutCombatSkill.BreakoutStepsCount, context);
				if (brokenOutCombatSkill.ObtainedNeili != 0)
				{
					skill.SetObtainedNeili(brokenOutCombatSkill.ObtainedNeili, context);
				}
				CombatSkillItem skillConfig = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
				if (character.IsCombatSkillEquipped(skillConfig.TemplateId))
				{
					equipChanged = true;
				}
				short bookId = skillConfig.BookId;
				if (bookId >= 0)
				{
					character.ChangeHappiness(context, ItemTemplateHelper.GetBaseHappinessChange(10, bookId));
					continue;
				}
				AdaptableLog.Warning($"Character {charId} is breaking out combat skill {skillConfig.Name}");
			}
			if (equipChanged)
			{
				DomainManager.SpecialEffect.UpdateEquippedSkillEffect(context, character);
			}
		}
		if (mod.FailedToBreakoutCombatSkills != null)
		{
			foreach (GameData.Domains.CombatSkill.CombatSkill combatSkill in mod.FailedToBreakoutCombatSkills)
			{
				short templateId = combatSkill.GetId().SkillTemplateId;
				SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
				int secretInfoOffset = secretInformationCollection.AddBreakoutFail(charId, templateId);
				DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
			}
		}
		if (mod.PersonalNeedsChanged)
		{
			character.SetActionPlanningModified(context);
		}
	}

	private int CompareScore((GameData.Domains.CombatSkill.CombatSkill combatSkill, int score) x, (GameData.Domains.CombatSkill.CombatSkill combatSkill, int score) y)
	{
		return x.score - y.score;
	}

	private bool OfflineBreakoutCombatSkill(ref BreakoutCombatSkillContext context, GameData.Domains.CombatSkill.CombatSkill combatSkill)
	{
		CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[combatSkill.GetId().SkillTemplateId];
		int breakoutExpCost = Config.SkillBreakPlate.Instance[combatSkillCfg.Grade].CostExp * 10;
		if (context.ExpPerMonth + context.CharExp >= breakoutExpCost)
		{
			context.ExpPerMonth -= breakoutExpCost;
			if (context.ExpPerMonth < 0)
			{
				context.CharExp += context.ExpPerMonth;
				context.ExpPerMonth = 0;
			}
			var (newActivationState, availableStepsCount, forcedStepsCount) = CalcCombatSkillBreakoutResult(ref context, combatSkill);
			if (!context.IsCreatedWithFixedTemplate && DomainManager.SpecialEffect.ModifyData(context.Character.GetId(), -1, 266, dataValue: false))
			{
				int successRate = CombatSkillHelper.CalcBreakoutSuccessRate(combatSkill.GetId().SkillTemplateId, ref context.Qualifications);
				int extraDamageCount = (130 - successRate) / 10;
				for (int i = 0; i < extraDamageCount; i++)
				{
					CombatSkillHelper.CalcForceBreakoutInjuriesAndDisorderOfQi(context.Random, combatSkillCfg, ref context.Injuries, ref context.DisorderOfQi);
				}
			}
			if (newActivationState == 0 && availableStepsCount < 10)
			{
				context.Character.OfflineAddGoal(245, combatSkillCfg.TemplateId);
				_goalUpdated = true;
				return false;
			}
			if (CombatSkillStateHelper.IsBrokenOut(newActivationState))
			{
				sbyte breakoutStepsCount = (sbyte)(availableStepsCount + forcedStepsCount);
				_brokenOutCombatSkills.Add(new CombatSkillInitialBreakoutData(combatSkill, newActivationState, breakoutStepsCount, forcedStepsCount));
				return false;
			}
			context.Character.OfflineAddGoal(245, combatSkillCfg.TemplateId);
			_goalUpdated = true;
			_failedToBreakoutCombatSkills.Add(combatSkill);
			CombatSkillHelper.CalcForceBreakoutInjuriesAndDisorderOfQi(context.Random, combatSkillCfg, ref context.Injuries, ref context.DisorderOfQi);
			return true;
		}
		context.Character.OfflineAddGoal(235, breakoutExpCost);
		_goalUpdated = true;
		return true;
	}

	public void ParallelUpdateBreakPlateBonuses(DataContext context, Character character)
	{
		_canUpdateCombatSkills.Clear();
		_modifiedBreakPlateBonuses.Clear();
		_consumedItems.Clear();
		_goalUpdated = false;
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		Personalities personalities = character.GetPersonalities();
		sbyte neiliType = character.GetNeiliType();
		sbyte selfOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte lovingOrgTemplateId = character.GetIdealSect();
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in charCombatSkills)
		{
			item.Deconstruct(out var key, out var value);
			short skillTemplateId = key;
			GameData.Domains.CombatSkill.CombatSkill combatSkill = value;
			ushort activationStates = combatSkill.GetActivationState();
			if (!combatSkill.GetRevoked() && CombatSkillStateHelper.IsBrokenOut(activationStates))
			{
				int score = CalcCombatSkillPracticeOrBreakoutScore(skillTemplateId, combatSkill, selfOrgTemplateId, lovingOrgTemplateId, ref personalities, neiliType);
				_canUpdateCombatSkills.Add((combatSkill, score));
			}
		}
		int expCost = 0;
		if (_canUpdateCombatSkills.Count > 0)
		{
			BreakPlateBonusContext breakPlateBonusContext = new BreakPlateBonusContext(context.Random, character);
			_canUpdateCombatSkills.Sort(CompareScore);
			for (int i = _canUpdateCombatSkills.Count - 1; i >= 0; i--)
			{
				expCost += OfflineUpdateBonuses(ref breakPlateBonusContext, _canUpdateCombatSkills[i].combatSkill);
			}
		}
		if (_modifiedBreakPlateBonuses.Count > 0 || _goalUpdated)
		{
			UpdateBreakPlateBonusesModification mod = new UpdateBreakPlateBonusesModification(character);
			ParallelModificationsRecorder recorder = context.ParallelModificationsRecorder;
			recorder.RecordType(ParallelModificationType.UpdateBreakPlateBonuses);
			recorder.RecordParameterClass(mod);
			if (_modifiedBreakPlateBonuses.Count > 0)
			{
				mod.ModifiedBonuses = _modifiedBreakPlateBonuses;
				_modifiedBreakPlateBonuses = new List<(short, int, SerializableList<SkillBreakPlateBonus>)>();
			}
			mod.ExpCost = expCost;
			if (_consumedItems.Count > 0)
			{
				mod.ToDeleteItems = _consumedItems;
				_consumedItems = new List<ItemKey>();
			}
			mod.PersonalNeedsUpdated |= _goalUpdated;
		}
	}

	public static void ComplementUpdateBreakPlateBonuses(DataContext context, UpdateBreakPlateBonusesModification mod)
	{
		Character character = mod.Character;
		int charId = character.GetId();
		if (mod.ModifiedBonuses != null)
		{
			ApplyBreakPlateBonuses(context, charId, mod.ModifiedBonuses);
			AddBreakPlateBonusLifeRecords(charId, mod.ModifiedBonuses);
		}
		if (mod.PersonalNeedsUpdated)
		{
			character.SetActionPlanningModified(context);
		}
		List<ItemKey> toDeleteItems = mod.ToDeleteItems;
		if (toDeleteItems != null && toDeleteItems.Count > 0)
		{
			foreach (ItemKey itemKey in mod.ToDeleteItems)
			{
				Events.RaiseItemRemovedFromInventory(context, character, itemKey, 1);
				DomainManager.Item.RemoveItem(context, itemKey);
			}
			character.SetInventory(character.GetInventory(), context);
		}
		if (mod.ExpCost > 0)
		{
			character.ChangeExp(context, -mod.ExpCost);
		}
	}

	private static void ApplyBreakPlateBonuses(DataContext context, int charId, List<(short skillTemplateId, int startIndex, SerializableList<SkillBreakPlateBonus> bonuses)> modifiedBonuses)
	{
		foreach (var element in modifiedBonuses)
		{
			DomainManager.Extra.SetCharacterSkillBreakBonuses(context, charId, element.skillTemplateId, element.bonuses);
		}
	}

	private static void AddBreakPlateBonusLifeRecords(int charId, List<(short skillTemplateId, int startIndex, SerializableList<SkillBreakPlateBonus> bonuses)> modifiedBonuses)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		foreach (var element in modifiedBonuses)
		{
			for (int i = element.startIndex; i < element.bonuses.Items.Count; i++)
			{
				SkillBreakPlateBonus bonus = element.bonuses.Items[i];
				switch (bonus.Type)
				{
				case ESkillBreakPlateBonusType.Item:
					lifeRecordCollection.AddCombatSkillKeyPointComprehensionByItems(charId, currDate, element.skillTemplateId, bonus.ItemType, bonus.ItemTemplateId);
					break;
				case ESkillBreakPlateBonusType.Relation:
					if (bonus.RelationType == 16384)
					{
						lifeRecordCollection.AddCombatSkillKeyPointComprehensionByLoveRelationship(charId, currDate, element.skillTemplateId, bonus.RelationRelatedCharId);
					}
					else
					{
						lifeRecordCollection.AddCombatSkillKeyPointComprehensionByHatredRelationship(charId, currDate, element.skillTemplateId, bonus.RelationRelatedCharId);
					}
					break;
				case ESkillBreakPlateBonusType.Exp:
					lifeRecordCollection.AddCombatSkillKeyPointComprehensionByExp(charId, currDate, element.skillTemplateId);
					break;
				}
			}
		}
	}

	private int OfflineUpdateBonuses(ref BreakPlateBonusContext context, GameData.Domains.CombatSkill.CombatSkill combatSkill)
	{
		Character character = context.Character;
		short skillTemplateId = combatSkill.GetId().SkillTemplateId;
		OrganizationItem organizationCfg = GetSkillBreakBonusOrganization(character);
		int maxBonusCount = CalcMaxSkillBreakBonusCount(character, combatSkill);
		SerializableList<SkillBreakPlateBonus> breakBonuses = DomainManager.Extra.GetCharacterSkillBreakBonuses(character.GetId(), skillTemplateId);
		int bonusCount = breakBonuses.Items?.Count ?? 0;
		if (bonusCount >= maxBonusCount)
		{
			return 0;
		}
		bool modified = false;
		int expCost = 0;
		for (int i = bonusCount; i < maxBonusCount; i++)
		{
			SkillBreakPlateBonus bonus = SelectSkillBreakBonus(ref context, combatSkill.Template, organizationCfg);
			if (bonus.Type == ESkillBreakPlateBonusType.None)
			{
				int index = GetRandomSkillBreakBonusIndex(context.Random, organizationCfg.SkillBreakBonusWeights);
				if (index >= 0)
				{
					sbyte needBonusEffectId = (sbyte)organizationCfg.SkillBreakBonusWeights[index].First;
					bool personalNeed = CreateSkillBreakPlateBonusNeed(context.Random, character, needBonusEffectId);
					_goalUpdated = true;
					break;
				}
				continue;
			}
			if (bonus.Type == ESkillBreakPlateBonusType.Exp)
			{
				expCost += SkillBreakPlateConstants.ExpLevelValues[bonus.ExpLevel];
			}
			ref List<SkillBreakPlateBonus> items = ref breakBonuses.Items;
			if (items == null)
			{
				items = new List<SkillBreakPlateBonus>();
			}
			breakBonuses.Items.Add(bonus);
			modified = true;
		}
		if (modified)
		{
			_modifiedBreakPlateBonuses.Add((skillTemplateId, bonusCount, breakBonuses));
		}
		return expCost;
	}

	private int CalcMaxSkillBreakBonusCount(Character character, GameData.Domains.CombatSkill.CombatSkill combatSkill)
	{
		int bonusCount = combatSkill.Template.SkillBreakPlate.BonusCount;
		int talentPercentage = character.GetSkillBreakoutStepsPercentage(combatSkill.GetId().SkillTemplateId);
		return Math.Min(bonusCount * talentPercentage / 100, bonusCount);
	}

	private OrganizationItem GetSkillBreakBonusOrganization(Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.OrgTemplateId == 16)
		{
			return Config.Organization.Instance[orgInfo.OrgTemplateId];
		}
		sbyte orgTemplateId = orgInfo.OrgTemplateId;
		OrganizationItem organizationCfg = Config.Organization.Instance[orgTemplateId];
		if (organizationCfg.IsSect)
		{
			return organizationCfg;
		}
		orgTemplateId = character.GetIdealSect();
		if (orgTemplateId >= 0)
		{
			return Config.Organization.Instance[orgTemplateId];
		}
		if (orgInfo.SettlementId >= 0)
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
			Location location = settlement.GetLocation();
			if (location.IsValid())
			{
				return organizationCfg;
			}
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
			orgTemplateId = MapState.Instance[stateTemplateId].SectID;
			return Config.Organization.Instance[orgTemplateId];
		}
		return organizationCfg;
	}

	private SkillBreakPlateBonus SelectSkillBreakBonus(ref BreakPlateBonusContext context, CombatSkillItem skillCfg, OrganizationItem organizationCfg)
	{
		Character character = context.Character;
		if (character.GetOrganizationInfo().OrgTemplateId == 16)
		{
			int[] gradeLimitArray = GlobalConfig.Instance.TaiwuVillagerSkillBreakBonusItemGradeLimitArray;
			sbyte cl = Math.Clamp(character.GetConsummateLevel(), 0, (sbyte)(gradeLimitArray.Length - 1));
			sbyte bonusGradeLimit = (sbyte)gradeLimitArray[cl];
			_skillBreakBonusWeights.Clear();
			_skillBreakBonusWeights.AddRange(organizationCfg.SkillBreakBonusWeights);
			while (_skillBreakBonusWeights.Count > 0)
			{
				int index = GetRandomSkillBreakBonusIndex(context.Random, _skillBreakBonusWeights);
				if (index < 0)
				{
					break;
				}
				sbyte bonusEffectId = (sbyte)_skillBreakBonusWeights[index].First;
				if (!skillCfg.MatchBreakPlateBonusEffect(SkillBreakBonusEffect.Instance[bonusEffectId]))
				{
					CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
					continue;
				}
				SkillBreakPlateBonus bonus = CreateSkillBreakBonus(ref context, bonusEffectId);
				if (bonus.Type == ESkillBreakPlateBonusType.None)
				{
					CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
					continue;
				}
				if (bonus.Grade > bonusGradeLimit)
				{
					CollectionUtils.SwapAndRemove(_skillBreakBonusWeights, index);
					continue;
				}
				return bonus;
			}
			return SkillBreakPlateBonus.Invalid;
		}
		ShortPair[] skillBreakBonusWeights = organizationCfg.SkillBreakBonusWeights;
		for (int i = 0; i < skillBreakBonusWeights.Length; i++)
		{
			ShortPair shortPair = skillBreakBonusWeights[i];
			sbyte bonusEffectId2 = (sbyte)shortPair.First;
			SkillBreakBonusEffectItem effectCfg = SkillBreakBonusEffect.Instance[bonusEffectId2];
			if (skillCfg.MatchBreakPlateBonusEffect(effectCfg))
			{
				SkillBreakPlateBonus bonus2 = CreateSkillBreakBonus(ref context, bonusEffectId2);
				if (bonus2.Type != ESkillBreakPlateBonusType.None)
				{
					return bonus2;
				}
			}
		}
		return SkillBreakPlateBonus.Invalid;
	}

	private static int GetRandomSkillBreakBonusIndex(IRandomSource random, IReadOnlyList<ShortPair> bonusWeights)
	{
		if (bonusWeights.Count == 0)
		{
			return -1;
		}
		int totalWeight = 0;
		foreach (ShortPair bonusWeight in bonusWeights)
		{
			totalWeight += bonusWeight.Second;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < bonusWeights.Count; i++)
		{
			randomValue -= bonusWeights[i].Second;
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new ArgumentException("Unable to get random from weight table.", "bonusWeights");
	}

	private bool CreateSkillBreakPlateBonusNeed(IRandomSource random, Character character, sbyte bonusEffectId)
	{
		sbyte charGrade = character.GetInteractionGrade();
		sbyte targetGrade = ItemDomain.GenerateRandomItemGrade(random, charGrade);
		switch (bonusEffectId)
		{
		case 37:
			return character.OfflineAddGoal(235, SkillBreakPlateConstants.ExpLevelValues[GradeToExpLevel(targetGrade)]);
		case 33:
			return character.OfflineAddGoal(249, (ushort)16384);
		case 34:
			return character.OfflineAddGoal(249, (ushort)32768);
		default:
		{
			TemplateKey groupTemplateKey = ItemDomain.GetRandomItemGroupIdByEffect(random, bonusEffectId);
			if (groupTemplateKey.ItemType >= 0)
			{
				short templateId = ItemTemplateHelper.GetTemplateIdInGroup(groupTemplateKey.ItemType, groupTemplateKey.TemplateId, targetGrade);
				return character.OfflineAddGoal(238, groupTemplateKey.ItemType, templateId);
			}
			throw new ArgumentException($"Unable to create personal need with bonus effect {bonusEffectId}");
		}
		}
	}

	private int GradeToExpLevel(sbyte grade)
	{
		return Math.Clamp(SkillBreakPlateConstants.ExpLevelValues.Count - 1 - 8 + grade, 0, SkillBreakPlateConstants.ExpLevelValues.Count - 1);
	}

	private SkillBreakPlateBonus CreateSkillBreakBonus(ref BreakPlateBonusContext context, sbyte bonusEffectId)
	{
		Character character = context.Character;
		switch (bonusEffectId)
		{
		case 37:
		{
			sbyte grade = character.GetInteractionGrade();
			return SkillBreakPlateBonusHelper.CreateExp(GradeToExpLevel(grade));
		}
		case 33:
		case 34:
		{
			int charId = character.GetId();
			ushort relationType = (ushort)((bonusEffectId == 33) ? 16384 : 32768);
			int selectedRelatedCharId = SelectRelatedCharForSkillBreakBonus(ref context, charId, relationType);
			if (selectedRelatedCharId < 0)
			{
				break;
			}
			return SkillBreakPlateBonusHelper.CreateRelation(charId, selectedRelatedCharId, relationType);
		}
		default:
		{
			Inventory inventory = character.GetInventory();
			ItemKey selectedItemKey = ItemKey.Invalid;
			int maxGrade = -1;
			sbyte limit = 8;
			foreach (KeyValuePair<ItemKey, int> item in inventory.Items)
			{
				item.Deconstruct(out var key, out var _);
				ItemKey itemKey = key;
				sbyte itemBonusEffectId = ItemTemplateHelper.GetBreakBonusEffect(itemKey.ItemType, itemKey.TemplateId);
				if (itemBonusEffectId == bonusEffectId)
				{
					sbyte itemGrade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
					if (itemGrade > maxGrade && itemGrade <= limit)
					{
						maxGrade = itemGrade;
						selectedItemKey = itemKey;
					}
				}
			}
			if (selectedItemKey.IsValid())
			{
				inventory.OfflineRemove(selectedItemKey, 1);
				_consumedItems.Add(selectedItemKey);
				return SkillBreakPlateBonusHelper.CreateItem(selectedItemKey);
			}
			break;
		}
		}
		return SkillBreakPlateBonus.Invalid;
	}

	private int SelectRelatedCharForSkillBreakBonus(ref BreakPlateBonusContext context, int charId, ushort relationType)
	{
		HashSet<int> relatedCharIds = DomainManager.Character.GetRelatedCharIds(charId, relationType);
		if (relatedCharIds.Count == 0)
		{
			return -1;
		}
		short currFavor = 0;
		int selectedCharId = -1;
		if (context.UsedRelatedCharIds == null)
		{
			InitializeUsedRelatedCharactersForBreakBonus(ref context);
		}
		foreach (int relatedCharId in relatedCharIds)
		{
			if (!DomainManager.Character.IsCharacterAlive(relatedCharId) || !DomainManager.Character.HasRelation(relatedCharId, charId, relationType) || _usedRelatedCharIds.Contains(relatedCharId))
			{
				continue;
			}
			short favor = DomainManager.Character.GetFavorability(charId, relatedCharId);
			if (selectedCharId < 0)
			{
				selectedCharId = relatedCharId;
				currFavor = favor;
			}
			else if (relationType == 32768)
			{
				if (favor < currFavor)
				{
					currFavor = favor;
					selectedCharId = relationType;
				}
			}
			else if (favor > currFavor)
			{
				currFavor = favor;
				selectedCharId = relationType;
			}
		}
		if (selectedCharId >= 0)
		{
			context.UsedRelatedCharIds.Add(selectedCharId);
		}
		return selectedCharId;
	}

	private void InitializeUsedRelatedCharactersForBreakBonus(ref BreakPlateBonusContext context)
	{
		int charId = context.Character.GetId();
		_usedRelatedCharIds.Clear();
		foreach (var (templateId, skill) in context.CharCombatSkills)
		{
			if (!CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState()))
			{
				continue;
			}
			SerializableList<SkillBreakPlateBonus> bonuses = DomainManager.Extra.GetCharacterSkillBreakBonuses(charId, templateId);
			List<SkillBreakPlateBonus> items = bonuses.Items;
			if (items == null || items.Count <= 0)
			{
				continue;
			}
			for (int i = 0; i < bonuses.Items.Count; i++)
			{
				SkillBreakPlateBonus bonus = bonuses.Items[i];
				if (bonus.Type == ESkillBreakPlateBonusType.Relation)
				{
					_usedRelatedCharIds.Add(bonus.RelationRelatedCharId);
				}
			}
		}
		context.UsedRelatedCharIds = _usedRelatedCharIds;
	}

	private unsafe static int CalcCombatSkillPracticeOrBreakoutScore(short skillTemplateId, GameData.Domains.CombatSkill.CombatSkill skill, short selfOrgTemplateId, short targetOrgTemplateId, ref Personalities personalities, sbyte neiliType)
	{
		int score = 0;
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
		if (skillCfg.SectId == selfOrgTemplateId)
		{
			score += 150 + personalities.Items[0];
		}
		if (skillCfg.SectId == targetOrgTemplateId)
		{
			score += 75 + personalities.Items[2];
		}
		if (!CheckCounterWithNeiliType(skillCfg.FiveElements, neiliType))
		{
			score += 150 + personalities.Items[0];
		}
		return score + 50 * (8 - skillCfg.Grade);
	}

	public static short SelectSectCombatSkillToBreakOut(Character character)
	{
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		Personalities personalities = character.GetPersonalities();
		sbyte neiliType = character.GetNeiliType();
		sbyte selfOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte lovingOrgTemplateId = character.GetIdealSect();
		int bestScore = int.MinValue;
		short bestSkillTemplateId = -1;
		foreach (var (skillId, combatSkill2) in combatSkills)
		{
			if (!CombatSkillStateHelper.IsBrokenOut(combatSkill2.GetActivationState()) && combatSkill2.CanBreakout() && combatSkill2.Template.SectId == character.GetOrganizationInfo().OrgTemplateId)
			{
				int score = CalcCombatSkillPracticeOrBreakoutScore(skillId, combatSkill2, selfOrgTemplateId, lovingOrgTemplateId, ref personalities, neiliType);
				if (score > bestScore)
				{
					bestScore = score;
					bestSkillTemplateId = skillId;
				}
			}
		}
		return bestSkillTemplateId;
	}

	public void EquipItems(DataContext context, Character character)
	{
		SelectEquipmentsModification mod = new SelectEquipmentsModification(character, removeUnequippedEquipment: false);
		EquipItems(character, mod);
		if (mod.EquippedItems != null)
		{
			AdaptableLog.Info($"{character} changed equipped items.");
			character.ChangeEquipment(context, mod.EquippedItems);
		}
	}

	private void EquipItems(Character character, SelectEquipmentsModification mod)
	{
		ClassifyAvailableItems(character);
		(ItemKey[] equipments, bool[] slotLocked) tuple = SelectWeapons(character, mod);
		ItemKey[] equipments = tuple.equipments;
		bool[] slotLocked = tuple.slotLocked;
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo());
		PresetEquipmentItemWithProb[] orgEquipment = orgMemberCfg.Equipment;
		_equippedItems[3] = (slotLocked[3] ? equipments[3] : SelectArmor(mod, _availableHelms, orgEquipment[0]));
		_equippedItems[5] = (slotLocked[5] ? equipments[5] : SelectArmor(mod, _availableTorsos, orgEquipment[1]));
		_equippedItems[6] = (slotLocked[6] ? equipments[6] : SelectArmor(mod, _availableBracers, orgEquipment[2]));
		_equippedItems[7] = (slotLocked[7] ? equipments[7] : SelectArmor(mod, _availableBoots, orgEquipment[3]));
		_equippedItems[8] = (slotLocked[8] ? equipments[8] : SelectAccessory(mod, _availableAccessories, orgEquipment[4]));
		_equippedItems[9] = (slotLocked[9] ? equipments[9] : SelectAccessory(mod, _availableAccessories, orgEquipment[5]));
		_equippedItems[10] = (slotLocked[10] ? equipments[10] : SelectAccessory(mod, _availableAccessories, orgEquipment[6]));
		short idealClothingTemplateId = character.GetIdealClothingTemplateId();
		_equippedItems[4] = (slotLocked[4] ? equipments[4] : SelectClothing(character, mod, idealClothingTemplateId));
		_equippedItems[11] = (slotLocked[11] ? equipments[11] : SelectCarrier(mod, _availableCarriers, orgEquipment[7]));
		_equippedItems[12] = (slotLocked[12] ? equipments[12] : SelectCarrier(mod, _availableLivestockCarriers, orgEquipment[8], _availableBeastCarriers));
		_equippedItems[13] = (slotLocked[13] ? equipments[13] : SelectCarrier(mod, _availableBeastCarriers, orgEquipment[9]));
		_equippedItems[14] = (slotLocked[14] ? equipments[14] : SelectAccessory(mod, _availablePockets, orgEquipment[10]));
		_equippedItems[15] = (slotLocked[15] ? equipments[15] : SelectAccessory(mod, _availablePockets, orgEquipment[11]));
		_equippedItems[16] = (slotLocked[16] ? equipments[16] : SelectAccessory(mod, _availablePockets, orgEquipment[12]));
		if (!CollectionUtils.Equals(character.GetEquipment(), _equippedItems, 17))
		{
			mod.EquippedItems = _equippedItems;
			_equippedItems = new ItemKey[17];
		}
	}

	public ItemKey SelectClothing(DataContext context, Character character)
	{
		_availableClothing.Clear();
		ItemKey[] equipment = character.GetEquipment();
		sbyte gender = character.GetGender();
		if (equipment[4].IsValid())
		{
			EquipmentBase item = DomainManager.Item.GetBaseEquipment(equipment[4]);
			AddAvailableItem(item, item.GetEquipmentType(), gender);
		}
		Inventory inventory = character.GetInventory();
		foreach (KeyValuePair<ItemKey, int> item3 in inventory.Items)
		{
			item3.Deconstruct(out var key, out var _);
			ItemKey itemKey = key;
			EquipmentBase item2 = DomainManager.Item.TryGetBaseEquipment(itemKey);
			if (item2 != null && item2.GetEquipmentType() == 2)
			{
				AddAvailableItem(item2, item2.GetEquipmentType(), gender);
			}
		}
		SelectEquipmentsModification modification = new SelectEquipmentsModification(character, removeUnequippedEquipment: false);
		short idealClothingId = character.GetIdealClothingTemplateId();
		ItemKey selectedClothing = SelectClothing(character, modification, idealClothingId);
		if (modification.PersonalNeedChanged)
		{
			character.SetActionPlanningModified(context);
		}
		return selectedClothing;
	}

	private void ClassifyAvailableItems(Character character)
	{
		_availableWeapons.Clear();
		_availableHelms.Clear();
		_availableTorsos.Clear();
		_availableBracers.Clear();
		_availableBoots.Clear();
		_availableAccessories.Clear();
		_availableClothing.Clear();
		_availableCarriers.Clear();
		_availableLivestockCarriers.Clear();
		_availableBeastCarriers.Clear();
		_availablePockets.Clear();
		ItemKey[] equipment = character.GetEquipment();
		sbyte gender = character.GetGender();
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid())
			{
				EquipmentBase item = DomainManager.Item.GetBaseEquipment(itemKey);
				AddAvailableItem(item, item.GetEquipmentType(), gender);
			}
		}
		Inventory inventory = character.GetInventory();
		foreach (KeyValuePair<ItemKey, int> item3 in inventory.Items)
		{
			item3.Deconstruct(out var key, out var _);
			ItemKey itemKey2 = key;
			EquipmentBase item2 = DomainManager.Item.TryGetBaseEquipment(itemKey2);
			if (item2 != null)
			{
				AddAvailableItem(item2, item2.GetEquipmentType(), gender);
			}
		}
	}

	private void AddAvailableItem(EquipmentBase item, sbyte equipmentType, sbyte gender)
	{
		if (item.GetMaxDurability() > 0 && item.GetCurrDurability() <= 0)
		{
			return;
		}
		switch (equipmentType)
		{
		case 0:
			_availableWeapons.Add((item.GetItemKey(), 0));
			break;
		case 1:
			_availableHelms.Add((GameData.Domains.Item.Armor)item);
			break;
		case 2:
		{
			GameData.Domains.Item.Clothing clothing = (GameData.Domains.Item.Clothing)item;
			if (clothing.GetAgeGroup() == 2)
			{
				_availableClothing.Add(clothing);
			}
			break;
		}
		case 3:
			_availableTorsos.Add((GameData.Domains.Item.Armor)item);
			break;
		case 4:
			_availableBracers.Add((GameData.Domains.Item.Armor)item);
			break;
		case 5:
			_availableBoots.Add((GameData.Domains.Item.Armor)item);
			break;
		case 6:
			_availableAccessories.Add((GameData.Domains.Item.Accessory)item);
			break;
		case 10:
			_availablePockets.Add((GameData.Domains.Item.Accessory)item);
			break;
		case 7:
			_availableCarriers.Add((GameData.Domains.Item.Carrier)item);
			break;
		case 8:
			_availableLivestockCarriers.Add((GameData.Domains.Item.Carrier)item);
			break;
		case 9:
			_availableBeastCarriers.Add((GameData.Domains.Item.Carrier)item);
			break;
		default:
			AdaptableLog.TagWarning("AutoEquip", $"Equipment {item.GetItemKey()} has invalid EquipmentType {equipmentType}");
			break;
		}
	}

	public unsafe static bool GetWeaponScores(Character character, List<(ItemKey weapon, int score)> availableWeapons, List<(short itemTemplateId, short count)> suitableWeapons, HashSet<short> fixedBestWeapons)
	{
		suitableWeapons.Clear();
		fixedBestWeapons.Clear();
		byte* intPtr = stackalloc byte[8];
		// IL initblk instruction
		Unsafe.InitBlock(intPtr, 0, 8);
		short* pRequiredHitRates = (short*)intPtr;
		byte* intPtr2 = stackalloc byte[22];
		// IL initblk instruction
		Unsafe.InitBlock(intPtr2, 0, 22);
		byte* pRequiredTricks = intPtr2;
		CombatSkillEquipment combatSkillEquipment = character.GetCombatSkillEquipment();
		CalcAttackSkillsRequirement(combatSkillEquipment, pRequiredHitRates, pRequiredTricks, suitableWeapons, fixedBestWeapons);
		byte* pClonedRequiredTricks = stackalloc byte[22];
		bool hasMatchTricks = false;
		int i = 0;
		for (int weaponsCount = availableWeapons.Count; i < weaponsCount; i++)
		{
			ItemKey weapon = availableWeapons[i].weapon;
			int score = CalcWeaponScore(weapon, pRequiredTricks, pClonedRequiredTricks, pRequiredHitRates, ref hasMatchTricks, suitableWeapons, fixedBestWeapons);
			availableWeapons[i] = (weapon, score);
		}
		return hasMatchTricks;
	}

	private unsafe static int CalcWeaponScore(ItemKey itemKey, byte* pRequiredTricks, byte* pClonedRequiredTricks, short* pRequiredHitRates, ref bool hasMatchTricks, List<(short itemTemplateId, short count)> suitableWeapons, HashSet<short> fixedBestWeapons)
	{
		WeaponItem weaponConfig = Config.Weapon.Instance[itemKey.TemplateId];
		int score = weaponConfig.Grade * 200;
		if (!itemKey.IsValid())
		{
			return score;
		}
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetBaseItem(itemKey) as GameData.Domains.Item.Weapon;
		if (ModificationStateHelper.IsActive(1, weapon.GetModificationState()))
		{
			PoisonsAndLevels attachedPoisons = DomainManager.Item.GetAttachedPoisons(weapon.GetItemKey());
			for (sbyte poisonType = 0; poisonType < 6; poisonType++)
			{
				short value = attachedPoisons.Values[poisonType];
				sbyte poisonsLevel = attachedPoisons.Levels[poisonType];
				score += value * poisonsLevel * 2;
			}
		}
		Buffer.MemoryCopy(pRequiredTricks, pClonedRequiredTricks, 22L, 22L);
		int matchedTricksCount = CalcMatchedTricksCount(pClonedRequiredTricks, weapon);
		short maxDurability = weapon.GetMaxDurability();
		if (maxDurability > 0)
		{
			score = score * weapon.GetCurrDurability() / maxDurability;
		}
		if (matchedTricksCount > 0)
		{
			score += matchedTricksCount * 10;
			hasMatchTricks = true;
			short baseItemTemplateId = (short)(itemKey.TemplateId - weaponConfig.Grade);
			score += GetSuitableWeaponCount(baseItemTemplateId, suitableWeapons) * 300;
			if (fixedBestWeapons.Contains(itemKey.TemplateId))
			{
				score += 900;
			}
			HitOrAvoidShorts hitFactors = weapon.GetHitFactors();
			for (int hitType = 0; hitType < 4; hitType++)
			{
				score += pRequiredHitRates[hitType] * hitFactors.Items[hitType] / 150;
			}
			score += 65536;
		}
		return score;
	}

	private bool MatchCombatSkillByCombatConfig(short combatSkillTemplateId, CombatConfigItem combatConfig)
	{
		CombatSkillItem combatSkillCfg = Config.CombatSkill.Instance[combatSkillTemplateId];
		if (combatSkillCfg.EquipType == 4 || combatSkillCfg.EquipType == 0)
		{
			return true;
		}
		if (combatConfig.Sect >= 0 && combatConfig.Sect != combatSkillCfg.SectId)
		{
			return false;
		}
		if (combatConfig.CombatSkillType != null && combatConfig.CombatSkillType.Count > 0 && !combatConfig.CombatSkillType.Contains(combatSkillCfg.Type))
		{
			return false;
		}
		return true;
	}

	private (ItemKey[] equipments, bool[] slotLocked) SelectWeapons(Character character, SelectEquipmentsModification mod)
	{
		if (!GetWeaponScores(character, _availableWeapons, _suitableWeapons, _fixedBestWeapons))
		{
			foreach (short weaponId in _fixedBestWeapons)
			{
				character.OfflineAddGoal(238, (sbyte)0, weaponId);
				mod.PersonalNeedChanged = true;
			}
			foreach (var suitableWeapon in _suitableWeapons)
			{
				short suitableWeaponId = suitableWeapon.itemTemplateId;
				character.OfflineAddGoal(238, (sbyte)0, suitableWeaponId);
				mod.PersonalNeedChanged = true;
			}
		}
		ItemKey[] equipments = character.GetEquipment();
		bool[] locks = Config.Character.Instance.GetItemOrDefault(character.GetTemplateId())?.EquipmentLock ?? Array.Empty<bool>();
		bool[] slotLocked = equipments.Select((ItemKey x, int i) => locks.CheckIndex(i) && locks[i]).ToArray();
		_equippedItems[0] = (slotLocked[0] ? equipments[0] : SelectBestWeapon(removeSameType: true));
		_equippedItems[1] = (slotLocked[1] ? equipments[1] : SelectBestWeapon(removeSameType: true));
		_equippedItems[2] = (slotLocked[2] ? equipments[2] : SelectBestWeapon(removeSameType: false));
		return (equipments: equipments, slotLocked: slotLocked);
	}

	private void SelectFixedWeapons(Character character, SelectEquipmentsModification mod)
	{
		CharacterItem charConfig = Config.Character.Instance[character.GetTemplateId()];
		for (sbyte slot = 0; slot <= 2; slot++)
		{
			PresetEquipmentItem presetWeapon = charConfig.PresetEquipment[slot];
			if (presetWeapon.TemplateId < 0)
			{
				_equippedItems[slot] = ItemKey.Invalid;
			}
			else
			{
				int weaponIndex = _availableWeapons.FindIndex(((ItemKey weapon, int score) pair) => pair.weapon.TemplateId == presetWeapon.TemplateId);
				ItemKey selectedWeapon = _availableWeapons[weaponIndex].weapon;
				_availableWeapons.RemoveAt(weaponIndex);
				_equippedItems[slot] = selectedWeapon;
			}
		}
	}

	private unsafe static void CalcAttackSkillsRequirement(CombatSkillEquipment skillEquipment, short* pRequiredHitRates, byte* pRequiredTricks, List<(short itemTemplateId, short count)> suitableWeapons, HashSet<short> fixedBestWeapons)
	{
		ArraySegmentList<short>.Enumerator enumerator = skillEquipment.Attack.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillTemplateId = enumerator.Current;
			if (skillTemplateId >= 0)
			{
				CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
				if (skillConfig.MostFittingWeaponID >= 0)
				{
					RecordSuitableWeapon(skillConfig.MostFittingWeaponID, suitableWeapons);
				}
				if (skillConfig.FixedBestWeaponID >= 0)
				{
					fixedBestWeapons.Add(skillConfig.FixedBestWeaponID);
				}
				if (!CombatSkillEquipType.IsMindHitSkill(skillTemplateId))
				{
					pRequiredHitRates[2] += skillConfig.PerHitDamageRateDistribution[0];
					pRequiredHitRates[1] += skillConfig.PerHitDamageRateDistribution[1];
					*pRequiredHitRates += skillConfig.PerHitDamageRateDistribution[2];
				}
				else
				{
					pRequiredHitRates[3] += skillConfig.PerHitDamageRateDistribution[3];
				}
				List<NeedTrick> tricks = skillConfig.TrickCost;
				int trickIdx = 0;
				for (int tricksCount = tricks.Count; trickIdx < tricksCount; trickIdx++)
				{
					NeedTrick trick = tricks[trickIdx];
					byte* num = pRequiredTricks + trick.TrickType;
					*num += trick.NeedCount;
				}
			}
		}
	}

	private unsafe static bool CalcWeaponScores(short* pRequiredHitRates, byte* pRequiredTricks, List<(GameData.Domains.Item.Weapon weapon, int score)> availableWeapons, List<(short itemTemplateId, short count)> suitableWeapons)
	{
		byte* pClonedRequiredTricks = stackalloc byte[22];
		bool hasMatchTricks = false;
		int i = 0;
		for (int weaponsCount = availableWeapons.Count; i < weaponsCount; i++)
		{
			GameData.Domains.Item.Weapon weapon = availableWeapons[i].weapon;
			short weaponTemplateId = weapon.GetTemplateId();
			WeaponItem weaponConfig = Config.Weapon.Instance[weaponTemplateId];
			Buffer.MemoryCopy(pRequiredTricks, pClonedRequiredTricks, 22L, 22L);
			int matchedTricksCount = CalcMatchedTricksCount(pClonedRequiredTricks, weapon);
			int score = (matchedTricksCount * 50 + weaponConfig.Grade * 200) * weapon.GetCurrDurability() / weapon.GetMaxDurability();
			if (matchedTricksCount > 0)
			{
				hasMatchTricks = true;
				short baseItemTemplateId = (short)(weaponTemplateId - weaponConfig.Grade);
				score += GetSuitableWeaponCount(baseItemTemplateId, suitableWeapons) * 300;
				HitOrAvoidShorts hitFactors = weapon.GetHitFactors();
				for (int hitType = 0; hitType < 4; hitType++)
				{
					score += pRequiredHitRates[hitType] * hitFactors.Items[hitType] / 150;
				}
				score += 65536;
			}
			availableWeapons[i] = (weapon, score);
		}
		return hasMatchTricks;
	}

	private ItemKey SelectBestWeapon(bool removeSameType)
	{
		int availableWeaponsCount = _availableWeapons.Count;
		if (availableWeaponsCount <= 0)
		{
			return ItemKey.Invalid;
		}
		int maxScore = int.MinValue;
		int selectedIdx = 0;
		for (int i = 0; i < availableWeaponsCount; i++)
		{
			int score = _availableWeapons[i].score;
			if (score > maxScore)
			{
				maxScore = score;
				selectedIdx = i;
			}
		}
		ItemKey selectedWeapon = _availableWeapons[selectedIdx].weapon;
		if (removeSameType)
		{
			CollectionUtils.SwapAndRemove(_availableWeapons, selectedIdx);
			WeaponItem selectedWeaponConfig = Config.Weapon.Instance[selectedWeapon.TemplateId];
			short selectedItemSubType = selectedWeaponConfig.ItemSubType;
			int j = 0;
			for (int count = _availableWeapons.Count; j < count; j++)
			{
				ItemKey currWeapon = _availableWeapons[j].weapon;
				WeaponItem currWeaponConfig = Config.Weapon.Instance[currWeapon.TemplateId];
				short currItemSubType = currWeaponConfig.ItemSubType;
				if (currItemSubType == selectedItemSubType && currItemSubType != 16)
				{
					CollectionUtils.SwapAndRemove(_availableWeapons, j);
					count--;
					j--;
				}
			}
		}
		return selectedWeapon;
	}

	private static void RecordSuitableWeapon(short itemTemplateId, List<(short itemTemplateId, short count)> suitableWeapons)
	{
		int index = -1;
		int i = 0;
		for (int count = suitableWeapons.Count; i < count; i++)
		{
			if (suitableWeapons[i].itemTemplateId == itemTemplateId)
			{
				index = i;
				break;
			}
		}
		if (index >= 0)
		{
			suitableWeapons[index] = (itemTemplateId, (short)(suitableWeapons[index].count + 1));
		}
		else
		{
			suitableWeapons.Add((itemTemplateId, 1));
		}
	}

	private static int GetSuitableWeaponCount(short itemTemplateId, List<(short itemTemplateId, short count)> suitableWeapons)
	{
		int index = -1;
		int i = 0;
		for (int count = suitableWeapons.Count; i < count; i++)
		{
			if (suitableWeapons[i].itemTemplateId == itemTemplateId)
			{
				index = i;
				break;
			}
		}
		return (index >= 0) ? suitableWeapons[index].count : 0;
	}

	private unsafe static int CalcMatchedTricksCount(byte* pClonedRequiredTricks, GameData.Domains.Item.Weapon weapon)
	{
		int matchedTricksCount = 0;
		List<sbyte> weaponTricks = weapon.GetTricks();
		int i = 0;
		for (int tricksCount = weaponTricks.Count; i < tricksCount; i++)
		{
			sbyte trickType = weaponTricks[i];
			byte requiredTrickCount = pClonedRequiredTricks[trickType];
			if (requiredTrickCount > 0)
			{
				pClonedRequiredTricks[trickType] = (byte)(requiredTrickCount - 1);
				matchedTricksCount++;
			}
		}
		return matchedTricksCount;
	}

	private ItemKey SelectClothing(Character character, SelectEquipmentsModification mod, short orgClothingTemplateId)
	{
		if (character.GetAgeGroup() != 2)
		{
			return character.GetEquipment()[4];
		}
		if (orgClothingTemplateId >= 0)
		{
			ItemKey clothingKey = SelectOrgClothing(character, orgClothingTemplateId);
			if (clothingKey.IsValid())
			{
				return clothingKey;
			}
			character.OfflineAddGoal(238, (sbyte)3, orgClothingTemplateId);
			mod.PersonalNeedChanged = true;
		}
		int maxScore = int.MinValue;
		int selectedIdx = -1;
		int i = 0;
		for (int count = _availableClothing.Count; i < count; i++)
		{
			GameData.Domains.Item.Clothing item = _availableClothing[i];
			int score = CalcEquipmentScore(item.GetItemKey(), -1).score;
			if (score > maxScore)
			{
				maxScore = score;
				selectedIdx = i;
			}
		}
		return (selectedIdx >= 0) ? _availableClothing[selectedIdx].GetItemKey() : ItemKey.Invalid;
	}

	private ItemKey SelectOrgClothing(Character character, short orgClothingTemplateId)
	{
		ItemKey clothingKey = character.GetEquipment()[4];
		if (clothingKey.IsValid() && clothingKey.TemplateId == orgClothingTemplateId)
		{
			return clothingKey;
		}
		int i = 0;
		for (int count = _availableClothing.Count; i < count; i++)
		{
			GameData.Domains.Item.Clothing currClothing = _availableClothing[i];
			if (currClothing.GetTemplateId() == orgClothingTemplateId)
			{
				return currClothing.GetItemKey();
			}
		}
		return ItemKey.Invalid;
	}

	private static ItemKey SelectEquipment<T>(SelectEquipmentsModification mod, List<T> availableEquipments, PresetEquipmentItemWithProb orgEquipment) where T : ItemBase
	{
		bool hasMeetOrgRequirement = false;
		int equipmentsCount = availableEquipments.Count;
		int maxScore = int.MinValue;
		int selectedIdx = 0;
		sbyte expectedGrade = mod.Character.GetOrganizationInfo().Grade;
		for (int i = 0; i < equipmentsCount; i++)
		{
			T item = availableEquipments[i];
			(int score, bool meetReq) tuple = CalcEquipmentScore(item.GetItemKey(), orgEquipment.TemplateId);
			int score = tuple.score;
			bool itemMeetReq = tuple.meetReq;
			hasMeetOrgRequirement = hasMeetOrgRequirement || itemMeetReq;
			if (score > maxScore)
			{
				maxScore = score;
				selectedIdx = i;
			}
		}
		if (!hasMeetOrgRequirement && orgEquipment.TemplateId >= 0)
		{
			short targetItemTemplateId = ItemTemplateHelper.GetTemplateIdInGroup(orgEquipment.Type, orgEquipment.TemplateId, expectedGrade);
			mod.Character.OfflineAddGoal(238, orgEquipment.Type, targetItemTemplateId);
			mod.PersonalNeedChanged = true;
		}
		if (equipmentsCount <= 0)
		{
			return ItemKey.Invalid;
		}
		ItemKey itemKey = availableEquipments[selectedIdx].GetItemKey();
		CollectionUtils.SwapAndRemove(availableEquipments, selectedIdx);
		return itemKey;
	}

	private static ItemKey SelectArmor(SelectEquipmentsModification mod, List<GameData.Domains.Item.Armor> availableArmors, PresetEquipmentItemWithProb orgEquipment)
	{
		return SelectEquipment(mod, availableArmors, orgEquipment);
	}

	private static ItemKey SelectAccessory(SelectEquipmentsModification mod, List<GameData.Domains.Item.Accessory> availableAccessories, PresetEquipmentItemWithProb orgEquipment)
	{
		return SelectEquipment(mod, availableAccessories, orgEquipment);
	}

	private static ItemKey SelectCarrier(SelectEquipmentsModification mod, List<GameData.Domains.Item.Carrier> availableCarriers, PresetEquipmentItemWithProb orgEquipment, List<GameData.Domains.Item.Carrier> extraCarriers = null)
	{
		if (extraCarriers == null || extraCarriers.Count == 0)
		{
			return SelectEquipment(mod, availableCarriers, orgEquipment);
		}
		ItemKey item = SelectEquipment(mod, extraCarriers.Concat(availableCarriers).ToList(), orgEquipment);
		availableCarriers.RemoveAll((GameData.Domains.Item.Carrier carrier) => carrier.GetItemKey() == item);
		extraCarriers.RemoveAll((GameData.Domains.Item.Carrier carrier) => carrier.GetItemKey() == item);
		return item;
	}

	public static (int score, bool meetReq) CalcEquipmentScore(ItemKey itemKey, int expectedItemGroupTemplateId)
	{
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		int score = grade * 200;
		bool meetReq = expectedItemGroupTemplateId >= 0 && itemKey.TemplateId >= expectedItemGroupTemplateId && itemKey.TemplateId <= expectedItemGroupTemplateId + 8;
		if (meetReq)
		{
			score += 300;
		}
		if (itemKey.IsValid())
		{
			ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
			short currDurability = itemBase.GetCurrDurability();
			short maxDurability = itemBase.GetMaxDurability();
			score = ((maxDurability <= 0) ? score : ((currDurability == 0) ? (-1) : (score * currDurability / maxDurability)));
		}
		return (score: score, meetReq: meetReq);
	}

	[Obsolete]
	private static bool MeetOrgRequirement(short itemTemplateId, PresetEquipmentItemWithProb orgEquipment)
	{
		return orgEquipment.TemplateId >= 0 && itemTemplateId >= orgEquipment.TemplateId && itemTemplateId <= orgEquipment.TemplateId + 8;
	}

	private void ChooseLoopingNeigong(Character character, SelectEquipmentsModification mod)
	{
		_candidateCombatSkillsForLooping.Clear();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> charCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(character.GetId());
		foreach (var (skillTemplateId, skill) in charCombatSkills)
		{
			if (CharacterDomain.IsLoopable(skill))
			{
				CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
				bool canObtainNeili = skill.GetObtainedNeili() < skill.GetTotalObtainableNeili();
				_candidateCombatSkillsForLooping.Add((skillCfg, canObtainNeili));
			}
		}
		short loopingNeigong = SelectCombatSkillForLooping(character, _candidateCombatSkillsForLooping);
		if (loopingNeigong != character.GetLoopingNeigong())
		{
			mod.LoopingNeigongChanged = true;
			mod.LoopingNeigong = loopingNeigong;
		}
	}

	private static short SelectCombatSkillForLooping(Character character, List<(CombatSkillItem skillCfg, bool canObtainNeili)> candidates)
	{
		sbyte selfOrgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte selfOrgElementType = Config.Organization.Instance[selfOrgTemplateId].FiveElementsType;
		sbyte lovingOrgTemplateId = character.GetIdealSect();
		sbyte lovingOrgElementType = (sbyte)((lovingOrgTemplateId >= 0) ? Config.Organization.Instance[lovingOrgTemplateId].FiveElementsType : (-1));
		short selectedSkillTemplateId = -1;
		int maxScore = -1;
		int i = 0;
		for (int count = candidates.Count; i < count; i++)
		{
			(CombatSkillItem skillCfg, bool canObtainNeili) tuple = candidates[i];
			CombatSkillItem skillConfig = tuple.skillCfg;
			bool canObtainNeili = tuple.canObtainNeili;
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillConfig.TemplateId));
			sbyte transferFromType = (sbyte)((skill.GetFiveElementsChange() > 0 && skillConfig.TransferTypeWhileLooping >= 0) ? NeiliProportionOfFiveElements.GetTransferSource(skillConfig.TransferTypeWhileLooping, skillConfig.DestTypeWhileLooping) : (-1));
			int score = 0;
			score += _formulas.LoopingScoreGrade.Calculate(skillConfig.Grade);
			if (canObtainNeili)
			{
				score += _formulas.LoopingScorePotentialNeili;
			}
			if (selfOrgElementType >= 0)
			{
				if (!CheckCounterWithTargetFiveElementsType(skillConfig.FiveElements, selfOrgElementType))
				{
					score += _formulas.LoopingScoreCurrSectNotCounter;
				}
				if (skillConfig.DestTypeWhileLooping == selfOrgElementType)
				{
					score += _formulas.LoopingScoreCurrSectDestType;
				}
				if (CheckCounterWithTargetFiveElementsType(transferFromType, selfOrgElementType))
				{
					score += _formulas.LoopingScoreCurrSectTransferCounter;
				}
			}
			if (lovingOrgElementType >= 0)
			{
				if (!CheckCounterWithTargetFiveElementsType(skillConfig.FiveElements, lovingOrgElementType))
				{
					score += _formulas.LoopingScoreIdealSectNotCounter;
				}
				if (skillConfig.DestTypeWhileLooping == lovingOrgElementType)
				{
					score += _formulas.LoopingScoreIdealSectDestType;
				}
				if (CheckCounterWithTargetFiveElementsType(transferFromType, lovingOrgElementType))
				{
					score += _formulas.LoopingScoreIdealSectTransferCounter;
				}
			}
			if (CanObtainExtraNeiliAllocationProgressFromSkill(character, skillConfig))
			{
				score += _formulas.LoopingScorePotentialExtraAllocation;
			}
			if (score > maxScore)
			{
				selectedSkillTemplateId = skillConfig.TemplateId;
				maxScore = score;
			}
		}
		return (short)((maxScore >= 0) ? selectedSkillTemplateId : (-1));
	}

	private CombatSkillItem SelectCombatSkillForAdjustingNeiliType(Character character, List<(CombatSkillItem skillCfg, int index)> brokenOutNeigongList)
	{
		_candidateCombatSkillsForLooping.Clear();
		int i = 0;
		for (int count = brokenOutNeigongList.Count; i < count; i++)
		{
			CombatSkillItem skillCfg = brokenOutNeigongList[i].skillCfg;
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg.TemplateId));
			if (skill.GetFiveElementsChange() > 0 && skillCfg.TransferTypeWhileLooping >= 0)
			{
				_candidateCombatSkillsForLooping.Add((skillCfg, false));
			}
		}
		short skillTemplateId = SelectCombatSkillForLooping(character, _candidateCombatSkillsForLooping);
		return (skillTemplateId < 0) ? null : Config.CombatSkill.Instance[skillTemplateId];
	}

	private static bool CanObtainExtraNeiliAllocationProgressFromSkill(Character character, CombatSkillItem skillCfg)
	{
		sbyte[] extraProgressCfg = skillCfg.ExtraNeiliAllocationProgress;
		int[] currentProgress = character.GetExtraNeiliAllocationProgress();
		for (int neiliAllocationType = 0; neiliAllocationType < 4; neiliAllocationType++)
		{
			sbyte configProgressDelta = extraProgressCfg[neiliAllocationType];
			if (configProgressDelta > 0)
			{
				int newProgress = Math.Min(100 * GlobalConfig.Instance.ExtraNeiliAllocationFromProgressRatio * GlobalConfig.Instance.MaxExtraNeiliAllocation, configProgressDelta * 100 + currentProgress[neiliAllocationType]);
				if (newProgress > currentProgress[neiliAllocationType])
				{
					return true;
				}
			}
		}
		return false;
	}

	public unsafe void AllocateNeili(DataContext context, Character character)
	{
		sbyte* skillSlotTotalCounts = stackalloc sbyte[5];
		SelectEquipmentsModification mod = new SelectEquipmentsModification(character, removeUnequippedEquipment: false);
		AllocateNeili(character, skillSlotTotalCounts, mod);
		if (mod.NeiliAllocationChanged)
		{
			character.SpecifyBaseNeiliAllocation(context, mod.NeiliAllocation);
		}
	}

	private unsafe static void AllocateNeili(Character character, sbyte* skillSlotTotalCounts, SelectEquipmentsModification mod)
	{
		sbyte neiliType = character.GetNeiliType();
		sbyte[] proportions = NeiliType.Instance[neiliType].IdeaAllocationProportion;
		CharacterItem template = Config.Character.Instance[character.GetTemplateId()];
		if (character.GetCreatingType() == 0 && template.IdeaAllocationProportion.Sum() > 0)
		{
			proportions = template.IdeaAllocationProportion;
		}
		sbyte* pProportions = stackalloc sbyte[4]
		{
			proportions[0],
			proportions[1],
			proportions[2],
			proportions[3]
		};
		NeiliAllocation allocations = FindBestNeiliAllocation(character, pProportions);
		NeiliAllocation oriAllocations = character.GetBaseNeiliAllocation();
		if (!NeiliAllocation.Equals(oriAllocations, allocations))
		{
			mod.NeiliAllocationChanged = true;
			mod.NeiliAllocation = allocations;
		}
	}

	private unsafe static void CalcNeiliAllocationProportions(sbyte* skillSlotTotalCounts, sbyte* pProportions)
	{
		for (int i = 0; i < 4; i++)
		{
			pProportions[i] = (sbyte)Math.Max(skillSlotTotalCounts[i + 1] + 6, 6);
		}
	}

	private unsafe static NeiliAllocation FindBestNeiliAllocation(Character character, sbyte* pProportions)
	{
		sbyte* pAllocationTypes = stackalloc sbyte[4] { 0, 1, 2, 3 };
		Span<sbyte> proportions = new Span<sbyte>(pProportions, 4);
		Span<sbyte> allocationTypes = new Span<sbyte>(pAllocationTypes, 4);
		proportions.Sort(allocationTypes, ReverseComparer);
		short proportionSum = (short)(*pProportions + pProportions[1] + pProportions[2] + pProportions[3]);
		short maxTotalAllocation = CombatHelper.GetMaxTotalNeiliAllocationConsideringFeature(character.GetConsummateLevel(), character.GetFeatureIds(), DomainManager.World.GetChallengeModeData());
		NeiliAllocation allocations = CalcNeiliAllocation(pProportions, proportionSum, maxTotalAllocation);
		int availableNeili = character.GetPureCurrNeili();
		if (CombatHelper.CalcRequiredNeili(allocations) <= availableNeili)
		{
			return RestorePositions(allocations, pAllocationTypes);
		}
		allocations = BinarySearch(pProportions, proportionSum, maxTotalAllocation, availableNeili);
		allocations = RestorePositions(allocations, pAllocationTypes);
		Tester.Assert(CombatHelper.CalcRequiredNeili(allocations) <= availableNeili);
		short totalAllocation = allocations.GetTotal();
		NeiliAllocation tmpAllocations = CalcNeiliAllocation(pProportions, proportionSum, totalAllocation + 1);
		Tester.Assert(CombatHelper.CalcRequiredNeili(tmpAllocations) > availableNeili);
		return allocations;
	}

	private unsafe static NeiliAllocation BinarySearch(sbyte* pProportions, int proportionSum, int maxTotalAllocation, int availableNeili)
	{
		int low = 0;
		int high = maxTotalAllocation;
		while (low <= high)
		{
			int middle = low + (high - low) / 2;
			NeiliAllocation allocations = CalcNeiliAllocation(pProportions, proportionSum, middle);
			int comparison = CombatHelper.CalcRequiredNeili(allocations) - availableNeili;
			if (comparison == 0)
			{
				return allocations;
			}
			if (comparison < 0)
			{
				low = middle + 1;
			}
			else
			{
				high = middle - 1;
			}
		}
		int targetTotalAllocation = low - 1;
		if (targetTotalAllocation > 0)
		{
			return CalcNeiliAllocation(pProportions, proportionSum, targetTotalAllocation);
		}
		NeiliAllocation allocation = default(NeiliAllocation);
		allocation.Initialize();
		return allocation;
	}

	private unsafe static NeiliAllocation CalcNeiliAllocation(sbyte* pProportions, int proportionSum, int totalAllocation)
	{
		int leftProportionSum = proportionSum;
		int leftTotalAllocation = totalAllocation;
		NeiliAllocation allocations = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			sbyte currProportion = pProportions[i];
			int currAllocation = leftTotalAllocation * currProportion / leftProportionSum;
			if (currAllocation > 100)
			{
				currAllocation = 100;
			}
			allocations.Items[i] = (short)currAllocation;
			leftTotalAllocation -= currAllocation;
			leftProportionSum -= currProportion;
		}
		return allocations;
	}

	private unsafe static NeiliAllocation RestorePositions(NeiliAllocation allocations, sbyte* pAllocationTypes)
	{
		NeiliAllocation restored = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			sbyte type = pAllocationTypes[i];
			restored.Items[type] = allocations.Items[i];
		}
		return restored;
	}

	public (GameData.Domains.Item.SkillBook book, int learnedSkillIndex, byte readingPage) GetCurrReadingBook(Character character)
	{
		_availableReadingBooks.Clear();
		List<ItemKey> readableBookList = ObjectPool<List<ItemKey>>.Instance.Get();
		character.GetReadableBookList(readableBookList);
		foreach (ItemKey itemKey in readableBookList)
		{
			GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
			int learnedSkillIndex;
			byte readingPage;
			if (book.IsCombatSkillBook())
			{
				(learnedSkillIndex, readingPage) = character.GetCombatSkillBookCurrReadingInfo(book);
			}
			else
			{
				(learnedSkillIndex, readingPage) = character.GetLifeSkillBookCurrReadingInfo(book);
			}
			_availableReadingBooks.Add((book, learnedSkillIndex, readingPage));
		}
		ObjectPool<List<ItemKey>>.Instance.Return(readableBookList);
		if (_availableReadingBooks.Count == 0)
		{
			return (book: null, learnedSkillIndex: -1, readingPage: 0);
		}
		_hasPersonalNeedToReadBooks.Clear();
		_hasPersonalNeedToLearnCombatSkillTypes.Clear();
		_hasPersonalNeedToLearnLifeSkillTypes.Clear();
		foreach (CharacterGoalData personalNeed in character.GetGoals())
		{
			if (personalNeed.GoalTemplateId == 246)
			{
				_hasPersonalNeedToLearnCombatSkillTypes.Add(personalNeed.Args.CombatSkillType);
			}
			else if (personalNeed.GoalTemplateId == 247)
			{
				_hasPersonalNeedToLearnLifeSkillTypes.Add(personalNeed.Args.LifeSkillType);
			}
		}
		int indexWithMaxScore = -1;
		int maxScore = int.MinValue;
		int indexWithMinAttainmentDiff = -1;
		int minAttainmentDiff = int.MaxValue;
		int scoreOfMinAttainmentDiff = int.MinValue;
		for (int i = 0; i < _availableReadingBooks.Count; i++)
		{
			GameData.Domains.Item.SkillBook book2 = _availableReadingBooks[i].book;
			sbyte bookGrade = book2.GetGrade();
			short needAttainment = SkillGradeData.Instance[bookGrade].ReadingAttainmentRequirement;
			SkillBookItem bookConfig = Config.SkillBook.Instance[book2.GetItemKey().TemplateId];
			short attainment;
			int score = CalcSkillBookScore(book2, bookConfig, character, _hasPersonalNeedToLearnCombatSkillTypes, _hasPersonalNeedToLearnLifeSkillTypes, out attainment);
			if (score > maxScore)
			{
				maxScore = score;
				indexWithMaxScore = i;
			}
			int diff = attainment - needAttainment;
			if (diff >= 0 && diff < minAttainmentDiff)
			{
				minAttainmentDiff = diff;
				indexWithMinAttainmentDiff = i;
				scoreOfMinAttainmentDiff = score;
			}
		}
		if (indexWithMinAttainmentDiff >= 0)
		{
			scoreOfMinAttainmentDiff += 50;
		}
		return (scoreOfMinAttainmentDiff > maxScore) ? _availableReadingBooks[indexWithMinAttainmentDiff] : _availableReadingBooks[indexWithMaxScore];
	}

	private unsafe static int CalcSkillBookScore(GameData.Domains.Item.SkillBook book, SkillBookItem bookConfig, Character character, List<sbyte> needToLearnCombatSkillTypes, List<sbyte> needToLearnLifeSkillTypes, out short attainment)
	{
		short roleTemplateId = DomainManager.Extra.GetVillagerRoleTemplateId(character.GetId());
		CombatSkillShorts combatSkillAttainments = character.GetCombatSkillAttainments();
		LifeSkillShorts lifeSkillAttainments = character.GetLifeSkillAttainments();
		CombatSkillShorts combatSkillQualifications = character.GetCombatSkillQualifications();
		LifeSkillShorts lifeSkillQualifications = character.GetLifeSkillQualifications();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		sbyte lovingOrgMemberId = character.GetIdealSect();
		OrganizationMemberItem lovingOrgMemberCfg = OrganizationDomain.GetOrgMemberConfig((lovingOrgMemberId >= 0) ? lovingOrgMemberId : orgInfo.OrgTemplateId, orgInfo.Grade);
		OrganizationMemberItem selfOrgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgInfo.OrgTemplateId, orgInfo.Grade);
		VillagerWorkData workData = DomainManager.Extra.GetVillagerRole(character.GetId())?.WorkData;
		int num;
		if (workData != null && DomainManager.Building.TryGetElement_BuildingBlocks(new BuildingBlockKey(workData.AreaId, workData.BlockId, workData.BuildingBlockIndex), out var blockData))
		{
			BuildingBlockItem data = blockData?.ConfigData;
			if (data != null)
			{
				num = ((bookConfig.CombatSkillType >= 0) ? data.RequireCombatSkillType : data.RequireLifeSkillType);
				goto IL_0100;
			}
		}
		num = -1;
		goto IL_0100;
		IL_0100:
		int workerPreferredSkill = num;
		int score;
		if (bookConfig.CombatSkillType >= 0)
		{
			sbyte skillType = bookConfig.CombatSkillType;
			attainment = combatSkillAttainments.Items[skillType];
			score = CalcCombatSkillBookScore(book, skillType, selfOrgMemberCfg, lovingOrgMemberCfg, ref combatSkillQualifications, roleTemplateId, needToLearnCombatSkillTypes);
			if (workerPreferredSkill == bookConfig.CombatSkillType)
			{
				score += _formulas.ReadingScoreBuildingRequiredType;
			}
		}
		else
		{
			sbyte skillType2 = bookConfig.LifeSkillType;
			attainment = lifeSkillAttainments.Items[skillType2];
			score = CalcLifeSkillBookScore(book, skillType2, selfOrgMemberCfg, lovingOrgMemberCfg, ref lifeSkillQualifications, roleTemplateId, needToLearnLifeSkillTypes);
			if (workerPreferredSkill == bookConfig.LifeSkillType)
			{
				score += _formulas.ReadingScoreBuildingRequiredType;
			}
		}
		return score;
	}

	private unsafe static int CalcCombatSkillBookScore(GameData.Domains.Item.SkillBook book, sbyte combatSkillType, OrganizationMemberItem selfOrgMemberCfg, OrganizationMemberItem lovingOrgMemberCfg, ref CombatSkillShorts qualifications, short roleTemplateId, List<sbyte> needToLearnSkillTypes)
	{
		int score = 0;
		int selfAdjust = selfOrgMemberCfg.GetEffectiveCombatSkillAdjust(combatSkillType);
		score += _formulas.ReadingScoreCurrSectAdjust.Calculate(selfAdjust);
		int idealSectAdjust = lovingOrgMemberCfg.GetEffectiveCombatSkillAdjust(combatSkillType);
		score += _formulas.ReadingScoreIdealSectAdjust.Calculate(idealSectAdjust);
		score += _formulas.ReadingScoreQualification.Calculate(qualifications.Items[combatSkillType]);
		score += CalcIncompleteStateScore(book);
		if (needToLearnSkillTypes != null && needToLearnSkillTypes.Contains(combatSkillType))
		{
			score += _formulas.ReadingScorePersonalNeed;
		}
		if (roleTemplateId == 5)
		{
			score += _formulas.ReadingScorePersonalNeed;
		}
		return score;
	}

	private unsafe static int CalcLifeSkillBookScore(GameData.Domains.Item.SkillBook book, sbyte lifeSkillType, OrganizationMemberItem selfOrgMemberCfg, OrganizationMemberItem lovingOrgMemberCfg, ref LifeSkillShorts qualifications, short roleTemplateId, List<sbyte> needToLearnSkillTypes)
	{
		int score = 0;
		int selfAdjust = selfOrgMemberCfg.GetEffectiveLifeSkillAdjust(lifeSkillType);
		score += _formulas.ReadingScoreCurrSectAdjust.Calculate(selfAdjust);
		int idealSectAdjust = lovingOrgMemberCfg.GetEffectiveLifeSkillAdjust(lifeSkillType);
		score += _formulas.ReadingScoreIdealSectAdjust.Calculate(idealSectAdjust);
		score += _formulas.ReadingScoreQualification.Calculate(qualifications.Items[lifeSkillType]);
		score += CalcIncompleteStateScore(book);
		if (needToLearnSkillTypes != null && needToLearnSkillTypes.Contains(lifeSkillType))
		{
			score += _formulas.ReadingScorePersonalNeed;
		}
		HashSet<sbyte> lifeSkillTypes = TaiwuDomain.VillagerRoleNeedLifeSkillBooks[roleTemplateId];
		if (lifeSkillTypes != null && lifeSkillTypes.Contains(lifeSkillType))
		{
			score += _formulas.ReadingScorePersonalNeed;
		}
		return score;
	}

	private static int CalcIncompleteStateScore(GameData.Domains.Item.SkillBook book)
	{
		if (book == null)
		{
			return 0;
		}
		int score = 0;
		byte pageCount = book.GetPageCount();
		ushort pageIncompleteState = book.GetPageIncompleteState();
		for (byte pageId = 0; pageId < pageCount; pageId++)
		{
			sbyte incompleteState = SkillBookStateHelper.GetPageIncompleteState(pageIncompleteState, pageId);
			score += _formulas.ReadingScoreCompleteState.Calculate(incompleteState);
		}
		return score;
	}

	public static void SortBooksByScore(List<(ItemKey itemKey, int score)> items, Character character)
	{
		List<sbyte> needToLearnCombatSkillTypes = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> needToLearnLifeSkillTypes = ObjectPool<List<sbyte>>.Instance.Get();
		foreach (CharacterGoalData personalNeed in character.GetGoals())
		{
			if (personalNeed.GoalTemplateId == 246)
			{
				needToLearnCombatSkillTypes.Add(personalNeed.Args.CombatSkillType);
			}
			else if (personalNeed.GoalTemplateId == 247)
			{
				needToLearnLifeSkillTypes.Add(personalNeed.Args.LifeSkillType);
			}
		}
		items.Sort(delegate((ItemKey itemKey, int score) a, (ItemKey itemKey, int score) b)
		{
			GameData.Domains.Item.SkillBook book = (a.itemKey.IsValid() ? DomainManager.Item.GetElement_SkillBooks(a.itemKey.Id) : null);
			SkillBookItem bookConfig = Config.SkillBook.Instance[a.itemKey.TemplateId];
			a.score = CalcSkillBookScore(book, bookConfig, character, needToLearnCombatSkillTypes, needToLearnLifeSkillTypes, out var attainment);
			GameData.Domains.Item.SkillBook book2 = (b.itemKey.IsValid() ? DomainManager.Item.GetElement_SkillBooks(b.itemKey.Id) : null);
			SkillBookItem bookConfig2 = Config.SkillBook.Instance[b.itemKey.TemplateId];
			b.score = CalcSkillBookScore(book2, bookConfig2, character, needToLearnCombatSkillTypes, needToLearnLifeSkillTypes, out attainment);
			return a.score.CompareTo(b.score);
		});
		ObjectPool<List<sbyte>>.Instance.Return(needToLearnCombatSkillTypes);
		ObjectPool<List<sbyte>>.Instance.Return(needToLearnLifeSkillTypes);
	}

	public static (GameData.Domains.Item.SkillBook combatSkillBook, GameData.Domains.Item.SkillBook lifeSkillBook) SelectSectSkillBookToRead(Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationItem orgCfg = Config.Organization.Instance[orgInfo.OrgTemplateId];
		OrganizationMemberItem orgMemberCfg = orgInfo.GetOrgMemberConfig();
		sbyte lovingSectId = character.GetIdealSect();
		OrganizationMemberItem lovingOrgMemberCfg = OrganizationDomain.GetOrgMemberConfig((lovingSectId >= 0) ? lovingSectId : orgInfo.OrgTemplateId, orgInfo.Grade);
		CombatSkillShorts combatSkillQualifications = character.GetCombatSkillQualifications();
		LifeSkillShorts lifeSkillQualifications = character.GetLifeSkillQualifications();
		GameData.Domains.Item.SkillBook bestLifeSkillBook = null;
		int bestLifeSkillBookScore = int.MinValue;
		GameData.Domains.Item.SkillBook bestCombatSkillBook = null;
		int bestCombatSkillBookScore = int.MinValue;
		foreach (ItemKey itemKey in character.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType != 10)
			{
				continue;
			}
			GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
			SkillBookItem skillBookCfg = Config.SkillBook.Instance[itemKey.TemplateId];
			if (skillBookCfg.CombatSkillType >= 0)
			{
				if (Config.CombatSkill.Instance[skillBookCfg.CombatSkillTemplateId].SectId == orgInfo.OrgTemplateId && !character.IsBookRead(itemKey))
				{
					int score = CalcCombatSkillBookScore(skillBook, skillBookCfg.CombatSkillType, orgMemberCfg, lovingOrgMemberCfg, ref combatSkillQualifications, -1, null);
					if (score > bestCombatSkillBookScore)
					{
						bestCombatSkillBookScore = score;
						bestCombatSkillBook = skillBook;
					}
				}
			}
			else if (orgCfg.LearnLifeSkillTypes.Contains(skillBookCfg.LifeSkillType) && !character.IsBookRead(itemKey))
			{
				int score2 = CalcLifeSkillBookScore(skillBook, skillBookCfg.LifeSkillType, orgMemberCfg, lovingOrgMemberCfg, ref lifeSkillQualifications, -1, null);
				if (score2 > bestLifeSkillBookScore)
				{
					bestLifeSkillBookScore = score2;
					bestLifeSkillBook = skillBook;
				}
			}
		}
		return (combatSkillBook: bestCombatSkillBook, lifeSkillBook: bestLifeSkillBook);
	}
}

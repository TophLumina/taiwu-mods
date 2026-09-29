using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;
using GameData.ArchiveData;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Dependencies;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Global;
using GameData.Domains.Item;
using GameData.Domains.LegendaryBook;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;
using NLog;
using Redzen.Random;

namespace GameData.Domains.CombatSkill;

[GameDataDomain(7)]
public class CombatSkillDomain : BaseGameDataDomain
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[DomainData(DomainDataType.ObjectCollection, true, false, true, true, CollectionCapacity = 8192)]
	private readonly CombatSkillCollection _combatSkills;

	private static readonly Dictionary<short, CombatSkill> EmptyCharCombatSkills = new Dictionary<short, CombatSkill>();

	public static short[][] EquipAddPropertyDict;

	private static List<CombatSkillItem>[][] _learnableCombatSkillsCache;

	public const byte MaxCostTrickTypeCount = 3;

	private static readonly DataInfluence[][] CacheInfluences = new DataInfluence[1][];

	private static readonly DataInfluence[][] CacheInfluencesCombatSkills = new DataInfluence[28][];

	private readonly ObjectCollectionDataStates _dataStatesCombatSkills = new ObjectCollectionDataStates(28, 8192);

	public readonly ObjectCollectionHelperData HelperDataCombatSkills;

	private void OnInitializedDomainData()
	{
	}

	private void InitializeOnInitializeGameDataModule()
	{
		EquipAddPropertyDict = new short[Config.CombatSkill.Instance.Count][];
		for (short skillId = 0; skillId < Config.CombatSkill.Instance.Count; skillId++)
		{
			List<PropertyAndValue> addPropertyList = Config.CombatSkill.Instance[skillId].PropertyAddList;
			if (addPropertyList != null && addPropertyList.Count > 0)
			{
				short[] addValueList = new short[167];
				Array.Clear(addValueList, 0, addValueList.Length);
				foreach (PropertyAndValue addProperty in addPropertyList)
				{
					addValueList[addProperty.PropertyId] = addProperty.Value;
				}
				EquipAddPropertyDict[skillId] = addValueList;
			}
		}
		InitializeLearnableCombatSkillTemplateIds();
		PlayerCastBossSkills.Initialize();
	}

	private void InitializeOnEnterNewWorld()
	{
	}

	private void OnLoadedArchiveData()
	{
	}

	private static void InitializeLearnableCombatSkillTemplateIds()
	{
		_learnableCombatSkillsCache = new List<CombatSkillItem>[16][];
		for (int i = 0; i < _learnableCombatSkillsCache.Length; i++)
		{
			_learnableCombatSkillsCache[i] = new List<CombatSkillItem>[14];
			for (int j = 0; j < 14; j++)
			{
				_learnableCombatSkillsCache[i][j] = new List<CombatSkillItem>();
			}
		}
		foreach (CombatSkillItem combatSkillCfg in (IEnumerable<CombatSkillItem>)Config.CombatSkill.Instance)
		{
			if (combatSkillCfg.BookId >= 0)
			{
				_learnableCombatSkillsCache[combatSkillCfg.SectId][combatSkillCfg.Type].Add(combatSkillCfg);
			}
		}
	}

	public static sbyte GetCombatSkillGradeGroup(sbyte grade, sbyte orgTemplateId, sbyte combatSkillType)
	{
		int cnt = GetLearnableCombatSkills(orgTemplateId, combatSkillType).Count;
		if (cnt > 6)
		{
			return Grade.GetGroup(grade);
		}
		int avg = cnt / 3;
		int rem = cnt % 3;
		int mid = avg + ((rem > 0) ? 1 : 0);
		int high = mid + avg + ((rem > 1) ? 1 : 0);
		return (sbyte)((grade >= high) ? 2 : ((grade >= mid) ? 1 : 0));
	}

	public static IReadOnlyList<IReadOnlyList<CombatSkillItem>> GetLearnableCombatSkills(sbyte orgTemplateId)
	{
		return _learnableCombatSkillsCache[orgTemplateId];
	}

	public static IReadOnlyList<CombatSkillItem> GetLearnableCombatSkills(sbyte orgTemplateId, sbyte combatSkillType)
	{
		return _learnableCombatSkillsCache[orgTemplateId][combatSkillType];
	}

	[DomainMethod]
	public bool SetActivePage(DataContext context, int charId, short skillId, byte pageId, sbyte direction)
	{
		if ((pageId <= 0 || pageId >= 6) ? true : false)
		{
			return false;
		}
		if ((uint)direction > 1u)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (!TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var skill))
		{
			return false;
		}
		bool isDirect = direction == 0;
		byte directIndex = CombatSkillStateHelper.GetPageInternalIndex(-1, 0, pageId);
		ushort readingState = skill.GetReadingState();
		if (isDirect && !CombatSkillStateHelper.IsPageRead(readingState, directIndex))
		{
			return false;
		}
		bool isReverse = direction == 1;
		byte reverseIndex = CombatSkillStateHelper.GetPageInternalIndex(-1, 1, pageId);
		if (isReverse && !CombatSkillStateHelper.IsPageRead(readingState, reverseIndex))
		{
			return false;
		}
		ushort activationState = skill.GetActivationState();
		sbyte prevDir = CombatSkillStateHelper.GetCombatSkillDirection(activationState);
		bool isTaiwu = character.IsTaiwu();
		activationState = CombatSkillStateHelper.SetPageInactive(activationState, directIndex);
		activationState = CombatSkillStateHelper.SetPageInactive(activationState, reverseIndex);
		if (isDirect)
		{
			activationState = CombatSkillStateHelper.SetPageActive(activationState, directIndex);
		}
		if (isReverse)
		{
			activationState = CombatSkillStateHelper.SetPageActive(activationState, reverseIndex);
		}
		if (skill.GetActivationState() == activationState)
		{
			return false;
		}
		bool isBrokenOut = CombatSkillStateHelper.IsBrokenOut(activationState);
		if (isTaiwu)
		{
			CombatSkillDisplayData combatSkillDisplayData = GetCombatSkillDisplayDataOnce(DomainManager.Taiwu.GetTaiwuCharId(), skillId);
			bool isLuohan = combatSkillDisplayData.LuohanId >= 0;
			if (isBrokenOut && !isLuohan && !DomainManager.Taiwu.UpdateBreakPlateSelectedPages(context, skillId, activationState))
			{
				return false;
			}
		}
		skill.SetActivationState(activationState, context);
		sbyte currDir = CombatSkillStateHelper.GetCombatSkillDirection(activationState);
		if (isTaiwu && prevDir == 0 && currDir == 1 && Config.CombatSkill.Instance[skillId].SectId == 4)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.SectMainStoryWudangStart, skillId);
		}
		if (!character.IsCombatSkillEquipped(skillId))
		{
			return true;
		}
		DomainManager.SpecialEffect.Remove(context, charId, skillId, 2);
		DomainManager.SpecialEffect.Add(context, charId, skillId, 2, -1);
		return true;
	}

	[DomainMethod]
	public bool DeActivePage(DataContext context, int charId, short skillId, byte pageId, sbyte direction)
	{
		if ((pageId <= 0 || pageId >= 6) ? true : false)
		{
			return false;
		}
		if ((uint)direction > 1u)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		if (!TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var skill))
		{
			return false;
		}
		bool isDirect = direction == 0;
		byte directIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(0, pageId);
		ushort readingState = skill.GetReadingState();
		if (isDirect && !CombatSkillStateHelper.IsPageRead(readingState, directIndex))
		{
			return false;
		}
		bool isReverse = direction == 1;
		byte reverseIndex = CombatSkillStateHelper.GetNormalPageInternalIndex(1, pageId);
		if (isReverse && !CombatSkillStateHelper.IsPageRead(readingState, reverseIndex))
		{
			return false;
		}
		ushort activationState = skill.GetActivationState();
		if (CombatSkillStateHelper.IsBrokenOut(activationState))
		{
			return false;
		}
		activationState = CombatSkillStateHelper.SetPageInactive(activationState, directIndex);
		activationState = CombatSkillStateHelper.SetPageInactive(activationState, reverseIndex);
		if (skill.GetActivationState() == activationState)
		{
			return false;
		}
		skill.SetActivationState(activationState, context);
		if (!character.IsCombatSkillEquipped(skillId))
		{
			return true;
		}
		DomainManager.SpecialEffect.Remove(context, charId, skillId, 2);
		DomainManager.SpecialEffect.Add(context, charId, skillId, 2, -1);
		return true;
	}

	[DomainMethod]
	public IntList GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		(sbyte, sbyte, sbyte) data = GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu(context, taiwu);
		IntList res = IntList.Create();
		res.Items.Add(data.Item1);
		res.Items.Add(data.Item2);
		res.Items.Add(data.Item3);
		return res;
	}

	public void SetCombatSkillReadingState(DataContext context, CombatSkill skill, ushort readingState)
	{
		skill.SetReadingState(readingState, context);
		DomainManager.Character.TryAutoEquipCombatSkillOnAttainmentPanel(context, skill.GetId().CharId, skill.GetId().SkillTemplateId);
	}

	public bool TryActivateCombatSkillBookPageWhenSetReadingState(DataContext context, int charId, short combatSkillTemplateId, byte pageInternalIndex)
	{
		if (pageInternalIndex < 5)
		{
			return false;
		}
		if (pageInternalIndex >= 15)
		{
			return false;
		}
		CombatSkillKey combatSkillKey = new CombatSkillKey(charId, combatSkillTemplateId);
		if (!TryGetElement_CombatSkills(combatSkillKey, out var combatSkill))
		{
			return false;
		}
		byte pageId = CombatSkillStateHelper.GetPageId(pageInternalIndex);
		ushort readState = combatSkill.GetReadingState();
		if (!CombatSkillStateHelper.IsPageRead(readState, pageInternalIndex))
		{
			return false;
		}
		ushort activationState = combatSkill.GetActivationState();
		if (CombatSkillStateHelper.IsPageActive(activationState, pageInternalIndex))
		{
			return false;
		}
		byte oppositeInternalIndex = CombatSkillStateHelper.GetNormalPageOppositeInternalIndex(pageInternalIndex);
		if (CombatSkillStateHelper.IsPageActive(activationState, oppositeInternalIndex))
		{
			return false;
		}
		sbyte readPageType = ((pageInternalIndex >= 10) ? ((sbyte)1) : ((sbyte)0));
		SetActivePage(context, charId, combatSkillTemplateId, pageId, readPageType);
		return true;
	}

	public Dictionary<short, CombatSkill> GetCharCombatSkills(int charId)
	{
		Dictionary<short, CombatSkill> charCombatSkills;
		return _combatSkills.Collection.TryGetValue(charId, out charCombatSkills) ? charCombatSkills : EmptyCharCombatSkills;
	}

	public static (short neili, short qiDisorder, int[] extraNeiliAllocationProgress) CalcNeigongLoopingEffect(IRandomSource random, GameData.Domains.Character.Character character, CombatSkillItem skillCfg, bool includeReference = true)
	{
		(short, int, ItemKey) feast;
		bool isParticipantFeast = DomainManager.Building.IsCharacterParticipantFeast(character.GetId(), out feast);
		sbyte neiliType = character.GetNeiliType();
		byte neiliElementType = NeiliType.Instance[neiliType].FiveElements;
		(int benefit, short qiDisorder) tuple = CalcNeigongLoopingEffect_GetBenefitAndQiDisorder(neiliElementType, character.GetId(), skillCfg);
		int benefit = tuple.benefit;
		short qiDisorder = tuple.qiDisorder;
		ConsummateLevelItem consummateLevelConfig = ConsummateLevel.Instance[character.GetEffectiveConsummateLevel()];
		CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg.TemplateId));
		int obtainNeili = skillCfg.ObtainedNeiliPerLoop + skill.GetBreakoutGridCombatSkillPropertyBonus(7);
		bool isTaiwu = character.GetId() == DomainManager.Taiwu.GetTaiwuCharId();
		if (isTaiwu && includeReference)
		{
			short combatSkillTemplateId = character.GetLoopingNeigong();
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[combatSkillTemplateId];
			benefit += GetTaiwuReferenceSkillNeiliBonus(skillConfig);
			benefit += DomainManager.Taiwu.GetQiArtStrategyDeltaNeiliBonus(random);
			benefit += CalcTaiwuProfessionNeigongLoopingEffectBonus();
		}
		benefit += consummateLevelConfig.LoopingNeiliBonus;
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (!isTaiwu && orgInfo.SettlementId >= 0 && OrganizationDomain.IsSect(orgInfo.OrgTemplateId))
		{
			Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
			benefit = benefit * settlement.GetMemberSelfImproveSpeedFactor() / 100;
		}
		if (isParticipantFeast)
		{
			FeastItem config = Feast.Instance[feast.Item1];
			benefit += benefit * config.Loop / 100 * feast.Item2 / 100;
		}
		int neili = obtainNeili * benefit / 100;
		int neiliMin = neili * 3 / 4;
		int neiliMax = neili * 5 / 4;
		neili = random.Next(neiliMin, neiliMax + 1);
		if (qiDisorder > 0)
		{
			qiDisorder = (short)random.Next(qiDisorder + 1);
		}
		else if (qiDisorder < 0)
		{
			qiDisorder = (short)(-random.Next(-qiDisorder + 1));
		}
		if (isParticipantFeast)
		{
			FeastItem config2 = Feast.Instance[feast.Item1];
			qiDisorder += (short)(qiDisorder * config2.Loop / 100 * feast.Item2 / 100);
		}
		sbyte[] skillConfigExtraProgress = skillCfg.ExtraNeiliAllocationProgress;
		int[] randomExtraNeiliAllocationProgress = RandomUtils.DistributeNIntoKBuckets(random, skillConfigExtraProgress[4], 4);
		int[] extraNeiliAllocationProgress = new int[4];
		int bonus = 0;
		if (isTaiwu)
		{
			bonus += GetTaiwuReferenceSkillNeiliAllocationBonus(skillCfg);
			bonus += DomainManager.Taiwu.GetQiArtStrategyExtraNeiliAllocationBonus(random, skillCfg.TemplateId);
			bonus += CalcTaiwuProfessionNeigongLoopingEffectBonus();
		}
		bonus += consummateLevelConfig.LoopingNeiliAllocationBonus;
		if (isParticipantFeast)
		{
			FeastItem config3 = Feast.Instance[feast.Item1];
			bonus += config3.Loop / 100 * feast.Item2;
		}
		for (int i = 0; i < 4; i++)
		{
			extraNeiliAllocationProgress[i] = 100 * (skillConfigExtraProgress[i] + randomExtraNeiliAllocationProgress[i]);
			extraNeiliAllocationProgress[i] *= (CValuePercentBonus)bonus;
		}
		return (neili: (short)neili, qiDisorder: qiDisorder, extraNeiliAllocationProgress: extraNeiliAllocationProgress);
	}

	private static int CalcTaiwuProfessionNeigongLoopingEffectBonus()
	{
		if (!DomainManager.Extra.IsProfessionalSkillUnlocked(3, 1))
		{
			return 0;
		}
		int seniority = DomainManager.Extra.GetProfessionData(3).Seniority;
		int maxSeniority = 3000000;
		return 50 + 50 * seniority / maxSeniority;
	}

	[DomainMethod]
	public (int minNeili, int maxNeili) CalcTaiwuExtraDeltaNeiliPerLoop(DataContext context)
	{
		GameData.Domains.Character.Character character = DomainManager.Taiwu.GetTaiwu();
		short loopingNeigong = character.GetLoopingNeigong();
		if (loopingNeigong < 0)
		{
			return (minNeili: 0, maxNeili: 0);
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[loopingNeigong];
		sbyte neiliType = character.GetNeiliType();
		byte neiliElementType = NeiliType.Instance[neiliType].FiveElements;
		(int benefit, short qiDisorder) tuple = CalcNeigongLoopingEffect_GetBenefitAndQiDisorder(neiliElementType, character.GetId(), skillConfig);
		int bonus = tuple.benefit;
		short _qiDisorder = tuple.qiDisorder;
		ConsummateLevelItem consummateLevelConfig = ConsummateLevel.Instance[character.GetEffectiveConsummateLevel()];
		CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillConfig.TemplateId));
		int obtainNeili = skillConfig.ObtainedNeiliPerLoop + skill.GetBreakoutGridCombatSkillPropertyBonus(7);
		int maxBonus = bonus;
		int minBonus = bonus;
		int refBonus = GetTaiwuReferenceSkillNeiliBonus(skillConfig);
		minBonus += refBonus;
		maxBonus += refBonus;
		(int, int) strategyBonusRange = DomainManager.Taiwu.GetQiArtStrategyDeltaNeiliBonusRange();
		minBonus += strategyBonusRange.Item1;
		maxBonus += strategyBonusRange.Item2;
		int professionBonus = CalcTaiwuProfessionNeigongLoopingEffectBonus();
		minBonus += professionBonus;
		maxBonus += professionBonus;
		minBonus += consummateLevelConfig.LoopingNeiliBonus;
		maxBonus += consummateLevelConfig.LoopingNeiliBonus;
		int minNeili = obtainNeili * minBonus / 100;
		int maxNeili = obtainNeili * maxBonus / 100;
		int neiliMin = minNeili * 3 / 4;
		int neiliMax = maxNeili * 5 / 4;
		byte loopingDifficulty = DomainManager.World.GetLoopingDifficulty();
		short factor = WorldCreation.Instance[(byte)4].InfluenceFactors[loopingDifficulty];
		neiliMin = neiliMin * factor / 100;
		neiliMax = neiliMax * factor / 100;
		return (minNeili: neiliMin - skillConfig.ObtainedNeiliPerLoop, maxNeili: neiliMax - skillConfig.ObtainedNeiliPerLoop);
	}

	[DomainMethod]
	public IntList CalcTaiwuExtraDeltaNeiliAllocationPerLoop(DataContext context)
	{
		GameData.Domains.Character.Character character = DomainManager.Taiwu.GetTaiwu();
		short loopingNeigong = character.GetLoopingNeigong();
		int[] min = new int[4];
		int[] max = new int[4];
		IntList result = IntList.Create();
		for (int i = 0; i < 8; i++)
		{
			result.Items.Add(0);
		}
		if (loopingNeigong < 0)
		{
			return result;
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[loopingNeigong];
		sbyte[] basicProgress = skillConfig.ExtraNeiliAllocationProgress;
		for (int j = 0; j < 4; j++)
		{
			min[j] = 100 * basicProgress[j];
			max[j] = 100 * (basicProgress[j] + basicProgress[4]);
		}
		int minBonus = 0;
		int maxBonus = 0;
		short combatSkillTemplateId = character.GetLoopingNeigong();
		int refBonus = GetTaiwuReferenceSkillNeiliAllocationBonus(skillConfig);
		minBonus += refBonus;
		maxBonus += refBonus;
		(int, int) strategyBonusRange = DomainManager.Taiwu.GetQiArtStrategyExtraNeiliAllocationBonusRange();
		minBonus += strategyBonusRange.Item1;
		maxBonus += strategyBonusRange.Item2;
		int professionBonus = CalcTaiwuProfessionNeigongLoopingEffectBonus();
		minBonus += professionBonus;
		maxBonus += professionBonus;
		ConsummateLevelItem consummateLevelConfig = ConsummateLevel.Instance[character.GetEffectiveConsummateLevel()];
		minBonus += consummateLevelConfig.LoopingNeiliAllocationBonus;
		maxBonus += consummateLevelConfig.LoopingNeiliAllocationBonus;
		for (int k = 0; k < 4; k++)
		{
			min[k] *= (CValuePercentBonus)minBonus;
			max[k] *= (CValuePercentBonus)maxBonus;
			min[k] -= basicProgress[k] * 100;
			max[k] -= basicProgress[k] * 100;
		}
		for (int l = 0; l < 4; l++)
		{
			result.Items[l] = min[l];
		}
		for (int m = 0; m < 4; m++)
		{
			result.Items[m + 4] = max[m];
		}
		return result;
	}

	private static int GetTaiwuReferenceSkillNeiliBonus(CombatSkillItem skillConfig)
	{
		List<short> referenceSkillList = DomainManager.Extra.GetReferenceSkillList();
		int referenceBonus = 0;
		if (referenceSkillList != null && referenceSkillList.Count > 0)
		{
			for (int i = 0; i < referenceSkillList.Count; i++)
			{
				short refSkill = referenceSkillList[i];
				if (skillConfig.LoopBonusSkillList.Contains(refSkill))
				{
					referenceBonus += 10;
				}
				if (refSkill != -1)
				{
					CombatSkillItem refSkillConfig = Config.CombatSkill.Instance[refSkill];
					if (refSkillConfig.SectId == skillConfig.SectId)
					{
						referenceBonus += 20;
					}
				}
			}
		}
		return referenceBonus;
	}

	private static int GetTaiwuReferenceSkillNeiliAllocationBonus(CombatSkillItem skillConfig)
	{
		int referenceBonus = 0;
		if (skillConfig == null)
		{
			return referenceBonus;
		}
		List<short> referenceSkillList = DomainManager.Extra.GetReferenceSkillList();
		if (referenceSkillList != null && referenceSkillList.Count > 0)
		{
			for (int i = 0; i < referenceSkillList.Count; i++)
			{
				short refSkill = referenceSkillList[i];
				if (skillConfig.LoopBonusSkillList.Contains(refSkill))
				{
					referenceBonus += 10;
				}
				if (refSkill != -1)
				{
					CombatSkillItem refSkillConfig = Config.CombatSkill.Instance[refSkill];
					if (refSkillConfig.SectId == skillConfig.SectId)
					{
						referenceBonus += 20;
					}
				}
			}
		}
		return referenceBonus;
	}

	public void ApplyNeigongLoopingEffect(DataContext context, GameData.Domains.Character.Character character, short combatSkillTemplateId, short obtainedNeili, int[] extraNeiliAllocationProgress)
	{
		int charId = character.GetId();
		CombatSkillKey skillKey = new CombatSkillKey(charId, combatSkillTemplateId);
		CombatSkill skill = _combatSkills[skillKey];
		ApplyLoopingNeiliModify(context, character, obtainedNeili, skill);
		ApplyLoopingTransferNeiliProportionOfFiveElements(context, character, combatSkillTemplateId, skill);
		character.ApplyLoopingExtraNeiliAllocationProgressModify(context, extraNeiliAllocationProgress);
		Events.RaiseQiArtAffected(context, character, combatSkillTemplateId);
		if (character.IsTaiwu())
		{
			DomainManager.Taiwu.RecordLifeSummary(context, 52);
		}
	}

	public void ApplyLoopingNeiliModify(DataContext context, GameData.Domains.Character.Character character, short obtainedNeili, CombatSkill skill)
	{
		short oriObtainedNeili = skill.GetObtainedNeili();
		skill.ObtainNeili(context, obtainedNeili);
		int deltaNeili = skill.GetObtainedNeili() - oriObtainedNeili;
		if (deltaNeili > 0)
		{
			int currNeili = character.GetCurrNeili() + deltaNeili;
			int maxNeili = character.GetMaxNeili();
			if (currNeili > maxNeili)
			{
				currNeili = maxNeili;
			}
			character.SetCurrNeili(currNeili, context);
		}
	}

	public void ApplyLoopingNeiliModifyForTaiwu(DataContext context, GameData.Domains.Character.Character taiwuChar, short obtainedNeili)
	{
		int charId = taiwuChar.GetId();
		short combatSkillTemplateId = taiwuChar.GetLoopingNeigong();
		CombatSkillKey skillKey = new CombatSkillKey(charId, combatSkillTemplateId);
		CombatSkill skill = _combatSkills[skillKey];
		ApplyLoopingNeiliModify(context, taiwuChar, obtainedNeili, skill);
	}

	private static void ApplyLoopingTransferNeiliProportionOfFiveElements(DataContext context, GameData.Domains.Character.Character character, short combatSkillTemplateId, CombatSkill loopingSkill)
	{
		var (destinationType, transferType, amount) = GetLoopingTransferNeiliProportionOfFiveElementsData(context, character, combatSkillTemplateId, loopingSkill);
		if (transferType >= 0 && amount > 0)
		{
			character.TransferNeiliProportionOfFiveElements(context, destinationType, transferType, amount);
		}
	}

	public static (sbyte destinationType, sbyte transferType, sbyte amount) GetLoopingTransferNeiliProportionOfFiveElementsData(DataContext context, GameData.Domains.Character.Character character, short combatSkillTemplateId, CombatSkill loopingSkill)
	{
		CombatSkillItem config = Config.CombatSkill.Instance[combatSkillTemplateId];
		sbyte amount = loopingSkill.GetFiveElementsChange();
		sbyte destinationType = config.DestTypeWhileLooping;
		sbyte transferType = config.TransferTypeWhileLooping;
		if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			var (overrideDestinationType, overrideTransferType) = DomainManager.Taiwu.GetOverrideFiveElementTransferInfo();
			if (overrideDestinationType > -1)
			{
				destinationType = overrideDestinationType;
				transferType = overrideTransferType;
			}
			short anchordFiveElement = DomainManager.Taiwu.GetAnchoredFiveElements();
			sbyte neiliType = character.GetNeiliType();
			NeiliTypeItem neiliTypeConfig = NeiliType.Instance[neiliType];
			bool isConflict = neiliTypeConfig.ColorType == 2;
			if (anchordFiveElement > -1 && !isConflict && neiliTypeConfig.FiveElements == anchordFiveElement)
			{
				destinationType = -1;
				transferType = -1;
			}
			int amountBonus = 0;
			amountBonus = DomainManager.Taiwu.GetQiArtStrategyFiveElementTransferAmountBonus(context.Random);
			amount = (sbyte)(amount * (100 + amountBonus) / 100);
		}
		return (destinationType: destinationType, transferType: transferType, amount: amount);
	}

	public (sbyte destinationType, sbyte transferType, sbyte amount) GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu(DataContext context, GameData.Domains.Character.Character taiwuChar)
	{
		int charId = taiwuChar.GetId();
		short combatSkillTemplateId = taiwuChar.GetLoopingNeigong();
		CombatSkillKey skillKey = new CombatSkillKey(charId, combatSkillTemplateId);
		CombatSkill skill = _combatSkills[skillKey];
		return GetLoopingTransferNeiliProportionOfFiveElementsData(context, taiwuChar, combatSkillTemplateId, skill);
	}

	public sbyte GetSkillDirection(int charId, short skillId)
	{
		return GetElement_CombatSkills(new CombatSkillKey(charId, skillId)).GetDirection();
	}

	public sbyte GetSkillType(int charId, short skillId)
	{
		sbyte type = Config.CombatSkill.Instance[skillId].Type;
		return (sbyte)DomainManager.SpecialEffect.ModifyData(charId, skillId, 221, type);
	}

	[DomainMethod]
	public CombatSkillNeigongLoopInformation CalcTaiwuExtraDeltaNeiliAllocationLoops(DataContext context, int combatSkillId, int totalLoopsCount)
	{
		GameData.Domains.Character.Character character = DomainManager.Taiwu.GetTaiwu();
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[combatSkillId];
		CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(character.GetId(), skillCfg.TemplateId));
		short totalNeili = skill.GetTotalObtainableNeili();
		int[] extraNeiliAllocationProgress = new int[4];
		CombatSkillNeigongLoopInformation result = new CombatSkillNeigongLoopInformation();
		result.ReferenceSkillList = DomainManager.Extra.GetReferenceSkillList();
		result.ExtraNeiliAllocationProgress = IntList.Create();
		int[] extraNeiliAllocationProgress2 = character.GetExtraNeiliAllocationProgress();
		foreach (int item in extraNeiliAllocationProgress2)
		{
			result.ExtraNeiliAllocationProgress.Items.Add(item);
		}
		result.ExtraNeiliTotalRange = DomainManager.CombatSkill.CalcTaiwuExtraDeltaNeiliPerLoop(context);
		result.ExtraNeiliTotalRange.Item1 *= totalLoopsCount;
		result.ExtraNeiliTotalRange.Item2 *= totalLoopsCount;
		result.ExtraNeiliAllocationTotal = DomainManager.CombatSkill.CalcTaiwuExtraDeltaNeiliAllocationPerLoop(context);
		for (int j = 0; j < result.ExtraNeiliAllocationTotal.Items.Count; j++)
		{
			result.ExtraNeiliAllocationTotal.Items[j] *= totalLoopsCount;
		}
		return result;
	}

	[DomainMethod]
	public List<short> GetLearnedCombatSkillByType(DataContext context, int charId, sbyte skillType)
	{
		List<short> result = new List<short>();
		result.AddRange(DomainManager.Character.GetElement_Objects(charId).GetLearnedCombatSkills());
		result.RemoveAll(delegate(short skillId)
		{
			CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[skillId];
			return skillType >= 0 && combatSkillItem.Type != skillType;
		});
		return result;
	}

	public bool CheckIsCombatSkillBookFinished(CombatSkill combatSkill, GameData.Domains.Item.SkillBook book)
	{
		ushort readingState = combatSkill.GetReadingState();
		byte pageTypes = book.GetPageTypes();
		sbyte behaviorType = SkillBookStateHelper.GetOutlinePageType(pageTypes);
		for (byte pageId = 0; pageId < 6; pageId++)
		{
			sbyte direction = SkillBookStateHelper.GetNormalPageType(pageTypes, pageId);
			byte internalIndex = CombatSkillStateHelper.GetPageInternalIndex(behaviorType, direction, pageId);
			if (!CombatSkillStateHelper.IsPageRead(readingState, internalIndex))
			{
				return false;
			}
		}
		return true;
	}

	private static (int benefit, short qiDisorder) CalcNeigongLoopingEffect_GetBenefitAndQiDisorder(byte neiliElementType, int charId, CombatSkillItem skillConfig)
	{
		if (neiliElementType == 5)
		{
			return (benefit: 100, qiDisorder: 0);
		}
		if (FiveElementEquals(charId, skillConfig, FiveElementsType.Producing[neiliElementType]))
		{
			return (benefit: 200, qiDisorder: (short)(skillConfig.Grade * -125));
		}
		if (FiveElementEquals(charId, skillConfig, FiveElementsType.Countering[neiliElementType]))
		{
			return (benefit: 50, qiDisorder: (short)(skillConfig.Grade * 125));
		}
		return (benefit: 100, qiDisorder: 0);
	}

	public CombatSkill CreateCombatSkill(int charId, short skillTemplateId, ushort readingState = 0)
	{
		CombatSkill skill = new CombatSkill(charId, skillTemplateId, readingState);
		AddElement_CombatSkills(skill.GetId(), skill);
		return skill;
	}

	public void RegisterCombatSkills(int charId, List<CombatSkill> combatSkills)
	{
		int i = 0;
		for (int count = combatSkills.Count; i < count; i++)
		{
			CombatSkill skill = combatSkills[i];
			skill.OfflineSetCharId(charId);
			AddElement_CombatSkills(skill.GetId(), skill);
		}
	}

	public void RemoveCombatSkill(int charId, short skillTemplateId)
	{
		RemoveElement_CombatSkills(new CombatSkillKey(charId, skillTemplateId));
	}

	public void RemoveAllCombatSkills(int charId)
	{
		Dictionary<short, CombatSkill> charCombatSkills = GetCharCombatSkills(charId);
		List<short> skillTemplateIdList = ObjectPool<List<short>>.Instance.Get();
		skillTemplateIdList.Clear();
		skillTemplateIdList.AddRange(charCombatSkills.Keys);
		for (int i = 0; i < skillTemplateIdList.Count; i++)
		{
			RemoveElement_CombatSkills(new CombatSkillKey(charId, skillTemplateIdList[i]));
		}
		_combatSkills.RemoveCharStub(charId);
		ObjectPool<List<short>>.Instance.Return(skillTemplateIdList);
	}

	public override void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Dictionary<short, CombatSkill> combatSkills = GetCharCombatSkills(taiwuCharId);
		crossArchiveGameData.CombatSkills = new List<CombatSkill>();
		crossArchiveGameData.CombatSkills.AddRange(combatSkills.Values);
	}

	public void UnpackCrossArchiveGameData_CombatSkills(DataContext context, CrossArchiveGameData crossArchiveGameData, bool overwriteEquipments)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Dictionary<short, CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(taiwuCharId);
		List<short> learnedCombatSkills = taiwu.GetLearnedCombatSkills();
		List<CombatSkill> dreamBackCombatSkills = crossArchiveGameData.CombatSkills;
		List<CombatSkill> conflictCombatSkills = null;
		foreach (CombatSkill dreamBackCombatSkill in dreamBackCombatSkills)
		{
			short templateId = dreamBackCombatSkill.GetId().SkillTemplateId;
			if (combatSkills.TryGetValue(templateId, out var combatSkill))
			{
				ushort readingState = (ushort)(combatSkill.GetReadingState() | dreamBackCombatSkill.GetReadingState());
				short obtainedNeili = Math.Max(combatSkill.GetObtainedNeili(), dreamBackCombatSkill.GetObtainedNeili());
				bool revoked = combatSkill.GetRevoked();
				bool dreamBackRevoked = dreamBackCombatSkill.GetRevoked();
				DomainManager.CombatSkill.SetCombatSkillReadingState(context, combatSkill, readingState);
				combatSkill.SetObtainedNeili(obtainedNeili, context);
				combatSkill.SetRevoked(revoked && dreamBackRevoked, context);
				ushort activationState = combatSkill.GetActivationState();
				ushort dreamBackActivationState = dreamBackCombatSkill.GetActivationState();
				if (activationState != 0 && dreamBackActivationState != 0)
				{
					if (conflictCombatSkills == null)
					{
						conflictCombatSkills = new List<CombatSkill>();
					}
					conflictCombatSkills.Add(dreamBackCombatSkill);
				}
				else if (dreamBackActivationState != 0)
				{
					combatSkill.SetActivationState(dreamBackActivationState, context);
					combatSkill.SetBreakoutStepsCount(dreamBackCombatSkill.GetBreakoutStepsCount(), context);
					combatSkill.SetForcedBreakoutStepsCount(dreamBackCombatSkill.GetForcedBreakoutStepsCount(), context);
				}
				if (overwriteEquipments)
				{
					combatSkill.SetInnerRatio(dreamBackCombatSkill.GetInnerRatio(), context);
				}
			}
			else
			{
				dreamBackCombatSkill.OfflineSetCharId(taiwuCharId);
				learnedCombatSkills.Add(templateId);
				AddElement_CombatSkills(dreamBackCombatSkill.GetId(), dreamBackCombatSkill);
			}
		}
		taiwu.SetLearnedCombatSkills(learnedCombatSkills, context);
		crossArchiveGameData.CombatSkills = conflictCombatSkills;
	}

	[DomainMethod]
	public CombatSkillDisplayData GetCombatSkillDisplayDataOnce(int charId, short skillTemplateId)
	{
		GameData.Domains.Character.Character character = null;
		if (charId >= 0 && !DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			charId = -1;
		}
		if (charId < 0)
		{
			charId = DomainManager.Taiwu.GetTaiwuCharId();
			character = DomainManager.Taiwu.GetTaiwu();
		}
		return CalcCombatSkillDisplayData(skillTemplateId, charId, character);
	}

	[DomainMethod]
	public CombatSkillDisplayDataForList GetCombatSkillDisplayDataForListOnce(int charId, short skillTemplateId)
	{
		GameData.Domains.Character.Character character = null;
		if (charId >= 0 && !DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			charId = -1;
		}
		if (charId < 0)
		{
			charId = DomainManager.Taiwu.GetTaiwuCharId();
			character = DomainManager.Taiwu.GetTaiwu();
		}
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		bool skillExist = _combatSkills.ContainsKey(skillKey);
		CombatSkill skill = (skillExist ? _combatSkills[skillKey] : new CombatSkill(charId, skillTemplateId, 0));
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		int prof;
		int combatSkillProficiency = (DomainManager.Extra.TryGetElement_CombatSkillProficiencies(skillKey, out prof) ? prof : 0);
		VoidValue value;
		CombatSkillDisplayDataForList data = new CombatSkillDisplayDataForList
		{
			CharId = charId,
			TemplateId = skillTemplateId,
			ReadingState = skill.GetReadingState(),
			ActivationState = skill.GetActivationState(),
			Power = (short)(skillExist ? skill.GetPower() : 100),
			CombatSkillProficiency = combatSkillProficiency,
			BreakSuccess = GetBreakSuccess(charId, skillTemplateId),
			IsInAnyEquipPlans = IsCombatSkillInAnyEquipPlan(skillTemplateId, character, isTaiwu),
			IsInCurrentEquipPlan = IsCombatSkillInCurrentEquipPlan(skillTemplateId, character),
			EmeiBonus1 = -1,
			EmeiBonus2 = -1,
			LuohanId = (sbyte)(isTaiwu ? DomainManager.Taiwu.GetCombatSkillLuohanId(skillTemplateId) : ((character != null && character.IsGearMate) ? (DomainManager.Extra.GetGearMateById(charId).LuohanBreakDict?.GetValueOrDefault<short, sbyte>(skillTemplateId, -1) ?? (-1)) : (-1))),
			HitDistribution = skill.GetHitDistribution(),
			CostTricks = new List<NeedTrick>(),
			Revoked = skill.GetRevoked(),
			IsFavorite = DomainManager.Taiwu.TryGetElement_FavoriteCombatSkills(skillTemplateId, out value)
		};
		GetCombatSkillCostTrick(skill, data.CostTricks);
		if (DomainManager.Story.TryGetElement_SectEmeiBreakBonusTemplateIds(skillTemplateId, out var templateIds) && templateIds.Items != null)
		{
			if (templateIds.Items.Count >= 1)
			{
				data.EmeiBonus1 = templateIds.Items[0];
			}
			if (templateIds.Items.Count >= 2)
			{
				data.EmeiBonus2 = templateIds.Items[1];
			}
		}
		if (skillExist)
		{
			IEnumerable<SkillBreakPlateBonus> bonuses = skill.GetBreakBonuses();
			data.BreakBonusGrades = new List<sbyte>();
			foreach (SkillBreakPlateBonus breakBonus in bonuses)
			{
				data.BreakBonusGrades.Add(breakBonus.Grade);
			}
		}
		return data;
	}

	[DomainMethod]
	public List<CombatSkillDisplayDataForList> GetCombatSkillDisplayDataForList(int charId, List<short> skillTemplateIdList)
	{
		if (charId >= 0 && !DomainManager.Character.TryGetElement_Objects(charId, out var _))
		{
			charId = -1;
		}
		List<CombatSkillDisplayDataForList> res = new List<CombatSkillDisplayDataForList>();
		if (skillTemplateIdList != null)
		{
			foreach (short id in skillTemplateIdList)
			{
				res.Add(GetCombatSkillDisplayDataForListOnce(charId, id));
			}
		}
		return res;
	}

	[DomainMethod]
	public CombatSkillPracticeDisplayData GetCombatSkillDisplayDataForPractice(int charId, short skillTemplateId)
	{
		CombatSkillPracticeDisplayData res = new CombatSkillPracticeDisplayData
		{
			CombatSkillDisplayData = GetCombatSkillDisplayDataOnce(charId, skillTemplateId),
			Bonuses = GetCombatSkillBreakBonuses(charId, skillTemplateId),
			ReBreakCd = 0
		};
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			res.SkillBreakPlate = DomainManager.Taiwu.GetBreakPlateData(skillTemplateId);
			res.CombatSkillBreakSuccessRateDisplayData = CalcTaiwuCombatSkillBreakSuccessRate(skillTemplateId);
			res.CombatSkillBreakAvailableStepsDisplayData = CalcCombatSkillBreakAvailableStepsDisplayData(charId, skillTemplateId);
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillTemplateId];
			Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
			int buildingEffect = DomainManager.Building.GetBuildingBlockEffect(location, EBuildingScaleEffect.BreakOutSuccessRate, skillConfig.Type);
			if (buildingEffect != 0)
			{
				res.CombatSkillBreakSuccessRateDisplayData.BuildingBonus = (byte)buildingEffect;
			}
			int currDate = DomainManager.World.GetCurrDate();
			SkillGradeData skillGradeConfig = SkillGradeData.Instance;
			if (DomainManager.Taiwu.TryGetTaiwuCombatSkill(skillTemplateId, out var data))
			{
				int passedMonth = currDate - data.LastClearBreakPlateTime;
				int leftCd = skillGradeConfig[Config.CombatSkill.Instance[skillTemplateId].Grade].ClearBreakPlateCd - passedMonth;
				res.ReBreakCd = leftCd;
			}
			int displaySteps = res.CombatSkillBreakAvailableStepsDisplayData.BaseAvailableSteps;
			ELegendaryBookSlotState bookState = DomainManager.Extra.GetLegendaryBookState(skillConfig.Type);
			if (bookState.ContainsYang())
			{
				displaySteps += GlobalConfig.Instance.LegendaryBookYangAddStepNormal;
			}
			CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
			if (DomainManager.Taiwu.TryGetElement_NextBreakoutStepBaseBonus(skillKey, out var skillStepBonus))
			{
				displaySteps += skillStepBonus;
			}
			res.DisplayAvailableSteps = displaySteps;
		}
		return res;
	}

	[DomainMethod]
	public List<CombatSkillDisplayData> GetCombatSkillDisplayData(int charId, List<short> skillTemplateIdList)
	{
		return CalcCombatSkillDisplayDataList(charId, skillTemplateIdList);
	}

	[DomainMethod]
	public List<CombatSkillDisplayData> GetCharacterEquipCombatSkillDisplayData(int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		return CalcCombatSkillDisplayDataList(charId, character.GetCombatSkillEquipment());
	}

	[DomainMethod]
	public EquipCombatSkillDisplayData GetEquipCombatSkillDisplayData(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		List<short> skills = character.GetLearnedCombatSkills();
		if (charId == DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Extra.CheckCombatSkillOrderPlan(context);
			int currCombatSkillPlanId = DomainManager.Taiwu.GetCurrCombatSkillPlanId();
			GameData.Utilities.ShortList plan;
			return new EquipCombatSkillDisplayData
			{
				CombatSkillDisplayDatas = GetCharacterMenuCombatSkillListItemDisplayData(context, charId),
				CurrentPlanId = currCombatSkillPlanId,
				IsCombatSkillLocked = false,
				PlanCount = DomainManager.Extra.GetUnlockedCombatSkillPlanCount(),
				CombatSkillOrderPlan = (DomainManager.Extra.TryGetElement_CombatSkillOrderPlans(currCombatSkillPlanId, out plan) ? plan : default(GameData.Utilities.ShortList)),
				CurrentEquipPlan = character.GetCombatSkillEquipment(),
				GenericGridAllocation = DomainManager.Character.GetGenericGridAllocation(charId)
			};
		}
		CharacterCombatSkillConfiguration characterCombatSkillConfiguration = DomainManager.Extra.TryGetCharacterCombatSkillConfiguration(charId);
		if (characterCombatSkillConfiguration == null)
		{
			if (character.GetLeaderId() != DomainManager.Taiwu.GetTaiwuCharId())
			{
				return null;
			}
			characterCombatSkillConfiguration = new CharacterCombatSkillConfiguration();
		}
		CharacterCombatSkillConfiguration characterCombatSkillConfiguration2 = characterCombatSkillConfiguration;
		if (characterCombatSkillConfiguration2.CombatSkillEquipPlans == null)
		{
			characterCombatSkillConfiguration2.CombatSkillEquipPlans = new List<CombatSkillPlan>();
		}
		return new EquipCombatSkillDisplayData
		{
			CombatSkillDisplayDatas = GetCharacterMenuCombatSkillListItemDisplayData(context, charId),
			CurrentPlanId = characterCombatSkillConfiguration.CurrentPlanId,
			IsCombatSkillLocked = characterCombatSkillConfiguration.IsCombatSkillLocked,
			PlanCount = characterCombatSkillConfiguration.CombatSkillEquipPlans.Count,
			CurrentEquipPlan = character.GetCombatSkillEquipment(),
			GenericGridAllocation = DomainManager.Character.GetGenericGridAllocation(charId)
		};
	}

	[DomainMethod]
	public CombatSkillEquipment GetCombatSkillEquipment(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		return character.GetCombatSkillEquipment();
	}

	[DomainMethod]
	public List<short> GetCharacterEquipNeigongBreakList(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		List<short> result = new List<short>();
		ArraySegmentList<short> neigong = character.GetCombatSkillEquipment().Neigong;
		for (int i = 0; i < neigong.Count; i++)
		{
			short templateId = neigong[i];
			CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, templateId));
			if (CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()))
			{
				result.Add(templateId);
			}
		}
		return result;
	}

	[DomainMethod]
	public List<short> GetCharacterEquipAssistanceBreakList(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return null;
		}
		List<short> result = new List<short>();
		ArraySegmentList<short> neigong = character.GetCombatSkillEquipment().Assistance;
		for (int i = 0; i < neigong.Count; i++)
		{
			short templateId = neigong[i];
			CombatSkill combatSkill = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, templateId));
			if (CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()))
			{
				result.Add(templateId);
			}
		}
		return result;
	}

	[DomainMethod]
	public List<CombatSkillEffectDescriptionDisplayData> GetEffectDescriptionData(int charId, List<short> skillIds)
	{
		List<CombatSkillEffectDescriptionDisplayData> result = new List<CombatSkillEffectDescriptionDisplayData>();
		foreach (short skillId in skillIds)
		{
			CombatSkillKey key = new CombatSkillKey(charId, skillId);
			if (TryGetElement_CombatSkills(key, out var skill))
			{
				result.Add(GetEffectDisplayData(skill));
				continue;
			}
			result.Add(CombatSkillEffectDescriptionDisplayData.Invalid);
			PredefinedLog.Show(13, $"GetEffectDescriptionData no exist key {key}");
		}
		return result;
	}

	[DomainMethod]
	public sbyte GetCombatSkillBreakStepCount(int charId, short skillTemplateId)
	{
		return DomainManager.Character.GetElement_Objects(charId).GetSkillBreakoutAvailableStepsCount(skillTemplateId);
	}

	[DomainMethod]
	public int GetCombatSkillBreakoutStepsMaxPower(int charId, short skillTemplateId)
	{
		GameData.Domains.Character.Character character;
		return DomainManager.Character.TryGetElement_Objects(charId, out character) ? character.GetSkillBreakoutStepsMaxPower(skillTemplateId) : 0;
	}

	private CombatSkillDisplayData CalcCombatSkillDisplayData(short skillTemplateId, int charId, GameData.Domains.Character.Character character)
	{
		if (character == null)
		{
			PredefinedLog.Show(12, $"CalcCombatSkillDisplayData {skillTemplateId} {charId}");
			return null;
		}
		CombatSkillItem configData = Config.CombatSkill.Instance[skillTemplateId];
		CombatCharacter combatChar = null;
		bool inCombat = DomainManager.Combat.IsInCombat() && DomainManager.Combat.TryGetElement_CombatCharacterDict(charId, out combatChar);
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		bool skillExist = _combatSkills.ContainsKey(skillKey);
		CombatSkill skill = (skillExist ? _combatSkills[skillKey] : new CombatSkill(charId, skillTemplateId, 0));
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		VoidValue value;
		bool isFavorite = DomainManager.Taiwu.TryGetElement_FavoriteCombatSkills(skillTemplateId, out value);
		CombatSkillDisplayData data = new CombatSkillDisplayData();
		data.CharId = charId;
		data.TemplateId = skillTemplateId;
		data.ReadingState = skill.GetReadingState();
		data.ActivationState = skill.GetActivationState();
		data.CanAffect = character.GetCombatSkillCanAffect(skillTemplateId);
		data.Conflicting = DomainManager.Extra.GetConflictCombatSkill(skillTemplateId) != null;
		data.GridCount = character.GetCombatSkillGridCost(skillTemplateId);
		data.Power = (short)(skillExist ? skill.GetPower() : 100);
		data.MaxPower = (skillExist ? skill.GetMaxPower() : GlobalConfig.Instance.CombatSkillMaxBasePower);
		data.RequirementsPower = (short)(skillExist ? skill.GetRequirementsPower() : (-1));
		data.Requirements = skill.GetRequirementsAndActualValues(character, skillExist);
		data.BreakAddProperty = skill.GetBreakAddPropertyList(data.Power);
		data.NeiliAllocationAddProperty = skill.GetNeiliAllocationPropertyList(data.Power);
		data.BreakPlateIndex = (sbyte)((isTaiwu && DomainManager.Taiwu.TryGetElement_CombatSkillBreakPresets(skillTemplateId, out var preset)) ? preset.CurrentIndex : 0);
		data.EffectType = (sbyte)(skillExist ? skill.GetDirection() : (-1));
		data.Mastered = DomainManager.Extra.GetCharacterMasteredCombatSkills(charId).Items?.Contains(skillTemplateId) ?? false;
		data.Revoked = skill.GetRevoked();
		data.JumpThreshold = (short)(isTaiwu ? DomainManager.Extra.GetJumpThreshold(skillTemplateId) : (-1));
		data.BaseInnerRatio = (skillExist ? skill.GetBaseInnerRatio() : configData.BaseInnerRatio);
		data.InnerRatioChangeRange = (skillExist ? skill.GetInnerRatioChangeRange() : configData.InnerRatioChangeRange);
		data.CurrInnerRatio = (skillExist ? skill.GetCurrInnerRatio() : skill.GetInnerRatio());
		data.ExpectInnerRatio = skill.GetInnerRatio();
		data.NewUnderstandingNeedExp = (skillExist ? GetNewUnderstandingNeedExp(charId, skillTemplateId) : (-1));
		data.BreakSuccess = GetBreakSuccess(charId, skillTemplateId);
		data.EffectDescription = (skillExist ? GetEffectDisplayData(skill) : CombatSkillEffectDescriptionDisplayData.Invalid);
		data.DamageStepBonus = (skillExist ? skill.CalcStepBonusDisplayData() : default(CombatSkillDamageStepBonusDisplayData));
		data.BodyPartDamageStepActive = CalcBodyPartDamageStepActive(charId, skillTemplateId);
		data.IsInAnyEquipPlans = IsCombatSkillInAnyEquipPlan(skillTemplateId, character, isTaiwu);
		data.IsInCurrentEquipPlan = IsCombatSkillInCurrentEquipPlan(skillTemplateId, character);
		data.HasSectEmeiSkillBreakBonus = DomainManager.Story.TryGetEmeiExtraBonusCollection(skillTemplateId, out var _);
		data.LuohanId = (sbyte)(isTaiwu ? DomainManager.Taiwu.GetCombatSkillLuohanId(skillTemplateId) : ((!character.IsGearMate) ? (-1) : (DomainManager.Extra.GetGearMateById(charId).LuohanBreakDict?.GetValueOrDefault<short, sbyte>(skillTemplateId, -1) ?? (-1))));
		data.IsFavorite = isFavorite;
		data.LegendaryBookSlotIds = CalcLegendaryBookSlotIds(skillTemplateId);
		if (skillExist)
		{
			IEnumerable<SkillBreakPlateBonus> breakBonues = skill.GetBreakBonuses();
			data.BreakBonusGrades = new List<sbyte>();
			foreach (SkillBreakPlateBonus breakBonus in breakBonues)
			{
				data.BreakBonusGrades.Add(breakBonus.Grade);
			}
		}
		if (!skillExist)
		{
			for (int j = 0; j < data.Requirements.Count; j++)
			{
				(int, int, int) requirement = data.Requirements[j];
				requirement.Item3 = -1;
				data.Requirements[j] = requirement;
			}
		}
		switch (configData.EquipType)
		{
		case 0:
			CalcNeigongSkillDisplayData(data, skillExist, skill, configData);
			break;
		case 1:
			CalcAttackSkillDisplayData(skillTemplateId, charId, data, skillExist, configData, skill);
			break;
		case 2:
			CalcAgileSkillDisplayData(data, skill, skillExist, configData);
			break;
		case 3:
			CalcDefenseSkillDisplayData(data, skillExist, skill, configData);
			break;
		}
		if (GameData.Domains.Character.CombatSkillHelper.IsProactiveSkill(configData.EquipType))
		{
			CalcProactiveSkillDisplayData(data, skill, skillExist, configData, inCombat, combatChar);
		}
		if (inCombat)
		{
			CalcInCombatSkillDisplayData(data);
		}
		CalcSkillDisplayDataFiveElement(data, charId, character);
		return data;
	}

	private List<short> CalcLegendaryBookSlotIds(short skillTemplateId)
	{
		List<short> result = new List<short>();
		CombatSkillItem configData = Config.CombatSkill.Instance[skillTemplateId];
		sbyte skillType = configData.Type;
		if (!DomainManager.Extra.TryGetElement_LegendaryBookSkillSlot(skillType, out var skillSlots))
		{
			return result;
		}
		CombatSkillTypeItem typeConfig = Config.CombatSkillType.Instance[skillType];
		List<short> legendaryBookSkillSlots = typeConfig.LegendaryBookSkillSlots;
		for (int i = 0; i < skillSlots.Items.Count && i < legendaryBookSkillSlots.Count; i++)
		{
			if (skillSlots.Items[i] == skillTemplateId)
			{
				result.Add(legendaryBookSkillSlots[i]);
			}
		}
		return result;
	}

	private CombatSkillDisplayDataCharacterMenuListItem CalcCombatSkillDisplayDataCharacterMenuListItem(short skillTemplateId, int charId, GameData.Domains.Character.Character character)
	{
		if (character == null)
		{
			PredefinedLog.Show(12, $"CalcCombatSkillDisplayData {skillTemplateId} {charId}");
			return null;
		}
		CombatSkillItem configData = Config.CombatSkill.Instance[skillTemplateId];
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		bool skillExist = _combatSkills.ContainsKey(skillKey);
		CombatSkill skill = (skillExist ? _combatSkills[skillKey] : new CombatSkill(charId, skillTemplateId, 0));
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		VoidValue value;
		bool isFavorite = DomainManager.Taiwu.TryGetElement_FavoriteCombatSkills(skillTemplateId, out value);
		CombatSkillDisplayDataCharacterMenuListItem data = new CombatSkillDisplayDataCharacterMenuListItem();
		data.CharId = charId;
		data.TemplateId = skillTemplateId;
		data.ReadingState = skill.GetReadingState();
		data.ActivationState = skill.GetActivationState();
		data.Power = (short)(skillExist ? skill.GetPower() : 100);
		data.BreakSuccess = GetBreakSuccess(charId, skillTemplateId);
		data.Mastered = DomainManager.Extra.GetCharacterMasteredCombatSkills(charId).Items?.Contains(skillTemplateId) ?? false;
		data.CanAffect = character.GetCombatSkillCanAffect(skillTemplateId);
		data.Conflicting = DomainManager.Extra.GetConflictCombatSkill(skillTemplateId) != null;
		data.GridCount = character.GetCombatSkillGridCost(skillTemplateId);
		data.IsFavorite = isFavorite;
		data.CombatSkillProficiency = (DomainManager.Extra.TryGetElement_CombatSkillProficiencies(skillKey, out var prof) ? prof : 0);
		data.IsInAnyEquipPlans = IsCombatSkillInAnyEquipPlan(skillTemplateId, character, isTaiwu);
		data.IsInCurrentEquipPlan = IsCombatSkillInCurrentEquipPlan(skillTemplateId, character);
		data.HasSectEmeiSkillBreakBonus = DomainManager.Story.TryGetEmeiExtraBonusCollection(skillTemplateId, out var _);
		if (skillExist)
		{
			data.MaxObtainableNeili = skill.GetTotalObtainableNeili();
			data.ObtainedNeili = skill.GetObtainedNeili();
		}
		else
		{
			data.MaxObtainableNeili = configData.TotalObtainableNeili;
			data.ObtainedNeili = 0;
		}
		CalcSkillDisplayDataFiveElement(data, charId, character);
		if (skillExist)
		{
			IEnumerable<SkillBreakPlateBonus> breakBonues = skill.GetBreakBonuses();
			data.BreakBonusGrades = new List<sbyte>();
			foreach (SkillBreakPlateBonus breakBonus in breakBonues)
			{
				data.BreakBonusGrades.Add(breakBonus.Grade);
			}
			data.LuohanId = (sbyte)(isTaiwu ? DomainManager.Taiwu.GetCombatSkillLuohanId(skillTemplateId) : ((!character.IsGearMate) ? (-1) : (DomainManager.Extra.GetGearMateById(charId).LuohanBreakDict?.GetValueOrDefault<short, sbyte>(skillTemplateId, -1) ?? (-1))));
			data.Revoked = skill.GetRevoked();
		}
		return data;
	}

	public CombatSkillDisplayDataCharacterMenuListItem GetCombatSkillDisplayDataCharacterMenuListItem(short skillTemplateId, int charId, GameData.Domains.Character.Character character)
	{
		return CalcCombatSkillDisplayDataCharacterMenuListItem(skillTemplateId, charId, character);
	}

	private static bool IsCombatSkillInAnyEquipPlan(short skillTemplateId, GameData.Domains.Character.Character character, bool isTaiwu)
	{
		if (isTaiwu)
		{
			return DomainManager.Taiwu.IsCombatSkillInPlans(skillTemplateId);
		}
		short[] equippedCombatSkills = character.GetEquippedCombatSkills();
		return Enumerable.Contains(equippedCombatSkills, skillTemplateId);
	}

	private static bool IsCombatSkillInCurrentEquipPlan(short skillTemplateId, GameData.Domains.Character.Character character)
	{
		return character.GetCombatSkillEquipment().IsCombatSkillEquipped(skillTemplateId);
	}

	private List<CombatSkillDisplayData> CalcCombatSkillDisplayDataList(int charId, IEnumerable<short> skillTemplateIdList)
	{
		List<CombatSkillDisplayData> dataList = new List<CombatSkillDisplayData>();
		if (skillTemplateIdList == null)
		{
			return dataList;
		}
		GameData.Domains.Character.Character character = null;
		if (charId >= 0 && !DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			charId = -1;
		}
		if (charId < 0)
		{
			charId = DomainManager.Taiwu.GetTaiwuCharId();
			character = DomainManager.Taiwu.GetTaiwu();
		}
		foreach (short skillTemplateId in skillTemplateIdList)
		{
			if (skillTemplateId >= 0)
			{
				dataList.Add(CalcCombatSkillDisplayData(skillTemplateId, charId, character));
			}
		}
		return dataList;
	}

	private static void CalcNeigongSkillDisplayData(CombatSkillDisplayData data, bool skillExist, CombatSkill skill, CombatSkillItem configData, bool preview = false)
	{
		if (skillExist)
		{
			data.MaxObtainableNeili = skill.GetTotalObtainableNeili();
			data.ObtainedNeili = skill.GetObtainedNeili();
			data.SpecificGrids = skill.GetSpecificGridCount(preview);
			data.GenericGrid = skill.GetGenericGridCount(preview);
		}
		else
		{
			data.MaxObtainableNeili = configData.TotalObtainableNeili;
			data.ObtainedNeili = 0;
			data.SpecificGrids = configData.SpecificGrids;
			data.GenericGrid = configData.GenericGrid;
		}
	}

	private unsafe void CalcAttackSkillDisplayData(short skillTemplateId, int charId, CombatSkillDisplayData data, bool skillExist, CombatSkillItem configData, CombatSkill skill)
	{
		if (skillExist)
		{
			data.AddAttackDistanceForward = GetCombatSkillAddAttackDistance(charId, skillTemplateId, forward: true);
			data.AddAttackDistanceBackward = GetCombatSkillAddAttackDistance(charId, skillTemplateId, forward: false);
			data.Poisons = skill.GetPoisons();
			HitOrAvoidInts hitValue = skill.GetHitValue();
			OuterAndInnerInts penetrations = skill.GetPenetrations();
			TaiwuCombatSkill taiwuSkill;
			sbyte fullPowerCastTimes = (sbyte)((charId == DomainManager.Taiwu.GetTaiwuCharId() && DomainManager.Taiwu.TryGetElement_CombatSkills(skillTemplateId, out taiwuSkill)) ? taiwuSkill.FullPowerCastTimes : 0);
			data.HitValueStrength = hitValue.Items[0];
			data.HitValueTechnique = hitValue.Items[1];
			data.HitValueSpeed = hitValue.Items[2];
			data.HitValueMind = hitValue.Items[3];
			data.PenetrateValueInner = penetrations.Inner;
			data.PenetrateValueOuter = penetrations.Outer;
			data.HitDistribution = skill.GetHitDistribution();
			data.BodyPartWeights = new List<int>(skill.GetBodyPartWeights());
			data.FullPowerCastTimes = fullPowerCastTimes;
			return;
		}
		data.AddAttackDistanceForward = configData.DistanceAdditionWhenCast;
		data.AddAttackDistanceBackward = configData.DistanceAdditionWhenCast;
		data.Poisons = configData.Poisons;
		sbyte[] distribution = configData.PerHitDamageRateDistribution;
		int totalHit = configData.TotalHit;
		data.HitValueStrength = (data.HitValueTechnique = (data.HitValueSpeed = (data.HitValueMind = 0)));
		if (CombatSkillEquipType.IsMindHitSkill(skillTemplateId))
		{
			data.HitValueMind = totalHit;
		}
		else
		{
			data.HitValueStrength = totalHit * distribution[0] / 100;
			data.HitValueStrength = totalHit * distribution[1] / 100;
			data.HitValueStrength = totalHit * distribution[2] / 100;
		}
		short totalPenetrate = configData.Penetrate;
		data.PenetrateValueInner = totalPenetrate * data.CurrInnerRatio / 100;
		data.PenetrateValueOuter = totalPenetrate - data.PenetrateValueInner;
		ref int items = ref data.HitDistribution.Items[0];
		items = distribution[0];
		data.HitDistribution.Items[1] = distribution[1];
		data.HitDistribution.Items[2] = distribution[2];
		data.HitDistribution.Items[3] = distribution[3];
		data.BodyPartWeights = new List<int>(((IEnumerable<sbyte>)configData.InjuryPartAtkRateDistribution).Select((Func<sbyte, int>)((sbyte x) => x)));
		data.FullPowerCastTimes = 0;
	}

	private unsafe void CalcAgileSkillDisplayData(CombatSkillDisplayData data, CombatSkill skill, bool skillExist, CombatSkillItem configData)
	{
		data.JumpSpeed = CalcJumpSpeed(data.CharId, data.TemplateId);
		data.AddMoveSpeed = CalcCastAddMoveSpeed(skill, data.Power);
		data.AddPercentMoveSpeed = CalcCastAddPercentMoveSpeed(skill, data.Power);
		if (skillExist)
		{
			HitOrAvoidInts addHit = CalcAddHitValueOnCast(skill, data.Power);
			data.AddHitStrength = addHit.Items[0];
			data.AddHitTechnique = addHit.Items[1];
			data.AddHitSpeed = addHit.Items[2];
			data.AddHitMind = addHit.Items[3];
		}
		else
		{
			data.AddAvoidStrength = configData.AddHitOnCast[0];
			data.AddAvoidTechnique = configData.AddHitOnCast[1];
			data.AddAvoidSpeed = configData.AddHitOnCast[2];
			data.AddAvoidMind = configData.AddHitOnCast[3];
		}
	}

	private unsafe static void CalcDefenseSkillDisplayData(CombatSkillDisplayData data, bool skillExist, CombatSkill skill, CombatSkillItem configData)
	{
		if (skillExist)
		{
			HitOrAvoidInts addAvoid = CalcAddAvoidValueOnCast(skill, data.Power);
			OuterAndInnerInts addPenetrateResist = CalcAddPenetrateResist(skill, data.Power);
			OuterAndInnerInts bouncePower = CalcBouncePower(skill, data.Power);
			data.EffectDuration = CalcContinuousFrames(skill);
			data.AddOuterDef = addPenetrateResist.Outer;
			data.AddInnerDef = addPenetrateResist.Inner;
			data.AddAvoidStrength = addAvoid.Items[0];
			data.AddAvoidTechnique = addAvoid.Items[1];
			data.AddAvoidSpeed = addAvoid.Items[2];
			data.AddAvoidMind = addAvoid.Items[3];
			data.FightbackPower = CalcFightBackPower(skill, data.Power);
			data.BouncePowerOuter = bouncePower.Outer;
			data.BouncePowerInner = bouncePower.Inner;
			data.BounceDistance = skill.GetBounceDistance();
		}
		else
		{
			data.EffectDuration = configData.ContinuousFrames;
			data.AddOuterDef = configData.AddOuterPenetrateResistOnCast;
			data.AddInnerDef = configData.AddInnerPenetrateResistOnCast;
			data.AddAvoidStrength = configData.AddAvoidOnCast[0];
			data.AddAvoidTechnique = configData.AddAvoidOnCast[1];
			data.AddAvoidSpeed = configData.AddAvoidOnCast[2];
			data.AddAvoidMind = configData.AddAvoidOnCast[3];
			data.FightbackPower = configData.FightBackDamage;
			data.BouncePowerOuter = configData.BounceRateOfOuterInjury;
			data.BouncePowerInner = configData.BounceRateOfInnerInjury;
			data.BounceDistance = configData.BounceDistance;
		}
	}

	private unsafe void CalcProactiveSkillDisplayData(CombatSkillDisplayData data, CombatSkill skill, bool skillExist, CombatSkillItem configData, bool inCombat, CombatCharacter combatChar)
	{
		data.CostMobility = (skillExist ? skill.GetCostMobilityPercent() : configData.MobilityCost);
		data.CostNeiliAllocation = ((sbyte, sbyte))(skillExist ? (((int, int))skill.GetCostNeiliAllocation()) : (-1, 0));
		data.CostTricks = new List<NeedTrick>();
		GetCombatSkillCostTrick(skill, data.CostTricks);
		if (inCombat)
		{
			int costMobility = MoveSpecialConstants.MaxMobility * data.CostMobility / 100;
			NeiliAllocation neiliAllocations = combatChar.GetNeiliAllocation();
			TrickCollection tricks = combatChar.GetTricks();
			if (skillExist)
			{
				DomainManager.Combat.GetSkillCostBreathStance(combatChar.GetId(), skill).Deconstruct(out var outer, out var inner);
				int stance = outer;
				int breath = inner;
				sbyte costStance = (sbyte)stance;
				sbyte costBreath = (sbyte)breath;
				data.CostStance = costStance;
				data.CostBreath = costBreath;
				data.CostBreathFontType = Convert(combatChar.GetBreathValue() >= 30000 * data.CostBreath / 100);
				data.CostStanceFontType = Convert(combatChar.GetStanceValue() >= 4000 * data.CostStance / 100);
			}
			else
			{
				PredefinedLog.Show(13, $"Skill not exist in combat {combatChar} {configData.Name}");
				data.CostBreath = (data.CostStance = 50);
				data.CostBreathFontType = (data.CostStanceFontType = Convert(enough: false));
			}
			data.CostMobilityFontType = Convert(combatChar.GetMobilityValue() >= costMobility);
			data.CostNeiliAllocationFontType = Convert(neiliAllocations.Items[data.CostNeiliAllocation.Item1] >= data.CostNeiliAllocation.Item2);
			data.CostWeaponDurabilityFontType = Convert(combatChar.GetUsingWeaponIndex() >= 3 || DomainManager.Item.GetElement_Weapons(DomainManager.Combat.GetUsingWeaponKey(combatChar).Id).GetCurrDurability() >= configData.WeaponDurableCost);
			data.CostWugFontType = Convert(combatChar.GetWugCount() >= configData.WugCost);
			data.CostTricksFontType = new List<sbyte>();
			for (int k = 0; k < data.CostTricks.Count; k++)
			{
				NeedTrick needTrick = data.CostTricks[k];
				int counter = 0;
				foreach (sbyte trickType in tricks.Tricks.Values)
				{
					if (combatChar.TrickEquals(trickType, needTrick.TrickType))
					{
						counter++;
					}
				}
				data.CostTricksFontType.Add(Convert(counter >= needTrick.NeedCount));
			}
		}
		else
		{
			data.CostBreath = (skillExist ? skill.GetCostBreathPercent() : ((sbyte)(configData.BreathStanceTotalCost * data.CurrInnerRatio / 100)));
			data.CostStance = (skillExist ? skill.GetCostStancePercent() : ((sbyte)(configData.BreathStanceTotalCost - data.CostBreath)));
			data.CostBreathFontType = (data.CostStanceFontType = (data.CostMobilityFontType = (data.CostNeiliAllocationFontType = (data.CostWeaponDurabilityFontType = (data.CostWugFontType = 0)))));
			data.CostTricksFontType = new List<sbyte>();
			for (int i = 0; i < data.CostTricks.Count; i++)
			{
				data.CostTricksFontType.Add(0);
			}
		}
		static sbyte Convert(bool enough)
		{
			return (sbyte)(enough ? 1 : 2);
		}
	}

	private void CalcInCombatSkillDisplayData(CombatSkillDisplayData data)
	{
		if (DomainManager.Combat.TryGetCombatSkillData(data.CharId, data.TemplateId, out var combatSkillData))
		{
			data.EffectData = combatSkillData.GetEffectData();
		}
	}

	private void CalcSkillDisplayDataFiveElement(IFilterableCombatSkill data, int charId, GameData.Domains.Character.Character character)
	{
		bool isTaiwu = charId == DomainManager.Taiwu.GetTaiwuCharId();
		CombatSkillItem configData = Config.CombatSkill.Instance[data.TemplateId];
		data.FiveElementDestTypeWhileLooping = configData.DestTypeWhileLooping;
		data.FiveElementTransferTypeWhileLooping = configData.TransferTypeWhileLooping;
		if (!isTaiwu)
		{
			return;
		}
		short loopingNeigong = character.GetLoopingNeigong();
		if (loopingNeigong < 0 || data.TemplateId != loopingNeigong || !DomainManager.Extra.TryGetElement_QiArtStrategyMap(loopingNeigong, out var qiArtStrategyList) || qiArtStrategyList.Items == null || qiArtStrategyList.Items.Count == 0)
		{
			return;
		}
		sbyte taiwuNeiliType = character.GetNeiliType();
		foreach (sbyte strategy in qiArtStrategyList.Items)
		{
			if (strategy != -1)
			{
				QiArtStrategyItem strategyConfig = QiArtStrategy.Instance[strategy];
				if (strategyConfig.TransferToFiveElements > -1 && strategyConfig.FiveElementsTransferType > -1)
				{
					data.FiveElementDestTypeWhileLooping = strategyConfig.TransferToFiveElements;
					data.FiveElementTransferTypeWhileLooping = strategyConfig.FiveElementsTransferType;
				}
				short strategyAnchoredFiveElements = strategyConfig.AnchorFiveElements;
				NeiliTypeItem neiliTypeConfig = NeiliType.Instance[taiwuNeiliType];
				bool isConflict = neiliTypeConfig.ColorType == 2;
				if (strategyAnchoredFiveElements != -1 && !isConflict && neiliTypeConfig.FiveElements == strategyAnchoredFiveElements)
				{
					data.FiveElementDestTypeWhileLooping = strategyConfig.TransferToFiveElements;
					data.FiveElementTransferTypeWhileLooping = strategyConfig.FiveElementsTransferType;
					break;
				}
			}
		}
	}

	public CombatSkillEffectDescriptionDisplayData GetEffectDisplayData(CombatSkillKey skillKey)
	{
		CombatSkill skill;
		return TryGetElement_CombatSkills(skillKey, out skill) ? GetEffectDisplayData(skill) : CombatSkillEffectDescriptionDisplayData.Invalid;
	}

	public CombatSkillEffectDescriptionDisplayData GetEffectDisplayData(int charId, short skillTemplateId)
	{
		return GetEffectDisplayData(new CombatSkillKey(charId, skillTemplateId));
	}

	public CombatSkillEffectDescriptionDisplayData GetEffectDisplayData(CombatSkill skill)
	{
		CombatSkillItem config = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		sbyte direction = skill.GetDirection();
		CombatSkillEffectDescriptionDisplayData result = default(CombatSkillEffectDescriptionDisplayData);
		bool flag = ((direction < 0 || direction >= 2) ? true : false);
		result.EffectId = (flag ? (-1) : ((direction == 0) ? config.DirectEffectID : config.ReverseEffectID));
		result.AffectRequirePower = (skill.AnyAffectRequirePower() ? new List<int>(skill.GetAffectRequirePower()) : null);
		return result;
	}

	public short GetCombatSkillAddAttackDistance(int charId, short skillId, bool forward)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		ushort fieldId = (ushort)(forward ? 145 : 146);
		int distance = DomainManager.SpecialEffect.GetModifyValue(charId, skillId, fieldId, EDataModifyType.Add);
		distance -= DomainManager.SpecialEffect.GetModifyValue(charId, -1, fieldId, EDataModifyType.Add);
		if (skillId >= 0)
		{
			distance += (_combatSkills.TryGetValue(skillKey, out var skill) ? skill.GetDistanceAdditionWhenCast(forward) : Config.CombatSkill.Instance[skillId].DistanceAdditionWhenCast);
		}
		return (short)distance;
	}

	public void GetCombatSkillCostTrick(CombatSkill skill, List<NeedTrick> costTricks, bool applySpecialEffect = true)
	{
		CombatSkillKey skillKey = skill.GetId();
		costTricks.Clear();
		costTricks.AddRange(Config.CombatSkill.Instance[skillKey.SkillTemplateId].TrickCost);
		List<int> removedTrickIndexes = ObjectPool<List<int>>.Instance.Get();
		removedTrickIndexes.Clear();
		for (int i = 0; i < costTricks.Count; i++)
		{
			bool isLast = removedTrickIndexes.Count == costTricks.Count - 1;
			short propertyId = (short)(53 + costTricks[i].TrickType);
			int index = i;
			NeedTrick value = costTricks[i];
			value.NeedCount = (byte)Math.Max(isLast ? 1 : 0, costTricks[i].NeedCount + skill.GetBreakoutGridCombatSkillPropertyBonus(propertyId));
			costTricks[index] = value;
			if (costTricks[i].NeedCount == 0)
			{
				removedTrickIndexes.Add(i);
			}
		}
		for (int i2 = removedTrickIndexes.Count - 1; i2 >= 0; i2--)
		{
			costTricks.RemoveAt(removedTrickIndexes[i2]);
		}
		ObjectPool<List<int>>.Instance.Return(removedTrickIndexes);
		if (applySpecialEffect)
		{
			DomainManager.SpecialEffect.ModifyData(skillKey.CharId, skillKey.SkillTemplateId, 208, costTricks);
		}
	}

	public sbyte GetCombatSkillGridCost(int charId, short skillTemplateId)
	{
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return character.GetCombatSkillGridCost(skillTemplateId);
		}
		return Config.CombatSkill.Instance[skillTemplateId].GridCost;
	}

	public static int CalcJumpSpeed(int charId, short skillTemplateId)
	{
		GameData.Domains.Character.Character character;
		int moveSpeed = (DomainManager.Character.TryGetElement_Objects(charId, out character) ? character.GetMoveSpeed() : 100);
		int jumpSpeed = CFormula.CalcJumpSpeed(moveSpeed);
		CValuePercentBonus percent = DomainManager.SpecialEffect.GetModifyValue(charId, skillTemplateId, 152, EDataModifyType.AddPercent);
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(skillKey, out var skill))
		{
			percent += (CValuePercentBonus)skill.GetBreakoutGridCombatSkillPropertyBonus(69);
		}
		return jumpSpeed * percent;
	}

	public static short CalcCastAddMoveSpeed(CombatSkill skill, CValuePercent power)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent baseValue = GlobalConfig.Instance.AgileSkillBaseAddSpeed;
		CValuePercentBonus gridBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(11);
		return (short)(configData.AddMoveSpeedOnCast * baseValue * gridBonus * power);
	}

	public static short CalcCastAddPercentMoveSpeed(CombatSkill skill, CValuePercent power)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		return (short)(configData.AddPercentMoveSpeedOnCast * power);
	}

	public static HitOrAvoidInts CalcAddHitValueOnCast(CombatSkill skill, CValuePercent power)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent baseValue = GlobalConfig.Instance.AgileSkillBaseAddHit;
		HitOrAvoidInts addHit = default(HitOrAvoidInts);
		int globalGridBonus = 0;
		foreach (SkillBreakPlateBonus breakBonuse in skill.GetBreakBonuses())
		{
			globalGridBonus += breakBonuse.CalcAddHitOnCast();
		}
		for (int i = 0; i < 4; i++)
		{
			CValuePercentBonus gridBonus = skill.GetBreakoutGridCombatSkillPropertyBonus((short)(12 + i));
			gridBonus += (CValuePercentBonus)globalGridBonus;
			addHit[i] = configData.AddHitOnCast[i] * baseValue * gridBonus * power;
		}
		return addHit;
	}

	public static OuterAndInnerInts CalcAddPenetrateResist(CombatSkill skill, CValuePercent power)
	{
		OuterAndInnerInts addPenetrate = default(OuterAndInnerInts);
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent baseValue = GlobalConfig.Instance.DefendSkillBaseAddPenetrateResist;
		CValuePercentBonus outerBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(18);
		CValuePercentBonus innerBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(19);
		foreach (SkillBreakPlateBonus bonus in skill.GetBreakBonuses())
		{
			outerBonus += (CValuePercentBonus)bonus.CalcAddPenetrateResist();
			innerBonus += (CValuePercentBonus)bonus.CalcAddPenetrateResist();
		}
		addPenetrate.Outer = configData.AddOuterPenetrateResistOnCast * baseValue * outerBonus * power;
		addPenetrate.Inner = configData.AddInnerPenetrateResistOnCast * baseValue * innerBonus * power;
		return addPenetrate;
	}

	public static short CalcContinuousFrames(CombatSkill skill)
	{
		return (short)DomainManager.SpecialEffect.ModifyValue(skill.GetId().CharId, skill.GetId().SkillTemplateId, 176, skill.GetContinuousFrames());
	}

	public static HitOrAvoidInts CalcAddAvoidValueOnCast(CombatSkill skill, CValuePercent power)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent baseValue = GlobalConfig.Instance.DefendSkillBaseAddAvoid;
		HitOrAvoidInts addAvoid = default(HitOrAvoidInts);
		int globalGridBonus = 0;
		foreach (SkillBreakPlateBonus breakBonuse in skill.GetBreakBonuses())
		{
			globalGridBonus += breakBonuse.CalcAddAvoidValueOnCast();
		}
		for (int i = 0; i < 4; i++)
		{
			CValuePercentBonus bonus = skill.GetBreakoutGridCombatSkillPropertyBonus((short)(20 + i));
			bonus += (CValuePercentBonus)globalGridBonus;
			addAvoid[i] = configData.AddAvoidOnCast[i] * baseValue * bonus * power;
		}
		return addAvoid;
	}

	public static int CalcFightBackPower(CombatSkill skill, CValuePercent power)
	{
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent basePower = GlobalConfig.Instance.DefendSkillBaseFightBackPower;
		CValuePercentBonus gridBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(24);
		foreach (SkillBreakPlateBonus breakBonuse in skill.GetBreakBonuses())
		{
			gridBonus += (CValuePercentBonus)breakBonuse.CalcFightBackPower();
		}
		return configData.FightBackDamage * gridBonus * basePower * power;
	}

	public static OuterAndInnerInts CalcBouncePower(CombatSkill skill, CValuePercent power)
	{
		OuterAndInnerInts addPenetrate = default(OuterAndInnerInts);
		CombatSkillItem configData = Config.CombatSkill.Instance[skill.GetId().SkillTemplateId];
		CValuePercent basePower = GlobalConfig.Instance.DefendSkillBaseBouncePower;
		CValuePercentBonus outerBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(25);
		CValuePercentBonus innerBonus = skill.GetBreakoutGridCombatSkillPropertyBonus(26);
		foreach (SkillBreakPlateBonus bonus in skill.GetBreakBonuses())
		{
			outerBonus += (CValuePercentBonus)bonus.CalcBouncePower();
			innerBonus += (CValuePercentBonus)bonus.CalcBouncePower();
		}
		addPenetrate.Outer = configData.BounceRateOfOuterInjury * outerBonus * basePower * power;
		addPenetrate.Inner = configData.BounceRateOfInnerInjury * innerBonus * basePower * power;
		return addPenetrate;
	}

	public int GetNewUnderstandingNeedExp(int charId, short skillTemplateId)
	{
		if (charId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return 0;
		}
		sbyte stepCount = DomainManager.CombatSkill.GetCombatSkillBreakStepCount(charId, skillTemplateId);
		int count = Math.Max(50 - stepCount, 0);
		CombatSkillItem combatSkillConfig = Config.CombatSkill.Instance[skillTemplateId];
		short costExp = Config.SkillBreakPlate.Instance[combatSkillConfig.Grade].CostExp;
		return count * costExp;
	}

	public bool GetBreakSuccess(int charId, short skillTemplateId)
	{
		if (charId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return false;
		}
		if (!TryGetElement_CombatSkills((charId: charId, skillId: skillTemplateId), out var skill))
		{
			return false;
		}
		return CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState());
	}

	[DomainMethod]
	public CombatSkillDisplayData GetCombatSkillPreviewDisplayDataOnce(int charId, short skillTemplateId)
	{
		GameData.Domains.Character.Character character = null;
		if (charId >= 0 && !DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			charId = -1;
		}
		if (charId < 0)
		{
			charId = DomainManager.Taiwu.GetTaiwuCharId();
			character = DomainManager.Taiwu.GetTaiwu();
		}
		CombatSkillDisplayData displayData = CalcCombatSkillDisplayData(skillTemplateId, charId, character);
		bool isMastered = DomainManager.Extra.IsCombatSkillMasteredByCharacter(charId, skillTemplateId);
		displayData.GridCount += (sbyte)(isMastered ? 1 : (-1));
		CombatSkillItem configData = Config.CombatSkill.Instance[skillTemplateId];
		if (configData.EquipType == 0)
		{
			CombatSkillKey skillKey = new CombatSkillKey(charId, skillTemplateId);
			bool skillExist = _combatSkills.ContainsKey(skillKey);
			CombatSkill skill = (skillExist ? _combatSkills[skillKey] : new CombatSkill(charId, skillTemplateId, 0));
			CalcNeigongSkillDisplayData(displayData, skillExist, skill, configData, preview: true);
		}
		displayData.Mastered = !isMastered;
		displayData.PreviewMastered = true;
		return displayData;
	}

	[DomainMethod]
	public List<SkillBreakPlateBonus> GetCombatSkillBreakBonuses(int charId, short skillTemplateId)
	{
		List<SkillBreakPlateBonus> result = new List<SkillBreakPlateBonus>();
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(charId, skillTemplateId), out var skill))
		{
			return result;
		}
		return skill.GetBreakBonuses().ToList();
	}

	[DomainMethod]
	public CombatSkillBreakSuccessRateDisplayData CalcTaiwuCombatSkillBreakSuccessRate(short skillTemplateId)
	{
		CombatSkillBreakSuccessRateDisplayData result = new CombatSkillBreakSuccessRateDisplayData();
		CombatSkill skill;
		bool isBroken = DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(DomainManager.Taiwu.GetTaiwuCharId(), skillTemplateId), out skill) && CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState());
		DomainManager.Taiwu.CalcTaiwuBreakBaseSuccessRate(Config.CombatSkill.Instance[skillTemplateId], result, !isBroken);
		return result;
	}

	[DomainMethod]
	public CombatSkillBreakAvailableStepsDisplayData CalcCombatSkillBreakAvailableStepsDisplayData(int charId, short skillTemplateId)
	{
		CombatSkillBreakAvailableStepsDisplayData result = new CombatSkillBreakAvailableStepsDisplayData();
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			CombatSkill skill;
			bool isBroken = DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(charId, skillTemplateId), out skill) && CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState());
			character.GetSkillBreakoutAvailableStepsCount(skillTemplateId, result, !isBroken);
		}
		return result;
	}

	[DomainMethod]
	public List<CombatSkillDisplayDataCharacterMenuListItem> GetCharacterMenuCombatSkillListItemDisplayData(DataContext context, int charId)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var targetChar))
		{
			return null;
		}
		List<short> learnedSkills = targetChar.GetLearnedCombatSkills();
		if (learnedSkills == null)
		{
			return null;
		}
		List<CombatSkillDisplayDataCharacterMenuListItem> result = new List<CombatSkillDisplayDataCharacterMenuListItem>();
		for (int i = 0; i < learnedSkills.Count; i++)
		{
			result.Add(CalcCombatSkillDisplayDataCharacterMenuListItem(learnedSkills[i], charId, targetChar));
		}
		return result;
	}

	private List<bool> CalcBodyPartDamageStepActive(int charId, short skillTemplateId)
	{
		CompleteDamageStepDisplayData completeData = DomainManager.Combat.GetCompleteDamageStepDisplayData(charId);
		List<bool> result = new List<bool>(9);
		for (int i = 0; i < 7; i++)
		{
			OuterAndInnerDamageStepDisplayData partData = completeData.BodyPart[i];
			bool active = partData.Outer.ActivateSkillTemplateId == skillTemplateId || partData.Inner.ActivateSkillTemplateId == skillTemplateId;
			result.Add(active);
		}
		result.Add(completeData.Fatal.ActivateSkillTemplateId == skillTemplateId);
		result.Add(completeData.Mind.ActivateSkillTemplateId == skillTemplateId);
		return result;
	}

	public static List<BreakGrid> GetBonusBreakGrids(short skillTemplateId, sbyte behaviorType)
	{
		SkillBreakGridListItem configData = SkillBreakGridList.Instance[skillTemplateId];
		if (configData == null)
		{
			return null;
		}
		if (1 == 0)
		{
		}
		List<BreakGrid> result = behaviorType switch
		{
			0 => configData.BreakGridListJust, 
			1 => configData.BreakGridListKind, 
			2 => configData.BreakGridListEven, 
			3 => configData.BreakGridListRebel, 
			4 => configData.BreakGridListEgoistic, 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public static IEnumerable<int> FiveElementIndexes(int charId, CombatSkillItem config)
	{
		yield return config.FiveElements;
		BoolArray8 alsoAs = DomainManager.SpecialEffect.ModifyData(charId, config.TemplateId, 240, (byte)0, config.FiveElements);
		for (int i = 0; i <= 5; i++)
		{
			if (i != config.FiveElements && alsoAs[i])
			{
				yield return i;
			}
		}
	}

	public static bool FiveElementEquals(int charId, CombatSkillItem config, sbyte fiveElement)
	{
		if ((fiveElement < 0 || fiveElement > 5) ? true : false)
		{
			return false;
		}
		return config.FiveElements == fiveElement || DomainManager.SpecialEffect.ModifyData(charId, config.TemplateId, 240, (byte)0, config.FiveElements)[fiveElement];
	}

	public static bool FiveElementEquals(int charId, short skillId, sbyte fiveElement)
	{
		return skillId >= 0 && FiveElementEquals(charId, Config.CombatSkill.Instance[skillId], fiveElement);
	}

	public static bool FiveElementEquals(int charId, CombatSkillItem config, IEnumerable<sbyte> fiveElements)
	{
		return fiveElements.Any((sbyte fiveElement) => FiveElementEquals(charId, config, fiveElement));
	}

	public static int FiveElementIndexesSum(int charId, CombatSkillItem config, sbyte[] properties)
	{
		int sum = 0;
		foreach (int fiveElement in FiveElementIndexes(charId, config))
		{
			sum += properties[fiveElement];
		}
		return sum;
	}

	public static (int min, int max) FiveElementIndexesTotal(int charId, CombatSkillItem config, sbyte[] properties)
	{
		int min = 0;
		int max = 0;
		foreach (int fiveElement in FiveElementIndexes(charId, config))
		{
			int num = Math.Min(min, properties[fiveElement]);
			max = Math.Max(max, properties[fiveElement]);
			min = num;
		}
		return (min: min, max: max);
	}

	public static bool FiveElementMatch(int charId, CombatSkillItem config, List<sbyte> fiveElementsLimit)
	{
		return fiveElementsLimit == null || fiveElementsLimit.Count == 0 || FiveElementEquals(charId, config, fiveElementsLimit);
	}

	public static bool FiveElementContains(int charId, CombatSkillItem config, List<byte> fiveElements)
	{
		return fiveElements != null && fiveElements.Count > 0 && FiveElementEquals(charId, config, fiveElements.Select((byte x) => (sbyte)x));
	}

	public CombatSkillDomain()
		: base(1)
	{
		_combatSkills = new CombatSkillCollection(8192);
		HelperDataCombatSkills = new ObjectCollectionHelperData(7, 0, CacheInfluencesCombatSkills, _dataStatesCombatSkills, isArchive: true);
		OnInitializedDomainData();
	}

	public CombatSkill GetElement_CombatSkills(CombatSkillKey objectId)
	{
		return _combatSkills[objectId];
	}

	public bool TryGetElement_CombatSkills(CombatSkillKey objectId, out CombatSkill element)
	{
		return _combatSkills.TryGetValue(objectId, out element);
	}

	private void AddElement_CombatSkills(CombatSkillKey objectId, CombatSkill instance)
	{
		instance.CollectionHelperData = HelperDataCombatSkills;
		instance.DataStatesOffset = _dataStatesCombatSkills.Create();
		_combatSkills.Add(objectId, instance);
	}

	private void RemoveElement_CombatSkills(CombatSkillKey objectId)
	{
		if (_combatSkills.TryGetValue(objectId, out var instance))
		{
			_dataStatesCombatSkills.Remove(instance.DataStatesOffset);
			_combatSkills.Remove(objectId);
		}
	}

	private void ClearCombatSkills()
	{
		_dataStatesCombatSkills.Clear();
		_combatSkills.Clear();
	}

	public int GetElementField_CombatSkills(CombatSkillKey objectId, ushort fieldId, RawDataPool dataPool, bool resetModified)
	{
		if (!_combatSkills.TryGetValue(objectId, out var instance))
		{
			AdaptableLog.TagWarning("GetElementField_CombatSkills", $"Failed to find element {objectId} with field {fieldId}");
			return -1;
		}
		if (resetModified)
		{
			_dataStatesCombatSkills.ResetModified(instance.DataStatesOffset, fieldId);
		}
		switch (fieldId)
		{
		case 0:
			return GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool);
		case 1:
			return GameData.Serializer.Serializer.Serialize(instance.GetReadingState(), dataPool);
		case 2:
			return GameData.Serializer.Serializer.Serialize(instance.GetActivationState(), dataPool);
		case 3:
			return GameData.Serializer.Serializer.Serialize(instance.GetForcedBreakoutStepsCount(), dataPool);
		case 4:
			return GameData.Serializer.Serializer.Serialize(instance.GetBreakoutStepsCount(), dataPool);
		case 5:
			return GameData.Serializer.Serializer.Serialize(instance.GetInnerRatio(), dataPool);
		case 6:
			return GameData.Serializer.Serializer.Serialize(instance.GetObtainedNeili(), dataPool);
		case 7:
			return GameData.Serializer.Serializer.Serialize(instance.GetRevoked(), dataPool);
		case 8:
			return GameData.Serializer.Serializer.Serialize(instance.GetSpecialEffectId(), dataPool);
		case 9:
			return GameData.Serializer.Serializer.Serialize(instance.GetPower(), dataPool);
		case 10:
			return GameData.Serializer.Serializer.Serialize(instance.GetMaxPower(), dataPool);
		case 11:
			return GameData.Serializer.Serializer.Serialize(instance.GetRequirementPercent(), dataPool);
		case 12:
			return GameData.Serializer.Serializer.Serialize(instance.GetDirection(), dataPool);
		case 13:
			return GameData.Serializer.Serializer.Serialize(instance.GetBaseScore(), dataPool);
		case 14:
			return GameData.Serializer.Serializer.Serialize(instance.GetCurrInnerRatio(), dataPool);
		case 15:
			return GameData.Serializer.Serializer.Serialize(instance.GetHitValue(), dataPool);
		case 16:
			return GameData.Serializer.Serializer.Serialize(instance.GetPenetrations(), dataPool);
		case 17:
			return GameData.Serializer.Serializer.Serialize(instance.GetCostBreathAndStancePercent(), dataPool);
		case 18:
			return GameData.Serializer.Serializer.Serialize(instance.GetCostBreathPercent(), dataPool);
		case 19:
			return GameData.Serializer.Serializer.Serialize(instance.GetCostStancePercent(), dataPool);
		case 20:
			return GameData.Serializer.Serializer.Serialize(instance.GetCostMobilityPercent(), dataPool);
		case 21:
			return GameData.Serializer.Serializer.Serialize(instance.GetAddHitValueOnCast(), dataPool);
		case 22:
			return GameData.Serializer.Serializer.Serialize(instance.GetAddPenetrateResist(), dataPool);
		case 23:
			return GameData.Serializer.Serializer.Serialize(instance.GetAddAvoidValueOnCast(), dataPool);
		case 24:
			return GameData.Serializer.Serializer.Serialize(instance.GetFightBackPower(), dataPool);
		case 25:
			return GameData.Serializer.Serializer.Serialize(instance.GetBouncePower(), dataPool);
		case 26:
			return GameData.Serializer.Serializer.Serialize(instance.GetRequirementsPower(), dataPool);
		case 27:
			return GameData.Serializer.Serializer.Serialize(instance.GetPlateAddMaxPower(), dataPool);
		default:
			if (fieldId >= 28)
			{
				throw new Exception($"Unsupported fieldId {fieldId}");
			}
			throw new Exception($"Not allow to get readonly field data: {fieldId}");
		}
	}

	public void SetElementField_CombatSkills(CombatSkillKey objectId, ushort fieldId, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (!_combatSkills.TryGetValue(objectId, out var instance))
		{
			throw new Exception($"Failed to find element {objectId} with field {fieldId}");
		}
		switch (fieldId)
		{
		case 0:
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		case 1:
		{
			ushort value3 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value3);
			instance.SetReadingState(value3, context);
			return;
		}
		case 2:
		{
			ushort value2 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value2);
			instance.SetActivationState(value2, context);
			return;
		}
		case 3:
		{
			sbyte value = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value);
			instance.SetForcedBreakoutStepsCount(value, context);
			return;
		}
		case 4:
		{
			sbyte value8 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value8);
			instance.SetBreakoutStepsCount(value8, context);
			return;
		}
		case 5:
		{
			sbyte value7 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value7);
			instance.SetInnerRatio(value7, context);
			return;
		}
		case 6:
		{
			short value6 = 0;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value6);
			instance.SetObtainedNeili(value6, context);
			return;
		}
		case 7:
		{
			bool value5 = false;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value5);
			instance.SetRevoked(value5, context);
			return;
		}
		case 8:
		{
			long value4 = 0L;
			GameData.Serializer.Serializer.Deserialize(dataPool, valueOffset, ref value4);
			instance.SetSpecialEffectId(value4, context);
			return;
		}
		}
		if (fieldId >= 28)
		{
			throw new Exception($"Unsupported fieldId {fieldId}");
		}
		if (fieldId >= 28)
		{
			throw new Exception($"Not allow to set readonly field data: {fieldId}");
		}
		throw new Exception($"Not allow to set cache field data: {fieldId}");
	}

	private int CheckModified_CombatSkills(CombatSkillKey objectId, ushort fieldId, RawDataPool dataPool)
	{
		if (!_combatSkills.TryGetValue(objectId, out var instance))
		{
			return -1;
		}
		if (fieldId >= 28)
		{
			throw new Exception($"Not allow to check readonly field data: {fieldId}");
		}
		if (!_dataStatesCombatSkills.IsModified(instance.DataStatesOffset, fieldId))
		{
			return -1;
		}
		_dataStatesCombatSkills.ResetModified(instance.DataStatesOffset, fieldId);
		return fieldId switch
		{
			0 => GameData.Serializer.Serializer.Serialize(instance.GetId(), dataPool), 
			1 => GameData.Serializer.Serializer.Serialize(instance.GetReadingState(), dataPool), 
			2 => GameData.Serializer.Serializer.Serialize(instance.GetActivationState(), dataPool), 
			3 => GameData.Serializer.Serializer.Serialize(instance.GetForcedBreakoutStepsCount(), dataPool), 
			4 => GameData.Serializer.Serializer.Serialize(instance.GetBreakoutStepsCount(), dataPool), 
			5 => GameData.Serializer.Serializer.Serialize(instance.GetInnerRatio(), dataPool), 
			6 => GameData.Serializer.Serializer.Serialize(instance.GetObtainedNeili(), dataPool), 
			7 => GameData.Serializer.Serializer.Serialize(instance.GetRevoked(), dataPool), 
			8 => GameData.Serializer.Serializer.Serialize(instance.GetSpecialEffectId(), dataPool), 
			9 => GameData.Serializer.Serializer.Serialize(instance.GetPower(), dataPool), 
			10 => GameData.Serializer.Serializer.Serialize(instance.GetMaxPower(), dataPool), 
			11 => GameData.Serializer.Serializer.Serialize(instance.GetRequirementPercent(), dataPool), 
			12 => GameData.Serializer.Serializer.Serialize(instance.GetDirection(), dataPool), 
			13 => GameData.Serializer.Serializer.Serialize(instance.GetBaseScore(), dataPool), 
			14 => GameData.Serializer.Serializer.Serialize(instance.GetCurrInnerRatio(), dataPool), 
			15 => GameData.Serializer.Serializer.Serialize(instance.GetHitValue(), dataPool), 
			16 => GameData.Serializer.Serializer.Serialize(instance.GetPenetrations(), dataPool), 
			17 => GameData.Serializer.Serializer.Serialize(instance.GetCostBreathAndStancePercent(), dataPool), 
			18 => GameData.Serializer.Serializer.Serialize(instance.GetCostBreathPercent(), dataPool), 
			19 => GameData.Serializer.Serializer.Serialize(instance.GetCostStancePercent(), dataPool), 
			20 => GameData.Serializer.Serializer.Serialize(instance.GetCostMobilityPercent(), dataPool), 
			21 => GameData.Serializer.Serializer.Serialize(instance.GetAddHitValueOnCast(), dataPool), 
			22 => GameData.Serializer.Serializer.Serialize(instance.GetAddPenetrateResist(), dataPool), 
			23 => GameData.Serializer.Serializer.Serialize(instance.GetAddAvoidValueOnCast(), dataPool), 
			24 => GameData.Serializer.Serializer.Serialize(instance.GetFightBackPower(), dataPool), 
			25 => GameData.Serializer.Serializer.Serialize(instance.GetBouncePower(), dataPool), 
			26 => GameData.Serializer.Serializer.Serialize(instance.GetRequirementsPower(), dataPool), 
			27 => GameData.Serializer.Serializer.Serialize(instance.GetPlateAddMaxPower(), dataPool), 
			_ => throw new Exception($"Unsupported fieldId {fieldId}"), 
		};
	}

	private void ResetModifiedWrapper_CombatSkills(CombatSkillKey objectId, ushort fieldId)
	{
		if (_combatSkills.TryGetValue(objectId, out var instance))
		{
			if (fieldId >= 28)
			{
				throw new Exception($"Not allow to reset modification state of readonly field data: {fieldId}");
			}
			if (_dataStatesCombatSkills.IsModified(instance.DataStatesOffset, fieldId))
			{
				_dataStatesCombatSkills.ResetModified(instance.DataStatesOffset, fieldId);
			}
		}
	}

	private bool IsModifiedWrapper_CombatSkills(CombatSkillKey objectId, ushort fieldId)
	{
		if (!_combatSkills.TryGetValue(objectId, out var instance))
		{
			return false;
		}
		if (fieldId >= 28)
		{
			throw new Exception($"Not allow to check modification state of readonly field data: {fieldId}");
		}
		return _dataStatesCombatSkills.IsModified(instance.DataStatesOffset, fieldId);
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
		archive.WriteSingleValueUnmanaged((ushort)1);
		archive.WriteDomainDataMeta(0);
		archive.WriteObjectCollectionCustomKey(_combatSkills);
	}

	public override void OnLoadWorld(ArchiveFileBase archive)
	{
		ushort savedFieldCount = 0;
		archive.ReadSingleValueUnmanaged(ref savedFieldCount);
		for (int domainDataIndex = 0; domainDataIndex < savedFieldCount; domainDataIndex++)
		{
			DomainDataMeta domainDataMeta = archive.ReadDomainDataMeta();
			if (domainDataMeta.DataId == 0)
			{
				archive.ReadObjectCollectionCustomKey(_combatSkills);
				RecordLoadedDomainData(domainDataMeta.DataId);
				continue;
			}
			throw new Exception($"Unsupported dataId {domainDataMeta.DataId}");
		}
		InitializeInternalDataOfCollections();
		OnLoadedArchiveData();
		DomainManager.Global.CompleteLoading(7);
	}

	public override int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified)
	{
		if (dataId == 0)
		{
			return GetElementField_CombatSkills((CombatSkillKey)subId0, (ushort)subId1, dataPool, resetModified);
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context)
	{
		if (dataId == 0)
		{
			SetElementField_CombatSkills((CombatSkillKey)subId0, (ushort)subId1, valueOffset, dataPool, context);
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context)
	{
		int argsOffset = operation.ArgsOffset;
		switch (operation.MethodId)
		{
		case 0:
		{
			int argsCount11 = operation.ArgsCount;
			int num11 = argsCount11;
			if (num11 == 2)
			{
				int charId11 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId11);
				List<short> skillTemplateIdList2 = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateIdList2);
				List<CombatSkillDisplayData> returnValue12 = GetCombatSkillDisplayData(charId11, skillTemplateIdList2);
				return GameData.Serializer.Serializer.Serialize(returnValue12, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 1:
		{
			int argsCount2 = operation.ArgsCount;
			int num2 = argsCount2;
			if (num2 == 2)
			{
				int charId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId2);
				short skillTemplateId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId);
				sbyte returnValue2 = GetCombatSkillBreakStepCount(charId2, skillTemplateId);
				return GameData.Serializer.Serializer.Serialize(returnValue2, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 2:
		{
			int argsCount14 = operation.ArgsCount;
			int num14 = argsCount14;
			if (num14 == 1)
			{
				int charId14 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId14);
				List<CombatSkillDisplayData> returnValue15 = GetCharacterEquipCombatSkillDisplayData(charId14);
				return GameData.Serializer.Serializer.Serialize(returnValue15, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 3:
		{
			int argsCount19 = operation.ArgsCount;
			int num19 = argsCount19;
			if (num19 == 2)
			{
				int charId17 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId17);
				short skillTemplateId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId7);
				CombatSkillDisplayData returnValue21 = GetCombatSkillDisplayDataOnce(charId17, skillTemplateId7);
				return GameData.Serializer.Serializer.Serialize(returnValue21, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 4:
		{
			int argsCount6 = operation.ArgsCount;
			int num6 = argsCount6;
			if (num6 == 2)
			{
				int charId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId6);
				List<short> skillIds = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillIds);
				List<CombatSkillEffectDescriptionDisplayData> returnValue6 = GetEffectDescriptionData(charId6, skillIds);
				return GameData.Serializer.Serializer.Serialize(returnValue6, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 5:
			if (operation.ArgsCount == 0)
			{
				(int, int) returnValue20 = CalcTaiwuExtraDeltaNeiliPerLoop(context);
				return GameData.Serializer.Serializer.Serialize(returnValue20, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 6:
			if (operation.ArgsCount == 0)
			{
				IntList returnValue8 = CalcTaiwuExtraDeltaNeiliAllocationPerLoop(context);
				return GameData.Serializer.Serializer.Serialize(returnValue8, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 7:
		{
			int argsCount22 = operation.ArgsCount;
			int num22 = argsCount22;
			if (num22 == 2)
			{
				int charId20 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId20);
				short skillTemplateId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId9);
				CombatSkillDisplayData returnValue24 = GetCombatSkillPreviewDisplayDataOnce(charId20, skillTemplateId9);
				return GameData.Serializer.Serializer.Serialize(returnValue24, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 8:
		{
			int argsCount16 = operation.ArgsCount;
			int num16 = argsCount16;
			if (num16 == 2)
			{
				int charId16 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId16);
				short skillTemplateId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId5);
				int returnValue17 = GetCombatSkillBreakoutStepsMaxPower(charId16, skillTemplateId5);
				return GameData.Serializer.Serializer.Serialize(returnValue17, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 9:
		{
			int argsCount10 = operation.ArgsCount;
			int num10 = argsCount10;
			if (num10 == 2)
			{
				int charId10 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId10);
				short skillTemplateId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId2);
				List<SkillBreakPlateBonus> returnValue11 = GetCombatSkillBreakBonuses(charId10, skillTemplateId2);
				return GameData.Serializer.Serializer.Serialize(returnValue11, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 10:
		{
			int argsCount3 = operation.ArgsCount;
			int num3 = argsCount3;
			if (num3 == 4)
			{
				int charId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId3);
				short skillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId);
				byte pageId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref pageId);
				sbyte direction = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref direction);
				bool returnValue3 = SetActivePage(context, charId3, skillId, pageId, direction);
				return GameData.Serializer.Serializer.Serialize(returnValue3, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 11:
		{
			int argsCount21 = operation.ArgsCount;
			int num21 = argsCount21;
			if (num21 == 4)
			{
				int charId19 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId19);
				short skillId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillId2);
				byte pageId2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref pageId2);
				sbyte direction2 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref direction2);
				bool returnValue23 = DeActivePage(context, charId19, skillId2, pageId2, direction2);
				return GameData.Serializer.Serializer.Serialize(returnValue23, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 12:
		{
			int argsCount17 = operation.ArgsCount;
			int num17 = argsCount17;
			if (num17 == 1)
			{
				short skillTemplateId6 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId6);
				CombatSkillBreakSuccessRateDisplayData returnValue18 = CalcTaiwuCombatSkillBreakSuccessRate(skillTemplateId6);
				return GameData.Serializer.Serializer.Serialize(returnValue18, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 13:
		{
			int argsCount13 = operation.ArgsCount;
			int num13 = argsCount13;
			if (num13 == 2)
			{
				int charId13 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId13);
				short skillTemplateId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId4);
				CombatSkillBreakAvailableStepsDisplayData returnValue14 = CalcCombatSkillBreakAvailableStepsDisplayData(charId13, skillTemplateId4);
				return GameData.Serializer.Serializer.Serialize(returnValue14, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 14:
		{
			int argsCount8 = operation.ArgsCount;
			int num8 = argsCount8;
			if (num8 == 1)
			{
				int charId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId8);
				EquipCombatSkillDisplayData returnValue9 = GetEquipCombatSkillDisplayData(context, charId8);
				return GameData.Serializer.Serializer.Serialize(returnValue9, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 15:
		{
			int argsCount5 = operation.ArgsCount;
			int num5 = argsCount5;
			if (num5 == 1)
			{
				int charId5 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId5);
				List<CombatSkillDisplayDataCharacterMenuListItem> returnValue5 = GetCharacterMenuCombatSkillListItemDisplayData(context, charId5);
				return GameData.Serializer.Serializer.Serialize(returnValue5, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 16:
			if (operation.ArgsCount == 0)
			{
				IntList returnValue25 = GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu(context);
				return GameData.Serializer.Serializer.Serialize(returnValue25, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		case 17:
		{
			int argsCount20 = operation.ArgsCount;
			int num20 = argsCount20;
			if (num20 == 2)
			{
				int charId18 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId18);
				short skillTemplateId8 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId8);
				CombatSkillPracticeDisplayData returnValue22 = GetCombatSkillDisplayDataForPractice(charId18, skillTemplateId8);
				return GameData.Serializer.Serializer.Serialize(returnValue22, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 18:
		{
			int argsCount18 = operation.ArgsCount;
			int num18 = argsCount18;
			if (num18 == 2)
			{
				int combatSkillId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref combatSkillId);
				int totalLoopsCount = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref totalLoopsCount);
				CombatSkillNeigongLoopInformation returnValue19 = CalcTaiwuExtraDeltaNeiliAllocationLoops(context, combatSkillId, totalLoopsCount);
				return GameData.Serializer.Serializer.Serialize(returnValue19, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 19:
		{
			int argsCount15 = operation.ArgsCount;
			int num15 = argsCount15;
			if (num15 == 2)
			{
				int charId15 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId15);
				sbyte skillType = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillType);
				List<short> returnValue16 = GetLearnedCombatSkillByType(context, charId15, skillType);
				return GameData.Serializer.Serializer.Serialize(returnValue16, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 20:
		{
			int argsCount12 = operation.ArgsCount;
			int num12 = argsCount12;
			if (num12 == 2)
			{
				int charId12 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId12);
				short skillTemplateId3 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateId3);
				CombatSkillDisplayDataForList returnValue13 = GetCombatSkillDisplayDataForListOnce(charId12, skillTemplateId3);
				return GameData.Serializer.Serializer.Serialize(returnValue13, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 21:
		{
			int argsCount9 = operation.ArgsCount;
			int num9 = argsCount9;
			if (num9 == 2)
			{
				int charId9 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId9);
				List<short> skillTemplateIdList = null;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref skillTemplateIdList);
				List<CombatSkillDisplayDataForList> returnValue10 = GetCombatSkillDisplayDataForList(charId9, skillTemplateIdList);
				return GameData.Serializer.Serializer.Serialize(returnValue10, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 22:
		{
			int argsCount7 = operation.ArgsCount;
			int num7 = argsCount7;
			if (num7 == 1)
			{
				int charId7 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId7);
				CombatSkillEquipment returnValue7 = GetCombatSkillEquipment(context, charId7);
				return GameData.Serializer.Serializer.Serialize(returnValue7, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 23:
		{
			int argsCount4 = operation.ArgsCount;
			int num4 = argsCount4;
			if (num4 == 1)
			{
				int charId4 = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId4);
				List<short> returnValue4 = GetCharacterEquipNeigongBreakList(context, charId4);
				return GameData.Serializer.Serializer.Serialize(returnValue4, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		case 24:
		{
			int argsCount = operation.ArgsCount;
			int num = argsCount;
			if (num == 1)
			{
				int charId = 0;
				argsOffset += GameData.Serializer.Serializer.Deserialize(argDataPool, argsOffset, ref charId);
				List<short> returnValue = GetCharacterEquipAssistanceBreakList(context, charId);
				return GameData.Serializer.Serializer.Serialize(returnValue, returnDataPool);
			}
			throw new Exception($"Unsupported argsCount of methodId: {operation.MethodId}");
		}
		default:
			throw new Exception($"Unsupported methodId {operation.MethodId}");
		}
	}

	public override void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring)
	{
		if (dataId == 0)
		{
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool)
	{
		if (dataId == 0)
		{
			return CheckModified_CombatSkills((CombatSkillKey)subId0, (ushort)subId1, dataPool);
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		if (dataId == 0)
		{
			ResetModifiedWrapper_CombatSkills((CombatSkillKey)subId0, (ushort)subId1);
			return;
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1)
	{
		if (dataId == 0)
		{
			return IsModifiedWrapper_CombatSkills((CombatSkillKey)subId0, (ushort)subId1);
		}
		throw new Exception($"Unsupported dataId {dataId}");
	}

	public override void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll)
	{
		if (influence.TargetIndicator.DataId == 0)
		{
			if (!unconditionallyInfluenceAll)
			{
				List<BaseGameDataObject> influencedObjects = InfluenceChecker.InfluencedObjectsPool.Get();
				if (!InfluenceChecker.GetScope(context, sourceObject, influence.Scope, _combatSkills, influencedObjects))
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
					BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCombatSkills, _dataStatesCombatSkills, influence, context);
				}
				influencedObjects.Clear();
				InfluenceChecker.InfluencedObjectsPool.Return(influencedObjects);
			}
			else
			{
				BaseGameDataDomain.InvalidateAllAndInfluencedCaches(CacheInfluencesCombatSkills, _dataStatesCombatSkills, influence, context);
			}
			return;
		}
		throw new Exception($"Unsupported dataId {influence.TargetIndicator.DataId}");
	}

	private void InitializeInternalDataOfCollections()
	{
		foreach (KeyValuePair<CombatSkillKey, CombatSkill> combatSkill in _combatSkills)
		{
			CombatSkill instance = combatSkill.Value;
			instance.CollectionHelperData = HelperDataCombatSkills;
			instance.DataStatesOffset = _dataStatesCombatSkills.Create();
		}
	}
}

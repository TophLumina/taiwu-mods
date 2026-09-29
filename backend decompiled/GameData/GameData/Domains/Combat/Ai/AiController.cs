using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat.Ai.Memory;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.GameDataBridge;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai;

public class AiController
{
	private readonly CombatCharacter _combatCharacter;

	public readonly AiEnvironment Environment;

	public readonly AiMemory Memory;

	public bool AllowDefense;

	public static readonly int[] AddHazardPerMark = new int[4] { 150, 75, 50, 150 };

	public static readonly int[] SpecialMarkAddHazardNeedCount = new int[4] { 0, 2, 4, 0 };

	private int _maxHazardValue;

	private int _addHazardPerMark;

	private int _specialMarkAddHazardNeedCount;

	private DefeatMarkCollection _lastMarks;

	private DataUid _defeatMarkUid;

	private string _defeatMarkDataHandlerKey;

	private const sbyte SkillMaxZeroScoreCount = 1;

	private const sbyte WeaponMaxZeroScoreCount = 2;

	private readonly Dictionary<short, int> _skillScoreDict = new Dictionary<short, int>();

	private readonly Dictionary<int, int> _weaponScoreDict = new Dictionary<int, int>();

	private readonly AiTree _aiTree;

	public bool IsCombatDifficultyLevel1 => _combatCharacter.IsAlly || DomainManager.World.GetCombatDifficulty() >= 1;

	public bool IsCombatDifficultyLevel2 => _combatCharacter.IsAlly || DomainManager.World.GetCombatDifficulty() >= 2;

	public AiController(CombatCharacter combatCharacter)
	{
		_combatCharacter = combatCharacter;
		Environment = new AiEnvironment(combatCharacter);
		Memory = new AiMemory(combatCharacter);
		AllowDefense = true;
		_aiTree = new AiTree(combatCharacter, new AiDataFile(ProperAiData()));
	}

	private AiDataItem ProperAiData()
	{
		if (_combatCharacter.IsTaiwu)
		{
			return Config.AiData.Instance[0];
		}
		CombatConfigItem combatConfig = DomainManager.Combat.CombatConfig;
		if (combatConfig.EnemyAi >= 0 && !_combatCharacter.IsAlly)
		{
			return Config.AiData.Instance[combatConfig.EnemyAi];
		}
		CharacterItem characterConfig = _combatCharacter.GetCharacter().Template;
		return Config.AiData.Instance[characterConfig.CombatAi];
	}

	public void Init()
	{
		InitHazard();
		Environment.RegisterCallbacks();
		Memory.RegisterCallbacks();
		if (!IsCombatDifficultyLevel2)
		{
			return;
		}
		List<short> selfLearnedSkills = _combatCharacter.GetCharacter().GetLearnedCombatSkills();
		int[] characterList = DomainManager.Combat.GetCharacterList(!_combatCharacter.IsAlly);
		foreach (int enemyId in characterList)
		{
			if (enemyId < 0)
			{
				continue;
			}
			List<short> attackSkillList = DomainManager.Combat.GetElement_CombatCharacterDict(enemyId).GetAttackSkillList();
			foreach (short skillId in attackSkillList)
			{
				if (selfLearnedSkills.Contains(skillId))
				{
					Memory.EnemyRecordDict[enemyId].SkillRecord.Add(skillId, (400, 0));
				}
			}
		}
	}

	public void UnInit()
	{
		UnInitHazard();
		Environment.UnregisterCallbacks();
		Memory.UnregisterCallbacks();
	}

	public void ClearMemories()
	{
		Memory.ClearMemories();
		_aiTree.ClearMemories();
	}

	private void InitHazard()
	{
		_maxHazardValue = Math.Min(750 + 750 * _combatCharacter.GetPersonalityValue(4) / 100, 1500);
		_addHazardPerMark = AddHazardPerMark[DomainManager.Combat.CombatConfig.CombatType];
		_specialMarkAddHazardNeedCount = SpecialMarkAddHazardNeedCount[DomainManager.Combat.CombatConfig.CombatType];
		_lastMarks = new DefeatMarkCollection();
		_lastMarks.Clear();
		_defeatMarkUid = new DataUid(8, 10, (ulong)_combatCharacter.GetId(), 50u);
		_defeatMarkDataHandlerKey = $"CombatAiHazard{_combatCharacter.GetId()}";
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, _defeatMarkDataHandlerKey, OnDefeatMarkChanged);
		OnDefeatMarkChanged(_combatCharacter.GetDataContext(), _defeatMarkUid);
	}

	private void UnInitHazard()
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, _defeatMarkDataHandlerKey);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		DefeatMarkCollection markCollection = _combatCharacter.GetDefeatMarkCollection();
		int totalFlaw = 0;
		int totalAddFlaw = 0;
		int totalAcupoint = 0;
		int totalAddAcupoint = 0;
		int addHazard = 0;
		for (sbyte part = 0; part < 7; part++)
		{
			byte outerInjury = markCollection.OuterInjuryMarkList[part];
			byte innerInjury = markCollection.InnerInjuryMarkList[part];
			ByteList flawList = markCollection.FlawMarkList[part];
			ByteList acupointList = markCollection.AcupointMarkList[part];
			if (outerInjury > _lastMarks.OuterInjuryMarkList[part])
			{
				addHazard += _addHazardPerMark * (outerInjury - _lastMarks.OuterInjuryMarkList[part]);
			}
			if (innerInjury > _lastMarks.InnerInjuryMarkList[part])
			{
				addHazard += _addHazardPerMark * (innerInjury - _lastMarks.InnerInjuryMarkList[part]);
			}
			totalFlaw += flawList.Count;
			if (flawList.Count > _lastMarks.FlawMarkList[part].Count)
			{
				totalAddFlaw += flawList.Count - _lastMarks.FlawMarkList[part].Count;
			}
			totalAcupoint += acupointList.Count;
			if (acupointList.Count > _lastMarks.AcupointMarkList[part].Count)
			{
				totalAddAcupoint += acupointList.Count - _lastMarks.AcupointMarkList[part].Count;
			}
			int maxAddCount = Math.Max(acupointList.Count - _specialMarkAddHazardNeedCount, 0);
			addHazard += _addHazardPerMark * Math.Min(acupointList.Count - _lastMarks.AcupointMarkList[part].Count, maxAddCount);
			_lastMarks.OuterInjuryMarkList[part] = outerInjury;
			_lastMarks.InnerInjuryMarkList[part] = innerInjury;
			_lastMarks.FlawMarkList[part].Clear();
			_lastMarks.FlawMarkList[part].AddRange(flawList);
			_lastMarks.AcupointMarkList[part].Clear();
			_lastMarks.AcupointMarkList[part].AddRange(acupointList);
		}
		if (totalAddFlaw > 0)
		{
			int maxAddCount2 = Math.Max(totalFlaw - _specialMarkAddHazardNeedCount, 0);
			addHazard += _addHazardPerMark * Math.Min(totalAddFlaw, maxAddCount2);
		}
		if (totalAddAcupoint > 0)
		{
			int maxAddCount3 = Math.Max(totalAcupoint - _specialMarkAddHazardNeedCount, 0);
			addHazard += _addHazardPerMark * Math.Min(totalAddAcupoint, maxAddCount3);
		}
		for (sbyte type = 0; type < 6; type++)
		{
			byte poison = markCollection.PoisonMarkList[type];
			if (poison > _lastMarks.PoisonMarkList[type])
			{
				addHazard += _addHazardPerMark * (poison - _lastMarks.PoisonMarkList[type]);
			}
			_lastMarks.PoisonMarkList[type] = poison;
		}
		if (markCollection.MindMarkList.Count > _lastMarks.MindMarkList.Count)
		{
			int maxAddCount4 = Math.Max(markCollection.MindMarkList.Count - _specialMarkAddHazardNeedCount, 0);
			addHazard += _addHazardPerMark * Math.Min(markCollection.MindMarkList.Count - _lastMarks.MindMarkList.Count, maxAddCount4);
		}
		_lastMarks.MindMarkList.Clear();
		_lastMarks.MindMarkList.AddRange(markCollection.MindMarkList);
		if (markCollection.DieMarkList.Count > _lastMarks.DieMarkList.Count)
		{
			addHazard += _addHazardPerMark * (markCollection.DieMarkList.Count - _lastMarks.DieMarkList.Count);
		}
		_lastMarks.DieMarkList.Clear();
		_lastMarks.DieMarkList.AddRange(markCollection.DieMarkList);
		if (markCollection.FatalDamageMarkCount > _lastMarks.FatalDamageMarkCount)
		{
			addHazard += _addHazardPerMark * (markCollection.FatalDamageMarkCount - _lastMarks.FatalDamageMarkCount);
		}
		_lastMarks.FatalDamageMarkCount = markCollection.FatalDamageMarkCount;
		ChangeHazardValue(context, addHazard);
	}

	public void ChangeHazardValue(DataContext context, int hazardValue)
	{
		int newValue = Math.Clamp(_combatCharacter.GetHazardValue() + hazardValue, 0, _maxHazardValue);
		_combatCharacter.SetHazardValue(newValue, context);
	}

	public CValuePercent GetHazardPercent()
	{
		return CValuePercent.Parse(_combatCharacter.GetHazardValue(), _maxHazardValue);
	}

	public bool IsHazard()
	{
		DefeatMarkCollection markCollection = _combatCharacter.GetDefeatMarkCollection();
		return _combatCharacter.GetHazardValue() >= _maxHazardValue || markCollection.FatalDamageMarkCount >= 3 || markCollection.DieMarkList.Count >= 3;
	}

	public bool CanFlee()
	{
		return DomainManager.Combat.CanFlee(_combatCharacter.IsAlly);
	}

	public short GetBestCombatSkill(IRandomSource random, sbyte equipType, bool requireCanUse = false, int costMaxFrame = -1, int costMaxBreath = -1, int costMaxStance = -1, short exceptSkill = -1)
	{
		List<short> skillIdList = ObjectPool<List<short>>.Instance.Get();
		short bestSkillId = -1;
		skillIdList.Clear();
		skillIdList.AddRange(_combatCharacter.GetCombatSkillList(equipType));
		skillIdList.RemoveAll((short id) => id < 0);
		skillIdList.Remove(exceptSkill);
		if (skillIdList.Count > 0)
		{
			_skillScoreDict.Clear();
			foreach (short skillId in skillIdList)
			{
				if (1 == 0)
				{
				}
				int num = equipType switch
				{
					1 => CalcAttackSkillScore(random, skillId, requireCanUse, costMaxFrame, costMaxBreath, costMaxStance), 
					3 => CalcDefenseSkillScore(skillId, requireCanUse, costMaxFrame, costMaxBreath, costMaxStance), 
					_ => 0, 
				};
				if (1 == 0)
				{
				}
				int score = num;
				_skillScoreDict.Add(skillId, score);
			}
			int currHazard = _combatCharacter.GetHazardValue();
			if (!IsHazard() && currHazard < _maxHazardValue / 2 && skillIdList.Count > 1)
			{
				int leftSkillCount = (skillIdList.Count - 1) * currHazard / (_maxHazardValue / 2) + 1;
				CollectionUtils.Shuffle(DomainManager.Combat.Context.Random, skillIdList);
				skillIdList.Sort((short skillL, short skillR) => _skillScoreDict[skillR] - _skillScoreDict[skillL]);
				while (skillIdList.Count > leftSkillCount)
				{
					skillIdList.RemoveAt(0);
				}
			}
			int maxScore = 0;
			for (int i = 0; i < skillIdList.Count; i++)
			{
				maxScore = Math.Max(maxScore, _skillScoreDict[skillIdList[i]]);
			}
			foreach (short skillId2 in _skillScoreDict.Keys)
			{
				if (_skillScoreDict[skillId2] != maxScore)
				{
					skillIdList.Remove(skillId2);
				}
			}
			if (skillIdList.Count > 0)
			{
				bestSkillId = skillIdList.GetRandom(random);
			}
		}
		ObjectPool<List<short>>.Instance.Return(skillIdList);
		return bestSkillId;
	}

	public int GetBestWeaponIndex(IRandomSource random, short skillId = -1, bool needInRange = false, int exceptIndex = -1)
	{
		bool hasUsableNormalWeapon = false;
		_weaponScoreDict.Clear();
		for (int i = 0; i < 7; i++)
		{
			if (i != exceptIndex && _combatCharacter.GetWeapons()[i].IsValid() && (i >= 3 || _combatCharacter.GetWeaponData(i).GetDurability() > 0))
			{
				if (i >= 3 && (hasUsableNormalWeapon || !Config.Character.Instance[_combatCharacter.GetCharacter().GetTemplateId()].AllowUseFreeWeapon))
				{
					break;
				}
				if (i < 3)
				{
					hasUsableNormalWeapon = true;
				}
				int score = CalcWeaponScore(i, skillId, needInRange);
				if (score >= 0)
				{
					_weaponScoreDict.Add(i, score);
				}
			}
		}
		if (_weaponScoreDict.Count == 0)
		{
			return -1;
		}
		int maxScore = 0;
		List<int> maxScoreIndexList = ObjectPool<List<int>>.Instance.Get();
		maxScoreIndexList.Clear();
		foreach (int score2 in _weaponScoreDict.Values)
		{
			maxScore = Math.Max(maxScore, score2);
		}
		foreach (int index in _weaponScoreDict.Keys)
		{
			if (_weaponScoreDict[index] == maxScore)
			{
				maxScoreIndexList.Add(index);
			}
		}
		int bestIndex = maxScoreIndexList.GetRandom(random);
		ObjectPool<List<int>>.Instance.Return(maxScoreIndexList);
		return bestIndex;
	}

	public unsafe int CalcAttackSkillScore(IRandomSource random, short skillId, bool requireCanUse = false, int costMaxFrame = -1, int costMaxBreath = -1, int costMaxStance = -1)
	{
		int charId = _combatCharacter.GetId();
		GameData.Domains.CombatSkill.CombatSkill skillObj = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId));
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		GameData.Domains.Character.Character character = _combatCharacter.GetCharacter();
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		Personalities personalities = character.GetPersonalities();
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!_combatCharacter.IsAlly);
		if (requireCanUse && !DomainManager.Combat.GetCombatSkillData(charId, skillId).GetCanUse())
		{
			return -1;
		}
		if (costMaxFrame >= 0 && DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId)).GetPrepareTotalProgress() / DomainManager.Combat.GetSkillPrepareSpeed(_combatCharacter) > costMaxFrame)
		{
			return -1;
		}
		if (skillId >= 0 && DomainManager.Combat.CombatSkillDataExist(new CombatSkillKey(charId, skillId)) && DomainManager.Combat.GetCombatSkillData(charId, skillId).GetLeftCdFrame() != 0)
		{
			return -1;
		}
		if (costMaxBreath >= 0 || costMaxStance >= 0)
		{
			OuterAndInnerInts costBreathStance = DomainManager.Combat.GetSkillCostBreathStance(charId, skillObj);
			if (costBreathStance.Outer > costMaxStance || costBreathStance.Inner > costMaxBreath)
			{
				return -1;
			}
		}
		if (Memory.SelfRecord.SkillRecord.ContainsKey(skillId) && Memory.SelfRecord.SkillRecord[skillId].zeroScoreCount > 1)
		{
			return 0;
		}
		int score = Equipping.CalcCombatSkillScore(skillObj, skillConfig.EquipType, ref personalities, character.GetNeiliType(), orgInfo.OrgTemplateId, character.GetIdealSect(), DomainManager.LegendaryBook.GetCharOwnedBookTypes(character.GetId()));
		sbyte skillInnerRatio = skillObj.GetInnerRatio();
		OuterAndInnerInts enemyPenetrationResists = enemyChar.GetCharacter().GetPenetrationResists();
		int enemyDefendDiff = enemyPenetrationResists.Outer - enemyPenetrationResists.Inner;
		if ((enemyDefendDiff > 0) ? (skillInnerRatio >= 50) : ((enemyDefendDiff < 0) ? (skillInnerRatio <= 50) : (skillInnerRatio == 50)))
		{
			score += 150 * Math.Max(skillInnerRatio, 100 - skillInnerRatio) / 100;
		}
		HitOrAvoidInts charHit = character.GetHitValues();
		HitOrAvoidInts skillHit = skillObj.GetHitValue();
		HitOrAvoidInts hitDistribution = skillObj.GetHitDistribution();
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			if (hitDistribution.Items[hitType] > 0 && charHit.Items[hitType] * skillHit.Items[hitType] / 100 >= Memory.EnemyRecordDict[enemyChar.GetId()].MaxAvoid.Items[hitType])
			{
				score += hitDistribution.Items[hitType] * 2;
			}
		}
		if (skillConfig.HasAtkAcupointEffect)
		{
			score += 100;
		}
		if (orgInfo.OrgTemplateId >= 0 && Config.Organization.Instance[orgInfo.OrgTemplateId].AllowPoisoning)
		{
			PoisonsAndLevels poisons = skillConfig.Poisons;
			int poisonScore = 0;
			for (int poisonType = 0; poisonType < 6; poisonType++)
			{
				poisonScore = Math.Max(poisonScore, poisons.Values[poisonType] * poisons.Levels[poisonType]);
			}
			score += poisonScore;
		}
		int bestWeaponIndex = GetBestWeaponIndex(random, skillId);
		int rangeWeaponIndex = ((DomainManager.CombatSkill.GetSkillType(_combatCharacter.GetId(), skillId) != 5) ? bestWeaponIndex : 3);
		if (rangeWeaponIndex >= 0)
		{
			GameData.Domains.Item.Weapon rangeWeapon = DomainManager.Item.GetElement_Weapons(_combatCharacter.GetWeapons()[rangeWeaponIndex].Id);
			int minIndex = RecordCollection.GetIndexByDistance((short)(rangeWeapon.GetMinDistance() - skillConfig.DistanceAdditionWhenCast));
			int maxIndex = RecordCollection.GetIndexByDistance((short)(rangeWeapon.GetMaxDistance() - skillConfig.DistanceAdditionWhenCast));
			int totalDamage = 0;
			int damageInRange = 0;
			for (int i = 0; i < Memory.SelfRecord.MaxDamages.Length; i++)
			{
				OuterAndInnerInts damage = Memory.SelfRecord.MaxDamages[i];
				totalDamage += damage.Outer + damage.Inner;
				if (minIndex <= i && i <= maxIndex)
				{
					damageInRange += damage.Outer + damage.Inner + Memory.SelfRecord.MaxMindDamages[i];
				}
			}
			if (damageInRange > 0 && totalDamage > 0)
			{
				sbyte braveValue = _combatCharacter.GetPersonalityValue(3);
				int reduceScore = 200 - 200 * braveValue / 100 * damageInRange * 100 / totalDamage;
				score = Math.Max(score - reduceScore, 0);
			}
		}
		score = ((!Memory.SelfRecord.SkillRecord.ContainsKey(skillId)) ? (score + Memory.SelfRecord.GetSkillRecordMaxScore()) : (score + Memory.SelfRecord.SkillRecord[skillId].score));
		if (bestWeaponIndex < 0)
		{
			score = -1;
		}
		else if (bestWeaponIndex >= 3)
		{
			score = score * 66 / 100;
		}
		return score;
	}

	public unsafe int CalcDefenseSkillScore(short skillId, bool requireCanUse = false, int costMaxFrame = -1, int costMaxBreath = -1, int costMaxStance = -1)
	{
		int charId = _combatCharacter.GetId();
		GameData.Domains.CombatSkill.CombatSkill skillObj = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId));
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!_combatCharacter.IsAlly);
		if (requireCanUse && !DomainManager.Combat.GetCombatSkillData(charId, skillId).GetCanUse())
		{
			return -1;
		}
		if (costMaxFrame >= 0 && DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(charId, skillId)).GetPrepareTotalProgress() / DomainManager.Combat.GetSkillPrepareSpeed(_combatCharacter) > costMaxFrame)
		{
			return -1;
		}
		if (costMaxBreath >= 0 || costMaxStance >= 0)
		{
			OuterAndInnerInts costBreathStance = DomainManager.Combat.GetSkillCostBreathStance(charId, skillObj);
			if (costBreathStance.Outer > costMaxStance || costBreathStance.Inner > costMaxBreath)
			{
				return -1;
			}
		}
		sbyte enemyInnerRatio;
		HitOrAvoidInts enemyHits = default(HitOrAvoidInts);
		if (enemyChar.GetPreparingSkillId() >= 0)
		{
			CombatSkillKey enemySkillKey = new CombatSkillKey(enemyChar.GetId(), enemyChar.GetPreparingSkillId());
			GameData.Domains.CombatSkill.CombatSkill enemySkill = DomainManager.CombatSkill.GetElement_CombatSkills(enemySkillKey);
			enemyInnerRatio = enemySkill.GetCurrInnerRatio();
			enemyHits = enemySkill.GetHitValue();
		}
		else
		{
			CombatWeaponData enemyWeapon = enemyChar.GetWeaponData();
			HitOrAvoidShorts weaponHits = enemyWeapon.Item.GetHitFactors();
			enemyInnerRatio = enemyWeapon.GetInnerRatio();
			for (int hitType = 0; hitType < 4; hitType++)
			{
				enemyHits.Items[hitType] = weaponHits.Items[hitType];
			}
		}
		int score = 0;
		score += skillConfig.AddOuterPenetrateResistOnCast * (100 - enemyInnerRatio) / 300;
		score += skillConfig.AddInnerPenetrateResistOnCast * enemyInnerRatio / 300;
		if ((skillObj.GetBouncePower().Inner > 0 || skillObj.GetBouncePower().Outer > 0) && DomainManager.Combat.GetCurrentDistance() < skillConfig.BounceDistance)
		{
			score += skillConfig.BounceRateOfOuterInjury * (100 - enemyInnerRatio) / 150;
			score += skillConfig.BounceRateOfInnerInjury * enemyInnerRatio / 150;
		}
		if (skillObj.GetFightBackPower() > 0 && DomainManager.Combat.InAttackRange(_combatCharacter))
		{
			score += skillObj.GetFightBackPower() / 2;
		}
		HitOrAvoidInts addAvoid = skillObj.GetAddAvoidValueOnCast();
		for (int i = 0; i < 4; i++)
		{
			score += addAvoid.Items[i] * enemyHits.Items[i] / 200;
		}
		if (score > 0)
		{
			GameData.Domains.Character.Character character = _combatCharacter.GetCharacter();
			Personalities personalities = character.GetPersonalities();
			score += Equipping.CalcCombatSkillScore(skillObj, skillConfig.EquipType, ref personalities, _combatCharacter.GetNeiliType(), character.GetOrganizationInfo().OrgTemplateId, character.GetIdealSect(), DomainManager.LegendaryBook.GetCharOwnedBookTypes(_combatCharacter.GetId()));
		}
		return score;
	}

	private unsafe int CalcWeaponScore(int weaponIndex, short skillId = -1, bool needInRange = false)
	{
		CombatWeaponData combatWeaponData = _combatCharacter.GetWeaponData(weaponIndex);
		if (skillId >= 0 && !DomainManager.Combat.WeaponHasNeedTrick(_combatCharacter, skillId, combatWeaponData))
		{
			return -1;
		}
		ItemKey weaponKey = _combatCharacter.GetWeapons()[weaponIndex];
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(weaponKey.Id);
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponKey.TemplateId];
		int innerRatioAdjustRange = weaponConfig.InnerRatioAdjustRange * _combatCharacter.GetCharacter().GetInnerRatio() / 100;
		bool isFreeWeapon = weaponKey.TemplateId == 0 || weaponKey.TemplateId == 1 || weaponKey.TemplateId == 2;
		if ((!isFreeWeapon && combatWeaponData.GetDurability() <= 0) || (needInRange && !InWeaponAttackRange(weaponKey)))
		{
			return -1;
		}
		if (Memory.SelfRecord.WeaponRecord.ContainsKey(weaponKey.Id) && Memory.SelfRecord.WeaponRecord[weaponKey.Id].zeroScoreCount > 2)
		{
			return 0;
		}
		HitOrAvoidShorts weaponHits = weapon.GetHitFactors(_combatCharacter.GetId());
		int score = Config.Weapon.Instance[weaponKey.TemplateId].Grade * 10 * DomainManager.Character.GetItemPower(_combatCharacter.GetId(), weaponKey) / 100;
		if (!isFreeWeapon)
		{
			score += 50;
		}
		if (Memory.SelfRecord.WeaponRecord.ContainsKey(weaponKey.Id))
		{
			score += Memory.SelfRecord.WeaponRecord[weaponKey.Id].score;
		}
		if (skillId >= 0)
		{
			GameData.Domains.CombatSkill.CombatSkill skillObj = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(_combatCharacter.GetId(), skillId));
			CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
			sbyte[] weaponTricks = combatWeaponData.GetWeaponTricks();
			int trickScore = 0;
			for (int i = 0; i < skillConfig.TrickCost.Count; i++)
			{
				NeedTrick needTrick = skillConfig.TrickCost[i];
				int hasCount = weaponTricks.CountAll((sbyte b) => b == needTrick.TrickType);
				if (Math.Min(needTrick.NeedCount, (byte)2) > hasCount)
				{
					trickScore = 0;
					break;
				}
				trickScore += hasCount * 100;
			}
			score += trickScore;
			HitOrAvoidInts hitDistribution = skillObj.GetHitDistribution();
			for (sbyte type = 0; type < 4; type++)
			{
				int skillHit = hitDistribution.Items[type];
				short weaponHit = weaponHits.Items[type];
				if (skillHit > 0 && weaponHit != 0)
				{
					score += weaponHit * skillHit * 2 / 100;
				}
			}
			score = Math.Max(score, 0);
			sbyte skillInnerRatio = skillObj.GetCurrInnerRatio();
			int minInnerRatio = weaponConfig.DefaultInnerRatio - innerRatioAdjustRange;
			int maxInnerRatio = weaponConfig.DefaultInnerRatio + innerRatioAdjustRange;
			int innerRatioDiff = ((skillInnerRatio > maxInnerRatio) ? (skillInnerRatio - maxInnerRatio) : ((skillInnerRatio < minInnerRatio) ? (minInnerRatio - skillInnerRatio) : 0));
			score += 50 - Math.Abs(innerRatioDiff / 2);
			if (skillConfig.MostFittingWeaponID >= 0)
			{
				int idDiff = weaponKey.TemplateId - skillConfig.MostFittingWeaponID;
				if (0 <= idDiff && idDiff <= 8)
				{
					score += 200;
				}
			}
		}
		else
		{
			int hitAddScore = 200;
			HitOrAvoidInts charHits = _combatCharacter.GetCharacter().GetHitValues();
			List<sbyte> hitTypeList = ObjectPool<List<sbyte>>.Instance.Get();
			Dictionary<int, int> hitValueDict = ObjectPool<Dictionary<int, int>>.Instance.Get();
			hitTypeList.Clear();
			hitValueDict.Clear();
			for (sbyte type2 = 0; type2 < 4; type2++)
			{
				hitTypeList.Add(type2);
				hitValueDict.Add(type2, charHits.Items[type2]);
			}
			hitTypeList.Sort((sbyte typeL, sbyte typeR) => hitValueDict[typeR] - hitValueDict[typeL]);
			for (int i2 = 0; i2 < hitTypeList.Count; i2++)
			{
				if (weaponHits.Items[hitTypeList[i2]] > 0)
				{
					score += hitAddScore;
				}
				hitAddScore -= 50;
			}
			ObjectPool<List<sbyte>>.Instance.Return(hitTypeList);
			ObjectPool<Dictionary<int, int>>.Instance.Return(hitValueDict);
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!_combatCharacter.IsAlly);
			OuterAndInnerInts enemyPenetrationResists = Memory.EnemyRecordDict[enemyChar.GetId()].MaxPenetrateResist;
			int maxInnerRatio2 = Math.Clamp(weaponConfig.DefaultInnerRatio + innerRatioAdjustRange, 0, 100);
			int minInnerRatio2 = Math.Clamp(weaponConfig.DefaultInnerRatio - innerRatioAdjustRange, 0, 100);
			if (enemyPenetrationResists.Outer > enemyPenetrationResists.Inner)
			{
				score += (100 - minInnerRatio2) * 3;
			}
			if (enemyPenetrationResists.Inner > enemyPenetrationResists.Outer)
			{
				score += maxInnerRatio2 * 3;
			}
			else if (minInnerRatio2 <= 50 && maxInnerRatio2 >= 50)
			{
				score += 300;
			}
			int minIndex = RecordCollection.GetIndexByDistance(weapon.GetMinDistance());
			int maxIndex = RecordCollection.GetIndexByDistance(weapon.GetMaxDistance());
			int baseScore = 200;
			int totalDamage = 0;
			int damageInRange = 0;
			for (int i3 = 0; i3 < Memory.SelfRecord.MaxDamages.Length; i3++)
			{
				OuterAndInnerInts damage = Memory.SelfRecord.MaxDamages[i3];
				totalDamage += damage.Outer + damage.Inner;
				if (minIndex <= i3 && i3 <= maxIndex)
				{
					damageInRange += damage.Outer + damage.Inner + Memory.SelfRecord.MaxMindDamages[i3];
				}
			}
			if (damageInRange > 0 && totalDamage > 0)
			{
				sbyte braveValue = _combatCharacter.GetPersonalityValue(3);
				int reduceScore = baseScore - baseScore * braveValue / 100 * damageInRange * 100 / totalDamage;
				score = Math.Max(score - reduceScore, 0);
			}
		}
		return score;
	}

	public bool InWeaponAttackRange(ItemKey weaponKey)
	{
		(int, int) attackRange = DomainManager.Item.GetWeaponAttackRange(_combatCharacter.GetId(), weaponKey);
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		return attackRange.Item1 <= currDistance && currDistance <= attackRange.Item2;
	}

	public short GetTargetDistance()
	{
		return _combatCharacter.AiTargetDistance;
	}

	public void Update(DataContext context)
	{
		if (!AutoStopJumpInReach())
		{
			_aiTree.Update();
			UpdateTargetDistance(context);
		}
	}

	public void UpdateOnlyMove(DataContext context)
	{
		UpdateTargetDistance(context);
		AutoStopJumpInReach();
	}

	public bool AutoStopJumpInReach()
	{
		if (!_combatCharacter.KeepMoving || !_combatCharacter.MoveData.PreparingJumpMove() || _combatCharacter.PlayerControllingMove)
		{
			return false;
		}
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		short targetDistance = _combatCharacter.GetTargetDistance();
		if (targetDistance < 0 || (_combatCharacter.MoveForward ? (currDistance <= targetDistance) : (currDistance >= targetDistance)) || !MoveCanApproachTargetDistance(targetDistance))
		{
			DomainManager.Combat.SetMoveState(MoveState.Stay, _combatCharacter.IsAlly);
		}
		else if (_combatCharacter.MoveData.CanPartlyJump)
		{
			short preparedDistance = _combatCharacter.GetJumpPreparedDistance();
			if (preparedDistance > 0 && (_combatCharacter.MoveForward ? (currDistance - preparedDistance <= targetDistance) : (currDistance + preparedDistance >= targetDistance)))
			{
				DomainManager.Combat.SetMoveState(MoveState.Stay, _combatCharacter.IsAlly);
			}
		}
		return true;
	}

	public void UpdateTargetDistance(DataContext context)
	{
		if (!_combatCharacter.PlayerControllingMove)
		{
			if (!_combatCharacter.IsAlly || DomainManager.Combat.IsAiMoving)
			{
				_combatCharacter.SetTargetDistance(context, GetTargetDistance());
			}
			else
			{
				_combatCharacter.SetTargetDistance(context, _combatCharacter.PlayerTargetDistance);
			}
			short targetDistance = _combatCharacter.GetTargetDistance();
			short currDistance = DomainManager.Combat.GetCurrentDistance();
			MoveState moveState = ((targetDistance >= 0 && targetDistance != currDistance && MoveCanApproachTargetDistance(targetDistance)) ? ((targetDistance < currDistance) ? MoveState.Forward : MoveState.Backward) : MoveState.Stay);
			MoveState currMoveState = (_combatCharacter.KeepMoving ? (_combatCharacter.MoveForward ? MoveState.Forward : MoveState.Backward) : MoveState.Stay);
			if (moveState != currMoveState)
			{
				DomainManager.Combat.SetMoveState(moveState, _combatCharacter.IsAlly);
			}
		}
	}

	private bool MoveCanApproachTargetDistance(short targetDistance)
	{
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		bool moveForward = targetDistance < currDistance;
		if (!_combatCharacter.MoveData.IsJumpMove(moveForward))
		{
			return true;
		}
		if (_combatCharacter.IsAlly)
		{
			return Math.Abs(currDistance - targetDistance) >= DomainManager.Extra.GetJumpThreshold(_combatCharacter.MoveData.JumpMoveSkillId);
		}
		int jumpDistance = (_combatCharacter.MoveData.CanPartlyJump ? 10 : (moveForward ? _combatCharacter.MoveData.MaxJumpForwardDist : _combatCharacter.MoveData.MaxJumpBackwardDist));
		return Math.Abs(currDistance - jumpDistance * (moveForward ? 1 : (-1)) - targetDistance) < Math.Abs(currDistance - targetDistance);
	}
}

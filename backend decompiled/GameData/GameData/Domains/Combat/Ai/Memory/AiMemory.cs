using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Memory;

public class AiMemory
{
	private readonly CombatCharacter _combatCharacter;

	public readonly RecordCollection SelfRecord = new RecordCollection();

	public readonly Dictionary<int, RecordCollection> EnemyRecordDict = new Dictionary<int, RecordCollection>();

	private CombatCharacter _attacker;

	private CombatCharacter _defender;

	private int _normalAttackWeaponId;

	private OuterAndInnerInts _singleAttackDamage;

	private int _singleAttackMindDamage;

	private bool _gotSkillNeedTrick;

	public AiMemory(CombatCharacter combatChar)
	{
		_combatCharacter = combatChar;
		int[] array = (_combatCharacter.IsAlly ? DomainManager.Combat.GetEnemyTeam() : DomainManager.Combat.GetSelfTeam());
		foreach (int charId in array)
		{
			if (charId >= 0)
			{
				EnemyRecordDict.Add(charId, new RecordCollection());
			}
		}
	}

	public void ClearMemories()
	{
		SelfRecord.ClearAll();
		foreach (RecordCollection enemyRecord in EnemyRecordDict.Values)
		{
			enemyRecord.ClearAll();
		}
	}

	public void RegisterCallbacks()
	{
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_AddMindDamage(OnAddMindDamageValue);
		Events.RegisterHandler_GetTrick(OnGetTrick);
	}

	public void UnregisterCallbacks()
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_AddMindDamage(OnAddMindDamageValue);
		Events.UnRegisterHandler_GetTrick(OnGetTrick);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (attacker == _combatCharacter)
		{
			UpdateMaxValues(isAttacker: true);
		}
		else if (defender == _combatCharacter)
		{
			UpdateMaxValues(isAttacker: false);
		}
		_attacker = attacker;
		_defender = defender;
		_normalAttackWeaponId = attacker.GetWeapons()[attacker.GetUsingWeaponIndex()].Id;
		_singleAttackDamage.Outer = 0;
		_singleAttackDamage.Inner = 0;
		_singleAttackMindDamage = 0;
		_gotSkillNeedTrick = false;
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (attacker == _combatCharacter || EnemyRecordDict.ContainsKey(attacker.GetId()))
		{
			int score = GetAttackScore();
			if (_gotSkillNeedTrick)
			{
				score += 400;
			}
			Dictionary<int, (int, int)> weaponRecord = ((attacker == _combatCharacter) ? SelfRecord.WeaponRecord : EnemyRecordDict[attacker.GetId()].WeaponRecord);
			UpdateWeaponScore(weaponRecord, _normalAttackWeaponId, score);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == _combatCharacter)
		{
			UpdateMaxValues(isAttacker: true);
		}
		else if (defender == _combatCharacter)
		{
			UpdateMaxValues(isAttacker: false);
		}
		_attacker = attacker;
		_defender = defender;
		_singleAttackDamage.Outer = 0;
		_singleAttackDamage.Inner = 0;
		_singleAttackMindDamage = 0;
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		if (skillConfig.EquipType != 1 || interrupted || (charId != _combatCharacter.GetId() && !EnemyRecordDict.ContainsKey(charId)) || !DomainManager.CombatSkill.TryGetElement_CombatSkills(skillKey, out var skill))
		{
			return;
		}
		int score = GetAttackScore();
		int powerScore = DomainManager.SpecialEffect.ModifyData(charId, skillId, 304, power) * 2;
		if (powerScore > 0)
		{
			sbyte direction = skill.GetDirection();
			if (direction != -1)
			{
				short effectTemplateId = ((direction == 0) ? skillConfig.DirectEffectID : skillConfig.ReverseEffectID);
				SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectTemplateId];
				if (effectConfig.RequireAttackPower < 0 || power >= effectConfig.RequireAttackPower)
				{
					powerScore *= 2;
				}
			}
		}
		score += powerScore;
		Dictionary<short, (int, int)> skillRecord = ((charId == _combatCharacter.GetId()) ? SelfRecord.SkillRecord : EnemyRecordDict[charId].SkillRecord);
		UpdateSkillScore(skillRecord, skillId, score);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (defenderId == _combatCharacter.GetId() && attackerId != _combatCharacter.GetId())
		{
			int distanceIndex = RecordCollection.GetIndexByDistance(DomainManager.Combat.GetCurrentDistance());
			if (isInner)
			{
				SelfRecord.MaxDamages[distanceIndex].Inner = Math.Max(SelfRecord.MaxDamages[distanceIndex].Inner, damageValue);
			}
			else
			{
				SelfRecord.MaxDamages[distanceIndex].Outer = Math.Max(SelfRecord.MaxDamages[distanceIndex].Outer, damageValue);
			}
		}
		if (isInner)
		{
			_singleAttackDamage.Inner += damageValue;
		}
		else
		{
			_singleAttackDamage.Outer += damageValue;
		}
	}

	private void OnAddMindDamageValue(DataContext context, int attackerId, int defenderId, int damageValue, int markCount, short combatSkillId)
	{
		if (defenderId == _combatCharacter.GetId() && attackerId != _combatCharacter.GetId())
		{
			int distanceIndex = RecordCollection.GetIndexByDistance(DomainManager.Combat.GetCurrentDistance());
			SelfRecord.MaxMindDamages[distanceIndex] = Math.Max(SelfRecord.MaxMindDamages[distanceIndex], damageValue);
		}
		_singleAttackMindDamage += damageValue;
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (_attacker != null && charId == _attacker.GetId())
		{
			_gotSkillNeedTrick = true;
		}
	}

	private unsafe void UpdateMaxValues(bool isAttacker)
	{
		DamageCompareData damageData = DomainManager.Combat.GetDamageCompareData();
		short distance = DomainManager.Combat.GetCurrentDistance();
		int distanceIndex = RecordCollection.GetIndexByDistance(distance);
		if (isAttacker)
		{
			for (int i = 0; i < damageData.HitType.Length; i++)
			{
				sbyte hitType = damageData.HitType[i];
				if (hitType >= 0)
				{
					HitOrAvoidInts hitValues = SelfRecord.MaxHits[distanceIndex];
					hitValues.Items[hitType] = Math.Max(hitValues.Items[hitType], damageData.HitValue[i]);
				}
			}
			if (damageData.OuterAttackValue >= 0)
			{
				SelfRecord.MaxPenetrates[distanceIndex].Outer = Math.Max(SelfRecord.MaxPenetrates[distanceIndex].Outer, damageData.OuterAttackValue);
			}
			if (damageData.InnerAttackValue >= 0)
			{
				SelfRecord.MaxPenetrates[distanceIndex].Inner = Math.Max(SelfRecord.MaxPenetrates[distanceIndex].Inner, damageData.InnerAttackValue);
			}
			return;
		}
		for (int j = 0; j < damageData.HitType.Length; j++)
		{
			sbyte hitType2 = damageData.HitType[j];
			if (hitType2 >= 0)
			{
				SelfRecord.MaxAvoid.Items[hitType2] = Math.Max(SelfRecord.MaxAvoid.Items[hitType2], damageData.AvoidValue[j]);
			}
		}
		if (damageData.OuterDefendValue >= 0)
		{
			SelfRecord.MaxPenetrateResist.Outer = Math.Max(SelfRecord.MaxPenetrateResist.Outer, damageData.OuterDefendValue);
		}
		if (damageData.InnerDefendValue >= 0)
		{
			SelfRecord.MaxPenetrateResist.Inner = Math.Max(SelfRecord.MaxPenetrateResist.Inner, damageData.InnerDefendValue);
		}
	}

	private int GetAttackScore()
	{
		DamageStepCollection damageStepCollection = _defender.GetDamageStepCollection();
		int score = 0;
		score += _singleAttackDamage.Outer * 100 / (damageStepCollection.OuterDamageSteps.Sum() / 7);
		score += _singleAttackDamage.Inner * 100 / (damageStepCollection.InnerDamageSteps.Sum() / 7);
		return score + _singleAttackMindDamage * 100 / damageStepCollection.MindDamageStep;
	}

	private void UpdateWeaponScore(Dictionary<int, (int score, int zeroScoreCount)> weaponRecord, int weaponId, int newScore)
	{
		if (weaponRecord.ContainsKey(weaponId))
		{
			(int, int) record = weaponRecord[weaponId];
			if (newScore > 0)
			{
				record.Item1 = newScore;
				record.Item2 = 0;
			}
			else
			{
				record.Item2++;
			}
			weaponRecord[weaponId] = record;
		}
		else
		{
			weaponRecord.Add(weaponId, (newScore, (newScore <= 0) ? 1 : 0));
		}
	}

	private void UpdateSkillScore(Dictionary<short, (int score, int zeroScoreCount)> skillRecord, short skillId, int newScore)
	{
		if (skillRecord.ContainsKey(skillId))
		{
			(int, int) record = skillRecord[skillId];
			if (newScore > 0)
			{
				record.Item1 = newScore;
				record.Item2 = 0;
			}
			else
			{
				record.Item2++;
			}
			skillRecord[skillId] = record;
		}
		else
		{
			skillRecord.Add(skillId, (newScore, (newScore <= 0) ? 1 : 0));
		}
	}
}

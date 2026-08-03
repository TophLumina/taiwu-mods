using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class LiuXinSiYiDao : CombatSkillEffectBase
{
	private CombatSkillKey _affectingSkillKey;

	private int _changePower;

	public LiuXinSiYiDao()
	{
	}

	public LiuXinSiYiDao(CombatSkillKey skillKey)
		: base(skillKey, 14203, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(199, EDataModifyType.Add, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(199, EDataModifyType.Add, -1);
		}
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (Config.CombatSkill.Instance[skillId].EquipType != 1 || base.EffectCount <= 0 || (base.IsDirect ? (charId != base.CharacterId) : (isAlly == base.CombatChar.IsAlly)))
		{
			return;
		}
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerAddDict = (base.IsDirect ? DomainManager.Combat.GetAllSkillPowerAddInCombat() : DomainManager.Combat.GetAllSkillPowerReduceInCombat());
		List<short> skillList = DomainManager.Combat.GetElement_CombatCharacterDict(charId).GetAttackSkillList();
		bool isDrunk = CharObj.GetEatingItems().ContainsWine();
		_changePower = 0;
		for (int i = 0; i < skillList.Count; i++)
		{
			short attackSkillId = skillList[i];
			if (attackSkillId < 0 || attackSkillId == skillId)
			{
				continue;
			}
			CombatSkillKey skillKey = new CombatSkillKey(charId, attackSkillId);
			if (powerAddDict.ContainsKey(skillKey))
			{
				int power = powerAddDict[skillKey].GetTotalChangeValue() / (isDrunk ? 1 : 2);
				if (base.IsDirect ? (power > _changePower) : (power < _changePower))
				{
					_changePower = power;
				}
			}
		}
		if (_changePower != 0)
		{
			if (_affectingSkillKey.IsValid)
			{
				ResetAffectingSkillKey(context);
			}
			_affectingSkillKey = new CombatSkillKey(charId, skillId);
			InvalidateCache(context, charId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_affectingSkillKey.IsMatch(charId, skillId))
		{
			ResetAffectingSkillKey(context);
			ReduceEffectCount();
		}
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void ResetAffectingSkillKey(DataContext context)
	{
		if (_affectingSkillKey.IsValid)
		{
			int charId = _affectingSkillKey.CharId;
			_affectingSkillKey = CombatSkillKey.Invalid;
			InvalidateCache(context, charId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != _affectingSkillKey)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _changePower;
		}
		return 0;
	}
}

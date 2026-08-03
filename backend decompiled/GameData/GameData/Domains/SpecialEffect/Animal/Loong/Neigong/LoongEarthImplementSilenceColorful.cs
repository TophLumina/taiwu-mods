using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongEarthImplementSilenceColorful : LoongEarthImplementSilence, ILoongEarthExtra
{
	public delegate void OnSilenceAffect(DataContext context, CombatCharacter combatChar, short skillId);

	private const int MaxValuePercent = 50;

	private const int AddFlawOrAcupointLevel = 3;

	private const int AddFlawOrAcupointCount = 4;

	private readonly Dictionary<int, HashSet<short>> _silencingAttackSkills = new Dictionary<int, HashSet<short>>();

	private readonly Dictionary<int, HashSet<short>> _silencingAgileSkills = new Dictionary<int, HashSet<short>>();

	private readonly Dictionary<int, HashSet<short>> _silencingAssistSkills = new Dictionary<int, HashSet<short>>();

	private OnSilenceAffect GetAffectByCombatSkillId(short skillId)
	{
		sbyte equipType = Config.CombatSkill.Instance[skillId].EquipType;
		if (1 == 0)
		{
		}
		OnSilenceAffect result = equipType switch
		{
			1 => OnSilenceAttack, 
			2 => OnSilenceAgile, 
			3 => OnSilenceDefense, 
			4 => OnSilenceAssist, 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		base.EffectBase.CreateAffectedAllEnemyData(171, EDataModifyType.Custom, -1);
		base.EffectBase.CreateAffectedAllEnemyData(172, EDataModifyType.Custom, -1);
		base.EffectBase.CreateAffectedAllEnemyData(273, EDataModifyType.Custom, -1);
		Events.RegisterHandler_SkillSilenceEnd(OnSkillSilenceEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_SkillSilenceEnd(OnSkillSilenceEnd);
		base.OnDisable(context);
	}

	private void OnSkillSilenceEnd(DataContext context, CombatSkillKey skillKey)
	{
		if (_silencingAttackSkills.TryGetValue(skillKey.CharId, out var attackSkills) && attackSkills.Remove(skillKey.SkillTemplateId) && attackSkills.Count == 0)
		{
			InvalidCacheAttack(context, skillKey.CharId);
		}
		if (_silencingAgileSkills.TryGetValue(skillKey.CharId, out var agileSkills) && agileSkills.Remove(skillKey.SkillTemplateId) && agileSkills.Count == 0)
		{
			InvalidCacheAgile(context, skillKey.CharId);
		}
	}

	public void OnSilenced(DataContext context, CombatCharacter combatChar, short skillId)
	{
		GetAffectByCombatSkillId(skillId)?.Invoke(context, combatChar, skillId);
	}

	private void InvalidCacheAttack(DataContext context, int charId)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, charId, 171);
		DomainManager.SpecialEffect.InvalidateCache(context, charId, 172);
		if (DomainManager.Combat.IsCharInCombat(charId))
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			if (combatChar.GetBreathValue() > combatChar.GetMaxBreathValue())
			{
				DomainManager.Combat.ChangeBreathValue(context, combatChar, 0);
			}
			if (combatChar.GetStanceValue() > combatChar.GetMaxStanceValue())
			{
				DomainManager.Combat.ChangeStanceValue(context, combatChar, 0);
			}
		}
	}

	private void InvalidCacheAgile(DataContext context, int charId)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, charId, 273);
		if (DomainManager.Combat.IsCharInCombat(charId))
		{
			CombatCharacter combatChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			if (combatChar.GetMobilityValue() > combatChar.GetMaxMobility())
			{
				DomainManager.Combat.ChangeMobilityValue(context, combatChar, 0);
			}
		}
	}

	private void OnSilenceAttack(DataContext context, CombatCharacter combatChar, short skillId)
	{
		HashSet<short> skills = _silencingAttackSkills.GetOrNew(combatChar.GetId());
		bool needUpdateCache = skills.Count == 0;
		skills.Add(skillId);
		if (needUpdateCache)
		{
			InvalidCacheAttack(context, combatChar.GetId());
			base.EffectBase.ShowSpecialEffectTips(1);
		}
	}

	private void OnSilenceAgile(DataContext context, CombatCharacter combatChar, short skillId)
	{
		HashSet<short> skills = _silencingAgileSkills.GetOrNew(combatChar.GetId());
		bool needUpdateCache = skills.Count == 0;
		skills.Add(skillId);
		if (needUpdateCache)
		{
			InvalidCacheAgile(context, combatChar.GetId());
			base.EffectBase.ShowSpecialEffectTips(2);
		}
	}

	private void OnSilenceDefense(DataContext context, CombatCharacter combatChar, short skillId)
	{
		for (int i = 0; i < 4; i++)
		{
			DomainManager.Combat.AddFlaw(context, combatChar, 3, base.EffectBase.SkillKey, -1);
		}
		base.EffectBase.ShowSpecialEffectTips(3);
	}

	private void OnSilenceAssist(DataContext context, CombatCharacter combatChar, short skillId)
	{
		for (int i = 0; i < 4; i++)
		{
			DomainManager.Combat.AddAcupoint(context, combatChar, 3, base.EffectBase.SkillKey, -1);
		}
		base.EffectBase.ShowSpecialEffectTips(4);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId == base.EffectBase.CharacterId)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 171) <= 1u;
		if (flag && _silencingAttackSkills.TryGetValue(dataKey.CharId, out var attackSkills) && attackSkills.Count > 0)
		{
			return Math.Min(50, dataValue);
		}
		if (dataKey.FieldId == 273 && _silencingAgileSkills.TryGetValue(dataKey.CharId, out var agileSkills) && agileSkills.Count > 0)
		{
			return Math.Min(50, dataValue);
		}
		return dataValue;
	}
}

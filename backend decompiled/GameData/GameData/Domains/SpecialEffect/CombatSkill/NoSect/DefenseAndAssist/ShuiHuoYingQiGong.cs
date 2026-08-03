using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.DefenseAndAssist;

public class ShuiHuoYingQiGong : DefenseSkillBase
{
	private const int DefaultReduceDamage = 80;

	private const int MinReduceDamage = 0;

	private const int ReduceEffectUnit = 1;

	private int _reduceDamage;

	private static CValuePercent ReduceEffectStep => 20;

	public ShuiHuoYingQiGong()
	{
		AutoRemove = false;
	}

	public ShuiHuoYingQiGong(CombatSkillKey skillKey)
		: base(skillKey, 300)
	{
		AutoRemove = false;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_reduceDamage = 80;
		CreateAffectedData(114, EDataModifyType.Custom, -1);
		CreateAffectedData(253, EDataModifyType.Custom, -1);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 114 || !base.CanAffect)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		long reduceValue = dataValue * (CValuePercent)_reduceDamage;
		if (reduceValue <= 0)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		bool inner = dataKey.CustomParam1 == 1;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		DamageStepCollection steps = base.CombatChar.GetDamageStepCollection();
		int step = (inner ? steps.InnerDamageSteps : steps.OuterDamageSteps)[bodyPart];
		if (dataValue >= step * ReduceEffectStep)
		{
			int reduceEffect = (int)dataValue / Math.Max(step * ReduceEffectStep, 1);
			int prevReduceDamage = _reduceDamage;
			_reduceDamage = Math.Max(_reduceDamage - reduceEffect, 0);
			if (prevReduceDamage != _reduceDamage)
			{
				InvalidateCache(DomainManager.Combat.Context, 253);
			}
		}
		return dataValue - reduceValue;
	}

	public override List<CombatSkillEffectData> GetModifiedValue(AffectedDataKey dataKey, List<CombatSkillEffectData> dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 253)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		dataValue.Add(new CombatSkillEffectData(ECombatSkillEffectType.ShuiHuoYingQiGongReduceDamage, _reduceDamage));
		return dataValue;
	}
}

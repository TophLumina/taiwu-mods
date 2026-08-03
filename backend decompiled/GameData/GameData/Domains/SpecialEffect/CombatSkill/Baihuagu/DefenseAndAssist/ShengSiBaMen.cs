using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class ShengSiBaMen : AssistSkillBase
{
	public ShengSiBaMen()
	{
	}

	public ShengSiBaMen(CombatSkillKey skillKey)
		: base(skillKey, 3606)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		base.OnDisable(context);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		TryAffect(context, attackerId, defenderId, bodyPart, outerMarkCount, innerMarkCount);
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		TryAffect(context, attackerId, defenderId, bodyPart, outerMarkCount, innerMarkCount);
	}

	private void TryAffect(DataContext context, int attackerId, int defenderId, sbyte part, int outer, int inner)
	{
		CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId);
		CombatCharacter defender = DomainManager.Combat.GetElement_CombatCharacterDict(defenderId);
		if (IsAffectMaker(attacker) && IsAffectChar(defender))
		{
			if (inner > 0)
			{
				DoAffect(context, defender, part, inner: true);
			}
			if (outer > 0)
			{
				DoAffect(context, defender, part, inner: false);
			}
		}
	}

	private bool IsAffectMaker(CombatCharacter maker)
	{
		if (base.IsDirect)
		{
			return maker.IsAlly != base.CombatChar.IsAlly;
		}
		return maker.GetId() == base.CharacterId;
	}

	private bool IsAffectChar(CombatCharacter character)
	{
		if (base.IsDirect)
		{
			return character.GetId() == base.CharacterId;
		}
		return character.IsAlly != base.CombatChar.IsAlly;
	}

	private void DoAffect(DataContext context, CombatCharacter affectChar, sbyte bodyPart, bool inner)
	{
		if (TryGetTarget(affectChar, context.Random, ref bodyPart, ref inner))
		{
			if (base.IsDirect)
			{
				affectChar.RemoveInjury(context, bodyPart, inner);
			}
			else
			{
				affectChar.WorsenInjury(context, bodyPart, inner);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private bool TryGetTarget(CombatCharacter affectChar, IRandomSource random, ref sbyte bodyPart, ref bool inner)
	{
		int maxCount = 0;
		Injuries injuries = affectChar.GetInjuries();
		Injuries affectInjuries = (base.IsDirect ? injuries.Subtract(affectChar.GetOldInjuries()) : injuries);
		List<sbyte> innerBodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		List<sbyte> outerBodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (i != bodyPart)
			{
				sbyte innerCount = affectInjuries.Get(i, isInnerInjury: true);
				sbyte outerCount = affectInjuries.Get(i, isInnerInjury: false);
				if (innerCount > 0 || outerCount > 0)
				{
					if (innerCount > maxCount || outerCount > maxCount)
					{
						maxCount = Math.Max(Math.Max(maxCount, innerCount), outerCount);
						innerBodyParts.Clear();
						outerBodyParts.Clear();
					}
					if (innerCount == maxCount)
					{
						innerBodyParts.Add(i);
					}
					if (outerCount == maxCount)
					{
						outerBodyParts.Add(i);
					}
				}
			}
		}
		bool anyInner = innerBodyParts.Count > 0;
		bool anyOuter = outerBodyParts.Count > 0;
		if (anyInner || anyOuter)
		{
			inner = random.RandomIsInner(anyInner, anyOuter);
			bodyPart = (inner ? innerBodyParts : outerBodyParts).GetRandom(random);
		}
		ObjectPool<List<sbyte>>.Instance.Return(innerBodyParts);
		ObjectPool<List<sbyte>>.Instance.Return(outerBodyParts);
		return anyInner || anyOuter;
	}
}

using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class EShaQiangFa : CombatSkillEffectBase
{
	private static readonly CValuePercent AccumulateFatalPercent = 20;

	private OuterAndInnerInts _fatalDamage;

	public EShaQiangFa()
	{
	}

	public EShaQiangFa(CombatSkillKey skillKey)
		: base(skillKey, 6300, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AddDirectFatalDamage(OnAddDirectFatalDamage);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectFatalDamage(OnAddDirectFatalDamage);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectFatalDamage(CombatContext context, OuterAndInnerInts damage, OuterAndInnerInts markCounts)
	{
		if (base.EffectCount > 0 && (base.IsDirect ? context.Attacker : context.Defender) == base.CombatChar)
		{
			OuterAndInnerInts outerAndInnerInts = damage;
			var (outer, inner) = (OuterAndInnerInts)(ref outerAndInnerInts);
			outer *= AccumulateFatalPercent;
			inner *= AccumulateFatalPercent;
			if (outer > 0 || inner > 0)
			{
				_fatalDamage.Outer += Math.Max(outer, 0);
				_fatalDamage.Inner += Math.Max(inner, 0);
				ReduceEffectCount();
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			if (PowerMatchAffectRequire(power))
			{
				DoAffect(context);
			}
			else if (_fatalDamage.IsNonZero)
			{
				ShowSpecialEffectTips(2);
			}
			_fatalDamage = (outer: 0, inner: 0);
		}
	}

	private void DoAffect(DataContext context)
	{
		AddMaxEffectCount();
		if (_fatalDamage.IsNonZero)
		{
			ShowSpecialEffectTips(1);
		}
		if (_fatalDamage.Outer > 0)
		{
			base.CurrEnemyChar.AddFatalDamage(context, _fatalDamage.Outer, 0, -1, -1);
		}
		if (_fatalDamage.Inner > 0)
		{
			base.CurrEnemyChar.AddFatalDamage(context, _fatalDamage.Inner, 1, -1, -1);
		}
	}
}

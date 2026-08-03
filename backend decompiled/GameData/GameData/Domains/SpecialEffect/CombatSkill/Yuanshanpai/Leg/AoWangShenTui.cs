using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class AoWangShenTui : CombatSkillEffectBase
{
	private const string ParticleName = "Particle_Effect_BringCloserCenter";

	private const int ChangeDistanceProgressPercent = 2;

	private const int CenterDamageProgressPercent = 10;

	private const int CenterDamageRange = 1;

	private const int CenterDamageBase = 100;

	private const int CenterDamageDivisor = 2;

	private const int FlawOrAcupointOdds = 50;

	private const sbyte FlawOrAcupointLevel = 1;

	private int _lastUpdateProgressPercent;

	public AoWangShenTui()
	{
	}

	public AoWangShenTui(CombatSkillKey skillKey)
		: base(skillKey, 5107, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			_lastUpdateProgressPercent = 0;
			base.CombatChar.SetParticleToLoopByCombatSkill("Particle_Effect_BringCloserCenter", context);
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			base.CombatChar.SetParticleToLoopByCombatSkill(null, context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			_lastUpdateProgressPercent = 0;
			base.CombatChar.SetParticleToLoopByCombatSkill(null, context);
		}
	}

	private void OnPrepareSkillProgressChange(DataContext context, int charId, bool isAlly, short skillId, sbyte preparePercent)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			int deltaPercent = preparePercent - _lastUpdateProgressPercent;
			while (deltaPercent >= 2 && !IsInAttackRangeCenter())
			{
				deltaPercent -= 2;
				DoChangeDistance(context);
			}
			while (deltaPercent >= 10 && IsInAttackRangeCenter())
			{
				deltaPercent -= 10;
				DoCenterDamage(context);
			}
			_lastUpdateProgressPercent = preparePercent - deltaPercent;
		}
	}

	private int CalcRangeCenter()
	{
		OuterAndInnerInts attackRange = DomainManager.Combat.GetSkillAttackRange(base.CombatChar, base.SkillTemplateId);
		return (attackRange.Outer + attackRange.Inner) / 2;
	}

	private bool IsInAttackRangeCenter()
	{
		int rangeCenter = CalcRangeCenter();
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		return Math.Abs(currDistance - rangeCenter) <= 1;
	}

	private void DoChangeDistance(DataContext context)
	{
		int rangeCenter = CalcRangeCenter();
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		if (rangeCenter != currDistance)
		{
			int direction = ((rangeCenter >= currDistance) ? 1 : (-1));
			DomainManager.Combat.ChangeDistance(context, base.EnemyChar, direction, isForced: true);
		}
	}

	private void DoCenterDamage(DataContext context)
	{
		short baseValue = (base.IsDirect ? CharObj.GetRecoveryOfFlaw() : CharObj.GetRecoveryOfBlockedAcupoint());
		int damageValue = 100 + baseValue / 2;
		sbyte part = base.EnemyChar.RandomInjuryBodyPartMustValid(context.Random, !base.IsDirect);
		int markCount = DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.EnemyChar, part, base.IsDirect ? damageValue : 0, (!base.IsDirect) ? damageValue : 0, base.SkillTemplateId);
		for (int i = 0; i < markCount; i++)
		{
			if (context.Random.CheckPercentProb(50))
			{
				if (base.IsDirect)
				{
					DomainManager.Combat.AddFlaw(context, base.EnemyChar, 1, SkillKey, -1);
				}
				else
				{
					DomainManager.Combat.AddAcupoint(context, base.EnemyChar, 1, SkillKey, -1);
				}
			}
		}
		ShowSpecialEffectTips(0);
	}
}

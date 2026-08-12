using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class ZhiLanYuBu : AgileSkillBase
{
	private const sbyte HealInjuryCount = 2;

	private bool _affecting;

	private List<(sbyte, bool, sbyte)> _injuryRandomPool;

	public ZhiLanYuBu()
	{
	}

	public ZhiLanYuBu(CombatSkillKey skillKey)
		: base(skillKey, 3406)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover != base.CombatChar || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)) || !_affecting || DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			return;
		}
		Injuries newInjuries = base.CombatChar.GetInjuries().Subtract(base.CombatChar.GetOldInjuries());
		if (_injuryRandomPool == null)
		{
			_injuryRandomPool = new List<(sbyte, bool, sbyte)>();
		}
		_injuryRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			(sbyte, sbyte) injury = newInjuries.Get(part);
			if (injury.Item1 > 0)
			{
				_injuryRandomPool.Add((part, false, injury.Item1));
			}
			if (injury.Item2 > 0)
			{
				_injuryRandomPool.Add((part, true, injury.Item2));
			}
		}
		if (_injuryRandomPool.Count > 0)
		{
			(sbyte, bool, sbyte) injuryInfo = _injuryRandomPool[context.Random.Next(0, _injuryRandomPool.Count)];
			base.CombatChar.RemoveInjury(context, injuryInfo.Item1, injuryInfo.Item2, Math.Min(2, injuryInfo.Item3));
			ShowSpecialEffectTips(0);
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			if (canAffect)
			{
				DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId, base.IsDirect);
			}
			else
			{
				DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}
}

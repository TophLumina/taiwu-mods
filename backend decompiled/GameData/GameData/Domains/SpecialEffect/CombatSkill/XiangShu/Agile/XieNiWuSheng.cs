using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class XieNiWuSheng : AgileSkillBase
{
	private const sbyte AffectSkillCount = 3;

	private bool _affecting;

	public XieNiWuSheng()
	{
	}

	public XieNiWuSheng(CombatSkillKey skillKey)
		: base(skillKey, 16201)
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
		if (mover != base.CombatChar || !isMove || isForced || !_affecting)
		{
			return;
		}
		int enemyCharId = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetId();
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = DomainManager.Combat.GetAllSkillPowerAddInCombat();
		List<CombatSkillKey> skillRandomPool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		skillRandomPool.Clear();
		foreach (CombatSkillKey skillKey in powerDict.Keys)
		{
			if (skillKey.CharId == enemyCharId)
			{
				skillRandomPool.Add(skillKey);
			}
		}
		if (skillRandomPool.Count > 0)
		{
			int removeCount = Math.Min(3, skillRandomPool.Count);
			for (int i = 0; i < removeCount; i++)
			{
				int index = context.Random.Next(0, skillRandomPool.Count);
				DomainManager.Combat.RemoveSkillPowerAddInCombat(context, skillRandomPool[index]);
				skillRandomPool.RemoveAt(index);
			}
			DomainManager.SpecialEffect.InvalidateCache(context, enemyCharId, 199);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(skillRandomPool);
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			if (canAffect)
			{
				DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId);
			}
			else
			{
				DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}
}

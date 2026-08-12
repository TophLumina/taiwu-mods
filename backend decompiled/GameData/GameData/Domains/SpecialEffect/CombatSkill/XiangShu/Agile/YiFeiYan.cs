using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class YiFeiYan : AgileSkillBase
{
	private const sbyte TrickPerDistance = 2;

	private bool _affecting;

	public YiFeiYan()
	{
	}

	public YiFeiYan(CombatSkillKey skillKey)
		: base(skillKey, 16204)
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
		if (_affecting && base.CombatChar.GetJumpPreparedDistance() > 0)
		{
			RemoveEnemyTricks(context, base.CombatChar.GetJumpPreparedDistance());
		}
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && _affecting)
		{
			RemoveEnemyTricks(context, distance);
		}
	}

	private void RemoveEnemyTricks(DataContext context, short distance)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		IReadOnlyDictionary<int, sbyte> trickDict = enemyChar.GetTricks().Tricks;
		int removeCount = Math.Min(2 * Math.Abs(distance) / 10, trickDict.Count);
		if (removeCount > 0)
		{
			List<int> keyList = ObjectPool<List<int>>.Instance.Get();
			List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
			keyList.Clear();
			keyList.AddRange(trickDict.Keys);
			removeTricks.Clear();
			for (int i = 0; i < removeCount; i++)
			{
				int index = context.Random.Next(0, keyList.Count);
				removeTricks.Add(new NeedTrick(trickDict[keyList[index]], 1));
				keyList.RemoveAt(index);
			}
			DomainManager.Combat.RemoveTrick(context, enemyChar, removeTricks, removedByAlly: false);
			ObjectPool<List<int>>.Instance.Return(keyList);
			ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
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
				DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId);
			}
			else
			{
				DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}
}

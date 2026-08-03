using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;

public class YuNvNuoLian : AgileSkillBase
{
	private const sbyte NeedMoveDistance = 10;

	private const sbyte ExchangeTrickCount = 3;

	private int _distanceAccumulator;

	public YuNvNuoLian()
	{
	}

	public YuNvNuoLian(CombatSkillKey skillKey)
		: base(skillKey, 2503)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover != base.CombatChar || !isMove || isForced || !(base.IsDirect ? (distance < 0) : (distance > 0)))
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		while (_distanceAccumulator >= 10)
		{
			_distanceAccumulator -= 10;
			if (!base.CanAffect)
			{
				continue;
			}
			CombatCharacter selfChar = base.CombatChar;
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			TrickCollection selfTricks = base.CombatChar.GetTricks();
			TrickCollection enemyTricks = enemyChar.GetTricks();
			List<sbyte> selfTrickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			List<sbyte> enemyTrickRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			selfTrickRandomPool.Clear();
			enemyTrickRandomPool.Clear();
			selfTrickRandomPool.AddRange(selfTricks.Tricks.Where(delegate(KeyValuePair<int, sbyte> trick)
			{
				CombatCharacter combatChar = base.CombatChar;
				KeyValuePair<int, sbyte> keyValuePair = trick;
				return combatChar.IsTrickUseless(keyValuePair.Value);
			}).Select(delegate(KeyValuePair<int, sbyte> trick)
			{
				KeyValuePair<int, sbyte> keyValuePair = trick;
				return keyValuePair.Value;
			}));
			enemyTrickRandomPool.AddRange(enemyTricks.Tricks.Where(delegate(KeyValuePair<int, sbyte> trick)
			{
				CombatCharacter combatChar = base.CombatChar;
				KeyValuePair<int, sbyte> keyValuePair = trick;
				return combatChar.IsTrickUsable(keyValuePair.Value);
			}).Select(delegate(KeyValuePair<int, sbyte> trick)
			{
				KeyValuePair<int, sbyte> keyValuePair = trick;
				return keyValuePair.Value;
			}));
			int exchangeCount = Math.Min(Math.Min(selfTrickRandomPool.Count, enemyTrickRandomPool.Count), 3);
			if (exchangeCount > 0)
			{
				CollectionUtils.Shuffle(context.Random, selfTrickRandomPool);
				CollectionUtils.Shuffle(context.Random, enemyTrickRandomPool);
				List<NeedTrick> selfRemoveTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				List<NeedTrick> selfAddTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				List<NeedTrick> enemyRemoveTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				List<NeedTrick> enemyAddTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
				for (int i = 0; i < exchangeCount; i++)
				{
					sbyte selfTrickType = selfTrickRandomPool[i];
					sbyte enemyTrickType = enemyTrickRandomPool[i];
					selfRemoveTricks.Add(new NeedTrick(selfTrickType, 1));
					selfAddTricks.Add(new NeedTrick(enemyTrickType, 1));
					enemyRemoveTricks.Add(new NeedTrick(enemyTrickType, 1));
					enemyAddTricks.Add(new NeedTrick(selfTrickType, 1));
				}
				DomainManager.Combat.RemoveTrick(context, selfChar, selfRemoveTricks);
				DomainManager.Combat.RemoveTrick(context, enemyChar, enemyRemoveTricks, removedByAlly: false);
				DomainManager.Combat.AddTrick(context, selfChar, selfAddTricks);
				DomainManager.Combat.AddTrick(context, enemyChar, enemyAddTricks, addedByAlly: false);
				ObjectPool<List<NeedTrick>>.Instance.Return(selfRemoveTricks);
				ObjectPool<List<NeedTrick>>.Instance.Return(selfAddTricks);
				ObjectPool<List<NeedTrick>>.Instance.Return(enemyRemoveTricks);
				ObjectPool<List<NeedTrick>>.Instance.Return(enemyAddTricks);
				ShowSpecialEffectTips(0);
			}
			ObjectPool<List<sbyte>>.Instance.Return(selfTrickRandomPool);
			ObjectPool<List<sbyte>>.Instance.Return(enemyTrickRandomPool);
		}
	}
}

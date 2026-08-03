using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class JinWuGu : DefenseSkillBase
{
	private const sbyte TrickCount = 2;

	public JinWuGu()
	{
	}

	public JinWuGu(CombatSkillKey skillKey)
		: base(skillKey, 2603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!(defender != base.CombatChar || hit) && base.CanAffect && attacker.NormalAttackHitType == 2)
		{
			DoEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.Defender != base.CombatChar || hit) && base.CanAffect && index <= 2 && DomainManager.Combat.GetDamageCompareData().HitType[index] == 2)
		{
			DoEffect(context);
		}
	}

	private void DoEffect(DataContext context)
	{
		if (base.IsDirect)
		{
			DomainManager.Combat.AddRandomTrick(context, base.CombatChar, 2);
			ShowSpecialEffectTips(0);
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		IReadOnlyDictionary<int, sbyte> trickDict = enemyChar.GetTricks().Tricks;
		if (trickDict.Count == 0)
		{
			return;
		}
		List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
		List<int> keyList = ObjectPool<List<int>>.Instance.Get();
		keyList.Clear();
		removeTricks.Clear();
		keyList.AddRange(trickDict.Keys);
		keyList.RemoveAll((int key) => enemyChar.IsTrickUseless(trickDict[key]));
		if (keyList.Count > 0)
		{
			int removeCount = Math.Min(2, keyList.Count);
			for (int i = 0; i < removeCount; i++)
			{
				int index = context.Random.Next(0, keyList.Count);
				removeTricks.Add(new NeedTrick(trickDict[keyList[index]], 1));
				keyList.RemoveAt(index);
			}
			DomainManager.Combat.RemoveTrick(context, enemyChar, removeTricks, removedByAlly: false);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<int>>.Instance.Return(keyList);
		ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
	}
}

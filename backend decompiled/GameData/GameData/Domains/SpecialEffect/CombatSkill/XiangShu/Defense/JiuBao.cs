using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class JiuBao : DefenseSkillBase
{
	private const int ReduceInjuryCount = 3;

	public JiuBao()
	{
	}

	public JiuBao(CombatSkillKey skillKey)
		: base(skillKey, 16303)
	{
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.CombatChar.GetInjuries().GetSum() <= 0 || !base.SkillData.GetCanAffect())
		{
			return;
		}
		Injuries injuries = base.CombatChar.GetInjuries();
		Injuries oldInjuries = base.CombatChar.GetOldInjuries();
		for (sbyte i = 0; i < 7; i++)
		{
			if (base.CombatChar.HasBreakInjury(i))
			{
				var (outer, inner) = injuries.Get(i);
				var (outerOld, innerOld) = oldInjuries.Get(i);
				injuries.Change(i, isInnerInjury: false, (sbyte)(-Math.Min(outer - outerOld, 3)));
				injuries.Change(i, isInnerInjury: true, (sbyte)(-Math.Min(inner - innerOld, 3)));
			}
		}
		Injuries newInjuries = injuries.Subtract(oldInjuries);
		List<(bool, bool)> injuryRandomPool = new List<(bool, bool)>();
		injuryRandomPool.Clear();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			(sbyte, sbyte) oldInjury = oldInjuries.Get(bodyPart);
			(sbyte, sbyte) newInjury = newInjuries.Get(bodyPart);
			for (int j = 0; j < oldInjury.Item1; j++)
			{
				injuryRandomPool.Add((false, true));
			}
			for (int k = 0; k < oldInjury.Item2; k++)
			{
				injuryRandomPool.Add((true, true));
			}
			for (int l = 0; l < newInjury.Item1; l++)
			{
				injuryRandomPool.Add((false, false));
			}
			for (int m = 0; m < newInjury.Item2; m++)
			{
				injuryRandomPool.Add((true, false));
			}
		}
		int average = injuryRandomPool.Count / 7;
		int remainder = injuryRandomPool.Count % 7;
		injuries.Initialize();
		oldInjuries.Initialize();
		for (sbyte bodyPart2 = 0; bodyPart2 < 7; bodyPart2++)
		{
			int injuryCount = 0;
			for (int n = 0; n < average; n++)
			{
				AllocationInjury(context, injuryRandomPool, bodyPart2, ref injuries, ref oldInjuries, ref injuryCount);
			}
			if (remainder > 0 && context.Random.CheckProb(remainder, 7 - bodyPart2))
			{
				remainder--;
				AllocationInjury(context, injuryRandomPool, bodyPart2, ref injuries, ref oldInjuries, ref injuryCount);
			}
		}
		base.CombatChar.SetOldInjuries(oldInjuries, context);
		base.CombatChar.SetInjuries(context, injuries);
		DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
		ShowSpecialEffectTips(0);
	}

	private static void AllocationInjury(DataContext context, List<(bool outer, bool old)> injuryRandomPool, sbyte bodyPart, ref Injuries injuries, ref Injuries oldInjuries, ref int injuryCount)
	{
		int index = context.Random.Next(0, injuryRandomPool.Count);
		(bool, bool) injuryInfo = injuryRandomPool[index];
		CollectionUtils.SwapAndRemove(injuryRandomPool, index);
		injuries.Change(bodyPart, injuryInfo.Item1, 1);
		if (injuryInfo.Item2)
		{
			oldInjuries.Change(bodyPart, injuryInfo.Item1, 1);
		}
		else
		{
			injuryCount++;
		}
	}
}

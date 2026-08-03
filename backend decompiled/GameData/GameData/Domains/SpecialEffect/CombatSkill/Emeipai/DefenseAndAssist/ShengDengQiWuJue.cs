using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class ShengDengQiWuJue : DefenseSkillBase
{
	private const int FreeTrickCount = 3;

	private const sbyte HealMarkCount = 2;

	private readonly List<(sbyte, sbyte)> _markRandomPool = new List<(sbyte, sbyte)>();

	public ShengDengQiWuJue()
	{
	}

	public ShengDengQiWuJue(CombatSkillKey skillKey)
		: base(skillKey, 2608)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!isFightBack || !hit || attacker != base.CombatChar || !base.CanAffect)
		{
			return;
		}
		if (base.IsDirect)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries newInjuries = injuries.Subtract(base.CombatChar.GetOldInjuries());
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			bodyPartRandomPool.Clear();
			for (sbyte part = 0; part < 7; part++)
			{
				(sbyte, sbyte) markCount = newInjuries.Get(part);
				for (int i = 0; i < markCount.Item1 + markCount.Item2; i++)
				{
					bodyPartRandomPool.Add(part);
				}
			}
			if (bodyPartRandomPool.Count > 0)
			{
				int removeCount = Math.Min(2, bodyPartRandomPool.Count);
				for (int j = 0; j < removeCount; j++)
				{
					sbyte part2 = bodyPartRandomPool[context.Random.Next(0, bodyPartRandomPool.Count)];
					bool isInner = newInjuries.Get(part2, isInnerInjury: true) > 0 && (newInjuries.Get(part2, isInnerInjury: false) <= 0 || context.Random.CheckPercentProb(50));
					injuries.Change(part2, isInner, -1);
					newInjuries.Change(part2, isInner, -1);
				}
				base.CombatChar.SetInjuries(context, injuries);
				ShowSpecialEffectTips(1);
			}
		}
		else
		{
			DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
			_markRandomPool.Clear();
			for (sbyte part3 = 0; part3 < 7; part3++)
			{
				for (int k = 0; k < markCollection.FlawMarkList[part3].Count; k++)
				{
					_markRandomPool.Add((0, part3));
				}
				for (int l = 0; l < markCollection.AcupointMarkList[part3].Count; l++)
				{
					_markRandomPool.Add((1, part3));
				}
			}
			for (int m = 0; m < markCollection.MindMarkList.Count; m++)
			{
				_markRandomPool.Add((2, -1));
			}
			if (_markRandomPool.Count > 0)
			{
				int removeCount2 = Math.Min(2, _markRandomPool.Count);
				for (int n = 0; n < removeCount2; n++)
				{
					int index = context.Random.Next(0, _markRandomPool.Count);
					(sbyte, sbyte) mark = _markRandomPool[index];
					if (mark.Item1 == 0)
					{
						DomainManager.Combat.RemoveFlaw(context, base.CombatChar, mark.Item2, context.Random.Next(0, base.CombatChar.GetFlawCount()[mark.Item2]));
					}
					else if (mark.Item1 == 1)
					{
						DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, mark.Item2, context.Random.Next(0, base.CombatChar.GetAcupointCount()[mark.Item2]));
					}
					else
					{
						base.CombatChar.RemoveMindMark(context, 1, random: true);
					}
					_markRandomPool.RemoveAt(index);
				}
				ShowSpecialEffectTips(1);
			}
		}
		DomainManager.Combat.AddRandomTrick(context, base.CombatChar, 3);
		ShowSpecialEffectTips(0);
	}
}

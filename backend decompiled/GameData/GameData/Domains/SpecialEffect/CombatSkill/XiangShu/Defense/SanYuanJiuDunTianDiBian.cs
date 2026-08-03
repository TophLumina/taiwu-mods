using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class SanYuanJiuDunTianDiBian : DefenseSkillBase
{
	private const sbyte AffectFrame = 120;

	private static readonly CValuePercent AddStanceAndBreathPercent = 10;

	private int _frameCounter;

	private readonly List<(sbyte type, sbyte bodyPart)> _markRandomPool = new List<(sbyte, sbyte)>();

	public SanYuanJiuDunTianDiBian()
	{
	}

	public SanYuanJiuDunTianDiBian(CombatSkillKey skillKey)
		: base(skillKey, 16308)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_frameCounter = 0;
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter < 120 || !base.CanAffect)
		{
			return;
		}
		_frameCounter = 0;
		_markRandomPool.Clear();
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		DefeatMarkCollection selfMarks = base.CombatChar.GetDefeatMarkCollection();
		DefeatMarkCollection enemyMarks = enemyChar.GetDefeatMarkCollection();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			for (int i = 0; i < Math.Min(selfMarks.OuterInjuryMarkList[bodyPart], 6 - enemyMarks.OuterInjuryMarkList[bodyPart]); i++)
			{
				_markRandomPool.Add((0, bodyPart));
			}
			for (int j = 0; j < Math.Min(selfMarks.InnerInjuryMarkList[bodyPart], 6 - enemyMarks.InnerInjuryMarkList[bodyPart]); j++)
			{
				_markRandomPool.Add((1, bodyPart));
			}
			for (int k = 0; k < Math.Min(selfMarks.FlawMarkList[bodyPart].Count, enemyChar.GetMaxFlawCount() - enemyMarks.FlawMarkList[bodyPart].Count); k++)
			{
				_markRandomPool.Add((2, bodyPart));
			}
			for (int l = 0; l < Math.Min(selfMarks.AcupointMarkList[bodyPart].Count, enemyChar.GetMaxAcupointCount() - enemyMarks.AcupointMarkList[bodyPart].Count); l++)
			{
				_markRandomPool.Add((3, bodyPart));
			}
		}
		for (int m = 0; m < selfMarks.MindMarkList.Count; m++)
		{
			_markRandomPool.Add((4, -1));
		}
		for (int n = 0; n < selfMarks.DieMarkList.Count; n++)
		{
			_markRandomPool.Add((5, -1));
		}
		if (_markRandomPool.Count <= 0)
		{
			return;
		}
		(sbyte, sbyte) markInfo = _markRandomPool[context.Random.Next(0, _markRandomPool.Count)];
		if (markInfo.Item1 == 0 || markInfo.Item1 == 1)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries oldInjuries = base.CombatChar.GetOldInjuries();
			bool inner = markInfo.Item1 == 1;
			int oldInjury = oldInjuries.Get(markInfo.Item2, inner);
			if (oldInjury > 0 && context.Random.CheckProb(oldInjury, injuries.Get(markInfo.Item2, inner)))
			{
				oldInjuries.Change(markInfo.Item2, inner, -1);
				base.CombatChar.SetOldInjuries(oldInjuries, context);
			}
			injuries.Change(markInfo.Item2, inner, -1);
			base.CombatChar.SetInjuries(context, injuries);
		}
		else if (markInfo.Item1 == 2)
		{
			DomainManager.Combat.RemoveFlaw(context, base.CombatChar, markInfo.Item2, context.Random.Next(0, selfMarks.FlawMarkList[markInfo.Item2].Count));
		}
		else if (markInfo.Item1 == 3)
		{
			DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, markInfo.Item2, context.Random.Next(0, selfMarks.AcupointMarkList[markInfo.Item2].Count));
		}
		else if (markInfo.Item1 == 4)
		{
			base.CombatChar.RemoveMindMark(context, 1, random: true);
		}
		else if (markInfo.Item1 == 5)
		{
			int index = context.Random.Next(0, selfMarks.DieMarkList.Count);
			selfMarks.DieMarkList.RemoveAt(index);
			base.CombatChar.SetDefeatMarkCollection(selfMarks, context);
			DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
		}
		DomainManager.Combat.ChangeBreathValue(context, base.CombatChar, 30000 * AddStanceAndBreathPercent);
		DomainManager.Combat.ChangeStanceValue(context, base.CombatChar, 4000 * AddStanceAndBreathPercent);
		ShowSpecialEffectTips(0);
	}
}

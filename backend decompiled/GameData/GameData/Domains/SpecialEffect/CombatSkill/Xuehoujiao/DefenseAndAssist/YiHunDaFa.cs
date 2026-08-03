using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class YiHunDaFa : DefenseSkillBase
{
	private const sbyte TransferInjury = 2;

	private const sbyte TransferQiDisorder = 15;

	public YiHunDaFa()
	{
	}

	public YiHunDaFa(CombatSkillKey skillKey)
		: base(skillKey, 15704)
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
		Injuries newInjuries = base.CombatChar.GetInjuries().Subtract(base.CombatChar.GetOldInjuries());
		List<sbyte> injuryRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		injuryRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			sbyte injury = newInjuries.Get(part, !base.IsDirect);
			for (int i = 0; i < injury; i++)
			{
				injuryRandomPool.Add(part);
			}
		}
		int transferInjury = Math.Min(2, injuryRandomPool.Count);
		for (int j = 0; j < transferInjury; j++)
		{
			int index = context.Random.Next(0, injuryRandomPool.Count);
			sbyte bodyPart = injuryRandomPool[index];
			base.CombatChar.RemoveInjury(context, bodyPart, !base.IsDirect, 1, updateDefeatMark: true, removeOldInjury: false, byTransfer: true);
			base.CurrEnemyChar.AddInjury(context, bodyPart, !base.IsDirect, 1, updateDefeatMark: true);
		}
		ObjectPool<List<sbyte>>.Instance.Return(injuryRandomPool);
		if (transferInjury > 0)
		{
			DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
			ShowSpecialEffectTips(0);
		}
		int transferQiDisorder = CharObj.GetDisorderOfQi() * 15 / 100;
		if (transferQiDisorder > 0)
		{
			DomainManager.Combat.TransferDisorderOfQi(context, base.CombatChar, base.CurrEnemyChar, transferQiDisorder);
			ShowSpecialEffectTips(1);
		}
	}
}

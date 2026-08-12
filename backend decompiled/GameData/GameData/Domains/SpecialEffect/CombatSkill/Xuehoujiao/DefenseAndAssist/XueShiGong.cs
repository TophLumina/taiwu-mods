using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class XueShiGong : AssistSkillBase
{
	private const sbyte RequireMarkCount = 1;

	private const sbyte RequireInjuryLevelMax = 4;

	public XueShiGong()
	{
	}

	public XueShiGong(CombatSkillKey skillKey)
		: base(skillKey, 15803)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		sbyte markCount = (base.IsDirect ? outerMarkCount : innerMarkCount);
		if (attackerId != base.CharacterId || markCount < 1 || !base.CanAffect)
		{
			return;
		}
		bool anyChanged = false;
		for (int i = 0; i < markCount; i++)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries newInjuries = injuries.Subtract(base.CombatChar.GetOldInjuries());
			if (!AnyValidInjuries(ref injuries, ref newInjuries))
			{
				break;
			}
			anyChanged = true;
			sbyte part = RandomUtils.GetRandomResult(InjuriesFilter(injuries, newInjuries), context.Random);
			base.CombatChar.RemoveInjury(context, part, !base.IsDirect);
		}
		if (anyChanged)
		{
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}

	private bool AnyValidInjuries(ref Injuries injuries, ref Injuries newInjuries)
	{
		for (sbyte part = 0; part < 7; part++)
		{
			sbyte level = injuries.Get(part, !base.IsDirect);
			if ((level <= 4 && level > 0) || 1 == 0)
			{
				sbyte newLevel = newInjuries.Get(part, !base.IsDirect);
				if (newLevel > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private IEnumerable<(sbyte, short)> InjuriesFilter(Injuries injuries, Injuries newInjuries)
	{
		for (sbyte part = 0; part < 7; part++)
		{
			sbyte level = injuries.Get(part, !base.IsDirect);
			if ((level <= 4 && level > 0) || 1 == 0)
			{
				sbyte newLevel = newInjuries.Get(part, !base.IsDirect);
				if (newLevel > 0)
				{
					yield return (part, newLevel);
				}
			}
		}
	}
}

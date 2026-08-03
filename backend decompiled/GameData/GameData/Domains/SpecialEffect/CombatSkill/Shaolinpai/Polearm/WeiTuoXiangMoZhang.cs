using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class WeiTuoXiangMoZhang : CombatSkillEffectBase
{
	public WeiTuoXiangMoZhang()
	{
	}

	public WeiTuoXiangMoZhang(CombatSkillKey skillKey)
		: base(skillKey, 1306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			Events.RegisterHandler_FlawAdded(OnFlawOrAcupointAdded);
		}
		else
		{
			Events.RegisterHandler_AcuPointAdded(OnFlawOrAcupointAdded);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_FlawAdded(OnFlawOrAcupointAdded);
		}
		else
		{
			Events.UnRegisterHandler_AcuPointAdded(OnFlawOrAcupointAdded);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnFlawOrAcupointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (!IsSrcSkillPerformed || combatChar != base.CombatChar)
		{
			return;
		}
		int addCount = Math.Min(level + 1, base.EffectCount);
		for (int i = 0; i < addCount; i++)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, 0, SkillKey, -1, 1, raiseEvent: false);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 0, SkillKey, -1, 1, raiseEvent: false);
			}
		}
		ReduceEffectCount(addCount);
		ShowSpecialEffectTipsOnceInFrame(0);
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}

using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class BaWangKaiGongShou : CombatSkillEffectBase
{
	public BaWangKaiGongShou()
	{
	}

	public BaWangKaiGongShou(CombatSkillKey skillKey)
		: base(skillKey, 6105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId && CombatCharPowerMatchAffectRequire() && damageValue > 0)
		{
			sbyte otherSidePart = ((!base.IsDirect) ? (bodyPart switch
			{
				6 => 5, 
				5 => 6, 
				_ => -1, 
			}) : (bodyPart switch
			{
				4 => 3, 
				3 => 4, 
				_ => -1, 
			}));
			if (otherSidePart >= 0)
			{
				DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.CurrEnemyChar, otherSidePart, (!isInner) ? damageValue : 0, isInner ? damageValue : 0, combatSkillId);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}

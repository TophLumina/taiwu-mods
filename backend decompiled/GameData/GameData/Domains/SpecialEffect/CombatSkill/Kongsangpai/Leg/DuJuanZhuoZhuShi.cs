using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class DuJuanZhuoZhuShi : CombatSkillEffectBase
{
	public DuJuanZhuoZhuShi()
	{
	}

	public DuJuanZhuoZhuShi(CombatSkillKey skillKey)
		: base(skillKey, 10302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId)
		{
			int acupointCount = (base.IsDirect ? outerMarkCount : innerMarkCount);
			if (acupointCount > 0)
			{
				DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 0, SkillKey, bodyPart, acupointCount);
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

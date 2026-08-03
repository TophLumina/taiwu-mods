using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class XiaoYuYangShenGong : CombatSkillEffectBase
{
	public XiaoYuYangShenGong()
	{
	}

	public XiaoYuYangShenGong(CombatSkillKey skillKey)
		: base(skillKey, 14003, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
	}

	private void OnAttackSkillAttackHit(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool critical)
	{
		if (critical && base.CharacterId == (base.IsDirect ? attacker.GetId() : defender.GetId()))
		{
			base.CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: true);
			base.CombatChar.RemoveRandomFlawOrAcupoint(context, isFlaw: false);
			base.CombatChar.RemoveMindMark(context, 1, random: true);
			ShowSpecialEffectTips(0);
		}
	}
}

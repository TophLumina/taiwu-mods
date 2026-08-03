using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class MeiRenCi : CombatSkillEffectBase
{
	public MeiRenCi()
	{
	}

	public MeiRenCi(CombatSkillKey skillKey)
		: base(skillKey, 2402, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index != 3 || context.SkillKey != SkillKey || !CombatCharPowerMatchAffectRequire())
		{
			return;
		}
		OuterAndInnerShorts enemyAttackRange = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetAttackRange();
		short currDist = DomainManager.Combat.GetCurrentDistance();
		if (base.IsDirect ? (currDist < enemyAttackRange.Inner) : (currDist > enemyAttackRange.Outer))
		{
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? (enemyAttackRange.Inner - currDist) : (enemyAttackRange.Outer - currDist));
			ShowSpecialEffectTips(0);
			DomainManager.Combat.SetDisplayPosition(context, base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
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

using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class GouLianJianFa : CombatSkillEffectBase
{
	private const sbyte StatePowerUnit = 25;

	private const sbyte ForceMoveDist = 20;

	public GouLianJianFa()
	{
	}

	public GouLianJianFa(CombatSkillKey skillKey)
		: base(skillKey, 12301, -1)
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
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, (short)(base.IsDirect ? 59 : 60), 25 * base.CombatChar.GetAttackSkillPower() / 10);
			DomainManager.Combat.ChangeDistance(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly), base.IsDirect ? 20 : (-20), isForced: true);
			ShowSpecialEffectTips(0);
			DomainManager.Combat.SetDisplayPosition(context, !base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(!base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
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

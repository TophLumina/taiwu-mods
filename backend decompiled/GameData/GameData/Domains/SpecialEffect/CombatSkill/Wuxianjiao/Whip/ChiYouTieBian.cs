using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;

public class ChiYouTieBian : AddWeaponEquipAttackOnAttack
{
	private const sbyte MoveDistance = 60;

	public ChiYouTieBian()
	{
	}

	public ChiYouTieBian(CombatSkillKey skillKey)
		: base(skillKey, 12404)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			ClearAffectingAgileSkill(context, enemyChar);
			ChangeMobilityValue(context, enemyChar, -enemyChar.GetMobilityValue());
			DomainManager.Combat.ChangeDistance(context, enemyChar, base.IsDirect ? 60 : (-60), isForced: true);
			ShowSpecialEffectTips(1);
			DomainManager.Combat.SetDisplayPosition(context, !base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(!base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
		}
	}
}

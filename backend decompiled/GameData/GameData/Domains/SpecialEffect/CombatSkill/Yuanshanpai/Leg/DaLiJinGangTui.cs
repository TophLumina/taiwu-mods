using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class DaLiJinGangTui : AddWeaponEquipAttackOnAttack
{
	private sbyte ChangeDistanceUnit = 5;

	private sbyte FlawLevel = 2;

	private sbyte FlawCount = 3;

	public DaLiJinGangTui()
	{
	}

	public DaLiJinGangTui(CombatSkillKey skillKey)
		: base(skillKey, 5104)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index != 3 || context.SkillKey != SkillKey || base.CombatChar.GetAttackSkillPower() <= 0)
		{
			return;
		}
		int changeDistance = ChangeDistanceUnit * base.CombatChar.GetAttackSkillPower() / 10;
		if (changeDistance > 0)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			(byte, byte) distanceRange = DomainManager.Combat.GetDistanceRange();
			DomainManager.Combat.ChangeDistance(context, enemyChar, base.IsDirect ? changeDistance : (-changeDistance), isForced: true);
			DomainManager.Combat.SetDisplayPosition(context, !base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(!base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
			if (DomainManager.Combat.GetCurrentDistance() == (base.IsDirect ? distanceRange.Item2 : distanceRange.Item1))
			{
				DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, FlawLevel, SkillKey, -1, FlawCount);
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
	}
}

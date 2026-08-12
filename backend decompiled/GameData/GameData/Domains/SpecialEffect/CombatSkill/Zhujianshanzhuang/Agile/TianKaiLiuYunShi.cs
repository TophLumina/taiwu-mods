using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class TianKaiLiuYunShi : BuffHitOrDebuffAvoid
{
	private const int ChangeEquipmentPowerUnit = 2;

	protected override sbyte AffectHitType => 0;

	public TianKaiLiuYunShi()
	{
	}

	public TianKaiLiuYunShi(CombatSkillKey skillKey)
		: base(skillKey, 9506)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
		base.OnDisable(context);
	}

	private void OnAttackSkillAttackHit(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool critical)
	{
		if (attacker.GetId() != base.CharacterId || index == 3)
		{
			return;
		}
		sbyte hitType = base.CombatChar.SkillHitType[index];
		if (hitType == AffectHitType)
		{
			int hit = DomainManager.CombatSkill.GetElement_CombatSkills((charId: attacker.GetId(), skillId: skillId)).GetHitDistribution()[hitType];
			if (hit > 0)
			{
				CombatCharacter affectChar = (base.IsDirect ? attacker : defender);
				DomainManager.Combat.ChangeEquipmentPowerInCombat(affectChar.GetId(), hit / 10 * 2 * (base.IsDirect ? 1 : (-1)));
				ShowSpecialEffectTips(1);
			}
		}
	}
}

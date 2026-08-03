using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class SangHunXi : DefenseSkillBase
{
	private const int AddPoison = 180;

	public SangHunXi()
	{
	}

	public SangHunXi(CombatSkillKey skillKey)
		: base(skillKey, 12705)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && hit && attacker == base.CombatChar && base.CanAffect)
		{
			int fightBackPower = base.CombatChar.GetFightBackPower(base.CombatChar.FightBackHitType);
			DomainManager.Combat.AddPoison(context, base.CombatChar, defender, (sbyte)(base.IsDirect ? 4 : 5), 2, 180 * fightBackPower / 100, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
	}
}

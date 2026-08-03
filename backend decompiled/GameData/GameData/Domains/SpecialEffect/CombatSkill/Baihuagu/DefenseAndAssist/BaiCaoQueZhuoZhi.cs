using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class BaiCaoQueZhuoZhi : AssistSkillBase
{
	private const sbyte AffectOdds = 30;

	public BaiCaoQueZhuoZhi()
	{
	}

	public BaiCaoQueZhuoZhi(CombatSkillKey skillKey)
		: base(skillKey, 3602)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && pursueIndex == 0 && attacker == base.CombatChar && base.CombatChar.GetChangeTrickAttack() && base.CanAffect && context.Random.CheckPercentProb(30) && (base.IsDirect ? base.CombatChar.RemoveRandomInjury(context) : base.CurrEnemyChar.WorsenRandomInjury(context)))
		{
			ShowSpecialEffectTips(0);
		}
	}
}

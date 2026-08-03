using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class ZhanYiShiBaDie : DefenseSkillBase
{
	private const sbyte AddStatePowerUnit = 50;

	public ZhanYiShiBaDie()
	{
	}

	public ZhanYiShiBaDie(CombatSkillKey skillKey)
		: base(skillKey, 1501)
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
		if (isFightBack && attacker == base.CombatChar && hit && base.CanAffect)
		{
			DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CombatChar : base.CurrEnemyChar, (sbyte)(base.IsDirect ? 1 : 2), (short)(base.IsDirect ? 11 : 12), 50);
			ShowSpecialEffectTips(0);
		}
	}
}

using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class QiXingFeiXuan : AgileSkillBase
{
	private const int SettlementAttackCount = 7;

	private static readonly CValuePercent AddFatalDamagePercent = 40;

	private int _attackCount;

	private int _catchingDamage;

	private bool IsAffectChar(CombatCharacter attacker)
	{
		return base.IsCurrent && (base.IsDirect ? (attacker.GetId() == base.CharacterId) : (attacker.IsAlly != base.CombatChar.IsAlly));
	}

	public QiXingFeiXuan()
	{
	}

	public QiXingFeiXuan(CombatSkillKey skillKey)
		: base(skillKey, 13406)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_AttackSkillAttackEndOfAll(OnAttackSkillAttackEndOfAll);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_AttackSkillAttackEndOfAll(OnAttackSkillAttackEndOfAll);
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (IsAffectChar(attacker) && base.CanAffect && !attacker.IsUnlockAttack)
		{
			DoSettlement(context);
		}
	}

	private void OnAttackSkillAttackEndOfAll(DataContext context, CombatCharacter character, int index)
	{
		if (IsAffectChar(character) && base.CanAffect)
		{
			DoSettlement(context);
		}
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId);
		if (IsAffectChar(attacker) && base.CanAffect && !attacker.IsUnlockAttack)
		{
			_catchingDamage += damageValue;
		}
	}

	private void DoSettlement(DataContext context)
	{
		_attackCount++;
		if (_attackCount >= 7)
		{
			base.CurrEnemyChar.AddFatalDamage(context, _catchingDamage * AddFatalDamagePercent, -1, -1, -1);
			_attackCount = (_catchingDamage = 0);
			ShowSpecialEffectTips(0);
		}
	}
}

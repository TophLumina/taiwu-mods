using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Common;

public abstract class NormalAttackAddOther : AutoCollectEffectBase
{
	protected NormalAttackAddOther(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		DoAffect(context, attackerId, defenderId, damageValue, combatSkillId);
	}

	private void DoAffect(DataContext context, int attackerId, int defenderId, int damageValue, short combatSkillId)
	{
		if (combatSkillId < 0 && DomainManager.Combat.TryGetElement_CombatCharacterDict(defenderId, out var defender))
		{
			CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
			int mainCharId = mainChar.GetId();
			if (mainCharId == attackerId)
			{
				DoAddDamage(context, defender, damageValue);
			}
		}
	}

	protected abstract void DoAddDamage(DataContext context, CombatCharacter defender, int damageValue);
}

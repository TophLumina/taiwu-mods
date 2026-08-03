using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.EquipmentMastery;

public abstract class MasteryWeaponBase : EquipmentMasteryBase
{
	protected sealed override EEquipmentMasteryType MasteryType => EEquipmentMasteryType.Weapon;

	protected virtual bool CheckAffectOdds => true;

	protected bool Affecting { get; private set; }

	protected MasteryWeaponBase()
	{
	}

	protected MasteryWeaponBase(int charId, int itemId, short specialEffectId)
		: base(charId, itemId, specialEffectId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		CheckAndSetAffecting(context, attacker, -1);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (Affecting && attacker.GetId() == base.CharacterId)
		{
			Affecting = false;
			OnAffectingChanged(context);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		CheckAndSetAffecting(context, attacker, skillId);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (Affecting && charId == base.CharacterId)
		{
			Affecting = false;
			OnAffectingChanged(context);
		}
	}

	private void CheckAndSetAffecting(DataContext context, CombatCharacter attacker, short skillId = -1)
	{
		if (attacker.GetId() == base.CharacterId && base.IsValid && (attacker.SkillUseLegAsWeapon(skillId) ? attacker.Armors[5] : DomainManager.Combat.GetUsingWeaponKey(attacker)).Id == ItemId)
		{
			Affecting = !CheckAffectOdds || CheckAffect(context.Random);
			if (Affecting)
			{
				OnAffectingChanged(context);
			}
		}
	}

	protected virtual void OnAffectingChanged(DataContext context)
	{
	}
}

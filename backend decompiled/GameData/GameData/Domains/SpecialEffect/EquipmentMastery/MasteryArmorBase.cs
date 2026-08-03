using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.EquipmentMastery;

public abstract class MasteryArmorBase : EquipmentMasteryBase
{
	protected sealed override EEquipmentMasteryType MasteryType => EEquipmentMasteryType.Armor;

	protected virtual bool CheckAffectOdds => true;

	protected bool Affecting { get; private set; }

	protected MasteryArmorBase()
	{
	}

	protected MasteryArmorBase(int charId, int itemId, short specialEffectId)
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
		CheckAndSetAffecting(context, attacker.NormalAttackBodyPart, defender);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (Affecting && defender.GetId() == base.CharacterId)
		{
			Affecting = false;
			OnAffectingChanged(context);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		CheckAndSetAffecting(context, attacker.SkillAttackBodyPart, defender);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (Affecting)
		{
			Affecting = false;
			OnAffectingChanged(context);
		}
	}

	private void CheckAndSetAffecting(DataContext context, sbyte bodyPart, CombatCharacter defender)
	{
		if (defender.GetId() != base.CharacterId || !base.IsValid || !defender.Armors.CheckIndex(bodyPart))
		{
			return;
		}
		ItemKey armorKey = defender.Armors[bodyPart];
		if (armorKey.Id == ItemId)
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

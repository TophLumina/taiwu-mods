using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class XianYuanShenJie : RawCreateEquipmentBase
{
	protected override int ReduceDurabilityValue => 8;

	public XianYuanShenJie()
	{
	}

	public XianYuanShenJie(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30204)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackCalcCriticalEnd(OnNormalAttackCalcCriticalEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcCriticalEnd(OnNormalAttackCalcCriticalEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcCriticalEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, bool critical)
	{
		if (attacker.GetId() == base.CharacterId && critical && base.CanAffect && attacker.PursueAttackCount <= 0 && !(attacker.IsUnlockAttack ? (attacker.UnlockWeapon.GetItemKey() != EquipItemKey) : (DomainManager.Combat.GetUsingWeaponKey(attacker) != EquipItemKey)))
		{
			sbyte level = (sbyte)context.Random.Next(0, 3);
			if (context.Random.CheckPercentProb(50))
			{
				DomainManager.Combat.AddFlaw(context, defender, level, CombatSkillKey.Invalid, -1);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, defender, level, CombatSkillKey.Invalid, -1);
			}
		}
	}
}

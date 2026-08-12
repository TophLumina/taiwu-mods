using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Protagonist;

public class PoE : EquipmentEffectBase
{
	private bool _invoked;

	public PoE()
	{
	}

	public PoE(int charId, ItemKey itemKey)
		: base(charId, itemKey, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
		base.OnDisable(context);
	}

	private void OnCombatCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar.GetId() == base.CharacterId && type == ECombatCharAboutToFallType.PoE && !_invoked && base.Durability > 0 && DomainManager.Combat.DefeatMarkReachFailCount(base.CombatChar) && base.EnemyChar.GetCharacter().Template.CanDefeat)
		{
			_invoked = true;
			ChangeDurability(context, base.CombatChar, EquipItemKey, -base.Durability);
			DoAffect(context);
		}
	}

	private void DoAffect(DataContext context)
	{
		DomainManager.Combat.RemoveAllFlaw(context, base.CombatChar);
		DomainManager.Combat.RemoveAllAcupoint(context, base.CombatChar);
		base.CombatChar.RemoveMindMark(context, int.MaxValue, random: false);
		base.CombatChar.RemoveAllFatalMark(context);
		base.CombatChar.SetInjuries(context, base.CombatChar.GetOldInjuries());
	}
}

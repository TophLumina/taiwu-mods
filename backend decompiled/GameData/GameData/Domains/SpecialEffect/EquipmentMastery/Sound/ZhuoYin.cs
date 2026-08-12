using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Sound;

public class ZhuoYin : MasteryWeaponBase
{
	public ZhuoYin()
	{
	}

	public ZhuoYin(int charId, int itemId)
		: base(charId, itemId, 1790)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddMindDamage(OnAddMindDamage);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddMindDamage(OnAddMindDamage);
		base.OnDisable(context);
	}

	private void OnAddMindDamage(DataContext context, int attackerId, int defenderId, int damageValue, int markCount, short combatSkillId)
	{
		if (base.Affecting && DomainManager.Combat.TryGetElement_CombatCharacterDict(defenderId, out var defender))
		{
			defender.AddFatalDamage(context, damageValue * MasteryConstants.PercentValue33, -1, -1, -1);
			ShowSpecialEffectTips(0);
		}
	}
}

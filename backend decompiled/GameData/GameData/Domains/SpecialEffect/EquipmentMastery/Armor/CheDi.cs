using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.EquipmentMastery.Armor;

public class CheDi : MasteryArmorBase
{
	public CheDi()
	{
	}

	public CheDi(int charId, int itemId)
		: base(charId, itemId, 1794)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_RecoverStance(OnRecoverStance);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_RecoverStance(OnRecoverStance);
		base.OnDisable(context);
	}

	private void OnRecoverStance(DataContext context, CombatCharacter combatChar, int addValue)
	{
		if (combatChar.GetId() == base.CharacterId && addValue > 0 && base.Affecting)
		{
			int mappingBreath = addValue * 30000 / 4000;
			ChangeBreathValue(context, combatChar, mappingBreath * MasteryConstants.PercentValue33);
			ShowSpecialEffectTips(0);
		}
	}
}

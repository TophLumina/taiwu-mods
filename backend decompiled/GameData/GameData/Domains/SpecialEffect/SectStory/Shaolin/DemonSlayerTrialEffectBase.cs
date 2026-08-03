using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public abstract class DemonSlayerTrialEffectBase : SpecialEffectBase
{
	protected DemonSlayerTrialEffectBase(int charId)
		: base(charId, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		DomainManager.SpecialEffect.Remove(context, Id);
	}
}

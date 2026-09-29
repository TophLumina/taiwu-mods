using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect;

public class AutoCollectEffectBase : SpecialEffectBase
{
	protected AutoCollectEffectBase()
	{
	}

	protected AutoCollectEffectBase(int charId)
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

	protected virtual void BeforeRemove(DataContext context)
	{
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		BeforeRemove(context);
		RemoveSelf(context);
	}
}

using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect;

public abstract class CombatStateEffectBase : AutoCollectEffectBase
{
	protected abstract short CombatStateId { get; }

	protected CombatStateEffectBase()
	{
	}

	protected CombatStateEffectBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 0, CombatStateId, 100, reverse: false, applyEffect: true, base.CharacterId);
	}
}

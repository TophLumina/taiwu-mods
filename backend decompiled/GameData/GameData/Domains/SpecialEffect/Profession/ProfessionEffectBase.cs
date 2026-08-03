using GameData.Common;

namespace GameData.Domains.SpecialEffect.Profession;

public abstract class ProfessionEffectBase : AutoCollectEffectBase
{
	protected abstract short CombatStateId { get; }

	protected ProfessionEffectBase()
	{
	}

	protected ProfessionEffectBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 0, CombatStateId, 100, reverse: false, applyEffect: true, base.CharacterId);
	}
}

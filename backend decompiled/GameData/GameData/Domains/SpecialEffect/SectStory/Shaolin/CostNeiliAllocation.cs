using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class CostNeiliAllocation : DemonSlayerTrialEffectBase
{
	private readonly int _costNeiliAllocationPercent;

	public CostNeiliAllocation(int charId, IReadOnlyList<int> parameters)
		: base(charId)
	{
		_costNeiliAllocationPercent = -parameters[0];
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
		base.CombatChar.ChangeAllNeiliAllocation(context, _costNeiliAllocationPercent, raiseEvent: false, applyChallengeModeQiDisorder: false);
	}
}

using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect;

public class FrameCounter
{
	private readonly IFrameCounterHandler _handler;

	private readonly int _period;

	private readonly int _counterType;

	private int _counter;

	public FrameCounter(IFrameCounterHandler handler, int period, int counterType = 0)
	{
		_handler = handler;
		_period = period;
		_counterType = counterType;
		Tester.Assert(_handler != null, "_handler != null");
	}

	public void Setup()
	{
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public void Close()
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() != _handler.CharacterId || DomainManager.Combat.Pause)
		{
			return;
		}
		if (_handler.IsOn(_counterType))
		{
			_counter++;
			if (_counter >= _period)
			{
				_counter = 0;
				_handler.OnProcess(context, _counterType);
			}
		}
		else
		{
			_counter = 0;
		}
	}
}

using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.SpecialEffect;

namespace GameData.Domains.Combat;

public class TeammateCommandInvokerCooldown : TeammateCommandInvokerBase, IFrameCounterHandler
{
	private readonly FrameCounter _coolingCounter;

	private bool _cooling;

	public int CharacterId => MainCharId;

	public TeammateCommandInvokerCooldown(int charId, int index)
		: base(charId, index)
	{
		_coolingCounter = new FrameCounter(this, base.CmdConfig.CooldownFrame);
	}

	public override void Setup()
	{
		_coolingCounter.Setup();
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void Close()
	{
		_coolingCounter.Close();
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar == base.MainChar && !TeammateCommandInvokerBase.CombatDomain.Pause && !_cooling)
		{
			_cooling = true;
			IntoCombat();
		}
	}

	public bool IsOn(int counterType)
	{
		return _cooling;
	}

	public void OnProcess(DataContext context, int counterType)
	{
		_cooling = false;
	}
}

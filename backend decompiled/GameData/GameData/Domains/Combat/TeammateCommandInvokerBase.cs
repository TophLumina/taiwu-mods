using Config;
using GameData.Common;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public abstract class TeammateCommandInvokerBase : ITeammateCommandInvoker
{
	protected readonly CombatCharacter CombatChar;

	protected readonly int MainCharId;

	private readonly int _index;

	private readonly sbyte _cmdType;

	protected static CombatDomain CombatDomain => DomainManager.Combat;

	protected string DataHandlerKey => $"{GetType().Name}{CombatChar.GetId()}";

	protected CombatCharacter MainChar => DomainManager.Combat.GetElement_CombatCharacterDict(MainCharId);

	protected TeammateCommandItem CmdConfig => TeammateCommand.Instance[_cmdType];

	protected TeammateCommandInvokerBase(int charId, int index)
	{
		CombatChar = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
		MainCharId = DomainManager.Combat.GetMainCharacter(CombatChar.IsAlly).GetId();
		Tester.Assert(MainCharId != charId, "MainCharId != charId");
		_index = index;
		_cmdType = CombatChar.GetCurrTeammateCommands()[index];
		Tester.Assert(CmdConfig != null, "CmdConfig != null");
	}

	public abstract void Setup();

	public abstract void Close();

	protected void Execute(DataContext context)
	{
		if (DomainManager.Combat.ExecuteTeammateCommand(context, CombatChar.IsAlly, _index, CombatChar.GetId()))
		{
			DomainManager.Combat.ShowTeammateCommand(CombatChar.GetId(), _index);
		}
	}

	protected void IntoCombat()
	{
		if (!CombatDomain.IsInCombat() || MainChar.HasDoingOrReserveCommand() || CombatChar.GetExecutingTeammateCommand() != _cmdType || CombatChar.ExecutingTeammateCommandConfig.IntoCombatField)
		{
			return;
		}
		bool isBefore = CombatChar.ExecutingTeammateCommandConfig.PosOffset > 0;
		if (!(isBefore ? (MainChar.TeammateBeforeMainChar >= 0) : (MainChar.TeammateAfterMainChar >= 0)))
		{
			if (isBefore)
			{
				MainChar.TeammateBeforeMainChar = CombatChar.GetId();
			}
			else
			{
				MainChar.TeammateAfterMainChar = CombatChar.GetId();
			}
			DataContext context = CombatDomain.Context;
			int displayPos = ((CombatChar.ExecutingTeammateCommandImplement.IsAttack() && CombatDomain.InAttackRange(CombatChar)) ? CombatDomain.GetDisplayPosition(CombatChar.IsAlly, CombatChar.GetNormalAttackPosition(CombatChar.GetAttackCommandTrickType())) : int.MinValue);
			CombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, displayPos);
			CombatChar.SetAnimationToLoop(CombatChar.GetIdleAni(), context);
			CombatChar.SetVisible(visible: true, context);
			CombatChar.SetTeammateCommandPreparePercent(0, context);
			MainChar.ActingTeammateCommandChar = CombatChar;
			MainChar.StateMachine.TranslateState(CombatCharacterStateType.TeammateCommand);
		}
	}
}

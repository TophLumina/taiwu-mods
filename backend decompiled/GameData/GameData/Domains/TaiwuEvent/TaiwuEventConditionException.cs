using System;

namespace GameData.Domains.TaiwuEvent;

public class TaiwuEventConditionException : Exception
{
	public TaiwuEventConditionException(string message, EventScriptId id, int line, EventCondition condition, Exception innerException)
		: base($"{message} at {id} line {line}.\n\n {condition.Instruction.InstructionStr}\n", innerException)
	{
	}

	public TaiwuEventConditionException(string message, EventScriptId id, int line, string instStr, Exception innerException)
		: base($"{message} at {id} line {line}.\n\n {instStr}\n", innerException)
	{
	}
}

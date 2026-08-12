using System;

namespace GameData.Domains.TaiwuEvent;

public class TaiwuEventScriptException : Exception
{
	public TaiwuEventScriptException(string message, EventScriptId id, int line, EventInstruction instruction, Exception innerException)
		: base($"{message} at {id} line {line}.\n\n {instruction.Instruction.InstructionStr}\n", innerException)
	{
	}

	public TaiwuEventScriptException(string message, EventScriptId id, int line, string instStr, Exception innerException)
		: base($"{message} at {id} line {line}.\n\n {instStr}\n", innerException)
	{
	}

	public TaiwuEventScriptException(string message, EventScriptId id, int line, Exception innerException)
		: base($"{message} at {id} line {line}.\n\n", innerException)
	{
	}
}

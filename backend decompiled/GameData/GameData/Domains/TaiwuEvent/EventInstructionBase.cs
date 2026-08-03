using CompDevLib.Interpreter;

namespace GameData.Domains.TaiwuEvent;

public class EventInstructionBase
{
	public readonly int Indent;

	public readonly int FunctionId;

	public readonly Instruction<EventScriptRuntime> Instruction;

	public EventInstructionBase(int functionId, Instruction<EventScriptRuntime> instruction, int indent)
	{
		FunctionId = functionId;
		Instruction = instruction;
		Indent = indent;
	}
}

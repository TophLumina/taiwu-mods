using CompDevLib.Interpreter;

namespace GameData.Domains.TaiwuEvent;

public class EventInstruction : EventInstructionBase
{
	public readonly string AssignToVar;

	public EventInstruction(int functionId, int indentAmount, string assignToVar, Instruction<EventScriptRuntime> instruction)
		: base(functionId, instruction, indentAmount)
	{
		AssignToVar = assignToVar;
	}
}

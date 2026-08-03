using CompDevLib.Interpreter;

namespace GameData.Domains.TaiwuEvent;

public class EventCondition : EventInstructionBase
{
	public readonly bool Reverse;

	public EventCondition(int functionId, Instruction<EventScriptRuntime> instruction, bool reverse, int indent)
		: base(functionId, instruction, indent)
	{
		Reverse = reverse;
	}

	public bool Check(EventScriptRuntime runtime)
	{
		return Reverse != Instruction.Execute<bool>(runtime);
	}
}

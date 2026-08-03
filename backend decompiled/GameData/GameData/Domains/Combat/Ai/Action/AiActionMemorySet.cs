using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemorySet)]
public class AiActionMemorySet : AiActionCommonBase
{
	private readonly string _key;

	private readonly CExpression _valueExpression;

	public AiActionMemorySet(IReadOnlyList<string> strings)
	{
		_key = strings[0];
		_valueExpression = CExpression.FromBase64(strings[1]);
	}

	public override void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		memory.Ints[_key] = _valueExpression.Calc(participant as IExpressionConverter);
	}
}

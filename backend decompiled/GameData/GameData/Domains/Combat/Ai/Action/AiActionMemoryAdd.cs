using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.MemoryAdd)]
public class AiActionMemoryAdd : AiActionCommonBase
{
	private readonly string _key;

	private readonly CExpression _valueExpression;

	public AiActionMemoryAdd(IReadOnlyList<string> strings)
	{
		_key = strings[0];
		_valueExpression = CExpression.FromBase64(strings[1]);
	}

	public override void Execute(AiMemoryNew memory, IAiParticipant participant)
	{
		memory.Ints[_key] = memory.Ints.GetOrDefault(_key) + _valueExpression.Calc(participant as IExpressionConverter);
	}
}

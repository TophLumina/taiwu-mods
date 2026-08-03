using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.MemoryEqual)]
public class AiConditionMemoryEqual : AiConditionCommonBase
{
	private readonly string _key;

	private readonly CExpression _valueExpression;

	public AiConditionMemoryEqual(IReadOnlyList<string> strings)
	{
		_key = strings[0];
		_valueExpression = CExpression.FromBase64(strings[1]);
	}

	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		int value;
		return memory.Ints.TryGetValue(_key, out value) && value == _valueExpression.Calc(participant as IExpressionConverter);
	}
}

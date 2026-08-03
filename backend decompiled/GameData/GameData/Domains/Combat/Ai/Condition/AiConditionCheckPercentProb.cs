using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CheckPercentProb)]
public class AiConditionCheckPercentProb : AiConditionCommonBase
{
	private readonly CExpression _expression;

	private readonly IRandomSource _randomSource;

	public AiConditionCheckPercentProb(IReadOnlyList<string> strings)
	{
		_expression = CExpression.FromBase64(strings[0]);
		_randomSource = RandomDefaults.CreateRandomSource();
	}

	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		int prob = _expression.Calc(participant as IExpressionConverter);
		return _randomSource.CheckPercentProb(prob);
	}
}

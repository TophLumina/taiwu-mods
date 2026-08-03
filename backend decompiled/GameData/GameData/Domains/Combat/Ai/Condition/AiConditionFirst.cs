using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.First)]
public class AiConditionFirst : AiConditionCommonBase
{
	public override bool Check(AiMemoryNew memory, IAiParticipant participant)
	{
		if (memory.Booleans.GetOrDefault(base.RuntimeIdStr))
		{
			return false;
		}
		memory.Booleans[base.RuntimeIdStr] = true;
		return true;
	}
}

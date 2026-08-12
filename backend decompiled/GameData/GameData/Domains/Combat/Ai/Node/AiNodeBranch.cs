using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Node;

[AiNode(EAiNodeType.Branch)]
public class AiNodeBranch : IAiNode
{
	private readonly IReadOnlyList<int> _ids;

	public int RuntimeId { get; set; }

	public bool IsAction => false;

	public AiNodeBranch(IReadOnlyList<int> ids)
	{
		_ids = ids;
		Tester.Assert(_ids.Count % 3 == 0);
	}

	public IEnumerable<int> Update(AiData data)
	{
		for (int i = 0; i < _ids.Count; i += 3)
		{
			int conditionId = _ids[i];
			int trueNodeId = _ids[i + 1];
			int falseNodeId = _ids[i + 2];
			if (data.CheckCondition(conditionId))
			{
				yield return trueNodeId;
			}
			else
			{
				yield return falseNodeId;
			}
		}
	}
}

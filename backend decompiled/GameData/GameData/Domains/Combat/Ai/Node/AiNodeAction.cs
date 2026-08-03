using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Node;

[AiNode(EAiNodeType.Action)]
public class AiNodeAction : IAiNode
{
	private readonly IReadOnlyList<int> _ids;

	public int RuntimeId { get; set; }

	public bool IsAction => true;

	public AiNodeAction(IReadOnlyList<int> ids)
	{
		_ids = ids;
	}

	public IEnumerable<int> Update(AiData data)
	{
		foreach (int actionId in _ids)
		{
			data.ExecuteAction(actionId);
		}
		yield break;
	}
}

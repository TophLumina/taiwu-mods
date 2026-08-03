using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Node;

[AiNode(EAiNodeType.Linear)]
public class AiNodeLinear : IAiNode
{
	private readonly IReadOnlyList<int> _ids;

	public int RuntimeId { get; set; }

	public bool IsAction => false;

	public AiNodeLinear(IReadOnlyList<int> ids)
	{
		_ids = ids;
	}

	public IEnumerable<int> Update(AiData data)
	{
		return _ids;
	}
}

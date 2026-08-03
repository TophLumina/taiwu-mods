using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Node;

[AiNode(EAiNodeType.Relay)]
public class AiNodeRelay : IAiNode
{
	private readonly IReadOnlyList<int> _ids;

	public int RuntimeId { get; set; }

	public bool IsAction => false;

	public AiNodeRelay(IReadOnlyList<int> ids)
	{
		_ids = ids;
		Tester.Assert(_ids.Count % 2 == 0);
	}

	public IEnumerable<int> Update(AiData data)
	{
		for (int i = 0; i < _ids.Count; i += 2)
		{
			int nextNodeId = _ids[i];
			int relayNodeId = _ids[i + 1];
			data.RelayEntry(relayNodeId);
			yield return nextNodeId;
		}
	}
}

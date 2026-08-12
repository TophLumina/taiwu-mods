using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai;

public interface IAiNode
{
	int RuntimeId { get; set; }

	bool IsAction { get; }

	IEnumerable<int> Update(AiData data);
}

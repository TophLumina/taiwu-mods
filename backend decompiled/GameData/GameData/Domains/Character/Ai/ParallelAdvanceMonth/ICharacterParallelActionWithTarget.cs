using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.Character.Ai.ParallelAdvanceMonth;

public interface ICharacterParallelActionWithTarget
{
	int BeginAreaId { get; }

	int EndAreaId { get; }

	bool IsEnabled => true;

	void Execute(DataContext context, Character character, HashSet<int> targetSet);
}

using System.Collections.Generic;
using GameData.Domains.Character.Ai.PrioritizedAction;

namespace GameData.Domains.Character.ParallelModifications;

public class PrioritizedActionModification
{
	public readonly Character Character;

	public BasePrioritizedAction Action = null;

	public bool IsNewAction = false;

	public List<short> FailToCreateActions = null;

	public PrioritizedActionModification(Character character)
	{
		Character = character;
	}
}

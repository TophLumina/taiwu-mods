using System.Collections.Generic;
using GameData.Domains.Character.Ai.GeneralAction;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthGeneralActionModification
{
	public Character Character;

	public List<(Character targetChar, IGeneralAction)> PerformedActions;

	public bool IsChanged => PerformedActions.Count > 0;

	public PeriAdvanceMonthGeneralActionModification(Character character)
	{
		Character = character;
		PerformedActions = new List<(Character, IGeneralAction)>();
	}
}

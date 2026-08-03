using System.Collections.Generic;
using GameData.Domains.Character.Ai.GeneralAction;
using GameData.Domains.Map;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthFixedActionModification
{
	public enum MakeLoveState
	{
		Legal,
		Illegal,
		Wug,
		RapeSucceed,
		RapeFail
	}

	public readonly Character Character;

	public List<(Character target, MakeLoveState makeLoveState, bool isPregnant, bool targetIsFather)> MakeLoveTargetList;

	public List<int> ReleaseKidnappedCharList;

	public List<MapBlockData> ModifiedMapBlocks;

	public bool LeaveGroup;

	public int NewGroupLeader;

	public short NewGroupActionTemplateId;

	public bool TravelTargetsChanged;

	public List<(Character targetChar, IGeneralAction)> PerformedActions;

	public bool IsChanged
	{
		get
		{
			int result;
			if (MakeLoveTargetList == null && ReleaseKidnappedCharList == null && ModifiedMapBlocks == null && !LeaveGroup && NewGroupLeader < 0)
			{
				List<(Character, IGeneralAction)> performedActions = PerformedActions;
				result = ((performedActions != null && performedActions.Count > 0) ? 1 : 0);
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public PeriAdvanceMonthFixedActionModification(Character character)
	{
		Character = character;
		NewGroupLeader = -1;
		NewGroupActionTemplateId = -1;
	}
}

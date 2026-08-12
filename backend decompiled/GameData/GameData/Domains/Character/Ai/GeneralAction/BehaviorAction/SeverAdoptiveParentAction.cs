using GameData.Common;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class SeverAdoptiveParentAction : IGeneralAction
{
	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return DomainManager.Character.HasRelation(selfChar.GetId(), targetChar.GetId(), 64);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfChar.GetId());
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetChar.GetId());
		Character.ApplyEndRelation_AdoptiveParent(context, selfChar, targetChar, selfChar.GetBehaviorType(), selfIsTaiwuPeople, targetIsTaiwuPeople);
	}
}

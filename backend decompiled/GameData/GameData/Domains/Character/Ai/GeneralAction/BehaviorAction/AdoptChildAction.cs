using GameData.Common;
using GameData.Domains.Character.Relation;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class AdoptChildAction : IGeneralAction
{
	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		RelatedCharacter selfToTarget = DomainManager.Character.GetRelation(selfChar.GetId(), targetChar.GetId());
		RelatedCharacter targetToSelf = DomainManager.Character.GetRelation(targetChar.GetId(), selfChar.GetId());
		return AiHelper.Relation.CanStartRelation_AdoptiveChild(selfChar.GetId(), selfToTarget, selfChar.GetCurrAge(), targetChar.GetId(), targetToSelf, targetChar.GetCurrAge());
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		ApplyChanges(context, selfChar, targetChar);
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		bool selfIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(selfChar.GetId());
		bool targetIsTaiwuPeople = DomainManager.Character.IsTaiwuPeople(targetChar.GetId());
		Character.ApplyAddRelation_AdoptiveChild(context, selfChar, targetChar, selfChar.GetBehaviorType(), selfIsTaiwuPeople, targetIsTaiwuPeople);
	}
}

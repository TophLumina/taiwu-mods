using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;

namespace GameData.Domains.Character.Ai.GeneralAction.BehaviorAction;

public class GainExpByCombatAction : IGeneralAction
{
	public CombatType CombatType;

	public sbyte ActionEnergyType => 3;

	public bool CheckValid(Character selfChar, Character targetChar)
	{
		return !selfChar.NeedToAvoidCombat(CombatType) && !targetChar.NeedToAvoidCombat(CombatType);
	}

	public void ApplyInitialChangesForTaiwu(DataContext context, Character selfChar, Character targetChar)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		switch (CombatType)
		{
		case CombatType.Play:
			monthlyEventCollection.AddRequestPlayCombat(selfCharId, location, targetCharId);
			break;
		case CombatType.Beat:
			monthlyEventCollection.AddRequestNormalCombat(selfCharId, location, targetCharId);
			break;
		}
		CharacterDomain.AddLockMovementCharSet(selfChar.GetId());
	}

	public void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (targetCharId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			DomainManager.Character.SimulateCharacterCombat(context, selfChar, targetChar, CombatType, isGroupCombat: false);
		}
	}
}

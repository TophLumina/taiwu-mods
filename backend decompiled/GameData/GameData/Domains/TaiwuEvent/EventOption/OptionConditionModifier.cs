using System;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.DisplayEvent;

namespace GameData.Domains.TaiwuEvent.EventOption;

public static class OptionConditionModifier
{
	public static void ModifyCondition(ref OptionAvailableInfoMinimumElement element, TaiwuEventOptionConditionBase condition, EventArgBox argBox)
	{
		switch (condition.Id)
		{
		case 19:
			if (condition is OptionConditionInt intCondition)
			{
				OptionConditionInt modifiedCondition2 = new OptionConditionInt(condition.Id, GetRealTeammateMax(intCondition.Arg), intCondition.ConditionChecker);
				element.Pass = modifiedCondition2.CheckCondition(argBox);
				ref short conditionId3 = ref element.ConditionId;
				ref string[] formatArgs = ref element.FormatArgs;
				(conditionId3, formatArgs) = modifiedCondition2.GetDisplayData(argBox);
			}
			break;
		case 6:
			if (condition is OptionConditionAreaSpiritualDebt areaSpiritualDebtCondition)
			{
				GameData.Domains.Character.Character character3 = argBox.GetCharacter();
				if (character3 == null)
				{
					throw new Exception("error:failed to get character from argBox when modify AreaSpiritualDebtMore");
				}
				short settlementId = character3.GetOrganizationInfo().SettlementId;
				if (settlementId < 0)
				{
					element.Hide = true;
					element.Pass = true;
					break;
				}
				short modifiedValue = DomainManager.Taiwu.GetSpiritualDebtFinalCost(settlementId, areaSpiritualDebtCondition.SpiritualDebtValue);
				OptionConditionAreaSpiritualDebt modifiedCondition4 = new OptionConditionAreaSpiritualDebt(condition.Id, modifiedValue, areaSpiritualDebtCondition.ConditionChecker);
				element.Pass = modifiedCondition4.CheckCondition(argBox);
				ref short conditionId5 = ref element.ConditionId;
				ref string[] formatArgs = ref element.FormatArgs;
				(conditionId5, formatArgs) = modifiedCondition4.GetDisplayData(argBox);
			}
			break;
		case 16:
			if (condition is OptionConditionAreaSpiritualDebtKey areaSpiritualDebtKeyCondition)
			{
				Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
				location = DomainManager.Map.GetBlock(location).GetRootBlock().GetLocation();
				short settlementId2 = DomainManager.Organization.GetSettlementByLocation(location).GetId();
				short modifiedValue2 = DomainManager.Taiwu.GetSpiritualDebtFinalCost(settlementId2, areaSpiritualDebtKeyCondition.SpiritualDebtValue);
				OptionConditionAreaSpiritualDebt modifiedCondition5 = new OptionConditionAreaSpiritualDebt(condition.Id, modifiedValue2, areaSpiritualDebtKeyCondition.ConditionChecker);
				element.Pass = modifiedCondition5.CheckCondition(settlementId2);
				ref short conditionId6 = ref element.ConditionId;
				ref string[] formatArgs = ref element.FormatArgs;
				(conditionId6, formatArgs) = modifiedCondition5.GetDisplayData(settlementId2);
			}
			break;
		case 37:
			if (condition is OptionConditionInt { ConditionChecker: var conditionChecker })
			{
				GameData.Domains.Character.Character character2 = argBox.GetCharacter();
				int value = ProfessionSkillHandle.TravelingTaoistMonkSkill1_ExpCost(character2);
				OptionConditionInt modifiedCondition3 = new OptionConditionInt(condition.Id, value, conditionChecker);
				element.Pass = modifiedCondition3.CheckCondition(argBox);
				ref short conditionId4 = ref element.ConditionId;
				ref string[] formatArgs = ref element.FormatArgs;
				(conditionId4, formatArgs) = modifiedCondition3.GetDisplayData(argBox);
			}
			break;
		case 67:
			if (condition is OptionConditionCharacterValue cCondition)
			{
				GameData.Domains.Character.Character character = argBox.GetCharacter();
				int requirement = DomainManager.Extra.GetCharacterMinimumExtraLegacyPoints(character);
				OptionConditionCharacterValue modifiedCondition = new OptionConditionCharacterValue(condition.Id, requirement, cCondition.ConditionChecker);
				element.Pass = modifiedCondition.CheckCondition(argBox);
				ref short conditionId2 = ref element.ConditionId;
				ref string[] formatArgs = ref element.FormatArgs;
				(conditionId2, formatArgs) = modifiedCondition.GetDisplayData(argBox);
			}
			break;
		default:
		{
			element.Pass = condition.CheckCondition(argBox);
			ref short conditionId = ref element.ConditionId;
			ref string[] formatArgs = ref element.FormatArgs;
			(conditionId, formatArgs) = condition.GetDisplayData(argBox);
			break;
		}
		}
	}

	private static int GetRealTeammateMax(int srcTeammateMax)
	{
		return DomainManager.Taiwu.GetTaiwuGroupMaxCount();
	}
}

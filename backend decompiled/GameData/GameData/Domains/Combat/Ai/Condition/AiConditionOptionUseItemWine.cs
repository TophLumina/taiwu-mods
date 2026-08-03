using GameData.Domains.Character;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemWine)]
public class AiConditionOptionUseItemWine : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemWine()
		: base(EItemSelectorType.Wine)
	{
	}

	protected override bool ExtraCheck(CombatCharacter combatChar)
	{
		GameData.Domains.Character.Character charObj = combatChar.GetCharacter();
		if (charObj.IsForbiddenToDrinkingWines())
		{
			return false;
		}
		return charObj.GetAgeGroup() == 2;
	}
}

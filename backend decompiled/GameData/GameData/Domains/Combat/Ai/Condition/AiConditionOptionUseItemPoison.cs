using Config;
using GameData.Domains.Character;
using GameData.Domains.Combat.Ai.Selector;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionUseItemPoison)]
public class AiConditionOptionUseItemPoison : AiConditionOptionUseItemCommonBase
{
	public AiConditionOptionUseItemPoison()
		: base(EItemSelectorType.ThrowPoison)
	{
	}

	protected override bool ExtraCheck(CombatCharacter combatChar)
	{
		GameData.Domains.Character.Character character = combatChar.GetCharacter();
		return Config.Organization.Instance[character.GetOrganizationInfo().OrgTemplateId].AllowPoisoning;
	}
}

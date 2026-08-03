using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CheckBanFlee)]
public class AiConditionCheckBanFlee : AiConditionCombatBase
{
	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.IsMainCharacter(combatChar))
		{
			return true;
		}
		if (!Config.Character.Instance[combatChar.GetCharacter().GetTemplateId()].AllowEscape)
		{
			return true;
		}
		if (combatChar.GetCharacter().GetXiangshuType() == 1)
		{
			return true;
		}
		if (!DomainManager.Combat.CanFlee(combatChar.IsAlly))
		{
			return true;
		}
		sbyte firm = combatChar.GetPersonalityValue(4);
		return DomainManager.Combat.Context.Random.CheckPercentProb(30 + 60 * firm / 100);
	}
}

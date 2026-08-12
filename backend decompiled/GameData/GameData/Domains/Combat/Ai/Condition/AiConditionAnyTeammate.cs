using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.AnyTeammate)]
public class AiConditionAnyTeammate : AiConditionCheckCharBase
{
	public AiConditionAnyTeammate(IReadOnlyList<int> ints)
		: base(ints)
	{
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		int[] characterList = DomainManager.Combat.GetCharacterList(checkChar.IsAlly);
		foreach (int charId in characterList)
		{
			if (charId >= 0 && charId != checkChar.GetId())
			{
				return true;
			}
		}
		return false;
	}
}

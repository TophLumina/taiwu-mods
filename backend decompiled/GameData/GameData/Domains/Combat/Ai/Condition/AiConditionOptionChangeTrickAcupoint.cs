using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeTrickAcupoint)]
public class AiConditionOptionChangeTrickAcupoint : AiConditionCombatBase
{
	private readonly sbyte _bodyPart;

	public AiConditionOptionChangeTrickAcupoint(IReadOnlyList<int> ints)
	{
		_bodyPart = (sbyte)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoAttack))
		{
			return false;
		}
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoChangeTrick))
		{
			return false;
		}
		if (!DomainManager.Combat.CanNormalAttack(combatChar.IsAlly) || !combatChar.GetCanChangeTrick())
		{
			return false;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!combatChar.IsAlly);
		if (enemyChar.GetAcupointCount()[_bodyPart] >= enemyChar.GetMaxAcupointCount())
		{
			return false;
		}
		if (!enemyChar.ContainsBodyPart(_bodyPart))
		{
			return false;
		}
		int costChangeTrickCount = CFormulaHelper.CalcCostChangeTrickCount(combatChar, EFlawOrAcupointType.Acupoint);
		return combatChar.GetChangeTrickCount() >= costChangeTrickCount;
	}
}

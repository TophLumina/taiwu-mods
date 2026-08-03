using System.Linq;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionChangeTrickNeiliType)]
public class AiConditionOptionChangeTrickNeiliType : AiConditionCombatBase
{
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
		return combatChar.GetSkillEffectCollection().EffectDict?.Keys.Any((SkillEffectKey x) => x.EffectConfig.TransferProportion > 0) ?? false;
	}
}

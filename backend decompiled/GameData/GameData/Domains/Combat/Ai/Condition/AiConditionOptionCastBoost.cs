using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.SpecialEffect;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionCastBoost)]
public class AiConditionOptionCastBoost : AiConditionCombatBase
{
	private readonly List<CastBoostEffectDisplayData> _costNeiliEffect = new List<CastBoostEffectDisplayData>();

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (!combatChar.AiCanOperate(DomainManager.Combat.AiOptions.AutoCostNeiliAllocation))
		{
			return false;
		}
		DataContext context = DomainManager.Combat.Context;
		short skillId = combatChar.GetPreparingSkillId();
		_costNeiliEffect.Clear();
		DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), skillId, 235, _costNeiliEffect);
		return _costNeiliEffect.Any((CastBoostEffectDisplayData data) => AiCastBoost(context.Random, combatChar, data));
	}

	private static bool AiCastBoost(IRandomSource random, CombatCharacter combatChar, CastBoostEffectDisplayData data)
	{
		SpecialEffectItem config = Config.SpecialEffect.Instance[data.EffectId];
		if (config.AiCostNeiliAllocationType == ESpecialEffectAiCostNeiliAllocationType.None)
		{
			return false;
		}
		if (config.AiCostNeiliAllocationType == ESpecialEffectAiCostNeiliAllocationType.Always)
		{
			return true;
		}
		byte type = data.NeiliAllocationType;
		NeiliAllocation current = combatChar.GetNeiliAllocation();
		NeiliAllocation origin = combatChar.GetOriginNeiliAllocation();
		if (current[type] <= origin[type] * 50 / 100)
		{
			return false;
		}
		ESpecialEffectAiCostNeiliAllocationType aiCostNeiliAllocationType = config.AiCostNeiliAllocationType;
		if (1 == 0)
		{
		}
		bool result = aiCostNeiliAllocationType switch
		{
			ESpecialEffectAiCostNeiliAllocationType.OnlyClever => CheckClever(random, combatChar), 
			ESpecialEffectAiCostNeiliAllocationType.CheckRange => combatChar.AiCastCheckRange(), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static bool CheckClever(IRandomSource random, CombatCharacter combatChar)
	{
		sbyte clever = combatChar.GetCharacter().GetPersonality(1);
		return random.CheckPercentProb(50 + 50 * clever / 100);
	}
}

using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.SpecialEffect;

namespace GameData.Domains.Combat.Ai.Action;

[AiAction(EAiActionType.CastSkillCastBoost)]
public class AiActionCastSkillCastBoost : AiActionCombatBase
{
	private readonly List<CastBoostEffectDisplayData> _costNeiliEffect = new List<CastBoostEffectDisplayData>();

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		short skillId = combatChar.GetPreparingSkillId();
		_costNeiliEffect.Clear();
		DomainManager.SpecialEffect.ModifyData(combatChar.GetId(), skillId, 235, _costNeiliEffect);
		foreach (CastBoostEffectDisplayData data in _costNeiliEffect)
		{
			if (AiCastBoost(combatChar, data))
			{
				DomainManager.SpecialEffect.CostNeiliEffect(context, combatChar.GetId(), skillId, (short)data.EffectId);
			}
		}
	}

	private static bool AiCastBoost(CombatCharacter combatChar, CastBoostEffectDisplayData data)
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
			ESpecialEffectAiCostNeiliAllocationType.OnlyClever => true, 
			ESpecialEffectAiCostNeiliAllocationType.CheckRange => combatChar.AiCastCheckRange(), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}

using System.Collections.Generic;
using GameData.Common;
using Redzen.Random;

namespace GameData.Domains.Combat.Ai.Action;

public abstract class AiActionChangeTrickBase : AiActionCombatBase
{
	private readonly string _key;

	protected virtual EFlawOrAcupointType ChangeTrickType => EFlawOrAcupointType.None;

	protected virtual sbyte GetTargetBodyPart(IRandomSource random, sbyte trickType, CombatCharacter combatChar)
	{
		return -1;
	}

	protected AiActionChangeTrickBase(IReadOnlyList<string> strings)
	{
		_key = strings[0];
	}

	public override void Execute(AiMemoryNew memory, CombatCharacter combatChar)
	{
		DataContext context = DomainManager.Combat.Context;
		short skillId = (short)memory.Ints.GetValueOrDefault(_key, -1);
		DomainManager.Combat.StartChangeTrick(context, combatChar.IsAlly);
		sbyte trickType = combatChar.AiGetCombatSkillRequireTrickType(skillId);
		trickType = ((trickType < 0) ? combatChar.GetOrRandomChangeTrickType(context.Random) : trickType);
		sbyte bodyPart = GetTargetBodyPart(context.Random, trickType, combatChar);
		bodyPart = ((bodyPart < 0) ? combatChar.RandomChangeTrickBodyPart(context.Random, trickType, skillId) : bodyPart);
		DomainManager.Combat.SelectChangeTrick(context, trickType, bodyPart, combatChar.IsAlly, ChangeTrickType);
	}
}

using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.OptionTeammateCommand)]
public class AiConditionOptionTeammateCommand : AiConditionCombatBase
{
	private readonly ETeammateCommandImplement _implement;

	public AiConditionOptionTeammateCommand(IReadOnlyList<int> ints)
	{
		_implement = (ETeammateCommandImplement)ints[0];
	}

	public override bool Check(AiMemoryNew memory, CombatCharacter combatChar)
	{
		if (combatChar.GetShowTransferInjuryCommand() && _implement != ETeammateCommandImplement.TransferInjury)
		{
			return false;
		}
		bool[] allowAutoUse = DomainManager.Combat.AiOptions.AutoUseTeammateCommand;
		ETeammateCommandOption option = CombatDomain.TeammateCommandOptions.GetValueOrDefault(_implement, ETeammateCommandOption.Invalid);
		if (!combatChar.AiCanOperate(allowAutoUse.CheckIndex((int)option) && allowAutoUse[(int)option]))
		{
			return false;
		}
		foreach (CombatCharacter teammate in DomainManager.Combat.GetTeammateCharacters(combatChar.GetId()))
		{
			List<sbyte> cmdTypes = teammate.GetCurrTeammateCommands();
			List<bool> cmdCanUse = teammate.GetTeammateCommandCanUse();
			for (int i = 0; i < cmdTypes.Count; i++)
			{
				if (cmdCanUse.CheckIndex(i) && cmdCanUse[i] && (combatChar.GetShowTransferInjuryCommand() || IsMatch(cmdTypes[i])))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool IsMatch(sbyte cmdType)
	{
		return TeammateCommand.Instance[cmdType].Implement == _implement;
	}
}

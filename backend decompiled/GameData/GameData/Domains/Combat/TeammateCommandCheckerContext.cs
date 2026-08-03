using System.Collections.Generic;
using Config;

namespace GameData.Domains.Combat;

public struct TeammateCommandCheckerContext
{
	public CombatCharacter CurrChar;

	public CombatCharacter TeammateChar;

	private bool _extraHasTeammateBefore;

	private bool _extraHasTeammateAfter;

	public IReadOnlyList<CountdownData> CdData => TeammateChar.GetTeammateCommandCd();

	public bool HasTeammateBefore => CurrChar.TeammateBeforeMainChar >= 0 || _extraHasTeammateBefore;

	public bool HasTeammateAfter => CurrChar.TeammateAfterMainChar >= 0 || _extraHasTeammateAfter;

	public void InitExtraFields()
	{
		int[] charList = DomainManager.Combat.GetCharacterList(TeammateChar.IsAlly);
		for (int i = 0; i < CurrChar.TeammateHasCommand.Length; i++)
		{
			if (!CurrChar.TeammateHasCommand[i])
			{
				continue;
			}
			TeammateCommandItem cmdConfig = DomainManager.Combat.GetElement_CombatCharacterDict(charList[i + 1]).ExecutingTeammateCommandConfig;
			if (cmdConfig.IntoCombatField)
			{
				if (cmdConfig.PosOffset > 0)
				{
					_extraHasTeammateBefore = true;
				}
				else
				{
					_extraHasTeammateAfter = true;
				}
			}
		}
	}
}

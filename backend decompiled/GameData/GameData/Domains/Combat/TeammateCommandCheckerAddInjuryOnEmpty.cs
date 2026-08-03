using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAddInjuryOnEmpty : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!context.CurrChar.IsAlly);
		Injuries injuries = enemyChar.GetInjuries();
		for (sbyte i = 0; i < 7; i++)
		{
			var (outer, inner) = injuries.Get(i);
			if (outer == 0 || inner == 0)
			{
				yield break;
			}
		}
		yield return ETeammateCommandBanReason.EnemyAllBodyPartInjured;
	}
}

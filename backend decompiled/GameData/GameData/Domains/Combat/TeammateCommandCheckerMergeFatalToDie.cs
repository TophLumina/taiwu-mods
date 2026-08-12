using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerMergeFatalToDie : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetDefeatMarkCollection().FatalDamageMarkCount <= 0)
		{
			yield return ETeammateCommandBanReason.MergeFatalToDieNoFatal;
		}
	}
}

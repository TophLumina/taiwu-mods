using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAnimalEffect : TeammateCommandCheckerBase
{
	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.TeammateChar.AnimalConfig == null || context.TeammateChar.AnimalConfig.CarrierId < 0)
		{
			yield return ETeammateCommandBanReason.Internal;
		}
	}
}

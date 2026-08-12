using System.Collections.Generic;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerAccelerateCast : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		if (context.CurrChar.GetPreparingSkillId() < 0 || context.CurrChar.GetSkillPreparePercent() >= 100)
		{
			yield return ETeammateCommandBanReason.AccelerateNotPreparing;
		}
	}
}

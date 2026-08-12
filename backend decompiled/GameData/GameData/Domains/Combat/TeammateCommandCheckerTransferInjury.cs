using System;
using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerTransferInjury : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBefore => true;

	public override IEnumerable<ETeammateCommandBanReason> Check(int index, TeammateCommandCheckerContext context)
	{
		if (index != 0)
		{
			yield return ETeammateCommandBanReason.Internal;
			yield break;
		}
		foreach (ETeammateCommandBanReason item in base.Check(index, context))
		{
			yield return item;
		}
	}

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		DefeatMarkCollection defeatMarkCollection = context.CurrChar.GetDefeatMarkCollection();
		if (defeatMarkCollection.FatalDamageMarkCount > 0)
		{
			yield break;
		}
		Injuries mainCharInjuries = context.CurrChar.GetInjuries();
		Injuries teammateInjuries = context.TeammateChar.GetInjuries();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte mainCharInjuryCount = mainCharInjuries.Get(bodyPart, context.CurrChar.TransferInjuryCommandIsInner);
			sbyte teammateCharInjuryCount = teammateInjuries.Get(bodyPart, context.CurrChar.TransferInjuryCommandIsInner);
			if (Math.Min(mainCharInjuryCount, 6 - teammateCharInjuryCount) > 0)
			{
				yield break;
			}
		}
		yield return ETeammateCommandBanReason.TransferInjuryNonInjury;
	}
}

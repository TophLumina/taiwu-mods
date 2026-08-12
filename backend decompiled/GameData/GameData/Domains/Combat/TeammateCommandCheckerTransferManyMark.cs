using System.Collections.Generic;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerTransferManyMark : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateBefore => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		int newDisorderOfQi = context.CurrChar.GetCharacter().GetDisorderOfQi() - context.CurrChar.GetOldDisorderOfQi();
		if (newDisorderOfQi > 0 && context.TeammateChar.GetCharacter().GetDisorderOfQi() < DisorderLevelOfQi.MaxValue)
		{
			yield break;
		}
		PoisonInts oldPoison = context.CurrChar.GetOldPoison();
		PoisonInts newPoison = context.CurrChar.GetPoison().Subtract(ref oldPoison);
		PoisonInts teammatePoisons = context.TeammateChar.GetPoison();
		for (int i = 0; i < 6; i++)
		{
			if (newPoison[i] > 0 && teammatePoisons[i] < 25000)
			{
				yield break;
			}
		}
		Injuries newInjuries = context.CurrChar.GetInjuries().Subtract(context.CurrChar.GetOldInjuries());
		Injuries teammateInjuries = context.TeammateChar.GetInjuries();
		for (sbyte i2 = 0; i2 < 7; i2++)
		{
			var (newOuter, newInner) = newInjuries.Get(i2);
			var (outer, inner) = teammateInjuries.Get(i2);
			if ((newOuter > 0 && outer < 6) || (newInner > 0 && inner < 6))
			{
				yield break;
			}
		}
		yield return ETeammateCommandBanReason.TransferManyMarkNonAnyMark;
	}
}

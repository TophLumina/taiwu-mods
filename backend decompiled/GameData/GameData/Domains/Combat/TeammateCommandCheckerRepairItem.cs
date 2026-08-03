using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public class TeammateCommandCheckerRepairItem : TeammateCommandCheckerBase
{
	protected override bool CheckTeammateAfter => true;

	protected override IEnumerable<ETeammateCommandBanReason> Extra(TeammateCommandCheckerContext context)
	{
		ItemKey[] equipment = context.CurrChar.GetCharacter().GetEquipment();
		foreach (ItemKey equipKey in equipment)
		{
			if (context.TeammateChar.CalcTeammateCommandRepairDurabilityValue(equipKey) > 0)
			{
				yield break;
			}
		}
		yield return ETeammateCommandBanReason.RepairItemNonAnyRepairable;
	}
}

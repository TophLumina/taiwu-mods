using System.Collections.Generic;
using System.Linq;

namespace GameData.Domains.Organization;

public static class SettlementPrisonHelper
{
	public static PrisonType GetPrisonType(this SettlementPrisoner prisoner)
	{
		if (!DomainManager.Character.TryGetElement_Objects(prisoner.CharId, out var character))
		{
			return PrisonType.Invalid;
		}
		if (character.IsCompletelyInfected())
		{
			return PrisonType.Infected;
		}
		if (prisoner.PunishmentSeverity == 0)
		{
			return PrisonType.Invalid;
		}
		if (prisoner.PunishmentType == 40)
		{
			return PrisonType.Infected;
		}
		return (PrisonType)(character.GetOrganizationInfo().Grade / 3);
	}

	public static IEnumerable<SettlementPrisoner> GetPrisonLow(this SettlementPrison prison)
	{
		return prison.Prisoners.Where((SettlementPrisoner x) => x.GetPrisonType() == PrisonType.Low);
	}

	public static IEnumerable<SettlementPrisoner> GetPrisonMid(this SettlementPrison prison)
	{
		return prison.Prisoners.Where((SettlementPrisoner x) => x.GetPrisonType() == PrisonType.Mid);
	}

	public static IEnumerable<SettlementPrisoner> GetPrisonHigh(this SettlementPrison prison)
	{
		return prison.Prisoners.Where((SettlementPrisoner x) => x.GetPrisonType() == PrisonType.High);
	}

	public static IEnumerable<SettlementPrisoner> GetPrisonInfected(this SettlementPrison prison)
	{
		return prison.Prisoners.Where((SettlementPrisoner x) => x.GetPrisonType() == PrisonType.Infected);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementTreasuryEventEffectItem : ConfigItem<SettlementTreasuryEventEffectItem, short>
{
	public readonly short TemplateId;

	public readonly int ChangeFavorGuardBaseRate;

	public readonly int ChangeFavorGuardFactor;

	public readonly int MinAffectedGuardCount;

	public readonly int GuardBaseFavorChange;

	public readonly int GuardFavorChangeFactor;

	public readonly int GuardDisapproveRate;

	public readonly int GuardApproveRate;

	public readonly int GuardBecomeEnemyRate;

	public readonly int ChangeFavorMemberBaseRate;

	public readonly int ChangeFavorMemberFactor;

	public readonly int MinAffectedMemberCount;

	public readonly int MemberBaseFavorChange;

	public readonly int MemberFavorChangeFactor;

	public readonly int MemberDisapproveRate;

	public readonly int MemberApproveRate;

	public readonly int MemberBecomeEnemyRate;

	public readonly int BaseSpiritualDebtChange;

	public readonly int SpiritualDebtChangeFactor;

	public readonly short TaiwuBounty;

	public readonly sbyte AlterTime;

	public SettlementTreasuryEventEffectItem(short templateId, int changeFavorGuardBaseRate, int changeFavorGuardFactor, int minAffectedGuardCount, int guardBaseFavorChange, int guardFavorChangeFactor, int guardDisapproveRate, int guardApproveRate, int guardBecomeEnemyRate, int changeFavorMemberBaseRate, int changeFavorMemberFactor, int minAffectedMemberCount, int memberBaseFavorChange, int memberFavorChangeFactor, int memberDisapproveRate, int memberApproveRate, int memberBecomeEnemyRate, int baseSpiritualDebtChange, int spiritualDebtChangeFactor, short taiwuBounty, sbyte alterTime)
	{
		TemplateId = templateId;
		ChangeFavorGuardBaseRate = changeFavorGuardBaseRate;
		ChangeFavorGuardFactor = changeFavorGuardFactor;
		MinAffectedGuardCount = minAffectedGuardCount;
		GuardBaseFavorChange = guardBaseFavorChange;
		GuardFavorChangeFactor = guardFavorChangeFactor;
		GuardDisapproveRate = guardDisapproveRate;
		GuardApproveRate = guardApproveRate;
		GuardBecomeEnemyRate = guardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = changeFavorMemberBaseRate;
		ChangeFavorMemberFactor = changeFavorMemberFactor;
		MinAffectedMemberCount = minAffectedMemberCount;
		MemberBaseFavorChange = memberBaseFavorChange;
		MemberFavorChangeFactor = memberFavorChangeFactor;
		MemberDisapproveRate = memberDisapproveRate;
		MemberApproveRate = memberApproveRate;
		MemberBecomeEnemyRate = memberBecomeEnemyRate;
		BaseSpiritualDebtChange = baseSpiritualDebtChange;
		SpiritualDebtChangeFactor = spiritualDebtChangeFactor;
		TaiwuBounty = taiwuBounty;
		AlterTime = alterTime;
	}

	public SettlementTreasuryEventEffectItem()
	{
		TemplateId = 0;
		ChangeFavorGuardBaseRate = 0;
		ChangeFavorGuardFactor = 0;
		MinAffectedGuardCount = 0;
		GuardBaseFavorChange = 0;
		GuardFavorChangeFactor = 0;
		GuardDisapproveRate = 0;
		GuardApproveRate = 0;
		GuardBecomeEnemyRate = 0;
		ChangeFavorMemberBaseRate = 0;
		ChangeFavorMemberFactor = 0;
		MinAffectedMemberCount = 0;
		MemberBaseFavorChange = 0;
		MemberFavorChangeFactor = 0;
		MemberDisapproveRate = 0;
		MemberApproveRate = 0;
		MemberBecomeEnemyRate = 0;
		BaseSpiritualDebtChange = 0;
		SpiritualDebtChangeFactor = 0;
		TaiwuBounty = 0;
		AlterTime = 0;
	}

	public SettlementTreasuryEventEffectItem(short templateId, SettlementTreasuryEventEffectItem other)
	{
		TemplateId = templateId;
		ChangeFavorGuardBaseRate = other.ChangeFavorGuardBaseRate;
		ChangeFavorGuardFactor = other.ChangeFavorGuardFactor;
		MinAffectedGuardCount = other.MinAffectedGuardCount;
		GuardBaseFavorChange = other.GuardBaseFavorChange;
		GuardFavorChangeFactor = other.GuardFavorChangeFactor;
		GuardDisapproveRate = other.GuardDisapproveRate;
		GuardApproveRate = other.GuardApproveRate;
		GuardBecomeEnemyRate = other.GuardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = other.ChangeFavorMemberBaseRate;
		ChangeFavorMemberFactor = other.ChangeFavorMemberFactor;
		MinAffectedMemberCount = other.MinAffectedMemberCount;
		MemberBaseFavorChange = other.MemberBaseFavorChange;
		MemberFavorChangeFactor = other.MemberFavorChangeFactor;
		MemberDisapproveRate = other.MemberDisapproveRate;
		MemberApproveRate = other.MemberApproveRate;
		MemberBecomeEnemyRate = other.MemberBecomeEnemyRate;
		BaseSpiritualDebtChange = other.BaseSpiritualDebtChange;
		SpiritualDebtChangeFactor = other.SpiritualDebtChangeFactor;
		TaiwuBounty = other.TaiwuBounty;
		AlterTime = other.AlterTime;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SettlementTreasuryEventEffectItem Duplicate(int templateId)
	{
		return new SettlementTreasuryEventEffectItem((short)templateId, this);
	}
}

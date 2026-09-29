using System;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementPrisonEventEffectItem : ConfigItem<SettlementPrisonEventEffectItem, short>
{
	public readonly short TemplateId;

	public readonly int ChangeFavorTeammate;

	public readonly int ChangeFavorCaptor;

	public readonly int ChangeFavorGuardBaseRate;

	public readonly int MinAffectedGuardCount;

	public readonly int GuardBaseFavorChange;

	public readonly int GuardDisapproveRate;

	public readonly int GuardApproveRate;

	public readonly int GuardBecomeEnemyRate;

	public readonly int ChangeFavorMemberBaseRate;

	public readonly int MinAffectedMemberCount;

	public readonly int MemberBaseFavorChange;

	public readonly int MemberDisapproveRate;

	public readonly int MemberApproveRate;

	public readonly int MemberBecomeEnemyRate;

	public readonly short TaiwuBounty;

	public readonly sbyte AlterTime;

	public SettlementPrisonEventEffectItem(short templateId, int changeFavorTeammate, int changeFavorCaptor, int changeFavorGuardBaseRate, int minAffectedGuardCount, int guardBaseFavorChange, int guardDisapproveRate, int guardApproveRate, int guardBecomeEnemyRate, int changeFavorMemberBaseRate, int minAffectedMemberCount, int memberBaseFavorChange, int memberDisapproveRate, int memberApproveRate, int memberBecomeEnemyRate, short taiwuBounty, sbyte alterTime)
	{
		TemplateId = templateId;
		ChangeFavorTeammate = changeFavorTeammate;
		ChangeFavorCaptor = changeFavorCaptor;
		ChangeFavorGuardBaseRate = changeFavorGuardBaseRate;
		MinAffectedGuardCount = minAffectedGuardCount;
		GuardBaseFavorChange = guardBaseFavorChange;
		GuardDisapproveRate = guardDisapproveRate;
		GuardApproveRate = guardApproveRate;
		GuardBecomeEnemyRate = guardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = changeFavorMemberBaseRate;
		MinAffectedMemberCount = minAffectedMemberCount;
		MemberBaseFavorChange = memberBaseFavorChange;
		MemberDisapproveRate = memberDisapproveRate;
		MemberApproveRate = memberApproveRate;
		MemberBecomeEnemyRate = memberBecomeEnemyRate;
		TaiwuBounty = taiwuBounty;
		AlterTime = alterTime;
	}

	public SettlementPrisonEventEffectItem()
	{
		TemplateId = 0;
		ChangeFavorTeammate = 0;
		ChangeFavorCaptor = 0;
		ChangeFavorGuardBaseRate = 0;
		MinAffectedGuardCount = 0;
		GuardBaseFavorChange = 0;
		GuardDisapproveRate = 0;
		GuardApproveRate = 0;
		GuardBecomeEnemyRate = 0;
		ChangeFavorMemberBaseRate = 0;
		MinAffectedMemberCount = 0;
		MemberBaseFavorChange = 0;
		MemberDisapproveRate = 0;
		MemberApproveRate = 0;
		MemberBecomeEnemyRate = 0;
		TaiwuBounty = 0;
		AlterTime = 0;
	}

	public SettlementPrisonEventEffectItem(short templateId, SettlementPrisonEventEffectItem other)
	{
		TemplateId = templateId;
		ChangeFavorTeammate = other.ChangeFavorTeammate;
		ChangeFavorCaptor = other.ChangeFavorCaptor;
		ChangeFavorGuardBaseRate = other.ChangeFavorGuardBaseRate;
		MinAffectedGuardCount = other.MinAffectedGuardCount;
		GuardBaseFavorChange = other.GuardBaseFavorChange;
		GuardDisapproveRate = other.GuardDisapproveRate;
		GuardApproveRate = other.GuardApproveRate;
		GuardBecomeEnemyRate = other.GuardBecomeEnemyRate;
		ChangeFavorMemberBaseRate = other.ChangeFavorMemberBaseRate;
		MinAffectedMemberCount = other.MinAffectedMemberCount;
		MemberBaseFavorChange = other.MemberBaseFavorChange;
		MemberDisapproveRate = other.MemberDisapproveRate;
		MemberApproveRate = other.MemberApproveRate;
		MemberBecomeEnemyRate = other.MemberBecomeEnemyRate;
		TaiwuBounty = other.TaiwuBounty;
		AlterTime = other.AlterTime;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SettlementPrisonEventEffectItem Duplicate(int templateId)
	{
		return new SettlementPrisonEventEffectItem((short)templateId, this);
	}
}

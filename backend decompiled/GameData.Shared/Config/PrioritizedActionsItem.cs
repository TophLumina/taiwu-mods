using System;
using Config.Common;

namespace Config;

[Serializable]
public class PrioritizedActionsItem : ConfigItem<PrioritizedActionsItem, short>
{
	public readonly short TemplateId;

	public readonly EPrioritizedActionsActType ActType;

	public readonly short FailToCreateActionCoolDown;

	public readonly short ActionCoolDown;

	public readonly int Duration;

	public readonly short BasePriority;

	public readonly short[] MoralityPriority;

	public readonly bool IsPrevActionInterrupted;

	public readonly bool IsAdultOnly;

	public readonly bool IsNonLeader;

	public readonly bool IsNonTaiwuTeammate;

	public readonly bool IsNonMonk;

	public readonly int LoafChance;

	public readonly sbyte[] OrgTemplateId;

	public readonly sbyte[] OrgGrade;

	public readonly sbyte[] ActionJointChance;

	public readonly string RefuseAppointment;

	public PrioritizedActionsItem(short templateId, EPrioritizedActionsActType actType, short failToCreateActionCoolDown, short actionCoolDown, int duration, short basePriority, short[] moralityPriority, bool isPrevActionInterrupted, bool isAdultOnly, bool isNonLeader, bool isNonTaiwuTeammate, bool isNonMonk, int loafChance, sbyte[] orgTemplateId, sbyte[] orgGrade, sbyte[] actionJointChance, string refuseAppointment)
	{
		TemplateId = templateId;
		ActType = actType;
		FailToCreateActionCoolDown = failToCreateActionCoolDown;
		ActionCoolDown = actionCoolDown;
		Duration = duration;
		BasePriority = basePriority;
		MoralityPriority = moralityPriority;
		IsPrevActionInterrupted = isPrevActionInterrupted;
		IsAdultOnly = isAdultOnly;
		IsNonLeader = isNonLeader;
		IsNonTaiwuTeammate = isNonTaiwuTeammate;
		IsNonMonk = isNonMonk;
		LoafChance = loafChance;
		OrgTemplateId = orgTemplateId;
		OrgGrade = orgGrade;
		ActionJointChance = actionJointChance;
		RefuseAppointment = refuseAppointment;
	}

	public PrioritizedActionsItem()
	{
		TemplateId = 0;
		ActType = EPrioritizedActionsActType.Normal;
		FailToCreateActionCoolDown = 0;
		ActionCoolDown = 0;
		Duration = -1;
		BasePriority = 0;
		MoralityPriority = new short[0];
		IsPrevActionInterrupted = false;
		IsAdultOnly = false;
		IsNonLeader = false;
		IsNonTaiwuTeammate = false;
		IsNonMonk = false;
		LoafChance = -1;
		OrgTemplateId = new sbyte[0];
		OrgGrade = new sbyte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
		ActionJointChance = new sbyte[5];
		RefuseAppointment = null;
	}

	public PrioritizedActionsItem(short templateId, PrioritizedActionsItem other)
	{
		TemplateId = templateId;
		ActType = other.ActType;
		FailToCreateActionCoolDown = other.FailToCreateActionCoolDown;
		ActionCoolDown = other.ActionCoolDown;
		Duration = other.Duration;
		BasePriority = other.BasePriority;
		MoralityPriority = other.MoralityPriority;
		IsPrevActionInterrupted = other.IsPrevActionInterrupted;
		IsAdultOnly = other.IsAdultOnly;
		IsNonLeader = other.IsNonLeader;
		IsNonTaiwuTeammate = other.IsNonTaiwuTeammate;
		IsNonMonk = other.IsNonMonk;
		LoafChance = other.LoafChance;
		OrgTemplateId = other.OrgTemplateId;
		OrgGrade = other.OrgGrade;
		ActionJointChance = other.ActionJointChance;
		RefuseAppointment = other.RefuseAppointment;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override PrioritizedActionsItem Duplicate(int templateId)
	{
		return new PrioritizedActionsItem((short)templateId, this);
	}
}

using System;

namespace Config.ConfigCells;

[Serializable]
public class OrganizationApproving
{
	public sbyte OrgTemplateId;

	public int ApprovingValue;

	public bool IsValid => OrgTemplateId != -1;

	public OrganizationApproving(sbyte orgTemplateId, int approvingValue)
	{
		OrgTemplateId = orgTemplateId;
		ApprovingValue = approvingValue;
	}

	public OrganizationApproving()
	{
		OrgTemplateId = -1;
		ApprovingValue = -1;
	}
}

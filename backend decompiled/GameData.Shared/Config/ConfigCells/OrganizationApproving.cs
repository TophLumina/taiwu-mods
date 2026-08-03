using System;

namespace Config.ConfigCells;

/// <summary>
/// 门派支持度配置
/// </summary>
[Serializable]
public class OrganizationApproving
{
	/// <summary>
	/// 门派模板 ID
	/// </summary>
	public sbyte OrgTemplateId;

	/// <summary>
	/// 支持度数值
	/// </summary>
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

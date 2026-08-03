namespace GameData.Domains.Taiwu;

/// <summary>
/// 突破格子状态工具集
/// </summary>
public static class SkillBreakPlateGridStateHelper
{
	/// <summary>
	/// 指定状态是否尚未被交互
	/// </summary>
	public static bool CanInteract(this ESkillBreakGridState state)
	{
		if ((uint)(state - -1) <= 2u)
		{
			return true;
		}
		return false;
	}
}

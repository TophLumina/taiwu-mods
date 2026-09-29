namespace GameData.Domains.Taiwu;

public static class SkillBreakPlateGridStateHelper
{
	public static bool CanInteract(this ESkillBreakGridState state)
	{
		if ((uint)(state - -1) <= 2u)
		{
			return true;
		}
		return false;
	}
}

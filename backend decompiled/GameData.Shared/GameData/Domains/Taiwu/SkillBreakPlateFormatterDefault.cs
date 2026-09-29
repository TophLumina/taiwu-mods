namespace GameData.Domains.Taiwu;

public class SkillBreakPlateFormatterDefault : ISkillBreakPlateFormatter
{
	public string AlignSpace => " ";

	public string Format(SkillBreakPlateIndex index, SkillBreakPlateGrid grid)
	{
		sbyte templateId = grid.TemplateId;
		if (grid.State != ESkillBreakGridState.Selected)
		{
			return templateId switch
			{
				0 => "+", 
				1 => "*", 
				2 => "$", 
				_ => grid.AddMaxPower.ToString().Substring(0, 1), 
			};
		}
		return "√";
	}
}

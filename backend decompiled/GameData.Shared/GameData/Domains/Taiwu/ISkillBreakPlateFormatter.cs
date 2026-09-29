namespace GameData.Domains.Taiwu;

public interface ISkillBreakPlateFormatter
{
	string AlignSpace { get; }

	string Format(SkillBreakPlateIndex index, SkillBreakPlateGrid grid);
}

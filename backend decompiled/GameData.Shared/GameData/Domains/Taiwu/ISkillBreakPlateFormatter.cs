namespace GameData.Domains.Taiwu;

/// <summary>
/// 突破盘格式化接口
/// </summary>
public interface ISkillBreakPlateFormatter
{
	/// <summary>
	/// 对齐使用的空格
	/// </summary>
	string AlignSpace { get; }

	/// <summary>
	/// 格式化方法
	/// </summary>
	/// <param name="index"></param>
	/// <param name="grid"></param>
	/// <returns></returns>
	string Format(SkillBreakPlateIndex index, SkillBreakPlateGrid grid);
}

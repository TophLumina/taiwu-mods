namespace GameData.Domains.Taiwu;

public interface ITaiwuSkill
{
	/// <summary>
	/// 获取指定书页的研读进度
	/// </summary>
	sbyte GetBookPageReadingProgress(byte index);

	/// <summary>
	/// 设置指定书页的研读进度
	/// </summary>
	void SetBookPageReadingProgress(byte index, sbyte progress);

	/// <summary>
	/// 获取所有书页的研读进度
	/// </summary>
	sbyte[] GetAllBookPageReadingProgress();
}

public class TeachBookResult
{
	/// <summary>
	/// 成功
	/// </summary>
	public const sbyte Success = 0;

	/// <summary>
	/// 没有安排主事
	/// </summary>
	public const sbyte HaveNotLeader = 1;

	/// <summary>
	/// 老师没有建筑需要的村民身份,无法服众
	/// </summary>
	public const sbyte LeaderHaveNotVillagerRole = 2;

	/// <summary>
	/// 没有可学习的书页：老师没有东西可交
	/// </summary>
	public const sbyte HaveNotPageToLearn = 3;

	/// <summary>
	/// 没有可学习的书页：学生点数不够
	/// </summary>
	public const sbyte NotEnoughPoint = 4;
}

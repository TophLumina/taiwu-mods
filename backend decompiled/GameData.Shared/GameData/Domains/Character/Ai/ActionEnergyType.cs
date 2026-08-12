namespace GameData.Domains.Character.Ai;

/// <summary>
/// AI行为能量类型
/// </summary>
public static class ActionEnergyType
{
	/// <summary>
	/// 健康请求行动
	/// </summary>
	public const sbyte HealthRequest = 0;

	/// <summary>
	/// 财富请求行动
	/// </summary>
	public const sbyte WealthRequest = 1;

	/// <summary>
	/// 学习请求行动
	/// </summary>
	public const sbyte StudyRequest = 2;

	/// <summary>
	/// 行为行动
	/// </summary>
	public const sbyte BehaviorAction = 3;

	/// <summary>
	/// 自由行动
	/// </summary>
	public const sbyte FreeAction = 4;

	/// <summary>
	/// 总数
	/// </summary>
	public const sbyte Count = 5;

	/// <summary>
	/// 最大能量
	/// </summary>
	public const byte MaxEnergy = 200;

	/// <summary>
	/// 能量消耗
	/// </summary>
	public const byte EnergyCost = 100;

	/// <summary>
	/// 获得与各种能量类型关联的七元赋性
	/// </summary>
	public static readonly sbyte[] ToPersonalityType = new sbyte[5] { 4, 0, 1, 3, 2 };
}

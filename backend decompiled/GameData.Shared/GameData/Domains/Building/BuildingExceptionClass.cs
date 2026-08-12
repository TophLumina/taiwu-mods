namespace GameData.Domains.Building;

/// <summary>
/// 建筑异常分类
/// </summary>
public enum BuildingExceptionClass : sbyte
{
	/// <summary>
	/// 经营异常
	/// </summary>
	ManageException,
	/// <summary>
	/// 研习异常
	/// </summary>
	LearnException,
	/// <summary>
	/// 建造异常
	/// </summary>
	BuildException,
	/// <summary>
	/// 效果异常
	/// </summary>
	EffectException,
	/// <summary>
	/// 建筑受损异常
	/// </summary>
	DamagedException
}

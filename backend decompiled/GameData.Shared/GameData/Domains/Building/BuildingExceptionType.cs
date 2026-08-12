namespace GameData.Domains.Building;

/// <summary>
/// 建筑异常类型
/// </summary>
public enum BuildingExceptionType : sbyte
{
	/// <summary>
	/// 经营中断，因依赖建筑或依赖资源点的规模不足
	/// </summary>
	ManageStoppedForDependency,
	/// <summary>
	/// 经营中断，因无主事
	/// </summary>
	ManageStoppedForNoLeader,
	/// <summary>
	/// 宴堂宴席，没有布置菜肴
	/// </summary>
	ComfortableHouseEntertainNoFood,
	/// <summary>
	/// 研习异常
	/// </summary>
	LearnException,
	/// <summary>
	/// 建造中断，因人手不足
	/// </summary>
	BuildStoppedForWorkerShortage,
	/// <summary>
	/// 撤除中断，因人手不足
	/// </summary>
	DemolishStoppedForWorkerShortage,
	/// <summary>
	/// 效果中断，因依赖建筑或依赖资源点的规模不足
	/// </summary>
	EffectStoppedForDependency,
	/// <summary>
	/// 建筑受损
	/// </summary>
	Damaged
}

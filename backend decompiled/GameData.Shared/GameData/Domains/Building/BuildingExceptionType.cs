namespace GameData.Domains.Building;

public enum BuildingExceptionType : sbyte
{
	ManageStoppedForDependency,
	ManageStoppedForNoLeader,
	ComfortableHouseEntertainNoFood,
	LearnException,
	BuildStoppedForWorkerShortage,
	DemolishStoppedForWorkerShortage,
	EffectStoppedForDependency,
	Damaged
}

using GameData.Adventure;

namespace GameData.Domains.Adventure;

public delegate bool AdventurePatrolTargetChecker(AdventureElementMoveData data, AdventureRuntime adventure, AdventureBlockIndex src, AdventureBlockIndex dst);

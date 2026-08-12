using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 巡逻目标校验器
/// </summary>
public delegate bool AdventurePatrolTargetChecker(AdventureElementMoveData data, AdventureRuntime adventure, AdventureBlockIndex src, AdventureBlockIndex dst);

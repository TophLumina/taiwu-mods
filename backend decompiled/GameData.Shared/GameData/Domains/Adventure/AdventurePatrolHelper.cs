using System.Collections.Generic;
using System.Linq;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇巡逻工具集
/// </summary>
public static class AdventurePatrolHelper
{
	/// <summary>
	/// 巡逻目标校验器
	/// </summary>
	public static Dictionary<EAdventureElementMoveType, AdventurePatrolTargetChecker> TargetCheckers = new Dictionary<EAdventureElementMoveType, AdventurePatrolTargetChecker>
	{
		{
			EAdventureElementMoveType.PatrolInBlock,
			BlockChecker
		},
		{
			EAdventureElementMoveType.PatrolInGroup,
			GroupChecker
		},
		{
			EAdventureElementMoveType.PatrolInSpecifyGroup,
			SpecifyGroupChecker
		}
	};

	private static bool BlockChecker(AdventureElementMoveData data, AdventureRuntime adv, AdventureBlockIndex src, AdventureBlockIndex dst)
	{
		return src.XyEquals(dst);
	}

	private static bool GroupChecker(AdventureElementMoveData data, AdventureRuntime adv, AdventureBlockIndex src, AdventureBlockIndex dst)
	{
		IReadOnlyList<int> groupIds = adv.GetBlockGroupIds(src);
		return adv.GetBlockGroupIds(dst).Any(((IEnumerable<int>)groupIds).Contains<int>);
	}

	private static bool SpecifyGroupChecker(AdventureElementMoveData data, AdventureRuntime adv, AdventureBlockIndex src, AdventureBlockIndex dst)
	{
		IReadOnlyList<int> movedGroupIds = adv.GetBlockGroupIds(dst);
		return data.TargetGroupIds.All(((IEnumerable<int>)movedGroupIds).Contains<int>);
	}
}

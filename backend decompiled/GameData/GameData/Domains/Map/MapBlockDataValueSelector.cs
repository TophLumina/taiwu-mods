using CompDevLib.Interpreter;

namespace GameData.Domains.Map;

public class MapBlockDataValueSelector : IFieldValueSelector<MapBlockData>, IFieldValueSelector
{
	public ValueInfo SelectValue(MapBlockData blockData, Evaluator evaluator, string identifier)
	{
		if (1 == 0)
		{
		}
		ValueInfo result = ((identifier == "Settlement") ? evaluator.PushEvaluationResult(DomainManager.Organization.GetSettlementByLocation(blockData.GetRootBlock().GetLocation())) : ((!(identifier == "SubBlocks")) ? ValueInfo.Void : evaluator.PushEvaluationResult(blockData.GroupBlockList)));
		if (1 == 0)
		{
		}
		return result;
	}
}

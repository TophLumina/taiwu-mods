using System.Collections.Generic;
using System.IO;
using System.Text;
using Config;

namespace GameData.Domains.Combat.Ai;

public static class AiDataBinaryReader
{
	public static void Analysis(Stream stream, out IReadOnlyList<IAiNode> dataNodes, out IReadOnlyList<IAiCondition> dataConditions, out IReadOnlyList<IAiAction> dataActions)
	{
		using BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);
		int nodeCount = reader.ReadInt32();
		List<IAiNode> nodes = (List<IAiNode>)(dataNodes = new List<IAiNode>(nodeCount));
		for (int i = 0; i < nodeCount; i++)
		{
			EAiNodeType type = (EAiNodeType)reader.ReadInt32();
			int nodeOrActionIdCount = reader.ReadInt32();
			List<int> nodeOrActionIds = new List<int>(nodeOrActionIdCount);
			for (int pi = 0; pi < nodeOrActionIdCount; pi++)
			{
				nodeOrActionIds.Add(reader.ReadInt32());
			}
			nodes.Add(AiNodeFactory.Create(type, i, nodeOrActionIds));
		}
		int conditionCount = reader.ReadInt32();
		List<IAiCondition> conditions = (List<IAiCondition>)(dataConditions = new List<IAiCondition>(conditionCount));
		for (int j = 0; j < conditionCount; j++)
		{
			EAiConditionType type2 = (EAiConditionType)reader.ReadInt32();
			AiConditionItem config = AiCondition.Instance[(int)type2];
			var (strings, ints) = ReadParam(reader, config.ParamStrings, config.ParamInts);
			conditions.Add(AiConditionFactory.Create(type2, j, strings, ints));
		}
		int actionCount = reader.ReadInt32();
		List<IAiAction> actions = (List<IAiAction>)(dataActions = new List<IAiAction>(actionCount));
		for (int k = 0; k < actionCount; k++)
		{
			EAiActionType type3 = (EAiActionType)reader.ReadInt32();
			AiActionItem config2 = AiAction.Instance[(int)type3];
			var (strings2, ints2) = ReadParam(reader, config2.ParamStrings, config2.ParamInts);
			actions.Add(AiActionFactory.Create(type3, k, strings2, ints2));
		}
	}

	private static (IReadOnlyList<string> strings, IReadOnlyList<int> ints) ReadParam(BinaryReader reader, IReadOnlyList<int> configStrings, IReadOnlyList<int> configInts)
	{
		List<string> strings = ((configStrings != null && configStrings.Count > 0) ? new List<string>(configStrings.Count) : null);
		if (strings != null)
		{
			for (int pi = 0; pi < configStrings.Count; pi++)
			{
				strings.Add(reader.ReadString());
			}
		}
		List<int> ints = ((configInts != null && configInts.Count > 0) ? new List<int>(configInts.Count) : null);
		if (ints != null)
		{
			for (int i = 0; i < configInts.Count; i++)
			{
				ints.Add(reader.ReadInt32());
			}
		}
		return (strings: strings, ints: ints);
	}
}

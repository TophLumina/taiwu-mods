using System;
using System.Collections.Generic;
using System.IO;
using Config;

namespace GameData.Domains.Combat.Ai;

public class AiDataFile : AiData
{
	protected override IReadOnlyList<IAiNode> Nodes { get; }

	protected sealed override IReadOnlyList<IAiCondition> Conditions { get; }

	protected sealed override IReadOnlyList<IAiAction> Actions { get; }

	public AiDataFile(AiDataItem data)
		: this("../Combat/CombatAi/" + data.Path + ".aid")
	{
	}

	public AiDataFile(string path)
	{
		try
		{
			using FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			AiDataBinaryReader.Analysis(stream, out var nodes, out var conditions, out var actions);
			Nodes = nodes;
			Conditions = conditions;
			Actions = actions;
		}
		catch (Exception ex)
		{
			PredefinedLog.Show(23, path, ex.Message);
			Nodes = Array.Empty<IAiNode>();
			Conditions = Array.Empty<IAiCondition>();
			Actions = Array.Empty<IAiAction>();
		}
	}
}

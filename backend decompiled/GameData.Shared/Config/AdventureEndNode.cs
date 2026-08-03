using System;

namespace Config;

[Serializable]
public class AdventureEndNode
{
	public Guid EventId;

	public int TerrainId;

	public string NodeKey;

	public string NodeTitle;

	public AdventureEndNode(string guid, string key, string nodeKey, int terrainId)
	{
		if (string.IsNullOrEmpty(guid))
		{
			EventId = Guid.Empty;
		}
		else if (!Guid.TryParse(guid, out EventId))
		{
			throw new ArgumentException("Unable to parse event guid " + guid + " at node " + nodeKey);
		}
		NodeKey = key;
		TerrainId = terrainId;
	}
}

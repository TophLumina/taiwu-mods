using GameData.Common;

namespace GameData.Domains.Map;

public static class MapBlockDataHelper
{
	public static void SetVisible(this MapBlockData blockData, bool visible, DataContext context)
	{
		blockData.Visible = visible;
		DomainManager.Map.SetBlockData(context, blockData);
		if (!visible)
		{
			return;
		}
		MapBlockData rootBlockData = blockData.GetRootBlock();
		if (rootBlockData.GroupBlockList != null)
		{
			foreach (MapBlockData groupBlock in rootBlockData.GroupBlockList)
			{
				groupBlock.Visible = true;
				DomainManager.Map.SetBlockData(context, groupBlock);
			}
		}
		rootBlockData.Visible = true;
		DomainManager.Map.SetBlockData(context, rootBlockData);
	}
}

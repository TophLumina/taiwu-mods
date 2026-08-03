using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 促织决斗预设
/// </summary>
public class CricketPreset : PresetBase<CricketPresetItem>
{
	/// <summary>
	/// 将所有预设中旧蛐蛐 ID 替换为新蛐蛐 ID
	/// </summary>
	/// <param name="oldCricketId">旧蛐蛐 ID</param>
	/// <param name="newCricketId">新蛐蛐 ID</param>
	public void ReplaceCrickets(int oldCricketId, int newCricketId)
	{
		foreach (CricketPresetItem preset in base.Presets)
		{
			List<int> cricketIds = preset.CricketIds;
			if (cricketIds == null || cricketIds.Count <= 0)
			{
				continue;
			}
			for (int i = 0; i < preset.CricketIds.Count; i++)
			{
				if (preset.CricketIds[i] == oldCricketId)
				{
					preset.CricketIds[i] = newCricketId;
				}
			}
		}
	}

	/// <summary>
	/// 判断蛐蛐ID是否在任意预设中（排除当前使用的预设）
	/// </summary>
	/// <param name="cricketId">蛐蛐ID</param>
	/// <param name="currentPresetIndex">当前使用的预设索引</param>
	/// <returns></returns>
	public bool ContainsCricketId(int cricketId, int currentPresetIndex = -1)
	{
		for (int i = 0; i < base.Presets.Count; i++)
		{
			if (i != currentPresetIndex)
			{
				CricketPresetItem preset = base.Presets[i];
				List<int> list = preset?.CricketIds;
				if (list != null && list.Count > 0 && preset.CricketIds.Contains(cricketId))
				{
					return true;
				}
			}
		}
		return false;
	}

	public CricketPreset()
		: base(3)
	{
	}
}

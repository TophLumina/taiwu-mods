using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Item;

public class CricketPreset : PresetBase<CricketPresetItem>
{
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

using GameData.Utilities;

namespace GameData.Domains.Global;

/// <summary>
/// 自定义人物预设
/// </summary>
public class CustomProtagonistPreset : PresetBase<CustomProtagonistPresetItem>
{
	public override int MaxPresetCount => 5;

	public CustomProtagonistPreset()
		: base(1)
	{
	}
}

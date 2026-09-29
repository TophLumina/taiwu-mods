using GameData.Utilities;

namespace GameData.Domains.Global;

public class CustomProtagonistPreset : PresetBase<CustomProtagonistPresetItem>
{
	public override int MaxPresetCount => 5;

	public CustomProtagonistPreset()
		: base(1)
	{
	}
}

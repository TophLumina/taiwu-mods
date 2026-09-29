using GameData.Utilities;

namespace GameData.DLC.SmarterChicken;

public class CombatChickenPreset : PresetBase<CombatChickenPresetItem>
{
	public override int MaxPresetCount => 7;

	public CombatChickenPreset()
		: base(3)
	{
	}
}

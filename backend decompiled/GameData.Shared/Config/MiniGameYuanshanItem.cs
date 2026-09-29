using System;
using Config.Common;

namespace Config;

[Serializable]
public class MiniGameYuanshanItem : ConfigItem<MiniGameYuanshanItem, byte>
{
	public readonly byte TemplateId;

	public readonly string Name;

	public readonly int SwapCount;

	public readonly float SwapDuration;

	public readonly bool GreyIcon;

	public readonly bool Effect;

	public readonly bool[] EnableEffect;

	public MiniGameYuanshanItem(byte templateId, string name, int swapCount, float swapDuration, bool greyIcon, bool effect, bool[] enableEffect)
	{
		TemplateId = templateId;
		Name = name;
		SwapCount = swapCount;
		SwapDuration = swapDuration;
		GreyIcon = greyIcon;
		Effect = effect;
		EnableEffect = enableEffect;
	}

	public MiniGameYuanshanItem()
	{
		TemplateId = 0;
		Name = null;
		SwapCount = 0;
		SwapDuration = 0f;
		GreyIcon = false;
		Effect = false;
		EnableEffect = null;
	}

	public MiniGameYuanshanItem(byte templateId, MiniGameYuanshanItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		SwapCount = other.SwapCount;
		SwapDuration = other.SwapDuration;
		GreyIcon = other.GreyIcon;
		Effect = other.Effect;
		EnableEffect = other.EnableEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MiniGameYuanshanItem Duplicate(int templateId)
	{
		return new MiniGameYuanshanItem((byte)templateId, this);
	}
}

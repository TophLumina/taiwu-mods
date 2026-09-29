using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakePerformanceEffectParamItem : ConfigItem<AdventureRemakePerformanceEffectParamItem, short>
{
	public readonly short TemplateId;

	public readonly EAdventureRemakePerformanceEffectParamType Type;

	public readonly string LoadName;

	public readonly sbyte PercentageCount;

	public readonly sbyte[] CountRange;

	public readonly int Scale;

	public readonly float ParticleSimulationSpeed;

	public readonly float ParticleStartDelay;

	public readonly float[] ParticleStartDelayRandom;

	public readonly float[] ParticleStartSpeedRandom;

	public AdventureRemakePerformanceEffectParamItem(short templateId, EAdventureRemakePerformanceEffectParamType type, string loadName, sbyte percentageCount, sbyte[] countRange, int scale, float particleSimulationSpeed, float particleStartDelay, float[] particleStartDelayRandom, float[] particleStartSpeedRandom)
	{
		TemplateId = templateId;
		Type = type;
		LoadName = loadName;
		PercentageCount = percentageCount;
		CountRange = countRange;
		Scale = scale;
		ParticleSimulationSpeed = particleSimulationSpeed;
		ParticleStartDelay = particleStartDelay;
		ParticleStartDelayRandom = particleStartDelayRandom;
		ParticleStartSpeedRandom = particleStartSpeedRandom;
	}

	public AdventureRemakePerformanceEffectParamItem()
	{
		TemplateId = 0;
		Type = EAdventureRemakePerformanceEffectParamType.OuterBlock;
		LoadName = null;
		PercentageCount = -1;
		CountRange = null;
		Scale = 1;
		ParticleSimulationSpeed = -1f;
		ParticleStartDelay = -1f;
		ParticleStartDelayRandom = null;
		ParticleStartSpeedRandom = null;
	}

	public AdventureRemakePerformanceEffectParamItem(short templateId, AdventureRemakePerformanceEffectParamItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		LoadName = other.LoadName;
		PercentageCount = other.PercentageCount;
		CountRange = other.CountRange;
		Scale = other.Scale;
		ParticleSimulationSpeed = other.ParticleSimulationSpeed;
		ParticleStartDelay = other.ParticleStartDelay;
		ParticleStartDelayRandom = other.ParticleStartDelayRandom;
		ParticleStartSpeedRandom = other.ParticleStartSpeedRandom;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureRemakePerformanceEffectParamItem Duplicate(int templateId)
	{
		return new AdventureRemakePerformanceEffectParamItem((short)templateId, this);
	}
}

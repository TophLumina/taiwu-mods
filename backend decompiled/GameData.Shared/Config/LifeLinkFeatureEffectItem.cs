using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class LifeLinkFeatureEffectItem : ConfigItem<LifeLinkFeatureEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly byte FiveElements;

	public readonly short FeatureId;

	public readonly int CriticalProbPercent;

	public CharacterFeatureItem Feature
	{
		[return: MaybeNull]
		get
		{
			return CharacterFeature.Instance.GetItemOrDefault(FeatureId);
		}
	}

	public LifeLinkFeatureEffectItem(sbyte templateId, byte fiveElements, short featureId, int criticalProbPercent)
	{
		TemplateId = templateId;
		FiveElements = fiveElements;
		FeatureId = featureId;
		CriticalProbPercent = criticalProbPercent;
	}

	public LifeLinkFeatureEffectItem()
	{
		TemplateId = 0;
		FiveElements = 0;
		FeatureId = 0;
		CriticalProbPercent = 0;
	}

	public LifeLinkFeatureEffectItem(sbyte templateId, LifeLinkFeatureEffectItem other)
	{
		TemplateId = templateId;
		FiveElements = other.FiveElements;
		FeatureId = other.FeatureId;
		CriticalProbPercent = other.CriticalProbPercent;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LifeLinkFeatureEffectItem Duplicate(int templateId)
	{
		return new LifeLinkFeatureEffectItem((sbyte)templateId, this);
	}
}

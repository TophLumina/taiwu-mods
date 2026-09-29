using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeLinkFeatureEffect : ConfigData<LifeLinkFeatureEffectItem, sbyte>
{
	public static LifeLinkFeatureEffect Instance = new LifeLinkFeatureEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "FeatureId", "TemplateId", "FiveElements", "CriticalProbPercent" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new LifeLinkFeatureEffectItem(0, 0, 450, 50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(1, 1, 451, 50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(2, 2, 452, 50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(3, 3, 453, 50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(4, 4, 454, 50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(5, 0, 455, -50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(6, 1, 456, -50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(7, 2, 457, -50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(8, 3, 458, -50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(9, 4, 459, -50));
		_dataArray.Add(new LifeLinkFeatureEffectItem(10, 0, 460, 25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(11, 1, 461, 25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(12, 2, 462, 25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(13, 3, 463, 25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(14, 4, 464, 25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(15, 0, 465, -25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(16, 1, 466, -25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(17, 2, 467, -25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(18, 3, 468, -25));
		_dataArray.Add(new LifeLinkFeatureEffectItem(19, 4, 469, -25));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeLinkFeatureEffectItem>(20);
		CreateItems0();
	}
}

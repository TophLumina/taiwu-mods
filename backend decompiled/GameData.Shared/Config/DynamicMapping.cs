using System.Collections.Generic;

namespace Config;

public static class DynamicMapping
{
	public static Dictionary<short, short> TwelveImmortalsFeatureId2TemplateId;

	public static void Initialize()
	{
		TwelveImmortalsFeatureId2TemplateId = new Dictionary<short, short>();
		foreach (TwelveImmortalsItem immortal in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			TwelveImmortalsFeatureId2TemplateId[immortal.BonusFeature] = immortal.TemplateId;
			TwelveImmortalsFeatureId2TemplateId[immortal.BonusFeatureInDefeated] = immortal.TemplateId;
		}
	}
}

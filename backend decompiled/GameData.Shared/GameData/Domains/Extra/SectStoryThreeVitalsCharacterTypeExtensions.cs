using System;

namespace GameData.Domains.Extra;

public static class SectStoryThreeVitalsCharacterTypeExtensions
{
	public static short GetVitalTemplateId(this SectStoryThreeVitalsCharacterType type, bool vitalIsDemon)
	{
		return type switch
		{
			SectStoryThreeVitalsCharacterType.Heaven => (short)(vitalIsDemon ? 640 : 643), 
			SectStoryThreeVitalsCharacterType.Earth => (short)(vitalIsDemon ? 641 : 644), 
			SectStoryThreeVitalsCharacterType.Human => (short)(vitalIsDemon ? 642 : 645), 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
	}
}

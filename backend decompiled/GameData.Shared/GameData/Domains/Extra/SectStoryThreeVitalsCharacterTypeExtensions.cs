using System;

namespace GameData.Domains.Extra;

/// <summary>
/// 三魔/才类型拓展接口
/// </summary>
public static class SectStoryThreeVitalsCharacterTypeExtensions
{
	/// <summary>
	/// 获取三才/魔角色的模板 ID
	/// </summary>
	/// <param name="type">三才/魔类型</param>
	/// <param name="vitalIsDemon">是否为三魔</param>
	/// <returns></returns>
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

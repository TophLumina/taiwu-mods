using System.Collections.Generic;
using Config;
using GameData.Domains.Character.Display;

namespace GameData.Domains.Story.MainStory;

public static class TwelveImmortalsDisplayExtensions
{
	/// <summary>
	/// 尝试获取角色作为十二仙的配置，返回值可能为空
	/// </summary>
	public static TwelveImmortalsItem GetTwelveImmortalsConfig(this CharacterDisplayData immortal)
	{
		foreach (TwelveImmortalsItem config in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (config.Character == immortal.TemplateId)
			{
				return config;
			}
		}
		return null;
	}
}

using Config;

namespace GameData.Domains.Story.MainStory;

/// <summary>
/// 主线特殊敌人拓展方法集
/// </summary>
public static class SpecialEnemyExtensions
{
	/// <summary>
	/// 角色是柴山元祖
	/// </summary>
	public static bool IsChaiShanYuanZu(this CharacterItem config)
	{
		int templateId = config.GetTemplateId();
		if (templateId == 1097 || templateId == 1112)
		{
			return true;
		}
		return false;
	}
}

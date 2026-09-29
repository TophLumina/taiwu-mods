using Config;

namespace GameData.Domains.Story.MainStory;

public static class SpecialEnemyExtensions
{
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

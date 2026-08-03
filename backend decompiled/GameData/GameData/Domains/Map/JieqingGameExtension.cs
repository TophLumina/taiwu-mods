using GameData.Domains.Extra;

namespace GameData.Domains.Map;

public static class JieqingGameExtension
{
	public static void AdvanceMonthResetData(this SectStoryJieqingGame jieqingGameData)
	{
		jieqingGameData.ReopenLeftCount = 1;
		int maxCount = (jieqingGameData.RerollMaxCount = JieqingGameHelper.GetRerollMaxCount());
		jieqingGameData.RerollLeftCount = maxCount;
	}
}

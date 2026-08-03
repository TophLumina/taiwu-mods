using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Extra;

namespace GameData.Domains.Map;

public static class JieqingGameHelper
{
	public static SectStoryJieqingGame InitJieqingGameData()
	{
		return new SectStoryJieqingGame
		{
			RerollMaxCount = GetRerollMaxCount(),
			RerollLeftCount = GetRerollMaxCount(),
			ReopenLeftCount = 1,
			GameResult = 0,
			CurrPeaceRotationState = 0,
			CurrPeaceTemplateId = -1,
			BroadChessData = new List<JieqingGameChessData>(),
			NextPieceTemplateId = -1
		};
	}

	public static int GetRerollMaxCount()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short mathAttainment = taiwu.GetLifeSkillAttainment(4);
		return mathAttainment / 150 + 1;
	}
}

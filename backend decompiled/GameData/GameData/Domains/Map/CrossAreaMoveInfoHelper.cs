using GameData.Domains.Character;

namespace GameData.Domains.Map;

public static class CrossAreaMoveInfoHelper
{
	public static void AutoCheckFreeTravel(this CrossAreaMoveInfo crossAreaMoveInfo)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taiwuChar.GetResource(6) < crossAreaMoveInfo.MoneyCost)
		{
			for (int i = 0; i < crossAreaMoveInfo.Route.CostList.Count; i++)
			{
				crossAreaMoveInfo.Route.CostList[i] = (short)(crossAreaMoveInfo.Route.CostList[i] * SharedConstValue.FreeTravelCostTimeRate);
			}
			crossAreaMoveInfo.MoneyCost = 0;
		}
	}
}

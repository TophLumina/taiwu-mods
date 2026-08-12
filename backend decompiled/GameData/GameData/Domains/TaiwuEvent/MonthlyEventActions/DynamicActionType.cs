using System;
using GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

public static class DynamicActionType
{
	public const short MarriageTriggerAction = 0;

	public const short LegendaryBookMonthlyAction = 1;

	public const short ShixiangStoryAdventureTriggerAction = 2;

	public const short WuxianStoryAdventureTriggerAction = 3;

	public const short BaihuaStoryAdventureFourTriggerAction = 4;

	public const short FulongStoryAdventureOneTriggerAction = 5;

	public const short FulongStoryAdventureThreeTriggerAction = 6;

	public static MonthlyActionBase CreateDynamicAction(short dynamicActionType)
	{
		return dynamicActionType switch
		{
			0 => new MarriageTriggerAction(), 
			1 => new LegendaryBookMonthlyAction(), 
			2 => new ShixiangStoryAdventureTriggerAction(), 
			3 => new WuxianStoryAdventureTriggerAction(), 
			4 => new BaihuaStoryAdventureFourTriggerAction(), 
			5 => new FulongStoryAdventureOneTriggerAction(), 
			6 => new FulongStoryAdventureThreeTriggerAction(), 
			_ => throw new ArgumentException($"{"dynamicActionType"} has an invalid value of {dynamicActionType}"), 
		};
	}
}

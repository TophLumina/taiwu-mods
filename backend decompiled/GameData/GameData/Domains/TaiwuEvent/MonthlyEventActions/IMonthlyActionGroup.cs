namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

public interface IMonthlyActionGroup
{
	void DeactivateSubAction(short areaId, short blockId, bool isComplete);

	ConfigMonthlyAction GetConfigAction(short areaId, short blockId);
}

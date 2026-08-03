namespace GameData.ActionPlanning.MonthlyAI.Sensor;

public static class SensorStateHelper
{
	public static sbyte Offset(this StateKey stateKey, int baseTemplateId)
	{
		return (sbyte)(stateKey.StateTemplateId - baseTemplateId);
	}

	public static int ToInt(this bool value)
	{
		return value ? 1 : 0;
	}
}

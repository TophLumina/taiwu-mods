namespace GameData.Utilities;

/// <summary>
/// 战斗道具配置接口
/// </summary>
public interface ICombatItemConfig
{
	/// <summary>
	/// 机略消耗
	/// </summary>
	int ConsumedFeatureMedals { get; }

	/// <summary>
	/// 使用帧数
	/// </summary>
	int UseFrame { get; }

	/// <summary>
	/// 允许在切磋与接招战使用
	/// </summary>
	bool AllowUseInPlayAndTest => false;
}

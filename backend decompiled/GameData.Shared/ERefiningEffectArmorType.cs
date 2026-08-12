/// <summary>
/// RefiningEffect -&gt; ArmorType
/// </summary>
public enum ERefiningEffectArmorType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 防具卸力
	/// </summary>
	AvoidRateStrength,
	/// <summary>
	/// 防具拆招
	/// </summary>
	AvoidRateTechnique,
	/// <summary>
	/// 防具闪避
	/// </summary>
	AvoidRateSpeed,
	/// <summary>
	/// 防具守心
	/// </summary>
	AvoidRateMind,
	/// <summary>
	/// 破刃
	/// </summary>
	EquipmentAttack,
	/// <summary>
	/// 坚韧
	/// </summary>
	EquipmentDefense,
	/// <summary>
	/// 防御
	/// </summary>
	PenetrationResist,
	/// <summary>
	/// 重量
	/// </summary>
	Weight,
	/// <summary>
	/// 内伤降低
	/// </summary>
	InjuryFactorInner,
	/// <summary>
	/// 最大耐久
	/// </summary>
	MaxDurability,
	/// <summary>
	/// 外伤降低
	/// </summary>
	InjuryFactorOuter,
	/// <summary>
	/// 反震威力
	/// </summary>
	CounterAttackPower,
	/// <summary>
	/// 反击威力
	/// </summary>
	CounterDamagePower,
	/// <summary>
	/// 威力上限
	/// </summary>
	MaxPower,
	/// <summary>
	/// 使用需求
	/// </summary>
	UseRequirement,
	Count
}

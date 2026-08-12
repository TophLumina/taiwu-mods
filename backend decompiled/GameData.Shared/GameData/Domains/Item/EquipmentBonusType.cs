namespace GameData.Domains.Item;

/// <summary>
/// 装备属性的加成类型
/// </summary>
public class EquipmentBonusType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 破甲/破刃
	/// </summary>
	public const sbyte EquipmentAttack = 0;

	/// <summary>
	/// 坚韧
	/// </summary>
	public const sbyte EquipmentDefense = 1;

	/// <summary>
	/// 攻击因子
	/// </summary>
	public const sbyte PenetrationFactor = 2;

	/// <summary>
	/// 防御因子
	/// </summary>
	public const sbyte PenetrationResistFactors = 3;

	/// <summary>
	/// 重量
	/// </summary>
	public const sbyte Weight = 4;
}

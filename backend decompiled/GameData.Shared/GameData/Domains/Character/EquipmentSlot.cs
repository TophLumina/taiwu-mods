using System.Collections.Generic;

namespace GameData.Domains.Character;

/// <summary>
/// 装备栏位
/// </summary>
public static class EquipmentSlot
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 武器1
	/// </summary>
	public const sbyte Weapon1 = 0;

	/// <summary>
	/// 武器2
	/// </summary>
	public const sbyte Weapon2 = 1;

	/// <summary>
	/// 武器3
	/// </summary>
	public const sbyte Weapon3 = 2;

	/// <summary>
	/// 头部防具
	/// </summary>
	public const sbyte Helm = 3;

	/// <summary>
	/// 衣装
	/// </summary>
	public const sbyte Clothing = 4;

	/// <summary>
	/// 躯干防具
	/// </summary>
	public const sbyte Torso = 5;

	/// <summary>
	/// 护手
	/// </summary>
	public const sbyte Bracers = 6;

	/// <summary>
	/// 护足
	/// </summary>
	public const sbyte Boots = 7;

	/// <summary>
	/// 饰品1
	/// </summary>
	public const sbyte Accessory1 = 8;

	/// <summary>
	/// 饰品2
	/// </summary>
	public const sbyte Accessory2 = 9;

	/// <summary>
	/// 饰品3
	/// </summary>
	public const sbyte Accessory3 = 10;

	/// <summary>
	/// 代步
	/// </summary>
	public const sbyte Carrier = 11;

	/// <summary>
	/// 家畜
	/// </summary>
	public const sbyte LivestockCarrier = 12;

	/// <summary>
	/// 野兽
	/// </summary>
	public const sbyte BeastCarrier = 13;

	/// <summary>
	/// 口袋1
	/// </summary>
	public const sbyte Pocket1 = 14;

	/// <summary>
	/// 口袋2
	/// </summary>
	public const sbyte Pocket2 = 15;

	/// <summary>
	/// 口袋3
	/// </summary>
	public const sbyte Pocket3 = 16;

	/// <summary>
	/// 装备栏位个数
	/// </summary>
	public const int Count = 17;

	/// <summary>
	/// 通过装备类型获取装备栏位
	/// </summary>
	public static readonly sbyte[][] EquipmentType2Slots = new sbyte[11][]
	{
		new sbyte[3] { 0, 1, 2 },
		new sbyte[1] { 3 },
		new sbyte[1] { 4 },
		new sbyte[1] { 5 },
		new sbyte[1] { 6 },
		new sbyte[1] { 7 },
		new sbyte[3] { 8, 9, 10 },
		new sbyte[1] { 11 },
		new sbyte[1] { 12 },
		new sbyte[2] { 12, 13 },
		new sbyte[3] { 14, 15, 16 }
	};

	/// <summary>
	/// 需要在进入战斗时生成特效的装备栏位
	/// </summary>
	public static readonly IReadOnlyList<sbyte> EquipmentEffectSlots = new sbyte[13]
	{
		0, 1, 2, 3, 5, 6, 7, 8, 9, 10,
		14, 15, 16
	};
}

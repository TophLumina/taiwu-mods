using System.Collections.Generic;

namespace GameData.Domains.Item;

/// <summary>
/// 道具操作类型
/// </summary>
public static class ItemOperationType
{
	/// <summary>
	/// 道具操作类型枚举
	/// </summary>
	public enum EItemOperationType
	{
		Invalid = -1,
		Repair,
		Disassemble,
		Transfer,
		Take,
		Discard,
		SpecialBreakConvertToExp,
		Feeding,
		Confiscate,
		PutPoisonMaterial,
		ExchangeTools,
		FixItem,
		VillagerCraft,
		PutCraftResource,
		KongsangSpecialInteract,
		UpgradeAnimal,
		HostileInteraction,
		ProfessionDoctorSkill0
	}

	/// <summary>
	/// 消耗太吾物品的操作类型列表
	/// </summary>
	private static List<EItemOperationType> _consumeTypeList = new List<EItemOperationType>
	{
		EItemOperationType.Disassemble,
		EItemOperationType.Transfer,
		EItemOperationType.Discard,
		EItemOperationType.SpecialBreakConvertToExp,
		EItemOperationType.Feeding,
		EItemOperationType.PutPoisonMaterial,
		EItemOperationType.ExchangeTools,
		EItemOperationType.VillagerCraft,
		EItemOperationType.PutCraftResource,
		EItemOperationType.KongsangSpecialInteract,
		EItemOperationType.ProfessionDoctorSkill0
	};

	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 修理
	/// </summary>
	public const sbyte Repair = 0;

	/// <summary>
	/// 拆解
	/// </summary>
	public const sbyte Disassemble = 1;

	/// <summary>
	/// 转赠
	/// </summary>
	public const sbyte Transfer = 2;

	/// <summary>
	/// 拿取
	/// </summary>
	public const sbyte Take = 3;

	/// <summary>
	/// 丢弃
	/// </summary>
	public const sbyte Discard = 4;

	/// <summary>
	/// 独创一格的融会贯通消耗
	/// </summary>
	public const sbyte SpecialBreakConvertToExp = 5;

	/// <summary>
	/// 喂食猛兽类坐骑
	/// </summary>
	public const sbyte Feeding = 6;

	/// <summary>
	/// 关押-没收
	/// </summary>
	public const sbyte Confiscate = 7;

	/// <summary>
	/// 向万毒坛投入毒材料
	/// </summary>
	public const sbyte PutPoisonMaterial = 8;

	/// <summary>
	/// 匠人-交换工具
	/// </summary>
	public const sbyte ExchangeTools = 9;

	/// <summary>
	/// 匠人-修理物品
	/// </summary>
	public const sbyte FixItem = 10;

	/// <summary>
	/// 村民匠人-制造物品
	/// </summary>
	public const sbyte VillagerCraft = 11;

	/// <summary>
	/// 匠人面板投入资源
	/// </summary>
	public const sbyte PutCraftResource = 12;

	/// <summary>
	/// 空桑特殊互动使用王蛊
	/// </summary>
	public const sbyte KongsangSpecialInteract = 13;

	/// <summary>
	/// 空桑特殊互动使用王蛊
	/// </summary>
	public const sbyte HostileInteraction = 15;

	/// <summary>
	/// 大夫志向-看诊施药
	/// </summary>
	public const sbyte ProfessionDoctorSkill0 = 16;

	/// <summary>
	/// 是否是消耗太吾物品的操作
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public static bool IsConsume(EItemOperationType type)
	{
		return _consumeTypeList.Contains(type);
	}
}

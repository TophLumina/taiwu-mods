namespace Config.Common;

/// <summary>
/// 物品配置数据基类
/// </summary>
public abstract class ItemTemplateBase
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 物品类型 <see cref="T:GameData.Domains.Item.ItemType" />
	/// </summary>
	public readonly sbyte ItemType;

	/// <summary>
	/// 物品子类 <see cref="T:GameData.Domains.Item.ItemSubType" />
	/// </summary>
	public readonly short ItemSubType;

	/// <summary>
	/// 品级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 可让渡
	/// </summary>
	public readonly bool Transferable;

	/// <summary>
	/// 可堆叠
	/// </summary>
	public readonly bool Stackable;

	/// <summary>
	/// 可押注
	/// </summary>
	public readonly bool Wagerable;

	/// <summary>
	/// 可精制
	/// </summary>
	public readonly bool Refinable;

	/// <summary>
	/// 可淬毒
	/// </summary>
	public readonly bool Poisonable;

	/// <summary>
	/// 可修理 (同时控制是否会在耐久耗尽时自动销毁)
	/// </summary>
	public readonly bool Repairable;

	/// <summary>
	/// 最大耐久 (配置值, 实际值可能不同)
	/// </summary>
	public readonly short MaxDurability;

	/// <summary>
	/// 重量
	/// </summary>
	public readonly int BaseWeight;

	/// <summary>
	/// 基础价值
	/// </summary>
	public readonly int BaseValue;

	/// <summary>
	/// 基础价格
	/// </summary>
	public readonly int BasePrice;

	/// <summary>
	/// 让渡后的心情变化
	/// </summary>
	public readonly sbyte HappinessChange;

	/// <summary>
	/// 让渡后的好感变化
	/// </summary>
	public readonly int FavorabilityChange;

	/// <summary>
	/// 礼物等级
	/// </summary>
	public readonly sbyte GiftLevel;

	/// <summary>
	/// 掉落率, 取值范围 [0, 100]
	/// </summary>
	public readonly sbyte DropRate;

	/// <summary>
	/// 材质 (对应资源类型)
	/// </summary>
	public readonly sbyte ResourceType;

	/// <summary>
	/// 保存时间 (无主物品的可保存时间, 超过时间会损毁. 单位为月.)
	/// </summary>
	public readonly short PreservationDuration;
}

namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 对人物行囊道具的操作类型
/// </summary>
/// <remarks>
/// 禁止中间插入项. 并需要与 EventArgument 表中的同名配置对应, 以保证指令的正确触发.
/// </remarks>
public enum InventoryItemOperationType
{
	/// <summary>
	/// 偷窃
	/// </summary>
	Steal,
	/// <summary>
	/// 唬骗
	/// </summary>
	Scam,
	/// <summary>
	/// 抢夺
	/// </summary>
	Rob,
	/// <summary>
	/// 富商-慧眼识珠
	/// </summary>
	ProfessionCapitalistSkill0,
	/// <summary>
	/// 王公-鉴别促织-鉴别
	/// </summary>
	ProfessionDukeSkill0_0,
	/// <summary>
	/// 王公-鉴别促织-蜕变
	/// </summary>
	ProfessionDukeSkill0_1,
	/// <summary>
	/// 匠人-独具匠心
	/// </summary>
	ProfessionCraftSkill2,
	/// <summary>
	/// 猎户-万兽升灵
	/// </summary>
	ProfessionHunterSkill3,
	/// <summary>
	/// 元鸡羽
	/// </summary>
	Feather,
	/// <summary>
	/// 直接使用, 用于触发通用使用事件
	/// </summary>
	CommonEventUse
}

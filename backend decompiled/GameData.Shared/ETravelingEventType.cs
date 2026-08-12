/// <summary>
/// TravelingEvent -&gt; Type
/// </summary>
public enum ETravelingEventType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 地区材料
	/// </summary>
	AreaMaterial,
	/// <summary>
	/// 地区资源
	/// </summary>
	AreaResource,
	/// <summary>
	/// 地区食物
	/// </summary>
	AreaFood,
	/// <summary>
	/// 治疗
	/// </summary>
	Heal,
	/// <summary>
	/// 人物赠礼道具
	/// </summary>
	CharacterGiftItem,
	/// <summary>
	/// 人物赠礼资源
	/// </summary>
	CharacterGiftResource,
	/// <summary>
	/// 恢复属性
	/// </summary>
	AttributeRegen,
	/// <summary>
	/// 事件消息
	/// </summary>
	Notification,
	/// <summary>
	/// 地区互动
	/// </summary>
	AreaInteraction,
	/// <summary>
	/// 地区恩义
	/// </summary>
	SpiritualDebt,
	/// <summary>
	/// 门派拜访
	/// </summary>
	SectVisit,
	/// <summary>
	/// 战斗
	/// </summary>
	Combat,
	/// <summary>
	/// 门派战斗
	/// </summary>
	SectCombat,
	/// <summary>
	/// 人物同道
	/// </summary>
	CharacterRecommendVillager,
	/// <summary>
	/// 消耗属性
	/// </summary>
	AttributeCost,
	/// <summary>
	/// 载具耐久
	/// </summary>
	CarrierDurability,
	Count
}

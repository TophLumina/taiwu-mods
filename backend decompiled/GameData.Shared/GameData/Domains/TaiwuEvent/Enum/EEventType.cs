namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 事件分类，一定不可以更换这个顺序
/// 不同类型的事件，参数盒子和监听方式有所不同
/// </summary>
public enum EEventType
{
	/// <summary>
	/// 主线剧情事件
	/// </summary>
	MainStoryEvent,
	/// <summary>
	/// 全局通用事件
	/// </summary>
	GlobalCommonEvent,
	/// <summary>
	/// 技艺任务事件
	/// </summary>
	SkillTaskEvent,
	/// <summary>
	/// 身份衣装事件
	/// </summary>
	IdentityEvent,
	/// <summary>
	/// Npc互动事件
	/// </summary>
	NpcInteractEvent,
	/// <summary>
	/// 奇遇触发事件
	/// </summary>
	AdventureEvent,
	/// <summary>
	/// Mod玩家制作的mod事件
	/// </summary>
	ModEvent,
	/// <summary>
	/// 演武事件
	/// </summary>
	TutorialEvent,
	/// <summary>
	/// 未指定类型的事件
	/// </summary>
	NoneType
}

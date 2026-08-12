namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 地区主线相关事件参数定义
/// </summary>
public static class SectMainStoryEventArgKeys
{
	/// <summary>
	/// 事件触发状态
	/// -1 = 暂停中
	/// 0 or 空 = 未暂停
	/// DomainManager.World.CheckSectMainStoryAvailable(OrgTemplateId) = 任务是否可进行
	/// </summary>
	public const string TriggeringStatus = "ConchShip_PresetKey_SectMainStoryTriggeringStatus";
}

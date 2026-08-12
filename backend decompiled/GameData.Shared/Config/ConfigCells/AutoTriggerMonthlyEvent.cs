using System;

namespace Config.ConfigCells;

/// <summary>
/// 自动触发和填充参数的过月事件配置
/// </summary>
[Serializable]
public class AutoTriggerMonthlyEvent
{
	/// <summary>
	/// 过月事件模板ID <see cref="F:Config.MonthlyEventItem.TemplateId" />
	/// </summary>
	public short MonthlyEventId;

	/// <summary>
	/// 参数名. 如果自动触发源为地区主线, 则从地区主线的参数盒子中获取, 否则从全局参数盒子中获取.
	/// </summary>
	public string[] Args;

	/// <summary>
	/// 无参数初始化
	/// </summary>
	/// <param name="monthlyEventId">过月事件模板ID <see cref="F:Config.MonthlyEventItem.TemplateId" /></param>
	public AutoTriggerMonthlyEvent(short monthlyEventId)
	{
		MonthlyEventId = monthlyEventId;
	}

	/// <summary>
	/// 有参数初始化
	/// </summary>
	/// <param name="monthlyEventId">过月事件模板ID <see cref="F:Config.MonthlyEventItem.TemplateId" /></param>
	/// <param name="args">初始参数名 Key</param>
	public AutoTriggerMonthlyEvent(short monthlyEventId, params string[] args)
	{
		MonthlyEventId = monthlyEventId;
		Args = args;
	}
}

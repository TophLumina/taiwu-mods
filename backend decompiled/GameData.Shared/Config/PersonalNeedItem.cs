using System;
using Config.Common;

namespace Config;

[Serializable]
public class PersonalNeedItem : ConfigItem<PersonalNeedItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 需求名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型匹配
	/// - 比较是否为同类需求时，除了模板ID是否还要比较目标类型。所有以类型为参数的需求（只定义了类型没定义参数）如果需要目标类型不同的需求同时存在则都必须设置该列为1；所有定义了新旧覆盖或参数合并的有类型的需求也必须设置此类。
	/// </summary>
	public readonly bool MatchType;

	/// <summary>
	/// 新旧覆盖
	/// - 获得同个需求时，此值为真时，覆盖之前的需求，之前的需求移除
	/// </summary>
	public readonly bool Overwrite;

	/// <summary>
	/// 参数合并
	/// - 获得同个需求时，将同类的参数合计在一起，如人物原有100银钱，第一个需求为200银钱，第二个需求为200银钱，最终人物需要300银钱。(注：只有参数字段名为Amount的参数才能合并。
	/// </summary>
	public readonly bool Combine;

	/// <summary>
	/// 持续时间
	/// - 该需求持续多少个月，覆盖或合并的情况下重置
	/// </summary>
	public readonly sbyte Duration;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">需求名</param>
	/// <param name="matchType">类型匹配 - 比较是否为同类需求时，除了模板ID是否还要比较目标类型。所有以类型为参数的需求（只定义了类型没定义参数）如果需要目标类型不同的需求同时存在则都必须设置该列为1；所有定义了新旧覆盖或参数合并的有类型的需求也必须设置此类。</param>
	/// <param name="overwrite">新旧覆盖 - 获得同个需求时，此值为真时，覆盖之前的需求，之前的需求移除</param>
	/// <param name="combine">参数合并 - 获得同个需求时，将同类的参数合计在一起，如人物原有100银钱，第一个需求为200银钱，第二个需求为200银钱，最终人物需要300银钱。(注：只有参数字段名为Amount的参数才能合并。</param>
	/// <param name="duration">持续时间 - 该需求持续多少个月，覆盖或合并的情况下重置</param>
	public PersonalNeedItem(sbyte templateId, string name, bool matchType, bool overwrite, bool combine, sbyte duration)
	{
		TemplateId = templateId;
		Name = name;
		MatchType = matchType;
		Overwrite = overwrite;
		Combine = combine;
		Duration = duration;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PersonalNeedItem()
	{
		TemplateId = 0;
		Name = null;
		MatchType = false;
		Overwrite = false;
		Combine = false;
		Duration = 3;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PersonalNeedItem(sbyte templateId, PersonalNeedItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		MatchType = other.MatchType;
		Overwrite = other.Overwrite;
		Combine = other.Combine;
		Duration = other.Duration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PersonalNeedItem Duplicate(int templateId)
	{
		return new PersonalNeedItem((sbyte)templateId, this);
	}
}

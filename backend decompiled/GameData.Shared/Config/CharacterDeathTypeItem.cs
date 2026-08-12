using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterDeathTypeItem : ConfigItem<CharacterDeathTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 默认经历
	/// - 支持自动添加的参数: 地点，杀人者，奇遇。此处不配置则默认不记录经历，可能为经历通过其它逻辑添加。
	/// </summary>
	public readonly short DefaultLifeRecord;

	/// <summary>
	/// 默认过月通知
	/// - 支持自动添加的参数: 地点，死亡者，奇遇。此处不配置则默认不记录经历，可能为经历通过其它逻辑添加。
	/// </summary>
	public readonly short DefaultMonthlyNotification;

	/// <summary>
	/// 只通知主角人群
	/// </summary>
	public readonly bool NotifyTaiwuPeopleOnly;

	/// <summary>
	/// 是否寻找埋葬者
	/// - 不寻找则固定为匆匆掩埋。
	/// </summary>
	public readonly bool FindUndertaker;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="defaultLifeRecord">默认经历 - 支持自动添加的参数: 地点，杀人者，奇遇。此处不配置则默认不记录经历，可能为经历通过其它逻辑添加。</param>
	/// <param name="defaultMonthlyNotification">默认过月通知 - 支持自动添加的参数: 地点，死亡者，奇遇。此处不配置则默认不记录经历，可能为经历通过其它逻辑添加。</param>
	/// <param name="notifyTaiwuPeopleOnly">只通知主角人群</param>
	/// <param name="findUndertaker">是否寻找埋葬者 - 不寻找则固定为匆匆掩埋。</param>
	public CharacterDeathTypeItem(short templateId, string name, short defaultLifeRecord, short defaultMonthlyNotification, bool notifyTaiwuPeopleOnly, bool findUndertaker)
	{
		TemplateId = templateId;
		Name = name;
		DefaultLifeRecord = defaultLifeRecord;
		DefaultMonthlyNotification = defaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = notifyTaiwuPeopleOnly;
		FindUndertaker = findUndertaker;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterDeathTypeItem()
	{
		TemplateId = 0;
		Name = null;
		DefaultLifeRecord = 0;
		DefaultMonthlyNotification = 0;
		NotifyTaiwuPeopleOnly = false;
		FindUndertaker = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterDeathTypeItem(short templateId, CharacterDeathTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		DefaultLifeRecord = other.DefaultLifeRecord;
		DefaultMonthlyNotification = other.DefaultMonthlyNotification;
		NotifyTaiwuPeopleOnly = other.NotifyTaiwuPeopleOnly;
		FindUndertaker = other.FindUndertaker;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterDeathTypeItem Duplicate(int templateId)
	{
		return new CharacterDeathTypeItem((short)templateId, this);
	}
}

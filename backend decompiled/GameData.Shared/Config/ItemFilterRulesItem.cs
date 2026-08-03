using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class ItemFilterRulesItem : ConfigItem<ItemFilterRulesItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 指定物品的id
	/// </summary>
	public readonly PresetItemTemplateId AppointId;

	/// <summary>
	/// 子类型
	/// </summary>
	public readonly List<PresetItemSubTypeWithGradeRange> AppointOrSubTypeCore;

	/// <summary>
	/// 指定库
	/// - 库中任意一个物品满足即可，匹配的物品组只有同类物品的多个不同品阶才能保证模板 ID 连续, 因此不要在一个库的一条匹配规则里同时匹配多类物品.其中该组的物品个数, 必须大于 0。
	/// </summary>
	public readonly List<PresetItemTemplateIdGroup> AppointOrIdCore;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="appointId">指定物品的id</param>
	/// <param name="appointOrSubTypeCore">子类型</param>
	/// <param name="appointOrIdCore">指定库 - 库中任意一个物品满足即可，匹配的物品组只有同类物品的多个不同品阶才能保证模板 ID 连续, 因此不要在一个库的一条匹配规则里同时匹配多类物品.其中该组的物品个数, 必须大于 0。</param>
	public ItemFilterRulesItem(short templateId, PresetItemTemplateId appointId, List<PresetItemSubTypeWithGradeRange> appointOrSubTypeCore, List<PresetItemTemplateIdGroup> appointOrIdCore)
	{
		TemplateId = templateId;
		AppointId = appointId;
		AppointOrSubTypeCore = appointOrSubTypeCore;
		AppointOrIdCore = appointOrIdCore;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ItemFilterRulesItem()
	{
		TemplateId = 0;
		AppointId = new PresetItemTemplateId("Misc", -1);
		AppointOrSubTypeCore = new List<PresetItemSubTypeWithGradeRange>();
		AppointOrIdCore = new List<PresetItemTemplateIdGroup>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ItemFilterRulesItem(short templateId, ItemFilterRulesItem other)
	{
		TemplateId = templateId;
		AppointId = other.AppointId;
		AppointOrSubTypeCore = other.AppointOrSubTypeCore;
		AppointOrIdCore = other.AppointOrIdCore;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ItemFilterRulesItem Duplicate(int templateId)
	{
		return new ItemFilterRulesItem((short)templateId, this);
	}
}

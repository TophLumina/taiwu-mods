using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakGridListItem : ConfigItem<SkillBreakGridListItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 刚正总纲属性加成突破格列表
	/// - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}
	/// </summary>
	public readonly List<BreakGrid> BreakGridListJust;

	/// <summary>
	/// 仁善总纲属性加成突破格列表
	/// - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}
	/// </summary>
	public readonly List<BreakGrid> BreakGridListKind;

	/// <summary>
	/// 中庸总纲属性加成突破格列表
	/// - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}
	/// </summary>
	public readonly List<BreakGrid> BreakGridListEven;

	/// <summary>
	/// 叛逆总纲属性加成突破格列表
	/// - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}
	/// </summary>
	public readonly List<BreakGrid> BreakGridListRebel;

	/// <summary>
	/// 唯我总纲属性加成突破格列表
	/// - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}
	/// </summary>
	public readonly List<BreakGrid> BreakGridListEgoistic;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="breakGridListJust">刚正总纲属性加成突破格列表 - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}</param>
	/// <param name="breakGridListKind">仁善总纲属性加成突破格列表 - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}</param>
	/// <param name="breakGridListEven">中庸总纲属性加成突破格列表 - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}</param>
	/// <param name="breakGridListRebel">叛逆总纲属性加成突破格列表 - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}</param>
	/// <param name="breakGridListEgoistic">唯我总纲属性加成突破格列表 - 单个突破格数据格式：{类型（SkillBreakPlateGridBonusType表中的模板ID）,数量}</param>
	public SkillBreakGridListItem(short templateId, List<BreakGrid> breakGridListJust, List<BreakGrid> breakGridListKind, List<BreakGrid> breakGridListEven, List<BreakGrid> breakGridListRebel, List<BreakGrid> breakGridListEgoistic)
	{
		TemplateId = templateId;
		BreakGridListJust = breakGridListJust;
		BreakGridListKind = breakGridListKind;
		BreakGridListEven = breakGridListEven;
		BreakGridListRebel = breakGridListRebel;
		BreakGridListEgoistic = breakGridListEgoistic;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakGridListItem()
	{
		TemplateId = 0;
		BreakGridListJust = new List<BreakGrid>();
		BreakGridListKind = new List<BreakGrid>();
		BreakGridListEven = new List<BreakGrid>();
		BreakGridListRebel = new List<BreakGrid>();
		BreakGridListEgoistic = new List<BreakGrid>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakGridListItem(short templateId, SkillBreakGridListItem other)
	{
		TemplateId = templateId;
		BreakGridListJust = other.BreakGridListJust;
		BreakGridListKind = other.BreakGridListKind;
		BreakGridListEven = other.BreakGridListEven;
		BreakGridListRebel = other.BreakGridListRebel;
		BreakGridListEgoistic = other.BreakGridListEgoistic;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakGridListItem Duplicate(int templateId)
	{
		return new SkillBreakGridListItem((short)templateId, this);
	}
}

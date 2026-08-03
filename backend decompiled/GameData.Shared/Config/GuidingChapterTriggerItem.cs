using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterTriggerItem : ConfigItem<GuidingChapterTriggerItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 对应引导章节
	/// </summary>
	public readonly List<short> Chapters;

	/// <summary>
	/// 额外整数参数1
	/// - 可在右侧注明这一列的含义
	/// </summary>
	public readonly int Int1;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="chapters">对应引导章节</param>
	/// <param name="int1">额外整数参数1 - 可在右侧注明这一列的含义</param>
	public GuidingChapterTriggerItem(short templateId, List<short> chapters, int int1)
	{
		TemplateId = templateId;
		Chapters = chapters;
		Int1 = int1;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public GuidingChapterTriggerItem()
	{
		TemplateId = 0;
		Chapters = new List<short>();
		Int1 = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public GuidingChapterTriggerItem(short templateId, GuidingChapterTriggerItem other)
	{
		TemplateId = templateId;
		Chapters = other.Chapters;
		Int1 = other.Int1;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override GuidingChapterTriggerItem Duplicate(int templateId)
	{
		return new GuidingChapterTriggerItem((short)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class BigEventKeyItem : ConfigItem<BigEventKeyItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	public BigEventKeyItem(short templateId)
	{
		TemplateId = templateId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BigEventKeyItem()
	{
		TemplateId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BigEventKeyItem(short templateId, BigEventKeyItem other)
	{
		TemplateId = templateId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BigEventKeyItem Duplicate(int templateId)
	{
		return new BigEventKeyItem((short)templateId, this);
	}
}

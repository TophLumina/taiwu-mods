using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MinionGroupItem : ConfigItem<MinionGroupItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 手下
	/// - 关联到 Character 表
	/// </summary>
	public readonly List<short> Minions;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="minions">手下 - 关联到 Character 表</param>
	public MinionGroupItem(short templateId, List<short> minions)
	{
		TemplateId = templateId;
		Minions = minions;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MinionGroupItem()
	{
		TemplateId = 0;
		Minions = new List<short>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MinionGroupItem(short templateId, MinionGroupItem other)
	{
		TemplateId = templateId;
		Minions = other.Minions;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MinionGroupItem Duplicate(int templateId)
	{
		return new MinionGroupItem((short)templateId, this);
	}
}

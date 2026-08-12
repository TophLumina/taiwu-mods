using System;
using Config.Common;

namespace Config;

[Serializable]
public class CatchThiefLevelItem : ConfigItem<CatchThiefLevelItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 级别
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 叫声音调
	/// </summary>
	public readonly sbyte SingPitch;

	/// <summary>
	/// 叫声范围
	/// </summary>
	public readonly short SingSize;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">说明</param>
	/// <param name="level">级别</param>
	/// <param name="singPitch">叫声音调</param>
	/// <param name="singSize">叫声范围</param>
	public CatchThiefLevelItem(sbyte templateId, string desc, sbyte level, sbyte singPitch, short singSize)
	{
		TemplateId = templateId;
		Desc = desc;
		Level = level;
		SingPitch = singPitch;
		SingSize = singSize;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CatchThiefLevelItem()
	{
		TemplateId = 0;
		Desc = null;
		Level = 0;
		SingPitch = 0;
		SingSize = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CatchThiefLevelItem(sbyte templateId, CatchThiefLevelItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Level = other.Level;
		SingPitch = other.SingPitch;
		SingSize = other.SingSize;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CatchThiefLevelItem Duplicate(int templateId)
	{
		return new CatchThiefLevelItem((sbyte)templateId, this);
	}
}

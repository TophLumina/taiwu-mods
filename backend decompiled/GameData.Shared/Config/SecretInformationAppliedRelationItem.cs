using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedRelationItem : ConfigItem<SecretInformationAppliedRelationItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 关系名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">关系名称</param>
	public SecretInformationAppliedRelationItem(sbyte templateId, string name)
	{
		TemplateId = templateId;
		Name = name;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationAppliedRelationItem()
	{
		TemplateId = 0;
		Name = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationAppliedRelationItem(sbyte templateId, SecretInformationAppliedRelationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationAppliedRelationItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedRelationItem((sbyte)templateId, this);
	}
}

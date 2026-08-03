using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreationGroupItem : ConfigItem<WorldCreationGroupItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 图片
	/// </summary>
	public readonly string Image;

	/// <summary>
	/// 对应世界细节
	/// </summary>
	public readonly byte[] WorldCreations;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="image">图片</param>
	/// <param name="worldCreations">对应世界细节</param>
	public WorldCreationGroupItem(sbyte templateId, string name, string image, byte[] worldCreations)
	{
		TemplateId = templateId;
		Name = name;
		Image = image;
		WorldCreations = worldCreations;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WorldCreationGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Image = null;
		WorldCreations = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WorldCreationGroupItem(sbyte templateId, WorldCreationGroupItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Image = other.Image;
		WorldCreations = other.WorldCreations;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WorldCreationGroupItem Duplicate(int templateId)
	{
		return new WorldCreationGroupItem((sbyte)templateId, this);
	}
}

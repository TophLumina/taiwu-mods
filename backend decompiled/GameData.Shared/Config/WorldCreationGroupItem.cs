using System;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreationGroupItem : ConfigItem<WorldCreationGroupItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Image;

	public readonly byte[] WorldCreations;

	public WorldCreationGroupItem(sbyte templateId, string name, string image, byte[] worldCreations)
	{
		TemplateId = templateId;
		Name = name;
		Image = image;
		WorldCreations = worldCreations;
	}

	public WorldCreationGroupItem()
	{
		TemplateId = 0;
		Name = null;
		Image = null;
		WorldCreations = null;
	}

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

	public override WorldCreationGroupItem Duplicate(int templateId)
	{
		return new WorldCreationGroupItem((sbyte)templateId, this);
	}
}

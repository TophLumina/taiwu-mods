using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapRouteItem : ConfigItem<MapRouteItem, short>
{
	public readonly short TemplateId;

	public readonly string InternalName;

	public readonly short FromId;

	public readonly short ToId;

	public readonly float[] PathLoc;

	public readonly float[][] Path;

	public readonly short[] ExtraFromId;

	public readonly short[] ExtraToId;

	public MapRouteItem(short templateId, string internalName, short fromId, short toId, float[] pathLoc, float[][] path, short[] extraFromId, short[] extraToId)
	{
		TemplateId = templateId;
		InternalName = internalName;
		FromId = fromId;
		ToId = toId;
		PathLoc = pathLoc;
		Path = path;
		ExtraFromId = extraFromId;
		ExtraToId = extraToId;
	}

	public MapRouteItem()
	{
		TemplateId = 0;
		InternalName = null;
		FromId = 0;
		ToId = 0;
		PathLoc = null;
		Path = null;
		ExtraFromId = null;
		ExtraToId = null;
	}

	public MapRouteItem(short templateId, MapRouteItem other)
	{
		TemplateId = templateId;
		InternalName = other.InternalName;
		FromId = other.FromId;
		ToId = other.ToId;
		PathLoc = other.PathLoc;
		Path = other.Path;
		ExtraFromId = other.ExtraFromId;
		ExtraToId = other.ExtraToId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapRouteItem Duplicate(int templateId)
	{
		return new MapRouteItem((short)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapRouteItem : ConfigItem<MapRouteItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 地点名
	/// </summary>
	public readonly string InternalName;

	/// <summary>
	/// 起点地区
	/// </summary>
	public readonly short FromId;

	/// <summary>
	/// 终点地区
	/// </summary>
	public readonly short ToId;

	/// <summary>
	/// 路径位置
	/// </summary>
	public readonly float[] PathLoc;

	/// <summary>
	/// 途经点
	/// </summary>
	public readonly float[][] Path;

	/// <summary>
	/// 额外起点
	/// - 不为空时，起点可以视为这些节点之一
	/// </summary>
	public readonly short[] ExtraFromId;

	/// <summary>
	/// 额外终点
	/// - 不为空时，终点可以视为这些节点之一
	/// </summary>
	public readonly short[] ExtraToId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="internalName">地点名</param>
	/// <param name="fromId">起点地区</param>
	/// <param name="toId">终点地区</param>
	/// <param name="pathLoc">路径位置</param>
	/// <param name="path">途经点</param>
	/// <param name="extraFromId">额外起点 - 不为空时，起点可以视为这些节点之一</param>
	/// <param name="extraToId">额外终点 - 不为空时，终点可以视为这些节点之一</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapRouteItem Duplicate(int templateId)
	{
		return new MapRouteItem((short)templateId, this);
	}
}

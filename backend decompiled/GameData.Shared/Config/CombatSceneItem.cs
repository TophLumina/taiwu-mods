using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSceneItem : ConfigItem<CombatSceneItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 场景预制体列表
	/// </summary>
	public readonly List<string> PrefabPath;

	/// <summary>
	/// 显示名
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 是否存在冬季资源
	/// </summary>
	public readonly bool HasWinterResource;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="prefabPath">场景预制体列表</param>
	/// <param name="name">显示名</param>
	/// <param name="hasWinterResource">是否存在冬季资源</param>
	public CombatSceneItem(short templateId, List<string> prefabPath, string name, bool hasWinterResource)
	{
		TemplateId = templateId;
		PrefabPath = prefabPath;
		Name = name;
		HasWinterResource = hasWinterResource;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatSceneItem()
	{
		TemplateId = 0;
		PrefabPath = null;
		Name = null;
		HasWinterResource = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatSceneItem(short templateId, CombatSceneItem other)
	{
		TemplateId = templateId;
		PrefabPath = other.PrefabPath;
		Name = other.Name;
		HasWinterResource = other.HasWinterResource;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatSceneItem Duplicate(int templateId)
	{
		return new CombatSceneItem((short)templateId, this);
	}
}

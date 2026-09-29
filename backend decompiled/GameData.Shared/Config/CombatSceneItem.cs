using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSceneItem : ConfigItem<CombatSceneItem, short>
{
	public readonly short TemplateId;

	public readonly List<string> PrefabPath;

	public readonly string Name;

	public readonly bool HasWinterResource;

	public CombatSceneItem(short templateId, List<string> prefabPath, string name, bool hasWinterResource)
	{
		TemplateId = templateId;
		PrefabPath = prefabPath;
		Name = name;
		HasWinterResource = hasWinterResource;
	}

	public CombatSceneItem()
	{
		TemplateId = 0;
		PrefabPath = null;
		Name = null;
		HasWinterResource = false;
	}

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

	public override CombatSceneItem Duplicate(int templateId)
	{
		return new CombatSceneItem((short)templateId, this);
	}
}

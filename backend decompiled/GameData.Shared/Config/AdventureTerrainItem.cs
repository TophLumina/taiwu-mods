using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureTerrainItem : ConfigItem<AdventureTerrainItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Img;

	public readonly string FlatImg;

	public readonly string EventBack;

	public readonly short CombatSceneId;

	public readonly List<short> EvtWeights;

	public AdventureTerrainItem(sbyte templateId, string name, string desc, string img, string flatImg, string eventBack, short combatSceneId, List<short> evtWeights)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Img = img;
		FlatImg = flatImg;
		EventBack = eventBack;
		CombatSceneId = combatSceneId;
		EvtWeights = evtWeights;
	}

	public AdventureTerrainItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Img = null;
		FlatImg = null;
		EventBack = null;
		CombatSceneId = 0;
		EvtWeights = new List<short>();
	}

	public AdventureTerrainItem(sbyte templateId, AdventureTerrainItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Img = other.Img;
		FlatImg = other.FlatImg;
		EventBack = other.EventBack;
		CombatSceneId = other.CombatSceneId;
		EvtWeights = other.EvtWeights;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureTerrainItem Duplicate(int templateId)
	{
		return new AdventureTerrainItem((sbyte)templateId, this);
	}
}

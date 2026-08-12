using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureTerrainItem : ConfigItem<AdventureTerrainItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图像
	/// </summary>
	public readonly string Img;

	/// <summary>
	/// 扁平图像
	/// </summary>
	public readonly string FlatImg;

	/// <summary>
	/// 事件背景图
	/// - 当在此地格发生事件，且事件配置中没有指定事件背景图片，则会根据事件发生的地块来取对应的背景图片
	/// </summary>
	public readonly string EventBack;

	/// <summary>
	/// 战斗场景
	/// </summary>
	public readonly short CombatSceneId;

	/// <summary>
	/// 地形默认七元
	/// - 由辅助配置列组合，不可直接配置此列
	/// </summary>
	public readonly List<short> EvtWeights;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="img">图像</param>
	/// <param name="flatImg">扁平图像</param>
	/// <param name="eventBack">事件背景图 - 当在此地格发生事件，且事件配置中没有指定事件背景图片，则会根据事件发生的地块来取对应的背景图片</param>
	/// <param name="combatSceneId">战斗场景</param>
	/// <param name="evtWeights">地形默认七元 - 由辅助配置列组合，不可直接配置此列</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AdventureTerrainItem Duplicate(int templateId)
	{
		return new AdventureTerrainItem((sbyte)templateId, this);
	}
}

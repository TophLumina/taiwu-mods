using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class TutorialChaptersItem : ConfigItem<TutorialChaptersItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string ToggleName;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 主角ID
	/// </summary>
	public readonly short MainCharacter;

	/// <summary>
	/// 预设地图区域Key
	/// </summary>
	public readonly string MapAreaPresetKey;

	/// <summary>
	/// 初始主角位置
	/// </summary>
	public readonly ByteCoordinate StartBlockCoordinate;

	/// <summary>
	/// 强制移动路径
	/// </summary>
	public readonly ByteCoordinate[] ForcePath;

	/// <summary>
	/// 开始月份
	/// </summary>
	public readonly short StartingMonth;

	/// <summary>
	/// 头
	/// </summary>
	public readonly string Head;

	/// <summary>
	/// 尾
	/// </summary>
	public readonly string Tail;

	/// <summary>
	/// 默认开启功能
	/// </summary>
	public readonly short[] OpenedFunctionTypes;

	/// <summary>
	/// 初始行囊道具
	/// </summary>
	public readonly List<PresetInventoryItem> PresetInventory;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="toggleName">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="mainCharacter">主角ID</param>
	/// <param name="mapAreaPresetKey">预设地图区域Key</param>
	/// <param name="startBlockCoordinate">初始主角位置</param>
	/// <param name="forcePath">强制移动路径</param>
	/// <param name="startingMonth">开始月份</param>
	/// <param name="head">头</param>
	/// <param name="tail">尾</param>
	/// <param name="openedFunctionTypes">默认开启功能</param>
	/// <param name="presetInventory">初始行囊道具</param>
	public TutorialChaptersItem(short templateId, string name, string toggleName, string desc, short mainCharacter, string mapAreaPresetKey, ByteCoordinate startBlockCoordinate, ByteCoordinate[] forcePath, short startingMonth, string head, string tail, short[] openedFunctionTypes, List<PresetInventoryItem> presetInventory)
	{
		TemplateId = templateId;
		Name = name;
		ToggleName = toggleName;
		Desc = desc;
		MainCharacter = mainCharacter;
		MapAreaPresetKey = mapAreaPresetKey;
		StartBlockCoordinate = startBlockCoordinate;
		ForcePath = forcePath;
		StartingMonth = startingMonth;
		Head = head;
		Tail = tail;
		OpenedFunctionTypes = openedFunctionTypes;
		PresetInventory = presetInventory;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TutorialChaptersItem()
	{
		TemplateId = 0;
		Name = null;
		ToggleName = null;
		Desc = null;
		MainCharacter = 0;
		MapAreaPresetKey = null;
		StartBlockCoordinate = default(ByteCoordinate);
		ForcePath = new ByteCoordinate[0];
		StartingMonth = -1;
		Head = null;
		Tail = null;
		OpenedFunctionTypes = new short[0];
		PresetInventory = new List<PresetInventoryItem>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TutorialChaptersItem(short templateId, TutorialChaptersItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ToggleName = other.ToggleName;
		Desc = other.Desc;
		MainCharacter = other.MainCharacter;
		MapAreaPresetKey = other.MapAreaPresetKey;
		StartBlockCoordinate = other.StartBlockCoordinate;
		ForcePath = other.ForcePath;
		StartingMonth = other.StartingMonth;
		Head = other.Head;
		Tail = other.Tail;
		OpenedFunctionTypes = other.OpenedFunctionTypes;
		PresetInventory = other.PresetInventory;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TutorialChaptersItem Duplicate(int templateId)
	{
		return new TutorialChaptersItem((short)templateId, this);
	}
}

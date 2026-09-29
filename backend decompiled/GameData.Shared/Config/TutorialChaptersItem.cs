using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class TutorialChaptersItem : ConfigItem<TutorialChaptersItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string ToggleName;

	public readonly string Desc;

	public readonly short MainCharacter;

	public readonly string MapAreaPresetKey;

	public readonly ByteCoordinate StartBlockCoordinate;

	public readonly ByteCoordinate[] ForcePath;

	public readonly short StartingMonth;

	public readonly string Head;

	public readonly string Tail;

	public readonly short[] OpenedFunctionTypes;

	public readonly List<PresetInventoryItem> PresetInventory;

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

	public override TutorialChaptersItem Duplicate(int templateId)
	{
		return new TutorialChaptersItem((short)templateId, this);
	}
}

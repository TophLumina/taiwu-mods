using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells;
using GameData.Utilities;

namespace Config;

[Serializable]
public class TaskConditionItem : ConfigItem<TaskConditionItem, int>
{
	public readonly int TemplateId;

	public readonly ETaskConditionType Type;

	public readonly bool IsReverseCondition;

	public readonly int IntParam;

	public readonly uint DlcAppId;

	public readonly string ArgBoxKey;

	public readonly IntPair ValueRange;

	public readonly int Adventure;

	public readonly List<PresetItemWithCount> Items;

	public readonly short CharacterTemplateId;

	public readonly ETaskConditionCharacterType CharacterType;

	public readonly ETaskConditionAreaType AreaType;

	public readonly sbyte StateTemplateId;

	public readonly sbyte Organization;

	public readonly short Feature;

	public readonly List<short> MapBlockList;

	public readonly short Building;

	public readonly int ProfessionSkill;

	public readonly int Task;

	public readonly List<int> OrTaskCondition;

	public readonly List<int> AndTaskCondition;

	public CharacterItem CharacterTemplate
	{
		[return: MaybeNull]
		get
		{
			return Character.Instance.GetItemOrDefault(CharacterTemplateId);
		}
	}

	public MapStateItem StateTemplate
	{
		[return: MaybeNull]
		get
		{
			return MapState.Instance.GetItemOrDefault(StateTemplateId);
		}
	}

	public TaskConditionItem(int templateId, ETaskConditionType type, bool isReverseCondition, int intParam, uint dlcAppId, string argBoxKey, IntPair valueRange, int adventure, List<PresetItemWithCount> items, short characterTemplateId, ETaskConditionCharacterType characterType, ETaskConditionAreaType areaType, sbyte stateTemplateId, sbyte organization, short feature, List<short> mapBlockList, short building, int professionSkill, int task, List<int> orTaskCondition, List<int> andTaskCondition)
	{
		TemplateId = templateId;
		Type = type;
		IsReverseCondition = isReverseCondition;
		IntParam = intParam;
		DlcAppId = dlcAppId;
		ArgBoxKey = argBoxKey;
		ValueRange = valueRange;
		Adventure = adventure;
		Items = items;
		CharacterTemplateId = characterTemplateId;
		CharacterType = characterType;
		AreaType = areaType;
		StateTemplateId = stateTemplateId;
		Organization = organization;
		Feature = feature;
		MapBlockList = mapBlockList;
		Building = building;
		ProfessionSkill = professionSkill;
		Task = task;
		OrTaskCondition = orTaskCondition;
		AndTaskCondition = andTaskCondition;
	}

	public TaskConditionItem()
	{
		TemplateId = 0;
		Type = ETaskConditionType.AdventureVisible;
		IsReverseCondition = false;
		IntParam = 0;
		DlcAppId = 0u;
		ArgBoxKey = null;
		ValueRange = new IntPair(0, 0);
		Adventure = 0;
		Items = new List<PresetItemWithCount>();
		CharacterTemplateId = 0;
		CharacterType = ETaskConditionCharacterType.Invalid;
		AreaType = ETaskConditionAreaType.Invalid;
		StateTemplateId = 0;
		Organization = 0;
		Feature = 0;
		MapBlockList = new List<short>();
		Building = 0;
		ProfessionSkill = 0;
		Task = 0;
		OrTaskCondition = new List<int>();
		AndTaskCondition = new List<int>();
	}

	public TaskConditionItem(int templateId, TaskConditionItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		IsReverseCondition = other.IsReverseCondition;
		IntParam = other.IntParam;
		DlcAppId = other.DlcAppId;
		ArgBoxKey = other.ArgBoxKey;
		ValueRange = other.ValueRange;
		Adventure = other.Adventure;
		Items = other.Items;
		CharacterTemplateId = other.CharacterTemplateId;
		CharacterType = other.CharacterType;
		AreaType = other.AreaType;
		StateTemplateId = other.StateTemplateId;
		Organization = other.Organization;
		Feature = other.Feature;
		MapBlockList = other.MapBlockList;
		Building = other.Building;
		ProfessionSkill = other.ProfessionSkill;
		Task = other.Task;
		OrTaskCondition = other.OrTaskCondition;
		AndTaskCondition = other.AndTaskCondition;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaskConditionItem Duplicate(int templateId)
	{
		return new TaskConditionItem(templateId, this);
	}
}

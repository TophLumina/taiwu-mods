using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Utilities;

namespace Config;

[Serializable]
public class TaskConditionItem : ConfigItem<TaskConditionItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 条件类型
	/// </summary>
	public readonly ETaskConditionType Type;

	/// <summary>
	/// 否定条件
	/// </summary>
	public readonly bool IsReverseCondition;

	/// <summary>
	/// Int参数
	/// </summary>
	public readonly int IntParam;

	/// <summary>
	/// 参数盒子Key
	/// - 根据条件类型区分是全局参数盒子还是地区主线参数盒子.如果为地区主线，还需要通过 组织 那一列的配置来指定对应的门派.
	/// </summary>
	public readonly string ArgBoxKey;

	/// <summary>
	/// 取值范围
	/// - 最小值包含，最大值不包含
	/// </summary>
	public readonly IntPair ValueRange;

	/// <summary>
	/// 奇遇参数
	/// </summary>
	public readonly int Adventure;

	/// <summary>
	/// 物品参数
	/// - 物品类型+预设id+数量，列表中任意物品符合条件则判定通过
	/// </summary>
	public readonly List<PresetItemWithCount> Items;

	/// <summary>
	/// 人物预设参数
	/// - 人物预设Id
	/// </summary>
	public readonly short CharacterTemplateId;

	/// <summary>
	/// 角色类型
	/// </summary>
	public readonly ETaskConditionCharacterType CharacterType;

	/// <summary>
	/// 区域类型
	/// </summary>
	public readonly ETaskConditionAreaType AreaType;

	/// <summary>
	/// 州域
	/// </summary>
	public readonly sbyte StateTemplateId;

	/// <summary>
	/// 组织
	/// </summary>
	public readonly sbyte Organization;

	/// <summary>
	/// 特性
	/// </summary>
	public readonly short Feature;

	/// <summary>
	/// 地格预设参数
	/// - 地格预设id列表，区域存在列表中任意id则判定通过
	/// </summary>
	public readonly List<short> MapBlockList;

	/// <summary>
	/// 产业建筑参数
	/// - 产业建筑预设Id
	/// </summary>
	public readonly short Building;

	/// <summary>
	/// 志向技能参数
	/// </summary>
	public readonly int ProfessionSkill;

	/// <summary>
	/// 任务参数
	/// </summary>
	public readonly int Task;

	/// <summary>
	/// 任务条件的或者组合
	/// - 该列如果不为空，则其他任何参数列的值都不会生效
	/// </summary>
	public readonly List<int> OrTaskCondition;

	/// <summary>
	/// 任务条件的并且组合
	/// - 该列如果不为空，则其他任何参数列的值都不会生效
	/// </summary>
	public readonly List<int> AndTaskCondition;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">条件类型</param>
	/// <param name="isReverseCondition">否定条件</param>
	/// <param name="intParam">Int参数</param>
	/// <param name="argBoxKey">参数盒子Key - 根据条件类型区分是全局参数盒子还是地区主线参数盒子.如果为地区主线，还需要通过 组织 那一列的配置来指定对应的门派.</param>
	/// <param name="valueRange">取值范围 - 最小值包含，最大值不包含</param>
	/// <param name="adventure">奇遇参数</param>
	/// <param name="items">物品参数 - 物品类型+预设id+数量，列表中任意物品符合条件则判定通过</param>
	/// <param name="characterTemplateId">人物预设参数 - 人物预设Id</param>
	/// <param name="characterType">角色类型</param>
	/// <param name="areaType">区域类型</param>
	/// <param name="stateTemplateId">州域</param>
	/// <param name="organization">组织</param>
	/// <param name="feature">特性</param>
	/// <param name="mapBlockList">地格预设参数 - 地格预设id列表，区域存在列表中任意id则判定通过</param>
	/// <param name="building">产业建筑参数 - 产业建筑预设Id</param>
	/// <param name="professionSkill">志向技能参数</param>
	/// <param name="task">任务参数</param>
	/// <param name="orTaskCondition">任务条件的或者组合 - 该列如果不为空，则其他任何参数列的值都不会生效</param>
	/// <param name="andTaskCondition">任务条件的并且组合 - 该列如果不为空，则其他任何参数列的值都不会生效</param>
	public TaskConditionItem(int templateId, ETaskConditionType type, bool isReverseCondition, int intParam, string argBoxKey, IntPair valueRange, int adventure, List<PresetItemWithCount> items, short characterTemplateId, ETaskConditionCharacterType characterType, ETaskConditionAreaType areaType, sbyte stateTemplateId, sbyte organization, short feature, List<short> mapBlockList, short building, int professionSkill, int task, List<int> orTaskCondition, List<int> andTaskCondition)
	{
		TemplateId = templateId;
		Type = type;
		IsReverseCondition = isReverseCondition;
		IntParam = intParam;
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaskConditionItem()
	{
		TemplateId = 0;
		Type = ETaskConditionType.AdventureVisible;
		IsReverseCondition = false;
		IntParam = 0;
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaskConditionItem(int templateId, TaskConditionItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		IsReverseCondition = other.IsReverseCondition;
		IntParam = other.IntParam;
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaskConditionItem Duplicate(int templateId)
	{
		return new TaskConditionItem(templateId, this);
	}
}

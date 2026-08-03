using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class ProtagonistFeatureItem : ConfigItem<ProtagonistFeatureItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 类别
	/// - 0: 经历特质, 1: 财富特质, 2: 技艺特质.
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 消耗点数
	/// - 选择该能力需要耗费多少点数
	/// </summary>
	public readonly sbyte Cost;

	/// <summary>
	/// 前置点数
	/// - 要选择该能力，必须在该类别花费指定点数，该能力才可以被选择
	/// </summary>
	public readonly sbyte PrerequisiteCost;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 功能说明
	/// </summary>
	public readonly string EffectDesc;

	/// <summary>
	/// 剑柄加成值
	/// - 配置形式：{加成项,是否百分比加成,加成值}
	/// </summary>
	public readonly List<PropertyAndValueAndModifyType> PermanentBonus;

	/// <summary>
	/// 自选道具组
	/// - 组内索引必须完全对应
	/// </summary>
	public readonly List<TemplateKey>[] CustomGroupItem;

	/// <summary>
	/// 自选道具组数量
	/// </summary>
	public readonly int[] CustomGroupCount;

	/// <summary>
	/// 自选道具组名称
	/// </summary>
	public readonly string[] CustomGroupName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类别 - 0: 经历特质, 1: 财富特质, 2: 技艺特质.</param>
	/// <param name="cost">消耗点数 - 选择该能力需要耗费多少点数</param>
	/// <param name="prerequisiteCost">前置点数 - 要选择该能力，必须在该类别花费指定点数，该能力才可以被选择</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="effectDesc">功能说明</param>
	/// <param name="permanentBonus">剑柄加成值 - 配置形式：{加成项,是否百分比加成,加成值}</param>
	/// <param name="customGroupItem">自选道具组 - 组内索引必须完全对应</param>
	/// <param name="customGroupCount">自选道具组数量</param>
	/// <param name="customGroupName">自选道具组名称</param>
	public ProtagonistFeatureItem(short templateId, sbyte type, sbyte cost, sbyte prerequisiteCost, string name, string desc, string effectDesc, List<PropertyAndValueAndModifyType> permanentBonus, List<TemplateKey>[] customGroupItem, int[] customGroupCount, string[] customGroupName)
	{
		TemplateId = templateId;
		Type = type;
		Cost = cost;
		PrerequisiteCost = prerequisiteCost;
		Name = name;
		Desc = desc;
		EffectDesc = effectDesc;
		PermanentBonus = permanentBonus;
		CustomGroupItem = customGroupItem;
		CustomGroupCount = customGroupCount;
		CustomGroupName = customGroupName;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ProtagonistFeatureItem()
	{
		TemplateId = 0;
		Type = 0;
		Cost = 0;
		PrerequisiteCost = 0;
		Name = null;
		Desc = null;
		EffectDesc = null;
		PermanentBonus = new List<PropertyAndValueAndModifyType>();
		CustomGroupItem = new List<TemplateKey>[0];
		CustomGroupCount = new int[0];
		CustomGroupName = new string[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ProtagonistFeatureItem(short templateId, ProtagonistFeatureItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Cost = other.Cost;
		PrerequisiteCost = other.PrerequisiteCost;
		Name = other.Name;
		Desc = other.Desc;
		EffectDesc = other.EffectDesc;
		PermanentBonus = other.PermanentBonus;
		CustomGroupItem = other.CustomGroupItem;
		CustomGroupCount = other.CustomGroupCount;
		CustomGroupName = other.CustomGroupName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ProtagonistFeatureItem Duplicate(int templateId)
	{
		return new ProtagonistFeatureItem((short)templateId, this);
	}
}

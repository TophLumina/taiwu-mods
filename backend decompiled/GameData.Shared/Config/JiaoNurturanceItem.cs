using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class JiaoNurturanceItem : ConfigItem<JiaoNurturanceItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 事件描述
	/// - {0}为蛟蛟名称，换行使用 \n，事件中根据繁育类型显示文本时使用
	/// </summary>
	public readonly string EventDesc;

	/// <summary>
	/// 消耗资源类型
	/// </summary>
	public readonly sbyte ResourceCostType;

	/// <summary>
	/// 消耗历练
	/// </summary>
	public readonly int ExpCost;

	/// <summary>
	/// 每月消耗资源量
	/// </summary>
	public readonly int ResourceCost;

	/// <summary>
	/// 养育完成所需月数
	/// </summary>
	public readonly short NurturanceCostMonth;

	/// <summary>
	/// 成长固定增加属性
	/// - 每达到一个成长阶段，固定增加的属性值
	/// </summary>
	public readonly List<IntPair> BasePropertyChange;

	/// <summary>
	/// 每阶段所需的月份数量
	/// </summary>
	public readonly short StageCostMonth;

	/// <summary>
	/// 养育动画
	/// </summary>
	public readonly string NurturanceAnimation;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="eventDesc">事件描述 - {0}为蛟蛟名称，换行使用 \n，事件中根据繁育类型显示文本时使用</param>
	/// <param name="resourceCostType">消耗资源类型</param>
	/// <param name="expCost">消耗历练</param>
	/// <param name="resourceCost">每月消耗资源量</param>
	/// <param name="nurturanceCostMonth">养育完成所需月数</param>
	/// <param name="basePropertyChange">成长固定增加属性 - 每达到一个成长阶段，固定增加的属性值</param>
	/// <param name="stageCostMonth">每阶段所需的月份数量</param>
	/// <param name="nurturanceAnimation">养育动画</param>
	public JiaoNurturanceItem(short templateId, string name, string eventDesc, sbyte resourceCostType, int expCost, int resourceCost, short nurturanceCostMonth, List<IntPair> basePropertyChange, short stageCostMonth, string nurturanceAnimation)
	{
		TemplateId = templateId;
		Name = name;
		EventDesc = eventDesc;
		ResourceCostType = resourceCostType;
		ExpCost = expCost;
		ResourceCost = resourceCost;
		NurturanceCostMonth = nurturanceCostMonth;
		BasePropertyChange = basePropertyChange;
		StageCostMonth = stageCostMonth;
		NurturanceAnimation = nurturanceAnimation;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JiaoNurturanceItem()
	{
		TemplateId = 0;
		Name = null;
		EventDesc = null;
		ResourceCostType = 0;
		ExpCost = -1;
		ResourceCost = 0;
		NurturanceCostMonth = 0;
		BasePropertyChange = new List<IntPair>();
		StageCostMonth = 1;
		NurturanceAnimation = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JiaoNurturanceItem(short templateId, JiaoNurturanceItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EventDesc = other.EventDesc;
		ResourceCostType = other.ResourceCostType;
		ExpCost = other.ExpCost;
		ResourceCost = other.ResourceCost;
		NurturanceCostMonth = other.NurturanceCostMonth;
		BasePropertyChange = other.BasePropertyChange;
		StageCostMonth = other.StageCostMonth;
		NurturanceAnimation = other.NurturanceAnimation;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JiaoNurturanceItem Duplicate(int templateId)
	{
		return new JiaoNurturanceItem((short)templateId, this);
	}
}

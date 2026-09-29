using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class JiaoNurturanceItem : ConfigItem<JiaoNurturanceItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string EventDesc;

	public readonly sbyte ResourceCostType;

	public readonly int ExpCost;

	public readonly int ResourceCost;

	public readonly short NurturanceCostMonth;

	public readonly List<IntPair> BasePropertyChange;

	public readonly short StageCostMonth;

	public readonly string NurturanceAnimation;

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

	public override JiaoNurturanceItem Duplicate(int templateId)
	{
		return new JiaoNurturanceItem((short)templateId, this);
	}
}

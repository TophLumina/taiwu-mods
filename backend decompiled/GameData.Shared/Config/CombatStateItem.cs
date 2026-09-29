using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class CombatStateItem : ConfigItem<CombatStateItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly List<CombatStateProperty> PropertyList;

	public readonly short ReverseState;

	public readonly string TipsDesc;

	public readonly string Desc;

	public CombatStateItem(short templateId, string name, List<CombatStateProperty> propertyList, short reverseState, string tipsDesc, string desc)
	{
		TemplateId = templateId;
		Name = name;
		PropertyList = propertyList;
		ReverseState = reverseState;
		TipsDesc = tipsDesc;
		Desc = desc;
	}

	public CombatStateItem()
	{
		TemplateId = 0;
		Name = null;
		PropertyList = new List<CombatStateProperty>();
		ReverseState = 0;
		TipsDesc = null;
		Desc = null;
	}

	public CombatStateItem(short templateId, CombatStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		PropertyList = other.PropertyList;
		ReverseState = other.ReverseState;
		TipsDesc = other.TipsDesc;
		Desc = other.Desc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatStateItem Duplicate(int templateId)
	{
		return new CombatStateItem((short)templateId, this);
	}
}

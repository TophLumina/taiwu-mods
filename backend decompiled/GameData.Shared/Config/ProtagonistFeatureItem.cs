using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class ProtagonistFeatureItem : ConfigItem<ProtagonistFeatureItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte Type;

	public readonly sbyte Cost;

	public readonly sbyte PrerequisiteCost;

	public readonly string Name;

	public readonly string Desc;

	public readonly string EffectDesc;

	public readonly List<PropertyAndValueAndModifyType> PermanentBonus;

	public readonly List<TemplateKey>[] CustomGroupItem;

	public readonly int[] CustomGroupCount;

	public readonly string[] CustomGroupName;

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

	public override ProtagonistFeatureItem Duplicate(int templateId)
	{
		return new ProtagonistFeatureItem((short)templateId, this);
	}
}

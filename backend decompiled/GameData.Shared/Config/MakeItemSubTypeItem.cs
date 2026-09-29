using System;
using Config.Common;
using Config.ConfigCells;
using GameData.Domains.Map;

namespace Config;

[Serializable]
public class MakeItemSubTypeItem : ConfigItem<MakeItemSubTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string FilterName;

	public readonly bool IsOdd;

	public readonly sbyte RefiningEffect;

	public readonly string Desc;

	public readonly short ExtraLifeSkill;

	public readonly string Icon;

	public readonly short Time;

	public readonly short ResourceTotalCount;

	public readonly MaterialResources MaxMaterialResources;

	public readonly MakeItemResult Result;

	public readonly sbyte WoodEffect;

	public readonly sbyte MetalEffect;

	public readonly sbyte JadeEffect;

	public readonly sbyte FabricEffect;

	public MakeItemSubTypeItem(short templateId, string name, string filterName, bool isOdd, sbyte refiningEffect, string desc, short extraLifeSkill, string icon, short time, short resourceTotalCount, MaterialResources maxMaterialResources, MakeItemResult result, sbyte woodEffect, sbyte metalEffect, sbyte jadeEffect, sbyte fabricEffect)
	{
		TemplateId = templateId;
		Name = name;
		FilterName = filterName;
		IsOdd = isOdd;
		RefiningEffect = refiningEffect;
		Desc = desc;
		ExtraLifeSkill = extraLifeSkill;
		Icon = icon;
		Time = time;
		ResourceTotalCount = resourceTotalCount;
		MaxMaterialResources = maxMaterialResources;
		Result = result;
		WoodEffect = woodEffect;
		MetalEffect = metalEffect;
		JadeEffect = jadeEffect;
		FabricEffect = fabricEffect;
	}

	public MakeItemSubTypeItem()
	{
		TemplateId = 0;
		Name = null;
		FilterName = null;
		IsOdd = false;
		RefiningEffect = 0;
		Desc = null;
		ExtraLifeSkill = 15;
		Icon = null;
		Time = 0;
		ResourceTotalCount = 50;
		MaxMaterialResources = new MaterialResources(default(short), default(short), default(short), default(short), default(short), default(short));
		Result = default(MakeItemResult);
		WoodEffect = -1;
		MetalEffect = -1;
		JadeEffect = -1;
		FabricEffect = -1;
	}

	public MakeItemSubTypeItem(short templateId, MakeItemSubTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		FilterName = other.FilterName;
		IsOdd = other.IsOdd;
		RefiningEffect = other.RefiningEffect;
		Desc = other.Desc;
		ExtraLifeSkill = other.ExtraLifeSkill;
		Icon = other.Icon;
		Time = other.Time;
		ResourceTotalCount = other.ResourceTotalCount;
		MaxMaterialResources = other.MaxMaterialResources;
		Result = other.Result;
		WoodEffect = other.WoodEffect;
		MetalEffect = other.MetalEffect;
		JadeEffect = other.JadeEffect;
		FabricEffect = other.FabricEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MakeItemSubTypeItem Duplicate(int templateId)
	{
		return new MakeItemSubTypeItem((short)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleArrangementItem : ConfigItem<VillagerRoleArrangementItem, short>
{
	public readonly short TemplateId;

	public readonly short VillagerRole;

	public readonly string ShortName;

	public readonly string Name;

	public readonly string DisplayIcon;

	public readonly string DisplayIcon2;

	public readonly string Desc;

	public readonly bool UnlockByChicken;

	public readonly bool InvisibleInGui;

	public readonly string DescName;

	public readonly string DescShort;

	public readonly string DescContent;

	public readonly string Illustration;

	public VillagerRoleArrangementItem(short templateId, short villagerRole, string shortName, string name, string displayIcon, string displayIcon2, string desc, bool unlockByChicken, bool invisibleInGui, string descName, string descShort, string descContent, string illustration)
	{
		TemplateId = templateId;
		VillagerRole = villagerRole;
		ShortName = shortName;
		Name = name;
		DisplayIcon = displayIcon;
		DisplayIcon2 = displayIcon2;
		Desc = desc;
		UnlockByChicken = unlockByChicken;
		InvisibleInGui = invisibleInGui;
		DescName = descName;
		DescShort = descShort;
		DescContent = descContent;
		Illustration = illustration;
	}

	public VillagerRoleArrangementItem()
	{
		TemplateId = 0;
		VillagerRole = 0;
		ShortName = null;
		Name = null;
		DisplayIcon = null;
		DisplayIcon2 = null;
		Desc = null;
		UnlockByChicken = false;
		InvisibleInGui = false;
		DescName = null;
		DescShort = null;
		DescContent = null;
		Illustration = null;
	}

	public VillagerRoleArrangementItem(short templateId, VillagerRoleArrangementItem other)
	{
		TemplateId = templateId;
		VillagerRole = other.VillagerRole;
		ShortName = other.ShortName;
		Name = other.Name;
		DisplayIcon = other.DisplayIcon;
		DisplayIcon2 = other.DisplayIcon2;
		Desc = other.Desc;
		UnlockByChicken = other.UnlockByChicken;
		InvisibleInGui = other.InvisibleInGui;
		DescName = other.DescName;
		DescShort = other.DescShort;
		DescContent = other.DescContent;
		Illustration = other.Illustration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override VillagerRoleArrangementItem Duplicate(int templateId)
	{
		return new VillagerRoleArrangementItem((short)templateId, this);
	}
}

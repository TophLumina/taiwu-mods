using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillItem : ConfigItem<LifeSkillItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Grade;

	public readonly string Desc;

	public readonly sbyte Type;

	public readonly byte InheritAttainmentAdiitionRate;

	public readonly short SkillBookId;

	public readonly List<sbyte> ProvidedReadingStrategies;

	public readonly int ReadingEventBonusRate;

	public readonly List<ShortList> UnlockBuildingList;

	public readonly sbyte[] UnlockInformationList;

	public SkillBookItem SkillBook
	{
		[return: MaybeNull]
		get
		{
			return Config.SkillBook.Instance.GetItemOrDefault(SkillBookId);
		}
	}

	public LifeSkillItem(short templateId, string name, sbyte grade, string desc, sbyte type, byte inheritAttainmentAdiitionRate, short skillBookId, List<sbyte> providedReadingStrategies, int readingEventBonusRate, List<ShortList> unlockBuildingList, sbyte[] unlockInformationList)
	{
		TemplateId = templateId;
		Name = name;
		Grade = grade;
		Desc = desc;
		Type = type;
		InheritAttainmentAdiitionRate = inheritAttainmentAdiitionRate;
		SkillBookId = skillBookId;
		ProvidedReadingStrategies = providedReadingStrategies;
		ReadingEventBonusRate = readingEventBonusRate;
		UnlockBuildingList = unlockBuildingList;
		UnlockInformationList = unlockInformationList;
	}

	public LifeSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Grade = 0;
		Desc = null;
		Type = 0;
		InheritAttainmentAdiitionRate = 0;
		SkillBookId = 0;
		ProvidedReadingStrategies = new List<sbyte>();
		ReadingEventBonusRate = 0;
		UnlockBuildingList = new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		};
		UnlockInformationList = null;
	}

	public LifeSkillItem(short templateId, LifeSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Grade = other.Grade;
		Desc = other.Desc;
		Type = other.Type;
		InheritAttainmentAdiitionRate = other.InheritAttainmentAdiitionRate;
		SkillBookId = other.SkillBookId;
		ProvidedReadingStrategies = other.ProvidedReadingStrategies;
		ReadingEventBonusRate = other.ReadingEventBonusRate;
		UnlockBuildingList = other.UnlockBuildingList;
		UnlockInformationList = other.UnlockInformationList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LifeSkillItem Duplicate(int templateId)
	{
		return new LifeSkillItem((short)templateId, this);
	}
}

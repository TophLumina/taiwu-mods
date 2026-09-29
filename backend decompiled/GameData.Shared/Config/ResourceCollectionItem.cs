using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceCollectionItem : ConfigItem<ResourceCollectionItem, short>
{
	public readonly short TemplateId;

	public readonly List<ShortList> ItemIdList;

	public readonly sbyte[] MaxAddGrade;

	public readonly sbyte[] GradeUpOdds;

	public ResourceCollectionItem(short templateId, List<ShortList> itemIdList, sbyte[] maxAddGrade, sbyte[] gradeUpOdds)
	{
		TemplateId = templateId;
		ItemIdList = itemIdList;
		MaxAddGrade = maxAddGrade;
		GradeUpOdds = gradeUpOdds;
	}

	public ResourceCollectionItem()
	{
		TemplateId = 0;
		ItemIdList = new List<ShortList>
		{
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1),
			new ShortList(-1)
		};
		MaxAddGrade = new sbyte[7] { -1, -1, -1, -1, -1, -1, -1 };
		GradeUpOdds = new sbyte[7] { -1, -1, -1, -1, -1, -1, -1 };
	}

	public ResourceCollectionItem(short templateId, ResourceCollectionItem other)
	{
		TemplateId = templateId;
		ItemIdList = other.ItemIdList;
		MaxAddGrade = other.MaxAddGrade;
		GradeUpOdds = other.GradeUpOdds;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ResourceCollectionItem Duplicate(int templateId)
	{
		return new ResourceCollectionItem((short)templateId, this);
	}
}

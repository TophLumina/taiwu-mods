using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceCollectionItem : ConfigItem<ResourceCollectionItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 采集物品列表
	/// - 采集每种资源时可能获得的材料道具ID，对应Item目录下Material表中的模板ID，经过品级加成后得到最终物品模板ID
	/// </summary>
	public readonly List<ShortList> ItemIdList;

	/// <summary>
	/// 品级提升次数上限
	/// </summary>
	public readonly sbyte[] MaxAddGrade;

	/// <summary>
	/// 品级提升概率
	/// </summary>
	public readonly sbyte[] GradeUpOdds;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="itemIdList">采集物品列表 - 采集每种资源时可能获得的材料道具ID，对应Item目录下Material表中的模板ID，经过品级加成后得到最终物品模板ID</param>
	/// <param name="maxAddGrade">品级提升次数上限</param>
	/// <param name="gradeUpOdds">品级提升概率</param>
	public ResourceCollectionItem(short templateId, List<ShortList> itemIdList, sbyte[] maxAddGrade, sbyte[] gradeUpOdds)
	{
		TemplateId = templateId;
		ItemIdList = itemIdList;
		MaxAddGrade = maxAddGrade;
		GradeUpOdds = gradeUpOdds;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ResourceCollectionItem Duplicate(int templateId)
	{
		return new ResourceCollectionItem((short)templateId, this);
	}
}

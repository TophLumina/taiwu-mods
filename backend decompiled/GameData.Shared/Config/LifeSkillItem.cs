using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillItem : ConfigItem<LifeSkillItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 品阶
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 类型
	/// - 琴、棋、书、画…
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 传授时的资质加成系数
	/// </summary>
	public readonly byte InheritAttainmentAdiitionRate;

	/// <summary>
	/// 技艺书籍道具ID
	/// - 对应SkillBook表中的模板ID
	/// </summary>
	public readonly short SkillBookId;

	/// <summary>
	/// 提供的研读策略
	/// - ReadingStrategy表中的TemplateId
	/// </summary>
	public readonly List<byte> ProvidedReadingStrategies;

	/// <summary>
	/// 灵光一闪的几率
	/// </summary>
	public readonly int ReadingEventBonusRate;

	/// <summary>
	/// 每页解锁建筑列表
	/// </summary>
	public readonly List<ShortList> UnlockBuildingList;

	/// <summary>
	/// 每页解锁见闻列表
	/// - 1 为此页会解锁见闻, 0 反之
	/// </summary>
	public readonly sbyte[] UnlockInformationList;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="grade">品阶</param>
	/// <param name="desc">说明</param>
	/// <param name="type">类型 - 琴、棋、书、画…</param>
	/// <param name="inheritAttainmentAdiitionRate">传授时的资质加成系数</param>
	/// <param name="skillBookId">技艺书籍道具ID - 对应SkillBook表中的模板ID</param>
	/// <param name="providedReadingStrategies">提供的研读策略 - ReadingStrategy表中的TemplateId</param>
	/// <param name="readingEventBonusRate">灵光一闪的几率</param>
	/// <param name="unlockBuildingList">每页解锁建筑列表</param>
	/// <param name="unlockInformationList">每页解锁见闻列表 - 1 为此页会解锁见闻, 0 反之</param>
	public LifeSkillItem(short templateId, string name, sbyte grade, string desc, sbyte type, byte inheritAttainmentAdiitionRate, short skillBookId, List<byte> providedReadingStrategies, int readingEventBonusRate, List<ShortList> unlockBuildingList, sbyte[] unlockInformationList)
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeSkillItem()
	{
		TemplateId = 0;
		Name = null;
		Grade = 0;
		Desc = null;
		Type = 0;
		InheritAttainmentAdiitionRate = 0;
		SkillBookId = 0;
		ProvidedReadingStrategies = new List<byte>();
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeSkillItem Duplicate(int templateId)
	{
		return new LifeSkillItem((short)templateId, this);
	}
}

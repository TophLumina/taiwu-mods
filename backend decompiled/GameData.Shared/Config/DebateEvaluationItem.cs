using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class DebateEvaluationItem : ConfigItem<DebateEvaluationItem, short>
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
	/// 结算评价说明
	/// </summary>
	public readonly string ResultTip;

	/// <summary>
	/// A类历练
	/// </summary>
	public readonly int ExpA;

	/// <summary>
	/// B类历练
	/// - 获得的历练 = 基础历练 * (100 + 所有战后评价的百分比B之和) / 100 * (100 + 所有战后评价的百分比C中最高值 + 所有战后评价的百分比C中最低值) / 100
	/// </summary>
	public readonly int ExpB;

	/// <summary>
	/// C类历练
	/// </summary>
	public readonly int ExpC;

	/// <summary>
	/// A类威望
	/// </summary>
	public readonly int AuthorityA;

	/// <summary>
	/// B类威望
	/// - 同历练值百分比参数
	/// </summary>
	public readonly int AuthorityB;

	/// <summary>
	/// C类威望
	/// </summary>
	public readonly int AuthorityC;

	/// <summary>
	/// A类好感增减
	/// </summary>
	public readonly short Favor;

	/// <summary>
	/// B类好感增加
	/// - 同历练值百分比参数
	/// </summary>
	public readonly int FavorIncreaseB;

	/// <summary>
	/// C类好感增加
	/// </summary>
	public readonly int FavorIncreaseC;

	/// <summary>
	/// B类好感减少
	/// </summary>
	public readonly int FavorDecreaseB;

	/// <summary>
	/// C类好感减少
	/// </summary>
	public readonly int FavorDecreaseC;

	/// <summary>
	/// 实战领悟
	/// </summary>
	public readonly int ReadRate;

	/// <summary>
	/// 实战周天
	/// </summary>
	public readonly int LoopRate;

	/// <summary>
	/// 名誉影响
	/// - 仅在正式地图有效，获得有名誉影响的评价时，战斗结束后人物获得相应的名誉词条
	/// </summary>
	public readonly short FameAction;

	/// <summary>
	/// 获得的遗惠点数与战胜战败时的百分比
	/// - 每条依次配置为“获得什么遗惠”、“战胜时该遗惠百分比”、“战败时该遗惠百分比”；各个加成之间取总和，总和大于零的遗惠会被添加给太吾
	/// </summary>
	public readonly List<LegacyPointReference> AddLegacyPoint;

	/// <summary>
	/// 心情影响
	/// </summary>
	public readonly int HappinessDelta;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="resultTip">结算评价说明</param>
	/// <param name="expA">A类历练</param>
	/// <param name="expB">B类历练 - 获得的历练 = 基础历练 * (100 + 所有战后评价的百分比B之和) / 100 * (100 + 所有战后评价的百分比C中最高值 + 所有战后评价的百分比C中最低值) / 100</param>
	/// <param name="expC">C类历练</param>
	/// <param name="authorityA">A类威望</param>
	/// <param name="authorityB">B类威望 - 同历练值百分比参数</param>
	/// <param name="authorityC">C类威望</param>
	/// <param name="favor">A类好感增减</param>
	/// <param name="favorIncreaseB">B类好感增加 - 同历练值百分比参数</param>
	/// <param name="favorIncreaseC">C类好感增加</param>
	/// <param name="favorDecreaseB">B类好感减少</param>
	/// <param name="favorDecreaseC">C类好感减少</param>
	/// <param name="readRate">实战领悟</param>
	/// <param name="loopRate">实战周天</param>
	/// <param name="fameAction">名誉影响 - 仅在正式地图有效，获得有名誉影响的评价时，战斗结束后人物获得相应的名誉词条</param>
	/// <param name="addLegacyPoint">获得的遗惠点数与战胜战败时的百分比 - 每条依次配置为“获得什么遗惠”、“战胜时该遗惠百分比”、“战败时该遗惠百分比”；各个加成之间取总和，总和大于零的遗惠会被添加给太吾</param>
	/// <param name="happinessDelta">心情影响</param>
	public DebateEvaluationItem(short templateId, string name, string resultTip, int expA, int expB, int expC, int authorityA, int authorityB, int authorityC, short favor, int favorIncreaseB, int favorIncreaseC, int favorDecreaseB, int favorDecreaseC, int readRate, int loopRate, short fameAction, List<LegacyPointReference> addLegacyPoint, int happinessDelta)
	{
		TemplateId = templateId;
		Name = name;
		ResultTip = resultTip;
		ExpA = expA;
		ExpB = expB;
		ExpC = expC;
		AuthorityA = authorityA;
		AuthorityB = authorityB;
		AuthorityC = authorityC;
		Favor = favor;
		FavorIncreaseB = favorIncreaseB;
		FavorIncreaseC = favorIncreaseC;
		FavorDecreaseB = favorDecreaseB;
		FavorDecreaseC = favorDecreaseC;
		ReadRate = readRate;
		LoopRate = loopRate;
		FameAction = fameAction;
		AddLegacyPoint = addLegacyPoint;
		HappinessDelta = happinessDelta;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateEvaluationItem()
	{
		TemplateId = 0;
		Name = null;
		ResultTip = null;
		ExpA = 0;
		ExpB = 0;
		ExpC = 0;
		AuthorityA = 0;
		AuthorityB = 0;
		AuthorityC = 0;
		Favor = 0;
		FavorIncreaseB = 0;
		FavorIncreaseC = 0;
		FavorDecreaseB = 0;
		FavorDecreaseC = 0;
		ReadRate = 0;
		LoopRate = 0;
		FameAction = 0;
		AddLegacyPoint = null;
		HappinessDelta = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateEvaluationItem(short templateId, DebateEvaluationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ResultTip = other.ResultTip;
		ExpA = other.ExpA;
		ExpB = other.ExpB;
		ExpC = other.ExpC;
		AuthorityA = other.AuthorityA;
		AuthorityB = other.AuthorityB;
		AuthorityC = other.AuthorityC;
		Favor = other.Favor;
		FavorIncreaseB = other.FavorIncreaseB;
		FavorIncreaseC = other.FavorIncreaseC;
		FavorDecreaseB = other.FavorDecreaseB;
		FavorDecreaseC = other.FavorDecreaseC;
		ReadRate = other.ReadRate;
		LoopRate = other.LoopRate;
		FameAction = other.FameAction;
		AddLegacyPoint = other.AddLegacyPoint;
		HappinessDelta = other.HappinessDelta;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateEvaluationItem Duplicate(int templateId)
	{
		return new DebateEvaluationItem((short)templateId, this);
	}
}

using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Taiwu;

namespace Config;

[Serializable]
public class CombatEvaluationItem : ConfigItem<CombatEvaluationItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 小村说明
	/// - 小村剧情中的说明（为了不显示相枢）
	/// </summary>
	public readonly string SmallVillageDesc;

	/// <summary>
	/// 可获得评价的战斗配置
	/// - 填空时不限制
	/// </summary>
	public readonly List<short> RequireCombatConfigs;

	/// <summary>
	/// 可获得评价的战斗类型
	/// - 0切磋，1恶斗，2死斗，3接招
	/// </summary>
	public readonly sbyte[] CombatTypes;

	/// <summary>
	/// 需要战胜
	/// - 只有在战斗胜利的情况下才会出现的评价
	/// </summary>
	public readonly bool NeedWin;

	/// <summary>
	/// 需求非 Boss 战
	/// - 只能在 CombatConfig 中 IsBossCombat 为 false 的战斗中出现
	/// </summary>
	public readonly bool RequireNotBoss;

	/// <summary>
	/// 游乐场限定
	/// - 练习模式木人战可获得该评价
	/// </summary>
	public readonly bool AvailableInPlayground;

	/// <summary>
	/// 额外判定条件
	/// - 若配置为无条件，则满足基本限定后必然产生对应评价，若需新增额外条件，应保持默认值未实装，待程序实装后由程序填入
	/// </summary>
	public readonly ECombatEvaluationExtraCheck ExtraCheck;

	/// <summary>
	/// 历练百分比B
	/// - 获得的历练 = 基础历练 * (100 + 所有战后评价的百分比B之和) / 100 * (100 + 所有战后评价的百分比C中最高值 + 所有战后评价的百分比C中最低值) / 100
	/// </summary>
	public readonly short ExpAddPercent;

	/// <summary>
	/// 历练百分比C
	/// </summary>
	public readonly short ExpTotalPercent;

	/// <summary>
	/// 威望百分比B
	/// - 同历练值百分比参数
	/// </summary>
	public readonly short AuthorityAddPercent;

	/// <summary>
	/// 威望百分比C
	/// </summary>
	public readonly short AuthorityTotalPercent;

	/// <summary>
	/// 允许获得实战值
	/// </summary>
	public readonly bool AllowProficiency;

	/// <summary>
	/// 地区恩义值
	/// </summary>
	public readonly short AreaSpiritualDebt;

	/// <summary>
	/// 名誉影响
	/// - 仅在正式地图有效，获得有名誉影响的评价时，战斗结束后人物获得相应的名誉词条
	/// </summary>
	public readonly short FameAction;

	/// <summary>
	/// 触发实战领悟的概率
	/// - 所有评价的实战领悟合计起来，为获得实战领悟的评价的几率，只能领悟所研读的功法秘籍
	/// </summary>
	public readonly int ReadInCombatRate;

	/// <summary>
	/// 触发实战周天的概率
	/// - 所有评价的实战周天合计起来，为获得实战领悟的评价的几率，只能运转所进行周天的内功
	/// </summary>
	public readonly int QiArtCombatRate;

	/// <summary>
	/// 获得的遗惠点数与战胜战败时的百分比
	/// - 每条依次配置为“获得什么遗惠”、“战胜时该遗惠百分比”、“战败时该遗惠百分比”；各个加成之间取总和，总和大于零的遗惠会被添加给太吾
	/// </summary>
	public readonly List<LegacyPointReference> AddLegacyPoint;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="smallVillageDesc">小村说明 - 小村剧情中的说明（为了不显示相枢）</param>
	/// <param name="requireCombatConfigs">可获得评价的战斗配置 - 填空时不限制</param>
	/// <param name="combatTypes">可获得评价的战斗类型 - 0切磋，1恶斗，2死斗，3接招</param>
	/// <param name="needWin">需要战胜 - 只有在战斗胜利的情况下才会出现的评价</param>
	/// <param name="requireNotBoss">需求非 Boss 战 - 只能在 CombatConfig 中 IsBossCombat 为 false 的战斗中出现</param>
	/// <param name="availableInPlayground">游乐场限定 - 练习模式木人战可获得该评价</param>
	/// <param name="extraCheck">额外判定条件 - 若配置为无条件，则满足基本限定后必然产生对应评价，若需新增额外条件，应保持默认值未实装，待程序实装后由程序填入</param>
	/// <param name="expAddPercent">历练百分比B - 获得的历练 = 基础历练 * (100 + 所有战后评价的百分比B之和) / 100 * (100 + 所有战后评价的百分比C中最高值 + 所有战后评价的百分比C中最低值) / 100</param>
	/// <param name="expTotalPercent">历练百分比C</param>
	/// <param name="authorityAddPercent">威望百分比B - 同历练值百分比参数</param>
	/// <param name="authorityTotalPercent">威望百分比C</param>
	/// <param name="allowProficiency">允许获得实战值</param>
	/// <param name="areaSpiritualDebt">地区恩义值</param>
	/// <param name="fameAction">名誉影响 - 仅在正式地图有效，获得有名誉影响的评价时，战斗结束后人物获得相应的名誉词条</param>
	/// <param name="readInCombatRate">触发实战领悟的概率 - 所有评价的实战领悟合计起来，为获得实战领悟的评价的几率，只能领悟所研读的功法秘籍</param>
	/// <param name="qiArtCombatRate">触发实战周天的概率 - 所有评价的实战周天合计起来，为获得实战领悟的评价的几率，只能运转所进行周天的内功</param>
	/// <param name="addLegacyPoint">获得的遗惠点数与战胜战败时的百分比 - 每条依次配置为“获得什么遗惠”、“战胜时该遗惠百分比”、“战败时该遗惠百分比”；各个加成之间取总和，总和大于零的遗惠会被添加给太吾</param>
	public CombatEvaluationItem(sbyte templateId, string name, string desc, string smallVillageDesc, List<short> requireCombatConfigs, sbyte[] combatTypes, bool needWin, bool requireNotBoss, bool availableInPlayground, ECombatEvaluationExtraCheck extraCheck, short expAddPercent, short expTotalPercent, short authorityAddPercent, short authorityTotalPercent, bool allowProficiency, short areaSpiritualDebt, short fameAction, int readInCombatRate, int qiArtCombatRate, List<LegacyPointReference> addLegacyPoint)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		SmallVillageDesc = smallVillageDesc;
		RequireCombatConfigs = requireCombatConfigs;
		CombatTypes = combatTypes;
		NeedWin = needWin;
		RequireNotBoss = requireNotBoss;
		AvailableInPlayground = availableInPlayground;
		ExtraCheck = extraCheck;
		ExpAddPercent = expAddPercent;
		ExpTotalPercent = expTotalPercent;
		AuthorityAddPercent = authorityAddPercent;
		AuthorityTotalPercent = authorityTotalPercent;
		AllowProficiency = allowProficiency;
		AreaSpiritualDebt = areaSpiritualDebt;
		FameAction = fameAction;
		ReadInCombatRate = readInCombatRate;
		QiArtCombatRate = qiArtCombatRate;
		AddLegacyPoint = addLegacyPoint;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatEvaluationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		SmallVillageDesc = null;
		RequireCombatConfigs = new List<short>();
		CombatTypes = new sbyte[4] { 0, 1, 2, 3 };
		NeedWin = false;
		RequireNotBoss = false;
		AvailableInPlayground = false;
		ExtraCheck = ECombatEvaluationExtraCheck.Invalid;
		ExpAddPercent = 0;
		ExpTotalPercent = 0;
		AuthorityAddPercent = 0;
		AuthorityTotalPercent = 0;
		AllowProficiency = true;
		AreaSpiritualDebt = 0;
		FameAction = 0;
		ReadInCombatRate = 0;
		QiArtCombatRate = 0;
		AddLegacyPoint = new List<LegacyPointReference>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatEvaluationItem(sbyte templateId, CombatEvaluationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		SmallVillageDesc = other.SmallVillageDesc;
		RequireCombatConfigs = other.RequireCombatConfigs;
		CombatTypes = other.CombatTypes;
		NeedWin = other.NeedWin;
		RequireNotBoss = other.RequireNotBoss;
		AvailableInPlayground = other.AvailableInPlayground;
		ExtraCheck = other.ExtraCheck;
		ExpAddPercent = other.ExpAddPercent;
		ExpTotalPercent = other.ExpTotalPercent;
		AuthorityAddPercent = other.AuthorityAddPercent;
		AuthorityTotalPercent = other.AuthorityTotalPercent;
		AllowProficiency = other.AllowProficiency;
		AreaSpiritualDebt = other.AreaSpiritualDebt;
		FameAction = other.FameAction;
		ReadInCombatRate = other.ReadInCombatRate;
		QiArtCombatRate = other.QiArtCombatRate;
		AddLegacyPoint = other.AddLegacyPoint;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatEvaluationItem Duplicate(int templateId)
	{
		return new CombatEvaluationItem((sbyte)templateId, this);
	}
}

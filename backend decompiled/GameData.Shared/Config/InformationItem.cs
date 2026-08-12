using System;
using Config.Common;

namespace Config;

[Serializable]
public class InformationItem : ConfigItem<InformationItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 简介 Id
	/// - 包含一至九级的差分
	/// </summary>
	public readonly short[] InfoIds;

	/// <summary>
	/// 是否为一般的见闻
	/// - 一般见闻有很多独占的规则，比如通过地区获取等
	/// </summary>
	public readonly bool IsGeneral;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 基础获取几率
	/// - 包含一至九级的差分
	/// </summary>
	public readonly sbyte[] BaseGainRate;

	/// <summary>
	/// 额外/升级几率
	/// - 包含一至九级的差分
	/// </summary>
	public readonly sbyte[] ExtraGainRate;

	/// <summary>
	/// 使用消耗时间
	/// </summary>
	public readonly sbyte CostDays;

	/// <summary>
	/// 是否按上限存储使用次数
	/// - 如果是，使用次数即为 N / M 模式；否则是 x N 的方式
	/// </summary>
	public readonly bool UsedCountWithMax;

	/// <summary>
	/// 使用效果倍率
	/// - 有效/普通/无效
	/// </summary>
	public readonly short[] EffectRate;

	/// <summary>
	/// 改变爱好类型因子(如果该因子未通过检定，则会改变厌恶类型)
	/// - 有效/普通/无效
	/// </summary>
	public readonly short ChangeLovingRate;

	/// <summary>
	/// 改变好恶的总几率
	/// - 通过此检定才能进行前两列的效果
	/// </summary>
	public readonly short[] ChangeLovingAndHatingRate;

	/// <summary>
	/// 改变理想门派几率
	/// - 有效/普通/无效
	/// </summary>
	public readonly short[] ChangeTowardOrganizationRate;

	/// <summary>
	/// 移除理想门派的几率（使用于地区主线，如果NPC听闻了该门派的衰落见闻且当前理想门派为该门派，会随机变为其他门派）
	/// - 有效/普通/无效
	/// </summary>
	public readonly short[] RemoveTowardOrganizationRate;

	/// <summary>
	/// 改变人物立场几率
	/// - 有效/普通/无效
	/// </summary>
	public readonly short[] ChangeBehaviorTypeRate;

	/// <summary>
	/// 获取威望值
	/// </summary>
	public readonly int Authority;

	/// <summary>
	/// 转化见闻 Id
	/// - 在某些特殊的见闻中使用
	/// - 目前在剑冢见闻中使用,获实-实不消耗次数的秘闻对应
	/// </summary>
	public readonly short TransformId;

	/// <summary>
	/// 是否增加级别字样
	/// - 是否在见闻界面末尾增加级别数字
	/// </summary>
	public readonly bool IsNeedShowLevel;

	/// <summary>
	/// 改变人物志向几率
	/// - 有效/普通/无效
	/// </summary>
	public readonly short[] ChangeProfessionRate;

	/// <summary>
	/// 获取等级
	/// - 剑冢见闻使用
	/// </summary>
	public readonly int GainLevel;

	/// <summary>
	/// 获取数量
	/// - 剑冢见闻使用
	/// </summary>
	public readonly int GainCount;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="infoIds">简介 Id - 包含一至九级的差分</param>
	/// <param name="isGeneral">是否为一般的见闻 - 一般见闻有很多独占的规则，比如通过地区获取等</param>
	/// <param name="type">类型</param>
	/// <param name="baseGainRate">基础获取几率 - 包含一至九级的差分</param>
	/// <param name="extraGainRate">额外/升级几率 - 包含一至九级的差分</param>
	/// <param name="costDays">使用消耗时间</param>
	/// <param name="usedCountWithMax">是否按上限存储使用次数 - 如果是，使用次数即为 N / M 模式；否则是 x N 的方式</param>
	/// <param name="effectRate">使用效果倍率 - 有效/普通/无效</param>
	/// <param name="changeLovingRate">改变爱好类型因子(如果该因子未通过检定，则会改变厌恶类型) - 有效/普通/无效</param>
	/// <param name="changeLovingAndHatingRate">改变好恶的总几率 - 通过此检定才能进行前两列的效果</param>
	/// <param name="changeTowardOrganizationRate">改变理想门派几率 - 有效/普通/无效</param>
	/// <param name="removeTowardOrganizationRate">移除理想门派的几率（使用于地区主线，如果NPC听闻了该门派的衰落见闻且当前理想门派为该门派，会随机变为其他门派） - 有效/普通/无效</param>
	/// <param name="changeBehaviorTypeRate">改变人物立场几率 - 有效/普通/无效</param>
	/// <param name="authority">获取威望值</param>
	/// <param name="transformId">转化见闻 Id - 在某些特殊的见闻中使用 目前在剑冢见闻中使用,获实-实不消耗次数的秘闻对应</param>
	/// <param name="isNeedShowLevel">是否增加级别字样 - 是否在见闻界面末尾增加级别数字</param>
	/// <param name="changeProfessionRate">改变人物志向几率 - 有效/普通/无效</param>
	/// <param name="gainLevel">获取等级 - 剑冢见闻使用</param>
	/// <param name="gainCount">获取数量 - 剑冢见闻使用</param>
	public InformationItem(short templateId, short[] infoIds, bool isGeneral, sbyte type, sbyte[] baseGainRate, sbyte[] extraGainRate, sbyte costDays, bool usedCountWithMax, short[] effectRate, short changeLovingRate, short[] changeLovingAndHatingRate, short[] changeTowardOrganizationRate, short[] removeTowardOrganizationRate, short[] changeBehaviorTypeRate, int authority, short transformId, bool isNeedShowLevel, short[] changeProfessionRate, int gainLevel, int gainCount)
	{
		TemplateId = templateId;
		InfoIds = infoIds;
		IsGeneral = isGeneral;
		Type = type;
		BaseGainRate = baseGainRate;
		ExtraGainRate = extraGainRate;
		CostDays = costDays;
		UsedCountWithMax = usedCountWithMax;
		EffectRate = effectRate;
		ChangeLovingRate = changeLovingRate;
		ChangeLovingAndHatingRate = changeLovingAndHatingRate;
		ChangeTowardOrganizationRate = changeTowardOrganizationRate;
		RemoveTowardOrganizationRate = removeTowardOrganizationRate;
		ChangeBehaviorTypeRate = changeBehaviorTypeRate;
		Authority = authority;
		TransformId = transformId;
		IsNeedShowLevel = isNeedShowLevel;
		ChangeProfessionRate = changeProfessionRate;
		GainLevel = gainLevel;
		GainCount = gainCount;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InformationItem()
	{
		TemplateId = 0;
		InfoIds = null;
		IsGeneral = false;
		Type = 0;
		BaseGainRate = null;
		ExtraGainRate = null;
		CostDays = 1;
		UsedCountWithMax = true;
		EffectRate = new short[3] { 300, 100, 0 };
		ChangeLovingRate = 0;
		ChangeLovingAndHatingRate = new short[3];
		ChangeTowardOrganizationRate = new short[3];
		RemoveTowardOrganizationRate = new short[3];
		ChangeBehaviorTypeRate = new short[3];
		Authority = 0;
		TransformId = 0;
		IsNeedShowLevel = true;
		ChangeProfessionRate = new short[3];
		GainLevel = 8;
		GainCount = 1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InformationItem(short templateId, InformationItem other)
	{
		TemplateId = templateId;
		InfoIds = other.InfoIds;
		IsGeneral = other.IsGeneral;
		Type = other.Type;
		BaseGainRate = other.BaseGainRate;
		ExtraGainRate = other.ExtraGainRate;
		CostDays = other.CostDays;
		UsedCountWithMax = other.UsedCountWithMax;
		EffectRate = other.EffectRate;
		ChangeLovingRate = other.ChangeLovingRate;
		ChangeLovingAndHatingRate = other.ChangeLovingAndHatingRate;
		ChangeTowardOrganizationRate = other.ChangeTowardOrganizationRate;
		RemoveTowardOrganizationRate = other.RemoveTowardOrganizationRate;
		ChangeBehaviorTypeRate = other.ChangeBehaviorTypeRate;
		Authority = other.Authority;
		TransformId = other.TransformId;
		IsNeedShowLevel = other.IsNeedShowLevel;
		ChangeProfessionRate = other.ChangeProfessionRate;
		GainLevel = other.GainLevel;
		GainCount = other.GainCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InformationItem Duplicate(int templateId)
	{
		return new InformationItem((short)templateId, this);
	}
}

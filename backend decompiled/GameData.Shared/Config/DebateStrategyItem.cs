using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateStrategyItem : ConfigItem<DebateStrategyItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 级别
	/// </summary>
	public readonly sbyte Level;

	/// <summary>
	/// 技艺类型
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 风格描述
	/// </summary>
	public readonly string StyleDesc;

	/// <summary>
	/// 论点策略描述
	/// </summary>
	public readonly string PawnEffectDesc;

	/// <summary>
	/// 使用禁用描述
	/// </summary>
	public readonly string NoTargetTip;

	/// <summary>
	/// 插画
	/// </summary>
	public readonly string Image;

	/// <summary>
	/// 标志类型
	/// </summary>
	public readonly EDebateStrategyMarkType MarkType;

	/// <summary>
	/// 消耗
	/// </summary>
	public readonly sbyte UsedCost;

	/// <summary>
	/// 是否仅生效一次
	/// </summary>
	public readonly bool IsOneTime;

	/// <summary>
	/// 较艺记录
	/// </summary>
	public readonly short DebateRecord;

	/// <summary>
	/// 触发类型
	/// </summary>
	public readonly EDebateStrategyTriggerType TriggerType;

	/// <summary>
	/// 效果列表
	/// - 效果名,值
	/// </summary>
	public readonly List<IntPair> EffectList;

	/// <summary>
	/// 目标列表
	/// - {{目标,最小数量,最大数量}}
	/// </summary>
	public readonly List<short[]> TargetList;

	/// <summary>
	/// 目标限制
	/// </summary>
	public readonly short TargetRestrict;

	/// <summary>
	/// 目标限制参数
	/// </summary>
	public readonly int TargetRestrictValue;

	/// <summary>
	/// 是否在落子前使用
	/// </summary>
	public readonly bool UseBeforeMakeMove;

	/// <summary>
	/// 是否用于解除逼宫
	/// </summary>
	public readonly bool AvoidCheckMate;

	/// <summary>
	/// 前期限制
	/// </summary>
	public readonly List<EDebateStrategyAiCheckType> EarlyLimits;

	/// <summary>
	/// 前期限制参数
	/// - 需要和限制一一对应，如果限制不需要参数则填0
	/// </summary>
	public readonly List<int> EarlyLimitParams;

	/// <summary>
	/// 中期限制
	/// </summary>
	public readonly List<EDebateStrategyAiCheckType> MidLimits;

	/// <summary>
	/// 中期限制参数
	/// </summary>
	public readonly List<int> MidLimitParams;

	/// <summary>
	/// 后期限制
	/// </summary>
	public readonly List<EDebateStrategyAiCheckType> LateLimits;

	/// <summary>
	/// 后期限制参数
	/// </summary>
	public readonly List<int> LateLimitParams;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="level">级别</param>
	/// <param name="lifeSkillType">技艺类型</param>
	/// <param name="desc">描述</param>
	/// <param name="styleDesc">风格描述</param>
	/// <param name="pawnEffectDesc">论点策略描述</param>
	/// <param name="noTargetTip">使用禁用描述</param>
	/// <param name="image">插画</param>
	/// <param name="markType">标志类型</param>
	/// <param name="usedCost">消耗</param>
	/// <param name="isOneTime">是否仅生效一次</param>
	/// <param name="debateRecord">较艺记录</param>
	/// <param name="triggerType">触发类型</param>
	/// <param name="effectList">效果列表 - 效果名,值</param>
	/// <param name="targetList">目标列表 - {{目标,最小数量,最大数量}}</param>
	/// <param name="targetRestrict">目标限制</param>
	/// <param name="targetRestrictValue">目标限制参数</param>
	/// <param name="useBeforeMakeMove">是否在落子前使用</param>
	/// <param name="avoidCheckMate">是否用于解除逼宫</param>
	/// <param name="earlyLimits">前期限制</param>
	/// <param name="earlyLimitParams">前期限制参数 - 需要和限制一一对应，如果限制不需要参数则填0</param>
	/// <param name="midLimits">中期限制</param>
	/// <param name="midLimitParams">中期限制参数</param>
	/// <param name="lateLimits">后期限制</param>
	/// <param name="lateLimitParams">后期限制参数</param>
	public DebateStrategyItem(short templateId, string name, sbyte level, sbyte lifeSkillType, string desc, string styleDesc, string pawnEffectDesc, string noTargetTip, string image, EDebateStrategyMarkType markType, sbyte usedCost, bool isOneTime, short debateRecord, EDebateStrategyTriggerType triggerType, List<IntPair> effectList, List<short[]> targetList, short targetRestrict, int targetRestrictValue, bool useBeforeMakeMove, bool avoidCheckMate, List<EDebateStrategyAiCheckType> earlyLimits, List<int> earlyLimitParams, List<EDebateStrategyAiCheckType> midLimits, List<int> midLimitParams, List<EDebateStrategyAiCheckType> lateLimits, List<int> lateLimitParams)
	{
		TemplateId = templateId;
		Name = name;
		Level = level;
		LifeSkillType = lifeSkillType;
		Desc = desc;
		StyleDesc = styleDesc;
		PawnEffectDesc = pawnEffectDesc;
		NoTargetTip = noTargetTip;
		Image = image;
		MarkType = markType;
		UsedCost = usedCost;
		IsOneTime = isOneTime;
		DebateRecord = debateRecord;
		TriggerType = triggerType;
		EffectList = effectList;
		TargetList = targetList;
		TargetRestrict = targetRestrict;
		TargetRestrictValue = targetRestrictValue;
		UseBeforeMakeMove = useBeforeMakeMove;
		AvoidCheckMate = avoidCheckMate;
		EarlyLimits = earlyLimits;
		EarlyLimitParams = earlyLimitParams;
		MidLimits = midLimits;
		MidLimitParams = midLimitParams;
		LateLimits = lateLimits;
		LateLimitParams = lateLimitParams;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateStrategyItem()
	{
		TemplateId = 0;
		Name = null;
		Level = 0;
		LifeSkillType = 0;
		Desc = null;
		StyleDesc = null;
		PawnEffectDesc = null;
		NoTargetTip = null;
		Image = null;
		MarkType = EDebateStrategyMarkType.Invalid;
		UsedCost = 0;
		IsOneTime = false;
		DebateRecord = 0;
		TriggerType = EDebateStrategyTriggerType.Invalid;
		EffectList = null;
		TargetList = null;
		TargetRestrict = 0;
		TargetRestrictValue = 1;
		UseBeforeMakeMove = false;
		AvoidCheckMate = false;
		EarlyLimits = null;
		EarlyLimitParams = null;
		MidLimits = null;
		MidLimitParams = null;
		LateLimits = null;
		LateLimitParams = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateStrategyItem(short templateId, DebateStrategyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Level = other.Level;
		LifeSkillType = other.LifeSkillType;
		Desc = other.Desc;
		StyleDesc = other.StyleDesc;
		PawnEffectDesc = other.PawnEffectDesc;
		NoTargetTip = other.NoTargetTip;
		Image = other.Image;
		MarkType = other.MarkType;
		UsedCost = other.UsedCost;
		IsOneTime = other.IsOneTime;
		DebateRecord = other.DebateRecord;
		TriggerType = other.TriggerType;
		EffectList = other.EffectList;
		TargetList = other.TargetList;
		TargetRestrict = other.TargetRestrict;
		TargetRestrictValue = other.TargetRestrictValue;
		UseBeforeMakeMove = other.UseBeforeMakeMove;
		AvoidCheckMate = other.AvoidCheckMate;
		EarlyLimits = other.EarlyLimits;
		EarlyLimitParams = other.EarlyLimitParams;
		MidLimits = other.MidLimits;
		MidLimitParams = other.MidLimitParams;
		LateLimits = other.LateLimits;
		LateLimitParams = other.LateLimitParams;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateStrategyItem Duplicate(int templateId)
	{
		return new DebateStrategyItem((short)templateId, this);
	}
}

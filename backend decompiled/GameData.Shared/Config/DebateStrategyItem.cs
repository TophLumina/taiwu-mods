using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Utilities;

namespace Config;

[Serializable]
public class DebateStrategyItem : ConfigItem<DebateStrategyItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Level;

	public readonly sbyte LifeSkillType;

	public readonly string Desc;

	public readonly string StyleDesc;

	public readonly string PawnEffectDesc;

	public readonly string NoTargetTip;

	public readonly string Image;

	public readonly EDebateStrategyMarkType MarkType;

	public readonly sbyte UsedCost;

	public readonly bool IsOneTime;

	public readonly short DebateRecord;

	public readonly EDebateStrategyTriggerType TriggerType;

	public readonly List<IntPair> EffectList;

	public readonly List<short[]> TargetList;

	public readonly short TargetRestrict;

	public readonly int TargetRestrictValue;

	public readonly bool UseBeforeMakeMove;

	public readonly bool AvoidCheckMate;

	public readonly List<EDebateStrategyAiCheckType> EarlyLimits;

	public readonly List<int> EarlyLimitParams;

	public readonly List<EDebateStrategyAiCheckType> MidLimits;

	public readonly List<int> MidLimitParams;

	public readonly List<EDebateStrategyAiCheckType> LateLimits;

	public readonly List<int> LateLimitParams;

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

	public override DebateStrategyItem Duplicate(int templateId)
	{
		return new DebateStrategyItem((short)templateId, this);
	}
}

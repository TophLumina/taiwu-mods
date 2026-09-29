using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillCombatEffectItem : ConfigItem<LifeSkillCombatEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly sbyte BaseAmount;

	public readonly sbyte MaxAmount;

	public readonly sbyte UsedCount;

	public readonly sbyte Level;

	public readonly ELifeSkillCombatEffectType Type;

	public readonly ELifeSkillCombatEffectGroup Group;

	public readonly bool IsInstant;

	public readonly bool IsSelectGrid;

	public readonly bool IsSelectBook;

	public readonly bool IsSaveCard;

	public readonly bool IsDecideAddEffect;

	public readonly bool IsGetPointAddEffect;

	public readonly List<sbyte> BanCardList;

	public readonly sbyte[] BehaviorTypeAmounts;

	public readonly sbyte[] PersonalityTypeRate;

	public readonly ELifeSkillCombatEffectSubEffect SubEffect;

	public readonly sbyte[] SubEffectParameters;

	public readonly string Imgae;

	public LifeSkillCombatEffectItem(sbyte templateId, string name, string desc, sbyte baseAmount, sbyte maxAmount, sbyte usedCount, sbyte level, ELifeSkillCombatEffectType type, ELifeSkillCombatEffectGroup group, bool isInstant, bool isSelectGrid, bool isSelectBook, bool isSaveCard, bool isDecideAddEffect, bool isGetPointAddEffect, List<sbyte> banCardList, sbyte[] behaviorTypeAmounts, sbyte[] personalityTypeRate, ELifeSkillCombatEffectSubEffect subEffect, sbyte[] subEffectParameters, string imgae)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		BaseAmount = baseAmount;
		MaxAmount = maxAmount;
		UsedCount = usedCount;
		Level = level;
		Type = type;
		Group = group;
		IsInstant = isInstant;
		IsSelectGrid = isSelectGrid;
		IsSelectBook = isSelectBook;
		IsSaveCard = isSaveCard;
		IsDecideAddEffect = isDecideAddEffect;
		IsGetPointAddEffect = isGetPointAddEffect;
		BanCardList = banCardList;
		BehaviorTypeAmounts = behaviorTypeAmounts;
		PersonalityTypeRate = personalityTypeRate;
		SubEffect = subEffect;
		SubEffectParameters = subEffectParameters;
		Imgae = imgae;
	}

	public LifeSkillCombatEffectItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		BaseAmount = 0;
		MaxAmount = 0;
		UsedCount = 0;
		Level = 0;
		Type = ELifeSkillCombatEffectType.Common;
		Group = ELifeSkillCombatEffectGroup.FlexibleFall;
		IsInstant = false;
		IsSelectGrid = false;
		IsSelectBook = false;
		IsSaveCard = false;
		IsDecideAddEffect = false;
		IsGetPointAddEffect = false;
		BanCardList = null;
		BehaviorTypeAmounts = null;
		PersonalityTypeRate = new sbyte[5];
		SubEffect = ELifeSkillCombatEffectSubEffect.SelfExtraQuestionAroundHouseThesisLow;
		SubEffectParameters = null;
		Imgae = null;
	}

	public LifeSkillCombatEffectItem(sbyte templateId, LifeSkillCombatEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		BaseAmount = other.BaseAmount;
		MaxAmount = other.MaxAmount;
		UsedCount = other.UsedCount;
		Level = other.Level;
		Type = other.Type;
		Group = other.Group;
		IsInstant = other.IsInstant;
		IsSelectGrid = other.IsSelectGrid;
		IsSelectBook = other.IsSelectBook;
		IsSaveCard = other.IsSaveCard;
		IsDecideAddEffect = other.IsDecideAddEffect;
		IsGetPointAddEffect = other.IsGetPointAddEffect;
		BanCardList = other.BanCardList;
		BehaviorTypeAmounts = other.BehaviorTypeAmounts;
		PersonalityTypeRate = other.PersonalityTypeRate;
		SubEffect = other.SubEffect;
		SubEffectParameters = other.SubEffectParameters;
		Imgae = other.Imgae;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LifeSkillCombatEffectItem Duplicate(int templateId)
	{
		return new LifeSkillCombatEffectItem((sbyte)templateId, this);
	}
}

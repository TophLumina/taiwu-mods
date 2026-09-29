using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleItem : ConfigItem<VillagerRoleItem, short>
{
	public readonly short TemplateId;

	public readonly short OrganizationMember;

	public readonly sbyte PersonalityType;

	public readonly NeedPersonality[] NeedPersonalityList;

	public readonly string[] EffectTextList;

	public readonly string[] EffectValueTextList;

	public readonly List<float[]> EffectDisplayValueList;

	public readonly int[] ExtraEffectIndices;

	public readonly short Clothing;

	public readonly string IdleIcon;

	public readonly short FeatureId;

	public readonly sbyte[] LearnableLifeSkillTypes;

	public readonly sbyte[] LearnableCombatSkillTypes;

	public readonly int MaxCount;

	public readonly int AuthorityCostParam;

	public readonly short[] AutoActions;

	public CharacterFeatureItem Feature
	{
		[return: MaybeNull]
		get
		{
			return CharacterFeature.Instance.GetItemOrDefault(FeatureId);
		}
	}

	public VillagerRoleItem(short templateId, short organizationMember, sbyte personalityType, NeedPersonality[] needPersonalityList, string[] effectTextList, string[] effectValueTextList, List<float[]> effectDisplayValueList, int[] extraEffectIndices, short clothing, string idleIcon, short featureId, sbyte[] learnableLifeSkillTypes, sbyte[] learnableCombatSkillTypes, int maxCount, int authorityCostParam, short[] autoActions)
	{
		TemplateId = templateId;
		OrganizationMember = organizationMember;
		PersonalityType = personalityType;
		NeedPersonalityList = needPersonalityList;
		EffectTextList = effectTextList;
		EffectValueTextList = effectValueTextList;
		EffectDisplayValueList = effectDisplayValueList;
		ExtraEffectIndices = extraEffectIndices;
		Clothing = clothing;
		IdleIcon = idleIcon;
		FeatureId = featureId;
		LearnableLifeSkillTypes = learnableLifeSkillTypes;
		LearnableCombatSkillTypes = learnableCombatSkillTypes;
		MaxCount = maxCount;
		AuthorityCostParam = authorityCostParam;
		AutoActions = autoActions;
	}

	public VillagerRoleItem()
	{
		TemplateId = 0;
		OrganizationMember = 0;
		PersonalityType = 0;
		NeedPersonalityList = new NeedPersonality[0];
		EffectTextList = new string[0];
		EffectValueTextList = new string[0];
		EffectDisplayValueList = new List<float[]>();
		ExtraEffectIndices = new int[0];
		Clothing = 0;
		IdleIcon = null;
		FeatureId = 0;
		LearnableLifeSkillTypes = new sbyte[0];
		LearnableCombatSkillTypes = new sbyte[0];
		MaxCount = int.MaxValue;
		AuthorityCostParam = 0;
		AutoActions = new short[0];
	}

	public VillagerRoleItem(short templateId, VillagerRoleItem other)
	{
		TemplateId = templateId;
		OrganizationMember = other.OrganizationMember;
		PersonalityType = other.PersonalityType;
		NeedPersonalityList = other.NeedPersonalityList;
		EffectTextList = other.EffectTextList;
		EffectValueTextList = other.EffectValueTextList;
		EffectDisplayValueList = other.EffectDisplayValueList;
		ExtraEffectIndices = other.ExtraEffectIndices;
		Clothing = other.Clothing;
		IdleIcon = other.IdleIcon;
		FeatureId = other.FeatureId;
		LearnableLifeSkillTypes = other.LearnableLifeSkillTypes;
		LearnableCombatSkillTypes = other.LearnableCombatSkillTypes;
		MaxCount = other.MaxCount;
		AuthorityCostParam = other.AuthorityCostParam;
		AutoActions = other.AutoActions;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override VillagerRoleItem Duplicate(int templateId)
	{
		return new VillagerRoleItem((short)templateId, this);
	}
}

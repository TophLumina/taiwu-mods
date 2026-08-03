using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleItem : ConfigItem<VillagerRoleItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 对应的OrganizationMember表的id
	/// </summary>
	public readonly short OrganizationMember;

	/// <summary>
	/// 对应七元类型
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 解锁额外效果需要的七元
	/// </summary>
	public readonly NeedPersonality[] NeedPersonalityList;

	/// <summary>
	/// 效果文本列表
	/// </summary>
	public readonly string[] EffectTextList;

	/// <summary>
	/// 效果数值显示文本
	/// </summary>
	public readonly string[] EffectValueTextList;

	/// <summary>
	/// 效果显示数值计算
	/// - 类型对应NeedPersonalityList中的顺序，按照Ax+By的形式，这里配置值是系数A和B
	/// </summary>
	public readonly List<float[]> EffectDisplayValueList;

	/// <summary>
	/// 哪些是额外效果
	/// - EffectTextList的下标
	/// </summary>
	public readonly int[] ExtraEffectIndices;

	/// <summary>
	/// 身份衣装
	/// </summary>
	public readonly short Clothing;

	/// <summary>
	/// 待命图标
	/// </summary>
	public readonly string IdleIcon;

	/// <summary>
	/// 角色特性
	/// </summary>
	public readonly short FeatureId;

	/// <summary>
	/// 可学技艺类型
	/// </summary>
	public readonly sbyte[] LearnableLifeSkillTypes;

	/// <summary>
	/// 可学武学类型
	/// </summary>
	public readonly sbyte[] LearnableCombatSkillTypes;

	/// <summary>
	/// 最大数目
	/// </summary>
	public readonly int MaxCount;

	/// <summary>
	/// 威望消耗参数
	/// - 授予身份时计算威望消耗的参数
	/// </summary>
	public readonly int AuthorityCostParam;

	/// <summary>
	/// 主动行为
	/// - 授予身份时计算威望消耗的参数
	/// </summary>
	public readonly short[] AutoActions;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="organizationMember">对应的OrganizationMember表的id</param>
	/// <param name="personalityType">对应七元类型</param>
	/// <param name="needPersonalityList">解锁额外效果需要的七元</param>
	/// <param name="effectTextList">效果文本列表</param>
	/// <param name="effectValueTextList">效果数值显示文本</param>
	/// <param name="effectDisplayValueList">效果显示数值计算 - 类型对应NeedPersonalityList中的顺序，按照Ax+By的形式，这里配置值是系数A和B</param>
	/// <param name="extraEffectIndices">哪些是额外效果 - EffectTextList的下标</param>
	/// <param name="clothing">身份衣装</param>
	/// <param name="idleIcon">待命图标</param>
	/// <param name="featureId">角色特性</param>
	/// <param name="learnableLifeSkillTypes">可学技艺类型</param>
	/// <param name="learnableCombatSkillTypes">可学武学类型</param>
	/// <param name="maxCount">最大数目</param>
	/// <param name="authorityCostParam">威望消耗参数 - 授予身份时计算威望消耗的参数</param>
	/// <param name="autoActions">主动行为 - 授予身份时计算威望消耗的参数</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override VillagerRoleItem Duplicate(int templateId)
	{
		return new VillagerRoleItem((short)templateId, this);
	}
}

using System;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class AgeEffectItem : ConfigItem<AgeEffectItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// - 实际为年龄. 100 岁以后的数据与 100 岁相同.
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 均衡
	/// - 所填数据为值的增减
	/// </summary>
	public readonly sbyte SkillQualificationAverage;

	/// <summary>
	/// 早熟
	/// - 所填数据为值的增减
	/// </summary>
	public readonly sbyte SkillQualificationPrecocious;

	/// <summary>
	/// 晚成
	/// - 所填数据为值的增减
	/// </summary>
	public readonly sbyte SkillQualificationLateBlooming;

	/// <summary>
	/// 主要属性
	/// - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.
	/// </summary>
	public readonly MainAttributes MainAttributes;

	/// <summary>
	/// 主要属性恢复
	/// - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.
	/// </summary>
	public readonly MainAttributes MainAttributesRecoveries;

	/// <summary>
	/// 男生育
	/// - 所填数据为值的增减
	/// </summary>
	public readonly short FertilityMale;

	/// <summary>
	/// 女生育
	/// - 所填数据为值的增减
	/// </summary>
	public readonly short FertilityFemale;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID - 实际为年龄. 100 岁以后的数据与 100 岁相同.</param>
	/// <param name="skillQualificationAverage">均衡 - 所填数据为值的增减</param>
	/// <param name="skillQualificationPrecocious">早熟 - 所填数据为值的增减</param>
	/// <param name="skillQualificationLateBlooming">晚成 - 所填数据为值的增减</param>
	/// <param name="mainAttributes">主要属性 - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.</param>
	/// <param name="mainAttributesRecoveries">主要属性恢复 - 此字段自动生成, 实际配置字段为前面从 "膂力" 到 "悟性" 的 6 个字段. 所填数据为百分比.</param>
	/// <param name="fertilityMale">男生育 - 所填数据为值的增减</param>
	/// <param name="fertilityFemale">女生育 - 所填数据为值的增减</param>
	public AgeEffectItem(sbyte templateId, sbyte skillQualificationAverage, sbyte skillQualificationPrecocious, sbyte skillQualificationLateBlooming, MainAttributes mainAttributes, MainAttributes mainAttributesRecoveries, short fertilityMale, short fertilityFemale)
	{
		TemplateId = templateId;
		SkillQualificationAverage = skillQualificationAverage;
		SkillQualificationPrecocious = skillQualificationPrecocious;
		SkillQualificationLateBlooming = skillQualificationLateBlooming;
		MainAttributes = mainAttributes;
		MainAttributesRecoveries = mainAttributesRecoveries;
		FertilityMale = fertilityMale;
		FertilityFemale = fertilityFemale;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public AgeEffectItem()
	{
		TemplateId = 0;
		SkillQualificationAverage = 0;
		SkillQualificationPrecocious = 0;
		SkillQualificationLateBlooming = 0;
		MainAttributes = new MainAttributes(100, 100, 100, 100, 100, 100);
		MainAttributesRecoveries = new MainAttributes(100, 100, 100, 100, 100, 100);
		FertilityMale = 0;
		FertilityFemale = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public AgeEffectItem(sbyte templateId, AgeEffectItem other)
	{
		TemplateId = templateId;
		SkillQualificationAverage = other.SkillQualificationAverage;
		SkillQualificationPrecocious = other.SkillQualificationPrecocious;
		SkillQualificationLateBlooming = other.SkillQualificationLateBlooming;
		MainAttributes = other.MainAttributes;
		MainAttributesRecoveries = other.MainAttributesRecoveries;
		FertilityMale = other.FertilityMale;
		FertilityFemale = other.FertilityFemale;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AgeEffectItem Duplicate(int templateId)
	{
		return new AgeEffectItem((sbyte)templateId, this);
	}
}

using System;
using Config.Common;

namespace Config;

[Serializable]
public class InformationInfoItem : ConfigItem<InformationInfoItem, short>
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
	/// 等级
	/// - 此列不用于生成、获得、使用见闻的等级判定，仅用于UI改变不同等级的见闻对应的底框的颜色与过月里文字颜色的显示
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 所属
	/// </summary>
	public readonly sbyte Oraganization;

	/// <summary>
	/// 技艺
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 西域
	/// </summary>
	public readonly short WesternRegionId;

	/// <summary>
	/// 剑冢
	/// </summary>
	public readonly EInformationInfoSwordInformationType SwordInformationType;

	/// <summary>
	/// 剑冢 Id
	/// </summary>
	public readonly sbyte SwordTombTemplateId;

	/// <summary>
	/// 志向
	/// </summary>
	public readonly sbyte Profession;

	/// <summary>
	/// 可消耗
	/// - 该字段默认TRUE，表示见闻是消耗的，可使用3次(见全局配置表)；FALSE代表使用见闻不消耗，可以使用无数次
	/// </summary>
	public readonly bool Consume;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 有效回答
	/// </summary>
	public readonly string EffectiveAnswer;

	/// <summary>
	/// 普通回答
	/// </summary>
	public readonly string NormalAnswer;

	/// <summary>
	/// 无效回答
	/// </summary>
	public readonly string InvalidAnswer;

	/// <summary>
	/// 五立场占位符
	/// </summary>
	public readonly string[] BehaviorTypePlaceHolders;

	/// <summary>
	/// 剑冢占位附
	/// </summary>
	public readonly string SwordTombPlaceHolder;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="grade">等级 - 此列不用于生成、获得、使用见闻的等级判定，仅用于UI改变不同等级的见闻对应的底框的颜色与过月里文字颜色的显示</param>
	/// <param name="oraganization">所属</param>
	/// <param name="lifeSkillType">技艺</param>
	/// <param name="westernRegionId">西域</param>
	/// <param name="swordInformationType">剑冢</param>
	/// <param name="swordTombTemplateId">剑冢 Id</param>
	/// <param name="profession">志向</param>
	/// <param name="consume">可消耗 - 该字段默认TRUE，表示见闻是消耗的，可使用3次(见全局配置表)；FALSE代表使用见闻不消耗，可以使用无数次</param>
	/// <param name="desc">说明</param>
	/// <param name="effectiveAnswer">有效回答</param>
	/// <param name="normalAnswer">普通回答</param>
	/// <param name="invalidAnswer">无效回答</param>
	/// <param name="behaviorTypePlaceHolders">五立场占位符</param>
	/// <param name="swordTombPlaceHolder">剑冢占位附</param>
	public InformationInfoItem(short templateId, string name, sbyte grade, sbyte oraganization, sbyte lifeSkillType, short westernRegionId, EInformationInfoSwordInformationType swordInformationType, sbyte swordTombTemplateId, sbyte profession, bool consume, string desc, string effectiveAnswer, string normalAnswer, string invalidAnswer, string[] behaviorTypePlaceHolders, string swordTombPlaceHolder)
	{
		TemplateId = templateId;
		Name = name;
		Grade = grade;
		Oraganization = oraganization;
		LifeSkillType = lifeSkillType;
		WesternRegionId = westernRegionId;
		SwordInformationType = swordInformationType;
		SwordTombTemplateId = swordTombTemplateId;
		Profession = profession;
		Consume = consume;
		Desc = desc;
		EffectiveAnswer = effectiveAnswer;
		NormalAnswer = normalAnswer;
		InvalidAnswer = invalidAnswer;
		BehaviorTypePlaceHolders = behaviorTypePlaceHolders;
		SwordTombPlaceHolder = swordTombPlaceHolder;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InformationInfoItem()
	{
		TemplateId = 0;
		Name = null;
		Grade = 0;
		Oraganization = 0;
		LifeSkillType = 0;
		WesternRegionId = 0;
		SwordInformationType = EInformationInfoSwordInformationType.Invalid;
		SwordTombTemplateId = 0;
		Profession = 0;
		Consume = true;
		Desc = null;
		EffectiveAnswer = null;
		NormalAnswer = null;
		InvalidAnswer = null;
		BehaviorTypePlaceHolders = null;
		SwordTombPlaceHolder = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InformationInfoItem(short templateId, InformationInfoItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Grade = other.Grade;
		Oraganization = other.Oraganization;
		LifeSkillType = other.LifeSkillType;
		WesternRegionId = other.WesternRegionId;
		SwordInformationType = other.SwordInformationType;
		SwordTombTemplateId = other.SwordTombTemplateId;
		Profession = other.Profession;
		Consume = other.Consume;
		Desc = other.Desc;
		EffectiveAnswer = other.EffectiveAnswer;
		NormalAnswer = other.NormalAnswer;
		InvalidAnswer = other.InvalidAnswer;
		BehaviorTypePlaceHolders = other.BehaviorTypePlaceHolders;
		SwordTombPlaceHolder = other.SwordTombPlaceHolder;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InformationInfoItem Duplicate(int templateId)
	{
		return new InformationInfoItem((short)templateId, this);
	}
}

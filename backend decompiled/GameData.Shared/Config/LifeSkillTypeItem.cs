using System;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillTypeItem : ConfigItem<LifeSkillTypeItem, sbyte>
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
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 展示图标
	/// - 40*40
	/// </summary>
	public readonly string DisplayIcon;

	/// <summary>
	/// 稍大一圈的带勾线展示图标
	/// - 48*48
	/// </summary>
	public readonly string DisplayIconOutLine;

	/// <summary>
	/// 稍大一圈的展示图标
	/// - 90*90
	/// </summary>
	public readonly string DisplayIconBig;

	/// <summary>
	/// 背景插画
	/// </summary>
	public readonly string BackgroundTexture;

	/// <summary>
	/// Loading界面插画
	/// </summary>
	public readonly string LoadingTexture;

	/// <summary>
	/// 造诣特效贴图
	/// </summary>
	public readonly string AttainmentEffectTexture;

	/// <summary>
	/// 对应七元
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 对应见闻模板 Id
	/// </summary>
	public readonly short InformationTemplateId;

	/// <summary>
	/// 技艺列表
	/// - 对应技艺表LiveSkill中的模板ID
	/// </summary>
	public readonly short[] SkillList;

	/// <summary>
	/// 制造说明
	/// </summary>
	public readonly string MakeDesc;

	/// <summary>
	/// 较艺中的说法
	/// - 在较艺中显示人物对话时引用的说法
	/// </summary>
	public readonly string DialogInBattle;

	/// <summary>
	/// 加载页面可用
	/// - 0可用 1不可用
	/// </summary>
	public readonly byte AvailableOnLoading;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="icon">图标</param>
	/// <param name="displayIcon">展示图标 - 40*40</param>
	/// <param name="displayIconOutLine">稍大一圈的带勾线展示图标 - 48*48</param>
	/// <param name="displayIconBig">稍大一圈的展示图标 - 90*90</param>
	/// <param name="backgroundTexture">背景插画</param>
	/// <param name="loadingTexture">Loading界面插画</param>
	/// <param name="attainmentEffectTexture">造诣特效贴图</param>
	/// <param name="personalityType">对应七元</param>
	/// <param name="informationTemplateId">对应见闻模板 Id</param>
	/// <param name="skillList">技艺列表 - 对应技艺表LiveSkill中的模板ID</param>
	/// <param name="makeDesc">制造说明</param>
	/// <param name="dialogInBattle">较艺中的说法 - 在较艺中显示人物对话时引用的说法</param>
	/// <param name="availableOnLoading">加载页面可用 - 0可用 1不可用</param>
	public LifeSkillTypeItem(sbyte templateId, string name, string desc, string icon, string displayIcon, string displayIconOutLine, string displayIconBig, string backgroundTexture, string loadingTexture, string attainmentEffectTexture, sbyte personalityType, short informationTemplateId, short[] skillList, string makeDesc, string dialogInBattle, byte availableOnLoading)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		DisplayIcon = displayIcon;
		DisplayIconOutLine = displayIconOutLine;
		DisplayIconBig = displayIconBig;
		BackgroundTexture = backgroundTexture;
		LoadingTexture = loadingTexture;
		AttainmentEffectTexture = attainmentEffectTexture;
		PersonalityType = personalityType;
		InformationTemplateId = informationTemplateId;
		SkillList = skillList;
		MakeDesc = makeDesc;
		DialogInBattle = dialogInBattle;
		AvailableOnLoading = availableOnLoading;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeSkillTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		DisplayIcon = null;
		DisplayIconOutLine = null;
		DisplayIconBig = null;
		BackgroundTexture = null;
		LoadingTexture = null;
		AttainmentEffectTexture = null;
		PersonalityType = 0;
		InformationTemplateId = 0;
		SkillList = null;
		MakeDesc = null;
		DialogInBattle = null;
		AvailableOnLoading = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LifeSkillTypeItem(sbyte templateId, LifeSkillTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		DisplayIcon = other.DisplayIcon;
		DisplayIconOutLine = other.DisplayIconOutLine;
		DisplayIconBig = other.DisplayIconBig;
		BackgroundTexture = other.BackgroundTexture;
		LoadingTexture = other.LoadingTexture;
		AttainmentEffectTexture = other.AttainmentEffectTexture;
		PersonalityType = other.PersonalityType;
		InformationTemplateId = other.InformationTemplateId;
		SkillList = other.SkillList;
		MakeDesc = other.MakeDesc;
		DialogInBattle = other.DialogInBattle;
		AvailableOnLoading = other.AvailableOnLoading;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeSkillTypeItem Duplicate(int templateId)
	{
		return new LifeSkillTypeItem((sbyte)templateId, this);
	}
}

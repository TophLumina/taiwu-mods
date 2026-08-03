using System;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceTypeItem : ConfigItem<ResourceTypeItem, sbyte>
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
	/// 图片名前缀
	/// - 根据资源数量加上0~11后缀得到对应图片
	/// </summary>
	public readonly string ImgPrefix;

	/// <summary>
	/// 采集获取资源倍率
	/// </summary>
	public readonly sbyte CollectMultiplier;

	/// <summary>
	/// 每次采集后地块资源减少值
	/// </summary>
	public readonly sbyte ResourceReducePerCollection;

	/// <summary>
	/// 关联技艺类型
	/// - 对应技艺类型表LifeSkillType中的模板ID
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 资源迁移心材
	/// </summary>
	public readonly short[] PossibleBuildingCoreItem;

	/// <summary>
	/// 资源迁移升级心材
	/// </summary>
	public readonly short[] PossibleUpgradedBuildingCoreItem;

	/// <summary>
	/// 受击音效列表
	/// </summary>
	public readonly string[] HitSound;

	/// <summary>
	/// 疾行破风音效列表
	/// </summary>
	public readonly string[] WhooshSound;

	/// <summary>
	/// 震动音效列表
	/// </summary>
	public readonly string[] ShockSound;

	/// <summary>
	/// 脚步声音效列表
	/// </summary>
	public readonly string[] StepSound;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="icon">图标</param>
	/// <param name="imgPrefix">图片名前缀 - 根据资源数量加上0~11后缀得到对应图片</param>
	/// <param name="collectMultiplier">采集获取资源倍率</param>
	/// <param name="resourceReducePerCollection">每次采集后地块资源减少值</param>
	/// <param name="lifeSkillType">关联技艺类型 - 对应技艺类型表LifeSkillType中的模板ID</param>
	/// <param name="possibleBuildingCoreItem">资源迁移心材</param>
	/// <param name="possibleUpgradedBuildingCoreItem">资源迁移升级心材</param>
	/// <param name="hitSound">受击音效列表</param>
	/// <param name="whooshSound">疾行破风音效列表</param>
	/// <param name="shockSound">震动音效列表</param>
	/// <param name="stepSound">脚步声音效列表</param>
	public ResourceTypeItem(sbyte templateId, string name, string desc, string icon, string imgPrefix, sbyte collectMultiplier, sbyte resourceReducePerCollection, sbyte lifeSkillType, short[] possibleBuildingCoreItem, short[] possibleUpgradedBuildingCoreItem, string[] hitSound, string[] whooshSound, string[] shockSound, string[] stepSound)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		ImgPrefix = imgPrefix;
		CollectMultiplier = collectMultiplier;
		ResourceReducePerCollection = resourceReducePerCollection;
		LifeSkillType = lifeSkillType;
		PossibleBuildingCoreItem = possibleBuildingCoreItem;
		PossibleUpgradedBuildingCoreItem = possibleUpgradedBuildingCoreItem;
		HitSound = hitSound;
		WhooshSound = whooshSound;
		ShockSound = shockSound;
		StepSound = stepSound;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ResourceTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		ImgPrefix = null;
		CollectMultiplier = -1;
		ResourceReducePerCollection = -1;
		LifeSkillType = 0;
		PossibleBuildingCoreItem = new short[0];
		PossibleUpgradedBuildingCoreItem = new short[0];
		HitSound = new string[0];
		WhooshSound = new string[0];
		ShockSound = new string[0];
		StepSound = new string[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ResourceTypeItem(sbyte templateId, ResourceTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		ImgPrefix = other.ImgPrefix;
		CollectMultiplier = other.CollectMultiplier;
		ResourceReducePerCollection = other.ResourceReducePerCollection;
		LifeSkillType = other.LifeSkillType;
		PossibleBuildingCoreItem = other.PossibleBuildingCoreItem;
		PossibleUpgradedBuildingCoreItem = other.PossibleUpgradedBuildingCoreItem;
		HitSound = other.HitSound;
		WhooshSound = other.WhooshSound;
		ShockSound = other.ShockSound;
		StepSound = other.StepSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ResourceTypeItem Duplicate(int templateId)
	{
		return new ResourceTypeItem((sbyte)templateId, this);
	}
}

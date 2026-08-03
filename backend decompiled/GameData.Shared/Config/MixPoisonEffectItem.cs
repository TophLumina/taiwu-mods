using System;
using Config.Common;

namespace Config;

[Serializable]
public class MixPoisonEffectItem : ConfigItem<MixPoisonEffectItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 简述
	/// </summary>
	public readonly string ShortDesc;

	/// <summary>
	/// 药毒模板
	/// - 用来获取说明文本
	/// </summary>
	public readonly short MedicineId;

	/// <summary>
	/// 特效模板
	/// - 用来获取战中效果跳字文本
	/// </summary>
	public readonly short EffectId;

	/// <summary>
	/// 所需毒素标记类型
	/// </summary>
	public readonly sbyte[] HasPoisonTypes;

	/// <summary>
	/// 所需毒发类型
	/// </summary>
	public readonly sbyte[] AffectPoisonTypes;

	/// <summary>
	/// 瞬时生效
	/// </summary>
	public readonly bool InstantEffect;

	/// <summary>
	/// 生效经历
	/// </summary>
	public readonly short LifeRecord;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="shortDesc">简述</param>
	/// <param name="medicineId">药毒模板 - 用来获取说明文本</param>
	/// <param name="effectId">特效模板 - 用来获取战中效果跳字文本</param>
	/// <param name="hasPoisonTypes">所需毒素标记类型</param>
	/// <param name="affectPoisonTypes">所需毒发类型</param>
	/// <param name="instantEffect">瞬时生效</param>
	/// <param name="lifeRecord">生效经历</param>
	public MixPoisonEffectItem(sbyte templateId, string shortDesc, short medicineId, short effectId, sbyte[] hasPoisonTypes, sbyte[] affectPoisonTypes, bool instantEffect, short lifeRecord)
	{
		TemplateId = templateId;
		ShortDesc = shortDesc;
		MedicineId = medicineId;
		EffectId = effectId;
		HasPoisonTypes = hasPoisonTypes;
		AffectPoisonTypes = affectPoisonTypes;
		InstantEffect = instantEffect;
		LifeRecord = lifeRecord;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MixPoisonEffectItem()
	{
		TemplateId = 0;
		ShortDesc = null;
		MedicineId = 0;
		EffectId = 0;
		HasPoisonTypes = null;
		AffectPoisonTypes = null;
		InstantEffect = false;
		LifeRecord = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MixPoisonEffectItem(sbyte templateId, MixPoisonEffectItem other)
	{
		TemplateId = templateId;
		ShortDesc = other.ShortDesc;
		MedicineId = other.MedicineId;
		EffectId = other.EffectId;
		HasPoisonTypes = other.HasPoisonTypes;
		AffectPoisonTypes = other.AffectPoisonTypes;
		InstantEffect = other.InstantEffect;
		LifeRecord = other.LifeRecord;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MixPoisonEffectItem Duplicate(int templateId)
	{
		return new MixPoisonEffectItem((sbyte)templateId, this);
	}
}

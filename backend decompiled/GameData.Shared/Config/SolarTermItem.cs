using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SolarTermItem : ConfigItem<SolarTermItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 节气性质
	/// - 0为节气；1为中气
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 诗句
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 酒令
	/// </summary>
	public readonly string Poem;

	/// <summary>
	/// 图片
	/// </summary>
	public readonly string Image;

	/// <summary>
	/// 音效
	/// </summary>
	public readonly string Sound;

	/// <summary>
	/// 月
	/// - 取值范围 [1, 12], 在真实字段中会换算为以 0 开始的月份序号.
	/// </summary>
	public readonly sbyte Month;

	/// <summary>
	/// 功法增益
	/// - 会增益的五行类型. 0: 金, 1: 木, 2: 水, 3: 火, 4: 土, 5: 混元.
	/// </summary>
	public readonly List<byte> FiveElementsTypesOfCombatSkillBuff;

	/// <summary>
	/// 食物增益
	/// - 会增益的食物的原料的 ID. 参见 Material 表, 取值范围 [鸡蛋, 鲟鳇鱼].
	/// </summary>
	public readonly List<short> MaterialIdsOfFoodBuff;

	/// <summary>
	/// 毒效增益
	/// </summary>
	public readonly sbyte PoisonBuffType;

	/// <summary>
	/// 解毒增益
	/// </summary>
	public readonly sbyte DetoxBuffType;

	/// <summary>
	/// 治疗外伤增益
	/// </summary>
	public readonly bool OuterHealingBuff;

	/// <summary>
	/// 治疗内伤增益
	/// </summary>
	public readonly bool InnerHealingBuff;

	/// <summary>
	/// 调理内息增益
	/// </summary>
	public readonly bool QiDisorderRecoveringBuff;

	/// <summary>
	/// 恢复健康增益
	/// </summary>
	public readonly bool HealthBuff;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">节气性质 - 0为节气；1为中气</param>
	/// <param name="desc">诗句</param>
	/// <param name="poem">酒令</param>
	/// <param name="image">图片</param>
	/// <param name="sound">音效</param>
	/// <param name="month">月 - 取值范围 [1, 12], 在真实字段中会换算为以 0 开始的月份序号.</param>
	/// <param name="fiveElementsTypesOfCombatSkillBuff">功法增益 - 会增益的五行类型. 0: 金, 1: 木, 2: 水, 3: 火, 4: 土, 5: 混元.</param>
	/// <param name="materialIdsOfFoodBuff">食物增益 - 会增益的食物的原料的 ID. 参见 Material 表, 取值范围 [鸡蛋, 鲟鳇鱼].</param>
	/// <param name="poisonBuffType">毒效增益</param>
	/// <param name="detoxBuffType">解毒增益</param>
	/// <param name="outerHealingBuff">治疗外伤增益</param>
	/// <param name="innerHealingBuff">治疗内伤增益</param>
	/// <param name="qiDisorderRecoveringBuff">调理内息增益</param>
	/// <param name="healthBuff">恢复健康增益</param>
	public SolarTermItem(sbyte templateId, string name, sbyte type, string desc, string poem, string image, string sound, sbyte month, List<byte> fiveElementsTypesOfCombatSkillBuff, List<short> materialIdsOfFoodBuff, sbyte poisonBuffType, sbyte detoxBuffType, bool outerHealingBuff, bool innerHealingBuff, bool qiDisorderRecoveringBuff, bool healthBuff)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Desc = desc;
		Poem = poem;
		Image = image;
		Sound = sound;
		Month = month;
		FiveElementsTypesOfCombatSkillBuff = fiveElementsTypesOfCombatSkillBuff;
		MaterialIdsOfFoodBuff = materialIdsOfFoodBuff;
		PoisonBuffType = poisonBuffType;
		DetoxBuffType = detoxBuffType;
		OuterHealingBuff = outerHealingBuff;
		InnerHealingBuff = innerHealingBuff;
		QiDisorderRecoveringBuff = qiDisorderRecoveringBuff;
		HealthBuff = healthBuff;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SolarTermItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		Desc = null;
		Poem = null;
		Image = null;
		Sound = null;
		Month = 0;
		FiveElementsTypesOfCombatSkillBuff = null;
		MaterialIdsOfFoodBuff = new List<short>();
		PoisonBuffType = 0;
		DetoxBuffType = 0;
		OuterHealingBuff = false;
		InnerHealingBuff = false;
		QiDisorderRecoveringBuff = false;
		HealthBuff = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SolarTermItem(sbyte templateId, SolarTermItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Desc = other.Desc;
		Poem = other.Poem;
		Image = other.Image;
		Sound = other.Sound;
		Month = other.Month;
		FiveElementsTypesOfCombatSkillBuff = other.FiveElementsTypesOfCombatSkillBuff;
		MaterialIdsOfFoodBuff = other.MaterialIdsOfFoodBuff;
		PoisonBuffType = other.PoisonBuffType;
		DetoxBuffType = other.DetoxBuffType;
		OuterHealingBuff = other.OuterHealingBuff;
		InnerHealingBuff = other.InnerHealingBuff;
		QiDisorderRecoveringBuff = other.QiDisorderRecoveringBuff;
		HealthBuff = other.HealthBuff;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SolarTermItem Duplicate(int templateId)
	{
		return new SolarTermItem((sbyte)templateId, this);
	}
}

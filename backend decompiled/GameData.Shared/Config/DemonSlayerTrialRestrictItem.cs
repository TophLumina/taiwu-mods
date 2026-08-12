using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrialRestrictItem : ConfigItem<DemonSlayerTrialRestrictItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 互斥组
	/// </summary>
	public readonly int MutexGroupId;

	/// <summary>
	/// 互斥角色
	/// - 用于禁用近战敌人或远程敌人
	/// </summary>
	public readonly List<int> MutexDemonId;

	/// <summary>
	/// 强度
	/// </summary>
	public readonly int Power;

	/// <summary>
	/// 权重
	/// </summary>
	public readonly short Weight;

	/// <summary>
	/// 最小功法品级
	/// - 0~8 对应九品到一品
	/// </summary>
	public readonly sbyte MinCombatSkillGrade;

	/// <summary>
	/// 最大功法品级
	/// </summary>
	public readonly sbyte MaxCombatSkillGrade;

	/// <summary>
	/// 最大摧破格数
	/// - 负数表示无限制
	/// </summary>
	public readonly sbyte MaxAttackSkillSlotCount;

	/// <summary>
	/// 最大轻灵格数
	/// - 负数表示无限制
	/// </summary>
	public readonly sbyte MaxAgileSkillSlotCount;

	/// <summary>
	/// 最大护体格数
	/// - 负数表示无限制
	/// </summary>
	public readonly sbyte MaxDefenseSkillSlotCount;

	/// <summary>
	/// 最大奇窍格数
	/// - 负数表示无限制
	/// </summary>
	public readonly sbyte MaxAssistSkillSlotCount;

	/// <summary>
	/// 最大武器格数
	/// - 负数表示无限制
	/// </summary>
	public readonly sbyte MaxWeaponSlotCount;

	/// <summary>
	/// 偏好战斗配置
	/// - 每随机一个约束，就会排除所有不在该约束有效战斗配置的战斗配置，最后在剩余有效战斗配置里，优先选偏好战斗配置
	/// </summary>
	public readonly short PreferCombatConfig;

	/// <summary>
	/// 有效战斗配置
	/// </summary>
	public readonly List<short> EffectiveCombatConfigs;

	/// <summary>
	/// 约束特效类名
	/// - 由程序维护此列配置
	/// </summary>
	public readonly string EffectClassName;

	/// <summary>
	/// 约束特效参数
	/// - 只可修改值，不可改变数量
	/// </summary>
	public readonly int[] EffectParameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">描述</param>
	/// <param name="mutexGroupId">互斥组</param>
	/// <param name="mutexDemonId">互斥角色 - 用于禁用近战敌人或远程敌人</param>
	/// <param name="power">强度</param>
	/// <param name="weight">权重</param>
	/// <param name="minCombatSkillGrade">最小功法品级 - 0~8 对应九品到一品</param>
	/// <param name="maxCombatSkillGrade">最大功法品级</param>
	/// <param name="maxAttackSkillSlotCount">最大摧破格数 - 负数表示无限制</param>
	/// <param name="maxAgileSkillSlotCount">最大轻灵格数 - 负数表示无限制</param>
	/// <param name="maxDefenseSkillSlotCount">最大护体格数 - 负数表示无限制</param>
	/// <param name="maxAssistSkillSlotCount">最大奇窍格数 - 负数表示无限制</param>
	/// <param name="maxWeaponSlotCount">最大武器格数 - 负数表示无限制</param>
	/// <param name="preferCombatConfig">偏好战斗配置 - 每随机一个约束，就会排除所有不在该约束有效战斗配置的战斗配置，最后在剩余有效战斗配置里，优先选偏好战斗配置</param>
	/// <param name="effectiveCombatConfigs">有效战斗配置</param>
	/// <param name="effectClassName">约束特效类名 - 由程序维护此列配置</param>
	/// <param name="effectParameters">约束特效参数 - 只可修改值，不可改变数量</param>
	public DemonSlayerTrialRestrictItem(int templateId, string desc, int mutexGroupId, List<int> mutexDemonId, int power, short weight, sbyte minCombatSkillGrade, sbyte maxCombatSkillGrade, sbyte maxAttackSkillSlotCount, sbyte maxAgileSkillSlotCount, sbyte maxDefenseSkillSlotCount, sbyte maxAssistSkillSlotCount, sbyte maxWeaponSlotCount, short preferCombatConfig, List<short> effectiveCombatConfigs, string effectClassName, int[] effectParameters)
	{
		TemplateId = templateId;
		Desc = desc;
		MutexGroupId = mutexGroupId;
		MutexDemonId = mutexDemonId;
		Power = power;
		Weight = weight;
		MinCombatSkillGrade = minCombatSkillGrade;
		MaxCombatSkillGrade = maxCombatSkillGrade;
		MaxAttackSkillSlotCount = maxAttackSkillSlotCount;
		MaxAgileSkillSlotCount = maxAgileSkillSlotCount;
		MaxDefenseSkillSlotCount = maxDefenseSkillSlotCount;
		MaxAssistSkillSlotCount = maxAssistSkillSlotCount;
		MaxWeaponSlotCount = maxWeaponSlotCount;
		PreferCombatConfig = preferCombatConfig;
		EffectiveCombatConfigs = effectiveCombatConfigs;
		EffectClassName = effectClassName;
		EffectParameters = effectParameters;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DemonSlayerTrialRestrictItem()
	{
		TemplateId = 0;
		Desc = null;
		MutexGroupId = 0;
		MutexDemonId = new List<int>();
		Power = 0;
		Weight = 0;
		MinCombatSkillGrade = 0;
		MaxCombatSkillGrade = 8;
		MaxAttackSkillSlotCount = -1;
		MaxAgileSkillSlotCount = -1;
		MaxDefenseSkillSlotCount = -1;
		MaxAssistSkillSlotCount = -1;
		MaxWeaponSlotCount = -1;
		PreferCombatConfig = 211;
		EffectiveCombatConfigs = new List<short>
		{
			211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
			221, 222
		};
		EffectClassName = null;
		EffectParameters = new int[0];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DemonSlayerTrialRestrictItem(int templateId, DemonSlayerTrialRestrictItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		MutexGroupId = other.MutexGroupId;
		MutexDemonId = other.MutexDemonId;
		Power = other.Power;
		Weight = other.Weight;
		MinCombatSkillGrade = other.MinCombatSkillGrade;
		MaxCombatSkillGrade = other.MaxCombatSkillGrade;
		MaxAttackSkillSlotCount = other.MaxAttackSkillSlotCount;
		MaxAgileSkillSlotCount = other.MaxAgileSkillSlotCount;
		MaxDefenseSkillSlotCount = other.MaxDefenseSkillSlotCount;
		MaxAssistSkillSlotCount = other.MaxAssistSkillSlotCount;
		MaxWeaponSlotCount = other.MaxWeaponSlotCount;
		PreferCombatConfig = other.PreferCombatConfig;
		EffectiveCombatConfigs = other.EffectiveCombatConfigs;
		EffectClassName = other.EffectClassName;
		EffectParameters = other.EffectParameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DemonSlayerTrialRestrictItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialRestrictItem(templateId, this);
	}
}

using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class NeiliTypeItem : ConfigItem<NeiliTypeItem, sbyte>
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
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 五行属性
	/// - 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.
	/// </summary>
	public readonly byte FiveElements;

	/// <summary>
	/// 理想真气分配比例
	/// - 先按此比例分配真气，再根据万用格的分配情况，额外的调整真气分配比例，如：摧破被分配了一个万用格，则摧破真气的比例+5，总比例+5，以混元为例，原本是(25,25,25,25)/100的比例，在人物向摧破分配了一个万用格后，真气分配比例变成(30,25,25,25)/105
	/// </summary>
	public readonly sbyte[] IdeaAllocationProportion;

	/// <summary>
	/// 各属性功法威力上限变化
	/// - 由辅助配置列 "金刚" 到 "混元" 组合，不可直接配置此列
	/// </summary>
	public readonly sbyte[] MaxPowerChange;

	/// <summary>
	/// 各属性功法发挥需求变化
	/// - 由辅助配置列 "金刚" 到 "混元" 组合，不可直接配置此列
	/// </summary>
	public readonly sbyte[] RequirementChange;

	/// <summary>
	/// 反噬五行
	/// - 施展后会受伤和内息紊乱的五行属性. 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.
	/// </summary>
	public readonly sbyte InjuryOnUseType;

	/// <summary>
	/// 显示内力冲克的世界状态
	/// </summary>
	public readonly bool ShowConflictingWorldState;

	/// <summary>
	/// 命中
	/// - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts HitValues;

	/// <summary>
	/// 攻击
	/// - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerShorts Penetrations;

	/// <summary>
	/// 化解
	/// - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidShorts AvoidValues;

	/// <summary>
	/// 防御
	/// - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerShorts PenetrationResists;

	/// <summary>
	/// 架势提气恢复
	/// - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.
	/// </summary>
	public readonly OuterAndInnerShorts RecoveryOfStanceAndBreath;

	/// <summary>
	/// 移动速度
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short MoveSpeed;

	/// <summary>
	/// 步伐稳健
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short RecoveryOfFlaw;

	/// <summary>
	/// 施展速度
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short CastSpeed;

	/// <summary>
	/// 引气冲关
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short RecoveryOfBlockedAcupoint;

	/// <summary>
	/// 武具发挥
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short WeaponSwitchSpeed;

	/// <summary>
	/// 攻击速度
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short AttackSpeed;

	/// <summary>
	/// 内功发挥
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short InnerRatio;

	/// <summary>
	/// 调息吐纳
	/// - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.
	/// </summary>
	public readonly short RecoveryOfQiDisorder;

	/// <summary>
	/// 毒素抵抗
	/// - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.
	/// </summary>
	public readonly PoisonShorts PoisonResists;

	/// <summary>
	/// 连线和图标颜色
	/// - 0-无，1-蓝（增益），2-红（减益）
	/// </summary>
	public readonly sbyte ColorType;

	/// <summary>
	/// 连线位置
	/// </summary>
	public readonly short[] LinePos;

	/// <summary>
	/// 连线角度
	/// </summary>
	public readonly short LineAngle;

	/// <summary>
	/// 类型图标位置
	/// </summary>
	public readonly short[] TypeIconPos;

	public readonly List<string> NeiliTypeConditionText;

	public readonly string SimpleDesc;

	public readonly string EffectDesc;

	/// <summary>
	/// 生位特性
	/// - 触发特效时，位于生位的人物获得的特性
	/// </summary>
	public readonly short[] LifeGateFeatures;

	/// <summary>
	/// 死位特性
	/// - 触发特效时，位于死位的人物获得的特性
	/// </summary>
	public readonly short[] DeathGateFeatures;

	/// <summary>
	/// 理想五行分配比例
	/// </summary>
	public readonly sbyte[] NeiliProportionOfFiveElements;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="fiveElements">五行属性 - 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.</param>
	/// <param name="ideaAllocationProportion">理想真气分配比例 - 先按此比例分配真气，再根据万用格的分配情况，额外的调整真气分配比例，如：摧破被分配了一个万用格，则摧破真气的比例+5，总比例+5，以混元为例，原本是(25,25,25,25)/100的比例，在人物向摧破分配了一个万用格后，真气分配比例变成(30,25,25,25)/105</param>
	/// <param name="maxPowerChange">各属性功法威力上限变化 - 由辅助配置列 "金刚" 到 "混元" 组合，不可直接配置此列</param>
	/// <param name="requirementChange">各属性功法发挥需求变化 - 由辅助配置列 "金刚" 到 "混元" 组合，不可直接配置此列</param>
	/// <param name="injuryOnUseType">反噬五行 - 施展后会受伤和内息紊乱的五行属性. 0: 金刚, 1: 紫霞、2: 玄阴、3: 纯阳, 4: 归元, 5: 混元.</param>
	/// <param name="showConflictingWorldState">显示内力冲克的世界状态</param>
	/// <param name="hitValues">命中 - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.</param>
	/// <param name="penetrations">攻击 - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.</param>
	/// <param name="avoidValues">化解 - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.</param>
	/// <param name="penetrationResists">防御 - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.</param>
	/// <param name="recoveryOfStanceAndBreath">架势提气恢复 - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.</param>
	/// <param name="moveSpeed">移动速度 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="recoveryOfFlaw">步伐稳健 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="castSpeed">施展速度 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="recoveryOfBlockedAcupoint">引气冲关 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="weaponSwitchSpeed">武具发挥 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="attackSpeed">攻击速度 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="innerRatio">内功发挥 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="recoveryOfQiDisorder">调息吐纳 - 每分配 N 点真气后会增加一次此属性, 此值即每次增加的值.</param>
	/// <param name="poisonResists">毒素抵抗 - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.</param>
	/// <param name="colorType">连线和图标颜色 - 0-无，1-蓝（增益），2-红（减益）</param>
	/// <param name="linePos">连线位置</param>
	/// <param name="lineAngle">连线角度</param>
	/// <param name="typeIconPos">类型图标位置</param>
	/// <param name="neiliTypeConditionText"></param>
	/// <param name="simpleDesc"></param>
	/// <param name="effectDesc"></param>
	/// <param name="lifeGateFeatures">生位特性 - 触发特效时，位于生位的人物获得的特性</param>
	/// <param name="deathGateFeatures">死位特性 - 触发特效时，位于死位的人物获得的特性</param>
	/// <param name="neiliProportionOfFiveElements">理想五行分配比例</param>
	public NeiliTypeItem(sbyte templateId, string name, string desc, byte fiveElements, sbyte[] ideaAllocationProportion, sbyte[] maxPowerChange, sbyte[] requirementChange, sbyte injuryOnUseType, bool showConflictingWorldState, HitOrAvoidShorts hitValues, OuterAndInnerShorts penetrations, HitOrAvoidShorts avoidValues, OuterAndInnerShorts penetrationResists, OuterAndInnerShorts recoveryOfStanceAndBreath, short moveSpeed, short recoveryOfFlaw, short castSpeed, short recoveryOfBlockedAcupoint, short weaponSwitchSpeed, short attackSpeed, short innerRatio, short recoveryOfQiDisorder, PoisonShorts poisonResists, sbyte colorType, short[] linePos, short lineAngle, short[] typeIconPos, List<string> neiliTypeConditionText, string simpleDesc, string effectDesc, short[] lifeGateFeatures, short[] deathGateFeatures, sbyte[] neiliProportionOfFiveElements)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		FiveElements = fiveElements;
		IdeaAllocationProportion = ideaAllocationProportion;
		MaxPowerChange = maxPowerChange;
		RequirementChange = requirementChange;
		InjuryOnUseType = injuryOnUseType;
		ShowConflictingWorldState = showConflictingWorldState;
		HitValues = hitValues;
		Penetrations = penetrations;
		AvoidValues = avoidValues;
		PenetrationResists = penetrationResists;
		RecoveryOfStanceAndBreath = recoveryOfStanceAndBreath;
		MoveSpeed = moveSpeed;
		RecoveryOfFlaw = recoveryOfFlaw;
		CastSpeed = castSpeed;
		RecoveryOfBlockedAcupoint = recoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = weaponSwitchSpeed;
		AttackSpeed = attackSpeed;
		InnerRatio = innerRatio;
		RecoveryOfQiDisorder = recoveryOfQiDisorder;
		PoisonResists = poisonResists;
		ColorType = colorType;
		LinePos = linePos;
		LineAngle = lineAngle;
		TypeIconPos = typeIconPos;
		NeiliTypeConditionText = neiliTypeConditionText;
		SimpleDesc = simpleDesc;
		EffectDesc = effectDesc;
		LifeGateFeatures = lifeGateFeatures;
		DeathGateFeatures = deathGateFeatures;
		NeiliProportionOfFiveElements = neiliProportionOfFiveElements;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public NeiliTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		FiveElements = 0;
		IdeaAllocationProportion = new sbyte[4] { 25, 25, 25, 25 };
		MaxPowerChange = new sbyte[6];
		RequirementChange = new sbyte[6];
		InjuryOnUseType = -1;
		ShowConflictingWorldState = false;
		HitValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		Penetrations = new OuterAndInnerShorts(0, 0);
		AvoidValues = new HitOrAvoidShorts(default(short), default(short), default(short), default(short));
		PenetrationResists = new OuterAndInnerShorts(0, 0);
		RecoveryOfStanceAndBreath = new OuterAndInnerShorts(0, 0);
		MoveSpeed = 0;
		RecoveryOfFlaw = 0;
		CastSpeed = 0;
		RecoveryOfBlockedAcupoint = 0;
		WeaponSwitchSpeed = 0;
		AttackSpeed = 0;
		InnerRatio = 0;
		RecoveryOfQiDisorder = 0;
		PoisonResists = new PoisonShorts(default(int), default(int), default(int), default(int), default(int), default(int));
		ColorType = 0;
		LinePos = null;
		LineAngle = 0;
		TypeIconPos = new short[2] { -1, -1 };
		NeiliTypeConditionText = new List<string> { string.Empty };
		SimpleDesc = null;
		EffectDesc = null;
		LifeGateFeatures = new short[0];
		DeathGateFeatures = new short[0];
		NeiliProportionOfFiveElements = new sbyte[5] { 20, 20, 20, 20, 20 };
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public NeiliTypeItem(sbyte templateId, NeiliTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		FiveElements = other.FiveElements;
		IdeaAllocationProportion = other.IdeaAllocationProportion;
		MaxPowerChange = other.MaxPowerChange;
		RequirementChange = other.RequirementChange;
		InjuryOnUseType = other.InjuryOnUseType;
		ShowConflictingWorldState = other.ShowConflictingWorldState;
		HitValues = other.HitValues;
		Penetrations = other.Penetrations;
		AvoidValues = other.AvoidValues;
		PenetrationResists = other.PenetrationResists;
		RecoveryOfStanceAndBreath = other.RecoveryOfStanceAndBreath;
		MoveSpeed = other.MoveSpeed;
		RecoveryOfFlaw = other.RecoveryOfFlaw;
		CastSpeed = other.CastSpeed;
		RecoveryOfBlockedAcupoint = other.RecoveryOfBlockedAcupoint;
		WeaponSwitchSpeed = other.WeaponSwitchSpeed;
		AttackSpeed = other.AttackSpeed;
		InnerRatio = other.InnerRatio;
		RecoveryOfQiDisorder = other.RecoveryOfQiDisorder;
		PoisonResists = other.PoisonResists;
		ColorType = other.ColorType;
		LinePos = other.LinePos;
		LineAngle = other.LineAngle;
		TypeIconPos = other.TypeIconPos;
		NeiliTypeConditionText = other.NeiliTypeConditionText;
		SimpleDesc = other.SimpleDesc;
		EffectDesc = other.EffectDesc;
		LifeGateFeatures = other.LifeGateFeatures;
		DeathGateFeatures = other.DeathGateFeatures;
		NeiliProportionOfFiveElements = other.NeiliProportionOfFiveElements;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NeiliTypeItem Duplicate(int templateId)
	{
		return new NeiliTypeItem((sbyte)templateId, this);
	}
}

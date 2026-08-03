using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheckTipItem : ConfigItem<InteractCheckTipItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 阶段名称
	/// </summary>
	public readonly string PhaseName;

	/// <summary>
	/// 阶段描述
	/// </summary>
	public readonly string PhaseDesc;

	/// <summary>
	/// 阶段图标
	/// </summary>
	public readonly string PhaseIcon;

	/// <summary>
	/// 判定内容
	/// - 影响因素描述
	/// </summary>
	public readonly string CheckDesc;

	/// <summary>
	/// 我方判定角色主要属性
	/// - 需要和代码一同修改
	/// </summary>
	public readonly short SelfCheckCharacterProperty;

	/// <summary>
	/// 目标判定角色主要属性
	/// - 需要和代码一同修改
	/// </summary>
	public readonly short TargetCheckCharacterProperty;

	/// <summary>
	/// 我方判定造诣武学类型
	/// - 需要和代码一同修改
	/// </summary>
	public readonly sbyte SelfCheckAttainmentCombatSkillType;

	/// <summary>
	/// 目标判定造诣武学类型
	/// - 需要和代码一同修改
	/// </summary>
	public readonly sbyte TargetCheckAttainmentCombatSkillType;

	/// <summary>
	/// 我方判定造诣技艺类型
	/// - 需要和代码一同修改
	/// </summary>
	public readonly sbyte SelfCheckAttainmentLifeSkillType;

	/// <summary>
	/// 目标判定造诣技艺类型
	/// - 需要和代码一同修改
	/// </summary>
	public readonly sbyte TargetCheckAttainmentLifeSkillType;

	/// <summary>
	/// 前端特殊数据处理方式
	/// - 程序根据不同类型，在Tips的表格中填写不同的数据
	/// </summary>
	public readonly EInteractCheckTipSpecialValueDisplayType SpecialValueDisplayType;

	/// <summary>
	/// 判定概率结果
	/// </summary>
	public readonly string CheckResultProb;

	/// <summary>
	/// 倾诉爱意类型
	/// </summary>
	public readonly EInteractCheckTipConfessionLoveFactorType ConfessionLoveFactorType;

	/// <summary>
	/// 文本条目
	/// </summary>
	public readonly string[] FactorDesc;

	/// <summary>
	/// 前端特殊行展示类型
	/// - tips表格后面的行，程序根据不同类型，对FactorDesc的参数进行不同的处理
	/// </summary>
	public readonly EInteractCheckTipSpecialLineDisplayType SpecialLineDisplayType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="phaseName">阶段名称</param>
	/// <param name="phaseDesc">阶段描述</param>
	/// <param name="phaseIcon">阶段图标</param>
	/// <param name="checkDesc">判定内容 - 影响因素描述</param>
	/// <param name="selfCheckCharacterProperty">我方判定角色主要属性 - 需要和代码一同修改</param>
	/// <param name="targetCheckCharacterProperty">目标判定角色主要属性 - 需要和代码一同修改</param>
	/// <param name="selfCheckAttainmentCombatSkillType">我方判定造诣武学类型 - 需要和代码一同修改</param>
	/// <param name="targetCheckAttainmentCombatSkillType">目标判定造诣武学类型 - 需要和代码一同修改</param>
	/// <param name="selfCheckAttainmentLifeSkillType">我方判定造诣技艺类型 - 需要和代码一同修改</param>
	/// <param name="targetCheckAttainmentLifeSkillType">目标判定造诣技艺类型 - 需要和代码一同修改</param>
	/// <param name="specialValueDisplayType">前端特殊数据处理方式 - 程序根据不同类型，在Tips的表格中填写不同的数据</param>
	/// <param name="checkResultProb">判定概率结果</param>
	/// <param name="confessionLoveFactorType">倾诉爱意类型</param>
	/// <param name="factorDesc">文本条目</param>
	/// <param name="specialLineDisplayType">前端特殊行展示类型 - tips表格后面的行，程序根据不同类型，对FactorDesc的参数进行不同的处理</param>
	public InteractCheckTipItem(short templateId, string phaseName, string phaseDesc, string phaseIcon, string checkDesc, short selfCheckCharacterProperty, short targetCheckCharacterProperty, sbyte selfCheckAttainmentCombatSkillType, sbyte targetCheckAttainmentCombatSkillType, sbyte selfCheckAttainmentLifeSkillType, sbyte targetCheckAttainmentLifeSkillType, EInteractCheckTipSpecialValueDisplayType specialValueDisplayType, string checkResultProb, EInteractCheckTipConfessionLoveFactorType confessionLoveFactorType, string[] factorDesc, EInteractCheckTipSpecialLineDisplayType specialLineDisplayType)
	{
		TemplateId = templateId;
		PhaseName = phaseName;
		PhaseDesc = phaseDesc;
		PhaseIcon = phaseIcon;
		CheckDesc = checkDesc;
		SelfCheckCharacterProperty = selfCheckCharacterProperty;
		TargetCheckCharacterProperty = targetCheckCharacterProperty;
		SelfCheckAttainmentCombatSkillType = selfCheckAttainmentCombatSkillType;
		TargetCheckAttainmentCombatSkillType = targetCheckAttainmentCombatSkillType;
		SelfCheckAttainmentLifeSkillType = selfCheckAttainmentLifeSkillType;
		TargetCheckAttainmentLifeSkillType = targetCheckAttainmentLifeSkillType;
		SpecialValueDisplayType = specialValueDisplayType;
		CheckResultProb = checkResultProb;
		ConfessionLoveFactorType = confessionLoveFactorType;
		FactorDesc = factorDesc;
		SpecialLineDisplayType = specialLineDisplayType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InteractCheckTipItem()
	{
		TemplateId = 0;
		PhaseName = null;
		PhaseDesc = null;
		PhaseIcon = null;
		CheckDesc = null;
		SelfCheckCharacterProperty = 0;
		TargetCheckCharacterProperty = 0;
		SelfCheckAttainmentCombatSkillType = 0;
		TargetCheckAttainmentCombatSkillType = 0;
		SelfCheckAttainmentLifeSkillType = 0;
		TargetCheckAttainmentLifeSkillType = 0;
		SpecialValueDisplayType = EInteractCheckTipSpecialValueDisplayType.Invalid;
		CheckResultProb = null;
		ConfessionLoveFactorType = EInteractCheckTipConfessionLoveFactorType.Invalid;
		FactorDesc = null;
		SpecialLineDisplayType = EInteractCheckTipSpecialLineDisplayType.Invalid;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InteractCheckTipItem(short templateId, InteractCheckTipItem other)
	{
		TemplateId = templateId;
		PhaseName = other.PhaseName;
		PhaseDesc = other.PhaseDesc;
		PhaseIcon = other.PhaseIcon;
		CheckDesc = other.CheckDesc;
		SelfCheckCharacterProperty = other.SelfCheckCharacterProperty;
		TargetCheckCharacterProperty = other.TargetCheckCharacterProperty;
		SelfCheckAttainmentCombatSkillType = other.SelfCheckAttainmentCombatSkillType;
		TargetCheckAttainmentCombatSkillType = other.TargetCheckAttainmentCombatSkillType;
		SelfCheckAttainmentLifeSkillType = other.SelfCheckAttainmentLifeSkillType;
		TargetCheckAttainmentLifeSkillType = other.TargetCheckAttainmentLifeSkillType;
		SpecialValueDisplayType = other.SpecialValueDisplayType;
		CheckResultProb = other.CheckResultProb;
		ConfessionLoveFactorType = other.ConfessionLoveFactorType;
		FactorDesc = other.FactorDesc;
		SpecialLineDisplayType = other.SpecialLineDisplayType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InteractCheckTipItem Duplicate(int templateId)
	{
		return new InteractCheckTipItem((short)templateId, this);
	}
}

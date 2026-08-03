using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSpecialConditionItem : ConfigItem<SecretInformationSpecialConditionItem, short>
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
	/// 保密概率
	/// - 满足此条件时人物要求保密的附加概率。无是基础保密概率。
	/// </summary>
	public readonly short[] RequestKeepSecretRate;

	/// <summary>
	/// 计算方式
	/// </summary>
	public readonly ESecretInformationSpecialConditionCalculate Calculate;

	/// <summary>
	/// 计算参数之名誉线
	/// </summary>
	public readonly ESecretInformationSpecialConditionCalcFameLine CalcFameLine;

	/// <summary>
	/// 计算参数之男女私情
	/// </summary>
	public readonly ESecretInformationSpecialConditionCalcSexualMateCase CalcSexualMateCase;

	/// <summary>
	/// 计算参数之男女私情规则
	/// </summary>
	public readonly ESecretInformationSpecialConditionCalcSexualMateRule CalcSexualMateRule;

	/// <summary>
	/// 门派的具体门规
	/// </summary>
	public readonly short CalcSectRule;

	/// <summary>
	/// 计算参数之组织
	/// </summary>
	public readonly short CalcOrganization;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="requestKeepSecretRate">保密概率 - 满足此条件时人物要求保密的附加概率。无是基础保密概率。</param>
	/// <param name="calculate">计算方式</param>
	/// <param name="calcFameLine">计算参数之名誉线</param>
	/// <param name="calcSexualMateCase">计算参数之男女私情</param>
	/// <param name="calcSexualMateRule">计算参数之男女私情规则</param>
	/// <param name="calcSectRule">门派的具体门规</param>
	/// <param name="calcOrganization">计算参数之组织</param>
	public SecretInformationSpecialConditionItem(short templateId, string name, short[] requestKeepSecretRate, ESecretInformationSpecialConditionCalculate calculate, ESecretInformationSpecialConditionCalcFameLine calcFameLine, ESecretInformationSpecialConditionCalcSexualMateCase calcSexualMateCase, ESecretInformationSpecialConditionCalcSexualMateRule calcSexualMateRule, short calcSectRule, short calcOrganization)
	{
		TemplateId = templateId;
		Name = name;
		RequestKeepSecretRate = requestKeepSecretRate;
		Calculate = calculate;
		CalcFameLine = calcFameLine;
		CalcSexualMateCase = calcSexualMateCase;
		CalcSexualMateRule = calcSexualMateRule;
		CalcSectRule = calcSectRule;
		CalcOrganization = calcOrganization;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationSpecialConditionItem()
	{
		TemplateId = 0;
		Name = null;
		RequestKeepSecretRate = new short[5];
		Calculate = ESecretInformationSpecialConditionCalculate.None;
		CalcFameLine = ESecretInformationSpecialConditionCalcFameLine.Invalid;
		CalcSexualMateCase = ESecretInformationSpecialConditionCalcSexualMateCase.Invalid;
		CalcSexualMateRule = ESecretInformationSpecialConditionCalcSexualMateRule.Invalid;
		CalcSectRule = 0;
		CalcOrganization = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationSpecialConditionItem(short templateId, SecretInformationSpecialConditionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		RequestKeepSecretRate = other.RequestKeepSecretRate;
		Calculate = other.Calculate;
		CalcFameLine = other.CalcFameLine;
		CalcSexualMateCase = other.CalcSexualMateCase;
		CalcSexualMateRule = other.CalcSexualMateRule;
		CalcSectRule = other.CalcSectRule;
		CalcOrganization = other.CalcOrganization;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationSpecialConditionItem Duplicate(int templateId)
	{
		return new SecretInformationSpecialConditionItem((short)templateId, this);
	}
}

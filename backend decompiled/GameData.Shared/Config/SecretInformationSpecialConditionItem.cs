using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSpecialConditionItem : ConfigItem<SecretInformationSpecialConditionItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short[] RequestKeepSecretRate;

	public readonly ESecretInformationSpecialConditionCalculate Calculate;

	public readonly ESecretInformationSpecialConditionCalcFameLine CalcFameLine;

	public readonly ESecretInformationSpecialConditionCalcSexualMateCase CalcSexualMateCase;

	public readonly ESecretInformationSpecialConditionCalcSexualMateRule CalcSexualMateRule;

	public readonly short CalcSectRule;

	public readonly sbyte CalcOrganization;

	public SecretInformationSpecialConditionItem(short templateId, string name, short[] requestKeepSecretRate, ESecretInformationSpecialConditionCalculate calculate, ESecretInformationSpecialConditionCalcFameLine calcFameLine, ESecretInformationSpecialConditionCalcSexualMateCase calcSexualMateCase, ESecretInformationSpecialConditionCalcSexualMateRule calcSexualMateRule, short calcSectRule, sbyte calcOrganization)
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

	public override SecretInformationSpecialConditionItem Duplicate(int templateId)
	{
		return new SecretInformationSpecialConditionItem((short)templateId, this);
	}
}

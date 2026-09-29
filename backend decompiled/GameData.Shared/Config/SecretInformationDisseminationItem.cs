using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDisseminationItem : ConfigItem<SecretInformationDisseminationItem, short>
{
	public readonly short TemplateId;

	public readonly short SfRateStr;

	public readonly short SfRateNStr;

	public readonly short SfRateActFri;

	public readonly short SfRateActEnm;

	public readonly short SfRateUnaFri;

	public readonly short SfRateUnaEnm;

	public readonly short[] SfPersonalityDiff;

	public readonly short[] SfBehaviorTypeDiff;

	public readonly short TfRateStr;

	public readonly short TfRateNStr;

	public readonly short TfRateItsFri;

	public readonly short TfRateItsEnm;

	public readonly short TfRateActFri;

	public readonly short TfRateActEnm;

	public readonly short TfRateUnaFri;

	public readonly short TfRateUnaEnm;

	public readonly short TfRateDiffWhenActFri;

	public readonly short TfRateDiffWhenActEnm;

	public readonly short TfRateDiffWhenUnaFri;

	public readonly short TfRateDiffWhenUnaEnm;

	public readonly short[] TfPersonalityDiff;

	public readonly short[] TfBehaviorTypeDiff;

	public SecretInformationDisseminationItem(short templateId, short sfRateStr, short sfRateNStr, short sfRateActFri, short sfRateActEnm, short sfRateUnaFri, short sfRateUnaEnm, short[] sfPersonalityDiff, short[] sfBehaviorTypeDiff, short tfRateStr, short tfRateNStr, short tfRateItsFri, short tfRateItsEnm, short tfRateActFri, short tfRateActEnm, short tfRateUnaFri, short tfRateUnaEnm, short tfRateDiffWhenActFri, short tfRateDiffWhenActEnm, short tfRateDiffWhenUnaFri, short tfRateDiffWhenUnaEnm, short[] tfPersonalityDiff, short[] tfBehaviorTypeDiff)
	{
		TemplateId = templateId;
		SfRateStr = sfRateStr;
		SfRateNStr = sfRateNStr;
		SfRateActFri = sfRateActFri;
		SfRateActEnm = sfRateActEnm;
		SfRateUnaFri = sfRateUnaFri;
		SfRateUnaEnm = sfRateUnaEnm;
		SfPersonalityDiff = sfPersonalityDiff;
		SfBehaviorTypeDiff = sfBehaviorTypeDiff;
		TfRateStr = tfRateStr;
		TfRateNStr = tfRateNStr;
		TfRateItsFri = tfRateItsFri;
		TfRateItsEnm = tfRateItsEnm;
		TfRateActFri = tfRateActFri;
		TfRateActEnm = tfRateActEnm;
		TfRateUnaFri = tfRateUnaFri;
		TfRateUnaEnm = tfRateUnaEnm;
		TfRateDiffWhenActFri = tfRateDiffWhenActFri;
		TfRateDiffWhenActEnm = tfRateDiffWhenActEnm;
		TfRateDiffWhenUnaFri = tfRateDiffWhenUnaFri;
		TfRateDiffWhenUnaEnm = tfRateDiffWhenUnaEnm;
		TfPersonalityDiff = tfPersonalityDiff;
		TfBehaviorTypeDiff = tfBehaviorTypeDiff;
	}

	public SecretInformationDisseminationItem()
	{
		TemplateId = 0;
		SfRateStr = -10000;
		SfRateNStr = -10000;
		SfRateActFri = -10000;
		SfRateActEnm = -10000;
		SfRateUnaFri = -10000;
		SfRateUnaEnm = -10000;
		SfPersonalityDiff = new short[5];
		SfBehaviorTypeDiff = new short[5];
		TfRateStr = -10000;
		TfRateNStr = -10000;
		TfRateItsFri = -10000;
		TfRateItsEnm = -10000;
		TfRateActFri = -10000;
		TfRateActEnm = -10000;
		TfRateUnaFri = -10000;
		TfRateUnaEnm = -10000;
		TfRateDiffWhenActFri = 0;
		TfRateDiffWhenActEnm = 0;
		TfRateDiffWhenUnaFri = 0;
		TfRateDiffWhenUnaEnm = 0;
		TfPersonalityDiff = new short[5];
		TfBehaviorTypeDiff = new short[5];
	}

	public SecretInformationDisseminationItem(short templateId, SecretInformationDisseminationItem other)
	{
		TemplateId = templateId;
		SfRateStr = other.SfRateStr;
		SfRateNStr = other.SfRateNStr;
		SfRateActFri = other.SfRateActFri;
		SfRateActEnm = other.SfRateActEnm;
		SfRateUnaFri = other.SfRateUnaFri;
		SfRateUnaEnm = other.SfRateUnaEnm;
		SfPersonalityDiff = other.SfPersonalityDiff;
		SfBehaviorTypeDiff = other.SfBehaviorTypeDiff;
		TfRateStr = other.TfRateStr;
		TfRateNStr = other.TfRateNStr;
		TfRateItsFri = other.TfRateItsFri;
		TfRateItsEnm = other.TfRateItsEnm;
		TfRateActFri = other.TfRateActFri;
		TfRateActEnm = other.TfRateActEnm;
		TfRateUnaFri = other.TfRateUnaFri;
		TfRateUnaEnm = other.TfRateUnaEnm;
		TfRateDiffWhenActFri = other.TfRateDiffWhenActFri;
		TfRateDiffWhenActEnm = other.TfRateDiffWhenActEnm;
		TfRateDiffWhenUnaFri = other.TfRateDiffWhenUnaFri;
		TfRateDiffWhenUnaEnm = other.TfRateDiffWhenUnaEnm;
		TfPersonalityDiff = other.TfPersonalityDiff;
		TfBehaviorTypeDiff = other.TfBehaviorTypeDiff;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationDisseminationItem Duplicate(int templateId)
	{
		return new SecretInformationDisseminationItem((short)templateId, this);
	}
}

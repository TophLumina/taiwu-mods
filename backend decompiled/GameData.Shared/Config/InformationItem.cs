using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class InformationItem : ConfigItem<InformationItem, short>
{
	public readonly short TemplateId;

	public readonly short[] InfoIds;

	public readonly bool IsGeneral;

	public readonly sbyte Type;

	public readonly sbyte[] BaseGainRate;

	public readonly sbyte[] ExtraGainRate;

	public readonly sbyte CostDays;

	public readonly bool UsedCountWithMax;

	public readonly short[] EffectRate;

	public readonly short ChangeLovingRate;

	public readonly short[] ChangeLovingAndHatingRate;

	public readonly short[] ChangeTowardOrganizationRate;

	public readonly short[] RemoveTowardOrganizationRate;

	public readonly short[] ChangeBehaviorTypeRate;

	public readonly int Authority;

	public readonly short TransformId;

	public readonly bool IsNeedShowLevel;

	public readonly short[] ChangeProfessionRate;

	public readonly int GainLevel;

	public readonly int GainCount;

	public InformationItem Transform
	{
		[return: MaybeNull]
		get
		{
			return Information.Instance.GetItemOrDefault(TransformId);
		}
	}

	public InformationItem(short templateId, short[] infoIds, bool isGeneral, sbyte type, sbyte[] baseGainRate, sbyte[] extraGainRate, sbyte costDays, bool usedCountWithMax, short[] effectRate, short changeLovingRate, short[] changeLovingAndHatingRate, short[] changeTowardOrganizationRate, short[] removeTowardOrganizationRate, short[] changeBehaviorTypeRate, int authority, short transformId, bool isNeedShowLevel, short[] changeProfessionRate, int gainLevel, int gainCount)
	{
		TemplateId = templateId;
		InfoIds = infoIds;
		IsGeneral = isGeneral;
		Type = type;
		BaseGainRate = baseGainRate;
		ExtraGainRate = extraGainRate;
		CostDays = costDays;
		UsedCountWithMax = usedCountWithMax;
		EffectRate = effectRate;
		ChangeLovingRate = changeLovingRate;
		ChangeLovingAndHatingRate = changeLovingAndHatingRate;
		ChangeTowardOrganizationRate = changeTowardOrganizationRate;
		RemoveTowardOrganizationRate = removeTowardOrganizationRate;
		ChangeBehaviorTypeRate = changeBehaviorTypeRate;
		Authority = authority;
		TransformId = transformId;
		IsNeedShowLevel = isNeedShowLevel;
		ChangeProfessionRate = changeProfessionRate;
		GainLevel = gainLevel;
		GainCount = gainCount;
	}

	public InformationItem()
	{
		TemplateId = 0;
		InfoIds = null;
		IsGeneral = false;
		Type = 0;
		BaseGainRate = null;
		ExtraGainRate = null;
		CostDays = 1;
		UsedCountWithMax = true;
		EffectRate = new short[3] { 300, 100, 0 };
		ChangeLovingRate = 0;
		ChangeLovingAndHatingRate = new short[3];
		ChangeTowardOrganizationRate = new short[3];
		RemoveTowardOrganizationRate = new short[3];
		ChangeBehaviorTypeRate = new short[3];
		Authority = 0;
		TransformId = 0;
		IsNeedShowLevel = true;
		ChangeProfessionRate = new short[3];
		GainLevel = 8;
		GainCount = 1;
	}

	public InformationItem(short templateId, InformationItem other)
	{
		TemplateId = templateId;
		InfoIds = other.InfoIds;
		IsGeneral = other.IsGeneral;
		Type = other.Type;
		BaseGainRate = other.BaseGainRate;
		ExtraGainRate = other.ExtraGainRate;
		CostDays = other.CostDays;
		UsedCountWithMax = other.UsedCountWithMax;
		EffectRate = other.EffectRate;
		ChangeLovingRate = other.ChangeLovingRate;
		ChangeLovingAndHatingRate = other.ChangeLovingAndHatingRate;
		ChangeTowardOrganizationRate = other.ChangeTowardOrganizationRate;
		RemoveTowardOrganizationRate = other.RemoveTowardOrganizationRate;
		ChangeBehaviorTypeRate = other.ChangeBehaviorTypeRate;
		Authority = other.Authority;
		TransformId = other.TransformId;
		IsNeedShowLevel = other.IsNeedShowLevel;
		ChangeProfessionRate = other.ChangeProfessionRate;
		GainLevel = other.GainLevel;
		GainCount = other.GainCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override InformationItem Duplicate(int templateId)
	{
		return new InformationItem((short)templateId, this);
	}
}

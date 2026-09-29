using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class NpcRandomWordsItem : ConfigItem<NpcRandomWordsItem, short>
{
	public readonly short TemplateId;

	public readonly string Words;

	public readonly ENpcRandomWordsFormatRule FormatRule;

	public readonly short HolderMiscId;

	public readonly ENpcRandomWordsType Type;

	public readonly short Weight;

	public readonly sbyte TargetGender;

	public readonly sbyte SelfGender;

	public readonly sbyte SexualOrientation;

	public readonly short AgeLimit;

	public readonly short[] BehaviorLimit;

	public readonly List<short> FeatureLimit;

	public readonly short[] PropertyLimit;

	public readonly short[] FavorLimit;

	public readonly sbyte RelationLimit;

	public readonly List<short> OrganizationGradeLimit;

	public readonly List<short> TaiwuTitleLimit;

	public readonly List<sbyte> MonthLimit;

	public readonly sbyte MapState;

	public readonly ENpcRandomWordsLocation Location;

	public readonly short MapAreaTemplateId;

	public readonly bool IsSectSettlement;

	public readonly sbyte[] XiangshuProgressLimit;

	public readonly sbyte SectStoryOrganizationTemplateId;

	public readonly sbyte SectStoryTaskStatus;

	public readonly string SectStoryBoolParam;

	public readonly List<int> NeedTaskInfos;

	public readonly uint DlcAppId;

	public MiscItem HolderMisc
	{
		[return: MaybeNull]
		get
		{
			return Misc.Instance.GetItemOrDefault(HolderMiscId);
		}
	}

	public MapAreaItem MapAreaTemplate
	{
		[return: MaybeNull]
		get
		{
			return MapArea.Instance.GetItemOrDefault(MapAreaTemplateId);
		}
	}

	public OrganizationItem SectStoryOrganizationTemplate
	{
		[return: MaybeNull]
		get
		{
			return Organization.Instance.GetItemOrDefault(SectStoryOrganizationTemplateId);
		}
	}

	public NpcRandomWordsItem(short templateId, string words, ENpcRandomWordsFormatRule formatRule, short holderMiscId, ENpcRandomWordsType type, short weight, sbyte targetGender, sbyte selfGender, sbyte sexualOrientation, short ageLimit, short[] behaviorLimit, List<short> featureLimit, short[] propertyLimit, short[] favorLimit, sbyte relationLimit, List<short> organizationGradeLimit, List<short> taiwuTitleLimit, List<sbyte> monthLimit, sbyte mapState, ENpcRandomWordsLocation location, short mapAreaTemplateId, bool isSectSettlement, sbyte[] xiangshuProgressLimit, sbyte sectStoryOrganizationTemplateId, sbyte sectStoryTaskStatus, string sectStoryBoolParam, List<int> needTaskInfos, uint dlcAppId)
	{
		TemplateId = templateId;
		Words = words;
		FormatRule = formatRule;
		HolderMiscId = holderMiscId;
		Type = type;
		Weight = weight;
		TargetGender = targetGender;
		SelfGender = selfGender;
		SexualOrientation = sexualOrientation;
		AgeLimit = ageLimit;
		BehaviorLimit = behaviorLimit;
		FeatureLimit = featureLimit;
		PropertyLimit = propertyLimit;
		FavorLimit = favorLimit;
		RelationLimit = relationLimit;
		OrganizationGradeLimit = organizationGradeLimit;
		TaiwuTitleLimit = taiwuTitleLimit;
		MonthLimit = monthLimit;
		MapState = mapState;
		Location = location;
		MapAreaTemplateId = mapAreaTemplateId;
		IsSectSettlement = isSectSettlement;
		XiangshuProgressLimit = xiangshuProgressLimit;
		SectStoryOrganizationTemplateId = sectStoryOrganizationTemplateId;
		SectStoryTaskStatus = sectStoryTaskStatus;
		SectStoryBoolParam = sectStoryBoolParam;
		NeedTaskInfos = needTaskInfos;
		DlcAppId = dlcAppId;
	}

	public NpcRandomWordsItem()
	{
		TemplateId = 0;
		Words = null;
		FormatRule = ENpcRandomWordsFormatRule.None;
		HolderMiscId = 0;
		Type = ENpcRandomWordsType.Invalid;
		Weight = 1;
		TargetGender = -1;
		SelfGender = -1;
		SexualOrientation = -1;
		AgeLimit = -1;
		BehaviorLimit = new short[2] { -500, 500 };
		FeatureLimit = new List<short>();
		PropertyLimit = null;
		FavorLimit = new short[2] { -30000, 30000 };
		RelationLimit = -1;
		OrganizationGradeLimit = new List<short>();
		TaiwuTitleLimit = new List<short>();
		MonthLimit = new List<sbyte>();
		MapState = 0;
		Location = ENpcRandomWordsLocation.None;
		MapAreaTemplateId = 0;
		IsSectSettlement = false;
		XiangshuProgressLimit = new sbyte[2] { 0, 18 };
		SectStoryOrganizationTemplateId = 0;
		SectStoryTaskStatus = -1;
		SectStoryBoolParam = null;
		NeedTaskInfos = new List<int>();
		DlcAppId = 0u;
	}

	public NpcRandomWordsItem(short templateId, NpcRandomWordsItem other)
	{
		TemplateId = templateId;
		Words = other.Words;
		FormatRule = other.FormatRule;
		HolderMiscId = other.HolderMiscId;
		Type = other.Type;
		Weight = other.Weight;
		TargetGender = other.TargetGender;
		SelfGender = other.SelfGender;
		SexualOrientation = other.SexualOrientation;
		AgeLimit = other.AgeLimit;
		BehaviorLimit = other.BehaviorLimit;
		FeatureLimit = other.FeatureLimit;
		PropertyLimit = other.PropertyLimit;
		FavorLimit = other.FavorLimit;
		RelationLimit = other.RelationLimit;
		OrganizationGradeLimit = other.OrganizationGradeLimit;
		TaiwuTitleLimit = other.TaiwuTitleLimit;
		MonthLimit = other.MonthLimit;
		MapState = other.MapState;
		Location = other.Location;
		MapAreaTemplateId = other.MapAreaTemplateId;
		IsSectSettlement = other.IsSectSettlement;
		XiangshuProgressLimit = other.XiangshuProgressLimit;
		SectStoryOrganizationTemplateId = other.SectStoryOrganizationTemplateId;
		SectStoryTaskStatus = other.SectStoryTaskStatus;
		SectStoryBoolParam = other.SectStoryBoolParam;
		NeedTaskInfos = other.NeedTaskInfos;
		DlcAppId = other.DlcAppId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override NpcRandomWordsItem Duplicate(int templateId)
	{
		return new NpcRandomWordsItem((short)templateId, this);
	}
}

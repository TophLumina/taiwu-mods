using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMissionItem : ConfigItem<CharacterMissionItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly bool IsHidden;

	public readonly ECharacterMissionType Type;

	public readonly ECharacterMissionGroup Group;

	public readonly sbyte Duration;

	public readonly sbyte KeepDuration;

	public readonly string[] BubbleContentInProgress;

	public readonly string[] BubbleContentSuccess;

	public readonly string[] BubbleContentFail;

	public readonly sbyte Priority;

	public readonly sbyte[] PersonalityTypes;

	public readonly int[] Goals;

	public readonly sbyte RequiredMapState;

	public readonly sbyte RequiredOrganization;

	public readonly sbyte RequiredGoodness;

	public readonly sbyte RequiredGradeGroup;

	public readonly short RequiredOrgMember;

	public readonly sbyte RequiredBehaviorType;

	public readonly sbyte LifeSkillType;

	public CharacterMissionItem(int templateId, string name, bool isHidden, ECharacterMissionType type, ECharacterMissionGroup group, sbyte duration, sbyte keepDuration, string[] bubbleContentInProgress, string[] bubbleContentSuccess, string[] bubbleContentFail, sbyte priority, sbyte[] personalityTypes, int[] goals, sbyte requiredMapState, sbyte requiredOrganization, sbyte requiredGoodness, sbyte requiredGradeGroup, short requiredOrgMember, sbyte requiredBehaviorType, sbyte lifeSkillType)
	{
		TemplateId = templateId;
		Name = name;
		IsHidden = isHidden;
		Type = type;
		Group = group;
		Duration = duration;
		KeepDuration = keepDuration;
		BubbleContentInProgress = bubbleContentInProgress;
		BubbleContentSuccess = bubbleContentSuccess;
		BubbleContentFail = bubbleContentFail;
		Priority = priority;
		PersonalityTypes = personalityTypes;
		Goals = goals;
		RequiredMapState = requiredMapState;
		RequiredOrganization = requiredOrganization;
		RequiredGoodness = requiredGoodness;
		RequiredGradeGroup = requiredGradeGroup;
		RequiredOrgMember = requiredOrgMember;
		RequiredBehaviorType = requiredBehaviorType;
		LifeSkillType = lifeSkillType;
	}

	public CharacterMissionItem()
	{
		TemplateId = 0;
		Name = null;
		IsHidden = false;
		Type = ECharacterMissionType.Sect;
		Group = ECharacterMissionGroup.Belonging;
		Duration = 4;
		KeepDuration = 2;
		BubbleContentInProgress = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		BubbleContentSuccess = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		BubbleContentFail = new string[5] { "{}", "{}", "{}", "{}", "{}" };
		Priority = 0;
		PersonalityTypes = new sbyte[5] { 0, 2, 1, 3, 4 };
		Goals = null;
		RequiredMapState = 0;
		RequiredOrganization = 0;
		RequiredGoodness = 0;
		RequiredGradeGroup = -1;
		RequiredOrgMember = 0;
		RequiredBehaviorType = 0;
		LifeSkillType = 0;
	}

	public CharacterMissionItem(int templateId, CharacterMissionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IsHidden = other.IsHidden;
		Type = other.Type;
		Group = other.Group;
		Duration = other.Duration;
		KeepDuration = other.KeepDuration;
		BubbleContentInProgress = other.BubbleContentInProgress;
		BubbleContentSuccess = other.BubbleContentSuccess;
		BubbleContentFail = other.BubbleContentFail;
		Priority = other.Priority;
		PersonalityTypes = other.PersonalityTypes;
		Goals = other.Goals;
		RequiredMapState = other.RequiredMapState;
		RequiredOrganization = other.RequiredOrganization;
		RequiredGoodness = other.RequiredGoodness;
		RequiredGradeGroup = other.RequiredGradeGroup;
		RequiredOrgMember = other.RequiredOrgMember;
		RequiredBehaviorType = other.RequiredBehaviorType;
		LifeSkillType = other.LifeSkillType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterMissionItem Duplicate(int templateId)
	{
		return new CharacterMissionItem(templateId, this);
	}
}

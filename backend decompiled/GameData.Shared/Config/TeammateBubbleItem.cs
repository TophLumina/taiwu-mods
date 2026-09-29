using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class TeammateBubbleItem : ConfigItem<TeammateBubbleItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly ETeammateBubbleBubbleElementType BubbleElementType;

	public readonly int Duration;

	public readonly sbyte MapStateTemplateId;

	public readonly short MapBlockTemplateId;

	public readonly List<short> CharacterTemplateIdList;

	public readonly List<short> CharacterFeatureTemplateIdList;

	public readonly List<int> AdventureTemplateIdList;

	public readonly sbyte PersonalityType;

	public readonly string SpecialDesc0;

	public readonly string SpecialDesc1;

	public readonly string SpecialDesc2;

	public readonly string SpecialDesc3;

	public readonly string SpecialDesc4;

	public readonly string FamilyDesc;

	public readonly string FriendDesc;

	public readonly string[] Cricket;

	public readonly string[] BehaviorDesc;

	public readonly string[] Parameters;

	public MapStateItem MapStateTemplate
	{
		[return: MaybeNull]
		get
		{
			return MapState.Instance.GetItemOrDefault(MapStateTemplateId);
		}
	}

	public MapBlockItem MapBlockTemplate
	{
		[return: MaybeNull]
		get
		{
			return MapBlock.Instance.GetItemOrDefault(MapBlockTemplateId);
		}
	}

	public TeammateBubbleItem(short templateId, string name, ETeammateBubbleBubbleElementType bubbleElementType, int duration, sbyte mapStateTemplateId, short mapBlockTemplateId, List<short> characterTemplateIdList, List<short> characterFeatureTemplateIdList, List<int> adventureTemplateIdList, sbyte personalityType, string specialDesc0, string specialDesc1, string specialDesc2, string specialDesc3, string specialDesc4, string familyDesc, string friendDesc, string[] cricket, string[] behaviorDesc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		BubbleElementType = bubbleElementType;
		Duration = duration;
		MapStateTemplateId = mapStateTemplateId;
		MapBlockTemplateId = mapBlockTemplateId;
		CharacterTemplateIdList = characterTemplateIdList;
		CharacterFeatureTemplateIdList = characterFeatureTemplateIdList;
		AdventureTemplateIdList = adventureTemplateIdList;
		PersonalityType = personalityType;
		SpecialDesc0 = specialDesc0;
		SpecialDesc1 = specialDesc1;
		SpecialDesc2 = specialDesc2;
		SpecialDesc3 = specialDesc3;
		SpecialDesc4 = specialDesc4;
		FamilyDesc = familyDesc;
		FriendDesc = friendDesc;
		Cricket = cricket;
		BehaviorDesc = behaviorDesc;
		Parameters = parameters;
	}

	public TeammateBubbleItem()
	{
		TemplateId = 0;
		Name = null;
		BubbleElementType = ETeammateBubbleBubbleElementType.Traveling;
		Duration = 180;
		MapStateTemplateId = 0;
		MapBlockTemplateId = 0;
		CharacterTemplateIdList = null;
		CharacterFeatureTemplateIdList = null;
		AdventureTemplateIdList = null;
		PersonalityType = 0;
		SpecialDesc0 = null;
		SpecialDesc1 = null;
		SpecialDesc2 = null;
		SpecialDesc3 = null;
		SpecialDesc4 = null;
		FamilyDesc = null;
		FriendDesc = null;
		Cricket = null;
		BehaviorDesc = new string[5]
		{
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty
		};
		Parameters = new string[3] { "", "", "" };
	}

	public TeammateBubbleItem(short templateId, TeammateBubbleItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		BubbleElementType = other.BubbleElementType;
		Duration = other.Duration;
		MapStateTemplateId = other.MapStateTemplateId;
		MapBlockTemplateId = other.MapBlockTemplateId;
		CharacterTemplateIdList = other.CharacterTemplateIdList;
		CharacterFeatureTemplateIdList = other.CharacterFeatureTemplateIdList;
		AdventureTemplateIdList = other.AdventureTemplateIdList;
		PersonalityType = other.PersonalityType;
		SpecialDesc0 = other.SpecialDesc0;
		SpecialDesc1 = other.SpecialDesc1;
		SpecialDesc2 = other.SpecialDesc2;
		SpecialDesc3 = other.SpecialDesc3;
		SpecialDesc4 = other.SpecialDesc4;
		FamilyDesc = other.FamilyDesc;
		FriendDesc = other.FriendDesc;
		Cricket = other.Cricket;
		BehaviorDesc = other.BehaviorDesc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TeammateBubbleItem Duplicate(int templateId)
	{
		return new TeammateBubbleItem((short)templateId, this);
	}
}

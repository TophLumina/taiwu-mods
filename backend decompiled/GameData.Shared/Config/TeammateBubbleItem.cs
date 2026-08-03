using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeammateBubbleItem : ConfigItem<TeammateBubbleItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 地图元素
	/// </summary>
	public readonly ETeammateBubbleBubbleElementType BubbleElementType;

	/// <summary>
	/// 显示时间
	/// </summary>
	public readonly int Duration;

	/// <summary>
	/// 州域
	/// </summary>
	public readonly sbyte MapStateTemplateId;

	/// <summary>
	/// 地块
	/// </summary>
	public readonly short MapBlockTemplateId;

	/// <summary>
	/// 人物列表
	/// </summary>
	public readonly List<short> CharacterTemplateIdList;

	/// <summary>
	/// 人物特性列表
	/// </summary>
	public readonly List<short> CharacterFeatureTemplateIdList;

	/// <summary>
	/// 奇遇列表
	/// </summary>
	public readonly List<int> AdventureTemplateIdList;

	/// <summary>
	/// 七元优先
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 谷中密友
	/// </summary>
	public readonly string SpecialDesc0;

	/// <summary>
	/// 徐小猫
	/// </summary>
	public readonly string SpecialDesc1;

	/// <summary>
	/// 郭彦
	/// </summary>
	public readonly string SpecialDesc2;

	/// <summary>
	/// 司徒还月
	/// </summary>
	public readonly string SpecialDesc3;

	/// <summary>
	/// 阿牛
	/// </summary>
	public readonly string SpecialDesc4;

	/// <summary>
	/// 亲属
	/// </summary>
	public readonly string FamilyDesc;

	/// <summary>
	/// 好友
	/// </summary>
	public readonly string FriendDesc;

	/// <summary>
	/// 促织
	/// </summary>
	public readonly string[] Cricket;

	public readonly string[] BehaviorDesc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="bubbleElementType">地图元素</param>
	/// <param name="duration">显示时间</param>
	/// <param name="mapStateTemplateId">州域</param>
	/// <param name="mapBlockTemplateId">地块</param>
	/// <param name="characterTemplateIdList">人物列表</param>
	/// <param name="characterFeatureTemplateIdList">人物特性列表</param>
	/// <param name="adventureTemplateIdList">奇遇列表</param>
	/// <param name="personalityType">七元优先</param>
	/// <param name="specialDesc0">谷中密友</param>
	/// <param name="specialDesc1">徐小猫</param>
	/// <param name="specialDesc2">郭彦</param>
	/// <param name="specialDesc3">司徒还月</param>
	/// <param name="specialDesc4">阿牛</param>
	/// <param name="familyDesc">亲属</param>
	/// <param name="friendDesc">好友</param>
	/// <param name="cricket">促织</param>
	/// <param name="behaviorDesc"></param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TeammateBubbleItem Duplicate(int templateId)
	{
		return new TeammateBubbleItem((short)templateId, this);
	}
}

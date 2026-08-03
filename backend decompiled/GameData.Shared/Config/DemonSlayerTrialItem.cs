using System;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrialItem : ConfigItem<DemonSlayerTrialItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 特殊能力
	/// </summary>
	public readonly string SpecialDesc;

	/// <summary>
	/// 角色
	/// </summary>
	public readonly short CharacterId;

	/// <summary>
	/// 首通奖励
	/// </summary>
	public readonly short FirstTimeRewards;

	/// <summary>
	/// 首通奖励关联罗汉
	/// </summary>
	public readonly sbyte FirstTimeRewardLuohan;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">描述</param>
	/// <param name="specialDesc">特殊能力</param>
	/// <param name="characterId">角色</param>
	/// <param name="firstTimeRewards">首通奖励</param>
	/// <param name="firstTimeRewardLuohan">首通奖励关联罗汉</param>
	public DemonSlayerTrialItem(int templateId, string desc, string specialDesc, short characterId, short firstTimeRewards, sbyte firstTimeRewardLuohan)
	{
		TemplateId = templateId;
		Desc = desc;
		SpecialDesc = specialDesc;
		CharacterId = characterId;
		FirstTimeRewards = firstTimeRewards;
		FirstTimeRewardLuohan = firstTimeRewardLuohan;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DemonSlayerTrialItem()
	{
		TemplateId = 0;
		Desc = null;
		SpecialDesc = null;
		CharacterId = 0;
		FirstTimeRewards = 0;
		FirstTimeRewardLuohan = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DemonSlayerTrialItem(int templateId, DemonSlayerTrialItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		SpecialDesc = other.SpecialDesc;
		CharacterId = other.CharacterId;
		FirstTimeRewards = other.FirstTimeRewards;
		FirstTimeRewardLuohan = other.FirstTimeRewardLuohan;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DemonSlayerTrialItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialItem(templateId, this);
	}
}

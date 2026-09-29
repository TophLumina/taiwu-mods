using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class DemonSlayerTrialItem : ConfigItem<DemonSlayerTrialItem, int>
{
	public readonly int TemplateId;

	public readonly string Desc;

	public readonly string SpecialDesc;

	public readonly short CharacterId;

	public readonly short FirstTimeRewards;

	public readonly sbyte FirstTimeRewardLuohan;

	public CharacterItem Character
	{
		[return: MaybeNull]
		get
		{
			return Config.Character.Instance.GetItemOrDefault(CharacterId);
		}
	}

	public DemonSlayerTrialItem(int templateId, string desc, string specialDesc, short characterId, short firstTimeRewards, sbyte firstTimeRewardLuohan)
	{
		TemplateId = templateId;
		Desc = desc;
		SpecialDesc = specialDesc;
		CharacterId = characterId;
		FirstTimeRewards = firstTimeRewards;
		FirstTimeRewardLuohan = firstTimeRewardLuohan;
	}

	public DemonSlayerTrialItem()
	{
		TemplateId = 0;
		Desc = null;
		SpecialDesc = null;
		CharacterId = 0;
		FirstTimeRewards = 0;
		FirstTimeRewardLuohan = 0;
	}

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

	public override DemonSlayerTrialItem Duplicate(int templateId)
	{
		return new DemonSlayerTrialItem(templateId, this);
	}
}

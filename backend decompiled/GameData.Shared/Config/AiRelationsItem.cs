using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class AiRelationsItem : ConfigItem<AiRelationsItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte PersonalityType;

	public readonly short[] MinFavorability;

	public readonly short[] MaxFavorability;

	public readonly RelationTriggerOnBehaviorChance[] Probability;

	public readonly short NoncontradictoryBehaviorAjust;

	public readonly short NoncontradictoryFameAjust;

	public readonly short EnemySectMemberAdjust;

	public readonly short FriendlySectMemberAdjust;

	public AiRelationsItem(short templateId, sbyte personalityType, short[] minFavorability, short[] maxFavorability, RelationTriggerOnBehaviorChance[] probability, short noncontradictoryBehaviorAjust, short noncontradictoryFameAjust, short enemySectMemberAdjust, short friendlySectMemberAdjust)
	{
		TemplateId = templateId;
		PersonalityType = personalityType;
		MinFavorability = minFavorability;
		MaxFavorability = maxFavorability;
		Probability = probability;
		NoncontradictoryBehaviorAjust = noncontradictoryBehaviorAjust;
		NoncontradictoryFameAjust = noncontradictoryFameAjust;
		EnemySectMemberAdjust = enemySectMemberAdjust;
		FriendlySectMemberAdjust = friendlySectMemberAdjust;
	}

	public AiRelationsItem()
	{
		TemplateId = 0;
		PersonalityType = 0;
		MinFavorability = new short[0];
		MaxFavorability = new short[0];
		Probability = new RelationTriggerOnBehaviorChance[0];
		NoncontradictoryBehaviorAjust = 0;
		NoncontradictoryFameAjust = 0;
		EnemySectMemberAdjust = 0;
		FriendlySectMemberAdjust = 0;
	}

	public AiRelationsItem(short templateId, AiRelationsItem other)
	{
		TemplateId = templateId;
		PersonalityType = other.PersonalityType;
		MinFavorability = other.MinFavorability;
		MaxFavorability = other.MaxFavorability;
		Probability = other.Probability;
		NoncontradictoryBehaviorAjust = other.NoncontradictoryBehaviorAjust;
		NoncontradictoryFameAjust = other.NoncontradictoryFameAjust;
		EnemySectMemberAdjust = other.EnemySectMemberAdjust;
		FriendlySectMemberAdjust = other.FriendlySectMemberAdjust;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiRelationsItem Duplicate(int templateId)
	{
		return new AiRelationsItem((short)templateId, this);
	}
}

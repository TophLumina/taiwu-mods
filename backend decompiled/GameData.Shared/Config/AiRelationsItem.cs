using System;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class AiRelationsItem : ConfigItem<AiRelationsItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 七元
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 好感下限
	/// - 要求好感必须不低于立场对应的值
	/// </summary>
	public readonly short[] MinFavorability;

	/// <summary>
	/// 好感上限
	/// - 要求好感必须不高于立场对应的值
	/// </summary>
	public readonly short[] MaxFavorability;

	/// <summary>
	/// 发起机率（万分之）
	/// - 要求好感必须不高于立场对应的值
	/// </summary>
	public readonly RelationTriggerOnBehaviorChance[] Probability;

	/// <summary>
	/// 机率修正 - 立场不对立
	/// </summary>
	public readonly short NoncontradictoryBehaviorAjust;

	/// <summary>
	/// 机率修正 - 名誉正负相同或亦正亦邪
	/// </summary>
	public readonly short NoncontradictoryFameAjust;

	/// <summary>
	/// 机率修正 - 敌对门派
	/// </summary>
	public readonly short EnemySectMemberAdjust;

	/// <summary>
	/// 机率修正 - 友好门派
	/// </summary>
	public readonly short FriendlySectMemberAdjust;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="personalityType">七元</param>
	/// <param name="minFavorability">好感下限 - 要求好感必须不低于立场对应的值</param>
	/// <param name="maxFavorability">好感上限 - 要求好感必须不高于立场对应的值</param>
	/// <param name="probability">发起机率（万分之） - 要求好感必须不高于立场对应的值</param>
	/// <param name="noncontradictoryBehaviorAjust">机率修正 - 立场不对立</param>
	/// <param name="noncontradictoryFameAjust">机率修正 - 名誉正负相同或亦正亦邪</param>
	/// <param name="enemySectMemberAdjust">机率修正 - 敌对门派</param>
	/// <param name="friendlySectMemberAdjust">机率修正 - 友好门派</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiRelationsItem Duplicate(int templateId)
	{
		return new AiRelationsItem((short)templateId, this);
	}
}

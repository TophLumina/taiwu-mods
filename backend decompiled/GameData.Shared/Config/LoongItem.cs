using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class LoongItem : ConfigItem<LoongItem, short>
{
	public readonly short TemplateId;

	public readonly short CharTemplateId;

	public readonly short MinionCharTemplateId;

	public readonly short MapBlock;

	public readonly sbyte PersonalityType;

	public readonly sbyte PersonalityRequirement;

	public readonly short ClothingTemplateId;

	public readonly sbyte WorldState;

	public readonly string BlockEffectTip;

	public readonly short DebuffCountIncNotification;

	public readonly short DebuffCountDecNotification;

	public readonly string EnterCombatEffect;

	public readonly string EnterCombatSound;

	public readonly short Jiao;

	public readonly short Task;

	public readonly string DebuffMarkOnChar;

	public CharacterItem CharTemplate
	{
		[return: MaybeNull]
		get
		{
			return Character.Instance.GetItemOrDefault(CharTemplateId);
		}
	}

	public CharacterItem MinionCharTemplate
	{
		[return: MaybeNull]
		get
		{
			return Character.Instance.GetItemOrDefault(MinionCharTemplateId);
		}
	}

	public ClothingItem ClothingTemplate
	{
		[return: MaybeNull]
		get
		{
			return Clothing.Instance.GetItemOrDefault(ClothingTemplateId);
		}
	}

	public LoongItem(short templateId, short charTemplateId, short minionCharTemplateId, short mapBlock, sbyte personalityType, sbyte personalityRequirement, short clothingTemplateId, sbyte worldState, string blockEffectTip, short debuffCountIncNotification, short debuffCountDecNotification, string enterCombatEffect, string enterCombatSound, short jiao, short task, string debuffMarkOnChar)
	{
		TemplateId = templateId;
		CharTemplateId = charTemplateId;
		MinionCharTemplateId = minionCharTemplateId;
		MapBlock = mapBlock;
		PersonalityType = personalityType;
		PersonalityRequirement = personalityRequirement;
		ClothingTemplateId = clothingTemplateId;
		WorldState = worldState;
		BlockEffectTip = blockEffectTip;
		DebuffCountIncNotification = debuffCountIncNotification;
		DebuffCountDecNotification = debuffCountDecNotification;
		EnterCombatEffect = enterCombatEffect;
		EnterCombatSound = enterCombatSound;
		Jiao = jiao;
		Task = task;
		DebuffMarkOnChar = debuffMarkOnChar;
	}

	public LoongItem()
	{
		TemplateId = 0;
		CharTemplateId = 0;
		MinionCharTemplateId = 0;
		MapBlock = 0;
		PersonalityType = 0;
		PersonalityRequirement = 0;
		ClothingTemplateId = 0;
		WorldState = 0;
		BlockEffectTip = null;
		DebuffCountIncNotification = 0;
		DebuffCountDecNotification = 0;
		EnterCombatEffect = null;
		EnterCombatSound = null;
		Jiao = 0;
		Task = 0;
		DebuffMarkOnChar = null;
	}

	public LoongItem(short templateId, LoongItem other)
	{
		TemplateId = templateId;
		CharTemplateId = other.CharTemplateId;
		MinionCharTemplateId = other.MinionCharTemplateId;
		MapBlock = other.MapBlock;
		PersonalityType = other.PersonalityType;
		PersonalityRequirement = other.PersonalityRequirement;
		ClothingTemplateId = other.ClothingTemplateId;
		WorldState = other.WorldState;
		BlockEffectTip = other.BlockEffectTip;
		DebuffCountIncNotification = other.DebuffCountIncNotification;
		DebuffCountDecNotification = other.DebuffCountDecNotification;
		EnterCombatEffect = other.EnterCombatEffect;
		EnterCombatSound = other.EnterCombatSound;
		Jiao = other.Jiao;
		Task = other.Task;
		DebuffMarkOnChar = other.DebuffMarkOnChar;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LoongItem Duplicate(int templateId)
	{
		return new LoongItem((short)templateId, this);
	}
}

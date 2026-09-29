using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class ChickenItem : ConfigItem<ChickenItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Display;

	public readonly sbyte Grade;

	public readonly sbyte PersonalityType;

	public readonly int PersonalityValue;

	public readonly short FeatureId;

	public readonly short EventActorTemplateId;

	public readonly string EventDesc;

	public readonly EChickenChickenColor ChickenColor;

	public readonly int OffsetX;

	public readonly int OffsetY;

	public CharacterFeatureItem Feature
	{
		[return: MaybeNull]
		get
		{
			return CharacterFeature.Instance.GetItemOrDefault(FeatureId);
		}
	}

	public EventActorsItem EventActorTemplate
	{
		[return: MaybeNull]
		get
		{
			return EventActors.Instance.GetItemOrDefault(EventActorTemplateId);
		}
	}

	public ChickenItem(short templateId, string name, string desc, string display, sbyte grade, sbyte personalityType, int personalityValue, short featureId, short eventActorTemplateId, string eventDesc, EChickenChickenColor chickenColor, int offsetX, int offsetY)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Display = display;
		Grade = grade;
		PersonalityType = personalityType;
		PersonalityValue = personalityValue;
		FeatureId = featureId;
		EventActorTemplateId = eventActorTemplateId;
		EventDesc = eventDesc;
		ChickenColor = chickenColor;
		OffsetX = offsetX;
		OffsetY = offsetY;
	}

	public ChickenItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Display = null;
		Grade = 0;
		PersonalityType = 0;
		PersonalityValue = 0;
		FeatureId = 0;
		EventActorTemplateId = 0;
		EventDesc = null;
		ChickenColor = (EChickenChickenColor)0;
		OffsetX = 0;
		OffsetY = 0;
	}

	public ChickenItem(short templateId, ChickenItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Display = other.Display;
		Grade = other.Grade;
		PersonalityType = other.PersonalityType;
		PersonalityValue = other.PersonalityValue;
		FeatureId = other.FeatureId;
		EventActorTemplateId = other.EventActorTemplateId;
		EventDesc = other.EventDesc;
		ChickenColor = other.ChickenColor;
		OffsetX = other.OffsetX;
		OffsetY = other.OffsetY;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ChickenItem Duplicate(int templateId)
	{
		return new ChickenItem((short)templateId, this);
	}
}

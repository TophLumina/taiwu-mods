using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class SmarterChickenItem : ConfigItem<SmarterChickenItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte PersonalityType;

	public readonly short CharacterMale;

	public readonly short CharacterFemale;

	public readonly short CharacterFeature;

	public readonly short FeatherMaterialId;

	public MaterialItem FeatherMaterial
	{
		[return: MaybeNull]
		get
		{
			return Material.Instance.GetItemOrDefault(FeatherMaterialId);
		}
	}

	public SmarterChickenItem(short templateId, sbyte personalityType, short characterMale, short characterFemale, short characterFeature, short featherMaterialId)
	{
		TemplateId = templateId;
		PersonalityType = personalityType;
		CharacterMale = characterMale;
		CharacterFemale = characterFemale;
		CharacterFeature = characterFeature;
		FeatherMaterialId = featherMaterialId;
	}

	public SmarterChickenItem()
	{
		TemplateId = 0;
		PersonalityType = 0;
		CharacterMale = 0;
		CharacterFemale = 0;
		CharacterFeature = 0;
		FeatherMaterialId = 0;
	}

	public SmarterChickenItem(short templateId, SmarterChickenItem other)
	{
		TemplateId = templateId;
		PersonalityType = other.PersonalityType;
		CharacterMale = other.CharacterMale;
		CharacterFemale = other.CharacterFemale;
		CharacterFeature = other.CharacterFeature;
		FeatherMaterialId = other.FeatherMaterialId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SmarterChickenItem Duplicate(int templateId)
	{
		return new SmarterChickenItem((short)templateId, this);
	}
}

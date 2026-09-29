using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMatcherItem : ConfigItem<CharacterMatcherItem, short>
{
	public readonly short TemplateId;

	public readonly ECharacterMatcherAgeType AgeType;

	public readonly ECharacterMatcherIdentityType IdentityType;

	public readonly sbyte MerchantType;

	public readonly ECharacterMatcherGenderType GenderType;

	public readonly int[] FavorRange;

	public readonly sbyte Organization;

	public readonly ECharacterMatcherSubCondition[] SubConditions;

	public readonly ECharacterMatcherTargetType TargetType;

	public readonly string TargetKey;

	public readonly ECharacterMatcherTargetSubCondition[] TargetSubConditions;

	public CharacterMatcherItem(short templateId, ECharacterMatcherAgeType ageType, ECharacterMatcherIdentityType identityType, sbyte merchantType, ECharacterMatcherGenderType genderType, int[] favorRange, sbyte organization, ECharacterMatcherSubCondition[] subConditions, ECharacterMatcherTargetType targetType, string targetKey, ECharacterMatcherTargetSubCondition[] targetSubConditions)
	{
		TemplateId = templateId;
		AgeType = ageType;
		IdentityType = identityType;
		MerchantType = merchantType;
		GenderType = genderType;
		FavorRange = favorRange;
		Organization = organization;
		SubConditions = subConditions;
		TargetType = targetType;
		TargetKey = targetKey;
		TargetSubConditions = targetSubConditions;
	}

	public CharacterMatcherItem()
	{
		TemplateId = 0;
		AgeType = ECharacterMatcherAgeType.NotRestricted;
		IdentityType = ECharacterMatcherIdentityType.NotRestricted;
		MerchantType = 0;
		GenderType = ECharacterMatcherGenderType.NotRestricted;
		FavorRange = null;
		Organization = 0;
		SubConditions = null;
		TargetType = ECharacterMatcherTargetType.None;
		TargetKey = null;
		TargetSubConditions = null;
	}

	public CharacterMatcherItem(short templateId, CharacterMatcherItem other)
	{
		TemplateId = templateId;
		AgeType = other.AgeType;
		IdentityType = other.IdentityType;
		MerchantType = other.MerchantType;
		GenderType = other.GenderType;
		FavorRange = other.FavorRange;
		Organization = other.Organization;
		SubConditions = other.SubConditions;
		TargetType = other.TargetType;
		TargetKey = other.TargetKey;
		TargetSubConditions = other.TargetSubConditions;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterMatcherItem Duplicate(int templateId)
	{
		return new CharacterMatcherItem((short)templateId, this);
	}
}

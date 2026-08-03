using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMatcherItem : ConfigItem<CharacterMatcherItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 要求年龄类型
	/// </summary>
	public readonly ECharacterMatcherAgeType AgeType;

	/// <summary>
	/// 要求身份类型
	/// </summary>
	public readonly ECharacterMatcherIdentityType IdentityType;

	/// <summary>
	/// 要求所属商会
	/// - 该列只在要求身份类型为商人时才会产生有效结果.
	/// </summary>
	public readonly sbyte MerchantType;

	/// <summary>
	/// 要求性别类型
	/// </summary>
	public readonly ECharacterMatcherGenderType GenderType;

	/// <summary>
	/// 要求对太吾好感范围
	/// - 具体好感数值的上下限，包含最小值，不包含最大值，不填写表示不限制
	/// </summary>
	public readonly int[] FavorRange;

	/// <summary>
	/// 要求门派
	/// </summary>
	public readonly sbyte Organization;

	/// <summary>
	/// 组合条件
	/// - 该列自动生成
	/// </summary>
	public readonly ECharacterMatcherSubCondition[] SubConditions;

	/// <summary>
	/// 指定目标类型
	/// </summary>
	public readonly ECharacterMatcherTargetType TargetType;

	/// <summary>
	/// 奇遇填充预留人物Key
	/// </summary>
	public readonly string TargetKey;

	/// <summary>
	/// 组合目标条件
	/// - 该列自动生成
	/// </summary>
	public readonly ECharacterMatcherTargetSubCondition[] TargetSubConditions;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="ageType">要求年龄类型</param>
	/// <param name="identityType">要求身份类型</param>
	/// <param name="merchantType">要求所属商会 - 该列只在要求身份类型为商人时才会产生有效结果.</param>
	/// <param name="genderType">要求性别类型</param>
	/// <param name="favorRange">要求对太吾好感范围 - 具体好感数值的上下限，包含最小值，不包含最大值，不填写表示不限制</param>
	/// <param name="organization">要求门派</param>
	/// <param name="subConditions">组合条件 - 该列自动生成</param>
	/// <param name="targetType">指定目标类型</param>
	/// <param name="targetKey">奇遇填充预留人物Key</param>
	/// <param name="targetSubConditions">组合目标条件 - 该列自动生成</param>
	public CharacterMatcherItem(byte templateId, ECharacterMatcherAgeType ageType, ECharacterMatcherIdentityType identityType, sbyte merchantType, ECharacterMatcherGenderType genderType, int[] favorRange, sbyte organization, ECharacterMatcherSubCondition[] subConditions, ECharacterMatcherTargetType targetType, string targetKey, ECharacterMatcherTargetSubCondition[] targetSubConditions)
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterMatcherItem(byte templateId, CharacterMatcherItem other)
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterMatcherItem Duplicate(int templateId)
	{
		return new CharacterMatcherItem((byte)templateId, this);
	}
}

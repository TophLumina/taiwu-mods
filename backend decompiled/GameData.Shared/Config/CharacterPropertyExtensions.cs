using System.Runtime.CompilerServices;
using Config.ConfigCells.Character;

namespace Config;

/// <summary>
/// 角色属性扩展方法
/// </summary>
public static class CharacterPropertyExtensions
{
	public static ERefiningEffectAccessoryType ToRefiningEffectAccessoryType(this ECharacterPropertyReferencedType propertyType)
	{
		return propertyType switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => ERefiningEffectAccessoryType.HitRateStrength, 
			ECharacterPropertyReferencedType.HitRateTechnique => ERefiningEffectAccessoryType.HitRateTechnique, 
			ECharacterPropertyReferencedType.HitRateSpeed => ERefiningEffectAccessoryType.HitRateSpeed, 
			ECharacterPropertyReferencedType.HitRateMind => ERefiningEffectAccessoryType.HitRateMind, 
			ECharacterPropertyReferencedType.AvoidRateStrength => ERefiningEffectAccessoryType.AvoidRateStrength, 
			ECharacterPropertyReferencedType.AvoidRateTechnique => ERefiningEffectAccessoryType.AvoidRateTechnique, 
			ECharacterPropertyReferencedType.AvoidRateSpeed => ERefiningEffectAccessoryType.AvoidRateSpeed, 
			ECharacterPropertyReferencedType.AvoidRateMind => ERefiningEffectAccessoryType.AvoidRateMind, 
			ECharacterPropertyReferencedType.PersonalityCalm => ERefiningEffectAccessoryType.Calm, 
			ECharacterPropertyReferencedType.PersonalityClever => ERefiningEffectAccessoryType.Clever, 
			ECharacterPropertyReferencedType.PersonalityEnthusiastic => ERefiningEffectAccessoryType.Enthusiastic, 
			ECharacterPropertyReferencedType.PersonalityBrave => ERefiningEffectAccessoryType.Brave, 
			ECharacterPropertyReferencedType.PersonalityFirm => ERefiningEffectAccessoryType.Firm, 
			ECharacterPropertyReferencedType.PersonalityLucky => ERefiningEffectAccessoryType.Lucky, 
			ECharacterPropertyReferencedType.PersonalityPerceptive => ERefiningEffectAccessoryType.Perceptive, 
			_ => ERefiningEffectAccessoryType.Invalid, 
		};
	}

	/// <summary>
	/// 根据类型计算和，类型相同时返回加值，类型不同时返回零
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Sum(this ECharacterPropertyReferencedType propertyType, PropertyAndValue propertyAndValue)
	{
		if (propertyType != (ECharacterPropertyReferencedType)propertyAndValue.PropertyId)
		{
			return 0;
		}
		return propertyAndValue.Value;
	}

	/// <summary>
	/// 根据类型计算和，类型相同时叠加，类型不同时返回原值
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Sum(ECharacterPropertyReferencedType propertyType, PropertyAndValue propertyAndValue, int value)
	{
		if (propertyType != (ECharacterPropertyReferencedType)propertyAndValue.PropertyId)
		{
			return value;
		}
		return value + propertyAndValue.Value;
	}
}

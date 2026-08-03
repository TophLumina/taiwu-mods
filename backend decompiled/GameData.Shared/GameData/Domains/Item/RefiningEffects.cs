using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 精制效果
/// </summary>
public struct RefiningEffects : ISerializableGameData
{
	/// <summary>
	/// 精制材料
	/// </summary>
	private unsafe fixed short _materialTemplateIds[5];

	/// <summary>
	/// 最大精制栏位
	/// </summary>
	public const int MaxRefineCount = 5;

	/// <summary>
	/// 是否经过精制
	/// </summary>
	public bool IsRefined => GetTotalRefiningCount() > 0;

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值,依赖于 <see cref="F:GameData.Domains.Item.RefiningEffects.MaxRefineCount" /> 的值
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* materialTemplateIds = _materialTemplateIds)
		{
			*(long*)materialTemplateIds = -1L;
			materialTemplateIds[4] = -1;
		}
	}

	/// <summary>
	/// 获取栏位所有的材料
	/// </summary>
	/// <returns></returns>
	public short[] GetAllMaterialTemplateIds()
	{
		short[] ids = new short[5];
		for (int i = 0; i < 5; i++)
		{
			ids[i] = GetMaterialTemplateIdAt(i);
		}
		return ids;
	}

	/// <summary>
	/// 获取指定栏位的精制材料
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public unsafe short GetMaterialTemplateIdAt(int index)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		return _materialTemplateIds[index];
	}

	/// <summary>
	/// 移除指定栏位的精制材料
	/// </summary>
	/// <param name="index"></param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public unsafe void RemoveAt(int index)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		_materialTemplateIds[index] = -1;
	}

	/// <summary>
	/// 设置指定栏位的精制材料
	/// </summary>
	/// <param name="index"></param>
	/// <param name="materialTemplateId"></param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public unsafe void Set(int index, short materialTemplateId)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		_materialTemplateIds[index] = materialTemplateId;
	}

	/// <summary>
	/// 获取总精制次数
	/// </summary>
	/// <returns></returns>
	public unsafe sbyte GetTotalRefiningCount()
	{
		sbyte refiningCount = 0;
		for (int i = 0; i < 5; i++)
		{
			if (_materialTemplateIds[i] >= 0)
			{
				refiningCount++;
			}
		}
		return refiningCount;
	}

	/// <summary>
	/// 获取指定武器属性的精制总效果
	/// </summary>
	/// <param name="effectType"></param>
	/// <returns></returns>
	public unsafe int GetWeaponPropertyBonus(ERefiningEffectWeaponType effectType)
	{
		int bonus = 0;
		for (int i = 0; i < 5; i++)
		{
			short templateId = _materialTemplateIds[i];
			if (templateId >= 0)
			{
				MaterialItem materialCfg = Material.Instance[templateId];
				RefiningEffectItem refiningEffectCfg = RefiningEffect.Instance[materialCfg.RefiningEffect];
				if (refiningEffectCfg != null && refiningEffectCfg.WeaponType == effectType)
				{
					bonus += refiningEffectCfg.WeaponBonusValues[materialCfg.Grade];
				}
			}
		}
		return bonus;
	}

	/// <summary>
	/// 获取指定护具属性的总精制效果
	/// </summary>
	/// <param name="effectType"></param>
	/// <returns></returns>
	public unsafe int GetArmorPropertyBonus(ERefiningEffectArmorType effectType)
	{
		int bonus = 0;
		for (int i = 0; i < 5; i++)
		{
			short templateId = _materialTemplateIds[i];
			if (templateId >= 0)
			{
				MaterialItem materialCfg = Material.Instance[templateId];
				RefiningEffectItem refiningEffectCfg = RefiningEffect.Instance[materialCfg.RefiningEffect];
				if (refiningEffectCfg != null && refiningEffectCfg.ArmorType == effectType)
				{
					bonus += refiningEffectCfg.ArmorBonusValues[materialCfg.Grade];
				}
			}
		}
		return bonus;
	}

	/// <summary>
	/// 获取指定属性的总精制效果（宝物）
	/// </summary>
	/// <param name="effectType"></param>
	/// <returns></returns>
	public unsafe int GetAccessoryPropertyBonus(ERefiningEffectAccessoryType effectType)
	{
		int bonus = 0;
		for (int i = 0; i < 5; i++)
		{
			short templateId = _materialTemplateIds[i];
			if (templateId >= 0)
			{
				MaterialItem materialCfg = Material.Instance[templateId];
				RefiningEffectItem refiningEffectCfg = RefiningEffect.Instance[materialCfg.RefiningEffect];
				if (refiningEffectCfg != null && refiningEffectCfg.AccessoryType == effectType)
				{
					bonus += refiningEffectCfg.AccessoryBonusValues[materialCfg.Grade];
				}
			}
		}
		return bonus;
	}

	public static ERefiningEffectAccessoryType CharPropertyTypeToRefiningEffectAccessoryType(ECharacterPropertyReferencedType propertyType)
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

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 10;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = _materialTemplateIds)
		{
			*(long*)pData = *(long*)pItems;
			((short*)pData)[4] = pItems[4];
		}
		return 10;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* materialTemplateIds = _materialTemplateIds)
		{
			*(long*)materialTemplateIds = *(long*)pData;
			materialTemplateIds[4] = ((short*)pData)[4];
		}
		return 10;
	}
}

using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Item;

public struct RefiningEffects : ISerializableGameData
{
	private unsafe fixed short _materialTemplateIds[5];

	public const int MaxRefineCount = 5;

	public bool IsRefined => GetTotalRefiningCount() > 0;

	public unsafe void Initialize()
	{
		fixed (short* materialTemplateIds = _materialTemplateIds)
		{
			*(long*)materialTemplateIds = -1L;
			materialTemplateIds[4] = -1;
		}
	}

	public short[] GetAllMaterialTemplateIds()
	{
		short[] ids = new short[5];
		for (int i = 0; i < 5; i++)
		{
			ids[i] = GetMaterialTemplateIdAt(i);
		}
		return ids;
	}

	public unsafe short GetMaterialTemplateIdAt(int index)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		return _materialTemplateIds[index];
	}

	public unsafe void RemoveAt(int index)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		_materialTemplateIds[index] = -1;
	}

	public unsafe void Set(int index, short materialTemplateId)
	{
		if (index < 0 || index >= 5)
		{
			throw new ArgumentOutOfRangeException("index", index, "refining slot index is out of range.");
		}
		_materialTemplateIds[index] = materialTemplateId;
	}

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

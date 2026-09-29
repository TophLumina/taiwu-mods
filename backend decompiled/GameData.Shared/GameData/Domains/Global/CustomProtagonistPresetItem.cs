using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Global;

[Serializable]
[SerializableGameData(IsExtensible = true)]
public class CustomProtagonistPresetItem : PresetItemBase<CustomProtagonistPresetItem>
{
	private static class FieldIds
	{
		public const ushort NeiliProportion = 0;

		public const ushort MainAttributes = 1;

		public const ushort LifeSkillQualificationGrowthType = 2;

		public const ushort CombatSkillQualificationGrowthType = 3;

		public const ushort LifeSkillQualifications = 4;

		public const ushort CombatSkillQualifications = 5;

		public const ushort SelectedFeatures = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "NeiliProportion", "MainAttributes", "LifeSkillQualificationGrowthType", "CombatSkillQualificationGrowthType", "LifeSkillQualifications", "CombatSkillQualifications", "SelectedFeatures" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public NeiliProportionOfFiveElements NeiliProportion;

	[SerializableGameDataField(FieldIndex = 1)]
	public MainAttributes MainAttributes;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte LifeSkillQualificationGrowthType;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte CombatSkillQualificationGrowthType;

	[SerializableGameDataField(FieldIndex = 4)]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField(FieldIndex = 5)]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField(FieldIndex = 6)]
	public List<short> SelectedFeatures;

	private GlobalConfig Global => GlobalConfig.Instance;

	private short AttributeTotal => Global.CustomProtagonistMainAttributeTotalPoint;

	private short LifeSkillTotal => Global.CustomProtagonistLifeSkillQualificationTotalPoint;

	private short CombatSkillTotal => Global.CustomProtagonistCombatSkillQualificationTotalPoint;

	private short AttributeMax => Global.CustomProtagonistMainAttributeMaxPoint;

	private short LifeSkillMax => Global.CustomProtagonistLifeSkillQualificationMaxPoint;

	private short CombatSkillMax => Global.CustomProtagonistCombatSkillQualificationMaxPoint;

	private short AttributeDefault => Global.CustomProtagonistMainAttributeDefaultPoint;

	private short LifeSkillDefault => Global.CustomProtagonistLifeSkillQualificationDefaultPoint;

	private short CombatSkillDefault => Global.CustomProtagonistCombatSkillQualificationDefaultPoint;

	public sbyte NeiliType
	{
		get
		{
			return GetNeiliTypeByProportion(NeiliProportion);
		}
		set
		{
			NeiliProportion = GenerateNeiliProportionByNeiliType(value);
		}
	}

	public int MainAttributeRemainPoints => AttributeTotal - MainAttributes.GetSum();

	public int LifeSkillQualificationRemainPoints => LifeSkillTotal - LifeSkillQualifications.GetSum();

	public int CombatSkillQualificationRemainPoints => CombatSkillTotal - CombatSkillQualifications.GetSum();

	public static NeiliProportionOfFiveElements GenerateNeiliProportionByNeiliType(sbyte innateFiveElementsType)
	{
		NeiliProportionOfFiveElements result = default(NeiliProportionOfFiveElements);
		if (innateFiveElementsType >= 0 && innateFiveElementsType <= 4)
		{
			for (int i = 0; i < 5; i++)
			{
				result[i] = (sbyte)((i == innateFiveElementsType) ? 40 : 15);
			}
		}
		else
		{
			for (int j = 0; j < 5; j++)
			{
				result[j] = 20;
			}
		}
		return result;
	}

	public static sbyte GetNeiliTypeByProportion(NeiliProportionOfFiveElements neiliProportion)
	{
		for (sbyte i = 0; i <= 5; i++)
		{
			if (GenerateNeiliProportionByNeiliType(i).Equals(neiliProportion))
			{
				return i;
			}
		}
		return -1;
	}

	public static implicit operator CustomProtagonistPresetItem(CharacterItem config)
	{
		return new CustomProtagonistPresetItem(config);
	}

	public CustomProtagonistPresetItem(CharacterItem config)
	{
		NeiliProportion = config.PresetNeiliProportionOfFiveElements;
		MainAttributes = config.BaseMainAttributes;
		LifeSkillQualificationGrowthType = config.LifeSkillQualificationGrowthType;
		CombatSkillQualificationGrowthType = config.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = config.BaseLifeSkillQualifications;
		CombatSkillQualifications = config.BaseCombatSkillQualifications;
		SelectedFeatures = ((config.FeatureIds == null) ? null : new List<short>(config.FeatureIds));
	}

	public bool CanAddMainAttribute(sbyte mainAttributeType)
	{
		return MainAttributes[mainAttributeType] < AttributeMax;
	}

	public bool CanAddLifeSkillQualification(sbyte lifeSkillType)
	{
		return LifeSkillQualifications[lifeSkillType] < LifeSkillMax;
	}

	public bool CanAddCombatSkillQualification(sbyte combatSkillType)
	{
		return CombatSkillQualifications[combatSkillType] < CombatSkillMax;
	}

	public void ResetMainAttributes()
	{
		for (int i = 0; i < 6; i++)
		{
			MainAttributes[i] = AttributeDefault;
		}
	}

	public void ResetQualifications()
	{
		LifeSkillQualificationGrowthType = 0;
		CombatSkillQualificationGrowthType = 0;
		for (int i = 0; i < 16; i++)
		{
			LifeSkillQualifications[i] = LifeSkillDefault;
		}
		for (int j = 0; j < 14; j++)
		{
			CombatSkillQualifications[j] = CombatSkillDefault;
		}
	}

	public unsafe void RandomMainAttributes(IRandomSource random)
	{
		ResetMainAttributes();
		int max = AttributeMax - AttributeDefault;
		fixed (short* values = MainAttributes.Items)
		{
			DistributeValues(random, values, 6, MainAttributeRemainPoints, max);
		}
	}

	public unsafe void RandomQualifications(IRandomSource random)
	{
		ResetQualifications();
		LifeSkillQualificationGrowthType = (sbyte)random.Next(3);
		CombatSkillQualificationGrowthType = (sbyte)random.Next(3);
		int lifeMax = LifeSkillMax - LifeSkillDefault;
		fixed (short* values = LifeSkillQualifications.Items)
		{
			DistributeValues(random, values, 16, LifeSkillQualificationRemainPoints, lifeMax);
		}
		int combatMax = CombatSkillMax - CombatSkillDefault;
		fixed (short* values2 = CombatSkillQualifications.Items)
		{
			DistributeValues(random, values2, 14, CombatSkillQualificationRemainPoints, combatMax);
		}
	}

	private unsafe void DistributeValues(IRandomSource random, short* values, int k, int n, int m)
	{
		Span<int> buckets = stackalloc int[k];
		RandomUtils.DistributeNIntoKBuckets(random, buckets, k, n, m);
		for (int i = 0; i < k; i++)
		{
			values[i] = (short)(values[i] + buckets[i]);
		}
	}

	public void ChangeMainAttribute(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, MainAttributeRemainPoints);
		}
		MainAttributes[type] = (short)Math.Clamp(MainAttributes[type] + deltaValue, 0, AttributeMax);
	}

	public void ChangeLifeSkillQualification(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, LifeSkillQualificationRemainPoints);
		}
		LifeSkillQualifications[type] = (short)Math.Clamp(LifeSkillQualifications[type] + deltaValue, 0, LifeSkillMax);
	}

	public void ChangeCombatSkillQualification(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, CombatSkillQualificationRemainPoints);
		}
		CombatSkillQualifications[type] = (short)Math.Clamp(CombatSkillQualifications[type] + deltaValue, 0, CombatSkillMax);
	}

	public override void Clear()
	{
		NeiliProportion = GenerateNeiliProportionByNeiliType(5);
		MainAttributes.Initialize();
		LifeSkillQualificationGrowthType = 0;
		CombatSkillQualificationGrowthType = 0;
		LifeSkillQualifications.Initialize();
		CombatSkillQualifications.Initialize();
		SelectedFeatures?.Clear();
	}

	public override CustomProtagonistPresetItem Clone()
	{
		return new CustomProtagonistPresetItem
		{
			NeiliProportion = NeiliProportion,
			MainAttributes = MainAttributes,
			LifeSkillQualificationGrowthType = LifeSkillQualificationGrowthType,
			CombatSkillQualificationGrowthType = CombatSkillQualificationGrowthType,
			LifeSkillQualifications = LifeSkillQualifications,
			CombatSkillQualifications = CombatSkillQualifications,
			SelectedFeatures = ((SelectedFeatures != null) ? new List<short>(SelectedFeatures) : null)
		};
	}

	public CustomProtagonistPresetItem()
	{
	}

	public CustomProtagonistPresetItem(CustomProtagonistPresetItem other)
	{
		NeiliProportion = other.NeiliProportion;
		MainAttributes = other.MainAttributes;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = other.LifeSkillQualifications;
		CombatSkillQualifications = other.CombatSkillQualifications;
		SelectedFeatures = ((other.SelectedFeatures == null) ? null : new List<short>(other.SelectedFeatures));
	}

	public void Assign(CustomProtagonistPresetItem other)
	{
		NeiliProportion = other.NeiliProportion;
		MainAttributes = other.MainAttributes;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		LifeSkillQualifications = other.LifeSkillQualifications;
		CombatSkillQualifications = other.CombatSkillQualifications;
		SelectedFeatures = ((other.SelectedFeatures == null) ? null : new List<short>(other.SelectedFeatures));
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 84;
		totalSize = ((SelectedFeatures == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SelectedFeatures.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		pCurrData += NeiliProportion.Serialize(pCurrData);
		pCurrData += MainAttributes.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillQualificationGrowthType;
		pCurrData++;
		*pCurrData = (byte)CombatSkillQualificationGrowthType;
		pCurrData++;
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		if (SelectedFeatures != null)
		{
			int elementsCount = SelectedFeatures.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = SelectedFeatures[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += NeiliProportion.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			pCurrData += MainAttributes.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			LifeSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			CombatSkillQualificationGrowthType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		}
		if (num > 5)
		{
			pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		}
		if (num > 6)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SelectedFeatures == null)
				{
					SelectedFeatures = new List<short>(elementsCount);
				}
				else
				{
					SelectedFeatures.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					SelectedFeatures.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				SelectedFeatures?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

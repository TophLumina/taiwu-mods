using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Global;

/// <summary>
/// 自定义人物预设项
/// </summary>
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

	/// <summary>
	/// 内力五行属性
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public NeiliProportionOfFiveElements NeiliProportion;

	/// <summary>
	/// 主属性
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public MainAttributes MainAttributes;

	/// <summary>
	/// 技艺资质成长类型 <see cref="T:GameData.Domains.Character.SkillQualificationGrowthType" />
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte LifeSkillQualificationGrowthType;

	/// <summary>
	/// 功法资质成长类型 <see cref="T:GameData.Domains.Character.SkillQualificationGrowthType" />
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte CombatSkillQualificationGrowthType;

	/// <summary>
	/// 技艺资质
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public LifeSkillShorts LifeSkillQualifications;

	/// <summary>
	/// 功法资质
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public CombatSkillShorts CombatSkillQualifications;

	/// <summary>
	/// 选中的特性
	/// </summary>
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

	/// <summary>
	/// 内力属性
	/// </summary>
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

	/// <summary>
	/// 主属性剩余点数
	/// </summary>
	public int MainAttributeRemainPoints => AttributeTotal - MainAttributes.GetSum();

	/// <summary>
	/// 技艺资质剩余点数
	/// </summary>
	public int LifeSkillQualificationRemainPoints => LifeSkillTotal - LifeSkillQualifications.GetSum();

	/// <summary>
	/// 功法资质剩余点数
	/// </summary>
	public int CombatSkillQualificationRemainPoints => CombatSkillTotal - CombatSkillQualifications.GetSum();

	/// <summary>
	/// 根据五行类型生成内力属性
	/// </summary>
	/// <param name="innateFiveElementsType">五行类型</param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定内力属性对应的标准内力类型，不为标准内力类型时返回 -1
	/// </summary>
	/// <param name="neiliProportion"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 从配置表数据隐式转换
	/// </summary>
	public static implicit operator CustomProtagonistPresetItem(CharacterItem config)
	{
		return new CustomProtagonistPresetItem(config);
	}

	/// <summary>
	/// 从配置表构造预设数据
	/// </summary>
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

	/// <summary>
	/// 能否增加主属性
	/// </summary>
	public bool CanAddMainAttribute(sbyte mainAttributeType)
	{
		return MainAttributes[mainAttributeType] < AttributeMax;
	}

	/// <summary>
	/// 能否增加技艺资质
	/// </summary>
	public bool CanAddLifeSkillQualification(sbyte lifeSkillType)
	{
		return LifeSkillQualifications[lifeSkillType] < LifeSkillMax;
	}

	/// <summary>
	/// 能否增加功法资质
	/// </summary>
	public bool CanAddCombatSkillQualification(sbyte combatSkillType)
	{
		return CombatSkillQualifications[combatSkillType] < CombatSkillMax;
	}

	/// <summary>
	/// 重置主属性加点
	/// </summary>
	public void ResetMainAttributes()
	{
		for (int i = 0; i < 6; i++)
		{
			MainAttributes[i] = AttributeDefault;
		}
	}

	/// <summary>
	/// 重置资质加点
	/// </summary>
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

	/// <summary>
	/// 随机主属性加点
	/// </summary>
	public unsafe void RandomMainAttributes(IRandomSource random)
	{
		ResetMainAttributes();
		int max = AttributeMax - AttributeDefault;
		fixed (short* values = MainAttributes.Items)
		{
			DistributeValues(random, values, 6, MainAttributeRemainPoints, max);
		}
	}

	/// <summary>
	/// 随机资质加点
	/// </summary>
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

	/// <summary>
	/// 改变主属性
	/// </summary>
	public void ChangeMainAttribute(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, MainAttributeRemainPoints);
		}
		MainAttributes[type] = (short)Math.Clamp(MainAttributes[type] + deltaValue, 0, AttributeMax);
	}

	/// <summary>
	/// 改变技艺资质
	/// </summary>
	public void ChangeLifeSkillQualification(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, LifeSkillQualificationRemainPoints);
		}
		LifeSkillQualifications[type] = (short)Math.Clamp(LifeSkillQualifications[type] + deltaValue, 0, LifeSkillMax);
	}

	/// <summary>
	/// 改变功法资质
	/// </summary>
	public void ChangeCombatSkillQualification(sbyte type, int deltaValue)
	{
		if (deltaValue > 0)
		{
			deltaValue = Math.Min(deltaValue, CombatSkillQualificationRemainPoints);
		}
		CombatSkillQualifications[type] = (short)Math.Clamp(CombatSkillQualifications[type] + deltaValue, 0, CombatSkillMax);
	}

	/// <inheritdoc />
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

	/// <inheritdoc />
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CustomProtagonistPresetItem()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GearMateDreamBackData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MainAttributeProgress = 0;

		public const ushort ConsummateLevelProgress = 1;

		public const ushort FeatureProgress = 2;

		public const ushort LifeSkillReadingProgress = 3;

		public const ushort CombatSkillReadingProgress = 4;

		public const ushort SkillBreakBonusDictObsolete = 5;

		public const ushort CombatSkillAttainmentProgress = 6;

		public const ushort LifeSkillAttainmentProgress = 7;

		public const ushort NeiliType = 8;

		public const ushort MainAttributes = 9;

		public const ushort ConsummateLevel = 10;

		public const ushort FeatureIds = 11;

		public const ushort CombatSkills = 12;

		public const ushort BaseCombatSkillQualifications = 13;

		public const ushort LifeSkills = 14;

		public const ushort BaseLifeSkillQualifications = 15;

		public const ushort SkillBreakBonusDict = 16;

		public const ushort SkillBreakMaxPowerDict = 17;

		public const ushort Neili = 18;

		public const ushort NeiliAllocation = 19;

		public const ushort SectEmeiSkillBreakBonus = 20;

		public const ushort LuohanBreakDict = 21;

		public const ushort Count = 22;

		public static readonly string[] FieldId2FieldName = new string[22]
		{
			"MainAttributeProgress", "ConsummateLevelProgress", "FeatureProgress", "LifeSkillReadingProgress", "CombatSkillReadingProgress", "SkillBreakBonusDictObsolete", "CombatSkillAttainmentProgress", "LifeSkillAttainmentProgress", "NeiliType", "MainAttributes",
			"ConsummateLevel", "FeatureIds", "CombatSkills", "BaseCombatSkillQualifications", "LifeSkills", "BaseLifeSkillQualifications", "SkillBreakBonusDict", "SkillBreakMaxPowerDict", "Neili", "NeiliAllocation",
			"SectEmeiSkillBreakBonus", "LuohanBreakDict"
		};
	}

	[SerializableGameDataField(ArrayElementsCount = 6)]
	public int[] MainAttributeProgress;

	[SerializableGameDataField]
	public int ConsummateLevelProgress;

	[SerializableGameDataField]
	public int FeatureProgress;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> LifeSkillReadingProgress;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuCombatSkill> CombatSkillReadingProgress;

	[SerializableGameDataField]
	public Dictionary<short, SkillBreakPlateBonusList> SkillBreakBonusDict;

	[SerializableGameDataField]
	public Dictionary<short, int> SkillBreakMaxPowerDict;

	[SerializableGameDataField]
	public Dictionary<short, SkillBreakBonusCollection> SkillBreakBonusDictObsolete;

	[SerializableGameDataField]
	public Dictionary<short, SkillBreakBonusCollection> SectEmeiSkillBreakBonus;

	[SerializableGameDataField]
	public Dictionary<short, sbyte> LuohanBreakDict;

	[SerializableGameDataField(ArrayElementsCount = 14)]
	public int[] CombatSkillAttainmentProgress;

	[SerializableGameDataField(ArrayElementsCount = 16)]
	public int[] LifeSkillAttainmentProgress;

	[SerializableGameDataField]
	public int NeiliType;

	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> CombatSkills;

	[SerializableGameDataField]
	public CombatSkillShorts BaseCombatSkillQualifications;

	[SerializableGameDataField]
	public List<LifeSkillItem> LifeSkills;

	[SerializableGameDataField]
	public LifeSkillShorts BaseLifeSkillQualifications;

	[SerializableGameDataField]
	public int Neili;

	[SerializableGameDataField]
	public NeiliAllocation NeiliAllocation;

	public GearMateDreamBackData()
	{
		MainAttributeProgress = new int[6];
		LifeSkillReadingProgress = new Dictionary<short, TaiwuLifeSkill>();
		CombatSkillReadingProgress = new Dictionary<short, TaiwuCombatSkill>();
		SkillBreakBonusDictObsolete = new Dictionary<short, SkillBreakBonusCollection>();
		SectEmeiSkillBreakBonus = new Dictionary<short, SkillBreakBonusCollection>();
		CombatSkillAttainmentProgress = new int[14];
		LifeSkillAttainmentProgress = new int[16];
		FeatureIds = new List<short>();
		CombatSkills = new Dictionary<short, GameData.Domains.CombatSkill.CombatSkill>();
		LifeSkills = new List<LifeSkillItem>();
		Neili = 0;
		NeiliAllocation = default(NeiliAllocation);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 243;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(LifeSkillReadingProgress);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillReadingProgress);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakBonusDictObsolete);
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkills);
		totalSize = ((LifeSkills == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LifeSkills.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakBonusDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(SkillBreakMaxPowerDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectEmeiSkillBreakBonus);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(LuohanBreakDict);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 22;
		pCurrData += 2;
		Tester.Assert(MainAttributeProgress.Length == 6);
		for (int i = 0; i < 6; i++)
		{
			((int*)pCurrData)[i] = MainAttributeProgress[i];
		}
		pCurrData += 24;
		*(int*)pCurrData = ConsummateLevelProgress;
		pCurrData += 4;
		*(int*)pCurrData = FeatureProgress;
		pCurrData += 4;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref LifeSkillReadingProgress);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkillReadingProgress);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SkillBreakBonusDictObsolete);
		Tester.Assert(CombatSkillAttainmentProgress.Length == 14);
		for (int j = 0; j < 14; j++)
		{
			((int*)pCurrData)[j] = CombatSkillAttainmentProgress[j];
		}
		pCurrData += 56;
		Tester.Assert(LifeSkillAttainmentProgress.Length == 16);
		for (int k = 0; k < 16; k++)
		{
			((int*)pCurrData)[k] = LifeSkillAttainmentProgress[k];
		}
		pCurrData += 64;
		*(int*)pCurrData = NeiliType;
		pCurrData += 4;
		pCurrData += MainAttributes.Serialize(pCurrData);
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		if (FeatureIds != null)
		{
			int elementsCount = FeatureIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int l = 0; l < elementsCount; l++)
			{
				((short*)pCurrData)[l] = FeatureIds[l];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkills);
		pCurrData += BaseCombatSkillQualifications.Serialize(pCurrData);
		if (LifeSkills != null)
		{
			int elementsCount2 = LifeSkills.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int m = 0; m < elementsCount2; m++)
			{
				pCurrData += LifeSkills[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BaseLifeSkillQualifications.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SkillBreakBonusDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref SkillBreakMaxPowerDict);
		*(int*)pCurrData = Neili;
		pCurrData += 4;
		pCurrData += NeiliAllocation.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectEmeiSkillBreakBonus);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref LuohanBreakDict);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			if (MainAttributeProgress == null || MainAttributeProgress.Length != 6)
			{
				MainAttributeProgress = new int[6];
			}
			for (int i = 0; i < 6; i++)
			{
				MainAttributeProgress[i] = ((int*)pCurrData)[i];
			}
			pCurrData += 24;
		}
		if (fieldCount > 1)
		{
			ConsummateLevelProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			FeatureProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref LifeSkillReadingProgress);
		}
		if (fieldCount > 4)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillReadingProgress);
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakBonusDictObsolete);
		}
		if (fieldCount > 6)
		{
			if (CombatSkillAttainmentProgress == null || CombatSkillAttainmentProgress.Length != 14)
			{
				CombatSkillAttainmentProgress = new int[14];
			}
			for (int j = 0; j < 14; j++)
			{
				CombatSkillAttainmentProgress[j] = ((int*)pCurrData)[j];
			}
			pCurrData += 56;
		}
		if (fieldCount > 7)
		{
			if (LifeSkillAttainmentProgress == null || LifeSkillAttainmentProgress.Length != 16)
			{
				LifeSkillAttainmentProgress = new int[16];
			}
			for (int k = 0; k < 16; k++)
			{
				LifeSkillAttainmentProgress[k] = ((int*)pCurrData)[k];
			}
			pCurrData += 64;
		}
		if (fieldCount > 8)
		{
			NeiliType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 9)
		{
			pCurrData += MainAttributes.Deserialize(pCurrData);
		}
		if (fieldCount > 10)
		{
			ConsummateLevel = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 11)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (FeatureIds == null)
				{
					FeatureIds = new List<short>(elementsCount);
				}
				else
				{
					FeatureIds.Clear();
				}
				for (int l = 0; l < elementsCount; l++)
				{
					FeatureIds.Add(((short*)pCurrData)[l]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				FeatureIds?.Clear();
			}
		}
		if (fieldCount > 12)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkills);
		}
		if (fieldCount > 13)
		{
			pCurrData += BaseCombatSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 14)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (LifeSkills == null)
				{
					LifeSkills = new List<LifeSkillItem>(elementsCount2);
				}
				else
				{
					LifeSkills.Clear();
				}
				for (int m = 0; m < elementsCount2; m++)
				{
					LifeSkillItem element = default(LifeSkillItem);
					pCurrData += element.Deserialize(pCurrData);
					LifeSkills.Add(element);
				}
			}
			else
			{
				LifeSkills?.Clear();
			}
		}
		if (fieldCount > 15)
		{
			pCurrData += BaseLifeSkillQualifications.Deserialize(pCurrData);
		}
		if (fieldCount > 16)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakBonusDict);
		}
		if (fieldCount > 17)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref SkillBreakMaxPowerDict);
		}
		if (fieldCount > 18)
		{
			Neili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 19)
		{
			pCurrData += NeiliAllocation.Deserialize(pCurrData);
		}
		if (fieldCount > 20)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectEmeiSkillBreakBonus);
		}
		if (fieldCount > 21)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref LuohanBreakDict);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

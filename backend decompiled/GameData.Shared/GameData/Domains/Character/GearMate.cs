using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class GearMate : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort MainAttributeProgress = 1;

		public const ushort ConsummateLevelProgress = 2;

		public const ushort FeatureProgress = 3;

		public const ushort Neili = 4;

		public const ushort LifeSkillReadingProgress = 5;

		public const ushort CombatSkillReadingProgress = 6;

		public const ushort SkillBreakBonusDictObsolete = 7;

		public const ushort CombatSkillAttainmentProgress = 8;

		public const ushort LifeSkillAttainmentProgress = 9;

		public const ushort NeiliType = 10;

		public const ushort SkillBreakBonusDict = 11;

		public const ushort SkillBreakMaxPowerDict = 12;

		public const ushort NeiliAllocation = 13;

		public const ushort SectEmeiSkillBreakBonus = 14;

		public const ushort LuohanBreakDict = 15;

		public const ushort Count = 16;

		public static readonly string[] FieldId2FieldName = new string[16]
		{
			"Id", "MainAttributeProgress", "ConsummateLevelProgress", "FeatureProgress", "Neili", "LifeSkillReadingProgress", "CombatSkillReadingProgress", "SkillBreakBonusDictObsolete", "CombatSkillAttainmentProgress", "LifeSkillAttainmentProgress",
			"NeiliType", "SkillBreakBonusDict", "SkillBreakMaxPowerDict", "NeiliAllocation", "SectEmeiSkillBreakBonus", "LuohanBreakDict"
		};
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField(ArrayElementsCount = 6)]
	public int[] MainAttributeProgress;

	[SerializableGameDataField]
	public int ConsummateLevelProgress;

	[SerializableGameDataField]
	public int FeatureProgress;

	[SerializableGameDataField]
	public int Neili;

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
	public NeiliAllocation NeiliAllocation;

	public GearMate()
	{
		MainAttributeProgress = new int[6];
		LifeSkillReadingProgress = new Dictionary<short, TaiwuLifeSkill>();
		CombatSkillReadingProgress = new Dictionary<short, TaiwuCombatSkill>();
		SkillBreakBonusDict = new Dictionary<short, SkillBreakPlateBonusList>();
		SkillBreakBonusDictObsolete = new Dictionary<short, SkillBreakBonusCollection>();
		SectEmeiSkillBreakBonus = new Dictionary<short, SkillBreakBonusCollection>();
		LuohanBreakDict = new Dictionary<short, sbyte>();
		CombatSkillAttainmentProgress = new int[14];
		LifeSkillAttainmentProgress = new int[16];
		NeiliType = 5;
		SkillBreakMaxPowerDict = new Dictionary<short, int>();
		NeiliAllocation = default(NeiliAllocation);
	}

	public GearMate(int charId)
	{
		Id = charId;
		MainAttributeProgress = new int[6];
		LifeSkillReadingProgress = new Dictionary<short, TaiwuLifeSkill>();
		CombatSkillReadingProgress = new Dictionary<short, TaiwuCombatSkill>();
		SkillBreakBonusDict = new Dictionary<short, SkillBreakPlateBonusList>();
		SkillBreakBonusDictObsolete = new Dictionary<short, SkillBreakBonusCollection>();
		SectEmeiSkillBreakBonus = new Dictionary<short, SkillBreakBonusCollection>();
		LuohanBreakDict = new Dictionary<short, sbyte>();
		CombatSkillAttainmentProgress = new int[14];
		LifeSkillAttainmentProgress = new int[16];
		NeiliType = 5;
		SkillBreakMaxPowerDict = new Dictionary<short, int>();
		NeiliAllocation = default(NeiliAllocation);
	}

	public bool IsCombatSkillBuffed(sbyte combatSkillType, sbyte grade)
	{
		return (CombatSkillAttainmentProgress[combatSkillType] & (1 << (int)grade)) != 0;
	}

	public bool IsLifeSkillBuffed(sbyte lifeSkillType, sbyte grade)
	{
		return (LifeSkillAttainmentProgress[lifeSkillType] & (1 << (int)grade)) != 0;
	}

	public void SetCombatSkillBuffed(sbyte combatSkillType, sbyte grade)
	{
		CombatSkillAttainmentProgress[combatSkillType] |= 1 << (int)grade;
	}

	public void SetLifeSkillBuffed(sbyte lifeSkillType, sbyte grade)
	{
		LifeSkillAttainmentProgress[lifeSkillType] |= 1 << (int)grade;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 174;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(LifeSkillReadingProgress);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkillReadingProgress);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakBonusDictObsolete);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SkillBreakBonusDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(SkillBreakMaxPowerDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(SectEmeiSkillBreakBonus);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(LuohanBreakDict);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 16;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
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
		*(int*)pCurrData = Neili;
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SkillBreakBonusDict);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref SkillBreakMaxPowerDict);
		pCurrData += NeiliAllocation.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref SectEmeiSkillBreakBonus);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref LuohanBreakDict);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
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
		if (fieldCount > 2)
		{
			ConsummateLevelProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			FeatureProgress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			Neili = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref LifeSkillReadingProgress);
		}
		if (fieldCount > 6)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkillReadingProgress);
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakBonusDictObsolete);
		}
		if (fieldCount > 8)
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
		if (fieldCount > 9)
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
		if (fieldCount > 10)
		{
			NeiliType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 11)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SkillBreakBonusDict);
		}
		if (fieldCount > 12)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref SkillBreakMaxPowerDict);
		}
		if (fieldCount > 13)
		{
			pCurrData += NeiliAllocation.Deserialize(pCurrData);
		}
		if (fieldCount > 14)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref SectEmeiSkillBreakBonus);
		}
		if (fieldCount > 15)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref LuohanBreakDict);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

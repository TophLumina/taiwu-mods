using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

[SerializableGameData(IsExtensible = true)]
public class CricketRoomData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MaterialCounts = 0;

		public const ushort EnabledPolymorphReturn = 1;

		public const ushort EnabledMakingWish = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "MaterialCounts", "EnabledPolymorphReturn", "EnabledMakingWish" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<short, int> MaterialCounts;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool EnabledPolymorphReturn;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool EnabledMakingWish;

	public int Exp => CalcClampedExp();

	public int Level => CalcLevel();

	private GlobalConfig Global => GlobalConfig.Instance;

	public int ReduceAgeEffect => 10 * (Level - 1);

	public int AddSpiritEffect => 2 * Level;

	public int PolymorphRateEffect => GlobalConfig.Instance.CricketPolymorphBaseRate + 2 * Level;

	public int RecoverDurabilityEffect => 30 * Level;

	public void UpdateEnabledStatus()
	{
		int level = Level;
		EnabledPolymorphReturn = EnabledPolymorphReturn || level >= Global.CricketRoomPolymorphReturnRequireLevel;
		EnabledMakingWish = EnabledMakingWish || level >= Global.CricketRoomMakingWishRequireLevel;
	}

	private int CalcClampedExp()
	{
		return CalcExpFromMaterialCounts(MaterialCounts);
	}

	public static int CalcExpFromMaterialCounts(Dictionary<short, int> materialCounts)
	{
		if (materialCounts == null || materialCounts.Count <= 0)
		{
			return 0;
		}
		int exp = 0;
		foreach (KeyValuePair<short, int> materialCount in materialCounts)
		{
			materialCount.Deconstruct(out var key, out var value);
			short templateId = key;
			int count = value;
			MiscItem template = Misc.Instance[templateId];
			if (template != null && template.ResourceMaterialType != EMiscResourceMaterialType.Invalid)
			{
				int baseValue = ((template.ResourceMaterialType == EMiscResourceMaterialType.Low) ? GlobalConfig.Instance.CricketRoomExpPerLowMaterialBaseValue : GlobalConfig.Instance.CricketRoomExpPerHighMaterialBaseValue);
				int decreasingValue = ((template.ResourceMaterialType == EMiscResourceMaterialType.Low) ? GlobalConfig.Instance.CricketRoomExpPerLowMaterialDecreasingValue : GlobalConfig.Instance.CricketRoomExpPerHighMaterialDecreasingValue);
				int minValue = ((template.ResourceMaterialType == EMiscResourceMaterialType.Low) ? GlobalConfig.Instance.CricketRoomExpPerLowMaterialMinValue : GlobalConfig.Instance.CricketRoomExpPerHighMaterialMinValue);
				for (int i = 0; i < count; i++)
				{
					exp += Math.Max(baseValue - decreasingValue * i, minValue);
				}
			}
		}
		int maxLevelDelta = GlobalConfig.Instance.CricketRoomMaxLevel - GlobalConfig.Instance.CricketRoomBaseLevel;
		return Math.Min(exp, maxLevelDelta * GlobalConfig.Instance.CricketRoomRequireExpPerLevel);
	}

	private int CalcLevel()
	{
		return GlobalConfig.Instance.CricketRoomBaseLevel + Exp / GlobalConfig.Instance.CricketRoomRequireExpPerLevel;
	}

	public CricketRoomData()
	{
	}

	public CricketRoomData(CricketRoomData other)
	{
		MaterialCounts = ((other.MaterialCounts == null) ? null : new Dictionary<short, int>(other.MaterialCounts));
		EnabledPolymorphReturn = other.EnabledPolymorphReturn;
		EnabledMakingWish = other.EnabledMakingWish;
	}

	public void Assign(CricketRoomData other)
	{
		MaterialCounts = ((other.MaterialCounts == null) ? null : new Dictionary<short, int>(other.MaterialCounts));
		EnabledPolymorphReturn = other.EnabledPolymorphReturn;
		EnabledMakingWish = other.EnabledMakingWish;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(MaterialCounts);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		byte* num2 = num + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num, ref MaterialCounts);
		*num2 = (EnabledPolymorphReturn ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (EnabledMakingWish ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref MaterialCounts);
		}
		if (num > 1)
		{
			EnabledPolymorphReturn = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			EnabledMakingWish = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

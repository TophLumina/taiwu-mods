using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

/// <summary>
/// 蛰室数据
/// </summary>
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

	/// <summary>
	/// 各资源心材数量
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<short, int> MaterialCounts;

	/// <summary>
	/// 返灵玉功能已解锁
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public bool EnabledPolymorphReturn;

	/// <summary>
	/// 促织许愿功能已解锁
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public bool EnabledMakingWish;

	/// <summary>
	/// 经验值
	/// </summary>
	public int Exp => CalcClampedExp();

	/// <summary>
	/// 等级
	/// </summary>
	public int Level => CalcLevel();

	/// <summary>
	/// 全局配置语法糖
	/// </summary>
	private GlobalConfig Global => GlobalConfig.Instance;

	/// <summary>
	/// 延缓衰老效果值
	/// </summary>
	public int ReduceAgeEffect => 10 * (Level - 1);

	/// <summary>
	/// 增长灵性效果值
	/// </summary>
	public int AddSpiritEffect => 2 * Level;

	/// <summary>
	/// 化人概率效果值
	/// </summary>
	public int PolymorphRateEffect => GlobalConfig.Instance.CricketPolymorphBaseRate + 2 * Level;

	/// <summary>
	/// 恢复耐久效果值
	/// </summary>
	public int RecoverDurabilityEffect => 30 * Level;

	/// <summary>
	/// 检查功能开启状态
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketRoomData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketRoomData(CricketRoomData other)
	{
		MaterialCounts = ((other.MaterialCounts == null) ? null : new Dictionary<short, int>(other.MaterialCounts));
		EnabledPolymorphReturn = other.EnabledPolymorphReturn;
		EnabledMakingWish = other.EnabledMakingWish;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketRoomData other)
	{
		MaterialCounts = ((other.MaterialCounts == null) ? null : new Dictionary<short, int>(other.MaterialCounts));
		EnabledPolymorphReturn = other.EnabledPolymorphReturn;
		EnabledMakingWish = other.EnabledMakingWish;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

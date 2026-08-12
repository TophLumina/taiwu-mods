using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 用于演出的摧破功法伤害数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SkillDamageData : ISerializableGameData
{
	/// <summary>
	/// 总计摧破伤害数据
	/// </summary>
	[SerializableGameDataField]
	public SkillDamageSectionData Total;

	/// <summary>
	/// 分段摧破伤害数据
	/// K: 摧破段数
	/// V: 伤害数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, SkillDamageSectionData> Sections;

	/// <summary>
	/// 目标部位数据
	/// </summary>
	[SerializableGameDataField]
	public sbyte TargetBodyPart = -1;

	/// <summary>
	/// 装备快照数据
	/// </summary>
	[SerializableGameDataField]
	public SkillEquipmentSnapshot EquipmentSnapshot;

	/// <summary>
	/// 后端使用的追踪索引
	/// </summary>
	public int BackendTrackingIndex;

	/// <summary>
	/// 清空伤害值
	/// </summary>
	public void Clear()
	{
		TargetBodyPart = -1;
		EquipmentSnapshot.Clear();
		Total?.Values.Clear();
		if (Sections == null)
		{
			return;
		}
		foreach (SkillDamageSectionData value in Sections.Values)
		{
			value.Values.Clear();
			value.Result = ESkillDamageSectionResult.Uncheck;
		}
	}

	/// <summary>
	/// 累加伤害值
	/// </summary>
	public bool Accumulate(DefeatMarkKey key, int value)
	{
		if (BackendTrackingIndex < 0 || value <= 0)
		{
			return false;
		}
		if (Total == null)
		{
			Total = new SkillDamageSectionData();
		}
		Total.Values.Accumulate(key, value);
		if (Sections == null)
		{
			Sections = new Dictionary<int, SkillDamageSectionData>();
		}
		Sections.GetOrNew(BackendTrackingIndex).Values.Accumulate(key, value);
		return true;
	}

	/// <summary>
	/// 标记当前分段伤害为已命中
	/// </summary>
	/// <returns></returns>
	public bool MarkSectionResult(ESkillDamageSectionResult result)
	{
		if (BackendTrackingIndex < 0)
		{
			return false;
		}
		if (Sections == null)
		{
			Sections = new Dictionary<int, SkillDamageSectionData>();
		}
		Sections.GetOrNew(BackendTrackingIndex).Result = result;
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SkillDamageData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SkillDamageData(SkillDamageData other)
	{
		Total = new SkillDamageSectionData(other.Total);
		if (other.Sections != null)
		{
			Dictionary<int, SkillDamageSectionData> sections = other.Sections;
			int elementsCount = sections.Count;
			Sections = new Dictionary<int, SkillDamageSectionData>(elementsCount);
			foreach (KeyValuePair<int, SkillDamageSectionData> pair in sections)
			{
				Sections.Add(pair.Key, new SkillDamageSectionData(pair.Value));
			}
		}
		else
		{
			Sections = null;
		}
		TargetBodyPart = other.TargetBodyPart;
		EquipmentSnapshot = other.EquipmentSnapshot;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SkillDamageData other)
	{
		Total = new SkillDamageSectionData(other.Total);
		if (other.Sections != null)
		{
			Dictionary<int, SkillDamageSectionData> sections = other.Sections;
			int elementsCount = sections.Count;
			Sections = new Dictionary<int, SkillDamageSectionData>(elementsCount);
			foreach (KeyValuePair<int, SkillDamageSectionData> pair in sections)
			{
				Sections.Add(pair.Key, new SkillDamageSectionData(pair.Value));
			}
		}
		else
		{
			Sections = null;
		}
		TargetBodyPart = other.TargetBodyPart;
		EquipmentSnapshot = other.EquipmentSnapshot;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 13;
		totalSize = ((Total == null) ? (totalSize + 2) : (totalSize + (2 + Total.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Sections);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Total != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Total.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Sections);
		*pCurrData = (byte)TargetBodyPart;
		pCurrData++;
		pCurrData += EquipmentSnapshot.Serialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
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
			if (Total == null)
			{
				Total = new SkillDamageSectionData();
			}
			pCurrData += Total.Deserialize(pCurrData);
		}
		else
		{
			Total = null;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Sections);
		TargetBodyPart = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EquipmentSnapshot.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

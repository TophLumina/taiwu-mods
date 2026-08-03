using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 用于演出的摧破功法伤害分段数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class SkillDamageSectionData : ISerializableGameData
{
	/// <summary>
	/// 伤害
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<DefeatMarkKey, int> Values = new Dictionary<DefeatMarkKey, int>();

	/// <summary>
	/// 结果
	/// </summary>
	[SerializableGameDataField]
	public ESkillDamageSectionResult Result;

	/// <summary>
	/// 命中
	/// </summary>
	public bool Hit => Result == ESkillDamageSectionResult.Hit;

	/// <summary>
	/// 暴击
	/// </summary>
	public bool Critical => Result == ESkillDamageSectionResult.Critical;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SkillDamageSectionData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SkillDamageSectionData(SkillDamageSectionData other)
	{
		Values = ((other.Values == null) ? null : new Dictionary<DefeatMarkKey, int>(other.Values));
		Result = other.Result;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SkillDamageSectionData other)
	{
		Values = ((other.Values == null) ? null : new Dictionary<DefeatMarkKey, int>(other.Values));
		Result = other.Result;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<DefeatMarkKey, int, int, int, Dictionary<DefeatMarkKey, int>>(Values);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryAsBasicTypePair.Serialize(pData, ref Values, (Func<DefeatMarkKey, int>)((DefeatMarkKey key) => key), (Func<int, int>)((int value) => value));
		*num = (byte)Result;
		int totalSize = (int)(num + 1 - pData);
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
		pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref Values, (int key) => (DefeatMarkKey)key, (int value) => value);
		Result = (ESkillDamageSectionResult)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

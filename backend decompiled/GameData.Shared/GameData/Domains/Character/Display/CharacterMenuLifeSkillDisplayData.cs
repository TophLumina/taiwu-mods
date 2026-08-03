using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 角色菜单技艺页面数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterMenuLifeSkillDisplayData : ISerializableGameData
{
	/// <summary>
	/// 目标已学技艺列表
	/// </summary>
	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkills;

	/// <summary>
	/// 太吾已学技艺数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	/// <summary>
	/// 太吾未学技艺数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuNotLearnLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((LearnedLifeSkills == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LearnedLifeSkills.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuLifeSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuNotLearnLifeSkills);
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
		if (LearnedLifeSkills != null)
		{
			int elementsCount = LearnedLifeSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += LearnedLifeSkills[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuNotLearnLifeSkills);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedLifeSkills == null)
			{
				LearnedLifeSkills = new List<LifeSkillItem>(elementsCount);
			}
			else
			{
				LearnedLifeSkills.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				LifeSkillItem element = default(LifeSkillItem);
				pCurrData += element.Deserialize(pCurrData);
				LearnedLifeSkills.Add(element);
			}
		}
		else
		{
			LearnedLifeSkills?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuNotLearnLifeSkills);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

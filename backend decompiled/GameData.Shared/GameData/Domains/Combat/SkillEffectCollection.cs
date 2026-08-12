using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 功法持续效果集合
/// </summary>
public class SkillEffectCollection : ISerializableGameData
{
	/// <summary>
	/// 效果集合。(功法ID, 是否正练) -&gt; 当前层数
	/// </summary>
	public Dictionary<SkillEffectKey, short> EffectDict;

	/// <summary>
	/// 效果描述集合。(功法ID, 是否正练) -&gt; 描述数据
	/// </summary>
	public Dictionary<SkillEffectKey, CombatSkillEffectDescriptionDisplayData> EffectDescriptionDict;

	/// <summary>
	/// 层数上限集合。仅后端特效使用，非序列化数据
	/// </summary>
	public readonly Dictionary<SkillEffectKey, short> MaxEffectCountDict = new Dictionary<SkillEffectKey, short>();

	/// <summary>
	/// 是否在归零时自动删除。仅后端特效使用，非序列化数据
	/// </summary>
	public readonly Dictionary<SkillEffectKey, bool> AutoRemoveOnNoCountDict = new Dictionary<SkillEffectKey, bool>();

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 2;
		if (EffectDict != null)
		{
			totalSize += (default(SkillEffectKey).GetSerializedSize() + 2) * EffectDict.Count;
		}
		totalSize += 2;
		if (EffectDescriptionDict != null)
		{
			foreach (KeyValuePair<SkillEffectKey, CombatSkillEffectDescriptionDisplayData> effect in EffectDescriptionDict)
			{
				totalSize += effect.Key.GetSerializedSize() + effect.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (EffectDict != null)
		{
			int elementsCount = EffectDict.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (KeyValuePair<SkillEffectKey, short> effect in EffectDict)
			{
				pCurrData += effect.Key.Serialize(pCurrData);
				*(short*)pCurrData = effect.Value;
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EffectDescriptionDict != null)
		{
			int elementsCount2 = EffectDescriptionDict.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			foreach (KeyValuePair<SkillEffectKey, CombatSkillEffectDescriptionDisplayData> effect2 in EffectDescriptionDict)
			{
				pCurrData += effect2.Key.Serialize(pCurrData);
				pCurrData += effect2.Value.Serialize(pCurrData);
			}
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

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (EffectDict == null)
			{
				EffectDict = new Dictionary<SkillEffectKey, short>();
			}
			EffectDict.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				SkillEffectKey key = default(SkillEffectKey);
				pCurrData += key.Deserialize(pCurrData);
				short value = *(short*)pCurrData;
				pCurrData += 2;
				EffectDict.Add(key, value);
			}
		}
		else
		{
			EffectDict?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (EffectDescriptionDict == null)
			{
				EffectDescriptionDict = new Dictionary<SkillEffectKey, CombatSkillEffectDescriptionDisplayData>();
			}
			EffectDescriptionDict.Clear();
			for (int j = 0; j < elementsCount2; j++)
			{
				SkillEffectKey key2 = default(SkillEffectKey);
				CombatSkillEffectDescriptionDisplayData value2 = default(CombatSkillEffectDescriptionDisplayData);
				pCurrData += key2.Deserialize(pCurrData);
				pCurrData += value2.Deserialize(pCurrData);
				EffectDescriptionDict.Add(key2, value2);
			}
		}
		else
		{
			EffectDescriptionDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

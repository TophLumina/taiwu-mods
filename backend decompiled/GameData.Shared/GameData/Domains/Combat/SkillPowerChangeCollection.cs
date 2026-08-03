using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗中功法威力持续变化效果集合
/// </summary>
public class SkillPowerChangeCollection : ISerializableGameData
{
	/// <summary>
	/// 变化值集合。(效果来源功法, 是否正练) -&gt; 威力变化值
	/// </summary>
	public Dictionary<SkillEffectKey, int> EffectDict = new Dictionary<SkillEffectKey, int>();

	/// <summary>
	/// 增加威力变化
	/// </summary>
	public void Add(SkillEffectKey effectKey, int power)
	{
		if (!EffectDict.TryAdd(effectKey, power))
		{
			EffectDict[effectKey] += power;
		}
	}

	/// <summary>
	/// 获取总变化值
	/// </summary>
	public int GetTotalChangeValue()
	{
		int totalValue = 0;
		foreach (int value in EffectDict.Values)
		{
			totalValue += value;
		}
		return totalValue;
	}

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
			totalSize += (default(SkillEffectKey).GetSerializedSize() + 4) * EffectDict.Count;
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
			foreach (KeyValuePair<SkillEffectKey, int> effect in EffectDict)
			{
				pCurrData += effect.Key.Serialize(pCurrData);
				*(int*)pCurrData = effect.Value;
				pCurrData += 4;
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
				EffectDict = new Dictionary<SkillEffectKey, int>();
			}
			EffectDict.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				SkillEffectKey key = default(SkillEffectKey);
				pCurrData += key.Deserialize(pCurrData);
				int value = *(int*)pCurrData;
				pCurrData += 4;
				EffectDict.Add(key, value);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			EffectDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Combat;

public class CombatStateCollection : ISerializableGameData
{
	public readonly Dictionary<short, (short power, bool reverse, int srcCharId)> StateDict = new Dictionary<short, (short, bool, int)>();

	public readonly Dictionary<short, long> State2EffectId = new Dictionary<short, long>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 2 + 9 * StateDict.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = (short)StateDict.Count;
		pCurrData += 2;
		foreach (KeyValuePair<short, (short, bool, int)> entry in StateDict)
		{
			*(short*)pCurrData = entry.Key;
			pCurrData += 2;
			*(short*)pCurrData = entry.Value.Item1;
			pCurrData += 2;
			*pCurrData = (entry.Value.Item2 ? ((byte)1) : ((byte)0));
			pCurrData++;
			*(int*)pCurrData = entry.Value.Item3;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		short count = *(short*)pCurrData;
		pCurrData += 2;
		StateDict.Clear();
		for (int i = 0; i < count; i++)
		{
			short key = *(short*)pCurrData;
			pCurrData += 2;
			short power = *(short*)pCurrData;
			pCurrData += 2;
			bool reverse = *pCurrData != 0;
			pCurrData++;
			int srcCharId = *(int*)pCurrData;
			pCurrData += 4;
			StateDict.Add(key, (power, reverse, srcCharId));
		}
		return (int)(pCurrData - pData);
	}
}

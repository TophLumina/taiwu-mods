using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

[SerializableGameData(NotForDisplayModule = true)]
public class AiActionAdjusts : ISerializableGameData
{
	public readonly Dictionary<AiActionKey, (short RateAdjust, int ExpireDate)> Collection;

	public AiActionAdjusts()
	{
		Collection = new Dictionary<AiActionKey, (short, int)>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2 + Collection.Count * 8;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(ushort*)pCurrData = (ushort)Collection.Count;
		pCurrData += 2;
		foreach (KeyValuePair<AiActionKey, (short, int)> pair in Collection)
		{
			pCurrData += pair.Key.Serialize(pCurrData);
			*(short*)pCurrData = pair.Value.Item1;
			pCurrData += 2;
			*(int*)pCurrData = pair.Value.Item2;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementCount = *(ushort*)pCurrData;
		pCurrData += 2;
		Collection.Clear();
		for (int i = 0; i < elementCount; i++)
		{
			AiActionKey actionKey = default(AiActionKey);
			pCurrData += actionKey.Deserialize(pCurrData);
			short rateAdjust = *(short*)pCurrData;
			pCurrData += 2;
			int expireDate = *(int*)pCurrData;
			pCurrData += 4;
			Collection.Add(actionKey, (rateAdjust, expireDate));
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

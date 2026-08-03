using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

[SerializableGameData(NotForDisplayModule = true)]
public class AiExtraActionCooldowns : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<AiActionKey, int> OffCooldownDates;

	public AiExtraActionCooldowns()
	{
		OffCooldownDates = new Dictionary<AiActionKey, int>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2 + (OffCooldownDates?.Count ?? 0) * 6;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = (short)OffCooldownDates.Count;
		pCurrData += 2;
		foreach (KeyValuePair<AiActionKey, int> pair in OffCooldownDates)
		{
			pCurrData += pair.Key.Serialize(pCurrData);
			*(int*)pCurrData = pair.Value;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		OffCooldownDates.Clear();
		byte* pCurrData = pData;
		short count = *(short*)pCurrData;
		pCurrData += 2;
		for (int i = 0; i < count; i++)
		{
			AiActionKey key = default(AiActionKey);
			pCurrData += key.Deserialize(pCurrData);
			int value = *(int*)pCurrData;
			pCurrData += 4;
			OffCooldownDates.Add(key, value);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

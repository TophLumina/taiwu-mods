using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC;

public class LoveDataItem : ISerializableGameData
{
	[SerializableGameDataField]
	public int TaiwuCharId;

	[SerializableGameDataField]
	public int LoverCharId;

	[SerializableGameDataField]
	public List<bool> ReincarnationLoveList;

	[SerializableGameDataField]
	public ItemKey TaiwuOwnedToken;

	[SerializableGameDataField]
	public ItemKey LoverOwnedToken;

	[SerializableGameDataField]
	public int DateCount;

	[SerializableGameDataField]
	public bool IsBindSamsara;

	[SerializableGameDataField]
	public int TaiwuNicknameId;

	[SerializableGameDataField]
	public int InteractTime;

	[SerializableGameDataField]
	public int BecomeLoverTime;

	[SerializableGameDataField]
	public Dictionary<sbyte, int> EventTimeDict;

	public bool CheckReincarnationLoveContinueThreeTimes()
	{
		if (ReincarnationLoveList.Count < 3)
		{
			return false;
		}
		int count = 0;
		foreach (bool reincarnationLove in ReincarnationLoveList)
		{
			count = (reincarnationLove ? (count + 1) : 0);
		}
		return count >= 3;
	}

	public LoveDataItem()
	{
		ReincarnationLoveList = new List<bool>();
		TaiwuOwnedToken = ItemKey.Invalid;
		LoverOwnedToken = ItemKey.Invalid;
		EventTimeDict = new Dictionary<sbyte, int>();
	}

	public LoveDataItem(LoveDataItem other)
	{
		TaiwuCharId = other.TaiwuCharId;
		LoverCharId = other.LoverCharId;
		ReincarnationLoveList = new List<bool>(other.ReincarnationLoveList);
		TaiwuOwnedToken = other.TaiwuOwnedToken;
		LoverOwnedToken = other.LoverOwnedToken;
		DateCount = other.DateCount;
		IsBindSamsara = other.IsBindSamsara;
		TaiwuNicknameId = other.TaiwuNicknameId;
		InteractTime = other.InteractTime;
		BecomeLoverTime = other.BecomeLoverTime;
		EventTimeDict = other.EventTimeDict;
	}

	public void Assign(LoveDataItem other)
	{
		TaiwuCharId = other.TaiwuCharId;
		LoverCharId = other.LoverCharId;
		ReincarnationLoveList = new List<bool>(other.ReincarnationLoveList);
		TaiwuOwnedToken = other.TaiwuOwnedToken;
		LoverOwnedToken = other.LoverOwnedToken;
		DateCount = other.DateCount;
		IsBindSamsara = other.IsBindSamsara;
		TaiwuNicknameId = other.TaiwuNicknameId;
		InteractTime = other.InteractTime;
		BecomeLoverTime = other.BecomeLoverTime;
		EventTimeDict = other.EventTimeDict;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 41;
		totalSize = ((ReincarnationLoveList == null) ? (totalSize + 2) : (totalSize + (2 + ReincarnationLoveList.Count)));
		totalSize = ((EventTimeDict == null || EventTimeDict.Count <= 0) ? (totalSize + 2) : (totalSize + (2 + 3 * EventTimeDict.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = TaiwuCharId;
		pCurrData += 4;
		*(int*)pCurrData = LoverCharId;
		pCurrData += 4;
		if (ReincarnationLoveList != null)
		{
			int elementsCount = ReincarnationLoveList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (ReincarnationLoveList[i] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += TaiwuOwnedToken.Serialize(pCurrData);
		pCurrData += LoverOwnedToken.Serialize(pCurrData);
		*(int*)pCurrData = DateCount;
		pCurrData += 4;
		*pCurrData = (IsBindSamsara ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = TaiwuNicknameId;
		pCurrData += 4;
		*(int*)pCurrData = InteractTime;
		pCurrData += 4;
		*(int*)pCurrData = BecomeLoverTime;
		pCurrData += 4;
		if (EventTimeDict != null && EventTimeDict.Count > 0)
		{
			*(ushort*)pCurrData = (ushort)EventTimeDict.Count;
			pCurrData += 2;
			foreach (KeyValuePair<sbyte, int> entry in EventTimeDict)
			{
				*pCurrData = (byte)entry.Key;
				pCurrData++;
				*(int*)pCurrData = entry.Value;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TaiwuCharId = *(int*)pCurrData;
		pCurrData += 4;
		LoverCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ReincarnationLoveList == null)
			{
				ReincarnationLoveList = new List<bool>(elementsCount);
			}
			else
			{
				ReincarnationLoveList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ReincarnationLoveList.Add(pCurrData[i] != 0);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			ReincarnationLoveList?.Clear();
		}
		pCurrData += TaiwuOwnedToken.Deserialize(pCurrData);
		pCurrData += LoverOwnedToken.Deserialize(pCurrData);
		DateCount = *(int*)pCurrData;
		pCurrData += 4;
		IsBindSamsara = *pCurrData != 0;
		pCurrData++;
		TaiwuNicknameId = *(int*)pCurrData;
		pCurrData += 4;
		InteractTime = *(int*)pCurrData;
		pCurrData += 4;
		BecomeLoverTime = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (EventTimeDict != null)
			{
				EventTimeDict.Clear();
			}
			else
			{
				EventTimeDict = new Dictionary<sbyte, int>(elementsCount2);
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				sbyte key = (sbyte)(*pCurrData);
				pCurrData++;
				int element = *(int*)pCurrData;
				pCurrData += 4;
				EventTimeDict.Add(key, element);
			}
		}
		else
		{
			EventTimeDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC;

/// <summary>
/// 恋人相关的数据
/// </summary>
public class LoveDataItem : ISerializableGameData
{
	/// <summary>
	/// 太吾ID，不会改变
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuCharId;

	/// <summary>
	/// 恋人ID，转世时改变
	/// </summary>
	[SerializableGameDataField]
	public int LoverCharId;

	/// <summary>
	/// 从恋人与太吾第一次相恋算起，每一世的相恋状态的列表，
	/// </summary>
	[SerializableGameDataField]
	public List<bool> ReincarnationLoveList;

	/// <summary>
	/// 定情时太吾获得的物品，物品被移除定情的信息时要设置为非法值
	/// </summary>
	[SerializableGameDataField]
	public ItemKey TaiwuOwnedToken;

	/// <summary>
	/// 定情时NPC获得的物品，物品被移除定情的信息时要设置为非法值
	/// </summary>
	[SerializableGameDataField]
	public ItemKey LoverOwnedToken;

	/// <summary>
	/// 约会次数
	/// </summary>
	[SerializableGameDataField]
	public int DateCount;

	/// <summary>
	/// 是否绑定轮回
	/// </summary>
	[SerializableGameDataField]
	public bool IsBindSamsara;

	/// <summary>
	/// NPC对太吾的昵称的ID
	/// </summary>
	[SerializableGameDataField]
	public int TaiwuNicknameId;

	/// <summary>
	/// 互动时间
	/// </summary>
	[SerializableGameDataField]
	public int InteractTime;

	/// <summary>
	/// 定情时间
	/// </summary>
	[SerializableGameDataField]
	public int BecomeLoverTime;

	/// <summary>
	/// 事件与发生事件的字典 事件GUID -&gt; 发生时间
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, int> EventTimeDict;

	/// <summary>
	/// 检查是否连续三世相恋
	/// </summary>
	/// <returns></returns>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

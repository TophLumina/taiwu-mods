using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

public class ArchiveInfo : ISerializableGameData
{
	public sbyte Status;

	public WorldInfo WorldInfo;

	public List<(long timestamp, WorldInfo worldInfo)> BackupWorldsInfo;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize++;
		totalSize += 4;
		if (WorldInfo != null)
		{
			totalSize += WorldInfo.GetSerializedSize();
		}
		int backupCount = BackupWorldsInfo.Count;
		Tester.Assert(backupCount <= 255);
		totalSize++;
		for (int i = 0; i < backupCount; i++)
		{
			WorldInfo extensibleInfo = BackupWorldsInfo[i].worldInfo;
			totalSize += 8;
			if (extensibleInfo != null)
			{
				totalSize += 4;
				totalSize += extensibleInfo.GetSerializedSize();
			}
			else
			{
				totalSize += 4;
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)Status;
		pCurrData++;
		int worldInfoSize = WorldInfo?.GetSerializedSize() ?? 0;
		*(int*)pCurrData = worldInfoSize;
		pCurrData += 4;
		if (WorldInfo != null)
		{
			pCurrData += WorldInfo.Serialize(pCurrData);
		}
		int backupCount = BackupWorldsInfo.Count;
		Tester.Assert(backupCount <= 255);
		*pCurrData = (byte)backupCount;
		pCurrData++;
		for (int i = 0; i < backupCount; i++)
		{
			(long timestamp, WorldInfo worldInfo) tuple = BackupWorldsInfo[i];
			long timestamp = tuple.timestamp;
			WorldInfo extensibleInfo = tuple.worldInfo;
			*(long*)pCurrData = timestamp;
			pCurrData += 8;
			if (extensibleInfo != null)
			{
				int extensibleInfoSize = extensibleInfo.GetSerializedSize();
				*(int*)pCurrData = extensibleInfoSize;
				pCurrData += 4;
				pCurrData += extensibleInfo.Serialize(pCurrData);
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
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
		Status = (sbyte)(*pCurrData);
		pCurrData++;
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num > 0)
		{
			if (WorldInfo == null)
			{
				WorldInfo = new WorldInfo();
			}
			pCurrData += WorldInfo.Deserialize(pCurrData);
		}
		else
		{
			WorldInfo = null;
		}
		byte backupCount = *pCurrData;
		pCurrData++;
		if (BackupWorldsInfo == null)
		{
			BackupWorldsInfo = new List<(long, WorldInfo)>(backupCount);
		}
		else
		{
			BackupWorldsInfo.Clear();
		}
		for (int i = 0; i < backupCount; i++)
		{
			long timestamp = *(long*)pCurrData;
			pCurrData += 8;
			int num2 = *(int*)pCurrData;
			pCurrData += 4;
			if (num2 > 0)
			{
				WorldInfo worldInfo = new WorldInfo();
				pCurrData += worldInfo.Deserialize(pCurrData);
				BackupWorldsInfo.Add((timestamp, worldInfo));
			}
			else
			{
				BackupWorldsInfo.Add((timestamp, null));
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

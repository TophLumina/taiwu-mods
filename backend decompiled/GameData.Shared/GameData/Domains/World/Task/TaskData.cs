using Config;
using GameData.Serializer;

namespace GameData.Domains.World.Task;

public struct TaskData : ISerializableGameData
{
	[SerializableGameDataField]
	public int TaskInfoId;

	[SerializableGameDataField]
	public int TaskChainId;

	[SerializableGameDataField]
	public byte TaskStatus;

	public bool IsBlocked => TaskStatus == 1;

	public bool IsInProgress => TaskStatus == 0;

	public bool IsFinished => TaskStatus == 2;

	public bool IsParallel => TaskChain.Instance[TaskChainId].Type == ETaskChainType.Parallel;

	public override string ToString()
	{
		string empty = string.Empty;
		string taskChainName = TaskChain.Instance[TaskChainId]?.Name ?? ("UnknownChain(" + TaskChainId + ")");
		if (string.IsNullOrEmpty(taskChainName))
		{
			taskChainName = "Chain(" + TaskChainId + ")";
		}
		string taskInfoName = TaskInfo.Instance[TaskInfoId]?.TaskTitle ?? ("UnknownTask(" + TaskInfoId + ")");
		if (string.IsNullOrEmpty(taskInfoName))
		{
			taskInfoName = "Task(" + TaskInfoId + ")";
		}
		return empty + taskChainName + " " + taskInfoName;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = TaskInfoId;
		byte* num = pData + 4;
		*(int*)num = TaskChainId;
		byte* num2 = num + 4;
		*num2 = TaskStatus;
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TaskInfoId = *(int*)pCurrData;
		pCurrData += 4;
		TaskChainId = *(int*)pCurrData;
		pCurrData += 4;
		TaskStatus = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

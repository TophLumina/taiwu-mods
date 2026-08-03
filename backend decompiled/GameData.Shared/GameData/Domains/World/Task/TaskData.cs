using Config;
using GameData.Serializer;

namespace GameData.Domains.World.Task;

public struct TaskData : ISerializableGameData
{
	/// <summary>
	/// 任务模板ID <see cref="T:Config.TaskInfo" />
	/// </summary>
	[SerializableGameDataField]
	public int TaskInfoId;

	/// <summary>
	/// 任务链模板ID <see cref="T:Config.TaskChain" />
	/// </summary>
	[SerializableGameDataField]
	public int TaskChainId;

	/// <summary>
	/// 任务状态
	/// </summary>
	[SerializableGameDataField]
	public byte TaskStatus;

	/// <summary>
	/// 是否受阻
	/// </summary>
	public bool IsBlocked => TaskStatus == 1;

	/// <summary>
	/// 是否进行中
	/// </summary>
	public bool IsInProgress => TaskStatus == 0;

	/// <summary>
	/// 是否已完成
	/// </summary>
	public bool IsFinished => TaskStatus == 2;

	/// <summary>
	/// 是否并行
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

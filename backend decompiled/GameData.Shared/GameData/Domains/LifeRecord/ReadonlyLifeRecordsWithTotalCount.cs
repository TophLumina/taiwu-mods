using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord;

/// <summary>
/// 只读的人物的经历的集合 + 人物经历总条数
/// </summary>
public class ReadonlyLifeRecordsWithTotalCount : ISerializableGameData
{
	/// <summary>
	/// 人物经历总条数
	/// </summary>
	[SerializableGameDataField]
	public int TotalCount;

	/// <summary>
	/// 目前获取到的经历条数
	/// </summary>
	[SerializableGameDataField]
	public ReadonlyLifeRecords Records;

	/// <summary>
	/// 只读的人物的经历的集合 + 人物经历总条数
	/// </summary>
	public ReadonlyLifeRecordsWithTotalCount()
	{
		Records = new ReadonlyLifeRecords();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((Records == null) ? (totalSize + 2) : (totalSize + (2 + Records.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = TotalCount;
		pCurrData += 4;
		if (Records != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Records.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
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
		TotalCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (Records == null)
			{
				Records = new ReadonlyLifeRecords();
			}
			pCurrData += Records.Deserialize(pCurrData);
		}
		else
		{
			Records = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

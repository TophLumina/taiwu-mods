using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord;

public class ReadonlyLifeRecordsWithDate : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public int StartDate;

	[SerializableGameDataField]
	public int MonthCount;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public ReadonlyLifeRecords Records;

	public ReadonlyLifeRecordsWithDate()
	{
		Records = new ReadonlyLifeRecords();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((Records == null) ? (totalSize + 4) : (totalSize + (4 + Records.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = StartDate;
		pCurrData += 4;
		*(int*)pCurrData = MonthCount;
		pCurrData += 4;
		if (Records != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize = Records.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)intPtr = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		StartDate = *(int*)pCurrData;
		pCurrData += 4;
		MonthCount = *(int*)pCurrData;
		pCurrData += 4;
		int num = *(int*)pCurrData;
		pCurrData += 4;
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

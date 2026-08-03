using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.LifeRecord;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class TransferableLifeRecordMonthData
{
	[SerializableGameDataField(FieldIndex = 0)]
	public int Date;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Index;

	[SerializableGameDataField(FieldIndex = 2)]
	public int Score;

	[SerializableGameDataField(FieldIndex = 3)]
	public int DataCount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Date;
		byte* num = pData + 4;
		*(int*)num = Index;
		byte* num2 = num + 4;
		*(int*)num2 = Score;
		byte* num3 = num2 + 4;
		*(int*)num3 = DataCount;
		int totalSize = (int)(num3 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Date = *(int*)pCurrData;
		pCurrData += 4;
		Index = *(int*)pCurrData;
		pCurrData += 4;
		Score = *(int*)pCurrData;
		pCurrData += 4;
		DataCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

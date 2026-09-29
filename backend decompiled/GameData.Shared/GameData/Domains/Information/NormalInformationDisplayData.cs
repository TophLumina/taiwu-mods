using GameData.Serializer;

namespace GameData.Domains.Information;

[SerializableGameData(NotForArchive = true)]
public class NormalInformationDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public NormalInformation NormalInformation;

	[SerializableGameDataField]
	public int UsedCount;

	[SerializableGameDataField]
	public int MaxCount;

	public NormalInformationDisplayData()
	{
	}

	public NormalInformationDisplayData(NormalInformationDisplayData other)
	{
		NormalInformation = other.NormalInformation;
		UsedCount = other.UsedCount;
		MaxCount = other.MaxCount;
	}

	public void Assign(NormalInformationDisplayData other)
	{
		NormalInformation = other.NormalInformation;
		UsedCount = other.UsedCount;
		MaxCount = other.MaxCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += NormalInformation.Serialize(pCurrData);
		*(int*)pCurrData = UsedCount;
		pCurrData += 4;
		*(int*)pCurrData = MaxCount;
		pCurrData += 4;
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
		pCurrData += NormalInformation.Deserialize(pCurrData);
		UsedCount = *(int*)pCurrData;
		pCurrData += 4;
		MaxCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

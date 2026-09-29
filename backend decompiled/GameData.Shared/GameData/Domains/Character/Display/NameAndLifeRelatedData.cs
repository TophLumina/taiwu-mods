using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public struct NameAndLifeRelatedData : ISerializableGameData
{
	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField]
	public sbyte LifeState;

	[SerializableGameDataField]
	public bool HasTomb;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 34;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += NameRelatedData.Serialize(pCurrData);
		*pCurrData = (byte)LifeState;
		pCurrData++;
		*pCurrData = (HasTomb ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		LifeState = (sbyte)(*pCurrData);
		pCurrData++;
		HasTomb = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

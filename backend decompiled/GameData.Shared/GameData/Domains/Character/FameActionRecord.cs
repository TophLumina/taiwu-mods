using GameData.Serializer;

namespace GameData.Domains.Character;

public struct FameActionRecord(short id, short value, int endDate) : ISerializableGameData
{
	public short Id = id;

	public short Value = value;

	public int EndDate = endDate;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = Id;
		((short*)pData)[1] = Value;
		((int*)pData)[1] = EndDate;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		Id = *(short*)pData;
		Value = ((short*)pData)[1];
		EndDate = ((int*)pData)[1];
		return 8;
	}
}

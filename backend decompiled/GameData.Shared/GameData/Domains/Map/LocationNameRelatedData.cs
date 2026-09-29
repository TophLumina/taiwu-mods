using GameData.Serializer;

namespace GameData.Domains.Map;

public struct LocationNameRelatedData(short areaTemplateId) : ISerializableGameData
{
	public short AreaTemplateId = areaTemplateId;

	public short SettlementMapBlockTemplateId = -1;

	public short SettlementRandomNameId = -1;

	public sbyte Direction = -1;

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
		*(short*)pData = AreaTemplateId;
		((short*)pData)[1] = SettlementMapBlockTemplateId;
		((short*)pData)[2] = SettlementRandomNameId;
		pData[6] = (byte)Direction;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		AreaTemplateId = *(short*)pData;
		SettlementMapBlockTemplateId = ((short*)pData)[1];
		SettlementRandomNameId = ((short*)pData)[2];
		Direction = (sbyte)pData[6];
		return 8;
	}
}

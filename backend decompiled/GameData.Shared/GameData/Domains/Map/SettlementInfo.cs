using GameData.Serializer;

namespace GameData.Domains.Map;

public struct SettlementInfo(short settlementId, short blockId, sbyte orgTemplateId, short randomNameId) : ISerializableGameData
{
	public short SettlementId = settlementId;

	public short BlockId = blockId;

	public sbyte OrgTemplateId = orgTemplateId;

	public short RandomNameId = randomNameId;

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
		*(short*)pData = SettlementId;
		((short*)pData)[1] = BlockId;
		pData[4] = (byte)OrgTemplateId;
		((short*)pData)[3] = RandomNameId;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		SettlementId = *(short*)pData;
		BlockId = ((short*)pData)[1];
		OrgTemplateId = (sbyte)pData[4];
		RandomNameId = ((short*)pData)[3];
		return 8;
	}
}

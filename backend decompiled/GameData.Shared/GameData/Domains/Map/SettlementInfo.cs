using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 区域中的定居点信息
/// </summary>
public struct SettlementInfo(short settlementId, short blockId, sbyte orgTemplateId, short randomNameId) : ISerializableGameData
{
	/// <summary>
	/// 定居点 ID.
	/// 小于 0 表示无定居点.
	/// </summary>
	public short SettlementId = settlementId;

	/// <summary>
	/// 地块 ID.
	/// 小于 0 表示无定居点.
	/// </summary>
	public short BlockId = blockId;

	/// <summary>
	/// 定居点的团体模板 ID.
	/// 小于 0 表示无定居点.
	/// </summary>
	public sbyte OrgTemplateId = orgTemplateId;

	/// <summary>
	/// 地块随机名称 ID.
	/// 小于 0 表示无定居点, 或有定居点但名称不随机.
	/// </summary>
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

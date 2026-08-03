using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 地图位置名称相关数据
/// </summary>
public struct LocationNameRelatedData : ISerializableGameData
{
	/// <summary>
	/// 区域模板 ID
	/// </summary>
	public short AreaTemplateId;

	/// <summary>
	/// 所参照的定居点所在地块模板 ID.
	/// 定居点的固定名称从地块配置数据中获取.
	/// 小于 0 表示该区域无定居点.
	/// </summary>
	public short SettlementMapBlockTemplateId;

	/// <summary>
	/// 所参照的定居点随机名称 ID.
	/// 小于 0 表示表示该区域无定居点, 或所参照的定居点使用固定名称.
	/// </summary>
	public short SettlementRandomNameId;

	/// <summary>
	/// 该位置相对于参照物的方位.
	/// 若该区域存在定居点, 则为相对于定居点的方位. 否则为在区域内的方位.
	/// <see cref="T:GameData.Domains.Map.Direction" />
	/// </summary>
	public sbyte Direction;

	/// <summary>
	/// 地图位置名称相关数据
	/// </summary>
	/// <param name="areaTemplateId"></param>
	public LocationNameRelatedData(short areaTemplateId)
	{
		AreaTemplateId = areaTemplateId;
		SettlementMapBlockTemplateId = -1;
		SettlementRandomNameId = -1;
		Direction = -1;
	}

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

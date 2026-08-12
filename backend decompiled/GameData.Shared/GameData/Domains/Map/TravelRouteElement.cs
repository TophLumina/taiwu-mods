using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 长途旅行路线节点数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class TravelRouteElement : ISerializableGameData
{
	/// <summary>
	/// 旅行路线
	/// </summary>
	[SerializableGameDataField]
	public short AreaId;

	/// <summary>
	/// 时间消耗 
	/// </summary>
	[SerializableGameDataField]
	public short Cost;

	/// <summary>
	/// 此地驿站是否开启
	/// </summary>
	[SerializableGameDataField]
	public bool StationUnlocked;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TravelRouteElement()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelRouteElement(TravelRouteElement other)
	{
		AreaId = other.AreaId;
		Cost = other.Cost;
		StationUnlocked = other.StationUnlocked;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelRouteElement other)
	{
		AreaId = other.AreaId;
		Cost = other.Cost;
		StationUnlocked = other.StationUnlocked;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaId;
		byte* num = pData + 2;
		*(short*)num = Cost;
		byte* num2 = num + 2;
		*num2 = (StationUnlocked ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		Cost = *(short*)pCurrData;
		pCurrData += 2;
		StationUnlocked = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

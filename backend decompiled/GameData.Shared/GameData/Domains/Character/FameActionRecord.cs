using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 名誉相关行为记录
/// </summary>
public struct FameActionRecord : ISerializableGameData
{
	/// <summary>
	/// 名誉相关行为 ID (同一个 ID 在集合里只会出现一次)
	/// </summary>
	public short Id;

	/// <summary>
	/// 累计名誉值影响 (会因为重复触发相同行为而增加, 也会因为消减行为而减少)
	/// </summary>
	public short Value;

	/// <summary>
	/// 影响结束日期, 时间达到或超过此日期影响即结束 (从第一年一月开始经过的月份数)
	/// </summary>
	public int EndDate;

	/// <summary>
	/// 名誉相关行为记录
	/// </summary>
	/// <param name="id"></param>
	/// <param name="value"></param>
	/// <param name="endDate"></param>
	public FameActionRecord(short id, short value, int endDate)
	{
		Id = id;
		Value = value;
		EndDate = endDate;
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

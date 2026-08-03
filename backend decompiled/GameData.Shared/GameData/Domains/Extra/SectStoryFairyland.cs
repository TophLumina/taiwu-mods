using System;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 地区主线 - 武当 - 洞天数据
/// </summary>
public struct SectStoryFairyland : ISerializableGameData
{
	/// <summary>
	/// 洞天位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 已访问
	/// </summary>
	[SerializableGameDataField]
	public bool Visited;

	/// <summary>
	/// 已隐藏
	/// </summary>
	[SerializableGameDataField]
	public bool Destroyed;

	/// <summary>
	/// 洞天在MapArea配置表中的模板id
	/// </summary>
	[SerializableGameDataField]
	[Obsolete]
	public short MapAreaTemplateId;

	/// <summary>
	/// 洞天在MapArea配置表中CaveName字段的索引
	/// </summary>
	[SerializableGameDataField]
	[Obsolete]
	public sbyte MapAreaIndex;

	/// <summary>
	/// 构造函数
	/// </summary>
	public SectStoryFairyland()
	{
		Visited = false;
		Destroyed = true;
		Location = Location.Invalid;
		MapAreaTemplateId = -1;
		MapAreaIndex = -1;
	}

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="location"></param>
	public SectStoryFairyland(Location location)
	{
		Visited = false;
		Destroyed = false;
		Location = location;
		MapAreaTemplateId = -1;
		MapAreaIndex = -1;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (Visited ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Destroyed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = MapAreaTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)MapAreaIndex;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Location.Deserialize(pCurrData);
		Visited = *pCurrData != 0;
		pCurrData++;
		Destroyed = *pCurrData != 0;
		pCurrData++;
		MapAreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		MapAreaIndex = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

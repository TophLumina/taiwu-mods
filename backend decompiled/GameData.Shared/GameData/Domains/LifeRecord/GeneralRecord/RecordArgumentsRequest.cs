using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 通知类参数请求
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct RecordArgumentsRequest(ArgumentCollection argumentCollection) : ISerializableGameData
{
	/// <summary>
	/// 角色 ID
	/// </summary>
	[SerializableGameDataField]
	public List<int> Characters = argumentCollection.Characters;

	/// <summary>
	/// 地点 ID
	/// </summary>
	[SerializableGameDataField]
	public List<Location> Locations = argumentCollection.Locations;

	/// <summary>
	/// 定居点 ID
	/// </summary>
	[SerializableGameDataField]
	public List<short> Settlements = argumentCollection.Settlements;

	/// <summary>
	/// 蛟龙 ID
	/// </summary>
	[SerializableGameDataField]
	public List<int> JiaoLoongs = argumentCollection.JiaoLoongs;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Characters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Characters.Count)));
		totalSize = ((Locations == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Locations.Count)));
		totalSize = ((Settlements == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Settlements.Count)));
		totalSize = ((JiaoLoongs == null) ? (totalSize + 2) : (totalSize + (2 + 4 * JiaoLoongs.Count)));
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
		if (Characters != null)
		{
			int elementsCount = Characters.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = Characters[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Locations != null)
		{
			int elementsCount2 = Locations.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += Locations[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Settlements != null)
		{
			int elementsCount3 = Settlements.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = Settlements[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (JiaoLoongs != null)
		{
			int elementsCount4 = JiaoLoongs.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((int*)pCurrData)[l] = JiaoLoongs[l];
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Characters == null)
			{
				Characters = new List<int>(elementsCount);
			}
			else
			{
				Characters.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Characters.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			Characters?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Locations == null)
			{
				Locations = new List<Location>(elementsCount2);
			}
			else
			{
				Locations.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				Location element = default(Location);
				pCurrData += element.Deserialize(pCurrData);
				Locations.Add(element);
			}
		}
		else
		{
			Locations?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (Settlements == null)
			{
				Settlements = new List<short>(elementsCount3);
			}
			else
			{
				Settlements.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				Settlements.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			Settlements?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (JiaoLoongs == null)
			{
				JiaoLoongs = new List<int>(elementsCount4);
			}
			else
			{
				JiaoLoongs.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				JiaoLoongs.Add(((int*)pCurrData)[l]);
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			JiaoLoongs?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

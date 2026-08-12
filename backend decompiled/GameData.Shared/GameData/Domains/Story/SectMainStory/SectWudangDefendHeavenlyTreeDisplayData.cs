using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 自 SerializeDefault 迁移而来的匿名结构
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class SectWudangDefendHeavenlyTreeDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<Location> Locations;

	[SerializableGameDataField]
	public bool EventTriggered;

	public static implicit operator SectWudangDefendHeavenlyTreeDisplayData((List<Location>, bool) tuple)
	{
		SectWudangDefendHeavenlyTreeDisplayData sectWudangDefendHeavenlyTreeDisplayData = new SectWudangDefendHeavenlyTreeDisplayData();
		(sectWudangDefendHeavenlyTreeDisplayData.Locations, sectWudangDefendHeavenlyTreeDisplayData.EventTriggered) = tuple;
		return sectWudangDefendHeavenlyTreeDisplayData;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectWudangDefendHeavenlyTreeDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectWudangDefendHeavenlyTreeDisplayData(SectWudangDefendHeavenlyTreeDisplayData other)
	{
		Locations = ((other.Locations == null) ? null : new List<Location>(other.Locations));
		EventTriggered = other.EventTriggered;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectWudangDefendHeavenlyTreeDisplayData other)
	{
		Locations = ((other.Locations == null) ? null : new List<Location>(other.Locations));
		EventTriggered = other.EventTriggered;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize = ((Locations == null) ? (totalSize + 2) : (totalSize + (2 + default(Location).GetSerializedSize() * Locations.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Locations != null)
		{
			int elementsCount = Locations.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Locations[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (EventTriggered ? ((byte)1) : ((byte)0));
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Locations == null)
			{
				Locations = new List<Location>();
			}
			else
			{
				Locations.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
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
		EventTriggered = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 旅行预览显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class TravelPreviewDisplayData : ISerializableGameData
{
	/// <summary>
	/// 目标地区 ID
	/// </summary>
	[SerializableGameDataField]
	public short ToAreaId;

	/// <summary>
	/// 需要解锁驿站的地区 ID
	/// </summary>
	[SerializableGameDataField]
	public List<short> NeedUnlockStations;

	/// <summary>
	/// 威望消耗
	/// </summary>
	[SerializableGameDataField]
	public int AuthorityCost;

	/// <summary>
	/// 金钱消耗
	/// </summary>
	[SerializableGameDataField]
	public int MoneyCost;

	/// <summary>
	/// 时间消耗
	/// </summary>
	[SerializableGameDataField]
	public int DaysCost;

	/// <summary>
	/// 当前威望
	/// </summary>
	[SerializableGameDataField]
	public int CurrentAuthority;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TravelPreviewDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelPreviewDisplayData(TravelPreviewDisplayData other)
	{
		ToAreaId = other.ToAreaId;
		NeedUnlockStations = ((other.NeedUnlockStations == null) ? null : new List<short>(other.NeedUnlockStations));
		AuthorityCost = other.AuthorityCost;
		MoneyCost = other.MoneyCost;
		DaysCost = other.DaysCost;
		CurrentAuthority = other.CurrentAuthority;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelPreviewDisplayData other)
	{
		ToAreaId = other.ToAreaId;
		NeedUnlockStations = ((other.NeedUnlockStations == null) ? null : new List<short>(other.NeedUnlockStations));
		AuthorityCost = other.AuthorityCost;
		MoneyCost = other.MoneyCost;
		DaysCost = other.DaysCost;
		CurrentAuthority = other.CurrentAuthority;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize = ((NeedUnlockStations == null) ? (totalSize + 2) : (totalSize + (2 + 2 * NeedUnlockStations.Count)));
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
		*(short*)pCurrData = ToAreaId;
		pCurrData += 2;
		if (NeedUnlockStations != null)
		{
			int elementsCount = NeedUnlockStations.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = NeedUnlockStations[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AuthorityCost;
		pCurrData += 4;
		*(int*)pCurrData = MoneyCost;
		pCurrData += 4;
		*(int*)pCurrData = DaysCost;
		pCurrData += 4;
		*(int*)pCurrData = CurrentAuthority;
		pCurrData += 4;
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
		ToAreaId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (NeedUnlockStations == null)
			{
				NeedUnlockStations = new List<short>(elementsCount);
			}
			else
			{
				NeedUnlockStations.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NeedUnlockStations.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			NeedUnlockStations?.Clear();
		}
		AuthorityCost = *(int*)pCurrData;
		pCurrData += 4;
		MoneyCost = *(int*)pCurrData;
		pCurrData += 4;
		DaysCost = *(int*)pCurrData;
		pCurrData += 4;
		CurrentAuthority = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

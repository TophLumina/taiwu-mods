using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 鸡
/// </summary>
public struct ChickenBlessingInfoData(ChickenBlessingInfoData other) : ISerializableGameData
{
	/// <summary>
	/// 被鸡祝福的剩余时间
	/// key: 被鸡祝福的特性 TemplateId
	/// value: 被鸡祝福的剩余时间月数
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, sbyte> RemainingMonths = new Dictionary<short, sbyte>(other.RemainingMonths);

	public void Assign(ChickenBlessingInfoData other)
	{
		RemainingMonths = new Dictionary<short, sbyte>(other.RemainingMonths);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((RemainingMonths == null) ? (totalSize + 4) : (totalSize + (4 + 3 * RemainingMonths.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (RemainingMonths != null)
		{
			int elementsCount = RemainingMonths.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<short, sbyte> pair in RemainingMonths)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*pCurrData = (byte)pair.Value;
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (RemainingMonths == null)
			{
				RemainingMonths = new Dictionary<short, sbyte>();
			}
			else
			{
				RemainingMonths.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short id = *(short*)pCurrData;
				pCurrData += 2;
				sbyte time = (sbyte)(*pCurrData);
				pCurrData++;
				RemainingMonths.Add(id, time);
			}
		}
		else
		{
			RemainingMonths?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

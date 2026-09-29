using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class BuildingExceptionItem : ISerializableGameData
{
	[SerializableGameDataField]
	public List<sbyte> ExceptionTypeList = new List<sbyte>();

	public BuildingExceptionItem()
	{
	}

	public BuildingExceptionItem(BuildingExceptionItem other)
	{
		ExceptionTypeList = ((other.ExceptionTypeList == null) ? null : new List<sbyte>(other.ExceptionTypeList));
	}

	public void Assign(BuildingExceptionItem other)
	{
		ExceptionTypeList = ((other.ExceptionTypeList == null) ? null : new List<sbyte>(other.ExceptionTypeList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((ExceptionTypeList == null) ? (totalSize + 2) : (totalSize + (2 + ExceptionTypeList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ExceptionTypeList != null)
		{
			int elementsCount = ExceptionTypeList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (byte)ExceptionTypeList[i];
			}
			pCurrData += elementsCount;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ExceptionTypeList == null)
			{
				ExceptionTypeList = new List<sbyte>(elementsCount);
			}
			else
			{
				ExceptionTypeList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ExceptionTypeList.Add((sbyte)pCurrData[i]);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			ExceptionTypeList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

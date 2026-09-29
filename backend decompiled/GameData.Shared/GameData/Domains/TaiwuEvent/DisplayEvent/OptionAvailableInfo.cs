using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public struct OptionAvailableInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public OptionAvailableInfoMinimumElement[] Data;

	[SerializableGameDataField]
	public bool PassState;

	[SerializableGameDataField]
	public bool Hide;

	public OptionAvailableInfo(OptionAvailableInfo other)
	{
		OptionAvailableInfoMinimumElement[] item = other.Data;
		int elementsCount = item.Length;
		Data = new OptionAvailableInfoMinimumElement[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Data[i] = new OptionAvailableInfoMinimumElement(item[i]);
		}
		PassState = other.PassState;
		Hide = other.Hide;
	}

	public void Assign(OptionAvailableInfo other)
	{
		OptionAvailableInfoMinimumElement[] item = other.Data;
		int elementsCount = item.Length;
		Data = new OptionAvailableInfoMinimumElement[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Data[i] = new OptionAvailableInfoMinimumElement(item[i]);
		}
		PassState = other.PassState;
		Hide = other.Hide;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (Data != null)
		{
			totalSize += 2;
			int elementsCount = Data.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += Data[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Data != null)
		{
			int elementsCount = Data.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = Data[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (PassState ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Hide ? ((byte)1) : ((byte)0));
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
			if (Data == null || Data.Length != elementsCount)
			{
				Data = new OptionAvailableInfoMinimumElement[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				OptionAvailableInfoMinimumElement element = default(OptionAvailableInfoMinimumElement);
				pCurrData += element.Deserialize(pCurrData);
				Data[i] = element;
			}
		}
		else
		{
			Data = null;
		}
		PassState = *pCurrData != 0;
		pCurrData++;
		Hide = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

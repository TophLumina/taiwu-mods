using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public class EventNotifyData : ISerializableGameData
{
	[SerializableGameDataField]
	public string TitleKey;

	[SerializableGameDataField]
	public string[] TitleFormatArgs;

	[SerializableGameDataField]
	public string ContentKey;

	[SerializableGameDataField]
	public string[] ContentFormatArgs;

	public static readonly EventNotifyData Empty = new EventNotifyData();

	public EventNotifyData()
	{
	}

	public EventNotifyData(EventNotifyData other)
	{
		TitleKey = other.TitleKey;
		string[] item = other.TitleFormatArgs;
		int elementsCount = item.Length;
		TitleFormatArgs = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			TitleFormatArgs[i] = item[i];
		}
		ContentKey = other.ContentKey;
		string[] item2 = other.ContentFormatArgs;
		int elementsCount2 = item2.Length;
		ContentFormatArgs = new string[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			ContentFormatArgs[j] = item2[j];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((TitleKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TitleKey.Length)));
		if (TitleFormatArgs != null)
		{
			totalSize += 2;
			int elementsCount = TitleFormatArgs.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = TitleFormatArgs[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ContentKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ContentKey.Length)));
		if (ContentFormatArgs != null)
		{
			totalSize += 2;
			int elementsCount2 = ContentFormatArgs.Length;
			for (int j = 0; j < elementsCount2; j++)
			{
				string element2 = ContentFormatArgs[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element2.Length)));
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
		if (TitleKey != null)
		{
			int elementsCount = TitleKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = TitleKey)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TitleFormatArgs != null)
		{
			int elementsCount2 = TitleFormatArgs.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				string element = TitleFormatArgs[j];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar2 = element)
					{
						for (int k = 0; k < subElementsCount; k++)
						{
							((short*)pCurrData)[k] = (short)pChar2[k];
						}
					}
					pCurrData += 2 * subElementsCount;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ContentKey != null)
		{
			int elementsCount3 = ContentKey.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			fixed (char* pChar3 = ContentKey)
			{
				for (int l = 0; l < elementsCount3; l++)
				{
					((short*)pCurrData)[l] = (short)pChar3[l];
				}
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ContentFormatArgs != null)
		{
			int elementsCount4 = ContentFormatArgs.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int m = 0; m < elementsCount4; m++)
			{
				string element2 = ContentFormatArgs[m];
				if (element2 != null)
				{
					int subElementsCount2 = element2.Length;
					Tester.Assert(subElementsCount2 <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount2;
					pCurrData += 2;
					fixed (char* pChar4 = element2)
					{
						for (int n = 0; n < subElementsCount2; n++)
						{
							((short*)pCurrData)[n] = (short)pChar4[n];
						}
					}
					pCurrData += 2 * subElementsCount2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
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
			int fieldSize = 2 * elementsCount;
			TitleKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			TitleKey = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TitleFormatArgs == null || TitleFormatArgs.Length != elementsCount2)
			{
				TitleFormatArgs = new string[elementsCount2];
			}
			for (int i = 0; i < elementsCount2; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					TitleFormatArgs[i] = Encoding.Unicode.GetString(pCurrData, subDataSize);
					pCurrData += subDataSize;
				}
				else
				{
					TitleFormatArgs[i] = null;
				}
			}
		}
		else
		{
			TitleFormatArgs = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			int fieldSize2 = 2 * elementsCount3;
			ContentKey = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			ContentKey = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ContentFormatArgs == null || ContentFormatArgs.Length != elementsCount4)
			{
				ContentFormatArgs = new string[elementsCount4];
			}
			for (int j = 0; j < elementsCount4; j++)
			{
				ushort subDataCount2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount2 > 0)
				{
					int subDataSize2 = 2 * subDataCount2;
					ContentFormatArgs[j] = Encoding.Unicode.GetString(pCurrData, subDataSize2);
					pCurrData += subDataSize2;
				}
				else
				{
					ContentFormatArgs[j] = null;
				}
			}
		}
		else
		{
			ContentFormatArgs = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

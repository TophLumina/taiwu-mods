using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public struct OptionAvailableInfoMinimumElement : ISerializableGameData
{
	[SerializableGameDataField]
	public short ConditionId;

	[SerializableGameDataField]
	public string[] FormatArgs;

	[SerializableGameDataField]
	public bool Pass;

	[SerializableGameDataField]
	public bool Hide;

	public OptionAvailableInfoMinimumElement(OptionAvailableInfoMinimumElement other)
	{
		ConditionId = other.ConditionId;
		string[] item = other.FormatArgs;
		int elementsCount = item.Length;
		FormatArgs = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			FormatArgs[i] = item[i];
		}
		Pass = other.Pass;
		Hide = other.Hide;
	}

	public void Assign(OptionAvailableInfoMinimumElement other)
	{
		ConditionId = other.ConditionId;
		string[] item = other.FormatArgs;
		int elementsCount = item.Length;
		FormatArgs = new string[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			FormatArgs[i] = item[i];
		}
		Pass = other.Pass;
		Hide = other.Hide;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (FormatArgs != null)
		{
			totalSize += 2;
			int elementsCount = FormatArgs.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = FormatArgs[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element.Length)));
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
		*(short*)pCurrData = ConditionId;
		pCurrData += 2;
		if (FormatArgs != null)
		{
			int elementsCount = FormatArgs.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				string element = FormatArgs[i];
				if (element != null)
				{
					int subElementsCount = element.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar = element)
					{
						for (int j = 0; j < subElementsCount; j++)
						{
							((short*)pCurrData)[j] = (short)pChar[j];
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
		*pCurrData = (Pass ? ((byte)1) : ((byte)0));
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
		ConditionId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FormatArgs == null || FormatArgs.Length != elementsCount)
			{
				FormatArgs = new string[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					FormatArgs[i] = Encoding.Unicode.GetString(pCurrData, subDataSize);
					pCurrData += subDataSize;
				}
				else
				{
					FormatArgs[i] = null;
				}
			}
		}
		else
		{
			FormatArgs = null;
		}
		Pass = *pCurrData != 0;
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

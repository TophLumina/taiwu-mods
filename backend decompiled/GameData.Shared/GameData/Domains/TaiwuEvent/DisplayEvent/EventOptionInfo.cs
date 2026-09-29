using System;
using System.Collections.Generic;
using System.Text;
using GameData.Domains.TaiwuEvent.EventOption;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[Serializable]
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct EventOptionInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte OptionType;

	[SerializableGameDataField]
	public string OptionKey;

	[SerializableGameDataField]
	public string OptionGuid;

	[SerializableGameDataField]
	public string OptionContent;

	[SerializableGameDataField]
	public List<OptionAvailableInfo> OptionAvailableConditions;

	[SerializableGameDataField]
	public List<OptionAvailableConditionInfo> OptionAvailableConditionInfos;

	[SerializableGameDataField]
	public List<OptionConsumeInfo> OptionConsumeInfos;

	[SerializableGameDataField]
	public sbyte OptionState;

	[SerializableGameDataField]
	public sbyte Behavior;

	[SerializableGameDataField]
	public List<string> ExtraFormatLanguageKeys;

	[SerializableGameDataField]
	public bool Important;

	[SerializableGameDataField]
	public string ImportantOptionTipLanguageKey;

	[SerializableGameDataField]
	public string ImportantOptionTitleLanguageKey;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((OptionKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OptionKey.Length)));
		totalSize = ((OptionGuid == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OptionGuid.Length)));
		totalSize = ((OptionContent == null) ? (totalSize + 2) : (totalSize + (2 + 2 * OptionContent.Length)));
		if (OptionAvailableConditions != null)
		{
			totalSize += 2;
			int elementsCount = OptionAvailableConditions.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += OptionAvailableConditions[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (OptionAvailableConditionInfos != null)
		{
			totalSize += 2;
			int elementsCount2 = OptionAvailableConditionInfos.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				OptionAvailableConditionInfo element = OptionAvailableConditionInfos[j];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((OptionConsumeInfos == null) ? (totalSize + 2) : (totalSize + (2 + 12 * OptionConsumeInfos.Count)));
		if (ExtraFormatLanguageKeys != null)
		{
			totalSize += 2;
			int elementsCount3 = ExtraFormatLanguageKeys.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				string element2 = ExtraFormatLanguageKeys[k];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + 2 * element2.Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ImportantOptionTipLanguageKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ImportantOptionTipLanguageKey.Length)));
		totalSize = ((ImportantOptionTitleLanguageKey == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ImportantOptionTitleLanguageKey.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)OptionType;
		pCurrData++;
		if (OptionKey != null)
		{
			int elementsCount = OptionKey.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = OptionKey)
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
		if (OptionGuid != null)
		{
			int elementsCount2 = OptionGuid.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = OptionGuid)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OptionContent != null)
		{
			int elementsCount3 = OptionContent.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			fixed (char* pChar3 = OptionContent)
			{
				for (int k = 0; k < elementsCount3; k++)
				{
					((short*)pCurrData)[k] = (short)pChar3[k];
				}
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OptionAvailableConditions != null)
		{
			int elementsCount4 = OptionAvailableConditions.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				int subDataSize = OptionAvailableConditions[l].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (OptionAvailableConditionInfos != null)
		{
			int elementsCount5 = OptionAvailableConditionInfos.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				OptionAvailableConditionInfo element = OptionAvailableConditionInfos[m];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize2;
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
		if (OptionConsumeInfos != null)
		{
			int elementsCount6 = OptionConsumeInfos.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData += OptionConsumeInfos[n].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)OptionState;
		pCurrData++;
		*pCurrData = (byte)Behavior;
		pCurrData++;
		if (ExtraFormatLanguageKeys != null)
		{
			int elementsCount7 = ExtraFormatLanguageKeys.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				string element2 = ExtraFormatLanguageKeys[num];
				if (element2 != null)
				{
					int subElementsCount = element2.Length;
					Tester.Assert(subElementsCount <= 65535);
					*(ushort*)pCurrData = (ushort)subElementsCount;
					pCurrData += 2;
					fixed (char* pChar4 = element2)
					{
						for (int num2 = 0; num2 < subElementsCount; num2++)
						{
							((short*)pCurrData)[num2] = (short)pChar4[num2];
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
		*pCurrData = (Important ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ImportantOptionTipLanguageKey != null)
		{
			int elementsCount8 = ImportantOptionTipLanguageKey.Length;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			fixed (char* pChar5 = ImportantOptionTipLanguageKey)
			{
				for (int num3 = 0; num3 < elementsCount8; num3++)
				{
					((short*)pCurrData)[num3] = (short)pChar5[num3];
				}
			}
			pCurrData += 2 * elementsCount8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ImportantOptionTitleLanguageKey != null)
		{
			int elementsCount9 = ImportantOptionTitleLanguageKey.Length;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			fixed (char* pChar6 = ImportantOptionTitleLanguageKey)
			{
				for (int num4 = 0; num4 < elementsCount9; num4++)
				{
					((short*)pCurrData)[num4] = (short)pChar6[num4];
				}
			}
			pCurrData += 2 * elementsCount9;
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
		OptionType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			OptionKey = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			OptionKey = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			OptionGuid = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			OptionGuid = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			int fieldSize3 = 2 * elementsCount3;
			OptionContent = Encoding.Unicode.GetString(pCurrData, fieldSize3);
			pCurrData += fieldSize3;
		}
		else
		{
			OptionContent = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (OptionAvailableConditions == null)
			{
				OptionAvailableConditions = new List<OptionAvailableInfo>(elementsCount4);
			}
			else
			{
				OptionAvailableConditions.Clear();
			}
			for (int i = 0; i < elementsCount4; i++)
			{
				OptionAvailableInfo element = default(OptionAvailableInfo);
				pCurrData += element.Deserialize(pCurrData);
				OptionAvailableConditions.Add(element);
			}
		}
		else
		{
			OptionAvailableConditions?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (OptionAvailableConditionInfos == null)
			{
				OptionAvailableConditionInfos = new List<OptionAvailableConditionInfo>(elementsCount5);
			}
			else
			{
				OptionAvailableConditionInfos.Clear();
			}
			for (int j = 0; j < elementsCount5; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					OptionAvailableConditionInfo element2 = new OptionAvailableConditionInfo();
					pCurrData += element2.Deserialize(pCurrData);
					OptionAvailableConditionInfos.Add(element2);
				}
				else
				{
					OptionAvailableConditionInfos.Add(null);
				}
			}
		}
		else
		{
			OptionAvailableConditionInfos?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (OptionConsumeInfos == null)
			{
				OptionConsumeInfos = new List<OptionConsumeInfo>(elementsCount6);
			}
			else
			{
				OptionConsumeInfos.Clear();
			}
			for (int k = 0; k < elementsCount6; k++)
			{
				OptionConsumeInfo element3 = default(OptionConsumeInfo);
				pCurrData += element3.Deserialize(pCurrData);
				OptionConsumeInfos.Add(element3);
			}
		}
		else
		{
			OptionConsumeInfos?.Clear();
		}
		OptionState = (sbyte)(*pCurrData);
		pCurrData++;
		Behavior = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (ExtraFormatLanguageKeys == null)
			{
				ExtraFormatLanguageKeys = new List<string>(elementsCount7);
			}
			else
			{
				ExtraFormatLanguageKeys.Clear();
			}
			for (int l = 0; l < elementsCount7; l++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					int subDataSize = 2 * subDataCount;
					ExtraFormatLanguageKeys.Add(Encoding.Unicode.GetString(pCurrData, subDataSize));
					pCurrData += subDataSize;
				}
				else
				{
					ExtraFormatLanguageKeys.Add(null);
				}
			}
		}
		else
		{
			ExtraFormatLanguageKeys?.Clear();
		}
		Important = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			int fieldSize4 = 2 * elementsCount8;
			ImportantOptionTipLanguageKey = Encoding.Unicode.GetString(pCurrData, fieldSize4);
			pCurrData += fieldSize4;
		}
		else
		{
			ImportantOptionTipLanguageKey = null;
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			int fieldSize5 = 2 * elementsCount9;
			ImportantOptionTitleLanguageKey = Encoding.Unicode.GetString(pCurrData, fieldSize5);
			pCurrData += fieldSize5;
		}
		else
		{
			ImportantOptionTitleLanguageKey = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

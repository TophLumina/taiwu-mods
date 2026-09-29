using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class TotalTaiwuLifeSummaryInfo : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TotalTaiwuLifeSummaries = 0;

		public const ushort TotalTaiwuAvatarRelatedDatas = 1;

		public const ushort TotalTaiwuSurnames = 2;

		public const ushort TotalTaiwuGivenNames = 3;

		public const ushort TotalTaiwuTitleIds = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "TotalTaiwuLifeSummaries", "TotalTaiwuAvatarRelatedDatas", "TotalTaiwuSurnames", "TotalTaiwuGivenNames", "TotalTaiwuTitleIds" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<TaiwuLifeSummary> TotalTaiwuLifeSummaries;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<AvatarRelatedData> TotalTaiwuAvatarRelatedDatas;

	[SerializableGameDataField(FieldIndex = 2)]
	public List<string> TotalTaiwuSurnames;

	[SerializableGameDataField(FieldIndex = 3)]
	public List<string> TotalTaiwuGivenNames;

	[SerializableGameDataField(FieldIndex = 4)]
	public List<short> TotalTaiwuTitleIds;

	public TotalTaiwuLifeSummaryInfo()
	{
	}

	public TotalTaiwuLifeSummaryInfo(TotalTaiwuLifeSummaryInfo other)
	{
		if (other.TotalTaiwuLifeSummaries != null)
		{
			List<TaiwuLifeSummary> totalTaiwuLifeSummaries = other.TotalTaiwuLifeSummaries;
			int elementsCount = totalTaiwuLifeSummaries.Count;
			TotalTaiwuLifeSummaries = new List<TaiwuLifeSummary>(elementsCount);
			foreach (TaiwuLifeSummary element in totalTaiwuLifeSummaries)
			{
				TotalTaiwuLifeSummaries.Add(new TaiwuLifeSummary(element));
			}
		}
		else
		{
			TotalTaiwuLifeSummaries = null;
		}
		if (other.TotalTaiwuAvatarRelatedDatas != null)
		{
			List<AvatarRelatedData> totalTaiwuAvatarRelatedDatas = other.TotalTaiwuAvatarRelatedDatas;
			int elementsCount2 = totalTaiwuAvatarRelatedDatas.Count;
			TotalTaiwuAvatarRelatedDatas = new List<AvatarRelatedData>(elementsCount2);
			foreach (AvatarRelatedData element2 in totalTaiwuAvatarRelatedDatas)
			{
				TotalTaiwuAvatarRelatedDatas.Add(new AvatarRelatedData(element2));
			}
		}
		else
		{
			TotalTaiwuAvatarRelatedDatas = null;
		}
		TotalTaiwuSurnames = ((other.TotalTaiwuSurnames == null) ? null : new List<string>(other.TotalTaiwuSurnames));
		TotalTaiwuGivenNames = ((other.TotalTaiwuGivenNames == null) ? null : new List<string>(other.TotalTaiwuGivenNames));
		TotalTaiwuTitleIds = ((other.TotalTaiwuTitleIds == null) ? null : new List<short>(other.TotalTaiwuTitleIds));
	}

	public void Assign(TotalTaiwuLifeSummaryInfo other)
	{
		if (other.TotalTaiwuLifeSummaries != null)
		{
			List<TaiwuLifeSummary> totalTaiwuLifeSummaries = other.TotalTaiwuLifeSummaries;
			int elementsCount = totalTaiwuLifeSummaries.Count;
			TotalTaiwuLifeSummaries = new List<TaiwuLifeSummary>(elementsCount);
			foreach (TaiwuLifeSummary element in totalTaiwuLifeSummaries)
			{
				TotalTaiwuLifeSummaries.Add(new TaiwuLifeSummary(element));
			}
		}
		else
		{
			TotalTaiwuLifeSummaries = null;
		}
		if (other.TotalTaiwuAvatarRelatedDatas != null)
		{
			List<AvatarRelatedData> totalTaiwuAvatarRelatedDatas = other.TotalTaiwuAvatarRelatedDatas;
			int elementsCount2 = totalTaiwuAvatarRelatedDatas.Count;
			TotalTaiwuAvatarRelatedDatas = new List<AvatarRelatedData>(elementsCount2);
			foreach (AvatarRelatedData element2 in totalTaiwuAvatarRelatedDatas)
			{
				TotalTaiwuAvatarRelatedDatas.Add(new AvatarRelatedData(element2));
			}
		}
		else
		{
			TotalTaiwuAvatarRelatedDatas = null;
		}
		TotalTaiwuSurnames = ((other.TotalTaiwuSurnames == null) ? null : new List<string>(other.TotalTaiwuSurnames));
		TotalTaiwuGivenNames = ((other.TotalTaiwuGivenNames == null) ? null : new List<string>(other.TotalTaiwuGivenNames));
		TotalTaiwuTitleIds = ((other.TotalTaiwuTitleIds == null) ? null : new List<short>(other.TotalTaiwuTitleIds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (TotalTaiwuLifeSummaries != null)
		{
			totalSize += 2;
			for (int i = 0; i < TotalTaiwuLifeSummaries.Count; i++)
			{
				totalSize = ((TotalTaiwuLifeSummaries[i] == null) ? (totalSize + 2) : (totalSize + (2 + TotalTaiwuLifeSummaries[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TotalTaiwuAvatarRelatedDatas != null)
		{
			totalSize += 2;
			for (int j = 0; j < TotalTaiwuAvatarRelatedDatas.Count; j++)
			{
				totalSize = ((TotalTaiwuAvatarRelatedDatas[j] == null) ? (totalSize + 2) : (totalSize + (2 + TotalTaiwuAvatarRelatedDatas[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TotalTaiwuSurnames != null)
		{
			totalSize += 2;
			for (int k = 0; k < TotalTaiwuSurnames.Count; k++)
			{
				totalSize = ((TotalTaiwuSurnames[k] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TotalTaiwuSurnames[k].Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TotalTaiwuGivenNames != null)
		{
			totalSize += 2;
			for (int l = 0; l < TotalTaiwuGivenNames.Count; l++)
			{
				totalSize = ((TotalTaiwuGivenNames[l] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TotalTaiwuGivenNames[l].Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((TotalTaiwuTitleIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TotalTaiwuTitleIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		if (TotalTaiwuLifeSummaries != null)
		{
			int elementsCount = TotalTaiwuLifeSummaries.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (TotalTaiwuLifeSummaries[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = TotalTaiwuLifeSummaries[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		if (TotalTaiwuAvatarRelatedDatas != null)
		{
			int elementsCount2 = TotalTaiwuAvatarRelatedDatas.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (TotalTaiwuAvatarRelatedDatas[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = TotalTaiwuAvatarRelatedDatas[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		if (TotalTaiwuSurnames != null)
		{
			int elementsCount3 = TotalTaiwuSurnames.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (TotalTaiwuSurnames[k] != null)
				{
					int stringCount = TotalTaiwuSurnames[k].Length;
					Tester.Assert(stringCount <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount;
					pCurrData += 2;
					fixed (char* pChar = TotalTaiwuSurnames[k])
					{
						for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
						{
							((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
						}
					}
					pCurrData += 2 * stringCount;
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
		if (TotalTaiwuGivenNames != null)
		{
			int elementsCount4 = TotalTaiwuGivenNames.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (TotalTaiwuGivenNames[l] != null)
				{
					int stringCount2 = TotalTaiwuGivenNames[l].Length;
					Tester.Assert(stringCount2 <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount2;
					pCurrData += 2;
					fixed (char* pChar2 = TotalTaiwuGivenNames[l])
					{
						for (int m = 0; m < stringCount2; m++)
						{
							((short*)pCurrData)[m] = (short)pChar2[m];
						}
					}
					pCurrData += 2 * stringCount2;
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
		if (TotalTaiwuTitleIds != null)
		{
			int elementsCount5 = TotalTaiwuTitleIds.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int n = 0; n < elementsCount5; n++)
			{
				*(short*)pCurrData = TotalTaiwuTitleIds[n];
				pCurrData += 2;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TotalTaiwuLifeSummaries == null)
				{
					TotalTaiwuLifeSummaries = new List<TaiwuLifeSummary>();
				}
				else
				{
					TotalTaiwuLifeSummaries.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					TaiwuLifeSummary element;
					if (num > 0)
					{
						element = new TaiwuLifeSummary();
						pCurrData += element.Deserialize(pCurrData);
					}
					else
					{
						element = null;
					}
					TotalTaiwuLifeSummaries.Add(element);
				}
			}
			else
			{
				TotalTaiwuLifeSummaries?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (TotalTaiwuAvatarRelatedDatas == null)
				{
					TotalTaiwuAvatarRelatedDatas = new List<AvatarRelatedData>();
				}
				else
				{
					TotalTaiwuAvatarRelatedDatas.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					AvatarRelatedData element2;
					if (num2 > 0)
					{
						element2 = new AvatarRelatedData();
						pCurrData += element2.Deserialize(pCurrData);
					}
					else
					{
						element2 = null;
					}
					TotalTaiwuAvatarRelatedDatas.Add(element2);
				}
			}
			else
			{
				TotalTaiwuAvatarRelatedDatas?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (TotalTaiwuSurnames == null)
				{
					TotalTaiwuSurnames = new List<string>();
				}
				else
				{
					TotalTaiwuSurnames.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort stringCount = *(ushort*)pCurrData;
					pCurrData += 2;
					string element3;
					if (stringCount > 0)
					{
						int fieldSize = 2 * stringCount;
						element3 = Encoding.Unicode.GetString(pCurrData, fieldSize);
						pCurrData += fieldSize;
					}
					else
					{
						element3 = null;
					}
					TotalTaiwuSurnames.Add(element3);
				}
			}
			else
			{
				TotalTaiwuSurnames?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (TotalTaiwuGivenNames == null)
				{
					TotalTaiwuGivenNames = new List<string>();
				}
				else
				{
					TotalTaiwuGivenNames.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					ushort stringCount2 = *(ushort*)pCurrData;
					pCurrData += 2;
					string element4;
					if (stringCount2 > 0)
					{
						int fieldSize2 = 2 * stringCount2;
						element4 = Encoding.Unicode.GetString(pCurrData, fieldSize2);
						pCurrData += fieldSize2;
					}
					else
					{
						element4 = null;
					}
					TotalTaiwuGivenNames.Add(element4);
				}
			}
			else
			{
				TotalTaiwuGivenNames?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (TotalTaiwuTitleIds == null)
				{
					TotalTaiwuTitleIds = new List<short>();
				}
				else
				{
					TotalTaiwuTitleIds.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					short element5 = *(short*)pCurrData;
					pCurrData += 2;
					TotalTaiwuTitleIds.Add(element5);
				}
			}
			else
			{
				TotalTaiwuTitleIds?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

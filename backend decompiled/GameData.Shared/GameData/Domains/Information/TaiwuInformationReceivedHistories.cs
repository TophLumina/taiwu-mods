using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

[Obsolete]
[SerializableGameData(IsExtensible = true)]
public class TaiwuInformationReceivedHistories : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ReceivedNormalInformation = 0;

		public const ushort PackedNormalInformationIndices = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ReceivedNormalInformation", "PackedNormalInformationIndices" };
	}

	[SerializableGameDataField]
	private List<NormalInformation> _receivedNormalInformation = new List<NormalInformation>();

	[SerializableGameDataField]
	private List<int> _packedNormalInformationIndices = new List<int>();

	public void PackReceivedNormalInformationInLastMonth(List<NormalInformation> taiwuReceivedNormalInformationInMonth)
	{
		Dictionary<int, List<NormalInformation>> recordMap = new Dictionary<int, List<NormalInformation>>();
		for (int i = 0; i < _packedNormalInformationIndices.Count; i++)
		{
			int recordDate = _packedNormalInformationIndices[i++];
			List<NormalInformation> records = new List<NormalInformation>();
			for (; _packedNormalInformationIndices[i] >= 0; i++)
			{
				records.Add(_receivedNormalInformation[_packedNormalInformationIndices[i]]);
			}
			recordMap[recordDate] = records;
		}
		sbyte currMonthInYear = SharedMethods.CalcMonthInYear(ExternalDataBridge.Context.CurrDate);
		if (currMonthInYear != 0)
		{
			recordMap[currMonthInYear - 1] = taiwuReceivedNormalInformationInMonth;
		}
		_receivedNormalInformation.Clear();
		_packedNormalInformationIndices.Clear();
		foreach (int date in recordMap.Keys.OrderByDescending((int d) => d))
		{
			_packedNormalInformationIndices.Add(date);
			foreach (NormalInformation record in recordMap[date])
			{
				_packedNormalInformationIndices.Add(_receivedNormalInformation.Count);
				_receivedNormalInformation.Add(record);
			}
			_packedNormalInformationIndices.Add(-1);
		}
	}

	public void ClearReceivedInformation()
	{
		_receivedNormalInformation.Clear();
		_packedNormalInformationIndices.Clear();
	}

	public bool TryUnpackReceivedNormalInformationInMonth(int date, out List<NormalInformation> result)
	{
		for (int i = 0; i < _packedNormalInformationIndices.Count; i++)
		{
			if (_packedNormalInformationIndices[i++] == date)
			{
				result = new List<NormalInformation>();
				for (; _packedNormalInformationIndices[i] >= 0; i++)
				{
					result.Add(_receivedNormalInformation[_packedNormalInformationIndices[i]]);
				}
				return true;
			}
			for (; _packedNormalInformationIndices[i] >= 0; i++)
			{
			}
		}
		result = null;
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((_receivedNormalInformation == null) ? (totalSize + 2) : (totalSize + (2 + 3 * _receivedNormalInformation.Count)));
		totalSize = ((_packedNormalInformationIndices == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _packedNormalInformationIndices.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (_receivedNormalInformation != null)
		{
			int elementsCount = _receivedNormalInformation.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += _receivedNormalInformation[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_packedNormalInformationIndices != null)
		{
			int elementsCount2 = _packedNormalInformationIndices.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _packedNormalInformationIndices[j];
			}
			pCurrData += 4 * elementsCount2;
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
				if (_receivedNormalInformation == null)
				{
					_receivedNormalInformation = new List<NormalInformation>(elementsCount);
				}
				else
				{
					_receivedNormalInformation.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					NormalInformation element = default(NormalInformation);
					pCurrData += element.Deserialize(pCurrData);
					_receivedNormalInformation.Add(element);
				}
			}
			else
			{
				_receivedNormalInformation?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_packedNormalInformationIndices == null)
				{
					_packedNormalInformationIndices = new List<int>(elementsCount2);
				}
				else
				{
					_packedNormalInformationIndices.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					_packedNormalInformationIndices.Add(((int*)pCurrData)[j]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				_packedNormalInformationIndices?.Clear();
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

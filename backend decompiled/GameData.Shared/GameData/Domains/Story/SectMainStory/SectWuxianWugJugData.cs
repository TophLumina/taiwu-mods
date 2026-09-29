using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Story.SectMainStory;

[SerializableGameData(IsExtensible = true)]
public class SectWuxianWugJugData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Poisons = 0;

		public const ushort LastRefiningDate = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Poisons", "LastRefiningDate" };
	}

	[SerializableGameDataField]
	private List<int> _poisons = new List<int>(6);

	[SerializableGameDataField]
	private int _lastRefiningDate;

	public IReadOnlyList<int> Poisons => _poisons;

	public int TotalPoison => GetTotalPoison();

	public int LastRefiningDate => _lastRefiningDate;

	public int GetTotalPoison()
	{
		int sum = 0;
		foreach (int poison in Poisons)
		{
			sum += poison;
		}
		return sum;
	}

	public void Reset()
	{
		_poisons.Clear();
		for (int i = 0; i < 6; i++)
		{
			_poisons.Add(0);
		}
		_lastRefiningDate = -1;
	}

	public void AddPoison(sbyte poisonType, int addValue)
	{
		if (_poisons.Count != 6)
		{
			Reset();
		}
		_poisons[poisonType] = MathUtils.Clamp(_poisons[poisonType] + addValue, 0, 357913941);
	}

	public void ReducePoison(sbyte poisonType, int reduceValue)
	{
		AddPoison(poisonType, -reduceValue);
	}

	public void UpdateRefiningDate()
	{
		_lastRefiningDate = ExternalDataBridge.Context.CurrDate;
	}

	public SectWuxianWugJugData()
	{
	}

	public SectWuxianWugJugData(SectWuxianWugJugData other)
	{
		_poisons = ((other._poisons == null) ? null : new List<int>(other._poisons));
		_lastRefiningDate = other._lastRefiningDate;
	}

	public void Assign(SectWuxianWugJugData other)
	{
		_poisons = ((other._poisons == null) ? null : new List<int>(other._poisons));
		_lastRefiningDate = other._lastRefiningDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((_poisons == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _poisons.Count)));
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
		if (_poisons != null)
		{
			int elementsCount = _poisons.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _poisons[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _lastRefiningDate;
		pCurrData += 4;
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
				if (_poisons == null)
				{
					_poisons = new List<int>(elementsCount);
				}
				else
				{
					_poisons.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_poisons.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_poisons?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			_lastRefiningDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

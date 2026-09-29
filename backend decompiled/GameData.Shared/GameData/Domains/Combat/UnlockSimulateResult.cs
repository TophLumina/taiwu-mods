using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public class UnlockSimulateResult : ISerializableGameData
{
	[SerializableGameDataField]
	private List<int> _rawCreateEffects;

	[SerializableGameDataField]
	private List<int> _blockedRawCreateEffects;

	public bool AllBlocked
	{
		get
		{
			List<int> blockedRawCreateEffects = _blockedRawCreateEffects;
			if (blockedRawCreateEffects != null && blockedRawCreateEffects.Count > 0)
			{
				blockedRawCreateEffects = _rawCreateEffects;
				return blockedRawCreateEffects == null || blockedRawCreateEffects.Count <= 0;
			}
			return false;
		}
	}

	public IEnumerable<int> AllRawCreateEffects
	{
		get
		{
			if (_rawCreateEffects != null)
			{
				foreach (int rawCreateEffect in _rawCreateEffects)
				{
					yield return rawCreateEffect;
				}
			}
			if (_blockedRawCreateEffects == null)
			{
				yield break;
			}
			foreach (int blockedRawCreateEffect in _blockedRawCreateEffects)
			{
				yield return blockedRawCreateEffect;
			}
		}
	}

	public IReadOnlyList<int> BlockedRawCreateEffects => _blockedRawCreateEffects;

	public int AllRawCreateEffectsCount
	{
		get
		{
			List<int> rawCreateEffects = _rawCreateEffects;
			if (rawCreateEffects == null)
			{
				int? num = _blockedRawCreateEffects?.Count;
				int? num2 = num;
				return num2.GetValueOrDefault();
			}
			return rawCreateEffects.Count;
		}
	}

	public UnlockSimulateResult(IEnumerable<int> rawCreateEffects, Func<int, bool> blockedChecker)
	{
		_rawCreateEffects = new List<int>(rawCreateEffects);
		_blockedRawCreateEffects = new List<int>(_rawCreateEffects.Where(blockedChecker));
		_rawCreateEffects.RemoveAll(_blockedRawCreateEffects.Contains);
	}

	public UnlockSimulateResult()
	{
	}

	public UnlockSimulateResult(UnlockSimulateResult other)
	{
		_rawCreateEffects = ((other._rawCreateEffects == null) ? null : new List<int>(other._rawCreateEffects));
		_blockedRawCreateEffects = ((other._blockedRawCreateEffects == null) ? null : new List<int>(other._blockedRawCreateEffects));
	}

	public void Assign(UnlockSimulateResult other)
	{
		_rawCreateEffects = ((other._rawCreateEffects == null) ? null : new List<int>(other._rawCreateEffects));
		_blockedRawCreateEffects = ((other._blockedRawCreateEffects == null) ? null : new List<int>(other._blockedRawCreateEffects));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((_rawCreateEffects == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _rawCreateEffects.Count)));
		totalSize = ((_blockedRawCreateEffects == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _blockedRawCreateEffects.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_rawCreateEffects != null)
		{
			int elementsCount = _rawCreateEffects.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _rawCreateEffects[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_blockedRawCreateEffects != null)
		{
			int elementsCount2 = _blockedRawCreateEffects.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _blockedRawCreateEffects[j];
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_rawCreateEffects == null)
			{
				_rawCreateEffects = new List<int>(elementsCount);
			}
			else
			{
				_rawCreateEffects.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_rawCreateEffects.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_rawCreateEffects?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (_blockedRawCreateEffects == null)
			{
				_blockedRawCreateEffects = new List<int>(elementsCount2);
			}
			else
			{
				_blockedRawCreateEffects.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				_blockedRawCreateEffects.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			_blockedRawCreateEffects?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System;
using System.Collections.Generic;
using GameData.Dependencies;

namespace GameData.Common;

public class ObjectCollectionDataStates
{
	public const int InvalidOffset = -1;

	private const int DefaultObjectCapacity = 16;

	private static readonly byte[] EmptyArray = Array.Empty<byte>();

	private readonly int _uintSize;

	private byte[] _dataStates;

	private int _nextMaxOffset;

	private readonly Stack<int> _unoccupiedOffsets;

	public int Count => _nextMaxOffset / _uintSize - _unoccupiedOffsets.Count;

	public int Capacity => _dataStates.Length / _uintSize;

	public ObjectCollectionDataStates(int fieldsCount, int capacity)
	{
		if (fieldsCount <= 0)
		{
			throw new ArgumentOutOfRangeException("fieldsCount", "FieldsCount must be greater than zero");
		}
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "Capacity cannot be less than zero");
		}
		_uintSize = (fieldsCount + 3) / 4;
		_dataStates = ((capacity > 0) ? new byte[_uintSize * capacity] : EmptyArray);
		_nextMaxOffset = 0;
		_unoccupiedOffsets = new Stack<int>(capacity / 10);
	}

	public int Create()
	{
		int offset;
		if (_unoccupiedOffsets.Count > 0)
		{
			offset = _unoccupiedOffsets.Pop();
		}
		else
		{
			EnsureCapacity(_nextMaxOffset + _uintSize);
			offset = _nextMaxOffset;
			_nextMaxOffset += _uintSize;
		}
		Array.Clear(_dataStates, offset, _uintSize);
		return offset;
	}

	public void Remove(int offset)
	{
		if (offset >= 0)
		{
			if (offset == _nextMaxOffset - _uintSize)
			{
				_nextMaxOffset -= _uintSize;
			}
			else
			{
				_unoccupiedOffsets.Push(offset);
			}
		}
	}

	public void Clear()
	{
		_nextMaxOffset = 0;
		_unoccupiedOffsets.Clear();
	}

	public bool IsCached(int offset, int fieldId)
	{
		return (_dataStates[offset + fieldId / 4] & (1 << fieldId % 4 * 2)) != 0;
	}

	public void SetCached(int offset, int fieldId)
	{
		_dataStates[offset + fieldId / 4] |= (byte)(1 << fieldId % 4 * 2);
	}

	public void ResetCached(int offset, int fieldId)
	{
		_dataStates[offset + fieldId / 4] &= (byte)(~(1 << fieldId % 4 * 2));
	}

	public bool IsModified(int offset, int fieldId)
	{
		return (_dataStates[offset + fieldId / 4] & (2 << fieldId % 4 * 2)) != 0;
	}

	public void SetModified(int offset, int fieldId)
	{
		_dataStates[offset + fieldId / 4] |= (byte)(2 << fieldId % 4 * 2);
	}

	public void ResetModified(int offset, int fieldId)
	{
		_dataStates[offset + fieldId / 4] &= (byte)(~(2 << fieldId % 4 * 2));
	}

	public void InvalidateAll(DataInfluence influence)
	{
		List<DataUid> targetUids = influence.TargetUids;
		int targetUidsCount = targetUids.Count;
		for (int offset = 0; offset < _nextMaxOffset; offset += _uintSize)
		{
			for (int i = 0; i < targetUidsCount; i++)
			{
				ushort fieldId = (ushort)targetUids[i].SubId1;
				int outerIndex = offset + fieldId / 4;
				int innerIndex = fieldId % 4 * 2;
				int state = (_dataStates[outerIndex] & ~(3 << innerIndex)) | (2 << innerIndex);
				_dataStates[outerIndex] = (byte)state;
			}
		}
	}

	private void EnsureCapacity(int min)
	{
		if (_dataStates.Length < min)
		{
			int newCapacity = ((_dataStates.Length == 0) ? (16 * _uintSize) : (_dataStates.Length * 2));
			if ((uint)newCapacity > 2147483647u)
			{
				newCapacity = int.MaxValue;
			}
			if (newCapacity < min)
			{
				newCapacity = min;
			}
			byte[] newDataStates = new byte[newCapacity];
			if (_nextMaxOffset > 0)
			{
				Array.Copy(_dataStates, newDataStates, _nextMaxOffset);
			}
			_dataStates = newDataStates;
		}
	}
}

using System;
using System.Text;
using GameData.Adventure;
using GameData.Domains.World.Task;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public struct AdventureParameterValue : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Type = 0;

		public const ushort InternalValue0 = 1;

		public const ushort InternalValue1 = 2;

		public const ushort InternalByte = 3;

		public const ushort InternalString = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "Type", "InternalValue0", "InternalValue1", "InternalByte", "InternalString" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private EAdventureParameterValueType _type;

	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalValue0;

	[SerializableGameDataField(FieldIndex = 2)]
	private int _internalValue1;

	[SerializableGameDataField(FieldIndex = 3)]
	private byte _internalByte;

	[SerializableGameDataField(FieldIndex = 4)]
	private string _internalString;

	public bool Readonly
	{
		get
		{
			EAdventureParameterValueType type = _type;
			bool flag = (uint)type <= 1u;
			return !flag;
		}
	}

	public int Current => _internalValue0;

	public int Max
	{
		get
		{
			if (_type != EAdventureParameterValueType.Progress)
			{
				return 0;
			}
			return _internalValue1;
		}
	}

	public float AsProgress
	{
		get
		{
			if (_type != EAdventureParameterValueType.Progress || _internalValue1 == 0)
			{
				return 0f;
			}
			return (float)_internalValue0 / (float)_internalValue1;
		}
	}

	public bool AsBool
	{
		get
		{
			if (_type == EAdventureParameterValueType.Bool)
			{
				return _internalValue0 != 0;
			}
			return false;
		}
	}

	public AdventureBlockIndex AsIndex
	{
		get
		{
			if (_type != EAdventureParameterValueType.Index)
			{
				return default(AdventureBlockIndex);
			}
			return new AdventureBlockIndex(_internalValue0, _internalValue1);
		}
	}

	public TaskData AsTask
	{
		get
		{
			if (_type != EAdventureParameterValueType.Task)
			{
				return default(TaskData);
			}
			return new TaskData
			{
				TaskChainId = _internalValue0,
				TaskInfoId = _internalValue1,
				TaskStatus = _internalByte
			};
		}
	}

	public string AsString
	{
		get
		{
			if (_type != EAdventureParameterValueType.String)
			{
				return null;
			}
			return _internalString;
		}
	}

	public static implicit operator AdventureParameterValue(int value)
	{
		return new AdventureParameterValue(EAdventureParameterValueType.Int, value);
	}

	public static implicit operator AdventureParameterValue(bool value)
	{
		return new AdventureParameterValue(EAdventureParameterValueType.Bool, value ? 1 : 0);
	}

	public static implicit operator AdventureParameterValue(AdventureBlockIndex i)
	{
		return new AdventureParameterValue(EAdventureParameterValueType.Index, i.Gx, i.Gy, 0);
	}

	public static implicit operator AdventureParameterValue(TaskData task)
	{
		return new AdventureParameterValue(EAdventureParameterValueType.Task, task.TaskChainId, task.TaskInfoId, task.TaskStatus);
	}

	public static implicit operator AdventureParameterValue(string value)
	{
		return new AdventureParameterValue(EAdventureParameterValueType.String, 0, 0, 0, value);
	}

	public AdventureParameterValue(EAdventureParameterType type, int value)
		: this(type.ConvertToValueType(), value)
	{
	}

	public AdventureParameterValue(EAdventureParameterValueType type, int value)
		: this(type, value, (type == EAdventureParameterValueType.Progress) ? value : 0, 0)
	{
	}

	private AdventureParameterValue(EAdventureParameterValueType type, int value0, int value1, byte valueByte = 0, string valueStr = null)
	{
		_type = type;
		_internalValue0 = value0;
		_internalValue1 = value1;
		_internalByte = valueByte;
		_internalString = valueStr;
	}

	public void Set(int value)
	{
		if (!Readonly)
		{
			_internalValue0 = value;
			if (_type == EAdventureParameterValueType.Progress)
			{
				_internalValue1 = value;
			}
		}
	}

	public bool Change(int delta)
	{
		if (Readonly)
		{
			return false;
		}
		if (_type == EAdventureParameterValueType.Int)
		{
			_internalValue0 += delta;
		}
		else
		{
			if (_internalValue1 <= 0)
			{
				return false;
			}
			_internalValue0 = Math.Clamp(_internalValue0 + delta, 0, _internalValue1);
		}
		return true;
	}

	public override string ToString()
	{
		return _type switch
		{
			EAdventureParameterValueType.Int => "(" + _internalValue0 + ")", 
			EAdventureParameterValueType.Progress => "(" + _internalValue0 + "/" + _internalValue1 + ")", 
			EAdventureParameterValueType.Bool => (AsBool ? "True" : "False") ?? "", 
			EAdventureParameterValueType.Index => AsIndex.ToString(), 
			EAdventureParameterValueType.Task => AsTask.ToString(), 
			_ => $"<{_type}>({_internalValue0},{_internalValue1})", 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((_internalString == null) ? (totalSize + 2) : (totalSize + (2 + 2 * _internalString.Length)));
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
		*pCurrData = (byte)_type;
		pCurrData++;
		*(int*)pCurrData = _internalValue0;
		pCurrData += 4;
		*(int*)pCurrData = _internalValue1;
		pCurrData += 4;
		*pCurrData = _internalByte;
		pCurrData++;
		if (_internalString != null)
		{
			int elementsCount = _internalString.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = _internalString)
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			_type = (EAdventureParameterValueType)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			_internalValue0 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			_internalValue1 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			_internalByte = *pCurrData;
			pCurrData++;
		}
		if (num > 4)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				_internalString = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				_internalString = null;
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

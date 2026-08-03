using System;
using System.Runtime.InteropServices;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.ActionPlanning.MonthlyAI;

[StructLayout(LayoutKind.Explicit)]
[SerializableGameData(NoCopyConstructors = true, NotForDisplayModule = true)]
public struct PlanningContextArg : ISerializableGameData, IEquatable<PlanningContextArg>
{
	[FieldOffset(0)]
	[SerializableGameDataField]
	private ulong _value;

	[FieldOffset(0)]
	private EPlanningParameterValueType _valueType;

	[FieldOffset(4)]
	private sbyte _sbyteValue;

	[FieldOffset(4)]
	private ushort _ushortValue;

	[FieldOffset(4)]
	private short _shortValue;

	[FieldOffset(4)]
	private uint _uintValue;

	[FieldOffset(4)]
	private int _intValue;

	[FieldOffset(4)]
	private Location _locationValue;

	public EPlanningParameterValueType ValueType => _valueType;

	public static implicit operator PlanningContextArg(Character character)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Int,
			_intValue = character.GetId()
		};
	}

	public static implicit operator PlanningContextArg(Location location)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Location,
			_locationValue = location
		};
	}

	public static implicit operator PlanningContextArg(MapBlockData mapBlockData)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Location,
			_locationValue = mapBlockData.GetLocation()
		};
	}

	public static implicit operator PlanningContextArg(int value)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Int,
			_intValue = value
		};
	}

	public static implicit operator PlanningContextArg(short value)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Short,
			_shortValue = value
		};
	}

	public static implicit operator PlanningContextArg(uint value)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Uint,
			_uintValue = value
		};
	}

	public static implicit operator PlanningContextArg(ushort value)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Ushort,
			_ushortValue = value
		};
	}

	public static implicit operator PlanningContextArg(sbyte value)
	{
		return new PlanningContextArg
		{
			_valueType = EPlanningParameterValueType.Sbyte,
			_sbyteValue = value
		};
	}

	public static implicit operator Location(PlanningContextArg arg)
	{
		return arg._locationValue;
	}

	public static implicit operator ushort(PlanningContextArg arg)
	{
		return arg._ushortValue;
	}

	public static implicit operator int(PlanningContextArg arg)
	{
		return arg._intValue;
	}

	public static implicit operator short(PlanningContextArg arg)
	{
		return arg._shortValue;
	}

	public static implicit operator sbyte(PlanningContextArg arg)
	{
		return arg._sbyteValue;
	}

	public bool Equals(PlanningContextArg other)
	{
		return _value == other._value;
	}

	public override bool Equals(object obj)
	{
		return obj is PlanningContextArg other && Equals(other);
	}

	public override int GetHashCode()
	{
		return _value.GetHashCode();
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = _value;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_value = *(ulong*)pData;
		return 8;
	}
}

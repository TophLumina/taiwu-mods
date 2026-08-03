using System;
using System.Runtime.InteropServices;
using GameData.Serializer;

namespace GameData.Utilities;

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct SimpleVariant : IVariant, ISerializableGameData
{
	public enum EType : byte
	{
		Int,
		Float,
		Bool,
		Complex
	}

	[FieldOffset(0)]
	private ulong _value;

	[FieldOffset(0)]
	public EType Type;

	[FieldOffset(1)]
	private int _intValue;

	[FieldOffset(1)]
	private float _floatValue;

	[FieldOffset(1)]
	private bool _boolValue;

	[FieldOffset(1)]
	private ComplexVariantTypeId _complexTypeId;

	public IVariant Duplicate()
	{
		return new SimpleVariant
		{
			Type = Type,
			_value = _value
		};
	}

	public static explicit operator SimpleVariant(int value)
	{
		return new SimpleVariant
		{
			_intValue = value,
			Type = EType.Int
		};
	}

	public static explicit operator SimpleVariant(float value)
	{
		return new SimpleVariant
		{
			_floatValue = value,
			Type = EType.Float
		};
	}

	public static explicit operator SimpleVariant(bool value)
	{
		return new SimpleVariant
		{
			_boolValue = value,
			Type = EType.Bool
		};
	}

	public static explicit operator SimpleVariant(ComplexVariantTypeId value)
	{
		return new SimpleVariant
		{
			_complexTypeId = value,
			Type = EType.Complex
		};
	}

	public static explicit operator int(SimpleVariant variant)
	{
		if (variant.Type != EType.Int)
		{
			throw variant.ThrowInvalidCastException(EType.Int);
		}
		return variant._intValue;
	}

	public static explicit operator float(SimpleVariant variant)
	{
		if (variant.Type != EType.Float)
		{
			throw variant.ThrowInvalidCastException(EType.Float);
		}
		return variant._floatValue;
	}

	public static explicit operator bool(SimpleVariant variant)
	{
		if (variant.Type != EType.Bool)
		{
			throw variant.ThrowInvalidCastException(EType.Bool);
		}
		return variant._boolValue;
	}

	public static explicit operator ComplexVariantTypeId(SimpleVariant variant)
	{
		if (variant.Type != EType.Complex)
		{
			throw variant.ThrowInvalidCastException(EType.Complex);
		}
		return variant._complexTypeId;
	}

	private InvalidCastException ThrowInvalidCastException(EType targetType)
	{
		throw new InvalidCastException($"Unable to cast from {Type} to {targetType}");
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

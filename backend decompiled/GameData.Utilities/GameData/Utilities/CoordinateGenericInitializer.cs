using System;

namespace GameData.Utilities;

public static class CoordinateGenericInitializer
{
	public static void Initialize()
	{
		Coordinate2D<sbyte>.Initialize((sbyte a, sbyte b) => a == b, (sbyte a, sbyte b) => (sbyte)(a + b), (sbyte a, sbyte b) => (sbyte)(a - b), Math.Abs, (sbyte a) => a, (sbyte a) => a);
		Coordinate2D<byte>.Initialize((byte a, byte b) => a == b, (byte a, byte b) => (byte)(a + b), (byte a, byte b) => (byte)(a - b), (byte a) => a, (byte a) => a, (byte a) => (int)a);
		Coordinate2D<short>.Initialize((short a, short b) => a == b, (short a, short b) => (short)(a + b), (short a, short b) => (short)(a - b), Math.Abs, (short a) => a, (short a) => a);
		Coordinate2D<ushort>.Initialize((ushort a, ushort b) => a == b, (ushort a, ushort b) => (ushort)(a + b), (ushort a, ushort b) => (ushort)(a - b), (ushort a) => a, (ushort a) => a, (ushort a) => (int)a);
		Coordinate2D<int>.Initialize((int a, int b) => a == b, (int a, int b) => a + b, (int a, int b) => a - b, Math.Abs, (int a) => a, (int a) => a);
	}
}

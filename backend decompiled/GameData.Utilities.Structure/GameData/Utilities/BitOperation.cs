namespace GameData.Utilities;

public static class BitOperation
{
	public static bool GetBit(byte value, int pos)
	{
		return (value & (1 << pos)) != 0;
	}

	public static byte SetBit(byte value, int pos, bool bit)
	{
		return (byte)(bit ? (value | (1 << pos)) : (value & ~(1 << pos)));
	}

	public static bool GetBit(ushort value, int pos)
	{
		return (value & (1 << pos)) != 0;
	}

	public static ushort SetBit(ushort value, int pos, bool bit)
	{
		return (ushort)(bit ? (value | (1 << pos)) : (value & ~(1 << pos)));
	}

	public static bool GetBit(uint value, int pos)
	{
		return (value & (1 << pos)) != 0;
	}

	public static uint SetBit(uint value, int pos, bool bit)
	{
		return (uint)(bit ? (value | (uint)(1 << pos)) : (value & ~(1 << pos)));
	}

	public static bool GetBit(ulong value, int pos)
	{
		return (value & (ulong)(1L << pos)) != 0;
	}

	public static ulong SetBit(ulong value, int pos, bool bit)
	{
		if (!bit)
		{
			return value & (ulong)(~(1L << pos));
		}
		return value | (ulong)(1L << pos);
	}

	public static byte GetSubByte(byte value, int pos, int count)
	{
		return (byte)(value << 8 - pos - count >> 8 - count);
	}

	public static byte SetSubByte(byte value, int pos, int count, byte subByte)
	{
		return (byte)((value & ~((2 ^ (count - 1)) << pos)) | (subByte << pos));
	}

	public static ulong GetSubUlong(ulong value, int pos, int count)
	{
		return value << 64 - pos - count >> 64 - count;
	}

	public static ulong SetSubUlong(ulong value, int pos, int count, ulong subUlong)
	{
		return (value & (ulong)(~((long)(2 ^ (count - 1)) << pos))) | (subUlong << pos);
	}

	public static byte GetSubUint(uint value, int pos, int count)
	{
		return (byte)(value << 32 - pos - count >> 32 - count);
	}

	public static uint SetSubUint(uint value, int pos, int count, byte subByte)
	{
		return (uint)((value & ~((2 ^ (count - 1)) << pos)) | (uint)(subByte << pos));
	}

	public static byte GetSubUshort(ushort value, int pos, int count)
	{
		return (byte)(value << 16 - pos - count >> 16 - count);
	}

	public static ushort SetSubUshort(ushort value, int pos, int count, byte subByte)
	{
		return (ushort)((value & ~((2 ^ (count - 1)) << pos)) | (ushort)(subByte << pos));
	}

	public static byte ConnectUint(uint uint1, uint uint2, int clip1, int clip2)
	{
		return (byte)((uint1 << 32 - clip1 >> 32 - clip1 - clip2) & (uint2 >> 32 - clip2));
	}

	public static void SplitByteToUints(ref uint uint1, ref uint uint2, int clip1, int clip2, byte value)
	{
		uint1 = (uint)((uint1 & ~(2 ^ (clip1 - 1))) | GetSubByte(value, clip2, clip1));
		uint2 = (uint)((uint1 & ~((2 ^ (clip1 - 1)) << 32 - clip2)) | (uint)(GetSubByte(value, 0, clip2) << 32 - clip2));
	}

	public static int CountBits(uint set)
	{
		int count = 0;
		while (set != 0)
		{
			set &= set - 1;
			count++;
		}
		return count;
	}

	public static (ushort major, ushort minor, ushort build, ushort revision) UnpackVersion(ulong version)
	{
		ulong subUlong = GetSubUlong(version, 0, 16);
		ulong minor = GetSubUlong(version, 16, 16);
		ulong build = GetSubUlong(version, 32, 16);
		ulong revision = GetSubUlong(version, 48, 16);
		return (major: (ushort)subUlong, minor: (ushort)minor, build: (ushort)build, revision: (ushort)revision);
	}

	public static ulong PackVersion(ushort major, ushort minor, ushort build, ushort revision)
	{
		return major | ((ulong)minor << 16) | ((ulong)build << 32) | ((ulong)revision << 48);
	}
}

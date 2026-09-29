using System;
using System.Runtime.InteropServices;
using GameData.Domains;

namespace GameData.Common;

[StructLayout(LayoutKind.Explicit)]
public readonly struct DataUid(ushort domainId, ushort dataId, ulong subId0 = ulong.MaxValue, uint subId1 = uint.MaxValue) : IEquatable<DataUid>
{
	public const ulong SubId0None = ulong.MaxValue;

	public const ulong SubId0PerContext = 18446744073709551614uL;

	public const uint SubId1None = uint.MaxValue;

	[FieldOffset(0)]
	public readonly ushort DomainId = domainId;

	[FieldOffset(2)]
	public readonly ushort DataId = dataId;

	[FieldOffset(4)]
	public readonly ulong SubId0 = subId0;

	[FieldOffset(12)]
	public readonly uint SubId1 = subId1;

	public bool Equals(DataUid other)
	{
		if (DomainId == other.DomainId && DataId == other.DataId && SubId0 == other.SubId0)
		{
			return SubId1 == other.SubId1;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is DataUid other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((DomainId.GetHashCode() * 397) ^ DataId.GetHashCode()) * 397) ^ SubId0.GetHashCode()) * 397) ^ (int)SubId1;
	}

	public override string ToString()
	{
		if (DomainId < DomainHelper.DomainId2DomainName.Length)
		{
			string domainName = DomainHelper.DomainId2DomainName[DomainId];
			string domainFieldName = DomainHelper.DomainId2DataId2FieldName[DomainId][DataId];
			string[] fieldId2FieldName = DomainHelper.DomainId2DataId2ObjectFieldId2FieldName[DomainId][DataId];
			if (fieldId2FieldName != null)
			{
				string objectFieldName = fieldId2FieldName[SubId1];
				string[] obj = new string[7] { domainName, ".", domainFieldName, ".", null, null, null };
				long subId = (long)SubId0;
				obj[4] = subId.ToString();
				obj[5] = ".";
				obj[6] = objectFieldName;
				return string.Concat(obj);
			}
			if (SubId0 != ulong.MaxValue)
			{
				string[] obj2 = new string[5] { domainName, ".", domainFieldName, ".", null };
				long subId = (long)SubId0;
				obj2[4] = subId.ToString();
				return string.Concat(obj2);
			}
			return domainName + "." + domainFieldName;
		}
		return $"Invalid({DomainId}.{DataId}.{SubId0}.{SubId1})";
	}
}

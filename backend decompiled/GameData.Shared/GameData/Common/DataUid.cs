using System;
using System.Runtime.InteropServices;
using GameData.Domains;

namespace GameData.Common;

/// <summary>
/// 游戏世界内数据唯一 ID
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public readonly struct DataUid(ushort domainId, ushort dataId, ulong subId0 = ulong.MaxValue, uint subId1 = uint.MaxValue) : IEquatable<DataUid>
{
	/// <summary>
	/// SubId0 不存在
	/// </summary>
	public const ulong SubId0None = ulong.MaxValue;

	/// <summary>
	/// 根据上下文确定 SubId0
	/// </summary>
	public const ulong SubId0PerContext = 18446744073709551614uL;

	/// <summary>
	/// SubId1 不存在
	/// </summary>
	public const uint SubId1None = uint.MaxValue;

	/// <summary>
	/// 数据的域 ID, 代表一个数据类, 例如角色, 物品等.
	/// 当表示全局域时, 此值为 0.
	/// </summary>
	[FieldOffset(0)]
	public readonly ushort DomainId = domainId;

	/// <summary>
	/// 数据 ID, 代表数据类中的一个成员, 例如角色类中的角色集合, 角色类中的已死亡角色集合等.
	/// 转为有符号数后, 大于等于 0 时为正常值. 若小于 0, 则表示特殊值.
	/// 对于对象集合型数据类, 其主对象集合的 dataId 固定为 0.
	/// 当表示数据 ID 不存在时, 此值为 -1.
	/// </summary>
	[FieldOffset(2)]
	public readonly ushort DataId = dataId;

	/// <summary>
	/// 第一级数据子 ID, 代表数据类中的一个成员的第一级索引, 例如角色类中的角色集合, 它用角色 ID 作为第一级索引.
	/// 转为有符号数后, 大于等于 0 时为正常值. 若小于 0, 则表示特殊值.
	/// 当对应数据的第一级索引不存在时, 此值为 -1.
	/// 当表示应根据当前上下文自动确定时, 此值为 -2.
	/// </summary>
	[FieldOffset(4)]
	public readonly ulong SubId0 = subId0;

	/// <summary>
	/// 第二级数据子 ID, 代表数据类中的一个成员的第二级索引, 例如角色类中的角色集合, 它用角色的属性 ID 作为第二级索引.
	/// 转为有符号数后, 大于等于 0 时为正常值. 若小于 0, 则表示特殊值.
	/// 当对应数据的第二级索引不存在时, 此值为 -1.
	/// </summary>
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

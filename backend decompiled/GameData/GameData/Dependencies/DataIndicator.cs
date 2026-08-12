using System;
using GameData.Common;
using GameData.Domains;

namespace GameData.Dependencies;

public readonly struct DataIndicator(DomainDataType dataType, ushort domainId, ushort dataId) : IEquatable<DataIndicator>
{
	public readonly DomainDataType DataType = dataType;

	public readonly ushort DomainId = domainId;

	public readonly ushort DataId = dataId;

	public bool Equals(DataIndicator other)
	{
		return DataType == other.DataType && DomainId == other.DomainId && DataId == other.DataId;
	}

	public override bool Equals(object obj)
	{
		return obj is DataIndicator other && Equals(other);
	}

	public override int GetHashCode()
	{
		int hashCode = (int)DataType;
		hashCode = (hashCode * 397) ^ DomainId.GetHashCode();
		return (hashCode * 397) ^ DataId.GetHashCode();
	}

	public override string ToString()
	{
		string dataTypeName = Enum.GetName(typeof(DomainDataType), DataType);
		string domainName = DomainHelper.DomainId2DomainName[DomainId];
		switch (DataType)
		{
		case DomainDataType.SingleValue:
		case DomainDataType.SingleValueCollection:
			return domainName + "(" + dataTypeName + ")";
		case DomainDataType.ElementList:
		{
			string dataName2 = DomainHelper.DomainId2DataId2FieldName[DomainId][DataId];
			return $"{domainName}.{dataName2}({dataTypeName})";
		}
		default:
		{
			string dataName = DomainHelper.DomainId2DataId2FieldName[DomainId][DataId];
			return $"{domainName}.{dataName}({dataTypeName})";
		}
		}
	}
}

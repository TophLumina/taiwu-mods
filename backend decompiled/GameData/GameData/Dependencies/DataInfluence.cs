using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains;

namespace GameData.Dependencies;

public class DataInfluence : IEquatable<DataInfluence>
{
	public DataIndicator TargetIndicator;

	public InfluenceCondition Condition;

	public InfluenceScope Scope;

	public readonly List<DataUid> TargetUids;

	public DataInfluence(DataIndicator targetIndicator, InfluenceCondition condition, InfluenceScope scope)
	{
		TargetIndicator = targetIndicator;
		Condition = condition;
		Scope = scope;
		TargetUids = new List<DataUid>();
	}

	public bool Equals(DataInfluence other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		return TargetIndicator.Equals(other.TargetIndicator) && Condition == other.Condition && Scope == other.Scope;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((DataInfluence)obj);
	}

	public override int GetHashCode()
	{
		int hashCode = TargetIndicator.GetHashCode();
		hashCode = (hashCode * 397) ^ (int)Condition;
		return (hashCode * 397) ^ (int)Scope;
	}

	public override string ToString()
	{
		ushort domainId = TargetIndicator.DomainId;
		string domainName = DomainHelper.DomainId2DomainName[domainId];
		string[] dataId2FieldName = DomainHelper.DomainId2DataId2FieldName[domainId];
		int uidsCount = TargetUids.Count;
		string[] dataNames = new string[uidsCount];
		string prefix;
		switch (TargetIndicator.DataType)
		{
		case DomainDataType.SingleValue:
		case DomainDataType.SingleValueCollection:
		{
			prefix = domainName;
			for (int j = 0; j < uidsCount; j++)
			{
				ushort dataId2 = TargetUids[j].DataId;
				string fieldName2 = dataId2FieldName[dataId2];
				dataNames[j] = fieldName2;
			}
			break;
		}
		case DomainDataType.ElementList:
		{
			ushort dataId3 = TargetIndicator.DataId;
			string fieldName3 = dataId2FieldName[dataId3];
			prefix = domainName + "." + fieldName3;
			for (int k = 0; k < uidsCount; k++)
			{
				dataNames[k] = TargetUids[k].SubId0.ToString();
			}
			break;
		}
		default:
		{
			ushort dataId = TargetIndicator.DataId;
			string fieldName = dataId2FieldName[dataId];
			prefix = domainName + "." + fieldName + ".";
			string[] fieldId2FieldName = DomainHelper.DomainId2DataId2ObjectFieldId2FieldName[domainId][dataId];
			for (int i = 0; i < uidsCount; i++)
			{
				uint fieldId = TargetUids[i].SubId1;
				dataNames[i] = fieldId2FieldName[fieldId];
			}
			break;
		}
		}
		return prefix + ".[" + string.Join(", ", dataNames) + "]";
	}
}

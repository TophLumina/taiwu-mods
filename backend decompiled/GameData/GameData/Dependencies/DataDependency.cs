using GameData.Common;
using GameData.Domains;

namespace GameData.Dependencies;

public class DataDependency
{
	public readonly DomainDataType SourceType;

	public readonly DataUid[] SourceUids;

	public readonly InfluenceCondition Condition;

	public readonly InfluenceScope Scope;

	public DataDependency(DomainDataType sourceType, DataUid[] sourceUids, InfluenceCondition condition, InfluenceScope scope)
	{
		SourceType = sourceType;
		SourceUids = sourceUids;
		Condition = condition;
		Scope = scope;
	}

	public override string ToString()
	{
		ushort domainId = SourceUids[0].DomainId;
		string domainName = DomainHelper.DomainId2DomainName[domainId];
		string[] dataId2FieldName = DomainHelper.DomainId2DataId2FieldName[domainId];
		int uidsCount = SourceUids.Length;
		string[] dataNames = new string[uidsCount];
		string prefix;
		switch (SourceType)
		{
		case DomainDataType.SingleValue:
		case DomainDataType.SingleValueCollection:
		{
			prefix = domainName;
			for (int j = 0; j < uidsCount; j++)
			{
				ushort dataId2 = SourceUids[j].DataId;
				string fieldName2 = dataId2FieldName[dataId2];
				dataNames[j] = fieldName2;
			}
			break;
		}
		case DomainDataType.ElementList:
		{
			ushort dataId3 = SourceUids[0].DataId;
			string fieldName3 = dataId2FieldName[dataId3];
			prefix = domainName + "." + fieldName3;
			for (int k = 0; k < uidsCount; k++)
			{
				dataNames[k] = SourceUids[k].SubId0.ToString();
			}
			break;
		}
		default:
		{
			ushort dataId = SourceUids[0].DataId;
			string fieldName = dataId2FieldName[dataId];
			prefix = domainName + "." + fieldName + ".";
			string[] fieldId2FieldName = DomainHelper.DomainId2DataId2ObjectFieldId2FieldName[domainId][dataId];
			for (int i = 0; i < uidsCount; i++)
			{
				uint fieldId = SourceUids[i].SubId1;
				dataNames[i] = fieldId2FieldName[fieldId];
			}
			break;
		}
		}
		return prefix + ".[" + string.Join(", ", dataNames) + "]";
	}
}

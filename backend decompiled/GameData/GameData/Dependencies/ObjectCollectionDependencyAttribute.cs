using GameData.Common;

namespace GameData.Dependencies;

public class ObjectCollectionDependencyAttribute : BaseDataDependencyAttribute
{
	public ObjectCollectionDependencyAttribute(ushort domainId, ushort dataId, params ushort[] subId1List)
	{
		SourceType = DomainDataType.ObjectCollection;
		int subId1ListLength = subId1List.Length;
		SourceUids = new DataUid[subId1ListLength];
		for (int i = 0; i < subId1ListLength; i++)
		{
			SourceUids[i] = new DataUid(domainId, dataId, 18446744073709551614uL, subId1List[i]);
		}
		Condition = InfluenceCondition.None;
		Scope = InfluenceScope.All;
	}
}

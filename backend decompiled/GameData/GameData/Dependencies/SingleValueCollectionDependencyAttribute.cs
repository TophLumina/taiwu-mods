using GameData.Common;

namespace GameData.Dependencies;

public class SingleValueCollectionDependencyAttribute : BaseDataDependencyAttribute
{
	public SingleValueCollectionDependencyAttribute(ushort domainId, params ushort[] dataIds)
	{
		SourceType = DomainDataType.SingleValueCollection;
		int dataIdsLength = dataIds.Length;
		SourceUids = new DataUid[dataIdsLength];
		for (int i = 0; i < dataIdsLength; i++)
		{
			SourceUids[i] = new DataUid(domainId, dataIds[i], ulong.MaxValue);
		}
		Condition = InfluenceCondition.None;
		Scope = InfluenceScope.All;
	}
}

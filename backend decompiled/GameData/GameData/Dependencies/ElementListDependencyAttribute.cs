using GameData.Common;

namespace GameData.Dependencies;

public class ElementListDependencyAttribute : BaseDataDependencyAttribute
{
	public ElementListDependencyAttribute(ushort domainId, ushort dataId, params ulong[] subId0List)
	{
		SourceType = DomainDataType.ElementList;
		int subId0ListLength = subId0List.Length;
		SourceUids = new DataUid[subId0ListLength];
		for (int i = 0; i < subId0ListLength; i++)
		{
			SourceUids[i] = new DataUid(domainId, dataId, subId0List[i]);
		}
		Condition = InfluenceCondition.None;
		Scope = InfluenceScope.All;
	}

	public ElementListDependencyAttribute(ushort domainId, ushort dataId, int count)
	{
		SourceType = DomainDataType.ElementList;
		SourceUids = new DataUid[count];
		for (int subId0 = 0; subId0 < count; subId0++)
		{
			SourceUids[subId0] = new DataUid(domainId, dataId, (ulong)subId0);
		}
		Condition = InfluenceCondition.None;
		Scope = InfluenceScope.All;
	}
}

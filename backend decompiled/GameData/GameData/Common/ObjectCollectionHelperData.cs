using GameData.Dependencies;

namespace GameData.Common;

public class ObjectCollectionHelperData
{
	public readonly ushort DomainId;

	public readonly ushort DataId;

	public readonly DataInfluence[][] CacheInfluences;

	public readonly ObjectCollectionDataStates DataStates;

	public readonly bool IsArchive;

	public ObjectCollectionHelperData(ushort domainId, ushort dataId, DataInfluence[][] cacheInfluences, ObjectCollectionDataStates dataStates, bool isArchive)
	{
		DomainId = domainId;
		DataId = dataId;
		CacheInfluences = cacheInfluences;
		DataStates = dataStates;
		IsArchive = isArchive;
	}
}

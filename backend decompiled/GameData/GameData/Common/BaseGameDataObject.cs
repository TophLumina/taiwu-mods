using GameData.ArchiveData;
using GameData.Dependencies;
using GameData.Domains;
using GameData.Utilities;

namespace GameData.Common;

public abstract class BaseGameDataObject : ArchiveFieldGroup
{
	public ObjectCollectionHelperData CollectionHelperData;

	public int DataStatesOffset;

	protected BaseGameDataObject()
	{
		DataStatesOffset = -1;
	}

	protected void SetModifiedAndInvalidateInfluencedCache(ushort fieldId, DataContext context)
	{
		CollectionHelperData.DataStates.SetModified(DataStatesOffset, fieldId);
		DataInfluence[] influences = CollectionHelperData.CacheInfluences[fieldId];
		if (influences == null)
		{
			return;
		}
		Tester.Assert(context != null);
		int influencesCount = influences.Length;
		for (int i = 0; i < influencesCount; i++)
		{
			DataInfluence influence = influences[i];
			if (InfluenceChecker.CheckCondition(context, this, influence.Condition))
			{
				BaseGameDataDomain domain = DomainManager.Domains[influence.TargetIndicator.DomainId];
				domain.InvalidateCache(this, influence, context, unconditionallyInfluenceAll: false);
			}
		}
	}

	public void InvalidateSelfAndInfluencedCache(ushort fieldId, DataContext context)
	{
		ObjectCollectionDataStates dataStates = CollectionHelperData.DataStates;
		dataStates.SetModified(DataStatesOffset, fieldId);
		if (!dataStates.IsCached(DataStatesOffset, fieldId))
		{
			return;
		}
		dataStates.ResetCached(DataStatesOffset, fieldId);
		DataInfluence[] influences = CollectionHelperData.CacheInfluences[fieldId];
		if (influences == null)
		{
			return;
		}
		Tester.Assert(context != null);
		int influencesCount = influences.Length;
		for (int i = 0; i < influencesCount; i++)
		{
			DataInfluence influence = influences[i];
			if (InfluenceChecker.CheckCondition(context, this, influence.Condition))
			{
				BaseGameDataDomain domain = DomainManager.Domains[influence.TargetIndicator.DomainId];
				domain.InvalidateCache(this, influence, context, unconditionallyInfluenceAll: false);
			}
		}
	}
}

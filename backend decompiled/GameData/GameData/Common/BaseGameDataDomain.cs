using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.ArchiveData;
using GameData.Dependencies;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Common;

public abstract class BaseGameDataDomain
{
	protected readonly byte[] DataStates;

	protected readonly Dictionary<DataUid, DataModificationHandlerGroup> PostModificationDataHandlers = new Dictionary<DataUid, DataModificationHandlerGroup>();

	protected readonly ushort DomainId;

	protected readonly int FieldsCount;

	private readonly Dictionary<ushort, InitNewDomainData> _newDomainDataInitializers = new Dictionary<ushort, InitNewDomainData>();

	protected BaseGameDataDomain(int fieldsCount)
	{
		FieldsCount = fieldsCount;
		DataStates = new byte[(fieldsCount + 3) / 4];
		Type type = GetType();
		DomainId = type.GetCustomAttribute<GameDataDomainAttribute>().Id;
		LoadNewDomainDataInitializers(type);
	}

	public abstract void OnInitializeGameDataModule();

	public abstract void OnEnterNewWorld();

	public abstract void OnLoadWorld(ArchiveFileBase archive);

	public abstract void OnSaveWorld(ArchiveFileBase archive);

	public virtual void OnUpdate(DataContext context)
	{
	}

	public virtual void FixAbnormalDomainArchiveData(DataContext context)
	{
	}

	public virtual void OnCurrWorldArchiveDataReady(DataContext context, bool isNewWorld)
	{
	}

	public virtual void PackCrossArchiveGameData(CrossArchiveGameData crossArchiveGameData)
	{
	}

	public virtual void UnpackCrossArchiveGameData(DataContext context, CrossArchiveGameData crossArchiveGameData)
	{
	}

	public abstract int GetData(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool, bool resetModified);

	public abstract void SetData(ushort dataId, ulong subId0, uint subId1, int valueOffset, RawDataPool dataPool, DataContext context);

	public abstract int CallMethod(Operation operation, RawDataPool argDataPool, RawDataPool returnDataPool, DataContext context);

	public abstract void OnMonitorData(ushort dataId, ulong subId0, uint subId1, bool monitoring);

	public abstract int CheckModified(ushort dataId, ulong subId0, uint subId1, RawDataPool dataPool);

	public abstract void ResetModifiedWrapper(ushort dataId, ulong subId0, uint subId1);

	public abstract bool IsModifiedWrapper(ushort dataId, ulong subId0, uint subId1);

	public abstract void InvalidateCache(BaseGameDataObject sourceObject, DataInfluence influence, DataContext context, bool unconditionallyInfluenceAll);

	public static bool IsCached(byte[] dataStates, int fieldId)
	{
		return (dataStates[fieldId / 4] & (1 << fieldId % 4 * 2)) != 0;
	}

	public static void SetCached(byte[] dataStates, int fieldId)
	{
		dataStates[fieldId / 4] |= (byte)(1 << fieldId % 4 * 2);
	}

	public static void ResetCached(byte[] dataStates, int fieldId)
	{
		dataStates[fieldId / 4] &= (byte)(~(1 << fieldId % 4 * 2));
	}

	public static bool IsModified(byte[] dataStates, int fieldId)
	{
		return (dataStates[fieldId / 4] & (2 << fieldId % 4 * 2)) != 0;
	}

	public static void SetModified(byte[] dataStates, int fieldId)
	{
		dataStates[fieldId / 4] |= (byte)(2 << fieldId % 4 * 2);
	}

	public static void ResetModified(byte[] dataStates, int fieldId)
	{
		dataStates[fieldId / 4] &= (byte)(~(2 << fieldId % 4 * 2));
	}

	public void ExecutePostModificationHandlers(DataContext context, DataUid uid)
	{
		if (PostModificationDataHandlers.TryGetValue(uid, out var handlerGroup))
		{
			handlerGroup.ExecuteAll(context, uid);
		}
	}

	public void AddPostModificationHandler(DataUid uid, string handlerKey, DataModificationHandler handler)
	{
		if (!PostModificationDataHandlers.TryGetValue(uid, out var handlerGroup))
		{
			handlerGroup = new DataModificationHandlerGroup();
			PostModificationDataHandlers.Add(uid, handlerGroup);
		}
		handlerGroup.RegisterHandler(handlerKey, handler);
	}

	public bool RemovePostModificationHandler(DataUid uid, string handlerKey)
	{
		if (PostModificationDataHandlers.TryGetValue(uid, out var handlerGroup))
		{
			handlerGroup.UnregisterHandler(handlerKey);
			return handlerGroup.Count == 0;
		}
		return true;
	}

	public void RemovePostModificationHandlers(DataUid uid)
	{
		PostModificationDataHandlers.Remove(uid);
	}

	protected void RecordLoadedDomainData(ushort dataId)
	{
		SetModified(DataStates, dataId);
	}

	private void LoadNewDomainDataInitializers(Type type)
	{
		MethodInfo[] methods = type.GetMethods((BindingFlags)(-1));
		foreach (MethodInfo methodInfo in methods)
		{
			NewDomainDataInitializerAttribute attribute = methodInfo.GetCustomAttribute<NewDomainDataInitializerAttribute>();
			if (attribute != null)
			{
				InitNewDomainData initMethod = (InitNewDomainData)Delegate.CreateDelegate(typeof(InitNewDomainData), this, methodInfo);
				_newDomainDataInitializers.Add(attribute.DataId, initMethod);
			}
		}
	}

	public void InitNewDomainDataFields()
	{
		for (ushort dataId = 0; dataId < FieldsCount; dataId++)
		{
			if (IsModified(DataStates, dataId))
			{
				ResetModified(DataStates, dataId);
			}
			else
			{
				InitNewField(dataId);
			}
		}
	}

	private void InitNewField(ushort dataId)
	{
		if (_newDomainDataInitializers.TryGetValue(dataId, out var callback))
		{
			callback();
			string typeName = GetType().Name;
			string fieldName = DomainHelper.DomainId2DataId2FieldName[DomainId][dataId];
			string methodName = callback.Method.Name;
			AdaptableLog.TagInfo("LoadArchive", $"Initializing new field: {typeName}.{fieldName} with {methodName}");
		}
	}

	protected virtual void SetModifiedAndInvalidateInfluencedCache(int dataId, byte[] dataStates, DataInfluence[][] cacheInfluences, DataContext context)
	{
		SetModified(dataStates, dataId);
		DataInfluence[] influences = cacheInfluences[dataId];
		if (influences != null)
		{
			Tester.Assert(context != null);
			int influencesCount = influences.Length;
			for (int i = 0; i < influencesCount; i++)
			{
				DataInfluence influence = influences[i];
				BaseGameDataDomain domain = DomainManager.Domains[influence.TargetIndicator.DomainId];
				domain.InvalidateCache(null, influence, context, unconditionallyInfluenceAll: false);
			}
		}
	}

	protected static void InvalidateSelfAndInfluencedCache(int dataId, byte[] dataStates, DataInfluence[][] cacheInfluences, DataContext context)
	{
		int outerIndex = dataId / 4;
		int innerIndex = dataId % 4 * 2;
		int state = (dataStates[outerIndex] & ~(3 << innerIndex)) | (2 << innerIndex);
		dataStates[outerIndex] = (byte)state;
		DataInfluence[] influences = cacheInfluences[dataId];
		if (influences != null)
		{
			Tester.Assert(context != null);
			int influencesCount = influences.Length;
			for (int i = 0; i < influencesCount; i++)
			{
				DataInfluence influence = influences[i];
				BaseGameDataDomain domain = DomainManager.Domains[influence.TargetIndicator.DomainId];
				domain.InvalidateCache(null, influence, context, unconditionallyInfluenceAll: false);
			}
		}
	}

	protected static void InvalidateAllAndInfluencedCaches(DataInfluence[][] cacheInfluences, ObjectCollectionDataStates dataStates, DataInfluence influence, DataContext context)
	{
		Tester.Assert(context != null);
		dataStates.InvalidateAll(influence);
		List<DataUid> targetUids = influence.TargetUids;
		int targetUidsCount = targetUids.Count;
		for (int i = 0; i < targetUidsCount; i++)
		{
			ushort fieldId = (ushort)targetUids[i].SubId1;
			DataInfluence[] currInfluences = cacheInfluences[fieldId];
			if (currInfluences != null)
			{
				int currInfluencesCount = currInfluences.Length;
				for (int j = 0; j < currInfluencesCount; j++)
				{
					DataInfluence currInfluence = currInfluences[j];
					BaseGameDataDomain domain = DomainManager.Domains[currInfluence.TargetIndicator.DomainId];
					domain.InvalidateCache(null, currInfluence, context, unconditionallyInfluenceAll: true);
				}
			}
		}
	}
}

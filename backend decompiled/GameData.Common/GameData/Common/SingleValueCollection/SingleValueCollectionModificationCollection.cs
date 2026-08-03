using System;
using System.Collections.Generic;

namespace GameData.Common.SingleValueCollection;

public struct SingleValueCollectionModificationCollection<TKey> where TKey : unmanaged, IEquatable<TKey>
{
	public List<SingleValueCollectionModification<TKey>> Items;

	private bool _recordingModifications;

	public static SingleValueCollectionModificationCollection<TKey> Create()
	{
		SingleValueCollectionModificationCollection<TKey> collection = default(SingleValueCollectionModificationCollection<TKey>);
		collection.Items = new List<SingleValueCollectionModification<TKey>>();
		collection._recordingModifications = false;
		return collection;
	}

	public void ChangeRecording(bool recording)
	{
		_recordingModifications = recording;
		if (!recording)
		{
			Reset();
		}
	}

	public void Reset()
	{
		Items.Clear();
	}

	public void RecordAdding(TKey id)
	{
		if (_recordingModifications)
		{
			Items.Add(new SingleValueCollectionModification<TKey>(0, id));
		}
	}

	public void RecordSetting(TKey id)
	{
		if (!_recordingModifications)
		{
			return;
		}
		if (Items.Count > 0)
		{
			List<SingleValueCollectionModification<TKey>> items = Items;
			if (items[items.Count - 1].Equals(1, id))
			{
				return;
			}
		}
		Items.Add(new SingleValueCollectionModification<TKey>(1, id));
	}

	public void RecordRemoving(TKey id)
	{
		if (_recordingModifications)
		{
			Items.Add(new SingleValueCollectionModification<TKey>(2, id));
		}
	}

	public void RecordClearing()
	{
		if (_recordingModifications)
		{
			Items.Clear();
			Items.Add(new SingleValueCollectionModification<TKey>(3, default(TKey)));
		}
	}
}

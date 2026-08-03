using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public abstract class MonthlyActionBase : ISerializableGameData
{
	[SerializableGameDataField]
	public MonthlyActionKey Key = MonthlyActionKey.Invalid;

	[SerializableGameDataField]
	public sbyte State;

	[SerializableGameDataField]
	public int Month;

	[SerializableGameDataField]
	public int LastFinishDate;

	public virtual bool IsMonthMatch()
	{
		return false;
	}

	public virtual void TriggerAction()
	{
	}

	public virtual void MonthlyHandler()
	{
	}

	public virtual void Activate()
	{
	}

	public virtual void Deactivate(bool isComplete)
	{
	}

	public virtual void InheritNonArchiveData(MonthlyActionBase action)
	{
	}

	public virtual void FillEventArgBox(EventArgBox eventArgBox)
	{
	}

	public virtual void EnsurePrerequisites()
	{
	}

	public virtual void ValidationHandler()
	{
	}

	public virtual void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
	}

	public abstract MonthlyActionBase CreateCopy();

	public virtual bool IsSerializedSizeFixed()
	{
		throw new Exception("Can't call ISerializableGameData method directly from abstract class MonthlyActionBase.");
	}

	public virtual int GetSerializedSize()
	{
		throw new Exception("Can't call ISerializableGameData method directly from abstract class MonthlyActionBase.");
	}

	public unsafe virtual int Serialize(byte* pData)
	{
		throw new Exception("Can't call ISerializableGameData method directly from abstract class MonthlyActionBase.");
	}

	public unsafe virtual int Deserialize(byte* pData)
	{
		throw new Exception("Can't call ISerializableGameData method directly from abstract class MonthlyActionBase.");
	}
}

using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public class ConfigWrapperAction : MonthlyActionBase, ISerializableGameData
{
	[field: SerializableGameDataField]
	public ConfigMonthlyAction CurrConfigMonthlyAction { get; private set; }

	public ConfigWrapperAction(MonthlyActionKey key)
	{
		Key = key;
	}

	public void CreateWrappedAction(short templateId, short assignedAreaId = -1)
	{
		if (CurrConfigMonthlyAction == null)
		{
			CurrConfigMonthlyAction = new ConfigMonthlyAction(templateId, assignedAreaId);
			CurrConfigMonthlyAction.Key = Key;
			CurrConfigMonthlyAction.SelectLocation();
			CurrConfigMonthlyAction.TriggerAction();
			if (CurrConfigMonthlyAction.State == 0)
			{
				CurrConfigMonthlyAction = null;
			}
		}
	}

	public override void MonthlyHandler()
	{
		CurrConfigMonthlyAction?.MonthlyHandler();
	}

	public override void ValidationHandler()
	{
		CurrConfigMonthlyAction?.ValidationHandler();
	}

	public override void Deactivate(bool isComplete)
	{
		CurrConfigMonthlyAction.Deactivate(isComplete);
		CurrConfigMonthlyAction = null;
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		if (CurrConfigMonthlyAction != null)
		{
			eventArgBox.Get("AdventureLocation", out Location location);
			if (location.IsValid())
			{
				CurrConfigMonthlyAction.EnsurePrerequisites();
				CurrConfigMonthlyAction.FillEventArgBox(eventArgBox);
			}
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		CurrConfigMonthlyAction?.CollectCalledCharacters(calledCharacters);
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public ConfigWrapperAction()
	{
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((CurrConfigMonthlyAction == null) ? (totalSize + 2) : (totalSize + (2 + CurrConfigMonthlyAction.GetSerializedSize())));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CurrConfigMonthlyAction != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 2;
			int fieldSize = CurrConfigMonthlyAction.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)pSubDataCount = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Key.Serialize(pCurrData);
		*pCurrData = (byte)State;
		pCurrData++;
		*(int*)pCurrData = Month;
		pCurrData += 4;
		*(int*)pCurrData = LastFinishDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldSize = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldSize > 0)
		{
			if (CurrConfigMonthlyAction == null)
			{
				CurrConfigMonthlyAction = new ConfigMonthlyAction();
			}
			pCurrData += CurrConfigMonthlyAction.Deserialize(pCurrData);
		}
		else
		{
			CurrConfigMonthlyAction = null;
		}
		pCurrData += Key.Deserialize(pCurrData);
		State = (sbyte)(*pCurrData);
		pCurrData++;
		Month = *(int*)pCurrData;
		pCurrData += 4;
		LastFinishDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

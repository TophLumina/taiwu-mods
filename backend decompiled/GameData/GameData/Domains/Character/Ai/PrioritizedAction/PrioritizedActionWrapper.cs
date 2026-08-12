using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

[SerializableGameData(NotForDisplayModule = true)]
public class PrioritizedActionWrapper : ISerializableGameData
{
	[Obsolete]
	[SerializableGameDataField]
	public sbyte ObsoleteActionType;

	[SerializableGameDataField]
	public short ActionType;

	[SerializableGameDataField]
	public BasePrioritizedAction Action;

	public PrioritizedActionWrapper()
	{
		ActionType = -1;
		Action = null;
	}

	public PrioritizedActionWrapper(sbyte actionType, NpcTravelTarget target)
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (ActionType >= 0)
		{
			totalSize += Action.GetSerializedSize();
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = 15;
		pCurrData++;
		*(short*)pCurrData = ActionType;
		pCurrData += 2;
		if (ActionType >= 0)
		{
			pCurrData += Action.Serialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ObsoleteActionType = (sbyte)(*pCurrData);
		pCurrData++;
		if (ObsoleteActionType > 14)
		{
			ActionType = *(short*)pCurrData;
			pCurrData += 2;
		}
		else
		{
			ActionType = ObsoleteActionType;
		}
		Action = null;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

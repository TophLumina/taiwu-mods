using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

[SerializableGameData]
public class PrioritizedActionCooldownList : ISerializableGameData
{
	[SerializableGameDataField]
	public List<PrioritizedActionCooldown> DataList = new List<PrioritizedActionCooldown>();

	public void Add(PrioritizedActionCooldown cooldown)
	{
		if (Contains(cooldown))
		{
			DataList.Remove(cooldown);
		}
		DataList.Add(cooldown);
	}

	public void Remove(PrioritizedActionCooldown cooldown)
	{
		if (Contains(cooldown))
		{
			DataList.Remove(cooldown);
		}
	}

	public int Get(short templateId)
	{
		foreach (PrioritizedActionCooldown data in DataList)
		{
			if (templateId == data.TemplateId)
			{
				return data.Cooldown;
			}
		}
		return 0;
	}

	public bool Contains(PrioritizedActionCooldown cooldown)
	{
		foreach (PrioritizedActionCooldown data in DataList)
		{
			if (cooldown == data)
			{
				return true;
			}
		}
		return false;
	}

	public bool Contains(short templateId)
	{
		foreach (PrioritizedActionCooldown data2 in DataList)
		{
			if (templateId == data2.TemplateId)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((DataList == null) ? (totalSize + 2) : (totalSize + (2 + 6 * DataList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DataList != null)
		{
			int elementsCount = DataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += DataList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (DataList == null)
			{
				DataList = new List<PrioritizedActionCooldown>(elementsCount);
			}
			else
			{
				DataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PrioritizedActionCooldown element = default(PrioritizedActionCooldown);
				pCurrData += element.Deserialize(pCurrData);
				DataList.Add(element);
			}
		}
		else
		{
			DataList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

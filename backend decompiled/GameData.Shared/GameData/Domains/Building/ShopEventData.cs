using System;
using GameData.Serializer;

namespace GameData.Domains.Building;

[Obsolete]
public struct ShopEventData(int eventDate, short itemTemplateId, sbyte resourceType, int resourceCount, sbyte recruitPeopleLevel, short eventConfigId, sbyte eventDesType, sbyte itemType) : ISerializableGameData
{
	public static readonly ShopEventData Invalid = new ShopEventData(0, -1, -1, -1, 0, -1, -1, -1);

	[SerializableGameDataField]
	public int EventDate = eventDate;

	[SerializableGameDataField]
	public short ItemTemplateId = itemTemplateId;

	[SerializableGameDataField]
	public sbyte ItemType = itemType;

	[SerializableGameDataField]
	public sbyte ResourceType = resourceType;

	[SerializableGameDataField]
	public int ResourceCount = resourceCount;

	[SerializableGameDataField]
	public sbyte RecruitPeopleLevel = recruitPeopleLevel;

	[SerializableGameDataField]
	public short EventConfigId = eventConfigId;

	[SerializableGameDataField]
	public sbyte EventDesType = eventDesType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 16;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = EventDate;
		byte* num = pData + 4;
		*(short*)num = ItemTemplateId;
		byte* num2 = num + 2;
		*num2 = (byte)ItemType;
		byte* num3 = num2 + 1;
		*num3 = (byte)ResourceType;
		byte* num4 = num3 + 1;
		*(int*)num4 = ResourceCount;
		byte* num5 = num4 + 4;
		*num5 = (byte)RecruitPeopleLevel;
		byte* num6 = num5 + 1;
		*(short*)num6 = EventConfigId;
		byte* num7 = num6 + 2;
		*num7 = (byte)EventDesType;
		int totalSize = (int)(num7 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		EventDate = *(int*)pCurrData;
		pCurrData += 4;
		ItemTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceCount = *(int*)pCurrData;
		pCurrData += 4;
		RecruitPeopleLevel = (sbyte)(*pCurrData);
		pCurrData++;
		EventConfigId = *(short*)pCurrData;
		pCurrData += 2;
		EventDesType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

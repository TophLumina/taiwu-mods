using System;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 物品的索引
/// </summary>
[Obsolete]
public struct ShopEventData(int eventDate, short itemTemplateId, sbyte resourceType, int resourceCount, sbyte recruitPeopleLevel, short eventConfigId, sbyte eventDesType, sbyte itemType) : ISerializableGameData
{
	public static readonly ShopEventData Invalid = new ShopEventData(0, -1, -1, -1, 0, -1, -1, -1);

	/// <summary>
	/// 事件发生时间
	/// </summary>
	[SerializableGameDataField]
	public int EventDate = eventDate;

	/// <summary>
	/// 事件产生道具模板id
	/// </summary>
	[SerializableGameDataField]
	public short ItemTemplateId = itemTemplateId;

	/// <summary>
	/// 事件产生道具类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType = itemType;

	/// <summary>
	/// 事件产生资源类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ResourceType = resourceType;

	/// <summary>
	/// 事件产生资源数量
	/// </summary>
	[SerializableGameDataField]
	public int ResourceCount = resourceCount;

	/// <summary>
	/// 招募人才等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte RecruitPeopleLevel = recruitPeopleLevel;

	/// <summary>
	/// 相应配置表id
	/// </summary>
	[SerializableGameDataField]
	public short EventConfigId = eventConfigId;

	/// <summary>
	/// 事件描述类型，用来显示多语言
	/// </summary>
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

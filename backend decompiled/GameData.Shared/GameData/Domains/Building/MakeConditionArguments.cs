using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Building;

public struct MakeConditionArguments : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	[SerializableGameDataField]
	public ItemKey ToolKey;

	[SerializableGameDataField]
	public ItemKey MaterialKey;

	[SerializableGameDataField]
	public short MakeCount;

	[SerializableGameDataField]
	public ResourceInts ResourceCount;

	[SerializableGameDataField]
	public short MakeItemTypeId;

	[SerializableGameDataField]
	public short MakeItemSubTypeId;

	[SerializableGameDataField]
	public bool IsManual;

	[SerializableGameDataField]
	public bool IsPerfect;

	[SerializableGameDataField]
	public short ManulFoodTemplateId;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 70;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		pCurrData += ToolKey.Serialize(pCurrData);
		pCurrData += MaterialKey.Serialize(pCurrData);
		*(short*)pCurrData = MakeCount;
		pCurrData += 2;
		pCurrData += ResourceCount.Serialize(pCurrData);
		*(short*)pCurrData = MakeItemTypeId;
		pCurrData += 2;
		*(short*)pCurrData = MakeItemSubTypeId;
		pCurrData += 2;
		*pCurrData = (IsManual ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsPerfect ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = ManulFoodTemplateId;
		pCurrData += 2;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		pCurrData += ToolKey.Deserialize(pCurrData);
		pCurrData += MaterialKey.Deserialize(pCurrData);
		MakeCount = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += ResourceCount.Deserialize(pCurrData);
		MakeItemTypeId = *(short*)pCurrData;
		pCurrData += 2;
		MakeItemSubTypeId = *(short*)pCurrData;
		pCurrData += 2;
		IsManual = *pCurrData != 0;
		pCurrData++;
		IsPerfect = *pCurrData != 0;
		pCurrData++;
		ManulFoodTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

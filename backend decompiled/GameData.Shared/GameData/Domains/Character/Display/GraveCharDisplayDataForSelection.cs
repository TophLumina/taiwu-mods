using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class GraveCharDisplayDataForSelection : ISerializableGameData, ISelectCharacterData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public short OrgSettlementId;

	[SerializableGameDataField]
	public bool Principal;

	[SerializableGameDataField]
	public sbyte Level;

	[SerializableGameDataField]
	public short Durability;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList Data;

	[SerializableGameDataField]
	public int DeadAt;

	int ISelectCharacterData.CharacterId => Data?.CharacterId ?? (-1);

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return Data;
	}

	public GraveCharDisplayDataForSelection()
	{
	}

	public GraveCharDisplayDataForSelection(GraveCharDisplayDataForSelection other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		NameData = other.NameData;
		OrgSettlementId = other.OrgSettlementId;
		Principal = other.Principal;
		Level = other.Level;
		Durability = other.Durability;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		Location = other.Location;
		Data = new CharacterDisplayDataForGeneralScrollList(other.Data);
		DeadAt = other.DeadAt;
	}

	public void Assign(GraveCharDisplayDataForSelection other)
	{
		Id = other.Id;
		TemplateId = other.TemplateId;
		NameData = other.NameData;
		OrgSettlementId = other.OrgSettlementId;
		Principal = other.Principal;
		Level = other.Level;
		Durability = other.Durability;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		Location = other.Location;
		Data = new CharacterDisplayDataForGeneralScrollList(other.Data);
		DeadAt = other.DeadAt;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 54;
		totalSize = ((Data == null) ? (totalSize + 2) : (totalSize + (2 + Data.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		pCurrData += NameData.Serialize(pCurrData);
		*(short*)pCurrData = OrgSettlementId;
		pCurrData += 2;
		*pCurrData = (Principal ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)Level;
		pCurrData++;
		*(short*)pCurrData = Durability;
		pCurrData += 2;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		if (Data != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Data.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = DeadAt;
		pCurrData += 4;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += NameData.Deserialize(pCurrData);
		OrgSettlementId = *(short*)pCurrData;
		pCurrData += 2;
		Principal = *pCurrData != 0;
		pCurrData++;
		Level = (sbyte)(*pCurrData);
		pCurrData++;
		Durability = *(short*)pCurrData;
		pCurrData += 2;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += Location.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (Data == null)
			{
				Data = new CharacterDisplayDataForGeneralScrollList();
			}
			pCurrData += Data.Deserialize(pCurrData);
		}
		else
		{
			Data = null;
		}
		DeadAt = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

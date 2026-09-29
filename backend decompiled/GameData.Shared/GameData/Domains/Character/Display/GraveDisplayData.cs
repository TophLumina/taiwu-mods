using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class GraveDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short OrgTemplateId;

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
	public bool IsSearchedCharacter;

	public short TemplateId => NameData.CharTemplateId;

	public GraveDisplayData()
	{
	}

	public GraveDisplayData(GraveDisplayData other)
	{
		Id = other.Id;
		OrgTemplateId = other.OrgTemplateId;
		NameData = other.NameData;
		OrgSettlementId = other.OrgSettlementId;
		Principal = other.Principal;
		Level = other.Level;
		Durability = other.Durability;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		Location = other.Location;
		IsSearchedCharacter = other.IsSearchedCharacter;
	}

	public void Assign(GraveDisplayData other)
	{
		Id = other.Id;
		OrgTemplateId = other.OrgTemplateId;
		NameData = other.NameData;
		OrgSettlementId = other.OrgSettlementId;
		Principal = other.Principal;
		Level = other.Level;
		Durability = other.Durability;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		Location = other.Location;
		IsSearchedCharacter = other.IsSearchedCharacter;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 51;
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
		*(short*)pCurrData = OrgTemplateId;
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
		*pCurrData = (IsSearchedCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		OrgTemplateId = *(short*)pCurrData;
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
		IsSearchedCharacter = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

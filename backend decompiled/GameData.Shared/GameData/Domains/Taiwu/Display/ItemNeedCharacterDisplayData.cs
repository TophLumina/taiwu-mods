using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotForArchive = true)]
public class ItemNeedCharacterDisplayData : ISerializableGameData, ISelectCharacterData, IVillagerSelectCharacterData
{
	[SerializableGameDataField]
	public int CharacterId;

	[SerializableGameDataField]
	public int CharacterTemplateId;

	[SerializableGameDataField]
	public FullName FullName;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public int TakeTime;

	[SerializableGameDataField]
	public int TakeAmount;

	[SerializableGameDataField]
	public short FavorabilityToTaiwu;

	[SerializableGameDataField]
	public bool IsInteractedWithTaiwu;

	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	[SerializableGameDataField]
	public short RoleTemplateId;

	[SerializableGameDataField]
	public int PowerLevel;

	[SerializableGameDataField]
	public bool IsCompanion;

	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList GeneralScrollListData;

	int ISelectCharacterData.CharacterId => CharacterId;

	sbyte IVillagerSelectCharacterData.WorkType => -1;

	byte IVillagerSelectCharacterData.WorkStatus => 0;

	int IVillagerSelectCharacterData.ArrangementTemplateId => -1;

	int IVillagerSelectCharacterData.BuildingBlockTemplateId => -1;

	bool IVillagerSelectCharacterData.IsBuyOperation => false;

	int IVillagerSelectCharacterData.GraveId => -1;

	int IVillagerSelectCharacterData.SwordTombId => -1;

	int IVillagerSelectCharacterData.RoleTemplateId => RoleTemplateId;

	public ItemNeedCharacterDisplayData()
	{
	}

	public ItemNeedCharacterDisplayData(ItemNeedCharacterDisplayData other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		FullName = other.FullName;
		NameData = other.NameData;
		Health = other.Health;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		CreatingType = other.CreatingType;
		TakeTime = other.TakeTime;
		TakeAmount = other.TakeAmount;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		PowerLevel = other.PowerLevel;
		IsCompanion = other.IsCompanion;
		GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList(other.GeneralScrollListData);
	}

	public void Assign(ItemNeedCharacterDisplayData other)
	{
		CharacterId = other.CharacterId;
		CharacterTemplateId = other.CharacterTemplateId;
		FullName = other.FullName;
		NameData = other.NameData;
		Health = other.Health;
		AvatarRelatedData = new AvatarRelatedData(other.AvatarRelatedData);
		CreatingType = other.CreatingType;
		TakeTime = other.TakeTime;
		TakeAmount = other.TakeAmount;
		FavorabilityToTaiwu = other.FavorabilityToTaiwu;
		IsInteractedWithTaiwu = other.IsInteractedWithTaiwu;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		PowerLevel = other.PowerLevel;
		IsCompanion = other.IsCompanion;
		GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList(other.GeneralScrollListData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 75;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
		totalSize = ((GeneralScrollListData == null) ? (totalSize + 2) : (totalSize + (2 + GeneralScrollListData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(int*)pCurrData = CharacterTemplateId;
		pCurrData += 4;
		pCurrData += FullName.Serialize(pCurrData);
		pCurrData += NameData.Serialize(pCurrData);
		*(short*)pCurrData = Health;
		pCurrData += 2;
		if (AvatarRelatedData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarRelatedData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = CreatingType;
		pCurrData++;
		*(int*)pCurrData = TakeTime;
		pCurrData += 4;
		*(int*)pCurrData = TakeAmount;
		pCurrData += 4;
		*(short*)pCurrData = FavorabilityToTaiwu;
		pCurrData += 2;
		*pCurrData = (IsInteractedWithTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		*(int*)pCurrData = PowerLevel;
		pCurrData += 4;
		*pCurrData = (IsCompanion ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (GeneralScrollListData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = GeneralScrollListData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		CharacterTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += FullName.Deserialize(pCurrData);
		pCurrData += NameData.Deserialize(pCurrData);
		Health = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarRelatedData == null)
			{
				AvatarRelatedData = new AvatarRelatedData();
			}
			pCurrData += AvatarRelatedData.Deserialize(pCurrData);
		}
		else
		{
			AvatarRelatedData = null;
		}
		CreatingType = *pCurrData;
		pCurrData++;
		TakeTime = *(int*)pCurrData;
		pCurrData += 4;
		TakeAmount = *(int*)pCurrData;
		pCurrData += 4;
		FavorabilityToTaiwu = *(short*)pCurrData;
		pCurrData += 2;
		IsInteractedWithTaiwu = *pCurrData != 0;
		pCurrData++;
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		PowerLevel = *(int*)pCurrData;
		pCurrData += 4;
		IsCompanion = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (GeneralScrollListData == null)
			{
				GeneralScrollListData = new CharacterDisplayDataForGeneralScrollList();
			}
			pCurrData += GeneralScrollListData.Deserialize(pCurrData);
		}
		else
		{
			GeneralScrollListData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	CharacterDisplayDataForGeneralScrollList ISelectCharacterData.GetGeneralScrollListData()
	{
		return GeneralScrollListData;
	}
}

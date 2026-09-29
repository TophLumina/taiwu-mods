using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData]
public class CharacterDisplayDataForSettlementPrisoner : ISerializableGameData
{
	[SerializableGameDataField]
	public SettlementPrisoner SettlementPrisoner;

	[SerializableGameDataField]
	public int Resistance;

	[SerializableGameDataField]
	public int EscapeRate;

	[SerializableGameDataField]
	public short RandomNameId = -1;

	[SerializableGameDataField]
	public bool CompletelyInfected;

	[SerializableGameDataField]
	public bool OwningBook;

	[SerializableGameDataField]
	public KidnapCharDisplayData KidnapCharDisplayData;

	public PrisonType PrisonType
	{
		get
		{
			if (SettlementPrisoner.PunishmentSeverity == 0)
			{
				return PrisonType.Invalid;
			}
			if (SettlementPrisoner.PunishmentType == 40)
			{
				return PrisonType.Infected;
			}
			return (PrisonType)(KidnapCharDisplayData.OrganizationInfo.Grade / 3);
		}
	}

	public CharacterDisplayDataForSettlementPrisoner()
	{
	}

	public CharacterDisplayDataForSettlementPrisoner(CharacterDisplayDataForSettlementPrisoner other)
	{
		SettlementPrisoner = new SettlementPrisoner(other.SettlementPrisoner);
		Resistance = other.Resistance;
		EscapeRate = other.EscapeRate;
		RandomNameId = other.RandomNameId;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
		KidnapCharDisplayData = new KidnapCharDisplayData(other.KidnapCharDisplayData);
	}

	public void Assign(CharacterDisplayDataForSettlementPrisoner other)
	{
		SettlementPrisoner = new SettlementPrisoner(other.SettlementPrisoner);
		Resistance = other.Resistance;
		EscapeRate = other.EscapeRate;
		RandomNameId = other.RandomNameId;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
		KidnapCharDisplayData = new KidnapCharDisplayData(other.KidnapCharDisplayData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((SettlementPrisoner == null) ? (totalSize + 2) : (totalSize + (2 + SettlementPrisoner.GetSerializedSize())));
		totalSize = ((KidnapCharDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + KidnapCharDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SettlementPrisoner != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SettlementPrisoner.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = Resistance;
		pCurrData += 4;
		*(int*)pCurrData = EscapeRate;
		pCurrData += 4;
		*(short*)pCurrData = RandomNameId;
		pCurrData += 2;
		*pCurrData = (CompletelyInfected ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (OwningBook ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (KidnapCharDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = KidnapCharDisplayData.Serialize(pCurrData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			SettlementPrisoner = new SettlementPrisoner();
			pCurrData += SettlementPrisoner.Deserialize(pCurrData);
		}
		else
		{
			SettlementPrisoner = null;
		}
		Resistance = *(int*)pCurrData;
		pCurrData += 4;
		EscapeRate = *(int*)pCurrData;
		pCurrData += 4;
		RandomNameId = *(short*)pCurrData;
		pCurrData += 2;
		CompletelyInfected = *pCurrData != 0;
		pCurrData++;
		OwningBook = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			KidnapCharDisplayData = new KidnapCharDisplayData();
			pCurrData += KidnapCharDisplayData.Deserialize(pCurrData);
		}
		else
		{
			KidnapCharDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Organization;

[SerializableGameData(IsExtensible = true)]
public class SettlementPrisoner : KidnappedCharacter, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Duration = 0;

		public const ushort PunishmentType = 1;

		public const ushort PunishmentSeverity = 2;

		public const ushort CharId = 3;

		public const ushort RopeItemKey = 4;

		public const ushort KidnapBeginDate = 5;

		public const ushort Resistance = 6;

		public const ushort InitialMorality = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "Duration", "PunishmentType", "PunishmentSeverity", "CharId", "RopeItemKey", "KidnapBeginDate", "Resistance", "InitialMorality" };
	}

	[SerializableGameDataField]
	public int Duration;

	[SerializableGameDataField]
	public short PunishmentType;

	[SerializableGameDataField]
	public sbyte PunishmentSeverity;

	[SerializableGameDataField]
	public short InitialMorality;

	[SerializableGameDataField]
	public int SpouseCharId = -1;

	public SettlementPrisoner()
	{
	}

	public SettlementPrisoner(SettlementPrisoner other)
	{
		Duration = other.Duration;
		PunishmentType = other.PunishmentType;
		PunishmentSeverity = other.PunishmentSeverity;
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
		InitialMorality = other.InitialMorality;
	}

	public void Assign(SettlementPrisoner other)
	{
		Duration = other.Duration;
		PunishmentType = other.PunishmentType;
		PunishmentSeverity = other.PunishmentSeverity;
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
		InitialMorality = other.InitialMorality;
	}

	public new bool IsSerializedSizeFixed()
	{
		return false;
	}

	public new int GetSerializedSize()
	{
		int totalSize = 28;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public new unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(int*)pCurrData = Duration;
		pCurrData += 4;
		*(short*)pCurrData = PunishmentType;
		pCurrData += 2;
		*pCurrData = (byte)PunishmentSeverity;
		pCurrData++;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += RopeItemKey.Serialize(pCurrData);
		*(int*)pCurrData = KidnapBeginDate;
		pCurrData += 4;
		*pCurrData = (byte)ExtraResistance;
		pCurrData++;
		*(short*)pCurrData = InitialMorality;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public new unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Duration = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			PunishmentType = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			PunishmentSeverity = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 4)
		{
			pCurrData += RopeItemKey.Deserialize(pCurrData);
		}
		if (num > 5)
		{
			KidnapBeginDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 6)
		{
			ExtraResistance = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 7)
		{
			InitialMorality = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

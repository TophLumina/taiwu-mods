using GameData.Serializer;

namespace GameData.Domains.Organization;

[SerializableGameData(IsExtensible = true)]
public class SettlementBounty : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharId = 0;

		public const ushort BountyAmount = 1;

		public const ushort PunishmentType = 2;

		public const ushort PunishmentSeverity = 3;

		public const ushort ExpireDate = 4;

		public const ushort RequiredConsummateLevel = 5;

		public const ushort CurrentHunterId = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "CharId", "BountyAmount", "PunishmentType", "PunishmentSeverity", "ExpireDate", "RequiredConsummateLevel", "CurrentHunterId" };
	}

	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public int BountyAmount;

	[SerializableGameDataField]
	public short PunishmentType;

	[SerializableGameDataField]
	public sbyte PunishmentSeverity;

	[SerializableGameDataField]
	public int ExpireDate;

	[SerializableGameDataField]
	public sbyte RequiredConsummateLevel = -1;

	[SerializableGameDataField]
	public int CurrentHunterId = -1;

	public short CaptorFameActionMultiplier => (short)(PunishmentSeverity * 10);

	public SettlementBounty()
	{
	}

	public SettlementBounty(SettlementBounty other)
	{
		CharId = other.CharId;
		BountyAmount = other.BountyAmount;
		PunishmentType = other.PunishmentType;
		PunishmentSeverity = other.PunishmentSeverity;
		ExpireDate = other.ExpireDate;
		RequiredConsummateLevel = other.RequiredConsummateLevel;
		CurrentHunterId = other.CurrentHunterId;
	}

	public void Assign(SettlementBounty other)
	{
		CharId = other.CharId;
		BountyAmount = other.BountyAmount;
		PunishmentType = other.PunishmentType;
		PunishmentSeverity = other.PunishmentSeverity;
		ExpireDate = other.ExpireDate;
		RequiredConsummateLevel = other.RequiredConsummateLevel;
		CurrentHunterId = other.CurrentHunterId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 7;
		byte* num = pData + 2;
		*(int*)num = CharId;
		byte* num2 = num + 4;
		*(int*)num2 = BountyAmount;
		byte* num3 = num2 + 4;
		*(short*)num3 = PunishmentType;
		byte* num4 = num3 + 2;
		*num4 = (byte)PunishmentSeverity;
		byte* num5 = num4 + 1;
		*(int*)num5 = ExpireDate;
		byte* num6 = num5 + 4;
		*num6 = (byte)RequiredConsummateLevel;
		byte* num7 = num6 + 1;
		*(int*)num7 = CurrentHunterId;
		int totalSize = (int)(num7 + 4 - pData);
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
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			BountyAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			PunishmentType = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 3)
		{
			PunishmentSeverity = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			ExpireDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			RequiredConsummateLevel = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 6)
		{
			CurrentHunterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

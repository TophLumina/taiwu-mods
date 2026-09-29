using System;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, IsExtensible = true)]
public class PunishmentSeverityCustomizeData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort PunishmentTypeTemplateId = 0;

		public const ushort CustomizedPunishmentSeverityTemplateId = 1;

		public const ushort ModifyDate = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "PunishmentTypeTemplateId", "CustomizedPunishmentSeverityTemplateId", "ModifyDate" };
	}

	[SerializableGameDataField]
	public short PunishmentTypeTemplateId;

	[SerializableGameDataField]
	public sbyte CustomizedPunishmentSeverityTemplateId;

	[SerializableGameDataField]
	public int ModifyDate;

	public int ModificationDiff(sbyte stateTemplateId, bool isSect)
	{
		return Math.Abs(PunishmentType.Instance[PunishmentTypeTemplateId].GetSeverity(stateTemplateId, isSect) - CustomizedPunishmentSeverityTemplateId);
	}

	public int ModificationDiff(short key)
	{
		var (stateTemplateId, isSect) = DecodePunishmentSeverityCustomizeKey(key);
		return ModificationDiff(stateTemplateId, isSect);
	}

	public static short GetPunishmentSeverityCustomizeKey(sbyte stateTemplateId, bool isSect)
	{
		return (short)(((isSect ? 1u : 0u) << 8) | (byte)stateTemplateId);
	}

	public static (sbyte stateTemplateId, bool isSect) DecodePunishmentSeverityCustomizeKey(short key)
	{
		ushort value = (ushort)key;
		sbyte stateTemplateId = (sbyte)BitOperation.GetSubUshort(value, 0, 8);
		bool isSect = BitOperation.GetSubUshort(value, 8, 8) == 1;
		return (stateTemplateId: stateTemplateId, isSect: isSect);
	}

	public PunishmentSeverityCustomizeData()
	{
	}

	public PunishmentSeverityCustomizeData(PunishmentSeverityCustomizeData other)
	{
		PunishmentTypeTemplateId = other.PunishmentTypeTemplateId;
		CustomizedPunishmentSeverityTemplateId = other.CustomizedPunishmentSeverityTemplateId;
		ModifyDate = other.ModifyDate;
	}

	public void Assign(PunishmentSeverityCustomizeData other)
	{
		PunishmentTypeTemplateId = other.PunishmentTypeTemplateId;
		CustomizedPunishmentSeverityTemplateId = other.CustomizedPunishmentSeverityTemplateId;
		ModifyDate = other.ModifyDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*(short*)num = PunishmentTypeTemplateId;
		byte* num2 = num + 2;
		*num2 = (byte)CustomizedPunishmentSeverityTemplateId;
		byte* num3 = num2 + 1;
		*(int*)num3 = ModifyDate;
		int totalSize = (int)(num3 + 4 - pData);
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
			PunishmentTypeTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			CustomizedPunishmentSeverityTemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			ModifyDate = *(int*)pCurrData;
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

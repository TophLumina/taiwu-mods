using System;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization.Display;

/// <summary>
/// 自定义的州域罪行程度数据
/// </summary>
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

	/// <summary>
	/// 类型
	/// </summary>
	[SerializableGameDataField]
	public short PunishmentTypeTemplateId;

	/// <summary>
	/// 自定义的罪行等级
	/// </summary>
	[SerializableGameDataField]
	public sbyte CustomizedPunishmentSeverityTemplateId;

	/// <summary>
	/// 修改时间
	/// </summary>
	[SerializableGameDataField]
	public int ModifyDate;

	/// <summary>
	/// 当前的修改范围
	/// </summary>
	public int ModificationDiff(sbyte stateTemplateId, bool isSect)
	{
		return Math.Abs(PunishmentType.Instance[PunishmentTypeTemplateId].GetSeverity(stateTemplateId, isSect) - CustomizedPunishmentSeverityTemplateId);
	}

	public int ModificationDiff(short key)
	{
		var (stateTemplateId, isSect) = DecodePunishmentSeverityCustomizeKey(key);
		return ModificationDiff(stateTemplateId, isSect);
	}

	/// <summary>
	/// 将 州域模板ID 和 是否为门派 转化为 Key
	/// </summary>
	public static short GetPunishmentSeverityCustomizeKey(sbyte stateTemplateId, bool isSect)
	{
		return (short)(((isSect ? 1u : 0u) << 8) | (byte)stateTemplateId);
	}

	/// <summary>
	/// 将 Key 转化为 州域模板ID 和 是否为门派
	/// </summary>
	public static (sbyte stateTemplateId, bool isSect) DecodePunishmentSeverityCustomizeKey(short key)
	{
		ushort value = (ushort)key;
		sbyte stateTemplateId = (sbyte)BitOperation.GetSubUshort(value, 0, 8);
		bool isSect = BitOperation.GetSubUshort(value, 8, 8) == 1;
		return (stateTemplateId: stateTemplateId, isSect: isSect);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public PunishmentSeverityCustomizeData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public PunishmentSeverityCustomizeData(PunishmentSeverityCustomizeData other)
	{
		PunishmentTypeTemplateId = other.PunishmentTypeTemplateId;
		CustomizedPunishmentSeverityTemplateId = other.CustomizedPunishmentSeverityTemplateId;
		ModifyDate = other.ModifyDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(PunishmentSeverityCustomizeData other)
	{
		PunishmentTypeTemplateId = other.PunishmentTypeTemplateId;
		CustomizedPunishmentSeverityTemplateId = other.CustomizedPunishmentSeverityTemplateId;
		ModifyDate = other.ModifyDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

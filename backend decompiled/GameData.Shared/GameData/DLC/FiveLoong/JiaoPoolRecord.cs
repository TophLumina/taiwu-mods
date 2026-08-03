using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 蛟池日志数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class JiaoPoolRecord : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort RecordTemplateId = 0;

		public const ushort Jiao1Id = 1;

		public const ushort Jiao2Id = 2;

		public const ushort TemplateId = 3;

		public const ushort PropertyChangeVolume = 4;

		public const ushort NurturanceTemplateId = 5;

		public const ushort Date = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "RecordTemplateId", "Jiao1Id", "Jiao2Id", "TemplateId", "PropertyChangeVolume", "NurturanceTemplateId", "Date" };
	}

	/// <summary>
	/// 类型
	/// </summary>
	[SerializableGameDataField]
	public short RecordTemplateId;

	/// <summary>
	/// 蛟1的Id
	/// </summary>
	[SerializableGameDataField]
	public int Jiao1Id;

	/// <summary>
	/// 蛟2的Id
	/// </summary>
	[SerializableGameDataField]
	public int Jiao2Id;

	/// <summary>
	/// 养育方针Id
	/// </summary>
	[SerializableGameDataField]
	public short NurturanceTemplateId;

	/// <summary>
	/// 模板Id
	/// 属性、物品Id
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 变化量
	/// </summary>
	[SerializableGameDataField]
	public int PropertyChangeVolume;

	/// <summary>
	/// 变化量
	/// </summary>
	[SerializableGameDataField]
	public int Date;

	public JiaoPoolRecord()
	{
	}

	public JiaoPoolRecord(short recordId, int id1)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = -1;
		NurturanceTemplateId = -1;
		TemplateId = -1;
		PropertyChangeVolume = -1;
	}

	public JiaoPoolRecord(short recordId, int id1, int value)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = -1;
		NurturanceTemplateId = -1;
		TemplateId = -1;
		PropertyChangeVolume = value;
	}

	public JiaoPoolRecord(short recordId, int id1, short templateId)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = -1;
		NurturanceTemplateId = -1;
		TemplateId = templateId;
		PropertyChangeVolume = -1;
	}

	public JiaoPoolRecord(short recordId, int id1, short templateId, int value)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = -1;
		NurturanceTemplateId = -1;
		TemplateId = templateId;
		PropertyChangeVolume = value;
	}

	public JiaoPoolRecord(short recordId, int id1, int id2, short templateId)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = id2;
		NurturanceTemplateId = -1;
		TemplateId = templateId;
		PropertyChangeVolume = -1;
	}

	public JiaoPoolRecord(short recordId, int id1, short nurturanceTemplateId, short templateId, int value)
	{
		RecordTemplateId = recordId;
		Jiao1Id = id1;
		Jiao2Id = -1;
		NurturanceTemplateId = nurturanceTemplateId;
		TemplateId = templateId;
		PropertyChangeVolume = value;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 24;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 7;
		byte* num = pData + 2;
		*(short*)num = RecordTemplateId;
		byte* num2 = num + 2;
		*(int*)num2 = Jiao1Id;
		byte* num3 = num2 + 4;
		*(int*)num3 = Jiao2Id;
		byte* num4 = num3 + 4;
		*(short*)num4 = TemplateId;
		byte* num5 = num4 + 2;
		*(int*)num5 = PropertyChangeVolume;
		byte* num6 = num5 + 4;
		*(short*)num6 = NurturanceTemplateId;
		byte* num7 = num6 + 2;
		*(int*)num7 = Date;
		int totalSize = (int)(num7 + 4 - pData);
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
			RecordTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			Jiao1Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			Jiao2Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 4)
		{
			PropertyChangeVolume = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			NurturanceTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 6)
		{
			Date = *(int*)pCurrData;
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

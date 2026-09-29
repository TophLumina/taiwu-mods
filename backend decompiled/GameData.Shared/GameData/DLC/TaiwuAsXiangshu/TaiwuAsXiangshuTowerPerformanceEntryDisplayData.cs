using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.TaiwuAsXiangshu;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuAsXiangshuTowerPerformanceEntryDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharacterTemplateId = 0;

		public const ushort Status = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CharacterTemplateId", "Status" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short CharacterTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public ETwelveImmortalsStatus Status;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*(short*)num = CharacterTemplateId;
		byte* num2 = num + 2;
		*num2 = (byte)Status;
		int totalSize = (int)(num2 + 1 - pData);
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
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			Status = (ETwelveImmortalsStatus)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.TaiwuAsXiangshu;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuAsXiangshuTowerTwelveImmortalDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharacterTemplateId = 0;

		public const ushort Status = 1;

		public const ushort NameRelatedData = 2;

		public const ushort LocationNameRelatedData = 3;

		public const ushort CharacterId = 4;

		public const ushort CharacterTipData = 5;

		public const ushort TwelveImmortalTemplateId = 6;

		public const ushort SwordFragmentTemplateId = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "CharacterTemplateId", "Status", "NameRelatedData", "LocationNameRelatedData", "CharacterId", "CharacterTipData", "TwelveImmortalTemplateId", "SwordFragmentTemplateId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short CharacterTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public ETwelveImmortalsStatus Status;

	[SerializableGameDataField(FieldIndex = 2)]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField(FieldIndex = 3)]
	public LocationNameRelatedData LocationNameRelatedData;

	[SerializableGameDataField(FieldIndex = 4)]
	public int CharacterId = -1;

	[SerializableGameDataField(FieldIndex = 5)]
	public CharacterDisplayDataForMapBlock CharacterTipData;

	[SerializableGameDataField(FieldIndex = 6)]
	public sbyte TwelveImmortalTemplateId;

	[SerializableGameDataField(FieldIndex = 7)]
	public short SwordFragmentTemplateId = -1;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 52;
		totalSize = ((CharacterTipData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterTipData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)Status;
		pCurrData++;
		pCurrData += NameRelatedData.Serialize(pCurrData);
		pCurrData += LocationNameRelatedData.Serialize(pCurrData);
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		if (CharacterTipData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterTipData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)TwelveImmortalTemplateId;
		pCurrData++;
		*(short*)pCurrData = SwordFragmentTemplateId;
		pCurrData += 2;
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
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			Status = (ETwelveImmortalsStatus)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			pCurrData += NameRelatedData.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			pCurrData += LocationNameRelatedData.Deserialize(pCurrData);
		}
		if (num > 4)
		{
			CharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				CharacterTipData = new CharacterDisplayDataForMapBlock();
				pCurrData += CharacterTipData.Deserialize(pCurrData);
			}
			else
			{
				CharacterTipData = null;
			}
		}
		if (num > 6)
		{
			TwelveImmortalTemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 7)
		{
			SwordFragmentTemplateId = *(short*)pCurrData;
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

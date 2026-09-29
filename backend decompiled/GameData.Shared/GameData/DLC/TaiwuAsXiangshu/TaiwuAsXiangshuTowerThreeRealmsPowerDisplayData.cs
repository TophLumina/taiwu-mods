using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.TaiwuAsXiangshu;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharacterTemplateId = 0;

		public const ushort IsObtained = 1;

		public const ushort IsKilled = 2;

		public const ushort AvatarRelatedData = 3;

		public const ushort NameRelatedData = 4;

		public const ushort LocationNameRelatedData = 5;

		public const ushort CharacterId = 6;

		public const ushort CharacterTipData = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "CharacterTemplateId", "IsObtained", "IsKilled", "AvatarRelatedData", "NameRelatedData", "LocationNameRelatedData", "CharacterId", "CharacterTipData" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short CharacterTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool IsObtained;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool IsKilled;

	[SerializableGameDataField(FieldIndex = 3)]
	public AvatarRelatedData AvatarRelatedData;

	[SerializableGameDataField(FieldIndex = 4)]
	public NameRelatedData NameRelatedData;

	[SerializableGameDataField(FieldIndex = 5)]
	public LocationNameRelatedData LocationNameRelatedData;

	[SerializableGameDataField(FieldIndex = 6)]
	public int CharacterId = -1;

	[SerializableGameDataField(FieldIndex = 7)]
	public CharacterDisplayDataForMapBlock CharacterTipData;

	public short GetPowerCharacterTemplateId()
	{
		return TaiwuAsXiangshuTowerPerformanceHelper.GetPowerCharacterTemplateId(CharacterTemplateId);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 50;
		totalSize = ((AvatarRelatedData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarRelatedData.GetSerializedSize())));
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
		*pCurrData = (IsObtained ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsKilled ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		pCurrData += NameRelatedData.Serialize(pCurrData);
		pCurrData += LocationNameRelatedData.Serialize(pCurrData);
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		if (CharacterTipData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = CharacterTipData.Serialize(pCurrData);
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
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			IsObtained = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			IsKilled = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				AvatarRelatedData = new AvatarRelatedData();
				pCurrData += AvatarRelatedData.Deserialize(pCurrData);
			}
			else
			{
				AvatarRelatedData = null;
			}
		}
		if (num > 4)
		{
			pCurrData += NameRelatedData.Deserialize(pCurrData);
		}
		if (num > 5)
		{
			pCurrData += LocationNameRelatedData.Deserialize(pCurrData);
		}
		if (num > 6)
		{
			CharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 7)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				CharacterTipData = new CharacterDisplayDataForMapBlock();
				pCurrData += CharacterTipData.Deserialize(pCurrData);
			}
			else
			{
				CharacterTipData = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

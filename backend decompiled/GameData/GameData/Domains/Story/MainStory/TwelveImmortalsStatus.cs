using GameData.Serializer;

namespace GameData.Domains.Story.MainStory;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class TwelveImmortalsStatus : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Progress = 0;

		public const ushort CharacterId = 1;

		public const ushort AssistCharacterTemplateId = 2;

		public const ushort AssistState = 3;

		public const ushort AlreadyIntoImpactRange = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "Progress", "CharacterId", "AssistCharacterTemplateId", "AssistState", "AlreadyIntoImpactRange" };
	}

	[SerializableGameDataField]
	public sbyte Progress = 0;

	[SerializableGameDataField]
	public int CharacterId = -1;

	[SerializableGameDataField]
	public short AssistCharacterTemplateId = -1;

	[SerializableGameDataField]
	public sbyte AssistState = 0;

	[SerializableGameDataField]
	public bool AlreadyIntoImpactRange;

	public TwelveImmortalsStatus()
	{
	}

	public TwelveImmortalsStatus(TwelveImmortalsStatus other)
	{
		Progress = other.Progress;
		CharacterId = other.CharacterId;
		AssistCharacterTemplateId = other.AssistCharacterTemplateId;
		AssistState = other.AssistState;
		AlreadyIntoImpactRange = other.AlreadyIntoImpactRange;
	}

	public void Assign(TwelveImmortalsStatus other)
	{
		Progress = other.Progress;
		CharacterId = other.CharacterId;
		AssistCharacterTemplateId = other.AssistCharacterTemplateId;
		AssistState = other.AssistState;
		AlreadyIntoImpactRange = other.AlreadyIntoImpactRange;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		*pCurrData = (byte)Progress;
		pCurrData++;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = AssistCharacterTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)AssistState;
		pCurrData++;
		*pCurrData = (AlreadyIntoImpactRange ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			Progress = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 1)
		{
			CharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			AssistCharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 3)
		{
			AssistState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			AlreadyIntoImpactRange = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

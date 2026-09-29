using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.TaiwuEvent.EventOption;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class EventBoolStateInfo : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort EventBoolStateTemplateId = 0;

		public const ushort BoolState = 1;

		public const ushort RemoveBeforeNextEvent = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "EventBoolStateTemplateId", "BoolState", "RemoveBeforeNextEvent" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short EventBoolStateTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool BoolState;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool RemoveBeforeNextEvent;

	public EventBoolStateInfo()
	{
	}

	public EventBoolStateInfo(EventBoolStateInfo other)
	{
		EventBoolStateTemplateId = other.EventBoolStateTemplateId;
		BoolState = other.BoolState;
		RemoveBeforeNextEvent = other.RemoveBeforeNextEvent;
	}

	public void Assign(EventBoolStateInfo other)
	{
		EventBoolStateTemplateId = other.EventBoolStateTemplateId;
		BoolState = other.BoolState;
		RemoveBeforeNextEvent = other.RemoveBeforeNextEvent;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*(short*)num = EventBoolStateTemplateId;
		byte* num2 = num + 2;
		*num2 = (BoolState ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (RemoveBeforeNextEvent ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num3 + 1 - pData);
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
			EventBoolStateTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			BoolState = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			RemoveBeforeNextEvent = *pCurrData != 0;
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

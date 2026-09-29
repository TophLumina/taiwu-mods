using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true)]
public class Animal : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort ItemKey = 1;

		public const ushort CharacterTemplateId = 2;

		public const ushort Location = 3;

		public const ushort Type = 4;

		public const ushort NoAccident = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "Id", "ItemKey", "CharacterTemplateId", "Location", "Type", "NoAccident" };
	}

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public ItemKey ItemKey;

	[SerializableGameDataField]
	public short CharacterTemplateId;

	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public sbyte Type;

	[SerializableGameDataField]
	public bool NoAccident;

	public Animal()
	{
		Id = -1;
		ItemKey = ItemKey.Invalid;
		CharacterTemplateId = -1;
		Location = Location.Invalid;
		Type = 0;
		NoAccident = false;
	}

	public Animal(int id, short templateId)
	{
		Id = id;
		ItemKey = ItemKey.Invalid;
		CharacterTemplateId = templateId;
		Location = Location.Invalid;
		Type = 0;
		NoAccident = false;
	}

	public Animal(int id, ItemKey itemKey, short templateId, sbyte type)
	{
		Id = id;
		ItemKey = itemKey;
		CharacterTemplateId = templateId;
		Location = Location.Invalid;
		Type = type;
		NoAccident = true;
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
		byte* pCurrData = pData;
		*(short*)pCurrData = 6;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		pCurrData += ItemKey.Serialize(pCurrData);
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (byte)Type;
		pCurrData++;
		*pCurrData = (NoAccident ? ((byte)1) : ((byte)0));
		pCurrData++;
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
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 3)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 4)
		{
			Type = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 5)
		{
			NoAccident = *pCurrData != 0;
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

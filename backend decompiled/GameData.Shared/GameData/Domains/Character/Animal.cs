using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 动物
/// </summary>
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

	/// <summary>
	/// Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// ItemKey
	/// 若是野生动物则为Invalid
	/// </summary>
	[SerializableGameDataField]
	public ItemKey ItemKey;

	/// <summary>
	/// 角色配置表的模板Id，用于前端显示和战斗
	/// </summary>
	[SerializableGameDataField]
	public short CharacterTemplateId;

	/// <summary>
	/// 位置
	/// 可能为Invalid，如已被抓回去的蛟
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 动物类型
	/// 用于在战斗结束后进行判断
	/// </summary>
	[SerializableGameDataField]
	public sbyte Type;

	/// <summary>
	/// 是否免于意外，仅与太吾（玩家）产生交互
	/// 如数量超出地格上限的随机抹杀、地格毁灭导致的抹杀、被路过npc杀死等等
	/// </summary>
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

	/// <summary>
	/// 生成普通的野生动物、龙
	/// </summary>
	/// <param name="id"></param>
	/// <param name="templateId"></param>
	public Animal(int id, short templateId)
	{
		Id = id;
		ItemKey = ItemKey.Invalid;
		CharacterTemplateId = templateId;
		Location = Location.Invalid;
		Type = 0;
		NoAccident = false;
	}

	/// <summary>
	/// 生成逃跑的代步、幼蛟
	/// </summary>
	/// <param name="id"></param>
	/// <param name="itemKey"></param>
	/// <param name="templateId"></param>
	/// <param name="type"></param>
	public Animal(int id, ItemKey itemKey, short templateId, sbyte type)
	{
		Id = id;
		ItemKey = itemKey;
		CharacterTemplateId = templateId;
		Location = Location.Invalid;
		Type = type;
		NoAccident = true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

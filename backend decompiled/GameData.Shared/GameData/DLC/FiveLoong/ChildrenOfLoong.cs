using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.DLC.FiveLoong;

/// <summary>
/// 五方神龙 - 龙的数据结构
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class ChildrenOfLoong : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Key = 0;

		public const ushort NameId = 1;

		public const ushort Behavior = 2;

		public const ushort Properties = 3;

		public const ushort Id = 4;

		public const ushort JiaoTemplateId = 5;

		public const ushort LoongTemplateId = 6;

		public const ushort Gender = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "Key", "NameId", "Behavior", "Properties", "Id", "JiaoTemplateId", "LoongTemplateId", "Gender" };
	}

	/// <summary>
	/// 蛟从卵开始使用的Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 物品Key
	/// </summary>
	[SerializableGameDataField]
	public ItemKey Key;

	/// <summary>
	/// 名字字符串的Id
	/// </summary>
	[SerializableGameDataField]
	public int NameId;

	/// <summary>
	/// 立场
	/// </summary>
	[SerializableGameDataField]
	public sbyte Behavior;

	/// <summary>
	/// 属性
	/// </summary>
	[SerializableGameDataField]
	public JiaoProperty Properties;

	/// <summary>
	/// 化龙前蛟的模板Id
	/// </summary>
	[SerializableGameDataField]
	public short JiaoTemplateId;

	/// <summary>
	/// 龙的模板Id
	/// </summary>
	[SerializableGameDataField]
	public short LoongTemplateId;

	/// <summary>
	/// 性别
	/// </summary>
	[SerializableGameDataField]
	public bool Gender;

	public ChildrenOfLoong()
	{
		Id = -1;
		Key = ItemKey.Invalid;
		NameId = -1;
		Behavior = -1;
		Properties = new JiaoProperty();
		JiaoTemplateId = 0;
		LoongTemplateId = 31;
		Gender = false;
	}

	public ChildrenOfLoong(int id, ItemKey key, sbyte behavior, short loongTemplateId, JiaoProperty properties)
	{
		Id = id;
		Key = key;
		NameId = -1;
		Behavior = behavior;
		Properties = properties;
		JiaoTemplateId = 0;
		LoongTemplateId = loongTemplateId;
		Gender = false;
	}

	public ChildrenOfLoong(Jiao jiao, ItemKey key, short loongTemplateId)
	{
		Id = jiao.Id;
		Key = key;
		NameId = jiao.NameId;
		Behavior = jiao.Behavior;
		Properties = new JiaoProperty();
		Properties.DeepCopy(jiao.Properties);
		JiaoTemplateId = jiao.TemplateId;
		LoongTemplateId = loongTemplateId;
		Gender = jiao.Gender;
	}

	public ChildrenOfLoong(ChildrenOfLoong childOfLoong, ItemKey key)
	{
		Id = key.Id;
		Key = key;
		NameId = childOfLoong.NameId;
		Behavior = childOfLoong.Behavior;
		Properties = new JiaoProperty();
		Properties.DeepCopy(childOfLoong.Properties);
		JiaoTemplateId = childOfLoong.JiaoTemplateId;
		LoongTemplateId = childOfLoong.LoongTemplateId;
		Gender = childOfLoong.Gender;
	}

	/// <summary>
	/// 获取名称
	/// </summary>
	/// <returns></returns>
	public string GetNameText()
	{
		return GetNameRelatedData().GetName();
	}

	/// <summary>
	/// 获取名称相关数据
	/// </summary>
	/// <returns></returns>
	public JiaoLoongNameRelatedData GetNameRelatedData()
	{
		return new JiaoLoongNameRelatedData
		{
			ItemType = Key.ItemType,
			ItemTemplateId = Key.TemplateId,
			NameId = NameId,
			CharTemplateId = -1
		};
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ChildrenOfLoong(ChildrenOfLoong other)
	{
		Key = other.Key;
		NameId = other.NameId;
		Behavior = other.Behavior;
		Properties = new JiaoProperty(other.Properties);
		Id = other.Id;
		JiaoTemplateId = other.JiaoTemplateId;
		LoongTemplateId = other.LoongTemplateId;
		Gender = other.Gender;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ChildrenOfLoong other)
	{
		Key = other.Key;
		NameId = other.NameId;
		Behavior = other.Behavior;
		Properties = new JiaoProperty(other.Properties);
		Id = other.Id;
		JiaoTemplateId = other.JiaoTemplateId;
		LoongTemplateId = other.LoongTemplateId;
		Gender = other.Gender;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 96;
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
		*(short*)pCurrData = 8;
		pCurrData += 2;
		pCurrData += Key.Serialize(pCurrData);
		*(int*)pCurrData = NameId;
		pCurrData += 4;
		*pCurrData = (byte)Behavior;
		pCurrData++;
		pCurrData += Properties.Serialize(pCurrData);
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = JiaoTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = LoongTemplateId;
		pCurrData += 2;
		*pCurrData = (Gender ? ((byte)1) : ((byte)0));
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
			pCurrData += Key.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			NameId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			Behavior = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			if (Properties == null)
			{
				Properties = new JiaoProperty();
			}
			pCurrData += Properties.Deserialize(pCurrData);
		}
		if (num > 4)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			JiaoTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 6)
		{
			LoongTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 7)
		{
			Gender = *pCurrData != 0;
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

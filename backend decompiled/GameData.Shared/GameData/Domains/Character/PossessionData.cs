using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 夺舍角色的数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class PossessionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort SoulCharId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "SoulCharId" };
	}

	/// <summary>
	/// 夺舍者原来的Id
	/// </summary>
	[SerializableGameDataField]
	public int SoulCharId;

	/// <summary>
	/// 夺舍者原来的Id
	/// </summary>
	[SerializableGameDataField]
	public List<int> SoulCharIds;

	public PossessionData(int soulCharId)
	{
		SoulCharId = soulCharId;
	}

	public PossessionData(List<int> soulCharIds)
	{
		SoulCharIds = soulCharIds;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public PossessionData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public PossessionData(PossessionData other)
	{
		SoulCharId = other.SoulCharId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(PossessionData other)
	{
		SoulCharId = other.SoulCharId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(int*)num = SoulCharId;
		int totalSize = (int)(num + 4 - pData);
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
			SoulCharId = *(int*)pCurrData;
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

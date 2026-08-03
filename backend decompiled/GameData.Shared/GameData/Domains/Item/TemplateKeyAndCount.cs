using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 物品类型和模板id以及数量
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct TemplateKeyAndCount : ISerializableGameData
{
	/// <summary>
	/// 物品类型和模板id
	/// </summary>
	[SerializableGameDataField]
	public TemplateKey TemplateKey;

	/// <summary>
	/// 数量
	/// </summary>
	[SerializableGameDataField]
	public int Count;

	public static implicit operator TemplateKeyAndCount((TemplateKey templateKey, int count) tuple)
	{
		TemplateKeyAndCount result = default(TemplateKeyAndCount);
		(result.TemplateKey, result.Count) = tuple;
		return result;
	}

	/// <summary>
	/// 隐式转换
	/// </summary>
	public static implicit operator TemplateKeyAndCount(TemplateKey templateKey)
	{
		return new TemplateKeyAndCount
		{
			TemplateKey = templateKey,
			Count = 1
		};
	}

	/// <summary>
	/// 反构造
	/// </summary>
	public void Deconstruct(out TemplateKey templateKey, out int count)
	{
		templateKey = TemplateKey;
		count = Count;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
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
		pCurrData += TemplateKey.Serialize(pCurrData);
		*(int*)pCurrData = Count;
		pCurrData += 4;
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
		pCurrData += TemplateKey.Deserialize(pCurrData);
		Count = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

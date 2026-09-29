using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true)]
public struct TemplateKeyAndCount : ISerializableGameData
{
	[SerializableGameDataField]
	public TemplateKey TemplateKey;

	[SerializableGameDataField]
	public int Count;

	public static implicit operator TemplateKeyAndCount((TemplateKey templateKey, int count) tuple)
	{
		TemplateKeyAndCount result = default(TemplateKeyAndCount);
		(result.TemplateKey, result.Count) = tuple;
		return result;
	}

	public static implicit operator TemplateKeyAndCount(TemplateKey templateKey)
	{
		return new TemplateKeyAndCount
		{
			TemplateKey = templateKey,
			Count = 1
		};
	}

	public void Deconstruct(out TemplateKey templateKey, out int count)
	{
		templateKey = TemplateKey;
		count = Count;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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

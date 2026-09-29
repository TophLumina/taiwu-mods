using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class QiArtStrategyDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte TemplateId;

	[SerializableGameDataField]
	public int ExpireTime;

	public QiArtStrategyDisplayData()
	{
	}

	public QiArtStrategyDisplayData(QiArtStrategyDisplayData other)
	{
		TemplateId = other.TemplateId;
		ExpireTime = other.ExpireTime;
	}

	public void Assign(QiArtStrategyDisplayData other)
	{
		TemplateId = other.TemplateId;
		ExpireTime = other.ExpireTime;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)TemplateId;
		byte* num = pData + 1;
		*(int*)num = ExpireTime;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		ExpireTime = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

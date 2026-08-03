using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 角色持有秘闻数据集合
/// </summary>
public class SecretInformationCharacterDataCollection : ISerializableGameData
{
	/// <summary>
	/// 集合对象
	/// </summary>
	[SerializableGameDataField]
	public readonly IDictionary<int, SecretInformationCharacterData> Collection;

	public SecretInformationCharacterDataCollection()
	{
		Collection = new Dictionary<int, SecretInformationCharacterData>();
	}

	public SecretInformationCharacterDataCollection(SecretInformationCharacterDataCollection other)
		: this()
	{
		Assign(other);
	}

	public void Assign(SecretInformationCharacterDataCollection other)
	{
		Collection.Clear();
		foreach (KeyValuePair<int, SecretInformationCharacterData> pair in other.Collection)
		{
			Collection.Add(pair.Key, pair.Value);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int size = 4;
		foreach (KeyValuePair<int, SecretInformationCharacterData> pair in Collection)
		{
			size += 4;
			size += pair.Value.GetSerializedSize();
		}
		return size;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Collection.Count;
		pCurrData += 4;
		foreach (KeyValuePair<int, SecretInformationCharacterData> pair in Collection)
		{
			*(int*)pCurrData = pair.Key;
			pCurrData += 4;
			pCurrData += pair.Value.Serialize(pCurrData);
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int size = *(int*)pCurrData;
		pCurrData += 4;
		Collection.Clear();
		for (int i = 0; i < size; i++)
		{
			int key = *(int*)pCurrData;
			SecretInformationCharacterData value = new SecretInformationCharacterData();
			pCurrData += 4;
			pCurrData += value.Deserialize(pCurrData);
			Collection.Add(key, value);
		}
		return (int)(pCurrData - pData);
	}
}

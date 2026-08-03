using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 一个角色用于显示的轮回数据
/// </summary>
public class CharacterSamsaraData : ISerializableGameData
{
	/// <summary>
	/// 所有有效的前世轮回数据
	/// </summary>
	[SerializableGameDataField]
	public List<DeadCharacter> DeadCharacters;

	/// <summary>
	/// 所有有效的前世名称数据
	/// </summary>
	[SerializableGameDataField]
	public List<NameRelatedData> DeadCharacterNames;

	/// <summary>
	/// 前世轮回数据的位置
	/// </summary>
	[SerializableGameDataField]
	public PreexistenceCharIds PreexistenceCharIds;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CharacterSamsaraData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CharacterSamsaraData(CharacterSamsaraData other)
	{
		if (other.DeadCharacters != null)
		{
			List<DeadCharacter> item = other.DeadCharacters;
			int elementsCount = item.Count;
			DeadCharacters = new List<DeadCharacter>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				DeadCharacters.Add(new DeadCharacter(item[i]));
			}
		}
		else
		{
			DeadCharacters = null;
		}
		DeadCharacterNames = ((other.DeadCharacterNames == null) ? null : new List<NameRelatedData>(other.DeadCharacterNames));
		PreexistenceCharIds = other.PreexistenceCharIds;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CharacterSamsaraData other)
	{
		if (other.DeadCharacters != null)
		{
			List<DeadCharacter> item = other.DeadCharacters;
			int elementsCount = item.Count;
			DeadCharacters = new List<DeadCharacter>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				DeadCharacters.Add(new DeadCharacter(item[i]));
			}
		}
		else
		{
			DeadCharacters = null;
		}
		DeadCharacterNames = ((other.DeadCharacterNames == null) ? null : new List<NameRelatedData>(other.DeadCharacterNames));
		PreexistenceCharIds = other.PreexistenceCharIds;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 40;
		if (DeadCharacters != null)
		{
			totalSize += 2;
			int elementsCount = DeadCharacters.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				DeadCharacter element = DeadCharacters[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((DeadCharacterNames == null) ? (totalSize + 2) : (totalSize + (2 + 32 * DeadCharacterNames.Count)));
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
		if (DeadCharacters != null)
		{
			int elementsCount = DeadCharacters.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				DeadCharacter element = DeadCharacters[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DeadCharacterNames != null)
		{
			int elementsCount2 = DeadCharacterNames.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += DeadCharacterNames[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += PreexistenceCharIds.Serialize(pCurrData);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (DeadCharacters == null)
			{
				DeadCharacters = new List<DeadCharacter>(elementsCount);
			}
			else
			{
				DeadCharacters.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					DeadCharacter element = new DeadCharacter();
					pCurrData += element.Deserialize(pCurrData);
					DeadCharacters.Add(element);
				}
				else
				{
					DeadCharacters.Add(null);
				}
			}
		}
		else
		{
			DeadCharacters?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (DeadCharacterNames == null)
			{
				DeadCharacterNames = new List<NameRelatedData>(elementsCount2);
			}
			else
			{
				DeadCharacterNames.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				NameRelatedData element2 = new NameRelatedData();
				pCurrData += element2.Deserialize(pCurrData);
				DeadCharacterNames.Add(element2);
			}
		}
		else
		{
			DeadCharacterNames?.Clear();
		}
		pCurrData += PreexistenceCharIds.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

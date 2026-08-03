using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 仙人泼墨/豪侠研武人物显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class CharacterDisplayDataForTasterUltimate : ISerializableGameData
{
	/// <summary>
	/// 角色通用滚动列表显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList CharacterData;

	/// <summary>
	/// 研读进度数据列表
	/// </summary>
	[SerializableGameDataField]
	public List<ReadProgressData> ReadProgressList;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CharacterData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterData.GetSerializedSize())));
		if (ReadProgressList != null)
		{
			totalSize += 2;
			for (int i = 0; i < ReadProgressList.Count; i++)
			{
				totalSize += ReadProgressList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadProgressList != null)
		{
			int elementsCount = ReadProgressList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize2 = ReadProgressList[i].Serialize(pCurrData);
				pCurrData += fieldSize2;
				Tester.Assert(fieldSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
			CharacterData = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += CharacterData.Deserialize(pCurrData);
		}
		else
		{
			CharacterData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ReadProgressList == null)
			{
				ReadProgressList = new List<ReadProgressData>();
			}
			else
			{
				ReadProgressList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ReadProgressData element = default(ReadProgressData);
				pCurrData += element.Deserialize(pCurrData);
				ReadProgressList.Add(element);
			}
		}
		else
		{
			ReadProgressList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
